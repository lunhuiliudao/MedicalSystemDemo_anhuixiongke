//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AnesthesiaRouteControl.cs
//功能描述(Description)：    麻醉路径名称保存
//数据表(Tables)：		    无 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.AnesthesiaPathViewModel;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// AnesthesiaRouteControl.xaml 的交互逻辑
    /// </summary>
    public partial class AnesthesiaRouteControl : BaseUserControl
    {
        public AnesthesiaRouteControl()
        {
            InitializeComponent();
            this.DataContext = new SaveAnesthesiaPathViewModel();
        }
    }
}
