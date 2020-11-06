//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationInformationTopControl.xaml.cs
//功能描述(Description)：    术中页面页头信息
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:49:12
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;
using System.Windows.Controls;
namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationInformationTopControl.xaml 的交互逻辑
    /// </summary>
    public partial class OperationInformationTopControl : UserControl
    {
        /// <summary>
        /// Defines the _operationInformationViewModel
        /// </summary>
        internal OperationInformationViewModel _operationInformationViewModel;

        /// <summary>
        /// 构造函数
        /// </summary>
        public OperationInformationTopControl()
        {
            InitializeComponent();
            _operationInformationViewModel = new OperationInformationViewModel();
            this.DataContext = _operationInformationViewModel;
        }

        /// <summary>
        /// ViewModel
        /// </summary>
        public OperationInformationViewModel ViewModel
        {
            get { return _operationInformationViewModel; }
        }
    }
}
