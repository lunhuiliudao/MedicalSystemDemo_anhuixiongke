using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{

    /// <summary>
    /// 实体 病人费用明细记录
    /// </summary>
    [Table("MED_INP_BILL_DETAIL")]
    public partial class MED_INP_BILL_DETAIL : BaseModel
    {
        /// <summary>
        /// 主键 病人ID
        /// </summary>
        [Key]
        public String PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数
        /// </summary>
        [Key]
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号
        /// </summary>
        [Key]
        public int OPER_ID { get; set; }
        [Key]
        public int ITEM_NO { get; set; }
        /// <summary>
        /// 项目分类
        /// </summary>
        public string ITEM_CLASS { get; set; }
        /// <summary>
        /// 项目代码
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
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal? PRICE { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? AMOUNT { get; set; }
        /// <summary>
        /// 生成方式
        /// </summary>
        public int? METHOD { get; set; }
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
        public DateTime? BILLING_DATE_TIME { get; set; }
        /// <summary>
        /// 审核者
        /// </summary>
        public string VERIFIED_BY { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? VERIFIED_DATE_TIME { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        public decimal? COSTS { get; set; }
        /// <summary>
        /// 应收费用
        /// </summary>
        public decimal? CHARGES { get; set; }
        /// <summary>
        /// 计价员号
        /// </summary>
        public string OPERATOR_NO { get; set; }
        /// <summary>
        /// 结算序号
        /// </summary>
        public string RCPT_NO { get; set; }
        public decimal? SPECIAL_FEE { get; set; }
        public string INSUR_FEE { get; set; }
        public string WARD_CODE { get; set; }
        public string ORDERED_DOCTOR_GROUP { get; set; }
        public string ORDERED_EMP_NO { get; set; }
        public string ORDERED_DOCTOR { get; set; }
        public string PERFORMED_DOCTOR_GROUP { get; set; }
        public string PERFOREED_EMP_NO { get; set; }
        public string PERFORMED_DOCTOR { get; set; }
        public int? REFUND_TIME_NO { get; set; }
        public decimal? DOSAGE { get; set; }
        //0-未提交；1-已提交
        public int? EXCHANGE_STATUS { get; set; }
        public string ANES_ITEM_NAME { get; set; }
    }
}