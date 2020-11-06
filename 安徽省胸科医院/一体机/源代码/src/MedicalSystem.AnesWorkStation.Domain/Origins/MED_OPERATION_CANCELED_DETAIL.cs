using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    [Table("MED_OPERATION_CANCELED_DETAIL")]
    public partial class MED_OPERATION_CANCELED_DETAIL : BaseModel
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
        /// 主键 手术取消标识	;手术取消标识(区分一个病人一次住院多次取消记录，从1开始顺序递增)
        /// </summary>
        [Key]
        public Int32 CANCEL_ID { get; set; }

        /// <summary>
        /// 取消分类（大类）;患者因素、医院因素、医护因素
        /// </summary>
        [Key]
        public string CANCEL_CLASS { get; set; }

        /// <summary>
        /// 取消分类（小类）;根据大类，从表MED_ANESTHESIA_INPUT_DICT提取可选结果
        /// </summary>
        [Key]
        public string CANCEL_TYPE { get; set; }
    }
}
