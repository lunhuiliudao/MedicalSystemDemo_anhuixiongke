namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_CONFIG")]
    public partial class MED_CONFIG : BaseModel
    {
        [Key]
        public string PARAKEY { get; set; }
        public byte[] PARAVALUE { get; set; }
    }
}