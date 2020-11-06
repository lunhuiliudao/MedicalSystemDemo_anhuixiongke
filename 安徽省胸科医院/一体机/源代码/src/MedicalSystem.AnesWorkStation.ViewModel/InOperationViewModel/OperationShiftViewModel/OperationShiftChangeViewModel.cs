//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationShiftChangeViewModel.cs
//功能描述(Description)：    修改麻醉交班、手术交班、护士交班信息
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 15:01:07
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
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

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationShiftViewModel
{
    public class OperationShiftChangeViewModel : BaseViewModel
    {
        private MED_OPERATION_SHIFT_RECORD paramaterData;
        private string type;
        /// <summary>
        /// 交班信息
        /// </summary>
        private ObservableCollection<MED_OPERATION_SHIFT_RECORD> _shiftRecordList;
        public ObservableCollection<MED_OPERATION_SHIFT_RECORD> ShiftRecordList
        {
            get { return _shiftRecordList; }
            set
            {
                _shiftRecordList = value;
                RaisePropertyChanged("ShiftRecordList");
            }
        }
        private ObservableCollection<MED_OPERATION_SHIFT_RECORD> tmpShiftRecordList;
        /// <summary>
        /// 人员字典表
        /// </summary>
        private List<MED_HIS_USERS> _medHisUserDict;
        public List<MED_HIS_USERS> MED_HISUSER_DICT
        {
            get
            {
                return this._medHisUserDict;
            }
            set
            {
                this._medHisUserDict = value;
                RaisePropertyChanged("MED_HISUSER_DICT");
            }
        }

        private string _patientID;
        private int _visitID;
        private int _operID;
        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationShiftChangeViewModel()
        {
            _patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            _visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            _operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;

        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            ShiftRecordList = new ObservableCollection<MED_OPERATION_SHIFT_RECORD>(AnesInfoService.ClientInstance.GetOperShiftRecord(_patientID, _visitID, _operID)
                .Where(x => x.SHIFT_DUTY.Equals(paramaterData.SHIFT_DUTY)).OrderBy(x => x.SHIFT_TIMES).ToList());
            foreach (var item in ShiftRecordList)
            {
                item.PERSON_NAME = ShowUserName(item.PERSON);
                item.SHIFT_PERSON_NAME = ShowUserName(item.SHIFT_PERSON);
                item.IS_SHOW = false;
            }
            if (ShiftRecordList.Count > 1)
            {
                ShiftRecordList.Last().IS_SHOW = true;
            }
            tmpShiftRecordList = new ObservableCollection<MED_OPERATION_SHIFT_RECORD>(_shiftRecordList);
            switch (type)
            {
                case "麻醉交班":
                    MED_HISUSER_DICT = ApplicationModel.Instance.AllDictList.HisUsersList.Where(x => x.USER_DEPT_CODE == ExtendAppContext.Current.AnesWardCode).ToList();
                    break;
                case "手术交班":
                    MED_HISUSER_DICT = ApplicationModel.Instance.AllDictList.HisUsersList.Where(x => x.USER_DEPT_CODE == ExtendAppContext.Current.OperDeptCode).ToList();
                    break;
                case "护士交班":
                    MED_HISUSER_DICT = ApplicationModel.Instance.AllDictList.HisUsersList;
                    break;
                default:
                    MED_HISUSER_DICT = ApplicationModel.Instance.AllDictList.HisUsersList;
                    break;
            }
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public override void OnViewLoaded()
        {
            try
            {
                base.OnViewLoaded();
                paramaterData = Args[0] as MED_OPERATION_SHIFT_RECORD;
                type = Args[1].ToString();
            }
            catch (Exception ex)
            {
                Logger.Error("患者确认异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        protected override SaveResult SaveData()
        {
            SaveResult saveResult = SaveResult.Fail;
            bool result = AnesInfoService.ClientInstance.SaveOperShiftRecord(new List<MED_OPERATION_SHIFT_RECORD>(tmpShiftRecordList));
            if (result)
                saveResult = SaveResult.Success;
            return saveResult;
        }
        /// <summary>
        /// 删除
        /// </summary>
        public ICommand DeleteItemClick
        {
            get
            {
                return new RelayCommand<MED_OPERATION_SHIFT_RECORD>(data =>
                {
                    if (data == null || (data.SHIFT_PERSON != null && data.SHIFT_PERSON != "") || ShiftRecordList.Count == 1)
                    {
                        return;
                    }
                    else
                    {
                        data.ModelStatus = ModelStatus.Deleted;
                        ShiftRecordList.Remove(data);
                        ShiftRecordList.Last().SHIFT_PERSON = "";
                        ShiftRecordList.Last().SHIFT_PERSON_NAME = "";
                        ShiftRecordList.Last().END_DATE_TIME = null;
                    }

                });
            }
        }
        /// <summary>
        /// 取消并关闭
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
        /// 确认并保存
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
    }
}
