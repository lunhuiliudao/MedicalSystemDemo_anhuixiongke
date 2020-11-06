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
    /// <summary>
    /// 数据时间点
    /// </summary>
    public class DataPoint
    {
        public DateTime Time { get; set; }

        public double Value { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public List<FrameworkElement> DataUIElements { get; set; }
        public PathFigure Figure { get; set; }
        public LineSegment LineSegment { get; set; }

        public string Name { get; set; }

        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool IsContinued
        {
            get
            {
                return BeginTime.HasValue;
            }            
        }

        public string Description { get; set; }

        public DataPoint()
        {

        }
        public DataPoint(DateTime Time, double Value, double X, double Y, List<FrameworkElement> DataUIElements, string Name = null, string Description = null)
        {
            this.Time = Time;
            this.Value = Value;
            this.X = X;
            this.Y = Y;
            this.DataUIElements = DataUIElements;
            this.Name = Name;
            this.Description = Description;
        }
        public DataPoint(DateTime Time, double Value, double X, double Y, FrameworkElement DataUIElement, string Name = null, string Description = null)
        {
            this.Time = Time;
            this.Value = Value;
            this.X = X;
            this.Y = Y;
            this.DataUIElements = new List<FrameworkElement>();
            DataUIElements.Add(DataUIElement);
            this.Name = Name;
            this.Description = Description;
        }
        public DataPoint(DateTime Time, double Value, double X, double Y, FrameworkElement DataUIElement, PathFigure figure, LineSegment lineSegment, string Name = null, string Description = null)
        {
            this.Time = Time;
            this.Value = Value;
            this.X = X;
            this.Y = Y;
            this.DataUIElements = new List<FrameworkElement>();
            DataUIElements.Add(DataUIElement);
            this.Name = Name;
            this.Description = Description;
            this.LineSegment = lineSegment;
            this.Figure = figure;
        }

        public DataPoint(DateTime Time, double Value, double X, double Y, List<FrameworkElement> DataUIElements, PathFigure figure, LineSegment lineSegment, string Name = null, string Description = null)
        {
            this.Time = Time;
            this.Value = Value;
            this.X = X;
            this.Y = Y;
            this.DataUIElements = DataUIElements;
            this.Name = Name;
            this.Description = Description;
            this.LineSegment = lineSegment;
            this.Figure = figure;
        }

        public DataPoint(DateTime BeginTime, DateTime? EndTime, List<FrameworkElement> DataUIElements, string Name, string Description)
        {
            this.BeginTime = BeginTime;
            this.EndTime = EndTime;
            this.DataUIElements = DataUIElements;
            this.Name = Name;
            this.Description = Description;
        }
    }
}
