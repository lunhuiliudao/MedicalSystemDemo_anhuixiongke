using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Domain.ViewModule
{
    public class MedicalBasicDoc
    {
        /// <summary>
        /// PATIENT_ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// VISIT_ID
        /// </summary>
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// OPER_ID
        /// </summary>
        public Int32 OPER_ID { get; set; }

        /// <summary>
        /// 当前文书状态类型
        /// </summary>
        public string StatusType { get; set; }

        /// <summary>
        /// 当前文书名称
        /// </summary>
        public string DocName { get; set; }

        /// <summary>
        /// 自定义表数据
        /// </summary>
        public dynamic CustomData { get; set; }
        /// <summary>
        /// MED_OPERATION_MASTER
        /// </summary>
        public MED_OPERATION_MASTER MED_OPERATION_MASTER { get; set; }

        /// <summary>
        /// 安全核查表
        /// </summary>
        public MED_SAFETY_CHECKS MED_SAFETY_CHECKS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MED_PAT_VISIT MED_PAT_VISIT { get; set; }

        /// <summary>
        /// 术前访视(病史)
        /// </summary>
        public MED_ANESTHESIA_PLAN MED_ANESTHESIA_PLAN { get; set; }

        /// <summary>
        /// 术前访视(病史)
        /// </summary>
        public MED_ANESTHESIA_PLAN_EXAM MED_ANESTHESIA_PLAN_EXAM { get; set; }

        /// <summary>
        /// 术前访视(病史)
        /// </summary>
        public MED_ANESTHESIA_PLAN_PMH MED_ANESTHESIA_PLAN_PMH { get; set; }

        /// <summary>
        /// 手术随访记录
        /// </summary>
        public MED_ANESTHESIA_RECOVER MED_ANESTHESIA_RECOVER { get; set; }

        /// <summary>
        /// 手术随访记录
        /// </summary>
        public MED_ANESTHESIA_INQUIRY MED_ANESTHESIA_INQUIRY { get; set; }

        /// <summary>
        /// 压疮评估单
        /// </summary>
        public MED_PRESSUREESTIMATE_DOC MED_PRESSUREESTIMATE_DOC { get; set; }

        /// <summary>
        ///  护理记录单
        /// </summary>
        public MED_NURSING_AFTER MED_NURSING_AFTER { get; set; }
        public MED_NURSING_AFTERSHIFT_PACU MED_NURSING_AFTERSHIFT_PACU { get; set; }
        public MED_NURSING_AFTERSHIFT_WARD MED_NURSING_AFTERSHIFT_WARD { get; set; }
        public MED_NURSING_BEFOREASSESS MED_NURSING_BEFOREASSESS { get; set; }
        public MED_NURSING_BEFORESHIFT MED_NURSING_BEFORESHIFT { get; set; }
        public MED_NURSING_QDNURSE MED_NURSING_QDNURSE { get; set; }
        public List<MED_NURSING_TOUR> MED_NURSING_TOUR { get; set; }
        public MED_NURSING_YWASSESS MED_NURSING_YWASSESS { get; set; }
        public List<MED_NURSING_QINGDIAN> MED_NURSING_QINGDIAN { get; set; }
        public OutOperatingRoomAnesRecordEntity OutOperatingRoomAnesRecordEntity { get; set; }
        public dynamic PatientDetail { get; set; }
    }
}
