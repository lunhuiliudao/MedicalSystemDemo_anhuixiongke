
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:06:11
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
    /// <summary>
    ///MedOperationBillItems
    /// </summary>
    [Serializable]
    public class MedOperationBillItems
    {
        #region define variable
        private string _patientId;
        private decimal _visitId;
        private decimal _operId;
        private decimal _itemNo;
        private string _itemClass = String.Empty;
        private string _itemName = String.Empty;
        private string _itemCode = String.Empty;
        private string _itemSpec = String.Empty;
        private decimal _amount;
        private string _units = String.Empty;
        private string _orderedBy = String.Empty;
        private string _performedBy = String.Empty;
        private decimal _costs;
        private decimal _charges;
        private string _notes = String.Empty;
        private decimal _verifiedIndicator;
        private string _enteredBy = String.Empty;
        private string _classOnReckoning = String.Empty;
        private decimal _inpbillItemNo;
        private decimal _eventItemNo;
        private decimal _exchangeIndicator;
        private decimal _storageIndicator;
        private decimal _billAttr;
        private string _supplierName = String.Empty;
        private DateTime _billDate;

        private string _operator = String.Empty;
        private decimal _price;
        private string _classOnInpRcpt = String.Empty;
        private string _subjCode = String.Empty;
        private string _classOnMr = String.Empty;
        private string _ordered_doctor = string.Empty;
        private string _performed_doctor = string.Empty;
        #endregion

        #region public property
        ///<summary>
        ///
        ///</summary>
        public string PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal VisitId
        {
            get { return _visitId; }
            set { _visitId = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal OperId
        {
            get { return _operId; }
            set { _operId = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal ItemNo
        {
            get { return _itemNo; }
            set { _itemNo = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string ItemClass
        {
            get { return _itemClass; }
            set { _itemClass = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string ItemCode
        {
            get { return _itemCode; }
            set { _itemCode = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string ItemSpec
        {
            get { return _itemSpec; }
            set { _itemSpec = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Units
        {
            get { return _units; }
            set { _units = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string OrderedBy
        {
            get { return _orderedBy; }
            set { _orderedBy = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string PerformedBy
        {
            get { return _performedBy; }
            set { _performedBy = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal Costs
        {
            get { return _costs; }
            set { _costs = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal Charges
        {
            get { return _charges; }
            set { _charges = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal VerifiedIndicator
        {
            get { return _verifiedIndicator; }
            set { _verifiedIndicator = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string EnteredBy
        {
            get { return _enteredBy; }
            set { _enteredBy = value; }
        }

        ///<summary>
        ///对应的核算项目分类
        ///</summary>
        public string ClassOnReckoning
        {
            get { return _classOnReckoning; }
            set { _classOnReckoning = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal InpbillItemNo
        {
            get { return _inpbillItemNo; }
            set { _inpbillItemNo = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal EventItemNo
        {
            get { return _eventItemNo; }
            set { _eventItemNo = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal ExchangeIndicator
        {
            get { return _exchangeIndicator; }
            set { _exchangeIndicator = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal StorageIndicator
        {
            get { return _storageIndicator; }
            set { _storageIndicator = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal BillAttr
        {
            get { return _billAttr; }
            set { _billAttr = value; }
        }

        ///<summary>
        ///供应商
        ///</summary>
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }

        ///<summary>
        ///计价时间
        ///</summary>
        public DateTime BillDate
        {
            get { return _billDate; }
            set { _billDate = value; }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        /// <returns></returns>
        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        /// <returns></returns>
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 对应的住院收据费用分类
        /// </summary>
        /// <returns></returns>
        public string ClassOnInRcpt
        {
            get { return _classOnInpRcpt; }
            set { _classOnInpRcpt = value; }
        }
        /// <summary>
        /// 对应的会计科目
        /// </summary>
        /// <returns></returns>
        public string SubjCode
        {
            get { return _subjCode; }
            set { _subjCode = value; }
        }
        /// <summary>
        /// 对应的病案首页费用分类
        /// </summary>
        /// <returns></returns>
        public string ClassOnMr
        {
            get { return _classOnMr; }
            set { _classOnMr = value; }
        }

        /// <summary>
        /// 开单医生
        /// </summary>
        /// <returns></returns>
        public string OrderedDoctor
        {
            get { return _ordered_doctor; }
            set { _ordered_doctor = value; }
        }
        /// <summary>
        /// 执行医生
        /// </summary>
        /// <returns></returns>
        public string PerformedDoctor
        {
            get { return _performed_doctor; }
            set { _performed_doctor = value; }
        }

        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedOperationBillItems))
                return false;
            MedOperationBillItems Oper = (MedOperationBillItems)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.OperId != Oper.OperId)
                return false;
            if (this.ItemNo != Oper.ItemNo)
                return false;
            if (this.ItemClass != Oper.ItemClass)
                return false;
            if (this.ItemName != Oper.ItemName)
                return false;
            if (this.ItemCode != Oper.ItemCode)
                return false;
            if (this.ItemSpec != Oper.ItemSpec)
                return false;
            if (this.Amount != Oper.Amount)
                return false;
            if (this.Units != Oper.Units)
                return false;
            if (this.OrderedBy != Oper.OrderedBy)
                return false;
            if (this.PerformedBy != Oper.PerformedBy)
                return false;
            if (this.Costs != Oper.Costs)
                return false;
            if (this.Charges != Oper.Charges)
                return false;
            if (this.Notes != Oper.Notes)
                return false;
            if (this.VerifiedIndicator != Oper.VerifiedIndicator)
                return false;
            if (this.EnteredBy != Oper.EnteredBy)
                return false;
            if (this.ClassOnReckoning != Oper.ClassOnReckoning)
                return false;
            if (this.InpbillItemNo != Oper.InpbillItemNo)
                return false;
            if (this.EventItemNo != Oper.EventItemNo)
                return false;
            if (this.ExchangeIndicator != Oper.ExchangeIndicator)
                return false;
            if (this.StorageIndicator != Oper.StorageIndicator)
                return false;
            if (this.BillAttr != Oper.BillAttr)
                return false;
            if (this.SupplierName != Oper.SupplierName)
                return false;
            if (this.EventItemNo != Oper.EventItemNo)
                return false;

            if (this.Operator != Oper.Operator)
                return false;
            if (this.Price != Oper.Price)
                return false;
            if (this.ClassOnInRcpt != Oper.ClassOnInRcpt)
                return false;
            if (this.SubjCode != Oper.SubjCode)
                return false;
            if (this.ClassOnMr != Oper.ClassOnMr)
                return false;
            return true;
        }
    }
}
