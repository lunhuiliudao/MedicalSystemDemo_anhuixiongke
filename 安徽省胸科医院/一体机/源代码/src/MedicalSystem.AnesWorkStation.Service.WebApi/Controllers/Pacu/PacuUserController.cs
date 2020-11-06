
using MedicalSystem.AnesWorkStation.DataServices;

using MedicalSystem.AnesWorkStation.Service.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Http;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.AnesWorkStation.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Pacu
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class PacuUserController : BaseController
    {
        IPacuUserService _userService;

        public PacuUserController(IPacuUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 获取用户信息表
        /// </summary>
        /// <param name="deptCode">科室代码</param>
        /// <param name="loginName">登录名</param>
        /// <param name="userName">用户名</param>
        /// <returns><![CDATA[RequestResult<List<MED_USERS>>]]></returns>
        [HttpGet]
        public RequestResult<List<MED_USERS>> GetUserList(string deptCode, string loginName
            , string userName)
        {
            List<MED_USERS> list = _userService.GetUserList(deptCode, loginName, userName);
            return Success(list);
           
         //   return base.GetList<MED_USERS>(_userService, expression, a => a.Asc(o => o.USER_ID));
        }

        /// <summary>
        /// 获取用户信息表(分页)
        /// </summary>
        /// <param name="deptCode">科室代码</param>
        /// <param name="loginName">登录名</param>
        /// <param name="userName">用户名</param>
        /// <returns><![CDATA[RequestResult<PagedList<MED_USERS>>]]></returns>
        [HttpGet]
        public Domain.RequestResult.RequestPageResult<List<MED_USERS>> GetUserPagedList(string deptCode, string loginName
            , string userName, int pageIndex, int pageSize)
        {
            List<MED_USERS> list = _userService.GetUserPagedList(deptCode, loginName, userName, pageIndex, pageSize);

            List<MED_USERS> pageList = list;
            //分页处理
            if (list.Count > pageSize)
            {

                pageList = pageList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }

            return PageSuccess(pageList, pageSize, pageIndex, list.Count);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns><![CDATA[RequestResult<MED_USERS>]]></returns>
        [HttpGet]
        public RequestResult<MED_USERS> GetUser(string userID)
        {
            MED_USERS user = _userService.GetUser(userID);
            return Success(user);
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SaveUser(MED_USERS item)
        {
            int result = _userService.SaveUser(item);
            return Success(result);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<bool> DeleteUser(MED_USERS item)
        {
            return Success (_userService.DeleteUser(item));
        }

        #region 用户留言记录表 成员

        /// <summary>
        /// 获取自己的留言信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<List<MED_USER_MESSAGES>> GetUserMessage(MED_USERS item)
        {
            List<MED_USER_MESSAGES> list = _userService.GetUserMessage(item);
            return Success(list);
        }

        /// <summary>
        /// 保存用户留言
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<bool> SaveUserMessage(MED_USER_MESSAGES item)
        {
            if (item == null)
            {
                return Success(false);
            }

            item.CREATE_DATE = DateTime.Now;
            item.READ_STATE = 0;
            item.MSG_ID = Guid.NewGuid().ToString();

            bool flag =  _userService.SaveUserMessage(item);
            return Success(flag);
        }

        #endregion

        [HttpPost]
        public RequestResult<List<MED_USER_NOTE>> GetUserNote(MED_USERS item)
        {
            List<MED_USER_NOTE> list = _userService.GetUserNote(item);
             return Success(list);
        }
        [HttpPost]
        public RequestResult<bool> SaveUseNote(MED_USER_NOTE item)
        {
            if (item == null)
            {
                return Success(false);
            }
            bool flag = _userService.SaveUseNote(item);
            return Success(flag);
        }
    }
}