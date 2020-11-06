using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class AnesEventRepository : BaseRepository 
    {
        /// <summary>
        /// 获得麻醉事件字典表
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<MED_EVENT_DICT>> GetAnesEventDict()
        {
            string address = "PacuAnesEvent/GetAnesEventDict";
            return BaseRepository.GetCallApi<List<MED_EVENT_DICT>>(address);
        }
        public RequestResult<List<MED_EVENT_DICT>> GetAnesEventDictByhuxi()
        {
            string address = "PacuAnesEvent/GetAnesEventDictByhuxi";
            return BaseRepository.GetCallApi<List<MED_EVENT_DICT>>(address);
        }
        public RequestResult<List<MED_EVENT_DICT>> GetAnesEventDictByItemClass(string eventItemClass)
        {
            string address = "PacuAnesEvent/GetAnesEventDictByItemClass";
            return BaseRepository.GetCallApi<List<MED_EVENT_DICT>>(address);
        }
        /// <summary>
        /// 获得麻醉事件字典扩展表
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<MED_EVENT_DICT_EXT>> GetAnesEventDictExt()
        {
            string address = "PacuAnesEvent/GetAnesEventDictExt";
            return BaseRepository.GetCallApi<List<MED_EVENT_DICT_EXT>>(address);
        }

        /// <summary>
        /// 删除麻醉事件
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>

        public RequestResult<bool> DelAnesEvent(MED_ANESTHESIA_EVENT item)
        {
            string address = "PacuAnesEvent/DelAnesEvent";
            return BaseRepository.PostCallApi<MED_ANESTHESIA_EVENT, bool>(address, item);
        }

    }
}
