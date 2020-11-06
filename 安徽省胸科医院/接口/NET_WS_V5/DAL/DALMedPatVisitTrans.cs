

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:27
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
	/// DAL MedPatVisit
	/// </summary>
	
	public partial class DALMedPatVisit
	{

		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedPatVisit 
		///Insert Table MED_PAT_VISIT
		/// </summary>
        public int InsertMedPatVisitSQL(MedPatVisit model, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneInert = GetParameterSQL("InsertMedPatVisit");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.DEPT_ADMISSION_TO != null)
						oneInert[2].Value = model.DEPT_ADMISSION_TO;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.AdmissionDateTime > DateTime.MinValue)
						oneInert[3].Value = model.AdmissionDateTime;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.DeptDischargeFrom != null)
						oneInert[4].Value = model.DeptDischargeFrom;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.DischargeDateTime > DateTime.MinValue)
						oneInert[5].Value = model.DischargeDateTime;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.Occupation != null)
						oneInert[6].Value = model.Occupation;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.MaritalStatus != null)
						oneInert[7].Value = model.MaritalStatus;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Identity != null)
						oneInert[8].Value = model.Identity;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.ArmedServices != null)
						oneInert[9].Value = model.ArmedServices;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Duty != null)
						oneInert[10].Value = model.Duty;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.TopUnit != null)
						oneInert[11].Value = model.TopUnit;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.ServiceSystemIndicator.ToString() != null)
						oneInert[12].Value = model.ServiceSystemIndicator;
					else
						oneInert[12].Value = DBNull.Value;
					if (model.UnitInContract != null)
						oneInert[13].Value = model.UnitInContract;
					else
						oneInert[13].Value = DBNull.Value;
					if (model.ChargeType != null)
						oneInert[14].Value = model.ChargeType;
					else
						oneInert[14].Value = DBNull.Value;
					if (model.WorkingStatus.ToString() != null)
						oneInert[15].Value = model.WorkingStatus;
					else
						oneInert[15].Value = DBNull.Value;
					if (model.InsuranceType != null)
						oneInert[16].Value = model.InsuranceType;
					else
						oneInert[16].Value = DBNull.Value;
					if (model.InsuranceNo != null)
						oneInert[17].Value = model.InsuranceNo;
					else
						oneInert[17].Value = DBNull.Value;
					if (model.ServiceAgency != null)
						oneInert[18].Value = model.ServiceAgency;
					else
						oneInert[18].Value = DBNull.Value;
					if (model.MailingAddress != null)
						oneInert[19].Value = model.MailingAddress;
					else
						oneInert[19].Value = DBNull.Value;
					if (model.ZipCode != null)
						oneInert[20].Value = model.ZipCode;
					else
						oneInert[20].Value = DBNull.Value;
					if (model.NextOfKin != null)
						oneInert[21].Value = model.NextOfKin;
					else
						oneInert[21].Value = DBNull.Value;
					if (model.Relationship != null)
						oneInert[22].Value = model.Relationship;
					else
						oneInert[22].Value = DBNull.Value;
					if (model.NextOfKinAddr != null)
						oneInert[23].Value = model.NextOfKinAddr;
					else
						oneInert[23].Value = DBNull.Value;
					if (model.NextOfKinZipcode != null)
						oneInert[24].Value = model.NextOfKinZipcode;
					else
						oneInert[24].Value = DBNull.Value;
					if (model.NextOfKinPhone != null)
						oneInert[25].Value = model.NextOfKinPhone;
					else
						oneInert[25].Value = DBNull.Value;
					if (model.PatientSource != null)
						oneInert[26].Value = model.PatientSource;
					else
						oneInert[26].Value = DBNull.Value;
					if (model.AdmissionCause != null)
						oneInert[27].Value = model.AdmissionCause;
					else
						oneInert[27].Value = DBNull.Value;
					if (model.ConsultingDate > DateTime.MinValue)
						oneInert[28].Value = model.ConsultingDate;
					else
						oneInert[28].Value = DBNull.Value;
					if (model.PatAdmCondition != null)
						oneInert[29].Value = model.PatAdmCondition;
					else
						oneInert[29].Value = DBNull.Value;
					if (model.ConsultingDoctor != null)
						oneInert[30].Value = model.ConsultingDoctor;
					else
						oneInert[30].Value = DBNull.Value;
					if (model.AdmittedBy != null)
						oneInert[31].Value = model.AdmittedBy;
					else
						oneInert[31].Value = DBNull.Value;
                    if (model.EmerTreatTimes.ToString() != null)
						oneInert[32].Value = model.EmerTreatTimes;
					else
						oneInert[32].Value = DBNull.Value;
                    if (model.EscEmerTimes.ToString() != null)
						oneInert[33].Value = model.EscEmerTimes;
					else
						oneInert[33].Value = DBNull.Value;
                    if (model.SeriousCondDays.ToString() != null)
						oneInert[34].Value = model.SeriousCondDays;
					else
						oneInert[34].Value = DBNull.Value;
                    if (model.CriticalCondDays.ToString() != null)
						oneInert[35].Value = model.CriticalCondDays;
					else
						oneInert[35].Value = DBNull.Value;
                    if (model.IcuDays.ToString() != null)
						oneInert[36].Value = model.IcuDays;
					else
						oneInert[36].Value = DBNull.Value;
                    if (model.CcuDays.ToString() != null)
						oneInert[37].Value = model.CcuDays;
					else
						oneInert[37].Value = DBNull.Value;
                    if (model.SpecLevelNursDays.ToString() != null)
						oneInert[38].Value = model.SpecLevelNursDays;
					else
						oneInert[38].Value = DBNull.Value;
                    if (model.FirstLevelNursDays.ToString() != null)
						oneInert[39].Value = model.FirstLevelNursDays;
					else
						oneInert[39].Value = DBNull.Value;
                    if (model.SecondLevelNursDays.ToString() != null)
						oneInert[40].Value = model.SecondLevelNursDays;
					else
						oneInert[40].Value = DBNull.Value;
                    if (model.AutopsyIndicator.ToString() != null)
						oneInert[41].Value = model.AutopsyIndicator;
					else
						oneInert[41].Value = DBNull.Value;
					if (model.BloodType != null)
						oneInert[42].Value = model.BloodType;
					else
						oneInert[42].Value = DBNull.Value;
					if (model.BloodTypeRh != null)
						oneInert[43].Value = model.BloodTypeRh;
					else
						oneInert[43].Value = DBNull.Value;
                    if (model.InfusionReactTimes.ToString() != null)
						oneInert[44].Value = model.InfusionReactTimes;
					else
						oneInert[44].Value = DBNull.Value;
                    if (model.BloodTranTimes.ToString() != null)
						oneInert[45].Value = model.BloodTranTimes;
					else
						oneInert[45].Value = DBNull.Value;
                    if (model.BloodTranVol.ToString() != null)
						oneInert[46].Value = model.BloodTranVol;
					else
						oneInert[46].Value = DBNull.Value;
                    if (model.BloodTranReactTimes.ToString() != null)
						oneInert[47].Value = model.BloodTranReactTimes;
					else
						oneInert[47].Value = DBNull.Value;
                    if (model.DecubitalUlcerTimes.ToString() != null)
						oneInert[48].Value = model.DecubitalUlcerTimes;
					else
						oneInert[48].Value = DBNull.Value;
					if (model.AlergyDrugs != null)
						oneInert[49].Value = model.AlergyDrugs;
					else
						oneInert[49].Value = DBNull.Value;
					if (model.AdverseReactionDrugs != null)
						oneInert[50].Value = model.AdverseReactionDrugs;
					else
						oneInert[50].Value = DBNull.Value;
					if (model.MrValue != null)
						oneInert[51].Value = model.MrValue;
					else
						oneInert[51].Value = DBNull.Value;
					if (model.MrQuality != null)
						oneInert[52].Value = model.MrQuality;
					else
						oneInert[52].Value = DBNull.Value;
                    if (model.FollowIndicator.ToString() != null)
						oneInert[53].Value = model.FollowIndicator;
					else
						oneInert[53].Value = DBNull.Value;
					if (model.FollowInterval.ToString() != null)
						oneInert[54].Value = model.FollowInterval;
					else
						oneInert[54].Value = DBNull.Value;
					if (model.FollowIntervalUnits != null)
						oneInert[55].Value = model.FollowIntervalUnits;
					else
						oneInert[55].Value = DBNull.Value;
					if (model.Director != null)
						oneInert[56].Value = model.Director;
					else
						oneInert[56].Value = DBNull.Value;
					if (model.AttendingDoctor != null)
						oneInert[57].Value = model.AttendingDoctor;
					else
						oneInert[57].Value = DBNull.Value;
					if (model.DoctorInCharge != null)
						oneInert[58].Value = model.DoctorInCharge;
					else
						oneInert[58].Value = DBNull.Value;
					if (model.DischargeDisposition != null)
						oneInert[59].Value = model.DischargeDisposition;
					else
						oneInert[59].Value = DBNull.Value;
                    if (model.TotalCosts.ToString() != null)
						oneInert[60].Value = model.TotalCosts;
					else
						oneInert[60].Value = DBNull.Value;
					if (model.TotalPayments.ToString() != null)
						oneInert[61].Value = model.TotalPayments;
					else
						oneInert[61].Value = DBNull.Value;
					if (model.CatalogDate > DateTime.MinValue)
						oneInert[62].Value = model.CatalogDate;
					else
						oneInert[62].Value = DBNull.Value;
					if (model.Cataloger != null)
						oneInert[63].Value = model.Cataloger;
					else
						oneInert[63].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneInert[64].Value = model.Reserved01;
					else
						oneInert[64].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneInert[65].Value = model.Reserved02;
					else
						oneInert[65].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneInert[66].Value = model.Reserved03;
					else
						oneInert[66].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneInert[67].Value = model.Reserved04;
					else
						oneInert[67].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneInert[68].Value = model.Reserved05;
					else
						oneInert[68].Value = DBNull.Value;
					if (model.Reserved06 != null)
						oneInert[69].Value = model.Reserved06;
					else
						oneInert[69].Value = DBNull.Value;
					if (model.Reserved07 != null)
						oneInert[70].Value = model.Reserved07;
					else
						oneInert[70].Value = DBNull.Value;
					if (model.Reserved08 != null)
						oneInert[71].Value = model.Reserved08;
					else
						oneInert[71].Value = DBNull.Value;
					if (model.Reserved09 != null)
						oneInert[72].Value = model.Reserved09;
					else
						oneInert[72].Value = DBNull.Value;
					if (model.Reserved10 != null)
						oneInert[73].Value = model.Reserved10;
					else
						oneInert[73].Value = DBNull.Value;
					if (model.ReservedDate01 > DateTime.MinValue)
						oneInert[74].Value = model.ReservedDate01;
					else
						oneInert[74].Value = DBNull.Value;
					if (model.ReservedDate02 > DateTime.MinValue)
						oneInert[75].Value = model.ReservedDate02;
					else
						oneInert[75].Value = DBNull.Value;
					if (model.BodyHeight.ToString() != null)
						oneInert[76].Value = model.BodyHeight;
					else
						oneInert[76].Value = DBNull.Value;
					if (model.BodyWeight.ToString() != null)
						oneInert[77].Value = model.BodyWeight;
					else
						oneInert[77].Value = DBNull.Value;
					if (model.PatientCondition != null)
						oneInert[78].Value = model.PatientCondition;
					else
						oneInert[78].Value = DBNull.Value;
					if (model.Abnormal != null)
						oneInert[79].Value = model.Abnormal;
					else
						oneInert[79].Value = DBNull.Value;

                    return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans,CommandType.Text, MED_PAT_VISIT_Insert_SQL, oneInert);
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedPatVisit 
		///Update Table     MED_PAT_VISIT
		/// </summary>
        public int UpdateMedPatVisitSQL(MedPatVisit model, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPatVisit");
		    if (model.PatientId != null)
			    oneUpdate[0].Value = model.PatientId;
		    else
			    oneUpdate[0].Value = DBNull.Value;
		    if (model.VisitId.ToString() != null)
			    oneUpdate[1].Value = model.VisitId;
		    else
			    oneUpdate[1].Value = DBNull.Value;
		    if (model.DEPT_ADMISSION_TO != null)
			    oneUpdate[2].Value = model.DEPT_ADMISSION_TO;
		    else
			    oneUpdate[2].Value = DBNull.Value;
		    if (model.AdmissionDateTime > DateTime.MinValue)
			    oneUpdate[3].Value = model.AdmissionDateTime;
		    else
			    oneUpdate[3].Value = DBNull.Value;
		    if (model.DeptDischargeFrom != null)
			    oneUpdate[4].Value = model.DeptDischargeFrom;
		    else
			    oneUpdate[4].Value = DBNull.Value;
		    if (model.DischargeDateTime > DateTime.MinValue)
			    oneUpdate[5].Value = model.DischargeDateTime;
		    else
			    oneUpdate[5].Value = DBNull.Value;
		    if (model.Occupation != null)
			    oneUpdate[6].Value = model.Occupation;
		    else
			    oneUpdate[6].Value = DBNull.Value;
		    if (model.MaritalStatus != null)
			    oneUpdate[7].Value = model.MaritalStatus;
		    else
			    oneUpdate[7].Value = DBNull.Value;
		    if (model.Identity != null)
			    oneUpdate[8].Value = model.Identity;
		    else
			    oneUpdate[8].Value = DBNull.Value;
		    if (model.ArmedServices != null)
			    oneUpdate[9].Value = model.ArmedServices;
		    else
			    oneUpdate[9].Value = DBNull.Value;
		    if (model.Duty != null)
			    oneUpdate[10].Value = model.Duty;
		    else
			    oneUpdate[10].Value = DBNull.Value;
		    if (model.TopUnit != null)
			    oneUpdate[11].Value = model.TopUnit;
		    else
			    oneUpdate[11].Value = DBNull.Value;
            if (model.ServiceSystemIndicator.ToString() != null)
			    oneUpdate[12].Value = model.ServiceSystemIndicator;
		    else
			    oneUpdate[12].Value = DBNull.Value;
		    if (model.UnitInContract != null)
			    oneUpdate[13].Value = model.UnitInContract;
		    else
			    oneUpdate[13].Value = DBNull.Value;
		    if (model.ChargeType != null)
			    oneUpdate[14].Value = model.ChargeType;
		    else
			    oneUpdate[14].Value = DBNull.Value;
            if (model.WorkingStatus.ToString() != null)
			    oneUpdate[15].Value = model.WorkingStatus;
		    else
			    oneUpdate[15].Value = DBNull.Value;
		    if (model.InsuranceType != null)
			    oneUpdate[16].Value = model.InsuranceType;
		    else
			    oneUpdate[16].Value = DBNull.Value;
		    if (model.InsuranceNo != null)
			    oneUpdate[17].Value = model.InsuranceNo;
		    else
			    oneUpdate[17].Value = DBNull.Value;
		    if (model.ServiceAgency != null)
			    oneUpdate[18].Value = model.ServiceAgency;
		    else
			    oneUpdate[18].Value = DBNull.Value;
		    if (model.MailingAddress != null)
			    oneUpdate[19].Value = model.MailingAddress;
		    else
			    oneUpdate[19].Value = DBNull.Value;
		    if (model.ZipCode != null)
			    oneUpdate[20].Value = model.ZipCode;
		    else
			    oneUpdate[20].Value = DBNull.Value;
		    if (model.NextOfKin != null)
			    oneUpdate[21].Value = model.NextOfKin;
		    else
			    oneUpdate[21].Value = DBNull.Value;
		    if (model.Relationship != null)
			    oneUpdate[22].Value = model.Relationship;
		    else
			    oneUpdate[22].Value = DBNull.Value;
		    if (model.NextOfKinAddr != null)
			    oneUpdate[23].Value = model.NextOfKinAddr;
		    else
			    oneUpdate[23].Value = DBNull.Value;
		    if (model.NextOfKinZipcode != null)
			    oneUpdate[24].Value = model.NextOfKinZipcode;
		    else
			    oneUpdate[24].Value = DBNull.Value;
		    if (model.NextOfKinPhone != null)
			    oneUpdate[25].Value = model.NextOfKinPhone;
		    else
			    oneUpdate[25].Value = DBNull.Value;
		    if (model.PatientSource != null)
			    oneUpdate[26].Value = model.PatientSource;
		    else
			    oneUpdate[26].Value = DBNull.Value;
		    if (model.AdmissionCause != null)
			    oneUpdate[27].Value = model.AdmissionCause;
		    else
			    oneUpdate[27].Value = DBNull.Value;
		    if (model.ConsultingDate > DateTime.MinValue)
			    oneUpdate[28].Value = model.ConsultingDate;
		    else
			    oneUpdate[28].Value = DBNull.Value;
		    if (model.PatAdmCondition != null)
			    oneUpdate[29].Value = model.PatAdmCondition;
		    else
			    oneUpdate[29].Value = DBNull.Value;
		    if (model.ConsultingDoctor != null)
			    oneUpdate[30].Value = model.ConsultingDoctor;
		    else
			    oneUpdate[30].Value = DBNull.Value;
		    if (model.AdmittedBy != null)
			    oneUpdate[31].Value = model.AdmittedBy;
		    else
			    oneUpdate[31].Value = DBNull.Value;
            if (model.EmerTreatTimes.ToString() != null)
			    oneUpdate[32].Value = model.EmerTreatTimes;
		    else
			    oneUpdate[32].Value = DBNull.Value;
            if (model.EscEmerTimes.ToString() != null)
			    oneUpdate[33].Value = model.EscEmerTimes;
		    else
			    oneUpdate[33].Value = DBNull.Value;
            if (model.SeriousCondDays.ToString() != null)
			    oneUpdate[34].Value = model.SeriousCondDays;
		    else
			    oneUpdate[34].Value = DBNull.Value;
            if (model.CriticalCondDays.ToString() != null)
			    oneUpdate[35].Value = model.CriticalCondDays;
		    else
			    oneUpdate[35].Value = DBNull.Value;
            if (model.IcuDays.ToString() != null)
			    oneUpdate[36].Value = model.IcuDays;
		    else
			    oneUpdate[36].Value = DBNull.Value;
            if (model.CcuDays.ToString() != null)
			    oneUpdate[37].Value = model.CcuDays;
		    else
			    oneUpdate[37].Value = DBNull.Value;
            if (model.SpecLevelNursDays.ToString() != null)
			    oneUpdate[38].Value = model.SpecLevelNursDays;
		    else
			    oneUpdate[38].Value = DBNull.Value;
            if (model.FirstLevelNursDays.ToString() != null)
			    oneUpdate[39].Value = model.FirstLevelNursDays;
		    else
			    oneUpdate[39].Value = DBNull.Value;
            if (model.SecondLevelNursDays.ToString() != null)
			    oneUpdate[40].Value = model.SecondLevelNursDays;
		    else
			    oneUpdate[40].Value = DBNull.Value;
            if (model.AutopsyIndicator.ToString() != null)
			    oneUpdate[41].Value = model.AutopsyIndicator;
		    else
			    oneUpdate[41].Value = DBNull.Value;
		    if (model.BloodType != null)
			    oneUpdate[42].Value = model.BloodType;
		    else
			    oneUpdate[42].Value = DBNull.Value;
		    if (model.BloodTypeRh != null)
			    oneUpdate[43].Value = model.BloodTypeRh;
		    else
			    oneUpdate[43].Value = DBNull.Value;
            if (model.InfusionReactTimes.ToString() != null)
			    oneUpdate[44].Value = model.InfusionReactTimes;
		    else
			    oneUpdate[44].Value = DBNull.Value;
            if (model.BloodTranTimes.ToString() != null)
			    oneUpdate[45].Value = model.BloodTranTimes;
		    else
			    oneUpdate[45].Value = DBNull.Value;
            if (model.BloodTranVol.ToString() != null)
			    oneUpdate[46].Value = model.BloodTranVol;
		    else
			    oneUpdate[46].Value = DBNull.Value;
            if (model.BloodTranReactTimes.ToString() != null)
			    oneUpdate[47].Value = model.BloodTranReactTimes;
		    else
			    oneUpdate[47].Value = DBNull.Value;
            if (model.DecubitalUlcerTimes.ToString() != null)
			    oneUpdate[48].Value = model.DecubitalUlcerTimes;
		    else
			    oneUpdate[48].Value = DBNull.Value;
		    if (model.AlergyDrugs != null)
			    oneUpdate[49].Value = model.AlergyDrugs;
		    else
			    oneUpdate[49].Value = DBNull.Value;
		    if (model.AdverseReactionDrugs != null)
			    oneUpdate[50].Value = model.AdverseReactionDrugs;
		    else
			    oneUpdate[50].Value = DBNull.Value;
		    if (model.MrValue != null)
			    oneUpdate[51].Value = model.MrValue;
		    else
			    oneUpdate[51].Value = DBNull.Value;
		    if (model.MrQuality != null)
			    oneUpdate[52].Value = model.MrQuality;
		    else
			    oneUpdate[52].Value = DBNull.Value;
            if (model.FollowIndicator.ToString() != null)
			    oneUpdate[53].Value = model.FollowIndicator;
		    else
			    oneUpdate[53].Value = DBNull.Value;
            if (model.FollowInterval.ToString() != null)
			    oneUpdate[54].Value = model.FollowInterval;
		    else
			    oneUpdate[54].Value = DBNull.Value;
		    if (model.FollowIntervalUnits != null)
			    oneUpdate[55].Value = model.FollowIntervalUnits;
		    else
			    oneUpdate[55].Value = DBNull.Value;
		    if (model.Director != null)
			    oneUpdate[56].Value = model.Director;
		    else
			    oneUpdate[56].Value = DBNull.Value;
		    if (model.AttendingDoctor != null)
			    oneUpdate[57].Value = model.AttendingDoctor;
		    else
			    oneUpdate[57].Value = DBNull.Value;
		    if (model.DoctorInCharge != null)
			    oneUpdate[58].Value = model.DoctorInCharge;
		    else
			    oneUpdate[58].Value = DBNull.Value;
		    if (model.DischargeDisposition != null)
			    oneUpdate[59].Value = model.DischargeDisposition;
		    else
			    oneUpdate[59].Value = DBNull.Value;
            if (model.TotalCosts.ToString() != null)
			    oneUpdate[60].Value = model.TotalCosts;
		    else
			    oneUpdate[60].Value = DBNull.Value;
            if (model.TotalPayments.ToString() != null)
			    oneUpdate[61].Value = model.TotalPayments;
		    else
			    oneUpdate[61].Value = DBNull.Value;
		    if (model.CatalogDate > DateTime.MinValue)
			    oneUpdate[62].Value = model.CatalogDate;
		    else
			    oneUpdate[62].Value = DBNull.Value;
		    if (model.Cataloger != null)
			    oneUpdate[63].Value = model.Cataloger;
		    else
			    oneUpdate[63].Value = DBNull.Value;
		    if (model.Reserved01 != null)
			    oneUpdate[64].Value = model.Reserved01;
		    else
			    oneUpdate[64].Value = DBNull.Value;
		    if (model.Reserved02 != null)
			    oneUpdate[65].Value = model.Reserved02;
		    else
			    oneUpdate[65].Value = DBNull.Value;
		    if (model.Reserved03 != null)
			    oneUpdate[66].Value = model.Reserved03;
		    else
			    oneUpdate[66].Value = DBNull.Value;
		    if (model.Reserved04 != null)
			    oneUpdate[67].Value = model.Reserved04;
		    else
			    oneUpdate[67].Value = DBNull.Value;
		    if (model.Reserved05 != null)
			    oneUpdate[68].Value = model.Reserved05;
		    else
			    oneUpdate[68].Value = DBNull.Value;
		    if (model.Reserved06 != null)
			    oneUpdate[69].Value = model.Reserved06;
		    else
			    oneUpdate[69].Value = DBNull.Value;
		    if (model.Reserved07 != null)
			    oneUpdate[70].Value = model.Reserved07;
		    else
			    oneUpdate[70].Value = DBNull.Value;
		    if (model.Reserved08 != null)
			    oneUpdate[71].Value = model.Reserved08;
		    else
			    oneUpdate[71].Value = DBNull.Value;
		    if (model.Reserved09 != null)
			    oneUpdate[72].Value = model.Reserved09;
		    else
			    oneUpdate[72].Value = DBNull.Value;
		    if (model.Reserved10 != null)
			    oneUpdate[73].Value = model.Reserved10;
		    else
			    oneUpdate[73].Value = DBNull.Value;
		    if (model.ReservedDate01 > DateTime.MinValue)
			    oneUpdate[74].Value = model.ReservedDate01;
		    else
			    oneUpdate[74].Value = DBNull.Value;
		    if (model.ReservedDate02 > DateTime.MinValue)
			    oneUpdate[75].Value = model.ReservedDate02;
		    else
			    oneUpdate[75].Value = DBNull.Value;
            if (model.BodyHeight.ToString() != null)
			    oneUpdate[76].Value = model.BodyHeight;
		    else
			    oneUpdate[76].Value = DBNull.Value;
            if (model.BodyWeight.ToString() != null)
			    oneUpdate[77].Value = model.BodyWeight;
		    else
			    oneUpdate[77].Value = DBNull.Value;
		    if (model.PatientCondition != null)
			    oneUpdate[78].Value = model.PatientCondition;
		    else
			    oneUpdate[78].Value = DBNull.Value;
		    if (model.Abnormal != null)
			    oneUpdate[79].Value = model.Abnormal;
		    else
			    oneUpdate[79].Value = DBNull.Value;
		    if (model.PatientId != null)
			    oneUpdate[80].Value =model.PatientId;
		    else
			    oneUpdate[80].Value = DBNull.Value;
		    if (model.VisitId.ToString() != null)
			    oneUpdate[81].Value =model.VisitId;
		    else
			    oneUpdate[81].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PAT_VISIT_Update_SQL, oneUpdate);
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedPatVisit 
		///Delete Table MED_PAT_VISIT by (string PATIENT_ID,decimal VISIT_ID)
		/// </summary>
        public int DeleteMedPatVisitSQL(string PATIENT_ID, decimal VISIT_ID, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPatVisit");
			if (PATIENT_ID != null)
				oneDelete[0].Value =PATIENT_ID;
			else
				oneDelete[0].Value = DBNull.Value;
            if (VISIT_ID.ToString() != null)
				oneDelete[1].Value =VISIT_ID;
			else
				oneDelete[1].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PAT_VISIT_Delete_SQL, oneDelete);

		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedPatVisit 
		///select Table MED_PAT_VISIT by (string PATIENT_ID,decimal VISIT_ID)
		/// </summary>
        public MedPatVisit SelectMedPatVisitSQL(string PATIENT_ID, decimal VISIT_ID, System.Data.Common.DbConnection oleCisConn)
		{
			MedPatVisit model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedPatVisit");
			parameterValues[0].Value=PATIENT_ID;
			parameterValues[1].Value=VISIT_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PAT_VISIT_Select_SQL, parameterValues))
		    {
				if (oleReader.Read())
				{
					model = new MedPatVisit();
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
							model.DEPT_ADMISSION_TO = oleReader["DEPT_ADMISSION_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.DeptDischargeFrom = oleReader["DEPT_DISCHARGE_FROM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.DischargeDateTime = DateTime.Parse(oleReader["DISCHARGE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Occupation = oleReader["OCCUPATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.MaritalStatus = oleReader["MARITAL_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Identity = oleReader["IDENTITY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.ArmedServices = oleReader["ARMED_SERVICES"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Duty = oleReader["DUTY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.TopUnit = oleReader["TOP_UNIT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.ServiceSystemIndicator = decimal.Parse(oleReader["SERVICE_SYSTEM_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.UnitInContract = oleReader["UNIT_IN_CONTRACT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.ChargeType = oleReader["CHARGE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.WorkingStatus = decimal.Parse(oleReader["WORKING_STATUS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.InsuranceType = oleReader["INSURANCE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.InsuranceNo = oleReader["INSURANCE_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.ServiceAgency = oleReader["SERVICE_AGENCY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.MailingAddress = oleReader["MAILING_ADDRESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.ZipCode = oleReader["ZIP_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.NextOfKin = oleReader["NEXT_OF_KIN"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.Relationship = oleReader["RELATIONSHIP"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.NextOfKinAddr = oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.NextOfKinZipcode = oleReader["NEXT_OF_KIN_ZIPCODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.NextOfKinPhone = oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(26))
						{
                            model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
						}
						if (!oleReader.IsDBNull(27))
						{
							model.AdmissionCause = oleReader["ADMISSION_CAUSE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.ConsultingDate = DateTime.Parse(oleReader["CONSULTING_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.PatAdmCondition = oleReader["PAT_ADM_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.ConsultingDoctor = oleReader["CONSULTING_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(31))
						{
							model.AdmittedBy = oleReader["ADMITTED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(32))
						{
							model.EmerTreatTimes = decimal.Parse(oleReader["EMER_TREAT_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(33))
						{
							model.EscEmerTimes = decimal.Parse(oleReader["ESC_EMER_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(34))
						{
							model.SeriousCondDays = decimal.Parse(oleReader["SERIOUS_COND_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(35))
						{
							model.CriticalCondDays = decimal.Parse(oleReader["CRITICAL_COND_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(36))
						{
							model.IcuDays = decimal.Parse(oleReader["ICU_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(37))
						{
							model.CcuDays = decimal.Parse(oleReader["CCU_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(38))
						{
							model.SpecLevelNursDays = decimal.Parse(oleReader["SPEC_LEVEL_NURS_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(39))
						{
							model.FirstLevelNursDays = decimal.Parse(oleReader["FIRST_LEVEL_NURS_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(40))
						{
							model.SecondLevelNursDays = decimal.Parse(oleReader["SECOND_LEVEL_NURS_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(41))
						{
							model.AutopsyIndicator = decimal.Parse(oleReader["AUTOPSY_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(42))
						{
							model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(43))
						{
							model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(44))
						{
							model.InfusionReactTimes = decimal.Parse(oleReader["INFUSION_REACT_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(45))
						{
							model.BloodTranTimes = decimal.Parse(oleReader["BLOOD_TRAN_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(46))
						{
							model.BloodTranVol = decimal.Parse(oleReader["BLOOD_TRAN_VOL"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(47))
						{
							model.BloodTranReactTimes = decimal.Parse(oleReader["BLOOD_TRAN_REACT_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(48))
						{
							model.DecubitalUlcerTimes = decimal.Parse(oleReader["DECUBITAL_ULCER_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(49))
						{
							model.AlergyDrugs = oleReader["ALERGY_DRUGS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(50))
						{
							model.AdverseReactionDrugs = oleReader["ADVERSE_REACTION_DRUGS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(51))
						{
							model.MrValue = oleReader["MR_VALUE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(52))
						{
							model.MrQuality = oleReader["MR_QUALITY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(53))
						{
							model.FollowIndicator = decimal.Parse(oleReader["FOLLOW_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(54))
						{
							model.FollowInterval = decimal.Parse(oleReader["FOLLOW_INTERVAL"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(55))
						{
							model.FollowIntervalUnits = oleReader["FOLLOW_INTERVAL_UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(56))
						{
							model.Director = oleReader["DIRECTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(57))
						{
							model.AttendingDoctor = oleReader["ATTENDING_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(58))
						{
							model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(59))
						{
							model.DischargeDisposition = oleReader["DISCHARGE_DISPOSITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(60))
						{
							model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(61))
						{
							model.TotalPayments = decimal.Parse(oleReader["TOTAL_PAYMENTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(62))
						{
							model.CatalogDate = DateTime.Parse(oleReader["CATALOG_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(63))
						{
							model.Cataloger = oleReader["CATALOGER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(64))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(65))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(66))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(67))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(68))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(69))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(70))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(71))
						{
							model.Reserved08 = oleReader["RESERVED08"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(72))
						{
							model.Reserved09 = oleReader["RESERVED09"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(73))
						{
							model.Reserved10 = oleReader["RESERVED10"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(74))
						{
							model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(75))
						{
							model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(76))
						{
							model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(77))
						{
							model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(78))
						{
							model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(79))
						{
							model.Abnormal = oleReader["ABNORMAL"].ToString().Trim() ;
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
		public List<MedPatVisit> SelectMedPatVisitListSQL( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedPatVisit> modelList = new List<MedPatVisit>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PAT_VISIT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedPatVisit model = new MedPatVisit();
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
							model.DEPT_ADMISSION_TO = oleReader["DEPT_ADMISSION_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.DeptDischargeFrom = oleReader["DEPT_DISCHARGE_FROM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.DischargeDateTime = DateTime.Parse(oleReader["DISCHARGE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Occupation = oleReader["OCCUPATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.MaritalStatus = oleReader["MARITAL_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Identity = oleReader["IDENTITY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.ArmedServices = oleReader["ARMED_SERVICES"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Duty = oleReader["DUTY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.TopUnit = oleReader["TOP_UNIT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.ServiceSystemIndicator = decimal.Parse(oleReader["SERVICE_SYSTEM_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.UnitInContract = oleReader["UNIT_IN_CONTRACT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.ChargeType = oleReader["CHARGE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.WorkingStatus = decimal.Parse(oleReader["WORKING_STATUS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.InsuranceType = oleReader["INSURANCE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.InsuranceNo = oleReader["INSURANCE_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.ServiceAgency = oleReader["SERVICE_AGENCY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.MailingAddress = oleReader["MAILING_ADDRESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.ZipCode = oleReader["ZIP_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.NextOfKin = oleReader["NEXT_OF_KIN"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.Relationship = oleReader["RELATIONSHIP"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.NextOfKinAddr = oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.NextOfKinZipcode = oleReader["NEXT_OF_KIN_ZIPCODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.NextOfKinPhone = oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(26))
						{
                            model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
						}
						if (!oleReader.IsDBNull(27))
						{
							model.AdmissionCause = oleReader["ADMISSION_CAUSE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.ConsultingDate = DateTime.Parse(oleReader["CONSULTING_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.PatAdmCondition = oleReader["PAT_ADM_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.ConsultingDoctor = oleReader["CONSULTING_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(31))
						{
							model.AdmittedBy = oleReader["ADMITTED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(32))
						{
							model.EmerTreatTimes = decimal.Parse(oleReader["EMER_TREAT_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(33))
						{
							model.EscEmerTimes = decimal.Parse(oleReader["ESC_EMER_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(34))
						{
							model.SeriousCondDays = decimal.Parse(oleReader["SERIOUS_COND_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(35))
						{
							model.CriticalCondDays = decimal.Parse(oleReader["CRITICAL_COND_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(36))
						{
							model.IcuDays = decimal.Parse(oleReader["ICU_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(37))
						{
							model.CcuDays = decimal.Parse(oleReader["CCU_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(38))
						{
							model.SpecLevelNursDays = decimal.Parse(oleReader["SPEC_LEVEL_NURS_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(39))
						{
							model.FirstLevelNursDays = decimal.Parse(oleReader["FIRST_LEVEL_NURS_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(40))
						{
							model.SecondLevelNursDays = decimal.Parse(oleReader["SECOND_LEVEL_NURS_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(41))
						{
							model.AutopsyIndicator = decimal.Parse(oleReader["AUTOPSY_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(42))
						{
							model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(43))
						{
							model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(44))
						{
							model.InfusionReactTimes = decimal.Parse(oleReader["INFUSION_REACT_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(45))
						{
							model.BloodTranTimes = decimal.Parse(oleReader["BLOOD_TRAN_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(46))
						{
							model.BloodTranVol = decimal.Parse(oleReader["BLOOD_TRAN_VOL"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(47))
						{
							model.BloodTranReactTimes = decimal.Parse(oleReader["BLOOD_TRAN_REACT_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(48))
						{
							model.DecubitalUlcerTimes = decimal.Parse(oleReader["DECUBITAL_ULCER_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(49))
						{
							model.AlergyDrugs = oleReader["ALERGY_DRUGS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(50))
						{
							model.AdverseReactionDrugs = oleReader["ADVERSE_REACTION_DRUGS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(51))
						{
							model.MrValue = oleReader["MR_VALUE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(52))
						{
							model.MrQuality = oleReader["MR_QUALITY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(53))
						{
							model.FollowIndicator = decimal.Parse(oleReader["FOLLOW_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(54))
						{
							model.FollowInterval = decimal.Parse(oleReader["FOLLOW_INTERVAL"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(55))
						{
							model.FollowIntervalUnits = oleReader["FOLLOW_INTERVAL_UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(56))
						{
							model.Director = oleReader["DIRECTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(57))
						{
							model.AttendingDoctor = oleReader["ATTENDING_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(58))
						{
							model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(59))
						{
							model.DischargeDisposition = oleReader["DISCHARGE_DISPOSITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(60))
						{
							model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(61))
						{
							model.TotalPayments = decimal.Parse(oleReader["TOTAL_PAYMENTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(62))
						{
							model.CatalogDate = DateTime.Parse(oleReader["CATALOG_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(63))
						{
							model.Cataloger = oleReader["CATALOGER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(64))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(65))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(66))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(67))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(68))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(69))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(70))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(71))
						{
							model.Reserved08 = oleReader["RESERVED08"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(72))
						{
							model.Reserved09 = oleReader["RESERVED09"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(73))
						{
							model.Reserved10 = oleReader["RESERVED10"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(74))
						{
							model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(75))
						{
							model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(76))
						{
							model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(77))
						{
							model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(78))
						{
							model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(79))
						{
							model.Abnormal = oleReader["ABNORMAL"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedPatVisit 
		///Insert Table MED_PAT_VISIT
		/// </summary>
        public int InsertMedPatVisit(MedPatVisit model, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneInert = GetParameter("InsertMedPatVisit");
			if (model.PatientId != null)
				oneInert[0].Value = model.PatientId;
			else
				oneInert[0].Value = DBNull.Value;
			if (model.VisitId.ToString() != null)
				oneInert[1].Value = model.VisitId;
			else
				oneInert[1].Value = DBNull.Value;
			if (model.DEPT_ADMISSION_TO != null)
				oneInert[2].Value = model.DEPT_ADMISSION_TO;
			else
				oneInert[2].Value = DBNull.Value;
			if (model.AdmissionDateTime > DateTime.MinValue)
				oneInert[3].Value = model.AdmissionDateTime;
			else
				oneInert[3].Value = DBNull.Value;
			if (model.DeptDischargeFrom != null)
				oneInert[4].Value = model.DeptDischargeFrom;
			else
				oneInert[4].Value = DBNull.Value;
			if (model.DischargeDateTime > DateTime.MinValue)
				oneInert[5].Value = model.DischargeDateTime;
			else
				oneInert[5].Value = DBNull.Value;
			if (model.Occupation != null)
				oneInert[6].Value = model.Occupation;
			else
				oneInert[6].Value = DBNull.Value;
			if (model.MaritalStatus != null)
				oneInert[7].Value = model.MaritalStatus;
			else
				oneInert[7].Value = DBNull.Value;
			if (model.Identity != null)
				oneInert[8].Value = model.Identity;
			else
				oneInert[8].Value = DBNull.Value;
			if (model.ArmedServices != null)
				oneInert[9].Value = model.ArmedServices;
			else
				oneInert[9].Value = DBNull.Value;
			if (model.Duty != null)
				oneInert[10].Value = model.Duty;
			else
				oneInert[10].Value = DBNull.Value;
			if (model.TopUnit != null)
				oneInert[11].Value = model.TopUnit;
			else
				oneInert[11].Value = DBNull.Value;
			if (model.ServiceSystemIndicator.ToString() != null)
				oneInert[12].Value = model.ServiceSystemIndicator;
			else
				oneInert[12].Value = DBNull.Value;
			if (model.UnitInContract != null)
				oneInert[13].Value = model.UnitInContract;
			else
				oneInert[13].Value = DBNull.Value;
			if (model.ChargeType != null)
				oneInert[14].Value = model.ChargeType;
			else
				oneInert[14].Value = DBNull.Value;
            if (model.WorkingStatus.ToString() != null)
				oneInert[15].Value = model.WorkingStatus;
			else
				oneInert[15].Value = DBNull.Value;
			if (model.InsuranceType != null)
				oneInert[16].Value = model.InsuranceType;
			else
				oneInert[16].Value = DBNull.Value;
			if (model.InsuranceNo != null)
				oneInert[17].Value = model.InsuranceNo;
			else
				oneInert[17].Value = DBNull.Value;
			if (model.ServiceAgency != null)
				oneInert[18].Value = model.ServiceAgency;
			else
				oneInert[18].Value = DBNull.Value;
			if (model.MailingAddress != null)
				oneInert[19].Value = model.MailingAddress;
			else
				oneInert[19].Value = DBNull.Value;
			if (model.ZipCode != null)
				oneInert[20].Value = model.ZipCode;
			else
				oneInert[20].Value = DBNull.Value;
			if (model.NextOfKin != null)
				oneInert[21].Value = model.NextOfKin;
			else
				oneInert[21].Value = DBNull.Value;
			if (model.Relationship != null)
				oneInert[22].Value = model.Relationship;
			else
				oneInert[22].Value = DBNull.Value;
			if (model.NextOfKinAddr != null)
				oneInert[23].Value = model.NextOfKinAddr;
			else
				oneInert[23].Value = DBNull.Value;
			if (model.NextOfKinZipcode != null)
				oneInert[24].Value = model.NextOfKinZipcode;
			else
				oneInert[24].Value = DBNull.Value;
			if (model.NextOfKinPhone != null)
				oneInert[25].Value = model.NextOfKinPhone;
			else
				oneInert[25].Value = DBNull.Value;
			if (model.PatientSource != null)
				oneInert[26].Value = model.PatientSource;
			else
				oneInert[26].Value = DBNull.Value;
			if (model.AdmissionCause != null)
				oneInert[27].Value = model.AdmissionCause;
			else
				oneInert[27].Value = DBNull.Value;
			if (model.ConsultingDate > DateTime.MinValue)
				oneInert[28].Value = model.ConsultingDate;
			else
				oneInert[28].Value = DBNull.Value;
			if (model.PatAdmCondition != null)
				oneInert[29].Value = model.PatAdmCondition;
			else
				oneInert[29].Value = DBNull.Value;
			if (model.ConsultingDoctor != null)
				oneInert[30].Value = model.ConsultingDoctor;
			else
				oneInert[30].Value = DBNull.Value;
			if (model.AdmittedBy != null)
				oneInert[31].Value = model.AdmittedBy;
			else
				oneInert[31].Value = DBNull.Value;
            if (model.EmerTreatTimes.ToString() != null)
				oneInert[32].Value = model.EmerTreatTimes;
			else
				oneInert[32].Value = DBNull.Value;
            if (model.EscEmerTimes.ToString() != null)
				oneInert[33].Value = model.EscEmerTimes;
			else
				oneInert[33].Value = DBNull.Value;
            if (model.SeriousCondDays.ToString() != null)
				oneInert[34].Value = model.SeriousCondDays;
			else
				oneInert[34].Value = DBNull.Value;
            if (model.CriticalCondDays.ToString() != null)
				oneInert[35].Value = model.CriticalCondDays;
			else
				oneInert[35].Value = DBNull.Value;
			if (model.IcuDays.ToString() != null)
				oneInert[36].Value = model.IcuDays;
			else
				oneInert[36].Value = DBNull.Value;
			if (model.CcuDays.ToString() != null)
				oneInert[37].Value = model.CcuDays;
			else
				oneInert[37].Value = DBNull.Value;
			if (model.SpecLevelNursDays.ToString() != null)
				oneInert[38].Value = model.SpecLevelNursDays;
			else
				oneInert[38].Value = DBNull.Value;
            if (model.FirstLevelNursDays.ToString() != null)
				oneInert[39].Value = model.FirstLevelNursDays;
			else
				oneInert[39].Value = DBNull.Value;
            if (model.SecondLevelNursDays.ToString() != null)
				oneInert[40].Value = model.SecondLevelNursDays;
			else
				oneInert[40].Value = DBNull.Value;
            if (model.AutopsyIndicator.ToString() != null)
				oneInert[41].Value = model.AutopsyIndicator;
			else
				oneInert[41].Value = DBNull.Value;
			if (model.BloodType != null)
				oneInert[42].Value = model.BloodType;
			else
				oneInert[42].Value = DBNull.Value;
			if (model.BloodTypeRh != null)
				oneInert[43].Value = model.BloodTypeRh;
			else
				oneInert[43].Value = DBNull.Value;
            if (model.InfusionReactTimes.ToString() != null)
				oneInert[44].Value = model.InfusionReactTimes;
			else
				oneInert[44].Value = DBNull.Value;
            if (model.BloodTranTimes.ToString() != null)
				oneInert[45].Value = model.BloodTranTimes;
			else
				oneInert[45].Value = DBNull.Value;
            if (model.BloodTranVol.ToString() != null)
				oneInert[46].Value = model.BloodTranVol;
			else
				oneInert[46].Value = DBNull.Value;
            if (model.BloodTranReactTimes.ToString() != null)
				oneInert[47].Value = model.BloodTranReactTimes;
			else
				oneInert[47].Value = DBNull.Value;
            if (model.DecubitalUlcerTimes.ToString() != null)
				oneInert[48].Value = model.DecubitalUlcerTimes;
			else
				oneInert[48].Value = DBNull.Value;
			if (model.AlergyDrugs != null)
				oneInert[49].Value = model.AlergyDrugs;
			else
				oneInert[49].Value = DBNull.Value;
			if (model.AdverseReactionDrugs != null)
				oneInert[50].Value = model.AdverseReactionDrugs;
			else
				oneInert[50].Value = DBNull.Value;
			if (model.MrValue != null)
				oneInert[51].Value = model.MrValue;
			else
				oneInert[51].Value = DBNull.Value;
			if (model.MrQuality != null)
				oneInert[52].Value = model.MrQuality;
			else
				oneInert[52].Value = DBNull.Value;
            if (model.FollowIndicator.ToString() != null)
				oneInert[53].Value = model.FollowIndicator;
			else
				oneInert[53].Value = DBNull.Value;
			if (model.FollowInterval.ToString() != null)
				oneInert[54].Value = model.FollowInterval;
			else
				oneInert[54].Value = DBNull.Value;
			if (model.FollowIntervalUnits != null)
				oneInert[55].Value = model.FollowIntervalUnits;
			else
				oneInert[55].Value = DBNull.Value;
			if (model.Director != null)
				oneInert[56].Value = model.Director;
			else
				oneInert[56].Value = DBNull.Value;
			if (model.AttendingDoctor != null)
				oneInert[57].Value = model.AttendingDoctor;
			else
				oneInert[57].Value = DBNull.Value;
			if (model.DoctorInCharge != null)
				oneInert[58].Value = model.DoctorInCharge;
			else
				oneInert[58].Value = DBNull.Value;
			if (model.DischargeDisposition != null)
				oneInert[59].Value = model.DischargeDisposition;
			else
				oneInert[59].Value = DBNull.Value;
            if (model.TotalCosts.ToString() != null)
				oneInert[60].Value = model.TotalCosts;
			else
				oneInert[60].Value = DBNull.Value;
			if (model.TotalPayments.ToString() != null)
				oneInert[61].Value = model.TotalPayments;
			else
				oneInert[61].Value = DBNull.Value;
			if (model.CatalogDate > DateTime.MinValue)
				oneInert[62].Value = model.CatalogDate;
			else
				oneInert[62].Value = DBNull.Value;
			if (model.Cataloger != null)
				oneInert[63].Value = model.Cataloger;
			else
				oneInert[63].Value = DBNull.Value;
			if (model.Reserved01 != null)
				oneInert[64].Value = model.Reserved01;
			else
				oneInert[64].Value = DBNull.Value;
			if (model.Reserved02 != null)
				oneInert[65].Value = model.Reserved02;
			else
				oneInert[65].Value = DBNull.Value;
			if (model.Reserved03 != null)
				oneInert[66].Value = model.Reserved03;
			else
				oneInert[66].Value = DBNull.Value;
			if (model.Reserved04 != null)
				oneInert[67].Value = model.Reserved04;
			else
				oneInert[67].Value = DBNull.Value;
			if (model.Reserved05 != null)
				oneInert[68].Value = model.Reserved05;
			else
				oneInert[68].Value = DBNull.Value;
			if (model.Reserved06 != null)
				oneInert[69].Value = model.Reserved06;
			else
				oneInert[69].Value = DBNull.Value;
			if (model.Reserved07 != null)
				oneInert[70].Value = model.Reserved07;
			else
				oneInert[70].Value = DBNull.Value;
			if (model.Reserved08 != null)
				oneInert[71].Value = model.Reserved08;
			else
				oneInert[71].Value = DBNull.Value;
			if (model.Reserved09 != null)
				oneInert[72].Value = model.Reserved09;
			else
				oneInert[72].Value = DBNull.Value;
			if (model.Reserved10 != null)
				oneInert[73].Value = model.Reserved10;
			else
				oneInert[73].Value = DBNull.Value;
			if (model.ReservedDate01 > DateTime.MinValue)
				oneInert[74].Value = model.ReservedDate01;
			else
				oneInert[74].Value = DBNull.Value;
			if (model.ReservedDate02 > DateTime.MinValue)
				oneInert[75].Value = model.ReservedDate02;
			else
				oneInert[75].Value = DBNull.Value;
			if (model.BodyHeight.ToString() != null)
				oneInert[76].Value = model.BodyHeight;
			else
				oneInert[76].Value = DBNull.Value;
			if (model.BodyWeight.ToString() != null)
				oneInert[77].Value = model.BodyWeight;
			else
				oneInert[77].Value = DBNull.Value;
			if (model.PatientCondition != null)
				oneInert[78].Value = model.PatientCondition;
			else
				oneInert[78].Value = DBNull.Value;
			if (model.Abnormal != null)
				oneInert[79].Value = model.Abnormal;
			else
				oneInert[79].Value = DBNull.Value;
	
		return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans,CommandType.Text, MED_PAT_VISIT_Insert, oneInert);

		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedPatVisit 
		///Update Table     MED_PAT_VISIT
		/// </summary>
        public int UpdateMedPatVisit(MedPatVisit model, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneUpdate = GetParameter("UpdateMedPatVisit");
			if (model.PatientId != null)
				oneUpdate[0].Value = model.PatientId;
			else
				oneUpdate[0].Value = DBNull.Value;
            if (model.VisitId.ToString() != null)
				oneUpdate[1].Value = model.VisitId;
			else
				oneUpdate[1].Value = DBNull.Value;
			if (model.DEPT_ADMISSION_TO != null)
				oneUpdate[2].Value = model.DEPT_ADMISSION_TO;
			else
				oneUpdate[2].Value = DBNull.Value;
			if (model.AdmissionDateTime > DateTime.MinValue)
				oneUpdate[3].Value = model.AdmissionDateTime;
			else
				oneUpdate[3].Value = DBNull.Value;
			if (model.DeptDischargeFrom != null)
				oneUpdate[4].Value = model.DeptDischargeFrom;
			else
				oneUpdate[4].Value = DBNull.Value;
			if (model.DischargeDateTime > DateTime.MinValue)
				oneUpdate[5].Value = model.DischargeDateTime;
			else
				oneUpdate[5].Value = DBNull.Value;
			if (model.Occupation != null)
				oneUpdate[6].Value = model.Occupation;
			else
				oneUpdate[6].Value = DBNull.Value;
			if (model.MaritalStatus != null)
				oneUpdate[7].Value = model.MaritalStatus;
			else
				oneUpdate[7].Value = DBNull.Value;
			if (model.Identity != null)
				oneUpdate[8].Value = model.Identity;
			else
				oneUpdate[8].Value = DBNull.Value;
			if (model.ArmedServices != null)
				oneUpdate[9].Value = model.ArmedServices;
			else
				oneUpdate[9].Value = DBNull.Value;
			if (model.Duty != null)
				oneUpdate[10].Value = model.Duty;
			else
				oneUpdate[10].Value = DBNull.Value;
			if (model.TopUnit != null)
				oneUpdate[11].Value = model.TopUnit;
			else
				oneUpdate[11].Value = DBNull.Value;
            if (model.ServiceSystemIndicator.ToString() != null)
				oneUpdate[12].Value = model.ServiceSystemIndicator;
			else
				oneUpdate[12].Value = DBNull.Value;
			if (model.UnitInContract != null)
				oneUpdate[13].Value = model.UnitInContract;
			else
				oneUpdate[13].Value = DBNull.Value;
			if (model.ChargeType != null)
				oneUpdate[14].Value = model.ChargeType;
			else
				oneUpdate[14].Value = DBNull.Value;
            if (model.WorkingStatus.ToString() != null)
				oneUpdate[15].Value = model.WorkingStatus;
			else
				oneUpdate[15].Value = DBNull.Value;
			if (model.InsuranceType != null)
				oneUpdate[16].Value = model.InsuranceType;
			else
				oneUpdate[16].Value = DBNull.Value;
			if (model.InsuranceNo != null)
				oneUpdate[17].Value = model.InsuranceNo;
			else
				oneUpdate[17].Value = DBNull.Value;
			if (model.ServiceAgency != null)
				oneUpdate[18].Value = model.ServiceAgency;
			else
				oneUpdate[18].Value = DBNull.Value;
			if (model.MailingAddress != null)
				oneUpdate[19].Value = model.MailingAddress;
			else
				oneUpdate[19].Value = DBNull.Value;
			if (model.ZipCode != null)
				oneUpdate[20].Value = model.ZipCode;
			else
				oneUpdate[20].Value = DBNull.Value;
			if (model.NextOfKin != null)
				oneUpdate[21].Value = model.NextOfKin;
			else
				oneUpdate[21].Value = DBNull.Value;
			if (model.Relationship != null)
				oneUpdate[22].Value = model.Relationship;
			else
				oneUpdate[22].Value = DBNull.Value;
			if (model.NextOfKinAddr != null)
				oneUpdate[23].Value = model.NextOfKinAddr;
			else
				oneUpdate[23].Value = DBNull.Value;
			if (model.NextOfKinZipcode != null)
				oneUpdate[24].Value = model.NextOfKinZipcode;
			else
				oneUpdate[24].Value = DBNull.Value;
			if (model.NextOfKinPhone != null)
				oneUpdate[25].Value = model.NextOfKinPhone;
			else
				oneUpdate[25].Value = DBNull.Value;
			if (model.PatientSource != null)
				oneUpdate[26].Value = model.PatientSource;
			else
				oneUpdate[26].Value = DBNull.Value;
			if (model.AdmissionCause != null)
				oneUpdate[27].Value = model.AdmissionCause;
			else
				oneUpdate[27].Value = DBNull.Value;
			if (model.ConsultingDate > DateTime.MinValue)
				oneUpdate[28].Value = model.ConsultingDate;
			else
				oneUpdate[28].Value = DBNull.Value;
			if (model.PatAdmCondition != null)
				oneUpdate[29].Value = model.PatAdmCondition;
			else
				oneUpdate[29].Value = DBNull.Value;
			if (model.ConsultingDoctor != null)
				oneUpdate[30].Value = model.ConsultingDoctor;
			else
				oneUpdate[30].Value = DBNull.Value;
			if (model.AdmittedBy != null)
				oneUpdate[31].Value = model.AdmittedBy;
			else
				oneUpdate[31].Value = DBNull.Value;
            if (model.EmerTreatTimes.ToString() != null)
				oneUpdate[32].Value = model.EmerTreatTimes;
			else
				oneUpdate[32].Value = DBNull.Value;
            if (model.EscEmerTimes.ToString() != null)
				oneUpdate[33].Value = model.EscEmerTimes;
			else
				oneUpdate[33].Value = DBNull.Value;
            if (model.SeriousCondDays.ToString() != null)
				oneUpdate[34].Value = model.SeriousCondDays;
			else
				oneUpdate[34].Value = DBNull.Value;
            if (model.CriticalCondDays.ToString() != null)
				oneUpdate[35].Value = model.CriticalCondDays;
			else
				oneUpdate[35].Value = DBNull.Value;
            if (model.IcuDays.ToString() != null)
				oneUpdate[36].Value = model.IcuDays;
			else
				oneUpdate[36].Value = DBNull.Value;
            if (model.CcuDays.ToString() != null)
				oneUpdate[37].Value = model.CcuDays;
			else
				oneUpdate[37].Value = DBNull.Value;
            if (model.SpecLevelNursDays.ToString() != null)
				oneUpdate[38].Value = model.SpecLevelNursDays;
			else
				oneUpdate[38].Value = DBNull.Value;
            if (model.FirstLevelNursDays.ToString() != null)
				oneUpdate[39].Value = model.FirstLevelNursDays;
			else
				oneUpdate[39].Value = DBNull.Value;
            if (model.SecondLevelNursDays.ToString() != null)
				oneUpdate[40].Value = model.SecondLevelNursDays;
			else
				oneUpdate[40].Value = DBNull.Value;
            if (model.AutopsyIndicator.ToString() != null)
				oneUpdate[41].Value = model.AutopsyIndicator;
			else
				oneUpdate[41].Value = DBNull.Value;
			if (model.BloodType != null)
				oneUpdate[42].Value = model.BloodType;
			else
				oneUpdate[42].Value = DBNull.Value;
			if (model.BloodTypeRh != null)
				oneUpdate[43].Value = model.BloodTypeRh;
			else
				oneUpdate[43].Value = DBNull.Value;
            if (model.InfusionReactTimes.ToString() != null)
				oneUpdate[44].Value = model.InfusionReactTimes;
			else
				oneUpdate[44].Value = DBNull.Value;
            if (model.BloodTranTimes.ToString() != null)
				oneUpdate[45].Value = model.BloodTranTimes;
			else
				oneUpdate[45].Value = DBNull.Value;
            if (model.BloodTranVol.ToString() != null)
				oneUpdate[46].Value = model.BloodTranVol;
			else
				oneUpdate[46].Value = DBNull.Value;
            if (model.BloodTranReactTimes.ToString() != null)
				oneUpdate[47].Value = model.BloodTranReactTimes;
			else
				oneUpdate[47].Value = DBNull.Value;
            if (model.DecubitalUlcerTimes.ToString() != null)
				oneUpdate[48].Value = model.DecubitalUlcerTimes;
			else
				oneUpdate[48].Value = DBNull.Value;
			if (model.AlergyDrugs != null)
				oneUpdate[49].Value = model.AlergyDrugs;
			else
				oneUpdate[49].Value = DBNull.Value;
			if (model.AdverseReactionDrugs != null)
				oneUpdate[50].Value = model.AdverseReactionDrugs;
			else
				oneUpdate[50].Value = DBNull.Value;
			if (model.MrValue != null)
				oneUpdate[51].Value = model.MrValue;
			else
				oneUpdate[51].Value = DBNull.Value;
			if (model.MrQuality != null)
				oneUpdate[52].Value = model.MrQuality;
			else
				oneUpdate[52].Value = DBNull.Value;
            if (model.FollowIndicator.ToString() != null)
				oneUpdate[53].Value = model.FollowIndicator;
			else
				oneUpdate[53].Value = DBNull.Value;
			if (model.FollowInterval.ToString() != null)
				oneUpdate[54].Value = model.FollowInterval;
			else
				oneUpdate[54].Value = DBNull.Value;
			if (model.FollowIntervalUnits != null)
				oneUpdate[55].Value = model.FollowIntervalUnits;
			else
				oneUpdate[55].Value = DBNull.Value;
			if (model.Director != null)
				oneUpdate[56].Value = model.Director;
			else
				oneUpdate[56].Value = DBNull.Value;
			if (model.AttendingDoctor != null)
				oneUpdate[57].Value = model.AttendingDoctor;
			else
				oneUpdate[57].Value = DBNull.Value;
			if (model.DoctorInCharge != null)
				oneUpdate[58].Value = model.DoctorInCharge;
			else
				oneUpdate[58].Value = DBNull.Value;
			if (model.DischargeDisposition != null)
				oneUpdate[59].Value = model.DischargeDisposition;
			else
				oneUpdate[59].Value = DBNull.Value;
            if (model.TotalCosts.ToString() != null)
				oneUpdate[60].Value = model.TotalCosts;
			else
				oneUpdate[60].Value = DBNull.Value;
			if (model.TotalPayments.ToString() != null)
				oneUpdate[61].Value = model.TotalPayments;
			else
				oneUpdate[61].Value = DBNull.Value;
			if (model.CatalogDate > DateTime.MinValue)
				oneUpdate[62].Value = model.CatalogDate;
			else
				oneUpdate[62].Value = DBNull.Value;
			if (model.Cataloger != null)
				oneUpdate[63].Value = model.Cataloger;
			else
				oneUpdate[63].Value = DBNull.Value;
			if (model.Reserved01 != null)
				oneUpdate[64].Value = model.Reserved01;
			else
				oneUpdate[64].Value = DBNull.Value;
			if (model.Reserved02 != null)
				oneUpdate[65].Value = model.Reserved02;
			else
				oneUpdate[65].Value = DBNull.Value;
			if (model.Reserved03 != null)
				oneUpdate[66].Value = model.Reserved03;
			else
				oneUpdate[66].Value = DBNull.Value;
			if (model.Reserved04 != null)
				oneUpdate[67].Value = model.Reserved04;
			else
				oneUpdate[67].Value = DBNull.Value;
			if (model.Reserved05 != null)
				oneUpdate[68].Value = model.Reserved05;
			else
				oneUpdate[68].Value = DBNull.Value;
			if (model.Reserved06 != null)
				oneUpdate[69].Value = model.Reserved06;
			else
				oneUpdate[69].Value = DBNull.Value;
			if (model.Reserved07 != null)
				oneUpdate[70].Value = model.Reserved07;
			else
				oneUpdate[70].Value = DBNull.Value;
			if (model.Reserved08 != null)
				oneUpdate[71].Value = model.Reserved08;
			else
				oneUpdate[71].Value = DBNull.Value;
			if (model.Reserved09 != null)
				oneUpdate[72].Value = model.Reserved09;
			else
				oneUpdate[72].Value = DBNull.Value;
			if (model.Reserved10 != null)
				oneUpdate[73].Value = model.Reserved10;
			else
				oneUpdate[73].Value = DBNull.Value;
			if (model.ReservedDate01 > DateTime.MinValue)
				oneUpdate[74].Value = model.ReservedDate01;
			else
				oneUpdate[74].Value = DBNull.Value;
			if (model.ReservedDate02 > DateTime.MinValue)
				oneUpdate[75].Value = model.ReservedDate02;
			else
				oneUpdate[75].Value = DBNull.Value;
			if (model.BodyHeight.ToString() != null)
				oneUpdate[76].Value = model.BodyHeight;
			else
				oneUpdate[76].Value = DBNull.Value;
			if (model.BodyWeight.ToString() != null)
				oneUpdate[77].Value = model.BodyWeight;
			else
				oneUpdate[77].Value = DBNull.Value;
			if (model.PatientCondition != null)
				oneUpdate[78].Value = model.PatientCondition;
			else
				oneUpdate[78].Value = DBNull.Value;
			if (model.Abnormal != null)
				oneUpdate[79].Value = model.Abnormal;
			else
				oneUpdate[79].Value = DBNull.Value;
			if (model.PatientId != null)
				oneUpdate[80].Value =model.PatientId;
			else
				oneUpdate[80].Value = DBNull.Value;
			if (model.VisitId.ToString() != null)
				oneUpdate[81].Value =model.VisitId;
			else
				oneUpdate[81].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PAT_VISIT_Update, oneUpdate);

		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedPatVisit 
		///Delete Table MED_PAT_VISIT by (string PATIENT_ID,decimal VISIT_ID)
		/// </summary>
        public int DeleteMedPatVisit(string PATIENT_ID, decimal VISIT_ID, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneDelete = GetParameter("DeleteMedPatVisit");
			if (PATIENT_ID != null)
				oneDelete[0].Value =PATIENT_ID;
			else
				oneDelete[0].Value = DBNull.Value;
            if (VISIT_ID.ToString() != null)
				oneDelete[1].Value =VISIT_ID;
			else
				oneDelete[1].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PAT_VISIT_Delete, oneDelete);

		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedPatVisit 
		///select Table MED_PAT_VISIT by (string PATIENT_ID,decimal VISIT_ID)
		/// </summary>
        public MedPatVisit SelectMedPatVisit(string PATIENT_ID, decimal VISIT_ID, System.Data.Common.DbConnection oleCisConn)
		{
			MedPatVisit model;
			OracleParameter[] parameterValues = GetParameter("SelectMedPatVisit");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
                using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PAT_VISIT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedPatVisit();
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
							model.DEPT_ADMISSION_TO = oleReader["DEPT_ADMISSION_TO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.DeptDischargeFrom = oleReader["DEPT_DISCHARGE_FROM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.DischargeDateTime = DateTime.Parse(oleReader["DISCHARGE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Occupation = oleReader["OCCUPATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.MaritalStatus = oleReader["MARITAL_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Identity = oleReader["IDENTITY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.ArmedServices = oleReader["ARMED_SERVICES"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Duty = oleReader["DUTY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.TopUnit = oleReader["TOP_UNIT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.ServiceSystemIndicator = decimal.Parse(oleReader["SERVICE_SYSTEM_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.UnitInContract = oleReader["UNIT_IN_CONTRACT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.ChargeType = oleReader["CHARGE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.WorkingStatus = decimal.Parse(oleReader["WORKING_STATUS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.InsuranceType = oleReader["INSURANCE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.InsuranceNo = oleReader["INSURANCE_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.ServiceAgency = oleReader["SERVICE_AGENCY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.MailingAddress = oleReader["MAILING_ADDRESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.ZipCode = oleReader["ZIP_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.NextOfKin = oleReader["NEXT_OF_KIN"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.Relationship = oleReader["RELATIONSHIP"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.NextOfKinAddr = oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.NextOfKinZipcode = oleReader["NEXT_OF_KIN_ZIPCODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.NextOfKinPhone = oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(26))
						{
                            model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
						}
						if (!oleReader.IsDBNull(27))
						{
							model.AdmissionCause = oleReader["ADMISSION_CAUSE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.ConsultingDate = DateTime.Parse(oleReader["CONSULTING_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.PatAdmCondition = oleReader["PAT_ADM_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.ConsultingDoctor = oleReader["CONSULTING_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(31))
						{
							model.AdmittedBy = oleReader["ADMITTED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(32))
						{
							model.EmerTreatTimes = decimal.Parse(oleReader["EMER_TREAT_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(33))
						{
							model.EscEmerTimes = decimal.Parse(oleReader["ESC_EMER_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(34))
						{
							model.SeriousCondDays = decimal.Parse(oleReader["SERIOUS_COND_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(35))
						{
							model.CriticalCondDays = decimal.Parse(oleReader["CRITICAL_COND_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(36))
						{
							model.IcuDays = decimal.Parse(oleReader["ICU_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(37))
						{
							model.CcuDays = decimal.Parse(oleReader["CCU_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(38))
						{
							model.SpecLevelNursDays = decimal.Parse(oleReader["SPEC_LEVEL_NURS_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(39))
						{
							model.FirstLevelNursDays = decimal.Parse(oleReader["FIRST_LEVEL_NURS_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(40))
						{
							model.SecondLevelNursDays = decimal.Parse(oleReader["SECOND_LEVEL_NURS_DAYS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(41))
						{
							model.AutopsyIndicator = decimal.Parse(oleReader["AUTOPSY_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(42))
						{
							model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(43))
						{
							model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(44))
						{
							model.InfusionReactTimes = decimal.Parse(oleReader["INFUSION_REACT_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(45))
						{
							model.BloodTranTimes = decimal.Parse(oleReader["BLOOD_TRAN_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(46))
						{
							model.BloodTranVol = decimal.Parse(oleReader["BLOOD_TRAN_VOL"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(47))
						{
							model.BloodTranReactTimes = decimal.Parse(oleReader["BLOOD_TRAN_REACT_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(48))
						{
							model.DecubitalUlcerTimes = decimal.Parse(oleReader["DECUBITAL_ULCER_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(49))
						{
							model.AlergyDrugs = oleReader["ALERGY_DRUGS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(50))
						{
							model.AdverseReactionDrugs = oleReader["ADVERSE_REACTION_DRUGS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(51))
						{
							model.MrValue = oleReader["MR_VALUE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(52))
						{
							model.MrQuality = oleReader["MR_QUALITY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(53))
						{
							model.FollowIndicator = decimal.Parse(oleReader["FOLLOW_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(54))
						{
							model.FollowInterval = decimal.Parse(oleReader["FOLLOW_INTERVAL"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(55))
						{
							model.FollowIntervalUnits = oleReader["FOLLOW_INTERVAL_UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(56))
						{
							model.Director = oleReader["DIRECTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(57))
						{
							model.AttendingDoctor = oleReader["ATTENDING_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(58))
						{
							model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(59))
						{
							model.DischargeDisposition = oleReader["DISCHARGE_DISPOSITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(60))
						{
							model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(61))
						{
							model.TotalPayments = decimal.Parse(oleReader["TOTAL_PAYMENTS"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(62))
						{
							model.CatalogDate = DateTime.Parse(oleReader["CATALOG_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(63))
						{
							model.Cataloger = oleReader["CATALOGER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(64))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(65))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(66))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(67))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(68))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(69))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(70))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(71))
						{
							model.Reserved08 = oleReader["RESERVED08"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(72))
						{
							model.Reserved09 = oleReader["RESERVED09"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(73))
						{
							model.Reserved10 = oleReader["RESERVED10"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(74))
						{
							model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(75))
						{
							model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(76))
						{
							model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(77))
						{
							model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(78))
						{
							model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(79))
						{
							model.Abnormal = oleReader["ABNORMAL"].ToString().Trim() ;
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
		public List<MedPatVisit> SelectMedPatVisitList( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedPatVisit> modelList = new List<MedPatVisit>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PAT_VISIT_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedPatVisit model = new MedPatVisit();
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
						model.DEPT_ADMISSION_TO = oleReader["DEPT_ADMISSION_TO"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(3))
					{
						model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(4))
					{
						model.DeptDischargeFrom = oleReader["DEPT_DISCHARGE_FROM"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(5))
					{
						model.DischargeDateTime = DateTime.Parse(oleReader["DISCHARGE_DATE_TIME"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(6))
					{
						model.Occupation = oleReader["OCCUPATION"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(7))
					{
						model.MaritalStatus = oleReader["MARITAL_STATUS"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(8))
					{
						model.Identity = oleReader["IDENTITY"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(9))
					{
						model.ArmedServices = oleReader["ARMED_SERVICES"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(10))
					{
						model.Duty = oleReader["DUTY"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(11))
					{
						model.TopUnit = oleReader["TOP_UNIT"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(12))
					{
						model.ServiceSystemIndicator = decimal.Parse(oleReader["SERVICE_SYSTEM_INDICATOR"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(13))
					{
						model.UnitInContract = oleReader["UNIT_IN_CONTRACT"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(14))
					{
						model.ChargeType = oleReader["CHARGE_TYPE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(15))
					{
						model.WorkingStatus = decimal.Parse(oleReader["WORKING_STATUS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(16))
					{
						model.InsuranceType = oleReader["INSURANCE_TYPE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(17))
					{
						model.InsuranceNo = oleReader["INSURANCE_NO"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(18))
					{
						model.ServiceAgency = oleReader["SERVICE_AGENCY"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(19))
					{
						model.MailingAddress = oleReader["MAILING_ADDRESS"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(20))
					{
						model.ZipCode = oleReader["ZIP_CODE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(21))
					{
						model.NextOfKin = oleReader["NEXT_OF_KIN"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(22))
					{
						model.Relationship = oleReader["RELATIONSHIP"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(23))
					{
						model.NextOfKinAddr = oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(24))
					{
						model.NextOfKinZipcode = oleReader["NEXT_OF_KIN_ZIPCODE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(25))
					{
						model.NextOfKinPhone = oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(26))
					{
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
					}
					if (!oleReader.IsDBNull(27))
					{
						model.AdmissionCause = oleReader["ADMISSION_CAUSE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(28))
					{
						model.ConsultingDate = DateTime.Parse(oleReader["CONSULTING_DATE"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(29))
					{
						model.PatAdmCondition = oleReader["PAT_ADM_CONDITION"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(30))
					{
						model.ConsultingDoctor = oleReader["CONSULTING_DOCTOR"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(31))
					{
						model.AdmittedBy = oleReader["ADMITTED_BY"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(32))
					{
						model.EmerTreatTimes = decimal.Parse(oleReader["EMER_TREAT_TIMES"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(33))
					{
						model.EscEmerTimes = decimal.Parse(oleReader["ESC_EMER_TIMES"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(34))
					{
						model.SeriousCondDays = decimal.Parse(oleReader["SERIOUS_COND_DAYS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(35))
					{
						model.CriticalCondDays = decimal.Parse(oleReader["CRITICAL_COND_DAYS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(36))
					{
						model.IcuDays = decimal.Parse(oleReader["ICU_DAYS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(37))
					{
						model.CcuDays = decimal.Parse(oleReader["CCU_DAYS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(38))
					{
						model.SpecLevelNursDays = decimal.Parse(oleReader["SPEC_LEVEL_NURS_DAYS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(39))
					{
						model.FirstLevelNursDays = decimal.Parse(oleReader["FIRST_LEVEL_NURS_DAYS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(40))
					{
						model.SecondLevelNursDays = decimal.Parse(oleReader["SECOND_LEVEL_NURS_DAYS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(41))
					{
						model.AutopsyIndicator = decimal.Parse(oleReader["AUTOPSY_INDICATOR"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(42))
					{
						model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(43))
					{
						model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(44))
					{
						model.InfusionReactTimes = decimal.Parse(oleReader["INFUSION_REACT_TIMES"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(45))
					{
						model.BloodTranTimes = decimal.Parse(oleReader["BLOOD_TRAN_TIMES"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(46))
					{
						model.BloodTranVol = decimal.Parse(oleReader["BLOOD_TRAN_VOL"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(47))
					{
						model.BloodTranReactTimes = decimal.Parse(oleReader["BLOOD_TRAN_REACT_TIMES"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(48))
					{
						model.DecubitalUlcerTimes = decimal.Parse(oleReader["DECUBITAL_ULCER_TIMES"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(49))
					{
						model.AlergyDrugs = oleReader["ALERGY_DRUGS"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(50))
					{
						model.AdverseReactionDrugs = oleReader["ADVERSE_REACTION_DRUGS"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(51))
					{
						model.MrValue = oleReader["MR_VALUE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(52))
					{
						model.MrQuality = oleReader["MR_QUALITY"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(53))
					{
						model.FollowIndicator = decimal.Parse(oleReader["FOLLOW_INDICATOR"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(54))
					{
						model.FollowInterval = decimal.Parse(oleReader["FOLLOW_INTERVAL"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(55))
					{
						model.FollowIntervalUnits = oleReader["FOLLOW_INTERVAL_UNITS"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(56))
					{
						model.Director = oleReader["DIRECTOR"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(57))
					{
						model.AttendingDoctor = oleReader["ATTENDING_DOCTOR"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(58))
					{
						model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(59))
					{
						model.DischargeDisposition = oleReader["DISCHARGE_DISPOSITION"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(60))
					{
						model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(61))
					{
						model.TotalPayments = decimal.Parse(oleReader["TOTAL_PAYMENTS"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(62))
					{
						model.CatalogDate = DateTime.Parse(oleReader["CATALOG_DATE"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(63))
					{
						model.Cataloger = oleReader["CATALOGER"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(64))
					{
						model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(65))
					{
						model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(66))
					{
						model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(67))
					{
						model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(68))
					{
						model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(69))
					{
						model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(70))
					{
						model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(71))
					{
						model.Reserved08 = oleReader["RESERVED08"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(72))
					{
						model.Reserved09 = oleReader["RESERVED09"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(73))
					{
						model.Reserved10 = oleReader["RESERVED10"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(74))
					{
						model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(75))
					{
						model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(76))
					{
						model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(77))
					{
						model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(78))
					{
						model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(79))
					{
						model.Abnormal = oleReader["ABNORMAL"].ToString().Trim() ;
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
