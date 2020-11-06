namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_DOCUMENT_TEMPLET")]
    public partial class MED_DOCUMENT_TEMPLET : BaseModel
    {
                [Key]
        public string TEMPLET_GUID { get; set; }
        public string USER_ID { get; set; }
        public string DOCUMENT_NAME { get; set; }
        public string CLASS_NAME { get; set; }
        public string TEMPLET_NAME { get; set; }
        public Int32 ISJUBU { get; set; }
        public Int32 ISPRIVATE { get; set; }
        public byte[] TEMPLET_VALUE { get; set; }
        public string EVENT_NO { get; set; }

    }
}