namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

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


    public partial class MED_CONFIGPara
    {
        [Key]
        public string KeyStr { get; set; }

        public string[] ValueStr { get; set; }
    }
}