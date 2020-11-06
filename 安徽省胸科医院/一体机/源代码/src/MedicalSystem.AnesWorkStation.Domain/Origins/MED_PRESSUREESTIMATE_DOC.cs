namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;
    using System.ComponentModel;

    /// <summary>
    /// 实体 患者压疮评估文书
    /// </summary>
    [Table("MED_PRESSUREESTIMATE_DOC")]
    public partial class MED_PRESSUREESTIMATE_DOC : BaseModel
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
        /// 年龄分值
        /// </summary>
        public Nullable<Int32> AGE_SCORE { get; set; }

        /// <summary>
        /// 体重分值
        /// </summary>
        public Nullable<Int32> WEIGHT_SCORE { get; set; }

        /// <summary>
        /// 受力点皮肤分值
        /// </summary>
        public Nullable<Int32> SLD_SCORE { get; set; }

        /// <summary>
        /// 手术体位分值
        /// </summary>
        public Nullable<Int32> POSITION_SCORE { get; set; }

        /// <summary>
        /// 预计术中施加的外力分值
        /// </summary>
        public Nullable<Int32> SJWL_SCORE { get; set; }

        /// <summary>
        /// 预计手术时间分值
        /// </summary>
        public Nullable<Int32> SSSJ_SCORE { get; set; }

        /// <summary>
        /// 预计手术出血分值
        /// </summary>
        public Nullable<Int32> SSCX_SCORE { get; set; }

        /// <summary>
        /// 其他因素分值
        /// </summary>
        public Nullable<Int32> OTHER_SCORE { get; set; }

        /// <summary>
        /// 合计分值
        /// </summary>
        public Nullable<Int32> AMOUNT_SCORE { get; set; }

        /// <summary>
        /// 责任护士
        /// </summary>
        public string NURSE { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public Nullable<DateTime> DOC_DATE { get; set; }

        /// <summary>
        /// 床单平整无褶皱
        /// </summary>
        public string POWER_CD { get; set; }

        /// <summary>
        /// 体位垫与皮肤之间平顺、无皱折、无皮肤挤压
        /// </summary>
        public string POWER_TWD { get; set; }

        /// <summary>
        /// 控制术中摇床的次数和角度
        /// </summary>
        public string POWER_YC { get; set; }

        /// <summary>
        /// 约束带柔软、平滑，松紧适宜
        /// </summary>
        public string POWER_YSD { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public string POWER_OTHER { get; set; }
        /// <summary>
        /// 其他描述
        /// </summary>
        public string POWER_OTHER_DESC { get; set; }

        /// <summary>
        /// 吸收帖贴皮肤
        /// </summary>
        public string REDPRE_ZT { get; set; }

        /// <summary>
        /// 体位垫
        /// </summary>
        public string REDPRE_TWD { get; set; }

        /// <summary>
        /// 在条件允许的情况下，隔1h轻抬受压部位，缓解局部压力
        /// </summary>
        public string REDPRE_HJ { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public string REDPRE_OTHER { get; set; }

        /// <summary>
        /// 其他描述
        /// </summary>
        public string REDPRE_OTHER_DESC { get; set; }

        /// <summary>
        /// 保暖：暖风机 盖被 液体恒温 输液铺单前、手术缝皮后将室温调高
        /// </summary>
        public string SKIN_BN { get; set; }

        /// <summary>
        /// 防止消毒液浸湿消毒区以外皮肤
        /// </summary>
        public string SKIN_XD { get; set; }

        /// <summary>
        /// 保持手术铺巾干燥、平整
        /// </summary>
        public string SKIN_PJGZ { get; set; }

        /// <summary>
        /// 保护眼角膜
        /// </summary>
        public string SKIN_YJM { get; set; }

        /// <summary>
        /// 眼眶、耳廊不受压
        /// </summary>
        public string SKIN_YKEL { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public string SKIN_OTHER { get; set; }

        /// <summary>
        /// 其他描述
        /// </summary>
        public string SKIN_OTHER_DESC { get; set; }

        /// <summary>
        /// 安全固定
        /// </summary>
        public string POS_SAVE { get; set; }

        /// <summary>
        /// 术中摇床后避免身体移位，变换体位后及时检查
        /// </summary>
        public string POS_YC { get; set; }

        /// <summary>
        /// 保持卧位稳定、肢体舒展，衔接部位凹陷处用软垫支撑
        /// </summary>
        public string POS_WW { get; set; }

        /// <summary>
        /// 肢体功能位
        /// </summary>
        public string POS_ZT { get; set; }

        /// <summary>
        /// 肢体无接触金属
        /// </summary>
        public string POS_ZTWJS { get; set; }

        /// <summary>
        /// 各管道电极线无受压
        /// </summary>
        public string POS_GD { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public string POS_OTHER { get; set; }

        /// <summary>
        /// 其他描述
        /// </summary>
        public string POS_OTHER_DESC { get; set; }

        /// <summary>
        /// 完好
        /// </summary>
        public string AFTER_SKIN_GOOD { get; set; }

        /// <summary>
        /// 有压疮
        /// </summary>
        public string AFTER_SKIN_YC { get; set; }

        /// <summary>
        /// 一期
        /// </summary>
        public string AFTER_SKIN_YC_ONE { get; set; }

        /// <summary>
        /// 二期
        /// </summary>
        public string AFTER_SKIN_YC_TWO { get; set; }

        /// <summary>
        /// 三期
        /// </summary>
        public string AFTER_SKIN_YC_THREE { get; set; }

        /// <summary>
        /// 四期
        /// </summary>
        public string AFTER_SKIN_YC_FOUR { get; set; }

        /// <summary>
        /// 不可分期
        /// </summary>
        public string AFTER_SKIN_YC_NO { get; set; }

        /// <summary>
        /// 深部组织损伤
        /// </summary>
        public string AFTER_SKIN_YC_SBZZ { get; set; }

        /// <summary>
        /// 术后交接
        /// </summary>
        public string AFTER_SHIFT { get; set; }

        /// <summary>
        /// 术后交接原因
        /// </summary>
        public string AFTER_SHIFT_CAUSE { get; set; }

        /// <summary>
        /// 术后交接整改措施
        /// </summary>
        public string AFTER_SHIFT_RESOLVE { get; set; }

        public string RESERVED01 { get; set; }
        public string RESERVED02 { get; set; }
        public string RESERVED03 { get; set; }
        public string RESERVED04 { get; set; }
        public string RESERVED05 { get; set; }
        public string RESERVED06 { get; set; }
        public string RESERVED07 { get; set; }
        public string RESERVED08 { get; set; }
        public string RESERVED09 { get; set; }
        public string RESERVED10 { get; set; }
    }
}