// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      DrugCurveModel.cs
// 功能描述(Description)：    用药曲线实体类，方便界面绑定
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
using System.Drawing;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel.DrugGraphModel
{
    /// <summary>
    /// 用药曲线类
    /// </summary>
    [Serializable]
    public class DrugCurveModel : ObservableObject
    {
        public static readonly double MINVALUE = -100000;              // 最大值
        private double _maxValue = MINVALUE;                           // 最大值                      
        private string _text;                                          // 第一标题
        private string _unit;                                          // 第一单位
        private string _text2 = null;                                  // 第二标题
        private string _unit2 = null;                                  // 第二单位
        private bool _centerValue = false;                             // 值绘制在中间
        private Color _color = Color.Blue;                             // 曲线颜色
        private float _Y1;                                             // Y坐标
        private float _Y2;                                             // Y坐标
        private List<DrugPointModel> _points = new List<DrugPointModel>(); // 用药曲线所包含的所有节点信息

        /// <summary>
        /// 第一显示文本
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// 第二显示文本
        /// </summary>
        public string DisplayText2 { get; set; }

        /// <summary>
        /// 第一单位
        /// </summary>
        public string DisplayUnit { get; set; }

        /// <summary>
        /// 第二单位
        /// </summary>
        public string DisplayUnit2 { get; set; }

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

        /// <summary>
        /// 值绘制在中间
        /// </summary>
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
        public List<DrugPointModel> Points
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
                foreach (DrugPointModel point in _points)
                {
                    if (point.Value is double)
                    {
                        totalValue += (double)point.Value;
                    }
                }
                return totalValue;
            }
        }
        
        /// <summary>
        /// 第二单位
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
        /// 单位
        /// </summary>
        public string Unit
        {
            get
            {
                if (string.IsNullOrEmpty(_unit))
                {
                    foreach (DrugPointModel point in _points)
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

        /// <summary>
        /// 最大值
        /// </summary>
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

        /// <summary>
        /// Y轴坐标1
        /// </summary>
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

        /// <summary>
        /// Y轴坐标2
        /// </summary>
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

        /// <summary>
        /// 有参构造，
        /// </summary>
        /// <param name="text">标题</param>
        /// <param name="color">颜色</param>
        public DrugCurveModel(string text, Color color) 
        { 
            this._text = text;
            this._color = color; 
        }
    }
}
