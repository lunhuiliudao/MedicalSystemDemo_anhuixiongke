using System;
using System.Linq;
using System.Text;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformAccountService
    {
        MED_USERS Login(string LoginName, string PassWord);
        int ChangePwd(MED_USERS user);
        MED_USERS GetUserByUserJobId(string userJobId);
        MED_USERS LoginFor5(string LoginName, string PassWord);
        List<string> GetPermissionsFor5(string userid);
    }

    /// <summary>
    /// 账号类
    /// </summary>
    public class PlatformAccountService : BaseService<PlatformAccountService>, IPlatformAccountService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PlatformAccountService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PlatformAccountService(IDapperContext context)
            : base(context) { }

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

        public MED_USERS Login(string LoginName, string PassWord)
        {
            string sql = sqlDict.GetSQLByKey("LoginAcount");
            var list = dapper.Set<MED_USERS>().Query(sql, new { LoginName = LoginName, LoginPwd = Encrypto(PassWord) });
            MED_USERS user = list.Count() > 0 ? list[0] : null;
            return user;
        }

        public int ChangePwd(MED_USERS user)
        {
            string tempOldPwd = Encrypto(user.OLD_LOGIN_PWD);
            MED_USERS midUser = dapper.Set<MED_USERS>().Single(x => x.LOGIN_NAME == user.LOGIN_NAME && x.LOGIN_PWD == tempOldPwd);
            if (midUser == null)
            {
                return 2; //原始密码输入错误
            }
            else
            {
                user.LOGIN_PWD = Encrypto(user.LOGIN_PWD);
                int updateCount = dapper.Set<MED_USERS>().Update(user, p => new { p.LOGIN_PWD });
                dapper.SaveChanges();
                if (updateCount > 0)
                {
                    return 1; //修改密码成功
                }
                else
                {
                    return 0;
                }
            }
        }

        public MED_USERS GetUserByUserJobId(string userJobId)
        {
            string sql = sqlDict.GetSQLByKey("GetUserByUserJobId");
            var list = dapper.Set<MED_USERS>().Query(sql, new { USER_JOB_ID = userJobId });
            MED_USERS user = list.Count() > 0 ? list[0] : null;
            return user;
        }

        public MED_USERS LoginFor5(string LoginName, string PassWord)
        {
            DapperContext context = new DapperContext("docareConnString5.0");
            string sql = @"SELECT U.USER_ID,
                           U.USER_ID,
                           U.LOGIN_NAME,
                           U.USER_NAME,
                           U.IS_VALID,
                           NVL(D.DEPT_NAME, U.DEPT_ID) AS DEPT_NAME,
                           B.USER_JOB
                      FROM MED_USERS U
                      LEFT JOIN MED_HIS_USERS B ON U.USER_ID = B.USER_ID
                      LEFT JOIN MED_DEPT_DICT D
                        ON U.DEPT_ID = D.DEPT_CODE WHERE U.LOGIN_NAME = :LoginName AND U.LOGIN_PWD =:LoginPwd";
            var list = context.Set<MED_USERS>().Query(sql, new { LoginName = LoginName, LoginPwd = Encrypto(PassWord) });
            MED_USERS user = list.Count() > 0 ? list[0] : null;
            return user;
        }

        public List<string> GetPermissionsFor5(string userid)
        {
            DapperContext context = new DapperContext("docareConnString5.0");
            string sql = @"SELECT DISTINCT T4.PERMISSION_KEY FROM MED_ROLES_PERMISSIONS T3 INNER JOIN MED_USERS_ROLES 
                            T1 ON T3.ROLE_ID=T1.ROLE_ID AND T1.USER_ID=:userid INNER JOIN MED_PERMISSIONS T4 ON T3.PERMISSION_ID=T4.PERMISSION_KEY";
            return context.Set<string>().Query(sql, new { userid });
        }
    }
}
