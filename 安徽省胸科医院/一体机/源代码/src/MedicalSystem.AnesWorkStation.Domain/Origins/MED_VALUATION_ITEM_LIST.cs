namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;

    /// <summary>
    /// 实体 计价单项目表
    /// </summary>
    [Table("MED_VALUATION_ITEM_LIST")]
    public partial class MED_VALUATION_ITEM_LIST : BaseModel
    {
        /// <summary>
        /// 项目类别
        /// </summary>
        public string ITEM_CLASS { get; set; }
        /// <summary>
        /// 主键 项目编码
        /// </summary>
        [Key]
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 项目序号
        /// </summary>
        public Nullable<Int32> ITEM_NO { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string ITEM_SPEC { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
    }
}