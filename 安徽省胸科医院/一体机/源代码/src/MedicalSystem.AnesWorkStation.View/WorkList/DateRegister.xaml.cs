using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.Model;
// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      DateRegister.xaml.cs
// 功能描述(Description)：    手术流程时间控件
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.InHospitalRegisterViewModel;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// DateRegister.xaml 的交互逻辑
    /// </summary>
    public partial class DateRegister : BaseUserControl
    {
        private DateRegisterViewModel dateRegisterViewModel = null;           // 控件对应的ViewModel

        /// <summary>
        /// 构造方法，定义ViewModel和DataContext
        /// </summary>
        public DateRegister()
        {
            InitializeComponent();
            this.dateRegisterViewModel = new DateRegisterViewModel();
            this.DataContext = this.dateRegisterViewModel;
            this.RegistManager();
        }

        private void RegistManager()
        {
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshDateRegisterFocus, msg =>
            {
                this.Focus();
            });
        }
    }
}
