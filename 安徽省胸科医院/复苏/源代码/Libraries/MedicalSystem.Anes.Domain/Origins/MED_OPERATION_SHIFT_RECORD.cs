namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 交班记录表
    /// </summary>
    [Table("MED_OPERATION_SHIFT_RECORD")]
    public partial class MED_OPERATION_SHIFT_RECORD : BaseModel
    {
                /// <summary>
        /// 主键 病人ID  ;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数  ;  住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号  ;一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 工作类型  ;麻醉医生、麻醉一助等等 
        /// </summary>
        [Key]
        public string SHIFT_DUTY { get; set; }
        /// <summary>
        /// 主键 交班人
        /// </summary>
        [Key]
        public string PERSON { get; set; }
        /// <summary>
        /// 接班人
        /// </summary>
        public string SHIFT_PERSON { get; set; }
        /// <summary>
        /// 主键 开始时间
        /// </summary>
        [Key]
        public DateTime START_DATE_TIME { get; set; }
        /// <summary>
        /// 结束时间  ;为空时标示为手术结束时间或麻醉结束时间
        /// </summary>
        public Nullable<DateTime> END_DATE_TIME { get; set; }
        /// <summary>
        /// 交班时间  ;填写交班记录事件，提取系统时间 
        /// </summary>
        public Nullable<DateTime> SHIFT_DATE_TIME { get; set; }
        /// <summary>
        /// 交班备注
        /// </summary>
        public string MEMO { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public string RESERVED4 { get; set; }

    }
}