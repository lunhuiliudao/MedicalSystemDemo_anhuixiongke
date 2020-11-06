
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:56:29
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedIfRunConfigDict
	/// </summary>
	[Serializable]
	public class MedIfRunConfigDict
	{
		#region define variable
		private string _appClass;
		private string _section;
		private string _mainKey;
		private string _keyValue = String.Empty;
		private string _memo = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///系统分类;系统分类情况，定义:AENS － 麻醉 ICU  － 重症监护
		///</summary>
		public string AppClass
		{
			get {return _appClass;}
			set {_appClass = value;}
		}

		///<summary>
		///设置区
		///</summary>
		public string Section
		{
			get {return _section;}
			set {_section = value;}
		}

		///<summary>
		///关键项
		///</summary>
		public string MainKey
		{
			get {return _mainKey;}
			set {_mainKey = value;}
		}

		///<summary>
		///关键项值
		///</summary>
		public string KeyValue
		{
			get {return _keyValue;}
			set {_keyValue = value;}
		}

		///<summary>
		///备注
		///</summary>
		public string Memo
		{
			get {return _memo;}
			set {_memo = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedIfRunConfigDict))
                return false;
            MedIfRunConfigDict Oper = (MedIfRunConfigDict)obj;
            if (this.AppClass != Oper.AppClass)
                return false;
            if (this.Section != Oper.Section)
                return false;
            if (this.MainKey != Oper.MainKey)
                return false;
            if (this.KeyValue != Oper.KeyValue)
                return false;
            if (this.Memo != Oper.Memo)
                return false;
            return true;
        }
	}
}
