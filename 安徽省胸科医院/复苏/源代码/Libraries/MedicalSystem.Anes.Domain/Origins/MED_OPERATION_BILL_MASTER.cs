namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 收费主表
    /// </summary>
    [Table("MED_OPERATION_BILL_MASTER")]
    public partial class MED_OPERATION_BILL_MASTER : BaseModel
    {
                /// <summary>
        /// 主键 病人标识号
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 病人本次住院标识 
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 病人本次手术标识
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 收费类别;1-麻醉，0-手术
        /// </summary>
        [Key]
        public Int32 BILL_ATTR { get; set; }
        /// <summary>
        /// 开单科室；
        /// </summary>
        public string ORDERED_BY { get; set; }
        /// <summary>
        /// 开单医生
        /// </summary>
        public string ORDERED_DOCTOR { get; set; }
        /// <summary>
        /// 执行科室
        /// </summary>
        public string PERFORMED_BY { get; set; }
        /// <summary>
        /// 执行医生
        /// </summary>
        public string PERFORMED_DOCTOR { get; set; }
        /// <summary>
        /// 录入者
        /// </summary>
        public string ENTERED_BY { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string OPERATOR { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        public string AUDITOR { get; set; }
        /// <summary>
        /// 审核标志；0-未审核，2-已审核
        /// </summary>
        public Nullable<Int32> REVIEWED_MARK { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public Nullable<DateTime> REVIEWED_DATA { get; set; }

    }
}