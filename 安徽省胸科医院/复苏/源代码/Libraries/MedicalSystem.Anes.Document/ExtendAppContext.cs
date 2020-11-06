using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document
{
    public class ExtendAppContext
    {
        public readonly static ExtendAppContext Current = new ExtendAppContext();
        private string _PatientID = string.Empty;
        private int _VisitID = 0;
        private int _OperID = 0;
        private bool _DoubleSelect = true;
        private bool _IsShowDevDateTimeEditor = true;
        private DateTime _anesStartTime = DateTime.Now;
        private Dictionary<string, DataTable> _codeTables = new Dictionary<string, DataTable>();
        private Dictionary<string, Dictionary<string, DataTable>> _codeTablesAllHospital = new Dictionary<string, Dictionary<string, DataTable>>();
        private string _EventNo = "0";
        private Dictionary<string, MedVitalSignCurveDetail> _VitalSignCurveDetailDict = null;
        private string _deptCode = string.Empty;
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode
        {
            get
            {
                return _deptCode;
            }
            set
            {
                _deptCode = value;
            }
        }
        public string PatientID
        {
            get { return _PatientID; }
            set { _PatientID = value; }
        }
        public int VisitID
        {
            get { return _VisitID; }
            set { _VisitID = value; }
        }
        public int OperID
        {
            get { return _OperID; }
            set { _OperID = value; }
        }

        public bool DoubleSelect
        {
            get { return _DoubleSelect; }
            set { _DoubleSelect = value; }
        }
        public bool IsShowDevDateTimeEditor
        {
            get { return _IsShowDevDateTimeEditor; }
            set { _IsShowDevDateTimeEditor = value; }
        }

        /// <summary>
        /// 字典表
        /// </summary>
        public Dictionary<string, DataTable> CodeTables
        {
            get
            {
                return _codeTables;
            }
            set
            {
                _codeTables = value;
            }
        }
        public Dictionary<string, Dictionary<string, DataTable>> CodeTablesAllHospital
        {
            get
            {
                return _codeTablesAllHospital;
            }
            set
            {
                _codeTablesAllHospital = value;
            }
        }

        public DateTime AnesStartTime
        {
            get
            {
                return _anesStartTime;
            }
            set
            {
                _anesStartTime = value;
            }
        }
        public string EventNo
        {
            get { return _EventNo; }
            set { _EventNo = value; }
        }

        public Dictionary<string, MedVitalSignCurveDetail> VitalSignCurveDetailDict
        {
            get { return _VitalSignCurveDetailDict; }
            set { _VitalSignCurveDetailDict = value; }
        }
        private Dictionary<string, string> _monitorFunctionCodeDict = new Dictionary<string, string>();
        public Dictionary<string, string> MonitorFunctionCodeDict
        {
            get { return _monitorFunctionCodeDict; }
            set { _monitorFunctionCodeDict = value; }
        }
        /// <summary>
        /// 打印抬头显示
        /// </summary>
        private bool isPrintTitle = false;
        public bool IsPrintTitle
        {
            get { return isPrintTitle; }
            set { isPrintTitle = value; }
        }
    }
}
