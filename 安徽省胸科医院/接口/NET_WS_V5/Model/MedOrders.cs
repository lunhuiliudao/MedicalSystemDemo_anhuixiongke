
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:32
 * 
 * Notes:
 *
* ******************************************************************/
using System;
using System.Collections.Generic;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedOrders
	/// </summary>
	[Serializable]
	public class MedOrders:ModelBase
	{
		#region define variable

        public string HisOrderSubNo { get; set; }

		private string _patientId;
		private decimal _visitId;
        private string _orderNo;
		private decimal _orderSubNo;
        private string _orderSubNoStr;
		private decimal _repeatIndicator;
		private string _orderClass = String.Empty;
		private string _orderText = String.Empty;
		private string _orderCode = String.Empty;
		private decimal _dosage;
		private string _dosageUnits = String.Empty;
		private string _administration = String.Empty;
		private DateTime? _startDateTime;
		private DateTime? _stopDateTime;
		private decimal _duration;
		private string _durationUnits = String.Empty;
		private string _frequency = String.Empty;
		private decimal _freqCounter;
		private decimal _freqInterval;
		private string _freqIntervalUnit = String.Empty;
		private string _freqDetail = String.Empty;
		private string _performSchedule = String.Empty;
		private string _performResult = String.Empty;
		private string _orderingDept = String.Empty;
		private string _doctor = String.Empty;
		private string _stopDoctor = String.Empty;
		private string _nurse = String.Empty;
		private string _stopNurse = String.Empty;
		private DateTime _enterDateTime;
		private DateTime _stopOrderDateTime;
		private string _orderStatus = String.Empty;
		private decimal _billingAttr;
		private DateTime _lastPerformDateTime;
		private DateTime _lastAcctingDateTime;
		private decimal _drugBillingAttr;
		private string _treatSheetFlag = String.Empty;
		private string _phamStdCode = String.Empty;
		private decimal _amount;
		private string _reserved1 = String.Empty;
		private string _dispenseMemos = String.Empty;
		private decimal _currentPrescNo;
		private string _drugSpec = String.Empty;
		private decimal _qty;
		#endregion
		
		#region public property
		///<summary>
		///病人标识号
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
		///病人本次住院标识
		///</summary>
		public decimal VisitId
		{
			get {return _visitId;}
			set {_visitId = value;}
		}

		///<summary>
		///医嘱序号
		///</summary>
        public string OrderNo
		{
			get {return _orderNo;}
			set {_orderNo = value;}
		}

		///<summary>
		///医嘱子序号
		///</summary>
		public decimal OrderSubNo
		{
			get {return _orderSubNo;}
			set {_orderSubNo = value;}
		}

        ///<summary>
        ///医嘱子序号String类型 临时
        ///</summary>
        public string OrderSubNoStr
        {
            get { return _orderSubNoStr; }
            set { _orderSubNoStr = value; }
        }


		///<summary>
		///长期医嘱标志  0--临时 1--长期
		///</summary>
		public decimal RepeatIndicator
		{
			get {return _repeatIndicator;}
			set {_repeatIndicator = value;}
		}

		///<summary>
		///医嘱类别
		///</summary>
		public string OrderClass
		{
			get {return _orderClass;}
			set {_orderClass = value;}
		}

		///<summary>
		///医嘱正文
		///</summary>
		public string OrderText
		{
			get {return _orderText;}
			set {_orderText = value;}
		}

		///<summary>
		///医嘱代码
		///</summary>
		public string OrderCode
		{
			get {return _orderCode;}
			set {_orderCode = value;}
		}

		///<summary>
		///药品一次使用剂量
		///</summary>
		public decimal Dosage
		{
			get {return _dosage;}
			set {_dosage = value;}
		}

		///<summary>
		///剂量单位
		///</summary>
		public string DosageUnits
		{
			get {return _dosageUnits;}
			set {_dosageUnits = value;}
		}

		///<summary>
		///给药途径和方法;规范描述，是判断生成何种治疗单的依据，本系统定义
		///</summary>
		public string Administration
		{
			get {return _administration;}
			set {_administration = value;}
		}

		///<summary>
		///起始日期及时间
		///</summary>
		public DateTime? StartDateTime
		{
			get {return _startDateTime;}
			set {_startDateTime = value;}
		}

		///<summary>
		///停止日期及时间
		///</summary>
		public DateTime? StopDateTime
		{
			get {return _stopDateTime;}
			set {_stopDateTime = value;}
		}

		///<summary>
		///持续时间
		///</summary>
		public decimal Duration
		{
			get {return _duration;}
			set {_duration = value;}
		}

		///<summary>
		///持续时间单位
		///</summary>
		public string DurationUnits
		{
			get {return _durationUnits;}
			set {_durationUnits = value;}
		}

		///<summary>
		///执行频率描述;使用固定或固定格式的描述，如：3/日、TID，每xx分xx次，用户定义
		///</summary>
		public string Frequency
		{
			get {return _frequency;}
			set {_frequency = value;}
		}

		///<summary>
		///频率次数执行频率的次数部分
		///</summary>
		public decimal FreqCounter
		{
			get {return _freqCounter;}
			set {_freqCounter = value;}
		}

		///<summary>
		///频率间隔;执行频率的间隔部分
		///</summary>
		public decimal FreqInterval
		{
			get {return _freqInterval;}
			set {_freqInterval = value;}
		}

		///<summary>
		///频率间隔单位;
		///</summary>
		public string FreqIntervalUnit
		{
			get {return _freqIntervalUnit;}
			set {_freqIntervalUnit = value;}
		}

		///<summary>
		///执行时间详细描述;医嘱执行的详细时间表，用于对执行频率的补充，如：执行频率为3/日，补充为饭前执行或直接指定时间
		///</summary>
		public string FreqDetail
		{
			get {return _freqDetail;}
			set {_freqDetail = value;}
		}

		///<summary>
		///护士执行时间
		///</summary>
		public string PerformSchedule
		{
			get {return _performSchedule;}
			set {_performSchedule = value;}
		}

		///<summary>
		///执行结果
		///</summary>
		public string PerformResult
		{
			get {return _performResult;}
			set {_performResult = value;}
		}

		///<summary>
		///开医嘱科室
		///</summary>
		public string OrderingDept
		{
			get {return _orderingDept;}
			set {_orderingDept = value;}
		}

		///<summary>
		///开医嘱医生
		///</summary>
		public string Doctor
		{
			get {return _doctor;}
			set {_doctor = value;}
		}

		///<summary>
		///停医嘱医生
		///</summary>
		public string StopDoctor
		{
			get {return _stopDoctor;}
			set {_stopDoctor = value;}
		}

		///<summary>
		///开医嘱校对护士
		///</summary>
		public string Nurse
		{
			get {return _nurse;}
			set {_nurse = value;}
		}

		///<summary>
		///停医嘱校对护士
		///</summary>
		public string StopNurse
		{
			get {return _stopNurse;}
			set {_stopNurse = value;}
		}

		///<summary>
		///开医嘱录入日期及时间
		///</summary>
		public DateTime EnterDateTime
		{
			get {return _enterDateTime;}
			set {_enterDateTime = value;}
		}

		///<summary>
		///停医嘱录入日期及时间
		///</summary>
		public DateTime StopOrderDateTime
		{
			get {return _stopOrderDateTime;}
			set {_stopOrderDateTime = value;}
		}

		///<summary>
        ///医嘱状态;反映医嘱的执行状态，如新开、校对、执行、停止等，使用代码 1 新开 2 校对 3 停止 4 作废
		///</summary>
		public string OrderStatus
		{
			get {return _orderStatus;}
			set {_orderStatus = value;}
		}

		///<summary>
		///计价属性;反映本条医嘱计价方面的信息。0-正常计价 1-自带药 2-需手工计价 3-不计价。由护士录入医嘱时，根据医嘱内容确定。
		///</summary>
		public decimal BillingAttr
		{
			get {return _billingAttr;}
			set {_billingAttr = value;}
		}

		///<summary>
		///最后一次执行日期及时间
		///</summary>
		public DateTime LastPerformDateTime
		{
			get {return _lastPerformDateTime;}
			set {_lastPerformDateTime = value;}
		}

		///<summary>
		///最后一次计价日期及时间
		///</summary>
		public DateTime LastAcctingDateTime
		{
			get {return _lastAcctingDateTime;}
			set {_lastAcctingDateTime = value;}
		}

		///<summary>
		///药品计价属性
		///</summary>
		public decimal DrugBillingAttr
		{
			get {return _drugBillingAttr;}
			set {_drugBillingAttr = value;}
		}

		///<summary>
		///治疗单标志
		///</summary>
		public string TreatSheetFlag
		{
			get {return _treatSheetFlag;}
			set {_treatSheetFlag = value;}
		}

		///<summary>
		///药品代码
		///</summary>
		public string PhamStdCode
		{
			get {return _phamStdCode;}
			set {_phamStdCode = value;}
		}

		///<summary>
		///数量
		///</summary>
		public decimal Amount
		{
			get {return _amount;}
			set {_amount = value;}
		}

		///<summary>
		///保留字
		///</summary>
		public string Reserved1
		{
			get {return _reserved1;}
			set {_reserved1 = value;}
		}

        public string Reserved2 { get; set; }

		///<summary>
		///摆药描述
		///</summary>
		public string DispenseMemos
		{
			get {return _dispenseMemos;}
			set {_dispenseMemos = value;}
		}

		///<summary>
		///当前处方号
		///</summary>
		public decimal CurrentPrescNo
		{
			get {return _currentPrescNo;}
			set {_currentPrescNo = value;}
		}

		///<summary>
		///药品规格
		///</summary>
		public string DrugSpec
		{
			get {return _drugSpec;}
			set {_drugSpec = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal Qty
		{
			get {return _qty;}
			set {_qty = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public   bool Equals(object obj,ref string message)
        {
            if (!(obj is MedOrders))
                return false;
            MedOrders Oper = (MedOrders)obj;
            if (this.PatientId != Oper.PatientId)
            {
                message += "patientid is diff";
              
            }
            if (this.VisitId != Oper.VisitId)
            {
                message += "VisitId is diff";
              
            }
            if (this.OrderNo != Oper.OrderNo)
            {
                message += "OrderNo is diff";
               
            }
            if (this.OrderSubNo != Oper.OrderSubNo)
            {
                message += "OrderSubNo is diff";
              
            }
            if (this.RepeatIndicator != Oper.RepeatIndicator)
            {
                message += "RepeatIndicator is diff";
                
            }
            if (this.OrderClass != Oper.OrderClass)
            {
                message += "OrderClass is diff";
               
            }
            if (this.OrderText != Oper.OrderText)
            {
                message += "OrderText is diff";
             
            }
            if (this.OrderCode != Oper.OrderCode)
            {
                message += "OrderCode is diff";
               
            }
            if (this.Dosage != Oper.Dosage)
            {
                message += "Dosage is diff";
               
            }
            if (this.DosageUnits != Oper.DosageUnits)
            {
                message += "DosageUnits is diff";
             
            }
            if (this.Administration != Oper.Administration)
            {
                message += "Administration is diff";
           
            }
            if (this.StartDateTime != Oper.StartDateTime)
            {
                message += "StartDateTime is diff";
              
            }
            if (this.StopDateTime != Oper.StopDateTime)
            {
                message += "StopDateTime is diff";
              
            }
            if (this.Duration != Oper.Duration)
            {
                message += "Duration is diff";
               
            }
            if (this.DurationUnits != Oper.DurationUnits)
            {
                message += "DurationUnits is diff";
               
            }
            if (this.Frequency != Oper.Frequency)
            {
                message += "Frequency is diff";
                
            }
            if (this.FreqCounter != Oper.FreqCounter)
            {
                message += "FreqCounter is diff";
                
            }
            if (this.FreqInterval != Oper.FreqInterval)
            {
                message += "FreqInterval is diff";
              
            }
            if (this.FreqIntervalUnit != Oper.FreqIntervalUnit)
            {
                message += "FreqIntervalUnit is diff";
                
            }
            if (this.FreqDetail != Oper.FreqDetail)
            {
                message += "FreqDetail is diff";
                
            }
            if (this.PerformSchedule != Oper.PerformSchedule)
            {
                message += "PerformSchedule is diff";
               
            }
            if (this.PerformResult != Oper.PerformResult)
            {
                message += "PerformResult is diff";
               
            }
            if (this.OrderingDept != Oper.OrderingDept)
            {
                message += "OrderingDept is diff";
               
            }
            if (this.Doctor != Oper.Doctor)
            {
                message += "Doctor is diff";
                
            }
            if (this.StopDoctor != Oper.StopDoctor)
            {
                message += "StopDoctor is diff";
              
            }
            if (this.Nurse != Oper.Nurse)
            {
                message += "Nurse is diff";
               
            }
            if (this.StopNurse != Oper.StopNurse)
            {
                message += "StopNurse is diff";
            
            }
            if (this.EnterDateTime != Oper.EnterDateTime)
            {
                message += "EnterDateTime is diff";
           
            }
            if (this.StopOrderDateTime != Oper.StopOrderDateTime)
            {
                message += "StopOrderDateTime is diff";
             
            }
            if (this.OrderStatus != Oper.OrderStatus)
            {
                message += "OrderStatus is diff";
          
            }
            if (this.BillingAttr != Oper.BillingAttr)
            {
                message += "BillingAttr is diff";
            
            }
            if (this.LastPerformDateTime != Oper.LastPerformDateTime)
            {
                message += "LastPerformDateTime is diff";
         
            }
            if (this.LastAcctingDateTime != Oper.LastAcctingDateTime)
            {
                message += "LastAcctingDateTime is diff";
           
            }
            if (this.DrugBillingAttr != Oper.DrugBillingAttr)
            {
                message += "DrugBillingAttr is diff";
           
            }
            if (this.TreatSheetFlag != Oper.TreatSheetFlag)
            {
                message += "TreatSheetFlag is diff";
            
            }
            if (this.PhamStdCode != Oper.PhamStdCode)
            {
                message += "PhamStdCode is diff";
           
            }
            if (this.Amount != Oper.Amount)
            {
                message += "Amount is diff";
       
            }
            if (this.Reserved1 != Oper.Reserved1)
            {
                message += "Reserved1 is diff";
          
            }
            if (this.DispenseMemos != Oper.DispenseMemos)
            {
                message += "DispenseMemos is diff";
          
            }
            if (this.CurrentPrescNo != Oper.CurrentPrescNo)
            {
                message += "CurrentPrescNo is diff";
           
            }
            if (this.DrugSpec != Oper.DrugSpec)
            {
                message += "DrugSpec is diff";
          
            }
            if (this.Qty != Oper.Qty)
            {
                message += "Qty is diff";
            }
            if (!string.IsNullOrEmpty(message))
            {
                return false;
            }
            return true;
        }
	}

    public class FilterOrders
    {
        private List<MedOrders> DocareOrderList
        {
            get;
            set;
        }

        private List<MedOrders> HisOrderList
        {
            get;
            set;
        }

        public FilterOrders(List<MedOrders> docareList, List<MedOrders> hisList)
        {
            this.DocareOrderList = docareList;
            this.HisOrderList = hisList;
        }

        public string FilterMessage
        {
            get;
            set;
        }

        public List<MedOrders> FilterResult()
        {
            string filerMess = "";
            List<MedOrders> result = new List<MedOrders>();
            foreach (MedOrders hisEntity in HisOrderList)
            {
                MedOrders temp = DocareOrderList.Find(P => P.PatientId == hisEntity.PatientId && P.VisitId == hisEntity.VisitId && P.OrderNo == hisEntity.OrderNo && P.OrderSubNo == hisEntity.OrderSubNo && P.RepeatIndicator == hisEntity.RepeatIndicator);
                if (temp == null)
                {
                    result.Add(hisEntity);
                    continue;
                }
                string mess=string.Empty;
                if (!hisEntity.Equals(temp, ref mess))
                {
                    filerMess += "OrderNo:" + hisEntity.OrderNo + " OrderSubNo:" + hisEntity.OrderSubNo + ";" + mess + "/r/n";
                    result.Add(hisEntity);
                    continue;
                }
                
            }
            FilterMessage = filerMess;
            return result;
        }
    
    }
}
