namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 用户电子签名（HIS）
    /// </summary>
    [Table("MED_HIS_USERS_INFO")]
    public partial class MED_HIS_USERS_INFO : BaseModel
    {
        /// <summary>
        /// 主键 医护人员工号	;医护人员工号
        /// </summary>
        [Key]
        public string USER_JOB_ID { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public byte[] SIGNATURE { get; set; }
    }
}