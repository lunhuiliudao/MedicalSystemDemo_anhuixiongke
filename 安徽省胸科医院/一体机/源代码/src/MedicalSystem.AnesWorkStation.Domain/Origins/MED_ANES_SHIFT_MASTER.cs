using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 麻醉交班表
    /// </summary>
    [Table("MED_ANES_SHIFT_MASTER")]
    public partial class MED_ANES_SHIFT_MASTER
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
        public int SHIFT_TYUPE { get; set; }

        /// <summary>
        /// 值班医师: 
        /// </summary>
        public string ANES_DOCTOR { get; set; }

        /// <summary>
        /// 值班医师CA签名: 
        /// </summary>
        [NotMapped]
        public string ANES_DOCTOR_PIC_STR { get; set; }

        /// <summary>
        /// 值班医师CA签名: 
        /// </summary>
        public byte[] ANES_DOCTOR_PIC { get; set; }

        /// <summary>
        /// 交班时间: 记录精确到时分
        /// </summary>
        public DateTime? SHIFT_TIME { get; set; }

        /// <summary>
        /// 二线值班医师: 
        /// </summary>
        public string ANES_DOCTOR1 { get; set; }

        /// <summary>
        /// 二线值班医师CA签名: 
        /// </summary>
        public byte[] ANES_DOCTOR1_PIC { get; set; }

        /// <summary>
        /// 二线值班医师CA签名:
        /// </summary>
        [NotMapped]
        public string ANES_DOCTOR1_PIC_STR { get; set; }

        /// <summary>
        /// 交班时间: 记录精确到时分
        /// </summary>
        public DateTime? SHIFT_TIME1 { get; set; }

        /// <summary>
        /// 接班医师: 
        /// </summary>
        public string SHIFT_DOCTOR { get; set; }

        /// <summary>
        /// 接班医师CA签名: 
        /// </summary>
        public byte[] SHIFT_DOCTOR_PIC { get; set; }

        /// <summary>
        /// 接班医师CA签名:
        /// </summary>
        [NotMapped]
        public string SHIFT_DOCTOR_PIC_STR { get; set; }

        /// <summary>
        /// 接班时间: 记录精确到时分
        /// </summary>
        public DateTime? TAKE_TIME { get; set; }

        /// <summary>
        /// 二线接班医师: 
        /// </summary>
        public string SHIFT_DOCTOR1 { get; set; }

        /// <summary>
        /// 二线接班医师CA签名: 
        /// </summary>
        public byte[] SHIFT_DOCTOR1_PIC { get; set; }

        /// <summary>
        /// 二线接班医师CA签名:
        /// </summary>
        [NotMapped]
        public string SHIFT_DOCTOR1_PIC_STR { get; set; }

        /// <summary>
        /// 接班时间: 记录精确到时分
        /// </summary>
        public DateTime? TAKE_TIME1 { get; set; }

        /// <summary>
        /// 可视喉镜: 1 可视喉镜，0/null 不显示
        /// </summary>
        public string GLIDESCOPE { get; set; }

        /// <summary>
        /// 普通喉镜: 大、中、小
        /// </summary>
        public string LARYNGOSCOPE { get; set; }

        /// <summary>
        /// 心电图: 1 心电图 ， 0/null  不显示
        /// </summary>
        public string ECG_EXAM { get; set; }

        /// <summary>
        /// 支气管镜: 1 支气管镜 ， 0/null  不显示
        /// </summary>
        public string BRONCHOSCOPE { get; set; }

        /// <summary>
        /// 氧饱和度检测仪: 1氧饱和度检测仪， 0/null  不显示
        /// </summary>
        public string SPO2_DETECTOR { get; set; }

        /// <summary>
        /// 听诊器: 1听诊器， 0/null  不显示
        /// </summary>
        public string STETHOSCOPE { get; set; }

        /// <summary>
        /// 简易呼吸器: 1简易呼吸机， 0/null  不显示
        /// </summary>
        public string BREATH_MACHINE { get; set; }

        /// <summary>
        /// 便携式呼吸机: 1便携呼吸机， 0/null  不显示
        /// </summary>
        public string BREATH_MACHINE_MINI { get; set; }

        /// <summary>
        /// 氧气瓶: 1氧气瓶， 0/null  不显示
        /// </summary>
        public string OXYGEN_BOTTLE { get; set; }

        /// <summary>
        /// 备注: 
        /// </summary>
        public string MEMO { get; set; }
    }
}
