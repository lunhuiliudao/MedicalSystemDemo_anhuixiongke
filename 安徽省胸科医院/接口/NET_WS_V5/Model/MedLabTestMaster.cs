
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:01
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedLabTestMaster
	/// </summary>
	[Serializable]
	public class MedLabTestMaster:ModelBase
	{
		#region define variable
		private string _testNo;
		private decimal _priorityIndicator;
		private string _patientId = String.Empty;
		private decimal _visitId;
		private string _workingId = String.Empty;
		private DateTime _executeDate;
		private string _name = String.Empty;
		private string _namePhonetic = String.Empty;
		private string _chargeType = String.Empty;
		private string _sex = String.Empty;
		private decimal _age;
		private string _testCause = String.Empty;
		private string _relevantClinicDiag = String.Empty;
		private string _specimen = String.Empty;
		private string _notesForSpcm = String.Empty;
		private DateTime _spcmReceivedDateTime;
		private DateTime _spcmSampleDateTime;
		private DateTime _requestedDateTime;
		private string _orderingDept = String.Empty;
		private string _orderingProvider = String.Empty;
		private string _performedBy = String.Empty;
		private string _resultStatus = String.Empty;
		private DateTime _resultsRptDateTime;
		private string _transcriptionist = String.Empty;
		private string _verifiedBy = String.Empty;
		private decimal _costs;
		private decimal _charges;
		private decimal _billingIndicator;
		private decimal _printIndicator;
		private string _subject = String.Empty;
		private string _barcode = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///申请序号;每个检验申请在整个系统范围内唯一标识
		///</summary>
		public string TestNo
		{
			get {return _testNo;}
			set {_testNo = value;}
		}

		///<summary>
		///优先标志;反映此申请的紧急程度。0-普通 1-紧急
		///</summary>
		public decimal PriorityIndicator
		{
			get {return _priorityIndicator;}
			set {_priorityIndicator = value;}
		}

		///<summary>
		///病人标识号
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
		///本次住院标识
		///</summary>
		public decimal VisitId
		{
			get {return _visitId;}
			set {_visitId = value;}
		}

		///<summary>
		///工作单号;检验科室为内部管理而给每个申请分配的标识号，在整个系统范围及同一科室不同日期的申请间并不唯一
		///</summary>
		public string WorkingId
		{
			get {return _workingId;}
			set {_workingId = value;}
		}

		///<summary>
        ///执行日期--术前访视必须要的字段 和MED_LAB_RESULT里面的 RESULT_DATE_TIME对应
		///</summary>
		public DateTime ExecuteDate
		{
			get {return _executeDate;}
			set {_executeDate = value;}
		}

		///<summary>
		///姓名
		///</summary>
		public string Name
		{
			get {return _name;}
			set {_name = value;}
		}

		///<summary>
		///姓名拼音
		///</summary>
		public string NamePhonetic
		{
			get {return _namePhonetic;}
			set {_namePhonetic = value;}
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
		///性别
		///</summary>
		public string Sex
		{
			get {return _sex;}
			set {_sex = value;}
		}

		///<summary>
		///年龄
		///</summary>
		public decimal Age
		{
			get {return _age;}
			set {_age = value;}
		}

		///<summary>
		///检验目的--非常重要
		///</summary>
		public string TestCause
		{
			get {return _testCause;}
			set {_testCause = value;}
		}

		///<summary>
		///临床诊断
		///</summary>
		public string RelevantClinicDiag
		{
			get {return _relevantClinicDiag;}
			set {_relevantClinicDiag = value;}
		}

		///<summary>
		///标本
		///</summary>
		public string Specimen
		{
			get {return _specimen;}
			set {_specimen = value;}
		}

		///<summary>
		///标本说明
		///</summary>
		public string NotesForSpcm
		{
			get {return _notesForSpcm;}
			set {_notesForSpcm = value;}
		}

		///<summary>
		///标本采样日期及时间
		///</summary>
		public DateTime SpcmReceivedDateTime
		{
			get {return _spcmReceivedDateTime;}
			set {_spcmReceivedDateTime = value;}
		}

		///<summary>
		///标本收到日期及时间
		///</summary>
		public DateTime SpcmSampleDateTime
		{
			get {return _spcmSampleDateTime;}
			set {_spcmSampleDateTime = value;}
		}

		///<summary>
		///申请日期及时间;医生开检验单的时间
		///</summary>
		public DateTime RequestedDateTime
		{
			get {return _requestedDateTime;}
			set {_requestedDateTime = value;}
		}

		///<summary>
		///申请科室
		///</summary>
		public string OrderingDept
		{
			get {return _orderingDept;}
			set {_orderingDept = value;}
		}

		///<summary>
		///申请医生
		///</summary>
		public string OrderingProvider
		{
			get {return _orderingProvider;}
			set {_orderingProvider = value;}
		}

		///<summary>
		///执行科室
		///</summary>
		public string PerformedBy
		{
			get {return _performedBy;}
			set {_performedBy = value;}
		}

		///<summary>
		///结果状态;反映申请的执行情况，如：收到标本、已执行、初步报告、确认报告等，初始时，由申请方填入，以后根据检查的执行情况，由执行者修改，使用代码，本系统定义 
		///</summary>
		public string ResultStatus
		{
			get {return _resultStatus;}
			set {_resultStatus = value;}
		}

		///<summary>
        ///报告日期及时间--非常重要 现在在界面上面的--日期
		///</summary>
		public DateTime ResultsRptDateTime
		{
			get {return _resultsRptDateTime;}
			set {_resultsRptDateTime = value;}
		}

		///<summary>
		///报告者
		///</summary>
		public string Transcriptionist
		{
			get {return _transcriptionist;}
			set {_transcriptionist = value;}
		}

		///<summary>
		///审核者
		///</summary>
		public string VerifiedBy
		{
			get {return _verifiedBy;}
			set {_verifiedBy = value;}
		}

		///<summary>
		///应收
		///</summary>
		public decimal Costs
		{
			get {return _costs;}
			set {_costs = value;}
		}

		///<summary>
		///实收
		///</summary>
		public decimal Charges
		{
			get {return _charges;}
			set {_charges = value;}
		}

		///<summary>
		///计费标志
		///</summary>
		public decimal BillingIndicator
		{
			get {return _billingIndicator;}
			set {_billingIndicator = value;}
		}

		///<summary>
		///打印标志
		///</summary>
		public decimal PrintIndicator
		{
			get {return _printIndicator;}
			set {_printIndicator = value;}
		}

		///<summary>
		///会计分类
		///</summary>
		public string Subject
		{
			get {return _subject;}
			set {_subject = value;}
		}

		///<summary>
		///条形码
		///</summary>
		public string Barcode
		{
			get {return _barcode;}
			set {_barcode = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedLabTestMaster))
                return false;
            MedLabTestMaster Oper = (MedLabTestMaster)obj;
            if (this.TestNo != Oper.TestNo)
                return false;
            if (this.PriorityIndicator != Oper.PriorityIndicator)
                return false;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.WorkingId != Oper.WorkingId)
                return false;
            if (this.ExecuteDate != Oper.ExecuteDate)
                return false;
            if (this.Name != Oper.Name)
                return false;
            if (this.NamePhonetic != Oper.NamePhonetic)
                return false;
            if (this.ChargeType != Oper.ChargeType)
                return false;
            if (this.Sex != Oper.Sex)
                return false;
            if (this.Age != Oper.Age)
                return false;
            if (this.TestCause != Oper.TestCause)
                return false;
            if (this.RelevantClinicDiag != Oper.RelevantClinicDiag)
                return false;
            if (this.Specimen != Oper.Specimen)
                return false;
            if (this.NotesForSpcm != Oper.NotesForSpcm)
                return false;
            if (this.SpcmReceivedDateTime != Oper.SpcmReceivedDateTime)
                return false;
            if (this.SpcmSampleDateTime != Oper.SpcmSampleDateTime)
                return false;
            if (this.RequestedDateTime != Oper.RequestedDateTime)
                return false;
            if (this.OrderingDept != Oper.OrderingDept)
                return false;
            if (this.OrderingProvider != Oper.OrderingProvider)
                return false;
            if (this.PerformedBy != Oper.PerformedBy)
                return false;
            if (this.ResultStatus != Oper.ResultStatus)
                return false;
            if (this.ResultsRptDateTime != Oper.ResultsRptDateTime)
                return false;
            if (this.Transcriptionist != Oper.Transcriptionist)
                return false;
            if (this.VerifiedBy != Oper.VerifiedBy)
                return false;
            if (this.Costs != Oper.Costs)
                return false;
            if (this.Charges != Oper.Charges)
                return false;
            if (this.BillingIndicator != Oper.BillingIndicator)
                return false;
            if (this.PrintIndicator != Oper.PrintIndicator)
                return false;
            if (this.Subject != Oper.Subject)
                return false;
            if (this.Barcode != Oper.Barcode)
                return false;
            return true;
        }
	}
}
