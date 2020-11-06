//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationEventNoteControl.xaml.cs
//功能描述(Description)：    术中事件、呼吸录入页面
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:19:46
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.AnesEventEditorViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Helper;
using MedicalSystem.AnesWorkStation.Wpf.Themes.Default;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// OperationEventNoteControl.xaml 的交互逻辑
    /// </summary>
    public partial class OperationEventNoteControl : BaseUserControl
    {
        private AnesEventEditorViewModel anesEventEditorViewModel = null;             // 对应ViewModel
        /// <summary>
        /// 构造函数
        /// </summary>
        public OperationEventNoteControl()
        {
            InitializeComponent();
            if (!ExtendAppContext.Current.IsModify || !ExtendAppContext.Current.IsPermission)
            {
                this.dg.IsReadOnly = true;
            }
            this.RegistMessenger();
            this.anesEventEditorViewModel = new AnesEventEditorViewModel();
            this.DataContext = this.anesEventEditorViewModel;
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
                    this.anesEventEditorViewModel.IsChangeOperEventing = false;
                }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            });
        }

        /// <summary>
        /// 将焦点定位到搜索框
        /// </summary>
        private void ResetSearchBoxFocus()
        {
            this.txtBoxSearch.Focus();
            this.txtBoxSearch.SelectAll();
            List<MED_EVENT_DICT> tem = this.anesEventEditorViewModel.EventDictData;
            this.anesEventEditorViewModel.EventDictData = null;
            this.anesEventEditorViewModel.EventDictData = tem;
            this.anesEventEditorViewModel.SelectedIndex = 0;
        }

        /// <summary>
        /// 响应方向键
        /// </summary>
        private void TxtBoxSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && this.Lv.Items.Count > 0)
            {
                e.Handled = true;
                this.Lv.Focus();
                this.Lv.SelectedIndex = 0;
                SelectorControlHelper.SetItemFocus(this.Lv, this.Lv.SelectedItem);
            }
            else if (e.Key == Key.Right && this.dg.Items.Count > 0)
            {
                // 往右进入表格
                e.Handled = true;
                this.dg.Focus();
                this.dg.SelectedIndex = 0;
                // 焦点定位到第一行的开始时间单元格
                DataGridCell timeCell = DataGridStyle.GetCell(this.dg, 0, 2);
                if (timeCell != null)
                {
                    this.dg.CurrentCell = new DataGridCellInfo(timeCell);
                    this.dg.BeginEdit();
                }
            }
        }

        /// <summary>
        /// 列表响应按键事件
        /// </summary>
        private void Lv_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && (this.Lv.SelectedIndex == 0 || this.Lv.SelectedIndex == 1))
            {
                e.Handled = true;
                this.txtBoxSearch.Focus();
            }
            else if (e.Key == Key.Enter && null != this.Lv.SelectedItem)
            {
                e.Handled = true;
                this.anesEventEditorViewModel.LeftEventDoubleClick.Execute(this.Lv.SelectedItem);
            }
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        private void ButtonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && sender is Button)
            {
                DataGridRow rw = DataGridRow.GetRowContainingElement(sender as FrameworkElement);
                MED_ANESTHESIA_EVENT eventRow = rw.Item as MED_ANESTHESIA_EVENT;
                this.dg.SelectedItem = eventRow;
            }

            int rowIndex = this.dg.SelectedIndex;
            this.anesEventEditorViewModel.DeleteItemClick.Execute(this.dg.SelectedItem);
            this.ResetDataGridSelected(rowIndex);
        }

        /// <summary>
        /// 重置列表选中行
        /// </summary>
        private void ResetDataGridSelected(int rowIndex)
        {
            // 设置选中行
            if (this.dg.Items.Count > 0)
            {
                if (this.dg.Items.Count > rowIndex)
                {
                    this.dg.SelectedIndex = rowIndex;
                }
                else if (this.dg.Items.Count == rowIndex)
                {
                    this.dg.SelectedIndex = this.dg.Items.Count - 1;
                }
            }
            else
            {
                this.ResetSearchBoxFocus();
            }
        }

        /// <summary>
        /// 表格响应按键事件
        /// </summary>
        private void Dg_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int rowIndex = this.dg.SelectedIndex;
                DataGridCellInfo cellInfo = this.dg.CurrentCell;
                if (null != cellInfo && null != cellInfo.Column)
                {
                    if (rowIndex == this.dg.Items.Count - 1 && cellInfo.Column.DisplayIndex == this.dg.Columns.Count - 1)
                    {
                        // 在最后一个单元格点击回车进入搜索框
                        e.Handled = true;
                        this.dg.SelectedIndex = -1;
                        this.ResetSearchBoxFocus();
                    }
                    else if (rowIndex > -1 && cellInfo.Column.DisplayIndex == 0)
                    {
                        // 第一列，删除事件
                        e.Handled = true;
                        this.ButtonDeleteItem_Click(null, null);
                        // 焦点定位到
                        DataGridCell timeCell = DataGridStyle.GetCell(this.dg, this.dg.SelectedIndex, 2);
                        if (timeCell != null)
                        {
                            this.dg.CurrentCell = new DataGridCellInfo(timeCell);
                            this.dg.BeginEdit();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 搜索框获得焦点时，重置下左侧列表的数据源，实现重绘功能
        /// </summary>
        private void TxtBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.Lv.Items.Count > 0)
            {
                List<MED_EVENT_DICT> tempList = this.anesEventEditorViewModel.EventDictData;
                this.anesEventEditorViewModel.EventDictData = null;
                this.anesEventEditorViewModel.EventDictData = tempList;
            }
        }

        /// <summary>
        /// 增加时，滚动条自动定位
        /// </summary>
        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (null != this.dg.SelectedItem)
            {
                this.dg.ScrollIntoView(this.dg.SelectedItem);
            }
        }
    }
}
