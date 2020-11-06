using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    public class MedLegend : IDisposable
    {
        private Rectangle _rect = new Rectangle();
        private Pen _pen;
        private Brush _bursh;
        private bool _hasborder = true;
        private int _colcount = 4;
        private List<Rectangle> itemRects = new List<Rectangle>();
        private bool _alignYAxis = true;

        public Rectangle Rect { get { return _rect; } set { _rect = value; } }
        public Pen Pen { get { if (_pen == null) { _pen = new Pen(Color.Black); } return _pen; } set { _pen.Dispose(); _pen = value; } }
        public Brush Brush { get { if (_bursh == null) { var p = new Pen(Color.FromArgb(243, 243, 243)); _bursh = p.Brush; p.Dispose(); } return _bursh; } set { _bursh.Dispose(); _bursh = value; } }
        public bool HasBorder { get { return _hasborder; } set { _hasborder = value; } }
        public int ColCount { get { return _colcount; } set { if (value > 0)_colcount = value; } }
        public List<Rectangle> ItemRects { get { return itemRects; } set { itemRects = value; } }
        public int ItemRectIndex = -1;
        public bool AlignYAxis
        {
            get
            {
                return _alignYAxis;
            }
            set
            {
                _alignYAxis = value;
            }
        }

        #region IDisposable ≥…‘±

        public void Dispose()
        {
            if (_pen != null)
                _pen.Dispose();
            if (_bursh != null)
                _bursh.Dispose();
        }

        #endregion
    }
}
