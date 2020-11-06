using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// AssayReport.xaml 的交互逻辑
    /// </summary>
    public partial class AnesFree : BaseUserControl
    {
        private bool isFirstIntoDataCell = false;                                      // 焦点首次进入单元格
        private AnesFreeViewModel anesFreeViewModel = null;                            // 界面对应的ViewModel         

        /// <summary>
        /// 无参构造
        /// </summary>
        public AnesFree()
        {
            InitializeComponent();
            this.anesFreeViewModel = new AnesFreeViewModel(ExtendAppContext.Current.PatientInformationExtend);
            this.DataContext = this.anesFreeViewModel;
        }

        /// <summary>
        /// 剂量、数量 文本框单元格事件，为了可录入小数点，在界面上使用的UpdateSourceTrigger=LostFocus
        /// </summary>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            bool isFirstInto = this.isFirstIntoDataCell;
            if (this.isFirstIntoDataCell)
            {
                this.isFirstIntoDataCell = false;
            }

            // 第一次进入设置成全选文本
            if (isFirstInto)
            {
                tb.SelectAll();
            }
            else if (tb.Text.LastIndexOf('.') != tb.Text.Length - 1)
            {
                // 当前文本绑定是lostfocus，会导致直接保存失效，所以在textchanged事件中手动绑定
                BindingExpression be = tb.GetBindingExpression(TextBox.TextProperty);
                be.UpdateSource();
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            this.isFirstIntoDataCell = false;
        }

        /// <summary>
        /// 单元格获得焦点进入编辑状态时触发的事件
        /// 备注：如果单元格的值为空或者值不属于下拉框中的任何一项，则不会触发TextChanged和SelectionChanged
        /// </summary>
        private void Datagrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (this.dataGrid.SelectedIndex > -1)
            {
                DataGridCellInfo curCellInfo = this.dataGrid.CurrentCell;
                this.isFirstIntoDataCell = true;
            }
        }
        private void cbItemClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cbItemName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object obj = (object)e.AddedItems;
            if (obj != null && ((object[])(obj)).Length > 0)
            {
                MED_VALUATION_ITEM_LIST row = ((MED_VALUATION_ITEM_LIST)(((object[])(obj))[0]));
                anesFreeViewModel.ChargItemChange(row);
            }
        }

        private void cbAnesType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object obj = (object)e.AddedItems;
            if (obj != null && ((object[])(obj)).Length > 0)
            {
                string itemClass = ((MED_BILL_ITEM_CLASS_DICT)(((object[])(obj))[0])).BILL_CLASS_CODE;
                anesFreeViewModel.TypeChange(itemClass);
            }
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        private void ButtonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            int rowIndex = this.dataGrid.SelectedIndex;
            this.anesFreeViewModel.DeleteItemClickCommon.Execute(this.dataGrid.SelectedItem);
            this.ResetDataGridSelected(rowIndex);
        }
        /// <summary>
        /// 重置列表选中行
        /// </summary>
        private void ResetDataGridSelected(int rowIndex)
        {
            // 设置选中行
            if (this.dataGrid.Items.Count > 0)
            {
                if (this.dataGrid.Items.Count > rowIndex)
                {
                    this.dataGrid.SelectedIndex = rowIndex;
                }
                else if (this.dataGrid.Items.Count == rowIndex)
                {
                    this.dataGrid.SelectedIndex = this.dataGrid.Items.Count - 1;
                }
            }
        }
        /// <summary>
        /// 加在行设置行背景色以及是否可修改
        /// </summary>
        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            MED_ANES_VALUATION_LIST row = (MED_ANES_VALUATION_LIST)(e.Row.Item);
            if (row != null && row.STATUS.HasValue && (row.STATUS == 1 || row.STATUS == 2))
            {
                e.Row.IsEnabled = false;
                e.Row.Background = Brushes.Gainsboro;
            }
        }
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            anesFreeViewModel.SubmitCommon.Execute("");
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                DataGridRow gridRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(i);
                if (gridRow != null)
                {
                    MED_ANES_VALUATION_LIST row = (MED_ANES_VALUATION_LIST)(gridRow.Item);
                    if (row != null && row.STATUS.HasValue && row.STATUS == 1)
                    {
                        gridRow.IsEnabled = false;
                        gridRow.Background = Brushes.Gainsboro;
                    }
                }
            }
        }
    }
}
