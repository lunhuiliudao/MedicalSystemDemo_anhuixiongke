
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-06-12 12:28:37
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///Users
	/// </summary>
	[Serializable]
	public class Users
	{
		#region define variable
		private string _userId;
		private string _userName = String.Empty;
		private string _userGender = String.Empty;
		private string _userPower = String.Empty;
		private string _partName = String.Empty;
		private string _officeName = String.Empty;
		private string _userPost = String.Empty;
		private string _userAccount = String.Empty;
		private string _userPass = String.Empty;
		private string _userCard = String.Empty;
		private string _userIdentityCard = String.Empty;
		private decimal _flag;
		#endregion
		
		#region public property
		///<summary>
        ///医生编号（主键）
		///</summary>
		public string UserId
		{
			get {return _userId;}
			set {_userId = value;}
		}

		///<summary>
        ///医生姓名
		///</summary>
		public string UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}

		///<summary>
        ///医生性别
		///</summary>
		public string UserGender
		{
			get {return _userGender;}
			set {_userGender = value;}
		}

		///<summary>
        ///医生权限
		///</summary>
		public string UserPower
		{
			get {return _userPower;}
			set {_userPower = value;}
		}

		///<summary>
        ///医生所在部门
		///</summary>
		public string PartName
		{
			get {return _partName;}
			set {_partName = value;}
		}

		///<summary>
        ///医生所在科室
		///</summary>
		public string OfficeName
		{
			get {return _officeName;}
			set {_officeName = value;}
		}

		///<summary>
        ///医生职位，如：主任医师
		///</summary>
		public string UserPost
		{
			get {return _userPost;}
			set {_userPost = value;}
		}

        ///<summary>
        ///医生登陆号
		///</summary>
		public string UserAccount
		{
			get {return _userAccount;}
			set {_userAccount = value;}
		}

		///<summary>
        ///密码
		///</summary>
		public string UserPass
		{
			get {return _userPass;}
			set {_userPass = value;}
		}

		///<summary>
        ///医生卡号
		///</summary>
		public string UserCard
		{
			get {return _userCard;}
			set {_userCard = value;}
		}

		///<summary>
        ///医生身份证号
		///</summary>
		public string UserIdentityCard
		{
			get {return _userIdentityCard;}
			set {_userIdentityCard = value;}
		}

		///<summary>
        ///标志位（暂无作用）
		///</summary>
		public decimal Flag
		{
			get {return _flag;}
			set {_flag = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Users))
                return false;
            Users Oper = (Users)obj;
			if (this.UserId != Oper.UserId)
                return false;
			if (this.UserName != Oper.UserName)
                return false;
			if (this.UserGender != Oper.UserGender)
                return false;
			if (this.UserPower != Oper.UserPower)
                return false;
			if (this.PartName != Oper.PartName)
                return false;
			if (this.OfficeName != Oper.OfficeName)
                return false;
			if (this.UserPost != Oper.UserPost)
                return false;
			if (this.UserAccount != Oper.UserAccount)
                return false;
			if (this.UserPass != Oper.UserPass)
                return false;
			if (this.UserCard != Oper.UserCard)
                return false;
			if (this.UserIdentityCard != Oper.UserIdentityCard)
                return false;
			if (this.Flag != Oper.Flag)
                return false;
            return true;
        }
	}
}
