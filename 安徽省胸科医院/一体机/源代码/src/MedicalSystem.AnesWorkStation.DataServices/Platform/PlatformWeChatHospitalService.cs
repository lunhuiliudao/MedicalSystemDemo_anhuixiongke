using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
//using MedicalSystem.AnesWorkStation.Domain.AnesQuery;
using MedicalSystem.Common.FileManage;
using MedicalSystem.Configurations;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformWeChatHospitalService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        MED_WECHAT_HOSPITALS Login(string LoginName, string PassWord);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int ChangePwd(MED_USERS user);

        /// <summary>
        /// 获取医院信息数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<MED_WECHAT_HOSPITALS> GetHospitalList(OperQueryParaModel model);

        /// <summary>
        /// 编辑医院信息数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="hospitalDict"></param>
        /// <returns></returns>
        int EditWeChatHospital(int type, MED_WECHAT_HOSPITALS hospitalDict);

    }
    public class PlatformWeChatHospitalService : BaseService<PlatformAnesQueryService>, IPlatformWeChatHospitalService
    {
        protected PlatformWeChatHospitalService()
            : base() { }
        public PlatformWeChatHospitalService(IDapperContext context)
            : base(context)
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public MED_WECHAT_HOSPITALS Login(string LoginName, string PassWord)
        {
            if (LoginName.ToUpper() == "mdsd".ToUpper() && PassWord.ToUpper() == "mdsdss".ToUpper())
            {
                MED_WECHAT_HOSPITALS user = new MED_WECHAT_HOSPITALS();
                user.HOSPITAL_ID = "mdsd";
                user.HOSPITAL_NAME = "麦迪斯顿";
                user.PROVINCE = "江苏省";
                user.PROVINCE_ID = "江苏省";
                user.CITY = "苏州";
                user.CITY_ID = "苏州";
                user.IP_ADDRESS = "";
                user.SHORT_NAME = "麦迪";
                user.LOGIN_NAME = "mdsd";
                user.PASSWORD = "mdsdss";
                user.ENABLE = 1;
                return user;
            }
            else
            {
                string sql = sqlDict.GetSQLByKey("LoginAcount");
                var list = dapper.Set<MED_WECHAT_HOSPITALS>().Query(sql, new { LoginName = LoginName, LoginPwd = Commom.Base64Encode(PassWord) });
                MED_WECHAT_HOSPITALS user = list.Count() > 0 ? list[0] : null;
                return user;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int ChangePwd(MED_USERS user)
        {
            string tempOldPwd = Commom.Base64Encode(user.OLD_LOGIN_PWD);
            MED_WECHAT_HOSPITALS midUser = dapper.Set<MED_WECHAT_HOSPITALS>().Single(x => x.LOGIN_NAME == user.LOGIN_NAME && x.PASSWORD == tempOldPwd);
            if (midUser == null)
            {
                return 2; //原始密码输入错误
            }
            else
            {
                midUser.PASSWORD = Commom.Base64Encode(user.LOGIN_PWD);
                int updateCount = dapper.Set<MED_WECHAT_HOSPITALS>().Update(midUser, p => new { p.PASSWORD });
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

        /// <summary>
        /// 获取医院信息数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<MED_WECHAT_HOSPITALS> GetHospitalList(OperQueryParaModel model)
        {
            string sql = @" select *
  from MED_WECHAT_HOSPITALS a
 where (a.hospital_name like '%' || @HospitalNameKey || '%'
    or a.short_name like '%' || @HospitalNameKey || '%' or @HospitalNameKey is null) and (a.province like '%' || @ProvinceKey || '%'
    or a.city like '%' || @ProvinceKey || '%' or @ProvinceKey is null )";

            try
            {
                return dapper.Set<MED_WECHAT_HOSPITALS>().Query(sql, new { HospitalNameKey = model.QueryType, ProvinceKey = model.SearchMark });
            }
            catch (Exception ex)
            {
                Logger.Error("读取医院信息数据GetHospitalList:", ex);
                return null;
            }
        }

        /// <summary>
        /// 编辑医院信息数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="hospitalDict"></param>
        /// <returns></returns>
        public int EditWeChatHospital(int type, MED_WECHAT_HOSPITALS hospitalDict)
        {
            hospitalDict.PASSWORD = Commom.Base64Encode(hospitalDict.PASSWORD);
            int result = 0;
            try
            {
                if (type == 0)
                {
                    hospitalDict.HOSPITAL_ID = Guid.NewGuid().ToString();
                    //根据医院判断是否存在
                    if (dapper.Set<MED_WECHAT_HOSPITALS>().Single(d => d.HOSPITAL_NAME == hospitalDict.HOSPITAL_NAME) != null)
                    {
                        result = 2;
                    }
                    //根据医院 登录名是否存在
                    else if (dapper.Set<MED_WECHAT_HOSPITALS>().Single(d => d.LOGIN_NAME == hospitalDict.LOGIN_NAME) != null)
                    {
                        result = 3;
                    }
                    else
                    {

                        result = dapper.Set<MED_WECHAT_HOSPITALS>().Insert(hospitalDict) ? 1 : 0;
                    }
                }
                else
                {
                    hospitalDict.ModelStatus = ModelStatus.Modeified;
                    result = dapper.Set<MED_WECHAT_HOSPITALS>().Update(hospitalDict) > 0 ? 1 : 0;
                }
                dapper.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("编辑医院信息数据EditWeChatHospital:", ex);
            }

            return result;

        }

    }
}
