using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 文书上传的显示记录信息
    /// </summary>
    [Table("MED_POSTPDF_SHOW")]
    public partial class MED_POSTPDF_SHOW : BaseModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public Int32 ROWNUM { get; set; }

        /// <summary>
        /// 病人ID	;非空，唯一确定手术病人
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次数	;	住院病人每次住院加1
        /// </summary>
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 手术次数
        /// </summary>
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 主麻医生
        /// </summary>
        public string ANES_DOCTOR { get; set; }

        /// <summary>
        /// 入室时间
        /// </summary>
        public Nullable<DateTime> IN_DATE_TIME { get; set; }
        /// <summary>
        /// 手术状态
        /// </summary>
        public Nullable<Int32> OPER_STATUS_CODE { get; set; }

        /// <summary>
        /// 已经上传的文书列表
        /// </summary>
        public string EXIST_DOCNAMES { get; set; }

        /// <summary>
        /// 未上传的文书列表
        /// </summary>
        public string NO_EXIST_DOCNAMES { get; set; }
    }
}
