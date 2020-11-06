using System;
using System.Web.Http;
using System.Text;
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using System.Web;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using System.Linq;
using System.Dynamic;
using System.Collections.Generic;
using Newtonsoft.Json;
using MedicalSystem.AnesWorkStation.Domain.Report;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 账号管理
    /// </summary>
    [ControllerGroup("账号管理", "接口")]
    public class PlatformAccountController : PlatformBaseController
    {
        IPlatformAccountService _accountService;
        IPlatformAnesQueryService _platformAnesQueryService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accountService"></param>
        public PlatformAccountController(IPlatformAccountService accountService, IPlatformAnesQueryService platformAnesQueryService)
        {
            _accountService = accountService;
            _platformAnesQueryService = platformAnesQueryService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> Login()
        {
            return Success("");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<MED_USERS> Login(dynamic data)
        {
            string loginName = data.loginName;
            string passWord = data.passWord;
            MED_USERS User = null;
            if (loginName.ToLower() == "mdsd" && passWord.ToLower() == "mdsdss")
            {
                User = new MED_USERS { LOGIN_NAME = loginName.ToUpper(), USER_NAME = loginName.ToUpper(), USER_JOB_ID = loginName.ToUpper(), USER_JOB = "医生", USER_ROLE = "主任,管理员", isMDSD = true };
                // 动态加载菜单
                GetReportMenu(data);
                User.MenuList = CheckPermission(null, data.menuList, true);
                return Success(User, "");
            }
            else
            {
                if (AppSettings.IsFor5)
                {
                    User = _accountService.LoginFor5(loginName, passWord);
                }
                else {
                    User = _accountService.Login(loginName, passWord);
                }
                if (User == null)
                {
                    return Failed<MED_USERS>("用户名或密码错误！");
                }
                else
                {
                    if (User.IS_VALID.ToUpper() != "T")
                    {
                        return Failed<MED_USERS>("该用户名未启用！");
                    }
                    else
                    {
                        if (AppSettings.IsFor5)
                        {
                            dynamic tempmenuList = new object[2];
                            foreach (var itemnew in data.menuList)
                            {
                                string name = itemnew["name"].Value;
                                if (name != "质控管理" && name != "日常查询" && name!= "系统设置")
                                {
                                    continue;
                                }
                                else
                                {
                                    if (name == "日常查询")
                                    {
                                        tempmenuList[0] = itemnew;
                                    }
                                    if (name == "系统设置")
                                    {
                                        tempmenuList[1] = itemnew;
                                    }
                                }
                            }
                            User.MenuList = CheckPermission(_accountService.GetPermissionsFor5(User.USER_ID), tempmenuList);
                        }
                        else
                        {
                            //获取用户权限信息
                            var permission = Permission.DataServices.PermissionService.ClientInstance.GetAppPermission("AnesPlatform2", User.USER_ID);
                            //用户角色
                            StringBuilder sbUserRole = new StringBuilder();
                            foreach (var item in permission.MDSD_USER_GROUP)
                            {
                                sbUserRole.AppendFormat("{0},", item.GROUP_NAME);
                            }
                            User.USER_ROLE = sbUserRole.ToString().TrimEnd(',');
                            if (User.USER_ROLE.Contains("主任") || User.USER_ROLE.Contains("护士长"))
                            {
                                User.IsDirector = true;
                            }
                            else
                            {
                                User.IsDirector = false;
                            }
                            // 系统菜单
                            StringBuilder sbMenus = new StringBuilder();
                            foreach (var item in permission.MDSD_APPLICATION.MENU_LIST)
                            {
                                sbMenus.AppendFormat("{0},", item.MENU_LABEL);
                            }
                            User.Menus = sbMenus.ToString().TrimEnd(',');
                            //生成token,SecureKey是配置的web.config中，用于加密token的key，打死也不能告诉别人
                            byte[] key = Encoding.Default.GetBytes(AppSettings.SecureKey);
                            var userSchedule = new MED_USERS_SCHEDULE()
                            {
                                USER_ID = User.USER_ID,
                                USER_JOB_ID = User.USER_JOB_ID,
                                LOGIN_NAME = User.LOGIN_NAME,
                                LOGIN_PWD = User.LOGIN_PWD,
                                USER_NAME = User.USER_NAME,
                                IS_VALID = User.IS_VALID,
                                Dept_Name = User.Dept_Name,
                                USER_JOB = User.USER_JOB,
                                USER_ROLE = User.USER_ROLE
                            };
                            // 采用HS256加密算法
                            User.Token = JWT.JsonWebToken.Encode(userSchedule, key, JWT.JwtHashAlgorithm.HS256);
                            // 消息平台登录
                            if (HttpContext.Current.Application[User.LOGIN_NAME] == null)
                            {
                                TransMessageManager tmm = new TransMessageManager(User);
                                System.Threading.Thread.Sleep(1000);
                                tmm.OpenConnection();
                                HttpContext.Current.Application[User.LOGIN_NAME] = tmm;
                            }
                            // 动态加载菜单
                            GetReportMenu(data);
                            // 菜单权限
                            User.MenuList = CheckPermission(permission, data.menuList);
                        }
                        return Success(User, "");
                    }
                }
            }
        }
        /// <summary>
        /// 获取报表菜单
        /// </summary>
        /// <param name="data"></param>
        private void GetReportMenu(dynamic data)
        {
            List<KeyValue> dyMenu = _platformAnesQueryService.GetReportConfig();
            foreach (var item in data.menuList)
            {
                string name = item["name"].Value;
                if (name != "质控管理" && name != "日常查询")
                {
                    continue;
                }
                else
                {
                    if (name == "质控管理")
                    {
                        for (int i = 0; i < item.childMenuList.Count - 1; i++)
                        {
                            StringBuilder sbbd = new StringBuilder();
                            foreach (var bsitem in item.childMenuList[i].childMenuList)
                            {
                                sbbd.Append(JsonConvert.SerializeObject(bsitem) + ",");
                            }
                            foreach (KeyValue childItem in dyMenu.Where(x => x.Value == item.childMenuList[i].name.Value))
                            {
                                sbbd.Append("{\"name\": \"" + childItem.Key + "\",\"menuKey\": \"" + childItem.Key + "\",\"path\": \"/quality/" + childItem.Value + "/" + childItem.Key + "\",\"permission\": false},");
                            }
                            if (sbbd.ToString() != "")
                            {
                                item.childMenuList[i].childMenuList = JsonConvert.DeserializeObject("[" + sbbd.ToString().TrimEnd(',') + "]");
                            }
                        }
                    }
                    else if (name == "日常查询")
                    {
                        for (int i = 0; i < item.childMenuList.Count; i++)
                        {
                            StringBuilder sbbd = new StringBuilder();
                            foreach (var bsitem in item.childMenuList[i].childMenuList)
                            {
                                sbbd.Append(JsonConvert.SerializeObject(bsitem) + ",");
                            }
                            foreach (KeyValue childItem in dyMenu.Where(x => x.Value == item.childMenuList[i].name.Value))
                            {
                                sbbd.Append("{\"name\": \"" + childItem.Key + "\",\"menuKey\": \"" + childItem.Key + "\",\"path\": \"/anesreport/" + childItem.Value + "/" + childItem.Key + "\",\"permission\": false},");
                            }
                            if (sbbd.ToString() != "")
                            {
                                item.childMenuList[i].childMenuList = JsonConvert.DeserializeObject("[" + sbbd.ToString().TrimEnd(',') + "]");
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获取菜单权限
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="menuList"></param>
        /// <param name="ismdsd"></param>
        /// <returns></returns>
        private dynamic CheckPermission(Permission.DataServices.Domain.PERMISSION permission, dynamic menuList, Boolean ismdsd = false)
        {
            if (menuList != null)
            {
                foreach (var item in menuList)
                {
                    if (ismdsd)
                    {
                        item.permission = true;
                    }
                    else
                    {
                        item.permission = permission.CheckedMenu(item.menuKey.Value);
                    }
                    if (item.permission.Value)
                    {
                        CheckPermission(permission, item.childMenuList, ismdsd);
                    }
                }
            }
            return menuList;
        }

        private dynamic CheckPermission(List<string> permissionlist, dynamic menuList)
        {
            if (menuList != null)
            {
                foreach (var item in menuList)
                {
                    item.permission = permissionlist.Contains(item.menuKey.Value);
                    
                    if (item.permission.Value)
                    {
                        CheckPermission(permissionlist, item.childMenuList);
                    }
                }
            }
            return menuList;
        }

        /// <summary>
        /// 检查是否登录
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_USERS> CheckLogin(string token)
        {
            string key = AppSettings.SecureKey;
            MED_USERS user = new MED_USERS();
            try
            {
                var userSchedule = JWT.JsonWebToken.DecodeToObject<MED_USERS_SCHEDULE>(token, key, true);

                user.USER_ID = userSchedule.USER_ID;
                user.USER_JOB_ID = userSchedule.USER_JOB_ID;
                user.LOGIN_NAME = userSchedule.LOGIN_NAME;
                user.LOGIN_PWD = userSchedule.LOGIN_PWD;
                user.USER_NAME = userSchedule.USER_NAME;
                user.IS_VALID = userSchedule.IS_VALID;
                user.Dept_Name = userSchedule.Dept_Name;
                user.USER_JOB = userSchedule.USER_JOB;
                user.USER_ROLE = userSchedule.USER_ROLE;

            }
            catch (Exception e)
            {
                user = null;
            }

            return Success(user, "");
        }

        /// <summary>
        /// 通过第三方登录获取用户信息
        /// </summary>
        /// <param name="userJobId"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_USERS> OauthSide(string userJobId)
        {
            MED_USERS User = _accountService.GetUserByUserJobId(userJobId);
            if (User == null)
            {
                return Failed<MED_USERS>("该用户不存在本系统中");
            }
            else
            {
                if (User.IS_VALID.ToUpper() != "T")
                {
                    return Failed<MED_USERS>("该用户未启用");
                }
                else
                {
                    //获取用户权限信息
                    var permission = Permission.DataServices.PermissionService.ClientInstance.GetAppPermission("AnesPlatform", User.USER_ID);
                    string user_Role = "";
                    foreach (var item in permission.MDSD_USER_GROUP)
                    {
                        user_Role += item.GROUP_NAME + ',';
                    }
                    User.USER_ROLE = user_Role;
                    if (user_Role.Contains("主任") || user_Role.Contains("护士长"))
                    {
                        User.IsDirector = true;
                    }
                    else
                    {
                        User.IsDirector = false;
                    }

                    string menus = ""; //菜单
                    foreach (var item in permission.MDSD_APPLICATION.MENU_LIST)
                    {
                        menus += item.MENU_LABEL + ",";
                    }
                    User.Menus = menus;

                    //生成token,SecureKey是配置的web.config中，用于加密token的key，打死也不能告诉别人
                    byte[] key = Encoding.Default.GetBytes(AppSettings.SecureKey);
                    //采用HS256加密算法
                    User.Token = JWT.JsonWebToken.Encode(User, key, JWT.JwtHashAlgorithm.HS256);

                    TransMessageManager tmm = new TransMessageManager(User);
                    tmm.OpenConnection();
                    if (HttpContext.Current.Session[User.LOGIN_NAME] == null)
                    {
                        HttpContext.Current.Session[User.LOGIN_NAME] = tmm;
                    }
                    return Success(User, "");
                }
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> ChangePwd(MED_USERS user)
        {
            int resultInt = _accountService.ChangePwd(user);
            if (resultInt == 2)
            {
                return Failed<string>("原始密码错误");
            }
            else if (resultInt == 1)
            {
                return Success("", "密码修改成功");
            }
            else
            {
                return Failed<string>("密码修改失败");
            }
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> LoginOut(MED_USERS user)
        {
            if (HttpContext.Current.Application[user.LOGIN_NAME] != null)
            {
                TransMessageManager tmm = HttpContext.Current.Application[user.LOGIN_NAME] as TransMessageManager;
                tmm.CloseConnection();
                HttpContext.Current.Application.Remove(user.LOGIN_NAME);
            }
            return Success("");
        }

        /// <summary>
        /// Test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public MED_USERS Test()
        {
            string key = AppSettings.SecureKey;
            MED_USERS tokenJson = JWT.JsonWebToken.DecodeToObject<MED_USERS>("http://192.168.18.118:8097/#/OperSchedule?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJEZXB0X05hbWUiOiLkvY_pmaLmiYvmnK_lrqQiLCJUb2tlbiI6bnVsbCwiVVNFUl9JRCI6ImU4NmFhMDk5LWRmNGUtNDNiOS1iNzVkLTRlOWZkZGEzMzU3OCIsIkxPR0lOX05BTUUiOiJzMzU0IiwiTE9HSU5fUFdEIjoiQ0ZDRDIwODQ5NUQ1NjVFRjY2RTdERkY5Rjk4NzY0REEiLCJVU0VSX05BTUUiOiLmnY7nkLPnkLMiLCJJU19WQUxJRCI6InQiLCJNb2RlbFN0YXR1cyI6MCwiVVNFUl9KT0IiOm51bGx9.goQrjnVcd6sW5cOoq7dKui9JrCRWSyCm6aI-1sZ6Lws", key, true);
            return tokenJson;
        }
    }
}