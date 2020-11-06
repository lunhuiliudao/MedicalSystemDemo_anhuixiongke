using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    public class AccountController : BaseController
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
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
    }
}