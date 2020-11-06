namespace MedicalSystem.Anes.Document.Controls
{
    public class MedAxis
    { 
        private float _max, _min, _step;
        private System.Drawing.Font _font;
        private System.Drawing.Brush _brush;
        private int _month = 0;
        private string _textformat = "";

        public MedAxis(System.Drawing.Font font, System.Drawing.Brush brush,float max, float min, float step)
        {
            _font = font;
            _max = max;
            _min = min;
            _step = step;
            _brush = brush;
        }

        public float Max { get { return _max; } set { _max = value; } }
        public float Min { get { return _min; } set { _min = value; } }
        public float Step { get { return _step; } set { _step = value; } }
        public System.Drawing.Font Font { get { return _font; } set { _font = value; } }
        public System.Drawing.Brush Brush { get { return _brush; } set { _brush = value; } }
        public string TextFormat { get { return _textformat; } set { _textformat = value; } }
        public int Month { get { return _month; } set { _month = value; } }

        public float Width(System.Drawing.Graphics g)
        {
            float wMax = g.MeasureString(_max.ToString(), _font).Width;
            float wMin = g.MeasureString(_min.ToString(), _font).Width;
            if (wMax > wMin) return wMax; else return wMin;
        }
        public float Height(System.Drawing.Graphics g)
        {
            return g.MeasureString("1", _font).Height;
        }
    }
}
