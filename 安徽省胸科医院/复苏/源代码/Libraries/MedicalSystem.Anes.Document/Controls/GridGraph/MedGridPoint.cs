/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedGridPoint.cs
      // 文件功能描述：事件索引表格点类
      //
      // 
      // 创建标识：戴呈祥-2008-10-22
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 事件索引表格点类
    /// </summary>
    [Serializable]
    public class MedGridPoint
    {
        #region 构造方法

        public MedGridPoint(DateTime time, int startIndex, int endIndex, string text, double value, string stringValue)
        {
            _time = time;
            _startIndex = startIndex;
            _endIndex = endIndex;
            _text = text;
            _value = value;
            _stringValue = stringValue;
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
        public MedGridPoint(DateTime time, int startIndex, string text, double value) : this(time, startIndex, -1, text, value, null) { }
        public MedGridPoint(DateTime time, int startIndex, string text, string value) : this(time, startIndex, -1, text, 0, value) { }
        public MedGridPoint(DateTime time, int startIndex, string text, double value, string alias)
            : this(time, startIndex, -1, text, value, null)
        {
            _alias = alias;
        }

        public MedGridPoint(DateTime time, DateTime endTime, int startIndex, string text, double value, string alias)
            : this(time, startIndex, text, value, alias)
        {
            _endTime = endTime;
        }

        #endregion 构造方法

        #region 变量

        private DateTime _time;

        private int _startIndex;

        private int _endIndex;

        private double _value;

        private string _text;

        private string _unit = null;

        #endregion 变量

        #region 属性

        public DateTime Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private DateTime _endTime;
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

        public int StartIndex
        {
            get
            {
                return _startIndex;
            }
            set
            {
                _startIndex = value;
            }
        }

        public int EndIndex
        {
            get
            {
                return _endIndex;
            }
            set
            {
                _endIndex = value;
            }
        }

        private string _stringValue;
        public string StringValue
        {
            get
            {
                return _stringValue;
            }
            set
            {
                _stringValue = value;
            }
        }

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

        private string _alias;
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

        private float _X1;
        public float X1
        {
            get
            {
                return _X1;
            }
            set
            {
                _X1 = value;
            }
        }

        private float _X2;
        public float X2
        {
            get
            {
                return _X2;
            }
            set
            {
                _X2 = value;
            }
        }

        private float _Y;
        public float Y
        {
            get
            {
                return _Y;
            }
            set
            {
                _Y = value;
            }
        }

        private bool _canStop = false;
        public bool CanStop
        {
            get
            {
                return _canStop;
            }
            set
            {
                _canStop = value;
            }
        }

        private MedGridGraphRow _row;
        public MedGridGraphRow Row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
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

        private string _route;
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


        private string _startText = "";
        public string StartText
        {
            get { return _startText; }
            set { _startText = value; }
        }

        private string _endText = "";
        public string EndText
        {
            get { return _endText; }
            set { _endText = value; }
        }

        #endregion 属性
    }
}
