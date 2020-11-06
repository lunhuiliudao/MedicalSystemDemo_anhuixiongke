namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 检查主记录表
    /// </summary>
    [Table("MED_EXAM_MASTER")]
    public partial class MED_EXAM_MASTER : BaseModel
    {
                /// <summary>
        /// 主键 申请序号
        /// </summary>
        [Key]
        public string EXAM_NO { get; set; }
        /// <summary>
        /// 检查号类别
        /// </summary>
        public string LOCAL_ID_CLASS { get; set; }
        /// <summary>
        /// 检查标识号
        /// </summary>
        public string PATIENT_LOCAL_ID { get; set; }
        /// <summary>
        /// 病人标识号
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 病人本次住院标识
        /// </summary>
        public Nullable<Int32> VISIT_ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        ///   出生日期
        /// </summary>
        public Nullable<DateTime> DATE_OF_BIRTH { get; set; }
        /// <summary>
        /// 检查类别
        /// </summary>
        public string EXAM_CLASS { get; set; }
        /// <summary>
        /// 检查子类
        /// </summary>
        public string EXAM_SUB_CLASS { get; set; }
        /// <summary>
        ///   收到标本日期及时间
        /// </summary>
        public Nullable<DateTime> SPM_RECVED_DATE { get; set; }
        /// <summary>
        /// 临床性状
        /// </summary>
        public string CLIN_SYMP { get; set; }
        /// <summary>
        /// 体征
        /// </summary>
        public string PHYS_SIGN { get; set; }
        /// <summary>
        ///   相关化验结果
        /// </summary>
        public string RELEVANT_LAB_TEST { get; set; }
        /// <summary>
        /// 其他诊断
        /// </summary>
        public string RELEVANT_DIAG { get; set; }
        /// <summary>
        ///   临床诊断
        /// </summary>
        public string CLIN_DIAG { get; set; }
        /// <summary>
        /// 检查方式
        /// </summary>
        public string EXAM_MODE { get; set; }
        /// <summary>
        /// 检查分组
        /// </summary>
        public string EXAM_GROUP { get; set; }
        /// <summary>
        /// 使用仪器
        /// </summary>
        public string DEVICE { get; set; }
        /// <summary>
        /// 执行科室
        /// </summary>
        public string PERFORMED_BY { get; set; }
        /// <summary>
        /// 病人来源
        /// </summary>
        public string PATIENT_SOURCE { get; set; }
        /// <summary>
        /// 外来医疗单位名称
        /// </summary>
        public string FACILITY { get; set; }
        /// <summary>
        ///   申请日期及时间
        /// </summary>
        public Nullable<DateTime> REQ_DATE_TIME { get; set; }
        /// <summary>
        /// 申请科室
        /// </summary>
        public string REQ_DEPT { get; set; }
        /// <summary>
        ///   申请医生
        /// </summary>
        public string REQ_PHYSICIAN { get; set; }
        /// <summary>
        /// 申请备注
        /// </summary>
        public string REQ_MEMO { get; set; }
        /// <summary>
        ///   预约日期挤时间
        /// </summary>
        public Nullable<DateTime> SCHEDULED_DATE_TIME { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string NOTICE { get; set; }
        /// <summary>
        /// 检查日期及时间
        /// </summary>
        public Nullable<DateTime> EXAM_DATE_TIME { get; set; }
        /// <summary>
        /// 报告日期挤时间
        /// </summary>
        public Nullable<DateTime> REPORT_DATE_TIME { get; set; }
        /// <summary>
        /// 操作者
        /// </summary>
        public string TECHNICIAN { get; set; }
        /// <summary>
        /// 报告者
        /// </summary>
        public string REPORTER { get; set; }
        /// <summary>
        /// 检查结果状态
        /// </summary>
        public string RESULT_STATUS { get; set; }
        /// <summary>
        ///   审核者
        /// </summary>
        public string VERIFIED_BY { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public Nullable<DateTime> VERIFIED_DATE_TIME { get; set; }

    }
}