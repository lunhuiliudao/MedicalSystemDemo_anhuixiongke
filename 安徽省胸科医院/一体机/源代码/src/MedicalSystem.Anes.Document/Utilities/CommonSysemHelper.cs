using MedicalSystem.Anes.Document.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Document
{
    public class CommonSysemHelper
    {
        public static bool SetLocalSystemDate(DateTime dt)
        {
            WinAPI.SYSTEMTIME st;

            st.year = (short)dt.Year;
            st.month = (short)dt.Month;
            st.dayOfWeek = (short)dt.DayOfWeek;
            st.day = (short)dt.Day;
            st.hour = (short)dt.Hour;
            st.minute = (short)dt.Minute;
            st.second = (short)dt.Second;
            st.milliseconds = (short)dt.Millisecond;

            return WinAPI.SetLocalTime(ref st);
        }
    }
}
