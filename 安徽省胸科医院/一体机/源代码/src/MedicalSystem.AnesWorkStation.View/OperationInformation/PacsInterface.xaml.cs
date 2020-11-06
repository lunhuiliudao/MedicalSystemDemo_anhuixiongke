//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      PacsInterface.xaml.cs
//功能描述(Description)：    家属大屏交互界面
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 14:45:43
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
    /// OperationScreen.xaml 的交互逻辑
    /// </summary>
    public partial class PacsInterface : BaseUserControl
    {
        private PacsInterfaceViewModel pacsInterfaceViewModel = null;

        /// <summary>
        ///构造方法
        /// </summary>
        public PacsInterface()
        {
            InitializeComponent();
            this.pacsInterfaceViewModel = new PacsInterfaceViewModel(ExtendAppContext.Current.PatientInformationExtend);
            this.DataContext = this.pacsInterfaceViewModel;
        }
    }
}
