//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      UnPostPDFControl.cs
//功能描述(Description)：    批量归档
//数据表(Tables)：		     无 
//作者(Author)：             许文龙
//日期(Create Date)：        2018/08/01 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// UnPostPDFControl.xaml 的交互逻辑
    /// </summary>
    public partial class UnPostPDFControl : BaseUserControl
    {
        private UnPostPDFControlViewModel unPostPDFControlViewModel = null;

        public UnPostPDFControl()
        {
            InitializeComponent();
            this.RegisterCommand();
            this.unPostPDFControlViewModel = new UnPostPDFControlViewModel(ExtendAppContext.Current.LoginUser.USER_JOB_ID);
            this.DataContext = this.unPostPDFControlViewModel;
            this.RegisterCommand();
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        private void RegisterCommand()
        {
            // 设置批量归档界面中的进度条显示与否
            Messenger.Default.Register<bool>(this, EnumMessageKey.SetUnPostPDFProbarShow, msg =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if(msg)
                    {
                        // 进入归档流程，设置按钮的状态
                        this.probar.Visibility = System.Windows.Visibility.Visible;
                        this.btnAllPost.IsEnabled = false;
                        this.btnCancel.IsEnabled = false;
                        this.dgMain.IsEnabled = false;
                    }
                    else
                    {
                        // 归档完成
                        this.probar.Visibility = System.Windows.Visibility.Collapsed;
                        this.btnAllPost.IsEnabled = true;
                        this.btnCancel.IsEnabled = true;
                        this.dgMain.IsEnabled = true;
                    }
                });
            });
        }
    }
}
