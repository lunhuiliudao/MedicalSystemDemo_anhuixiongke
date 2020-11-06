using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSytem.Soft.Model
{
    public class MedPriceList
    {
        /// <summary>
        /// 项目分类;本系统定义，见6.8价表项目分类字典。非空
        /// </summary>
        private string _itemClass;
        /// <summary>
        /// 项目代码;非空
        /// </summary>
        private string _itemCode; 
        /// <summary>
        /// 项目名称;项目的标准名称。非空
        /// </summary>
        private string _itemName; 
        /// <summary>
        /// 项目规格;药品规格、器械材料规格
        /// </summary>
        private string _itemSpec; 
        /// <summary>
        /// 单位;指计价单位，如：’片’，’针’，’人次’，’部位’等。见6.3计价单位字典
        /// </summary>
        private string _units; 
        /// <summary>
        /// 价格;标准价格，可对应全费价。非空
        /// </summary>
        private decimal _price; 
        /// <summary>
        /// 优惠价格;可对应自费价。非空
        /// </summary>
        private decimal _preferPrice; 
        /// <summary>
        /// 外宾价格
        /// </summary>
        private decimal _foreignerPrice; 
        /// <summary>
        /// 执行科室;执行科室代码,当为*时，表示有两个以上执行科室，如一个检查项目。当为空时，表示为各科都执行的项目，如静滴等普通治疗项目。
        /// </summary>
        private string _performedBy; 
        /// <summary>
        /// 费别屏蔽标志;通常情况下，按照费别，各种项目统一原则收费或优惠。特殊项目不按费别收费。此项为1表示此收费项目不考虑费别按规定价格收费，0表示按费别收费。非空
        /// </summary>
        private decimal _feeTypeMask; 
        /// <summary>
        /// 对应的住院收据费用分类;此项目对住院病人在收据中应归属的费用类别；非空；见6.11住院收据费用分类字典；使用代码。
        /// </summary>
        private string _classOnInpRcpt;
        /// <summary>
        /// 对应的门诊收据费用分类;此项目对门诊病人在收据中应归属的费用类别，见6.10门诊收据费用分类字典；非空；使用代码。
        /// </summary>
        private string _classOnOutpRcpt;
        /// <summary>
        /// 对应的核算项目分类;此项目在经济核算中应归属的费用类别；非空；见6.12核算项目分类字典；使用代码。
        /// </summary>
        private string _classOnReckoning; 
        /// <summary>
        /// 对应的会计科目;此项目收入归属的会计科目；非空；见6.13会计科目字典，使用代码。
        /// </summary>
        private string _subjCode; 
        /// <summary>
        /// 对应的病案首页费用分类;此项目对应住院病人在病案首页中应归属的费用类别；非空；使用规范名称，见6.9病案首页费用分类字典。
        /// </summary>
        private string _classOnMr; 
        /// <summary>
        /// 备注;用于定价条件说明
        /// </summary>
        private string _memo; 
        /// <summary>
        /// 起用日期;执行日期含起用日期当天
        /// </summary>
        private DateTime _startDate;
        /// <summary>
        /// 停止日期;执行日期含停止日期当天
        /// </summary>
        private DateTime _stopDate; 
        /// <summary>
        /// 操作员;操作员姓名
        /// </summary>
        private string _operator; 
        /// <summary>
        /// 录入日期及时间;非空
        /// </summary>
        private DateTime _enterDate; 
        /// <summary>
        /// 操作码
        /// </summary>
        private string _inputCode;
        /// <summary>
        /// 保留字段
        /// </summary>
        private string _reserved1;
        /// <summary>
        /// 保留字段
        /// </summary>
        private string _reserved2;
        /// <summary>
        /// 保留字段
        /// </summary>
        private string _reserved3;
        /// <summary>
        /// 保留字段
        /// </summary>
        private decimal _reserved4;
        /// <summary>
        /// 保留字段
        /// </summary>
        private decimal _reserved5;

        public string ItemClass
        {
            get { return _itemClass; }
            set { _itemClass = value; }
        }

        public string ItemCode
        {
            get { return _itemCode; }
            set { _itemCode = value; }
        }

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        public string ItemSpec
        {
            get { return _itemSpec; }
            set { _itemSpec = value; }
        }

        public string Units
        {
            get { return _units; }
            set { _units = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public decimal PreferPrice
        {
            get { return _preferPrice; }
            set { _preferPrice = value; }
        }

        public decimal ForeignerPrice
        {
            get { return _foreignerPrice; }
            set { _foreignerPrice = value; }
        }

        public string PerformedBy
        {
            get { return _performedBy; }
            set { _performedBy = value; }
        }

        public decimal FeeTypeMask
        {
            get { return _feeTypeMask; }
            set { _feeTypeMask = value; }
        }

        public string ClassOnInpRcpt
        {
            get { return _classOnInpRcpt; }
            set { _classOnInpRcpt = value; }
        }

        public string ClassOnOutpRcpt
        {
            get { return _classOnOutpRcpt; }
            set { _classOnOutpRcpt = value; }
        }

        public string ClassOnReckoning
        {
            get { return _classOnReckoning; }
            set { _classOnReckoning = value; }
        }

        public string SubjCode
        {
            get { return _subjCode; }
            set { _subjCode = value; }
        }

        public string ClassOnMr
        {
            get { return _classOnMr; }
            set { _classOnMr = value; }
        }

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime StopDate
        {
            get { return _stopDate; }
            set { _stopDate = value; }
        }

        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        public DateTime EnterDate
        {
            get { return _enterDate; }
            set { _enterDate = value; }
        }

        public string InputCode
        {
            get { return _inputCode; }
            set { _inputCode = value; }
        }

        public string Reserved1
        {
            get { return _reserved1; }
            set { _reserved1 = value; }
        }

        public string Reserved2
        {
            get { return _reserved2; }
            set { _reserved2 = value; }
        }

        public string Reserved3
        {
            get { return _reserved3; }
            set { _reserved3 = value; }
        }

        public decimal Reserved4
        {
            get { return _reserved4; }
            set { _reserved4 = value; }
        }

        public decimal Reserved5
        {
            get { return _reserved5; }
            set { _reserved5 = value; }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedPriceList))
                return false;
            MedPriceList Oper = (MedPriceList)obj;
            if (this.ItemClass != Oper.ItemClass)
                return false;
            if (this.ItemCode != Oper.ItemCode)
                return false;
            if (this.ItemName != Oper.ItemName)
                return false;
            if (this.ItemSpec != Oper.ItemSpec)
                return false;
            if (this.Units != Oper.Units)
                return false;
            if (this.Price != Oper.Price)
                return false;
            if (this.PreferPrice != Oper.PreferPrice)
                return false;
            if (this.InputCode != Oper.InputCode)
                return false;
            if (this.Reserved1 != Oper.Reserved1)
                return false;
            if (this.Reserved2 != Oper.Reserved2)
                return false;
            if (this.Reserved3 != Oper.Reserved3)
                return false;
            if (this.Reserved4 != Oper.Reserved4)
                return false;

            return true;
        }

    }
}
