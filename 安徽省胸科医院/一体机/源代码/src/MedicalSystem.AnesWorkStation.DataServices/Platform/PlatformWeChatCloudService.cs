using System;
using System.Collections.Generic;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformWeChatCloudService
    {


        /// <summary>
        /// 保存手术信息菜单数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        int SaveWeChatCloudOperInfoData(string hospitalId, string jsonData);

        /// <summary>
        /// 保存统计查询菜单数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="childMenu"></param>
        /// <param name="reportMonth"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        int SaveWeChatCloudStatisticsData(string hospitalId, string childMenu, string reportMonth, string jsonData);

        /// <summary>
        /// 保存质控菜单数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="reportMonth"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        int SaveWeChatCloudQuanlityData(string hospitalId, string reportMonth, string jsonData);

        /// <summary>
        /// 获取手术信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        List<MED_WECHAT_OPERINFO> GetOperInfo(string openId);

        /// <summary>
        /// 根据用户openId获取统计查询数据
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="childMenu"></param>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        List<MED_WECHAT_STATISTICS> GetStatisticsInfo(string openId, string childMenu, string reportMonth);

        /// <summary>
        /// 根据用户openId获取质控查询数据
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        List<MED_WECHAT_QUANLITY> GetQuanlityInfo(string openId, string reportMonth);
    }

    public class PlatformWeChatCloudService : BaseService<PlatformAnesQueryService>, IPlatformWeChatCloudService
    {
        public PlatformWeChatCloudService()
            : base() { }
        public PlatformWeChatCloudService(IDapperContext context)
            : base(context)
        {

        }

        /// <summary>
        /// 保存手术信息菜单数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public int SaveWeChatCloudOperInfoData(string hospitalId, string jsonData)
        {
            int result = 0;

            try
            {
                MED_WECHAT_OPERINFO operInfo = new MED_WECHAT_OPERINFO();

                //保证GUID 唯一 
                do//先执行一次，再判断。  
                {
                    operInfo.OPERINFO_ID = Guid.NewGuid().ToString();

                    operInfo.HOSPITAL_ID = hospitalId;

                    operInfo.JSON_DATA = jsonData;

                    operInfo.RECIVE_DATE = DateTime.Now;
                }
                while (dapper.Set<MED_WECHAT_OPERINFO>().Single(d => d.OPERINFO_ID == operInfo.OPERINFO_ID) != null);


                string sqlDelete = @" DELETE FROM MED_WECHAT_OPERINFO";

                //根据医院 ID 、用户ID判断是否存在
                if (dapper.Execute(sqlDelete, null) >= 0)
                {
                    result = dapper.Set<MED_WECHAT_OPERINFO>().Insert(operInfo) ? 1 : 0;

                    dapper.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("保存手术信息菜单数据错误SaveWeChatCloudOperInfoData:", ex);
            }


            return result;
        }

        /// <summary>
        /// 保存统计查询菜单数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="childMenu"></param>
        /// <param name="reportMonth"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public int SaveWeChatCloudStatisticsData(string hospitalId, string childMenu, string reportMonth, string jsonData)
        {
            int result = 0;

            try
            {
                MED_WECHAT_STATISTICS statistics = new MED_WECHAT_STATISTICS();

                //保证GUID 唯一 
                do//先执行一次，再判断。  
                {
                    statistics.STATISTICS_ID = Guid.NewGuid().ToString();

                    statistics.HOSPITAL_ID = hospitalId;

                    statistics.CHILD_MENU = childMenu;

                    statistics.REPORT_MONTH = Convert.ToDateTime(reportMonth).ToString("yyyyMM");

                    statistics.JSON_DATA = jsonData;

                    statistics.RECIVE_DATE = DateTime.Now;


                }
                while (dapper.Set<MED_WECHAT_STATISTICS>().Single(d => d.STATISTICS_ID == statistics.STATISTICS_ID) != null);


                string sqlDelete = string.Format(@" DELETE FROM MED_WECHAT_STATISTICS WHERE CHILD_MENU='{0}' AND REPORT_MONTH ='{1}' ", childMenu, Convert.ToDateTime(reportMonth).ToString("yyyyMM"));

                //根据医院 ID 、用户ID判断是否存在
                if (dapper.Execute(sqlDelete, null) >= 0)
                {
                    result = dapper.Set<MED_WECHAT_STATISTICS>().Insert(statistics) ? 1 : 0;

                    dapper.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("保存统计查询菜单数据错误SaveWeChatCloudStatisticsData:", ex);
            }

            return result;
        }

        /// <summary>
        /// 保存质控菜单数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="reportMonth"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public int SaveWeChatCloudQuanlityData(string hospitalId, string reportMonth, string jsonData)
        {
            int result = 0;

            try
            {


                MED_WECHAT_QUANLITY quanlity = new MED_WECHAT_QUANLITY();

                //保证GUID 唯一 
                do//先执行一次，再判断。  
                {
                    quanlity.QUANLITY_ID = Guid.NewGuid().ToString();

                    quanlity.HOSPITAL_ID = hospitalId;

                    quanlity.REPORT_MONTH = Convert.ToDateTime(reportMonth).ToString("yyyyMM");

                    quanlity.JSON_DATA = jsonData;

                    quanlity.RECIVE_DATE = DateTime.Now;
                }
                while (dapper.Set<MED_WECHAT_QUANLITY>().Single(d => d.QUANLITY_ID == quanlity.QUANLITY_ID) != null);


                string sqlDelete = string.Format(@" DELETE FROM MED_WECHAT_QUANLITY WHERE  REPORT_MONTH ='{0}' ", Convert.ToDateTime(reportMonth).ToString("yyyyMM"));

                //根据医院 ID 、用户ID判断是否存在
                if (dapper.Execute(sqlDelete, null) >= 0)
                {
                    result = dapper.Set<MED_WECHAT_QUANLITY>().Insert(quanlity) ? 1 : 0;

                    dapper.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("保存质控菜单数据错误SaveWeChatCloudQuanlityData:", ex);
            }


            return result;
        }



        /// <summary>
        /// 根据 OPENID 获取微信用户
        /// </summary>
        /// <param name="openId">医院ID</param>
        /// <returns></returns>
        public dynamic GetWeChatUsers(string openId)
        {
            string sql = string.Format(@"SELECT * FROM MED_WECHAT_USERS WHERE OPEN_ID = '{0}'", openId);

            try
            {
                return dapper.Query<MED_WECHAT_USERS>(sql);
            }
            catch (Exception ex)
            {
                Logger.Error("读取微信用户信息错误GetWeChatUsers:", new Exception("该用户该用户还未关注公众号或不存在！"));
                return null;
            }
        }


        /// <summary>
        /// 根据用户openId获取手术信息数据
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public List<MED_WECHAT_OPERINFO> GetOperInfo(string openId)
        {
            if (!string.IsNullOrEmpty(openId))
            {
                List<MED_WECHAT_USERS> usersList = GetWeChatUsers(openId);

                if (usersList != null && usersList.Count > 0)
                {
                    if (!string.IsNullOrEmpty(usersList[0].HOSPITAL_ID))
                    {
                        string sql = string.Format(@" SELECT * FROM MED_WECHAT_OPERINFO WHERE HOSPITAL_ID = '{0}' ORDER BY RECIVE_DATE DESC ", usersList[0].HOSPITAL_ID);

                        return dapper.Query<MED_WECHAT_OPERINFO>(sql);
                    }
                    else
                    {
                        Logger.Error("读取手术信息错误GetOperInfo:", new Exception("该用户{" + usersList[0].ID + "}还未绑定医院！"));

                        return null;
                    }
                }
                else
                {
                    Logger.Error("读取手术信息错误GetOperInfo:", new Exception("该用户还未关注公众号或不存在！"));

                    return null;
                }
            }
            else
            {
                Logger.Error("读取手术信息错误GetOperInfo:", new Exception("GetOperInfo参数为空,openId={" + openId + "}！"));

                return null;
            }
        }

        /// <summary>
        /// 根据用户openId获取统计查询数据
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="childMenu"></param>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public List<MED_WECHAT_STATISTICS> GetStatisticsInfo(string openId, string childMenu, string reportMonth)
        {
            if (!string.IsNullOrEmpty(openId) && !string.IsNullOrEmpty(childMenu) && !string.IsNullOrEmpty(reportMonth))
            {
                List<MED_WECHAT_USERS> usersList = GetWeChatUsers(openId);

                if (usersList != null && usersList.Count > 0)
                {
                    if (!string.IsNullOrEmpty(usersList[0].HOSPITAL_ID))
                    {
                        string sql = string.Format(@" SELECT * FROM MED_WECHAT_STATISTICS 
                                                  WHERE HOSPITAL_ID = '{0}' AND CHILD_MENU = '{1}' AND REPORT_MONTH = '{2}'  
                                                  ORDER BY RECIVE_DATE DESC ", usersList[0].HOSPITAL_ID, childMenu, Convert.ToDateTime(reportMonth).ToString("yyyyMM"));

                        return dapper.Query<MED_WECHAT_STATISTICS>(sql);
                    }
                    else
                    {
                        Logger.Error("读取统计查询信息错误GetStatisticsInfo:", new Exception("该用户{" + usersList[0].ID + "}还未绑定医院！"));

                        return null;
                    }
                }
                else
                {
                    Logger.Error("读取统计查询信息错误GetStatisticsInfo:", new Exception("该用户还未关注公众号或不存在！"));

                    return null;
                }
            }
            else
            {
                Logger.Error("读取统计查询信息错误GetStatisticsInfo:", new Exception("GetStatisticsInfo参数为空,openId={" + openId + "},childMenu={" + childMenu + "},reportMonth={" + reportMonth + "}！"));

                return null;
            }
        }

        /// <summary>
        /// 根据用户openId获取质控查询数据
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public List<MED_WECHAT_QUANLITY> GetQuanlityInfo(string openId, string reportMonth)
        {
            if (!string.IsNullOrEmpty(openId) && !string.IsNullOrEmpty(reportMonth))
            {
                List<MED_WECHAT_USERS> usersList = GetWeChatUsers(openId);

                if (usersList != null && usersList.Count > 0)
                {
                    if (!string.IsNullOrEmpty(usersList[0].HOSPITAL_ID))
                    {
                        string sql = string.Format(@" SELECT * FROM MED_WECHAT_QUANLITY 
                                                  WHERE HOSPITAL_ID = '{0}' AND REPORT_MONTH LIKE '%{1}%'  
                                                  ORDER BY RECIVE_DATE DESC ", usersList[0].HOSPITAL_ID, reportMonth);

                        return dapper.Query<MED_WECHAT_QUANLITY>(sql);
                    }
                    else
                    {
                        Logger.Error("读取质控查询信息错误GetQuanlityInfo:", new Exception("该用户{" + usersList[0].ID + "}还未绑定医院！"));

                        return null;
                    }
                }
                else
                {
                    Logger.Error("读取质控查询信息错误GetQuanlityInfo:", new Exception("该用户还未关注公众号或不存在！"));

                    return null;
                }
            }
            else
            {
                Logger.Error("读取质控查询信息错误GetQuanlityInfo:", new Exception("GetStatisticsInfo参数为空,openId={" + openId + "},reportMonth={" + reportMonth + "}！"));

                return null;
            }
        }
    }
}
