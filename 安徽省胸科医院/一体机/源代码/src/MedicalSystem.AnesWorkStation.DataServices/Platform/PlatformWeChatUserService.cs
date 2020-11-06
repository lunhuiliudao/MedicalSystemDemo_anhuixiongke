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
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformWeChatUserService
    {
        /// <summary>
        /// 获取用户表
        /// </summary>
        /// <returns></returns>
        dynamic GetWeChatUsers(string hospitalId);

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="type"></param>
        /// <param name="medWeChatUsers"></param>
        /// <returns></returns>
        int SaveWeChatUsers(int type, MED_WECHAT_USERS medWeChatUsers);

        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="medWeChatUsers"></param>
        /// <returns></returns>
        int DeletedWeChatUsers(List<MED_WECHAT_USERS> medWeChatUsers);

        /// <summary>
        /// 导入用户数据
        /// </summary>
        /// <param name="medWeChatUsers"></param>
        /// <returns></returns>
        int ImportWeChatUsers(List<MED_WECHAT_USERS> medWeChatUsers);

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="platName"></param>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        string CreateQrCoce(string platName, string userId, string userType);

        /// <summary>
        /// 绑定用户OpenId
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="OpenId"></param>
        /// <param name="Type">0绑定失败  1绑定成功  2用户已经被绑定  3解绑成功  4解绑失败 5解绑失败（非同一用户）  -10其它未知情况 </param>
        /// <returns></returns>
        int BindUserOpenId(string UserId, string OpenId, string Type);

        /// <summary>
        /// 生成解绑二维码
        /// </summary>
        /// <param name="platName"></param>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        string CreateUnBindQrCoce(string platName, string userId, string userType);
    }
    public class PlatformWeChatUserService : BaseService<PlatformAnesQueryService>, IPlatformWeChatUserService
    {
        public PlatformWeChatUserService()
            : base() { }
        public PlatformWeChatUserService(IDapperContext context)
            : base(context)
        {

        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="platName">anes</param>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        [HttpGet]
        public string CreateQrCoce(string platName, string userId, string userType)
        {
            string imgUrl = string.Empty;

            try
            {
                //string address = System.Configuration.ConfigurationManager.AppSettings["QrCoceAddress"].ToString();

                string url = string.Format(@"http://mp.medqc.com/api/Bind/Qrcode?platform={0}&userId={1}&userType={2}", platName, userId, userType);

                imgUrl = JsonConvert.DeserializeObject<string>(PlatformAsyncHandleData.Get(url));
            }
            catch (Exception ex)
            {
                Logger.Error("生成二维码CreateQrCoce:", ex);
            }

            return imgUrl;
        }

        /// <summary>
        /// 生成解绑二维码
        /// </summary>
        /// <param name="platName">anes</param>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        [HttpGet]
        public string CreateUnBindQrCoce(string platName, string userId, string userType)
        {
            string imgUrl = string.Empty;

            try
            {
                //string address = System.Configuration.ConfigurationManager.AppSettings["QrCoceAddress"].ToString();

                string url = string.Format(@"http://mp.medqc.com/api/Bind/UnbindQrcode?platform={0}&userId={1}&userType={2}", platName, userId, userType);

                imgUrl = JsonConvert.DeserializeObject<string>(PlatformAsyncHandleData.Get(url));
            }
            catch (Exception ex)
            {
                Logger.Error("生成解绑二维码CreateUnBindQrCoce:", ex);
            }

            return imgUrl;
        }

        /// <summary>
        /// 保存用户openid数据
        /// </summary>
        /// <param name="UserId">GUID</param>
        /// <param name="OpenId"></param>
        /// <param name="Type">1 绑定  2 解绑 </param>
        /// <returns></returns>
        /// 返回值 0绑定失败  1绑定成功  2用户已经被绑定  3解绑成功  4解绑失败 5解绑失败（非同一用户）  -10其它未知情况 
        public int BindUserOpenId(string UserId, string OpenId, string Type)
        {
            int result = 0;

            MED_WECHAT_USERS userExist = dapper.Set<MED_WECHAT_USERS>().Single(d => d.ID == UserId);//根据用户ID判断是否存在

            if (userExist != null)//用户存在
            {
                if (string.IsNullOrEmpty(userExist.OPEN_ID))//先判断该用户是否已经绑定过--未绑定
                {
                    if (Type == "1")//绑定
                    {
                        userExist.OPEN_ID = OpenId;
                        int count = dapper.Set<MED_WECHAT_USERS>().Update(userExist) > 0 ? 1 : 0;

                        dapper.SaveChanges();

                        if (count == 1)
                        {
                            result = 1;

                            Logger.Error("1绑定成功BindUserOpenId:", new Exception("绑定用户{" + UserId + "}|{" + OpenId + "}成功！"));
                        }
                        else
                        {
                            result = 0;
                            Logger.Error("0绑定失败BindUserOpenId:", new Exception("绑定用户{" + UserId + "}|{" + OpenId + "}失败，请重新绑定！"));
                        }
                    }

                }
                else//先判断该用户是否已经绑定过--已绑定
                {
                    if (userExist.OPEN_ID.Trim().Equals(OpenId.Trim()))//判断非同一用户--同一用户
                    {
                        if (Type == "1")//绑定
                        {
                            result = 2;
                            Logger.Error("2用户已经被绑定BindUserOpenId:", new Exception("绑定用户{" + UserId + "}|{" + OpenId + "}失败，该用户已绑定，请先解绑！"));
                        }
                        else if (Type == "2")//解绑
                        {
                            userExist.OPEN_ID = "";
                            int count = dapper.Set<MED_WECHAT_USERS>().Update(userExist) > 0 ? 1 : 0;

                            dapper.SaveChanges();

                            if (count == 1)
                            {
                                result = 3;

                                Logger.Error("3解绑成功BindUserOpenId:", new Exception("绑定用户{" + UserId + "}|{" + OpenId + "}成功！"));
                            }
                            else
                            {
                                result = 4;
                                Logger.Error("4解绑失败BindUserOpenId:", new Exception("绑定用户{" + UserId + "}|{" + OpenId + "}失败，请重新解绑！"));
                            }
                        }
                    }
                    else//判断非同一用户--非同一用户
                    {
                        result = 5;
                        Logger.Error("5解绑失败（非同一用户）BindUserOpenId:", new Exception("解绑用户{" + UserId + "}|{" + OpenId + "}失败，非同一用户，请找到对应用户解绑！"));
                    }
                }
            }
            else//用户不存在
            {
                result = 0;
                Logger.Error("0绑定失败BindUserOpenId:", new Exception("该用户{" + UserId + "}|{" + OpenId + "}不存在，请先创建该用户！"));
            }

            return result;
        }



        /// <summary>
        /// 获取微信用户数据
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
                    Logger.Error("获取微信用户数据GetWeChatUsers:", ex);
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
                    Logger.Error("获取微信用户数据GetWeChatUsers:", ex);
                    return null;
                }
            }

        }

        /// <summary>
        /// 保存用户数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="medWeChatUsers"></param>
        /// <returns></returns>
        public int SaveWeChatUsers(int type, MED_WECHAT_USERS medWeChatUsers)
        {
            int result = 0;

            try
            {
                if (type == 0)
                {

                    //保证GUID 唯一 
                    do//先执行一次，再判断。  
                    {
                        medWeChatUsers.ID = Guid.NewGuid().ToString();
                        medWeChatUsers.CREATE_DATE = DateTime.Now;
                    }
                    while (dapper.Set<MED_WECHAT_USERS>().Single(d => d.ID == medWeChatUsers.ID) != null);


                    //根据医院 ID 、用户ID判断是否存在
                    if (dapper.Set<MED_WECHAT_USERS>().Single(d => d.HOSPITAL_ID == medWeChatUsers.HOSPITAL_ID && d.USER_JOB_ID == medWeChatUsers.USER_JOB_ID) != null)
                    {
                        result = 2;
                    }
                    else
                    {
                        result = dapper.Set<MED_WECHAT_USERS>().Insert(medWeChatUsers) ? 1 : 0;
                    }
                }
                else
                {
                    result = dapper.Set<MED_WECHAT_USERS>().Update(medWeChatUsers) > 0 ? 1 : 0;
                }
                dapper.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("保存微信用户数据SaveWeChatUsers:", ex);
            }

            return result;
        }




        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="medWeChatUsers"></param>
        /// <returns></returns>
        public int DeletedWeChatUsers(List<MED_WECHAT_USERS> medWeChatUsers)
        {
            int result = 0;
            try
            {
                result = dapper.Set<MED_WECHAT_USERS>().Delete(medWeChatUsers);
                dapper.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("删除用户数据DeletedWeChatUsers:", ex);
            }
            return result;
        }

        /// <summary>
        /// 导入用户数据
        /// </summary>
        /// <param name="medWeChatUsers"></param>
        /// <returns></returns>
        public int ImportWeChatUsers(List<MED_WECHAT_USERS> medWeChatUsers)
        {
            int result = 0;

            try
            {
                foreach (MED_WECHAT_USERS item in medWeChatUsers)
                {
                    SaveWeChatUsers(0, item);
                }

                result = 1;
            }
            catch (Exception ex)
            {
                Logger.Error("导入用户数据ImportWeChatUsers:", ex);
                result = 0;
            }

            return result;
        }
    }
}
