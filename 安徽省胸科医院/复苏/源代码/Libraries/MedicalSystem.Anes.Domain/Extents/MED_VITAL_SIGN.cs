using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.Anes.Domain
{
    /// <summary>
    /// 体征合并后的表
    /// </summary>
    public class MED_VITAL_SIGN
    {
        /// <summary>
        /// 主键 时间点
        /// </summary>
        [Key]
        public DateTime TIME_POINT { get; set; }
        /// <summary>
        /// 主键 项目编号	;对应体征项目代码表
        /// </summary>
        [Key]
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 采集项目名称	;冗余字段，为查询方便
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 采集项目值
        /// </summary>
        public string ITEM_VALUE { get; set; }
        /// <summary>
        /// 修改标志
        /// </summary>
        public string Flag { get; set; }
    }
}
