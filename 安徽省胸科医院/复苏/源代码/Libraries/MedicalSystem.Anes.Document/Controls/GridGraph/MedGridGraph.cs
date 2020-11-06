/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedGridGraph.cs
      // 文件功能描述：事件索引表格控件
      //
      // 
      // 创建标识：戴呈祥-2008-10-22
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
    /// 事件索引表格控件
    /// </summary>
    [Serializable, ToolboxItem(false), Description("输液表格")]
    public partial class MedGridGraph : AnesGraph, IPrintable
    {

        #region 构造方法

        public MedGridGraph()
        {
            InitializeComponent();
            TimeText = null;
            //TotalText = null;
            if (DesignMode) Test();
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 竖网格颜色
        /// </summary>
        private Color _gridColor = Color.Red;
        /// <summary>
        /// 行网格颜色
        /// </summary>
        private Color _rowGridColor = Color.Red;

        private bool _rowColorEqualColumColor = true;

        /// <summary>
        /// 网格宽度
        /// </summary>
        private int _gridLineWidth = 1;

        /// <summary>
        /// 刻度线虚线样式
        /// </summary>
        private DashStyle _gridDashStyle = DashStyle.Solid;

        /// <summary>
        /// 小刻度刻度数
        /// </summary>
        private int _minScaleCount = 2;

        /// <summary>
        /// 小刻度线颜色
        /// </summary>
        private Color _middleLineColor = Color.FromArgb(255, 200, 200);

        /// <summary>
        /// 小刻度线宽度
        /// </summary>
        private int _minScaleWidth = 1;

        /// <summary>
        /// 小刻度线样式
        /// </summary>
        private DashStyle _minDashStyle = DashStyle.Solid;

        /// <summary>
        /// 行集合
        /// </summary>
        private List<MedGridGraphRow> _rows = new List<MedGridGraphRow>();

        /// <summary>
        /// 保存单元集合
        /// </summary>
        private List<MedGridGraphSavedCell> _savedCells;

        /// <summary>
        /// 数据填充类型
        /// </summary>
        private MedGridType _gridType = MedGridType.Index;

        /// <summary>
        /// 上次鼠标位置
        /// </summary>
        private Point _oldMousePos = new Point(-1000, -1000);

        #endregion 变量

        #region 属性


        /// <summary>
        /// 注释字体
        /// </summary>
        private Font _commentFont = new Font("宋体", 6);

        [DisplayName("说明文本字体")]
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
        [DisplayName("说明文本颜色")]
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
        [DisplayName("标题水平位移")]
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
        /// 是否自动数字
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
        [DisplayName("画线数字开头")]
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
        [DisplayName("网格竖线打印颜色")]
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
        [DisplayName("网格横线打印颜色")]
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
        /// 是否正在打印
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
        /// 当前时间
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
        /// 是否显示输血输液明细
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
        /// 边框颜色
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


        [DisplayName("网格竖线颜色")]
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


        [DisplayName("网格横线颜色")]
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


        [DisplayName("网格横线颜色与网格竖线颜色相同")]
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
        /// 网格线宽度
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
        /// 刻度线样式
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
        /// 小刻度线样式
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
        /// 小刻度线宽度
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
        /// 小刻度线颜色
        /// </summary>
        [Category("数据-自定义"), DisplayName("小刻度线颜色")]
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
        /// 小刻度线数
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
        /// 数据行
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
        /// 数据填充类型
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
        [Description("单一文本颜色")]
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
        [Description("单一标题颜色")]
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
        [Description("是否显示用药")]
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
        [Description("是否显示输血输液")]
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
        [Description("最小行数")]
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
        [Description("最大行数")]
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
        [Category("数据-自定义"), DisplayName("行参数设置")]
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
        [Description("不打印")]
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
        [Description("不按表格")]
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
        [Description("忽略括号")]
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
        [Category("数据-自定义"), DisplayName("是否将网格线延伸到总计处")]
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
        /// 选中的点
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
        /// 鼠标所在位置对于时间
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
        /// 鼠标所在位置对应行
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
        [Category("数据(自定义)"), DisplayName("标题")]
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
        [Category("数据(自定义)"), DisplayName("标题宽度")]
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


        #region add by xiaopei.y@2014-11-14 10:19:51  当前时间线可配


        private bool _isCurrentTimeLine;
        [Category("数据-自定义"), DisplayName("是否显示当前时间线")]
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

        #endregion 属性

        #region 事件接口

        /// <summary>
        /// 客户绘制事件
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

        #endregion 事件接口

        #region 方法

        /// <summary>
        /// IPrint接口-打印
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
        /// 根据标题返回行
        /// </summary>
        /// <param name="rowString"></param>
        /// <returns>如果没找到返回空，否则返回该行</returns>
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
        [DisplayName("整点竖线")]
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

        #region 2013-3-18 归月平 画当前时间线
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
        /// 汇总本控件（事件索引表格控件）
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

            #region 2013-3-18 归月平 画当前时间线,不打印出来
            if (!_printing)
            {

                if (IsCurrentTimeLine)  // add by xiaopei.y@2014-11-14 10:24:00  当前时间线根据配置显示
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
        /// 绘制标题
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
        /// 画网格
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
        /// 画子网格
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
        /// 行标题字体
        /// </summary>
        private Font _rowTitleFont = new Font("宋体", 9);
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
        /// 行分组宽度
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
        /// 绘制线（以数字开头）
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
        /// 绘制线
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
        /// 获取行标题
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
        /// 画所有行
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
                ///画行线和行标题
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

                        //汇总
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

                    ///右半格
                    if (gridIndex * minutes + minutes / 2 <= spThis.TotalMinutes) x += gridWidth / 2;

                    ///保证不出右边界
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

                    ///新格
                    if (x > oldX)
                    {
                        ///画保存的格
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
                            ///画明细
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
        /// 获取时间点对应X坐标
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
        /// 绘制字符串
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
        /// 测试
        /// </summary>
        public void Test()
        {
            _startTime = DateTime.Parse("08:00");
            _endTime = DateTime.Parse("12:00");
            MedGridGraphRow row = new MedGridGraphRow("事件", Color.Purple);
            row.AddPoint(DateTime.Parse("08:15"), 1, "", 0);
            row.AddPoint(DateTime.Parse("08:30"), 2, 3, "", 0);
            _rows.Add(row);
            row = new MedGridGraphRow("用药", Color.Blue);
            _rows.Add(row);
            row = new MedGridGraphRow("输液", Color.Black);
            _rows.Add(row);
        }

        /// <summary>
        /// 获取鼠标位置单元格
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
        /// 设置鼠标位置
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
                                tipStrings.AppendLine(point.Time.ToString() + " 到 " + point.EndTime.ToString() + "\r\n剂量:"
                                    + (string.IsNullOrEmpty(point.StringValue) ? point.Value.ToString() : point.StringValue));
                            }
                            else
                            {
                                tipStrings.AppendLine(point.Time.ToString() + "\r\n剂量:"
                                    + (string.IsNullOrEmpty(point.StringValue) ? point.Value.ToString() : point.StringValue));
                            }
                            if (point.Speed > 0 && !string.IsNullOrEmpty(point.SpeedUnit))
                            {
                                tipStrings.AppendLine("流速：" + point.Speed.ToString() + point.SpeedUnit);
                            }
                            if (point.ThickNess > 0 && !string.IsNullOrEmpty(point.ThickNessUnit))
                            {
                                tipStrings.AppendLine("浓度：" + point.ThickNess.ToString() + point.ThickNessUnit);
                            }


                            if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                            {
                                tipStrings.AppendLine("鼠标所在时间：" + dt9.ToString("yyyy-MM-dd HH:mm"));
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
                                tipStrings.AppendLine(i.ToString() + " " + point.Time.ToString() + " 到 " + point.EndTime.ToString() + " " + point.Text + "\r\n剂量:"
                                    + (string.IsNullOrEmpty(point.StringValue) ? point.Value.ToString() : point.StringValue));
                            }
                            else
                            {
                                tipStrings.AppendLine(i.ToString() + " " + point.Time.ToString() + " " + point.Text + "\r\n剂量:"
                                    + (string.IsNullOrEmpty(point.StringValue) ? point.Value.ToString() : point.StringValue));
                            }
                            if (point.Speed > 0 && !string.IsNullOrEmpty(_rows[i].SpeedUnit))
                            {
                                tipStrings.AppendLine("流速：" + point.Speed.ToString() + _rows[i].SpeedUnit);
                            }
                            if (point.ThickNess > 0 && !string.IsNullOrEmpty(_rows[i].ThickNessUnit))
                            {
                                tipStrings.AppendLine("浓度：" + point.ThickNess.ToString() + _rows[i].ThickNessUnit);
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
        /// 获取提示文本
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
        /// 获取纵向位置对应行
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
        /// 设置鼠标双击
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
        /// 获取指定位置的注释文本
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





        #endregion 方法

        #region 事件

        /// <summary>
        /// 鼠标移到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedGridGraph_MouseMove(object sender, MouseEventArgs e)
        {
            SetMousePosition(e.Location);
        }

        /// <summary>
        /// 鼠标双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedGridGraph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetMouseDoubleClick(e.Location);
        }

        #endregion 事件
    }
}

