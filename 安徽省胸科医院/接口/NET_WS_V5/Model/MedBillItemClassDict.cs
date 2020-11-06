
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:38
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedBillItemClassDict
	/// </summary>
	[Serializable]
	public class MedBillItemClassDict
	{
		#region define variable
		private decimal _serialNo;
		private string _classCode;
		private string _className = String.Empty;
		private string _inputCode = String.Empty;
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
		///项目分类代码
		///</summary>
		public string ClassCode
		{
			get {return _classCode;}
			set {_classCode = value;}
		}

		///<summary>
		///项目分类名称
		///</summary>
		public string ClassName
		{
			get {return _className;}
			set {_className = value;}
		}

		///<summary>
		///输入码
		///</summary>
		public string InputCode
		{
			get {return _inputCode;}
			set {_inputCode = value;}
		}
		#endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedBillItemClassDict))
                return false;
            MedBillItemClassDict Oper = (MedBillItemClassDict)obj;
            if (this.SerialNo != Oper.SerialNo)
                return false;
            if (this.ClassCode != Oper.ClassCode)
                return false;
            if (this.ClassName != Oper.ClassName)
                return false;
            if (this.InputCode != Oper.InputCode)
                return false;
            return true;
        }
	}
}
