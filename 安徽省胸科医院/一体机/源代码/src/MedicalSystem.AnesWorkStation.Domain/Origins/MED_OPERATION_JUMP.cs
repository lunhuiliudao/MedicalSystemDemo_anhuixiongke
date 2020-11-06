using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 手术跳转
    /// </summary>
    [Table("MED_OPERATION_JUMP")]
    public partial class MED_OPERATION_JUMP : BaseModel
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
        /// 跳转日期
        /// </summary>
        [Key]
        public DateTime JUMP_DATE { get; set; }

        /// <summary>
        /// 原手术状态
        /// </summary>
        public Int32 OPER_STATUS_OLD { get; set; }

        /// <summary>
        /// 新手术状态;跳转到的手术状态，默认麻醉结束状态
        /// </summary>
        public Int32 OPER_STATUS_NEW { get; set; }

        /// <summary>
        /// 跳转原因
        /// </summary>
        public string JUMP_REASON { get; set; }

        /// <summary>
        /// 操作者
        /// </summary>
        public string ENTERED_BY { get; set; }
    }
}
