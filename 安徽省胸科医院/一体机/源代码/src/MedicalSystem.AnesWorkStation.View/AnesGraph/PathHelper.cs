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
    public class PathHelper
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        public struct POINT
        {
            public int X;
            public int Y;
            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        public static POINT GetCursorPos()
        {
            POINT p = new POINT();
            PathHelper.GetCursorPos(out p);
            return p;
        }
        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="thickness"></param>
        /// <param name="rowBrush"></param>
        /// <returns></returns>
        public static Rectangle DrawRectangle(double width, double height, Thickness thickness, Brush rowBrush)
        {
            Rectangle rowRectangle = new Rectangle();
            if (width > 0)
                rowRectangle.Width = width;
            if (height > 0)
                rowRectangle.Height = height;
            rowRectangle.Stroke = rowBrush;
            rowRectangle.Fill = rowBrush;
            rowRectangle.VerticalAlignment = VerticalAlignment.Top;
            rowRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            rowRectangle.Margin = thickness;
            return rowRectangle;
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="thickness"></param>
        /// <param name="rowBrush"></param>
        /// <returns></returns>
        public static Rectangle DrawRectangle(double width, double height, Thickness thickness, Brush StrokeBrush, Brush rowBrush)
        {
            Rectangle rowRectangle = new Rectangle();
            if (width > 0)
                rowRectangle.Width = width;
            if (height > 0)
                rowRectangle.Height = height;
            rowRectangle.Stroke = StrokeBrush;
            rowRectangle.Fill = rowBrush;
            rowRectangle.VerticalAlignment = VerticalAlignment.Top;
            rowRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            rowRectangle.Margin = thickness;
            return rowRectangle;
        }

        /// <summary>
        /// 绘制实线
        /// </summary>
        /// <param name="StartP"></param>
        /// <param name="EndP"></param>
        /// <param name="LineColor"></param>
        /// <param name="StrokeThickness"></param>
        /// <returns></returns>
        public static Path DrawLine(Point StartP, Point EndP, Color LineColor, double StrokeThickness)
        {
            return DrawLine(StartP, EndP, LineColor, StrokeThickness, false, null);
        }

        /// <summary>
        /// 绘制虚线
        /// </summary>
        /// <param name="StartP"></param>
        /// <param name="EndP"></param>
        /// <param name="LineColor"></param>
        /// <param name="StrokeThickness"></param>
        /// <returns></returns>
        public static Path DrawLine(Point StartP, Point EndP, Color LineColor, double StrokeThickness, DoubleCollection DashArray)
        {
            return DrawLine(StartP, EndP, LineColor, StrokeThickness, true, DashArray);
        }

        /// <summary>
        /// 绘制线条
        /// </summary>
        /// <param name="StartP"></param>
        /// <param name="EndP"></param>
        /// <param name="LineColor"></param>
        /// <param name="StrokeThickness"></param>
        /// <param name="IsDash"></param>
        /// <param name="DashArray"></param>
        /// <returns></returns>
        private static Path DrawLine(Point StartP, Point EndP, Color LineColor, double StrokeThickness, bool IsDash, DoubleCollection DashArray)
        {
            Path line = new Path();
            line.SnapsToDevicePixels = true;
            PathGeometry VLineGeometry = new PathGeometry();
            VLineGeometry.Figures = new PathFigureCollection();
            PathFigure aPathFigure = new PathFigure();
            aPathFigure.StartPoint = StartP;
            aPathFigure.Segments = new PathSegmentCollection() { new LineSegment(EndP, true) };
            VLineGeometry.Figures.Add(aPathFigure);
            line.Data = VLineGeometry;
            line.StrokeThickness = StrokeThickness;
            line.Stroke = new SolidColorBrush(LineColor);
            if (IsDash)
                line.StrokeDashArray = DashArray; //虚线
            return line;
        }

        public static double MeasureTextWidth(string text, double fontSize, string fontFamily)
        {
            return MeasureTextWidth(text, fontSize, fontFamily, FontWeights.Normal);
        }
        public static double MeasureTextWidth(string text, double fontSize, string fontFamily, FontWeight weight)
        {
            FormattedText formattedText = new FormattedText(
            text,
            System.Globalization.CultureInfo.InvariantCulture,
            FlowDirection.LeftToRight,
            new Typeface(fontFamily.ToString()),
            fontSize,
            Brushes.Black
            );
            formattedText.SetFontWeight(weight);
            return formattedText.WidthIncludingTrailingWhitespace;
        }
        public static double MeasureTextHeight(string text, double fontSize, string fontFamily)
        {
            return MeasureTextHeight(text, fontSize, fontFamily, FontWeights.Normal);
        }
        public static double MeasureTextHeight(string text, double fontSize, string fontFamily, FontWeight weight)
        {
            FormattedText formattedText = new FormattedText(
            text,
            System.Globalization.CultureInfo.InvariantCulture,
            FlowDirection.LeftToRight,
            new Typeface(fontFamily.ToString()),
            fontSize,
            Brushes.Black
            );
            formattedText.SetFontWeight(weight);
            return formattedText.Height;
        }

        public static System.Windows.Media.Color ConvertToMediaColor(System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);    
        }
    }
}
