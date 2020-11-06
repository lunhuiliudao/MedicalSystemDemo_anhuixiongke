using System;
using System.Collections.Generic;  
using Dapper.Data;


using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 早交班映射实体类
    /// </summary>
    public class SHIFT_OPERATION_INFO : BaseModel
    {
        /// <summary>
        /// 患者编号
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 访问编号
        /// </summary>
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 手术编号
        /// </summary>
        public int OPER_ID { get; set; }
        /// <summary>
        /// 手术日期
        /// </summary>
        public string IN_DATE { get; set; }
        /// <summary>
        /// 科室
        /// </summary>
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 手术间
        /// </summary>
        public string OPER_ROOM_NO { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string AGE { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }
        /// <summary>
        /// 术者
        /// </summary>
        public string SURGEON_NAME { get; set; }
        /// <summary>
        /// 一助
        /// </summary>
        public string FIRST_OPER_ASSISTANT_NAME { get; set; }
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANES_METHOD { get; set; }
        /// <summary>
        /// 主麻
        /// </summary>
        public string ANES_DOCTOR_NAME { get; set; }
        /// <summary>
        /// 副麻
        /// </summary>
        public string FIRST_ANES_ASSISTANT_NAME { get; set; }
        /// <summary>
        /// 巡回
        /// </summary>
        public string FIRST_OPER_NURSE_NAME { get; set; }
        /// <summary>
        /// 洗手
        /// </summary>
        public string FIRST_SUPPLY_NURSE_NAME { get; set; }
        /// <summary>
        /// 入室时间
        /// </summary>
        public Nullable<DateTime> IN_DATE_TIME { get; set; }
        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        public Nullable<DateTime> ANES_START_TIME { get; set; }
        /// <summary>
        /// 手术开始时间
        /// </summary>
        public Nullable<DateTime> START_DATE_TIME { get; set; }
        /// <summary>
        /// 手术结束时间
        /// </summary>
        public Nullable<DateTime> END_DATE_TIME { get; set; }
        /// <summary>
        /// 麻醉结束时间
        /// </summary>
        public Nullable<DateTime> ANES_END_TIME { get; set; }
        /// <summary>
        /// 出手术室时间
        /// </summary>
        public Nullable<DateTime> OUT_DATE_TIME { get; set; }
        /// <summary>
        /// 入PACU时间
        /// </summary>
        public Nullable<DateTime> IN_PACU_DATE_TIME { get; set; }
        /// <summary>
        /// 出PACU时间
        /// </summary>
        public Nullable<DateTime> OUT_PACU_DATE_TIME { get; set; }
        /// <summary>
        /// 术后去向
        /// </summary>
        public string PAT_WHEREABORTS { get; set; }
        /// <summary>
        /// ASA分级
        /// </summary>
        public string ASA_GRADE { get; set; }
        /// <summary>
        /// 麻醉单
        /// </summary>
        public string ANESTHESIA_ID { get; set; }
        /// <summary>
        /// 急诊择期区分
        /// </summary>
        public Nullable<int> EMERGENCY_IND { get; set; }
        /// <summary>
        /// 手术预约时间
        /// </summary>
        public Nullable<DateTime> SCHEDULED_DATE_TIME { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public Nullable<DateTime> DATE_OF_BIRTH { get; set; }
        /// <summary>
        /// 隔离标志	;	指手术是否需要隔离。1-正常 2-隔离
        /// </summary>
        public string ISOLATION_IND { get; set; }
        /// <summary>
        /// 交班类型识别（1：麻醉；2：护理）
        /// </summary>
        public Int32 SHIFT_TYPE { get; set; }
        /// <summary>
        /// 交班区分（1：术前；2：术后）
        /// </summary>
        public Int32 SHIFT_DIVISION { get; set; }
        /// <summary>
        /// 交班标记内容
        /// </summary>
        public string SHIFT_CONTENT { get; set; }
    }
}
