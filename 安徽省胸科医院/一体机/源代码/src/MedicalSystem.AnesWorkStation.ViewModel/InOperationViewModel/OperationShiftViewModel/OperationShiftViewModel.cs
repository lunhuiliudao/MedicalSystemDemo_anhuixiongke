//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationShiftViewModel.cs
//功能描述(Description)：    手术交班
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 14:49:33
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.InOperationModel.OperationShiftModel;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationShiftViewModel
{
    public class OperationShiftViewModel : BaseViewModel
    {
        /// <summary>
        /// 左侧交班类型 ；麻醉交班、手术交班、护士交班
        /// </summary>
        private List<OperationShiftModel> _leftType;
        public List<OperationShiftModel> LeftType
        {
            get { return _leftType; }
            set
            {
                _leftType = value;
                RaisePropertyChanged("LeftType");
            }
        }

        private List<MED_OPERATION_SHIFT_RECORD> shiftRecordList;
        /// <summary>
        /// 交班表
        /// </summary>
        private List<MED_OPERATION_SHIFT_RECORD> _showRecordList;

        public List<MED_OPERATION_SHIFT_RECORD> ShowRecordList
        {
            get { return _showRecordList; }
            set
            {
                _showRecordList = value;
                RaisePropertyChanged("ShowRecordList");
            }
        }
        /// <summary>
        /// 人员字典表
        /// </summary>
        private List<MED_HIS_USERS> _medHisUsersList;
        public List<MED_HIS_USERS> MED_USERS_LIST
        {
            get
            {
                return this._medHisUsersList;
            }
            set
            {
                this._medHisUsersList = value;
                RaisePropertyChanged("MED_USERS_LIST");
            }
        }
        /// <summary>
        /// 护士交班数据
        /// </summary>
        private List<MED_OPERATION_SHIFT_RECORD> _NurseRecord;

        public List<MED_OPERATION_SHIFT_RECORD> NurseRecord
        {
            get { return _NurseRecord; }
            set
            {
                _NurseRecord = value;
                RaisePropertyChanged("NurseRecord");
            }
        }
        /// <summary>
        /// 医生交班数据
        /// </summary>
        private List<MED_OPERATION_SHIFT_RECORD> _AnesDocRecord;

        public List<MED_OPERATION_SHIFT_RECORD> AnesDocRecord
        {
            get { return _AnesDocRecord; }
            set
            {
                _AnesDocRecord = value;
                RaisePropertyChanged("AnesDocRecord");
            }
        }
        /// <summary>
        /// 助理交班数据
        /// </summary>
        private List<MED_OPERATION_SHIFT_RECORD> _SurgeryRecord;

        public List<MED_OPERATION_SHIFT_RECORD> SurgeryRecord
        {
            get { return _SurgeryRecord; }
            set
            {
                _SurgeryRecord = value;
                RaisePropertyChanged("SurgeryRecord");
            }
        }
        private OperationShiftModel currentType = new OperationShiftModel();
        private MED_OPERATION_MASTER _masterRow;

        private string[] NurseDutyList = new string[] { "第一台上护士", "第二台上护士", "第三台上护士", "第四台上护士", "第一供应护士", "第二供应护士", "第三供应护士", "第四供应护士" };
        private string[] AnesDocDutyList = new string[] { "主麻", "麻醉助手1", "麻醉助手2", "麻醉助手3", "麻醉助手4" };
        private string[] SurgeryDutyList = new string[] { "术者", "第一手术助理", "第二手术助理", "第三手术助理", "第四手术助理", "灌注医生", "灌注医生助手1" };

        private string _patientID;
        private int _visitID;
        private int _operID;
        /// <summary>
        /// 获取窗口传参
        /// </summary>
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            _patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            _visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            _operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
        }
        /// <summary>
        ///数据加载
        /// </summary>
        public override void LoadData()
        {
            _leftType = new List<OperationShiftModel>();
            OperationShiftModel item1 = new OperationShiftModel();
            item1.ShiftType = "麻醉交班";
            _leftType.Add(item1);
            OperationShiftModel item2 = new OperationShiftModel();
            item2.ShiftType = "手术交班";
            _leftType.Add(item2);
            OperationShiftModel item3 = new OperationShiftModel();
            item3.ShiftType = "护士交班";
            _leftType.Add(item3);
            LeftType = _leftType;
            MED_DOCTOR_DICT = ApplicationModel.Instance.AllDictList.HisUsersList.Where(x => x.USER_DEPT_CODE == ExtendAppContext.Current.AnesWardCode).ToList();
            MED_NURSE_DICT = ApplicationModel.Instance.AllDictList.HisUsersList.Where(x => x.USER_DEPT_CODE == ExtendAppContext.Current.OperDeptCode).ToList();
            MED_USERS_DICT = ApplicationModel.Instance.AllDictList.HisUsersList;
            _masterRow = AnesInfoService.ClientInstance.GetOperationMaster(_patientID, _visitID, _operID);
            shiftRecordList = AnesInfoService.ClientInstance.GetOperShiftRecord(_patientID, _visitID, _operID);
            ShowNurseShift();
            ShowSurgeryShift();
            ShowAnesDocShift();
        }
        /// <summary>
        /// 护士交班信息
        /// </summary>
        private void ShowNurseShift()
        {
            NurseRecord = new List<MED_OPERATION_SHIFT_RECORD>();

            foreach (var duty in NurseDutyList)
            {
                MED_OPERATION_SHIFT_RECORD record = new MED_OPERATION_SHIFT_RECORD();
                record = shiftRecordList.Where(x => x.SHIFT_DUTY == duty).OrderByDescending(p => p.SHIFT_TIMES).FirstOrDefault();
                if (record == null)
                {
                    record = new MED_OPERATION_SHIFT_RECORD();
                    record.PATIENT_ID = _patientID;
                    record.VISIT_ID = _visitID;
                    record.OPER_ID = _operID;
                    record.ModelStatus = ModelStatus.Add;
                    switch (duty)
                    {
                        case "第一台上护士":
                            record.SHIFT_DUTY = "第一台上护士";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.FIRST_OPER_NURSE;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第二台上护士":
                            record.SHIFT_DUTY = "第二台上护士";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.SECOND_OPER_NURSE;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第三台上护士":
                            record.SHIFT_DUTY = "第三台上护士";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.THIRD_OPER_NURSE;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第四台上护士":
                            record.SHIFT_DUTY = "第四台上护士";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.FOURTH_OPER_NURSE;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第一供应护士":
                            record.SHIFT_DUTY = "第一供应护士";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.FIRST_SUPPLY_NURSE;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第二供应护士":
                            record.SHIFT_DUTY = "第二供应护士";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.SECOND_SUPPLY_NURSE;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第三供应护士":
                            record.SHIFT_DUTY = "第三供应护士";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.THIRD_SUPPLY_NURSE;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第四供应护士":
                            record.SHIFT_DUTY = "第四供应护士";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.FOURTH_SUPPLY_NURSE;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        default:
                            break;
                    }
                }
                record.PERSON_NAME = ShowUserName(record.PERSON);
                NurseRecord.Add(record);
            }
            currentType.ShiftType = "护士交班";
        }
        /// <summary>
        /// 麻醉医生交班信息
        /// </summary>
        private void ShowAnesDocShift()
        {
            AnesDocRecord = new List<MED_OPERATION_SHIFT_RECORD>();

            foreach (var duty in AnesDocDutyList)
            {
                MED_OPERATION_SHIFT_RECORD record = new MED_OPERATION_SHIFT_RECORD();
                record = shiftRecordList.Where(x => x.SHIFT_DUTY == duty).OrderByDescending(p => p.SHIFT_TIMES).FirstOrDefault();
                if (record == null)
                {
                    record = new MED_OPERATION_SHIFT_RECORD();
                    record.PATIENT_ID = _patientID;
                    record.VISIT_ID = _visitID;
                    record.OPER_ID = _operID;
                    record.ModelStatus = ModelStatus.Add;
                    switch (duty)
                    {
                        case "主麻":
                            record.SHIFT_DUTY = "主麻";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.ANES_DOCTOR;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "麻醉助手1":
                            record.SHIFT_DUTY = "麻醉助手1";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.FIRST_ANES_ASSISTANT;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "麻醉助手2":
                            record.SHIFT_DUTY = "麻醉助手2";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.SECOND_ANES_ASSISTANT;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "麻醉助手3":
                            record.SHIFT_DUTY = "麻醉助手3";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.THIRD_ANES_ASSISTANT;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "麻醉助手4":
                            record.SHIFT_DUTY = "麻醉助手4";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.FOURTH_ANES_ASSISTANT;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;

                        default:
                            break;
                    }
                }
                record.PERSON_NAME = ShowUserName(record.PERSON);
                AnesDocRecord.Add(record);
            }
            currentType.ShiftType = "麻醉交班";
        }
        /// <summary>
        /// 手术医生交班信息
        /// </summary>
        private void ShowSurgeryShift()
        {
            SurgeryRecord = new List<MED_OPERATION_SHIFT_RECORD>();

            foreach (var duty in SurgeryDutyList)
            {
                MED_OPERATION_SHIFT_RECORD record = new MED_OPERATION_SHIFT_RECORD();
                record = shiftRecordList.Where(x => x.SHIFT_DUTY == duty).OrderByDescending(p => p.SHIFT_TIMES).FirstOrDefault();
                if (record == null)
                {
                    record = new MED_OPERATION_SHIFT_RECORD();
                    record.PATIENT_ID = _patientID;
                    record.VISIT_ID = _visitID;
                    record.OPER_ID = _operID;
                    record.ModelStatus = ModelStatus.Add;
                    switch (duty)
                    {
                        case "术者":
                            record.SHIFT_DUTY = "术者";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.SURGEON;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第一手术助理":
                            record.SHIFT_DUTY = "第一手术助理";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.FIRST_OPER_ASSISTANT;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第二手术助理":
                            record.SHIFT_DUTY = "第二手术助理";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.SECOND_OPER_ASSISTANT;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第三手术助理":
                            record.SHIFT_DUTY = "第三手术助理";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.THIRD_OPER_ASSISTANT;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "第四手术助理":
                            record.SHIFT_DUTY = "第四手术助理";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.FOURTH_OPER_ASSISTANT;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "灌注医生":
                            record.SHIFT_DUTY = "灌注医生";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.CPB_DOCTOR;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        case "灌注医生助手1":
                            record.SHIFT_DUTY = "灌注医生助手1";
                            record.SHIFT_TIMES = 1;
                            record.PERSON = _masterRow.FIRST_CPB_ASSISTANT;
                            record.START_DATE_TIME = _masterRow.IN_DATE_TIME.Value;
                            break;
                        default:
                            break;
                    }
                }
                record.PERSON_NAME = ShowUserName(record.PERSON);
                SurgeryRecord.Add(record);
            }
            currentType.ShiftType = "手术交班";
        }
        /// <summary>
        /// 切换交班类型
        /// </summary>
        public ICommand LeftTypeClick
        {
            get
            {
                return new RelayCommand<OperationShiftModel>(data =>
                {
                    if (data.ShiftType == "护士交班")
                    {
                        Messenger.Default.Send<object>(this, EnumMessageKey.ShowNurseShift);
                    }
                    else if (data.ShiftType == "麻醉交班")
                    {
                        Messenger.Default.Send<object>(this, EnumMessageKey.ShowAnesDocShift);
                    }
                    else if (data.ShiftType == "手术交班")
                    {
                        Messenger.Default.Send<object>(this, EnumMessageKey.ShowSurgeonShift);
                    }
                });
            }
        }
        /// <summary>
        /// 保存交班数据
        /// </summary>
        protected override SaveResult SaveData()
        {
            SaveResult saveResult = SaveResult.Fail;
            bool result = true;
            List<MED_OPERATION_SHIFT_RECORD> newList = new List<MED_OPERATION_SHIFT_RECORD>();
            foreach (MED_OPERATION_SHIFT_RECORD item in _NurseRecord)
            {
                if (item.PERSON != null)
                {
                    newList.Add(item);
                }
                else { continue; }
                if (item.END_DATE_TIME != null && item.SHIFT_PERSON != null)
                {
                    MED_OPERATION_SHIFT_RECORD newItem = new MED_OPERATION_SHIFT_RECORD();
                    newItem.PATIENT_ID = _patientID;
                    newItem.VISIT_ID = _visitID;
                    newItem.OPER_ID = _operID;
                    newItem.SHIFT_DUTY = item.SHIFT_DUTY;
                    newItem.SHIFT_TIMES = item.SHIFT_TIMES + 1;
                    newItem.PERSON = item.SHIFT_PERSON;
                    newItem.START_DATE_TIME = item.END_DATE_TIME.Value;
                    newItem.ModelStatus = ModelStatus.Add;
                    newList.Add(newItem);
                }
            }
            foreach (MED_OPERATION_SHIFT_RECORD item in _AnesDocRecord)
            {
                if (item.PERSON != null)
                {
                    newList.Add(item);
                }
                else { continue; }
                if (item.END_DATE_TIME != null && item.SHIFT_PERSON != null)
                {
                    MED_OPERATION_SHIFT_RECORD newItem = new MED_OPERATION_SHIFT_RECORD();
                    newItem.PATIENT_ID = _patientID;
                    newItem.VISIT_ID = _visitID;
                    newItem.OPER_ID = _operID;
                    newItem.SHIFT_DUTY = item.SHIFT_DUTY;
                    newItem.SHIFT_TIMES = item.SHIFT_TIMES + 1;
                    newItem.PERSON = item.SHIFT_PERSON;
                    newItem.START_DATE_TIME = item.END_DATE_TIME.Value;
                    newItem.ModelStatus = ModelStatus.Add;
                    newList.Add(newItem);
                }
            }
            foreach (MED_OPERATION_SHIFT_RECORD item in _SurgeryRecord)
            {
                if (item.PERSON != null)
                {
                    newList.Add(item);
                }
                else { continue; }
                if (item.END_DATE_TIME != null && item.SHIFT_PERSON != null)
                {
                    MED_OPERATION_SHIFT_RECORD newItem = new MED_OPERATION_SHIFT_RECORD();
                    newItem.PATIENT_ID = _patientID;
                    newItem.VISIT_ID = _visitID;
                    newItem.OPER_ID = _operID;
                    newItem.SHIFT_DUTY = item.SHIFT_DUTY;
                    newItem.SHIFT_TIMES = item.SHIFT_TIMES + 1;
                    newItem.PERSON = item.SHIFT_PERSON;
                    newItem.START_DATE_TIME = item.END_DATE_TIME.Value;
                    newItem.ModelStatus = ModelStatus.Add;
                    newList.Add(newItem);
                }
            }
            result = AnesInfoService.ClientInstance.SaveOperShiftRecord(newList);
            if (result)
                saveResult = SaveResult.Success;

            return saveResult;
        }
        /// <summary>
        /// 取消并关闭窗口
        /// </summary>
        public ICommand BtnCancelCommand
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    this.CloseContentWindow();
                });
            }
        }
        /// <summary>
        /// 确定并保存
        /// </summary>
        public ICommand BtnOKCommand
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    PublicKeyBoardMessage(KeyCode.AppCode.Save);
                });
            }
        }
        /// <summary>
        /// 修改单条交班信息
        /// </summary>
        public ICommand DetailClick
        {
            get
            {
                return new RelayCommand<MED_OPERATION_SHIFT_RECORD>(data =>
                {
                    if (data == null || data.PERSON == null || data.PERSON == "")
                    {
                        return;
                    }
                    else
                    {
                        this.keyBoardMessageLock = true;
                        ShowContentWindowMessage message;
                        message = new ShowContentWindowMessage("OperationShiftChange", "交班修改")
                        {
                            Height = 500,
                            Width = 600,
                            IsModal = true,
                            Args = new object[] { data, currentType.ShiftType },
                            CallBackCommand = RefreshData
                        };
                        Messenger.Default.Send<ShowContentWindowMessage>(message);
                    }

                });
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        public ICommand RefreshData
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    this.keyBoardMessageLock = false;
                    shiftRecordList = AnesInfoService.ClientInstance.GetOperShiftRecord(_patientID, _visitID, _operID);
                    switch (currentType.ShiftType)
                    {
                        case "麻醉交班":
                            ShowAnesDocShift();
                            break;
                        case "手术交班":
                            ShowSurgeryShift();
                            break;
                        case "护士交班":
                            ShowNurseShift();
                            break;
                        default:
                            break;
                    }
                });
            }
        }

    }
}
