using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public class OutOperatingRoomAnesRecordEntity
    {


        public string PATIENT_ID { get; set; }
        public int VISIT_ID { get; set; }
        public int OPER_ID { get; set; }

        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string AGE { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 急诊择期
        /// </summary>
       public string EMERGENCY_IND { get; set; }
        /// <summary>
        /// 入院时间
        /// </summary>
        public DateTime DATE_Of_BIRTH { get; set; }

        /// <summary>
        /// 手术科室
        /// </summary>
        public string DEPT_NAME { get; set; }

        /// <summary>
        /// 麻醉医生
        /// </summary>
        public string ANES_DOCTOR { get; set; }
        /// <summary>
        /// 麻醉助手
        /// </summary>
        public string FIRST_ANES_ASSISTANT { get; set; }
        /// <summary>
        /// 护士1
        /// </summary>
        public string FIRST_OPER_NURSE { get; set; }
        /// <summary>
        /// 护士2
        /// </summary>
        public string SECOND_OPER_NURSE { get; set; }
        /// <summary>
        /// 手术者
        /// </summary>
        public string SURGEON { get; set; }

        /// <summary>
        /// 术前诊断
        /// </summary>
        public string DIAG_BEFORE_OPERATION { get; set; }
        /// <summary>
        /// 术前诊断集合
        /// </summary>
        public string[] DIAG_BEFORE_OPERATIONS { get; set; }

        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }

        /// <summary>
        /// 手术名称集合
        /// </summary>
        public string[] OPERATION_NAMES { get; set; }

        /// <summary>
        /// 手术等级
        /// </summary>
        public string OPER_SCALE { get; set; }

        /// <summary>
        /// 手术安排时间
        /// </summary>
        public DateTime SCHEDULED_DATE_TIME { get; set; }


        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANES_METHOD { get; set; }
        /// <summary>
        /// ASA分级
        /// </summary>
        public string ASA_GRADE { get; set; }
        


        /// <summary>
        /// 入手术室时间
        /// </summary>
        public DateTime? IN_DATE_TIME { get; set; }
        /// <summary>
        /// 出手术室时间
        /// </summary>
        public DateTime? OUT_DATE_TIME { get; set; }
        /// <summary>
        /// 手术开始时间
        /// </summary>
        public DateTime? START_DATE_TIME { get; set; }
        /// <summary>
        /// 手术结束时间
        /// </summary>
        public DateTime? END_DATE_TIME { get; set; }
        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        public DateTime ANES_START_TIME { get; set; }
        /// <summary>
        /// 麻醉结束时间
        /// </summary>
        public DateTime ANES_END_TIME { get; set; }

        /// <summary>
        /// 手术间
        /// </summary>
        public string OPER_ROOM { get; set; }
        /// <summary>
        /// 手术间号
        /// </summary>
        public string OPER_ROOM_NO { get; set; }

        /// <summary>
        /// 手术助手
        /// </summary>
        public string FIRST_OPER_ASSISTANT { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public string WEIGHT { get; set; }
    }
}
