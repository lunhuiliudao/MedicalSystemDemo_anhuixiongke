namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// 交班会议记录表
    /// </summary>
    [Table("MED_SHIFT_OPERATION_MASTER")]
    public class MED_SHIFT_OPERATION_MASTER
    {
        /// <summary>
        /// 主键 YYYY-MM-DD
        /// </summary>
        [Key]
        public string MEETING_NO { get; set; }
        /// <summary>
        /// 主键 交班标识（1麻醉、2护理）
        /// </summary>
        [Key]
        public Int32 SHIFT_TYPE { get; set; }
        /// <summary>
        /// 主键 交班区分（1术前、2术后）
        /// </summary>
        [Key]
        public Int32 SHIFT_DIVISION { get; set; }
        /// <summary>
        /// 讨论人
        /// </summary>
        public string PARTICIPANT { get; set; }
        /// <summary>
        /// 交班内容
        /// </summary>
        public string DISCUSSION_CONTENT { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string OPERATOR { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public Nullable<DateTime> INSERT_DATETIME { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public Nullable<DateTime> UPDATE_DATETIME { get; set; } 

    }
}
