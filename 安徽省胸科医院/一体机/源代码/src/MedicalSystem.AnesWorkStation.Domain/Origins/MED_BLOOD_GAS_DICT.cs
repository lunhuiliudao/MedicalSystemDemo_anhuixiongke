namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 血气分析字典表
    /// </summary>
    [Table("MED_BLOOD_GAS_DICT")]
    public partial class MED_BLOOD_GAS_DICT : BaseModel
    {
        /// <summary>
        /// 主键 项目代码;实施现场不得修改，由研发人员统一维护。该字段对应MED_BLOOD_GAS_DETAIL_CODE字段
        /// </summary>
        [Key]
        public string BLG_CODE { get; set; }
        /// <summary>
        /// 项目名称;前台主程序显示血气结果的明细项目名称，每个现场可以根据医院需要修改
        /// </summary>
        public string BLG_NAME { get; set; }
        /// <summary>
        /// 主键 显示ID值;该项目在报表中县市先后序号，每个现场可以根据医院需要修改
        /// </summary>
        [Key]
        public Int32 BLG_SHOWID { get; set; }
        /// <summary>
        /// 项目单位;界面显示该化验项目的单位值
        /// </summary>
        public string BLG_UNIT { get; set; }
        /// <summary>
        /// 取值范围;界面显示该化验项目的参考值
        /// </summary>
        public string BLG_REFER_VALUE { get; set; }
        /// <summary>
        /// 主键 状态;0 表示主程序报表中不显示，即采集程序也不采集该化验项目。1，表示允许采集程序采集该化验项目
        /// </summary>
        [Key]
        public string BLG_STATUS { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string BLG_INPUT_CODE { get; set; }
        /// <summary>
        /// 设备项目ID;(实施现场不得修改，由开发人员统一维护)血气项目对应项目内部码，每个项目用|号隔开，采集程序根据这个字段将设备数据包中血气项目与数据库中该化验项目对应。
        /// </summary>
        public string BLG_ATTR_CODE { get; set; }
        /// <summary>
        /// 项目ID;实施现场不得修改，由开发人员统一维护
        /// </summary>
        public Nullable<Int32> BLG_ITEM_ID { get; set; }
    }
}