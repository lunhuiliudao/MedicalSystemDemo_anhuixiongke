using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Domain
{

    [Table("MED_NURSING_QINGDIAN")]
    public partial class MED_NURSING_QINGDIAN : BaseModel
    {
        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }

        [Key]
        public Int32 ITEM_NO { get; set; }

        public string ITEM_NAME1 { get; set; }

        public Nullable<Int32> SSQ1 { get; set; }

        public Nullable<Int32> GTQQ1 { get; set; }

        public Nullable<Int32> GTQH1 { get; set; }

        public Nullable<Int32> FPH1 { get; set; }

        public string ITEM_NAME2 { get; set; }

        public Nullable<Int32> SSQ2 { get; set; }

        public Nullable<Int32> GTQQ2 { get; set; }

        public Nullable<Int32> GTQH2 { get; set; }

        public Nullable<Int32> FPH2 { get; set; }

        public string RESERVED01 { get; set; }

        public string RESERVED02 { get; set; }

        public string RESERVED03 { get; set; }

        public string RESERVED04 { get; set; }

        public string RESERVED05 { get; set; }
    }
}
