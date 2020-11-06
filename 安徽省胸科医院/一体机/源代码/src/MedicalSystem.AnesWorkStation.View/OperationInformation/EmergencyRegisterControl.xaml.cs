//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      EmergencyRegisterControl.xaml.cs
//功能描述(Description)：    急诊登记
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:05:39
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.EmergencyRegisterViewModel;
using System.Windows;
namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// EmergencyRegisterControl.xaml 的交互逻辑
    /// </summary>
    public partial class EmergencyRegisterControl : BaseUserControl
    {
        /// <summary>
        /// Defines the emergencyRegisterViewModel
        /// </summary>
        private EmergencyRegisterViewModel emergencyRegisterViewModel;

        /// <summary>
        /// 构造方法
        /// </summary>
        public EmergencyRegisterControl()
        {
            InitializeComponent();

            ExtendAppContext.Current.IsPermission = true;

            this.emergencyRegisterViewModel = new EmergencyRegisterViewModel();
            this.DataContext = this.emergencyRegisterViewModel;
            this.tbPatientID.ResetFocus();
            RegisterMessage();

            this.Unloaded += EmergencyRegisterControl_Unloaded;
        }
        #region Methods

        /// <summary>
        /// The EmergencyRegisterControl_Unloaded
        /// </summary>
        /// <param name="sender">The <see cref="object"/></param>
        /// <param name="e">The <see cref="RoutedEventArgs"/></param>
        internal void EmergencyRegisterControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<string>(this, EnumMessageKey.ResetFocus);
        }

        /// <summary>
        /// 注册消息响应
        /// </summary>
        private void RegisterMessage()
        {
            //首次相应焦点到具体输入框，
            Messenger.Default.Register<string>(this, EnumMessageKey.ResetFocus, msg =>
            {
                if (msg == "tbPatientID")
                {
                    this.tbPatientID.ResetFocus();
                }
            });
        }

        #endregion
    }
}
