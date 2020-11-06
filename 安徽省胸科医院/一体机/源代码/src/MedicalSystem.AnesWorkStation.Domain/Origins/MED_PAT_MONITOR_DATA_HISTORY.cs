namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;

    /// <summary>
    /// 实体 密集体征数据采集表
    /// </summary>
    [Table("MED_PAT_MONITOR_DATA_HISTORY")]
    public partial class MED_PAT_MONITOR_DATA_HISTORY : BaseModel
    {
        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 时间点
        /// </summary>
        [Key]
        public DateTime TIME_POINT { get; set; }
        /// <summary>
        /// 主键 项目编号	;对应体征项目代码表
        /// </summary>
        [Key]
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
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 仪器标示
        /// </summary>
        public string MONITOR_LABEL { get; set; }
        /// <summary>
        /// 记录日期
        /// </summary>
        public Nullable<DateTime> LOG_DATE_TIME { get; set; }
        /// <summary>
        /// 0-手术、1-术后复苏、4-术前诱导；8=产房
        /// </summary>
        public string DATA_TYPE { get; set; }
    }
}