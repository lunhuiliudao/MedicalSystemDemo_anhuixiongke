
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-03-05 16:32:44
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
    /// <summary>
    ///MedPatInicuInformation
    /// </summary>
    [Serializable]
    public class MedPatInicuInformation
    {
        #region define variable
        private string _patientId;
        private decimal _visitId;
        private decimal _depId;
        private decimal _inIcuTimes;
        private DateTime _inIcuDatetime;
        private DateTime _outIcuDatetime;
        private string _diagnose = String.Empty;
        private string _bedNo = String.Empty;
        private string _doctor = String.Empty;
        private decimal _bodyWeight;
        private decimal _bodyHeight;
        private string _wardCode = String.Empty;
        private string _commitStatus = String.Empty;
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
        private string _reserved11 = String.Empty;
        private string _reserved12 = String.Empty;
        private string _reserved13 = String.Empty;
        private string _reserved14 = String.Empty;
        private string _reserved15 = String.Empty;
        private string _reserved16 = String.Empty;
        private string _reserved17 = String.Empty;
        private string _reserved18 = String.Empty;
        private string _reserved19 = String.Empty;
        private string _reserved20 = String.Empty;
        #endregion

        #region public property
        ///<summary>
        ///
        ///</summary>
        public string PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal VisitId
        {
            get { return _visitId; }
            set { _visitId = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal DepId
        {
            get { return _depId; }
            set { _depId = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal InIcuTimes
        {
            get { return _inIcuTimes; }
            set { _inIcuTimes = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime InIcuDatetime
        {
            get { return _inIcuDatetime; }
            set { _inIcuDatetime = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime OutIcuDatetime
        {
            get { return _outIcuDatetime; }
            set { _outIcuDatetime = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Diagnose
        {
            get { return _diagnose; }
            set { _diagnose = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string BedNo
        {
            get { return _bedNo; }
            set { _bedNo = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal BodyWeight
        {
            get { return _bodyWeight; }
            set { _bodyWeight = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal BodyHeight
        {
            get { return _bodyHeight; }
            set { _bodyHeight = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string WardCode
        {
            get { return _wardCode; }
            set { _wardCode = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string CommitStatus
        {
            get { return _commitStatus; }
            set { _commitStatus = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved01
        {
            get { return _reserved01; }
            set { _reserved01 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved02
        {
            get { return _reserved02; }
            set { _reserved02 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved03
        {
            get { return _reserved03; }
            set { _reserved03 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved04
        {
            get { return _reserved04; }
            set { _reserved04 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved05
        {
            get { return _reserved05; }
            set { _reserved05 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved06
        {
            get { return _reserved06; }
            set { _reserved06 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved07
        {
            get { return _reserved07; }
            set { _reserved07 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved08
        {
            get { return _reserved08; }
            set { _reserved08 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved09
        {
            get { return _reserved09; }
            set { _reserved09 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved10
        {
            get { return _reserved10; }
            set { _reserved10 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved11
        {
            get { return _reserved11; }
            set { _reserved11 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved12
        {
            get { return _reserved12; }
            set { _reserved12 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved13
        {
            get { return _reserved13; }
            set { _reserved13 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved14
        {
            get { return _reserved14; }
            set { _reserved14 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved15
        {
            get { return _reserved15; }
            set { _reserved15 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved16
        {
            get { return _reserved16; }
            set { _reserved16 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved17
        {
            get { return _reserved17; }
            set { _reserved17 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved18
        {
            get { return _reserved18; }
            set { _reserved18 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved19
        {
            get { return _reserved19; }
            set { _reserved19 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string Reserved20
        {
            get { return _reserved20; }
            set { _reserved20 = value; }
        }
        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedPatInicuInformation))
                return false;
            MedPatInicuInformation Oper = (MedPatInicuInformation)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.DepId != Oper.DepId)
                return false;
            if (this.InIcuTimes != Oper.InIcuTimes)
                return false;
            if (this.InIcuDatetime != Oper.InIcuDatetime)
                return false;
            if (this.OutIcuDatetime != Oper.OutIcuDatetime)
                return false;
            if (this.Diagnose != Oper.Diagnose)
                return false;
            if (this.BedNo != Oper.BedNo)
                return false;
            if (this.Doctor != Oper.Doctor)
                return false;
            if (this.BodyWeight != Oper.BodyWeight)
                return false;
            if (this.BodyHeight != Oper.BodyHeight)
                return false;
            if (this.WardCode != Oper.WardCode)
                return false;
            if (this.CommitStatus != Oper.CommitStatus)
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
            if (this.Reserved11 != Oper.Reserved11)
                return false;
            if (this.Reserved12 != Oper.Reserved12)
                return false;
            if (this.Reserved13 != Oper.Reserved13)
                return false;
            if (this.Reserved14 != Oper.Reserved14)
                return false;
            if (this.Reserved15 != Oper.Reserved15)
                return false;
            if (this.Reserved16 != Oper.Reserved16)
                return false;
            if (this.Reserved17 != Oper.Reserved17)
                return false;
            if (this.Reserved18 != Oper.Reserved18)
                return false;
            if (this.Reserved19 != Oper.Reserved19)
                return false;
            if (this.Reserved20 != Oper.Reserved20)
                return false;
            return true;
        }
    }
}
