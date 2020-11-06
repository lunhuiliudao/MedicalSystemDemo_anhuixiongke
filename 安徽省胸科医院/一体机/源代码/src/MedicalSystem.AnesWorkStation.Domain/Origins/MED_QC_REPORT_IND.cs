using Dapper.Data;
using System;
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.Domain
{
    [Table("MED_QC_REPORT_IND")]
    public partial class MED_QC_REPORT_IND : BaseModel
    {

        [Key]
        public string REPORT_ID { get; set; }

        public string REPORT_MONTH { get; set; }

        public DateTime? COUNT_DATE { get; set; }

        public string REPORT_NAME { get; set; }

        public int STATUS { get; set; }

        public DateTime? REPORT_DATE { get; set; }

        public string OPERATOR { get; set; }

        [NotMapped]
        public int ROW_NO { get; set; }

        [NotMapped]
        public IList<MED_QC_REPORT_LIST> list{get;set;}

    }
}
