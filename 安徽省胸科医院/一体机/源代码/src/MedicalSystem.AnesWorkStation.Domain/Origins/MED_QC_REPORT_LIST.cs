using Dapper.Data;
using System;

namespace MedicalSystem.AnesWorkStation.Domain
{
    [Table("MED_QC_REPORT_LIST")]
    public partial class MED_QC_REPORT_LIST : BaseModel
    {
        [Key]
        public string REPORT_NO { get; set; }
        public string REPORT_NAME { get; set; }
        public string NMRTR_CODE { get; set; }
        [NotMapped]
        public string NMRTR_CODE_VALUE { get; set; }
        public decimal? NMRTR_EDIT_MARK { get; set; }
        public string DNMTR_CODE { get; set; }
        [NotMapped]
        public string DNMTR_CODE_VALUE { get; set; }
        public decimal? DNMTR_EDIT_MARK { get; set; }
        [NotMapped]
        public string PERCENT { get; set; }

        [NotMapped]
        public DateTime? COUNT_DATE { get; set; }

        [NotMapped]
        public string REPORT_ID { get; set; }

        [NotMapped]
        public decimal? DETAILS_COUNT { get; set; }

        /// <summary>
        /// 分组号
        /// </summary>
        public decimal? GROUP_NO { get; set; }

        /// <summary>
        /// 是否父级  父级子级,0子级,1父级
        /// </summary>
        public decimal FATHER_CHILD { get; set; }


        /// <summary>
        /// 项目描述
        /// </summary>
        public string DESCRIBE { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT { get; set; }
    }
}
