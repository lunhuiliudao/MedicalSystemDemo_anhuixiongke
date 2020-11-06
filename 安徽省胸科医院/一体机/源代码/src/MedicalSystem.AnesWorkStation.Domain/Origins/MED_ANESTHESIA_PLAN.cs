namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 术前访视主表;每条手术对应一条术前访视记录，存放术前访视的主要信息
    /// </summary>
    [Table("MED_ANESTHESIA_PLAN")]
    public partial class MED_ANESTHESIA_PLAN : BaseModel
    {
        /// <summary>
        /// 主键 病人id;	非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数;	病人每次住院加1
        /// </summary>
        [Key]
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号;一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public int OPER_ID { get; set; }
        /// <summary>
        /// 拟施手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }
        /// <summary>
        /// 术前用药
        /// </summary>
        public string PRE_ANES_PHAM { get; set; }
        /// <summary>
        /// 拟施麻醉方法
        /// </summary>
        public string ANESTHESIA_METHOD { get; set; }
        /// <summary>
        /// 按期手术情况;	按期手术、推迟
        /// </summary>
        public string ON_TIME { get; set; }
        /// <summary>
        /// 术前麻醉医嘱
        /// </summary>
        public string INVESTIGATE_SUGGESTION { get; set; }
        /// <summary>
        /// 心功能分级;	I，II，III，IV 四级
        /// </summary>
        public string HEART_GRADE { get; set; }
        /// <summary>
        /// 心脏危险分级;	1级：0～5分，死亡率为0.2%。2级：6～12分，死亡率为2%。3级：13～25分，死亡率为2%。4级：26分，死亡率为>56%。3级和4级的手术危险性较大。5级：大于26分，5级病人只宜施行急救手术。
        /// </summary>
        public string GOLDMAN { get; set; }
        /// <summary>
        /// Mallampatti分级
        /// </summary>
        public string MALLAMPATTI { get; set; }
        /// <summary>
        /// 禁食;	是否饱胃
        /// </summary>
        public string FASTING { get; set; }
        /// <summary>
        /// 术中困难估计及预防措施
        /// </summary>
        public string ANES_SUMMARY { get; set; }
        /// <summary>
        /// 访视日期
        /// </summary>
        public Nullable<DateTime> INQUIRY_BEFORE_DATE { get; set; }
        /// <summary>
        /// 访视医生
        /// </summary>
        public string INQUIRY_DOCTOR { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public Nullable<DateTime> ENTER_DATE_TIME { get; set; }
        /// <summary>
        /// 录入者
        /// </summary>
        public string ENTERED_BY { get; set; }
        /// <summary>
        /// 计划术后去向
        /// </summary>
        public string PLAN_WHEREABORTS { get; set; }
        /// <summary>
        /// 24小时内是否重返手术室
        /// </summary>
        public string RETURN_TO_SURGERY { get; set; }

        /// <summary>
        /// 手术麻醉风险类别
        /// </summary>
        public string ANES_RISK_GRADE { get; set; }
    }
}