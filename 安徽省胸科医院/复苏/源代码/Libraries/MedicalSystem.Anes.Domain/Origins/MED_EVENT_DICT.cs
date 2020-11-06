namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 麻醉事件定义
    /// </summary>
    [Table("MED_EVENT_DICT")]
    public partial class MED_EVENT_DICT : BaseModel
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
        /// 名称	;唯一索引
        /// </summary>
        public string EVENT_ITEM_NAME { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string EVENT_ITEM_SPEC { get; set; }
        /// <summary>
        /// 剂量	;默认剂量
        /// </summary>
        public Nullable<decimal> DOSAGE { get; set; }
        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DOSAGE_UNITS { get; set; }
        /// <summary>
        /// 用药途径
        /// </summary>
        public string ADMINISTRATOR { get; set; }
        /// <summary>
        /// 医嘱分类	;1 医嘱2 其他 
        /// </summary>
        public string OPER_CLASS { get; set; }
        /// <summary>
        /// 持续/一次性标识	;1-持续 
        /// </summary>
        public Nullable<Int32> DURATIVE_INDICATOR { get; set; }
        /// <summary>
        /// 方式	;例如PCA、液体通路等
        /// </summary>
        public string METHOD { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public Nullable<decimal> PERFORM_SPEED { get; set; }
        /// <summary>
        /// 速度单位
        /// </summary>
        public string SPEED_UNIT { get; set; }
        /// <summary>
        /// 属性1	;平衡液、血安定、贺斯、红细胞、血浆、血小板、其它等
        /// </summary>
        public string EVENT_ATTR { get; set; }
        /// <summary>
        /// 浓度
        /// </summary>
        public Nullable<decimal> CONCENTRATION { get; set; }
        /// <summary>
        /// 浓度单位
        /// </summary>
        public string CONCENTRATION_UNIT { get; set; }
        /// <summary>
        /// 属性2	;白蛋白，甘露醇 
        /// </summary>
        public string EVENT_ATTR2 { get; set; }
        /// <summary>
        /// 生产厂家	
        /// </summary>
        public string SUPPLIER_NAME { get; set; }
        /// <summary>
        /// 停用标识	;1 可用,0 停用 
        /// </summary>
        public Nullable<Int32> STOP_INDICATOR { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
    }
}