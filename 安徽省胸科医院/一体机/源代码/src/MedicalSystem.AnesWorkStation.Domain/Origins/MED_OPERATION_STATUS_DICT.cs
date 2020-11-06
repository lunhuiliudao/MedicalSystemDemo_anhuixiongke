namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 手术状态字典表
    /// </summary>
    [Table("MED_OPERATION_STATUS_DICT")]
    public partial class MED_OPERATION_STATUS_DICT : BaseModel
    {
        /// <summary>
        /// 主键 状态代码	
        /// </summary>
        [Key]
        public Int32 OPER_STATUS_CODE { get; set; }
        /// <summary>
        /// 状态名称	
        /// </summary>
        public string OPER_STATUS_NAME { get; set; }
        /// <summary>
        /// 状态分类	;1 排班前,2 术前准备,3 手术中,4 手术后,9 取消手术	
        /// </summary>
        public string STATUS_TYPE { get; set; }
        /// <summary>
        /// 	主要流程标志	;0 默认,1 主要流程	
        /// </summary>
        public Nullable<Int32> PRIMARY_IND { get; set; }
        /// <summary>
        /// 	排序号	
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
        /// <summary>
        /// 状态说明	
        /// </summary>
        public string OPER_STATUS_MEMO { get; set; }
        /// <summary>
        /// 是否启用	;0 不启用,1 启用.默认为1	
        /// </summary>
        public Nullable<Int32> IS_VALID { get; set; }
    }
}