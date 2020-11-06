//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      EmergencyRegisterViewModel.cs
//功能描述(Description)：    急诊登记
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:05:39
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.EmergencyRegisterViewModel
{

    /// <summary>
    /// 急诊登记ViewModel
    /// </summary>
    public class EmergencyRegisterViewModel : BaseViewModel
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public EmergencyRegisterViewModel()
        {
            // 载入字典数据
            LoadDictData();

            // 默认手术日期为当前
            SCHEDULED_DATE_TIME = DateTime.Now;
        }

        /// <summary>
        /// 保存返回值
        /// </summary>
        SaveResult saveResult = SaveResult.Fail;


        #region 界面控件字段绑定
        private string _OPER_ROOM_NO;                                              // 手术间号
        private Nullable<Int32> _SEQUENCE;                                         // 台次
        private string _PATIENT_ID;                                                // 患者ID
        private string _INP_NO;                                                    // 住院号
        private string _NAME;                                                      // 姓名
        private string _SEX;                                                       // 性别
        private Nullable<DateTime> _DATE_OF_BIRTH;                                 // 出生日期
        private string _BED_NO;                                                    // 床号
        private string _DEPT_CODE;                                                 // 科室代码
        private string _DIAG_BEFORE_OPERATION;                                     // 术前诊断
        private ObservableCollection<string> _OPERATION_NAME = new ObservableCollection<string>();          // 拟施手术
        private string _OPER_SCALE;                                                // 手术等级
        private string _OPER_POSITION;                                             // 手术体位
        private Nullable<Int32> _EMERGENCY_IND;                                    // 急诊择期
        private Nullable<Int32> _ISOLATION_IND;                                    // 隔离标志
        private Nullable<Int32> _RADIATE_IND;                                      // 放射标志
        private string _PATIENT_CONDITION;                                         // 病情
        private string _SURGEON;                                                    // 手术医生1
        private string _SURGEON_NAME;
        private string _FIRST_OPER_ASSISTANT;                                      // 手术医生2
        private string _FIRST_OPER_ASSISTANT_NAME;
        private string _SECOND_OPER_ASSISTANT;                                     // 手术医生3
        private string _SECOND_OPER_ASSISTANT_NAME;
        private string _CPB_DOCTOR;                                                // 灌注医生1
        private string _CPB_DOCTOR_NAME;
        private string _FIRST_CPB_ASSISTANT;                                       // 灌注医生2
        private string _FIRST_CPB_ASSISTANT_NAME;
        private string _FIRST_OPER_NURSE;                                          // 洗手护士1
        private string _FIRST_OPER_NURSE_NAME;
        private string _SECOND_OPER_NURSE;                                         // 洗手护士2
        private string _SECOND_OPER_NURSE_NAME;
        private string _FIRST_SUPPLY_NURSE;                                        // 巡回护士1
        private string _FIRST_SUPPLY_NURSE_NAME;
        private string _SECOND_SUPPLY_NURSE;                                       // 巡回护士2
        private string _SECOND_SUPPLY_NURSE_NAME;
        private string _ANES_METHOD;                                               // 麻醉方法
        private string _ANAESTHESIA_TYPE;                                          // 麻醉方法分类
        private string _ANES_DOCTOR;                                               // 麻醉医生1
        private string _ANES_DOCTOR_NAME;
        private string _FIRST_ANES_ASSISTANT;                                      // 麻醉医生2
        private string _FIRST_ANES_ASSISTANT_NAME;
        private string _SECOND_ANES_ASSISTANT;                                     // 麻醉医生3
        private string _SECOND_ANES_ASSISTANT_NAME;
        private string _THIRD_ANES_ASSISTANT;                                      // 麻醉医生4
        private string _THIRD_ANES_ASSISTANT_NAME;
        private string _ASA_GRADE;                                                 // ASA分级
        private string _WOUND_TYPE;                                                // 切口等级
        private string _RETURN_TO_SURGERY;                                         // 是否24小时内重返手术室
        private string _PLAN_WHEREABORTS;                                          // 术后计划患者去向
        private DateTime _SCHEDULED_DATE_TIME;                                     // 手术日期
        private int minimalInvasive;                                               // 微创手术标识
        private bool _isTimeFocused = false;

        /// <summary>
        /// 微创手术标识：0（否） 1（是）
        /// </summary>
        public int MINIMAL_INVASIVE
        {
            get { return this.minimalInvasive; }
            set
            {
                this.minimalInvasive = value;
                this.RaisePropertyChanged("MINIMAL_INVASIVE");
            }
        }

        /// <summary>
        /// 手术日期
        /// </summary>
        public DateTime SCHEDULED_DATE_TIME
        {
            get { return _SCHEDULED_DATE_TIME; }
            set
            {
                _SCHEDULED_DATE_TIME = value;
                RaisePropertyChanged("SCHEDULED_DATE_TIME");
            }
        }

        /// <summary>
        /// 手术间号
        /// </summary>
        public string OPER_ROOM_NO
        {
            get
            {
                return _OPER_ROOM_NO;
            }
            set
            {
                this._OPER_ROOM_NO = value;
                RaisePropertyChanged("OPER_ROOM_NO");
            }
        }
        /// <summary>
        /// 台次
        /// </summary>
        public Nullable<Int32> SEQUENCE
        {
            get
            {
                return _SEQUENCE;
            }
            set
            {
                this._SEQUENCE = value;
                RaisePropertyChanged("SEQUENCE");
            }
        }
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID
        {
            get
            {
                return _PATIENT_ID;
            }
            set
            {
                this._PATIENT_ID = value;
                RaisePropertyChanged("PATIENT_ID");
            }
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO
        {
            get
            {
                return _INP_NO;
            }
            set
            {
                this._INP_NO = value;
                RaisePropertyChanged("INP_NO");
            }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME
        {
            get
            {
                return _NAME;
            }
            set
            {
                this._NAME = value;
                RaisePropertyChanged("NAME");
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX
        {
            get
            {
                return _SEX;
            }
            set
            {
                this._SEX = value;
                RaisePropertyChanged("SEX");
            }
        }
        /// <summary>
        /// 出生年月
        /// </summary>
        public Nullable<DateTime> DATE_OF_BIRTH
        {
            get
            {
                return _DATE_OF_BIRTH;
            }
            set
            {
                this._DATE_OF_BIRTH = value;
                RaisePropertyChanged("DATE_OF_BIRTH");
            }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO
        {
            get
            {
                return _BED_NO;
            }
            set
            {
                this._BED_NO = value;
                RaisePropertyChanged("BED_NO");
            }
        }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DEPT_CODE
        {
            get
            {
                return _DEPT_CODE;
            }
            set
            {
                this._DEPT_CODE = value;
                RaisePropertyChanged("DEPT_CODE");
            }
        }
        /// <summary>
        /// 术前诊断
        /// </summary>
        public string DIAG_BEFORE_OPERATION
        {
            get
            {
                return _DIAG_BEFORE_OPERATION;
            }
            set
            {
                this._DIAG_BEFORE_OPERATION = value;
                RaisePropertyChanged("DIAG_BEFORE_OPERATION");
            }
        }
        /// <summary>
        /// 拟施手术
        /// </summary>
        public ObservableCollection<string> OPERATION_NAME
        {
            get
            {
                return _OPERATION_NAME;
            }
            set
            {
                this._OPERATION_NAME = value;
                RaisePropertyChanged("OPERATION_NAME");
            }
        }

        /// <summary>
        /// 手术等级
        /// </summary>
        public string OPER_SCALE
        {
            get
            {
                return _OPER_SCALE;
            }
            set
            {
                this._OPER_SCALE = value;
                RaisePropertyChanged("OPER_SCALE");
            }
        }
        /// <summary>
        /// 手术体位
        /// </summary>
        public string OPER_POSITION
        {
            get
            {
                return _OPER_POSITION;
            }
            set
            {
                this._OPER_POSITION = value;
                RaisePropertyChanged("OPER_POSITION");
            }
        }
        /// <summary>
        /// 急诊择期
        /// </summary>
        public Nullable<Int32> EMERGENCY_IND
        {
            get
            {
                return _EMERGENCY_IND;
            }
            set
            {
                this._EMERGENCY_IND = value;
                RaisePropertyChanged("EMERGENCY_IND");
            }
        }
        /// <summary>
        /// 隔离标志
        /// </summary>
        public Nullable<Int32> ISOLATION_IND
        {
            get
            {
                return _ISOLATION_IND;
            }
            set
            {
                this._ISOLATION_IND = value;
                RaisePropertyChanged("ISOLATION_IND");
            }
        }
        /// <summary>
        /// 放射标志
        /// </summary>
        public Nullable<Int32> RADIATE_IND
        {
            get
            {
                return _RADIATE_IND;
            }
            set
            {
                this._RADIATE_IND = value;
                RaisePropertyChanged("RADIATE_IND");
            }
        }
        /// <summary>
        /// 病情
        /// </summary>
        public string PATIENT_CONDITION
        {
            get
            {
                return _PATIENT_CONDITION;
            }
            set
            {
                this._PATIENT_CONDITION = value;
                RaisePropertyChanged("PATIENT_CONDITION");
            }
        }
        /// <summary>
        /// 手术医生1
        /// </summary>
        public string SURGEON
        {
            get
            {
                return _SURGEON;
            }
            set
            {
                this._SURGEON = value;
                RaisePropertyChanged("SURGEON");
            }
        }

        public string SURGEON_NAME
        {
            get
            { return _SURGEON_NAME; }
            set
            {
                _SURGEON_NAME = value;
                RaisePropertyChanged("SURGEON_NAME");
            }
        }
        /// <summary>
        /// 手术医生2
        /// </summary>
        public string FIRST_OPER_ASSISTANT
        {
            get
            {
                return _FIRST_OPER_ASSISTANT;
            }
            set
            {
                this._FIRST_OPER_ASSISTANT = value;
                RaisePropertyChanged("FIRST_OPER_ASSISTANT");
            }
        }
        public string FIRST_OPER_ASSISTANT_NAME
        {
            get
            {
                return _FIRST_OPER_ASSISTANT_NAME;
            }
            set
            {
                this._FIRST_OPER_ASSISTANT_NAME = value;
                RaisePropertyChanged("FIRST_OPER_ASSISTANT_NAME");
            }
        }
        /// <summary>
        /// 手术医生3
        /// </summary>
        public string SECOND_OPER_ASSISTANT
        {
            get
            {
                return _SECOND_OPER_ASSISTANT;
            }
            set
            {
                this._SECOND_OPER_ASSISTANT = value;
                RaisePropertyChanged("SECOND_OPER_ASSISTANT");
            }
        }
        public string SECOND_OPER_ASSISTANT_NAME
        {
            get
            {
                return _SECOND_OPER_ASSISTANT_NAME;
            }
            set
            {
                this._SECOND_OPER_ASSISTANT_NAME = value;
                RaisePropertyChanged("SECOND_OPER_ASSISTANT_NAME");
            }
        }
        /// <summary>
        /// 灌注医生1
        /// </summary>
        public string CPB_DOCTOR
        {
            get
            {
                return _CPB_DOCTOR;
            }
            set
            {
                this._CPB_DOCTOR = value;
                RaisePropertyChanged("CPB_DOCTOR");
            }
        }
        public string CPB_DOCTOR_NAME
        {
            get
            {
                return _CPB_DOCTOR_NAME;
            }
            set
            {
                this._CPB_DOCTOR_NAME = value;
                RaisePropertyChanged("CPB_DOCTOR_NAME");
            }
        }
        /// <summary>
        /// 灌注医生2
        /// </summary>
        public string FIRST_CPB_ASSISTANT
        {
            get
            {
                return _FIRST_CPB_ASSISTANT;
            }
            set
            {
                this._FIRST_CPB_ASSISTANT = value;
                RaisePropertyChanged("FIRST_CPB_ASSISTANT");
            }
        }
        public string FIRST_CPB_ASSISTANT_NAME
        {
            get
            {
                return _FIRST_CPB_ASSISTANT_NAME;
            }
            set
            {
                this._FIRST_CPB_ASSISTANT_NAME = value;
                RaisePropertyChanged("FIRST_CPB_ASSISTANT_NAME");
            }
        }
        /// <summary>
        /// 洗手护士1
        /// </summary>
        public string FIRST_OPER_NURSE
        {
            get
            {
                return _FIRST_OPER_NURSE;
            }
            set
            {
                this._FIRST_OPER_NURSE = value;
                RaisePropertyChanged("FIRST_OPER_NURSE");
            }
        }
        public string FIRST_OPER_NURSE_NAME
        {
            get
            {
                return _FIRST_OPER_NURSE_NAME;
            }
            set
            {
                this._FIRST_OPER_NURSE_NAME = value;
                RaisePropertyChanged("FIRST_OPER_NURSE_NAME");
            }
        }
        /// <summary>
        /// 洗手护士2
        /// </summary>
        public string SECOND_OPER_NURSE
        {
            get
            {
                return _SECOND_OPER_NURSE;
            }
            set
            {
                this._SECOND_OPER_NURSE = value;
                RaisePropertyChanged("SECOND_OPER_NURSE");
            }
        }
        public string SECOND_OPER_NURSE_NAME
        {
            get
            {
                return _SECOND_OPER_NURSE_NAME;
            }
            set
            {
                this._SECOND_OPER_NURSE_NAME = value;
                RaisePropertyChanged("SECOND_OPER_NURSE_NAME");
            }
        }
        /// <summary>
        /// 巡回护士1
        /// </summary>
        public string FIRST_SUPPLY_NURSE
        {
            get
            {
                return _FIRST_SUPPLY_NURSE;
            }
            set
            {
                this._FIRST_SUPPLY_NURSE = value;
                RaisePropertyChanged("FIRST_SUPPLY_NURSE");
            }
        }
        public string FIRST_SUPPLY_NURSE_NAME
        {
            get
            {
                return _FIRST_SUPPLY_NURSE_NAME;
            }
            set
            {
                this._FIRST_SUPPLY_NURSE_NAME = value;
                RaisePropertyChanged("FIRST_SUPPLY_NURSE_NAME");
            }
        }
        /// <summary>
        /// 巡回护士2
        /// </summary>
        public string SECOND_SUPPLY_NURSE
        {
            get
            {
                return _SECOND_SUPPLY_NURSE;
            }
            set
            {
                this._SECOND_SUPPLY_NURSE = value;
                RaisePropertyChanged("SECOND_SUPPLY_NURSE");
            }
        }
        public string SECOND_SUPPLY_NURSE_NAME
        {
            get
            {
                return _SECOND_SUPPLY_NURSE_NAME;
            }
            set
            {
                this._SECOND_SUPPLY_NURSE_NAME = value;
                RaisePropertyChanged("SECOND_SUPPLY_NURSE_NAME");
            }
        }
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANES_METHOD
        {
            get
            {
                return _ANES_METHOD;
            }
            set
            {
                this._ANES_METHOD = value;
                if (_ANES_METHOD == null || _ANES_METHOD == "")
                {
                    ANAESTHESIA_TYPE = null;
                }
                else
                {
                    MED_ANESTHESIA_DICT anesDict = MED_ANESTHESIA_DICT.Where(d => d.ANAESTHESIA_NAME == _ANES_METHOD).FirstOrDefault();
                    if (anesDict != null)
                        ANAESTHESIA_TYPE = anesDict.ANAESTHESIA_TYPE;
                }
                RaisePropertyChanged("ANES_METHOD");
            }
        }

        private string _ANES_METHOD_NAME;
        public string ANES_METHOD_NAME
        {
            get
            {
                return _ANES_METHOD_NAME;
            }
            set
            {
                this._ANES_METHOD_NAME = value;
                RaisePropertyChanged("ANES_METHOD_NAME");
            }
        }

        /// <summary>
        /// 麻醉方法分类
        /// </summary>
        public string ANAESTHESIA_TYPE
        {
            get
            {
                return _ANAESTHESIA_TYPE;
            }
            set
            {
                this._ANAESTHESIA_TYPE = value;
                RaisePropertyChanged("ANAESTHESIA_TYPE");
            }
        }
        /// <summary>
        /// 麻醉医生1
        /// </summary>
        public string ANES_DOCTOR
        {
            get
            {
                return _ANES_DOCTOR;
            }
            set
            {
                this._ANES_DOCTOR = value;
                RaisePropertyChanged("ANES_DOCTOR");
            }
        }
        public string ANES_DOCTOR_NAME
        {
            get
            {
                return _ANES_DOCTOR_NAME;
            }
            set
            {
                this._ANES_DOCTOR_NAME = value;
                RaisePropertyChanged("ANES_DOCTOR_NAME");
            }
        }
        /// <summary>
        /// 麻醉医生2
        /// </summary>
        public string FIRST_ANES_ASSISTANT
        {
            get
            {
                return _FIRST_ANES_ASSISTANT;
            }
            set
            {
                this._FIRST_ANES_ASSISTANT = value;
                RaisePropertyChanged("FIRST_ANES_ASSISTANT");
            }
        }
        public string FIRST_ANES_ASSISTANT_NAME
        {
            get
            {
                return _FIRST_ANES_ASSISTANT_NAME;
            }
            set
            {
                this._FIRST_ANES_ASSISTANT_NAME = value;
                RaisePropertyChanged("FIRST_ANES_ASSISTANT_NAME");
            }
        }
        /// <summary>
        /// 麻醉医生3
        /// </summary>
        public string SECOND_ANES_ASSISTANT
        {
            get
            {
                return _SECOND_ANES_ASSISTANT;
            }
            set
            {
                this._SECOND_ANES_ASSISTANT = value;
                RaisePropertyChanged("SECOND_ANES_ASSISTANT");
            }
        }
        public string SECOND_ANES_ASSISTANT_NAME
        {
            get
            {
                return _SECOND_ANES_ASSISTANT_NAME;
            }
            set
            {
                this._SECOND_ANES_ASSISTANT_NAME = value;
                RaisePropertyChanged("SECOND_ANES_ASSISTANT_NAME");
            }
        }
        /// <summary>
        /// 麻醉医生4
        /// </summary>
        public string THIRD_ANES_ASSISTANT
        {
            get
            {
                return _THIRD_ANES_ASSISTANT;
            }
            set
            {
                this._THIRD_ANES_ASSISTANT = value;
                RaisePropertyChanged("THIRD_ANES_ASSISTANT");
            }
        }
        public string THIRD_ANES_ASSISTANT_NAME
        {
            get
            {
                return _THIRD_ANES_ASSISTANT_NAME;
            }
            set
            {
                this._THIRD_ANES_ASSISTANT_NAME = value;
                RaisePropertyChanged("THIRD_ANES_ASSISTANT_NAME");
            }
        }
        /// <summary>
        /// ASA分级
        /// </summary>
        public string ASA_GRADE
        {
            get
            {
                return _ASA_GRADE;
            }
            set
            {
                this._ASA_GRADE = value;
                RaisePropertyChanged("ASA_GRADE");
            }
        }
        /// <summary>
        /// 切口等级
        /// </summary>
        public string WOUND_TYPE
        {
            get
            {
                return _WOUND_TYPE;
            }
            set
            {
                this._WOUND_TYPE = value;
                RaisePropertyChanged("WOUND_TYPE");
            }
        }
        /// <summary>
        /// 是否24小时内重返手术室
        /// </summary>
        public string RETURN_TO_SURGERY
        {
            get
            {
                return _RETURN_TO_SURGERY;
            }
            set
            {
                this._RETURN_TO_SURGERY = value;
                RaisePropertyChanged("RETURN_TO_SURGERY");
            }
        }
        /// <summary>
        /// 术后计划患者去向
        /// </summary>
        public string PLAN_WHEREABORTS
        {
            get
            {
                return _PLAN_WHEREABORTS;
            }
            set
            {
                this._PLAN_WHEREABORTS = value;
                RaisePropertyChanged("PLAN_WHEREABORTS");
            }
        }
        public bool IsTimeFocused
        {
            get { return _isTimeFocused; }
            set
            {
                this._isTimeFocused = value;
                RaisePropertyChanged("IsTimeFocused");
            }
        }
        #endregion

        #region 其它绑定
        private bool CanContinue;                                                  // 是否可继续
        private string _searchText;                                                // 查询数据
        MED_OPERATION_MASTER _searchTextForChoose;                                 // 查询数据(选择)

        /// <summary>
        /// 搜索输入文本
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                PatientList = PatInfoService.ClientInstance.GetPatientList(_searchText, 8, ApplicationConfiguration.IsSyncByInpNo);

                RaisePropertyChanged("SearchText");
            }
        }

        /// <summary>
        /// 搜索下拉选择的那条数据
        /// </summary>
        public MED_OPERATION_MASTER SearchTextForChoose
        {
            get { return _searchTextForChoose; }
            set
            {
                _searchTextForChoose = value;
                if (value != null)
                {
                    if (ApplicationConfiguration.IsSyncByInpNo)
                    {
                        LoadDataByInpNo(value.PATIENT_ID);
                    }
                    else
                    {
                        LoadData(value.PATIENT_ID);
                    }
                }
                RaisePropertyChanged("SearchTextForChoose");


            }
        }

        /// <summary>
        /// 按钮活性
        /// </summary>
        private bool _isBtnEnabled = true;

        public bool IsBtnEnabled
        {
            get { return _isBtnEnabled; }
            set { _isBtnEnabled = value; }
        }

        #endregion

        #region 数据源
        MED_OPERATION_MASTER _masterRow;
        MED_PATS_IN_HOSPITAL _patsInHospitalRow;
        MED_PAT_MASTER_INDEX _patMasterIndexRow;
        MED_ANESTHESIA_PLAN _anesthesiaPlanRow;
        #endregion

        #region 方法
        /// <summary>
        /// 根据患者ID,载入患者信息
        /// </summary>
        /// <param name="patientID"></param>
        private void LoadData(string patientID)
        {
            try
            {
                CanContinue = true;
                List<MED_OPERATION_MASTER> masterList = AnesInfoService.ClientInstance.GetOperationMaster(patientID).OrderByDescending(c => c.VISIT_ID).ThenByDescending(c => c.OPER_ID).ToList();

                _masterRow = new MED_OPERATION_MASTER();
                _masterRow.PATIENT_ID = patientID;
                _masterRow.VISIT_ID = 1;
                _masterRow.OPER_ID = 0;

                if (masterList.Count > 0)
                {
                    _masterRow.PATIENT_ID = masterList[0].PATIENT_ID;
                    _masterRow.VISIT_ID = masterList[0].VISIT_ID;
                    _masterRow.OPER_ID = masterList[0].OPER_ID;

                    if (masterList.Where(x => x.SCHEDULED_DATE_TIME >= DateTime.Today && x.SCHEDULED_DATE_TIME < DateTime.Today.AddDays(1) && x.OPER_STATUS_CODE < 35).ToList().Count > 0)
                    {
                        ShowMessageBox(string.Format("患者{0}已经在当天的手术列表中,是否继续？", patientID), MessageBoxButton.OKCancel,
                          MessageBoxImage.Warning,
                          new Action<MessageBoxResult>((r) =>
                          {
                              if (r == MessageBoxResult.Cancel)
                              {
                                  CanContinue = false;
                                  return;
                              }
                              else
                              {
                                  CanContinue = true;

                              }
                          }));
                    }
                }

                if (CanContinue)
                {
                    // 同步患者信息
                    SyncPatientByPatientId(patientID);
                    List<MED_PATS_IN_HOSPITAL> patInHospList = AnesInfoService.ClientInstance.GetPatsInHospitalListByID(_masterRow.PATIENT_ID);
                    if (patInHospList.Count > 0)
                    {
                        _patsInHospitalRow = patInHospList.OrderByDescending(c => c.VISIT_ID).ToList().First();
                        _masterRow.VISIT_ID = _patsInHospitalRow.VISIT_ID;
                        _patsInHospitalRow.ModelStatus = ModelStatus.Modeified;
                    }
                    else
                    {
                        _patsInHospitalRow = new MED_PATS_IN_HOSPITAL();
                        _patsInHospitalRow.PATIENT_ID = patientID;
                        _patsInHospitalRow.VISIT_ID = 1;
                        _patsInHospitalRow.INP_NO = patientID;
                        _patsInHospitalRow.ModelStatus = ModelStatus.Add;
                    }
                    List<MED_PAT_MASTER_INDEX> patMasterList = AnesInfoService.ClientInstance.GetPatMasterIndex(_masterRow.PATIENT_ID);
                    if (patMasterList.Count > 0)
                    {
                        _patMasterIndexRow = patMasterList.First();
                    }
                    else
                    {
                        ShowMessageBox("找不到患者的基本信息，无法进行急诊登记。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        Messenger.Default.Send<string>("tbPatientID", EnumMessageKey.ResetFocus);
                        return;
                    }
                    _anesthesiaPlanRow = new MED_ANESTHESIA_PLAN();
                    _anesthesiaPlanRow.PATIENT_ID = patientID;
                    _anesthesiaPlanRow.VISIT_ID = _masterRow.VISIT_ID;
                    _anesthesiaPlanRow.OPER_ID = _masterRow.OPER_ID;

                    OPER_ROOM_NO = ExtendAppContext.Current.OperRoomNo;
                    // 台次 = 当天所有手术最大台次+1
                    List<MED_PAT_INFO> todayOperList = PatInfoService.ClientInstance.GetPatientInfosByDateTime(DateTime.Now, ExtendAppContext.Current.OperDeptCode, ExtendAppContext.Current.OperRoomNo);
                    if (todayOperList.Count > 0)
                    {
                        SEQUENCE = todayOperList.OrderByDescending(d => d.SEQUENCE).First().SEQUENCE + 1;
                    }
                    else SEQUENCE = 1;
                    PATIENT_ID = _masterRow.PATIENT_ID;
                    if (_patsInHospitalRow != null
                        && _patsInHospitalRow.INP_NO != null
                        && _patsInHospitalRow.INP_NO.Trim() != string.Empty)
                    {
                        INP_NO = _patsInHospitalRow.INP_NO;
                    }
                    else
                    {
                        INP_NO = patientID;
                    }
                    NAME = _patMasterIndexRow.NAME;
                    SEX = _patMasterIndexRow.SEX;
                    DATE_OF_BIRTH = _patMasterIndexRow.DATE_OF_BIRTH;
                    BED_NO = _patsInHospitalRow.BED_NO;
                    DEPT_CODE = _patsInHospitalRow.DEPT_CODE;
                    //默认急诊
                    EMERGENCY_IND = 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("急诊登记异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadDataByInpNo(string inpNo)
        {
            try
            {
                string patientID = "";
                CanContinue = true;
                List<MED_PATS_IN_HOSPITAL> patsList = AnesInfoService.ClientInstance.GetPatsInHospitalListByInpNo(inpNo);

                if (patsList.Count > 0)
                {
                    patientID = patsList[0].PATIENT_ID;

                    List<MED_OPERATION_MASTER> masterList = AnesInfoService.ClientInstance.GetOperationMaster(patientID).OrderByDescending(c => c.VISIT_ID).ThenByDescending(c => c.OPER_ID).ToList();

                    _masterRow = new MED_OPERATION_MASTER();
                    _masterRow.PATIENT_ID = patientID;
                    _masterRow.VISIT_ID = 1;
                    _masterRow.OPER_ID = 0;

                    if (masterList.Count > 0)
                    {
                        _masterRow.PATIENT_ID = masterList[0].PATIENT_ID;
                        _masterRow.VISIT_ID = masterList[0].VISIT_ID;
                        _masterRow.OPER_ID = masterList[0].OPER_ID;

                        if (masterList.Where(x => x.SCHEDULED_DATE_TIME >= DateTime.Today && x.SCHEDULED_DATE_TIME < DateTime.Today.AddDays(1) && x.OPER_STATUS_CODE < 35).ToList().Count > 0)
                        {
                            ShowMessageBox(string.Format("患者{0}已经在当天的手术列表中,是否继续？", patientID), MessageBoxButton.OKCancel,
                              MessageBoxImage.Warning,
                              new Action<MessageBoxResult>((r) =>
                              {
                                  if (r == MessageBoxResult.Cancel)
                                  {
                                      CanContinue = false;
                                      return;
                                  }
                                  else
                                  {
                                      CanContinue = true;

                                  }
                              }));
                        }
                    }
                }
                else
                {
                    patientID = inpNo;
                    _masterRow = new MED_OPERATION_MASTER();
                    _masterRow.PATIENT_ID = patientID;
                    _masterRow.VISIT_ID = 1;
                    _masterRow.OPER_ID = 0;
                }

                if (CanContinue)
                {
                    //同步患者信息
                    SyncPatientByInpNo(inpNo);
                    List<MED_PATS_IN_HOSPITAL> patInHospList = AnesInfoService.ClientInstance.GetPatsInHospitalListByInpNo(inpNo);
                    if (patInHospList.Count > 0)
                    {
                        _patsInHospitalRow = patInHospList.OrderByDescending(c => c.VISIT_ID).ToList().First();
                        _masterRow.PATIENT_ID = _patsInHospitalRow.PATIENT_ID;
                        _masterRow.VISIT_ID = _patsInHospitalRow.VISIT_ID;
                        _patsInHospitalRow.ModelStatus = ModelStatus.Modeified;
                    }
                    else
                    {
                        _patsInHospitalRow = new MED_PATS_IN_HOSPITAL();
                        _patsInHospitalRow.PATIENT_ID = inpNo;
                        _patsInHospitalRow.VISIT_ID = 1;
                        _patsInHospitalRow.INP_NO = inpNo;
                        _patsInHospitalRow.ModelStatus = ModelStatus.Add;
                    }
                    List<MED_PAT_MASTER_INDEX> patMasterList = AnesInfoService.ClientInstance.GetPatMasterIndex(_patsInHospitalRow.PATIENT_ID);
                    if (patMasterList.Count > 0)
                    {
                        _patMasterIndexRow = patMasterList.First();
                    }
                    else
                    {
                        ShowMessageBox("找不到患者的基本信息，无法进行急诊登记。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        Messenger.Default.Send<string>("tbPatientID", EnumMessageKey.ResetFocus);
                        return;
                    }
                    _anesthesiaPlanRow = new MED_ANESTHESIA_PLAN();
                    _anesthesiaPlanRow.PATIENT_ID = patientID;
                    _anesthesiaPlanRow.VISIT_ID = _masterRow.VISIT_ID;
                    _anesthesiaPlanRow.OPER_ID = _masterRow.OPER_ID;

                    OPER_ROOM_NO = ExtendAppContext.Current.OperRoomNo;
                    // 台次 = 当天所有手术最大台次+1
                    List<MED_PAT_INFO> todayOperList = PatInfoService.ClientInstance.GetPatientInfosByDateTime(DateTime.Now, ExtendAppContext.Current.OperDeptCode, ExtendAppContext.Current.OperRoomNo);
                    if (todayOperList.Count > 0)
                    {
                        SEQUENCE = todayOperList.OrderByDescending(d => d.SEQUENCE).First().SEQUENCE + 1;
                    }
                    else SEQUENCE = 1;
                    PATIENT_ID = _masterRow.PATIENT_ID;
                    if (_patsInHospitalRow != null
                        && _patsInHospitalRow.INP_NO != null
                        && _patsInHospitalRow.INP_NO.Trim() != string.Empty)
                    {
                        INP_NO = _patsInHospitalRow.INP_NO;
                    }
                    else
                    {
                        INP_NO = patientID;
                    }
                    NAME = _patMasterIndexRow.NAME;
                    SEX = _patMasterIndexRow.SEX;
                    DATE_OF_BIRTH = _patMasterIndexRow.DATE_OF_BIRTH;
                    BED_NO = _patsInHospitalRow.BED_NO;
                    DEPT_CODE = _patsInHospitalRow.DEPT_CODE;
                    //默认急诊
                    EMERGENCY_IND = 1;

                }
            }
            catch (Exception ex)
            {
                Logger.Error("急诊登记异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// 保存患者信息
        /// </summary>
        protected override SaveResult SaveData()
        {
            bool result = true;

            if (_masterRow != null && _anesthesiaPlanRow != null)
            {
                // 手术记录数加1
                _masterRow.OPER_ID = _masterRow.OPER_ID + 1;
                _masterRow.OPER_ROOM = ExtendAppContext.Current.OperDeptCode;
                _masterRow.OPER_ROOM_NO = OPER_ROOM_NO;
                _masterRow.SEQUENCE = SEQUENCE;
                _masterRow.BED_NO = BED_NO;
                _masterRow.DEPT_CODE = DEPT_CODE;
                _masterRow.DIAG_BEFORE_OPERATION = DIAG_BEFORE_OPERATION;
                string operName = string.Empty;
                foreach (string operDict in OPERATION_NAME)
                {
                    operName += operDict + "+";
                }
                if (operName != "" && operName.Length > 0)
                {
                    operName = operName.Substring(0, operName.Length - 1);
                }
                _masterRow.OPERATION_NAME = operName;
                _masterRow.OPER_SCALE = OPER_SCALE;
                _masterRow.OPER_POSITION = OPER_POSITION;
                _masterRow.EMERGENCY_IND = EMERGENCY_IND;
                _masterRow.ISOLATION_IND = ISOLATION_IND;
                _masterRow.RADIATE_IND = RADIATE_IND;
                _masterRow.PATIENT_CONDITION = PATIENT_CONDITION;

                if (ANES_METHOD != ANES_METHOD_NAME)
                {
                    ANES_METHOD = ANES_METHOD_NAME;
                }
                _masterRow.ANES_METHOD = ANES_METHOD;
                _masterRow.ANAESTHESIA_TYPE = ANAESTHESIA_TYPE;

                #region 人员保存特殊处理
                if (SURGEON == null && SURGEON_NAME != null)
                    SURGEON = SURGEON_NAME;
                _masterRow.SURGEON = SURGEON;
                if (FIRST_OPER_ASSISTANT == null && FIRST_OPER_ASSISTANT_NAME != null)
                    FIRST_OPER_ASSISTANT = FIRST_OPER_ASSISTANT_NAME;
                _masterRow.FIRST_OPER_ASSISTANT = FIRST_OPER_ASSISTANT;
                if (SECOND_OPER_ASSISTANT == null && SECOND_OPER_ASSISTANT_NAME != null)
                    SECOND_OPER_ASSISTANT = SECOND_OPER_ASSISTANT_NAME;
                _masterRow.SECOND_OPER_ASSISTANT = SECOND_OPER_ASSISTANT;
                if (CPB_DOCTOR == null && CPB_DOCTOR_NAME != null)
                    CPB_DOCTOR = CPB_DOCTOR_NAME;
                _masterRow.CPB_DOCTOR = CPB_DOCTOR;
                if (FIRST_CPB_ASSISTANT == null && FIRST_CPB_ASSISTANT_NAME != null)
                    FIRST_CPB_ASSISTANT = FIRST_CPB_ASSISTANT_NAME;
                _masterRow.FIRST_CPB_ASSISTANT = FIRST_CPB_ASSISTANT;
                if (FIRST_OPER_NURSE == null && FIRST_OPER_NURSE_NAME != null)
                    FIRST_OPER_NURSE = FIRST_OPER_NURSE_NAME;
                _masterRow.FIRST_OPER_NURSE = FIRST_OPER_NURSE;
                if (SECOND_OPER_NURSE == null && SECOND_OPER_NURSE_NAME != null)
                    SECOND_OPER_NURSE = SECOND_OPER_NURSE_NAME;
                _masterRow.SECOND_OPER_NURSE = SECOND_OPER_NURSE;
                if (FIRST_SUPPLY_NURSE == null && FIRST_SUPPLY_NURSE_NAME != null)
                    FIRST_SUPPLY_NURSE = FIRST_SUPPLY_NURSE_NAME;
                _masterRow.FIRST_SUPPLY_NURSE = FIRST_SUPPLY_NURSE;
                if (SECOND_SUPPLY_NURSE == null && SECOND_SUPPLY_NURSE_NAME != null)
                    SECOND_SUPPLY_NURSE = SECOND_SUPPLY_NURSE_NAME;
                _masterRow.SECOND_SUPPLY_NURSE = SECOND_SUPPLY_NURSE;
                if (ANES_DOCTOR == null && ANES_DOCTOR_NAME != null)
                    ANES_DOCTOR = ANES_DOCTOR_NAME;
                _masterRow.ANES_DOCTOR = ANES_DOCTOR;
                if (FIRST_ANES_ASSISTANT == null && FIRST_ANES_ASSISTANT_NAME != null)
                    FIRST_ANES_ASSISTANT = FIRST_ANES_ASSISTANT_NAME;
                _masterRow.FIRST_ANES_ASSISTANT = FIRST_ANES_ASSISTANT;
                if (SECOND_ANES_ASSISTANT == null && SECOND_ANES_ASSISTANT_NAME != null)
                    SECOND_ANES_ASSISTANT = SECOND_ANES_ASSISTANT_NAME;
                _masterRow.SECOND_ANES_ASSISTANT = SECOND_ANES_ASSISTANT;
                if (THIRD_ANES_ASSISTANT == null && THIRD_ANES_ASSISTANT_NAME != null)
                    THIRD_ANES_ASSISTANT = THIRD_ANES_ASSISTANT_NAME;
                _masterRow.THIRD_ANES_ASSISTANT = THIRD_ANES_ASSISTANT;
                #endregion

                _masterRow.ASA_GRADE = ASA_GRADE;
                _masterRow.WOUND_TYPE = WOUND_TYPE;
                _masterRow.SCHEDULED_DATE_TIME = SCHEDULED_DATE_TIME;
                _masterRow.OPER_STATUS_CODE = (int)OperationStatus.IsReady;
                _masterRow.MINIMAL_INVASIVE = this.MINIMAL_INVASIVE;

                // 手术记录数加1
                _anesthesiaPlanRow.OPER_ID = _masterRow.OPER_ID;
                _anesthesiaPlanRow.OPERATION_NAME = operName;
                _anesthesiaPlanRow.RETURN_TO_SURGERY = RETURN_TO_SURGERY;
                _anesthesiaPlanRow.PLAN_WHEREABORTS = PLAN_WHEREABORTS;

                List<MED_OPERATION_NAME> listOperationName = new List<MED_OPERATION_NAME>();
                int operNo = 1;
                foreach (var item in OPERATION_NAME)
                {
                    MED_OPERATION_NAME operationName = new MED_OPERATION_NAME();
                    operationName.PATIENT_ID = _masterRow.PATIENT_ID;
                    operationName.VISIT_ID = _masterRow.VISIT_ID;
                    operationName.OPER_ID = _masterRow.OPER_ID;
                    operationName.OPER_NO = operNo++;
                    operationName.OPER_NAME = item;
                    listOperationName.Add(operationName);
                }

                result = CommonService.ClientInstance.UpdateByTransaction(TransactionParamsters.Create().Append(_masterRow).
                                                                                                         Append(_anesthesiaPlanRow).
                                                                                                         Append(listOperationName).
                                                                                                         Append(_patsInHospitalRow).
                                                                                                         ToString());
            }
            if (result)
                saveResult = SaveResult.Success;

            return saveResult;
        }

        /// <summary>
        /// 保存患者信息前检查
        /// </summary>
        protected override bool CheckData()
        {
            bool result = true;
            if (PATIENT_ID == null)
            {
                ShowMessageBox("请输入患者ID。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            else if (INP_NO == null)
            {
                ShowMessageBox("请输入患者住院号。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            else if (OPER_ROOM_NO == null)
            {
                ShowMessageBox("请输入患者手术间号。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            else if (SCHEDULED_DATE_TIME == DateTime.MinValue || SCHEDULED_DATE_TIME == null)
            {
                ShowMessageBox("手术日期为必填项。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            else if (DEPT_CODE == null)
            {
                ShowMessageBox("患者所在科室为必填项。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }

            return result;
        }


        /// <summary>
        /// 重置
        /// </summary>
        private void ResetData()
        {
            try
            {
                _masterRow = new MED_OPERATION_MASTER();
                _patsInHospitalRow = new MED_PATS_IN_HOSPITAL();
                _patMasterIndexRow = new MED_PAT_MASTER_INDEX();
                _anesthesiaPlanRow = new MED_ANESTHESIA_PLAN();
                OPER_ROOM_NO = _masterRow.OPER_ROOM_NO;
                SEQUENCE = _masterRow.SEQUENCE;
                PATIENT_ID = _masterRow.PATIENT_ID;
                INP_NO = _patsInHospitalRow.INP_NO;
                NAME = _patMasterIndexRow.NAME;
                SEX = _patMasterIndexRow.SEX;
                DATE_OF_BIRTH = _patMasterIndexRow.DATE_OF_BIRTH;
                BED_NO = _masterRow.BED_NO;
                DEPT_CODE = _masterRow.DEPT_CODE;
                DIAG_BEFORE_OPERATION = _masterRow.DIAG_BEFORE_OPERATION;
                OPERATION_NAME = new ObservableCollection<string>();
                OPER_SCALE = _masterRow.OPER_SCALE;
                OPER_POSITION = _masterRow.OPER_POSITION;
                EMERGENCY_IND = _masterRow.EMERGENCY_IND;
                ISOLATION_IND = _masterRow.ISOLATION_IND;
                RADIATE_IND = _masterRow.RADIATE_IND;
                PATIENT_CONDITION = _masterRow.PATIENT_CONDITION;
                SURGEON = _masterRow.SURGEON;
                FIRST_OPER_ASSISTANT = _masterRow.FIRST_OPER_ASSISTANT;
                SECOND_OPER_ASSISTANT = _masterRow.SECOND_OPER_ASSISTANT;
                CPB_DOCTOR = _masterRow.CPB_DOCTOR;
                FIRST_CPB_ASSISTANT = _masterRow.FIRST_CPB_ASSISTANT;
                FIRST_OPER_NURSE = _masterRow.FIRST_OPER_NURSE;
                SECOND_OPER_NURSE = _masterRow.SECOND_OPER_NURSE;
                FIRST_SUPPLY_NURSE = _masterRow.FIRST_SUPPLY_NURSE;
                SECOND_SUPPLY_NURSE = _masterRow.SECOND_SUPPLY_NURSE;
                ANES_METHOD = _masterRow.ANES_METHOD;
                ANAESTHESIA_TYPE = _masterRow.ANAESTHESIA_TYPE;
                ANES_DOCTOR = _masterRow.ANES_DOCTOR;
                FIRST_ANES_ASSISTANT = _masterRow.FIRST_ANES_ASSISTANT;
                SECOND_ANES_ASSISTANT = _masterRow.SECOND_ANES_ASSISTANT;
                THIRD_ANES_ASSISTANT = _masterRow.THIRD_ANES_ASSISTANT;
                ASA_GRADE = _masterRow.ASA_GRADE;
                WOUND_TYPE = _masterRow.WOUND_TYPE;
                RETURN_TO_SURGERY = _anesthesiaPlanRow.RETURN_TO_SURGERY;
                PLAN_WHEREABORTS = _anesthesiaPlanRow.PLAN_WHEREABORTS;
                this.MINIMAL_INVASIVE = _masterRow.MINIMAL_INVASIVE;
            }
            catch (Exception ex)
            {
                Logger.Error("急诊登记异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 同步患者信息
        /// </summary>
        /// <param name="patientID"></param>
        private void SyncPatientByPatientId(string patientID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                if (ApplicationConfiguration.IsSync)
                {
                    string ret = "";
                    ret = SyncInfoService.ClientInstance.SyncPatientInfoAndInHospital(patientID);
                    ret += SyncInfoService.ClientInstance.SyncScheduleInfo(patientID, DateTime.Now);
                    if (!string.IsNullOrEmpty(ret))
                    {
                        ShowMessageBox("患者信息同步失败。", MessageBoxButton.OK, MessageBoxImage.Error);
                        Logger.Error("患者信息同步失败：" + ret);
                    }
                }
            }
        }

        private void SyncPatientByInpNo(string inpNo)
        {
            if (!string.IsNullOrEmpty(inpNo))
            {
                if (ApplicationConfiguration.IsSync)
                {
                    string ret = "";
                    ret = SyncInfoService.ClientInstance.SyncPatientInfoAndInHospitalByInpNo(inpNo);
                    if (!string.IsNullOrEmpty(ret))
                    {
                        ShowMessageBox("患者信息同步失败。", MessageBoxButton.OK, MessageBoxImage.Error);
                        Logger.Error("患者信息同步失败：" + ret);
                    }
                }
            }
        }
        #endregion

        #region 命令
        /// <summary>
        /// 搜索
        /// </summary>
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    if (ApplicationConfiguration.IsSyncByInpNo)
                    {
                        LoadDataByInpNo(key);
                    }
                    else
                    {
                        LoadData(key);
                    }
                    _isTimeFocused = true;
                });
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    PublicKeyBoardMessage(KeyCode.AppCode.Save);
                });
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        public ICommand ResetCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    ResetData();
                });
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        /// <param name="e"></param>
        public override void OnPreviewViewUnLoaded(System.ComponentModel.CancelEventArgs e)
        {
            // 清除全局缓存
            ExtendAppContext.Current.CurrentDocName = string.Empty;
            ExtendAppContext.Current.CurntOpenForm = null;

            //急诊登记关闭后刷新今日列表
            if (saveResult == SaveResult.Success)
            {
                List<object> list = new List<object>();
                list.Add(_masterRow);
                list.Add("UnFinishWorkList");//未完成
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);
                Messenger.Default.Send<object>(list, EnumMessageKey.SetWorkListSelectItem);
            }
        }
        #endregion
    }
}
