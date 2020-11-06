namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;

    /// <summary>
    /// 协同的扩展表
    /// </summary>
    public partial class MED_CLIENT_COMPUTER
    {
        /// <summary>
        /// 麻醉医师	;	麻醉医师姓名，Anesthesia_doctor
        /// </summary>
        [NotMapped]
        public string ANES_DOCTOR { get; set; }
        /// <summary>
        /// 麻醉助手1	;	麻醉第一助手 anesthesia_assistant
        /// </summary>
        [NotMapped]
        public string FIRST_ANES_ASSISTANT { get; set; }
    }
}