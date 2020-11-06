

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
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedPackageMaster
    /// </summary>

    public partial class DALMedPackageMaster
    {
        private static readonly string MED_PACKAGE_MASTER_Select_SQL = "SELECT BAR_CODE,PACKAGE_NAME,STERILIZE_DATE,TODAY_USE_TIMES,EXP_DATE,PACKAGE_OPERATOR,MEMO FROM MED_PACKAGE_MASTER WHERE BAR_CODE = @BarCode";
        private static readonly string MED_PACKAGE_MASTER_Insert_SQL = "INSERT INTO MED_PACKAGE_MASTER (BAR_CODE,PACKAGE_NAME,STERILIZE_DATE,TODAY_USE_TIMES,EXP_DATE,PACKAGE_OPERATOR,MEMO) values (@BarCode,@PackageName,@SterilizeDate,@TodayUseTimes,@ExpDate,@PackageOperator,@Memo)";
        private static readonly string MED_PACKAGE_MASTER_Update_SQL = "UPDATE MED_PACKAGE_MASTER SET BAR_CODE=@BarCode,PACKAGE_NAME=@PackageName,STERILIZE_DATE=@SterilizeDate,TODAY_USE_TIMES=@TodayUseTimes,EXP_DATE=@ExpDate,PACKAGE_OPERATOR=@PackageOperator,MEMO=@Memo WHERE BAR_CODE = @BarCodeP";
        private static readonly string MED_PACKAGE_MASTER_Delete_SQL = "Delete MED_PACKAGE_MASTER WHERE BAR_CODE = @BarCode";

        private static readonly string MED_PACKAGE_MASTER_Select = "SELECT BAR_CODE,PACKAGE_NAME,STERILIZE_DATE,TODAY_USE_TIMES,EXP_DATE,PACKAGE_OPERATOR,MEMO FROM MED_PACKAGE_MASTER WHERE BAR_CODE = :BarCode";
        private static readonly string MED_PACKAGE_MASTER_Insert = "INSERT INTO MED_PACKAGE_MASTER (BAR_CODE,PACKAGE_NAME,STERILIZE_DATE,TODAY_USE_TIMES,EXP_DATE,PACKAGE_OPERATOR,MEMO) values (:BarCode,:PackageName,:SterilizeDate,:TodayUseTimes,:ExpDate,:PackageOperator,:Memo)";
        private static readonly string MED_PACKAGE_MASTER_Update = "UPDATE MED_PACKAGE_MASTER SET BAR_CODE=:BarCode,PACKAGE_NAME=:PackageName,STERILIZE_DATE=:SterilizeDate,TODAY_USE_TIMES=:TodayUseTimes,EXP_DATE=:ExpDate,PACKAGE_OPERATOR=:PackageOperator,MEMO=:Memo WHERE BAR_CODE = :BarCodeP";
        private static readonly string MED_PACKAGE_MASTER_Delete = "Delete MED_PACKAGE_MASTER WHERE BAR_CODE = :BarCode";
        public DALMedPackageMaster()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedHisUsers SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPackageMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@BarCode",SqlDbType.VarChar),
							new SqlParameter("@PackageName",SqlDbType.VarChar),
							new SqlParameter("@SterilizeDate",SqlDbType.DateTime),
							new SqlParameter("@TodayUseTimes",SqlDbType.VarChar),
							new SqlParameter("@ExpDate",SqlDbType.DateTime),
							new SqlParameter("@PackageOperator",SqlDbType.VarChar),
							new SqlParameter("@Memo",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPackageMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@BarCode",SqlDbType.VarChar),
							new SqlParameter("@PackageName",SqlDbType.VarChar),
							new SqlParameter("@SterilizeDate",SqlDbType.DateTime),
							new SqlParameter("@TodayUseTimes",SqlDbType.VarChar),
							new SqlParameter("@ExpDate",SqlDbType.DateTime),
							new SqlParameter("@PackageOperator",SqlDbType.VarChar),
							new SqlParameter("@Memo",SqlDbType.VarChar),
                            new SqlParameter("@BarCodeP",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPackageMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@BarCode",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@BarCode",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MEDPACKAGEMASTER 
        ///Insert Table MED_PACKAGE_MASTER
        /// </summary>
        public int InsertMedPackageMasterSQL(MedPackageMaster model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedPackageMaster");
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

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PACKAGE_MASTER_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedPackageMaster 
        ///Update Table     MED_Package_Master
        /// </summary>
        public int UpdateMedPackageMasterSQL(MedPackageMaster model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPackageMaster");
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

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedPackageMaster 
        ///Delete Table Med_Package_Master by (string USER_ID)
        /// </summary>
        public int DeleteMedPackageMasterSQL(string Bar_Code)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPackageMaster");
                if (Bar_Code != null)
                    oneDelete[0].Value = Bar_Code;
                else
                    oneDelete[0].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PACKAGE_MASTER_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedPackageMaster 
        ///select Table Med_Package_Master by (string USER_ID)
        /// </summary>
        public MedPackageMaster SelectMedPackageMasterSQL(string Bar_Code)
        {
            MedPackageMaster model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedPackageMaster");
            parameterValues[0].Value = Bar_Code;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Select_SQL, parameterValues))
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

        #region [获取参数]
        /// <summary>
        ///获取参数MedHisUsers
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {//:BarCode,:PackageName,:SterilizeDate,:TodayUseTimes,:ExpDate,:PackageOperator,:Memo
                if (sqlParms == "InsertMedPackageMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":BarCode",OracleType.VarChar),
							new OracleParameter(":PackageName",OracleType.VarChar),
							new OracleParameter(":SterilizeDate",OracleType.DateTime),
							new OracleParameter(":TodayUseTimes",OracleType.VarChar),
							new OracleParameter(":ExpDate",OracleType.DateTime),
							new OracleParameter(":PackageOperator",OracleType.VarChar),
							new OracleParameter(":Memo",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPackageMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":BarCode",OracleType.VarChar),
							new OracleParameter(":PackageName",OracleType.VarChar),
							new OracleParameter(":SterilizeDate",OracleType.DateTime),
							new OracleParameter(":TodayUseTimes",OracleType.VarChar),
							new OracleParameter(":ExpDate",OracleType.DateTime),
							new OracleParameter(":PackageOperator",OracleType.VarChar),
							new OracleParameter(":Memo",OracleType.VarChar),
                            new OracleParameter(":BarCodeP",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPackageMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":BarCode",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":BarCode",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedPackageMaster 
        ///Insert Table Med_Package_Master
        /// </summary>
        public int InsertMedPackageMaster(MedPackageMaster model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedPackageMaster");
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

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PACKAGE_MASTER_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedPackageMaster 
        ///Update Table     Med_Package_Master
        /// </summary>
        public int UpdateMedPackageMaster(MedPackageMaster model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedPackageMaster");
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

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedHisUsers 
        ///Delete Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public int DeleteMedPackageMaster(string Bar_Code)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedPackageMaster");
                if (Bar_Code != null)
                    oneDelete[0].Value = Bar_Code;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PACKAGE_MASTER_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedPackageMaster 
        ///select Table MedPackageMaster by (string Bar_Code)
        /// </summary>
        public MedPackageMaster SelectMedPackageMaster(string Bar_Code)
        {
            MedPackageMaster model;
            OracleParameter[] parameterValues = GetParameter("SelectMedPackageMaster");
            parameterValues[0].Value = Bar_Code;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_PACKAGE_MASTER_Select, parameterValues))
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
