namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_SCREEN_MSG")]
    public partial class MED_SCREEN_MSG : BaseModel
    {
        [Key]
        public string ID { get; set; }
        public string MSG { get; set; }
        public Nullable<DateTime> INSERT_TIME { get; set; }
        public Nullable<Int32> COUNTS { get; set; }
        public Nullable<Int32> STATUS { get; set; }
        public Nullable<Int32> OTHER1 { get; set; }
        public string USER_ID { get; set; }
        public Nullable<Int32> TYPE { get; set; }
        public string DEPT_CODE { get; set; }
    }
}