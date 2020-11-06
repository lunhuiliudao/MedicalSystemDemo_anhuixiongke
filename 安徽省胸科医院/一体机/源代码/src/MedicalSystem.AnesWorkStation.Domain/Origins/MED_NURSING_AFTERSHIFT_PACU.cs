namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 
    /// </summary>
    [Table("MED_NURSING_AFTERSHIFT_PACU")]
    public partial class MED_NURSING_AFTERSHIFT_PACU : BaseModel
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
        public string YLG_BW { get; set; }
        public string YLG_COUNT { get; set; }
        public string PF_STATUS { get; set; }
        public string PF_OTHER { get; set; }
        public string YS { get; set; }
        public string DHBQYW_X { get; set; }
        public string DHBQYW_X_COUNT { get; set; }
        public string DHBQYW_YW { get; set; }
        public string DHBQYW_YW_NAME { get; set; }
        public string DHBQYW_YW_OTHER { get; set; }
        public string SYBW_SZ { get; set; }
        public string SYBW_XZ { get; set; }
        public string SYBW_SGX { get; set; }
        public string SYBW_JN { get; set; }
        public string SYBW_OTHER { get; set; }
        public string DHXZP_H { get; set; }
        public string DHXZP_X { get; set; }
        public string LZNG_STATUS { get; set; }
        public string LZNG_NL { get; set; }
        public string WX { get; set; }
        public string XH_NURSE { get; set; }
        public string BQ_NURSE { get; set; }
        public DateTime? TIME_POINT { get; set; }
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