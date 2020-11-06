using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
    public class MED_LAB_PATIENT : BaseModel
    {
        /// <summary>
        /// 病人ID	;非空，唯一确定手术病人
        /// </summary> 
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次数	;	住院病人每次住院加1
        /// </summary> 
        public Int32 VISIT_ID { get; set; }
        public string REPORT_ITEM_NAME { get; set; }
        public string RESULT { get; set; }
        public string UNITS { get; set; }
        public string ABNORMAL_INDICATOR { get; set; }
        public Nullable<DateTime> RESULT_DATE_TIME { get; set; }
        public string REFERENCE_RESULT { get; set; }
        public string TEST_CAUSE { get; set; } 
    }
}
