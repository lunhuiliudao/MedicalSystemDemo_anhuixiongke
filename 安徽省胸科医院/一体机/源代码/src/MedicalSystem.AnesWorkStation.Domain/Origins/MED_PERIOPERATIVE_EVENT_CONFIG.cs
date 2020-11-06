namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;   
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_PERIOPERATIVE_EVENT_CONFIG")]
    public partial class MED_PERIOPERATIVE_EVENT_CONFIG : BaseModel
    {
        [Key]
        public string EVENT_ID { get; set; }
        public Nullable<Int32> SERIAL_NO { get; set; }
        public string EVENT_NAME { get; set; }
        public string EVENT_PERIOD { get; set; }
        public string EVENT_CLASS { get; set; }
        public string DATA_SOURCE { get; set; }
        public string DATA_SOURCE_TYPE { get; set; }
        public string DATA_KEY { get; set; }
        public string DLL_FUNCTION { get; set; }
        public string DLL_FUNCTION_PARAMS { get; set; }
        public string EXE_FUNCTION { get; set; }
        public string WEBPAGE_FUNCTION { get; set; }
        public string DATA_SELECT { get; set; }
        public string DATA_IND { get; set; }
        public string EVENT_STUTAS { get; set; }
        public Nullable<Int32> DISPLAY_ORDER { get; set; }
        public string PRIORITY { get; set; }
        public string WARNING_PROMPT { get; set; }
        public string MEMO { get; set; }
        public string EVENT_CATEGORY { get; set; }
        public string INDEX_LABEL_FORMAT { get; set; }
        public string EVENT_TIME_FIELD { get; set; }
        public string IFSHOWINCLIENT { get; set; }
        public string CLIENT_ALIAES { get; set; }
        public string IMG_ID { get; set; }
        public string ISSHOWINDEXONMENU { get; set; }
    }
}