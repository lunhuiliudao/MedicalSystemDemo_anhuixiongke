// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      OperatingPatient.xaml.cs
// 功能描述(Description)：    正在手术的患者信息界面
// 数据表(Tables)：		      无
// 作者(Author)：             孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// OperatingPatient.xaml 的交互逻辑
    /// </summary>
    public partial class OperatingPatient : UserControl
    {
        private OperatingPatientViewModel patientVM = null;                                    // 当前患者的ViewModel

        /// <summary>
        /// 无参构造方法
        /// </summary>
        public OperatingPatient()
        {
            InitializeComponent();
            // 设置控件可以接收焦点
            this.Focusable = true;
            this.patientVM = new OperatingPatientViewModel();
            this.DataContext = this.patientVM;
        }

        /// <summary>
        /// 选中
        /// </summary>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Messenger.Default.Send<object>(typeof(OperatingPatient), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
            if (this.HasOperatingPatient())
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 当前是否有患者正在手术
        /// </summary>
        public bool HasOperatingPatient()
        {
            return this.patientVM.CurPatientModel != null;
        }
    }
}
