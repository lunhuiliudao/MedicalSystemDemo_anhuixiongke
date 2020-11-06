using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MedPatMonitorData
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
        public Nullable<DateTime> TimePoint
        {
            get;
            set;
        }
        public string ItemCode
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
        public string ItemValue
        {
            get;
            set;
        }
        public string Units
        {
            get;
            set;
        }
        public string MonitorLabel
        {
            get;
            set;
        }
        public Nullable<DateTime> LogDateTime
        {
            get;
            set;
        }
        public string DataType
        {
            get;
            set;
        }
    }

    public class MedPatMonitorDataEXT
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
        public Nullable<DateTime> LastModifyDate
        {
            get;
            set;
        }
        public Nullable<DateTime> TimePoint
        {
            get;
            set;
        }
        public string ItemCode
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
        public string ItemValue
        {
            get;
            set;
        }
        public string Operator
        {
            get;
            set;
        }
        public string Reserved1
        {
            get;
            set;
        }
        public string Reserved2
        {
            get;
            set;
        }
        public string Reserved3
        {
            get;
            set;
        }
        public string Reserved4
        {
            get;
            set;
        }
        public string DataType
        {
            get;
            set;
        }
        public Nullable<decimal> DataMark
        {
            get;
            set;
        }
    }

}