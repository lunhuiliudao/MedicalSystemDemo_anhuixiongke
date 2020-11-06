using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{

    /// <summary>
    /// add by xiaopei.y@2017-06-23 16:26:42   医生首页手术间信息集中统计 实体类
    /// </summary>
    public class OperInfosForDirectorIndexEntity
    {
        
       
        /// <summary>
        /// 今日手术总数
        /// </summary>
        public int TodayTotalCount { get; set; }
        /// <summary>
        /// 今日完成手术总数
        /// </summary>
        public int TodayCompletedCount { get; set; }
        /// <summary>
        /// 今日手术中数量
        /// </summary>
        public int TodayOperatingCount { get; set; }
        /// <summary>
        /// 今日取消手术
        /// </summary>
        public int TodayCancelCount { get; set; }
        /// <summary>
        /// 今日待完成手术
        /// </summary>
        public int TodayWaitingCount { get; set; }
        /// <summary>
        /// 今日急诊台数
        /// </summary>
        public int TodayEmergencyCount { get; set; }
        /// <summary>
        /// 今日隔离感染台数
        /// </summary>
        public int TodayGLGRCount { get; set; }
        /// <summary>
        /// 今日手术抢救台数
        /// </summary>
        public int TodayRescueCount { get; set; }
        /// <summary>
        /// 今日死亡例数
        /// </summary>
        public int TodayDeathCount { get; set; }
        /// <summary>
        /// 今日非预期事件列数
        /// </summary>
        public int TodayUnExpectCount { get; set; }
        /// <summary>
        /// 今日术后转ICU台数
        /// </summary>
        public int TodayToICUCount { get; set; }
        /// <summary>
        /// 今日复苏时长≥2h
        /// </summary>
        public int TodayPacuCount { get; set; }
        /// <summary>
        /// 明日预约手术台数
        /// </summary>
        public int TomorrowTotalCount { get; set; }
        /// <summary>
        /// 昨天手术总数
        /// </summary>
        public int YesterdayTotalCount { get; set; }
        /// <summary>
        /// 昨天隔离感染台数
        /// </summary>
        public int YesterdayGLGRCount { get; set; }
        /// <summary>
        /// 昨天抢救台数
        /// </summary>
        public int YesterdayRescueCount { get; set; }
        /// <summary>
        /// 昨天术后转ICU台数
        /// </summary>
        public int YesterdayToICUCount { get; set; }
        /// <summary>
        /// 昨日复苏时长≥2h
        /// </summary>
        public int YesterdayPacuCount { get; set; }
       
    }
}
