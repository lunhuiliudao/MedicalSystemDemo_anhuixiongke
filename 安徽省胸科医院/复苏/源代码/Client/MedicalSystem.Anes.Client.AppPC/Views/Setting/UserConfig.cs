using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors.Controls;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Domain;
using System.Reflection;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    /// <summary>
    /// 配置类
    /// </summary>
    [ToolboxItem(false)]
    public partial class UserConfig : BaseView
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();
        #region 变量
        private PageSetupDialog pageSetupDialog;
        private readonly string ButtonTitle = "按钮标题";
        private readonly string LiquidAttrs = "液体属性";
        private ProgramStatus _programStatus = ProgramStatus.PeroperativePatient;
        private Dictionary<ProgramStatus, string> _statusButtonStrList = new Dictionary<ProgramStatus, string>();
        private string[] _currentButtonStrings = new string[] { "", "", "", "", "" };
        private Dictionary<ProgramStatus, string> _operDocuments = new Dictionary<ProgramStatus, string>();
        private Dictionary<ProgramStatus, string> _operActions = new Dictionary<ProgramStatus, string>();
        #endregion 变量

        #region 方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserConfig()
        {
            InitializeComponent();
            Caption = ViewNames.UserConfig;
            if (!DesignMode)
            {
                List<MemberDetail> list = AssemblyHelper.GetEnumList(typeof(ProLongedDrugUnitShowType), true);
                foreach (MemberDetail item in list)
                {
                    cmbProLonged.Properties.Items.Add(item);
                }
                list = AssemblyHelper.GetEnumList(typeof(NormalDrugUnitShowType), true);
                foreach (MemberDetail item in list)
                {
                    cmbDrugShow.Properties.Items.Add(item);
                }
                List<MED_OPERATING_ROOM> roomList = comnDictRepository.GetOperatingRoomList(ApplicationConfiguration.IsPACUProcess ? "1" : "0").Data;
                if (roomList != null && roomList.Count > 0)
                {
                    foreach (MED_OPERATING_ROOM room in roomList)
                    {
                        txtOpertionRoomNo.Properties.Items.Add(room);
                    }
                }
            }
        }



        private void SetGridViewProperties(DataGridView grid)
        {
            grid.Columns.Add("Item", "Item");
            grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            grid.MultiSelect = false;
            grid.GridColor = grid.BackgroundColor;
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="rowKey"></param>
        private void RemoveFromGrid(DataGridView grid, string rowKey)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(rowKey))
                {
                    grid.Rows.Remove(row);
                    break;
                }
            }
        }
        /// <summary>
        /// 导航菜单相关内容显示
        /// </summary>
        /// <param name="currentButtonStrings"></param>
        /// <param name="groupIndex"></param>
        private void SetNavigateAndGrid(string[] currentButtonStrings, int groupIndex)
        {
            List<string> menus = new List<string>();
            dgvMenuCanSelect.Rows.Clear();
            Type type = typeof(ViewNames);
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                dgvMenuCanSelect.Rows.Add(new string[] { fieldInfo.GetRawConstantValue().ToString().Trim() });
                menus.Add(fieldInfo.GetRawConstantValue().ToString().Trim());
            }
            Dictionary<string, MedicalDocElement> customViews = MedicalDocSettings.GetCustomForms();
            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in customViews)
            {
                if (!menus.Contains(keyValuePair.Key))
                {
                    dgvMenuCanSelect.Rows.Add(new string[] { keyValuePair.Key });
                    menus.Add(keyValuePair.Key);
                }
            }

            dgvMenuSelected.Rows.Clear();
            foreach (string str in currentButtonStrings)
            {
                string[] groupButtons = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string text in groupButtons)
                {
                    string btnText = text;
                    if (btnText.Contains("\t")) btnText = btnText.Replace("\t", "");
                    while (btnText.Contains(" "))
                    {
                        btnText = btnText.Replace(" ", "");
                    }
                    if (!string.IsNullOrEmpty(btnText))
                    {
                        if (str == currentButtonStrings[groupIndex])
                        {
                            dgvMenuSelected.Rows.Add(new string[] { btnText });
                        }
                        RemoveFromGrid(dgvMenuCanSelect, btnText);
                    }
                }
            }
        }
        /// <summary>
        /// 修改缓存中导航菜单
        /// </summary>
        private void modifyButtonStrList()
        {
            int selectIndex = comboBoxEditSample.SelectedIndex > 0 ? 2 : 0;
            if (dgvMenuSelected.Rows.Count > 0)
            {
                List<string> list = new List<string>();
                string str = "";
                for (int i = 0; i < dgvMenuSelected.Rows.Count; i++)
                {
                    str += dgvMenuSelected.Rows[i].Cells[0].Value.ToString().Trim() + ",";
                }
                str = str.Substring(0, str.Length - 1);
                _currentButtonStrings[selectIndex] = str;
                switch (radioGroupProgramStatusByDoc.SelectedIndex)
                {
                    case 0:
                        _statusButtonStrList[ProgramStatus.PeroperativePatient] = string.Join(";", _currentButtonStrings);
                        break;
                    case 1:
                        _statusButtonStrList[ProgramStatus.AnesthesiaRecord] = string.Join(";", _currentButtonStrings);
                        break;
                    case 2:
                        _statusButtonStrList[ProgramStatus.PACURecord] = string.Join(";", _currentButtonStrings);
                        break;
                    case 3:
                        _statusButtonStrList[ProgramStatus.PostoperativePatient] = string.Join(";", _currentButtonStrings);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _currentButtonStrings[selectIndex] = "";
                _statusButtonStrList[_programStatus] = string.Join(";", _currentButtonStrings);
            }
        }
        private void ModifyDocStrList()
        {
            _currentButtonStrings = _statusButtonStrList[_programStatus].Split(new char[] { ';' }, StringSplitOptions.None);
            if (dgvSelectedDoc.Rows.Count > 0)
            {
                List<string> list = new List<string>();
                string str = "";
                for (int i = 0; i < dgvSelectedDoc.Rows.Count; i++)
                {
                    str += dgvSelectedDoc.Rows[i].Cells[0].Value.ToString().Trim() + ",";
                }
                str = str.Substring(0, str.Length - 1);
                _currentButtonStrings[1] = str;

                switch (radioGroupProgramStatusByDoc.SelectedIndex)
                {
                    case 0:
                        _statusButtonStrList[ProgramStatus.PeroperativePatient] = string.Join(";", _currentButtonStrings);
                        break;
                    case 1:
                        _statusButtonStrList[ProgramStatus.AnesthesiaRecord] = string.Join(";", _currentButtonStrings);
                        break;
                    case 2:
                        _statusButtonStrList[ProgramStatus.PACURecord] = string.Join(";", _currentButtonStrings);
                        break;
                    case 3:
                        _statusButtonStrList[ProgramStatus.PostoperativePatient] = string.Join(";", _currentButtonStrings);
                        break;
                    default:
                        break;
                }

            }
            else
            {
                _currentButtonStrings[1] = "";
                _statusButtonStrList[_programStatus] = string.Join(";", _currentButtonStrings);
            }
        }
        /// <summary>
        /// 在内存中更新当前状态医疗文书配置
        /// </summary>
        private void ChangeOperDocument()
        {
            string s1 = "", s2 = "";
            foreach (DataGridViewRow row in dgvSelectedDoc.Rows)
            {
                s1 = s1 + "," + row.Cells[0].Value.ToString();
            }
            if (s1.Length > 0 && s1.StartsWith(","))
            {
                s1 = s1.Substring(1);
            }
            if (s2.Length > 0 && s2.StartsWith(","))
            {
                s2 = s2.Substring(1);
            }
            string text = string.Empty;
            switch (radioGroupProgramStatusByDoc.SelectedIndex)
            {
                case 0:
                    _programStatus = ProgramStatus.PeroperativePatient;
                    break;
                case 1:
                    _programStatus = ProgramStatus.AnesthesiaRecord;
                    break;
                case 2:
                    _programStatus = ProgramStatus.PACURecord;
                    break;
                case 3:
                    _programStatus = ProgramStatus.PostoperativePatient;
                    break;
                default:
                    break;
            }
            _operDocuments[_programStatus] = s1;
            ModifyDocStrList();
        }
        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="grid"></param>
        private void MoveUp(DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                int index = grid.CurrentRow.Index;
                if (index > 0)
                {
                    string text = grid.CurrentCell.Value.ToString();
                    grid.Rows.Remove(grid.CurrentRow);
                    grid.Rows.Insert(index - 1, text);
                    grid.CurrentCell = grid.Rows[index - 1].Cells[0];
                }
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="grid"></param>
        private void MoveDown(DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                int index = grid.CurrentRow.Index;
                if (index < grid.Rows.Count - 1)
                {
                    string text = grid.CurrentCell.Value.ToString();
                    grid.Rows.Remove(grid.CurrentRow);
                    grid.Rows.Insert(index + 1, text);
                    grid.CurrentCell = grid.Rows[index + 1].Cells[0];
                }
            }
        }
        #endregion 方法

        #region 事件
        private void btnOK_Click(object sender, EventArgs e)
        {
            //通用运行参数
            ExtendApplicationContext.Current.OperRoom = txtOpertionRoom.Text;
            ExtendApplicationContext.Current.AnesthesiaWardCode = txtAnesthesiaWardCode.Text;
            ApplicationConfiguration.DrugShow = cmbDrugShow.SelectedIndex;
            ApplicationConfiguration.ProLonged = cmbProLonged.SelectedIndex;
            ExtendApplicationContext.Current.HospBranchCode = txtHospBranchCode.Text;
            //持续用药自动结束 
            ApplicationConfiguration.DrugAutoStop = chkDrugAutoStop.Checked;
            ApplicationConfiguration.DrugAutoStopOperationStatus = cmbDrugStopOperationStatus.Text;
            ApplicationConfiguration.IsModifyVitalSignShowDifferent = chkSignModification.Checked;
            ApplicationConfiguration.IsVerificationAudit = chkVerificationAudit.Checked;

            //本机运行参数
            if (cboPatterns.EditValue != null && cboPatterns.EditValue.Equals("手术间"))
            { ApplicationConfiguration.ApplicationPatterns = "0"; }
            else if (cboPatterns.EditValue != null && cboPatterns.EditValue.Equals("办公室"))
            { ApplicationConfiguration.ApplicationPatterns = "1"; }
            ExtendApplicationContext.Current.OperRoomNo = txtOpertionRoomNo.Text;
            ExtendApplicationContext.Current.BaseAddress = txtBaseAddress.Text;
            ExtendApplicationContext.Current.WebApiUri = txtWebApiUri.Text;
            ApplicationConfiguration.IsPACUProgram = chkPACUProgram.Checked;

            //接口相关参数
            ApplicationConfiguration.SyncOpen = chkSyncOpen.Checked;
            ApplicationConfiguration.IsUpdateScheduleStatus = chkIsUpdateScheduleStatus.Checked;
            ApplicationConfiguration.IsUpdateHisStatus = chkIsUpdateHisStatus.Checked;
            ApplicationConfiguration.IsUpdateAnesCharge = chkIsUpdateAnesFei.Checked;

            //打印归档配置
            //打印设置
            try
            {
                ApplicationConfiguration.PrintPageName = medTextBoxPageName.Text;
                float resultValue = 0f;
                if (!float.TryParse(medTextBoxPaperHeight.Text, out resultValue))
                {
                    resultValue = 0f;
                }
                ApplicationConfiguration.PrintPaperHeight = resultValue;
                resultValue = 0f;
                if (!float.TryParse(medTextBoxPaperWidth.Text, out resultValue))
                {
                    resultValue = 0f;
                }
                ApplicationConfiguration.PrintPaperWidth = resultValue;
                resultValue = 0.5f;
                if (!float.TryParse(medTextBoxPaperLeftOff.Text, out resultValue))
                {
                    resultValue = 0.5f;
                }
                ApplicationConfiguration.PaperLeftOff = resultValue;

                resultValue = 1f;
                if (!float.TryParse(medTextBoxPaperTopOff.Text, out resultValue))
                {
                    resultValue = 1f;
                }
                ApplicationConfiguration.PaperTopOff = resultValue;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "打印设置保存时发生错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //文书上传设置 
            ApplicationConfiguration.PDFServerUrl = txtPDFServerUrl.Text;
            ApplicationConfiguration.PDFLocalUrl = txtPDFLocalUrl.Text;
            ApplicationConfiguration.IsDeleteAfterCommitDoc = chkDeleteAfterCommitDoc.Checked;
            List<string> fileList = new List<string>();
            foreach (CheckedListBoxItem boxItem in chkUpFileList.Items)
            {
                if (boxItem.CheckState == CheckState.Checked)
                {
                    fileList.Add(boxItem.Value.ToString());
                }
            }
            ApplicationConfiguration.PostPDF_Names = string.Join(",", fileList.ToArray());
            ApplicationConfiguration.IsAutomaticArchiving = chkAutomaticArchiving.Checked;
            if (chkAutomaticArchiving.Checked && cboArchivOperAfterDay.EditValue != null)
            {
                string days = cboArchivOperAfterDay.EditValue.ToString();
                ApplicationConfiguration.ArchivOperAfterDay = Convert.ToInt32(days);
            }

            //文书配置 
            ApplicationConfiguration.NoPatientButtons = _statusButtonStrList[ProgramStatus.NoPatient];
            ApplicationConfiguration.PeroperativePatientButtons = _statusButtonStrList[ProgramStatus.PeroperativePatient];
            ApplicationConfiguration.AnesthesiaRecordButtons = _statusButtonStrList[ProgramStatus.AnesthesiaRecord];
            ApplicationConfiguration.PACUButtons = _statusButtonStrList[ProgramStatus.PACURecord];
            ApplicationConfiguration.PostoperativePatientButtons = _statusButtonStrList[ProgramStatus.PostoperativePatient];
            ExtendApplicationContext.Current.StatusButtonStrList = _statusButtonStrList;
            //文书菜单 
            OperationStatusHelper.SetOperDocument(_operDocuments);
            //提交更新到数据库 
            if (comnDictRepository.SaveConfig(ExtendApplicationContext.Current.CommDict.ConfigDict).Data > 0)
            {
                ParentForm.DialogResult = DialogResult.OK;
            }
        }

        private void UserConfig_Load(object sender, EventArgs e)
        {
            this.SetDefaultGridViewStyle(dgvDocumentNames);
            this.SetDefaultGridViewStyle(dgvSelectedDoc);
            this.SetDefaultGridViewStyle(dgvMenuCanSelect);
            this.SetDefaultGridViewStyle(dgvMenuSelected);
            if (!DesignMode)
            {
                //通用运行参数
                txtOpertionRoom.Text = ExtendApplicationContext.Current.OperRoom;
                txtAnesthesiaWardCode.Text = ExtendApplicationContext.Current.AnesthesiaWardCode;
                cmbDrugShow.SelectedIndex = ApplicationConfiguration.DrugShow;
                cmbProLonged.SelectedIndex = ApplicationConfiguration.ProLonged;
                txtHospBranchCode.Text = ExtendApplicationContext.Current.HospBranchCode;
                chkDrugAutoStop.Checked = ApplicationConfiguration.DrugAutoStop;
                cmbDrugStopOperationStatus.Text = ApplicationConfiguration.DrugAutoStopOperationStatus;
                chkSignModification.Checked = ApplicationConfiguration.IsModifyVitalSignShowDifferent;
                chkVerificationAudit.Checked = ApplicationConfiguration.IsVerificationAudit;
                //本机运行参数
                if (ApplicationConfiguration.ApplicationPatterns == "0")
                { cboPatterns.EditValue = "手术间"; }
                else if (ApplicationConfiguration.ApplicationPatterns == "1")
                { cboPatterns.EditValue = "办公室"; }
                txtOpertionRoomNo.Text = ExtendApplicationContext.Current.OperRoomNo;
                txtBaseAddress.Text = ExtendApplicationContext.Current.BaseAddress;
                txtWebApiUri.Text = ExtendApplicationContext.Current.WebApiUri;
                chkPACUProgram.Checked = ApplicationConfiguration.IsPACUProgram;

                //接口相关参数
                chkSyncOpen.Checked = ApplicationConfiguration.SyncOpen;
                chkIsUpdateScheduleStatus.Checked = ApplicationConfiguration.IsUpdateScheduleStatus;
                chkIsUpdateHisStatus.Checked = ApplicationConfiguration.IsUpdateHisStatus;
                chkIsUpdateAnesFei.Checked = ApplicationConfiguration.IsUpdateAnesCharge;
                //打印设置
                medTextBoxPageName.Text = ApplicationConfiguration.PrintPageName;
                medTextBoxPaperHeight.Text = ApplicationConfiguration.PrintPaperHeight.ToString();
                medTextBoxPaperWidth.Text = ApplicationConfiguration.PrintPaperWidth.ToString();
                medTextBoxPaperLeftOff.Text = ApplicationConfiguration.PaperLeftOff.ToString();
                medTextBoxPaperTopOff.Text = ApplicationConfiguration.PaperTopOff.ToString();


                //文书上传设置
                txtPDFServerUrl.Text = ApplicationConfiguration.PDFServerUrl;
                txtPDFLocalUrl.Text = ApplicationConfiguration.PDFLocalUrl;

                chkDeleteAfterCommitDoc.Checked = ApplicationConfiguration.IsDeleteAfterCommitDoc;
                List<string> fileList = new List<string>();
                if (!string.IsNullOrEmpty(ApplicationConfiguration.PostPDF_Names))
                {
                    IEnumerator ie = ApplicationConfiguration.PostPDF_Names.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).GetEnumerator();
                    while (ie.MoveNext())
                    {
                        fileList.Add(ie.Current.ToString());
                    }
                }

                Dictionary<string, MedicalDocElement> docKeyValuePairs = MedicalDocSettings.GetMedicalDocNameAndPath();

                foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docKeyValuePairs)
                {
                    CheckedListBoxItem boxItem = new CheckedListBoxItem(keyValuePair.Key, keyValuePair.Value.Key);
                    //上传文件检查
                    chkUpFileList.Items.Add(boxItem);
                    if (fileList.Contains(keyValuePair.Key))
                    {
                        boxItem.CheckState = CheckState.Checked;
                    }
                }
                chkAutomaticArchiving.Checked = ApplicationConfiguration.IsAutomaticArchiving;
                cboArchivOperAfterDay.EditValue = ApplicationConfiguration.ArchivOperAfterDay.ToString();

                //文书配置
                _statusButtonStrList.Add(ProgramStatus.NoPatient, ApplicationConfiguration.NoPatientButtons);
                _statusButtonStrList.Add(ProgramStatus.PeroperativePatient, ApplicationConfiguration.PeroperativePatientButtons);
                _statusButtonStrList.Add(ProgramStatus.AnesthesiaRecord, ApplicationConfiguration.AnesthesiaRecordButtons);
                _statusButtonStrList.Add(ProgramStatus.PACURecord, ApplicationConfiguration.PACUButtons);
                _statusButtonStrList.Add(ProgramStatus.PostoperativePatient, ApplicationConfiguration.PostoperativePatientButtons);

                _operDocuments.Add(ProgramStatus.PeroperativePatient, ApplicationConfiguration.PeroperativePatientDocuments);
                _operDocuments.Add(ProgramStatus.AnesthesiaRecord, ApplicationConfiguration.AnesthesiaRecordDocuments);
                _operDocuments.Add(ProgramStatus.PACURecord, ApplicationConfiguration.PACURecordEndDocuments);
                _operDocuments.Add(ProgramStatus.PostoperativePatient, ApplicationConfiguration.PostoperativePatientDocuments);

                _operActions.Add(ProgramStatus.PeroperativePatient, ApplicationConfiguration.PeroperativePatientActions);
                _operActions.Add(ProgramStatus.AnesthesiaRecord, ApplicationConfiguration.AnesthesiaRecordActions);
                _operActions.Add(ProgramStatus.PACURecord, ApplicationConfiguration.PACURecordActions);
                _operActions.Add(ProgramStatus.PostoperativePatient, ApplicationConfiguration.PostoperativePatientActions);

                radioGroupProgramStatusByDoc.SelectedIndex = 0;
            }
        }

        private void txtOpertionRoom_DoubleClick(object sender, EventArgs e)
        {
            List<MED_OPERATING_ROOM> room = comnDictRepository.GetOperatingRoomList("0").Data;
            Dialog.ShowCustomSelection(room, "ROOM_NO", txtOpertionRoomNo, new Point(0, txtOpertionRoomNo.Height), new Size(100, 300)
                , new EventHandler(delegate (object s1, EventArgs e1)
                {
                    if (s1 is int)
                    {
                        int index = (int)s1;
                        txtOpertionRoomNo.Text = room[index].ROOM_NO;
                    }
                    else if (s1 is int[])
                    {
                        string s = "";
                        foreach (int i in (s1 as int[]))
                        {
                            s = s + "," + room[i].ROOM_NO;
                        }
                        txtOpertionRoomNo.Text = s.Substring(1);
                    }
                }), true);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)//控制管理员编号为数值
        {

            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')// '\b'表示可以删除键有用
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void chkDrugAutoStop_CheckedChanged(object sender, EventArgs e)
        {
            //持续用药自动结束 
            cmbDrugStopOperationStatus.Visible = chkDrugAutoStop.Checked;
        }
        private void btnCancel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }
        private void chkAutomaticArchiving_CheckedChanged(object sender, EventArgs e)
        {
            cboArchivOperAfterDay.Visible = chkAutomaticArchiving.Checked;
        }
        //文书
        private void dgvDocumentNames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvSelectedDoc.Rows.Add(new string[] { text });
            }
            ChangeOperDocument();
        }

        private void dgvSelectedDoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvDocumentNames.Rows.Add(new string[] { text });
            }
            ChangeOperDocument();
        }

        private void btnDocUp_Click(object sender, EventArgs e)
        {
            MoveUp(dgvSelectedDoc);
            ChangeOperDocument();
        }

        private void btnDocDown_Click(object sender, EventArgs e)
        {
            MoveDown(dgvSelectedDoc);
            ChangeOperDocument();
        }

        private void radioGroupProgramStatusByDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDocumentNames.Rows.Clear();
            dgvMenuCanSelect.Rows.Clear();
            dgvSelectedDoc.Rows.Clear();
            dgvMenuSelected.Rows.Clear();
            List<string> docs = ApplicationConfiguration.MedicalDocumentList;
            foreach (string s in docs)
            {
                dgvDocumentNames.Rows.Add(new string[] { s });
            }
            string textStatus = string.Empty;
            switch (radioGroupProgramStatusByDoc.SelectedIndex)
            {
                case 0:
                    _programStatus = ProgramStatus.PeroperativePatient;
                    break;
                case 1:
                    _programStatus = ProgramStatus.AnesthesiaRecord;
                    break;
                case 2:
                    _programStatus = ProgramStatus.PACURecord;
                    break;
                case 3:
                    _programStatus = ProgramStatus.PostoperativePatient;
                    break;
                default:
                    break;
            }
            string text = _operDocuments[_programStatus];
            if (!string.IsNullOrEmpty(text))
            {
                int index = text.IndexOf(";");
                string s1 = text;
                if (index >= 0)
                {
                    s1 = text.Substring(0, index);
                }
                string[] list = s1.Split(',');
                foreach (string s in list)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        dgvSelectedDoc.Rows.Add(new string[] { s });
                        RemoveFromGrid(dgvDocumentNames, s);
                    }
                }
            }

            _currentButtonStrings = _statusButtonStrList[_programStatus].Split(new char[] { ';' }, StringSplitOptions.None);
            int selectIndex = comboBoxEditSample.SelectedIndex > 0 ? 2 : 0;
            SetNavigateAndGrid(_currentButtonStrings, selectIndex);
        }
        //操作
        private void comboBoxEditSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = comboBoxEditSample.SelectedIndex > 0 ? 2 : 0;
            SetNavigateAndGrid(_currentButtonStrings, selectIndex);
        }

        private void dgvMenuCanSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvMenuSelected.Rows.Add(new string[] { text });
                modifyButtonStrList();
            }
        }

        private void dgvMenuSelected_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentCell != null)
            {
                string text = grid.CurrentCell.Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvMenuCanSelect.Rows.Add(new string[] { text });
                modifyButtonStrList();
            }
        }

        private void btnNavMenuUp_Click(object sender, EventArgs e)
        {
            MoveUp(dgvMenuSelected);
            modifyButtonStrList();
        }

        private void btnNavMenuDown_Click(object sender, EventArgs e)
        {
            MoveDown(dgvMenuSelected);
            modifyButtonStrList();
        }
        #endregion 事件





    }
}
