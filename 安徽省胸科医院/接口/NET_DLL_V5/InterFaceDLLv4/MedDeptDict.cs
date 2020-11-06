
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:09
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace InterFaceV5
{
	/// <summary>
	///MedDeptDict
	/// </summary>
	[Serializable]
	public class MedDeptDict
	{
		#region define variable
		private decimal _serialNo;
		private string _deptCode;
		private string _deptName = String.Empty;
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
		///科室代码
		///</summary>
		public string DeptCode
		{
			get {return _deptCode;}
			set {_deptCode = value;}
		}

		///<summary>
		///科室名称
		///</summary>
		public string DeptName
		{
			get {return _deptName;}
			set {_deptName = value;}
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
            if (!(obj is MedDeptDict))
                return false;
            MedDeptDict Oper = (MedDeptDict)obj;
            if (this.SerialNo != Oper.SerialNo)
                return false;
            if (this.DeptCode != Oper.DeptCode)
                return false;
            if (this.DeptName != Oper.DeptName)
                return false;
            if (this.InputCode != Oper.InputCode)
                return false;
            return true;
        }
	}
}
