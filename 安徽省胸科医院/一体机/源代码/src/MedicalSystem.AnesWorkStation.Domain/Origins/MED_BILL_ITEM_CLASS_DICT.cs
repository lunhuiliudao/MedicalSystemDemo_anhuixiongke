namespace MedicalSystem.AnesWorkStation.Domain
{
    using Dapper.Data;
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// 实体 收费项目分类代码表
    /// </summary>
    [Table("MED_BILL_ITEM_CLASS_DICT")]
    public partial class MED_BILL_ITEM_CLASS_DICT : BaseModel
    {
        /// <summary>
        /// 主键 项目分类
        /// </summary>
        [Key]
        public string BILL_CLASS_CODE { get; set; }
        /// <summary>
        /// 项目分类名称
        /// </summary>
        public string BILL_CLASS_NAME { get; set; }
        public string INPUT_CODE { get; set; }
        public string TYPE { get; set; }
    }
}