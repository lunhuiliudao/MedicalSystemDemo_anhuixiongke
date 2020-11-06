

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
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedLabResult
	/// </summary>
	
	public partial class DALMedLabResult
	{

		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedLabResult 
		///Insert Table MED_LAB_RESULT
		/// </summary>
        public int InsertMedLabResultSQL(MedLabResult model, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneInert = GetParameterSQL("InsertMedLabResult");
			if (model.TestNo != null)
				oneInert[0].Value = model.TestNo;
			else
				oneInert[0].Value = DBNull.Value;
            if (model.ItemNo.ToString() != null)
				oneInert[1].Value = model.ItemNo;
			else
				oneInert[1].Value = DBNull.Value;
			if (model.PrintOrder.ToString() != null)
				oneInert[2].Value = model.PrintOrder;
			else
				oneInert[2].Value = DBNull.Value;
			if (model.ReportItemName != null)
				oneInert[3].Value = model.ReportItemName;
			else
				oneInert[3].Value = DBNull.Value;
			if (model.ReportItemCode != null)
				oneInert[4].Value = model.ReportItemCode;
			else
				oneInert[4].Value = DBNull.Value;
			if (model.Result != null)
				oneInert[5].Value = model.Result;
			else
				oneInert[5].Value = DBNull.Value;
			if (model.Units != null)
				oneInert[6].Value = model.Units;
			else
				oneInert[6].Value = DBNull.Value;
			if (model.AbnormalIndicator != null)
				oneInert[7].Value = model.AbnormalIndicator;
			else
				oneInert[7].Value = DBNull.Value;
			if (model.InstrumentId != null)
				oneInert[8].Value = model.InstrumentId;
			else
				oneInert[8].Value = DBNull.Value;
			if (model.ResultDateTime > DateTime.MinValue)
				oneInert[9].Value = model.ResultDateTime;
			else
				oneInert[9].Value = DBNull.Value;
			if (model.ReferenceResult != null)
				oneInert[10].Value = model.ReferenceResult;
			else
				oneInert[10].Value = DBNull.Value;
	
		    return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_LAB_RESULT_Insert_SQL, oneInert);

		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedLabResult 
		///Update Table     MED_LAB_RESULT
		/// </summary>
        public int UpdateMedLabResultSQL(MedLabResult model, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedLabResult");
			if (model.TestNo != null)
				oneUpdate[0].Value = model.TestNo;
			else
				oneUpdate[0].Value = DBNull.Value;
            if (model.ItemNo.ToString() != null)
				oneUpdate[1].Value = model.ItemNo;
			else
				oneUpdate[1].Value = DBNull.Value;
			if (model.PrintOrder.ToString() != null)
				oneUpdate[2].Value = model.PrintOrder;
			else
				oneUpdate[2].Value = DBNull.Value;
			if (model.ReportItemName != null)
				oneUpdate[3].Value = model.ReportItemName;
			else
				oneUpdate[3].Value = DBNull.Value;
			if (model.ReportItemCode != null)
				oneUpdate[4].Value = model.ReportItemCode;
			else
				oneUpdate[4].Value = DBNull.Value;
			if (model.Result != null)
				oneUpdate[5].Value = model.Result;
			else
				oneUpdate[5].Value = DBNull.Value;
			if (model.Units != null)
				oneUpdate[6].Value = model.Units;
			else
				oneUpdate[6].Value = DBNull.Value;
			if (model.AbnormalIndicator != null)
				oneUpdate[7].Value = model.AbnormalIndicator;
			else
				oneUpdate[7].Value = DBNull.Value;
			if (model.InstrumentId != null)
				oneUpdate[8].Value = model.InstrumentId;
			else
				oneUpdate[8].Value = DBNull.Value;
			if (model.ResultDateTime > DateTime.MinValue)
				oneUpdate[9].Value = model.ResultDateTime;
			else
				oneUpdate[9].Value = DBNull.Value;
			if (model.ReferenceResult != null)
				oneUpdate[10].Value = model.ReferenceResult;
			else
				oneUpdate[10].Value = DBNull.Value;
			if (model.TestNo != null)
				oneUpdate[11].Value =model.TestNo;
			else
				oneUpdate[11].Value = DBNull.Value;
			if (model.ItemNo.ToString() != null)
				oneUpdate[12].Value =model.ItemNo;
			else
				oneUpdate[12].Value = DBNull.Value;
			if (model.PrintOrder.ToString() != null)
				oneUpdate[13].Value =model.PrintOrder;
			else
				oneUpdate[13].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_LAB_RESULT_Update_SQL, oneUpdate);

		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedLabResult 
		///Delete Table MED_LAB_RESULT by (string TEST_NO,decimal ITEM_NO,decimal PRINT_ORDER)
		/// </summary>
        public int DeleteMedLabResultSQL(string TEST_NO, decimal ITEM_NO, decimal PRINT_ORDER, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneDelete = GetParameterSQL("DeleteMedLabResult");
			if (TEST_NO != null)
				oneDelete[0].Value =TEST_NO;
			else
				oneDelete[0].Value = DBNull.Value;
            if (ITEM_NO.ToString() != null)
				oneDelete[1].Value =ITEM_NO;
			else
				oneDelete[1].Value = DBNull.Value;
            if (PRINT_ORDER.ToString() != null)
				oneDelete[2].Value =PRINT_ORDER;
			else
				oneDelete[2].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_LAB_RESULT_Delete_SQL, oneDelete);
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedLabResult 
		///select Table MED_LAB_RESULT by (string TEST_NO,decimal ITEM_NO,decimal PRINT_ORDER)
		/// </summary>
        public MedLabResult SelectMedLabResultSQL(string TEST_NO, decimal ITEM_NO, decimal PRINT_ORDER, System.Data.Common.DbConnection oleCisConn)
		{
			MedLabResult model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedLabResult");
			parameterValues[0].Value=TEST_NO;
			parameterValues[1].Value=ITEM_NO;
			parameterValues[2].Value=PRINT_ORDER;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_LAB_RESULT_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedLabResult();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PrintOrder = decimal.Parse(oleReader["PRINT_ORDER"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ReportItemName = oleReader["REPORT_ITEM_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ReportItemCode = oleReader["REPORT_ITEM_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.Result = oleReader["RESULT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.AbnormalIndicator = oleReader["ABNORMAL_INDICATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.InstrumentId = oleReader["INSTRUMENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.ResultDateTime = DateTime.Parse(oleReader["RESULT_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.ReferenceResult = oleReader["REFERENCE_RESULT"].ToString().Trim() ;
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
		public List<MedLabResult> SelectMedLabResultListSQL( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedLabResult> modelList = new List<MedLabResult>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_LAB_RESULT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedLabResult model = new MedLabResult();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PrintOrder = decimal.Parse(oleReader["PRINT_ORDER"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ReportItemName = oleReader["REPORT_ITEM_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ReportItemCode = oleReader["REPORT_ITEM_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.Result = oleReader["RESULT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.AbnormalIndicator = oleReader["ABNORMAL_INDICATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.InstrumentId = oleReader["INSTRUMENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.ResultDateTime = DateTime.Parse(oleReader["RESULT_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.ReferenceResult = oleReader["REFERENCE_RESULT"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	

		#region [添加一条记录]
		/// <summary>
		///Add    model  MedLabResult 
		///Insert Table MED_LAB_RESULT
		/// </summary>
        public int InsertMedLabResult(MedLabResult model, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneInert = GetParameter("InsertMedLabResult");
			if (model.TestNo != null)
				oneInert[0].Value = model.TestNo;
			else
				oneInert[0].Value = DBNull.Value;
			if (model.ItemNo.ToString() != null)
				oneInert[1].Value = model.ItemNo;
			else
				oneInert[1].Value = DBNull.Value;
			if (model.PrintOrder.ToString() != null)
				oneInert[2].Value = model.PrintOrder;
			else
				oneInert[2].Value = DBNull.Value;
			if (model.ReportItemName != null)
				oneInert[3].Value = model.ReportItemName;
			else
				oneInert[3].Value = DBNull.Value;
			if (model.ReportItemCode != null)
				oneInert[4].Value = model.ReportItemCode;
			else
				oneInert[4].Value = DBNull.Value;
			if (model.Result != null)
				oneInert[5].Value = model.Result;
			else
				oneInert[5].Value = DBNull.Value;
			if (model.Units != null)
				oneInert[6].Value = model.Units;
			else
				oneInert[6].Value = DBNull.Value;
			if (model.AbnormalIndicator != null)
				oneInert[7].Value = model.AbnormalIndicator;
			else
				oneInert[7].Value = DBNull.Value;
			if (model.InstrumentId != null)
				oneInert[8].Value = model.InstrumentId;
			else
				oneInert[8].Value = DBNull.Value;
			if (model.ResultDateTime > DateTime.MinValue)
				oneInert[9].Value = model.ResultDateTime;
			else
				oneInert[9].Value = DBNull.Value;
			if (model.ReferenceResult != null)
				oneInert[10].Value = model.ReferenceResult;
			else
				oneInert[10].Value = DBNull.Value;
	
		    return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_LAB_RESULT_Insert, oneInert);

		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedLabResult 
		///Update Table     MED_LAB_RESULT
		/// </summary>
        public int UpdateMedLabResult(MedLabResult model, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneUpdate = GetParameter("UpdateMedLabResult");
			if (model.TestNo != null)
				oneUpdate[0].Value = model.TestNo;
			else
				oneUpdate[0].Value = DBNull.Value;
			if (model.ItemNo.ToString() != null)
				oneUpdate[1].Value = model.ItemNo;
			else
				oneUpdate[1].Value = DBNull.Value;
			if (model.PrintOrder.ToString() != null)
				oneUpdate[2].Value = model.PrintOrder;
			else
				oneUpdate[2].Value = DBNull.Value;
			if (model.ReportItemName != null)
				oneUpdate[3].Value = model.ReportItemName;
			else
				oneUpdate[3].Value = DBNull.Value;
			if (model.ReportItemCode != null)
				oneUpdate[4].Value = model.ReportItemCode;
			else
				oneUpdate[4].Value = DBNull.Value;
			if (model.Result != null)
				oneUpdate[5].Value = model.Result;
			else
				oneUpdate[5].Value = DBNull.Value;
			if (model.Units != null)
				oneUpdate[6].Value = model.Units;
			else
				oneUpdate[6].Value = DBNull.Value;
			if (model.AbnormalIndicator != null)
				oneUpdate[7].Value = model.AbnormalIndicator;
			else
				oneUpdate[7].Value = DBNull.Value;
			if (model.InstrumentId != null)
				oneUpdate[8].Value = model.InstrumentId;
			else
				oneUpdate[8].Value = DBNull.Value;
			if (model.ResultDateTime > DateTime.MinValue)
				oneUpdate[9].Value = model.ResultDateTime;
			else
				oneUpdate[9].Value = DBNull.Value;
			if (model.ReferenceResult != null)
				oneUpdate[10].Value = model.ReferenceResult;
			else
				oneUpdate[10].Value = DBNull.Value;
			if (model.TestNo != null)
				oneUpdate[11].Value =model.TestNo;
			else
				oneUpdate[11].Value = DBNull.Value;
			if (model.ItemNo.ToString() != null)
				oneUpdate[12].Value =model.ItemNo;
			else
				oneUpdate[12].Value = DBNull.Value;
			if (model.PrintOrder.ToString() != null)
				oneUpdate[13].Value =model.PrintOrder;
			else
				oneUpdate[13].Value = DBNull.Value;
	
		    return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans,CommandType.Text, MED_LAB_RESULT_Update, oneUpdate);

		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedLabResult 
		///Delete Table MED_LAB_RESULT by (string TEST_NO,decimal ITEM_NO,decimal PRINT_ORDER)
		/// </summary>
        public int DeleteMedLabResult(string TEST_NO, decimal ITEM_NO, decimal PRINT_ORDER, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneDelete = GetParameter("DeleteMedLabResult");
			if (TEST_NO != null)
				oneDelete[0].Value =TEST_NO;
			else
				oneDelete[0].Value = DBNull.Value;
			if (ITEM_NO.ToString() != null)
				oneDelete[1].Value =ITEM_NO;
			else
				oneDelete[1].Value = DBNull.Value;
            if (PRINT_ORDER.ToString() != null)
				oneDelete[2].Value =PRINT_ORDER;
			else
				oneDelete[2].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_LAB_RESULT_Delete, oneDelete);

		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedLabResult 
		///select Table MED_LAB_RESULT by (string TEST_NO,decimal ITEM_NO,decimal PRINT_ORDER)
		/// </summary>
        public MedLabResult SelectMedLabResult(string TEST_NO, decimal ITEM_NO, decimal PRINT_ORDER, System.Data.Common.DbConnection oleCisConn)
		{
			MedLabResult model;
			OracleParameter[] parameterValues = GetParameter("SelectMedLabResult");
			parameterValues[0].Value=TEST_NO;
			parameterValues[1].Value=ITEM_NO;
			parameterValues[2].Value=PRINT_ORDER;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_LAB_RESULT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedLabResult();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PrintOrder = decimal.Parse(oleReader["PRINT_ORDER"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ReportItemName = oleReader["REPORT_ITEM_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ReportItemCode = oleReader["REPORT_ITEM_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.Result = oleReader["RESULT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.AbnormalIndicator = oleReader["ABNORMAL_INDICATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.InstrumentId = oleReader["INSTRUMENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.ResultDateTime = DateTime.Parse(oleReader["RESULT_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.ReferenceResult = oleReader["REFERENCE_RESULT"].ToString().Trim() ;
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
		public List<MedLabResult> SelectMedLabResultList( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedLabResult> modelList = new List<MedLabResult>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_LAB_RESULT_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedLabResult model = new MedLabResult();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PrintOrder = decimal.Parse(oleReader["PRINT_ORDER"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ReportItemName = oleReader["REPORT_ITEM_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ReportItemCode = oleReader["REPORT_ITEM_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.Result = oleReader["RESULT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.AbnormalIndicator = oleReader["ABNORMAL_INDICATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.InstrumentId = oleReader["INSTRUMENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.ResultDateTime = DateTime.Parse(oleReader["RESULT_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.ReferenceResult = oleReader["REFERENCE_RESULT"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
