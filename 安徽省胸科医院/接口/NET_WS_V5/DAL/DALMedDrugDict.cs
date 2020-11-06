

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:24:31
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
	/// DAL MedDrugDict
	/// </summary>

    public class DALMedDrugDict
    {
        private static readonly string MED_DRUG_DICT_Insert_SQL = "INSERT INTO MED_DRUG_DICT (DRUG_CODE,DRUG_NAME,DRUG_SPEC,UNITS,DRUG_FORM,SUPPLIER_NAME,DOSE_PER_UNIT,DOSE_UNITS,DRUG_CLASS,ANESTHETIC_CLASS,CODE_IN_HIS,INPUT_CODE) values (@DrugCode,@DrugName,@DrugSpec,@Units,@DrugForm,@SupplierName,@DosePerUnit,@DoseUnits,@DrugClass,@AnestheticClass,@CodeInHis,@InputCode)";
        private static readonly string MED_DRUG_DICT_Update_SQL = "UPDATE MED_DRUG_DICT SET DRUG_CODE=@DrugCode,DRUG_NAME=@DrugName,DRUG_SPEC=@DrugSpec,UNITS=@Units,DRUG_FORM=@DrugForm,SUPPLIER_NAME=@SupplierName,DOSE_PER_UNIT=@DosePerUnit,DOSE_UNITS=@DoseUnits,DRUG_CLASS=@DrugClass,ANESTHETIC_CLASS=@AnestheticClass,CODE_IN_HIS=@CodeInHis,INPUT_CODE=@InputCode WHERE  DRUG_CODE=@DrugCode AND DRUG_SPEC=@DrugSpec";
        private static readonly string MED_DRUG_DICT_Delete_SQL = "DELETE MED_DRUG_DICT WHERE  DRUG_CODE=@DrugCode AND DRUG_SPEC=@DrugSpec";
        private static readonly string MED_DRUG_DICT_Select_SQL = "SELECT DRUG_CODE,DRUG_NAME,DRUG_SPEC,UNITS,DRUG_FORM,SUPPLIER_NAME,DOSE_PER_UNIT,DOSE_UNITS,DRUG_CLASS,ANESTHETIC_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_DRUG_DICT where  DRUG_CODE=@DrugCode AND DRUG_SPEC=@DrugSpec";
        private static readonly string MED_DRUG_DICT_Select_ALL_SQL = "SELECT DRUG_CODE,DRUG_NAME,DRUG_SPEC,UNITS,DRUG_FORM,SUPPLIER_NAME,DOSE_PER_UNIT,DOSE_UNITS,DRUG_CLASS,ANESTHETIC_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_DRUG_DICT";
        private static readonly string MED_DRUG_DICT_Insert = "INSERT INTO MED_DRUG_DICT (DRUG_CODE,DRUG_NAME,DRUG_SPEC,UNITS,DRUG_FORM,SUPPLIER_NAME,DOSE_PER_UNIT,DOSE_UNITS,DRUG_CLASS,ANESTHETIC_CLASS,CODE_IN_HIS,INPUT_CODE) values (:DrugCode,:DrugName,:DrugSpec,:Units,:DrugForm,:SupplierName,:DosePerUnit,:DoseUnits,:DrugClass,:AnestheticClass,:CodeInHis,:InputCode)";
        private static readonly string MED_DRUG_DICT_Update = "UPDATE MED_DRUG_DICT SET DRUG_CODE=:DrugCode,DRUG_NAME=:DrugName,DRUG_SPEC=:DrugSpec,UNITS=:Units,DRUG_FORM=:DrugForm,SUPPLIER_NAME=:SupplierName,DOSE_PER_UNIT=:DosePerUnit,DOSE_UNITS=:DoseUnits,DRUG_CLASS=:DrugClass,ANESTHETIC_CLASS=:AnestheticClass,CODE_IN_HIS=:CodeInHis,INPUT_CODE=:InputCode WHERE  DRUG_CODE=:DrugCode AND DRUG_SPEC=:DrugSpec";
        private static readonly string MED_DRUG_DICT_Delete = "DELETE MED_DRUG_DICT WHERE  DRUG_CODE=:DrugCode AND DRUG_SPEC=:DrugSpec";
        private static readonly string MED_DRUG_DICT_Select = "SELECT DRUG_CODE,DRUG_NAME,DRUG_SPEC,UNITS,DRUG_FORM,SUPPLIER_NAME,DOSE_PER_UNIT,DOSE_UNITS,DRUG_CLASS,ANESTHETIC_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_DRUG_DICT where  DRUG_CODE=:DrugCode AND DRUG_SPEC=:DrugSpec";
        private static readonly string MED_DRUG_DICT_Select_ALL = "SELECT DRUG_CODE,DRUG_NAME,DRUG_SPEC,UNITS,DRUG_FORM,SUPPLIER_NAME,DOSE_PER_UNIT,DOSE_UNITS,DRUG_CLASS,ANESTHETIC_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_DRUG_DICT";

        public DALMedDrugDict()
        {
        }

        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedDrugDict SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDrugDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugName",SqlDbType.VarChar),
							new SqlParameter("@DrugSpec",SqlDbType.VarChar),
							new SqlParameter("@Units",SqlDbType.VarChar),
							new SqlParameter("@DrugForm",SqlDbType.VarChar),
							new SqlParameter("@SupplierName",SqlDbType.VarChar),
							new SqlParameter("@DosePerUnit",SqlDbType.Decimal),
							new SqlParameter("@DoseUnits",SqlDbType.VarChar),
							new SqlParameter("@DrugClass",SqlDbType.VarChar),
							new SqlParameter("@AnestheticClass",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedDrugDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugName",SqlDbType.VarChar),
							new SqlParameter("@DrugSpec",SqlDbType.VarChar),
							new SqlParameter("@Units",SqlDbType.VarChar),
							new SqlParameter("@DrugForm",SqlDbType.VarChar),
							new SqlParameter("@SupplierName",SqlDbType.VarChar),
							new SqlParameter("@DosePerUnit",SqlDbType.Decimal),
							new SqlParameter("@DoseUnits",SqlDbType.VarChar),
							new SqlParameter("@DrugClass",SqlDbType.VarChar),
							new SqlParameter("@AnestheticClass",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugSpec",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedDrugDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugSpec",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedDrugDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugSpec",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedDrugDict 
        ///Insert Table MED_DRUG_DICT
        /// </summary>
        public int InsertMedDrugDictSQL(MedDrugDict model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedDrugDict");
                if (model.DrugCode != null)
                    oneInert[0].Value = model.DrugCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.DrugName != null)
                    oneInert[1].Value = model.DrugName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneInert[2].Value = model.DrugSpec;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.Units != null)
                    oneInert[3].Value = model.Units;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.DrugForm != null)
                    oneInert[4].Value = model.DrugForm;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.SupplierName != null)
                    oneInert[5].Value = model.SupplierName;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.DosePerUnit.ToString() != null)
                    oneInert[6].Value = model.DosePerUnit.ToString();
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.DoseUnits != null)
                    oneInert[7].Value = model.DoseUnits;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.DrugClass != null)
                    oneInert[8].Value = model.DrugClass;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.AnestheticClass != null)
                    oneInert[9].Value = model.AnestheticClass;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.CodeInHis != null)
                    oneInert[10].Value = model.CodeInHis;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneInert[11].Value = model.InputCode;
                else
                    oneInert[11].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DRUG_DICT_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedDrugDict 
        ///Update Table     MED_DRUG_DICT
        /// </summary>
        public int UpdateMedDrugDictSQL(MedDrugDict model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedDrugDict");
                if (model.DrugCode != null)
                    oneUpdate[0].Value = model.DrugCode;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.DrugName != null)
                    oneUpdate[1].Value = model.DrugName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneUpdate[2].Value = model.DrugSpec;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Units != null)
                    oneUpdate[3].Value = model.Units;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DrugForm != null)
                    oneUpdate[4].Value = model.DrugForm;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.SupplierName != null)
                    oneUpdate[5].Value = model.SupplierName;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.DosePerUnit.ToString() != null)
                    oneUpdate[6].Value = model.DosePerUnit.ToString();
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.DoseUnits != null)
                    oneUpdate[7].Value = model.DoseUnits;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.DrugClass != null)
                    oneUpdate[8].Value = model.DrugClass;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.AnestheticClass != null)
                    oneUpdate[9].Value = model.AnestheticClass;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.CodeInHis != null)
                    oneUpdate[10].Value = model.CodeInHis;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneUpdate[11].Value = model.InputCode;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.DrugCode != null)
                    oneUpdate[12].Value = model.DrugCode;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneUpdate[13].Value = model.DrugSpec;
                else
                    oneUpdate[13].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DRUG_DICT_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedDrugDict 
        ///Delete Table MED_DRUG_DICT by (string DRUG_CODE,string DRUG_SPEC)
        /// </summary>
        public int DeleteMedDrugDictSQL(string DRUG_CODE, string DRUG_SPEC)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedDrugDict");
                if (DRUG_CODE != null)
                    oneDelete[0].Value = DRUG_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (DRUG_SPEC != null)
                    oneDelete[1].Value = DRUG_SPEC;
                else
                    oneDelete[1].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DRUG_DICT_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedDrugDict 
        ///select Table MED_DRUG_DICT by (string DRUG_CODE,string DRUG_SPEC)
        /// </summary>
        public MedDrugDict SelectMedDrugDictSQL(string DRUG_CODE, string DRUG_SPEC)
        {
            MedDrugDict model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedDrugDict");
            parameterValues[0].Value = DRUG_CODE;
            parameterValues[1].Value = DRUG_SPEC;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DRUG_DICT_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedDrugDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DrugCode = oleReader["DRUG_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DrugName = oleReader["DRUG_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DrugSpec = oleReader["DRUG_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DrugForm = oleReader["DRUG_FORM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DosePerUnit = decimal.Parse(oleReader["DOSE_PER_UNIT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DoseUnits = oleReader["DOSE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.DrugClass = oleReader["DRUG_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AnestheticClass = oleReader["ANESTHETIC_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
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
        public List<MedDrugDict> SelectMedDrugDictListSQL()
        {
            List<MedDrugDict> modelList = new List<MedDrugDict>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DRUG_DICT_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedDrugDict model = new MedDrugDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DrugCode = oleReader["DRUG_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DrugName = oleReader["DRUG_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DrugSpec = oleReader["DRUG_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DrugForm = oleReader["DRUG_FORM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DosePerUnit = decimal.Parse(oleReader["DOSE_PER_UNIT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DoseUnits = oleReader["DOSE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.DrugClass = oleReader["DRUG_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AnestheticClass = oleReader["ANESTHETIC_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region [获取参数]
        /// <summary>
        ///获取参数MedDrugDict
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDrugDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DrugCode",OracleType.VarChar),
							new OracleParameter(":DrugName",OracleType.VarChar),
							new OracleParameter(":DrugSpec",OracleType.VarChar),
							new OracleParameter(":Units",OracleType.VarChar),
							new OracleParameter(":DrugForm",OracleType.VarChar),
							new OracleParameter(":SupplierName",OracleType.VarChar),
							new OracleParameter(":DosePerUnit",OracleType.Number),
							new OracleParameter(":DoseUnits",OracleType.VarChar),
							new OracleParameter(":DrugClass",OracleType.VarChar),
							new OracleParameter(":AnestheticClass",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedDrugDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DrugCode",OracleType.VarChar),
							new OracleParameter(":DrugName",OracleType.VarChar),
							new OracleParameter(":DrugSpec",OracleType.VarChar),
							new OracleParameter(":Units",OracleType.VarChar),
							new OracleParameter(":DrugForm",OracleType.VarChar),
							new OracleParameter(":SupplierName",OracleType.VarChar),
							new OracleParameter(":DosePerUnit",OracleType.Number),
							new OracleParameter(":DoseUnits",OracleType.VarChar),
							new OracleParameter(":DrugClass",OracleType.VarChar),
							new OracleParameter(":AnestheticClass",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
							new OracleParameter(":DrugCode",SqlDbType.VarChar),
							new OracleParameter(":DrugSpec",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedDrugDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DrugCode",OracleType.VarChar),
							new OracleParameter(":DrugSpec",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedDrugDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DrugCode",OracleType.VarChar),
							new OracleParameter(":DrugSpec",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedDrugDict 
        ///Insert Table MED_DRUG_DICT
        /// </summary>
        public int InsertMedDrugDict(MedDrugDict model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedDrugDict");
                if (model.DrugCode != null)
                    oneInert[0].Value = model.DrugCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.DrugName != null)
                    oneInert[1].Value = model.DrugName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneInert[2].Value = model.DrugSpec;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.Units != null)
                    oneInert[3].Value = model.Units;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.DrugForm != null)
                    oneInert[4].Value = model.DrugForm;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.SupplierName != null)
                    oneInert[5].Value = model.SupplierName;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.DosePerUnit.ToString() != null)
                    oneInert[6].Value = model.DosePerUnit.ToString();
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.DoseUnits != null)
                    oneInert[7].Value = model.DoseUnits;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.DrugClass != null)
                    oneInert[8].Value = model.DrugClass;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.AnestheticClass != null)
                    oneInert[9].Value = model.AnestheticClass;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.CodeInHis != null)
                    oneInert[10].Value = model.CodeInHis;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneInert[11].Value = model.InputCode;
                else
                    oneInert[11].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DRUG_DICT_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedDrugDict 
        ///Update Table     MED_DRUG_DICT
        /// </summary>
        public int UpdateMedDrugDict(MedDrugDict model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedDrugDict");
                if (model.DrugCode != null)
                    oneUpdate[0].Value = model.DrugCode;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.DrugName != null)
                    oneUpdate[1].Value = model.DrugName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneUpdate[2].Value = model.DrugSpec;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Units != null)
                    oneUpdate[3].Value = model.Units;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DrugForm != null)
                    oneUpdate[4].Value = model.DrugForm;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.SupplierName != null)
                    oneUpdate[5].Value = model.SupplierName;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.DosePerUnit.ToString() != null)
                    oneUpdate[6].Value = model.DosePerUnit.ToString();
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.DoseUnits != null)
                    oneUpdate[7].Value = model.DoseUnits;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.DrugClass != null)
                    oneUpdate[8].Value = model.DrugClass;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.AnestheticClass != null)
                    oneUpdate[9].Value = model.AnestheticClass;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.CodeInHis != null)
                    oneUpdate[10].Value = model.CodeInHis;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneUpdate[11].Value = model.InputCode;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.DrugCode != null)
                    oneUpdate[12].Value = model.DrugCode;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneUpdate[13].Value = model.DrugSpec;
                else
                    oneUpdate[13].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DRUG_DICT_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedDrugDict 
        ///Delete Table MED_DRUG_DICT by (string DRUG_CODE,string DRUG_SPEC)
        /// </summary>
        public int DeleteMedDrugDict(string DRUG_CODE, string DRUG_SPEC)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedDrugDict");
                if (DRUG_CODE != null)
                    oneDelete[0].Value = DRUG_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (DRUG_SPEC != null)
                    oneDelete[1].Value = DRUG_SPEC;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DRUG_DICT_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedDrugDict 
        ///select Table MED_DRUG_DICT by (string DRUG_CODE,string DRUG_SPEC)
        /// </summary>
        public MedDrugDict SelectMedDrugDict(string DRUG_CODE, string DRUG_SPEC)
        {
            MedDrugDict model;
            OracleParameter[] parameterValues = GetParameter("SelectMedDrugDict");
            parameterValues[0].Value = DRUG_CODE;
            parameterValues[1].Value = DRUG_SPEC;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DRUG_DICT_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedDrugDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DrugCode = oleReader["DRUG_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DrugName = oleReader["DRUG_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DrugSpec = oleReader["DRUG_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DrugForm = oleReader["DRUG_FORM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DosePerUnit = decimal.Parse(oleReader["DOSE_PER_UNIT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DoseUnits = oleReader["DOSE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.DrugClass = oleReader["DRUG_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AnestheticClass = oleReader["ANESTHETIC_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
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
        public List<MedDrugDict> SelectMedDrugDictList()
        {
            List<MedDrugDict> modelList = new List<MedDrugDict>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DRUG_DICT_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedDrugDict model = new MedDrugDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DrugCode = oleReader["DRUG_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DrugName = oleReader["DRUG_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DrugSpec = oleReader["DRUG_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DrugForm = oleReader["DRUG_FORM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DosePerUnit = decimal.Parse(oleReader["DOSE_PER_UNIT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DoseUnits = oleReader["DOSE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.DrugClass = oleReader["DRUG_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AnestheticClass = oleReader["ANESTHETIC_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

    }
}
