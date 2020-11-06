using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
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
    /// InAndOutControl.xaml 的交互逻辑
    /// </summary>
    public partial class InAndOutControl : UserControl
    {
        private int _MedicineRowCount, _OutputRowCount, _InfusionRowCount;
        private double _TableHeadWidthPercent;
        private List<IntakeAndOutputControl> _graphContorls;
        private bool _isLoaded;
        //private static AxisSetting _AxisSetting;
        private string _DataTimeShowFormat;

        public static readonly DependencyProperty DoubleClickDataProperty = DependencyProperty.Register("DoubleClickData", typeof(IntakeAndOutputClickData), typeof(InAndOutControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(List<IntakeAndOutputData>), typeof(InAndOutControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnDataChanged));
        public static readonly DependencyProperty XAxisSettingProperty = DependencyProperty.Register("XAxisSetting", typeof(AxisSetting), typeof(InAndOutControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnXAxisSettingChanged));
        public static readonly RoutedEvent DoubleClickRoutedEvent = EventManager.RegisterRoutedEvent("DoubleClick", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(InAndOutControl));

        public static readonly RoutedEvent DataPointDragRoutedEvent = EventManager.RegisterRoutedEvent("DataPointDrag", RoutingStrategy.Bubble, typeof(EventHandler<IntakeAndOutputDataEventArgs>), typeof(InAndOutControl));

        #region 属性

        /// <summary>
        /// 行数
        /// </summary>
        private int RowCount
        {
            get
            {
                return MedicineRowCount + OutputRowCount + InfusionRowCount;
            }
        }
        /// <summary>
        /// 用药行数
        /// </summary>
        public int MedicineRowCount
        {
            get { return _MedicineRowCount; }
            set
            {
                _MedicineRowCount = value;
                graphMedicine.RowCount = value;
            }
        }
        /// <summary>
        /// 出量行数
        /// </summary>
        public int OutputRowCount
        {
            get { return _OutputRowCount; }
            set
            {
                _OutputRowCount = value;
                graphOutput.RowCount = value;
            }
        }
        /// <summary>
        /// 输血输液行数
        /// </summary>
        public int InfusionRowCount
        {
            get { return _InfusionRowCount; }
            set
            {
                _InfusionRowCount = value;
                graphInfusion.RowCount = value;
            }
        }

        /// <summary>
        /// 表头宽度百分比
        /// </summary>
        public double TableHeadWidthPercent {
            get
            {
                return _TableHeadWidthPercent;
            }
            set
            {
                _TableHeadWidthPercent = value;
                graphMedicine.TableHeadWidthPercent = value;
                graphOutput.TableHeadWidthPercent = value;
                graphInfusion.TableHeadWidthPercent = value;
            }
        }

        /// <summary>
        /// X轴设置
        /// </summary>
        public AxisSetting XAxisSetting
        {
            get { return (AxisSetting)GetValue(XAxisSettingProperty); }
            set
            {
                SetValue(XAxisSettingProperty, value);
                if (_isLoaded)
                    SetXAxisSetting(value); ;
            }
        }
        /// <summary>
        /// 数据
        /// </summary>
        public List<IntakeAndOutputData> Data
        {
            get { return (List<IntakeAndOutputData>)GetValue(DataProperty); }
            set
            {
                SetValue(DataProperty, value);
                if (_isLoaded)
                    LoadData(value);
            }
        }
        /// <summary>
        /// 双击时的数据
        /// </summary>
        public IntakeAndOutputClickData DoubleClickData
        {
            get { return (IntakeAndOutputClickData)GetValue(DoubleClickDataProperty); }
            set { SetValue(DoubleClickDataProperty, value); }
        }
        #endregion
              
        /// <summary>
        /// 双击
        /// </summary>
        [Description("双击")]
        public event MouseButtonEventHandler DoubleClick
        {
            add { AddHandler(DoubleClickRoutedEvent, value); }
            remove { RemoveHandler(DoubleClickRoutedEvent, value); }
        }

        /// <summary>
        /// 拖拽用药
        /// </summary>
        [Description("拖拽用药")]
        public event RoutedEventHandler DataPointDrag
        {
            add { AddHandler(DataPointDragRoutedEvent, value); }
            remove { RemoveHandler(DataPointDragRoutedEvent, value); }
        }

        /// <summary>
        /// 数据时间显示格式
        /// </summary>
        public string DataTimeShowFormat
        {
            get { return _DataTimeShowFormat; }
            set
            {
                _DataTimeShowFormat = value;
                SetDataTimeShowFormat(value);
            }
        }

        /// <summary>
        /// 移动X轴委托<![CDATA[<sender,xMove>]]>
        /// </summary>
        public Action<object, double> MoveXAxisAction { get; set; }

        public InAndOutControl()
        {
            InitializeComponent();

            _DataTimeShowFormat = "yyyy-MM-dd HH:mm:ss";
            SetDataTimeShowFormat(_DataTimeShowFormat);
            _graphContorls = new List<IntakeAndOutputControl>() { graphMedicine, graphOutput, graphInfusion };
            MedicineRowCount = 15;
            OutputRowCount = 1;
            InfusionRowCount = 4;
            this.graphOutput.CrossHeadColumnDef = new CrossHeadColumn("出\n量", Color.FromRgb(0x33, 0xB3, 0xE0));
            this.graphInfusion.CrossHeadColumnDef = new CrossHeadColumn("输\n血\n&\n输\n液", Color.FromRgb(0x08, 0xA9, 0xBC));
            this.Loaded += InAndOutControl_Loaded;
        }

        public static void OnXAxisSettingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as InAndOutControl).SetXAxisSetting(e.NewValue as AxisSetting);
            if((d as InAndOutControl)._isLoaded)
                (d as InAndOutControl).LoadData();
        }

        public static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        { 
            if ((d as InAndOutControl)._isLoaded)
                (d as InAndOutControl).LoadData();
        }

        public void SetRows()
        {
            graphOutput.IsExchangeOddEvenRowStyle = MedicineRowCount % 2 != 0;
            graphInfusion.IsExchangeOddEvenRowStyle = (MedicineRowCount + OutputRowCount) % 2 != 0;
            double rowHeight = this.ActualHeight / RowCount;
            scrollGraphMedicine.Height = rowHeight * MedicineRowCount;
            scrollGraphOutput.Height = rowHeight * OutputRowCount;
            scrollGraphInfusion.Height = rowHeight * InfusionRowCount;

            graphMedicine.Height = rowHeight * MedicineRowCount;
            graphOutput.Height = rowHeight * OutputRowCount;
            graphInfusion.Height = rowHeight * InfusionRowCount;
        }

        void InAndOutControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetRows();
            SetDelegate();
            LoadData(Data);
            
            _isLoaded = true;
        }

        private void SetXAxisSetting(AxisSetting Setting)
        {
            graphMedicine.Init(Setting);
            graphOutput.Init(Setting);
            graphInfusion.Init(Setting);
        }
        private void SetDataTimeShowFormat(string format)
        {
            graphMedicine.DataTimeShowFormat = format;
            graphOutput.DataTimeShowFormat = format;
            graphInfusion.DataTimeShowFormat = format;
        }
        /// <summary>
        /// 设置委托
        /// </summary>
        private void SetDelegate()
        {
            graphMedicine.DoubleClickAction = DoubleClickHandler;
            graphOutput.DoubleClickAction = DoubleClickHandler;
            graphInfusion.DoubleClickAction = DoubleClickHandler;


            graphMedicine.DataPointDragAction = DataPointGragHandler;
            graphOutput.DataPointDragAction = DataPointGragHandler;
            graphInfusion.DataPointDragAction = DataPointGragHandler;

            graphMedicine.MoveXAxisAction = MoveXAxis;
            graphOutput.MoveXAxisAction = MoveXAxis;
            graphInfusion.MoveXAxisAction = MoveXAxis;
        }

        public void DataPointGragHandler(object sender, IntakeAndOutputData date, DateTime? time)
        {
            IntakeAndOutputDataEventArgs args = new IntakeAndOutputDataEventArgs(DataPointDragRoutedEvent, sender);
            args.DataPoint = date;
            args.BeforeTime = time;
            this.RaiseEvent(args);
        }

        /// <summary>
        /// 移动X轴
        /// </summary>
        /// <param name="xMove"></param>
        public void MoveXAxis(double xMove)
        {
            foreach (IntakeAndOutputControl graph in _graphContorls)
            {
                graph.MoveXAxis(xMove);
            }
        }

        private void DoubleClickHandler(object sender, MouseButtonEventArgs e, List<IntakeAndOutputData> list)
        {
            IntakeAndOutputClickData data = new IntakeAndOutputClickData();            
            if(sender == graphMedicine)
            {
                //双击用药区域
                data.InAndOutType = IntakeAndOutputType.Medicine;
            }
            else if (sender == graphOutput)
            {
                //双击出量区域
                data.InAndOutType = IntakeAndOutputType.Output;
            }
            else if (sender == graphInfusion)
            {
                //双击输血输液区域
                data.InAndOutType = IntakeAndOutputType.Infusion;
            }
            data.Data = list;
            DoubleClickData = data;
            MouseButtonEventArgs newEventArgs = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton);
            newEventArgs.RoutedEvent = DoubleClickRoutedEvent;
            RaiseEvent(newEventArgs);
        }

        private void MoveXAxis(object sender, double xMove)
        {
           foreach(IntakeAndOutputControl graph in _graphContorls)
           {
               if (graph == sender)
                   continue;
               graph.MoveXAxis(xMove);
           }
           if (MoveXAxisAction != null)
           {
               MoveXAxisAction(sender, xMove);
           }
        }

        private void LoadData()
        {
            LoadData(Data);
        }
        
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="DataList"></param>
        private void LoadData(List<IntakeAndOutputData> DataList)
        {
            if (DataList != null)
            {
                graphMedicine.Data = DataList.FindAll(p => p.InAndOutType == IntakeAndOutputType.Medicine);
                graphOutput.Data = DataList.FindAll(p => p.InAndOutType == IntakeAndOutputType.Output);
                graphInfusion.Data = DataList.FindAll(p => p.InAndOutType == IntakeAndOutputType.Infusion);
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="DataList"></param>
        private void UpdateRowData(List<IntakeAndOutputData> DataList)
        {
            if (DataList != null)
            {
                graphMedicine.Data = DataList.FindAll(p => p.InAndOutType == IntakeAndOutputType.Medicine);
                graphOutput.Data = DataList.FindAll(p => p.InAndOutType == IntakeAndOutputType.Output);
                graphInfusion.Data = DataList.FindAll(p => p.InAndOutType == IntakeAndOutputType.Infusion);
            }
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="Data"></param>
        public void AddData(IntakeAndOutputData Data)
        {
            if (Data == null)
                return;
            List<IntakeAndOutputData> DataList = new List<IntakeAndOutputData>() { Data };
            switch(Data.InAndOutType)
            {
                case IntakeAndOutputType.Medicine:
                    graphMedicine.AddData(DataList);
                    break;
                case IntakeAndOutputType.Output:
                    graphOutput.AddData(DataList);
                    break;
                case IntakeAndOutputType.Infusion:
                    graphInfusion.AddData(DataList);
                    break;
            }
        }
        /// <summary>
        /// 新增数据集合
        /// </summary>
        /// <param name="DataList"></param>
        public void AddDataRange(List<IntakeAndOutputData> DataList)
        {
            if (DataList == null)
                return;
            graphMedicine.AddData(DataList.FindAll(p => p.InAndOutType == IntakeAndOutputType.Medicine));
            graphOutput.AddData(DataList.FindAll(p => p.InAndOutType == IntakeAndOutputType.Output));
            graphInfusion.AddData(DataList.FindAll(p => p.InAndOutType == IntakeAndOutputType.Infusion));
        }

        public void DrawTimeProcess(DateTime time)
        {
            graphMedicine.DrawTimeProcess(time);
            graphOutput.DrawTimeProcess(time);
            graphInfusion.DrawTimeProcess(time);
        }

        private void scrollGraphInfusion_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            graphInfusion.SetVerticalOffset(scrollGraphOutput.VerticalOffset);
        }

        private void scrollGraphOutput_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            graphOutput.SetVerticalOffset(scrollGraphOutput.VerticalOffset);
        }

        private void scrollGraphMedicine_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            graphMedicine.SetVerticalOffset(scrollGraphOutput.VerticalOffset);
        }
    }
}
