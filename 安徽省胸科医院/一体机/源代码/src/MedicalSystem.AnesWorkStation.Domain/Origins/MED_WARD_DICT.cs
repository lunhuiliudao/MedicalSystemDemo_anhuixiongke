namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 病区代码表
    /// </summary>
    [Table("MED_WARD_DICT")]
    public partial class MED_WARD_DICT : BaseModel
    {
        /// <summary>
        /// 主键 病区代码
        /// </summary>
        [Key]
        public string WARD_CODE { get; set; }
        /// <summary>
        /// 病区名称
        /// </summary>
        public string WARD_NAME { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// 科室代码	;记录科室与病区的关系，有些医院时大病区小科室，有些医院是大科室小病区
        /// </summary>
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 	排序号
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
    }
}