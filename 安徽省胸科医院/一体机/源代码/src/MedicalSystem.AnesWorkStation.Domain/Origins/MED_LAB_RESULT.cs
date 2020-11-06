namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_LAB_RESULT")]
    public partial class MED_LAB_RESULT : BaseModel
    {
        [Key]
        public string TEST_NO { get; set; }
        [Key]
        public long ITEM_NO { get; set; }
        [Key]
        public Int32 PRINT_ORDER { get; set; }
        public string REPORT_ITEM_NAME { get; set; }
        public string REPORT_ITEM_CODE { get; set; }
        public string RESULT { get; set; }
        public string UNITS { get; set; }
        public string ABNORMAL_INDICATOR { get; set; }
        public string INSTRUMENT_ID { get; set; }
        public Nullable<DateTime> RESULT_DATE_TIME { get; set; }
        public string REFERENCE_RESULT { get; set; }
    }
}