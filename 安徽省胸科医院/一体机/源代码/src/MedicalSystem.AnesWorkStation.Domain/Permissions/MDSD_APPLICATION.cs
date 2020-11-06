namespace MDSD.Permission.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
   
    using MedicalSystem.AnesWorkStation.Domain;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MDSD_APPLICATION")]
    public partial class MDSD_APPLICATION : BaseModel
    {
        [Key]
        public string APPLICATION_CODE { get; set; }
        public string APPLICATION_KEY { get; set; }
        public string APPLICATION_LABEL { get; set; }
        public string APPLICATION_DESC { get; set; }
        public Nullable<Int32> IS_DISABLE { get; set; }

        [NotMapped]
        public virtual ICollection<MDSD_MENU> MENU_LIST { get; set; }
    }
}