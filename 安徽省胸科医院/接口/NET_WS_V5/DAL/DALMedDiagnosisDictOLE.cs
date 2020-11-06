using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using System.Data.Odbc;
using System.Data;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedDiagnosisDict
    {
        private static readonly string MED_DIAGNOSIS_DICT_Insert_OLE = "INSERT INTO MED_DIAGNOSIS_DICT (DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR) values (?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_DIAGNOSIS_DICT_Update_OLE = "UPDATE MED_DIAGNOSIS_DICT SET DIAGNOSIS_CODE=?,DIAGNOSIS_NAME=?,STD_INDICATOR=?,APPROVED_INDICATOR=?,CREATE_DATE=?,INPUT_CODE=?,INFECT_INDICATOR=?,HEALTH_LEVEL=?,INPUT_CODE_WB=?,DISEASE_SORT=?,DIAG_INDICATOR=? WHERE DIAGNOSIS_CODE=?";
        private static readonly string MED_DIAGNOSIS_DICT_Delete_OLE = "Delete MED_DIAGNOSIS_DICT WHERE DIAGNOSIS_CODE=@DiagnosisCode";
        private static readonly string MED_DIAGNOSIS_DICT_Select_OLE = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT where DIAGNOSIS_CODE=?";
        private static readonly string MED_DIAGNOSIS_DICT_Select_Name_OLE = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT where DIAGNOSIS_NAME=?";
        private static readonly string MED_DIAGNOSIS_DICT_Select_ALL_OLE = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT";


        private static readonly string MED_DIAGNOSIS_DICT_Insert_ODBC = "INSERT INTO MED_DIAGNOSIS_DICT (DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR) values (?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_DIAGNOSIS_DICT_Update_ODBC = "UPDATE MED_DIAGNOSIS_DICT SET DIAGNOSIS_CODE=?,DIAGNOSIS_NAME=?,STD_INDICATOR=?,APPROVED_INDICATOR=?,CREATE_DATE=?,INPUT_CODE=?,INFECT_INDICATOR=?,HEALTH_LEVEL=?,INPUT_CODE_WB=?,DISEASE_SORT=?,DIAG_INDICATOR=? WHERE DIAGNOSIS_CODE=?";
        private static readonly string MED_DIAGNOSIS_DICT_Delete_ODBC = "Delete MED_DIAGNOSIS_DICT WHERE DIAGNOSIS_CODE=@DiagnosisCode";
        private static readonly string MED_DIAGNOSIS_DICT_Select_ODBC = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT where DIAGNOSIS_CODE=?";
        private static readonly string MED_DIAGNOSIS_DICT_Select_Name_ODBC = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT where DIAGNOSIS_NAME=?";
        private static readonly string MED_DIAGNOSIS_DICT_Select_ALL_ODBC = "SELECT DIAGNOSIS_CODE,DIAGNOSIS_NAME,STD_INDICATOR,APPROVED_INDICATOR,CREATE_DATE,INPUT_CODE,INFECT_INDICATOR,HEALTH_LEVEL,INPUT_CODE_WB,DISEASE_SORT,DIAG_INDICATOR FROM MED_DIAGNOSIS_DICT";


        

        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedDiagnosisDict SQL
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDiagnosisDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("DiagnosisCode",OleDbType.VarChar),
							new OleDbParameter("DiagnosisName",OleDbType.VarChar),
							new OleDbParameter("StdIndicator",OleDbType.Numeric),
                            new OleDbParameter("ApprovedIndicator",OleDbType.Numeric),
                            new OleDbParameter("CreateDate",OleDbType.DBTimeStamp),
                            new OleDbParameter("InputCode",OleDbType.VarChar),
                            new OleDbParameter("InffctIndicator",OleDbType.VarChar),
                            new OleDbParameter("HealthLevel",OleDbType.VarChar),
                            new OleDbParameter("InputCodeWb",OleDbType.VarChar), 
                            new OleDbParameter("DiseaseSort",OleDbType.VarChar),
                            new OleDbParameter("DiagIndicator",OleDbType.Numeric),
                        };
                }
                else if (sqlParms == "UpdateMedDiagnosisDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("DiagnosisCode",OleDbType.VarChar),
							new OleDbParameter("DiagnosisName",OleDbType.VarChar),
							new OleDbParameter("StdIndicator",OleDbType.Numeric),
                            new OleDbParameter("ApprovedIndicator",OleDbType.Numeric),
                            new OleDbParameter("CreateDate",OleDbType.DBTimeStamp),
                            new OleDbParameter("InputCode",OleDbType.VarChar),
                            new OleDbParameter("InffctIndicator",OleDbType.VarChar),
                            new OleDbParameter("HealthLevel",OleDbType.VarChar),
                            new OleDbParameter("InputCodeWb",OleDbType.VarChar), 
                            new OleDbParameter("DiseaseSort",OleDbType.VarChar),
                            new OleDbParameter("DiagIndicator",OleDbType.Numeric),
                            new OleDbParameter("DiagnosisCode1",OleDbType.VarChar),
                        };
                }
                else if (sqlParms == "DeleteMedDiagnosisDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("DiagnosisCode",OleDbType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedDiagnosisDict")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("DiagnosisCode",OleDbType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedDiagnosisDictName")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("DiagnosisName",OleDbType.VarChar),
                        };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedDiagnosisDict 
        ///Insert Table MED_Diagnosis_DICT
        /// </summary>
        public int InsertMedDiagnosisDictOLE(MedDiagnosisDict model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedDiagnosisDict");

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

                foreach (OleDbParameter p in oneInert)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                }
                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, System.Data.CommandType.Text ,MED_DIAGNOSIS_DICT_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedDiagnosisDict 
        ///Update Table     MED_Diagnosis_DICT
        /// </summary>
        public int UpdateMedDiagnosisDictOLE(MedDiagnosisDict model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedDiagnosisDict");
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

                foreach (OleDbParameter p in oneUpdate)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                }
                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, System.Data.CommandType.Text, MED_DIAGNOSIS_DICT_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedDiagnosisDict 
        ///Delete Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
        /// </summary>
        public int DeleteMedDiagnosisDictOLE(string Diagnosis_CODE)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedDiagnosisDict");

                if (Diagnosis_CODE != null)
                    oneDelete[0].Value = Diagnosis_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, System.Data.CommandType.Text ,MED_DIAGNOSIS_DICT_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedDiagnosisDict 
        ///select Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
        /// </summary>
        public MedDiagnosisDict SelectMedDiagnosisDictOLE(string Diagnosis_CODE)
        {
            MedDiagnosisDict model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedDiagnosisDict");
            parameterValues[0].Value = Diagnosis_CODE;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_OLE, parameterValues))
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
        #region  [获取一条记录SQL-Diagnosis_NAME]
        /// <summary>
        ///Select    model  MedDiagnosisDict 
        ///select Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
        /// </summary>
        public MedDiagnosisDict SelectMedDiagnosisDictNameOle(string Diagnosis_NAME)
        {
            MedDiagnosisDict model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedDiagnosisDictName");
            parameterValues[0].Value = Diagnosis_NAME;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_Name_OLE, parameterValues))
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
        #region  [获取所有记录SQL]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedDiagnosisDict> SelectMedDiagnosisDictListOLE()
        {
            List<MedDiagnosisDict> modelList = new List<MedDiagnosisDict>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_ALL_OLE, null))
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

        #region [获取参数]
        /// <summary>
        ///获取参数MedDiagnosisDict
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDiagnosisDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("DiagnosisCode",OdbcType.VarChar),
							new OdbcParameter("DiagnosisName",OdbcType.VarChar),
							new OdbcParameter("StdIndicator",OdbcType.Numeric),
                            new OdbcParameter("ApprovedIndicator",OdbcType.Numeric),
                            new OdbcParameter("CreateDate",OdbcType.DateTime),
                            new OdbcParameter("InputCode",OdbcType.VarChar),
                            new OdbcParameter("InffctIndicator",OdbcType.VarChar),
                            new OdbcParameter("HealthLevel",OdbcType.VarChar),
                            new OdbcParameter("InputCodeWb",OdbcType.VarChar), 
                            new OdbcParameter("DiseaseSort",OdbcType.VarChar),
                            new OdbcParameter("DiagIndicator",OdbcType.Numeric),
                        };
                }
                else if (sqlParms == "UpdateMedDiagnosisDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("DiagnosisCode",OdbcType.VarChar),
							new OdbcParameter("DiagnosisName",OdbcType.VarChar),
							new OdbcParameter("StdIndicator",OdbcType.Numeric),
                            new OdbcParameter("ApprovedIndicator",OdbcType.Numeric),
                            new OdbcParameter("CreateDate",OdbcType.DateTime),
                            new OdbcParameter("InputCode",OdbcType.VarChar),
                            new OdbcParameter("InffctIndicator",OdbcType.VarChar),
                            new OdbcParameter("HealthLevel",OdbcType.VarChar),
                            new OdbcParameter("InputCodeWb",OdbcType.VarChar), 
                            new OdbcParameter("DiseaseSort",OdbcType.VarChar),
                            new OdbcParameter("DiagIndicator",OdbcType.Numeric),
                            new OdbcParameter("DiagnosisCode1",OdbcType.VarChar),
                        };
                }
                else if (sqlParms == "DeleteMedDiagnosisDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("DiagnosisCode",OdbcType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedDiagnosisDict")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("DiagnosisCode",OdbcType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedDiagnosisDictName")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("DiagnosisName",OdbcType.VarChar),
                        };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedDiagnosisDict 
        ///Insert Table MED_Diagnosis_DICT
        /// </summary>
        public int InsertMedDiagnosisDict_Odbc(MedDiagnosisDict model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedDiagnosisDict");
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

                foreach (OdbcParameter p in oneInert)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                }
                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text ,MED_DIAGNOSIS_DICT_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedDiagnosisDict 
        ///Update Table     MED_Diagnosis_DICT
        /// </summary>
        public int UpdateMedDiagnosisDict_Odbc(MedDiagnosisDict model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedDiagnosisDict");
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

                foreach (OdbcParameter p in oneUpdate)
                {
                    if (p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                }
                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text ,MED_DIAGNOSIS_DICT_Update_ODBC, oneUpdate);
            }
        }

        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedDiagnosisDict 
        ///Delete Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
        /// </summary>
        public int DeleteMedDiagnosisDict_Odbc(string Diagnosis_CODE)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedDiagnosisDict");
                if (Diagnosis_CODE != null)
                    oneDelete[0].Value = Diagnosis_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text,MED_DIAGNOSIS_DICT_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedDiagnosisDict 
        ///select Table MED_Diagnosis_DICT by (string Diagnosis_CODE)
        /// </summary>
        public MedDiagnosisDict SelectMedDiagnosisDict_Odbc(string Diagnosis_CODE)
        {
            MedDiagnosisDict model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedDiagnosisDict");
            parameterValues[0].Value = Diagnosis_CODE;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_ODBC, parameterValues))
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
        public MedDiagnosisDict SelectMedDiagnosisDictName_Odbc(string Diagnosis_NAME)
        {
            MedDiagnosisDict model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedDiagnosisDictName");
            parameterValues[0].Value = Diagnosis_NAME;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_Name_ODBC, parameterValues))
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
        public List<MedDiagnosisDict> SelectMedDiagnosisDictList_Odbc()
        {
            List<MedDiagnosisDict> modelList = new List<MedDiagnosisDict>();
      
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_DIAGNOSIS_DICT_Select_ALL_ODBC, null))
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
