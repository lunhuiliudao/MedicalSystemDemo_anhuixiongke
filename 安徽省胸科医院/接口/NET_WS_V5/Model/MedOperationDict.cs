
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:20
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedOperationDict
	/// </summary>
	[Serializable]
	public class MedOperationDict:ModelBase
	{
		#region define variable
		private string _operationCode = String.Empty;
		private string _operationName;
		private string _operationScale = String.Empty;
		private decimal _stdIndicator;
		private decimal _approvedIndicator;
		private DateTime _createDate;
		private string _inputCode = String.Empty;
		private string _inputCodeWb = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///手术操作代码;非空，使用ICD9CM，用户定义
		///</summary>
		public string OperationCode
		{
			get {return _operationCode;}
			set {_operationCode = value;}
		}

		///<summary>
		///手术操作名称;非空
		///</summary>
		public string OperationName
		{
			get {return _operationName;}
			set {_operationName = value;}
		}

		///<summary>
		///手术等级;使用规范名称，见4.16手术等级字典
		///</summary>
		public string OperationScale
		{
			get {return _operationScale;}
			set {_operationScale = value;}
		}

		///<summary>
		///正名标志;1-正名 0-别名，每种手术即每个手术代码有且只能有一个正名
		///</summary>
		public decimal StdIndicator
		{
			get {return _stdIndicator;}
			set {_stdIndicator = value;}
		}

		///<summary>
		///标准化标志;1-已标准化 0-临时项目
		///</summary>
		public decimal ApprovedIndicator
		{
			get {return _approvedIndicator;}
			set {_approvedIndicator = value;}
		}

		///<summary>
		///创建日期;创建该诊断的日期
		///</summary>
		public DateTime CreateDate
		{
			get {return _createDate;}
			set {_createDate = value;}
		}

		///<summary>
		///输入码;推荐使用拼音词头
		///</summary>
		public string InputCode
		{
			get {return _inputCode;}
			set {_inputCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string InputCodeWb
		{
			get {return _inputCodeWb;}
			set {_inputCodeWb = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedOperationDict))
                return false;
            MedOperationDict Oper = (MedOperationDict)obj;
            if (this.OperationCode != Oper.OperationCode)
                return false;
            if (this.OperationName != Oper.OperationName)
                return false;
            if (this.OperationScale != Oper.OperationScale)
                return false;
            if (this.StdIndicator != Oper.StdIndicator)
                return false;
            if (this.ApprovedIndicator != Oper.ApprovedIndicator)
                return false;
            if (this.CreateDate != Oper.CreateDate)
                return false;
            if (this.InputCode != Oper.InputCode)
                return false;
            if (this.InputCodeWb != Oper.InputCodeWb)
                return false;
            return true;
        }
	}
}
