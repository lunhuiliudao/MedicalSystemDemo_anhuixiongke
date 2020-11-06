namespace MedicalSystem.AnesWorkStation.Domain
{
    using Dapper.Data;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 实体 麻醉收费单模板
    /// </summary>
    [Table("MED_EVENT_VS_VALUATION")]
    public partial class MED_EVENT_VS_VALUATION : BaseModel
    {
        /// <summary>
        /// 主键 事件类别
        /// </summary>
        [Key]
        public string EVENT_CLASS_CODE { get; set; }
        /// <summary>
        /// 主键 事件代码
        /// </summary>
        [Key]
        public string EVENT_ITEM_CODE { get; set; }
        /// <summary>
        /// 主键 对照序号
        /// </summary>
        [Key]
        public Int32 VS_NO { get; set; }
        /// <summary>
        /// 主键 对计价单项目表项目分类
        /// </summary>
        [Key]
        public string VT_ITEM_CLASS { get; set; }
        /// <summary>
        /// 主键 对计价单项目表项目代码
        /// </summary>
        [Key]
        public string VT_ITEM_CODE { get; set; }
        /// <summary>
        /// 对计价单项目表项目数量
        /// </summary>
        public Nullable<Int32> AMOUNT { get; set; }
        /// <summary>
        /// 对计价单项目表项目单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 状态;默认0 ;0 初始;1 麻醉医生提交;2 收费已审核
        /// </summary>
        public string NOTE { get; set; }

    }
}