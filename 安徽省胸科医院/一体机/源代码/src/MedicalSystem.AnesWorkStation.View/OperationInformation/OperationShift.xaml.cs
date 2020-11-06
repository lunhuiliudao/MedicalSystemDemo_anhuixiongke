//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationShift.xaml.cs
//功能描述(Description)：    手术交班
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 14:49:33
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationShiftViewModel;
using System.Windows;
namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationShift.xaml 的交互逻辑
    /// </summary>
    public partial class OperationShift : BaseUserControl
    {
        OperationShiftViewModel _operationShiftViewModel = null;
        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationShift()
        {
            InitializeComponent();
            _operationShiftViewModel = new OperationShiftViewModel();
            this.DataContext = _operationShiftViewModel;
            RegisterMessage();
            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
        }

        /// <summary>
        /// 消息注册
        /// </summary>
        private void RegisterMessage()
        {
            Messenger.Default.Register<object>(this, EnumMessageKey.ShowNurseShift, msg =>
            {
                this.datagridNurse.Visibility = Visibility.Visible;
                this.datagridAnesDoc.Visibility = Visibility.Collapsed;
                this.datagridSurgeon.Visibility = Visibility.Collapsed;
            });
            Messenger.Default.Register<object>(this, EnumMessageKey.ShowAnesDocShift, msg =>
            {
                this.datagridNurse.Visibility = Visibility.Collapsed;
                this.datagridAnesDoc.Visibility = Visibility.Visible;
                this.datagridSurgeon.Visibility = Visibility.Collapsed;
            });
            Messenger.Default.Register<object>(this, EnumMessageKey.ShowSurgeonShift, msg =>
            {
                this.datagridNurse.Visibility = Visibility.Collapsed;
                this.datagridAnesDoc.Visibility = Visibility.Collapsed;
                this.datagridSurgeon.Visibility = Visibility.Visible;
            });
        }
    }
}
