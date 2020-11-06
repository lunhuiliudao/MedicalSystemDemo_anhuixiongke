
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:21
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
    /// <summary>
    ///MedPatMasterIndex
    /// </summary>
    [Serializable]
    public class MedPatMasterIndex:ModelBase
    {
        #region define variable
        private string _patientId;
        //private string _inpNo = String.Empty;
        private string _name = String.Empty;
        private string _namePhonetic = String.Empty;
        private string _sex = String.Empty;
        private DateTime _dateOfBirth;
        private string _birthPlace = String.Empty;
        private string _citizenship = String.Empty;
        private string _nation = String.Empty;
        private string _idNo = String.Empty;
        private string _identity = String.Empty;
        private string _chargeType = String.Empty;
        private string _unitInContract = String.Empty;
        private string _mailingAddress = String.Empty;
        private string _zipCode = String.Empty;
        private string _phoneNumberHome = String.Empty;
        private string _phoneNumberBusiness = String.Empty;
        private string _nextOfKin = String.Empty;
        private string _relationship = String.Empty;
        private string _nextOfKinAddr = String.Empty;
        private string _nextOfKinZipCode = String.Empty;
        private string _nextOfKinPhone = String.Empty;
        private DateTime _lastVisitDate;
        private decimal _vipIndicator;
        private DateTime _createDate;
        private string _operator = String.Empty;
        private string lclj = string.Empty;
        #endregion

        #region public property
        ///<summary>
        ///病人标识号;病人唯一标识号，可以由用户赋予具体的含义，如：病案号，门诊号等
        ///</summary>
        public string PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }

        /////<summary>
        /////住院号;病人住院标识（如果没有可同门诊号）,门诊病人为空
        /////</summary>
        //public string InpNo
        //{
        //    get {return _inpNo;}
        //    set {_inpNo = value;}
        //}

        ///<summary>
        ///姓名
        ///</summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        ///<summary>
        ///姓名拼音
        ///</summary>
        public string NamePhonetic
        {
            get { return _namePhonetic; }
            set { _namePhonetic = value; }
        }

        ///<summary>
        ///性别
        ///</summary>
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        ///<summary>
        ///出生日期
        ///</summary>
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        ///<summary>
        ///出生地
        ///</summary>
        public string BirthPlace
        {
            get { return _birthPlace; }
            set { _birthPlace = value; }
        }

        ///<summary>
        ///国籍
        ///</summary>
        public string Citizenship
        {
            get { return _citizenship; }
            set { _citizenship = value; }
        }

        ///<summary>
        ///民族
        ///</summary>
        public string Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        ///<summary>
        ///身份证号
        ///</summary>
        public string IdNo
        {
            get { return _idNo; }
            set { _idNo = value; }
        }

        ///<summary>
        ///身份
        ///</summary>
        public string Identity
        {
            get { return _identity; }
            set { _identity = value; }
        }

        ///<summary>
        ///费别
        ///</summary>
        public string ChargeType
        {
            get { return _chargeType; }
            set { _chargeType = value; }
        }

        /// <summary>
        /// 临床路径
        /// </summary>
        public string Lclj
        {
            get { return this.lclj; }
            set { this.lclj = value; }
        }

        ///<summary>
        ///合同单位
        ///</summary>
        public string UnitInContract
        {
            get { return _unitInContract; }
            set { _unitInContract = value; }
        }

        ///<summary>
        ///通信地址
        ///</summary>
        public string MailingAddress
        {
            get { return _mailingAddress; }
            set { _mailingAddress = value; }
        }

        ///<summary>
        ///邮政编码
        ///</summary>
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        ///<summary>
        ///家庭电话号码
        ///</summary>
        public string PhoneNumberHome
        {
            get { return _phoneNumberHome; }
            set { _phoneNumberHome = value; }
        }

        ///<summary>
        ///单位电话号码
        ///</summary>
        public string PhoneNumberBusiness
        {
            get { return _phoneNumberBusiness; }
            set { _phoneNumberBusiness = value; }
        }

        ///<summary>
        ///联系人姓名
        ///</summary>
        public string NextOfKin
        {
            get { return _nextOfKin; }
            set { _nextOfKin = value; }
        }

        ///<summary>
        ///与联系人关系
        ///</summary>
        public string Relationship
        {
            get { return _relationship; }
            set { _relationship = value; }
        }

        ///<summary>
        ///联系人地址
        ///</summary>
        public string NextOfKinAddr
        {
            get { return _nextOfKinAddr; }
            set { _nextOfKinAddr = value; }
        }

        ///<summary>
        ///联系人邮政编码
        ///</summary>
        public string NextOfKinZipCode
        {
            get { return _nextOfKinZipCode; }
            set { _nextOfKinZipCode = value; }
        }

        ///<summary>
        ///联系人电话号码
        ///</summary>
        public string NextOfKinPhone
        {
            get { return _nextOfKinPhone; }
            set { _nextOfKinPhone = value; }
        }

        /////<summary>
        /////上次就诊日期
        /////</summary>
        //public DateTime LastVisitDate
        //{
        //    get {return _lastVisitDate;}
        //    set {_lastVisitDate = value;}
        //}

        /////<summary>
        /////重要人物标志
        /////</summary>
        //public decimal VipIndicator
        //{
        //    get {return _vipIndicator;}
        //    set {_vipIndicator = value;}
        //}

        /////<summary>
        /////创建日期
        /////</summary>
        //public DateTime CreateDate
        //{
        //    get {return _createDate;}
        //    set {_createDate = value;}
        //}

        /////<summary>
        /////创建人
        /////</summary>
        //public string Operator
        //{
        //    get {return _operator;}
        //    set {_operator = value;}
        //}
        #endregion

        public string InPno { get; set; }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedPatMasterIndex))
                return false;
            MedPatMasterIndex Oper = (MedPatMasterIndex)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            //   if (this.InpNo != Oper.InpNo)
            //      return false;
            if (this.Name != Oper.Name)
                return false;
            if (this.NamePhonetic != Oper.NamePhonetic)
                return false;
            if (this.Sex != Oper.Sex)
                return false;
            if (this.DateOfBirth != Oper.DateOfBirth)
                return false;
            if (this.BirthPlace != Oper.BirthPlace)
                return false;
            if (this.Citizenship != Oper.Citizenship)
                return false;
            if (this.Nation != Oper.Nation)
                return false;
            if (this.IdNo != Oper.IdNo)
                return false;
            if (this.Identity != Oper.Identity)
                return false;
            if (this.UnitInContract != Oper.UnitInContract)
                return false;
            if (this.MailingAddress != Oper.MailingAddress)
                return false;
            if (this.ZipCode != Oper.ZipCode)
                return false;
            if (this.PhoneNumberHome != Oper.PhoneNumberHome)
                return false;
            if (this.PhoneNumberBusiness != Oper.PhoneNumberBusiness)
                return false;
            if (this.NextOfKin != Oper.NextOfKin)
                return false;
            if (this.Relationship != Oper.Relationship)
                return false;
            if (this.NextOfKinAddr != Oper.NextOfKinAddr)
                return false;
            if (this.NextOfKinZipCode != Oper.NextOfKinZipCode)
                return false;
            if (this.NextOfKinPhone != Oper.NextOfKinPhone)
                return false;
            return true;
        }
    }
}
