namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 报警消息
    /// </summary>
    [Table("MED_ANES_ALARM_MESSAGE")]
    public partial class MED_ANES_ALARM_MESSAGE : BaseModel
    {
                /// <summary>
        /// 主键 病人id
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 手术号
        /// </summary>
        public Nullable<Int32> OPER_ID { get; set; }
        /// <summary>
        /// 信息编号
        /// </summary>
        public string MSG_NO { get; set; }
        /// <summary>
        /// 主键 发生时间
        /// </summary>
        [Key]
        public DateTime MSG_TIME { get; set; }
        /// <summary>
        /// 读取标识
        /// </summary>
        public Nullable<Int32> READ_FLAG { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MSG { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public Nullable<DateTime> RECORD_TIME { get; set; }
        /// <summary>
        /// 报警CODE
        /// </summary>
        public string ALARM_ITEM { get; set; }
        /// <summary>
        /// 读取时间
        /// </summary>
        public Nullable<DateTime> READ_TIME { get; set; }

    }
}