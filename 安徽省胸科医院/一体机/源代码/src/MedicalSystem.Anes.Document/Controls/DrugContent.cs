/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：DrugContent.cs
      // 文件功能描述：药品容器
      //
      // 
      // 创建标识：戴呈祥-2010-12-16
      //
----------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Designer;

namespace MedicalSystem.Anes.Document.Controls
{
    [Description("药品容器"),ToolboxItem(false)]
    public class DrugContent:Control
    {
        private static readonly object _applyGridViewStyleEventHandle = new object();
        public event EventHandler ApplyGridViewStyleEventHandle
        {
            add
            {
                Events.AddHandler(_applyGridViewStyleEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_applyGridViewStyleEventHandle, value);
            }
        }

        private string _sourceTableName;
        /// <summary>
        /// 绑定表名称
        /// </summary>
        [DisplayName("源表名称"), Description("数据源:源表名称"), Category("数据(自定义)")]
        [Editor(typeof(TableNamesDropDownEditor), typeof(UITypeEditor))]
        public string SourceTableName
        {
            get
            {
                return _sourceTableName;
            }
            set
            {
                _sourceTableName = value;
            }
        }

        private string _sourceItemCodeFieldName;
        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [DisplayName("源编码字段"), Description("数据源:源编码字段"), Category("数据(自定义)")]
        [Editor(typeof(SourceFieldNameDropDownEditor), typeof(UITypeEditor))]
        public string SourceItemCodeFieldName
        {
            set
            {
                _sourceItemCodeFieldName = value;
            }
            get
            {
                return _sourceItemCodeFieldName;
            }
        }

        private string _sourceDosageFieldName;
        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [DisplayName("源用量字段"), Description("数据源:源用量字段"), Category("数据(自定义)")]
        [Editor(typeof(SourceFieldNameDropDownEditor), typeof(UITypeEditor))]
        public string SourceDosageFieldName
        {
            set
            {
                _sourceDosageFieldName = value;
            }
            get
            {
                return _sourceDosageFieldName;
            }
        }

        private string _sourceItemTypeFieldName;
        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [DisplayName("源大类字段"), Description("数据源:源大类字段"), Category("数据(自定义)")]
        [Editor(typeof(SourceFieldNameDropDownEditor), typeof(UITypeEditor))]
        public string SourceItemTypeFieldName
        {
            set
            {
                _sourceItemTypeFieldName = value;
            }
            get
            {
                return _sourceItemTypeFieldName;
            }
        }

        private string _listTableName;
        /// <summary>
        /// 绑定表名称
        /// </summary>
        [DisplayName("字典表名称"), Description("字典录入:字典表名称"), Category("数据(自定义)")]
        [Editor(typeof(TableNamesDropDownEditor), typeof(UITypeEditor))]
        public string ListTableName
        {
            get
            {
                return _listTableName;
            }
            set
            {
                _listTableName = value;
            }
        }

