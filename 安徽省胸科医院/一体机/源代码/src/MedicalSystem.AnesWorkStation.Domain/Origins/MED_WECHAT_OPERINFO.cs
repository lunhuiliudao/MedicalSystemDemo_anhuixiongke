using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain.Origins
{

    /// <summary>
    /// 实体 手术信息表
    /// </summary>
    [Table("MED_WECHAT_OPERINFO")]
    public class MED_WECHAT_OPERINFO : BaseModel
    {
        /// <summary>
        /// 主键 GUID,系统自动生成	
        /// </summary>
        [Key]
        public string OPERINFO_ID { get; set; }

        /// <summary>
        /// 医院ID，唯一标识
        /// </summary>
        public string HOSPITAL_ID { get; set; }

        /// <summary>
        /// JSON数据
        /// </summary>
        public string JSON_DATA { get; set; }

        /// <summary>
        /// 接受时间
        /// </summary>
        public DateTime? RECIVE_DATE { get; set; }

    }
}
