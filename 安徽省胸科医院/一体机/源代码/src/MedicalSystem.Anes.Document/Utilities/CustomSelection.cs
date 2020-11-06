/*----------------------------------------------------------------
      // Copyright (C) 2005 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：CustomSelection.cs
      // 文件功能描述：自定义选单-类弹出菜单
      //
      // 
      // 创建标识：戴呈祥-2008-12-11
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Data;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Constants;

namespace MedicalSystem.Anes.Document.Utilities
{
    /// <summary>
    /// 选单类型
    /// </summary>
    public enum ListType
    {
        /// <summary>
        /// ListBox(不建议使用)
        /// </summary>
        ListBox,
        /// <summary>
        /// ListView(不建议使用)
        /// </summary>
        ListView,
        /// <summary>
        /// 采用DataGridView演化而来，变化丰富(建议采用)
        /// </summary>
        DataGridView,
        /// <summary>
        /// 系统弹出菜单
        /// </summary>
        PopupMenu,
        DevGridView,
    }

    /// <summary>
    /// 自定义选择
    /// </summary>
    public class CustomSelection
    {

        private class CustomSelectionListItem
        {
            public CustomSelectionListItem(int index, string displayText, List<string> rowArray)
            {
                _index = index;
                _displayText = displayText;
                _inputCode = StringManage.GetPYString(displayText).ToLower();
                _rowArray = rowArray;
            }
            private string _inputCode;
            public string InputCode
            {
                get
                {
                    return _inputCode;
                }
                set
                {
                    _inputCode = value;
                }
            }
            private string _displayText;
            public string DisplayText
            {
                get
                {
                    return _displayText;
                }
                set
                {
                    _displayText = value;
                }
            }
            private int _index;
            public int Index
            {
                get
                {
                    return _index;
                }
                set
                {
                    _index = value;
                }
            }
            private List<string> _rowArray;
            public List<string> RowArray
            {
                get
                {
                    return _rowArray;
                }
            }
        }

        #region 私有静态方法

        private static Control _callControl = null;
        private static string[] _displayNames = null;
        private static List<CustomSelectionListItem> _listItems = new List<CustomSelectionListItem>();
        private static List<CustomSelectionListItem> _showListItems = new List<CustomSelectionListItem>();

        private static void GenListItems()
        {
            _listItems.Clear();
            int index = 0;
            foreach (object obj in _list)
            {
                Type type = obj.GetType();
                if (_displayNames != null && _displayNames.Length > 0)
                {
                    try
                    {
                        List<string> rowArray = new List<string>();
                        foreach (string dispName in _displayNames)
                        {
                            if (obj is DataRow)
                            {
                                rowArray.Add(((DataRow)obj)[dispName].ToString());
                            }
                            else
                            {
                                rowArray.Add(type.GetProperty(dispName).GetValue(obj, null).ToString());
                            }
                        }
                        if (type.Equals(typeof(DataRow)))
                        {
                            _listItems.Add(new CustomSelectionListItem(index, ((DataRow)obj)[_displayNames[0]].ToString(), rowArray));
                        }
                        else
                        {
                            _listItems.Add(new CustomSelectionListItem(index, type.GetProperty(_displayNames[0]).GetValue(obj, null).ToString(), rowArray));
                        }
                    }
                    catch
                    {
                        _listItems.Add(new CustomSelectionListItem(index, obj.ToString(),null));
                    }
                }
                else
                {
                    _listItems.Add(new CustomSelectionListItem(index, obj.ToString(),null));
                }
                index++;
            }
        }

        private static bool _lock = false;

        private static void SetDataGridViewList(DataGridView dataGridView)
        {
            if (_lock)
            {
                return;
            }
            _lock = true;
            dataGridView.Rows.Clear();
            _showListItems.Clear();
            foreach (CustomSelectionListItem item in _listItems)
            {
                bool flg = false;
                if (!string.IsNullOrEmpty(_filtString) && !item.InputCode.Contains(_filtString.ToLower()))
                {
                    foreach (var it in item.RowArray)
                    {
                        if (it.Contains(_filtString))
                        {
                            flg = true;
                        }
                    }
                    if (!flg)
                    {
                        continue;
                    }
                }
                _showListItems.Add(item);
                if (item.RowArray != null)
                {
                    dataGridView.Rows.Add(item.RowArray.ToArray());
                }
                else
                {
                    dataGridView.Rows.Add(item.DisplayText);
                }
                if (_showListItems.Count > 200)
                {
                    break;
                }
            }
            _lock = false;
        }

        private static void SetDataGridViewList(DevExpress.XtraGrid.Views.Grid.GridView dataGridView,DataTable dataTable)
        {
            if (_lock)
            {
                return;
            }
            _lock = true;
            dataTable.DefaultView.RowFilter = "aabbccdd like '%" +  _filtString + "%'";
            dataGridView.GridControl.DataSource = dataTable;
            _lock = false;
        }

        private static void ShowDataGridView(IEnumerable list, string displayName, Control parent, Point point, Size size, EventHandler eventHandle, bool multiSelect, bool autoCalPoint, DataGridViewCellPaintingEventHandler cellPaintingEventHandle, ContextMenuForm contextMenuForm)
        {
            _callControl = parent;
            DataGridView dataGridView = new DataGridView();
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ColumnHeadersHeight = 18;
            dataGridView.BackgroundColor = dataGridView.DefaultCellStyle.BackColor;
            dataGridView.CellPainting += cellPaintingEventHandle;
            dataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView_CellPainting);
            dataGridView.GridColor = dataGridView.BackgroundColor;
            dataGridView.KeyPress += new KeyPressEventHandler(dataGridView_KeyPress);
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Columns.Add("字典选择器", "字典选择器");
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = false;

            dataGridView.ScrollBars = ScrollBars.Vertical;
            
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Cursor = Cursors.Hand;
            string[] displayNames = null;
            if (displayName != null)
            {
                displayNames = displayName.Split(new char[] { ',', ';' });
                for (int i = 1; i < displayNames.Length; i++)
                {
                    dataGridView.Columns.Add("Column" + i.ToString(), "Column");
                }
                if (dataGridView.Columns.Count > 1)
                    dataGridView.ScrollBars = ScrollBars.Both;
            }
            _displayNames = displayNames;
            GenListItems();
            SetDataGridViewList(dataGridView);

            dataGridView.Resize += new EventHandler(delegate(object sender1, EventArgs e1)
            {
                for (int i = 0; i < dataGridView.Columns.Count - 1; i++)
                {
                    //dataGridView.Columns[i].Width = 120;
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                //Modify by wenpei.x@2014-02-12
                //新增人员选择下拉框显示User_ID，故宽度不应该再有限制
                if (dataGridView.Columns.Count <= 1)
                {
                    int width = dataGridView.Width - 120 * (dataGridView.Columns.Count - 1);
                    if (width < 1)
                    {
                        dataGridView.Columns[dataGridView.Columns.Count - 1].Visible = false;
                    }
                    else
                    {
                        dataGridView.Columns[dataGridView.Columns.Count - 1].Width = width;
                    }   
                }
            });
            dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(delegate(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
                {
                    if (eventHandle != null)
                    {
                        if (multiSelect)
                        {
                            List<int> selectedIndexes = new List<int>();
                            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                            {
                                selectedIndexes.Add(_showListItems[cell.RowIndex].Index);
                            }
                            selectedIndexes.Reverse();
                            eventHandle(selectedIndexes.ToArray(), null);
                            if (dataGridView.Parent != null && dataGridView.Parent is DevExpress.XtraEditors.XtraForm)
                            {
                                (dataGridView.Parent as DevExpress.XtraEditors.XtraForm).Close();
                            }
                            dataGridView.Dispose();
                        }
                    }
                }
            });
            dataGridView.KeyDown += new KeyEventHandler(delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
                    {
                        if (eventHandle != null)
                        {
                            if (multiSelect)
                            {
                                List<int> selectedIndexes = new List<int>();
                                foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                                {
                                    selectedIndexes.Add(_showListItems[cell.RowIndex].Index);
                                }
                                selectedIndexes.Reverse();
                                eventHandle(selectedIndexes.ToArray(), null);
                            }
                            else
                            {
                                eventHandle(_showListItems[dataGridView.CurrentRow.Index].Index, null);
                            }
                        }
                        if (dataGridView.Parent != null && dataGridView.Parent is DevExpress.XtraEditors.XtraForm)
                        {
                            (dataGridView.Parent as DevExpress.XtraEditors.XtraForm).Close();
                        }
                        dataGridView.Dispose();
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    if (dataGridView.Parent != null && dataGridView.Parent is DevExpress.XtraEditors.XtraForm)
                    {
                        (dataGridView.Parent as DevExpress.XtraEditors.XtraForm).Close();
                    }
                    dataGridView.Dispose();
                    if (_callControl != null) _callControl.Focus();
                }
            });
            if (!multiSelect)
            {
                dataGridView.MouseMove += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
                {
                    int rowIndex = dataGridView.HitTest(e.X, e.Y).RowIndex;
                    if (rowIndex >= 0)
                    {
                        dataGridView.CurrentCell = dataGridView.Rows[rowIndex].Cells[0];
                    }
                });
                dataGridView.CellClick += new DataGridViewCellEventHandler(delegate(object sender, DataGridViewCellEventArgs e)
                {
                    if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
                    {
                        if (eventHandle != null)
                        {
                            eventHandle(_showListItems[dataGridView.CurrentRow.Index].Index, null);
                        }
                        try
                        {
                            if (dataGridView.Parent != null && dataGridView.Parent is DevExpress.XtraEditors.XtraForm)
                            {
                                (dataGridView.Parent as DevExpress.XtraEditors.XtraForm).Close();
                            }
                            dataGridView.Dispose();
                        }
                        catch
                        {
                        }
                    }
                });
            }
            if (size.Width < 100) size.Width = 100;
            dataGridView.CellMouseDown += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseDown);
            dataGridView.CellMouseMove += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseMove);
            dataGridView.CellMouseUp += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseUp);

            DevExpress.XtraEditors.XtraForm form = new DevExpress.XtraEditors.XtraForm();
            form.TopMost = true;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = parent.PointToScreen(point);
            form.Size = size;
            //if (parent != null && !(parent is DataGridView))
            //{
            //    form.Width = parent.Width;
            //}
            form.Controls.Add(dataGridView);
            dataGridView.Dock = DockStyle.Fill;
            form.Deactivate += new EventHandler(form_Deactivate);
            form.FormBorderStyle = FormBorderStyle.None;
            if (form.Bottom > Screen.PrimaryScreen.Bounds.Height)
            {
                if (form.Top >= form.Height)
                {
                    form.Top -= form.Height;
                }
                else
                {
                    form.Top = 0;
                }
            }
            form.Show();

            //if (size.Height > dataGridView.RowTemplate.Height * dataGridView.Rows.Count + dataGridView.ColumnHeadersHeight)
            //{
            //    dataGridView.ColumnHeadersVisible = false;
            //    Control parentControl = parent;
            //    Dialog.SetPopup(dataGridView, parent, point, new Size(size.Width, dataGridView.RowTemplate.Height * dataGridView.Rows.Count + 3), autoCalPoint);
            //}
            //else
            //{
            //    Control parentControl = parent;
            //    Dialog.SetPopup(dataGridView, parent, point, size, autoCalPoint);
            //}
        }

        private static void ShowDevGridView(DataTable dataTable, string displayName, Control parent, Point point, Size size, EventHandler eventHandle, bool multiSelect, bool autoCalPoint, DataGridViewCellPaintingEventHandler cellPaintingEventHandle, ContextMenuForm contextMenuForm)
        {
            _callControl = parent;
            DevExpress.XtraGrid.GridControl gridControl = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView dataGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridControl.MainView = dataGridView;
            dataGridView.OptionsView.ShowColumnHeaders = false;
            dataGridView.OptionsView.ShowGroupPanel = false;
            dataGridView.OptionsView.ShowIndicator = false;
            //dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //dataGridView.ColumnHeadersHeight = 18;
            //dataGridView.BackgroundColor = dataGridView.DefaultCellStyle.BackColor;
            //dataGridView.CellPainting += cellPaintingEventHandle;
            //dataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView_CellPainting);
            //dataGridView.GridColor = dataGridView.BackgroundColor;
            dataGridView.KeyPress += new KeyPressEventHandler(dataGridView_KeyPress);
            dataGridView.OptionsBehavior.ReadOnly = true;
            dataGridView.Tag = eventHandle;
            //DevExpress.XtraGrid.Columns.GridColumn column = dataGridView.Columns.Add();
            //column.FieldName = 
            //"字典选择器", "字典选择器");
            //dataGridView.AllowUserToResizeRows = false;
            //dataGridView.AllowUserToResizeColumns = false;
            //dataGridView.ScrollBars = ScrollBars.Vertical;
            //dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView.Cursor = Cursors.Hand;
            string[] displayNames = null;
            string ddd = displayName;
            if (displayName != null)
            {
                displayNames = displayName.Split(new char[] { ',', ';' });
                for (int i = 0; i < displayNames.Length; i++)
                {
                    DevExpress.XtraGrid.Columns.GridColumn column = dataGridView.Columns.Add();
                    column.FieldName = displayNames[i];
                    column.OptionsColumn.AllowEdit = false;
                    column.OptionsFilter.AllowAutoFilter = false;
                    column.OptionsFilter.AllowFilter = false;
                    column.Visible = true;
                    column.VisibleIndex = 0;
                    if (i == 0)
                    {
                        ddd = displayNames[i];
                    }
                }
            }
            _displayNames = displayNames;
            SetDataGridViewList(dataGridView, TransTable(dataTable,ddd));
            //dataGridView.Resize += new EventHandler(delegate(object sender1, EventArgs e1)
            //{
            //    for (int i = 0; i < dataGridView.Columns.Count - 1; i++)
            //    {
            //        dataGridView.Columns[i].Width = 120;
            //    }
            //    int width = dataGridView.Width - 120 * (dataGridView.Columns.Count - 1);
            //    if (width < 1)
            //    {
            //        dataGridView.Columns[dataGridView.Columns.Count - 1].Visible = false;
            //    }
            //    else
            //    {
            //        dataGridView.Columns[dataGridView.Columns.Count - 1].Width = width;
            //    }
            //});
            //dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(delegate(object sender, DataGridViewCellEventArgs e)
            //{
            //    if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
            //    {
            //        if (eventHandle != null)
            //        {
            //            if (multiSelect)
            //            {
            //                List<int> selectedIndexes = new List<int>();
            //                foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            //                {
            //                    selectedIndexes.Add(_showListItems[cell.RowIndex].Index);
            //                }
            //                selectedIndexes.Reverse();
            //                eventHandle(selectedIndexes.ToArray(), null);
            //                if (dataGridView.Parent != null && dataGridView.Parent is DevExpress.XtraEditors.XtraForm)
            //                {
            //                    (dataGridView.Parent as DevExpress.XtraEditors.XtraForm).Close();
            //                }
            //                dataGridView.Dispose();
            //            }
            //        }
            //    }
            //});
            dataGridView.KeyDown +=new KeyEventHandler(dataGridView_KeyDown);
            if (!multiSelect)
            {
                //dataGridView.MouseMove += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
                //{
                //    int rowIndex = dataGridView.get .HitTest(e.X, e.Y).RowIndex;
                //    if (rowIndex >= 0)
                //    {
                //        dataGridView.CurrentCell = dataGridView.Rows[rowIndex].Cells[0];
                //    }
                //});
                //dataGridView.CellClick += new DataGridViewCellEventHandler(delegate(object sender, DataGridViewCellEventArgs e)
                dataGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(delegate(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
                {
                    if (eventHandle != null)
                    {
                        eventHandle(dataGridView.GetDataRow(e.RowHandle), e);
                    }
                    try
                    {
                        if (gridControl.Parent != null && gridControl.Parent is DevExpress.XtraEditors.XtraForm)
                        {
                            (gridControl.Parent as DevExpress.XtraEditors.XtraForm).Close();
                        }
                        dataGridView.Dispose();
                        gridControl.Dispose();
                    }
                    catch
                    {
                    }
                });
            }
            if (size.Width < 100) size.Width = 100;
            //dataGridView.CellMouseDown += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseDown);
            //dataGridView.CellMouseMove += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseMove);
            //dataGridView.CellMouseUp += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseUp);

            DevExpress.XtraEditors.XtraForm form = new DevExpress.XtraEditors.XtraForm();
            form.TopMost = true;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = parent.PointToScreen(point);
            form.Size = size;
            if (parent != null && !(parent is DataGridView))
            {
                form.Width = parent.Width;
            }
            form.Controls.Add(gridControl);
            gridControl.Dock = DockStyle.Fill;
            form.Deactivate += new EventHandler(form_Deactivate);
            form.FormBorderStyle = FormBorderStyle.None;
            if (form.Bottom > Screen.PrimaryScreen.Bounds.Height)
            {
                if (form.Top >= form.Height)
                {
                    form.Top -= form.Height;
                }
                else
                {
                    form.Top = 0;
                }
            }
            form.Width = size.Width;
            form.Show();
        }

        private static void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView dataGridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView != null && dataGridView.SelectedRowsCount > 0)
                {
                    if (dataGridView.Tag == null || !(dataGridView.Tag is EventHandler))
                    {
                        return;
                    }
                    EventHandler eventHandle = dataGridView.Tag as EventHandler;
                    if(eventHandle != null)
                    {
                        //if (multiSelect)
                        //{
                        //    //List<int> selectedIndexes = new List<int>();
                        //    //foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                        //    //{
                        //    //    selectedIndexes.Add(_showListItems[cell.RowIndex].Index);
                        //    //}
                        //    //selectedIndexes.Reverse();
                        //    //eventHandle(selectedIndexes.ToArray(), null);
                        //}
                        //else
                        {
                            
                            eventHandle(dataGridView.GetDataRow(dataGridView.GetSelectedRows()[0]), null);
                        }
                    }
                    dataGridView.KeyPress -= dataGridView_KeyPress;
                    dataGridView.KeyDown -= dataGridView_KeyDown;
                    if (dataGridView.GridControl.Parent != null && dataGridView.GridControl.Parent is DevExpress.XtraEditors.XtraForm)
                    {
                        (dataGridView.GridControl.Parent as DevExpress.XtraEditors.XtraForm).Close();
                    }
                    //dataGridView.GridControl.Dispose();
                    dataGridView.Dispose();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                dataGridView.KeyPress -= dataGridView_KeyPress;
                dataGridView.KeyDown -= dataGridView_KeyDown;
                if (dataGridView.GridControl.Parent != null && dataGridView.GridControl.Parent is DevExpress.XtraEditors.XtraForm)
                {
                    (dataGridView.GridControl.Parent as DevExpress.XtraEditors.XtraForm).Close();
                }
                dataGridView.GridControl.Dispose();
                dataGridView.Dispose();
                if (_callControl != null) _callControl.Focus();
            }
        }

        private static DataTable TransTable(DataTable source,string ddd)
        {
            source.Columns.Add("aabbccdd");
            source.Columns.Add("globalIndex");
            for(int i = 0; i < source.Rows.Count; i ++)
            {
                DataRow row = source.Rows[i];
                if (row[ddd] != System.DBNull.Value && !string.IsNullOrEmpty(row[ddd].ToString()))
                {
                    row["aabbccdd"] = StringManage.GetPYString(row[ddd].ToString()).ToLower();
                }
                else
                {
                    row["aabbccdd"] = "";
                }
                row["globalIndex"] = i;
            }
            return source;
        }

        private static void form_Deactivate(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraEditors.XtraForm).Close();
        }

        private static void dataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            _XX = -1;
        }

        private static void dataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _XX >= 0)
            {
                (sender as DataGridView).Width = _Width + e.X - _XX;
                (sender as DataGridView).Height = _Height + e.Y - _YY + (e.RowIndex + 1) * (sender as DataGridView).RowTemplate.Height ;
            }
        }

        private static int _XX = -1, _YY = -1,_Width = 1,_Height = 1;
       private  static void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex == -1)
            {
                _XX = e.X;
                _YY = e.Y;
                _Width = (sender as DataGridView).Width;
                _Height = (sender as DataGridView).Height;
            }
        }

        private static void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                e.Handled = true;
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
                //e.PaintBackground(e.ClipBounds, true);
                //e.Graphics.DrawString("请选择(" + _filtString + ")", new Font("宋体", 9), Brushes.Red, 0, 3);
                e.Graphics.DrawString(_filtString, new Font("宋体", 9), Brushes.Red, 0, 3);
            };
        }

        static void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is DataGridView)
            {
                DateTime dt = DateTime.Now;
                DataGridView dataGridView = sender as DataGridView;
                if (dataGridView == null) return;
                if (((int)e.KeyChar) == 8)
                {
                    if (_filtString.Length > 0)
                    {
                        _filtString = _filtString.Remove(_filtString.Length - 1);
                    }
                }
                else if (dataGridView.Rows.Count > 0)
                {
                    _filtString = _filtString + e.KeyChar;
                }
                SetDataGridViewList(dataGridView);

                if (string.IsNullOrEmpty(_filtString))
                {
                    dataGridView.ColumnHeadersVisible = false;
                }
                else
                {
                    dataGridView.ColumnHeadersVisible = true;
                }
                System.Diagnostics.Debug.Print(((TimeSpan)(DateTime.Now - dt)).Milliseconds.ToString());
            }
            else if (!e.KeyChar.Equals((char)13) && !e.KeyChar.Equals((char)27) && sender is DevExpress.XtraGrid.Views.Grid.GridView)
            {
                DateTime dt = DateTime.Now;
                DevExpress.XtraGrid.Views.Grid.GridView dataGridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (dataGridView == null) return;
                if (((int)e.KeyChar) == 8)
                {
                    if (_filtString.Length > 0)
                    {
                        _filtString = _filtString.Remove(_filtString.Length - 1);
                    }
                }
                else if (dataGridView.RowCount > 0)
                {
                    _filtString = _filtString + e.KeyChar;
                }
                SetDataGridViewList(dataGridView,dataGridView.GridControl.DataSource as DataTable);
                if (string.IsNullOrEmpty(_filtString))
                {
                    dataGridView.OptionsView.ShowColumnHeaders = false;
                }
                else
                {
                    dataGridView.Columns[0].Caption = _filtString;
                    dataGridView.OptionsView.ShowColumnHeaders = true;
                }
                System.Diagnostics.Debug.Print(((TimeSpan)(DateTime.Now - dt)).Milliseconds.ToString());
            }
        }

        #endregion 私有静态方法

        #region 公有静态方法

        public static void Show(DataTable dataTable, string displayName, Control parent, Point point, Size size, EventHandler eventHandle, bool multiSelect, bool autoCalPoint, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            if (dataTable == null) return;
            _filtString = "";
            _point = point;
            ContextMenuForm contextMenuForm = new ContextMenuForm();
            contextMenuForm.ShowInTaskbar = false;
            ShowDevGridView(dataTable, displayName, parent, point, size, eventHandle, multiSelect, autoCalPoint, cellPaintingEventHandle, contextMenuForm);
        }

       /// <summary>
        /// 弹出选择列表窗体
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="displayName">需要显示的字段</param>
        /// <param name="parent">调用的控件</param>
        /// <param name="point">显示坐标</param>
        /// <param name="size">显示大小</param>
        /// <param name="eventHandle"></param>
        public static void Show(IEnumerable list, string displayName, Control parent, Point point, Size size, EventHandler eventHandle, ListType listType, bool multiSelect, bool autoCalPoint, DataGridViewCellPaintingEventHandler cellPaintingEventHandle)
        {
            if (list == null) return;
            IEnumerator en = list.GetEnumerator();
            if (!en.MoveNext()) return;
            if (en.Current == null) return;
            _list = list;
            _filtString = "";
            _point = point;
            ContextMenuForm contextMenuForm = new ContextMenuForm();
            contextMenuForm.ShowInTaskbar = false;
            switch (listType)
            {
                case ListType.ListBox:
                    ListBox lst = new ListBox();
                    lst.Font = new Font("宋体",12);// 20);
                    foreach (object obj in list)
                    {
                        Type type = obj.GetType();
                        string displayText = "";
                        try
                        {
                            displayText = type.GetProperty(displayName).GetValue(obj, null).ToString();
                        }
                        catch
                        {
                            displayText = obj.ToString();
                        }
                        lst.Items.Add(displayText);
                    }
                    lst.SelectedIndexChanged += new EventHandler(delegate(object sender1, EventArgs e1)
                        {
                            if (eventHandle != null)
                            {
                                eventHandle(lst.SelectedIndex, null);
                            }
                            contextMenuForm.Close();
                        });
                    contextMenuForm.Show(parent, point, size, lst);
                    break;
                case ListType.ListView:
                    ListView listView = new ListView();
                    listView.Font = new Font("宋体",12);// 20);
                    listView.View = View.List;
                    listView.Columns.Add("选项");
                    listView.FullRowSelect = true;
                    listView.HoverSelection = true;
                    listView.LabelEdit = false;
                    listView.HeaderStyle = ColumnHeaderStyle.None;
                    listView.Resize += new EventHandler(delegate(object sender1, EventArgs e1)
                        {
                            listView.Columns[0].Width = listView.Width - 5;
                        });
                    listView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    foreach (object obj in list)
                    {
                        Type type = obj.GetType();
                        string displayText = "";
                        try
                        {
                            displayText = type.GetProperty(displayName).GetValue(obj, null).ToString();
                        }
                        catch
                        {
                            displayText = obj.ToString();
                        }
                        listView.Items.Add(displayText);
                    }
                    listView.KeyDown += new KeyEventHandler(delegate(object sender, KeyEventArgs e)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (listView.SelectedIndices != null && listView.SelectedIndices.Count > 0)
                            {
                                if (eventHandle != null)
                                {
                                    eventHandle(listView.SelectedIndices[0], null);
                                }
                                contextMenuForm.Close();
                            }
                        }
                    });
                    listView.Click += new EventHandler(delegate(object sender1, EventArgs e1)
                        {
                            if (listView.SelectedIndices != null && listView.SelectedIndices.Count > 0)
                            {
                                if (eventHandle != null)
                                {
                                    eventHandle(listView.SelectedIndices[0], null);
                                }
                                contextMenuForm.Close();
                            }
                        });
                    contextMenuForm.Show(parent, point, size, listView);
                    break;
                case ListType.DataGridView:
                    ShowDataGridView(list, displayName, parent, point, size, eventHandle, multiSelect, autoCalPoint, cellPaintingEventHandle, contextMenuForm);
                    break;
                case ListType.PopupMenu:
                    if (list != null)
                    {
                        ContextMenuStrip popupMenu = new ContextMenuStrip();
                        popupMenu.KeyDown +=new KeyEventHandler(popupMenu_KeyDown);
                        popupMenu.KeyPress += new KeyPressEventHandler(popupMenu_KeyPress);
                        //popupMenu.Font = new Font("宋体", 12);// 21.75f);
                        foreach (object obj in list)
                        {
                            Type type = obj.GetType();
                            string displayText = "";
                            try
                            {
                                displayText = type.GetProperty(displayName).GetValue(obj, null).ToString();
                            }
                            catch
                            {
                                displayText = obj.ToString();
                            }
                            ToolStripItem item = popupMenu.Items.Add(displayText);
                            item.Click += new EventHandler(delegate(object sender1, EventArgs e1)
                            {
                                if (eventHandle != null)
                                {
                                    eventHandle(popupMenu.Items.IndexOf(item), null);
                                }
                            });
                        }
                        _point = parent.PointToScreen(point);
                        popupMenu.Show(parent, point);
                    }
                    break;
            }
        }

        private static void popupMenu_KeyDown(object sender, KeyEventArgs e)
        {
            //Dialog.MessageBox(e.KeyCode.ToString());
            //if (e.KeyCode == Keys.Back)
            //{
            //    Dialog.MessageBox("yeah");
            //}
        }

        private static IEnumerable _list;
        private static string _filtString = "";
        private static Point _point = new Point(0, 0);
        private static void popupMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            ContextMenuStrip popupMenu = sender as ContextMenuStrip;
            if(popupMenu == null)return;
            int height = popupMenu.Height;
            if (((int)e.KeyChar) == 32)
            {
                if (_filtString.Length > 0)
                {
                    _filtString = _filtString.Remove(_filtString.Length - 1);
                }
            }
            else
            {
                _filtString = _filtString + e.KeyChar;
            }
            foreach (ToolStripItem item in popupMenu.Items)
            {
                if (StringManage.GetPYString(item.Text).ToLower().Contains(_filtString.ToLower()))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
            popupMenu.Show(_point);
        }

        #endregion 公有静态方法
    }
}
