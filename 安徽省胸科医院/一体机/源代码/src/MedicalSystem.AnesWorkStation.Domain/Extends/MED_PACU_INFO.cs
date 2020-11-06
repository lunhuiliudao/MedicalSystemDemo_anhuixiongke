using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// PACU功能类
    /// </summary>
    [NotMapped]
    public partial class MED_PACU_INFO : BaseModel
    {
        /// <summary>
        /// 用户ID	
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// VISIT_ID	
        /// </summary>
        public Int32 VISIT_ID { get; set; }

        /// <summary>
        /// OPER_ID	
        /// </summary>
        public Int32 OPER_ID { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 姓别
        /// </summary>
        public string SEX { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public Nullable<DateTime> DATE_OF_BIRTH { get; set; }

        /// <summary>
        /// 手术安排日期
        /// </summary>
        public Nullable<DateTime> SCHEDULED_DATE_TIME { get; set; }

        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }

        /// <summary>
        /// 入PACU时间
        /// </summary>
        public Nullable<DateTime> IN_PACU_DATE_TIME { get; set; }

        /// <summary>
        /// 出PACU时间
        /// </summary>
        public Nullable<DateTime> OUT_PACU_DATE_TIME { get; set; }
    }
}
