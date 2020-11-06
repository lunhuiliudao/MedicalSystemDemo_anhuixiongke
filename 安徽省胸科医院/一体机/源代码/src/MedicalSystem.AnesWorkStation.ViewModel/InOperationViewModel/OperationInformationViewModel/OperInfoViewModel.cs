//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AfterOperationInformationControl.cs
//功能描述(Description)：    术后登记以及手术信息共用ViewModel
//数据表(Tables)：		       
//作者(Author)：                 MDSD
//日期(Create Date)：         2017/12/26 14:27:59
//R1: 
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝  
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Framework.Utilities;
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

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class OperInfoViewModel : BaseViewModel
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public OperInfoViewModel(bool isAfterOper)
        {
            // 载入字典数据
            LoadDictData();

            this.isAfterOperInfo = isAfterOper;
        }

        /// 分隔符
        /// </summary>
        public const string CommonSplit = "+";

        /// <summary>
        /// <summary>
        /// 保存返回值
        /// </summary>
        SaveResult saveResult = SaveResult.Fail;
        #region 界面控件字段绑定
        private string _OPER_ROOM_NO;                                                // 手术间号
        private Nullable<Int32> _SEQUENCE;                                         // 台次
        private string _PATIENT_ID;                                                        // 患者ID
        private string _INP_NO;                                                              // 住院号
        private string _NAME;                                                                 // 姓名
        private string _SEX;                                                                     // 性别
        private Nullable<DateTime> _DATE_OF_BIRTH;                           // 出生日期
        private string _AGE;                                                                    // 年龄
        private string _BED_NO;                                                              // 床号
        private string _DEPT_CODE;                                                        // 科室代码
        private string _DEPT_NAME;                                                 // 科室名称
        private string _DIAG_BEFORE_OPERATION;                                     // 术前诊断
        private ObservableCollection<string> _OPERATION_NAME = new ObservableCollection<string>();          // 拟施手术
        private string _OPER_SCALE;                                                // 手术等级
        private string _OPER_POSITION;                                             // 手术体位
        private Nullable<Int32> _EMERGENCY_IND;                                    // 急诊择期
        private Nullable<Int32> _ISOLATION_IND;                                    // 隔离标志
        private Nullable<Int32> _RADIATE_IND;                                      // 放射标志
        private string _PATIENT_CONDITION;                                         // 病情
        private string _SURGEON;                                                    // 手术医生CODE1
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
        private ObservableCollection<string> _ANES_METHOD = new ObservableCollection<string>();          // 麻醉方法(多选)
        private string _ANAESTHESIA_TYPE;                                          // 麻醉方法分类
        private string _ANES_DOCTOR;                                               // 麻醉医生1
        private string _ANES_DOCTOR_NAME;
        private string _FIRST_ANES_ASSISTANT;                                      // 麻醉医生2
        private string _FIRST_ANES_ASSISTANT_NAME;
        private string _SECOND_ANES_ASSISTANT;                                     // 麻醉医生3
        private string _SECOND_ANES_ASSISTANT_NAME;
        private string _THIRD_ANES_ASSISTANT;                                      // 麻醉医生4
        private string _THIRD_ANES_ASSISTANT_NAME;
        private string _ASA_GRADE;                                                     // ASA分级
        private string _WOUND_TYPE;                                                 // 切口等级
        private string _RETURN_TO_SURGERY;                                     // 是否24小时内重返手术室
        private string _PLAN_WHEREABORTS;                                     // 术后计划患者去向
        private Nullable<DateTime> _IN_DATE_TIME;                        //入手术室时间
        private Nullable<DateTime> _START_DATE_TIME;                 //手术开始时间
        private Nullable<DateTime> _ANES_START_TIME;                 //麻醉开始时间
        private Nullable<DateTime> _ANES_END_TIME;                    //麻醉结束时间
        private Nullable<DateTime> _END_DATE_TIME;                    //手术结束时间
        private Nullable<DateTime> _OUT_DATE_TIME;                    //出手术室时间
        private bool _IsOperRoomEnable = true;
        private int minimalInvasive;                                               // 微创手术标识
        private bool isAfterOperInfo = false; // 当前帮的界面是否为术后登记
        private int localAnesthesia;                                               // 局麻手术标识，0-非局麻、1-局麻

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
        /// 局麻手术标识，0-非局麻、1-局麻
        /// </summary>
        public int LOCAL_ANESTHESIA
        {
            get { return this.localAnesthesia; }
            set
            {
                this.localAnesthesia = value;
                this.RaisePropertyChanged("LOCAL_ANESTHESIA");
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
        /// 手术开始
        /// </summary>
        public Nullable<DateTime> START_DATE_TIME
        {
            get
            {
                return _START_DATE_TIME;
            }
            set
            {
                this._START_DATE_TIME = value;
                RaisePropertyChanged("START_DATE_TIME");
            }
        }

        /// <summary>
        /// 麻醉开始
        /// </summary>
        public Nullable<DateTime> ANES_START_TIME
        {
            get
            {
                return _ANES_START_TIME;
            }
            set
            {
                this._ANES_START_TIME = value;
                RaisePropertyChanged("ANES_START_TIME");
            }
        }

        /// <summary>
        /// 麻醉结束
        /// </summary>
        public Nullable<DateTime> ANES_END_TIME
        {
            get
            {
                return _ANES_END_TIME;
            }
            set
            {
                this._ANES_END_TIME = value;
                RaisePropertyChanged("ANES_END_TIME");
            }
        }

        /// <summary>
        /// 手术结束
        /// </summary>
        public Nullable<DateTime> END_DATE_TIME
        {
            get
            {
                return _END_DATE_TIME;
            }
            set
            {
                this._END_DATE_TIME = value;
                RaisePropertyChanged("END_DATE_TIME");
            }
        }

        /// <summary>
        /// 出手术室
        /// </summary>
        public Nullable<DateTime> OUT_DATE_TIME
        {
            get
            {
                return _OUT_DATE_TIME;
            }
            set
            {
                this._OUT_DATE_TIME = value;
                RaisePropertyChanged("OUT_DATE_TIME");
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
        /// <summary>
        /// 手术医生名称1
        /// </summary>
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
        /// <summary>
        /// 手术医生名称2
        /// </summary>
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
        /// <summary>
        /// 手术医生名称3
        /// </summary>
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
        /// <summary>
        /// 灌注医生名称1
        /// </summary>
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
        /// <summary>
        /// 灌注医生名称2
        /// </summary>
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
        /// <summary>
        /// 洗手护士名称1
        /// </summary>
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
        /// <summary>
        /// 洗手护士名称2
        /// </summary>
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
        /// <summary>
        /// 巡回护士名称1
        /// </summary>
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
        /// <summary>
        /// 巡回护士姓名2
        /// </summary>
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

        public bool IsOperRoomEnable
        {
            get
            {
                return _IsOperRoomEnable;
            }
            set
            {
                _IsOperRoomEnable = value;
                RaisePropertyChanged("IsOperRoomEnable");
            }
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
        /// 载入数据
        /// </summary>
        public override void LoadData()
        {
            string pid = "";
            int visitID = 1;
            int operID = 1;
            pid = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            _masterRow = AnesInfoService.ClientInstance.GetOperationMaster(pid, visitID, operID);

            if (_masterRow != null)
            {
                try
                {
                    _patsInHospitalRow = AnesInfoService.ClientInstance.GetPatsInHospitalListByID(_masterRow.PATIENT_ID).OrderByDescending(c => c.VISIT_ID).ToList().First();
                    _patMasterIndexRow = AnesInfoService.ClientInstance.GetPatMasterIndex(_masterRow.PATIENT_ID).First();
                    _anesthesiaPlanRow = AnesInfoService.ClientInstance.GetAnesthesiaPlan(_masterRow.PATIENT_ID, _masterRow.VISIT_ID, _masterRow.OPER_ID).First();
                }
                catch (Exception ex)
                {
                    Logger.Error("获取患者基本信息异常", ex);
                    ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                OPER_ROOM_NO = _masterRow.OPER_ROOM_NO;
                if (!CanChangeOperRoomNo())
                {
                    IsOperRoomEnable = false;
                }
                SEQUENCE = _masterRow.SEQUENCE;
                PATIENT_ID = _masterRow.PATIENT_ID;
                INP_NO = _patsInHospitalRow.INP_NO;
                NAME = _patMasterIndexRow.NAME;
                SEX = _patMasterIndexRow.SEX;
                DATE_OF_BIRTH = _patMasterIndexRow.DATE_OF_BIRTH;
                BED_NO = _masterRow.BED_NO;
                DEPT_CODE = _masterRow.DEPT_CODE;
                DIAG_BEFORE_OPERATION = _masterRow.DIAG_BEFORE_OPERATION;
                // 手术名称 (新分隔符)
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
                if (this.isAfterOperInfo)
                {
                    IN_DATE_TIME = _masterRow.IN_DATE_TIME;// == null ? DateTime.Now : _masterRow.IN_DATE_TIME;
                    START_DATE_TIME = _masterRow.START_DATE_TIME;// == null ? DateTime.Now : _masterRow.START_DATE_TIME;
                    END_DATE_TIME = _masterRow.END_DATE_TIME;// == null ? DateTime.Now : _masterRow.END_DATE_TIME;
                    OUT_DATE_TIME = _masterRow.OUT_DATE_TIME;//== null ? DateTime.Now : _masterRow.OUT_DATE_TIME;
                }
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
                // 麻醉方法(多选)
                //if (!string.IsNullOrEmpty(_masterRow.ANES_METHOD))
                //{
                //    string[] anesMethod = _masterRow.ANES_METHOD.Split(new string[] { CommonSplit },
                //                                                       StringSplitOptions.RemoveEmptyEntries);
                //    ANES_METHOD = new ObservableCollection<string>(anesMethod);
                //}
                //else if (ANES_METHOD != null)
                //{
                //    ANES_METHOD.Clear();
                //}
                //else
                //{
                //    ANES_METHOD = new ObservableCollection<string>();
                //}
                ANES_METHOD_NAME = _masterRow.ANES_METHOD;
                ANAESTHESIA_TYPE = _masterRow.ANAESTHESIA_TYPE;
                ASA_GRADE = _masterRow.ASA_GRADE;
                WOUND_TYPE = _masterRow.WOUND_TYPE;
                RETURN_TO_SURGERY = _anesthesiaPlanRow.RETURN_TO_SURGERY;
                PLAN_WHEREABORTS = _anesthesiaPlanRow.PLAN_WHEREABORTS;
                DEPT_NAME = _masterRow.DEPT_NAME;
                AGE = DateDiff.CalAge((DateTime)_patMasterIndexRow.DATE_OF_BIRTH, _masterRow.SCHEDULED_DATE_TIME.Value);
                this.MINIMAL_INVASIVE = _masterRow.MINIMAL_INVASIVE;
                this.LOCAL_ANESTHESIA = _masterRow.LOCAL_ANESTHESIA;
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
                _masterRow.OPER_ROOM_NO = OPER_ROOM_NO;
                _masterRow.SEQUENCE = SEQUENCE;
                _masterRow.BED_NO = BED_NO;
                _masterRow.DEPT_CODE = DEPT_CODE;
                _masterRow.DIAG_BEFORE_OPERATION = DIAG_BEFORE_OPERATION;
                // 手术名称(新分隔符)
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
                // 麻醉方法多选处理
                //string anesMethod = string.Empty;
                //if (ANES_METHOD != null)
                //{
                //    foreach (string item in ANES_METHOD)
                //    {
                //        anesMethod += item + CommonSplit;
                //    }
                //}
                //if (anesMethod.Length > 0)
                //{
                //    anesMethod = anesMethod.Substring(0, anesMethod.Length - CommonSplit.Length);
                //}
                //_masterRow.ANES_METHOD = anesMethod;

                _masterRow.ANES_METHOD = ANES_METHOD_NAME;

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
                _masterRow.MINIMAL_INVASIVE = this.MINIMAL_INVASIVE;
                _masterRow.LOCAL_ANESTHESIA = this.LOCAL_ANESTHESIA;
                // 局麻手术
                if (this.isAfterOperInfo)
                {
                    if (1 == this.LOCAL_ANESTHESIA)
                    {
                        _masterRow.IN_DATE_TIME = this.IN_DATE_TIME;
                        _masterRow.START_DATE_TIME = this.START_DATE_TIME;
                        _masterRow.END_DATE_TIME = this.END_DATE_TIME;
                        _masterRow.OUT_DATE_TIME = this.OUT_DATE_TIME;
                        _masterRow.OPER_STATUS_CODE = 35;
                    }
                    else
                    {
                        _masterRow.IN_DATE_TIME = null;
                        _masterRow.START_DATE_TIME = null;
                        _masterRow.END_DATE_TIME = null;
                        _masterRow.OUT_DATE_TIME = null;
                        _masterRow.OPER_STATUS_CODE = 0;
                    }
                }

                TransactionParamsters tp = TransactionParamsters.Create();
                tp.Append(_masterRow);

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
                tp.Append(listOperationName);
                _anesthesiaPlanRow.OPER_ID = _anesthesiaPlanRow.OPER_ID;
                _anesthesiaPlanRow.RETURN_TO_SURGERY = RETURN_TO_SURGERY;
                _anesthesiaPlanRow.PLAN_WHEREABORTS = PLAN_WHEREABORTS;
                tp.Append(_anesthesiaPlanRow);
                result = CommonService.ClientInstance.UpdateByTransaction(tp.ToString());
            }
            if (result)
            {
                saveResult = SaveResult.Success;
            }

            return saveResult;
        }

        /// <summary>
        /// 检查数据有效
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            bool result = true;
            if (OPER_ROOM_NO == null)
            {
                ShowMessageBox("请输入患者手术间号。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            else if (result && DEPT_CODE == null)
            {
                ShowMessageBox("患者所在科室为必填项。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }

            if (this.isAfterOperInfo && LOCAL_ANESTHESIA == 1)
            {
                if (this.IN_DATE_TIME <= this.START_DATE_TIME)
                {
                    if (this.START_DATE_TIME <= this.END_DATE_TIME)
                    {
                        if (this.END_DATE_TIME > this.OUT_DATE_TIME)
                        {
                            ShowMessageBox("出手术室时间小于手术结束时间，请重新填写。", MessageBoxButton.OK, MessageBoxImage.Warning);
                            result = false;
                        }
                    }
                    else
                    {
                        ShowMessageBox("手术结束时间小于手术开始时间，请重新填写。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                }
                else
                {
                    ShowMessageBox("手术开始时间小于入手术室时间，请重新填写。", MessageBoxButton.OK, MessageBoxImage.Warning);
                    result = false;
                }
            }

            return result;
        }

        private bool CanChangeOperRoomNo()
        {
            if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= 5)
            {
                return false;
            }
            else return true;
        }

        #endregion

        #region 命令
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
                    //手术信息的重置是不保存当前修改，直接重新获取数据并刷新界面
                    LoadData();
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

            //手术信息关闭后刷新主界面
            if (saveResult == SaveResult.Success)
            {
                //搜索列表进行修改手术信息，不刷新首页
                DateTime date = DateTime.Now.Date;
                if (_masterRow.OPER_ROOM_NO != ExtendAppContext.Current.OperRoomNo ||
                    (_masterRow.OUT_DATE_TIME.HasValue && date != _masterRow.OUT_DATE_TIME.Value.Date))
                {
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshWordList);
                    return;
                }
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);
                if (_masterRow.OPER_STATUS_CODE < (int)OperationStatus.InOperationRoom ||
                    _masterRow.OPER_STATUS_CODE >= (int)OperationStatus.OutOperationRoom)
                {
                    List<object> list = new List<object>();
                    list.Add(_masterRow);
                    if (_masterRow.OPER_STATUS_CODE >= (int)OperationStatus.OutOperationRoom)//术后患者
                        list.Add("FinishWorkList");//已完成
                    else
                        list.Add("UnFinishWorkList");//未完成 
                    Messenger.Default.Send<object>(list, EnumMessageKey.SetWorkListSelectItem);
                }
            }
        }
        #endregion
    }
}

