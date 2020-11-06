// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      WeekSurgery.xaml.cs
// 功能描述(Description)：    一周手术信息面板
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel;
using System.Windows.Controls;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// WeekSurgery.xaml 的交互逻辑
    /// </summary>
    public partial class WeekSurgery : UserControl
    {
        private WeekSurgeryViewModel weekSurgeryViewModel = null;              // 界面对应的ViewModel

        /// <summary>
        /// 构造方法
        /// </summary>
        public WeekSurgery()
        {
            InitializeComponent();
            this.weekSurgeryViewModel = new WeekSurgeryViewModel();
            this.DataContext = this.weekSurgeryViewModel;
        }
    }
}
