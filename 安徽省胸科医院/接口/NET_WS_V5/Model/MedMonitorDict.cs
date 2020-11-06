
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:32
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
    ///MedMonitorDict
	/// </summary>
	[Serializable]
	public class MedMonitorDict
	{
		#region define variable
        private string _monitorlabel;
        private string _manufirmname;
        private string _model;
        private decimal _interfacetype;
        private string _interfacedesc;
        private string _ipaddr;
        private string _macaddr;
        private DateTime _lastrecvtime;
        private string _lastrecvbedid;
        private decimal _duplexflag;
        private string _autoinflag;
        private string _commport;
        private decimal _baudrate;
        private decimal _bytesize;
        private decimal _parity;
        private decimal _stopbits;
        private decimal _foutx;
        private decimal _finx;
        private decimal _fhardware;
        private decimal _txqueuesize;
        private decimal _rxqueuesize;
        private decimal _xonlim;
        private decimal _xofflim;
        private string _xonchar;
        private string _xoffchar;
        private string _errorchar;
        private string _eventchar;
        private string _driverprog;
        private decimal _priority;
        private string _itemtype;
        private decimal _autoload;
        private DateTime _startdatetime;
        private decimal _defaultrecvfrequency;
        private decimal _currentrecvfrequency;
        private decimal _currentrecvtimesuplimit;
        private string _currentrecvitems;
        private string _wardcode;
        private decimal _wardtype;
        private string _bedno;
        private string _patientid;
        private decimal _visitid;
        private decimal _operid;
        private decimal _usingindicator;
        private decimal _frequencydisplay;
        private string _memo;
        private DateTime _datalogstarttime;
        private decimal _pcport;
        private string _datalogstatus;
        private decimal _ipport;
        private decimal _inport;
        private decimal _outport;
        private string _bednobind;
		#endregion
		
		#region public property
		///<summary>
        ///监护仪标识
		///</summary>
        public string MonitorLabel
		{
            get { return _monitorlabel; }
            set { _monitorlabel = value; }
		}

		///<summary>
		///
		///</summary>
        public string ManuFirmName
		{
            get { return _manufirmname; }
            set { _manufirmname = value; }
		}

		///<summary>
		///
		///</summary>
        public string Model
		{
            get { return _model; }
            set { _model = value; }
		}

		///<summary>
		///
		///</summary>
        public decimal InterfaceType
		{
            get { return _interfacetype; }
            set { _interfacetype = value; }
		}

        ///<summary>
        ///
        ///</summary>
        public string InterfaceDesc
        {
            get { return _interfacedesc; }
            set { _interfacedesc = value; }
        }


		///<summary>
		///
		///</summary>
        public string IpAddr
		{
            get { return _ipaddr; }
            set { _ipaddr = value; }
		}

		///<summary>
		///
		///</summary>
        public string MacAddr
		{
            get { return _macaddr; }
            set { _macaddr = value; }
		}

		///<summary>
		///
		///</summary>
        public DateTime LastRecvTime
		{
            get { return _lastrecvtime; }
            set { _lastrecvtime = value; }
		}

		///<summary>
		///
		///</summary>
        public string LastRecvBedId
		{
            get { return _lastrecvbedid; }
            set { _lastrecvbedid = value; }
		}

		///<summary>
		///
		///</summary>
        public decimal DuplexFlag
		{
            get { return _duplexflag; }
            set { _duplexflag = value; }
		}

		///<summary>
		///
		///</summary>
        public string AutoinFlag
		{
            get { return _autoinflag; }
            set { _autoinflag = value; }
		}

		///<summary>
		///
		///</summary>
        public string Commport
		{
            get { return _commport; }
            set { _commport = value; }
		}

        ///<summary>
        ///
        ///</summary>
        public decimal BaudRate
        {
            get { return _baudrate; }
            set { _baudrate = value; }
        }


        ///<summary>
        ///
        ///</summary>
        public decimal ByteSize
        {
            get { return _bytesize; }
            set { _bytesize = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal StopBits
        {
            get { return _stopbits; }
            set { _stopbits = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal FOutx
        {
            get { return _foutx; }
            set { _foutx = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal FInx
        {
            get { return _finx; }
            set { _finx = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal FHardware
        {
            get { return _fhardware; }
            set { _fhardware = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal TxQueuesize
        {
            get { return _txqueuesize; }
            set { _txqueuesize = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal RxQueuesize
        {
            get { return _rxqueuesize; }
            set { _rxqueuesize = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal XonLim
        {
            get { return _xonlim; }
            set { _xonlim = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal XoffLim
        {
            get { return _xofflim; }
            set { _xofflim = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string XonChar
        {
            get { return _xonchar; }
            set { _xonchar = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string XoffChar
        {
            get { return _xoffchar; }
            set { _xoffchar = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string ErrorChar
        {
            get { return _errorchar; }
            set { _errorchar = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string EventChar
        {
            get { return _eventchar; }
            set { _eventchar = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string DriverProg
        {
            get { return _driverprog; }
            set { _driverprog = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string ItemType
        {
            get { return _itemtype; }
            set { _itemtype = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal AutoLoad
        {
            get { return _autoload; }
            set { _autoload = value; }
        }

		///<summary>
		///
		///</summary>
        public DateTime StartDateTime
		{
            get { return _startdatetime; }
            set { _startdatetime = value; }
		}

        ///<summary>
        ///
        ///</summary>
        public decimal DefaultRecvFrequency
        {
            get { return _defaultrecvfrequency; }
            set { _defaultrecvfrequency = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal CurrentRecvFrequency
        {
            get { return _currentrecvfrequency; }
            set { _currentrecvfrequency = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal CurrentRecvtimesUplimit
        {
            get { return _currentrecvtimesuplimit; }
            set { _currentrecvtimesuplimit = value; }
        }

		///<summary>
		///
		///</summary>
        public string CurrentRecviTems
		{
            get { return _currentrecvitems; }
            set { _currentrecvitems = value; }
		}

		///<summary>
		///
		///</summary>
        public string WardCode
		{
            get { return _wardcode; }
            set { _wardcode = value; }
		}

		///<summary>
		///
		///</summary>
        public decimal WardType
		{
            get { return _wardtype; }
            set { _wardtype = value; }
		}

		///<summary>
		///
		///</summary>
        public string BedNo
		{
            get { return _bedno; }
            set { _bedno = value; }
		}

		///<summary>
		///
		///</summary>
        public string PatientId
		{
            get { return _patientid; }
            set { _patientid = value; }
		}

		///<summary>
		///
		///</summary>
        public decimal VisitId
		{
            get { return _visitid; }
            set { _visitid = value; }
		}

        ///<summary>
        ///
        ///</summary>
        public decimal OperId
        {
            get { return _operid; }
            set { _operid = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal UsingIndicator
        {
            get { return _usingindicator; }
            set { _usingindicator = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal FrequencyDisplay
        {
            get { return _frequencydisplay; }
            set { _frequencydisplay = value; }
        }

		///<summary>
		///
		///</summary>
        public string Memo
		{
            get { return _memo; }
            set { _memo = value; }
		}

		///<summary>
		///
		///</summary>
        public DateTime DatalogStartTime
		{
            get { return _datalogstarttime; }
            set { _datalogstarttime = value; }
		}

		///<summary>
		///
		///</summary>
        public decimal PcPort
		{
            get { return _pcport; }
            set { _pcport = value; }
		}

		///<summary>
		///
		///</summary>
        public string DatalogStatus
		{
            get { return _datalogstatus; }
            set { _datalogstatus = value; }
		}

        ///<summary>
        ///
        ///</summary>
        public decimal IpPort
        {
            get { return _ipport; }
            set { _ipport = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal InPort
        {
            get { return _inport; }
            set { _inport = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal OutPort
        {
            get { return _outport; }
            set { _outport = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string BedNoBind
        {
            get { return _bednobind; }
            set { _bednobind = value; }
        }
        
		#endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedMonitorDict))
                return false;
            MedMonitorDict Oper = (MedMonitorDict)obj;
            if (this.MonitorLabel != Oper.MonitorLabel)
                return false;
            if (this.ManuFirmName != Oper.ManuFirmName)
                return false;
            if (this.Model != Oper.Model)
                return false;
            if (this.InterfaceType != Oper.InterfaceType)
                return false;
            if (this.InterfaceDesc != Oper.InterfaceDesc)
                return false;
            if (this.IpAddr != Oper.IpAddr)
                return false;
            if (this.MacAddr != Oper.MacAddr)
                return false;
            if (this.LastRecvTime != Oper.LastRecvTime)
                return false;
            if (this.LastRecvBedId != Oper.LastRecvBedId)
                return false;
            if (this.DuplexFlag != Oper.DuplexFlag)
                return false;
            if (this.AutoinFlag != Oper.AutoinFlag)
                return false;
            if (this.Commport != Oper.Commport)
                return false;
            if (this.BaudRate != Oper.BaudRate)
                return false;
            if (this.ByteSize != Oper.ByteSize)
                return false;
            if (this.Parity != Oper.Parity)
                return false;
            if (this.StopBits != Oper.StopBits)
                return false;
            if (this.FOutx != Oper.FOutx)
                return false;
            if (this.FInx != Oper.FInx)
                return false;
            if (this.FHardware != Oper.FHardware)
                return false;
            if (this.TxQueuesize != Oper.TxQueuesize)
                return false;
            if (this.RxQueuesize != Oper.RxQueuesize)
                return false;
            if (this.XonLim != Oper.XonLim)
                return false;
            if (this.XoffLim != Oper.XoffLim)
                return false;
            if (this.XonChar != Oper.XonChar)
                return false;
            if (this.XoffChar != Oper.XoffChar)
                return false;
            if (this.ErrorChar != Oper.ErrorChar)
                return false;
            if (this.EventChar != Oper.EventChar)
                return false;
            if (this.DriverProg != Oper.DriverProg)
                return false;
            if (this.Priority != Oper.Priority)
                return false;
            if (this.ItemType != Oper.ItemType)
                return false;
            if (this.AutoLoad != Oper.AutoLoad)
                return false;
            if (this.StartDateTime != Oper.StartDateTime)
                return false;
            if (this.DefaultRecvFrequency != Oper.DefaultRecvFrequency)
                return false;
            if (this.CurrentRecvFrequency != Oper.CurrentRecvFrequency)
                return false;
            if (this.CurrentRecvtimesUplimit != Oper.CurrentRecvtimesUplimit)
                return false;
            if (this.CurrentRecviTems != Oper.CurrentRecviTems)
                return false;
            if (this.WardCode != Oper.WardCode)
                return false;
            if (this.WardType != Oper.WardType)
                return false;
            if (this.BedNo != Oper.BedNo)
                return false;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.OperId != Oper.OperId)
                return false;
            if (this.UsingIndicator != Oper.UsingIndicator)
                return false;
            if (this.FrequencyDisplay != Oper.FrequencyDisplay)
                return false;
            if (this.Memo != Oper.Memo)
                return false;
            if (this.DatalogStartTime != Oper.DatalogStartTime)
                return false;
            if (this.PcPort != Oper.PcPort)
                return false;
            if (this.DatalogStatus != Oper.DatalogStatus)
                return false;
            if (this.IpPort != Oper.IpPort)
                return false;
            if (this.InPort != Oper.InPort)
                return false;
            if (this.OutPort != Oper.OutPort)
                return false;
            if (this.BedNoBind != Oper.BedNoBind)
                return false;
            return true;
        }
	}
}
