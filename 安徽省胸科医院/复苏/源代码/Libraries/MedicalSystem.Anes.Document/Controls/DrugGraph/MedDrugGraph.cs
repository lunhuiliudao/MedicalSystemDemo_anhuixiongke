/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedDrugGraph.cs
      // �ļ�������������ҩͼ��ؼ�
      //
      // 
      // ������ʶ��������-2008-10-20
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using MedicalSystem.Anes.Document.Controls;
using System.Reflection;
using MedicalSystem.Anes.Document.Controls.Base;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// ��ҩͼ��ؼ�
    /// </summary>
    [Serializable, ToolboxItem(false), Description("��ҩͼ��")]
    public partial class MedDrugGraph : AnesGraph, IPrintable
    {
        #region ���췽��

        public MedDrugGraph()
        {
            InitializeComponent();
            if (DesignMode)
            {
                Test();
            }
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// ��ҩ�����б�
        /// </summary>
        private List<MedDrugCurve> _curves = new List<MedDrugCurve>();

        /// <summary>
        /// ��������
        /// </summary>
        private TotalType _totalType = TotalType.SummeryValue;

        /// <summary>
        /// ��������
        /// </summary>
        private Font _totalFont;

        /// <summary>
        /// ������ɫ
        /// </summary>
        private Color _totalColor = Color.Blue;

        /// <summary>
        /// ͼ������
        /// </summary>
        private Font _legengFont = new Font("����", 9);

        /// <summary>
        /// ��������
        /// </summary>
        private Font _curveFont;

        /// <summary>
        /// �и�
        /// </summary>
        private float _lineHeight = 20;

        /// <summary>
        /// ������ɫ
        /// </summary>
        private Color _gridColor = Color.Red;

        /// <summary>
        /// ������
        /// </summary>
        private int _gridLineWidth = 1;

        /// <summary>
        /// �̶���������ʽ
        /// </summary>
        private DashStyle _gridDashStyle = DashStyle.Solid;

        /// <summary>
        /// С�̶ȿ̶���
        /// </summary>
        private int _minScaleCount = 6;

        /// <summary>
        /// С�̶�����ɫ
        /// </summary>
        private Color _middleLineColor = Color.FromArgb(255, 200, 200);

        /// <summary>
        /// С�̶��߿��
        /// </summary>
        private float _minScaleWidth = .5f;

        /// <summary>
        /// С�̶�����ʽ
        /// </summary>
        private DashStyle _minDashStyle = DashStyle.DashDotDot;

        /// <summary>
        /// �Ƿ������ˮƽ��
        /// </summary>
        private bool _hasLeftHorizontalLine = false;

        /// <summary>
        /// �Ƿ����ʱ�ˮƽ��
        /// </summary>
        private bool _hasRightHorizontalLine = false;

        /// <summary>
        /// ���������
        /// </summary>
        private DashStyle _leftHorizontalLineStyle = DashStyle.Solid;

        /// <summary>
        /// �ұ�������
        /// </summary>
        private DashStyle _rightHorizontalLineStyle = DashStyle.Solid;

        /// <summary>
        /// �������λ�ö�Ӧ��
        /// </summary>
        private MedDrugPoint _MedDrugPointAtMousePos = null;

        /// <summary>
        /// ���λ�ö�Ӧ�������ƺ�ʱ��
        /// </summary>
        private string _CurvesAndTimeAtMousePos = null;

        #endregion ����

        #region ����
        /// <summary>
        /// ��ҩ��ʾ�ַ���
        /// </summary>
        private string _drugPointShowFormatType;

        public string DrugPointShowFormatType
        {
            get { return _drugPointShowFormatType; }
            set { _drugPointShowFormatType = value; }
        }
        /// <summary>
        /// ������ҩ��ʾ�ַ���
        /// </summary>
        private string _drugProLongedShowFormatType;

        public string DrugProLongedShowFormatType
        {
            get { return _drugProLongedShowFormatType; }
            set { _drugProLongedShowFormatType = value; }
        }

        /// <summary>
        /// ��ҩ�����ַ���
        /// </summary>
        private string _drugNameShowFormatType;

        public string DrugNameShowFormatType
        {
            get { return _drugNameShowFormatType; }
            set { _drugNameShowFormatType = value; }
        }
        /// <summary>
        /// ��ҩ��ʾ��ʽ
        /// </summary>
        public string PointMarkFormat { get; set; }
        /// <summary>
        /// ������ҩ��ʾ��ʽ
        /// </summary>
        public string ProLongedMarkFormat { get; set; }
        /// <summary>
        /// ��ҩ���Ƹ�ʽ
        /// </summary>
        public string NameMarkFormat { get; set; }
        private bool _autoCalTotal = false;
        [DisplayName("�Զ���������")]
        public bool AutoCalTotal
        {
            get
            {
                return _autoCalTotal;
            }
            set
            {
                _autoCalTotal = value;
            }
        }

        /// <summary>
        /// �Ƿ�ȥ�����Ͻ���
        /// </summary>
        private bool _clearLeftTopLine = false;
        public bool ClearLeftTopLine
        {
            get
            {
                return _clearLeftTopLine;
            }
            set
            {
                _clearLeftTopLine = value;
            }
        }

        /// <summary>
        /// ��Ӧ����֮��������
        /// </summary>
        private MedVitalSignGraph _vitalSign = null;
        public MedVitalSignGraph VitalSign
        {
            set
            {
                _vitalSign = value;
            }
        }

        /// <summary>
        /// �������λ�ö�Ӧ��
        /// </summary>
        public MedDrugPoint MedDrugPointAtMousePos
        {
            get
            {
                return _MedDrugPointAtMousePos;
            }
        }

        /// <summary>
        /// ���λ�ö�Ӧ�������ƺ�ʱ��
        /// </summary>
        public string CurvesAndTimeAtMousePos
        {
            get
            {
                return _CurvesAndTimeAtMousePos;
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        private Dictionary<string, string> _itemDescs;
        public Dictionary<string, string> ItemDescs
        {
            get
            {
                return _itemDescs;
            }
            set
            {
                _itemDescs = value;
            }
        }

        [Category("����-�Զ���"), DisplayName("���ˮƽ��")]
        public bool HasLeftHorizontal
        {
            get
            {
                return _hasLeftHorizontalLine;
            }
            set
            {
                _hasLeftHorizontalLine = value;
            }
        }
        [Category("����-�Զ���"), DisplayName("���ˮƽ����ʽ")]
        public DashStyle LeftHorizontalLineStyle
        {
            get
            {
                return _leftHorizontalLineStyle;
            }
            set
            {
                _leftHorizontalLineStyle = value;
            }
        }

        [Category("����-�Զ���"), DisplayName("�Ҳ�ˮƽ��")]
        public bool HasRightHorizontal
        {
            get
            {
                return _hasRightHorizontalLine;
            }
            set
            {
                _hasRightHorizontalLine = value;
            }
        }
        [Category("����-�Զ���"), DisplayName("�Ҳ�ˮƽ����ʽ")]
        public DashStyle RightHorizontalLineStyle
        {
            get
            {
                return _rightHorizontalLineStyle;
            }
            set
            {
                _rightHorizontalLineStyle = value;
            }
        }

        [Category("����-�Զ���"), DisplayName("�߿���ɫ")]
        public new Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                base.BorderColor = value;
                //_gridColor = value;
                //_minScaleColor = value;
            }
        }

        /// <summary>
        /// ��ҩ�����б�
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�����б�")]
        public List<MedDrugCurve> Curves
        {
            get
            {
                return _curves;
            }
            set
            {
                _curves = value;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        [Category("����-�Զ���"), DisplayName("��������")]
        public TotalType TotalType
        {
            get
            {
                return _totalType;
            }
            set
            {
                _totalType = value;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        [Category("����-�Զ���"), DisplayName("��������")]
        public Font CurveFont
        {
            get
            {
                if (_curveFont == null)
                {
                    return DefaultFont;
                }
                else
                {
                    return _curveFont;
                }
            }
            set
            {
                _curveFont = value;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        [Category("����-�Զ���"), DisplayName("��������")]
        public Font TotalFont
        {
            get
            {
                if (_totalFont == null)
                {
                    return DefaultFont;
                }
                else
                {
                    return _totalFont;
                }
            }
            set
            {
                _totalFont = value;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        [Category("����-�Զ���"), DisplayName("������ɫ")]
        public Color TotalColor
        {
            get
            {
                return _totalColor;
            }
            set
            {
                _totalColor = value;
            }
        }

        /// <summary>
        /// ͼ������
        /// </summary>
        [Category("����-�Զ���"), DisplayName("ͼ������")]
        public Font LegendFont
        {
            get
            {
                if (_legengFont != null)
                {
                    return _legengFont;
                }
                else
                {
                    return DefaultFont;
                }
            }
            set
            {
                _legengFont = value;
            }
        }

        /// <summary>
        /// ������ɫ
        /// </summary>
        [Category("����-�Զ���"), DisplayName("������ɫ")]
        public Color GridColor
        {
            get
            {
                return _gridColor;
            }
            set
            {
                _gridColor = value;
            }
        }

        /// <summary>
        /// �����߿��
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�����߿��")]
        public int GridLineWidth
        {
            get
            {
                return _gridLineWidth;
            }
            set
            {
                _gridLineWidth = value;
            }
        }

        /// <summary>
        /// �̶�����ʽ
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�̶�����ʽ")]
        public DashStyle GridDashStyle
        {
            get
            {
                return _gridDashStyle;
            }
            set
            {
                _gridDashStyle = value;
            }
        }

        /// <summary>
        /// С�̶�����ʽ
        /// </summary>
        [Category("����-�Զ���"), DisplayName("С�̶�����ʽ")]
        public DashStyle MinDashStyle
        {
            get
            {
                return _minDashStyle;
            }
            set
            {
                _minDashStyle = value;
            }
        }

        /// <summary>
        /// С�̶��߿��
        /// </summary>
        [Category("����-�Զ���"), DisplayName("С�̶��߿��")]
        public float MinScaleWidth
        {
            get
            {
                return _minScaleWidth;
            }
            set
            {
                _minScaleWidth = value;
            }
        }

        /// <summary>
        /// С�̶�����ɫ
        /// </summary>
        [Category("����-�Զ���"), DisplayName("С�̶�����ɫ")]
        public Color MinScaleColor
        {
            get
            {
                if (_isPrinting)
                {
                    return _printColor;
                }
                else
                {
                    return _middleLineColor;
                }
            }
            set
            {
                _middleLineColor = value;
            }
        }

        /// <summary>
        /// С�̶�����
        /// </summary>
        [Category("����-�Զ���"), DisplayName("С�̶�����")]
        public int MinScaleCount
        {
            get
            {
                return _minScaleCount;
            }
            set
            {
                _minScaleCount = value;
            }
        }

        private bool _isOnlyLine;
        [Category("����-�Զ���"), DisplayName("ֻ��ʾ������ҩ")]
        public bool IsOnlyLine
        {
            get
            {
                return _isOnlyLine;
            }
            set
            {
                _isOnlyLine = value;
            }
        }

        private bool _isSingleColor = false;
        [Category("����-�Զ���"), DisplayName("��һ��ɫ��ʾ")]
        public bool IsSingleColor
        {
            get
            {
                return _isSingleColor;
            }
            set
            {
                _isSingleColor = value;
            }
        }

        private Color _singleColor = Color.Blue;
        [Category("����-�Զ���"), DisplayName("��һ��ɫ")]
        public Color SingleColor
        {
            get
            {
                return _singleColor;
            }
            set
            {
                _singleColor = value;
            }
        }

        private Color _singleTextColor = Color.Blue;
        [Category("����-�Զ���"), DisplayName("��һ�ı���ɫ")]
        public Color SingleTextColor
        {
            get
            {
                return _singleTextColor;
            }
            set
            {
                _singleTextColor = value;
            }
        }

        private bool _hasLegendSymbol = true;
        [Category("����-�Զ���"), DisplayName("��ʾͼ����ʶ")]
        public bool HasLegendSymbol
        {
            get
            {
                return _hasLegendSymbol;
            }
            set
            {
                _hasLegendSymbol = value;
            }
        }

        private bool _showLegend = true;
        [Category("����-�Զ���"), DisplayName("��ʾͼ��")]
        public bool ShowLegend
        {
            get
            {
                return _showLegend;
            }
            set
            {
                _showLegend = value;
            }
        }

        private bool _hasBeiYongYao = false;
        [Category("����-�Զ���"), DisplayName("��ʾ����ҩ")]
        public bool HasBeiYongYao
        {
            get
            {
                return _hasBeiYongYao;
            }
            set
            {
                _hasBeiYongYao = value;
            }
        }

        /// <summary>
        /// �Ƿ���ҩ�ѱ��޸�
        /// </summary>
        private bool _beiYongYaoChanged = false;
        public bool BeiYongYaoChanged
        {
            get
            {
                return _beiYongYaoChanged;
            }
            set
            {
                _beiYongYaoChanged = value;
            }
        }

        private string _beiYongYao = "";
        [Category("����-�Զ���"), DisplayName("����ҩ")]
        public string BeiYongYao
        {
            get
            {
                return _beiYongYao;
            }
            set
            {
                _beiYongYao = value;
                _beiYongYaoChanged = true;
            }
        }

        /// <summary>
        /// �Ҽ��˵�
        /// </summary>
        private ContextMenuStrip _popupMenu;
        public ContextMenuStrip PopupMenu
        {
            set
            {
                _popupMenu = value;
            }
        }

        private bool _noPrint = false;
        [DisplayName("����ӡ")]
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

        private Color _printColor = Color.DarkGray;
        [DisplayName("�����ӡ��ɫ")]
        public Color PringColor
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

        /// <summary>
        /// �Ƿ����ڴ�ӡ��
        /// </summary>
        private bool _isPrinting = false;
        public bool IsPrinting
        {
            get
            {
                return _isPrinting;
            }
            set
            {
                _isPrinting = value;
            }
        }

        private List<LineParameter> _lineParameters = new List<LineParameter>(8);
        [Category("����-�Զ���"), DisplayName("�в���")]
        public List<LineParameter> LineParameters
        {
            get
            {
                return _lineParameters;
            }
            set
            {
                _lineParameters = value;
            }
        }

        private bool _sameVertLineColor = false;
        [Category("����-�Զ���"), DisplayName("������ɫͳһ")]
        public bool SameVertLineColor
        {
            get
            {
                return _sameVertLineColor;
            }
            set
            {
                _sameVertLineColor = value;
            }
        }

        /// <summary>
        /// ��ѡ��������
        /// </summary>
        private int _selectLineIndex = -1;
        [Browsable(false)]
        public int SelectedLineIndex
        {
            get
            {
                return _selectLineIndex;
            }
        }

        /// <summary>
        /// �Ƿ��Զ���ʾ
        /// </summary>
        private bool _autoShow = false;
        public bool AutoShow
        {
            get
            {
                return _autoShow;
            }
            set
            {
                _autoShow = value;
            }
        }

        /// <summary>
        /// �Ƿ��������
        /// </summary>
        private bool _lockMouse = false;
        [Browsable(false)]
        public bool LockMouse
        {
            get
            {
                return _lockMouse;
            }
            set
            {
                _lockMouse = value;
            }
        }

        /// <summary>
        /// �ϴ����λ��
        /// </summary>
        private Point _oldMousePos = new Point(-1000, -1000);

        /// <summary>
        /// �������ʱ���
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

        private int _modNumber = -1;
        [DisplayName("����ʱ��(��)")]
        public int ModNumber
        {
            get
            {
                return _modNumber;
            }
            set
            {
                _modNumber = value;
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

        private bool _hasTagLine = false;
        [DisplayName("�Ƿ�Ҫ����")]
        public bool HasTagLine
        {
            get
            {
                return _hasTagLine;
            }
            set
            {
                _hasTagLine = value;
            }
        }

        /// <summary>
        /// ���˫��ʱ������
        /// </summary>
        private int _doubleMouseRowIndex = -1;
        [Browsable(false)]
        public int DoubleMouseRowIndex
        {
            get
            {
                return _doubleMouseRowIndex;
            }
        }

        /// <summary>
        /// ѡ�еĵ�
        /// </summary>
        private MedDrugPoint _selectPoint = null;
        [Browsable(false)]
        public MedDrugPoint SelectedPoint
        {
            get
            {
                return _selectPoint;
            }
        }

        /// <summary>
        /// ��ͨ��ʾ����
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
        /// ����ҩ��ʾ����
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


        #region add by xiaopei.y@2014-11-14 10:19:51  ��ǰʱ���߿���


        private bool _isCurrentTimeLine;
        [Category("����-�Զ���"), DisplayName("�Ƿ���ʾ��ǰʱ����")]
        public bool IsCurrentTimeLine
        {
            get
            {
                return _isCurrentTimeLine;
            }
            set
            {
                _isCurrentTimeLine = value;
            }
        }
        #endregion

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
            //float columnWidth = ColumnWidth;
            string ttt = text.Trim();
            //while (ttt.IndexOf("  ") > 0) ttt = ttt.Replace("  ", " ");
            //if (g.MeasureString(ttt, font).Width > columnWidth)
            //    ttt = ttt.Replace(" ", "");
            if (ttt.Contains("."))
            {
                string a = ttt.Substring(0, ttt.IndexOf(".") + 1);
                g.DrawString(a, font, brush, x, y);
                string b = ttt.Substring(ttt.IndexOf(".") + 1);
                g.DrawString(b, font, brush, x + g.MeasureString(a, font).Width - 7, y);
            }
            else
            {
                g.DrawString(ttt, font, brush, x, y);
            }
        }

        private bool _drawHourLines = false;
        [DisplayName("��������")]
        public bool IsDrawHourLines
        {
            get
            {
                return _drawHourLines;
            }
            set
            {
                _drawHourLines = value;
            }
        }


        private void DrawHourLines(Graphics g)
        {
            RectangleF rect = GetMainRect();
            DateTime dt = DateTime.Now;
            if (_startTime.Hour == 23)
            {
                dt = new DateTime(_startTime.Year, _startTime.Month, _startTime.Day, _startTime.Hour, 0, 0);
                dt.AddHours(1);
            }
            else
            {
                dt = new DateTime(_startTime.Year, _startTime.Month, _startTime.Day, _startTime.Hour + 1, 0, 0);

            }

            TimeSpan spTotal = _endTime - _startTime;
            while (dt < _endTime)
            {
                TimeSpan spThis = dt - _startTime;
                float x1 = (float)(rect.X + rect.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                g.DrawLine(Pens.Black, x1, rect.Y + _topOffSet, x1, rect.Bottom);
                dt = dt.AddHours(1);
            }
        }

        #region 2013-3-18 ����ƽ ����ǰʱ����
        private void DrawNowHourLines(Graphics g)
        {
            RectangleF rect = GetMainRect();
            DateTime dt = DateTime.Now;

            TimeSpan spTotal = _endTime - _startTime;
            TimeSpan spThis = dt - _startTime;
            float x1 = (float)(rect.X + rect.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
            g.DrawLine(new Pen(Color.Red, 0), x1, rect.Y + _topOffSet, x1, rect.Bottom);
        }
        #endregion

        /// <summary>
        /// ������ͼ
        /// </summary>
        /// <param name="g"></param>
        public override void DrawGraphics(Graphics graphics)
        {
            _zoomRate = (float)(1 / _showZoomRate);

            Graphics g = graphics;

            bool lockMouse = _lockMouse;
            _lockMouse = true;
            base.DrawGraphics(g);

            ResetLineHeight(g);
            DrawGrid(g);

            if (_drawHourLines)
            {
                DrawHourLines(g);
            }

            #region 2013-3-18 ����ƽ ����ǰʱ����,����ӡ����
            if (!_printing)
            {
                if (IsCurrentTimeLine)  // add by xiaopei.y@2014-11-14 10:24:00  ��ǰʱ���߸���������ʾ
                {
                    DrawNowHourLines(g);
                }
            }
            #endregion

            RectangleF rect = GetMainRect();
            for (int index = 0; index < _curves.Count; index++)
            {
                DrawPoints(g, index);
            }
            using (SolidBrush solidBrush = new SolidBrush(BackColor))
            {
                g.FillRectangles(solidBrush, new Rectangle[] { new Rectangle(2, (int)_topOffSet + 1, (int)rect.Left - 3, (int)(rect.Height - _topOffSet - 2))
                , new Rectangle((int)rect.Right, (int)_topOffSet + 1, (int)ClientRectangle.Width - (int)rect.Right - 2, (int)(rect.Height - _topOffSet - 2)) });
            }
            using (Pen pen = new Pen(_borderColor))
            {
                g.DrawLine(pen, OriginRect.Right - 1, 1, OriginRect.Right - 1, (int)(rect.Height - 2));
            }

            for (int index = 0; index < _curves.Count; index++)
            {
                if (_showLegend)
                {
                    DrawLegend(g, index);
                }
                if (_rightWidthPercent > 0)
                {
                    DrawTotal(g, index);
                }
            }
            if (_hasLeftHorizontalLine)
            {
                using (Pen pen1 = new Pen(MinScaleColor, _minScaleWidth))
                {
                    pen1.DashStyle = _leftHorizontalLineStyle;
                    float leftoff = string.IsNullOrEmpty(_title) ? 0f : _titleWidth;
                    DrawLines(g, pen1, OriginRect.Left + (int)leftoff, (OriginRect.Width - (int)GetMainRect().Width));
                }
            }
            using (Pen pen2 = new Pen(MinScaleColor, _minScaleWidth))
            {
                if (_hasRightHorizontalLine)
                {
                    pen2.DashStyle = _rightHorizontalLineStyle;
                    DrawLines(g, pen2, (OriginRect.Width - (int)GetMainRect().Width), OriginRect.Width);
                }
                else
                {
                    pen2.DashStyle = _rightHorizontalLineStyle;
                    DrawLines(g, pen2, rect.Left, rect.Right);
                }
            }
            if (_rightWidthPercent > 0)
            {
                if (_vitalSign != null)
                {
                    RectangleF rectF = GetMainRect();
                    rectF.X = rectF.Right;
                    rectF.Y += _topOffSet;
                    using (SolidBrush solidBrush2 = new SolidBrush(BackColor))
                    {
                        g.FillRectangle(solidBrush2, new RectangleF(rectF.X, rectF.Top + 2, OriginRect.Right - rectF.X, rectF.Height));
                    }
                    using (Pen pen3 = new Pen(_borderColor))
                    {
                        g.DrawLine(pen3, OriginRect.Right - 1, rect.Top, OriginRect.Right - 1, rectF.Bottom);
                    }

                    if (!_isPrinting)
                    {
                        rectF.Y += _topOffSet + 1;
                    }
                    if (_showLegend)
                    {
                        _vitalSign.DrawLegend(g, rectF);
                    }
                }
                using (SolidBrush solidBrush3 = new SolidBrush(BackColor))
                {
                    //g.FillRectangle(solidBrush3, new Rectangle((int)OriginRect.Right, (int)rect.Top, 100, (int)rect.Height));
                }

            }
            else
            {
                //�����߽��� ������ ע�͵�
                //g.FillRectangle(new SolidBrush(BackColor), new Rectangle((int)rect.Right, (int)rect.Top, 100, (int)rect.Height));
            }
            if (_hasBeiYongYao)
            {
                using (SolidBrush solidBrush4 = new SolidBrush(_borderColor))
                {
                    g.DrawString("����ҩ", Font, solidBrush4, (rect.Right + OriginRect.Right - g.MeasureString("����ҩ", Font).Width) / 2, rect.Top + 1);
                    g.DrawString(_beiYongYao, Font, solidBrush4, rect.Right + 1, rect.Top + 1 + _topOffSet);
                }

            }
            using (Pen pen = new Pen(_borderColor))
            {
                g.DrawLine(pen, rect.Left, 30, rect.Left, rect.Bottom);
            }
            //  g.DrawLine(Pens.Red, rect.Left, 30, rect.Left, rect.Bottom);
            if (_clearLeftTopLine)
            {
                g.FillRectangle(Brushes.White, new RectangleF(-1, 0, 2, _topOffSet));
            }
            DrawTitle(g, OriginRect.X, OriginRect.Y, OriginRect);
            PaintEventHandler eventHandle = Events[_customDraw] as PaintEventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, new PaintEventArgs(g, ClientRectangle));
            }

            _lockMouse = lockMouse;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        private int GetLineCount()
        {
            int count = _lineParameters.Count;
            if (count == 0)
            {
                count = 8;
            }
            return count;
        }

        /// <summary>
        /// ���¼���߶�
        /// </summary>
        /// <param name="g"></param>
        private void ResetLineHeight(Graphics g)
        {
            _lineHeight = ((float)Height - _topOffSet) / (float)GetLineCount(); //(int)((Height - _topOffSet) / GetLineCount());
            //if (!_isPrinting) 
            _lineHeight--;
            _lineHeight = _zoomRate * _lineHeight;
            //_lineHeight = 1;
            //float h;
            ////float ph = Com.MedicalSystem.Common.Utilities.Globals.GetPrintRowHeight(_scaleRate, Font);
            ////if (ph > 0)
            ////{
            ////    h = ph + 1;
            ////    if (_lineHeight < h) _lineHeight = h;
            ////}
            ////else
            //{
            //    h = g.MeasureString("A", CurveFont).Height + 1;
            //    if (_lineHeight < h) _lineHeight = h;
            //    h = g.MeasureString("A", LegendFont).Height + 1;
            //    if (_lineHeight < h) _lineHeight = h;
            //    h = g.MeasureString("A", TotalFont).Height + 1;
            //    if (_lineHeight < h) _lineHeight = h;
            //    if (_isPrinting) _lineHeight -= 2;
            //}
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
                g.FillRectangle(Brushes.White, new RectangleF(x + 1, y + 1 + _topOffSet, _titleWidth - 1, rect.Height - 2 - _topOffSet));
                g.DrawString(_title.Replace(" ", "\r\n"), Font, Brushes.Black, new RectangleF(x + 1, y + 1 + _topOffSet, _titleWidth - 2, rect.Height - 2 - _topOffSet), sf);
                x += _titleWidth;
                g.DrawLine(Pens.Black, x - 2, y + _topOffSet, x - 2, rect.Bottom);
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="g"></param>
        private void DrawGrid(Graphics g)
        {
            RectangleF rectF = GetMainRect();
            float gridWidth = GetGridWidth();
            float x = rectF.X + gridWidth;
            Color color = _gridColor;
            if (_sameVertLineColor)
            {
                color = MinScaleColor;
            }
            using (Pen pen = new Pen(color, _gridLineWidth))
            {
                pen.DashStyle = _gridDashStyle;
                while (x + gridWidth - 5 < rectF.Right)
                {
                    g.DrawLine(pen, x, rectF.Top + _topOffSet, x, rectF.Bottom);
                    DrawMinGrid(g, new RectangleF(x, rectF.Top + _topOffSet, gridWidth, rectF.Height - _topOffSet));
                    x += gridWidth;
                }
                DrawMinGrid(g, new RectangleF(x, rectF.Top + _topOffSet, gridWidth, rectF.Height - _topOffSet));
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rectF"></param>
        private void DrawMinGrid(Graphics g, RectangleF rectF)
        {
            float minGridWidth = rectF.Width / _minScaleCount;
            Color color = MinScaleColor;
            if (_isPrinting)
            {
                color = _printColor;
            }
            using (Pen pen = new Pen(color, _minScaleWidth))
            {
                pen.DashStyle = _minDashStyle;
                for (int i = 1; i < _minScaleCount; i++)
                {
                    if (rectF.X + minGridWidth * i - rectF.Width > ClientRectangle.Right - 1) break;
                    g.DrawLine(pen, rectF.X + minGridWidth * i - rectF.Width, rectF.Top, rectF.X + minGridWidth * i - rectF.Width, rectF.Bottom);
                }
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="g"></param>
        /// <param name="index"></param>
        private void DrawPoints(Graphics g, int index)
        {
            MeasurePoints(g, index, new Point());
        }

        /// <summary>
        /// ��ȡ���ֵ
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private string GetPointValue(MedDrugPoint point)
        {

            string text = "";
            if (point.Value != null)
            {
                text = point.Value.ToString();
            }
            if (point.Curve != null && point.Curve.MaxValue > MedDrugCurve.MINVALUE)
            {
                double d;
                if (!double.TryParse(text, out d))
                {
                    d = MedDrugCurve.MINVALUE;
                }
                if (d > point.Curve.MaxValue)
                {
                    text = ">" + point.Curve.MaxValue.ToString();
                }
            }
            return text;
        }

        /// <summary>
        /// �������ߵĵ㼯��
        /// </summary>
        /// <param name="g"></param>
        /// <param name="index"></param>
        /// <param name="pt">���λ��</param>
        /// <returns>������</returns>
        private int MeasurePoints(Graphics g, int index, Point pt)
        {
            //������ by joysola
            //string passedFormatText = ";DOSAGE;DOSAGE_UNITS;+;(;PERFORM_SPEED;SPEED_UNIT;+;CONCENTRATION;CONCENTRATION_UNIT;)";//��ʽ�ַ�����Ҫ����
            //modified by joysola on 2018-2-26 ������med_config��ȡ��ʽ���ַ���
            string passedFormatText = DrugPointShowFormatType;

            float tagHeight = 5;
            MedDrugCurve curve = _curves[index];
            string unit = curve.Unit;
            RectangleF rect = GetMainRect();
            Rectangle legengRect = GetLegendRect(g, index);
            Font font = CurveFont;
            for (int k = 0; k < curve.Points.Count; k++)
            {
                MedDrugPoint point = curve.Points[k];

                //Խ��Ĳ���

                ////����Ƿ�ҳ����ô�жϿ��ܻ�Խ��
                //if (point.StartTime < _startTime)
                //    break;
                ////Խ��Ĳ���
                //if (point.EndTime > _endTime)
                //    break;

                TimeSpan spThis, spTotal;
                float x1, x2;
                switch (point.PointType)
                {
                    case PointType.SinglePoint:

                        if (point.StartTime < _startTime) //������Ļ���Խ������˳�
                            break;
                        spThis = point.StartTime - _startTime;



                        spTotal = _endTime - _startTime;


                        point.X1 = (float)(rect.X + rect.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                        point.Y = rect.Y + _lineHeight * (index + .5f) + _topOffSet;
                        point.Y = (legengRect.Top + legengRect.Bottom) / 2;
                        if (point.StartTime == DateTime.MinValue) continue;


                        ///�������ߺ�����˵��
                        if (rect.Contains(point.X1, point.Y))
                        {
                            if (string.IsNullOrEmpty(curve.Text2) && !curve.CenterValue)
                            {
                                if (_hasTagLine)
                                {
                                    using (Pen pen = new Pen(GetCurveColor(curve)))
                                    {
                                        g.DrawLine(pen, point.X1, point.Y - tagHeight, point.X1, point.Y + tagHeight);
                                    }

                                }
                            }
                        }
                        string text1 = GetPointValue(point); //((double)point.Value).ToString();
                        if (!string.IsNullOrEmpty(point.Unit))
                        {
                            if (!string.IsNullOrEmpty(unit) && unit.Trim().ToLower().Equals(point.Unit.Trim().ToLower()))
                            {
                            }
                            else
                            {
                                text1 += point.Unit;
                            }
                        }
                        if (string.IsNullOrEmpty(text1))
                        {
                            text1 = "";
                        }
                        //if (!string.IsNullOrEmpty(point.Route))
                        //{
                        //    text1 += "(" + point.Route + ")";
                        //}

                        if (point.StartTime == _endTime && !string.IsNullOrEmpty(text1))//��������յ��ڱ߽�
                        {
                            point.X1 = point.X1 - 2 - g.MeasureString(text1, CurveFont).Width; ;
                        }


                        if (!string.IsNullOrEmpty(curve.Text2) || curve.CenterValue)//���������
                        {
                            if (!string.IsNullOrEmpty(curve.Text2))
                            {
                                text1 += "/" + point.Value2.ToString();
                            }
                            float xx = point.X1 + 2 - g.MeasureString(text1, CurveFont).Width / 2;
                            if (rect.Contains(xx, point.Y - g.MeasureString("A", CurveFont).Height / 2 + 1))
                            {
                                g.FillRectangle(Brushes.White, new Rectangle((int)(point.X1 + 2 - g.MeasureString(text1, CurveFont).Width / 2), legengRect.Top - 1, (int)g.MeasureString(text1, CurveFont).Width, (int)_lineHeight + 1));
                                using (SolidBrush solidBrush = new SolidBrush(GetCurveColor(curve)))
                                {
                                    DrawString(g, text1, CurveFont, solidBrush, xx, point.Y - g.MeasureString("A", CurveFont).Height / 2 + 1);
                                }

                            }
                            point.X1 = point.X1 - g.MeasureString(text1, CurveFont).Width / 2;
                            point.X2 = point.X1 + g.MeasureString(text1, CurveFont).Width;
                            if (!string.IsNullOrEmpty(point.Route))
                            {
                                using (SolidBrush solidBrush1 = new SolidBrush(GetCurveColor(curve)))
                                {
                                    DrawString(g, point.Route, CurveFont, solidBrush1, point.X1 + 2, point.Y);
                                }

                            }
                        }
                        else
                        {
                            SolidBrush solidBrush = new SolidBrush(GetCurveColor(curve));

                            //modified by joysola on 2018-2-22��2-28��3-1
                            //text1 = GetPointDrugShowText2(point, passedFormatText);
                            text1 = ShowHelper.GetPointDrugShowText(point, PointMarkFormat, DrugPointShowFormatType);
                            //��Ϊ\r\n[i.vdrip]�������£�������ȷ���У����Բ�ȡ���з���
                            if (text1.Contains("\r\n"))//����
                            {
                                string textTop = text1.Substring(0, text1.IndexOf("\r"));
                                string textBottom = text1.Substring(text1.IndexOf("\n") + 1, text1.Length - text1.IndexOf("\n") - 1);//;��
                                //float textBottomStart = point.X1 + (g.MeasureString(textTop, CurveFont).Width - g.MeasureString(textBottom, CurveFont).Width) / 2;//;����㣨���У�
                                DrawString(g, textTop, CurveFont, solidBrush, point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                                float textBottomStart = point.X1 + 2;//;����㣨�����浥λ�����һ�£�
                                DrawString(g, textBottom, CurveFont, solidBrush, textBottomStart, point.Y + g.MeasureString("A", CurveFont).Height / 2);//��;��
                            }
                            else
                                DrawString(g, text1, CurveFont, solidBrush, point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);

                            //ע�� by joysola 
                            #region �ϴ���
                            //switch (_drugShowType)
                            //{
                            //    case NormalDrugUnitShowType.Dosage:
                            //        text1 = point.Value.ToString();
                            //        DrawString(g, text1, CurveFont, solidBrush, point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case NormalDrugUnitShowType.DosageThick:
                            //        text1 = point.Value.ToString() + "(" + point.ThickNess.ToString() + ")";
                            //        DrawString(g, text1, CurveFont, solidBrush, point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case NormalDrugUnitShowType.DosageThickRoute:
                            //        text1 = point.Value.ToString() + "(" + point.ThickNess.ToString() + "+" + point.Route + ")";
                            //        DrawString(g, text1, CurveFont, solidBrush, point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case NormalDrugUnitShowType.DosageUnit:
                            //        text1 = point.Value.ToString() + "(" + point.Unit + ")";
                            //        DrawString(g, text1, CurveFont, solidBrush, point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case NormalDrugUnitShowType.Thick:
                            //        text1 = point.ThickNess.ToString();
                            //        DrawString(g, text1, CurveFont, solidBrush, point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    default:
                            //        //Modify by wenpei.x@2014-02-11
                            //        //������ҩĬ��;�������Ҳ�
                            //        if (rect.Contains(point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2))
                            //        {
                            //            //if (!string.IsNullOrEmpty(point.Route))
                            //            //{
                            //            //    DrawString(g, string.Format("{0}({1})", text1, point.Route), CurveFont, solidBrush, point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //            //}
                            //            //else
                            //            {
                            //                DrawString(g, text1, CurveFont, solidBrush, point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //            }
                            //        }
                            //        // point.X2 = point.X1 + g.MeasureString(text1, CurveFont).Width;
                            //        //if (rect.Contains(point.X1 + 2, point.Y - g.MeasureString("A", CurveFont).Height / 2))
                            //        // {
                            //        //     if (!string.IsNullOrEmpty(point.Route))
                            //        //     {//CurveFont.FontFamily.Name
                            //        //         //Font routeFont = new Font(CurveFont.FontFamily.Name, CurveFont.Size - 2);
                            //        //         if (rect.Contains(point.X1 + 5, point.Y + 3 - g.MeasureString("��", CurveFont).Height / 2))
                            //        //         {
                            //        //             DrawString(g, point.Route, font, solidBrush, point.X1 + 2, point.Y + 3);
                            //        //         }
                            //        //         else
                            //        //         {
                            //        //             DrawString(g, point.Route, font, solidBrush, point.X1 + 2, point.Y);
                            //        //         }
                            //        //         //routeFont.Dispose();
                            //        //     }
                            //        //}
                            //        break;
                            //}
                            //
                            #endregion

                            point.X2 = point.X1 + g.MeasureString(text1, CurveFont).Width;
                            solidBrush.Dispose();
                        }
                        break;
                    case PointType.ProLonged:

                        if (point.StartTime < _startTime)
                            spThis = _startTime - _startTime;//�ӵ�ǰҳ�Ŀ�ʼʱ�仭
                        else
                            spThis = point.StartTime - _startTime;

                        if (point.StartTime < _startTime && point.EndTime == _startTime)
                        {
                            //�����ҳ���������ս���ʱ��͵�ǰҳ�Ŀ�ʼʱ��һ�����򲻻ᣬ��Ȼ���е����
                            break;
                        }
                        //ԭ����
                        // spThis = point.StartTime - _startTime;

                        spTotal = _endTime - _startTime;

                        point.X1 = (float)(rect.X + rect.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                        point.Y = rect.Y + _lineHeight * (index + .5f) + _topOffSet;
                        point.Y = (legengRect.Top + legengRect.Bottom) / 2;
                        if (point.StartTime == DateTime.MinValue) continue;
                        ///�����
                        if (rect.Contains(point.X1, point.Y))
                        {
                            using (Pen pen = new Pen(GetCurveColor(curve)))
                            {
                                g.DrawLine(pen, point.X1, point.Y - tagHeight, point.X1, point.Y + tagHeight);
                            }

                        }


                        if (point.EndTime < _startTime)//�������ʱ��û�е�ǰҳ�Ŀ�ʼʱ����˳�
                            break;


                        if (point.EndTime < _endTime)
                        {
                            spThis = point.EndTime - _startTime;//
                        }
                        else
                        {
                            spThis = _endTime - _startTime;//
                        }




                        //ԭ����ôд
                        //spThis = point.EndTime - _startTime;

                        point.X2 = (float)(rect.X + rect.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                        Pen pen1 = new Pen(GetCurveColor(curve));
                        ///���յ�
                        if (point.IsArrow)
                        {
                            if (rect.Contains(point.X2 - 1, point.Y))
                            {

                                if (point.IsArrow)
                                {
                                    g.DrawLine(pen1, point.X2 - 1, point.Y, point.X2 - tagHeight, point.Y + tagHeight);
                                    g.DrawLine(pen1, point.X2 - 1, point.Y, point.X2 - tagHeight, point.Y - tagHeight);
                                }
                                else
                                {
                                    g.DrawLine(pen1, point.X2, point.Y - tagHeight, point.X2, point.Y + tagHeight);
                                }

                            }
                        }
                        else
                        {
                            if (rect.Contains(point.X2, point.Y))
                            {
                                if (point.IsArrow)
                                {
                                    g.DrawLine(pen1, point.X2, point.Y, point.X2 - tagHeight, point.Y + tagHeight);
                                }
                                else
                                {
                                    g.DrawLine(pen1, point.X2, point.Y - tagHeight, point.X2, point.Y + tagHeight);
                                }

                            }
                        }


                        string text = "";
                        //modified by joysola on 2018-2-27 ��4-8 
                        //text = GetPointDrugShowText2(point, passedFormatText);
                        text = ShowHelper.GetPointDrugShowText(point, ProLongedMarkFormat, DrugProLongedShowFormatType);

                        //ע�� by joysola 
                        #region �ϴ���
                        //switch (point.ShowType)
                        //{
                        //    case ProLongedShowType.Unit:
                        //        text = GetPointValue(point) + point.Unit;
                        //        break;
                        //    case ProLongedShowType.Speed:
                        //        if (point.ThickNess > 0)
                        //        {
                        //            text += point.ThickNess.ToString() + point.ThickNessUnit;
                        //        }
                        //        else if (point.Speed > 0)
                        //        {
                        //            text = ((double)point.Speed).ToString() + point.SpeedUnit;// .Unit + "/s";
                        //        }
                        //        else
                        //        {
                        //            text = GetPointValue(point) + point.Unit;
                        //        }
                        //        if (point.ThickNess > 0 && point.Speed > 0)
                        //        {
                        //            text = point.Speed.ToString() + "(" + point.ThickNess.ToString() + ")";
                        //        }
                        //        break;
                        //    case ProLongedShowType.TotalAndSpeed:
                        //        text = GetPointValue(point) + point.Unit + ((point.Speed > 0) ? "(" + point.Speed.ToString() + point.SpeedUnit + ")" : "");
                        //        break;
                        //    case ProLongedShowType.Default:
                        //        if (point.ThickNess > 0)
                        //        {
                        //            text += point.ThickNess.ToString();
                        //        }
                        //        else if (point.Speed > 0)
                        //        {
                        //            text = ((double)point.Speed).ToString();// .Unit + "/s";
                        //        }
                        //        else
                        //        {
                        //            text = GetPointValue(point);
                        //        }
                        //        if (point.ThickNess > 0 && point.Speed > 0)
                        //        {
                        //            text = point.Speed.ToString() + "(" + point.ThickNess.ToString() + ")";
                        //        }
                        //        break;
                        //}
                        //if (point.ThickNess > 0)
                        //{
                        //    text = point.ThickNess.ToString() + point.ThickNessUnit;
                        //}
                        #endregion

                        ///��ͼ-���ߺ�����˵��
                        x1 = point.X1;
                        //
                        float drugTtextLength = g.MeasureString(text, font).Width;//��¼���ֳ���

                        if (drugTtextLength > point.X2 - point.X1)//���ֱ�ʱ���߳��������ڲ�����
                        {
                            float timeLength = point.X2 - point.X1;//ʱ����
                            x1 = point.X1;//�������
                            x2 = point.X2;//�����յ�
                            if (x1 < rect.Left)
                            {
                                x1 = rect.Left;
                            }
                            if (x2 > rect.Right)
                            {
                                x2 = rect.Right;
                            }

                            pen1.Dispose();
                            SolidBrush solidBrush2 = new SolidBrush(GetCurveColor(curve));
                            if (text.Contains("\r\n"))//��������;������
                            {

                                string textTop = text.Substring(0, text.IndexOf("\r"));
                                string textBottom = text.Substring(text.IndexOf("\n") + 1, text.Length - text.IndexOf("\n") - 1);//;��
                                float textBottomLength = g.MeasureString(textBottom, font).Width;//��¼;�����ֳ���
                                float textBottomStart = point.X1 + (timeLength - textBottomLength) / 2;//;�����ֵ���㣨����Ч����
                                DrawString(g, textBottom, CurveFont, solidBrush2, textBottomStart, point.Y + g.MeasureString("A", CurveFont).Height / 2);//;��
                                DrawString(g, textTop, CurveFont, solidBrush2, x1, point.Y - g.MeasureString("A", CurveFont).Height / 2);

                            }
                            else
                                DrawString(g, text, CurveFont, solidBrush2, x1, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                        }
                        else//�������
                        {
                            x2 = point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2;
                            if (x1 < rect.Left)
                            {
                                x1 = rect.Left;
                            }
                            if (x2 > rect.Right)
                            {
                                x2 = rect.Right;
                            }
                            if (x2 > x1)
                            {
                                g.DrawLine(pen1, x1, point.Y, x2, point.Y);
                            }
                            float x3 = point.X1 + (point.X2 - point.X1 + g.MeasureString(text, font).Width) / 2;
                            if (x3 < rect.Left)
                            {
                                x3 = rect.Left;
                            }
                            g.DrawLine(pen1, x3, point.Y, point.X2, point.Y);
                            pen1.Dispose();
                            SolidBrush solidBrush2 = new SolidBrush(GetCurveColor(curve));

                            //modified by joysola on 2018-2-22
                            //text = GetPointDrugShowText(point, passedFormatText);
                            DrawString(g, text, CurveFont, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);

                            //ע�� by joysola
                            #region �ϴ���
                            //switch (_proLongedDrugShowType)
                            //{
                            //    case ProLongedDrugUnitShowType.Thick:
                            //        text = point.ThickNess.ToString();
                            //        DrawString(g, text, CurveFont, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case ProLongedDrugUnitShowType.Speed:
                            //        text = point.Speed.ToString();
                            //        DrawString(g, text, CurveFont, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case ProLongedDrugUnitShowType.Dosage:
                            //        text = point.Value.ToString();
                            //        DrawString(g, text, CurveFont, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case ProLongedDrugUnitShowType.DosageSpeed:
                            //        text = point.Value.ToString() + "(" + point.Speed.ToString() + ")";
                            //        DrawString(g, text, CurveFont, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case ProLongedDrugUnitShowType.DosageThick:
                            //        text = point.Value.ToString() + "(" + point.ThickNess.ToString() + ")";
                            //        DrawString(g, text, CurveFont, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case ProLongedDrugUnitShowType.SpeedThick:
                            //        text = point.Speed.ToString() + "(" + point.ThickNess.ToString() + ")";
                            //        DrawString(g, text, CurveFont, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    case ProLongedDrugUnitShowType.SpeedThickRoute:
                            //        text = point.Speed.ToString() + "(" + point.ThickNess.ToString() + "+" + point.Route + ")";
                            //        DrawString(g, text, CurveFont, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        break;
                            //    default:
                            //        DrawString(g, text, CurveFont, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(text, font).Width) / 2, point.Y - g.MeasureString("A", CurveFont).Height / 2);
                            //        //if (!string.IsNullOrEmpty(point.Route))
                            //        //{
                            //        //    if (rect.Contains(point.X1 + (point.X2 - point.X1 - g.MeasureString(point.Route, font).Width) / 2, point.Y + 3))
                            //        //    {
                            //        //        DrawString(g, point.Route, font, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(point.Route, font).Width) / 2, point.Y + 3);
                            //        //    }
                            //        //    else
                            //        //    {
                            //        //        DrawString(g, point.Route, font, solidBrush2, point.X1 + (point.X2 - point.X1 - g.MeasureString(point.Route, font).Width) / 2, point.Y);
                            //        //    }
                            //        //}
                            //        break;
                            //}
                            #endregion

                        }
                        break;
                }
            }
            return -1;
        }


        /// <summary>
        /// ��ȡͼ������
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private Rectangle GetLegendRect(Graphics graphics, int index)
        {
            Graphics g;
            if (graphics == null) g = CreateGraphics(); else g = graphics;
            Rectangle rect = OriginRect;
            Font font = LegendFont;
            int width = (int)(g.MeasureString("A", font).Height) - 2;
            if (width < 3) width = 3;
            int leftoff = string.IsNullOrEmpty(_title) ? 0 : (int)_titleWidth;
            return new Rectangle(rect.X + 5 + leftoff, (int)(rect.Top + index * (_lineHeight + 1) + _topOffSet) + 2, width, width);
        }

        /// <summary>
        /// ��ͼ��
        /// </summary>
        /// <param name="g"></param>
        /// <param name="index"></param>
        private void DrawLegend(Graphics g, int index)
        {
            MedDrugCurve curve = _curves[index];
            Rectangle rect = OriginRect;
            Font font = LegendFont;
            Color textColor = _isSingleColor ? _singleTextColor : curve.Color;
            curve.Y1 = rect.Top + index * (_lineHeight + 1) + _topOffSet + 1;
            curve.Y2 = curve.Y1 + g.MeasureString("A", font).Height;
            SolidBrush textColorBrush = new SolidBrush(textColor);
            if (_hasLegendSymbol)
            {
                using (SolidBrush solidBrush = new SolidBrush(GetCurveColor(curve)))
                {
                    g.FillRectangle(new SolidBrush(GetCurveColor(curve)), GetLegendRect(g, index));
                }
                float leftoff = string.IsNullOrEmpty(_title) ? 0f : _titleWidth;
                string text = ShowHelper.GetDrugNameShowText(curve, NameMarkFormat, DrugNameShowFormatType);
                g.DrawString(text, font, textColorBrush, rect.X + 7 + g.MeasureString("A", font).Height + (int)leftoff, rect.Top + index * (_lineHeight + 1) + _topOffSet + 1);
            }
            else
            {
                float leftoff = string.IsNullOrEmpty(_title) ? 0f : _titleWidth;
                string text = ShowHelper.GetDrugNameShowText(curve, NameMarkFormat, DrugNameShowFormatType);
                g.DrawString(text, font, textColorBrush, rect.X + 1 + leftoff, rect.Top + index * (_lineHeight + 1) + _topOffSet + 1);
            }
            textColorBrush.Dispose();
        }

        /// <summary>
        /// ��ȡ���ƺ͵�λ
        /// </summary>
        /// <param name="textUnitObject"></param>
        /// <returns></returns>
        public static string GetTextUnit(object textUnitObject)
        {
            string text = "";
            PropertyInfo propertyInfo = textUnitObject.GetType().GetProperty("Text");
            if (propertyInfo != null)
            {
                text = AllowNullToString(propertyInfo.GetValue(textUnitObject, null));
            }
            if (text == null)
            {
                text = "";
            }
            string unit = "";
            propertyInfo = textUnitObject.GetType().GetProperty("Unit");
            if (propertyInfo != null)
            {
                unit = AllowNullToString(propertyInfo.GetValue(textUnitObject, null));
            }
            if (!string.IsNullOrEmpty(unit))
            {
                text += "(" + unit + ")";
            }
            string text2 = "";
            propertyInfo = textUnitObject.GetType().GetProperty("Text2");
            if (propertyInfo != null)
            {
                text2 = AllowNullToString(propertyInfo.GetValue(textUnitObject, null));
            }
            if (!string.IsNullOrEmpty(text2))
            {
                text += "/" + text2;
                string unit2 = "";
                propertyInfo = textUnitObject.GetType().GetProperty("Unit2");
                if (propertyInfo != null)
                {
                    unit2 = AllowNullToString(propertyInfo.GetValue(textUnitObject, null));
                }
                if (!string.IsNullOrEmpty(unit2))
                {
                    text += "(" + unit2 + ")";
                }
            }
            return text;
        }

        /// <summary>
        /// ����ת�ַ���
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string AllowNullToString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="drawLeft"></param>
        /// <param name="drawEndX"></param>
        private void DrawLines(Graphics g, Pen pen, float drawLeft, float drawEndX)
        {
            Rectangle rect = OriginRect;
            float topOffSet = rect.Top + _topOffSet + _lineHeight;
            while (topOffSet < rect.Bottom - _lineHeight + 5)
            {
                g.DrawLine(pen, drawLeft, topOffSet, drawEndX, topOffSet);
                topOffSet += _lineHeight + 1;
            }
        }

        /// <summary>
        /// ��ȡ����ɫ
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        private Color GetCurveColor(MedDrugCurve curve)
        {
            return _isSingleColor ? _singleColor : curve.Color;
        }

        private double GetCurveTotal(MedDrugCurve curve)
        {
            //return curve.Totalvalue;
            double totalValue = 0;
            foreach (MedDrugPoint point in curve.Points)
            {
                if (point.Value is double && point.StartTime >= _startTime && point.StartTime < _endTime)
                {
                    totalValue += (double)point.Value;
                }
            }
            return totalValue;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="g"></param>
        /// <param name="index"></param>
        private void DrawTotal(Graphics g, int index)
        {
            MedDrugCurve curve = _curves[index];
            Rectangle rect;
            Font font;
            SolidBrush solidBrush = new SolidBrush(GetCurveColor(curve)); //new SolidBrush(curve.Color);
            switch (_totalType)
            {
                case TotalType.SummeryValue:
                    curve = _curves[index];
                    rect = OriginRect;
                    font = TotalFont;
                    //g.DrawString(GetCurveTotal(curve).ToString() + curve.Unit, font, solidBrush, rect.X + rect.Width * (1 - _rightWidthPercent) + 5, rect.Top + index * (_lineHeight + 1) + 5 + _topOffSet);
                    double totalValue = GetCurveTotal(curve);
                    if (totalValue > 0)
                    {
                        g.DrawString(totalValue.ToString(), font, solidBrush, rect.X + rect.Width * (1 - _rightWidthPercent), rect.Top + index * (_lineHeight + 1) + _topOffSet);
                    }
                    break;
                case TotalType.Unit:
                    curve = _curves[index];
                    rect = OriginRect;
                    font = TotalFont;
                    g.DrawString(curve.Unit, font, solidBrush, rect.X + rect.Width * (1 - _rightWidthPercent) + 5, rect.Top + index * (_lineHeight + 1) + 5 + _topOffSet);
                    break;
                case TotalType.Empty:
                    break;
            }
            solidBrush.Dispose();
        }

        /// <summary>
        /// ���ɲ�������
        /// </summary>
        public void Test()
        {
            _startTime = DateTime.Parse("08:00");
            _endTime = DateTime.Parse("12:00");
            _minScaleCount = 6;
            List<MedDrugCurve> curves = new List<MedDrugCurve>();
            MedDrugCurve curve = new MedDrugCurve("���򰲶�", Color.Blue);
            List<MedDrugPoint> points = new List<MedDrugPoint>();
            MedDrugPoint point = new MedDrugPoint();
            point.StartTime = DateTime.Parse("08:30");
            point.Value = 20;
            point.Unit = "ml";
            points.Add(point);
            curve.Points = points;
            curves.Add(curve);
            curve = new MedDrugCurve("���̫��", Color.Green);
            points = new List<MedDrugPoint>();
            point = new MedDrugPoint();
            point.PointType = PointType.ProLonged;
            point.StartTime = DateTime.Parse("10:21");
            point.EndTime = DateTime.Parse("11:00");
            point.Unit = "mg";
            point.Speed = 2;
            points.Add(point);
            point = new MedDrugPoint();
            point.PointType = PointType.ProLonged;
            point.StartTime = DateTime.Parse("09:07");
            point.EndTime = DateTime.Parse("09:43");
            point.Unit = "mg";
            point.ShowType = ProLongedShowType.Speed;
            point.Speed = 1;
            points.Add(point);
            curve.Points = points;
            curves.Add(curve);
            _curves = curves;
        }

        /// <summary>
        /// ��ȡĳλ�ö�Ӧ������
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="pt"></param>
        /// <returns>δ�ҵ�����-1</returns>
        private int MeasurePoints(MedDrugCurve curve, Point pt)
        {
            for (int i = 0; i < curve.Points.Count; i++)
            {
                MedDrugPoint point = curve.Points[i];
                if (curve.Y1 <= pt.Y && curve.Y2 >= pt.Y && pt.X / _scaleRate >= point.X1 && pt.X / _scaleRate <= point.X2)
                {
                    return i;
                }
                switch (point.PointType)
                {
                    case PointType.SinglePoint:
                        if (Math.Abs(pt.X / _scaleRate - point.X1) < 5 && Math.Abs(pt.Y / _scaleRate - point.Y) < 5)
                        {
                            return i;
                        }
                        break;
                    //case PointType.ProLonged:
                    //    if (Math.Abs(pt.Y / _scaleRate - point.Y) < 5 && pt.X / _scaleRate >= point.X1 && pt.X / _scaleRate <= point.X2)
                    //    {
                    //        return i;
                    //    }
                    //    break;
                }
            }
            return -1;
        }

        /// <summary>
        /// �Ƿ�ĳλ����ָ����
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        private bool MeasurePointY(MedDrugCurve curve, Point pt)
        {
            if (curve.Y1 <= pt.Y && curve.Y2 >= pt.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
            //for (int i = 0; i < curve.Points.Count; i++)
            //{
            //    MedDrugPoint point = curve.Points[i];
            //    if (Math.Abs(pt.Y / _scaleRate - point.Y) < 5)
            //    {
            //        return i;
            //    }
            //}
            //return -1;
        }

        /// <summary>
        /// ��ȡ��ʾ�ı�
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
        /// ��������ʾ
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        private string GetCurveTip(MedDrugCurve curve)
        {
            if (!string.IsNullOrEmpty(curve.DisplayText2) && !string.IsNullOrEmpty(curve.DisplayText) && !string.IsNullOrEmpty(curve.DisplayUnit)
                && !string.IsNullOrEmpty(curve.DisplayUnit2))
            {
                return curve.DisplayText + "(" + curve.DisplayUnit + ")/" + curve.DisplayText2 + "(" + curve.DisplayUnit2 + ")";
            }
            else
            {
                return AssemblyHelper.GetTextUnit(curve);
            }
        }

        /// <summary>
        /// �������λ��
        /// </summary>
        /// <param name="mousePoint"></param>
        public void SetMousePosition(Point mousePoint)
        {
            _selectLineIndex = -1;
            //_mouseTime = DateTime.MinValue;
            if (_lockMouse)
            {
                return;
            }
            RectangleF rect = GetMainRect();
            rect.X = rect.X * _scaleRate;
            rect.Y = rect.Y * _scaleRate;
            rect.Width = rect.Width * _scaleRate;
            rect.Height = rect.Height * _scaleRate;

            _MedDrugPointAtMousePos = null;
            _CurvesAndTimeAtMousePos = "";

            if (_curves != null)//&& rect.Contains(e.X, e.Y))
            {
                for (int i = 0; i < _curves.Count; i++)
                {
                    if (rect.Contains(mousePoint.X, mousePoint.Y))
                    {
                        int index = MeasurePoints(_curves[i], new Point(mousePoint.X, mousePoint.Y));//MeasurePoints(null, i, new Point(e.X, e.Y));
                        if (index > -1)
                        {
                            MedDrugPoint point = _curves[i].Points[index];
                            _MedDrugPointAtMousePos = point;
                            string su = "";
                            if (point.ThickNess > 0)
                            {
                                su = "Ũ�ȣ�" + point.ThickNess.ToString() + point.ThickNessUnit;
                            }
                            else
                            {
                                su = "���٣�" + point.Speed.ToString() + point.SpeedUnit;
                            }
                            if (point.ThickNess > 0 && point.Speed > 0)
                            {
                                su = "���٣�" + point.Speed.ToString() + point.SpeedUnit + "\r\n" + "Ũ�ȣ�" + point.ThickNess.ToString() + point.ThickNessUnit;
                            }
                            string valueString = "";
                            if (point.Value != null)
                            {
                                valueString = point.Value.ToString() + point.Unit;
                            }
                            if (!string.IsNullOrEmpty(_curves[i].Text2))
                            {
                                valueString += "/" + point.Value2.ToString();
                            }

                            string tooltip = GetCurveTip(_curves[i]) + "\r\n==============\r\n" +
                                ("��ʼʱ�䣺" + point.StartTime.ToString("HH:mm") + "\r\n����ʱ�䣺" + point.EndTime.ToString("HH:mm") + "\r\n" + su + "\r\n������" + valueString);
                            if (_itemDescs != null && _itemDescs.ContainsKey(_curves[i].Text))
                            {
                                tooltip += "\r\n\r\nҩƷ˵��:\r\n" + _itemDescs[_curves[i].Text];
                            }
                            TimeSpan spTotal = _endTime - _startTime;
                            DateTime dt = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal.TotalSeconds));
                            ModMinute(ref dt);

                            tooltip += "\r\n�������ʱ�䣺" + dt.ToString("yyyy-MM-dd HH:mm");
                            _doubleMouseRowIndex = i;
                            if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                            {
                                _mouseTime = dt;
                                toolTip1.SetToolTip(this, tooltip);
                                _selectLineIndex = i;
                                _oldMousePos.X = mousePoint.X;
                                _oldMousePos.Y = mousePoint.Y;
                            }

                            _CurvesAndTimeAtMousePos = AssemblyHelper.GetTextUnit(_curves[i]) + "#" + dt.ToString("yyyy-MM-dd HH:mm");
                            return;
                        }
                        else
                        {
                            if (MeasurePointY(_curves[i], mousePoint))
                            {
                                TimeSpan spTotal = _endTime - _startTime;
                                DateTime dt = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal.TotalSeconds));
                                ModMinute(ref dt);

                                string tooltip = GetCurveTip(_curves[i]) + " " + dt.ToString("yyyy-MM-dd HH:mm"); //AssemblyHelper.GetTextUnit(_curves[i]) + " " + dt.ToString("yyyy-MM-dd HH:mm");
                                _doubleMouseRowIndex = i;
                                if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                                {
                                    _mouseTime = dt;
                                    toolTip1.SetToolTip(this, tooltip);
                                    _selectLineIndex = i;
                                    _oldMousePos.X = mousePoint.X;
                                    _oldMousePos.Y = mousePoint.Y;
                                }

                                _CurvesAndTimeAtMousePos = AssemblyHelper.GetTextUnit(_curves[i]) + "#" + dt.ToString("yyyy-MM-dd HH:mm");
                                return;
                            }
                        }
                    }
                    else if (mousePoint.X < rect.X && mousePoint.Y >= rect.Top && mousePoint.Y <= rect.Bottom)
                    {
                        if (MeasurePointY(_curves[i], mousePoint))
                        {
                            TimeSpan spTotal = _endTime - _startTime;
                            DateTime dt = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal.TotalSeconds));
                            ModMinute(ref dt);
                            string tooltip = GetCurveTip(_curves[i]); //AssemblyHelper.GetTextUnit(_curves[i]);// +" " + dt.ToString("yyyy-MM-dd HH:mm");
                            _doubleMouseRowIndex = i;
                            if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                            {
                                _mouseTime = dt;
                                toolTip1.SetToolTip(this, tooltip);
                                _selectLineIndex = i;
                                _oldMousePos.X = mousePoint.X;
                                _oldMousePos.Y = mousePoint.Y;
                            }
                            _CurvesAndTimeAtMousePos = AssemblyHelper.GetTextUnit(_curves[i]) + "#";
                            return;
                        }
                    }
                }
            }
            TimeSpan spTotal1 = _endTime - _startTime;
            DateTime dt1 = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal1.TotalSeconds));
            ModMinute(ref dt1);
            if (dt1 >= _startTime && dt1 <= _endTime)
            {
                if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                {
                    toolTip1.SetToolTip(this, dt1.ToString("yyyy-MM-dd HH:mm"));
                    _mouseTime = dt1;
                    _oldMousePos.X = mousePoint.X;
                    _oldMousePos.Y = mousePoint.Y;
                }
            }
            else
            {
                if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                {
                    _mouseTime = DateTime.MinValue;
                    toolTip1.SetToolTip(this, "");
                    _oldMousePos.X = mousePoint.X;
                    _oldMousePos.Y = mousePoint.Y;
                }
            }
        }

        /// <summary>
        /// �Ƿ�ָ��������������
        /// </summary>
        /// <param name="dateTime"></param>
        private void ModMinute(ref DateTime dateTime)
        {
            ModMinute(ref dateTime, _modNumber);
        }

        /// <summary>
        /// �Ƿ�ָ��������������
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="modNumber"></param>
        public static void ModMinute(ref DateTime dateTime, int modNumber)
        {
            if (modNumber < 0)
            {
                return;
            }
            int mu = dateTime.Minute % modNumber;
            if (mu == 0) return;
            if (mu * 2 >= modNumber) mu -= modNumber;
            dateTime = dateTime.AddMinutes(-mu);
        }

        /// <summary>
        /// �������˫��
        /// </summary>
        /// <param name="mousePoint"></param>
        public void SetMouseDoubleClick(Point mousePoint)
        {
            _doubleMouseRowIndex = -1;
            AnesBandEventHandle eventHandle = (AnesBandEventHandle)Events[_customEditEventHandle];
            //if (eventHandle != null)
            {
                RectangleF rect = GetMainRect();
                rect.X = rect.X * _scaleRate;
                rect.Y = rect.Y * _scaleRate;
                rect.Width = rect.Width * _scaleRate;
                rect.Height = rect.Height * _scaleRate;
                if (_hasBeiYongYao)
                {
                    RectangleF rectF = new RectangleF(rect.Right + 1, rect.Top + 1 + _topOffSet, OriginRect.Right - rect.Right - 2, OriginRect.Height - _topOffSet - 2);
                    if (rectF.Contains(mousePoint.X, mousePoint.Y))
                    {
                        if (eventHandle != null)
                        {
                            eventHandle(this, "beiyongyao", null);
                        }
                        return;
                    }
                }
                if (_curves != null && rect.Contains(mousePoint.X, mousePoint.Y))
                {
                    for (int i = 0; i < _curves.Count; i++)
                    {
                        int index = MeasurePoints(_curves[i], new Point(mousePoint.X, mousePoint.Y));//MeasurePoints(null, i, new Point(e.X, e.Y));
                        if (index > -1)
                        {
                            MedDrugPoint point = _curves[i].Points[index];
                            point.Curve = _curves[i];
                            TimeSpan spTotal = _endTime - _startTime;
                            DateTime dt = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal.TotalSeconds));
                            ModMinute(ref dt);
                            _currentTime = dt;
                            _doubleMouseRowIndex = i;
                            if (eventHandle != null)
                            {
                                eventHandle(this, point, null);
                            }
                            return;
                        }
                        else
                        {
                            if (MeasurePointY(_curves[i], mousePoint))
                            {
                                TimeSpan spTotal = _endTime - _startTime;
                                DateTime dt = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal.TotalSeconds));
                                ModMinute(ref dt);
                                _currentTime = dt;
                                _doubleMouseRowIndex = i;
                                if (eventHandle != null)
                                {
                                    eventHandle(this, _curves[i].Text, null);
                                }
                                return;
                            }
                            else
                            {
                            }
                        }
                    }
                }
                TimeSpan spTotal1 = _endTime - _startTime;
                DateTime dt1 = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal1.TotalSeconds));
                ModMinute(ref dt1);
                _currentTime = dt1;
                for (int i = 0; i < _curves.Count; i++)
                {
                    if (MeasurePointY(_curves[i], mousePoint))
                    {
                        _doubleMouseRowIndex = i;
                    }
                }
                if (eventHandle != null)
                {
                    eventHandle(this, dt1, null);
                }
                return;
                //eventHandle(this, null, null);
            }
        }

        /// <summary>
        /// ������갴��
        /// </summary>
        /// <param name="mousePoint"></param>
        public void SetMouseDown(Point mousePoint)
        {
            _selectPoint = null;
            RectangleF rect = GetMainRect();
            rect.X = rect.X * _scaleRate;
            rect.Y = rect.Y * _scaleRate;
            rect.Width = rect.Width * _scaleRate;
            rect.Height = rect.Height * _scaleRate;
            if (_hasBeiYongYao)
            {
                RectangleF rectF = new RectangleF(rect.Right + 1, rect.Top + 1 + _topOffSet, OriginRect.Right - rect.Right - 2, OriginRect.Height - _topOffSet - 2);
                if (rectF.Contains(mousePoint.X, mousePoint.Y))
                {
                    AnesBandEventHandle eventHandle = (AnesBandEventHandle)Events[_customEditEventHandle];
                    if (eventHandle != null)
                    {
                        eventHandle(this, "beiyongyao", null);
                        return;
                    }
                }
            }
            if (_curves != null && rect.Contains(mousePoint.X, mousePoint.Y))
            {
                for (int i = 0; i < _curves.Count; i++)
                {
                    int index = MeasurePoints(_curves[i], new Point(mousePoint.X, mousePoint.Y));//MeasurePoints(null, i, new Point(mousePoint.X, mousePoint.Y));
                    if (index > -1)
                    {
                        MedDrugPoint point = _curves[i].Points[index];
                        point.Curve = _curves[i];
                        _selectPoint = point;
                    }
                }
            }
            //if (_popupMenu != null && e.Button == MouseButtons.Right)
            //{
            //    if (_curves != null && rect.Contains(mousePoint.X, mousePoint.Y))
            //    {
            //        for (int i = 0; i < _curves.Count; i++)
            //        {
            //            int index = MeasurePoints(_curves[i], new Point(mousePoint.X, mousePoint.Y));//MeasurePoints(null, i, new Point(mousePoint.X, mousePoint.Y));
            //            if (index > -1)
            //            {
            //                MedDrugPoint point = _curves[i].Points[index];
            //                point.Curve = _curves[i];
            //                _selectPoint = point;
            //                TimeSpan spTotal1 = _endTime - _startTime;
            //                DateTime dt1 = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal1.TotalSeconds));
            //                ModMinute(ref dt1);
            //                _currentTime = dt1;
            //                _popupMenu.Show(this, mousePoint.X, mousePoint.Y);
            //                return;
            //            }
            //        }
            //    }
            //}

            if (_selectLineIndex > -1)
            {
                AnesBandEventHandle eventHandle = (AnesBandEventHandle)Events[_customEditEventHandle];
                if (eventHandle != null)
                {
                    eventHandle(this, _selectLineIndex, null);
                    return;
                }
            }
        }

        #endregion ����

        #region �¼�

        /// <summary>
        /// ��С�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedDrugCurve_Resize(object sender, EventArgs e)
        {
            //Invalidate();
        }

        /// <summary>
        /// ����Ƶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedDrugGraph_MouseMove(object sender, MouseEventArgs e)
        {
            SetMousePosition(e.Location);
        }

        /// <summary>
        /// ���˫��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedDrugGraph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetMouseDoubleClick(e.Location);
        }

        /// <summary>
        /// ��갴��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedDrugGraph_MouseDown(object sender, MouseEventArgs e)
        {
            SetMouseDown(e.Location);
        }

        /// <summary>
        /// ����ɿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedDrugGraph_MouseUp(object sender, MouseEventArgs e)
        {
            _selectPoint = null;
        }

        #endregion �¼�
    }
}
