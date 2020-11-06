namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 手术安全核查
    /// </summary>
    [Table("MED_SAFETY_CHECKS")]
    public partial class MED_SAFETY_CHECKS : BaseModel
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
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号;	一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 患者确认1			;	Default 是
        /// </summary>
        public string PATIENT_CONFIRM1 { get; set; }
        /// <summary>
        /// 手术确认1			;	Default 是
        /// </summary>
        public string OPERATION_CONFIRM1 { get; set; }
        /// <summary>
        /// 手术部位确认1			;	Default 是
        /// </summary>
        public string OPERATION_POSITION_CONFIRM1 { get; set; }
        /// <summary>
        /// 手术同意书确认			;	Default 是
        /// </summary>
        public string OPERATION_APPROVAL_CONFIRM { get; set; }
        /// <summary>
        /// 麻醉同意书确认			;	Default 是
        /// </summary>
        public string ANESTHESIA_APPROVAL_CONFIRM { get; set; }
        /// <summary>
        /// 麻醉方式确认			;	Default 是
        /// </summary>
        public string ANESTHESIA_METHOD_CONFIRM { get; set; }
        /// <summary>
        /// 麻醉设备确认			;	Default 是
        /// </summary>
        public string EQUIPMENT_CONFIRM { get; set; }
        /// <summary>
        /// 皮肤是否完整			;	Default 是
        /// </summary>
        public string SKIN_INTEGRITY_CONFIRM1 { get; set; }
        /// <summary>
        /// 术野皮肤准备正确			;	Default 是
        /// </summary>
        public string ALL_SKIN_CONFIRM { get; set; }
        /// <summary>
        /// 静脉通道建立完成			;	Default 是
        /// </summary>
        public string VENOUS_ROUTE { get; set; }
        /// <summary>
        /// 患者是否有过敏史			;	Default 否
        /// </summary>
        public string ALERGY_HISTORY_CONFIRM { get; set; }
        /// <summary>
        /// 抗菌药物皮试结果			;	Default 是
        /// </summary>
        public string SKIN_TEST_RESULT { get; set; }
        /// <summary>
        /// 感染性疾病筛查结果			;	Default 是
        /// </summary>
        public string INFECTED_CONFIRM { get; set; }
        /// <summary>
        /// 术前备血			;	Default 是
        /// </summary>
        public string BLOOD_PREPARATION { get; set; }
        /// <summary>
        /// 假体			;	Default 是
        /// </summary>
        public string PROTHESIS { get; set; }
        /// <summary>
        /// 体内植入物			;	Default 是
        /// </summary>
        public string IMPLANTED { get; set; }
        /// <summary>
        /// 影像学资料			;	Default 是
        /// </summary>
        public string IMAGING_DATA1 { get; set; }
        /// <summary>
        /// 其他	
        /// </summary>
        public string ORTHER1 { get; set; }
        /// <summary>
        /// 手术医生签名1
        /// </summary>
        public string OPER_DOCTOR1 { get; set; }
        /// <summary>
        /// 麻醉医生签名1
        /// </summary>
        public string ANES_DOCTOR1 { get; set; }
        /// <summary>
        /// 护士签名1
        /// </summary>
        public string NURSE1 { get; set; }
        /// <summary>
        /// 核对时间1
        /// </summary>
        public Nullable<DateTime> CHECK_TIME1 { get; set; }
        /// <summary>
        /// 患者确认2			;	Default 是
        /// </summary>
        public string PATIENT_CONFIRM2 { get; set; }
        /// <summary>
        /// 手术确认2			;	Default 是
        /// </summary>
        public string OPERATION_CONFIRM2 { get; set; }
        /// <summary>
        /// 手术部位确认2			;	Default 是
        /// </summary>
        public string OPERATION_POSITION_CONFIRM2 { get; set; }
        /// <summary>
        /// 手术医生预计时间			;	Default 是
        /// </summary>
        public string ESTIMATED_TIME { get; set; }
        /// <summary>
        /// 手术医生预计失血量			;	Default 是
        /// </summary>
        public string ESTIMATED_BLOOD_LOSS { get; set; }
        /// <summary>
        /// 手术医生手术关注点			;	Default 是
        /// </summary>
        public string OPER_DOCTOR_FOCUSES { get; set; }
        /// <summary>
        /// 手术医生其他			;	Default 是
        /// </summary>
        public string OPER_DOCTOR_OTHER { get; set; }
        /// <summary>
        /// 麻醉医生关注点			;	Default 是
        /// </summary>
        public string ANES_DOCTOR_FOCUSES { get; set; }
        /// <summary>
        /// 麻醉医生其他			;	Default 是
        /// </summary>
        public string ANES_DOCTOR_OTHER { get; set; }
        /// <summary>
        /// 护士 物品灭菌合格			;	Default 是
        /// </summary>
        public string STERILISATION_CONFIRM { get; set; }
        /// <summary>
        /// 护士 仪器设备			;	Default 是
        /// </summary>
        public string EQUIPMENT { get; set; }
        /// <summary>
        /// 护士 特殊用药情况			;	Default 是
        /// </summary>
        public string SPECIFIC_MEDICATIONS { get; set; }
        /// <summary>
        /// 护士 30分钟内抗生素使用			;	Default 是
        /// </summary>
        public string ANTIBIOTICS { get; set; }
        /// <summary>
        /// 护士 其他
        /// </summary>
        public string NURSE_OTHER { get; set; }
        /// <summary>
        /// 是否需要影响资料			;	Default 是
        /// </summary>
        public string IMAGING_DATA2 { get; set; }
        /// <summary>
        /// 手术医生签名2
        /// </summary>
        public string OPER_DOCTOR2 { get; set; }
        /// <summary>
        /// 麻醉医生签名2
        /// </summary>
        public string ANES_DOCTOR2 { get; set; }
        /// <summary>
        /// 护士签名2	
        /// </summary>
        public string NURSE2 { get; set; }
        /// <summary>
        /// 核对时间2
        /// </summary>
        public Nullable<DateTime> CHECK_TIME2 { get; set; }
        /// <summary>
        /// 患者确认3			;	Default 是
        /// </summary>
        public string PATIENT_CONFIRM3 { get; set; }
        /// <summary>
        /// 手术确认3			;	Default 是
        /// </summary>
        public string OPERATION_CONFIRM3 { get; set; }
        /// <summary>
        /// 手术用药确认			;	Default 是
        /// </summary>
        public string MEDICATION_CONFIRM { get; set; }
        /// <summary>
        /// 标本确认			;	Default 是
        /// </summary>
        public string PECIMENS { get; set; }
        /// <summary>
        /// 皮肤完整确认			;	Default 是
        /// </summary>
        public string SKIN_INTEGRITY_CONFIRM3 { get; set; }
        /// <summary>
        /// 物品清点确认			;	Default 是
        /// </summary>
        public string OPERATION_EQUIP_INDICATOR { get; set; }
        /// <summary>
        /// 中心静脉通路			;	Default 有
        /// </summary>
        public string CENTRAL_VENOUS { get; set; }
        /// <summary>
        /// 动脉通路			;	Default 有
        /// </summary>
        public string ARTERY_PATH { get; set; }
        /// <summary>
        /// 气管插管			;	Default 有
        /// </summary>
        public string RACHEA_CANNULA { get; set; }
        /// <summary>
        /// 伤口引流			;	Default 有
        /// </summary>
        public string SUCTION_DRAINAGE { get; set; }
        /// <summary>
        /// 胃管			;	Default 有
        /// </summary>
        public string STOMACH_TUBE { get; set; }
        /// <summary>
        /// 尿管			;	Default 有
        /// </summary>
        public string URINE_TUBE { get; set; }
        /// <summary>
        /// 其他	
        /// </summary>
        public string ORTHER2 { get; set; }
        /// <summary>
        /// 其他	
        /// </summary>
        public string ORTHER3 { get; set; }
        /// <summary>
        /// 患者去向
        /// </summary>
        public string PAT_WHEREABORTS { get; set; }
        /// <summary>
        /// 手术医生签名3
        /// </summary>
        public string OPER_DOCTOR3 { get; set; }
        /// <summary>
        /// 麻醉医生签名3
        /// </summary>
        public string ANES_DOCTOR3 { get; set; }
        /// <summary>
        /// 护士签名3	
        /// </summary>
        public string NURSE3 { get; set; }
        /// <summary>
        /// 核对时间3
        /// </summary>
        public Nullable<DateTime> CHECK_TIME3 { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public string ORTHER4 { get; set; }
    }
}