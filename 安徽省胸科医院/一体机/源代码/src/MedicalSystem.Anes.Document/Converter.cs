using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document
{
    public class Converter
    {
        /// <summary>
        /// 获取双字节的低位字节
        /// </summary>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static int GETLOWORD(int lParam)
        {
            return (lParam & 0xffff);
        }

        /// <summary>
        /// 获取双字节的高位字节
        /// </summary>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static int GETHIWORD(int lParam)
        {
            return (lParam >> 16);
        }

        /// <summary>
        /// 数值转时间
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTime HourToHHMM(float hour)
        {
            DateTime dt = DateTime.FromOADate(hour / 24);
            return dt;
        }

        /// <summary>
        /// 时间转数值
        /// </summary>
        /// <param name="hhmm"></param>
        /// <returns></returns>
        public static float HHMMToHour(DateTime hhmm)
        {
            float dt = (float)(hhmm.ToOADate() * 24);
            return dt;
        }

        /// <summary>
        /// 日期时间转小时分钟
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime DateTimeToHHMM(DateTime dt)
        {
            //DateTime minDate = new DateTime(1900, 1, 1);
            ///因为这里的MinValue涉及到最后把日期转换成float，这里的MinValue不要改
            DateTime minDate = DateTime.MinValue;
            return new DateTime(minDate.Year, minDate.Month, minDate.Day, dt.Hour, dt.Minute, dt.Second);
        }

        /// <summary>
        /// 日期时间转小时分钟2
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime DateTimeToHHMM2(DateTime dt, double hours)
        {
            DateTime minDate = new DateTime(1900, 1, 1);
            DateTime converTime = new DateTime(minDate.Year, minDate.Month, minDate.Day, dt.Hour, dt.Minute, dt.Second);
            return converTime.AddHours(hours);
        }

        /// <summary>
        /// 字符转整数
        /// </summary>
        /// <param name="intString"></param>
        /// <returns></returns>
        public static int GetInt(object obj)
        {
            int ret;
            if (Int32.TryParse(obj.ToString().Trim(), out ret)) return ret; else return -1;
        }

        /// <summary>
        /// 字符转日期
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(object obj)
        {
            DateTime ret;
            if (DateTime.TryParse(obj.ToString(), out ret)) return ret; else return new DateTime(1900, 1, 1);
        }

    }

}
