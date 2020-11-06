
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:25:37
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedMtrlImportMaster
	/// </summary>
	[Serializable]
	public class MedMtrlImportMaster
	{
		#region define variable
		private string _documentNo;
		private string _storageCode = String.Empty;
		private DateTime _importDate;
		private string _supplier = String.Empty;
		private decimal _accountReceivable;
		private decimal _accountPayed;
		private decimal _additionalFee;
		private string _importClass = String.Empty;
		private string _subStorage = String.Empty;
		private decimal _accountIndicator;
		private string _memos = String.Empty;
		private string _operator = String.Empty;
		#endregion

        #region public property
        ///<summary>
        /// 入库单号  唯一标识一次入库
        ///</summary>
        public string DocumentNo
        {
            get { return _documentNo; }
            set { _documentNo = value; }
        }

        ///<summary>
        /// 库存单位代码  入库单位代码，见库存单位字典
        ///</summary>
        public string StorageCode
        {
            get { return _storageCode; }
            set { _storageCode = value; }
        }

        ///<summary>
        /// 入库日期 
        ///</summary>
        public DateTime ImportDate
        {
            get { return _importDate; }
            set { _importDate = value; }
        }

        ///<summary>
        /// 供货方  见供货单位字典
        ///</summary>
        public string Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }

        ///<summary>
        ///应付款  该批耗材的总应付款（含附加费）
        ///</summary>
        public decimal AccountReceivable
        {
            get { return _accountReceivable; }
            set { _accountReceivable = value; }
        }

        ///<summary>
        /// 已付款 该批耗材的已付款
        ///</summary>
        public decimal AccountPayed
        {
            get { return _accountPayed; }
            set { _accountPayed = value; }
        }

        ///<summary>
        /// 附加费  该批耗材的附加费，如运杂费
        ///</summary>
        public decimal AdditionalFee
        {
            get { return _additionalFee; }
            set { _additionalFee = value; }
        }

        ///<summary>
        /// 入库类别  反映耗材来源，如：购入、退货等
        ///</summary>
        public string ImportClass
        {
            get { return _importClass; }
            set { _importClass = value; }
        }

        ///<summary>
        /// 存放库房  一个库存管理单位内的存放库房，一张出库单只能对应一个库房
        ///</summary>
        public string SubStorage
        {
            get { return _subStorage; }
            set { _subStorage = value; }
        }

        ///<summary>
        /// 记帐标志  记帐后入库记录不能修改，作为记帐确认标志。0-未记帐 1-已记帐 2-作废
        ///</summary>
        public decimal AccountIndicator
        {
            get { return _accountIndicator; }
            set { _accountIndicator = value; }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string Memos
        {
            get { return _memos; }
            set { _memos = value; }
        }

        ///<summary>
        ///录入者
        ///</summary>
        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }
        #endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedMtrlImportMaster))
                return false;
            MedMtrlImportMaster Oper = (MedMtrlImportMaster)obj;
			if (this.DocumentNo != Oper.DocumentNo)
                return false;
			if (this.StorageCode != Oper.StorageCode)
                return false;
			if (this.ImportDate != Oper.ImportDate)
                return false;
			if (this.Supplier != Oper.Supplier)
                return false;
			if (this.AccountReceivable != Oper.AccountReceivable)
                return false;
			if (this.AccountPayed != Oper.AccountPayed)
                return false;
			if (this.AdditionalFee != Oper.AdditionalFee)
                return false;
			if (this.ImportClass != Oper.ImportClass)
                return false;
			if (this.SubStorage != Oper.SubStorage)
                return false;
			if (this.AccountIndicator != Oper.AccountIndicator)
                return false;
			if (this.Memos != Oper.Memos)
                return false;
			if (this.Operator != Oper.Operator)
                return false;
            return true;
        }
	}
}
