using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateEntity;
using DapperEx;

namespace UpdateDAL
{
    public class VerDAL:BaseDAL
    {
        public bool Insert(VER_INFO verInfo)
        {
            return Insert<VER_INFO>(verInfo);
        }

        public bool Update(VER_INFO verInfo)
        {
            return Update<VER_INFO>(verInfo);
        }

        public bool UpdateRollBack(VER_INFO verInfo)
        {
            using (var db = CreateDbBase())
            {
                string sql = @"UPDATE VER_INFO SET ROLL_BACK = @ROLL_BACK, ROLL_BACK_DESC = @ROLL_BACK_DESC, MODIFYER = @MODIFYER, MODIFY_TIME = @MODIFY_TIME WHERE VER_ID=@VER_ID";
                return db.UpdateSql(sql, verInfo);
            }
        }

        /// <summary>
        /// 通appID按最大版本号取实体
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        public VER_INFO GetVER_InfoByMaxNo(string appID)
        {
            using (var db = CreateDbBase())
            {
                SqlQuery sql = SqlQuery<VER_INFO>.Builder(db)
                   .AndWhere(m => m.APP_ID, OperationMethod.Equal, appID)
                   .OrderBy(m => m.VER_NO, true);
                VER_INFO model = db.SingleOrDefault<VER_INFO>(sql);
                return model;
            }
        }

        public int GetAppVerion(string appID)
        {
            using (var db = CreateDbBase())
            {
                var model = GetVER_InfoByMaxNo(appID);
                int no = 1000;
                if (model != null)
                    no = model.VER_NO+1;
                return no;
            }
        }

        public VER_INFO GetSingle(string id)
        {
            VER_INFO entity = new VER_INFO();
            using (var db = CreateDbBase())
            {
                var sql = SqlQuery<VER_INFO>.Builder(db)
                    .AndWhere(m => m.VER_ID, OperationMethod.Equal, id);
                entity = db.SingleOrDefault<VER_INFO>(sql);
            }
            return entity;
        }

        public List<VER_LIST> GetList(string appID)
        {
            List<VER_LIST> list =new List<VER_LIST>();
            using (var db = CreateDbBase())
            {
                var sql = @"SELECT A.*,B.APP_KEY,B.APP_NAME,C.DOWNLOAD_NUM,C.UPDATED_NUM FROM VER_INFO A
LEFT JOIN APP_INFO B ON A.APP_ID=B.APP_ID
LEFT JOIN (SELECT R.VER_ID,SUM(R.IS_DOWNLOAD) DOWNLOAD_NUM,SUM(R.IS_UPDATED) UPDATED_NUM FROM VER_UPDATE_REC R
GROUP BY R.VER_ID) C ON A.VER_ID=C.VER_ID 
WHERE 1=1 ";
                var dynamicParams = new DynamicParameters();
                if (!string.IsNullOrEmpty(appID))
                {
                    sql += "AND A.APP_ID=@APP_ID";
                    dynamicParams.Add("APP_ID", appID);
                }
                list = db.QuerySQL<VER_LIST>(sql,dynamicParams).ToList();
            }
            return list.OrderBy(p=>p.APP_KEY).ToList().OrderByDescending(p=>p.VER_NO).ToList();
        }

        public List<VER_INFO> GetAllList(string appID)
        {
            using (var db = CreateDbBase())
            {
                SqlQuery sql = SqlQuery<VER_INFO>.Builder(db)
                   .AndWhere(m => m.APP_ID, OperationMethod.Equal, appID)
                   .OrderBy(m => m.VER_NO, true);
                List<VER_INFO> model = db.Query<VER_INFO>(sql).ToList();
                return model;
            }
        }

        public VER_INFO GetVer_InfoByAppIDAndVerion(string appID, string verion)
        {
            using (var db = CreateDbBase())
            {
                SqlQuery sql = SqlQuery<VER_INFO>.Builder(db)
                   .AndWhere(m => m.APP_ID, OperationMethod.Equal, appID)
                   .AndWhere(m=>m.VER_NO,OperationMethod.Equal,verion)
                   .OrderBy(m => m.VER_NO, true);
                VER_INFO model = db.SingleOrDefault<VER_INFO>(sql);
                return model;
            }
        }

        public List<VER_INFO> GetListByAppIDAndVerio(string appID, string verion, string isTest)
        {
            using (var db = CreateDbBase())
            {
                var sql = @"SELECT * FROM VER_INFO WHERE APP_ID = '"+ appID + "' AND VER_NO >= "+ verion + " ORDER BY VER_NO ASC";
                if(isTest!="1")
                    sql = @"SELECT * FROM VER_INFO WHERE APP_ID = '" + appID + "' AND VER_NO >= " + verion + " AND (IS_TEST <> 1 OR IS_TEST IS NULL) ORDER BY VER_NO ASC";

                List<VER_INFO> model = db.QuerySQL<VER_INFO>(sql, null).ToList();
                return model;
            }
        }

        public bool UpdateVerInfoByForcibly(string verionID)
        {
            VER_INFO entity = GetSingle(verionID);
            entity.IS_FORCIBLY = 1;
            return Update<VER_INFO>(entity);
        }

        public bool UpdateVerInfoByPublish(string verionID)
        {
            VER_INFO entity = GetSingle(verionID);
            entity.IS_TEST = 0;
            return Update<VER_INFO>(entity);
        }

        public bool Delete(string verionID)
        {
            VER_INFO entity = new VER_INFO();
            entity.VER_ID = verionID;
            return Delete<VER_INFO>(entity);
        }
    }
}
