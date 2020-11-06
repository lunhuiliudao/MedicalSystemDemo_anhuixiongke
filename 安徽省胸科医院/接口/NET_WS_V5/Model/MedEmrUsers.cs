
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/6/30 15:39:36
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedEmrUsers
	/// </summary>
	[Serializable]
	public class MedEmrUsers
	{
		#region define variable
		private string _userId;
		private string _loginName = String.Empty;
		private string _loginPwd = String.Empty;
		private string _name = String.Empty;
		private string _deptCode = String.Empty;
		private string _inputCode = String.Empty;
		private string _job = String.Empty;
		private string _title = String.Empty;
		private string _grantCode = String.Empty;
		private decimal _isValid;
		#endregion
		
		#region public property
		///<summary>
		///
		///</summary>
		public string UserId
		{
			get {return _userId;}
			set {_userId = value;}
		}

		///<summary>
		///
		///</summary>
		public string LoginName
		{
			get {return _loginName;}
			set {_loginName = value;}
		}

		///<summary>
		///
		///</summary>
		public string LoginPwd
		{
			get {return _loginPwd;}
			set {_loginPwd = value;}
		}

		///<summary>
		///
		///</summary>
		public string Name
		{
			get {return _name;}
			set {_name = value;}
		}

		///<summary>
		///
		///</summary>
		public string DeptCode
		{
			get {return _deptCode;}
			set {_deptCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string InputCode
		{
			get {return _inputCode;}
			set {_inputCode = value;}
		}

		///<summary>
		///
		///</summary>
		public string Job
		{
			get {return _job;}
			set {_job = value;}
		}

		///<summary>
		///
		///</summary>
		public string Title
		{
			get {return _title;}
			set {_title = value;}
		}

		///<summary>
		///
		///</summary>
		public string GrantCode
		{
			get {return _grantCode;}
			set {_grantCode = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal IsValid
		{
			get {return _isValid;}
			set {_isValid = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedEmrUsers))
                return false;
            MedEmrUsers Oper = (MedEmrUsers)obj;
			if (this.UserId != Oper.UserId)
                return false;
			if (this.LoginName != Oper.LoginName)
                return false;
			if (this.LoginPwd != Oper.LoginPwd)
                return false;
			if (this.Name != Oper.Name)
                return false;
			if (this.DeptCode != Oper.DeptCode)
                return false;
			if (this.InputCode != Oper.InputCode)
                return false;
			if (this.Job != Oper.Job)
                return false;
			if (this.Title != Oper.Title)
                return false;
			if (this.GrantCode != Oper.GrantCode)
                return false;
			if (this.IsValid != Oper.IsValid)
                return false;
            return true;
        }
	}
}
