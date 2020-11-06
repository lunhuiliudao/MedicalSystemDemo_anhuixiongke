namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;   
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_TISS_SCORING_RESULT_DETAIL")]
    public partial class MED_TISS_SCORING_RESULT_DETAIL : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 DEP_ID { get; set; }
        [Key]
        public DateTime SCORING_DATE_TIME { get; set; }
        public Nullable<Int32> T41 { get; set; }
        public Nullable<Int32> T42 { get; set; }
        public Nullable<Int32> T43 { get; set; }
        public Nullable<Int32> T44 { get; set; }
        public Nullable<Int32> T45 { get; set; }
        public Nullable<Int32> T46 { get; set; }
        public Nullable<Int32> T47 { get; set; }
        public Nullable<Int32> T48 { get; set; }
        public Nullable<Int32> T49 { get; set; }
        public Nullable<Int32> T410 { get; set; }
        public Nullable<Int32> T411 { get; set; }
        public Nullable<Int32> T412 { get; set; }
        public Nullable<Int32> T413 { get; set; }
        public Nullable<Int32> T414 { get; set; }
        public Nullable<Int32> T415 { get; set; }
        public Nullable<Int32> T416 { get; set; }
        public Nullable<Int32> T417 { get; set; }
        public Nullable<Int32> T418 { get; set; }
        public Nullable<Int32> T419 { get; set; }
        public Nullable<Int32> T31 { get; set; }
        public Nullable<Int32> T32 { get; set; }
        public Nullable<Int32> T33 { get; set; }
        public Nullable<Int32> T34 { get; set; }
        public Nullable<Int32> T35 { get; set; }
        public Nullable<Int32> T36 { get; set; }
        public Nullable<Int32> T37 { get; set; }
        public Nullable<Int32> T38 { get; set; }
        public Nullable<Int32> T39 { get; set; }
        public Nullable<Int32> T310 { get; set; }
        public Nullable<Int32> T311 { get; set; }
        public Nullable<Int32> T312 { get; set; }
        public Nullable<Int32> T313 { get; set; }
        public Nullable<Int32> T314 { get; set; }
        public Nullable<Int32> T315 { get; set; }
        public Nullable<Int32> T316 { get; set; }
        public Nullable<Int32> T317 { get; set; }
        public Nullable<Int32> T318 { get; set; }
        public Nullable<Int32> T319 { get; set; }
        public Nullable<Int32> T320 { get; set; }
        public Nullable<Int32> T321 { get; set; }
        public Nullable<Int32> T322 { get; set; }
        public Nullable<Int32> T323 { get; set; }
        public Nullable<Int32> T324 { get; set; }
        public Nullable<Int32> T325 { get; set; }
        public Nullable<Int32> T326 { get; set; }
        public Nullable<Int32> T327 { get; set; }
        public Nullable<Int32> T328 { get; set; }
        public Nullable<Int32> T21 { get; set; }
        public Nullable<Int32> T22 { get; set; }
        public Nullable<Int32> T23 { get; set; }
        public Nullable<Int32> T24 { get; set; }
        public Nullable<Int32> T25 { get; set; }
        public Nullable<Int32> T26 { get; set; }
        public Nullable<Int32> T27 { get; set; }
        public Nullable<Int32> T28 { get; set; }
        public Nullable<Int32> T29 { get; set; }
        public Nullable<Int32> T210 { get; set; }
        public Nullable<Int32> T211 { get; set; }
        public Nullable<Int32> T11 { get; set; }
        public Nullable<Int32> T12 { get; set; }
        public Nullable<Int32> T13 { get; set; }
        public Nullable<Int32> T14 { get; set; }
        public Nullable<Int32> T15 { get; set; }
        public Nullable<Int32> T16 { get; set; }
        public Nullable<Int32> T17 { get; set; }
        public Nullable<Int32> T18 { get; set; }
        public Nullable<Int32> T19 { get; set; }
        public Nullable<Int32> T110 { get; set; }
        public Nullable<Int32> T111 { get; set; }
        public Nullable<Int32> T112 { get; set; }
        public Nullable<Int32> T113 { get; set; }
        public Nullable<Int32> T114 { get; set; }
        public Nullable<Int32> T115 { get; set; }
        public Nullable<Int32> T116 { get; set; }
        public Nullable<Int32> T117 { get; set; }
        public Nullable<Int32> T118 { get; set; }
        public string MEMO { get; set; }

    }
}