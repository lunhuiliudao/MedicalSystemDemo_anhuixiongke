
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:26
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedPatVisit
	/// </summary>
	[Serializable]
	public class MedPatVisit:ModelBase
	{
		#region define variable
		private string _patientId;
		private decimal _visitId;
		private string _DEPT_ADMISSION_TO = String.Empty;
		private DateTime _admissionDateTime;
		private string _deptDischargeFrom = String.Empty;
		private DateTime _dischargeDateTime;
		private string _occupation = String.Empty;
		private string _maritalStatus = String.Empty;
		private string _identity = String.Empty;
		private string _armedServices = String.Empty;
		private string _duty = String.Empty;
		private string _topUnit = String.Empty;
		private decimal _serviceSystemIndicator;
		private string _unitInContract = String.Empty;
		private string _chargeType = String.Empty;
		private decimal _workingStatus;
		private string _insuranceType = String.Empty;
		private string _insuranceNo = String.Empty;
		private string _serviceAgency = String.Empty;
		private string _mailingAddress = String.Empty;
		private string _zipCode = String.Empty;
		private string _nextOfKin = String.Empty;
		private string _relationship = String.Empty;
		private string _nextOfKinAddr = String.Empty;
		private string _nextOfKinZipcode = String.Empty;
		private string _nextOfKinPhone = String.Empty;
	 
		private string _admissionCause = String.Empty;
		private DateTime _consultingDate;
		private string _patAdmCondition = String.Empty;
		private string _consultingDoctor = String.Empty;
		private string _admittedBy = String.Empty;
		private decimal _emerTreatTimes;
		private decimal _escEmerTimes;
		private decimal _seriousCondDays;
		private decimal _criticalCondDays;
		private decimal _icuDays;
		private decimal _ccuDays;
		private decimal _specLevelNursDays;
		private decimal _firstLevelNursDays;
		private decimal _secondLevelNursDays;
		private decimal _autopsyIndicator;
		private string _bloodType = String.Empty;
		private string _bloodTypeRh = String.Empty;
		private decimal _infusionReactTimes;
		private decimal _bloodTranTimes;
		private decimal _bloodTranVol;
		private decimal _bloodTranReactTimes;
		private decimal _decubitalUlcerTimes;
		private string _alergyDrugs = String.Empty;
		private string _adverseReactionDrugs = String.Empty;
		private string _mrValue = String.Empty;
		private string _mrQuality = String.Empty;
		private decimal _followIndicator;
		private decimal _followInterval;
		private string _followIntervalUnits = String.Empty;
		private string _director = String.Empty;
		private string _attendingDoctor = String.Empty;
		private string _doctorInCharge = String.Empty;
		private string _dischargeDisposition = String.Empty;
		private decimal _totalCosts;
		private decimal _totalPayments;
		private DateTime _catalogDate;
		private string _cataloger = String.Empty;
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
		private decimal _bodyHeight;
		private decimal _bodyWeight;
		private string _patientCondition = String.Empty;
		private string _abnormal = String.Empty;
        private string _inpNo;
        private Nullable<decimal> _patientSource;

        private string _hospBranch; // HOSP_BRANCH
		#endregion
		
		#region public property

        public string InpNo
        {
            get { return _inpNo; }
            set { _inpNo = value; }
        }

        public Nullable<decimal> PatientSource
        {
            get { return _patientSource; }

            set { _patientSource = value; }
        }

        /// <summary>
        /// 病区
        /// </summary>
        public string HospBranch
        {
            get { return _hospBranch; }
            set { _hospBranch = value; }
        
        }

		///<summary>
		///病人标识
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
		///病人本次住院标识;病人每次住院，分配一个不同的标识，与病人标识一起，构成一个病人一次住院的唯一标识。可使用住院次数的绝对值或相对值
		///</summary>
		public decimal VisitId
		{
			get {return _visitId;}
			set {_visitId = value;}
		}

		///<summary>
		///入院科室
		///</summary>
		public string DEPT_ADMISSION_TO
		{
			get {return _DEPT_ADMISSION_TO;}
			set {_DEPT_ADMISSION_TO = value;}
		}

		///<summary>
		///入院日期及时间
		///</summary>
		public DateTime AdmissionDateTime
		{
			get {return _admissionDateTime;}
			set {_admissionDateTime = value;}
		}

		///<summary>
		///出院科室
		///</summary>
		public string DeptDischargeFrom
		{
			get {return _deptDischargeFrom;}
			set {_deptDischargeFrom = value;}
		}

		///<summary>
		///出院日期及时间
		///</summary>
		public DateTime DischargeDateTime
		{
			get {return _dischargeDateTime;}
			set {_dischargeDateTime = value;}
		}

		///<summary>
		///职业
		///</summary>
		public string Occupation
		{
			get {return _occupation;}
			set {_occupation = value;}
		}

		///<summary>
		///婚姻状况
		///</summary>
		public string MaritalStatus
		{
			get {return _maritalStatus;}
			set {_maritalStatus = value;}
		}

		///<summary>
		///身份
		///</summary>
		public string Identity
		{
			get {return _identity;}
			set {_identity = value;}
		}

		///<summary>
		///军种
		///</summary>
		public string ArmedServices
		{
			get {return _armedServices;}
			set {_armedServices = value;}
		}

		///<summary>
		///勤务
		///</summary>
		public string Duty
		{
			get {return _duty;}
			set {_duty = value;}
		}

		///<summary>
		///隶属大单位
		///</summary>
		public string TopUnit
		{
			get {return _topUnit;}
			set {_topUnit = value;}
		}

		///<summary>
		///医疗体系病人标志
		///</summary>
		public decimal ServiceSystemIndicator
		{
			get {return _serviceSystemIndicator;}
			set {_serviceSystemIndicator = value;}
		}

		///<summary>
		///合同单位
		///</summary>
		public string UnitInContract
		{
			get {return _unitInContract;}
			set {_unitInContract = value;}
		}

		///<summary>
		///费别
		///</summary>
		public string ChargeType
		{
			get {return _chargeType;}
			set {_chargeType = value;}
		}

		///<summary>
		///在职标志
		///</summary>
		public decimal WorkingStatus
		{
			get {return _workingStatus;}
			set {_workingStatus = value;}
		}

		///<summary>
		///工作单位
		///</summary>
		public string InsuranceType
		{
			get {return _insuranceType;}
			set {_insuranceType = value;}
		}

		///<summary>
		///医疗保险号
		///</summary>
		public string InsuranceNo
		{
			get {return _insuranceNo;}
			set {_insuranceNo = value;}
		}

		///<summary>
		///工作单位
		///</summary>
		public string ServiceAgency
		{
			get {return _serviceAgency;}
			set {_serviceAgency = value;}
		}

		///<summary>
		///通信地址
		///</summary>
		public string MailingAddress
		{
			get {return _mailingAddress;}
			set {_mailingAddress = value;}
		}

		///<summary>
		///邮政编码
		///</summary>
		public string ZipCode
		{
			get {return _zipCode;}
			set {_zipCode = value;}
		}

		///<summary>
		///联系人姓名
		///</summary>
		public string NextOfKin
		{
			get {return _nextOfKin;}
			set {_nextOfKin = value;}
		}

		///<summary>
		///与联系人关系
		///</summary>
		public string Relationship
		{
			get {return _relationship;}
			set {_relationship = value;}
		}

		///<summary>
		///联系人地址
		///</summary>
		public string NextOfKinAddr
		{
			get {return _nextOfKinAddr;}
			set {_nextOfKinAddr = value;}
		}

		///<summary>
		///联系人邮政编码
		///</summary>
		public string NextOfKinZipcode
		{
			get {return _nextOfKinZipcode;}
			set {_nextOfKinZipcode = value;}
		}

		///<summary>
		///联系人电话
		///</summary>
		public string NextOfKinPhone
		{
			get {return _nextOfKinPhone;}
			set {_nextOfKinPhone = value;}
		}

		 

		///<summary>
		///住院目的
		///</summary>
		public string AdmissionCause
		{
			get {return _admissionCause;}
			set {_admissionCause = value;}
		}

		///<summary>
		///接诊日期
		///</summary>
		public DateTime ConsultingDate
		{
			get {return _consultingDate;}
			set {_consultingDate = value;}
		}

		///<summary>
		///入院病情
		///</summary>
		public string PatAdmCondition
		{
			get {return _patAdmCondition;}
			set {_patAdmCondition = value;}
		}

		///<summary>
		///门诊医师
		///</summary>
		public string ConsultingDoctor
		{
			get {return _consultingDoctor;}
			set {_consultingDoctor = value;}
		}

		///<summary>
		///办理住院者
		///</summary>
		public string AdmittedBy
		{
			get {return _admittedBy;}
			set {_admittedBy = value;}
		}

		///<summary>
		///抢救次数
		///</summary>
		public decimal EmerTreatTimes
		{
			get {return _emerTreatTimes;}
			set {_emerTreatTimes = value;}
		}

		///<summary>
		///抢救成功次数
		///</summary>
		public decimal EscEmerTimes
		{
			get {return _escEmerTimes;}
			set {_escEmerTimes = value;}
		}

		///<summary>
		///病重天数
		///</summary>
		public decimal SeriousCondDays
		{
			get {return _seriousCondDays;}
			set {_seriousCondDays = value;}
		}

		///<summary>
		///病危天数
		///</summary>
		public decimal CriticalCondDays
		{
			get {return _criticalCondDays;}
			set {_criticalCondDays = value;}
		}

		///<summary>
		///ICU天数
		///</summary>
		public decimal IcuDays
		{
			get {return _icuDays;}
			set {_icuDays = value;}
		}

		///<summary>
		///CCU天数
		///</summary>
		public decimal CcuDays
		{
			get {return _ccuDays;}
			set {_ccuDays = value;}
		}

		///<summary>
		///特别护理天数
		///</summary>
		public decimal SpecLevelNursDays
		{
			get {return _specLevelNursDays;}
			set {_specLevelNursDays = value;}
		}

		///<summary>
		///一级护理天数
		///</summary>
		public decimal FirstLevelNursDays
		{
			get {return _firstLevelNursDays;}
			set {_firstLevelNursDays = value;}
		}

		///<summary>
		///二级护理天数
		///</summary>
		public decimal SecondLevelNursDays
		{
			get {return _secondLevelNursDays;}
			set {_secondLevelNursDays = value;}
		}

		///<summary>
		///尸检标识
		///</summary>
		public decimal AutopsyIndicator
		{
			get {return _autopsyIndicator;}
			set {_autopsyIndicator = value;}
		}

		///<summary>
		///血型
		///</summary>
		public string BloodType
		{
			get {return _bloodType;}
			set {_bloodType = value;}
		}

		///<summary>
		///Rh血型
		///</summary>
		public string BloodTypeRh
		{
			get {return _bloodTypeRh;}
			set {_bloodTypeRh = value;}
		}

		///<summary>
		///输液反应次数
		///</summary>
		public decimal InfusionReactTimes
		{
			get {return _infusionReactTimes;}
			set {_infusionReactTimes = value;}
		}

		///<summary>
		///输血次数
		///</summary>
		public decimal BloodTranTimes
		{
			get {return _bloodTranTimes;}
			set {_bloodTranTimes = value;}
		}

		///<summary>
		///输血总量
		///</summary>
		public decimal BloodTranVol
		{
			get {return _bloodTranVol;}
			set {_bloodTranVol = value;}
		}

		///<summary>
		///输血反应次数
		///</summary>
		public decimal BloodTranReactTimes
		{
			get {return _bloodTranReactTimes;}
			set {_bloodTranReactTimes = value;}
		}

		///<summary>
		///发生褥疮次数
		///</summary>
		public decimal DecubitalUlcerTimes
		{
			get {return _decubitalUlcerTimes;}
			set {_decubitalUlcerTimes = value;}
		}

		///<summary>
		///过敏药物
		///</summary>
		public string AlergyDrugs
		{
			get {return _alergyDrugs;}
			set {_alergyDrugs = value;}
		}

		///<summary>
		///不良反应药物
		///</summary>
		public string AdverseReactionDrugs
		{
			get {return _adverseReactionDrugs;}
			set {_adverseReactionDrugs = value;}
		}

		///<summary>
		///病案价值
		///</summary>
		public string MrValue
		{
			get {return _mrValue;}
			set {_mrValue = value;}
		}

		///<summary>
		///病案质量
		///</summary>
		public string MrQuality
		{
			get {return _mrQuality;}
			set {_mrQuality = value;}
		}

		///<summary>
		///随诊标志
		///</summary>
		public decimal FollowIndicator
		{
			get {return _followIndicator;}
			set {_followIndicator = value;}
		}

		///<summary>
		///随诊期限
		///</summary>
		public decimal FollowInterval
		{
			get {return _followInterval;}
			set {_followInterval = value;}
		}

		///<summary>
		///随诊期限单位
		///</summary>
		public string FollowIntervalUnits
		{
			get {return _followIntervalUnits;}
			set {_followIntervalUnits = value;}
		}

		///<summary>
		///科主任
		///</summary>
		public string Director
		{
			get {return _director;}
			set {_director = value;}
		}

		///<summary>
		///主治医师
		///</summary>
		public string AttendingDoctor
		{
			get {return _attendingDoctor;}
			set {_attendingDoctor = value;}
		}

		///<summary>
		///经治医师
		///</summary>
		public string DoctorInCharge
		{
			get {return _doctorInCharge;}
			set {_doctorInCharge = value;}
		}

		///<summary>
		///出院方式
		///</summary>
		public string DischargeDisposition
		{
			get {return _dischargeDisposition;}
			set {_dischargeDisposition = value;}
		}

		///<summary>
		///总费用
		///</summary>
		public decimal TotalCosts
		{
			get {return _totalCosts;}
			set {_totalCosts = value;}
		}

		///<summary>
		///实付费用
		///</summary>
		public decimal TotalPayments
		{
			get {return _totalPayments;}
			set {_totalPayments = value;}
		}

		///<summary>
		///编目日期
		///</summary>
		public DateTime CatalogDate
		{
			get {return _catalogDate;}
			set {_catalogDate = value;}
		}

		///<summary>
		///编目人
		///</summary>
		public string Cataloger
		{
			get {return _cataloger;}
			set {_cataloger = value;}
		}

		///<summary>
        ///保留字1 --WARD_CODE 病区代码
		///</summary>
		public string Reserved01
		{
			get {return _reserved01;}
			set {_reserved01 = value;}
		}

		///<summary>
		///保留字2--BED_NO 床号
		///</summary>
		public string Reserved02
		{
			get {return _reserved02;}
			set {_reserved02 = value;}
		}

		///<summary>
        ///保留字3--HIS VISIT_ID 住院号或者唯一编号
		///</summary>
		public string Reserved03
		{
			get {return _reserved03;}
			set {_reserved03 = value;}
		}

		///<summary>
        ///保留字4--DIAGNOSIS 诊断
		///</summary>
		public string Reserved04
		{
			get {return _reserved04;}
			set {_reserved04 = value;}
		}

		///<summary>
        ///保留字5--入科时间 和PATS_IN_HOSPITAL字段 AdmWardDateTime 相同
		///</summary>
		public string Reserved05
		{
			get {return _reserved05;}
			set {_reserved05 = value;}
		}

		///<summary>
		///保留字6--MEMO 备注
		///</summary>
		public string Reserved06
		{
			get {return _reserved06;}
			set {_reserved06 = value;}
		}

		///<summary>
		///保留字07 --护理登记
		///</summary>
		public string Reserved07
		{
			get {return _reserved07;}
			set {_reserved07 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved08
		{
			get {return _reserved08;}
			set {_reserved08 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved09
		{
			get {return _reserved09;}
			set {_reserved09 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved10
		{
			get {return _reserved10;}
			set {_reserved10 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public DateTime ReservedDate01
		{
			get {return _reservedDate01;}
			set {_reservedDate01 = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public DateTime ReservedDate02
		{
			get {return _reservedDate02;}
			set {_reservedDate02 = value;}
		}

		///<summary>
		///身高
		///</summary>
		public decimal BodyHeight
		{
			get {return _bodyHeight;}
			set {_bodyHeight = value;}
		}

		///<summary>
		///体重
		///</summary>
		public decimal BodyWeight
		{
			get {return _bodyWeight;}
			set {_bodyWeight = value;}
		}

		///<summary>
		///病人情况
		///</summary>
		public string PatientCondition
		{
			get {return _patientCondition;}
			set {_patientCondition = value;}
		}

		///<summary>
		///阳性标志
		///</summary>
		public string Abnormal
		{
			get {return _abnormal;}
			set {_abnormal = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedPatVisit))
                return false;
            MedPatVisit Oper = (MedPatVisit)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.DEPT_ADMISSION_TO != Oper.DEPT_ADMISSION_TO)
                return false;
            if (this.AdmissionDateTime != Oper.AdmissionDateTime)
                return false;
            if (this.DeptDischargeFrom != Oper.DeptDischargeFrom)
                return false;
            if (this.DischargeDateTime != Oper.DischargeDateTime)
                return false;
            if (this.Occupation != Oper.Occupation)
                return false;
            if (this.MaritalStatus != Oper.MaritalStatus)
                return false;
            if (this.Identity != Oper.Identity)
                return false;
            if (this.ArmedServices != Oper.ArmedServices)
                return false;
            if (this.Duty != Oper.Duty)
                return false;
            if (this.TopUnit != Oper.TopUnit)
                return false;
            if (this.ServiceSystemIndicator != Oper.ServiceSystemIndicator)
                return false;
            if (this.UnitInContract != Oper.UnitInContract)
                return false;
            if (this.ChargeType != Oper.ChargeType)
                return false;
            if (this.WorkingStatus != Oper.WorkingStatus)
                return false;
            if (this.InsuranceType != Oper.InsuranceType)
                return false;
            if (this.InsuranceNo != Oper.InsuranceNo)
                return false;
            if (this.ServiceAgency != Oper.ServiceAgency)
                return false;
            if (this.MailingAddress != Oper.MailingAddress)
                return false;
            if (this.ZipCode != Oper.ZipCode)
                return false;
            if (this.NextOfKin != Oper.NextOfKin)
                return false;
            if (this.Relationship != Oper.Relationship)
                return false;
            if (this.NextOfKinAddr != Oper.NextOfKinAddr)
                return false;
            if (this.NextOfKinZipcode != Oper.NextOfKinZipcode)
                return false;
            if (this.NextOfKinPhone != Oper.NextOfKinPhone)
                return false;
        
            if (this.AdmissionCause != Oper.AdmissionCause)
                return false;
            if (this.ConsultingDate != Oper.ConsultingDate)
                return false;
            if (this.PatAdmCondition != Oper.PatAdmCondition)
                return false;
            if (this.ConsultingDoctor != Oper.ConsultingDoctor)
                return false;
            if (this.AdmittedBy != Oper.AdmittedBy)
                return false;
            if (this.EmerTreatTimes != Oper.EmerTreatTimes)
                return false;
            if (this.EscEmerTimes != Oper.EscEmerTimes)
                return false;
            if (this.SeriousCondDays != Oper.SeriousCondDays)
                return false;
            if (this.CriticalCondDays != Oper.CriticalCondDays)
                return false;
            if (this.IcuDays != Oper.IcuDays)
                return false;
            if (this.CcuDays != Oper.CcuDays)
                return false;
            if (this.SpecLevelNursDays != Oper.SpecLevelNursDays)
                return false;
            if (this.FirstLevelNursDays != Oper.FirstLevelNursDays)
                return false;
            if (this.SecondLevelNursDays != Oper.SecondLevelNursDays)
                return false;
            if (this.AutopsyIndicator != Oper.AutopsyIndicator)
                return false;
            if (this.BloodType != Oper.BloodType)
                return false;
            if (this.BloodTypeRh != Oper.BloodTypeRh)
                return false;
            if (this.InfusionReactTimes != Oper.InfusionReactTimes)
                return false;
            if (this.BloodTranTimes != Oper.BloodTranTimes)
                return false;
            if (this.BloodTranVol != Oper.BloodTranVol)
                return false;
            if (this.BloodTranReactTimes != Oper.BloodTranReactTimes)
                return false;
            if (this.DecubitalUlcerTimes != Oper.DecubitalUlcerTimes)
                return false;
            if (this.AlergyDrugs != Oper.AlergyDrugs)
                return false;
            if (this.AdverseReactionDrugs != Oper.AdverseReactionDrugs)
                return false;
            if (this.MrValue != Oper.MrValue)
                return false;
            if (this.MrQuality != Oper.MrQuality)
                return false;
            if (this.FollowIndicator != Oper.FollowIndicator)
                return false;
            if (this.FollowInterval != Oper.FollowInterval)
                return false;
            if (this.FollowIntervalUnits != Oper.FollowIntervalUnits)
                return false;
            if (this.Director != Oper.Director)
                return false;
            if (this.AttendingDoctor != Oper.AttendingDoctor)
                return false;
            if (this.DoctorInCharge != Oper.DoctorInCharge)
                return false;
            if (this.DischargeDisposition != Oper.DischargeDisposition)
                return false;
            if (this.TotalCosts != Oper.TotalCosts)
                return false;
            if (this.TotalPayments != Oper.TotalPayments)
                return false;
            if (this.CatalogDate != Oper.CatalogDate)
                return false;
            if (this.Cataloger != Oper.Cataloger)
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
            if (this.BodyHeight != Oper.BodyHeight)
                return false;
            if (this.BodyWeight != Oper.BodyWeight)
                return false;
            if (this.PatientCondition != Oper.PatientCondition)
                return false;
            if (this.Abnormal != Oper.Abnormal)
                return false;
            return true;
        }
	}
}
