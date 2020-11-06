using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using NET_WS_V5;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedIfHisViewSql2
    {
        #region SELECT
        public List<MedIfHisViewSql2> GetMedIfHisView2Sql()
        {
            List<MedIfHisViewSql2> result = new List<MedIfHisViewSql2>();
            DataSet ds = new DataSet();
            string sqlselect = "select * from med_if_his_view_sql2";

            ds = SqlHelper.GetDataSet(SqlHelper.ConnectionString, CommandType.Text, sqlselect, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedIfHisViewSql2 entity = new MedIfHisViewSql2();
                entity.AppCode = dr["App_Code"].ToString();
                entity.TransName = dr["Trans_Name"].ToString();
                entity.SqlText = dr["Sql_Text"].ToString();
                entity.MedTableName = dr["Med_Table_name"].ToString();
                entity.DataSourceName = dr["Data_Source_Name"].ToString();
                entity.SqlPara = dr["Sql_Para"].ToString();
                entity.Description = dr["Description"].ToString();
                entity.CommandType = dr["CommandType"].ToString();
                result.Add(entity);
            }
            return result;
        }

        public List<MedIfHisViewSql2> GetMedIfHisView2()
        {
            List<MedIfHisViewSql2> result = new List<MedIfHisViewSql2>();
            DataSet ds = new DataSet();
            string sqlselect = "select * from med_if_his_view_sql";

            ds = OracleHelper.GetDataSet(OracleHelper.ConnectionString, CommandType.Text, sqlselect, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedIfHisViewSql2 entity = new MedIfHisViewSql2();
                entity.AppCode = dr["App_Code"].ToString();
                entity.TransName = dr["Trans_Name"].ToString();
                entity.SqlText = dr["Sql_Text"].ToString();
                entity.MedTableName = dr["Med_Table_name"].ToString();
                entity.DataSourceName = dr["Data_Source_Name"].ToString();
                entity.SqlPara = dr["Sql_Para"].ToString();
                entity.Description = dr["Description"].ToString();
                entity.CommandType = dr["CommandType"].ToString();
                result.Add(entity);
            }
            return result;
        }

        public List<MedIfHisViewSql2> GetMedIfHisView2OLE()
        {
            List<MedIfHisViewSql2> result = new List<MedIfHisViewSql2>();
            DataSet ds = new DataSet();
            string sqlselect = "select * from med_if_his_view_sql";

            ds = OleDbHelper.GetDataSet(OleDbHelper.ConnectionString, CommandType.Text, sqlselect, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedIfHisViewSql2 entity = new MedIfHisViewSql2();
                entity.AppCode = dr["App_Code"].ToString();
                entity.TransName = dr["Trans_Name"].ToString();
                entity.SqlText = dr["Sql_Text"].ToString();
                entity.MedTableName = dr["Med_Table_name"].ToString();
                entity.DataSourceName = dr["Data_Source_Name"].ToString();
                entity.SqlPara = dr["Sql_Para"].ToString();
                entity.Description = dr["Description"].ToString();
                entity.CommandType = dr["CommandType"].ToString();
                result.Add(entity);
            }
            return result;
        }

        #endregion

        #region Insert
        public int InsertMedIfHisView2(MedIfHisViewSql2 viewSql2)
        {
            string sql = "Insert intoMed_if_his_view_sql2(App_Code,Trans_Name,Sql_Text,Med_Table_name,Data_Source_Name,Sql_Para,Description,CommandType) values('" + viewSql2.AppCode + "' ,'" + viewSql2.TransName + "','" + viewSql2.SqlText + "','" + viewSql2.MedTableName + "','" + viewSql2.DataSourceName + "','" + viewSql2.SqlPara + "','" + viewSql2.Description + "','" + viewSql2.CommandType + "')";
            return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, sql, null);
        }

        public int InsertMedIfHisView2SQL(MedIfHisViewSql2 viewSql2)
        {
            string sql = "Insert intoMed_if_his_view_sql2(App_Code,Trans_Name,Sql_Text,Med_Table_name,Data_Source_Name,Sql_Para,Description,CommandType) values('" + viewSql2.AppCode + "' ,'" + viewSql2.TransName + "','" + viewSql2.SqlText + "','" + viewSql2.MedTableName + "','" + viewSql2.DataSourceName + "','" + viewSql2.SqlPara + "','" + viewSql2.Description + "','" + viewSql2.CommandType + "')";
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, sql, null);
        }

        public int InsertMedIfHisView2OLE(MedIfHisViewSql2 viewSql2)
        {
            string sql = "Insert intoMed_if_his_view_sql2(App_Code,Trans_Name,Sql_Text,Med_Table_name,Data_Source_Name,Sql_Para,Description,CommandType) values('" + viewSql2.AppCode + "' ,'" + viewSql2.TransName + "','" + viewSql2.SqlText + "','" + viewSql2.MedTableName + "','" + viewSql2.DataSourceName + "','" + viewSql2.SqlPara + "','" + viewSql2.Description + "','" + viewSql2.CommandType + "')";
            return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, sql, null); 
        }
        #endregion

        #region Update
        //public int UpdateMedIfHisViewSql2(MedIfHisViewSql2 viewSql2)
        //{
        //   // string update = "Update Med_if_his_view_sql2 set Sql_Text='"+viewSql2.SqlText+"',Data_Source_Name='"+viewSql2.DataSourceName+"',Sql_Para,Description,CommandType
        //}

        //public int UpdateMedIfHisViewSql2SQL(MedIfHisViewSql2 viewSql2)
        //{

        //}

        //public int UpdateMedIfHisViewSql2OLE(MedIfHisViewSql2 viewSql2)
        //{

        //}
        #endregion

        #region Delete

        public int DeleteMedIfHisViewSql2(MedIfHisViewSql2 viewSql2)
        {
            string sql = "delete from Med_if_his_view_sql2 where App_code='" + viewSql2.AppCode + "' and Trans_Name='" + viewSql2.TransName + "' and Med_Table_name='" + viewSql2.MedTableName + "'";
            return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, sql, null);
        }

        public int DeleteMedIfHisViewSql2OLE(MedIfHisViewSql2 viewSql2)
        {
            string sql = "delete from Med_if_his_view_sql2 where App_code='" + viewSql2.AppCode + "' and Trans_Name='" + viewSql2.TransName + "' and Med_Table_name='" + viewSql2.MedTableName + "'";
            return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text ,sql, null);
        }

        public int DeleteMedIfHisViewSql2SQL(MedIfHisViewSql2 viewSql2)
        {
            string sql = "delete from Med_if_his_view_sql2 where App_code='" + viewSql2.AppCode + "' and Trans_Name='" + viewSql2.TransName + "' and Med_Table_name='" + viewSql2.MedTableName + "'";
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, sql, null);
        }
        #endregion
    }
}
