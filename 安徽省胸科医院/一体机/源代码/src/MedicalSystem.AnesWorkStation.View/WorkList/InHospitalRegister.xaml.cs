// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      InHospitalRegister.xaml.cs
// 功能描述(Description)：    入室登记界面
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
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// InHospitalRegister.xaml 的交互逻辑
    /// </summary>
    public partial class InHospitalRegister : BaseUserControl
    {
        private InHospitalRegisterViewModel inHospitalRegisterViewModel = null;                     // 界面对应的ViewmModel

        /// <summary>
        /// 构造方法：定义ViewModel和DataContext，同时焦点默认定位到下一步按钮
        /// </summary>
        public InHospitalRegister()
        {
            InitializeComponent();
            this.inHospitalRegisterViewModel = new InHospitalRegisterViewModel();
            this.DataContext = this.inHospitalRegisterViewModel;
            this.btnNext.Focus();
        }

        /// <summary>
        /// 按键事件，当点击向上Up键时焦点定位到下一步按钮
        /// </summary>
        private void BaseUserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Prior)
            {
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    this.btnNext.Focus();
                }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            }
        }
    }
}
