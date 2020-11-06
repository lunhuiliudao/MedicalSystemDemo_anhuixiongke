using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateDAL;
using UpdateEntity;

namespace UpdateBLL
{
    public static class AppInfoBLL
    {
        public static AppInfoDAL appInfoDal = new AppInfoDAL();
        public static bool Insert(APP_INFO appInfo)
        {
            appInfo.APP_ID = Guid.NewGuid().ToString();
            appInfo.CREATE_TIME = DateTime.Now;
            return appInfoDal.Insert(appInfo);
        }

        public static bool Update(APP_INFO appInfo)
        {
            appInfo.MODIFY_TIME = DateTime.Now;
            return appInfoDal.Update(appInfo);
        }

        public static List<APP_INFO> GetList()
        {
            return appInfoDal.GetList();
        }

        public static APP_INFO GetSingle(string id)
        {
            return appInfoDal.GetSingle(id);
        }

        public static bool GetIsExistAppKey(string appKey)
        {
            return appInfoDal.GetIsExistAppKey(appKey);
        }

        public static APP_INFO GetAppInfoByAppKey(string appKey)
        {
            return appInfoDal.GetAppInfoByAppKey(appKey);
        }

        public static bool Delete(string appID)
        {
            return appInfoDal.Delete(appID);
        }
    }
}
