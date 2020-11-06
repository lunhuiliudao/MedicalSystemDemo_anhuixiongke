namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 给药方式字典
    /// </summary>
    [Table("MED_METHOD_DICT")]
    public partial class MED_METHOD_DICT : BaseModel
    {
        /// <summary>
        /// 主键 单位代码
        /// </summary>
        [Key]
        public string METHOD_CODE { get; set; }
        /// <summary>
        /// 单位名称;唯一索引
        /// </summary>
        public string METHOD_NAME { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// 排序号;排序使用，默认为0
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
    }
}