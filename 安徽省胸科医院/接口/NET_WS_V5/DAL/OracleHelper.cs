using System;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Data.OracleClient;

namespace MedicalSytem.Soft.DAL
{
    public class OracleHelper
    {
        //数据库连接字符串
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        // 用于缓存参数的HASH表
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        ///  给定连接的数据库用假设参数执行一个Oracle命令（不返回数据集）
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者Oracle命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, string cmdText, params OracleParameter[] commandParameters)
        {

            OracleCommand cmd = new OracleCommand();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {

                PrepareCommand(cmd, connection, null, CommandType.Text, cmdText, commandParameters);
               
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        ///  给定连接的数据库用假设参数执行一个Oracle命令（不返回数据集）
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者Oracle命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {

            OracleCommand cmd = new OracleCommand();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {

                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        ///使用现有的Oracle事务执行一个Oracle命令（不返回数据集）--最后记得trans.Commit()
        /// </summary>
        /// <remarks>
        ///举例:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter(":prodid", 24));
        /// </remarks>
        /// <param name="trans">一个现有的事务</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者Oracle命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(OracleTransaction trans, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 用现有的数据库连接执行一个Oracle命令（不返回数据集）
        /// </summary>
        /// <param name="conn">一个现有的数据库连接</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者Oracle命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
        public static int ExecuteNonQuery(OracleConnection connection, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {

            OracleCommand cmd = new OracleCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的Oracle命令
        /// </summary>
        /// <remarks>
        /// 举例:  
        ///  OracleDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter(":prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者Oracle命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static OracleDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {

            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(connectionString);

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                OracleDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;

            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的Oracle命令
        /// </summary>
        /// <remarks>
        /// 举例:  
        ///  OracleDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter(":prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者Oracle命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {

            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(connectionString);
            try
            {
                DataSet ds = new DataSet();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                oda.Fill(ds);
                return ds;

            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的Oracle命令
        /// </summary>
        /// <remarks>
        /// 举例:  
        ///  OracleDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter(":prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者Oracle命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static OracleDataReader ExecuteReader(OracleConnection conn, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {

            OracleCommand cmd = new OracleCommand();

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                OracleDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;

            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        ///例如:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter(":prodid", 24));
        /// </remarks>
        ///<param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者Oracle命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand cmd = new OracleCommand();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        ///例如:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter(":prodid", 24));
        /// </remarks>
        ///<param name="connectionString">一个现有的数据库连接</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者Oracle命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
        public static object ExecuteScalar(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked	or commited, please	provide	an open	transaction.", "transaction");

            OracleCommand cmd = new OracleCommand();

            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

            object retval = cmd.ExecuteScalar();

            cmd.Parameters.Clear();
            return retval;
        }

        /// <summary>
        /// 将参数集合添加到缓存
        /// </summary>
        /// <param name="cacheKey">添加到缓存的变量</param>
        /// <param name="cmdParms">一个将要添加到缓存的Oracle参数集合</param>
        public static void CacheParameters(string cacheKey, params OracleParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 找会缓存参数集合
        /// </summary>
        /// <param name="cacheKey">用于找回参数的关键字</param>
        /// <returns>缓存的参数集合</returns>
        public static OracleParameter[] GetCachedParameters(string cacheKey)
        {
            OracleParameter[] cachedParms = (OracleParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            OracleParameter[] clonedParms = new OracleParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (OracleParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">Oracle命令</param>
        /// <param name="conn">Oracle连接</param>
        /// <param name="trans">Oracle事务</param>
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] commandParameters)
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
                foreach (OracleParameter parm in commandParameters)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}
