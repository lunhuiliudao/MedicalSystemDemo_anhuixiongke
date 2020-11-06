
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:55
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedTransfer
	/// </summary>
	[Serializable]
	public class MedTransfer
	{
		#region define variable
		private string _patientId;
		private decimal _visitId;
		private string _deptStayed = String.Empty;
		private DateTime _admissionDateTime;
		private DateTime _dischargeDateTime;
		private string _deptTransferedTo = String.Empty;
		private string _doctorInCharge = String.Empty;
		private string _wardStayed = String.Empty;
		private string _wardTransferedTo = String.Empty;
		private decimal _reserved1;
		private string _bedNo = String.Empty;
		private decimal _reserved2;
		private DateTime _reserved3;
		#endregion
		
		#region public property
		///<summary>
		///病人标识
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
		///病人本次住院标识
		///</summary>
		public decimal VisitId
		{
			get {return _visitId;}
			set {_visitId = value;}
		}

		///<summary>
		///所在科室
		///</summary>
		public string DeptStayed
		{
			get {return _deptStayed;}
			set {_deptStayed = value;}
		}

		///<summary>
		///入科日期及时间
		///</summary>
		public DateTime AdmissionDateTime
		{
			get {return _admissionDateTime;}
			set {_admissionDateTime = value;}
		}

		///<summary>
		///出科日期及时间
		///</summary>
		public DateTime DischargeDateTime
		{
			get {return _dischargeDateTime;}
			set {_dischargeDateTime = value;}
		}

		///<summary>
		///转向科室
		///</summary>
		public string DeptTransferedTo
		{
			get {return _deptTransferedTo;}
			set {_deptTransferedTo = value;}
		}

		///<summary>
		///经治医师
		///</summary>
		public string DoctorInCharge
		{
			get {return _doctorInCharge;}
			set {_doctorInCharge = value;}
		}

		///<summary>
		///所在病区
		///</summary>
		public string WardStayed
		{
			get {return _wardStayed;}
			set {_wardStayed = value;}
		}

		///<summary>
		///转向病区
		///</summary>
		public string WardTransferedTo
		{
			get {return _wardTransferedTo;}
			set {_wardTransferedTo = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public decimal Reserved1
		{
			get {return _reserved1;}
			set {_reserved1 = value;}
		}

		///<summary>
		///床号
		///</summary>
		public string BedNo
		{
			get {return _bedNo;}
			set {_bedNo = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public decimal Reserved2
		{
			get {return _reserved2;}
			set {_reserved2 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public DateTime Reserved3
		{
			get {return _reserved3;}
			set {_reserved3 = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedTransfer))
                return false;
            MedTransfer Oper = (MedTransfer)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.DeptStayed != Oper.DeptStayed)
                return false;
            if (this.AdmissionDateTime != Oper.AdmissionDateTime)
                return false;
            if (this.DischargeDateTime != Oper.DischargeDateTime)
                return false;
            if (this.DeptTransferedTo != Oper.DeptTransferedTo)
                return false;
            if (this.DoctorInCharge != Oper.DoctorInCharge)
                return false;
            if (this.WardStayed != Oper.WardStayed)
                return false;
            if (this.WardTransferedTo != Oper.WardTransferedTo)
                return false;
            if (this.Reserved1 != Oper.Reserved1)
                return false;
            if (this.BedNo != Oper.BedNo)
                return false;
            if (this.Reserved2 != Oper.Reserved2)
                return false;
            if (this.Reserved3 != Oper.Reserved3)
                return false;
            return true;
        }
	}
}
