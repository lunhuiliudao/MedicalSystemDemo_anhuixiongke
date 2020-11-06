namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using Dapper.Data;


    /// <summary>
    /// 实体 给药途径代码表
    /// </summary>
    [Table("MED_CHUFANG_RECORD")]
    public partial class MED_CHUFANG_RECORD : BaseModel
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
        /// 主键 处方单类型：精一=0、精二=1
        /// </summary>
        [Key]
        public Int32 CHUFANG_CLASS { get; set; }

        /// <summary>
        /// 主键 处方单编号
        /// </summary>
        [Key]
        public long CHUFANG_INDEX { get; set; }

        /// <summary>
        /// 收费类别：公费=0、自费=1、医保=2、其他=3
        /// </summary>
        public Nullable<Int32> FREE_ITEM_CLASS { get; set; }

        /// <summary>
        /// 处方开具时间
        /// </summary>
        public Nullable<DateTime> CHUFANG_DATE { get; set; }

        /// <summary>
        /// 医师
        /// </summary>
        public string DOCTOR { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public Nullable<decimal> MONEY { get; set; }

        /// <summary>
        /// 审核药师
        /// </summary>
        public string CHECK_DOCTOR { get; set; }

        /// <summary>
        /// 调配药师
        /// </summary>
        public string BLEND_DOCTOR { get; set; }

        /// <summary>
        /// 核对、发药药师
        /// </summary>
        public string CONFIRM_DOCTOR { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string EVENT_ITEM_NAME { get; set; }

        /// <summary>
        /// 药品规格
        /// </summary>
        public string EVENT_ITEM_SPEC { get; set; }

        /// <summary>
        /// 药品数量
        /// </summary>
        public Nullable<decimal> AMOUNT { get; set; }

        /// <summary>
        /// 药品数量单位
        /// </summary>
        public string AMOUNT_UNITS { get; set; }

        /// <summary>
        /// 药品剂量
        /// </summary>
        public Nullable<decimal> DOSAGE { get; set; }

        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DOSAGE_UNITS { get; set; }

        /// <summary>
        /// 药品用法
        /// </summary>
        public string EVENT_METHOD { get; set; }

        /// <summary>
        /// 药品废弃量
        /// </summary>
        public Nullable<decimal> DISUSE { get; set; }

        /// <summary>
        /// 药品废弃量单位
        /// </summary>
        public string DISUSE_UNITS { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string EVENT_ITEM_NAME1 { get; set; }

        /// <summary>
        /// 药品规格
        /// </summary>
        public string EVENT_ITEM_SPEC1 { get; set; }

        /// <summary>
        /// 药品数量
        /// </summary>
        public Nullable<decimal> AMOUNT1 { get; set; }

        /// <summary>
        /// 药品数量单位
        /// </summary>
        public string AMOUNT_UNITS1 { get; set; }

        /// <summary>
        /// 药品剂量
        /// </summary>
        public Nullable<decimal> DOSAGE1 { get; set; }

        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DOSAGE_UNITS1 { get; set; }

        /// <summary>
        /// 药品用法
        /// </summary>
        public string EVENT_METHOD1 { get; set; }

        /// <summary>
        /// 药品废弃量
        /// </summary>
        public Nullable<decimal> DISUSE1 { get; set; }

        /// <summary>
        /// 药品废弃量单位
        /// </summary>
        public string DISUSE_UNITS1 { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string EVENT_ITEM_NAME2 { get; set; }

        /// <summary>
        /// 药品规格
        /// </summary>
        public string EVENT_ITEM_SPEC2 { get; set; }

        /// <summary>
        /// 药品数量
        /// </summary>
        public Nullable<decimal> AMOUNT2 { get; set; }

        /// <summary>
        /// 药品数量单位
        /// </summary>
        public string AMOUNT_UNITS2 { get; set; }

        /// <summary>
        /// 药品剂量
        /// </summary>
        public Nullable<decimal> DOSAGE2 { get; set; }

        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DOSAGE_UNITS2 { get; set; }

        /// <summary>
        /// 药品用法
        /// </summary>
        public string EVENT_METHOD2 { get; set; }

        /// <summary>
        /// 药品废弃量
        /// </summary>
        public Nullable<decimal> DISUSE2 { get; set; }

        /// <summary>
        /// 药品废弃量单位
        /// </summary>
        public string DISUSE_UNITS2 { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string EVENT_ITEM_NAME3 { get; set; }

        /// <summary>
        /// 药品规格
        /// </summary>
        public string EVENT_ITEM_SPEC3 { get; set; }

        /// <summary>
        /// 药品数量
        /// </summary>
        public Nullable<decimal> AMOUNT3 { get; set; }

        /// <summary>
        /// 药品数量单位
        /// </summary>
        public string AMOUNT_UNITS3 { get; set; }

        /// <summary>
        /// 药品剂量
        /// </summary>
        public Nullable<decimal> DOSAGE3 { get; set; }

        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DOSAGE_UNITS3 { get; set; }

        /// <summary>
        /// 药品用法
        /// </summary>
        public string EVENT_METHOD3 { get; set; }

        /// <summary>
        /// 药品废弃量
        /// </summary>
        public Nullable<decimal> DISUSE3 { get; set; }

        /// <summary>
        /// 药品废弃量单位
        /// </summary>
        public string DISUSE_UNITS3 { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string EVENT_ITEM_NAME4 { get; set; }

        /// <summary>
        /// 药品规格
        /// </summary>
        public string EVENT_ITEM_SPEC4 { get; set; }

        /// <summary>
        /// 药品数量
        /// </summary>
        public Nullable<decimal> AMOUNT4 { get; set; }

        /// <summary>
        /// 药品数量单位
        /// </summary>
        public string AMOUNT_UNITS4 { get; set; }

        /// <summary>
        /// 药品剂量
        /// </summary>
        public Nullable<decimal> DOSAGE4 { get; set; }

        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DOSAGE_UNITS4 { get; set; }

        /// <summary>
        /// 药品用法
        /// </summary>
        public string EVENT_METHOD4 { get; set; }

        /// <summary>
        /// 药品废弃量
        /// </summary>
        public Nullable<decimal> DISUSE4 { get; set; }

        /// <summary>
        /// 药品废弃量单位
        /// </summary>
        public string DISUSE_UNITS4 { get; set; }
    }
}