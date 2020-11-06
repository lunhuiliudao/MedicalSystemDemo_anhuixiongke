
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010-11-10 13:32:23
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedOperationNameCanceled
	/// </summary>
	[Serializable]
	public class MedOperationNameCanceled
	{
		#region define variable
		private string _patientId;
		private decimal _visitId;
		private decimal _cancelId;
		private decimal _operationNo;
		private string _operation = String.Empty;
		private string _operationScale = String.Empty;
		private string _operationCode = String.Empty;
		private string _reserved1 = String.Empty;
		private string _reserved2 = String.Empty;
		private string _reserved3 = String.Empty;
		private string _reserved4 = String.Empty;
		private decimal _reserved5;
		#endregion
		
		#region public property
		///<summary>
		///
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal VisitId
		{
			get {return _visitId;}
			set {_visitId = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal CancelId
		{
			get {return _cancelId;}
			set {_cancelId = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal OperationNo
		{
			get {return _operationNo;}
			set {_operationNo = value;}
		}

		///<summary>
		///
		///</summary>
		public string Operation
		{
			get {return _operation;}
			set {_operation = value;}
		}

		///<summary>
		///
		///</summary>
		public string OperationScale
		{
			get {return _operationScale;}
			set {_operationScale = value;}
		}

		///<summary>
		///
		///</summary>
		public string OperationCode
		{
			get {return _operationCode;}
			set {_operationCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved1
		{
			get {return _reserved1;}
			set {_reserved1 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved2
		{
			get {return _reserved2;}
			set {_reserved2 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved3
		{
			get {return _reserved3;}
			set {_reserved3 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved4
		{
			get {return _reserved4;}
			set {_reserved4 = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal Reserved5
		{
			get {return _reserved5;}
			set {_reserved5 = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedOperationNameCanceled))
                return false;
            MedOperationNameCanceled Oper = (MedOperationNameCanceled)obj;
			if (this.PatientId != Oper.PatientId)
                return false;
			if (this.VisitId != Oper.VisitId)
                return false;
			if (this.CancelId != Oper.CancelId)
                return false;
			if (this.OperationNo != Oper.OperationNo)
                return false;
			if (this.Operation != Oper.Operation)
                return false;
			if (this.OperationScale != Oper.OperationScale)
                return false;
			if (this.OperationCode != Oper.OperationCode)
                return false;
			if (this.Reserved1 != Oper.Reserved1)
                return false;
			if (this.Reserved2 != Oper.Reserved2)
                return false;
			if (this.Reserved3 != Oper.Reserved3)
                return false;
			if (this.Reserved4 != Oper.Reserved4)
                return false;
			if (this.Reserved5 != Oper.Reserved5)
                return false;
            return true;
        }
	}
}
