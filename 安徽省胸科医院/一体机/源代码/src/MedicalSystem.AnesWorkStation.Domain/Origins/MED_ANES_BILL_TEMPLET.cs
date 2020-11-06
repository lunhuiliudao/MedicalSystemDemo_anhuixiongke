namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;

    /// <summary>
    /// 实体 麻醉收费单模板
    /// </summary>
    [Table("MED_ANES_BILL_TEMPLET")]
    public partial class MED_ANES_BILL_TEMPLET : BaseModel
    {
        /// <summary>
        /// 模板
        /// </summary>
        [Key]
        public string TEMPLET { get; set; }
        /// <summary>
        /// 模板分类
        /// </summary>
        [Key]
        public string TEMPLET_CLASS { get; set; }
        /// <summary>
        /// 麻醉方法
        /// </summary>
        [Key]
        public string ANESTHESIA_METHOD { get; set; }
        /// <summary>
        /// 项目序号
        /// </summary>
        [Key]
        public Nullable<Int32> ITEM_NO { get; set; }
        /// <summary>
        /// 项目类别
        /// </summary>
        public string ITEM_CLASS { get; set; }
        /// <summary>
        /// 项目代码
        /// </summary>
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 项目规格
        /// </summary>
        public string ITEM_SPEC { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Nullable<decimal> AMOUNT { get; set; }
    }
    public partial class MED_TEMPLET_BILL_MENU
    {
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public String ANESTHESIA_METHOD { get; set; }

        /// <summary>
        /// 模版名称
        /// </summary>
        public string TEMPLET_NAME { get; set; }
    }
}