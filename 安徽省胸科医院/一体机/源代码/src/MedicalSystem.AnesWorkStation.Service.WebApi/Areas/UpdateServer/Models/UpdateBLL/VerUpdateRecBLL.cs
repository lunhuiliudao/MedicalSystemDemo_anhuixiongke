using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateDAL;
using UpdateEntity;

namespace UpdateBLL
{
    public class VerUpdateRecBLL
    {
        public static VerUpdateRecDAL verUpdateDal = new VerUpdateRecDAL();
        public static bool Insert(VER_UPDATE_REC verUpdateInfo)
        {
            try
            {
                return verUpdateDal.Insert(verUpdateInfo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Update(VER_UPDATE_REC verUpdateInfo)
        {
            try
            {
                return verUpdateDal.Update(verUpdateInfo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static VER_UPDATE_REC GetVerUpdateRecByIPAndVerionID(string ip, string verionID)
        {
            return verUpdateDal.GetVerUpdateRecByIPAndVerionID(ip, verionID);
        }

        public static List<VER_UPDATE_REC> GetListByVerionID(string verionID)
        {
            return verUpdateDal.GetListByVerionID(verionID);
        }

        /// <summary>
        /// 按条件获取所有更新日志
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="verionID"></param>
        /// <returns></returns>
        public static List<VER_UPDATE_REC_LIST> VerUpdateAllList(string appID, string verionID)
        {
            return verUpdateDal.VerUpdateAllList(appID,verionID);
        }
    }
}
