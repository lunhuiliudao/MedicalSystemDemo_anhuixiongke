using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dapper.Data;
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    [ControllerGroup("公共模块", "接口")]
    public class PlatformCommonController : PlatformBaseController
    {
        IPlatformCommonService _common;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="common"></param>
        public PlatformCommonController(IPlatformCommonService common)
        {
            _common = common;
        }

        /// <summary>
        /// 测试网络连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<bool> TestNet()
        {
            return Success(_common.TestNet());
        }

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<bool> TestDbConn()
        {
            try
            {
                return Success(_common.TestDbConn());
            }
            catch (Exception ex)
            {
                return Failed<bool>(ex.Message);
            }
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="name">字典名称</param>
        /// <param name="inputContent">输入内容</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetDictList(string name, string inputContent)
        {
            return Success<dynamic>(_common.GetDictList(name, inputContent));
        }

        /// <summary>
        /// 获取麻醉术语字典
        /// </summary>
        /// <param name="ItemClass">类型</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_ANESTHESIA_INPUT_DICT>> GetAnesInputDictByClass(string ItemClass)
        {
            return Success(_common.GetAnesInputDictByClass(ItemClass));
        }

        /// <summary>
        /// 给药途径字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_ADMINISTRATION_DICT>> GetAdministrationDict()
        {
            return Success(_common.GetAdministrationDict());
        }

        /// <summary>
        /// 获取医生护士人员字典
        /// </summary>
        /// <param name="UserJob">用户角色</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_HIS_USERS>> GetMedHisUserDict(string UserJob)
        {
            return Success(_common.GetMedHisUserDict(UserJob));
        }

    }
}