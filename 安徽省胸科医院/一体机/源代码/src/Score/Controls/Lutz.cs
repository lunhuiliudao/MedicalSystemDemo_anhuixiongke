/*----------------------------------------------------------------
      // Copyright (C) 2005 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：Lutz.cs
      // 文件功能描述：Lutz麻醉危险性评分
      //
      // 
      // 创建标识：陈晨-2008-06-25
----------------------------------------------------------------*/

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
    public partial class Lutz : BaseControl
    {
        #region  构造方法

        public Lutz() : this("", -1, -1) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        //public Lutz(DataSetModel.Patient.PatientRow patientRow) : this(patientRow, "Lutz麻醉危险性评分") { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        /// <param name="title">模块标题</param>
        //public Lutz(DataSetModel.Patient.PatientRow patientRow, string title)
        //    : base(patientRow, title)
        //{
        //    InitializeComponent();
        //}
        public Lutz(string patientID, decimal visitID, decimal deptID)
            : base(patientID, visitID, deptID, "Lutz麻醉危险性评分")
        {
            InitializeComponent();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 30;

        }
        #endregion
        #region 私有变量

        private List<MED_LUTZ_SCORING_RESULT> lutzDataTable;
        private List<MED_LUTZ_SCORING_RESULT> lutzTable;
        private List<MED_PATIENT_SCORING_RESULT> patientScore;
        /// <summary>
        /// 评分时间
        /// </summary>
        DateTime scoreTime;
        int s1;
        int s2;
        int s3;
        int s4;
        int s5;
        int s6;
        int s7;
        int s8;
        int s9;
        int s10;
        int s11;
        int s12;
        int s13;
        int s14;
        int s15;

        #endregion
        #region 方法
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
        /// 绑定数据到表格
        /// </summary>
        private void bindToDataGrid()
        {
            if (string.IsNullOrEmpty(_patientID))
                return;
            lutzTable = DataOperator.GetDataLutz(_patientID, _visitID, _deptID);
            patientScore = DataOperator.GetPatientScoringResultDt(_patientID, _visitID, _deptID, "Lutz");
            dgvLutz.AutoGenerateColumns = false;
            dgvLutz.DataSource = patientScore;

            RefreshGraph();
        }
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
        /// 获取手术种类、血红蛋白值 0、2、4
        /// </summary>
        private int getS1_S15(DevExpress.XtraEditors.ComboBoxEdit comboTemp)
        {
            int value = 0;
            if (comboTemp.SelectedIndex == 0)
                value = 0;
            else if (comboTemp.SelectedIndex == 1)
                value = 2;
            else if (comboTemp.SelectedIndex == 2)
                value = 4;
            return value;
        }
        /// <summary>
        /// 取得手术种类、血红蛋白索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getS1_S15Index(int value)
        {
            int index = -1;
            if (value == 0)
                index = 0;
            else if (value == 2)
                index = 1;
            else if (value == 4)
                index = 2;
            return index;
        }
        /// <summary>
        /// 获取手术部位值 2、4
        /// </summary>
        private int getS2()
        {
            int value = 0;
            if (cbs2.SelectedIndex == 0)
                value = 2;
            else if (cbs2.SelectedIndex == 1)
                value = 4;
            return value;
        }
        /// <summary>
        /// 取得手术部位索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getS2Index(int value)
        {
            int index = -1;
            if (value == 2)
                index = 0;
            else if (value == 4)
                index = 1;
            return index;
        }
        /// <summary>
        /// 获取手术时间、病人年龄、心律失常、代谢、循环系统值 0、1、2,心脏、呼吸 0、1、2、3,血钾 0、1
        /// </summary>
        private int getS3_S4_S7_S10_S6_S8_S9_S13(DevExpress.XtraEditors.ComboBoxEdit comboTemp)
        {
            int value = 0;
            if (comboTemp.SelectedIndex == 0)
                value = 0;
            else if (comboTemp.SelectedIndex == 1)
                value = 1;
            else if (comboTemp.SelectedIndex == 2)
                value = 2;
            else if (comboTemp.SelectedIndex == 3)
                value = 3;
            return value;
        }
        /// <summary>
        /// 取得手术时间、病人年龄、心律失常、代谢、循环系统、心脏、血钾索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getS3_S4_S7_S10_S6_S8_S9_S13Index(int value)
        {
            int index = -1;
            if (value == 0)
                index = 0;
            else if (value == 1)
                index = 1;
            else if (value == 2)
                index = 2;
            else if (value == 3)
                index = 3;
            return index;
        }
        /// <summary>
        /// 获取全身情况值 0、1、3、4
        /// </summary>
        private int getS5()
        {
            int value = 0;
            if (cbs1.SelectedIndex == 0)
                value = 0;
            else if (cbs5.SelectedIndex == 1)
                value = 1;
            else if (cbs5.SelectedIndex == 2)
                value = 3;
            else if (cbs5.SelectedIndex == 3)
                value = 4;
            return value;
        }
        /// <summary>
        /// 取得全身情况索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getS5Index(int value)
        {
            int index = -1;
            if (value == 0)
                index = 0;
            else if (value == 1)
                index = 1;
            else if (value == 3)
                index = 2;
            else if (value == 4)
                index = 3;
            return index;
        }
        /// <summary>
        /// 获取意识值 0 4
        /// </summary>
        private int getS11()
        {
            int value = 0;
            if (cbs1.SelectedIndex == 0)
                value = 0;
            else if (cbs5.SelectedIndex == 1)
                value = 4;
            return value;
        }

        /// <summary>
        /// 取得意识索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getS11Index(int value)
        {
            int index = -1;
            if (value == 0)
                index = 0;
            else if (value == 4)
                index = 1;
            return index;
        }
        /// <summary>
        /// 获取肾功能值
        /// </summary>
        private int getS12()
        {
            int value = 0;
            if (cbs12.SelectedIndex == 0)
                value = 2;
            return value;
        }

        /// <summary>
        /// 取得肾功能索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getS12Index(int value)
        {
            int index = -1;
            if (value == 2)
                index = 0;
            return index;
        }
        /// <summary>
        /// 获取肝功能值
        /// </summary>
        private int getS14()
        {
            int value = 0;
            if (cbs14.SelectedIndex == 0)
                value = 0;
            else if (cbs14.SelectedIndex == 1)
                value = 2;
            return value;
        }

        /// <summary>
        /// 取得肝功能索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getS14Index(int value)
        {
            int index = -1;
            if (value == 0)
                index = 0;
            else if (value == 2)
                index = 1;
            return index;
        }
        /// <summary>
        /// 清空控件值
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public void Clear()
        {
            cbs1.SelectedIndex = -1;
            cbs2.SelectedIndex = -1;
            cbs3.SelectedIndex = -1;
            cbs4.SelectedIndex = -1;
            cbs5.SelectedIndex = -1;
            cbs6.SelectedIndex = -1;
            cbs7.SelectedIndex = -1;
            cbs8.SelectedIndex = -1;
            cbs9.SelectedIndex = -1;
            cbs10.SelectedIndex = -1;
            cbs11.SelectedIndex = -1;
            cbs12.SelectedIndex = -1;
            cbs13.SelectedIndex = -1;
            cbs14.SelectedIndex = -1;
            cbs15.SelectedIndex = -1;
            txtMemo.Text = "";
            txtScore.Text = "";
            txtdangerLevel.Text = "";
        }
        /// <summary>
        /// 计算分值
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public int computeScore()
        {
            int scoreValue = 0;
            s1 = getS1_S15(cbs1);
            s2 = getS2();
            s3 = getS3_S4_S7_S10_S6_S8_S9_S13(cbs3);
            s4 = getS3_S4_S7_S10_S6_S8_S9_S13(cbs4);
            s5 = getS5();
            s6 = getS3_S4_S7_S10_S6_S8_S9_S13(cbs6);
            s7 = getS3_S4_S7_S10_S6_S8_S9_S13(cbs7);
            s8 = getS3_S4_S7_S10_S6_S8_S9_S13(cbs8);
            s9 = getS3_S4_S7_S10_S6_S8_S9_S13(cbs9);
            s10 = getS3_S4_S7_S10_S6_S8_S9_S13(cbs10);
            s11 = getS11();
            s12 = getS12();
            s13 = getS3_S4_S7_S10_S6_S8_S9_S13(cbs13);
            s14 = getS14();
            s15 = getS1_S15(cbs15);
            scoreValue = s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10 + s11 + s12 + s13 + s14 + s15;
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
        /// 危险程度
        /// </summary>
        /// <returns></returns>
        /// <summary>
        private void dangerLevel(int scorevalue)
        {

            if (scorevalue >= 0 && scorevalue <= 6)
            {

                txtdangerLevel.Text = "低";
            }
            else if (scorevalue >= 7 && scorevalue <= 10)
            {
                txtdangerLevel.Text = "中";
            }
            else if (scorevalue > 10)
            {
                txtdangerLevel.Text = "高";
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

            if (lutzDataTable == null)
            {
                lutzDataTable = new List<MED_LUTZ_SCORING_RESULT>();
            }
            scoreTime = DataOperator.GetSysDate();

            lutzDataTable.Add(new MED_LUTZ_SCORING_RESULT()
            {
                PATIENT_ID = _patientID,
                VISIT_ID = (int)_visitID,
                DEP_ID = (int)_deptID,
                SCORING_DATE_TIME = scoreTime,
                S1 = cbs1.SelectedIndex,
                S2 = cbs2.SelectedIndex,
                S3 = cbs3.SelectedIndex,
                S4 = cbs4.SelectedIndex,
                S5 = cbs5.SelectedIndex,
                S6 = cbs6.SelectedIndex,
                S7 = cbs7.SelectedIndex,
                S8 = cbs8.SelectedIndex,
                S9 = cbs9.SelectedIndex,
                S10 = cbs10.SelectedIndex,
                S11 = cbs11.SelectedIndex,
                S12 = cbs12.SelectedIndex,
                S13 = cbs13.SelectedIndex,
                S14 = cbs14.SelectedIndex,
                S15 = cbs15.SelectedIndex,

                MEMO = this.txtMemo.Text
            });

            return DataOperator.UpdateLutzScore(lutzDataTable);
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
                SCORING_DATE_TIME = scoreTime,
                SCORING_METHOD = "Lutz",
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
        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="deTable"></param>
        private void pushValue(List<MED_LUTZ_SCORING_RESULT> lutzDataTable)
        {
            cbs1.SelectedIndex = int.Parse(lutzDataTable[0].S1.ToString().Trim());
            cbs2.SelectedIndex = int.Parse(lutzDataTable[0].S2.ToString().Trim());
            cbs3.SelectedIndex = int.Parse(lutzDataTable[0].S3.ToString().Trim());
            cbs4.SelectedIndex = int.Parse(lutzDataTable[0].S4.ToString().Trim());
            cbs5.SelectedIndex = int.Parse(lutzDataTable[0].S5.ToString().Trim());
            cbs6.SelectedIndex = int.Parse(lutzDataTable[0].S6.ToString().Trim());
            cbs7.SelectedIndex = int.Parse(lutzDataTable[0].S7.ToString().Trim());
            cbs8.SelectedIndex = int.Parse(lutzDataTable[0].S8.ToString().Trim());

            cbs9.SelectedIndex = int.Parse(lutzDataTable[0].S9.ToString().Trim());
            cbs10.SelectedIndex = int.Parse(lutzDataTable[0].S10.ToString().Trim());
            cbs11.SelectedIndex = int.Parse(lutzDataTable[0].S11.ToString().Trim());
            cbs12.SelectedIndex = int.Parse(lutzDataTable[0].S12.ToString().Trim());
            cbs13.SelectedIndex = int.Parse(lutzDataTable[0].S13.ToString().Trim());
            cbs14.SelectedIndex = int.Parse(lutzDataTable[0].S14.ToString().Trim());
            cbs15.SelectedIndex = int.Parse(lutzDataTable[0].S15.ToString().Trim());
            txtScore.Text = dgvLutz.SelectedRows[0].Cells["SCORING_VALUE"].Value == null ? "" : dgvLutz.SelectedRows[0].Cells["SCORING_VALUE"].Value.ToString();
            txtMemo.Text = lutzDataTable[0].MEMO == null ? "" : lutzDataTable[0].MEMO.ToString();
            txtdangerLevel.Text = patientScore[0].DEGREE == null ? "" : patientScore[0].DEGREE.ToString();

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
                if (exsitRow >= dgvLutz.SelectedRows[0].Index + 1)
                    break;
            }
            for (index = dgvLutz.SelectedRows[0].Index + deleteBeforeSelect; index < patientScore.Count; index++)
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
            for (int rowNo = 0; rowNo < lutzTable.Count; rowNo++)
            {
                if (lutzTable[rowNo].ModelStatus != ModelStatus.Deleted)
                {
                    if (lutzTable[rowNo].SCORING_DATE_TIME.ToString() == patientScore[findMainTableIndex()].SCORING_DATE_TIME.ToString())
                        return rowNo;
                }
            }
            return -1;
        }

        #endregion

        #region 事件
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lutz_Load(object sender, EventArgs e)
        {
            SetGraphParameters();
            bindToDataGrid();
            RefreshGraph(); ;
        }
        /// <summary>
        /// 评分按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnScore_Click(object sender, EventArgs e)
        {
            computeScore();
            int i = computeScore();
            dangerLevel(i);
        }


        /// <summary>
        /// 保存评分详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveScore_Click(object sender, EventArgs e)
        {
            if (saveDetail() > 0 && saveScoreResult() > 0)
            {
                RefreshGraph();
                Dialog.MessageBox("保存成功", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindToDataGrid();
                Clear();
            }
        }
        private void dgvLutz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                lutzDataTable = DataOperator.GetLutz(_patientID, _visitID, _deptID,
                                 (DateTime)dgvLutz.Rows[e.RowIndex].Cells[0].Value);
                pushValue(lutzDataTable);
            }
        }


        private void btn_dele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLutz.Rows.Count > 0 && dgvLutz.SelectedRows != null)
                {
                    var row = lutzTable[quaryIndex()];
                    row.ModelStatus = ModelStatus.Deleted;

                    var row2 = patientScore[findMainTableIndex()];
                    row2.ModelStatus = ModelStatus.Deleted;

                    RefreshGraph();
                    Clear();
                    if (dgvLutz.Rows.Count > 0)
                    {
                        dgvLutz.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataOperator.UpdatePatientScoringResult(patientScore) >= 0)
            {
                if (DataOperator.UpdateLutzScore(lutzTable) >= 0)
                {

                    RefreshGraph();
                    bindToDataGrid();
                    Dialog.MessageBox("保存成功！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Dialog.MessageBox("保存失败！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //bindToDataGrid();
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion

    }
}
