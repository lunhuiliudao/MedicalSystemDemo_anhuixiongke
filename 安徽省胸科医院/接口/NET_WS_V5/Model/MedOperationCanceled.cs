
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:06:25
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedOperationCanceled
	/// </summary>
	[Serializable]
	public class MedOperationCanceled
	{
		#region define variable
		private string _patientId;
		private decimal _visitId;
		private decimal _cancelId;
		private string _deptStayed = String.Empty;
		private DateTime _scheduledDateTime;
		private string _operatingRoom = String.Empty;
		private string _operatingRoomNo = String.Empty;
		private decimal _sequence;
		private string _diagBeforeOperation = String.Empty;
		private string _patientCondition = String.Empty;
		private string _operationScale = String.Empty;
		private decimal _isolationIndicator;
		private string _operatingDept = String.Empty;
		private string _surgeon = String.Empty;
		private string _firstAssistant = String.Empty;
		private string _secondAssistant = String.Empty;
		private string _thirdAssistant = String.Empty;
		private string _fourthAssistant = String.Empty;
		private string _anesthesiaMethod = String.Empty;
		private string _anesthesiaDoctor = String.Empty;
		private string _anesthesiaAssistant = String.Empty;
		private string _bloodTranDoctor = String.Empty;
		private string _notesOnOperation = String.Empty;
		private string _enteredBy = String.Empty;
		private string _cancelReason = String.Empty;
		private string _reserved1 = String.Empty;
		private string _operationId = String.Empty;
		private string _reserved2 = String.Empty;
		private string _reserved3 = String.Empty;
		private string _reserved4 = String.Empty;
		private string _reserved5 = String.Empty;
		private string _reserved6 = String.Empty;
		private string _reserved7 = String.Empty;
		private string _reserved8 = String.Empty;
		private DateTime _reserved9;
		private DateTime _reserved10;
		private decimal _reserved11;
		private decimal _reserved12;
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
		public string DeptStayed
		{
			get {return _deptStayed;}
			set {_deptStayed = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime ScheduledDateTime
		{
			get {return _scheduledDateTime;}
			set {_scheduledDateTime = value;}
		}

		///<summary>
		///
		///</summary>
		public string OperatingRoom
		{
			get {return _operatingRoom;}
			set {_operatingRoom = value;}
		}

		///<summary>
		///
		///</summary>
		public string OperatingRoomNo
		{
			get {return _operatingRoomNo;}
			set {_operatingRoomNo = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal Sequence
		{
			get {return _sequence;}
			set {_sequence = value;}
		}

		///<summary>
		///
		///</summary>
		public string DiagBeforeOperation
		{
			get {return _diagBeforeOperation;}
			set {_diagBeforeOperation = value;}
		}

		///<summary>
		///
		///</summary>
		public string PatientCondition
		{
			get {return _patientCondition;}
			set {_patientCondition = value;}
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
		public decimal IsolationIndicator
		{
			get {return _isolationIndicator;}
			set {_isolationIndicator = value;}
		}

		///<summary>
		///
		///</summary>
		public string OperatingDept
		{
			get {return _operatingDept;}
			set {_operatingDept = value;}
		}

		///<summary>
		///
		///</summary>
		public string Surgeon
		{
			get {return _surgeon;}
			set {_surgeon = value;}
		}

		///<summary>
		///
		///</summary>
		public string FirstAssistant
		{
			get {return _firstAssistant;}
			set {_firstAssistant = value;}
		}

		///<summary>
		///
		///</summary>
		public string SecondAssistant
		{
			get {return _secondAssistant;}
			set {_secondAssistant = value;}
		}

		///<summary>
		///
		///</summary>
		public string ThirdAssistant
		{
			get {return _thirdAssistant;}
			set {_thirdAssistant = value;}
		}

		///<summary>
		///
		///</summary>
		public string FourthAssistant
		{
			get {return _fourthAssistant;}
			set {_fourthAssistant = value;}
		}

		///<summary>
		///
		///</summary>
		public string AnesthesiaMethod
		{
			get {return _anesthesiaMethod;}
			set {_anesthesiaMethod = value;}
		}

		///<summary>
		///
		///</summary>
		public string AnesthesiaDoctor
		{
			get {return _anesthesiaDoctor;}
			set {_anesthesiaDoctor = value;}
		}

		///<summary>
		///
		///</summary>
		public string AnesthesiaAssistant
		{
			get {return _anesthesiaAssistant;}
			set {_anesthesiaAssistant = value;}
		}

		///<summary>
		///
		///</summary>
		public string BloodTranDoctor
		{
			get {return _bloodTranDoctor;}
			set {_bloodTranDoctor = value;}
		}

		///<summary>
		///
		///</summary>
		public string NotesOnOperation
		{
			get {return _notesOnOperation;}
			set {_notesOnOperation = value;}
		}

		///<summary>
		///
		///</summary>
		public string EnteredBy
		{
			get {return _enteredBy;}
			set {_enteredBy = value;}
		}

		///<summary>
		///
		///</summary>
		public string CancelReason
		{
			get {return _cancelReason;}
			set {_cancelReason = value;}
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
		public string OperationId
		{
			get {return _operationId;}
			set {_operationId = value;}
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
		public string Reserved5
		{
			get {return _reserved5;}
			set {_reserved5 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved6
		{
			get {return _reserved6;}
			set {_reserved6 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved7
		{
			get {return _reserved7;}
			set {_reserved7 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved8
		{
			get {return _reserved8;}
			set {_reserved8 = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime Reserved9
		{
			get {return _reserved9;}
			set {_reserved9 = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime Reserved10
		{
			get {return _reserved10;}
			set {_reserved10 = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal Reserved11
		{
			get {return _reserved11;}
			set {_reserved11 = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal Reserved12
		{
			get {return _reserved12;}
			set {_reserved12 = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedOperationCanceled))
                return false;
            MedOperationCanceled Oper = (MedOperationCanceled)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.CancelId != Oper.CancelId)
                return false;
            if (this.DeptStayed != Oper.DeptStayed)
                return false;
            if (this.ScheduledDateTime != Oper.ScheduledDateTime)
                return false;
            if (this.OperatingRoom != Oper.OperatingRoom)
                return false;
            if (this.OperatingRoomNo != Oper.OperatingRoomNo)
                return false;
            if (this.Sequence != Oper.Sequence)
                return false;
            if (this.DiagBeforeOperation != Oper.DiagBeforeOperation)
                return false;
            if (this.PatientCondition != Oper.PatientCondition)
                return false;
            if (this.OperationScale != Oper.OperationScale)
                return false;
            if (this.IsolationIndicator != Oper.IsolationIndicator)
                return false;
            if (this.OperatingDept != Oper.OperatingDept)
                return false;
            if (this.Surgeon != Oper.Surgeon)
                return false;
            if (this.FirstAssistant != Oper.FirstAssistant)
                return false;
            if (this.SecondAssistant != Oper.SecondAssistant)
                return false;
            if (this.ThirdAssistant != Oper.ThirdAssistant)
                return false;
            if (this.FourthAssistant != Oper.FourthAssistant)
                return false;
            if (this.AnesthesiaMethod != Oper.AnesthesiaMethod)
                return false;
            if (this.AnesthesiaDoctor != Oper.AnesthesiaDoctor)
                return false;
            if (this.AnesthesiaAssistant != Oper.AnesthesiaAssistant)
                return false;
            if (this.BloodTranDoctor != Oper.BloodTranDoctor)
                return false;
            if (this.NotesOnOperation != Oper.NotesOnOperation)
                return false;
            if (this.EnteredBy != Oper.EnteredBy)
                return false;
            if (this.CancelReason != Oper.CancelReason)
                return false;
            if (this.Reserved1 != Oper.Reserved1)
                return false;
            if (this.OperationId != Oper.OperationId)
                return false;
            if (this.Reserved2 != Oper.Reserved2)
                return false;
            if (this.Reserved3 != Oper.Reserved3)
                return false;
            if (this.Reserved4 != Oper.Reserved4)
                return false;
            if (this.Reserved5 != Oper.Reserved5)
                return false;
            if (this.Reserved6 != Oper.Reserved6)
                return false;
            if (this.Reserved7 != Oper.Reserved7)
                return false;
            if (this.Reserved8 != Oper.Reserved8)
                return false;
            if (this.Reserved9 != Oper.Reserved9)
                return false;
            if (this.Reserved10 != Oper.Reserved10)
                return false;
            if (this.Reserved11 != Oper.Reserved11)
                return false;
            if (this.Reserved12 != Oper.Reserved12)
                return false;
            return true;
        }
	}
}
