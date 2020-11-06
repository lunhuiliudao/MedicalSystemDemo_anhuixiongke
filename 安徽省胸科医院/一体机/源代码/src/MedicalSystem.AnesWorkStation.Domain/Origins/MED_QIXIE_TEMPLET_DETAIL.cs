namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_QIXIE_TEMPLET_DETAIL")]
    public partial class MED_QIXIE_TEMPLET_DETAIL : BaseModel
    {
                public Nullable<Int32> SERIAL_NO { get; set; }
        [Key]
        public string TEMPLET_GUID { get; set; }
        [Key]
        public string ITEM_NAME { get; set; }
        public string ITEM_VALUE { get; set; }

    }
}