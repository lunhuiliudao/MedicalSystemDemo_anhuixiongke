//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      SignSwicthControl.cs
//功能描述(Description)：    个性化体征项目配置（1）
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:30
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// SignSwicthControl.xaml 的交互逻辑
    /// </summary>
    public partial class SignSwicthControl : BaseUserControl
    {
        public SignSwicthControl()
        {
            InitializeComponent();

            this.DataContext = new SignSwicthControlViewModel();
        }
    }
}
