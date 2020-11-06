// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      InOperationViewModel.cs
// 功能描述(Description)：    术中界面对应的ViewModel
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
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
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public partial class InOperationViewModel : BaseViewModel
    {
        #region  绑定属性
        /// <summary>
        /// 脉搏
        /// </summary> 
        private string _pulseValue;

        public string PulseValue
        {
            get { return _pulseValue; }
            set { _pulseValue = value; RaisePropertyChanged("PulseValue"); }
        }
        /// <summary>
        /// 呼吸
        /// </summary> 
        private string _breathValue;

        public string BreathValue
        {
            get { return _breathValue; }
            set { _breathValue = value; RaisePropertyChanged("BreathValue"); }
        }
        /// <summary>
        ///血压
        /// </summary> 
        private string _bloodPreValue;

        public string BloodPreValue
        {
            get { return _bloodPreValue; }
            set { _bloodPreValue = value; RaisePropertyChanged("BloodPreValue"); }
        }
        /// <summary>
        /// 体温
        /// </summary> 
        private string _temperatureValue;

        public string TemperatureValue
        {
            get { return _temperatureValue; }
            set { _temperatureValue = value; RaisePropertyChanged("TemperatureValue"); }
        }
        /// <summary>
        /// spo2
        /// </summary> 
        private string _spo2Value;

        public string Spo2Value
        {
            get { return _spo2Value; }
            set
            {
                _spo2Value = value;
                RaisePropertyChanged("Spo2Value");
            }
        }
        /// <summary>
        /// 是否弹出
        /// </summary> 
        private bool _isPopupShow = false;

        public bool IsPopupShow
        {
            get { return _isPopupShow; }
            set
            {
                _isPopupShow = value;
                RaisePropertyChanged("IsPopupShow");
            }
        }
        private Visibility _isResueShow;
        public Visibility IsResueShow
        {
            get { return _isResueShow; }
            set
            {
                _isResueShow = value;

                RaisePropertyChanged("IsResueShow");
            }
        }
        #endregion
        /// <summary>
        /// 构造方法
        /// </summary>
        public InOperationViewModel()
        {
            RegisterMessage();
        }

        private void RegisterMessage()
        {
            Messenger.Default.Register<object>(this, EnumMessageKey.IsOperationRescuing, mes =>
            {
                if (ExtendAppContext.Current.IsOperationRescuing)
                {
                    this.IntensiveSignLasterItem();
                    if (IsResueShow == Visibility.Visible)
                    {
                        IsPopupShow = false;
                    }
                    else
                    {
                        IsPopupShow = true;
                    }
                }
                else
                {
                    IsPopupShow = ExtendAppContext.Current.IsOperationRescuing;
                    IsResueShow = Visibility.Collapsed;
                }
            });
        }
        public void IntensiveSignLasterItem()
        {
            List<MED_COMM_VITAL_REC> vitalList = AnesInfoService.ClientInstance.GetCommVitalRecListByEventNo(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID
                , ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, ExtendAppContext.Current.PatientInformationExtend.OPER_ID, ExtendAppContext.Current.EventNo);
            if (vitalList != null && vitalList.Count > 0)
            {
                MED_COMM_VITAL_REC signItem = vitalList[vitalList.Count - 1];
                PulseValue = signItem.PULSE.HasValue ? signItem.PULSE.Value.ToString() : "";
                BreathValue = signItem.RESP.HasValue ? signItem.RESP.Value.ToString() : "";
                if (signItem.IBP_SYS.HasValue || signItem.IBP_DIA.HasValue)
                {
                    BloodPreValue = (signItem.IBP_SYS.HasValue ? signItem.IBP_SYS.Value.ToString() : "") + "/" + (signItem.IBP_DIA.HasValue ? signItem.IBP_DIA.Value.ToString() : "");
                }
                else
                {
                    BloodPreValue = (signItem.NIBP_SYS.HasValue ? signItem.NIBP_SYS.Value.ToString() : "") + "/" + (signItem.NIBP_DIA.HasValue ? signItem.NIBP_DIA.Value.ToString() : "");
                }
                TemperatureValue = signItem.BODY_TEMP.HasValue ? signItem.BODY_TEMP.Value.ToString() : "";
                Spo2Value = signItem.SPO2.HasValue ? signItem.SPO2.Value.ToString() : "";
            }
        }

        protected override void KeyBoardMessage(string keyCode)
        {
            if (KeyBoardStateCache.AppCodeStack.Count == 0)//术中首页返回主页面
            {
                switch (keyCode)
                {
                    case KeyCode.AppCode.HOME:
                    case KeyCode.AppCode.Back:
                        ExtendAppContext.Current.IsModify = true;
                        Messenger.Default.Send<object>(this, EnumMessageKey.CloseInOperationWindow);
                        break;
                    case KeyCode.AppCode.Rescue:
                        IntensiveSignLasterItem();
                        IsPopupShow = true;
                        break;
                    default:
                        // 响应快捷键
                        if (ApplicationConfiguration.ShortCuts.ContainsKey(keyCode))
                        {
                            string value = ApplicationConfiguration.ShortCuts[keyCode];
                            // 判断是不是文书
                            if (!string.IsNullOrEmpty(ApplicationConfiguration.GetMedicalDocument(value).Caption))
                            {
                                ExtendAppContext.Current.CurntOpenForm = new OpenForm(value, null);
                                this.ShowDocByDocName(value);
                            }
                            else
                            {
                                // 快捷键响应功能按键
                                switch (value)
                                {
                                    case "血气分析":
                                        this.BloodGasAnalysisControlMethod();
                                        break;
                                    case "手术跳转":
                                        this.OperatioinJumpMethod();
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 功能菜单
        /// </summary>
        public ICommand BottomMenu
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    if (ExtendAppContext.Current.IsModify)
                    {
                        var message = new ShowContentWindowMessage("BottomMenu", "");
                        message.WindowType = ContentWindowType.ToolBox;
                        message.Height = MED_CONSTANT.TOOL_BAR_HEIGHT;
                        message.Width = SystemParameters.PrimaryScreenWidth;
                        message.IsModal = false;
                        message.PositionX = 0;
                        message.PositionY = SystemParameters.PrimaryScreenHeight - message.Height;
                        message.TileBackground = Brushes.Transparent;
                        Messenger.Default.Send<ShowContentWindowMessage>(message);
                    }

                });
            }
        }
    }
}
