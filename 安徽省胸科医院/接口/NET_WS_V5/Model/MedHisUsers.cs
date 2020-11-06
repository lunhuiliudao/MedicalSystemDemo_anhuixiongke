
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:04
 * 
 * Notes:
 *
* ******************************************************************/
using System;

namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedHisUsers
	/// </summary>
	[Serializable]
	public class MedHisUsers:ModelBase
	{
		#region define variable
		private string _userJobId;
		private string _userName = String.Empty;
		private string _userDeptCode = String.Empty;
        private string _inputCode = String.Empty;
		private string _userJob = String.Empty;
        private decimal _userStatus = 1;
		private string _reserved01 = String.Empty;
		private DateTime _createDate;
        private DateTime _stopDate;

		#endregion
		
		#region public property
		///<summary>
		///用户标识;每个用户分配一个唯一标识号（工号）
		///</summary>
		public string UserJobId
		{
            get { return _userJobId; }
            set { _userJobId = value; }
		}

		///<summary>
		///用户姓名
		///</summary>
		public string UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}

		///<summary>
		///用户所在科室的代码
		///</summary>
		public string UserDeptCode
		{
            get { return _userDeptCode; }
            set { _userDeptCode = value; }
		}

		///<summary>
		///例如：医生、护士
		///</summary>
		public string UserJob
		{
			get {return _userJob;}
			set {_userJob = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved01
		{
			get {return _reserved01;}
			set {_reserved01 = value;}
		}

		///<summary>
		///创建日期
		///</summary>
		public DateTime CreateDate
		{
			get {return _createDate;}
			set {_createDate = value;}
		}

        public DateTime StopDateTime
        {
            get { return _stopDate; }
            set { _stopDate = value; }
        }

        public decimal UserStatus
        {
            get { return _userStatus; }
            set { _userStatus = value; }
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
            if (!(obj is MedHisUsers))
                return false;
            MedHisUsers Oper = (MedHisUsers)obj;
            //if (this.UserId != Oper.UserId)
            //    return false;
            //if (this.UserName != Oper.UserName)
            //    return false;
            //if (this.UserDept != Oper.UserDept)
            //    return false;
            //if (this.UserJob != Oper.UserJob)
            //    return false;
            //if (this.Reserved01 != Oper.Reserved01)
            //    return false;
            //if (this.CreateDate != Oper.CreateDate)
            //    return false;
            //if (this.InputCode != Oper.InputCode)
            //    return false;
            return true;
        }
	}
}
