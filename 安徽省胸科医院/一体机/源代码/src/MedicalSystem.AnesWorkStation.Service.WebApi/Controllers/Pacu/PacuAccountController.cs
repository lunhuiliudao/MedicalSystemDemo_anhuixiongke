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
    /// 账户
    /// </summary>
    public class PacuAccountController : BaseController
    {
        IPacuAccountService _accountService;

        public PacuAccountController(IPacuAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="passWord">密码</param>
        /// <returns><![CDATA[RequestResult<MED_USERS>]]></returns>
        [HttpGet]
        public RequestResult<MED_USERS> Login(string loginName, string passWord)
        {

            MED_USERS User = _accountService.Login(loginName, passWord);

            return Success(User);
        }

        [HttpGet]
        public RequestResult<DateTime> GetServerTime()
        {
            return Success(DateTime.Now);
        }


        /// <summary>
        /// 获取登录用户的权限
        /// </summary>
        /// <param name="appID">程序ID</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        /// <returns><![CDATA[RequestResult<MED_USERS>]]></returns>        
        [HttpGet]
        public RequestResult<List<MED_PERMISSIONS>> GetPermission(string appID, string loginName)
        {
            List<MED_PERMISSIONS> list = _accountService.GetPermission(appID, loginName);

            return Success(list);
        }

    }
}