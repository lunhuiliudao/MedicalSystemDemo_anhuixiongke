//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationOutputNoteControl.xaml.cs
//功能描述(Description)：    术中右击界面新增或修改用药 麻药 输液 
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:49:12
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.PopupControlViewModel;
using System.Collections.Generic;
using System.Windows.Documents;

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationOutputNoteControl.xaml 的交互逻辑
    /// </summary>
    public partial class OperationOutputNoteControl : BaseUserControl
    {
        OperationOutputNoteControlViewModel _operationOutPutControl = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public OperationOutputNoteControl()
        {
            InitializeComponent();
            _operationOutPutControl = new OperationOutputNoteControlViewModel();
            this.DataContext = _operationOutPutControl;
            List<object> lo = new List<object>();
            lo.Add("1");
            lo.Add("1");
            lo.Add("1");
            lo.Add("1");
            lo.Add("1");
            this.datagrid.ItemsSource = lo;
        }
    }
}
