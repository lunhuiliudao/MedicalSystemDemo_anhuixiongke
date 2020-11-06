namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 权限字典表
    /// </summary>
    [Table("MED_PERMISSIONS")]
    public partial class MED_PERMISSIONS : BaseModel
    {
        /// <summary>
        /// 主键 权限ID
        /// </summary>
        [Key]
        public string PERMISSION_ID { get; set; }
        /// <summary>
        /// 父节点ID 
        /// </summary>
        public string PARENT_PERMISSION_ID { get; set; }
        /// <summary>
        /// 应用程序ID 
        /// </summary>
        public string APP_ID { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        public string PERMISSION_NAME { get; set; }
        /// <summary>
        /// KEY
        /// </summary>
        public string PERMISSION_KEY { get; set; }
        /// <summary>
        /// 	排序号
        /// </summary>
        public Nullable<long> SORT_ID { get; set; }
        /// <summary>
        /// 有效标识位
        /// </summary>
        public string IS_VALID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string MEMO { get; set; }
    }
}