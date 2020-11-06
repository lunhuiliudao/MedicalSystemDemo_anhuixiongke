using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.Common.SecretManage;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Pacu
{
    /// <summary>
    /// 麻醉事件控制器
    /// </summary>
    public class PacuAnesEventController : BaseController
    {
        IPacuAnesEventDataService _anesEventDataService;

        public PacuAnesEventController(IPacuAnesEventDataService anesEventDataService)
        {
            _anesEventDataService = anesEventDataService;
        }

        /// <summary>
        /// 获得麻醉事件字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]                                 
        public RequestResult<List<MED_EVENT_DICT>> GetAnesEventDict()
        {
            return Success(_anesEventDataService.GetAnesEventDict());
        }
        [HttpGet]
        public RequestResult<List<MED_EVENT_DICT>> GetAnesEventDictByItemClass(string eventItemClass)
        {
            return Success(_anesEventDataService.GetAnesEventDictByItemClass(eventItemClass));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_EVENT_DICT>> GetAnesEventDictByhuxi()
        {
            return Success(_anesEventDataService.GetAnesEventDictByhuxi());
        }
        /// <summary>
        /// 获得麻醉事件字扩展表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_EVENT_DICT_EXT>> GetAnesEventDictExt()
        {
            return Success(_anesEventDataService.GetAnesEventDictExt());
        }

        /// <summary>
        /// 删除麻醉事件
        /// </summary>
        /// <returns><![CDATA[RequestResult<bool>]]></returns>
        [HttpPost]
        public RequestResult<bool> DelAnesEvent(MED_ANESTHESIA_EVENT item) 
        {
            return Success(_anesEventDataService.DelAnesEvent(item));
        }
    }
}