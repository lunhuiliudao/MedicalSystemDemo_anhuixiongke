namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_LAB_TEST_MASTER")]
    public partial class MED_LAB_TEST_MASTER : BaseModel
    {
        [Key]
        public string TEST_NO { get; set; }
        public Nullable<Int32> PRIORITY_INDICATOR { get; set; }
        public string PATIENT_ID { get; set; }
        public Nullable<Int32> VISIT_ID { get; set; }
        public string WORKING_ID { get; set; }
        public Nullable<DateTime> EXECUTE_DATE { get; set; }
        public string NAME { get; set; }
        public string NAME_PHONETIC { get; set; }
        public string CHARGE_TYPE { get; set; }
        public string SEX { get; set; }
        public Nullable<Int32> AGE { get; set; }
        public string TEST_CAUSE { get; set; }
        public string RELEVANT_CLINIC_DIAG { get; set; }
        public string SPECIMEN { get; set; }
        public string NOTES_FOR_SPCM { get; set; }
        public Nullable<DateTime> SPCM_RECEIVED_DATE_TIME { get; set; }
        public Nullable<DateTime> SPCM_SAMPLE_DATE_TIME { get; set; }
        public Nullable<DateTime> REQUESTED_DATE_TIME { get; set; }
        public string ORDERING_DEPT { get; set; }
        public string ORDERING_PROVIDER { get; set; }
        public string PERFORMED_BY { get; set; }
        public string RESULT_STATUS { get; set; }
        public Nullable<DateTime> RESULTS_RPT_DATE_TIME { get; set; }
        public string TRANSCRIPTIONIST { get; set; }
        public string VERIFIED_BY { get; set; }
        public Nullable<decimal> COSTS { get; set; }
        public Nullable<decimal> CHARGES { get; set; }
        public Nullable<Int32> BILLING_INDICATOR { get; set; }
        public Nullable<Int32> PRINT_INDICATOR { get; set; }
        public string SUBJECT { get; set; }
        public string BARCODE { get; set; }
    }
}