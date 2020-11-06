//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      ChangeOperRoomNo.xaml
//功能描述(Description)：    切换手术间
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-26 16:12:56
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝ 
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// ChangeOperRoomNo.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeOperRoomNo : BaseUserControl
    {
        /// <summary>
        /// 变量
        /// </summary>
        private ChangeOperRoomNoViewModel changeOperRoomNoViewModel = null;

        /// <summary>
        /// 页面
        /// </summary>
        public ChangeOperRoomNo()
        {
            InitializeComponent();
            this.changeOperRoomNoViewModel = new ChangeOperRoomNoViewModel(ExtendAppContext.Current.PatientInformationExtend);
            this.DataContext = this.changeOperRoomNoViewModel;
        }
    }
}
