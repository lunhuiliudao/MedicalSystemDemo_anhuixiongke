﻿namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// 手术标记表
    /// </summary>
    [Table("MED_SHIFT_OPERATION_FILES")]
    public class MED_SHIFT_OPERATION_FILES : BaseModel
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
        /// 主键 手术号	;	一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 交班标识（1麻醉、2护理）
        /// </summary>
        [Key]
        public Int32 SHIFT_TYPE { get; set; }
        /// <summary>
        /// 主键 交班区分（1术前、2术后）
        /// </summary>
        [Key]
        public Int32 SHIFT_DIVISION { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FILE_NAME { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string OPERATOR { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public Nullable<DateTime> UPLOAD_DATETIME { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO { get; set; }

    }
}
