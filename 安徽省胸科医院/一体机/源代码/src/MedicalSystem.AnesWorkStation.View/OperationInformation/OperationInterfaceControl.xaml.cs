/*******************************************************************
 * 文件名称(File Name)：      OperationInterfaceControl.cs
 * 功能描述(Description)：    第三方接口动态链接访问界面
 * 数据表(Tables)：		
 * 作者(Author)：             许文龙 
 * 日期(Create Date)：        2018-09-14 10:49:12
 * R1:
 *    修改作者:
 *    修改日期:
 *    修改理由:
 *******************************************************************/
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationInterfaceControl.xaml 的交互逻辑
    /// </summary>
    public partial class OperationInterfaceControl : BaseUserControl
    {
        private OperationInterfaceControlViewModel operInterViewModel = null;

        public OperationInterfaceControl()
        {
            InitializeComponent();
            this.operInterViewModel = new OperationInterfaceControlViewModel();
            this.DataContext = this.operInterViewModel;
            this.Focus();
        }
    }
}
