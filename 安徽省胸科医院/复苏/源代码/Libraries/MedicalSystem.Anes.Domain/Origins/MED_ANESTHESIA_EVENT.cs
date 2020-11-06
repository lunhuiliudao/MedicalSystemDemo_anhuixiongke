namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 麻醉事件表
    /// </summary>
    [Table("MED_ANESTHESIA_EVENT")]
    public partial class MED_ANESTHESIA_EVENT : BaseModel
    {
        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 事件序号	;	总的事件序号，按病人一次手术标识排序
        /// </summary>
        [Key]
        public Int32 ITEM_NO { get; set; }
        /// <summary>
        /// 主键 分类事件项目	;	按事件类别排序,大量都是0，只有很少的为1 
        /// </summary>
        [Key]
        public string EVENT_NO { get; set; }
        /// <summary>
        /// 事件类别	;	对应事件类型代码表,MED_EVENT_ITEM_CLASS_DICT
        /// </summary>
        public string EVENT_CLASS_CODE { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string EVENT_ITEM_NAME { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string EVENT_ITEM_CODE { get; set; }
        /// <summary>
        /// 项目规格
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
        /// 用药途径	;	见用药途径代码表
        /// </summary>
        public string ADMINISTRATOR { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public Nullable<DateTime> START_TIME { get; set; }
        /// <summary>
        /// 结束时间	
        /// </summary>
        public Nullable<DateTime> END_TIME { get; set; }
        /// <summary>
        /// 划价标志	;	0 未划价，默认,1 已划价 
        /// </summary>
        public Nullable<Int32> BILL_INDICATOR { get; set; }
        /// <summary>
        /// 持续标志	;	1 持续用药,0 一次性用药  默认
        /// </summary>
        public Nullable<Int32> DURATIVE_INDICATOR { get; set; }
        /// <summary>
        /// 用药方式	;	见用药方式代码表,例如PCA、液体通路等 
        /// </summary>
        public string METHOD { get; set; }
        /// <summary>
        /// 父方式号;EVENT_ITEM_NO	
        /// </summary>
        public Nullable<Int32> METHOD_PARENT_NO { get; set; }
        /// <summary>
        /// 流速
        /// </summary>
        public Nullable<decimal> PERFORM_SPEED { get; set; }
        /// <summary>
        /// 流速单位
        /// </summary>
        public string SPEED_UNIT { get; set; }
        /// <summary>
        /// 父事件序号	;	用于处理浓度、速度变化情况 EVENT_ITEM_NO
        /// </summary>
        public Nullable<Int32> PARENT_ITEM_NO { get; set; }
        /// <summary>
        /// 属性	;	衡液、血安定、贺斯、红细胞、血浆、血小板、其它等
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
        /// 生产厂家
        /// </summary>
        public string SUPPLIER_NAME { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public string RESERVED4 { get; set; }
    }
}