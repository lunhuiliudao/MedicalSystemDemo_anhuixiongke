using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    [Table("MED_CHANGE_ROOM_NO")]
    public partial class MED_CHANGE_ROOM_NO : BaseModel
    {
        /// <summary>
        /// 主键 
        /// </summary>
        [Key]
        public Int32 CHANGE_NO { get; set; }

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
        /// 更改前的手术间
        /// </summary>
        public string OLD_ROOM_NO { get; set; }

        /// <summary>
        /// 更改后的手术间
        /// </summary>
        public string NEW_ROOM_NO { get; set; }

        /// <summary>
        /// 更改时间
        /// </summary>
        public Nullable<DateTime> CHANGE_DATE { get; set; }

        /// <summary>
        /// 更改者
        /// </summary>
        public string CHANGE_ATOR { get; set; }

        /// <summary>
        /// 更换原因
        /// </summary>
        public string CHANGE_REASON { get; set; }
    }
}
