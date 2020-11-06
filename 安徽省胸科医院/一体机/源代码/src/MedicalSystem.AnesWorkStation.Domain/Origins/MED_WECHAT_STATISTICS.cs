using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain.Origins
{

    /// <summary>
    /// 实体 统计查询表
    /// </summary>
    [Table("MED_WECHAT_STATISTICS")]
    public class MED_WECHAT_STATISTICS : BaseModel
    {
        /// <summary>
        /// 主键 GUID,系统自动生成	
        /// </summary>
        [Key]
        public string STATISTICS_ID { get; set; }

        /// <summary>
        /// 医院ID，唯一标识
        /// </summary>
        public string HOSPITAL_ID { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public string CHILD_MENU { get; set; }

        /// <summary>
        /// 年月份
        /// </summary>
        public string REPORT_MONTH { get; set; }

        /// <summary>
        /// JSON数据
        /// </summary>
        public string JSON_DATA { get; set; }

        /// <summary>
        /// 接受时间
        /// </summary>
        public DateTime? RECIVE_DATE { get; set; }

    }
}
