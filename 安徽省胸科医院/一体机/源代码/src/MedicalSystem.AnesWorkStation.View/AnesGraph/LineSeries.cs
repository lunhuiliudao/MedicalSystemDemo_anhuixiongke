using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System.Web;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    public class LineSeries
    {
        private Path _path = null;
        private PathGeometry _pathGeometry = new PathGeometry();
        private GeometryGroup _pathGroup;
        private List<DataPoint> _points;

        private int _index = 0;
        //private Dictionary<DateTime, DataPoint> _points = new Dictionary<DateTime, DataPoint>();

        private Axis _YAxis;
        private DateAxis _XAxis;
        private double _drawHeight;
        private double _pointWidth, _pointHeight;

        public Axis YAxis
        {
            get
            {
                return _YAxis;
            }
        }
        /// <summary>
        /// 表示一条曲线的路径
        /// </summary>
        public Path LinePath
        {
            get
            {
                return this._path;
            }
        }

        /// <summary>
        /// 曲线的颜色
        /// </summary>
        public Color LineColor
        {
            get
            {
                return ((SolidColorBrush)_path.Stroke).Color;
            }
            set
            {
                _path.Stroke = new SolidColorBrush(value);
            }
        }
        public List<DataPoint> Points
        {
            get { return _points; }
        }
        public double PointWidth
        {
            get
            {
                return _pointWidth;
            }
        }

        public LineSeries(DateAxis XAxis, Axis YAxis, double drawHeight)
        {
            _points = new List<DataPoint>();
            _XAxis = XAxis;
            _YAxis = YAxis;
            _drawHeight = drawHeight;
            _path = new Path();
            _path.StrokeThickness = 1.5;
            _path.Stroke = Brushes.DarkBlue;
            _pointWidth = _pointHeight = 8;
            var pathFigure = new PathFigure();

            pathFigure.Segments = new PathSegmentCollection();

            _pathGeometry.Figures = new PathFigureCollection();
            _pathGeometry.Figures.Add(pathFigure);

            _pathGroup = new GeometryGroup();
            _pathGroup.Children.Add(_pathGeometry);

            this._path.Data = _pathGroup;
        }


        public void MoveToNextFigure()
        {
            var currentFigures = _pathGeometry.Figures[_index];
            if (currentFigures.StartPoint.X == 0D && currentFigures.StartPoint.Y == 0D && currentFigures.Segments.Count == 0)
                return;        //当前未使用过则返回       

            var pathFigure = new PathFigure();
            pathFigure.Segments = new PathSegmentCollection();
            _pathGeometry.Figures.Add(pathFigure);
            _index++;
        }
        public DataPoint Point(DateTime time, double value, object Tag, SymbolType symbolType = SymbolType.Point)
        {
            DataPoint point = null;
            return point;
        }

        public void InsertDataPoint(DateTime time, double value, object Tag, MouseEventHandler MouseEnterHandler, MouseEventHandler MouseLeaveHandler, ref DataPoint point, SymbolType symbolType = SymbolType.Point)
        {
            bool isOverMin, isOverMax;
            var x = _XAxis.LocalTransform(time, out isOverMin, out isOverMax);
            if (isOverMin || isOverMax) //超过x轴范围返回
                return;
            double drawValue = value;
            if (drawValue > _YAxis.Max)
                drawValue = _YAxis.Max;
            else if (drawValue < _YAxis.Min)
                drawValue = _YAxis.Min;
            var y = _drawHeight - _YAxis.LocalTransform(drawValue);
            LineSegment lineSegment = null;
            PathFigure figure = null;
            var currentFigures = _pathGeometry.Figures[_index];

            DataPoint point1 = _points.Find(x1 => x1.Time == time.AddMinutes(-5));
            DataPoint point2 = _points.Find(x2 => x2.Time == time.AddMinutes(5));
            if (point1 != null && point2 == null)
            {
                lineSegment = new LineSegment();
                lineSegment.Point = new Point(x, y);
                for (int i = _points.IndexOf(point1); i >= 0; i--)
                {
                    if (_points[i].Figure != null)
                    {
                        currentFigures = _points[i].Figure;
                        break;
                    }
                }
                currentFigures.Segments.Add(lineSegment);
            }
            else if (point1 != null && point2 != null)
            {
                lineSegment = new LineSegment();
                lineSegment.Point = new Point(x, y);
                for (int i = _points.IndexOf(point1); i >= 0; i--)
                {
                    if (_points[i].Figure != null)
                    {
                        currentFigures = _points[i].Figure;
                        break;
                    }
                }
                currentFigures.Segments.Add(lineSegment);
                point2.Figure = null;
                point2.LineSegment = new LineSegment();
                point2.LineSegment.Point = new Point(point2.X, point2.Y);
                for (int i = _points.IndexOf(point2); i < _points.Count; i++)
                {
                    if (_points[i].Figure != null) break;
                    currentFigures.Segments.Add(_points[i].LineSegment);
                }
            }
            else if (point1 == null && point2 != null)
            {
                figure = point2.Figure;
                figure.Segments.Clear();
                figure.StartPoint = new Point(x, y);
                point2.Figure = null;
                point2.LineSegment = new LineSegment();
                point2.LineSegment.Point = new Point(point2.X, point2.Y);
                for (int i = _points.IndexOf(point2); i < _points.Count; i++)
                {
                    if (_points[i].Figure != null) break;
                    figure.Segments.Add(_points[i].LineSegment);
                }
            }
            else if (point1 == null && point2 == null)
            {
                figure = new PathFigure();
                figure.Segments = new PathSegmentCollection();
                _pathGeometry.Figures.Add(figure);
                _index++;
                figure.StartPoint = new Point(x, y);

            }

            Path path = Symbol.MakePath(symbolType, new Point(x, y), new Size(_pointWidth, _pointHeight), LineColor, Colors.White);
            path.Tag = Tag;
            path.StrokeThickness = 1.5;
            //path.RenderTransform = new TranslateTransform(1, 1);
            path.MouseEnter += MouseEnterHandler;
            path.MouseMove += MouseEnterHandler;
            path.MouseLeave += MouseLeaveHandler;

            Path path2 = Symbol.MakePath(SymbolType.CustomRectangle, new Point(x, y), new Size(_pointWidth, _pointHeight), LineColor, Colors.White);
            path2.Tag = Tag;
            path2.StrokeThickness = 1.5;
            //path.RenderTransform = new TranslateTransform(1, 1);
            path2.MouseEnter += MouseEnterHandler;
            path2.MouseMove += MouseEnterHandler;
            path2.MouseLeave += MouseLeaveHandler;
            point = new DataPoint(time, value, x, y, new List<FrameworkElement>() { path, path2 }, figure, lineSegment);
            _points.Add(point);
            _points = _points.OrderBy(p => p.Time).ToList();

        }

        /// <summary>
        ///添加坐标点 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="value"></param>
        public void AddDataPoint(DateTime time, double value, object Tag, MouseEventHandler MouseEnterHandler, MouseEventHandler MouseLeaveHandler, ref DataPoint point, SymbolType symbolType = SymbolType.Point)
        {
            VitalSignPointModel model = null;
            if(null != Tag && Tag is VitalSignPointModel)
            {
                model = Tag as VitalSignPointModel;
            }

            bool isOverMin, isOverMax;
            var x = _XAxis.LocalTransform(time, out isOverMin, out isOverMax);
            if (isOverMin || isOverMax) //超过x轴范围返回
                return;
            double drawValue = value;
            if (drawValue > _YAxis.Max)
                drawValue = _YAxis.Max;
            else if (drawValue < _YAxis.Min)
                drawValue = _YAxis.Min;
            var y = _drawHeight - _YAxis.LocalTransform(drawValue);

            var currentFigures = _pathGeometry.Figures[_index];
            LineSegment lineSegment = null;
            PathFigure figure = null;
            //添加基本坐标点
            if (currentFigures.StartPoint.X == 0D && currentFigures.StartPoint.Y == 0D && currentFigures.Segments.Count == 0)
            {
                figure = _pathGeometry.Figures[_index];
                figure.StartPoint = new Point(x, y);
            }
            else
            {
                //坐标点
                lineSegment = new LineSegment();
                lineSegment.Point = new Point(x, y);
                currentFigures.Segments.Add(lineSegment);
            }

            //添加点
            string pathText = model == null ? "" : model.Symbol.Text;
            Path path = Symbol.MakePath(symbolType, new Point(x, y), new Size(_pointWidth, _pointHeight), LineColor, Colors.White, false, pathText);
            path.Tag = Tag;
            path.StrokeThickness = 1.5;
            //path.RenderTransform = new TranslateTransform(1, 1);
            path.MouseEnter += MouseEnterHandler;
            path.MouseMove += MouseEnterHandler;
            path.MouseLeave += MouseLeaveHandler;

            Path path2 = Symbol.MakePath(SymbolType.CustomRectangle, new Point(x, y), new Size(_pointWidth, _pointHeight), LineColor, Colors.White);
            path2.Tag = Tag;
            path2.StrokeThickness = 1.5;
            //path.RenderTransform = new TranslateTransform(1, 1);
            path2.MouseEnter += MouseEnterHandler;
            path2.MouseMove += MouseEnterHandler;
            path2.MouseLeave += MouseLeaveHandler;
            point = new DataPoint(time, value, x, y, new List<FrameworkElement>() { path, path2 }, figure, lineSegment);
            _points.Add(point);
            _points = _points.OrderBy(p => p.Time).ToList();
            //_points[time] = new DataPoint
            //{
            //    Time = time,
            //    Value = value,
            //    X = x,
            //    Y = y
            //};
        }

        /// <summary>
        /// 清空曲线上的所有点
        /// </summary>
        public void ClearPoints()
        {
            _points.Clear();
            _pathGeometry.Figures.Clear();
        }
        ///// <summary>
        ///// 获取所有的数据坐标点
        ///// </summary>
        //public DataPoint[] Points
        //{
        //    get
        //    {
        //        return _points.Values.ToArray();
        //    }
        //}
        ///// <summary>
        ///// 是否存在X轴坐标对应的数据坐标点
        ///// </summary>
        ///// <param name="x"></param>
        ///// <returns></returns>
        //public bool Contains(DateTime timePoint)
        //{
        //    return _points.ContainsKey(timePoint);
        //}
        public bool Contains()
        {
            return _points.Exists(s => s.DataUIElements != null && s.DataUIElements.Exists(i => i.IsMouseOver));
        }
        /// <summary>
        /// 返回X轴坐标所对应的坐标数据点
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public DataPoint GetDataPoint()
        {
            return _points.Find(s => s.DataUIElements != null && s.DataUIElements.Exists(i => i.IsMouseOver));
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            set;
            //get
            //{
            //    return _path.Name;
            //}
            //set
            //{
            //    _path.Name = value;
            //}
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        private string _stringFormat = "F0";
        /// <summary>
        /// 表示Y值的StringFormat
        /// </summary>
        public string StringFormat
        {
            get
            {
                return _stringFormat;
            }
            set
            {
                _stringFormat = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Marker { get; set; }


    }
}
