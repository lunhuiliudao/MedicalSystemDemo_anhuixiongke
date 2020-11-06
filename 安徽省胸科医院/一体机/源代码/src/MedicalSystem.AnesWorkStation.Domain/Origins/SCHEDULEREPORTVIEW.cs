using System;
using System.Collections.Generic;  
using Dapper.Data;


using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 手术通知单数据源
    /// </summary>
    [Table("SCHEDULEREPORTVIEW")]
    public partial class SCHEDULEREPORTVIEW : BaseModel
    {      /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        [Key]
        public decimal VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术安排标识	;	一个病人一次住院预约多次手术时，从1开始分配。每次预约时，在该表中取病人预约手术的最大标识数，加1作为本次标识。如果未找到该病人在本表中的预约记录，标识为1)
        /// </summary>
        [Key]
        public decimal SCHEDULE_ID { get; set; }

        public string OPER_ROOM_NO_SEQUENCE { get; set; }

        public Nullable<DateTime> SCHEDULED_DATE_TIME { get; set; }

        public string NAME { get; set; }

        public string SEX { get; set; }

        public DateTime DATE_OF_BIRTH { get; set; }

        public string AGE { get; set; }

        public string INP_NO { get; set; }

        public string OPER_DEPT_NAME { get; set; }

        public string BED_NO { get; set; }

        public string DIAG_BEFORE_OPERATION { get; set; }

        public string OPERATION_NAME { get; set; }

        public string SURGEON_NAME { get; set; }

        public string OPER_ASSISTANT_NAME { get; set; }

        public string ANES_METHOD { get; set; }

        public string ANES_DOCTOR_NAME { get; set; }

        public string ANES_ASSISTANT_NAME { get; set; }

        public string OPER_NURSE_NAME { get; set; }

        public string SUPPLY_NURSE_NAME { get; set; }

        public string OPER_ROOM_NO { get; set; }

        /// <summary>
        /// 备注		
        /// </summary>
        public string NOTES_ON_OPERATION { get; set; }
    }
}
