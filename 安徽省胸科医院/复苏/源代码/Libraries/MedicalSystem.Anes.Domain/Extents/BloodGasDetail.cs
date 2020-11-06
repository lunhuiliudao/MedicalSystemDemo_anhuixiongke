using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
    [Serializable]
    public class BloodGasDetail
    {
        private string detailId;

        public string DetailId
        {
            get { return detailId; }
            set { detailId = value; }
        }

        private string bloodGasCode;

        public string BloodGasCode
        {
            get { return bloodGasCode; }
            set { bloodGasCode = value; }
        }

        private string bloodGasName;

        public string BloodGasName
        {
            get
            {
                if (string.IsNullOrEmpty(bloodGasName))
                {
                    return BloodGasCode;
                }
                else
                {
                    return bloodGasName;
                }
            }
            set { bloodGasName = value; }
        }

        private string bloodGasValue;

        public string BloodGasValue
        {
            get { return bloodGasValue; }
            set { bloodGasValue = value; }
        }

        private string oper;

        public string Oper
        {
            get { return oper; }
            set { oper = value; }
        }

        private DateTime operdate;

        public DateTime Operdate
        {
            get { return operdate; }
            set { operdate = value; }
        }
    }
}
