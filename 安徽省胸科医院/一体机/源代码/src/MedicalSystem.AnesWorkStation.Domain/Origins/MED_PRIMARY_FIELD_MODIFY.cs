namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 数据修改日志表
    /// </summary>
    [Table("MED_PRIMARY_FIELD_MODIFY")]
    public partial class MED_PRIMARY_FIELD_MODIFY : BaseModel
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
        /// 主键 数据表名称
        /// </summary>
        [Key]
        public string TABLE_NAME { get; set; }
        /// <summary>
        /// 主键 修改字段名称
        /// </summary>
        [Key]
        public string FIELD_NAME { get; set; }
        /// <summary>
        /// 主键 修改时间
        /// </summary>
        [Key]
        public DateTime MODIFY_DATE { get; set; }
        /// <summary>
        /// 新值
        /// </summary>
        public string NEW_VALUE { get; set; }
        /// <summary>
        /// 旧值
        /// </summary>
        public string OLD_VALUE { get; set; }
        /// <summary>
        /// 修改原因
        /// </summary>
        public string MODIFY_REASON { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string OPERATOR { get; set; }
    }
}