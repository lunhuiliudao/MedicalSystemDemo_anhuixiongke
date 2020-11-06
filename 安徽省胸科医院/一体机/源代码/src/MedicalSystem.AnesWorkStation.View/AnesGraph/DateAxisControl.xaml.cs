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

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    /// <summary>
    /// DateAxisControl.xaml 的交互逻辑
    /// </summary>
    public partial class DateAxisControl : UserControl
    {
        #region 字段

        /// <summary>
        /// x轴
        /// </summary>
        private DateAxis _XAxis;

        /// <summary>
        /// 过程时长UIElement
        /// </summary>
        private UIElement _ProcessLongUI;

        /// <summary>
        /// 当前时间进度UIElement
        /// </summary>
        private List<UIElement> _TimeProcessUI;

        /// <summary>
        /// x轴元素集合
        /// </summary>
        private List<UIElement> _XAxisItems;

        /// <summary>
        /// x轴设置
        /// </summary>
        //private AxisSetting _XAxisSetting;

        /// <summary>
        /// 是否已加载
        /// </summary>
        private bool _isLoaded;

        /// <summary>
        /// 刻度线颜色
        /// </summary>
        private Color _TicColor = Color.FromRgb(0xFF, 0xFF, 0xFF);//Color.FromRgb(0xAF, 0xAF, 0xAF);
        /// <summary>
        /// 刻度线宽度
        /// </summary>
        private double _TicThickness = 1d;

        private Point _StartPoint;
        private Point _AxisStartPoint;
        //private Point _AxisTicStartPoint;
        /// <summary>
        /// 占主刻度线长度百分比
        /// </summary>
        private double _MinorTicLongPercent;

        private static System.Windows.Threading.DispatcherTimer ProcessTimer = new System.Windows.Threading.DispatcherTimer();
        private static System.Windows.Threading.DispatcherTimer TimeProcessTimer = new System.Windows.Threading.DispatcherTimer();
        #endregion

        #region 私有属性

        /// <summary>
        /// 容器
        /// </summary>
        private Grid _Container
        {
            get
            {
                return this.gridAxis;
            }
        }
        /// <summary>
        /// 头文本（左边）
        /// </summary>
        private string HeadText
        {
            get
            {
                return DateTime.Now.ToString("HH：mm：ss");
            }
        }
        private string TicLabelFormat
        {
            get
            {
                return "HH:mm";
            }
        }
        private double _drawHeight
        {
            get
            {
                return _Container.ActualHeight;
            }
        }
        private double _drawWidth
        {
            get
            {
                return _Container.ActualWidth;
            }
        }

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
                    _AxisStartPoint = new Point(StartPoint.X + _drawWidth * HeadWidthPercent, StartPoint.Y);
                else
                {
                    _AxisStartPoint.X = StartPoint.X + _drawWidth * HeadWidthPercent;
                    _AxisStartPoint.Y = StartPoint.Y;
                }
                return _AxisStartPoint;
            }
        }

        #endregion

        /// <summary>
        /// 默认设置
        /// </summary>
        private class _DefaultSetting
        {
            public const double HeadWidthPercent = 0.2d;
            public const double TicLabelHeightPercent = 0.4d;
            public const double TicAreaHeightPercent = 0.47d;
            public const double TicHeightPercent = 0.8d;
            public const double MinorTicLongPercent = 0.5d;

            public const double DefaultTableHeadThickness = 1d;
            public const double DefaultGridThickness = 1d;
            public static DoubleCollection DefaultDashArray = new DoubleCollection { 10, 5 };
            public static Color DefaultGridLineColor = Color.FromRgb(0xED, 0xED, 0xED);//Color.FromRgb(0xBB, 0xE7, 0xDD);
            public static Color DefaultHeadOddRowBrushColor = Color.FromRgb(0xFC, 0xFE, 0xFE);
            public static Color DefaultHeadEvenRowBrushColor = Color.FromRgb(0xD2, 0xF0, 0xF0);//Color.FromRgb(0x74, 0xC6, 0xD4);
            public static Color DefaultBodyOddRowBrushColor = Colors.White;
            public static Color DefaultBodyEvenRowBrushColor = Color.FromRgb(0xF5, 0xF7, 0xF7);//Color.FromRgb(0xC6, 0xEA, 0xEA);
            public static Color DefaultDataLineColor = Color.FromRgb(0x24, 0xBE, 0xC8);//24BEC8//Color.FromRgb(0x23, 0xC0, 0xC9);            
        }

        #region 依赖属性
        public static readonly DependencyProperty XAxisSettingProperty = DependencyProperty.Register("XAxisSetting", typeof(AxisSetting), typeof(DateAxisControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, XAxisSettingChanged));
        public static readonly DependencyProperty ProcessBeginTimeProperty = DependencyProperty.Register("ProcessBeginTime", typeof(Nullable<DateTime>), typeof(DateAxisControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnProcessBeginTimeChanged));
        public static readonly DependencyProperty ProcessEndTimeProperty = DependencyProperty.Register("ProcessEndTime", typeof(Nullable<DateTime>), typeof(DateAxisControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnProcessEndTimeChanged));
        public static readonly DependencyProperty RescueTimeListProperty = DependencyProperty.Register("RescueTimeList", typeof(List<RescueTime>), typeof(DateAxisControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnRescueTimeListChanged));

        public static readonly RoutedEvent RescueClickRoutedEvent = EventManager.RegisterRoutedEvent("RescueClick", RoutingStrategy.Bubble, typeof(EventHandler<RescueEventArgs>), typeof(DateAxisControl));
        
        #endregion

        #region 事件

        /// <summary>
        /// 抢救时间段点击事件
        /// </summary>
        [Description("抢救时间段点击事件")]
        public event RoutedEventHandler RescueClick
        {
            add { AddHandler(RescueClickRoutedEvent, value); }
            remove { RemoveHandler(RescueClickRoutedEvent, value); }
        }

        #endregion

        #region 公共属性

        /// <summary>
        /// 过程开始时间
        /// </summary>
        public Nullable<DateTime> ProcessBeginTime
        {
            get { return (Nullable<DateTime>)GetValue(ProcessBeginTimeProperty); }
            set
            {
                SetValue(ProcessBeginTimeProperty, value);
            }
        }
        /// <summary>
        /// 过程结束时间
        /// </summary>
        public Nullable<DateTime> ProcessEndTime
        {
            get { return (Nullable<DateTime>)GetValue(ProcessEndTimeProperty); }
            set
            {
                SetValue(ProcessEndTimeProperty, value);
            }
        }
        /// <summary>
        /// 抢救时间
        /// </summary>
        public List<RescueTime> RescueTimeList
        {
            get { return (List<RescueTime>)GetValue(RescueTimeListProperty); }
            set
            {
                SetValue(RescueTimeListProperty, value);
            }
        }
        /// <summary>
        /// 头宽度百分比
        /// </summary>
        public double HeadWidthPercent { get; set; }
        /// <summary>
        /// 刻度Label高度百分比
        /// </summary>
        public double TicLabelHeightPercent { get; set; }
        /// <summary>
        /// 刻度区域高度百分比
        /// </summary>
        public double TicAreaHeightPercent { get; set; }
        /// <summary>
        /// 刻度高度百分比（占刻度区域高度的百分比）
        /// </summary>
        public double TicHeightPercent { get; set; }
        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// 头文本颜色（左边）
        /// </summary>
        public Color HeadTextColor { get; set; }

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
        #endregion
        /// <summary>
        /// 绘制时间进度
        /// </summary>
        public Action<DateTime> DrawTimeProcessAction { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DateAxisControl()
        {
            InitializeComponent();

            _XAxisItems = new List<UIElement>();
            _TimeProcessUI = new List<UIElement>();
            HeadWidthPercent = _DefaultSetting.HeadWidthPercent;
            TicLabelHeightPercent = _DefaultSetting.TicLabelHeightPercent;
            TicAreaHeightPercent = _DefaultSetting.TicAreaHeightPercent;
            TicHeightPercent = _DefaultSetting.TicHeightPercent;
            _MinorTicLongPercent = _DefaultSetting.MinorTicLongPercent;
            this.Loaded += DateAxisControl_Loaded;
        }

        void DateAxisControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetProcessTimer();
            SetTimeProcessTimer();
            Draw(true);
            _isLoaded = true;
        }

        public static void XAxisSettingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DateAxisControl).InitAxisSetting(e.NewValue as AxisSetting);
            if ((d as DateAxisControl)._isLoaded)
                (d as DateAxisControl).Draw();
        }
        public static void OnProcessBeginTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DateAxisControl).DrawProcessTimeLong();
        }
        public static void OnProcessEndTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DateAxisControl).DrawProcessTimeLong();
        }
        private static void OnRescueTimeListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((d as DateAxisControl)._isLoaded)
                (d as DateAxisControl).Draw(true);
        }

        public void InitAxisSetting(AxisSetting xAxisSetting)
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

        /// <summary>
        /// 绘制
        /// </summary>
        private void Draw(bool isSyncProcess = false)
        {
            if (_XAxis == null)
                return;
            _XAxis.MinPix = AxisStartPoint.X;
            _XAxis.MaxPix = _drawWidth;
            if (_XAxisItems != null && _XAxisItems.Count > 0)
            {
                _XAxisItems.ForEach(u => _Container.Children.Remove(u));
                _XAxisItems.Clear();
            }

            DrawTimeProcess(isSyncProcess);

            DrawTics();

            //画时长
            DrawProcessTimeLong();
        }

        /// <summary>
        /// 画时间刻度
        /// </summary>
        private void DrawTics()
        {
            double fontSize = 10.5;
            string fontFamily = "微软雅黑";
            double textHeight, textWidth;
            double ticLabelAreaHeight = _drawHeight * TicLabelHeightPercent;

            double MajorTicStartY = StartPoint.Y + _drawHeight * TicLabelHeightPercent + _drawHeight * TicAreaHeightPercent * (1 - TicHeightPercent) / 2;
            double MajorTicEndY = MajorTicStartY + _drawHeight * TicAreaHeightPercent * TicHeightPercent;
            double MinorTicStartY = MajorTicStartY + (1 - _MinorTicLongPercent) * _drawHeight * TicAreaHeightPercent * TicHeightPercent / 2;
            double MinorTicEndY = MajorTicEndY - (1 - _MinorTicLongPercent) * _drawHeight * TicAreaHeightPercent * TicHeightPercent / 2;

            _XAxis.Draw(null, (p, ticTime, isMajorTic) =>
            {
                //画刻度线
                #region old
                //Point StartP = new Point(p, isMajorTic ? MajorTicStartY : MinorTicStartY);
                //Point EndP = new Point(p, isMajorTic ? MajorTicEndY : MinorTicEndY);
                //Path xAxisLine = PathHelper.DrawLine(StartP, EndP, _TicColor, _TicThickness);
                //_Container.Children.Add(xAxisLine);
                //_XAxisItems.Add(xAxisLine);
                #endregion
                Point StartP = new Point(p, isMajorTic ? MajorTicStartY : MinorTicStartY);
                Point EndP = new Point(p, isMajorTic ? MajorTicEndY : MinorTicEndY);
                Path xAxisLine = PathHelper.DrawLine(StartP, EndP, _TicColor, _TicThickness);
                _Container.Children.Add(xAxisLine);
                _XAxisItems.Add(xAxisLine);

                //画刻度Label
                if (isMajorTic || (!isMajorTic && _XAxis.IsShowMinorTicLabel))
                {
                    string labelText = ticTime.ToString(TicLabelFormat);
                    textHeight = PathHelper.MeasureTextHeight(labelText, fontSize, fontFamily);
                    textWidth = PathHelper.MeasureTextWidth(labelText, fontSize, fontFamily);
                    TextBlock tb = new TextBlock();
                    tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    tb.Foreground = new SolidColorBrush(Color.FromRgb(0x7E, 0x7e, 0x80));//new SolidColorBrush(Color.FromRgb(0x57, 0x5B, 0x5C));
                    tb.FontSize = fontSize;
                    tb.FontFamily = new FontFamily(fontFamily);
                    tb.Height = textHeight;
                    //tb.Width = textWidth;
                    tb.Text = labelText;
                    //tb.FontWeight = FontWeights.Bold;
                    tb.Margin = new Thickness(p - textWidth / 2, (ticLabelAreaHeight - 4 - textHeight) / 2, 0, 0);
                    _Container.Children.Add(tb);
                    _XAxisItems.Add(tb);
                }
            });
        }

        /// <summary>
        /// 绘制过程时长
        /// </summary>
        private void DrawProcessTimeLong()
        {
            if (_ProcessLongUI != null)
            {
                _Container.Children.Remove(_ProcessLongUI);
                _ProcessLongUI = null;
            }

            //画时长FA9278
            TimeSpan ts = new TimeSpan();
            if (ProcessBeginTime.HasValue)
            {
                ts = (ProcessEndTime.HasValue ? ProcessEndTime.Value : DateTime.Now) - ProcessBeginTime.Value;
            }
            string processLongText = string.Format("{0}:{1}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"));
            //string processLongText = ts.ToString("g");
            double fontSize = 20;
            string fontFamily = "微软雅黑";
            double textHeight = PathHelper.MeasureTextHeight(processLongText, fontSize, fontFamily, FontWeights.Bold);
            double textWidth = PathHelper.MeasureTextWidth(processLongText, fontSize, fontFamily, FontWeights.Bold);

            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            tb.Foreground = new SolidColorBrush(Color.FromRgb(0x7E, 0x7E, 0x80));//new SolidColorBrush(Color.FromRgb(0xFA, 0x92, 0x78));
            tb.FontSize = fontSize;
            tb.FontFamily = new FontFamily(fontFamily);
            //tb.Height = textHeight;
            //tb.Width = textWidth;
            tb.FontWeight = FontWeights.Bold;
            tb.Text = processLongText;
            tb.Margin = new Thickness((_drawWidth * HeadWidthPercent - textWidth) / 2, (_drawHeight - textHeight) / 2, 0, 0);
            _Container.Children.Add(tb);
            _ProcessLongUI = tb;
        }
        /// <summary>
        /// 设置过程定时器
        /// </summary>
        private void SetProcessTimer()
        {
            ProcessTimer.Tick += new EventHandler(ProcessTimerCycle);
            ProcessTimer.Interval = new TimeSpan(0, 0, 1, 0);
            ProcessTimer.Start();
        }

        private void ProcessTimerCycle(object sender, EventArgs e)
        {
            DrawProcessTimeLong();
        }

        /// <summary>
        /// 设置当前时间定时器
        /// </summary>
        private void SetTimeProcessTimer()
        {
            TimeProcessTimer.Tick += new EventHandler(TimeProcessTimerCycle);
            TimeProcessTimer.Interval = new TimeSpan(0, 0, 1, 0);
            TimeProcessTimer.Start();
        }

        private void TimeProcessTimerCycle(object sender, EventArgs e)
        {
            Draw(true);
            //DrawTimeProcess();
        }
        /// <summary>
        /// 绘制当前时间进度
        /// </summary>
        private void DrawTimeProcess(bool isSyncProcess = false)
        {
            if (_XAxis == null)
                return;
            if (_TimeProcessUI != null && _TimeProcessUI.Count > 0)
            {
                _TimeProcessUI.ForEach(u => _Container.Children.Remove(u));
                _TimeProcessUI.Clear();
            }
            processButtonGrid.Children.Clear();

            bool isOverMin, isOverMax;
            DateTime time = DateTime.Now;//DateTime.Now.Date.AddHours(9);// 
            double x = _XAxis.LocalTransform(time, out isOverMin, out isOverMax);

            GradientStopCollection GradientStops = new GradientStopCollection();
            LinearGradientBrush bgBrush;
            Border processBorder;
            double TicStartY = StartPoint.Y + _drawHeight * TicLabelHeightPercent;
            double TicEndY = TicStartY + _drawHeight * TicAreaHeightPercent;
            double leftMargin = -6;
            double rightMargin = 6;
            if (!isOverMin)
            {
                //LinearGradientBrush bgBrush = new LinearGradientBrush(Color.FromRgb(0x65, 0xD3, 0xAC), Color.FromRgb(0x29, 0xB9, 0xB6), new Point(0, 0), new Point(0, 1));

                GradientStops.Add(new GradientStop(Color.FromRgb(0x65, 0xD3, 0xAC), 0.0));
                GradientStops.Add(new GradientStop(Color.FromRgb(0x59, 0xE6, 0xCB), 0.3));
                GradientStops.Add(new GradientStop(Color.FromRgb(0x45, 0xD9, 0xC7), 0.7));
                GradientStops.Add(new GradientStop(Color.FromRgb(0x29, 0xB9, 0xB6), 1.0));
                bgBrush = new LinearGradientBrush(GradientStops, new Point(0, 0), new Point(0, 1));

                processBorder = new Border();
                processBorder.Width = x - AxisStartPoint.X - leftMargin + rightMargin;
                processBorder.Height = _drawHeight * TicAreaHeightPercent;
                processBorder.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                processBorder.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                processBorder.CornerRadius = new CornerRadius(5);
                processBorder.Background = bgBrush;
                processBorder.Margin = new Thickness(AxisStartPoint.X + leftMargin, TicStartY, 0, 0);
                //processBorder.Opacity = 0.5;
                _Container.Children.Add(processBorder);
                _TimeProcessUI.Add(processBorder);
            }

            DrawRescueTimes(TicStartY);  //绘制抢救时间段

            if (time < _XAxis.MaxTime)
            {
                GradientStops = new GradientStopCollection();
                GradientStops.Add(new GradientStop(Color.FromRgb(0x31, 0xAA, 0xCE), 0.0));
                GradientStops.Add(new GradientStop(Color.FromRgb(0x38, 0xBD, 0xE3), 0.3));
                GradientStops.Add(new GradientStop(Color.FromRgb(0x38, 0xBC, 0xE2), 0.7));
                GradientStops.Add(new GradientStop(Color.FromRgb(0x37, 0xAD, 0xD1), 1.0));
                bgBrush = new LinearGradientBrush(GradientStops, new Point(0, 0), new Point(0, 1));
                processBorder = new Border();
                processBorder.Width = _XAxis.MaxPix - x;
                processBorder.Height = _drawHeight * TicAreaHeightPercent;
                processBorder.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                processBorder.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                processBorder.CornerRadius = new CornerRadius(5);
                processBorder.Background = bgBrush;
                processBorder.Margin = new Thickness(x, TicStartY, 0, 0);
                _Container.Children.Add(processBorder);
                _TimeProcessUI.Add(processBorder);

                //拉杆   
                if (!isOverMin && !isOverMax)
                {
                    double width = processBorder.Height * 0.8;
                    double ContainerWidth = width * 2.5;
                    processButtonPopup.Width = ContainerWidth * 1.2;
                    processButtonPopup.Height = ContainerWidth * 1.2;
                    processButtonPopup.Margin = new Thickness(x, 0, 0, 0);
                    Point startP = new Point(ContainerWidth / 2, ContainerWidth / 2);

                    Path Circle3 = GetProcessButton(startP, new Size(width * 2.5, width * 2.5), Color.FromRgb(0xE5, 0xF6, 0xF5), Color.FromRgb(0xE5, 0xF6, 0xF5));
                    Circle3.Opacity = 0.7;
                    processButtonGrid.Children.Add(Circle3);

                    Path Circle2 = GetProcessButton(startP, new Size(width * 1.8, width * 1.8), Color.FromRgb(0xFF, 0xFF, 0xFF), Color.FromRgb(0xFF, 0xFF, 0xFF));
                    processButtonGrid.Children.Add(Circle2);

                    Path Circle1 = GetProcessButton(startP, new Size(width, width), Color.FromRgb(0x00, 0xD8, 0xAE), Color.FromRgb(0x00, 0xD8, 0xAE));
                    processButtonGrid.Children.Add(Circle1);

                    double y = TicStartY + processBorder.Height / 2 - ContainerWidth / 2;
                    processButtonPopup.PlacementRectangle = new Rect(x - ContainerWidth / 2, y, ContainerWidth, ContainerWidth);
                    processButtonPopup.IsOpen = true;
                }
            }

            if (isSyncProcess && DrawTimeProcessAction != null)
                DrawTimeProcessAction(time);
        }

        /// <summary>
        /// 绘制抢救时间段
        /// </summary>
        private void DrawRescueTimes(double TicStartY)
        {
            if (RescueTimeList == null || RescueTimeList.Count == 0)
                return;

            GradientStopCollection GradientStops = new GradientStopCollection();
            GradientStops.Add(new GradientStop(Color.FromRgb(0xFF, 0x79, 0x0A), 0.0));
            GradientStops.Add(new GradientStop(Color.FromRgb(0xFF, 0x87, 0x24), 0.3));
            GradientStops.Add(new GradientStop(Color.FromRgb(0xFF, 0x99, 0x44), 0.7));
            GradientStops.Add(new GradientStop(Color.FromRgb(0xFF, 0xA5, 0x5A), 1.0));

            LinearGradientBrush bgBrush = new LinearGradientBrush(GradientStops, new Point(0, 0), new Point(0, 1));
            Border processBorder;
            Image image;
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("../Images/rescue.png", UriKind.Relative);
            bi3.EndInit();
           
            DateTime rescueEndTime = DateTime.Now;
            double x1, x2;
            bool isOverMin, isOverMax;

            for (int i = 0; i < RescueTimeList.Count; i++)
            {
                RescueTime rescueTime = RescueTimeList[i];
                if (rescueTime.CameraTime.HasValue)
                {
                    rescueEndTime = rescueTime.CameraTime.Value.AddMinutes(2); 
                }
                else
                {
                    if (!rescueTime.BeginTime.HasValue)
                        continue;
                    if (rescueTime.BeginTime.Value >= _XAxis.MaxTime)
                        continue;
                    if (rescueTime.EndTime.HasValue)
                        rescueEndTime = rescueTime.EndTime.Value;
                    else
                        rescueEndTime = DateTime.Now;
                    if (!rescueTime.BeginTime.HasValue)
                        continue;
                    if (rescueTime.BeginTime.Value >= _XAxis.MaxTime)
                        continue;
                    if (rescueTime.EndTime.HasValue)
                        rescueEndTime = rescueTime.EndTime.Value;
                    else
                        rescueEndTime = DateTime.Now;
                }
              
                if (rescueEndTime > _XAxis.MaxTime)
                    rescueEndTime = _XAxis.MaxTime;

                x1 = _XAxis.LocalTransform(rescueTime.CameraTime.HasValue ? rescueTime.CameraTime.Value:rescueTime.BeginTime.Value, out isOverMin, out isOverMax);
                x2 = _XAxis.LocalTransform(rescueEndTime, out isOverMin, out isOverMax);
                if (rescueTime.CameraTime.HasValue)
                {
                    image = new Image();
                    image.Width = x2 - x1;
                    image.Source = bi3;
                    image.Height = _drawHeight * TicAreaHeightPercent;
                    image.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    image.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    image.Margin = new Thickness(x1, TicStartY, 0, 0);
                    image.Tag = rescueTime;
                    image.MouseLeftButtonDown += Image_MouseLeftButtonDown;
                    _Container.Children.Add(image);
                    _TimeProcessUI.Add(image);
                }
                else
                {
                    processBorder = new Border();
                    processBorder.Width = x2 - x1;
                    processBorder.Height = _drawHeight * TicAreaHeightPercent;
                    processBorder.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    processBorder.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    processBorder.CornerRadius = new CornerRadius(5);
                    processBorder.Background = bgBrush;
                    processBorder.Margin = new Thickness(x1, TicStartY, 0, 0);
                    processBorder.Tag = rescueTime;
                    processBorder.MouseLeftButtonDown += processBorder_MouseLeftButtonDown;
                    _Container.Children.Add(processBorder);
                    _TimeProcessUI.Add(processBorder);
                }
                   
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RescueEventArgs args = new RescueEventArgs(RescueClickRoutedEvent, sender);
            args.RescueTimePeroid = (sender as Image).Tag as RescueTime;
            this.RaiseEvent(args);
        }

        void processBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RescueEventArgs args = new RescueEventArgs(RescueClickRoutedEvent, sender);
            args.RescueTimePeroid = (sender as Border).Tag as RescueTime;
            this.RaiseEvent(args);
        }

        private Path GetProcessButton(Point startPoint, Size size, Color StrokeColor, Color FillColor)
        {
            Path path = new Path();
            path.VerticalAlignment = VerticalAlignment.Top;
            path.HorizontalAlignment = HorizontalAlignment.Left;
            path.Stroke = new SolidColorBrush(StrokeColor);
            GeometryGroup group = new GeometryGroup();
            path.Data = group;
            double halfWidth = size.Width / 2;
            path.Fill = new SolidColorBrush(FillColor);
            EllipseGeometry ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
            group.Children.Add(ellipse);
            return path;
        }

        /// <summary>
        /// 移动X轴
        /// </summary>
        /// <param name="xMove"></param>
        public void MoveXAxis(double xMove)
        {
            _XAxis.MoveAxis(xMove, () =>
            {
                _XAxisItems.ForEach(c => { _Container.Children.Remove(c); });
                _XAxisItems.Clear();
            }, () => { Draw(); });
        }
    }
}
