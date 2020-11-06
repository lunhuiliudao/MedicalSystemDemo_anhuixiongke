using Dapper.Data;
using System;

namespace MedicalSystem.AnesWorkStation.Domain
{
    [Table("MED_QC_OUT_REPORT_DATA")]
    public partial class MED_QC_OUT_REPORT_DATA : BaseModel
    {
        [Key]
        public string REPORT_ID { get; set; }
        public string QC_CODE { get; set; }
        public decimal QC_VALUE { get; set; }
        public string REPORT_MONTH { get; set; }
        public DateTime? COUNT_DATE { get; set; }
        public string REPORT_NAME { get; set; }
        public decimal STATUS { get; set; }
        public DateTime? REPORT_DATE { get; set; }
        public string OPERATOR { get; set; }


    }
}
