namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 采集扩展表
    /// </summary>
    [Table("MED_COMM_VITAL_REC_EXTEND")]
    public partial class MED_COMM_VITAL_REC_EXTEND : BaseModel
    {
                /// <summary>
        /// 主键 患者ID
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 入科次数或手术次数
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public Nullable<DateTime> RECORDING_DATE { get; set; }
        /// <summary>
        /// 主键 体征时间
        /// </summary>
        [Key]
        public DateTime TIME_POINT { get; set; }
        /// <summary>
        /// 主键 项目名称
        /// </summary>
        [Key]
        public string VITAL_SIGNS { get; set; }
        /// <summary>
        /// 项目代码
        /// </summary>
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string VITAL_SIGNS_VALUES { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 操作者
        /// </summary>
        public string OPERATOR { get; set; }
        /// <summary>
        /// 仪器标签
        /// </summary>
        public string MONITOR_LABEL { get; set; }
        /// <summary>
        /// 数据类型(0-手术、1-术后复苏)
        /// </summary>
        public string DATA_TYPE { get; set; }

    }
}