using Dapper.Data;
using System;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_QC_OUT_PAT_INFO : BaseModel
    {
        /// <summary>
        /// 住院号
        /// </summary>
        [Key]
        public string INP_NO { get; set; }

        [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public int VISIT_ID { get; set; }
        [Key]
        public int OPER_ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? DATE_OF_BIRTH { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public decimal BODY_HEIGHT { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal BODY_WEIGHT { get; set; }

        /// <summary>
        /// 手术类别
        /// </summary>
        public decimal EMERGENCY_IND { get; set; }

        /// <summary>
        /// 手术科室
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
        /// 诊断名称
        /// </summary>
        public string DIAG_OPERATION { get; set; }

        /// <summary>
        /// 麻醉开始
        /// </summary>
        public DateTime? ANES_START_TIME { get; set; }

        /// <summary>
        /// 麻醉结束
        /// </summary>
        public DateTime? ANES_END_TIME { get; set; }
    }
}
