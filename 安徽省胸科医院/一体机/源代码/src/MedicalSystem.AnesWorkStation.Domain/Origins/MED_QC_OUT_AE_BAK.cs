using Dapper.Data;


namespace MedicalSystem.AnesWorkStation.Domain
{

    [Table("MED_QC_OUT_AE_BAK")]
    public partial class MED_QC_OUT_AE_BAK : BaseModel
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
        public decimal UPLOAD { get; set; }

    }
}
