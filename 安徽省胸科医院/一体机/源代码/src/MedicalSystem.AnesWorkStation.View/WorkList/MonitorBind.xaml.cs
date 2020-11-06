// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      MonitorBind.xaml.cs
// 功能描述(Description)：    绑定监护仪界面
// 数据表(Tables)：		      无
// 作者(Author)：             孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.MonitorBindViewModel;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// MonitorBind.xaml 的交互逻辑
    /// </summary>
    public partial class MonitorBind : BaseUserControl
    {
        private MonitorBindViewModel monitorBindViewModel = null;                         // 界面对应的ViewModel

        public MonitorBind()
        {
            InitializeComponent();
            this.monitorBindViewModel = new MonitorBindViewModel();
            this.DataContext = this.monitorBindViewModel;
        }
    }
}
