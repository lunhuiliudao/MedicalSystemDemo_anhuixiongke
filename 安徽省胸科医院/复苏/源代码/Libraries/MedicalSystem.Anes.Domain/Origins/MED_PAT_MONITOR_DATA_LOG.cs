namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 体征修改日志表(手术后再修改)
    /// </summary>
    [Table("MED_PAT_MONITOR_DATA_LOG")]
    public partial class MED_PAT_MONITOR_DATA_LOG : BaseModel
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
        /// 主键 修改时间
        /// </summary>
        [Key]
        public DateTime MODIFY_DATE { get; set; }
        /// <summary>
        /// 主键 项目编号
        /// </summary>
        [Key]
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 时间点
        /// </summary>
        public DateTime TIME_POINT { get; set; }
        /// <summary>
        /// 结果值
        /// </summary>
        public string NEW_VALUE { get; set; }
        /// <summary>
        /// 原值值
        /// </summary>
        public string OLD_VALUE { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string OPERATOR { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public string RESERVED4 { get; set; }
    }
}