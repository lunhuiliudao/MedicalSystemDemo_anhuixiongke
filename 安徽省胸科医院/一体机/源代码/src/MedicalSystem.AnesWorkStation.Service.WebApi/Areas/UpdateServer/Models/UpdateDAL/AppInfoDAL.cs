using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateEntity;
using DapperEx;

namespace UpdateDAL
{
    public class AppInfoDAL:BaseDAL
    {
        public bool Insert(APP_INFO appInfo)
        {
            return Insert<APP_INFO>(appInfo);
        }

        public bool Update(APP_INFO appInfo)
        {
            return Update<APP_INFO>(appInfo);
        }

        public List<APP_INFO> GetList()
        {
            return GetList<APP_INFO>();
        }

        public APP_INFO GetSingle(string id)
        {
            APP_INFO entity = new APP_INFO();
            using (var db = CreateDbBase())
            {
                var sql = SqlQuery<APP_INFO>.Builder(db)
                    .AndWhere(m => m.APP_ID, OperationMethod.Equal, id);
                entity = db.SingleOrDefault<APP_INFO>(sql);
            }
            return entity;
        }

        public bool GetIsExistAppKey(string appKey)
        {
            bool result = false;
            using (var db = CreateDbBase())
            {
                var sql = SqlQuery<APP_INFO>.Builder(db)
                    .AndWhere(m => m.APP_KEY, OperationMethod.Equal, appKey);
                result = db.SingleOrDefault<APP_INFO>(sql)==null?false:true;
            }
            return result;
        }

        public APP_INFO GetAppInfoByAppKey(string appKey)
        {
            APP_INFO entity = new APP_INFO();
            using (var db = CreateDbBase())
            {
                var sql = SqlQuery<APP_INFO>.Builder(db)
                    .AndWhere(m => m.APP_KEY, OperationMethod.Equal, appKey);
                entity = db.SingleOrDefault<APP_INFO>(sql);
            }
            return entity;
        }

        public bool Delete(string appID)
        {
            APP_INFO entity = new APP_INFO();
            entity.APP_ID = appID;
            return Delete<APP_INFO>(entity);
        }
    }
}
