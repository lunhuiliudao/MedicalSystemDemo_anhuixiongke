namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 
    /// </summary>
    [Table("MED_NURSING_QDNURSE")]
    public partial class MED_NURSING_QDNURSE : BaseModel
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
        public string QX_SQQD { get; set; }
        public string QX_GTQQ { get; set; }
        public string QX_GTQH { get; set; }
        public string QX_JB_NURSE { get; set; }
        public DateTime? QX_JB_DATE { get; set; }
        public string XH_SQQD { get; set; }
        public string XH_GTQQ { get; set; }
        public string XH_GTQH { get; set; }
        public string XH_JB_NURSE { get; set; }
        public DateTime? XH_JB_DATE { get; set; }
        public string COMMEN { get; set; }
        public string RESERVED01 { get; set; }
        public string RESERVED02 { get; set; }
        public string RESERVED03 { get; set; }
        public string RESERVED04 { get; set; }
        public string RESERVED05 { get; set; }
    }
}