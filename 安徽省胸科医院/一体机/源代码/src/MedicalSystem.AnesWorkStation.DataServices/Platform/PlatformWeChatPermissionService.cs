using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices.WebApi;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using System.IO;
using MedicalSystem.Common.FileManage;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformWeChatPermissionService
    {

        /// <summary>
        /// 获取用户表
        /// </summary>
        /// <returns></returns>
        dynamic GetWeChatUsers(string hospitalId);

        /// <summary>
        /// 获取权限表
        /// </summary>
        /// <returns></returns>
        dynamic GetWeChatPermissions(string permissionId);

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userCheckList"></param>
        /// <returns></returns>
        dynamic GetWeChatUserPermissions(object userCheckList);

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="userCheckList"></param>
        /// <param name="roleCheckList"></param>
        /// <param name="menuCheckList"></param>
        /// <returns></returns>
        int SaveWeChatUsersPermission(object userCheckList, object roleCheckList, object menuCheckList);

    }
    public class PlatformWeChatPermissionService : BaseService<PlatformAnesQueryService>, IPlatformWeChatPermissionService
    {
        protected PlatformWeChatPermissionService()
            : base() { }
        public PlatformWeChatPermissionService(IDapperContext context)
            : base(context)
        {

        }

        /// <summary>
        /// 根据医院ID获取用户数据
        /// </summary>
        /// <param name="hospitalId">医院ID</param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetWeChatUsers(string hospitalId)
        {


            if (!string.IsNullOrEmpty(hospitalId))
            {
                string sql = sqlDict.GetSQLByKey("GetWeChatUsers");

                try
                {
                    return dapper.Set<MED_WECHAT_USERS>().Query(sql, new { HOSPITAL_ID = hospitalId }).OrderBy(t => t.USER_JOB_ID);
                }
                catch (Exception ex)
                {
                    Logger.Error("根据医院ID获取用户数据GetWeChatUsers", ex);
                    return null;
                }
            }
            else
            {
                string sql = sqlDict.GetSQLByKey("GetWeChatUsersNoParam");

                try
                {
                    return dapper.Set<MED_WECHAT_USERS>().Query(sql).OrderBy(t => t.USER_JOB_ID);
                }
                catch (Exception ex)
                {
                    Logger.Error("根据医院ID获取用户数据GetWeChatUsers", ex);
                    return null;
                }
            }

        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userCheckList"></param>
        /// <returns></returns>
        public dynamic GetWeChatUserPermissions(object userCheckList)
        {

            List<MED_WECHAT_PERMISSIONS> permissionList = new List<MED_WECHAT_PERMISSIONS>();

            try
            {
                string objUserValue = JsonConvert.SerializeObject(GetWeChatUsers(""));

                List<MED_WECHAT_USERS> weChatUsers = JsonConvert.DeserializeObject<List<MED_WECHAT_USERS>>(objUserValue);

                string objPermissionValue = JsonConvert.SerializeObject(GetWeChatPermissions(""));

                List<MED_WECHAT_PERMISSIONS> weChatUserPermissions = JsonConvert.DeserializeObject<List<MED_WECHAT_PERMISSIONS>>(objPermissionValue);

                if (userCheckList != null)
                {
                    string[] userList = JsonConvert.DeserializeObject<string[]>(userCheckList.ToString());


                    foreach (var item in userList)
                    {
                        MED_WECHAT_USERS weChatUser = weChatUsers.Find(t => t.USER_JOB_ID == item);

                        if (weChatUser != null)
                        {
                            MED_WECHAT_PERMISSIONS weChatUserPermission = weChatUserPermissions.Find(t => t.PERMISSION_ID == weChatUser.PERMISSION_ID);

                            permissionList.Add(weChatUserPermission);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("获取用户权限GetWeChatUserPermissions:", ex);
            }
            return permissionList;
        }

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="permissionId">权限ID</param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetWeChatPermissions(string permissionId)
        {


            if (!string.IsNullOrEmpty(permissionId))
            {
                string sql = sqlDict.GetSQLByKey("GetWeChatPermissions");

                try
                {
                    return dapper.Set<MED_WECHAT_PERMISSIONS>().Query(sql, new { PERMISSION_ID = permissionId }).OrderBy(t => t.ROLE_NAME);
                }
                catch (Exception ex)
                {
                    Logger.Error("获取权限GetWeChatPermissions:", ex);
                    return null;
                }
            }
            else
            {
                string sql = sqlDict.GetSQLByKey("GetWeChatPermissionsNoParam");
                try
                {
                    return dapper.Set<MED_WECHAT_PERMISSIONS>().Query(sql).OrderBy(t => t.ROLE_NAME);
                }
                catch (Exception ex)
                {
                    Logger.Error("获取权限GetWeChatPermissions:", ex);
                    return null;
                }
            }

        }

        /// <summary>
        /// 保存用户数据
        /// </summary>
        /// <param name="userCheckList"></param>
        /// <param name="roleCheckList"></param>
        /// <param name="menuCheckList"></param>
        /// <returns></returns>
        public int SaveWeChatUsersPermission(object userCheckList, object roleCheckList, object menuCheckList)
        {
            int result = 0;

            try
            {
                string objValue = JsonConvert.SerializeObject(GetWeChatUsers(""));

                List<MED_WECHAT_USERS> weChatUsersList = JsonConvert.DeserializeObject<List<MED_WECHAT_USERS>>(objValue);

                string[] userList = JsonConvert.DeserializeObject<string[]>(userCheckList.ToString());

                string[] roleList = JsonConvert.DeserializeObject<string[]>(roleCheckList.ToString());

                string[] menuList = JsonConvert.DeserializeObject<string[]>(menuCheckList.ToString());




                string objPermissionValue = JsonConvert.SerializeObject(GetWeChatPermissions(""));

                List<MED_WECHAT_PERMISSIONS> weChatPermissionsList = JsonConvert.DeserializeObject<List<MED_WECHAT_PERMISSIONS>>(objPermissionValue);


                foreach (string userStr in userList)
                {
                    MED_WECHAT_USERS weChatUser = weChatUsersList.Find(t => t.USER_JOB_ID == userStr);

                    if (weChatUser != null)
                    {
                        MED_WECHAT_PERMISSIONS weChatPermission = weChatPermissionsList.Find(t => t.PERMISSION_ID == weChatUser.PERMISSION_ID);

                        if (weChatPermission != null)
                        {
                            // 已有权限

                            weChatPermission.ROLE_NAME = JsonConvert.SerializeObject(roleList);

                            weChatPermission.PLAT_NAME = "麻醉微信公众号";

                            weChatPermission.PERMISSION_NAME = JsonConvert.SerializeObject(menuList);

                            result = dapper.Set<MED_WECHAT_PERMISSIONS>().Update(weChatPermission) > 0 ? 1 : 0;

                        }
                        else
                        {


                            // 还没有建立权限

                            MED_WECHAT_PERMISSIONS weChatPermissionInsert = new MED_WECHAT_PERMISSIONS();

                            //保证GUID 唯一 
                            do//先执行一次，再判断。  
                            {
                                weChatPermissionInsert.PERMISSION_ID = Guid.NewGuid().ToString();
                            }
                            while (dapper.Set<MED_WECHAT_PERMISSIONS>().Single(d => d.PERMISSION_ID == weChatPermissionInsert.PERMISSION_ID) != null);

                            weChatPermissionInsert.ROLE_NAME = JsonConvert.SerializeObject(roleList);

                            weChatPermissionInsert.PLAT_NAME = "麻醉微信公众号";

                            weChatPermissionInsert.PERMISSION_NAME = JsonConvert.SerializeObject(menuList);

                            int count = dapper.Set<MED_WECHAT_PERMISSIONS>().Insert(weChatPermissionInsert) ? 1 : 0;

                            if (count == 1)
                            {
                                //更新用户表 权限ID
                                weChatUser.PERMISSION_ID = weChatPermissionInsert.PERMISSION_ID;

                                result = dapper.Set<MED_WECHAT_USERS>().Update(weChatUser) > 0 ? 1 : 0;
                            }
                        }
                    }
                }

                dapper.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("保存用户数据SaveWeChatUsersPermission:", ex);
            }
            return result;
        }

    }
}
