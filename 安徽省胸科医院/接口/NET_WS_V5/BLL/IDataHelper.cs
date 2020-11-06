using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections;
using System.Configuration;

namespace BLL
{
    public abstract class IDataHelper
    {
        public string Connection = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        public   Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        public   virtual void CacheParameters(string cacheKey, params DbParameter[] commandParameters)
        {
           
        }

        public   virtual DbParameter[] GetCachedParameters(string cacheKey)
        {
            return
              null;
        }

        public virtual int ExecuteNonQuery(DbCommand dbcommand)
        {
            return 0;
        }

        public   virtual int ExecuteNonQuery(CommandType cmdType, string cmdText, string connectionString = null, params DbParameter[] commandParameters)
        {
            return 0;
        }
        public   virtual int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            return 0;
        }
        public   virtual int ExecuteNonQuery(DbConnection connection, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            return 0;
        }
        public   virtual DbDataReader ExecuteReader(CommandType cmdType, string cmdText, string connectionStrin = null, params DbParameter[] commandParameters)
        {
            return null;
        }
        public   virtual DataSet GetDataSet(CommandType cmdType, string cmdText, string connectionString = null, params DbParameter[] commandParameters)
        {
            return null;
        }
        public   virtual DbDataReader ExecuteReader(DbConnection conn, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            return null;
        }
        public   virtual object ExecuteScalar(CommandType cmdType, string cmdText, string connectionString = null, params  DbParameter[] commandParameters)
        {
            return null;
        }
        public   virtual object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            return null;
        }
    }
}