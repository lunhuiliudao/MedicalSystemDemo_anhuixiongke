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
    public partial class Pars : BaseControl
    {
        #region  构造方法
        public Pars() : this("", -1, -1) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        //public Pars(DataSetModel.Patient.PatientRow patientRow) : this(patientRow, "PARS麻醉恢复评分") { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        /// <param name="title">模块标题</param>
        //public Pars(DataSetModel.Patient.PatientRow patientRow, string title)
        //    : base(patientRow, title)
        //{
        //    InitializeComponent();
        //}
        public Pars(string patientID, decimal visitID, decimal deptID)
            : base(patientID, visitID, deptID, "PARS麻醉恢复评分")
        {
            InitializeComponent();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 30;

        }
        #endregion
        #region 私有变量
        /// <summary>
        /// 评分数据表
        /// </summary>
        private List<MED_PATIENT_SCORING_RESULT> patientScore;
        private List<MED_PARS_SCORING_RESULT> parsDatatable;
        private List<MED_PARS_SCORING_RESULT> parsTable;
        /// <summary>
        /// 评分时间
        /// </summary>
        DateTime scoreDateTime;
        private int S1;
        private int S2;
        private int S3;
        private int S4;
        private int S5;

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
            txtMemo.Text = "";
            txtScore.Text = "";
        }
        /// <summary>
        /// 绑定数据到表格
        /// </summary>
        private void bindToDataGrid()
        {
            if (string.IsNullOrEmpty(_patientID))
                return;
            parsTable = DataOperator.GetDataPars(_patientID, _visitID, _deptID);
            patientScore = DataOperator.GetPatientScoringResultDt(_patientID, _visitID, _deptID, "pars");
            dgvPars.AutoGenerateColumns = false;
            dgvPars.DataSource = patientScore;
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
        /// 获取活动分值
        /// </summary>
        /// <returns></returns>
        private int getS1()
        {
            int score = -1;
            foreach (RadioButton rbtn in gbS1.Controls)
            {
                if (rbtn.Checked)
                {

                    switch (rbtn.Text.Trim())
                    {
                        case "四肢均能活动":
                            score = 2;
                            break;
                        case "两个肢体活动":

                            score = 1;
                            break;
                        case "一个肢体也不能活动":

                            score = 0;
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
        /// 获取呼吸分值
        /// </summary>
        /// <returns></returns>
        private int getS2()
        {
            int score = -1;
            foreach (RadioButton rbtn in gbS2.Controls)
            {
                if (rbtn.Checked)
                {

                    switch (rbtn.Text.Trim())
                    {
                        case "能做深呼吸和咳嗽":
                            score = 2;
                            break;
                        case "呼吸困难，通气不足":

                            score = 1;
                            break;
                        case "呼吸暂停（无自主呼吸）":

                            score = 0;
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
        /// 获取循环分值
        /// </summary>
        /// <returns></returns>
        private int getS3()
        {
            int score = -1;
            foreach (RadioButton rbtn in gbS3.Controls)
            {
                if (rbtn.Checked)
                {
                    switch (rbtn.Text.Trim())
                    {
                        case "收缩压波动为麻醉前水平±20%":

                            score = 2;
                            break;
                        case "收缩压波动为麻醉前水平±20%～±50%":

                            score = 1;
                            break;
                        case "收缩压波动为麻醉前水平±50%":
                            score = 0;
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
        /// 获取意识分值
        /// </summary>
        /// <returns></returns>
        private int getS4()
        {
            int score = -1;
            foreach (RadioButton rbtn in gbS4.Controls)
            {
                if (rbtn.Checked)
                {

                    switch (rbtn.Text.Trim())
                    {
                        case "能集中注意力回答问题":

                            score = 2;
                            break;
                        case "呼唤名字病人能被唤醒":

                            score = 1;
                            break;
                        case "听力刺激不能诱出任何反应":

                            score = 0;
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
        /// 获取皮肤分值
        /// </summary>
        /// <returns></returns>
        private int getS5()
        {
            int score = -1;
            foreach (RadioButton rbtn in gbS5.Controls)
            {
                if (rbtn.Checked)
                {

                    switch (rbtn.Text.Trim())
                    {
                        case "正常或粉红色皮肤":

                            score = 2;
                            break;
                        case "任何皮肤的变化 例如:苍白 瘀斑 黄疸 小脓疮":

                            score = 1;
                            break;
                        case "甲床、唇及皮肤发绀":

                            score = 0;
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
        /// 显示内容
        /// </summary>
        /// <param name="deTable"></param>
        private void pushValue(List<MED_PARS_SCORING_RESULT> parsTable)
        {
            Clear();
            foreach (RadioButton rbut in gbS1.Controls)
            {

                //活动
                if (rbut.Name == "rbtns1_" + parsTable[0].S1.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS2.Controls)
            {
                //呼吸
                if (rbut.Name == "rbtns2_" + parsTable[0].S2.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS3.Controls)
            {
                //循环
                if (rbut.Name == "rbtns3_" + parsTable[0].S3.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS4.Controls)
            {
                //意识
                if (rbut.Name == "rbtns4_" + parsTable[0].S4.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            foreach (RadioButton rbut in gbS5.Controls)
            {
                //皮肤
                if (rbut.Name == "rbtns5_" + parsTable[0].S5.ToString())
                {
                    rbut.Checked = true;
                    break;
                }
            }
            txtScore.Text = dgvPars.SelectedRows[0].Cells["SCORING_VALUE"].Value == null ? "" : dgvPars.SelectedRows[0].Cells["SCORING_VALUE"].Value.ToString();
            txtMemo.Text = patientScore[0].MEMO == null ? "" : patientScore[0].MEMO.ToString();
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
                SCORING_METHOD = "pars",
                SCORING_VALUE = int.Parse(txtScore.Text),
                MEMO = txtMemo.Text,
                OPERATOR = operatorNurse,
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
            if (parsDatatable == null)
            {
                parsDatatable = new List<MED_PARS_SCORING_RESULT>();
            }
            scoreDateTime = DataOperator.GetSysDate();

            parsDatatable.Add(new MED_PARS_SCORING_RESULT()
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
                MEMO = this.txtMemo.Text
            });

            return DataOperator.UpdateParsScore(parsDatatable);
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

            if (S1 == -1)
                S1 = 0;
            if (S2 == -1)
                S2 = 0;
            if (S3 == -1)
                S3 = 0;
            if (S4 == -1)
                S4 = 0;
            if (S5 == -1)
                S5 = 0;
            scoreValue = S1 + S2 + S3 + S4 + S5;
            if (scoreValue >= 0)
            {
                txtScore.Text = scoreValue.ToString();
                return scoreValue;
            }
            else
            {
                return -1;
            }
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
                if (exsitRow >= dgvPars.SelectedRows[0].Index + 1)
                    break;
            }
            for (index = dgvPars.SelectedRows[0].Index + deleteBeforeSelect; index < patientScore.Count; index++)
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
            for (int rowNo = 0; rowNo < parsTable.Count; rowNo++)
            {
                if (parsTable[rowNo].ModelStatus != ModelStatus.Deleted)
                {
                    if (parsTable[rowNo].SCORING_DATE_TIME.ToString() == patientScore[findMainTableIndex()].SCORING_DATE_TIME.ToString())
                        return rowNo;
                }
            }
            return -1;
        }

        #endregion

        #region 事件
        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// 评分按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScore_Click(object sender, EventArgs e)
        {
            computeScore();
        }

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pars_Load(object sender, EventArgs e)
        {
            SetGraphParameters();
            bindToDataGrid();
            RefreshGraph();
        }

        /// <summary>
        /// 保存按钮
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
                //Clear();
            }
        }



        private void btn_dele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPars.Rows.Count > 0 && dgvPars.SelectedRows != null)
                {
                    var row = parsTable[quaryIndex()];
                    row.ModelStatus = ModelStatus.Deleted;

                    var row2 = patientScore[findMainTableIndex()];
                    row2.ModelStatus = ModelStatus.Deleted;

                    RefreshGraph();
                    Clear();
                    if (dgvPars.Rows.Count > 0)
                    {
                        dgvPars.Rows[0].Selected = true;
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
            if (DataOperator.UpdatePatientScoringResult(patientScore) >= 0)
            {
                if (DataOperator.UpdateParsScore(parsTable) >= 0)
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


        private void dgvPars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                parsDatatable = DataOperator.GetPars(_patientID, _visitID, _deptID,
                                 (DateTime)dgvPars.Rows[e.RowIndex].Cells[0].Value);
                pushValue(parsDatatable);
            }
        }
        #endregion
    }
}
