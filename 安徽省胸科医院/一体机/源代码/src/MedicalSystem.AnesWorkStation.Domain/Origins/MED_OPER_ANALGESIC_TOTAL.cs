namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_OPER_ANALGESIC_TOTAL")]
    public partial class MED_OPER_ANALGESIC_TOTAL : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 观察名称
        /// </summary>
        [Key]
        public string TOTAL_NAME { get; set; }
        /// <summary>
        /// 观察值
        /// </summary>
        public string TOTAL_VALUE { get; set; }
        /// <summary>
        /// 观察备注
        /// </summary>
        public string TOTAL_MEMO { get; set; }

    }
}