namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_OPER_ANALGESIC_MEDICINE")]
    public partial class MED_OPER_ANALGESIC_MEDICINE : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 药物名称
        /// </summary>
        [Key]
        public string MEDICINE_NAME { get; set; }
        /// <summary>
        /// 药物剂量
        /// </summary>
        public Nullable<decimal> MEDICINE_DOSAGE { get; set; }
        /// <summary>
        /// 药物单位
        /// </summary>
        public string MEDICINE_DOSAGE_UNITS { get; set; }

    }
}