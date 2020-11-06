//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      IndividuationVitalSignControl.cs
//功能描述(Description)：    个性化体征（二）
//数据表(Tables)：		    无 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;
using System.Windows.Controls;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// IndividuationVitalSignControl.xaml 的交互逻辑
    /// </summary>
    public partial class IndividuationVitalSignControl : BaseUserControl
    {
        private bool isFirstIntoInput = false;

        public IndividuationVitalSignControl()
        {
            InitializeComponent();
            this.DataContext = new IndividuationVitalSignViewModel();
        }

        private void datagrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataGridCellInfo curCellInfo = this.datagrid.CurrentCell;
            if ((curCellInfo.Column.DisplayIndex == 1 || curCellInfo.Column.DisplayIndex == 2 || curCellInfo.Column.DisplayIndex == 3 ||
                curCellInfo.Column.DisplayIndex == 4 || curCellInfo.Column.DisplayIndex == 5) && this.datagrid.SelectedIndex > -1)
            {
                this.isFirstIntoInput = true;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isFirstInto = false;
            ComboBox cb = sender as ComboBox;
            isFirstInto = this.isFirstIntoInput;
            if (this.isFirstIntoInput)
            {
                this.isFirstIntoInput = false;
            }
            if (isFirstInto)
            {
                cb.Focus();
                cb.IsDropDownOpen = true;
            }
        }
    }
}
