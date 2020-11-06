namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 科室代码表
    /// </summary>
    [Table("MED_DEPT_DICT")]
    public partial class MED_DEPT_DICT : BaseModel
    {
        /// <summary>
        /// 主键 科室代码
        /// </summary>
        [Key]
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 科室名称	;唯一索引
        /// </summary>
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// 部门别名
        /// </summary>
        public string DEPT_ALIAS { get; set; }
        /// <summary>
        /// 部门类别
        /// </summary>
        public string DEPT_TYPE { get; set; }
        /// <summary>
        /// 病区代码	;记录科室与病区的关系，有些医院时大病区小科室，有些医院是大科室小病区
        /// </summary>
        public string WARD_CODE { get; set; }
        /// <summary>
        /// 排序号	
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
    }
}