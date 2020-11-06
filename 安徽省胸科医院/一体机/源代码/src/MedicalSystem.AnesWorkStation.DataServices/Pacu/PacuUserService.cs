
using System;
using System.Collections.Generic;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.Services;
using MedicalSystem.Common.SecretManage;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuUserService
    {
        List<MED_USERS> GetUserList(string deptCode, string loginName
             , string userName);

        List<MED_USERS> GetUserPagedList(string deptCode, string loginName
                    , string userName, int pageIndex, int pageSize);

        MED_USERS GetUser(string userID);

        int SaveUser(MED_USERS item);

        bool DeleteUser(MED_USERS item);

        List<MED_USER_MESSAGES> GetUserMessage(MED_USERS item);

        bool SaveUserMessage(MED_USER_MESSAGES item);

        List<MED_USER_NOTE> GetUserNote(MED_USERS item);

        bool SaveUseNote(MED_USER_NOTE item);

    }


    public class PacuUserService : BaseService<PacuUserService>, IPacuUserService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuUserService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuUserService(IDapperContext context)
            : base(context)
        {
        }

        public List<MED_USERS> GetUserList(string deptCode, string loginName
                 , string userName)
        {
            List<MED_USERS> data = dapper.Set<MED_USERS>().Select(x => (x.USER_DEPT_CODE == deptCode || deptCode == "")
           && (x.LOGIN_NAME == loginName || loginName == "") && (x.USER_NAME == userName || userName == ""));
            return data;
        }

        public List<MED_USERS> GetUserPagedList(string deptCode, string loginName
                    , string userName, int pageIndex, int pageSize)
        {
            List<MED_USERS> data = dapper.Set<MED_USERS>().Select();
            return data;
            ;
        }

        public MED_USERS GetUser(string userID)
        {
            MED_USERS data = dapper.Set<MED_USERS>().Single(x => x.USER_ID = userID);
            return data;
        }

        public int SaveUser(MED_USERS item)
        {
            int result = dapper.Set<MED_USERS>().Save(item) == true ? 1 : 0;
            dapper.SaveChanges();
            return result;
        }

        public bool DeleteUser(MED_USERS item)
        {
            bool result = dapper.Set<MED_USERS>().Delete(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_USER_MESSAGES> GetUserMessage(MED_USERS item)
        {

            List<MED_USER_MESSAGES> list = dapper.Set<MED_USER_MESSAGES>().Select(x => x.RECEIVE_USER_ID == item.USER_JOB_ID || x.RECEIVE_DEPT_CODE == item.USER_DEPT_CODE);

            if (list == null)
            {
                list = new List<MED_USER_MESSAGES>();
            }

            // 按角色查询
            List<MED_USERS_ROLES> userRoles = dapper.Set<MED_USERS_ROLES>().Select(x => x.USER_ID == item.USER_ID);
            if (userRoles != null)
            {
                userRoles.ForEach(role =>
                {
                    var tmp = dapper.Set<MED_USER_MESSAGES>().Select(x => x.RECEIVE_ROLE_ID == role.ROLE_ID);
                    if (tmp != null)
                    {
                        list.AddRange(tmp);
                    }
                });
            }
            return list;
        }


        public bool SaveUserMessage(MED_USER_MESSAGES item)
        {
            bool result = dapper.Set<MED_USER_MESSAGES>().Save(item);
            dapper.SaveChanges();
            return result;
        }

        public List<MED_USER_NOTE> GetUserNote(MED_USERS item)
        {

            List<MED_USER_NOTE> list = dapper.Set<MED_USER_NOTE>().Select(x => x.USER_ID == item.USER_ID || x.DEPT_CODE == item.USER_DEPT_CODE);
            return list;
        }

        public bool SaveUseNote(MED_USER_NOTE item)
        {
            bool result = dapper.Set<MED_USER_NOTE>().Save(item);
            dapper.SaveChanges();
            return result;
        }

    }
}
