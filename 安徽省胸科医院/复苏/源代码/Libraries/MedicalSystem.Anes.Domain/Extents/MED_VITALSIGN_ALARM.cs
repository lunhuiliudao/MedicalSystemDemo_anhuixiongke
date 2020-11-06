using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
    /// <summary>
    /// 体征预警信息合并表
    /// </summary>
    public class MED_VITALSIGN_ALARM
    {
        /// <summary>
        /// 主键 时间点
        /// </summary>
        public DateTime TIME_POINT { get; set; }
        /// <summary>
        /// 主键 项目编号	;对应体征项目代码表
        /// </summary>
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 采集项目名称	;冗余字段，为查询方便
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 采集项目值
        /// </summary>
        public string ITEM_VALUE { get; set; }
        /// <summary>
        /// 报警原因
        /// </summary>
        public string ALARM_REASON { get; set; }
        /// <summary>
        /// 预警范围
        /// </summary>
        public string ALARM_RANGE { get; set; }
    }
}
