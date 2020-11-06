using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public class MED_SHIFT_INFO : BaseModel
    {
        /// <summary>
        /// 职责
        /// </summary>
        public string DUTY_NAME { get; set; }
        /// <summary>
        /// 当班人员
        /// </summary>
        public string DUTY_OFFICER { get; set; }
        /// <summary>
        /// 开始时间 
        /// </summary>
        public Nullable<DateTime> START_TIME { get; set; }
        /// <summary>
        /// 接班人员
        /// </summary>
        public string SUCCESSION_OFFICER { get; set; }
        /// <summary>
        /// 接班人员ID
        /// </summary>
        public string SUCCESSION_ID { get; set; }
    }
}
