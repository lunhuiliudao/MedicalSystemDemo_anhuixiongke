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
    /// 协同
    /// </summary>
    public class PacuCoordinationController : BaseController
    {

        IPacuCoordinationService _pacuCoordinationService;

        public PacuCoordinationController(IPacuCoordinationService pacuCoordinationService)
        {
            _pacuCoordinationService = pacuCoordinationService;
        }

        #region IPacuCoordinationService 成员

        /// <summary>
        /// 获取客户端列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_CLIENT_COMPUTER>> GetClientComputerList()
        {
            return Success(_pacuCoordinationService.GetClientComputerList());
        }

        /// <summary>
        /// 获取消息模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_MESSAGE_TEMPLET>> GetMessageTempletList()
        {
            return Success(_pacuCoordinationService.GetMessageTempletList());
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<bool> SendMessage(MED_MESSAGE_LOG item)
        {
            bool flag = false;
            lock (PacuCoordinationService.SerialNoLock)
            {
                item.MESSAGE_ID = _pacuCoordinationService.GetCurrentMessageID();
                item.SEND_TIME = DateTime.Now;
                item.RECEIVE_CONFIRM = 0;
                flag = _pacuCoordinationService.AddMessageLog(item);
                if (flag)
                {
                    _pacuCoordinationService.MoveToNextMessageID();
                }
            }
            return Success(flag);
        }

        /// <summary>
        /// 获取消息列表
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<MED_MESSAGE_LOG>> GetMessageList(string client_id)
        {
            return Success(_pacuCoordinationService.GetMessageList(client_id));
        }

        public RequestResult<List<MED_MESSAGE_LOG>> GetMessageListByID(string clientID)
        {
            return Success(_pacuCoordinationService.GetMessageListByID(clientID));
        }
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<bool> ReceiveMessage(List<MED_MESSAGE_LOG> item)
        {
            return Success(_pacuCoordinationService.SaveMessageLog(item));
        }

        public RequestResult<bool> SaveCoordination(dynamic item)
        {
            return Success(_pacuCoordinationService.SaveCoordination(item));
        }
        #endregion
    }
}