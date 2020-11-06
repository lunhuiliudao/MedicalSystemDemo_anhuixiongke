using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// CA签名
    /// </summary>
    public class PlatformCASignedController : PlatformBaseController
    {
        IPlatformCASignedService CASignedService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="CASignedServiceParam"></param>
        public PlatformCASignedController(IPlatformCASignedService CASignedServiceParam)
        {
            CASignedService = CASignedServiceParam;
        }

        /// <summary>
        /// 获取签名数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="operId"></param>
        /// <param name="signDocName"></param>
        /// <param name="controlId"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_BJCA_SIGN>> QuerySignData(string patientId, decimal visitId, decimal operId, string signDocName, string controlId)
        {
            return Success(CASignedService.QuerySignData(patientId, visitId, operId, signDocName, controlId));
        }


        /// <summary>
        /// 保存签名数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveSignData(dynamic obj)
        {
            string patientId = obj.patientId;

            decimal visitId = obj.visitId;

            decimal operId = obj.operId;

            string signDocName = obj.signDocName;

            string signName = obj.signName;

            string controlId = obj.controlId;

            string signImage = obj.signImage;

            return Success(CASignedService.SaveSignData(patientId, visitId, operId, signDocName, signName, controlId, signImage));
        }


        /// <summary>
        /// 删除签名数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeleteSignData(dynamic obj)
        {
            string patientId = obj.patientId;

            decimal visitId = obj.visitId;

            decimal operId = obj.operId;

            string signDocName = obj.signDocName;

            string controlId = obj.controlId;


            return Success(CASignedService.DeleteSignData(patientId, visitId, operId, signDocName, controlId));
        }
    }
}