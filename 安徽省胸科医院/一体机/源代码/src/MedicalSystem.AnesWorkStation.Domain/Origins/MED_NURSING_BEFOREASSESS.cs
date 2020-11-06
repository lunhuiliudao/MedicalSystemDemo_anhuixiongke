namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 
    /// </summary>
    [Table("MED_NURSING_BEFOREASSESS")]
    public partial class MED_NURSING_BEFOREASSESS : BaseModel
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

        public string SSJQR { get; set; }
        public string TZD { get; set; }
        public string BL { get; set; }
        public string WD { get; set; }
        public string HD_BR { get; set; }
        public string HD_JS { get; set; }
        public string HD_XM { get; set; }
        public string HD_SSMC { get; set; }
        public string HD_SSBW { get; set; }
        public string GMS { get; set; }
        public string JWSSS { get; set; }
        public string MXBS { get; set; }
        public string ZRW_YY { get; set; }
        public string ZRW_XZQBQ { get; set; }
        public string ZRW_RGBM { get; set; }
        public string ZRW_JZ { get; set; }
        public string ZRW_GB { get; set; }
        public string ZRW_ZTQ { get; set; }
        public string ZRW_OTHER { get; set; }
        public string YSZT { get; set; }
        public string YSZT_OTHER { get; set; }
        public string XLZT { get; set; }
        public string PFNM_STATUS { get; set; }
        public string PFNM_BW { get; set; }
        public string PFNM_XZ { get; set; }
        public string SZHD_STATUS { get; set; }
        public string SZHD_BW { get; set; }
        public string SZHD_XZ { get; set; }
        public string SZHD_OTHER { get; set; }
        public string ZTGJ_STATUS { get; set; }
        public string ZTGJ_BW { get; set; }
        public string ZTGJ_XZ { get; set; }
        public string ZTGJ_OTHER { get; set; }
        public string GD_STATUS { get; set; }
        public string GD_WG { get; set; }
        public string GD_NG { get; set; }
        public string GD_XYG { get; set; }
        public string GD_FQYLG { get; set; }
        public string GD_SYG { get; set; }
        public string GD_BW { get; set; }
        public string GD_OTHER { get; set; }
        public string GD__STATUS_DES { get; set; }
        public string BFDLW_SP { get; set; }
        public string BFDLW_SP_COUNT { get; set; }
        public string BFDLW_YP { get; set; }
        public string BFDLW_YP_NAME { get; set; }
        public string BFDLW_OTHER { get; set; }
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