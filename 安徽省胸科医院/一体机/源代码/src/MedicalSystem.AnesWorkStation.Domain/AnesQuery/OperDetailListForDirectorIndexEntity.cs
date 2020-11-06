using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public class OperDetailListForDirectorIndexEntity
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
        /// 手术科室
        /// </summary>
        public string DEPT_NAME { get; set; }

        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }
        /// <summary>
        /// 手术等级
        /// </summary>
        public string OPERATION_SCALE { get; set; }
        /// <summary>
        /// 手术者
        /// </summary>
        public string SURGEON { get; set; }
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string AnesMethod { get; set; }
        /// <summary>
        /// ASA分级
        /// </summary>
        public string ASA { get; set; }
        /// <summary>
        /// A麻醉医生
        /// </summary>
        public string AnesDoctor { get; set; }
        /// <summary>
        /// 护士
        /// </summary>
        public string Nurse { get; set; }
        

        /// <summary>
        /// 手术安排时间
        /// </summary>
        public DateTime OPER_DATE { get; set; }


        public string OPERTIME { get; set; }
        /// <summary>
        /// 手术状态
        /// </summary>
        public string Oper_Status { get; set; }

        /// <summary>
        /// 手术间
        /// </summary>
        public string OPERATING_ROOM_NO { get; set; }

        /// <summary>
        /// 台次
        /// </summary>
        public int SEQUENCE { get; set; }


    }
}
