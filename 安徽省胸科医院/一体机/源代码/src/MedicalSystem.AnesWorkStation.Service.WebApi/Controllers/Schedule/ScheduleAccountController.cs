using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Schedule
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    public class ScheduleAccountController : ScheduleBaseController
    {
        IScheduleAccountService _accountService;
        public ScheduleAccountController(IScheduleAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="passWord">密码</param>
        /// <returns><![CDATA[RequestResult<MED_USERS>]]></returns>
        [HttpPost]
        public RequestResult<MED_USERS> Login(dynamic data)
        {
            string loginName = data.loginName;
            string passWord = data.passWord;
            MED_USERS User = _accountService.Login(loginName, passWord);
            if (User == null)
            {
                return Failed<MED_USERS>("用户名或者密码错误");
            }
            else
            {
                if (User.IS_VALID.ToUpper() != "T")
                {
                    return Failed<MED_USERS>("该用户名未启用");
                }
                else
                {
                    //var p = Permission.DataServices.PermissionService.ClientInstance.GetAppPermission("OperSchedule", User.USER_ID);
                    
                    return Success(User,"");
                }
            }
        }

    }
}