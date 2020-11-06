using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;
using System.Collections;
using System.Configuration;

namespace InitDocare
{
    public class DbOdbcDbData : DbAccess
    {

        new OdbcCommand cmd = null;
        public DbOdbcDbData()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            conn = new OdbcConnection();
            conn.ConnectionString = ConnectionString; //Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["datasource"]);
            //conn.ConnectionString = "initial catalog=idyan_new;data source=.;user id=bt;password=btbtbtbt;Connect Timeout=5000";
            cmd = new OdbcCommand();
            cmd.Connection = conn as OdbcConnection;
            cmd.CommandTimeout = 0;

        }
        public DbOdbcDbData(string constr)
        {

            //
            // TODO: 在此处添加构造函数逻辑
            //
            conn = new OdbcConnection();
            //conn.ConnectionString = "initial catalog=pubs;data source=.;user id=sa;password=";
            //conn.ConnectionString = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["datasource"]);
            conn.ConnectionString = constr;// "initial catalog=idyan_new;data source=.;user id=bt;password=btbtbtbt";
            cmd = new OdbcCommand();
            cmd.Connection = conn as OdbcConnection;
            cmd.CommandTimeout = 0;

        }
        /// <summary>
        /// 获取数据根据OdbcDb语句 
        /// </summary>
        /// <param name="OdbcDb"></param>
        /// <returns></returns>
        public override DataTable GetTable(string sql)
        {
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandText = GetCurrentDbSql(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                OdbcDataAdapter da = new OdbcDataAdapter();
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
                OdbcDataAdapter da = new OdbcDataAdapter();
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
                foreach (OdbcParameter pa in pas)
                {
                    cmd.Parameters.Add(pa);
                }
                cmd.CommandType = CommandType.Text;
                OdbcDataAdapter da = new OdbcDataAdapter();
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
                foreach (OdbcParameter pa in pas)
                {
                    cmd.Parameters.Add(pa);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                OdbcDataAdapter da = new OdbcDataAdapter();
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
                OdbcDataAdapter da = new OdbcDataAdapter();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                foreach (OdbcParameter temppa in pas)
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
                OdbcDataAdapter da = new OdbcDataAdapter();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                foreach (OdbcParameter temppa in pas)
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
                OdbcDataAdapter da = new OdbcDataAdapter();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                foreach (OdbcParameter temppa in pas)
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
                foreach (OdbcParameter temppa in pas)
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
                foreach (OdbcParameter temppa in pas)
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
                foreach (OdbcParameter temppa in pas)
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

                foreach (OdbcParameter temppa in pas)
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

                foreach (OdbcParameter temppa in pas)
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
            OdbcDataReader dr = null;
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
            OdbcDataReader dr = null;
            try
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.Clear();

                foreach (OdbcParameter temppa in pas)
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
            OdbcTransaction tran = (conn as OdbcConnection).BeginTransaction();
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
            OdbcParameter[] pas = { new OdbcParameter("@PageIndex", current), new OdbcParameter("@PageSize", pagesize), new OdbcParameter("@Columns", columns), new OdbcParameter("@Tablename", tablename), new OdbcParameter("@Where", where), new OdbcParameter("@Order", order), new OdbcParameter("@OrderType", ordertype), new OdbcParameter("@Pid", pid) };
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
            OdbcParameter[] pas = { new OdbcParameter("@TableNames", OdbcType.VarChar, 200), new OdbcParameter("@PrimaryKey", OdbcType.VarChar, 100), new OdbcParameter("@Order", OdbcType.VarChar, 200), new OdbcParameter("@CurrentPage", OdbcType.Int), new OdbcParameter("@PageSize", OdbcType.Int), new OdbcParameter("@Fields", OdbcType.VarChar, 800), new OdbcParameter("@Filter", OdbcType.VarChar, 1000), new OdbcParameter("@ResultCount", OdbcType.VarChar, 12), new OdbcParameter("@distinct", OdbcType.VarChar, 12) };
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
            OdbcParameter[] pas = { new OdbcParameter("@TableNames", OdbcType.VarChar, 200), new OdbcParameter("@PrimaryKey", OdbcType.VarChar, 100), new OdbcParameter("@Order", OdbcType.VarChar, 200), new OdbcParameter("@CurrentPage", OdbcType.Int), new OdbcParameter("@PageSize", OdbcType.Int), new OdbcParameter("@Fields", OdbcType.VarChar, 800), new OdbcParameter("@Filter", OdbcType.VarChar, 200), new OdbcParameter("@ResultCount", OdbcType.VarChar, 24), new OdbcParameter("@Distinct", OdbcType.VarChar, 12) };
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
            OdbcParameter[] pas = new OdbcParameter[str.Length / 2];
            for (int i = 0; i < str.Length / 2; i++)
            {
                pas[i] = new OdbcParameter(string.Format("@{0}", str[2 * i]), str[2 * i + 1]);
            }
            return pas;
        }
        public string GetCurrentDbSql(string sql)
        {
            return System.Text.RegularExpressions.Regex.Replace(sql,":[^\\s,|\\+\\)]+","?");
        }
        

    }
}
