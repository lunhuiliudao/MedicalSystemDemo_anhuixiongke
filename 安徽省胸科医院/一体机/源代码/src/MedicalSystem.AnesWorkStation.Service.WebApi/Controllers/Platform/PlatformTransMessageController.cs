
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 消息平台
    /// </summary>
    public class PlatformTransMessageController : PlatformBaseController
    {
        /// <summary>
        /// 小麦助手登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> TransMsgLogin(MED_USERS user)
        {
            string transmsgInfo = string.Empty;
            TransMessageManager tmm = null;
            if (HttpContext.Current.Application[user.LOGIN_NAME] == null)
            {
                tmm = new TransMessageManager(user);
                tmm.OpenConnection();
                HttpContext.Current.Application[user.LOGIN_NAME] = tmm;
            }
            else
            {
                tmm = HttpContext.Current.Application[user.LOGIN_NAME] as TransMessageManager;
            }
            transmsgInfo = JsonConvert.SerializeObject(tmm.ChildLoginModel).Replace("\"", "\"\"\"");
            return Success(transmsgInfo);
        }

        /// <summary>
        /// 心跳监测
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<Boolean> SendHeartBeatMessage(MED_USERS user)
        {
            string transmsgInfo = string.Empty;
            TransMessageManager tmm = null;
            if (HttpContext.Current.Application[user.LOGIN_NAME] == null)
            {
                tmm = new TransMessageManager(user);
                tmm.OpenConnection();
                HttpContext.Current.Application[user.LOGIN_NAME] = tmm;
            }
            else
            {
                tmm = HttpContext.Current.Application[user.LOGIN_NAME] as TransMessageManager;
            }
            tmm.SendHeartBeatMessage();
            return Success(tmm.GetHasReadMsg());
        }

    }
}
