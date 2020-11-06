namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 手术主表信息扩展
    /// </summary>
    [Table("MED_OPERATION_MASTER_EXT")]
    public partial class MED_OPERATION_MASTER_EXT : BaseModel
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
        /// 总出量
        /// </summary>
        public Nullable<decimal> OUT_FLUIDS_AMOUNT { get; set; }
        /// <summary>
        /// 总入量
        /// </summary>
        public Nullable<decimal> IN_FLUIDS_AMOUNT { get; set; }
        /// <summary>
        /// 液体总入量
        /// </summary>
        public Nullable<decimal> INFUSION_TRAN_VOL { get; set; }
        /// <summary>
        /// 出室余量
        /// </summary>
        public Nullable<decimal> OUT_REMAINDER_AMOUNT { get; set; }
        /// <summary>
        /// 失血量
        /// </summary>
        public Nullable<decimal> BLOOD_LOSSED { get; set; }
        /// <summary>
        /// 输血量
        /// </summary>
        public Nullable<decimal> BLOOD_TRANSFUSED { get; set; }
        /// <summary>
        /// 尿量
        /// </summary>
        public Nullable<decimal> URINE_AMOUNT { get; set; }
        /// <summary>
        /// 引流量
        /// </summary>
        public Nullable<decimal> DRAINAGE_AMOUNT { get; set; }
        /// <summary>
        /// 全血
        /// </summary>
        public Nullable<decimal> WHOLE_BLOOD { get; set; }
        /// <summary>
        /// 红细胞悬液
        /// </summary>
        public Nullable<decimal> PURE_RED_CELL { get; set; }
        /// <summary>
        /// 晶体
        /// </summary>
        public Nullable<decimal> CRYSTALLOIDS { get; set; }
        /// <summary>
        /// 胶体
        /// </summary>
        public Nullable<decimal> COLLOIDS { get; set; }
        /// <summary>
        /// 凝血因子
        /// </summary>
        public Nullable<decimal> BLOOD_COAGULATION_FACTORS { get; set; }
        /// <summary>
        /// 白蛋白
        /// </summary>
        public Nullable<decimal> ALBUMIN { get; set; }
        /// <summary>
        /// 血浆
        /// </summary>
        public Nullable<decimal> PLASMA { get; set; }
        /// <summary>
        /// 血浆替代品
        /// </summary>
        public Nullable<decimal> PLASMA_SUBSTITUTE { get; set; }
        /// <summary>
        /// 平衡液
        /// </summary>
        public Nullable<decimal> EQUILIBRIUM_LIQUID { get; set; }
        /// <summary>
        /// 生理盐水
        /// </summary>
        public Nullable<decimal> ORMAL_SALINE { get; set; }
        /// <summary>
        /// 万汶
        /// </summary>
        public Nullable<decimal> VOLUVEN { get; set; }
        /// <summary>
        /// 佳乐施
        /// </summary>
        public Nullable<decimal> GELOFUSINE { get; set; }
        /// <summary>
        /// 血小板
        /// </summary>
        public Nullable<decimal> PLATELET { get; set; }
        /// <summary>
        /// 冷沉淀
        /// </summary>
        public Nullable<decimal> COOL_THING { get; set; }
        /// <summary>
        /// 自体回输
        /// </summary>
        public Nullable<decimal> CRY_WATHER { get; set; }
        /// <summary>
        /// 红细胞
        /// </summary>
        public Nullable<decimal> RED_BLOOD { get; set; }
        /// <summary>
        /// 其它入量
        /// </summary>
        public Nullable<decimal> OTHER_IN_AMOUNT { get; set; }
        /// <summary>
        /// 其它出量
        /// </summary>
        public Nullable<decimal> OTHER_OUT_AMOUNT { get; set; }
    }
}