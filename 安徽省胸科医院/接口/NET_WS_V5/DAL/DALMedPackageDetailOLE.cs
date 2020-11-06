

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
    /// DAL MedPackageDetail
    /// </summary>

    public partial class DALMedPackageDetail
    {
        private static readonly string MED_PACKAGE_DETAIL_Select_OLE = "SELECT BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY FROM MED_PACKAGE_DETAIL WHERE BAR_CODE = ?";
        private static readonly string MED_PACKAGE_DETAIL_Select_With_Name_OLE = "SELECT BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY FROM MED_PACKAGE_DETAIL WHERE BAR_CODE = ? AND INSTRUMENT_NAME =?";
        private static readonly string MED_PACKAGE_DETAIL_Insert_OLE = "INSERT INTO MED_PACKAGE_DETAIL (BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY) values (?,?,?,?)";
        private static readonly string MED_PACKAGE_DETAIL_Update_OLE = "UPDATE MED_PACKAGE_DETAIL SET BAR_CODE=?,INSTRUMENT_NAME=?,INSTRUMENT_CODE=?,QUANTITY=? WHERE BAR_CODE = ?";
        private static readonly string MED_PACKAGE_DETAIL_Delete_OLE = "Delete MED_PACKAGE_DETAIL WHERE BAR_CODE = ?";

        private static readonly string MED_PACKAGE_DETAIL_Select_ODBC = "SELECT BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY FROM MED_PACKAGE_DETAIL WHERE BAR_CODE = ?";
        private static readonly string MED_PACKAGE_DETAIL_Select_With_Name_ODBC = "SELECT BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY FROM MED_PACKAGE_DETAIL WHERE BAR_CODE = ? AND INSTRUMENT_NAME =?";
        private static readonly string MED_PACKAGE_DETAIL_Insert_ODBC = "INSERT INTO MED_PACKAGE_DETAIL (BAR_CODE,INSTRUMENT_NAME,INSTRUMENT_CODE,QUANTITY) values (?,?,?,?)";
        private static readonly string MED_PACKAGE_DETAIL_Update_ODBC = "UPDATE MED_PACKAGE_DETAIL SET BAR_CODE=?,INSTRUMENT_NAME=?,INSTRUMENT_CODE=?,QUANTITY=? WHERE BAR_CODE = ?";
        private static readonly string MED_PACKAGE_DETAIL_Delete_ODBC = "Delete MED_PACKAGE_DETAIL WHERE BAR_CODE = ?";

        #region [获取参数OLE]
        /// <summary>
        ///获取参数MedHisUsers OLE
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {//@BarCode,@InstrumentName,@SterilizeDate,@InstrumentCode
                if (sqlParms == "InsertMedPackageDetail")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("BarCode",OleDbType.VarChar),
							new OleDbParameter("InstrumentName",OleDbType.VarChar),
							new OleDbParameter("InstrumentCode",OleDbType.VarChar),
							new OleDbParameter("Quantity",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "UpdateMedPackageDetail")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("BarCode",OleDbType.VarChar),
							new OleDbParameter("InstrumentName",OleDbType.VarChar),
							new OleDbParameter("InstrumentCode",OleDbType.VarChar),
							new OleDbParameter("Quantity",OleDbType.Decimal),
                            new OleDbParameter("BarCodeP",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPackageDetail")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("BarCode",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageDetail")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("BarCode",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageDetailWithName")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("BarCode",OleDbType.VarChar),
                            new OleDbParameter("InstrumentName",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录OLE]
        /// <summary>
        ///Add    model  MedPackageDetail 
        ///Insert Table MED_PACKAGE_DETAIL
        /// </summary>
        public int InsertMedPackageDetailOLE(MedPackageDetail model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedPackageDetail");
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
                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录OLE]
        /// <summary>
        ///Update    model  MedPackageDetail 
        ///Update Table     MED_PACKAGE_DETAIL
        /// </summary>
        public int UpdateMedPackageDetailOLE(MedPackageDetail model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedPackageDetail");
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

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录OLE]
        /// <summary>
        ///Delete    model  MedPackageDetail 
        ///Delete Table MED_PACKAGE_DETAIL by (string USER_ID)
        /// </summary>
        public int DeleteMedPackageDetailOLE(string Bar_Code)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedPackageDetail");
                if (Bar_Code != null)
                    oneDelete[0].Value = Bar_Code;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取多条明细记录OLE]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public List<MedPackageDetail> SelectMedPackageDetailOLE(string Bar_Code)
        {
            List<MedPackageDetail> modelList = new List<MedPackageDetail>();
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedPackageDetail");
            parameterValues[0].Value = Bar_Code;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Select_OLE, parameterValues))
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
        #region  [获取单条记录OLE]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public MedPackageDetail SelectMedPackageDetailWithNameOLE(string Bar_Code, string Instrument_Name)
        {
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedPackageDetailWithName");
            parameterValues[0].Value = Bar_Code;
            parameterValues[1].Value = Instrument_Name;
            MedPackageDetail model;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Select_With_Name_OLE, parameterValues))
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
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPackageDetail")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("BarCode",OdbcType.VarChar),
							new OdbcParameter("InstrumentName",OdbcType.VarChar),
							new OdbcParameter("InstrumentCode",OdbcType.VarChar),
							new OdbcParameter("Quantity",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "UpdateMedPackageDetail")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("BarCode",OdbcType.VarChar),
							new OdbcParameter("InstrumentName",OdbcType.VarChar),
							new OdbcParameter("InstrumentCode",OdbcType.VarChar),
							new OdbcParameter("Quantity",OdbcType.Decimal),
                            new OdbcParameter("BarCodeP",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPackageDetail")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("BarCode",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageDetail")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("BarCode",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPackageDetailWithName")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("BarCode",OdbcType.VarChar),
                            new OdbcParameter("InstrumentName",OdbcType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录ODBC]
        /// <summary>
        ///Add    model  MedPackageDetail 
        ///Insert Table MED_PACKAGE_DETAIL
        /// </summary>
        public int InsertMedPackageDetailODBC(MedPackageDetail model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedPackageDetail");
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
                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录ODBC]
        /// <summary>
        ///Update    model  MedPackageDetail 
        ///Update Table     MED_PACKAGE_DETAIL
        /// </summary>
        public int UpdateMedPackageDetailODBC(MedPackageDetail model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedPackageDetail");
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

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录OLE]
        /// <summary>
        ///Delete    model  MedPackageDetail 
        ///Delete Table MED_PACKAGE_DETAIL by (string USER_ID)
        /// </summary>
        public int DeleteMedPackageDetailODBC(string Bar_Code)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedPackageDetail");
                if (Bar_Code != null)
                    oneDelete[0].Value = Bar_Code;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取多条明细记录ODBC]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public List<MedPackageDetail> SelectMedPackageDetailODBC(string Bar_Code)
        {
            List<MedPackageDetail> modelList = new List<MedPackageDetail>();
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedPackageDetail");
            parameterValues[0].Value = Bar_Code;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Select_ODBC, parameterValues))
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
        #region  [获取单条记录ODBC]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public MedPackageDetail SelectMedPackageDetailWithNameODBC(string Bar_Code, string Instrument_Name)
        {
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedPackageDetailWithName");
            parameterValues[0].Value = Bar_Code;
            parameterValues[1].Value = Instrument_Name;
            MedPackageDetail model;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_PACKAGE_DETAIL_Select_With_Name_ODBC, parameterValues))
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
