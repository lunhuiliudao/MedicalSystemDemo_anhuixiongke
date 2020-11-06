using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 事件标识-点
    /// </summary>
    public class EventMarkPoint
    {
        #region 变量
        private int _index;
        private string _text;
        private MedSymbol _symbol;
        private DateTime _timePoint;
        private float _X, _Y;
        #endregion 变量

        #region 属性
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

        public MedSymbol Symbol
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
        public float X
        {
            get
            {
                return _X;
            }
            set
            {
                _X = value;
            }
        }
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
        private Color _color;
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
        #endregion 属性
        #region 方法

        public EventMarkPoint(DateTime timePoint, int index, string text, MedSymbol symbol, Color color, string alias)
        {
            _index = index;
            _timePoint = timePoint;
            _symbol = symbol;
            _text = text;
            _color = color;
            _alias = alias;
        }
        #endregion 方法
    }

    /// <summary>
    /// 事件标识
    /// </summary>
    public class EventMark : IDisposable
    {
        #region 变量
        private string _title;
        private List<EventMarkPoint> _points = new List<EventMarkPoint>();
        private Font _font = new Font("宋体", 10);
        private Color _color = Color.Black;
        #endregion 变量
        #region 属性
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
        public List<EventMarkPoint> Points
        {
            get
            {
                return _points;
            }
        }
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
        #endregion 属性
        #region 方法
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
        public void AddPoint(DateTime timePoint, int index, string text, MedSymbol symbol, Color color, string alias)
        {
            //if(IndexOf(timePoint) >= 0)
            //{
            //    throw new Exception("该时间点已存在");
            //}
            _points.Add(new EventMarkPoint(timePoint, index, text, symbol, color, alias));
        }
        public MedSymbol GetSymbol(DateTime timePoint)
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
        public void RemovePoint(DateTime timePoint)
        {
            int index = IndexOf(timePoint);
            if (index >= 0)
            {
                _points.RemoveAt(index);
            }
        }
        public void ClearPoints()
        {
            _points.Clear();
        }
        public void DrawPoint(Graphics g, int index, float X, float Y)
        {
            if (_points[index].Index > 0)
            {
                string text = _points[index].Index.ToString();
                g.DrawString(text, _font, new SolidBrush(_points[index].Color), X, Y);
            }
            else
            {
                float ps = _points[index].Symbol.Size / 2;
                if (ps < 5)
                {
                    ps = 5;
                }
                _points[index].Symbol.Draw(g, X + ps, Y + ps);
            }
        }

        public void ReSort()
        {
            Points.Sort(new Comparison<EventMarkPoint>(delegate(EventMarkPoint p1, EventMarkPoint p2)
                {
                    //if (p2.Symbol != null && p1.Symbol == null) return 1;
                    //else if (p2.Symbol == null && p1.Symbol != null) return -1;
                    //else if (p1.TimePoint.Equals(p2.TimePoint)) return p1.Index.CompareTo(p2.Index);
                    //else return p1.TimePoint.CompareTo(p2.TimePoint);
                    if (p1.TimePoint.Equals(p2.TimePoint))
                    {
                        if (p2.Symbol != null && p1.Symbol == null) return 1;
                        else if (p2.Symbol == null && p1.Symbol != null) return -1;
                        return p1.Index.CompareTo(p2.Index);
                    }
                    else return p1.TimePoint.CompareTo(p2.TimePoint);
                }));
        }

        #endregion 方法

        #region IDisposable 成员

        public void Dispose()
        {
            _font.Dispose();
        }

        #endregion
    }
}
