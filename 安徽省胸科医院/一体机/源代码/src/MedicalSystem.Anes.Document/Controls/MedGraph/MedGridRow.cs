using System;
using System.Collections;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    public class MedGridRow : IDisposable
    {
        private MedPointList _points;
        private string _title;
        private int _datatype = 0;
        private System.Drawing.Pen _pen = new System.Drawing.Pen(System.Drawing.Color.Black);

        public MedPointList Points { get { lock (this) return _points; } set { lock (this) _points = value; } }
        public System.Drawing.Pen Pen { get { return _pen; } set { _pen.Dispose(); _pen = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public int DataType { get { return _datatype; } set { _datatype = value; } }

        public MedPointList SubPoints(float minvalue, float maxvalue)
        {
            MedPointList points = new MedPointList();
            foreach (MedPoint point in _points)
            {
                if ((point.X >= minvalue) && (point.X < maxvalue))
                {
                    points.Add(point.X, point.Y);
                }
            }
            return points;
        }

        #region IDisposable ³ÉÔ±

        public void Dispose()
        {
            if (_pen != null)
                _pen.Dispose();
        }

        #endregion
    }
}
