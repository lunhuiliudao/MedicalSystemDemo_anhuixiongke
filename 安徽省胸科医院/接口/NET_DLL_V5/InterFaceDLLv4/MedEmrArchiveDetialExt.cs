
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010-08-31 17:52:57
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace InterFaceV5
{
	/// <summary>
	///MedEmrArchiveDetialExt
	/// </summary>
	[Serializable]
	public class MedEmrArchiveDetialExt
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
		private byte[] _emrXmlFile;
		private string _emrXmlName = String.Empty;
		private string _reserved01 = String.Empty;
		private string _reserved02 = String.Empty;
		private string _reserved03 = String.Empty;
		private string _reserved04 = String.Empty;
		private string _reserved05 = String.Empty;
		private decimal _reserved06;
		private decimal _reserved07;
        private byte[] _reserved08;
        private byte[] _reserved09;
		#endregion
		
		#region public property
		///<summary>
		///
		///</summary>
		public string PatientId
		{
			get {return _patientId;}
			set {_patientId = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal VisitId
		{
			get {return _visitId;}
			set {_visitId = value;}
		}

		///<summary>
		///
		///</summary>
		public string MrClass
		{
			get {return _mrClass;}
			set {_mrClass = value;}
		}

		///<summary>
		///
		///</summary>
		public string MrSubClass
		{
			get {return _mrSubClass;}
			set {_mrSubClass = value;}
		}

		///<summary>
		///
		///</summary>
		public string ArchiveKey
		{
			get {return _archiveKey;}
			set {_archiveKey = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal EmrFileIndex
		{
			get {return _emrFileIndex;}
			set {_emrFileIndex = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal ArchiveTimes
		{
			get {return _archiveTimes;}
			set {_archiveTimes = value;}
		}

		///<summary>
		///
		///</summary>
		public string Topic
		{
			get {return _topic;}
			set {_topic = value;}
		}

		///<summary>
		///
		///</summary>
		public string EmrFileName
		{
			get {return _emrFileName;}
			set {_emrFileName = value;}
		}

		///<summary>
		///
		///</summary>
		public string EmrType
		{
			get {return _emrType;}
			set {_emrType = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime ArchiveDateTime
		{
			get {return _archiveDateTime;}
			set {_archiveDateTime = value;}
		}

		///<summary>
		///
		///</summary>
		public string ArchiveType
		{
			get {return _archiveType;}
			set {_archiveType = value;}
		}

		///<summary>
		///
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
		///
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

		///<summary>
		///
		///</summary>
        public byte[] EmrXmlFile
		{
			get {return _emrXmlFile;}
			set {_emrXmlFile = value;}
		}

		///<summary>
		///
		///</summary>
		public string EmrXmlName
		{
			get {return _emrXmlName;}
			set {_emrXmlName = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved01
		{
			get {return _reserved01;}
			set {_reserved01 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved02
		{
			get {return _reserved02;}
			set {_reserved02 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved03
		{
			get {return _reserved03;}
			set {_reserved03 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved04
		{
			get {return _reserved04;}
			set {_reserved04 = value;}
		}

		///<summary>
		///
		///</summary>
		public string Reserved05
		{
			get {return _reserved05;}
			set {_reserved05 = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal Reserved06
		{
			get {return _reserved06;}
			set {_reserved06 = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal Reserved07
		{
			get {return _reserved07;}
			set {_reserved07 = value;}
		}

		///<summary>
		///
		///</summary>
        public byte[] Reserved08
		{
			get {return _reserved08;}
			set {_reserved08 = value;}
		}

		///<summary>
		///
		///</summary>
        public byte[] Reserved09
		{
			get {return _reserved09;}
			set {_reserved09 = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedEmrArchiveDetialExt))
                return false;
            MedEmrArchiveDetialExt Oper = (MedEmrArchiveDetialExt)obj;
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
			if (this.EmrXmlFile != Oper.EmrXmlFile)
                return false;
			if (this.EmrXmlName != Oper.EmrXmlName)
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
            return true;
        }
	}
}
