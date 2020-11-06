namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 单位代码表
    /// </summary>
    [Table("MED_UNIT_DICT")]
    public partial class MED_UNIT_DICT : BaseModel
    {
        /// <summary>
        /// 主键 单位代码
        /// </summary>
        [Key]
        public string UNIT_CODE { get; set; }
        /// <summary>
        /// 单位名称;唯一索引
        /// </summary>
        public string UNIT_NAME { get; set; }
        /// <summary>
        /// 单位类型;1 浓度单位；2 速度单位，3 剂量单位
        /// </summary>
        public Int32 UNIT_TYPE { get; set; }
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