//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationJump.xaml.cs
//功能描述(Description)：    术中状态跳转
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:49:12
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationJump.xaml 的交互逻辑
    /// </summary>
    public partial class OperationJump : BaseUserControl
    {
        private OperationJumpViewModel operationJumpViewModel = null;
        /// <summary>
        ///构造函数
        /// </summary>
        public OperationJump()
        {
            InitializeComponent();
            this.operationJumpViewModel = new OperationJumpViewModel(ExtendAppContext.Current.PatientInformationExtend, this.tbReason);
            this.DataContext = this.operationJumpViewModel;
        }

        private void cbOperStatus_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            operationJumpViewModel.ResetVisibTime();
        }
    }
}
