using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain.ViewModule
{
    /// <summary>
    /// 手术通知单实体
    /// </summary>
    public class OperNoticeEntity
    {
        /// <summary>
        /// 病区
        /// </summary>
        public string WARD_CODE_NAME { get; set; }
        /// <summary>
        /// 手术间
        /// </summary>
        public string OperRoomNo { get; set; }
        /// <summary>
        /// 台次
        /// </summary>
        public int Sequence { get; set; }

        public string Merge_RoomNO { get { return this.OperRoomNo + "—" + this.Sequence; } }

        /// <summary>
        /// 计划手术日期
        /// </summary>
        public string ScheduledDateTime { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO { get; set; }
        /// <summary>
        /// 术前诊断
        /// </summary>
        public string DIAG_BEFORE_OPERATION { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }
        /// <summary>
        /// 术前主要诊断
        /// </summary>
        public string DiagBeforeOperation { get; set; }
        /// <summary>
        /// 手术者
        /// </summary>
        public string SURGEON_NAME { get; set; }
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
        /// 洗手护士1
        /// </summary>
        public string FIRST_OPER_NURSE_NAME { get; set; }

        /// <summary>
        /// 洗手护士2
        /// </summary>
        public string SECOND_OPER_NURSE_NAME { get; set; }

        public string Merge_OPER_NURSE { get { return this.FIRST_OPER_NURSE_NAME + " " + this.SECOND_OPER_NURSE_NAME; } }

        /// <summary>
        /// 巡回护士1
        /// </summary>
        public string FIRST_SUPPLY_NURSE_NAME { get; set; }

        /// <summary>
        /// 巡回护士2
        /// </summary>
        public string SECOND_SUPPLY_NURSE_NAME { get; set; }

        public string Merge_SUPPLY_NURSE { get { return this.FIRST_SUPPLY_NURSE_NAME + " " + this.SECOND_SUPPLY_NURSE_NAME; } }

        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANES_METHOD { get; set; }
        /// <summary>
        /// 麻醉医师
        /// </summary>
        public string ANES_DOCTOR_NAME { get; set; }
        /// <summary>
        /// 副麻1
        /// </summary>
        public string FIRST_ANES_ASSISTANT_NAME { get; set; }

        public string Merge_ANES_DOCTOR { get { return this.ANES_DOCTOR_NAME + " " + this.FIRST_ANES_ASSISTANT_NAME; } }
        /// <summary>
        /// 备注
        /// </summary>
        public string NOTES_ON_OPERATION { get; set; }

    }
}
