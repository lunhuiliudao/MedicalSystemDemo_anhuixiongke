

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
using System.Data.OleDb;
using System.Data.Odbc;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedBedRec
	/// </summary>
	
	public partial class DALMedBedRec
	{

        private static readonly string Select_MedBedRec_OLE = "SELECT WARD_CODE ,BED_NO ,BED_LABEL ,ROOM_NO ,DEPT_CODE  ,BED_APPROVED_TYPE ,BED_SEX_TYPE ,BED_CLASS ,BED_STATUS ,ICU_INDICATOR ,MONITOR_LABEL ,SERIAL_NO FROM MED_BED_REC WHERE WARD_CODE = ? AND  BED_NO = ?";
        private static readonly string Insert_MedBedRec_OLE = "INSERT INTO MED_BED_REC(WARD_CODE ,BED_NO ,BED_LABEL ,ROOM_NO, DEPT_CODE, BED_APPROVED_TYPE ,BED_SEX_TYPE ,BED_CLASS ,BED_STATUS ,ICU_INDICATOR ,MONITOR_LABEL ,SERIAL_NO)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_MedBedRec_OLE = "UPDATE MED_BED_REC SET BED_LABEL = ?,ROOM_NO = ?,DEPT_CODE = ?,BED_APPROVED_TYPE = ?,BED_SEX_TYPE = ?, BED_CLASS = ?, BED_STATUS = ?, ICU_INDICATOR = ?, MONITOR_LABEL = ? ,SERIAL_NO = ?  where WARD_CODE = ? and BED_NO = ?";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedBedRec")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("wardCode",OleDbType.VarChar),
                        new OleDbParameter("bedNo",OleDbType.VarChar)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedBedRec")
                    {
                        parms = new OleDbParameter[]{
                            new OleDbParameter("wardCode",OleDbType.VarChar),
                            new OleDbParameter("bedNo",OleDbType.VarChar), 
                            new OleDbParameter("bedLabel",OleDbType.VarChar), 
                            new OleDbParameter("roomNo",OleDbType.VarChar),
                            new OleDbParameter("deptCode",OleDbType.VarChar),
                            new OleDbParameter("bedApprovedType",OleDbType.VarChar),
                            new OleDbParameter("bedSexType",OleDbType.VarChar), 
                            new OleDbParameter("bedClass",OleDbType.VarChar), 
                            new OleDbParameter("bedStatus",OleDbType.VarChar),
                            new OleDbParameter("icuIndicator",OleDbType.Decimal),
                            new OleDbParameter("monitorLabel",OleDbType.VarChar),
                            new OleDbParameter("serialNo",OleDbType.Decimal)
                        };
                    }
                    else
                    {
                        if (sqlParms == "UpdateMedBedRec")
                        {
                            parms = new OleDbParameter[]{
                                new OleDbParameter("bedLabel",OleDbType.VarChar),
                                new OleDbParameter("roomNo",OleDbType.VarChar), 
                                new OleDbParameter("deptCode",OleDbType.VarChar),
                                new OleDbParameter("bedApprovedType",OleDbType.VarChar),
                                new OleDbParameter("bedSexType",OleDbType.VarChar),
                                new OleDbParameter("bedClass",OleDbType.VarChar), 
                                new OleDbParameter("bedStatus",OleDbType.VarChar),
                                new OleDbParameter("icuIndicator",OleDbType.Decimal),
                                new OleDbParameter("monitorLabel",OleDbType.VarChar),
                                new OleDbParameter("serialNo",OleDbType.Decimal),
                                new OleDbParameter("wardCode",OleDbType.VarChar),
                                new OleDbParameter("bedNo",OleDbType.VarChar)
                            };
                        }
                    }
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedBedRec SelectMedBedRecOLE(string wardCode, string bedNo)
        {
            Model.MedBedRec OneMedBedRec = null;

            OleDbParameter[] paramDeptDict = GetParameterOLE("SelectMedBedRec");
            paramDeptDict[0].Value = wardCode;
            paramDeptDict[1].Value = bedNo;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedBedRec_OLE, paramDeptDict))
            {
                if (oleReader.Read())
                {
                    OneMedBedRec = new Model.MedBedRec();

                    OneMedBedRec.WardCode = oleReader.GetString(0);
                    OneMedBedRec.BedNo = oleReader.GetString(1);
                    if (!oleReader.IsDBNull(2))
                        OneMedBedRec.BedLabel = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        OneMedBedRec.RoomNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        OneMedBedRec.DeptCode = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        OneMedBedRec.BedApprovedType = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        OneMedBedRec.BedSexType = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        OneMedBedRec.BedClass = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        OneMedBedRec.BedStatus = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        OneMedBedRec.IcuIndicator = oleReader.GetDecimal(9);
                    if (!oleReader.IsDBNull(10))
                        OneMedBedRec.MonitorLabel = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        OneMedBedRec.SerialNo = oleReader.GetDecimal(11);
                }
                else
                    OneMedBedRec = null;
            }
            return OneMedBedRec;
        }

        public int InsertMedBedRecOLE(Model.MedBedRec OneMedBedRec)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedBedRec");
                if (OneMedBedRec.WardCode != null)
                    oneInert[0].Value = OneMedBedRec.WardCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (OneMedBedRec.BedNo != null)
                    oneInert[1].Value = OneMedBedRec.BedNo;
                else
                    oneInert[1].Value = DBNull.Value;
                if (OneMedBedRec.BedLabel != null)
                    oneInert[2].Value = OneMedBedRec.BedLabel;
                else
                    oneInert[2].Value = DBNull.Value;
                if (OneMedBedRec.RoomNo != null)
                    oneInert[3].Value = OneMedBedRec.RoomNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (OneMedBedRec.DeptCode != null)
                    oneInert[4].Value = OneMedBedRec.DeptCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (OneMedBedRec.BedApprovedType != null)
                    oneInert[5].Value = OneMedBedRec.BedApprovedType;
                else
                    oneInert[5].Value = DBNull.Value;
                if (OneMedBedRec.BedSexType != null)
                    oneInert[6].Value = OneMedBedRec.BedSexType;
                else
                    oneInert[6].Value = DBNull.Value;
                if (OneMedBedRec.BedClass != null)
                    oneInert[7].Value = OneMedBedRec.BedClass;
                else
                    oneInert[7].Value = DBNull.Value;
                if (OneMedBedRec.BedStatus != null)
                    oneInert[8].Value = OneMedBedRec.BedStatus;
                else
                    oneInert[8].Value = DBNull.Value;
                if (OneMedBedRec.IcuIndicator.ToString() != null)
                    oneInert[9].Value = OneMedBedRec.IcuIndicator;
                else
                    oneInert[9].Value = DBNull.Value;
                if (OneMedBedRec.MonitorLabel != null)
                    oneInert[10].Value = OneMedBedRec.MonitorLabel;
                else
                    oneInert[10].Value = DBNull.Value;
                if (OneMedBedRec.SerialNo.ToString() != null)
                    oneInert[11].Value = OneMedBedRec.SerialNo;
                else
                    oneInert[11].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedBedRec_OLE, oneInert);
            }
        }

        public int UpdateMedBedRecOLE(Model.MedBedRec OneMedBedRec)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedBedRec");
                if (OneMedBedRec.BedLabel != null)
                    oneUpdate[0].Value = OneMedBedRec.BedLabel;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (OneMedBedRec.RoomNo != null)
                    oneUpdate[1].Value = OneMedBedRec.RoomNo;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (OneMedBedRec.DeptCode != null)
                    oneUpdate[2].Value = OneMedBedRec.DeptCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (OneMedBedRec.BedApprovedType != null)
                    oneUpdate[3].Value = OneMedBedRec.BedApprovedType;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (OneMedBedRec.BedSexType != null)
                    oneUpdate[4].Value = OneMedBedRec.BedSexType;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (OneMedBedRec.BedClass != null)
                    oneUpdate[5].Value = OneMedBedRec.BedClass;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (OneMedBedRec.BedStatus != null)
                    oneUpdate[6].Value = OneMedBedRec.BedStatus;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (OneMedBedRec.IcuIndicator.ToString() != null)
                    oneUpdate[7].Value = OneMedBedRec.IcuIndicator;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (OneMedBedRec.MonitorLabel != null)
                    oneUpdate[8].Value = OneMedBedRec.MonitorLabel;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (OneMedBedRec.SerialNo.ToString() != null)
                    oneUpdate[9].Value = OneMedBedRec.SerialNo;
                else
                    oneUpdate[9].Value = DBNull.Value;
                oneUpdate[10].Value = OneMedBedRec.WardCode;
                oneUpdate[11].Value = OneMedBedRec.BedNo;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedBedRec_OLE, oneUpdate);
            }
        }


        private static readonly string Select_MedBedRec_Odbc = "SELECT WARD_CODE ,BED_NO ,BED_LABEL ,ROOM_NO ,DEPT_CODE  ,BED_APPROVED_TYPE ,BED_SEX_TYPE ,BED_CLASS ,BED_STATUS ,ICU_INDICATOR ,MONITOR_LABEL ,SERIAL_NO FROM MED_BED_REC WHERE WARD_CODE = ? AND  BED_NO = ?";
        private static readonly string Insert_MedBedRec_Odbc = "INSERT INTO MED_BED_REC(WARD_CODE ,BED_NO ,BED_LABEL ,ROOM_NO, DEPT_CODE, BED_APPROVED_TYPE ,BED_SEX_TYPE ,BED_CLASS ,BED_STATUS ,ICU_INDICATOR ,MONITOR_LABEL ,SERIAL_NO)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_MedBedRec_Odbc = "UPDATE MED_BED_REC SET BED_LABEL = ?,ROOM_NO = ?,DEPT_CODE = ?,BED_APPROVED_TYPE = ?,BED_SEX_TYPE = ?, BED_CLASS = ?, BED_STATUS = ?, ICU_INDICATOR = ?, MONITOR_LABEL = ? ,SERIAL_NO = ?  where WARD_CODE = ? and BED_NO = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedBedRec")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("wardCode",OdbcType.VarChar),
                        new OdbcParameter("bedNo",OdbcType.VarChar)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedBedRec")
                    {
                        parms = new OdbcParameter[]{
                            new OdbcParameter("wardCode",OdbcType.VarChar),
                            new OdbcParameter("bedNo",OdbcType.VarChar), 
                            new OdbcParameter("bedLabel",OdbcType.VarChar), 
                            new OdbcParameter("roomNo",OdbcType.VarChar),
                            new OdbcParameter("deptCode",OdbcType.VarChar),
                            new OdbcParameter("bedApprovedType",OdbcType.VarChar),
                            new OdbcParameter("bedSexType",OdbcType.VarChar), 
                            new OdbcParameter("bedClass",OdbcType.VarChar), 
                            new OdbcParameter("bedStatus",OdbcType.VarChar),
                            new OdbcParameter("icuIndicator",OdbcType.Decimal),
                            new OdbcParameter("monitorLabel",OdbcType.VarChar),
                            new OdbcParameter("serialNo",OdbcType.Decimal)
                        };
                    }
                    else
                    {
                        if (sqlParms == "UpdateMedBedRec")
                        {
                            parms = new OdbcParameter[]{
                                new OdbcParameter("bedLabel",OdbcType.VarChar),
                                new OdbcParameter("roomNo",OdbcType.VarChar), 
                                new OdbcParameter("deptCode",OdbcType.VarChar),
                                new OdbcParameter("bedApprovedType",OdbcType.VarChar),
                                new OdbcParameter("bedSexType",OdbcType.VarChar),
                                new OdbcParameter("bedClass",OdbcType.VarChar), 
                                new OdbcParameter("bedStatus",OdbcType.VarChar),
                                new OdbcParameter("icuIndicator",OdbcType.Decimal),
                                new OdbcParameter("monitorLabel",OdbcType.VarChar),
                                new OdbcParameter("serialNo",OdbcType.Decimal),
                                new OdbcParameter("wardCode",OdbcType.VarChar),
                                new OdbcParameter("bedNo",OdbcType.VarChar)
                            };
                        }
                    }
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedBedRec SelectMedBedRecOdbc(string wardCode, string bedNo)
        {
            Model.MedBedRec OneMedBedRec = null;

            OdbcParameter[] paramDeptDict = GetParameterOdbc("SelectMedBedRec");
            paramDeptDict[0].Value = wardCode;
            paramDeptDict[1].Value = bedNo;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedBedRec_Odbc, paramDeptDict))
            {
                if (OdbcReader.Read())
                {
                    OneMedBedRec = new Model.MedBedRec();

                    OneMedBedRec.WardCode = OdbcReader.GetString(0);
                    OneMedBedRec.BedNo = OdbcReader.GetString(1);
                    if (!OdbcReader.IsDBNull(2))
                        OneMedBedRec.BedLabel = OdbcReader.GetString(2);
                    if (!OdbcReader.IsDBNull(3))
                        OneMedBedRec.RoomNo = OdbcReader.GetString(3);
                    if (!OdbcReader.IsDBNull(4))
                        OneMedBedRec.DeptCode = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        OneMedBedRec.BedApprovedType = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        OneMedBedRec.BedSexType = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        OneMedBedRec.BedClass = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        OneMedBedRec.BedStatus = OdbcReader.GetString(8);
                    if (!OdbcReader.IsDBNull(9))
                        OneMedBedRec.IcuIndicator = OdbcReader.GetDecimal(9);
                    if (!OdbcReader.IsDBNull(10))
                        OneMedBedRec.MonitorLabel = OdbcReader.GetString(10);
                    if (!OdbcReader.IsDBNull(11))
                        OneMedBedRec.SerialNo = OdbcReader.GetDecimal(11);
                }
                else
                    OneMedBedRec = null;
            }
            return OneMedBedRec;
        }

        public int InsertMedBedRecOdbc(Model.MedBedRec OneMedBedRec)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedBedRec");
                if (OneMedBedRec.WardCode != null)
                    oneInert[0].Value = OneMedBedRec.WardCode;
                else
                    oneInert[0].Value = DBNull.Value;
                if (OneMedBedRec.BedNo != null)
                    oneInert[1].Value = OneMedBedRec.BedNo;
                else
                    oneInert[1].Value = DBNull.Value;
                if (OneMedBedRec.BedLabel != null)
                    oneInert[2].Value = OneMedBedRec.BedLabel;
                else
                    oneInert[2].Value = DBNull.Value;
                if (OneMedBedRec.RoomNo != null)
                    oneInert[3].Value = OneMedBedRec.RoomNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (OneMedBedRec.DeptCode != null)
                    oneInert[4].Value = OneMedBedRec.DeptCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (OneMedBedRec.BedApprovedType != null)
                    oneInert[5].Value = OneMedBedRec.BedApprovedType;
                else
                    oneInert[5].Value = DBNull.Value;
                if (OneMedBedRec.BedSexType != null)
                    oneInert[6].Value = OneMedBedRec.BedSexType;
                else
                    oneInert[6].Value = DBNull.Value;
                if (OneMedBedRec.BedClass != null)
                    oneInert[7].Value = OneMedBedRec.BedClass;
                else
                    oneInert[7].Value = DBNull.Value;
                if (OneMedBedRec.BedStatus != null)
                    oneInert[8].Value = OneMedBedRec.BedStatus;
                else
                    oneInert[8].Value = DBNull.Value;
                if (OneMedBedRec.IcuIndicator.ToString() != null)
                    oneInert[9].Value = OneMedBedRec.IcuIndicator;
                else
                    oneInert[9].Value = DBNull.Value;
                if (OneMedBedRec.MonitorLabel != null)
                    oneInert[10].Value = OneMedBedRec.MonitorLabel;
                else
                    oneInert[10].Value = DBNull.Value;
                if (OneMedBedRec.SerialNo.ToString() != null)
                    oneInert[11].Value = OneMedBedRec.SerialNo;
                else
                    oneInert[11].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedBedRec_Odbc, oneInert);
            }
        }

        public int UpdateMedBedRecOdbc(Model.MedBedRec OneMedBedRec)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedBedRec");
                if (OneMedBedRec.BedLabel != null)
                    oneUpdate[0].Value = OneMedBedRec.BedLabel;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (OneMedBedRec.RoomNo != null)
                    oneUpdate[1].Value = OneMedBedRec.RoomNo;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (OneMedBedRec.DeptCode != null)
                    oneUpdate[2].Value = OneMedBedRec.DeptCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (OneMedBedRec.BedApprovedType != null)
                    oneUpdate[3].Value = OneMedBedRec.BedApprovedType;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (OneMedBedRec.BedSexType != null)
                    oneUpdate[4].Value = OneMedBedRec.BedSexType;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (OneMedBedRec.BedClass != null)
                    oneUpdate[5].Value = OneMedBedRec.BedClass;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (OneMedBedRec.BedStatus != null)
                    oneUpdate[6].Value = OneMedBedRec.BedStatus;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (OneMedBedRec.IcuIndicator.ToString() != null)
                    oneUpdate[7].Value = OneMedBedRec.IcuIndicator;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (OneMedBedRec.MonitorLabel != null)
                    oneUpdate[8].Value = OneMedBedRec.MonitorLabel;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (OneMedBedRec.SerialNo.ToString() != null)
                    oneUpdate[9].Value = OneMedBedRec.SerialNo;
                else
                    oneUpdate[9].Value = DBNull.Value;
                oneUpdate[10].Value = OneMedBedRec.WardCode;
                oneUpdate[11].Value = OneMedBedRec.BedNo;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedBedRec_Odbc, oneUpdate);
            }
        }
	}
}
