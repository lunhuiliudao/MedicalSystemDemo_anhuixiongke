
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:05:54
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedVsHisOperBillConsts
	/// </summary>
	[Serializable]
	public class MedVsHisOperBillConsts
	{
		#region define variable
		private string _patientId;
		private decimal _visitId;
		private decimal _operId;
		private decimal _constsCount;
		private string _itemNoString;
		private string _itemNoStringIndicator = String.Empty;
		private string _reserved1 = String.Empty;
		private string _reserved2 = String.Empty;
		private string _reserved3 = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		/// 病人ID号
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
		///病人住院次数
		///</summary>
		public decimal VisitId
		{
			get {return _visitId;}
			set {_visitId = value;}
		}

		///<summary>
		/// 病人手术次数
		///</summary>
		public decimal OperId
		{
			get {return _operId;}
			set {_operId = value;}
		}

		///<summary>
		/// 第几次更新收费 多次
		///</summary>
		public decimal ConstsCount
		{
			get {return _constsCount;}
			set {_constsCount = value;}
		}

		///<summary>
		///更新收费的itemNo 记录下来
		///</summary>
		public string ItemNoString
		{
			get {return _itemNoString;}
			set {_itemNoString = value;}
		}

		///<summary>
        ///收费的itemNo 状态
		///</summary>
		public string ItemNoStringIndicator
		{
			get {return _itemNoStringIndicator;}
			set {_itemNoStringIndicator = value;}
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
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedVsHisOperBillConsts))
                return false;
            MedVsHisOperBillConsts Oper = (MedVsHisOperBillConsts)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.OperId != Oper.OperId)
                return false;
            if (this.ConstsCount != Oper.ConstsCount)
                return false;
            if (this.ItemNoString != Oper.ItemNoString)
                return false;
            if (this.ItemNoStringIndicator != Oper.ItemNoStringIndicator)
                return false;
            if (this.Reserved1 != Oper.Reserved1)
                return false;
            if (this.Reserved2 != Oper.Reserved2)
                return false;
            if (this.Reserved3 != Oper.Reserved3)
                return false;
            return true;
        }
	}
}
