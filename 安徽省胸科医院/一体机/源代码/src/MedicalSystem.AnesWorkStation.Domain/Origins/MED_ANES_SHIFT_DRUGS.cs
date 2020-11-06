using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 麻醉科交班_毒麻药品
    /// </summary>
    [Table("MED_ANES_SHIFT_DRUGS")]
    public partial class MED_ANES_SHIFT_DRUGS
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
        /// 药品序号: 
        /// </summary>
        [Key]
        public int? DRUGS_NO { get; set; }

        /// <summary>
        /// 药品名称: 
        /// </summary>
        public string DRUGS_NAME { get; set; }

        /// <summary>
        /// 总数量:  
        /// </summary>
        public int? AMOUNT { get; set; }

        /// <summary>
        /// 未用数量: 
        /// </summary>
        public int? AMOUNT_SURPLUS { get; set; }

        /// <summary>
        /// 使用数量:  
        /// </summary>
        public int? AMOUNT_USE { get; set; }

        /// <summary>
        /// 备注: 
        /// </summary>
        public string MEMO { get; set; }
    }
}
