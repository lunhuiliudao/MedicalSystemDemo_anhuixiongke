namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 
    /// </summary>
    [Table("MED_NURSING_AFTER")]
    public partial class MED_NURSING_AFTER : BaseModel
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

        public string YS { get; set; }
        public string QGCG { get; set; }
        public string XY { get; set; }
        public string MB { get; set; }
        public string HX { get; set; }
        public string PF { get; set; }
        public string PF_OTHER { get; set; }
        public string PF_CXL { get; set; }
        public string YLG_STATUS { get; set; }
        public string YLG_WG { get; set; }
        public string YLG_NG { get; set; }
        public string YLG_XYG { get; set; }
        public string YLG_FQYLG { get; set; }
        public string YLG_SYG { get; set; }
        public string YLG_OTHER { get; set; }
        public string YLG_COUNT { get; set; }
        public string YLG_NL { get; set; }
        public string YY_WZ { get; set; }
        public string YY_ZXJM { get; set; }
        public string NURSE { get; set; }
        public DateTime? OUT_DATE { get; set; }
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