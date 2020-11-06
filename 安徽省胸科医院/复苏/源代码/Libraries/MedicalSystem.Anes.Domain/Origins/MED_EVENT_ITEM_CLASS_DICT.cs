namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 事件类型代码表
    /// </summary>
    [Table("MED_EVENT_ITEM_CLASS_DICT")]
    public partial class MED_EVENT_ITEM_CLASS_DICT : BaseModel
    {
        /// <summary>
        /// 主键 事件类型代码	
        /// </summary>
        [Key]
        public string EVENT_CLASS_CODE { get; set; }
        /// <summary>
        /// 事件类型名称
        /// </summary>
        public string EVENT_CLASS_NAME { get; set; }
        public string INPUT_CODE { get; set; }
    }
}