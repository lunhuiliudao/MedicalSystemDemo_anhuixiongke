//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationRescue.xaml.cs
//功能描述(Description)：    按第二次抢救按钮 代表抢救结束弹出此页面
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 14:40:45
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝ 
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;
using System;
namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{

    /// <summary>
    /// OperationRescue.xaml 的交互逻辑
    /// </summary>
    public partial class OperationRescue : BaseUserControl
    {
        private OperationRescueViewModel operationRescueViewModel = null;


        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationRescue()
        {
            InitializeComponent();
            this.operationRescueViewModel = new OperationRescueViewModel(ExtendAppContext.Current.PatientInformationExtend,
                                                                         ExtendAppContext.Current.OperationRescueStartTime,
                                                                         DateTime.Now,
                                                                         this.mainGird);
            this.DataContext = this.operationRescueViewModel;
        }
    }
}
