namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 图表曲线
    /// </summary>
    public class MedCurve
    {
        #region 变量

        private MedPointList _points;
        private int _XaxisIndex, _YaxisIndex;
        private MedSymbol _symbol;
        private System.Drawing.Pen _pen = new System.Drawing.Pen(System.Drawing.Color.Black);
        private string _title;
        private string _legendTitle = null;
        private bool _hasLine = true;
        private bool _isBar = false;
        private int _barWidth = 8;

        #endregion 变量

        #region 方法

        public MedCurve(MedPointList points, int xaxisindex, int yaxisindex, MedSymbol symbol, System.Drawing.Pen pen, string title, bool hasLine)
        {
            this._points = points;
            this._XaxisIndex = xaxisindex;
            this._YaxisIndex = yaxisindex;
            this._pen = pen;
            if (symbol == null) this._symbol = new MedSymbol(MedSymbolType.None);
            else this._symbol = symbol;
            _symbol.Pen = _pen;
            _title = title;
            _hasLine = hasLine;
        }

        public MedCurve(MedPointList points, int xaxisindex, int yaxisindex, MedSymbol symbol, System.Drawing.Pen pen, string title) : this(points, xaxisindex, yaxisindex, symbol, pen, title, true) { }
        public MedCurve(MedPointList points, int xaxisindex, int yaxisindex, MedSymbol symbol, System.Drawing.Pen pen) : this(points, xaxisindex, yaxisindex, symbol, pen, null) { }
        public MedCurve(MedPointList points) : this(points, 0, 0, null, new System.Drawing.Pen(System.Drawing.Color.Black)) { _symbol.Pen = _pen; }
        public MedCurve(MedPointList points, System.Drawing.Image image) : this(points) { _symbol = new MedSymbol(image); _symbol.Pen = _pen; }
        public MedCurve(MedPointList points, System.Drawing.Pen pen) : this(points) { _pen = pen; _symbol.Pen = _pen; }
        public MedCurve(MedPointList points, System.Drawing.Color color) : this(points) { _pen = new System.Drawing.Pen(color); _symbol.Pen = _pen; }
        public MedCurve(MedPointList points, System.Drawing.Image image, System.Drawing.Color color) : this(points, image) { _pen = new System.Drawing.Pen(color); _symbol.Pen = _pen; }

        #endregion 方法

        #region 属性

        /// <summary>
        /// 是否要连线
        /// </summary>
        public bool hasLine
        {
            get
            {
                return _hasLine;
            }
            set
            {
                _hasLine = value;
            }
        }

        /// <summary>
        /// 是否柱状图
        /// </summary>
        public bool IsBar
        {
            get
            {
                return _isBar;
            }
            set
            {
                _isBar = value;
            }
        }

        /// <summary>
        /// 柱状图宽度
        /// </summary>
        public int BarWidth
        {
            get
            {
                return _barWidth;
            }
            set
            {
                if (value > 0)
                {
                    _barWidth = value;
                }
            }
        }

        /// <summary>
        /// 图例标题
        /// </summary>
        public string LegendTitle
        {
            get
            {
                return _legendTitle;
            }
            set
            {
                _legendTitle = value;
            }
        }

        public MedPointList Points
        {
            get { 
                lock (this) 
                    return _points; 
            }
            set { 
                lock (this) 
                    _points = value; 
            }
        }

        public int XAxisIndex { get { return _XaxisIndex; } set { _XaxisIndex = value; } }
        public int YAxisIndex { get { return _YaxisIndex; } set { _YaxisIndex = value; } }
        public MedSymbol Symbol { get { return _symbol; } set { _symbol = value; } }
        public System.Drawing.Pen Pen { get { return _pen; } set { _pen = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public bool Visible = true;

        #endregion 属性

    }
}
