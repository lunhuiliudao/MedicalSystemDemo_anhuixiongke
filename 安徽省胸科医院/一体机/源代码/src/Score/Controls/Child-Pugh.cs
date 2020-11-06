using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Controls;
using Com.MedicalSystem.Common.Utilities;
using MedicalSystem.AnesWorkStation.Domain;
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.Score
{
    public partial class Child_Pugh : BaseControl
    {

        #region  构造方法

        public Child_Pugh() : this("", -1, -1) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        //public Child_Pugh(DataSetModel.Patient.PatientRow patientRow) : this(patientRow, "Child-Pugh肝脏疾病患者手术危险性评分") { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        /// <param name="title">模块标题</param>
        //public Child_Pugh(DataSetModel.Patient.PatientRow patientRow, string title)
        //    : base(patientRow, title)
        //{
        //    InitializeComponent();
        //}
        public Child_Pugh(string patientID, decimal visitID, decimal deptID)
            : base(patientID, visitID, deptID, "Child-Pugh肝脏疾病患者手术危险性评分")
        {
            InitializeComponent();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 30;

        }
        #endregion

        #region 私有变量
        private List<MED_CHILDPUGH_SCORING_RESULT> ChildpughDataTable;
        private List<MED_CHILDPUGH_SCORING_RESULT> childpughTable;
        private List<MED_PATIENT_SCORING_RESULT> patientScore;
        /// <summary>
        /// 评分时间
        /// </summary>
        DateTime scoreDateTime;

        private int S1;
        private int S2;
        private int S3;
        private int S4;
        private int S5;
        private int S6;
        private int S7;
        #endregion
        #region 方法
        /// <summary>
        /// 刷新信息
        /// </summary>
        protected override void RefreshAll()
        {
            base.RefreshAll();
            bindToDataGrid();
            RefreshGraph();
        }
        /// <summary>
        /// 绑定数据到表格
        /// </summary>
        private void bindToDataGrid()
        {
            if (string.IsNullOrEmpty(_patientID))
                return;
            childpughTable = DataOperator.GetDataChildPugh(_patientID, _visitID, _deptID);
            patientScore = DataOperator.GetPatientScoringResultDt(_patientID, _visitID, _deptID, "child-pugh");
            dgvChildpugh.AutoGenerateColumns = false;
            dgvChildpugh.DataSource = patientScore;
            RefreshGraph();
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
        /// 清空页面信息
        /// </summary>
        private void Clear()
        {
            foreach (RadioButton rab in gbS1.Controls)
            {
                if (rab.Checked)
                {
                    rab.Checked = false;
                }
            }
            foreach (RadioButton rab2 in gbS2.Controls)
            {
                if (rab2.Checked)
                {
                    rab2.Checked = false;
                }
            }
            foreach (RadioButton rab3 in gbS3.Controls)
            {
                if (rab3.Checked)
                {
                    rab3.Checked = false;
                }
            }
            foreach (RadioButton rab4 in gbS4.Controls)
            {
                if (rab4.Checked)
                {
                    rab4.Checked = false;
                }
            }
            foreach (RadioButton rab5 in gbS5.Controls)
            {
                if (rab5.Checked)
                {
                    rab5.Checked = false;
                }

            }
            foreach (RadioButton rab6 in gbS6.Controls)
            {
                if (rab6.Checked)
                {
                    rab6.Checked = false;
                }
            }
            foreach (RadioButton rab7 in gbS7.Controls)
            {
                if (rab7.Checked)
                {
                    rab7.Checked = false;
                }
            }
            txtMemo.Text = "";
            txtScore.Text = "";
            txtdangerLevel.Text = "";
        }

        /// <summary>
        /// 获取肝性脑病分值
        /// </summary>
        /// <returns></returns>
        private int getS1()
        {
            int score = 0;
            foreach (RadioButton rbtn in gbS1.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "无":

                            score = 1;
                            break;
                        case "1～2期":

                            score = 2;
                            break;
                        case "3～4期":
                            score = 3;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }

        /// <summary>
        /// 获取腹水分值
        /// </summary>
        /// <returns></returns>
        private int getS2()
        {
            int score = 0;
            foreach (RadioButton rbtn in gbS2.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "无":

                            score = 1;
                            break;
                        case "轻度":

                            score = 2;
                            break;
                        case "中度":
                            score = 3;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }

        /// <summary>
        /// 获取非原发性胆汁性肝硬化分值
        /// </summary>
        /// <returns></returns>
        private int getS3()
        {
            int score = 0;
            foreach (RadioButton rbtn in gbS3.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "1～2":

                            score = 1;
                            break;
                        case "2～3":

                            score = 2;
                            break;
                        case ">3":
                            score = 3;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }

        /// <summary>
        /// 获取原发性胆汁性肝硬化分值
        /// </summary>
        /// <returns></returns>
        private int getS4()
        {
            int score = 0;
            foreach (RadioButton rbtn in gbS4.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "1～4":

                            score = 1;
                            break;
                        case "4～10":

                            score = 2;
                            break;
                        case ">10":
                            score = 3;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }
        /// <summary>
        /// 获取白蛋白(g/100ml)分值
        /// </summary>
        /// <returns></returns>
        private int getS5()
        {
            int score = 0;
            foreach (RadioButton rbtn in gbS5.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "3.5":

                            score = 1;
                            break;
                        case "2.8～3.5":

                            score = 2;
                            break;
                        case "<2.8":
                            score = 3;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }
        /// 获取凝血酶原时间分值
        /// </summary>
        /// <returns></returns>
        private int getS6()
        {
            int score = 0;
            foreach (RadioButton rbtn in gbS6.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "1～4":

                            score = 1;
                            break;
                        case "4～6":

                            score = 2;
                            break;
                        case ">6":
                            score = 3;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }

        /// 获取营养不良状况分值
        /// </summary>
        /// <returns></returns>
        private int getS7()
        {
            int score = 0;
            foreach (RadioButton rbtn in gbS7.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "轻度":

                            score = 1;
                            break;
                        case "中度":

                            score = 2;
                            break;
                        case "严重":
                            score = 3;
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return score;
        }
        /// <summary>
        /// 计算分值
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public int computeScore()
        {
            int scoreValue = 0;
            S1 = getS1();
            S2 = getS2();
            S3 = getS3();
            S4 = getS4();
            S5 = getS5();
            S6 = getS6();
            S7 = getS7();
            scoreValue = S1 + S2 + S3 + S4 + S5 + S6 + S7;
            if (scoreValue >= 0)
            {
                if (scoreValue >= 5 && scoreValue <= 6)
                {
                    txtdangerLevel.Text = "小";
                }
                else if (scoreValue >= 7 && scoreValue <= 9)
                {
                    txtdangerLevel.Text = "中";
                }
                else if (scoreValue > 9)
                {
                    txtdangerLevel.Text = "大";
                }
                txtScore.Text = scoreValue.ToString();
                return scoreValue;
            }
            else
            {
                return -1;
            }
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
                SCORING_METHOD = "child-pugh",
                SCORING_VALUE = int.Parse(txtScore.Text),
                DEGREE = txtdangerLevel.Text,
                MEMO = txtMemo.Text,
                OPERATOR = operatorNurse
            });


            if (DataOperator.UpdatePatientScoringResult(patientScore) >= 0)
            {
                return 1;
            }
            else
            {
                Dialog.MessageBox("保存失败！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
        }

        /// 保存评分明细选项
        /// </summary>
        /// <returns></returns>
        private int saveDetail()
        {
            if (txtScore.Text == "")
            {
                Dialog.MessageBox("请先评分，再保存！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            scoreDateTime = DataOperator.GetSysDate();

            if (ChildpughDataTable == null)
            {
                ChildpughDataTable = new List<MED_CHILDPUGH_SCORING_RESULT>();
            }

            ChildpughDataTable.Add(new MED_CHILDPUGH_SCORING_RESULT()
            {
                PATIENT_ID = _patientID,
                VISIT_ID = (int)_visitID,
                DEP_ID = (int)_deptID,
                SCORING_DATE_TIME = scoreDateTime,
                S1 = getS1(),
                S2 = getS2(),
                S3 = getS3(),
                S4 = getS4(),
                S5 = getS5(),
                S6 = getS6(),
                S7 = getS7(),
                MEMO = this.txtMemo.Text
            });

            return DataOperator.UpdateChildPugh(ChildpughDataTable);
        }

        /// <summary>
        /// 获取dataGirdView选中行索引
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
                if (exsitRow >= dgvChildpugh.SelectedRows[0].Index + 1)
                    break;
            }
            for (index = dgvChildpugh.SelectedRows[0].Index + deleteBeforeSelect; index < patientScore.Count; index++)
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
            for (int rowNo = 0; rowNo < childpughTable.Count; rowNo++)
            {
                if (childpughTable[rowNo].ModelStatus != ModelStatus.Deleted)
                {
                    if (childpughTable[rowNo].SCORING_DATE_TIME.ToString() == patientScore[findMainTableIndex()].SCORING_DATE_TIME.ToString())
                        return rowNo;
                }
            }
            return -1;
        }
        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="deTable"></param>
        private void pushValue(List<MED_CHILDPUGH_SCORING_RESULT> ChildpughTable)
        {
            Clear();
            foreach (RadioButton rbut in gbS1.Controls)
            {


                if (rbut.Name == "rbtns1_" + ChildpughTable[0].S1.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS2.Controls)
            {

                if (rbut.Name == "rbtns2_" + ChildpughTable[0].S2.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS3.Controls)
            {

                if (rbut.Name == "rbtns3_" + ChildpughTable[0].S3.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS4.Controls)
            {

                if (rbut.Name == "rbtns4_" + ChildpughTable[0].S4.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS5.Controls)
            {
                if (rbut.Name == "rbtns5_" + ChildpughTable[0].S5.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS6.Controls)
            {
                if (rbut.Name == "rbtns6_" + ChildpughTable[0].S6.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS7.Controls)
            {
                if (rbut.Name == "rbtns7_" + ChildpughTable[0].S7.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            txtdangerLevel.Text = dgvChildpugh.SelectedRows[0].Cells["GEGREE"].Value == null ? "" : dgvChildpugh.SelectedRows[0].Cells["GEGREE"].Value.ToString();
            txtScore.Text = dgvChildpugh.SelectedRows[0].Cells["SCORING_VALUE"].Value == null ? "" : dgvChildpugh.SelectedRows[0].Cells["SCORING_VALUE"].Value.ToString();
            txtMemo.Text = ChildpughTable[0].MEMO == null ? "" : ChildpughTable[0].MEMO.ToString();
        }
        #endregion

        private void btnScore_Click(object sender, EventArgs e)
        {
            computeScore();
        }
        private void Child_Pugh_Load(object sender, EventArgs e)
        {
            SetGraphParameters();
            bindToDataGrid();
            RefreshGraph();
        }
        /// <summary>
        /// 保存评分明细按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveDetail() > 0 && saveScoreResult() > 0)
            {
                RefreshGraph();
                Dialog.MessageBox("保存成功", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindToDataGrid();
                Clear();
            }
        }
        /// <summary>
        /// 删除评分信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvChildpugh.Rows.Count > 0 && dgvChildpugh.SelectedRows != null)
                {

                    var row = childpughTable[quaryIndex()];
                    row.ModelStatus = ModelStatus.Deleted;

                    var row2 = patientScore[findMainTableIndex()];
                    row2.ModelStatus = ModelStatus.Deleted;

                    RefreshGraph();
                    Clear();
                    if (dgvChildpugh.Rows.Count > 0)
                    {
                        dgvChildpugh.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvChildpugh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                ChildpughDataTable = DataOperator.GetChildPugh(_patientID, _visitID, _deptID,
                                 (DateTime)dgvChildpugh.Rows[e.RowIndex].Cells[0].Value);
                pushValue(ChildpughDataTable);
            }
        }

        private void btnSaveScore_Click(object sender, EventArgs e)
        {
            if (DataOperator.UpdatePatientScoringResult(patientScore) >= 0)
            {
                if (DataOperator.UpdateChildPugh(childpughTable) >= 0)
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
