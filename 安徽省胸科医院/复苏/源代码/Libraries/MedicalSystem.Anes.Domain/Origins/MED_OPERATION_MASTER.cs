namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 病人手术主记录
    /// </summary>
    [Table("MED_OPERATION_MASTER")]
    public partial class MED_OPERATION_MASTER : BaseModel
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
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号	;	一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public int OPER_ID { get; set; }
        /// <summary>
        /// 病人所在院区	;	记录病人所在院区信息。对应院区代码表MED_HOSP_BRANCH_DICT
        /// </summary>
        public string HOSP_BRANCH { get; set; }
        /// <summary>
        /// 病人所在病区	;	见病区代码表。MED_WARD_DICT
        /// </summary>
        public string WARD_CODE { get; set; }
        /// <summary>
        /// 病人所在科室	;	见科室代码表。MED_DEPT_DICT
        /// </summary>
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 手术科室	;	实施手术的科室，即手术医生所在科室。MED_DEPT_DICT
        /// </summary>
        public string OPER_DEPT_CODE { get; set; }
        /// <summary>
        /// 手术室	;	室科室代码。MED_DEPT_DICT
        /// </summary>
        public string OPER_ROOM { get; set; }
        /// <summary>
        /// 手术间	;	手术间代码表
        /// </summary>
        public string OPER_ROOM_NO { get; set; }
        /// <summary>
        /// 台次		
        /// </summary>
        public Nullable<int> SEQUENCE { get; set; }
        /// <summary>
        /// 手术类型	;	手术类型代码表。1 一般手术 ，2 急抢救手术 ，3 术中急抢救
        /// </summary>
        public string OPER_CLASS { get; set; }
        /// <summary>
        /// 术前主要诊断	;	病人手术前的诊断描述
        /// </summary>
        public string DIAG_BEFORE_OPERATION { get; set; }
        /// <summary>
        /// 病情说明		
        /// </summary>
        public string PATIENT_CONDITION { get; set; }
        /// <summary>
        /// 手术等级	;	指一次手术的综合等级。手术等级代码表，I级、ii级、iii级、iv级
        /// </summary>
        public string OPER_SCALE { get; set; }
        /// <summary>
        /// 切口类型	;	切口类型代码表，I类、ii类、iii类
        /// </summary>
        public string WOUND_TYPE { get; set; }
        /// <summary>
        /// Asa等级	;	Asa等级代码表，I级、ii级、iii级、iv级、Ⅴ级、Ⅵ级
        /// </summary>
        public string ASA_GRADE { get; set; }
        /// <summary>
        /// 术后诊断	;	病人手术后的诊断描述
        /// </summary>
        public string DIAG_AFTER_OPERATION { get; set; }
        /// <summary>
        /// 急诊标志	;	急诊标志，0-择期 1-急诊
        /// </summary>
        public Nullable<int> EMERGENCY_IND { get; set; }
        /// <summary>
        /// 手术来源	;	0 门诊，1 住院，2 急诊
        /// </summary>
        public Nullable<int> OPER_SOURCE { get; set; }
        /// <summary>
        /// 隔离标志	;	指手术是否需要隔离。1-正常 2-隔离
        /// </summary>
        public Nullable<int> ISOLATION_IND { get; set; }
        /// <summary>
        /// 感染标志	;	感染标志。1 正常 ，2 感染
        /// </summary>
        public Nullable<int> INFECTED_IND { get; set; }
        /// <summary>
        /// 放射标志	;	放射标志。1 正常 ，2 感染
        /// </summary>
        public Nullable<int> RADIATE_IND { get; set; }
        /// <summary>
        /// 手术者	;	手术医师姓名
        /// </summary>
        public string SURGEON { get; set; }
        /// <summary>
        /// 第一手术助手	;	第一手术助手，First_assistant
        /// </summary>
        public string FIRST_OPER_ASSISTANT { get; set; }
        /// <summary>
        /// 第二手术助手	;	第二手术助手，Second_assistant
        /// </summary>
        public string SECOND_OPER_ASSISTANT { get; set; }
        /// <summary>
        /// 第三手术助手	;	第三手术助手，Third_assistant
        /// </summary>
        public string THIRD_OPER_ASSISTANT { get; set; }
        /// <summary>
        /// 第四手术助手	;	第四手术助手，Fourth_assistant
        /// </summary>
        public string FOURTH_OPER_ASSISTANT { get; set; }
        /// <summary>
        /// 麻醉方法	;	Anesthesia_method
        /// </summary>
        public string ANES_METHOD { get; set; }
        /// <summary>
        /// 麻醉医师	;	麻醉医师姓名，Anesthesia_doctor
        /// </summary>
        public string ANES_DOCTOR { get; set; }
        /// <summary>
        /// 麻醉助手1	;	麻醉第一助手 anesthesia_assistant
        /// </summary>
        public string FIRST_ANES_ASSISTANT { get; set; }
        /// <summary>
        /// 麻醉助手2	;	麻醉第二助手 second_anesthesia _assistant
        /// </summary>
        public string SECOND_ANES_ASSISTANT { get; set; }
        /// <summary>
        /// 麻醉助手3	;	麻醉第三助手third_anesthesia _assistant 
        /// </summary>
        public string THIRD_ANES_ASSISTANT { get; set; }
        /// <summary>
        /// 麻醉助手4	;	麻醉第四助手 fourth_anesthesia _assistant
        /// </summary>
        public string FOURTH_ANES_ASSISTANT { get; set; }
        /// <summary>
        /// 灌注医生	;	灌注医生
        /// </summary>
        public string CPB_DOCTOR { get; set; }
        /// <summary>
        /// 灌注医生助手1	;	灌注医生助手1
        /// </summary>
        public string FIRST_CPB_ASSISTANT { get; set; }
        /// <summary>
        /// 灌注医生助手2	;	灌注医生助手2
        /// </summary>
        public string SECOND_CPB_ASSISTANT { get; set; }
        /// <summary>
        /// 灌注医生助手3	;	灌注医生助手3
        /// </summary>
        public string THIRD_CPB_ASSISTANT { get; set; }
        /// <summary>
        /// 灌注医生助手4	;	灌注医生助手4
        /// </summary>
        public string FOURTH_CPB_ASSISTANT { get; set; }
        /// <summary>
        /// 第一台上护士	;	器械护士/洗手护士
        /// </summary>
        public string FIRST_OPER_NURSE { get; set; }
        /// <summary>
        /// 第二台上护士	;	器械护士/洗手护士
        /// </summary>
        public string SECOND_OPER_NURSE { get; set; }
        /// <summary>
        /// 第三台上护士	;	器械护士/洗手护士
        /// </summary>
        public string THIRD_OPER_NURSE { get; set; }
        /// <summary>
        /// 第四台上护士	;	器械护士/洗手护士
        /// </summary>
        public string FOURTH_OPER_NURSE { get; set; }
        /// <summary>
        /// 第一供应护士	;	巡回护士
        /// </summary>
        public string FIRST_SUPPLY_NURSE { get; set; }
        /// <summary>
        /// 第二供应护士	;	巡回护士
        /// </summary>
        public string SECOND_SUPPLY_NURSE { get; set; }
        /// <summary>
        /// 第三供应护士	;	巡回护士
        /// </summary>
        public string THIRD_SUPPLY_NURSE { get; set; }
        /// <summary>
        /// 第四供应护士	;	巡回护士
        /// </summary>
        public string FOURTH_SUPPLY_NURSE { get; set; }
        /// <summary>
        /// acu医生	;	Pacu医生
        /// </summary>
        public string PACU_DOCTOR { get; set; }
        /// <summary>
        /// pacu助手1	;	pacu第一助手
        /// </summary>
        public string FIRST_PACU_ASSISTANT { get; set; }
        /// <summary>
        /// pacu助手2	;	pacu第二助手
        /// </summary>
        public string SECOND_PACU_ASSISTANT { get; set; }
        /// <summary>
        /// Pacu护士1	;	Pacu第一护士
        /// </summary>
        public string FIRST_PACU_NURSE { get; set; }
        /// <summary>
        /// Pacu护士2	;	Pacu第二护士
        /// </summary>
        public string SECOND_PACU_NURSE { get; set; }
        /// <summary>
        /// 手术申请日期		
        /// </summary>
        public Nullable<DateTime> REQ_DATE_TIME { get; set; }
        /// <summary>
        /// 手术安排日期
        /// </summary>
        public Nullable<DateTime> SCHEDULED_DATE_TIME { get; set; }
        /// <summary>
        /// 进入手术室日期及时间	
        /// </summary>
        public Nullable<DateTime> IN_DATE_TIME { get; set; }
        /// <summary>
        /// 离开手术室日期及时间	
        /// </summary>
        public Nullable<DateTime> OUT_DATE_TIME { get; set; }
        /// <summary>
        /// 手术开始日期及时间
        /// </summary>
        public Nullable<DateTime> START_DATE_TIME { get; set; }
        /// <summary>
        /// 手术结束日期及时间
        /// </summary>
        public Nullable<DateTime> END_DATE_TIME { get; set; }
        /// <summary>
        /// 进入pacu日期及时间
        /// </summary>
        public Nullable<DateTime> IN_PACU_DATE_TIME { get; set; }
        /// <summary>
        /// 离开pacu日期及时间
        /// </summary>
        public Nullable<DateTime> OUT_PACU_DATE_TIME { get; set; }
        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        public Nullable<DateTime> ANES_START_TIME { get; set; }
        /// <summary>
        /// 麻醉结束时间
        /// </summary>
        public Nullable<DateTime> ANES_END_TIME { get; set; }
        /// <summary>
        /// 手术状态	;	对应手术状态代码表
        /// </summary>
        public int OPER_STATUS_CODE { get; set; }
        /// <summary>
        /// 手术体位	;	对应体位代码表，Operation_position
        /// </summary>
        public string OPER_POSITION { get; set; }
        /// <summary>
        /// 床号	;	是否可以放在住院患者信息表中
        /// </summary>
        public string BED_NO { get; set; }
        /// <summary>
        /// 手术名称	;	与med_operation_name 表重复，字段扩大200，此处只为显示时使用。所有统计查询，都需要查询med_operation_name中相对应的手术名称。
        /// </summary>
        public string OPERATION_NAME { get; set; }
        /// <summary>
        /// 病人去向	;	对应病人去向代码表，原科室、icu等等，Patient whereabouts
        /// </summary>
        public string PAT_WHEREABORTS { get; set; }
        /// <summary>
        /// 麻醉满意程度	;	1-满意 2-不全满意 3-改麻醉
        /// </summary>
        public Nullable<int> SATISFACTION_DEGREE { get; set; }
        /// <summary>
        /// 手术过程顺利标志	;	1-顺利 0-不顺利
        /// </summary>
        public Nullable<int> SMOOTH_INDICATOR { get; set; }
        /// <summary>
        /// 录入者		
        /// </summary>
        public string ENTERED_BY { get; set; }
        /// <summary>
        /// 医嘱提交
        /// </summary>
        public Nullable<int> ORDER_TRANSFER { get; set; }
        /// <summary>
        /// 费用提交
        /// </summary>
        public Nullable<int> CHARGE_TRANSFER { get; set; }
        /// <summary>
        /// 完成标识	;	1-手术登记完成，完成后不允许再修改
        /// </summary>
        public Nullable<int> END_INDICATOR { get; set; }
        /// <summary>
        /// 备注		
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 麻醉单编号		
        /// </summary>
        public string ANESTHESIA_ID { get; set; }
        /// <summary>
        /// HIS病人ID
        /// </summary>
        public string HIS_PATIENT_ID { get; set; }
        /// <summary>
        /// His住院次数
        /// </summary>
        public string HIS_VISIT_ID { get; set; }
        /// <summary>
        /// HIS手术申请ID
        /// </summary>
        public string HIS_SCHEDULE_ID { get; set; }
        /// <summary>
        /// His申请状态
        /// </summary>
        public string HIS_OPER_STATUS { get; set; }
        public string RESERVED01 { get; set; }
        public string RESERVED02 { get; set; }
        public string RESERVED03 { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public Nullable<int> WOUND_NUMBER { get; set; }
        /// <summary>
        /// 第一麻醉护士
        /// </summary>
        public string FIRST_ANES_NURSE { get; set; }
        /// <summary>
        /// 第二麻醉护士
        /// </summary>
        public string SECOND_ANES_NURSE { get; set; }
        /// <summary>
        /// 第三麻醉护士
        /// </summary>
        public string THIRD_ANES_NURSE { get; set; }
        /// <summary>
        /// 插管类型
        /// </summary>
        public string INTUBATTON_TYPE { get; set; }
        /// <summary>
        /// 插管途径
        /// </summary>
        public string INTUBATTON_PATH { get; set; }
        /// <summary>
        /// 穿刺部位
        /// </summary>
        public string PUNCTURE_POSITION { get; set; }
        /// <summary>
        /// 置管方向
        /// </summary>
        public string INDWELLING_DIRECTION { get; set; }
        /// <summary>
        /// 置管深度
        /// </summary>
        public string INDWELLING_LENGTH { get; set; }
        /// <summary>
        /// Steward苏醒评分
        /// </summary>
        public string STEWARD { get; set; }
        /// <summary>
        /// 特殊设备
        /// </summary>
        public string SPECIAL_EQUIPMENT { get; set; }
        /// <summary>
        /// 特殊感染
        /// </summary>
        public string SPECIAL_INFECT { get; set; }
        /// <summary>
        /// 出手术室去向
        /// </summary>
        public int OUT_OPER_WHEREABORTS { get; set; }
        /// <summary>
        /// 出手术室转去向时间
        /// </summary>
        public Nullable<DateTime> OUT_OPER_OVERTIME { get; set; }
        /// <summary>
        /// 出复苏室去向
        /// </summary>
        public int OUT_PACU_WHEREABORTS { get; set; }
        /// <summary>
        /// 出复苏室去向时间
        /// </summary>
        public Nullable<DateTime> OUT_PACU_OVERTIME { get; set; }
        /// <summary>
        /// 麻醉类型
        /// </summary>
        public string ANAESTHESIA_TYPE { get; set; }
    }
}