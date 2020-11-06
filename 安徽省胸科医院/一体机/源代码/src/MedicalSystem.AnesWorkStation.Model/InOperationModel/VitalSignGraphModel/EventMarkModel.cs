// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      EventMarkModel.cs
// 功能描述(Description)：    体征曲线上的节点的实体类
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

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 事件标识单个点实体类
    /// </summary>
    public class EventMarkPoint
    {
        private int _index;                                      // 排序编号
        private string _text;                                    // 具体的事件名称
        private string _displayText;                             // 展示在界面上的节点显示
        private SymbolModel _symbol;                             // 事件节点图标符号
        private DateTime _timePoint;                             // 事件节点的开始时间
        private Nullable<DateTime> _endTime;                     // 事件节点的结束时间，针对持续用药
        private bool _IsContinued;                               // 当前事件是否持续
        private Color _color;                                    // 节点颜色
        private string _lengenedText = "";                       // 事件节点的图例名称

        /// <summary>
        /// 排序编号
        /// </summary>
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

        /// <summary>
        /// 事件名称
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
        /// 展示在界面上的节点显示
        /// </summary>
        public string DisplayText
        {
            get { return _displayText; }
            set { _displayText = value; }
        }

        /// <summary>
        /// 事件节点图标符号
        /// </summary>
        public SymbolModel Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
            }
        }

        /// <summary>
        /// 是否需要显示图例
        /// </summary>
        public bool IsShowLengend
        {
            get
            {
                return Symbol != null;
            }
        }

        /// <summary>
        /// 事件节点的开始时间
        /// </summary>
        public DateTime TimePoint
        {
            get
            {
                return _timePoint;
            }
            set
            {
                _timePoint = value;
            }
        }

        /// <summary>
        /// 是否是持续事件
        /// </summary>
        public bool IsContinued
        {
            get
            {
                return EndTime.HasValue || _IsContinued;
            }
            set
            {
                _IsContinued = value;
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public Nullable<DateTime> EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                if (_endTime.HasValue)
                {
                    _IsContinued = true;
                }
            }
        }

        /// <summary>
        /// 是否图例显示
        /// </summary>
        public bool IsMarkShow
        {
            get
            {
                return Symbol != null;
            }
        }

        /// <summary>
        /// 事件节点的颜色
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
        /// 图例名称
        /// </summary>
        public string LengenedText
        {
            get
            {
                return _lengenedText;
            }
            set
            {
                _lengenedText = value;
            }
        }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="timePoint">开始时间</param>
        /// <param name="index">排序编号</param>
        /// <param name="text">事件名称</param>
        /// <param name="symbol">事件图标</param>
        /// <param name="color">事件颜色</param>
        /// <param name="lengenedText">图例名称</param>
        public EventMarkPoint(DateTime timePoint, int index, string text, SymbolModel symbol, Color color, string lengenedText)
        {
            _index = index;
            _timePoint = timePoint;
            _symbol = symbol;
            _text = text;
            _color = color;
            _lengenedText = lengenedText;
            _displayText = timePoint != DateTime.MinValue ? string.Format("{0} {1}", timePoint.ToString("HH:mm"), text) : text;
        }
    }

    /// <summary>
    /// 事件标识
    /// </summary>
    public class EventMarkModel : ObservableObject
    {
        private string _title;                                             // 事件标题
        private Font _font = new Font("宋体", 10);                         // 展示事件信息的字体
        private Color _color = Color.Black;                                // 展示事件信息的字体颜色
        private List<EventMarkPoint> _points = new List<EventMarkPoint>(); // 事件明细列表

        /// <summary>
        /// 事件标题
        /// </summary>
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

        /// <summary>
        /// 事件明细列表
        /// </summary>
        public List<EventMarkPoint> Points
        {
            get
            {
                return _points;
            }
        }

        /// <summary>
        /// 展示事件信息的字体
        /// </summary>
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("字体不能为空");
                }
                _font = value;
            }
        }

        /// <summary>
        /// 展示事件信息的字体颜色
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
        /// 根据时间节点获取该节点在明细列表中所在的排序编号
        /// </summary>
        public int IndexOf(DateTime timePoint)
        {
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].TimePoint.Equals(timePoint))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 添加事件明细节点
        /// </summary>
        /// <param name="timePoint">事件节点</param>
        /// <param name="index">编号</param>
        /// <param name="text">事件名称</param>
        /// <param name="symbol">事件图标</param>
        /// <param name="color">事件图标颜色</param>
        /// <param name="alias">事件图例名称</param>
        public void AddPoint(DateTime timePoint, int index, string text, SymbolModel symbol, Color color, string alias)
        {
            _points.Add(new EventMarkPoint(timePoint, index, text, symbol, color, alias));
        }

        /// <summary>
        /// 根据时间节点获取对应的事件图标
        /// </summary>
        public SymbolModel GetSymbol(DateTime timePoint)
        {
            int index = IndexOf(timePoint);
            if (index >= 0)
            {
                return _points[index].Symbol;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据时间节点删除事件明细列表中对应的事件明细
        /// </summary>
        public void RemovePoint(DateTime timePoint)
        {
            int index = IndexOf(timePoint);
            if (index >= 0)
            {
                _points.RemoveAt(index);
            }
        }

        /// <summary>
        /// 清除事件明细列表
        /// </summary>
        public void ClearPoints()
        {
            _points.Clear();
        }

        /// <summary>
        /// 事件明细列表执行排序
        /// </summary>
        public void ReSort()
        {
            Points.Sort(new Comparison<EventMarkPoint>(delegate(EventMarkPoint p1, EventMarkPoint p2)
            {
                if (p1.TimePoint.Equals(p2.TimePoint))
                {
                    if ((p1.Text.Contains("入室") || p1.Text.Contains("入手术室")) &&
                       !(p2.Text.Contains("入室") || p2.Text.Contains("入手术室")))
                    {
                        return -1;
                    }
                    else if ((p2.Text.Contains("入室") || p2.Text.Contains("入手术室")) &&
                            !(p1.Text.Contains("入室") || p1.Text.Contains("入手术室")))
                    {
                        return 1;
                    }
                    else if (p1.Text.Contains("出手术室") && p2.Text.Contains("麻醉结束"))
                    {
                        return 1;
                    }
                    else if (p2.Symbol != null && p1.Symbol == null)
                    {
                        return 1;
                    }
                    else if (p2.Symbol == null && p1.Symbol != null)
                    {
                        return -1;
                    }

                    return p1.Index.CompareTo(p2.Index);
                }
                else
                {
                    return p1.TimePoint.CompareTo(p2.TimePoint);
                }
            }));
        }
    }
}
