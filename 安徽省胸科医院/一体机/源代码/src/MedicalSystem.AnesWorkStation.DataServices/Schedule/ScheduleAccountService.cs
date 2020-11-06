using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Data;
using MedicalSystem.DataServices.WebApi;
using MedicalSystem.AnesWorkStation.Domain;
using System.Security.Cryptography;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IScheduleAccountService
    {
        MED_USERS Login(string LoginName, string PassWord);
        bool ChangePwd(string LoginName, string oldPwd, string newPwd);
    }

    /// <summary>
    /// 账号类
    /// </summary>
    public class ScheduleAccountService : BaseService<ScheduleAccountService>, IScheduleAccountService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ScheduleAccountService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public ScheduleAccountService(IDapperContext context)
            : base(context)
        {
        }
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        private  string Encrypto(string Source)
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

        #region IAccountService 成员
        public virtual MED_USERS Login(string LoginName, string PassWord)
        {
            string sql = sqlDict.GetSQLByKey("LoginAcount");
            var list = dapper.Set<MED_USERS>().Query(sql, new { LoginName = LoginName, LoginPwd = Encrypto(PassWord) });
            MED_USERS user = list.Count() > 0 ? list[0] : null;
            return user;
        }

        [HttpGet]
        public virtual bool ChangePwd(string LoginName, string oldPwd, string newPwd)
        {
            MED_USERS user = dapper.Set<MED_USERS>()
                .Single(x => x.LOGIN_NAME == LoginName && x.LOGIN_PWD == oldPwd && x.IS_VALID == "t");
            if (user == null)
            {
                return false;
            }
            else
            {
                user.LOGIN_PWD = newPwd;
                dapper.Set<MED_USERS>().Update(user, p => new { p.LOGIN_PWD });
                dapper.SaveChanges();
                return true;
            }
        }

        #endregion
    }
}
