using Entitys;
using NET_WS_V5.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NET_WS_V5.Controllers;
using System.Data.Odbc;

namespace NET_WS_V5.WebApi
{
    public class TransDictController : ApiController
    {
        DALMedIfTransDict dal = new DALMedIfTransDict();
        // GET api/<controller>
        public IEnumerable<MedIfTrans> Get()
        {
            return dal.SelectMedIfTransAll();
        }

        // GET api/<controller>/5
        public MedIfTrans Get(string id)
        {
            return dal.SelectMedIfTransAll().Find(p => p.TransName == id); ;
        }

        // POST api/<controller>
        public string Post([FromBody]MedIfTrans transEntity)
        {
            List<MedIfTrans> transAll = Get().ToList();
            if (transAll.Exists(p => p.TransName == transEntity.TransName))
            {
                return "已经存在此TransName";
            }
            transEntity.DbParm = getConn(transEntity);
            return dal.InsertMedIfTrans(transEntity);
        }

        private string getConn(MedIfTrans transEntity)
        {
            string conn = "";
            if (transEntity.DBMS == "SQLSERVER" || transEntity.DBMS == "SQLSVR2008")
            {
                conn = "Data Source = " + transEntity.ServerName + "; Initial Catalog = " + transEntity.DataBase + "; User Id = " + transEntity.LogId + "; Password = " + transEntity.LogPass + ";";
            }
            else if (transEntity.DBMS == "ORACLE")
            {
                conn = "Persist Security Info=True;Data Source=" + transEntity.ServerName + ";Password=" + transEntity.LogPass + ";User ID=" + transEntity.LogId + ";Unicode=True;";
            }
            else if (transEntity.DBMS == "ORAOLEDB")
            {
                conn = "Provider=MSDAORA;Data Source=" + transEntity.ServerName + ";Password=" + transEntity.LogPass + ";User ID=" + transEntity.LogId + ";";
            }
            else if (transEntity.DBMS == "ODBC")
            {
                conn = "Dsn=" + transEntity.ServerName + ";uid=" + transEntity.LogId + ";pwd=" + transEntity.LogPass + ";";
            }
            return conn;
        }

        private string Conn(MedIfTrans transEntity)
        {
            string conn = "";
            if (transEntity.DBMS == "SQLSERVER" || transEntity.DBMS == "SQLSVR2008")
            {
                conn = "Data Source = " + transEntity.ServerName + "; Initial Catalog = " + transEntity.DataBase + "; User Id = " + transEntity.LogId + "; Password = " + transEntity.LogPass + ";";
                return ConnSql(conn);
            }
            else if (transEntity.DBMS == "ORACLE")
            {
                conn = "Persist Security Info=True;Data Source=" + transEntity.ServerName + ";Password=" + transEntity.LogPass + ";User ID=" + transEntity.LogId + ";Unicode=True;";
                return ConnOracle(conn);
            }
            else if (transEntity.DBMS == "ORAOLEDB")
            {
                conn = "Provider=MSDAORA;Data Source=" + transEntity.ServerName + ";Password=" + transEntity.LogPass + ";User ID=" + transEntity.LogId + ";";
                return ConnOraOle(conn);
            }
            else if (transEntity.DBMS == "ODBC")
            {
                conn = "Dsn=" + transEntity.ServerName + ";uid=" + transEntity.LogId + ";pwd=" + transEntity.LogPass + ";";
                return ConnODBC(conn);
            }
            return "此数据库类型暂不支持连接测试";
        }
        //Persist Security Info=True;Data Source=ANESICU;Password=docare;User ID=system;Unicode=True;
        string ConnSql(string conn)
        {
            try
            {
                SqlConnection conns = new SqlConnection(conn);
                if (conns.State != System.Data.ConnectionState.Open)
                {
                    conns.Open();
                }
                conns.Dispose();
                return "连接成功";
            }
            catch (Exception ex)
            {
                return "连接失败：" + ex.Message;
            }
        }

        string ConnOracle(string conn)
        {
            try
            {
                OracleConnection conns = new OracleConnection(conn);

                if (conns.State != System.Data.ConnectionState.Open)
                {
                    conns.Open();
                }
                conns.Dispose();
                return "连接成功";
            }
            catch (Exception ex)
            {
                return "连接失败：" + ex.Message;
            }
        }

        string ConnOraOle(string conn)
        {
            try
            {
                OleDbConnection conns = new OleDbConnection(conn);
                if (conns.State != System.Data.ConnectionState.Open)
                {
                    conns.Open();
                }
                conns.Dispose();
                return "连接成功";
            }
            catch (Exception ex)
            {
                return "连接失败：" + ex.Message;
            }
        }

        string ConnODBC(string conn)
        {
            try
            {
                OdbcConnection conns = new OdbcConnection(conn);
                if (conns.State != System.Data.ConnectionState.Open)
                {
                    conns.Open();
                }
                conns.Dispose();
                return "连接成功";
            }
            catch (Exception ex)
            {
                return "连接失败：" + ex.Message;
            }
        }

        // PUT api/<controller>/5
        public string Put(string id, [FromBody]MedIfTrans transEntity)
        {
            if (string.IsNullOrEmpty(id)) ///测试操作 
            {
                return Conn(transEntity);
            }

            List<MedIfTrans> transAll = Get().ToList();  ///修改操作
            if (id == transEntity.TransName)
            {
                transEntity.DbParm = getConn(transEntity);
                return dal.UpdateMedIfTrans(transEntity, id);

            }
            if (transAll.Exists(p => p.TransName == transEntity.TransName))
            {
                return "已经存在此TransName";
            }
            else
            {
                transEntity.DbParm = getConn(transEntity);
                return dal.UpdateMedIfTrans(transEntity, id);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            dal.DeleteMedIfTrans(new MedIfTrans() { TransName = id });
        }
    }
}