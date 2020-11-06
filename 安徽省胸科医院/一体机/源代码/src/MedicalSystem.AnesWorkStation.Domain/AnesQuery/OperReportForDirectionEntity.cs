using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{

    /// <summary>
    /// add by xiaopei.y@2017-07-7 16:26:42   主任手术统计ECHART下方统计 实体类
    /// </summary>
    public class OperReportForDirectionEntity
    {
        
       
        /// <summary>
        /// 手术总数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 平均每日手术量
        /// </summary>
        public int DayAvgCount { get; set; }
        /// <summary>
        /// 手术最多日
        /// </summary>
        public string MostOperDate { get; set; }
        /// <summary>
        /// 手术最多日数量
        /// </summary>
        public int MostOperCount { get; set; }
        /// <summary>
        /// 手术最少日
        /// </summary>
        public string LeastOperDate { get; set; }
        /// <summary>
        /// 手术最少日数量
        /// </summary>
        public int LeastOperCount { get; set; }
        /// <summary>
        /// 周末手术数量
        /// </summary>
        public int WeekOperCount { get; set; }
        /// <summary>
        /// 急症数量
        /// </summary>
        public int EmergencyCount { get; set; }
       
       
    }
}
