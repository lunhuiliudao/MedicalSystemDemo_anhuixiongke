
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-06-12 12:28:20
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///Medicalcases
	/// </summary>
	[Serializable]
	public class Medicalcases
	{
		#region define variable
		private string _medicalId;
		private string _patientId = String.Empty;
		private string _patientName = String.Empty;
		private string _userId = String.Empty;
		private string _userName = String.Empty;
		private string _officeName = String.Empty;
		private string _createDate = String.Empty;
		private string _createTime = String.Empty;
		private string _visitDate = String.Empty;
		private string _visitNo = String.Empty;
		private DateTime _visitTime;
		private decimal _flag;
		private decimal _signPage;
		#endregion
		
		#region public property
		///<summary>
		///挂号唯一标识（主键）（=  VISIT_DATE+” ”+VISIT_NO）
		///</summary>
		public string MedicalId
		{
			get {return _medicalId;}
			set {_medicalId = value;}
		}

		///<summary>
        ///病人唯一标识号
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
        ///病人姓名
		///</summary>
		public string PatientName
		{
			get {return _patientName;}
			set {_patientName = value;}
		}

		///<summary>
        ///医生唯一标识
		///</summary>
		public string UserId
		{
			get {return _userId;}
			set {_userId = value;}
		}

		///<summary>
        ///医生姓名
		///</summary>
		public string UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}

		///<summary>
        ///科室名称
		///</summary>
		public string OfficeName
		{
			get {return _officeName;}
			set {_officeName = value;}
		}

		///<summary>
        ///记录创建日期
		///</summary>
		public string CreateDate
		{
			get {return _createDate;}
			set {_createDate = value;}
		}

		///<summary>
        ///记录创建时间
		///</summary>
		public string CreateTime
		{
			get {return _createTime;}
			set {_createTime = value;}
		}

		///<summary>
        ///挂号日期
		///</summary>
		public string VisitDate
		{
			get {return _visitDate;}
			set {_visitDate = value;}
		}

		///<summary>
        ///挂号流水号
		///</summary>
		public string VisitNo
		{
			get {return _visitNo;}
			set {_visitNo = value;}
		}

		///<summary>
        ///挂号时间
		///</summary>
		public DateTime VisitTime
		{
			get {return _visitTime;}
			set {_visitTime = value;}
		}

		///<summary>
        ///标志位（暂无作用）
		///</summary>
		public decimal Flag
		{
			get {return _flag;}
			set {_flag = value;}
		}

		///<summary>
        ///是否写病历
		///</summary>
		public decimal SignPage
		{
			get {return _signPage;}
			set {_signPage = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Medicalcases))
                return false;
            Medicalcases Oper = (Medicalcases)obj;
			if (this.MedicalId != Oper.MedicalId)
                return false;
			if (this.PatientId != Oper.PatientId)
                return false;
			if (this.PatientName != Oper.PatientName)
                return false;
			if (this.UserId != Oper.UserId)
                return false;
			if (this.UserName != Oper.UserName)
                return false;
			if (this.OfficeName != Oper.OfficeName)
                return false;
			if (this.CreateDate != Oper.CreateDate)
                return false;
			if (this.CreateTime != Oper.CreateTime)
                return false;
			if (this.VisitDate != Oper.VisitDate)
                return false;
			if (this.VisitNo != Oper.VisitNo)
                return false;
			if (this.VisitTime != Oper.VisitTime)
                return false;
			if (this.Flag != Oper.Flag)
                return false;
			if (this.SignPage != Oper.SignPage)
                return false;
            return true;
        }
	}
}
