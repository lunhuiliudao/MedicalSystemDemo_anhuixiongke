/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedDrugCurve.cs
      // 文件功能描述：用药曲线类
      //
      // 
      // 创建标识：戴呈祥-2008-10-20
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 用药曲线类
    /// </summary>
    [Serializable]
    public class MedDrugCurve
    {
        #region 构造方法

        public MedDrugCurve()
        {
        }

        public MedDrugCurve(string text, Color color) 
        { 
            _text = text;
            _color = color; 
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 颜色
        /// </summary>
        private Color _color = Color.Blue;

        /// <summary>
        /// 标题
        /// </summary>
        private string _text;

        /// <summary>
        /// 包含的点
        /// </summary>
        private List<MedDrugPoint> _points = new List<MedDrugPoint>();

        #endregion 变量

        #region 属性

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

        /// <summary>
        /// 标题
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

        public string DisplayText = "";
        public string DisplayText2 = "";
        public string DisplayUnit = "";
        public string DisplayUnit2 = "";
        private string _text2 = null;
        /// <summary>
        /// 第二标题
        /// </summary>
        public string Text2
        {
            get
            {
                return _text2;
            }
            set
            {
                _text2 = value;
            }
        }

        private string _unit2 = null;
        /// <summary>
        /// 第二标题
        /// </summary>
        public string Unit2
        {
            get
            {
                return _unit2;
            }
            set
            {
                _unit2 = value;
            }
        }

        /// <summary>
        /// 值绘制在中间
        /// </summary>
        private bool _centerValue = false;
        public bool CenterValue
        {
            get
            {
                return _centerValue;
            }
            set
            {
                _centerValue = value;
            }
        }

        /// <summary>
        /// 包含的点
        /// </summary>
        public List<MedDrugPoint> Points
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
        /// 总量
        /// </summary>
        public double Totalvalue
        {
            get
            {
                double totalValue = 0;
                foreach (MedDrugPoint point in _points)
                {
                    if (point.Value is double)
                    {
                        totalValue += (double)point.Value;
                    }
                }
                return totalValue;
            }
        }

        private string _unit;
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get
            {
                if(string.IsNullOrEmpty(_unit))
                {
                    foreach (MedDrugPoint point in _points)
                    {
                        if (!string.IsNullOrEmpty(point.Unit))
                        {
                            _unit = point.Unit;
                            break;
                        }
                    }
                }
                return _unit;
            }
            set
            {
                _unit = value;
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
                if (string.IsNullOrEmpty(_route))
                {
                    foreach (MedDrugPoint point in _points)
                    {
                        if (!string.IsNullOrEmpty(point.Route))
                        {
                            _route = point.Route;
                            break;
                        }
                    }
                }
                return _route;
            }
            set
            {
                _route = value;
            }
        }

        private string _speedUnit;
        /// <summary>
        /// 流速
        /// </summary>
        public string SpeedUnit
        {
            get
            {
                if (string.IsNullOrEmpty(_speedUnit))
                {
                    foreach (MedDrugPoint point in _points)
                    {
                        if (!string.IsNullOrEmpty(point.SpeedUnit))
                        {
                            _speedUnit = point.SpeedUnit;
                            break;
                        }
                    }
                }
                return _speedUnit;
            }
            set
            {
                _speedUnit = value;
            }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                if (_points != null && _points.Count > 0)
                {
                    return _points[0].StartTime;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        
        }

        public static readonly double MINVALUE = -100000;
        /// <summary>
        /// 最大值
        /// </summary>
        private double _maxValue = MINVALUE;
        public double MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
            }
        }

        private float _Y1;
        [System.ComponentModel.Browsable(false)]
        public float Y1
        {
            get
            {
                return _Y1;
            }
            set
            {
                _Y1 = value;
            }
        }

        private float _Y2;
        [System.ComponentModel.Browsable(false)]
        public float Y2
        {
            get
            {
                return _Y2;
            }
            set
            {
                _Y2 = value;
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 生成点
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="value">总量</param>
        /// <param name="unit">单位</param>
        /// <param name="thickNess">浓度</param>
        /// <param name="thickNessUnit">浓度单位</param>
        /// <param name="route">途径</param>
        /// <returns>点</returns>
        private MedDrugPoint GenPoint(DateTime startTime, double value, string unit, double thickNess, string thickNessUnit, string route)
        {
            MedDrugPoint point = new MedDrugPoint();
            point.StartTime = startTime;
            point.Value = value;
            point.Unit = unit;
            point.ThickNess = thickNess;
            point.ThickNessUnit = thickNessUnit;
            point.Route = route;
            return point;
        }

        private MedDrugPoint GenPoint(DateTime startTime, double value, string unit, double thickNess, string thickNessUnit, string route,DateTime endTime,double speed,string speedUnit,PointType pointType)
        {
            MedDrugPoint point = GenPoint(startTime,value,unit,thickNess,thickNessUnit,route);
            point.EndTime = endTime;
            point.PointType = pointType;
            point.Speed = speed;
            point.SpeedUnit = speedUnit;
            return point;
        }

        /// <summary>
        /// 增加点
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="value">总量</param>
        /// <param name="unit">单位</param>
        /// <param name="thickNess">浓度</param>
        /// <param name="thickNessUnit">浓度单位</param>
        /// <param name="route">途径</param>
        public void AddPoint(DateTime startTime, double value, string unit, double thickNess, string thickNessUnit, string route)
        {
            _points.Add(GenPoint(startTime,value,unit, thickNess,thickNessUnit,route));
        }

        public MedDrugPoint AddPoint(DateTime startTime, double value, string unit, double thickNess, string thickNessUnit, string route, DateTime endTime, double speed, string speedUnit, PointType pointType)
        {
            MedDrugPoint point = GenPoint(startTime, value, unit, thickNess, thickNessUnit, route, endTime, speed, speedUnit, pointType);
            _points.Add(point);
            return point;
        }

        #endregion 方法
    }
}
