using DapperEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDAL
{
    public class BaseDAL
    {
        public string connectionName = "SQLite";
        public DbBase CreateDbBase()
        {
            return new DbBase(connectionName);
        }

        public bool Insert<T>(T t) where T : class
        {
            bool result = false;
            using (var db = CreateDbBase())
            {
                result = db.Insert<T>(t);
            }
            return result;
        }

        public bool Update<T>(T t) where T : class
        {
            bool result = false;
            using (var db = CreateDbBase())
            {
                result = db.Update<T>(t);
            }
            return result;
        }

        public bool Delete<T>(T t) where T : class
        {
            bool result = false;
            using (var db = CreateDbBase())
            {
                result = db.Delete<T>(t);
            }
            return result;
        }

        public bool Delete<T>(SqlQuery sql = null) where T : class
        {
            bool result = false;
            using (var db = CreateDbBase())
            {
                result = db.Delete<T>(sql);
            }
            return result;
        }

        public List<T> GetList<T>() where T : class
        {
            List<T> result = new List<T>();
            using (var db = CreateDbBase())
            {
                result = db.Query<T>().ToList() ;
            }
            return result;
        }
    }
}
