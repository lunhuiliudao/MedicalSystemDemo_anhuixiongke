
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:05
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace InterFaceV5
{
	/// <summary>
	///MedVsHisPat
	/// </summary>
	[Serializable]
	public class MedVsHisPat
	{
		#region define variable
		private string _medPatientId;
		private decimal _medVisitId;
		private string _hisPatientId = String.Empty;
		private string _hisInpNo = String.Empty;
		private string _hisVisitId = String.Empty;
		private DateTime _createDate;
		private string _reserved01 = String.Empty;
		private string _reserved02 = String.Empty;
		private string _reserved03 = String.Empty;
		private string _reserved04 = String.Empty;
		private string _reserved05 = String.Empty;
		private string _reserved06 = String.Empty;
		private string _reserved07 = String.Empty;
		private string _reserved08 = String.Empty;
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
		///病人标识号(HIS)
		///</summary>
		public string HisPatientId
		{
			get {return _hisPatientId;}
			set {_hisPatientId = value;}
		}

		///<summary>
		///病人住院号(HIS)
		///</summary>
		public string HisInpNo
		{
			get {return _hisInpNo;}
			set {_hisInpNo = value;}
		}

		///<summary>
		///病人本次住院标识(HIS)
		///</summary>
		public string HisVisitId
		{
			get {return _hisVisitId;}
			set {_hisVisitId = value;}
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

		///<summary>
		///保留字
		///</summary>
		public string Reserved06
		{
			get {return _reserved06;}
			set {_reserved06 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved07
		{
			get {return _reserved07;}
			set {_reserved07 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved08
		{
			get {return _reserved08;}
			set {_reserved08 = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedVsHisPat))
                return false;
            MedVsHisPat Oper = (MedVsHisPat)obj;
            if (this.MedPatientId != Oper.MedPatientId)
                return false;
            if (this.MedVisitId != Oper.MedVisitId)
                return false;
            if (this.HisPatientId != Oper.HisPatientId)
                return false;
            if (this.HisInpNo != Oper.HisInpNo)
                return false;
            if (this.HisVisitId != Oper.HisVisitId)
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
            if (this.Reserved06 != Oper.Reserved06)
                return false;
            if (this.Reserved07 != Oper.Reserved07)
                return false;
            if (this.Reserved08 != Oper.Reserved08)
                return false;
            return true;
        }
	}
}
