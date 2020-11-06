using System;
using System.Collections.Generic;
using System.Text;


namespace MedicalSytem.Soft.Model
{
    public class MedDiagnosisDict : ModelBase
    {
        public string DiagnosisCode
        {
            get;
            set;
        }

        public string DiagnosisName
        {
            get;
            set;
        }
        public decimal StdIndicator
        {
            get;
            set;
        }
        public decimal ApprovedIndicator
        {
            get;
            set;
        }
        public DateTime CreateDate
        {
            get;
            set;
        }
        public string InputCode
        {
            get;
            set;
        }
        public string InffctIndicator
        {
            get;
            set;
        }
        public string HealthLevel
        {
            get;
            set;
        }
        public string InputCodeWb
        {
            get;
            set;
        }
        public string DiseaseSort
        {
            get;
            set;
        }
        public decimal DiagIndicator
        {
            get;
            set;
        }
    }
}
