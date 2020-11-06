namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 麻醉事件收费对照表
    /// </summary>
    [Table("MED_EVENT_VS_BILL")]
    public partial class MED_EVENT_VS_BILL : BaseModel
    {
        /// <summary>
        /// 主键 事件类别	;对应事件类型代码表MED_EVENT_ITEM_CLASS_DICT
        /// </summary>
        [Key]
        public string EVENT_CLASS_CODE { get; set; }
        /// <summary>
        /// 主键 代码
        /// </summary>
        [Key]
        public string EVENT_ITEM_CODE { get; set; }
        /// <summary>
        /// 收费类型	;1-麻醉，2-手术，其它不收费
        /// </summary>
        public Nullable<Int32> REL_BILL { get; set; }
        /// <summary>
        /// 主键 项目分类	
        /// </summary>
        [Key]
        public string BILL_ITEM_CLASS { get; set; }
        /// <summary>
        /// 主键 项目代码
        /// </summary>
        [Key]
        public string BILL_ITEM_CODE { get; set; }
        /// <summary>
        /// 主键 项目规格
        /// </summary>
        [Key]
        public string BILL_ITEM_SPEC { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string MEMO { get; set; }
    }
}