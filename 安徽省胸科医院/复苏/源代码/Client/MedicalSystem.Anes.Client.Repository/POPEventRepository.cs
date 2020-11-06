using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class POPEventRepository : BaseRepository
    {
        /// <summary>
        /// 采集手术CDR
        /// </summary>
        /// <param name="Operation">手术信息</param>
        /// <returns><![CDATA[RequestResult<string>]></returns>
        public RequestResult<int> SampleCDR(MED_OPERATION_MASTER Operation)
        {
            string address = "PacuPOPEvent/SampleCDR";
            return BaseRepository.PostCallApi<MED_OPERATION_MASTER>(address, Operation);
        }

        /// <summary>
        /// 获取围术期事件索引列表(不分页)
        /// </summary>
        /// <param name="PATIENT_ID">患者住院号 可传null</param>
        /// <param name="VISIT_ID">住院次数 可传null</param>
        /// <param name="OPER_ID">手术次数 可传null</param>
        /// <returns><![CDATA[RequestResult<IEnumerable<MED_PERIOPERATIVE_EVENT_INDEX>>]]></returns>
        public RequestResult<IEnumerable<MED_PERIOPERATIVE_EVENT_INDEX>> GetPOPEventIndexs(string PATIENT_ID, string VISIT_ID, int? OPER_ID)
        {
            string address = "PacuPOPEvent/GetPOPEventIndexs?PATIENT_ID=" + PATIENT_ID + "&VISIT_ID=" + VISIT_ID + "&OPER_ID=" + OPER_ID;
            return BaseRepository.GetCallApi<IEnumerable<MED_PERIOPERATIVE_EVENT_INDEX>>(address);
        }
    }
}
