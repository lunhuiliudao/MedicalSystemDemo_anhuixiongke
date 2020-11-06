using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedSheetCell
    {
        private object _value;
        [DisplayName("值")]
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        private  DateTime _timePoint;
        [Browsable(false)]
        public DateTime TimePoint
        {
            get
            {
                return _timePoint;
            }
            set
            {
                _timePoint = value;
            }
        }
        private int _colSpan = 1;
        [DisplayName("列跨度")]
        public int ColSpan
        {
            get
            {
                return _colSpan;
            }
            set
            {
                _colSpan = value;
            }
        }
        private Rectangle _drawRectangel;

        [Browsable(false)]
        public Rectangle DrawRectangel
        {
            get
            {
                return _drawRectangel;
            }

            set
            {
                _drawRectangel = value;
            }
        }


        private int _rowIndex;

        [Browsable(false)]
        public int RowIndex
        {
            get
            {
                return _rowIndex;
            }
        }

        internal void SetRowIndex(int rowIndex)
        {
            _rowIndex = rowIndex;
        }
    }
}
