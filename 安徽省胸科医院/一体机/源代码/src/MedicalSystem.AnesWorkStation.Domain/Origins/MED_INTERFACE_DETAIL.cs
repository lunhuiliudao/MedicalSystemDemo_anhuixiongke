using Dapper.Data;
using System;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 第三方接口链接路径配置
    /// </summary>
    [Table("MED_INTERFACE_DETAIL")]
    public partial class MED_INTERFACE_DETAIL
    {
        /// <summary>
        /// 链接类型：1=网页，2=EXE
        /// </summary>
        [Key]
        public Int32 INT_TYPE { get; set; }

        /// <summary>
        /// 链接名称
        /// </summary>
        [Key]
        public string INT_NAME { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [Key]
        public string INT_ADDRESS { get; set; }

        /// <summary>
        /// 链接所需的参数
        /// </summary>
        public string INT_PARAMETERS { get; set; }

        /// <summary>
        /// 链接是否启用1=启用，0=不启用
        /// </summary>
        public Int32 INT_ENABLE { get; set; }
    }
}
