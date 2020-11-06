

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:29
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
	/// DAL MedBedRec
	/// </summary>

    public partial class DALMedBedRec
    {

        private static readonly string MED_BED_REC_Insert_SQL = "INSERT INTO MED_BED_REC (WARD_CODE,BED_NO,BED_LABEL,ROOM_NO,DEPT_CODE,BED_APPROVED_TYPE,BED_SEX_TYPE,BED_CLASS,BED_STATUS,ICU_INDICATOR,MONITOR_LABEL,SERIAL_NO) values (@WardCode,@BedNo,@BedLabel,@RoomNo,@DeptCode,@BedApprovedType,@BedSexType,@BedClass,@BedStatus,@IcuIndicator,@MonitorLabel,@SerialNo)";
        private static readonly string MED_BED_REC_Update_SQL = "UPDATE MED_BED_REC SET WARD_CODE=@WardCode,BED_NO=@BedNo,BED_LABEL=@BedLabel,ROOM_NO=@RoomNo,DEPT_CODE=@DeptCode,BED_APPROVED_TYPE=@BedApprovedType,BED_SEX_TYPE=@BedSexType,BED_CLASS=@BedClass,BED_STATUS=@BedStatus,ICU_INDICATOR=@IcuIndicator,MONITOR_LABEL=@MonitorLabel,SERIAL_NO=@SerialNo WHERE WARD_CODE=@WardCode AND BED_NO=@BedNo";
        private static readonly string MED_BED_REC_Delete_SQL = "Delete MED_BED_REC WHERE WARD_CODE=@WardCode AND BED_NO=@BedNo";
        private static readonly string MED_BED_REC_Select_SQL = "SELECT WARD_CODE,BED_NO,BED_LABEL,ROOM_NO,DEPT_CODE,BED_APPROVED_TYPE,BED_SEX_TYPE,BED_CLASS,BED_STATUS,ICU_INDICATOR,MONITOR_LABEL,SERIAL_NO FROM MED_BED_REC where WARD_CODE=@WardCode AND BED_NO=@BedNo";
        private static readonly string MED_BED_REC_LABEL_Select_SQL = "SELECT WARD_CODE,BED_NO,BED_LABEL,ROOM_NO,DEPT_CODE,BED_APPROVED_TYPE,BED_SEX_TYPE,BED_CLASS,BED_STATUS,ICU_INDICATOR,MONITOR_LABEL,SERIAL_NO FROM MED_BED_REC where WARD_CODE=@WardCode AND BED_LABEL=@BedLabel";
        private static readonly string MED_BED_REC_Select_ALL_SQL = "SELECT WARD_CODE,BED_NO,BED_LABEL,ROOM_NO,DEPT_CODE,BED_APPROVED_TYPE,BED_SEX_TYPE,BED_CLASS,BED_STATUS,ICU_INDICATOR,MONITOR_LABEL,SERIAL_NO FROM MED_BED_REC";
        private static readonly string MED_BED_REC_Insert = "INSERT INTO MED_BED_REC (WARD_CODE,BED_NO,BED_LABEL,ROOM_NO,DEPT_CODE,BED_APPROVED_TYPE,BED_SEX_TYPE,BED_CLASS,BED_STATUS,ICU_INDICATOR,MONITOR_LABEL,SERIAL_NO) values (:WardCode,:BedNo,:BedLabel,:RoomNo,:DeptCode,:BedApprovedType,:BedSexType,:BedClass,:BedStatus,:IcuIndicator,:MonitorLabel,:SerialNo)";
        private static readonly string MED_BED_REC_Update = "UPDATE MED_BED_REC SET WARD_CODE=:WardCode,BED_NO=:BedNo,BED_LABEL=:BedLabel,ROOM_NO=:RoomNo,DEPT_CODE=:DeptCode,BED_APPROVED_TYPE=:BedApprovedType,BED_SEX_TYPE=:BedSexType,BED_CLASS=:BedClass,BED_STATUS=:BedStatus,ICU_INDICATOR=:IcuIndicator,MONITOR_LABEL=:MonitorLabel,SERIAL_NO=:SerialNo WHERE WARD_CODE=:WardCode AND BED_NO=:BedNo";
        private static readonly string MED_BED_REC_Delete = "Delete MED_BED_REC WHERE WARD_CODE=:WardCode AND BED_NO=:BedNo";
        private static readonly string MED_BED_REC_Select = "SELECT WARD_CODE,BED_NO,BED_LABEL,ROOM_NO,DEPT_CODE,BED_APPROVED_TYPE,BED_SEX_TYPE,BED_CLASS,BED_STATUS,ICU_INDICATOR,MONITOR_LABEL,SERIAL_NO FROM MED_BED_REC where WARD_CODE=:WardCode AND BED_NO=:BedNo";
        private static readonly string MED_BED_REC_LABEL_Select = "SELECT WARD_CODE,BED_NO,BED_LABEL,ROOM_NO,DEPT_CODE,BED_APPROVED_TYPE,BED_SEX_TYPE,BED_CLASS,BED_STATUS,ICU_INDICATOR,MONITOR_LABEL,SERIAL_NO FROM MED_BED_REC where WARD_CODE=:WardCode AND BED_LABEL=:BedLabel";
        private static readonly string MED_BED_REC_Select_ALL = "SELECT WARD_CODE,BED_NO,BED_LABEL,ROOM_NO,DEPT_CODE,BED_APPROVED_TYPE,BED_SEX_TYPE,BED_CLASS,BED_STATUS,ICU_INDICATOR,MONITOR_LABEL,SERIAL_NO FROM MED_BED_REC";
        public DALMedBedRec()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedBedRec SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedBedRec")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@BedNo",SqlDbType.VarChar),
							new SqlParameter("@BedLabel",SqlDbType.VarChar),
							new SqlParameter("@RoomNo",SqlDbType.VarChar),
							new SqlParameter("@DeptCode",SqlDbType.VarChar),
							new SqlParameter("@BedApprovedType",SqlDbType.VarChar),
							new SqlParameter("@BedSexType",SqlDbType.VarChar),
							new SqlParameter("@BedClass",SqlDbType.VarChar),
							new SqlParameter("@BedStatus",SqlDbType.VarChar),
							new SqlParameter("@IcuIndicator",SqlDbType.Decimal),
							new SqlParameter("@MonitorLabel",SqlDbType.VarChar),
							new SqlParameter("@SerialNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "UpdateMedBedRec")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@BedNo",SqlDbType.VarChar),
							new SqlParameter("@BedLabel",SqlDbType.VarChar),
							new SqlParameter("@RoomNo",SqlDbType.VarChar),
							new SqlParameter("@DeptCode",SqlDbType.VarChar),
							new SqlParameter("@BedApprovedType",SqlDbType.VarChar),
							new SqlParameter("@BedSexType",SqlDbType.VarChar),
							new SqlParameter("@BedClass",SqlDbType.VarChar),
							new SqlParameter("@BedStatus",SqlDbType.VarChar),
							new SqlParameter("@IcuIndicator",SqlDbType.Decimal),
							new SqlParameter("@MonitorLabel",SqlDbType.VarChar),
							new SqlParameter("@SerialNo",SqlDbType.Decimal),
							new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@BedNo",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedBedRec")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@BedNo",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedBedRec")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@BedNo",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedBedRecLabel")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@WardCode",SqlDbType.VarChar),
							new SqlParameter("@BedLabel",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedBedRec 
        ///Insert Table MED_BED_REC
        /// </summary>
        public int InsertMedBedRecSQL(MedBedRec model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedBedRec");
                if (model.WardCode != null)
                    oneInert[0].Value = model.WardCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[1].Value = model.BedNo;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.BedLabel != null)
                    oneInert[2].Value = model.BedLabel;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.RoomNo != null)
                    oneInert[3].Value = model.RoomNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[4].Value = model.DeptCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.BedApprovedType != null)
                    oneInert[5].Value = model.BedApprovedType;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.BedSexType != null)
                    oneInert[6].Value = model.BedSexType;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.BedClass != null)
                    oneInert[7].Value = model.BedClass;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.BedStatus != null)
                    oneInert[8].Value = model.BedStatus;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.IcuIndicator.ToString() != null)
                    oneInert[9].Value = model.IcuIndicator;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.MonitorLabel != null)
                    oneInert[10].Value = model.MonitorLabel;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.SerialNo.ToString() != null)
                    oneInert[11].Value = model.SerialNo;
                else
                    oneInert[11].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_BED_REC_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedBedRec 
        ///Update Table     MED_BED_REC
        /// </summary>
        public int UpdateMedBedRecSQL(MedBedRec model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedBedRec");
                if (model.WardCode != null)
                    oneUpdate[0].Value = model.WardCode;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[1].Value = model.BedNo;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.BedLabel != null)
                    oneUpdate[2].Value = model.BedLabel;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.RoomNo != null)
                    oneUpdate[3].Value = model.RoomNo;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[4].Value = model.DeptCode;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.BedApprovedType != null)
                    oneUpdate[5].Value = model.BedApprovedType;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.BedSexType != null)
                    oneUpdate[6].Value = model.BedSexType;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.BedClass != null)
                    oneUpdate[7].Value = model.BedClass;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.BedStatus != null)
                    oneUpdate[8].Value = model.BedStatus;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.IcuIndicator.ToString() != null)
                    oneUpdate[9].Value = model.IcuIndicator;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.MonitorLabel != null)
                    oneUpdate[10].Value = model.MonitorLabel;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.SerialNo.ToString() != null)
                    oneUpdate[11].Value = model.SerialNo;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[12].Value = model.WardCode;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[13].Value = model.BedNo;
                else
                    oneUpdate[13].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_BED_REC_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedBedRec 
        ///Delete Table MED_BED_REC by (string WARD_CODE,string BED_NO)
        /// </summary>
        public int DeleteMedBedRecSQL(string WARD_CODE, string BED_NO)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedBedRec");
                if (WARD_CODE != null)
                    oneDelete[0].Value = WARD_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (BED_NO != null)
                    oneDelete[1].Value = BED_NO;
                else
                    oneDelete[1].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_BED_REC_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedBedRec 
        ///select Table MED_BED_REC by (string WARD_CODE,string BED_NO)
        /// </summary>
        public MedBedRec SelectMedBedRecSQL(string WARD_CODE, string BED_NO)
        {
            MedBedRec model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedBedRec");
            parameterValues[0].Value = WARD_CODE;
            parameterValues[1].Value = BED_NO;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_BED_REC_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedBedRec();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.BedLabel = oleReader["BED_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.RoomNo = oleReader["ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BedApprovedType = oleReader["BED_APPROVED_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.BedSexType = oleReader["BED_SEX_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedClass = oleReader["BED_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedStatus = oleReader["BED_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IcuIndicator = decimal.Parse(oleReader["ICU_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
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
        public List<MedBedRec> SelectMedBedRecListSQL()
        {
            List<MedBedRec> modelList = new List<MedBedRec>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_BED_REC_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedBedRec model = new MedBedRec();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.BedLabel = oleReader["BED_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.RoomNo = oleReader["ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BedApprovedType = oleReader["BED_APPROVED_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.BedSexType = oleReader["BED_SEX_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedClass = oleReader["BED_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedStatus = oleReader["BED_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IcuIndicator = decimal.Parse(oleReader["ICU_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录SQL-LABEL]
        /// <summary>
        ///Select    model  MedBedRec 
        ///select Table MED_BED_REC by (string WARD_CODE,string BED_NO)
        /// </summary>
        public MedBedRec SelectMedBedRecLabelSQL(string WARD_CODE, string BED_LABEL)
        {
            MedBedRec model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedBedRecLabel");
            parameterValues[0].Value = WARD_CODE;
            parameterValues[1].Value = BED_LABEL;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_BED_REC_LABEL_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedBedRec();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.BedLabel = oleReader["BED_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.RoomNo = oleReader["ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BedApprovedType = oleReader["BED_APPROVED_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.BedSexType = oleReader["BED_SEX_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedClass = oleReader["BED_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedStatus = oleReader["BED_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IcuIndicator = decimal.Parse(oleReader["ICU_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
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
        ///获取参数MedBedRec
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedBedRec")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":BedNo",OracleType.VarChar),
							new OracleParameter(":BedLabel",OracleType.VarChar),
							new OracleParameter(":RoomNo",OracleType.VarChar),
							new OracleParameter(":DeptCode",OracleType.VarChar),
							new OracleParameter(":BedApprovedType",OracleType.VarChar),
							new OracleParameter(":BedSexType",OracleType.VarChar),
							new OracleParameter(":BedClass",OracleType.VarChar),
							new OracleParameter(":BedStatus",OracleType.VarChar),
							new OracleParameter(":IcuIndicator",OracleType.Number),
							new OracleParameter(":MonitorLabel",OracleType.VarChar),
							new OracleParameter(":SerialNo",OracleType.Number),
                    };
                }
                else if (sqlParms == "UpdateMedBedRec")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":BedNo",OracleType.VarChar),
							new OracleParameter(":BedLabel",OracleType.VarChar),
							new OracleParameter(":RoomNo",OracleType.VarChar),
							new OracleParameter(":DeptCode",OracleType.VarChar),
							new OracleParameter(":BedApprovedType",OracleType.VarChar),
							new OracleParameter(":BedSexType",OracleType.VarChar),
							new OracleParameter(":BedClass",OracleType.VarChar),
							new OracleParameter(":BedStatus",OracleType.VarChar),
							new OracleParameter(":IcuIndicator",OracleType.Number),
							new OracleParameter(":MonitorLabel",OracleType.VarChar),
							new OracleParameter(":SerialNo",OracleType.Number),
							new OracleParameter(":WardCode",SqlDbType.VarChar),
							new OracleParameter(":BedNo",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedBedRec")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":BedNo",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedBedRec")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":BedNo",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedBedRecLabel")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":WardCode",OracleType.VarChar),
							new OracleParameter(":BedLabel",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedBedRec 
        ///Insert Table MED_BED_REC
        /// </summary>
        public int InsertMedBedRec(MedBedRec model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedBedRec");
                if (model.WardCode != null)
                    oneInert[0].Value = model.WardCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[1].Value = model.BedNo;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.BedLabel != null)
                    oneInert[2].Value = model.BedLabel;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.RoomNo != null)
                    oneInert[3].Value = model.RoomNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[4].Value = model.DeptCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.BedApprovedType != null)
                    oneInert[5].Value = model.BedApprovedType;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.BedSexType != null)
                    oneInert[6].Value = model.BedSexType;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.BedClass != null)
                    oneInert[7].Value = model.BedClass;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.BedStatus != null)
                    oneInert[8].Value = model.BedStatus;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.IcuIndicator.ToString() != null)
                    oneInert[9].Value = model.IcuIndicator;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.MonitorLabel != null)
                    oneInert[10].Value = model.MonitorLabel;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.SerialNo.ToString() != null)
                    oneInert[11].Value = model.SerialNo;
                else
                    oneInert[11].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_BED_REC_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedBedRec 
        ///Update Table     MED_BED_REC
        /// </summary>
        public int UpdateMedBedRec(MedBedRec model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedBedRec");
                if (model.WardCode != null)
                    oneUpdate[0].Value = model.WardCode;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[1].Value = model.BedNo;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.BedLabel != null)
                    oneUpdate[2].Value = model.BedLabel;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.RoomNo != null)
                    oneUpdate[3].Value = model.RoomNo;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[4].Value = model.DeptCode;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.BedApprovedType != null)
                    oneUpdate[5].Value = model.BedApprovedType;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.BedSexType != null)
                    oneUpdate[6].Value = model.BedSexType;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.BedClass != null)
                    oneUpdate[7].Value = model.BedClass;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.BedStatus != null)
                    oneUpdate[8].Value = model.BedStatus;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.IcuIndicator.ToString() != null)
                    oneUpdate[9].Value = model.IcuIndicator;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.MonitorLabel != null)
                    oneUpdate[10].Value = model.MonitorLabel;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.SerialNo.ToString() != null)
                    oneUpdate[11].Value = model.SerialNo;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[12].Value = model.WardCode;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[13].Value = model.BedNo;
                else
                    oneUpdate[13].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_BED_REC_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedBedRec 
        ///Delete Table MED_BED_REC by (string WARD_CODE,string BED_NO)
        /// </summary>
        public int DeleteMedBedRec(string WARD_CODE, string BED_NO)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedBedRec");
                if (WARD_CODE != null)
                    oneDelete[0].Value = WARD_CODE;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (BED_NO != null)
                    oneDelete[1].Value = BED_NO;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_BED_REC_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedBedRec 
        ///select Table MED_BED_REC by (string WARD_CODE,string BED_NO)
        /// </summary>
        public MedBedRec SelectMedBedRec(string WARD_CODE, string BED_NO)
        {
            MedBedRec model;
            OracleParameter[] parameterValues = GetParameter("SelectMedBedRec");
            parameterValues[0].Value = WARD_CODE;
            parameterValues[1].Value = BED_NO;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_BED_REC_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedBedRec();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.BedLabel = oleReader["BED_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.RoomNo = oleReader["ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BedApprovedType = oleReader["BED_APPROVED_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.BedSexType = oleReader["BED_SEX_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedClass = oleReader["BED_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedStatus = oleReader["BED_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IcuIndicator = decimal.Parse(oleReader["ICU_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
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
        public List<MedBedRec> SelectMedBedRecList()
        {
            List<MedBedRec> modelList = new List<MedBedRec>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_BED_REC_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedBedRec model = new MedBedRec();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.BedLabel = oleReader["BED_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.RoomNo = oleReader["ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BedApprovedType = oleReader["BED_APPROVED_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.BedSexType = oleReader["BED_SEX_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedClass = oleReader["BED_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedStatus = oleReader["BED_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IcuIndicator = decimal.Parse(oleReader["ICU_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录-LABEL]
        /// <summary>
        ///Select    model  MedBedRec 
        ///select Table MED_BED_REC by (string WARD_CODE,string BED_NO)
        /// </summary>
        public MedBedRec SelectMedBedLabelRec(string WARD_CODE, string BED_LABEL)
        {
            MedBedRec model;
            OracleParameter[] parameterValues = GetParameter("SelectMedBedRecLabel");
            parameterValues[0].Value = WARD_CODE;
            parameterValues[1].Value = BED_LABEL;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_BED_REC_LABEL_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedBedRec();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.BedLabel = oleReader["BED_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.RoomNo = oleReader["ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BedApprovedType = oleReader["BED_APPROVED_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.BedSexType = oleReader["BED_SEX_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedClass = oleReader["BED_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedStatus = oleReader["BED_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IcuIndicator = decimal.Parse(oleReader["ICU_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.MonitorLabel = oleReader["MONITOR_LABEL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
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
