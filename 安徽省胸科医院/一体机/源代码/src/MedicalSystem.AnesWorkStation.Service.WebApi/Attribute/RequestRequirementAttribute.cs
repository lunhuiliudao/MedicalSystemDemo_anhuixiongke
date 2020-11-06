using MedicalSystem.Anes.Service.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Attribute
{
    /// <summary>
    /// 请求要求（默认允许匿名访问）
    /// </summary>
    public class RequestRequirementAttribute : System.Attribute
    {
        /// <summary>
        /// 请求要求
        /// </summary>
        public RequestAuthority Requirement
        {
            get
            {
                return __Requirement;
            }
        }
        private RequestAuthority __Requirement;
        /// <summary>
        /// 请求要求（默认允许匿名访问）
        /// </summary>
        /// <param name="_Requirement">默认允许匿名访问</param>
        public RequestRequirementAttribute(RequestAuthority _Requirement = RequestAuthority.AllowAnonymous)
        {
            __Requirement = _Requirement;
        }
    }
}