using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    public class VitalSignPointEventArgs : EventArgs
    {
        private MedVitalSignPoint _point;
        private DateTime _oldTimePoint;
        private double _oldValue;
        public MedVitalSignPoint Point
        {
            get
            {
                return _point;
            }
        }
        public DateTime OldTimePoint
        {
            get
            {
                return _oldTimePoint;
            }
        }
        public double OldValue
        {
            get
            {
                return _oldValue;
            }
        }
        public VitalSignPointEventArgs(MedVitalSignPoint point, DateTime oldTimePoint, double oldValue)
        {
            _oldTimePoint = oldTimePoint;
            _oldValue = oldValue;
            _point = point;
        }
    }
}
