using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class ChargeTemplateMethodViewModel : BaseViewModel
    {
        private List<MED_ANESTHESIA_DICT> _medAnesthesiaDict;                      // 麻醉方法字典表
        private string _ANES_METHOD_NAME;     // 当前患者麻醉方式
        private string _TempletName;//模板名称
        /// <summary>
        /// 麻醉方法字典绑定
        /// </summary>
        public List<MED_ANESTHESIA_DICT> MED_ANESTHESIA_DICT
        {
            get { return this._medAnesthesiaDict; }
            set
            {
                this._medAnesthesiaDict = value;
                RaisePropertyChanged("MED_ANESTHESIA_DICT");
            }
        }
        /// <summary>
        /// 当前患者麻醉方式
        /// </summary>
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
        /// 当前模板名称
        /// </summary>
        public string TempletName
        {
            get
            {
                return _TempletName;
            }
            set
            {
                this._TempletName = value;
                RaisePropertyChanged("TempletName");
            }
        }
        /// <summary>
        /// 保存返回值
        /// </summary>
        SaveResult saveResult = SaveResult.Fail;

        /// <summary>
        /// 载入数据
        /// </summary>
        public override void LoadData()
        {
            ANES_METHOD_NAME = ExtendAppContext.Current.PatientInformationExtend.ANES_METHOD;
            MED_ANESTHESIA_DICT = ApplicationModel.Instance.AllDictList.AnesthesiaDictList;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override SaveResult SaveData()
        {
            this.Result = new { templetType = ANES_METHOD_NAME, name = TempletName }; ;
            Messenger.Default.Send<object>(this.Result, "BtnSureCommand");
            return SaveResult.CancelMessageBox;
        }
        /// <summary>
        /// 选中模板名称
        /// </summary>
        public ICommand BtnSureCommand
        {
            get
            {
                return new RelayCommand<object>(data =>
                {
                    if (string.IsNullOrEmpty(ANES_METHOD_NAME) || string.IsNullOrEmpty(TempletName))
                    {
                        ShowMessageBox("收费类别和收费模板名称不能为空。", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        List<MED_ANES_BILL_TEMPLET> templetList = ChargeInfoService.ClientInstance.GetBillTempletList(ANES_METHOD_NAME, TempletName);
                        if (templetList.Count > 0)
                        {
                            ShowMessageBox("已存在此模板，请重新选择。", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                            PublicKeyBoardMessage(KeyCode.AppCode.Save);
                    }

                });
            }
        }
    }
}
