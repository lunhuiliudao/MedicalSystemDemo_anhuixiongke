using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{

    [Serializable]
    public class CPBTimeItem
    {
        private DateTime _CPBStart;

        public DateTime CPBStart
        {
            get { return _CPBStart; }
            set { _CPBStart = value; }
        }

        private DateTime _CPBEnd;

        public DateTime CPBEnd
        {
            get { return _CPBEnd; }
            set { _CPBEnd = value; }
        }

        //20120926参照空总新增 
        private int _type = 0;
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
