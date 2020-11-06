namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;



    /// <summary>
    /// 实体 检测项目字典表
    /// </summary>
    [Table("MED_MONITOR_FUNCTION_CODE")]
    public partial class MED_MONITOR_FUNCTION_CODE : BaseModel
    {
        /// <summary>
        /// 主键 序号
        /// </summary>
        [Key]
        public Int32 ITEM_ID { get; set; }
        /// <summary>
        /// 主键 生命体征名称	;主程序显示的项目名称
        /// </summary>
        [Key]
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 生命体征代码	;序号在5000 以下为采集程序内部预留序号段，由研发人员统一维护，主程序自定义序号须从5000 序号以上开始
        /// </summary>
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 单位	;如果该字段配置为空，则认为该监测项目无单位 
        /// </summary>
        public string ITEM_UNIT { get; set; }
        /// <summary>
        /// 显示颜色	
        /// </summary>
        public string DIS_COLOR { get; set; }
        /// <summary>
        /// 参数类别
        /// </summary>
        public string PARM_CLASS { get; set; }
        /// <summary>
        /// 显示图标
        /// </summary>
        public string DRAW_ICON { get; set; }
        /// <summary>
        /// 使用标志
        /// </summary>
        public string USE_FLAG { get; set; }
        /// <summary>
        /// 优先标志
        /// </summary>
        public Nullable<Int32> PRIORITY_INDI { get; set; }
        /// <summary>
        /// 备注	
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 输入码	
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// ICU中名称	;用于自定义采集程序保存到med_vital_signs_rec_temp 表的参数项目名称
        /// </summary>
        public string NAME_IN_ICU { get; set; }
        /// <summary>
        /// 护理单元
        /// </summary>
        public string WARD_CODE { get; set; }
        /// <summary>
        /// 护理单元类型	;=*，在ICU 系统中表示全院通用
        /// </summary>
        public Nullable<Int32> WARD_TYPE { get; set; }
        /// <summary>
        /// 生命体征简称
        /// </summary>
        public string ITEM_NAME_ALIAS { get; set; }
        /// <summary>
        /// 值类型	;0-数值型、1-字符型 
        /// </summary>
        public Nullable<Int32> VALUE_TYPE { get; set; }
        /// <summary>
        /// 检测方法	;0-手工录入、1-自动采集 
        /// </summary>
        public Nullable<Int32> EXAM_METHOD { get; set; }
        /// <summary>
        /// 出入指标	;0-输入、1-排出、2-观察
        /// </summary>
        public Nullable<Int32> IN_OR_OUT { get; set; }
        /// <summary>
        /// 生命体征类型	;0-系统定义，1-护理记录单，2-用户定义 
        /// </summary>
        public Nullable<Int32> ITEM_TYPE { get; set; }
        /// <summary>
        /// 单独计算总量标志	;1-单独计算（只对出量有效）
        /// </summary>
        public Nullable<Int32> CALC_SUM { get; set; }
        /// <summary>
        /// 打印顺序	;按基础护理记录单的打印顺序排序，最大序号为21。不需要打印的项目，填写0 
        /// </summary>
        public Nullable<Int32> PRINT_ITEM_NO { get; set; }
        /// <summary>
        /// 显示情况	;0 不显示； 1 显示曲线； 2 显示数值
        /// </summary>
        public Nullable<Int32> DRAW_STYLE { get; set; }
        public Nullable<Int32> DRAW_ISVALID { get; set; }
        public string SHOW_SUB_CODE { get; set; }
        public string DATA_TABLE_CODE { get; set; }
    }
}