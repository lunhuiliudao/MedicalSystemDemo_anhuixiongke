
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:46
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedBillItemClassVsHis
	/// </summary>
	[Serializable]
	public class MedBillItemClassVsHis
	{
		#region define variable
		private string _classCode;
		private string _codeInHis;
		#endregion
		
		#region public property
		///<summary>
		///类别代码
		///</summary>
		public string ClassCode
		{
			get {return _classCode;}
			set {_classCode = value;}
		}

		///<summary>
		///HIS类别代码
		///</summary>
		public string CodeInHis
		{
			get {return _codeInHis;}
			set {_codeInHis = value;}
		}
		#endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedBillItemClassVsHis))
                return false;
            MedBillItemClassVsHis Oper = (MedBillItemClassVsHis)obj;
            if (this.ClassCode != Oper.ClassCode)
                return false;
            if (this.CodeInHis != Oper.CodeInHis)
                return false;
            return true;
        }
	}
}
