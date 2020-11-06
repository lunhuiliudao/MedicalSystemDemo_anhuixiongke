using Medicalsystem.Common.Doricon.Public;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System;
using System.Collections.Generic;
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
    /// IntakeAndOutputControl.xaml 的交互逻辑
    /// </summary>
    public partial class IntakeAndOutputControl : UserControl
    {
        #region 字段

        private double _firstX;
        private double _lastX;
        private double _lastY;        

        private int _gridTableClickNum = 0;
        /// <summary>
        /// 拖动时间轴的toolTip
        /// </summary>
        private ToolTip _dragXAxisTip;
        /// <summary>
        /// x轴
        /// </summary>
        private DateAxis _XAxis;

        private List<UIElement> _XAxisItems;

        private DateTime _processTime;

        /// <summary>
        /// 行
        /// </summary>
        private List<DataRowDefine> _Rows;
        /// <summary>
        /// tooltip
        /// </summary>
        private ToolTip _ToolTip;

        /// <summary>
        /// 当前绘画
        /// </summary>
        private DrawingContext _drawingContext;

        private double _dataShapLocationPercent = 0.7D;

        public bool _IsExchangeOddEvenRowStyle;

        private Rectangle _crossColumnUIElement;

        private TextBlock _crossColumnTxtUIElement;

        /// <summary>
        /// 行高
        /// </summary>
        private double _rowHeight;

        private double _drawHeight
        {
            get
            {
                return this.Height;
            }
        }
        private double tableWidth
        {
            get
            {
                return this._tableContainer.ActualWidth;
            }
        }
        private double _crossHeadColumnWidth;
        private List<IntakeAndOutputData> _Data;
        private bool _isLoaded;
        private Point _MouseOldLocation;
        /// <summary>
        /// 时间进度矩形
        /// </summary>
        private Rectangle _TimeRectangle;

        private DataPoint _selectDataPoint;
        private DateTime _selectStartTime;

        private string _DataTimeShowFormat;
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
            public static Color GridLineColor = Color.FromRgb(0xED, 0xED, 0xED);//Color.FromRgb(0xBB, 0xE7, 0xDD);
            public static Color HeadOddRowBrushColor = Color.FromRgb(0xE5, 0xFD, 0xFB);
            public static Color HeadEvenRowBrushColor = Color.FromRgb(0xA7, 0xE3, 0xE6);//Color.FromRgb(0x74, 0xC6, 0xD4);
            public static Color BodyOddRowBrushColor = Colors.White;
            public static Color BodyEvenRowBrushColor = Color.FromRgb(0xE6, 0xFA, 0xF9);//Color.FromRgb(0xC6, 0xEA, 0xEA);
            public static Color DataLineColor = Color.FromRgb(0x22, 0xB8, 0xF0);//24BEC8//Color.FromRgb(0x23, 0xC0, 0xC9);            
        }

        #endregion

        #region 私有属性

        /// <summary>
        /// 表格容器
        /// </summary>
        private Grid _tableContainer
        {
            get
            {
                return this.gridTable;
            }
        }

        /// <summary>
        /// x轴容器
        /// </summary>
        private Grid _xAxisContainer
        {
            get
            {
                return this.gridXAxis;
            }
        }

        /// <summary>
        /// 表格起点
        /// </summary>
        private Point StartPoint
        {
            get
            {
                return new Point(0, 0);
            }
        }

        #endregion

        #region 公共属性
                
        /// <summary>
        /// 表头宽度百分比
        /// </summary>
        public double TableHeadWidthPercent { get; set; }
        public int RowCount { get; set; }        
        /// <summary>
        /// 网格线颜色
        /// </summary>
        public Color GridLineColor { get; set; }
        /// <summary>
        /// 数据线颜色
        /// </summary>
        public Color DataLineColor { get; set; }
        /// <summary>
        /// 表头奇数行填充颜色
        /// </summary>
        public Color TableHeadOddRowBrushColor { get; set; }
        /// <summary>
        /// 表头偶数行填充颜色
        /// </summary>
        public Color TableHeadEvenRowBrushColor { get; set; }
        /// <summary>
        /// 表体奇数行填充颜色
        /// </summary>
        public Color TableBodyOddRowBrushColor { get; set; }
        /// <summary>
        /// 表头偶数行填充颜色
        /// </summary>
        public Color TableBodyEvenRowBrushColor { get; set; }

        /// <summary>
        /// 是否是交叉表头
        /// </summary>
        public bool IsCrossHead
        {
            get
            {
                return CrossHeadColumnDef != null;
            }
        }
        /// <summary>
        /// 交叉表头列
        /// </summary>
        public CrossHeadColumn CrossHeadColumnDef { get; set; }
        /// <summary>
        /// 是否交换交错行样式
        /// </summary>
        public bool IsExchangeOddEvenRowStyle
        {
            get { return _IsExchangeOddEvenRowStyle; }
            set
            {
                _IsExchangeOddEvenRowStyle = value;
                if (value)
                {
                    Color tmpColor = TableHeadOddRowBrushColor;
                    TableHeadOddRowBrushColor = TableHeadEvenRowBrushColor;
                    TableHeadEvenRowBrushColor = tmpColor;
                    tmpColor = TableBodyOddRowBrushColor;
                    TableBodyOddRowBrushColor = TableBodyEvenRowBrushColor;
                    TableBodyEvenRowBrushColor = tmpColor;
                }
            }
        }
        /// <summary>
        /// 数据
        /// </summary>
        public List<IntakeAndOutputData> Data
        {
            get { return _Data; }
            set
            {
                _Data = value;
                if (_isLoaded)
                    LoadData(value);
            }
        }

        /// <summary>
        /// 数据时间显示格式
        /// </summary>
        public string DataTimeShowFormat
        {
            get { return _DataTimeShowFormat; }
            set { _DataTimeShowFormat = value; }
        }

        #endregion

        #region 委托

        /// <summary>
        /// 双击委托
        /// </summary>
        public Action<object, MouseButtonEventArgs, List<IntakeAndOutputData>> DoubleClickAction { get; set; }

        /// <summary>
        /// 移动X轴委托
        /// </summary>
        public Action<object,double> MoveXAxisAction { get; set; }
        /// <summary>
        /// 修改用药委托
        /// </summary>
        public Action<object, IntakeAndOutputData, DateTime?> DataPointDragAction { get; set; }
        #endregion

        public IntakeAndOutputControl()
        {
            InitializeComponent();
            _DataTimeShowFormat = "yyyy-MM-dd HH:mm:ss";
            _MouseOldLocation = new Point();
            _Rows = new List<DataRowDefine>();
            _XAxisItems = new List<UIElement>();
            TableHeadWidthPercent = _DefaultSetting.TableHeadWidthPercent;
                        
            RowCount = _DefaultSetting.RowCount;
            //MedicineRowCount = _DefaultSetting.DefaultMedicineRowCount;
            //OutputRowCount = _DefaultSetting.DefaultOutputRowCount;
            //InfusionRowCount = _DefaultSetting.DefaultInfusionRowCount;
            GridLineColor = _DefaultSetting.GridLineColor;
            TableHeadOddRowBrushColor = _DefaultSetting.HeadOddRowBrushColor;
            TableHeadEvenRowBrushColor = _DefaultSetting.HeadEvenRowBrushColor;
            TableBodyOddRowBrushColor = _DefaultSetting.BodyOddRowBrushColor;
            TableBodyEvenRowBrushColor = _DefaultSetting.BodyEvenRowBrushColor;
            DataLineColor = _DefaultSetting.DataLineColor;

            _ToolTip = new ToolTip();
            _ToolTip.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            _ToolTip.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            _ToolTip.IsOpen = false;

            _dragXAxisTip = new ToolTip();
            _dragXAxisTip.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            _dragXAxisTip.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            _dragXAxisTip.IsOpen = false;
            _processTime = DateTime.Now;

            this.Loaded += IntakeAndOutputControl_Loaded;
        }

        void IntakeAndOutputControl_Loaded(object sender, RoutedEventArgs e)
        {
            DrawTable();
            _tableContainer.MouseLeftButtonDown += _tableContainer_MouseLeftButtonDown;
            _isLoaded = true;
        }

        void _tableContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _gridTableClickNum += 1;
            //Logger.WriteLog("鼠标点击次数：" + _gridTableClickNum.ToString() + " 时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"));

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; _gridTableClickNum = 0; };
            timer.IsEnabled = true;

            if (_gridTableClickNum % 2 == 0)
            {
                timer.IsEnabled = false;
                _gridTableClickNum = 0;

                DataRowDefine row = GetRow(e.GetPosition(_tableContainer));
                //手抖双击时，row是null触发报错，屏蔽这个无效的操作
                if (row == null) return;
                List<IntakeAndOutputData> list = row.RowData;   //传给弹出框

                //双击
                if (DoubleClickAction != null)
                {
                    DoubleClickAction(this, e, list);
                }
            }
        }

        #region 方法

        public void Init(AxisSetting xAxisSetting)
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
            if (_isLoaded)
            {
                double tableHeight = this.Height;
                Point bodyStartPoint = new Point(StartPoint.X + tableWidth * TableHeadWidthPercent, StartPoint.Y);
                DrawXAxis(bodyStartPoint, tableWidth); //DrawTable();
            }                
        }

        public void DrawTable()
        {
            _tableContainer.Children.Clear();

            //Draw table            
            //double tableHeight = this._tableContainer.ActualHeight;
            double tableHeight = this.Height;
            Point bodyStartPoint = new Point(StartPoint.X + tableWidth * TableHeadWidthPercent, StartPoint.Y);
            
            //_crossHeadColumnWidth = tableWidth * TableHeadWidthPercent * CrossHeadColumnWidthPercent;
            if (IsCrossHead)
                _crossHeadColumnWidth = PathHelper.MeasureTextWidth(CrossHeadColumnDef.Text, CrossHeadColumnDef.FontSize, CrossHeadColumnDef.FontFamily) + 4;

            #region Draw table grid

            //DrawTimeProcess(_processTime);

            _rowHeight = tableHeight / RowCount;
            
            //brush rows
            Brush headOddRowBrush = new SolidColorBrush(TableHeadOddRowBrushColor);
            Brush headEvenRowBrush = new SolidColorBrush(TableHeadEvenRowBrushColor);
            Brush bodyOddRowBrush = new SolidColorBrush(TableBodyOddRowBrushColor);
            Brush bodyEvenRowBrush = new SolidColorBrush(TableBodyEvenRowBrushColor);

            
            for (int i = 0; i < RowCount; i++)
            {
                Rectangle rectHead = null;
                Rectangle rectBody = null;
                Brush headRowBrush, bodyRowBrush;
                if ((i + 1) % 2 > 0)    //Odd row
                {
                    headRowBrush = headOddRowBrush;
                    bodyRowBrush = bodyOddRowBrush;
                }
                else //Even row
                {
                    headRowBrush = headEvenRowBrush;
                    bodyRowBrush = bodyEvenRowBrush;                    
                }

                if (IsCrossHead)
                {
                    //head
                    rectHead = PathHelper.DrawRectangle(bodyStartPoint.X - _crossHeadColumnWidth, _rowHeight, new Thickness(StartPoint.X + _crossHeadColumnWidth, StartPoint.Y + _rowHeight * i, 0, 0), headRowBrush);
                }
                else
                {
                    //head
                    rectHead = PathHelper.DrawRectangle(bodyStartPoint.X, _rowHeight, new Thickness(StartPoint.X, StartPoint.Y + _rowHeight * i, 0, 0), headRowBrush);
                }
                //body
                rectBody = PathHelper.DrawRectangle(this.ActualWidth - bodyStartPoint.X, _rowHeight, new Thickness(bodyStartPoint.X, bodyStartPoint.Y + _rowHeight * i, 0, 0), bodyRowBrush);
                _Rows.Add(new DataRowDefine(rectHead, rectBody));
                _tableContainer.Children.Add(rectHead);
                _tableContainer.Children.Add(rectBody);
            }           

            //draw horizontal grid             
            //for (int i = 0; i <= RowCount; i++)
            //{
            //    Point StartP = new Point(StartPoint.X, StartPoint.Y + _rowHeight * i);
            //    Point EndP = new Point(StartPoint.X + tableWidth, StartPoint.Y + _rowHeight * i);
            //    _tableContainer.Children.Add(DrawLine(StartP, EndP));
            //}

            if (IsCrossHead)
            {
                //画交叉列 62ABBA
                _crossColumnUIElement = PathHelper.DrawRectangle(_crossHeadColumnWidth, tableHeight, new Thickness(StartPoint.X, StartPoint.Y, 0, 0), new SolidColorBrush(CrossHeadColumnDef.BackgroundColor));
                _tableContainer.Children.Add(_crossColumnUIElement);

                double textHeight = PathHelper.MeasureTextHeight(CrossHeadColumnDef.Text, CrossHeadColumnDef.FontSize, CrossHeadColumnDef.FontFamily);
                double titleWidth = PathHelper.MeasureTextWidth(CrossHeadColumnDef.Text, CrossHeadColumnDef.FontSize, CrossHeadColumnDef.FontFamily);
                double y = (tableHeight - textHeight) / 2;
                double x = (_crossHeadColumnWidth - titleWidth) / 2;

                _crossColumnTxtUIElement = new TextBlock();
                _crossColumnTxtUIElement.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                _crossColumnTxtUIElement.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                _crossColumnTxtUIElement.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
                _crossColumnTxtUIElement.FontSize = CrossHeadColumnDef.FontSize;
                _crossColumnTxtUIElement.FontFamily = new FontFamily(CrossHeadColumnDef.FontFamily);
                _crossColumnTxtUIElement.Height = textHeight;
                _crossColumnTxtUIElement.Width = titleWidth;
                _crossColumnTxtUIElement.Text = CrossHeadColumnDef.Text;
                _crossColumnTxtUIElement.Margin = new Thickness(x, y, 0, 0);
                _tableContainer.Children.Add(_crossColumnTxtUIElement);
            }

            //Draw first vertical grid
            _tableContainer.Children.Add(DrawLine(StartPoint, new Point(StartPoint.X, _drawHeight)));

            //表头和表体连接地方的竖线
            _tableContainer.Children.Add(DrawLine(bodyStartPoint, new Point(bodyStartPoint.X, bodyStartPoint.Y + tableHeight), _DefaultSetting.TableHeadThickness));

            //Draw vertical grid from body 

            //for (int i = 0; i <= Columns; i++)
            //{
            //    Point StartP = new Point(bodyStartPoint.X + columnWidth * i, bodyStartPoint.Y);
            //    Point EndP = new Point(bodyStartPoint.X + columnWidth * i, this.ActualHeight);
            //    //_drawingContext.DrawLine(new Pen(new SolidColorBrush(GridLineColor), 1), StartP, EndP);
            //    _tableContainer.Children.Add(DrawLine(StartP, EndP, _DefaultSetting.DefaultGridThickness, (i + 1) % 2 == 0));
            //}
            //tableWidth * TableHeadWidthPercent
            DrawXAxis(bodyStartPoint, tableWidth);  //画X轴

            //画右边框
            _tableContainer.Children.Add(DrawLine(new Point(tableWidth, bodyStartPoint.Y), new Point(tableWidth, tableHeight), _DefaultSetting.TableHeadThickness));
            #endregion

            DrawTimeProcess(_processTime);

            #region 画数据
            if (_Data != null && _Data.Count > 0)
            {
                var groupList = _Data.GroupBy(p => p.Name).ToList();
                foreach (var item in groupList)
                {
                    AddRowData(item.ToList());
                }
            }
            #endregion            
        }

        private double _lastVerticalOffset;
        public void SetVerticalOffset(double y)
        {
            if (_crossColumnTxtUIElement == null)
                return;
            _crossColumnTxtUIElement.Margin = new Thickness(_crossColumnTxtUIElement.Margin.Left, _crossColumnTxtUIElement.Margin.Top + (y - _lastVerticalOffset), _crossColumnTxtUIElement.Margin.Right, _crossColumnTxtUIElement.Margin.Bottom);
            _lastVerticalOffset = y;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="dataList"></param>
        private void LoadData(List<IntakeAndOutputData> dataList)
        {
            
            _Rows.ForEach(row =>
            {
                row.RowData.Clear();
                foreach (UIElement item in row.DataUIElements)
                {
                    _tableContainer.Children.Remove(item);
                }
                row.DataUIElements.Clear();
                row.TitleUIElements.ForEach(p => _tableContainer.Children.Remove(p));
                row.TitleUIElements.Clear();
            });
            var groupList = dataList.GroupBy(p => p.Name).ToList();
            foreach (var item in groupList)
            {
                AddRowData(item.ToList());
            }
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="dataList"></param>
        public void UpdateData(List<IntakeAndOutputData> dataList)
        {
            if (dataList == null || dataList.Count == 0)
                return;
            var groupList = dataList.GroupBy(p => p.Name).ToList();
            foreach (var item in groupList)
            {
                AddRowData(item.ToList());
            }
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="dataList"></param>
        public void AddData(List<IntakeAndOutputData> dataList)
        {
            if (dataList == null || dataList.Count == 0)
                return;
            var groupList = dataList.GroupBy(p => p.Name).ToList();
            foreach (var item in groupList)
            {
                AddRowData(item.ToList(), true);
            }
        }

        /// <summary>
        /// 画X轴
        /// </summary>
        /// <param name="bodyStartPoint"></param>
        /// <param name="tableWidth"></param>
        private void DrawXAxis(Point bodyStartPoint, double tableWidth)
        {
            if (_XAxis == null)
                return;
            _XAxis.MinPix = bodyStartPoint.X;
            _XAxis.MaxPix = tableWidth;
            _XAxisItems.ForEach(p => _tableContainer.Children.Remove(p));
            _XAxisItems.Clear();
            _XAxis.Draw((p, isMajorGrid) =>
            {
                Point StartP = new Point(p, bodyStartPoint.Y);
                Point EndP = new Point(p, _drawHeight);
                Path xAxisLine = DrawLine(StartP, EndP, _DefaultSetting.GridThickness, !isMajorGrid);
                _tableContainer.Children.Add(xAxisLine);
                _XAxisItems.Add(xAxisLine);
            }, null);
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
        /// 获取行定义
        /// </summary>
        /// <param name="rowRect"></param>
        /// <returns></returns>
        private DataRowDefine GetRow(Rectangle rowRect)
        {
            return _Rows.Find(p => p.HeadRectangle == rowRect || p.BodyRectangle == rowRect);
        }

        private DataRowDefine GetRow(Point p)
        {
            DataRowDefine row = _Rows.Find(r => r.HeadRectangle.IsMouseOver || r.BodyRectangle.IsMouseOver);
            if (row == null)
            {
                row = _Rows.Find(r => p.X >= r.BodyRectangle.Margin.Left && p.X <= (r.BodyRectangle.Margin.Left + r.BodyRectangle.Width)
                    && p.Y >= r.BodyRectangle.Margin.Top && p.Y <= (r.BodyRectangle.Margin.Top + r.BodyRectangle.Height));
            }
            return row;
        }

        private DataRowDefine GetRowDefine(IntakeAndOutputData data)
        {
            DataRowDefine row = _Rows.Find(p => p.RowTitle == data.Name);
            if (row == null)
                row = _Rows.Find(p => p.RowData.Count == 0);
            return row;
        }

        private void AddRowData(List<IntakeAndOutputData> dataList, bool IsAdd = false)
        {
            DataRowDefine row = GetRowDefine(dataList.FirstOrDefault());
            if (row == null)
            {
                //新加行
                double PreHeight = this.Height; //this.ActualHeight;
                this.Height = PreHeight + _rowHeight;

                Brush headOddRowBrush = new SolidColorBrush(TableHeadOddRowBrushColor);
                Brush headEvenRowBrush = new SolidColorBrush(TableHeadEvenRowBrushColor);
                Brush bodyOddRowBrush = new SolidColorBrush(TableBodyOddRowBrushColor);
                Brush bodyEvenRowBrush = new SolidColorBrush(TableBodyEvenRowBrushColor);
                Brush Stroke = new SolidColorBrush(TableHeadEvenRowBrushColor);
                Brush headRowBrush, bodyRowBrush;
                if ((RowCount + 1) % 2 > 0)    //Odd row
                {
                    headRowBrush = headOddRowBrush;
                    bodyRowBrush = bodyOddRowBrush;
                }
                else //Even row
                {
                    headRowBrush = headEvenRowBrush;
                    bodyRowBrush = bodyEvenRowBrush;
                }

                Point bodyStartPoint = new Point(StartPoint.X + tableWidth * TableHeadWidthPercent, PreHeight);

                //head
                Rectangle rectHead;
                if (IsCrossHead)
                {
                    //画交叉列 62ABBA
                    _crossColumnUIElement.Height += _rowHeight;
                    //Rectangle crossColumn = DrawRectangle(CrossHeadColumnWidth, _rowHeight, new Thickness(StartPoint.X, bodyStartPoint.Y, 0, 0), new SolidColorBrush(Color.FromRgb(0x62, 0xAB, 0xBA)));
                    //_tableContainer.Children.Add(crossColumn);

                    rectHead = PathHelper.DrawRectangle(bodyStartPoint.X - _crossHeadColumnWidth, _rowHeight, new Thickness(StartPoint.X + _crossHeadColumnWidth, bodyStartPoint.Y, 0, 0), headRowBrush);
                }
                else
                    rectHead = PathHelper.DrawRectangle(bodyStartPoint.X, _rowHeight, new Thickness(StartPoint.X, bodyStartPoint.Y, 0, 0), headRowBrush);
                //body
                Rectangle rectBody = PathHelper.DrawRectangle(this.ActualWidth - bodyStartPoint.X, _rowHeight, new Thickness(bodyStartPoint.X, bodyStartPoint.Y, 0, 0), bodyRowBrush);

                row = new DataRowDefine(rectHead, rectBody);
                _Rows.Add(row);                
                _tableContainer.Children.Add(rectHead);
                _tableContainer.Children.Add(rectBody);
                RowCount++;

                _XAxisItems.ForEach(c => { _tableContainer.Children.Remove(c); });
                _XAxisItems.Clear();
                DrawXAxis(new Point(StartPoint.X + tableWidth * TableHeadWidthPercent, StartPoint.Y), tableWidth);
            }
            if (IsAdd)
            {
                row.AddData(dataList);
            }
            else
            {
                row.UpdateData(dataList);
            }
            //清除行数据图形，重绘
            foreach (UIElement item in row.DataUIElements)
            {
                _tableContainer.Children.Remove(item);
            }
            row.DataUIElements.Clear();
            row.DataPoints.Clear();
            foreach (IntakeAndOutputData data in row.RowData)
            {
                DrawDataShape(row, data);
                DrawDataLabel(row, data);
                DrawDataTitle(row);
            }
        }
        /// <summary>
        /// 绘制标题
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private void DrawDataTitle(DataRowDefine row)
        {
            if (string.IsNullOrWhiteSpace(row.RowTitle) || row.TitleUIElements.Count > 0)
                return;
            double tableWidth = this._tableContainer.ActualWidth;
            double headWidth = row.HeadRectangle.Width; //tableWidth* TableHeadWidthPercent;

            double fontSize = 12;
            string fontFamily = "微软雅黑";
            double textHeight = PathHelper.MeasureTextHeight(row.RowTitle, fontSize, fontFamily);
            double titleWidth = PathHelper.MeasureTextWidth(row.RowTitle, fontSize, fontFamily);
            double y = row.HeadRectangle.Margin.Top + (row.HeadRectangle.Height - textHeight) / 2;
            double x1 = row.HeadRectangle.Margin.Left + 5;
            //double x1 = row.HeadRectangle.Margin.Left + ((headWidth - titleWidth) > 0 ? (headWidth - titleWidth) : 0) / 2;
            //double x2 = x1 + titleWidth;

            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            tb.Foreground = new SolidColorBrush(Color.FromRgb(0x57, 0x58, 0x6B));
            tb.FontSize = fontSize;
            tb.FontFamily = new FontFamily(fontFamily);
            tb.Height = textHeight;
            tb.Width = titleWidth;
            tb.Text = row.RowTitle;
            tb.Margin = new Thickness(x1, y, 0, 0);
            _tableContainer.Children.Add(tb);
            row.TitleUIElements.Add(tb);
        }
        /// <summary>
        /// 绘制数据图形
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        private void DrawDataShape(DataRowDefine row, IntakeAndOutputData data)
        {            
            double y = row.BodyRectangle.Margin.Top + row.BodyRectangle.Height * _dataShapLocationPercent;
            double pointXt = 5;
            double StrokeThickness = 3;
            Color StrokeColor = DataLineColor;
            if (data.IsOneTime)
            {
                bool IsOverMin, IsOverMax;
                double x = _XAxis.LocalTransform(data.OnetimeData.ExcuteTime.Value, out IsOverMin, out IsOverMax);
                if (IsOverMin || IsOverMax)
                    return;
                #region old

                //if (data.OnetimeData.IsShowIcon)
                //{
                //    double CircleRadius = row.BodyRectangle.Height * (1 - _dataShapLocationPercent) * 0.8;
                //    Path circle = Symbol.MakePath(SymbolType.Ext_FillCircle, new Point(x + CircleRadius, y), new Size(CircleRadius * 2, CircleRadius * 2), data.OnetimeData.IconBackground);
                //    _tableContainer.Children.Add(circle);
                //    row.DataUIElements.Add(circle);

                //    double fontSize = 12;
                //    string fontFamily = "微软雅黑";
                //    double textHeight = PathHelper.MeasureTextHeight(data.OnetimeData.IconText, fontSize, fontFamily);
                //    double textWidth = PathHelper.MeasureTextWidth(data.OnetimeData.IconText, fontSize, fontFamily);

                //    TextBlock tb = new TextBlock();
                //    tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                //    tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                //    tb.Foreground = new SolidColorBrush(Color.FromRgb(0x57, 0x58, 0x6B));
                //    tb.FontSize = fontSize;
                //    tb.FontFamily = new FontFamily(fontFamily);
                //    tb.Height = textHeight;
                //    tb.Width = textWidth;
                //    tb.Text = data.OnetimeData.IconText;
                //    tb.Margin = new Thickness(x - textWidth / 2, y - textHeight / 2, 0, 0);
                //    _tableContainer.Children.Add(tb);
                //    row.DataUIElements.Add(tb);
                //}
                //else
                //{
                //    Path point1 = Symbol.MakePath(SymbolType.Ext_CircleInCircle, new Point(x, y), new Size(pointXt * 2, pointXt * 2));
                //    _tableContainer.Children.Add(point1);
                //    row.DataUIElements.Add(point1);
                //    double lineLenth = 3;
                //    FrameworkElement line1 = DrawLine(new Point(x, y - pointXt - lineLenth), new Point(x, y - pointXt), DataLineColor, 4);
                //    _tableContainer.Children.Add(line1);
                //    row.DataUIElements.Add(line1);
                //    FrameworkElement line2 = DrawLine(new Point(x, y + pointXt), new Point(x, y + pointXt + lineLenth), DataLineColor, 4);
                //    _tableContainer.Children.Add(line2);
                //    row.DataUIElements.Add(line2);
                //    row.DataPoints.Add(new DataPoint(data.OnetimeData.ExcuteTime.Value, 0, x, y, new List<FrameworkElement>() { point1, line1, line2 }, data.Name, data.ToolTip));
                //}

                #endregion

                Path point1 = Symbol.MakePath(SymbolType.Ext_CircleInCircle, new Point(x, y), new Size(pointXt * 2, pointXt * 2), StrokeColor);
                point1.Tag = data;
                _tableContainer.Children.Add(point1);
                row.DataUIElements.Add(point1);
                double lineLenth = 3.5;
                FrameworkElement line1 = DrawLine(new Point(x, y - pointXt - lineLenth), new Point(x, y - pointXt), StrokeColor, StrokeThickness);
                _tableContainer.Children.Add(line1);
                row.DataUIElements.Add(line1);
                FrameworkElement line2 = DrawLine(new Point(x, y + pointXt), new Point(x, y + pointXt + lineLenth), StrokeColor, StrokeThickness);
                _tableContainer.Children.Add(line2);
                row.DataUIElements.Add(line2);
                row.DataPoints.Add(new DataPoint(data.OnetimeData.ExcuteTime.Value, 0, x, y, new List<FrameworkElement>() { point1, line1, line2 }, data.Name, data.ToolTip));
            }
            else
            {
                bool x1IsOverMin, x1IsOverMax, x2IsOverMin, x2IsOverMax;
                double x1 = _XAxis.LocalTransform(data.BeginTime.Value, out x1IsOverMin, out x1IsOverMax);
                double x2 = _XAxis.LocalTransform(data.EndTime.HasValue ? data.EndTime.Value : DateTime.Now, out x2IsOverMin, out x2IsOverMax);
                //if (x1 == x2 && data.BeginTime.Value != data.EndTime.Value)
                if (x1IsOverMax || x2IsOverMin)
                    return;

                Shape shape = DrawLine(new Point(x1 + (x1IsOverMin ? 0 : pointXt), y), new Point(x2 - (x2IsOverMax || !data.EndTime.HasValue ? 0 : pointXt), y), StrokeColor, StrokeThickness);
                _tableContainer.Children.Add(shape);
                row.DataUIElements.Add(shape);

                List<FrameworkElement> Elements = new List<FrameworkElement>() { shape };
                
                if (!x1IsOverMin)
                {
                    Path point1 = Symbol.MakePath(SymbolType.Ext_CircleInCircle, new Point(x1, y), new Size(pointXt * 2, pointXt * 2), StrokeColor, StrokeColor);
                    _tableContainer.Children.Add(point1);
                    row.DataUIElements.Add(point1);
                    Elements.Add(point1);
                }
                else
                {
                    Path vLine = PathHelper.DrawLine(new Point(x1, y - 5), new Point(x1, y + 5), StrokeColor, 2);
                    _tableContainer.Children.Add(vLine);
                    row.DataUIElements.Add(vLine);
                    Elements.Add(vLine);
                }
                if (!x2IsOverMax && data.EndTime.HasValue)
                {
                    Path point2 = Symbol.MakePath(SymbolType.Ext_CircleInCircle, new Point(x2, y), new Size(pointXt * 2, pointXt * 2), StrokeColor, StrokeColor);
                    _tableContainer.Children.Add(point2);
                    row.DataUIElements.Add(point2);
                    Elements.Add(point2);
                }
                else
                {
                    Path vLine = PathHelper.DrawLine(new Point(x2, y - 5), new Point(x2, y + 5), StrokeColor, 2);
                    _tableContainer.Children.Add(vLine);
                    row.DataUIElements.Add(vLine);
                    Elements.Add(vLine);
                }
                DataPoint dp = new DataPoint(data.BeginTime.Value, data.EndTime, Elements, data.Name, data.ToolTip);
                row.DataPoints.Add(dp);
            }
        }
        /// <summary>
        /// 绘制数据标签
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        private void DrawDataLabel(DataRowDefine row, IntakeAndOutputData data)
        {
            double x;
            double fontSize = 10.5;
            string fontFamily = "微软雅黑";
            double textHeight = PathHelper.MeasureTextHeight(data.Label, fontSize, fontFamily);
            double textWidth = PathHelper.MeasureTextWidth(data.Label, fontSize, fontFamily);
            //double textMaginTop = 0;
            //double textMarginLeft = 10;
            //double labelHeight = textHeight + textMaginTop * 2;
            //double labelWidth = textWidth + textMarginLeft * 2;
            double labelHeight = textHeight;
            double labelWidth = textWidth;

            double y = row.BodyRectangle.Margin.Top + (row.BodyRectangle.Height * _dataShapLocationPercent - labelHeight) / 2;
            if (data.IsOneTime)
            {
                bool IsOverMin, IsOverMax;
                x = _XAxis.LocalTransform(data.OnetimeData.ExcuteTime.Value, out IsOverMin, out IsOverMax);
                if (IsOverMin || IsOverMax)
                    return;
                x = x - labelWidth / 2;
                y -= 3;
            }
            else
            {
                bool x1IsOverMin, x1IsOverMax, x2IsOverMin, x2IsOverMax;
                double x1 = _XAxis.LocalTransform(data.BeginTime.Value, out x1IsOverMin, out x1IsOverMax);
                double x2 = _XAxis.LocalTransform(data.EndTime.HasValue ? data.EndTime.Value : DateTime.Now, out x2IsOverMin, out x2IsOverMax);
                if (x1IsOverMax || x2IsOverMin)
                    return;

                x = x1 + (x2 - x1 - labelWidth) / 2;
            }
            
            if (x < row.BodyRectangle.Margin.Left)
                x = row.BodyRectangle.Margin.Left;
            else if (x + labelWidth > row.BodyRectangle.Margin.Left + row.BodyRectangle.Width)
                x = row.BodyRectangle.Margin.Left + row.BodyRectangle.Width - labelWidth;

            #region old
            //Border bor = new Border();
            //bor.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            //bor.CornerRadius = new CornerRadius(10);
            //bor.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            //bor.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            //bor.Margin = new Thickness(x, y, 0, 0);
            //bor.Height = labelHeight;
            //bor.Width = labelWidth;

            //TextBlock tb = new TextBlock();
            //tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            //tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            //tb.Foreground = new SolidColorBrush(Color.FromRgb(0x57, 0x58, 0x6B));
            //tb.FontSize = fontSize;
            //tb.FontFamily = new FontFamily(fontFamily);
            //tb.Height = textHeight;
            //tb.Width = textWidth;
            //tb.Text = data.Label;
            //tb.Margin = new Thickness(textMarginLeft, textMaginTop, 0, 0);
            //bor.Child = tb;
            //_tableContainer.Children.Add(bor);
            //row.DataUIElements.Add(bor);
            #endregion

            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            tb.Foreground = new SolidColorBrush(Color.FromRgb(0x57, 0x58, 0x6B));
            tb.FontSize = fontSize;
            tb.FontFamily = new FontFamily(fontFamily);
            tb.Height = textHeight;
            tb.Width = textWidth;
            tb.Text = data.Label;
            tb.Margin = new Thickness(x, y, 0, 0);
            _tableContainer.Children.Add(tb);
            row.DataUIElements.Add(tb);
        }
        
        /// <summary>
        /// 重绘行数据及进度
        /// </summary>
        private void ReDrawRowDataShapes()
        {
            DrawTimeProcess(_processTime);
            foreach (DataRowDefine row in _Rows)
            {
                if (row.RowData.Count == 0)
                    continue;
                row.DataUIElements.ForEach(s => _tableContainer.Children.Remove(s));
                row.DataUIElements.Clear();
                foreach (IntakeAndOutputData data in row.RowData)
                {
                    DrawDataShape(row, data);
                    DrawDataLabel(row, data);
                    DrawDataTitle(row);
                }
            }            
        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //DrawTable();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //DrawTable();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            _drawingContext = drawingContext;
            //DrawTable();

            //base.OnRender(drawingContext);
        }

        private void gridTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //单击
            try
            {
                object dataObject = 1;
                PathHelper.POINT p = PathHelper.GetCursorPos();
                _firstX = p.X;
                // DragDrop.DoDragDrop(gridTable, dataObject, DragDropEffects.Move);
                if (_selectDataPoint != null)
                {
                    DragDrop.DoDragDrop(gridTable, _selectDataPoint, DragDropEffects.Move);
                }
                else
                    DragDrop.DoDragDrop(gridTable, dataObject, DragDropEffects.Move);
            }
            finally
            {
                //e.Handled = true;
            }            
        }

        private void gridTable_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            PathHelper.POINT p = PathHelper.GetCursorPos();
            //if (p.X != _lastX || p.Y != _lastY)
            //{
            //    _dragXAxisTip.IsOpen = false;
            //    double xMove = -(p.X - _firstX);
            //    if (xMove > 0)
            //        _dragXAxisTip.Content = "向右移动时间轴：" + _XAxis.GetMoveDesc(xMove);
            //    else
            //        _dragXAxisTip.Content = "向左移动时间轴：" + _XAxis.GetMoveDesc(xMove);
            //    _dragXAxisTip.IsOpen = true;
            //    _lastX = p.X;
            //    _lastY = p.Y;
            //}
            if (_selectDataPoint != null)
            {
                DateTime dataTime = _XAxis.GetTime(p.X);
                _dragXAxisTip.IsOpen = false;
                _dragXAxisTip.Content = "时间：" + dataTime.ToString("yyyy-MM-dd HH:mm:ss");
                _dragXAxisTip.IsOpen = true;
            }
            else
            {
                if (p.X != _lastX || p.Y != _lastY)
                {
                    _dragXAxisTip.IsOpen = false;
                    double xMove = -(p.X - _firstX);
                    if (xMove > 0)
                        _dragXAxisTip.Content = "向右移动时间轴：" + _XAxis.GetMoveDesc(xMove);
                    else
                        _dragXAxisTip.Content = "向左移动时间轴：" + _XAxis.GetMoveDesc(xMove);
                    _dragXAxisTip.IsOpen = true;
                    _lastX = p.X;
                    _lastY = p.Y;
                }
            }
        }

        private void gridTable_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
            e.Effects = DragDropEffects.Move;
        }

        private void gridTable_Drop(object sender, DragEventArgs e)
        {
            try
            {
                if (_dragXAxisTip != null)
                {
                    _dragXAxisTip.IsOpen = false;
                }
                if (_selectDataPoint != null)
                {
                    Point p = e.GetPosition(_tableContainer);
                    DateTime dataTime = _XAxis.GetTime(p.X);
                    DateTime? beforeTime = dataTime;
                    if (!_selectDataPoint.IsContinued)
                    {
                        IntakeAndOutputData data = Data.Find(f => f.Name == _selectDataPoint.Name && f.IsOneTime == !_selectDataPoint.IsContinued && f.OnetimeData.ExcuteTime == _selectDataPoint.Time);
                        if (data != null)
                        {
                            beforeTime = data.OnetimeData.ExcuteTime;
                            data.OnetimeData.ExcuteTime = dataTime;
                            UpdateData(Data);
                            if (DataPointDragAction != null)
                                DataPointDragAction(sender, data, beforeTime);
                        }
                    }
                    else
                    {
                        if (_selectStartTime != DateTime.MinValue)
                        {
                            IntakeAndOutputData data = Data.Find(f => f.Name == _selectDataPoint.Name && f.IsOneTime == !_selectDataPoint.IsContinued && f.BeginTime == _selectDataPoint.BeginTime && f.EndTime == _selectDataPoint.EndTime);

                            if (data != null)
                            {
                                beforeTime = data.BeginTime;
                                if (data.BeginTime >= _selectStartTime.AddMinutes(-2) && data.BeginTime <= _selectStartTime.AddMinutes(2))
                                {
                                    if (data.EndTime != null && data.EndTime <= dataTime) return;
                                    data.BeginTime = dataTime;
                                }
                                else
                                {
                                    if (dataTime <= data.BeginTime) return;
                                    data.EndTime = dataTime;
                                }
                                UpdateData(Data);
                                if (DataPointDragAction != null)
                                    DataPointDragAction(sender, data, beforeTime);
                            }

                        }
                    }
                }
                else
                {
                    PathHelper.POINT p = PathHelper.GetCursorPos();
                    double xMove = -(p.X - _firstX);
                    _XAxis.MoveAxis(xMove, () =>
                    {
                        _XAxisItems.ForEach(c => { _tableContainer.Children.Remove(c); });
                        _XAxisItems.Clear();

                    }, () => { ReDrawRowDataShapes(); });

                    if (MoveXAxisAction != null)
                        MoveXAxisAction(this, xMove);
                }
                //PathHelper.POINT p = PathHelper.GetCursorPos();
                //double xMove = -(p.X - _firstX);
                //_XAxis.MoveAxis(xMove, () =>
                //{
                //    _XAxisItems.ForEach(c => { _tableContainer.Children.Remove(c); });
                //    _XAxisItems.Clear();
                //}, () => { ReDrawRowDataShapes(); });

                //if (MoveXAxisAction != null)
                //    MoveXAxisAction(this, xMove);
            }
            finally
            {
                //e.Handled = true;
            }
        }

        /// <summary>
        /// 移动X轴
        /// </summary>
        /// <param name="xMove"></param>
        public void MoveXAxis(double xMove)
        {
            _XAxis.MoveAxis(xMove, () =>
            {
                _XAxisItems.ForEach(c => { _tableContainer.Children.Remove(c); });
                _XAxisItems.Clear();
            }, () => { ReDrawRowDataShapes(); });
        }

        private void gridTable_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(_tableContainer);
            if (_MouseOldLocation.X == p.X && _MouseOldLocation.Y == p.Y)
                return;
            string content = string.Empty;
            DataPoint dataP = null;
            DataRowDefine curOverRow = null;
            foreach (var row in _Rows)
            {
                dataP = row.DataPoints.Find(dp => dp.DataUIElements.Exists(u => u.IsMouseOver));
                if (dataP != null)
                {
                    curOverRow = row;
                    break;
                }                
            }
            string strMargin = "  ";
            _selectDataPoint = null;
            _selectStartTime = DateTime.MinValue;

            if (dataP != null)
            {                
                content += strMargin + dataP.Name;
                content += "\n———————————————";
                if (dataP.IsContinued)
                {
                    _selectStartTime = _XAxis.GetTime(p.X);
                    content += "\n" + strMargin + "开始时间：" + dataP.BeginTime.Value.ToString(_DataTimeShowFormat);
                    if (dataP.EndTime.HasValue)
                        content += "\n" + strMargin + "结束时间：" + dataP.EndTime.Value.ToString(_DataTimeShowFormat);                                    
                }
                else
                {
                    content += "\n" + strMargin + "用药时间：" + dataP.Time.ToString(_DataTimeShowFormat);
                }
                if (!string.IsNullOrWhiteSpace(dataP.Description))
                {
                    content += "\n" + strMargin + dataP.Description.Replace("\n", "\n" + strMargin);
                }
                _selectDataPoint = dataP;
            }
            else
            {
                curOverRow = _Rows.Find(r => r.BodyRectangle.IsMouseOver);
                if (curOverRow != null && !string.IsNullOrWhiteSpace(curOverRow.RowTitle))
                {
                    content += strMargin + curOverRow.RowTitle;
                    content += "\n—————————————";
                    content += "\n" + strMargin;
                }
                if (_XAxis != null)
                {
                    DateTime dataTime = _XAxis.GetTime(p.X);
                    content += "时间：" + dataTime.ToString("yyyy-MM-dd HH:mm:ss");
                    if (curOverRow != null && !string.IsNullOrWhiteSpace(curOverRow.RowTitle) && curOverRow.DataPoints.Count > 0)
                    {
                        foreach (DataPoint point in curOverRow.DataPoints)
                        {
                            if (point.IsContinued)
                            {
                                if (curOverRow.RowTitle == point.Name && ((point.BeginTime >= dataTime.AddMinutes(-1) && point.BeginTime <= dataTime.AddMinutes(1)) || (point.EndTime >= dataTime.AddMinutes(-1) && point.EndTime <= dataTime.AddMinutes(1))))
                                {
                                    _selectStartTime = dataTime;
                                    _selectDataPoint = point; break;
                                }
                            }
                            else
                            {
                                if (curOverRow.RowTitle == point.Name && point.Time >= dataTime.AddMinutes(-1) && point.Time <= dataTime.AddMinutes(1))
                                {
                                    _selectDataPoint = point; break;
                                }
                            }
                        }
                    }
                }                
            }
            if (!string.IsNullOrWhiteSpace(content))
            {
                _ToolTip.Content = content;
                _ToolTip.IsOpen = false;
                _ToolTip.IsOpen = true;
                _MouseOldLocation = p;
            }
        }

        private void gridTable_MouseLeave(object sender, MouseEventArgs e)
        {
            _ToolTip.IsOpen = false;
            if (_dragXAxisTip != null)
                _dragXAxisTip.IsOpen = false;
        }

        /// <summary>
        /// 绘制当前时间进度
        /// </summary>
        /// <param name="time"></param>
        public void DrawTimeProcess(DateTime time)
        {
            if (_TimeRectangle != null)
            {
                _TimeRectangle.Width = 0;
            }
            _processTime = time;
            //if (_TimeRectangle != null)
            //    _tableContainer.Children.Remove(_TimeRectangle);
            if (_XAxis == null || _processTime < _XAxis.MinTime || _processTime > _XAxis.MaxTime)
            {
                if (_TimeRectangle != null)
                {
                    _TimeRectangle.Width = 0;
                }
                return;
            }
                
            bool isOverMin, isOverMax;
            double x = _XAxis.LocalTransform(_processTime, out isOverMin, out isOverMax);

            Point bodyStartPoint = new Point(StartPoint.X + tableWidth * TableHeadWidthPercent, StartPoint.Y);
            LinearGradientBrush bgBrush = new LinearGradientBrush(Color.FromRgb(0xFF, 0xFF, 0xFF), Color.FromRgb(0xBD, 0xF8, 0xFD), 0.0);
            bgBrush.Opacity = 0.3;
            double width = (x - bodyStartPoint.X) < 200 ? (x - bodyStartPoint.X) : 200;
            if (_TimeRectangle == null)
            {
                _TimeRectangle = PathHelper.DrawRectangle(width, _drawHeight, new Thickness(x - width, bodyStartPoint.Y, 0, 0), bgBrush);
                _tableContainer.Children.Add(_TimeRectangle);
            }
            else
            {
                _TimeRectangle.Width = width;
                _TimeRectangle.Height = _drawHeight;
                _TimeRectangle.Margin = new Thickness(x - width, bodyStartPoint.Y, 0, 0);
            }
        }
    }

    /// <summary>
    /// 交叉表头列
    /// </summary>
    public class CrossHeadColumn
    {
        /// <summary>
        /// 交叉表头列文字
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 交叉表头列背景色
        /// </summary>
        public Color BackgroundColor { get; set; }
        public double FontSize { get; set; }
        public string FontFamily { get; set; }
        
        public CrossHeadColumn(string CrossHeadColumnText,Color CrossHeadColumnBgColor)
        {
            this.Text = CrossHeadColumnText;
            this.BackgroundColor = CrossHeadColumnBgColor;
            FontSize = 12;
            FontFamily = "微软雅黑";
        }
    }
}
