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
    public class PacuPermissionController : BaseController
    {
        IPacuPermissionService _permissionDataService = null;
        public PacuPermissionController(IPacuPermissionService permissionDataService)
        {
            _permissionDataService = permissionDataService;
        }
        [HttpGet]
        public RequestResult<List<MED_PERMISSION_LOGINNAME>> GetUserByUserName(string appID, string loginName)
        {
            return Success(_permissionDataService.GetUserByUserName(appID, loginName));
        }
    }
}