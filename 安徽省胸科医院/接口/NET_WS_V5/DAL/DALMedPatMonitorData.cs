using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using MedicalSytem.Soft.DAL;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.OracleClient;

namespace MedicalSytem.Soft.DAL
{
    public class DALMedPatMonitorData
    {
        public DataSet SelectMedPatMonitorData(string patientid, decimal visitid, decimal operid, string dbtype, string connstr)
        {

            DataSet ds = null;

            string sql = "select * from MED_PAT_MONITOR_DATA where patient_id='" + patientid + "' and visit_id=" + visitid + " and oper_id=" + operid + "";
            if (dbtype == "sql")
            {
                ds = SqlHelper.GetDataSet(connstr, CommandType.Text, sql, null);
            }
            else if (dbtype == "ole")
            {
                ds = OleDbHelper.GetDataSet(connstr, CommandType.Text, sql, null);
            }
            else if (dbtype == "oracle")
            {
                ds = OracleHelper.GetDataSet(connstr, CommandType.Text, sql, null);
            }
            
            return ds;
        }

        
        public List<MedPatMonitorData> SelectMedPatMonitorDataNew(string patientid, decimal visitid, decimal operid, string dbtype)
        {
            DataSet ds = null;
            string sql = "select PATIENT_ID,VISIT_ID,OPER_ID ,TIME_POINT,ITEM_CODE,ITEM_NAME,ITEM_VALUE,UNITS,MONITOR_LABEL,LOG_DATE_TIME,DATA_TYPE from MED_PAT_MONITOR_DATA WHERE patient_id='" + patientid + "' and visit_id=" + visitid + " and oper_id=" + operid + "";
            if (dbtype == "sql")
            {
                ds = SqlHelper.GetDataSet(SqlHelper.ConnectionString, CommandType.Text, sql, null);
            }
            else if (dbtype == "ole")
            {
                ds = OleDbHelper.GetDataSet(OleDbHelper.ConnectionString, CommandType.Text, sql, null);
            }
            else if (dbtype == "oracle")
            {
                ds = OracleHelper.GetDataSet(OracleHelper.ConnectionString, CommandType.Text, sql, null);
            }
            else
            {
                return null;
            }

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }


            List<MedPatMonitorData> patExtList = new List<MedPatMonitorData>();


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedPatMonitorData entity = new MedPatMonitorData();
                entity.PatientId = patientid;
                entity.VisitId = visitid;
                entity.OperId = operid;
                entity.LogDateTime = DateTime.Parse(dr["LOG_DATE_TIME"].ToString());
                entity.TimePoint = DateTime.Parse(dr["TIME_POINT"].ToString());
                entity.ItemCode = dr["ITEM_CODE"].ToString();
                entity.ItemName = dr["ITEM_NAME"].ToString();
                entity.ItemValue = dr["ITEM_VALUE"].ToString();
                entity.DataType = dr["Data_Type"].ToString();
                entity.MonitorLabel = dr["Monitor_Label"].ToString();

               
                entity.Units = dr["units"].ToString();
                patExtList.Add(entity);
            }

