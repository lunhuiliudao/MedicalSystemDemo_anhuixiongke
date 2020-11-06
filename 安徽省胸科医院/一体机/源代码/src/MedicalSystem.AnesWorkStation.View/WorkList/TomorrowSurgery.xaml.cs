// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      TomorrowSurgery.xaml.cs
// 功能描述(Description)：    明日手术信息面板
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
    /// TomorrowSurgery.xaml 的交互逻辑
    /// </summary>
    public partial class TomorrowSurgery : UserControl
    {
        private TomorrowSurgeryViewModel tomSurgeryViewModel = null;           // 界面对应的ViewModel

        /// <summary>
        /// 构造方法
        /// </summary>
        public TomorrowSurgery()
        {
            InitializeComponent();
            this.tomSurgeryViewModel = new TomorrowSurgeryViewModel();
            this.DataContext = this.tomSurgeryViewModel;
        }
    }
}
