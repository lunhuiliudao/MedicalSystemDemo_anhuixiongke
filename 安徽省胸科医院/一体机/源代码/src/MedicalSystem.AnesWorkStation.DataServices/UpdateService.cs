using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;
using Dapper.Data;
using System.Linq.Expressions;
using System.Data;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 麻醉信息接口
    /// </summary>
    public interface IUpdateService
    {
        MED_APP_INFO GetAppInfoByAppKey(string appKey);
        List<MED_APP_INFO> GetAppInfoList();
        List<MED_VER_INFO> GetListByAppIDAndVerio(string appID, string verion, string isTest);
        List<MED_VER_INFO> GetVerInfoList(string appID);
        MED_VER_INFO GetVer_InfoByAppIDAndVerion(string appID, string versionNo);
        MED_VER_UPDATE_REC GetVerUpdateRecByIPAndVerionID(string ip, string verID);
        bool SaveVerUpdateRec(MED_VER_UPDATE_REC data);
        bool SaveAppInfo(MED_APP_INFO data);
        bool SaveVerInfo(MED_VER_INFO data);
        MED_SYSTEM_CONFIG GetSingleTopOn();
    }
    /// <summary>
    /// 麻醉信息
    /// </summary>
    public class UpdateService : BaseService<UpdateService>, IUpdateService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected UpdateService()
            : base() { }


        public UpdateService(IDapperContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 获取病人手术信息
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        [HttpGet]
        public virtual MED_OPERATION_MASTER GetOperationMaster(string patientID, int visitID, int operID)
        {
            string sql = string.Format(@"
SELECT MOM.*,
       NVL(MDD.DEPT_NAME, MOM.DEPT_CODE) AS DEPT_NAME
  FROM MED_OPERATION_MASTER MOM
  LEFT JOIN MED_DEPT_DICT MDD ON MDD.DEPT_CODE = MOM.DEPT_CODE
 WHERE MOM.PATIENT_ID = '{0}'
   AND MOM.VISIT_ID = {1}
   AND MOM.OPER_ID = {2}
", patientID, visitID, operID);
            MED_OPERATION_MASTER operationMaster = dapper.Query<MED_OPERATION_MASTER>(sql, null).FirstOrDefault();

            return operationMaster;
        }

        [HttpGet]
        public virtual MED_APP_INFO GetAppInfoByAppKey(string appKey)
        {
            MED_APP_INFO info = dapper.Set<MED_APP_INFO>().Single(x => x.APP_KEY.Equals(appKey));
            return info;
        }

        [HttpGet]
        public virtual List<MED_VER_INFO> GetVerInfoList(string appID)
        {
            List<MED_VER_INFO> result = dapper.Set<MED_VER_INFO>().Select(x => x.APP_ID.Equals(appID));
            return result;
        }

        /// <summary>
        /// 根据应用程序ID、版本号、是否为测试版获取更新版列表
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="verion"></param>
        /// <param name="isTest"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_VER_INFO> GetListByAppIDAndVerio(string appID, string verion, string isTest)
        {
            string sql = @"SELECT * FROM MED_VER_INFO WHERE APP_ID = '" + appID + "' AND VER_NO >= " + verion + " ORDER BY VER_NO ASC";
            if (isTest != "1")
            {
                sql = @"SELECT * FROM MED_VER_INFO WHERE APP_ID = '" + appID + "' AND VER_NO >= " + verion + " AND (IS_TEST != 1 OR IS_TEST IS NULL) ORDER BY VER_NO ASC";
            }

            List<MED_VER_INFO> list = dapper.Query<MED_VER_INFO>(sql, null).ToList();
            List<MED_VER_INFO> tempList = new List<MED_VER_INFO>();
            //处理，当前客户版本未更新则不取所有回退版，如果有更新，则当前版取，并且取大于当前版所有未回退版本
            foreach (MED_VER_INFO item in list)
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
                        if (item.ROLL_BACK != 1)
                            tempList.Add(item);
                    }
                }
            }
            return tempList;
        }

        [HttpGet]
        public virtual MED_VER_INFO GetVer_InfoByAppIDAndVerion(string appID, string versionNo)
        {
            MED_VER_INFO result = dapper.Set<MED_VER_INFO>().Single(x => x.APP_ID.Equals(appID) && x.VER_NO.Equals(versionNo));
            return result;
        }

        [HttpGet]
        public virtual List<MED_APP_INFO> GetAppInfoList()
        {
            List<MED_APP_INFO> result = dapper.Set<MED_APP_INFO>().Select();
            return result;
        }

        [HttpGet]
        public virtual MED_VER_UPDATE_REC GetVerUpdateRecByIPAndVerionID(string ip, string verID)
        {
            MED_VER_UPDATE_REC result = dapper.Set<MED_VER_UPDATE_REC>().Single(x => x.IP.Equals(ip) && x.VER_ID.Equals(verID));
            return result;
        }

        [HttpPost]
        public virtual bool SaveVerUpdateRec(MED_VER_UPDATE_REC data)
        {
            bool ret = false;
            ret = dapper.Set<MED_VER_UPDATE_REC>().Save(data);
            dapper.SaveChanges();
            return ret;
        }

        [HttpPost]
        public virtual bool SaveAppInfo(MED_APP_INFO data)
        {
            bool ret = false;
            ret = dapper.Set<MED_APP_INFO>().Save(data);
            dapper.SaveChanges();
            return ret;
        }

        [HttpPost]
        public virtual bool SaveVerInfo(MED_VER_INFO data)
        {
            bool ret = false;
            ret = dapper.Set<MED_VER_INFO>().Save(data);
            dapper.SaveChanges();
            return ret;
        }

        [HttpGet]
        public virtual MED_SYSTEM_CONFIG GetSingleTopOn()
        {
            MED_SYSTEM_CONFIG result = dapper.Set<MED_SYSTEM_CONFIG>().Select().FirstOrDefault();
            return result;
        }
    }
}
