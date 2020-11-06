//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationInformationViewModel.cs
//功能描述(Description)：    术中页面页头信息
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:49:12
//R1:
//    修改作者:
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
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    /// <summary>
    /// 手术信息ViewModel
    /// </summary>
    public class OperationInformationViewModel : BaseViewModel
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationInformationViewModel()
        {
            // 载入字典数据
            LoadDictData();
            //手动调用LoadData()函数，该窗口是Windiws无法通过基类自动调用 wwj
            LoadData();
            // 注册消息
            this.RegisterMessage();
        }

        #region 界面控件字典绑定
        private List<MED_OPERATING_ROOM> _medOperationRoomInOper;                  // 正在手术手术间字典
        #endregion

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
        private string _DEPT_CODE;                                                 // 科室代码
        private string _DEPT_NAME;                                                 // 科室名称
        private string _DIAG_BEFORE_OPERATION;                                     // 术前诊断
        private Nullable<DateTime> _IN_DATE_TIME;                                     // 手术时间
        private string _OPERATION_NAME;                                            // 拟施手术
        private string _OPER_SCALE;                                                // 手术等级
        private string _OPER_POSITION;                                             // 手术体位
        private Nullable<Int32> _EMERGENCY_IND;                                    // 急诊择期
        private Visibility emergVisible = Visibility.Collapsed;
        private Nullable<Int32> _ISOLATION_IND;                                    // 隔离标志
        private Visibility isolaVisible = Visibility.Collapsed;
        private Nullable<Int32> _RADIATE_IND;                                      // 放射标志
        private Visibility radiaVisible = Visibility.Collapsed;
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
        private string _BLOOD_TYPE;                                                // 血型

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
        /// 手术时间
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
                string deptName = _DEPT_CODE;
                MED_DEPT_DICT dept = DEPT_DICT.Where(d => d.DEPT_CODE.Equals(_DEPT_CODE)).FirstOrDefault();
                if (dept != null)
                {
                    deptName = dept.DEPT_NAME;
                }
                return deptName;
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
        public string OPERATION_NAME
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

        public Visibility EmergVisible
        {
            get
            {
                return emergVisible;
            }
            set
            {
                emergVisible = value;
                RaisePropertyChanged("EmergVisible");
            }
        }

        private BitmapImage asaPath;
        /// <summary>
        /// 根据ASA等级显示不同的图片
        /// </summary>
        public BitmapImage AsaPath
        {
            get
            {
                return this.asaPath;
            }
            set
            {
                this.asaPath = value;
                RaisePropertyChanged("AsaPath");
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
        public Visibility IsolaVisible
        {
            get
            {
                return isolaVisible;
            }
            set
            {
                isolaVisible = value;
                RaisePropertyChanged("IsolaVisible");
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
        public Visibility RadiaVisible
        {
            get
            {
                return radiaVisible;
            }
            set
            {
                radiaVisible = value;
                RaisePropertyChanged("RadiaVisible");
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
        /// 正在手术手术间
        /// </summary>
        public List<MED_OPERATING_ROOM> LIST_OPER
        {
            get
            {
                return _medOperationRoomInOper;
            }
            set
            {
                this._medOperationRoomInOper = value;
                RaisePropertyChanged("LIST_OPER");
            }
        }

        /// <summary>
        /// 手术间字典
        /// </summary>
        public List<MED_OPERATING_ROOM> LIST_OPER_ALL
        {
            get
            {
                return MED_OPERATING_ROOM;
            }
            set
            {
                this._medOperationRoomInOper = value;
                RaisePropertyChanged("LIST_OPER_ALL");
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
        /// 血型
        /// </summary>
        public string BLOOD_TYPE
        {
            get
            {
                return _BLOOD_TYPE;
            }
            set
            {
                this._BLOOD_TYPE = value;
                RaisePropertyChanged("BLOOD_TYPE");
            }
        }

        #endregion

        #region 数据源
        MED_OPERATION_MASTER _masterRow;
        MED_PATS_IN_HOSPITAL _patsInHospitalRow;
        MED_PAT_MASTER_INDEX _patMasterIndexRow;
        MED_ANESTHESIA_PLAN _anesthesiaPlanRow;
        List<MED_OPERATION_NAME> _listOperName;            // 病人的手术名称列表
        #endregion

        #region 方法

        /// <summary>
        /// 注册刷新消息
        /// </summary>

        private void RegisterMessage()
        {
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshInOperationInformation, mes =>
            {
                this.LoadData();
            });
        }

        /// <summary>
        /// 载入患者信息
        /// </summary>
        public override void LoadData()
        {
            string patientID = "";
            int visitID = 1;
            int operID = 1;
            if (ExtendAppContext.Current.PatientInformationExtend != null)
            {
                patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            }
            _masterRow = AnesInfoService.ClientInstance.GetOperationMaster(patientID, visitID, operID);

            if (_masterRow != null)
            {
                _patsInHospitalRow = AnesInfoService.ClientInstance.GetPatsInHospitalListByID(patientID).OrderByDescending(c => c.VISIT_ID).ToList().First();
                _patMasterIndexRow = AnesInfoService.ClientInstance.GetPatMasterIndex(patientID).First();
                _anesthesiaPlanRow = AnesInfoService.ClientInstance.GetAnesthesiaPlan(patientID, visitID, operID).First();
                _listOperName = CareDocService.ClientInstance.GetOperNameList(patientID, visitID, operID);
                OPER_ROOM_NO = _masterRow.OPER_ROOM_NO;
                SEQUENCE = _masterRow.SEQUENCE;
                PATIENT_ID = _masterRow.PATIENT_ID;
                INP_NO = _patsInHospitalRow.INP_NO;
                NAME = _patMasterIndexRow.NAME;
                SEX = _patMasterIndexRow.SEX;
                DATE_OF_BIRTH = _patMasterIndexRow.DATE_OF_BIRTH;
                BED_NO = _masterRow.BED_NO;
                DEPT_CODE = _masterRow.DEPT_CODE;
                DEPT_NAME = "";
                IN_DATE_TIME = _masterRow.IN_DATE_TIME;
                DIAG_BEFORE_OPERATION = _masterRow.DIAG_BEFORE_OPERATION;
                OPERATION_NAME = _masterRow.OPERATION_NAME;
                OPER_SCALE = _masterRow.OPER_SCALE;
                OPER_POSITION = _masterRow.OPER_POSITION;
                EMERGENCY_IND = _masterRow.EMERGENCY_IND;
                EmergVisible = EMERGENCY_IND == 1 ? Visibility.Visible : Visibility.Collapsed;
                ISOLATION_IND = _masterRow.ISOLATION_IND;
                IsolaVisible = ISOLATION_IND == 2 ? Visibility.Visible : Visibility.Collapsed;
                RADIATE_IND = _masterRow.RADIATE_IND;
                RadiaVisible = RADIATE_IND == 2 ? Visibility.Visible : Visibility.Collapsed;

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
                AGE = DateDiff.CalAge((DateTime)_patMasterIndexRow.DATE_OF_BIRTH, _masterRow.SCHEDULED_DATE_TIME.Value);

                // 当前仅考虑Ⅰ,Ⅱ,Ⅲ,Ⅳ,Ⅴ
                string strPath = "MedicalSystem.AnesWorkStation.View;component/Images/ASA_None.png";

                switch (this.ASA_GRADE)
                {
                    case "Ⅰ":
                    case "Ⅰ级":
                    case "一级":
                    case "1级":
                        strPath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA1.png";
                        break;
                    case "Ⅱ":
                    case "Ⅱ级":
                    case "二级":
                    case "2级":
                        strPath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA2.png";
                        break;
                    case "Ⅲ":
                    case "Ⅲ级":
                    case "三级":
                    case "3级":
                        strPath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA3.png";
                        break;
                    case "Ⅳ":
                    case "Ⅳ级":
                    case "四级":
                    case "4级":
                        strPath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA4.png";
                        break;
                    case "Ⅴ":
                    case "Ⅴ级":
                    case "五级":
                    case "5级":
                        strPath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA5.png";
                        break;
                    case "Ⅵ":
                    case "Ⅵ级":
                    case "六级":
                    case "6级":
                        strPath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA6.png";
                        break;
                    default:
                        strPath = "MedicalSystem.AnesWorkStation.View;component/Images/ASA_None.png";
                        break;
                }

                this.AsaPath = new BitmapImage(new Uri(strPath, UriKind.RelativeOrAbsolute));
            }
        }


        #endregion

        #region 命令

        /// <summary>
        /// 加载手术室列表
        /// </summary>
        public ICommand LoadOperRooms
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MED_OPERATING_ROOM = DictService.ClientInstance.GetOperatingRoomListByType("0", ExtendAppContext.Current.OperDeptCode);
                    LIST_OPER = MED_OPERATING_ROOM.Where(d => d.PATIENT_ID != null && d.VISIT_ID != null && d.OPER_ID != null).ToList();
                });
            }
        }

        /// <summary>
        /// 打开用户手术信息
        /// </summary>
        public ICommand ShowPatientInfoCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var message = new ShowContentWindowMessage("OperationInformationControl", MED_CONSTANT.OPERATION_INFOMATION);
                    message.Height = MED_CONSTANT.POPUP_WINDOW_HEIGHT;
                    message.Width = MED_CONSTANT.POPUP_WINDOW_WIDTH;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                });
            }
        }
        /// <summary>
        /// 切换手术间信息
        /// </summary>
        public ICommand ClickOperRoom
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    ExtendAppContext.Current.PatientInformationExtend = PatInfoService.ClientInstance.GetCurPatientInfo(ExtendAppContext.Current.OperDeptCode, key);
                    LoadData();
                    if (ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO == ExtendAppContext.Current.OperRoomNo)
                        ExtendAppContext.Current.IsModify = true;
                    else
                    {
                        if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.OutOperationRoom)
                        {
                            ExtendAppContext.Current.IsModify = true;
                        }
                        else
                        {
                            //ExtendAppContext.Current.IsModify = false;
                            if (!ExtendAppContext.Current.LoginUser.isMDSD)// 切换手术间的时候，再次判断是否是主麻、副麻医生，是的话允许修改
                            {
                                if (ExtendAppContext.Current.PatientInformationExtend.ANES_DOCTOR == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.ANES_DOCTOR == ExtendAppContext.Current.LoginUser.USER_NAME ||
                                    ExtendAppContext.Current.PatientInformationExtend.FIRST_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.FIRST_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_NAME ||
                                    ExtendAppContext.Current.PatientInformationExtend.SECOND_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.SECOND_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_NAME ||
                                    ExtendAppContext.Current.PatientInformationExtend.THIRD_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.THIRD_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_NAME ||
                                    ExtendAppContext.Current.PatientInformationExtend.FOURTH_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.FOURTH_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_NAME)
                                {
                                    ExtendAppContext.Current.IsModify = true;
                                }
                                else
                                {
                                    ExtendAppContext.Current.IsModify = false;
                                }
                            }
                            else
                                ExtendAppContext.Current.IsModify = true;
                        }
                    }
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshInOperationWindow);
                });
            }
        }
        #endregion
    }
}
