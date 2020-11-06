namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 患者住院记录表
    /// </summary>
    [Table("MED_PAT_VISIT")]
    public partial class MED_PAT_VISIT : BaseModel
    {
        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 住院号	;	唯一确定一名患者
        /// </summary>
        public string INP_NO { get; set; }
        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 患者来源	;	0 门诊，1 住院，2 急诊
        /// </summary>
        public Int32 PATIENT_SOURCE { get; set; }
        /// <summary>
        /// 病人所在院区	;	记录病人所在院区信息，对应院区代码表MED_HOSP_BRANCH_DICT
        /// </summary>
        public string HOSP_BRANCH { get; set; }
        /// <summary>
        /// 入院科室	;	对应科室代码表 
        /// </summary>
        public string DEPT_ADMISSION_TO { get; set; }
        /// <summary>
        /// 入院日期及时间	
        /// </summary>
        public Nullable<DateTime> ADMISSION_DATE_TIME { get; set; }
        /// <summary>
        /// 出院科室	;	对应科室代码表
        /// </summary>
        public string DEPT_DISCHARGE_FROM { get; set; }
        /// <summary>
        /// 出院日期及时间
        /// </summary>
        public Nullable<DateTime> DISCHARGE_DATE_TIME { get; set; }
        /// <summary>
        /// 职业	;	对应职业代码表
        /// </summary>
        public string OCCUPATION { get; set; }
        /// <summary>
        /// 婚姻状况	;	对应婚姻状况字典表，已婚、未婚、离婚、丧偶
        /// </summary>
        public string MARITAL_STATUS { get; set; }
        /// <summary>
        /// 身份	;	对应身份代码表
        /// </summary>
        public string IDENTITY { get; set; }
        /// <summary>
        /// 军种	;	对应军兵种字典
        /// </summary>
        public string ARMED_SERVICES { get; set; }
        /// <summary>
        /// 勤务	;	海勤、空勤，本系统定义，勤务字典
        /// </summary>
        public string DUTY { get; set; }
        public string TOP_UNIT { get; set; }
        public Nullable<Int32> SERVICE_SYSTEM_INDICATOR { get; set; }
        /// <summary>
        /// 合同单位
        /// </summary>
        public string UNIT_IN_CONTRACT { get; set; }
        /// <summary>
        /// 费别	;	费别字典
        /// </summary>
        public string CHARGE_TYPE { get; set; }
        /// <summary>
        /// 在职标志	;	0 在职,1 离休,2 退休
        /// </summary>
        public Nullable<Int32> WORKING_STATUS { get; set; }
        /// <summary>
        /// 医保类别
        /// </summary>
        public string INSURANCE_TYPE { get; set; }
        /// <summary>
        /// 医疗保险号
        /// </summary>
        public string INSURANCE_NO { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string SERVICE_AGENCY { get; set; }
        /// <summary>
        /// 通讯地址
        /// </summary>
        public string MAILING_ADDRESS { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZIP_CODE { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string NEXT_OF_KIN { get; set; }
        /// <summary>
        /// 与联系人关系
        /// </summary>
        public string RELATIONSHIP { get; set; }
        /// <summary>
        /// 联系人地址
        /// </summary>
        public string NEXT_OF_KIN_ADDR { get; set; }
        /// <summary>
        /// 联系人邮政编码	
        /// </summary>
        public string NEXT_OF_KIN_ZIPCODE { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string NEXT_OF_KIN_PHONE { get; set; }
        /// <summary>
        /// 入院方式	;	入院方式字典.门诊、急诊、转入
        /// </summary>
        public string PATIENT_CLASS { get; set; }
        /// <summary>
        /// 入院目的	;	入院目的字典.治疗、查体、计划生育等
        /// </summary>
        public string ADMISSION_CAUSE { get; set; }
        /// <summary>
        /// 接诊日期	
        /// </summary>
        public Nullable<DateTime> CONSULTING_DATE { get; set; }
        /// <summary>
        /// 入院病情	;	入院病情字典.危、急、一般 
        /// </summary>
        public string PAT_ADM_CONDITION { get; set; }
        /// <summary>
        /// 门诊医师
        /// </summary>
        public string CONSULTING_DOCTOR { get; set; }
        /// <summary>
        /// 办理住院者
        /// </summary>
        public string ADMITTED_BY { get; set; }
        /// <summary>
        /// 抢救次数
        /// </summary>
        public Nullable<Int32> EMER_TREAT_TIMES { get; set; }
        /// <summary>
        /// 抢救成功次数
        /// </summary>
        public Nullable<Int32> ESC_EMER_TIMES { get; set; }
        /// <summary>
        /// 重病天数
        /// </summary>
        public Nullable<Int32> SERIOUS_COND_DAYS { get; set; }
        /// <summary>
        /// 病危天数	
        /// </summary>
        public Nullable<Int32> CRITICAL_COND_DAYS { get; set; }
        /// <summary>
        /// ICU天数
        /// </summary>
        public Nullable<Int32> ICU_DAYS { get; set; }
        /// <summary>
        /// CCU天数
        /// </summary>
        public Nullable<Int32> CCU_DAYS { get; set; }
        /// <summary>
        /// 特级护理天数
        /// </summary>
        public Nullable<Int32> SPEC_LEVEL_NURS_DAYS { get; set; }
        /// <summary>
        /// 一级护理天数	
        /// </summary>
        public Nullable<Int32> FIRST_LEVEL_NURS_DAYS { get; set; }
        /// <summary>
        /// 二级护理天数	
        /// </summary>
        public Nullable<Int32> SECOND_LEVEL_NURS_DAYS { get; set; }
        /// <summary>
        /// 尸检标识	;	1 尸检,0 否 
        /// </summary>
        public Nullable<Int32> AUTOPSY_INDICATOR { get; set; }
        /// <summary>
        /// 血型	;	血型代码
        /// </summary>
        public string BLOOD_TYPE { get; set; }
        /// <summary>
        /// Rh血型	;	取值：+、-
        /// </summary>
        public string BLOOD_TYPE_RH { get; set; }
        /// <summary>
        /// 输液反应次数	
        /// </summary>
        public Nullable<Int32> INFUSION_REACT_TIMES { get; set; }
        /// <summary>
        /// 输血次数
        /// </summary>
        public Nullable<Int32> BLOOD_TRAN_TIMES { get; set; }
        /// <summary>
        /// 输血总量	
        /// </summary>
        public Nullable<Int32> BLOOD_TRAN_VOL { get; set; }
        /// <summary>
        /// 输血反应次数
        /// </summary>
        public Nullable<Int32> BLOOD_TRAN_REACT_TIMES { get; set; }
        /// <summary>
        /// 发生褥疮次数
        /// </summary>
        public Nullable<Int32> DECUBITAL_ULCER_TIMES { get; set; }
        /// <summary>
        /// 过敏药物
        /// </summary>
        public string ALERGY_DRUGS { get; set; }
        /// <summary>
        /// 不良反应药物	
        /// </summary>
        public string ADVERSE_REACTION_DRUGS { get; set; }
        /// <summary>
        /// 病案价值	
        /// </summary>
        public string MR_VALUE { get; set; }
        /// <summary>
        /// 病案质量	
        /// </summary>
        public string MR_QUALITY { get; set; }
        /// <summary>
        /// 随诊标志	
        /// </summary>
        public Nullable<Int32> FOLLOW_INDICATOR { get; set; }
        /// <summary>
        /// 随诊期限	
        /// </summary>
        public Nullable<Int32> FOLLOW_INTERVAL { get; set; }
        /// <summary>
        /// 随诊期限单位	;	年、月
        /// </summary>
        public string FOLLOW_INTERVAL_UNITS { get; set; }
        /// <summary>
        /// 科主任	
        /// </summary>
        public string DIRECTOR { get; set; }
        /// <summary>
        /// 主治医师	
        /// </summary>
        public string ATTENDING_DOCTOR { get; set; }
        /// <summary>
        /// 经治医师	
        /// </summary>
        public string DOCTOR_IN_CHARGE { get; set; }
        /// <summary>
        /// 出院方式	;	对应出院方式代码.正常、转院、死亡 
        /// </summary>
        public string DISCHARGE_DISPOSITION { get; set; }
        /// <summary>
        /// 总费用
        /// </summary>
        public Nullable<decimal> TOTAL_COSTS { get; set; }
        /// <summary>
        /// 实付费用	
        /// </summary>
        public Nullable<decimal> TOTAL_PAYMENTS { get; set; }
        /// <summary>
        /// 边牧日期	
        /// </summary>
        public Nullable<DateTime> CATALOG_DATE { get; set; }
        /// <summary>
        /// 边牧人
        /// </summary>
        public string CATALOGER { get; set; }
        public string RESERVED01 { get; set; }
        public string RESERVED02 { get; set; }
        public string RESERVED03 { get; set; }
        public string RESERVED04 { get; set; }
        public string RESERVED05 { get; set; }
        public Nullable<DateTime> RESERVED_DATE01 { get; set; }
        public Nullable<DateTime> RESERVED_DATE02 { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public Nullable<decimal> BODY_HEIGHT { get; set; }
        /// <summary>
        /// 体重	
        /// </summary>
        public Nullable<decimal> BODY_WEIGHT { get; set; }
        /// <summary>
        /// 病情状态	
        /// </summary>
        public string PATIENT_CONDITION { get; set; }
        public string ABNORMAL { get; set; }
    }
}