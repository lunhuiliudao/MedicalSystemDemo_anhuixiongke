namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 手术安排表
    /// </summary>
    [Table("MED_OPERATION_SCHEDULE")]
    public partial class MED_OPERATION_SCHEDULE : BaseModel
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
        /// 主键 手术安排标识	;	一个病人一次住院预约多次手术时，从1开始分配。每次预约时，在该表中取病人预约手术的最大标识数，加1作为本次标识。如果未找到该病人在本表中的预约记录，标识为1)
        /// </summary>
        [Key]
        public Int32 SCHEDULE_ID { get; set; }
        /// <summary>
        /// 手术号	;	当手术排班完成后，提交时产生.一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        public Nullable<Int32> OPER_ID { get; set; }
        /// <summary>
        /// 病人所在院区	;	见院区代码表
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
        /// 手术科室	;	实施手术的科室，即手术医生所在科室.OPERATING_DEPT
        /// </summary>
        public string OPER_DEPT_CODE { get; set; }
        /// <summary>
        /// 手术室	;	见科室代码表.OPERATING_ROOM
        /// </summary>
        public string OPER_ROOM { get; set; }
        /// <summary>
        /// 手术间	;	手术间代码表.OPERATING_ROOM_NO
        /// </summary>
        public string OPER_ROOM_NO { get; set; }
        /// <summary>
        /// 台次
        /// </summary>
        public Nullable<Int32> SEQUENCE { get; set; }
        /// <summary>
        /// 手术类型	;	手术类型代码表。1 一般手术，2 急抢救手术 ，3 术中急抢救
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
        /// 手术等级	;	指一次手术的综合等级。手术等级代码表。I级、II级、III级、IV级
        /// </summary>
        public string OPER_SCALE { get; set; }
        /// <summary>
        /// 切口类型	;	切口类型代码表。I类、II类、III类
        /// </summary>
        public string WOUND_TYPE { get; set; }
        /// <summary>
        /// ASA等级	;	ASA等级代码表。I级、II级、III级、IV级、Ⅴ级、Ⅵ级
        /// </summary>
        public string ASA_GRADE { get; set; }
        /// <summary>
        /// 急诊标志	;	急诊标志。EMERGENCY INDICATOR。0-择期 1-急诊
        /// </summary>
        public Nullable<Int32> EMERGENCY_IND { get; set; }
        /// <summary>
        /// 手术来源	;	0 门诊，1 住院，2 急诊
        /// </summary>
        public Nullable<Int32> OPER_SOURCE { get; set; }
        /// <summary>
        /// 隔离标志	;	指手术是否需要隔离。1-正常 2-隔离
        /// </summary>
        public Nullable<Int32> ISOLATION_IND { get; set; }
        /// <summary>
        /// 感染标志	;	感染标志。1 正常 ，2 感染
        /// </summary>
        public Nullable<Int32> INFECTED_IND { get; set; }
        /// <summary>
        /// 放射标志	;	放射标志。1 正常 ，2 感染
        /// </summary>
        public Nullable<Int32> RADIATE_IND { get; set; }
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
        /// Pacu医生	;	Pacu医生
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
        /// 申请日期及时间		
        /// </summary>
        public Nullable<DateTime> REQ_DATE_TIME { get; set; }
        /// <summary>
        /// 计划手术日期	;	计划做手术的日期
        /// </summary>
        public Nullable<DateTime> SCHEDULED_DATE_TIME { get; set; }
        /// <summary>
        /// 体位	;	对应体位代码表，OPERATION_POSITION
        /// </summary>
        public string OPER_POSITION { get; set; }
        /// <summary>
        /// 床号		
        /// </summary>
        public string BED_NO { get; set; }
        /// <summary>
        /// 手术名称;冗余字段，为表MED_OPERATION_SCHEDULE_NAME中多个手术名称的拼接。所有统计查询，都需要查询MED_OPERATION_SCHEDULE_NAM中相对应的手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }
        /// <summary>
        /// 特殊设备		
        /// </summary>
        public string SPECIAL_EQUIPMENT { get; set; }
        /// <summary>
        /// 特殊感染		
        /// </summary>
        public string SPECIAL_INFECT { get; set; }
        /// <summary>
        /// 麻醉排班确认;0 未确认  ， 1 已确认
        /// </summary>
        public Int32 ANES_CONFIRM { get; set; }
        /// <summary>
        /// 护理排班确认;0 未确认  ， 1 已确认
        /// </summary>
        public Int32 NURSE_CONFIRM { get; set; }
        /// <summary>
        /// 手术状态	;	已分配,已提交,已作废
        /// </summary>
        public Int32 OPER_STATUS_CODE { get; set; }
        /// <summary>
        /// 备注		
        /// </summary>
        public string NOTES_ON_OPERATION { get; set; }
        /// <summary>
        /// 录入者	;	ENTERED_BY
        /// </summary>
        public string OPERATOR { get; set; }
        public string HIS_PATIENT_ID { get; set; }
        public string HIS_VISIT_ID { get; set; }
        public string HIS_SCHEDULE_ID { get; set; }
        public string HIS_OPER_STATUS { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public Nullable<Int32> OPERATING_TIME { get; set; }
    }
}