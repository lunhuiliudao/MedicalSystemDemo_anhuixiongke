namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_QIXIE_QINGDIAN")]
    public partial class MED_QIXIE_QINGDIAN : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        [Key]
        public long X_POSITION { get; set; }
        [Key]
        public long Y_POSITION { get; set; }
        public string POSITION_VALUE { get; set; }
        [Key]
        public string TABLETAG { get; set; }

    }
}