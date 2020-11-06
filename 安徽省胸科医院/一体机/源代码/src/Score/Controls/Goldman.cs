using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Controls;
using Com.MedicalSystem.Common.Utilities;
using System.Collections.Generic;
using MedicalSystem.AnesWorkStation.Domain;

namespace MedicalSystem.AnesWorkStation.Score
{
    public partial class Goldman : BaseControl
    {

        #region  ���췽��

        public Goldman() : this("", -1, -1) { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="patientRow">������Ϣ</param>
        //public Goldman(DataSetModel.Patient.PatientRow patientRow) : this(patientRow, "GOLDMAN�����Σ��������") { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="patientRow">������Ϣ</param>
        /// <param name="title">ģ�����</param>
        //public Goldman(DataSetModel.Patient.PatientRow patientRow, string title)
        //    : base(patientRow, title)
        //{
        //    InitializeComponent();
        //}
        public Goldman(string patientID, decimal visitID, decimal deptID)
            : base(patientID, visitID, deptID, "GOLDMAN�����Σ��������")
        {
            InitializeComponent();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 30;

        }
        #endregion
        #region ˽�б���
        /// <summary>
        /// �������ݱ�
        /// </summary>
        private List<MED_PATIENT_SCORING_RESULT> patientScore;
        private List<MED_GOLDMAN_SCORING_RESULT> goldmanDataTable;
        private List<MED_GOLDMAN_SCORING_RESULT> goldmanTable;
        int s1 = 0;
        int s2 = 0;
        int s3 = 0;
        int s4 = 0;
        int s5 = 0;
        int s6 = 0;
        int s7 = 0;
        int s8 = 0;
        int s9 = 0;
        DateTime scoreDateTime;
        #endregion
        #region ����
        /// <summary>
        /// �����ݵ����
        /// </summary>
        private void bindToDataGrid()
        {
            if (string.IsNullOrEmpty(_patientID))
                return;
            goldmanTable = DataOperator.GetDataGoldman(_patientID, _visitID, _deptID);

            patientScore = DataOperator.GetPatientScoringResultDt(_patientID, _visitID, _deptID, "goldman");
            dgvGoldman.AutoGenerateColumns = false;
            dgvGoldman.DataSource = patientScore;
            Clear();
        }
        /// <summary>
        /// �������߲���
        /// </summary>

        private void SetGraphParameters()
        {
            ///Y������
            myGraph1.MainPanel.YAxisList.Add(new MedAxis(this.Font, Brushes.Black, 100, 0, 20));
            myGraph1.MainPanel.YAxisList.MinSetp = 1;
            myGraph1.MainPanel.YAxisList.Pen.Color = Color.Black;

            ///X������
            MedAxis axis = new MedAxis(this.Font, Brushes.Black, 10, 1, 1f);
            myGraph1.MainPanel.XAxisList.Add(axis);
            myGraph1.MainPanel.XAxisList.MinSetp = 1;
            myGraph1.MainPanel.XAxisList.Pen.Color = Color.Black;

            ///��������
            myGraph1.MainPanel.LeftMargin = 10;
            myGraph1.MainPanel.BottomMargin = 20;
            myGraph1.MainPanel.RectBorderPen = Pens.Gray;

            myGraph1.MainPanel.HasAxisGridLine = false;
            myGraph1.MainPanel.XAxisTitleAtTop = false;
        }

        /// <summary>
        /// ˢ��ͼ��
        /// </summary>
        private void RefreshGraph()
        {
            myGraph1.MainPanel.CurveList.Clear();
            MedPointList points = new MedPointList();
            if (patientScore != null)
            {
                foreach (var row in patientScore)
                {
                    if (row.ModelStatus != ModelStatus.Deleted)
                        points.Add(points.Count + 1, (double)row.SCORING_VALUE);
                }
                myGraph1.MainPanel.CurveList.Add(new MedCurve(points));
            }
            myGraph1.Invalidate();
        }
        /// <summary>
        /// �����ֵ
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public int computeScore()
        {
            int score = 0;
            int lever = 0;
            double deathRate = 0;

            if (ckxs1_10.Checked)
            {
                score += 10;
                s1 = 10;
            }
            if (ckxs2_5.Checked)
            {
                score += 5;
                s2 = 5;
            }
            if (ckxs3_11.Checked)
            {
                score += 11;
                s3 = 11;
            }
            if (ckxs4_3.Checked)
            {
                score += 3;
                s4 = 3;
            }
            if (ckxs5_7.Checked)
            {
                score += 7;
                s5 = 7;
            }
            if (ckxs6_7.Checked)
            {
                score += 7;
                s6 = 7;
            }
            if (ckxs7_3.Checked)
            {
                score += 3;
                s7 = 3;
            }
            if (ckxs8_3.Checked)
            {
                score += 3;
                s8 = 3;
            }
            if (ckxs9_3.Checked)
            {
                score += 3;
                s9 = 3;
            }
            if (score >= 0 && score <= 5)
            {
                lever = 1;
                deathRate = 0.2;
            }
            else if (score >= 6 && score <= 12)
            {
                lever = 2;
                deathRate = 2;
            }
            else if (score >= 13 && score <= 25)
            {
                lever = 3;
                deathRate = 2;
            }
            else if (score >= 26)
            {
                lever = 4;
                deathRate = 56;
            }
            txtDeathRate.Text = deathRate.ToString();
            txtLever.Text = lever.ToString();
            txtScore.Text = score.ToString();
            return score;
        }
        /// <summary>
        /// �������ֽ��
        /// </summary>
        /// <returns></returns>
        private int saveScoreResult()
        {
            if (txtScore.Text == "")
            {
                return -1;
            }
            string operatorNurse = DataOperator.Operator;
            if (operatorNurse == null)
            {
                return -1;
            }

            if (patientScore == null)
            {
                patientScore = new List<MED_PATIENT_SCORING_RESULT>();
            }

            patientScore.Add(new MED_PATIENT_SCORING_RESULT()
            {
                PATIENT_ID = _patientID,
                VISIT_ID = (int)_visitID,
                DEP_ID = (int)_deptID,
                SCORING_DATE_TIME = scoreDateTime,
                SCORING_METHOD = "goldman",
                SCORING_VALUE = int.Parse(txtScore.Text),
                DEGREE = txtLever.Text,
                DEATH_PROBABILITY = Decimal.Parse(txtDeathRate.Text) / 100,
                PAT_CONDITION = txtMemo.Text,
                OPERATOR = operatorNurse
            });

            if (DataOperator.UpdatePatientScoringResult(patientScore) >= 0)
            {
                return 1;
            }
            else
            {
                Dialog.MessageBox("����ʧ�ܣ�", "������Ϣ����վ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
        }

        /// ����������ϸѡ��
        /// </summary>
        /// <returns></returns>
        private int saveDetail()
        {
            if (txtScore.Text == "")
            {
                Dialog.MessageBox("�������֣��ٱ��棡", "������Ϣ����վ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            if (ckxs1_10.Checked)
            {
                s1 = 10;
            }
            if (ckxs2_5.Checked)
            {
                s2 = 5;
            }
            if (ckxs3_11.Checked)
            {
                s3 = 11;
            }
            if (ckxs4_3.Checked)
            {
                s4 = 3;
            }
            if (ckxs5_7.Checked)
            {
                s5 = 7;
            }
            if (ckxs6_7.Checked)
            {
                s6 = 7;
            }
            if (ckxs7_3.Checked)
            {
                s7 = 3;
            }
            if (ckxs8_3.Checked)
            {
                s8 = 3;
            }
            if (ckxs9_3.Checked)
            {
                s9 = 3;
            }

            if (goldmanDataTable == null)
            {
                goldmanDataTable = new List<MED_GOLDMAN_SCORING_RESULT>();
            }

            scoreDateTime = DataOperator.GetSysDate();

            goldmanDataTable.Add(new MED_GOLDMAN_SCORING_RESULT()
            {
                PATIENT_ID = _patientID,
                VISIT_ID = (int)_visitID,
                DEP_ID = (int)_deptID,

                SCORING_DATE_TIME = scoreDateTime,
                S1 = s1,
                S2 = s2,
                S3 = s3,
                S4 = s4,
                S5 = s5,
                S6 = s6,
                S7 = s7,
                S8 = s8,
                S9 = s9,
                MEMO = this.txtMemo.Text
            });

            return DataOperator.UpdateGoldman(goldmanDataTable);
        }
        private void Clear()
        {
            ckxs1_10.Checked = false;
            ckxs2_5.Checked = false;
            ckxs3_11.Checked = false;
            ckxs4_3.Checked = false;
            ckxs5_7.Checked = false;
            ckxs6_7.Checked = false;
            ckxs7_3.Checked = false;
            ckxs8_3.Checked = false;
            ckxs9_3.Checked = false;
            txtDeathRate.Text = "";
            txtLever.Text = "";
            txtMemo.Text = "";
            txtScore.Text = "";
        }
        private Boolean getIndex(int value)
        {
            Boolean choose = false;
            if (value != 0)
            {
                choose = true;
            }
            return choose;
        }
        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="deTable"></param>
        private void pushValue(List<MED_GOLDMAN_SCORING_RESULT> goldman_DataTable)
        {
            ckxs1_10.Checked = getIndex(int.Parse(goldman_DataTable[0].S1.ToString().Trim()));
            ckxs2_5.Checked = getIndex(int.Parse(goldman_DataTable[0].S2.ToString().Trim()));
            ckxs3_11.Checked = getIndex(int.Parse(goldman_DataTable[0].S3.ToString().Trim()));
            ckxs4_3.Checked = getIndex(int.Parse(goldman_DataTable[0].S4.ToString().Trim()));
            ckxs5_7.Checked = getIndex(int.Parse(goldman_DataTable[0].S5.ToString().Trim()));
            ckxs6_7.Checked = getIndex(int.Parse(goldman_DataTable[0].S6.ToString().Trim()));
            ckxs7_3.Checked = getIndex(int.Parse(goldman_DataTable[0].S7.ToString().Trim()));
            ckxs8_3.Checked = getIndex(int.Parse(goldman_DataTable[0].S8.ToString().Trim()));
            ckxs9_3.Checked = getIndex(int.Parse(goldman_DataTable[0].S9.ToString().Trim()));
            txtScore.Text = dgvGoldman.SelectedRows[0].Cells["SCORING_VALUE1"].Value == null ? "" : dgvGoldman.SelectedRows[0].Cells["SCORING_VALUE1"].Value.ToString();
            txtLever.Text = dgvGoldman.SelectedRows[0].Cells["DEGREE1"].Value == null ? "" : dgvGoldman.SelectedRows[0].Cells["DEGREE1"].Value.ToString();
            txtDeathRate.Text = dgvGoldman.SelectedRows[0].Cells["DEATH_PROBABILITY1"].Value == null ? "": dgvGoldman.SelectedRows[0].Cells["DEATH_PROBABILITY1"].Value.ToString();
            txtMemo.Text = goldman_DataTable[0].MEMO == null ? "" : goldman_DataTable[0].MEMO.ToString();
        }
        /// <summary>
        /// ��ȡdataGirdViewѡ��������
        /// </summary>
        /// <returns></returns>
        private int findMainTableIndex()
        {
            int deleteBeforeSelect = 0, exsitRow = 0, index;
            for (int i = 0; i < patientScore.Count; i++)
            {
                if (patientScore[i].ModelStatus == ModelStatus.Deleted)
                    deleteBeforeSelect++;
                else
                    exsitRow++;
                if (exsitRow >= dgvGoldman.SelectedRows[0].Index + 1)
                    break;
            }
            for (index = dgvGoldman.SelectedRows[0].Index + deleteBeforeSelect; index < patientScore.Count; index++)
            {
                if (patientScore[index].ModelStatus == ModelStatus.Deleted)
                    continue;
                else
                {
                    break;
                }
            }
            return index;
        }

        private int quaryIndex()
        {
            for (int rowNo = 0; rowNo < goldmanTable.Count; rowNo++)
            {
                if (goldmanTable[rowNo].ModelStatus != ModelStatus.Deleted)
                {
                    if (goldmanTable[rowNo].SCORING_DATE_TIME.ToString() == patientScore[findMainTableIndex()].SCORING_DATE_TIME.ToString())
                        return rowNo;
                }
            }
            return -1;
        }
        #endregion
        #region �¼�
        private void Goldman_Load(object sender, EventArgs e)
        {
            bindToDataGrid();
            SetGraphParameters();
            Clear();
        }
        /// <summary>
        /// ���ְ�ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScore_Click(object sender, EventArgs e)
        {
            computeScore();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveDetail() > 0 && saveScoreResult() > 0)
            {
                RefreshGraph();
                Dialog.MessageBox("����ɹ�", "������Ϣ����վ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindToDataGrid();
                Clear();
            }
        }
        /// <summary>
        /// ��հ�ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void dgvGoldman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            goldmanDataTable = DataOperator.GetGoldman(_patientID, _visitID, _deptID,
                  (DateTime)dgvGoldman.Rows[e.RowIndex].Cells[0].Value);
            pushValue(goldmanDataTable);
        }

        /// <summary>
        /// ɾ����ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGoldman.Rows.Count > 0 && dgvGoldman.SelectedRows != null)
                {

                    var row = goldmanTable[quaryIndex()];
                    row.ModelStatus = ModelStatus.Deleted;

                    var row2 = patientScore[findMainTableIndex()];
                    row2.ModelStatus = ModelStatus.Deleted;

                    RefreshGraph();
                    Clear();
                    if (dgvGoldman.Rows.Count > 0)
                    {
                        dgvGoldman.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void btnSaveScore_Click(object sender, EventArgs e)
        {
            if (DataOperator.UpdatePatientScoringResult(patientScore) >= 0 && DataOperator.UpdateGoldman(goldmanTable) >= 0)
            {
                RefreshGraph();
                bindToDataGrid();
                Dialog.MessageBox("����ɹ���", "������Ϣ����վ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Dialog.MessageBox("����ʧ�ܣ�", "������Ϣ����վ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
