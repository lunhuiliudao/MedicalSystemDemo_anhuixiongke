
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-03-02 16:24:51
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedVsHisDepId
	/// </summary>
	[Serializable]
	public class MedVsHisDepId
	{
		#region define variable
		private string _medPatientId;
		private decimal _medVisitId;
		private decimal _medDepId;
		private DateTime _hisAdmWardDateTime;
		private string _hisPatientId = String.Empty;
		private string _hisVisitId = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///
		///</summary>
		public string MedPatientId
		{
			get {return _medPatientId;}
			set {_medPatientId = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal MedVisitId
		{
			get {return _medVisitId;}
			set {_medVisitId = value;}
		}

		///<summary>
		///入科次数
		///</summary>
		public decimal MedDepId
		{
			get {return _medDepId;}
			set {_medDepId = value;}
		}

		///<summary>
		///入科时间
		///</summary>
		public DateTime HisAdmWardDateTime
		{
			get {return _hisAdmWardDateTime;}
			set {_hisAdmWardDateTime = value;}
		}

		///<summary>
		///
		///</summary>
		public string HisPatientId
		{
			get {return _hisPatientId;}
			set {_hisPatientId = value;}
		}

		///<summary>
		///his住院标示
		///</summary>
		public string HisVisitId
		{
			get {return _hisVisitId;}
			set {_hisVisitId = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedVsHisDepId))
                return false;
            MedVsHisDepId Oper = (MedVsHisDepId)obj;
			if (this.MedPatientId != Oper.MedPatientId)
                return false;
			if (this.MedVisitId != Oper.MedVisitId)
                return false;
			if (this.MedDepId != Oper.MedDepId)
                return false;
			if (this.HisAdmWardDateTime != Oper.HisAdmWardDateTime)
                return false;
			if (this.HisPatientId != Oper.HisPatientId)
                return false;
			if (this.HisVisitId != Oper.HisVisitId)
                return false;
            return true;
        }
	}
}
