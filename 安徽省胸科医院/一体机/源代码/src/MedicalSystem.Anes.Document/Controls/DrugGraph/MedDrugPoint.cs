/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedDrugPoint.cs
      // 文件功能描述：用药点类
      //
      // 
      // 创建标识：戴呈祥-2008-10-20
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 用药点类型
    /// </summary>
    [Serializable]
    public enum PointType
    {
        /// <summary>
        /// 单个点
        /// </summary>
        SinglePoint,
        /// <summary>
        /// 持续用药的点
        /// </summary>
        ProLonged
    }

    /// <summary>
    /// 持续显示类型
    /// </summary>
    [Serializable]
    public enum ProLongedShowType
    {
        /// <summary>
        /// 流速
        /// </summary>
        Speed,
        /// <summary>
        /// 单位
        /// </summary>
        Unit
        ,
        /// <summary>
        /// 总量和流速
        /// </summary>
        TotalAndSpeed,
        /// <summary>
        /// 默认值
        /// </summary>
        Default
    }

    /// <summary>
    /// 用药点类
    /// </summary>
    [Serializable]
    public class MedDrugPoint
    {
        #region 构造方法

        public MedDrugPoint() { }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 点类型
        /// </summary>
        private PointType _pointType = PointType.SinglePoint;
        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime _startTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime _endTime;
        /// <summary>
        /// 值
        /// </summary>
        private object _value;
        /// <summary>
        /// 单位
        /// </summary>
        private string _unit;
        /// <summary>
        /// 每秒流速
        /// </summary>
        private double _speed;

        /// <summary>
        /// 持续显示类型
        /// </summary>
        private ProLongedShowType _showType = ProLongedShowType.Default;

        /// <summary>
        /// 浓度
        /// </summary>
        private double _thickNess;

        /// <summary>
        /// 浓度单位
        /// </summary>
        private string _thickNessUnit;

        /// <summary>
        /// 途径
        /// </summary>
        private string _route;

        /// <summary>
        /// 流速单位
        /// </summary>
        private string _speedUnit;

        private float _x1, _x2, _y;

        #endregion 变量

        #region 属性

        private MedDrugCurve _curve;
        public MedDrugCurve Curve
        {
            get
            {
                return _curve;
            }
            set
            {
                _curve = value;
            }
        }

        private bool _isArrow = false;
        public bool IsArrow
        {
            get
            {
                return _isArrow;
            }
            set
            {
                _isArrow = value;
            }
        }

        /// <summary>
        /// 点类型
        /// </summary>
        public PointType PointType
        {
            get
            {
                return _pointType;
            }
            set
            {
                _pointType = value;
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        /// <summary>
        /// 值
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
                //if (_value != null)
                //{
                //    return _value;
                //}
                //else
                //{
                //    TimeSpan ts = _endTime - _startTime;
                //    return ts.TotalSeconds * _speed;
                //}
            }
            set
            {
                _value = value;
            }
        }

        private object _value2;
        /// <summary>
        /// 第二组值
        /// </summary>
        public object Value2
        {
            get
            {
                return _value2;
            }
            set
            {
                _value2 = value;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }

        /// <summary>
        /// 每秒流速
        /// </summary>
        public double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        /// <summary>
        /// 持续显示类型
        /// </summary>
        public ProLongedShowType ShowType
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
        /// 浓度
        /// </summary>
        public double ThickNess
        {
            get
            {
                return _thickNess;
            }
            set
            {
                _thickNess = value;
            }
        }

        /// <summary>
        /// 浓度单位
        /// </summary>
        public string ThickNessUnit
        {
            get
            {
                return _thickNessUnit;
            }
            set
            {
                _thickNessUnit = value;
            }
        }

        /// <summary>
        /// 途径
        /// </summary>
        public string Route
        {
            get
            {
                return _route;
            }
            set
            {
                _route = value;
            }
        }

        /// <summary>
        /// 流速单位
        /// </summary>
        public string SpeedUnit
        {
            get
            {
                return _speedUnit;
            }
            set
            {
                _speedUnit = value;
            }
        }

        public float X1
        {
            get
            {
                return _x1;
            }
            set
            {
                _x1 = value;
            }
        }

        public float X2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        private string _text;
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

        #endregion 属性
    }
}