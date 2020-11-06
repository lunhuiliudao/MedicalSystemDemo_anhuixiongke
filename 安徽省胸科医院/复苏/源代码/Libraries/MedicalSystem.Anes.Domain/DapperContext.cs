using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Domain
{
    public class DapperContext : IDisposable
    {
        /// <summary>
        /// 默认的数据库连接字符串名称
        /// </summary>
        private const string connectionStringName = "docare";
        private readonly string connectionString;
        private string providerName = null;
        private IDbConnection dbConnecttion;

        private DBType _dbType = DBType.Oracle;

        public DBType DbType
        {
            get
            {
                return _dbType;
            }
        }

        public DapperContext()
            : this(connectionStringName)
        {
        }

        public DapperContext(string connectionName)
        {
            var connSetting = ConfigurationManager.ConnectionStrings[connectionName];
            connectionString = connSetting.ConnectionString;
            if (!string.IsNullOrEmpty(connSetting.ProviderName))
                providerName = connSetting.ProviderName;
            else
                throw new Exception("ConnectionStrings中没有配置提供程序ProviderName！");

            InitDbConnection();
        }

        #region

        /// <summary>
        /// 初始化驱动
        /// </summary>
        public void InitDbConnection()
        {
            if (providerName.IndexOf("Devart", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                _dbType = DBType.DevertOracle;
            }
            else if (providerName.IndexOf("Oracle", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                _dbType = DBType.Oracle;
            }

                //else if (providerName.IndexOf("MySql", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    throw new ArgumentNullException("暂时没有添加该驱动！");
            //else if (providerName.IndexOf("SqlServerCe", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    //return new System.Data.SqlServerCe.SqlConnection(connectionString);
            //    throw new ArgumentNullException("暂时没有添加该驱动！");
            //else if (providerName.IndexOf("Npgsql", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    throw new ArgumentNullException("暂时没有添加该驱动！");
            //else if (providerName.IndexOf("SQLite", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    throw new ArgumentNullException("暂时没有添加该驱动！");
            else if (providerName.IndexOf("SqlClient", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                _dbType = DBType.SqlServer;
            }
            else
                throw new ArgumentNullException(providerName, "暂时没有添加该驱动！");
        }

        #endregion

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
                dbConnecttion = GetConnection(providerName, connectionString);

                return dbConnecttion;
            }
        }
        public string ProviderName
        {
            get
            {
                return providerName;
            }
        }

        public IDbConnection GetConnection(string providerName, string connectionString)
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
