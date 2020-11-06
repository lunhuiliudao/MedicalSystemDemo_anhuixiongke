using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_QC_PATIENT_INFO: BaseModel
    {
        /// <summary>
        /// 是否上传
        /// </summary>
        public int UPLOAD { get; set; }

        /// <summary>
        /// 患者编号
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// 就诊次数
        /// </summary>
        public decimal VISIT_ID { get; set; }

        /// <summary>
        /// 手术次数
        /// </summary>
        public decimal OPER_ID { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 患者性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 患者性别
        /// </summary>
        public string AGE { get; set; }
        /// <summary>
        /// 科室
        /// </summary>
        public string DEPT_NAME { get; set; }

        /// <summary>
        /// 手术间
        /// </summary>
        public string OPER_ROOM_NO { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        public string DEPT_CODE { get; set; }

        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }

        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANES_METHOD { get; set; }

        /// <summary>
        /// ASA分级
        /// </summary>
        public string ASA_GRADE { get; set; }

        /// <summary>
        /// 麻醉医生
        /// </summary>
        public string ANES_DOCTOR { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public string SCHEDULED_DATE_TIME { get; set; }

        /// <summary>
        /// 不良事件明细
        /// </summary>
        public string AE_DETAIL { get; set; }

        /// <summary>
        /// 不良事件明细代码
        /// </summary>
        public string AE_DETAIL_CODE { get; set; }

        /// <summary>
        /// 报表ID
        /// </summary>
        public string REPORT_ID { get; set;}

        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO { get; set; }

        /// <summary>
        /// 麻醉结束时间
        /// </summary>
        public string ANES_END_TIME { get; set; }

        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        public string ANES_START_TIME { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string DATE_OF_BIRTH { get; set; }

        /// <summary>
        /// 诊断
        /// </summary>
        public string DIAG_AFTER_OPERATION { get; set; }

        /// <summary>
        /// 不良事件发生原因分析
        /// </summary>
        public string UNEXPECT_EVENT_REASON { get; set; }

        /// <summary>
        /// 不良事件发生原因
        /// </summary>
        public string EventCause { get; set; }

        /// <summary>
        /// 不良事件“其它”类型（质控标准包括的不良事件类型，但手麻系统没有该类型）
        /// </summary>
        public string OTHER_EVENT { get; set; }

        /// <summary>
        /// 不良事件发生经过
        /// </summary>
        public string EVENT_COURSE { get; set; }

        /// <summary>
        /// 不良事件类型
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public string BODY_HEIGHT { get; set; }

        /// <summary>
        /// 预防措施
        /// </summary>
        public string PREVENT_STEP { get; set; }

        /// <summary>
        /// 手术类别 急诊 择期
        /// </summary>
        public string EMERGENCY_IND { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public string BODY_WEIGHT { get; set; }


        /// <summary>
        /// 上报编码
        /// </summary>
        public string REPORT_CODE { get; set; }

        /// <summary>
        /// 不良事件分级：1-Ⅰ级（警讯事件）；2-Ⅱ级（不良后果事件）； 3-Ⅲ级（未造成后果事件）； 4-Ⅳ级（隐患事件）
        /// </summary>
        public string EVENT_GRADE { get; set; }
    }
}
