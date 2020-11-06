/*----------------------------------------------------------------
      // Copyright (C) 2005 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedTextBox.cs
      // �ļ��������������������
      //
      // 
      // �ع���ʶ��������-2008-01-16 �Ż��ṹ ���ע�� ��չ
----------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Designer;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;


namespace MedicalSystem.Anes.Document.Controls
{

    /// <summary>
    /// ���������
    /// </summary>
    [ToolboxItem(true), Description("�����")]
    public class MTextBox : TextBox, ICheckable, IPrintable//TextBox, ICheckable, IPrintable
    {

        /// <summary>
        /// ���췽��
        /// </summary>
        public MTextBox()
        {

            //BorderStyle = BorderStyle.FixedSingle; //DevExpress.XtraEditors.Controls.BorderStyles.Flat; //BorderStyle.FixedSingle;            
            _oldForeColor = this.ForeColor;
            Validating += new CancelEventHandler(MedTextBox_Validating);
            //ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            KeyDown += new KeyEventHandler(MedTextBox_KeyDown);
            KeyPress += new KeyPressEventHandler(MedTextBox_KeyPress);



            ////===============͸������ʹ��========================
            //    InitializeComponent();
            //   this.BackColor = myBackColor;

            //    this.SetStyle(ControlStyles.UserPaint, false);
            //    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //    this.SetStyle(ControlStyles.DoubleBuffer, true);


            //    //myPictureBox = new uPictureBox();
            //    //this.Controls.Add(myPictureBox);
            //    //myPictureBox.Dock = DockStyle.Fill;
            // //=======================================
        }

        void MedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_canEdit)
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
            if (!_canEdit)
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
        private string _selectedText = string.Empty;
        /// <summary>
        /// ����������ѡ�����ʾֵ
        /// </summary>
        [Browsable(false)]
        public new string SelectedText
        {
            get
            {
                return _selectedText;
            }
            set
            {
                base.Text = value;
                _selectedText = value;

            }
        }
        private object _selectedData;
        /// <summary>
        /// ����������ѡ���ʵ��ֵ
        /// </summary>
        [Browsable(false)]
        public object SelectedData
        {
            get
            {
                return _selectedData;
            }
            set
            {
                Data = value;
                _selectedData = value;

            }
        }
        private bool _hasLookUpItems = false;
        /// <summary>
        /// �Ƿ���������ѡ����
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

        private string CheckInput(string text)
        {
            switch (_inputType)
            {
                case MedInputType.Date:
                    DateTime dt = TryParseDateTime(text);
                    if (dt == DateTime.MinValue)
                    {
                        return "��Ч�����ڸ�ʽ";
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
                            return "����ֵС����Сֵ" + _minimum;
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
                            return "����ֵС����Сֵ" + _minimum;
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
                            return "����ֵС����Сֵ" + _minimum;
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
                            return "����ֵ�������ֵ" + _maximum;
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
                            return "����ֵ�������ֵ" + _maximum;
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
                            return "����ֵ�������ֵ" + _maximum;
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
                            return "��Ч�����ָ�ʽ";
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
                                return "С��λ�����ԣ�ֻ����" + _dotNumber.ToString() + "λС��";
                            }
                        }
                    }
                    break;
            }
            return null;
        }
        private string _errorText = string.Empty;

        public string ErrorText
        {
            get
            {
                return _errorText;
            }
            set
            {
                _errorText = value;
            }
        }
        private void MedTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!_nullAble && string.IsNullOrEmpty(Text))
            {
                ErrorText = "���ݲ���Ϊ�գ�";
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
        [DisplayName("�����Ŀ����(ExamItemName)")]
        public string ExamItemName
        {
            get { return examItemName; }
            set { examItemName = value; }
        }

        private string labItemName;
        [DisplayName("������Ŀ����(LabItemName)")]
        public string LabItemName
        {
            get { return labItemName; }
            set { labItemName = value; }
        }

        private string labItemType;
        [DisplayName("������Ŀ���(LabItemType)")]
        public string LabItemType
        {
            get { return labItemType; }
            set { labItemType = value; }
        }

        private string summaryName;
        [DisplayName("������Ŀ����(SummaryName)")]
        public string SummaryName
        {
            get { return summaryName; }
            set { summaryName = value; }
        }

        /// <summary>
        /// �߿���ɫ
        /// </summary>
        private Color borderColor = Color.LightGray;

        /// <summary>
        /// �߿�����
        /// </summary>
        private Border3DStyle border3DStyle = Border3DStyle.Adjust;

        /// <summary>
        /// �ֶ�����
        /// </summary>
        private string fieldName;

        /// <summary>
        /// ��������
        /// </summary>
        private MedInputType _inputType = MedInputType.General;

        /// <summary>
        /// �Ƿ�ܾ�����
        /// </summary>
        private bool isRejectInput = false;

        /// <summary>
        /// �Ƿ�����������
        /// </summary>
        private bool _lockInput = false;

        /// <summary>
        /// �Ƿ����߱߿�
        /// </summary>
        private bool _dotBorder = false;

        /// <summary>
        /// �󶨱�����
        /// </summary>
        private string _bindTableName = string.Empty;

        /// <summary>
        /// ���ֶ�����
        /// </summary>
        private string _bindFieldName = string.Empty;

        private string _celerityInputTableName = string.Empty;
        private string _celerityInputValueColumnName = string.Empty;
        private string _celerityInputCodeColumnName = string.Empty;
        private string _celerityInputSqlWhere = string.Empty;
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
        //        return _borderStyle;base.bo
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
        /// �߿���ɫ
        /// </summary>
        [Description("�߿���ɫ")]
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

        //public char PasswordChar
        //{
        //    get
        //    {
        //        return base.PasswordChar;
        //    }
        //    set
        //    {
        //        base.PasswordChar = value;
        //    }
        //}

        //private bool _multiLine = false;
        //public bool Multiline
        //{
        //    get
        //    {
        //        return _multiLine;
        //    }
        //    set
        //    {
        //        _multiLine = value;
        //    }
        //}

        //private bool _readOnly = false;
        //public bool ReadOnly
        //{
        //    get
        //    {
        //        return base.ReadOnly; //_readOnly;
        //    }
        //    set
        //    {
        //        base.ReadOnly = value;
        //        //base = value;
        //    }
        //}

        //private bool _wordWrap = false;
        //public bool WordWrap
        //{
        //    get
        //    {
        //        return base.WordWrap;
        //    }
        //    set
        //    {
        //        base = value;
        //    }
        //}

        //private HorizontalAlignment _textAlign = HorizontalAlignment.Left;
        //public HorizontalAlignment TextAlign
        //{
        //    get
        //    {
        //        return _textAlign;
        //    }
        //    set
        //    {
        //        _textAlign = value;
        //        switch (_textAlign)
        //        {
        //            case HorizontalAlignment.Center:
        //                Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //                break;
        //            case HorizontalAlignment.Left:
        //                Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        //                break;
        //            case HorizontalAlignment.Right:
        //                Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        //                break;
        //            default:
        //                Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// ���ݱ仯ǰ��ɫ
        /// </summary>
        [Description("���ݱ仯ǰ��ɫ")]
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


        /// <summary>
        /// �߿�����
        /// </summary>
        [Description("�߿�����")]
        public Border3DStyle Border3DStyle
        {
            get
            {
                return border3DStyle;
            }
            set
            {
                border3DStyle = value;
            }
        }

        /// <summary>
        /// �ֶ�����
        /// </summary>
        [DisplayName("�ֶ�����"), Description("�ֶ�����"), Category("����(�Զ���)"), Browsable(false)]
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
        /// �Ƿ����߱߿�
        /// </summary>
        [DisplayName("�Ƿ����߱߿�"), Description("�Ƿ����߱߿�")]
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
        /// �����Ƿ����仯
        /// </summary>
        [DisplayName("�����Ƿ����仯"), Description("�����Ƿ����仯"), Browsable(false)]
        public virtual bool IsChanged
        {
            get
            {
                return _isChanged;
            }
        }

        private bool _programChanging = false;
        /// <summary>
        /// ��̸ı���...(�ǽ����û������ĸı�)
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
        /// ����ֵ
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
        /// ��ӦText���ݵ�ֵ
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
        /// SelfValueֵ�Ƿ����仯
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
        public virtual object Data
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
        /// �Ƿ�����������
        /// </summary>
        [Description("�Ƿ�����������"), Browsable(false)]
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
        //[DisplayName("��󳤶�"), Description("�������볤��"), Category("����(�Զ���)")]
        //public int MaxLength
        //{
        //    get
        //    {
        //        return Properties.MaxLength; // _maxLength;b
        //    }
        //    set
        //    {

        //        Properties.MaxLength = value;//_maxLength = value;
        //    }
        //}

        /// <summary>
        /// ��������
        /// </summary>
        [DisplayName("��������"), Description("��������"), Category("����(�Զ���)")]
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
        /// ��Сֵ
        /// </summary>
        private string _minimum = null;
        /// <summary>
        /// ��Сֵ
        /// </summary>
        [DisplayName("��Сֵ"), Description("��Сֵ"), Category("����(�Զ���)")]
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
        /// ���ֵ
        /// </summary>
        private string _maximum = null;
        /// <summary>
        /// ���ֵ
        /// </summary>
        [DisplayName("���ֵ"), Description("���ֵ"), Category("����(�Զ���)")]
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
        /// С��λ��
        /// </summary>
        private int _dotNumber = 0;
        /// <summary>
        /// С��λ��
        /// </summary>
        [DisplayName("С��λ��"), Description("С��λ��"), Category("����(�Զ���)")]
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
        private int _locationPoint = 0;
        [DisplayName("��λ��ʶ"), Description("��λ��ʶ"), Category("����(�Զ���)")]
        public int LocationPoint
        {
            get
            {
                return _locationPoint;
            }
            set
            {
                _locationPoint = value;
            }
        }
        #region MyRegion
        //private int point = 0;
        //public int Point
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(LocationPoint) && LocationPoint.Contains("/"))
        //        {
        //            string[] s = LocationPoint.Split('/');
        //            if (s.Length == 3)
        //            {
        //                point = Convert.ToInt32(s[2]);
        //            }
        //        }
        //        return point;
        //    }
        //}
        //private int rowPoint = 0;
        //public int RowPoint
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(LocationPoint) && LocationPoint.Contains("/"))
        //        {
        //            string[] s = LocationPoint.Split('/');
        //            if (s.Length == 3)
        //            {
        //                rowPoint = Convert.ToInt32(s[0]);
        //            }
        //        }
        //        return rowPoint;
        //    }
        //}
        //private int colPoint = 0;
        //public int ColPoint
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(LocationPoint) && LocationPoint.Contains("/"))
        //        {
        //            string[] s = LocationPoint.Split('/');
        //            if (s.Length == 3)
        //            {
        //                colPoint = Convert.ToInt32(s[1]);
        //            }
        //        }
        //        return colPoint;
        //    }
        //} 
        #endregion
        /// <summary>
        /// �Ƿ��Ϊ��
        /// </summary>
        private bool _nullAble = true;
        /// <summary>
        /// �Ƿ��Ϊ��
        /// </summary>
        [DisplayName("�Ƿ��Ϊ��"), Description("�Ƿ��Ϊ��"), Category("����(�Զ���)")]
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
        /// �Ƿ�Ϊ����ģ��ؼ�
        /// </summary>
        private bool _isTotalModel = false;
        /// <summary>
        /// �Ƿ�Ϊ����ģ��ؼ�
        /// </summary>
        [DisplayName("�Ƿ�Ϊ����ģ��"), Description("�Ƿ�Ϊ����ģ��"), Category("����(�Զ���)")]
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

        /// <summary>
        /// �󶨱�����
        /// </summary>
        [DisplayName("�󶨱�����"), Description("�󶨱�����"), Category("����(�Զ���)"), Browsable(false)]
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
        /// �󶨱�����
        /// </summary>
        [DisplayName("Դ���ݱ�����"), Description("����Դ:������"), Category("����(�Զ���)")]
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
        /// ���ֶ�����
        /// </summary>
        [DisplayName("Դ�����ֶ�����"), Description("����Դ:�ֶ�����"), Category("����(�Զ���)")]
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
        /// ���ֶ�����
        /// </summary>
        [DisplayName("���ֶ�����"), Description("���ֶ�����"), Category("����(�Զ���)"), Browsable(false)]
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
        /// ����¼��󶨱���
        /// </summary>
        [DisplayName("�ֵ������"), Description("�ֵ�¼��:����"), Category("����(�Զ���)")]
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
        /// ����¼��󶨱���
        /// </summary>
        [DisplayName("����¼��󶨱���"), Description("����¼��󶨱���"), Category("����(�Զ���)"), Browsable(false)]
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
        /// ����¼���ֵ�ֶ���
        /// </summary>
        [DisplayName("����¼���ֵ�ֶ���"), Description("����¼���ֵ�ֶ���"), Category("����(�Զ���)"), Browsable(false)]
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
        /// ����¼���ֵ�ֶ���
        /// </summary>
        [DisplayName("�ֵ��ֶ�����"), Description("�ֵ�¼��:ֵ��Ӧ�ֶ���"), Category("����(�Զ���)")]
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
        /// ����¼���ƴ���ֶ���
        /// </summary>
        [DisplayName("����¼���ƴ���ֶ���"), Description("����¼���ƴ���ֶ���"), Category("����(�Զ���)"), Browsable(false)]
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
        /// ����¼���ƴ���ֶ���
        /// </summary>
        [DisplayName("�ֵ���ʾ�ֶ�����"), Description("�ֵ�¼��:��ʾ�ֶ���"), Category("����(�Զ���)")]
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
        /// ����¼���������
        /// </summary>
        [DisplayName("����¼���������"), Description("����¼���������"), Category("����(�Զ���)"), Browsable(false)]
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
        /// ����¼���������
        /// </summary>
        [DisplayName("�ֵ�¼��ɸѡ����"), Description("�ֵ�¼��:ѡ����Ŀɸѡ����"), Category("����(�Զ���)")]
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
        /// ��������б���@�ָ�
        /// </summary>
        [DisplayName("��������б�"), Description("��������б���@�ָ�"), Category("����(�Զ���)"), Browsable(false)]
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
        /// ����������ͱ�־λ����Ϊ��ѡ����Ϊ��ѡ
        /// </summary>
        [Description("����������ͱ�־λ����Ϊ��ѡ����Ϊ��ѡ"), Category("����(�Զ���)"), Browsable(false)]
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
        /// ����������ͱ�־λ����Ϊ��ѡ����Ϊ��ѡ
        /// </summary>
        [Description("����������ͱ�־λ����Ϊ��ѡ����Ϊ��ѡ"), Category("����(�Զ���)")]
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
        /// ��ʽ����ʽ
        /// </summary>
        [DisplayName("��ʽ���ַ���"), Description("��ʽ����ʽ�ַ���"), Category("����(�Զ���)")]
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
        /// ��������ʾ
        /// </summary>
        [DisplayName("��������ʾ"), Description("��������ʾ"), Category("����(�Զ���)")]
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
        [DisplayName("��ʼֵ"), Description("��ʼֵ"), Category("����(�Զ���)")]
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
        [DisplayName("Ĭ�ϴ�ӡ�ı�"), Description("������Ϊ��ʱ��Ĭ�ϴ�ӡ������"), Category("����(�Զ���)")]
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
        [DisplayName("��ӡ������Ŀ��ʾ"), Description("�����ı�Ϊ��ӡǰ������ʱ��ָʾ�û�������д����ʾ����"), Category("����(�Զ���)")]
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
        [DisplayName("�Ƿ񲻴�ӡ"), Description("���ı������Ƿ��ڴ�ӡʱ��ʾ"), Category("����(�Զ���)")]
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
        [DisplayName("����ӡ�ı�"), Description("��������ݵ��ı���ӡʱ��������"), Category("����(�Զ���)")]
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
        [DisplayName("��ӡ����"), Description("��ӡ����"), Category("����(�Զ���)")]
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

        private System.Drawing.Drawing2D.DashStyle _bottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        [DisplayName("���߷��"), Description("���߷��"), Category("����(�Զ���)")]
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
        [DisplayName("�Ƿ�ɱ༭"), Description("��������¼��֧��ʱ���Ƿ��ֱ��¼��"), Category("����(�Զ���)")]
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
                else if (_initValue.ToLower().Equals("<%=today+1%>"))
                {
                    string format = "yyyy-MM-dd";
                    if (!string.IsNullOrEmpty(_format))
                    {
                        format = _format;
                    }
                    string replaceString = "-";
                    text = DateTime.Today.AddDays(1).ToString(TransFormat(format, ref replaceString)).Replace("-", replaceString);
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
                    //Add by wenpei.x@2014-02-12
                    //�ı����ڰ����������ֵ��ʱ��Ĭ��ֵ��Ҫͬʱд��Data
                    if (!string.IsNullOrEmpty(_celerityInputTableName))
                    {
                        _data = _initValue;
                        _selectedData = _initValue;
                    }
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
                if (string.IsNullOrEmpty(text))
                {
                    text = GetInitText();
                }
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
                    else if (_inputType == MedInputType.DefinedFunction)
                    {
                        if (_format.ToUpper().Contains("SUBSTRING"))
                        {
                            if (value != null)
                            {
                                try
                                {
                                    int indexStart = _format.IndexOf("(") + 1;
                                    string formatFunc = _format.Substring(indexStart, _format.Length - indexStart - 1);

                                    string[] formatFuncParas = formatFunc.Split(new char[] { ',' });

                                    text = value.ToString().Substring(int.Parse(formatFuncParas[0]), int.Parse(formatFuncParas[1]));
                                }
                                catch
                                {

                                    text = value.ToString();
                                }

                            }
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
            if (_inputType.Equals(MedInputType.Time))
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
        public EventHandler RaiseKeyDownEvent;
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up:
                    FocusHelper.FocusNext(this, true);
                    break;
                case Keys.Down:
                case Keys.Enter:
                    FocusHelper.FocusNext(this, false);
                    break;
            }

            if (RaiseKeyDownEvent != null)
            {
                //if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                //{ RaiseKeyDownEvent(this, e); }

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        RaiseKeyDownEvent(this, e);
                        break;
                    case Keys.Down:
                        RaiseKeyDownEvent(this, e);
                        break;
                }

            }
        }

        /// <summary>
        /// �����������-���̰���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Integer_KeyDown(object sender, KeyEventArgs e)
        {
            isRejectInput = false;
            if ((e.Modifiers & Keys.Shift) == Keys.Shift)
            {
                isRejectInput = true;
                e.Handled = true;
                return;
            }
            if (_inputType == MedInputType.Integer || _inputType == MedInputType.Nurmeric)
            {
                ///����0-9
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    ///���ּ�����0-9
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
                        ///�˸�����߼��ż�
                        if ((e.KeyCode != Keys.Back) && ((vMin >= 0) || (e.KeyCode != Keys.Subtract)))
                        {
                            if (_inputType == MedInputType.Integer)
                            {
                                isRejectInput = true;
                            }
                            else if (e.KeyCode != Keys.Decimal || (e.KeyCode == Keys.Decimal && Text.Contains(".")))
                            {
                                if (e.KeyCode != Keys.OemPeriod || (e.KeyCode == Keys.OemPeriod && Text.Contains(".")))
                                    isRejectInput = true;
                            }
                        }
                    }
                }
            }
            else if (_inputType == MedInputType.Date)
            {
                if (e.KeyCode < Keys.D0 || (e.KeyCode > Keys.D9 && e.KeyCode < Keys.NumPad0) || e.KeyCode > Keys.NumPad9)
                {
                    isRejectInput = true;
                }
                else
                {
                    string text = "";
                    if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
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
        /// �����������-��������
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
        // ///�ı��ı�
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
        /// ����ֵ
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <returns>�Ƿ����óɹ�</returns>
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
        /// ת�����ڸ�ʽ
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
                formatString = formatString.Replace(replaceString, "-").Replace("yyyy��mm", "yyyy��MM").Replace("yyyy-mm", "yyyy-MM").Replace("hh:", "HH:");
            }
            return formatString;
        }

        /// <summary>
        /// �Ƿ����ڸ�ʽ
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        private bool IsDateTimeFomrat(string format)
        {
            if (!string.IsNullOrEmpty(format))
            {
                string replaceString = "-";
                string formatString = TransFormat(format, ref replaceString);
                if (formatString.Equals("yyyy-MM-dd") || formatString.Equals("yyyy-MM-dd HH:mm") || formatString.Equals("HH:mm") || formatString.Equals("yyyy��MM��dd��"))
                {
                    return true;
                }
            }
            return false;
        }

        private float _printYOffSet = 0;
        [DisplayName("��ֱ��ӡƫ����")]
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
        [DisplayName("ˮƽ��ӡƫ����")]
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
        [DisplayName("��ӡ��׺")]
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




        private float _underLineOffset = 0;
        [DisplayName("����ƫ����"), Description("����ƫ����"), Category("����(�Զ���)")]
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
                    if (Text == null || string.IsNullOrEmpty(Text))
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        g.DrawString(text.Trim(), Font, brush, new RectangleF(x + _printXOffSet, y + _printYOffSet, Width, Height), sf);
                    }
                    else
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
            }
            if (_bottomLine)
            {
                using (Pen pen = new Pen(ForeColor, 1))
                {
                    pen.DashStyle = _bottomLineStyle;
                    g.DrawLine(pen, x, y + Height + _underLineOffset, x + Width, y + Height + _underLineOffset);
                }
            }


            if (_drawBorder)
            {

                g.TranslateTransform(x, y);
                DrawBorder(g);
                g.ResetTransform();
            }
        }



        /// <summary>
        /// �Ƿ񻭱߿�
        /// </summary>
        protected bool _drawBorder = false;

        /// <summary>
        /// �߿���
        /// </summary>
        protected int _borderWidth = 1;

        protected BorderType _borderType = BorderType.None;

        [Category("����-�Զ���"), DisplayName("�߿�����")]
        public BorderType BorderType
        {
            get
            {
                return _borderType;
            }
            set
            {
                _borderType = value;
            }
        }

        /// <summary>
        /// �߿���
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�߿���")]
        public int BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                _borderWidth = value;
            }
        }

        /// <summary>
        /// �Ƿ񻭱߿�
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�Ƿ񻭱߿�")]
        public bool IsDrawBorder
        {
            get
            {
                return _drawBorder;
            }
            set
            {
                _drawBorder = value;
                Refresh();
            }
        }


        bool _OnlyBottomLine = false;
        /// <summary>
        /// ��������ֻ��ʾ����
        /// </summary>
        [Category("����-�Զ���"), DisplayName("��������ֻ��ʾ����")]
        public bool OnlyBottomLine
        {
            get
            {
                return _OnlyBottomLine;
            }
            set
            {
                _OnlyBottomLine = value;
            }

        }
        Color _BottomLineColor = Color.Black;
        /// <summary>
        /// ��������ֻ��ʾ����ʱ�ĵ�����ɫ
        /// </summary>
        [Category("����-�Զ���"), DisplayName("��������ֻ��ʾ����ʱ�ĵ�����ɫ")]
        public Color BottomLineColor
        {
            get
            {
                return _BottomLineColor;
            }
            set
            {
                _BottomLineColor = value;
            }

        }
        /// <summary>
        /// ���ƿؼ�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //if (_drawBorder && _borderType != BorderType.None)
            //{

            //    DrawBorder(e.Graphics);

            //}





        }

        protected override void WndProc(ref   Message m)
        {
            base.WndProc(ref   m);
            if (m.Msg == MedicalSystem.Anes.Document.Utilities.WinAPI.WM_PAINT)
            {

                if (_OnlyBottomLine)
                {
                    using (Pen pen = new Pen(BottomLineColor, 1))
                    {// Graphics.FromHwnd(this.Handle)
                        Graphics g = this.CreateGraphics();
                        if (_bottomLine)
                        {
                            pen.DashStyle = _bottomLineStyle;
                        }
                        g.DrawRectangle(Pens.White, 0, 0, this.Width - 1, this.Height - 1);
                        g.DrawLine(pen, 0, this.Height - 1, this.Width - 1, this.Height - 1);
                        g.Dispose();

                    }
                }
            }
        }




        /// <summary>
        /// ���߿�
        /// </summary>
        protected virtual void DrawBorder(Graphics g)
        {
            if (_drawBorder && _borderType != BorderType.None)
            {
                Rectangle rect = ClientRectangle;
                //g.FillRectangle(new SolidBrush(BackColor), rect);
                rect.Width += -1;
                rect.Height += -1;
                Pen P = new Pen(BorderColor, _borderWidth);
                switch (_borderType)
                {
                    case BorderType.Rectangle:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.NoTop:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.RightBottom:
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftRight:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.NoBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        break;
                    case BorderType.OnlyLeft:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        break;
                    case BorderType.OnlyRight:
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.OnlyTop:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        break;
                    case BorderType.OnlyBottom:
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftRightMoveLeft:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom);
                        break;
                    case BorderType.LeftRightMoveRight:
                        g.DrawLine(P, rect.Left + 1, rect.Top, rect.Left + 1, rect.Bottom);
                        g.DrawLine(P, rect.Right + 1, rect.Top, rect.Right + 1, rect.Bottom);
                        break;
                    case BorderType.LeftTop:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        break;
                    case BorderType.LeftBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.RightTop:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.TopBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftTopBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        break;
                    case BorderType.RightTopBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftBottomRight:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftTopRight:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                }
                P.Dispose();
            }
        }

        /*


            #region "͸������˽�б���"

            //private uPictureBox myPictureBox;
            private bool myUpToDate = false;
            private bool myCaretUpToDate = false;
            private Bitmap myBitmap;
            private Bitmap myAlphaBitmap;

            private int myFontHeight = 10;

            private System.Windows.Forms.Timer myTimer1;

            private bool myCaretState = true;

            private bool myPaintedFirstTime = false;

            private Color myBackColor = Color.White;
            private int myBackAlpha = 10;


            private System.ComponentModel.Container components = null;

            #endregion // end "͸������˽�б���"


            #region "���з�����д"
            protected override void OnResize(EventArgs e)
            {

                base.OnResize(e);
                this.myBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(this.Width,this.Height);
                this.myAlphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(this.Width,this.Height);
                myUpToDate = false;
                this.Invalidate();
            }


            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                myUpToDate = false;
                this.Invalidate();
            }
            protected override void OnKeyUp(KeyEventArgs e)
            {
                base.OnKeyUp(e);
                myUpToDate = false;
                this.Invalidate();

            }

            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                base.OnKeyPress(e);
                myUpToDate = false;
                this.Invalidate();
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                this.Invalidate();
            }

            protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
            {
                base.OnGiveFeedback(gfbevent);
                myUpToDate = false;
                this.Invalidate();
            }

            protected override void OnMouseLeave(EventArgs e)
            {

                Point ptCursor = Cursor.Position;
                Form f = this.FindForm();
                ptCursor = f.PointToClient(ptCursor);
                if (!this.Bounds.Contains(ptCursor))
                    base.OnMouseLeave(e);
            }

            protected override void OnChangeUICues(UICuesEventArgs e)
            {
                base.OnChangeUICues(e);
                myUpToDate = false;
                this.Invalidate();
            }

            //--
            protected override void OnGotFocus(EventArgs e)
            {
                base.OnGotFocus(e);
                myCaretUpToDate = false;
                myUpToDate = false;
                this.Invalidate();

                myTimer1 = new System.Windows.Forms.Timer(this.components);
                myTimer1.Interval = (int)win32.GetCaretBlinkTime(); //  usually around 500;

                myTimer1.Tick += new EventHandler(myTimer1_Tick);
                myTimer1.Enabled = true;
            }

            protected override void OnLostFocus(EventArgs e)
            {
                base.OnLostFocus(e);
                myCaretUpToDate = false;
                myUpToDate = false;
                this.Invalidate();
                if (myTimer1 != null)
                {
                    myTimer1.Stop();
                    myTimer1.Dispose();

                }
              
            }

            //--		

            protected override void OnFontChanged(EventArgs e)
            {
                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, false);

                base.OnFontChanged(e);

                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, true);


                myFontHeight = GetFontHeight();


                myUpToDate = false;
                this.Invalidate();
            }

            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                myUpToDate = false;
                this.Invalidate();
            }


            protected override void WndProc(ref Message m)
            {

                base.WndProc(ref m);

                // need to rewrite as a big switch

                if (m.Msg == win32.WM_PAINT)
                {
                    myPaintedFirstTime = true;

                    if (!myUpToDate || !myCaretUpToDate)
                        GetBitmaps();
                    myUpToDate = true;
                    myCaretUpToDate = true;
                    using (Graphics g = Graphics.FromHwnd(this.Handle))
                    {
                        g.DrawImage(myAlphaBitmap, 0, (int)((Height - myAlphaBitmap.Height)/2));
                    }
                    //if (myPictureBox.Image != null) myPictureBox.Image.Dispose();
                    //myPictureBox.Image = (Image)myAlphaBitmap.Clone();

                }

                else if (m.Msg == win32.WM_HSCROLL || m.Msg == win32.WM_VSCROLL)
                {
                    myUpToDate = false;
                    this.Invalidate();
                }

                else if (m.Msg == win32.WM_LBUTTONDOWN
                    || m.Msg == win32.WM_RBUTTONDOWN
                    || m.Msg == win32.WM_LBUTTONDBLCLK
                    //  || m.Msg == win32.WM_MOUSELEAVE  ///****
                    )
                {
                    myUpToDate = false;
                    this.Invalidate();
                }

                else if (m.Msg == win32.WM_MOUSEMOVE)
                {
                    if (m.WParam.ToInt32() != 0)  //shift key or other buttons
                    {
                        myUpToDate = false;
                        this.Invalidate();
                    }
                }

            }


            /// <summary> 
            /// Clean up any resources being used.
            /// </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    //this.BackColor = Color.Pink;
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }

            #endregion		//end public method and overrides


            #region public property overrides

            public new BorderStyle BorderStyle
            {
                get { return base.BorderStyle; }
                set
                {
                    if (this.myPaintedFirstTime)
                        this.SetStyle(ControlStyles.UserPaint, false);

                    base.BorderStyle = value;

                    if (this.myPaintedFirstTime)
                        this.SetStyle(ControlStyles.UserPaint, true);

                    this.myBitmap = null;
                    this.myAlphaBitmap = null;
                    myUpToDate = false;
                    this.Invalidate();
                }
            }

            public new Color BackColor
            {
                get
                {
                    return Color.FromArgb(base.BackColor.R, base.BackColor.G, base.BackColor.B);
                }
                set
                {
                    myBackColor = value;
                    base.BackColor = value;
                    myUpToDate = false;
                }
            }
            public override bool Multiline
            {
                get { return base.Multiline; }
                set
                {
                    if (this.myPaintedFirstTime)
                        this.SetStyle(ControlStyles.UserPaint, false);

                    base.Multiline = value;

                    if (this.myPaintedFirstTime)
                        this.SetStyle(ControlStyles.UserPaint, true);

                    this.myBitmap = null;
                    this.myAlphaBitmap = null;
                    myUpToDate = false;
                    this.Invalidate();
                }
            }


            #endregion    


            #region private functions and classes

            private int GetFontHeight()
            {
                Graphics g = this.CreateGraphics();
                SizeF sf_font = g.MeasureString("X", this.Font);
                g.Dispose();
                return (int)sf_font.Height;
            }


            private void GetBitmaps()
            {

                if (myBitmap == null
                    || myAlphaBitmap == null
                    || myBitmap.Width != Width
                    || myBitmap.Height != Height
                    || myAlphaBitmap.Width != Width
                    || myAlphaBitmap.Height != Height)
                {
                    myBitmap = null;
                    myAlphaBitmap = null;
                }



                if (myBitmap == null)
                {
                    myBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(Width,Height);
                    myUpToDate = false;
                }


                if (!myUpToDate)
                {

                    this.SetStyle(ControlStyles.UserPaint, false);

                    win32.CaptureWindow(this, ref myBitmap);

                    this.SetStyle(ControlStyles.UserPaint, true);
                    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                    this.BackColor = Color.FromArgb(myBackAlpha, myBackColor);

                }
                //--



                Rectangle r2 = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
                ImageAttributes tempImageAttr = new ImageAttributes();



                ColorMap[] tempColorMap = new ColorMap[1];
                tempColorMap[0] = new ColorMap();
                tempColorMap[0].OldColor = Color.FromArgb(255, myBackColor);
                tempColorMap[0].NewColor = Color.FromArgb(myBackAlpha, myBackColor);

                tempImageAttr.SetRemapTable(tempColorMap);

                if (myAlphaBitmap != null)
                    myAlphaBitmap.Dispose();


                myAlphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(Width,Height);

                Graphics tempGraphics1 = Graphics.FromImage(myAlphaBitmap);

                tempGraphics1.DrawImage(myBitmap, r2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, GraphicsUnit.Pixel, tempImageAttr);

                tempGraphics1.Dispose();

                //----

                if (this.Focused && (this.SelectionLength == 0))
                {
                    Graphics tempGraphics2 = Graphics.FromImage(myAlphaBitmap);
                    if (myCaretState)
                    {
                        //Draw the caret
                        Point caret = this.findCaret();
                        Pen p = new Pen(this.ForeColor, 3);
                        tempGraphics2.DrawLine(p, caret.X, caret.Y + 0, caret.X, caret.Y + myFontHeight);
                        tempGraphics2.Dispose();
                    }

                }



            }



            private Point findCaret()
            {

                Point pointCaret = new Point(0);
                int i_char_loc = this.SelectionStart;
                IntPtr pi_char_loc = new IntPtr(i_char_loc);

                int i_point = win32.SendMessage(this.Handle, win32.EM_POSFROMCHAR, pi_char_loc, IntPtr.Zero);
                pointCaret = new Point(i_point);

                if (i_char_loc == 0)
                {
                    pointCaret = new Point(0);
                }
                else if (i_char_loc >= this.Text.Length)
                {
                    pi_char_loc = new IntPtr(i_char_loc - 1);
                    i_point = win32.SendMessage(this.Handle, win32.EM_POSFROMCHAR, pi_char_loc, IntPtr.Zero);
                    pointCaret = new Point(i_point);

                    Graphics g = this.CreateGraphics();
                    String t1 = this.Text.Substring(this.Text.Length - 1, 1) + "X";
                    SizeF sizet1 = g.MeasureString(t1, this.Font);
                    SizeF sizex = g.MeasureString("X", this.Font);
                    g.Dispose();
                    int xoffset = (int)(sizet1.Width - sizex.Width);
                    pointCaret.X = pointCaret.X + xoffset;

                    if (i_char_loc == this.Text.Length)
                    {
                        String slast = this.Text.Substring(Text.Length - 1, 1);
                        if (slast == "\n")
                        {
                            pointCaret.X = 1;
                            pointCaret.Y = pointCaret.Y + myFontHeight;
                        }
                    }

                }



                return pointCaret;
            }


            private void myTimer1_Tick(object sender, EventArgs e)
            {

                myCaretState = !myCaretState;
                myCaretUpToDate = false;
                this.Invalidate();
            }


            private class uPictureBox : PictureBox
            {
                public uPictureBox()
                {
                    this.SetStyle(ControlStyles.Selectable, false);
                    this.SetStyle(ControlStyles.UserPaint, true);
                    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                    this.SetStyle(ControlStyles.DoubleBuffer, true);

                    this.Cursor = null;
                    this.Enabled = true;
                    this.SizeMode = PictureBoxSizeMode.Normal;

                }




                //uPictureBox
                protected override void WndProc(ref Message m)
                {
                    if (m.Msg == win32.WM_LBUTTONDOWN
                        || m.Msg == win32.WM_RBUTTONDOWN
                        || m.Msg == win32.WM_LBUTTONDBLCLK
                        || m.Msg == win32.WM_MOUSELEAVE
                        || m.Msg == win32.WM_MOUSEMOVE)
                    {
                        
                        win32.PostMessage(this.Parent.Handle, (uint)m.Msg, m.WParam, m.LParam);
                    }

                    else if (m.Msg == win32.WM_LBUTTONUP)
                    {

                        this.Parent.Invalidate();
                    }


                    base.WndProc(ref m);
                }


            }   

            #endregion  


            #region Component Designer generated code

            private void InitializeComponent()
            {
                components = new System.ComponentModel.Container();
            }
            #endregion

            #region "��������"

            [
            Category("����(�Զ���)"),
            Description("����͸���� 0 - 255."),
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
            ]
            public int BackAlpha
            {
                get { return myBackAlpha; }
                set
                {
                    int v = value;
                    if (v > 255)
                        v = 255;
                    myBackAlpha = v;
                    myUpToDate = false;
                    Invalidate();
                }
            }

            #endregion


        */

    }


    //public class win32
    //{

    //    public const int WM_MOUSEMOVE = 0x0200;
    //    public const int WM_LBUTTONDOWN = 0x0201;
    //    public const int WM_LBUTTONUP = 0x0202;
    //    public const int WM_RBUTTONDOWN = 0x0204;
    //    public const int WM_LBUTTONDBLCLK = 0x0203;

    //    public const int WM_MOUSELEAVE = 0x02A3;



    //    public const int WM_PAINT = 0x000F;
    //    public const int WM_ERASEBKGND = 0x0014;

    //    public const int WM_PRINT = 0x0317;

    //    //const int EN_HSCROLL       =   0x0601;
    //    //const int EN_VSCROLL       =   0x0602;

    //    public const int WM_HSCROLL = 0x0114;
    //    public const int WM_VSCROLL = 0x0115;


    //    public const int EM_GETSEL = 0x00B0;
    //    public const int EM_LINEINDEX = 0x00BB;
    //    public const int EM_LINEFROMCHAR = 0x00C9;

    //    public const int EM_POSFROMCHAR = 0x00D6;



    //    [DllImport("USER32.DLL", EntryPoint = "PostMessage")]
    //    public static extern bool PostMessage(IntPtr hwnd, uint msg,
    //        IntPtr wParam, IntPtr lParam);

    //    /*
    //        BOOL PostMessage(          HWND hWnd,
    //            UINT Msg,
    //            WPARAM wParam,
    //            LPARAM lParam
    //            );
    //    */

    //    // Put this declaration in your class   //IntPtr
    //    [DllImport("USER32.DLL", EntryPoint = "SendMessage")]
    //    public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam,
    //        IntPtr lParam);




    //    [DllImport("USER32.DLL", EntryPoint = "GetCaretBlinkTime")]
    //    public static extern uint GetCaretBlinkTime();




    //    const int WM_PRINTCLIENT = 0x0318;

    //    const long PRF_CHECKVISIBLE = 0x00000001L;
    //    const long PRF_NONCLIENT = 0x00000002L;
    //    const long PRF_CLIENT = 0x00000004L;
    //    const long PRF_ERASEBKGND = 0x00000008L;
    //    const long PRF_CHILDREN = 0x00000010L;
    //    const long PRF_OWNED = 0x00000020L;

    //    /*  Will clean this up later doing something like this
    //    enum  CaptureOptions : long
    //    {
    //        PRF_CHECKVISIBLE= 0x00000001L,
    //        PRF_NONCLIENT	= 0x00000002L,
    //        PRF_CLIENT		= 0x00000004L,
    //        PRF_ERASEBKGND	= 0x00000008L,
    //        PRF_CHILDREN	= 0x00000010L,
    //        PRF_OWNED		= 0x00000020L
    //    }
    //    */


    //    public static bool CaptureWindow(System.Windows.Forms.Control control,
    //                            ref System.Drawing.Bitmap bitmap)
    //    {
    //        //This function captures the contents of a window or control

    //        Graphics g2 = Graphics.FromImage(bitmap);

    //        //PRF_CHILDREN // PRF_NONCLIENT
    //        int meint = (int)(PRF_CLIENT | PRF_ERASEBKGND); //| PRF_OWNED ); //  );
    //        System.IntPtr meptr = new System.IntPtr(meint);

    //        System.IntPtr hdc = g2.GetHdc();
    //        win32.SendMessage(control.Handle, win32.WM_PRINT, hdc, meptr);

    //        g2.ReleaseHdc(hdc);
    //        g2.Dispose();

    //        return true;

    //    }



    //}















}
