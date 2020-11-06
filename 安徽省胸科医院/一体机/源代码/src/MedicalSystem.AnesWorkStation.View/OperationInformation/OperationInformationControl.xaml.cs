//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationInformationControl.xaml.cs
//功能描述(Description)：    手术信息
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:46:36
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝ 
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;
namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationInformationControl.xaml 的交互逻辑
    /// </summary>
    public partial class OperationInformationControl : BaseUserControl
    {
        /// <summary>
        /// Defines the _operInfoViewModel
        /// </summary>
        internal OperInfoViewModel _operInfoViewModel;

        /// <summary>
        /// 构造函数
        /// </summary>
        public OperationInformationControl()
        {
            InitializeComponent();
            _operInfoViewModel = new OperInfoViewModel(false);
            this.DataContext = _operInfoViewModel;
        }
    }
}
