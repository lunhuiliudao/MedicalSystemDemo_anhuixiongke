using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Framework.Utilities;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.Anes.FrameWork.Enum;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.InHospitalRegisterViewModel
{
    public class OutHospitalRegisterViewModel : BaseViewModel
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
        public OutHospitalRegisterViewModel()
        {
            // 载入字典数据
            LoadDictData();
        }
        /// <summary>
        /// 保存返回值
        /// </summary>
        SaveResult saveResult = SaveResult.Fail;
        #region 界面绑定相关字段
        #region 界面控件值绑定
        List<MED_CHECKBOX_ITEM> _listTemp;
        string _UNEXPECT_EVENT_REASON = "";
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
        private string _DIAG_BEFORE_OPERATION;                                     // 术前诊断
        private ObservableCollection<MED_OPERATION_DICT> _OPERATION_NAME = new ObservableCollection<MED_OPERATION_DICT>();          // 拟施手术
        private string _OPER_SCALE;                                                // 手术等级
        private string _OPER_POSITION;                                             // 手术体位
        private Nullable<Int32> _EMERGENCY_IND;                                    // 急诊择期
        private Nullable<Int32> _ISOLATION_IND;                                    // 隔离标志
        private Nullable<Int32> _RADIATE_IND;                                      // 放射标志
        private string _PATIENT_CONDITION;                                         // 病情
        private string _SURGEON;                                                   // 手术医生1
        private string _FIRST_OPER_ASSISTANT;                                      // 手术医生2
        private string _SECOND_OPER_ASSISTANT;                                     // 手术医生3
        private string _CPB_DOCTOR;                                                // 灌注医生1
        private string _FIRST_CPB_ASSISTANT;                                       // 灌注医生2
        private string _FIRST_OPER_NURSE;                                          // 洗手护士1
        private string _SECOND_OPER_NURSE;                                         // 洗手护士2
        private string _FIRST_SUPPLY_NURSE;                                        // 巡回护士1
        private string _SECOND_SUPPLY_NURSE;                                       // 巡回护士2
        private string _ANES_METHOD;                                               // 麻醉方法
        private string _ANAESTHESIA_TYPE;                                          // 麻醉方法分类
        private string _ANES_DOCTOR;                                               // 麻醉医生1
        private string _FIRST_ANES_ASSISTANT;                                      // 麻醉医生2
        private string _SECOND_ANES_ASSISTANT;                                     // 麻醉医生3
        private string _THIRD_ANES_ASSISTANT;                                      // 麻醉医生4
        private string _ASA_GRADE;                                                 // ASA分级
        private string _WOUND_TYPE;                                                // 切口等级
        private string _RETURN_TO_SURGERY;                                         // 是否24小时内重返手术室
        private string _PLAN_WHEREABORTS;                                          // 术后计划患者去向
        private string _OUT_OPER_WHEREABORTS;                                      // 术后实际患者去向
        private Visibility _PATINFOCHECK;                                          // 病人信息界面显示FLAG
        private Visibility _OUTROOMTIMECHECK;                                       // 入室时间界面显示FLAG
        private bool _PATINFOCHECKBOOL;
        private bool _OUTROOMTIMECHECKBOOL;
        private string _ZONGRULIANG;                                               // 总入量
        private string _ZONGCHULIANG;                                              // 总出量
        private string _SHUXUE;                                                    // 输血
        private string _ZITIXUE;                                                   // 自体血
        private Nullable<DateTime> _IN_DATE_TIME;
        private Nullable<DateTime> _START_DATE_TIME;
        private Nullable<DateTime> _ANES_START_TIME;
        private Nullable<DateTime> _ANES_END_TIME;
        private Nullable<DateTime> _END_DATE_TIME;
        private Nullable<DateTime> _OUT_DATE_TIME;
        // 麻醉效果
        private string _ANES_EFFECT;

        public string ANES_EFFECT
        {
            get { return _ANES_EFFECT; }
            set
            {
                _ANES_EFFECT = value;
                RaisePropertyChanged("ANES_EFFECT");
            }
        }

        // 术后镇痛
        private Nullable<Int32> _AFTER_ANALGESIA;

        public Nullable<Int32> AFTER_ANALGESIA
        {
            get { return _AFTER_ANALGESIA; }
            set
            {
                _AFTER_ANALGESIA = value;
                RaisePropertyChanged("AFTER_ANALGESIA");
            }
        }

        // 镇痛方式
        private string _ANALGESIA_METHOD;

        public string ANALGESIA_METHOD
        {
            get { return _ANALGESIA_METHOD; }
            set
            {
                _ANALGESIA_METHOD = value;
                RaisePropertyChanged("ANALGESIA_METHOD");
            }
        }


        private string _leftBtnText = "重 置";
        private string _rightBtnText = "下一步";

        /// <summary>
        /// 总入量
        /// </summary>
        public string ZONGRULIANG
        {
            get
            {
                return _ZONGRULIANG;
            }
            set
            {
                this._ZONGRULIANG = value;
                RaisePropertyChanged("ZONGRULIANG");
            }
        }

        /// <summary>
        /// 总出量
        /// </summary>
        public string ZONGCHULIANG
        {
            get
            {
                return _ZONGCHULIANG;
            }
            set
            {
                this._ZONGCHULIANG = value;
                RaisePropertyChanged("ZONGCHULIANG");
            }
        }

        /// <summary>
        /// 输血
        /// </summary>
        public string SHUXUE
        {
            get
            {
                return _SHUXUE;
            }
            set
            {
                this._SHUXUE = value;
                RaisePropertyChanged("SHUXUE");
            }
        }

        /// <summary>
        /// 自体血
        /// </summary>
        public string ZITIXUE
        {
            get
            {
                return _ZITIXUE;
            }
            set
            {
                this._ZITIXUE = value;
                RaisePropertyChanged("ZITIXUE");
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
            set { _AGE = value; }
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
        public ObservableCollection<MED_OPERATION_DICT> OPERATION_NAME
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
                RaisePropertyChanged("ANES_METHOD");
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

        /// <summary>
        /// 术后实际患者去向
        /// </summary>
        public string OUT_OPER_WHEREABORTS
        {
            get
            {
                return _OUT_OPER_WHEREABORTS;
            }
            set
            {
                this._OUT_OPER_WHEREABORTS = value;
                RaisePropertyChanged("_OUT_OPER_WHEREABORTS");
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
        /// 出室
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

        public List<MED_CHECKBOX_ITEM> LIST_TEMP
        {
            get
            {
                return _listTemp;
            }
            set
            {
                this._listTemp = value;
                RaisePropertyChanged("LIST_TEMP");
            }
        }

        public string UNEXPECT_EVENT_REASON
        {
            get
            {
                return _UNEXPECT_EVENT_REASON;
            }
            set
            {
                _UNEXPECT_EVENT_REASON = value;
                RaisePropertyChanged("UNEXPECT_EVENT_REASON");
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


        public Visibility OUTROOMTIMECHECK
        {
            get { return _OUTROOMTIMECHECK; }
            set
            {
                _OUTROOMTIMECHECK = value;

                RaisePropertyChanged("OUTROOMTIMECHECK");


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

        public bool OUTROOMTIMECHECKBOOL
        {
            get { return _OUTROOMTIMECHECKBOOL; }
            set
            {
                _OUTROOMTIMECHECKBOOL = value;

                RaisePropertyChanged("OUTROOMTIMECHECKBOOL");


            }
        }

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
        #endregion

        #endregion

        #region 数据源
        MED_OPERATION_MASTER _masterRow;
        MED_PATS_IN_HOSPITAL _patsInHospitalRow;
        MED_PAT_MASTER_INDEX _patMasterIndexRow;
        MED_ANESTHESIA_PLAN _anesthesiaPlanRow;
        MED_ANESTHESIA_INPUT_DATA _anesInputData;
        List<MED_ANESTHESIA_EVENT> _anesthesisEventRows;
        #endregion

        #region 方法

        /// <summary>
        /// 载入数据
        /// </summary>
        public override void LoadData()
        {
            _masterRow = AnesInfoService.ClientInstance.GetOperationMaster(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
               ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
            if (_masterRow != null && !string.IsNullOrEmpty(_masterRow.PATIENT_ID))
            {
                _anesInputData = CareDocService.ClientInstance.GetAnesthestaInputData(_masterRow.PATIENT_ID, _masterRow.VISIT_ID, _masterRow.OPER_ID);
                _patsInHospitalRow = AnesInfoService.ClientInstance.GetPatsInHospitalListByID(_masterRow.PATIENT_ID).OrderByDescending(c => c.VISIT_ID).ToList().First();
                _patMasterIndexRow = AnesInfoService.ClientInstance.GetPatMasterIndex(_masterRow.PATIENT_ID).First();
                try
                {
                    _anesthesiaPlanRow = AnesInfoService.ClientInstance.GetAnesthesiaPlan(_masterRow.PATIENT_ID).OrderByDescending(c => c.VISIT_ID).ThenByDescending(c => c.OPER_ID).First();
                }
                catch
                {
                    _anesthesiaPlanRow = new MED_ANESTHESIA_PLAN();
                    _anesthesiaPlanRow.PATIENT_ID = _masterRow.PATIENT_ID;
                    _anesthesiaPlanRow.VISIT_ID = _masterRow.VISIT_ID;
                    _anesthesiaPlanRow.OPER_ID = _masterRow.OPER_ID;
                }
                //_listOperName = CareDocService.ClientInstance.GetOperNameList("1130049", 1, 1);
                OPER_ROOM_NO = _masterRow.OPER_ROOM_NO;
                SEQUENCE = _masterRow.SEQUENCE;
                PATIENT_ID = _masterRow.PATIENT_ID;
                INP_NO = _patsInHospitalRow.INP_NO;
                NAME = _patMasterIndexRow.NAME;
                SEX = _patMasterIndexRow.SEX;
                DATE_OF_BIRTH = _patMasterIndexRow.DATE_OF_BIRTH;
                BED_NO = _masterRow.BED_NO;
                DEPT_CODE = _masterRow.DEPT_CODE;
                //SCHEDULED_DATE_TIME = _masterRow.SCHEDULED_DATE_TIME;
                DIAG_BEFORE_OPERATION = _masterRow.DIAG_BEFORE_OPERATION;
                // 手术名称
                //if (!string.IsNullOrEmpty(_masterRow.OPERATION_NAME))
                //{
                //    string[] operNameArray = _masterRow.OPERATION_NAME.Split('+');
                //    List<MED_OPERATION_DICT> operationList = MED_OPERATION_DICT.Where(r => operNameArray.Contains(r.OPER_NAME)).ToList();
                //    OPERATION_NAME = new ObservableCollection<Domain.MED_OPERATION_DICT>(operationList);
                //}

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
                //AGE = DateTime.Now.Year - _patMasterIndexRow.DATE_OF_BIRTH.Value.Year;
                AGE = DateDiff.CalAge((DateTime)_patMasterIndexRow.DATE_OF_BIRTH, _masterRow.SCHEDULED_DATE_TIME.Value);

                if (_masterRow.IN_DATE_TIME != null)
                {
                    IN_DATE_TIME = (DateTime)_masterRow.IN_DATE_TIME;
                }
                if (_masterRow.ANES_START_TIME != null)
                {
                    ANES_START_TIME = (DateTime)_masterRow.ANES_START_TIME;
                }
                if (_masterRow.START_DATE_TIME != null)
                {
                    START_DATE_TIME = (DateTime)_masterRow.START_DATE_TIME;
                }
                if (_masterRow.END_DATE_TIME != null)
                {
                    END_DATE_TIME = (DateTime)_masterRow.END_DATE_TIME;
                }
                if (_masterRow.ANES_END_TIME != null)
                {
                    ANES_END_TIME = (DateTime)_masterRow.ANES_END_TIME;
                }
                OUT_DATE_TIME = DateTime.Now;

                PATINFOCHECK = Visibility.Visible;
                OUTROOMTIMECHECK = Visibility.Collapsed;

                PATINFOCHECKBOOL = true;
                OUTROOMTIMECHECKBOOL = false;

                ANES_EFFECT = _anesInputData.ANES_EFFECT;
                AFTER_ANALGESIA = _anesInputData.AFTER_ANALGESIA;
                ANALGESIA_METHOD = _anesInputData.ANALGESIA_METHOD;

                // 计算总入量，总出量，输血，自体血
                double Ruliang = 0;
                double ChuLiang = 0;
                double ShuXue = 0;
                double ZiTiXue = 0;
                _anesthesisEventRows = AnesInfoService.ClientInstance.GetAnesthesiaEventByEventNo(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
               ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, ExtendAppContext.Current.PatientInformationExtend.OPER_ID, "0");

                //  总入量
                List<MED_ANESTHESIA_EVENT> listRuLiang = _anesthesisEventRows.
                Where(d => d.EVENT_CLASS_CODE.Equals(AnesEventType.GetAnesClassTypeString(AnesEventType.AnesClassType.InLiquid))
                || d.EVENT_CLASS_CODE.Equals(AnesEventType.GetAnesClassTypeString(AnesEventType.AnesClassType.InBlood))).ToList();
                foreach (MED_ANESTHESIA_EVENT tempEvent in listRuLiang)
                {
                    if (tempEvent.DOSAGE != null)
                    {
                        Ruliang += double.Parse(tempEvent.DOSAGE.ToString());
                    }
                }
                // 总出量
                List<MED_ANESTHESIA_EVENT> listChuLiang = _anesthesisEventRows.
                   Where(d => d.EVENT_CLASS_CODE.Equals(AnesEventType.GetAnesClassTypeString(AnesEventType.AnesClassType.OutLiquid))).ToList();
                foreach (MED_ANESTHESIA_EVENT tempEvent in listChuLiang)
                {
                    if (tempEvent.DOSAGE != null)
                    {
                        ChuLiang += double.Parse(tempEvent.DOSAGE.ToString());
                    }
                }
                // 输血
                List<MED_ANESTHESIA_EVENT> listShuXue = _anesthesisEventRows.
                  Where(d => d.EVENT_CLASS_CODE.Equals(AnesEventType.GetAnesClassTypeString(AnesEventType.AnesClassType.InBlood))).ToList();
                foreach (MED_ANESTHESIA_EVENT tempEvent in listShuXue)
                {
                    if (tempEvent.DOSAGE != null)
                    {
                        ShuXue += double.Parse(tempEvent.DOSAGE.ToString());
                    }
                }
                // 自体血,根据属性Event_attr=自体血来判断
                List<MED_EVENT_DICT> eventDictList = ApplicationModel.Instance.AllDictList.EventDictList;
                foreach (MED_ANESTHESIA_EVENT tempEvent in _anesthesisEventRows)
                {
                    if (tempEvent.DOSAGE != null)
                    {
                        List<MED_EVENT_DICT> eventRow = eventDictList.Where(x => x.EVENT_CLASS_CODE == tempEvent.EVENT_CLASS_CODE && x.EVENT_ITEM_NAME == tempEvent.EVENT_ITEM_NAME).ToList();
                        if (eventRow != null && eventRow.Count > 0 && !string.IsNullOrEmpty(eventRow[0].EVENT_ATTR) && eventRow[0].EVENT_ATTR.Equals("自体血"))
                        {
                            ZiTiXue += double.Parse(tempEvent.DOSAGE.ToString());
                        }
                    }
                }
                _ZONGRULIANG = Ruliang.ToString();
                _ZONGCHULIANG = ChuLiang.ToString();
                _SHUXUE = ShuXue.ToString();
                _ZITIXUE = ZiTiXue.ToString();

                #region 17项质控数据处理
                //麻醉开始后取消
                if (_masterRow != null && _masterRow.LOCAL_ANESTHESIA == 0 && _masterRow.START_DATE_TIME == null)
                {
                    _anesInputData.CANCELED_TYPE = "1";
                }
                else
                {
                    _anesInputData.CANCELED_TYPE = null;
                }

                //椎管内麻醉后严重神经并发症发生例数
                List<string> _listAnesMethodConfig = CommonService.ClientInstance.GetAnesConfigByParams("椎管内麻醉大类");

                if (_masterRow != null)
                {
                    if (!string.IsNullOrEmpty(_masterRow.ANES_METHOD)
                        && _listAnesMethodConfig != null && _listAnesMethodConfig.Count > 0
                        && _listAnesMethodConfig.FindAll(t => t == _masterRow.ANES_METHOD.Trim()).Count > 0)
                    {
                        _anesInputData.SPINAL_ANES_COMP = 1;
                    }
                    else
                    {
                        _anesInputData.SPINAL_ANES_COMP = null;
                    }
                }

                //全麻气管插管拔管后声音嘶哑发生例数
                List<string> _listAnesMethodConfig2 = CommonService.ClientInstance.GetAnesConfigByParams("插管全麻大类");

                if (_masterRow != null)
                {
                    if (!string.IsNullOrEmpty(_masterRow.ANES_METHOD)
                        && _listAnesMethodConfig2 != null && _listAnesMethodConfig2.Count > 0
                        && _listAnesMethodConfig2.FindAll(t => t == _masterRow.ANES_METHOD.Trim()).Count > 0)
                    {
                        _anesInputData.TRACHEA_HOARSE = 1;
                    }
                    else
                    {
                        _anesInputData.TRACHEA_HOARSE = null;
                    }
                }

                //麻醉中接受400ml及以上输血治疗的患者总数
                if (ShuXue >= 400)
                {
                    _anesInputData.BLOOD_EVENT = 1;
                }
                else
                {
                    _anesInputData.BLOOD_EVENT = null;
                }

                //麻醉中接受400ml及以上自体血（包括自体全血及自体血红细胞）输注患者数
                if (ZiTiXue >= 400)
                {
                    _anesInputData.BLOOD_EVENT_SELF = 1;
                }
                else
                {
                    _anesInputData.BLOOD_EVENT_SELF = null;
                }
                #endregion

                _listTemp = new List<MED_CHECKBOX_ITEM>();
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "麻醉开始后取消", ITEM_VALUE = _anesInputData.CANCELED_TYPE == "1" ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "椎管内麻醉后严重并发症", ITEM_VALUE = _anesInputData.SPINAL_ANES_COMP == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "麻醉中发生意识障碍", ITEM_VALUE = _anesInputData.CONS_DISTURBANCE == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "麻醉中因呜咽误吸引发呼吸梗阻", ITEM_VALUE = _anesInputData.RES_TRACT_OBSTRUCE == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "非计划二次插管", ITEM_VALUE = _anesInputData.TRACHEA_6H == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "非计划转入ICU", ITEM_VALUE = _anesInputData.NO_PLAN_IN_ICU == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "中心静脉穿刺严重并发症", ITEM_VALUE = _anesInputData.CENTRAL_VENOUS == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "麻醉中发生氧饱和度重度降低", ITEM_VALUE = _anesInputData.OXYGEN_SATURATION == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "麻醉后新发昏迷", ITEM_VALUE = _anesInputData.AFTER_ANES_COMA == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "麻醉期间发生严重过敏反应", ITEM_VALUE = _anesInputData.ANES_ANAPHYLAXIS == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "全麻气管插管拔管后发生声音嘶哑", ITEM_VALUE = _anesInputData.TRACHEA_HOARSE == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "麻醉中意外死亡", ITEM_VALUE = _anesInputData.ANES_DEATH == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "麻醉中接受400ml及以上输血治疗", ITEM_VALUE = _anesInputData.BLOOD_EVENT == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "其它非预期事件", ITEM_VALUE = _anesInputData.OTHER_NOT_EXP == 1 ? true : false });
                _listTemp.Add(new MED_CHECKBOX_ITEM { ITEM_NAME = "麻醉中接受400ml及以上自体血输注（包括自体全血及自体血红细胞）", ITEM_VALUE = _anesInputData.BLOOD_EVENT_SELF == 1 ? true : false });

                LIST_TEMP = _listTemp;
                UNEXPECT_EVENT_REASON = _anesInputData.UNEXPECT_EVENT_REASON;
            }
        }

        /// <summary>
        /// 检查数据有效
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            bool result = true;
            if (!_OUTROOMTIMECHECKBOOL)
            {
                ShowMessageBox("请下一步后进行保存操作。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            else if (OUT_DATE_TIME == null || OUT_DATE_TIME == DateTime.MinValue)
            {
                ShowMessageBox("出室时间不能为空。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            else
            {
                if (OUT_DATE_TIME < ANES_END_TIME)
                {
                    ShowMessageBox("出室时间不能小于麻醉结束时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                    result = false;
                }
            }
            return result;
        }

        public override void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.PageDown)//下一页
            {
                if (_PATINFOCHECKBOOL)
                {
                    FirstStep();
                }

            }
            else if (e.Key == Key.PageUp)//上一页
            {
                ResetData();
            }
        }

        /// <summary>
        /// 保存患者信息
        /// </summary>
        protected override SaveResult SaveData()
        {
            if (_OUTROOMTIMECHECKBOOL)
            {
                ShowMessageBox("出室后术中信息将无法修改,是否确定出室？", MessageBoxButton.YesNoCancel,
                                 MessageBoxImage.Question,
                new Action<MessageBoxResult>((r) =>
                {
                    if (r == MessageBoxResult.OK || r == MessageBoxResult.Yes)
                    {
                        if (SecondStep())
                        {
                            StopAnesEvent(OUT_DATE_TIME.Value);
                            //ShowMessageBox("患者已成功出室。", MessageBoxButton.OK, MessageBoxImage.Information); // 六个时间点保存成功后无需弹出框

                            ////清空缓存
                            //ExtendAppContext.InOperation.PatientInformationExtend = null;
                            //ExtendAppContext.Current.PatientInformationExtend = null;
                            //关闭键盘灯
                            KeyBoardStateCache.KeyBoard.CloseSecondKeyBoardAllLed();
                            saveResult = SaveResult.CancelMessageBox;
                            Messenger.Default.Send<object>(this, EnumMessageKey.CloseInOperationWindow);
                        }
                    }
                    else
                    {
                        saveResult = SaveResult.Cancel;
                    }
                }));
            }

            return saveResult;
        }

        private void FirstStep()
        {
            if (PATIENT_ID == null || INP_NO == null || OPER_ROOM_NO == null || PLAN_WHEREABORTS == null)
            {
                ShowMessageBox("请输入必填项。", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_masterRow != null && _anesthesiaPlanRow != null)
            {
                _masterRow.OPER_ID = _masterRow.OPER_ID;

                _masterRow.OPER_ROOM_NO = OPER_ROOM_NO;
                _masterRow.SEQUENCE = SEQUENCE;
                _masterRow.BED_NO = BED_NO;
                _masterRow.DEPT_CODE = DEPT_CODE;
                _masterRow.DIAG_BEFORE_OPERATION = DIAG_BEFORE_OPERATION;
                //string operName = string.Empty;
                //if (OPERATION_NAME != null)
                //{
                //    foreach (MED_OPERATION_DICT operDict in OPERATION_NAME)
                //    {
                //        operName += operDict.OPER_NAME + ",";
                //    }
                //}
                //if (operName.Length > 0)
                //    operName = operName.Substring(0, operName.Length - 1);
                //_masterRow.OPERATION_NAME = operName;
                _masterRow.OPER_SCALE = OPER_SCALE;
                _masterRow.OPER_POSITION = OPER_POSITION;
                _masterRow.EMERGENCY_IND = EMERGENCY_IND;
                _masterRow.ISOLATION_IND = ISOLATION_IND;
                _masterRow.RADIATE_IND = RADIATE_IND;
                _masterRow.PATIENT_CONDITION = PATIENT_CONDITION;
                _masterRow.SURGEON = SURGEON;
                _masterRow.FIRST_OPER_ASSISTANT = FIRST_OPER_ASSISTANT;
                _masterRow.SECOND_OPER_ASSISTANT = SECOND_OPER_ASSISTANT;
                _masterRow.CPB_DOCTOR = CPB_DOCTOR;
                _masterRow.FIRST_CPB_ASSISTANT = FIRST_CPB_ASSISTANT;
                _masterRow.FIRST_OPER_NURSE = FIRST_OPER_NURSE;
                _masterRow.SECOND_OPER_NURSE = SECOND_OPER_NURSE;
                _masterRow.FIRST_SUPPLY_NURSE = FIRST_SUPPLY_NURSE;
                _masterRow.SECOND_SUPPLY_NURSE = SECOND_SUPPLY_NURSE;
                _masterRow.ANES_METHOD = ANES_METHOD;
                _masterRow.ANAESTHESIA_TYPE = ANAESTHESIA_TYPE;
                _masterRow.ANES_DOCTOR = ANES_DOCTOR;
                _masterRow.FIRST_ANES_ASSISTANT = FIRST_ANES_ASSISTANT;
                _masterRow.SECOND_ANES_ASSISTANT = SECOND_ANES_ASSISTANT;
                _masterRow.THIRD_ANES_ASSISTANT = THIRD_ANES_ASSISTANT;
                _masterRow.ASA_GRADE = ASA_GRADE;
                _masterRow.WOUND_TYPE = WOUND_TYPE;

                //AnesInfoService.ClientInstance.UpadteOperationMasterRow(_masterRow);

                _anesthesiaPlanRow.OPER_ID = _anesthesiaPlanRow.OPER_ID;
                _anesthesiaPlanRow.RETURN_TO_SURGERY = RETURN_TO_SURGERY;
                //_anesthesiaPlanRow.PLAN_WHEREABORTS = PLAN_WHEREABORTS;

                //AnesInfoService.ClientInstance.UpadteAnesPlanRow(_anesthesiaPlanRow);

                //ShowMessageBox("保存成功！", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                if (_PATINFOCHECKBOOL)
                {
                    PATINFOCHECK = Visibility.Collapsed;
                    OUTROOMTIMECHECK = Visibility.Visible;
                    PATINFOCHECKBOOL = false;
                    OUTROOMTIMECHECKBOOL = true;
                    leftBtnText = "上一步";
                    rightBtnText = "完 成";
                }

            }

            //计划患者去向与实际去向不符，并且实际转入ICU
            if (_anesthesiaPlanRow.PLAN_WHEREABORTS != PLAN_WHEREABORTS && PLAN_WHEREABORTS == "65")//65 ICU
            {
                this.ShowMessageBox("系统检测到如下质控事件：非计划转入ICU，请确认", MessageBoxButton.YesNo, MessageBoxImage.Question, new Action<MessageBoxResult>((mbr) =>
                {

                    if (mbr == MessageBoxResult.OK)
                    {
                        _anesInputData.NO_PLAN_IN_ICU = 1;
                    }
                    else
                    {
                        _anesInputData.NO_PLAN_IN_ICU = null;
                    }
                }));
            }

            //非计划二次插管
            if (_anesthesisEventRows.Where(t => t.EVENT_CLASS_CODE == "7").ToList().Count > 1)
            {
                this.ShowMessageBox("系统检测到如下质控事件：非计划二次插管，请确认", MessageBoxButton.YesNo, MessageBoxImage.Question, new Action<MessageBoxResult>((mbr) =>
                {
                    if (mbr == MessageBoxResult.OK)
                    {
                        _anesInputData.TRACHEA_6H = 1;
                    }
                    else
                    {
                        _anesInputData.TRACHEA_6H = null;
                    }
                }));
            }

            if (LIST_TEMP != null && LIST_TEMP.Count > 0)
            {
                foreach (MED_CHECKBOX_ITEM row in LIST_TEMP)
                {
                    switch (row.ITEM_NAME)
                    {
                        case "麻醉开始后取消":
                            _anesInputData.CANCELED_TYPE = row.ITEM_VALUE ? "1" : "0";
                            break;
                        case "椎管内麻醉后严重并发症":
                            _anesInputData.SPINAL_ANES_COMP = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "麻醉中发生意识障碍":
                            _anesInputData.CONS_DISTURBANCE = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "麻醉中因呜咽误吸引发呼吸梗阻":
                            _anesInputData.RES_TRACT_OBSTRUCE = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "非计划二次插管":
                            _anesInputData.TRACHEA_6H = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "非计划转入ICU":
                            _anesInputData.NO_PLAN_IN_ICU = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "中心静脉穿刺严重并发症":
                            _anesInputData.CENTRAL_VENOUS = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "麻醉中发生氧饱和度重度降低":
                            _anesInputData.OXYGEN_SATURATION = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "麻醉后新发昏迷":
                            _anesInputData.AFTER_ANES_COMA = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "麻醉期间发生严重过敏反应":
                            _anesInputData.ANES_ANAPHYLAXIS = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "全麻气管插管拔管后发生声音嘶哑":
                            _anesInputData.TRACHEA_HOARSE = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "麻醉中意外死亡":
                            _anesInputData.ANES_DEATH = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "其它非预期事件":
                            _anesInputData.OTHER_NOT_EXP = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "麻醉中接受400ml及以上输血治疗":
                            _anesInputData.BLOOD_EVENT = row.ITEM_VALUE ? 1 : 0;
                            break;
                        case "麻醉中接受400ml及以上自体血输注（包括自体全血及自体血红细胞）":
                            _anesInputData.BLOOD_EVENT_SELF = row.ITEM_VALUE ? 1 : 0;
                            break;
                        default:
                            break;
                    }
                }
            }
            _anesInputData.UNEXPECT_EVENT_REASON = UNEXPECT_EVENT_REASON;
            _anesInputData.ANES_EFFECT = ANES_EFFECT;
            _anesInputData.AFTER_ANALGESIA = AFTER_ANALGESIA;
            _anesInputData.ANALGESIA_METHOD = ANALGESIA_METHOD;
        }

        private bool SecondStep()
        {
            _masterRow.OUT_DATE_TIME = OUT_DATE_TIME.Value.AddSeconds(0 - OUT_DATE_TIME.Value.Second);
            switch (PLAN_WHEREABORTS)
            {
                case "40":
                    _masterRow.OPER_STATUS_CODE = (int)OperationStatus.TurnToPACU;
                    _masterRow.OUT_OPER_WHEREABORTS = (int)OperationStatus.TurnToPACU;
                    break;
                case "65":
                    _masterRow.OPER_STATUS_CODE = (int)OperationStatus.TurnToICU;
                    _masterRow.OUT_OPER_WHEREABORTS = (int)OperationStatus.TurnToICU;
                    break;
                case "60":
                    _masterRow.OPER_STATUS_CODE = (int)OperationStatus.TurnToSickRoom;
                    _masterRow.OUT_OPER_WHEREABORTS = (int)OperationStatus.TurnToSickRoom;
                    break;
                case "66":
                    _masterRow.OPER_STATUS_CODE = (int)OperationStatus.TurnToEmergency;
                    _masterRow.OUT_OPER_WHEREABORTS = (int)OperationStatus.TurnToEmergency;
                    break;
                case "67":
                    _masterRow.OPER_STATUS_CODE = (int)OperationStatus.LeftHospital;
                    _masterRow.OUT_OPER_WHEREABORTS = (int)OperationStatus.LeftHospital;
                    break;
                default:
                    _masterRow.OPER_STATUS_CODE = (int)OperationStatus.OutOperationRoom;
                    _masterRow.OUT_OPER_WHEREABORTS = (int)OperationStatus.OutOperationRoom;
                    break;
            }

            TransactionParamsters tp = TransactionParamsters.Create();
            tp.Append(_anesthesiaPlanRow).
               Append(_masterRow).
               Append(_anesInputData).
               Append(this.SaveShiftData());

            //更新手术间字典表，将患者的3个ID清空
            MED_OPERATING_ROOM operRoom = MED_OPERATING_ROOM.Where(d => d.BED_TYPE == "0" && d.ROOM_NO == ExtendAppContext.Current.OperRoomNo).First();
            operRoom.PATIENT_ID = "";
            operRoom.VISIT_ID = null;
            operRoom.OPER_ID = null;
            operRoom.ModelStatus = ModelStatus.Modeified;
            tp.Append(operRoom);

            if (MONITORDICT != null && MONITORDICT.Count > 0)
            {
                foreach (MED_MONITOR_DICT row in MONITORDICT)
                {
                    row.PATIENT_ID = "";
                    row.VISIT_ID = null;
                    row.OPER_ID = null;
                    row.ModelStatus = ModelStatus.Modeified;
                }

                tp.Append(MONITORDICT);
            }

            //modified by joysola on 2018-3-30 加入“是否更新排班程序状态”的判断
            if (ApplicationConfiguration.IsUpdateScheduleStatus)
            {
                // 出手术室时将排班表里的状态置为4
                MED_OPERATION_SCHEDULE scheduled = AnesInfoService.ClientInstance.GetOperSchedule(_masterRow.PATIENT_ID,
                                                                                                  _masterRow.VISIT_ID,
                                                                                                  _masterRow.OPER_ID);
                if (scheduled != null)
                {
                    scheduled.OPER_STATUS_CODE = 4;
                    tp.Append(scheduled);
                }
            }
            //modified end on 2018-3-30
            return CommonService.ClientInstance.UpdateByTransaction(tp.ToString());
        }

        /// <summary>
        /// 保存交班表（用于工作量计算）
        /// </summary>
        /// <returns></returns>
        private List<MED_OPERATION_SHIFT_RECORD> SaveShiftData()
        {
            List<MED_OPERATION_SHIFT_RECORD> shiftRecordList = AnesInfoService.ClientInstance.
                GetOperShiftRecord(_masterRow.PATIENT_ID, _masterRow.VISIT_ID, _masterRow.OPER_ID);
            if (shiftRecordList.Count > 0)
            {
                foreach (var item in shiftRecordList)
                {
                    if (!item.END_DATE_TIME.HasValue)
                    {
                        item.END_DATE_TIME = _masterRow.OUT_DATE_TIME;
                    }
                }
            }
            else
            {
                string[] DutyList = new string[] { "第一台上护士", "第二台上护士", "第三台上护士",
                    "第四台上护士", "第一供应护士", "第二供应护士", "第三供应护士", "第四供应护士",
                    "主麻", "麻醉助手1", "麻醉助手2", "麻醉助手3", "麻醉助手4",
                    "术者", "第一手术助理", "第二手术助理", "第三手术助理", "第四手术助理" , "灌注医生", "灌注医生助手1"};

                foreach (var duty in DutyList)
                {
                    MED_OPERATION_SHIFT_RECORD record = new MED_OPERATION_SHIFT_RECORD();
                    record.PATIENT_ID = _masterRow.PATIENT_ID;
                    record.VISIT_ID = _masterRow.VISIT_ID;
                    record.OPER_ID = _masterRow.OPER_ID;
                    record.ModelStatus = ModelStatus.Add;
                    record.SHIFT_DUTY = duty;
                    record.SHIFT_TIMES = 1;
                    record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                    record.END_DATE_TIME = _masterRow.OUT_DATE_TIME;
                    switch (duty)
                    {
                        case "第一台上护士":
                            record.PERSON = _masterRow.FIRST_OPER_NURSE;
                            break;
                        case "第二台上护士":
                            record.PERSON = _masterRow.SECOND_OPER_NURSE;
                            break;
                        case "第三台上护士":
                            record.PERSON = _masterRow.THIRD_OPER_NURSE;
                            break;
                        case "第四台上护士":
                            record.PERSON = _masterRow.FOURTH_OPER_NURSE;
                            break;
                        case "第一供应护士":
                            record.PERSON = _masterRow.FIRST_SUPPLY_NURSE;
                            break;
                        case "第二供应护士":
                            record.PERSON = _masterRow.SECOND_SUPPLY_NURSE;
                            break;
                        case "第三供应护士":
                            record.PERSON = _masterRow.THIRD_SUPPLY_NURSE;
                            break;
                        case "第四供应护士":
                            record.PERSON = _masterRow.FOURTH_SUPPLY_NURSE;
                            break;
                        case "主麻":
                            record.PERSON = _masterRow.ANES_DOCTOR;
                            break;
                        case "麻醉助手1":
                            record.PERSON = _masterRow.FIRST_ANES_ASSISTANT;
                            break;
                        case "麻醉助手2":
                            record.PERSON = _masterRow.SECOND_ANES_ASSISTANT;
                            break;
                        case "麻醉助手3":
                            record.PERSON = _masterRow.THIRD_ANES_ASSISTANT;
                            break;
                        case "麻醉助手4":
                            record.PERSON = _masterRow.FOURTH_ANES_ASSISTANT;
                            break;
                        case "灌注医生":
                            record.PERSON = _masterRow.CPB_DOCTOR;
                            break;
                        case "灌注医生助手1":
                            record.PERSON = _masterRow.FIRST_CPB_ASSISTANT;
                            break;
                        case "术者":
                            record.PERSON = _masterRow.SURGEON;
                            break;
                        case "第一手术助理":
                            record.PERSON = _masterRow.FIRST_OPER_ASSISTANT;
                            break;
                        case "第二手术助理":
                            record.PERSON = _masterRow.SECOND_OPER_ASSISTANT;
                            break;
                        case "第三手术助理":
                            record.PERSON = _masterRow.THIRD_OPER_ASSISTANT;
                            break;
                        case "第四手术助理":
                            record.PERSON = _masterRow.FOURTH_OPER_ASSISTANT;
                            break;
                        default:
                            break;
                    }
                    if (string.IsNullOrEmpty(record.PERSON))
                    {
                        continue;
                    }
                    else
                    {
                        shiftRecordList.Add(record);
                    }
                }
            }

            return shiftRecordList;
        }

        /// <summary>
        /// 重置
        /// </summary>
        private void ResetData()
        {
            if (PATINFOCHECKBOOL)
            {
                LoadData();
            }
            else
            {
                PATINFOCHECK = Visibility.Visible;
                OUTROOMTIMECHECK = Visibility.Collapsed;
                PATINFOCHECKBOOL = true;
                OUTROOMTIMECHECKBOOL = false;
                leftBtnText = "重 置";
                rightBtnText = "下一步";
            }
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
                    if (_PATINFOCHECKBOOL)
                        FirstStep();
                    else
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

            //出室界面关闭后，关闭术中页面，并刷新今日列表
            if (saveResult == SaveResult.CancelMessageBox)
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);
        }
        #endregion

        /// <summary>
        /// 出手术室结束所有持续事件
        /// </summary>
        /// <param name="endTime"></param>
        /// <returns></returns>
        private bool StopAnesEvent(DateTime endTime)
        {
            List<MED_ANESTHESIA_EVENT> allAnesEvent = AnesInfoService.ClientInstance.GetAnesthesiaEventList(
               ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
               ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
               ExtendAppContext.Current.PatientInformationExtend.OPER_ID)
               .Where(x => x.DURATIVE_INDICATOR == 1 && !x.END_TIME.HasValue).ToList();

            foreach (var item in allAnesEvent)
            {
                item.END_TIME = endTime;
            }

            return AnesInfoService.ClientInstance.UpadteAnesthesiaEvent(allAnesEvent);
        }
    }
}
