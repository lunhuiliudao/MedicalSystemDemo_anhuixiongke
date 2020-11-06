using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateEntity;
using DapperEx;

namespace UpdateDAL
{
    public class VerUpdateRecDAL: BaseDAL
    {
        public bool Insert(VER_UPDATE_REC verInfo)
        {
            return Insert<VER_UPDATE_REC>(verInfo);
        }

        public bool Update(VER_UPDATE_REC verInfo)
        {
            return Update<VER_UPDATE_REC>(verInfo);
        }

        public VER_UPDATE_REC GetVerUpdateRecByIPAndVerionID(string ip, string verionID)
        {
            using (var db = CreateDbBase())
            {
                SqlQuery sql = SqlQuery<VER_UPDATE_REC>.Builder(db)
                   .AndWhere(m => m.IP, OperationMethod.Equal, ip)
                   .AndWhere(m => m.VER_ID, OperationMethod.Equal, verionID)
                   .OrderBy(m => m.CREATE_TIME, true);
                VER_UPDATE_REC model = db.SingleOrDefault<VER_UPDATE_REC>(sql);
                return model;
            }
        }

        public List<VER_UPDATE_REC> GetListByVerionID(string verionID)
        {
            using (var db = CreateDbBase())
            {
                SqlQuery sql = SqlQuery<VER_UPDATE_REC>.Builder(db)
                   .AndWhere(m => m.VER_ID, OperationMethod.Equal, verionID)
                   .OrderBy(m => m.CREATE_TIME, true);
                List<VER_UPDATE_REC> model = db.Query<VER_UPDATE_REC>(sql).ToList();
                return model;
            }
        }

        public List<VER_UPDATE_REC_LIST> VerUpdateAllList(string appID, string verionID)
        {
            List<VER_UPDATE_REC_LIST> list = new List<VER_UPDATE_REC_LIST>();
            using (var db = CreateDbBase())
            {
                var sql = @"SELECT A.*,B.VER_NO,C.APP_KEY FROM VER_UPDATE_REC A
LEFT JOIN VER_INFO B ON A.VER_ID =B.VER_ID 
LEFT JOIN APP_INFO C ON C.APP_ID=B.APP_ID 
WHERE 1=1 ";
                var dynamicParams = new DynamicParameters();
                if (!string.IsNullOrEmpty(appID))
                {
                    sql += " AND C.APP_ID=@APP_ID";
                    dynamicParams.Add("APP_ID", appID);
                }
                if (!string.IsNullOrEmpty(verionID))
                {
                    sql += " AND A.VER_ID=@VER_ID";
                    dynamicParams.Add("VER_ID", verionID);
                }
                list = db.QuerySQL<VER_UPDATE_REC_LIST>(sql, dynamicParams).ToList();
            }
            return list.OrderBy(p => p.CREATE_TIME).ToList().OrderByDescending(p => p.CREATE_TIME).ToList();
        }
    }
}
