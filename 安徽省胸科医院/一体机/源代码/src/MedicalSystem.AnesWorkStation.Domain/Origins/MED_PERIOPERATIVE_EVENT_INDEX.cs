namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_PERIOPERATIVE_EVENT_INDEX")]
    public partial class MED_PERIOPERATIVE_EVENT_INDEX : BaseModel
    {
        [Key]
        public string INDEX_ID { get; set; }
        public string PATIENT_ID { get; set; }
        public string VISIT_ID { get; set; }
        public Nullable<Int32> OPER_ID { get; set; }
        public string EVENT_ID { get; set; }
        public string INDEX_LABEL { get; set; }
        public Nullable<DateTime> EVENT_TIME { get; set; }
        public string DATA_KEY_VAL { get; set; }
        public string SELECT_SQL { get; set; }
        public string DLL_FUNCTION { get; set; }
        public string DLL_FUNCTION_PARAMVALS { get; set; }
        public string EXE_PATH { get; set; }
        public string WEBPAGE_URL { get; set; }
        public string WARNING_PROMPT { get; set; }
        public string MEMO { get; set; }
        public string EVENT_CATEGORY { get; set; }
    }
}