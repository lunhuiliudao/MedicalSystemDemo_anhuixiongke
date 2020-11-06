using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class PatientContext
    {
        private string _patientID = "";
        public string PatientID
        {
            get
            {
                return _patientID;
            }
            set
            {
                _patientID = value;
            }
        }
        private int _VisitID;
        public int VisitID
        {
            get
            {
                return _VisitID;
            }
            set
            {
                _VisitID = value;
            }
        }
        private int _OperID;
        public int OperID
        {
            get
            {
                return _OperID;
            }
            set
            {
                _OperID = value;
            }
        }
    
    
    
    
    }
}
