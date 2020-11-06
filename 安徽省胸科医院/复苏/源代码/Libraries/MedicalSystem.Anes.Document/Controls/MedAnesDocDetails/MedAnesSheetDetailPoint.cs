/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedAnesSheetDetailPoint.cs
      // 文件功能描述：麻醉单明细区点类
      //
      // 
      // 创建标识：戴呈祥-2008-10-24
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using MedicalSystem.Anes.Domain;


namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 麻醉单明细区点类
    /// </summary>
    public class MedAnesSheetDetailPoint
    {

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="text">文本（名称）</param>
        public MedAnesSheetDetailPoint(DateTime startTime, string text)
        {
            _startTime = startTime;
            _text = text;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="text">文本（名称）</param>
        public MedAnesSheetDetailPoint(DateTime startTime, string text, MED_ANESTHESIA_EVENT row)
        {
            _startTime = startTime;
            _text = text;
            _datarow = row;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="text">文本（名称）</param>
        public MedAnesSheetDetailPoint(DateTime startTime, DateTime endTime, string text,MED_ANESTHESIA_EVENT row)
            : this(startTime, text, row)
        {
            _endTime = endTime;
            _pointType = PointType.ProLonged;

        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="text">文本（名称）</param>
        /// <param name="value">值</param>
        /// <param name="unit">单位</param>
        /// <param name="route">途径</param>
        public MedAnesSheetDetailPoint(DateTime startTime, string text, double value, string unit, string route, MED_ANESTHESIA_EVENT row)
            : this(startTime, text, row)
        {
            _value = value;
            _unit = unit;
            _route = route;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="text">文本（名称）</param>
        /// <param name="value">值</param>
        /// <param name="unit">单位</param>
        /// <param name="route">途径</param>
        public MedAnesSheetDetailPoint(DateTime startTime, DateTime endTime, string text, double value, string unit, string route, MED_ANESTHESIA_EVENT row)
            : this(startTime, text, value, unit, route, row)
        {
            _endTime = endTime;
            _pointType = PointType.ProLonged;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="text">文本（名称）</param>
        /// <param name="value">值</param>
        /// <param name="unit">单位</param>
        public MedAnesSheetDetailPoint(string text, double value, string unit, MED_ANESTHESIA_EVENT row)
        {
            _text = text;
            _value = value;
            _unit = unit;
            _datarow = row;
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime _endTime;

        /// <summary>
        /// 点类型
        /// </summary>
        private PointType _pointType = PointType.SinglePoint;

        /// <summary>
        /// 文本（名称）
        /// </summary>
        private string _text;

        /// <summary>
        /// 值
        /// </summary>
        private double _value;

        /// <summary>
        /// 单位
        /// </summary>
        private string _unit;

        /// <summary>
        /// 途径
        /// </summary>
        private string _route;

        private RectangleF _rectF;


        private MED_ANESTHESIA_EVENT _datarow;

        #endregion 变量

        #region 属性

        private object _tag;
        public object Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }

        public MED_ANESTHESIA_EVENT DataRow
        {
            get { return _datarow; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Description("开始时间")]
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
        [Description("结束时间")]
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
        /// 文本（名称）
        /// </summary>
        [Description("名称")]
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
        /// 值
        /// </summary>
        [Description("值")]
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
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
        /// 途径
        /// </summary>
        [Description("途径")]
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

        private double _thickNess;
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

        private string _thickNessUnit;
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

        private string _speedUnit;
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

        private double _speed;
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

        public RectangleF RectF
        {
            get
            {
                return _rectF;
            }
            set
            {
                _rectF = value;
            }
        }

        private int _index;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        private MedAnesSheetDetailCollection _collection;
        public MedAnesSheetDetailCollection Collection
        {
            get
            {
                return _collection;
            }
            set
            {
                _collection = value;
            }
        }

        private Color _color;
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
            }
        }

        private string _attrubite;
        public string Attrubite
        {
            get
            {
                return _attrubite;
            }
            set
            {
                _attrubite = value;
            }
        }

        #endregion 属性
    }
}
