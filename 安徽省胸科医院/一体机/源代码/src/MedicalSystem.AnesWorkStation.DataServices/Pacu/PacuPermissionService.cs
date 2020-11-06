using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{

    public interface IPacuPermissionService
    {
        List<MED_PERMISSION_LOGINNAME> GetUserByUserName(string appID, string loginName);
    }

    public class PacuPermissionService : BaseService<PacuPermissionService>, IPacuPermissionService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuPermissionService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuPermissionService(IDapperContext context)
            : base(context)
        {
        }

        public List<MED_PERMISSION_LOGINNAME> GetUserByUserName(string appID, string loginName)
        {
            string sqlText = @"SELECT PERMISSION_ID, APP_ID, PERMISSION_NAME, PERMISSION_KEY, SORT_ID, IS_VALID,MEMO ,LOGIN_NAME FROM 
                              (SELECT DISTINCT A.PERMISSION_ID, A.APP_ID, A.PERMISSION_NAME, A.PERMISSION_KEY, A.SORT_ID, A.IS_VALID,A.MEMO ,E.LOGIN_NAME FROM MED_PERMISSIONS A,MED_APPLICATIONS B,MED_ROLES_PERMISSIONS C,MED_USERS_ROLES D,MED_USERS E
                               WHERE A.APP_ID = B.APP_ID AND A.PERMISSION_ID = C.PERMISSION_ID AND D.ROLE_ID = C.ROLE_ID AND D.USER_ID = E.USER_ID   )";
            sqlText += "  WHERE  APP_ID ='" + appID + "' AND LOGIN_NAME = '" + loginName + "'";

            return dapper.Set<MED_PERMISSION_LOGINNAME>().Query(sqlText);
        }
    }
}
