using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Model.Utilities
{

    public static class DateDiff
    {

        private static DateDifference dateDifference = null;
        public static string CalAge(DateTime fromDate, DateTime toDate)
        {
            if (string.IsNullOrEmpty(fromDate.ToString()) || string.IsNullOrEmpty(toDate.ToString()) || fromDate == DateTime.MinValue)
            {
                return null;
            }
            if (dateDifference == null)
            {
                dateDifference = new DateDifference();
            }
            //计算年龄
            dateDifference.CalAge(fromDate, toDate);

            if (dateDifference.Years > 0)
            {
                return dateDifference.Years + "岁";
            }
            else if (dateDifference.Months > 0)
            {
                if (dateDifference.Days == 0)
                {
                    return dateDifference.Months + "月";
                }
                else
                {
                    return dateDifference.Months + "月" + dateDifference.Days + "天";
                }

            }
            else
            {
                if (dateDifference.Days == 0)
                {
                    return "1天";
                }
                else
                {
                    return dateDifference.Days + "天";
                }

            } 
        }
        public static string ShowDay(int y, int m, int d)
        {
            if (m == 1) m = 13;
            if (m == 2) m = 14;
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;
            string weekstr = "";
            switch (week)
            {
                case 1: weekstr = "星期一"; break;
                case 2: weekstr = "星期二"; break;
                case 3: weekstr = "星期三"; break;
                case 4: weekstr = "星期四"; break;
                case 5: weekstr = "星期五"; break;
                case 6: weekstr = "星期六"; break;
                case 7: weekstr = "星期日"; break;
            } 
             string day = y + "年" + m + "月" + d + "日 " + weekstr;
            return day;
        }
    }
    internal class DateDifference
    {
        /// <summary>
        /// 定义天数
        /// 二月在计算中会重定义，用-1先定义
        /// </summary>
        private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

 
        private DateTime fromDate;


        private DateTime toDate;


        private int year;
        private int month;
        private int day;
        private int hours;

        public void CalAge(DateTime d1, DateTime d2)
        {

            int increment;

            if (d1 > d2)
            {
                this.fromDate = d2;
                this.toDate = d1;
            }
            else
            {
                this.fromDate = d1;
                this.toDate = d2;
            }

            //计算小时
            TimeSpan timespan = this.toDate - this.fromDate;
            
            this.hours = timespan.Hours;

            /// 
            /// 计算日
            /// 
            increment = 0;

            if (this.fromDate.Day > this.toDate.Day)
            {
                increment = this.monthDay[this.fromDate.Month - 1];

            }
            /// 二月
            if (increment == -1)
            {
                if (DateTime.IsLeapYear(this.fromDate.Year))
                {
                    // 闰月
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }
            if (increment != 0)
            {
                day = (this.toDate.Day + increment) - this.fromDate.Day;
                increment = 1;
            }
            else
            {
                day = this.toDate.Day - this.fromDate.Day;
            }

            ///
            ///计算月
            ///
            if ((this.fromDate.Month + increment) > this.toDate.Month)
            {
                this.month = (this.toDate.Month + 12) - (this.fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                this.month = (this.toDate.Month) - (this.fromDate.Month + increment);
                increment = 0;
            }

            ///
            /// year calculation
            ///
            if ((this.toDate.Year - this.fromDate.Year) > 7)
            {
                this.year = this.toDate.Year - this.fromDate.Year;
            }
            else
            {
                this.year = this.toDate.Year - (this.fromDate.Year + increment);
            }
        }
      
        public override string ToString()
        {
            //return base.ToString();
            return this.year + " 年, " + this.month + "月, " + this.day + " 天";
        }

        public int Years
        {
            get
            {
                return this.year;
            }
        }

        public int Months
        {
            get
            {
                return this.month;
            }
        }

        public int Days
        {
            get
            {
                return this.day;
            }
        }

        public int Hours
        {
            get
            {
                return this.hours;
            }
        }

    }
}