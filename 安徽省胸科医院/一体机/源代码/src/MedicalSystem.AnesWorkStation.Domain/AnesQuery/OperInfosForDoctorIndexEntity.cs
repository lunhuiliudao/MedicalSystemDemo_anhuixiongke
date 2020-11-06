using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{

    /// <summary>
    /// add by xiaopei.y@2017-06-23 16:26:42   医生首页手术间信息集中统计 实体类
    /// </summary>
    public class OperInfosForDoctorIndexEntity
    {
        /// <summary>
        /// 当日手术总数
        /// </summary>
        public int DayTotalCount { get; set; }
        ///<summary>
        ///当日未完成
        ///</summary>
        public int DayBeforeOperCount { get; set; }
        /// <summary> 
        /// 成手术总数
        /// </summary>
        public int DayCompletedCount { get; set; }
        /// <summary>
        /// 当日入ICU手术总数
        /// </summary>
        public int DayToICUCount { get; set; }
        /// <summary>
        /// 当日手术中总数
        /// </summary>
        public int DayOperatingCount { get; set; }
        /// <summary>
        /// 当日复苏>=2小时手术总数
        /// </summary>
        public int PacuCount { get; set; }
        /// <summary>
        /// 当月手术总数
        /// </summary>
        public int MonthTotalCount { get; set; }
        /// <summary>
        /// 当日手术总时长
        /// </summary>
        public decimal MonthTotalTime { get; set; }
        /// <summary>
        /// 抢救台数
        /// </summary>
        public int RescueCount { get; set; }
        /// <summary>
        /// 急诊台数
        /// </summary>
        public int EmergencyCount { get; set; }
        ///<summary>
        ///明日总台数
        ///</summary>
        public int TomorrowTotalCount { get; set; }
        ///<summary>
        ///昨日总台数
        ///</summary>
        public int YesterdayTotalCount { get; set; }
        ///<summary>
        ///昨日急诊
        ///</summary>
        public int YesterdayEmergencyCount { get; set; }
        ///<summary>
        ///昨日复苏时长》=2H
        ///</summary>
        public int YesterdayPacuCount { get; set; }
        ///<summary>
        ///昨日转ICU
        ///</summary>
        public int YesterdayToICUCount { get; set; }
        ///<summary>
        ///昨日非预期事件
        ///</summary>
        public int YesterdayUnExpectCount { get; set; }
    }
}
