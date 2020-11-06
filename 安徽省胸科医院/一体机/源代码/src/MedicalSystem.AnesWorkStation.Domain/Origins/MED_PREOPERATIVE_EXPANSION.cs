namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_PREOPERATIVE_EXPANSION")]
    public partial class MED_PREOPERATIVE_EXPANSION : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        [Key]
        public string ITEM_NAME { get; set; }
        public string ITEM_VALUE { get; set; }

    }
}