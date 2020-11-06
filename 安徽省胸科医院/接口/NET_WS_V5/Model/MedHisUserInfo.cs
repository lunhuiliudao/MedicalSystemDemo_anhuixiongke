
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/21 11:28:53
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedHisUserInfo
	/// </summary>
	[Serializable]
	public class MedHisUserInfo
	{
		#region define variable
		private string _userId;
		private string _userName = String.Empty;
		private object _userImage;
		private DateTime _createDate;
		private string _reserved01 = String.Empty;
		private string _reserved02 = String.Empty;
		private string _reserved03 = String.Empty;
		private DateTime _reserved04;
		private DateTime _reserved05;
		private object _reserved06;
		private object _reserved07;
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
		public string UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}

		///<summary>
		///
		///</summary>
		public object UserImage
		{
			get {return _userImage;}
			set {_userImage = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime CreateDate
		{
			get {return _createDate;}
			set {_createDate = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved01
		{
			get {return _reserved01;}
			set {_reserved01 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved02
		{
			get {return _reserved02;}
			set {_reserved02 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved03
		{
			get {return _reserved03;}
			set {_reserved03 = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime Reserved04
		{
			get {return _reserved04;}
			set {_reserved04 = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime Reserved05
		{
			get {return _reserved05;}
			set {_reserved05 = value;}
		}

		///<summary>
		///
		///</summary>
		public object Reserved06
		{
			get {return _reserved06;}
			set {_reserved06 = value;}
		}

		///<summary>
		///
		///</summary>
		public object Reserved07
		{
			get {return _reserved07;}
			set {_reserved07 = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedHisUserInfo))
                return false;
            MedHisUserInfo Oper = (MedHisUserInfo)obj;
			if (this.UserId != Oper.UserId)
                return false;
			if (this.UserName != Oper.UserName)
                return false;
			if (this.UserImage != Oper.UserImage)
                return false;
			if (this.CreateDate != Oper.CreateDate)
                return false;
			if (this.Reserved01 != Oper.Reserved01)
                return false;
			if (this.Reserved02 != Oper.Reserved02)
                return false;
			if (this.Reserved03 != Oper.Reserved03)
                return false;
			if (this.Reserved04 != Oper.Reserved04)
                return false;
			if (this.Reserved05 != Oper.Reserved05)
                return false;
			if (this.Reserved06 != Oper.Reserved06)
                return false;
			if (this.Reserved07 != Oper.Reserved07)
                return false;
            return true;
        }
	}
}
