using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;


namespace InitDocare
{
    public class DbAccess
    {

        private string _ConnectionString = "";
        public string ConnectionString
        {
            get {
                //return "Data Source=orcl;User Id=system;Password=manager;";
                _ConnectionString = string.IsNullOrEmpty(_ConnectionString) ? ("") : (_ConnectionString);
                string dataType = ConfigurationManager.AppSettings["DataServerType"].Trim();
                if (dataType == "OracleOLE" || dataType == "OraOLEDB")
                {
                   _ConnectionString= _ConnectionString.Length > 0 ? (_ConnectionString) : (Convert.ToString(ConfigurationManager.ConnectionStrings["OLEConnString"].ConnectionString ?? ""));
                }
                else if (dataType == "Oracle")
                {
                    _ConnectionString = _ConnectionString.Length > 0 ? (_ConnectionString) : (Convert.ToString(ConfigurationManager.ConnectionStrings["OraClientConnString"].ConnectionString ?? ""));
                }
                else if (dataType == "SQLServer")
                {
                    _ConnectionString = _ConnectionString.Length > 0 ? (_ConnectionString) : (Convert.ToString(ConfigurationManager.ConnectionStrings["SQLClientConnString"].ConnectionString ?? ""));
                }
                else if (dataType == "ODBC")
                {
                    _ConnectionString = _ConnectionString.Length > 0 ? (_ConnectionString) : (Convert.ToString(ConfigurationManager.ConnectionStrings["OdbcConnString"].ConnectionString ?? ""));
                }

                return _ConnectionString;
            }
        }
       public DbConnection conn = null;
       protected DbCommand cmd = null;
       public DbAccess()
       {

       }
       public DbAccess(string conn)
       {

       }
        /// <summary>
        /// 获取数据根据Oracle语句 
        /// </summary>
        /// <param name="Oracle"></param>
        /// <returns></returns>
        public virtual DataTable GetTable(string sql)
        {
          
            return  new DataTable();
        }
        /// <summary>
        /// 获取数据根据sql语句 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataSet GetDataSet(string sql)
        {
            return new DataSet();
        }
        /// <summary>
        /// 获取数据根据sql语句 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataSet GetDataSet(string sql, DbParameter[] pas)
        {
            return new DataSet();
        }
        /// <summary>
        /// 获取数据根据sql语句 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataSet GetProcDataSet(string sql, DbParameter[] pas)
        {
            return new DataSet();
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public virtual DataTable GetTable(string sql, params DbParameter[] pas)
        {
           return  new DataTable();
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public virtual DataTable GetProcTable(string procname, params DbParameter[] pas)
        {       
            return  new DataTable();
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public virtual DataTable GetProcCursorTable(string procname, params DbParameter[] pas)
        {
       
            return  new DataTable();
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public virtual int GetProcState(string procname, params DbParameter[] pas)
        {
            return 0;
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public virtual int GetProcStateNo(string procname, params DbParameter[] pas)
        {
            return 0;
        }
        /// <summary>
        /// 存储过程返回值的
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public virtual string GetProcStateReturnValue(string procname, params DbParameter[] pas)
        {    
                return "";         
        }
        /// <summary>
        /// 根据sql语句返回跟新状态
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual bool GetState(string sql)
        {
            return false;

        }
        /// <summary>
        /// 根据sql语句返回跟新状态带参数的 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pas">参数的集合</param>
        /// <returns></returns>
        public virtual bool GetState(string sql, params DbParameter[] pas)
        {
            return false;

        }
        /// <summary>
        /// 根据sql语句返回第一个单元格的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual string GetOne(string sql)
        {
         
            return "";
        }
        /// <summary>
        ///  根据sql语句返回第一个单元格的数据带参数的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public virtual string GetOne(string sql, params DbParameter[] pas)
        {
            return "";
        }
        /// <summary>
        /// 返回数据的DataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DbDataReader GetDataReader(string sql)
        {
           DbDataReader dr = null;
           
            return dr;
        }
        /// <summary>
        /// 返回数据的DataReader带参数的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public virtual DbDataReader GetDataReader(string sql, params DbParameter[] pas)
        {
            DbDataReader dr = null;
            
            return dr;
        }
        /// <summary>
        /// 事务处理函数
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        public virtual bool GetTranState(ArrayList al)
        {
            return false;

        }
        /// <summary>
        /// 事务处理函数
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        public virtual bool GetTranStateParameter(ArrayList al)
        {
            return false;

        }
        /// <summary>
        /// 分页函数
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="columns"></param>
        /// <param name="tablename"></param>
        /// <param name="pid"></param>
        /// <param name="order"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public virtual DataTable GetPageData(int current, int pagesize, string columns, string tablename, string pid, string where, string order)
        {
            current = current - 1 >= 0 ? (current - 1) : (0);
            string sql = string.Format("select top {0} {1} from {2} where 1=1 and {3} not in(select top {4}{3} from {2} where 1=1{5}  order by {6}){5} order by {6}", pagesize, columns, tablename, pid, current * pagesize, where, order);
            return GetTable(sql);

        }
        /// <summary>
        /// 分页存储过程的调用
        /// </summary>
        /// <param name="current"></param>
        /// <param name="pagesize"></param>
        /// <param name="columns"></param>
        /// <param name="tablename"></param>
        /// <param name="pid"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public virtual DataTable GetProcPageData(int current, int pagesize, string columns, string tablename, string pid, string where, string order, string ordertype)
        {
            return new DataTable();
        }
        /// <summary>
        /// 分页存储过程的调用
        /// </summary>
        /// <param name="current"></param>
        /// <param name="pagesize"></param>
        /// <param name="columns"></param>
        /// <param name="tablename"></param>
        /// <param name="pid"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public virtual DataTable GetProcData(int current, int pagesize, string columns, string tablename, string pid, string where, string order, string resultCount, string distinct)
        {
            return new DataTable();

        }
        /// <summary>
        /// 分页存储过程的调用
        /// </summary>
        /// <param name="current"></param>
        /// <param name="pagesize"></param>
        /// <param name="columns"></param>
        /// <param name="tablename"></param>
        /// <param name="pid"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public virtual DataTable GetProcAdminData(int current, int pagesize, string columns, string tablename, string pid, string where, string order, string resultCount, string distinct)
        {
            return new DataTable();

        }
        public virtual DbParameter[] MakeParameters(params string[] str)
        {
            return null;
        }
        /// <summary>
        /// 打开连接
        /// </summary>
        public void OpenConn()
        {
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {


                    throw ex;
                }
            }
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void CloseConn()
        {
            if (conn.State != ConnectionState.Closed)
            {
                try
                {
                    conn.Close();

                }
                catch (Exception ex)
                {


                    throw ex;
                }
            }
        }
        /// <summary>
        /// 销毁连接
        /// </summary>
        public void DisposeConn()
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    try
                    {
                        conn.Close();

                    }
                    catch (Exception ex)
                    {


                        throw ex;
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 获取数据库连接对象
        /// </summary>
        /// <param name="DataType"></param>
        /// <returns></returns>
        public DbAccess GetDbAccess()
        {
            DbAccess dbBase = null;
            string dataType = ConfigurationManager.AppSettings["DataServerType"].Trim();
            if (dataType == "OracleOLE" || dataType == "OraOLEDB")
            {
                dbBase = new DbOleDbData();
            }
            else if (dataType == "Oracle")
            {
                dbBase = new DbOracleData();
            }
            else if (dataType == "SQLServer")
            {
                dbBase = new DbSqlServerData();
            }
            else if (dataType == "ODBC")
            {
                dbBase = new DbOdbcDbData();
            }
            return dbBase;
        }

    }
}
