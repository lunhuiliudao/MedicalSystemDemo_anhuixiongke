
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:12
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedVsHisOrderClass
	/// </summary>
	[Serializable]
	public class MedVsHisOrderClass
	{
		#region define variable
		private decimal _serialNo;
		private string _hisClassCode;
		private string _hisClassName = String.Empty;
		private string _medClassCode = String.Empty;
		private string _medClassName = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///序号
		///</summary>
		public decimal SerialNo
		{
			get {return _serialNo;}
			set {_serialNo = value;}
		}

		///<summary>
		///HIS医嘱类别代码
		///</summary>
		public string HisClassCode
		{
			get {return _hisClassCode;}
			set {_hisClassCode = value;}
		}

		///<summary>
		///HIS医嘱类别名称
		///</summary>
		public string HisClassName
		{
			get {return _hisClassName;}
			set {_hisClassName = value;}
		}

		///<summary>
		///本地医嘱类别代码
		///</summary>
		public string MedClassCode
		{
			get {return _medClassCode;}
			set {_medClassCode = value;}
		}

		///<summary>
		///本地医嘱类别名称
		///</summary>
		public string MedClassName
		{
			get {return _medClassName;}
			set {_medClassName = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedVsHisOrderClass))
                return false;
            MedVsHisOrderClass Oper = (MedVsHisOrderClass)obj;
            if (this.SerialNo != Oper.SerialNo)
                return false;
            if (this.HisClassCode != Oper.HisClassCode)
                return false;
            if (this.HisClassName != Oper.HisClassName)
                return false;
            if (this.MedClassCode != Oper.MedClassCode)
                return false;
            if (this.MedClassName != Oper.MedClassName)
                return false;
            return true;
        }
	}
}
