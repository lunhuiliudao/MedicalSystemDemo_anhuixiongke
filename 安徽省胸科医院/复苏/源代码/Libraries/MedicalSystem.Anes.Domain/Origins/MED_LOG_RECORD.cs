namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MED_LOG_RECORD")]
    public partial class MED_LOG_RECORD
    {
        [Key]
        public string LOGID { get; set; }
        public string APP_ID { get; set; }
        public string TYPE { get; set; }
        public string ACTION { get; set; }
        public string CONTENT { get; set; }
        public System.DateTime LOGTIME { get; set; }
        public string USER_ID { get; set; }
        public string DESCRIPTION { get; set; }
    
    }
}
