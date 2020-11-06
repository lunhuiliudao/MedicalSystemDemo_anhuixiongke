/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedAnesSheetDetailCollection.cs
      // 文件功能描述：麻醉单明细区集类
      //
      // 
      // 创建标识：戴呈祥-2008-10-24
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MedicalSystem.Anes.Document.Constants; 

namespace MedicalSystem.Anes.Document.Controls
{

    /// <summary>
    /// 集类型
    /// </summary>
    public enum CollectionType
    {
        /// <summary>
        /// 事件
        /// </summary>
        Event,
        /// <summary>
        /// 用药
        /// </summary>
        Drug,
        /// <summary>
        /// 汇总
        /// </summary>
        Total
    }

    /// <summary>
    /// 麻醉单明细区集类
    /// </summary>
    [Serializable]
    public class MedAnesSheetDetailCollection
    {

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="text">文本（名称）</param>
        /// <param name="color">颜色</param>
        /// <param name="type">类型</param>
        public MedAnesSheetDetailCollection(string text, Color color, CollectionType type)
        {
            _text = text;
            _color = color;
            _collectionType = type;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="text">文本（名称）</param>
        /// <param name="color">颜色</param>
        public MedAnesSheetDetailCollection(string text, Color color) : this(text, color, CollectionType.Event) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="text">文本（名称）</param>
        /// <param name="color">颜色</param>
        public MedAnesSheetDetailCollection(string text) : this(text, Color.Black) { }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 文本（名称）
        /// </summary>
        private string _text;

        /// <summary>
        /// 颜色
        /// </summary>
        private Color _color;

        /// <summary>
        /// 点集合
        /// </summary>
        private List<MedAnesSheetDetailPoint> _points = new List<MedAnesSheetDetailPoint>();

        /// <summary>
        /// 集类型
        /// </summary>
        private CollectionType _collectionType = CollectionType.Total;

        #endregion 变量

        #region 属性

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
        /// 点集合
        /// </summary>
        public List<MedAnesSheetDetailPoint> Points
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
        /// 集类型
        /// </summary>
        public CollectionType CollectionType
        {
            get
            {
                return _collectionType;
            }
            set
            {
                _collectionType = value;
            }
        }

        /// <summary>
        /// 总量
        /// </summary>
        public double TotalValue
        {
            get
            {
                double result = 0;
                if (_points != null && _points.Count > 0)
                {
                    foreach (MedAnesSheetDetailPoint point in _points)
                    {
                        result += point.Value;
                    }
                }
                return result;
            }
        }

        #endregion 属性

        #region 方法
        /// <summary>
        /// 按时间给点重新排序
        /// </summary>
        public void Sort()
        {
            if (_points != null && _points.Count > 0)
            {
                _points.Sort(new Comparison<MedAnesSheetDetailPoint>(delegate(MedAnesSheetDetailPoint p1, MedAnesSheetDetailPoint p2)
                {
                    if (p1.StartTime < p2.StartTime) return -1;
                    else if (p1.StartTime > p2.StartTime) return 1;
                    else
                    {
                        if ((p1.Text.Contains("入室") || p1.Text.Contains("入手术室")) && !(p2.Text.Contains("入室") || p2.Text.Contains("入手术室")))
                        {
                            return -1;
                        }
                        else if ((p2.Text.Contains("入室") || p2.Text.Contains("入手术室")) && !(p1.Text.Contains("入室") || p1.Text.Contains("入手术室")))
                        {
                            return 1;
                        }
                        else if ((p1.Text.Contains(EventNames.INPACU) || p1.Text.Contains("入复苏室")) && !(p2.Text.Contains(EventNames.INPACU) || p2.Text.Contains("入复苏室")))
                        {
                            return -1;
                        }
                        else if ((p2.Text.Contains(EventNames.INPACU) || p2.Text.Contains("入复苏室")) && !(p1.Text.Contains(EventNames.INPACU) || p1.Text.Contains("入复苏室")))
                        {
                            return 1;
                        }
                        else
                        {
                            return p1.Text.CompareTo(p2.Text);
                        }
                    }
                }));
                for (int i = 0; i < _points.Count; i++)
                {
                    _points[i].Index = i + 1;
                }
            }
        }

        /// <summary>
        /// 加入另一麻醉单明细区集类的所有点
        /// </summary>
        /// <param name="collection"></param>
        public void Add(MedAnesSheetDetailCollection collection)
        {
            if (_points == null) _points = new List<MedAnesSheetDetailPoint>();
            if (collection != null && collection.Points != null & collection.Points.Count > 0)
            {
                foreach (MedAnesSheetDetailPoint point in collection.Points)
                {
                    point.Color = collection.Color;
                    _points.Add(point);
                }
            }
        }

        #endregion 方法

    }
}
