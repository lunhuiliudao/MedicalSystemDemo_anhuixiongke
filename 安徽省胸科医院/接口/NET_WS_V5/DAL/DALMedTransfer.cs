

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:55
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
	/// DAL MedTransfer
	/// </summary>
	
	public partial class DALMedTransfer
	{
		
		private static readonly string MED_TRANSFER_Insert_SQL = "INSERT INTO MED_TRANSFER (PATIENT_ID,VISIT_ID,DEPT_STAYED,ADMISSION_DATE_TIME,DISCHARGE_DATE_TIME,DEPT_TRANSFERED_TO,DOCTOR_IN_CHARGE,WARD_STAYED,WARD_TRANSFERED_TO,RESERVED1,BED_NO,RESERVED2,RESERVED3) values (@PatientId,@VisitId,@DeptStayed,@AdmissionDateTime,@DischargeDateTime,@DeptTransferedTo,@DoctorInCharge,@WardStayed,@WardTransferedTo,@Reserved1,@BedNo,@Reserved2,@Reserved3)";
        private static readonly string MED_TRANSFER_Update_SQL = "UPDATE MED_TRANSFER SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,DEPT_STAYED=@DeptStayed,ADMISSION_DATE_TIME=@AdmissionDateTime,DISCHARGE_DATE_TIME=@DischargeDateTime,DEPT_TRANSFERED_TO=@DeptTransferedTo,DOCTOR_IN_CHARGE=@DoctorInCharge,WARD_STAYED=@WardStayed,WARD_TRANSFERED_TO=@WardTransferedTo,RESERVED1=@Reserved1,BED_NO=@BedNo,RESERVED2=@Reserved2,RESERVED3=@Reserved3 WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND ADMISSION_DATE_TIME=@AdmissionDateTime";
        private static readonly string MED_TRANSFER_Delete_SQL = "Delete MED_TRANSFER WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND ADMISSION_DATE_TIME=@AdmissionDateTime";
        private static readonly string MED_TRANSFER_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,DEPT_STAYED,ADMISSION_DATE_TIME,DISCHARGE_DATE_TIME,DEPT_TRANSFERED_TO,DOCTOR_IN_CHARGE,WARD_STAYED,WARD_TRANSFERED_TO,RESERVED1,BED_NO,RESERVED2,RESERVED3 FROM MED_TRANSFER where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND ADMISSION_DATE_TIME=@AdmissionDateTime";
		private static readonly string MED_TRANSFER_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,DEPT_STAYED,ADMISSION_DATE_TIME,DISCHARGE_DATE_TIME,DEPT_TRANSFERED_TO,DOCTOR_IN_CHARGE,WARD_STAYED,WARD_TRANSFERED_TO,RESERVED1,BED_NO,RESERVED2,RESERVED3 FROM MED_TRANSFER";
        private static readonly string MED_TRANSFER_Select_Max_Re2_SQL = "SELECT isnull(max(RESERVED2),0) FROM MED_TRANSFER where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND DEPT_STAYED=@deptStayed";
        private static readonly string MED_TRANSFER_Insert = "INSERT INTO MED_TRANSFER (PATIENT_ID,VISIT_ID,DEPT_STAYED,ADMISSION_DATE_TIME,DISCHARGE_DATE_TIME,DEPT_TRANSFERED_TO,DOCTOR_IN_CHARGE,WARD_STAYED,WARD_TRANSFERED_TO,RESERVED1,BED_NO,RESERVED2,RESERVED3) values (:PatientId,:VisitId,:DeptStayed,:AdmissionDateTime,:DischargeDateTime,:DeptTransferedTo,:DoctorInCharge,:WardStayed,:WardTransferedTo,:Reserved1,:BedNo,:Reserved2,:Reserved3)";
        private static readonly string MED_TRANSFER_Update = "UPDATE MED_TRANSFER SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,DEPT_STAYED=:DeptStayed,ADMISSION_DATE_TIME=:AdmissionDateTime,DISCHARGE_DATE_TIME=:DischargeDateTime,DEPT_TRANSFERED_TO=:DeptTransferedTo,DOCTOR_IN_CHARGE=:DoctorInCharge,WARD_STAYED=:WardStayed,WARD_TRANSFERED_TO=:WardTransferedTo,RESERVED1=:Reserved1,BED_NO=:BedNo,RESERVED2=:Reserved2,RESERVED3=:Reserved3 WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND ADMISSION_DATE_TIME=:AdmissionDateTime";
        private static readonly string MED_TRANSFER_Delete = "Delete MED_TRANSFER WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND ADMISSION_DATE_TIME=:AdmissionDateTime";
        private static readonly string MED_TRANSFER_Select = "SELECT PATIENT_ID,VISIT_ID,DEPT_STAYED,ADMISSION_DATE_TIME,DISCHARGE_DATE_TIME,DEPT_TRANSFERED_TO,DOCTOR_IN_CHARGE,WARD_STAYED,WARD_TRANSFERED_TO,RESERVED1,BED_NO,RESERVED2,RESERVED3 FROM MED_TRANSFER where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND ADMISSION_DATE_TIME=:AdmissionDateTime";
		private static readonly string MED_TRANSFER_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,DEPT_STAYED,ADMISSION_DATE_TIME,DISCHARGE_DATE_TIME,DEPT_TRANSFERED_TO,DOCTOR_IN_CHARGE,WARD_STAYED,WARD_TRANSFERED_TO,RESERVED1,BED_NO,RESERVED2,RESERVED3 FROM MED_TRANSFER";
        private static readonly string MED_TRANSFER_Select_Max_Re2 = "SELECT nvl(max(RESERVED2),0) FROM MED_TRANSFER where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND DEPT_STAYED=:deptStayed";
        
        public DALMedTransfer ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedTransfer SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedTransfer")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@DeptStayed",SqlDbType.VarChar),
							new SqlParameter("@AdmissionDateTime",SqlDbType.DateTime),
							new SqlParameter("@DischargeDateTime",SqlDbType.DateTime),
							new SqlParameter("@DeptTransferedTo",SqlDbType.VarChar),
							new SqlParameter("@DoctorInCharge",SqlDbType.VarChar),
							new SqlParameter("@WardStayed",SqlDbType.VarChar),
							new SqlParameter("@WardTransferedTo",SqlDbType.VarChar),
							new SqlParameter("@Reserved1",SqlDbType.Decimal),
							new SqlParameter("@BedNo",SqlDbType.VarChar),
							new SqlParameter("@Reserved2",SqlDbType.Decimal),
							new SqlParameter("@Reserved3",SqlDbType.DateTime),
                    };
                }
				else if (sqlParms == "UpdateMedTransfer")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@DeptStayed",SqlDbType.VarChar),
							new SqlParameter("@AdmissionDateTime",SqlDbType.DateTime),
							new SqlParameter("@DischargeDateTime",SqlDbType.DateTime),
							new SqlParameter("@DeptTransferedTo",SqlDbType.VarChar),
							new SqlParameter("@DoctorInCharge",SqlDbType.VarChar),
							new SqlParameter("@WardStayed",SqlDbType.VarChar),
							new SqlParameter("@WardTransferedTo",SqlDbType.VarChar),
							new SqlParameter("@Reserved1",SqlDbType.Decimal),
							new SqlParameter("@BedNo",SqlDbType.VarChar),
							new SqlParameter("@Reserved2",SqlDbType.Decimal),
							new SqlParameter("@Reserved3",SqlDbType.DateTime),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@AdmissionDateTime",SqlDbType.DateTime),
                    };
                }
				else if(sqlParms == "DeleteMedTransfer")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@AdmissionDateTime",SqlDbType.DateTime),
                    };
                }
				else if(sqlParms == "SelectMedTransfer")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@AdmissionDateTime",SqlDbType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMaxTransferRe2")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@deptStayed",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedTransfer 
		///Insert Table MED_TRANSFER
		/// </summary>
		public int InsertMedTransferSQL(MedTransfer model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedTransfer");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.DeptStayed != null)
						oneInert[2].Value = model.DeptStayed;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.AdmissionDateTime > DateTime.MinValue)
						oneInert[3].Value = model.AdmissionDateTime;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.DischargeDateTime > DateTime.MinValue)
						oneInert[4].Value = model.DischargeDateTime;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.DeptTransferedTo != null)
						oneInert[5].Value = model.DeptTransferedTo;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.DoctorInCharge != null)
						oneInert[6].Value = model.DoctorInCharge;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.WardStayed != null)
						oneInert[7].Value = model.WardStayed;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.WardTransferedTo != null)
						oneInert[8].Value = model.WardTransferedTo;
					else
						oneInert[8].Value = DBNull.Value;
                    if (model.Reserved1.ToString() != null)
						oneInert[9].Value = model.Reserved1;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.BedNo != null)
						oneInert[10].Value = model.BedNo;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.Reserved2.ToString() != null)
						oneInert[11].Value = model.Reserved2;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneInert[12].Value = model.Reserved3;
					else
						oneInert[12].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_TRANSFER_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedTransfer 
		///Update Table     MED_TRANSFER
		/// </summary>
		public int UpdateMedTransferSQL(MedTransfer model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedTransfer");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.DeptStayed != null)
						oneUpdate[2].Value = model.DeptStayed;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.AdmissionDateTime > DateTime.MinValue)
						oneUpdate[3].Value = model.AdmissionDateTime;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.DischargeDateTime > DateTime.MinValue)
						oneUpdate[4].Value = model.DischargeDateTime;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.DeptTransferedTo != null)
						oneUpdate[5].Value = model.DeptTransferedTo;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.DoctorInCharge != null)
						oneUpdate[6].Value = model.DoctorInCharge;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.WardStayed != null)
						oneUpdate[7].Value = model.WardStayed;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.WardTransferedTo != null)
						oneUpdate[8].Value = model.WardTransferedTo;
					else
						oneUpdate[8].Value = DBNull.Value;
                    if (model.Reserved1.ToString() != null)
						oneUpdate[9].Value = model.Reserved1;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.BedNo != null)
						oneUpdate[10].Value = model.BedNo;
					else
						oneUpdate[10].Value = DBNull.Value;
                    if (model.Reserved2.ToString() != null)
						oneUpdate[11].Value = model.Reserved2;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneUpdate[12].Value = model.Reserved3;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[13].Value =model.PatientId;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[14].Value =model.VisitId;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.AdmissionDateTime > DateTime.MinValue)
						oneUpdate[15].Value =model.AdmissionDateTime;
					else
						oneUpdate[15].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_TRANSFER_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedTransfer 
		///Delete Table MED_TRANSFER by (string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		/// </summary>
		public int DeleteMedTransferSQL(string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedTransfer");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
					if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
					if (ADMISSION_DATE_TIME != null)
						oneDelete[2].Value =ADMISSION_DATE_TIME;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_TRANSFER_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedTransfer 
		///select Table MED_TRANSFER by (string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		/// </summary>
		public MedTransfer  SelectMedTransferSQL(string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		{
			MedTransfer model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedTransfer");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=ADMISSION_DATE_TIME;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_TRANSFER_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedTransfer();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.DeptStayed = oleReader["DEPT_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.DischargeDateTime = DateTime.Parse(oleReader["DISCHARGE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.DeptTransferedTo = oleReader["DEPT_TRANSFERED_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.WardStayed = oleReader["WARD_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.WardTransferedTo = oleReader["WARD_TRANSFERED_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved1 = decimal.Parse(oleReader["RESERVED1"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.BedNo = oleReader["BED_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved2 = decimal.Parse(oleReader["RESERVED2"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved3 = DateTime.Parse(oleReader["RESERVED3"].ToString().Trim()) ;
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
		public List<MedTransfer> SelectMedTransferListSQL()
		{
			List<MedTransfer> modelList = new List<MedTransfer>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_TRANSFER_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedTransfer model = new MedTransfer();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.DeptStayed = oleReader["DEPT_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.DischargeDateTime = DateTime.Parse(oleReader["DISCHARGE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.DeptTransferedTo = oleReader["DEPT_TRANSFERED_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.WardStayed = oleReader["WARD_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.WardTransferedTo = oleReader["WARD_TRANSFERED_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved1 = decimal.Parse(oleReader["RESERVED1"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.BedNo = oleReader["BED_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved2 = decimal.Parse(oleReader["RESERVED2"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved3 = DateTime.Parse(oleReader["RESERVED3"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
        public int SelectMaxTransferRe2SQL(string patientId, decimal visitId,string deptStayed)
        {
            SqlParameter[] medMaxTransferRe2 = GetParameterSQL("SelectMaxTransferRe2");
            medMaxTransferRe2[0].Value = patientId;
            medMaxTransferRe2[1].Value = visitId;
            medMaxTransferRe2[2].Value = deptStayed;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_TRANSFER_Select_Max_Re2_SQL, medMaxTransferRe2))
            {
                if (oleReader.Read())
                {
                    return Convert.ToInt32(oleReader[0]);
                }
                else
                {
                    return 0;
                }
            }
        }

		#region [获取参数]
		/// <summary>
		///获取参数MedTransfer
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedTransfer")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":DeptStayed",OracleType.VarChar),
							new OracleParameter(":AdmissionDateTime",OracleType.DateTime),
							new OracleParameter(":DischargeDateTime",OracleType.DateTime),
							new OracleParameter(":DeptTransferedTo",OracleType.VarChar),
							new OracleParameter(":DoctorInCharge",OracleType.VarChar),
							new OracleParameter(":WardStayed",OracleType.VarChar),
							new OracleParameter(":WardTransferedTo",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.Number),
							new OracleParameter(":BedNo",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.Number),
							new OracleParameter(":Reserved3",OracleType.DateTime),
                    };
                }
				else if (sqlParms == "UpdateMedTransfer")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":DeptStayed",OracleType.VarChar),
							new OracleParameter(":AdmissionDateTime",OracleType.DateTime),
							new OracleParameter(":DischargeDateTime",OracleType.DateTime),
							new OracleParameter(":DeptTransferedTo",OracleType.VarChar),
							new OracleParameter(":DoctorInCharge",OracleType.VarChar),
							new OracleParameter(":WardStayed",OracleType.VarChar),
							new OracleParameter(":WardTransferedTo",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.Number),
							new OracleParameter(":BedNo",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.Number),
							new OracleParameter(":Reserved3",OracleType.DateTime),
							new OracleParameter(":PatientId",SqlDbType.VarChar),
							new OracleParameter(":VisitId",SqlDbType.Decimal),
							new OracleParameter(":AdmissionDateTime",SqlDbType.DateTime),
                    };
                }
				else if(sqlParms == "DeleteMedTransfer")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":AdmissionDateTime",OracleType.DateTime),
                    };
                }
				else if(sqlParms == "SelectMedTransfer")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":AdmissionDateTime",OracleType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMaxTransferRe2")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":deptStayed",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedTransfer 
		///Insert Table MED_TRANSFER
		/// </summary>
		public int InsertMedTransfer(MedTransfer model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedTransfer");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.DeptStayed != null)
						oneInert[2].Value = model.DeptStayed;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.AdmissionDateTime > DateTime.MinValue)
						oneInert[3].Value = model.AdmissionDateTime;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.DischargeDateTime > DateTime.MinValue)
						oneInert[4].Value = model.DischargeDateTime;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.DeptTransferedTo != null)
						oneInert[5].Value = model.DeptTransferedTo;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.DoctorInCharge != null)
						oneInert[6].Value = model.DoctorInCharge;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.WardStayed != null)
						oneInert[7].Value = model.WardStayed;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.WardTransferedTo != null)
						oneInert[8].Value = model.WardTransferedTo;
					else
						oneInert[8].Value = DBNull.Value;
                    if (model.Reserved1.ToString() != null)
						oneInert[9].Value = model.Reserved1;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.BedNo != null)
						oneInert[10].Value = model.BedNo;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.Reserved2.ToString() != null)
						oneInert[11].Value = model.Reserved2;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneInert[12].Value = model.Reserved3;
					else
						oneInert[12].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_TRANSFER_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedTransfer 
		///Update Table     MED_TRANSFER
		/// </summary>
		public int UpdateMedTransfer(MedTransfer model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedTransfer");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.DeptStayed != null)
						oneUpdate[2].Value = model.DeptStayed;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.AdmissionDateTime > DateTime.MinValue)
						oneUpdate[3].Value = model.AdmissionDateTime;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.DischargeDateTime > DateTime.MinValue)
						oneUpdate[4].Value = model.DischargeDateTime;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.DeptTransferedTo != null)
						oneUpdate[5].Value = model.DeptTransferedTo;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.DoctorInCharge != null)
						oneUpdate[6].Value = model.DoctorInCharge;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.WardStayed != null)
						oneUpdate[7].Value = model.WardStayed;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.WardTransferedTo != null)
						oneUpdate[8].Value = model.WardTransferedTo;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Reserved1.ToString() != null)
						oneUpdate[9].Value = model.Reserved1;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.BedNo != null)
						oneUpdate[10].Value = model.BedNo;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.Reserved2.ToString() != null)
						oneUpdate[11].Value = model.Reserved2;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.Reserved3 > DateTime.MinValue)
						oneUpdate[12].Value = model.Reserved3;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[13].Value =model.PatientId;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[14].Value =model.VisitId;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.AdmissionDateTime > DateTime.MinValue)
						oneUpdate[15].Value =model.AdmissionDateTime;
					else
						oneUpdate[15].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_TRANSFER_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedTransfer 
		///Delete Table MED_TRANSFER by (string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		/// </summary>
		public int DeleteMedTransfer(string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedTransfer");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
					if (ADMISSION_DATE_TIME > DateTime.MinValue)
						oneDelete[2].Value =ADMISSION_DATE_TIME;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_TRANSFER_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedTransfer 
		///select Table MED_TRANSFER by (string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		/// </summary>
		public MedTransfer  SelectMedTransfer(string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		{
			MedTransfer model;
			OracleParameter[] parameterValues = GetParameter("SelectMedTransfer");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=ADMISSION_DATE_TIME;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_TRANSFER_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedTransfer();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.DeptStayed = oleReader["DEPT_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.DischargeDateTime = DateTime.Parse(oleReader["DISCHARGE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.DeptTransferedTo = oleReader["DEPT_TRANSFERED_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.WardStayed = oleReader["WARD_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.WardTransferedTo = oleReader["WARD_TRANSFERED_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved1 = decimal.Parse(oleReader["RESERVED1"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.BedNo = oleReader["BED_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved2 = decimal.Parse(oleReader["RESERVED2"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved3 = DateTime.Parse(oleReader["RESERVED3"].ToString().Trim()) ;
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
		public List<MedTransfer> SelectMedTransferList()
		{
			List<MedTransfer> modelList = new List<MedTransfer>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_TRANSFER_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedTransfer model = new MedTransfer();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.DeptStayed = oleReader["DEPT_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.DischargeDateTime = DateTime.Parse(oleReader["DISCHARGE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.DeptTransferedTo = oleReader["DEPT_TRANSFERED_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.WardStayed = oleReader["WARD_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.WardTransferedTo = oleReader["WARD_TRANSFERED_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved1 = decimal.Parse(oleReader["RESERVED1"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.BedNo = oleReader["BED_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved2 = decimal.Parse(oleReader["RESERVED2"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved3 = DateTime.Parse(oleReader["RESERVED3"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	

        public int SelectMaxTransferRe2(string patientId, decimal visitId, string deptStayed)
        {
            OracleParameter[] medMaxTransferRe2 = GetParameter("SelectMaxTransferRe2");
            medMaxTransferRe2[0].Value = patientId;
            medMaxTransferRe2[1].Value = visitId;
            medMaxTransferRe2[2].Value = deptStayed;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_TRANSFER_Select_Max_Re2, medMaxTransferRe2))
            {
                if (oleReader.Read())
                {
                    return (int)oleReader.GetDecimal(0);
                }
                else
                {
                    return 0;
                }
            }
        }
	}
}
