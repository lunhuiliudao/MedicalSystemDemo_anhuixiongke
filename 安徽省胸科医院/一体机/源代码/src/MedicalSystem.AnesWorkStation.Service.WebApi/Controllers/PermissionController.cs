using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    public class PermissionController : BaseController
    {
        IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// 根据ID获取权限信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_PERMISSION_LOGINNAME>> GetPermissionByUserName(string appID, string loginName)
        {
            return Success(_permissionService.GetPermissionByUserName(appID, loginName));
        }

    }
}