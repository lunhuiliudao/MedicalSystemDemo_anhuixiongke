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
    public partial class ScoreTISSPanel : BaseControl
    {

        /// <summary>
        /// 评分数据表
        /// </summary>
        private List<MED_PATIENT_SCORING_RESULT> tissScore;
        private List<MED_TISS_SCORING_RESULT_DETAIL> tissDataTable;
        /// <summary>
        /// 评分时间
        /// </summary>
        private DateTime scoreDateTime;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ScoreTISSPanel() : this("", -1, -1) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        //public ScoreTISSPanel(DataSetModel.Patient.PatientRow patientRow) : this(patientRow, "TISS评分") { }

        ///// <summary>
        ///// 构造方法
        ///// </summary>
        ///// <param name="patientRow">病人信息</param>
        ///// <param name="title">模块标题</param>
        //public ScoreTISSPanel(DataSetModel.Patient.PatientRow patientRow, string title)
        //    : base(patientRow, title)
        //{
        //    InitializeComponent();
        //}
        public ScoreTISSPanel(string patientID, decimal visitID, decimal deptID)
            : base(patientID, visitID, deptID, "TISS评分")
        {
            InitializeComponent();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 30;

        }

        /// <summary>
        /// 设置曲线参数
        /// </summary>
        private void SetGraphParameters()
        {
            ///Y坐标轴
            myGraph1.MainPanel.YAxisList.Add(new MedAxis(this.Font, Brushes.Black, 100, 0, 20));
            myGraph1.MainPanel.YAxisList.MinSetp = 1;
            myGraph1.MainPanel.YAxisList.Pen.Color = Color.Black;

            ///X坐标轴
            MedAxis axis = new MedAxis(this.Font, Brushes.Black, 10, 1, 1f);
            myGraph1.MainPanel.XAxisList.Add(axis);
            myGraph1.MainPanel.XAxisList.MinSetp = 1;
            myGraph1.MainPanel.XAxisList.Pen.Color = Color.Black;

            ///其他属性
            myGraph1.MainPanel.LeftMargin = 10;
            myGraph1.MainPanel.BottomMargin = 20;
            myGraph1.MainPanel.RectBorderPen = Pens.Gray;

            myGraph1.MainPanel.HasAxisGridLine = false;
            myGraph1.MainPanel.XAxisTitleAtTop = false;
        }

        /// <summary>
        /// 刷新图表
        /// </summary>
        private void RefreshGraph()
        {
            myGraph1.MainPanel.CurveList.Clear();
            MedPointList points = new MedPointList();
            if (tissScore != null)
            {
                foreach (var row in tissScore)
                {
                    if (row.ModelStatus != ModelStatus.Deleted)
                        points.Add(points.Count + 1, (double)row.SCORING_VALUE);
                }
                myGraph1.MainPanel.CurveList.Add(new MedCurve(points));
            }
            myGraph1.Invalidate();
        }
        /// <summary>
        /// 获取dataGirdView选中行索引
        /// </summary>
        /// <returns></returns>
        private int findMainTableIndex()
        {
            int deleteBeforeSelect = 0, exsitRow = 0, index;
            for (int i = 0; i < tissScore.Count; i++)
            {
                if (tissScore[i].ModelStatus == ModelStatus.Deleted)
                    deleteBeforeSelect++;
                else
                    exsitRow++;
                if (exsitRow >= dgvTiss.SelectedRows[0].Index + 1)
                    break;
            }
            for (index = dgvTiss.SelectedRows[0].Index + deleteBeforeSelect; index < tissScore.Count; index++)
            {
                if (tissScore[index].ModelStatus == ModelStatus.Deleted)
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
            for (int rowNo = 0; rowNo < tissDataTable.Count; rowNo++)
            {
                if (tissDataTable[rowNo].ModelStatus != ModelStatus.Deleted)
                {
                    if (tissDataTable[rowNo].SCORING_DATE_TIME.ToString() == tissScore[findMainTableIndex()].SCORING_DATE_TIME.ToString())
                        return rowNo;
                }
            }
            return -1;
        }
        /// <summary>
        /// 绑定数据到表格
        /// </summary>
        private void bindToDataGrid()
        {
            if (string.IsNullOrEmpty(_patientID))
                return;
            tissDataTable = DataOperator.GetDataTiss(_patientID, _visitID, _deptID);
            tissScore = DataOperator.GetPatientScoringResultDt(_patientID, _visitID, _deptID, "tiss");
            dgvTiss.AutoGenerateColumns = false;
            dgvTiss.DataSource = tissScore;
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        protected override void RefreshAll()
        {
            base.RefreshAll();
            bindToDataGrid();
            RefreshGraph();
        }
        /// <summary>
        /// 保存评分结果
        /// </summary>
        /// <returns></returns>
        private int saveScoreResult()
        {
            if (txtScore.Text == "")
            {
                return -1;
            }
            string operatorNurse = DataOperator.Operator;
            if (operatorNurse == null) return -1;

            if (tissScore == null)
            {
                tissScore = new List<MED_PATIENT_SCORING_RESULT>();
            }

            tissScore.Add(new MED_PATIENT_SCORING_RESULT()
            {
                PATIENT_ID = _patientID,
                VISIT_ID = (int)_visitID,
                DEP_ID = (int)_deptID,
                SCORING_DATE_TIME = scoreDateTime,
                SCORING_METHOD = "tiss",
                SCORING_VALUE = int.Parse(txtScore.Text),
                //addRow.DEGREE = deathRates.ToString().Trim();
                PAT_CONDITION = tex_DescriptionIllness.Text,
                OPERATOR = operatorNurse
            });


            if (DataOperator.UpdatePatientScoringResult(tissScore) >= 0)
            {
                return 1;
            }
            else
            {
                Dialog.MessageBox("保存失败！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
        }

        /// <summary>
        /// 保存评分明细选项
        /// </summary>
        /// <returns></returns>
        private int saveDetailSap()
        {
            string columnName = "";
            //int score = 0;
            if (txtScore.Text == "")
            {
                Dialog.MessageBox("请先评分，再保存！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 1;
            }

            List<MED_TISS_SCORING_RESULT_DETAIL> detailTable = new List<MED_TISS_SCORING_RESULT_DETAIL>();

            MED_TISS_SCORING_RESULT_DETAIL detailRow = new MED_TISS_SCORING_RESULT_DETAIL();

            detailRow.PATIENT_ID = _patientID;
            detailRow.VISIT_ID = (int)_visitID;
            detailRow.DEP_ID = (int)_deptID;
            scoreDateTime = DataOperator.GetSysDate();
            detailRow.SCORING_DATE_TIME = scoreDateTime;
            DevExpress.XtraEditors.CheckEdit temp;
            foreach (Control getControl in panel4.Controls)
            {
                try
                {
                    temp = getControl as DevExpress.XtraEditors.CheckEdit;
                    char[] NumberLetter = temp.Name.ToCharArray(temp.Name.Length - 3, 1);
                    if (char.IsNumber(NumberLetter[0]))
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 3);
                    else
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 2);
                    if (temp.Checked == true)
                        setValue(detailRow, "4", columnName);
                    else
                        setValue(detailRow, "0", columnName);
                }
                catch (Exception) { }
            }
            foreach (Control getControl in panel5.Controls)
            {
                try
                {
                    temp = getControl as DevExpress.XtraEditors.CheckEdit;
                    char[] NumberLetter = temp.Name.ToCharArray(temp.Name.Length - 3, 1);
                    if (char.IsNumber(NumberLetter[0]))
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 3);
                    else
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 2);
                    if (temp.Checked == true)
                        setValue(detailRow, "3", columnName);
                    else
                        setValue(detailRow, "0", columnName);
                }
                catch (Exception) { }
            }
            foreach (Control getControl in panel6.Controls)
            {
                try
                {
                    temp = getControl as DevExpress.XtraEditors.CheckEdit;
                    char[] NumberLetter = temp.Name.ToCharArray(temp.Name.Length - 3, 1);
                    if (char.IsNumber(NumberLetter[0]))
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 3);
                    else
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 2);
                    if (temp.Checked == true)
                        setValue(detailRow, "2", columnName);
                    else
                        setValue(detailRow, "0", columnName);
                }
                catch (Exception) { }
            }
            foreach (Control getControl in panel7.Controls)
            {
                try
                {
                    temp = getControl as DevExpress.XtraEditors.CheckEdit;
                    char[] NumberLetter = temp.Name.ToCharArray(temp.Name.Length - 3, 1);
                    if (char.IsNumber(NumberLetter[0]))
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 3);
                    else
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 2);
                    if (temp.Checked == true)
                        setValue(detailRow, "1", columnName);
                    else
                        setValue(detailRow, "0", columnName);
                }
                catch (Exception) { }
            }
            detailRow.MEMO = tex_DescriptionIllness.Text;

            detailTable.Add(detailRow);
            if (DataOperator.UpdateTissScoringResult(detailTable) >= 0)
            {
                return 1;
            }
            else
            {
                Dialog.MessageBox("保存失败！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="text"></param>
        /// <param name="columnName"></param>
        private void setValue(MED_TISS_SCORING_RESULT_DETAIL row, string text, string columnName)
        {
            decimal value = 0;
            try
            {
                value = decimal.Parse(text);
            }
            catch
            {
                return;
            }
            row.SetValue(columnName, value);
        }

        private void UserControlTISS_Load(object sender, EventArgs e)
        {
            SetGraphParameters();
            bindToDataGrid();
            RefreshGraph();
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            computeScore();
        }

        private void computeScore()
        {
            int score = 0;
            DevExpress.XtraEditors.CheckEdit temp;
            ControlCollection collection = panel4.Controls;
            for (int count = 0; count < collection.Count; count++)
            {
                temp = collection[count] as DevExpress.XtraEditors.CheckEdit;
                if (temp.Checked == true)
                    score += 4;
            }
            collection = panel5.Controls;
            for (int count = 0; count < collection.Count; count++)
            {
                temp = collection[count] as DevExpress.XtraEditors.CheckEdit;
                if (temp.Checked == true)
                    score += 3;
            }
            collection = panel6.Controls;
            for (int count = 0; count < collection.Count; count++)
            {
                temp = collection[count] as DevExpress.XtraEditors.CheckEdit;
                if (temp.Checked == true)
                    score += 2;
            }
            collection = panel7.Controls;
            for (int count = 0; count < collection.Count; count++)
            {
                temp = collection[count] as DevExpress.XtraEditors.CheckEdit;
                if (temp.Checked == true)
                    score += 1;
            }
            txtScore.Text = score.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit temp;
            ControlCollection collection = panel4.Controls;
            for (int count = 0; count < collection.Count; count++)
            {
                temp = collection[count] as DevExpress.XtraEditors.CheckEdit;
                temp.Checked = false;
            }
            collection = panel5.Controls;
            for (int count = 0; count < collection.Count; count++)
            {
                temp = collection[count] as DevExpress.XtraEditors.CheckEdit;
                temp.Checked = false;
            }
            collection = panel6.Controls;
            for (int count = 0; count < collection.Count; count++)
            {
                temp = collection[count] as DevExpress.XtraEditors.CheckEdit;
                temp.Checked = false;
            }
            collection = panel7.Controls;
            for (int count = 0; count < collection.Count; count++)
            {
                temp = collection[count] as DevExpress.XtraEditors.CheckEdit;
                temp.Checked = false;
            }
            txtScore.Text = "";
        }

        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="deTable"></param>
        private void pushValue(List<MED_TISS_SCORING_RESULT_DETAIL> deTable)
        {
            string columnName = "";
            DevExpress.XtraEditors.CheckEdit temp;
            txtScore.Text = dgvTiss.SelectedRows[0].Cells["scoreValue"].Value == null ? "" : dgvTiss.SelectedRows[0].Cells["scoreValue"].Value.ToString();
            foreach (Control getControl in panel4.Controls)
            {
                try
                {
                    temp = getControl as DevExpress.XtraEditors.CheckEdit;
                    char[] NumberLetter = temp.Name.ToCharArray(temp.Name.Length - 3, 1);
                    if (char.IsNumber(NumberLetter[0]))
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 3);
                    else
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 2);
                    temp.Checked = getBoolValue(deTable[0].GetValue(columnName));
                }
                catch (Exception) { }
            }
            foreach (Control getControl in panel5.Controls)
            {
                try
                {
                    temp = getControl as DevExpress.XtraEditors.CheckEdit;
                    char[] NumberLetter = temp.Name.ToCharArray(temp.Name.Length - 3, 1);
                    if (char.IsNumber(NumberLetter[0]))
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 3);
                    else
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 2);
                    temp.Checked = getBoolValue(deTable[0].GetValue(columnName));
                }
                catch (Exception) { }
            }
            foreach (Control getControl in panel6.Controls)
            {
                try
                {
                    temp = getControl as DevExpress.XtraEditors.CheckEdit;
                    char[] NumberLetter = temp.Name.ToCharArray(temp.Name.Length - 3, 1);
                    if (char.IsNumber(NumberLetter[0]))
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 3);
                    else
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 2);
                    temp.Checked = getBoolValue(deTable[0].GetValue(columnName));
                }
                catch (Exception) { }
            }
            foreach (Control getControl in panel7.Controls)
            {
                try
                {
                    temp = getControl as DevExpress.XtraEditors.CheckEdit;
                    char[] NumberLetter = temp.Name.ToCharArray(temp.Name.Length - 3, 1);
                    if (char.IsNumber(NumberLetter[0]))
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 3);
                    else
                        columnName = "T" + temp.Name.Substring(temp.Name.Length - 2);
                    temp.Checked = getBoolValue(deTable[0].GetValue(columnName));
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// 取得对应逻辑值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool getBoolValue(object value)
        {
            try
            {
                if (int.Parse(value.ToString()) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_patientID))
            {
                Dialog.MessageBox("请先选中一个病人！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (saveDetailSap() > 0 && saveScoreResult() > 0)
            {
                RefreshGraph();
                bindToDataGrid();
                Dialog.MessageBox("保存成功！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvTiss_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            List<MED_TISS_SCORING_RESULT_DETAIL> detailTable;

            detailTable = DataOperator.GetTissScoringResultDt(_patientID, _visitID, _deptID,
                (DateTime)dgvTiss.Rows[e.RowIndex].Cells[0].Value);
            pushValue(detailTable);
        }

        private void btn_dele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTiss.Rows.Count > 0 && dgvTiss.SelectedRows != null)
                {
                    var row = tissDataTable[quaryIndex()];
                    row.ModelStatus = ModelStatus.Deleted;

                    var row2 = tissScore[findMainTableIndex()];
                    row2.ModelStatus = ModelStatus.Deleted;

                    RefreshGraph();

                    if (dgvTiss.Rows.Count > 0)
                    {
                        dgvTiss.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            if (DataOperator.UpdatePatientScoringResult(tissScore) >= 0)
            {
                if (DataOperator.UpdateTissScoringResult(tissDataTable) >= 0)
                {
                    RefreshGraph();
                    bindToDataGrid();
                    Dialog.MessageBox("保存成功！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Dialog.MessageBox("保存失败！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
