using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Data;
using MedicalSystem.DataServices.WebApi;
using MedicalSystem.AnesWorkStation.Domain;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 账号接口
    /// </summary>
    public interface IAccountService
    {
        MED_USERS Login(string LoginName, string PassWord);
        bool ChangePwd(string LoginName, string oldPwd, string newPwd);

    }

    /// <summary>
    /// 账号类
    /// </summary>
    public class AccountService : BaseService<AccountService>, IAccountService
    {
       
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected AccountService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public AccountService(IDapperContext context)
            : base(context)
        {
        }

        #region IAccountService 成员

        [HttpGet]
        public virtual MED_USERS Login(string LoginName, string PassWord)
        {
            MED_USERS user = dapper.Set<MED_USERS>().Select(x => x.LOGIN_NAME == LoginName && x.LOGIN_PWD == PassWord && x.IS_VALID == "t").FirstOrDefault();
            if (user == null)
                return null;
            else
            {
                return user;
            }
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
