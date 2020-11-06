namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 麻醉方法字典表
    /// </summary>
    [Table("MED_ANESTHESIA_DICT")]
    public partial class MED_ANESTHESIA_DICT : BaseModel
    {
        /// <summary>
        /// 主键 麻醉方法代码
        /// </summary>
        [Key]
        public string ANAESTHESIA_CODE { get; set; }
        /// <summary>
        /// 麻醉方法名称
        /// </summary>
        public string ANAESTHESIA_NAME { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// 麻醉方法类别
        /// </summary>
        public string ANAESTHESIA_TYPE { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string ANAESTHESIA_ABBR { get; set; }
        /// <summary>
        /// 标明本麻醉方法是否需要麻醉医生默认为需要
        /// </summary>
        public Nullable<Int32> NEED_ANES_DOCTOR { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
    }
}