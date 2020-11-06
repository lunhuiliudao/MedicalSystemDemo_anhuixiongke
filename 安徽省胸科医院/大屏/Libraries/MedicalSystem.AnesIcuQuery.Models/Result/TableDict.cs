using System.Collections.Generic;
using System.ComponentModel;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 获取当前所有Table的表名及列名
    /// </summary>
    public class TableDict
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字段属性
        /// </summary>
        public List<TableField> Fields { get; set; }
    }

    /// <summary>
    /// 表的字段信息
    /// </summary>
    public class TableField
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        [DefaultValue("String")]
        public string FieldType { get; set; }
    }

}
