using System;
namespace MedicalSytem.Soft.Model
{
    public class MedBloodGasMaster
    {
        public string PatientId
        {
            get;
            set;
        }
        public Nullable<decimal> VisitId
        {
            get;
            set;
        }
        public Nullable<decimal> OperId
        {
            get;
            set;
        }
        public Nullable<DateTime> RecordDate
        {
            get;
            set;
        }
        public string NurseMemo1
        {
            get;
            set;
        }
        public string NurseMemo2
        {
            get;
            set;
        }
        public string DetailId
        {
            get;
            set;
        }
        public string Operator
        {
            get;
            set;
        }
        public Nullable<DateTime> OpDate
        {
            get;
            set;
        }
        public string Equipment
        {
            get;
            set;
        }
        public string Specimen
        {
            get;
            set;
        }
    }

    public class MedBloodGasDetail
    {
        public string DetailId
        {
            get;
            set;
        }
        public string BlgCode
        {
            get;
            set;
        }
        public string BlgValue
        {
            get;
            set;
        }
        public string Operator
        {
            get;
            set;
        }
        public Nullable<DateTime> OpDate
        {
            get;
            set;
        }
        public string AbnormalIndicator
        {
            get;
            set;
        }
    }


}