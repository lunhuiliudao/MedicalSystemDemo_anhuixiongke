/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedVitalSignGraph.cs
      // 文件功能描述：体征曲线控件
      //
      // 
      // 创建标识：戴呈祥-2008-10-21
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
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Designer;
using System.Drawing.Design;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Document.Controls
{

    /// <summary>
    /// 体征曲线控件
    /// </summary>
    [Serializable, ToolboxItem(false), Description("体征曲线")]
    public partial class MedVitalSignGraph : AnesGraph, IPrintable
    {
        #region 构造方法

        public MedVitalSignGraph()
        {
            InitializeComponent();
            TimeText = null;
            TotalText = "图例";
            if (DesignMode) Test();
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 网格颜色
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
        private int _minScaleCount = 6;

        /// <summary>
        /// 小刻度刻度数(Y)
        /// </summary>
        private int _minYScaleCount = 1;

        /// <summary>
        /// 小刻度线颜色
        /// </summary>
        private Color _middleLineColor = Color.FromArgb(255, 200, 200);

        /// <summary>
        /// 小刻度线宽度
        /// </summary>
        private float _minScaleWidth = .5f;

        /// <summary>
        /// 小刻度线样式
        /// </summary>
        private DashStyle _minDashStyle = DashStyle.DashDotDot;

        /// <summary>
        /// Y坐标
        /// </summary>
        private List<MedVitalSignYAxis> _yAxises = new List<MedVitalSignYAxis>(new MedVitalSignYAxis[]{
            new MedVitalSignYAxis(new double[] { 0, 10, 20, 30, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220 }, "mmHg"),
            new MedVitalSignYAxis(new double[] { -1, -1, 60, 64, 68, 72, 76, 80, 84, 88, 92, 96, 100, 104 }, "spo2"),
            new MedVitalSignYAxis(new double[] { -1, -1, -1, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42 }, "℃")});

        /// <summary>
        /// Y坐标刻度数
        /// </summary>
        private int _yAxisScaleCount = 13;

        /// <summary>
        /// Y坐标边框类型
        /// </summary>
        private YAxisBorderType _yAxisBorderType = YAxisBorderType.RountRect;

        /// <summary>
        /// Y坐标边框宽度
        /// </summary>
        private int _yAxisBorderWidth = 1;

        /// <summary>
        /// Y坐标边框颜色
        /// </summary>
        private Color _yAxisBorderColor = Color.FromArgb(160, 160, 160);

        /// <summary>
        /// 体征曲线
        /// </summary>
        private List<MedVitalSignCurve> _curves = new List<MedVitalSignCurve>();

        /// <summary>
        /// 图例字体
        /// </summary>
        private Font _legendFont;

        /// <summary>
        /// 图例类别
        /// </summary>
        private LegengType _legendType = LegengType.Vertical;

        /// <summary>
        /// 事件标记
        /// </summary>
        private EventMark _eventMark;

        /// <summary>
        /// 事件标记高度
        /// </summary>
        private float _eventMarkHeight = 20;

        /// <summary>
        /// 控制呼吸时间
        /// </summary>
        private List<DateTime> _breathControlTime = new List<DateTime>();

        /// <summary>
        /// 控制呼吸列表
        /// </summary>
        private List<MedVitalSignBreathControlTime> _breathControlTimeList = new List<MedVitalSignBreathControlTime>();

        /// <summary>
        /// 事件位移
        /// </summary>
        private float _eventOffSet = 0;

        /// <summary>
        /// 数字索引
        /// </summary>
        private Dictionary<string, int> _digitIndex;

        /// <summary>
        /// 事件区域集合
        /// </summary>
        private Dictionary<EventItem, RectangleF> _eventRects = new Dictionary<EventItem, RectangleF>();

        /// <summary>
        /// 选择的点
        /// </summary>
        private MedVitalSignPoint _selectPoint = null;

        /// <summary>
        /// 上次时间点
        /// </summary>
        private DateTime _oldTimePoint;

        /// <summary>
        /// 上次值
        /// </summary>
        private double _oldValue;

        /// <summary>
        /// 上次鼠标位置
        /// </summary>
        private Point _oldMousePos = new Point(-1000, -1000);


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

        #endregion 变量

        #region 事件接口

        private static readonly object _controlBreathStartDoubleClick = new object();
        public event EventHandler ControlBreathStartDoubleClick
        {
            add
            {
                Events.AddHandler(_controlBreathStartDoubleClick, value);
            }
            remove
            {
                Events.RemoveHandler(_controlBreathStartDoubleClick, value);
            }
        }

        /// <summary
        /// 值改变
        /// </summary>
        private static readonly object _valueChanged = new object();
        public event EventHandler<VitalSignPointEventArgs> ValueChanged
        {
            add
            {
                Events.AddHandler(_valueChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_valueChanged, value);
            }
        }


        /// <summary
        /// 属性点移动
        /// </summary>
        private static readonly object _SignPointMouseMove = new object();
        public event EventHandler<VitalSignPointEventArgs> SignPointMouseMove
        {
            add
            {
                Events.AddHandler(_SignPointMouseMove, value);
            }
            remove
            {
                Events.RemoveHandler(_SignPointMouseMove, value);
            }
        }
        /// <summary>
        /// 鼠标右键
        /// </summary>
        private static readonly object _rMouseClick = new object();
        public event EventHandler RMouseClick
        {
            add
            {
                Events.AddHandler(_rMouseClick, value);
            }
            remove
            {
                Events.RemoveHandler(_rMouseClick, value);
            }
        }

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

        #region 属性
        [Browsable(false)]
        public Point MousePostion
        {
            get
            {
                return _oldMousePos;
            }
        }

        private bool _isMouseInMark = false;
        [Browsable(false)]
        public bool IsMouseInMark
        {
            get
            {
                return _isMouseInMark;
            }
        }


        private MedVitalSignBreathControlTime _selectedBreathControlTime = null;
        [Browsable(false)]
        public MedVitalSignBreathControlTime SelectedBreathControlTime
        {
            get
            {
                return _selectedBreathControlTime;
            }
        }

        private bool _clearLeftBottomLine = true;
        public bool ClearLeftBottomLine
        {
            get
            {
                return _clearLeftBottomLine;
            }
            set
            {
                _clearLeftBottomLine = value;
            }
        }

        private bool _clearLeftTopLine = true;
        public bool ClearLeftTopLine
        {
            get
            {
                return _clearLeftTopLine;
            }
            set
            {
                _clearLeftTopLine = value;
            }
        }

        /// <summary>
        /// 修改体征值
        /// </summary>
        private NewMonitorData _newMonitorData = null;
        public NewMonitorData NewMonitorData
        {
            get
            {
                return _newMonitorData;
            }
            set
            {
                _newMonitorData = value;
            }
        }

        private string _eventNo = "0";
        /// <summary>
        /// 0为麻醉,1复苏 2-体外循环
        /// </summary>
        //[Browsable(false)]
        public string EventNo
        {
            get
            {
                return _eventNo;
            }
            set
            {
                _eventNo = value;
            }
        }

        /// <summary>
        /// 控制呼吸时间
        /// </summary>
        [Browsable(false)]
        public List<DateTime> BreathControlTime
        {
            get
            {
                return _breathControlTime;
            }
            set
            {
                _breathControlTime = value;
            }
        }

        /// <summary>
        /// 控制呼吸列表
        /// </summary>
        [Browsable(false)]
        public List<MedVitalSignBreathControlTime> BreathControlTimeList
        {
            get
            {
                return _breathControlTimeList;
            }
            set
            {
                _breathControlTimeList = value;
            }
        }

        private string _breathParaName1 = "";
        [Browsable(false)]
        public string BreathParaName1
        {
            get
            {
                return _breathParaName1;
            }
            set
            {
                _breathParaName1 = value;
            }
        }

        private string _breathParaName2 = "";
        [Browsable(false)]
        public string BreathParaName2
        {
            get
            {
                return _breathParaName2;
            }
            set
            {
                _breathParaName2 = value;
            }
        }

        private string _breathParaName3 = "";
        [Browsable(false)]
        public string BreathParaName3
        {
            get
            {
                return _breathParaName3;
            }
            set
            {
                _breathParaName3 = value;
            }
        }

        private string _breathPara1 = "";
        /// <summary>
        /// 绑定字段名称
        /// </summary>
        [DisplayName("呼吸参数1"), Category("数据(自定义)")]
        [Editor(typeof(FieldNamesOfMonitorFunctionCodeDropDownEditor), typeof(UITypeEditor))]
        public string BreathPara1
        {
            get
            {
                return _breathPara1;
            }
            set
            {
                _breathPara1 = value;
            }
        }

        private string _breathPara2 = "";
        /// <summary>
        /// 绑定字段名称
        /// </summary>
        [DisplayName("呼吸参数2"), Category("数据(自定义)")]
        [Editor(typeof(FieldNamesOfMonitorFunctionCodeDropDownEditor), typeof(UITypeEditor))]
        public string BreathPara2
        {
            get
            {
                return _breathPara2;
            }
            set
            {
                _breathPara2 = value;
            }
        }

        private string _breathPara3 = "";
        /// <summary>
        /// 绑定字段名称
        /// </summary>
        [DisplayName("呼吸参数3"), Category("数据(自定义)")]
        [Editor(typeof(FieldNamesOfMonitorFunctionCodeDropDownEditor), typeof(UITypeEditor))]
        public string BreathPara3
        {
            get
            {
                return _breathPara3;
            }
            set
            {
                _breathPara3 = value;
            }
        }

        private Color _printColor = Color.DarkGray;
        [DisplayName("网格打印颜色")]
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

        private bool _isPrintSingleCurveColor = false;
        [DisplayName("单一颜色打印曲线")]
        public bool IsPrintSingleCurveColor
        {
            get
            {
                return _isPrintSingleCurveColor;
            }
            set
            {
                _isPrintSingleCurveColor = value;
            }
        }

        private bool _isShowBloodGas = false;
        [DisplayName("是否显示血气")]
        public bool IsShowBloodGas
        {
            get { return _isShowBloodGas; }
            set { _isShowBloodGas = value; }
        }


        private bool _isShowBloodGasUnit = false;
        [DisplayName("是否显示血气单位")]
        public bool IsShowBloodGasUnit
        {
            get { return _isShowBloodGasUnit; }
            set { _isShowBloodGasUnit = value; }
        }
        /// <summary>
        /// 血气
        /// </summary>
        private List<BloodGasMaster> _bloodGasItems = new List<BloodGasMaster>();
        [Browsable(false)]
        public List<BloodGasMaster> BloodGasItems
        {
            get
            {
                return _bloodGasItems;
            }

            set
            {
                _bloodGasItems = value;
            }
        }

        /// <summary>
        /// 事件集合(竖直显示)
        /// </summary>
        private List<EventItem> _events = new List<EventItem>();
        [Browsable(false)]
        public List<EventItem> AnesEvents
        {
            get
            {
                return _events;
            }

            set
            {
                _events = value;
            }
        }

        private bool _showLegend = true;
        [Category("数据-自定义"), DisplayName("显示图例")]
        public bool ShowLegend
        {
            get
            {
                return _showLegend;
            }
            set
            {
                _showLegend = value;
            }
        }

        private bool _hasEventMark = false;
        [Category("数据-自定义"), DisplayName("显示事件标识")]
        public bool HasEventMark
        {
            get
            {
                return _hasEventMark;
            }
            set
            {
                _hasEventMark = value;
            }
        }

        [Category("数据-自定义"), DisplayName("事件标识高度")]
        public float EventMarkHeight
        {
            get
            {
                return _eventMarkHeight;
            }
            set
            {
                _eventMarkHeight = value;
            }
        }

        /// <summary>
        /// 是否具有用户自绘制线
        /// </summary>
        private bool _isUseLine = false;
        public bool IsUserLine
        {
            get
            {
                return _isUseLine;
            }
            set
            {
                _isUseLine = value;
            }
        }

        private int _startLegendIndex = 0;
        [Category("数据-自定义"), DisplayName("起始图例索引")]
        public int StartLegendIndex
        {
            get
            {
                return _startLegendIndex;
            }
            set
            {
                _startLegendIndex = value;
            }
        }

        private bool _isDigitTop = false;
        [Category("数据-自定义"), DisplayName("数值在顶端")]
        public bool IsDigitTop
        {
            get
            {
                return _isDigitTop;
            }
            set
            {
                _isDigitTop = value;
            }
        }

        //public new Color BorderColor
        //{
        //    get
        //    {
        //        return _borderColor;
        //    }
        //    set
        //    {
        //        base.BorderColor = value;
        //        _gridColor = value;
        //        _minScaleColor = value;
        //        _yAxisBorderColor = value;
        //    }
        //}

        /// <summary>
        /// 网格颜色
        /// </summary>
        [Category("数据-自定义"), DisplayName("网格竖线颜色")]
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

        [Category("数据-自定义"), DisplayName("网格横线颜色")]
        public Color RowGridColor
        {
            get
            {
                if (_isPrinting)
                {
                    //if (_rowColorEqualColumColor)
                    //    return _printColor;
                    //else
                    //    return _rowprintColor;
                    return _printColor;
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


        [Category("数据-自定义"), DisplayName("网格横线颜色与网格竖线颜色相同")]
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
        [Category("数据-自定义"), DisplayName("网格线宽度")]
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
        [Category("数据-自定义"), DisplayName("刻度线样式")]
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
        [Category("数据-自定义"), DisplayName("小刻度线样式")]
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
        [Category("数据-自定义"), DisplayName("小刻度线宽度")]
        public float MinScaleWidth
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
        [Category("数据-自定义"), DisplayName("小刻度线数")]
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
        /// 小刻度线数(Y)
        /// </summary>
        [Category("数据-自定义"), DisplayName("小刻度线数(Y)")]
        public int MinYScaleCount
        {
            get
            {
                return _minYScaleCount;
            }
            set
            {
                _minYScaleCount = value;
            }
        }

        /// <summary>
        /// Y坐标
        /// </summary>
        [Category("数据-自定义"), DisplayName("Y坐标轴设置")]
        public List<MedVitalSignYAxis> YAxises
        {
            get
            {
                return _yAxises;
            }
            set
            {
                _yAxises = value;
                if (_yAxises != null && _yAxises.Count > 0)
                {
                    //_yAxisScaleCount = 35;
                    foreach (MedVitalSignYAxis yAxis in _yAxises)
                    {
                        if (_yAxisScaleCount != yAxis.ScaleValues.Count)
                        {
                            _yAxisScaleCount = yAxis.ScaleValues.Count;
                        }
                    }
                }
            }
        }

        ///// <summary>
        ///// Y坐标刻度数
        ///// </summary>
        //public int YAxisScaleCount
        //{
        //    get
        //    {
        //        return _yAxisScaleCount;
        //    }
        //    set
        //    {
        //        _yAxisScaleCount = value;
        //    }
        //}

        /// <summary>
        /// 是否画底线
        /// </summary>
        public bool _isDrawBottomLine = false;
        public bool IsDrawBottomLine
        {
            get
            {
                return _isDrawBottomLine;
            }
            set
            {
                _isDrawBottomLine = value;
            }
        }

        /// <summary>
        /// Y坐标边框类型
        /// </summary>
        [Category("数据-自定义"), DisplayName("坐标边框类型")]
        public YAxisBorderType YAxisBorderType
        {
            get
            {
                return _yAxisBorderType;
            }
            set
            {
                _yAxisBorderType = value;
            }
        }

        /// <summary>
        /// Y坐标边框颜色
        /// </summary>
        [Category("数据-自定义"), DisplayName("坐标边框颜色")]
        public Color YAxisBorderColor
        {
            get
            {
                return _yAxisBorderColor;
            }
            set
            {
                _yAxisBorderColor = value;
            }
        }

        /// <summary>
        /// Y坐标边框宽度
        /// </summary>
        [Category("数据-自定义"), DisplayName("坐标边框宽度")]
        public int YAxisBorderWidth
        {
            get
            {
                return _yAxisBorderWidth;
            }
            set
            {
                _yAxisBorderWidth = value;
            }
        }

        private float _legengSymbolSize = 6;
        [Category("数据-自定义"), DisplayName("图例标识大小")]
        public float LegendSymbolSize
        {
            get
            {
                return _legengSymbolSize;
            }
            set
            {
                _legengSymbolSize = value;
            }
        }

        private float _curveSymbolSize = 6;
        [Category("数据-自定义"), DisplayName("曲线标识大小")]
        public float CurveSymbolSize
        {
            get
            {
                return _curveSymbolSize;
            }
            set
            {
                _curveSymbolSize = value;
            }
        }

        /// <summary>
        /// 图例字体
        /// </summary>
        [Category("数据-自定义"), DisplayName("图例字体")]
        public Font LegendFont
        {
            get
            {
                if (_legendFont != null)
                {
                    return _legendFont;
                }
                else
                {
                    return DefaultFont;
                }
            }
            set
            {
                _legendFont = value;
            }
        }

        /// <summary>
        /// 体征曲线
        /// </summary>
        [Category("数据-自定义"), DisplayName("曲线"), Browsable(false)]
        public List<MedVitalSignCurve> Curves
        {
            get
            {
                return _curves;
            }
            set
            {
                _curves = value;
            }
        }

        [Category("数据-自定义"), DisplayName("图例类别")]
        public LegengType LegendType
        {
            get
            {
                return _legendType;
            }
            set
            {
                _legendType = value;
            }
        }

        [Category("数据-自定义"), DisplayName("事件标记"), Browsable(false)]
        public EventMark EventMark
        {
            get
            {
                return _eventMark;
            }
            set
            {
                _eventMark = value;
            }
        }

        private bool _canUpdate = true;
        [Category("数据-自定义"), DisplayName("是否可修改")]
        public bool CanUpdate
        {
            get
            {
                return _canUpdate;
            }
            set
            {
                _canUpdate = value;
            }
        }

        /// <summary>
        /// 右键菜单
        /// </summary>
        private ContextMenuStrip _popupMenu;
        public ContextMenuStrip PopupMenu
        {
            set
            {
                _popupMenu = value;
            }
        }

        [Category("数据-自定义"), DisplayName("当前选中点"), Browsable(false)]
        public MedVitalSignPoint SelectedPoint
        {
            get
            {
                return _selectPoint;
            }
        }

        /// <summary>
        /// 图例字体
        /// </summary>
        private bool _isLegendFloat = false;
        public bool IsLegendFloat
        {
            get
            {
                return _isLegendFloat;
            }
            set
            {
                _isLegendFloat = value;
            }
        }

        private List<MedVitalSignCurveDetail> _curveDetails = new List<MedVitalSignCurveDetail>();
        [Category("数据-自定义"), DisplayName("曲线明细设置")]
        public List<MedVitalSignCurveDetail> CurveDetails
        {
            get
            {
                return _curveDetails;
            }
            set
            {
                _curveDetails = value;
            }
        }

        private List<MedSymbolCurveDetail> _eventMarkSettings = new List<MedSymbolCurveDetail>();
        [Category("数据-自定义"), DisplayName("事件标识设置")]
        public List<MedSymbolCurveDetail> EventMarkSettings
        {
            get
            {
                return _eventMarkSettings;
            }
            set
            {
                _eventMarkSettings = value;
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

        private Font _bloodGasFont = new Font("宋体", 9);
        [DisplayName("血气字体")]
        public Font BloodGasFont
        {
            get
            {
                return _bloodGasFont;
            }
            set
            {
                _bloodGasFont = value;
            }
        }

        private bool _drawCurveLegend = true;
        [DisplayName("画体征图例")]
        public bool DrawCurveLegend
        {
            get
            {
                return _drawCurveLegend;
            }
            set
            {
                _drawCurveLegend = value;
            }
        }

        private bool _onlyShowFiveMinute = true;
        [Category("数据-自定义"), DisplayName("只显示整5分钟数据")]
        public bool OnlyShowFileMinute
        {
            get
            {
                return _onlyShowFiveMinute;
            }
            set
            {
                _onlyShowFiveMinute = value;
            }
        }

        private InterValControlType _interValControl = InterValControlType.ControlAll;
        [Category("数据-自定义"), DisplayName("时间间隔作用曲线")]
        public InterValControlType InterValControl
        {
            get
            {
                return _interValControl;
            }
            set
            {
                _interValControl = value;
            }
        }

        /// <summary>
        /// 体外循环时间列表
        /// </summary>
        private SortedList<DateTime, string> _CPBTtimeList = new SortedList<DateTime, string>();
        public SortedList<DateTime, string> CPBTtimeList
        {
            get { return _CPBTtimeList; }
            set { _CPBTtimeList = value; }
        }

        /// <summary>
        /// 是否绘制右侧底线
        /// </summary>
        private bool _drawRightBottom = true;
        public bool DrawRightBottom
        {
            get
            {
                return _drawRightBottom;
            }
            set
            {
                _drawRightBottom = value;
            }
        }

        /// <summary>
        /// 修改了的点
        /// </summary>
        private List<MedVitalSignPoint> _modifiedPoints = new List<MedVitalSignPoint>();
        [Browsable(false)]
        public List<MedVitalSignPoint> ModifiedPoints
        {
            get
            {
                return _modifiedPoints;
            }
            set
            {
                _modifiedPoints = value;
            }
        }

        /// <summary>
        /// 是否锁定鼠标
        /// </summary>
        private bool _lockMouse = false;
        public bool LockMouse
        {
            get
            {
                return _lockMouse;
            }
            set
            {
                _lockMouse = value;
            }
        }

        /// <summary>
        /// 鼠标所在时间
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
        /// 所选的血气
        /// </summary>
        private BloodGasMaster _selectedBlood = null;
        public BloodGasMaster SelectedBlood
        {
            get
            {
                return _selectedBlood;
            }
        }

        /// <summary>
        /// 所选的事件
        /// </summary>
        private EventItem _selectedEvent = null;
        public EventItem SelectedEventItem
        {
            get
            {
                return _selectedEvent;
            }
        }

        private string _title = "";
        [Category("数据-自定义"), DisplayName("标题")]
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
        [Category("数据-自定义"), DisplayName("标题宽度")]
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

        private string _rightYAxis = "";
        [Category("数据-自定义"), DisplayName("右侧Y坐标轴索引")]
        public string RightYAxis
        {
            get
            {
                return _rightYAxis;
            }
            set
            {
                _rightYAxis = value;
            }
        }

        #endregion 属性

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
        /// 获取曲线
        /// </summary>
        /// <param name="curveText"></param>
        /// <returns></returns>
        public MedVitalSignCurve GetCurve(string curveText)
        {
            foreach (MedVitalSignCurve curve in _curves)
            {
                if (curve.Text.Equals(curveText))
                {
                    return curve;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public override RectangleF GetMainRect()
        {
            RectangleF rect = base.GetMainRect();
            rect.Height -= _eventMarkHeight;
            return rect;
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

        private bool _CurrentPosCanMove = true;
        public void SetCurrentPosMove(bool bMove)
        {
            this._CurrentPosCanMove = bMove;

        }
        private void DrawHourLines(Graphics g)
        {
            RectangleF rect = GetMainRect();
            // DateTime dt = new DateTime(_startTime.Year, _startTime.Month, _startTime.Day, _startTime.Hour + 1, 0, 0);
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
            TimeSpan spTotal = _endTime - _startTime;
            while (dt < _endTime)
            {
                TimeSpan spThis = dt - _startTime;
                float x1 = (float)(rect.X + rect.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
                g.DrawLine(Pens.Black, x1, rect.Y + _topOffSet, x1, rect.Height - _topOffSet);
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
        /// 绘制体征曲线图
        /// </summary>
        /// <param name="g"></param>
        public override void DrawGraphics(Graphics graphics)
        {
            _zoomRate = (float)(1 / _showZoomRate);

            Graphics g = graphics;

            bool lockMouse = _lockMouse;
            _lockMouse = true;
            base.DrawGraphics(g);

            float leftoff = string.IsNullOrEmpty(_title) ? 0f : _titleWidth;
            RectangleF rect = GetMainRect();
            if (_yAxisBorderType == YAxisBorderType.BottomLine && _topOffSet > 0)
            {
                g.FillRectangle(Brushes.White, OriginRect.Left + 2 + (int)leftoff, _topOffSet - 2, rect.X - OriginRect.Left - 3, 4);
                g.FillRectangle(Brushes.White, rect.X + 1 + (int)leftoff, 1, rect.Width - 4, _topOffSet - 2);
            }
            else if (_topOffSet > 0)
            {
                if (_clearLeftTopLine)
                {
                    g.FillRectangle(Brushes.White, OriginRect.Left + 2, _topOffSet - 2, rect.X - OriginRect.Left - 3, 4);
                }
            }

            if (CPBTtimeList.Count > 0)
            {

                List<CPBTimeItem> tiwaitimeList = new List<CPBTimeItem>();


                //for (int i = 0; i < CPBTtimeList.Count - 1; i++)
                //{
                //    if (CPBTtimeList.Keys[i + 1] < _startTime)
                //        continue;

                //    DateTime startTime = CPBTtimeList.Keys[i];
                //    DateTime endTime = CPBTtimeList.Keys[i + 1];

                //    if (startTime < _startTime)
                //        startTime = _startTime;

                //    if (endTime > _endTime)
                //        endTime = _endTime;


                //    CPBTimeItem item = new CPBTimeItem();
                //    item.CPBStart = startTime;
                //    item.CPBEnd = endTime;

                //    if (CPBTtimeList.Values[i] == "阻断升主动脉")
                //        item.Type = 0;
                //    else
                //        item.Type = 1;
                //    tiwaitimeList.Add(item);

                //}


                for (int i = 0; i < CPBTtimeList.Count; )
                {
                    DateTime startTime = DateTime.MinValue, endTime = DateTime.MinValue;
                    if (CPBTtimeList.Values[i] == "体外循环结束")
                    {
                        if (CPBTtimeList.Keys[i] >= _startTime)
                        {
                            if (tiwaitimeList.Count == 0)
                            {
                                //endTime = CPBTtimeList.Keys[i];
                                //CPBTimeItem item = new CPBTimeItem();
                                //item.CPBStart = startTime;
                                //item.CPBEnd = endTime;
                                //tiwaitimeList.Add(item);
                            }
                            else
                            {
                                int count = tiwaitimeList.Count;
                                startTime = tiwaitimeList[count - 1].CPBStart;
                                endTime = CPBTtimeList.Keys[i];
                                CPBTimeItem item = new CPBTimeItem();
                                item.CPBStart = startTime;
                                item.CPBEnd = endTime;
                                item.Type = 1;
                                tiwaitimeList.RemoveAt(count - 1);
                                tiwaitimeList.Add(item);
                            }
                        }
                        i += 1;
                        continue;
                    }

                    else if (CPBTtimeList.Values[i] == "体外循环开始")
                    {
                        if (CPBTtimeList.Keys[i] < _endTime)
                        {
                            startTime = CPBTtimeList.Keys[i];
                            for (int j = i + 1; j < CPBTtimeList.Count; j++)
                            {
                                i = j + 1;
                                if (CPBTtimeList.Values[j] == "体外循环结束")
                                {
                                    endTime = CPBTtimeList.Keys[j];
                                    break;
                                }
                            }
                            CPBTimeItem item = new CPBTimeItem();
                            item.CPBStart = startTime;
                            item.CPBEnd = endTime;
                            item.Type = 1;


                            tiwaitimeList.Add(item);
                            if (endTime == DateTime.MinValue)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    else
                    {
                        i += 1;
                    }

                }
                for (int i = 0; i < CPBTtimeList.Count; )
                {
                    DateTime startTime = DateTime.MinValue, endTime = DateTime.MinValue;
                    if (CPBTtimeList.Values[i] == "开放升主动脉")
                    {
                        if (CPBTtimeList.Keys[i] >= _startTime)
                        {
                            if (tiwaitimeList.Count == 0)
                            {
                            }
                            else
                            {
                                int count = tiwaitimeList.Count;
                                startTime = tiwaitimeList[count - 1].CPBStart;
                                endTime = CPBTtimeList.Keys[i];
                                CPBTimeItem item = new CPBTimeItem();
                                item.CPBStart = startTime;
                                item.CPBEnd = endTime;
                                item.Type = 0;
                                tiwaitimeList.RemoveAt(count - 1);
                                tiwaitimeList.Add(item);
                            }
                        }
                        i += 1;
                        continue;
                    }
                    else if (CPBTtimeList.Values[i] == "阻断升主动脉")
                    {
                        if (CPBTtimeList.Keys[i] < _endTime)
                        {
                            startTime = CPBTtimeList.Keys[i];
                            for (int j = i + 1; j < CPBTtimeList.Count; j++)
                            {
                                i = j + 1;
                                if (CPBTtimeList.Values[j] == "开放升主动脉")
                                {
                                    endTime = CPBTtimeList.Keys[j];
                                    break;
                                }
                            }
                            CPBTimeItem item = new CPBTimeItem();
                            item.CPBStart = startTime;
                            item.CPBEnd = endTime;
                            item.Type = 0;

                            tiwaitimeList.Add(item);
                            if (endTime == DateTime.MinValue)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    else
                    {
                        i += 1;
                    }

                }




                foreach (CPBTimeItem item in tiwaitimeList)
                {
                    float x1 = 0, x2 = 0;
                    if (item.CPBStart == DateTime.MinValue)
                    {
                        //x1 = GetX(_startTime, rect);
                        //if (item.CPBEnd > _endTime)
                        //{
                        //    x2 = GetX(_endTime, rect);
                        //}
                        //else
                        //{
                        //    x2 = GetX(item.CPBEnd, rect);
                        //}
                        //using (Brush brush = new SolidBrush(Color.FromArgb(192, 192, 192)))
                        //{
                        //    g.FillRectangle(brush, x1, _topOffSet - 2, x2 - x1, OriginHeight);
                        //}
                    }
                    else if (item.CPBEnd == DateTime.MinValue)
                    {
                        if (item.CPBStart > _startTime)
                        {
                            x1 = GetX(item.CPBStart, rect);
                        }
                        else
                        {
                            x1 = GetX(_startTime, rect);
                        }
                        if (DateTime.Now > _endTime)
                        {
                            x2 = GetX(_endTime, rect);
                        }
                        else
                        {
                            x2 = GetX(DateTime.Now, rect);
                        }
                    }
                    else
                    {

                        if (item.CPBEnd < _startTime)
                        {
                            continue;
                        }
                        if (item.CPBStart < _startTime)
                        {
                            x1 = GetX(_startTime, rect);
                        }
                        else
                        {
                            x1 = GetX(item.CPBStart, rect);
                        }

                        if (item.CPBEnd > _endTime)
                        {
                            x2 = GetX(_endTime, rect);
                        }
                        else
                        {
                            x2 = GetX(item.CPBEnd, rect);
                        }
                    }
                    using (Brush brush2 = new SolidBrush(Color.FromArgb(192, 192, 192)))
                    {
                        using (Brush brush1 = new HatchBrush(HatchStyle.LightUpwardDiagonal, Color.Red, Color.FromArgb(192, 192, 192)))
                        {
                            if (float.IsNaN(x1) || float.IsNaN(x2))
                            { }
                            else
                            {
                                //20120926参照空总新增 
                                Brush brush = item.Type == 1 ? brush2 : brush1;
                                g.FillRectangle(brush, x1, OriginHeight - _topOffSet - 10, x2 - x1, 10);
                                //g.FillRectangle(brush, x1, OriginHeight-_topOffSet - 10, x2 - x1, 10);
                            }
                        }
                    }
                }
            }

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

            _eventOffSet = 0;
            _digitIndex = new Dictionary<string, int>();
            if (_eventMark != null)
            {
                DrawEventMarks(g);
            }

            SolidBrush backBrush = new SolidBrush(BackColor);
            Pen borderPen = new Pen(_borderColor);
            Pen borderWidthPen = new Pen(_borderColor, _borderWidth);

            Rectangle rect1 = new Rectangle((int)rect.Right, (int)_topOffSet + 1, (int)Bounds.Width - (int)rect.Right - 3, (int)(rect.Height));
            if (_clearLeftBottomLine)
            {
                g.FillRectangles(backBrush, new Rectangle[] { new Rectangle(2, (int)_topOffSet + 1, (int)rect.Left - 3
                , (int)(rect.Height)) ,rect1 });
            }
            DrawYAxises(g);
            if (_rightWidthPercent > 0 && _curves != null)
            {
                RectangleF rect2 = new RectangleF(rect.Right, rect.Top + _topOffSet + 2, OriginRect.Right - rect.Right, OriginRect.Height + 1);
                g.FillRectangle(backBrush, rect2);
                //g.FillRectangle(backBrush, new RectangleF(OriginRect.Right, rect.Top, 100, rect.Height));
                g.DrawLine(borderWidthPen, rect2.Right - 1, rect2.Top, rect2.Right - 1, rect2.Bottom);
                RectangleF rectF = GetMainRect();
                rectF.X = rectF.Right;
                rectF.Y += _topOffSet + 1;// - 15;
                if (_startLegendIndex > 0)
                {
                    rectF.Y -= _topOffSet;
                    g.FillRectangle(backBrush, new RectangleF(rectF.X, rectF.Y, OriginRect.Right - rectF.X - 2, _topOffSet + 20));
                }
                if (_showLegend)
                {
                    DrawLegend(g, rectF, _startLegendIndex);
                }
                else
                {
                    DrawControlBreathParaLegend(g, new PointF(rectF.X + (OriginRect.Right - rectF.X) / 2, rectF.Y + 30));
                }
            }
            else if (_isLegendFloat && _curves != null)
            {
                if (_showLegend)
                {
                    DrawLegend(g, new RectangleF(OriginRect.Left + 10 + (int)leftoff, OriginRect.Top + _topOffSet + 5, OriginRect.Width - 20, 200), 0);
                }
            }
            if (_isDrawBottomLine)
            {
                Font font = new Font("宋体", 9);//ScaleValueFont;
                g.FillRectangle(backBrush, new RectangleF(OriginRect.Left + 2, OriginRect.Bottom - g.MeasureString("A", font).Height,
                    rect.Left - OriginRect.Left - 4, g.MeasureString("A", font).Height));
                g.DrawLine(borderPen, OriginRect.Left + 1, OriginRect.Bottom - 1, rect.Left, OriginRect.Bottom - 1);
                g.DrawLine(borderPen, OriginRect.Right - 1, OriginRect.Bottom - 1, rect.Right, OriginRect.Bottom - 1);
                RectangleF rectF = GetMainRect();
                float axisWidth = rectF.Left / _yAxises.Count;
                for (int i = 0; i < _yAxises.Count; i++)
                {
                    string scaleValueText = _yAxises[i].ScaleValues[0].ShowText;
                    if (string.IsNullOrEmpty(scaleValueText))
                    {
                        scaleValueText = _yAxises[i].ScaleValues[0].Value.ToString();
                    }
                    using (Brush tempBrush = new SolidBrush(_scaleValueColor))
                    {
                        g.DrawString(scaleValueText, font, tempBrush, rectF.X - i * axisWidth - 5 - g.MeasureString(scaleValueText, font).Width
                            , OriginRect.Bottom - g.MeasureString("A", font).Height);
                    }
                }
                font.Dispose();
            }
            backBrush.Dispose();
            borderPen.Dispose();
            borderWidthPen.Dispose();

            if (IsShowBloodGas)
            {
                DrawBloodGas(g);
            }
            DrawEvents(g);
            DrawDisplayTexts(g);
            if (_drawRightBottom)
            {
                using (Pen pen = new Pen(_borderColor))
                {
                    g.DrawLine(pen, rect.Right, OriginRect.Bottom - 1, OriginRect.Right, OriginRect.Bottom - 1);
                }
                // g.DrawLine(Pens.Red, rect.Right, OriginRect.Bottom - 1, OriginRect.Right, OriginRect.Bottom - 1);
            }

            if (_curves != null)
            {
                for (int index = 0; index < _curves.Count; index++)
                {
                    if (_curves[index].Color == Color.White) continue;
                    DrawCurve(g, index);
                }
            }
            DrawTitle(g, OriginRect.X, OriginRect.Y, OriginRect);
            PaintEventHandler eventHandle = Events[_customDraw] as PaintEventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, new PaintEventArgs(g, ClientRectangle));
            }

            _lockMouse = lockMouse;
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

        private float _breathDigitsYOffset = 50;
        [DisplayName("纵向呼吸参数顶部")]
        public float BreathDigitsYOffset
        {
            get
            {
                return _breathDigitsYOffset;
            }
            set
            {
                _breathDigitsYOffset = value;
            }
        }

        private Font _breathDigitsFont = new Font("宋体", 6.75f);
        [DisplayName("纵向呼吸参数字体")]
        public Font BreathDigitsFont
        {
            get
            {
                return _breathDigitsFont;
            }
            set
            {
                _breathDigitsFont = value;
            }
        }

        private bool _drawBreathDigits = false;
        [DisplayName("纵向绘制呼吸参数值")]
        public bool DrawBreathDigits
        {
            get
            {
                return _drawBreathDigits;
            }
            set
            {
                _drawBreathDigits = value;
            }
        }

        private void DrawControlBreathParaLegend(Graphics g, PointF pointF)
        {
            if (!string.IsNullOrEmpty(_breathParaName1) && !string.IsNullOrEmpty(_breathParaName2) && !string.IsNullOrEmpty(_breathParaName3))
            {
                DrawControlBreathPara(g, Pens.Black, _legendFont, Brushes.Black, pointF, 5
                    , new List<string>(new string[] { _breathParaName1, _breathParaName2, _breathParaName3 }));
            }
        }

        private void DrawControlBreathPara(Graphics g, Pen pen, Font font, Brush brush, PointF pointF, float lineLength, MedVitalSignBreathControlTime breathControlTime)
        {
            DrawControlBreathPara(g, pen, font, brush, pointF, lineLength, breathControlTime.list);
        }

        private void DrawControlBreathPara(Graphics g, Pen pen, Font font, Brush brush, PointF pointF, float lineLength, List<string> list)
        {
            g.DrawLine(pen, pointF.X, pointF.Y - lineLength, pointF.X, pointF.Y);
            string text = list[1];
            g.DrawString(text, font, brush, pointF.X - g.MeasureString(text, font).Width / 2, pointF.Y - lineLength - g.MeasureString(text, font).Height);
            float lineLength1 = lineLength * (float)Math.Tan(Math.PI / 4);
            g.DrawLine(pen, pointF.X, pointF.Y, pointF.X - lineLength1, pointF.Y + lineLength1);
            text = list[0];
            g.DrawString(text, font, brush, pointF.X - lineLength1 - g.MeasureString(text, font).Width, pointF.Y + lineLength1);
            g.DrawLine(pen, pointF.X, pointF.Y, pointF.X + lineLength1, pointF.Y + lineLength1);
            text = list[2];
            g.DrawString(text, font, brush, pointF.X + lineLength1, pointF.Y + lineLength1);
        }

        private void DrawControlBreathParaDight(Graphics g, Pen pen, Font font, Brush brush, PointF pointF, float lineLength, List<string> list)
        {
            float top = _breathDigitsYOffset;
            string text = _breathParaName1 + "=" + list[0];
            g.DrawString(text, _breathDigitsFont, brush, pointF.X /*- g.MeasureString(text, font).Width / 2*/, top);
            top += g.MeasureString(text, _breathDigitsFont).Height;
            text = _breathParaName2 + "=" + list[1];
            g.DrawString(text, _breathDigitsFont, brush, pointF.X/* - g.MeasureString(text, font).Width / 2*/, top);
            top += g.MeasureString(text, _breathDigitsFont).Height;
            text = _breathParaName3 + "=" + list[2];
            g.DrawString(text, _breathDigitsFont, brush, pointF.X/* - g.MeasureString(text, font).Width / 2*/, top);
        }

        private void DrawEvents(Graphics g)
        {
            if (_events == null || _events.Count == 0)
            {
                return;
            }
            _eventRects.Clear();
            RectangleF rectF = GetMainRect();
            float left = rectF.X;
            float oldLeft = float.NaN;
            float maxHeight = 0;
            foreach (EventItem item in _events)
            {
                float width = g.MeasureString(item.EventName, _bloodGasFont).Width;
                if (width > maxHeight)
                {
                    maxHeight = width;
                }
            }
            float top = rectF.Bottom - maxHeight - 3;
            foreach (EventItem item in _events)
            {
                left = GetX(item.StartTime, rectF);
                if (!left.Equals(float.NaN))
                {
                    if (item.EventName.Equals("有创") || item.EventName.Equals("无创"))
                    {
                        DrawRotateString(g, item.EventName, _bloodGasFont, Brushes.Blue, left, rectF.Top + 5, rectF);
                    }
                    else
                    {
                        if (!oldLeft.Equals(float.NaN) && left < oldLeft + 7f)
                        {
                            left = oldLeft + 7f;
                        }
                        DrawRotateString(g, item.EventName, _bloodGasFont, Brushes.Blue, left, top, rectF);
                    }
                }
                oldLeft = left;
                if (!_eventRects.ContainsKey(item))
                {
                    _eventRects.Add(item, new RectangleF(left, top, g.MeasureString("妞", _bloodGasFont).Width, g.MeasureString(item.EventName, _bloodGasFont).Width));
                }
            }
        }

        private void DrawRotateString(Graphics g, string text, Font font, Brush brush, float x, float y, RectangleF rectF)
        {
            float top = y;

            float left;
            if (x <= rectF.X)
            {
                left = x;
            }
            else if (x >= rectF.Right)
            {
                left = x - g.MeasureString("妞", font).Width;
            }
            else
            {
                left = x - g.MeasureString("妞", font).Width / 2;
            }
            List<TextItem> list = GetRotateList(text);
            foreach (TextItem item in list)
            {
                if (!item.IsChinese)
                {
                    g.RotateTransform(90);
                    g.DrawString(item.Text, font, brush, top, 1 - g.MeasureString("妞", font).Width - left);
                    g.RotateTransform(-90);
                    top += g.MeasureString(item.Text, font).Width;
                }
                else
                {
                    g.DrawString(item.Text, font, brush, left, top);
                    top += g.MeasureString(item.Text, font).Height - 1;
                }
            }
        }

        private List<TextItem> GetRotateList(string text)
        {
            List<TextItem> list = new List<TextItem>();
            string wString = "";
            for (int i = 0; i < text.Length; i++)
            {
                string s = text.Substring(i, 1);
                if (StringManage.IsChinese(s))
                {
                    if (!string.IsNullOrEmpty(wString))
                    {
                        list.Add(new TextItem(wString));
                        wString = "";
                    }
                    list.Add(new TextItem(s, true));
                }
                else
                {
                    wString += s;
                }
            }
            if (!string.IsNullOrEmpty(wString))
            {
                list.Add(new TextItem(wString));
            }
            return list;
        }

        private void DrawDisplayTexts(Graphics g)
        {
            RectangleF rectF = GetMainRect();
            foreach (MedVitalSignCurve curve in _curves)
            {
                if (!string.IsNullOrEmpty(curve.DisplayText) && curve.Points.Count > 0)
                {
                    foreach (MedVitalSignPoint point in curve.Points)
                    {
                        double d = 0;
                        if (!double.TryParse(point.Value.ToString(), out d))
                        {
                            d = 0;
                        }
                        if (d > 0)
                        {
                            float x = GetX(point.Time);
                            DrawRotateString(g, curve.DisplayText, _legendFont, Brushes.Blue, x, _topOffSet, rectF);
                            break;
                        }
                    }
                }
            }
        }

        private Dictionary<BloodGasMaster, RectangleF> _bloodGasRects = new Dictionary<BloodGasMaster, RectangleF>();

        private void DrawBloodGas(Graphics g)
        {
            if (_bloodGasItems == null || _bloodGasItems.Count == 0)
            {
                _bloodGasRects.Clear();
                return;
            }
            RectangleF rectF = GetMainRect();
            float left = rectF.X;
            float top = rectF.Y;
            _bloodGasRects.Clear();
            int digitCount = 0;
            foreach (MedVitalSignCurve curve in _curves)
            {
                if (curve.IsDigit)
                {
                    digitCount++;
                }
            }
            foreach (BloodGasMaster item in _bloodGasItems)
            {
                left = GetX(item.Recorddate, rectF);
                if (left.Equals(float.NaN))
                { continue; }
                top = rectF.Y + digitCount * g.MeasureString("A", new Font("宋体", 9)).Height;
                RectangleF rect = new RectangleF();
                rect.X = left;
                rect.Y = top;
                g.DrawString(item.DisplayName, _bloodGasFont, Brushes.Blue, left, top + 3);
                float width = g.MeasureString(item.DisplayName, _bloodGasFont).Width;
                top += g.MeasureString("A", _bloodGasFont).Height + 2;
                foreach (BloodGasDetail detail in item.Details)
                {
                    //Modify @2014-02-14,无数据的血气项不显示
                    if (!string.IsNullOrEmpty(detail.BloodGasValue))
                    {
                        string drawText = detail.BloodGasName + "=" + detail.BloodGasValue;
                        if (_isShowBloodGasUnit)
                            drawText += " " + GetBloodGasUnit(detail.BloodGasCode);

                        g.DrawString(drawText, _bloodGasFont, Brushes.Blue, left, top);
                        top += g.MeasureString("A", _bloodGasFont).Height - 1;
                        float w = g.MeasureString(drawText, _bloodGasFont).Width;
                        if (w > width)
                        {
                            width = w;
                        }
                    }
                    //End Modify
                }
                rect.Height = top - rect.Y;
                rect.Width = width;
                if (!_bloodGasRects.ContainsKey(item))
                {
                    _bloodGasRects.Add(item, rect);
                }
            }
        }

        // 获取血气记录的单位
        string GetBloodGasUnit(string itemcode)
        {
            //DataTable dt =ExtendAppContext.Current.CodeTables["MED_BLOOD_GAS_DICT"];
            //DataRow [] rows = dt.Select("BLG_CODE='" + itemcode + "'");
            //if (rows.Length > 0)
            //    return rows[0].IsNull("BLG_UNIT")?"":rows[0]["BLG_UNIT"].ToString();
            //else
            return "";
        }


        public void DrawEventMarks(Graphics g)
        {
            RectangleF rect = GetMainRect();
            float x, oldX = 0;
            float baseY = rect.Bottom + _eventMarkHeight - g.MeasureString("A", _eventMark.Font).Height;
            float y = baseY, oldY = baseY;
            using (Brush eventMarkBrush = new SolidBrush(_eventMark.Color))
            {
                g.DrawString(_eventMark.Title, _eventMark.Font, eventMarkBrush, (rect.X - g.MeasureString(_eventMark.Title, _eventMark.Font).Width) / 2, y);
            }
            //int index = 0;
            for (int i = 0; i < _eventMark.Points.Count; i++)
            {
                x = GetX(_eventMark.Points[i].TimePoint, rect);
                if (x.Equals(float.NaN))
                { continue; }
                float xx = 0;
                if (_eventMark.Points[i].Index > 0)
                {
                    xx = (g.MeasureString(_eventMark.Points[i].Index.ToString(), _eventMark.Font).Width - 2);
                }
                else
                {
                    xx = _eventMark.Points[i].Symbol.Size;
                }
                if ((x + xx) > rect.Right)
                {
                    x = rect.Right - xx;
                }
                if (System.Math.Abs(x - oldX) < xx)
                {
                    oldY -= (_eventMark.Points[i].Index > 0) ? g.MeasureString("A", _eventMark.Font).Height - 4 : _eventMark.Points[i].Symbol.Size + 2;//_eventMarkHeight;
                }
                else
                {
                    oldY = y;
                    oldX = x;
                }
                _eventMark.Points[i].Y = oldY;
                _eventMark.Points[i].X = x;
                if (_eventMark.Points[i].Y == baseY && _eventMark.Points[i].Symbol != null)
                {
                    _eventMark.Points[i].Y += 4;
                    oldY += 4;
                }
                if (_eventMark.Points[i].X < rect.Right)
                {
                    if (_eventMark.Points[i].Y < baseY)
                    {
                        _eventMark.Points[i].Y = _eventMark.Points[i].Y - _eventOffSet;
                    }
                    _eventMark.DrawPoint(g, i, _eventMark.Points[i].X, _eventMark.Points[i].Y);
                }
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
                int index = 0;
                while (x + gridWidth - 5 < rectF.Right)
                {
                    if (_yAxisBorderType == YAxisBorderType.BottomLine && _topOffSet > 0)
                    {
                        g.DrawLine(pen, x, rectF.Top, x, rectF.Bottom);
                    }
                    else
                    {
                        g.DrawLine(pen, x, rectF.Top + _topOffSet, x, rectF.Bottom);
                    }
                    DrawMinGrid(g, new RectangleF(x, rectF.Top + _topOffSet, gridWidth, rectF.Height - _topOffSet), index++);
                    x += gridWidth;
                }
                DrawMinGrid(g, new RectangleF(x, rectF.Top + _topOffSet, gridWidth, rectF.Height - _topOffSet), index);
            }
        }

        private void DrawMinGrid(Graphics g, RectangleF rectF, int index)
        {
            float minGridWidth = rectF.Width / _minScaleCount;
            Color color = MinScaleColor;
            if (_isPrinting)
            {
                color = _printColor;
            }
            using (Pen pen = new Pen(color))// _minScaleWidth))
            {
                Font font = new Font("宋体", 9);
                Brush brush = new SolidBrush(color);
                pen.DashStyle = _minDashStyle;
                int mu = (int)(GetGridMinutes() / _minScaleCount);
                DateTime dt = _startTime;
                dt = dt.AddMinutes(index * mu * _minScaleCount);
                for (int i = 1; i < _minScaleCount; i++)
                {
                    if (rectF.X + minGridWidth * i - rectF.Width > ClientRectangle.Right - 1) break;
                    if (_yAxisBorderType == YAxisBorderType.BottomLine && _topOffSet > 0)
                    {
                        g.DrawLine(pen, rectF.X + minGridWidth * i - rectF.Width, rectF.Top - _topOffSet, rectF.X + minGridWidth * i - rectF.Width, rectF.Bottom);
                    }
                    else
                    {
                        g.DrawLine(pen, rectF.X + minGridWidth * i - rectF.Width, rectF.Top, rectF.X + minGridWidth * i - rectF.Width, rectF.Bottom);
                    }
                    dt = dt.AddMinutes(mu);
                    if (_isDrawBottomLine && g.MeasureString(dt.ToString("HH:mm"), font).Width < minGridWidth)
                    {
                        g.DrawString(dt.ToString("HH:mm"), Font, brush, rectF.X + minGridWidth * i - rectF.Width
                            - g.MeasureString(dt.ToString("HH:mm"), Font).Width / 2, rectF.Top - g.MeasureString("A", Font).Height);
                    }
                }
                brush.Dispose();
            }
        }

        /// <summary>
        /// 画Y坐标
        /// </summary>
        /// <param name="g"></param>
        private void DrawYAxises(Graphics g)
        {
            float leftoff = string.IsNullOrEmpty(_title) ? 0f : _titleWidth;
            RectangleF rectF = GetMainRect();
            float gridHeight = (rectF.Height - _topOffSet) / (_yAxisScaleCount - 1);
            //Font font = new Font("宋体", 9); //ScaleValueFont;
            Font font = ScaleValueFont;
            ///绘制刻度网格
            Pen pen = new Pen(MinScaleColor, _minScaleWidth);
            pen.DashStyle = _minDashStyle;
            Pen gridPen = new Pen(RowGridColor, _gridLineWidth);
            Brush brush = new SolidBrush(_scaleValueColor);
            for (int i = 0; i < _yAxisScaleCount - 1; i++)
            {

                if (_yAxisBorderType == YAxisBorderType.BottomLine)
                {
                    g.DrawLine(gridPen, rectF.X, rectF.Y + gridHeight * i + _topOffSet, rectF.Right, rectF.Y + gridHeight * i + _topOffSet);
                }
                else if (_yAxisBorderType == YAxisBorderType.TopLine)
                {
                    g.DrawLine(gridPen, rectF.X, rectF.Y + gridHeight * i + _topOffSet, rectF.Right, rectF.Y + gridHeight * i + _topOffSet);
                }
                else
                {
                    g.DrawLine(gridPen, rectF.X, rectF.Y + gridHeight * i + _topOffSet, rectF.Right, rectF.Y + gridHeight * i + _topOffSet);
                }
                if (_minYScaleCount > 1)
                {
                    float minHeight = gridHeight / _minYScaleCount;
                    for (int j = 1; j < _minYScaleCount; j++)
                    {
                        if (_yAxisBorderType == YAxisBorderType.BottomLine)
                        {
                            g.DrawLine(pen, OriginRect.Left + (int)leftoff, rectF.Y + gridHeight * i + _topOffSet + j * minHeight, rectF.Right, rectF.Y + gridHeight * i + _topOffSet + j * minHeight);
                        }
                        else
                        {
                            g.DrawLine(pen, rectF.X, rectF.Y + gridHeight * i + _topOffSet + j * minHeight, rectF.Right, rectF.Y + gridHeight * i + _topOffSet + j * minHeight);
                        }
                    }
                }
            }
            if (_eventMarkHeight > 0)
            {
                if (_yAxisBorderType == YAxisBorderType.BottomLine || _yAxisBorderType == YAxisBorderType.TopLine)
                {
                    g.DrawLine(gridPen, rectF.X, rectF.Y + gridHeight * (_yAxisScaleCount - 1) + _topOffSet, rectF.Right, rectF.Y + gridHeight * (_yAxisScaleCount - 1) + _topOffSet);
                }
                else
                {
                    g.DrawLine(gridPen, rectF.X, rectF.Y + gridHeight * (_yAxisScaleCount - 1) + _topOffSet, rectF.Right, rectF.Y + gridHeight * (_yAxisScaleCount - 1) + _topOffSet);
                }
                g.DrawLine(gridPen, rectF.X, rectF.Y + gridHeight * (_yAxisScaleCount - 1) + _topOffSet, OriginRect.Left
                    , rectF.Y + gridHeight * (_yAxisScaleCount - 1) + _topOffSet);
            }
            if (_yAxises != null)
            {
                int yIndex = 0;
                bool isMoveRight = false;
                if (!string.IsNullOrEmpty(_rightYAxis) && int.TryParse(_rightYAxis, out yIndex))
                {
                    isMoveRight = true;
                    g.FillRectangle(Brushes.White, new Rectangle(OriginRect.Right, OriginRect.Top, RightRetainWidth, OriginRect.Height));
                }
                Color oldColor = _scaleValueColor;
                for (int i = 0; i < _yAxisScaleCount; i++)
                {
                    for (int j = 0; j < _yAxises.Count; j++)
                    {
                        _scaleValueColor = _yAxisColors[j];
                        float axisWidth = (rectF.Left - leftoff) / _yAxises.Count;
                        ///绘制刻度值
                        double scaleValue = _yAxises[j].ScaleValues[_yAxisScaleCount - 1 - i].Value;
                        if (scaleValue >= 0)
                        {
                            string showText = _yAxises[j].ScaleValues[_yAxisScaleCount - 1 - i].ShowText;
                            string scaleValueText;
                            if (showText != null && !showText.Equals(""))
                            {
                                scaleValueText = showText.Replace(@"\r\n", "\r\n");
                            }
                            else
                            {
                                scaleValueText = scaleValue.ToString();
                            }
                            if (_yAxisBorderType == YAxisBorderType.BottomLine)
                            {
                                if (g.MeasureString(scaleValueText, font).Height > g.MeasureString("A", font).Height)
                                {
                                    if (isMoveRight && yIndex == j)
                                    {
                                        g.DrawString(scaleValueText, font, brush, OriginRect.Right + 1, gridHeight * i + _topOffSet
                                            - (gridHeight - g.MeasureString(scaleValueText, font).Height) / 2 - g.MeasureString("A", font).Height);
                                    }
                                    else
                                    {
                                        g.DrawString(scaleValueText, font, brush, rectF.X - j * axisWidth - 5
                                            - (axisWidth + g.MeasureString(scaleValueText, font).Width) / 2, gridHeight * i + _topOffSet
                                            - (gridHeight - g.MeasureString(scaleValueText, font).Height) / 2 - g.MeasureString("A", font).Height);
                                    }
                                }
                                else
                                {
                                    if (isMoveRight && yIndex == j)
                                    {
                                        g.DrawString(scaleValueText, font, brush, OriginRect.Right + 1, gridHeight * i + _topOffSet
                                            - (gridHeight - g.MeasureString(scaleValueText, font).Height) / 2);
                                    }
                                    else
                                    {
                                        g.DrawString(scaleValueText, font, brush, rectF.X - j * axisWidth - 5
                                            - (axisWidth + g.MeasureString(scaleValueText, font).Width) / 2, gridHeight * i + _topOffSet
                                            - (gridHeight - g.MeasureString(scaleValueText, font).Height) / 2);
                                    }
                                }
                            }
                            else if (_yAxisBorderType == YAxisBorderType.TopLine)
                            {
                                if (isMoveRight && yIndex == j)
                                {
                                    g.DrawString(scaleValueText, font, brush, OriginRect.Right + 1, gridHeight * i + _topOffSet - g.MeasureString("A", font).Height / 2 + 1);
                                }
                                else
                                {
                                    g.DrawString(scaleValueText, font, brush, rectF.X - j * axisWidth - 5 - g.MeasureString(scaleValueText, font).Width
                                        , gridHeight * i + _topOffSet - g.MeasureString("A", font).Height / 2 + 1);
                                }
                            }
                            else
                            {
                                if (_yAxises.Count == 1)
                                {
                                    //g.DrawString(scaleValueText, font, brush, OriginRect.X + 1, gridHeight * i + _topOffSet - g.MeasureString(scaleValueText, font).Height / 2);
                                    g.DrawString(scaleValueText, font, brush, rectF.X - j * axisWidth - 5 - g.MeasureString(scaleValueText, font).Width, gridHeight * i + _topOffSet - g.MeasureString(scaleValueText, font).Height / 2);
                                }
                                else
                                {
                                    if (i == 0 && _topOffSet < 1)
                                    {
                                        if (isMoveRight && yIndex == j)
                                        {
                                            g.DrawString(scaleValueText, font, brush, OriginRect.Right + 1, _topOffSet);
                                        }
                                        else
                                        {
                                            g.DrawString(scaleValueText, font, brush, rectF.X - j * axisWidth - 5 - g.MeasureString(scaleValueText, font).Width, _topOffSet);
                                        }
                                    }
                                    else if (i == _yAxisScaleCount - 1)
                                    {
                                        if (isMoveRight && yIndex == j)
                                        {
                                            g.DrawString(scaleValueText, font, brush, OriginRect.Right + 1, gridHeight * i + _topOffSet - g.MeasureString(scaleValueText, font).Height);
                                        }
                                        else
                                        {
                                            g.DrawString(scaleValueText, font, brush, rectF.X - j * axisWidth - 5 - g.MeasureString(scaleValueText, font).Width, gridHeight * i + _topOffSet - g.MeasureString(scaleValueText, font).Height);
                                        }
                                    }
                                    else
                                    {
                                        if (isMoveRight && yIndex == j)
                                        {
                                            g.DrawString(scaleValueText, font, brush, OriginRect.Right + 1, gridHeight * i + _topOffSet - g.MeasureString(scaleValueText, font).Height / 2);
                                        }
                                        else
                                        {
                                            g.DrawString(scaleValueText, font, brush, rectF.X - j * axisWidth - 5 - g.MeasureString(scaleValueText, font).Width, gridHeight * i + _topOffSet - g.MeasureString(scaleValueText, font).Height / 2);
                                        }
                                    }
                                }
                            }
                        }
                        ///绘制单位
                        if (i == 1)
                        {
                            if (_yAxises[j].Unit != null)
                            {
                                g.DrawString(_yAxises[j].Unit, font, brush, rectF.X - j * axisWidth - 5 - g.MeasureString(_yAxises[j].Unit, font).Width, _topOffSet + 2);
                            }
                        }
                    }
                    ///绘制刻度值边框
                    if (_yAxisBorderType != YAxisBorderType.None)
                    {
                        Rectangle rect = new Rectangle(ClientRectangle.X + 5 + (int)leftoff, (int)(gridHeight * i + _topOffSet - g.MeasureString("A", font).Height / 2 - 2), (int)rectF.X - ClientRectangle.X - 10, (int)g.MeasureString("A", font).Height + 4);
                        if (_yAxisBorderType == YAxisBorderType.RountRect)
                        {
                            GraphHelper.DrawRoundRect(g, rect, 5, _yAxisBorderColor, _yAxisBorderWidth);
                        }
                        else if (_yAxisBorderType == YAxisBorderType.Rect)
                        {
                            using (Pen yAxisPen = new Pen(_yAxisBorderColor, _yAxisBorderWidth))
                            {
                                g.DrawRectangle(pen, rect);
                            }
                        }
                    }
                }
                _scaleValueColor = oldColor;
            }
            pen.Dispose();
            gridPen.Dispose();
            brush.Dispose();
        }

        private List<Color> _yAxisColors = new List<Color>(new Color[] { Color.Black, Color.Black, Color.Black, Color.Black, Color.Black });
        [Browsable(false)]
        public List<Color> YAxisColors
        {
            get
            {
                return _yAxisColors;
            }
            set
            {
                _yAxisColors = value;
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern int SetTextCharacterExtra(
        IntPtr hdc, // handle to DC 
        int nCharExtra // extra-space value 
        );

        public void DrawString(string text, Graphics g, PointF startPoint, Font font, Brush brush, int sepDist)
        {
            IntPtr hdc = g.GetHdc();
            SetTextCharacterExtra(hdc, sepDist);//设置字符间距 
            g.ReleaseHdc(hdc);

            //绘制 
            g.DrawString(text, font, brush, startPoint.X, startPoint.Y);
        }

        private void DrawStringEx(string text, Graphics g, PointF startPoint, Font font, Brush brush, float sepDist)
        {
            PointF pf = startPoint;
            SizeF charSize;
            char[] ch = text.ToCharArray();

            foreach (char c in ch)
            {
                charSize = g.MeasureString(c.ToString(), font);
                g.DrawString(c.ToString(), font, brush, pf);
                pf.X += (charSize.Width + sepDist);
                if (c.Equals('.')) pf.X -= 3;
            }
        }

        private void DrawDigit(Graphics g, int index)
        {
            using (Brush brush = new SolidBrush(_curves[index].Color))
            {
                Font font = new Font("宋体", 9);
                if (_isDigitTop)
                {
                    int idx = 0;
                    if (!_digitIndex.ContainsKey(_curves[index].Text))
                    {
                        _digitIndex.Add(_curves[index].Text, _digitIndex.Count);
                        idx = _digitIndex.Count - 1;
                    }
                    else
                    {
                        idx = _digitIndex[_curves[index].Text];
                    }
                    float rowHeight = g.MeasureString("A", font).Height;
                    RectangleF rectF = GetMainRect();
                    //写曲线名称
                    if (_curves[index].IsDigit && _curves[index].Points.Count > 0)
                    {
                        if (TimeAxisPositionType == TimeAxisPositionType.Top)
                        {
                            g.DrawString(_curves[index].Text, font, brush, rectF.Left - g.MeasureString(_curves[index].Text, font).Width, rectF.Top + (idx + 1) * rowHeight);
                        }
                        else
                        {
                            g.DrawString(_curves[index].Text, font, brush, rectF.Left - g.MeasureString(_curves[index].Text, font).Width, rectF.Top + idx * rowHeight);
                        }
                    }

                    foreach (MedVitalSignPoint point in _curves[index].Points)
                    {
                        point.X = GetX(point.Time, rectF);
                        if (point.X.Equals(float.NaN))
                        { continue; }
                        point.Y = rectF.Top + idx * rowHeight;
                        if (_topOffSet > 0 && _yAxisBorderType == YAxisBorderType.None)
                        {
                            point.Y += _topOffSet;
                        }
                        double d = 0;
                        if (!double.TryParse(point.Value.ToString(), out d))
                        {
                            d = -3;
                        }
                        if ((d != 0 || d == -3) && point.Time >= _startTime && point.Time < _endTime)
                        {
                            string text = "";
                            if (d > 0)
                            {
                                text = d.ToString(string.Format("F{0}", _curves[index].DotNumber));
                            }
                            else
                            {
                                text = point.Value.ToString();
                            }
                            if (text.EndsWith(".0")) text = text.Replace(".0", "");
                            if (text.EndsWith(".00")) text = text.Replace(".00", "");
                            if (text.Contains("."))
                            {
                                DrawStringEx(text, g, new PointF(point.X, point.Y), Font, brush, -5.2f);
                            }
                            else
                            {
                                g.DrawString(text, font, brush, point.X, point.Y);
                            }
                        }
                    }

                }
                else
                {
                    int idx = 0;
                    if (!_digitIndex.ContainsKey(_curves[index].Text))
                    {
                        _digitIndex.Add(_curves[index].Text, _digitIndex.Count);
                        idx = _digitIndex.Count - 1;
                    }
                    else
                    {
                        idx = _digitIndex[_curves[index].Text];
                    }
                    float rowHeight = g.MeasureString("A", Font).Height;
                    _eventOffSet = _digitIndex.Count * rowHeight;
                    RectangleF rectF = GetMainRect();
                    foreach (MedVitalSignPoint point in _curves[index].Points)
                    {
                        point.X = GetX(point.Time, rectF);
                        if (point.X.Equals(float.NaN))
                        { continue; }
                        point.Y = rectF.Bottom - (idx + 1) * rowHeight;
                        double d = 0;
                        if (!double.TryParse(point.Value.ToString(), out d))
                        {
                            d = 0;
                        }
                        if (d > 0)
                        {
                            g.DrawString(d.ToString(string.Format("F{0}", _curves[index].DotNumber)), Font, brush, point.X, point.Y);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 画曲线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="index"></param>
        private void DrawCurve(Graphics g, int index)
        {
            ///绘制数字
            if (_curves[index].IsDigit)
            {
                DrawDigit(g, index);
            }
            else
            {
                ///绘制曲线
                MeasureCurve(g, index, new Point());
            }
        }

        public float GetX(DateTime timePoint)
        {
            RectangleF rectF = GetMainRect();
            TimeSpan spThis, spTotal;
            spThis = timePoint - _startTime;
            spTotal = _endTime - _startTime;
            if (spTotal.Ticks <= 0)// || spThis.TotalSeconds > spTotal.TotalSeconds)
            {
                return float.NaN;
            }
            else if (spThis.Ticks <= 0)
            {
                return rectF.X;
            }
            else if (spThis.TotalSeconds > spTotal.TotalSeconds)
            {
                return rectF.Right;
            }
            else
            {
                return (float)(rectF.X + rectF.Width * (spThis.TotalSeconds / spTotal.TotalSeconds));
            }
        }

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

        private DateTime GetTimePoint(float x, RectangleF rectF)
        {
            TimeSpan spTotal = _endTime - _startTime;
            return _startTime.AddSeconds(((double)(x - rectF.X) / rectF.Width) * spTotal.TotalSeconds);
        }

        private bool IsBreathControl(MedVitalSignPoint point)
        {
            if (point.Curve.Text.Contains("呼吸"))
            {
                if (_breathControlTime != null && _breathControlTime.Count > 0)
                {
                    DateTime startTime = _breathControlTime[0];
                    DateTime endTime = startTime.AddHours(48);
                    if (_breathControlTime.Count > 1)
                    {
                        endTime = _breathControlTime[1];
                        if (endTime < startTime)
                        {
                            startTime = _breathControlTime[1];
                            endTime = _breathControlTime[0];
                        }
                    }
                    if (point.Time >= startTime && point.Time <= endTime)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        /// <summary>
        /// 处理呼吸事件
        /// </summary>
        /// <param name="point"></param>
        /// <returns>0，自由呼吸1  辅助呼吸2 ，1控制呼吸，-1</returns>
        private MedVitalSignBreathControlTime DoBreathControl(MedVitalSignPoint point)
        {
            if (!point.Curve.Text.Contains("呼吸"))
            {
                return null;
            }
            if (_breathControlTimeList != null && BreathControlTimeList.Count == 0)
            {
                return null;
            }
            if (point.Curve.Text.Contains("呼吸"))
            {


                for (int i = 0; i < BreathControlTimeList.Count; i++)
                {
                    MedVitalSignBreathControlTime breathControlTime = BreathControlTimeList[i];
                    if (point.Time >= breathControlTime.startTime.AddSeconds(0-breathControlTime.startTime.Second) && point.Time <= breathControlTime.endTime.AddSeconds(0 - breathControlTime.startTime.Second))
                    {
                        return breathControlTime;
                    }

                }
            }

            return null;
        }

        public class BreathPara
        {
            public string Para1, Para2, Para3;
        }

        private Dictionary<DateTime, BreathPara> _breathParalList = new Dictionary<DateTime, BreathPara>();
        public Dictionary<DateTime, BreathPara> BreathParalList
        {
            get
            {
                return _breathParalList;
            }
            set
            {
                _breathParalList = value;
            }
        }

        /// <summary>
        /// 测量曲线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="index">曲线索引</param>
        /// <param name="pt">鼠标位置</param>
        /// <returns>点索引</returns>
        private int MeasureCurve(Graphics g, int index, Point pt)
        {
            MedVitalSignCurve curve = _curves[index];
            Rectangle rect = ClientRectangle;
            RectangleF rectF = GetMainRect();
            float gridHeight = (rectF.Height - _topOffSet) / (_yAxisScaleCount - 1);
            float x0 = -1, y0 = -1;

            if (curve.YAxisIndex >= _yAxises.Count) curve.YAxisIndex = _yAxises.Count - 1;
            float oldSize = curve.Symbol.Size;
            if (Width < Screen.PrimaryScreen.Bounds.Width)
            {
                int scal = (int)(Screen.PrimaryScreen.Bounds.Width / Width);
                curve.Symbol.Size = oldSize / (float)System.Math.Sqrt(scal);
            }
            curve.Symbol.Size = _curveSymbolSize;

            Pen bluePen = new Pen(Color.Blue, 2);
            Pen blackPen = new Pen(Color.Black, 1.5f);
            Pen curvePen = new Pen(curve.Color);
            Pen ModifyPen = new Pen(Color.Red, 2f);
            // MedVitalSignPoint pointOld = new MedVitalSignPoint();

            ///绘制曲线的点
            for (int k = 0; k < curve.Points.Count; k++)
            {
                MedVitalSignPoint point = curve.Points[k];

                double d1 = 0;
                if (!double.TryParse(point.Value.ToString(), out d1))
                {
                    d1 = 0;
                }

                if (d1 <= 0)
                {
                    x0 = -1;
                    y0 = -1;
                    continue;
                }
                point.X = GetX(point.Time, rectF);
                if (point.X.Equals(float.NaN))
                {
                    continue;
                }
                List<MedVitalSignYAxisScaleValue> scaleValues = _yAxises[curve.YAxisIndex].ScaleValues;
                for (int i = 0; i < scaleValues.Count - 1; i++)
                {
                    double d2 = 0;
                    if (!double.TryParse(point.Value.ToString(), out d2))
                    {
                        d2 = 0;
                    }
                    if (d2 >= scaleValues[i].Value && d2 <= scaleValues[i + 1].Value)
                    {
                        if (d2 == scaleValues[i].Value)
                        {
                            point.Y = rectF.Y + gridHeight * (_yAxisScaleCount - 1 - i) + _topOffSet;
                        }
                        else if (d2 == scaleValues[i + 1].Value)
                        {
                            point.Y = rectF.Y + gridHeight * (_yAxisScaleCount - 1 - i - 1) + _topOffSet;
                        }
                        else
                        {
                            double d = 0;
                            if (!double.TryParse(point.Value.ToString(), out d))
                            {
                                d = 0;
                            }

                            point.Y = (float)(rectF.Y + gridHeight * (_yAxisScaleCount - 1 - i) + _topOffSet - gridHeight * (d - scaleValues[i].Value) / (scaleValues[i + 1].Value - scaleValues[i].Value));
                        }
                        MedVitalSignBreathControlTime breathControlTime = null;
                        ///只在准5分钟的点上绘制标识
                        if (!_onlyShowFiveMinute || point.Time.Minute % 5 == 0)
                        {
                            breathControlTime = DoBreathControl(point);
                            if (breathControlTime != null && breathControlTime.BreathType == BreathControlType.ControlBreath)//控制呼吸
                            {

                                //MedSymbol symbol = new MedSymbol(MedSymbolType.Text);
                                //symbol.Text = "C";
                                MedSymbol symbol = new MedSymbol(MedSymbolType.None);

                                using (Pen breathPen = new Pen(breathControlTime.curveColor))
                                {
                                    //symbol.Pen = curve.Symbol.Pen;
                                    symbol.Pen = breathPen;
                                    symbol.Draw(g, point.X, point.Y);

                                    //if (point.Time.Equals(breathControlTime.startTime) && breathControlTime.list != null && breathControlTime.list.Count == 3)
                                    //if (breathControlTime.list != null && breathControlTime.list.Count == 3)
                                    if (_breathParalList != null && _breathParalList.ContainsKey(point.Time))
                                    {
                                        if (!string.IsNullOrEmpty(_breathParalList[point.Time].Para1) && !string.IsNullOrEmpty(_breathParalList[point.Time].Para2) && !string.IsNullOrEmpty(_breathParalList[point.Time].Para3))
                                        {
                                            if (_drawBreathDigits)
                                            {
                                                DrawControlBreathParaDight(g, symbol.Pen, new Font("宋体", 6.75f), new SolidBrush(curve.Color), new PointF(point.X, point.Y - 25), 5
                                                    , new List<string>(new string[] { _breathParalList[point.Time].Para1, _breathParalList[point.Time].Para2, _breathParalList[point.Time].Para3 }));//, breathControlTime);
                                            }
                                            else
                                            {
                                                DrawControlBreathPara(g, symbol.Pen, new Font("宋体", 6.75f), new SolidBrush(curve.Color), new PointF(point.X, point.Y - 25), 5
                                                    , new List<string>(new string[] { _breathParalList[point.Time].Para1, _breathParalList[point.Time].Para2, _breathParalList[point.Time].Para3 }));//, breathControlTime);
                                            }
                                        }
                                    }
                                }

                            }
                            else if (breathControlTime != null && breathControlTime.BreathType == BreathControlType.HelpBreath)//辅助呼吸
                            {
                                MedSymbol symbol = new MedSymbol(MedSymbolType.Text);
                                symbol.Text = "A";
                                using (Pen breathPen = new Pen(breathControlTime.curveColor))
                                {
                                    symbol.Pen = breathPen;
                                    //symbol.Pen = curve.Symbol.Pen;
                                    symbol.Draw(g, point.X, point.Y);
                                }

                            }
                            else
                            {
                                if (_isPrinting && _isPrintSingleCurveColor)
                                {
                                    Brush symbolBrush = curve.Symbol.Brush;
                                    Pen symbolPen = curve.Symbol.Pen;
                                    curve.Symbol.Pen = Pens.Black;
                                    curve.Symbol.Brush = Brushes.Black;
                                    curve.Symbol.Draw(g, point.X, point.Y);
                                    curve.Symbol.Brush = symbolBrush;
                                    curve.Symbol.Pen = symbolPen;
                                }
                                else
                                {


                                    if (!_printing && curve.CurveType == VitalSignCurveType.LineAndPoints && point.IsModify)
                                    {

                                        Pen symbolPen = curve.Symbol.Pen;
                                        if (curve.Symbol.Pen.Color.Equals(ModifyPen.Color))
                                        {
                                            ModifyPen.Color = Color.Brown;
                                        }

                                        curve.Symbol.Pen = ModifyPen;
                                        curve.Symbol.Draw(g, point.X, point.Y);
                                        curve.Symbol.Pen = symbolPen;

                                    }
                                    else
                                    {
                                        curve.Symbol.Draw(g, point.X, point.Y);
                                    }

                                }
                            }
                        }
                        if (curve.CurveType == VitalSignCurveType.LineAndPoints)
                        {


                            if (x0 != -1 || y0 != -1)
                            {
                                if (k >= 1)
                                {
                                    //如果间距差超过1个刻度，则不画连线
                                    //if (point.Time > curve.Points[k - 1].Time.AddMinutes(6) )
                                    if (point.Time > curve.Points[k - 1].Time.AddMinutes(curve.LineMaxscale))
                                    {
                                        x0 = point.X;
                                        y0 = point.Y;
                                        continue;
                                    }
                                }


                                if (point.IsKzhx)
                                {
                                    g.DrawLine(bluePen, point.X, point.Y, x0, y0);
                                }
                                else
                                {
                                    if (_isPrinting && _isPrintSingleCurveColor)
                                    {
                                        g.DrawLine(blackPen, point.X, point.Y, x0, y0);
                                    }
                                    else
                                    {

                                        //呼吸特殊处理
                                        if (breathControlTime != null && (breathControlTime.BreathType == BreathControlType.ControlBreath || breathControlTime.BreathType == BreathControlType.HelpBreath))//呼吸处理
                                        {
                                            using (Pen breathPen = new Pen(breathControlTime.curveColor))
                                            {
                                                g.DrawLine(breathPen, point.X, point.Y, x0, y0);
                                            }
                                        }
                                        else
                                        {
                                            g.DrawLine(curvePen, point.X, point.Y, x0, y0);
                                        }



                                    }
                                }
                            }
                            x0 = point.X;
                            y0 = point.Y;
                        }

                        //找到之后退出20120929
                        break;
                    }
                    else if (d2 > scaleValues[scaleValues.Count - 1].Value)//超过坐标轴范围
                    {
                        #region "超过坐标部分绘图"
                        int ii = scaleValues.Count - 1;
                        point.Y = (float)(rectF.Y + gridHeight * (_yAxisScaleCount - 1 - ii) + _topOffSet) + 2;
                        using (Brush brush = new SolidBrush(curve.Color))
                        {
                            using (Font font = new Font("宋体", 9))
                            {
                                g.DrawString(d2.ToString(), font, brush, point.X, point.Y);
                            }
                        }


                        if (curve.CurveType == VitalSignCurveType.LineAndPoints)
                        {


                            if (x0 != -1 || y0 != -1)
                            {
                                if (k >= 1)
                                {
                                    //如果间距差超过1个刻度，则不画连线
                                    if (point.Time > curve.Points[k - 1].Time.AddMinutes(curve.LineMaxscale))
                                    {
                                        x0 = point.X;
                                        y0 = point.Y;
                                        continue;
                                    }
                                }
                                if (point.IsKzhx)
                                {
                                    g.DrawLine(bluePen, point.X, point.Y, x0, y0);
                                }
                                else
                                {
                                    if (_isPrinting && _isPrintSingleCurveColor)
                                    {
                                        g.DrawLine(blackPen, point.X, point.Y, x0, y0);
                                    }
                                    else
                                    {

                                        g.DrawLine(curvePen, point.X, point.Y, x0, y0);

                                    }
                                }
                            }
                            x0 = point.X;
                            y0 = point.Y;
                        }

                        //找到之后退出20120929
                        break;
                        #endregion
                    }
                }
            }
            curvePen.Dispose();
            blackPen.Dispose();
            bluePen.Dispose();
            ModifyPen.Dispose();
            curve.Symbol.Size = oldSize;
            return -1;
        }

        private double GetValue(float y1, MedVitalSignCurve curve)
        {
            Rectangle rect = ClientRectangle;
            RectangleF rectF = GetMainRect();
            float gridHeight = (rectF.Height - _topOffSet) / (_yAxisScaleCount - 1);
            List<MedVitalSignYAxisScaleValue> scaleValues = _yAxises[curve.YAxisIndex].ScaleValues;
            int i = (int)((y1 - _topOffSet - rectF.Y - _topOffSet) / gridHeight);
            double result = scaleValues[_yAxisScaleCount - 1 - i].Value - (y1 - _topOffSet - i * gridHeight) / gridHeight * (scaleValues[i + 1].Value - scaleValues[i].Value);
            result = double.Parse(result.ToString(string.Format("F{0}", curve.DotNumber)));
            return result;
        }

        public void DrawLegend(Graphics g, RectangleF rectF)
        {
            DrawLegend(g, rectF, 0);
        }

        /// <summary>
        /// 画图例
        /// </summary>
        /// <param name="g"></param>
        /// <param name="index"></param>
        private void DrawLegend(Graphics g, RectangleF rectF, int startIndex)
        {
            List<string> aliass = new List<string>();
            if (_legendType == LegengType.Vertical)
            {
                Font font = LegendFont;
                float rowHeight = g.MeasureString("A", font).Height + 2;
                int index = 0;
                int idx = 0;
                if (_drawCurveLegend)
                {
                    for (int i = 0; i < _curves.Count; i++)
                    {
                        MedVitalSignCurve curve = _curves[i];
                        if (curve.Color == Color.White) continue;
                        bool find = false;
                        foreach (MedVitalSignCurveDetail detail in _curveDetails)
                        {
                            if (detail.CurveCode == curve.Code && detail.ShowType == MedCurveShowType.Digit)
                            {
                                find = true;
                                break;
                            }
                        }
                        if (find) continue;
                        string showText = curve.Text;
                        if (curve.Text == "呼吸")
                        {
                            showText = "自主呼吸";


                        }

                        if (string.IsNullOrEmpty(showText) || aliass.Contains(showText)) continue;
                        aliass.Add(showText);
                        if (idx >= startIndex)
                        {
                            float size = curve.Symbol.Size;
                            curve.Symbol.Size = _legengSymbolSize;
                            if (curve.Symbol.Size < 3) curve.Symbol.Size = 3;
                            curve.Symbol.Draw(g, rectF.X + 5, rectF.Y + (rowHeight) / 2 + index * rowHeight);
                            using (Brush curveBrush = new SolidBrush(curve.Color))
                            {
                                g.DrawString(showText, font, curveBrush, rectF.X + 3 + curve.Symbol.Size, rectF.Y + (rowHeight - g.MeasureString("A", font).Height) / 2 + index * rowHeight);
                            }
                            curve.Symbol.Size = size;
                            index++;
                        }
                        idx++;
                        if (i == (_curves.Count - 1))
                        {

                        }
                    }
                }
                if (_eventMark != null && _eventMark.Points.Count > 0)
                {
                    for (int i = 0; i < _eventMark.Points.Count; i++)
                    {
                        EventMarkPoint point = _eventMark.Points[i];
                        if (point.Symbol == null) continue;
                        string text = point.Text;
                        if (!string.IsNullOrEmpty(point.Alias))
                        {
                            text = point.Alias;
                        }
                        if (aliass.Contains(text)) continue;
                        aliass.Add(text);
                        if (idx >= startIndex)
                        {
                            float size = point.Symbol.Size;
                            point.Symbol.Size = _legengSymbolSize;
                            if (point.Symbol.Size < 3) point.Symbol.Size = 3;
                            point.Symbol.Draw(g, rectF.X + 5, rectF.Y + (rowHeight) / 2 + index * rowHeight);
                            g.DrawString(text, font, new SolidBrush(point.Color), rectF.X + 3 + point.Symbol.Size, rectF.Y + (rowHeight - g.MeasureString("A", font).Height) / 2 + index * rowHeight);
                            index++;
                            point.Symbol.Size = size;
                        }
                        idx++;
                    }
                }
            }
            else if (_legendType == LegengType.Horizontal)
            {
                Font font = LegendFont;
                float leftOffset = 0, topOffSet = 0;
                for (int i = 0; i < _curves.Count; i++)
                {
                    MedVitalSignCurve curve = _curves[i];
                    Color oldColor = curve.Color;
                    Color color = oldColor;
                    if (oldColor.Equals(Color.White))
                    {
                        color = Color.Black;
                        continue;
                    }
                    if (rectF.X + 8 + curve.Symbol.Size + 1 + leftOffset + g.MeasureString(curve.Text, font).Width > rectF.Right + 3)
                    {
                        leftOffset = 0;
                        topOffSet += g.MeasureString("A", font).Height + 1;
                    }
                    curve.Symbol.Draw(g, rectF.X + 8 + leftOffset, rectF.Y + 10 + topOffSet);
                    g.DrawString(curve.Text, font, new SolidBrush(color), rectF.X + 8 + curve.Symbol.Size + 1 + leftOffset, rectF.Y + 4 + topOffSet);
                    if (!oldColor.Equals(color))
                    {
                        curve.Symbol.Brush = new SolidBrush(oldColor);
                    }
                    leftOffset += curve.Symbol.Size + 1 + g.MeasureString(curve.Text, font).Width + 10;
                }
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        public void Test()
        {
            _startTime = DateTime.Parse("08:00");
            _endTime = DateTime.Parse("12:00");
            _yAxises = new List<MedVitalSignYAxis>();
            _yAxises.Add(new MedVitalSignYAxis(new double[] { 0, 10, 20, 30, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220 }, "mmHg"));
            _yAxises.Add(new MedVitalSignYAxis(new double[] { -1, -1, 60, 64, 68, 72, 76, 80, 84, 88, 92, 96, 100, 104 }, "spo2"));
            _yAxises.Add(new MedVitalSignYAxis(new double[] { -1, -1, -1, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42 }, "℃"));
            _curves = new List<MedVitalSignCurve>();
            MedVitalSignCurve curve = new MedVitalSignCurve("动脉收缩压", 0, Color.IndianRed, new MedSymbol(MedSymbolType.Diamond));
            curve.AddPoint(DateTime.Parse("08:40"), 70);
            curve.AddPoint(DateTime.Parse("08:45"), 65);
            curve.AddPoint(DateTime.Parse("09:07"), 62);
            curve.AddPoint(DateTime.Parse("09:25"), 74);
            curve.AddPoint(DateTime.Parse("09:31"), 81);
            curve.AddPoint(DateTime.Parse("09:55"), 63);
            _curves.Add(curve);
            curve = new MedVitalSignCurve("动脉舒张压", 0, Color.Blue, new MedSymbol(MedSymbolType.Circle));
            curve.AddPoint(DateTime.Parse("08:30"), 80);
            curve.AddPoint(DateTime.Parse("08:45"), 95);
            curve.AddPoint(DateTime.Parse("09:00"), 95);
            curve.AddPoint(DateTime.Parse("09:15"), 80);
            curve.AddPoint(DateTime.Parse("09:35"), 105);
            curve.AddPoint(DateTime.Parse("09:45"), 82);
            _curves.Add(curve);
        }

        /// <summary>
        /// 获取坐标所在曲线
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        private int MeasureCurve(MedVitalSignCurve curve, Point pt)
        {
            for (int i = 0; i < curve.Points.Count; i++)
            {
                MedVitalSignPoint point = curve.Points[i];
                if (Math.Abs(pt.X / _scaleRate - point.X) < 5 && Math.Abs(pt.Y / _scaleRate - point.Y) < 5)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获取坐标所在事件标记
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        private int MeasureEventMark(Point pt)
        {
            for (int i = 0; i < _eventMark.Points.Count; i++)
            {
                EventMarkPoint point = _eventMark.Points[i];
                float y = point.Y;
                if (pt.X / _scaleRate - point.X > 0 && pt.X / _scaleRate - point.X < 8 && pt.Y / _scaleRate - point.Y > 0
                    && pt.Y / _scaleRate - point.Y < 8)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获取曲线显示文本
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        private string GetCurveDispText(MedVitalSignCurve curve)
        {
            if (!string.IsNullOrEmpty(curve.Alias))
            {
                return curve.Alias;
            }
            return curve.Text;
        }

        /// <summary>
        /// 设置鼠标位置
        /// </summary>
        /// <param name="mousePoint"></param>
        public void SetMousePosition(Point mousePoint)
        {
            _selectedBlood = null;
            _selectedEvent = null;
            _isMouseInMark = false;
            if (_lockMouse)
            {
                return;
            }


            //判断当前点是否可以被拖动
            if (CanUpdate1() && _selectPoint != null)
            {

                EventHandler<VitalSignPointEventArgs> eventHandle = (EventHandler<VitalSignPointEventArgs>)Events[_SignPointMouseMove];
                if (eventHandle != null)
                {
                    eventHandle(this, new VitalSignPointEventArgs(_selectPoint, _oldTimePoint, _oldValue));
                }
                //判断当前点是否可以可以拖动
                if (!_CurrentPosCanMove)
                {
                    _CurrentPosCanMove = true;
                    return;
                }
            }

            RectangleF rect = GetMainRect();
            rect.Height += _eventMarkHeight;
            if (rect.Contains(mousePoint))
            {
                if (mousePoint.Y > rect.Height - _eventMarkHeight)
                    _isMouseInMark = true;
            }

            rect.X = rect.X * _scaleRate;
            rect.Y = rect.Y * _scaleRate;
            rect.Width = rect.Width * _scaleRate;
            rect.Height = rect.Height * _scaleRate;
            TimeSpan spTotal1 = _endTime - _startTime;
            _mouseTime = _startTime.AddSeconds((int)((mousePoint.X - rect.X) / rect.Width * spTotal1.TotalSeconds));

            if (CanUpdate1() && _selectPoint != null && _selectPoint.Curve.CanUpdate && rect.Contains(mousePoint.X, mousePoint.Y))// && e.Button == MouseButtons.Left)
            {
                //Console.WriteLine("Mousemove");
                double d = 0;
                if (!double.TryParse(_selectPoint.Value.ToString(), out d))
                {
                    d = 0;
                }
                double oldValue = d;
                try
                {
                    _selectPoint.Value = GetValue(mousePoint.Y, _selectPoint.Curve);
                    if (!_modifiedPoints.Contains(_selectPoint))
                    {
                        _modifiedPoints.Add(_selectPoint);
                    }
                }
                catch { _selectPoint.Value = oldValue; }
                //if (ModifierKeys != Keys.Shift)
                //{
                picCursor.Top = mousePoint.Y;
                //}
                //else
                //{
                //    _selectPoint.Time = GetTimePoint(mousePoint.X, rect);
                //    picCursor.Location = mousePoint;
                //}
                Invalidate();
                string s = GetCurveDispText(_selectPoint.Curve) + "\r\n时间：" + _selectPoint.Time.ToString("HH:mm") + "\r\n值：" + _selectPoint.Value.ToString();
                using (Graphics g = picCursor.CreateGraphics())
                {
                    g.Clear(picCursor.BackColor);
                    g.DrawString(s, Font, Brushes.Black, 0, 0);
                }
            }
            else
            {
                if (_curves != null && rect.Contains(mousePoint.X, mousePoint.Y))
                {
                    if (_eventOffSet > 0)
                    {
                        if ((rect.Bottom - _eventOffSet - _eventMarkHeight <= mousePoint.Y) && (rect.Bottom - _eventMarkHeight > mousePoint.Y))
                        {
                            for (int i = 0; i < _curves.Count; i++)
                            {
                                if (_curves[i].IsDigit)
                                {
                                    int index = MeasureCurve(_curves[i], new Point(mousePoint.X, mousePoint.Y));
                                    if (index > -1)
                                    {
                                        double d = 0;
                                        if (!double.TryParse(_curves[i].Points[index].Value.ToString(), out d))
                                        {
                                            d = 0;
                                        }
                                        if (d > 0)
                                        {
                                            if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                                            {
                                                toolTip1.SetToolTip(this, GetCurveDispText(_curves[i]) + "\r\n================\r\n时间：" + _curves[i].Points[index].Time.ToString("HH:mm") + "\r\n值：" + _curves[i].Points[index].Value.ToString());
                                                _oldMousePos.X = mousePoint.X;
                                                _oldMousePos.Y = mousePoint.Y;
                                            }
                                            return;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                            {
                                toolTip1.SetToolTip(this, "");
                                _oldMousePos.X = mousePoint.X;
                                _oldMousePos.Y = mousePoint.Y;
                            }
                            return;
                        }
                    }
                    for (int i = 0; i < _curves.Count; i++)
                    {
                        if (_curves[i].Color == Color.White) continue;
                        int index = MeasureCurve(_curves[i], new Point(mousePoint.X, mousePoint.Y));
                        if (index > -1)
                        {
                            if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                            {
                                toolTip1.SetToolTip(this, GetBreathText(GetCurveDispText(_curves[i]), _curves[i].Points[index].Time) + "\r\n================\r\n时间：" + _curves[i].Points[index].Time.ToString("HH:mm") + "\r\n值：" + _curves[i].Points[index].Value.ToString());
                                _oldMousePos.X = mousePoint.X;
                                _oldMousePos.Y = mousePoint.Y;
                            }
                            return;
                        }
                        else if (_eventMark != null)
                        {
                            index = MeasureEventMark(new Point(mousePoint.X, mousePoint.Y));
                            if (index > -1)
                            {
                                if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                                {
                                    toolTip1.SetToolTip(this, "时间：" + _eventMark.Points[index].TimePoint.ToString() + "\r\n================\r\n名称："
                                        + _eventMark.Points[index].Text);
                                    _oldMousePos.X = mousePoint.X;
                                    _oldMousePos.Y = mousePoint.Y;
                                }
                                return;
                            }
                        }
                    }
                }
            }
            if (_bloodGasRects.Count > 0)
            {
                Dictionary<BloodGasMaster, RectangleF>.Enumerator enumerator = _bloodGasRects.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Value.Contains(mousePoint))
                    {
                        _selectedBlood = enumerator.Current.Key;
                        if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                        {
                            toolTip1.SetToolTip(this, _selectedBlood.DisplayName + "\r\n===================\r\n" + _selectedBlood.Recorddate.ToString("yyyy-MM-dd HH:mm"));
                            _oldMousePos.X = mousePoint.X;
                            _oldMousePos.Y = mousePoint.Y;
                        }
                        return;
                    }
                }
            }
            if (_eventRects.Count > 0)
            {
                Dictionary<EventItem, RectangleF>.Enumerator enumerator = _eventRects.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Value.Contains(mousePoint))
                    {
                        _selectedEvent = enumerator.Current.Key;
                        if (_oldMousePos.X != mousePoint.X || _oldMousePos.Y != mousePoint.Y)
                        {
                            toolTip1.SetToolTip(this, _selectedEvent.EventName + "\r\n===================\r\n" + _selectedEvent.StartTime.ToString("yyyy-MM-dd HH:mm"));
                            _oldMousePos.X = mousePoint.X;
                            _oldMousePos.Y = mousePoint.Y;
                        }
                        return;
                    }
                }
            }
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

        private string GetBreathText(string text, DateTime timePoint)
        {
            if (text.Equals("呼吸") && _breathControlTimeList != null && _breathControlTimeList.Count > 0)
            {
                foreach (MedVitalSignBreathControlTime controlTime in _breathControlTimeList)
                {
                    if (controlTime.BreathType == BreathControlType.ControlBreath)
                    {
                        if (controlTime.startTime <= timePoint && controlTime.endTime >= timePoint)
                        {
                            return "控制呼吸";
                        }
                    }
                    else if (controlTime.BreathType == BreathControlType.FreeBreath)
                    {
                        if (controlTime.startTime <= timePoint && controlTime.endTime >= timePoint)
                        {
                            return "自主呼吸";
                        }
                    }
                    else if (controlTime.BreathType == BreathControlType.HelpBreath)
                    {
                        if (controlTime.startTime <= timePoint && controlTime.endTime >= timePoint)
                        {
                            return "辅助呼吸";
                        }
                    }
                }
            }
            return text;
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

        private bool _autoBreathUpdate = true;
        [DisplayName("呼吸拖到控制")]
        public bool AutoBreathUpdate
        {
            get
            {
                return _autoBreathUpdate;
            }
            set
            {
                _autoBreathUpdate = value;
            }
        }

        private bool CanUpdate1()
        {

            if (_canUpdate && _autoBreathUpdate)
            {
                if (_selectPoint != null && _selectPoint.Curve.Text.Equals("呼吸") && _breathControlTimeList != null && _breathControlTimeList.Count > 0)
                {
                    foreach (MedVitalSignBreathControlTime controlTime in _breathControlTimeList)
                    {
                        if (controlTime.BreathType == BreathControlType.ControlBreath)
                        {
                            return false;
                        }
                    }
                }
            }

            return _canUpdate;
        }

        /// <summary>
        /// 设置鼠标按下
        /// </summary>
        /// <param name="mousePoint"></param>
        public void SetMouseDown(Point mousePoint)
        {

            SetMouseUp();
            //EventHandler eventHandle = Events[_rMouseClick] as EventHandler;
            //if (e.Button == MouseButtons.Left || ((_popupMenu != null || eventHandle != null) && e.Button == MouseButtons.Right))
            //if (_popupMenu != null || eventHandle != null)
            {
                RectangleF rect = GetMainRect();
                rect.Height += _eventMarkHeight;
                rect.X = rect.X * _scaleRate;
                rect.Y = rect.Y * _scaleRate;
                rect.Width = rect.Width * _scaleRate;
                rect.Height = rect.Height * _scaleRate;
                if (_curves != null && rect.Contains(mousePoint.X, mousePoint.Y))
                {
                    for (int i = 0; i < _curves.Count; i++)
                    {
                        if (_curves[i].Color == Color.White) continue;
                        int index = MeasureCurve(_curves[i], new Point(mousePoint.X, mousePoint.Y));
                        if (index > -1)
                        {
                            _selectPoint = _curves[i].Points[index];
                            //Console.WriteLine("Mousedown");
                            //if (e.Button == MouseButtons.Left)
                            {
                                _oldTimePoint = _selectPoint.Time;
                                double d = 0;
                                if (!double.TryParse(_selectPoint.Value.ToString(), out d))
                                {
                                    d = 0;
                                }
                                _oldValue = d;
                                if (CanUpdate1())
                                {
                                    picCursor.Location = mousePoint;
                                    picCursor.Visible = true;
                                }
                            }
                            //else
                            //{
                            //    if (_popupMenu != null)
                            //    {
                            //        _popupMenu.Show(this, mousePoint.X, mousePoint.Y);
                            //    }
                            //    else
                            //    {
                            //        eventHandle(this, null);
                            //    }
                            //}
                        }
                        else if (_eventMark != null)
                        {
                            index = MeasureEventMark(new Point(mousePoint.X, mousePoint.Y));
                            if (index > -1)
                            {
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置鼠标松开
        /// </summary>
        private void SetMouseUp()
        {
            //Console.Write("Mouseup");
            if (CanUpdate1() && _selectPoint != null)// && e.Button == MouseButtons.Left)
            {
                picCursor.Visible = false;
                if (_selectPoint.Time != _oldTimePoint || !_selectPoint.Value.Equals(_oldValue))
                {
                    EventHandler<VitalSignPointEventArgs> eventHandle = (EventHandler<VitalSignPointEventArgs>)Events[_valueChanged];
                    if (eventHandle != null)
                    {
                        eventHandle(this, new VitalSignPointEventArgs(_selectPoint, _oldTimePoint, _oldValue));
                    }
                }
            }
            _selectPoint = null;
            //Console.WriteLine("...");

        }

        #endregion 方法

        #region 事件

        /// <summary>
        /// 大小改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedVitalSignGraph_Resize(object sender, EventArgs e)
        {
            //Invalidate();
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedVitalSignGraph_MouseMove(object sender, MouseEventArgs e)
        {
            SetMousePosition(e.Location);
        }

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedVitalSignGraph_MouseDown(object sender, MouseEventArgs e)
        {
            SetMouseDown(e.Location);
        }

        /// <summary>
        /// 鼠标松开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedVitalSignGraph_MouseUp(object sender, MouseEventArgs e)
        {
            SetMouseUp();
        }

        private void MedVitalSignGraph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_selectPoint != null)
            {
                if (_selectPoint.Curve.Text.Equals("呼吸") && _breathControlTimeList != null && _breathControlTimeList.Count > 0)
                {
                    foreach (MedVitalSignBreathControlTime controlTime in _breathControlTimeList)
                    {
                        if (controlTime.BreathType == BreathControlType.ControlBreath && controlTime.startTime <= _selectPoint.Time
                            && controlTime.endTime >= _selectPoint.Time)
                        //if (controlTime.BreathType == BreathControlType.ControlBreath)
                        {
                            _selectedBreathControlTime = controlTime;
                            EventHandler eventHandle = Events[_controlBreathStartDoubleClick] as EventHandler;
                            if (eventHandle != null)
                            {
                                eventHandle(this, e);
                            }
                        }
                    }
                }
            }
        }

        #endregion 事件
    }
}
