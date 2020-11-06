namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_USER_NOTE")]
    public partial class MED_USER_NOTE : BaseModel
    {
                /// <summary>
        /// 主键 用户ID
        /// </summary>
        [Key]
        public string USER_ID { get; set; }
        /// <summary>
        /// 主键 创建时间
        /// </summary>
        [Key]
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string CONTENT { get; set; }

    }
}