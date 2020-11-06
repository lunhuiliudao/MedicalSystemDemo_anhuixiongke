namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;

    /// <summary>
    /// 实体 病人计价单
    /// </summary>
    [Table("MED_ANES_VALUATION_LIST")]
    public partial class MED_ANES_VALUATION_LIST : BaseModel
    {
        [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 项目序号
        /// </summary>
        [Key]
        public Int32 VALUATION_NO { get; set; }
        /// <summary>
        /// 项目类别
        /// </summary>
        public string ITEM_CLASS { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 项目规格
        /// </summary>
        public string ITEM_SPEC { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Nullable<decimal> AMOUNT { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 状态;默认0 ;0 初始;1 麻醉医生提交;2 收费已审核
        /// </summary>
        public Nullable<Int32> STATUS { get; set; }
        /// <summary>
        /// 生成方式;1自动划价;2模板导入;3手工录入
        /// </summary>
        public Nullable<Int32> METHOD { get; set; }
        /// <summary>
        /// 操作者
        /// </summary>
        public string TECHNICIAN { get; set; }
        /// <summary>
        /// 开单科室
        /// </summary>
        public string ORDERED_BY { get; set; }
        /// <summary>
        /// 计价日期
        /// </summary>
        public Nullable<DateTime> BILLING_DATE_TIME { get; set; }
        /// <summary>
        /// 审核者
        /// </summary>
        public string VERIFIED_BY { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public Nullable<DateTime> VERIFIED_DATE_TIME { get; set; }
        public Nullable<decimal> DOSAGE { get; set; }

    }
}