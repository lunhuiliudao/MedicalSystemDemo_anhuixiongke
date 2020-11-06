namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 手术状态扩展表
    /// </summary>
    [Table("MED_OPERATION_STATUS_EXT")]
    public partial class MED_OPERATION_STATUS_EXT : BaseModel
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
        /// 主键 手术号	;	一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 状态代码		
        /// </summary>
        [Key]
        public Int32 OPER_STATUS_CODE { get; set; }
        /// <summary>
        /// 状态名称	;	冗余字段，方便查看
        /// </summary>
        public string OPER_STATUS_NAME { get; set; }
        /// <summary>
        /// 完成时间	;	完成时间
        /// </summary>
        public Nullable<DateTime> ACHIEVE_DATE_TIME { get; set; }
        /// <summary>
        /// 备注说明	;	备注说明
        /// </summary>
        public string MEMO { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public string RESERVED4 { get; set; }
    }
}