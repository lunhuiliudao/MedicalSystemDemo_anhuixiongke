

/*********************************************************************
 * Author:    孙凯
 * Date:      2011/8/28 
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedIFHisViewSql
	/// </summary>

    public partial class DALMedIfHisViewSql
	{
        private static readonly string MED_IF_HIS_VIEW_SQL_Select = "SELECT SERIAL_NO,SQL_TEXT,HIS_TABLE_NAME,MED_TABLE_NAME,PARA_CODE,SQL_TYPE,DESCRIPTION,DBMS_TYPE,COMMAND_TYPE FROM MED_IF_HIS_VIEW_SQL WHERE MED_TABLE_NAME =:medtablename AND DBMS_TYPE = :dbmstype";
        public DALMedIfHisViewSql()
		{
		}

		#region [获取参数]
		/// <summary>
        ///获取参数MedHisViewSql
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfHisViewSql")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":medtablename",OracleType.VarChar),
                            new OracleParameter(":dbmstype",OracleType.VarChar),
                        };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedHisViewSql 
        ///select Table MedHisViewSql by Med_Table_Name
        /// </summary>
        public MedIfHisViewSql SelectMedIfHisViewSql(string MedTableName, string DbmsType)
        {
            MedIfHisViewSql model;
            OracleParameter[] parameterValues = GetParameter("SelectMedIfHisViewSql");
            parameterValues[0].Value = MedTableName;
            parameterValues[1].Value = DbmsType;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_IF_HIS_VIEW_SQL_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedIfHisViewSql();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.SqlText = oleReader["SQL_TEXT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisTableName = oleReader["HIS_TABLE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedTableName = oleReader["MED_TABLE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ParaCode = oleReader["PARA_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.SqlType = oleReader["SQL_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Description = oleReader["DESCRIPTION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DBMSType = oleReader["DBMS_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Commandtype = oleReader["COMMAND_TYPE"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion	


        private static readonly string MED_HIS_VIEW_SQL_Select_Sql = "SELECT SERIAL_NO,SQL_TEXT,HIS_TABLE_NAME,MED_TABLE_NAME,PARA_CODE,SQL_TYPE,DESCRIPTION,DBMS_TYPE,COMMAND_TYPE FROM MED_IF_HIS_VIEW_SQL WHERE MED_TABLE_NAME =@medtablename AND DBMS_TYPE = @dbmstype";

        #region [获取参数]
        /// <summary>
        ///获取参数MedHisViewSql
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfHisViewSql")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@medtablename",SqlDbType.VarChar),
                            new SqlParameter("@dbmstype",SqlDbType.VarChar),
                        };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedHisViewSql 
        ///select Table MedHisViewSql by Med_Table_Name
        /// </summary>
        public MedIfHisViewSql SelectMedIfHisViewSqlSQL(string MedTableName, string DbmsType)
        {
            MedIfHisViewSql model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedIfHisViewSql");
            parameterValues[0].Value = MedTableName;
            parameterValues[1].Value = DbmsType;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_HIS_VIEW_SQL_Select_Sql, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedIfHisViewSql();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.SqlText = oleReader["SQL_TEXT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisTableName = oleReader["HIS_TABLE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedTableName = oleReader["MED_TABLE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ParaCode = oleReader["PARA_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.SqlType = oleReader["SQL_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Description = oleReader["DESCRIPTION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DBMSType = oleReader["DBMS_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Commandtype = oleReader["COMMAND_TYPE"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion	

        public List<MedIfHisViewSql> GetMedIfHisViewSql()
        {
            List<MedIfHisViewSql> result = new List<MedIfHisViewSql>();
            DataSet ds = new DataSet();
            string sqlselect = "select * from med_if_his_view_sql";

            ds = SqlHelper.GetDataSet(SqlHelper.ConnectionString, CommandType.Text, sqlselect, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedIfHisViewSql entity = new MedIfHisViewSql();
                entity.Commandtype = dr["COMMAND_TYPE"].ToString();
                entity.DBMSType = dr["DBMS_TYPE"].ToString();
                entity.Description = dr["DESCRIPTION"].ToString();
                entity.HisTableName = dr["HIS_TABLE_NAME"].ToString();
                entity.MedTableName = dr["MED_TABLE_NAME"].ToString();
                entity.ParaCode = dr["PARA_CODE"].ToString();
                entity.SqlText = dr["SQL_TEXT"].ToString();
                entity.SqlType = dr["SQL_TYPE"].ToString();
                result.Add(entity);
            }
            return result;
        }

        public List<MedIfHisViewSql> GetMedIfHisView()
        {
            List<MedIfHisViewSql> result = new List<MedIfHisViewSql>();
            DataSet ds = new DataSet();
            string sqlselect = "select * from med_if_his_view_sql";

            ds = OracleHelper.GetDataSet(OracleHelper.ConnectionString, CommandType.Text, sqlselect, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedIfHisViewSql entity = new MedIfHisViewSql();
                entity.Commandtype = dr["COMMAND_TYPE"].ToString();
                entity.DBMSType = dr["DBMS_TYPE"].ToString();
                entity.Description = dr["DESCRIPTION"].ToString();
                entity.HisTableName = dr["HIS_TABLE_NAME"].ToString();
                entity.MedTableName = dr["MED_TABLE_NAME"].ToString();
                entity.ParaCode = dr["PARA_CODE"].ToString();
                entity.SqlText = dr["SQL_TEXT"].ToString();
                entity.SqlType = dr["SQL_TYPE"].ToString();
                result.Add(entity);
            }
            return result;
        }

        public List<MedIfHisViewSql> GetMedIfHisViewOLE()
        {
            List<MedIfHisViewSql> result = new List<MedIfHisViewSql>();
            DataSet ds = new DataSet();
            string sqlselect = "select * from med_if_his_view_sql";

            ds = OleDbHelper.GetDataSet(OleDbHelper.ConnectionString, CommandType.Text, sqlselect, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedIfHisViewSql entity = new MedIfHisViewSql();
                entity.Commandtype = dr["COMMAND_TYPE"].ToString();
                entity.DBMSType = dr["DBMS_TYPE"].ToString();
                entity.Description = dr["DESCRIPTION"].ToString();
                entity.HisTableName = dr["HIS_TABLE_NAME"].ToString();
                entity.MedTableName = dr["MED_TABLE_NAME"].ToString();
                entity.ParaCode = dr["PARA_CODE"].ToString();
                entity.SqlText = dr["SQL_TEXT"].ToString();
                entity.SqlType = dr["SQL_TYPE"].ToString();
                result.Add(entity);
            }
            return result;
        }

	}
}
