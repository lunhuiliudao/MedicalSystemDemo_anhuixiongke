using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.Common.SecretManage;
using Newtonsoft.Json;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Pacu
{
    /// <summary>
    /// 围术期事件
    /// </summary>
    public class PacuPOPEventController : BaseController
    {
        IPacuPOPEventService _pacuPOPEventService;

        public PacuPOPEventController(IPacuPOPEventService pacuPOPEventService)
        {
            _pacuPOPEventService = pacuPOPEventService;
        }

        #region 围术期事件配置相关方法

        /// <summary>
        /// 新增围术期事件配置
        /// </summary>
        /// <param name="POPEventConfig">围术期事件配置</param>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<bool> AddPOPEventConfig(MED_PERIOPERATIVE_EVENT_CONFIG POPEventConfig)
        {
            return Success(_pacuPOPEventService.AddPOPEventConfig(POPEventConfig));
        }
        /// <summary>
        /// 修改围术期事件配置
        /// </summary>
        /// <param name="POPEventConfig">围术期事件配置</param>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<bool> UpdatePOPEventConfig(MED_PERIOPERATIVE_EVENT_CONFIG POPEventConfig)
        {
            return Success(_pacuPOPEventService.UpdatePOPEventConfig(POPEventConfig));
        }
        /// <summary>
        /// 删除围术期事件配置
        /// </summary>
        /// <param name="EVENT_ID">围术期事件配置ID</param>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpGet]
        public RequestResult<bool> DeletePOPEventConfig(string EVENT_ID)
        {
            return Success(_pacuPOPEventService.DeletePOPEventConfig(EVENT_ID));
        }
        /// <summary>
        /// 获取围术期事件配置
        /// </summary>
        /// <param name="EVENT_ID">围术期事件配置ID</param>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpGet]
        public RequestResult<MED_PERIOPERATIVE_EVENT_CONFIG> GetPOPEventConfig(string EVENT_ID)
        {
            return Success(_pacuPOPEventService.GetPOPEventConfig(EVENT_ID));
        }
        /// <summary>
        /// 获取围术期事件配置列表(分页)
        /// </summary>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns><![CDATA[RequestResult<PagedList<MED_PERIOPERATIVE_EVENT_CONFIG>>]]></returns>
        [HttpGet]
        public Domain.RequestResult.RequestPageResult<List<MED_PERIOPERATIVE_EVENT_CONFIG>> GetPOPEventConfigList(int pageIndex, int pageSize)
        {

            List<MED_PERIOPERATIVE_EVENT_CONFIG> list = _pacuPOPEventService.GetPOPEventConfigList();

            List<MED_PERIOPERATIVE_EVENT_CONFIG> pageList = list;
            //分页处理
            if (list.Count > pageSize)
            {

                pageList = pageList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }

            return PageSuccess(pageList, pageSize, pageIndex, list.Count);

        }
        /// <summary>
        /// 获取围术期事件配置列表(不分页)
        /// </summary>
        /// <returns><![CDATA[RequestResult<IEnumerable<MED_PERIOPERATIVE_EVENT_CONFIG>>]]></returns>
        [HttpGet]
        public RequestResult<List<MED_PERIOPERATIVE_EVENT_CONFIG>> GetPOPEventConfigs()
        {
            return Success(_pacuPOPEventService.GetPOPEventConfigs());
        }
        /// <summary>
        /// 为客户端（手术端、观摩端）获取围术期事件配置列表
        /// </summary>
        /// <returns><![CDATA[RequestResult<IEnumerable<MED_PERIOPERATIVE_EVENT_CONFIG>>]]></returns>
        [HttpGet]
        public RequestResult<List<MED_PERIOPERATIVE_EVENT_CONFIG>> GetPOPEventConfigsForClient()
        {
            return Success(_pacuPOPEventService.GetPOPEventConfigs().FindAll(d => d.IFSHOWINCLIENT == "1").OrderBy(p => p.DISPLAY_ORDER).ToList());
        }
        #endregion

        #region 围术期事件索引相关方法

        /// <summary>
        /// 新增围术期事件索引
        /// </summary>
        /// <param name="POPEventIndex">围术期事件索引</param>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<bool> AddPOPEventIndex(MED_PERIOPERATIVE_EVENT_INDEX POPEventIndex)
        {
            return Success(_pacuPOPEventService.AddPOPEventIndex(POPEventIndex));
        }
        /// <summary>
        /// 修改围术期事件索引
        /// </summary>
        /// <param name="POPEventIndex">围术期事件索引</param>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<bool> UpdatePOPEventIndex(MED_PERIOPERATIVE_EVENT_INDEX POPEventIndex)
        {
            return Success(_pacuPOPEventService.UpdatePOPEventIndex(POPEventIndex));
        }

        /// <summary>
        /// 删除围术期事件索引
        /// </summary>
        /// <param name="INDEX_ID">围术期事件索引ID</param>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpGet]
        public RequestResult<bool> DeletePOPEventIndex(string INDEX_ID)
        {
            return Success(_pacuPOPEventService.DeletePOPEventIndex(INDEX_ID));
        }
        /// <summary>
        /// 获取围术期事件索引
        /// </summary>
        /// <param name="INDEX_ID">围术期事件索引ID</param>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpGet]
        public RequestResult<MED_PERIOPERATIVE_EVENT_INDEX> GetPOPEventIndex(string INDEX_ID)
        {
            return Success(_pacuPOPEventService.GetPOPEventIndex(INDEX_ID));
        }
        /// <summary>
        /// 获取围术期事件索引列表(分页)
        /// </summary>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns><![CDATA[RequestResult<PagedList<MED_PERIOPERATIVE_EVENT_INDEX>>]]></returns>
        [HttpGet]
        public Domain.RequestResult.RequestPageResult<List<MED_PERIOPERATIVE_EVENT_INDEX>> GetPOPEventIndexList(int pageIndex, int pageSize)
        {
            List<MED_PERIOPERATIVE_EVENT_INDEX> list = _pacuPOPEventService.GetPOPEventIndexList();

            List<MED_PERIOPERATIVE_EVENT_INDEX> pageList = list;

            //分页处理
            if (list.Count > pageSize)
            {
                pageList = pageList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }

            return PageSuccess(pageList, pageSize, pageIndex, list.Count);
        }
        /// <summary>
        /// 获取围术期事件索引列表(不分页)
        /// </summary>
        /// <param name="PATIENT_ID">患者住院号 可传null</param>
        /// <param name="VISIT_ID">住院次数 可传null</param>
        /// <param name="OPER_ID">手术次数 可传null</param>
        /// <returns><![CDATA[RequestResult<IEnumerable<MED_PERIOPERATIVE_EVENT_INDEX>>]]></returns>
        [HttpGet]
        public RequestResult<List<MED_PERIOPERATIVE_EVENT_INDEX>> GetPOPEventIndexs(string PATIENT_ID, string VISIT_ID, int? OPER_ID)
        {
            return Success(_pacuPOPEventService.GetPOPEventIndexList().FindAll(d => (d.PATIENT_ID == PATIENT_ID || PATIENT_ID == "")
            && (d.VISIT_ID == VISIT_ID || VISIT_ID == "") && (d.OPER_ID == OPER_ID.Value || OPER_ID == null)));
        }
        /// <summary>
        /// 获取围术期事件索引列表(不分页)
        /// </summary>
        /// <param name="PATIENT_ID">患者住院号 可传null</param>
        /// <param name="VISIT_ID">住院次数 可传null</param>
        /// <param name="OPER_ID">手术次数 可传null</param>
        /// <param name="EVENT_ID">事件ID 可传null</param>
        /// <returns><![CDATA[RequestResult<IEnumerable<MED_PERIOPERATIVE_EVENT_INDEX>>]]></returns>
        [HttpGet]
        public RequestResult<List<MED_PERIOPERATIVE_EVENT_INDEX>> GetPOPEventIndexs(string PATIENT_ID, string VISIT_ID, int? OPER_ID, string EVENT_ID)
        {
            return Success(_pacuPOPEventService.GetPOPEventIndexList().FindAll(d => (d.PATIENT_ID == PATIENT_ID || PATIENT_ID == "")
            && (d.VISIT_ID == VISIT_ID || VISIT_ID == "") && (d.OPER_ID == OPER_ID.Value || OPER_ID == null) && d.EVENT_ID == EVENT_ID));
        }

        #endregion

    }
}
