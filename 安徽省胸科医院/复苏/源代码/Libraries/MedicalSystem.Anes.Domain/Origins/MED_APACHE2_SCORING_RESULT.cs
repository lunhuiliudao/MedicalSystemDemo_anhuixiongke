namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_APACHE2_SCORING_RESULT")]
    public partial class MED_APACHE2_SCORING_RESULT : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 DEP_ID { get; set; }
        [Key]
        public DateTime SCORING_DATE_TIME { get; set; }
        public Nullable<Int32> AGE { get; set; }
        public Nullable<Int32> HR { get; set; }
        public Nullable<Int32> MAP { get; set; }
        public Nullable<Int32> BR { get; set; }
        public Nullable<decimal> TMP { get; set; }
        public Nullable<decimal> AADO2 { get; set; }
        public Nullable<decimal> PAO2 { get; set; }
        public Nullable<decimal> FIO2 { get; set; }
        public Nullable<decimal> PH { get; set; }
        public Nullable<decimal> HCT { get; set; }
        public Nullable<decimal> CR { get; set; }
        public Nullable<decimal> WBC { get; set; }
        public Nullable<decimal> K { get; set; }
        public Nullable<decimal> NA { get; set; }
        public Nullable<Int32> EYES_REFLECT { get; set; }
        public Nullable<Int32> TALK_REFLECT { get; set; }
        public Nullable<Int32> LIMB_REFLECT { get; set; }
        public Nullable<Int32> HEALTH_STATUS { get; set; }
        public Nullable<Int32> KEY_INDICATOR { get; set; }
        public string MEMO { get; set; }
        public Nullable<Int32> JI_ZHEN_OPER { get; set; }
        public string NO_OPER_PAT { get; set; }
        public string AFTER_OPER_PAT { get; set; }

    }
}