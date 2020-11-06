namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using Dapper.Data;
   

    /// <summary>
    /// 实体 给药途径代码表
    /// </summary>
    [Table("MED_ADMINISTRATION_DICT")]
    public partial class MED_ADMINISTRATION_DICT : BaseModel
    {
        /// <summary>
        /// 主键 途径编码
        /// </summary>
        [Key]
        public string ADMINISTRATION_CODE { get; set; }
        /// <summary>
        /// 入境名称
        /// </summary>
        public string ADMINISTRATION_NAME { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string ADMINISTRATION_ABBR { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
    }
}