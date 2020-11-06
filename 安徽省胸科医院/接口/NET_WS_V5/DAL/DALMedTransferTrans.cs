

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
		
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedTransfer 
		///Insert Table MED_TRANSFER
		/// </summary>
        public int InsertMedTransferSQL(MedTransfer model, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_TRANSFER_Insert_SQL, oneInert);
			
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedTransfer 
		///Update Table     MED_TRANSFER
		/// </summary>
        public int UpdateMedTransferSQL(MedTransfer model, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_TRANSFER_Update_SQL, oneUpdate);
			
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedTransfer 
		///Delete Table MED_TRANSFER by (string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		/// </summary>
        public int DeleteMedTransferSQL(string PATIENT_ID, decimal VISIT_ID, DateTime ADMISSION_DATE_TIME, System.Data.Common.DbTransaction oleCisTrans)
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
			
			return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans,CommandType.Text, MED_TRANSFER_Delete_SQL, oneDelete);
			
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedTransfer 
		///select Table MED_TRANSFER by (string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		/// </summary>
        public MedTransfer SelectMedTransferSQL(string PATIENT_ID, decimal VISIT_ID, DateTime ADMISSION_DATE_TIME, System.Data.Common.DbConnection oleCisConn)
		{
			MedTransfer model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedTransfer");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=ADMISSION_DATE_TIME;
                using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_TRANSFER_Select_SQL, parameterValues))
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
		public List<MedTransfer> SelectMedTransferListSQL( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedTransfer> modelList = new List<MedTransfer>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_TRANSFER_Select_ALL_SQL, null))
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
		
        public int SelectMaxTransferRe2SQL(string patientId, decimal visitId, string deptStayed, System.Data.Common.DbConnection oleCisConn)
        {
            SqlParameter[] medMaxTransferRe2 = GetParameterSQL("SelectMaxTransferRe2");
            medMaxTransferRe2[0].Value = patientId;
            medMaxTransferRe2[1].Value = visitId;
            medMaxTransferRe2[2].Value = deptStayed;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_TRANSFER_Select_Max_Re2_SQL, medMaxTransferRe2))
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

		#region [添加一条记录]
		/// <summary>
		///Add    model  MedTransfer 
		///Insert Table MED_TRANSFER
		/// </summary>
        public int InsertMedTransfer(MedTransfer model, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_TRANSFER_Insert, oneInert);

		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedTransfer 
		///Update Table     MED_TRANSFER
		/// </summary>
        public int UpdateMedTransfer(MedTransfer model, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_TRANSFER_Update, oneUpdate);
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedTransfer 
		///Delete Table MED_TRANSFER by (string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		/// </summary>
        public int DeleteMedTransfer(string PATIENT_ID, decimal VISIT_ID, DateTime ADMISSION_DATE_TIME, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_TRANSFER_Delete, oneDelete);
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedTransfer 
		///select Table MED_TRANSFER by (string PATIENT_ID,decimal VISIT_ID,DateTime ADMISSION_DATE_TIME)
		/// </summary>
        public MedTransfer SelectMedTransfer(string PATIENT_ID, decimal VISIT_ID, DateTime ADMISSION_DATE_TIME, System.Data.Common.DbConnection oleCisConn)
		{
			MedTransfer model;
			OracleParameter[] parameterValues = GetParameter("SelectMedTransfer");
			parameterValues[0].Value=PATIENT_ID;
			parameterValues[1].Value=VISIT_ID;
			parameterValues[2].Value=ADMISSION_DATE_TIME;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_TRANSFER_Select, parameterValues))
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
		public List<MedTransfer> SelectMedTransferList( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedTransfer> modelList = new List<MedTransfer>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_TRANSFER_Select_ALL, null))
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

        public int SelectMaxTransferRe2(string patientId, decimal visitId, string deptStayed, System.Data.Common.DbConnection oleCisConn)
        {
            OracleParameter[] medMaxTransferRe2 = GetParameter("SelectMaxTransferRe2");
            medMaxTransferRe2[0].Value = patientId;
            medMaxTransferRe2[1].Value = visitId;
            medMaxTransferRe2[2].Value = deptStayed;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_TRANSFER_Select_Max_Re2, medMaxTransferRe2))
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
