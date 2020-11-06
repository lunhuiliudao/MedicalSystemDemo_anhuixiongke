namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;



    /// <summary>
    /// 实体 体征记录扩展表
    /// </summary>
    [Table("MED_PAT_MONITOR_DATA_EXT")]
    public partial class MED_PAT_MONITOR_DATA_EXT : BaseModel
    {
        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 时间点
        /// </summary>
        [Key]
        public DateTime TIME_POINT { get; set; }
        /// <summary>
        /// 主键 项目编号	;对应体征项目代码表
        /// </summary>
        [Key]
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 采集项目名称	;冗余字段，为查询方便
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 采集项目值
        /// </summary>
        public string ITEM_VALUE { get; set; }
        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public DateTime LAST_MODIFY_DATE { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OPERATOR { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public string RESERVED4 { get; set; }
        /// <summary>
        /// 数据类型;	0-手术、1-术后复苏、4-术前诱导；8=产房
        /// </summary>
        public string DATA_TYPE { get; set; }
        /// <summary>
        /// 删除标记;0 删除数据  1 正常数据，默认为1
        /// </summary>
        public Nullable<Int32> DATA_MARK { get; set; }
    }
}