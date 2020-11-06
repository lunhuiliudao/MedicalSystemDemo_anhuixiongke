
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010-08-13 10:02:08
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedEmrWorkPath
	/// </summary>
	[Serializable]
	public class MedEmrWorkPath
	{
		#region define variable
		private string _application;
		private string _emrPath;
		private string _userName = String.Empty;
		private string _userPwd = String.Empty;
		private string _ipAddr = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///
		///</summary>
		public string Application
		{
			get {return _application;}
			set {_application = value;}
		}

		///<summary>
		///
		///</summary>
		public string EmrPath
		{
			get {return _emrPath;}
			set {_emrPath = value;}
		}

		///<summary>
		///
		///</summary>
		public string UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}

		///<summary>
		///
		///</summary>
		public string UserPwd
		{
			get {return _userPwd;}
			set {_userPwd = value;}
		}

		///<summary>
		///
		///</summary>
		public string IpAddr
		{
			get {return _ipAddr;}
			set {_ipAddr = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedEmrWorkPath))
                return false;
            MedEmrWorkPath Oper = (MedEmrWorkPath)obj;
			if (this.Application != Oper.Application)
                return false;
			if (this.EmrPath != Oper.EmrPath)
                return false;
			if (this.UserName != Oper.UserName)
                return false;
			if (this.UserPwd != Oper.UserPwd)
                return false;
			if (this.IpAddr != Oper.IpAddr)
                return false;
            return true;
        }
	}
}
