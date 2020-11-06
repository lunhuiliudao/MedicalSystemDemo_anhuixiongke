namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 
    /// </summary>
    [Table("MED_NURSING_TOUR")]
    public partial class MED_NURSING_TOUR : BaseModel
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

        [Key]
        public Int32 ITEM_NO { get; set; }
        public DateTime? TIME_POINT { get; set; }
        public string JMSY { get; set; }
        public string PFYS { get; set; }
        public string ZTWZ { get; set; }
        public string FJB { get; set; }
        public string YQSB { get; set; }
        public string NURSE { get; set; }
        public string RESERVED01 { get; set; }
        public string RESERVED02 { get; set; }
        public string RESERVED03 { get; set; }
        public string RESERVED04 { get; set; }
        public string RESERVED05 { get; set; }
    }
}