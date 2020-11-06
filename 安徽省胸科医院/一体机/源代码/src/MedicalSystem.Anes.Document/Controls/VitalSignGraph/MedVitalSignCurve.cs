/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedVitalSignGraph.cs
      // 文件功能描述：体征曲线类
      //
      // 
      // 创建标识：戴呈祥-2008-10-21
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{

    /// <summary>
    /// 体征曲线类型
    /// </summary>
    [Serializable]
    public enum VitalSignCurveType
    {
        /// <summary>
        /// 点和线
        /// </summary>
        LineAndPoints,
        /// <summary>
        /// 点集合
        /// </summary>
        Points
    }


    /// <summary>
    /// 体征曲线类
    /// </summary>
    [Serializable]
    public class MedVitalSignCurve
    {

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="text">文本（名称）</param>
        /// <param name="yAxisIndex">Y坐标索引</param>
        /// <param name="color">颜色</param>
        /// <param name="symbol">标识</param>
        public MedVitalSignCurve(string text, int yAxisIndex, Color color, MedSymbol symbol)
            : this(text, yAxisIndex, color, symbol, false)
        {

        }
        public MedVitalSignCurve(string text, int yAxisIndex, Color color, MedSymbol symbol, bool isDigit)
        {
            _text = text;
            _yAxisIndex = yAxisIndex;
            _color = color;
            _symbol = symbol;
            _symbol.Pen.Color = color;
            _isDigit = isDigit;
        }

        public MedVitalSignCurve(string text, string code, int yAxisIndex, Color color, MedSymbol symbol, bool isDigit)
        {
            _code = code;
            _text = text;
            _yAxisIndex = yAxisIndex;
            _color = color;
            _symbol = symbol;
            _symbol.Pen.Color = color;
            _isDigit = isDigit;
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 文本（名称）
        /// </summary>
        private string _text;

        /// <summary>
        /// 代码（代码）
        /// </summary>
        private string _code;

        /// <summary>
        /// 点集合
        /// </summary>
        private List<MedVitalSignPoint> _points = new List<MedVitalSignPoint>();

        /// <summary>
        /// 颜色
        /// </summary>
        private Color _color = Color.Black;

        /// <summary>
        /// 宽度
        /// </summary>
        private int _width;

        /// <summary>
        /// Y坐标索引
        /// </summary>
        private int _yAxisIndex;

        /// <summary>
        /// 标识
        /// </summary>
        private MedSymbol _symbol;

        /// <summary>
        /// 曲线类型
        /// </summary>
        private VitalSignCurveType _curveType;

        #endregion 变量

        #region 属性
        private string _alias = "";
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                _alias = value;
            }
        }
        private string _displayText = "";
        public string DisplayText
        {
            get
            {
                return _displayText;
            }
            set
            {
                _displayText = value;
            }
        }

        private bool _isDigit = false;
        public bool IsDigit
        {
            get
            {
                return _isDigit;
            }
            set
            {
                _isDigit = value;
            }
        }

        /// <summary>
        /// 文本（名称）
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        /// <summary>
        /// 文本（名称）
        /// </summary>
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        /// <summary>
        /// 点集合
        /// </summary>
        public List<MedVitalSignPoint> Points
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

        private int _dotNumber = 0;
        /// <summary>
        /// 小数位数
        /// </summary>
        public int DotNumber
        {
            get
            {
                return _dotNumber;
            }
            set
            {
                if (value >= 0)
                {
                    _dotNumber = value;
                }
                else
                {
                    _dotNumber = 0;
                }
            }
        }

        /// <summary>
        /// 颜色
        /// </summary>
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                if (_symbol != null) _symbol.Pen.Color = _color;
            }
        }

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        /// <summary>
        /// Y坐标索引
        /// </summary>
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
        /// 标识
        /// </summary>
        public MedSymbol Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
                _symbol.Pen.Color = _color;
            }
        }

        /// <summary>
        /// 曲线类型
        /// </summary>
        public VitalSignCurveType CurveType
        {
            get
            {
                return _curveType;
            }
            set
            {
                _curveType = value;
            }
        }

        private bool _canUpdate = true;
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


        // 连线最大刻度 体征曲线上 间距差超过1个刻度，则不画连线
        protected double _lineMaxScale = 5.01;
        public double LineMaxscale
        {
            get { return _lineMaxScale - 0.01; }
            set { _lineMaxScale = value + 0.01; }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 增加点
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="value">值</param>
        public void AddPoint(DateTime time, double value)
        {
            _points.Add(new MedVitalSignPoint(time, value, this));
        }

        public void AddPoint(DateTime time, double value, bool isKzhx)
        {
            MedVitalSignPoint point = new MedVitalSignPoint(time, value, this);
            point.IsKzhx = isKzhx;
            _points.Add(point);
        }

        /// <summary>
        /// 清除所有点
        /// </summary>
        public void Clear()
        {
            _points.Clear();
        }

        #endregion 方法
    }
}
