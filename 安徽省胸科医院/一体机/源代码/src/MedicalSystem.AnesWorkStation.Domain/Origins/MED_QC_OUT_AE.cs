using Dapper.Data;


namespace MedicalSystem.AnesWorkStation.Domain
{

    [Table("MED_QC_OUT_AE")]
    public partial class MED_QC_OUT_AE : BaseModel
    {
        [Key]
        public string REPORT_ID { get; set; }
        [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public decimal VISIT_ID { get; set; }
        [Key]
        public decimal OPER_ID { get; set; }
        [Key]
        public string ITEM_CODE { get; set; }
    }
}
