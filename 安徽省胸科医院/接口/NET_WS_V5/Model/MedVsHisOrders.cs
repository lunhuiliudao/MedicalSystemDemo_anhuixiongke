
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:17
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedVsHisOrders
	/// </summary>
	[Serializable]
	public class MedVsHisOrders
	{
		#region define variable
		private string _medPatientId;
		private decimal _medVisitId;
		private string _medOrderNo;
		private decimal _medOrderSubNo;
		private decimal _medRepeatIndicator;
		private string _hisOrderNo = String.Empty;
		private string _hisOrderSubNo = String.Empty;
		private DateTime _createDate;
		private string _reserved01 = String.Empty;
		private string _reserved02 = String.Empty;
		private string _reserved03 = String.Empty;
		private string _reserved04 = String.Empty;
		private string _reserved05 = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///病人标识号
		///</summary>
		public string MedPatientId
		{
			get {return _medPatientId;}
			set {_medPatientId = value;}
		}

		///<summary>
		///病人本次住院标识
		///</summary>
		public decimal MedVisitId
		{
			get {return _medVisitId;}
			set {_medVisitId = value;}
		}

		///<summary>
		///医嘱序号
		///</summary>
		public string MedOrderNo
		{
			get {return _medOrderNo;}
			set {_medOrderNo = value;}
		}

		///<summary>
		///医嘱子序号
		///</summary>
		public decimal MedOrderSubNo
		{
			get {return _medOrderSubNo;}
			set {_medOrderSubNo = value;}
		}

		///<summary>
		///长期医嘱标志
		///</summary>
		public decimal MedRepeatIndicator
		{
			get {return _medRepeatIndicator;}
			set {_medRepeatIndicator = value;}
		}

		///<summary>
		///HIS医嘱序号
		///</summary>
		public string HisOrderNo
		{
			get {return _hisOrderNo;}
			set {_hisOrderNo = value;}
		}

		///<summary>
		///HIS医嘱子序号
		///</summary>
		public string HisOrderSubNo
		{
			get {return _hisOrderSubNo;}
			set {_hisOrderSubNo = value;}
		}

		///<summary>
		///创建时间
		///</summary>
		public DateTime CreateDate
		{
			get {return _createDate;}
			set {_createDate = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved01
		{
			get {return _reserved01;}
			set {_reserved01 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved02
		{
			get {return _reserved02;}
			set {_reserved02 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved03
		{
			get {return _reserved03;}
			set {_reserved03 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved04
		{
			get {return _reserved04;}
			set {_reserved04 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved05
		{
			get {return _reserved05;}
			set {_reserved05 = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedVsHisOrders))
                return false;
            MedVsHisOrders Oper = (MedVsHisOrders)obj;
            if (this.MedPatientId != Oper.MedPatientId)
                return false;
            if (this.MedVisitId != Oper.MedVisitId)
                return false;
            if (this.MedOrderNo != Oper.MedOrderNo)
                return false;
            if (this.MedOrderSubNo != Oper.MedOrderSubNo)
                return false;
            if (this.MedRepeatIndicator != Oper.MedRepeatIndicator)
                return false;
            if (this.HisOrderNo != Oper.HisOrderNo)
                return false;
            if (this.HisOrderSubNo != Oper.HisOrderSubNo)
                return false;
            if (this.CreateDate != Oper.CreateDate)
                return false;
            if (this.Reserved01 != Oper.Reserved01)
                return false;
            if (this.Reserved02 != Oper.Reserved02)
                return false;
            if (this.Reserved03 != Oper.Reserved03)
                return false;
            if (this.Reserved04 != Oper.Reserved04)
                return false;
            if (this.Reserved05 != Oper.Reserved05)
                return false;
            return true;
        }
	}
}
