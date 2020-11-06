namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 麻醉事件定义扩展表
    /// </summary>
    [Table("MED_EVENT_DICT_EXT")]
    public partial class MED_EVENT_DICT_EXT : BaseModel
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
        /// 主键 序号
        /// </summary>
        [Key]
        public Int32 DOSAGE_NO { get; set; }
        /// <summary>
        /// 常用标准剂量	;常用标准剂量
        /// </summary>
        public Nullable<decimal> STANDARD_DOSAGE { get; set; }
        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DOSAGE_UNITS { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
        /// <summary>
        /// 常用速度
        /// </summary>
        public Nullable<decimal> STANDARD_SPEED { get; set; }
        /// <summary>
        /// 速度单位
        /// </summary>
        public string SPEED_UNITS { get; set; }
        /// <summary>
        /// 常用浓度
        /// </summary>
        public Nullable<decimal> STANDARD_CONCENTRATION { get; set; }
        /// <summary>
        /// 浓度单位
        /// </summary>
        public string CONCENTRATION_UNIT { get; set; }
    }
}