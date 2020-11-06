using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    [Table("MED_TRANSPORT_MESSAGE")]
    public partial class MED_TRANSPORT_MESSAGE : BaseModel
    {
        // <summary>
        /// 主键 
        /// </summary>
        [Key]
        public Int32 MESSAGE_NO { get; set; }

        /// <summary>
        /// 主键：源手术间
        /// </summary>
        [Key]
        public string SOURCE_ROOM_NO { get; set; }

        /// <summary>
        /// 主键：目标手术间
        /// </summary>
        [Key]
        public string TARGET_ROOM_NO { get; set; }

        /// <summary>
        /// 消息发送的时间
        /// </summary>
        public Nullable<DateTime> TRANS_DATE { get; set; }

        /// <summary>
        /// 发送消息的人
        /// </summary>
        public string TRANS_ATOR { get; set; }

        /// <summary>
        /// 消息信息
        /// </summary>
        public string TRANS_MESSAGE { get; set; }

        /// <summary>
        /// 消息是否已经阅读过 0=未阅读，1=已阅读
        /// </summary>
        public int HAS_READ { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public int MESSAGE_CLASS { get; set; }
    }
}
