
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010-08-31 17:52:50
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedEmrArchiveDetial
	/// </summary>
	[Serializable]
	public class MedEmrArchiveDetial
	{
		#region define variable
		private string _patientId;
		private decimal _visitId;
		private string _mrClass;
		private string _mrSubClass;
		private string _archiveKey;
		private decimal _emrFileIndex;
		private decimal _archiveTimes;
		private string _topic = String.Empty;
		private string _emrFileName = String.Empty;
		private string _emrType = String.Empty;
		private DateTime _archiveDateTime;
		private string _archiveType = String.Empty;
		private string _archiveStatus = String.Empty;
		private string _emrOwner = String.Empty;
		private string _operator = String.Empty;
		private string _archivePc = String.Empty;
		private string _archiveMode = String.Empty;
		private string _archiveAccess = String.Empty;
		private string _memo = String.Empty;
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
        ///本次住院标识
		///</summary>
		public decimal VisitId
		{
			get {return _visitId;}
			set {_visitId = value;}
		}

		///<summary>
		/// 归档类别 麻醉  重症
		///</summary>
		public string MrClass
		{
			get {return _mrClass;}
			set {_mrClass = value;}
		}

		///<summary>
        ///归档子类别 特护单 麻醉单 
		///</summary>
		public string MrSubClass
		{
			get {return _mrSubClass;}
			set {_mrSubClass = value;}
		}

		///<summary>
		///归档主键 手术次数 日期 如2010-11-28
		///</summary>
		public string ArchiveKey
		{
			get {return _archiveKey;}
			set {_archiveKey = value;}
		}

		///<summary>
		/// 归档的页码 PDF固定为0 图片为 0 1  2 3
		///</summary>
		public decimal EmrFileIndex
		{
			get {return _emrFileIndex;}
			set {_emrFileIndex = value;}
		}

		///<summary>
        ///归档次数
		///</summary>
		public decimal ArchiveTimes
		{
			get {return _archiveTimes;}
			set {_archiveTimes = value;}
		}

		///<summary>
		/// 归档名称
		///</summary>
		public string Topic
		{
			get {return _topic;}
			set {_topic = value;}
		}

		///<summary>
		/// EMR文件的名称
		///</summary>
		public string EmrFileName
		{
			get {return _emrFileName;}
			set {_emrFileName = value;}
		}

		///<summary>
		/// EMR的类别 PDF JPEG 
		///</summary>
		public string EmrType
		{
			get {return _emrType;}
			set {_emrType = value;}
		}

		///<summary>
		/// 归档时间
		///</summary>
		public DateTime ArchiveDateTime
		{
			get {return _archiveDateTime;}
			set {_archiveDateTime = value;}
		}

		///<summary>
		/// 归档类型
		///</summary>
		public string ArchiveType
		{
			get {return _archiveType;}
			set {_archiveType = value;}
		}

		///<summary>
		/// 归档状态 已归档 作废
		///</summary>
		public string ArchiveStatus
		{
			get {return _archiveStatus;}
			set {_archiveStatus = value;}
		}

		///<summary>
		///
		///</summary>
		public string EmrOwner
		{
			get {return _emrOwner;}
			set {_emrOwner = value;}
		}

		///<summary>
		/// 操作者
		///</summary>
		public string Operator
		{
			get {return _operator;}
			set {_operator = value;}
		}

		///<summary>
		///
		///</summary>
		public string ArchivePc
		{
			get {return _archivePc;}
			set {_archivePc = value;}
		}

		///<summary>
		///
		///</summary>
		public string ArchiveMode
		{
			get {return _archiveMode;}
			set {_archiveMode = value;}
		}

		///<summary>
		///
		///</summary>
		public string ArchiveAccess
		{
			get {return _archiveAccess;}
			set {_archiveAccess = value;}
		}

		///<summary>
		///
		///</summary>
		public string Memo
		{
			get {return _memo;}
			set {_memo = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedEmrArchiveDetial))
                return false;
            MedEmrArchiveDetial Oper = (MedEmrArchiveDetial)obj;
			if (this.PatientId != Oper.PatientId)
                return false;
			if (this.VisitId != Oper.VisitId)
                return false;
			if (this.MrClass != Oper.MrClass)
                return false;
			if (this.MrSubClass != Oper.MrSubClass)
                return false;
			if (this.ArchiveKey != Oper.ArchiveKey)
                return false;
			if (this.EmrFileIndex != Oper.EmrFileIndex)
                return false;
			if (this.ArchiveTimes != Oper.ArchiveTimes)
                return false;
			if (this.Topic != Oper.Topic)
                return false;
			if (this.EmrFileName != Oper.EmrFileName)
                return false;
			if (this.EmrType != Oper.EmrType)
                return false;
			if (this.ArchiveDateTime != Oper.ArchiveDateTime)
                return false;
			if (this.ArchiveType != Oper.ArchiveType)
                return false;
			if (this.ArchiveStatus != Oper.ArchiveStatus)
                return false;
			if (this.EmrOwner != Oper.EmrOwner)
                return false;
			if (this.Operator != Oper.Operator)
                return false;
			if (this.ArchivePc != Oper.ArchivePc)
                return false;
			if (this.ArchiveMode != Oper.ArchiveMode)
                return false;
			if (this.ArchiveAccess != Oper.ArchiveAccess)
                return false;
			if (this.Memo != Oper.Memo)
                return false;
            return true;
        }
	}
}
