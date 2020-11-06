

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
    /// DAL MedPackageDetail
    /// </summary>

    public partial class DALMedPackageDetail
    {
        private static readonly string MED_PACKAGE_DETAIL_Select_SQL = "SELECT BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY FROM MED_PACKAGE_DETAIL WHERE BAR_CODE = @BarCode";
        private static readonly string MED_PACKAGE_DETAIL_Select_With_Name_SQL = "SELECT BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY FROM MED_PACKAGE_DETAIL WHERE BAR_CODE = @BarCode AND INSTRUMENT_NAME =@InstrumentName";
        private static readonly string MED_PACKAGE_DETAIL_Insert_SQL = "INSERT INTO MED_PACKAGE_DETAIL (BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY) values (@BarCode,@InstrumentName,@InstrumentCode,@Quantity)";
        private static readonly string MED_PACKAGE_DETAIL_Update_SQL = "UPDATE MED_PACKAGE_DETAIL SET BAR_CODE=@BarCode,INSTRUMENT_NAME=@InstrumentName,INSTRUMENT_CODE=@InstrumentCode,QUANTITY=@Quantity WHERE BAR_CODE = @BarCodeP";
        private static readonly string MED_PACKAGE_DETAIL_Delete_SQL = "Delete MED_PACKAGE_DETAIL WHERE BAR_CODE = @BarCode";

        private static readonly string MED_PACKAGE_DETAIL_Select = "SELECT BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY FROM MED_PACKAGE_DETAIL WHERE BAR_CODE = :BarCode";
        private static readonly string MED_PACKAGE_DETAIL_Select_With_Name = "SELECT BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY FROM MED_PACKAGE_DETAIL WHERE BAR_CODE = :BarCode AND INSTRUMENT_NAME =:InstrumentName";
        private static readonly string MED_PACKAGE_DETAIL_Insert = "INSERT INTO MED_PACKAGE_DETAIL (BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY) values (:BarCode,:InstrumentName,:InstrumentCode,:Quantity)";
        private static readonly string MED_PACKAGE_DETAIL_Update = "UPDATE MED_PACKAGE_DETAIL SET BAR_CODE=:BarCode,INSTRUMENT_NAME=:InstrumentName,INSTRUMENT_CODE=:InstrumentCode,QUANTITY=:Quantity WHERE BAR_CODE = :BarCodeP";
        private static readonly string MED_PACKAGE_DETAIL_Delete = "Delete MED_PACKAGE_DETAIL WHERE BAR_CODE = :BarCode";
        public DALMedPackageDetail()
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
            {//@BarCode,@InstrumentName,@SterilizeDate,@InstrumentCode
                if (sqlParms == "InsertMedPackageDetail")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@BarCode",SqlDbType.VarChar),
							new SqlParameter("@InstrumentName",SqlDbType.VarChar),
							new SqlParameter("@InstrumentCode",SqlDbType.VarChar),
							new SqlParameter("@Quantity",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "UpdateMedPackageDetail")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@BarCode",SqlDbType.VarChar),
							new SqlParameter("@InstrumentName",SqlDbType.VarChar),
							new SqlParameter("@InstrumentCode",SqlDbType.VarChar),
							new SqlParameter("@Quantity",SqlDbType.Decimal),
                            new SqlParameter("@BarCodeP",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPackageDetail")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@BarCode",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageDetail")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@BarCode",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageDetailWithName")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@BarCode",SqlDbType.VarChar),
                            new SqlParameter("@InstrumentName",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedPackageDetail 
        ///Insert Table MED_PACKAGE_DETAIL
        /// </summary>
        public int InsertMedPackageDetailSQL(MedPackageDetail model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedPackageDetail");
                if (model.BarCode != null)
                    oneInert[0].Value = model.BarCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.InstrumentName != null)
                    oneInert[1].Value = model.InstrumentName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.InstrumentCode != null)
                    oneInert[2].Value = model.InstrumentCode;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.Quantity.ToString() != null)
                    oneInert[3].Value = model.Quantity;
                else
                    oneInert[3].Value = DBNull.Value;
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PACKAGE_DETAIL_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedPackageDetail 
        ///Update Table     MED_PACKAGE_DETAIL
        /// </summary>
        public int UpdateMedPackageDetailSQL(MedPackageDetail model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPackageDetail");
                if (model.BarCode != null)
                    oneUpdate[0].Value = model.BarCode;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.InstrumentName != null)
                    oneUpdate[1].Value = model.InstrumentName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.InstrumentCode != null)
                    oneUpdate[2].Value = model.InstrumentCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Quantity.ToString() != null)
                    oneUpdate[3].Value = model.Quantity;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.BarCode != null)
                    oneUpdate[4].Value = model.BarCode;
                else
                    oneUpdate[4].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedPackageDetail 
        ///Delete Table MED_PACKAGE_DETAIL by (string USER_ID)
        /// </summary>
        public int DeleteMedPackageDetailSQL(string Bar_Code)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPackageDetail");
                if (Bar_Code != null)
                    oneDelete[0].Value = Bar_Code;
                else
                    oneDelete[0].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PACKAGE_DETAIL_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取多条明细记录SQL]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public List<MedPackageDetail> SelectMedPackageDetailSQL(string Bar_Code)
        {
            List<MedPackageDetail> modelList = new List<MedPackageDetail>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedPackageDetail");
            parameterValues[0].Value = Bar_Code;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Select_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedPackageDetail model = new MedPackageDetail();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.BarCode = oleReader["BAR_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InstrumentName = oleReader["INSTRUMENT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.InstrumentCode = oleReader["INSTRUMENT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Quantity = decimal.Parse(oleReader["QUANTITY"].ToString().Trim());
                    }
                    modelList.Add(model);
                }

            }
            return modelList;
        }
        #endregion
        #region  [获取单条记录SQL]
        /// <summary>
        ///Select    model  MedPackageDetail 
        ///select Table MED_PACKAGE_DETAIL by (string USER_ID)
        /// </summary>
        public MedPackageDetail SelectMedPackageDetailWithNameSQL(string Bar_Code, string Instrument_Name)
        {
            MedPackageDetail model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedPackageDetailWithName");
            parameterValues[0].Value = Bar_Code;
            parameterValues[1].Value = Instrument_Name;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Select_With_Name_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPackageDetail();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.BarCode = oleReader["BAR_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InstrumentName = oleReader["INSTRUMENT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.InstrumentCode = oleReader["INSTRUMENT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Quantity = decimal.Parse(oleReader["QUANTITY"].ToString().Trim());
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
            {
                if (sqlParms == "InsertMedPackageDetail")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":BarCode",OracleType.VarChar),
							new OracleParameter(":InstrumentName",OracleType.VarChar),
							new OracleParameter(":InstrumentCode",OracleType.VarChar),
							new OracleParameter(":Quantity",OracleType.Number),
                    };
                }
                else if (sqlParms == "UpdateMedPackageDetail")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":BarCode",OracleType.VarChar),
							new OracleParameter(":InstrumentName",OracleType.VarChar),
							new OracleParameter(":InstrumentCode",OracleType.VarChar),
							new OracleParameter(":Quantity",OracleType.Number),
                            new OracleParameter(":BarCodeP",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPackageDetail")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":BarCode",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageDetail")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":BarCode",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageDetailWithName")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":BarCode",OracleType.VarChar),
                            new OracleParameter(":InstrumentName",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedPackageDetail 
        ///Insert Table MED_PACKAGE_DETAIL
        /// </summary>
        public int InsertMedPackageDetail(MedPackageDetail model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedPackageDetail");
                if (model.BarCode != null)
                    oneInert[0].Value = model.BarCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.InstrumentName != null)
                    oneInert[1].Value = model.InstrumentName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.InstrumentCode != null)
                    oneInert[2].Value = model.InstrumentCode;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.Quantity.ToString() != null)
                    oneInert[3].Value = model.Quantity;
                else
                    oneInert[3].Value = DBNull.Value;
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PACKAGE_DETAIL_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedPackageDetail 
        ///Update Table     MED_PACKAGE_DETAIL
        /// </summary>
        public int UpdateMedPackageDetail(MedPackageDetail model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedPackageDetail");
                if (model.BarCode != null)
                    oneUpdate[0].Value = model.BarCode;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.InstrumentName != null)
                    oneUpdate[1].Value = model.InstrumentName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.InstrumentCode != null)
                    oneUpdate[2].Value = model.InstrumentCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Quantity.ToString() != null)
                    oneUpdate[3].Value = model.Quantity;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.BarCode != null)
                    oneUpdate[4].Value = model.BarCode;
                else
                    oneUpdate[4].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedHisUsers 
        ///Delete Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public int DeleteMedPackageDetail(string Bar_Code)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedPackageDetail");
                if (Bar_Code != null)
                    oneDelete[0].Value = Bar_Code;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PACKAGE_DETAIL_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取多条明细记录]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public List<MedPackageDetail> SelectMedPackageDetail(string Bar_Code)
        {
            List<MedPackageDetail> modelList = new List<MedPackageDetail>();
            OracleParameter[] parameterValues = GetParameter("SelectMedPackageDetail");
            parameterValues[0].Value = Bar_Code;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Select, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedPackageDetail model = new MedPackageDetail();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.BarCode = oleReader["BAR_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InstrumentName = oleReader["INSTRUMENT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.InstrumentCode = oleReader["INSTRUMENT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Quantity = decimal.Parse(oleReader["QUANTITY"].ToString().Trim());
                    }
                    modelList.Add(model);
                }

            }
            return modelList;
        }
        #endregion
        #region  [获取单条记录]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public MedPackageDetail SelectMedPackageDetailWithName(string Bar_Code, string Instrument_Name)
        {
            OracleParameter[] parameterValues = GetParameter("SelectMedPackageDetailWithName");
            parameterValues[0].Value = Bar_Code;
            parameterValues[1].Value = Instrument_Name;
            MedPackageDetail model;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Select_With_Name, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPackageDetail();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.BarCode = oleReader["BAR_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InstrumentName = oleReader["INSTRUMENT_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.InstrumentCode = oleReader["INSTRUMENT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Quantity = decimal.Parse(oleReader["QUANTITY"].ToString().Trim());
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
