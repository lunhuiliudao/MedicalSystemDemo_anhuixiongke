
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AddVitalSignTitleViewModel.cs
//功能描述(Description)：    添加体征项目界面ViewModel
//数据表(Tables)：		    MED_MONITOR_FUNCTION_CODE
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class AddVitalSignTitleViewModel : BaseViewModel
    {
        private List<MED_MONITOR_FUNCTION_CODE> monitCodeData;
        public List<MED_MONITOR_FUNCTION_CODE> MonitCodeData
        {
            get { return monitCodeData; }
            set
            {
                monitCodeData = value;
                this.RaisePropertyChanged("MonitCodeData");
            }
        }
        private MED_MONITOR_FUNCTION_CODE selectData;
        public MED_MONITOR_FUNCTION_CODE SelectData
        {
            get { return selectData; }
            set
            {
                selectData = value;
                this.RaisePropertyChanged("SelectData");
            }

        }
        private Dictionary<int, string> rowDict;

        private List<MED_MONITOR_FUNCTION_CODE> listMonitorCode;

        public AddVitalSignTitleViewModel()
        {
        }

        /// <summary>
        /// 检查数据有效
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            bool result = true;
            if (SelectData == null)
            {
                ShowMessageBox("请先选择项目。", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }
            return result;
        }


        protected override SaveResult SaveData()
        {
            Messenger.Default.Send<dynamic>(SelectData, "SureCommand");
            return SaveResult.Success;
        }

        public override void LoadData()
        {
            rowDict = (Dictionary<int, string>)Args[0];
            listMonitorCode = ApplicationModel.Instance.AllDictList.MonitorFuctionCodeList.Where(x => x.USE_FLAG == "1").ToList();
            MonitCodeData = new List<MED_MONITOR_FUNCTION_CODE>(listMonitorCode);
        }

        /// <summary>
        /// 增加体征项目发送消息
        /// </summary>
        public ICommand SureCommand
        {
            get
            {
                return new RelayCommand<MED_MONITOR_FUNCTION_CODE>(data =>
                {
                    data = selectData;
                    bool isAdd = true;
                    for (int i = 0; i < rowDict.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(rowDict[i]))
                        {
                            if (data.ITEM_CODE.Equals(rowDict[i].Trim()))
                            {
                                isAdd = false; 
                                break;
                            }
                        }
                    }
                    if (isAdd)
                        PublicKeyBoardMessage(KeyCode.AppCode.Save);
                    else
                    {
                        ShowMessageBox("已存在此体征项目，请重新选择！", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }
        /// <summary>
        /// 搜索
        /// </summary>
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    this.MonitCodeData = listMonitorCode.Where(x => x.INPUT_CODE.ToUpper().Contains(key.Trim().ToUpper())).ToList();
                });
            }
        }
        public ICommand SearchTextChangedCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    this.MonitCodeData = listMonitorCode.Where(x => x.INPUT_CODE.ToUpper().Contains(key.Trim().ToUpper())).ToList();
                });
            }
        }
    }
}
