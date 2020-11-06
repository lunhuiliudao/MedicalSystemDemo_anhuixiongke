

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:00:56
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
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedLabResult OLE
	/// </summary>
    public partial class DALMedLabResult
	{

        private static readonly string Select_Med_Lab_Result_OLE = "select test_no, item_no, print_order, report_item_name, report_item_code, result, units, abnormal_indicator, instrument_id, result_date_time, reference_result from med_lab_result where test_no = ? and item_no = ? and  print_order = ?";
        private static readonly string Insert_Med_Lab_Result_OLE = "insert into med_lab_result(test_no, item_no, print_order, report_item_name, report_item_code, result, units, abnormal_indicator, instrument_id, result_date_time, reference_result)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_Med_Lab_Result_OLE = "update med_lab_result set report_item_name = ?, report_item_code = ?, result = ?, units = ?, abnormal_indicator = ?, instrument_id = ?, result_date_time = ?, reference_result = ? where test_no = ? and item_no = ? and print_order = ?";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedLabResult")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("testNo",OleDbType.VarChar),
                        new OleDbParameter("itemNo",OleDbType.Decimal),
                        new OleDbParameter("printOrder",OleDbType.Decimal)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedLabResult")
                    {
                        parms = new OleDbParameter[]{
                            new OleDbParameter("testNo",OleDbType.VarChar),
                            new OleDbParameter("itemNo",OleDbType.Decimal),
                            new OleDbParameter("printOrder",OleDbType.Decimal), 
                            new OleDbParameter("reportItemName",OleDbType.VarChar), 
                            new OleDbParameter("reportItemCode",OleDbType.VarChar), 
                            new OleDbParameter("result",OleDbType.VarChar), 
                            new OleDbParameter("units",OleDbType.VarChar), 
                            new OleDbParameter("abnormalIndicator",OleDbType.VarChar), 
                            new OleDbParameter("instrumentId",OleDbType.VarChar), 
                            new OleDbParameter("resultDateTime",OleDbType.DBTimeStamp), 
                            new OleDbParameter("referenceResult",OleDbType.VarChar)
                        };
                    }
                    else
                    {
                        if (sqlParms == "UpdateMedLabResult")
                        {
                            parms = new OleDbParameter[]{
                                new OleDbParameter("reportItemName",OleDbType.VarChar), 
                                new OleDbParameter("reportItemCode",OleDbType.VarChar), 
                                new OleDbParameter("result",OleDbType.VarChar), 
                                new OleDbParameter("units",OleDbType.VarChar), 
                                new OleDbParameter("abnormalIndicator",OleDbType.VarChar), 
                                new OleDbParameter("instrumentId",OleDbType.VarChar), 
                                new OleDbParameter("resultDateTime",OleDbType.DBTimeStamp), 
                                new OleDbParameter("referenceResult",OleDbType.VarChar),
                                new OleDbParameter("testNo",OleDbType.VarChar),
                                new OleDbParameter("itemNo",OleDbType.Decimal),
                                new OleDbParameter("printOrder",OleDbType.Decimal)
                            };
                        }
                    }
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedLabResult SelectMedLabResultOLE(string testNo, decimal itemNo, decimal printOrder)
        {
            Model.MedLabResult MedLabResult = null;

            OleDbParameter[] mdPats = GetParameterOLE("SelectMedLabResult");
            mdPats[0].Value = testNo;
            mdPats[1].Value = itemNo;
            mdPats[2].Value = printOrder;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Med_Lab_Result_OLE, mdPats))
            {
                if (oleReader.Read())
                {
                    MedLabResult = new Model.MedLabResult();
                    MedLabResult.TestNo = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        MedLabResult.ItemNo = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        MedLabResult.PrintOrder = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        MedLabResult.ReportItemName = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        MedLabResult.ReportItemCode = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        MedLabResult.Result = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        MedLabResult.Units = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        MedLabResult.AbnormalIndicator = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        MedLabResult.InstrumentId = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        MedLabResult.ResultDateTime = oleReader.GetDateTime(9);
                    if (!oleReader.IsDBNull(10))
                        MedLabResult.ReferenceResult = oleReader.GetString(10);
                }
                else
                    MedLabResult = null;
            }
            return MedLabResult;
        }

        public int InsertMedLabResultOLE(Model.MedLabResult MedLabResult)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedLabResult");
                oneInert[0].Value = MedLabResult.TestNo;
                if (MedLabResult.ItemNo.ToString() != null)
                    oneInert[1].Value = MedLabResult.ItemNo;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedLabResult.PrintOrder.ToString() != null)
                    oneInert[2].Value = MedLabResult.PrintOrder;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedLabResult.ReportItemName != null)
                    oneInert[3].Value = MedLabResult.ReportItemName;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedLabResult.ReportItemCode != null)
                    oneInert[4].Value = MedLabResult.ReportItemCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedLabResult.Result != null)
                    oneInert[5].Value = MedLabResult.Result;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedLabResult.Units != null)
                    oneInert[6].Value = MedLabResult.Units;
                else
                    oneInert[6].Value = DBNull.Value;
                if (MedLabResult.AbnormalIndicator != null)
                    oneInert[7].Value = MedLabResult.AbnormalIndicator;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedLabResult.InstrumentId != null)
                    oneInert[8].Value = MedLabResult.InstrumentId;
                else
                    oneInert[8].Value = DBNull.Value;
                if (MedLabResult.ResultDateTime > DateTime.MinValue)
                    oneInert[9].Value = MedLabResult.ResultDateTime;
                else
                    oneInert[9].Value = DBNull.Value;
                if (MedLabResult.ReferenceResult != null)
                    oneInert[10].Value = MedLabResult.ReferenceResult;
                else
                    oneInert[10].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_Med_Lab_Result_OLE, oneInert);
            }
        }

        public int UpdateMedLabResultOLE(Model.MedLabResult MedLabResult)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedLabResult");
                if (MedLabResult.ReportItemName != null)
                    oneUpdate[0].Value = MedLabResult.ReportItemName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedLabResult.ReportItemCode != null)
                    oneUpdate[1].Value = MedLabResult.ReportItemCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedLabResult.Result != null)
                    oneUpdate[2].Value = MedLabResult.Result;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedLabResult.Units != null)
                    oneUpdate[3].Value = MedLabResult.Units;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedLabResult.AbnormalIndicator != null)
                    oneUpdate[4].Value = MedLabResult.AbnormalIndicator;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedLabResult.InstrumentId != null)
                    oneUpdate[5].Value = MedLabResult.InstrumentId;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedLabResult.ResultDateTime > DateTime.MinValue)
                    oneUpdate[6].Value = MedLabResult.ResultDateTime;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedLabResult.ReferenceResult != null)
                    oneUpdate[7].Value = MedLabResult.ReferenceResult;
                else
                    oneUpdate[7].Value = DBNull.Value;
                oneUpdate[8].Value = MedLabResult.TestNo;
                oneUpdate[9].Value = MedLabResult.ItemNo;
                oneUpdate[10].Value = MedLabResult.PrintOrder;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_Med_Lab_Result_OLE, oneUpdate);
            }
        }

        private static readonly string Select_Med_Lab_Result_Odbc = "select test_no, item_no, print_order, report_item_name, report_item_code, result, units, abnormal_indicator, instrument_id, result_date_time, reference_result from med_lab_result where test_no = ? and item_no = ? and  print_order = ?";
        private static readonly string Insert_Med_Lab_Result_Odbc = "insert into med_lab_result(test_no, item_no, print_order, report_item_name, report_item_code, result, units, abnormal_indicator, instrument_id, result_date_time, reference_result)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_Med_Lab_Result_Odbc = "update med_lab_result set report_item_name = ?, report_item_code = ?, result = ?, units = ?, abnormal_indicator = ?, instrument_id = ?, result_date_time = ?, reference_result = ? where test_no = ? and item_no = ? and print_order = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedLabResult")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("testNo",OdbcType.VarChar),
                        new OdbcParameter("itemNo",OdbcType.Decimal),
                        new OdbcParameter("printOrder",OdbcType.Decimal)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedLabResult")
                    {
                        parms = new OdbcParameter[]{
                            new OdbcParameter("testNo",OdbcType.VarChar),
                            new OdbcParameter("itemNo",OdbcType.Decimal),
                            new OdbcParameter("printOrder",OdbcType.Decimal), 
                            new OdbcParameter("reportItemName",OdbcType.VarChar), 
                            new OdbcParameter("reportItemCode",OdbcType.VarChar), 
                            new OdbcParameter("result",OdbcType.VarChar), 
                            new OdbcParameter("units",OdbcType.VarChar), 
                            new OdbcParameter("abnormalIndicator",OdbcType.VarChar), 
                            new OdbcParameter("instrumentId",OdbcType.VarChar), 
                            new OdbcParameter("resultDateTime",OdbcType.DateTime), 
                            new OdbcParameter("referenceResult",OdbcType.VarChar)
                        };
                    }
                    else
                    {
                        if (sqlParms == "UpdateMedLabResult")
                        {
                            parms = new OdbcParameter[]{
                                new OdbcParameter("reportItemName",OdbcType.VarChar), 
                                new OdbcParameter("reportItemCode",OdbcType.VarChar), 
                                new OdbcParameter("result",OdbcType.VarChar), 
                                new OdbcParameter("units",OdbcType.VarChar), 
                                new OdbcParameter("abnormalIndicator",OdbcType.VarChar), 
                                new OdbcParameter("instrumentId",OdbcType.VarChar), 
                                new OdbcParameter("resultDateTime",OdbcType.DateTime), 
                                new OdbcParameter("referenceResult",OdbcType.VarChar),
                                new OdbcParameter("testNo",OdbcType.VarChar),
                                new OdbcParameter("itemNo",OdbcType.Decimal),
                                new OdbcParameter("printOrder",OdbcType.Decimal)
                            };
                        }
                    }
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedLabResult SelectMedLabResultOdbc(string testNo, decimal itemNo, decimal printOrder)
        {
            Model.MedLabResult MedLabResult = null;

            OdbcParameter[] mdPats = GetParameterOdbc("SelectMedLabResult");
            mdPats[0].Value = testNo;
            mdPats[1].Value = itemNo;
            mdPats[2].Value = printOrder;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Med_Lab_Result_Odbc, mdPats))
            {
                if (OdbcReader.Read())
                {
                    MedLabResult = new Model.MedLabResult();
                    MedLabResult.TestNo = OdbcReader.GetString(0);
                    if (!OdbcReader.IsDBNull(1))
                        MedLabResult.ItemNo = OdbcReader.GetDecimal(1);
                    if (!OdbcReader.IsDBNull(2))
                        MedLabResult.PrintOrder = OdbcReader.GetDecimal(2);
                    if (!OdbcReader.IsDBNull(3))
                        MedLabResult.ReportItemName = OdbcReader.GetString(3);
                    if (!OdbcReader.IsDBNull(4))
                        MedLabResult.ReportItemCode = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        MedLabResult.Result = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        MedLabResult.Units = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        MedLabResult.AbnormalIndicator = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        MedLabResult.InstrumentId = OdbcReader.GetString(8);
                    if (!OdbcReader.IsDBNull(9))
                        MedLabResult.ResultDateTime = OdbcReader.GetDateTime(9);
                    if (!OdbcReader.IsDBNull(10))
                        MedLabResult.ReferenceResult = OdbcReader.GetString(10);
                }
                else
                    MedLabResult = null;
            }
            return MedLabResult;
        }

        public int InsertMedLabResultOdbc(Model.MedLabResult MedLabResult)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedLabResult");
                oneInert[0].Value = MedLabResult.TestNo;
                if (MedLabResult.ItemNo.ToString() != null)
                    oneInert[1].Value = MedLabResult.ItemNo;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedLabResult.PrintOrder.ToString() != null)
                    oneInert[2].Value = MedLabResult.PrintOrder;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedLabResult.ReportItemName != null)
                    oneInert[3].Value = MedLabResult.ReportItemName;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedLabResult.ReportItemCode != null)
                    oneInert[4].Value = MedLabResult.ReportItemCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedLabResult.Result != null)
                    oneInert[5].Value = MedLabResult.Result;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedLabResult.Units != null)
                    oneInert[6].Value = MedLabResult.Units;
                else
                    oneInert[6].Value = DBNull.Value;
                if (MedLabResult.AbnormalIndicator != null)
                    oneInert[7].Value = MedLabResult.AbnormalIndicator;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedLabResult.InstrumentId != null)
                    oneInert[8].Value = MedLabResult.InstrumentId;
                else
                    oneInert[8].Value = DBNull.Value;
                if (MedLabResult.ResultDateTime > DateTime.MinValue)
                    oneInert[9].Value = MedLabResult.ResultDateTime;
                else
                    oneInert[9].Value = DBNull.Value;
                if (MedLabResult.ReferenceResult != null)
                    oneInert[10].Value = MedLabResult.ReferenceResult;
                else
                    oneInert[10].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_Med_Lab_Result_Odbc, oneInert);
            }
        }

        public int UpdateMedLabResultOdbc(Model.MedLabResult MedLabResult)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedLabResult");
                if (MedLabResult.ReportItemName != null)
                    oneUpdate[0].Value = MedLabResult.ReportItemName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedLabResult.ReportItemCode != null)
                    oneUpdate[1].Value = MedLabResult.ReportItemCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedLabResult.Result != null)
                    oneUpdate[2].Value = MedLabResult.Result;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedLabResult.Units != null)
                    oneUpdate[3].Value = MedLabResult.Units;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedLabResult.AbnormalIndicator != null)
                    oneUpdate[4].Value = MedLabResult.AbnormalIndicator;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedLabResult.InstrumentId != null)
                    oneUpdate[5].Value = MedLabResult.InstrumentId;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedLabResult.ResultDateTime > DateTime.MinValue)
                    oneUpdate[6].Value = MedLabResult.ResultDateTime;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedLabResult.ReferenceResult != null)
                    oneUpdate[7].Value = MedLabResult.ReferenceResult;
                else
                    oneUpdate[7].Value = DBNull.Value;
                oneUpdate[8].Value = MedLabResult.TestNo;
                oneUpdate[9].Value = MedLabResult.ItemNo;
                oneUpdate[10].Value = MedLabResult.PrintOrder;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_Med_Lab_Result_Odbc, oneUpdate);
            }
        }
	}
}
