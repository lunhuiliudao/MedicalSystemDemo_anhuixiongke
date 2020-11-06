using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    /// <summary>
    /// VitalSignsControl.xaml 的交互逻辑
    /// </summary>
    public partial class VitalSignsControl : UserControl
    {
        #region 生命体征字段及私有属性

        /// <summary>
        /// x轴
        /// </summary>
        private static DateAxis _XAxis;
        private List<UIElement> _XAxisItems;
        private Dictionary<VitalSignCurveDetailModel, List<UIElement>> _CurvesUIItems;
        /// <summary>
        /// 选中体征
        /// </summary>
        private VitalSignCurveDetailModel _SelectPoints;
        /// <summary>
        /// 是否可以画体征曲线
        /// </summary>
        private bool _StartPenVitalSign = false;
        /// <summary>
        /// 文本点UIElement
        /// </summary>
        private List<UIElement> _TextPointItems;
        private DateTime _processTime;
        /// <summary>
        /// 图例UIElement
        /// </summary>
        private List<UIElement> _LegendItems;
        /// <summary>
        /// 潮气量UIElement
        /// </summary>
        private List<UIElement> _BreathParamUIElements;
        /// <summary>
        /// 事件标记区Header
        /// </summary>
        private List<UIElement> _EventMarkHeaderUIElements;
        /// <summary>
        /// 事件标记UIElement
        /// </summary>
        private List<UIElement> _EventMarkUIElements;
        /// <summary>
        /// y轴
        /// </summary>
        private List<Axis> _YAxises;
        /// <summary>
        /// y轴颜色
        /// </summary>
        private List<Color> _YAxiseColors;
        /// <summary>
        /// 横向定位线
        /// </summary>
        private Line _horizationLine;
        /// <summary>
        /// 纵向定位线
        /// </summary>
        private Line _verticalLine;
        /// <summary>
        /// tooltip
        /// </summary>
        private ToolTip _VitalSignsToolTip;
        private Point _MouseOldLocation;
        private Point _StartPoint;
        private Point _AxisStartPoint;
        private int _curvePointClickNum;
        private int _chartClickNum;
        /// <summary>
        /// y轴元素集合
        /// </summary>
        private List<UIElement> _YAxisItems;
        /// <summary>
        /// 开始拖拽鼠标位置
        /// </summary>
        private Point _firstMousePosition;
        /// <summary>
        /// 拖拽过程中最近鼠标位置
        /// </summary>
        private Point _lastMousePosition;
        /// <summary>
        /// 拖动时间轴的toolTip
        /// </summary>
        private ToolTip _dragXAxisTip;
        private bool _isLoading;
        /// <summary>
        /// 是否已加载
        /// </summary>
        private bool _isLoaded;
        /// <summary>
        /// 生命体征容器
        /// </summary>
        private Grid _VitalSignsContainer
        {
            get
            {
                return this.GridVitalSigns;
            }
        }
        /// <summary>
        /// 最后一条Y轴的x坐标
        /// </summary>
        private double _lastYAxisX;
        private double _LegendStartY;
        private double _VitalSignsDrawHeight;
        private double _EventMarkDrawHeight;
        private double _VitalSignsHeightPercent = 0.94D;
        /// <summary>
        /// 生命体征与事件标注分割线宽度
        /// </summary>
        private double _VSignsEventMarkDividingLineHeight = 2D;
        private Point _EventMarkStartPoint;
        /// <summary>
        /// 时间进度矩形
        /// </summary>
        private Rectangle _TimeRectangle;
        /// <summary>
        /// 是否是拖拽点
        /// </summary>
        private bool _isDragPoint;
        private double _VitalSignsDrawWidth
        {
            get
            {
                return _VitalSignsContainer.ActualWidth;
            }
        }

        /// <summary>
        /// 事件标记区原始宽度
        /// </summary>
        private double _eventDescContainerOrginWidth;

        /// <summary>
        /// 起点
        /// </summary>
        private Point StartPoint
        {
            get
            {
                if (_StartPoint == null)
                    _StartPoint = new Point(0, 0);

                return _StartPoint;
            }
        }
        /// <summary>
        /// 时间轴起点
        /// </summary>
        private Point AxisStartPoint
        {
            get
            {
                if (_AxisStartPoint == null)
                    _AxisStartPoint = new Point(StartPoint.X + _VitalSignsDrawWidth * HeadWidthPercent, StartPoint.Y);
                else
                {
                    _AxisStartPoint.X = StartPoint.X + _VitalSignsDrawWidth * HeadWidthPercent;
                    _AxisStartPoint.Y = StartPoint.Y;
                }
                return _AxisStartPoint;
            }
        }
        /// <summary>
        /// 数字形式曲线显示行数
        /// </summary>
        private int DigitRows
        {
            get
            {
                return Curves == null ? 0 : Curves.Count(p => p.ShowType == CurveShowType.Digit && p.Visible);
            }
        }
        /// <summary>
        /// 事件
        /// </summary>
        private List<EventMarkPoint> _eventMarkPoints;

        /// <summary>
        /// 曲线
        /// </summary>
        private List<LineSeries> _curveLineSeries;

        private double _AxisMaxX;
        private double _AxisMaxY;

        private string _tooltipContent;
        private string _strMargin = "  ";
        private Point _mousePosition;
        private bool _isMouseOverPoint;
        #endregion

        #region 事件标记区

        private List<DataPoint> _eventDataPonits;
        private string _eventMarkHeaderText = "标 记";
        private double _eventHeaderFontSize = 10.5;
        private string _eventHeaderFontFamily = "微软雅黑";
        private Color _eventHeaderForeground = Color.FromRgb(0xFF, 0xFF, 0xFF);
        private Color _eventMarkHeaderBgColor = Color.FromRgb(0x32, 0x76, 0x94);
        private double _eventHeaderHMargin = 3;
        private double _eventHeaderWidth;

        private double _eventMarkFontSize = 10;
        private string _eventMarkFontFamily = "微软雅黑";
        private Color _eventMarkForeground = Color.FromRgb(0xFF, 0xFF, 0xFF);
        private Color _eventMarkBgColor = Color.FromRgb(0x6C, 0x94, 0xA4);

        private double _eventDescHeaderWidth = 10;
        private double _eventDescFontSize = 10.5;
        private string _eventDescFontFamily = "微软雅黑";
        private Color _eventDescForeground = Color.FromRgb(0xFF, 0xFF, 0xFF);
        private Color _eventDescBgColor = Color.FromRgb(0x6C, 0x94, 0xA4);

        #endregion

        #region 事件备注区

        private Grid _eventDescContainer
        {
            get { return GridEventsDesc; }
        }
        private string _eventDescHeaderText = "备 注";
        private Color _eventDescHeaderBgColor = Color.FromRgb(0x08, 0xA9, 0xBC); //Color.FromRgb(0xF5, 0xD2, 0x8D);

        #endregion

        #region 私有类

        /// <summary>
        /// 默认设置
        /// </summary>
        private class _DefaultSetting
        {
            public const int RowCount = 20;
            //public const int DefaultMedicineRowCount = 5;
            //public const int DefaultOutputRowCount = 1;
            //public const int DefaultInfusionRowCount = 4;
            public const double TableHeadWidthPercent = 0.2d;
            public const double TableHeadThickness = 1d;
            public const double GridThickness = 1d;
            public static DoubleCollection DefaultDashArray = new DoubleCollection { 4, 4 };
            public static Color GridLineColor = Color.FromRgb(0xE1, 0xE8, 0xEC); //Color.FromRgb(0xC5, 0xE9, 0xEC);//Color.FromRgb(0xBB, 0xE7, 0xDD);
            public static Color HeadOddRowBrushColor = Color.FromRgb(0xFC, 0xFE, 0xFE);
            public static Color HeadEvenRowBrushColor = Color.FromRgb(0xD2, 0xF0, 0xF0);//Color.FromRgb(0x74, 0xC6, 0xD4);
            public static Color BodyOddRowBrushColor = Colors.White;
            public static Color BodyEvenRowBrushColor = Color.FromRgb(0xF5, 0xF7, 0xF7);//Color.FromRgb(0xC6, 0xEA, 0xEA);
            public static Color DataLineColor = Color.FromRgb(0x24, 0xBE, 0xC8);//24BEC8//Color.FromRgb(0x23, 0xC0, 0xC9);            
        }

        #endregion

        #region 依赖属性

        public static readonly DependencyProperty XAxisSettingProperty = DependencyProperty.Register("XAxisSetting", typeof(AxisSetting), typeof(VitalSignsControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, XAxisSettingChanged));
        public static readonly DependencyProperty BreathParamProperty = DependencyProperty.Register("BreathParam", typeof(BreathParaModel), typeof(VitalSignsControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnBreathParamChanged));
        public static readonly DependencyProperty YAxisSettingsProperty = DependencyProperty.Register("YAxisSettings", typeof(List<YAxisSetting>), typeof(VitalSignsControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnYAxisSettingsChanged));
        public static readonly DependencyProperty CurvesProperty = DependencyProperty.Register("Curves", typeof(List<VitalSignCurveDetailModel>), typeof(VitalSignsControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnCurvesChanged));
        public static readonly DependencyProperty EventMarkProperty = DependencyProperty.Register("EventMark", typeof(EventMarkModel), typeof(VitalSignsControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnEventMarkChanged));
        public static readonly DependencyProperty TextMarkPointsProperty = DependencyProperty.Register("TextMarkPoints", typeof(List<TextMarkPoint>), typeof(VitalSignsControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnTextPointsChanged));
        public static readonly DependencyProperty IsEditEnableProperty = DependencyProperty.Register("IsEditEnable", typeof(bool), typeof(VitalSignsControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsMeasure, OnIsEditEnableChanged));
        public static readonly DependencyProperty IsHiddenEventMarkAreaProperty = DependencyProperty.Register("IsHiddenEventMarkArea", typeof(bool), typeof(VitalSignsControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure, OnIsHiddenEventMarkAreaChanged));

        public static readonly RoutedEvent CurveSetClickRoutedEvent = EventManager.RegisterRoutedEvent("CurveSetClick", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(VitalSignsControl));
        public static readonly RoutedEvent CurvePointDoubleClickRoutedEvent = EventManager.RegisterRoutedEvent("CurvePointDoubleClick", RoutingStrategy.Bubble, typeof(EventHandler<CurveEventArgs>), typeof(VitalSignsControl));
        public static readonly RoutedEvent CurvePointDragRoutedEvent = EventManager.RegisterRoutedEvent("CurvePointDrag", RoutingStrategy.Bubble, typeof(EventHandler<CurveEventArgs>), typeof(VitalSignsControl));
        public static readonly RoutedEvent ChartDoubleClickRoutedEvent = EventManager.RegisterRoutedEvent("ChartDoubleClick", RoutingStrategy.Bubble, typeof(EventHandler<CurveEventArgs>), typeof(VitalSignsControl));

        #endregion

        #region 公共属性

        /// <summary>
        /// 头宽度百分比
        /// </summary>
        public double HeadWidthPercent { get; set; }
        /// <summary>
        /// 网格线颜色
        /// </summary>
        public Color GridLineColor { get; set; }
        /// <summary>
        /// x轴设置
        /// </summary>
        public AxisSetting XAxisSetting
        {
            get { return (AxisSetting)GetValue(XAxisSettingProperty); }
            set
            {
                SetValue(XAxisSettingProperty, value);
            }
        }
        /// <summary>
        /// Y轴设置
        /// </summary>
        public List<YAxisSetting> YAxisSettings
        {
            get { return (List<YAxisSetting>)GetValue(YAxisSettingsProperty); }
            set
            {
                SetValue(YAxisSettingsProperty, value);
            }
        }
        /// <summary>
        /// 生命体征曲线
        /// </summary>
        public List<VitalSignCurveDetailModel> Curves
        {
            get { return (List<VitalSignCurveDetailModel>)GetValue(CurvesProperty); }
            set { SetValue(CurvesProperty, value); }
        }
        /// <summary>
        /// 事件标注
        /// </summary>
        public EventMarkModel EventMark
        {
            get { return (EventMarkModel)GetValue(EventMarkProperty); }
            set { SetValue(EventMarkProperty, value); }
        }
        /// <summary>
        /// 文本标记
        /// </summary>
        public List<TextMarkPoint> TextMarkPoints
        {
            get { return (List<TextMarkPoint>)GetValue(TextMarkPointsProperty); }
            set
            {
                SetValue(TextMarkPointsProperty, value);
            }
        }
        /// <summary>
        /// 是否可以编辑（默认true 可以编辑）
        /// </summary>
        public bool IsEditEnable
        {
            get { return (bool)GetValue(IsEditEnableProperty); }
            set
            {
                SetValue(IsEditEnableProperty, value);
            }
        }
        /// <summary>
        /// 事件
        /// </summary>
        public List<EventMarkPoint> EventMarkPoints
        {
            get { return _eventMarkPoints; }
            set { _eventMarkPoints = value; }
        }

        /// <summary>
        /// 潮气量（三角分布）
        /// </summary>
        public BreathParaModel BreathParam
        {
            get { return (BreathParaModel)GetValue(BreathParamProperty); }
            set { SetValue(BreathParamProperty, value); }
        }
        /// <summary>
        /// 移动X轴委托
        /// </summary>
        public Action<object, double> MoveXAxisAction { get; set; }
        /// <summary>
        /// 是否隐藏事件标记和备注区（默认false）
        /// </summary>
        public bool IsHiddenEventMarkArea
        {
            get { return (bool)GetValue(IsHiddenEventMarkAreaProperty); }
            set
            {
                SetValue(IsHiddenEventMarkAreaProperty, value);
            }
        }

        #endregion

        #region 事件
        /// <summary>
        /// 图形设置
        /// </summary>
        [Description("图形设置")]
        public event MouseButtonEventHandler CurveSetClick
        {
            add { AddHandler(CurveSetClickRoutedEvent, value); }
            remove { RemoveHandler(CurveSetClickRoutedEvent, value); }
        }
        /// <summary>
        /// 双击曲线上点
        /// </summary>
        [Description("双击曲线上点")]
        public event RoutedEventHandler CurvePointDoubleClick
        {
            add { AddHandler(CurvePointDoubleClickRoutedEvent, value); }
            remove { RemoveHandler(CurvePointDoubleClickRoutedEvent, value); }
        }
        /// <summary>
        /// 拖拽曲线上的点
        /// </summary>
        [Description("拖拽曲线上的点")]
        public event RoutedEventHandler CurvePointDrag
        {
            add { AddHandler(CurvePointDragRoutedEvent, value); }
            remove { RemoveHandler(CurvePointDragRoutedEvent, value); }
        }
        /// <summary>
        /// 画图区双击
        /// </summary>
        [Description("画图区双击")]
        public event RoutedEventHandler ChartDoubleClick
        {
            add { AddHandler(ChartDoubleClickRoutedEvent, value); }
            remove { RemoveHandler(ChartDoubleClickRoutedEvent, value); }
        }

        #endregion
        public VitalSignsControl()
        {
            InitializeComponent();
            _YAxiseColors = new List<Color>() { Color.FromRgb(0x1D, 0xAD, 0xE7), Color.FromRgb(0xF1, 0xCD, 0x3D), Color.FromRgb(0x1D, 0xAD, 0xE7) };
            _XAxisItems = new List<UIElement>();
            _YAxisItems = new List<UIElement>();
            _BreathParamUIElements = new List<UIElement>();
            _EventMarkHeaderUIElements = new List<UIElement>();
            _EventMarkUIElements = new List<UIElement>();
            _TextPointItems = new List<UIElement>();
            _LegendItems = new List<UIElement>();
            _curveLineSeries = new List<LineSeries>();
            _CurvesUIItems = new Dictionary<VitalSignCurveDetailModel, List<UIElement>>();
            GridLineColor = _DefaultSetting.GridLineColor;
            _MouseOldLocation = new Point();
            _VitalSignsToolTip = new ToolTip();
            _VitalSignsToolTip.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            _VitalSignsToolTip.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            _VitalSignsToolTip.IsOpen = false;

            _dragXAxisTip = new ToolTip();
            _dragXAxisTip.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            _dragXAxisTip.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            _dragXAxisTip.IsOpen = false;
            _eventDataPonits = new List<DataPoint>();
            _processTime = DateTime.Now;
            this.Loaded += VitalSignsControl_Loaded;
        }

        #region 依赖属性Changed事件

        void VitalSignsControl_Loaded(object sender, RoutedEventArgs e)
        {
            _isLoading = true;
            _VitalSignsDrawHeight = _VitalSignsContainer.ActualHeight * _VitalSignsHeightPercent;
            _EventMarkDrawHeight = _VitalSignsContainer.ActualHeight * (1 - _VitalSignsHeightPercent) - _VSignsEventMarkDividingLineHeight;
            _EventMarkStartPoint = new Point(StartPoint.X, _VitalSignsDrawHeight + _VSignsEventMarkDividingLineHeight);
            _eventDescContainerOrginWidth = _eventDescContainer.ActualWidth;
            Draw();
            //_VitalSignsContainer.MouseEnter += VitalSignsControl_MouseEnter;
            _VitalSignsContainer.MouseMove += VitalSignsControl_MouseMove;
            _VitalSignsContainer.MouseLeave += VitalSignsControl_MouseLeave;
            _VitalSignsContainer.MouseLeftButtonDown += _VitalSignsContainer_MouseLeftButtonDown;
            _VitalSignsContainer.DragOver += _VitalSignsContainer_DragOver;
            _VitalSignsContainer.GiveFeedback += _VitalSignsContainer_GiveFeedback;
            _VitalSignsContainer.Drop += _VitalSignsContainer_Drop;

            _AxisMaxX = _AxisStartPoint.X + _VitalSignsDrawWidth;
            _AxisMaxY = _AxisStartPoint.Y + _VitalSignsDrawHeight;
            _isLoaded = true;
        }

        void _VitalSignsContainer_Drop(object sender, DragEventArgs e)
        {
            Point p = e.GetPosition(_VitalSignsContainer);
            if (_isDragPoint)
            {
                var data = e.Data;
                if (data.GetDataPresent(typeof(DragPointData)))
                {
                    var spoint = data.GetData(typeof(DragPointData)) as DragPointData;
                    if (spoint.MoveY <= spoint.Series.PointWidth)
                        return;

                    if (p.Y < _VitalSignsDrawHeight - spoint.Series.YAxis.LocalTransform(spoint.Series.YAxis.Max) || p.Y > _VitalSignsDrawHeight - spoint.Series.YAxis.LocalTransform(spoint.Series.YAxis.Min))
                    {
                        e.Effects = DragDropEffects.None;
                        return;
                    }
                    FrameworkElement ue = spoint.Data.DataUIElements.FirstOrDefault();
                    //ue.Margin = new Thickness(ue.Margin.Left, ue.Margin.Top + (p.Y - spoint.OldPoint.Y), 0, 0);
                    //ue.Margin = new Thickness(ue.Margin.Left, p.Y - spoint.Data.Y, 0, 0);
                    Thickness thick = new Thickness(ue.Margin.Left,
                        p.Y - spoint.Data.Y, 0, 0);
                    foreach (FrameworkElement path in spoint.Data.DataUIElements)
                    {
                        path.Margin = thick;
                    }

                    VitalSignPointModel curvePData = ue.Tag as VitalSignPointModel;
                    //(ue.Tag as PointData).RelatedPath.Margin = ue.Margin;
                    DateTime moveTime = Convert.ToDateTime(_XAxis.GetTime(p.X).ToString("yyyy-MM-dd HH:mm"));


                    spoint.Data.Value = Math.Round(spoint.Series.YAxis.ReverseTransform((float)p.Y), curvePData.Curve.DecimalDigits);
                    if (spoint.Data.LineSegment != null)
                        spoint.Data.LineSegment.Point = new Point(spoint.Data.LineSegment.Point.X, p.Y);
                    else if (spoint.Data.Figure != null)
                        spoint.Data.Figure.StartPoint = new Point(spoint.Data.Figure.StartPoint.X, p.Y);

                    //spoint.Data.Y = p.Y;
                    curvePData.Value = spoint.Data.Value;
                    CurveEventArgs args = new CurveEventArgs(CurvePointDragRoutedEvent, sender);
                    //if (moveTime != curvePData.Time)
                    //{
                    //    if (moveTime.Minute % 5 != 0)
                    //    {
                    //        int i = moveTime.Minute % 5;
                    //        moveTime = moveTime.AddMinutes(5 - i);
                    //    }
                    //    bool isAdd = true;
                    //    for (int j = 0; j < curvePData.Curve.Points.Count; j++)
                    //    {
                    //        if (curvePData.Curve.Points[j].Time == moveTime)
                    //        {
                    //            isAdd = false;
                    //        }
                    //    }
                    //    if (isAdd)
                    //    {
                    //        DateTime startTime = curvePData.Time;
                    //        SymbolType symbolType = SymbolType.Point;
                    //        if (curvePData.Curve.Points[0].Symbol != null)
                    //            symbolType = curvePData.Curve.Points[0].Symbol.SymbolType;
                    //        LineSeries lineSeries = _curveLineSeries.Find(x => x.Name == curvePData.Curve.CurveName);
                    //        while (startTime <= moveTime)
                    //        {
                    //            curvePData.Time = startTime;
                    //            lineSeries.AddDataPoint(startTime, double.Parse(curvePData.Value.ToString()), curvePData, CurvePoint_MouseEnter, CurvePoint_MouseLeave, symbolType);

                    //            startTime = startTime.AddMinutes(5);
                    //            if (startTime <= moveTime && IsNeedMoveToNextFigure(curvePData.Curve, curvePData.Time, startTime))
                    //            {
                    //                lineSeries.MoveToNextFigure();
                    //            }
                    //            lineSeries.Points[lineSeries.Points.Count - 1].DataUIElements.ForEach(u =>
                    //            {
                    //                _VitalSignsContainer.Children.Add(u);
                    //            });
                    //            args.Point = curvePData;
                    //            this.RaiseEvent(args);
                    //        }

                    //    }
                    //    else
                    //    {
                    //        args.Point = curvePData;
                    //        this.RaiseEvent(args);
                    //    }
                    //}
                    //else
                    {
                        args.Point = curvePData;
                        this.RaiseEvent(args);
                    }


                }
                _isDragPoint = false;
            }
            else
            {
                if (_dragXAxisTip != null)
                {
                    _dragXAxisTip.IsOpen = false;
                }
                double xMove = -(p.X - _firstMousePosition.X);
                _XAxis.MoveAxis(xMove, () =>
                {
                    _XAxisItems.ForEach(c => { _VitalSignsContainer.Children.Remove(c); });
                    _XAxisItems.Clear();
                }, () => { ReDraw(); });

                if (MoveXAxisAction != null)
                    MoveXAxisAction(this, xMove);
            }
        }

        /// <summary>
        /// 坐标轴移动
        /// </summary>
        /// <param name="xMove"></param>
        public void MoveXAxis(double xMove)
        {
            _XAxis.MoveAxis(xMove, () =>
            {
                _XAxisItems.ForEach(c => { _VitalSignsContainer.Children.Remove(c); });
                _XAxisItems.Clear();
            }, () => { ReDraw(); });
        }

        void _VitalSignsContainer_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            //Point p = Mouse.GetPosition(_VitalSignsContainer);
            PathHelper.POINT p = PathHelper.GetCursorPos();
            if (_isDragPoint)
            {
                if (p.Y != _lastMousePosition.Y)
                {
                    _VitalSignsToolTip.IsOpen = false;
                    _VitalSignsToolTip.IsOpen = true;
                    _lastMousePosition.X = p.X;
                    _lastMousePosition.Y = p.Y;
                }
            }
            else
            {
                if (p.X != _lastMousePosition.X)
                {
                    _dragXAxisTip.IsOpen = false;
                    double xMove = -(p.X - _firstMousePosition.X);
                    if (xMove > 0)
                        _dragXAxisTip.Content = "向右移动时间轴：" + _XAxis.GetMoveDesc(xMove);
                    else
                        _dragXAxisTip.Content = "向左移动时间轴：" + _XAxis.GetMoveDesc(xMove);
                    _dragXAxisTip.IsOpen = true;
                    _lastMousePosition.X = p.X;
                    _lastMousePosition.Y = p.Y;
                }
            }
        }

        void _VitalSignsContainer_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
            //return;
            Point p = e.GetPosition(_VitalSignsContainer);
            //PathHelper.POINT p = PathHelper.GetCursorPos();

            if (_isDragPoint)
            {
                var data = e.Data;
                if (data.GetDataPresent(typeof(DragPointData)))
                {
                    var spoint = data.GetData(typeof(DragPointData)) as DragPointData;

                    //if (spoint.MoveY == 0 && Math.Abs(p.Y - spoint.FirstDragPoint.Y) <= spoint.Series.PointWidth)
                    if (spoint.MoveY == 0 && Math.Abs(p.Y - spoint.FirstDragPoint.Y) <= 0.1)
                    {
                        return;
                    }

                    string tooltipContent = string.Empty;
                    string strMargin = "  ";
                    if (p.Y < _VitalSignsDrawHeight - spoint.Series.YAxis.LocalTransform(spoint.Series.YAxis.Max) || p.Y > _VitalSignsDrawHeight - spoint.Series.YAxis.LocalTransform(spoint.Series.YAxis.Min))
                    {
                        e.Effects = DragDropEffects.None;

                        tooltipContent += strMargin + spoint.Series.Name;
                        tooltipContent += "\n—————————————";
                        tooltipContent += "\n" + strMargin + "时间：" + spoint.Data.Time.ToString("yyyy-MM-dd HH:mm:ss");
                        tooltipContent += "\n" + strMargin + "已移动到最大或最小值";
                        _VitalSignsToolTip.Content = tooltipContent;
                        return;
                    }

                    FrameworkElement ue = spoint.Data.DataUIElements.FirstOrDefault();
                    //ue.Margin = new Thickness(ue.Margin.Left, ue.Margin.Top + (p.Y - spoint.OldPoint.Y), 0, 0);
                    ue.Margin = new Thickness(ue.Margin.Left, p.Y - spoint.Data.Y, 0, 0);

                    if (spoint.Data.LineSegment != null)
                        spoint.Data.LineSegment.Point = new Point(spoint.Data.LineSegment.Point.X, p.Y);
                    else if (spoint.Data.Figure != null)
                        spoint.Data.Figure.StartPoint = new Point(spoint.Data.Figure.StartPoint.X, p.Y);

                    double val = Math.Round(spoint.Series.YAxis.ReverseTransform((float)p.Y), (ue.Tag as VitalSignPointModel).Curve.DecimalDigits);

                    //tooltip
                    tooltipContent += strMargin + spoint.Series.Name;
                    tooltipContent += "\n—————————————";
                    tooltipContent += "\n" + strMargin + "时间：" + spoint.Data.Time.ToString("yyyy-MM-dd HH:mm:ss");
                    tooltipContent += "\n" + strMargin + "值：" + val;
                    _VitalSignsToolTip.Content = tooltipContent;

                    spoint.LastPoint = p;
                    spoint.MoveY += Math.Abs(p.Y - spoint.FirstDragPoint.Y);
                }
            }
        }
        void _VitalSignsContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_mousePosition.X >= _AxisStartPoint.X && _mousePosition.X <= _AxisMaxX
               && _mousePosition.Y >= _AxisStartPoint.Y && _mousePosition.Y <= _AxisMaxY)
            {
                if (_SelectPoints != null)
                {
                    _StartPenVitalSign = !_StartPenVitalSign;
                    if (_StartPenVitalSign)
                    {
                        this.Cursor = Cursors.Pen;
                        ExtendAppContext.Current.IsRefVitalSigns = false;
                    }
                    else
                    {
                        _SelectPoints = null;
                        this.Cursor = Cursors.Arrow;
                        ExtendAppContext.Current.IsRefVitalSigns = true;

                    }
                }
            }
            _chartClickNum += 1;
            Point p = e.GetPosition(_VitalSignsContainer);
            LineSeries series = null;
            DataPoint data = null;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) =>
            {
                timer.IsEnabled = false;

                //if (_chartClickNum % 2 != 0)
                //{
                //    //如果300毫秒内无双击 则是单击
                //    _isDragPoint = IsOnCurvePoint(out series, out data);
                //    object dataObject = 1;
                //    if (!_isDragPoint)
                //    {
                //        //鼠标不在曲线点上才能拖拽时间轴                    
                //        _firstMousePosition = p;
                //        _lastMousePosition = p;
                //        DragDrop.DoDragDrop(_VitalSignsContainer, dataObject, DragDropEffects.Move);
                //    }
                //    else
                //    {
                //        DataObject d = new DataObject(typeof(DragPointData), new DragPointData() { Series = series, Data = data, OldPoint = p });
                //        //dataObject = new DragPointData(){ Series = series, Data = data };//曲线点
                //        DragDrop.DoDragDrop(_VitalSignsContainer, d, DragDropEffects.Move);
                //    }
                //}

                _chartClickNum = 0;
            };
            timer.IsEnabled = true;

            if (_chartClickNum % 2 == 0)
            {
                _isDragPoint = false;
                timer.IsEnabled = false;
                timer = null;
                _chartClickNum = 0;
                CurveEventArgs args = null;

                bool isOnCurve = IsOnCurvePoint(out series, out data);
                if (!isOnCurve)
                {
                    args = new CurveEventArgs(ChartDoubleClickRoutedEvent, sender);
                    args.CurrentTime = _XAxis.GetTime(p.X);
                    this.RaiseEvent(args);
                }
                else
                {
                    args = new CurveEventArgs(CurvePointDoubleClickRoutedEvent, sender);
                    args.Point = data.DataUIElements.FirstOrDefault().Tag as VitalSignPointModel;
                    this.RaiseEvent(args);
                }
            }
            else
            {
                _isDragPoint = IsOnCurvePoint(out series, out data);
                object dataObject = 1;
                if (!_isDragPoint)
                {
                    //鼠标不在曲线点上才能拖拽时间轴                    
                    _firstMousePosition = p;
                    _lastMousePosition = p;
                    DragDrop.DoDragDrop(_VitalSignsContainer, dataObject, DragDropEffects.Move);
                }
                else
                {
                    if (!IsEditEnable)
                        return;
                    DataObject d = new DataObject(typeof(DragPointData), new DragPointData() { Series = series, Data = data, LastPoint = p, FirstDragPoint = p });
                    //dataObject = new DragPointData(){ Series = series, Data = data };//曲线点
                    DragDrop.DoDragDrop(_VitalSignsContainer, d, DragDropEffects.Move);
                }
            }
        }
        /// <summary>
        /// 鼠标是否在曲线点上
        /// </summary>
        /// <returns></returns>
        private bool IsOnCurvePoint()
        {
            if (_curveLineSeries == null || _curveLineSeries.Count == 0)
                return false;
            LineSeries series = _curveLineSeries.Find(s => s.Contains());
            return series != null;
        }
        /// <summary>
        /// 鼠标是否在曲线点上
        /// </summary>
        /// <param name="series"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool IsOnCurvePoint(out LineSeries series, out DataPoint data)
        {
            series = null;
            data = null;
            if (_curveLineSeries == null || _curveLineSeries.Count == 0)
                return false;
            series = _curveLineSeries.Find(s => s.Contains());
            if (series != null)
            {
                data = series.GetDataPoint();
            }
            return series != null;
        }
        void VitalSignsControl_MouseLeave(object sender, MouseEventArgs e)
        {
            _VitalSignsToolTip.IsOpen = false;
            _dragXAxisTip.IsOpen = false;
            _horizationLine.Visibility = System.Windows.Visibility.Hidden;
            _verticalLine.Visibility = System.Windows.Visibility.Hidden;
        }

        void VitalSignsControl_MouseMove(object sender, MouseEventArgs e)
        {
            _mousePosition = e.GetPosition(_VitalSignsContainer);

            //SetLocationLines
            if (_mousePosition.X >= _AxisStartPoint.X && _mousePosition.X <= _AxisMaxX
                && _mousePosition.Y >= _AxisStartPoint.Y && _mousePosition.Y <= _AxisMaxY)
            {
                _horizationLine.Margin = new Thickness(0, _mousePosition.Y, 0, 0);
                _verticalLine.Margin = new Thickness(_mousePosition.X - _AxisStartPoint.X, 0, 0, 0);
                _horizationLine.Visibility = System.Windows.Visibility.Visible;
                _verticalLine.Visibility = System.Windows.Visibility.Visible;
                if (_SelectPoints != null && _StartPenVitalSign) this.Cursor = Cursors.Pen;
                DateTime selectedTime = Convert.ToDateTime(_XAxis.GetTime(_mousePosition.X).ToString("yyyy-MM-dd HH:mm"));
                if (_SelectPoints != null && _StartPenVitalSign && (selectedTime.Minute % 5 <= 2))
                {
                    selectedTime = selectedTime.AddSeconds(-selectedTime.Second);
                    if (selectedTime.Minute % 5 > 0)
                    {
                        selectedTime = selectedTime.AddMinutes(-selectedTime.Minute % 5);
                    }
                    bool isAdd = true;
                    for (int j = 0; j < _SelectPoints.Points.Count; j++)
                    {
                        if (_SelectPoints.Points[j].Time == selectedTime)
                        {
                            isAdd = false;
                        }
                    }
                    LineSeries lineSeries = _curveLineSeries.Find(x => x.Name == _SelectPoints.CurveName);
                    double value = Math.Round(lineSeries.YAxis.ReverseTransform((float)_mousePosition.Y), _SelectPoints.DecimalDigits);
                    if (isAdd)
                    {
                        CurveEventArgs args = new CurveEventArgs(CurvePointDragRoutedEvent, sender);

                        SymbolType symbolType = SymbolType.Point;
                        symbolType = _SelectPoints.LegendList[0].Symbol.SymbolType;

                        VitalSignPointModel curvePData = new VitalSignPointModel(selectedTime, value, _SelectPoints, _SelectPoints.LegendList[0].Symbol, "1");
                        _SelectPoints.Points.Add(curvePData);
                        DataPoint point = null;
                        lineSeries.InsertDataPoint(selectedTime, value, curvePData, CurvePoint_MouseEnter, CurvePoint_MouseLeave, ref  point, symbolType);

                        point.DataUIElements.ForEach(u =>
                        {
                            _VitalSignsContainer.Children.Add(u);
                        });
                        args.Point = curvePData;
                        this.RaiseEvent(args);
                        VitalSignCurveDetailModel detail = Curves.Find(p => p.CurveCode == _SelectPoints.CurveCode);
                        detail.Points = detail.Points.OrderBy(x => x.Time).ToList();
                    }
                    _tooltipContent = _strMargin + _SelectPoints.CurveName + "\n—————————————" + "\n" + _strMargin + "时间：" + selectedTime.ToString("yyyy-MM-dd HH:mm:ss") + "\n" + _strMargin + "值：" + value;
                    _VitalSignsToolTip.Content = _tooltipContent;
                    _VitalSignsToolTip.IsOpen = false;
                    _VitalSignsToolTip.IsOpen = true;
                }
            }
            else
            {
                _horizationLine.Visibility = System.Windows.Visibility.Hidden;
                _verticalLine.Visibility = System.Windows.Visibility.Hidden;

                if (_mousePosition.X < _AxisStartPoint.X || _mousePosition.X > _AxisMaxX)
                {
                    _VitalSignsToolTip.IsOpen = false;
                    _dragXAxisTip.IsOpen = false;
                    return;
                }
            }

            if (!_isMouseOverPoint)
            {
                _tooltipContent = "时间：" + _XAxis.GetTime(_mousePosition.X).ToString("yyyy-MM-dd HH:mm:ss");
                _VitalSignsToolTip.Content = _tooltipContent;
                _VitalSignsToolTip.IsOpen = false;
                _VitalSignsToolTip.IsOpen = true;
            }

            #region 遍历方式（已修改为事件触发）

            //LineSeries series = _curveLineSeries.Find(s => s.Contains());
            //string tooltipContent = string.Empty;
            //if (series != null)
            //{
            //    this.Cursor = Cursors.Pen;

            //    DataPoint data = series.GetDataPoint();
            //    //tooltipContent += strMargin + series.Name;
            //    //tooltipContent += "\n—————————————";
            //    //tooltipContent += "\n" + strMargin + "时间：" + data.Time.ToString("yyyy-MM-dd HH:mm:ss");
            //    //tooltipContent += "\n" + strMargin + "值：" + data.Value;
            //    _tooltipContent = _strMargin + series.Name + "\n—————————————" + "\n" + _strMargin + "时间：" + data.Time.ToString("yyyy-MM-dd HH:mm:ss") + "\n" + _strMargin + "值：" + data.Value;
            //}
            //else
            //{
            //    this.Cursor = Cursors.Arrow;
            //    DataPoint dP = _eventDataPonits.Find(d => d.DataUIElements.Exists(i => i.IsMouseOver));
            //    if (dP != null)
            //    {
            //        //tooltipContent += strMargin + dP.Name;
            //        //tooltipContent += "\n—————————————";
            //        //tooltipContent += "\n" + strMargin + "时间：" + dP.Time.ToString("yyyy-MM-dd HH:mm:ss");
            //        _tooltipContent = _strMargin + dP.Name + "\n—————————————" + "\n" + _strMargin + "时间：" + dP.Time.ToString("yyyy-MM-dd HH:mm:ss");
            //    }
            //    else
            //    {
            //        _tooltipContent = "时间：" + _XAxis.GetTime(_mousePosition.X).ToString("yyyy-MM-dd HH:mm:ss");
            //    }
            //}

            ////_VitalSignsToolTip.HorizontalOffset = 1;
            ////_VitalSignsToolTip.VerticalOffset = 1;

            //_VitalSignsToolTip.Content = _tooltipContent;
            //_VitalSignsToolTip.IsOpen = false;
            //_VitalSignsToolTip.IsOpen = true;
            //_MouseOldLocation = _mousePosition;

            #endregion
        }


        void VitalSignsControl_MouseEnter(object sender, MouseEventArgs e)
        {
            //Point p = e.GetPosition(this);
            //SetLocationLines(p);
        }

        public static void XAxisSettingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as VitalSignsControl).InitXAxis(e.NewValue as AxisSetting);
            if ((d as VitalSignsControl)._isLoaded)
            {
                (d as VitalSignsControl).DrawXAxis();
                (d as VitalSignsControl).ReDraw();
            }
        }
        private static void OnYAxisSettingsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as VitalSignsControl).InitYAxis((List<YAxisSetting>)e.NewValue);
            if ((d as VitalSignsControl)._isLoaded)
            {
                (d as VitalSignsControl).DrawYAxis();
                (d as VitalSignsControl).ReDraw();
            }
        }
        private static void OnBreathParamChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((d as VitalSignsControl)._isLoaded)
                (d as VitalSignsControl).DrawBreathMark();
        }
        private static void OnCurvesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((d as VitalSignsControl)._isLoaded)
            {
                (d as VitalSignsControl).DrawYAxis();
                (d as VitalSignsControl).DrawCurves();
                (d as VitalSignsControl).DrawLegend();
                (d as VitalSignsControl).DrawTextPoints();
            }
        }
        private static void OnEventMarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((d as VitalSignsControl)._isLoaded)
            {
                (d as VitalSignsControl).DrawEventMark();
                (d as VitalSignsControl).DrawLegend();
                (d as VitalSignsControl).DrawTextPoints();
            }
        }
        private static void OnTextPointsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if ((d as VitalSignsControl)._isLoaded)
            //    (d as VitalSignsControl).DrawEventMark();
        }

        private static void OnIsEditEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private static void OnIsHiddenEventMarkAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as VitalSignsControl).SetEventMarkArea();
            if ((d as VitalSignsControl)._isLoaded)
            {
                (d as VitalSignsControl).DrawEventsMarkHeader();
                (d as VitalSignsControl).ReDraw();
            }
        }
        #endregion

        private void SetEventMarkArea()
        {
            if (IsHiddenEventMarkArea)
            {
                EventDescRow.Height = new GridLength(0);
                VitalSignsRow.Height = new GridLength(1.0, GridUnitType.Star);
                _VitalSignsHeightPercent = 1;
            }
        }

        public void InitXAxis(AxisSetting xAxisSetting)
        {
            if (xAxisSetting == null)
                return;
            if (_XAxis == null)
                _XAxis = new DateAxis();
            _XAxis.MinTime = xAxisSetting.BeginTime ?? DateTime.Now.AddHours(-1);
            _XAxis.MaxTime = xAxisSetting.EndTime ?? DateTime.Now.AddHours(1);
            _XAxis.Title = xAxisSetting.Title;
            _XAxis.MinorUnit = xAxisSetting.MinorUnit ?? DateUnit.Minute;
            _XAxis.MajorUnit = xAxisSetting.MajorUnit ?? DateUnit.Minute;
            _XAxis.MinorStep = xAxisSetting.MinorStep ?? 5;
            _XAxis.MajorStep = xAxisSetting.MajorStep ?? 15;
            _XAxis.MoveMinLimitTime = xAxisSetting.MoveMinLimitTime;
            _XAxis.MoveMaxLimitTime = xAxisSetting.MoveMaxLimitTime;
        }

        public void InitYAxis(List<YAxisSetting> YAxisSettings)
        {
            if (YAxisSettings == null)
                return;

            _YAxises = new List<Axis>();
            foreach (YAxisSetting setting in YAxisSettings)
            {
                Axis yAxis = new Axis();
                yAxis.IsPrimary = setting.IsPrimary;
                yAxis.Index = setting.Index;
                yAxis.Min = setting.MinVal;
                yAxis.Max = setting.MaxVal;
                yAxis.Title = setting.Title;
                yAxis.Unit = setting.Unit;
                yAxis.MinorStep = setting.MinorStep ?? 0;
                yAxis.MajorStep = setting.MajorStep ?? 20;
                _YAxises.Add(yAxis);
            }
        }
        private void Draw()
        {
            DrawXAxis();
            DrawYAxis();
            DrawTimeProcess(_processTime);
            DrawCurves();
            DrawTextPoints();
            DrawLegend();
            if (!IsHiddenEventMarkArea)
            {
                DrawHeader();
                DrawBreathMark();
                DrawEventMark();
            }
        }

        private void ReDraw()
        {
            DrawTimeProcess(_processTime);
            DrawCurves();
            DrawTextPoints();
            DrawEventMark();
        }

        /// <summary>
        /// 画X轴
        /// </summary>
        private void DrawXAxis()
        {
            if (_XAxisItems != null && _XAxisItems.Count > 0)
            {
                _XAxisItems.ForEach(p => _VitalSignsContainer.Children.Remove(p));
                _XAxisItems.Clear();
            }

            if (_XAxis == null)
                return;

            _XAxis.MinPix = AxisStartPoint.X;
            _XAxis.MaxPix = AxisStartPoint.Y + _VitalSignsDrawWidth;
            _XAxis.Draw((p, isMajorGrid) =>
            {
                Point StartP = new Point(p, AxisStartPoint.Y);
                Point EndP = new Point(p, _VitalSignsDrawHeight);
                Path xAxisLine = DrawLine(StartP, EndP, _DefaultSetting.GridThickness, !isMajorGrid);
                _VitalSignsContainer.Children.Add(xAxisLine);
                _XAxisItems.Add(xAxisLine);
            }, null);

            //纵向定位线
            if (_verticalLine == null)
            {
                _verticalLine = new Line();
                _VitalSignsContainer.Children.Add(_verticalLine);
            }
            _verticalLine.StrokeThickness = 1.2;
            _verticalLine.SnapsToDevicePixels = true;
            _verticalLine.Opacity = 0.3;
            _verticalLine.Stroke = new SolidColorBrush(Colors.Red);
            _verticalLine.X1 = _XAxis.MinPix;
            _verticalLine.Y1 = AxisStartPoint.Y;
            _verticalLine.X2 = _XAxis.MinPix;
            _verticalLine.Y2 = AxisStartPoint.Y + _VitalSignsDrawHeight;
            _verticalLine.Visibility = System.Windows.Visibility.Collapsed;
            _verticalLine.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            _verticalLine.VerticalAlignment = System.Windows.VerticalAlignment.Top;
        }
        /// <summary>
        /// 画Y轴
        /// </summary>
        private void DrawYAxis()
        {
            if (_YAxisItems != null && _YAxisItems.Count > 0)
            {
                _YAxisItems.ForEach(p => _VitalSignsContainer.Children.Remove(p));
                _YAxisItems.Clear();
            }
            if (_YAxises == null)
                return;

            double fontSize = 10;
            string fontFamily = "微软雅黑";
            double textHeight, textWidth;
            Thickness yAxisLineThickness = new Thickness(1, 0, 8, 0);
            double yAxisLineStroke = 3;
            double labelMargin = 4;
            double axisMargin = 4;
            double AxisWidth = GetAxisWidth(fontSize, fontFamily, labelMargin);
            int i = 1;
            int MoreMajorTics = DigitRows;
            foreach (Axis yAxis in _YAxises)
            {
                if (yAxis == null)
                    continue;

                bool isPrimary = yAxis.IsPrimary;
                yAxis.MoreMajorTics = MoreMajorTics;
                yAxis.MinPix = AxisStartPoint.Y;
                yAxis.MaxPix = AxisStartPoint.Y + _VitalSignsDrawHeight;

                double x = AxisStartPoint.X - yAxisLineThickness.Right;
                if (!isPrimary)
                {
                    x = AxisStartPoint.X - yAxisLineThickness.Right - (AxisWidth + axisMargin) * i;
                    i++;
                }

                yAxis.Draw((p, isMajorGrid, isOverMax) =>
                {
                    if (isPrimary)
                    {
                        Point StartP = new Point(AxisStartPoint.X, _VitalSignsDrawHeight - p);
                        if (isOverMax)
                            StartP = new Point(StartPoint.X, _VitalSignsDrawHeight - p);
                        Point EndP = new Point(_VitalSignsDrawWidth, _VitalSignsDrawHeight - p);
                        Path gridLine = DrawLine(StartP, EndP, _DefaultSetting.GridThickness, isOverMax ? false : true);
                        _VitalSignsContainer.Children.Add(gridLine);
                        _YAxisItems.Add(gridLine);
                    }
                }, (p, val, isMajorTic) =>
                {
                    //画刻度Label
                    string labelText = val.ToString();
                    textHeight = PathHelper.MeasureTextHeight(labelText, fontSize, fontFamily);
                    textWidth = PathHelper.MeasureTextWidth(labelText, fontSize, fontFamily);

                    TextBlock tb = new TextBlock();
                    tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    tb.Text = labelText;
                    tb.FontFamily = new FontFamily(fontFamily);
                    if (textWidth > AxisWidth)
                    {
                        tb.FontSize = GetFontSize(labelText, AxisWidth + yAxisLineStroke, fontSize, fontFamily);
                        textWidth = PathHelper.MeasureTextWidth(labelText, tb.FontSize, fontFamily);
                    }
                    else
                    {
                        tb.FontSize = fontSize;
                        tb.Width = textWidth;
                    }

                    double y = _VitalSignsDrawHeight - p - textHeight / 2;
                    if (val is string)
                    {
                        y = y + textHeight / 2;
                        _LegendStartY = y;
                    }
                    if (y < 0)
                    {
                        y = AxisStartPoint.Y;
                    }
                    else if (y + textHeight > _VitalSignsDrawHeight)
                        y = _VitalSignsDrawHeight - textHeight;

                    if (p > yAxis.LocalTransform(yAxis.Max))
                    {
                        tb.Margin = new Thickness(x - textWidth + yAxisLineStroke, y, 0, 0);
                        tb.Foreground = new SolidColorBrush(_YAxiseColors[i - 1]);
                        tb.FontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        tb.Margin = new Thickness(x - textWidth - labelMargin, y, 0, 0);
                        tb.Foreground = new SolidColorBrush(Color.FromRgb(0x58, 0x9E, 0xAD));
                    }

                    _VitalSignsContainer.Children.Add(tb);
                    _YAxisItems.Add(tb);
                    if (_lastYAxisX == 0 || x - textWidth - labelMargin < _lastYAxisX)
                        _lastYAxisX = x - textWidth - labelMargin;
                });

                Path yAxisLine = PathHelper.DrawLine(new Point(x, _VitalSignsDrawHeight - yAxis.LocalTransform(yAxis.Min) - 2), new Point(x, _VitalSignsDrawHeight - yAxis.LocalTransform(yAxis.Max + yAxis.MajorStep / 2)), _YAxiseColors[i - 1], yAxisLineStroke);
                _VitalSignsContainer.Children.Add(yAxisLine);
                _YAxisItems.Add(yAxisLine);
            }

            //横向定位线
            if (_horizationLine == null)
            {
                _horizationLine = new Line();
                _VitalSignsContainer.Children.Add(_horizationLine);
            }
            _horizationLine.StrokeThickness = 1.2;
            _horizationLine.SnapsToDevicePixels = true;
            _horizationLine.Opacity = 0.3;
            _horizationLine.Stroke = new SolidColorBrush(Colors.Red);
            _horizationLine.X1 = AxisStartPoint.X;
            _horizationLine.Y1 = AxisStartPoint.Y;
            _horizationLine.X2 = AxisStartPoint.X + _VitalSignsDrawWidth;
            _horizationLine.Y2 = AxisStartPoint.Y;
            _horizationLine.Visibility = System.Windows.Visibility.Hidden;
            _horizationLine.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            _horizationLine.VerticalAlignment = System.Windows.VerticalAlignment.Top;
        }
        private double GetFontSize(string text, double targetWidth, double orgFontSize, string fontFamily)
        {
            double textWidth = PathHelper.MeasureTextWidth(text, orgFontSize, fontFamily);
            while (textWidth > targetWidth)
            {
                orgFontSize -= 0.1;
                textWidth = PathHelper.MeasureTextWidth(text, orgFontSize, fontFamily);
            }
            return orgFontSize;
        }

        private double GetAxisWidth(double fontSize, string fontFamily, double labelMargin)
        {
            return PathHelper.MeasureTextWidth("100", fontSize, fontFamily) + labelMargin * 2;
        }

        private Path DrawLine(Point StartP, Point EndP, double StrokeThickness = _DefaultSetting.GridThickness, bool IsDash = false)
        {
            return DrawLine(StartP, EndP, GridLineColor, StrokeThickness, IsDash);
        }

        private Path DrawLine(Point StartP, Point EndP, Color LineColor, double StrokeThickness = _DefaultSetting.GridThickness, bool IsDash = false)
        {
            if (IsDash)
                return PathHelper.DrawLine(StartP, EndP, LineColor, StrokeThickness, _DefaultSetting.DefaultDashArray);
            else
                return PathHelper.DrawLine(StartP, EndP, LineColor, StrokeThickness);
        }
        /// <summary>
        /// 画事件标记区Header和事件备注区Header
        /// </summary>
        private void DrawHeader()
        {
            DrawEventsMarkHeader();
            DrawEventsDescHeader();
        }
        /// <summary>
        /// 画事件标记区Header
        /// </summary>
        private void DrawEventsMarkHeader()
        {
            if (_EventMarkHeaderUIElements != null && _EventMarkHeaderUIElements.Count > 0)
            {
                _EventMarkHeaderUIElements.ForEach(p => _VitalSignsContainer.Children.Remove(p));
                _EventMarkHeaderUIElements.Clear();
            }
            if (IsHiddenEventMarkArea)
            {
                return;
            }

            //画分割线
            double lineY = _VitalSignsDrawHeight + _VSignsEventMarkDividingLineHeight / 2;
            var path = DrawLine(new Point(StartPoint.X, lineY), new Point(_VitalSignsDrawWidth, lineY), Color.FromRgb(0xA9, 0xE0, 0xE4), _VSignsEventMarkDividingLineHeight);
            _VitalSignsContainer.Children.Add(path);
            _EventMarkHeaderUIElements.Add(path);

            //draw header
            double textHeight = _EventMarkDrawHeight;
            double textWidth = PathHelper.MeasureTextWidth(_eventMarkHeaderText, _eventHeaderFontSize, _eventHeaderFontFamily);
            _eventHeaderWidth = textWidth + _eventHeaderHMargin * 2;

            Rectangle rect = PathHelper.DrawRectangle(_eventHeaderWidth, _EventMarkDrawHeight, new Thickness(0), new SolidColorBrush(_eventMarkHeaderBgColor));
            rect.Margin = new Thickness(0, _EventMarkStartPoint.Y, 0, 0);
            _VitalSignsContainer.Children.Add(rect);
            _EventMarkHeaderUIElements.Add(rect);

            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            tb.Margin = new Thickness(_eventHeaderHMargin, _EventMarkStartPoint.Y, 0, 0);
            tb.Foreground = new SolidColorBrush(_eventHeaderForeground);
            tb.FontSize = _eventHeaderFontSize;
            tb.FontFamily = new FontFamily(_eventHeaderFontFamily);
            //tb.Height = textHeight;
            tb.Width = textWidth;
            tb.Text = _eventMarkHeaderText;
            tb.Background = new SolidColorBrush(_eventMarkHeaderBgColor);
            _VitalSignsContainer.Children.Add(tb);
            _EventMarkHeaderUIElements.Add(tb);
        }
        /// <summary>
        /// 画事件备注区
        /// </summary>
        private void DrawEventsDescHeader()
        {
            //draw header
            double textHeight = _eventDescContainer.ActualHeight;
            double textWidth = PathHelper.MeasureTextWidth(_eventDescHeaderText, _eventHeaderFontSize, _eventHeaderFontFamily);

            _eventDescHeaderWidth = textWidth + _eventHeaderHMargin * 2;
            Rectangle rect = PathHelper.DrawRectangle(_eventDescHeaderWidth, _eventDescContainer.ActualHeight, new Thickness(0), new SolidColorBrush(_eventDescHeaderBgColor));
            _eventDescContainer.Children.Add(rect);

            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            tb.Margin = new Thickness(_eventHeaderHMargin, 0, 0, 0);
            tb.Foreground = new SolidColorBrush(_eventHeaderForeground);
            tb.FontSize = _eventHeaderFontSize;
            tb.FontFamily = new FontFamily(_eventHeaderFontFamily);
            //tb.Height = textHeight;
            tb.Width = textWidth;
            tb.Text = _eventDescHeaderText;
            tb.Background = new SolidColorBrush(_eventDescHeaderBgColor);
            _eventDescContainer.Children.Add(tb);
        }

        double lastY = 0.0;
        /// <summary>
        /// 画曲线
        /// </summary>
        private void DrawCurves()
        {
            lastY = 0.0;
            //清除所有曲线
            if (_curveLineSeries != null && _curveLineSeries.Count > 0)
            {
                foreach (var lineSeries in _curveLineSeries)
                {
                    RemoveLineSeriesToChart(lineSeries);
                }
                _curveLineSeries.Clear();
            }
            if (_CurvesUIItems != null && _CurvesUIItems.Count > 0)
            {
                foreach (var curveItem in _CurvesUIItems.Values)
                {
                    curveItem.ForEach(s => _VitalSignsContainer.Children.Remove(s));
                }
                _CurvesUIItems.Clear();
            }
            if (Curves == null || Curves.Count == 0)
                return;

            Axis yAxis = null;
            Axis primaryYAxis = null;
            bool isOverMin, isOverMax;
            primaryYAxis = _YAxises.Find(p => p.IsPrimary);
            int iDigitRowIndex = 0;
            double headerFontSize = 12;
            double pointFontSize = 10;
            string pointFontFamily = "微软雅黑";
            //double pointWidth, pointHeight;
            //pointWidth = pointHeight = 4;
            foreach (VitalSignCurveDetailModel curve in Curves)
            {
                if (!curve.Visible)
                    continue;
                if (!_CurvesUIItems.ContainsKey(curve))
                    _CurvesUIItems.Add(curve, new List<UIElement>());
                List<UIElement> curveUIElements = _CurvesUIItems[curve];
                yAxis = _YAxises.Find(p => p.Index == curve.YAxisIndex);
                if (yAxis == null)
                    continue;

                Color curveColor = PathHelper.ConvertToMediaColor(curve.Color);
                LineSeries lineSeries = new LineSeries(_XAxis, yAxis, _VitalSignsDrawHeight);
                lineSeries.LineColor = curveColor;
                lineSeries.Name = curve.CurveName;
                _curveLineSeries.Add(lineSeries);

                double y = 0;
                if (curve.IsDigit)
                {
                    y = _VitalSignsDrawHeight - primaryYAxis.MaxPix + (iDigitRowIndex + 1) * primaryYAxis.MajorStepPix - primaryYAxis.MajorStepPix / 2;
                    //画header 
                    double headerX = AxisStartPoint.X / 2;
                    Color headerColor = Color.FromRgb(0x09, 0xA9, 0xBC);
                    UIElement point = GetTextPoint(new Point(headerX, y), curve.CurveName, headerFontSize, pointFontFamily, headerColor);
                    _VitalSignsContainer.Children.Add(point);
                    curveUIElements.Add(point);

                    Color headLineColor = Color.FromRgb(0x21, 0xC1, 0xD4);
                    if (iDigitRowIndex % 2 != 0)
                        headLineColor = Color.FromRgb(0x90, 0xE0, 0xE9);
                    Rectangle header = PathHelper.DrawRectangle(3, primaryYAxis.MajorStepPix - 0.5, new Thickness(StartPoint.X, y - primaryYAxis.MajorStepPix / 2 + 0.5, 0, 0), new SolidColorBrush(headLineColor));
                    _VitalSignsContainer.Children.Add(header);
                    curveUIElements.Add(header);

                    iDigitRowIndex++;

                    lastY = y;
                }
                for (int i = 0; i < curve.Points.Count; i++)
                {
                    VitalSignPointModel curvePointData = curve.Points[i];
                    if (!IsValidPoint(curve, curvePointData))
                    {
                        lineSeries.MoveToNextFigure();
                        continue;
                    }

                    double x = _XAxis.LocalTransform(curvePointData.Time, out isOverMin, out isOverMax);
                    if (isOverMin || isOverMax)
                        continue;

                    UIElement point;
                    if (curve.IsDigit)
                    {
                        point = GetTextPoint(new Point(x, y), curvePointData.Value.ToString(), pointFontSize, pointFontFamily, Color.FromRgb(0x69, 0x6E, 0x70));
                        _VitalSignsContainer.Children.Add(point);
                        curveUIElements.Add(point);
                    }
                    else
                    {
                        SymbolType symbolType = SymbolType.Point;
                        if (curvePointData.Symbol != null)
                            symbolType = curvePointData.Symbol.SymbolType;
                        DataPoint point1 = null;
                        lineSeries.AddDataPoint(curvePointData.Time, double.Parse(curvePointData.Value.ToString()), curvePointData, CurvePoint_MouseEnter, CurvePoint_MouseLeave, ref point1, symbolType);
                    }

                    if (i + 1 < curve.Points.Count && IsNeedMoveToNextFigure(curve, curvePointData.Time, curve.Points[i + 1].Time))
                    {
                        lineSeries.MoveToNextFigure();
                        continue;
                    }
                }
                AddLineSeriesToChart(lineSeries);
            }
        }

        void CurvePoint_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _isMouseOverPoint = true;
            this.Cursor = Cursors.Pen;
            VitalSignPointModel pData = null;
            if ((sender as FrameworkElement).Tag is VitalSignPointModel)
            {
                pData = (sender as FrameworkElement).Tag as VitalSignPointModel;

                //VitalSignPointModel data = (sender as FrameworkElement).Tag as VitalSignPointModel;
                _tooltipContent = _strMargin + pData.Curve.CurveName + "\n—————————————" + "\n" + _strMargin + "时间：" + pData.Time.ToString("yyyy-MM-dd HH:mm:ss") + "\n" + _strMargin + "值：" + pData.Value;
                _VitalSignsToolTip.Content = _tooltipContent;
                _VitalSignsToolTip.IsOpen = false;
                _VitalSignsToolTip.IsOpen = true;
            }
        }

        void CurvePoint_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _isMouseOverPoint = false;
            _VitalSignsToolTip.IsOpen = false;
            _VitalSignsToolTip.Content = string.Empty;
            this.Cursor = Cursors.Arrow;
        }
        /// <summary>
        /// 会诊文本点,绘制血气
        /// </summary>
        private void DrawTextPoints()
        {
            _TextPointItems.ForEach(s => _VitalSignsContainer.Children.Remove(s));
            _TextPointItems.Clear();
            if (TextMarkPoints == null || TextMarkPoints.Count == 0)
                return;

            double fontSize = 12;
            string fontFamily = "微软雅黑";
            Axis primaryYAxis = _YAxises.Find(t => t.IsPrimary);
            foreach (TextMarkPoint p in TextMarkPoints)
            {
                if (p.MarkTime < _XAxis.MinTime || p.MarkTime > _XAxis.MaxTime)
                    continue;
                bool IsOverMin, IsOverMax;
                double x = _XAxis.LocalTransform(p.MarkTime, out IsOverMin, out IsOverMax);
                double textHeight = PathHelper.MeasureTextHeight(p.MarkText, fontSize, fontFamily);
                //var y = _VitalSignsDrawHeight - primaryYAxis.MaxPix + primaryYAxis.MajorStepPix * DigitRows + textHeight / 2;
                // 此处的Y不是传统上的Y坐标，而是根据Y计算Margin.Top属性
                // 注：10的来源：_YAxises.Find(t => t.IsPrimary).MajorStepPix/2等于10，因为mmhg这个轴设置就是20
                var y = _VitalSignsDrawHeight - _YAxises.Find(t => t.IsPrimary).MaxPix + textHeight / 2 + lastY + 10;
                TextBlock tb = GetTextPoint(new Point(x, y), p.MarkText, fontSize, fontFamily, Color.FromRgb(0x25, 0x9D, 0xAC));
                _VitalSignsContainer.Children.Add(tb);
                Grid.SetZIndex(tb, -1);
                _TextPointItems.Add(tb);
            }
        }
        /// <summary>
        /// 将曲线对像添加到Chart中去
        /// </summary>
        /// <param name="lineSeries"></param>
        public void AddLineSeriesToChart(LineSeries lineSeries)
        {
            _VitalSignsContainer.Children.Add(lineSeries.LinePath);
            foreach (var point in lineSeries.Points)
            {
                point.DataUIElements.ForEach(u =>
            {
                _VitalSignsContainer.Children.Add(u);
                //u.MouseLeftButtonDown += u_MouseLeftButtonDown;
            });
            }
            //this.dataPointMarker.AddPointMarker(lineSeries);
            //if (string.IsNullOrEmpty(lineSeries.Name))
            //    lineSeries.Name = string.Format("P{0}", _series.Count);
            //_series.Add(lineSeries);
        }

        void u_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _curvePointClickNum += 1;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; _curvePointClickNum = 0; };
            timer.IsEnabled = true;

            Point p = e.GetPosition(_VitalSignsContainer);
            if (_curvePointClickNum % 2 == 0)
            {
                timer.IsEnabled = false;
                timer = null;
                _curvePointClickNum = 0;

                CurveEventArgs args = new CurveEventArgs(CurvePointDoubleClickRoutedEvent, sender);
                if ((sender as FrameworkElement).Tag != null && (sender as FrameworkElement).Tag is VitalSignPointModel)
                {
                    args.Point = (sender as FrameworkElement).Tag as VitalSignPointModel;
                }
                this.RaiseEvent(args);
            }
        }
        public void RemoveLineSeriesToChart(LineSeries lineSeries)
        {
            _VitalSignsContainer.Children.Remove(lineSeries.LinePath);
            foreach (var point in lineSeries.Points)
            {
                point.DataUIElements.ForEach(u =>
                {
                    u.MouseLeftButtonDown -= u_MouseLeftButtonDown;
                    _VitalSignsContainer.Children.Remove(u);
                });
            }
            //this.dataPointMarker.AddPointMarker(lineSeries);
            //if (string.IsNullOrEmpty(lineSeries.Name))
            //    lineSeries.Name = string.Format("P{0}", _series.Count);
            //_series.Add(lineSeries);
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="curvePointData"></param>
        /// <returns>true：有效，false：无效</returns>
        private bool IsValidPoint(VitalSignCurveDetailModel curve, VitalSignPointModel curvePointData)
        {
            if (curve.HideTime == null)
                return true;
            else if (curve.HideTime.Exists(p => p.EndDateTime.HasValue && p.StartDateTime.HasValue && curvePointData.Time >= p.StartDateTime && curvePointData.Time <= p.EndDateTime))
                return false;
            else if (curve.HideTime.Exists(p => !p.EndDateTime.HasValue && p.StartDateTime.HasValue && curvePointData.Time >= p.StartDateTime))
                return false;
            else
                return true;
        }
        private bool IsNeedMoveToNextFigure(VitalSignCurveDetailModel curve, DateTime time1, DateTime time2)
        {
            return curve.HideTime != null && (curve.HideTime.Exists(p => p.StartDateTime.HasValue && p.EndDateTime.HasValue && 
                                                                         time1 <= p.StartDateTime && time2 >= p.EndDateTime && 
                                                                         p.EndDateTime >= p.StartDateTime)
                                           || curve.HideTime.Exists(p => p.StartDateTime.HasValue && !p.EndDateTime.HasValue && 
                                                                         time1 <= p.StartDateTime && time2 >= p.StartDateTime && 
                                                                         p.EndDateTime >= p.StartDateTime));
        }

        private TextBlock GetTextPoint(Point point, string text, double fontSize, string fontFamily, Color forColor)
        {
            double textHeight = text == null ? 0 : PathHelper.MeasureTextHeight(text, fontSize, fontFamily);
            double textWidth = text == null ? 0 : PathHelper.MeasureTextWidth(text, fontSize, fontFamily);
            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            tb.FontFamily = new FontFamily(fontFamily);
            tb.FontSize = fontSize;
            tb.Foreground = new SolidColorBrush(forColor);
            tb.Margin = new Thickness(point.X - textWidth / 2, point.Y - textHeight / 2, 0, 0);
            tb.Text = text;
            return tb;
        }

        /// <summary>
        /// 画潮气量图标
        /// </summary>
        /// <param name="model"></param>
        private void DrawBreathMark()
        {
            if (_BreathParamUIElements != null && _BreathParamUIElements.Count > 0)
            {
                _BreathParamUIElements.ForEach(u => _VitalSignsContainer.Children.Remove(u));
                _BreathParamUIElements.Clear();
            }

            if (BreathParam == null)
                return;

            #region 画潮气量标识

            double pointWidth = 7;
            double x = StartPoint.X + _eventHeaderWidth + pointWidth * 2 + 10;
            double y = _EventMarkStartPoint.Y + _EventMarkDrawHeight / 2;

            Color markColor = Color.FromRgb(0x8B, 0xC3, 0xE6);
            Path breathPath = Symbol.MakePath(SymbolType.Ext_Breath, new Point(x, y), new Size(pointWidth, pointWidth), markColor, markColor);
            breathPath.StrokeThickness = 2;
            _VitalSignsContainer.Children.Add(breathPath);
            _BreathParamUIElements.Add(breathPath);

            double fontSize = 8;
            string fontFamily = "微软雅黑";
            Color fontColor = Color.FromRgb(0x30, 0x77, 0xA2);
            double textHeight = PathHelper.MeasureTextHeight("E", fontSize, fontFamily);
            TextBlock tbTop = GetTextPoint(new Point(x, y - pointWidth / 2 - textHeight / 2), BreathParam.TopParamName, fontSize, fontFamily, fontColor);
            TextBlock tbLeft = GetTextPoint(new Point(x - pointWidth * 1.2D, y + pointWidth / 2 + textHeight / 2), BreathParam.LeftParamName, fontSize, fontFamily, fontColor);
            TextBlock tbRight = GetTextPoint(new Point(x + pointWidth * 1.2D, y + pointWidth / 2 + textHeight / 2), BreathParam.RightParamName, fontSize, fontFamily, fontColor);
            _VitalSignsContainer.Children.Add(tbTop);
            _VitalSignsContainer.Children.Add(tbLeft);
            _VitalSignsContainer.Children.Add(tbRight);
            _BreathParamUIElements.Add(tbTop);
            _BreathParamUIElements.Add(tbLeft);
            _BreathParamUIElements.Add(tbRight);

            #endregion

            #region 画潮气量数据
            if (BreathParam.BreathParalList != null && BreathParam.BreathParalList.Count > 0)
            {
                y = _VitalSignsDrawHeight - _YAxises.Find(a => a.Index == BreathParam.YAxisIndex).LocalTransform(BreathParam.YLocation.HasValue ? BreathParam.YLocation.Value : 30);
                foreach (var breath in BreathParam.BreathParalList)
                {
                    bool isOverMin, isOverMax;
                    x = _XAxis.LocalTransform(breath.Key, out isOverMin, out isOverMax);
                    if (isOverMin || isOverMax)
                        continue;

                    breathPath = Symbol.MakePath(SymbolType.Ext_Breath, new Point(x, y), new Size(pointWidth, pointWidth), markColor, markColor);
                    breathPath.StrokeThickness = 2;
                    _VitalSignsContainer.Children.Add(breathPath);
                    _BreathParamUIElements.Add(breathPath);

                    tbTop = GetTextPoint(new Point(x, y - pointWidth / 2 - textHeight / 2), breath.Value.TopParamVal, fontSize, fontFamily, fontColor);
                    tbLeft = GetTextPoint(new Point(x - pointWidth * 1.2D, y + pointWidth / 2 + textHeight / 2), breath.Value.LeftParamVal, fontSize, fontFamily, fontColor);
                    tbRight = GetTextPoint(new Point(x + pointWidth * 1.2D, y + pointWidth / 2 + textHeight / 2), breath.Value.RightParamVal, fontSize, fontFamily, fontColor);
                    _VitalSignsContainer.Children.Add(tbTop);
                    _VitalSignsContainer.Children.Add(tbLeft);
                    _VitalSignsContainer.Children.Add(tbRight);
                    _BreathParamUIElements.Add(tbTop);
                    _BreathParamUIElements.Add(tbLeft);
                    _BreathParamUIElements.Add(tbRight);
                }
            }
            #endregion
        }

        /// <summary>
        /// 画事件标记
        /// </summary>
        private void DrawEventMark()
        {
            _EventMarkUIElements.ForEach(p =>
            {
                if (_eventDescContainer.Children.Contains(p))
                    _eventDescContainer.Children.Remove(p);
                else
                    _VitalSignsContainer.Children.Remove(p);
            });
            _EventMarkUIElements.Clear();
            _eventDataPonits.Clear();

            if (EventMark == null || EventMark.Points == null || EventMark.Points.Count == 0)
                return;
            //画备注和标记
            string markMeasureText = "22";
            double markWidth = PathHelper.MeasureTextWidth(markMeasureText, _eventMarkFontSize, _eventMarkFontFamily) * 0.9;
            double markHeight = PathHelper.MeasureTextHeight(markMeasureText, _eventMarkFontSize, _eventMarkFontFamily) * 0.9;
            double markTopMargin = 1;
            double markVMargin = 2;
            double? lastX = null;
            double? lastY = null;

            //备注相关计算
            int Columns = 3;
            Thickness markDescMargin = new Thickness(10, 5, 10, 5);
            Thickness descTxtMargin = new Thickness(8, 2, 20, 2);
            double minRowPadding = 3;
            double txtMarginRight = 10;
            double columnWidth = (_eventDescContainerOrginWidth - _eventDescHeaderWidth - markDescMargin.Left - markDescMargin.Right) / Columns;
            double txtWidth = columnWidth - txtMarginRight - descTxtMargin.Left - descTxtMargin.Right;
            string markDescMeasureText = "22";
            double descTxtHeight = PathHelper.MeasureTextHeight(markDescMeasureText, _eventDescFontSize, _eventDescFontFamily);
            Point descStartPoint = new Point(_eventDescHeaderWidth + markDescMargin.Left, markDescMargin.Top);
            Color descTxtHeaderColor = Color.FromRgb(0x58, 0xC7, 0xE0);
            Color descBgColor = Color.FromRgb(0xFF, 0xFF, 0xFF);
            Color descFontColor = Color.FromRgb(0x6E, 0x6E, 0x6E);
            Color bgColor = Colors.White;
            double descTxtHeaderWidth = 3;

            double descX = descStartPoint.X;
            double descY = descStartPoint.Y;
            int iColumn = 1;
            foreach (var eventPoint in EventMark.Points)
            {
                #region 画备注
                string descText = eventPoint.Index == 0 ? eventPoint.DisplayText : string.Format("{0}. {1}", eventPoint.Index, eventPoint.DisplayText);
                TextBlock descUI = GetEventDescTextBlock(txtWidth, descText, _eventDescFontSize, _eventDescFontFamily, descFontColor);
                descUI.LineHeight = descTxtHeight + 2;
                int txtRows = 1;
                if (PathHelper.MeasureTextWidth(descText, _eventDescFontSize, _eventDescFontFamily) > txtWidth)
                    txtRows = (int)(PathHelper.MeasureTextWidth(descText, _eventDescFontSize, _eventDescFontFamily) / txtWidth) + 1;
                double bgHeight = descUI.LineHeight * txtRows + descTxtMargin.Top + descTxtMargin.Bottom;
                if (descY + bgHeight > _eventDescContainer.ActualHeight - markDescMargin.Bottom)
                {
                    if (iColumn > Columns - 1)
                    {
                        _eventDescContainer.Width += columnWidth;
                    }
                    //换列
                    descX = descStartPoint.X + columnWidth * iColumn;
                    descY = descStartPoint.Y;
                    iColumn++;
                }
                //画背景
                Rectangle txtBg = new Rectangle();
                txtBg.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                txtBg.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                txtBg.Fill = new SolidColorBrush(descBgColor);
                txtBg.Margin = new Thickness(descX, descY, 0, 0);
                txtBg.Width = columnWidth - txtMarginRight;
                txtBg.Height = bgHeight;
                _eventDescContainer.Children.Add(txtBg);
                _EventMarkUIElements.Add(txtBg);

                Rectangle txtHeader = new Rectangle();
                txtHeader.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                txtHeader.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                txtHeader.Fill = new SolidColorBrush(descTxtHeaderColor);
                txtHeader.Margin = new Thickness(descX, descY, 0, 0);
                txtHeader.Width = descTxtHeaderWidth;
                txtHeader.Height = bgHeight;
                _eventDescContainer.Children.Add(txtHeader);
                _EventMarkUIElements.Add(txtHeader);

                descUI.Margin = new Thickness(descX + descTxtMargin.Left, descY + descTxtMargin.Top, 0, 0);
                _eventDescContainer.Children.Add(descUI);
                _EventMarkUIElements.Add(descUI);
                descY += bgHeight + minRowPadding;
                #endregion

                //画标记
                bool isOverMin, isOverMax;
                double x = _XAxis.LocalTransform(eventPoint.TimePoint, out isOverMin, out isOverMax);
                if (!eventPoint.IsContinued && (isOverMin || isOverMax))
                    continue;
                else if (eventPoint.IsContinued && isOverMax)
                    continue;
                double y = _EventMarkStartPoint.Y + markTopMargin + markHeight / 2;
                if (lastX.HasValue && Math.Abs(x - lastX.Value) < markWidth)//事件重叠
                    y = lastY.Value - markHeight - markVMargin;
                FrameworkElement mark;
                Color markColor = PathHelper.ConvertToMediaColor(eventPoint.Color);
                if (eventPoint.IsMarkShow)  //图标
                {
                    mark = Symbol.MakePath(eventPoint.Symbol.SymbolType, new Point(x, y), new Size(markWidth, markHeight), markColor, bgColor);
                }
                else  //画索引
                {
                    mark = GetTextPoint(new Point(x, y), eventPoint.Index.ToString(), _eventMarkFontSize, _eventMarkFontFamily, markColor);
                }
                _VitalSignsContainer.Children.Add(mark);
                _EventMarkUIElements.Add(mark);
                lastX = x;
                lastY = y;
                DataPoint dataPoint = new DataPoint(eventPoint.TimePoint, 0, x, y, mark, eventPoint.Text);
                mark.Tag = dataPoint;
                mark.MouseEnter += mark_MouseEnter;
                mark.MouseLeave += mark_MouseLeave;
                mark.MouseMove += mark_MouseEnter;
                _eventDataPonits.Add(dataPoint);
            }
        }

        void mark_MouseLeave(object sender, MouseEventArgs e)
        {
            _isMouseOverPoint = false;
            this.Cursor = Cursors.Arrow;
            _VitalSignsToolTip.IsOpen = false;
            _VitalSignsToolTip.Content = string.Empty;
        }

        void mark_MouseEnter(object sender, MouseEventArgs e)
        {
            _isMouseOverPoint = true;
            this.Cursor = Cursors.Arrow;
            DataPoint data = (sender as FrameworkElement).Tag as DataPoint;
            _tooltipContent = _strMargin + data.Name + "\n—————————————" + "\n" + _strMargin + "时间：" + data.Time.ToString("yyyy-MM-dd HH:mm:ss");
            _VitalSignsToolTip.Content = _tooltipContent;
            _VitalSignsToolTip.IsOpen = false;
            _VitalSignsToolTip.IsOpen = true;
        }

        private TextBlock GetEventDescTextBlock(double width, string text, double fontSize, string fontFamily, Color forColor)
        {
            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            tb.FontFamily = new FontFamily(fontFamily);
            tb.FontSize = fontSize;
            tb.Foreground = new SolidColorBrush(forColor);
            tb.Text = text;
            tb.Width = width;
            tb.TextWrapping = TextWrapping.Wrap;
            return tb;
        }
        /// <summary>
        /// 需要在Y轴绘制完成后才能绘制图例
        /// </summary>
        private void DrawLegend()
        {
            if (_LegendItems != null && _LegendItems.Count > 0)
            {
                _LegendItems.ForEach(p => _VitalSignsContainer.Children.Remove(p));
                _LegendItems.Clear();
            }
            //画图例背景 
            Thickness LegendMargin = new Thickness(2, 5, 15, 5);
            double x = StartPoint.X + LegendMargin.Left;
            double y = _LegendStartY + LegendMargin.Top;
            double width = _lastYAxisX - LegendMargin.Left - LegendMargin.Right;
            double height = _VitalSignsDrawHeight - _LegendStartY - LegendMargin.Top - LegendMargin.Bottom;
            double headerHeightPercent = 0.07D;
            Color headerColor = Color.FromRgb(0xF6, 0xB0, 0x5D);
            Color bgColor = Color.FromRgb(0xFC, 0xFE, 0xFE);
            Rectangle bg = PathHelper.DrawRectangle(width, height, new Thickness(x, y, 0, 0), new SolidColorBrush(Color.FromRgb(0xC3, 0xC3, 0xC3)), new SolidColorBrush(bgColor));
            _VitalSignsContainer.Children.Add(bg);
            _LegendItems.Add(bg);

            #region header

            Rectangle header = PathHelper.DrawRectangle(width, height * headerHeightPercent, new Thickness(x, y, 0, 0), new SolidColorBrush(headerColor), new SolidColorBrush(headerColor));
            _VitalSignsContainer.Children.Add(header);
            _LegendItems.Add(header);
            //倒三角
            double TriangleWidth = 15;
            Path Triangle = Symbol.MakePath(SymbolType.Ext_TriangleDown, new Point(x + width / 2, y + height * headerHeightPercent), new Size(TriangleWidth, TriangleWidth), headerColor, headerColor);
            Triangle.Fill = new SolidColorBrush(headerColor);
            _VitalSignsContainer.Children.Add(Triangle);
            _LegendItems.Add(Triangle);

            TextBlock tb = GetTextPoint(new Point(x + width / 2, y + height * headerHeightPercent / 2), "图 例", 12, "微软雅黑", Color.FromRgb(0xFF, 0xFF, 0xFF));
            tb.FontWeight = FontWeights.Bold;
            _VitalSignsContainer.Children.Add(tb);
            _LegendItems.Add(tb);

            Image imgSetting = new Image();
            imgSetting.Width = 12;
            imgSetting.Height = 12;
            imgSetting.Source = new BitmapImage(new Uri(@"/MedicalSystem.AnesWorkStation.View;component/Images/LegendSetting.png", UriKind.Relative));
            imgSetting.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            imgSetting.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            imgSetting.Margin = new Thickness(x + width - imgSetting.Width - 6, y + height * headerHeightPercent / 2 - imgSetting.Height / 2, 0, 0);
            imgSetting.MouseLeftButtonDown += imgSetting_MouseLeftButtonDown;
            _VitalSignsContainer.Children.Add(imgSetting);
            _LegendItems.Add(imgSetting);
            #endregion

            #region content

            if (Curves == null && EventMark == null)
                return;

            Thickness itemsMargin = new Thickness(5, 10, 5, 0);
            double itempadding = 4;
            double legendFontSize = 10.5;
            string legendFontFamily = "微软雅黑";
            double yItem = y + height * headerHeightPercent + itemsMargin.Top;
            double itemHeight = PathHelper.MeasureTextHeight("微", legendFontSize, legendFontFamily);
            double itemDefaultWidth = PathHelper.MeasureTextWidth("微微微微微", legendFontSize, legendFontFamily);
            double legendSymbolX = x + itemsMargin.Left + itemDefaultWidth;
            double symbolPadding = 4;
            int i = 0;
            if (Curves != null)
            {
                foreach (var curve in Curves)
                {
                    if (curve.LegendList == null || curve.LegendList.Count == 0 || !curve.Visible || curve.IsDigit)
                        continue;

                    Color curveColor = PathHelper.ConvertToMediaColor(curve.Color);
                    foreach (LegendItem item in curve.LegendList)
                    {
                        if (item.Symbol == null)
                            continue;
                        double itemY = yItem + (itemHeight + itempadding) * i;
                        TextBlock tbLegend = GetTextPoint(new Point(), item.DisplayName, legendFontSize, legendFontFamily, Color.FromRgb(0x77, 0x77, 0x77));
                        tbLegend.Margin = new Thickness(x + itemsMargin.Left, itemY, 0, 0);
                        _VitalSignsContainer.Children.Add(tbLegend);
                        _LegendItems.Add(tbLegend);
                        tbLegend.Tag = curve;
                        tbLegend.MouseLeftButtonDown += tbLegend_MouseLeftButtonDown;
                        //tbLegend.DragOver += tbLegend_DragOver;
                        //tbLegend.Drop += tbLegend_Drop;
                        double symbolHeight = itemHeight * 0.5D;
                        Color symbolColor = curveColor;
                        if (item.Symbol.Brush != null)
                            symbolColor = PathHelper.ConvertToMediaColor(((System.Drawing.SolidBrush)item.Symbol.Brush).Color);

                        double lineY = GetLegendLineY(item.Symbol.SymbolType, itemY + itemHeight / 2, symbolHeight);
                        Path symbolLine = PathHelper.DrawLine(new Point(legendSymbolX, lineY), new Point(legendSymbolX + symbolHeight * 2 + symbolPadding * 3, lineY), curveColor, 1);
                        _VitalSignsContainer.Children.Add(symbolLine);
                        _LegendItems.Add(symbolLine);

                        symbolLine.Tag = curve;
                        symbolLine.MouseLeftButtonDown += tbLegend_MouseLeftButtonDown;

                        Path symbol = Symbol.MakePath(item.Symbol.SymbolType, new Point(legendSymbolX + symbolPadding + symbolHeight / 2, itemY + itemHeight / 2), new Size(symbolHeight, symbolHeight), symbolColor, bgColor, true, item.Symbol.Text);
                        symbol.StrokeThickness = 1;
                        _VitalSignsContainer.Children.Add(symbol);
                        _LegendItems.Add(symbol);

                        symbol.Tag = curve;
                        symbol.MouseLeftButtonDown += tbLegend_MouseLeftButtonDown;

                        symbol = Symbol.MakePath(item.Symbol.SymbolType, new Point(legendSymbolX + symbolPadding + symbolHeight / 2 + symbolHeight + symbolPadding, itemY + itemHeight / 2), new Size(symbolHeight, symbolHeight), symbolColor, bgColor, true, item.Symbol.Text);
                        symbol.StrokeThickness = 1;
                        _VitalSignsContainer.Children.Add(symbol);
                        _LegendItems.Add(symbol);

                        //symbol.Tag = curve;
                        //symbol.MouseLeftButtonDown += tbLegend_MouseLeftButtonDown;

                        i++;
                    }
                }
            }
            if (EventMark != null)
            {
                List<string> lengendTxtList = new List<string>();
                foreach (EventMarkPoint eventPoint in EventMark.Points)
                {
                    if (!eventPoint.IsShowLengend || string.IsNullOrWhiteSpace(eventPoint.LengenedText))
                        continue;
                    if (lengendTxtList.Contains(eventPoint.LengenedText))
                        continue;

                    double itemY = yItem + (itemHeight + itempadding) * i;
                    TextBlock tbLegend = GetTextPoint(new Point(), eventPoint.LengenedText, legendFontSize, legendFontFamily, Color.FromRgb(0x77, 0x77, 0x77));
                    tbLegend.Margin = new Thickness(x + itemsMargin.Left, itemY, 0, 0);
                    _VitalSignsContainer.Children.Add(tbLegend);
                    _LegendItems.Add(tbLegend);
                    lengendTxtList.Add(eventPoint.LengenedText);

                    if (eventPoint.Symbol != null)
                    {
                        double symbolHeight = itemHeight * 0.6D;
                        Color symbolColor = PathHelper.ConvertToMediaColor(eventPoint.Color);
                        if (eventPoint.Symbol.Brush != null)
                            symbolColor = PathHelper.ConvertToMediaColor(((System.Drawing.SolidBrush)eventPoint.Symbol.Brush).Color);

                        Path symbol = Symbol.MakePath(eventPoint.Symbol.SymbolType, new Point(legendSymbolX + symbolPadding + symbolHeight, itemY + itemHeight / 2), new Size(symbolHeight, symbolHeight), symbolColor, bgColor, true);
                        symbol.StrokeThickness = 1;
                        _VitalSignsContainer.Children.Add(symbol);
                        _LegendItems.Add(symbol);
                    }
                    i++;
                }
            }

            #endregion
        }
        void tbLegend_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock)
            {
                VitalSignCurveDetailModel vitalSign = (sender as TextBlock).Tag as VitalSignCurveDetailModel;
                if (vitalSign != null)
                {
                    _SelectPoints = vitalSign;
                    return;
                }
            }
            else
            {
                VitalSignCurveDetailModel vitalSign = (sender as Path).Tag as VitalSignCurveDetailModel;
                if (vitalSign != null)
                {
                    _SelectPoints = vitalSign;
                }
            }


        }
        void tbLegend_Drop(object sender, DragEventArgs e)
        {

        }
        void tbLegend_DragOver(object sender, DragEventArgs e)
        {
            VitalSignCurveDetailModel vitalSign = (sender as TextBlock).Tag as VitalSignCurveDetailModel;
            if (vitalSign != null)
            {

            }
        }
        /// <summary>
        /// 设置图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void imgSetting_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsEditEnable)
                return;
            MouseButtonEventArgs newEventArgs = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton);
            newEventArgs.RoutedEvent = CurveSetClickRoutedEvent;
            RaiseEvent(newEventArgs);
        }

        private double GetLegendLineY(SymbolType SymbolType, double y, double symbolHeight)
        {
            double lineY = y;
            switch (SymbolType)
            {
                case Model.InOperationModel.SymbolType.VLetter:
                    lineY += symbolHeight / 2;
                    break;
                case Model.InOperationModel.SymbolType.VLetterDown:
                    lineY -= symbolHeight / 2;
                    break;
            }
            return lineY;
        }
        /// <summary>
        /// 绘制当前时间进度
        /// </summary>
        /// <param name="time"></param>
        public void DrawTimeProcess(DateTime time)
        {
            if (!_isLoading)
                return;
            if (_TimeRectangle != null)
            {
                _TimeRectangle.Width = 0;
            }

            _processTime = time;
            //if (_TimeRectangle != null)
            //    _VitalSignsContainer.Children.Remove(_TimeRectangle);
            if (_XAxis == null || _processTime < _XAxis.MinTime || _processTime > _XAxis.MaxTime)
                return;
            bool isOverMin, isOverMax;
            double x = _XAxis.LocalTransform(_processTime, out isOverMin, out isOverMax);

            //Color.FromRgb(0xE7, 0xFC, 0xFE)
            LinearGradientBrush bgBrush = new LinearGradientBrush(Color.FromRgb(0xFF, 0xFF, 0xFF), Color.FromRgb(0xBD, 0xF8, 0xFD), 0.0);
            bgBrush.Opacity = 0.3;
            double width = (x - AxisStartPoint.X) < 200 ? (x - AxisStartPoint.X) : 200;
            if (_TimeRectangle == null)
            {
                _TimeRectangle = PathHelper.DrawRectangle(width, _VitalSignsDrawHeight, new Thickness(x - width, AxisStartPoint.Y, 0, 0), bgBrush);
                _VitalSignsContainer.Children.Add(_TimeRectangle);
            }
            else
            {
                if (width > 0)
                    _TimeRectangle.Width = width;
                if (_VitalSignsDrawHeight > 0)
                    _TimeRectangle.Height = _VitalSignsDrawHeight;
                _TimeRectangle.Margin = new Thickness(x - width, AxisStartPoint.Y, 0, 0);
            }
        }
    }
    /// <summary>
    /// 拖拽点数据
    /// </summary>
    public class DragPointData
    {
        public LineSeries Series { get; set; }
        public DataPoint Data { get; set; }
        public Point LastPoint { get; set; }
        public Point FirstDragPoint { get; set; }
        public double MoveY { get; set; }
    }
}
