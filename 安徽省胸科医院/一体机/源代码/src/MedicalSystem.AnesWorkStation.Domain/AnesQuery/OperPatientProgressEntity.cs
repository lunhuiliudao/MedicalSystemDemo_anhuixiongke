using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public class OperPatientProgressEntity
    {


        public int ID { get; set; }
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
        public string Bed_No { get; set; }


        /// <summary>
        /// 入院时间
        /// </summary>
        public DateTime ADMISSION_DATE_TIME { get; set; }

        /// <summary>
        /// 手术科室
        /// </summary>
        public string DEPT_NAME { get; set; }

        /// <summary>
        /// A麻醉医生
        /// </summary>
        public string AnesDoctor { get; set; }
        /// <summary>
        /// 手术者
        /// </summary>
        public string SURGEON { get; set; }

        /// <summary>
        /// 术前诊断
        /// </summary>
        public string DIAG_BEFORE_OPERATION { get; set; }

        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }
        /// <summary>
        ///手术体位
        /// </summary>
        public string OPER_POSITION { get; set; }

        /// <summary>
        /// 手术等级
        /// </summary>
        public string Oper_Scale { get; set; }
        /// <summary>
        /// 手术安排时间
        /// </summary>
        public DateTime Scheduled_Date_Time { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string AnesMethod { get; set; }

        /// <summary>
        /// BP1
        /// </summary>
        public string before_BP1 { get; set; }

        /// <summary>
        /// BP2
        /// </summary>
        public string before_BP2 { get; set; }

        /// <summary>
        /// p
        /// </summary>
        public string before_P { get; set; }
        /// <summary>
        /// R
        /// </summary>
        public string brfore_R { get; set; }

        /// <summary>
        /// 心电图
        /// </summary>
        public string before_XDT { get; set; }

        /// <summary>
        /// 有无过敏史
        /// </summary>
        public string before_YWGMS { get; set; }

        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANES_METHOD { get; set; }
        /// <summary>
        /// ASA分级
        /// </summary>
        public string Asa_Grade { get; set; }
        
        /// <summary>
        /// 手术时长
        /// </summary>
        public string OPERTIME { get; set; }

        /// <summary>
        /// 入手术室时间
        /// </summary>
        public DateTime In_Date_Time { get; set; }
        /// <summary>
        /// 出手术室时间
        /// </summary>
        public DateTime Out_Date_Time { get; set; }
        /// <summary>
        /// 手术开始时间
        /// </summary>
        public DateTime Start_Date_Time { get; set; }
        /// <summary>
        /// 手术结束时间
        /// </summary>
        public DateTime End_Date_Time { get; set; }
        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        public DateTime Anes_Start_Time { get; set; }
        /// <summary>
        /// 麻醉结束时间
        /// </summary>
        public DateTime Anes_End_Time { get; set; }
        /// <summary>
        /// 入复苏时间
        /// </summary>
        public DateTime In_Pacu_Date_Time { get; set; }
        /// <summary>
        /// 出复苏时间
        /// </summary>
        public DateTime Out_Pacu_Date_Time { get; set; }

        ///文书集合
        public string Docs { get; set; }

    }
}
