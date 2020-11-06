using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Domain
{  /// <summary>
   /// 实体 拍照功能-图片信息表
   /// </summary>
    [Table("MED_CAMERA_PICINFO")]
    public partial class MED_CAMERA_PICINFO : BaseModel 
    {
        /// <summary>
        /// 主键 病人id;	非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数;	病人每次住院加1
        /// </summary>
        [Key]
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号;一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public int OPER_ID { get; set; }
        /// <summary>
        /// 主键 图片上传时间
        /// </summary>
        [Key]
        public DateTime UPDATE_TIME { get; set; }
        /// <summary>
        /// 图片类型
        /// </summary>
        public String PIC_TYPE { get; set; }
        /// <summary>
        /// 图片本地路径
        /// </summary>
        public String PIC_PATH { get; set; }
        /// <summary>
        /// 图片服务器路径
        /// </summary>
        public String PIC_SERVER_PATH { get; set; }
        /// <summary>
        /// 图片说明
        /// </summary>
        public String MEMO { get; set; }
    }
}
