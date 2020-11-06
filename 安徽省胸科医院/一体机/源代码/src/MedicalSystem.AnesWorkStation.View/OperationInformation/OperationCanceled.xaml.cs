//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationCanceled.xaml.cs
//功能描述(Description)：    手术取消
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:19:46
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
    /// OperationCanceled.xaml 的交互逻辑
    /// </summary>
    public partial class OperationCanceled : BaseUserControl
    {
        /// <summary>
        /// 手术取消ViewModel
        /// </summary>
        private OperationCanceledViewModel operationCanceledViewModel = null;

        /// <summary>
        ///构造函数
        /// </summary>
        public OperationCanceled()
        {
            InitializeComponent();
            this.operationCanceledViewModel = new OperationCanceledViewModel(ExtendAppContext.Current.PatientInformationExtend, this.tbReason);
            this.DataContext = this.operationCanceledViewModel;
        }
    }
}
