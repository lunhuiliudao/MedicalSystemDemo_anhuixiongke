using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    public class Symbol
    {
        public static Path MakePath(SymbolType type, Point startPoint, Size size, Color StrokeColor, bool isLegend = false)
        {
            return MakePath(type, startPoint, size, StrokeColor, StrokeColor, isLegend);
        }
        public static Path MakePath(SymbolType type, Point startPoint, Size size, Color StrokeColor, Color FillColor, bool isLegend = false, string text = "")
        {
            Path path = new Path();
            path.Fill = new SolidColorBrush(Colors.Transparent);
            path.SnapsToDevicePixels = true;
            path.VerticalAlignment = VerticalAlignment.Top;
            path.HorizontalAlignment = HorizontalAlignment.Left;
            path.Stroke = new SolidColorBrush(StrokeColor);
            //path.StrokeThickness = 3;
            GeometryGroup group = new GeometryGroup();
            path.Data = group;
            PathGeometry geometry = new PathGeometry();
            geometry.Figures = new PathFigureCollection();
            PathFigure figure = new PathFigure();
            PathSegment segment;
            EllipseGeometry ellipse;
            double halfWidth = size.Width / 2 * 1.5;

            //ellipse = new EllipseGeometry(startPoint, halfWidth+5, halfWidth+5);           
            //group.Children.Add(ellipse);

            switch (type)
            {
                case SymbolType.Anesthesia:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth + size.Width / 4, startPoint.Y - halfWidth + size.Width / 4);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth - size.Width / 4, startPoint.Y + halfWidth - size.Width / 4), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth + size.Width / 4, startPoint.Y + halfWidth - size.Width / 4);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth - size.Width / 4, startPoint.Y - halfWidth + size.Width / 4), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    group.Children.Add(geometry);
                    break;
                case SymbolType.Circle:
                    path.Fill = new SolidColorBrush(FillColor);ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);
                    break;
                case SymbolType.CircleDot:
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);
                    ellipse = new EllipseGeometry(startPoint, 0.8, 0.8);
                    group.Children.Add(ellipse);
                    break;
                case SymbolType.CircleHArrow:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + size.Width / 4), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X + halfWidth, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y - size.Width / 4), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    group.Children.Add(geometry);
                    break;
                case SymbolType.CircleHLine:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth - 2, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth + 2, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.CirclePlus:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    group.Children.Add(geometry);
                    break;
                case SymbolType.CircleVArrow:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + size.Width / 4, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y + halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X - size.Width / 4, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    group.Children.Add(geometry);

                    break;
                case SymbolType.CircleVLine:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth - 2);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth + 2), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.CircleXCross:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth + size.Width / 4, startPoint.Y - halfWidth + size.Width / 4);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth - size.Width / 4, startPoint.Y + halfWidth - size.Width / 4), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth + size.Width / 4, startPoint.Y + halfWidth - size.Width / 4);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth - size.Width / 4, startPoint.Y - halfWidth + size.Width / 4), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    group.Children.Add(geometry);
                    break;
                case SymbolType.CircleXCrossDot:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth + size.Width / 4, startPoint.Y - halfWidth + size.Width / 4);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth - size.Width / 4, startPoint.Y + halfWidth - size.Width / 4), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth + size.Width / 4, startPoint.Y + halfWidth - size.Width / 4);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth - size.Width / 4, startPoint.Y - halfWidth + size.Width / 4), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);

                    ellipse = new EllipseGeometry(new Point(startPoint.X - halfWidth / 2, startPoint.Y), 0.5, 0.5);
                    group.Children.Add(ellipse);
                    ellipse = new EllipseGeometry(new Point(startPoint.X + halfWidth / 2, startPoint.Y), 0.5, 0.5);
                    group.Children.Add(ellipse);
                    ellipse = new EllipseGeometry(new Point(startPoint.X, startPoint.Y - halfWidth / 2), 0.5, 0.5);
                    group.Children.Add(ellipse);
                    ellipse = new EllipseGeometry(new Point(startPoint.X, startPoint.Y + halfWidth / 2), 0.5, 0.5);
                    group.Children.Add(ellipse);
                    break;
                case SymbolType.Diamond:
                    path.Fill = new SolidColorBrush(FillColor);
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X - halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.FillCircle:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);
                    break;
                case SymbolType.FillMiniCircle:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth / 2, halfWidth / 2);
                    group.Children.Add(ellipse);
                    break;
                case SymbolType.HDash:
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.Image:
                    break;
                case SymbolType.MachineAir:
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y + halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X - halfWidth * 2 / 3, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X - halfWidth / 3, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + halfWidth / 3, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + halfWidth * 2 / 3, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.MiniCircle:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth / 2, halfWidth / 2);
                    group.Children.Add(ellipse);
                    break;
                case SymbolType.MiniCircleLine:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth / 2, halfWidth / 2);
                    group.Children.Add(ellipse);
                    figure.StartPoint = new Point(startPoint.X - halfWidth / 2, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth * 1.6, startPoint.Y + halfWidth / 3), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.Operation:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.Plus:
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    group.Children.Add(geometry);
                    break;
                case SymbolType.Point:
                    ellipse = new EllipseGeometry(startPoint, 0.8, 0.8);
                    group.Children.Add(ellipse);
                    break;
                case SymbolType.PullPipe:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth * 0.6d, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y - 2);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X - halfWidth, startPoint.Y + 2), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X + halfWidth, startPoint.Y - 2);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + 2), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.PullPipe1:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth - 2);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth + 2), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.PutPipe:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth * 0.6d);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - 2, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + 2, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - 2, startPoint.Y + halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + 2, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.PutPipe1:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.PutPipe2:
                    path.Fill = new SolidColorBrush(FillColor);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);

                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y + halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.Square:
                    path.Fill = new SolidColorBrush(FillColor);
                    RectangleGeometry rect = new RectangleGeometry(new Rect(new Point(startPoint.X - halfWidth, startPoint.Y - halfWidth / 2), new Size(size.Width, halfWidth)));
                    group.Children.Add(rect);
                    break;
                case SymbolType.Star:
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y + halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.Text:
                    if (!string.IsNullOrEmpty(text))
                    {
                        path.Fill = new SolidColorBrush(FillColor);
                        FormattedText ft = new FormattedText(text, new System.Globalization.CultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("宋体"), 13, new SolidColorBrush(FillColor));
                        Geometry g = ft.BuildGeometry(new Point(startPoint.X - halfWidth + 3, startPoint.Y - size.Width - 1));
                        PathGeometry pg = g.GetFlattenedPathGeometry();
                        path.Data = pg;
                    }
                    break;
                case SymbolType.Triangle:
                    path.Fill = new SolidColorBrush(FillColor);
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X - halfWidth, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.TriangleDown:
                    path.Fill = new SolidColorBrush(FillColor);
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y + halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X - halfWidth, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.VDash:
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.VLetter:
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y - size.Width);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(startPoint, true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y - size.Width), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    if (isLegend)
                        path.Margin = new Thickness(0, halfWidth, 0, 0);
                    break;
                case SymbolType.VLetterDown:
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y + size.Width);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(startPoint, true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + size.Width), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    path.Fill = new SolidColorBrush(Colors.Transparent);
                    if (isLegend)
                        path.Margin = new Thickness(0, -halfWidth, 0, 0);
                    break;
                case SymbolType.VLetterDownLine:
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y + size.Width);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(startPoint, true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + size.Width), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.VLetterLine:
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y + halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.XCross:
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y + halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    group.Children.Add(geometry);
                    break;
                case SymbolType.XCrossVLine:
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X - halfWidth, startPoint.Y + halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y - halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    group.Children.Add(geometry);
                    break;
                //扩展画法
                case SymbolType.Ext_CircleInCircle:
                    path.Fill = new SolidColorBrush(FillColor);
                    //figure.StartPoint = startPoint;
                    //figure.IsClosed = true;
                    //figure.Segments = new PathSegmentCollection();
                    //segment = new ArcSegment(new Point(startPoint.X, startPoint.Y - 0.01), new Size(halfWidth, halfWidth), 0, true, SweepDirection.Clockwise, true);
                    //figure.Segments.Add(segment);
                    //geometry.Figures.Add(figure);
                    //group.Children.Add(geometry);

                    //double smallCircle = halfWidth * 0.5;
                    //geometry = new PathGeometry();
                    //geometry.Figures = new PathFigureCollection();
                    //figure = new PathFigure();
                    //figure.StartPoint = new Point(startPoint.X - smallCircle, startPoint.Y);
                    //figure.IsClosed = true;
                    //figure.Segments = new PathSegmentCollection();
                    //segment = new ArcSegment(new Point(startPoint.X - smallCircle, startPoint.Y - 0.01), new Size(halfWidth - smallCircle, halfWidth - smallCircle), 0, true, SweepDirection.Clockwise, true);
                    //figure.Segments.Add(segment);
                    //geometry.Figures.Add(figure);
                    //group.Children.Add(geometry);
                    ellipse = new EllipseGeometry(startPoint, halfWidth, halfWidth);
                    group.Children.Add(ellipse);
                    ellipse = new EllipseGeometry(startPoint, halfWidth * 0.5, halfWidth * 0.5);
                    group.Children.Add(ellipse);
                    break;
                case SymbolType.Ext_FillCircle:
                    path.Fill = new SolidColorBrush(FillColor);
                    figure.StartPoint = startPoint;
                    figure.IsClosed = true;
                    figure.Segments = new PathSegmentCollection();
                    segment = new ArcSegment(new Point(startPoint.X, startPoint.Y - 0.01), new Size(halfWidth, halfWidth), 0, true, SweepDirection.Clockwise, true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.Ext_Breath:
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y - halfWidth);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(startPoint, true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X - halfWidth, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);

                    figure = new PathFigure();
                    figure.StartPoint = startPoint;
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y + halfWidth), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.Ext_TriangleDown:
                    figure.StartPoint = new Point(startPoint.X, startPoint.Y + halfWidth * 0.9D);
                    figure.IsClosed = false;
                    figure.Segments = new PathSegmentCollection();
                    segment = new LineSegment(new Point(startPoint.X + halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X - halfWidth, startPoint.Y), true);
                    figure.Segments.Add(segment);
                    segment = new LineSegment(new Point(startPoint.X, startPoint.Y + halfWidth * 0.9D), true);
                    figure.Segments.Add(segment);
                    geometry.Figures.Add(figure);
                    group.Children.Add(geometry);
                    break;
                case SymbolType.CustomRectangle:
                    path.Fill = new SolidColorBrush(Colors.Transparent);
                    path.Stroke = new SolidColorBrush(Colors.Transparent);
                    double scale = 1.2;
                    RectangleGeometry rectangle = new RectangleGeometry(new Rect(new Point(startPoint.X - halfWidth * scale, startPoint.Y - halfWidth * scale), new Size(halfWidth * scale * 2, halfWidth * scale * 2)));
                    group.Children.Add(rectangle);
                    break;
            }
            return path;
        }
    }
}
