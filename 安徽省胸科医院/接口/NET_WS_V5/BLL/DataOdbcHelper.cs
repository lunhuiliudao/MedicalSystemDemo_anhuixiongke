using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DataOdbcHelper : IDataHelper
    {
        public readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public override int ExecuteNonQuery(System.Data.CommandType cmdType, string cmdText, string connectionString = null, params System.Data.Common.DbParameter[] commandParameters)
        {
            return -1;
        }

        public override int ExecuteNonQuery(System.Data.Common.DbCommand dbcommand)
        {
            int val = dbcommand.ExecuteNonQuery();
            dbcommand.Parameters.Clear();
            return val;
        }

        public override int ExecuteNonQuery(System.Data.Common.DbConnection connection, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            return -1;
        }

        public override int ExecuteNonQuery(System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            return base.ExecuteNonQuery(trans, cmdType, cmdText, commandParameters);
        }

        public override System.Data.Common.DbDataReader ExecuteReader(System.Data.CommandType cmdType, string cmdText, string connectionStrin = null, params System.Data.Common.DbParameter[] commandParameters)
        {
            return base.ExecuteReader(cmdType, cmdText, connectionStrin, commandParameters);
        }

        public override System.Data.Common.DbDataReader ExecuteReader(System.Data.Common.DbConnection conn, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            return base.ExecuteReader(conn, cmdType, cmdText, commandParameters);
        }

        public override object ExecuteScalar(System.Data.CommandType cmdType, string cmdText, string connectionString = null, params System.Data.Common.DbParameter[] commandParameters)
        {
            return base.ExecuteScalar(cmdType, cmdText, connectionString, commandParameters);
        }

        public override object ExecuteScalar(System.Data.Common.DbTransaction transaction, System.Data.CommandType commandType, string commandText, params System.Data.Common.DbParameter[] commandParameters)
        {
            return base.ExecuteScalar(transaction, commandType, commandText, commandParameters);
        }

        public override System.Data.DataSet GetDataSet(System.Data.CommandType cmdType, string cmdText, string connectionString = null, params System.Data.Common.DbParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = ConnectionString;
            }

            DataSet ds = new DataSet();
            OdbcCommand cmd = new OdbcCommand();
            OdbcConnection conn = new OdbcConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                OdbcDataAdapter oda = new OdbcDataAdapter(cmd);
                oda.Fill(ds);
                cmd.Parameters.Clear();
                conn.Dispose();
                conn.Close();
                return ds;

            }
            catch
            {
                conn.Dispose();
                conn.Close();
                throw;
            }
        }

        public override void CacheParameters(string cacheKey, params System.Data.Common.DbParameter[] commandParameters)
        {
            base.CacheParameters(cacheKey, commandParameters);
        }

        public override System.Data.Common.DbParameter[] GetCachedParameters(string cacheKey)
        {
            return base.GetCachedParameters(cacheKey);
        }


        void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction trans, CommandType cmdType, string cmdText, DbParameter[] commandParameters)
        {

            //Open the connection if required
            if (conn.State != ConnectionState.Open)
                conn.Open();

            //Set up the command
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            //Bind it to the transaction if it exists
            if (trans != null)
                cmd.Transaction = trans;

            // Bind the parameters passed in
            if (commandParameters != null)
            {
                foreach (OdbcParameter parm in commandParameters)
                    cmd.Parameters.Add(parm);
            }
        }
    }


}
