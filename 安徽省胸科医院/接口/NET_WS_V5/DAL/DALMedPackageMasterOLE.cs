

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:05
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
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedPackageMaster
    /// </summary>

    public partial class DALMedPackageMaster
    {
        private static readonly string MED_PACKAGE_MASTER_Select_OLE = "SELECT BAR_CODE,PACKAGE_NAME,STERILIZE_DATE,TODAY_USE_TIMES,EXP_DATE,PACKAGE_OPERATOR,MEMO FROM MED_PACKAGE_MASTER WHERE BAR_CODE = ?";
        private static readonly string MED_PACKAGE_MASTER_Insert_OLE = "INSERT INTO MED_PACKAGE_MASTER (BAR_CODE,PACKAGE_NAME,STERILIZE_DATE,TODAY_USE_TIMES,EXP_DATE,PACKAGE_OPERATOR,MEMO) values (?,?,?,?,?,?,?)";
        private static readonly string MED_PACKAGE_MASTER_Update_OLE = "UPDATE MED_PACKAGE_MASTER SET BAR_CODE=?,PACKAGE_NAME=?,STERILIZE_DATE=?,TODAY_USE_TIMES=?,EXP_DATE=?,PACKAGE_OPERATOR=?,MEMO=? WHERE BAR_CODE = ?";
        private static readonly string MED_PACKAGE_MASTER_Delete_OLE = "Delete MED_PACKAGE_MASTER WHERE BAR_CODE = ?";

        private static readonly string MED_PACKAGE_MASTER_Select_ODBC = "SELECT BAR_CODE,PACKAGE_NAME,STERILIZE_DATE,TODAY_USE_TIMES,EXP_DATE,PACKAGE_OPERATOR,MEMO FROM MED_PACKAGE_MASTER WHERE BAR_CODE = ?";
        private static readonly string MED_PACKAGE_MASTER_Insert_ODBC = "INSERT INTO MED_PACKAGE_MASTER (BAR_CODE,PACKAGE_NAME,STERILIZE_DATE,TODAY_USE_TIMES,EXP_DATE,PACKAGE_OPERATOR,MEMO) values (?,?,?,?,?,?,?)";
        private static readonly string MED_PACKAGE_MASTER_Update_ODBC = "UPDATE MED_PACKAGE_MASTER SET BAR_CODE=?,PACKAGE_NAME=?,STERILIZE_DATE=?,TODAY_USE_TIMES=?,EXP_DATE=?,PACKAGE_OPERATOR=?,MEMO=? WHERE BAR_CODE = ";
        private static readonly string MED_PACKAGE_MASTER_Delete_ODBC = "Delete MED_PACKAGE_MASTER WHERE BAR_CODE = ?";

        #region [获取参数OLE]
        /// <summary>
        ///获取参数MedHisUsers OLE
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPackageMaster")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("BarCode",OleDbType.VarChar),
							new OleDbParameter("PackageName",OleDbType.VarChar),
							new OleDbParameter("SterilizeDate",OleDbType.DBTimeStamp),
							new OleDbParameter("TodayUseTimes",OleDbType.VarChar),
							new OleDbParameter("ExpDate",OleDbType.DBTimeStamp),
							new OleDbParameter("PackageOperator",OleDbType.VarChar),
							new OleDbParameter("Memo",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPackageMaster")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("BarCode",OleDbType.VarChar),
							new OleDbParameter("PackageName",OleDbType.VarChar),
							new OleDbParameter("SterilizeDate",OleDbType.DBTimeStamp),
							new OleDbParameter("TodayUseTimes",OleDbType.VarChar),
							new OleDbParameter("ExpDate",OleDbType.DBTimeStamp),
							new OleDbParameter("PackageOperator",OleDbType.VarChar),
							new OleDbParameter("Memo",OleDbType.VarChar),
                            new OleDbParameter("BarCodeP",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPackageMaster")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("BarCode",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageMaster")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("BarCode",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MEDPACKAGEMASTER 
        ///Insert Table MED_PACKAGE_MASTER
        /// </summary>
        public int InsertMedPackageMasterOLE(MedPackageMaster model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedPackageMaster");
                if (model.BarCode != null)
                    oneInert[0].Value = model.BarCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.PackageName != null)
                    oneInert[1].Value = model.PackageName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.SterilizeDate > DateTime.MinValue)
                    oneInert[2].Value = model.SterilizeDate;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.TodayUseTimes != null)
                    oneInert[3].Value = model.TodayUseTimes;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.ExpDate > DateTime.MinValue)
                    oneInert[4].Value = model.ExpDate;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.PackageOperator != null)
                    oneInert[5].Value = model.PackageOperator;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Memo != null)
                    oneInert[6].Value = model.Memo;
                else
                    oneInert[6].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录OLE]
        /// <summary>
        ///Update    model  MedPackageMaster 
        ///Update Table     MED_Package_Master
        /// </summary>
        public int UpdateMedPackageMasterOLE(MedPackageMaster model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedPackageMaster");
                if (model.BarCode != null)
                    oneUpdate[0].Value = model.BarCode;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.PackageName != null)
                    oneUpdate[1].Value = model.PackageName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.SterilizeDate > DateTime.MinValue)
                    oneUpdate[2].Value = model.SterilizeDate;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.TodayUseTimes != null)
                    oneUpdate[3].Value = model.TodayUseTimes;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.ExpDate > DateTime.MinValue)
                    oneUpdate[4].Value = model.ExpDate;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.PackageOperator != null)
                    oneUpdate[5].Value = model.PackageOperator;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Memo != null)
                    oneUpdate[6].Value = model.Memo;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.BarCode != null)
                    oneUpdate[7].Value = model.BarCode;
                else
                    oneUpdate[7].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录OLE]
        /// <summary>
        ///Delete    model  MedPackageMaster 
        ///Delete Table Med_Package_Master by (string USER_ID)
        /// </summary>
        public int DeleteMedPackageMasterOLE(string Bar_Code)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedPackageMaster");
                if (Bar_Code != null)
                    oneDelete[0].Value = Bar_Code;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录OLE]
        /// <summary>
        ///Select    model  MedPackageMaster 
        ///select Table Med_Package_Master by (string USER_ID)
        /// </summary>
        public MedPackageMaster SelectMedPackageMasterOLE(string Bar_Code)
        {
            MedPackageMaster model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedPackageMaster");
            parameterValues[0].Value = Bar_Code;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPackageMaster();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.BarCode = oleReader["BAR_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.PackageName = oleReader["PACKAGE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.SterilizeDate = DateTime.Parse(oleReader["STERILIZE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.TodayUseTimes = oleReader["TODAY_USE_TIMES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ExpDate = DateTime.Parse(oleReader["EXP_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.PackageOperator = oleReader["PACKAGE_OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion

        #region [获取参数ODBC]
        /// <summary>
        ///获取参数MedHisUsers
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {//:BarCode,:PackageName,:SterilizeDate,:TodayUseTimes,:ExpDate,:PackageOperator,:Memo
                if (sqlParms == "InsertMedPackageMaster")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter(":BarCode",OdbcType.VarChar),
							new OdbcParameter(":PackageName",OdbcType.VarChar),
							new OdbcParameter(":SterilizeDate",OdbcType.DateTime),
							new OdbcParameter(":TodayUseTimes",OdbcType.VarChar),
							new OdbcParameter(":ExpDate",OdbcType.DateTime),
							new OdbcParameter(":PackageOperator",OdbcType.VarChar),
							new OdbcParameter(":Memo",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPackageMaster")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter(":BarCode",OdbcType.VarChar),
							new OdbcParameter(":PackageName",OdbcType.VarChar),
							new OdbcParameter(":SterilizeDate",OdbcType.DateTime),
							new OdbcParameter(":TodayUseTimes",OdbcType.VarChar),
							new OdbcParameter(":ExpDate",OdbcType.DateTime),
							new OdbcParameter(":PackageOperator",OdbcType.VarChar),
							new OdbcParameter(":Memo",OdbcType.VarChar),
                            new OdbcParameter(":BarCodeP",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPackageMaster")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter(":BarCode",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageMaster")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter(":BarCode",OdbcType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录ODBC]
        /// <summary>
        ///Add    model  MedPackageMaster 
        ///Insert Table Med_Package_Master
        /// </summary>
        public int InsertMedPackageMasterODBC(MedPackageMaster model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedPackageMaster");
                if (model.BarCode != null)
                    oneInert[0].Value = model.BarCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.PackageName != null)
                    oneInert[1].Value = model.PackageName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.SterilizeDate > DateTime.MinValue)
                    oneInert[2].Value = model.SterilizeDate;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.TodayUseTimes != null)
                    oneInert[3].Value = model.TodayUseTimes;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.ExpDate > DateTime.MinValue)
                    oneInert[4].Value = model.ExpDate;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.PackageOperator != null)
                    oneInert[5].Value = model.PackageOperator;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Memo != null)
                    oneInert[6].Value = model.Memo;
                else
                    oneInert[6].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录ODBC]
        /// <summary>
        ///Update    model  MedPackageMaster 
        ///Update Table     Med_Package_Master
        /// </summary>
        public int UpdateMedPackageMasterODBC(MedPackageMaster model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedPackageMaster");
                if (model.BarCode != null)
                    oneUpdate[0].Value = model.BarCode;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.PackageName != null)
                    oneUpdate[1].Value = model.PackageName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.SterilizeDate > DateTime.MinValue)
                    oneUpdate[2].Value = model.SterilizeDate;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.TodayUseTimes != null)
                    oneUpdate[3].Value = model.TodayUseTimes;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.ExpDate > DateTime.MinValue)
                    oneUpdate[4].Value = model.ExpDate;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.PackageOperator != null)
                    oneUpdate[5].Value = model.PackageOperator;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Memo != null)
                    oneUpdate[6].Value = model.Memo;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.BarCode != null)
                    oneUpdate[7].Value = model.BarCode;
                else
                    oneUpdate[7].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录ODBC]
        /// <summary>
        ///Delete    model  MedHisUsers 
        ///Delete Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public int DeleteMedPackageMasterODBC(string Bar_Code)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedPackageMaster");
                if (Bar_Code != null)
                    oneDelete[0].Value = Bar_Code;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录ODBC]
        /// <summary>
        ///Select    model  MedPackageMaster 
        ///select Table MedPackageMaster by (string Bar_Code)
        /// </summary>
        public MedPackageMaster SelectMedPackageMasterODBC(string Bar_Code)
        {
            MedPackageMaster model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedPackageMaster");
            parameterValues[0].Value = Bar_Code;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Select_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPackageMaster();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.BarCode = oleReader["BAR_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.PackageName = oleReader["PACKAGE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.SterilizeDate = DateTime.Parse(oleReader["STERILIZE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.TodayUseTimes = oleReader["TODAY_USE_TIMES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ExpDate = DateTime.Parse(oleReader["EXP_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.PackageOperator = oleReader["PACKAGE_OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
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
