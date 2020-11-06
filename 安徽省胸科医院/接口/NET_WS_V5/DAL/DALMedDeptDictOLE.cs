using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedDeptDict
    {


        private static readonly string Select_MedDeptDict_OLE = "SELECT SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS FROM MED_DEPT_DICT WHERE dept_code = ? ";
        private static readonly string Select_MedDeptDict_Name_OLE = "SELECT SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS FROM MED_DEPT_DICT WHERE dept_name = ? ";
        private static readonly string Insert_MedDeptDict_OLE = "INSERT INTO MED_DEPT_DICT (SORT_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE,WARD_CODE,DEPT_TYPE,DEPT_ALIAS) values (?,?,?,?,?,?,?)";
        private static readonly string Update_MedDeptDict_OLE = "UPDATE MED_DEPT_DICT SET SORT_NO=?,DEPT_NAME=?,INPUT_CODE=?,WARD_CODE=?,DEPT_TYPE=?,DEPT_ALIAS=? WHERE DEPT_CODE=?";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedDeptDict")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("deptCode",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "SelectMedDeptDictName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("deptName",OleDbType.VarChar)
                    };
                }
                if (sqlParms == "InsertMedDeptDict")
                {
                    parms = new OleDbParameter[]{
						    new OleDbParameter("SortNo",OleDbType.Decimal),
							new OleDbParameter("DeptCode",OleDbType.VarChar),
							new OleDbParameter("DeptName",OleDbType.VarChar),
							new OleDbParameter("InputCode",OleDbType.VarChar),
                            new OleDbParameter("WardCode",OleDbType.VarChar),
							new OleDbParameter("DeptType",OleDbType.VarChar),
							new OleDbParameter("DeptAlias",OleDbType.VarChar),
                        };
                }
                else if (sqlParms == "UpdateMedDeptDict")
                {
                    parms = new OleDbParameter[]{
						    new OleDbParameter("SortNo",OleDbType.Decimal),
							new OleDbParameter("DeptName",OleDbType.VarChar),
							new OleDbParameter("InputCode",OleDbType.VarChar),
                            new OleDbParameter("WardCode",OleDbType.VarChar),
							new OleDbParameter("DeptType",OleDbType.VarChar),
							new OleDbParameter("DeptAlias",OleDbType.VarChar),
							new OleDbParameter("DeptCode",OleDbType.Decimal),
                        };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedDeptDict SelectMedDeptDictOLE(string deptCode)
        {
            Model.MedDeptDict model = null;

            OleDbParameter[] paramDeptDict = GetParameterOLE("SelectMedDeptDict");
            paramDeptDict[0].Value = deptCode;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedDeptDict_OLE, paramDeptDict))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedDeptDict();
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

        public Model.MedDeptDict SelectMedDeptDictNameOLE(string deptName)
        {
            Model.MedDeptDict model = null;

            OleDbParameter[] paramDeptDict = GetParameterOLE("SelectMedDeptDictName");
            paramDeptDict[0].Value = deptName;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedDeptDict_Name_OLE, paramDeptDict))
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

        public int InsertMedDeptDictOLE(Model.MedDeptDict model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedDeptDict");
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

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedDeptDict_OLE, oneInert);
            }
        }

        public int UpdateMedDeptDictOLE(Model.MedDeptDict model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedDeptDict");

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
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedDeptDict_OLE, oneUpdate);
            }
        }

        private static readonly string Select_MedDeptDict_Odbc = "SELECT SERIAL_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE FROM MED_DEPT_DICT WHERE dept_code = ? ";
        private static readonly string Select_MedDeptDict_Name_Odbc = "SELECT SERIAL_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE FROM MED_DEPT_DICT WHERE dept_name = ? ";
        private static readonly string Insert_MedDeptDict_Odbc = "INSERT INTO MED_DEPT_DICT (SERIAL_NO,DEPT_CODE,DEPT_NAME,INPUT_CODE)values(?, ?, ?, ?)";
        private static readonly string Update_MedDeptDict_Odbc = "UPDATE MED_DEPT_DICT SET SERIAL_NO = ?,DEPT_NAME = ?,INPUT_CODE = ? where DEPT_CODE = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedDeptDict")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("deptCode",OdbcType.VarChar)
                    };
                }
                else if (sqlParms == "SelectMedDeptDictName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("deptName",OdbcType.VarChar)
                    };
                }
                if (sqlParms == "InsertMedDeptDict")
                {
                    parms = new OdbcParameter[]{
						    new OdbcParameter("@SortNo",OdbcType.Decimal),
							new OdbcParameter("@DeptCode",OdbcType.VarChar),
							new OdbcParameter("@DeptName",OdbcType.VarChar),
							new OdbcParameter("@InputCode",OdbcType.VarChar),
                            new OdbcParameter("@WardCode",OdbcType.VarChar),
							new OdbcParameter("@DeptType",OdbcType.VarChar),
							new OdbcParameter("@DeptAlias",OdbcType.VarChar),
                        };
                }
                else if (sqlParms == "UpdateMedDeptDict")
                {
                    parms = new OdbcParameter[]{
						    new OdbcParameter("@SortNo",OdbcType.Decimal),
							new OdbcParameter("@DeptName",OdbcType.VarChar),
							new OdbcParameter("@InputCode",OdbcType.VarChar),
                            new OdbcParameter("@WardCode",OdbcType.VarChar),
							new OdbcParameter("@DeptType",OdbcType.VarChar),
							new OdbcParameter("@DeptAlias",OdbcType.VarChar),
							new OdbcParameter("@DeptCode",OdbcType.Decimal),
                        };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedDeptDict SelectMedDeptDictOdbc(string deptCode)
        {
            Model.MedDeptDict OneMedDeptDict = null;

            OdbcParameter[] paramDeptDict = GetParameterOdbc("SelectMedDeptDict");
            paramDeptDict[0].Value = deptCode;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedDeptDict_Odbc, paramDeptDict))
            {
                if (OdbcReader.Read())
                {
                    OneMedDeptDict = new Model.MedDeptDict();
                    //OneMedDeptDict.DeptCode = OdbcReader.GetString(1);
                    //if (!OdbcReader.IsDBNull(0))
                    //    OneMedDeptDict.SerialNo = OdbcReader.GetDecimal(0);
                    //if (!OdbcReader.IsDBNull(2))
                    //    OneMedDeptDict.DeptName = OdbcReader.GetString(2);
                    //if (!OdbcReader.IsDBNull(3))
                    //    OneMedDeptDict.InputCode = OdbcReader.GetString(3);
                }
                else
                    OneMedDeptDict = null;
            }
            return OneMedDeptDict;
        }

        public Model.MedDeptDict SelectMedDeptDictNameOdbc(string deptName)
        {
            Model.MedDeptDict OneMedDeptDict = null;

            OdbcParameter[] paramDeptDict = GetParameterOdbc("SelectMedDeptDictName");
            paramDeptDict[0].Value = deptName;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedDeptDict_Name_Odbc, paramDeptDict))
            {
                if (OdbcReader.Read())
                {
                    OneMedDeptDict = new Model.MedDeptDict();
                    //OneMedDeptDict.DeptCode = OdbcReader.GetString(1);
                    //if (!OdbcReader.IsDBNull(0))
                    //    OneMedDeptDict.SerialNo = OdbcReader.GetDecimal(0);
                    //if (!OdbcReader.IsDBNull(2))
                    //    OneMedDeptDict.DeptName = OdbcReader.GetString(2);
                    //if (!OdbcReader.IsDBNull(3))
                    //    OneMedDeptDict.InputCode = OdbcReader.GetString(3);
                }
                else
                    OneMedDeptDict = null;
            }
            return OneMedDeptDict;
        }

        public int InsertMedDeptDictOdbc(Model.MedDeptDict MedDeptDict)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedDeptDict");
                //if (MedDeptDict.SerialNo.ToString() != null)
                //    oneInert[0].Value = MedDeptDict.SerialNo;
                //else
                //    oneInert[0].Value = DBNull.Value;
                //oneInert[1].Value = MedDeptDict.DeptCode;
                //if (MedDeptDict.DeptName != null)
                //    oneInert[2].Value = MedDeptDict.DeptName;
                //else
                //    oneInert[2].Value = DBNull.Value;
                //if (MedDeptDict.InputCode != null)
                //    oneInert[3].Value = MedDeptDict.InputCode;
                //else
                //    oneInert[3].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedDeptDict_Odbc, oneInert);
            }
        }

        public int UpdateMedDeptDictOdbc(Model.MedDeptDict MedDeptDict)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedDeptDict");

                //if (MedDeptDict.SerialNo.ToString() != null)
                //    oneUpdate[0].Value = MedDeptDict.SerialNo;
                //else
                //    oneUpdate[0].Value = DBNull.Value;

                //if (MedDeptDict.DeptName != null)
                //    oneUpdate[1].Value = MedDeptDict.DeptName;
                //else
                //    oneUpdate[1].Value = DBNull.Value;
                //if (MedDeptDict.InputCode != null)
                //    oneUpdate[2].Value = MedDeptDict.InputCode;
                //else
                //    oneUpdate[2].Value = DBNull.Value;
                //oneUpdate[3].Value = MedDeptDict.DeptCode;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedDeptDict_Odbc, oneUpdate);
            }
        }
    }
}
