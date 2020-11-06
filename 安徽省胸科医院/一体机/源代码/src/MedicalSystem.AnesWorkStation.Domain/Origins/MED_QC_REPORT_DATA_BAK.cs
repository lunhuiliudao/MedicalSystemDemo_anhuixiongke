using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    [Table("MED_QC_REPORT_DATA_BAK")]
    public partial class MED_QC_REPORT_DATA_BAK : BaseModel
    {
        [Key]
        public string REPORT_ID { get; set; }
        [Key]
        public string QC_CODE { get; set; }
        public decimal QC_VALUE { get; set; }

        [NotMapped]
        public decimal? DETAILS_COUNT { get; set; }
    }
}
