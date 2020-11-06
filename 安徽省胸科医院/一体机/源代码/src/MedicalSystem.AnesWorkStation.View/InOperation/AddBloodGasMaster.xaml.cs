//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AddBloodGasMaster.cs
//功能描述(Description)：    血气类型设置界面
//数据表(Tables)：		    无 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.BloodGasAnalysisViewModel;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// AddBloodGasMaster.xaml 的交互逻辑
    /// </summary>
    public partial class AddBloodGasMaster : BaseUserControl
    {
        private AddBloodGasMasterViewModel addBloodGasMasterViewModel = null; 

        /// <summary>
        /// 构造方法
        /// </summary>
        public AddBloodGasMaster()
        {
            InitializeComponent();
            this.addBloodGasMasterViewModel = new AddBloodGasMasterViewModel(ExtendAppContext.Current.PatientInformationExtend);
            this.DataContext = this.addBloodGasMasterViewModel;
            this.operatorList.SelectedValue = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
            this.operatorList.Text = ExtendAppContext.Current.LoginUser.USER_NAME;
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string res = (bool)this.rbDongMai.IsChecked ? "动脉" : string.Empty;
            this.addBloodGasMasterViewModel.AddBloodGasMasterRecord(this.operatorList.SelectedValue, res);
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.addBloodGasMasterViewModel.CancelAddBloodGasMasterRecord();
        }
    }
}
