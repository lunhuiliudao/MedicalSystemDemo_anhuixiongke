/*----------------------------------------------------------------
      // Copyright (C) 2005 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedTextBox.cs
      // 文件功能描述：基本输入框
      //
      // 
      // 重构标识：戴呈祥-2008-01-16 优化结构 添加注释 扩展
----------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Designer;


namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 输入类型
    /// </summary>
    public enum MedInputType
    {
        /// <summary>
        /// 字符型
        /// </summary>
        String,

        /// <summary>
        /// 数字型
        /// </summary>
        Nurmeric,
        /// <summary>
        /// 正整数型
        /// </summary>
        PositiveInteger,
        /// <summary>
        /// 整数型
        /// </summary>
        Integer,

        /// <summary>
        /// 日期型
        /// </summary>
        Date,

        /// <summary>
        /// 时间型
        /// </summary>
        Time,

        /// <summary>
        /// 通用型
        /// </summary>
        General,
        
        /// <summary>
        /// 竖线
        /// </summary>
        VerticalLine,

        /// <summary>
        /// 横线
        /// </summary>
        Line,
        /// <summary>
        /// 自定义函数
        /// </summary>
        DefinedFunction
    }


    /// <summary>
    /// 基本输入框
    /// </summary>
    [ToolboxItem(true), Description("输入框")]
    public class MedTextBox : DevExpress.XtraEditors.TextEdit, ICheckable, IPrintable//TextBox, ICheckable, IPrintable
    {

        /// <summary>
        /// 构造方法
        /// </summary>
        public MedTextBox()
        {
            base.LookAndFeel.UseDefaultLookAndFeel = false;
            //BorderStyle = BorderStyle.FixedSingle; //DevExpress.XtraEditors.Controls.BorderStyles.Flat; //BorderStyle.FixedSingle;            
            _oldForeColor = this.ForeColor;
            Validating += new CancelEventHandler(MedTextBox_Validating);
            ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            KeyDown += new KeyEventHandler(MedTextBox_KeyDown);
            KeyPress += new KeyPressEventHandler(MedTextBox_KeyPress);
        }

        void MedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_canEdit  )
            {
                e.Handled = true;
            }
            else if (!string.IsNullOrEmpty(_limitedString))
            {
                if (_limitedString.Contains(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }
        }

        void MedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_canEdit )
            {
                e.Handled = true;
            }
        }

        public DateTime TryParseDateTime()
        {
            return TryParseDateTime(Text);
        }

        private DateTime TryParseDateTime(string text)
        {
            DateTime dt = DateTime.MinValue;
            if (!DateTime.TryParse(text, out dt))
            {
                if (_format.Contains(":"))
                {
                    if (!text.Contains(":"))
                    {
                        string s = text + ":00";
                        if (!DateTime.TryParse(s, out dt))
                        {
                            dt = DateTime.MinValue;
                        }
                    }
                    else
                    {
                        dt = DateTime.MinValue;
                        if (text.EndsWith(":"))
                        {
                            string s = text + "00"; if (!DateTime.TryParse(s, out dt))
                            {
                                dt = DateTime.MinValue;
                            }
                        }
                    }
                }
                else
                {
                    dt = DateTime.MinValue;
                }
            }
            return dt;
        }

        private string CheckInput(string text)
        {
            switch (_inputType)
            {
                case MedInputType.Date:
                    DateTime dt = TryParseDateTime(text);
                    if (dt == DateTime.MinValue)
                    {
                        return "无效的日期格式";
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(_minimum))
            {
                switch (_inputType)
                {
                    case MedInputType.Date:
                        DateTime dt, dtMin;
                        if (!DateTime.TryParse(text, out dt))
                        {
                            dt = DateTime.MinValue;
                        }
                        if (!DateTime.TryParse(_minimum, out dtMin))
                        {
                            dtMin = DateTime.MinValue.AddDays(1);
                        }
                        if (dt < dtMin)
                        {
                            return "输入值小于最小值" + _minimum;
                        }
                        break;
                    case MedInputType.Integer:
                        int value, vMin;
                        if (!int.TryParse(text, out value))
                        {
                            value = int.MinValue;
                        }
                        if (!int.TryParse(_minimum, out vMin))
                        {
                            vMin = int.MinValue + 1;
                        }
                        if (value < vMin)
                        {
                            return "输入值小于最小值" + _minimum;
                        }
                        break;
                    case MedInputType.Nurmeric:
                        double dvalue, dMin;
                        if (!double.TryParse(text, out dvalue))
                        {
                            dvalue = double.MinValue;
                        }
                        if (!double.TryParse(_minimum, out dMin))
                        {
                            dMin = double.MinValue + 1;
                        }
                        if (dvalue < dMin)
                        {
                            return "输入值小于最小值" + _minimum;
                        }
                        break;
                    case MedInputType.PositiveInteger:
                        int intValue;
                        if (!int.TryParse(text, out intValue))
                        {
                            intValue = 1;
                        }
                        if(intValue < 1)
                        {
                            return "输入值小于最小值" + _minimum;
                        }
                        break;
                }
            }
            if (!string.IsNullOrEmpty(_maximum))
            {
                switch (_inputType)
                {
                    case MedInputType.Date:
                        DateTime dt, dtMax;
                        dt = TryParseDateTime(text);
                        if (!DateTime.TryParse(_maximum, out dtMax))
                        {
                            dtMax = DateTime.MaxValue.AddDays(-1);
                        }
                        if (dt > dtMax)
                        {
                            return "输入值大于最大值" + _maximum;
                        }
                        break;
                    case MedInputType.Integer:
                        int value, vMax;
                        if (!int.TryParse(text, out value))
                        {
                            value = int.MaxValue;
                        }
                        if (!int.TryParse(_maximum, out vMax))
                        {
                            vMax = int.MaxValue - 1;
                        }
                        if (value > vMax)
                        {
                            return "输入值大于最大值" + _maximum;
                        }
                        break;
                    case MedInputType.PositiveInteger:
                        int intValue,intMax;
                        if (!int.TryParse(text, out intValue))
                        {
                            intValue = 3600;
                        }
                        if (!int.TryParse(_maximum, out intMax))
                        {
                            intMax = 3600;
                        }
                        if (intValue > intMax)
                        {
                            return "输入值大于最大值" + _maximum;
                        }
                        break;
                    case MedInputType.Nurmeric:
                        double dvalue, dMax;
                        if (!double.TryParse(text, out dvalue))
                        {
                            dvalue = double.MaxValue;
                        }
                        if (!double.TryParse(_maximum, out dMax))
                        {
                            dMax = double.MaxValue - 1;
                        }
                        if (dvalue > dMax)
                        {
                            return "输入值大于最大值" + _maximum;
                        }
                        break;
                }
            }
            switch (_inputType)
            {
                case MedInputType.Nurmeric:
                    if (_dotNumber > 0)
                    {
                        double dbl;
                        if (!double.TryParse(text, out dbl))
                        {
                            dbl = double.MinValue;
                        }
                        if (dbl == double.MinValue)
                        {
                            return "无效的数字格式";
                        }
                        else
                        {
                            string s = dbl.ToString();
                            int index = s.IndexOf('.');
                            int dotNumber = 0;
                            if (index > 0)
                            {
                                s = s.Substring(index + 1);
                                dotNumber = s.Length;
                            }
                            if (!dotNumber.Equals(_dotNumber))
                            {
                                return "小数位数不对，只能是" + _dotNumber.ToString() + "位小数";
                            }
                        }
                    }
                    break;
            }
            return null;
        }

        private void MedTextBox_Validating(object sender, CancelEventArgs e)
        {
            if(!_nullAble && string.IsNullOrEmpty(Text))
            {
                ErrorText = "内容不能为空！";
                e.Cancel = true;
                return;
            }

            if (!string.IsNullOrEmpty(Text))
            {
                string errMessage = CheckInput(Text);
                if (!string.IsNullOrEmpty(errMessage))
                {
                    ErrorText = errMessage;
                    e.Cancel = true;
                }
                //else
                //{
                //    ErrorText = "";
                //}
            }
        }

        private string examItemName;
        [DisplayName("检查项目名称")]
        public string ExamItemName
        {
            get { return examItemName; }
            set { examItemName = value; }
        }

        private string labItemName;
        [DisplayName("检验项目名称")]
        public string LabItemName
        {
            get { return labItemName; }
            set { labItemName = value; }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color borderColor = Color.LightGray;

        ///// <summary>
        ///// 边框类型
        ///// </summary>
        //private Border3DStyle border3DStyle = Border3DStyle.Adjust;

        /// <summary>
        /// 字段名称
        /// </summary>
        private string fieldName;

        /// <summary>
        /// 输入类型
        /// </summary>
        private MedInputType _inputType = MedInputType.General;

        /// <summary>
        /// 是否拒绝输入
        /// </summary>
        private bool isRejectInput = false;

        /// <summary>
        /// 是否锁定输入区
        /// </summary>
        private bool _lockInput = false;

        /// <summary>
        /// 是否画虚线边框
        /// </summary>
        private bool _dotBorder = false;

        /// <summary>
        /// 绑定表名称
        /// </summary>
        private string _bindTableName = string.Empty;

        /// <summary>
        /// 绑定字段名称
        /// </summary>
        private string _bindFieldName = string.Empty;
        
        private string _celerityInputTableName = string.Empty;
        private string _celerityInputValueColumnName = string.Empty;
        private string _celerityInputCodeColumnName = string.Empty;
        private string _celerityInputSqlWhere = string.Empty;

        private string _displayMutiColFieldName = string.Empty;
        private string _bindList = string.Empty;        
        private string _selfValue = string.Empty;
        private string _format = string.Empty;
        private string _oldValue = "";
        private bool _multiSign = false;
        private bool _selfValueChanged = false;
        private bool _isChanged = false;
        private Color _oldForeColor;

        private string _storedValue = "";
        [Browsable(false)]
        public string StoredValue
        {
            get
            {
                return _storedValue;
            }
            set
            {
                _storedValue = value;
            }
        }

        //private BorderStyle _borderStyle = BorderStyle.FixedSingle;
        //public new BorderStyle BorderStyle
        //{
        //    get
        //    {
        //        return _borderStyle;
        //    }
        //    set
        //    {
        //        _borderStyle = value;
        //        switch (_borderStyle)
        //        {
        //            case BorderStyle.None:
        //                base.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        //                break;
        //            case BorderStyle.FixedSingle:
        //                base.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        //                break;
        //            case BorderStyle.Fixed3D:
        //                base.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
        //                break;
        //            default:
        //                base.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("边框颜色")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
            }
        }

        private string _limitedString = "";
        public string LimitedString
        {
            get
            {
                return _limitedString;
            }
            set
            {
                _limitedString = value;
            }
        }

        public char PasswordChar
        {
            get
            {
                return Properties.PasswordChar;
            }
            set
            {
                Properties.PasswordChar = value;
            }
        }

        private bool _multiLine = false;
        public bool Multiline
        {
            get
            {
                return _multiLine;
            }
            set
            {
                _multiLine = value;
            }
        }

        //private bool _readOnly = false;
        public bool ReadOnly
        {
            get
            {
                return Properties.ReadOnly; //_readOnly;
            }
            set
            {
                Properties.ReadOnly = value;
                //_readOnly = value;
            }
        }

        private bool _wordWrap = false;
        public bool WordWrap
        {
            get
            {
                return _wordWrap;
            }
            set
            {
                _wordWrap = value;
            }
        }

        private HorizontalAlignment _textAlign = HorizontalAlignment.Left;
        public HorizontalAlignment TextAlign
        {
            get
            {
                return _textAlign;
            }
            set
            {
                _textAlign = value;
                switch (_textAlign)
                {
                    case HorizontalAlignment.Center:
                        Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        break;
                    case HorizontalAlignment.Left:
                        Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        break;
                    case HorizontalAlignment.Right:
                        Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        break;
                    default:
                        Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
                        break;
                }
            }
        }

        /// <summary>
        /// 数据变化前颜色
        /// </summary>
        [Description("数据变化前颜色")]
        public Color OldForeColor
        {
            get
            {
                return _oldForeColor;
            }
            set
            {
                _oldForeColor = value;
            }
        }


        ///// <summary>
        ///// 边框类型
        ///// </summary>
        //[Description("边框类型")]
        //public Border3DStyle Border3DStyle
        //{
        //    get
        //    {
        //        return border3DStyle;
        //    }
        //    set
        //    {
        //        border3DStyle = value;
        //    }
        //}

        private bool _hasLookUpItems = false;
        /// <summary>
        /// 是否有下拉框选择项
        /// </summary>
        [Browsable(false)]
        public bool HasLookUpItems
        {
            get
            {
                return _hasLookUpItems;
            }
            set
            {
                _hasLookUpItems = value;
            }
        }
        /// <summary>
        /// 字段名称
        /// </summary>
        [DisplayName("字段名称"), Description("字段名称"), Category("数据(自定义)"),Browsable(false)]
        public string FieldName
        {
            get
            {
                if ((fieldName == null) || (fieldName.Trim() == ""))
                {
                    return this.Name;
                }
                else
                {
                    return fieldName.Trim();
                }
            }
            set
            {
                fieldName = value;
            }
        }

        /// <summary>
        /// 是否画虚线边框
        /// </summary>
        [DisplayName("是否画虚线边框"),Description("是否画虚线边框")]
        public bool DotBorder
        {
            get
            {
                return _dotBorder;
            }
            set
            {
                _dotBorder = value;
                Refresh();
            }
        }

        /// <summary>
        /// 数据是否发生变化
        /// </summary>
        [DisplayName("数据是否发生变化"),Description("数据是否发生变化"),Browsable(false)]
        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }           
        }

        private bool _programChanging = false;
        /// <summary>
        /// 编程改变中...(非交互用户产生的改变)
        /// </summary>
        [Browsable(false)] 
        public bool ProgramChanging
        {
            get
            {
                return _programChanging;
            }
            set
            {
                _programChanging = value;
            }
        }

        /// <summary>
        /// 输入值
        /// </summary>
        [BrowsableAttribute(false)]
        public object Value
        {
            get
            {
                switch (_inputType)
                {
                    case MedInputType.Integer:
                    case MedInputType.Nurmeric:
                        if (Text.Trim() == "")
                        {
                            return 0;
                        }
                        else
                        {
                            return int.Parse(Text);
                        }                        
                    default:
                        return Text;                        
                }
            }
        }

        [Browsable(false)]
        public bool IsInputNeeded
        {
            get
            {
                return !string.IsNullOrEmpty(_inputNeededMessage);
            }
        }

        [Browsable(false)]
        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(_inputNeededMessage) || !string.IsNullOrEmpty(Text);
            }
        }

        /// <summary>
        /// 对应Text内容的值
        /// </summary>
        public string SelfValue
        {
            set
            {
                _selfValue = value;
            }
            get
            {
                return _selfValue;
            }
        }

        /// <summary>
        /// SelfValue值是否发生变化
        /// </summary>
        [Browsable(false)]
        public bool SelfValueChanged
        {
            set
            {
                _selfValueChanged = value;
            }
            get
            {
                return _selfValueChanged;
            }
        }

        private object _data;
        [Browsable(false)]
        public object Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        /// <summary>
        /// 是否锁定输入区
        /// </summary>
        [Description("是否锁定输入区"),Browsable(false)]
        public bool LockInput
        {
            get
            {
                return _lockInput;
            }
            set
            {
                _lockInput = value;
            }
        }

        //private int _maxLength = 0;
        [DisplayName("最大长度"), Description("最大可输入长度"), Category("数据(自定义)")]
        public int MaxLength
        {
            get
            {
                return Properties.MaxLength; // _maxLength;
            }
            set
            {
                Properties.MaxLength = value;//_maxLength = value;
            }
        }

        /// <summary>
        /// 输入类型
        /// </summary>
        [DisplayName("输入类型"), Description("输入类型"), Category("数据(自定义)")]
        public MedInputType InputType
        {
            get
            {
                return _inputType;
            }
            set
            {
                if (_inputType != value)
                {
                    _inputType = value;
                    switch (_inputType)
                    {
                        case MedInputType.Nurmeric:
                        case MedInputType.Integer:
                        case MedInputType.PositiveInteger:
                            KeyDown += Integer_KeyDown;
                            KeyPress += Integer_KeyPress;
                            ImeMode = ImeMode.Disable;
                            break;
                        case MedInputType.Date:
                            KeyDown += new KeyEventHandler(Integer_KeyDown);
                            KeyPress += new KeyPressEventHandler(Integer_KeyPress);
                            ImeMode = ImeMode.Disable;
                            break;
                        case MedInputType.Time:
                            KeyDown += new KeyEventHandler(Integer_KeyDown);
                            KeyPress += new KeyPressEventHandler(Integer_KeyPress);
                            ImeMode = ImeMode.Disable;
                            break;
                        case MedInputType.Line:
                        case MedInputType.VerticalLine:
                            if (this.Parent != null)
                            {
                                //BorderStyle = BorderStyle.None;
                                if (Parent != null)
                                {
                                    BackColor = Parent.BackColor;
                                }
                            }
                            break;
                        default:
                            ImeMode = ImeMode.NoControl;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 最小值
        /// </summary>
        private string _minimum = null;
        /// <summary>
        /// 最小值
        /// </summary>
        [DisplayName("最小值"), Description("最小值"), Category("数据(自定义)")]
        public string Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                _minimum = value;
            }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        private string _maximum = null;
        /// <summary>
        /// 最大值
        /// </summary>
        [DisplayName("最大值"), Description("最大值"), Category("数据(自定义)")]
        public string Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
            }
        }

        /// <summary>
        /// 小数位数
        /// </summary>
        private int _dotNumber = 0;
        /// <summary>
        /// 小数位数
        /// </summary>
        [DisplayName("小数位数"), Description("小数位数"), Category("数据(自定义)")]
        public int DotNumber
        {
            get
            {
                return _dotNumber;
            }
            set
            {
                _dotNumber = value;
            }
        }

        /// <summary>
        /// 是否可为空
        /// </summary>
        private bool _nullAble = true;
        /// <summary>
        /// 是否可为空
        /// </summary>
        [DisplayName("是否可为空"), Description("是否可为空"), Category("数据(自定义)")]
        public bool NullAble
        {
            get
            {
                return _nullAble;
            }
            set
            {
                _nullAble = value;
            }
        }

        /// <summary>
        /// 绑定表名称
        /// </summary>
        [DisplayName("绑定表名称"),Description("绑定表名称"), Category("数据(自定义)"),Browsable(false)]
        [Editor(typeof(TableNamesDropDownEditor), typeof(UITypeEditor))]
        public string BindTableName
        {
            get
            {
                return _bindTableName;
            }
            set
            {
                _bindTableName = value;
            }
        }

        /// <summary>
        /// 绑定表名称
        /// </summary>
        [DisplayName("源数据表名称"),Description("数据源:表名称"), Category("数据(自定义)")]
        [Editor(typeof(TableNamesDropDownEditor), typeof(UITypeEditor))]
        public string SourceTableName
        {
            get
            {
                return _bindTableName;
            }
            set
            {
                _bindTableName = value;
            }
        }

        /// <summary>
        /// 绑定字段名称
        /// </summary>
        [DisplayName("源数据字段名称"),Description("数据源:字段名称"), Category("数据(自定义)")]
        [Editor(typeof(SourceFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string SourceFieldName
        {
            get
            {
                return _bindFieldName;
            }
            set
            {
                _bindFieldName = value;
            }
        }

        /// <summary>
        /// 绑定字段名称
        /// </summary>
        [DisplayName("绑定字段名称"),Description("绑定字段名称"), Category("数据(自定义)"), Browsable(false)]
        public string BindFieldName
        {
            get
            {
                return _bindFieldName;
            }
            set
            {
                _bindFieldName = value;
            }
        }

        /// <summary>
        /// 快速录入绑定表名
        /// </summary>
        [DisplayName("字典表名称"),Description("字典录入:表名"), Category("数据(自定义)")]
        [Editor(typeof(DictTableNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictTableName
        {
            set
            {
                _celerityInputTableName = value;
            }
            get
            {
                return _celerityInputTableName;
            }
        }




        /// <summary>
        /// 快速录入绑定表名
        /// </summary>
        [DisplayName("快速录入绑定表名"),Description("快速录入绑定表名"), Category("数据(自定义)"), Browsable(false)]
        [Editor(typeof(TableNamesDropDownEditor), typeof(UITypeEditor))]
        public string CelerityInputTableName
        {
            set
            {
                _celerityInputTableName = value;
            }
            get
            {
                return _celerityInputTableName;
            }
        }

        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [DisplayName("快速录入绑定值字段名"),Description("快速录入绑定值字段名"), Category("数据(自定义)"),Browsable(false)]
        public string CelerityInputValueColumnName
        {
            set
            {
                _celerityInputValueColumnName = value;
            }
            get
            {
                return _celerityInputValueColumnName;
            }
        }

        /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [DisplayName("字典字段名称"),Description("字典录入:值对应字段名"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictValueFieldName
        {
            set
            {
                _celerityInputValueColumnName = value;
            }
            get
            {
                return _celerityInputValueColumnName;
            }
        }

        /// <summary>
        /// 快速录入绑定拼音字段名
        /// </summary>
        [DisplayName("快速录入绑定拼音字段名"),Description("快速录入绑定拼音字段名"), Category("数据(自定义)"),Browsable(false)]
        public string CelerityInputCodeColumnName
        {
            set
            {
                _celerityInputCodeColumnName = value;
            }
            get
            {
                return _celerityInputCodeColumnName;
            }
        }

        /// <summary>
        /// 快速录入绑定拼音字段名
        /// </summary>
        [DisplayName("字典显示字段名称"),Description("字典录入:显示字段名"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DisplayFieldName
        {
            set
            {
                _celerityInputCodeColumnName = value;
            }
            get
            {
                return _celerityInputCodeColumnName;
            }
        }

        /// <summary>
        /// 多列字段显示
        /// </summary>
        [DisplayName("字典下拉多列字段显示"), Description("字典下拉多列字段显示"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DisplayMutiColFieldName
        {
            set
            {
                _displayMutiColFieldName = value;
            }
            get
            {
                return _displayMutiColFieldName;
            }
        }
        /// <summary>
        /// 快速录入过滤条件
        /// </summary>
        [DisplayName("快速录入过滤条件"),Description("快速录入过滤条件"), Category("数据(自定义)"),Browsable(false)]
        public string CelerityInputSqlWhere
        {
            set
            {
                _celerityInputSqlWhere = value;
            }
            get
            {
                return _celerityInputSqlWhere;
            }
        }

        /// <summary>
        /// 快速录入过滤条件
        /// </summary>
        [DisplayName("字典录入筛选条件"),Description("字典录入:选择项目筛选条件"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictWhereString
        {
            set
            {
                _celerityInputSqlWhere = value;
            }
            get
            {
                return _celerityInputSqlWhere;
            }
        }

        /// <summary>
        /// 下拉框绑定列表，用@分割
        /// </summary>
        [DisplayName("下拉框绑定列表"),Description("下拉框绑定列表，用@分割"), Category("数据(自定义)"),Browsable(false)]
        public string BindList
        {
            set
            {
                _bindList = value;
            }
            get
            {
                return _bindList;
            }
        }

        /// <summary>
        /// 下拉框绑定类型标志位，真为多选，假为单选
        /// </summary>
        [Description("下拉框绑定类型标志位，真为多选，假为单选"), Category("数据(自定义)"),Browsable(false)]
        public bool MultiSign
        {
            set
            {
                _multiSign = value;
            }
            get
            {
                return _multiSign;
            }
        }

        /// <summary>
        /// 下拉框绑定类型标志位，真为多选，假为单选
        /// </summary>
        [Description("下拉框绑定类型标志位，真为多选，假为单选"), Category("数据(自定义)")]
        public bool MultiSelect
        {
            set
            {
                _multiSign = value;
            }
            get
            {
                return _multiSign;
            }
        }

        /// <summary>
        /// 格式化样式
        /// </summary>
        [DisplayName("格式化字符串"),Description("格式化样式字符串"), Category("数据(自定义)")]
        public string Format
        {
            set
            {
                _format = value;
            }
            get
            {
                return _format;
            }
        }

        private string _inputNeededMessage = "";
        /// <summary>
        /// 格式化样式
        /// </summary>
        [DisplayName("必填项提示"),Description("必填项提示"), Category("数据(自定义)")]
        public string InputNeededMessage
        {
            set
            {
                _inputNeededMessage = value;
            }
            get
            {
                return _inputNeededMessage;
            }
        }

        private string _initValue = "";
        [DisplayName("初始值"), Description("初始值"), Category("数据(自定义)")]
        public string InitValue
        {
            get
            {
                return _initValue;
            }
            set
            {
                _initValue = value;
            }
        }

        private string _defaultPrintText;
        [DisplayName("默认打印文本"), Description("当内容为空时，默认打印的内容"), Category("数据(自定义)")]
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

        private string _wantValueBeforePrint = "";
        [DisplayName("打印必填项目提示"), Description("当本文本为打印前必填项时，指示用户必须填写的提示内容"), Category("数据(自定义)")]
        public string WantValueBeforePrint
        {
            set
            {
                _wantValueBeforePrint = value;
            }
            get
            {
                return _wantValueBeforePrint;
            }
        }

        private bool _noPrint = false;
        [DisplayName("是否不打印"), Description("本文本内容是否在打印时显示"), Category("数据(自定义)")]
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

        private string _noPrintText;
        [DisplayName("不打印文本"), Description("形如该内容的文本打印时都不出现"), Category("数据(自定义)")]
        public string NoPrintText
        {
            get
            {
                return string.IsNullOrEmpty(_noPrintText) ? "" : _noPrintText;
            }
            set
            {
                _noPrintText = value;
            }
        }

        private bool _bottomLine = false;
        [DisplayName("打印底线"), Description("打印底线"), Category("数据(自定义)")]
        public bool BottomLine
        {
            get
            {
                return _bottomLine;
            }
            set
            {
                _bottomLine = value;
            }
        }

        private float _underLineOffset = 0;
        [DisplayName("底线偏移量"), Description("底线偏移量"), Category("数据(自定义)")]
        public float UnderLineOffset
        {
            get
            {
                return _underLineOffset;
            }
            set
            {
                _underLineOffset = value;
            }
        }
        private System.Drawing.Drawing2D.DashStyle _bottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        [DisplayName("底线风格"), Description("底线风格"), Category("数据(自定义)")]
        public System.Drawing.Drawing2D.DashStyle BottomLineStyle
        {
            get
            {
                return _bottomLineStyle;
            }
            set
            {
                _bottomLineStyle = value;
            }
        }

        private bool _canEdit = true;
        [DisplayName("是否可编辑"), Description("当有下拉录入支持时，是否可直接录入"), Category("数据(自定义)")]
        public bool CanEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                _canEdit = value;
            }
        }

        private bool IsDigit()
        {
            return (_data != null && (_data is int || _data is double || _data is Single || _data is decimal));
        }

        public void SetData(object value)
        {
            _data = value;
            SetText();
        }

        public string GetInitText()
        {
            string text = "";
            if (!string.IsNullOrEmpty(_initValue))
            {
                if (_initValue.ToLower().Equals("<%=today%>"))
                {
                    string format = "yyyy-MM-dd";
                    if (!string.IsNullOrEmpty(_format))
                    {
                        format = _format;
                    }
                    string replaceString = "-";
                    text = DateTime.Today.ToString(TransFormat(format, ref replaceString)).Replace("-", replaceString);
                }
                else if (_initValue.ToLower().Equals("<%=today-1%>"))
                {
                    string format = "yyyy-MM-dd";
                    if (!string.IsNullOrEmpty(_format))
                    {
                        format = _format;
                    }
                    string replaceString = "-";
                    text = DateTime.Today.AddDays(-1).ToString(TransFormat(format, ref replaceString)).Replace("-", replaceString);
                }
                else if (_initValue.ToLower().Equals("<%=now%>"))
                {
                    _data = DateTime.Now;
                    string format = "yyyy-MM-dd HH:mm";
                    if (!string.IsNullOrEmpty(_format))
                    {
                        format = _format;
                    }
                    string replaceString = "-";
                    text = DateTime.Now.ToString(TransFormat(format, ref replaceString)).Replace("-", replaceString);
                }
                else
                {
                    text = _initValue;
                }
            }
            return text;
        }

        public void SetText(object value)
        {
            string text;
            if (value != null)
            {
                text = value.ToString();
                if (IsDigit())
                {
                    while (text.IndexOf(".") > 0 && (text.EndsWith("0") || text.EndsWith(".")))
                    {
                        text = text.Substring(0, text.Length - 1);
                    }
                }
                else if (!string.IsNullOrEmpty(_format))
                {
                    if (value is DateTime)
                    {
                        try
                        {
                            text = FormatDateTime((DateTime)value, _format);
                            //string replaceString = "-";
                            //text = ((DateTime)value).ToString(TransFormat(_format, ref replaceString)).Replace("-", replaceString);
                        }
                        catch
                        {
                            text = value.ToString();
                        }
                    }
                }
            }
            else
            {
                text = GetInitText();
            }
            _programChanging = true;
            Text = text;
            _programChanging = false;
        }

        public void SetText()
        {
            SetText(_data);
        }

        protected bool IsFunctionFormat(string format)
        {
            if (!string.IsNullOrEmpty(format))
            {
                if (format.ToLower().Trim().Equals("datetoage"))
                {
                    return true;
                }
            }
            return false;
        }

        protected string FormatDateTime(DateTime dateTime, string format)
        {
            if (IsDateTimeFomrat(format))
            {
                string replaceString = "-";
                return dateTime.ToString(TransFormat(format, ref replaceString)).Replace("-", replaceString);
            }
            else if (IsFunctionFormat(format))
            {
                if (format.ToLower().Trim().Equals("datetoage"))
                {
                   
                }
            }
            return dateTime.ToString();
        }

        protected override void OnClick(EventArgs e)
        {
    
            base.OnClick(e);
            if(_inputType.Equals(MedInputType.Time))
            {
                SelectNum();
            }
        }

        private void SelectNum()
        {
            if (SelectionStart <= Text.IndexOf(":"))
            {
                SelectionStart = 0;
                SelectionLength = 2;
                Select();
            }
            else if (SelectionStart > Text.IndexOf(":"))
            {
                SelectionStart = Text.IndexOf(":") + 1;
                SelectionLength = 2;
                Select();
            }
        }

        /// <summary>
        /// 整数输入控制-键盘按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Integer_KeyDown(object sender, KeyEventArgs e)
        {
            isRejectInput = false;
            if((e.Modifiers & Keys.Shift) == Keys.Shift)
            {
                isRejectInput = true;
                e.Handled = true;
                return;
            }
            if (_inputType == MedInputType.Integer || _inputType == MedInputType.Nurmeric || _inputType == MedInputType.PositiveInteger)
            {
                ///数字0-9
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    ///数字键区域0-9
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        int vMin = int.MinValue;
                        if (!string.IsNullOrEmpty(_minimum))
                        {
                            if (!int.TryParse(_minimum, out vMin))
                            {
                                vMin = int.MinValue;
                            }
                        }
                        ///退格键或者减号键
                        if ((e.KeyCode != Keys.Back) && ((vMin >= 0) || (e.KeyCode != Keys.Subtract)))
                        {
                            if (_inputType == MedInputType.Integer || _inputType == MedInputType.PositiveInteger)
                            {
                                isRejectInput = true;
                            }
                            else if (e.KeyCode != Keys.Decimal || (e.KeyCode == Keys.Decimal && Text.Contains(".")))
                            {
                                if (e.KeyCode != Keys.OemPeriod || (e.KeyCode == Keys.OemPeriod && Text.Contains(".")))
                                    isRejectInput = true;
                            }
                            if (e.KeyValue == 190 && _inputType == MedInputType.PositiveInteger)
                            {
                                isRejectInput = true;
                            }
                               
                        }
                    }
                }
            }
            else if (_inputType == MedInputType.Date)
            {
                if (e.KeyCode < Keys.D0 || (e.KeyCode > Keys.D9&&e.KeyCode<Keys.NumPad0)||e.KeyCode>Keys.NumPad9)
                {
                    isRejectInput = true;
                }
                else
                {
                    string text="";
                    if (e.KeyCode>=Keys.D0 && e.KeyCode <= Keys.D9)
                    {
                        text = Text + ((int)((int)e.KeyCode - (int)Keys.D0)).ToString();
                        if (SelectionLength > 0)
                        {
                            text = Text.Substring(0, SelectionStart) + ((int)((int)e.KeyCode - (int)Keys.D0)).ToString()
                                + Text.Substring(SelectionStart + SelectionLength);
                        }
                    }
                    else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                    {
                        text = Text + ((int)((int)e.KeyCode - (int)Keys.NumPad0)).ToString();
                        if (SelectionLength > 0)
                        {
                            text = Text.Substring(0, SelectionStart) + ((int)((int)e.KeyCode - (int)Keys.NumPad0)).ToString()
                                + Text.Substring(SelectionStart + SelectionLength);
                        }
                    }
                    string errMessage = CheckInput(text);
                    if (!string.IsNullOrEmpty(errMessage))
                    {
                        isRejectInput = true;
                    }
                }
            }
            else if (_inputType == MedInputType.Time)
            {
                if ((e.KeyCode < Keys.D0 && e.KeyCode > Keys.Down) || e.KeyCode < Keys.Left || (e.KeyCode > Keys.D9 && e.KeyCode < Keys.NumPad0) || e.KeyCode > Keys.NumPad9)
                {
                    isRejectInput = true;
                }
                else
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        SelectionStart = 0;
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        SelectionStart = Text.IndexOf(":") + 1;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        if (SelectionStart == 0)
                        {
                            if (int.Parse(Text.Substring(0, 2)) + 1 <= 23)
                            {
                                if (int.Parse(Text.Substring(0, 2)) + 1 <= 9)
                                {
                                    Text = "0" + (int.Parse(Text.Substring(0, 2)) + 1).ToString() + Text.Substring(2, 3);
                                }
                                else
                                {
                                    Text = (int.Parse(Text.Substring(0, 2)) + 1).ToString() + Text.Substring(2, 3);
                                }
                            }
                            SelectionStart = 0;
                        }
                        else if (SelectionStart == Text.IndexOf(":") + 1)
                        {
                            if (int.Parse(Text.Substring(3, 2)) + 1 <= 59)
                            {
                                if (int.Parse(Text.Substring(3, 2)) + 1 <= 9)
                                {
                                    Text = Text.Substring(0, 3) + "0" + (int.Parse(Text.Substring(3, 2)) + 1).ToString();
                                }
                                else
                                {
                                    Text = Text.Substring(0, 3) + (int.Parse(Text.Substring(3, 2)) + 1).ToString();
                                }
                            }
                            SelectionStart = Text.IndexOf(":") + 1;
                        }
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        if (SelectionStart == 0)
                        {
                            if (int.Parse(Text.Substring(0, 2)) - 1 >= 0)
                            {
                                if (int.Parse(Text.Substring(0, 2)) - 1 <= 9)
                                {
                                    Text = "0" + (int.Parse(Text.Substring(0, 2)) - 1).ToString() + Text.Substring(2, 3);
                                }
                                else
                                {
                                    Text = (int.Parse(Text.Substring(0, 2)) - 1).ToString() + Text.Substring(2, 3);
                                }
                            }
                            SelectionStart = 0;
                        }
                        else if (SelectionStart == Text.IndexOf(":") + 1)
                        {
                            if (int.Parse(Text.Substring(3, 2)) - 1 >= 0)
                            {
                                if (int.Parse(Text.Substring(3, 2)) - 1 <= 9)
                                {
                                    Text = Text.Substring(0, 3) + "0" + (int.Parse(Text.Substring(3, 2)) - 1).ToString();
                                }
                                else
                                {
                                    Text = Text.Substring(0, 3) + (int.Parse(Text.Substring(3, 2)) - 1).ToString();
                                }
                            }
                            SelectionStart = Text.IndexOf(":") + 1;
                        }
                    }
                    else
                    {
                        if (Text.Equals(string.Empty))
                        {
                            Text = "00:00";
                            SelectionStart = 0;
                        }
                    }
                    SelectNum();
                    e.Handled = true;
                }            
            }
        }

        /// <summary>
        /// 整数输入控制-键盘输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Integer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isRejectInput == true)
            {
                e.Handled = true;
                isRejectInput = false;
            }
            else
            {
                if (_inputType.Equals(MedInputType.Time))
                {
                    if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    {
                        e.Handled = true;
                        if (SelectionStart == 0)
                        {
                            int n = (int)e.KeyChar - 48;
                            if (int.Parse(Text.Substring(1, 1) + n.ToString()) <= 23)
                            {
                                Text = Text.Substring(1, 1) + n.ToString() + Text.Substring(2, 3);
                            }
                            else
                            {
                                Text = "0" + n.ToString() + Text.Substring(2, 3);
                            }
                            SelectionStart = 0;
                        }
                        else if (SelectionStart == Text.IndexOf(":") + 1)
                        {
                            int n = (int)e.KeyChar - 48;
                            if (int.Parse(Text.Substring(4, 1) + n.ToString()) <= 59)
                            {
                                Text = Text.Substring(0, 3) + Text.Substring(4, 1) + n.ToString();
                            }
                            else
                            {
                                Text = Text.Substring(0, 3) + "0" + n.ToString();
                            }
                            SelectionStart = Text.IndexOf(":") + 1;
                        }
                        SelectNum();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(_format) && (_format.ToLower().Equals("hh:mm") || _format.ToLower().Equals("0:t")))
                    {
                        string text = Text + ((int)((int)e.KeyChar - (int)Keys.D0)).ToString();
                        int v = 0;
                        if (!int.TryParse(text, out v))
                        {
                            v = 0;
                        }
                        if (v > 2 || text.Length == 2)
                        {
                            if (!Text.Contains(":"))
                            {
                                e.Handled = true;
                                Text = text + ":";
                                SelectionStart = Text.Length;
                            }
                        }
                    }
                }
            }
        }

        // ///<summary>
        // ///文本改变
        // ///</summary>
        // ///<param name="e"></param>
        //protected override void OnTextChanged(EventArgs e)
        //{
        //    if (_lockInput)
        //    {
        //        Text = _oldValue;
        //    }
        //    else
        //    {
        //        _oldValue = Text;
        //    }            
        //    base.OnTextChanged(e);
        //}

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是否设置成功</returns>
        public bool SetValue(string value)
        {
            try
            {
                _oldValue = value;
                Text = value;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 转换日期格式
        /// </summary>
        /// <param name="format"></param>
        /// <param name="replaceString"></param>
        /// <returns></returns>
        private string TransFormat(string format, ref string replaceString)
        {
            string formatString = format;
            if (!string.IsNullOrEmpty(formatString))
            {
                formatString = formatString.ToLower().Trim();
                if (formatString.IndexOf(".") > 0)
                {
                    replaceString = ".";
                }
                else if (formatString.IndexOf("/") > 0)
                {
                    replaceString = "/";
                }
                formatString = formatString.Replace(replaceString, "-").Replace("yyyy年mm", "yyyy年MM").Replace("yyyy-mm", "yyyy-MM").Replace("hh:", "HH:");
            }
            return formatString;
        }

        /// <summary>
        /// 是否日期格式
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        private bool IsDateTimeFomrat(string format)
        {
            if (!string.IsNullOrEmpty(format))
            {
                string replaceString = "-";
                string formatString = TransFormat(format, ref replaceString);
                if (formatString.Equals("yyyy-MM-dd") || formatString.Equals("yyyy-MM-dd HH:mm") || formatString.Equals("HH:mm") || formatString.Equals("yyyy年MM月dd日"))
                {
                    return true;
                }
            }
            return false;
        }

        private float _printYOffSet = 0;
        [DisplayName("垂直打印偏移量")]
        public float PrintYOffSet
        {
            set
            {
                _printYOffSet = value;
            }
            get
            {
                return _printYOffSet;
            }
        }

        private float _printXOffSet = 0;
        [DisplayName("水平打印偏移量")]
        public float PrintXOffSet
        {
            set
            {
                _printXOffSet = value;
            }
            get
            {
                return _printXOffSet;
            }
        }

        private string _printTail = "";
        [DisplayName("打印后缀")]
        public string PrintTail
        {
            get
            {
                return _printTail;
            }
            set
            {
                _printTail = value;
            }
        }

        public void Draw(Graphics g, float x, float y)
        {
            string text = Text;
            if (text == null || string.IsNullOrEmpty(text))
            {
                text = "";
                if (!string.IsNullOrEmpty(_defaultPrintText))
                {
                    text = _defaultPrintText;
                }
            }
            if (!string.IsNullOrEmpty(_printTail))
            {
                text += _printTail;
            }
            if (!string.IsNullOrEmpty(_noPrintText))
            {
                text = text.Replace(_noPrintText, "");
            }
            if (!string.IsNullOrEmpty(text))
            {
                using (Brush brush = new SolidBrush(ForeColor))
                {
                    if (TextAlign == HorizontalAlignment.Left)
                    {
                        g.DrawString(text, Font, brush, x + _printXOffSet, y + _printYOffSet);
                    }
                    else
                    {
                        StringFormat sf = new StringFormat();
                        if (TextAlign == HorizontalAlignment.Center)
                        {
                            sf.Alignment = StringAlignment.Center;
                        }
                        else
                        {
                            sf.Alignment = StringAlignment.Far;
                        }
                        g.DrawString(text, Font, brush, new RectangleF(x + _printXOffSet, y + _printYOffSet, Width, Height), sf);
                    }
                }
            }
            if (_bottomLine)
            {
                using (Pen pen = new Pen(ForeColor, 1))
                {
                    pen.DashStyle = _bottomLineStyle;
                    g.DrawLine(pen, x, y + Height + _underLineOffset, x + Width, y + Height + _underLineOffset);
                }
            }
        }
    }
}
