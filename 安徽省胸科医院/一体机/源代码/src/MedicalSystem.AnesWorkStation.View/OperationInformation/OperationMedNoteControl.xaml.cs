//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationMedNoteControl.xaml.cs
//功能描述(Description)：    术中用药、麻药、输液、出液、输血页面
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:49:12
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.AnesEventEditorModel;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.AnesEventEditorViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.AnesWorkStation.Wpf.Helper;
using MedicalSystem.AnesWorkStation.Wpf.Themes.Default;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationMedNoteControl.xaml 的交互逻辑
    /// </summary>
    public partial class OperationMedNoteControl : BaseUserControl
    {
        private AnesDrugEditorViewModel anesDrugEditorViewModel = null;                               // 对应的ViewModel
        private bool isDataGridPreviewMouseLeftButtonDown = false;                                    // 当前表格鼠标是否按下
        private bool isFirstIntoDataCell = false;                                                     // 焦点首次进入单元格
        private int cbCellNextColumnIndex = -1;                                                       // 下拉框单元格弹出下拉框后下个单元格的位置，是前一个还是后一个单元格 
        //public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(List<AnesEventEditorModel>), typeof(OperationMedNoteControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));
        //public List<AnesEventEditorModel> Data
        //{
        //    get { return (List<AnesEventEditorModel>)GetValue(DataProperty); }
        //    set { SetValue(DataProperty, value); }
        //}
        /// <summary>
        /// 构造函数
        /// </summary>
        public OperationMedNoteControl()
        {
            InitializeComponent();
            if (!ExtendAppContext.Current.IsModify || !ExtendAppContext.Current.IsPermission)
            {
                this.datagrid.IsReadOnly = true;
            }

            this.anesDrugEditorViewModel = new AnesDrugEditorViewModel();
            this.DataContext = this.anesDrugEditorViewModel;

            this.RegistMessenger();

            // 默认搜索框获得焦点
            this.txtBoxSearch.Focus();
        }

        /// <summary>
        /// 注册响应消息
        /// </summary>
        private void RegistMessenger()
        {
            // 重置界面焦点
            Messenger.Default.Register<object>(this, EnumMessageKey.ResetOperationMedNoteControlFocus, msg =>
            {
                if (msg != null && msg is int && (int)msg > -1)
                {
                    this.ResetDataGridSelected((int)msg);
                }
                else
                {
                    this.ResetSearchBoxFocus();
                }
            });

            Messenger.Default.Register<string>(this, EnumMessageKey.RefreshOperEventWindowTitle, msg =>
            {
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    Window.GetWindow(this).Title = msg;
                    this.txtBoxSearch.Text = "";
                    this.txtBoxSearch.Focus();
                    this.anesDrugEditorViewModel.IsChangeOperEventing = false;
                }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            });
        }

        /// <summary>
        /// 将焦点定位到搜索框
        /// </summary>
        private void ResetSearchBoxFocus()
        {
            this.Dispatcher.BeginInvoke((Action)delegate
            {
                this.txtBoxSearch.Focus();
                this.txtBoxSearch.SelectAll();
            }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            List<MED_EVENT_DICT> tem = this.anesDrugEditorViewModel.DrugDictData;
            this.anesDrugEditorViewModel.DrugDictData = null;
            this.anesDrugEditorViewModel.DrugDictData = tem;
        }

        /// <summary>
        /// 搜索框响应方向键
        /// </summary>
        private void TxtBoxSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && this.lvMed.Items.Count > 0)
            {
                // 往下进入字典列表
                e.Handled = true;
                this.lvMed.Focus();
                this.lvMed.SelectedIndex = 0;
                SelectorControlHelper.SetItemFocus(this.lvMed, this.lvMed.SelectedItem);
            }
            else if (e.Key == Key.Right && this.datagrid.Items.Count > 0)
            {
                // 往右进入表格
                e.Handled = true;
                this.datagrid.Focus();
                this.datagrid.SelectedIndex = 0;
                // 焦点定位到第一行的开始时间单元格
                DataGridCell timeCell = DataGridStyle.GetCell(this.datagrid, 0, 2);
                if (timeCell != null)
                {
                    this.datagrid.CurrentCell = new DataGridCellInfo(timeCell);
                    this.datagrid.BeginEdit();
                }
            }
        }

        /// <summary>
        /// 列表响应方向键
        /// </summary>
        private void LvMed_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && this.lvMed.SelectedIndex == 0)
            {
                e.Handled = true;
                this.txtBoxSearch.Focus();
            }
            else if (e.Key == Key.Enter && null != this.lvMed.SelectedItem)
            {
                e.Handled = true;
                this.anesDrugEditorViewModel.LeftDrugDoubleClick.Execute(this.lvMed.SelectedItem);
            }
            else if (e.Key == Key.Right && this.lvInCount.Items.Count > 0)
            {
                e.Handled = true;
                this.lvInCount.Focus();
                this.lvInCount.SelectedIndex = 0;
                SelectorControlHelper.SetItemFocus(this.lvInCount, this.lvInCount.SelectedItem);
            }
        }

        /// <summary>
        /// 响应按键
        /// </summary>
        private void LvInCount_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && null != this.lvInCount.SelectedItem)
            {
                e.Handled = true;
                this.anesDrugEditorViewModel.RefenceDosageClick.Execute(this.lvInCount.SelectedItem);
            }
            else if (e.Key == Key.Left && this.lvInCount.SelectedIndex == 0)
            {
                e.Handled = true;
                int tempLvMedSelectedIndex = this.lvMed.SelectedIndex;
                if (tempLvMedSelectedIndex > -1)
                {
                    this.lvMed.Focus();
                    List<MED_EVENT_DICT> tempList = this.anesDrugEditorViewModel.DrugDictData;
                    this.anesDrugEditorViewModel.DrugDictData = null;
                    this.anesDrugEditorViewModel.DrugDictData = tempList;
                    this.lvMed.SelectedIndex = tempLvMedSelectedIndex;
                    SelectorControlHelper.SetItemFocus(this.lvMed, this.lvMed.SelectedItem);
                }
                else
                {
                    this.ResetSearchBoxFocus();
                }
            }
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        private void ButtonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            int rowIndex = this.datagrid.SelectedIndex;
            this.anesDrugEditorViewModel.DeleteItemClick.Execute(this.datagrid.SelectedItem);
            this.ResetDataGridSelected(rowIndex);
        }

        /// <summary>
        /// 重置列表选中行
        /// </summary>
        private void ResetDataGridSelected(int rowIndex)
        {
            // 设置选中行
            if (this.datagrid.Items.Count > 0)
            {
                if (this.datagrid.Items.Count > rowIndex)
                {
                    this.datagrid.SelectedIndex = rowIndex;
                }
                else if (this.datagrid.Items.Count == rowIndex)
                {
                    this.datagrid.SelectedIndex = this.datagrid.Items.Count - 1;
                }

                // 焦点定位到开始时间
                DataGridCell timeCell = DataGridStyle.GetCell(this.datagrid, this.datagrid.SelectedIndex, 2);
                if (timeCell != null)
                {
                    this.datagrid.CurrentCell = new DataGridCellInfo(timeCell);
                    this.datagrid.BeginEdit();
                }
            }
            else
            {
                this.ResetSearchBoxFocus();
            }
        }

        /// <summary>
        /// 表格按键事件响应
        /// </summary>
        private void Datagrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (this.datagrid.Tag == null || !this.datagrid.Tag.ToString().Equals("NoPreviewKeyDown"))
            {
                if (e.Key == Key.Enter)
                {
                    int rowIndex = this.datagrid.SelectedIndex;
                    DataGridCellInfo cellInfo = this.datagrid.CurrentCell;
                    if (null != cellInfo && null != cellInfo.Column)
                    {
                        if (rowIndex == this.datagrid.Items.Count - 1 && cellInfo.Column.DisplayIndex == this.datagrid.Columns.Count - 1)
                        {
                            // 在最后一个单元格点击回车进入搜索框
                            this.datagrid.SelectedIndex = -1;
                            this.ResetSearchBoxFocus();
                        }
                        else if (rowIndex > -1 && cellInfo.Column.DisplayIndex == 0)
                        {
                            // 第一列，删除事件
                            e.Handled = true;
                            this.ButtonDeleteItem_Click(null, null);
                            // 焦点定位到开始时间
                            DataGridCell timeCell = DataGridStyle.GetCell(this.datagrid, this.datagrid.SelectedIndex, 2);
                            if (timeCell != null)
                            {
                                this.datagrid.CurrentCell = new DataGridCellInfo(timeCell);
                                this.datagrid.BeginEdit();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 单元格获得焦点进入编辑状态时触发的事件
        /// 备注：如果单元格的值为空或者值不属于下拉框中的任何一项，则不会触发TextChanged和SelectionChanged
        /// </summary>
        private void Datagrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (this.datagrid.SelectedIndex > -1)
            {
                DataGridCellInfo curCellInfo = this.datagrid.CurrentCell;
                if (curCellInfo.Column.DisplayIndex >= 3 && curCellInfo.Column.DisplayIndex <= 10)
                {
                    this.isFirstIntoDataCell = true;
                }
            }
        }

        /// <summary>
        /// 剂量文本框事件
        /// </summary>
        private void TbDosage_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.TextBoxTextChangedEvent(sender as TextBox);
        }

        /// <summary>
        /// 浓度文本框
        /// </summary>
        private void TbConcentration_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.TextBoxTextChangedEvent(sender as TextBox);
        }

        /// <summary>
        /// 速度文本框
        /// </summary>
        private void TbSpeed_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.TextBoxTextChangedEvent(sender as TextBox);
        }

        /// <summary>
        /// 特殊文本框文本事件
        /// </summary>
        private void TextBoxTextChangedEvent(TextBox tb)
        {
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

            this.isDataGridPreviewMouseLeftButtonDown = false;
        }

        /// <summary>
        /// 剂量单位下拉框
        /// </summary>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            bool isFirstInto = this.isFirstIntoDataCell;
            if (this.isFirstIntoDataCell)
            {
                this.isFirstIntoDataCell = false;
            }

            // 持续下拉框,如果是鼠标进入单元格则无需联动时间
            if (cb.Name.Equals("cbDurativeIndicator") && !this.isDataGridPreviewMouseLeftButtonDown)
            {
                if (cb.SelectedIndex == 1 && null == ((MED_ANESTHESIA_EVENT)this.datagrid.SelectedItem).END_TIME)
                {
                    this.anesDrugEditorViewModel.SelectItem.END_TIME = DateTime.MinValue;
                }
                else if (cb.SelectedIndex == 0)
                {
                    this.anesDrugEditorViewModel.SelectItem.END_TIME = null;
                }
            }

            // 第一次进入触发 ComboBox_DropDownOpened
            if (isFirstInto)
            {
                cb.Focus();
                cb.IsDropDownOpen = true;
            }
        }

        /// <summary>
        /// 下拉框弹出时不响应DataGrid的按键事件
        /// </summary>
        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            this.datagrid.Tag = "NoPreviewKeyDown";
            this.SetCbCellColumnIndex(true);
        }

        /// <summary>
        /// 下拉框关闭时恢复响应DataGrid的按键事件
        /// </summary>
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            // 恢复表格响应PreviewKeyDown事件
            this.datagrid.Tag = null;

            // 进入往右的下一单元格
            this.datagrid.Focus();

            // 当前选中行的持续状态为0时，则焦点定位到搜索框中
            if (this.cbCellNextColumnIndex == 11 && this.anesDrugEditorViewModel.SelectItem.DURATIVE_INDICATOR == 0)
            {
                this.ResetSearchBoxFocus();
            }
            else
            {
                DataGridCell timeCell = DataGridStyle.GetCell(this.datagrid, this.datagrid.SelectedIndex, this.cbCellNextColumnIndex);
                if (timeCell != null)
                {
                    this.datagrid.CurrentCell = new DataGridCellInfo(timeCell);
                    this.datagrid.BeginEdit();
                }
            }

            // 重新设置下数据
            this.cbCellNextColumnIndex = -1;
            this.isDataGridPreviewMouseLeftButtonDown = false;
        }

        /// <summary>
        /// 剂量单位单元格响应方向键
        /// </summary>
        private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (e.Key == Key.Left || e.Key == Key.Right)
            {
                e.Handled = true;
                if (e.Key == Key.Left)
                {
                    this.SetCbCellColumnIndex(false);
                }
                else
                {
                    this.SetCbCellColumnIndex(true);
                }

                cb.IsDropDownOpen = false;
            }
        }

        /// <summary>
        /// 设置下拉框的下一个单元格位置
        /// </summary>
        /// <param name="cb"></param>
        private void SetCbCellColumnIndex(bool isNext)
        {
            if (this.isDataGridPreviewMouseLeftButtonDown)
            {
                this.cbCellNextColumnIndex = -1;
            }
            else if (isNext) // 往右进入下个单元格
            {
                DataGridCellInfo cellInfo = this.datagrid.CurrentCell;
                if (null != cellInfo && cellInfo.Column.DisplayIndex < this.datagrid.Columns.Count)
                {
                    int tempDisplayIndex = cellInfo.Column.DisplayIndex;
                    while (this.datagrid.Columns[tempDisplayIndex + 1].Visibility != System.Windows.Visibility.Visible)
                    {
                        tempDisplayIndex++;
                        if (tempDisplayIndex >= this.datagrid.Columns.Count)
                        {
                            return;
                        }
                    }

                    this.cbCellNextColumnIndex = tempDisplayIndex + 1;
                }
            }
            else if (!isNext) // 往左进入上一个单元格
            {
                DataGridCellInfo cellInfo = this.datagrid.CurrentCell;
                if (null != cellInfo && cellInfo.Column.DisplayIndex > 0)
                {
                    int tempDisplayIndex = cellInfo.Column.DisplayIndex;
                    while (this.datagrid.Columns[tempDisplayIndex - 1].Visibility != System.Windows.Visibility.Visible)
                    {
                        tempDisplayIndex--;
                        if (tempDisplayIndex <= 0)
                        {
                            return;
                        }
                    }
                    this.cbCellNextColumnIndex = tempDisplayIndex - 1;
                }
            }
        }

        /// <summary>
        /// 文本框按键事件
        /// </summary>
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            this.isFirstIntoDataCell = false;
        }

        /// <summary>
        /// 表格滚动条
        /// </summary>
        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (null != this.datagrid.SelectedItem)
            {
                this.datagrid.ScrollIntoView(this.datagrid.SelectedItem);
            }
        }

        /// <summary>
        /// 搜索框获得焦点时，重置下左侧列表的数据源，实现重绘功能
        /// </summary>
        private void TxtBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.lvMed.Items.Count > 0)
            {
                List<MED_EVENT_DICT> tempList = this.anesDrugEditorViewModel.DrugDictData;
                this.anesDrugEditorViewModel.DrugDictData = null;
                this.anesDrugEditorViewModel.DrugDictData = tempList;
            }
        }

        /// <summary>
        /// 表格鼠标单击事件
        /// </summary>
        private void Datagrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.isDataGridPreviewMouseLeftButtonDown = true;
        }

        /// <summary>
        /// 下拉框鼠标选择要断开联动
        /// </summary>
        private void ComboBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.isDataGridPreviewMouseLeftButtonDown = true;
            this.SetCbCellColumnIndex(false);
        }
    }
}
