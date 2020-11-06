namespace MDSD.Permission.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
   
    using MedicalSystem.AnesWorkStation.Domain;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MDSD_MENU")]
    public partial class MDSD_MENU : BaseModel
    {
        [Key]
        public string MENU_CODE { get; set; }
        public string APPLICATION_CODE { get; set; }
        public string PARENT_MENU { get; set; }
        public string MENU_KEY { get; set; }
        public string MENU_LABEL { get; set; }
        public string MENU_STYLE { get; set; }
        public string MENU_ROUTE { get; set; }
        public string MENU_IMG { get; set; }
        public string MENU_DESC { get; set; }
        public Nullable<long> SERIAL_NO { get; set; }
        public Nullable<Int32> IS_DISABLE { get; set; }


        [NotMapped]
        public virtual ICollection<MDSD_FUNC> FUNC_LIST { get; set; }

        [NotMapped]
        public virtual ICollection<MDSD_MENU> SUB_MENU_LIST { get; set; }
    }
}