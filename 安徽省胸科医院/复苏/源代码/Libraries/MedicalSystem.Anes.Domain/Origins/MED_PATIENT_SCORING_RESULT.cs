namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_PATIENT_SCORING_RESULT")]
    public partial class MED_PATIENT_SCORING_RESULT : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 DEP_ID { get; set; }
        [Key]
        public DateTime SCORING_DATE_TIME { get; set; }
        [Key]
        public string SCORING_METHOD { get; set; }
        public Nullable<Int32> SCORING_VALUE { get; set; }
        public string DEGREE { get; set; }
        public Nullable<decimal> DEATH_PROBABILITY { get; set; }
        public string PAT_CONDITION { get; set; }
        public string WARD_CODE { get; set; }
        public string OPERATOR { get; set; }
        public string MEMO { get; set; }
        public Nullable<DateTime> ENTER_DATE_TIME { get; set; }
        public Nullable<decimal> DEATH_RATE { get; set; }
        public Nullable<decimal> ISS_SCORE { get; set; }
        public Nullable<decimal> TRS_SCORE { get; set; }

    }
}