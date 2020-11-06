namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 医嘱表
    /// </summary>
    [Table("MED_ORDERS")]
    public partial class MED_ORDERS : BaseModel
    {
        /// <summary>
        /// 主键 病人id
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 医嘱序号
        /// </summary>
        [Key]
        public string ORDER_NO { get; set; }
        /// <summary>
        /// 主键 医嘱子序号
        /// </summary>
        [Key]
        public long ORDER_SUB_NO { get; set; }
        /// <summary>
        /// 长期医嘱标志
        /// </summary>
        public Nullable<Int32> REPEAT_INDICATOR { get; set; }
        /// <summary>
        /// 医嘱类别
        /// </summary>
        public string ORDER_CLASS { get; set; }
        /// <summary>
        /// 医嘱正文
        /// </summary>
        public string ORDER_TEXT { get; set; }
        /// <summary>
        /// 医嘱代码
        /// </summary>
        public string ORDER_CODE { get; set; }
        /// <summary>
        /// 药品一次使用剂量
        /// </summary>
        public Nullable<decimal> DOSAGE { get; set; }
        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DOSAGE_UNITS { get; set; }
        /// <summary>
        /// 给药途径和方法
        /// </summary>
        public string ADMINISTRATION { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public Nullable<DateTime> START_DATE_TIME { get; set; }
        /// <summary>
        /// 停止时间
        /// </summary>
        public Nullable<DateTime> STOP_DATE_TIME { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public Nullable<Int32> DURATION { get; set; }
        /// <summary>
        /// 持续时间单位
        /// </summary>
        public string DURATION_UNITS { get; set; }
        /// <summary>
        /// 执行频率描述
        /// </summary>
        public string FREQUENCY { get; set; }
        /// <summary>
        /// 执行频率次数
        /// </summary>
        public Nullable<Int32> FREQ_COUNTER { get; set; }
        /// <summary>
        /// 频率间隔
        /// </summary>
        public Nullable<Int32> FREQ_INTERVAL { get; set; }
        /// <summary>
        /// 频率间隔单位
        /// </summary>
        public string FREQ_INTERVAL_UNIT { get; set; }
        /// <summary>
        /// 频率时间详细描述
        /// </summary>
        public string FREQ_DETAIL { get; set; }
        /// <summary>
        /// 护士执行时间
        /// </summary>
        public string PERFORM_SCHEDULE { get; set; }
        /// <summary>
        /// 执行结果
        /// </summary>
        public string PERFORM_RESULT { get; set; }
        /// <summary>
        /// 开医嘱科室
        /// </summary>
        public string ORDERING_DEPT { get; set; }
        /// <summary>
        /// 开医嘱医生
        /// </summary>
        public string DOCTOR { get; set; }
        /// <summary>
        /// 停止医嘱医生
        /// </summary>
        public string STOP_DOCTOR { get; set; }
        /// <summary>
        /// 开医嘱校对护士
        /// </summary>
        public string NURSE { get; set; }
        /// <summary>
        /// 停医嘱校对护士
        /// </summary>
        public string STOP_NURSE { get; set; }
        /// <summary>
        /// 开医嘱录入日期及时间
        /// </summary>
        public Nullable<DateTime> ENTER_DATE_TIME { get; set; }
        /// <summary>
        /// 听医嘱录入日期挤时间
        /// </summary>
        public Nullable<DateTime> STOP_ORDER_DATE_TIME { get; set; }
        /// <summary>
        /// 医嘱状态
        /// </summary>
        public string ORDER_STATUS { get; set; }
        /// <summary>
        /// 计价属性
        /// </summary>
        public Nullable<Int32> BILLING_ATTR { get; set; }
        /// <summary>
        /// 最后一次执行日期及时间
        /// </summary>
        public Nullable<DateTime> LAST_PERFORM_DATE_TIME { get; set; }
        /// <summary>
        /// 最后一次计价日期挤时间
        /// </summary>
        public Nullable<DateTime> LAST_ACCTING_DATE_TIME { get; set; }
        /// <summary>
        /// 药品计价属性
        /// </summary>
        public Nullable<Int32> DRUG_BILLING_ATTR { get; set; }
        /// <summary>
        /// 治疗单标志
        /// </summary>
        public string TREAT_SHEET_FLAG { get; set; }
        /// <summary>
        /// 药品代码
        /// </summary>
        public string PHAM_STD_CODE { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Nullable<Int32> AMOUNT { get; set; }
        /// <summary>
        /// 白药描述
        /// </summary>
        public string DISPENSE_MEMOS { get; set; }
        /// <summary>
        /// 当前处方号
        /// </summary>
        public Nullable<Int32> CURRENT_PRESC_NO { get; set; }
        /// <summary>
        /// 药品规格
        /// </summary>
        public string DRUG_SPEC { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Nullable<decimal> QTY { get; set; }
        /// <summary>
        /// 抗生素
        /// </summary>
        public string ANTIBIOTIC { get; set; }
        /// <summary>
        /// 保留字
        /// </summary>
        public string RESERVED1 { get; set; }
    }
}