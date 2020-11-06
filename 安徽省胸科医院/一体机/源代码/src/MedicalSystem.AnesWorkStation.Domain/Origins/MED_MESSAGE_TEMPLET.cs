namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;   
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 消息模板
    /// </summary>
    [Table("MED_MESSAGE_TEMPLET")]
    public partial class MED_MESSAGE_TEMPLET : BaseModel
    {
        /// <summary>
        /// 主键 消息ID
        /// </summary>
        [Key]
        public string TEMPLET_ID { get; set; }
        /// <summary>
        /// 消息模板内容
        /// </summary>
        public string TEMPLET_CONTENTS { get; set; }
        /// <summary>
        /// 消息类型;0 手术间协同消息模板。1 抢救消息模板
        /// </summary>
        public Int32 TEMPLETE_TYPE { get; set; }
    }
}