namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 每日的日程表
    /// </summary>
    [Table("MED_DAILY_SCHEDULE")]
    public partial class MED_DAILY_SCHEDULE : BaseModel
    {
        /// <summary>
        /// 主键 日期，不含时间
        /// </summary>
        [Key]
        public DateTime DAILY_DAY { get; set; }
        /// <summary>
        /// 主键 当前的用户ID
        /// </summary>
        [Key]
        public string DAILY_USER { get; set; }
        /// <summary>
        /// 主键 每日的日程编号
        /// </summary>
        [Key]
        public int DAILY_NO { get; set; }
        /// <summary>
        /// 日程类型
        /// </summary>
        public string SCHEDULE_TYPE { get; set; }
        /// <summary>
        /// 日程内容（500个汉字长度）
        /// </summary>
        public string CONTENT { get; set; }
        /// <summary>
        /// 状态：0,未完成;1,已完成.
        /// </summary>
        public Nullable<int> STATE { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<DateTime> CREATE_DATE { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public Nullable<DateTime> UPDATE_DATE { get; set; }
    }
}