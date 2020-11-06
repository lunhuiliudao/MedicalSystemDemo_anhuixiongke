
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:24:30
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedDrugDict
	/// </summary>
	[Serializable]
	public class MedDrugDict
	{
		#region define variable
		private string _drugCode;
		private string _drugName = String.Empty;
		private string _drugSpec;
		private string _units = String.Empty;
		private string _drugForm = String.Empty;
		private string _supplierName = String.Empty;
		private decimal _dosePerUnit;
		private string _doseUnits = String.Empty;
		private string _drugClass = String.Empty;
		private string _anestheticClass = String.Empty;
		private string _codeInHis = String.Empty;
		private string _inputCode = String.Empty;
		#endregion
		
		#region public property
		///<summary>
        ///药品代码  --药品的唯一标识
		///</summary>
		public string DrugCode
		{
			get {return _drugCode;}
			set {_drugCode = value;}
		}

		///<summary>
        ///药品名称 药品的标准名称
		///</summary>
		public string DrugName
		{
			get {return _drugName;}
			set {_drugName = value;}
		}

		///<summary>
        ///规格 反映药品的规格，可以带包装信息
		///</summary>
		public string DrugSpec
		{
			get {return _drugSpec;}
			set {_drugSpec = value;}
		}

		///<summary>
        /// 单位 对应剂型及规格的单位
		///</summary>
		public string Units
		{
			get {return _units;}
			set {_units = value;}
		}

		///<summary>
        /// 剂型  药品的剂型，如针剂、片剂等，使用规范描述，见药品剂型字典
		///</summary>
		public string DrugForm
		{
			get {return _drugForm;}
			set {_drugForm = value;}
		}

		///<summary>
        ///厂商名称  反映生产厂家
		///</summary>
		public string SupplierName
		{
			get {return _supplierName;}
			set {_supplierName = value;}
		}

		///<summary>
        ///最小单位剂量  每一最小不可分包装单位所含剂量，如每片、每支的剂量
		///</summary>
		public decimal DosePerUnit
		{
			get {return _dosePerUnit;}
			set {_dosePerUnit = value;}
		}

		///<summary>
        ///剂量单位   剂量的单位，如mg、ml等
		///</summary>
		public string DoseUnits
		{
			get {return _doseUnits;}
			set {_doseUnits = value;}
		}

		///<summary>
        /// 药品分类  药品的分类，如药品分为常规药品、特殊药品、抢救药品、毒麻贵重药品等，见药品分类字典
		///</summary>
		public string DrugClass
		{
			get {return _drugClass;}
			set {_drugClass = value;}
		}

		///<summary>
        /// 麻药分类  说明麻药分类，如局部麻醉药、麻醉性镇痛药、吸入全身麻醉药等，使用规范名称，见麻药分类字典
		///</summary>
		public string AnestheticClass
		{
			get {return _anestheticClass;}
			set {_anestheticClass = value;}
		}

		///<summary>
        /// HIS对照码  药品代码在HIS中的代码。如果本项为空，说明药品代码与HIS中的代码完全一致，或不需要对照。
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
            if (!(obj is MedDrugDict))
                return false;
            MedDrugDict Oper = (MedDrugDict)obj;
			if (this.DrugCode != Oper.DrugCode)
                return false;
			if (this.DrugName != Oper.DrugName)
                return false;
			if (this.DrugSpec != Oper.DrugSpec)
                return false;
			if (this.Units != Oper.Units)
                return false;
			if (this.DrugForm != Oper.DrugForm)
                return false;
			if (this.SupplierName != Oper.SupplierName)
                return false;
			if (this.DosePerUnit != Oper.DosePerUnit)
                return false;
			if (this.DoseUnits != Oper.DoseUnits)
                return false;
			if (this.DrugClass != Oper.DrugClass)
                return false;
			if (this.AnestheticClass != Oper.AnestheticClass)
                return false;
			if (this.CodeInHis != Oper.CodeInHis)
                return false;
			if (this.InputCode != Oper.InputCode)
                return false;
            return true;
        }
	}
}
