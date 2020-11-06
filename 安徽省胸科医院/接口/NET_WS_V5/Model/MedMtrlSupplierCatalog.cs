
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:25:04
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
    ///耗材供应商目录
	/// </summary>
	[Serializable]
	public class MedMtrlSupplierCatalog
	{
		#region define variable
		private string _supplierId;
		private string _supplier = String.Empty;
		private string _supplierClass = String.Empty;
		private string _codeInHis = String.Empty;
		private string _inputCode = String.Empty;
		#endregion
		
		#region public property
		///<summary>
        ///厂商标识  唯一标识一个厂商
		///</summary>
		public string SupplierId
		{
			get {return _supplierId;}
			set {_supplierId = value;}
		}

		///<summary>
        /// 厂商   厂商全称
		///</summary>
		public string Supplier
		{
			get {return _supplier;}
			set {_supplier = value;}
		}

		///<summary>
        /// 厂商类别  用于反映厂商的性质，如生产厂、供应商等
		///</summary>
		public string SupplierClass
		{
			get {return _supplierClass;}
			set {_supplierClass = value;}
		}

		///<summary>
        /// HIS对照码 厂商标识在HIS中的代码。如果本项为空，说明与HIS中的代码完全一致，或不需要对照。
		///</summary>
		public string CodeInHis
		{
			get {return _codeInHis;}
			set {_codeInHis = value;}
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
            if (!(obj is MedMtrlSupplierCatalog))
                return false;
            MedMtrlSupplierCatalog Oper = (MedMtrlSupplierCatalog)obj;
			if (this.SupplierId != Oper.SupplierId)
                return false;
			if (this.Supplier != Oper.Supplier)
                return false;
			if (this.SupplierClass != Oper.SupplierClass)
                return false;
			if (this.CodeInHis != Oper.CodeInHis)
                return false;
			if (this.InputCode != Oper.InputCode)
                return false;
            return true;
        }
	}
}
