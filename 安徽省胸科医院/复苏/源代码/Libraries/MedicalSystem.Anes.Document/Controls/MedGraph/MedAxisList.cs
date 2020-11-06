using System.Collections;

namespace MedicalSystem.Anes.Document.Controls
{
    public class MedAxisList: CollectionBase
    {
        private float _axisgap = 5;
        private int _minstep = 5;
        private System.Drawing.Pen _pen, _minpen;

        public MedAxisList(System.Drawing.Pen pen, System.Drawing.Pen minpen)
        {
            _pen = pen;
            _minpen = minpen;
        }

        public float AxisGap { get { return _axisgap; } set { _axisgap = value; } }
        public int MinSetp { get { return _minstep; } set { _minstep = value; } }
        public System.Drawing.Pen Pen { get { return _pen; } set { _pen = value; } }
        public System.Drawing.Pen MinPen { get { return _minpen; } set { _minpen = value; } }
        public MedAxis this[int index] { get { return (MedAxis)List[index]; } set { List[index] = value; } }

        public void Add(MedAxis axis) { List.Add(axis); }
        public float Width(System.Drawing.Graphics g)
        {
            float ret = 0;
            for (int i = 0; i < List.Count; i++) ret += _axisgap + this[i].Width(g);
            return ret;
        }
        public float Height(System.Drawing.Graphics g)
        {
            float ret = 0;
            for (int i = 0; i < List.Count; i++) ret += _axisgap + this[i].Height(g);
            return ret;
        }
    }
}
