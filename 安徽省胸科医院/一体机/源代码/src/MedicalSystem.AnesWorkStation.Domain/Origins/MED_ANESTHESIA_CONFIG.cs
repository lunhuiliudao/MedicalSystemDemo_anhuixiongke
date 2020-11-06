using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain.Origins
{
    /// <summary>
    /// 麻醉方法归类表
    /// </summary>
    [Table("MED_ANESTHESIA_CONFIG")]
    public partial class MED_ANESTHESIA_CONFIG : BaseModel
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string ITEM_TYPE { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public int ITEM_ID { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int ITEM_PARENTID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ITEM_VALUE { get; set; }

        [NotMapped]
        public string[] TEMP_ITEM_VALUE { get; set; }
    }
}
