using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateDAL;
using UpdateEntity;

namespace UpdateBLL
{
    public class SystemConfigBLL
    {
        public static SystemConfigDAL appInfoDal = new SystemConfigDAL();
        public static bool Insert(SYSTEM_CONFIG systemConfig)
        {
            return appInfoDal.Insert(systemConfig);
        }

        public static bool Update(SYSTEM_CONFIG systemConfig)
        {
            return appInfoDal.Update(systemConfig);
        }

        public static SYSTEM_CONFIG GetSingleTopOn()
        {
            return appInfoDal.GetSingleTopOn();
        }
    }
}
