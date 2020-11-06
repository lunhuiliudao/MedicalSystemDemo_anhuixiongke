using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document
{
    public class DateTimeRange
    {
        public DateTime StartDateTime;
        public DateTime EndDateTime;
        public DateTimeRange(DateTime startDateTime, DateTime endDateTime)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public DateTime OrigiStartDateTime; 
        public DateTime OrigiEndDateTime;
    }
}
