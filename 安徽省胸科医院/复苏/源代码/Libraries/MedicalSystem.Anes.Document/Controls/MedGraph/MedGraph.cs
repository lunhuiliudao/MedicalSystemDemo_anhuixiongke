/*----------------------------------------------------------------
      // Copyright (C) 2005 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedGraph.cs
      // 文件功能描述：图表控件
      //
      // 
      // 创建标识：戴呈祥-2007-12-20
----------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(false)]
    public partial class MedGraph : UserControl
    {

        public delegate void CustomDrawGridEvent(Graphics graphics, Rectangle gridRect);
        public delegate void CustomDrawMemoEvent(Graphics graphics, Rectangle memoRect);

        private static readonly object _customDrawGridEventHandle = new object();
        private static readonly object _customDrawMemoEventHandle = new object();

        /// <summary>
        /// 自画备注事件
        /// </summary>
        [Description("自画备注事件")]
        public event CustomDrawMemoEvent CustomDrawMemo
        {
            add
            {
                Events.AddHandler(_customDrawMemoEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_customDrawMemoEventHandle, value);
            }
        }

        /// <summary>
        /// 自画备注事件句柄
        /// </summary>
        public CustomDrawMemoEvent CustomDrawMemoEventHandle
        {
            get
            {
                return (CustomDrawMemoEvent)Events[_customDrawMemoEventHandle];
            }
        }

        /// <summary>
        /// 自画表格事件
        /// </summary>
        [Description("自画表格事件")]
        public event CustomDrawGridEvent CustomDrawGrid
        {
            add
            {
                Events.AddHandler(_customDrawGridEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_customDrawGridEventHandle, value);
            }
        }

        /// <summary>
        /// 自画表格事件句柄
        /// </summary>
        public CustomDrawGridEvent CustomDrawGridEventHandle
        {
            get
            {
                return (CustomDrawGridEvent)Events[_customDrawGridEventHandle];
            }
        }

        #region 私有变量

        /// <summary>
        /// 图表主体
        /// </summary>
        private MedGraphPanel _mainPanel;

        private Point _cursorPos;

        private Pen _cursorPosPen = new Pen(Color.Black);

        private int _curveIndex = -1,_pointIndex = -1,_rowIndex = -1,_rowtypeIndex = -1;

        private bool _drawcursorpos = false;

        private MedPointList _currentpoints;

        /// <summary>
        /// 是否锁定(禁用)鼠标事件
        /// </summary>
        private bool _lockMouseEvent = false;

        #endregion 私有变量

        #region 属性

        /// <summary>
        /// 图表主体
        /// </summary>
        public MedGraphPanel MainPanel
        {
            get
            {
                return _mainPanel;
            }
        }

        /// <summary>
        /// 当前曲线
        /// </summary>
        public MedCurve CurrentCurve 
        { 
            get 
            {
                if (_curveIndex >= 0)
                {
                    return _mainPanel.CurveList[_curveIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 当前网格行
        /// </summary>
        public MedGridRow CurrentRow
        {
            get
            {
                if ((_rowIndex >= 0) && (_rowtypeIndex >= 0))
                {
                    return _mainPanel.RowList[_rowIndex, _rowtypeIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        public MedPointList CurrentPoints { get { return _currentpoints; } set { _currentpoints = value; } }

        public int PointIndex { get { return _pointIndex; } }

        public bool IsDrawCursorPos { get { return _drawcursorpos; } set { _drawcursorpos = value; } }

        public Pen CursorPosPen { get { return _cursorPosPen; } set { _cursorPosPen = value; } }

        /// <summary>
        /// 是否锁定(禁用)鼠标事件
        /// </summary>
        public bool LockMouseEvent
        {
            get
            {
                return _lockMouseEvent;
            }
            set
            {
                _lockMouseEvent = value;
            }
        }

        #endregion 属性

        #region 构造方法

        public MedGraph()
        {
            InitializeComponent();
            _mainPanel = new MedGraphPanel(this);
            _cursorPos = new Point(this.Width / 2, this.Height / 2);
            _cursorPosPen.DashStyle = DashStyle.DashDotDot;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
            _mainPanel.Width = this.Width;
            _mainPanel.Height = this.Height;
        }

        #endregion 构造方法

        #region 方法

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_mainPanel != null)
            {
                _mainPanel.Width = this.Width;
                _mainPanel.Height = this.Height;
            }
        }

        #region 作图方法

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.DesignMode)
            {
                ///Y坐标轴
                _mainPanel.YAxisList.Clear();
                _mainPanel.YAxisList.Add(new MedAxis(this.Font, Brushes.Black, 100, 0, 20));
                _mainPanel.YAxisList.MinSetp = 1;
                _mainPanel.YAxisList.Pen.Color = Color.Black;

                ///X坐标轴
                _mainPanel.XAxisList.Clear();
                MedAxis axis = new MedAxis(this.Font, Brushes.Black, 10, 1, 1f);
                _mainPanel.XAxisList.Add(axis);
                _mainPanel.XAxisList.MinSetp = 1;
                _mainPanel.XAxisList.Pen.Color = Color.Black;

                ///其他属性
                _mainPanel.LeftMargin = 10;
                _mainPanel.BottomMargin = 20;
                _mainPanel.RectBorderPen = Pens.Gray;
                _mainPanel.HasAxisGridLine = false;
                _mainPanel.XAxisTitleAtTop = false;

                _mainPanel.CurveList.Clear();
                MedPointList points = new MedPointList();
                points.Add(1, 10);
                points.Add(2, 40);
                points.Add(3, 20);
                points.Add(4, 80);
                points.Add(5, 50);
                points.Add(6, 70);
                points.Add(7, 60);
                points.Add(8, 100);
                points.Add(9, 90);
                points.Add(10, 0);
                MedCurve curve = new MedCurve(points);
                _mainPanel.CurveList.Add(curve);
            }

            ///隐藏滚动条

            ///如果没有坐标轴则不作图
            if ((_mainPanel.XAxisList.Count == 0) || (_mainPanel.YAxisList.Count == 0)) return;

            _mainPanel.DrawGraph(e.Graphics);

            ///绘制光标位置
            if (_drawcursorpos)
            {
                DrawCursorPos(e.Graphics);
            }
        }

        /// <summary>
        /// 画光标位置
        /// </summary>
        /// <param name="g">作图对象</param>
        private void DrawCursorPos(Graphics g)
        {
            //g.DrawLine(_cursorPosPen, _cursorPos.X, 0, _cursorPos.X,this.Height);
            g.DrawLine(_cursorPosPen, 0, _cursorPos.Y, this.Width, _cursorPos.Y);
        }


        #endregion 作图方法

        /// <summary>
        /// 输出图表区域到打印机
        /// </summary>
        public void PrintGraph(int leftOffSet,int topOffSet)
        {
            ///创建一个PrintDocument的实例
            using (System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument())
            {
                docToPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(
                    delegate (object sender, System.Drawing.Printing.PrintPageEventArgs e)
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        _mainPanel.DrawAxises(e.Graphics, false, leftOffSet, topOffSet);
                        _mainPanel.DrawCurves(e.Graphics, leftOffSet, topOffSet);
                    }
                );

                docToPrint.Print();

            }
        }

        #endregion 方法

        #region 事件

        private void MedGraph_MouseMove(object sender, MouseEventArgs e)
        {
            ///如果锁定鼠标则不处理
            if (_lockMouseEvent) return;

            _cursorPos.X = e.X;
            _cursorPos.Y = e.Y;
            float xx, yy;
            _curveIndex = -1;
            _pointIndex = -1;
            _rowtypeIndex = -1;
            _rowIndex = -1;
            _mainPanel.Legend.ItemRectIndex = -1;
            if (e.X < _mainPanel.MainRect.X || e.X > (_mainPanel.MainRect.X + _mainPanel.MainRect.Width) || (e.Y - _mainPanel.HScrollPos) < _mainPanel.MainRect.Y || (e.Y - _mainPanel.HScrollPos) > (_mainPanel.MainRect.Y + _mainPanel.MainRect.Height + _mainPanel.GridRect.Height)) return;
            
            #region 是否是体征数据并保存光标位置

            if (e.X >= _mainPanel.MainRect.X && e.X <= (_mainPanel.MainRect.X + _mainPanel.MainRect.Width) && (e.Y - _mainPanel.HScrollPos) >= _mainPanel.MainRect.Y && (e.Y - _mainPanel.HScrollPos) <= (_mainPanel.MainRect.Y + _mainPanel.MainRect.Height))
            {
                int idx = 0;
                foreach (MedCurve curve in _mainPanel.CurveList)
                {
                    MedPointList points = curve.Points;
                    for (int j = 0; j < points.Count; j++)
                    {
                        xx = _mainPanel.TranslateX(points[j].X, curve.XAxisIndex);
                        yy = _mainPanel.TranslateY(points[j].Y, curve.YAxisIndex);
                        if ((Math.Abs(xx - e.X) < 5) && (Math.Abs(yy - e.Y + _mainPanel.HScrollPos) < 5)) { _pointIndex = j; _curveIndex = idx; }
                        if (_pointIndex >= 0) break;
                    }
                    if (_pointIndex >= 0) break;
                    idx++;
                }
            }

            #endregion 是否是体征数据并保存光标位置

            #region 是否是出入液数据

            if ((_pointIndex < 0) && e.X >= _mainPanel.MainRect.X && e.X <= (_mainPanel.MainRect.X + _mainPanel.MainRect.Width) && (e.Y - _mainPanel.HScrollPos) >= (_mainPanel.MainRect.Y + _mainPanel.MainRect.Height) && (e.Y - _mainPanel.HScrollPos) <= (_mainPanel.MainRect.Y + _mainPanel.MainRect.Height + _mainPanel.GridRect.Height))
            {
                int _count = (int)((_mainPanel.XAxisList[0].Max - _mainPanel.XAxisList[0].Min) / (_mainPanel.XAxisList[0].Step));
                float _H = _mainPanel.GridRect.Height / _mainPanel.GirdRowCounts, _Y = _mainPanel.GridRect.Y + _H;
                for (int i = 0; i < _mainPanel.RowList.TypeCount; i++)
                {
                    for (int j = 0; j < _mainPanel.RowList.CountOfType(i); j++)
                    {
                        for (int k = 0; k < _count; k++)
                        {
                            for (int kk = 0; kk < _mainPanel.XAxisList.MinSetp; kk++)
                            {
                                if ((e.X >= _mainPanel.MainRect.X + k * _mainPanel.GridRect.Width / _count + kk * _mainPanel.GridRect.Width / _count / _mainPanel.XAxisList.MinSetp) 
                                    && (e.X < _mainPanel.MainRect.X + k * _mainPanel.GridRect.Width / _count + kk * _mainPanel.GridRect.Width / _count / _mainPanel.XAxisList.MinSetp + _mainPanel.GridRect.Width / _count / _mainPanel.XAxisList.MinSetp)
                                    && ((e.Y - _mainPanel.HScrollPos) >= _Y - _H) && ((e.Y - _mainPanel.HScrollPos) < _Y - _H + _H)) 
                                { 
                                    _pointIndex = k * _mainPanel.XAxisList.MinSetp + kk; _rowtypeIndex = i; _rowIndex = j;
                                    if (_mainPanel.RowList[j, i].Points != null)
                                    {
                                        _currentpoints = _mainPanel.RowList[j, i].SubPoints(_mainPanel.XAxisList[0].Min + k * _mainPanel.XAxisList[0].Step + kk * _mainPanel.XAxisList[0].Step / _mainPanel.XAxisList.MinSetp
                                            , _mainPanel.XAxisList[0].Min + k * _mainPanel.XAxisList[0].Step + (kk + 1) * _mainPanel.XAxisList[0].Step / _mainPanel.XAxisList.MinSetp);
                                    }
                                }
                                if (_pointIndex >= 0) break;
                            }
                            if (_pointIndex >= 0) break;
                        }
                        if (_pointIndex >= 0) break;
                        _Y += _H;
                    }
                    if (_pointIndex >= 0) break;
                    _Y += _H;
                }
            }

            #endregion 是否是出入液数据

            #region 是否是图例并保存光标位置

            //if (_pointIndex<0){
            //    idx = 0;
            //    foreach (Rectangle rect in _mainPanel.Legend.ItemRects)
            //    {
            //        if(rect.Contains((int)e.X,(int)(e.Y - _mainPanel.HScrollPos))){
            //            _mainPanel.Legend.ItemRectIndex = idx;break;
            //        }
            //        idx ++;
            //    }
            //}

            #endregion 是否是图例并保存光标位置

            Invalidate();
        }

        #endregion 事件

    }
}
