namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 术后随访记录表
    /// </summary>
    [Table("MED_ANESTHESIA_INQUIRY")]
    public partial class MED_ANESTHESIA_INQUIRY : BaseModel
    {
        /// <summary>
        /// 主键 病人ID;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数;住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号;一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 随访序号;是  一个病人一次手术可多次术后随访，从1开始，每次随访次数加1
        /// </summary>
        [Key]
        public Int32 INQUIRY_NO { get; set; }
        /// <summary>
        /// 生命体征是否平稳;是、否
        /// </summary>
        public string VITAL_SIGNS_STABLE { get; set; }
        /// <summary>
        /// 意识;清醒、嗜睡、昏迷
        /// </summary>
        public string CONSCIOUSNESS { get; set; }
        /// <summary>
        /// PCA效果;满意、不满意
        /// </summary>
        public string PCA_EFFECT { get; set; }
        /// <summary>
        /// 呼吸系统;异常、未见异常
        /// </summary>
        public string RESPIRATORY_SYSTEM { get; set; }
        /// <summary>
        /// 声音嘶哑;有、无
        /// </summary>
        public string HOARSENESS { get; set; }
        /// <summary>
        /// 肺部感染;有、无
        /// </summary>
        public string PULMONARY_INFECTION { get; set; }
        /// <summary>
        /// 呼吸困难;有、无
        /// </summary>
        public string BREATHING_PROBLEMS { get; set; }
        /// <summary>
        /// 呼吸衰竭;有、无
        /// </summary>
        public string RESPIRATORY_FAILURE { get; set; }
        /// <summary>
        /// 咽喉痛;有、无
        /// </summary>
        public string THROAT_ACHE { get; set; }
        /// <summary>
        /// 低血氧血症;有、无
        /// </summary>
        public string HYPOXEMIA { get; set; }
        /// <summary>
        /// 循环系统;未见异常、异常
        /// </summary>
        public string CIRCULATORY_SYSTEM { get; set; }
        /// <summary>
        /// 严重高/低血压;有、无
        /// </summary>
        public string BLOOD_PRESS_HIGH { get; set; }
        /// <summary>
        /// 严重心律失常;有、无
        /// </summary>
        public string SEVERE_ARRHYTHMIAS { get; set; }
        /// <summary>
        /// 心绞痛;有、无
        /// </summary>
        public string ANGINA { get; set; }
        /// <summary>
        /// 心力衰竭;有、无
        /// </summary>
        public string HEART_FAILURE { get; set; }
        /// <summary>
        /// 神经系统;未见异常、异常
        /// </summary>
        public string NERVOUS_SYSTEM { get; set; }
        /// <summary>
        /// 认知功能障碍;有、无
        /// </summary>
        public string COGNITIVE_DYSFUNCTION { get; set; }
        /// <summary>
        /// 术中知晓;有、无
        /// </summary>
        public string INTRAOPER_AWARENESS { get; set; }
        /// <summary>
        /// 肢体感觉/活动;正常、异常
        /// </summary>
        public string BODY_SENSATION { get; set; }
        /// <summary>
        /// 心肺检查;未见异常、异常
        /// </summary>
        public string CARDIOPULMONARY_EXAM { get; set; }
        /// <summary>
        /// 脊麻后头痛;有、无
        /// </summary>
        public string HEADACHE_AFTER_ANES { get; set; }
        /// <summary>
        /// 术后谵妄;有、无
        /// </summary>
        public string POSTOPER_DELIRIUM { get; set; }
        /// <summary>
        /// 下肢肌力;未见异常、异常
        /// </summary>
        public string LIMB { get; set; }
        /// <summary>
        /// 异感;有、无
        /// </summary>
        public string PARESTHESIA { get; set; }
        /// <summary>
        /// 恶心呕吐;有、无
        /// </summary>
        public string NAUSEA { get; set; }
        /// <summary>
        /// 处理措施
        /// </summary>
        public string MEASURE { get; set; }
        /// <summary>
        /// 尿潴留;有、无
        /// </summary>
        public string EMICTION_RETENTION { get; set; }
        /// <summary>
        /// 是否继续随访;是、否
        /// </summary>
        public string INQUIRY_FOLLOWUP { get; set; }
        /// <summary>
        /// 患者满意度;满意、一般、不满意
        /// </summary>
        public string SATISFACTORY { get; set; }
        /// <summary>
        /// 其他特殊情况
        /// </summary>
        public string OTHER_SPECIAL_CASE { get; set; }
        /// <summary>
        /// 随访麻醉医生
        /// </summary>
        public string INQUIRY_DOCTOR { get; set; }
        /// <summary>
        /// 随访日期
        /// </summary>
        public Nullable<DateTime> INQUIRY_DATE { get; set; }

        /// <summary>
        /// 温蒂
        /// </summary>
        public string TEMPETURE { get; set; }

        /// <summary>
        ///  脉搏
        /// </summary>
        public string PLUS { get; set; }

        /// <summary>
        /// 呼吸
        /// </summary>
        public string BREATH { get; set; }

        /// <summary>
        /// 皮肤
        /// </summary>
        public string CERVIX { get; set; }

        /// <summary>
        /// 伤口情况
        /// </summary>
        public string LIMBS_FEEL { get; set; }
    }
}