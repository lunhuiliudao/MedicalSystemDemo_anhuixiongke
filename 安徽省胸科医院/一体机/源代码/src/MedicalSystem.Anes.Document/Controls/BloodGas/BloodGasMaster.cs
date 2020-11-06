using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class BloodGasMaster
    {
        private string patientId;

        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        private int vistId;

        public int VistId
        {
            get { return vistId; }
            set { vistId = value; }
        }

        private int operId;

        public int OperId
        {
            get { return operId; }
            set { operId = value; }
        }

        private DateTime recorddate;

        public DateTime Recorddate
        {
            get { return recorddate; }
            set { recorddate = value; }
        }

        private DateTime operdate;

        public DateTime Operdate
        {
            get { return operdate; }
            set { operdate = value; }
        }

        private string detailId;

        public string DetailId
        {
            get { return detailId; }
            set { detailId = value; }
        }

        private string oper;

        public string Oper
        {
            get { return oper; }
            set { oper = value; }
        }

        private List<BloodGasDetail> details = new List<BloodGasDetail>();

        public List<BloodGasDetail> Details
        {
            get { return details; }
            set { details = value; }
        }

        private string _diaplayName = "";
        public string DisplayName
        {
            get
            {
                return _diaplayName;
            }
            set
            {
                _diaplayName = value;
            }
        }

    }
}
