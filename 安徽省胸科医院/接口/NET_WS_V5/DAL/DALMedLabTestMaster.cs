

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:01
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
	/// DAL MedLabTestMaster
	/// </summary>

    public partial class DALMedLabTestMaster
	{
		
		private static readonly string MED_LAB_TEST_MASTER_Insert_SQL = "INSERT INTO MED_LAB_TEST_MASTER (TEST_NO,PRIORITY_INDICATOR,PATIENT_ID,VISIT_ID,WORKING_ID,EXECUTE_DATE,NAME,NAME_PHONETIC,CHARGE_TYPE,SEX,AGE,TEST_CAUSE,RELEVANT_CLINIC_DIAG,SPECIMEN,NOTES_FOR_SPCM,SPCM_RECEIVED_DATE_TIME,SPCM_SAMPLE_DATE_TIME,REQUESTED_DATE_TIME,ORDERING_DEPT,ORDERING_PROVIDER,PERFORMED_BY,RESULT_STATUS,RESULTS_RPT_DATE_TIME,TRANSCRIPTIONIST,VERIFIED_BY,COSTS,CHARGES,BILLING_INDICATOR,PRINT_INDICATOR,SUBJECT,BARCODE) values (@TestNo,@PriorityIndicator,@PatientId,@VisitId,@WorkingId,@ExecuteDate,@Name,@NamePhonetic,@ChargeType,@Sex,@Age,@TestCause,@RelevantClinicDiag,@Specimen,@NotesForSpcm,@SpcmReceivedDateTime,@SpcmSampleDateTime,@RequestedDateTime,@OrderingDept,@OrderingProvider,@PerformedBy,@ResultStatus,@ResultsRptDateTime,@Transcriptionist,@VerifiedBy,@Costs,@Charges,@BillingIndicator,@PrintIndicator,@Subject,@Barcode)";
		private static readonly string MED_LAB_TEST_MASTER_Update_SQL = "UPDATE MED_LAB_TEST_MASTER SET TEST_NO=@TestNo,PRIORITY_INDICATOR=@PriorityIndicator,PATIENT_ID=@PatientId,VISIT_ID=@VisitId,WORKING_ID=@WorkingId,EXECUTE_DATE=@ExecuteDate,NAME=@Name,NAME_PHONETIC=@NamePhonetic,CHARGE_TYPE=@ChargeType,SEX=@Sex,AGE=@Age,TEST_CAUSE=@TestCause,RELEVANT_CLINIC_DIAG=@RelevantClinicDiag,SPECIMEN=@Specimen,NOTES_FOR_SPCM=@NotesForSpcm,SPCM_RECEIVED_DATE_TIME=@SpcmReceivedDateTime,SPCM_SAMPLE_DATE_TIME=@SpcmSampleDateTime,REQUESTED_DATE_TIME=@RequestedDateTime,ORDERING_DEPT=@OrderingDept,ORDERING_PROVIDER=@OrderingProvider,PERFORMED_BY=@PerformedBy,RESULT_STATUS=@ResultStatus,RESULTS_RPT_DATE_TIME=@ResultsRptDateTime,TRANSCRIPTIONIST=@Transcriptionist,VERIFIED_BY=@VerifiedBy,COSTS=@Costs,CHARGES=@Charges,BILLING_INDICATOR=@BillingIndicator,PRINT_INDICATOR=@PrintIndicator,SUBJECT=@Subject,BARCODE=@Barcode WHERE TEST_NO=@TestNoP";
		private static readonly string MED_LAB_TEST_MASTER_Delete_SQL = "Delete MED_LAB_TEST_MASTER WHERE TEST_NO=@TestNo";
		private static readonly string MED_LAB_TEST_MASTER_Select_SQL = "SELECT TEST_NO,PRIORITY_INDICATOR,PATIENT_ID,VISIT_ID,WORKING_ID,EXECUTE_DATE,NAME,NAME_PHONETIC,CHARGE_TYPE,SEX,AGE,TEST_CAUSE,RELEVANT_CLINIC_DIAG,SPECIMEN,NOTES_FOR_SPCM,SPCM_RECEIVED_DATE_TIME,SPCM_SAMPLE_DATE_TIME,REQUESTED_DATE_TIME,ORDERING_DEPT,ORDERING_PROVIDER,PERFORMED_BY,RESULT_STATUS,RESULTS_RPT_DATE_TIME,TRANSCRIPTIONIST,VERIFIED_BY,COSTS,CHARGES,BILLING_INDICATOR,PRINT_INDICATOR,SUBJECT,BARCODE FROM MED_LAB_TEST_MASTER where TEST_NO=@TestNo";
		private static readonly string MED_LAB_TEST_MASTER_Select_ALL_SQL = "SELECT TEST_NO,PRIORITY_INDICATOR,PATIENT_ID,VISIT_ID,WORKING_ID,EXECUTE_DATE,NAME,NAME_PHONETIC,CHARGE_TYPE,SEX,AGE,TEST_CAUSE,RELEVANT_CLINIC_DIAG,SPECIMEN,NOTES_FOR_SPCM,SPCM_RECEIVED_DATE_TIME,SPCM_SAMPLE_DATE_TIME,REQUESTED_DATE_TIME,ORDERING_DEPT,ORDERING_PROVIDER,PERFORMED_BY,RESULT_STATUS,RESULTS_RPT_DATE_TIME,TRANSCRIPTIONIST,VERIFIED_BY,COSTS,CHARGES,BILLING_INDICATOR,PRINT_INDICATOR,SUBJECT,BARCODE FROM MED_LAB_TEST_MASTER";
		private static readonly string MED_LAB_TEST_MASTER_Insert = "INSERT INTO MED_LAB_TEST_MASTER (TEST_NO,PRIORITY_INDICATOR,PATIENT_ID,VISIT_ID,WORKING_ID,EXECUTE_DATE,NAME,NAME_PHONETIC,CHARGE_TYPE,SEX,AGE,TEST_CAUSE,RELEVANT_CLINIC_DIAG,SPECIMEN,NOTES_FOR_SPCM,SPCM_RECEIVED_DATE_TIME,SPCM_SAMPLE_DATE_TIME,REQUESTED_DATE_TIME,ORDERING_DEPT,ORDERING_PROVIDER,PERFORMED_BY,RESULT_STATUS,RESULTS_RPT_DATE_TIME,TRANSCRIPTIONIST,VERIFIED_BY,COSTS,CHARGES,BILLING_INDICATOR,PRINT_INDICATOR,SUBJECT,BARCODE) values (:TestNo,:PriorityIndicator,:PatientId,:VisitId,:WorkingId,:ExecuteDate,:Name,:NamePhonetic,:ChargeType,:Sex,:Age,:TestCause,:RelevantClinicDiag,:Specimen,:NotesForSpcm,:SpcmReceivedDateTime,:SpcmSampleDateTime,:RequestedDateTime,:OrderingDept,:OrderingProvider,:PerformedBy,:ResultStatus,:ResultsRptDateTime,:Transcriptionist,:VerifiedBy,:Costs,:Charges,:BillingIndicator,:PrintIndicator,:Subject,:Barcode)";
		private static readonly string MED_LAB_TEST_MASTER_Update = "UPDATE MED_LAB_TEST_MASTER SET TEST_NO=:TestNo,PRIORITY_INDICATOR=:PriorityIndicator,PATIENT_ID=:PatientId,VISIT_ID=:VisitId,WORKING_ID=:WorkingId,EXECUTE_DATE=:ExecuteDate,NAME=:Name,NAME_PHONETIC=:NamePhonetic,CHARGE_TYPE=:ChargeType,SEX=:Sex,AGE=:Age,TEST_CAUSE=:TestCause,RELEVANT_CLINIC_DIAG=:RelevantClinicDiag,SPECIMEN=:Specimen,NOTES_FOR_SPCM=:NotesForSpcm,SPCM_RECEIVED_DATE_TIME=:SpcmReceivedDateTime,SPCM_SAMPLE_DATE_TIME=:SpcmSampleDateTime,REQUESTED_DATE_TIME=:RequestedDateTime,ORDERING_DEPT=:OrderingDept,ORDERING_PROVIDER=:OrderingProvider,PERFORMED_BY=:PerformedBy,RESULT_STATUS=:ResultStatus,RESULTS_RPT_DATE_TIME=:ResultsRptDateTime,TRANSCRIPTIONIST=:Transcriptionist,VERIFIED_BY=:VerifiedBy,COSTS=:Costs,CHARGES=:Charges,BILLING_INDICATOR=:BillingIndicator,PRINT_INDICATOR=:PrintIndicator,SUBJECT=:Subject,BARCODE=:Barcode WHERE TEST_NO=:TestNoP";
		private static readonly string MED_LAB_TEST_MASTER_Delete = "Delete MED_LAB_TEST_MASTER WHERE TEST_NO=:TestNo";
		private static readonly string MED_LAB_TEST_MASTER_Select = "SELECT TEST_NO,PRIORITY_INDICATOR,PATIENT_ID,VISIT_ID,WORKING_ID,EXECUTE_DATE,NAME,NAME_PHONETIC,CHARGE_TYPE,SEX,AGE,TEST_CAUSE,RELEVANT_CLINIC_DIAG,SPECIMEN,NOTES_FOR_SPCM,SPCM_RECEIVED_DATE_TIME,SPCM_SAMPLE_DATE_TIME,REQUESTED_DATE_TIME,ORDERING_DEPT,ORDERING_PROVIDER,PERFORMED_BY,RESULT_STATUS,RESULTS_RPT_DATE_TIME,TRANSCRIPTIONIST,VERIFIED_BY,COSTS,CHARGES,BILLING_INDICATOR,PRINT_INDICATOR,SUBJECT,BARCODE FROM MED_LAB_TEST_MASTER where TEST_NO=:TestNo";
		private static readonly string MED_LAB_TEST_MASTER_Select_ALL = "SELECT TEST_NO,PRIORITY_INDICATOR,PATIENT_ID,VISIT_ID,WORKING_ID,EXECUTE_DATE,NAME,NAME_PHONETIC,CHARGE_TYPE,SEX,AGE,TEST_CAUSE,RELEVANT_CLINIC_DIAG,SPECIMEN,NOTES_FOR_SPCM,SPCM_RECEIVED_DATE_TIME,SPCM_SAMPLE_DATE_TIME,REQUESTED_DATE_TIME,ORDERING_DEPT,ORDERING_PROVIDER,PERFORMED_BY,RESULT_STATUS,RESULTS_RPT_DATE_TIME,TRANSCRIPTIONIST,VERIFIED_BY,COSTS,CHARGES,BILLING_INDICATOR,PRINT_INDICATOR,SUBJECT,BARCODE FROM MED_LAB_TEST_MASTER";
		public DALMedLabTestMaster ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedLabTestMaster SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedLabTestMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TestNo",SqlDbType.VarChar),
							new SqlParameter("@PriorityIndicator",SqlDbType.Decimal),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@WorkingId",SqlDbType.VarChar),
							new SqlParameter("@ExecuteDate",SqlDbType.DateTime),
							new SqlParameter("@Name",SqlDbType.VarChar),
							new SqlParameter("@NamePhonetic",SqlDbType.VarChar),
							new SqlParameter("@ChargeType",SqlDbType.VarChar),
							new SqlParameter("@Sex",SqlDbType.VarChar),
							new SqlParameter("@Age",SqlDbType.Decimal),
							new SqlParameter("@TestCause",SqlDbType.VarChar),
							new SqlParameter("@RelevantClinicDiag",SqlDbType.VarChar),
							new SqlParameter("@Specimen",SqlDbType.VarChar),
							new SqlParameter("@NotesForSpcm",SqlDbType.VarChar),
							new SqlParameter("@SpcmReceivedDateTime",SqlDbType.DateTime),
							new SqlParameter("@SpcmSampleDateTime",SqlDbType.DateTime),
							new SqlParameter("@RequestedDateTime",SqlDbType.DateTime),
							new SqlParameter("@OrderingDept",SqlDbType.VarChar),
							new SqlParameter("@OrderingProvider",SqlDbType.VarChar),
							new SqlParameter("@PerformedBy",SqlDbType.VarChar),
							new SqlParameter("@ResultStatus",SqlDbType.VarChar),
							new SqlParameter("@ResultsRptDateTime",SqlDbType.DateTime),
							new SqlParameter("@Transcriptionist",SqlDbType.VarChar),
							new SqlParameter("@VerifiedBy",SqlDbType.VarChar),
							new SqlParameter("@Costs",SqlDbType.Decimal),
							new SqlParameter("@Charges",SqlDbType.Decimal),
							new SqlParameter("@BillingIndicator",SqlDbType.Decimal),
							new SqlParameter("@PrintIndicator",SqlDbType.Decimal),
							new SqlParameter("@Subject",SqlDbType.VarChar),
							new SqlParameter("@Barcode",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedLabTestMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TestNo",SqlDbType.VarChar),
							new SqlParameter("@PriorityIndicator",SqlDbType.Decimal),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@WorkingId",SqlDbType.VarChar),
							new SqlParameter("@ExecuteDate",SqlDbType.DateTime),
							new SqlParameter("@Name",SqlDbType.VarChar),
							new SqlParameter("@NamePhonetic",SqlDbType.VarChar),
							new SqlParameter("@ChargeType",SqlDbType.VarChar),
							new SqlParameter("@Sex",SqlDbType.VarChar),
							new SqlParameter("@Age",SqlDbType.Decimal),
							new SqlParameter("@TestCause",SqlDbType.VarChar),
							new SqlParameter("@RelevantClinicDiag",SqlDbType.VarChar),
							new SqlParameter("@Specimen",SqlDbType.VarChar),
							new SqlParameter("@NotesForSpcm",SqlDbType.VarChar),
							new SqlParameter("@SpcmReceivedDateTime",SqlDbType.DateTime),
							new SqlParameter("@SpcmSampleDateTime",SqlDbType.DateTime),
							new SqlParameter("@RequestedDateTime",SqlDbType.DateTime),
							new SqlParameter("@OrderingDept",SqlDbType.VarChar),
							new SqlParameter("@OrderingProvider",SqlDbType.VarChar),
							new SqlParameter("@PerformedBy",SqlDbType.VarChar),
							new SqlParameter("@ResultStatus",SqlDbType.VarChar),
							new SqlParameter("@ResultsRptDateTime",SqlDbType.DateTime),
							new SqlParameter("@Transcriptionist",SqlDbType.VarChar),
							new SqlParameter("@VerifiedBy",SqlDbType.VarChar),
							new SqlParameter("@Costs",SqlDbType.Decimal),
							new SqlParameter("@Charges",SqlDbType.Decimal),
							new SqlParameter("@BillingIndicator",SqlDbType.Decimal),
							new SqlParameter("@PrintIndicator",SqlDbType.Decimal),
							new SqlParameter("@Subject",SqlDbType.VarChar),
							new SqlParameter("@Barcode",SqlDbType.VarChar),
							new SqlParameter("@TestNoP",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedLabTestMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TestNo",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedLabTestMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TestNo",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedLabTestMaster 
		///Insert Table MED_LAB_TEST_MASTER
		/// </summary>
		public int InsertMedLabTestMasterSQL(MedLabTestMaster model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedLabTestMaster");
					if (model.TestNo != null)
						oneInert[0].Value = model.TestNo;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.PriorityIndicator.ToString() != null)
						oneInert[1].Value = model.PriorityIndicator;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.PatientId != null)
						oneInert[2].Value = model.PatientId;
					else
						oneInert[2].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneInert[3].Value = model.VisitId;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.WorkingId != null)
						oneInert[4].Value = model.WorkingId;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.ExecuteDate > DateTime.MinValue)
						oneInert[5].Value = model.ExecuteDate;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.Name != null)
						oneInert[6].Value = model.Name;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.NamePhonetic != null)
						oneInert[7].Value = model.NamePhonetic;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.ChargeType != null)
						oneInert[8].Value = model.ChargeType;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Sex != null)
						oneInert[9].Value = model.Sex;
					else
						oneInert[9].Value = DBNull.Value;
                    if (model.Age.ToString() != null)
						oneInert[10].Value = model.Age;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.TestCause != null)
						oneInert[11].Value = model.TestCause;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.RelevantClinicDiag != null)
						oneInert[12].Value = model.RelevantClinicDiag;
					else
						oneInert[12].Value = DBNull.Value;
					if (model.Specimen != null)
						oneInert[13].Value = model.Specimen;
					else
						oneInert[13].Value = DBNull.Value;
					if (model.NotesForSpcm != null)
						oneInert[14].Value = model.NotesForSpcm;
					else
						oneInert[14].Value = DBNull.Value;
					if (model.SpcmReceivedDateTime > DateTime.MinValue)
						oneInert[15].Value = model.SpcmReceivedDateTime;
					else
						oneInert[15].Value = DBNull.Value;
					if (model.SpcmSampleDateTime > DateTime.MinValue)
						oneInert[16].Value = model.SpcmSampleDateTime;
					else
						oneInert[16].Value = DBNull.Value;
					if (model.RequestedDateTime > DateTime.MinValue)
						oneInert[17].Value = model.RequestedDateTime;
					else
						oneInert[17].Value = DBNull.Value;
					if (model.OrderingDept != null)
						oneInert[18].Value = model.OrderingDept;
					else
						oneInert[18].Value = DBNull.Value;
					if (model.OrderingProvider != null)
						oneInert[19].Value = model.OrderingProvider;
					else
						oneInert[19].Value = DBNull.Value;
					if (model.PerformedBy != null)
						oneInert[20].Value = model.PerformedBy;
					else
						oneInert[20].Value = DBNull.Value;
					if (model.ResultStatus != null)
						oneInert[21].Value = model.ResultStatus;
					else
						oneInert[21].Value = DBNull.Value;
					if (model.ResultsRptDateTime > DateTime.MinValue)
						oneInert[22].Value = model.ResultsRptDateTime;
					else
						oneInert[22].Value = DBNull.Value;
					if (model.Transcriptionist != null)
						oneInert[23].Value = model.Transcriptionist;
					else
						oneInert[23].Value = DBNull.Value;
					if (model.VerifiedBy != null)
						oneInert[24].Value = model.VerifiedBy;
					else
						oneInert[24].Value = DBNull.Value;
                    if (model.Costs.ToString() != null)
						oneInert[25].Value = model.Costs;
					else
						oneInert[25].Value = DBNull.Value;
                    if (model.Charges.ToString() != null)
						oneInert[26].Value = model.Charges;
					else
						oneInert[26].Value = DBNull.Value;
                    if (model.BillingIndicator.ToString() != null)
						oneInert[27].Value = model.BillingIndicator;
					else
						oneInert[27].Value = DBNull.Value;
                    if (model.PrintIndicator.ToString() != null)
						oneInert[28].Value = model.PrintIndicator;
					else
						oneInert[28].Value = DBNull.Value;
					if (model.Subject != null)
						oneInert[29].Value = model.Subject;
					else
						oneInert[29].Value = DBNull.Value;
					if (model.Barcode != null)
						oneInert[30].Value = model.Barcode;
					else
						oneInert[30].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_LAB_TEST_MASTER_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedLabTestMaster 
		///Update Table     MED_LAB_TEST_MASTER
		/// </summary>
		public int UpdateMedLabTestMasterSQL(MedLabTestMaster model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedLabTestMaster");
					if (model.TestNo != null)
						oneUpdate[0].Value = model.TestNo;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.PriorityIndicator.ToString() != null)
						oneUpdate[1].Value = model.PriorityIndicator;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[2].Value = model.PatientId;
					else
						oneUpdate[2].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneUpdate[3].Value = model.VisitId;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.WorkingId != null)
						oneUpdate[4].Value = model.WorkingId;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.ExecuteDate > DateTime.MinValue)
						oneUpdate[5].Value = model.ExecuteDate;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Name != null)
						oneUpdate[6].Value = model.Name;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.NamePhonetic != null)
						oneUpdate[7].Value = model.NamePhonetic;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.ChargeType != null)
						oneUpdate[8].Value = model.ChargeType;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Sex != null)
						oneUpdate[9].Value = model.Sex;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Age.ToString() != null)
						oneUpdate[10].Value = model.Age;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.TestCause != null)
						oneUpdate[11].Value = model.TestCause;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.RelevantClinicDiag != null)
						oneUpdate[12].Value = model.RelevantClinicDiag;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.Specimen != null)
						oneUpdate[13].Value = model.Specimen;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.NotesForSpcm != null)
						oneUpdate[14].Value = model.NotesForSpcm;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.SpcmReceivedDateTime > DateTime.MinValue)
						oneUpdate[15].Value = model.SpcmReceivedDateTime;
					else
						oneUpdate[15].Value = DBNull.Value;
					if (model.SpcmSampleDateTime > DateTime.MinValue)
						oneUpdate[16].Value = model.SpcmSampleDateTime;
					else
						oneUpdate[16].Value = DBNull.Value;
					if (model.RequestedDateTime > DateTime.MinValue)
						oneUpdate[17].Value = model.RequestedDateTime;
					else
						oneUpdate[17].Value = DBNull.Value;
					if (model.OrderingDept != null)
						oneUpdate[18].Value = model.OrderingDept;
					else
						oneUpdate[18].Value = DBNull.Value;
					if (model.OrderingProvider != null)
						oneUpdate[19].Value = model.OrderingProvider;
					else
						oneUpdate[19].Value = DBNull.Value;
					if (model.PerformedBy != null)
						oneUpdate[20].Value = model.PerformedBy;
					else
						oneUpdate[20].Value = DBNull.Value;
					if (model.ResultStatus != null)
						oneUpdate[21].Value = model.ResultStatus;
					else
						oneUpdate[21].Value = DBNull.Value;
					if (model.ResultsRptDateTime > DateTime.MinValue)
						oneUpdate[22].Value = model.ResultsRptDateTime;
					else
						oneUpdate[22].Value = DBNull.Value;
					if (model.Transcriptionist != null)
						oneUpdate[23].Value = model.Transcriptionist;
					else
						oneUpdate[23].Value = DBNull.Value;
					if (model.VerifiedBy != null)
						oneUpdate[24].Value = model.VerifiedBy;
					else
						oneUpdate[24].Value = DBNull.Value;
                    if (model.Costs.ToString() != null)
						oneUpdate[25].Value = model.Costs;
					else
						oneUpdate[25].Value = DBNull.Value;
                    if (model.Charges.ToString() != null)
						oneUpdate[26].Value = model.Charges;
					else
						oneUpdate[26].Value = DBNull.Value;
                    if (model.BillingIndicator.ToString() != null)
						oneUpdate[27].Value = model.BillingIndicator;
					else
						oneUpdate[27].Value = DBNull.Value;
                    if (model.PrintIndicator.ToString() != null)
						oneUpdate[28].Value = model.PrintIndicator;
					else
						oneUpdate[28].Value = DBNull.Value;
					if (model.Subject != null)
						oneUpdate[29].Value = model.Subject;
					else
						oneUpdate[29].Value = DBNull.Value;
					if (model.Barcode != null)
						oneUpdate[30].Value = model.Barcode;
					else
						oneUpdate[30].Value = DBNull.Value;
					if (model.TestNo != null)
						oneUpdate[31].Value =model.TestNo;
					else
						oneUpdate[31].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_LAB_TEST_MASTER_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedLabTestMaster 
		///Delete Table MED_LAB_TEST_MASTER by (string TEST_NO)
		/// </summary>
		public int DeleteMedLabTestMasterSQL(string TEST_NO)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedLabTestMaster");
					if (TEST_NO != null)
						oneDelete[0].Value =TEST_NO;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_LAB_TEST_MASTER_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedLabTestMaster 
		///select Table MED_LAB_TEST_MASTER by (string TEST_NO)
		/// </summary>
		public MedLabTestMaster  SelectMedLabTestMasterSQL(string TEST_NO)
		{
			MedLabTestMaster model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedLabTestMaster");
				parameterValues[0].Value=TEST_NO;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_LAB_TEST_MASTER_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedLabTestMaster();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PriorityIndicator = decimal.Parse(oleReader["PRIORITY_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.WorkingId = oleReader["WORKING_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.ExecuteDate = DateTime.Parse(oleReader["EXECUTE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Name = oleReader["NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.NamePhonetic = oleReader["NAME_PHONETIC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.ChargeType = oleReader["CHARGE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Sex = oleReader["SEX"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Age = decimal.Parse(oleReader["AGE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.TestCause = oleReader["TEST_CAUSE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.RelevantClinicDiag = oleReader["RELEVANT_CLINIC_DIAG"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Specimen = oleReader["SPECIMEN"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.NotesForSpcm = oleReader["NOTES_FOR_SPCM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SpcmReceivedDateTime = DateTime.Parse(oleReader["SPCM_RECEIVED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.SpcmSampleDateTime = DateTime.Parse(oleReader["SPCM_SAMPLE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.RequestedDateTime = DateTime.Parse(oleReader["REQUESTED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.OrderingDept = oleReader["ORDERING_DEPT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.OrderingProvider = oleReader["ORDERING_PROVIDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.ResultStatus = oleReader["RESULT_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.ResultsRptDateTime = DateTime.Parse(oleReader["RESULTS_RPT_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.Transcriptionist = oleReader["TRANSCRIPTIONIST"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.VerifiedBy = oleReader["VERIFIED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.BillingIndicator = decimal.Parse(oleReader["BILLING_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.PrintIndicator = decimal.Parse(oleReader["PRINT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.Subject = oleReader["SUBJECT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.Barcode = oleReader["BARCODE"].ToString().Trim() ;
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
		public List<MedLabTestMaster> SelectMedLabTestMasterListSQL()
		{
			List<MedLabTestMaster> modelList = new List<MedLabTestMaster>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_LAB_TEST_MASTER_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedLabTestMaster model = new MedLabTestMaster();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PriorityIndicator = decimal.Parse(oleReader["PRIORITY_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.WorkingId = oleReader["WORKING_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.ExecuteDate = DateTime.Parse(oleReader["EXECUTE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Name = oleReader["NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.NamePhonetic = oleReader["NAME_PHONETIC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.ChargeType = oleReader["CHARGE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Sex = oleReader["SEX"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Age = decimal.Parse(oleReader["AGE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.TestCause = oleReader["TEST_CAUSE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.RelevantClinicDiag = oleReader["RELEVANT_CLINIC_DIAG"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Specimen = oleReader["SPECIMEN"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.NotesForSpcm = oleReader["NOTES_FOR_SPCM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SpcmReceivedDateTime = DateTime.Parse(oleReader["SPCM_RECEIVED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.SpcmSampleDateTime = DateTime.Parse(oleReader["SPCM_SAMPLE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.RequestedDateTime = DateTime.Parse(oleReader["REQUESTED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.OrderingDept = oleReader["ORDERING_DEPT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.OrderingProvider = oleReader["ORDERING_PROVIDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.ResultStatus = oleReader["RESULT_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.ResultsRptDateTime = DateTime.Parse(oleReader["RESULTS_RPT_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.Transcriptionist = oleReader["TRANSCRIPTIONIST"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.VerifiedBy = oleReader["VERIFIED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.BillingIndicator = decimal.Parse(oleReader["BILLING_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.PrintIndicator = decimal.Parse(oleReader["PRINT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.Subject = oleReader["SUBJECT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.Barcode = oleReader["BARCODE"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedLabTestMaster
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedLabTestMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TestNo",OracleType.VarChar),
							new OracleParameter(":PriorityIndicator",OracleType.Number),
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":WorkingId",OracleType.VarChar),
							new OracleParameter(":ExecuteDate",OracleType.DateTime),
							new OracleParameter(":Name",OracleType.VarChar),
							new OracleParameter(":NamePhonetic",OracleType.VarChar),
							new OracleParameter(":ChargeType",OracleType.VarChar),
							new OracleParameter(":Sex",OracleType.VarChar),
							new OracleParameter(":Age",OracleType.Number),
							new OracleParameter(":TestCause",OracleType.VarChar),
							new OracleParameter(":RelevantClinicDiag",OracleType.VarChar),
							new OracleParameter(":Specimen",OracleType.VarChar),
							new OracleParameter(":NotesForSpcm",OracleType.VarChar),
							new OracleParameter(":SpcmReceivedDateTime",OracleType.DateTime),
							new OracleParameter(":SpcmSampleDateTime",OracleType.DateTime),
							new OracleParameter(":RequestedDateTime",OracleType.DateTime),
							new OracleParameter(":OrderingDept",OracleType.VarChar),
							new OracleParameter(":OrderingProvider",OracleType.VarChar),
							new OracleParameter(":PerformedBy",OracleType.VarChar),
							new OracleParameter(":ResultStatus",OracleType.VarChar),
							new OracleParameter(":ResultsRptDateTime",OracleType.DateTime),
							new OracleParameter(":Transcriptionist",OracleType.VarChar),
							new OracleParameter(":VerifiedBy",OracleType.VarChar),
							new OracleParameter(":Costs",OracleType.Number),
							new OracleParameter(":Charges",OracleType.Number),
							new OracleParameter(":BillingIndicator",OracleType.Number),
							new OracleParameter(":PrintIndicator",OracleType.Number),
							new OracleParameter(":Subject",OracleType.VarChar),
							new OracleParameter(":Barcode",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedLabTestMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TestNo",OracleType.VarChar),
							new OracleParameter(":PriorityIndicator",OracleType.Number),
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":WorkingId",OracleType.VarChar),
							new OracleParameter(":ExecuteDate",OracleType.DateTime),
							new OracleParameter(":Name",OracleType.VarChar),
							new OracleParameter(":NamePhonetic",OracleType.VarChar),
							new OracleParameter(":ChargeType",OracleType.VarChar),
							new OracleParameter(":Sex",OracleType.VarChar),
							new OracleParameter(":Age",OracleType.Number),
							new OracleParameter(":TestCause",OracleType.VarChar),
							new OracleParameter(":RelevantClinicDiag",OracleType.VarChar),
							new OracleParameter(":Specimen",OracleType.VarChar),
							new OracleParameter(":NotesForSpcm",OracleType.VarChar),
							new OracleParameter(":SpcmReceivedDateTime",OracleType.DateTime),
							new OracleParameter(":SpcmSampleDateTime",OracleType.DateTime),
							new OracleParameter(":RequestedDateTime",OracleType.DateTime),
							new OracleParameter(":OrderingDept",OracleType.VarChar),
							new OracleParameter(":OrderingProvider",OracleType.VarChar),
							new OracleParameter(":PerformedBy",OracleType.VarChar),
							new OracleParameter(":ResultStatus",OracleType.VarChar),
							new OracleParameter(":ResultsRptDateTime",OracleType.DateTime),
							new OracleParameter(":Transcriptionist",OracleType.VarChar),
							new OracleParameter(":VerifiedBy",OracleType.VarChar),
							new OracleParameter(":Costs",OracleType.Number),
							new OracleParameter(":Charges",OracleType.Number),
							new OracleParameter(":BillingIndicator",OracleType.Number),
							new OracleParameter(":PrintIndicator",OracleType.Number),
							new OracleParameter(":Subject",OracleType.VarChar),
							new OracleParameter(":Barcode",OracleType.VarChar),
							new OracleParameter(":TestNoP",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedLabTestMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TestNo",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedLabTestMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TestNo",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedLabTestMaster 
		///Insert Table MED_LAB_TEST_MASTER
		/// </summary>
		public int InsertMedLabTestMaster(MedLabTestMaster model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedLabTestMaster");
					if (model.TestNo != null)
						oneInert[0].Value = model.TestNo;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.PriorityIndicator.ToString() != null)
						oneInert[1].Value = model.PriorityIndicator;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.PatientId != null)
						oneInert[2].Value = model.PatientId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneInert[3].Value = model.VisitId;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.WorkingId != null)
						oneInert[4].Value = model.WorkingId;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.ExecuteDate > DateTime.MinValue)
						oneInert[5].Value = model.ExecuteDate;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.Name != null)
						oneInert[6].Value = model.Name;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.NamePhonetic != null)
						oneInert[7].Value = model.NamePhonetic;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.ChargeType != null)
						oneInert[8].Value = model.ChargeType;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Sex != null)
						oneInert[9].Value = model.Sex;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Age.ToString() != null)
						oneInert[10].Value = model.Age;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.TestCause != null)
						oneInert[11].Value = model.TestCause;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.RelevantClinicDiag != null)
						oneInert[12].Value = model.RelevantClinicDiag;
					else
						oneInert[12].Value = DBNull.Value;
					if (model.Specimen != null)
						oneInert[13].Value = model.Specimen;
					else
						oneInert[13].Value = DBNull.Value;
					if (model.NotesForSpcm != null)
						oneInert[14].Value = model.NotesForSpcm;
					else
						oneInert[14].Value = DBNull.Value;
					if (model.SpcmReceivedDateTime > DateTime.MinValue)
						oneInert[15].Value = model.SpcmReceivedDateTime;
					else
						oneInert[15].Value = DBNull.Value;
					if (model.SpcmSampleDateTime > DateTime.MinValue)
						oneInert[16].Value = model.SpcmSampleDateTime;
					else
						oneInert[16].Value = DBNull.Value;
					if (model.RequestedDateTime > DateTime.MinValue)
						oneInert[17].Value = model.RequestedDateTime;
					else
						oneInert[17].Value = DBNull.Value;
					if (model.OrderingDept != null)
						oneInert[18].Value = model.OrderingDept;
					else
						oneInert[18].Value = DBNull.Value;
					if (model.OrderingProvider != null)
						oneInert[19].Value = model.OrderingProvider;
					else
						oneInert[19].Value = DBNull.Value;
					if (model.PerformedBy != null)
						oneInert[20].Value = model.PerformedBy;
					else
						oneInert[20].Value = DBNull.Value;
					if (model.ResultStatus != null)
						oneInert[21].Value = model.ResultStatus;
					else
						oneInert[21].Value = DBNull.Value;
					if (model.ResultsRptDateTime > DateTime.MinValue)
						oneInert[22].Value = model.ResultsRptDateTime;
					else
						oneInert[22].Value = DBNull.Value;
					if (model.Transcriptionist != null)
						oneInert[23].Value = model.Transcriptionist;
					else
						oneInert[23].Value = DBNull.Value;
					if (model.VerifiedBy != null)
						oneInert[24].Value = model.VerifiedBy;
					else
						oneInert[24].Value = DBNull.Value;
                    if (model.Costs.ToString() != null)
						oneInert[25].Value = model.Costs;
					else
						oneInert[25].Value = DBNull.Value;
                    if (model.Charges.ToString() != null)
						oneInert[26].Value = model.Charges;
					else
						oneInert[26].Value = DBNull.Value;
                    if (model.BillingIndicator.ToString() != null)
						oneInert[27].Value = model.BillingIndicator;
					else
						oneInert[27].Value = DBNull.Value;
                    if (model.PrintIndicator.ToString() != null)
						oneInert[28].Value = model.PrintIndicator;
					else
						oneInert[28].Value = DBNull.Value;
					if (model.Subject != null)
						oneInert[29].Value = model.Subject;
					else
						oneInert[29].Value = DBNull.Value;
					if (model.Barcode != null)
						oneInert[30].Value = model.Barcode;
					else
						oneInert[30].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_LAB_TEST_MASTER_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedLabTestMaster 
		///Update Table     MED_LAB_TEST_MASTER
		/// </summary>
		public int UpdateMedLabTestMaster(MedLabTestMaster model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedLabTestMaster");
					if (model.TestNo != null)
						oneUpdate[0].Value = model.TestNo;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.PriorityIndicator.ToString() != null)
						oneUpdate[1].Value = model.PriorityIndicator;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[2].Value = model.PatientId;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[3].Value = model.VisitId;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.WorkingId != null)
						oneUpdate[4].Value = model.WorkingId;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.ExecuteDate > DateTime.MinValue)
						oneUpdate[5].Value = model.ExecuteDate;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Name != null)
						oneUpdate[6].Value = model.Name;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.NamePhonetic != null)
						oneUpdate[7].Value = model.NamePhonetic;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.ChargeType != null)
						oneUpdate[8].Value = model.ChargeType;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Sex != null)
						oneUpdate[9].Value = model.Sex;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Age.ToString() != null)
						oneUpdate[10].Value = model.Age;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.TestCause != null)
						oneUpdate[11].Value = model.TestCause;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.RelevantClinicDiag != null)
						oneUpdate[12].Value = model.RelevantClinicDiag;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.Specimen != null)
						oneUpdate[13].Value = model.Specimen;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.NotesForSpcm != null)
						oneUpdate[14].Value = model.NotesForSpcm;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.SpcmReceivedDateTime > DateTime.MinValue)
						oneUpdate[15].Value = model.SpcmReceivedDateTime;
					else
						oneUpdate[15].Value = DBNull.Value;
					if (model.SpcmSampleDateTime > DateTime.MinValue)
						oneUpdate[16].Value = model.SpcmSampleDateTime;
					else
						oneUpdate[16].Value = DBNull.Value;
					if (model.RequestedDateTime > DateTime.MinValue)
						oneUpdate[17].Value = model.RequestedDateTime;
					else
						oneUpdate[17].Value = DBNull.Value;
					if (model.OrderingDept != null)
						oneUpdate[18].Value = model.OrderingDept;
					else
						oneUpdate[18].Value = DBNull.Value;
					if (model.OrderingProvider != null)
						oneUpdate[19].Value = model.OrderingProvider;
					else
						oneUpdate[19].Value = DBNull.Value;
					if (model.PerformedBy != null)
						oneUpdate[20].Value = model.PerformedBy;
					else
						oneUpdate[20].Value = DBNull.Value;
					if (model.ResultStatus != null)
						oneUpdate[21].Value = model.ResultStatus;
					else
						oneUpdate[21].Value = DBNull.Value;
					if (model.ResultsRptDateTime > DateTime.MinValue)
						oneUpdate[22].Value = model.ResultsRptDateTime;
					else
						oneUpdate[22].Value = DBNull.Value;
					if (model.Transcriptionist != null)
						oneUpdate[23].Value = model.Transcriptionist;
					else
						oneUpdate[23].Value = DBNull.Value;
					if (model.VerifiedBy != null)
						oneUpdate[24].Value = model.VerifiedBy;
					else
						oneUpdate[24].Value = DBNull.Value;
                    if (model.Costs.ToString() != null)
						oneUpdate[25].Value = model.Costs;
					else
						oneUpdate[25].Value = DBNull.Value;
                    if (model.Charges.ToString() != null)
						oneUpdate[26].Value = model.Charges;
					else
						oneUpdate[26].Value = DBNull.Value;
                    if (model.BillingIndicator.ToString() != null)
						oneUpdate[27].Value = model.BillingIndicator;
					else
						oneUpdate[27].Value = DBNull.Value;
                    if (model.PrintIndicator.ToString() != null)
						oneUpdate[28].Value = model.PrintIndicator;
					else
						oneUpdate[28].Value = DBNull.Value;
					if (model.Subject != null)
						oneUpdate[29].Value = model.Subject;
					else
						oneUpdate[29].Value = DBNull.Value;
					if (model.Barcode != null)
						oneUpdate[30].Value = model.Barcode;
					else
						oneUpdate[30].Value = DBNull.Value;
					if (model.TestNo != null)
						oneUpdate[31].Value =model.TestNo;
					else
						oneUpdate[31].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_LAB_TEST_MASTER_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedLabTestMaster 
		///Delete Table MED_LAB_TEST_MASTER by (string TEST_NO)
		/// </summary>
		public int DeleteMedLabTestMaster(string TEST_NO)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedLabTestMaster");
					if (TEST_NO != null)
						oneDelete[0].Value =TEST_NO;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_LAB_TEST_MASTER_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedLabTestMaster 
		///select Table MED_LAB_TEST_MASTER by (string TEST_NO)
		/// </summary>
		public MedLabTestMaster  SelectMedLabTestMaster(string TEST_NO)
		{
			MedLabTestMaster model;
			OracleParameter[] parameterValues = GetParameter("SelectMedLabTestMaster");
				parameterValues[0].Value=TEST_NO;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_LAB_TEST_MASTER_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedLabTestMaster();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PriorityIndicator = decimal.Parse(oleReader["PRIORITY_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.WorkingId = oleReader["WORKING_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.ExecuteDate = DateTime.Parse(oleReader["EXECUTE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Name = oleReader["NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.NamePhonetic = oleReader["NAME_PHONETIC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.ChargeType = oleReader["CHARGE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Sex = oleReader["SEX"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Age = decimal.Parse(oleReader["AGE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.TestCause = oleReader["TEST_CAUSE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.RelevantClinicDiag = oleReader["RELEVANT_CLINIC_DIAG"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Specimen = oleReader["SPECIMEN"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.NotesForSpcm = oleReader["NOTES_FOR_SPCM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SpcmReceivedDateTime = DateTime.Parse(oleReader["SPCM_RECEIVED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.SpcmSampleDateTime = DateTime.Parse(oleReader["SPCM_SAMPLE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.RequestedDateTime = DateTime.Parse(oleReader["REQUESTED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.OrderingDept = oleReader["ORDERING_DEPT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.OrderingProvider = oleReader["ORDERING_PROVIDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.ResultStatus = oleReader["RESULT_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.ResultsRptDateTime = DateTime.Parse(oleReader["RESULTS_RPT_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.Transcriptionist = oleReader["TRANSCRIPTIONIST"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.VerifiedBy = oleReader["VERIFIED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.BillingIndicator = decimal.Parse(oleReader["BILLING_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.PrintIndicator = decimal.Parse(oleReader["PRINT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.Subject = oleReader["SUBJECT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.Barcode = oleReader["BARCODE"].ToString().Trim() ;
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
		public List<MedLabTestMaster> SelectMedLabTestMasterList()
		{
			List<MedLabTestMaster> modelList = new List<MedLabTestMaster>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_LAB_TEST_MASTER_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedLabTestMaster model = new MedLabTestMaster();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PriorityIndicator = decimal.Parse(oleReader["PRIORITY_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.WorkingId = oleReader["WORKING_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.ExecuteDate = DateTime.Parse(oleReader["EXECUTE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Name = oleReader["NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.NamePhonetic = oleReader["NAME_PHONETIC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.ChargeType = oleReader["CHARGE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Sex = oleReader["SEX"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Age = decimal.Parse(oleReader["AGE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.TestCause = oleReader["TEST_CAUSE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.RelevantClinicDiag = oleReader["RELEVANT_CLINIC_DIAG"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Specimen = oleReader["SPECIMEN"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.NotesForSpcm = oleReader["NOTES_FOR_SPCM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SpcmReceivedDateTime = DateTime.Parse(oleReader["SPCM_RECEIVED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.SpcmSampleDateTime = DateTime.Parse(oleReader["SPCM_SAMPLE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.RequestedDateTime = DateTime.Parse(oleReader["REQUESTED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.OrderingDept = oleReader["ORDERING_DEPT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.OrderingProvider = oleReader["ORDERING_PROVIDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.ResultStatus = oleReader["RESULT_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.ResultsRptDateTime = DateTime.Parse(oleReader["RESULTS_RPT_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.Transcriptionist = oleReader["TRANSCRIPTIONIST"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.VerifiedBy = oleReader["VERIFIED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.BillingIndicator = decimal.Parse(oleReader["BILLING_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.PrintIndicator = decimal.Parse(oleReader["PRINT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.Subject = oleReader["SUBJECT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.Barcode = oleReader["BARCODE"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
