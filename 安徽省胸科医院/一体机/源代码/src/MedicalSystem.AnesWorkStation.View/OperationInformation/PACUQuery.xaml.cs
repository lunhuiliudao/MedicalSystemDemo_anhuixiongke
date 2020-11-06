//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      PACUQuery.xaml.cs
//功能描述(Description)：    入复苏室信息查询
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 15:23:35
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.ViewModel.OperationInformationViewModel;
namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// PACUQuery.xaml 的交互逻辑
    /// </summary>
    public partial class PACUQuery : BaseUserControl
    {
        PACUQueryViewModel pacuQueryViewModel = null;
        /// <summary>
        /// 构造方法
        /// </summary>
        public PACUQuery()
        {
            InitializeComponent();
            this.pacuQueryViewModel = new PACUQueryViewModel();
            this.DataContext = pacuQueryViewModel;
        }
    }
}
