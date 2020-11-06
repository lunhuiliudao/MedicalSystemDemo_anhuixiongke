
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/15 14:44:04
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedPerformDefaultSchedule
	/// </summary>
	[Serializable]
	public class MedPerformDefaultSchedule
	{
		#region define variable
		private decimal _serialNo;
		private string _freqDesc;
		private string _administration;
		private string _defaultSchedule = String.Empty;
		#endregion
		
		#region public property
		///<summary>
        /// 序号
		///</summary>
		public decimal SerialNo
		{
			get {return _serialNo;}
			set {_serialNo = value;}
		}

		///<summary>
        /// 医嘱频次
		///</summary>
		public string FreqDesc
		{
			get {return _freqDesc;}
			set {_freqDesc = value;}
		}

		///<summary>
        /// 给药途径
		///</summary>
		public string Administration
		{
			get {return _administration;}
			set {_administration = value;}
		}

		///<summary>
        /// 默认执行时间
		///</summary>
		public string DefaultSchedule
		{
			get {return _defaultSchedule;}
			set {_defaultSchedule = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedPerformDefaultSchedule))
                return false;
            MedPerformDefaultSchedule Oper = (MedPerformDefaultSchedule)obj;
			if (this.SerialNo != Oper.SerialNo)
                return false;
			if (this.FreqDesc != Oper.FreqDesc)
                return false;
			if (this.Administration != Oper.Administration)
                return false;
			if (this.DefaultSchedule != Oper.DefaultSchedule)
                return false;
            return true;
        }
	}
}
