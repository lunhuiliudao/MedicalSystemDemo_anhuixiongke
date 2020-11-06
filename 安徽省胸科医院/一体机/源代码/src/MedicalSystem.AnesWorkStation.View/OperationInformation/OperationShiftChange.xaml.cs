//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationShiftChange.xaml.cs
//功能描述(Description)：    修改麻醉交班、手术交班、护士交班信息
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 15:01:07
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationShiftViewModel;
using System.Windows;
namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationShift.xaml 的交互逻辑
    /// </summary>
    public partial class OperationShiftChange : BaseUserControl
    {
        private OperationShiftChangeViewModel operationShiftChangeViewModel = null;

        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationShiftChange()
        {
            InitializeComponent();
            this.operationShiftChangeViewModel = new OperationShiftChangeViewModel();
            this.DataContext = operationShiftChangeViewModel;
            this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender">The <see cref="object"/></param>
        /// <param name="e">The <see cref="RoutedEventArgs"/></param>
        private void ButtonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            int rowIndex = this.datagrid.SelectedIndex;
            this.operationShiftChangeViewModel.DeleteItemClick.Execute(this.datagrid.SelectedItem);
        }
    }
}
