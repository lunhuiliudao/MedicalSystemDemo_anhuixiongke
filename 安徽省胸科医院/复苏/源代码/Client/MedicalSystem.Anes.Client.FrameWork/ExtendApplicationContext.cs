using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Domain;
using System.Windows.Forms;
using System.Configuration;
using MedicalSystem.Anes.Document;
using System.Data;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class ExtendApplicationContext
    {
        public readonly static ExtendApplicationContext Current = new ExtendApplicationContext();
        private static string _CurrentDocName = string.Empty;
        private CommDict _commDict = null;
        private DateTime _LastSelectedDateTime = DateTime.MinValue;
        private DateTime _CurrentDateTime = DateTime.MinValue;
        private string _CurrentSearchStr = string.Empty;
        private long _ClockTick = 0;
        private long _SystemRunClockTick = 0;
        private long _ClockPacuTick = 0;
        private CustomSettingContext _CustomSettingContext = new CustomSettingContext();
        private Dictionary<string, DataTable> _codeTables = new Dictionary<string, DataTable>();
        public DateTime CurrentDateTime
        {
            get { return _CurrentDateTime; }
            set { _CurrentDateTime = value; }
        }
        public string CurrentSearchStr
        {
            get { return _CurrentSearchStr; }
            set { _CurrentSearchStr = value; }
        }
        public string CurrentDocName
        {
            get { return _CurrentDocName; }
            set { _CurrentDocName = value; }
        }
        //时钟控制（单位秒）
        public long ClockTick
        {
            get { return _ClockTick; }
            set { _ClockTick = value; }
        }
        //系统总共运行时间（单位秒）
        public long SystemRunClockTick
        {
            get { return _SystemRunClockTick; }
            set { _SystemRunClockTick = value; }
        }
        public long ClockPacuTick
        {
            get { return _ClockPacuTick; }
            set { _ClockPacuTick = value; }
        }
        private ProgramProcess _SystemCurrentProcess = ProgramProcess.SystemStart;

        private string[] _programArgs;
        //系统运行参数
        public string[] ProgramArgs
        {
            get { return _programArgs; }
            set { _programArgs = value; }
        }
        //系统当前进程（单位秒）
        public ProgramProcess SystemCurrentProcess
        {
            get { return _SystemCurrentProcess; }
            set { _SystemCurrentProcess = value; }
        }
        /// <summary>
        /// 字典表
        /// </summary>
        public CommDict CommDict
        {
            get
            {
                if (_commDict == null)
                {
                    _commDict = new CommDict();
                }
                return _commDict;
            }
        }

        //private ProgramStatus _systemStatus = ProgramStatus.NoPatient;
        //private OperationStatus _OperationStatus = OperationStatus.None;
        private string _ApplicationID = "ANES6";
        private Dictionary<string, MedVitalSignCurveDetail> _VitalSignCurveDetailDict = null;
        private bool _isShowBloodGasItems = false;

        /// <summary>
        /// 应用程序权限ID
        /// </summary>
        public string ApplicationID
        {
            get { return _ApplicationID; }
            set { _ApplicationID = value; }
        }
        /// <summary>
        /// 最后一次被选中的时间
        /// </summary>
        public DateTime LastSelectedDateTime
        {
            get { return _LastSelectedDateTime; }
            set { _LastSelectedDateTime = value; }
        }

        private ApplicationType _appType = ApplicationType.Anesthesia;
        public ApplicationType AppType
        {
            get
            {
                return _appType;
            }
            set
            {
                _appType = value;
            }
        }

        private string _eventNo = "0";
        public string EventNo
        {
            get
            {
                return _eventNo;
            }
            set
            {
                _eventNo = value;
            }
        }

        private MED_PATIENT_CARD _PatientInformation = new MED_PATIENT_CARD();

        public MED_PATIENT_CARD PatientInformationExtend
        {
            get
            {
                return _PatientInformation;
            }
            set
            {
                _PatientInformation = value;
                if (_PatientInformation != null)
                {
                    _PatientContext.PatientID = _PatientInformation.PATIENT_ID;
                    _PatientContext.VisitID = _PatientInformation.VISIT_ID;
                    _PatientContext.OperID = _PatientInformation.OPER_ID;
                }
            }
        }

        private PatientContext _PatientContext = new PatientContext();

        public PatientContext PatientContextExtend
        {
            get
            {
                return _PatientContext;
            }
            set
            {
                _PatientContext = value;
            }
        }

        private bool _isSync = false;
        public bool IsSync
        {
            get
            {
                string text = GetSetting("IsSync");
                bool result;
                if (bool.TryParse(text, out result))
                {
                    _isSync = result;
                }
                else
                {
                    _isSync = false;
                }
                return _isSync;
            }
            set
            {
                _isSync = value;
                SetSetting("IsSync", value.ToString());
            }
        }

        private string _anesthesiaWardCode = null;
        /// <summary>
        /// 麻醉科代码
        /// </summary>
        public string AnesthesiaWardCode
        {
            get
            {
                if (string.IsNullOrEmpty(_anesthesiaWardCode))
                    _anesthesiaWardCode = GetSetting("AnesthesiaWardCode");
                return _anesthesiaWardCode;
            }
            set
            {
                _anesthesiaWardCode = value;
                SetSetting("AnesthesiaWardCode", value);
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
        private int _anesDocPageHours = 5;
        /// <summary>
        /// 麻醉单每页显示的小时数
        /// </summary>
        public int AnesDocPageHours
        {
            get
            {
                int result = 0;
                if (int.TryParse(GetSetting("AnesDocPageHours"), out result))
                    _anesDocPageHours = result;
                return _anesDocPageHours;
            }
            set
            {
                _anesDocPageHours = value;
                SetSetting("AnesDocPageHours", value.ToString());
            }
        }
        private string _operRoom = null;
        /// <summary>
        /// 手术室代码
        /// </summary>
        public string OperRoom
        {
            get
            {
                if (string.IsNullOrEmpty(_operRoom))
                    _operRoom = GetSetting("OperRoom");
                return _operRoom;
            }
            set
            {
                _operRoom = value;
                SetSetting("OperRoom", value);
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
                    _operRoomNo = GetSetting("OperRoomNo");
                return _operRoomNo;
            }
            set
            {
                _operRoomNo = value;
                SetSetting("OperRoomNo", value);
            }
        }
        private string _baseAddress = null;
        /// <summary>
        /// 本地服URI
        /// </summary>
        public string BaseAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_baseAddress))
                    _baseAddress = GetSetting("BaseAddress");
                return _baseAddress;
            }
            set
            {
                _baseAddress = value;
                SetSetting("BaseAddress", value);
            }
        }
        private string _webApiUri = null;
        /// <summary>
        /// 服务器URI
        /// </summary>
        public string WebApiUri
        {
            get
            {
                if (string.IsNullOrEmpty(_webApiUri))
                    _webApiUri = GetSetting("WebApiUri");
                return _webApiUri;
            }
            set
            {
                _webApiUri = value;
                SetSetting("WebApiUri", value);
            }
        }
        private string _firstFounding = "08:00";
        /// <summary>
        /// 首台开台时间 
        /// </summary>
        public string FirstFounding
        {
            get
            {
                if (string.IsNullOrEmpty(_firstFounding))
                    _firstFounding = GetSetting("FirstFounding");
                return _firstFounding;
            }
            set
            {
                _firstFounding = value;
                SetSetting("FirstFounding", value);
            }
        }
        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIP { get; set; }

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

        // 字典表集合
        //public Dictionary<string, List<MED_EVENT_DICT>> _codeLists = new Dictionary<string, List<MED_EVENT_DICT>>(); 

        private PermissionContext _permissionContext = new PermissionContext();

        public PermissionContext PermissionContext
        {
            get { return _permissionContext; }
            set { _permissionContext = value; }
        }
        /// <summary>
        /// 当前登录的用户表
        /// </summary>
        public MED_USERS LoginUser { get; set; }

        public List<MED_PERMISSIONS> PermissionsList { get; set; }

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

        public bool IsShowBloodGasItems
        {
            get { return _isShowBloodGasItems; }
            set { _isShowBloodGasItems = value; }
        }
        /// <summary>
        /// 常用客户化设置
        /// </summary>
        public CustomSettingContext CustomSettingContext
        {
            get { return _CustomSettingContext; }
            set { _CustomSettingContext = value; }
        }
        private string _HospitalID;
        public string HospitalID
        {
            get { return _HospitalID; }
            set { _HospitalID = value; }
        }
        private string _HospitalName;
        public string HospitalName
        {
            get { return _HospitalName; }
            set { _HospitalName = value; }
        }
        private string _hospBranchCode = "";

        /// <summary>
        /// 分院编号
        /// </summary>
        public string HospBranchCode
        {
            get
            {
                if (string.IsNullOrEmpty(_hospBranchCode))
                    _hospBranchCode = GetSetting("HospBranchCode");
                return _hospBranchCode;
            }
            set { _hospBranchCode = value; SetSetting("HospBranchCode", value); }
        }

        private int _screenLocker = 0;
        /// <summary>
        /// 锁屏时间-分钟
        /// </summary>
        public int ScreenLocker
        {
            get
            {
                int result = 0;
                if (_screenLocker <= 0)
                {
                    if (int.TryParse(GetSetting("ScreenLocker"), out result))
                        _screenLocker = result * 60;
                    //if (_screenLocker <= 300) _screenLocker = 300;
                    else
                        return 300;
                }
                return _screenLocker;
            }
            set { _screenLocker = value; SetSetting("ScreenLocker", value.ToString()); }
        }


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
        private ProgramStatus _systemStatus = ProgramStatus.NoPatient;
        public ProgramStatus SystemStatus
        {
            get { return _systemStatus; }
            set { _systemStatus = value; }
        }
        private Dictionary<ProgramStatus, string> _statusButtonStrList = new Dictionary<ProgramStatus, string>();
        public Dictionary<ProgramStatus, string> StatusButtonStrList
        {
            get { return _statusButtonStrList; }
            set { _statusButtonStrList = value; }
        }
        //private OperationAction _operAction = OperationAction.NoPatient;
        //public OperationAction OperAction
        //{
        //    get { return _operAction; }
        //    set { _operAction = value; }
        //}
        //private Dictionary<OperationAction, string> _operActionStrList = new Dictionary<OperationAction, string>();
        //public Dictionary<OperationAction, string> OperActionStrList
        //{
        //    get { return _operActionStrList; }
        //    set { _operActionStrList = value; }
        //}
        private OperationStatus _OperationStatus = OperationStatus.None;
        public OperationStatus OperationStatus
        {
            get { return _OperationStatus; }
            set { _OperationStatus = value; }
        }

        private List<MED_CONFIG> _configTable;

        public List<MED_CONFIG> ConfigTable
        {
            get { return _configTable; }
            set { _configTable = value; }
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
        private string _defaultMonitorItems = null;
        /// <summary>
        /// 默认体征项目
        /// </summary>
        public string DefaultMonitorItems
        {
            get
            {
                if (string.IsNullOrEmpty(_defaultMonitorItems))
                    _defaultMonitorItems = ConfigurationManager.AppSettings["DefaultMonitorItems"];
                return _defaultMonitorItems;
            }
            set
            {
                _defaultMonitorItems = value;
                SetSetting("DefaultMonitorItems", value);
            }
        }




    }
}
