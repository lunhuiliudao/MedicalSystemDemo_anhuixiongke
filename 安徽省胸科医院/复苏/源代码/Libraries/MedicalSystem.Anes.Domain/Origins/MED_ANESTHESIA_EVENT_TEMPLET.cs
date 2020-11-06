namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 麻醉事件模板定义表
    /// </summary>
    [Table("MED_ANESTHESIA_EVENT_TEMPLET")]
    public partial class MED_ANESTHESIA_EVENT_TEMPLET : BaseModel
    {
                /// <summary>
        /// 主键 模板名称
        /// </summary>
        [Key]
        public string TEMPLET_NAME { get; set; }
        /// <summary>
        /// 主键 模板所有者  ;  默认“公共”  
        /// </summary>
        [Key]
        public string CREATE_BY { get; set; }
        /// <summary>
        /// 模板类别  ;  1/PACU、2/手术室、0/通用，默认0 
        /// </summary>
        public string TEMPLET_CLASS { get; set; }
        /// <summary>
        /// 麻醉方法  ;  * - 通用，默认*
        /// </summary>
        public string ANESTHESIA_METHOD { get; set; }
        /// <summary>
        /// 事件类别
        /// </summary>
        public string EVENT_ITEM_CLASS { get; set; }
        /// <summary>
        /// 主键 项目序号
        /// </summary>
        [Key]
        public Int32 EVENT_ITEM_NO { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string EVENT_ITEM_NAME { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string EVENT_ITEM_CODE { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string EVENT_ITEM_SPEC { get; set; }
        /// <summary>
        /// 剂量
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
        /// 持续/一次性标志  ;  0 默认一次性用药；1-持续
        /// </summary>
        public Nullable<Int32> DURATIVE_INDICATOR { get; set; }
        /// <summary>
        /// 方式  ;  例如PCA等
        /// </summary>
        public string METHOD { get; set; }
        /// <summary>
        /// 父方式号
        /// </summary>
        public Nullable<Int32> METHOD_PARENT_NO { get; set; }
        /// <summary>
        /// 流速  ;  输液滴入速度
        /// </summary>
        public Nullable<decimal> PERFORM_SPEED { get; set; }
        /// <summary>
        /// 流速单位
        /// </summary>
        public string SPEED_UNIT { get; set; }
        /// <summary>
        /// 浓度  
        /// </summary>
        public Nullable<decimal> CONCENTRATION { get; set; }
        /// <summary>
        /// 浓度单位  
        /// </summary>
        public string CONCENTRATION_UNIT { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public string EVENT_ATTR { get; set; }
        /// <summary>
        /// 距离录入的时间间隔
        /// </summary>
        public decimal START_AFTER_INPUT { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public Nullable<decimal> DURATIVE { get; set; }
        /// <summary>
        /// 父事件序号  ;  用于处理浓度、速度变化情况
        /// </summary>
        public Nullable<Int32> PARENT_ITEM_NO { get; set; }
        /// <summary>
        /// 收费属性  
        /// </summary>
        public Nullable<Int32> BILL_ATTR { get; set; }

    }
}