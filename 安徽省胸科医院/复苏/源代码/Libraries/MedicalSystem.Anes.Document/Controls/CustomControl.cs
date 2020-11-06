using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Designer;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(true), Description("自定义控件")]
    public partial class CustomControl : UserControl, IPrintable
    {
        public CustomControl()
        {
            InitializeComponent();
            SetDefaultItem();
        }

        private void SetDefaultItem()
        {
            if (_defaultItems != null && _defaultItems.Count > 0 && !string.IsNullOrEmpty(_displayFieldName) && !string.IsNullOrEmpty(_valueFieldName))
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(_displayFieldName);
                dataTable.Columns.Add(_valueFieldName);
                dataTable.Columns.Add("LeftMargin");
                foreach (DefualtItem s in _defaultItems)
                {
                    DataRow row = dataTable.NewRow();
                    row[0] = s.ItemName;
                    row[1] = s.ItemValue;
                    row[2] = s.LeftMargin;
                    dataTable.Rows.Add(row);
                }
                _dataRows = dataTable.Select();
                SetList();
            }
        }

        #region 公用事件接口

        private static readonly object _valueChanged = new object();
        public event EventHandler ValueChanged
        {
            add
            {
                Events.AddHandler(_valueChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_valueChanged, value);
            }
        }

        #endregion 公用事件接口

        #region 私有变量

        private DataRow[] _dataRows;

        #endregion 私有变量

        [Serializable]
        public class EffectItem
        {
            public enum ValidCase
            {
                Equal,
                Unequal,
                Both
            }



            private string _effectCtrlName;
            public string EffectControlName
            {
                get { return _effectCtrlName; }
                set { _effectCtrlName = value; }
            }

            private string _effectValue;
            public string EffectValue
            {
                get { return _effectValue; }
                set { _effectValue = value; }
            }

            private string _effectProperty;
            public string EffectProperty
            {
                get { return _effectProperty; }
                set { _effectProperty = value; }
            }

            private string _propertyValue;
            public string PropertyValue
            {
                get { return _propertyValue; }
                set { _propertyValue = value; }
            }

            private ValidCase _validCase = ValidCase.Equal;
            public ValidCase ItemValidCase
            {
                get { return _validCase; }
                set { _validCase = value; }
            }

            private string _valueWhileUnequal;
            public string ValueWhileUnequal
            {
                get { return _valueWhileUnequal; }
                set { _valueWhileUnequal = value; }
            }

            private int _startIndex = 0;
            public int StartIndex
            {
                get { return _startIndex; }
                set { _startIndex = value; }
            }
        }


        #region 属性

        private bool _effectUseIndex = false;  // 是否不比较值，根据索引来确定
        public bool EffectUseIndex
        {
            get { return _effectUseIndex; }
            set { _effectUseIndex = value; }
        }

        // 值变化时影响的控件名称
        protected List<EffectItem> _effectControls = new List<EffectItem>();
        public List<EffectItem> EffectControls
        {
            get { return _effectControls; }
            set { _effectControls = value; }
        }

        // CheckBox位置
        protected LeftRightAlignment _checkBoxLocation = LeftRightAlignment.Left;

        [Localizable(true)]
        [Bindable(true)]
        public LeftRightAlignment CheckBoxLocation
        {
            get { return _checkBoxLocation; }
            set
            {
                _checkBoxLocation = value;
                SetList();
            }
        }



        [Serializable]
        public class DefualtItem
        {
            private string _itemName;
            public string ItemName
            {
                get
                {
                    return _itemName;
                }
                set
                {
                    _itemName = value;
                }
            }

            private string _itemValue;
            public string ItemValue
            {
                get
                {
                    return _itemValue;
                }
                set
                {
                    _itemValue = value;
                }
            }
            private int _leftMargin = 0;
            public int LeftMargin
            {
                get
                {
                    return _leftMargin;
                }
                set
                {
                    _leftMargin = value;
                }
            }
            public DefualtItem()
            {
            }

            public override string ToString()
            {
                return _itemName + "(" + _itemValue + ")";
            }
        }

        [Serializable]
        public class IndexLeftMarginPair
        {
            private int _index = 0;
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

            private int _leftMargin = 0;
            public int LeftMargin
            {
                get
                {
                    return _leftMargin;
                }
                set
                {
                    _leftMargin = value;
                }
            }
        }
        private List<DefualtItem> _defaultItems = new List<DefualtItem>();
        public List<DefualtItem> DefaultItems
        {
            get
            {
                return _defaultItems;
            }
            set
            {
                _defaultItems = value;
                if (_defaultItems != null && _defaultItems.Count > 0)
                {
                    if (string.IsNullOrEmpty(_displayFieldName))
                    {
                        _displayFieldName = "ITEM_NAME";
                    }
                    if (string.IsNullOrEmpty(_valueFieldName))
                    {
                        _valueFieldName = "ITEM_VALUE";
                    }
                    SetDefaultItem();
                }
            }
        }

        private string _fieldName;
        [Browsable(false)]
        public string FieldName
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName = value;
            }
        }

        private string _groupName = string.Empty;
        [Description("分组名"), Category("数据(自定义)")]
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }

        private string _defaultCheckValue = string.Empty;
        [Description("新增默认勾选项"), Category("数据(自定义)")]
        public string DefaultCheckValue
        {
            get
            {
                return _defaultCheckValue;
            }
            set
            {
                _defaultCheckValue = value;
            }
        }
        private string _tableName;
        [Browsable(false)]
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }


        /// <summary>
        /// 是否为整体模板控件
        /// </summary>
        private bool _isTotalModel = false;
        /// <summary>
        /// 是否为整体模板控件
        /// </summary>
        [DisplayName("是否为整体模板"), Description("是否为整体模板"), Category("数据(自定义)")]
        public bool IsTotalModel
        {
            get
            {
                return _isTotalModel;
            }
            set
            {
                _isTotalModel = value;
            }
        }


        private string _sourceTableName;
        /// <summary>
        /// 绑定表名称
        /// </summary>
        [Description("数据源:表名称"), Category("数据(自定义)")]
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
        /// <summary>
        /// 是否已经加载字典表选项
        /// </summary>
        [Browsable(false)]
        public bool IsItemsLoaded
        {
            get
            {
                return _dataRows != null;
            }
        }
        /// <summary>
        /// 绑定字段名称
        /// </summary>
        [Description("数据源:字段名称"), Category("数据(自定义)")]
        [Editor(typeof(SourceFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string SourceFieldName
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName = value;
            }
        }

        /// <summary>
        /// 快速录入绑定表名
        /// </summary>
        [Description("字典录入:表名"), Category("数据(自定义)")]
        [Editor(typeof(DictTableNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictTableName
        {
            set
            {
                _tableName = value;
            }
            get
            {
                return _tableName;
            }
        }

        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [Description("字典录入:值对应字段名"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictValueFieldName
        {
            set
            {
                _valueFieldName = value;
                if (!string.IsNullOrEmpty(_valueFieldName))
                {
                    SetDefaultItem();
                }
            }
            get
            {
                return _valueFieldName;
            }
        }

        private string _displayFieldName;
        /// <summary>
        /// 快速录入绑定拼音字段名
        /// </summary>
        [Description("字典录入:显示字段名"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DisplayFieldName
        {
            get
            {
                return _displayFieldName;
            }
            set
            {
                _displayFieldName = value;
                if (!string.IsNullOrEmpty(_displayFieldName))
                {
                    SetDefaultItem();
                }
            }
        }


        /// <summary>
        /// 快速录入过滤条件
        /// </summary>
        [Description("字典录入:选择项目筛选条件"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictWhereString
        {
            set
            {
                _sqlWhereFilter = value;
            }
            get
            {
                return _sqlWhereFilter;
            }
        }

        private string _valueFieldName;
        [Browsable(false)]
        public string ValueFieldName
        {
            get
            {
                return _valueFieldName;
            }
            set
            {
                _valueFieldName = value;
            }
        }

        private string _sqlWhereFilter;
        [Browsable(false)]
        public string SqlWhereFilter
        {
            get
            {
                return string.IsNullOrEmpty(_sqlWhereFilter) ? "" : _sqlWhereFilter;
            }
            set
            {
                _sqlWhereFilter = value;
            }
        }

        private bool _multiSelect = false;
        /// <summary>
        /// 下拉框绑定类型标志位，真为多选，假为单选
        /// </summary>
        [Description("下拉框绑定类型标志位，真为多选，假为单选"), Category("数据(自定义)")]
        public bool MultiSelect
        {
            get
            {
                return _multiSelect;
            }
            set
            {
                _multiSelect = value;
            }
        }

        private bool _noPrint = false;
        [Description("是否不打印"), Category("数据(自定义)")]
        public bool NoPrint
        {
            get
            {
                return _noPrint;
            }
            set
            {
                _noPrint = value;
            }
        }

        private string _value;
        [Browsable(false)]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (_multiSelect)
                {
                    SetMulitValue(value);
                }
            }
        }

        private void SetMulitValue(string value)
        {
            if (_dataRows != null && _dataRows.Length > 0)
            {
                string vField = _valueFieldName;
                if (string.IsNullOrEmpty(vField) && _defaultItems != null && _defaultItems.Count > 0)
                {
                    vField = "ITEM_VALUE";
                }
                if (!string.IsNullOrEmpty(vField))
                {
                    List<int> list = new List<int>();
                    if (value != null)
                    {
                        string v = "," + value + ",";
                        for (int i = 0; i < _dataRows.Length; i++)
                        {
                            if (_dataRows[i][vField] != System.DBNull.Value && v.Contains("," + _dataRows[i][vField].ToString() + ","))
                            {
                                list.Add(i);
                            }

                        }
                    }
                    foreach (Control control in Controls)
                    {
                        if (control is CheckBox)
                        {
                            (control as CheckBox).Checked = false;
                        }
                    }
                    if (list.Count > 0)
                    {
                        foreach (int index in list)
                        {
                            foreach (Control control in Controls)
                            {
                                if (control is CheckBox)
                                {
                                    IndexLeftMarginPair indexPair = control.Tag as IndexLeftMarginPair;
                                    if (indexPair != null && index == indexPair.Index)
                                    {
                                        (control as CheckBox).Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private object _simpleValue;
        [Browsable(false)]
        public object SimpleValue
        {
            get
            {
                if (_defaultItems == null || _defaultItems.Count == 0)
                {
                    return _simpleValue;
                }
                else
                {
                    foreach (Control control in Controls)
                    {
                        if (control is CheckBox)
                        {
                            CheckBox checkBox = control as CheckBox;
                            if (checkBox.Checked)
                            {
                                foreach (DefualtItem item in _defaultItems)
                                {
                                    if (item.ItemName.Equals(checkBox.Text))
                                    {
                                        return item.ItemValue;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    return null;
                }
            }
            set
            {

                _simpleValue = value;
                if (_dataRows != null && _dataRows.Length > 0)
                {
                    string vField = _valueFieldName;
                    if (string.IsNullOrEmpty(vField) && _defaultItems != null && _defaultItems.Count > 0)
                    {
                        vField = "ITEM_VALUE";
                    }
                    if (!string.IsNullOrEmpty(vField))
                    {
                        int index = -1;
                        if (value != null)
                        {
                            for (int i = 0; i < _dataRows.Length; i++)
                            {
                                if (_dataRows[i][vField] != System.DBNull.Value && _dataRows[i][vField].ToString().Equals(value.ToString()))
                                {
                                    index = i;
                                    break;
                                }

                            }
                        }
                        foreach (Control control in Controls)
                        {
                            if (control is CheckBox)
                            {
                                if (control.Tag != null && control.Tag is IndexLeftMarginPair)
                                {
                                    if ((control.Tag as IndexLeftMarginPair).Index == index)
                                    {
                                        (control as CheckBox).Checked = true;
                                    }
                                    else
                                    {
                                        (control as CheckBox).Checked = false;
                                    }

                                }
                                else
                                {
                                    (control as CheckBox).Checked = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        private bool _isDrawAll = false;
        public bool IsDrawAll
        {
            get
            {
                return _isDrawAll;
            }
            set
            {
                _isDrawAll = value;
            }
        }

        private string _defaultPrintText;
        [Description("默认打印文本"), Category("数据(自定义)")]
        public string DefaultPrintText
        {
            get
            {
                return string.IsNullOrEmpty(_defaultPrintText) ? "" : _defaultPrintText;
            }
            set
            {
                _defaultPrintText = value;
            }
        }

        private Color _printColor = Color.Black;
        public Color PrintColor
        {
            get
            {
                return _printColor;
            }
            set
            {
                _printColor = value;
            }
        }


        private Color _selectColor = Color.Black;
        [Description("选中项颜色"), Category("数据(自定义)")]
        public Color SelectColor
        {
            get { return _selectColor; }
            set { _selectColor = value; }
        }
        private bool _isVert = false;
        public bool IsVert
        {
            get
            {
                return _isVert;
            }
            set
            {
                _isVert = value;
            }
        }

        private bool _readOnly = false;
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
            }
        }

        #endregion 属性

        public void SetTable(DataTable dataTable)
        {
            _dataRows = null;
            if (!dataTable.Columns.Contains("LeftMargin"))
            {
                dataTable.Columns.Add("LeftMargin");
            }
            if (!string.IsNullOrEmpty(_sqlWhereFilter))
            {
                _dataRows = dataTable.Select(_sqlWhereFilter);
            }
            else
            {
                _dataRows = dataTable.Select();
            }
            if (_dataRows != null)
            {
                if (dataTable.Columns.Contains("SERIAL_NO"))
                {
                    List<DataRow> rows = new List<DataRow>(_dataRows);
                    rows.Sort(new Comparison<DataRow>(delegate(DataRow row1, DataRow row2)
                    {
                        if (row1["SERIAL_NO"] == System.DBNull.Value || row2["SERIAL_NO"] == System.DBNull.Value)
                        {
                            return 0;
                        }
                        else
                        {
                            return ((decimal)row1["SERIAL_NO"]).CompareTo((decimal)row2["SERIAL_NO"]);
                        }
                    }));
                    _dataRows = rows.ToArray();
                }
                SetList();
            }
            if (!string.IsNullOrEmpty(_value))
            {
                if (_dataRows != null && !string.IsNullOrEmpty(_displayFieldName))
                {
                    string vv = "," + _value.ToString() + ",";
                    for (int i = 0; i < _dataRows.Length; i++)
                    {
                        if (vv.Contains("," + _dataRows[i][_displayFieldName].ToString() + ","))
                        {
                            (Controls[string.Format("Control{0}", new object[] { i })] as CheckBox).Checked = true;
                        }
                    }
                }
            }
        }

        public List<string> GetList()
        {
            List<string> list = new List<string>();
            if (_dataRows != null && _dataRows.Length > 0)
            {
                for (int index = 0; index < _dataRows.Length; index++)
                {
                    list.Add(_dataRows[index][_displayFieldName].ToString());
                }
            }
            return list;
        }
        //private int xOffSet = 19;
        //[Description("数据源:选择框行间距"), Category("数据(自定义)")]
        //[Editor(typeof(TableNamesDropDownEditor), typeof(UITypeEditor))]
        //public int XOffSet
        //{
        //    get
        //    {
        //        return xOffSet;
        //    }
        //    set
        //    {
        //        xOffSet = value;
        //    }
        //}
        int xOffSet = 20;
        private void SetList()
        {
            Font _font = this.Font;
            Controls.Clear();
            Control control = null;
            int top = 0, left = 0;
            int maxWidth = Width - xOffSet;
            if (_dataRows != null)
                for (int index = 0; index < _dataRows.Length; index++)
                {
                    if (_displayFieldName == null) _displayFieldName = "ITEM_NAME";
                    string text = _dataRows[index][_displayFieldName].ToString();
                    IndexLeftMarginPair indexLeftPair = new IndexLeftMarginPair();
                    control = new CheckBox();
                    CheckBox checkBox = control as CheckBox;
                    checkBox.AutoSize = false;
                    checkBox.Text = text;
                    indexLeftPair.Index = index;
                    checkBox.Click += new EventHandler(checkBox_Click);
                    checkBox.Paint += new PaintEventHandler(checkBox_Paint);
                    control.Font = _font;
                    control.ForeColor = ForeColor;
                    control.Name = string.Format("Control{0}", new object[] { index });
                    using (Graphics g = control.CreateGraphics())
                    {
                        SizeF measuerSize = g.MeasureString(text, _font);
                        control.Top = top;
                        control.Left = left;
                        control.Width = xOffSet + (int)Math.Ceiling(measuerSize.Width) + (_font.Style == FontStyle.Bold ? 10 : 0);
                        control.Height = (int)Math.Ceiling(measuerSize.Height) + 1;

                        if (_isVert)
                        {
                            if (_checkBoxLocation == LeftRightAlignment.Left)
                                checkBox.CheckAlign = ContentAlignment.TopLeft;
                            else
                            {
                                checkBox.CheckAlign = ContentAlignment.TopRight;
                                checkBox.TextAlign = ContentAlignment.MiddleRight;
                                checkBox.Left += Width - checkBox.Width;
                            }
                            // 判断总共需要几行
                            if (measuerSize.Width > maxWidth)
                            {
                                int nLines = Convert.ToInt32(Math.Ceiling(measuerSize.Width)) / maxWidth;
                                int nRemain = Convert.ToInt32(Math.Ceiling(measuerSize.Width)) % maxWidth;
                                if (nRemain > 0)
                                    nLines++;
                                control.Width = Width;
                                control.Height = control.Height * nLines;
                            }
                            top += control.Height + 2;
                        }
                        else
                        {
                            if (_checkBoxLocation == LeftRightAlignment.Left)
                                checkBox.CheckAlign = ContentAlignment.MiddleLeft;
                            else
                                checkBox.CheckAlign = ContentAlignment.MiddleRight;
                            // 如果选项一行装不下，则分多行
                            if (measuerSize.Width > maxWidth)
                            {
                                if (left > 0)
                                    top += control.Height + 3;
                                control.Left = left = 0;
                                control.Top = top;
                                // 判断总共需要几行
                                int nLines = Convert.ToInt32(Math.Ceiling(measuerSize.Width)) / maxWidth;
                                int nRemain = Convert.ToInt32(Math.Ceiling(measuerSize.Width)) % maxWidth;
                                if (nRemain > 0)
                                    nLines++;
                                control.Width = Width;
                                control.Height = control.Height * nLines;
                                top += control.Height + 3;
                            }
                            else if (left + measuerSize.Width > maxWidth)  // 本行不够则换行
                            {
                                control.Left = 0;
                                top += control.Height + 3;
                                control.Top = top;

                                left = control.Width;
                            }
                            else
                            {
                                left += control.Width;
                            }
                        }
                        if (_dataRows[index]["LeftMargin"] != null && _dataRows[index]["LeftMargin"] != DBNull.Value && !(_dataRows[index]["LeftMargin"] is DBNull))
                        {
                            int leftMargin = Convert.ToInt32(_dataRows[index]["LeftMargin"]);

                            if (leftMargin > 0)
                            {
                                if (_isVert)
                                {
                                    control.Top += leftMargin;
                                    top += leftMargin;
                                }
                                else
                                {
                                    if (control.Left + leftMargin + measuerSize.Width > maxWidth)
                                    {
                                        control.Left = 0;
                                        top += control.Height + 3;
                                        control.Top = top;
                                        left = control.Width;
                                    }
                                    else
                                    {
                                        control.Left += leftMargin;
                                        left += leftMargin;
                                    }

                                }

                                indexLeftPair.LeftMargin = leftMargin;
                            }
                        }
                        control.Tag = indexLeftPair;
                        Controls.Add(control);
                    }
                }
            if (Controls.Count > 0) toolTip1.SetToolTip(this, null);
        }

        private void checkBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            CheckBox checkBox = sender as CheckBox;
            Rectangle rect = checkBox.ClientRectangle;
            rect.X = rect.X + 14;

            rect.Width += xOffSet - 14;

            using (SolidBrush solidBrush = new SolidBrush(Parent.BackColor))
            {
                if (Parent != null)
                {
                    g.FillRectangle(solidBrush, rect);
                }
                else
                {
                    g.FillRectangle(Brushes.White, rect);
                }
            }
            using (SolidBrush solidBrush = new SolidBrush(checkBox.ForeColor))
            {
                //int height = (int)g.MeasureString(checkBox.Text, checkBox.Font).Height;
                g.DrawString(checkBox.Text, checkBox.Font, solidBrush, rect.X, rect.Y + 3);
            }
        }

        private void RaiseValueChanged()
        {
            EventHandler eventHandle = Events[_valueChanged] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        public string GetVirtrueValue()
        {
            string ret = string.Empty;
            foreach (Control control in Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;
                    if (checkBox.Checked)
                    {
                        string tvalue = checkBox.Text;

                        IndexLeftMarginPair index = checkBox.Tag as IndexLeftMarginPair;
                        if (_dataRows != null && index != null && _dataRows.Length > index.Index && !string.IsNullOrEmpty(_valueFieldName))
                        {
                            if (_dataRows[index.Index][_valueFieldName] != DBNull.Value)
                            {
                                tvalue = _dataRows[index.Index][_valueFieldName].ToString();
                            }
                        }
                        ret += "," + tvalue;
                    }
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                ret = ret.Substring(1);
            }
            return ret;
        }

        private void CustomControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if ((Parent == null))
                {
                    string text = _tableName + "[" + _fieldName + "]:" + (_multiSelect ? "多选" : "单选");
                    toolTip1.SetToolTip(this, text);
                }
                else
                {
                    if (Controls.Count == 0)
                    {
                        string text = SourceTableName + "[" + SourceFieldName + "]:" + (_multiSelect ? "多选" : "单选");
                        toolTip1.SetToolTip(this, text);
                    }
                }
            }
        }

        private void radio_Click(object sender, EventArgs e)
        {
            if (_readOnly)
            {
                return;
            }
            string value = _dataRows[((sender as RadioButton).Tag as IndexLeftMarginPair).Index][_valueFieldName].ToString();
            if (!value.Equals(_value))
            {
                _value = value;
                RaiseValueChanged();
            }
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            if (_readOnly)
            {
                (sender as CheckBox).Checked = !(sender as CheckBox).Checked;
                return;
            }
            else
            {
            }
            string value = "";
            _simpleValue = null;
            foreach (Control control in Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;
                    if (!_multiSelect)
                    {
                        if (!checkBox.Equals(sender))
                        {
                            checkBox.Checked = false;
                        }
                    }
                    if (checkBox.Checked)
                    {
                        string tvalue = checkBox.Text;
                        if (!_multiSelect)
                        {
                            IndexLeftMarginPair index = checkBox.Tag as IndexLeftMarginPair;
                            if (_dataRows != null && index != null && _dataRows.Length > index.Index && !string.IsNullOrEmpty(_valueFieldName))
                            {
                                _simpleValue = _dataRows[index.Index][_valueFieldName];
                            }
                        }
                        else
                        {
                            IndexLeftMarginPair index = checkBox.Tag as IndexLeftMarginPair;
                            if (_dataRows != null && index != null && _dataRows.Length > index.Index && !string.IsNullOrEmpty(_valueFieldName))
                            {
                                if (_dataRows[index.Index][_valueFieldName] != DBNull.Value)
                                {
                                    tvalue = _dataRows[index.Index][_valueFieldName].ToString();
                                }
                            }
                        }
                        value += "," + tvalue;
                    }
                }
            }
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Substring(1);
            }
            if (!value.Equals(_value))
            {
                _value = value;
            }
            RaiseValueChanged();
        }

        public void Draw(Graphics g, float x, float y)
        {
            DrawGraphics(g, x, y);
        }

        public void ClearValue()
        {
            foreach (Control control in Controls)
            {
                if (control is CheckBox)
                {
                    (control as CheckBox).Checked = false;
                }
            }
        }

        public void DrawGraphics(Graphics g, float x, float y)
        {
            string checkStr = "√";
            float left = x;
            float top = y;
            Rectangle rect = new Rectangle();
            SolidBrush solidBrush = new SolidBrush(ForeColor);
            SolidBrush selectBrush = new SolidBrush(_selectColor);
            Pen pen = new Pen(ForeColor);
            Pen selectPen = new Pen(_selectColor);
            int index = 0;
            foreach (Control ctl in Controls)
            {
                if (ctl is CheckBox)
                {
                    if (_isVert)
                    {
                        left = x;
                        top = y + index * (g.MeasureString(ctl.Text, Font).Height + 6);
                    }
                    else if (((int)left + xOffSet + g.MeasureString(ctl.Text, Font).Width) >= ((int)x + Width))
                    {
                        left = x;
                        top += g.MeasureString(ctl.Text, Font).Height + 6;
                    }
                    if ((ctl as CheckBox).Checked)
                    {
                        g.DrawString(checkStr, Font, selectBrush, left, top);
                    }
                    rect.X = 2 + (int)left;
                    rect.Y = (int)top;
                    rect.Width = -5 + (int)g.MeasureString(checkStr, Font).Width;
                    rect.Height = rect.Width;
                    int leftMargin = 0;
                    if (ctl.Tag is IndexLeftMarginPair)
                    {
                        leftMargin = (ctl.Tag as IndexLeftMarginPair).LeftMargin;
                    }
                    rect.X += leftMargin;
                    if ((ctl as CheckBox).Checked)
                    {
                        g.DrawRectangle(selectPen, rect);
                        g.DrawString(ctl.Text, Font, selectBrush, left + xOffSet + leftMargin, top);
                    }
                    else
                    {
                        g.DrawRectangle(pen, rect);
                        g.DrawString(ctl.Text, Font, solidBrush, left + xOffSet + leftMargin, top);
                    }
                    left += xOffSet + g.MeasureString(ctl.Text, Font).Width;
                    index++;
                }
            }
            pen.Dispose();
            selectPen.Dispose();
            solidBrush.Dispose();
            selectBrush.Dispose();
        }

        private void CustomControl_DoubleClick(object sender, EventArgs e)
        {
            if (_readOnly)
            {
                return;
            }
            foreach (Control control in Controls)
            {
                if (control is RadioButton)
                {
                    (control as RadioButton).Checked = false;
                }
                _value = "";
                RaiseValueChanged();
            }
        }

        private bool _isDesigned = true;
        [Browsable(false)]
        public bool IsDesigned
        {
            set
            {
                _isDesigned = value;
            }
        }

        private void CustomControl_Paint(object sender, PaintEventArgs e)
        {
            if (_isDesigned && Controls.Count == 0)
            {
                string text = "";
                if ((Parent == null))
                {
                    text = toolTip1.GetToolTip(this);
                }
                else
                {
                    text = SourceTableName + "[" + SourceFieldName + "]:" + (_multiSelect ? "多选" : "单选");
                }
                if (!string.IsNullOrEmpty(text))
                {
                    using (SolidBrush solidBrush = new SolidBrush(ForeColor))
                    {
                        e.Graphics.DrawString(text, Font, solidBrush, 0, 0);
                    }
                }
            }
        }

        private void CustomControl_Resize(object sender, EventArgs e)
        {
            SetList();
        }

    }
}
