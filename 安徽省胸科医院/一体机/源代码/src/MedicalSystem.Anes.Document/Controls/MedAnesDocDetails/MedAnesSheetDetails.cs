/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedAnesSheetDetails.cs
      // �ļ�����������������ϸ���ؼ�
      //
      // 
      // ������ʶ��������-2008-10-23
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Controls
{

    /// <summary>
    /// ������ϸ���ؼ�
    /// </summary>
    [ToolboxItem(false), Description("�¼���ϸ")]
    public partial class MedAnesSheetDetails : AnesBand, IPrintable
    {

        #region ���췽��

        public MedAnesSheetDetails()
        {
            InitializeComponent();
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// �߿���ɫ
        /// </summary>
        //private Color _borderColor = Color.Red;

        /// <summary>
        /// �߿���
        /// </summary>
        //private int _borderWidth = 1;

        /// <summary>
        /// Ҫ�����ַ����б�
        /// </summary>
        private List<string> DrawStringList = new List<string>();

        private static Brush brush = new SolidBrush(Color.Black);
        /// <summary>
        /// ����
        /// </summary>
        private int _columnCount = 3;

        /// <summary>
        /// ��ϸ��
        /// </summary>
        private List<MedAnesSheetDetailCollection> _collections = new List<MedAnesSheetDetailCollection>();

        /// <summary>
        /// ��������
        /// </summary>
        private int _totalRowCount = 6;

        /// <summary>
        /// ����ֵ��ɫ
        /// </summary>
        private Color _totalValueColor = Color.Blue;

        /// <summary>
        /// ������ͨ��ɫ
        /// </summary>
        private Color _totalNormalColor = Color.Black;

        /// <summary>
        /// �Ƿ������
        /// </summary>
        private bool _hasOrderNo = true;

        /// <summary>
        /// �Ƿ���ʱ��
        /// </summary>
        private bool _hasTime = true;

        /// <summary>
        /// ��Һ��ɫ
        /// </summary>
        private Color _inLiquidColor = Color.Black;

        /// <summary>
        /// ��ҩ��ɫ
        /// </summary>
        private Color _drugColor = Color.Blue;

        /// <summary>
        /// �¼���ɫ
        /// </summary>
        private Color _eventColor = Color.PaleVioletRed;

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        private DateTime _startTime = DateTime.Parse("08:00");

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _endTime = DateTime.Parse("12:00");

        /// <summary>
        /// �ϴ����λ��
        /// </summary>
        private Point _oldMousePos = new Point(-1000, -1000);

        #endregion ����

        #region ����

        private bool _displayRoute = true;
        [DisplayName("Ĭ����ʾ;��")]
        public bool DisplayRoute
        {
            get
            {
                return _displayRoute;
            }
            set
            {
                _displayRoute = value;
            }
        }
        public int DrawListCount
        {
            get
            {
                
                return DrawStringList.Count;
            }
        }
        /// <summary>
        /// ��ͨҩ����ʾ���
        /// </summary>
        private NormalDrugUnitShowType _drugShowType = NormalDrugUnitShowType.Default;
        [Browsable(false)]
        public NormalDrugUnitShowType DrugShowType
        {
            get
            {
                return _drugShowType;
            }
            set
            {
                _drugShowType = value;
            }
        }

        /// <summary>
        /// ����ҩ��ʾ���
        /// </summary>
        private ProLongedDrugUnitShowType _proLongedDrugShowType = ProLongedDrugUnitShowType.Default;
        [Browsable(false)]
        public ProLongedDrugUnitShowType ProLongedDrugShowType
        {
            get
            {
                return _proLongedDrugShowType;
            }
            set
            {
                _proLongedDrugShowType = value;
            }
        }

        /// <summary>
        /// ��ǰʱ��
        /// </summary>
        private DateTime _currentTime;
        public DateTime CurrentTime
        {
            get
            {
                return _currentTime;
            }
        }

        private float _leftWidthPercent = 0;
        /// <summary>
        /// ��߰ٷֱ�
        /// </summary>
        [DisplayName("��߰ٷֱ�")]
        public float LeftWidthPercent
        {
            get
            {
                return _leftWidthPercent;
            }
            set
            {
                if (value > .05f && value <= 1)
                {
                    _leftWidthPercent = value;
                }
                else
                {
                    Exception ex = new Exception("��Ч�İٷֱȣ��������5%��100%֮��!");
                    throw ex;
                }
            }
        }

        /// <summary>
        /// ˮƽλ��
        /// </summary>
        private float _XOffSet = 0;
        [DisplayName("ˮƽλ��")]
        public float XOffSet
        {
            get
            {
                return _XOffSet;
            }
            set
            {
                _XOffSet = value;
            }
        }

        private float _rightWidthPercent = 0;
        /// <summary>
        /// �ұ߰ٷֱ�
        /// </summary>
        [DisplayName("�ұ߰ٷֱ�")]
        public float RightWidthPercent
        {
            get
            {
                return _rightWidthPercent;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    _rightWidthPercent = value;
                }
                else
                {
                    Exception ex = new Exception("��Ч�İٷֱȣ��������0%��100%֮��!");
                    throw ex;
                }
            }
        }

        private bool _group = true;
        [Description("����"), DisplayName("����")]
        public bool Group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
            }
        }
        private int _rowLine;
        public int RowLine
        {
            get
            {
                return _rowLine;
            }
            set
            {
                _rowLine = value;
            }
        }
        private bool _isTimeOrder = false;
        [Description("���鰴ʱ������"), DisplayName("���鰴ʱ������")]
        public bool IsTimeOrder
        {
            get
            {
                return _isTimeOrder;
            }
            set
            {
                _isTimeOrder = value;
            }
        }

        private bool _hasGroupTitle = true;
        [Description("�Ƿ�Ҫ�����"), DisplayName("�Ƿ�Ҫ�����")]
        public bool HasGrounTitle
        {
            get
            {
                return _hasGroupTitle;
            }
            set
            {
                _hasGroupTitle = value;
            }
        }

        private bool _hasGroupEmptyLine = true;
        [Description("�Ƿ�Ҫ������"), DisplayName("�Ƿ�Ҫ������")]
        public bool HasGrounEmptyLine
        {
            get
            {
                return _hasGroupEmptyLine;
            }
            set
            {
                _hasGroupEmptyLine = value;
            }
        }

        private bool _hasGroupLine = true;
        [Description("�Ƿ�Ҫ�������"), DisplayName("�Ƿ�Ҫ�������")]
        public bool HasGrounLine
        {
            get
            {
                return _hasGroupLine;
            }
            set
            {
                _hasGroupLine = value;
            }
        }

        private bool _hasLiquid = true;
        [Description("�Ƿ�Ҫ��Ѫ��Һ"), DisplayName("�Ƿ�Ҫ��Ѫ��Һ")]
        public bool HasLiquid
        {
            get
            {
                return _hasLiquid;
            }
            set
            {
                _hasLiquid = value;
            }
        }

        ///// <summary>
        ///// �߿���ɫ
        ///// </summary>
        //public Color BorderColor
        //{
        //    get
        //    {
        //        return _borderColor;
        //    }
        //    set
        //    {
        //        _borderColor = value;
        //    }
        //}

        ///// <summary>
        ///// �߿���
        ///// </summary>
        //public int BorderWidth
        //{
        //    get
        //    {
        //        return _borderWidth;
        //    }
        //    set
        //    {
        //        _borderWidth = value;
        //    }
        //}

        /// <summary>
        /// ����
        /// </summary>
        [DisplayName("����")]
        public int ColumnCount
        {
            get
            {
                return _columnCount;
            }
            set
            {
                _columnCount = value;
            }
        }

        /// <summary>
        /// ��ϸ��
        /// </summary>
        public List<MedAnesSheetDetailCollection> Collections
        {
            get
            {
                return _collections;
            }
            set
            {
                _collections = value;
            }
        }

        /// <summary>
        /// �п�
        /// </summary>
        public float ColumnWidth
        {
            get
            {
                return (OriginRect.Width - _titleWidth) / _columnCount;
            }
        }

        /// <summary>
        /// �и�
        /// </summary>
        public float RowHeight
        {
            get
            {
                return (Height - _innerTopOffSet - _topOffSet) / _rowCount;//CreateGraphics().MeasureString("A", _detailFont).Height + 1;
            }
        }

        private int _rowCount = 7;
        /// <summary>
        /// ����
        /// </summary>
        [Category("����(�Զ���)"), DisplayName("����")]
        public int RowCount
        {
            get
            {
                return _rowCount;//(int)(OriginRect.Height / RowHeight);
            }
            set
            {
                _rowCount = value;
            }
        }

        private Font _detailFont = new Font("����", 9);
        /// <summary>
        /// ��ϸ����
        /// </summary>
        [Category("����(�Զ���)"), DisplayName("��ϸ����")]
        public Font DetailFont
        {
            get
            {
                return _detailFont;
            }
            set
            {
                _detailFont = value;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        [DisplayName("��������")]
        public int TotalRowCount
        {
            get
            {
                return _totalRowCount;
            }
            set
            {
                _totalRowCount = value;
            }
        }

        /// <summary>
        /// ����ֵ��ɫ
        /// </summary>
        [DisplayName("����ֵ��ɫ")]
        public Color TotalValueColor
        {
            get
            {
                return _totalValueColor;
            }
            set
            {
                _totalValueColor = value;
            }
        }

        /// <summary>
        /// ������ͨ��ɫ
        /// </summary>
        [DisplayName("������ͨ��ɫ")]
        public Color TotalNormalColor
        {
            get
            {
                return _totalNormalColor;
            }
            set
            {
                _totalNormalColor = value;
            }
        }

        /// <summary>
        /// �Ƿ���Ҫ���
        /// </summary>
        [DisplayName("�Ƿ���Ҫ���")]
        public bool HasOrderNo
        {
            get
            {
                return _hasOrderNo;
            }
            set
            {
                _hasOrderNo = value;
            }
        }

        /// <summary>
        /// �Ƿ���Ҫʱ��
        /// </summary>
        [DisplayName("�Ƿ���Ҫʱ��")]
        public bool HasTime
        {
            get
            {
                return _hasTime;
            }
            set
            {
                _hasTime = value;
            }
        }

        private bool _hasEvent = true;
        [Description("�Ƿ���ʾ�¼�"), DisplayName("�Ƿ���ʾ�¼�")]
        public bool HasEvent
        {
            get
            {
                return _hasEvent;
            }
            set
            {
                _hasEvent = value;
            }
        }

        [Description("�¼���ɫ"), DisplayName("�¼���ɫ")]
        public Color EventColor
        {
            get
            {
                return _eventColor;
            }
            set
            {
                _eventColor = value;
            }
        }

        private bool _hasAnesDrug = true;
        [Description("�Ƿ���ʾ��ҩ"), DisplayName("�Ƿ���ʾ��ҩ")]
        public bool HasAnesDrug
        {
            get
            {
                return _hasAnesDrug;
            }
            set
            {
                _hasAnesDrug = value;
            }
        }

        private Color _anesDrugColor = Color.DarkGreen;
        [Description("��ҩ��ɫ"), DisplayName("��ҩ��ɫ")]
        public Color AnesDrugColor
        {
            get
            {
                return _anesDrugColor;
            }
            set
            {
                _anesDrugColor = value;
            }
        }

        private AnesDrugShowType _anesDrugShowType = AnesDrugShowType.SinglePoint;
        [Description("��ҩ��ʾ����"), DisplayName("��ҩ��ʾ����")]
        public AnesDrugShowType AnesDrugShowType
        {
            get
            {
                return _anesDrugShowType;
            }
            set
            {
                _anesDrugShowType = value;
            }
        }

        [Description("��ҩ��ɫ"), DisplayName("��ҩ��ɫ")]
        public Color DrugColor
        {
            get
            {
                return _drugColor;
            }
            set
            {
                _drugColor = value;
            }
        }

        [Description("��Ѫ��Һ��ɫ"), DisplayName("��Ѫ��Һ��ɫ")]
        public Color InLiquidColor
        {
            get
            {
                return _inLiquidColor;
            }
            set
            {
                _inLiquidColor = value;
            }
        }

        private bool _hasZhiGuan = true;
        [Description("�Ƿ���ʾ���"), DisplayName("�Ƿ���ʾ���")]
        public bool HasZhiGuan
        {
            get
            {
                return _hasZhiGuan;
            }
            set
            {
                _hasZhiGuan = value;
            }
        }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        private bool _hasFuji = false;
        [Description("�Ƿ���ʾ����"), DisplayName("�Ƿ���ʾ����")]
        public bool HasFuji
        {
            get
            {
                return _hasFuji;
            }
            set
            {
                _hasFuji = value;
            }
        }

        private string _signNameTitle = "";
        [Description("ǩ������"), DisplayName("ǩ������")]
        public string SignNameTitle
        {
            get
            {
                return _signNameTitle;
            }
            set
            {
                _signNameTitle = value;
            }
        }

        private bool _noPrint = false;
        [Description("����ӡ")]
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

        /// <summary>
        /// ��ʼ����
        /// </summary>
        private int _startIndex = 0;
        [Browsable(false)]
        public int StartIndex
        {
            get
            {
                return _startIndex;
            }
            set
            {
                _startIndex = value;
            }
        }

        private int _totalCount = -1;
        [Category("����(�Զ���)"), DisplayName("��¼��")]
        public int TotalCount
        {
            get
            {
                return _totalCount;
            }
            set
            {
                _totalCount = value;
            }
        }

        private string _title = "";
        [Category("����(�Զ���)"), DisplayName("����")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        private float _titleWidth = 20;
        [Category("����(�Զ���)"), DisplayName("������")]
        public float TitleWidth
        {
            get
            {
                return _titleWidth;
            }
            set
            {
                _titleWidth = value;
            }
        }

        private bool _displayTimeOrder = false;
        [Category("����(�Զ���)"), DisplayName("ʱ�����")]
        public bool DisplayTimeOrder
        {
            get
            {
                return _displayTimeOrder;
            }
            set
            {
                _displayTimeOrder = value;
            }
        }

        private string _timeOrderTitle;
        [Category("����(�Զ���)"), DisplayName("ʱ����ű���")]
        public string TimeOrderTitle
        {
            get
            {
                return _timeOrderTitle;
            }
            set
            {
                _timeOrderTitle = value;
            }
        }

        private float _innerTopOffSet = 0;
        [Category("����(�Զ���)"), DisplayName("ʱ����Ÿ߶�")]
        public float InnerTopOffSet
        {
            get
            {
                return _innerTopOffSet;
            }
            set
            {
                _innerTopOffSet = value;
            }
        }

        /// <summary>
        /// �ܽ����м���
        /// </summary>
        [Browsable(false)]
        private List<LastColumnLineItem> _lastLines = new List<LastColumnLineItem>();
        public List<LastColumnLineItem> LastLines
        {
            get
            {
                return _lastLines;
            }
            set
            {
                _lastLines = value;
            }
        }

        /// <summary>
        /// �̶�����
        /// </summary>
        protected ScaleType _scaleType = ScaleType.HalfHour;

        /// <summary>
        /// ʱ�����
        /// </summary>
        private string _timeText = "ʱ��";
        /// <summary>
        /// ʱ�����
        /// </summary>
        [Category("����-�Զ���"), DisplayName("ʱ�����")]
        public string TimeText
        {
            get
            {
                return _timeText;
            }
            set
            {
                _timeText = value;
            }
        }

        /// <summary>
        /// ����ƫ����
        /// </summary>
        protected float _topOffSet = 0;
        [Category("����(�Զ���)"), DisplayName("ʱ������߶�")]
        public float TopOffSet
        {
            get
            {
                return _topOffSet;
            }
            set
            {
                _topOffSet = value;
            }
        }

        /// <summary>
        /// ʱ��������λ������
        /// </summary>
        protected TimeAxisPositionType _timeAxisPositionType = TimeAxisPositionType.None;
        /// <summary>
        /// ʱ��������λ������
        /// </summary>
        [Category("����-�Զ���"), DisplayName("ʱ��������λ������")]
        public TimeAxisPositionType TimeAxisPositionType
        {
            get
            {
                return _timeAxisPositionType;
            }
            set
            {
                _timeAxisPositionType = value;
            }
        }

        /// <summary>
        /// ����Ӧʱ��
        /// </summary>
        private DateTime _mouseTime = DateTime.MinValue;
        [Browsable(false)]
        public DateTime MouseTime
        {
            get
            {
                return _mouseTime;
            }
        }

        /// <summary>
        /// ѡ�еĵ�
        /// </summary>
        private MedAnesSheetDetailPoint _selectPoint = null;
        public MedAnesSheetDetailPoint SelectedPoint
        {
            get
            {
                return _selectPoint;
            }
        }

        #endregion ����

        #region �¼��ӿ�
        /// <summary>
        /// �ͻ������¼��ӿ�
        /// </summary>
        private static readonly object _customDraw = new object();
        public event PaintEventHandler CustomDraw
        {
            add
            {
                Events.AddHandler(_customDraw, value);
            }
            remove
            {
                Events.RemoveHandler(_customDraw, value);
            }
        }

        #endregion �¼��ӿ�

        #region ����

        /// <summary>
        /// IPrint�ӿ�-��ӡ
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Draw(Graphics g, float x, float y)
        {
            _printing = true;
            g.TranslateTransform(x, y);
            int backHeight = Height;
            if (_backHeight > 0)
            {
                Height = _backHeight;
            }
            DrawGraphics(g);
            Height = backHeight;
            g.ResetTransform();
            _printing = false;
        }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <returns></returns>
        protected virtual float GetGridScale()
        {
            float scale = 1;
            switch (_scaleType)
            {
                case ScaleType.Hour:
                    scale = 1;
                    break;
                case ScaleType.Quarter:
                    scale = .25f;
                    break;
                case ScaleType.HalfHour:
                    scale = .5f;
                    break;
                case ScaleType.TriQuarter:
                    scale = .75f;
                    break;
                case ScaleType.TwiHour:
                    scale = 2;
                    break;
                case ScaleType.OneMin:
                    scale = (float)(1 / 60.0);
                    break;
                case ScaleType.FiveMin:
                    scale = (float)(5 / 60.0);
                    break;
                case ScaleType.TwoMin:
                    scale = (float)(2 / 60.0);
                    break;
                case ScaleType.TenMin:
                    scale = (float)(10 / 60.0);
                    break;
            }
            return scale;
        }

        /// <summary>
        /// ��ȡ����̶ȿ��
        /// </summary>
        /// <returns></returns>
        protected virtual float GetGridWidth()
        {
            TimeSpan ts = _endTime - _startTime;
            RectangleF rectF = GetMainRect();
            return (float)(rectF.Width / ts.TotalHours) * GetGridScale();
        }

        /// <summary>
        /// ��ȡ����̶�ʱ��--������
        /// </summary>
        /// <returns></returns>
        protected virtual int GetGridMinutes()
        {
            return (int)(60 * GetGridScale());
        }

        /// <summary>
        /// ���̶�ֵ
        /// </summary>
        /// <param name="g"></param>
        protected virtual void DrawScaleValue(Graphics g)
        {
            int vSpan = 1;
            Font font = _detailFont;
            RectangleF rectF = GetMainRect();
            Rectangle rect = OriginRect;
            float gridWidth = GetGridWidth();
            int minutes = GetGridMinutes();
            DateTime dt = _startTime.AddMinutes(minutes);
            float x = rectF.X + gridWidth;
            g.FillRectangle(Brushes.White, rect.X + 2, rect.Y, rect.Right - rect.X - 5, _topOffSet);
            using (Brush brush = new SolidBrush(_scaleValueColor))
            {
                if (_timeText != null)
                {
                    g.DrawString(_timeText, font, brush, rect.X + (rectF.X - rect.X - g.MeasureString(_timeText, font).Width) / 2, rectF.Y + vSpan);
                }
                //if (_rightWidthPercent > 0 && _totalText != null)
                //{
                //    g.DrawString(_totalText, font, brush, rectF.Right + (rect.Right - rectF.Right - g.MeasureString(_totalText, font).Width) / 2, rectF.Y + vSpan);
                //}
                string firstScaleValue = dt.AddMinutes(-minutes).ToString("HH:mm");
                g.DrawString(firstScaleValue, font, brush, rectF.X - g.MeasureString(firstScaleValue, font).Width / 2, rectF.Y + vSpan);
                while (x - 5 < rectF.Right)
                {
                    string scaleValue = dt.ToString("HH:mm");
                    g.DrawString(scaleValue, font, brush, x - g.MeasureString(scaleValue, font).Width / 2, rectF.Y + vSpan);
                    dt = dt.AddMinutes(minutes);
                    x += gridWidth;
                }
            }
            //_topOffSet = g.MeasureString("A", font).Height + vSpan * 2;
            g.DrawLine(new Pen(_borderColor, _borderWidth), rect.X + 1, rectF.Y + _topOffSet, rect.Right, rectF.Y + _topOffSet);
        }

        /// <summary>
        /// ��ȡʱ����Ӧˮƽ����
        /// </summary>
        /// <param name="timePoint"></param>
        /// <param name="rectF"></param>
        /// <returns></returns>
        private float GetX(DateTime timePoint, RectangleF rectF)
        {
            TimeSpan spThis, spTotal;
            spThis = timePoint - _startTime;
            spTotal = _endTime - _startTime;
            return (float)(rectF.X + rectF.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
        }

        /// <summary>
        /// ���ƿؼ�
        /// </summary>
        /// <param name="graphics"></param>
        public override void DrawGraphics(Graphics graphics)
        {
            _zoomRate = (float)(1 / _showZoomRate);

            Graphics g = graphics;

            //Metafile metafile = GetMetafile(@"c:\test.wmf", Width, Height);
            //g = Graphics.FromImage(metafile);

            base.DrawGraphics(g);
            if (_displayTimeOrder)
            {
                Rectangle rect = OriginRect;
                RectangleF rectF = GetMainRect();
                g.DrawLine(Pens.Black, rect.X, rect.Y + _innerTopOffSet + _topOffSet, rect.Right, rect.Y + _innerTopOffSet + _topOffSet);
                g.DrawLine(Pens.Black, rectF.X, rect.Y, rectF.X, rect.Y + _innerTopOffSet + _topOffSet);
                if (!string.IsNullOrEmpty(_timeOrderTitle))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(_timeOrderTitle, _detailFont, Brushes.Black, new RectangleF(rect.X, rect.Y + _topOffSet, rectF.X - rect.X, _innerTopOffSet), sf);
                }
                List<int> indexes = new List<int>();
                foreach (MedAnesSheetDetailCollection collection in Collections)
                {
                    if (collection == null)
                    {
                        continue;
                    }
                    foreach (MedAnesSheetDetailPoint point in collection.Points)
                    {
                        if (!indexes.Contains(point.Index))
                        {
                            indexes.Add(point.Index);
                            float x = GetX(point.StartTime, rectF);
                            if (point.StartTime >= _startTime && point.StartTime <= _endTime)
                            {
                                g.DrawString(point.Index.ToString(), _detailFont, Brushes.Black, x, rect.Y + _topOffSet);
                            }
                        }
                    }
                }
            }
            if (_hasGroupLine)
            {
                Rectangle rect = OriginRect;
                rect.Width += -1;
                rect.Height += -1;
                //g.DrawRectangle(new Pen(_borderColor, _borderWidth), rect);
                float columnWidth = ColumnWidth;
                float x1 = 0;
                if (!string.IsNullOrEmpty(_title))
                {
                    x1 += _titleWidth;
                }
                for (int i = 1; i < _columnCount; i++)
                {
                    g.DrawLine(new Pen(_borderColor, _borderWidth), rect.X + x1 + i * columnWidth, rect.Y + _innerTopOffSet + _topOffSet, rect.X + x1 + i * columnWidth, rect.Bottom);
                }
            }
            if (_collections != null && _collections.Count > 0)
            {
                if (_group)
                {
                    DrawCollections(g);
                }
                else
                {
                    DrawCollectionsTogether(g);
                }
            }
            if (!string.IsNullOrEmpty(_signNameTitle))
            {
                g.DrawString(_signNameTitle, _detailFont, new SolidBrush(_borderColor), ColumnWidth * ColumnCount - g.MeasureString(_signNameTitle, _detailFont).Width - 80, OriginRect.Height - 20);
            }

            PaintEventHandler eventHandle = Events[_customDraw] as PaintEventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, new PaintEventArgs(g, ClientRectangle));
            }

            if (_timeAxisPositionType == TimeAxisPositionType.Top)
            {
                DrawScaleValue(g);
            }

        }

        /// <summary>
        /// ��ȡ����ʾ����
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private string GetPointText(MedAnesSheetDetailPoint point)
        {
            string drawText = point.Text;

            if (point.Value > 0)
            {
                drawText += " " + point.Value.ToString() + "" + point.Unit;
            }
            if (point.Attrubite != null && !string.IsNullOrEmpty(point.Attrubite.Trim()))
            {
                drawText += " " + point.Attrubite;
            }
            if (_displayRoute)
            {
                drawText += " " + point.Route;
            }
            if (point.PointType == PointType.SinglePoint && (point.Value > 0 || point.Speed > 0 || point.ThickNess > 0))
            {
                switch (_drugShowType)
                {
                    case NormalDrugUnitShowType.Dosage:
                        drawText = point.Text + " " + point.Value.ToString();
                        break;
                    case NormalDrugUnitShowType.DosageThick:
                        drawText = point.Text + " " + point.Value.ToString() + "(" + point.ThickNess.ToString() + ")";
                        break;
                    case NormalDrugUnitShowType.DosageThickRoute:
                        drawText = point.Text + " " + point.Value.ToString() + "(" + point.ThickNess.ToString() + "+" + point.Route + ")";
                        break;
                    case NormalDrugUnitShowType.DosageUnit:
                        drawText = point.Text + " " + point.Value.ToString() + "(" + point.Unit + ")";
                        break;
                    case NormalDrugUnitShowType.Thick:
                        drawText = point.Text + " " + point.ThickNess.ToString();
                        break;
                    default:
                        break;
                }
            }
            else if (point.PointType == PointType.ProLonged && (point.Value > 0 || point.Speed > 0 || point.ThickNess > 0))
            {
                switch (_proLongedDrugShowType)
                {
                    case ProLongedDrugUnitShowType.Thick:
                        drawText = point.Text + " " + point.ThickNess.ToString();
                        break;
                    case ProLongedDrugUnitShowType.Speed:
                        drawText = point.Text + " " + point.Speed.ToString();
                        break;
                    case ProLongedDrugUnitShowType.Dosage:
                        drawText = point.Text + " " + point.Value.ToString();
                        break;
                    case ProLongedDrugUnitShowType.DosageSpeed:
                        drawText = point.Text + " " + point.Value.ToString() + "(" + point.Speed.ToString() + ")";
                        break;
                    case ProLongedDrugUnitShowType.DosageThick:
                        drawText = point.Text + " " + point.Value.ToString() + "(" + point.ThickNess.ToString() + ")";
                        break;
                    case ProLongedDrugUnitShowType.SpeedThick:
                        drawText = point.Text + " " + point.Speed.ToString() + "(" + point.ThickNess.ToString() + ")";
                        break;
                    case ProLongedDrugUnitShowType.SpeedThickRoute:
                        drawText = point.Text + " " + point.Speed.ToString() + "(" + point.ThickNess.ToString() + "+" + point.Route + ")";
                        break;
                    default:
                        break;
                }
            }
            if (_hasTime)
            {
                if (point.PointType == PointType.ProLonged)
                {
                    drawText = point.StartTime.ToString("HH:mm") + point.EndTime.ToString("-->HH:mm ") + drawText;
                }
                else
                {
                    drawText = point.StartTime.ToString("HH:mm ") + drawText;
                }
            }
            return drawText;
        }

        /// <summary>
        /// ���Ʊ���
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rect"></param>
        private void DrawTitle(Graphics g, float x, float y, Rectangle rect)
        {
            if (!string.IsNullOrEmpty(_title))
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                g.DrawString(_title.Replace(" ", "\r\n"), _detailFont, Brushes.Black, new RectangleF(x, y, _titleWidth, rect.Height - _innerTopOffSet - _topOffSet), sf);
                x += _titleWidth;
                g.DrawLine(Pens.Black, x - 2, y, x - 2, rect.Bottom);
            }
        }

        //private List<string> GetPointStrings(Graphics g, MedAnesSheetDetailPoint point, float x, float y, float width)
        //{
        //    width = width - 5;
        //    string pointText = GetPointText(point);
        //    SizeF sizeF = g.MeasureString(pointText, _detailFont);
        //    point.RectF = new RectangleF(x, y, sizeF.Width, sizeF.Height);
        //    List<string> list = new List<string>();
        //    int copyLength = 1;
        //    while (g.MeasureString(pointText.Substring(0, copyLength), _detailFont).Width < width && copyLength < pointText.Length)
        //    {
        //        copyLength++;
        //    }
        //    list.Add(pointText.Substring(0, copyLength));
        //    pointText = pointText.Substring(copyLength);
        //    while (pointText.Length > 0)
        //    {
        //        copyLength = 1;
        //        while (g.MeasureString(pointText.Substring(0, copyLength), _detailFont).Width < width && copyLength < pointText.Length)
        //        {
        //            copyLength++;
        //        }
        //        list.Add(pointText.Substring(0, copyLength));
        //        pointText = pointText.Substring(copyLength);
        //    }
        //    return list;
        //}


        public List<string> GetPointStrings(Graphics g, MedAnesSheetDetailPoint point, float x, float y, float width)
        {
            string pointText = GetPointText(point);
            SizeF sizeF = g.MeasureString(pointText, _detailFont);
            point.RectF = new RectangleF(x, y, sizeF.Width, sizeF.Height);
            List<string> list = new List<string>();
            int copyLength = 1;
            while (g.MeasureString(pointText.Substring(0, copyLength), _detailFont).Width < width && copyLength < pointText.Length)
            {
                copyLength++;
            }
            //Add By xiasen.x@2014-05-31,��һ���Ϳ��ܳ��������ˣ��������ж�
            if (g.MeasureString(pointText.Substring(0, copyLength), _detailFont).Width > width)
            {
                copyLength--;
            }
            if (pointText.Substring(0, copyLength).Trim() != "")
                list.Add(pointText.Substring(0, copyLength));
            pointText = pointText.Substring(copyLength);
            while (pointText.Length > 0)
            {
                copyLength = 1;
                while (g.MeasureString(pointText.Substring(0, copyLength), _detailFont).Width < width && copyLength < pointText.Length)
                {
                    copyLength++;
                }
                if (g.MeasureString(pointText.Substring(0, copyLength), _detailFont).Width > width)
                {
                    copyLength--;
                }
                if (pointText.Substring(0, copyLength).Trim() != "")
                    list.Add(pointText.Substring(0, copyLength));
                //End Add
                pointText = pointText.Substring(copyLength);
            }
            return list;
        }

        /// <summary>
        /// ������ϸ�������飩
        /// </summary>=
        /// <param name="g"></param>
        private void DrawCollectionsTogether(Graphics g)
        {
            MedAnesSheetDetailCollection collection = _collections[0];
            collection.Color = Color.Black;
            Rectangle rect = OriginRect;
            float rowHeight = RowHeight, columnWidth = ColumnWidth;
            float x = rect.X, y = rect.Y + _innerTopOffSet + _topOffSet;

            DrawTitle(g, x, y, rect);
            x += _titleWidth;
            float x1 = x;
            float y1 = y;
            int rowCount = RowCount, rowIndex = 0, columnIndex = 0, columnCount = ColumnCount;
            ///���Ƶ�
            if (collection.Points != null && collection.Points.Count > 0)
            {
                using (Brush brush = new SolidBrush(collection.Color))
                {
                    int startIndex = 0;
                    float leftOffset = 0;//_titleWidth;// 0;
                    if (_hasOrderNo)
                    {
                        leftOffset = g.MeasureString("99", _detailFont).Width;
                    }

                    for (int i = 0; i < collection.Points.Count; i++)
                    {
                        MedAnesSheetDetailPoint point = collection.Points[i];
                        if (collection.CollectionType != CollectionType.Total && (point.StartTime > _endTime || point.StartTime < _startTime)) continue;
                        List<string> list = GetPointStrings(g, point, x + leftOffset, y, columnWidth - leftOffset);

                        StringFormat sf = new StringFormat();

                        int yof = -1;
                        if (_hasOrderNo)
                        {
                            yof = 1;
                        }

                        for (int ii = 0; ii < list.Count; ii++)
                        {
                            startIndex++;
                            if (startIndex > _startIndex && startIndex <= _totalCount + _startIndex)
                            {
                                if (_hasOrderNo && ii == 0)
                                {
                                    g.DrawString(string.Format("{0}", point.Index), _detailFont, brush, x, y);
                                }
                                if (startIndex == _startIndex + 1)
                                {
                                    g.DrawString(list[ii], _detailFont, brush, x + leftOffset, y1 + yof);
                                }
                                else
                                {
                                    g.DrawString(list[ii], _detailFont, brush, x + leftOffset, y + yof + ii * rowHeight);
                                }
                                rowIndex++;
                                if (rowIndex >= rowCount)
                                {
                                    if (rowIndex > rowCount)
                                    {
                                        rowIndex = 1;
                                    }
                                    else
                                    {
                                        rowIndex = 0;
                                    }
                                    y = y1 + rowIndex * rowHeight - (ii + 1) * rowHeight;
                                    columnIndex++;
                                    x = x1 + columnWidth * columnIndex;
                                }
                            }
                        }

                        y = y1 + rowIndex * rowHeight;
                    }
                }
            }

            DrawLastLines(g, x1, y1, columnCount, columnWidth);
        }

        /// <summary>
        /// �����ܽ���
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="columnCount"></param>
        /// <param name="columnWidth"></param>
        private void DrawLastLines(Graphics g, float x1, float y1, int columnCount, float columnWidth)
        {
            if (_lastLines != null && _lastLines.Count > 0)
            {
                float x0 = x1 + (columnCount - 1) * columnWidth;
                float y0 = y1;
                foreach (LastColumnLineItem item in _lastLines)
                {
                    g.DrawString(item.Text, item.Font, Brushes.Black, x0, y0);
                    y0 += g.MeasureString(item.Text, item.Font).Height;
                }
            }
        }

        /// <summary>
        /// ���Ƽ��ϣ����飩
        /// </summary>
        /// <param name="g"></param>
        public void DrawCollections(Graphics g)
        {
            DrawStringList = new List<string>();
            Rectangle rect = OriginRect;
            float rowHeight = RowHeight, columnWidth = ColumnWidth;
            float x = rect.X, y = rect.Y;
            int rowCount = RowCount, rowIndex = 0, columnIndex = 0, columnCount = ColumnCount, totalIndex = 0;
            RowLine = 0;
            foreach (MedAnesSheetDetailCollection collection in _collections)
            {

                if (collection == null) continue;
                if (collection.Points.Count == 0) continue;
                ///���Ʊ���
                if (_hasGroupTitle)
                {
                    if (collection != null && collection.Points != null && collection.CollectionType != CollectionType.Total)
                    {
                        DrawStringList.Add(string.Format("<<{0}>>", collection.Text));
                    }
                }
                if (collection.Points != null && collection.Points.Count > 0)
                {
                    for (int i = 0; i < collection.Points.Count; i++)
                    {
                        MedAnesSheetDetailPoint point = collection.Points[i];
                        List<string> list = GetPointStringList(g, collection, point, x, y, columnWidth);
                        foreach (string pointStr in list)
                        {
                            DrawStringList.Add(pointStr);
                        }
                    }
                }
                ///�������
                if (_hasGroupEmptyLine)
                {
                    DrawStringList.Add("");
                }
                ///���ܼ����⴦��
                if (collection.CollectionType == CollectionType.Total)
                {
                    g.DrawLine(new Pen(_borderColor, _borderWidth), rect.X + (columnCount - 1) * columnWidth, rect.Y + (rowCount - _totalRowCount) * rowHeight - 5, rect.Right, rect.Y + (rowCount - _totalRowCount) * rowHeight - 5);
                    if (totalIndex > 0)
                    {
                        g.DrawLine(new Pen(_borderColor, _borderWidth), rect.X + (columnCount - 1) * columnWidth + totalIndex * columnWidth / 2, rect.Y + (rowCount - _totalRowCount) * rowHeight - 5, rect.X + (columnCount - 1) * columnWidth + totalIndex * columnWidth / 2, rect.Bottom);
                    }
                    totalIndex++;
                }
            }
            if (DrawStringList.Count > 0)
            {
                //Brush brush = new SolidBrush(Color.Black);
                int startIndex = 0;

                for (int i = 0; i < DrawStringList.Count; i++)
                {
                    startIndex++;
                    if (startIndex > _startIndex && startIndex <= _totalCount + _startIndex)
                    {
                        if (DrawStringList[i].Contains("<<") && DrawStringList[i].Contains(">>"))
                        {
                            foreach (MedAnesSheetDetailCollection col in _collections)
                            {
                                if (DrawStringList[i].Replace("<<", "").Replace(">>", "").Equals(col.Text))
                                {
                                    brush = new SolidBrush(col.Color);
                                }
                            }
                            RectangleF rectF = new RectangleF(x, y + rowIndex * rowHeight, columnWidth, rowHeight);
                            g.DrawString(DrawStringList[i], _detailFont, brush, rectF);
                            rowIndex++;
                            if (rowIndex >= rowCount)
                            {
                                rowIndex = 0;
                                columnIndex++;
                                x = rect.X + columnWidth * columnIndex;
                            }
                            //y = rect.Y + rowIndex * rowHeight;
                        }
                        //RectangleF rectF = new RectangleF(x, y + (rowHeight - g.MeasureString("A", _detailFont).Height) / 2, columnWidth, rowHeight);
                        //g.DrawString(DrawStringList[i], _detailFont, brush, rectF);
                        else
                        {
                            if (string.IsNullOrEmpty(DrawStringList[i]))
                                rowIndex++;
                            else
                            {
                                g.DrawString(DrawStringList[i], _detailFont, brush, x, y + rowIndex * rowHeight);
                                rowIndex++;
                                
                            }
                            if (rowIndex >= rowCount)
                            {
                                rowIndex = 0;
                                columnIndex++;
                                x = rect.X + columnWidth * columnIndex;
                            }
                            //y = rect.Y + rowIndex * rowHeight;
                        }
                    }
                }
            }

        }

        private List<string> GetPointStringList(Graphics g, MedAnesSheetDetailCollection collection, MedAnesSheetDetailPoint point, float x, float y, float width)
        {
            string pointText = string.Empty;
            switch (collection.CollectionType)
            {
                case CollectionType.Event:
                    pointText = "";
                    if (_hasOrderNo)
                    {
                        if (point.Index > 0)
                        {
                            pointText = string.Format("{0} ", point.Index);
                            //g.DrawString(string.Format("{0}", orderNo++), _detailFont, brush, x, y);
                            //DrawString(g, string.Format("{0}", point.Index), _detailFont, brush, x, y, rowHeight, rowIndex, columnIndex, rect.Y);
                        }
                        //leftOffset = g.MeasureString("99", _detailFont).Width;
                    }
                    if (_hasTime)
                    {
                        pointText += point.StartTime.ToString("HH:mm") + ((point.PointType == PointType.ProLonged) ? point.EndTime.ToString(">HH:mm ")
                        : " ") + point.Text;
                    }
                    else
                    {
                        pointText += point.Text;
                    }
                    string v = " " + point.Value.ToString() + point.Unit + " " + point.Route;
                    if (v.Trim().Equals("0")) v = "";

                    pointText = pointText + v;

                    if (point.PointType == PointType.ProLonged && point.DataRow.PERFORM_SPEED.HasValue && point.DataRow.SPEED_UNIT != "")
                    {
                        pointText += "  " + point.DataRow.PERFORM_SPEED.Value + " " + point.DataRow.SPEED_UNIT;
                    }
                    if (point.PointType == PointType.ProLonged && point.DataRow.CONCENTRATION.HasValue && point.DataRow.CONCENTRATION_UNIT != "")
                    {
                        pointText += "  " + point.DataRow.CONCENTRATION.Value + " " + point.DataRow.CONCENTRATION_UNIT;
                    }

                    break;
                case CollectionType.Drug:
                    pointText = "";
                    if (_hasOrderNo)
                    {
                        if (point.Index > 0)
                        {
                            pointText = string.Format("{0} ", point.Index);
                        }
                    }
                    if (_hasTime)
                    {
                        pointText += point.StartTime.ToString("HH:mm") + ((point.PointType == PointType.ProLonged) ? point.EndTime.ToString(">HH:mm ")
                        : " ") + point.Text + " " + point.Value.ToString() + point.Unit + " " + point.Route;
                        if (point.PointType == PointType.ProLonged && point.DataRow.PERFORM_SPEED.HasValue && point.DataRow.SPEED_UNIT != "")
                        {
                            pointText += "  " + point.DataRow.PERFORM_SPEED.Value + " " + point.DataRow.SPEED_UNIT;
                        }
                        if (point.PointType == PointType.ProLonged && point.DataRow.CONCENTRATION.HasValue && point.DataRow.CONCENTRATION_UNIT != "")
                        {
                            pointText += "  " + point.DataRow.CONCENTRATION.Value + " " + point.DataRow.CONCENTRATION_UNIT;
                        }
                    }
                    else
                    {
                        pointText += point.Text + " " + point.Value.ToString() + point.Unit + " " + point.Route;
                    }
                    break;
            }
            SizeF sizeF = g.MeasureString(pointText, _detailFont);
            point.RectF = new RectangleF(x, y, sizeF.Width, sizeF.Height);
            List<string> list = new List<string>();
            int copyLength = 1;
            while (g.MeasureString(pointText.Substring(0, copyLength), _detailFont).Width < width - 10 && copyLength < pointText.Length)
            {
                copyLength++;
            }
            //while (g.MeasureString(text.Substring(0, index), font).Width < remainLine * columnWidth)
            //{
            //    index++;
            //    if (index == text.Length)
            //        break;
            //}
            list.Add(pointText.Substring(0, copyLength));
            pointText = pointText.Substring(copyLength);
            while (pointText.Length > 0)
            {
                copyLength = 1;
                while (g.MeasureString(pointText.Substring(0, copyLength), _detailFont).Width - 10 < width && copyLength < pointText.Length)
                {
                    copyLength++;
                }
                list.Add("  " + pointText.Substring(0, copyLength));
                pointText = pointText.Substring(copyLength);
            }
            return list;
        }

        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void DrawString(Graphics g, string text, Font font, Brush brush, float x, float y)
        {
            float columnWidth = ColumnWidth;
            string ttt = text.Trim();
            while (ttt.IndexOf("  ") > 0) ttt = ttt.Replace("  ", " ");
            if (g.MeasureString(ttt, font).Width > columnWidth)
                ttt = ttt.Replace(" ", "");
            g.DrawString(ttt, font, brush, x, y);
        }

        /// <summary>
        /// ���Ƽ��ı������ƣ�
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text">�ı������ƣ�</param>
        /// <param name="color">��ɫ</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        private void DrawCollectionText(Graphics g, string text, Color color, float x, float y, float width)
        {
            using (Pen pen = new Pen(color))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(pen, x, y + g.MeasureString("A", _detailFont).Height / 2, x + (width - g.MeasureString(text, _detailFont).Width) / 2, y + g.MeasureString("A", _detailFont).Height / 2);
                g.DrawLine(pen, x + (width + g.MeasureString(text, _detailFont).Width) / 2, y + g.MeasureString("A", _detailFont).Height / 2, x + width, y + g.MeasureString("A", _detailFont).Height / 2);
            }
            g.DrawString(text, _detailFont, new SolidBrush(color), x + (width - g.MeasureString(text, _detailFont).Width) / 2, y);
        }

        /// <summary>
        /// ����
        /// </summary>
        public void Test()
        {
            /*
            Font = new Font("����", 12);
            _collections.Clear();
            MedAnesSheetDetailCollection collection = new MedAnesSheetDetailCollection("�¼�",Color.PaleVioletRed);
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:20"), "����"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:35"), "����ͨ��"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:38"), "����ѭ����ʼ"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:58"), "���ܲ��"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("09:50"), "��̵"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:05"), "����"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:15"), "θ���г�"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:31"), DateTime.Parse("10:46"), "�Ǻ�"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:42"), "�ظ�"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:50"), "˫��ͨ��"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:10"), "ֹͣͨ��"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:20"), "����"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:30"), "�ָ�ͨ��"));
            _collections.Add(collection);
            collection = new MedAnesSheetDetailCollection("��ҩ", Color.Blue, CollectionType.Drug);
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:43"), "6-54", 25, "mg", "IV"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:58"), "��һ��", 1, "mg", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:58"), "����Ʒ", .5, "mg", "IV"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:05"), "��������", .5, "mg", "IV"));
            _collections.Add(collection);
            collection = new MedAnesSheetDetailCollection("��Һ����Ѫ", Color.Black, CollectionType.Drug);
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:23"), "ƽ��Һ", 800, "ml", "VD"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:50"), "Ѫˮ", 500, "ml", "VD"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("09:08"), "6%��˹", 500, "ml", "VD"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:20"), "ƽ��Һ", 500, "ml", "VD"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "50%������", 200, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "20%��¶��", 100, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "9%��ˮ", 100, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "706��Ѫ��", 100, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "ƽ��Һ", 100, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "5%̼������", 100, "ml", ""));
            _collections.Add(collection);
            collection = new MedAnesSheetDetailCollection("������", Color.PaleVioletRed, CollectionType.Total);
            collection.Points.Add(new MedAnesSheetDetailPoint("������", 5500, "ml"));
            collection.Points.Add(new MedAnesSheetDetailPoint("����", 5500, "ml"));
            _collections.Add(collection);
            collection = new MedAnesSheetDetailCollection("�ܳ���", Color.PaleVioletRed, CollectionType.Total);
            collection.Points.Add(new MedAnesSheetDetailPoint("�ܳ���", 220, "ml"));
            collection.Points.Add(new MedAnesSheetDetailPoint("ʧѪ��", 200, "ml"));
            collection.Points.Add(new MedAnesSheetDetailPoint("����", 20, "ml"));
            collection.Points.Add(new MedAnesSheetDetailPoint("����", 300, "ml"));
            _collections.Add(collection);
             * */
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <returns></returns>
        public RectangleF GetMainRect()
        {
            Rectangle rect = OriginRect;
            RectangleF rectF = new RectangleF(rect.X - _XOffSet, rect.Y, rect.Width + _XOffSet, rect.Height);
            rectF.X += rectF.Width * _leftWidthPercent;
            rectF.Width = rectF.Width * (1 - _leftWidthPercent - _rightWidthPercent);
            return rectF;
        }

        /// <summary>
        /// ��ȡ�����Ӧ������
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int MeasurePoints(MedAnesSheetDetailCollection collection, float x, float y)
        {
            if (collection != null && collection.Points != null)
            {
                for (int i = 0; i < collection.Points.Count; i++)
                {
                    MedAnesSheetDetailPoint point = collection.Points[i];
                    RectangleF rectF = new RectangleF(point.RectF.X, point.RectF.Y, ColumnWidth - 20, point.RectF.Height);
                    rectF.Inflate(0, -4);
                    if (point.StartTime >= _startTime && point.StartTime <= _endTime && rectF.Contains(x / _scaleRate, y / _scaleRate) && point.Index > _startIndex)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }


        /// <summary>
        /// �������λ��
        /// </summary>
        /// <param name="mousePoint"></param>
        public void SetMousePosition(Point mousePoint)
        {
            RectangleF rect = GetMainRect();
            rect.X = rect.X * _scaleRate;
            rect.Y = rect.Y * _scaleRate;
            rect.Width = rect.Width * _scaleRate;
            rect.Height = rect.Height * _scaleRate;
            TimeSpan spTotal1 = _endTime - _startTime;
            _mouseTime = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal1.TotalSeconds));
            _selectPoint = null;
            if (_collections != null && _collections.Count > 0)
            {
                for (int i = 0; i < _collections.Count; i++)
                {
                    int index = MeasurePoints(_collections[i], mousePoint.X, mousePoint.Y);
                    if (index > -1)
                    {
                        MedAnesSheetDetailPoint point = _collections[i].Points[index];
                        _selectPoint = point;
                        StringBuilder tipStrings = new StringBuilder();
                        tipStrings.AppendLine(point.Text);
                        tipStrings.AppendLine("===================");
                        tipStrings.AppendLine("��ʼʱ�䣺" + point.StartTime.ToString());
                        if (!point.EndTime.Equals(DateTime.MinValue) && !point.EndTime.Equals(DateTime.MaxValue))
                        {
                            tipStrings.AppendLine("����ʱ�䣺" + point.EndTime.ToString());
                        }
                        if (!string.IsNullOrEmpty(point.Route))
                        {
                            tipStrings.AppendLine(";����" + point.Route);
                        }
                        if (point.Value > 0)
                        {
                            tipStrings.AppendLine("����" + point.Value.ToString());
                        }
                        if (!string.IsNullOrEmpty(point.Unit))
                        {
                            tipStrings.AppendLine("��λ��" + point.Unit);
                        }
                        if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                        {
                            toolTip1.SetToolTip(this, tipStrings.ToString());
                            _oldMousePos.X = mousePoint.X;
                            _oldMousePos.Y = mousePoint.Y;
                        }
                        return;
                    }
                }
            }
            //RectangleF rect = GetMainRect();
            //rect.X = rect.X * _scaleRate;
            //rect.Y = rect.Y * _scaleRate;
            //rect.Width = rect.Width * _scaleRate;
            //rect.Height = rect.Height * _scaleRate;
            //TimeSpan spTotal1 = _endTime - _startTime;
            //DateTime dt1 = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal1.TotalSeconds));
            ////ModMinute(ref dt1, 5);
            //if (dt1 >= _startTime && dt1 <= _endTime)
            //{
            //    toolTip1.SetToolTip(this, dt1.ToString("yyyy-MM-dd HH:mm"));
            //}
            //else
            {
                if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                {
                    if (rect.Contains(mousePoint))
                    {
                        toolTip1.SetToolTip(this, _mouseTime.ToString("yyyy-MM-dd HH:mm"));
                    }
                    else
                    {
                        toolTip1.SetToolTip(this, "");
                    }
                    _oldMousePos.X = mousePoint.X;
                    _oldMousePos.Y = mousePoint.Y;
                }
            }
        }

        /// <summary>
        /// ��ȡ��ʾ
        /// </summary>
        /// <returns></returns>
        public string GetToolTipText()
        {
            string toolTipText = toolTip1.GetToolTip(this);
            if (string.IsNullOrEmpty(toolTipText))
            {
                toolTipText = "";
            }
            return toolTipText;
        }

        /// <summary>
        /// �������˫��
        /// </summary>
        /// <param name="mousePoint"></param>
        public void SetMouseDoubleClick(Point mousePoint)
        {
            AnesBandEventHandle eventHandle = (AnesBandEventHandle)Events[_customEditEventHandle];
            if (eventHandle != null)
            {
                if (_collections != null && _collections.Count > 0)
                {
                    for (int i = 0; i < _collections.Count; i++)
                    {
                        int index = MeasurePoints(_collections[i], mousePoint.X, mousePoint.Y);
                        if (index > -1)
                        {
                            MedAnesSheetDetailPoint point = _collections[i].Points[index];
                            point.Collection = _collections[i];
                            _selectPoint = point;
                            eventHandle(this, point, null);
                            return;
                        }
                    }
                }
                RectangleF rect = GetMainRect();
                rect.X = rect.X * _scaleRate;
                rect.Y = rect.Y * _scaleRate;
                rect.Width = rect.Width * _scaleRate;
                rect.Height = rect.Height * _scaleRate;
                TimeSpan spTotal1 = _endTime - _startTime;
                DateTime dt1 = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal1.TotalSeconds));
                _currentTime = new DateTime(dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, 0);
                eventHandle(this, mousePoint, null);
            }
        }

        #endregion ����

        #region �¼�

        /// <summary>
        /// ����Ƶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedAnesSheetDetails_MouseMove(object sender, MouseEventArgs e)
        {
            SetMousePosition(e.Location);
        }

        /// <summary>
        /// ˫��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedAnesSheetDetails_DoubleClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// ���˫��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedAnesSheetDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetMouseDoubleClick(e.Location);
        }




        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedAnesSheetDetails_Click(object sender, EventArgs e)
        {
        }


        private void MedAnesSheetDetails_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                SetMouseDoubleClick(e.Location);
        }


        #endregion �¼�

    }
}
