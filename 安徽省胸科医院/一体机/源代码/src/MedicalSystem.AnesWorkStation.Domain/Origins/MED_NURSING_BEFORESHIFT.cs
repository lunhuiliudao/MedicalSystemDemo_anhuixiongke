namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 
    /// </summary>
    [Table("MED_NURSING_BEFORESHIFT")]
    public partial class MED_NURSING_BEFORESHIFT : BaseModel
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
        public string BINGLI { get; set; }
        public string YP_NAME_COUNT { get; set; }
        public string YXXZL { get; set; }
        public string YXXZL_COUNT { get; set; }
        public string BRHD { get; set; }
        public string SSBWHD { get; set; }
        public string JSS { get; set; }
        public string RSQPN { get; set; }
        public string BP { get; set; }
        public string JSTYQZ { get; set; }
        public string QCSSYXYJJA { get; set; }
        public string SQYY { get; set; }
        public string THKC { get; set; }
        public string FR { get; set; }
        public string KS { get; set; }
        public string SDY { get; set; }
        public string MZXGZS { get; set; }
        public string SSXGZS { get; set; }
        public string YG_YING_YANG { get; set; }
        public string HIV_YING_YNAG { get; set; }
        public string HIV_OTHER { get; set; }
        public string BF_NURSE { get; set; }
        public string SSS_NURSE { get; set; }
        public DateTime? SHIFT_DATE { get; set; }
        public string RESERVED01 { get; set; }
        public string RESERVED02 { get; set; }
        public string RESERVED03 { get; set; }
        public string RESERVED04 { get; set; }
        public string RESERVED05 { get; set; }
        public string RESERVED06 { get; set; }
        public string RESERVED07 { get; set; }
        public string RESERVED08 { get; set; }
        public string RESERVED09 { get; set; }
        public string RESERVED10 { get; set; }
    }
}