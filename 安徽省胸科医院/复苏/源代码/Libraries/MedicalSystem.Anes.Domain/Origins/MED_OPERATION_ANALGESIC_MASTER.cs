namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_OPERATION_ANALGESIC_MASTER")]
    public partial class MED_OPERATION_ANALGESIC_MASTER : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public Nullable<Int32> WEIGHT { get; set; }
        /// <summary>
        /// 途径
        /// </summary>
        public string ADMINISTRATION { get; set; }
        /// <summary>
        /// 穿刺水平
        /// </summary>
        public string PUNCTURE { get; set; }
        /// <summary>
        /// 只管深度
        /// </summary>
        public string PIPLE { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public string OTHER { get; set; }
        /// <summary>
        /// 镇痛方式
        /// </summary>
        public string ANALGESIC_METHOD { get; set; }
        /// <summary>
        /// 持续速率
        /// </summary>
        public Nullable<decimal> DURATIVE_SPEED { get; set; }
        /// <summary>
        /// 容量
        /// </summary>
        public Nullable<decimal> DURATIVE_DOSAGE { get; set; }
        /// <summary>
        /// 单次剂量
        /// </summary>
        public Nullable<decimal> FIRST_DOSAGE { get; set; }
        /// <summary>
        /// 锁定时间
        /// </summary>
        public Nullable<Int32> LOCK_TIME { get; set; }
        /// <summary>
        /// 1小时限量
        /// </summary>
        public Nullable<decimal> HOUR_DOSAGE { get; set; }
        /// <summary>
        /// 药物更改(0否,1是)
        /// </summary>
        public Nullable<Int32> ANALGESIC_CHANGE { get; set; }
        /// <summary>
        /// 药物更改内容
        /// </summary>
        public string ANALGESIC_CHANGE_TEXT { get; set; }
        /// <summary>
        /// 参数持续速率(0否,1是)
        /// </summary>
        public Nullable<Int32> DURATIVE_SPEED_CHANGE { get; set; }
        /// <summary>
        /// 参数持续速率内容
        /// </summary>
        public string DURATIVE_SPEED_CHANGE_TEXT { get; set; }
        /// <summary>
        /// 单次剂量(0否,1是)
        /// </summary>
        public Nullable<Int32> FIRST_DOSAGE_CHANGE { get; set; }
        /// <summary>
        /// 单次剂量内容
        /// </summary>
        public string FIRST_DOSAGE_CHANGE_TEXT { get; set; }
        /// <summary>
        /// 锁定时间(0否,1是)
        /// </summary>
        public Nullable<Int32> LOCK_TIME_CHANGE { get; set; }
        /// <summary>
        /// 锁定时间内容
        /// </summary>
        public string LOCK_TIME_CHANGE_TEXT { get; set; }
        /// <summary>
        /// 单次PCA(0否,1是)
        /// </summary>
        public Nullable<Int32> PCA_DOSAGE_CHANGE { get; set; }
        /// <summary>
        /// 单次PCA内容
        /// </summary>
        public string PCA_DOSAGE_CHANGE_TEXT { get; set; }
        /// <summary>
        /// 其他备注
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 处理内容
        /// </summary>
        public string CONTENT { get; set; }
        /// <summary>
        /// 镇痛泵开始时间
        /// </summary>
        public Nullable<DateTime> START_DATE_TIME { get; set; }
        /// <summary>
        /// 镇痛泵结束时间
        /// </summary>
        public Nullable<DateTime> END_DATE_TIME { get; set; }
        /// <summary>
        /// 镇痛泵类型
        /// </summary>
        public string ANALGESIC_PUMPS_TYPE { get; set; }
        /// <summary>
        /// 麻醉医师
        /// </summary>
        public string ANESTHESIA_DOCTOR { get; set; }
        /// <summary>
        /// 护士核对
        /// </summary>
        public string OPERATION_NURSE { get; set; }
        /// <summary>
        /// 病房护士
        /// </summary>
        public string WARD_NURSE { get; set; }

    }
}