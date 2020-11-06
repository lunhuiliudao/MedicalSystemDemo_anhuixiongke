using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Framework.Utilities;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.InHospitalRegisterViewModel
{
    public class InHospitalRegisterViewModel : BaseViewModel
    {
        public enum ShowType
        {
            PatInfoCheck = 0,
            MonitorCheck = 1,
            InRoomTimeCheck = 2
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public InHospitalRegisterViewModel()
        {
            // 载入字典数据
            LoadDictData();
        }

        /// <summary>
        /// 分隔符
        /// </summary>
        public const string CommonSplit = "+";

        #region 界面绑定相关字段
        #region 界面控件值绑定
        private string _OPER_ROOM_NO;                                              // 手术间号
        private Nullable<Int32> _SEQUENCE;                                         // 台次
        private string _PATIENT_ID;                                                // 患者ID
        private string _INP_NO;                                                    // 住院号
        private string _NAME;                                                      // 姓名
        private string _SEX;                                                       // 性别
        private Nullable<DateTime> _DATE_OF_BIRTH;                                 // 出生日期
        private string _AGE;                                                          // 年龄
        private string _BED_NO;                                                    // 床号
        private string _DEPT_CODE;                                                 // 科室代码
        private string _DEPT_NAME;                                                 // 科室名称
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
        private ObservableCollection<string> _ANES_METHOD = new ObservableCollection<string>();            // 麻醉方法（多选）
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
        private Visibility _PATINFOCHECK;                                          // 病人信息界面显示FLAG
        private Visibility _MONITORINFOCHECK;                                      // 仪器选择界面显示FALG
        private Visibility _INROOMTIMECHECK;                                           // 入室时间界面显示FLAG
        private bool _PATINFOCHECKBOOL;
        private bool _MONITORINFOCHECKBOOL;
        private bool _INROOMTIMECHECKBOOL;
        private Nullable<DateTime> _IN_DATE_TIME;


        private ShowType currentStep = ShowType.PatInfoCheck;
        private string _leftBtnText = "重 置";
        private string _rightBtnText = "下一步";

        public string leftBtnText
        {
            get { return _leftBtnText; }
            set
            {
                this._leftBtnText = value;
                RaisePropertyChanged("leftBtnText");
            }
        }

        public string rightBtnText
        {
            get { return _rightBtnText; }
            set
            {
                this._rightBtnText = value;
                RaisePropertyChanged("rightBtnText");
            }
        }
        /// <summary>
        /// 入手术室
        /// </summary>
        public Nullable<DateTime> IN_DATE_TIME
        {
            get
            {
                return _IN_DATE_TIME;
            }
            set
            {
                this._IN_DATE_TIME = value;
                RaisePropertyChanged("IN_DATE_TIME");
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
                //AGE = DateTime.Now.Year - DATE_OF_BIRTH.Value.Year;
                return _DATE_OF_BIRTH;
            }
            set
            {
                this._DATE_OF_BIRTH = value;
                RaisePropertyChanged("DATE_OF_BIRTH");
            }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string AGE
        {
            get { return _AGE; }
            set
            {
                _AGE = value;
                RaisePropertyChanged("AGE");
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
        /// 科室名称
        /// </summary>
        public string DEPT_NAME
        {
            get
            {
                return _DEPT_NAME;
            }
            set
            {
                this._DEPT_NAME = value;
                RaisePropertyChanged("DEPT_NAME");
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
        /// 麻醉方法(多选)
        /// </summary>
        public ObservableCollection<string> ANES_METHOD
        {
            get
            {
                return _ANES_METHOD;
            }
            set
            {
                this._ANES_METHOD = value;
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

        public Visibility PATINFOCHECK
        {
            get { return _PATINFOCHECK; }
            set
            {
                _PATINFOCHECK = value;

                RaisePropertyChanged("PATINFOCHECK");


            }
        }

        public Visibility MONITORINFOCHECK
        {
            get { return _MONITORINFOCHECK; }
            set
            {
                _MONITORINFOCHECK = value;

                RaisePropertyChanged("MONITORINFOCHECK");


            }
        }

        public Visibility INROOMTIMECHECK
        {
            get { return _INROOMTIMECHECK; }
            set
            {
                _INROOMTIMECHECK = value;

                RaisePropertyChanged("INROOMTIMECHECK");
            }
        }

        public bool PATINFOCHECKBOOL
        {
            get { return _PATINFOCHECKBOOL; }
            set
            {
                _PATINFOCHECKBOOL = value;

                RaisePropertyChanged("PATINFOCHECKBOOL");


            }
        }

        public bool MONITORINFOCHECKBOOL
        {
            get { return _MONITORINFOCHECKBOOL; }
            set
            {
                _MONITORINFOCHECKBOOL = value;

                RaisePropertyChanged("MONITORINFOCHECKBOOL");


            }
        }

        public bool INROOMTIMECHECKBOOL
        {
            get { return _INROOMTIMECHECKBOOL; }
            set
            {
                _INROOMTIMECHECKBOOL = value;

                RaisePropertyChanged("INROOMTIMECHECKBOOL");


            }
        }
        #endregion

        #endregion

        #region 数据源
        MED_OPERATION_MASTER _masterRow;
        MED_PATS_IN_HOSPITAL _patsInHospitalRow;
        MED_PAT_MASTER_INDEX _patMasterIndexRow;
        MED_ANESTHESIA_PLAN _anesthesiaPlanRow;
        #endregion

        #region 方法

        /// <summary>
        /// 保存返回值
        /// </summary>
        SaveResult saveResult = SaveResult.Fail;

        /// <summary>
        /// 载入数据
        /// </summary>
        public override void LoadData()
        {
            _masterRow = AnesInfoService.ClientInstance.GetOperationMaster(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                           ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                                           ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
            if (_masterRow != null && !string.IsNullOrEmpty(_masterRow.PATIENT_ID))
            {
                _patsInHospitalRow = AnesInfoService.ClientInstance.GetPatsInHospitalListByID(_masterRow.PATIENT_ID).OrderByDescending(c => c.VISIT_ID).ToList().First();
                _patMasterIndexRow = AnesInfoService.ClientInstance.GetPatMasterIndex(_masterRow.PATIENT_ID).First();
                try
                {
                    this._anesthesiaPlanRow = AnesInfoService.ClientInstance.GetAnesthesiaPlan(_masterRow.PATIENT_ID, _masterRow.VISIT_ID, _masterRow.OPER_ID).FirstOrDefault();
                    if (string.IsNullOrEmpty(this._anesthesiaPlanRow.OPERATION_NAME))
                    {
                        this._anesthesiaPlanRow.OPERATION_NAME = _masterRow.OPERATION_NAME;
                    }

                    if (string.IsNullOrEmpty(this._anesthesiaPlanRow.ANESTHESIA_METHOD))
                    {
                        this._anesthesiaPlanRow.ANESTHESIA_METHOD = _masterRow.ANES_METHOD;
                    }
                }
                catch
                {
                    this._anesthesiaPlanRow = new MED_ANESTHESIA_PLAN();
                    this._anesthesiaPlanRow.PATIENT_ID = _masterRow.PATIENT_ID;
                    this._anesthesiaPlanRow.VISIT_ID = _masterRow.VISIT_ID;
                    this._anesthesiaPlanRow.OPER_ID = _masterRow.OPER_ID;
                    this._anesthesiaPlanRow.OPERATION_NAME = _masterRow.OPERATION_NAME;
                    this._anesthesiaPlanRow.ANESTHESIA_METHOD = _masterRow.ANES_METHOD;
                    this._anesthesiaPlanRow.ModelStatus = ModelStatus.Add;
                }

                List<MED_PAT_INFO> todayOperList = PatInfoService.ClientInstance.GetPatientInfosByDateTime(DateTime.Now, ExtendAppContext.Current.OperDeptCode, ExtendAppContext.Current.OperRoomNo);
                if (todayOperList.Count > 0)
                {
                    todayOperList = todayOperList.Where(x => x.OPER_STATUS_CODE >= 35).ToList();
                    if (todayOperList.Count > 0)
                    {
                        SEQUENCE = todayOperList.Count + 1;
                    }
                    else
                    {
                        SEQUENCE = 1;
                    }
                }
                else SEQUENCE = 1;

                OPER_ROOM_NO = _masterRow.OPER_ROOM_NO;
                //SEQUENCE = _masterRow.SEQUENCE;
                PATIENT_ID = _masterRow.PATIENT_ID;
                INP_NO = _patsInHospitalRow.INP_NO;
                NAME = _patMasterIndexRow.NAME;
                SEX = _patMasterIndexRow.SEX;
                DATE_OF_BIRTH = _patMasterIndexRow.DATE_OF_BIRTH;
                BED_NO = _masterRow.BED_NO;
                DEPT_CODE = _masterRow.DEPT_CODE;
                DIAG_BEFORE_OPERATION = _masterRow.DIAG_BEFORE_OPERATION;
                // 手术名称（新分隔符）
                if (!string.IsNullOrEmpty(_masterRow.OPERATION_NAME))
                {
                    string[] operNameArray = _masterRow.OPERATION_NAME.Split(new string[] { CommonSplit },
                                                                                      StringSplitOptions.RemoveEmptyEntries);
                    OPERATION_NAME = new ObservableCollection<string>(operNameArray);
                }
                else if (OPERATION_NAME != null)
                {
                    OPERATION_NAME.Clear();
                }
                else
                {
                    OPERATION_NAME = new ObservableCollection<string>();
                }
                OPER_SCALE = _masterRow.OPER_SCALE;
                OPER_POSITION = _masterRow.OPER_POSITION;
                EMERGENCY_IND = _masterRow.EMERGENCY_IND;
                ISOLATION_IND = _masterRow.ISOLATION_IND;
                RADIATE_IND = _masterRow.RADIATE_IND;
                PATIENT_CONDITION = _masterRow.PATIENT_CONDITION;

                #region 人员特殊处理
                SURGEON = _masterRow.SURGEON;
                if (!ExistsUser(_masterRow.SURGEON))
                {
                    SURGEON_NAME = _masterRow.SURGEON;
                }
                FIRST_OPER_ASSISTANT = _masterRow.FIRST_OPER_ASSISTANT;
                if (!ExistsUser(_masterRow.FIRST_OPER_ASSISTANT))
                {
                    FIRST_OPER_ASSISTANT_NAME = _masterRow.FIRST_OPER_ASSISTANT;
                }
                SECOND_OPER_ASSISTANT = _masterRow.SECOND_OPER_ASSISTANT;
                if (!ExistsUser(_masterRow.SECOND_OPER_ASSISTANT))
                {
                    SECOND_OPER_ASSISTANT_NAME = _masterRow.SECOND_OPER_ASSISTANT;
                }
                CPB_DOCTOR = _masterRow.CPB_DOCTOR;
                if (!ExistsUser(_masterRow.CPB_DOCTOR))
                {
                    CPB_DOCTOR_NAME = _masterRow.CPB_DOCTOR;
                }
                FIRST_CPB_ASSISTANT = _masterRow.FIRST_CPB_ASSISTANT;
                if (!ExistsUser(_masterRow.FIRST_CPB_ASSISTANT))
                {
                    FIRST_CPB_ASSISTANT_NAME = _masterRow.FIRST_CPB_ASSISTANT;
                }
                FIRST_OPER_NURSE = _masterRow.FIRST_OPER_NURSE;
                if (!ExistsNurse(_masterRow.FIRST_OPER_NURSE))
                {
                    FIRST_OPER_NURSE_NAME = _masterRow.FIRST_OPER_NURSE;
                }
                SECOND_OPER_NURSE = _masterRow.SECOND_OPER_NURSE;
                if (!ExistsNurse(_masterRow.SECOND_OPER_NURSE))
                {
                    SECOND_OPER_NURSE_NAME = _masterRow.SECOND_OPER_NURSE;
                }
                FIRST_SUPPLY_NURSE = _masterRow.FIRST_SUPPLY_NURSE;
                if (!ExistsNurse(_masterRow.FIRST_SUPPLY_NURSE))
                {
                    FIRST_SUPPLY_NURSE_NAME = _masterRow.FIRST_SUPPLY_NURSE;
                }
                SECOND_SUPPLY_NURSE = _masterRow.SECOND_SUPPLY_NURSE;
                if (!ExistsNurse(_masterRow.SECOND_SUPPLY_NURSE))
                {
                    SECOND_SUPPLY_NURSE_NAME = _masterRow.SECOND_SUPPLY_NURSE;
                }
                ANES_DOCTOR = _masterRow.ANES_DOCTOR;
                if (!ExistsDoctor(_masterRow.ANES_DOCTOR))
                {
                    ANES_DOCTOR_NAME = _masterRow.ANES_DOCTOR;
                }
                FIRST_ANES_ASSISTANT = _masterRow.FIRST_ANES_ASSISTANT;
                if (!ExistsDoctor(_masterRow.FIRST_ANES_ASSISTANT))
                {
                    FIRST_ANES_ASSISTANT_NAME = _masterRow.FIRST_ANES_ASSISTANT;
                }
                SECOND_ANES_ASSISTANT = _masterRow.SECOND_ANES_ASSISTANT;
                if (!ExistsDoctor(_masterRow.SECOND_ANES_ASSISTANT))
                {
                    SECOND_ANES_ASSISTANT_NAME = _masterRow.SECOND_ANES_ASSISTANT;
                }
                THIRD_ANES_ASSISTANT = _masterRow.THIRD_ANES_ASSISTANT;
                if (!ExistsDoctor(_masterRow.THIRD_ANES_ASSISTANT))
                {
                    THIRD_ANES_ASSISTANT_NAME = _masterRow.THIRD_ANES_ASSISTANT;
                }
                #endregion
                // 麻醉方法（多选）
                if (!string.IsNullOrEmpty(_masterRow.ANES_METHOD))
                {
                    string[] anesMethod = _masterRow.ANES_METHOD.Split(new string[] { CommonSplit },
                                                                       StringSplitOptions.RemoveEmptyEntries);
                    ANES_METHOD = new ObservableCollection<string>(anesMethod);
                }
                else if (ANES_METHOD != null)
                {
                    ANES_METHOD.Clear();
                }
                else
                {
                    ANES_METHOD = new ObservableCollection<string>();
                }

                ANAESTHESIA_TYPE = _masterRow.ANAESTHESIA_TYPE;
                ASA_GRADE = _masterRow.ASA_GRADE;
                WOUND_TYPE = _masterRow.WOUND_TYPE;
                RETURN_TO_SURGERY = _anesthesiaPlanRow.RETURN_TO_SURGERY;
                PLAN_WHEREABORTS = _anesthesiaPlanRow.PLAN_WHEREABORTS;
                AGE = DateDiff.CalAge((DateTime)_patMasterIndexRow.DATE_OF_BIRTH, _masterRow.SCHEDULED_DATE_TIME.Value);
                PATINFOCHECK = Visibility.Visible;
                MONITORINFOCHECK = Visibility.Collapsed;
                INROOMTIMECHECK = Visibility.Collapsed;
                PATINFOCHECKBOOL = true;
                MONITORINFOCHECKBOOL = false;
                INROOMTIMECHECKBOOL = false;
                IN_DATE_TIME = _masterRow.IN_DATE_TIME == null ? DateTime.Now : (DateTime)_masterRow.IN_DATE_TIME;

                // 科室名称
                DEPT_NAME = _masterRow.DEPT_NAME;
            }
        }

        /// <summary>
        /// 检查数据有效
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            bool result = true;

            if (currentStep != ShowType.InRoomTimeCheck)
            {
                ShowMessageBox("请下一步后进行保存操作。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            return result;
        }


        public override void KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.PageDown)//下一页
            {
                if (currentStep == ShowType.PatInfoCheck)
                {
                    FirstStep();
                }
                //第二步，仪器配置
                else if (currentStep == ShowType.MonitorCheck)
                {
                    SecondStep();
                }
            }
            else if (e.Key == Key.PageUp)//上一页
            {
                ResetDataOrPre();
            }

        }

        /// <summary>
        /// 保存患者信息
        /// </summary>
        protected override SaveResult SaveData()
        {
            //第三步，入室时间确认
            if (currentStep == ShowType.InRoomTimeCheck)
            {
                ThirdStep();
                saveResult = SaveResult.CancelMessageBox;
                this.Result = true;
            }
            return saveResult;
        }

        private void FirstStep()
        {
            if (OPER_ROOM_NO == null)
            {
                ShowMessageBox("请输入患者手术间号。", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (DEPT_CODE == null)
            {
                ShowMessageBox("患者所在科室为必填项。", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (_masterRow != null && _anesthesiaPlanRow != null)
            {
                _masterRow.OPER_ID = _masterRow.OPER_ID;

                _masterRow.OPER_ROOM_NO = OPER_ROOM_NO;
                _masterRow.SEQUENCE = SEQUENCE;
                _masterRow.BED_NO = BED_NO;
                _masterRow.DEPT_CODE = DEPT_CODE;
                _masterRow.DIAG_BEFORE_OPERATION = DIAG_BEFORE_OPERATION;
                // 手术名称新的分隔符
                string operName = string.Empty;
                if (OPERATION_NAME != null)
                {
                    foreach (string operDict in OPERATION_NAME)
                    {
                        operName += operDict + CommonSplit;
                    }
                }
                if (operName.Length > 0)
                    operName = operName.Substring(0, operName.Length - CommonSplit.Length);

                _masterRow.OPERATION_NAME = operName;
                _masterRow.OPER_SCALE = OPER_SCALE;
                _masterRow.OPER_POSITION = OPER_POSITION;
                _masterRow.EMERGENCY_IND = EMERGENCY_IND;
                _masterRow.ISOLATION_IND = ISOLATION_IND;
                _masterRow.RADIATE_IND = RADIATE_IND;
                _masterRow.PATIENT_CONDITION = PATIENT_CONDITION;

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

                // 麻醉方法多选
                string anesMethod = string.Empty;
                if (ANES_METHOD != null)
                {
                    foreach (string item in ANES_METHOD)
                    {
                        anesMethod += item + CommonSplit;
                    }
                }
                if (anesMethod.Length > 0)
                {
                    anesMethod = anesMethod.Substring(0, anesMethod.Length - CommonSplit.Length);
                }
                _masterRow.ANES_METHOD = anesMethod;

                _masterRow.ANAESTHESIA_TYPE = ANAESTHESIA_TYPE;
                _masterRow.ASA_GRADE = ASA_GRADE;
                _masterRow.WOUND_TYPE = WOUND_TYPE;
                _anesthesiaPlanRow.RETURN_TO_SURGERY = RETURN_TO_SURGERY;
                _anesthesiaPlanRow.PLAN_WHEREABORTS = PLAN_WHEREABORTS;
                //第一步，患者信息确认
                if (_PATINFOCHECKBOOL == true)
                {
                    PATINFOCHECK = Visibility.Collapsed;
                    MONITORINFOCHECK = Visibility.Visible;
                    INROOMTIMECHECK = Visibility.Collapsed;
                    PATINFOCHECKBOOL = true;
                    MONITORINFOCHECKBOOL = true;
                    INROOMTIMECHECKBOOL = false;
                    leftBtnText = "上一步";
                    rightBtnText = "下一步";
                    currentStep = ShowType.MonitorCheck;
                }
            }
        }

        private void SecondStep()
        {
            //ShowMessageBox("保存成功！", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            if (_MONITORINFOCHECKBOOL == true)
            {
                PATINFOCHECK = Visibility.Collapsed;
                MONITORINFOCHECK = Visibility.Collapsed;
                INROOMTIMECHECK = Visibility.Visible;
                PATINFOCHECKBOOL = true;
                MONITORINFOCHECKBOOL = true;
                INROOMTIMECHECKBOOL = true;

                leftBtnText = "上一步";
                rightBtnText = "完 成";
                currentStep = ShowType.InRoomTimeCheck;
            }
        }

        private void ThirdStep()
        {
            TransactionParamsters tp = TransactionParamsters.Create();
            _masterRow.IN_DATE_TIME = IN_DATE_TIME.Value.AddSeconds(0 - IN_DATE_TIME.Value.Second);
            _masterRow.OPER_STATUS_CODE = (int)OperationStatus.InOperationRoom;
            //更新手术间字典表，将患者的3个ID写入
            MED_OPERATING_ROOM operRoom = MED_OPERATING_ROOM.Where(d => d.BED_TYPE == "0" &&
                                                                        d.ROOM_NO == ExtendAppContext.Current.OperRoomNo).First();
            operRoom.PATIENT_ID = _masterRow.PATIENT_ID;
            operRoom.VISIT_ID = _masterRow.VISIT_ID;
            operRoom.OPER_ID = _masterRow.OPER_ID;
            operRoom.ModelStatus = ModelStatus.Modeified;
            //modified by joysola on 2018-3-30 加入“是否更新排班程序状态”的判断
            if (ApplicationConfiguration.IsUpdateScheduleStatus)
            {
                MED_OPERATION_SCHEDULE scheduled = AnesInfoService.ClientInstance.GetOperSchedule(_masterRow.PATIENT_ID, _masterRow.VISIT_ID, _masterRow.OPER_ID);
                if (scheduled != null)
                {
                    scheduled.OPER_STATUS_CODE = 3;
                    tp.Append(scheduled);
                }
            }
            //modified end on 2018-3-30

            // 追加数据表
            tp.Append(_anesthesiaPlanRow).
               Append(_masterRow).
               Append(operRoom);

            bool result = CommonService.ClientInstance.UpdateByTransaction(tp.ToString());
            if (result)
            {
                if (MONITORDICT != null && MONITORDICT.Count > 0)
                {
                    foreach (MED_MONITOR_DICT row in MONITORDICT)
                    {
                        row.PATIENT_ID = _masterRow.PATIENT_ID;
                        row.VISIT_ID = _masterRow.VISIT_ID;
                        row.OPER_ID = _masterRow.OPER_ID;
                        row.ModelStatus = ModelStatus.Modeified;

                        // 自动启动监护仪
                        if (!string.IsNullOrEmpty(row.DRIVER_PROG))
                        {
                            string strPath = ExtendAppContext.Current.AppPath + row.DRIVER_PROG;
                            bool hasStart = false;
                            // 获取当前启动的所有进程
                            string strProcessName = row.DRIVER_PROG.Substring(0, row.DRIVER_PROG.ToLower().IndexOf(".exe"));
                            Process[] myProgress = Process.GetProcessesByName(strProcessName);
                            // 查看采集EXE是否启动
                            foreach (Process p in myProgress)
                            {
                                if (p.ProcessName.Equals(strProcessName))
                                {
                                    hasStart = true;
                                    break;
                                }
                            }

                            // 进程没有启动同时采集EXE必须存在
                            if (!hasStart && File.Exists(strPath))
                            {
                                System.Diagnostics.Process.Start(strPath);
                            }
                        }
                    }

                    DictService.ClientInstance.UpdateMonitorDict(MONITORDICT);
                }
            }

            this.ShowMessageBox("患者已入室。", MessageBoxButton.OK, MessageBoxImage.Information);
            ExtendAppContext.Current.PatientInformationExtend = PatInfoService.ClientInstance.GetCurPatientInfo(ExtendAppContext.Current.OperDeptCode,
                                                                                                                ExtendAppContext.Current.OperRoomNo);
        }

        /// <summary>
        /// 重置或上一步
        /// </summary>
        private void ResetDataOrPre()
        {
            if (currentStep == ShowType.PatInfoCheck)
            {
                LoadData();
            }
            else if (currentStep == ShowType.MonitorCheck)
            {
                PATINFOCHECK = Visibility.Visible;
                MONITORINFOCHECK = Visibility.Collapsed;
                INROOMTIMECHECK = Visibility.Collapsed;
                PATINFOCHECKBOOL = true;
                MONITORINFOCHECKBOOL = false;
                INROOMTIMECHECKBOOL = false;
                leftBtnText = "重 置";
                rightBtnText = "下一步";
                currentStep = ShowType.PatInfoCheck;
            }
            else if (currentStep == ShowType.InRoomTimeCheck)
            {
                PATINFOCHECK = Visibility.Collapsed;
                MONITORINFOCHECK = Visibility.Visible;
                INROOMTIMECHECK = Visibility.Collapsed;
                PATINFOCHECKBOOL = true;
                MONITORINFOCHECKBOOL = true;
                INROOMTIMECHECKBOOL = false;
                leftBtnText = "上一步";
                rightBtnText = "下一步";
                currentStep = ShowType.MonitorCheck;
            }
        }

        #endregion

        #region 命令

        /// <summary>
        /// 保存或下一步
        /// </summary>
        public ICommand SaveOrNextCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    if (currentStep == ShowType.PatInfoCheck)
                    {
                        FirstStep();
                    }
                    //第二步，仪器配置
                    else if (currentStep == ShowType.MonitorCheck)
                    {
                        SecondStep();
                    }
                    else
                    {
                        PublicKeyBoardMessage(KeyCode.AppCode.Save);
                    }
                });
            }
        }

        /// <summary>
        /// 重置或上一步
        /// </summary>
        public ICommand ResetOrPreCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    ResetDataOrPre();
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

            //入室后刷新主页面保存后刷新
            if (saveResult == SaveResult.CancelMessageBox)
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);
        }
        #endregion
    }
}
