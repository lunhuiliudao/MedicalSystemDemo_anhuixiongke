

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
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedOperationDict
    /// </summary>

    public partial class DALMedOperationDict
    {

        private static readonly string MED_OPERATION_DICT_Insert_SQL = "INSERT INTO MED_OPERATION_DICT (OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB) values (@OperationCode,@OperationName,@OperationScale,@StdIndicator,@ApprovedIndicator,@CreateDate,@InputCode,@InputCodeWb)";
        private static readonly string MED_OPERATION_DICT_Update_SQL = "UPDATE MED_OPERATION_DICT SET OPERATION_CODE=@OperationCode,OPERATION_NAME=@OperationName,OPERATION_SCALE=@OperationScale,STD_INDICATOR=@StdIndicator,APPROVED_INDICATOR=@ApprovedIndicator,CREATE_DATE=@CreateDate,INPUT_CODE=@InputCode,INPUT_CODE_WB=@InputCodeWb WHERE OPERATION_NAME=@OperationName1";
        private static readonly string MED_OPERATION_DICT_Delete_SQL = "Delete MED_OPERATION_DICT WHERE OPERATION_NAME=@OperationName";
        private static readonly string MED_OPERATION_DICT_Select_SQL = "SELECT OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB FROM MED_OPERATION_DICT where OPERATION_NAME=@OperationName";
        private static readonly string MED_OPERATION_DICT_Select_ALL_SQL = "SELECT OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB FROM MED_OPERATION_DICT";
        private static readonly string MED_OPERATION_DICT_Insert = "INSERT INTO MED_OPERATION_DICT (OPER_CODE,OPER_NAME,OPER_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE) values (:OperationCode,:OperationName,:OperationScale,:StdIndicator,:ApprovedIndicator,:CreateDate,:InputCode)";
        private static readonly string MED_OPERATION_DICT_Update = "UPDATE MED_OPERATION_DICT SET OPER_CODE=:OperationCode,OPER_NAME=:OperationName,OPER_SCALE=:OperationScale,STD_INDICATOR=:StdIndicator,APPROVED_INDICATOR=:ApprovedIndicator,CREATE_DATE=:CreateDate,INPUT_CODE=:InputCode WHERE OPER_CODE=:OperationCode";
        private static readonly string MED_OPERATION_DICT_Delete = "Delete MED_OPERATION_DICT WHERE OPERATION_NAME=:OperationName";
        private static readonly string MED_OPERATION_DICT_Select = "SELECT OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB FROM MED_OPERATION_DICT where OPERATION_NAME=:OperationName";
        private static readonly string MED_OPERATION_DICT_Select_ALL = "SELECT OPERATION_CODE,OPERATION_NAME,OPERATION_SCALE,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INPUT_CODE_WB FROM MED_OPERATION_DICT";
        public DALMedOperationDict()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedOperationDict SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@OperationCode",SqlDbType.VarChar),
							new SqlParameter("@OperationName",SqlDbType.VarChar),
							new SqlParameter("@OperationScale",SqlDbType.VarChar),
							new SqlParameter("@StdIndicator",SqlDbType.Decimal),
							new SqlParameter("@ApprovedIndicator",SqlDbType.Decimal),
							new SqlParameter("@CreateDate",SqlDbType.DateTime),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@InputCodeWb",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedOperationDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@OperationCode",SqlDbType.VarChar),
							new SqlParameter("@OperationName",SqlDbType.VarChar),
							new SqlParameter("@OperationScale",SqlDbType.VarChar),
							new SqlParameter("@StdIndicator",SqlDbType.Decimal),
							new SqlParameter("@ApprovedIndicator",SqlDbType.Decimal),
							new SqlParameter("@CreateDate",SqlDbType.DateTime),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@InputCodeWb",SqlDbType.VarChar),
							new SqlParameter("@OperationName1",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedOperationDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@OperationName",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedOperationDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@OperationName",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedOperationDict 
        ///Insert Table MED_OPERATION_DICT
        /// </summary>
        public int InsertMedOperationDictSQL(MedOperationDict model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedOperationDict");
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

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_DICT_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedOperationDict 
        ///Update Table     MED_OPERATION_DICT
        /// </summary>
        public int UpdateMedOperationDictSQL(MedOperationDict model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedOperationDict");
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
                    oneUpdate[8].Value = model.OperationName;
                else
                    oneUpdate[8].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_DICT_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedOperationDict 
        ///Delete Table MED_OPERATION_DICT by (string OPERATION_NAME)
        /// </summary>
        public int DeleteMedOperationDictSQL(string OPERATION_NAME)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedOperationDict");
                if (OPERATION_NAME != null)
                    oneDelete[0].Value = OPERATION_NAME;
                else
                    oneDelete[0].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_DICT_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedOperationDict 
        ///select Table MED_OPERATION_DICT by (string OPERATION_NAME)
        /// </summary>
        public MedOperationDict SelectMedOperationDictSQL(string OPERATION_NAME)
        {
            MedOperationDict model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedOperationDict");
            parameterValues[0].Value = OPERATION_NAME;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_DICT_Select_SQL, parameterValues))
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
        public List<MedOperationDict> SelectMedOperationDictListSQL()
        {
            List<MedOperationDict> modelList = new List<MedOperationDict>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_DICT_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedOperationDict model = new MedOperationDict();
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
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":OperationCode",OracleType.VarChar),
							new OracleParameter(":OperationName",OracleType.VarChar),
							new OracleParameter(":OperationScale",OracleType.VarChar),
							new OracleParameter(":StdIndicator",OracleType.Number),
							new OracleParameter(":ApprovedIndicator",OracleType.Number),
							new OracleParameter(":CreateDate",OracleType.DateTime),
							new OracleParameter(":InputCode",OracleType.VarChar),
						 
                    };
                }
                else if (sqlParms == "UpdateMedOperationDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":OperationCode",OracleType.VarChar),
							new OracleParameter(":OperationName",OracleType.VarChar),
							new OracleParameter(":OperationScale",OracleType.VarChar),
							new OracleParameter(":StdIndicator",OracleType.Number),
							new OracleParameter(":ApprovedIndicator",OracleType.Number),
							new OracleParameter(":CreateDate",OracleType.DateTime),
							new OracleParameter(":InputCode",OracleType.VarChar),
							new OracleParameter(":OperationCode",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedOperationDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":OperationName",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedOperationDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":OperationName",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedOperationDict 
        ///Insert Table MED_OPERATION_DICT
        /// </summary>
        public int InsertMedOperationDict(MedOperationDict model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedOperationDict");
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


                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_DICT_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedOperationDict 
        ///Update Table     MED_OPERATION_DICT
        /// </summary>
        public int UpdateMedOperationDict(MedOperationDict model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedOperationDict");
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

                if (model.OperationName != null)
                    oneUpdate[7].Value = model.OperationCode;
                else
                    oneUpdate[7].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_DICT_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedOperationDict 
        ///Delete Table MED_OPERATION_DICT by (string OPERATION_NAME)
        /// </summary>
        public int DeleteMedOperationDict(string OPERATION_NAME)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedOperationDict");
                if (OPERATION_NAME != null)
                    oneDelete[0].Value = OPERATION_NAME;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_DICT_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedOperationDict 
        ///select Table MED_OPERATION_DICT by (string OPERATION_NAME)
        /// </summary>
        public MedOperationDict SelectMedOperationDict(string OPERATION_NAME)
        {
            MedOperationDict model;
            OracleParameter[] parameterValues = GetParameter("SelectMedOperationDict");
            parameterValues[0].Value = OPERATION_NAME;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_DICT_Select, parameterValues))
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
        #region  [获取所有记录]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedOperationDict> SelectMedOperationDictList()
        {
            List<MedOperationDict> modelList = new List<MedOperationDict>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_DICT_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedOperationDict model = new MedOperationDict();
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
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

    }
}
