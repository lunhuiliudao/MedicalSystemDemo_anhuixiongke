
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:04
 * 
 * Notes:
 *
* ******************************************************************/
using System;

namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedHisUsers
	/// </summary>
	[Serializable]
    public class MedInOrOutRec
	{
		#region define variable
        private string _patientId = String.Empty;
        private decimal _visitId;
        private decimal _depId;
        private DateTime _recordingDate;
        private DateTime _timePoint;
        private string _vitalSigns;
        private string _orderNo = String.Empty;
        private decimal _orderSubNo;
        private decimal _vitalSignsValues;
        private decimal _inOrOut;
        
		#endregion
		
		#region public property
		///<summary>
		///病人标识
		///</summary>
        public string PatientId
		{
            get { return _patientId; }
            set { _patientId = value; }
		}

		///<summary>
        ///VisitId
		///</summary>
        public decimal VisitId
		{
            get { return _visitId; }
            set { _visitId = value; }
		}

		///<summary>
        ///DepId
		///</summary>
        public decimal DepId
		{
            get { return _depId; }
            set { _depId = value; }
		}

		///<summary>
        ///RecordingDate
		///</summary>
        public DateTime RecordingDate
		{
            get { return _recordingDate; }
            set { _recordingDate = value; }
		}

		///<summary>
        ///TimePoint
		///</summary>
        public DateTime TimePoint
		{
            get { return _timePoint; }
            set { _timePoint = value; }
		}

		///<summary>
        ///VitalSigns
		///</summary>
        public string VitalSigns
		{
            get { return _vitalSigns; }
            set { _vitalSigns = value; }
		}

        ///<summary>
        ///OrderNo
        ///</summary>
        public string OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }


        ///<summary>
        ///OrderNo
        ///</summary>
        public decimal OrderSubNo
        {
            get { return _orderSubNo; }
            set { _orderSubNo = value; }
        }

        ///<summary>
        ///OrderNo
        ///</summary>
        public decimal VitalSignsValues
        {
            get { return _vitalSignsValues; }
            set { _vitalSignsValues = value; }
        }


        ///<summary>
        ///OrderNo
        ///</summary>
        public decimal InOrOut
        {
            get { return _inOrOut; }
            set { _inOrOut = value; }
        }
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedInOrOutRec))
                return false;
            MedInOrOutRec Oper = (MedInOrOutRec)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.DepId != Oper.DepId)
                return false;
            if (this.RecordingDate != Oper.RecordingDate)
                return false;
            if (this.TimePoint != Oper.TimePoint)
                return false;
            if (this.VitalSigns != Oper.VitalSigns)
                return false;
            if (this.OrderNo != Oper.OrderNo)
                return false;
            if (this.OrderSubNo != Oper.OrderSubNo)
                return false;
            if (this.VitalSignsValues != Oper.VitalSignsValues)
                return false;
            if (this.InOrOut != Oper.InOrOut)
                return false;
            return true;
        }
	}
}
