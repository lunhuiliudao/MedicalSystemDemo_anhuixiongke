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
    /// 配置方法类
    /// </summary>
    public class ConfigController : BaseController
    {
        IConfigService _config;
        public ConfigController(IConfigService config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取配置表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_HOSPITAL_CONFIG>> GetHosotalConfig()
        {
            return Success(_config.GetHosotalConfig());
        }

        /// <summary>
        /// 获取配置表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_CONFIG>> GetConfig()
        {
            return Success(_config.GetConfig());
        }

        /// <summary>
        /// 插入信息到配置表
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<bool> InsertConfig(MED_CONFIG mc)
        {
            return Success(_config.InsertConfig(mc));
        }
    }
}