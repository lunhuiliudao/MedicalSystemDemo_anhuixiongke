
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:47:28
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedScheduledOperationName
	/// </summary>
	[Serializable]
	public class MedScheduledOperationName:ModelBase
	{
		#region define variable
		private string _patientId;
		private decimal _visitId;
		private decimal _scheduleId;
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
		///病人标识号;非空
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
		///病人本次住院标识;对门诊病人为0
		///</summary>
		public decimal VisitId
		{
			get {return _visitId;}
			set {_visitId = value;}
		}

		///<summary>
		///手术安排标识;同手术安排表中的手术安排标识
		///</summary>
		public decimal ScheduleId
		{
			get {return _scheduleId;}
			set {_scheduleId = value;}
		}

		///<summary>
		///手术序号;病人本次手术中的第几个手术
		///</summary>
        public decimal OperNo
		{
            get;
            set;
		}

		///<summary>
		///手术;手术名称
		///</summary>
        public string OperName
        {
            get;
            set;
        }

		///<summary>
		///手术等级;指手术规模，取值：特、大、中、小
		///</summary>
        public string OperScale
		{
            get;
            set;
		}

		///<summary>
		///手术编码
		///</summary>
        public string OperCode
		{
            get;
            set;
		}

        /// <summary>
        /// 切开类型
        /// </summary>
        public string WoundType
        {
            get;
            set;
        }

		///<summary>
        /// 保留字段1--HIS Schedule_Id 手术流水号
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

	 
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedScheduledOperationName))
                return false;
            MedScheduledOperationName Oper = (MedScheduledOperationName)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.ScheduleId != Oper.ScheduleId)
                return false;
            if (this.Reserved1 != Oper.Reserved1)
                return false;
            if (this.Reserved2 != Oper.Reserved2)
                return false;
            if (this.Reserved3 != Oper.Reserved3)
                return false;
            if (this.Reserved4 != Oper.Reserved4)
                return false;
          
            return true;
        }
	}
}
