namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 患者在院记录表
    /// </summary>
    [Table("MED_PATS_IN_HOSPITAL")]
    public partial class MED_PATS_IN_HOSPITAL : BaseModel
    {
        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 住院号;唯一确定一名患者
        /// </summary>
        public string INP_NO { get; set; }
        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 患者来源;0 门诊,1 住院,2 急诊
        /// </summary>
        public Int32 PATIENT_SOURCE { get; set; }
        /// <summary>
        /// 病人所在院区;记录病人所在院区信息,对应院区代码表MED_HOSP_BRANCH_DICT
        /// </summary>
        public string HOSP_BRANCH { get; set; }
        /// <summary>
        /// 入科次数
        /// </summary>
        public Nullable<Int32> DEP_ID { get; set; }
        /// <summary>
        /// 病区代码
        /// </summary>
        public string WARD_CODE { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO { get; set; }
        /// <summary>
        /// 入院日期
        /// </summary>
        public Nullable<DateTime> ADMISSION_DATE_TIME { get; set; }
        /// <summary>
        /// 入科日期
        /// </summary>
        public Nullable<DateTime> ADM_WARD_DATE_TIME { get; set; }
        /// <summary>
        /// 主要诊断
        /// </summary>
        public string DIAGNOSIS { get; set; }
        /// <summary>
        /// 病情状态
        /// </summary>
        public string PATIENT_CONDITION { get; set; }
        /// <summary>
        /// 血型
        /// </summary>
        public string BLOOD_TYPE { get; set; }
        /// <summary>
        /// Rh血型
        /// </summary>
        public string BLOOD_TYPE_RH { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public Nullable<decimal> BODY_HEIGHT { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public Nullable<decimal> BODY_WEIGHT { get; set; }
        /// <summary>
        /// 护理等级
        /// </summary>
        public string NURSING_CLASS { get; set; }
        /// <summary>
        /// 经治医生
        /// </summary>
        public string DOCTOR_IN_CHARGE { get; set; }
        /// <summary>
        /// 主管护师
        /// </summary>
        public string NURSE_IN_CHARGE { get; set; }
        /// <summary>
        /// 手术日期
        /// </summary>
        public Nullable<DateTime> OPERATING_DATE { get; set; }
        /// <summary>
        /// 计价截止日期
        /// </summary>
        public Nullable<DateTime> BILLING_DATE_TIME { get; set; }
        /// <summary>
        /// 预交金额
        /// </summary>
        public Nullable<decimal> PREPAYMENTS { get; set; }
        /// <summary>
        /// 累计未结费用
        /// </summary>
        public Nullable<decimal> TOTAL_COSTS { get; set; }
        /// <summary>
        /// 优惠后未结费用
        /// </summary>
        public Nullable<decimal> TOTAL_CHARGES { get; set; }
        /// <summary>
        /// 担保人
        /// </summary>
        public string GUARANTOR { get; set; }
        /// <summary>
        /// 担保人单位
        /// </summary>
        public string GUARANTOR_ORG { get; set; }
        /// <summary>
        /// 担保人电话
        /// </summary>
        public string GUARANTOR_PHONE_NUM { get; set; }
        /// <summary>
        /// 计价截止日期
        /// </summary>
        public Nullable<DateTime> BILL_CHECKED_DATE_TIME { get; set; }
        /// <summary>
        /// 出院结算标志
        /// </summary>
        public Nullable<Int32> SETTLED_INDICATOR { get; set; }
        public string RESERVED01 { get; set; }
        public string RESERVED02 { get; set; }
        public string RESERVED03 { get; set; }
        public Nullable<DateTime> RESERVED_DATE01 { get; set; }
        public Nullable<DateTime> RESERVED_DATE02 { get; set; }
    }
}