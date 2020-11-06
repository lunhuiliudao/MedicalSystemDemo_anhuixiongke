namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 手术分值表
    /// </summary>
    [Table("MED_OPERSCORE_DICT")]
    public partial class MED_OPERSCORE_DICT : BaseModel
    {
                /// <summary>
        /// 主键 手术编码
        /// </summary>
        [Key]
        public string OPER_CODE { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPER_NAME { get; set; }
        /// <summary>
        /// 手术分值
        /// </summary>
        public Nullable<long> OPER_SCORE { get; set; }
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