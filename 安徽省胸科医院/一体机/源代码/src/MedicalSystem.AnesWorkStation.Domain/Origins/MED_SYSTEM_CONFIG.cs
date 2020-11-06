namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using Dapper.Data;
   

    /// <summary>
    /// 实体
    /// </summary>
    [Table("MED_SYSTEM_CONFIG")]
    public partial class MED_SYSTEM_CONFIG : BaseModel
    {
        /// <summary>
        /// 主键 途径编码
        /// </summary>
        [Key]
        public string SYS_ID { get; set; }

        public string CONFIG_JSON { get; set; }
    }
}