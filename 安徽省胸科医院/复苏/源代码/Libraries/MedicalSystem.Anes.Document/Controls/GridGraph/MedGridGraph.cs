/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedGridGraph.cs
      // �ļ������������¼��������ؼ�
      //
      // 
      // ������ʶ��������-2008-10-22
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Controls
{

    /// <summary>
    /// �¼��������ؼ�
    /// </summary>
    [Serializable, ToolboxItem(false), Description("��Һ���")]
    public partial class MedGridGraph : AnesGraph, IPrintable
    {

        #region ���췽��

        public MedGridGraph()
        {
            InitializeComponent();
            TimeText = null;
            //TotalText = null;
            if (DesignMode) Test();
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// ��������ɫ
        /// </summary>
        private Color _gridColor = Color.Red;
        /// <summary>
        /// ��������ɫ
        /// </summary>
        private Color _rowGridColor = Color.Red;

        private bool _rowColorEqualColumColor = true;

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
        private int _minScaleCount = 2;

        /// <summary>
        /// С�̶�����ɫ
        /// </summary>
        private Color _middleLineColor = Color.FromArgb(255, 200, 200);

        /// <summary>
        /// С�̶��߿��
        /// </summary>
        private int _minScaleWidth = 1;

        /// <summary>
        /// С�̶�����ʽ
        /// </summary>
        private DashStyle _minDashStyle = DashStyle.Solid;

        /// <summary>
        /// �м���
        /// </summary>
        private List<MedGridGraphRow> _rows = new List<MedGridGraphRow>();

        /// <summary>
        /// ���浥Ԫ����
        /// </summary>
        private List<MedGridGraphSavedCell> _savedCells;

        /// <summary>
        /// �����������
        /// </summary>
        private MedGridType _gridType = MedGridType.Index;

        /// <summary>
        /// �ϴ����λ��
        /// </summary>
        private Point _oldMousePos = new Point(-1000, -1000);

        #endregion ����

        #region ����


        /// <summary>
        /// ע������
        /// </summary>
        private Font _commentFont = new Font("����", 6);

        [DisplayName("˵���ı�����")]
        public Font CommentFont
        {
            get
            {
                return _commentFont;
            }
            set
            {
                _commentFont = value;
            }
        }

        private Color _commentColor = Color.Black;
        [DisplayName("˵���ı���ɫ")]
        public Color CommentColor
        {
            get
            {
                return _commentColor;
            }
            set
            {
                _commentColor = value;
            }
        }




        private float _xTitleOffSet = 0;
        [DisplayName("����ˮƽλ��")]
        public float XTitleOffSet
        {
            get
            {
                return _xTitleOffSet;
            }
            set
            {
                _xTitleOffSet = value;
            }
        }

        /// <summary>
        /// �Ƿ��Զ�����
        /// </summary>
        private bool _autoDigit = false;
        public bool AutoDigit
        {
            get
            {
                return _autoDigit;
            }
            set
            {
                _autoDigit = value;
            }
        }

        private bool _isLineStartWithDigit = false;
        [DisplayName("�������ֿ�ͷ")]
        public bool IsLineStartWithDigit
        {
            get
            {
                return _isLineStartWithDigit;
            }
            set
            {
                _isLineStartWithDigit = value;
            }
        }

        private Color _printColor = Color.DarkGray;
        [DisplayName("�������ߴ�ӡ��ɫ")]
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
        private Color _rowprintColor = Color.DarkGray;
        [DisplayName("������ߴ�ӡ��ɫ")]
        public Color RowPringColor
        {
            get
            {
                return _rowprintColor;
            }
            set
            {
                _rowprintColor = value;
            }
        }
        /// <summary>
        /// �Ƿ����ڴ�ӡ
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

        /// <summary>
        /// �Ƿ���ʾ��Ѫ��Һ��ϸ
        /// </summary>
        private bool _isLiquidDetail = false;
        public bool IsLiquidDetail
        {
            get
            {
                return _isLiquidDetail;
            }
            set
            {
                _isLiquidDetail = value;
            }
        }

        /// <summary>
        /// �߿���ɫ
        /// </summary>
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


        [DisplayName("����������ɫ")]
        public Color GridColor
        {
            get
            {
                if (_isPrinting)
                {
                    return _printColor;
                }
                else
                {
                    return _gridColor;
                }
            }
            set
            {
                _gridColor = value;
            }
        }


        [DisplayName("���������ɫ")]
        public Color RowGridColor
        {
            get
            {
                if (_isPrinting)
                {
                    if (_rowColorEqualColumColor)
                        return _printColor;
                    else
                        return _rowprintColor;
                }
                else
                {
                    if (_rowColorEqualColumColor)
                        return _gridColor;
                    else
                        return _rowGridColor;
                }
            }
            set
            {
                _rowGridColor = value;
            }
        }


        [DisplayName("���������ɫ������������ɫ��ͬ")]
        public bool RowColorEqualColumColor
        {
            get
            {
                return _rowColorEqualColumColor;
            }
            set
            {
                _rowColorEqualColumColor = value;
            }
        }

        /// <summary>
        /// �����߿��
        /// </summary>
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
        public int MinScaleWidth
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

        /// <summary>
        /// ������
        /// </summary>
        public List<MedGridGraphRow> Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public MedGridType GridType
        {
            get
            {
                return _gridType;
            }
            set
            {
                _gridType = value;
            }
        }

        private Color _singleTextColor = Color.Blue;
        [Description("��һ�ı���ɫ")]
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

        private Color _singleTitleColor = Color.Blue;
        [Description("��һ������ɫ")]
        public Color SingleTitleColor
        {
            get
            {
                return _singleTitleColor;
            }
            set
            {
                _singleTitleColor = value;
            }
        }

        private bool _hasDrug = true;
        [Description("�Ƿ���ʾ��ҩ")]
        public bool HasDrug
        {
            get
            {
                return _hasDrug;
            }
            set
            {
                _hasDrug = value;
            }
        }

        private bool _hasLiquid = true;
        [Description("�Ƿ���ʾ��Ѫ��Һ")]
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

        private int _minRowCount = 6;
        [Description("��С����")]
        public int MinRowCount
        {
            get
            {
                return _minRowCount;
            }
            set
            {
                _minRowCount = value;
            }
        }

        private int _maxRowCount = 6;
        [Description("�������")]
        public int MaxRowCount
        {
            get
            {
                return _maxRowCount;
            }
            set
            {
                _maxRowCount = value;
            }
        }

        private List<GridRowAliasName> _rowSettings = new List<GridRowAliasName>();
        [Category("����-�Զ���"), DisplayName("�в�������")]
        public List<GridRowAliasName> RowSettings
        {
            get
            {
                return _rowSettings;
            }
            set
            {
                _rowSettings = value;
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

        private bool _isNoGrid = false;
        [Description("�������")]
        public bool IsNoGrid
        {
            get
            {
                return _isNoGrid;
            }
            set
            {
                _isNoGrid = value;
            }
        }

        private bool _isNoKuoHao = false;
        [Description("��������")]
        public bool IsNoKuoHao
        {
            get
            {
                return _isNoKuoHao;
            }
            set
            {
                _isNoKuoHao = value;
            }
        }
        private bool _isDrawTotalLine = false;
        [Category("����-�Զ���"), DisplayName("�Ƿ����������쵽�ܼƴ�")]
        public bool ISDrawTotalLine
        {
            get
            {
                return _isDrawTotalLine;
            }
            set
            {
                _isDrawTotalLine = value;
            }
        }

        /// <summary>
        /// ѡ�еĵ�
        /// </summary>
        private MedGridPoint _selectPoint = null;
        [Browsable(false)]
        public MedGridPoint SelectedPoint
        {
            get
            {
                return _selectPoint;
            }
        }

        /// <summary>
        /// �������λ�ö���ʱ��
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
        /// �������λ�ö�Ӧ��
        /// </summary>
        private int _mouseRowIndex = -1;
        [Browsable(false)]
        public int MouseRowIndex
        {
            get
            {
                return _mouseRowIndex;
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
        /// �ͻ������¼�
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
        /// ���ݱ��ⷵ����
        /// </summary>
        /// <param name="rowString"></param>
        /// <returns>���û�ҵ����ؿգ����򷵻ظ���</returns>
        public MedGridGraphRow GetRow(string rowString)
        {
            foreach (MedGridGraphRow row in _rows)
            {
                if (row.Text.Equals(rowString))
                {
                    return row;
                }
            }
            return null;
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
            //DateTime dt = new DateTime(_startTime.Year, _startTime.Month, _startTime.Day, _startTime.Hour + 1, 0, 0);
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
        /// ���ܱ��ؼ����¼��������ؼ���
        /// </summary>
        /// <param name="graphics"></param>
        public override void DrawGraphics(Graphics graphics)
        {
            _zoomRate = (float)(1 / _showZoomRate);

            Graphics g = graphics;

            base.DrawGraphics(g);
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

            if (_rows != null && _rows.Count > 0)
            {
                DrawRows(g);
            }
            if (!string.IsNullOrEmpty(TotalText))
            {
                RectangleF rectF = GetMainRect();
                Rectangle rect = OriginRect;
                g.DrawString(TotalText, _rowTitleFont, Brushes.Black, rectF.Right + (OriginRect.Right - rectF.Right - g.MeasureString(TotalText, _rowTitleFont).Width) / 2
                    , rectF.Top + 2);
            }
            DrawTitle(g, OriginRect.X, OriginRect.Y, OriginRect);
            PaintEventHandler eventHandle = Events[_customDraw] as PaintEventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, new PaintEventArgs(g, ClientRectangle));
            }
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
                using (Pen pen = new Pen(_borderColor))
                {
                    g.DrawLine(pen, x - 2, y + _topOffSet, x - 2, rect.Bottom);
                }
                // g.DrawLine(Pens.Red, x - 2, y + _topOffSet, x - 2, rect.Bottom);
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
            using (Pen pen = new Pen(GridColor))//, _gridLineWidth))
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
        /// ��������
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
            using (Pen pen = new Pen(color))//, _minScaleWidth))
            {
                pen.DashStyle = _minDashStyle;
                for (int i = 1; i < _minScaleCount; i++)
                {
                    if (rectF.X + minGridWidth * i - rectF.Width > OriginRect.Right - 1) break;
                    g.DrawLine(pen, rectF.X + minGridWidth * i - rectF.Width, rectF.Top, rectF.X + minGridWidth * i - rectF.Width, rectF.Bottom);
                }
            }
        }

        /// <summary>
        /// �б�������
        /// </summary>
        private Font _rowTitleFont = new Font("����", 9);
        public Font RowTitleFont
        {
            get
            {
                return _rowTitleFont;
            }
            set
            {
                _rowTitleFont = value;
            }
        }

        /// <summary>
        /// �з�����
        /// </summary>
        private float _groupWidth = 0;
        public float GroupWidth
        {
            get
            {
                return _groupWidth;
            }
            set
            {
                _groupWidth = value;
            }
        }

        /// <summary>
        /// �����ߣ������ֿ�ͷ��
        /// </summary>
        /// <param name="g"></param>
        /// <param name="point"></param>
        /// <param name="rowIndex"></param>
        /// <param name="rowHeight"></param>
        private void DrawPointLineStartWithDigit(Graphics g, MedGridPoint point, int rowIndex, float rowHeight)
        {
            if (point.EndTime > DateTime.MinValue && point.Time < _endTime && point.EndTime > _startTime) // && point.Time >= _startTime && point.Time <= _endTime
            //&& point.EndTime >= _startTime && point.EndTime <= _endTime && point.EndTime > point.Time
            {
                DateTime startTime = point.Time;
                DateTime endTime = point.EndTime;
                if (startTime < _startTime)
                {
                    startTime = _startTime;
                }
                if (endTime > _endTime)
                {
                    endTime = _endTime;
                }
                if (startTime >= endTime)
                {
                    return;
                }
                Color textColor = _singleTextColor;
                string value = point.Value.ToString();
                if (point.Speed > 0 && point.ThickNess > 0)
                {
                    value = point.Speed.ToString() + "(" + point.ThickNess.ToString() + ")";
                }
                else if (point.Speed > 0)
                {
                    value = point.Speed.ToString();
                }
                else if (point.ThickNess > 0)
                {
                    value = point.ThickNess.ToString();
                }

                float y = rowHeight * rowIndex + rowHeight / 2;
                TimeSpan spThis = startTime - _startTime;
                TimeSpan spTotal = _endTime - _startTime;
                RectangleF rect1 = GetMainRect();

                float X1 = (float)(rect1.X + rect1.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));

                spThis = endTime - _startTime;
                float X2 = (float)(rect1.X + rect1.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                point.X1 = X1;
                point.X2 = X2;
                point.Y = y;

                float X3 = X1 + g.MeasureString(value, _rowTitleFont).Width + 4;
                if (X3 < rect1.Left)
                {
                    X3 = rect1.Left;
                }
                else
                {
                    using (SolidBrush solidBrush = new SolidBrush(textColor))
                    {
                        g.DrawString(value, _rowTitleFont, solidBrush, new RectangleF(X1 + 2, y - g.MeasureString("A", _rowTitleFont).Height / 2, X2 - X1, g.MeasureString("A", _rowTitleFont).Height));
                    }

                }
                if (X3 < X2)
                {
                    if (X2 > rect1.Right)
                    {
                        X2 = rect1.Right;
                    }
                    using (Pen pen = new Pen(textColor))
                    {
                        g.DrawLine(pen, X3, y, X2, y);
                    }

                }
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="g"></param>
        /// <param name="point"></param>
        /// <param name="rowIndex"></param>
        /// <param name="rowHeight"></param>
        private void DrawPointLine(Graphics g, MedGridPoint point, int rowIndex, float rowHeight)
        {
            if (_isLineStartWithDigit)
            {
                DrawPointLineStartWithDigit(g, point, rowIndex, rowHeight);
                return;
            }
            if (point.EndTime > DateTime.MinValue)
            {
                Color textColor = _singleTextColor;
                string value = point.Value.ToString()+point.Unit.ToString();
                if (point.Speed > 0 && point.ThickNess > 0)
                {
                    value = point.Speed.ToString() + "(" + point.ThickNess.ToString() + ")";
                }
                else if (point.Speed > 0)
                {
                    value = point.Speed.ToString();
                }
                else if (point.ThickNess > 0)
                {
                    value = point.ThickNess.ToString();
                }
                float tagHeight = 5;
                float y = rowHeight * rowIndex + rowHeight / 2 + _topOffSet;
                TimeSpan spThis = point.Time - _startTime;
                TimeSpan spTotal = _endTime - _startTime;
                RectangleF rect1 = GetMainRect();

                float X1 = (float)(rect1.X + rect1.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));

                spThis = point.EndTime - _startTime;
                float X2 = (float)(rect1.X + rect1.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                point.X1 = X1;
                point.X2 = X2;
                point.Y = y;

                float X3 = X1;
                float X4 = (X1 + X2 - g.MeasureString(value, _rowTitleFont).Width) / 2;
                if (X4 > rect1.Left && X3 < rect1.Right)
                {
                    if (X3 < rect1.Left)
                    {
                        X3 = rect1.Left;
                    }
                    else
                    {
                        using (Pen pen1 = new Pen(textColor, 1))
                        {
                            g.DrawLine(pen1, X1, y - tagHeight, X1, y + tagHeight);
                        }

                    }
                    if (X4 > rect1.Right)
                    {
                        X4 = rect1.Right;
                    }
                    using (Pen pen2 = new Pen(textColor, 1))
                    {
                        g.DrawLine(pen2, X4, y, X3, y);
                    }

                }
                X3 = (X1 + X2 + g.MeasureString(value, _rowTitleFont).Width) / 2;
                X4 = X2;
                if (X4 > rect1.Left && X3 < rect1.Right)
                {
                    if (X3 < rect1.Left)
                    {
                        X3 = rect1.Left;
                    }
                    if (X4 > rect1.Right)
                    {
                        X4 = rect1.Right;
                    }
                    else
                    {
                        //g.DrawLine(new Pen(textColor, 1), X2, y - tagHeight, X2, y + tagHeight);
                        using (Pen pen3 = new Pen(textColor, 1))
                        {
                            if (point.IsArrow)
                            {
                                g.DrawLine(pen3, X2 - 5, y + tagHeight, X2, y);
                                g.DrawLine(pen3, X2 - 5, y - tagHeight, X2, y);
                            }
                            else
                            {
                                g.DrawLine(pen3, X2, y - tagHeight, X2, y + tagHeight);
                            }
                        }

                    }
                    using (Pen pen4 = new Pen(textColor, 1))
                    {
                        g.DrawLine(pen4, X4, y, X3, y);
                    }

                }
                X3 = (X1 + X2 - g.MeasureString(value, _rowTitleFont).Width) / 2;
                X4 = (X1 + X2 + g.MeasureString(value, _rowTitleFont).Width) / 2;
                if (X4 > rect1.Left && X3 < rect1.Right)
                {
                    StringFormat sf = new StringFormat();
                    if (X3 < rect1.Left)
                    {
                        X3 = rect1.Left;
                        sf.Alignment = StringAlignment.Far;
                    }
                    else if (X4 > rect1.Right)
                    {
                        X4 = rect1.Right + 2;
                    }
                    using (SolidBrush solidBrush1 = new SolidBrush(textColor))
                    {
                        g.DrawString(value, _rowTitleFont, solidBrush1, new RectangleF(X3, y - g.MeasureString("A", _rowTitleFont).Height / 2, X4 - X3
                            , g.MeasureString("A", _rowTitleFont).Height));
                    }

                }
            }
        }

        /// <summary>
        /// ��ȡ�б���
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetRowTitle(MedGridGraphRow row)
        {
            string text = row.Text;
            if (!string.IsNullOrEmpty(row.RowFix))
            {
                return text + row.RowFix;
            }
            if (_isNoKuoHao && text.Contains("(") && text.Contains(")"))
            {
                int index = text.IndexOf("(");
                int index1 = text.IndexOf(")");
                if (index1 > index)
                {
                    text = text.Substring(0, index) + text.Substring(index1 + 1);
                }
            }
            if (!string.IsNullOrEmpty(row.Unit))
            {
                text += "(" + row.Unit + ")";
            }
            else if (!string.IsNullOrEmpty(row.SpeedUnit) && !string.IsNullOrEmpty(row.ThickNessUnit))
            {
                text += "(" + row.SpeedUnit + @"/" + row.ThickNessUnit + ")";
            }
            else if (!string.IsNullOrEmpty(row.SpeedUnit))
            {
                text += "(" + row.SpeedUnit + ")";
            }
            else if (!string.IsNullOrEmpty(row.ThickNessUnit))
            {
                text += "(" + row.ThickNessUnit + ")";
            }
            return text;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="g"></param>
        private void DrawRows(Graphics g)
        {
            _savedCells = new List<MedGridGraphSavedCell>();
            RectangleF rectF = GetMainRect();
            float rowHeight = (float)(rectF.Height - _topOffSet) / _rows.Count;
            Rectangle rect = OriginRect;
            MedGridGraphSavedCell savedCell;
            for (int i = 0; i < _rows.Count; i++)
            {
                Color textColor = _rows[i].Color;
                if (_gridType == MedGridType.Summery)
                {
                    textColor = _singleTitleColor;
                }
                ///�����ߺ��б���
                if (i > 0)
                {
                    using (Pen gridColor = new Pen(RowGridColor))
                    {

                        float leftoff = string.IsNullOrEmpty(_title) ? 0f : _titleWidth;
                        if (_isDrawTotalLine)
                        {
                            g.DrawLine(gridColor, rect.X + (int)leftoff, rectF.Y + i * rowHeight + _topOffSet, rectF.X, rectF.Y + i * rowHeight + _topOffSet);
                            g.DrawLine(gridColor, rectF.X, rectF.Y + i * rowHeight + _topOffSet, rect.Right, rectF.Y + i * rowHeight + _topOffSet);
                        }
                        else
                        {

                            g.DrawLine(gridColor, rect.X + (int)leftoff, rectF.Y + i * rowHeight + _topOffSet, rectF.X, rectF.Y + i * rowHeight + _topOffSet);
                            //g.DrawLine(new Pen(_borderColor), rect.X, rectF.Y + i * rowHeight + _topOffSet, rectF.X, rectF.Y + i * rowHeight + _topOffSet);
                            g.DrawLine(gridColor, rectF.X, rectF.Y + i * rowHeight + _topOffSet, rectF.Right, rectF.Y + i * rowHeight + _topOffSet);


                        }

                        //����
                        if (!string.IsNullOrEmpty(TotalText))
                        {
                            g.DrawLine(gridColor, rectF.Right, rectF.Y + i * rowHeight + _topOffSet, rect.Right, rectF.Y + i * rowHeight + _topOffSet);
                        }
                    }

                }
                using (SolidBrush textColorBrush = new SolidBrush(textColor))
                {
                    float leftoff = string.IsNullOrEmpty(_title) ? 0f : _titleWidth;
                    //if (!string.IsNullOrEmpty(_rows[i].Total))
                    //{
                    //    g.DrawString(_rows[i].Total, _rowTitleFont, textColorBrush, rectF.Right + 2, rectF.Y + i * rowHeight + _topOffSet + 2);
                    //}

                    string text = GetRowTitle(_rows[i]);
                    //if (_groupWidth > 0)
                    {
                        g.DrawString(text, _rowTitleFont, textColorBrush, _groupWidth + _xTitleOffSet + rect.X + (int)leftoff + 2 + _rows[i].XOffSet, rectF.Y + i * rowHeight + _topOffSet + (rowHeight - g.MeasureString("A", _rowTitleFont).Height) / 2);
                    }
                    //else
                    //{
                    //    g.DrawString(text, _rowTitleFont, textColorBrush, rect.X + (int)leftoff + _xTitleOffSet + _rows[i].XOffSet + (rectF.X - rect.X - (int)leftoff - g.MeasureString(_rows[i].Text, _rowTitleFont).Width) / 2, rectF.Y + i * rowHeight + _topOffSet + (rowHeight - g.MeasureString("A", _rowTitleFont).Height) / 2);
                    //}
                }


                float gridWidth = GetGridWidth();
                int minutes = GetGridMinutes();
                float oldX = -1;
                int startIndex = -1, endIndex = 0;
                float x = -1;
                string value = "";
                int startCount = 0;
                foreach (MedGridPoint point in _rows[i].Points)
                {
                    if (_rows[i].IsLine)
                    {
                        DrawPointLine(g, point, i, rowHeight);
                        continue;
                    }
                    TimeSpan spThis, spTotal;
                    if (point.Time < _startTime)
                    {
                        startCount++;
                        //endIndex++;
                        continue;
                        //spThis = _startTime - _startTime;
                    }
                    else
                    {
                        spThis = point.Time - _startTime;
                    }
                    spTotal = _endTime - _startTime;
                    int gridIndex = (int)(rectF.Width * (spThis.TotalSeconds / spTotal.TotalSeconds) / gridWidth);
                    x = rectF.X + gridIndex * gridWidth;

                    ///�Ұ��
                    if (gridIndex * minutes + minutes / 2 <= spThis.TotalMinutes) x += gridWidth / 2;

                    ///��֤�����ұ߽�
                    if (x >= rectF.Right)
                    {
                        //endIndex++;
                        continue;
                        //x = rectF.Right - gridWidth / 2;
                    }

                    //if (_gridType != MedGridType.Index)
                    //{
                    //    oldX = x;
                    //    value = point.Value.ToString();
                    //    savedCell = new MedGridGraphSavedCell(_rows[i], new RectangleF(oldX, rectF.Y + i * rowHeight + _topOffSet, gridWidth / 2, rowHeight), startIndex, endIndex, startCount);
                    //    g.DrawString(value, Font, new SolidBrush(_rows[i].Color), savedCell.Rect.X + (savedCell.Rect.Width - g.MeasureString(value, Font).Width) / 2, savedCell.Rect.Y + (savedCell.Rect.Height - g.MeasureString("A", Font).Height) / 2);
                    //    continue;
                    //}

                    ///�¸�
                    if (x > oldX)
                    {
                        ///������ĸ�
                        if (oldX >= 0 && startIndex >= 0)
                        {
                            savedCell = new MedGridGraphSavedCell(_rows[i], new RectangleF(oldX, rectF.Y + i * rowHeight + _topOffSet, gridWidth / 2, rowHeight), startIndex, endIndex, startCount);
                            _savedCells.Add(savedCell);
                            textColor = _rows[i].Color;
                            switch (_gridType)
                            {
                                case MedGridType.Index:
                                    value = startIndex.ToString();
                                    if (endIndex > startIndex) value += "-" + endIndex.ToString();
                                    break;
                                case MedGridType.Summery:
                                    if (_rows[i].IsDetail)
                                    {
                                        //value = "";
                                        //for (int ii = savedCell.StartIndex; ii <= savedCell.EndIndex; ii++)
                                        //{
                                        //    value += "+" + savedCell.Row.Points[ii - 1 + savedCell.StartCount].Value.ToString()
                                        //        + savedCell.Row.Points[ii - 1 + savedCell.StartCount].Text;
                                        //}
                                        //if (!string.IsNullOrEmpty(value))
                                        //{
                                        //    value = value.Substring(1);
                                        //}
                                    }
                                    else
                                    {
                                        double v = 0;
                                        int cn = 0;
                                        bool find = false;
                                        for (int ii = savedCell.StartIndex; ii <= savedCell.EndIndex; ii++)
                                        {
                                            if (!string.IsNullOrEmpty(savedCell.Row.Points[ii - 1 + savedCell.StartCount].StringValue))
                                            {
                                                find = true;
                                                value = savedCell.Row.Points[ii - 1 + savedCell.StartCount].StringValue;
                                                break;
                                            }
                                            v += savedCell.Row.Points[ii - 1 + savedCell.StartCount].Value;
                                            cn++;
                                        }
                                        if (_rows[i].IsAverage)
                                        {
                                            v = v / cn;
                                        }
                                        if (!find)
                                        {
                                            if (_rows[i].DotNumber >= 0)
                                            {
                                                value = double.Parse(v.ToString(string.Format("F{0}", _rows[i].DotNumber))).ToString();
                                            }
                                            else
                                            {
                                                value = v.ToString();
                                            }
                                        }
                                    }
                                    textColor = _singleTextColor;
                                    break;
                                default:
                                    value = "";
                                    break;
                            }
                            ///����ϸ
                            if (_rows[i].IsDetail)
                            {
                                float xx = 0;
                                Font font = _rowTitleFont;// new Font(_rowTitleFont.Name, Font.Size - .2f);
                                for (int ii = savedCell.StartIndex; ii <= savedCell.EndIndex; ii++)
                                {
                                    if (xx > 0)
                                    {
                                        using (SolidBrush brush = new SolidBrush(textColor))
                                        {
                                            g.DrawString("+", _rowTitleFont, brush, savedCell.Rect.X + xx, savedCell.Rect.Y + savedCell.Rect.Height / 2 - g.MeasureString("A", font).Height / 2);
                                        }

                                        xx += 10;
                                    }
                                    //string vvv = savedCell.Row.Points[ii - 1 + savedCell.StartCount].Value.ToString();
                                    //g.DrawString(vvv, font, new SolidBrush(textColor), savedCell.Rect.X + (savedCell.Rect.Width - g.MeasureString(vvv, font).Width) / 2 + xx, savedCell.Rect.Y + savedCell.Rect.Height / 2 - g.MeasureString("A", font).Height);
                                    string vvv;
                                    if (!string.IsNullOrEmpty(savedCell.Row.Points[ii - 1 + savedCell.StartCount].Alias))
                                    {
                                        vvv = savedCell.Row.Points[ii - 1 + savedCell.StartCount].Alias;
                                    }
                                    else
                                    {
                                        vvv = savedCell.Row.Points[ii - 1 + savedCell.StartCount].Text;
                                    }
                                    vvv = savedCell.Row.Points[ii - 1 + savedCell.StartCount].Value.ToString() + "(" + vvv + ")";
                                    using (SolidBrush textColorBrush1 = new SolidBrush(textColor))
                                    {
                                        g.DrawString(vvv, font, textColorBrush1, savedCell.Rect.X + xx, savedCell.Rect.Y + (savedCell.Rect.Height - g.MeasureString("A", font).Height) / 2);
                                    }
                                    xx += g.MeasureString(vvv, font).Width;
                                }
                            }
                            else
                            {
                                if (_rows[i].IsLine)
                                {
                                    if (point.EndTime > DateTime.MinValue)
                                    {
                                        spThis = point.Time - _startTime;
                                        spTotal = _endTime - _startTime;
                                        RectangleF rect1 = GetMainRect();
                                        float X1 = (float)(rect1.X + rect1.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                                        spThis = point.EndTime - _startTime;
                                        float X2 = (float)(rect1.X + rect1.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                                        float X3 = X1;
                                        float X4 = (X1 + X2 - g.MeasureString(value, _rowTitleFont).Width) / 2;
                                        if (X4 > rect1.Left && X3 < rect1.Right)
                                        {
                                            using (Pen textColorPen = new Pen(textColor, 1))
                                            {

                                                if (X3 < rect1.Left)
                                                {
                                                    X3 = rect1.Left;
                                                }
                                                else
                                                {
                                                    g.DrawLine(textColorPen, X1, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2 - 5, X1, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2 + 5);
                                                }
                                                if (X4 > rect1.Right)
                                                {
                                                    X4 = rect1.Right;
                                                }
                                                g.DrawLine(textColorPen, X4, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2, X3, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2);
                                            }

                                        }
                                        X3 = (X1 + X2 + g.MeasureString(value, _rowTitleFont).Width) / 2;
                                        X4 = X2;
                                        if (X4 > rect1.Left && X3 < rect1.Right)
                                        {
                                            using (Pen textColorPen2 = new Pen(textColor, 1))
                                            {
                                                if (X3 < rect1.Left)
                                                {
                                                    X3 = rect1.Left;
                                                }
                                                if (X4 > rect1.Right)
                                                {
                                                    X4 = rect1.Right;
                                                }
                                                else
                                                {
                                                    g.DrawLine(textColorPen2, X2, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2 - 5, X2, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2 + 5);
                                                }
                                                g.DrawLine(textColorPen2, X4, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2, X3, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2);
                                            }

                                        }
                                        X3 = (X1 + X2 - g.MeasureString(value, _rowTitleFont).Width) / 2;
                                        X4 = (X1 + X2 + g.MeasureString(value, _rowTitleFont).Width) / 2;
                                        if (X4 > rect1.Left && X3 < rect1.Right)
                                        {
                                            StringFormat sf = new StringFormat();
                                            if (X3 < rect1.Left)
                                            {
                                                X3 = rect1.Left;
                                                sf.Alignment = StringAlignment.Far;
                                            }
                                            else if (X4 > rect1.Right)
                                            {
                                                X4 = rect1.Right + 2;
                                                //sf.Alignment = StringAlignment.Near;
                                            }
                                            using (SolidBrush textColorBrush3 = new SolidBrush(textColor))
                                            {
                                                g.DrawString(value, _rowTitleFont, textColorBrush3, new RectangleF(X3, savedCell.Rect.Y, X4 - X3, g.MeasureString("A", _rowTitleFont).Height));
                                            }

                                        }
                                    }
                                    else
                                    {
                                        using (SolidBrush textColorBrush4 = new SolidBrush(textColor))
                                        {
                                            g.DrawString(value, _rowTitleFont, textColorBrush4, savedCell.Rect.X + (savedCell.Rect.Width - g.MeasureString(value, _rowTitleFont).Width) / 2
                                            , savedCell.Rect.Y + (savedCell.Rect.Height - g.MeasureString("A", _rowTitleFont).Height) / 2);
                                        }

                                    }
                                }
                                else
                                {
                                    using (SolidBrush textColorBrush5 = new SolidBrush(textColor))
                                    {
                                        if (_isNoGrid)
                                        {
                                            MedGridPoint point1 = savedCell.Row.Points[savedCell.StartIndex - 1 + savedCell.StartCount];
                                            RectangleF rect1 = GetMainRect();
                                            point1.X1 = GetX(point1.Time, rect1);
                                            point1.X2 = point1.X1 + g.MeasureString(value, _rowTitleFont).Width;
                                            g.DrawString(value, _rowTitleFont, textColorBrush5, point1.X1, savedCell.Rect.Y + (savedCell.Rect.Height - g.MeasureString("A", _rowTitleFont).Height) / 2);
                                        }
                                        else
                                        {
                                            g.DrawString(value, _rowTitleFont, textColorBrush5, savedCell.Rect.X + (savedCell.Rect.Width - g.MeasureString(value, _rowTitleFont).Width) / 2
                                                , savedCell.Rect.Y + (savedCell.Rect.Height - g.MeasureString("A", _rowTitleFont).Height) / 2);
                                        }
                                    }

                                }
                            }
                        }
                        oldX = x;
                        startIndex = endIndex + 1;
                        endIndex = startIndex;
                    }
                    else
                    {
                        endIndex++;
                    }
                }

                if (startIndex >= 0)
                {
                    savedCell = new MedGridGraphSavedCell(_rows[i], new RectangleF(oldX, rectF.Y + i * rowHeight + _topOffSet, gridWidth / 2, rowHeight), startIndex, endIndex, startCount);
                    _savedCells.Add(savedCell);
                    textColor = _rows[i].Color;
                    switch (_gridType)
                    {
                        case MedGridType.Index:
                            value = startIndex.ToString();
                            if (endIndex > startIndex) value += "-" + endIndex.ToString();
                            break;
                        case MedGridType.Summery:
                            if (_rows[i].IsDetail)
                            {
                                //value = "";
                                //for (int ii = savedCell.StartIndex; ii <= savedCell.EndIndex; ii++)
                                //{
                                //    value += "+" + savedCell.Row.Points[ii - 1 + savedCell.StartCount].Value.ToString()
                                //        + savedCell.Row.Points[ii - 1 + savedCell.StartCount].Text;
                                //}
                                //if (!string.IsNullOrEmpty(value))
                                //{
                                //    value = value.Substring(1);
                                //}
                            }
                            else
                            {
                                double v = 0;
                                int cn = 0;
                                bool find = false;
                                for (int ii = savedCell.StartIndex; ii <= savedCell.EndIndex; ii++)
                                {
                                    if (!string.IsNullOrEmpty(savedCell.Row.Points[ii - 1 + savedCell.StartCount].StringValue))
                                    {
                                        find = true;
                                        value = savedCell.Row.Points[ii - 1 + savedCell.StartCount].StringValue;
                                        break;
                                    }
                                    v += savedCell.Row.Points[ii - 1 + savedCell.StartCount].Value;
                                    cn++;
                                }
                                if (_rows[i].IsAverage)
                                {
                                    v = v / cn;
                                }
                                if (!find)
                                {
                                    if (_rows[i].DotNumber >= 0)
                                    {
                                        value = double.Parse(v.ToString(string.Format("F{0}", _rows[i].DotNumber))).ToString();
                                    }
                                    else
                                    {
                                        value = v.ToString();
                                    }
                                }
                            }
                            textColor = _singleTextColor;
                            break;
                        default:
                            value = "";
                            break;
                    }
                    if (_rows[i].IsDetail)
                    {
                        float xx = 0;
                        Font font = _rowTitleFont;// new Font(Font.Name, Font.Size - .2f);
                        for (int ii = savedCell.StartIndex; ii <= savedCell.EndIndex; ii++)
                        {
                            if (xx > 0)
                            {
                                using (SolidBrush textColorBrush5 = new SolidBrush(textColor))
                                {
                                    g.DrawString("+", _rowTitleFont, textColorBrush5, savedCell.Rect.X + xx, savedCell.Rect.Y + savedCell.Rect.Height / 2 - g.MeasureString("A", _rowTitleFont).Height / 2);
                                }
                                xx += 10;
                            }
                            //string vvv = savedCell.Row.Points[ii - 1 + savedCell.StartCount].Value.ToString();
                            //g.DrawString(vvv, _rowTitleFont, new SolidBrush(textColor), savedCell.Rect.X + (savedCell.Rect.Width - g.MeasureString(vvv, _rowTitleFont).Width) / 2 + xx, savedCell.Rect.Y + savedCell.Rect.Height / 2 - g.MeasureString("A", _rowTitleFont).Height);
                            string vvv;
                            if (!string.IsNullOrEmpty(savedCell.Row.Points[ii - 1 + savedCell.StartCount].Alias))
                            {
                                vvv = savedCell.Row.Points[ii - 1 + savedCell.StartCount].Alias;
                            }
                            else
                            {
                                vvv = savedCell.Row.Points[ii - 1 + savedCell.StartCount].Text;
                            }
                            vvv = savedCell.Row.Points[ii - 1 + savedCell.StartCount].Value.ToString() + "(" + vvv + ")";
                            using (SolidBrush textColorBrush6 = new SolidBrush(textColor))
                            {
                                g.DrawString(vvv, _rowTitleFont, textColorBrush6, savedCell.Rect.X + xx, savedCell.Rect.Y + (savedCell.Rect.Height - g.MeasureString("A", _rowTitleFont).Height) / 2);
                            }

                            xx += g.MeasureString(vvv, _rowTitleFont).Width;
                        }
                    }
                    else
                    {
                        if (_rows[i].IsLine)
                        {
                            MedGridPoint point = savedCell.Row.Points[savedCell.StartIndex - 1 + savedCell.StartCount];
                            if (point.EndTime > DateTime.MinValue)
                            {
                                TimeSpan spThis = point.Time - _startTime;
                                TimeSpan spTotal = _endTime - _startTime;
                                RectangleF rect1 = GetMainRect();
                                float X1 = (float)(rect1.X + rect1.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                                spThis = point.EndTime - _startTime;
                                float X2 = (float)(rect1.X + rect1.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                                float X3 = X1;
                                float X4 = (X1 + X2 - g.MeasureString(value, _rowTitleFont).Width) / 2;
                                if (X4 > rect1.Left && X3 < rect1.Right)
                                {
                                    using (Pen textColorPen1 = new Pen(textColor, 1))
                                    {
                                        if (X3 < rect1.Left)
                                        {
                                            X3 = rect1.Left;
                                        }
                                        else
                                        {
                                            g.DrawLine(textColorPen1, X1, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2 - 5, X1, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2 + 5);
                                        }
                                        if (X4 > rect1.Right)
                                        {
                                            X4 = rect1.Right;
                                        }
                                        g.DrawLine(textColorPen1, X4, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2, X3, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2);
                                    }

                                }
                                X3 = (X1 + X2 + g.MeasureString(value, _rowTitleFont).Width) / 2;
                                X4 = X2;
                                if (X4 > rect1.Left && X3 < rect1.Right)
                                {
                                    using (Pen textColorPen2 = new Pen(textColor, 1))
                                    {
                                        if (X3 < rect1.Left)
                                        {
                                            X3 = rect1.Left;
                                        }
                                        if (X4 > rect1.Right)
                                        {
                                            X4 = rect1.Right;
                                        }
                                        else
                                        {
                                            g.DrawLine(textColorPen2, X2, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2 - 5, X2, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2 + 5);
                                        }
                                        g.DrawLine(textColorPen2, X4, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2, X3, savedCell.Rect.Y + g.MeasureString("A", _rowTitleFont).Height / 2);
                                    }

                                }
                                X3 = (X1 + X2 - g.MeasureString(value, _rowTitleFont).Width) / 2;
                                X4 = (X1 + X2 + g.MeasureString(value, _rowTitleFont).Width) / 2;
                                if (X4 > rect1.Left && X3 < rect1.Right)
                                {
                                    StringFormat sf = new StringFormat();
                                    if (X3 < rect1.Left)
                                    {
                                        X3 = rect1.Left;
                                        sf.Alignment = StringAlignment.Far;
                                    }
                                    else if (X4 > rect1.Right)
                                    {
                                        X4 = rect1.Right + 2;
                                    }
                                    using (SolidBrush textColorBrush8 = new SolidBrush(textColor))
                                    {
                                        g.DrawString(value, _rowTitleFont, textColorBrush8, new RectangleF(X3, savedCell.Rect.Y, X4 - X3, g.MeasureString("A", _rowTitleFont).Height));
                                    }

                                }
                            }
                            else
                            {
                                using (SolidBrush textColorBrush9 = new SolidBrush(textColor))
                                {
                                    g.DrawString(value, _rowTitleFont, textColorBrush9, savedCell.Rect.X + (savedCell.Rect.Width - g.MeasureString(value, _rowTitleFont).Width) / 2, savedCell.Rect.Y + (savedCell.Rect.Height - g.MeasureString("A", _rowTitleFont).Height) / 2);
                                }

                            }
                        }
                        else
                        {
                            using (SolidBrush textColorBrush10 = new SolidBrush(textColor))
                            {
                                if (_isNoGrid)
                                {
                                    MedGridPoint point = savedCell.Row.Points[savedCell.StartIndex - 1 + savedCell.StartCount];
                                    RectangleF rect1 = GetMainRect();
                                    point.X1 = GetX(point.Time, rect1);
                                    point.X2 = point.X1 + g.MeasureString(value, _rowTitleFont).Width;
                                    g.DrawString(value, _rowTitleFont, textColorBrush10, point.X1, savedCell.Rect.Y + (savedCell.Rect.Height - g.MeasureString("A", _rowTitleFont).Height) / 2);
                                }
                                else
                                {
                                    g.DrawString(value, _rowTitleFont, textColorBrush10, savedCell.Rect.X + (savedCell.Rect.Width - g.MeasureString(value, _rowTitleFont).Width) / 2, savedCell.Rect.Y + (savedCell.Rect.Height - g.MeasureString("A", _rowTitleFont).Height) / 2);
                                }
                            }

                        }
                    }
                }
            }

            for (int i = 0; i < _rows.Count; i++)
            {
                if (_rows[i].GroupLines > 0)
                {
                    g.FillRectangle(Brushes.White, new RectangleF(rect.X, rectF.Y + i * rowHeight + _topOffSet + 1, _groupWidth, rowHeight * _rows[i].GroupLines - 3));
                    using (Pen borderColorPen = new Pen(_borderColor))
                    {
                        g.DrawLine(borderColorPen, rect.X, rectF.Y + i * rowHeight + _topOffSet, rect.X
                        , rectF.Y + i * rowHeight + _topOffSet + rowHeight * _rows[i].GroupLines);
                        g.DrawLine(borderColorPen, rect.X + _groupWidth, rectF.Y + i * rowHeight + _topOffSet, rect.X + _groupWidth
                            , rectF.Y + i * rowHeight + _topOffSet + rowHeight * _rows[i].GroupLines);
                    }
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(_rows[i].GroupTitle, _rowTitleFont, Brushes.Black, new RectangleF(rect.X - 1, rectF.Y + i * rowHeight + _topOffSet, _groupWidth, rowHeight * _rows[i].GroupLines)
                        , sf);
                }
            }
        }

        /// <summary>
        /// ��ȡʱ����ӦX����
        /// </summary>
        /// <param name="timePoint"></param>
        /// <param name="rectF"></param>
        /// <returns></returns>
        private float GetX(DateTime timePoint, RectangleF rectF)
        {
            TimeSpan spThis, spTotal;
            spThis = timePoint - _startTime;
            spTotal = _endTime - _startTime;
            if (spThis.Ticks < 0 || spTotal.Ticks <= 0 || spThis.TotalSeconds > spTotal.TotalSeconds)
                return float.NaN;
            else
                return (float)(rectF.X + rectF.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
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

            string ttt = text.Trim();
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

        /// <summary>
        /// ����
        /// </summary>
        public void Test()
        {
            _startTime = DateTime.Parse("08:00");
            _endTime = DateTime.Parse("12:00");
            MedGridGraphRow row = new MedGridGraphRow("�¼�", Color.Purple);
            row.AddPoint(DateTime.Parse("08:15"), 1, "", 0);
            row.AddPoint(DateTime.Parse("08:30"), 2, 3, "", 0);
            _rows.Add(row);
            row = new MedGridGraphRow("��ҩ", Color.Blue);
            _rows.Add(row);
            row = new MedGridGraphRow("��Һ", Color.Black);
            _rows.Add(row);
        }

        /// <summary>
        /// ��ȡ���λ�õ�Ԫ��
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int MeasurePoints(float x, float y)
        {
            for (int i = 0; i < _savedCells.Count; i++)
            {
                MedGridGraphSavedCell savedCell = _savedCells[i];
                if (savedCell.Rect.Contains(x / _scaleRate, y / _scaleRate))
                {
                    return i;
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
            _selectPoint = null;
            _mouseTime = DateTime.MinValue;
            _mouseRowIndex = -1;
            RectangleF rectF = GetMainRect();
            if (!rectF.Contains(mousePoint))
            {
                if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                {
                    toolTip1.SetToolTip(this, "");
                    _oldMousePos.X = mousePoint.X;
                    _oldMousePos.Y = mousePoint.Y;
                }
                return;
            }

            RectangleF rect9 = GetMainRect();
            rect9.X = rect9.X * _scaleRate;
            rect9.Y = rect9.Y * _scaleRate;
            rect9.Width = rect9.Width * _scaleRate;
            rect9.Height = rect9.Height * _scaleRate;
            TimeSpan spTotal9 = _endTime - _startTime;
            DateTime dt9 = _startTime.AddSeconds((int)((mousePoint.X - rect9.X) / rect9.Width * spTotal9.TotalSeconds));
            _mouseTime = dt9;

            float rowHeight = (float)(rectF.Height - _topOffSet) / _rows.Count;
            for (int i = 0; i < _rows.Count; i++)
            {
                if (System.Math.Abs(rowHeight * i + rowHeight / 2 - mousePoint.Y + _topOffSet) < 5 && (_rows[i].IsLine || _isNoGrid))
                {
                    foreach (MedGridPoint point in _rows[i].Points)
                    {
                        if (point.X1 < mousePoint.X && point.X2 > mousePoint.X)
                        {
                            _selectPoint = point;
                            _mouseRowIndex = i;
                            StringBuilder tipStrings = new StringBuilder();
                            tipStrings.AppendLine(_rows[i].Text);
                            tipStrings.AppendLine("===================");
                            if (point.EndTime > DateTime.MinValue)
                            {
                                tipStrings.AppendLine(point.Time.ToString() + " �� " + point.EndTime.ToString() + "\r\n����:"
                                    + (string.IsNullOrEmpty(point.StringValue) ? point.Value.ToString() : point.StringValue));
                            }
                            else
                            {
                                tipStrings.AppendLine(point.Time.ToString() + "\r\n����:"
                                    + (string.IsNullOrEmpty(point.StringValue) ? point.Value.ToString() : point.StringValue));
                            }
                            if (point.Speed > 0 && !string.IsNullOrEmpty(point.SpeedUnit))
                            {
                                tipStrings.AppendLine("���٣�" + point.Speed.ToString() + point.SpeedUnit);
                            }
                            if (point.ThickNess > 0 && !string.IsNullOrEmpty(point.ThickNessUnit))
                            {
                                tipStrings.AppendLine("Ũ�ȣ�" + point.ThickNess.ToString() + point.ThickNessUnit);
                            }


                            if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                            {
                                tipStrings.AppendLine("�������ʱ�䣺" + dt9.ToString("yyyy-MM-dd HH:mm"));
                                toolTip1.SetToolTip(this, tipStrings.ToString());
                                _oldMousePos.X = mousePoint.X;
                                _oldMousePos.Y = mousePoint.Y;
                            }

                            return;
                        }
                    }
                }
            }
            if (!_isNoGrid && _savedCells != null && _savedCells.Count > 0)
            {
                int index = MeasurePoints(mousePoint.X, mousePoint.Y);
                if (index > -1)
                {
                    MedGridGraphSavedCell savedCell = _savedCells[index];
                    StringBuilder tipStrings = new StringBuilder();
                    tipStrings.AppendLine(savedCell.Row.Text);
                    _mouseRowIndex = _rows.IndexOf(savedCell.Row);
                    tipStrings.AppendLine("===================");
                    for (int i = savedCell.StartIndex; i <= savedCell.EndIndex; i++)
                    {
                        MedGridPoint point = savedCell.Row.Points[i - 1 + savedCell.StartCount];
                        _selectPoint = point;
                        if (_gridType == MedGridType.Index)
                        {
                            tipStrings.AppendLine(i.ToString() + " " + point.Time.ToString() + " " + point.Text);
                        }
                        else if (_gridType == MedGridType.Summery)
                        {
                            if (savedCell.Row.IsLine && point.EndTime > DateTime.MinValue)
                            {
                                tipStrings.AppendLine(i.ToString() + " " + point.Time.ToString() + " �� " + point.EndTime.ToString() + " " + point.Text + "\r\n����:"
                                    + (string.IsNullOrEmpty(point.StringValue) ? point.Value.ToString() : point.StringValue));
                            }
                            else
                            {
                                tipStrings.AppendLine(i.ToString() + " " + point.Time.ToString() + " " + point.Text + "\r\n����:"
                                    + (string.IsNullOrEmpty(point.StringValue) ? point.Value.ToString() : point.StringValue));
                            }
                            if (point.Speed > 0 && !string.IsNullOrEmpty(_rows[i].SpeedUnit))
                            {
                                tipStrings.AppendLine("���٣�" + point.Speed.ToString() + _rows[i].SpeedUnit);
                            }
                            if (point.ThickNess > 0 && !string.IsNullOrEmpty(_rows[i].ThickNessUnit))
                            {
                                tipStrings.AppendLine("Ũ�ȣ�" + point.ThickNess.ToString() + _rows[i].ThickNessUnit);
                            }
                        }

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
            RectangleF rect = GetMainRect();
            rect.X = rect.X * _scaleRate;
            rect.Y = rect.Y * _scaleRate;
            rect.Width = rect.Width * _scaleRate;
            rect.Height = rect.Height * _scaleRate;
            TimeSpan spTotal1 = _endTime - _startTime;
            DateTime dt1 = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal1.TotalSeconds));
            if (dt1 >= _startTime && dt1 <= _endTime)
            {
                if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                {
                    if (_mouseRowIndex == -1)
                    {
                        _mouseRowIndex = GetMouseRowIndex(mousePoint.Y);
                    }
                    string tipText = dt1.ToString("yyyy-MM-dd HH:mm");
                    if (_mouseRowIndex >= 0)
                    {
                        tipText = _rows[_mouseRowIndex].Text + "\r\n" + tipText;
                    }
                    toolTip1.SetToolTip(this, tipText);
                    _mouseTime = dt1;
                    _oldMousePos.X = mousePoint.X;
                    _oldMousePos.Y = mousePoint.Y;
                }
            }
            else
            {
                if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                {
                    toolTip1.SetToolTip(this, "");
                    _oldMousePos.X = mousePoint.X;
                    _oldMousePos.Y = mousePoint.Y;
                }
            }
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
        /// ��ȡ����λ�ö�Ӧ��
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private int GetMouseRowIndex(float y)
        {
            if (_rows != null && _rows.Count > 0)
            {
                RectangleF rectF = GetMainRect();
                float rowHeight = (float)(rectF.Height - _topOffSet) / _rows.Count;
                for (int i = 0; i < _rows.Count; i++)
                {
                    if (rectF.Y + _topOffSet + i * rowHeight < y && rectF.Y + _topOffSet + (i + 1) * rowHeight > y)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// �������˫��
        /// </summary>
        /// <param name="mousePoint"></param>
        public void SetMouseDoubleClick(Point mousePoint)
        {
            _mouseRowIndex = GetMouseRowIndex(mousePoint.Y);
            RectangleF rect = GetMainRect();
            rect.X = rect.X * _scaleRate;
            rect.Y = rect.Y * _scaleRate;
            rect.Width = rect.Width * _scaleRate;
            rect.Height = rect.Height * _scaleRate;
            TimeSpan spTotal1 = _endTime - _startTime;
            DateTime dt1 = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal1.TotalSeconds));
            _mouseTime = dt1;
            AnesBandEventHandle eventHandle = (AnesBandEventHandle)Events[_customEditEventHandle];
            if (eventHandle != null)
            {
                if (_savedCells != null && _savedCells.Count > 0)
                {
                    int index = MeasurePoints(mousePoint.X, mousePoint.Y);
                    if (index > -1)
                    {
                        MedGridGraphSavedCell savedCell = _savedCells[index];
                        MedGridPoint point = savedCell.Row.Points[savedCell.StartIndex - 1 + savedCell.StartCount];
                        point.Row = savedCell.Row;
                        eventHandle(this, point, null);
                        return;
                    }
                }
                _currentTime = new DateTime(dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, 0);
                eventHandle(this, null, null);
            }
        }





        /// <summary>
        /// ��ȡָ��λ�õ�ע���ı�
        /// </summary>
        /// <param name="mousePoint"></param>
        /// <param name="isStart"></param>
        /// <returns></returns>
        public MedGridPoint GetPointCommentText(Point mousePoint, out bool isStart)
        {
            isStart = true;
            RectangleF rectF = GetMainRect();
            float rowHeight = (float)(rectF.Height - _topOffSet) / _rows.Count;
            for (int i = 0; i < _rows.Count; i++)
            {
                if (System.Math.Abs(rowHeight * i + rowHeight / 2 - mousePoint.Y + _topOffSet) < rowHeight / 2 && (_rows[i].IsLine || _isNoGrid))
                {
                    foreach (MedGridPoint point in _rows[i].Points)
                    {
                        if (!string.IsNullOrEmpty(point.StartText))
                        {
                            Graphics graph = Graphics.FromHwnd(this.Handle);
                            SizeF size = graph.MeasureString(point.StartText, _commentFont);
                            graph.Dispose();

                            if (point.X1 - size.Width - 5 < mousePoint.X && point.X1 > mousePoint.X)
                                return point;
                        }

                        if (!string.IsNullOrEmpty(point.EndText))
                        {
                            Graphics graph = Graphics.FromHwnd(this.Handle);
                            SizeF size = graph.MeasureString(point.EndText, _commentFont);
                            graph.Dispose();

                            if (point.X2 < mousePoint.X && point.X2 + size.Width + 5 > mousePoint.X)
                            {
                                isStart = false;
                                return point;
                            }
                        }
                    }
                }
            }
            return null;
        }
        public void Sort()
        {
            if (Rows != null && Rows.Count > 0)
            {
                Rows.Sort(new Comparison<MedGridGraphRow>(delegate(MedGridGraphRow row1, MedGridGraphRow row2)
                {
                    DateTime dateTimeRow1 = row1.Points[0].Time;
                    foreach (var item in row1.Points)
                    {
                        if (item.Time < dateTimeRow1)
                        {
                            dateTimeRow1 = item.Time;
                        }
                    }
                    DateTime dateTimeRow2 = row2.Points[0].Time;
                    foreach (var item in row2.Points)
                    {
                        if (item.Time < dateTimeRow2)
                        {
                            dateTimeRow2 = item.Time;
                        }
                    }
                    if (dateTimeRow1 < dateTimeRow2)
                    {
                        return -1;
                    }
                    else return 1;
                }));
            }
        }





        #endregion ����

        #region �¼�

        /// <summary>
        /// ����Ƶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedGridGraph_MouseMove(object sender, MouseEventArgs e)
        {
            SetMousePosition(e.Location);
        }

        /// <summary>
        /// ���˫��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedGridGraph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetMouseDoubleClick(e.Location);
        }

        #endregion �¼�
    }
}

