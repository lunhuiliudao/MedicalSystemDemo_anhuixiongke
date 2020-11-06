
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:32
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace InterFaceV5
{
    /// <summary>
    ///MedPatsInHospital
    /// </summary>
    [Serializable]
    public class MedPatsInHospital
    {
        #region define variable
        private string _patientId;
        private decimal _visitId;
        private decimal _depId;
        private string _wardCode = String.Empty;
        private string _deptCode = String.Empty;
        private string _bedNo = String.Empty;
        private DateTime _admissionDateTime;
        private DateTime _admWardDateTime;
        private string _diagnosis = String.Empty;
        private string _patientCondition = String.Empty;
        private string _nursingClass = String.Empty;
        private string _doctorInCharge = String.Empty;
        private DateTime _operatingDate;
        private DateTime _billingDateTime;
        private decimal _prepayments;
        private decimal _totalCosts;
        private decimal _totalCharges;
        private string _guarantor = String.Empty;
        private string _guarantorOrg = String.Empty;
        private string _guarantorPhoneNum = String.Empty;
        private DateTime _billCheckedDateTime;
        private decimal _settledIndicator;
        private string _reserved01 = String.Empty;
        private string _reserved02 = String.Empty;
        private string _reserved03 = String.Empty;
        private string _reserved04 = String.Empty;
        private string _reserved05 = String.Empty;
        private string _reserved06 = String.Empty;
        private string _reserved07 = String.Empty;
        private string _reserved08 = String.Empty;
        private string _reserved09 = String.Empty;
        private string _reserved10 = String.Empty;
        private DateTime _reservedDate01;
        private DateTime _reservedDate02;
        private DateTime _startDateTime;
        private decimal _frequencyNurse;
        private string _nurseInCharge = String.Empty;
        #endregion

        #region public property
        ///<summary>
        ///病人标识号
        ///</summary>
        public string PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }

        ///<summary>
        ///病人本次住院标识;病人每次住院，分配一个不同的标识，与病人标识一起，构成一个病人一次住院的唯一标识。可使用住院次数的绝对值或相对值
        ///</summary>
        public decimal VisitId
        {
            get { return _visitId; }
            set { _visitId = value; }
        }
        ///<summary>
        ///入科次数
        ///</summary>
        public decimal DepId
        {
            get { return _depId; }
            set { _depId = value; }
        }
        ///<summary>
        ///所在病房代码;病人住院登记后，将该字段置为空，在入科时，将该字段置为本病房代码，转科时，由转出科室将该代码置为空
        ///</summary>
        public string WardCode
        {
            get { return _wardCode; }
            set { _wardCode = value; }
        }

        ///<summary>
        ///所在科室代码;病人住院所属科室的代码。用于区分一个病房包含多个科室的床位的情况。病人住院登记后，将该字段置为空，在入科分配床位时，根据床位属性将该字段置为所在科室代码，转科时，由转出科室将该代码置为空
        ///</summary>
        public string DeptCode
        {
            get { return _deptCode; }
            set { _deptCode = value; }
        }

        ///<summary>
        ///床号
        ///</summary>
        public string BedNo
        {
            get { return _bedNo; }
            set { _bedNo = value; }
        }

        ///<summary>
        ///入院日期及时间
        ///</summary>
        public DateTime AdmissionDateTime
        {
            get { return _admissionDateTime; }
            set { _admissionDateTime = value; }
        }

        ///<summary>
        ///入科日期及时间
        ///</summary>
        public DateTime AdmWardDateTime
        {
            get { return _admWardDateTime; }
            set { _admWardDateTime = value; }
        }

        ///<summary>
        ///主要诊断
        ///</summary>
        public string Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

        ///<summary>
        ///病情状态;病人危重情况
        ///</summary>
        public string PatientCondition
        {
            get { return _patientCondition; }
            set { _patientCondition = value; }
        }

        ///<summary>
        ///护理等级
        ///</summary>
        public string NursingClass
        {
            get { return _nursingClass; }
            set { _nursingClass = value; }
        }

        ///<summary>
        ///经治医生
        ///</summary>
        public string DoctorInCharge
        {
            get { return _doctorInCharge; }
            set { _doctorInCharge = value; }
        }

        ///<summary>
        ///手术日期
        ///</summary>
        public DateTime OperatingDate
        {
            get { return _operatingDate; }
            set { _operatingDate = value; }
        }

        ///<summary>
        ///计价截止日期及时间
        ///</summary>
        public DateTime BillingDateTime
        {
            get { return _billingDateTime; }
            set { _billingDateTime = value; }
        }

        ///<summary>
        ///预交金余额
        ///</summary>
        public decimal Prepayments
        {
            get { return _prepayments; }
            set { _prepayments = value; }
        }

        ///<summary>
        ///累计未结费用
        ///</summary>
        public decimal TotalCosts
        {
            get { return _totalCosts; }
            set { _totalCosts = value; }
        }

        ///<summary>
        ///优惠后未结费用
        ///</summary>
        public decimal TotalCharges
        {
            get { return _totalCharges; }
            set { _totalCharges = value; }
        }

        ///<summary>
        ///经济担保人
        ///</summary>
        public string Guarantor
        {
            get { return _guarantor; }
            set { _guarantor = value; }
        }

        ///<summary>
        ///经济担保人所在单位
        ///</summary>
        public string GuarantorOrg
        {
            get { return _guarantorOrg; }
            set { _guarantorOrg = value; }
        }

        ///<summary>
        ///经济担保人联系电话
        ///</summary>
        public string GuarantorPhoneNum
        {
            get { return _guarantorPhoneNum; }
            set { _guarantorPhoneNum = value; }
        }

        ///<summary>
        ///计价截止日期及时间
        ///</summary>
        public DateTime BillCheckedDateTime
        {
            get { return _billCheckedDateTime; }
            set { _billCheckedDateTime = value; }
        }

        ///<summary>
        ///出院结算标记
        ///</summary>
        public decimal SettledIndicator
        {
            get { return _settledIndicator; }
            set { _settledIndicator = value; }
        }

        ///<summary>
        ///保留字1--Charge_Type费别
        ///</summary>
        public string Reserved01
        {
            get { return _reserved01; }
            set { _reserved01 = value; }
        }

        ///<summary>
        ///保留字2-- MEMO 备注
        ///</summary>
        public string Reserved02
        {
            get { return _reserved02; }
            set { _reserved02 = value; }
        }

        ///<summary>
        ///保留字3--HIS VISIT_ID 住院号或者唯一编号
        ///</summary>
        public string Reserved03
        {
            get { return _reserved03; }
            set { _reserved03 = value; }
        }

        ///<summary>
        ///保留字3 --HIS INP_NO住院号 如果HIS有单独的住院号
        ///</summary>
        public string Reserved04
        {
            get { return _reserved04; }
            set { _reserved04 = value; }
        }

        ///<summary>
        ///保留字
        ///</summary>
        public string Reserved05
        {
            get { return _reserved05; }
            set { _reserved05 = value; }
        }

        ///<summary>
        ///保留字
        ///</summary>
        public string Reserved06
        {
            get { return _reserved06; }
            set { _reserved06 = value; }
        }

        ///<summary>
        ///保留字
        ///</summary>
        public string Reserved07
        {
            get { return _reserved07; }
            set { _reserved07 = value; }
        }

        ///<summary>
        ///保留字
        ///</summary>
        public string Reserved08
        {
            get { return _reserved08; }
            set { _reserved08 = value; }
        }

        ///<summary>
        ///保留字
        ///</summary>
        public string Reserved09
        {
            get { return _reserved09; }
            set { _reserved09 = value; }
        }

        ///<summary>
        ///保留字
        ///</summary>
        public string Reserved10
        {
            get { return _reserved10; }
            set { _reserved10 = value; }
        }

        ///<summary>
        ///保留字
        ///</summary>
        public DateTime ReservedDate01
        {
            get { return _reservedDate01; }
            set { _reservedDate01 = value; }
        }

        ///<summary>
        ///保留字
        ///</summary>
        public DateTime ReservedDate02
        {
            get { return _reservedDate02; }
            set { _reservedDate02 = value; }
        }

        ///<summary>
        ///护理记录单开始时间
        ///</summary>
        public DateTime StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        ///<summary>
        ///采集频率
        ///</summary>
        public decimal FrequencyNurse
        {
            get { return _frequencyNurse; }
            set { _frequencyNurse = value; }
        }

        ///<summary>
        ///主管护士
        ///</summary>
        public string NurseInCharge
        {
            get { return _nurseInCharge; }
            set { _nurseInCharge = value; }
        }
        #endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedPatsInHospital))
                return false;
            MedPatsInHospital Oper = (MedPatsInHospital)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.DepId != Oper.DepId)
                return false;
            if (this.WardCode != Oper.WardCode)
                return false;
            if (this.DeptCode != Oper.DeptCode)
                return false;
            if (this.BedNo != Oper.BedNo)
                return false;
            if (this.AdmissionDateTime != Oper.AdmissionDateTime)
                return false;
            if (this.AdmWardDateTime != Oper.AdmWardDateTime)
                return false;
            if (this.Diagnosis != Oper.Diagnosis)
                return false;
            if (this.PatientCondition != Oper.PatientCondition)
                return false;
            if (this.NursingClass != Oper.NursingClass)
                return false;
            if (this.DoctorInCharge != Oper.DoctorInCharge)
                return false;
            if (this.OperatingDate != Oper.OperatingDate)
                return false;
            if (this.BillingDateTime != Oper.BillingDateTime)
                return false;
            if (this.Prepayments != Oper.Prepayments)
                return false;
            if (this.TotalCosts != Oper.TotalCosts)
                return false;
            if (this.TotalCharges != Oper.TotalCharges)
                return false;
            if (this.Guarantor != Oper.Guarantor)
                return false;
            if (this.GuarantorOrg != Oper.GuarantorOrg)
                return false;
            if (this.GuarantorPhoneNum != Oper.GuarantorPhoneNum)
                return false;
            if (this.BillCheckedDateTime != Oper.BillCheckedDateTime)
                return false;
            if (this.SettledIndicator != Oper.SettledIndicator)
                return false;
            if (this.Reserved01 != Oper.Reserved01)
                return false;
            if (this.Reserved02 != Oper.Reserved02)
                return false;
            if (this.Reserved03 != Oper.Reserved03)
                return false;
            if (this.Reserved04 != Oper.Reserved04)
                return false;
            if (this.Reserved05 != Oper.Reserved05)
                return false;
            if (this.Reserved06 != Oper.Reserved06)
                return false;
            if (this.Reserved07 != Oper.Reserved07)
                return false;
            if (this.Reserved08 != Oper.Reserved08)
                return false;
            if (this.Reserved09 != Oper.Reserved09)
                return false;
            if (this.Reserved10 != Oper.Reserved10)
                return false;
            if (this.ReservedDate01 != Oper.ReservedDate01)
                return false;
            if (this.ReservedDate02 != Oper.ReservedDate02)
                return false;
            if (this.StartDateTime != Oper.StartDateTime)
                return false;
            if (this.FrequencyNurse != Oper.FrequencyNurse)
                return false;
            if (this.NurseInCharge != Oper.NurseInCharge)
                return false;
            return true;
        }
    }
}
