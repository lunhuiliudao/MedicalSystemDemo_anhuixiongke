using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using System.Data.OracleClient;
using System.Data;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedDiagnosisDict
    {
        private static readonly string MED_DIAGNOSIS_DICT_Insert_SQL = "INSERT INTO MED_DIAGNOSIS_DICT (DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR) values (@DiagnosisCode,@DiagnosisName,@StdIndicator,@ApprovedIndicator,@CreateDate,@InputCode,@InffctIndicator,@HealthLevel,@InputCodeWb,@DiseaseSort,@DiagIndicator)";
        private static readonly string MED_DIAGNOSIS_DICT_Update_SQL = "UPDATE MED_DIAGNOSIS_DICT SET DIAGNOSIS_CODE=@DiagnosisCode,DIAGNOSIS_NAME=@DiagnosisName,STD_INDICATOR=@StdIndicator,APPROVED_INDICATOR=@ApprovedIndicator,CREATE_DATE=@CreateDate,INPUT_CODE=@InputCode,INFECT_INDICATOR=@InffctIndicator,HEALTH_LEVEL=@HealthLevel,INPUT_CODE_WB=@InputCodeWb,DISEASE_SORT=@DiseaseSort,DIAG_INDICATOR=@DiagIndicator WHERE DIAGNOSIS_CODE=@DiagnosisCode1";
        private static readonly string MED_DIAGNOSIS_DICT_Delete_SQL = "Delete MED_DIAGNOSIS_DICT WHERE DIAGNOSIS_CODE=@DiagnosisCode";
        private static readonly string MED_DIAGNOSIS_DICT_Select_SQL = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT where DIAGNOSIS_CODE=@DiagnosisCode";
        private static readonly string MED_DIAGNOSIS_DICT_Select_Name_SQL = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT where DIAGNOSIS_NAME=@DiagnosisName";
        private static readonly string MED_DIAGNOSIS_DICT_Select_ALL_SQL = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT";

        private static readonly string MED_DIAGNOSIS_DICT_Insert = "INSERT INTO MED_DIAGNOSIS_DICT (DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR) values (:DiagnosisCode,:DiagnosisName,:StdIndicator,:ApprovedIndicator,:CreateDate,:InputCode,:InffctIndicator,:HealthLevel,:InputCodeWb,:DiseaseSort,:DiagIndicator)";
        private static readonly string MED_DIAGNOSIS_DICT_Update = "UPDATE MED_DIAGNOSIS_DICT SET DIAGNOSIS_CODE=:DiagnosisCode,DIAGNOSIS_NAME=:DiagnosisName,STD_INDICATOR=:StdIndicator,APPROVED_INDICATOR=:ApprovedIndicator,CREATE_DATE=:CreateDate,INPUT_CODE=:InputCode,INFECT_INDICATOR=:InffctIndicator,HEALTH_LEVEL=:HealthLevel,INPUT_CODE_WB=:InputCodeWb,DISEASE_SORT=:DiseaseSort,DIAG_INDICATOR=:DiagIndicator WHERE DIAGNOSIS_CODE=:DiagnosisCode1";
        private static readonly string MED_DIAGNOSIS_DICT_Delete = "Delete MED_DIAGNOSIS_DICT WHERE DIAGNOSIS_CODE=:DiagnosisCode";
        private static readonly string MED_DIAGNOSIS_DICT_Select = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT where DIAGNOSIS_CODE=:DiagnosisCode";
        private static readonly string MED_DIAGNOSIS_DICT_Select_Name = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT where DIAGNOSIS_NAME=:DiagnosisName";
        private static readonly string MED_DIAGNOSIS_DICT_Select_ALL = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT";
	

		#region [获取参数SQL]
		/// <summary>
		///获取参数MedDiagnosisDict SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDiagnosisDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DiagnosisCode",SqlDbType.VarChar),
							new SqlParameter("@DiagnosisName",SqlDbType.VarChar),
							new SqlParameter("@StdIndicator",SqlDbType.Int),
                            new SqlParameter("@ApprovedIndicator",SqlDbType.Int),
                            new SqlParameter("@CreateDate",SqlDbType.DateTime),
                            new SqlParameter("@InputCode",SqlDbType.VarChar),
                            new SqlParameter("@InffctIndicator",SqlDbType.VarChar),
                            new SqlParameter("@HealthLevel",SqlDbType.VarChar),
                            new SqlParameter("@InputCodeWb",SqlDbType.VarChar), 
                            new SqlParameter("@DiseaseSort",SqlDbType.VarChar),
                            new SqlParameter("@DiagIndicator",SqlDbType.Int),
                        };
                }
				else if (sqlParms == "UpdateMedDiagnosisDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DiagnosisCode",SqlDbType.VarChar),
							new SqlParameter("@DiagnosisName",SqlDbType.VarChar),
							new SqlParameter("@StdIndicator",SqlDbType.Decimal),
                            new SqlParameter("@ApprovedIndicator",SqlDbType.Decimal),
                            new SqlParameter("@CreateDate",SqlDbType.DateTime),
                            new SqlParameter("@InputCode",SqlDbType.VarChar),
                            new SqlParameter("@InffctIndicator",SqlDbType.VarChar),
                            new SqlParameter("@HealthLevel",SqlDbType.VarChar),
                            new SqlParameter("@InputCodeWb",SqlDbType.VarChar), 
                            new SqlParameter("@DiseaseSort",SqlDbType.VarChar),
                            new SqlParameter("@DiagIndicator",SqlDbType.Decimal),
                            new SqlParameter("@DiagnosisCode1",SqlDbType.VarChar),
                        };
                }
				else if(sqlParms == "DeleteMedDiagnosisDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DiagnosisCode",SqlDbType.VarChar),
                        };
                }
				else if(sqlParms == "SelectMedDiagnosisDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DiagnosisCode",SqlDbType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedDiagnosisDictName")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DiagnosisName",SqlDbType.VarChar),
                        };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedDiagnosisDict 
		///Insert Table MED_Diagnosis_DICT
		/// </summary>
        public int InsertMedDiagnosisDictSQL(MedDiagnosisDict model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedDiagnosisDict");

                oneInert[0].Value = model.DiagnosisCode;
                oneInert[1].Value = model.DiagnosisName;
                oneInert[2].Value = model.StdIndicator;
                oneInert[3].Value = model.ApprovedIndicator;
                oneInert[4].Value = model.CreateDate;
                oneInert[5].Value = model.InputCode;
                oneInert[6].Value = model.InffctIndicator;
                oneInert[7].Value = model.HealthLevel;
                oneInert[8].Value = model.InputCodeWb;
                oneInert[9].Value = model.DiseaseSort;
                oneInert[10].Value = model.DiagIndicator;

                foreach (SqlParameter p in oneInert)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                }
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DIAGNOSIS_DICT_Insert_SQL, oneInert);
            }
        }
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedDiagnosisDict 
		///Update Table     MED_Diagnosis_DICT
		/// </summary>
		public int UpdateMedDiagnosisDictSQL(MedDiagnosisDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedDiagnosisDict");
                oneUpdate[0].Value = model.DiagnosisCode;
                oneUpdate[1].Value = model.DiagnosisName;
                oneUpdate[2].Value = model.StdIndicator;
                oneUpdate[3].Value = model.ApprovedIndicator;
                oneUpdate[4].Value = model.CreateDate;
                oneUpdate[5].Value = model.InputCode;
                oneUpdate[6].Value = model.InffctIndicator;
                oneUpdate[7].Value = model.HealthLevel;
                oneUpdate[8].Value = model.InputCodeWb;
                oneUpdate[9].Value = model.DiseaseSort;
                oneUpdate[10].Value = model.DiagIndicator;
                oneUpdate[11].Value = model.DiagnosisCode;

                foreach (SqlParameter p in oneUpdate)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                }
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DIAGNOSIS_DICT_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedDiagnosisDict 
		///Delete Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
		/// </summary>
		public int DeleteMedDiagnosisDictSQL(string Diagnosis_CODE)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedDiagnosisDict");

					if (Diagnosis_CODE != null)
						oneDelete[0].Value =Diagnosis_CODE;
					else
						oneDelete[0].Value = DBNull.Value;

                    return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DIAGNOSIS_DICT_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedDiagnosisDict 
		///select Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
		/// </summary>
        public MedDiagnosisDict SelectMedDiagnosisDictSQL(string Diagnosis_CODE)
        {
            MedDiagnosisDict model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedDiagnosisDict");
            parameterValues[0].Value = Diagnosis_CODE;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedDiagnosisDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DiagnosisCode =oleReader["DIAGNOSIS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DiagnosisName = oleReader["DIAGNOSIS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(4))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(6))
                    {
                        model.InffctIndicator = oleReader["INFECT_INDICATOR"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(7))
                    {
                        model.HealthLevel = oleReader["HEALTH_LEVEL"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(8))
                    {
                        model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(9))
                    {
                        model.DiseaseSort = oleReader["DISEASE_SORT"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(10))
                    {
                        model.DiagIndicator = decimal.Parse(oleReader["DIAG_INDICATOR"].ToString().Trim());
                    }
                }
                else
                    model = null;
            }
            return model;
        }
		#endregion	
        #region  [获取一条记录SQL-Diagnosis_NAME]
        /// <summary>
        ///Select    model  MedDiagnosisDict 
        ///select Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
        /// </summary>
        public MedDiagnosisDict SelectMedDiagnosisDictNameSQL(string Diagnosis_NAME)
        {
            MedDiagnosisDict model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedDiagnosisDictName");
            parameterValues[0].Value = Diagnosis_NAME;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_Name_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedDiagnosisDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DiagnosisCode =oleReader["DIAGNOSIS_CODE"].ToString().Trim() ;
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DiagnosisName = oleReader["DIAGNOSIS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(4))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(6))
                    {
                        model.InffctIndicator = oleReader["INFECT_INDICATOR"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(7))
                    {
                        model.HealthLevel = oleReader["HEALTH_LEVEL"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(8))
                    {
                        model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(9))
                    {
                        model.DiseaseSort = oleReader["DISEASE_SORT"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(10))
                    {
                        model.DiagIndicator = decimal.Parse(oleReader["DIAG_INDICATOR"].ToString().Trim());
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
		public List<MedDiagnosisDict> SelectMedDiagnosisDictListSQL()
		{
			List<MedDiagnosisDict> modelList = new List<MedDiagnosisDict>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedDiagnosisDict model = new MedDiagnosisDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DiagnosisCode =  oleReader["DIAGNOSIS_CODE"].ToString().Trim() ;
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DiagnosisName = oleReader["DIAGNOSIS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(4))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(6))
                    {
                        model.InffctIndicator = oleReader["INFECT_INDICATOR"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(7))
                    {
                        model.HealthLevel = oleReader["HEALTH_LEVEL"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(8))
                    {
                        model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(9))
                    {
                        model.DiseaseSort = oleReader["DISEASE_SORT"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(10))
                    {
                        model.DiagIndicator = decimal.Parse(oleReader["DIAG_INDICATOR"].ToString().Trim());
                    }
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedDiagnosisDict
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDiagnosisDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DiagnosisCode",OracleType.VarChar),
							new OracleParameter(":DiagnosisName",OracleType.VarChar),
							new OracleParameter(":StdIndicator",OracleType.Number),
                            new OracleParameter(":ApprovedIndicator",OracleType.Number),
                            new OracleParameter(":CreateDate",OracleType.DateTime),
                            new OracleParameter(":InputCode",OracleType.VarChar),
                            new OracleParameter(":InffctIndicator",OracleType.VarChar),
                            new OracleParameter(":HealthLevel",OracleType.VarChar),
                            new OracleParameter(":InputCodeWb",OracleType.VarChar), 
                            new OracleParameter(":DiseaseSort",OracleType.VarChar),
                            new OracleParameter(":DiagIndicator",OracleType.Number),
                        };
                }
                    
                else if (sqlParms == "UpdateMedDiagnosisDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DiagnosisCode",OracleType.VarChar),
							new OracleParameter(":DiagnosisName",OracleType.VarChar),
							new OracleParameter(":StdIndicator",OracleType.Number),
                            new OracleParameter(":ApprovedIndicator",OracleType.Number),
                            new OracleParameter(":CreateDate",OracleType.DateTime),
                            new OracleParameter(":InputCode",OracleType.VarChar),
                            new OracleParameter(":InffctIndicator",OracleType.VarChar),
                            new OracleParameter(":HealthLevel",OracleType.VarChar),
                            new OracleParameter(":InputCodeWb",OracleType.VarChar), 
                            new OracleParameter(":DiseaseSort",OracleType.VarChar),
                            new OracleParameter(":DiagIndicator",OracleType.Number),
                            new OracleParameter(":DiagnosisCode1",OracleType.VarChar),
                        };
                }
                else if (sqlParms == "DeleteMedDiagnosisDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DiagnosisCode",OracleType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedDiagnosisDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DiagnosisCode",OracleType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedDiagnosisDictName")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DiagnosisName",OracleType.VarChar),
                        };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedDiagnosisDict 
		///Insert Table MED_Diagnosis_DICT
		/// </summary>
		public int InsertMedDiagnosisDict(MedDiagnosisDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedDiagnosisDict");
                oneInert[0].Value = model.DiagnosisCode;
                oneInert[1].Value = model.DiagnosisName;
                oneInert[2].Value = model.StdIndicator;
                oneInert[3].Value = model.ApprovedIndicator;
                oneInert[4].Value = model.CreateDate;
                oneInert[5].Value = model.InputCode;
                oneInert[6].Value = model.InffctIndicator;
                oneInert[7].Value = model.HealthLevel;
                oneInert[8].Value = model.InputCodeWb;
                oneInert[9].Value = model.DiseaseSort;
                oneInert[10].Value = model.DiagIndicator;

                foreach (OracleParameter p in oneInert)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                }
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DIAGNOSIS_DICT_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedDiagnosisDict 
		///Update Table     MED_Diagnosis_DICT
		/// </summary>
		public int UpdateMedDiagnosisDict(MedDiagnosisDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedDiagnosisDict");
                oneUpdate[0].Value = model.DiagnosisCode;
                oneUpdate[1].Value = model.DiagnosisName;
                oneUpdate[2].Value = model.StdIndicator;
                oneUpdate[3].Value = model.ApprovedIndicator;
                oneUpdate[4].Value = model.CreateDate;
                oneUpdate[5].Value = model.InputCode;
                oneUpdate[6].Value = model.InffctIndicator;
                oneUpdate[7].Value = model.HealthLevel;
                oneUpdate[8].Value = model.InputCodeWb;
                oneUpdate[9].Value = model.DiseaseSort;
                oneUpdate[10].Value = model.DiagIndicator;
                oneUpdate[11].Value = model.DiagnosisCode;

                foreach (OracleParameter p in oneUpdate)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                }
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DIAGNOSIS_DICT_Update, oneUpdate);
			}
		}

		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedDiagnosisDict 
		///Delete Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
		/// </summary>
		public int DeleteMedDiagnosisDict(string Diagnosis_CODE)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedDiagnosisDict");
					if (Diagnosis_CODE != null)
						oneDelete[0].Value =Diagnosis_CODE;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DIAGNOSIS_DICT_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedDiagnosisDict 
		///select Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
		/// </summary>
		public MedDiagnosisDict  SelectMedDiagnosisDict(string Diagnosis_CODE)
		{
			MedDiagnosisDict model;
			OracleParameter[] parameterValues = GetParameter("SelectMedDiagnosisDict");
			parameterValues[0].Value=Diagnosis_CODE;

			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedDiagnosisDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DiagnosisCode = oleReader["DIAGNOSIS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DiagnosisName = oleReader["DIAGNOSIS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(4))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(6))
                    {
                        model.InffctIndicator = oleReader["INFECT_INDICATOR"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(7))
                    {
                        model.HealthLevel = oleReader["HEALTH_LEVEL"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(8))
                    {
                        model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(9))
                    {
                        model.DiseaseSort = oleReader["DISEASE_SORT"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(10))
                    {
                        model.DiagIndicator = decimal.Parse(oleReader["DIAG_INDICATOR"].ToString().Trim());
                    }
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取一条记录-Diagnosis_NAME]
        /// <summary>
        ///Select    model  MedDiagnosisDict 
        ///select Table MED_Diagnosis_DICT by (string Diagnosis_NAME)
        /// </summary>
        public MedDiagnosisDict SelectMedDiagnosisDictName(string Diagnosis_NAME)
        {
            MedDiagnosisDict model;
            OracleParameter[] parameterValues = GetParameter("SelectMedDiagnosisDictName");
            parameterValues[0].Value = Diagnosis_NAME;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_Name, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedDiagnosisDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DiagnosisCode = oleReader["DIAGNOSIS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DiagnosisName = oleReader["DIAGNOSIS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(4))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(6))
                    {
                        model.InffctIndicator = oleReader["INFECT_INDICATOR"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(7))
                    {
                        model.HealthLevel = oleReader["HEALTH_LEVEL"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(8))
                    {
                        model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(9))
                    {
                        model.DiseaseSort = oleReader["DISEASE_SORT"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(10))
                    {
                        model.DiagIndicator = decimal.Parse(oleReader["DIAG_INDICATOR"].ToString().Trim());
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
		public List<MedDiagnosisDict> SelectMedDiagnosisDictList()
		{
			List<MedDiagnosisDict> modelList = new List<MedDiagnosisDict>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedDiagnosisDict model = new MedDiagnosisDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.DiagnosisCode = oleReader["DIAGNOSIS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.DiagnosisName = oleReader["DIAGNOSIS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.ApprovedIndicator = decimal.Parse(oleReader["APPROVED_INDICATOR"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(4))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }

                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(6))
                    {
                        model.InffctIndicator = oleReader["INFECT_INDICATOR"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(7))
                    {
                        model.HealthLevel = oleReader["HEALTH_LEVEL"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(8))
                    {
                        model.InputCodeWb = oleReader["INPUT_CODE_WB"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(9))
                    {
                        model.DiseaseSort = oleReader["DISEASE_SORT"].ToString().Trim();
                    }

                    if (!oleReader.IsDBNull(10))
                    {
                        model.DiagIndicator = decimal.Parse(oleReader["DIAG_INDICATOR"].ToString().Trim());
                    }
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
    }
}
