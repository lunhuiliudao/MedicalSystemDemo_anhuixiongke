
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:00:56
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedLabResult
	/// </summary>
	[Serializable]
	public class MedLabResult:ModelBase
	{
		#region define variable
		private string _testNo;
		private decimal _itemNo;
		private decimal _printOrder;
		private string _reportItemName = String.Empty;
		private string _reportItemCode = String.Empty;
		private string _result = String.Empty;
		private string _units = String.Empty;
		private string _abnormalIndicator = String.Empty;
		private string _instrumentId = String.Empty;
		private DateTime _resultDateTime;
		private string _referenceResult = String.Empty;
		#endregion
		
		#region public property
		///<summary>
		///申请序号;对应检验申请主记录中的申请序号
		///</summary>
		public string TestNo
		{
			get {return _testNo;}
			set {_testNo = value;}
		}

		///<summary>
		///项目序号;对应检验项目中的项目序号
		///</summary>
		public decimal ItemNo
		{
			get {return _itemNo;}
			set {_itemNo = value;}
		}

		///<summary>
		///打印序号;反映该报告项目在打印报告单时排列的次序，与检验报告项目字典序号保持一致，在一个检验申请内部，可能不连续
		///</summary>
		public decimal PrintOrder
		{
			get {return _printOrder;}
			set {_printOrder = value;}
		}

		///<summary>
		///检验报告项目名称
		///</summary>
		public string ReportItemName
		{
			get {return _reportItemName;}
			set {_reportItemName = value;}
		}

		///<summary>
		///检验报告项目代码
		///</summary>
		public string ReportItemCode
		{
			get {return _reportItemCode;}
			set {_reportItemCode = value;}
		}

		///<summary>
		///检验结果值;正文描述，可以是定性描述，也可以是定量数值，对于没有值的项目不使用此字段
		///</summary>
		public string Result
		{
			get {return _result;}
			set {_result = value;}
		}

		///<summary>
		///检验结果单位;对检验结果为数值型的项目使用此字段
		///</summary>
		public string Units
		{
			get {return _units;}
			set {_units = value;}
		}

		///<summary>
		///结果正常标志;结果正常与否标志，N-正常 L-低 H-高
		///</summary>
		public string AbnormalIndicator
		{
			get {return _abnormalIndicator;}
			set {_abnormalIndicator = value;}
		}

		///<summary>
		///仪器编号
		///</summary>
		public string InstrumentId
		{
			get {return _instrumentId;}
			set {_instrumentId = value;}
		}

		///<summary>
        ///检验日期及时间 --术前访视必须要的字段
		///</summary>
		public DateTime ResultDateTime
		{
			get {return _resultDateTime;}
			set {_resultDateTime = value;}
		}

		///<summary>
		///结果参考值;检验结果参考值，可是参考范围，例如:0.1~9.0u
		///</summary>
		public string ReferenceResult
		{
			get {return _referenceResult;}
			set {_referenceResult = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedLabResult))
                return false;
            MedLabResult Oper = (MedLabResult)obj;
            if (this.TestNo != Oper.TestNo)
                return false;
            if (this.ItemNo != Oper.ItemNo)
                return false;
            if (this.PrintOrder != Oper.PrintOrder)
                return false;
            if (this.ReportItemName != Oper.ReportItemName)
                return false;
            if (this.ReportItemCode != Oper.ReportItemCode)
                return false;
            if (this.Result != Oper.Result)
                return false;
            if (this.Units != Oper.Units)
                return false;
            if (this.AbnormalIndicator != Oper.AbnormalIndicator)
                return false;
            if (this.InstrumentId != Oper.InstrumentId)
                return false;
            if (this.ResultDateTime != Oper.ResultDateTime)
                return false;
            if (this.ReferenceResult != Oper.ReferenceResult)
                return false;
            return true;
        }
	}
}
