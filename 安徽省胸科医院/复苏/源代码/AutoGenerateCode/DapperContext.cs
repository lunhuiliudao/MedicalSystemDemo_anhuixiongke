using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AutoGenerateCode
{
    public class DapperContext : IDisposable
    {
        private readonly string connectionString;
        private IDbConnection dbConnecttion;

        private DBType _dbType = DBType.Oracle;

        public DapperContext(string connectionsStr)
        {
            connectionString = connectionsStr;
        }

        /// <summary>
        /// 返回数据库连接操作，并打开连接，等待执行脚步。
        /// 推荐使用方法如下： using (var dbConn = DbContext.Instance.DbConnecttion) { ... };
        /// 便于释放资源。
        /// </summary>
        public IDbConnection DbConnecttion
        {
            get
            {
                dbConnecttion = null;
                dbConnecttion = GetConnection(connectionString);

                return dbConnecttion;
            }
        }

        public IDbConnection GetConnection(string connectionString)
        {
            switch (_dbType)
            {
                case DBType.SqlServer:
                    return new System.Data.SqlClient.SqlConnection(connectionString);
                case DBType.Oracle:
#pragma warning disable 0618
                    return new System.Data.OracleClient.OracleConnection(connectionString);
                case DBType.DevertOracle:
                    return new Devart.Data.Oracle.OracleConnection(connectionString);
                case DBType.SQLite:
                case DBType.SqlServerCE:
                case DBType.MySql:
                case DBType.PostgreSQL:
                default:
                    throw new ArgumentNullException("providerName");
            }
        }

        public void Dispose()
        {
            if (dbConnecttion != null)
            {
                try
                {
                    if (dbConnecttion.State != ConnectionState.Closed)
                        dbConnecttion.Close();
                    dbConnecttion.Dispose();
                    dbConnecttion = null;
                }
                catch { }
            }
        }

    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DBType
    {
        SqlServer,
        SqlServerCE,
        MySql,
        PostgreSQL,
        Oracle,
        DevertOracle,
        SQLite
    }

}
