/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedAnesSheetDetails.cs
      // 文件功能描述：麻醉单明细区控件
      //
      // 
      // 创建标识：戴呈祥-2008-10-23
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
    /// 麻醉单明细区控件
    /// </summary>
    [ToolboxItem(false), Description("事件明细")]
    public partial class MedAnesSheetDetails : AnesBand, IPrintable
    {

        #region 构造方法

        public MedAnesSheetDetails()
        {
            InitializeComponent();
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 边框颜色
        /// </summary>
        //private Color _borderColor = Color.Red;

        /// <summary>
        /// 边框宽度
        /// </summary>
        //private int _borderWidth = 1;

        /// <summary>
        /// 要画的字符串列表
        /// </summary>
        private List<string> DrawStringList = new List<string>();

        private static Brush brush = new SolidBrush(Color.Black);
        /// <summary>
        /// 列数
        /// </summary>
        private int _columnCount = 3;

        /// <summary>
        /// 明细集
        /// </summary>
        private List<MedAnesSheetDetailCollection> _collections = new List<MedAnesSheetDetailCollection>();

        /// <summary>
        /// 汇总行数
        /// </summary>
        private int _totalRowCount = 6;

        /// <summary>
        /// 汇总值颜色
        /// </summary>
        private Color _totalValueColor = Color.Blue;

        /// <summary>
        /// 汇总普通颜色
        /// </summary>
        private Color _totalNormalColor = Color.Black;

        /// <summary>
        /// 是否有序号
        /// </summary>
        private bool _hasOrderNo = true;

        /// <summary>
        /// 是否有时间
        /// </summary>
        private bool _hasTime = true;

        /// <summary>
        /// 输液颜色
        /// </summary>
        private Color _inLiquidColor = Color.Black;

        /// <summary>
        /// 用药颜色
        /// </summary>
        private Color _drugColor = Color.Blue;

        /// <summary>
        /// 事件颜色
        /// </summary>
        private Color _eventColor = Color.PaleVioletRed;

        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime _startTime = DateTime.Parse("08:00");

        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime _endTime = DateTime.Parse("12:00");

        /// <summary>
        /// 上次鼠标位置
        /// </summary>
        private Point _oldMousePos = new Point(-1000, -1000);

        #endregion 变量

        #region 属性

        private bool _displayRoute = true;
        [DisplayName("默认显示途径")]
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
        /// 普通药物显示类别
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
        /// 持续药显示类别
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

        private float _leftWidthPercent = 0;
        /// <summary>
        /// 左边百分比
        /// </summary>
        [DisplayName("左边百分比")]
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
                    Exception ex = new Exception("无效的百分比，必须介于5%和100%之间!");
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 水平位移
        /// </summary>
        private float _XOffSet = 0;
        [DisplayName("水平位移")]
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
        /// 右边百分比
        /// </summary>
        [DisplayName("右边百分比")]
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
                    Exception ex = new Exception("无效的百分比，必须介于0%和100%之间!");
                    throw ex;
                }
            }
        }

        private bool _group = true;
        [Description("分组"), DisplayName("分组")]
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
        [Description("分组按时间排序"), DisplayName("分组按时间排序")]
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
        [Description("是否要组标题"), DisplayName("是否要组标题")]
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
        [Description("是否要组间分行"), DisplayName("是否要组间分行")]
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
        [Description("是否要组间竖线"), DisplayName("是否要组间竖线")]
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
        [Description("是否要输血输液"), DisplayName("是否要输血输液")]
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
        ///// 边框颜色
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
        ///// 边框宽度
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
        /// 列数
        /// </summary>
        [DisplayName("列数")]
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
        /// 明细集
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
        /// 列宽
        /// </summary>
        public float ColumnWidth
        {
            get
            {
                return (OriginRect.Width - _titleWidth) / _columnCount;
            }
        }

        /// <summary>
        /// 行高
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
        /// 行数
        /// </summary>
        [Category("数据(自定义)"), DisplayName("行数")]
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

        private Font _detailFont = new Font("宋体", 9);
        /// <summary>
        /// 明细字体
        /// </summary>
        [Category("数据(自定义)"), DisplayName("明细字体")]
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
        /// 汇总行数
        /// </summary>
        [DisplayName("汇总行数")]
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
        /// 汇总值颜色
        /// </summary>
        [DisplayName("汇总值颜色")]
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
        /// 汇总普通颜色
        /// </summary>
        [DisplayName("汇总普通颜色")]
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
        /// 是否需要序号
        /// </summary>
        [DisplayName("是否需要序号")]
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
        /// 是否需要时间
        /// </summary>
        [DisplayName("是否需要时间")]
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
        [Description("是否显示事件"), DisplayName("是否显示事件")]
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

        [Description("事件颜色"), DisplayName("事件颜色")]
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
        [Description("是否显示麻药"), DisplayName("是否显示麻药")]
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
        [Description("麻药颜色"), DisplayName("麻药颜色")]
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
        [Description("麻药显示类型"), DisplayName("麻药显示类型")]
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

        [Description("用药颜色"), DisplayName("用药颜色")]
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

        [Description("输血输液颜色"), DisplayName("输血输液颜色")]
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
        [Description("是否显示插管"), DisplayName("是否显示插管")]
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
        /// 开始时间
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
        /// 结束时间
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
        [Description("是否显示附记"), DisplayName("是否显示附记")]
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
        [Description("签名标题"), DisplayName("签名标题")]
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

        /// <summary>
        /// 开始索引
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
        [Category("数据(自定义)"), DisplayName("记录数")]
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

        private bool _displayTimeOrder = false;
        [Category("数据(自定义)"), DisplayName("时间序号")]
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
        [Category("数据(自定义)"), DisplayName("时间序号标题")]
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
        [Category("数据(自定义)"), DisplayName("时间序号高度")]
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
        /// 总结列行集合
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
        /// 刻度类型
        /// </summary>
        protected ScaleType _scaleType = ScaleType.HalfHour;

        /// <summary>
        /// 时间标题
        /// </summary>
        private string _timeText = "时间";
        /// <summary>
        /// 时间标题
        /// </summary>
        [Category("数据-自定义"), DisplayName("时间标题")]
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
        /// 顶部偏移量
        /// </summary>
        protected float _topOffSet = 0;
        [Category("数据(自定义)"), DisplayName("时间坐标高度")]
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
        /// 时间坐标轴位置类型
        /// </summary>
        protected TimeAxisPositionType _timeAxisPositionType = TimeAxisPositionType.None;
        /// <summary>
        /// 时间坐标轴位置类型
        /// </summary>
        [Category("数据-自定义"), DisplayName("时间坐标轴位置类型")]
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
        /// 鼠标对应时间
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
        /// 选中的点
        /// </summary>
        private MedAnesSheetDetailPoint _selectPoint = null;
        public MedAnesSheetDetailPoint SelectedPoint
        {
            get
            {
                return _selectPoint;
            }
        }

        #endregion 属性

        #region 事件接口
        /// <summary>
        /// 客户绘制事件接口
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
        /// 获取网格宽度因子
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
        /// 获取网格刻度宽度
        /// </summary>
        /// <returns></returns>
        protected virtual float GetGridWidth()
        {
            TimeSpan ts = _endTime - _startTime;
            RectangleF rectF = GetMainRect();
            return (float)(rectF.Width / ts.TotalHours) * GetGridScale();
        }

        /// <summary>
        /// 获取网格刻度时间--分钟数
        /// </summary>
        /// <returns></returns>
        protected virtual int GetGridMinutes()
        {
            return (int)(60 * GetGridScale());
        }

        /// <summary>
        /// 画刻度值
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
        /// 获取时间点对应水平坐标
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
        /// 绘制控件
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
        /// 获取点显示内容
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
            //Add By xiasen.x@2014-05-31,多一个就可能超出格子了，故新增判断
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
        /// 绘制明细（不分组）
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
            ///绘制点
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
        /// 绘制总结行
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
        /// 绘制集合（分组）
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
                ///绘制标题
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
                ///插入空行
                if (_hasGroupEmptyLine)
                {
                    DrawStringList.Add("");
                }
                ///汇总集特殊处理
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
            float columnWidth = ColumnWidth;
            string ttt = text.Trim();
            while (ttt.IndexOf("  ") > 0) ttt = ttt.Replace("  ", " ");
            if (g.MeasureString(ttt, font).Width > columnWidth)
                ttt = ttt.Replace(" ", "");
            g.DrawString(ttt, font, brush, x, y);
        }

        /// <summary>
        /// 绘制集文本（名称）
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text">文本（名称）</param>
        /// <param name="color">颜色</param>
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
        /// 测试
        /// </summary>
        public void Test()
        {
            /*
            Font = new Font("宋体", 12);
            _collections.Clear();
            MedAnesSheetDetailCollection collection = new MedAnesSheetDetailCollection("事件",Color.PaleVioletRed);
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:20"), "入室"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:35"), "单肺通气"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:38"), "体外循环开始"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:58"), "气管插管"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("09:50"), "吸痰"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:05"), "苏醒"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:15"), "胃大部切除"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:31"), DateTime.Parse("10:46"), "吻合"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:42"), "关腹"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:50"), "双肺通气"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:10"), "停止通气"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:20"), "出室"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:30"), "恢复通气"));
            _collections.Add(collection);
            collection = new MedAnesSheetDetailCollection("用药", Color.Blue, CollectionType.Drug);
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:43"), "6-54", 25, "mg", "IV"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:58"), "奥一麦", 1, "mg", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:58"), "阿托品", .5, "mg", "IV"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:05"), "氟吗西尼", .5, "mg", "IV"));
            _collections.Add(collection);
            collection = new MedAnesSheetDetailCollection("输液和输血", Color.Black, CollectionType.Drug);
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:23"), "平衡液", 800, "ml", "VD"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("08:50"), "血水", 500, "ml", "VD"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("09:08"), "6%贺斯", 500, "ml", "VD"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("10:20"), "平衡液", 500, "ml", "VD"));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "50%葡萄糖", 200, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "20%甘露醇", 100, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "9%盐水", 100, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "706代血浆", 100, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "平衡液", 100, "ml", ""));
            collection.Points.Add(new MedAnesSheetDetailPoint(DateTime.Parse("11:21"), "5%碳酸氢钠", 100, "ml", ""));
            _collections.Add(collection);
            collection = new MedAnesSheetDetailCollection("总入量", Color.PaleVioletRed, CollectionType.Total);
            collection.Points.Add(new MedAnesSheetDetailPoint("总入量", 5500, "ml"));
            collection.Points.Add(new MedAnesSheetDetailPoint("其它", 5500, "ml"));
            _collections.Add(collection);
            collection = new MedAnesSheetDetailCollection("总出量", Color.PaleVioletRed, CollectionType.Total);
            collection.Points.Add(new MedAnesSheetDetailPoint("总出量", 220, "ml"));
            collection.Points.Add(new MedAnesSheetDetailPoint("失血量", 200, "ml"));
            collection.Points.Add(new MedAnesSheetDetailPoint("尿量", 20, "ml"));
            collection.Points.Add(new MedAnesSheetDetailPoint("其它", 300, "ml"));
            _collections.Add(collection);
             * */
        }

        /// <summary>
        /// 获取主矩形
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
        /// 获取坐标对应点索引
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
        /// 设置鼠标位置
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
                        tipStrings.AppendLine("开始时间：" + point.StartTime.ToString());
                        if (!point.EndTime.Equals(DateTime.MinValue) && !point.EndTime.Equals(DateTime.MaxValue))
                        {
                            tipStrings.AppendLine("结束时间：" + point.EndTime.ToString());
                        }
                        if (!string.IsNullOrEmpty(point.Route))
                        {
                            tipStrings.AppendLine("途径：" + point.Route);
                        }
                        if (point.Value > 0)
                        {
                            tipStrings.AppendLine("量：" + point.Value.ToString());
                        }
                        if (!string.IsNullOrEmpty(point.Unit))
                        {
                            tipStrings.AppendLine("单位：" + point.Unit);
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
        /// 获取提示
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
        /// 设置鼠标双击
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

        #endregion 方法

        #region 事件

        /// <summary>
        /// 鼠标移到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedAnesSheetDetails_MouseMove(object sender, MouseEventArgs e)
        {
            SetMousePosition(e.Location);
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedAnesSheetDetails_DoubleClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 鼠标双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedAnesSheetDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetMouseDoubleClick(e.Location);
        }




        /// <summary>
        /// 单击
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


        #endregion 事件

    }
}
