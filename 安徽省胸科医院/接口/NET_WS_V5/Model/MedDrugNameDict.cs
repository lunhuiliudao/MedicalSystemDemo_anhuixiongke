
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:24:37
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedDrugNameDict
	/// </summary>
	[Serializable]
	public class MedDrugNameDict
	{
		#region define variable
		private string _drugCode;
		private string _drugName;
		private decimal _stdIndicator;
		private string _inputCode = String.Empty;
		#endregion

        #region public property
        ///<summary>
        ///药品代码
        ///</summary>
        public string DrugCode
        {
            get { return _drugCode; }
            set { _drugCode = value; }
        }

        ///<summary>
        ///药品名称
        ///</summary>
        public string DrugName
        {
            get { return _drugName; }
            set { _drugName = value; }
        }

        ///<summary>
        /// 正名标志 0-别名 1-正名
        ///</summary>
        public decimal StdIndicator
        {
            get { return _stdIndicator; }
            set { _stdIndicator = value; }
        }

        ///<summary>
        ///输入码
        ///</summary>
        public string InputCode
        {
            get { return _inputCode; }
            set { _inputCode = value; }
        }
        #endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedDrugNameDict))
                return false;
            MedDrugNameDict Oper = (MedDrugNameDict)obj;
			if (this.DrugCode != Oper.DrugCode)
                return false;
			if (this.DrugName != Oper.DrugName)
                return false;
			if (this.StdIndicator != Oper.StdIndicator)
                return false;
			if (this.InputCode != Oper.InputCode)
                return false;
            return true;
        }
	}
}
