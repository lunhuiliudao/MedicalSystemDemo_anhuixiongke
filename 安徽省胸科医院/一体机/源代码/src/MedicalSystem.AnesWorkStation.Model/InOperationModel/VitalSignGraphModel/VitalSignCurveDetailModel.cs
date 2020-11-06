// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      VitalSignCurveDetailModel.cs
// 功能描述(Description)：    体征明细对应的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 体征展示的类型：数字OR曲线
    /// </summary>
    public enum CurveShowType
    {
        /// <summary>
        /// 数字
        /// </summary>
        [Description("数字")]
        Digit,

        /// <summary>
        /// 曲线图
        /// </summary>
        [Description("曲线图")]
        Line
    }

    /// <summary>
    /// 体征展示的时间刻度枚举
    /// </summary>
    public enum ShowTimeInterval
    {
        /// <summary>
        /// 5分钟
        /// </summary>
        [Description("5分钟")]
        Five = 5,

        /// <summary>
        /// 10分钟
        /// </summary>
        [Description("10分钟")]
        Ten = 10,

        /// <summary>
        /// 15分钟
        /// </summary>
        [Description("15分钟")]
        Fifiteen = 15,

        /// <summary>
        /// 20分钟
        /// </summary>
        [Description("20分钟")]
        Twenty = 20,

        /// <summary>
        /// 半小时
        /// </summary>
        [Description("半小时")]
        HalfHour = 30,

        /// <summary>
        /// 1小时
        /// </summary>
        [Description("1小时")]
        Hour = 60,

        /// <summary>
        /// 不限制
        /// </summary>
        [Description("不限制")]
        AnyTime = 1
    }

    /// <summary>
    /// 体征明细对应的实体类
    /// </summary>
    public class VitalSignCurveDetailModel : ObservableObject
    {
        private string _curveCode;                                                 // 曲线代码
        private string _curveName;                                                 // 曲线名称
        private bool _visible = true;                                              // 当前曲线是否展示
        private List<LegendItem> _LegendList = new List<LegendItem>();             // 曲线图例列表
        private string _symbolEntry = null;                                        // 图标对应的文本信息
        private Color _color = Color.Red;                                          // 曲线颜色
        private CurveShowType _showType = CurveShowType.Line;                      // 曲线展示类型：数字OR曲线
        private int _yAxisIndex = 0;                                               // Y坐标索引：Y轴有3种坐标
        private ShowTimeInterval _showTimeInterval = ShowTimeInterval.Five;        // 体征展示的时间刻度枚举
        private List<DateTimeRangeModel> _hideTime;                                // 隐藏的时间列表
        private List<VitalSignPointModel> _points = new List<VitalSignPointModel>();  // 曲线所有的时间点列表

        /// <summary>
        /// 无参构造
        /// </summary>
        public VitalSignCurveDetailModel()
        {
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="text">文本（名称）</param>
        /// <param name="yAxisIndex">Y坐标索引：Y轴有3种坐标</param>
        /// <param name="color">颜色</param>
        /// <param name="symbol">标识</param>
        public VitalSignCurveDetailModel(string text, int yAxisIndex, Color color)
            : this(text, yAxisIndex, color, false)
        {
        }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="text">曲线名称</param>
        /// <param name="yAxisIndex">Y坐标索引：Y轴有3种坐标</param>
        /// <param name="color">曲线颜色</param>
        /// <param name="isDigit">界面展示：数字OR曲线</param>
        public VitalSignCurveDetailModel(string text, int yAxisIndex, Color color, bool isDigit)
        {
            _curveName = text;
            _yAxisIndex = yAxisIndex;
            _color = color;
            this._showType = isDigit ? CurveShowType.Digit : CurveShowType.Line;
        }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="text">曲线名称</param>
        /// <param name="code">曲线颜色</param>
        /// <param name="yAxisIndex">Y坐标索引：Y轴有3种坐标</param>
        public VitalSignCurveDetailModel(string text, string code, int yAxisIndex)
        {
            _curveCode = code;
            _curveName = text;
            _yAxisIndex = yAxisIndex;
        }

        /// <summary>
        /// 曲线代码
        /// </summary>
        [DisplayName("曲线代码")]
        public string CurveCode
        {
            get
            {
                return _curveCode;
            }
            set
            {
                _curveCode = value;
            }
        }

        /// <summary>
        /// 曲线名称
        /// </summary>
        [DisplayName("曲线名称")]
        public string CurveName
        {
            get
            {
                return _curveName;
            }
            set
            {
                _curveName = value;
            }
        }

        /// <summary>
        /// 当前曲线是否展示
        /// </summary>
        [DisplayName("是否显示")]
        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
            }
        }

        /// <summary>
        /// 曲线图例列表
        /// </summary>
        [DisplayName("图例列")]
        public List<LegendItem> LegendList
        {
            get
            {
                return _LegendList;
            }
            set
            {
                _LegendList = value;
            }
        }

        /// <summary>
        /// 图标对应的文本信息
        /// </summary>
        [DisplayName("标识实体")]
        public string SymbolEntry
        {
            get
            {
                return _symbolEntry;
            }
            set
            {
                _symbolEntry = value;
            }
        }

        /// <summary>
        /// 曲线颜色
        /// </summary>
        [DisplayName("颜色")]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        /// <summary>
        /// 展示类型：数字OR曲线
        /// </summary>
        [DisplayName("显示类型")]
        public CurveShowType ShowType
        {
            get
            {
                return _showType;
            }
            set
            {
                _showType = value;
            }
        }

        /// <summary>
        /// Y坐标索引：Y轴有3种坐标
        /// </summary>
        [DisplayName("Y坐标索引")]
        public int YAxisIndex
        {
            get
            {
                return _yAxisIndex;
            }
            set
            {
                _yAxisIndex = value;
            }
        }

        /// <summary>
        /// 体征展示的时间刻度枚举
        /// </summary>
        [DisplayName("显示时间间隔")]
        public ShowTimeInterval ShowTimeInterval
        {
            get
            {
                return _showTimeInterval;
            }
            set
            {
                _showTimeInterval = value;
            }
        }

        /// <summary>
        /// 隐藏的时间列表
        /// </summary>
        [DisplayName("隐藏时间")]
        public List<DateTimeRangeModel> HideTime
        {
            get { return _hideTime; }
            set { _hideTime = value; }
        }

        /// <summary>
        /// 点集合
        /// </summary>
        public List<VitalSignPointModel> Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }

        /// <summary>
        /// 是否数字显示
        /// </summary>
        public bool IsDigit
        {
            get
            {
                return ShowType == CurveShowType.Digit;
            }
        }

        /// <summary>
        /// 保留小数位数
        /// </summary>
        public int DecimalDigits
        {
            get;
            set;
        }

        /// <summary>
        /// 增加点
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="value">值</param>
        public void AddPoint(DateTime time, double value, SymbolModel symbol, string flag)
        {
            _points.Add(new VitalSignPointModel(time, value, this, symbol, flag));
        }

        /// <summary>
        /// 重写ToString，返回曲线名称
        /// </summary>
        public override string ToString()
        {
            return _curveName;
        }
    }
}
