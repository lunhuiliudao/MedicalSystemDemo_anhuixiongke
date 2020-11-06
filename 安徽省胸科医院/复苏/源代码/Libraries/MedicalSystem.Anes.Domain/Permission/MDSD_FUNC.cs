namespace MDSD.Permission.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MedicalSystem.Anes.Domain;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MDSD_FUNC")]
    public partial class MDSD_FUNC : BaseModel
    {
        [Key]
        public string FUNC_CODE { get; set; }
        public string MENU_CODE { get; set; }
        public string FUNC_KEY { get; set; }
        public string FUNC_LABEL { get; set; }
        public string FUNC_DESC { get; set; }
        public Nullable<Int32> IS_DISABLE { get; set; }
    }
}