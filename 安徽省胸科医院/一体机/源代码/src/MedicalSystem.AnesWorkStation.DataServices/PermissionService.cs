using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 用户权限字典
    /// </summary>
    public interface IPermissionService
    {
        List<MED_PERMISSION_LOGINNAME> GetPermissionByUserName(string appID, string loginName);
    }

    /// <summary>
    /// 用户权限服务
    /// </summary>
    public class PermissionService : BaseService<PermissionService>, IPermissionService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PermissionService()
            : base() { }

        public PermissionService(IDapperContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 根据ID获取权限信息
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_PERMISSION_LOGINNAME> GetPermissionByUserName(string appID, string loginName)
        {
            throw new NotSupportedException();
        }
    }
}
