namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;



    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_CHILDPUGH_SCORING_RESULT")]
    public partial class MED_CHILDPUGH_SCORING_RESULT : BaseModel
    {
        [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 DEP_ID { get; set; }
        [Key]
        public DateTime SCORING_DATE_TIME { get; set; }
        public Nullable<Int32> S1 { get; set; }
        public Nullable<Int32> S2 { get; set; }
        public Nullable<Int32> S3 { get; set; }
        public Nullable<Int32> S4 { get; set; }
        public Nullable<Int32> S5 { get; set; }
        public Nullable<Int32> S6 { get; set; }
        public Nullable<Int32> S7 { get; set; }
        public string MEMO { get; set; }
        public string DEGREE { get; set; }

    }
}