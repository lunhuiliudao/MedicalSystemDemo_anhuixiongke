using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Utilities
{
    public static class DateDiff
    {
        private static DateDifference dateDifference = null;
        public static string CalAge(DateTime fromDate, DateTime toDate)
        {
            if (fromDate == DateTime.MinValue || fromDate == DateTime.MaxValue || fromDate == null)
                return "";
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
        public static string ShowDay(DateTime dayNow)
        {
            string day = dayNow.Year + "年" + dayNow.Month + "月" + dayNow.Day + "日 " + Week(dayNow);
            return day;
        }
        public static string Week(DateTime dayNow)
        {
            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = weekdays[Convert.ToInt32(dayNow.DayOfWeek)];

            return week;
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
            if ((this.toDate.Year - this.fromDate.Year) > 3)
            {
                this.year = this.toDate.Year - this.fromDate.Year;
                DateTime now = DateTime.Today;
                if (fromDate > now.AddYears(-this.year)) this.year--;
            }
            else
            {
                this.year = this.toDate.Year - (this.fromDate.Year + increment);
            }
        }

        public override string ToString()
        {
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