        private string _listFieldNames;
        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [DisplayName("字典显示字段"), Description("字典录入:字典显示字段"), Category("数据(自定义)")]
        [Editor(typeof(ListFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string ListFieldNames
        {
            set
            {
                _listFieldNames = value;
            }
            get
            {
                return _listFieldNames;
            }
        }

        private string _valueFieldName;
        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [DisplayName("字典编码字段"), Description("字典录入:字典编码字段"), Category("数据(自定义)")]
        [Editor(typeof(ListFieldNameDropDownEditor), typeof(UITypeEditor))]
        public string ValueFieldName
        {
            set
            {
                _valueFieldName = value;
            }
            get
            {
                return _valueFieldName;
            }
        }

        private string _displayFieldName;
        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [DisplayName("字典名称字段"), Description("字典录入:字典名称字段"), Category("数据(自定义)")]
        [Editor(typeof(ListFieldNameDropDownEditor), typeof(UITypeEditor))]
        public string DisplayFieldName
        {
            set
            {
                _displayFieldName = value;
            }
            get
            {
                return _displayFieldName;
            }
        }

        private string _unitFieldName;
        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [DisplayName("字典单位字段"), Description("字典录入:字典单位字段"), Category("数据(自定义)")]
        [Editor(typeof(ListFieldNameDropDownEditor), typeof(UITypeEditor))]
        public string UnitFieldName
        {
            set
            {
                _unitFieldName = value;
            }
            get
            {
                return _unitFieldName;
            }
        }

        private List<DrugItem> _items = new List<DrugItem>();

        private DataGridView _grid = new DataGridView();

        public DrugContent()
        {
            MouseDown += new MouseEventHandler(DrugContent_MouseDown);
            Leave += new EventHandler(DrugContent_Leave);
            InitColumns();
            _grid.Dock = DockStyle.Fill;
            _grid.CellClick += new DataGridViewCellEventHandler(_grid_CellClick);
            _grid.RowHeadersWidth = 10;
            ContextMenuStrip popupMenu = new ContextMenuStrip();
            popupMenu.Items.Add("保存并退出");
            popupMenu.Items.Add("不保存退出");
            _grid.ContextMenuStrip = popupMenu;
            popupMenu.ItemClicked += new ToolStripItemClickedEventHandler(popupMenu_ItemClicked);
        }

        private void DrugContent_Leave(object sender, EventArgs e)
        {
            Controls.Clear();
        }

        private void _grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    if (!string.IsNullOrEmpty(_listTableName) && !string.IsNullOrEmpty(_listFieldNames)
            //        && !string.IsNullOrEmpty(_valueFieldName) && !string.IsNullOrEmpty(_displayFieldName) && !string.IsNullOrEmpty(_unitFieldName))
            //    {
            //        List<KeyValue> list = new List<KeyValue>();
            //        DataTable dataTable = new DataTable();
            //        MedicalSystem.iMedical.Data.IDatabase dataBase = MedicalSystem.iMedical.Data.DatabaseFactory.Create();
            //        dataBase.Fill("SELECT * FROM " + _listTableName, dataTable);
            //        string[] fieldNames = _listFieldNames.Split(',');
            //        for(int i = 0; i < dataTable.Rows.Count; i++)
            //        {
            //            DataRow row = dataTable.Rows[i];
            //            if (row[_valueFieldName] != System.DBNull.Value && !string.IsNullOrEmpty(row[_valueFieldName].ToString())
            //                && row[_displayFieldName] != System.DBNull.Value && !string.IsNullOrEmpty(row[_displayFieldName].ToString())
            //                && row[_unitFieldName] != System.DBNull.Value && !string.IsNullOrEmpty(row[_unitFieldName].ToString()))
            //            {
            //                string value = "";
            //                foreach (string fieldName in fieldNames)
            //                {
            //                    value += " " + row[fieldName].ToString();
            //                }
            //                list.Add(new KeyValue(i.ToString(), value.Trim()));
            //            }
            //        }
            //        Rectangle rect = _grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //        Dialog.ShowCustomSelection(list, "Value", _grid, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
            //            , new EventHandler(delegate(object s1, EventArgs e1)
            //            {
            //                if (s1 is int)
            //                {
            //                    int index = (int)s1;
            //                    _grid.CurrentRow.Cells[0].Value = dataTable.Rows[int.Parse( list[index].Key)][_valueFieldName].ToString();
            //                    _grid.CurrentRow.Cells[1].Value = dataTable.Rows[int.Parse(list[index].Key)][_displayFieldName].ToString();
            //                    _grid.CurrentRow.Cells[3].Value = dataTable.Rows[int.Parse(list[index].Key)][_unitFieldName].ToString();
            //                }
            //            }));
            //    }
            //}
        }


        private void DrugContent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Controls.Add(_grid);
                EventHandler eventHandle = Events[_applyGridViewStyleEventHandle] as EventHandler;
                if (eventHandle != null)
                {
                    eventHandle(_grid, null);
                }
                SetList();
            }
        }

        private void InitColumns()
        {
            _grid.Columns.Clear();

            DataGridViewColumn dataGridViewColumn;

            dataGridViewColumn = new DataGridViewTextBoxColumn();
            dataGridViewColumn.HeaderText = "编码";
            dataGridViewColumn.Visible = false;
            _grid.Columns.Add(dataGridViewColumn);

            dataGridViewColumn = new DataGridViewTextBoxColumn();
            dataGridViewColumn.HeaderText = "名称";
            dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _grid.Columns.Add(dataGridViewColumn);

            dataGridViewColumn = new DataGridViewTextBoxColumn();
            dataGridViewColumn.HeaderText = "用量";
            dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            dataGridViewColumn.Width = 80;
            _grid.Columns.Add(dataGridViewColumn);

            dataGridViewColumn = new DataGridViewTextBoxColumn();
            dataGridViewColumn.HeaderText = "单位";
            dataGridViewColumn.Visible = false;
            _grid.Columns.Add(dataGridViewColumn);

        }

        private void SetList()
        {
            _grid.Rows.Clear();
            foreach (DrugItem item in _items)
            {
                AddRow(item);
            }
        }

        private void AddRow(DrugItem item)
        {
            List<object> rowValues = new List<object>();
            rowValues.Add(item.ItemCode);
            rowValues.Add(item.ItemName);
            rowValues.Add(item.Dosage);
            rowValues.Add(item.ItemUnit);
            _grid.Rows.Add(rowValues.ToArray());
        }


        private DrugItem GetRowItem(int rowIndex)
        {
            DrugItem item = new DrugItem();
            item.ItemCode = _grid.Rows[rowIndex].Cells[0].Value.ToString();
            item.ItemName = _grid.Rows[rowIndex].Cells[1].Value.ToString();
            item.Dosage = double.Parse(_grid.Rows[rowIndex].Cells[2].Value.ToString());
            item.ItemUnit = _grid.Rows[rowIndex].Cells[3].Value.ToString();
            return item;
        }

        private bool CheckRow(int rowIndex)
        {
            if (_grid.Rows.Count <= rowIndex || rowIndex < 0)
            {
                return false;
            }
            if (_grid.Rows[rowIndex].Cells[0].Value == null)
            {
                return false;
            }
            if (_grid.Rows[rowIndex].Cells[1].Value == null)
            {
                return false;
            }
            if (_grid.Rows[rowIndex].Cells[2].Value == null)
            {
                return false;
            }
            else
            {
                double d;
                if (!double.TryParse(_grid.Rows[rowIndex].Cells[2].Value.ToString(), out d))
                {
                    return false;
                }
            }
            return true;
        }

        private void popupMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "不保存退出":
                    Controls.Clear();
                    break;
                case "保存并退出":
                    _items.Clear();
                    if (_grid != null)
                    {
                        for (int i = 0; i < _grid.Rows.Count; i++)
                        {
                            if (CheckRow(i))
                            {
                                DrugItem item = GetRowItem(i);
                                _items.Add(item);
                            }
                        }
                    }
                    Controls.Clear();
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (_items != null)
            {
                string text = "";
                foreach (DrugItem item in _items)
                {
                    text += "," + item.ItemName + " " + item.Dosage.ToString() + item.ItemUnit;
                }
                if (!string.IsNullOrEmpty(text))
                {
                    text = text.Substring(1);
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Near;
                    using (var solidBrush = new SolidBrush(ForeColor))
                    {
                        g.DrawString(text, Font, solidBrush, new RectangleF(1, 1, Width - 2, Height - 2), sf);
                    }
                    
                }
            }
        }
    }
}