            return patExtList;
        }
        public string docaredbtype = System.Configuration.ConfigurationManager.AppSettings["DataServerType"].ToString();

        public int InsertNew(string sql, string dbtype)
        {
            try
            {
               
                if (docaredbtype.ToUpper().IndexOf("SQL") >= 0)
                {
                    return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, sql, null);
                }
                if (docaredbtype.ToUpper().IndexOf("OLE") >= 0)
                {
                    sql = "begin " + sql + " end;";  
                    return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, sql, null);
                }
                if (docaredbtype.ToUpper() == "ORACLE")
                {
                    sql  = "begin " + sql + " end;";
                   
                    return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, CommandType.Text, sql, null);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }

    public class DALMedPatMonitorDataExt
    {
        public List<MedPatMonitorDataEXT> SelectMedPatMonitorDataExtOle(string patientid, decimal visitid, decimal operid, string dbtype, string connstr)
        {
            DataSet ds = null;
            string sql = "select PATIENT_ID,VISIT_ID,OPER_ID , RECORDING_DATE AS LAST_MODIFY_DATE,TIME_POINT,ITEM_CODE,ITEM_NAME,ITEM_VALUE,OPERATOR, '' RESERVED1,'' RESERVED2,'' RESERVED3, '' RESERVED4, '' DATA_TYPE from MED_PAT_MONITOR_DATA_EXT WHERE patient_id='" + patientid + "' and visit_id=" + visitid + " and oper_id=" + operid + " and memo is null ";
            if (dbtype == "sql")
            {
                ds = SqlHelper.GetDataSet(connstr, CommandType.Text, sql, null);
            }
            else if (dbtype == "ole")
            {
                ds = OleDbHelper.GetDataSet(connstr, CommandType.Text, sql, null);
            }
            else if (dbtype == "oracle")
            {
                ds = OracleHelper.GetDataSet(connstr, CommandType.Text, sql, null);
            }
            else
            {
                return null;
            }
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            List<MedPatMonitorDataEXT> patExtList = new List<MedPatMonitorDataEXT>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedPatMonitorDataEXT entity = new MedPatMonitorDataEXT();
                entity.PatientId = patientid;
                entity.VisitId = visitid;
                entity.OperId = operid;
                entity.LastModifyDate = DateTime.Parse(dr["LAST_MODIFY_DATE"].ToString());
                entity.TimePoint = DateTime.Parse(dr["TIME_POINT"].ToString());
                entity.ItemCode = dr["ITEM_CODE"].ToString();
                entity.ItemName = dr["ITEM_NAME"].ToString();
                entity.ItemValue = dr["ITEM_VALUE"].ToString();
                entity.DataMark = 1;
                entity.DataType = dr["Data_Type"].ToString();
                entity.Operator = dr["Operator"].ToString();
                entity.Reserved1 = dr["Reserved1"].ToString();
                entity.Reserved2 = dr["Reserved2"].ToString();
                entity.Reserved3 = dr["Reserved3"].ToString();
                entity.Reserved4 = dr["Reserved4"].ToString();

                patExtList.Add(entity);
            }

            return patExtList;
        }


        public List<MedPatMonitorDataEXT> SelectMedPatMonitorDataExtNew(string patientid, decimal visitid, decimal operid, string dbtype, string connstr)
        {
            DataSet ds = null;
            string sql = "select PATIENT_ID,VISIT_ID,OPER_ID ,  LAST_MODIFY_DATE,TIME_POINT,ITEM_CODE,ITEM_NAME,ITEM_VALUE,OPERATOR,  RESERVED1,  RESERVED2,  RESERVED3,  RESERVED4,  DATA_TYPE,   from MED_PAT_MONITOR_DATA_EXT WHERE patient_id='" + patientid + "' and visit_id=" + visitid + " and oper_id=" + operid + " and memo=''";
            if (dbtype == "sql")
            {
                ds = SqlHelper.GetDataSet(connstr, CommandType.Text, sql, null);
            }
            else if (dbtype == "ole")
            {
                ds = OleDbHelper.GetDataSet(connstr, CommandType.Text, sql, null);
            }
            else if (dbtype == "oracle")
            {
                ds = OracleHelper.GetDataSet(connstr, CommandType.Text, sql, null);
            }
            else
            {
                return null;
            }

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }


            List<MedPatMonitorDataEXT> patExtList = new List<MedPatMonitorDataEXT>();


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedPatMonitorDataEXT entity = new MedPatMonitorDataEXT();
                entity.PatientId = patientid;
                entity.VisitId = visitid;
                entity.OperId = operid;
                entity.LastModifyDate = DateTime.Parse(dr["LAST_MODIFY_DATE"].ToString());
                entity.TimePoint = DateTime.Parse(dr["TIME_POINT"].ToString());
                entity.ItemCode = dr["ITEM_CODE"].ToString();
                entity.ItemName = dr["ITEM_NAME"].ToString();
                entity.ItemValue = dr["ITEM_VALUE"].ToString();
                entity.DataMark = 1;
                entity.DataType = dr["Data_Type"].ToString();
                entity.Operator = dr["Operator"].ToString();
                entity.Reserved1 = dr["Reserved1"].ToString();
                entity.Reserved2 = dr["Reserved2"].ToString();
                entity.Reserved3 = dr["Reserved3"].ToString();
                entity.Reserved4 = dr["Reserved4"].ToString();

                patExtList.Add(entity);
            }

            return patExtList;
        }

        public int UpdateOld(string sql, string dbtype, string connstr, DbTransaction dbtrans)
        {
            try
            {
                if (dbtype == "sql")
                {
                    SqlTransaction sqltrans = dbtrans as SqlTransaction;
                    return SqlHelper.ExecuteNonQuery(sqltrans, CommandType.Text, sql, null);
                }
                if (dbtype == "ole")
                {
                    sql = "begin " + sql + " end;";
                    OleDbTransaction oledbtrans = dbtrans as OleDbTransaction;
                    return OleDbHelper.ExecuteNonQuery(oledbtrans, CommandType.Text, sql, null);
                }
                if (dbtype == "oracle")
                {
                    sql = "begin " + sql + " end;";
                    OracleTransaction oracledbtrans = dbtrans as OracleTransaction;
                    return OracleHelper.ExecuteNonQuery(oracledbtrans, CommandType.Text, sql, null);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string docaredbtype = System.Configuration.ConfigurationManager.AppSettings["DataServerType"].ToString();

        public int InsertNew(string sql, string dbtype)
        {
            try
            {
                if (docaredbtype.ToUpper().IndexOf("SQL") >= 0)
                {
                    return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, sql, null);
                }
                if (docaredbtype.ToUpper().IndexOf("OLE") >= 0)
                {
                    sql = "begin " + sql + " end;";
                    return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, sql, null);
                }
                if (docaredbtype.ToUpper() == "ORACLE")
                {
                    sql = "begin " + sql + " end;";
                    return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, CommandType.Text, sql, null);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
