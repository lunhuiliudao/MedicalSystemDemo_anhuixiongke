using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateCommon;
using UpdateDAL;
using UpdateEntity;

namespace UpdateBLL
{    
    public static class VerBLL
    {
        public static VerDAL verDal = new VerDAL();
        public static bool Insert(VER_INFO verInfo)
        {
            try
            {
                if (verInfo != null)
                {
                    verInfo.VER_ID = Guid.NewGuid().ToString();
                    verInfo.CREATE_TIME = DateTime.Now;
                }
                return verDal.Insert(verInfo);
            }
            catch (Exception ex)
            {
                return false;
            }            
        }

        public static bool Update(VER_INFO verInfo)
        {
            try
            {
                if (verInfo != null)
                {
                    verInfo.MODIFY_TIME = DateTime.Now;
                }
                return verDal.Update(verInfo);
            }
            catch (Exception ex)
            {
                LogHelper.writeLog(ex.ToString());
                return false;
            }
        }

        public static bool UpdateRollBack(VER_INFO verInfo)
        {
            try
            {
                if (verInfo != null)
                {
                    verInfo.MODIFY_TIME = DateTime.Now;
                }
                return verDal.UpdateRollBack(verInfo);
            }
            catch (Exception ex)
            {
                LogHelper.writeLog(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 通appID按最大版本号取实体
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        public static VER_INFO GetVER_InfoByMaxNo(string appID)
        {
            return verDal.GetVER_InfoByMaxNo(appID);
        }

        /// <summary>
        /// 获取版本号（已作累加）
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        public static int GetAppVerion(string appID)
        {
            return verDal.GetAppVerion(appID);
        }

        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VER_INFO GetSingle(string id)
        {
            return verDal.GetSingle(id);
        }

        /// <summary>
        /// 按应用程序ID获取版本信息
        /// </summary>
        /// <returns></returns>
        public static List<VER_LIST> GetList(string appID)
        {
            return verDal.GetList(appID);
        }

        public static List<VER_INFO> GetAllList(string appID)
        {
            return verDal.GetAllList(appID);
        }

        /// <summary>
        /// 根据应用程序ID和版本号取信息
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="verion"></param>
        /// <returns></returns>
        public static VER_INFO GetVer_InfoByAppIDAndVerion(string appID,string verion)
        {
            return verDal.GetVer_InfoByAppIDAndVerion(appID, verion);
        }

        /// <summary>
        /// 根据应用程序ID、版本号、是否为测试版获取更新版列表
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="verion"></param>
        /// <param name="isTest"></param>
        /// <returns></returns>
        public static List<VER_INFO> GetListByAppIDAndVerio(string appID, string verion,string isTest)
        {
            List<VER_INFO> list = verDal.GetListByAppIDAndVerio(appID, verion, isTest);
            List<VER_INFO> tempList = new List<VER_INFO>();
            //处理，当前客户版本未更新则不取所有回退版，如果有更新，则当前版取，并且取大于当前版所有未回退版本
            foreach (VER_INFO item in list)
            {
                if (int.Parse(verion) == 0)
                {
                    if (item.ROLL_BACK != 1)
                        tempList.Add(item);
                }
                else
                {
                    if (verion == item.VER_NO.ToString())
                        tempList.Add(item);
                    else
                    {
                        if(item.ROLL_BACK != 1)
                            tempList.Add(item);
                    }
                }
            }
            return tempList;
        }

        public static bool UpdateVerInfoByForcibly(string verionID)
        {
            return verDal.UpdateVerInfoByForcibly(verionID);
        }

        public static bool UpdateVerInfoByPublish(string verionID)
        {
            return verDal.UpdateVerInfoByPublish(verionID);
        }

        public static bool Delete(string verionID)
        {
            return verDal.Delete(verionID);
        }
    }
}
