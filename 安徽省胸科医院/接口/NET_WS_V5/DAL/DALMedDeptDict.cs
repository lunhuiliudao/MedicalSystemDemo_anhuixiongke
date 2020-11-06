

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:09
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
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedDeptDict
    /// </summary>

    public partial class DALMedDeptDict
    {
        private static readonly string MED_DEPT_DICT_Insert_SQL = "INSERT INTO MED_DEPT_DICT (SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS) values (@SortNo,@DeptCode,@DeptName,@InputCode,@WardCode,@DeptType,@DeptAlias)";
        private static readonly string MED_DEPT_DICT_Update_SQL = "UPDATE MED_DEPT_DICT SET SORT_NO=@SortNo,DEPT_NAME=@DeptName,INPUT_CODE=@InputCode,WARD_CODE=@WardCode,DEPT_TYPE=@DeptType,DEPT_ALIAS=@DeptAlias WHERE DEPT_CODE=@DeptCode";
        private static readonly string MED_DEPT_DICT_Delete_SQL = "Delete MED_DEPT_DICT WHERE DEPT_CODE=@DeptCode";
        private static readonly string MED_DEPT_DICT_Select_SQL = "SELECT SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS FROM MED_DEPT_DICT where DEPT_CODE=@DeptCode";
        private static readonly string MED_DEPT_DICT_Select_Name_SQL = "SELECT SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS FROM MED_DEPT_DICT where DEPT_NAME=@DeptName";
        private static readonly string MED_DEPT_DICT_Select_ALL_SQL = "SELECT SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS FROM MED_DEPT_DICT";

        private static readonly string MED_DEPT_DICT_Insert = "INSERT INTO MED_DEPT_DICT (SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS) values (:SortNo,:DeptCode,:DeptName,:InputCode,:WardCode,:DeptType,:DeptAlias)";

        private static readonly string MED_DEPT_DICT_Update = "UPDATE MED_DEPT_DICT SET SORT_NO=:SortNo,DEPT_NAME=:DeptName,INPUT_CODE=:InputCode,WARD_CODE=:WardCode,DEPT_TYPE=:DeptType,DEPT_ALIAS=:DeptAlias WHERE DEPT_CODE=:DeptCode";

        private static readonly string MED_DEPT_DICT_Delete = "Delete MED_DEPT_DICT WHERE DEPT_CODE=:DeptCode";
        private static readonly string MED_DEPT_DICT_Select = "SELECT SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS FROM MED_DEPT_DICT where DEPT_CODE=:DeptCode";
        private static readonly string MED_DEPT_DICT_Select_Name = "SELECT SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS where DEPT_NAME=:DeptName";
        private static readonly string MED_DEPT_DICT_Select_ALL = "SELECT SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS FROM MED_DEPT_DICT";
        public DALMedDeptDict()
        {
        }

        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedDeptDict SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDeptDict")
                {
                    parms = new SqlParameter[]{
						    new SqlParameter("@SortNo",SqlDbType.Decimal),
							new SqlParameter("@DeptCode",SqlDbType.VarChar),
							new SqlParameter("@DeptName",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
                            new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@DeptType",SqlDbType.VarChar),
							new SqlParameter("@DeptAlias",SqlDbType.VarChar),
                        };
                }
                else if (sqlParms == "UpdateMedDeptDict")
                {
                    parms = new SqlParameter[]{
						    new SqlParameter("@SortNo",SqlDbType.Decimal),
							new SqlParameter("@DeptName",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
                            new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@DeptType",SqlDbType.VarChar),
							new SqlParameter("@DeptAlias",SqlDbType.VarChar),
							new SqlParameter("@DeptCode",SqlDbType.Decimal),
                        };
                }
                else if (sqlParms == "DeleteMedDeptDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DeptCode",SqlDbType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedDeptDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DeptCode",SqlDbType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedDeptDictName")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DeptName",SqlDbType.VarChar),
                        };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedDeptDict 
        ///Insert Table MED_DEPT_DICT
        /// </summary>
        public int InsertMedDeptDictSQL(MedDeptDict model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedDeptDict");
                if (model.SortNo.ToString() != null)
                    oneInert[0].Value = model.SortNo;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[1].Value = model.DeptCode;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.DeptName != null)
                    oneInert[2].Value = model.DeptName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneInert[3].Value = model.InputCode;
                else
                    oneInert[3].Value = DBNull.Value;

                if (model.WardCode != null)
                    oneInert[4].Value = model.WardCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.DeptType != null)
                    oneInert[5].Value = model.DeptType;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.DeptAlis != null)
                    oneInert[6].Value = model.DeptAlis;
                else
                    oneInert[6].Value = DBNull.Value;


                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DEPT_DICT_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedDeptDict 
        ///Update Table     MED_DEPT_DICT
        /// </summary>
        public int UpdateMedDeptDictSQL(MedDeptDict model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedDeptDict");
              
                if (model.SortNo.ToString() != null)
                    oneUpdate[0].Value = model.SortNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.DeptName != null)
                    oneUpdate[1].Value = model.DeptName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneUpdate[2].Value = model.InputCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[3].Value = model.WardCode;
                else
                    oneUpdate[3].Value = DBNull.Value;

                if (model.DeptType != null)
                    oneUpdate[4].Value = model.DeptType;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.DeptAlis != null)
                    oneUpdate[5].Value = model.DeptAlis;
                else
                    oneUpdate[5].Value = DBNull.Value;

                if (model.DeptCode != null)
                    oneUpdate[6].Value = model.DeptCode;
                else
                    oneUpdate[6].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DEPT_DICT_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedDeptDict 
        ///Delete Table MED_DEPT_DICT by (string DEPT_CODE)
        /// </summary>
        public int DeleteMedDeptDictSQL(string DEPT_CODE)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedDeptDict");
                if (DEPT_CODE != null)
                    oneDelete[0].Value = DEPT_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DEPT_DICT_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedDeptDict 
        ///select Table MED_DEPT_DICT by (string DEPT_CODE)
        /// </summary>
        public MedDeptDict SelectMedDeptDictSQL(string DEPT_CODE)
        {
            MedDeptDict model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedDeptDict");
            parameterValues[0].Value = DEPT_CODE;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DEPT_DICT_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedDeptDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SortNo = decimal.Parse(oleReader["Sort_No"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DeptName = oleReader["DEPT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    } if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptType = oleReader["DEPT_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptAlis = oleReader["DEPT_ALIAS"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取一条记录SQL-DEPT_NAME]
        /// <summary>
        ///Select    model  MedDeptDict 
        ///select Table MED_DEPT_DICT by (string DEPT_CODE)
        /// </summary>
        public MedDeptDict SelectMedDeptDictNameSQL(string DEPT_NAME)
        {
            MedDeptDict model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedDeptDictName");
            parameterValues[0].Value = DEPT_NAME;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DEPT_DICT_Select_Name_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedDeptDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SortNo = decimal.Parse(oleReader["Sort_No"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DeptName = oleReader["DEPT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    } if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptType = oleReader["DEPT_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptAlis = oleReader["DEPT_ALIAS"].ToString().Trim();
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
        public List<MedDeptDict> SelectMedDeptDictListSQL()
        {
            List<MedDeptDict> modelList = new List<MedDeptDict>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DEPT_DICT_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedDeptDict model = new MedDeptDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SortNo = decimal.Parse(oleReader["Sort_No"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DeptName = oleReader["DEPT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptType = oleReader["DEPT_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptAlis = oleReader["DEPT_ALIAS"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region [获取参数]
        /// <summary>
        ///获取参数MedDeptDict
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDeptDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":SortNo",OracleType.Number),
							new OracleParameter(":DeptCode",OracleType.VarChar),
							new OracleParameter(":DeptName",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
                            new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":DeptType",OracleType.VarChar),
							new OracleParameter(":DeptAlias",OracleType.VarChar),
                        
                    };
                }
                else if (sqlParms == "UpdateMedDeptDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":SortNo",OracleType.Number),
							new OracleParameter(":DeptName",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
                            new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":DeptType",OracleType.VarChar),
							new OracleParameter(":DeptAlias",OracleType.VarChar),
							new OracleParameter(":DeptCode",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedDeptDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DeptCode",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedDeptDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DeptCode",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedDeptDictName")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DeptName",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedDeptDict 
        ///Insert Table MED_DEPT_DICT
        /// </summary>
        public int InsertMedDeptDict(MedDeptDict model)
        {

            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedDeptDict");
                if (model.SortNo.ToString() != null)
                    oneInert[0].Value = model.SortNo;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[1].Value = model.DeptCode;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.DeptName != null)
                    oneInert[2].Value = model.DeptName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneInert[3].Value = model.InputCode;
                else
                    oneInert[3].Value = DBNull.Value;

                if (model.WardCode != null)
                    oneInert[4].Value = model.WardCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.DeptType != null)
                    oneInert[5].Value = model.DeptType;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.DeptAlis != null)
                    oneInert[6].Value = model.DeptAlis;
                else
                    oneInert[6].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DEPT_DICT_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]

        /// <summary>
        ///Update    model  MedDeptDict 
        ///Update Table     MED_DEPT_DICT
        /// </summary>
        public int UpdateMedDeptDict(MedDeptDict model)
        {

            //new OracleParameter(":SortNo",OracleType.Number),
            //            new OracleParameter(":DeptName",OracleType.VarChar),
            //            new OracleParameter(":InputCode",OracleType.VarChar),
            //            new OracleParameter(":WardCode",OracleType.VarChar),
            //            new OracleParameter(":DeptType",OracleType.VarChar),
            //            new OracleParameter(":DeptAlias",OracleType.VarChar),
            //            new OracleParameter(":DeptCode",SqlDbType.Decimal),

            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedDeptDict");
                if (model.SortNo.ToString() != null)
                    oneUpdate[0].Value = model.SortNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.DeptName != null)
                    oneUpdate[1].Value = model.DeptName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneUpdate[2].Value = model.InputCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[3].Value = model.WardCode;
                else
                    oneUpdate[3].Value = DBNull.Value;

                if (model.DeptType != null)
                    oneUpdate[4].Value = model.DeptType;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.DeptAlis != null)
                    oneUpdate[5].Value = model.DeptAlis;
                else
                    oneUpdate[5].Value = DBNull.Value;

                if (model.DeptCode != null)
                    oneUpdate[6].Value = model.DeptCode;
                else
                    oneUpdate[6].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DEPT_DICT_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedDeptDict 
        ///Delete Table MED_DEPT_DICT by (string DEPT_CODE)
        /// </summary>
        public int DeleteMedDeptDict(string DEPT_CODE)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedDeptDict");
                if (DEPT_CODE != null)
                    oneDelete[0].Value = DEPT_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DEPT_DICT_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedDeptDict 
        ///select Table MED_DEPT_DICT by (string DEPT_CODE)
        /// </summary>
        public MedDeptDict SelectMedDeptDict(string DEPT_CODE)
        {
            MedDeptDict model;
            OracleParameter[] parameterValues = GetParameter("SelectMedDeptDict");
            parameterValues[0].Value = DEPT_CODE;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DEPT_DICT_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedDeptDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SortNo = decimal.Parse(oleReader["Sort_No"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DeptName = oleReader["DEPT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptType = oleReader["DEPT_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptAlis = oleReader["DEPT_ALIAS"].ToString().Trim();
                    }


                    // SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取一条记录-DEPT_NAME]
        /// <summary>
        ///Select    model  MedDeptDict 
        ///select Table MED_DEPT_DICT by (string DEPT_NAME)
        /// </summary>
        public MedDeptDict SelectMedDeptDictName(string DEPT_NAME)
        {
            MedDeptDict model;
            OracleParameter[] parameterValues = GetParameter("SelectMedDeptDictName");
            parameterValues[0].Value = DEPT_NAME;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DEPT_DICT_Select_Name, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedDeptDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SortNo = decimal.Parse(oleReader["Sort_No"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DeptName = oleReader["DEPT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptType = oleReader["DEPT_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptAlis = oleReader["DEPT_ALIAS"].ToString().Trim();
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
        public List<MedDeptDict> SelectMedDeptDictList()
        {
            List<MedDeptDict> modelList = new List<MedDeptDict>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DEPT_DICT_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedDeptDict model = new MedDeptDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SortNo = decimal.Parse(oleReader["Sort_No"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DeptName = oleReader["DEPT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptType = oleReader["DEPT_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptAlis = oleReader["DEPT_ALIAS"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

    }
}
