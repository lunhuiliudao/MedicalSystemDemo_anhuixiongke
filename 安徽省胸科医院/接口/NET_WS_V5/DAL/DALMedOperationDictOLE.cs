

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:20
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
using System.Data.OleDb;
using System.Data.Odbc;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedOperationDict
	/// </summary>

    public partial class DALMedOperationDict
	{

        private static readonly string MED_OPERATION_DICT_Insert_OLE = "INSERT INTO MED_OPERATION_DICT (OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB) values (?,?,?,?,?,?,?,?)";
        private static readonly string MED_OPERATION_DICT_Update_OLE = "UPDATE MED_OPERATION_DICT SET OPERATION_CODE=?,OPERATION_NAME=?,OPERATION_SCALE=?,STD_INDICATOR=?,APPROVED_INDICATOR=?,CREATE_DATE=?,INPUT_CODE=?,INPUT_CODE_WB=? WHERE OPERATION_NAME=?";
        private static readonly string MED_OPERATION_DICT_Delete_OLE = "Delete MED_OPERATION_DICT WHERE OPERATION_NAME=?";
        private static readonly string MED_OPERATION_DICT_Select_OLE = "SELECT OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB FROM MED_OPERATION_DICT where OPERATION_NAME=?";
		private static readonly string MED_OPERATION_DICT_Select_ALL_OLE = "SELECT OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB FROM MED_OPERATION_DICT";

        private static readonly string MED_OPERATION_DICT_Insert_ODBC = "INSERT INTO MED_OPERATION_DICT (OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB) values (?,?,?,?,?,?,?,?)";
        private static readonly string MED_OPERATION_DICT_Update_ODBC = "UPDATE MED_OPERATION_DICT SET OPERATION_CODE=?,OPERATION_NAME=?,OPERATION_SCALE=?,STD_INDICATOR=?,APPROVED_INDICATOR=?,CREATE_DATE=?,INPUT_CODE=?,INPUT_CODE_WB=? WHERE OPERATION_NAME=?";
        private static readonly string MED_OPERATION_DICT_Delete_ODBC = "Delete MED_OPERATION_DICT WHERE OPERATION_NAME=?";
        private static readonly string MED_OPERATION_DICT_Select_ODBC = "SELECT OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB FROM MED_OPERATION_DICT where OPERATION_NAME=?";
        private static readonly string MED_OPERATION_DICT_Select_ALL_ODBC = "SELECT OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB FROM MED_OPERATION_DICT";
	
      
		 
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedOperationDict SQL
		/// </summary>
		public static OleDbParameter[] GetParameterOLE(string sqlParms)
		{
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("OperationCode", OleDbType.VarChar),
							new OleDbParameter("OperationName",OleDbType.VarChar),
							new OleDbParameter("OperationScale",OleDbType.VarChar),
							new OleDbParameter("StdIndicator",OleDbType.Decimal),
							new OleDbParameter("ApprovedIndicator",OleDbType.Decimal),
							new OleDbParameter("CreateDate",OleDbType.DBTimeStamp),
							new OleDbParameter("InputCode",OleDbType.VarChar),
							new OleDbParameter("InputCodeWb",OleDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedOperationDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("OperationCode",OleDbType.VarChar),
							new OleDbParameter("OperationName",OleDbType.VarChar),
							new OleDbParameter("OperationScale",OleDbType.VarChar),
							new OleDbParameter("StdIndicator",OleDbType.Decimal),
							new OleDbParameter("ApprovedIndicator",OleDbType.Decimal),
							new OleDbParameter("CreateDate",OleDbType.DBTimeStamp),
							new OleDbParameter("InputCode",OleDbType.VarChar),
							new OleDbParameter("InputCodeWb",OleDbType.VarChar),
							new OleDbParameter("OperationName1",OleDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedOperationDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("OperationName",OleDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedOperationDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("OperationName",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedOperationDict 
		///Insert Table MED_OPERATION_DICT
		/// </summary>
		public int InsertMedOperationDictOLE(MedOperationDict model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedOperationDict");
					if (model.OperationCode != null)
						oneInert[0].Value = model.OperationCode;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.OperationName != null)
						oneInert[1].Value = model.OperationName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneInert[2].Value = model.OperationScale;
					else
						oneInert[2].Value = DBNull.Value;
                    if (model.StdIndicator.ToString() != null)
						oneInert[3].Value = model.StdIndicator;
					else
						oneInert[3].Value = DBNull.Value;
                    if (model.ApprovedIndicator.ToString() != null)
						oneInert[4].Value = model.ApprovedIndicator;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneInert[5].Value = model.CreateDate;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[6].Value = model.InputCode;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.InputCodeWb != null)
						oneInert[7].Value = model.InputCodeWb;
					else
						oneInert[7].Value = DBNull.Value;

                    return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text ,MED_OPERATION_DICT_Insert_OLE, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedOperationDict 
		///Update Table     MED_OPERATION_DICT
		/// </summary>
		public int UpdateMedOperationDictOLE(MedOperationDict model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedOperationDict");
					if (model.OperationCode != null)
						oneUpdate[0].Value = model.OperationCode;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.OperationName != null)
						oneUpdate[1].Value = model.OperationName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneUpdate[2].Value = model.OperationScale;
					else
						oneUpdate[2].Value = DBNull.Value;
                    if (model.StdIndicator.ToString() != null)
						oneUpdate[3].Value = model.StdIndicator;
					else
						oneUpdate[3].Value = DBNull.Value;
                    if (model.ApprovedIndicator.ToString() != null)
						oneUpdate[4].Value = model.ApprovedIndicator;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneUpdate[5].Value = model.CreateDate;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.InputCode != null)
						oneUpdate[6].Value = model.InputCode;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.InputCodeWb != null)
						oneUpdate[7].Value = model.InputCodeWb;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.OperationName != null)
						oneUpdate[8].Value =model.OperationName;
					else
						oneUpdate[8].Value = DBNull.Value;

                    return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text ,MED_OPERATION_DICT_Update_OLE, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedOperationDict 
		///Delete Table MED_OPERATION_DICT by (string OPERATION_NAME)
		/// </summary>
		public int DeleteMedOperationDictOLE(string OPERATION_NAME)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedOperationDict");
					if (OPERATION_NAME != null)
						oneDelete[0].Value =OPERATION_NAME;
					else
						oneDelete[0].Value = DBNull.Value;

                    return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text ,MED_OPERATION_DICT_Delete_OLE, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedOperationDict 
		///select Table MED_OPERATION_DICT by (string OPERATION_NAME)
		/// </summary>
        public MedOperationDict SelectMedOperationDictOLE(string OPERATION_NAME)
        {
            MedOperationDict model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedOperationDict");
            parameterValues[0].Value = OPERATION_NAME;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_OPERATION_DICT_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedOperationDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
		#endregion	
		#region  [获取所有记录SQL]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedOperationDict> SelectMedOperationDictListOLE()
		{
			List<MedOperationDict> modelList = new List<MedOperationDict>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_OPERATION_DICT_Select_ALL_OLE, null))
			{
                while (oleReader.Read())
				{
					MedOperationDict model = new MedOperationDict();
						if (!oleReader.IsDBNull(0))
						{
							model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedOperationDict
		/// </summary>
		public static OdbcParameter[] GetParameterODBC(string sqlParms)
		{
            OdbcParameter[] parms =OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("OperationCode", OdbcType.VarChar),
							new OdbcParameter("OperationName",OdbcType.VarChar),
							new OdbcParameter("OperationScale",OdbcType.VarChar),
							new OdbcParameter("StdIndicator",OdbcType.Decimal),
							new OdbcParameter("ApprovedIndicator",OdbcType.Decimal),
							new OdbcParameter("CreateDate",OdbcType.DateTime),
							new OdbcParameter("InputCode",OdbcType.VarChar),
							new OdbcParameter("InputCodeWb",OdbcType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedOperationDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("OperationCode",OdbcType.VarChar),
							new OdbcParameter("OperationName",OdbcType.VarChar),
							new OdbcParameter("OperationScale",OdbcType.VarChar),
							new OdbcParameter("StdIndicator",OdbcType.Decimal),
							new OdbcParameter("ApprovedIndicator",OdbcType.Decimal),
							new OdbcParameter("CreateDate",OdbcType.DateTime),
							new OdbcParameter("InputCode",OdbcType.VarChar),
							new OdbcParameter("InputCodeWb",OdbcType.VarChar),
							new OdbcParameter("OperationName1",OdbcType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedOperationDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("OperationName",OdbcType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedOperationDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("OperationName",OdbcType.VarChar),
                    };
                }
            	OdbcHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedOperationDict 
		///Insert Table MED_OPERATION_DICT
		/// </summary>
		public int InsertMedOperationDictODBC(MedOperationDict model)
		{
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneInert = GetParameterODBC("InsertMedOperationDict");
					if (model.OperationCode != null)
						oneInert[0].Value = model.OperationCode;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.OperationName != null)
						oneInert[1].Value = model.OperationName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneInert[2].Value = model.OperationScale;
					else
						oneInert[2].Value = DBNull.Value;
                    if (model.StdIndicator.ToString() != null)
						oneInert[3].Value = model.StdIndicator;
					else
						oneInert[3].Value = DBNull.Value;
                    if (model.ApprovedIndicator.ToString() != null)
						oneInert[4].Value = model.ApprovedIndicator;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneInert[5].Value = model.CreateDate;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[6].Value = model.InputCode;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.InputCodeWb != null)
						oneInert[7].Value = model.InputCodeWb;
					else
						oneInert[7].Value = DBNull.Value;

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString  , CommandType.Text, MED_OPERATION_DICT_Insert_ODBC, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedOperationDict 
		///Update Table     MED_OPERATION_DICT
		/// </summary>
		public int UpdateMedOperationDictODBC(MedOperationDict model)
		{
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedOperationDict");
					if (model.OperationCode != null)
						oneUpdate[0].Value = model.OperationCode;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.OperationName != null)
						oneUpdate[1].Value = model.OperationName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneUpdate[2].Value = model.OperationScale;
					else
						oneUpdate[2].Value = DBNull.Value;
                    if (model.StdIndicator.ToString() != null)
						oneUpdate[3].Value = model.StdIndicator;
					else
						oneUpdate[3].Value = DBNull.Value;
                    if (model.ApprovedIndicator.ToString() != null)
						oneUpdate[4].Value = model.ApprovedIndicator;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneUpdate[5].Value = model.CreateDate;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.InputCode != null)
						oneUpdate[6].Value = model.InputCode;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.InputCodeWb != null)
						oneUpdate[7].Value = model.InputCodeWb;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.OperationName != null)
						oneUpdate[8].Value =model.OperationName;
					else
						oneUpdate[8].Value = DBNull.Value;

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text ,MED_OPERATION_DICT_Update_ODBC, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedOperationDict 
		///Delete Table MED_OPERATION_DICT by (string OPERATION_NAME)
		/// </summary>
		public int DeleteMedOperationDictODBC(string OPERATION_NAME)
		{
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedOperationDict");
					if (OPERATION_NAME != null)
						oneDelete[0].Value =OPERATION_NAME;
					else
						oneDelete[0].Value = DBNull.Value;

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text,MED_OPERATION_DICT_Delete_ODBC, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedOperationDict 
		///select Table MED_OPERATION_DICT by (string OPERATION_NAME)
		/// </summary>
		public MedOperationDict  SelectMedOperationDictODBC(string OPERATION_NAME)
		{
			MedOperationDict model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedOperationDict");
				parameterValues[0].Value=OPERATION_NAME;
                using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_OPERATION_DICT_Select_ODBC, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedOperationDict();
						if (!oleReader.IsDBNull(0))
						{
							model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim() ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
		#region  [获取所有记录]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedOperationDict> SelectMedOperationDictListODBC()
		{
			List<MedOperationDict> modelList = new List<MedOperationDict>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_OPERATION_DICT_Select_ALL_ODBC, null))
			{
                while (oleReader.Read())
				{
					MedOperationDict model = new MedOperationDict();
						if (!oleReader.IsDBNull(0))
						{
							model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
