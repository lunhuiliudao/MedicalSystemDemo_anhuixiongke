
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:25:32
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
    ///耗材入库明细记录 MED_MTRL_IMPORT_DETAIL
	/// </summary>
	[Serializable]
	public class MedMtrlImportDetail
	{
		#region define variable
		private string _documentNo;
		private decimal _itemNo;
		private string _mtrlCode = String.Empty;
		private string _mtrlSpec = String.Empty;
		private string _units = String.Empty;
		private string _batchNo = String.Empty;
		private DateTime _antisepsisDate;
		private DateTime _expireDate;
		private string _supplierId = String.Empty;
		private decimal _purchasePrice;
		private decimal _discount;
		private decimal _retailPrice;
		private string _packageSpec = String.Empty;
		private decimal _quantity;
		private string _packageUnits = String.Empty;
		private decimal _subPackage1;
		private string _subPackageUnits1 = String.Empty;
		private string _subPackageSpec1 = String.Empty;
		private decimal _subPackage2;
		private string _subPackageUnits2 = String.Empty;
		private string _subPackageSpec2 = String.Empty;
		private string _invoiceNo = String.Empty;
		private DateTime _invoiceDate;
		#endregion
		
		#region public property
		///<summary>
        ///入库单号  由耗材入库主记录定义的入库单号
		///</summary>
		public string DocumentNo
		{
			get {return _documentNo;}
			set {_documentNo = value;}
		}

		///<summary>
        /// 项目序号  标识一个入库单内各项目顺序
		///</summary>
		public decimal ItemNo
		{
			get {return _itemNo;}
			set {_itemNo = value;}
		}

		///<summary>
        /// 耗材代码  由耗材字典定义的代码
		///</summary>
		public string MtrlCode
		{
			get {return _mtrlCode;}
			set {_mtrlCode = value;}
		}

		///<summary>
        /// 规格 由耗材字典定义的规格
		///</summary>
		public string MtrlSpec
		{
			get {return _mtrlSpec;}
			set {_mtrlSpec = value;}
		}

		///<summary>
        /// 单位   对应剂型及规格，使用规范名称，见计量单位字典
		///</summary>
		public string Units
		{
			get {return _units;}
			set {_units = value;}
		}

		///<summary>
        /// 批号  
		///</summary>
		public string BatchNo
		{
			get {return _batchNo;}
			set {_batchNo = value;}
		}

		///<summary>
        /// 灭菌日期  耗材的灭菌日期
		///</summary>
		public DateTime AntisepsisDate
		{
			get {return _antisepsisDate;}
			set {_antisepsisDate = value;}
		}

		///<summary>
        /// 有效期  耗材的有效截止日期
		///</summary>
		public DateTime ExpireDate
		{
			get {return _expireDate;}
			set {_expireDate = value;}
		}

		///<summary>
        /// 厂商标识  反映生产厂家，见耗材供应商目录 
		///</summary>
		public string SupplierId
		{
			get {return _supplierId;}
			set {_supplierId = value;}
		}

		///<summary>
        ///进货价  实际购买价，以包装单位记单价
		///</summary>
		public decimal PurchasePrice
		{
			get {return _purchasePrice;}
			set {_purchasePrice = value;}
		}

		///<summary>
        /// 折扣  该耗材购入时的折扣率。百分数，只记录数值部分
		///</summary>
		public decimal Discount
		{
			get {return _discount;}
			set {_discount = value;}
		}

		///<summary>
        ///零售价 入库当时的零售价，以包装单位记单价
		///</summary>
		public decimal RetailPrice
		{
			get {return _retailPrice;}
			set {_retailPrice = value;}
		}

		///<summary>
        ///包装规格   反映耗材含量及包装信息
		///</summary>
		public string PackageSpec
		{
			get {return _packageSpec;}
			set {_packageSpec = value;}
		}

		///<summary>
        ///数量	QUANTITY	N	12,2	以包装单位所计的数量
		///</summary>
		public decimal Quantity
		{
			get {return _quantity;}
			set {_quantity = value;}
		}

		///<summary>
        /// 包装单位	PACKAGE_UNITS	C	8	计量单位，可使用任一级管理上方便的包装
		///</summary>
		public string PackageUnits
		{
			get {return _packageUnits;}
			set {_packageUnits = value;}
		}

		///<summary>
        ///内含包装1	SUB_PACKAGE_1	N	12,2	上述一个包装单位中包含的小包装数量，为空或1表示为无此级包装
		///</summary>
		public decimal SubPackage1
		{
			get {return _subPackage1;}
			set {_subPackage1 = value;}
		}

		///<summary>
        ///内含包装1单位	SUB_PACKAGE_UNITS_1	C	8	对应内含包装1的单位
		///</summary>
		public string SubPackageUnits1
		{
			get {return _subPackageUnits1;}
			set {_subPackageUnits1 = value;}
		}

		///<summary>
        ///内含包装1规格	SUB_PACKAGE_SPEC_1	C	20	对应内含包装1的规格
		///</summary>
		public string SubPackageSpec1
		{
			get {return _subPackageSpec1;}
			set {_subPackageSpec1 = value;}
		}

		///<summary>
        ///内含包装2	SUB_PACKAGE_2	N	12,2	内含包装1中包含的小包装数量，为空或1表示为无此级包装
		///</summary>
		public decimal SubPackage2
		{
			get {return _subPackage2;}
			set {_subPackage2 = value;}
		}

		///<summary>
        ///内含包装2单位	SUB_PACKAGE_UNITS_2	C	8	对应内含包装2的单位
		///</summary>
		public string SubPackageUnits2
		{
			get {return _subPackageUnits2;}
			set {_subPackageUnits2 = value;}
		}

		///<summary>
        ///内含包装2规格	SUB_PACKAGE_SPEC_2	C	20	对应内含包装2的规格
		///</summary>
		public string SubPackageSpec2
		{
			get {return _subPackageSpec2;}
			set {_subPackageSpec2 = value;}
		}

		///<summary>
        ///发票号	INVOICE_NO	C	10	该耗材对应供货发票号
		///</summary>
		public string InvoiceNo
		{
			get {return _invoiceNo;}
			set {_invoiceNo = value;}
		}

		///<summary>
        ///发票日期	INVOICE_DATE	D		该耗材对应供货发票的开票日期
		///</summary>
		public DateTime InvoiceDate
		{
			get {return _invoiceDate;}
			set {_invoiceDate = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedMtrlImportDetail))
                return false;
            MedMtrlImportDetail Oper = (MedMtrlImportDetail)obj;
			if (this.DocumentNo != Oper.DocumentNo)
                return false;
			if (this.ItemNo != Oper.ItemNo)
                return false;
			if (this.MtrlCode != Oper.MtrlCode)
                return false;
			if (this.MtrlSpec != Oper.MtrlSpec)
                return false;
			if (this.Units != Oper.Units)
                return false;
			if (this.BatchNo != Oper.BatchNo)
                return false;
			if (this.AntisepsisDate != Oper.AntisepsisDate)
                return false;
			if (this.ExpireDate != Oper.ExpireDate)
                return false;
			if (this.SupplierId != Oper.SupplierId)
                return false;
			if (this.PurchasePrice != Oper.PurchasePrice)
                return false;
			if (this.Discount != Oper.Discount)
                return false;
			if (this.RetailPrice != Oper.RetailPrice)
                return false;
			if (this.PackageSpec != Oper.PackageSpec)
                return false;
			if (this.Quantity != Oper.Quantity)
                return false;
			if (this.PackageUnits != Oper.PackageUnits)
                return false;
			if (this.SubPackage1 != Oper.SubPackage1)
                return false;
			if (this.SubPackageUnits1 != Oper.SubPackageUnits1)
                return false;
			if (this.SubPackageSpec1 != Oper.SubPackageSpec1)
                return false;
			if (this.SubPackage2 != Oper.SubPackage2)
                return false;
			if (this.SubPackageUnits2 != Oper.SubPackageUnits2)
                return false;
			if (this.SubPackageSpec2 != Oper.SubPackageSpec2)
                return false;
			if (this.InvoiceNo != Oper.InvoiceNo)
                return false;
			if (this.InvoiceDate != Oper.InvoiceDate)
                return false;
            return true;
        }
	}
}
