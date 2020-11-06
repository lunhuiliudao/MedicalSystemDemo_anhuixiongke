namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 
    /// </summary>
    [Table("MED_NURSING_YWASSESS")]
    public partial class MED_NURSING_YWASSESS : BaseModel
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
        public string SSQX { get; set; }
        public string YQSB { get; set; }
        public string TWYP { get; set; }
        public string SSHJ { get; set; }
        public string YFDTW_SW { get; set; }
        public string YFDTW_BWT { get; set; }
        public string YFDTW_WYS { get; set; }
        public string YFDTW_JSJG { get; set; }
        public string SYZLD { get; set; }
        public string YT { get; set; }
        public string GHTW_STATUS { get; set; }
        public DateTime? GHTW_DATE { get; set; }
        public string GHTW_FS { get; set; }
        public string DDSY { get; set; }
        public string FJBZTWZ { get; set; }
        public string JBPFQK { get; set; }
        public string QYZXD_STATUS { get; set; }
        public string QYZXD_BZWZ { get; set; }
        public string QYZXD_YL { get; set; }
        public DateTime? QYZXD_DATE { get; set; }
        public DateTime? QYZXD_SBDATE { get; set; }
        public string QYZXD_JBPF { get; set; }
        public string SZBD { get; set; }
        public string BLBB { get; set; }
        public string XHHSJB_STATUS { get; set; }
        public string SYBW_SZ { get; set; }
        public string SYBW_XZ { get; set; }
        public string SYBW_SGX { get; set; }
        public string SYBW_JN { get; set; }
        public string BRDLW_X { get; set; }
        public string BRDLW_YW { get; set; }
        public string SYXZP { get; set; }
        public string ZZSQLYZP { get; set; }
        public string SSTWPSL { get; set; }
        public string GZTSHC { get; set; }
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