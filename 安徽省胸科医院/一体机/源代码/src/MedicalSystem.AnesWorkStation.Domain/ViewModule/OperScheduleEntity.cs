using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.AnesWorkStation.Domain.Origins;

namespace MedicalSystem.AnesWorkStation.Domain.ViewModule
{
    public class OperScheduleEntity
    {
        /// <summary>
        ///  病人id 
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 住院次数
        /// </summary>
        public int VisitId { get; set; }
        /// <summary>
        /// 手术安排标识
        /// </summary>
        public int ScheduleId { get; set; }
        /// <summary>
        /// 手术号
        /// </summary>
        public int OperId { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 患者性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 排班时间
        /// </summary>
        public DateTime? ScheduledDateTime { get; set; }
        /// <summary>
        /// 患者年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// 排班状态
        /// </summary>
        public int OperStatusCode { get; set; }
        /// <summary>
        /// 手术间号
        /// </summary>
        public String OperRoomNo { get; set; }

        /// <summary>
        /// 术者
        /// </summary>
        public string SurgeonName { get; set; }
    }

    public class OperScheduleInRoomEntity
    {
        /// <summary>
        /// 手术间集合
        /// </summary>
        public List<MED_OPERATING_ROOM> OperRoomNoList { get; set; }
        /// <summary>
        /// 手术信息集合
        /// </summary>
        public List<OperScheduleEntity> OperScheduleList { get; set; }

    }
}
