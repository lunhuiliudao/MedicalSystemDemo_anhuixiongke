

/*********************************************************************
 * Author:    孙凯
 * Date:      2011/8/9
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
    /// DAL MedIFHisViewSql
	/// </summary>

    public partial class DALMedIfHisViewSql
	{
        private static readonly string MED_IF_HIS_VIEW_SQL_Select_OLE = "SELECT SERIAL_NO,SQL_TEXT,HIS_TABLE_NAME,MED_TABLE_NAME,PARA_CODE,SQL_TYPE,DESCRIPTION,DBMS_TYPE,COMMAND_TYPE FROM MED_IF_HIS_VIEW_SQL WHERE MED_TABLE_NAME = ? AND DBMS_TYPE = ?";


		#region [获取参数]
		/// <summary>
        ///获取参数MedHisViewSql
		/// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
		{
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfHisViewSql")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("medtablename",OleDbType.VarChar),
                            new OleDbParameter("dbmstype",OleDbType.VarChar),
                        };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedHisViewSql 
        ///select Table MedHisViewSql by Med_Table_Name
        /// </summary>
        public MedIfHisViewSql SelectMedIfHisViewSqlOLE(string MedTableName, string DbmsType)
        {
            MedIfHisViewSql model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedIfHisViewSql");
            parameterValues[0].Value = MedTableName;
            parameterValues[1].Value = DbmsType;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_IF_HIS_VIEW_SQL_Select_OLE, parameterValues))
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


        private static readonly string MED_HIS_VIEW_SQL_Select_Sql_ODBC = "SELECT SERIAL_NO,SQL_TEXT,HIS_TABLE_NAME,MED_TABLE_NAME,PARA_CODE,SQL_TYPE,DESCRIPTION,DBMS_TYPE,COMMAND_TYPE FROM MED_IF_HIS_VIEW_SQL WHERE MED_TABLE_NAME = ? AND DBMS_TYPE = ?";

        #region [获取参数]
        /// <summary>
        ///获取参数MedHisViewSql
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfHisViewSql")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("medtablename",OdbcType.VarChar),
                            new OdbcParameter("dbmstype",OdbcType.VarChar),
                        };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedHisViewSql 
        ///select Table MedHisViewSql by Med_Table_Name
        /// </summary>
        public MedIfHisViewSql SelectMedIfHisViewSqlODBC(string MedTableName, string DbmsType)
        {
            MedIfHisViewSql model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedIfHisViewSql");
            parameterValues[0].Value = MedTableName;
            parameterValues[1].Value = DbmsType;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_HIS_VIEW_SQL_Select_Sql_ODBC, parameterValues))
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
	}
}
