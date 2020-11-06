namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_QIXIE_TEMPLET_MASTER")]
    public partial class MED_QIXIE_TEMPLET_MASTER : BaseModel
    {
                [Key]
        public string TEMPLET_GUID { get; set; }
        public Int32 OPER_BAG_FLAG { get; set; }
        public string CLASS_NAME { get; set; }
        public string TEMPLET_NAME { get; set; }
        public string MEMO { get; set; }

    }
}