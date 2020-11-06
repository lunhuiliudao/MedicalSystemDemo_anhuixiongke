namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 手术取消表
    /// </summary>
    [Table("MED_OPERATION_CANCELED")]
    public partial class MED_OPERATION_CANCELED : BaseModel
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
        /// 主键 手术取消标识	;手术取消标识(区分一个病人一次住院多次取消记录，从1开始顺序递增)
        /// </summary>
        [Key]
        public Int32 CANCEL_ID { get; set; }
        /// <summary>
        /// 手术安排标识	;	与计划表中的SCHEDULE_ID对应
        /// </summary>
        public Nullable<Int32> SCHEDULE_ID { get; set; }
        /// <summary>
        /// 手术安排标识	;	与手术主表的OPER_ID对应
        /// </summary>
        public Nullable<Int32> OPER_ID { get; set; }
        /// <summary>
        /// 手术状态	;			对应手术状态代码表记录取消时的手术状态。
        /// </summary>
        public Int32 OPER_STATUS_CODE { get; set; }
        /// <summary>
        /// 取消类型	;			对应取消类型代码表 
        /// </summary>
        public string CANCEL_TYPE { get; set; }
        /// <summary>
        /// 取消原因
        /// </summary>
        public string CANCEL_REASON { get; set; }
        /// <summary>
        /// 取消日期
        /// </summary>
        public DateTime CANCEL_DATE { get; set; }
        /// <summary>
        /// 取消人
        /// </summary>
        public string CANCEL_BY { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string ENTERED_BY { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public string RESERVED4 { get; set; }
    }
}