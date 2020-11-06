using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using DevExpress.XtraEditors;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    [ToolboxItem(false)]
    public partial class TimePointBloodGasEditor : BaseView
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        private string _patientID;
        private int _visitID;
        private int _operID;
        private string _detailID;

        public DateTime TimePoint
        {
            get { return dateEdit1.DateTime; }
            set { dateEdit1.DateTime = value; }
        }

        public TimePointBloodGasEditor()
        {
            InitializeComponent();
        }

        public TimePointBloodGasEditor(string patientID, int visitID, int operID, string detailID)
            : this()
        {
            //  dateEdit1.Properties.ReadOnly = true;
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _detailID = detailID;
            //if (!string.IsNullOrEmpty(ApplicationConfiguration.BloodGasTempletNames))
            //{
            //    string[] names = ApplicationConfiguration.BloodGasTempletNames.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //    if (names.Length > 0)
            //    {
            //        foreach (string name in names)
            //        {
            //            comboBoxEditSample.Properties.Items.Add(name);
            //        }
            //    }
            //}
        }

        private void LoadGridList()
        {
            dataGridView1.Rows.Clear();

            foreach (MED_BLOOD_GAS_DICT row in ExtendApplicationContext.Current.CommDict.BloodGasDict)
            {
                if (row.BLG_STATUS.Equals("1"))
                {
                    dataGridView1.Rows.Add(new object[] { row.BLG_CODE, row.BLG_NAME, null });
                }
            }
        }
        private void LoadBloodGasList(string detailID)
        {
            LoadGridList();
            if (!string.IsNullOrEmpty(detailID))
            {
                List<MED_BLOOD_GAS_MASTER> bloodMaster = operationInfoRepository.GetBloodGasMasterListByID(detailID).Data;
                if (bloodMaster != null && bloodMaster.Count == 1)
                {
                    dateEdit1.DateTime = bloodMaster[0].RECORD_DATE;
                    if (!string.IsNullOrEmpty(bloodMaster[0].NURSE_MEMO1) && bloodMaster[0].NURSE_MEMO1.Contains("动脉"))
                    {
                        radioGroupBloodGasTypes.SelectedIndex = 1;
                    }
                    List<MED_BLOOD_GAS_DETAIL> bloodDetail = operationInfoRepository.GetBloodGasDetailList(detailID).Data;
                    if (bloodDetail != null && bloodDetail.Count > 0)
                    {
                        MED_BLOOD_GAS_DETAIL detailRow = null;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            string code = row.Cells[0].Value.ToString();
                            detailRow = bloodDetail.Where(x => x.BLG_CODE == code).FirstOrDefault();
                            if (detailRow != null)
                            {
                                row.Cells[2].Value = detailRow.BLG_VALUE;
                            }
                        }
                    }
                }
            }
        }

        private void CheckSaveButtonStatus()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[2].ErrorText))
                {
                    btnSave.Enabled = false;
                    return;
                }
            }
            bool find = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2].FormattedValue != null && !string.IsNullOrEmpty(row.Cells[2].FormattedValue.ToString().Trim()))
                {
                    find = true;
                    break;
                }
            }
            btnSave.Enabled = find;
        }

        private void TimePointBloodGasEditor_Load(object sender, EventArgs e)
        {
            this.SetDefaultGridViewStyle(dataGridView1);
            if (!string.IsNullOrEmpty(_detailID))
            {
                List<MED_BLOOD_GAS_MASTER> bloodMaster = operationInfoRepository.GetBloodGasMasterListByID(_detailID).Data;
                if (bloodMaster != null && bloodMaster.Count == 1)
                {
                    if (bloodMaster[0].NURSE_MEMO2.StartsWith("ok@"))
                    {
                        comboBoxEditSample.SelectedItem = bloodMaster[0].NURSE_MEMO2.Replace("ok@", "");
                    }
                }
            }
            else if (string.IsNullOrEmpty(_detailID) && comboBoxEditSample.Properties.Items.Count > 0)
            {
                comboBoxEditSample.SelectedIndex = 0;
            }
            LoadBloodGasList(_detailID);
            btnSave.Enabled = false;
        }

        private void btnSelectBloodGas_Click(object sender, EventArgs e)
        {
            XtraForm form = new XtraForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            BloodGasSelector bloodGasSelector = new BloodGasSelector(_patientID, _visitID, _operID);
            bloodGasSelector.DefaultDate = dateEdit1.DateTime.Date;
            form.Width = bloodGasSelector.Width;
            form.Height = bloodGasSelector.Height;
            bloodGasSelector.Dock = DockStyle.Fill;
            form.Controls.Add(bloodGasSelector);
            form.Text = "选择血气记录";
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(bloodGasSelector.SelectedDetailID))
                {
                    _detailID = bloodGasSelector.SelectedDetailID;
                    LoadBloodGasList(_detailID);
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[2].Value = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<MED_BLOOD_GAS_MASTER> bloodGasMasterDataTable = operationInfoRepository.GetBloodGasMasterList(_patientID, _visitID, _operID).Data;
            if (bloodGasMasterDataTable == null) return;
            MED_BLOOD_GAS_MASTER row = null;
            if (string.IsNullOrEmpty(_detailID))
            {
                _detailID = TimePoint.ToString("yyyy-MM-dd HH:mm") + "|" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                row = new MED_BLOOD_GAS_MASTER();
                row.PATIENT_ID = _patientID;
                row.VISIT_ID = _visitID;
                row.OPER_ID = _operID;
                row.RECORD_DATE = TimePoint;
                row.OP_DATE = DateTime.Now;
                row.OPERATOR = string.IsNullOrEmpty(ExtendApplicationContext.Current.LoginUser.USER_JOB_ID) ? ExtendApplicationContext.Current.LoginUser.LOGIN_NAME : ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
                row.DETAIL_ID = _detailID;
                bloodGasMasterDataTable.Add(row);
            }
            else
            {
                row = bloodGasMasterDataTable.Where(x => x.DETAIL_ID == _detailID).FirstOrDefault();
            }
            if (row == null)
            {
                _detailID = TimePoint.ToString("yyyy-MM-dd HH:mm") + "|" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                row = new MED_BLOOD_GAS_MASTER();
                row.PATIENT_ID = _patientID;
                row.VISIT_ID = _visitID;
                row.OPER_ID = _operID;
                row.RECORD_DATE = TimePoint;
                row.OP_DATE = DateTime.Now;
                row.OPERATOR = string.IsNullOrEmpty(ExtendApplicationContext.Current.LoginUser.USER_JOB_ID) ? ExtendApplicationContext.Current.LoginUser.LOGIN_NAME : ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
                row.DETAIL_ID = _detailID;
                bloodGasMasterDataTable.Add(row);
            }
            if (radioGroupBloodGasTypes.SelectedIndex == 1)
            {
                row.NURSE_MEMO1 = "动脉";
            }
            else
            {
                row.NURSE_MEMO1 = null;
            }
            row.NURSE_MEMO2 = null;// "ok@" + comboBoxEditSample.Text.Trim();
            if (operationInfoRepository.SaveBloodGasMaster(bloodGasMasterDataTable).Data <= 0) return;

            List<MED_BLOOD_GAS_DETAIL> detailTable = operationInfoRepository.GetBloodGasDetailList(_detailID).Data;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                string blgCode = drow.Cells[0].Value.ToString();
                MED_BLOOD_GAS_DETAIL detailRow = detailTable.Where(x => x.BLG_CODE == blgCode).FirstOrDefault();
                if (detailRow == null)
                {
                    detailRow = new MED_BLOOD_GAS_DETAIL();
                    detailRow.DETAIL_ID = _detailID;
                    detailRow.BLG_CODE = blgCode;
                    detailTable.Add(detailRow);
                }
                detailRow.OP_DATE = DateTime.Now;
                detailRow.OPERATOR = string.IsNullOrEmpty(ExtendApplicationContext.Current.LoginUser.USER_JOB_ID) ? ExtendApplicationContext.Current.LoginUser.LOGIN_NAME : ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
                string value = "";
                if (drow.Cells[2].Value != null && drow.Cells[2].Value != System.DBNull.Value)
                {
                    value = drow.Cells[2].Value.ToString();
                }
                detailRow.BLG_VALUE = value;
            }
            if (operationInfoRepository.SaveBloodGasDetail(detailTable).Data <= 0) return;
            ParentForm.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CheckSaveButtonStatus();
        }

        private void radioGroupBloodGasTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSaveButtonStatus();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (e.FormattedValue != null && !e.FormattedValue.Equals(string.Empty))
                {
                    double d = 0;
                    if (!double.TryParse(e.FormattedValue.ToString().Trim(), out d))
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = "输入值不是有效的血气值";
                        btnSave.Enabled = false;
                        return;
                    }
                    else if (e.FormattedValue.ToString().Trim().Length > 6)
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = "输入值长度不可大于6";
                        btnSave.Enabled = false;
                        return;
                    }
                }
                dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = string.Empty;
            }
        }

        private void comboBoxEditSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBloodGasList(_detailID);
        }
    }
}
