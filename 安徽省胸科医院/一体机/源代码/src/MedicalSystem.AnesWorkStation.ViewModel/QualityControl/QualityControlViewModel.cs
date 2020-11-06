using GalaSoft.MvvmLight.CommandWpf;
using MedicalSystem.Anes.Framework.Utilities;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.QualityControl
{
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //文件名称(File Name)：      QualityControlViewModel.cs
    //功能描述(Description)：    麻醉质控ViewModel
    //数据表(Tables)：		      MED_ANESTHESIA_INPUT_DATA,MED_OPERATION_MASTER
    //                                    MED_PATS_IN_HOSPITAL,MED_PAT_MASTER_INDEX
    //作者(Author)：            MDSD
    //日期(Create Date)：        2017/12/26 14:27:59
    //R1:
    //    修改作者:
    //    修改日期:
    //    修改理由:
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝ 
    public class QualityControlViewModel : BaseViewModel
    {
        public QualityControlViewModel()
        {
        }
        #region 界面控件字段绑定
        private string _OPER_ROOM_NO;                                              // 手术间号
        private Nullable<Int32> _SEQUENCE;                                         // 台次
        private string _PATIENT_ID;                                                // 患者ID
        private string _INP_NO;                                                    // 住院号
        private string _NAME;                                                      // 姓名
        private string _SEX;                                                       // 性别
        private Nullable<DateTime> _DATE_OF_BIRTH;                                 // 出生日期
        private string _AGE;                                                          // 年龄
        private string _BED_NO;                                                    // 床号
        private bool _CANCELED_TYPE;                                         //麻醉开始后取消
        private bool _SPINAL_ANES_COMP;                                         //椎管内麻醉后严重并发症
        private bool _CONS_DISTURBANCE;                                         //麻醉中发生意识障碍
        private bool _RES_TRACT_OBSTRUCE;                                         //麻醉中因呜咽误吸引发呼吸梗阻
        private bool _TRACHEA_6H;                                         //非计划二次插管
        private bool _CENTRAL_VENOUS;                                         //中心静脉穿刺严重并发症
        private bool _OXYGEN_SATURATION;                                         //麻醉中发生氧饱和度重度降低
        private bool _AFTER_ANES_COMA;                                         //麻醉后新发昏迷
        private bool _ANES_ANAPHYLAXIS;                                         //麻醉期间发生严重过敏反应
        private bool _TRACHEA_HOARSE;                                         //全麻气管插管拔管后发生声音嘶哑
        private bool _ANES_DEATH;                                         //麻醉中意外死亡
        private bool _PACU_3H;                                         //PACU转出延迟(超过3小时)
        private bool _PACU_TEMPERATURE;                                         //PACU入室低体温(35.5)
        private bool _NO_PLAN_IN_ICU;                                         //非计划转入ICU
        private bool _BLOOD_EVENT;                                         //术中自体血输入
        private bool _OPER_EVENT;                                         //手术因素
        private bool _ANES_EVENT;                                         //麻醉因素
        private bool _PAT_INDETIFICATION;                                         //患者因素
        private bool _OTHER_EVENT;                                         //其他因素

        private bool _TRACHEA_REMOVE;                                          // 术后气管插管拔除患者；1-是；0-否
        private bool _ANES_START_24H_DEATH;                                    // 麻醉开始后24小时内死亡（死亡原因）；1-是；0-否
        private bool _ANES_START_24H_STOP;                                     // 麻醉开始后24小时内心跳骤停患者（死亡原因）；1-是；0-否

        private string _UNEXPECT_EVENT_REASON;                                         //发生原因
        private string _PREVENT_STEP;                                         //预防措施 
        private string _DEPT_NAME;                                                 // 科室名称
        private string _EVENT_COURSE;                                                 // 事件发生经过


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
        /// 麻醉开始后取消
        /// </summary>
        public bool CANCELED_TYPE
        {
            get
            {
                return _CANCELED_TYPE;
            }
            set
            {
                this._CANCELED_TYPE = value;
                RaisePropertyChanged("CANCELED_TYPE");
            }
        }

        /// <summary>
        /// 椎管内麻醉后严重并发症
        /// </summary>
        public bool SPINAL_ANES_COMP
        {
            get
            {
                return _SPINAL_ANES_COMP;
            }
            set
            {
                this._SPINAL_ANES_COMP = value;
                RaisePropertyChanged("SPINAL_ANES_COMP");
            }
        }

        /// <summary>
        /// 麻醉中发生意识障碍
        /// </summary>
        public bool CONS_DISTURBANCE
        {
            get
            {
                return _CONS_DISTURBANCE;
            }
            set
            {
                this._CONS_DISTURBANCE = value;
                RaisePropertyChanged("CONS_DISTURBANCE");
            }
        }
        /// <summary>
        /// 麻醉中因呜咽误吸引发呼吸梗阻
        /// </summary>
        public bool RES_TRACT_OBSTRUCE
        {
            get
            {
                return _RES_TRACT_OBSTRUCE;
            }
            set
            {
                this._RES_TRACT_OBSTRUCE = value;
                RaisePropertyChanged("RES_TRACT_OBSTRUCE");
            }
        }

        /// <summary>
        /// 非计划二次插管
        /// </summary>
        public bool TRACHEA_6H
        {
            get
            {
                return _TRACHEA_6H;
            }
            set
            {
                this._TRACHEA_6H = value;
                RaisePropertyChanged("TRACHEA_6H");
            }
        }
        /// <summary>
        /// 中心静脉穿刺严重并发症
        /// </summary>
        public bool CENTRAL_VENOUS
        {
            get
            {
                return _CENTRAL_VENOUS;
            }
            set
            {
                this._CENTRAL_VENOUS = value;
                RaisePropertyChanged("CENTRAL_VENOUS ");
            }
        }

        /// <summary>
        /// 麻醉中发生氧饱和度重度降低
        /// </summary>
        public bool OXYGEN_SATURATION
        {
            get
            {
                return _OXYGEN_SATURATION;
            }
            set
            {
                this._OXYGEN_SATURATION = value;
                RaisePropertyChanged("OXYGEN_SATURATION");
            }
        }
        /// <summary>
        /// 麻醉后新发昏迷
        /// </summary>
        public bool AFTER_ANES_COMA
        {
            get
            {
                return _AFTER_ANES_COMA;
            }
            set
            {
                this._AFTER_ANES_COMA = value;
                RaisePropertyChanged("AFTER_ANES_COMA");
            }
        }
        /// <summary>
        /// 麻醉期间发生严重过敏反应
        /// </summary>
        public bool ANES_ANAPHYLAXIS
        {
            get
            {
                return _ANES_ANAPHYLAXIS;
            }
            set
            {
                this._ANES_ANAPHYLAXIS = value;
                RaisePropertyChanged("ANES_ANAPHYLAXIS");
            }
        }


        /// <summary>
        /// 全麻气管插管拔管后发生声音嘶哑
        /// </summary>
        public bool TRACHEA_HOARSE
        {
            get
            {
                return _TRACHEA_HOARSE;
            }
            set
            {
                this._TRACHEA_HOARSE = value;
                RaisePropertyChanged("TRACHEA_HOARSE");
            }
        }
        /// <summary>
        /// 麻醉中意外死亡
        /// </summary>
        public bool ANES_DEATH
        {
            get
            {
                return _ANES_DEATH;
            }
            set
            {
                this._ANES_DEATH = value;
                RaisePropertyChanged("ANES_DEATH");
            }
        }
        /// <summary>
        /// PACU转出延迟(超过3小时) 
        /// </summary>
        public bool PACU_3H
        {
            get
            {
                return _PACU_3H;
            }
            set
            {
                this._PACU_3H = value;
                RaisePropertyChanged("PACU_3H");
            }
        }


        /// <summary>
        /// PACU入室低体温(35.5) 
        /// </summary>
        public bool PACU_TEMPERATURE
        {
            get
            {
                return _PACU_TEMPERATURE;
            }
            set
            {
                this._PACU_TEMPERATURE = value;
                RaisePropertyChanged("PACU_TEMPERATURE");
            }
        }
        /// <summary>
        /// 非计划转入ICU 
        /// </summary>
        public bool NO_PLAN_IN_ICU
        {
            get
            {
                return _NO_PLAN_IN_ICU;
            }
            set
            {
                this._NO_PLAN_IN_ICU = value;
                RaisePropertyChanged("NO_PLAN_IN_ICU");
            }
        }


        /// <summary>
        /// 术中自体血输入
        /// </summary>
        public bool BLOOD_EVENT
        {
            get
            {
                return _BLOOD_EVENT;
            }
            set
            {
                this._BLOOD_EVENT = value;
                RaisePropertyChanged("BLOOD_EVENT");
            }
        }

        /// <summary>
        /// 麻醉开始后24小时内心跳骤停患者（死亡原因）；1-是；0-否
        /// </summary>
        public bool ANES_START_24H_STOP
        {
            get { return this._ANES_START_24H_STOP; }
            set
            {
                this._ANES_START_24H_STOP = value;
                this.RaisePropertyChanged("ANES_START_24H_STOP");
            }
        }

        /// <summary>
        /// 麻醉开始后24小时内死亡（死亡原因）；1-是；0-否
        /// </summary>
        public bool ANES_START_24H_DEATH
        {
            get { return this._ANES_START_24H_DEATH; }
            set
            {
                this._ANES_START_24H_DEATH = value;
                this.RaisePropertyChanged("ANES_START_24H_DEATH");
            }
        }

        /// <summary>
        /// 术后气管插管拔除患者；1-是；0-否
        /// </summary>
        public bool TRACHEA_REMOVE
        {
            get { return this._TRACHEA_REMOVE; }
            set
            {
                this._TRACHEA_REMOVE = value;
                this.RaisePropertyChanged("TRACHEA_REMOVE");
            }
        }

        /// <summary>
        /// 手术因素
        /// </summary>
        public bool OPER_EVENT
        {
            get
            {
                return _OPER_EVENT;
            }
            set
            {
                this._OPER_EVENT = value;
                RaisePropertyChanged("OPER_EVENT");
            }
        }

        /// <summary>
        /// 麻醉因素
        /// </summary>
        public bool ANES_EVENT
        {
            get
            {
                return _ANES_EVENT;
            }
            set
            {
                this._ANES_EVENT = value;
                RaisePropertyChanged("ANES_EVENT");
            }
        }
        /// <summary>
        /// 患者因素
        /// </summary>
        public bool PAT_INDETIFICATION
        {
            get
            {
                return _PAT_INDETIFICATION;
            }
            set
            {
                this._PAT_INDETIFICATION = value;
                RaisePropertyChanged("PAT_INDETIFICATION");
            }
        }

        /// <summary>
        /// 患者因素
        /// </summary>
        public bool OTHER_EVENT
        {
            get
            {
                return _OTHER_EVENT;
            }
            set
            {
                this._OTHER_EVENT = value;
                RaisePropertyChanged("OTHER_EVENT");
            }
        }

        /// <summary>
        /// 发生原因
        /// </summary>
        public string UNEXPECT_EVENT_REASON
        {
            get
            {
                return _UNEXPECT_EVENT_REASON;
            }
            set
            {
                this._UNEXPECT_EVENT_REASON = value;
                RaisePropertyChanged("UNEXPECT_EVENT_REASON");
            }
        }
        /// <summary>
        /// 预防措施
        /// </summary>
        public string PREVENT_STEP
        {
            get
            {
                return _PREVENT_STEP;
            }
            set
            {
                this._PREVENT_STEP = value;
                RaisePropertyChanged("PREVENT_STEP");
            }
        }
        public string EVENT_COURSE
        {
            get
            {
                return _EVENT_COURSE;
            }
            set
            {
                this._EVENT_COURSE = value;
                RaisePropertyChanged("EVENT_COURSE");
            }
        }

        #endregion
        #region 数据源
        MED_OPERATION_MASTER _masterRow;
        MED_PATS_IN_HOSPITAL _patsInHospitalRow;
        MED_PAT_MASTER_INDEX _patMasterIndexRow;
        MED_ANESTHESIA_INPUT_DATA _anesInputData;
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
                OPER_ROOM_NO = _masterRow.OPER_ROOM_NO;
                SEQUENCE = _masterRow.SEQUENCE;
                PATIENT_ID = _masterRow.PATIENT_ID;
                INP_NO = _patsInHospitalRow.INP_NO;
                NAME = _patMasterIndexRow.NAME;
                SEX = _patMasterIndexRow.SEX;
                DATE_OF_BIRTH = _patMasterIndexRow.DATE_OF_BIRTH;
                BED_NO = _masterRow.BED_NO;
                DEPT_NAME = _masterRow.DEPT_NAME;
                AGE = DateDiff.CalAge((DateTime)_patMasterIndexRow.DATE_OF_BIRTH, _masterRow.SCHEDULED_DATE_TIME.Value);
                CANCELED_TYPE = _anesInputData.CANCELED_TYPE == "1" ? true : false;
                SPINAL_ANES_COMP = _anesInputData.SPINAL_ANES_COMP == 1 ? true : false;
                CONS_DISTURBANCE = _anesInputData.CONS_DISTURBANCE == 1 ? true : false;
                RES_TRACT_OBSTRUCE = _anesInputData.RES_TRACT_OBSTRUCE == 1 ? true : false;
                TRACHEA_6H = _anesInputData.TRACHEA_6H == 1 ? true : false;
                CENTRAL_VENOUS = _anesInputData.CENTRAL_VENOUS == 1 ? true : false;
                OXYGEN_SATURATION = _anesInputData.OXYGEN_SATURATION == 1 ? true : false;
                AFTER_ANES_COMA = _anesInputData.AFTER_ANES_COMA == 1 ? true : false;
                ANES_ANAPHYLAXIS = _anesInputData.ANES_ANAPHYLAXIS == 1 ? true : false;
                TRACHEA_HOARSE = _anesInputData.TRACHEA_HOARSE == 1 ? true : false;
                ANES_DEATH = _anesInputData.ANES_DEATH == 1 ? true : false;
                PACU_3H = _anesInputData.PACU_3H == "1" ? true : false;
                PACU_TEMPERATURE = _anesInputData.PACU_TEMPERATURE == 1 ? true : false;
                NO_PLAN_IN_ICU = _anesInputData.NO_PLAN_IN_ICU == 1 ? true : false;
                BLOOD_EVENT = _anesInputData.BLOOD_EVENT == 1 ? true : false;
                OPER_EVENT = _anesInputData.OPER_EVENT == 1 ? true : false;
                ANES_EVENT = _anesInputData.ANES_EVENT == 1 ? true : false;
                PAT_INDETIFICATION = _anesInputData.PAT_INDETIFICATION == 1 ? true : false;
                OTHER_EVENT = _anesInputData.OTHER_EVENT == 1 ? true : false;
                this.TRACHEA_REMOVE = _anesInputData.TRACHEA_REMOVE == 1 ? true : false;
                this.ANES_START_24H_DEATH = _anesInputData.ANES_START_24H_DEATH == 1 ? true : false;
                this.ANES_START_24H_STOP = _anesInputData.ANES_START_24H_STOP == 1 ? true : false;
                UNEXPECT_EVENT_REASON = _anesInputData.UNEXPECT_EVENT_REASON;
                PREVENT_STEP = _anesInputData.PREVENT_STEP;
                EVENT_COURSE = _anesInputData.EVENT_COURSE;
            }
        }

        /// <summary>
        /// 保存患者信息
        /// </summary>
        protected override SaveResult SaveData()
        {
            SaveResult saveResult = SaveResult.Fail;
            bool result = true;

            if (_anesInputData != null)
            {
                _anesInputData.CANCELED_TYPE = CANCELED_TYPE ? "1" : null;
                _anesInputData.SPINAL_ANES_COMP = SPINAL_ANES_COMP ? 1 : 0;
                _anesInputData.CONS_DISTURBANCE = CONS_DISTURBANCE ? 1 : 0;
                _anesInputData.RES_TRACT_OBSTRUCE = RES_TRACT_OBSTRUCE ? 1 : 0;
                _anesInputData.TRACHEA_6H = TRACHEA_6H ? 1 : 0;
                _anesInputData.CENTRAL_VENOUS = CENTRAL_VENOUS ? 1 : 0;
                _anesInputData.OXYGEN_SATURATION = OXYGEN_SATURATION ? 1 : 0;
                _anesInputData.AFTER_ANES_COMA = AFTER_ANES_COMA ? 1 : 0;
                _anesInputData.ANES_ANAPHYLAXIS = ANES_ANAPHYLAXIS ? 1 : 0;
                _anesInputData.TRACHEA_HOARSE = TRACHEA_HOARSE ? 1 : 0;
                _anesInputData.ANES_DEATH = ANES_DEATH ? 1 : 0;
                _anesInputData.PACU_3H = PACU_3H ? "1" : null;
                _anesInputData.PACU_TEMPERATURE = PACU_TEMPERATURE ? 1 : 0;
                _anesInputData.NO_PLAN_IN_ICU = NO_PLAN_IN_ICU ? 1 : 0;
                _anesInputData.BLOOD_EVENT = BLOOD_EVENT ? 1 : 0;
                _anesInputData.OPER_EVENT = OPER_EVENT ? 1 : 0;
                _anesInputData.ANES_EVENT = ANES_EVENT ? 1 : 0;
                _anesInputData.PAT_INDETIFICATION = PAT_INDETIFICATION ? 1 : 0;
                _anesInputData.OTHER_EVENT = OTHER_EVENT ? 1 : 0;
                _anesInputData.UNEXPECT_EVENT_REASON = UNEXPECT_EVENT_REASON;

                _anesInputData.TRACHEA_REMOVE = this.TRACHEA_REMOVE ? 1 : 0;
                _anesInputData.ANES_START_24H_DEATH = this.ANES_START_24H_DEATH ? 1 : 0;
                _anesInputData.ANES_START_24H_STOP = this.ANES_START_24H_STOP ? 1 : 0;

                _anesInputData.PREVENT_STEP = PREVENT_STEP;
                _anesInputData.EVENT_COURSE = EVENT_COURSE;
                result = CareDocService.ClientInstance.SaveAnesInputData(_anesInputData);
            }

            if (result)
                saveResult = SaveResult.Success;


            return saveResult;
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
                    //SaveData();

                    PublicKeyBoardMessage(KeyCode.AppCode.Save);
                });
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        public ICommand ColseCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    this.CloseContentWindow();
                });
            }
        }
        #endregion
    }
}
