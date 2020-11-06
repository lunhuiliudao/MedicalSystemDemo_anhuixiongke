using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain.ViewModule
{
    /// <summary>
    /// 手术取消实体类
    /// </summary>
    public class OperCancelEntity : BaseModel
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 住院次数
        /// </summary>
        public decimal VISIT_ID { get; set; }
        /// <summary>
        /// 本次住院手术次数
        /// </summary>
        public decimal OPER_ID { get; set; }
        /// <summary>
        /// 手术排班编号
        /// </summary>
        public decimal SCHEDULE_ID { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO { get; set; }
        /// <summary>
        /// 计划手术日期
        /// </summary>
        public string SCHEDULED_DATE_TIME { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PAT_NAME { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string AGE { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }
        /// <summary>
        /// 手术医师
        /// </summary>
        public string SURGEON_NAME { get; set; }
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANESTHESIA_METHOD { get; set; }
        /// <summary>
        /// 手术助手1
        /// </summary>
        public string FIRST_OPER_ASSISTANT_NAME { get; set; }
        /// <summary>
        /// 手术助手2
        /// </summary>
        public string SECOND_OPER_ASSISTANT_NAME { get; set; }
        /// <summary>
        /// 手术助手3
        /// </summary>
        public string THIRD_OPER_ASSISTANT_NAME { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string NOTES_ON_OPERATION { get; set; }


    }
}
