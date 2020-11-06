namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 收费明细表
    /// </summary>
    [Table("MED_OPERATION_BILL_DETAIL")]
    public partial class MED_OPERATION_BILL_DETAIL : BaseModel
    {
                /// <summary>
        /// 主键 病人标识号
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 病人本次住院标识 
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 病人本次手术标识
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 项目序号;一个病人的费用项目的唯一标识
        /// </summary>
        [Key]
        public Int32 ITEM_NO { get; set; }
        /// <summary>
        /// 主键 收费类别;1-麻醉，0-手术
        /// </summary>
        [Key]
        public Int32 BILL_ATTR { get; set; }
        /// <summary>
        /// 项目类别;按价表项目分类
        /// </summary>
        public string ITEM_CLASS { get; set; }
        /// <summary>
        /// 项目类别名称;按价表项目分类
        /// </summary>
        public string ITEM_CLASS_NAME { get; set; }
        /// <summary>
        /// 项目名称;按价表项目名称
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 项目代码;对应于价表中的项目代码，当不能对应到具体的项目时，代码为’*’
        /// </summary>
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 项目规格;指药品的规格或材料的规格。
        /// </summary>
        public string ITEM_SPEC { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 单价价格
        /// </summary>
        public Nullable<decimal> PRICE { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Nullable<decimal> AMOUNT { get; set; }
        /// <summary>
        /// 费用;每条总价
        /// </summary>
        public Nullable<decimal> COSTS { get; set; }
        /// <summary>
        /// 应收费用;考虑病人费别或特殊优惠后病人应交的费用
        /// </summary>
        public Nullable<decimal> CHARGES { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string SUPPLIER_NAME { get; set; }
        /// <summary>
        /// 库存标志;1 已减，0 未减
        /// </summary>
        public Nullable<Int32> STORAGE_INDICATOR { get; set; }
        /// <summary>
        /// 对应事件分类
        /// </summary>
        public string EVENT_ITEM_CLASS { get; set; }
        /// <summary>
        /// 对应事件名称
        /// </summary>
        public string EVENT_ITEM_NAME { get; set; }
        /// <summary>
        /// 对应事件序号
        /// </summary>
        public Nullable<Int32> EVENT_ITEM_NO { get; set; }
        /// <summary>
        /// 处方号
        /// </summary>
        public string SCRIPTION_NO { get; set; }
        /// <summary>
        /// 处方类型
        /// </summary>
        public string SCRIPTION_TYPE { get; set; }
        /// <summary>
        /// 处方类型
        /// </summary>
        public string SCRIPTION_NAME { get; set; }
        /// <summary>
        /// 处方备注
        /// </summary>
        public string SCRIPTION_MEMO { get; set; }
        /// <summary>
        /// 确认收费信息，0 未收，1 已收，2收费到HIS异常
        /// </summary>
        public Nullable<decimal> EXCHANGE_INDICATOR { get; set; }
        /// <summary>
        /// 此项目对住院病人在收据中应归属的费用类别
        /// </summary>
        public string CLASS_ON_INP_RCPT { get; set; }
        /// <summary>
        /// 此项目对门诊病人在收据中应归属的费用类别
        /// </summary>
        public string CLASS_ON_OUTP_RCPT { get; set; }
        /// <summary>
        /// 此项目在经济核算中应归属的费用类别
        /// </summary>
        public string CLASS_ON_RECKONING { get; set; }
        /// <summary>
        /// 此项目收入归属的会计科目
        /// </summary>
        public string SUBJ_CODE { get; set; }
        /// <summary>
        /// 此项目对应住院病人在病案首页中应归属的费用类别 
        /// </summary>
        public string CLASS_ON_MR { get; set; }
        /// <summary>
        /// 收费排序
        /// </summary>
        public Nullable<Int32> BILL_SORT { get; set; }
        /// <summary>
        /// 备注;用于对收费标准的说明
        /// </summary>
        public string NOTES { get; set; }

    }
}