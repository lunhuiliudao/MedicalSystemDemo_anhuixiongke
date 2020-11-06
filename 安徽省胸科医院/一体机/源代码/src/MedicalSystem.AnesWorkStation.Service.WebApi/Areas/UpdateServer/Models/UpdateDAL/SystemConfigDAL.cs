using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateEntity;
using DapperEx;

namespace UpdateDAL
{
    public class SystemConfigDAL:BaseDAL
    {
        public bool Insert(SYSTEM_CONFIG systemConfig)
        {
            return Insert<SYSTEM_CONFIG>(systemConfig);
        }

        public bool Update(SYSTEM_CONFIG systemConfig)
        {
            return Update<SYSTEM_CONFIG>(systemConfig);
        }

        public SYSTEM_CONFIG GetSingleTopOn()
        {
            SYSTEM_CONFIG entity = new SYSTEM_CONFIG();
            using (var db = CreateDbBase())
            {
                var sql = SqlQuery<SYSTEM_CONFIG>.Builder(db);
                entity = db.SingleOrDefault<SYSTEM_CONFIG>(sql);
            }
            return entity;
        }
    }
}
