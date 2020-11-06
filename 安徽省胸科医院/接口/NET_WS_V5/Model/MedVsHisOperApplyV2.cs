
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:56:40
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	/// 手术记录对照表 记录相关手术次数
	/// </summary>
	[Serializable]
	public class MedVsHisOperApplyV2
	{
		#region define variable
		private string _medPatientId;
		private decimal _medVisitId;
		private decimal _medScheduleId;
		private string _hisApplyNo = String.Empty;
		private string _hisPatientId = String.Empty;
		private string _hisVisitId = String.Empty;
		private string  _hisScheduleId;
		private string _reqDateTime = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///病人ID
		///</summary>
		public string MedPatientId
		{
			get {return _medPatientId;}
			set {_medPatientId = value;}
		}

		///<summary>
		///病人住院标识
		///</summary>
		public decimal MedVisitId
		{
			get {return _medVisitId;}
			set {_medVisitId = value;}
		}

		///<summary>
		///手术申请号
		///</summary>
		public decimal MedScheduleId
		{
			get {return _medScheduleId;}
			set {_medScheduleId = value;}
		}

		///<summary>
		///手术申请号（HIS）
		///</summary>
		public string HisApplyNo
		{
			get {return _hisApplyNo;}
			set {_hisApplyNo = value;}
		}

		///<summary>
		///病人ID（HIS）
		///</summary>
		public string HisPatientId
		{
			get {return _hisPatientId;}
			set {_hisPatientId = value;}
		}

		///<summary>
		///病人住院标识（HIS）
		///</summary>
		public string HisVisitId
		{
			get {return _hisVisitId;}
			set {_hisVisitId = value;}
		}

		///<summary>
		///手术申请号（HIS备用）
		///</summary>
		public string  HisScheduleId
		{
			get {return _hisScheduleId;}
			set {_hisScheduleId = value;}
		}

		///<summary>
		///申请时间
		///</summary>
		public string ReqDateTime
		{
			get {return _reqDateTime;}
			set {_reqDateTime = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedVsHisOperApplyV2))
                return false;
            MedVsHisOperApplyV2 Oper = (MedVsHisOperApplyV2)obj;
            if (this.MedPatientId != Oper.MedPatientId)
                return false;
            if (this.MedVisitId != Oper.MedVisitId)
                return false;
            if (this.MedScheduleId != Oper.MedScheduleId)
                return false;
            if (this.HisApplyNo != Oper.HisApplyNo)
                return false;
            if (this.HisPatientId != Oper.HisPatientId)
                return false;
            if (this.HisVisitId != Oper.HisVisitId)
                return false;
            if (this.HisScheduleId != Oper.HisScheduleId)
                return false;
            if (this.ReqDateTime != Oper.ReqDateTime)
                return false;
            return true;
        }
	}
}
