
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:08:41
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedLabTestItems
	/// </summary>
	[Serializable]
	public class MedLabTestItems
	{
		#region define variable
		private string _testNo;
		private decimal _itemNo;
		private string _itemName = String.Empty;
		private string _itemCode = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///
		///</summary>
		public string TestNo
		{
			get {return _testNo;}
			set {_testNo = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal ItemNo
		{
			get {return _itemNo;}
			set {_itemNo = value;}
		}

		///<summary>
		///
		///</summary>
		public string ItemName
		{
			get {return _itemName;}
			set {_itemName = value;}
		}

		///<summary>
		///
		///</summary>
		public string ItemCode
		{
			get {return _itemCode;}
			set {_itemCode = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedLabTestItems))
                return false;
            MedLabTestItems Oper = (MedLabTestItems)obj;
            if (this.TestNo != Oper.TestNo)
                return false;
            if (this.ItemNo != Oper.ItemNo)
                return false;
            if (this.ItemName != Oper.ItemName)
                return false;
            if (this.ItemCode != Oper.ItemCode)
                return false;
            return true;
        }
	}
}
