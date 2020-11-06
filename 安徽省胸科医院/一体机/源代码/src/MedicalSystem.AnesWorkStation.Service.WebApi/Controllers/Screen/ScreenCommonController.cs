

using System.Collections.Generic;
using System.Web.Http;
using System.Data;
using System.Configuration;
using System;
using MedicalSystem.AnesWorkStation.Service.WebApi.Controllers;
using MedicalSystem.AnesWorkStation.Domain.Screen;
using MedicalSystem.AnesWorkStation.DataServices;

namespace MedicalSystem.AnesIcuQuery.WebApi.Controllers
{
    /// <summary>
    /// 常用请求
    /// </summary>
    public class ScreenCommonController : BaseApiController

    {

        IScreenCommonService bc;
        public ScreenCommonController(IScreenCommonService accountService)
        {
            bc = accountService;
        }
        #region 测试网络


        /// <summary>
        /// 测试网络
        /// </summary>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public ApiResult<bool> TestNet()
        {
            return Success(true);
        }

        #endregion

        #region 获取手术室配置

        /// <summary>
        /// 获取手术室配置
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ApiResult<string> GetOperationRoom()
        {
            return Success(ConfigurationManager.AppSettings["OperationRoom"] ?? "");
        }

        #endregion

        #region 麻醉数据库版本

        /// <summary>
        /// 麻醉数据库版本
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ApiResult<string> GetAnesVersion()
        {
            return Success(ConfigurationManager.AppSettings["AnesVersion"] ?? "");
        }

        /// <summary>
        /// 1台麻醉是否多台手术
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ApiResult<string> GetOneAnesIsMoreOperation()
        {
            return Success(ConfigurationManager.AppSettings["OneAnesIsMoreOperation"] ?? "");
        }


        #endregion

        /// <summary>
        /// 麻醉医生科室代码
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ApiResult<string> GetAnesthesiaWardCode()
        {
            return Success(ConfigurationManager.AppSettings["AnesthesiaWardCode"] ?? "");
        }
        /// <summary>
        /// 手术医生科室代码
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ApiResult<string> GetOperDoctorWardCode()
        {
            return Success(ConfigurationManager.AppSettings["OperDoctorWardCode"] ?? "");
        }
        /// <summary>
        /// 手术护士科室代码
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ApiResult<string> GetOperNurseWardCode()
        {
            return Success(ConfigurationManager.AppSettings["OperNurseWardCode"] ?? "");
        }



        [HttpPost, HttpGet]
        public ApiResult<DateTime> GetServerDateTime()
        {
            return Success(bc.GetServerDateTime());
        }

        [HttpPost, HttpGet]
        public ApiResult<DataResult> GetTodayInfo([FromBody]QueryParams queryParams)
        {
            return Success(bc.GetTodayInfo(queryParams));
        }

    }
}
