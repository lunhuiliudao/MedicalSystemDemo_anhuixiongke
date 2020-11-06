using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Data.OracleClient;
using System.Configuration;
namespace InitDocare
{
    public class DbOracleData : DbAccess
    {
        new OracleCommand cmd = null;
        public DbOracleData()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            conn = new OracleConnection();
            conn.ConnectionString = ConnectionString;//Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["datasource"]);
            //conn.ConnectionString = "initial catalog=idyan_new;data source=.;user id=bt;password=btbtbtbt;Connect Timeout=5000";
            cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandTimeout = 0;

        }
        public DbOracleData(string constr)
        {

            //
            // TODO: 在此处添加构造函数逻辑
            //
            conn = new OracleConnection();
            //conn.ConnectionString = "initial catalog=pubs;data source=.;user id=sa;password=";
            //conn.ConnectionString = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["datasource"]);
            conn.ConnectionString = constr;// "initial catalog=idyan_new;data source=.;user id=bt;password=btbtbtbt";
            cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandTimeout = 0;

        }
        /// <summary>
        /// 获取数据根据Oracle语句 
        /// </summary>
        /// <param name="Oracle"></param>
        /// <returns></returns>
        public override DataTable GetTable(string sql)
        {
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch 
            {


                return null;

            }
            return ds.Tables[0] ?? new DataTable();
        }
        /// <summary>
        /// 获取数据根据sql语句 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
            }
            catch 
            {
                return null;
            }
            return ds;
        }
        /// <summary>
        /// 获取数据根据sql语句 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override DataSet GetDataSet(string sql, DbParameter[] pas)
        {
            DataSet ds = new DataSet();

            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = sql;
                foreach (OracleParameter pa in pas)
                {
                    cmd.Parameters.Add(pa);
                }
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
            }
            catch 
            {


                return null;

            }
            return ds;
        }
        /// <summary>
        /// 获取数据根据sql语句 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override DataSet GetProcDataSet(string sql, DbParameter[] pas)
        {
            DataSet ds = new DataSet();

            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = sql;
                foreach (OracleParameter pa in pas)
                {
                    cmd.Parameters.Add(pa);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
            }
            catch 
            {


                return null;

            }
            return ds;
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public override DataTable GetTable(string sql, params DbParameter[] pas)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                foreach (OracleParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }


                da.Fill(ds);
            }
            catch 
            {


                return null;
            }
            return ds.Tables[0] ?? new DataTable();
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public override DataTable GetProcTable(string procname, params DbParameter[] pas)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procname;
                //cmd.CommandText = sql;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                foreach (OracleParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }



                da.Fill(ds);
            }
            catch 
            {


                return null;
            }
            return ds.Tables[0] ?? new DataTable();
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public override DataTable GetProcCursorTable(string procname, params DbParameter[] pas)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procname;
                //cmd.CommandText = sql;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                foreach (OracleParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }



                da.Fill(ds);
            }
            catch 
            {


                return null;
            }
            return ds.Tables[1] ?? new DataTable();
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public override int GetProcState(string procname, params DbParameter[] pas)
        {
            int state = 0;
            try
            {
                OpenConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procname;
                cmd.Parameters.Clear();
                foreach (OracleParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }
                cmd.ExecuteNonQuery();
                CloseConn();
                state = Convert.ToInt32(pas[pas.Length - 1].Value);

            }
            catch
            {
                return 0;
            }
            return state;
        }
        /// <summary>
        /// 获取数据根据sql语句 带参数 的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public override int GetProcStateNo(string procname, params DbParameter[] pas)
        {
            int state = 0;
            try
            {
                OpenConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procname;
                cmd.Parameters.Clear();
                foreach (OracleParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }
                cmd.ExecuteNonQuery();
                CloseConn();
                state = 1;

                // state = Convert.ToInt32(pas[pas.Length - 1].Value);

            }
            catch
            {

                return 0;
            }
            return state;
        }
        /// <summary>
        /// 存储过程返回值的
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public override string GetProcStateReturnValue(string procname, params DbParameter[] pas)
        {
            string state = "";
            try
            {
                OpenConn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procname;
                cmd.Parameters.Clear();
                foreach (OracleParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }
                cmd.Parameters.AddWithValue("@Return_Value", "").Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                state = Convert.ToString(cmd.Parameters["@Return_Value"].Value);
                state = state == null ? ("") : (state);
                CloseConn();


                // state = Convert.ToInt32(pas[pas.Length - 1].Value);

            }
            catch
            {

                return "";
            }
            return state;
        }
        /// <summary>
        /// 根据sql语句返回跟新状态
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override bool GetState(string sql)
        {
            bool succ = false;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                OpenConn();
                succ = cmd.ExecuteNonQuery() > 0 ? (true) : (false);
                CloseConn();
            }
            catch 
            {


                return false;
            }
            return succ;

        }
        /// <summary>
        /// 根据sql语句返回跟新状态带参数的 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pas">参数的集合</param>
        /// <returns></returns>
        public override bool GetState(string sql, params DbParameter[] pas)
        {
            bool succ = false;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();

                foreach (OracleParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }
                OpenConn();
                succ = cmd.ExecuteNonQuery() > 0 ? (true) : (false);
                CloseConn();
            }
            catch
            {
                return false;
            }
            return succ;

        }
        /// <summary>
        /// 根据sql语句返回第一个单元格的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override string GetOne(string sql)
        {
            string res = "";
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                OpenConn();
                res = cmd.ExecuteScalar() == null ? ("") : (Convert.ToString(cmd.ExecuteScalar()));
                CloseConn();
            }
            catch 
            {


                return null;
            }
            return res;
        }
        /// <summary>
        ///  根据sql语句返回第一个单元格的数据带参数的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public override string GetOne(string sql, params DbParameter[] pas)
        {
            string res = "";
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();

                foreach (OracleParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }
                OpenConn();
                res = cmd.ExecuteScalar() == null ? ("") : (Convert.ToString(cmd.ExecuteScalar()));
                CloseConn();
            }
            catch 
            {
                CloseConn();

                return null;
            }
            return res;
        }
        /// <summary>
        /// 返回数据的DataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override DbDataReader GetDataReader(string sql)
        {
            OracleDataReader dr = null;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                conn.Open();
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch 
            {


                return null;
            }
            return dr;
        }
        /// <summary>
        /// 返回数据的DataReader带参数的 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public override DbDataReader GetDataReader(string sql, params DbParameter[] pas)
        {
            OracleDataReader dr = null;
            try
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.Clear();

                foreach (OracleParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }

                cmd.CommandText = sql;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch 
            {


                return null;
            }
            return dr;
        }
        /// <summary>
        /// 事务处理函数
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        public override bool GetTranState(ArrayList al)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            OpenConn();
            OracleTransaction tran = (conn as OracleConnection).BeginTransaction();
            cmd.Transaction = tran;
            try
            {
                for (int i = 0; i < al.Count; i++)
                {
                    cmd.CommandText = Convert.ToString(al[i]);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                CloseConn();
            }
            catch
            {

                tran.Rollback();
                CloseConn();
                return false;
            }
            return true;

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
        public override DataTable GetPageData(int current, int pagesize, string columns, string tablename, string pid, string where, string order)
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
        public override DataTable GetProcPageData(int current, int pagesize, string columns, string tablename, string pid, string where, string order, string ordertype)
        {
            OracleParameter[] pas = { new OracleParameter("@PageIndex", current), new OracleParameter("@PageSize", pagesize), new OracleParameter("@Columns", columns), new OracleParameter("@Tablename", tablename), new OracleParameter("@Where", where), new OracleParameter("@Order", order), new OracleParameter("@OrderType", ordertype), new OracleParameter("@Pid", pid) };
            return GetProcTable("Pages", pas);
            //current = current - 1 >= 0 ? (current - 1) : (0);
            //string sql = string.Format("select top {0} {1} from {2} where 1=1 and {3} not in(select top {4}{3} from {2} where 1=1{5}  order by {6}){5} order by {6}", pagesize, columns, tablename, pid, current * pagesize, where, order);
            //return GetTable(sql);
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
        public override DataTable GetProcData(int current, int pagesize, string columns, string tablename, string pid, string where, string order, string resultCount, string distinct)
        {
            OracleParameter[] pas = { new OracleParameter("@TableNames", OracleType.NVarChar, 200), new OracleParameter("@PrimaryKey", OracleType.NVarChar, 100), new OracleParameter("@Order", OracleType.NVarChar, 200), new OracleParameter("@CurrentPage", OracleType.Number), new OracleParameter("@PageSize", OracleType.Number), new OracleParameter("@Fields", OracleType.NVarChar, 800), new OracleParameter("@Filter", OracleType.NVarChar, 1000), new OracleParameter("@ResultCount", OracleType.NVarChar, 12), new OracleParameter("@distinct", OracleType.NVarChar, 12) };
            pas[0].Value = tablename;
            pas[1].Value = pid;
            pas[2].Value = order;
            pas[3].Value = current;
            pas[4].Value = pagesize;
            pas[5].Value = columns;
            pas[6].Value = where;
            pas[7].Value = resultCount;
            pas[8].Value = distinct;
            return this.GetProcTable("Pages", pas);
       
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
        public override DataTable GetProcAdminData(int current, int pagesize, string columns, string tablename, string pid, string where, string order, string resultCount, string distinct)
        {
            OracleParameter[] pas = { new OracleParameter("@TableNames", OracleType.NVarChar, 200), new OracleParameter("@PrimaryKey", OracleType.NVarChar, 100), new OracleParameter("@Order", OracleType.NVarChar, 200), new OracleParameter("@CurrentPage", OracleType.Number), new OracleParameter("@PageSize", OracleType.Number), new OracleParameter("@Fields", OracleType.NVarChar, 800), new OracleParameter("@Filter", OracleType.NVarChar, 200), new OracleParameter("@ResultCount", OracleType.NVarChar, 24), new OracleParameter("@Distinct", OracleType.NVarChar, 12) };
            pas[0].Value = tablename;
            pas[1].Value = pid;
            pas[2].Value = order;
            pas[3].Value = current;
            pas[4].Value = pagesize;
            pas[5].Value = columns;
            pas[6].Value = where;
            pas[7].Value = resultCount;
            pas[8].Value = distinct;
            return this.GetProcTable("Pages", pas);

        }
        public override DbParameter[] MakeParameters(params string[] str)
        {
            OracleParameter[] pas = new OracleParameter[str.Length / 2];
            for (int i = 0; i < str.Length / 2; i++)
            {
                pas[i] = new OracleParameter(string.Format(":{0}", str[2 * i]), str[2 * i + 1]);
            }
            return pas;
        }
     
    }
}
