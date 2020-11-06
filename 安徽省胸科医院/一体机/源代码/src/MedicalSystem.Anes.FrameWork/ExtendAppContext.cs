using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MedicalSystem.AnesWorkStation.Domain;
using System.Configuration;
using System.Windows.Forms;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork.Enum;
using System.Windows.Threading;
using MedicalSystem.AnesWorkStation.Model.InOperationModel.DrugGraphModel;

namespace MedicalSystem.Anes.FrameWork
{
    public class ExtendAppContext
    {
        /// <summary>
        /// 当前选中患者
        /// </summary>
        public readonly static ExtendAppContext Current = new ExtendAppContext();

        /// <summary>
        /// 在当前选中患者变更时刷新LED手术状态灯
        /// </summary>
        public event EventHandler RefreshCurrentPatientInfo = null;
        public MedVitalSignGraph _VitalSignGraph = null;
        private CommDict _commDict = null;
        private CustomSettingContext _CustomSettingContext = new CustomSettingContext();
        private DateTime _anesStartTime = DateTime.Now;
        private Dictionary<string, DataTable> _codeTables = new Dictionary<string, DataTable>();
        private string _EventNo = "0";
        private string _deptCode = string.Empty;
        private string _anesWardCode = null;
        private static string _CurrentDocName = string.Empty;
        private EnumLoginType curEnumLoginType = EnumLoginType.NormalLogin;                           // 登录枚举：正常登录还是锁屏登录还是注销登录
        private DateTime operationRescueStartTime = DateTime.MinValue;                                // 抢救开始时间
        private bool isOperationRescuing = false;                                                     // 是否处于抢救状态
        private string patientID = "";
        public string PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }
        private int visitID = 0;
        public int VisitID
        {
            get { return visitID; }
            set { visitID = value; }
        }
        private int operID = 0;
        public int OperID
        {
            get { return operID; }
            set { operID = value; }
        }

        private ExtendAppContext()
        {
            this.ExitFrameCallback = new DispatcherOperationCallback(ExitFrame);
        }

        private MED_PAT_INFO _PatientInformation = null;

        public MED_PAT_INFO PatientInformationExtend
        {
            get
            {
                return _PatientInformation;
            }
            set
            {
                _PatientInformation = value;
                if (null != this.RefreshCurrentPatientInfo)
                {
                    this.RefreshCurrentPatientInfo(null, null);
                }
            }
        }

        /// <summary>
        /// 麻醉科代码
        /// </summary>
        public string AnesWardCode
        {
            get
            {
                if (string.IsNullOrEmpty(_anesWardCode))
                    _anesWardCode = GetSetting("AnesWardCode");
                return _anesWardCode;
            }
            set
            {
                _anesWardCode = value;
                SetSetting("AnesWardCode", value);
            }
        }

        private string _operDeptCode = null;
        /// <summary>
        /// 手术室代码
        /// </summary>
        public string OperDeptCode
        {
            get
            {
                if (string.IsNullOrEmpty(_operDeptCode))
                    _operDeptCode = GetSetting("OperDeptCode");
                return _operDeptCode;
            }
            set
            {
                _operDeptCode = value;
                SetSetting("OperDeptCode", value);
            }
        }

        private string _operRoomNo = null;
        /// <summary>
        /// 当前系统配置默认手术间
        /// </summary>
        public string OperRoomNo
        {
            get
            {
                if (string.IsNullOrEmpty(_operRoomNo))
                {
                    _operRoomNo = GetSetting("OperRoomNo");
                }

                if (string.IsNullOrEmpty(this._operRoomNo))
                {
                    this._operRoomNo = "1";
                }

                return _operRoomNo;
            }
            set
            {
                _operRoomNo = value;
                SetSetting("OperRoomNo", value);
            }
        }

