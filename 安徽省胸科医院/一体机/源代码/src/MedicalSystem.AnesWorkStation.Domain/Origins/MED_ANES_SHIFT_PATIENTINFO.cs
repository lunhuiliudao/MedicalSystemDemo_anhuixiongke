using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 麻醉科交班_急救插管患者
    /// </summary>
    [Table("MED_ANES_SHIFT_PATIENTINFO")]
    public partial class MED_ANES_SHIFT_PATIENTINFO
    {
        /// <summary>
        ///  交班日期: 只记录日期 
        /// </summary>
        [Key]
        public DateTime? SHIFT_DATE { get; set; }

        /// <summary>
        /// 交班类型: 1 白交夜、0 夜交白
        /// </summary>
        [Key]
        public int? SHIFT_TYUPE { get; set; }

        /// <summary>
        /// 患者序号:  
        /// </summary>
        [Key]
        public int PATIENT_NO { get; set; }

        /// <summary>
        /// 住院号:  
        /// </summary>
        public string INP_NO { get; set; }

        /// <summary>
        /// 姓名:   
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 病区: 取科室代码表 
        /// </summary>
        public string DEPT_CODE { get; set; }

        /// <summary>
        /// 床号:   
        /// </summary>
        public string BED_NO { get; set; }

        /// <summary>
        /// 抢救标识: 1抢救， 0/null  不显示
        /// </summary>
        public string RESCUE { get; set; }

        /// <summary>
        /// 呼吸支持标识: 1呼吸支持， 0/null  不显示
        /// </summary>
        public string BREATH { get; set; }

        /// <summary>
        /// 备注: 
        /// </summary>
        public string MEMO { get; set; }
    }
}
