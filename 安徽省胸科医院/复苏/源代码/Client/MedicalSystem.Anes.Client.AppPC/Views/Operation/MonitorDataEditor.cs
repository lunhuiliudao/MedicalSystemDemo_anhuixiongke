using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class MonitorDataEditor : BaseView
    {
        private List<string> _items;
        private List<object> _values;
        private string _patientID;
        private int _visitID, _operID;
        private string _eventNo;
        private object _result;

        public object Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public MonitorDataEditor(string patientID, int visitID, int operID, List<string> items, DateTime startTime, List<object> values, string eventNo)
            : this(patientID, visitID, operID, items, eventNo)
        {
            _values = values;
            dateEdit1.DateTime = startTime.AddSeconds(double.Parse(txtInterval.Text));
            dateEdit1.DateTime = GetFiveMinuteTime(dateEdit1.DateTime);
            dateEdit2.DateTime = dateEdit1.DateTime.AddMinutes(5);
        }

        public MonitorDataEditor(string patientID, int visitID, int operID, List<string> items, string eventNo)
        {
            Caption = "插入体征数据";
            _eventNo = eventNo;
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _items = items;
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Now;
            dateEdit1.DateTime = GetFiveMinuteTime(dateEdit1.DateTime);
            dateEdit2.DateTime = dateEdit1.DateTime.AddMinutes(5);
        }

        private DateTime GetFiveMinuteTime(DateTime source)
        {
            DateTime dateTime = source;
            int minute = dateTime.Minute;
            while (minute % 5 != 0)
            {
                dateTime = dateTime.AddMinutes(1);
                minute = dateTime.Minute;
            }
            return dateTime;
        }

        private void MonitorDataEditor_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (_items != null && _items.Count > 0)
                {
                    int top = txtInterval.Bottom + 10;
                    int left1 = label1.Left;
                    int left2 = txtInterval.Left;
                    //int height = btnOK.Top - top - 10;
                    int columnIndex = 0, columnCount = ((_items.Count > 5) ? 2 : 1);
                    int width = -30 + (int)(Width - left1 * 2) / columnCount;
                    List<MED_MONITOR_FUNCTION_CODE> monitorFunctionCodeDataTable = ExtendApplicationContext.Current.CommDict.MonitorFuntionDict;

                    for (int i = 0; i < _items.Count; i++)
                    {
                        string item = _items[i];
                        Label label = new Label();
                        label.Text = ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(item) ? ExtendApplicationContext.Current.MonitorFunctionCodeDict[item] : item;
                        label.Location = new Point(left1 + (30 + width) * columnIndex, top);
                        MedTextBox textBox = new MedTextBox();
                        if (_values != null && _values.Count > i)
                        {
                            textBox.Text = _values[i].ToString();
                        }
                        textBox.Location = new Point(left2 + (30 + width) * columnIndex, top);
                        textBox.Width = width - left2 - left1;
                        textBox.Tag = item;
                        textBox.EnterMoveNextControl = true;
                        textBox.TextChanged += new EventHandler(textBox_TextChanged);
                        label.Top += 2;
                        Controls.Add(label);
                        Controls.Add(textBox);
                        label.BringToFront();
                        bool isNumeric = true;
                        if (monitorFunctionCodeDataTable != null && monitorFunctionCodeDataTable.Count > 0)
                        {
                            foreach (MED_MONITOR_FUNCTION_CODE row in monitorFunctionCodeDataTable)
                            {
                                if (row.ITEM_CODE.Equals(item))
                                {
                                    if (!string.IsNullOrEmpty(row.ITEM_UNIT))
                                    {
                                        Label labelUnit = new Label();
                                        labelUnit.Text = row.ITEM_UNIT;
                                        labelUnit.Top = label.Top;
                                        labelUnit.Left = textBox.Right + 5;
                                        Controls.Add(labelUnit);
                                    }
                                    if (row.VALUE_TYPE.HasValue && row.VALUE_TYPE == 1)
                                    {
                                        isNumeric = false;
                                    }
                                    break;
                                }
                            }
                        }
                        if (isNumeric)
                        {
                            textBox.InputType = MedInputType.Nurmeric;
                        }
                        textBox.BringToFront();
                        if (columnIndex < columnCount - 1)
                        {
                            columnIndex++;
                        }
                        else
                        {
                            top += textBox.Height + 10;
                            columnIndex = 0;
                        }
                    }
                    btnOK.Top = top;
                    btnCancel.Top = top;
                    lblMessage.Top = top;
                    Height = btnOK.Bottom + 10;
                    if (ParentForm != null)
                    {
                        ParentForm.Height = btnOK.Bottom + 50;
                    }
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            bool enable = false;
            foreach (Control control in (sender as Control).Parent.Controls)
            {
                if (control is MedTextBox && !control.Equals(txtInterval))
                {
                    if (!string.IsNullOrEmpty(control.Text))
                    {
                        enable = true;
                        break;
                    }
                }
            }
            btnOK.Enabled = enable;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateEdit1.DateTime > dateEdit2.DateTime)
                {
                    MessageBoxFormPC.Show("开始时间不能大于结束时间", MessageBoxIcon.Information);
                    return;
                }
                if (((TimeSpan)(dateEdit2.DateTime - dateEdit1.DateTime)).TotalHours > 8)
                {
                    MessageBoxFormPC.Show("每次添加体征数据的时间区域请保持在8小时以内！", MessageBoxIcon.Information);
                    return;
                }
                NewMonitorData newMonitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo, ExtendApplicationContext.Current.LoginUser.USER_JOB_ID);
                DateTime dt = DateTimeEqual(dateEdit1.DateTime);
                dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                while (dt <= dateEdit2.DateTime)
                {
                    List<MED_VITAL_SIGN> vitalSignDataTable = new OperationVitalSignRepository().GetVitalSignData(_patientID, _visitID, _operID, _eventNo, false);
                    //int index = _items.Count - 1;
                    foreach (Control control in Controls)
                    {
                        if (control is MedTextBox && !control.Equals(txtInterval))
                        {
                            string text = (control as MedTextBox).Text;
                            string oldvalue = "0";
                            string itemName = "";
                            if (vitalSignDataTable != null && vitalSignDataTable.Count > 0)
                            {
                                foreach (MED_VITAL_SIGN row in vitalSignDataTable)
                                {
                                    if (dt == row.TIME_POINT && (control as MedTextBox).Tag.ToString() == row.ITEM_CODE)
                                    {
                                        oldvalue = row.ITEM_VALUE.ToString();
                                    }
                                }
                            }
                            itemName = ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey((control as MedTextBox).Tag.ToString()) ? ExtendApplicationContext.Current.MonitorFunctionCodeDict[(control as MedTextBox).Tag.ToString()] : (control as MedTextBox).Tag.ToString();
                            if (!string.IsNullOrEmpty(text))
                            {
                                newMonitorData.SetItem(dt, itemName, text, oldvalue, (control as MedTextBox).Tag.ToString());
                            }
                        }
                    }
                    dt = dt.AddSeconds(double.Parse(txtInterval.Text));
                }
                newMonitorData.Save();
                _result = DialogResult.OK;
                ParentForm.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Dialog.MessageBox(ex.Message, MessageBoxIcon.Information);
                _result = DialogResult.None;
            }
        }
        /// <summary>
        /// 时间转换整五分钟
        /// </summary>
        /// <param name="selectDateTime"></param>
        /// <returns></returns>
        public DateTime DateTimeEqual(DateTime selectDateTime)
        {
            int minute = selectDateTime.Minute % 5;
            if (minute != 0)
            {
                minute = 5 - minute;
                selectDateTime = selectDateTime.AddMinutes(minute);
            }
            return selectDateTime;
        }

        private void btnCancel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
            _result = DialogResult.Cancel;
        }
    }
}
