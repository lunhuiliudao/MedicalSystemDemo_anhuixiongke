namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;



    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_ANESTHESIA_INPUT_DATA_OUT")]
    public partial class MED_ANESTHESIA_INPUT_DATA_OUT : BaseModel
    {
        [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 取消类型；1-麻醉开始后手术开始前手术
        /// </summary>
        public string CANCELED_TYPE { get; set; }
        /// <summary>
        /// 入PACU第一次测量体温低于35.5℃；1-是；0-否
        /// </summary>
        public Nullable<Int32> PACU_TEMPERATURE { get; set; }
        /// <summary>
        /// 转入ICU患者；1-是；0-否
        /// </summary>
        public Nullable<Int32> IN_ICU { get; set; }
        /// <summary>
        /// 患者术后气管插管拔除后6小时内，非计划再次行气管插管；1-是；0-否
        /// </summary>
        public Nullable<Int32> TRACHEA_6H { get; set; }
        /// <summary>
        /// 术后气管插管拔除患者；1-是；0-否
        /// </summary>
        public Nullable<Int32> TRACHEA_REMOVE { get; set; }
        /// <summary>
        /// 麻醉开始后24小时内死亡（死亡原因）；1-是；0-否
        /// </summary>
        public Nullable<Int32> ANES_START_24H_DEATH { get; set; }
        /// <summary>
        /// 麻醉开始后24小时内心跳骤停患者（死亡原因）；1-是；0-否
        /// </summary>
        public Nullable<Int32> ANES_START_24H_STOP { get; set; }
        /// <summary>
        /// 麻醉期间严重过敏反应发生；1-是；0-否
        /// </summary>
        public Nullable<Int32> ANES_ANAPHYLAXIS { get; set; }
        /// <summary>
        /// 椎管内麻醉后严重神经并发症发生；1-是；0-否
        /// </summary>
        public Nullable<Int32> SPINAL_ANES_COMP { get; set; }
        /// <summary>
        /// 中心静脉穿刺严重并发症发生；1-是；0-否
        /// </summary>
        public Nullable<Int32> CENTRAL_VENOUS { get; set; }
        /// <summary>
        /// 椎管内麻醉；1-是；0-否
        /// </summary>
        public Nullable<Int32> SPINAL_ANES { get; set; }
        /// <summary>
        /// 全麻气管插管拔管后声音嘶哑发生；1-是；0-否
        /// </summary>
        public Nullable<Int32> TRACHEA_HOARSE { get; set; }
        /// <summary>
        /// 麻醉后新发昏迷发生；1-是；0-否
        /// </summary>
        public Nullable<Int32> AFTER_ANES_COMA { get; set; }
        /// <summary>
        /// 全麻气管插管；1-是；0-否
        /// </summary>
        public Nullable<Int32> GEN_ANES_TRACHEA { get; set; }
        /// <summary>
        /// 入PACU情况
        /// </summary>
        public string PACU_SITUATION { get; set; }
        /// <summary>
        /// 出PACU STEWARD 评分
        /// </summary>
        public Nullable<Int32> PACU_STEWARD { get; set; }
        /// <summary>
        /// PACU医师
        /// </summary>
        public string PACU_DOCTOR { get; set; }
        /// <summary>
        /// PACU护士
        /// </summary>
        public string PACU_NURSE { get; set; }
        /// <summary>
        /// 镇痛泵
        /// </summary>
        public string ANALGESIA_PUMP { get; set; }
        /// <summary>
        /// 镇痛方式
        /// </summary>
        public string ANALGESIA_METHOD { get; set; }
        /// <summary>
        /// 镇痛药物
        /// </summary>
        public string ANALGESIA_DRUGS { get; set; }
        /// <summary>
        /// 镇痛效果
        /// </summary>
        public string ANALGESIA_EFFECT { get; set; }
        /// <summary>
        /// 体外循环；1-是；0-否
        /// </summary>
        public Nullable<Int32> EXTRA_CIRCULATION { get; set; }
        /// <summary>
        /// 镇痛治疗；1-是；0-否
        /// </summary>
        public Nullable<Int32> ANALGESIA_THERAPY { get; set; }
        /// <summary>
        /// 术后镇痛；1-是；0-否
        /// </summary>
        public Nullable<Int32> AFTER_ANALGESIA { get; set; }
        /// <summary>
        /// 心肺复苏治疗；1-是；0-否
        /// </summary>
        public Nullable<Int32> MONARY_RES { get; set; }
        /// <summary>
        /// 心肺复苏治疗成功；1-是；0-否
        /// </summary>
        public Nullable<Int32> MONARY_RES_OK { get; set; }
        /// <summary>
        /// 麻醉中发生未预期的意识障碍；1-是；0-否
        /// </summary>
        public Nullable<Int32> CONS_DISTURBANCE { get; set; }
        /// <summary>
        /// 麻醉中出现氧饱和度重度降低；1-是；0-否
        /// </summary>
        public Nullable<Int32> OXYGEN_SATURATION { get; set; }
        /// <summary>
        /// 全身麻醉结束时使用催醒药物；1-是；0-否
        /// </summary>
        public Nullable<Int32> USE_REMINDERS { get; set; }
        /// <summary>
        /// 麻醉中因误咽误吸引发呼吸道梗阻；1-是；0-否
        /// </summary>
        public Nullable<Int32> RES_TRACT_OBSTRUCE { get; set; }
        /// <summary>
        /// 麻醉意外死亡；1-是；0-否
        /// </summary>
        public Nullable<Int32> ANES_DEATH { get; set; }
        /// <summary>
        /// 其他非预期的相关事件；1-是；0-否
        /// </summary>
        public Nullable<Int32> OTHER_NOT_EXP { get; set; }
        /// <summary>
        /// 术后死亡；1-是；0-否
        /// </summary>
        public Nullable<Int32> DEATH_AFTER_OPER { get; set; }
        /// <summary>
        /// 非计划转入ICU；1-是；0-否
        /// </summary>
        public Nullable<Int32> NO_PLAN_IN_ICU { get; set; }
        /// <summary>
        /// 病人去向；如转入病房
        /// </summary>
        public string PAT_DIRECTION { get; set; }
        /// <summary>
        /// 麻醉效果
        /// </summary>
        public string ANES_EFFECT { get; set; }
        /// <summary>
        /// 非计划再次手术
        /// </summary>
        public string OPER_AGAIN { get; set; }
        /// <summary>
        /// 术前首次预防用抗菌药物时间
        /// </summary>
        public string USE_ANTIBACTERIAL_AGENTS { get; set; }
        /// <summary>
        /// 术中追加
        /// </summary>
        public string OPER_APPENDED { get; set; }
        /// <summary>
        /// 麻醉方法变更
        /// </summary>
        public string ANES_METHOD_CHANGE { get; set; }
        /// <summary>
        /// 变更原因
        /// </summary>
        public string REASON_FOR_CHANGE { get; set; }
        /// <summary>
        /// 入PACU超过3小时
        /// </summary>
        public string PACU_3H { get; set; }
        /// <summary>
        /// 非预期事件发生原因
        /// </summary>
        public string UNEXPECT_EVENT_REASON { get; set; }
        /// <summary>
        /// 术中自体血
        /// </summary>
        public Nullable<Int32> BLOOD_EVENT { get; set; }
        /// <summary>
        /// 手术因素
        /// </summary>
        public Nullable<Int32> OPER_EVENT { get; set; }
        /// <summary>
        /// 麻醉因素
        /// </summary>
        public Nullable<Int32> ANES_EVENT { get; set; }
        /// <summary>
        /// 患者因素
        /// </summary>
        public Nullable<Int32> PAT_INDETIFICATION { get; set; }
        /// <summary>
        /// 预防措施
        /// </summary>
        public string PREVENT_STEP { get; set; }

        /// <summary>
        /// 事件发生经过
        /// </summary>
        public string EVENT_COURSE { get; set; }

        /// <summary>
        /// 困难气道
        /// </summary>
        public Nullable<Int32> DIFFICULT_AIRWAY { get; set; }

        /// <summary>
        /// 不良事件分级：1-Ⅰ级（警讯事件）；2-Ⅱ级（不良后果事件）； 3-Ⅲ级（未造成后果事件）； 4-Ⅳ级（隐患事件）
        /// </summary>
        public int EVENT_GRADE { get; set; }

        /// <summary>
        /// 文件存储路径
        /// </summary>
        public string DOC_ADDRESS { get; set; }

        /// <summary>
        /// 质控云平台返回的文件存储唯一标识符
        /// </summary>
        public string QC_FLODID { get; set; }

    }
}