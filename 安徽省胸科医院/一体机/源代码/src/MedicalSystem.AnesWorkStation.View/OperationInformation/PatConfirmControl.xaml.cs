//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      PatConfirmControl.xaml.cs
//功能描述(Description)：    核对患者信息
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 15:32:06
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;
namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationScreen.xaml 的交互逻辑
    /// </summary>
    public partial class PatConfirmControl : BaseUserControl
    {
        private PatConfirmControlViewModel patConfirmControlViewModel = null;
        /// <summary>
        /// 构造方法
        /// </summary>
        public PatConfirmControl()
        {
            InitializeComponent();
            this.patConfirmControlViewModel = new PatConfirmControlViewModel();
            this.DataContext = this.patConfirmControlViewModel;
        }
    }
}
