using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    public class DataPointMarker : FrameworkElement
    {
        private VisualCollection _children = null;

        public DataPointMarker()
        {
            _children = new VisualCollection(this);
        }


        public void AddPointMarker(LineSeries lineSeries)
        {
            var drawingVisual = new DrawingVisual();

            using (var drawingContext = drawingVisual.RenderOpen())
            {
                foreach (var point in lineSeries.Points)
                {
                    drawingContext.DrawText(new FormattedText(lineSeries.Marker, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal), 15, new SolidColorBrush(lineSeries.LineColor)), new Point(point.X - 5.0, point.Y - 9));
                }
                drawingContext.Close();
            }
            _children.Add(drawingVisual);
        }
        protected override int VisualChildrenCount
        {
            get
            {
                return _children.Count;
            }

        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _children[index];

        }

        public void Clear()
        {
            this._children.Clear();

        }
    }
}
