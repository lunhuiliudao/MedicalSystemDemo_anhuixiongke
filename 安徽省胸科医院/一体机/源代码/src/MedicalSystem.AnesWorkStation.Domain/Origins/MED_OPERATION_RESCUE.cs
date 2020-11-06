using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain.Origins
{
    /// <summary>
    /// 实体 抢救结束确认表
    /// </summary>
    [Table("MED_OPERATION_RESCUE")]
    public partial class MED_OPERATION_RESCUE : BaseModel
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
        /// 手术安排标识	;	与手术主表的OPER_ID对应
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }

        /// <summary>
        /// 主键 手术取消标识	;抢救标识(从1开始顺序递增)
        /// </summary>
        [Key]
        public Int32 RESCUE_ID { get; set; }

        /// <summary>
        /// 对应手术状态代码表记录抢救取消时的手术状态。
        /// </summary>
        public Nullable<Int32> OPER_STATUS_CODE { get; set; }

        /// <summary>
        /// 抢救开始时间
        /// </summary>
        public Nullable<DateTime> START_DATE_TIME { get; set; }
        /// <summary>
        /// 抢救结束时间
        /// </summary>
        public Nullable<DateTime> END_DATE_TIME { get; set; }
        /// <summary>
        /// 抢救原因
        /// </summary>
        public string REASON { get; set; }

        /// <summary>
        /// 抢救措施
        /// </summary>
        public string MEASURES { get; set; }

        /// <summary>
        /// 抢救结果
        /// </summary>
        public string RESULT { get; set; }

        /// <summary>
        /// 参与抢救人员
        /// </summary>
        public string PARTICIPANTS { get; set; }

        /// <summary>
        /// 录入者
        /// </summary>
        public string ENTERED_BY { get; set; }
    }
}
