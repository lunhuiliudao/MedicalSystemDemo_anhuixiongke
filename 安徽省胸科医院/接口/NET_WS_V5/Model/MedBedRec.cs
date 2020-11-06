
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:29
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedBedRec
	/// </summary>
	[Serializable]
	public class MedBedRec
	{
		#region define variable
		private string _wardCode;
		private string _bedNo;
		private string _bedLabel = String.Empty;
		private string _roomNo = String.Empty;
		private string _deptCode = String.Empty;
		private string _bedApprovedType = String.Empty;
		private string _bedSexType = String.Empty;
		private string _bedClass = String.Empty;
		private string _bedStatus = String.Empty;
		private decimal _icuIndicator;
		private string _monitorLabel = String.Empty;
		private decimal _serialNo;
		#endregion
		
		#region public property
		///<summary>
		///病房（护理单元）代码;病床所在病房代码
		///</summary>
		public string WardCode
		{
			get {return _wardCode;}
			set {_wardCode = value;}
		}

		///<summary>
		///床号
		///</summary>
		public string BedNo
		{
			get {return _bedNo;}
			set {_bedNo = value;}
		}

		///<summary>
		///床标号
		///</summary>
		public string BedLabel
		{
			get {return _bedLabel;}
			set {_bedLabel = value;}
		}

		///<summary>
		///房间号
		///</summary>
		public string RoomNo
		{
			get {return _roomNo;}
			set {_roomNo = value;}
		}

		///<summary>
		///所属科室代码
		///</summary>
		public string DeptCode
		{
			get {return _deptCode;}
			set {_deptCode = value;}
		}

		///<summary>
		///床位编制类型;1 - 在编 2 - 加床 3 - 童床 0 - 非编
		///</summary>
		public string BedApprovedType
		{
			get {return _bedApprovedType;}
			set {_bedApprovedType = value;}
		}

		///<summary>
		///床位类型;1- 男床 2 -女床 3 -不限
		///</summary>
		public string BedSexType
		{
			get {return _bedSexType;}
			set {_bedSexType = value;}
		}

		///<summary>
		///床位等级;表示床位的收费等级
		///</summary>
		public string BedClass
		{
			get {return _bedClass;}
			set {_bedClass = value;}
		}

		///<summary>
		///床位状态;0 -未占用 1 -已占用 9 -未展开
		///</summary>
		public string BedStatus
		{
			get {return _bedStatus;}
			set {_bedStatus = value;}
		}

		///<summary>
		///ICU标志
		///</summary>
		public decimal IcuIndicator
		{
			get {return _icuIndicator;}
			set {_icuIndicator = value;}
		}

		///<summary>
		///监护仪标识;见监护仪字典MONITOR_DICT，在涉及到具体病人时操作，维护床位信息时不处理
		///</summary>
		public string MonitorLabel
		{
			get {return _monitorLabel;}
			set {_monitorLabel = value;}
		}

		///<summary>
		///排序
		///</summary>
		public decimal SerialNo
		{
			get {return _serialNo;}
			set {_serialNo = value;}
		}
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedBedRec))
                return false;
            MedBedRec Oper = (MedBedRec)obj;
            if (this.WardCode != Oper.WardCode)
                return false;
            if (this.BedNo != Oper.BedNo)
                return false;
            if (this.BedLabel != Oper.BedLabel)
                return false;
            if (this.RoomNo != Oper.RoomNo)
                return false;
            if (this.DeptCode != Oper.DeptCode)
                return false;
            if (this.BedApprovedType != Oper.BedApprovedType)
                return false;
            if (this.BedSexType != Oper.BedSexType)
                return false;
            if (this.BedClass != Oper.BedClass)
                return false;
            if (this.BedStatus != Oper.BedStatus)
                return false;
            if (this.IcuIndicator != Oper.IcuIndicator)
                return false;
            if (this.MonitorLabel != Oper.MonitorLabel)
                return false;
            if (this.SerialNo != Oper.SerialNo)
                return false;
            return true;
        }
	}
}
