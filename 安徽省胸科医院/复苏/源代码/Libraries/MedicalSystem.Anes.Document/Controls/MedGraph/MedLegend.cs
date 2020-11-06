using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    public class MedLegend
    {
        private Rectangle _rect = new Rectangle();
        private Pen _pen = new Pen(Color.Black);
        private Brush _bursh = new Pen(Color.FromArgb(243,243,243)).Brush;
        private bool _hasborder = true;
        private int _colcount = 4;
        private List<Rectangle> itemRects = new List<Rectangle>();
        private bool _alignYAxis = true;

        public Rectangle Rect { get { return _rect; } set { _rect = value; } }
        public Pen Pen { get { return _pen; } set { _pen = value; } }
        public Brush Brush { get { return _bursh; } set { _bursh = value; } }
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
    }
}
