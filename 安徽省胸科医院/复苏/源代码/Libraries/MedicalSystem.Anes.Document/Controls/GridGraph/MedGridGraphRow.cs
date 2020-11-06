/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedGridPoint.cs
      // 文件功能描述：事件索引表格行类
      //
      // 
      // 创建标识：戴呈祥-2008-10-22
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 事件索引表格行类
    /// </summary>
    [Serializable]
    public class MedGridGraphRow
    {

        #region 构造方法

        public MedGridGraphRow(string text, Color color)
        {
            _text = text;
            _color = color;
            this.DotNumber = 1;
        }

        #endregion 构造方法

        #region 变量

        private string _text;

        private Color _color = Color.Black;

        private List<MedGridPoint> _points = new List<MedGridPoint>();

        #endregion 变量

        #region 属性

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

        public List<MedGridPoint> Points
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

        private bool _isAverage = false;
        public bool IsAverage
        {
            get
            {
                return _isAverage;
            }
            set
            {
                _isAverage = value;
            }
        }

        private bool _isDetail = false;
        public bool IsDetail
        {
            get
            {
                return _isDetail;
            }
            set
            {
                _isDetail = value;
            }
        }

        private bool _isLine = false;
        public bool IsLine
        {
            get
            {
                return _isLine;
            }
            set
            {
                _isLine = value;
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
                _dotNumber = value;
            }
        }

        private string _groupTitle = "";
        public string GroupTitle
        {
            get
            {
                return _groupTitle;
            }
            set
            {
                _groupTitle = value;
            }
        }

        private int _groupLines = 0;
        public int GroupLines
        {
            get
            {
                return _groupLines;
            }
            set
            {
                _groupLines = value;
            }
        }

        private float _xOffSet = 0;
        public float XOffSet
        {
            get
            {
                return _xOffSet;
            }
            set
            {
                _xOffSet = value;
            }
        }

        private string _total = "";
        public string Total
        {
            get
            {
                if (_autoCalcTotal)
                {
                    return GetTotal();
                }
                else
                {
                    return _total;
                }
            }
            set
            {
                _total = value;
            }
        }

        private bool _autoCalcTotal = true;
        public bool AutoCalcTotal
        {
            get
            {
                return _autoCalcTotal;
            }
            set
            {
                _autoCalcTotal = value;
            }
        }

        private string _unit;
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

        private string _rowFix = "";
        public string RowFix
        {
            set
            {
                _rowFix = value;
            }
            get
            {
                return _rowFix;
            }
        }

        #endregion 属性

        #region 方法

        private string GetTotal()
        {
            double v = 0;
            foreach (MedGridPoint point in Points)
            {
                v += point.Value;
            }
            if (v == 0)
            {
                return "";
            }
            else
            {
                return v.ToString();
            }
        }

        public MedGridPoint AddPoint(DateTime time, int startIndex, int endIndex, string text, double value)
        {
            MedGridPoint pt = new MedGridPoint(time, startIndex, endIndex, text, value, null);
            _points.Add(pt);
            return pt;
        }

        public MedGridPoint AddPoint(DateTime time, int startIndex, string text, double value)
        {
            MedGridPoint pt = new MedGridPoint(time, startIndex, text, value);
            _points.Add(pt);
            return pt;
        }

        public MedGridPoint AddPoint(DateTime time, int startIndex, string text, string value)
        {
            MedGridPoint pt = new MedGridPoint(time, startIndex, text, value);
            _points.Add(pt);
            return pt;
        }

        public MedGridPoint AddPoint(DateTime time, int startIndex, string text, double value, string alias)
        {
            MedGridPoint pt = new MedGridPoint(time, startIndex, text, value, alias);
            _points.Add(pt);
            return pt;
        }

        public MedGridPoint AddPoint(DateTime time, DateTime endTime, int startIndex, string text, double value, string alias)
        {
            MedGridPoint pt = new MedGridPoint(time, endTime, startIndex, text, value, alias);
            _points.Add(pt);
            return pt;
        }

        #endregion 方法
    }
}
