using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystem.AnesWorkStation.Service.WebApi
{
    /// <summary>
    /// 权限要求
    /// </summary>
    public enum RequestAuthority
    {
        /// <summary>
        /// 允许匿名访问
        /// </summary>
        AllowAnonymous = 1,
        /// <summary>
        /// 身份验证但不授权检查
        /// </summary>
        AuthenticateNotAuthorize, 
    }
}