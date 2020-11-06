
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-06-12 12:28:57
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///Patients
	/// </summary>
	[Serializable]
	public class Patients
	{
		#region define variable
		private string _patientId;
		private string _patientCreateDate = String.Empty;
		private string _patientName = String.Empty;
		private string _patientGender = String.Empty;
		private string _patientBirth = String.Empty;
		private string _patientAddress = String.Empty;
		private string _patientAllergies = String.Empty;
		private string _patientTelphone = String.Empty;
		private string _patientMedicareCard = String.Empty;
		private string _patientIdentityCard = String.Empty;
		private decimal _flag;
		#endregion
		
		#region public property
		///<summary>
        ///病人编号（主键） 必须的
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
        ///病人建卡时间
		///</summary>
		public string PatientCreateDate
		{
			get {return _patientCreateDate;}
			set {_patientCreateDate = value;}
		}

		///<summary>
        ///病人姓名    必须的
		///</summary>
		public string PatientName
		{
			get {return _patientName;}
			set {_patientName = value;}
		}

		///<summary>
        ///病人性别  必须的
		///</summary>
		public string PatientGender
		{
			get {return _patientGender;}
			set {_patientGender = value;}
		}

		///<summary>
        ///病人出生日期 必须的
		///</summary>
		public string PatientBirth
		{
			get {return _patientBirth;}
			set {_patientBirth = value;}
		}

		///<summary>
        ///病人住址
		///</summary>
		public string PatientAddress
		{
			get {return _patientAddress;}
			set {_patientAddress = value;}
		}

		///<summary>
        ///病人过往病史
		///</summary>
		public string PatientAllergies
		{
			get {return _patientAllergies;}
			set {_patientAllergies = value;}
		}

		///<summary>
        ///病人电话号码
		///</summary>
		public string PatientTelphone
		{
			get {return _patientTelphone;}
			set {_patientTelphone = value;}
		}

		///<summary>
        ///病人医保号
		///</summary>
		public string PatientMedicareCard
		{
			get {return _patientMedicareCard;}
			set {_patientMedicareCard = value;}
		}

		///<summary>
        ///病人身份证号 必须的
		///</summary>
		public string PatientIdentityCard
		{
			get {return _patientIdentityCard;}
			set {_patientIdentityCard = value;}
		}

		///<summary>
        ///标志位（暂无作用）
		///</summary>
		public decimal Flag
		{
			get {return _flag;}
			set {_flag = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Patients))
                return false;
            Patients Oper = (Patients)obj;
			if (this.PatientId != Oper.PatientId)
                return false;
			if (this.PatientCreateDate != Oper.PatientCreateDate)
                return false;
			if (this.PatientName != Oper.PatientName)
                return false;
			if (this.PatientGender != Oper.PatientGender)
                return false;
			if (this.PatientBirth != Oper.PatientBirth)
                return false;
			if (this.PatientAddress != Oper.PatientAddress)
                return false;
			if (this.PatientAllergies != Oper.PatientAllergies)
                return false;
			if (this.PatientTelphone != Oper.PatientTelphone)
                return false;
			if (this.PatientMedicareCard != Oper.PatientMedicareCard)
                return false;
			if (this.PatientIdentityCard != Oper.PatientIdentityCard)
                return false;
			if (this.Flag != Oper.Flag)
                return false;
            return true;
        }
	}
}
