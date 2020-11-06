namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 麻醉事件使用频率排序表
    /// </summary>
    [Table("MED_EVENT_SORT")]
    public partial class MED_EVENT_SORT : BaseModel
    {
        /// <summary>
        /// 主键 事件类别	;对应事件类型代码表MED_EVENT_ITEM_CLASS_DICT	
        /// </summary>
        [Key]
        public string EVENT_CLASS_CODE { get; set; }
        /// <summary>
        /// 主键 代码
        /// </summary>
        [Key]
        public string EVENT_ITEM_CODE { get; set; }
        /// <summary>
        /// 名称	;唯一索引
        /// </summary>
        public string EVENT_ITEM_NAME { get; set; }
        /// <summary>
        /// 主键 用户ID
        /// </summary>
        [Key]
        public string USER_ID { get; set; }
        /// <summary>
        /// 排序号;定时更细
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
    }
}