        private string _loginName = null;
        public string LoginName
        {
            get
            {
                if (string.IsNullOrEmpty(_loginName))
                    _loginName = GetSetting("LoginName");
                return _loginName;
            }
            set
            {
                _loginName = value;
                SetSetting("LoginName", value);
            }
        }
        public string CurrentDocName
        {
            get { return _CurrentDocName; }
            set { _CurrentDocName = value; }
        }
        /// <summary>
        /// 生成文书图片触发地址
        /// </summary>
        private string webRequestDocUrl = null;
        public string WebRequestDocUrl
        {
            get
            {
                if (string.IsNullOrEmpty(webRequestDocUrl))
                    webRequestDocUrl = GetSetting("WebRequestDocUrl");
                return webRequestDocUrl;
            }
            set
            {
                webRequestDocUrl = value;
                SetSetting("WebRequestDocUrl", value);
            }
        }
        private string[] _programArgs;
        /// <summary>
        /// 系统运行参数
        /// </summary>
        public string[] ProgramArgs
        {
            get { return _programArgs; }
            set { _programArgs = value; }
        }
        /// <summary>
        /// 字典表
        /// </summary>
        //public CommDict CommDict
        //{
        //    get
        //    {
        //        if (_commDict == null)
        //        {
        //            _commDict = new CommDict();
        //        }
        //        return _commDict;
        //    }
        //}

        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static bool SetSetting(string key, string value)
        {
            bool bRes = true;
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[key] == null)
                {
                    config.AppSettings.Settings.Add(key, value);
                }
                else
                {
                    config.AppSettings.Settings[key].Value = value;
                }
                config.Save(ConfigurationSaveMode.Modified);
                if (ConfigurationManager.AppSettings[key] == null)
                {
                    bRes = false;
                }
                else
                {
                    ConfigurationManager.AppSettings.Set(key, value);
                }
            }
            catch
            {

            }
            return bRes;
        }

        /// <summary>
        /// 字典表
        /// </summary>
        public Dictionary<string, DataTable> CodeTables
        {
            get
            {
                return _codeTables;
            }
            set
            {
                _codeTables = value;
            }
        }

        /// <summary>
        /// 常用客户化设置
        /// </summary>
        public CustomSettingContext CustomSettingContext
        {
            get { return _CustomSettingContext; }
            set { _CustomSettingContext = value; }
        }

        public DateTime AnesStartTime
        {
            get
            {
                return _anesStartTime;
            }
            set
            {
                _anesStartTime = value;
            }
        }

        private string _appPath = string.Empty;
        /// <summary>
        /// 文书路径
        /// </summary>
        public string AppPath
        {
            get
            {
                if (string.IsNullOrEmpty(_appPath))
                {
                    string path = Application.ExecutablePath;
                    if (path.Contains(@"\"))
                    {
                        int pos = path.LastIndexOf(@"\");
                        path = path.Remove(pos + 1);
                    }
                    if (!path.EndsWith(@"\"))
                        path += @"\";
                    _appPath = path;

                }
                return _appPath;
            }
        }

        public string EventNo
        {
            get { return _EventNo; }
            set { _EventNo = value; }
        }

        private Dictionary<string, MedVitalSignCurveDetail> _VitalSignCurveDetailDict = null;
        public Dictionary<string, MedVitalSignCurveDetail> VitalSignCurveDetailDict
        {
            get { return _VitalSignCurveDetailDict; }
            set { _VitalSignCurveDetailDict = value; }
        }

        private Dictionary<string, string> _monitorFunctionCodeDict = new Dictionary<string, string>();
        public Dictionary<string, string> MonitorFunctionCodeDict
        {
            get { return _monitorFunctionCodeDict; }
            set { _monitorFunctionCodeDict = value; }
        }

        private bool _isShowBloodGasItems = false;
        public bool IsShowBloodGasItems
        {
            get { return _isShowBloodGasItems; }
            set { _isShowBloodGasItems = value; }
        }

        private List<string> _defaultBloodGasItem = new List<string>();

        public List<string> DefaultBloodGasItem
        {
            get { return _defaultBloodGasItem; }
            set { _defaultBloodGasItem = value; }
        }
        private Dictionary<string, string> _bloodGasItemDict = new Dictionary<string, string>();

        public Dictionary<string, string> BloodGasItemDict
        {
            get { return _bloodGasItemDict; }
            set { _bloodGasItemDict = value; }
        }
        /// <summary>
        /// 是否刷新体征数据
        /// </summary>
        private bool _isRefVitalSigns = true;
        public bool IsRefVitalSigns
        {
            get { return _isRefVitalSigns; }
            set { _isRefVitalSigns = value; }
        }
        /// <summary>
        /// 是否是抢救模式
        /// </summary>
        private bool _isRescueMode = false;
        public bool IsRescueMode
        {
            get { return _isRescueMode; }
            set { _isRescueMode = value; }
        }

        /// <summary>
        /// 记录原先网格的最小竖线数
        /// </summary>
        private int _oldMinScaleCount = 3;
        public int OldMinScaleCount
        {
            get { return _oldMinScaleCount; }
            set { _oldMinScaleCount = value; }
        }

        private MED_USERS loginUser = new MED_USERS();
        /// <summary>
        /// 当前登录的用户表
        /// </summary>
        public MED_USERS LoginUser
        {
            get { return this.loginUser; }
            set { this.loginUser = value; }
        }

        /// <summary>
        /// 搜索列表的患者是否有操作权限
        /// </summary>
        private bool isPermission = true;

        /// <summary>
        /// 搜索列表的患者是否有操作权限
        /// </summary>
        public bool IsPermission
        {
            get { return this.isPermission; }
            set { this.isPermission = value; }
        }

        /// <summary>
        /// 当前手术信息
        /// </summary>
        public MED_OPERATION_MASTER MED_OPERATION_MASTER { get; set; }
        /// <summary>
        /// 当前病人信息
        /// </summary>
        public MED_PAT_MASTER_INDEX MED_PAT_MASTER_INDEX { get; set; }
        /// <summary>
        /// 当前住院信息
        /// </summary>
        public MED_PAT_VISIT MED_PAT_VISIT { get; set; }

        public OpenForm CurntOpenForm { get; set; }

        private bool isModify = true;
        public bool IsModify
        {
            get { return this.isModify; }
            set { this.isModify = value; }
        }

        /// <summary>
        /// 当前登录枚举
        /// </summary>
        public EnumLoginType CurEnumLoginType
        {
            get { return this.curEnumLoginType; }
            set { this.curEnumLoginType = value; }
        }

        /// <summary>
        /// 抢救开始时间，默认：DateTime.MinValue
        /// </summary>
        public DateTime OperationRescueStartTime
        {
            get { return this.operationRescueStartTime; }
        }

        /// <summary>
        /// 正常关闭操作流程
        /// </summary>
        public bool IsNormalClosing = false;

        /// <summary>
        /// 是否处于抢救状态
        /// </summary>
        public bool IsOperationRescuing
        {
            get { return this.isOperationRescuing; }
            set
            {
                this.isOperationRescuing = value;
                if (this.isOperationRescuing)
                {
                    // 进入抢救状态
                    DateTime tempDt = DateTime.Now;
                    this.operationRescueStartTime = new DateTime(tempDt.Year, tempDt.Month, tempDt.Day, tempDt.Hour, tempDt.Minute, 0);
                }
            }
        }


        private List<OperEventInfoModel> operEventInfoList = null;

        /// <summary>
        /// 所有大事件按键、描述、对应类型 等信息列表
        /// </summary>
        public List<OperEventInfoModel> OperEventInfoList
        {
            get
            {
                if (null == this.operEventInfoList)
                {
                    this.operEventInfoList = new List<OperEventInfoModel>();
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.AnesDrug, "麻药录入", "OperationMedNoteControl"));
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.Drug, "用药录入", "OperationMedNoteControl"));
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.InLiquid, "输液录入", "OperationMedNoteControl"));
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.Event, "事件录入", "OperationEventNoteControl"));
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.Breath, "呼吸录入", "OperationMedNoteControl"));
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.Oxygen, "输氧录入", "OperationMedNoteControl"));
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.Blood, "输血录入", "OperationMedNoteControl"));
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.Intubatton, "插管录入", "OperationEventNoteControl"));
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.Extubation, "拔管录入", "OperationEventNoteControl"));
                    this.operEventInfoList.Add(new OperEventInfoModel(KeyCode.AppCode.OutLiquid, "出液录入", "OperationMedNoteControl"));
                }

                return this.operEventInfoList;
            }
        }

        private DispatcherOperationCallback ExitFrameCallback = null;

        /// <summary>
        /// DoEvents，类似Application.DoEvents
        /// </summary>
        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrameCallback), frame);
            Dispatcher.PushFrame(frame);
        }

        private Object ExitFrame(Object state)
        {
            (state as DispatcherFrame).Continue = false;
            return null;
        }

        /// <summary>
        /// 不影响界面的休眠
        /// </summary>
        /// <param name="millSec">毫秒</param>
        public void Sleep(int millSec)
        {
            int split = 100;
            int count = millSec / split;
            for (int i = 0; i < count; i++)
            {
                System.Threading.Thread.Sleep(split);
                this.DoEvents();
            }
        }

        private string _cameraImageLocalPath = null;
        /// <summary>
        /// 拍照-本地路径
        /// </summary>
        public string CameraImageLocalPath
        {
            get
            {
                if (string.IsNullOrEmpty(_cameraImageLocalPath))
                    _cameraImageLocalPath = GetSetting("CameraImageLocalPath");
                if (string.IsNullOrEmpty(_cameraImageLocalPath))
                {
                    _cameraImageLocalPath = "D:\\一体机图片\\";
                }
                return _cameraImageLocalPath;
            }
            set
            {
                _cameraImageLocalPath = value;
                SetSetting("CameraImageLocalPath", value);
            }
        }
        private string _cameraImageServePath = null;
        /// <summary>
        /// 拍照-服务器路径
        /// </summary>
        public string CameraImageServePath
        {
            get
            {
                if (string.IsNullOrEmpty(_cameraImageServePath))
                    _cameraImageServePath = GetSetting("CameraImageServePath");
                if (string.IsNullOrEmpty(_cameraImageServePath))
                {
                    _cameraImageServePath = "D:\\一体机图片\\";
                }
                return _cameraImageServePath;
            }
            set
            {
                _cameraImageServePath = value;
                SetSetting("CameraImageServePath", value);
            }
        }
    }
}
