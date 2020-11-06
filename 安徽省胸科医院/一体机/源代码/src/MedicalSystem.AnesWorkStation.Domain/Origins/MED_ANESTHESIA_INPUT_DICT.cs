namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 麻醉通用项目字典表;此表保存麻醉产品中输入项目的字典，这些输入项目直接保存次表的项目名称。
    /// </summary>
    [Table("MED_ANESTHESIA_INPUT_DICT")]
    public partial class MED_ANESTHESIA_INPUT_DICT : BaseModel
    {
        /// <summary>
        /// 主键 输入项目
        /// </summary>
        [Key]
        public string ITEM_CLASS { get; set; }
        /// <summary>
        /// 主键 项目名称
        /// </summary>
        [Key]
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 项目代码
        /// </summary>
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
    }
}