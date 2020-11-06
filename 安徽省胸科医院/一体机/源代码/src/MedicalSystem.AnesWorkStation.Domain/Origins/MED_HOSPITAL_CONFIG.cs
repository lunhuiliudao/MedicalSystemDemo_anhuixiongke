namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 医院信息配置字典表
    /// </summary>
    [Table("MED_HOSPITAL_CONFIG")]
    public partial class MED_HOSPITAL_CONFIG : BaseModel
    {
        /// <summary>
        /// 主键 医院唯一标识
        /// </summary>
        [Key]
        public string HOSPITAL_ID { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HOSPITAL_NAME { get; set; }
        /// <summary>
        /// 授权码
        /// </summary>
        public string AUTHORIZED_KEY { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string LOCATION { get; set; }
        /// <summary>
        /// 通讯地址
        /// </summary>
        public string MAILING_ADDRESS { get; set; }
        /// <summary>
        /// 邮编 
        /// </summary>
        public string ZIP_CODE { get; set; }
        /// <summary>
        /// 床位数
        /// </summary>
        public Nullable<Int32> APPROVED_BED_NUM { get; set; }
        /// <summary>
        /// 等级 
        /// </summary>
        public string HOSPITAL_CLASS { get; set; }
    }
}