using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections;
using System.Configuration;

namespace InitDocare
{
    public class DbOleDbData : DbAccess
    {

        new OleDbCommand cmd = null;
        public DbOleDbData()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            conn = new OleDbConnection();
            conn.ConnectionString = ConnectionString; //Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["datasource"]);
            //conn.ConnectionString = "initial catalog=idyan_new;data source=.;user id=bt;password=btbtbtbt;Connect Timeout=5000";
            cmd = new OleDbCommand();
            cmd.Connection = conn as OleDbConnection;
            cmd.CommandTimeout = 0;

        }
        public DbOleDbData(string constr)
        {

            //
            // TODO: 在此处添加构造函数逻辑
            //
            conn = new OleDbConnection();
            //conn.ConnectionString = "initial catalog=pubs;data source=.;user id=sa;password=";
            //conn.ConnectionString = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["datasource"]);
            conn.ConnectionString = constr;// "initial catalog=idyan_new;data source=.;user id=bt;password=btbtbtbt";
            cmd = new OleDbCommand();
            cmd.Connection = conn as OleDbConnection;
            cmd.CommandTimeout = 0;

        }
        /// <summary>
        /// 获取数据根据OleDb语句 
        /// </summary>
        /// <param name="OleDb"></param>
        /// <returns></returns>
        public override DataTable GetTable(string sql)
        {
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandText = GetCurrentDbSql(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                OleDbDataAdapter da = new OleDbDataAdapter();
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
                cmd.CommandText = GetCurrentDbSql(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                OleDbDataAdapter da = new OleDbDataAdapter();
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
                cmd.CommandText = GetCurrentDbSql(sql);
                foreach (OleDbParameter pa in pas)
                {
                    cmd.Parameters.Add(pa);
                }
                cmd.CommandType = CommandType.Text;
                OleDbDataAdapter da = new OleDbDataAdapter();
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
                cmd.CommandText = GetCurrentDbSql(sql);
                foreach (OleDbParameter pa in pas)
                {
                    cmd.Parameters.Add(pa);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                OleDbDataAdapter da = new OleDbDataAdapter();
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
                cmd.CommandText = GetCurrentDbSql(sql);
                cmd.CommandType = CommandType.Text;
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                foreach (OleDbParameter temppa in pas)
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
                //cmd.CommandText = GetCurrentDbSql(sql);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                foreach (OleDbParameter temppa in pas)
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
                //cmd.CommandText = GetCurrentDbSql(sql);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                foreach (OleDbParameter temppa in pas)
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
                foreach (OleDbParameter temppa in pas)
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
                foreach (OleDbParameter temppa in pas)
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
                foreach (OleDbParameter temppa in pas)
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
                cmd.CommandText = GetCurrentDbSql(sql);
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
                cmd.CommandText = GetCurrentDbSql(sql);
                cmd.Parameters.Clear();

                foreach (OleDbParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }
                OpenConn();
                succ = cmd.ExecuteNonQuery() > 0 ? (true) : (false);
                CloseConn();
            }
            catch
            {

                // this.ShowError(ex.Message);
                //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\error2008.txt"))
                //{
                //    sw.Write(ex.Message);
                //    sw.Flush();
                //}
                return false;
            }
            return succ;

        }
        /// <summary>
        /// 根据GetCurrentDbSql(sql)语句返回第一个单元格的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override string GetOne(string sql)
        {
            string res = "";
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = GetCurrentDbSql(sql);
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
                cmd.CommandText = GetCurrentDbSql(sql);
                cmd.Parameters.Clear();

                foreach (OleDbParameter temppa in pas)
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
            OleDbDataReader dr = null;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                conn.Open();
                cmd.CommandText = GetCurrentDbSql(sql);
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
            OleDbDataReader dr = null;
            try
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.Clear();

                foreach (OleDbParameter temppa in pas)
                {
                    cmd.Parameters.Add(temppa);
                }

                cmd.CommandText = GetCurrentDbSql(sql);
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
            OleDbTransaction tran = (conn as OleDbConnection).BeginTransaction();
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
            OleDbParameter[] pas = { new OleDbParameter("@PageIndex", current), new OleDbParameter("@PageSize", pagesize), new OleDbParameter("@Columns", columns), new OleDbParameter("@Tablename", tablename), new OleDbParameter("@Where", where), new OleDbParameter("@Order", order), new OleDbParameter("@OrderType", ordertype), new OleDbParameter("@Pid", pid) };
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
            OleDbParameter[] pas = { new OleDbParameter("@TableNames", OleDbType.VarChar, 200), new OleDbParameter("@PrimaryKey", OleDbType.VarChar, 100), new OleDbParameter("@Order", OleDbType.VarChar, 200), new OleDbParameter("@CurrentPage", OleDbType.Integer), new OleDbParameter("@PageSize", OleDbType.Integer), new OleDbParameter("@Fields", OleDbType.VarChar, 800), new OleDbParameter("@Filter", OleDbType.VarChar, 1000), new OleDbParameter("@ResultCount", OleDbType.VarChar, 12), new OleDbParameter("@distinct", OleDbType.VarChar, 12) };
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
            OleDbParameter[] pas = { new OleDbParameter("@TableNames", OleDbType.VarChar, 200), new OleDbParameter("@PrimaryKey", OleDbType.VarChar, 100), new OleDbParameter("@Order", OleDbType.VarChar, 200), new OleDbParameter("@CurrentPage", OleDbType.Integer), new OleDbParameter("@PageSize", OleDbType.Integer), new OleDbParameter("@Fields", OleDbType.VarChar, 800), new OleDbParameter("@Filter", OleDbType.VarChar, 200), new OleDbParameter("@ResultCount", OleDbType.VarChar, 24), new OleDbParameter("@Distinct", OleDbType.VarChar, 12) };
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
            OleDbParameter[] pas = new OleDbParameter[str.Length / 2];
            for (int i = 0; i < str.Length / 2; i++)
            {
                pas[i] = new OleDbParameter(string.Format("@{0}", str[2 * i]), str[2 * i + 1]);
            }
            return pas;
        }
        public string GetCurrentDbSql(string sql)
        {
            return System.Text.RegularExpressions.Regex.Replace(sql,":[^\\s,|\\+\\)]+","?");
        }
        

    }
}
