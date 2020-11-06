namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 术后恢复情况记录表
    /// </summary>
    [Table("MED_ANESTHESIA_RECOVER")]
    public partial class MED_ANESTHESIA_RECOVER : BaseModel
    {
        /// <summary>
        /// 主键 病人ID;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数;住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号;一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 病人一般情况
        /// </summary>
        public string PATIENT_CONDITION { get; set; }
        /// <summary>
        /// 病人恢复情况
        /// </summary>
        public string RECOVER_CONDITION { get; set; }
        /// <summary>
        /// 离室意识;清醒、嗜睡、昏迷
        /// </summary>
        public string CONSCIOUSNESS { get; set; }
        /// <summary>
        /// 清醒时间
        /// </summary>
        public Nullable<DateTime> ENTIRE_REVIVAL_TIME { get; set; }
        /// <summary>
        /// 插管全麻;是、否
        /// </summary>
        public string GEN_ANES_TRACHEA { get; set; }
        /// <summary>
        /// 导管拔除;是、否
        /// </summary>
        public string PULL_PIPE { get; set; }
        /// <summary>
        /// 拔管时间
        /// </summary>
        public Nullable<DateTime> EXTUBATE_DATE { get; set; }
        /// <summary>
        /// 麻醉并发症;有、无
        /// </summary>
        public string ANES_HISTORY { get; set; }
        /// <summary>
        /// 麻醉并发症说明
        /// </summary>
        public string ANES_HISTORY_COND { get; set; }
        /// <summary>
        /// 特殊情况说明
        /// </summary>
        public string SPECIAL_CONDITION { get; set; }
        /// <summary>
        /// 术后麻醉医嘱
        /// </summary>
        public string ANES_ORDERS { get; set; }
        /// <summary>
        /// 离室麻醉医生
        /// </summary>
        public string ANES_DOCTOR { get; set; }
        /// <summary>
        /// 记录日期
        /// </summary>
        public DateTime RECORD_DATE { get; set; }
    }
}