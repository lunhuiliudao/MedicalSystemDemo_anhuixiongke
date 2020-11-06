namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 手术间默认仪器对照表
    /// </summary>
    [Table("MED_OPERATING_ROOM_VS_MONITOR")]
    public partial class MED_OPERATING_ROOM_VS_MONITOR : BaseModel
    {
        /// <summary>
        /// 主键 手术间号
        /// </summary>
        [Key]
        public string ROOM_NO { get; set; }
        /// <summary>
        /// 主键 所在科室代码
        /// </summary>
        [Key]
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 主键 仪器标示
        /// </summary>
        [Key]
        public string MONITOR_LABEL { get; set; }
    }
}