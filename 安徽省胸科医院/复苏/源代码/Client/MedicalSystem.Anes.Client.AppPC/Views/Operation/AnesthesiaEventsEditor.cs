using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.FrameWork.Enum;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Constants;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(true)]
    public partial class AnesthesiaEventsEditor : BaseView
    {
        CommonRepository commonRepository = new CommonRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();


        #region 构造方法

        public AnesthesiaEventsEditor(MED_PATIENT_CARD patientInfo, string eventNo)
        {
            _eventNo = eventNo;
            InitializeComponent();
            listEventDict = ExtendApplicationContext.Current.CommDict.EventDict;
            if (!ApplicationConfiguration.ShowYouDao)
            {
                //btnYouDao1.Visible = false;
                //lblTypes.Left -= btnDelete.Left - btnYouDao1.Left;
                //cmbTypes.Left -= btnDelete.Left - btnYouDao1.Left;
                //label1.Left -= btnDelete.Left - btnYouDao1.Left;
                //btnDelete.Left = btnYouDao1.Left;
                //lblYouDaoColor.Visible = false;
            }
            // dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AutoGenerateColumns = false;
            PerformPatientInformationChanged(patientInfo);
        }
        public void RefAnesthesiaEvent(MED_PATIENT_CARD patientInfo, string eventNo)
        {
            _eventNo = eventNo;
            _patientInfo = patientInfo;
            RefreshEventData();
        }
        #endregion 构造方法


        #region 事件接口

        private static readonly object _dataChangedEventHandle = new object();
        public event EventHandler DataChanged
        {
            add
            {
                Events.AddHandler(_dataChangedEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_dataChangedEventHandle, value);
            }
        }

        #endregion 事件接口

        #region 变量

        private string validValue = "valid";
        private bool _dataChanged = false;

        private decimal _maxItemNo = 0;

        private string _eventNo = "0";

        /// <summary>
        /// 病人基本信息
        /// </summary>
        private MED_PATIENT_CARD _patientInfo;
        private bool _showCloseButton = false;

        private bool _lock = false;
        private List<MED_ANESTHESIA_EVENT> _anesthesiaEventDataTable;
        private List<MED_ANESTHESIA_EVENT> _anesthesiaEventDefult;
        private List<MED_EVENT_DICT> listEventDict;
        private List<MED_EVENT_DICT> currentEventDict;
        #endregion 变量

        #region 属性

        /// <summary>
        /// 显示关闭按钮
        /// </summary>
        public bool ShowCloseButton
        {
            get
            {
                return _showCloseButton;
            }
            set
            {
                _showCloseButton = value;
                btnClose.Visible = false;
                if (_showCloseButton)
                {
                    if (ParentForm != null)
                    {
                        btnClose.Visible = _showCloseButton;
                        // ParentForm.CancelButton = btnClose;
                    }
                }
                else
                {
                    // pnlTitle.Visible = false;
                }
            }
        }

        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        private DateTime _startTime = DateTime.MaxValue;
        /// <summary>
        /// 麻醉开始时间
        /// </summary>
        private DateTime AnesDateTime
        {
            get
            {
                if (_anesthesiaEventDataTable != null && _anesthesiaEventDataTable.Count == 1)
                {
                    foreach (MED_ANESTHESIA_EVENT row in _anesthesiaEventDataTable)
                    {
                        if (row.START_TIME.HasValue)
                        {
                            _startTime = row.START_TIME.Value;
                        }
                    }
                }
                else if (_startTime.Equals(DateTime.MaxValue) && _anesthesiaEventDataTable.Count > 1)
                {
                    ResetStartTime();
                }
                if (!_startTime.Equals(DateTime.MaxValue))
                {
                    return _startTime;
                }
                else
                {
                    return accountRepository.GetServerTime().Data;
                }
            }
        }

        #endregion 属性

        #region 方法

        public void SetEventType(string typeName)
        {
            btnClose.Visible = true;
            btnCancel.Visible = true;
            BorderStyle = BorderStyle.FixedSingle;
        }

        public void SetText(string text)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (text.Equals(row.Cells["EventName"].Value))
                {
                    if (row.Cells["Column9"].Value != System.DBNull.Value)
                    {
                        dataGridView1.CurrentCell = row.Cells["Column9"];
                    }
                    else if (row.Cells["Column8"].Value != System.DBNull.Value)
                    {
                        dataGridView1.CurrentCell = row.Cells["Column8"];
                    }
                    else
                    {
                        dataGridView1.CurrentCell = row.Cells["Column10"];
                    }
                    dataGridView1.Focus();
                    break;
                }
            }
        }

        public void SetText(string text, DateTime startTime)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (text.Equals(row.Cells["EventName"].Value) && startTime.Equals((DateTime)row.Cells["StartTime"].Value))
                {
                    if (row.Cells["Column9"].Value != System.DBNull.Value)
                    {
                        dataGridView1.CurrentCell = row.Cells["Column9"];
                    }
                    else if (row.Cells["Column8"].Value != System.DBNull.Value)
                    {
                        dataGridView1.CurrentCell = row.Cells["Column8"];
                    }
                    else
                    {
                        dataGridView1.CurrentCell = row.Cells["Column10"];
                    }
                    dataGridView1.Focus();
                    break;
                }
            }
        }

        private void RaiseDataChanged()
        {
            EventHandler eventHandle = Events[_dataChangedEventHandle] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        protected void PerformPatientInformationChanged(MED_PATIENT_CARD patientInfo)
        {
            _patientInfo = patientInfo;
        }
        private BindingList<MED_ANESTHESIA_EVENT> list;
        /// <summary>
        /// 绑定病人麻醉事件
        /// </summary>
        private void BindEventTable()
        {
            //   MED_ANESTHESIA_EVENT row = new MED_ANESTHESIA_EVENT();
            _anesthesiaEventDataTable = operationInfoRepository.GetAnesEventList(_patientInfo.PATIENT_ID, _patientInfo.VISIT_ID, _patientInfo.OPER_ID, _eventNo).Data;
            _anesthesiaEventDefult = _anesthesiaEventDataTable.OrderBy(x => x.START_TIME).ToList(); ;
            list = new BindingList<MED_ANESTHESIA_EVENT>(_anesthesiaEventDefult);
            dataGridView1.DataSource = list;
            this.SetDefaultGridViewStyle(dataGridView1, 30);//, dataGridView1.RowTemplate.Height, dataGridView1.ColumnHeadersHeight 
        }

        private string GetTypeName(string itemType)
        {
            if (_eventNo == "2")
            {
            }
            else
            {
                if (AnesEventType._keyPairList.ContainsKey(itemType))
                {
                    return AnesEventType._keyPairList[itemType];
                }
            }
            return "";
        }

        public bool IsDirty
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        public bool IsDataChanged
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        public bool IsDataSaved
        {
            get
            {
                return _dataChanged;
            }
        }

        public bool Save()
        {
            if (!CheckItems())
            {
                return false;
            }
            bool saved = false;
            if (btnSave.Enabled)
            {
                if (_eventNo == "1" && _anesthesiaEventDataTable != null && _anesthesiaEventDataTable.Count > 0)
                {
                    _anesthesiaEventDataTable.ForEach(row =>
                    {
                        if (row.ITEM_NO < 500)
                            row.ITEM_NO += 500;
                    });
                }
                if (operationInfoRepository.SaveAnesthesiaEventList(_anesthesiaEventDataTable).Data > 0)
                {
                    saved = true;
                    btnSave.Enabled = false;
                    btnRefresh.Enabled = false;
                }
            }
            if (saved)
            {
                BindEventTable();
                //list = new BindingList<MED_ANESTHESIA_EVENT>(_anesthesiaEventDefult);
                //dataGridView1.DataSource = list;
                _dataChanged = true;
                // label1.ForeColor = Color.Blue;
                // label1.Text = "保存成功";
                MessageQueue.AddMessage("麻醉事件保存成功！", Color.Black);
                btnSave.Enabled = false;
                btnRefresh.Enabled = false;
                CallSaveHandle();
            }
            return saved;
        }

        private static readonly object _saveHandle = new object();
        public event EventHandler SaveHandle
        {
            add
            {
                Events.AddHandler(_saveHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_saveHandle, value);
            }
        }

        private void CallSaveHandle()
        {
            EventHandler eventHandle = Events[_saveHandle] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(null, null);
            }
        }

        private void ValidateNumber(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger = 0;
            float newdecimal = 0;
            if (((!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0) &&
                (!float.TryParse(e.FormattedValue.ToString(), out newdecimal) || newdecimal < 0))
                && e.FormattedValue.ToString() != "")
            {
                e.Cancel = true;
                // label1.ForeColor = Color.Red;
                // label1.Text = (sender as DataGridView).Columns[e.ColumnIndex].HeaderText + "字段必须为非负数字类型";
            }
            else
            {
                // label1.ForeColor = Color.Blue;
                // label1.Text = "要删除某时间点，必须选中整行!";
            }
        }

        private MED_ANESTHESIA_EVENT NewRow()
        {
            return new NewAnesthesiaEventRepository().NewAnesthesiaEventRow(_anesthesiaEventDataTable, ExtendApplicationContext.Current.PatientInformationExtend, _eventNo);
        }

        private MED_ANESTHESIA_EVENT NewRow(string eventName)
        {
            MED_ANESTHESIA_EVENT row = NewRow();
            row.EVENT_CLASS_CODE = "1";
            row.EVENT_ITEM_NAME = eventName;
            return row;
        }

        public MED_ANESTHESIA_EVENT NewRow(string itemClass, string itemName)
        {
            MED_ANESTHESIA_EVENT row = NewRow();
            row.EVENT_CLASS_CODE = itemClass;
            row.EVENT_ITEM_NAME = itemName;
            return row;
        }

        private MED_ANESTHESIA_EVENT NewRow(string itemClass, string itemName, string itemSpec
            , string itemCode, string administrator, decimal concentration, string concentrationUnit, decimal dosage
            , string dosageUnit, decimal performSpeed, string speedUnit, string supplierName, string eventAttr, int durativeIndicato)
        {
            MED_ANESTHESIA_EVENT row = NewRow();
            string typeName = GetTypeName(itemClass);
            if (typeName.Equals("麻药") || typeName.Equals("药剂") || typeName.Equals("输出") || typeName.Equals("用药") || typeName.Equals("输血")
                || typeName.Equals("输液") || typeName.Equals("出量") || typeName.Equals("输氧") || typeName.Equals("氧气"))
            {
                row.EVENT_ITEM_SPEC = itemSpec;
                row.ADMINISTRATOR = administrator;
                if (concentration > 0)
                    row.CONCENTRATION = concentration;
                row.CONCENTRATION_UNIT = concentrationUnit;
                if (dosage > 0)
                    row.DOSAGE = dosage;
                row.DOSAGE_UNITS = dosageUnit;
                if (performSpeed > 0)
                    row.PERFORM_SPEED = performSpeed;
                row.SPEED_UNIT = speedUnit;
                row.DURATIVE_INDICATOR = durativeIndicato;
            }
            row.EVENT_CLASS_CODE = itemClass;
            row.EVENT_ITEM_NAME = itemName;
            row.EVENT_ITEM_CODE = itemCode;
            row.SUPPLIER_NAME = supplierName;
            row.EVENT_ATTR = eventAttr;
            return row;
        }

        private MED_ANESTHESIA_EVENT NewRow(DataGridViewRow girdRow)
        {
            MED_ANESTHESIA_EVENT row = NewRow();
            if (girdRow.Cells["EVENT_CLASS_CODE"].Value != null)
                row.EVENT_CLASS_CODE = girdRow.Cells["EVENT_CLASS_CODE"].Value.ToString();
            if (girdRow.Cells["EVENT_ITEM_NAME"].Value != null)
                row.EVENT_ITEM_NAME = girdRow.Cells["EVENT_ITEM_NAME"].Value.ToString();
            if (girdRow.Cells["EVENT_ITEM_SPEC"].Value != null)
                row.EVENT_ITEM_SPEC = girdRow.Cells["EVENT_ITEM_SPEC"].Value.ToString();
            if (girdRow.Cells["EVENT_ITEM_CODE"].Value != null)
                row.EVENT_ITEM_CODE = girdRow.Cells["EVENT_ITEM_CODE"].Value.ToString();
            if (girdRow.Cells["ADMINISTRATOR"].Value != null)
                row.ADMINISTRATOR = girdRow.Cells["ADMINISTRATOR"].Value.ToString();
            if (girdRow.Cells["CONCENTRATION"].Value != null && girdRow.Cells["CONCENTRATION"].Value.ToString() != "")
            {
                row.CONCENTRATION = Convert.ToDecimal(girdRow.Cells["CONCENTRATION"].Value.ToString());
            }
            if (girdRow.Cells["CONCENTRATION_UNIT"].Value != null)
                row.CONCENTRATION_UNIT = girdRow.Cells["CONCENTRATION_UNIT"].Value.ToString();
            if (girdRow.Cells["DOSAGE"].Value != null && girdRow.Cells["DOSAGE"].Value.ToString() != "")
            {
                row.DOSAGE = Convert.ToDecimal(girdRow.Cells["DOSAGE"].Value.ToString());
            }
            if (girdRow.Cells["DOSAGE_UNITS"].Value != null)
                row.DOSAGE_UNITS = girdRow.Cells["DOSAGE_UNITS"].Value.ToString();
            if (girdRow.Cells["PERFORM_SPEED"].Value != null && girdRow.Cells["PERFORM_SPEED"].Value.ToString() != "")
            {
                row.PERFORM_SPEED = Convert.ToDecimal(girdRow.Cells["PERFORM_SPEED"].Value.ToString());
            }
            if (girdRow.Cells["SPEED_UNIT"].Value != null)
                row.SPEED_UNIT = girdRow.Cells["SPEED_UNIT"].Value.ToString();

            if (girdRow.Cells["SUPPLIER_NAME"].Value != null)
                row.SUPPLIER_NAME = girdRow.Cells["SUPPLIER_NAME"].Value.ToString();

            if (girdRow.Cells["DURATIVE_INDICATOR1"].Value != System.DBNull.Value)
            {
                row.DURATIVE_INDICATOR = Convert.ToInt32(girdRow.Cells["DURATIVE_INDICATOR1"].Value);
            }
            if (girdRow.Cells["EVENT_ATTR"].Value != null)
            {
                row.EVENT_ATTR = girdRow.Cells["EVENT_ATTR"].Value.ToString();
            }
            return row;
        }

        public void CopySpeedRow()
        {
            try
            {
                MED_ANESTHESIA_EVENT row = new NewAnesthesiaEventRepository().CopyAnesthesiaEventRow(_anesthesiaEventDataTable, ExtendApplicationContext.Current.PatientInformationExtend, _eventNo, dataGridView1.CurrentRow.Index);
                MED_ANESTHESIA_EVENT sourceRow = _anesthesiaEventDataTable[dataGridView1.CurrentRow.Index];
                if (!sourceRow.END_TIME.HasValue)
                {
                    sourceRow.END_TIME = accountRepository.GetServerTime().Data;
                    sourceRow.DURATIVE_INDICATOR = 1;
                }
                row.START_TIME = sourceRow.END_TIME.Value;
                AddRow(row);
                row.DURATIVE_INDICATOR = 1;
                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["Column9"];
            }
            catch { }
        }

        public void CopyConcentrationRow()
        {
            try
            {
                MED_ANESTHESIA_EVENT sourceRow = _anesthesiaEventDataTable[dataGridView1.CurrentRow.Index];
                MED_ANESTHESIA_EVENT row = new NewAnesthesiaEventRepository().CopyAnesthesiaEventRow(_anesthesiaEventDataTable, ExtendApplicationContext.Current.PatientInformationExtend, _eventNo, dataGridView1.CurrentRow.Index);
                if (!sourceRow.END_TIME.HasValue)
                {
                    sourceRow.END_TIME = accountRepository.GetServerTime().Data;
                    sourceRow.DURATIVE_INDICATOR = 1;
                }
                row.START_TIME = sourceRow.END_TIME.Value;
                AddRow(row);
                row.DURATIVE_INDICATOR = 1;
                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["Column8"];
            }
            catch { }
        }

        private void AddRow(MED_ANESTHESIA_EVENT row)
        {
            list.Add(row);
            _anesthesiaEventDataTable.Add(row);
            btnSave.Enabled = true;
            // _anesthesiaEventDefult.Add(row);
            btnRefresh.Enabled = true;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells["ItemNo"].Value.ToString().Equals(row.ITEM_NO.ToString()))
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells["StartTime"];
                    break;
                }
            }
            if (cmbTypes.SelectedIndex > 0)
            {
                int index = cmbTypes.Properties.Items.IndexOf(AnesEventType._keyPairList[row.EVENT_CLASS_CODE]);
                if (cmbTypes.Properties.Items.Count > index && index >= 0)
                {
                    cmbTypes.SelectedIndex = index;
                }
                else
                {
                    cmbTypes.SelectedIndex = 0;
                }
            }
        }

        private MED_ANESTHESIA_EVENT NewRow(MED_ANESTHESIA_EVENT row)
        {
            return new NewAnesthesiaEventRepository().CopyAnesthesiaEventRow(_anesthesiaEventDataTable, ExtendApplicationContext.Current.PatientInformationExtend, _eventNo, row);
        }
        private MED_ANESTHESIA_EVENT NewRow(MED_ANESTHESIA_EVENT_TEMPLET row)
        {
            MED_ANESTHESIA_EVENT eventRow = NewRow();
            eventRow.EVENT_CLASS_CODE = row.EVENT_ITEM_CLASS;
            eventRow.EVENT_ITEM_NAME = row.EVENT_ITEM_NAME;
            eventRow.EVENT_ITEM_SPEC = row.EVENT_ITEM_SPEC;
            eventRow.EVENT_ITEM_CODE = row.EVENT_ITEM_CODE;
            eventRow.ADMINISTRATOR = row.ADMINISTRATOR;
            eventRow.CONCENTRATION = row.CONCENTRATION;
            eventRow.CONCENTRATION_UNIT = row.CONCENTRATION_UNIT;
            eventRow.DOSAGE = row.DOSAGE;
            eventRow.DOSAGE_UNITS = row.DOSAGE_UNITS;
            eventRow.PERFORM_SPEED = row.PERFORM_SPEED;
            eventRow.SPEED_UNIT = row.SPEED_UNIT;
            eventRow.PERFORM_SPEED = row.PERFORM_SPEED;
            eventRow.EVENT_ATTR = row.EVENT_ATTR;
            eventRow.DURATIVE_INDICATOR = row.DURATIVE_INDICATOR;
            return eventRow;
        }
        public MED_ANESTHESIA_EVENT AddRow(object obj, Nullable<DateTime> startTime, decimal durative)
        {
            MED_ANESTHESIA_EVENT row = null;
            if (obj is DataGridViewRow)
            {
                row = NewRow(obj as DataGridViewRow);
            }
            else if (obj is MED_ANESTHESIA_EVENT)
            {
                row = NewRow(obj as MED_ANESTHESIA_EVENT);
            }
            else
            {
                if (obj is MED_ANESTHESIA_EVENT_TEMPLET)
                {
                    row = NewRow(obj as MED_ANESTHESIA_EVENT_TEMPLET);
                }
                else
                {
                    row = NewRow(obj.ToString());
                }
            }
            if (startTime != null)
            {
                row.START_TIME = (DateTime)startTime;
            }

            if (durative != 0)
            {
                if (durative != 999)
                {
                    row.END_TIME = (DateTime)row.START_TIME.Value.AddMinutes(double.Parse(durative.ToString())); // 结束时间为起始时间 + 持续(分钟)
                }
                row.DURATIVE_INDICATOR = 1;
            }

            AddRow(row);
            return row;
        }
        private void AddRow() { AddRow(""); }
        public MED_ANESTHESIA_EVENT AddRow(object obj)
        {
            return AddRow(obj, null, null);
        }
        public MED_ANESTHESIA_EVENT AddRow(object obj, Nullable<DateTime> startTime, Nullable<DateTime> endDate)
        {
            MED_ANESTHESIA_EVENT row = null;
            if (obj is DataGridViewRow)
            {
                row = NewRow(obj as DataGridViewRow);
            }
            else if (obj is DataRow)
            {
                row = NewRow(obj as MED_ANESTHESIA_EVENT);
            }
            else
            {
                row = NewRow(obj.ToString());
            }
            if (startTime != null)
            {
                row.START_TIME = (DateTime)startTime;
            }
            if (endDate != null)
            {
                row.END_TIME = (DateTime)endDate;
                row.DURATIVE_INDICATOR = 1;
            }
            AddRow(row);
            return row;
        }

        public MED_ANESTHESIA_EVENT AddRow(string itemClass, string itemName, string itemSpec
            , string itemCode, string administrator, decimal concentration, string concentrationUnit, decimal dosage
            , string dosageUnit, decimal performSpeed, string speedUnit, string supplierName, string eventAttr, int durativeIndicator)
        {
            MED_ANESTHESIA_EVENT row = NewRow(itemClass, itemName, itemSpec, itemCode, administrator, concentration, concentrationUnit
                , dosage, dosageUnit, performSpeed, speedUnit, supplierName, eventAttr, durativeIndicator);
            row.PATIENT_ID = _patientInfo.PATIENT_ID;
            row.VISIT_ID = _patientInfo.VISIT_ID;
            row.OPER_ID = _patientInfo.OPER_ID;
            row.EVENT_NO = _eventNo;
            AddRow(row);
            return row;
        }

        private DataGridViewRow GetGridRowByEventName(string eventName)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["EventName"].Value != null && row.Cells["EventName"].Value.ToString().Equals(eventName))
                {
                    return row;
                }
            }
            return null;
        }

        private bool IsEventNameExists(string eventName)
        {
            return GetGridRowByEventName(eventName) != null;
        }

        private DateTime TransDateTime(DateTime dateTime)
        {
            DateTime dt = AnesDateTime;
            dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
            DateTime dt1 = dateTime;
            dt1 = new DateTime(dt.Year, dt.Month, dt.Day, dt1.Hour, dt1.Minute, 0);
            if (dt1.AddHours(12) < dt) dt1 = dt1.AddDays(1);
            return dt1;
        }

        public void RefreshRow(MED_ANESTHESIA_EVENT row)
        {
            dataGridView1.Focus();
        }

        public bool CheckItems()
        {
            string noDosage = ",";
            List<MED_ANESTHESIA_INPUT_DICT> anesInput = ExtendApplicationContext.Current.CommDict.AnesInputDictDict;
            anesInput = anesInput.Where(x => x.ITEM_CLASS == "无剂量药品").ToList();
            if (anesInput != null && anesInput.Count > 0)
            {
                anesInput.ForEach(row =>
                {
                    noDosage += row.ITEM_NAME;
                });
            }
            noDosage += ",";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells["EventName"].Value == null || row.Cells["EventName"].Value == System.DBNull.Value
                    || string.IsNullOrEmpty(row.Cells["EventName"].Value.ToString()))
                {
                    //label1.ForeColor = Color.Red;
                    //label1.Text = "必须输入名称";
                    dataGridView1.CurrentCell = row.Cells["EventName"];
                    dataGridView1.Focus();
                    return false;
                }
                string typeName = GetTypeName(row.Cells["ItemType"].Value.ToString());
                if (typeName.Equals("麻药") || typeName.Equals("用药") || typeName.Equals("输血") || typeName.Equals("输液") || typeName.Equals("出量"))
                {
                    if (!typeName.Equals("输血") && (row.Cells["Column7"].Value == System.DBNull.Value || row.Cells["Column7"].Value == null || string.IsNullOrEmpty(row.Cells["Column7"].Value.ToString())))
                    {
                        if (typeName.Equals("输液"))
                        {
                            row.Cells["Column7"].Value = "ivgtt";
                        }
                    }
                    if (row.Cells["StartTime"].Value != System.DBNull.Value)
                    {
                        string text = "," + row.Cells["EventName"].Value.ToString() + ",";



                        if (!noDosage.Contains(text) && row.Cells["Column9"].Value == System.DBNull.Value && row.Cells["Column8"].Value == System.DBNull.Value
                            && row.Cells["Column10"].Value == System.DBNull.Value)
                        {
                            if (row.Cells["EventName"].Value == System.DBNull.Value || row.Cells["EventName"].Value == null
                                || (!row.Cells["EventName"].Value.ToString().StartsWith("@") && row.Cells["EventName"].Value.ToString().ToLower().Contains("ml") && row.Cells["EventName"].Value.ToString().ToLower().Contains("/")))
                            {
                            }
                            else
                            {
                                dataGridView1.CurrentCell = row.Cells["Column10"];
                                //  label1.ForeColor = Color.Red;
                                // label1.Text = "必须输入剂量";
                                dataGridView1.Focus();
                                return false;
                            }
                        }
                        if (row.Cells["Column10"].Value != System.DBNull.Value)
                        {
                            if (row.Cells["DosageUnit"].Value == System.DBNull.Value)
                            {
                                dataGridView1.CurrentCell = row.Cells["DosageUnit"];
                                //  label1.ForeColor = Color.Red;
                                //  label1.Text = "必须输入剂量单位";
                                dataGridView1.Focus();
                                return false;
                            }
                        }
                        else if (!noDosage.Contains(text) && row.Cells["Column8"].Value != System.DBNull.Value)
                        {
                            if (row.Cells["Column1"].Value == System.DBNull.Value)
                            {
                                dataGridView1.CurrentCell = row.Cells["Column1"];
                                // label1.ForeColor = Color.Red;
                                // label1.Text = "必须输入浓度单位";
                                dataGridView1.Focus();
                                return false;
                            }
                        }
                        else if (!noDosage.Contains(text) && row.Cells["Column9"].Value != System.DBNull.Value)
                        {
                            if (row.Cells["Column3"].Value == System.DBNull.Value)
                            {
                                dataGridView1.CurrentCell = row.Cells["Column3"];
                                // label1.ForeColor = Color.Red;
                                // label1.Text = "必须输入速度单位";
                                dataGridView1.Focus();
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool isEmptyDate(string dateString)
        {
            return (string.IsNullOrEmpty(dateString) || dateString.Trim().Equals(":"));
        }

        private void ResetStartTime()
        {
            if (_anesthesiaEventDataTable != null && _anesthesiaEventDataTable.Count > 0)
            {
                _anesthesiaEventDataTable.ForEach(row =>
                {
                    if (row.START_TIME.HasValue && _startTime > row.START_TIME) _startTime = row.START_TIME.Value;
                });
            }
        }
        public void RefreshEventData()
        {
            if (!CheckRefreshItems())
            {
                return;
            }
            _anesthesiaEventDataTable = operationInfoRepository.GetAnesEventList(_patientInfo.PATIENT_ID, _patientInfo.VISIT_ID, _patientInfo.OPER_ID, _eventNo).Data;
            _anesthesiaEventDefult = _anesthesiaEventDataTable.OrderBy(x => x.START_TIME).ToList();
            list = new BindingList<MED_ANESTHESIA_EVENT>(_anesthesiaEventDefult);
            dataGridView1.DataSource = list;
            if (cmbTypes.SelectedIndex >= 0)
            {
                SetType(cmbTypes.Properties.Items[cmbTypes.SelectedIndex].ToString());
            }
            btnSave.Enabled = false;
            btnRefresh.Enabled = false;
        }

        public bool CheckRefreshItems()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["EventName"].Value == null || row.Cells["EventName"].Value == System.DBNull.Value
                    || string.IsNullOrEmpty(row.Cells["EventName"].Value.ToString()))
                {
                    //label1.ForeColor = Color.Red;
                    //label1.Text = "必须输入名称";
                    dataGridView1.CurrentCell = row.Cells["EventName"];
                    dataGridView1.Focus();
                    return false;
                }
            }
            return true;
        }
        #endregion 方法


        #region 控件事件

        #region dataGridView1事件
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("START_TIME")
                            || dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("END_DATE"))
            {
                e.Cancel = true;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Equals(Column8) || dataGridView1.Columns[e.ColumnIndex].Equals(Column9)
                || dataGridView1.Columns[e.ColumnIndex].Equals(Column10))
            {
                if (validValue.Equals(""))
                {
                    validValue = "valid";
                    dataGridView1.CurrentCell.Value = null;
                    dataGridView1.CurrentCell.Value = System.DBNull.Value;
                    e.Cancel = false;
                }
                else
                {
                }
            }
            else
            {
                MessageBoxFormPC.Show(e.Exception.Message, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            if (dataGridView1.ReadOnly || e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            if (!CanEdit(e.RowIndex, e.ColumnIndex))
            {
                // 对于不可编辑的数据,只允许修改开始,和結束时间
                if (dataGridView1.Columns["StartTime"].Index == dataGridView1.CurrentCell.ColumnIndex || dataGridView1.Columns["EndDate"].Index == dataGridView1.CurrentCell.ColumnIndex)
                {
                    dataGridView1.CurrentCell.ReadOnly = false;
                }
                else
                    dataGridView1.CurrentCell.ReadOnly = true;

                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("DosageUnit"))
            {
                if (!dataGridView1.CurrentRow.Cells["EventName"].Value.ToString().Contains("麻醉平面"))
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    List<MED_UNIT_DICT> dict = ExtendApplicationContext.Current.CommDict.UnitDictExt.Where(p => p.UNIT_TYPE == 3).ToList();   // 单位类型;1 浓度单位；2 速度单位，3 剂量单位
                    Dialog.ShowCustomSelection(dict, "UNIT_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                        , new EventHandler(delegate (object s1, EventArgs e1)
                        {
                            if (s1 is int)
                            {
                                int index = (int)s1;
                                dataGridView1.CurrentCell.Value = dict[index].UNIT_NAME;
                                dataGridView1.EndEdit();
                                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                                dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
                            }
                        }));
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Column3"))
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                List<MED_UNIT_DICT> dict = ExtendApplicationContext.Current.CommDict.UnitDictExt.Where(p => p.UNIT_TYPE == 2).ToList();
                Dialog.ShowCustomSelection(dict, "UNIT_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate (object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dataGridView1.CurrentCell.Value = dict[index].UNIT_NAME;
                            dataGridView1.EndEdit();
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
                        }
                    }));
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("EventName"))
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                Dialog.ShowCustomSelection(currentEventDict, "EVENT_ITEM_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate (object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dataGridView1.CurrentCell.Value = currentEventDict[index].EVENT_ITEM_NAME;
                            dataGridView1.CurrentRow.Cells["EVENT_ITEM_CODE"].Value = currentEventDict[index].EVENT_ITEM_CODE;
                            dataGridView1.EndEdit();
                            //dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                            //dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];

                        }
                    }));


            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Column1"))
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                List<MED_UNIT_DICT> dict = ExtendApplicationContext.Current.CommDict.UnitDictExt.Where(p => p.UNIT_TYPE == 1).ToList();
                Dialog.ShowCustomSelection(dict, "UNIT_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate (object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dataGridView1.CurrentCell.Value = dict[index].UNIT_NAME;
                            dataGridView1.EndEdit();
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
                        }
                    }));
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Column7"))
            {
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                List<MED_ADMINISTRATION_DICT> dict = ExtendApplicationContext.Current.CommDict.AdministrationDictExt;

                Dialog.ShowCustomSelection(dict, "ADMINISTRATION_NAME", dataGridView1, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                    , new EventHandler(delegate (object s1, EventArgs e1)
                    {
                        if (s1 is int)
                        {
                            int index = (int)s1;
                            dataGridView1.CurrentCell.Value = dict[index].ADMINISTRATION_NAME;
                            if (dataGridView1.CurrentCell.Value.ToString().Contains("泵"))
                            {
                                dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 1;
                            }
                            dataGridView1.EndEdit();
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex];
                        }
                    }));
            }
            else
            {
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (_lock) return;
            if (e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 8)
            {
                validValue = e.FormattedValue.ToString();
                if (validValue.Equals(""))
                {
                    dataGridView1.CurrentCell.Value = System.DBNull.Value;
                    dataGridView1.CurrentCell.Value = null;
                    //如果是 呼吸，允许输入数值的同时 加上单位
                    if (e.RowIndex >= 0 && e.ColumnIndex == 8 && dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value != null
            && dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value != System.DBNull.Value)
                    {
                        string typeName = GetTypeName(dataGridView1.Rows[e.RowIndex].Cells["ItemType"].Value.ToString());
                        if (typeName.Equals("呼吸"))
                        {
                            if (dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value.ToString().Contains("呼吸"))
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["DosageUnit"].Value = "";
                            }
                        }


                    }
                }
                else
                {
                    ValidateNumber(sender, e);

                    //如果是 呼吸，允许输入数值的同时 加上单位
                    if (e.RowIndex >= 0 && e.ColumnIndex == 8 && dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value != null
            && dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value != System.DBNull.Value)
                    {
                        string typeName = GetTypeName(dataGridView1.Rows[e.RowIndex].Cells["ItemType"].Value.ToString());
                        if (typeName.Equals("呼吸"))
                        {
                            if (dataGridView1.Rows[e.RowIndex].Cells["EventName"].Value.ToString().Contains("呼吸"))
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["DosageUnit"].Value = "次/分";
                            }
                        }


                    }
                }
                return;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("EventName"))
            {
                if (e.FormattedValue != null && e.FormattedValue.ToString().Length > 60)
                {

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                    MessageQueue.AddMessage(dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误,字符长度不可大于60", Color.Red);
                    e.Cancel = true;
                    return;
                }
                else if (string.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                    MessageQueue.AddMessage(dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误,事件名称不能为空", Color.Red);
                    e.Cancel = true;
                    return;
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("START_TIME")
                || dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("END_TIME"))
            {

                if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Equals("START_TIME"))
                {
                    bool isNullOrEmpty = false;
                    if (e.FormattedValue == null)
                    {
                        isNullOrEmpty = true;
                    }
                    else
                    {
                        if (isEmptyDate(e.FormattedValue.ToString()))
                        {
                            isNullOrEmpty = true;
                        }
                        if (isNullOrEmpty)
                        {
                            MessageQueue.AddMessage(dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误，必须输入【发生时间】！ ", Color.Red);
                            e.Cancel = true;
                            return;
                        }

                    }

                }

                if (e.FormattedValue != null && !isEmptyDate(e.FormattedValue.ToString()))
                {
                    DateTime date = new DateTime();
                    if ((!DateTime.TryParse(e.FormattedValue.ToString(), out date)) && e.FormattedValue.ToString() != "")
                    {

                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                        e.FormattedValue.ToString().Remove(0, e.FormattedValue.ToString().Length);
                        MessageQueue.AddMessage(dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误,格式为 小时:分钟", Color.Red);
                        e.Cancel = true;
                        return;
                    }
                }
                if (!isEmptyDate(e.FormattedValue.ToString()))
                {
                    //判断结束时间
                    if (dataGridView1.Columns[e.ColumnIndex] == EndDate)
                    {
                        DateTime dt1 = DateTime.Parse(e.FormattedValue.ToString());
                        if ((dataGridView1.CurrentRow.Cells["StartTime"].Value is DateTime) && (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value > dt1)
                        {
                            DateTime dt2 = (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value;
                            MessageQueue.AddMessage(dataGridView1.Columns[e.ColumnIndex].HeaderText + " 输入错误，结束时间【" + dt1.ToString("yyyy-MM-dd HH:mm") + "】小于开始时间【" + dt2.ToString("yyyy-MM-dd HH:mm") + "】！", Color.Red);
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            DateTime dtStart = (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value;
                            if (dtStart.AddHours(24) < dt1)
                            {
                                if (MessageBoxFormPC.Show("结束时间【" + dt1.ToString("yyyy-MM-dd HH:mm") + "】超过开始时间【" + dtStart.ToString("yyyy-MM-dd HH:mm") + "】24小时以上，请确认？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                }
                                else
                                {
                                    e.Cancel = true;
                                }
                            }

                        }
                    }
                }
            }
            // label1.ForeColor = Color.Blue;
            // label1.Text = "要删除某时间点，必须选中整行!";
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_lock) return;
            if (dataGridView1.CurrentRow != null)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == EndDate || dataGridView1.Columns[e.ColumnIndex] == StartTime)
                {
                    if (dataGridView1.CurrentRow.Cells["EndDate"].Value != null && dataGridView1.CurrentRow.Cells["StartTime"].Value != null
                       && dataGridView1.CurrentRow.Cells["EndDate"].Value != dataGridView1.CurrentRow.Cells["StartTime"].Value)
                    {
                        dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 1;
                        dataGridView1.CurrentRow.Cells["Duration"].Value = (int)(DateTime.Parse(dataGridView1.CurrentRow.Cells["EndDate"].Value.ToString()) - (DateTime)dataGridView1.CurrentRow.Cells["StartTime"].Value).TotalMinutes;
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Duration" && dataGridView1.CurrentRow.Cells["Duration"].Value != null)
                {
                    if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["Duration"].Value.ToString())) dataGridView1.CurrentRow.Cells["Duration"].Value = 0;
                }
                btnSave.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private Color _colorReadOnlyBack = Color.FromArgb(0xf8, 0xf8, 0xf8);

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
            }
            else if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Equals(DURATIVE_INDICATOR))
            {
                e.Handled = true;
                Rectangle rect = e.CellBounds;
                e.PaintBackground(e.ClipBounds, true);
                if (!CanEdit(e.RowIndex, e.ColumnIndex))
                {
                    Rectangle rect1 = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
                    e.Graphics.FillRectangle(new SolidBrush(_colorReadOnlyBack), rect1);
                }
                if (e.Value != null && e.Value.ToString().Equals("1"))
                {
                    string text = "→";
                    Color foreColor = (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex == e.RowIndex
                            && dataGridView1.CurrentCell.ColumnIndex == e.ColumnIndex)
                            ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor;
                    if (!CanEdit(e.RowIndex, e.ColumnIndex))
                    {
                        foreColor = Color.FromArgb(0x66, 0x66, 0x66);
                    }
                    e.Graphics.DrawString(text, e.CellStyle.Font
                        , new SolidBrush(foreColor), rect.X + 1
                        , rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Value != null && e.Value != System.DBNull.Value)
            {
                e.Handled = true;
                Rectangle rect = e.CellBounds;
                e.PaintBackground(e.ClipBounds, true);
                if (!CanEdit(e.RowIndex, e.ColumnIndex))
                {
                    Rectangle rect1 = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
                    e.Graphics.FillRectangle(new SolidBrush(_colorReadOnlyBack), rect1);
                }
                string text = e.Value.ToString();
                if (e.ColumnIndex == 0)
                {
                    text = GetTypeName(e.Value.ToString());
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Equals(StartTime) || dataGridView1.Columns[e.ColumnIndex].Equals(EndDate))
                {
                    text = (Convert.ToDateTime(e.Value)).ToString("MM-dd HH:mm");// (e.Value).ToString("MM-dd HH:mm");
                    //text = ((DateTime)e.Value).ToString("MM-dd HH:mm");
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Equals(Column13))
                {
                    text = (Convert.ToDateTime(e.Value)).ToString("yyyy-MM-dd");
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Equals(Column10) || dataGridView1.Columns[e.ColumnIndex].Equals(Column8)
                    || dataGridView1.Columns[e.ColumnIndex].Equals(Column9))
                {
                    if (((decimal)e.Value) > 0)
                        text = ((decimal)e.Value).ToString("F3").Replace(".000", "");
                    else
                        text = "";
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Equals(EventName))
                {
                    text = e.Value.ToString();
                    //string attr = "";
                    //if (dataGridView1.Rows[e.RowIndex].Cells["EVENTATTR"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["EVENTATTR"].Value != System.DBNull.Value)
                    //{
                    //    attr = dataGridView1.Rows[e.RowIndex].Cells["EVENTATTR"].Value.ToString().Trim();
                    //}
                    //text += " " + attr;
                }
                if (!string.IsNullOrEmpty(text))
                {
                    object eventAttr = dataGridView1.Rows[e.RowIndex].Cells[EVENTATTR.Name].Value;
                    bool isYouDao = (eventAttr != null && eventAttr.ToString().Equals(EventNames.YOUDAONUMBER));
                    Color foreColor = (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex == e.RowIndex
                        && dataGridView1.CurrentCell.ColumnIndex == e.ColumnIndex)
                        ? e.CellStyle.SelectionForeColor : (isYouDao ? ApplicationConfiguration.YouDaoColor : e.CellStyle.ForeColor);
                    if (!CanEdit(e.RowIndex, e.ColumnIndex))
                    {
                        foreColor = Color.FromArgb(0x66, 0x66, 0x66);
                    }
                    if (dataGridView1.Columns[e.ColumnIndex].Equals(EndDate) && dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value is DateTime
                        && dataGridView1.Rows[e.RowIndex].Cells["EndDate"].Value is DateTime && (DateTime)dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value
                        < (DateTime)dataGridView1.Rows[e.RowIndex].Cells["EndDate"].Value && TransDateTime((DateTime)dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value)
                        > TransDateTime((DateTime)dataGridView1.Rows[e.RowIndex].Cells["EndDate"].Value))
                    {
                        foreColor = Color.Red;
                    }
                    e.Graphics.DrawString(text, e.CellStyle.Font
                        , new SolidBrush(foreColor), rect.X + 1
                        , rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                }
            }
            else if (!CanEdit(e.RowIndex, e.ColumnIndex))
            {
                e.Handled = true;
                Rectangle rect = e.CellBounds;
                e.PaintBackground(e.ClipBounds, true);
                if (!CanEdit(e.RowIndex, e.ColumnIndex))
                {
                    Rectangle rect1 = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
                    e.Graphics.FillRectangle(new SolidBrush(_colorReadOnlyBack), rect1);
                }
                if (e.Value != null && e.Value != System.DBNull.Value)
                {
                    string text = e.Value.ToString();
                    if (!string.IsNullOrEmpty(text))
                    {
                        Color foreColor = (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex == e.RowIndex
                            && dataGridView1.CurrentCell.ColumnIndex == e.ColumnIndex)
                            ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor;
                        if (!CanEdit(e.RowIndex, e.ColumnIndex))
                        {
                            foreColor = Color.FromArgb(0x66, 0x66, 0x66);
                        }
                        e.Graphics.DrawString(text, e.CellStyle.Font
                            , new SolidBrush(foreColor), rect.X + 1
                            , rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!CanEdit(e.RowIndex, e.ColumnIndex))
            {
                return;
            }
            if (dataGridView1.ReadOnly || e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                return;
            }
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name.Equals("EndDate") && (dataGridView1.CurrentCell.Value == null
                || string.IsNullOrEmpty(dataGridView1.CurrentCell.Value.ToString())))
            {
                try
                {
                    dataGridView1.CurrentCell.Value = accountRepository.GetServerTime().Data;
                    dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["StartTime"];
                    dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["EndDate"];
                }
                catch
                {
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Equals(Column13))
            {
                DateTime dt = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["Column13"].Value;
                dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                object result = Dialog.SingleInputSelect("请输入日期", "麻醉日期", dt, "yyyy-MM-dd");
                if (result != null)
                {
                    DateTime dt1 = (DateTime)result;
                    dt1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, dt.Hour, dt.Minute, 0);
                    if (!dt.Equals(dt1))
                    {
                        int n = (dt1 - dt).Days;
                        if (n >= 1 || n <= -1)
                        {
                            DialogResult res = MessageBoxFormPC.Show("您选的日期跨越了 " + Math.Abs(n) + " 天，请确认。", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (res == DialogResult.No)
                            {
                                return;
                            }
                        }

                        _lock = true;
                        dataGridView1.CurrentCell.Value = dt1;
                        ResetStartTime();
                        _lock = false;
                        btnSave.Enabled = true;
                        btnRefresh.Enabled = true;
                    }
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Equals(DURATIVE_INDICATOR))
            {
                if (CanEdit(e.RowIndex, e.ColumnIndex))
                {
                    if (dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value != null && dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value.ToString().Equals("1"))
                    {
                        dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 0;
                    }
                    else
                    {
                        dataGridView1.CurrentRow.Cells["DURATIVE_INDICATOR"].Value = 1;
                    }
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Equals(EventName))
            {
                _doubleClickCount++;
                if (_doubleClickCount > 2)
                {
                    _doubleClickCount = 0;
                    //  textBox1.Visible = true;
                    // textBox1.Focus();
                }
                return;
            }
            if (dataGridView1.Rows.Count == 0 || _startTime.Equals(DateTime.MaxValue)) return;
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Equals(Column13))
            {
                DateTime dt = new DateTime(_startTime.Year, _startTime.Month, _startTime.Day, _startTime.Hour, _startTime.Minute, 0);
                object result = Dialog.SingleInputSelect("请输入日期", "麻醉日期", dt, "yyyy-MM-dd");
                if (result != null)
                {
                    dt = (DateTime)result;
                    dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                    if (dt.Date != _startTime.Date)
                    {
                        _lock = true;
                        for (int i = 0; i < _anesthesiaEventDataTable.Count; i++)
                        {
                            MED_ANESTHESIA_EVENT row = _anesthesiaEventDataTable[i];
                            if (row.START_TIME.HasValue)
                            {
                                DateTime dt1 = row.START_TIME.Value;
                                if (dt1.Date.Equals(_startTime.Date))
                                {
                                    dt1 = new DateTime(dt.Year, dt.Month, dt.Day, dt1.Hour, dt1.Minute, 0);
                                }
                                else
                                {
                                    dt1 = new DateTime(dt.Year, dt.Month, dt.Day, dt1.Hour, dt1.Minute, 0).AddDays(1);
                                }
                                row.START_TIME = dt1;
                            }
                            if (row.END_TIME.HasValue)
                            {
                                DateTime dt1 = row.END_TIME.Value;
                                if (dt1.Date.Equals(_startTime.Date))
                                {
                                    dt1 = new DateTime(dt.Year, dt.Month, dt.Day, dt1.Hour, dt1.Minute, 0);
                                }
                                else
                                {
                                    dt1 = new DateTime(dt.Year, dt.Month, dt.Day, dt1.Hour, dt1.Minute, 0).AddDays(1);
                                }
                                row.END_TIME = dt1;
                            }
                        }
                        _startTime = dt;
                        _lock = false;
                        btnSave.Enabled = true;
                        btnRefresh.Enabled = true;
                    }
                }
            }
        }

        private int _doubleClickCount = 0;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private bool CanEdit(int rowIndex, int columnIndex)
        {
            bool result = true;
            if (rowIndex < 0 || columnIndex < 1)
            {
                if (columnIndex == 0 && rowIndex >= 0) result = true;
                else
                    result = false;
            }
            else
            {
                DataGridViewColumn column = dataGridView1.Columns[columnIndex];
                if (dataGridView1.Rows[rowIndex].Cells["ItemType"].Value != null)
                {
                    string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                    if (typeName.Equals("麻药") || typeName.Equals("药剂") || typeName.Equals("输出") || typeName.Equals("用药") || typeName.Equals("输血")
                        || typeName.Equals("输液") || typeName.Equals("出液") || typeName.Equals("镇痛") || typeName.Equals("抗生素") || typeName.Equals("特殊材料") || typeName.Equals("诱导") || typeName.Equals("输氧") || typeName.Equals("氧气"))
                    {
                    }
                    else
                    {
                        if (column.Equals(EventName) || column.Equals(StartTime) || column.Equals(EndDate) || column.Equals(Column13))
                        {
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            if (rowIndex >= 0 && columnIndex > 0 && dataGridView1.Columns[columnIndex].Equals(DosageUnit) && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != null
                && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != System.DBNull.Value)
            {
                string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                if (typeName.Equals("事件"))
                {
                    if (dataGridView1.Rows[rowIndex].Cells["EventName"].Value.ToString().Contains("麻醉平面"))
                    {
                        result = true;
                    }
                }

            }
            //如果是 呼吸，允许输入数值
            if (rowIndex >= 0 && columnIndex > 0 && dataGridView1.Columns[columnIndex].Equals(Column10) && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != null
    && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != System.DBNull.Value)
            {
                string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                if (typeName.Equals("呼吸"))
                {
                    if (dataGridView1.Rows[rowIndex].Cells["EventName"].Value.ToString().Contains("呼吸"))
                    {
                        result = true;
                    }
                }

            }
            //如果是 呼吸，DURATIVE_INDICATOR 列 允许输入数值
            if (rowIndex >= 0 && columnIndex > 0 && dataGridView1.Columns[columnIndex].Equals(DURATIVE_INDICATOR) && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != null
    && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != System.DBNull.Value)
            {
                string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                if (typeName.Equals("呼吸"))
                {
                    if (dataGridView1.Rows[rowIndex].Cells["EventName"].Value.ToString().Contains("呼吸"))
                    {
                        result = true;
                    }
                }

            }
            //如果是 瞳孔，允许输入数值
            if (rowIndex >= 0 && columnIndex > 0 && dataGridView1.Columns[columnIndex].Equals(Column10) && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != null
    && dataGridView1.Rows[rowIndex].Cells["EventName"].Value != System.DBNull.Value)
            {
                string typeName = GetTypeName(dataGridView1.Rows[rowIndex].Cells["ItemType"].Value.ToString());
                if (typeName.Equals("其他"))
                {
                    if (dataGridView1.Rows[rowIndex].Cells["EventName"].Value.ToString().Contains("瞳孔监测"))
                    {
                        result = true;
                    }
                }

            }
            return result;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            bool canEdit = CanEdit(e.RowIndex, e.ColumnIndex);
            if (!canEdit)
            {
                //   e.Cancel = true;
            }
            else
            {
                //dataGridView1.get
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (editControl != null)
            {
                editControl.KeyDown -= Integer_KeyDown;
                editControl.KeyPress -= Integer_KeyPress;
            }
        }

        /// <summary>
        /// 整数输入控制-键盘按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Integer_KeyDown(object sender, KeyEventArgs e)
        {
            isRejectInput = false;
            if ((e.Modifiers & Keys.Shift) == Keys.Shift)
            {
                isRejectInput = true;
                e.Handled = true;
                return;
            }
            ///数字0-9
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                ///数字键区域0-9
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    ///退格键或者减号键
                    if ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Subtract))
                    {
                        if (_inputType == MedInputType.Integer)
                        {
                            isRejectInput = true;
                        }
                        else if (e.KeyCode != Keys.Decimal || (e.KeyCode == Keys.Decimal && (sender as Control).Text.Contains(".")))
                        {
                            if (e.KeyCode != Keys.OemPeriod || (e.KeyCode == Keys.OemPeriod && (sender as Control).Text.Contains(".")))
                                isRejectInput = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 整数输入控制-键盘输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Integer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isRejectInput == true)
            {
                e.Handled = true; //设置该次键入未能通过验证
                isRejectInput = false;
            }

        }

        DataGridViewTextBoxEditingControl editControl;
        bool isRejectInput;
        MedInputType _inputType = MedInputType.General;

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            e.Control.TextChanged -= editor_TextChanged;
            e.Control.TextChanged += editor_TextChanged;
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                editControl = (DataGridViewTextBoxEditingControl)e.Control;

                if (grid.CurrentCell != null && grid.CurrentRow != null && (grid.Columns[grid.CurrentCell.ColumnIndex].Equals(Column8)
                    || grid.Columns[grid.CurrentCell.ColumnIndex].Equals(Column9) || grid.Columns[grid.CurrentCell.ColumnIndex].Equals(Column10)))
                {
                    _inputType = MedInputType.Nurmeric;
                    editControl.KeyDown += Integer_KeyDown;
                    editControl.KeyPress += Integer_KeyPress;
                }
            }
        }

        private void editor_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        #endregion  dataGridView1事件

        public void SetReadOnly(bool isReadOnly)
        {
            dataGridView1.ReadOnly = !isReadOnly;
            if (!isReadOnly)
            {
                dataGridView1.ContextMenuStrip = null;
            }
            else
            {
                dataGridView1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void AnesthesiaDrugEventEdit_Load(object sender, EventArgs e)
        {
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.刷新1, Resources.刷新2, Resources.刷新2).AddMouseMove(btnRefresh);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.事件体征保存1, Resources.事件体征保存2, Resources.事件体征保存2).AddMouseMove(btnSave);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.模版导入1, Resources.模版导入2, Resources.模版导入2).AddMouseMove(btnYouDao1);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.删除1, Resources.删除2, Resources.删除2).AddMouseMove(btnDelete);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.事件体征保存模版1, Resources.事件体征保存模版2, Resources.事件体征保存模版2).AddMouseMove(btnSaveModel);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.套用模版1, Resources.套用模版2, Resources.套用模版2).AddMouseMove(btnApplyModel);



            if (!DesignMode)
            {
                if (ParentForm != null && ParentForm.Name == "FloatFrm")
                {
                    btnApplyModel.Visible = false;
                    btnSaveModel.Visible = false;
                }
                _maxItemNo = new NewAnesthesiaEventRepository().GetMaxEventItemNo(_patientInfo);
                this.StartTime.Mask = "00:00";
                this.EndDate.Mask = "00:00";
                string buttonDockString = ConfigurationHelper.Read(Name + ".ButtonDock");
                BindEventTable();
                // lblYouDaoColor.ForeColor = ApplicationConfiguration.YouDaoColor;
                cmbTypes.Properties.Items.Clear();
                cmbTypes.Properties.Items.Add("全部");
                Dictionary<string, string>.Enumerator enumerator;
                if (_eventNo != "2")
                {
                    enumerator = AnesEventType._keyPairList.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (!cmbTypes.Properties.Items.Contains(enumerator.Current.Value))
                        {
                            cmbTypes.Properties.Items.Add(enumerator.Current.Value);
                        }
                    }
                }
                else
                {
                }
            }
        }
        public event EventHandler EventSaveClicked;
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                //OperationLogger.WriteOperate("事件登记", "保存", "点击登记界面保存按钮，自动保存", true, OperationLogKind.AnesEvent);
                //_anesthesiaEventDataTable.AcceptChanges();
            }
            string selector = cmbTypes.EditValue == null ? "" : cmbTypes.EditValue.ToString();
            SetType(selector);
            if (EventSaveClicked != null)
                EventSaveClicked(this, EventArgs.Empty);
        }

        private void toolStripMenuItemInsert_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemEmpty_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // BindEventTable();
            RefreshEventData();

            // OperationLogger.WriteOperate("事件登记", "刷新", "点击登记界面刷新按钮，刷新事件", false, OperationLogKind.Other);
        }

        private void toolStripMenuItemYouDao_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > -1 && _anesthesiaEventDataTable.Count > 0 && dataGridView1.CurrentRow != null
                && dataGridView1.CurrentRow.Index >= 0)
            {
                if (dataGridView1.CurrentRow.Cells["EVENTATTR"].Value == null || dataGridView1.CurrentRow.Cells["EVENTATTR"].Value == System.DBNull.Value
                    || string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["EVENTATTR"].Value.ToString()))
                {
                    dataGridView1.CurrentRow.Cells["EVENTATTR"].Value = EventNames.YOUDAONUMBER;
                }
                else
                {
                    dataGridView1.CurrentRow.Cells["EVENTATTR"].Value = System.DBNull.Value;
                }
                btnSave.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void lblYouDaoColor_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // lblYouDaoColor.ForeColor = dialog.Color;
                // ApplicationConfiguration.YouDaoColor = lblYouDaoColor.ForeColor;
                dataGridView1.Refresh();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBoxFormPC.Show("真的要删除当前所选记录吗？\r\n该操作不可恢复！", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                // Application.DoEvents();
                bool isDelete = false;
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                    for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        isDelete = new AnesEventRepository().DelAnesEvent(list[dataGridView1.SelectedRows[i].Index]).Data;

                        MED_ANESTHESIA_EVENT row = list[dataGridView1.SelectedRows[i].Index];
                        list.RemoveAt(dataGridView1.SelectedRows[i].Index);
                        _anesthesiaEventDataTable.Remove(row);
                    }
                }
                btnSave.Enabled = true;
                btnRefresh.Enabled = true;
                //  BindEventTable();
                // Save(); 
                if (EventSaveClicked != null)
                    EventSaveClicked(this, EventArgs.Empty);
                // OperationLogger.WriteOperate("事件登记", "删除", "点击登记界面删除按钮，自动保存", true, OperationLogKind.AnesEvent);
            }
        }

        private void btnYouDao1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                {
                    if (dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value == null || dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value == System.DBNull.Value
                        || string.IsNullOrEmpty(dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value.ToString()))
                    {
                        dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value = EventNames.YOUDAONUMBER;
                    }
                    else
                    {
                        dataGridView1.SelectedRows[i].Cells["EVENTATTR"].Value = System.DBNull.Value;
                    }
                }
                btnSave.Enabled = true;
                btnRefresh.Enabled = true;
            }
            else
            {
                Dialog.MessageBox("请通过行头选择要操作的行！", 6);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckItems())
                {
                    // OperationLogger.WriteOperate("事件登记", "关闭", "点击大事件登记界面确定按钮，执行自动保存前数据校验未通过", false, OperationLogKind.Other);
                    return;
                }
                // OperationLogger.WriteOperate("事件登记", "关闭", "点击大事件登记界面确定按钮，关闭界面", false, OperationLogKind.Other);
                if (btnSave.Enabled)
                {
                    Save();
                    // OperationLogger.WriteOperate("事件登记", "保存", "点击大事件登记界面确定按钮，执行自动保存", true, OperationLogKind.AnesEvent);
                }
                Parent.Controls.Remove(this);
                if (_dataChanged)
                {
                    RaiseDataChanged();
                }
            }
            catch
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        private void ToolStripMenuItemChangeSpeed_Click(object sender, EventArgs e)
        {
            CopySpeedRow();
        }

        private void ToolStripMenuItemThick_Click(object sender, EventArgs e)
        {
            CopyConcentrationRow();
        }

        public void SetType(string typeName)
        {
            if (_anesthesiaEventDataTable != null)
            {
                string newTypeName = "全部";
                if (cmbTypes.SelectedIndex >= 0 && cmbTypes.Properties.Items[cmbTypes.SelectedIndex].ToString().Equals(typeName))
                {
                    newTypeName = typeName;
                }
                else
                {
                    for (int i = 0; i < cmbTypes.Properties.Items.Count; i++)
                    {
                        if (cmbTypes.Properties.Items[i].ToString().Equals(typeName))
                        {
                            cmbTypes.SelectedIndex = i;
                            newTypeName = typeName;
                            break;
                        }
                    }
                }
                if (newTypeName.Equals("全部"))
                {
                    _anesthesiaEventDefult = _anesthesiaEventDataTable;
                    Column7.Visible = true;
                    Column8.Visible = true;
                    Column1.Visible = true;
                    Column9.Visible = true;
                    Column3.Visible = true;
                    Column10.Visible = true;
                    DosageUnit.Visible = true;
                    DURATIVE_INDICATOR.Visible = true;
                    EndDate.Visible = true;
                }
                else
                {
                    if (newTypeName.Equals("呼吸"))
                    {
                        _anesthesiaEventDefult = _anesthesiaEventDataTable.Where(x => x.EVENT_CLASS_CODE == "9" || x.EVENT_CLASS_CODE == "A" || x.EVENT_CLASS_CODE == "Y").ToList();
                    }
                    else
                    {
                        _anesthesiaEventDefult = _anesthesiaEventDataTable.Where(x => x.EVENT_CLASS_CODE == AnesEventType.SwitchKeyValue[newTypeName]).ToList();

                    }
                    switch (newTypeName)
                    {
                        case "输氧":
                        case "氧气":
                        case "输血":
                        case "输液":
                        case "出量":
                        case "诱导":
                        case "镇痛":
                        case "抗生素":
                        case "特殊材料":
                        case "麻药":
                        case "用药":
                        case "药剂":
                        case "输出":
                            Column7.Visible = true;
                            Column8.Visible = true;
                            Column1.Visible = true;
                            Column9.Visible = true;
                            Column3.Visible = true;
                            Column10.Visible = true;
                            DosageUnit.Visible = true;
                            DURATIVE_INDICATOR.Visible = true;
                            EndDate.Visible = true;
                            break;
                        case "呼吸":
                            Column7.Visible = false;
                            Column8.Visible = false;
                            Column1.Visible = false;
                            Column9.Visible = false;
                            Column3.Visible = false;
                            DURATIVE_INDICATOR.Visible = false;
                            break;
                        default:
                            Column7.Visible = false;
                            Column8.Visible = false;
                            Column1.Visible = false;
                            Column9.Visible = false;
                            Column3.Visible = false;
                            Column10.Visible = false;
                            DURATIVE_INDICATOR.Visible = false;
                            break;
                    }
                }
            }
        }

        private void cmbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypes.SelectedIndex >= 0 && _anesthesiaEventDataTable != null)
            {
                SetType(cmbTypes.Properties.Items[cmbTypes.SelectedIndex].ToString());
                list = new BindingList<MED_ANESTHESIA_EVENT>(_anesthesiaEventDefult);
                dataGridView1.DataSource = list; ;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void SetTimes()
        {
            string text = "";
            if (dataGridView1.CurrentRow.Cells["EVENTATTR"].Value != null && dataGridView1.CurrentRow.Cells["EVENTATTR"].Value != System.DBNull.Value)
            {
                text = dataGridView1.CurrentRow.Cells["EVENTATTR"].Value.ToString().Trim();
            }
            text = text.Replace("分次", "");
            SetTimes(text);
        }

        private void SetTimes(string text)
        {
            if (ToolStripMenuItem分次.Checked)
            {
                dataGridView1.CurrentRow.Cells["EVENTATTR"].Value = text.Replace("×1", "") + "分次";
            }
            else
            {
                dataGridView1.CurrentRow.Cells["EVENTATTR"].Value = text.Replace("×1", "");
            }
            dataGridView1.Invalidate();
        }
        List<MED_ANESTHESIA_EVENT_TEMPLET> _anesthesiaEventTemplet;
        private void btnApplyModel_Click(object sender, EventArgs e)
        {
            EventTemplet view = new EventTemplet(_eventNo);
            DialogHostFormPC dialogHostForm = new DialogHostFormPC("套用模板", view.Width, view.Height);
            dialogHostForm.Child = view;
            dialogHostForm.ShowDialog();
            object result = view.DialogResultData;
            if (result != null)
            {
                TimeInPutFrmPC timeInput = new TimeInPutFrmPC();
                timeInput.Text = "套用时间";
                timeInput.SelectedDateTime = DateTime.Now;
                if (timeInput.ShowDialog() != DialogResult.Cancel)
                {
                    DateTime applyTime = timeInput.SelectedDateTime;

                    EventTempletDetail templet = (EventTempletDetail)result;
                    _anesthesiaEventTemplet = commonRepository.GetAnesEventTemplet(templet.Name).Data;

                    foreach (MED_ANESTHESIA_EVENT_TEMPLET row in _anesthesiaEventTemplet)
                    {
                        if (!templet.IsApplyDosage)
                        {
                            row.DOSAGE = null;
                        }
                        double d = string.IsNullOrEmpty(row.START_AFTER_INPUT.ToString()) ? 0 : double.Parse(row.START_AFTER_INPUT.ToString());

                        decimal dDurative = !row.DURATIVE.HasValue ? 0 : row.DURATIVE.Value;
                        //AddRow(row, templet.StartTime.AddMinutes(d), dDurative);
                        AddRow(row, applyTime.AddMinutes(d), dDurative);
                    }
                }
            }
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (!CheckItems())
            {
                return;
            }
            if (_anesthesiaEventDataTable != null && _anesthesiaEventDataTable.Count > 0)
            {
                if (_eventNo == "1" && _anesthesiaEventDataTable != null && _anesthesiaEventDataTable.Count > 0)
                {
                    _anesthesiaEventDataTable.ForEach(row =>
                    {
                        if (row.ITEM_NO < 500) row.ITEM_NO += 500;
                    });
                }
                SetNewEventTemplet view = new SetNewEventTemplet();
                DialogHostFormPC dialogHostForm = new DialogHostFormPC("保存模板", view.Width, view.Height);
                dialogHostForm.Child = view;
                //dialogHostForm.StartPosition = FormStartPosition.Manual; 
                dialogHostForm.ShowDialog();
                object result = view.DialogResultData;
                if (result != null)
                {
                    EventTempletDetail templet = (EventTempletDetail)result;
                    _anesthesiaEventTemplet = commonRepository.GetAnesEventTemplet(templet.Name).Data;
                    DateTime topEventTime = DateTime.MinValue;
                    if (_anesthesiaEventDataTable.Count > 0)
                    {
                        //计算最小开始时间
                        topEventTime = _anesthesiaEventDataTable[0].START_TIME.Value;
                        foreach (MED_ANESTHESIA_EVENT eventRow1 in _anesthesiaEventDataTable)
                        {
                            if (!string.IsNullOrEmpty(eventRow1.START_TIME.ToString()) && (topEventTime >= eventRow1.START_TIME)) topEventTime = eventRow1.START_TIME.Value;
                        }
                    }
                    foreach (MED_ANESTHESIA_EVENT eventRow in _anesthesiaEventDataTable)
                    {
                        MED_ANESTHESIA_EVENT_TEMPLET row = new MED_ANESTHESIA_EVENT_TEMPLET();
                        row.TEMPLET_CLASS = "1"; //模板类别	;	1/PACU、2/手术室、0/通用，默认0 
                        row.ANESTHESIA_METHOD = string.IsNullOrEmpty(templet.AnesMethod.Trim()) ? "通用" : templet.AnesMethod.Trim();
                        row.TEMPLET_NAME = templet.Name;
                        row.EVENT_ITEM_CLASS = eventRow.EVENT_CLASS_CODE;
                        row.EVENT_ITEM_NO = eventRow.ITEM_NO;
                        row.EVENT_ITEM_NAME = eventRow.EVENT_ITEM_NAME;
                        row.EVENT_ITEM_CODE = eventRow.EVENT_ITEM_CODE;
                        row.EVENT_ITEM_SPEC = eventRow.EVENT_ITEM_SPEC;
                        row.CONCENTRATION = eventRow.CONCENTRATION;
                        row.PERFORM_SPEED = eventRow.PERFORM_SPEED;
                        row.SPEED_UNIT = eventRow.SPEED_UNIT;
                        row.DOSAGE = eventRow.DOSAGE;
                        row.DOSAGE_UNITS = eventRow.DOSAGE_UNITS;
                        row.ADMINISTRATOR = eventRow.ADMINISTRATOR;
                        row.DURATIVE_INDICATOR = eventRow.DURATIVE_INDICATOR;
                        row.METHOD = eventRow.METHOD;
                        row.EVENT_ATTR = eventRow.EVENT_ATTR;
                        row.CONCENTRATION_UNIT = eventRow.CONCENTRATION_UNIT;
                        row.BILL_ATTR = eventRow.BILL_INDICATOR;
                        row.START_AFTER_INPUT = 0;
                        if (topEventTime != DateTime.MinValue)
                        {
                            row.START_AFTER_INPUT = (decimal)((int)(eventRow.START_TIME.Value - topEventTime).TotalMinutes);
                        }
                        row.CREATE_BY = templet.Owner;

                        row.ModelStatus = ModelStatus.Add;

                        _anesthesiaEventTemplet.Add(row);
                    }

                    if (commonRepository.SaveAnesEventTempletList(_anesthesiaEventTemplet).Data)
                    {
                        MessageQueue.AddMessage("模板保存成功！", Color.Black);
                    }
                }
            }
            else
            {
                MessageBoxFormPC.Show("麻醉事件为空无法保存模板！");
            }
        }
        #endregion 控件事件

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            if (_anesthesiaEventDataTable != null && _anesthesiaEventDataTable.Count > 0)
            {
                _anesthesiaEventDataTable.ForEach(row =>
                {
                    if (!string.IsNullOrEmpty(row.EVENT_ITEM_NAME) && !list.Contains(row.EVENT_ITEM_NAME))
                    {
                        list.Add(row.EVENT_ITEM_NAME);
                    }
                });
            }
        }

        private void panelControl_Paint(object sender, PaintEventArgs e)
        {
            Color border = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            ControlPaint.DrawBorder(e.Graphics, panelControl.ClientRectangle,
            border, 1, ButtonBorderStyle.Solid, //左边
            border, 1, ButtonBorderStyle.Solid, //上边
            border, 1, ButtonBorderStyle.Solid, //右边
            border, 1, ButtonBorderStyle.Solid);//底边
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {
            Color border = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            ControlPaint.DrawBorder(e.Graphics, pnlBody.ClientRectangle,
            border, 1, ButtonBorderStyle.Solid, //左边
            border, 1, ButtonBorderStyle.Solid, //上边
            border, 1, ButtonBorderStyle.Solid, //右边
            border, 1, ButtonBorderStyle.Solid);//底边
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.IsCurrentCellDirty) //有未提交的更//改
            {
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
