//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      BloodGasAnalysisControl.cs
//功能描述(Description)：    血气
//数据表(Tables)：		    无 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.BloodGasAnalysisViewModel;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// BloodGasAnalysisControl.xaml 的交互逻辑
    /// </summary>
    public partial class BloodGasAnalysisControl : BaseUserControl
    {
        private BloodGasAnalysisViewModel bloodGasAnalysisViewModel = null;

        public BloodGasAnalysisControl()
        {
            InitializeComponent();
            this.bloodGasAnalysisViewModel = new BloodGasAnalysisViewModel(ExtendAppContext.Current.PatientInformationExtend, "0");
            this.DataContext = this.bloodGasAnalysisViewModel;
            this.RegisterCommand();
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        private void RegisterCommand()
        {
            // 增加血气成功后刷新左侧列表信息
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshBloodGasMasterSelection, msg =>
            {
                this.dgMaster.SelectedItem = msg;
            });
        }
    }
}
