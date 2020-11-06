// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      OutRegister.xaml.cs
// 功能描述(Description)：    出室信息确认界面
// 数据表(Tables)：		      无
// 作者(Author)：             孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.InHospitalRegisterViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// OutRegister.xaml 的交互逻辑
    /// </summary>
    public partial class OutRegister : BaseUserControl
    {
        private OutHospitalRegisterViewModel outHospitalRegisterViewModel = null;                    // 对应的ViewModel

        /// <summary>
        /// 构造方法，焦点默认定位到下一步按钮
        /// </summary>
        public OutRegister()
        {
            InitializeComponent();
            this.outHospitalRegisterViewModel = new OutHospitalRegisterViewModel();
            this.DataContext = this.outHospitalRegisterViewModel;
            btnNext.Focus();
        }

        /// <summary>
        /// 重置按钮
        /// </summary>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)delegate
            {
                this.txtReason.Focus();
            }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        /// <summary>
        /// 响应Up按键
        /// </summary>
        private void BaseUserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Prior)
            {
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    this.txtReason.Focus();
                }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            }
        }
    }
}
