/*----------------------------------------------------------------
      // Copyright (C) 2005 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedGraphPanel.cs
      // 文件功能描述：图表主体类
      //
      // 
      // 创建标识：戴呈祥-2008-01-08创建此类以实现MedGraph和元素的分离，从而达到解耦的目的，以提高适用性和强壮性
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 图表主体类
    /// </summary>
    public class MedGraphPanel : IDisposable
    {

        #region 构造方法

        public MedGraphPanel(MedGraph graphControl)
        {
            _graphControl = graphControl;
        }

        #endregion 构造方法

        #region 变量

        private MedGraph _graphControl;

        /// <summary>
        /// 曲线列表
        /// </summary>
        private MedCurveList _curveList = new MedCurveList();

        /// <summary>
        /// X坐标轴
        /// </summary>
        private MedAxisList _XaxisList = new MedAxisList(new Pen(Color.Green, 2), new Pen(Color.Green, 1));

        /// <summary>
        /// Y坐标轴
        /// </summary>
        private MedAxisList _YaxisList = new MedAxisList(new Pen(Color.Green, 2), new Pen(Color.Green, 1));

        /// <summary>
        /// 图例
        /// </summary>
        private MedLegend _legend = new MedLegend();

        /// <summary>
        /// 边距
        /// </summary>
        private int _leftmargin = 5, _topmargin = 5, _rightmargin = 5, _bottommargin = 5;

        /// <summary>
        /// 网格行
        /// </summary>
        private MedGridRowList _rowList = new MedGridRowList(2);

        /// <summary>
        /// 区域画刷
        /// </summary>
        private Brush _rectBrush = Brushes.White, _mainrectBrush = Brushes.White, _gridTextBrush = Brushes.Black, _memoTextBrush = Brushes.Black;

        /// <summary>
        /// 区域边框画笔
        /// </summary>
        private Pen _rectBorderPen = Pens.Black, _mainRectBorderPen = Pens.Green, _gridLinePen = Pens.Black, _memoLinePen = Pens.Black;

        /// <summary>
        /// 网格最大显示行数
        /// </summary>
        private int _maxgirdRowCounts = 10;

        /// <summary>
        /// 网格和备注行高度百分比
        /// </summary>
        private float _gridHeightPercent = 0.0f, _memoHeightPercent = 0.1f;

        /// <summary>
        /// 是否画图例
        /// </summary>
        private bool _drawlegend = true;

        /// <summary>
        /// 滚动条宽度
        /// </summary>
        private int _hscrollwidth = 0;

        /// <summary>
        /// 需要绘制坐标网格
        /// </summary>
        private bool _hasAxisGridLine = true;

        /// <summary>
        /// X坐标标题在顶部
        /// </summary>
        private bool _xAxisTitleAtTop = true;

        /// <summary>
        /// Y坐标标题位移
        /// </summary>
        private float _yAxisTitleOffset = 0;

        #endregion 变量

        #region 属性

        /// <summary>
        /// 曲线列表
        /// </summary>
        public MedCurveList CurveList
        {
            get
            {
                return _curveList;
            }
        }

        /// <summary>
        /// 网格行
        /// </summary>
        public MedGridRowList RowList
        {
            get
            {
                return _rowList;
            }
        }

        /// <summary>
        /// X坐标轴
        /// </summary>
        public MedAxisList XAxisList
        {
            get
            {
                return _XaxisList;
            }
        }

        /// <summary>
        /// Y坐标轴
        /// </summary>
        public MedAxisList YAxisList
        {
            get
            {
                return _YaxisList;
            }
        }

        /// <summary>
        /// 图例
        /// </summary>
        public MedLegend Legend
        {
            get
            {
                return _legend;
            }
            set
            {
                if (_legend != null)
                {
                    _legend.Dispose();
                }
                _legend = value;
            }
        }

        /// <summary>
        /// 左边距
        /// </summary>
        public int LeftMargin
        {
            get
            {
                return _leftmargin;
            }
            set
            {
                _leftmargin = value;
            }
        }

        /// <summary>
        /// 上边距
        /// </summary>
        public int TopMargin
        {
            get
            {
                return _topmargin;
            }
            set
            {
                _topmargin = value;
            }
        }

        /// <summary>
        /// 右边距
        /// </summary>
        public int RightMargin
        {
            get
            {
                return _rightmargin;
            }
            set
            {
                _rightmargin = value;
            }
        }

        /// <summary>
        /// 下边距
        /// </summary>
        public int BottomMargin
        {
            get
            {
                return _bottommargin;
            }
            set
            {
                _bottommargin = value;
            }
        }

        /// <summary>
        /// 图表区域画刷
        /// </summary>
        public Brush MainRectBrush
        {
            get
            {
                return _mainrectBrush;
            }
            set
            {
                _mainrectBrush = value;
            }
        }

        /// <summary>
        /// 整体区域画刷
        /// </summary>
        public Brush RectBrush
        {
            get
            {
                return _rectBrush;
            }
            set
            {
                _rectBrush = value;
            }
        }

        /// <summary>
        /// 整体区域画笔
        /// </summary>
        public Pen RectBorderPen
        {
            get
            {
                return _rectBorderPen;
            }
            set
            {
                _rectBorderPen = value;
            }
        }

        /// <summary>
        /// 图表区域画笔
        /// </summary>
        public Pen MainRectBorderPen
        {
            get
            {
                return _mainRectBorderPen;
            }
            set
            {
                _mainRectBorderPen = value;
            }
        }

        /// <summary>
        /// 网格区域线条画笔
        /// </summary>
        public Pen GridLinePen
        {
            get
            {
                return _gridLinePen;
            }
            set
            {
                _gridLinePen = value;
            }
        }

        /// <summary>
        /// 网格区域文本画刷
        /// </summary>
        public Brush GridTextBrush
        {
            get
            {
                return _gridTextBrush;
            }
            set
            {
                _gridTextBrush = value;
            }
        }

        /// <summary>
        /// 备注区域线条画笔
        /// </summary>
        public Pen MemoLinePen
        {
            get
            {
                return _memoLinePen;
            }
            set
            {
                _memoLinePen = value;
            }
        }

        /// <summary>
        /// 备注区域文本画刷
        /// </summary>
        public Brush MemoTextBrush
        {
            get
            {
                return _memoTextBrush;
            }
            set
            {
                _memoTextBrush = value;
            }
        }

        /// <summary>
        /// 区域
        /// </summary>
        public Rectangle Rect, MainRect, GridRect, MemoRect;

        /// <summary>
        /// 网格显示行数
        /// </summary>
        public int GirdRowCounts = 10;

        /// <summary>
        /// 网格和备注标题
        /// </summary>
        public string SummeryTitle = "体液平衡总计", MemoTitle = "备注", SubTitle = "合计";

        /// <summary>
        /// 网格行类型标题宽度
        /// </summary>
        public float GridDataTypeHeadWidth = 30;

        /// <summary>
        /// 网格行类型标题
        /// </summary>
        public string[] DataTypeTitles = new string[] { "入量", "出量" };

        /// <summary>
        /// 垂直滚动位移
        /// </summary>
        public float HShiftPos = 20.0f, HScrollPos = 0;

        /// <summary>
        /// 字体
        /// </summary>
        public Font Font = new Font("宋体", 9);

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width = 100;

        /// <summary>
        /// 高度
        /// </summary>
        public int Height = 100;

        /// <summary>
        /// 网格最大显示行数
        /// </summary>
        public int MaxGirdRowCounts
        {
            get
            {
                return _maxgirdRowCounts;
            }
            set
            {
                if (value >= 0) _maxgirdRowCounts = value;
            }
        }

        /// <summary>
        /// 网格高度百分比
        /// </summary>
        public float GridHeightPercent
        {
            get
            {
                return _gridHeightPercent;
            }
            set
            {
                if ((value >= 0) && (value < 1))
                {
                    _gridHeightPercent = value;
                }
            }
        }

        /// <summary>
        /// 注行高度百分比
        /// </summary>
        public float MemoHeightPercent
        {
            get
            {
                return _memoHeightPercent;
            }
            set
            {
                if ((value >= 0) && (value < 1))
                {
                    _memoHeightPercent = value;
                }
            }
        }

        /// <summary>
        /// 是否画图例
        /// </summary>
        public bool IsDrawLegend
        {
            get
            {
                return _drawlegend;
            }
            set
            {
                _drawlegend = value;
            }
        }

        /// <summary>
        /// 滚动条宽度
        /// </summary>
        public int HScrollWidth
        {
            get
            {
                return _hscrollwidth;
            }
            set
            {
                if (value >= 0)
                {
                    _hscrollwidth = value;
                }
            }
        }

        /// <summary>
        /// 需要绘制坐标网格
        /// </summary>
        public bool HasAxisGridLine
        {
            get
            {
                return _hasAxisGridLine;
            }
            set
            {
                _hasAxisGridLine = value;
            }
        }

        /// <summary>
        /// X坐标标题在顶部
        /// </summary>
        public bool XAxisTitleAtTop
        {
            get
            {
                return _xAxisTitleAtTop;
            }
            set
            {
                _xAxisTitleAtTop = value;
            }
        }

        /// <summary>
        /// Y坐标标题位移
        /// </summary>
        public float YAxisTitleOffset
        {
            get
            {
                return _yAxisTitleOffset;
            }
            set
            {
                _yAxisTitleOffset = value;
            }
        }

        #endregion 属性

        #region 方法

        #region 方法 - AddCurve

        public MedCurve addCurve(string title, MedPointList points)
        {
            MedCurve curve = new MedCurve(points);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points)
        {
            return addCurve("", points);
        }

        public MedCurve addCurve(string title, MedPointList points, MedSymbol symbol, Pen pen, int xaxisindex, int yaxisindex)
        {
            MedCurve curve = new MedCurve(points, xaxisindex, yaxisindex, symbol, pen);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, MedSymbol symbol, Pen pen, int xaxisindex, int yaxisindex)
        {
            return addCurve("", points, symbol, pen, xaxisindex, yaxisindex);
        }

        public MedCurve addCurve(string title, MedPointList points, MedSymbol symbol, Pen pen)
        {
            return addCurve(title, points, symbol, pen, 0, 0);
        }

        public MedCurve addCurve(MedPointList points, MedSymbol symbol, Pen pen)
        {
            return addCurve("", points, symbol, pen);
        }

        public MedCurve addCurve(string title, MedPointList points, Image image, Color color, int xaxisindex, int yaxisindex)
        {
            MedCurve curve = new MedCurve(points, xaxisindex, yaxisindex, new MedSymbol(image), new Pen(color));
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, Image image, Color color, int xaxisindex, int yaxisindex)
        {
            return addCurve("", points, image, color, xaxisindex, yaxisindex);
        }

        public MedCurve addCurve(string title, MedPointList points, string imageFileName, Color color, int xaxisindex, int yaxisindex)
        {
            return addCurve(title, points, Image.FromFile(imageFileName), color, xaxisindex, yaxisindex);
        }

        public MedCurve addCurve(MedPointList points, string imageFileName, Color color, int xaxisindex, int yaxisindex)
        {
            return addCurve("", points, imageFileName, color, xaxisindex, yaxisindex);
        }

        public MedCurve addCurve(string title, MedPointList points, Image image, Color color)
        {
            MedCurve curve = new MedCurve(points, image, color);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, Image image, Color color)
        {
            return addCurve("", points, image, color);
        }

        public MedCurve addCurve(string title, MedPointList points, string imageFileName, Color color)
        {
            return addCurve(title, points, Image.FromFile(imageFileName), color);
        }

        public MedCurve addCurve(MedPointList points, string imageFileName, Color color)
        {
            return addCurve("", points, imageFileName, color);
        }

        public MedCurve addCurve(string title, MedPointList points, Image image)
        {
            MedCurve curve = new MedCurve(points, image);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, Image image)
        {
            return addCurve("", points, image);
        }

        public MedCurve addCurve(string title, MedPointList points, string imageFileName)
        {
            return addCurve(title, points, Image.FromFile(imageFileName));
        }

        public MedCurve addCurve(MedPointList points, string imageFileName)
        {
            return addCurve("", points, imageFileName);
        }

        public MedCurve addCurve(string title, MedPointList points, Color color)
        {
            MedCurve curve = new MedCurve(points, color);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, Color color)
        {
            return addCurve("", points, color);
        }

        #endregion 方法 - AddCurve

        #region 方法 - addRow

        public MedGridRow addRow(string title, Pen pen, int datatype, MedPointList points)
        {
            MedGridRow row = new MedGridRow();
            row.Pen = pen;
            row.Title = title;
            row.DataType = datatype;
            row.Points = points;
            _rowList.Add(row, datatype);
            return row;
        }

        public MedGridRow addRow(string title, Pen pen, int datatype)
        {
            return addRow(title, pen, datatype, null);
        }

        public MedGridRow addRow(string title, int datatype)
        {
            return addRow(title, new Pen(Color.Black), datatype);
        }

        public MedGridRow addRow(string title)
        {
            return addRow(title, 0);
        }

        #endregion 方法 - addRow

        #region 计算方法

        /// <summary>
        /// 计算总数-某行
        /// </summary>
        /// <param name="row"></param>
        /// <param name="minvalue"></param>
        /// <param name="maxvalue"></param>
        /// <returns></returns>
        public double Summery(MedGridRow row, double minvalue, double maxvalue)
        {
            double sum = 0;
            foreach (MedPoint point in row.Points)
            {
                if ((point.X >= minvalue) && (point.X < maxvalue)) sum += point.Y;
            }
            return sum;
        }

        /// <summary>
        /// 计算总数-出量或者入量
        /// </summary>
        /// <param name="typeindex">类型：0-入量 1-出量</param>
        /// <param name="minvalue"></param>
        /// <param name="maxvalue"></param>
        /// <returns></returns>
        public double Summery(int typeindex, double minvalue, double maxvalue)
        {
            double sum = 0;
            for (int i = 0; i < _rowList.CountOfType(typeindex); i++) sum += Summery(_rowList[i, typeindex], minvalue, maxvalue);
            return sum;
        }

        /// <summary>
        /// 计算总数-出入量
        /// </summary>
        /// <param name="minvalue"></param>
        /// <param name="maxvalue"></param>
        /// <returns></returns>
        public double Summery(double minvalue, double maxvalue)
        {
            return Summery(0, minvalue, maxvalue) - Summery(1, minvalue, maxvalue);
        }

        #endregion 计算方法

        /// <summary>
        /// 初始化区域-填充底色和绘制边框
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="rect">区域</param>
        /// <param name="brush">填充画刷</param>
        /// <param name="pen">点线文字画笔</param>
        /// <param name="drawrect">是否画边框</param>
        public void InitRect(Graphics g, Rectangle rect, Brush brush, Pen pen, bool drawrect)
        {
            g.FillRectangle(brush, rect);
            if (drawrect) g.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// 初始化区域-填充底色和绘制边框
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="rect">区域</param>
        /// <param name="color1">填充渐变色起始颜色</param>
        /// <param name="color2">填充渐变色结束颜色</param>
        /// <param name="angle">填充渐变色变化角度</param>
        /// <param name="pen">点线文字画笔</param>
        /// <param name="drawrect">是否画边框</param>
        public void InitRect(Graphics g, Rectangle rect, Color color1, Color color2, float angle, Pen pen, bool drawrect)
        {
            InitRect(g, rect, new LinearGradientBrush(rect, color1, color2, angle), pen, drawrect);
        }

        /// <summary>
        /// 画图例
        /// </summary>
        /// <param name="g">作图对象</param>
        public void DrawLegend(Graphics g)
        {
            InitRect(g, _legend.Rect, _legend.Brush, _legend.Pen, _legend.HasBorder);

            int i = 0, k = 0, curveIndex = 0, j = 0;
            int[] topOffSet = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            ///曲线索引
            int index = -1;

            _legend.ItemRects.Clear();

            ///图例依赖于曲线
            foreach (MedCurve curve in _curveList)
            {
                index++;
                if (!string.IsNullOrEmpty(curve.LegendTitle))
                {
                    Rectangle rect = new Rectangle();
                    if (_legend.AlignYAxis)
                    {
                        curveIndex = (_YaxisList.Count - curve.YAxisIndex - 1);
                        rect.X = _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount - 2;
                        rect.Y = topOffSet[curveIndex] * 25 + _legend.Rect.Y + 3;
                        rect.Height = (int)(topOffSet[curveIndex] * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height) - rect.Y + 9;
                    }
                    else
                    {
                        rect.X = _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount - 2;
                        rect.Y = j * 25 + _legend.Rect.Y + 3;
                        rect.Height = (int)g.MeasureString("A", this.Font).Height;
                    }
                    rect.Width = (int)g.MeasureString(curve.Title, this.Font).Width + 2;
                    _legend.ItemRects.Add(rect);

                    ///画某图例边框
                    if (_legend.ItemRectIndex == k++) g.DrawRectangle(Pens.LightGray, rect);

                    //if (!((index > 0) && curve.LegendTitle.Equals(_curveList[index - 1].LegendTitle)))
                    {
                        ///画图例标题
                        if (_legend.AlignYAxis)
                        {
                            g.DrawString(curve.LegendTitle, this.Font, curve.Pen.Brush, _legend.Rect.X + curveIndex * _legend.Rect.Width / _legend.ColCount, topOffSet[curveIndex] * 25 + _legend.Rect.Y + 5);
                        }
                        else
                        {
                            g.DrawString(curve.LegendTitle, this.Font, curve.Pen.Brush, _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount, j * 25 + _legend.Rect.Y + 5);
                        }
                        ///画图例标识
                        //if ((index < _curveList.Count - 1) && curve.LegendTitle.Equals(_curveList[index + 1].LegendTitle))
                        //{
                        //    //curve.Symbol.Draw(g, _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.Title, this.Font).Width / 2 - 16, j * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                        //    //_curveList[index + 1].Symbol.Draw(g, _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.Title, this.Font).Width / 2 - 2, j * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                        //    curve.Symbol.Draw(g, _legend.Rect.X + curveIndex * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.LegendTitle, this.Font).Width / 2 - 4, topOffSet[curveIndex] * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                        //    i--;
                        //}
                        //else
                        {
                            if (_legend.AlignYAxis)
                            {
                                curve.Symbol.Draw(g, _legend.Rect.X + curveIndex * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.LegendTitle, this.Font).Width / 2 - 4, topOffSet[curveIndex] * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                            }
                            else
                            {
                                curve.Symbol.Draw(g, _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.Title, this.Font).Width / 2 - 4, j * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                            }
                        }
                    }
                    if (_legend.AlignYAxis)
                    {
                        topOffSet[curveIndex]++;
                    }
                    else
                    {
                        i++;
                        ///换行
                        if (i > _legend.ColCount - 1)
                        {
                            i = 0;
                            //j++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绘制曲线
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="leftOffSet">横向位移</param>
        /// <param name="topOffSet">纵向位移</param>
        public void DrawCurves(Graphics g, int leftOffSet, int topOffSet)
        {
            float xx, yy, xx1 = 0, yy1 = 0, barCount = 0, barIndex = 0, barWidth = 0;

            for (int i = 0; i < _curveList.Count; i++)
            {
                if (((MedCurve)_curveList[i]).IsBar)
                {
                    barCount++;
                    if (barWidth <= 0) barWidth = ((MedCurve)_curveList[i]).BarWidth;
                }
            }

            for (int i = 0; i < _curveList.Count; i++)
            {
                MedCurve curve = (MedCurve)_curveList[i];
                MedPointList points = curve.Points;

                ///画曲线的每个点
                for (int j = 0; j < points.Count; j++)
                {
                    xx = TranslateX(points[j].X, curve.XAxisIndex);
                    yy = TranslateY(points[j].Y, curve.YAxisIndex);

                    ///图柱状图
                    if (curve.IsBar)
                    {
                        g.DrawRectangle(curve.Pen, xx + leftOffSet - (barWidth * barCount / 2) + barIndex * barWidth, yy + topOffSet, barWidth, MainRect.Bottom - yy - topOffSet);
                        g.FillRectangle(new SolidBrush(curve.Pen.Color), xx + leftOffSet - (barWidth * barCount / 2) + barIndex * barWidth, yy + topOffSet, barWidth, MainRect.Bottom - yy - topOffSet);
                    }

                    ///画折线图
                    else
                    {
                        if (j > 0)
                        {
                            if (curve.hasLine)
                            {
                                ///绘制连线
                                g.DrawLine(curve.Pen, xx1 + leftOffSet, yy1 + topOffSet, xx + leftOffSet, yy + topOffSet);
                            }
                        }
                        if (points[j].Symbol != null)
                        {
                            ///绘制点标识
                            points[j].Symbol.Draw(g, xx + leftOffSet, yy + topOffSet);
                        }
                        else if (curve.Symbol.SymbolType != MedSymbolType.None)
                        {
                            ///绘制曲线点标识
                            curve.Symbol.Draw(g, xx + leftOffSet, yy + topOffSet);
                        }
                        xx1 = xx;
                        yy1 = yy;
                    }
                }///画曲线的每个点

                if (curve.IsBar) barIndex++;

            }
        }

        /// <summary>
        /// 画数据网格-出入量
        /// </summary>
        /// <param name="g">作图对象</param>
        public void DrawGrid(Graphics g)
        {
            if (_graphControl.CustomDrawGridEventHandle != null)
            {
                _graphControl.CustomDrawGridEventHandle(g, GridRect);
                return;
            }

            InitRect(g, new Rectangle(Rect.X, GridRect.Y, Rect.Width, GridRect.Height), Brushes.White, _gridLinePen, false);

            ///X坐标轴刻度值数量
            int _count = (int)((_XaxisList[0].Max - _XaxisList[0].Min) / (_XaxisList[0].Step));

            ///画X坐标轴刻度线
            for (int i = 0; i <= _count; i++)
            {
                float _X = GridRect.X + i * GridRect.Width / _count;
                //g.DrawLine(GridPen, _X, GridRect.Y, _X, GridRect.Y + GridRect.Height);
                ///画竖线
                DrawAxisGrid(g, new Rectangle((int)_X, GridRect.Y, (int)(GridRect.Width / _count), (_rowList.Count) * GridRect.Height / GirdRowCounts), _XaxisList.MinSetp, true, _gridLinePen);
            }

            ///画起始横线
            g.DrawLine(_gridLinePen, Rect.X, GridRect.Y, GridRect.X + GridRect.Width, GridRect.Y);

            ///行高
            float _H = GridRect.Height / GirdRowCounts;

            ///行起点Y坐标
            float _Y = GridRect.Y + _H;

            float oldY = GridRect.Y;

            ///画出入量
            for (int i = 0; i < _rowList.TypeCount; i++)
            {
                ///j=0：入量 j=1：出量
                for (int j = 0; j < _rowList.CountOfType(i); j++)
                {

                    g.DrawLine(_gridLinePen, Rect.X + GridDataTypeHeadWidth, _Y, GridRect.X + GridRect.Width, _Y);

                    ///写出入量明细类别标题
                    g.DrawString(_rowList[j, i].Title, Font, _rowList[j, i].Pen.Brush, Rect.X + GridDataTypeHeadWidth, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2);

                    ///写出量或者入量汇总值
                    for (int k = 0; k < _count; k++)
                    {
                        for (int kk = 0; kk < _XaxisList.MinSetp; kk++)
                        {
                            double sum = Summery(_rowList[j, i], _XaxisList[0].Min + k * _XaxisList[0].Step + kk * _XaxisList[0].Step / _XaxisList.MinSetp, _XaxisList[0].Min + k * _XaxisList[0].Step + (kk + 1) * _XaxisList[0].Step / _XaxisList.MinSetp);
                            if (sum != 0) g.DrawString(sum.ToString(), this.Font, _rowList[j, i].Pen.Brush, new RectangleF(MainRect.X + k * GridRect.Width / _count + kk * GridRect.Width / _count / _XaxisList.MinSetp, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2, GridRect.Width / _count / _XaxisList.MinSetp, g.MeasureString("A", this.Font).Height));
                        }
                    }

                    _Y += _H;
                }

                ///画横线
                g.DrawLine(_gridLinePen, Rect.X, _Y, GridRect.X + GridRect.Width, _Y);

                ///写入量或者出量合计标题
                if (_rowList.Count > 3)
                {
                    try
                    {
                        g.DrawString(DataTypeTitles[i] + SubTitle, this.Font, _rowList[0, i].Pen.Brush, Rect.X + GridDataTypeHeadWidth, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2);
                    }
                    catch { }
                }
                else
                {
                    g.DrawString(DataTypeTitles[i] + SubTitle, this.Font, _gridTextBrush, Rect.X + GridDataTypeHeadWidth, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2);
                }

                ///写出入量总汇总值
                for (int k = 0; k < _count; k++)
                {
                    for (int kk = 0; kk < _XaxisList.MinSetp; kk++)
                    {
                        double sum = Summery(i, _XaxisList[0].Min + k * _XaxisList[0].Step + kk * _XaxisList[0].Step / _XaxisList.MinSetp, _XaxisList[0].Min + k * _XaxisList[0].Step + (kk + 1) * _XaxisList[0].Step / _XaxisList.MinSetp);
                        if (sum != 0) g.DrawString(sum.ToString(), this.Font, _gridTextBrush, new RectangleF(MainRect.X + k * GridRect.Width / _count + kk * GridRect.Width / _count / _XaxisList.MinSetp, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2, GridRect.Width / _count / _XaxisList.MinSetp, g.MeasureString("A", this.Font).Height));
                    }
                }

                ///画汇总栏背景
                InitRect(g, new Rectangle(Rect.X, (int)oldY, (int)GridDataTypeHeadWidth, (int)(_Y - oldY)), Color.FromArgb(235, 242, 248), Color.FromArgb(213, 229, 242), 0, _gridLinePen, true);

                ///写出量或者入量整体标题
                g.DrawString(DataTypeTitles[i], this.Font, _gridTextBrush, Rect.X + (GridDataTypeHeadWidth - g.MeasureString(DataTypeTitles[i], this.Font).Width) / 2, (oldY + _Y - g.MeasureString("A", this.Font).Height) / 2);

                oldY = _Y;
                _Y += _H;
            }

            ///写汇总值
            g.DrawString(SummeryTitle, this.Font, _gridTextBrush, Rect.X, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2);
            for (int k = 0; k < _count; k++)
            {
                for (int kk = 0; kk < _XaxisList.MinSetp; kk++)
                {
                    try
                    {
                        double sum = Summery(_XaxisList[0].Min + k * _XaxisList[0].Step + kk * _XaxisList[0].Step / _XaxisList.MinSetp, _XaxisList[0].Min + k * _XaxisList[0].Step + (kk + 1) * _XaxisList[0].Step / _XaxisList.MinSetp);
                        if (sum != 0) g.DrawString(sum.ToString(), this.Font, _gridTextBrush, new RectangleF(MainRect.X + k * GridRect.Width / _count + kk * GridRect.Width / _count / _XaxisList.MinSetp, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2, GridRect.Width / _count / _XaxisList.MinSetp, g.MeasureString("A", this.Font).Height));
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// 画X坐标轴
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="rect">作图区域</param>
        /// <param name="pen">画笔</param>
        /// <param name="gridPen">网格画笔</param>
        /// <param name="index">坐标轴索引</param>
        /// <param name="minstep">最小分割</param>
        /// <param name="axis">坐标轴</param>
        public void DrawXAxis(Graphics g, Rectangle rect, Pen pen, Pen gridPen, int index, int minstep, MedAxis axis, int leftOffSet, int topOffSet)
        {
            int _count = (int)((axis.Max - axis.Min) / (axis.Step));
            if (_count == 0)
                return;

            for (int i = 0; i <= _count; i++)
            {
                float _X = rect.X + i * rect.Width / _count;

                if (index == 0)
                {
                    if ((_hasAxisGridLine) || (i == 0))
                    {
                        g.DrawLine(pen, _X + leftOffSet, rect.Y + topOffSet, _X + leftOffSet, rect.Y + topOffSet + rect.Height);
                    }
                    else
                    {
                        g.DrawLine(pen, _X + leftOffSet, rect.Y + topOffSet + rect.Height - 10, _X + leftOffSet, rect.Y + topOffSet + rect.Height);
                    }

                    if ((i < _count) && _hasAxisGridLine)
                    {
                        DrawAxisGrid(g, new Rectangle((int)_X + leftOffSet, rect.Y + topOffSet, (int)(rect.Width / _count), rect.Height), minstep, true, gridPen);
                    }
                }
            }
        }

        /// <summary>
        /// 绘制Y坐标轴
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="rect">区域</param>
        /// <param name="pen">画笔</param>
        /// <param name="gridPen">网格画笔</param>
        /// <param name="index">坐标轴索引</param>
        /// <param name="minstep">最小刻度</param>
        /// <param name="axis">坐标轴</param>
        public void DrawYAxis(Graphics g, Rectangle rect, Pen pen, Pen gridPen, int index, int minstep, MedAxis axis, int leftOffSet, int topOffSet)
        {
            ///刻度数量
            int _count = (int)((axis.Max - axis.Min) / (axis.Step));

            for (int i = 0; i <= _count; i++)
            {
                float _Y = rect.Y + i * rect.Height / _count;

                ///只绘制一次
                if (index == 0)
                {
                    if (_gridHeightPercent > 0)
                    {
                        g.DrawLine(pen, rect.X + leftOffSet, _Y + topOffSet, rect.X + rect.Width + leftOffSet, _Y + topOffSet);

                        ///绘制网格
                        if ((i < _count) && (_hasAxisGridLine))
                        {
                            DrawAxisGrid(g, new Rectangle(rect.X + leftOffSet, (int)_Y + topOffSet, rect.Width, (int)(rect.Height / _count)), minstep, false, gridPen);
                        }
                    }
                    else
                    {
                        if ((_hasAxisGridLine) || (i == _count))
                        {
                            g.DrawLine(pen, rect.X + leftOffSet, _Y + topOffSet - i - 1, rect.X + rect.Width + leftOffSet, _Y + topOffSet - i - 1);
                        }
                        else
                        {
                            g.DrawLine(pen, rect.X + leftOffSet, _Y + topOffSet - i - 1, rect.X + 5 + leftOffSet, _Y + topOffSet - i - 1);
                        }

                        ///绘制网格
                        if ((i < _count) && (_hasAxisGridLine))
                        {
                            DrawAxisGrid(g, new Rectangle(rect.X + leftOffSet, (int)_Y + topOffSet - i - 1, rect.Width, (int)(rect.Height / _count) - 1), minstep, false, gridPen);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绘制刻度值标题
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="rect">区域</param>
        /// <param name="pen">画笔</param>
        /// <param name="gridPen">网格画笔</param>
        /// <param name="index">坐标轴索引</param>
        /// <param name="minstep">最小刻度</param>
        /// <param name="axis">坐标轴</param>
        public void DrawYAxisTitle(Graphics g, Rectangle rect, Pen pen, Pen gridPen, int index, int minstep, MedAxis axis, int leftOffSet, int topOffSet)
        {
            ///刻度数量
            int _count = (int)((axis.Max - axis.Min) / (axis.Step));

            for (int i = 0; i <= _count; i++)
            {
                float _Y = rect.Y + i * rect.Height / _count;

                /////绘制刻度值标题
                float _V = (axis.Max - axis.Step * i);
                SizeF _sizeF = g.MeasureString(_V.ToString(), axis.Font);
                SizeF _sizeF1 = g.MeasureString("1000", axis.Font);

                ///有网格
                if (_gridHeightPercent > 0)
                {
                    if (i < _count)
                    {
                        g.DrawString(_V.ToString(), axis.Font, axis.Brush, rect.X + leftOffSet - _sizeF.Width - index * _sizeF1.Width - 15 + _yAxisTitleOffset, _Y + topOffSet - _sizeF.Height / 2);
                    }
                }
                ///无网格
                else
                {
                    if ((i > 0) && (i < _count))
                    {
                        g.DrawString(_V.ToString(), axis.Font, axis.Brush, rect.X + leftOffSet - _sizeF.Width - index * _sizeF1.Width - 15, _Y + topOffSet - _sizeF.Height / 2 - i - 1);
                    }
                    else if (i > 0)
                    {
                        g.DrawString(_V.ToString(), axis.Font, axis.Brush, rect.X + leftOffSet - _sizeF.Width - index * _sizeF1.Width - 15, _Y + topOffSet - _sizeF.Height - 2);
                    }
                    else
                    {
                        g.DrawString(_V.ToString(), axis.Font, axis.Brush, rect.X + leftOffSet - _sizeF.Width - index * _sizeF1.Width - 15, _Y + topOffSet - 2);
                    }
                }

            }
        }

        /// <summary>
        /// 画坐标轴网格
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="rect">作图区域</param>
        /// <param name="gridcount">坐标数</param>
        /// <param name="isXaxis">是否X坐标</param>
        /// <param name="pen">画笔</param>
        private void DrawAxisGrid(Graphics g, Rectangle rect, int gridcount, bool isXaxis, Pen pen)
        {
            if (isXaxis)
                for (int i = 0; i < gridcount; i++)
                {
                    float _X = rect.X + i * rect.Width / gridcount;
                    g.DrawLine(pen, _X, rect.Y, _X, rect.Y + rect.Height);
                }
            else
                for (int i = 0; i < gridcount; i++)
                {
                    float _Y = rect.Y + i * rect.Height / gridcount;
                    g.DrawLine(pen, rect.X, _Y, rect.X + rect.Width, _Y);
                }
        }

        /// <summary>
        /// 绘制坐标轴
        /// </summary>
        /// <param name="g">作图对象</param>
        public void DrawAxises(Graphics g, bool hadYAxisCaption, int leftOffSet, int topOffSet)
        {
            ///画Y坐标
            for (int i = 0; i < _YaxisList.Count; i++)
            {
                DrawYAxis(g, MainRect, _YaxisList.Pen, _YaxisList.MinPen, i, _YaxisList.MinSetp, _YaxisList[i], leftOffSet, topOffSet);
                if (hadYAxisCaption)
                {
                    DrawYAxisTitle(g, MainRect, _YaxisList.Pen, _YaxisList.MinPen, i, _YaxisList.MinSetp, _YaxisList[i], leftOffSet, topOffSet);
                }
            }

            ///画X坐标
            for (int i = 0; i < _XaxisList.Count; i++)
            {
                DrawXAxis(g, MainRect, _XaxisList.Pen, _XaxisList.MinPen, i, _XaxisList.MinSetp, _XaxisList[i], leftOffSet, topOffSet);
            }

        }

        /// <summary>
        /// 画备注区
        /// </summary>
        /// <param name="g">作图对象</param>
        public void DrawMemo(Graphics g)
        {
            if (MemoHeightPercent < 0.05f) return;
            InitRect(g, new Rectangle(Rect.X, MemoRect.Y, Rect.Width, MemoRect.Height), Color.FromArgb(235, 242, 248), Color.FromArgb(213, 229, 242), 90, _memoLinePen, true);
            g.DrawLine(_memoLinePen, MemoRect.X, MemoRect.Y, MemoRect.X, MemoRect.Y + MemoRect.Height);
            g.DrawString(MemoTitle, this.Font, _memoTextBrush, Rect.X + 5, MemoRect.Y + (MemoRect.Height - g.MeasureString(MemoTitle, this.Font).Height) / 2);
            if (_graphControl.CustomDrawMemoEventHandle != null)
            {
                _graphControl.CustomDrawMemoEventHandle(g, MemoRect);
            }
        }

        /// <summary>
        /// 计算主区域
        /// </summary>
        /// <param name="g">作图对象</param>
        public void CalcMainRect(Graphics g)
        {
            ///整个图表区域
            Rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            ///图表上部分区域(曲线区)
            MainRect = new Rectangle();
            MainRect.X = LeftMargin + (int)YAxisList.Width(g);
            MainRect.Y = TopMargin + (_xAxisTitleAtTop ? (int)XAxisList.Height(g) : 0);
            MainRect.Width = Rect.Width - MainRect.X - RightMargin - _hscrollwidth;
            MainRect.Height = (int)((Rect.Height - MainRect.Y - BottomMargin) * (1 - GridHeightPercent));

            ///网格区域
            if (GridHeightPercent > 0)
            {
                GridRect = new Rectangle(MainRect.X, MainRect.Y + MainRect.Height, MainRect.Width, (int)(((Rect.Height - MainRect.Y - BottomMargin) - MainRect.Height) * (1 - MemoHeightPercent)));
                MemoRect = new Rectangle(GridRect.X, GridRect.Y + GridRect.Height, Rect.Width - GridRect.X, (Rect.Height - MainRect.Y - BottomMargin) - MainRect.Height - GridRect.Height);
            }

            ///网格行数
            GirdRowCounts = (MaxGirdRowCounts > RowList.Count) ? RowList.Count : MaxGirdRowCounts;

        }

        /// <summary>
        /// X坐标转换
        /// </summary>
        /// <param name="X"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public float TranslateX(double X, int index)
        {
            return (MainRect.X + ((float)X - _XaxisList[index].Min) * (MainRect.Width) / (_XaxisList[index].Max - _XaxisList[index].Min));
        }

        /// <summary>
        /// Y坐标转换
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public float TranslateY(double Y, int index)
        {
            return (MainRect.Y + MainRect.Height - ((float)Y - _YaxisList[index].Min) * (MainRect.Height) / (_YaxisList[index].Max - _YaxisList[index].Min));
        }

        /// <summary>
        /// 整体作图
        /// </summary>
        /// <param name="g">作图对象</param>
        public void DrawGraph(Graphics g)
        {
            ///重新计算区域
            CalcMainRect(g);

            InitRect(g, Rect, RectBrush, RectBorderPen, true);

            ///整体图像
            using (Image imageAll = new Bitmap(this.Width, this.Height + (RowList.Count) * GridRect.Height / GirdRowCounts))
            {
                ///图表上部分区域(曲线区) + 网格区
                using (Image imageMainAndGrid = new Bitmap(this.Width, MainRect.Height + GridRect.Height + ((TopMargin > 5) ? TopMargin - 5 : TopMargin)))
                {
                    ///整体图像作图对象
                    using (Graphics graphicsAll = Graphics.FromImage(imageAll))
                    {
                        ///保正曲线平整流畅
                        graphicsAll.SmoothingMode = SmoothingMode.AntiAlias;

                        ///图表上部分区域(曲线区) + 网格区作图对象
                        using (Graphics graphicsMainAndGrid = Graphics.FromImage(imageMainAndGrid))
                        {
                            ///初始化区域
                            InitRect(graphicsAll, MainRect, MainRectBrush, MainRectBorderPen, false);

                            ///画坐标轴
                            DrawAxises(graphicsAll, false, 0, 0);

                            ///画曲线
                            DrawCurves(graphicsAll, 0, 0);

                            ///画Y坐标背景
                            InitRect(graphicsAll, new Rectangle(Rect.X, Rect.Y, MainRect.X - Rect.X, MainRect.Y + MainRect.Height - Rect.Y),
                                Color.FromArgb(243, 243, 243), Color.White, 90, new Pen(Color.Black), false);

                            for (int i = 0; i < _YaxisList.Count; i++)
                            {
                                DrawYAxisTitle(graphicsAll, MainRect, _YaxisList.Pen, _YaxisList.MinPen, i, _YaxisList.MinSetp, _YaxisList[i], 10, 0);
                            }

                            ///画网格
                            if (GridHeightPercent > 0.0f)
                            {
                                DrawGrid(graphicsAll);
                                DrawMemo(g);
                            }

                            ///绘制可当前可显示部分
                            graphicsMainAndGrid.DrawImage(imageAll, 0, HScrollPos - MainRect.Y + TopMargin);

                            ///画图例
                            if (IsDrawLegend)
                            {
                                _legend.Rect = new Rectangle(_legend.Rect.X, (int)HScrollPos, _legend.Rect.Width, _legend.Rect.Height);
                                DrawLegend(graphicsMainAndGrid);
                            }

                            ///根据滚动条计算位移并绘制
                            g.DrawImage(imageMainAndGrid, 0, HShiftPos);

                            ///画X坐标值
                            int _count = (int)((XAxisList[0].Max - XAxisList[0].Min) / (XAxisList[0].Step));
                            if (_count == 0)
                                return;
                            for (int i = 0; i <= _count; i++)
                            {
                                float _X = MainRect.X + i * MainRect.Width / _count;
                                float _V = (XAxisList[0].Min + XAxisList[0].Step * i);
                                string s;
                                if (XAxisList[0].TextFormat.Equals("HH:mm"))
                                {
                                    if (_V > 24) _V -= 24;
                                    DateTime dt = Converter.HourToHHMM(_V);
                                    if (dt.Second >= 30) dt = dt.AddMinutes(1);
                                    s = dt.ToString("HH:mm");
                                }
                                else if (XAxisList[0].TextFormat.Equals("day"))
                                {
                                    if (XAxisList[0].Month == 0 && _V > DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                                        _V -= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                                    else if (XAxisList[0].Month > 0 && _V > DateTime.DaysInMonth(DateTime.Now.Year, XAxisList[0].Month))
                                        _V -= DateTime.DaysInMonth(DateTime.Now.Year, XAxisList[0].Month);
                                    double hours = (_V - (int)_V) * 24;
                                    if (hours != 0)
                                        //s = ((int)_V).ToString() + "-" + (int)hours;
                                        s = "";
                                    else
                                        s = _V.ToString();
                                }
                                else
                                {
                                    s = _V.ToString();
                                }
                                SizeF _sizeF = g.MeasureString(s, XAxisList[0].Font);
                                SizeF _sizeF1 = g.MeasureString("1000", XAxisList[0].Font);
                                if (_xAxisTitleAtTop)
                                {
                                    if ((_gridHeightPercent > 0) && (i == 0))
                                    {
                                        g.DrawString(s, XAxisList[0].Font, XAxisList[0].Brush, _X - _sizeF.Width / 2 + 12, MainRect.Y - _sizeF.Height - 5);
                                    }
                                    else
                                    {
                                        g.DrawString(s, XAxisList[0].Font, XAxisList[0].Brush, _X - _sizeF.Width / 2, MainRect.Y - _sizeF.Height - 5);
                                    }
                                }
                                else
                                {
                                    if ((_gridHeightPercent > 0) && (i == 0))
                                    {
                                        g.DrawString(s, XAxisList[0].Font, XAxisList[0].Brush, _X - _sizeF.Width / 2 + 12, MainRect.Y + MainRect.Height);
                                    }
                                    else
                                    {
                                        g.DrawString(s, XAxisList[0].Font, XAxisList[0].Brush, _X - _sizeF.Width / 2, MainRect.Y + MainRect.Height);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion 方法


        #region IDisposable 成员

        public void Dispose()
        {
            if (Font != null)
            {
                Font.Dispose();
            }

            if (_legend != null)
            {
                _legend.Dispose();
            }
        }

        #endregion
    }
}
