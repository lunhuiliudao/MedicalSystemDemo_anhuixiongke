//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      InOperationNoteWindow.xaml.cs
//功能描述(Description)：    InOperationNoteWindow.xaml.cs
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:12:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;
namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// InOperationNoteWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InOperationNoteWindow : WindowBase
    {
        internal OperationInformationViewModel _operationInformationViewModel;

        /// <summary>
        /// 构造函数
        /// </summary>
        public InOperationNoteWindow()
        {
            InitializeComponent();

            _operationInformationViewModel = new OperationInformationViewModel();
            this.DataContext = _operationInformationViewModel;
        }
    }
}
