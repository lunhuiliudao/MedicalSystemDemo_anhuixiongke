using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PatMonitorEditor : BaseView
    {
        CommonRepository commonRepository = new CommonRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();


        private List<MED_MONITOR_FUNCTION_CODE> _monitorFunctionCode = null;
        private DataTable _vitalSignTable;
        private string _patientID;
        private int _visitID, _operID;
        private string _eventNo;
        private NewMonitorData _newMonitorData;
        private bool _dataChanged = false;
        private double cellOldValue = 0;
        private List<MED_VITAL_SIGN> vitalSignDataTable = null;
        public int controlWidth = 0;
        public int controlHeight = 0;
        public override bool IsDirty
        {
            get
            {
                return _dataChanged;
            }
        }

        public bool IsDataSaved
        {
            get
            {
                return _dataChanged;
            }
        }
        public override bool Save()
        {
            bool saved = false;
            if (_newMonitorData != null)
            {
                saved = _newMonitorData.Save();
                if (saved)
                {
                    _dataChanged = false;
                    btnSave.Enabled = false;
                    btnRefresh.Enabled = false;
                    label1.ForeColor = Color.Blue;
                    label1.Text = "保存成功";
                    MessageQueue.AddMessage("体征数据保存成功!", Color.Black);
                }
            }
            return saved;
        }
        /// <summary>
        /// 锁死修改功能
        /// </summary>
        public void SetReadOnly(bool isReadOnly)
        {
            dgMonitorEditorView.ReadOnly = !isReadOnly;
        }
        public PatMonitorEditor(string patientID, int visitID, int operID, string eventNo)
        {
            InitializeComponent();
            Load += new EventHandler(PatMonitorEditor_Load);
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _eventNo = eventNo;
        }
        private void PatMonitorEditor_Load(object sender, EventArgs e)
        {

            new ControlAddEvent(Resources.刷新1, Resources.刷新2, Resources.刷新2).AddMouseMove(btnRefresh);
            new ControlAddEvent(Resources.事件体征保存1, Resources.事件体征保存2, Resources.事件体征保存2).AddMouseMove(btnSave);
            new ControlAddEvent(Resources.插入数据1, Resources.插入数据2, Resources.插入数据2).AddMouseMove(btnInsertColumns);
            new ControlAddEvent(Resources.删除1, Resources.删除2, Resources.删除2).AddMouseMove(btnDelete);
            new ControlAddEvent(Resources.删除项目1, Resources.删除项目2, Resources.删除项目2).AddMouseMove(btnDeleteItem);
            new ControlAddEvent(Resources.增加项目1, Resources.增加项目2, Resources.增加项目2).AddMouseMove(btnAddItem);


            if (_monitorFunctionCode == null)
            {
                _monitorFunctionCode = comnDictRepository.GetMonitorFuctionCodeList().Data;
            }
            //MED_OPERATION_MASTER operMaster = ExtendApplicationContext.Current.MED_OPERATION_MASTER;
            GetVitalSignDataTable();
            dgMonitorEditorView.Focus();
            this.SetDefaultGridViewStyle(dgMonitorEditorView);//, dgMonitorEditorView.RowTemplate.Height, dgMonitorEditorView.ColumnHeadersHeight
            for (int i = 0; i < dgMonitorEditorView.ColumnCount; i++)
            {
                dgMonitorEditorView.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
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
        public void GetVitalSignDataTable()
        {
            vitalSignDataTable = new OperationVitalSignRepository().GetVitalSignData(_patientID, _visitID, _operID, _eventNo, false);
            //List<string> itemNames = new List<string>();
            controlWidth = this.Width;
            controlHeight = 0;
            if (vitalSignDataTable != null && vitalSignDataTable.Count > 0)
            {
                _vitalSignTable = new DataTable();
                _vitalSignTable.Columns.Add("实际时间");
                _vitalSignTable.Columns.Add("时间");
                DateTime vStartTime = vitalSignDataTable[0].TIME_POINT;
                DateTime vEndTime = vitalSignDataTable[vitalSignDataTable.Count - 1].TIME_POINT;
                DataRow dtRow;
                Dictionary<string, int> rowDict = new Dictionary<string, int>();
                if (vStartTime.Minute % 5 != 0)
                {
                    string columnName = vStartTime.ToString("HH:mm");
                    if (!rowDict.ContainsKey(columnName))
                        rowDict.Add(columnName, _vitalSignTable.Rows.Count);
                    dtRow = _vitalSignTable.NewRow();
                    dtRow[0] = vStartTime.ToString("yyyy-MM-dd HH:mm");
                    dtRow[1] = columnName;
                    _vitalSignTable.Rows.Add(dtRow);
                    vStartTime = DateTimeEqual(vStartTime);
                }
                while (vStartTime <= vEndTime)
                {
                    string columnName = vStartTime.ToString("HH:mm");
                    if (!rowDict.ContainsKey(columnName))
                        rowDict.Add(columnName, _vitalSignTable.Rows.Count);
                    dtRow = _vitalSignTable.NewRow();
                    dtRow[0] = vStartTime.ToString("yyyy-MM-dd HH:mm");
                    dtRow[1] = columnName;
                    _vitalSignTable.Rows.Add(dtRow);
                    vStartTime = vStartTime.AddMinutes(5);
                }
                string[] list = ExtendApplicationContext.Current.DefaultMonitorItems.Split(',');
                string[] items = new OperationVitalSignRepository().GetVitalSignTitles(_patientID, _visitID, _operID, _eventNo);

                //新增默认体征项目
                if (items != null)
                {
                    List<string> itemList = new List<string>();
                    foreach (string item in list)
                    {
                        if (!itemList.Contains(item.Trim())) itemList.Add(item);
                    }

                    if (items.Length > 0)
                    {
                        foreach (string item in items)
                        {
                            if (!itemList.Contains(item.Trim())) itemList.Add(item);
                        }
                    }
                    list = itemList.ToArray();
                }
                //End Add

                foreach (string s in list)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        string columnName = ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(s) ? ExtendApplicationContext.Current.MonitorFunctionCodeDict[s] : s;
                        DataColumn column = new DataColumn(columnName, typeof(string));
                        column.Caption = s;
                        //if (_vitalSignTable.Columns..Contains(column))
                        //{

                        //}
                        //else
                        _vitalSignTable.Columns.Add(column);
                    }
                }

                vitalSignDataTable.ForEach(row =>
                {
                    string columnName = row.TIME_POINT.ToString("HH:mm");
                    for (int i = 2; i < _vitalSignTable.Columns.Count; i++)
                    {
                        DataColumn column = _vitalSignTable.Columns[i];
                        if (row.ITEM_CODE == column.Caption)
                        {
                            if (rowDict.ContainsKey(columnName))
                            {
                                _vitalSignTable.Rows[rowDict[columnName]][i] = row.ITEM_VALUE;
                                break;
                            }

                        }
                    }

                });
                dgMonitorEditorView.DataSource = _vitalSignTable;
                for (int i = 2; i < dgMonitorEditorView.ColumnCount; i++)
                {
                    DataGridViewColumn column = dgMonitorEditorView.Columns[i];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    column.ToolTipText = _vitalSignTable.Columns[i].Caption;
                }
                dgMonitorEditorView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgMonitorEditorView.Columns[0].ReadOnly = true;
                dgMonitorEditorView.Columns[0].Frozen = true;
                dgMonitorEditorView.Columns[0].Visible = false;
                dgMonitorEditorView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgMonitorEditorView.Columns[1].ReadOnly = true;
                dgMonitorEditorView.Columns[1].Frozen = true;
            }
            else
            {
                _vitalSignTable = new DataTable();
                _vitalSignTable.Columns.Add("实际时间");
                _vitalSignTable.Columns.Add("时间");
                string[] items = ExtendApplicationContext.Current.DefaultMonitorItems.Split(',');
                // string[] items = new OperationVitalSignService().GetVitalSignTitles(_patientID, _visitID, _operID, _eventNo);

                if (_eventNo == "1" && ExtendApplicationContext.Current.CustomSettingContext.IsAddPacuSpecialItems)//复苏项
                {
                    if (items != null)
                    {
                        string[] itemsCopy = new string[items.Length + 2];
                        itemsCopy[0] = "50008";
                        itemsCopy[1] = "50009";
                        for (int i = 0; i < items.Length; i++)
                        {
                            itemsCopy[i + 2] = items[i];
                        }

                        items = itemsCopy;
                    }
                }
                if (items != null && items.Length > 0)
                {
                    for (int i = 0; i < items.Length; i++)
                    {
                        string columnName = ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(items[i]) ? ExtendApplicationContext.Current.MonitorFunctionCodeDict[items[i]] : items[i];
                        DataColumn column = new DataColumn(columnName, typeof(string));
                        column.Caption = items[i];
                        _vitalSignTable.Columns.Add(column);
                    }
                    dgMonitorEditorView.DataSource = _vitalSignTable;
                    dgMonitorEditorView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgMonitorEditorView.Columns[0].ReadOnly = true;
                    dgMonitorEditorView.Columns[0].Visible = false;
                    dgMonitorEditorView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgMonitorEditorView.Columns[1].ReadOnly = true;
                }
            }
            _newMonitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo, ExtendApplicationContext.Current.LoginUser.USER_JOB_ID);
            if (dgMonitorEditorView.Height < 50) dgMonitorEditorView.Height = 200;
        }
        private void dgMonitorEditorView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string value;
            if (dgMonitorEditorView.CurrentCell.Value == System.DBNull.Value || string.IsNullOrEmpty(dgMonitorEditorView.CurrentCell.Value.ToString()))
            {
                value = "";
            }
            else
            {
                value = dgMonitorEditorView.CurrentCell.Value.ToString();
            }
            _newMonitorData.SetItem(DateTime.Parse(((DataTable)dgMonitorEditorView.DataSource).Rows[dgMonitorEditorView.CurrentCell.RowIndex][0].ToString())
                , dgMonitorEditorView.Columns[dgMonitorEditorView.CurrentCell.ColumnIndex].Name.ToString(), value, cellOldValue.ToString(), ((DataTable)dgMonitorEditorView.DataSource).Columns[dgMonitorEditorView.CurrentCell.ColumnIndex].Caption);
            _dataChanged = true;
            btnSave.Enabled = true;
            btnRefresh.Enabled = true;
        }

        private void ValidateNumber(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger = 0;
            float newdecimal = 0;
            if (((!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0) &&
                (!float.TryParse(e.FormattedValue.ToString(), out newdecimal) || newdecimal < 0))
                && e.FormattedValue.ToString() != "")
            {
                DataGridView grid = (sender as DataGridView);
                if (grid.CurrentRow.Cells[0].Value.Equals("50008") || grid.CurrentRow.Cells[0].Value.Equals("50009"))
                {
                }
                else
                {
                    e.Cancel = true;
                    label1.ForeColor = Color.Red;
                    label1.Text = "“" + grid.CurrentRow.Cells[0].Value.ToString() + "”字段必须为非负数字类型";
                }

            }
            else
            {
                label1.ForeColor = Color.Blue;
                label1.Text = "要删除某时间点，必须选中整列!";
            }
        }

        private void dgMonitorEditorView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex > 1)
            {
                ValidateNumber(sender, e);
            }
            else
            {
            }
        }

        private void dgMonitorEditorView_SelectionChanged(object sender, EventArgs e)
        {
            if (dgMonitorEditorView.SelectedRows != null && dgMonitorEditorView.SelectedRows.Count > 0)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
            if (dgMonitorEditorView.SelectedColumns != null && dgMonitorEditorView.SelectedColumns.Count > 0 && !dgMonitorEditorView.SelectedColumns.Contains(dgMonitorEditorView.Columns[0]))
            {
                btnDeleteItem.Enabled = true;
            }
            else
            {
                btnDeleteItem.Enabled = false;
            }
        }


        private void dgMonitorEditorView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
            }
        }

        private void dgMonitorEditorView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                cellOldValue = double.Parse(dgMonitorEditorView.CurrentCell.Value.ToString().Trim());
            }
            catch
            {
                cellOldValue = 0.0;
            }
        }
        private void AddItem(object sender, EventArgs e)
        {
            if (sender is int)
            {
                dgMonitorEditorView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                int index = (int)sender;
                if (_vitalSignTable == null) _vitalSignTable = new DataTable();
                if (_vitalSignTable.Columns.Count == 0)
                {
                    _vitalSignTable.Columns.Add("实际时间");
                    _vitalSignTable.Columns.Add("时间");
                }
                for (int i = 0; i < _vitalSignTable.Columns.Count; i++)
                {
                    if (_vitalSignTable.Columns[i].Caption.Equals("_monitorFunctionCode[index].ITEM_CODE")) return;
                }
                string columnName = _monitorFunctionCode[index].ITEM_NAME;
                DataColumn column = new DataColumn(columnName, typeof(string));
                column.Caption = _monitorFunctionCode[index].ITEM_CODE;
                _vitalSignTable.Columns.Add(column);
                dgMonitorEditorView.DataSource = _vitalSignTable;
                dgMonitorEditorView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgMonitorEditorView.Columns[0].ReadOnly = true;
            }
        }
        private void dgMonitorEditorView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            Control control = e.Control;
            if (control is System.Windows.Forms.DataGridViewTextBoxEditingControl)
            {
                System.Windows.Forms.DataGridViewTextBoxEditingControl editor = control as System.Windows.Forms.DataGridViewTextBoxEditingControl;
                editor.TextChanged -= new EventHandler(editor_TextChanged);
                editor.TextChanged += new EventHandler(editor_TextChanged);
            }
        }

        private void editor_TextChanged(object sender, EventArgs e)
        {
            _dataChanged = true;
        }

        private void dgMonitorEditorView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (!_dataChanged)
            //for (int i = 0; i < dgMonitorEditorView.Columns.Count; i++)
            //{
            //    if (dgMonitorEditorView.Columns[i].Name.Equals(_selectDateTime.ToString("HH:mm")))
            //    {
            //        this.dgMonitorEditorView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //        this.dgMonitorEditorView.CurrentCell = this.dgMonitorEditorView.Rows[0].Cells[i];
            //    }
            //    else
            //    {

            //        this.dgMonitorEditorView.Rows[0].Cells[i].Selected = false;
            //    }
            //}
        }
        private void Delete()
        {
            if (MessageBoxFormPC.Show("真的要删除所选时间点的数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = false;
                //NewMonitorData monitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo, ExtendApplicationContext.Current.LoginUser.USER_JOB_ID);
                for (int i = 0; i < dgMonitorEditorView.SelectedRows.Count; i++)
                {
                    //DateTime timePoint = DateTime.Parse(((DataTable)dgMonitorEditorView.DataSource).Rows[dgMonitorEditorView.CurrentCell.RowIndex][0].ToString());
                    DateTime timePoint = DateTime.Parse(dgMonitorEditorView.SelectedRows[i].Cells["实际时间"].Value.ToString());
                    if (_newMonitorData.Delete(timePoint))
                    {
                        result = true;
                    }
                }
                if (result)
                {
                    _dataChanged = true;
                    GetVitalSignDataTable();
                }
            }
        }
        private void dgMonitorEditorView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                if (dgMonitorEditorView.CurrentRow != null && dgMonitorEditorView.CurrentRow.Index >= 0)
                {
                    if (MessageBoxFormPC.Show("真的要删当前体征项目吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        NewMonitorData monitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo, ExtendApplicationContext.Current.LoginUser.USER_JOB_ID);
                        int columnsIndex = dgMonitorEditorView.CurrentCell.ColumnIndex;
                        DateTime timePoint = DateTime.Parse(((DataTable)dgMonitorEditorView.DataSource).Rows[dgMonitorEditorView.CurrentCell.RowIndex][0].ToString());
                        // DateTime timePoint = DateTime.Parse(((DataTable)dgMonitorEditorView.DataSource).Columns[columnsIndex].Caption);
                        if (!string.IsNullOrEmpty(dgMonitorEditorView.CurrentCell.Value.ToString()))
                        {
                            if (monitorData.Delete(timePoint, ((DataTable)dgMonitorEditorView.DataSource).Columns[columnsIndex].Caption, ((DataTable)dgMonitorEditorView.DataSource).Columns[columnsIndex].ColumnName.ToString(), dgMonitorEditorView.CurrentCell.Value.ToString()))
                            {
                                GetVitalSignDataTable();
                                this.dgMonitorEditorView.CurrentCell = this.dgMonitorEditorView.Rows[0].Cells[columnsIndex];
                            }
                        }
                    }
                }
            }
        }

        private void dgMonitorEditorView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ApplicationConfiguration.IsModifyVitalSignShowDifferent)
            {
                if (e.RowIndex != -1 && e.ColumnIndex > 1 && e.Value != null)
                {
                    string item_code = ""; DateTime columTime = DateTime.Now; string itemValue = "";
                    if (_vitalSignTable.Columns.Count > e.ColumnIndex)
                    {
                        foreach (DataRow row in _vitalSignTable.Rows)
                        {
                            columTime = Convert.ToDateTime(row[0].ToString());
                            item_code = _vitalSignTable.Columns[e.ColumnIndex].Caption;
                            itemValue = e.Value.ToString();
                            if (vitalSignDataTable != null && vitalSignDataTable.Count > 0)
                            {
                                vitalSignDataTable.ForEach(vitalSignRow =>
                                {
                                    if (vitalSignRow.ITEM_CODE.Equals(item_code) && vitalSignRow.ITEM_VALUE.Equals(itemValue)
                               && vitalSignRow.TIME_POINT == columTime && !string.IsNullOrEmpty(vitalSignRow.Flag) && vitalSignRow.Flag == "1")
                                    {
                                        e.CellStyle.ForeColor = Color.Red;
                                    }
                                    else if (vitalSignRow.ITEM_CODE.Equals(item_code) && vitalSignRow.ITEM_VALUE.Equals(itemValue)
                                  && vitalSignRow.TIME_POINT == columTime && !string.IsNullOrEmpty(vitalSignRow.Flag) && vitalSignRow.Flag == "2")
                                    {
                                        e.CellStyle.ForeColor = Color.Blue;
                                    }
                                });
                            }
                        }
                    }
                }
            }
        }
        public EventHandler SignVitalSaveClicked;
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            if (SignVitalSaveClicked != null)
                SignVitalSaveClicked(this, EventArgs.Empty);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetVitalSignDataTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            if (SignVitalSaveClicked != null)
                SignVitalSaveClicked(this, EventArgs.Empty);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Dialog.ShowCustomSelection(_monitorFunctionCode, "ITEM_NAME", btnAddItem, new Size(300, 300), new EventHandler(AddItem));
        }

        private void btnInsertColumns_Click(object sender, EventArgs e)
        {
            if (dgMonitorEditorView.ColumnCount > 0)
            {
                int rowIndex = -1;
                if (dgMonitorEditorView.SelectedRows != null && dgMonitorEditorView.SelectedRows.Count > 0)
                {
                    rowIndex = dgMonitorEditorView.SelectedRows[0].Index;
                }
                List<string> items = new List<string>();
                List<object> values = new List<object>();
                for (int i = 2; i < ((DataTable)dgMonitorEditorView.DataSource).Columns.Count; i++)
                {
                    DataColumn column = ((DataTable)dgMonitorEditorView.DataSource).Columns[i];
                    items.Add(column.Caption);
                    if (rowIndex >= 0)
                    {
                        object v = ((DataTable)dgMonitorEditorView.DataSource).Rows[rowIndex][i];
                        if (v == System.DBNull.Value)
                        {
                            values.Add("0");
                        }
                        else
                        {
                            values.Add(v.ToString());
                        }
                    }
                }

                MonitorDataEditor monitorEditor;
                if (rowIndex >= 0)
                {
                    monitorEditor = new MonitorDataEditor(_patientID, _visitID, _operID, items
                        , DateTime.Parse(((DataTable)dgMonitorEditorView.DataSource).Rows[rowIndex][0].ToString()), values, _eventNo);
                }
                else
                {
                    monitorEditor = new MonitorDataEditor(_patientID, _visitID, _operID, items, _eventNo);
                }
                DialogHostFormPC dialogHostForm = new DialogHostFormPC(monitorEditor.Caption, monitorEditor.Width, monitorEditor.Height + 30);
                dialogHostForm.Child = monitorEditor;
                dialogHostForm.ShowDialog();
                object result = monitorEditor.Result;
                if (result != null && result is DialogResult && (DialogResult)result == DialogResult.OK)
                {
                    GetVitalSignDataTable();
                    _dataChanged = true;
                    if (SignVitalSaveClicked != null)
                        SignVitalSaveClicked(this, EventArgs.Empty);
                }
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgMonitorEditorView.SelectedColumns.Count > 0 && dgMonitorEditorView.CurrentRow.Index >= 0)
            {
                if (MessageBoxFormPC.Show("真的要删除所选列的数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool result = false;
                    NewMonitorData monitorData = new NewMonitorData(_patientID, _visitID, _operID, _eventNo, ExtendApplicationContext.Current.LoginUser.USER_JOB_ID);
                    for (int i = 0; i < dgMonitorEditorView.SelectedColumns.Count; i++)
                    {
                        string code = ((DataTable)dgMonitorEditorView.DataSource).Columns[dgMonitorEditorView.SelectedColumns[i].Index].Caption;

                        if (monitorData.Delete(code))
                        {
                            result = true;
                        }
                    }
                    if (result)
                    {
                        _dataChanged = true;
                        GetVitalSignDataTable();
                        if (SignVitalSaveClicked != null)
                            SignVitalSaveClicked(this, EventArgs.Empty);
                    }
                }
            }
        }

        private void dgMonitorEditorView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                for (int i = 0; i < dgMonitorEditorView.ColumnCount; i++)
                {
                    if (dgMonitorEditorView.Columns[i].SortMode == DataGridViewColumnSortMode.Automatic)
                    {
                        dgMonitorEditorView.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                }
                dgMonitorEditorView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            }
            else if (e.ColumnIndex == 1)
            {
                dgMonitorEditorView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                dgMonitorEditorView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
        }

        private void dgMonitorEditorView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgMonitorEditorView.IsCurrentCellDirty) //有未提交的更//改
            {
                this.dgMonitorEditorView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
