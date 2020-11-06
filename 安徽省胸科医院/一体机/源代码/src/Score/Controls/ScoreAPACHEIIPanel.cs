/*----------------------------------------------------------------
      // Copyright (C) 2005 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：ScoreAPACHEIIPanel.cs
      // 文件功能描述：APACHEII评分模块
      //
      // 
      // 创建标识：林健
      //
      // 修改标识：戴呈祥-2008-02-22
      // 修改描述：加入曲线趋势图
----------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Com.MedicalSystem.Common.Controls;
using DevExpress.XtraEditors.Controls;
using Com.MedicalSystem.Common.Utilities;
using System.Collections.Generic;
using MedicalSystem.AnesWorkStation.Domain;

namespace MedicalSystem.AnesWorkStation.Score
{
    /// <summary>
    /// APACHEII评分模块
    /// </summary>
    public partial class ScoreAPACHEIIPanel : BaseControl
    {

        #region 变量

        /// <summary>
        /// 错误索引
        /// </summary>
        private int errorIndex = 1;

        /// <summary>
        /// 评分数据表
        /// </summary>
        private List<MED_PATIENT_SCORING_RESULT> appcheScore;
        private List<MED_APACHE2_SCORING_RESULT> apache2Score;
        private Com.MedicalSystem.Icu.DataSetModel.CareItems.VitalSignsRecLifeDataTable careItemsDateTable;
        private Com.MedicalSystem.Icu.DataSetModel.CheckReport.AssayReportDataTable AssayTable;
        private DataTable noOper = new DataTable();     //非手术患者系数
        private DataTable afterOper = new DataTable();      //手术后患者
        private System.Collections.Specialized.NameValueCollection nameConvertCollection;
        /// <summary>
        /// 评分时间
        /// </summary>
        private DateTime scoreDateTime;
        /// <summary>
        /// 提取数据的时间
        /// </summary>
        private DateTime startTime, endTime;

        #endregion 变量

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public ScoreAPACHEIIPanel() : this("", -1, -1) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="patientRow">病人信息</param>
        //public ScoreAPACHEIIPanel(DataSetModel.Patient.PatientRow patientRow) : this(patientRow, "APACHE2评分") { }
        public ScoreAPACHEIIPanel(string patientID, decimal visitID, decimal deptID)
            : base(patientID, visitID, deptID, "APACHE2评分")
        {
            InitializeComponent();
            dateTimePicker1.DateTime = DateTime.Now.Date.AddDays(-1);

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 30;

        }

        ///// <summary>
        ///// 构造方法
        ///// </summary>
        ///// <param name="patientRow">病人信息</param>
        ///// <param name="title">模块标题</param>
        //public ScoreAPACHEIIPanel(DataSetModel.Patient.PatientRow patientRow, string title)
        //    : base(patientRow, title)
        //{
        //    InitializeComponent();
        //    dateTimePicker1.DateTime = DateTime.Now.Date.AddDays(-1);
        //}

        #endregion 构造方法

        #region 方法
        /// <summary>
        /// 刷新数据
        /// </summary>
        protected override void RefreshAll()
        {
            base.RefreshAll();
            bindToDataGrid();
            RefreshGraph();
            Clear();
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
            if (appcheScore != null)
            {
                foreach (var row in appcheScore)
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
            apache2Score = DataOperator.GetDataApache2(_patientID, _visitID, _deptID);
            appcheScore = DataOperator.GetPatientScoringResultDt(_patientID, _visitID, _deptID, "apache2");
            dgvApache.AutoGenerateColumns = false;
            dgvApache.DataSource = appcheScore;
        }

        /// <summary>
        /// 下拉框校验
        /// </summary>
        /// <param name="sender">下拉框</param>
        /// <param name="e">事件参数</param>
        private void comb_Value_Validated(object sender, EventArgs e)
        {
            if (comb_EyeOpen.SelectedIndex != -1 && comb_language.SelectedIndex != -1 && comb_Body.SelectedIndex != -1)
                errorIndex = 0;
            if (comb_EyeOpen.SelectedIndex == -1)
            {
                errorProviderEye.SetError(comb_EyeOpen, "必须选择一项！");
                errorIndex = 1;
            }
            else
                errorProviderEye.SetError(comb_EyeOpen, "");
            if (comb_language.SelectedIndex == -1)
            {
                errorProviderEye.SetError(comb_language, "必须选择一项！");
                errorIndex = 1;
            }
            else
                errorProviderEye.SetError(comb_language, "");
            if (comb_Body.SelectedIndex == -1)
            {
                errorProviderEye.SetError(comb_Body, "必须选择一项！");
                errorIndex = 1;
            }
            else
                errorProviderEye.SetError(comb_Body, "");
        }

        /// <summary>
        /// 计算评分
        /// </summary>
        /// <returns></returns>
        public int computeScore()
        {
            int value = 0, score_value = 0, gcs_value = 0;
            if (txt_Age.Text != "")
                value = (double.Parse(txt_Age.Text) <= 44 ? 0 : 0) + (double.Parse(txt_Age.Text) >= 45 && double.Parse(txt_Age.Text) <= 54 ? 2 : 0) + (double.Parse(txt_Age.Text) >= 55 && double.Parse(txt_Age.Text) <= 64 ? 3 : 0) + (double.Parse(txt_Age.Text) >= 65 && double.Parse(txt_Age.Text) <= 74 ? 5 : 0) + (double.Parse(txt_Age.Text) >= 75 ? 6 : 0);
            if (txt_Temperature.Text != "")
                value = value + (Double.Parse(txt_Temperature.Text) >= 41 ? 4 : 0) + (Double.Parse(txt_Temperature.Text) >= 39 && Double.Parse(txt_Temperature.Text) <= 40.9 ? 3 : 0) + (Double.Parse(txt_Temperature.Text) >= 38.5 && Double.Parse(txt_Temperature.Text) <= 38.9 ? 1 : 0) + (Double.Parse(txt_Temperature.Text) >= 36 && Double.Parse(txt_Temperature.Text) <= 38.4 ? 0 : 0) + (Double.Parse(txt_Temperature.Text) >= 34 && Double.Parse(txt_Temperature.Text) <= 35.9 ? 1 : 0) + (Double.Parse(txt_Temperature.Text) >= 32 && Double.Parse(txt_Temperature.Text) <= 33.9 ? 2 : 0) + (Double.Parse(txt_Temperature.Text) >= 30 && Double.Parse(txt_Temperature.Text) <= 31.9 ? 3 : 0) + (Double.Parse(txt_Temperature.Text) <= 29.9 ? 4 : 0);
            if (txt_MAP.Text != "")
                value = value + (double.Parse(txt_MAP.Text) >= 160 ? 4 : 0) + (double.Parse(txt_MAP.Text) >= 130 && double.Parse(txt_MAP.Text) <= 159 ? 3 : 0) + (double.Parse(txt_MAP.Text) >= 110 && double.Parse(txt_MAP.Text) <= 129 ? 2 : 0) + (double.Parse(txt_MAP.Text) >= 70 && double.Parse(txt_MAP.Text) <= 109 ? 0 : 0) + (double.Parse(txt_MAP.Text) >= 50 && double.Parse(txt_MAP.Text) <= 69 ? 2 : 0) + (double.Parse(txt_MAP.Text) <= 49 ? 4 : 0);
            if (txt_HeartRate.Text != "")
                value = value + (double.Parse(txt_HeartRate.Text) >= 180 ? 4 : 0) + (double.Parse(txt_HeartRate.Text) >= 140 && double.Parse(txt_HeartRate.Text) <= 179 ? 3 : 0) + (double.Parse(txt_HeartRate.Text) >= 110 && double.Parse(txt_HeartRate.Text) <= 139 ? 2 : 0) + (double.Parse(txt_HeartRate.Text) >= 70 && double.Parse(txt_HeartRate.Text) <= 109 ? 0 : 0) + (double.Parse(txt_HeartRate.Text) >= 55 && double.Parse(txt_HeartRate.Text) <= 69 ? 2 : 0) + (double.Parse(txt_HeartRate.Text) >= 40 && double.Parse(txt_HeartRate.Text) <= 54 ? 3 : 0) + (double.Parse(txt_HeartRate.Text) <= 39 ? 4 : 0);
            if (txt_Breath.Text != "")
                value = value + (double.Parse(txt_Breath.Text) >= 50 ? 4 : 0) + (double.Parse(txt_Breath.Text) >= 35 && double.Parse(txt_Breath.Text) <= 49 ? 3 : 0) + (double.Parse(txt_Breath.Text) >= 25 && double.Parse(txt_Breath.Text) <= 34 ? 1 : 0) + (double.Parse(txt_Breath.Text) >= 12 && double.Parse(txt_Breath.Text) <= 24 ? 0 : 0) + (double.Parse(txt_Breath.Text) >= 10 && double.Parse(txt_Breath.Text) <= 11 ? 1 : 0) + (double.Parse(txt_Breath.Text) >= 6 && double.Parse(txt_Breath.Text) <= 9 ? 2 : 0) + (double.Parse(txt_Breath.Text) <= 5 ? 4 : 0);
            if (txt_aD02.Text != "" && txt_Fi92.Text != "")
                value = value + ((Double.Parse(txt_aD02.Text) >= 500 ? 4 : 0) + (Double.Parse(txt_aD02.Text) >= 350 && Double.Parse(txt_aD02.Text) <= 499 ? 3 : 0) + (Double.Parse(txt_aD02.Text) >= 200 && Double.Parse(txt_aD02.Text) <= 349 ? 2 : 0) + (Double.Parse(txt_aD02.Text) <= 200 ? 0 : 0)) * (Double.Parse(txt_Fi92.Text) >= 0.5 ? 1 : 0);
            if (txt_Pa02.Text != "" && txt_Fi92.Text != "")
                value = value + ((Double.Parse(txt_Pa02.Text) >= 70 ? 0 : 0) + (Double.Parse(txt_Pa02.Text) >= 61 && Double.Parse(txt_Pa02.Text) <= 70 ? 1 : 0) + (Double.Parse(txt_Pa02.Text) >= 55 && Double.Parse(txt_Pa02.Text) <= 60 ? 3 : 0) + (Double.Parse(txt_Pa02.Text) < 55 ? 4 : 0)) * (Double.Parse(txt_Fi92.Text) < 0.5 ? 1 : 0);
            if (txt_PH.Text != "")
                value = value + (Double.Parse(txt_PH.Text) >= 7.7 ? 4 : 0) + (Double.Parse(txt_PH.Text) >= 7.6 && Double.Parse(txt_PH.Text) <= 7.69 ? 3 : 0) + (Double.Parse(txt_PH.Text) >= 7.5 && Double.Parse(txt_PH.Text) <= 7.59 ? 1 : 0) + (Double.Parse(txt_PH.Text) >= 7.33 && Double.Parse(txt_PH.Text) <= 7.49 ? 3 : 0) + (Double.Parse(txt_PH.Text) >= 7.25 && Double.Parse(txt_PH.Text) <= 7.32 ? 2 : 0) + (Double.Parse(txt_PH.Text) >= 7.15 && Double.Parse(txt_PH.Text) <= 7.24 ? 3 : 0) + (Double.Parse(txt_PH.Text) < 7.15 ? 4 : 0);
            if (txt_Na.Text != "")
                value = value + (Double.Parse(txt_Na.Text) >= 180 ? 4 : 0) + (Double.Parse(txt_Na.Text) >= 160 && Double.Parse(txt_Na.Text) <= 179 ? 3 : 0) + (Double.Parse(txt_Na.Text) >= 155 && Double.Parse(txt_Na.Text) <= 159 ? 2 : 0) + (Double.Parse(txt_Na.Text) >= 150 && Double.Parse(txt_Na.Text) <= 154 ? 1 : 0) + (Double.Parse(txt_Na.Text) >= 130 && Double.Parse(txt_Na.Text) <= 149 ? 0 : 0) + (Double.Parse(txt_Na.Text) >= 120 && Double.Parse(txt_Na.Text) <= 129 ? 2 : 0) + (Double.Parse(txt_Na.Text) >= 111 && Double.Parse(txt_Na.Text) <= 119 ? 3 : 0) + (Double.Parse(txt_Na.Text) <= 111 ? 4 : 0);
            if (txt_K.Text != "")
                value = value + (Double.Parse(txt_K.Text) >= 7 ? 4 : 0) + (Double.Parse(txt_K.Text) >= 6 && Double.Parse(txt_K.Text) <= 6.9 ? 3 : 0) + (Double.Parse(txt_K.Text) >= 5.5 && Double.Parse(txt_K.Text) <= 5.9 ? 1 : 0) + (Double.Parse(txt_K.Text) >= 3.5 && Double.Parse(txt_K.Text) <= 5.4 ? 0 : 0) + (Double.Parse(txt_K.Text) >= 3 && Double.Parse(txt_K.Text) <= 3.4 ? 1 : 0) + (Double.Parse(txt_K.Text) >= 2.5 && Double.Parse(txt_K.Text) <= 2.9 ? 2 : 0) + (Double.Parse(txt_K.Text) < 2.5 ? 4 : 0);
            if (txt_Cr.Text != "")
                value = value + (checkBox1.Checked == true ? 2 : 1) * ((Double.Parse(txt_Cr.Text) >= 3.5 ? 4 : 0) + (Double.Parse(txt_Cr.Text) >= 2 && Double.Parse(txt_Cr.Text) <= 3.4 ? 3 : 0) + (Double.Parse(txt_Cr.Text) >= 1.5 && Double.Parse(txt_Cr.Text) <= 1.9 ? 2 : 0) + (Double.Parse(txt_Cr.Text) >= 0.6 && Double.Parse(txt_Cr.Text) <= 1.4 ? 0 : 0) + (Double.Parse(txt_Cr.Text) <= 0.6 ? 2 : 0));
            if (txt_HCT.Text != "")
                value = value + (Double.Parse(txt_HCT.Text) >= 60 ? 4 : 0) + (Double.Parse(txt_HCT.Text) >= 50 && Double.Parse(txt_HCT.Text) <= 59.9 ? 2 : 0) + (Double.Parse(txt_HCT.Text) >= 46 && Double.Parse(txt_HCT.Text) <= 49.9 ? 1 : 0) + (Double.Parse(txt_HCT.Text) >= 30 && Double.Parse(txt_HCT.Text) <= 45.9 ? 0 : 0) + (Double.Parse(txt_HCT.Text) >= 20 && Double.Parse(txt_HCT.Text) <= 29.9 ? 2 : 0) + (Double.Parse(txt_HCT.Text) < 20 ? 4 : 0);
            if (txt_WBC.Text != "")
                value = value + (Double.Parse(txt_WBC.Text) >= 40 ? 4 : 0) + (Double.Parse(txt_WBC.Text) >= 20 && Double.Parse(txt_WBC.Text) <= 39.9 ? 2 : 0) + (Double.Parse(txt_WBC.Text) >= 15 && Double.Parse(txt_WBC.Text) <= 19.9 ? 1 : 0) + (Double.Parse(txt_WBC.Text) >= 3 && Double.Parse(txt_WBC.Text) <= 14.9 ? 0 : 0) + (Double.Parse(txt_WBC.Text) >= 1 && Double.Parse(txt_WBC.Text) <= 2.9 ? 2 : 0) + (Double.Parse(txt_WBC.Text) < 1 ? 4 : 0);
            score_value = value + (radio_select.Checked == true ? 2 : 0) + (radio_NoSelect.Checked == true ? 5 : 0);
            if (comb_EyeOpen.SelectedIndex == 0)
                value = 4;
            else if (comb_EyeOpen.SelectedIndex == 1)
                value = 3;
            else if (comb_EyeOpen.SelectedIndex == 2)
                value = 2;
            else if (comb_EyeOpen.SelectedIndex == 3)
                value = 1;
            gcs_value = gcs_value + value;
            if (comb_language.SelectedIndex == 0)
                value = 5;
            else if (comb_language.SelectedIndex == 1)
                value = 4;
            else if (comb_language.SelectedIndex == 2)
                value = 3;
            else if (comb_language.SelectedIndex == 3)
                value = 2;
            else if (comb_language.SelectedIndex == 4)
                value = 1;
            gcs_value = gcs_value + value;
            if (comb_Body.SelectedIndex == 0)
                value = 6;
            else if (comb_Body.SelectedIndex == 1)
                value = 5;
            else if (comb_Body.SelectedIndex == 2)
                value = 4;
            else if (comb_Body.SelectedIndex == 3)
                value = 3;
            else if (comb_Body.SelectedIndex == 4)
                value = 2;
            else if (comb_Body.SelectedIndex == 5)
                value = 1;
            gcs_value = gcs_value + value;
            score_value = score_value + (15 - gcs_value);

            double logit, temp, deadRate = 0;
            if (score_value > 0)
            {
                logit = (-3.517 + score_value * 0.146);
                //if (DataOperator.HospitalID == HospitalIDList.DNDXFSZDYY)
                //{
                //    if (cbxNoOper.EditValue != null)
                //    {
                //        logit = logit + double.Parse(cbxNoOper.EditValue.ToString());
                //    }
                //    else if (cbxAfterOper.EditValue != null)
                //    {
                //        logit = logit + double.Parse(cbxAfterOper.EditValue.ToString());
                //    }
                //    if (cbxJiZheng.Checked)
                //    {
                //        logit = logit + 0.603;
                //    }
                //}
                temp = Math.Exp(logit);
                deadRate = Math.Round(temp / (1 + temp), 4);
                deadRate = Math.Round(deadRate * 100, 2);
            }
            txtDeathRate.Text = deadRate.ToString();
            txtScore.Text = score_value.ToString();
            return score_value;
        }

        /// <summary>
        /// 取得睁眼反应数据
        /// </summary>
        /// <returns></returns>
        private int getEyeOpenValue()
        {
            int value = 0;
            if (comb_EyeOpen.SelectedIndex == 0)
                value = 4;
            else if (comb_EyeOpen.SelectedIndex == 1)
                value = 3;
            else if (comb_EyeOpen.SelectedIndex == 2)
                value = 2;
            else if (comb_EyeOpen.SelectedIndex == 3)
                value = 1;
            return value;
        }

        /// <summary>
        /// 取得言语反应数据
        /// </summary>
        /// <returns></returns>
        private int getLanguageValue()
        {
            int value = 0;
            if (comb_language.SelectedIndex == 0)
                value = 5;
            else if (comb_language.SelectedIndex == 1)
                value = 4;
            else if (comb_language.SelectedIndex == 2)
                value = 3;
            else if (comb_language.SelectedIndex == 3)
                value = 2;
            else if (comb_language.SelectedIndex == 4)
                value = 1;
            return value;
        }

        /// <summary>
        /// 取得肢体反应数据
        /// </summary>
        /// <returns></returns>
        private int getBodyValue()
        {
            int value = 0;
            if (comb_Body.SelectedIndex == 0)
                value = 6;
            else if (comb_Body.SelectedIndex == 1)
                value = 5;
            else if (comb_Body.SelectedIndex == 2)
                value = 4;
            else if (comb_Body.SelectedIndex == 3)
                value = 3;
            else if (comb_Body.SelectedIndex == 4)
                value = 2;
            else if (comb_Body.SelectedIndex == 5)
                value = 1;
            return value;
        }

        /// <summary>
        /// 取得睁眼反应索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getEyeOpenIndex(int value)
        {
            int index = 0;
            if (value == 4)
                index = 0;
            else if (value == 3)
                index = 1;
            else if (value == 2)
                index = 2;
            else if (value == 1)
                index = 3;
            return index;
        }

        /// <summary>
        /// 取得言语反应索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getLanguageIndex(int value)
        {
            int index = 0;
            if (value == 5)
                index = 0;
            else if (value == 4)
                index = 1;
            else if (value == 3)
                index = 2;
            else if (value == 2)
                index = 3;
            else if (value == 1)
                index = 4;
            return index;
        }

        /// <summary>
        /// 取得肢体反应索引
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private int getBodyIndex(int value)
        {
            int index = 0;
            if (value == 6)
                index = 0;
            else if (value == 5)
                index = 1;
            else if (value == 4)
                index = 2;
            else if (value == 3)
                index = 3;
            else if (value == 2)
                index = 4;
            else if (value == 1)
                index = 5;
            return index;
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="text"></param>
        /// <param name="columnName"></param>
        private void setValue(Com.MedicalSystem.Icu.DataSetModel.Score.Apache2ScoringResultDetailRow row, string text, string columnName)
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
            row[columnName] = value;
        }

        /// <summary>
        /// 保存评分结果
        /// </summary>
        /// <returns></returns>
        private int saveScoreResult()
        {
            if (txtDeathRate.Text == "" || txtScore.Text == "")
            {
                return -1;
            }
            string operatorNurse = DataOperator.Operator;
            if (operatorNurse == null) return -1;

            if (appcheScore == null)
            {
                appcheScore = new List<MED_PATIENT_SCORING_RESULT>();
            }

            double deatnRates = double.Parse(txtDeathRate.Text) / 100;
            deatnRates = Math.Round(deatnRates, 4);

            appcheScore.Add(new MED_PATIENT_SCORING_RESULT()
            {
                PATIENT_ID = _patientID,
                VISIT_ID = (int)_visitID,
                DEP_ID = (int)_deptID,

                SCORING_DATE_TIME = scoreDateTime,
                SCORING_METHOD = "apache2",
                SCORING_VALUE = int.Parse(txtScore.Text),
                DEATH_PROBABILITY = (decimal)deatnRates,
                PAT_CONDITION = tex_DescriptionIllness.Text,
                OPERATOR = operatorNurse
            });


            if (DataOperator.UpdatePatientScoringResult(appcheScore) >= 0)
            {
                //if (DataOperator.HospitalID == HospitalIDList.GZZHONGLIU)
                //{
                //    DataSetModel.CareItems.PatientNursingRecDateDataTable patientnm = DataOperator.GetPatientNursingInfo
                //        (_patientID,_visitID,_deptID, DateTime.Now, DateTime.Now);
                //    DataSetModel.CareItems.PatientNursingRecDateRow PNMRow = patientnm.NewPatientNursingRecDateRow();
                //    PNMRow.PATIENT_ID = _patientID;
                //    PNMRow.VISIT_ID = _visitID;
                //    PNMRow.RECORDING_DATE = DateTime.Parse(DateTime.Now.ToShortDateString());
                //    PNMRow.TIME_POINT = DateTime.Now;
                //    PNMRow.ORDER_NO = "0";
                //    PNMRow.NURSING_TYPE = "未定义";
                //    PNMRow.NURSING_DESC = "APACHE Ⅱ评分  评分时间:" + scoreDateTime.ToString() + ", 得分:" + txtScore.Text +
                //        ", 死亡率:" + deatnRates + ", 病情描述:" + tex_DescriptionIllness.Text + ",评分人:" + DataOperator.OperatorNurse;
                //    PNMRow.NURSE_IN_OPERATE = DataOperator.OperatorNurse;
                //    PNMRow.LOG_DATE_TIME = DateTime.Now;
                //    patientnm.Rows.Add(PNMRow);
                //    DataOperator.UpdatePatientNursingRec(patientnm);
                //}

                return 1;
            }
            else
            {
                Dialog.MessageBox("保存失败！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
        }
        private void Clear()
        {

            txtDeathRate.Text = "";
            txtScore.Text = "";
            txt_Age.Text = "";
            txt_HeartRate.Text = "";
            txt_MAP.Text = "";
            txt_Breath.Text = "";
            txt_Temperature.Text = "";
            txt_aD02.Text = "";
            txt_Pa02.Text = "";
            txt_Fi92.Text = "";
            txt_PH.Text = "";
            txt_HCT.Text = "";
            txt_WBC.Text = "";
            txt_K.Text = "";
            txt_Na.Text = "";
            txt_Cr.Text = "";
            comb_EyeOpen.SelectedIndex = -1;
            comb_language.SelectedIndex = -1;
            comb_Body.SelectedIndex = -1;
            tex_DescriptionIllness.Text = "";
            checkBox1.Checked = false;
            radio_select.Checked = false;
            radio_NoSelect.Checked = false;
        }
        /// <summary>
        /// 保存评分明细选项
        /// </summary>
        /// <returns></returns>
        private int saveDetailSap()
        {
            if (txtDeathRate.Text == "" || txtScore.Text == "")
            {
                Dialog.MessageBox("请先评分，再保存！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            scoreDateTime = DataOperator.GetSysDate();

            List<MED_APACHE2_SCORING_RESULT> detailTable = new List<MED_APACHE2_SCORING_RESULT>();

            MED_APACHE2_SCORING_RESULT row = new MED_APACHE2_SCORING_RESULT();

            row.PATIENT_ID = _patientID;
            row.VISIT_ID = (int)_visitID;
            row.DEP_ID = (int)_deptID;

            row.SCORING_DATE_TIME = scoreDateTime;
            if (!string.IsNullOrEmpty(txt_Age.Text))
            {
                row.AGE = int.Parse(txt_Age.Text);
            }

            if (!string.IsNullOrEmpty(txt_HeartRate.Text))
            {
                row.HR = int.Parse(txt_HeartRate.Text);
            }

            if (!string.IsNullOrEmpty(txt_MAP.Text))
            {
                row.MAP = int.Parse(txt_MAP.Text);
            }

            if (!string.IsNullOrEmpty(txt_Breath.Text))
            {
                row.BR = int.Parse(txt_Breath.Text);
            }

            if (!string.IsNullOrEmpty(txt_Temperature.Text))
            {
                row.TMP = int.Parse(txt_Temperature.Text);
            }

            if (!string.IsNullOrEmpty(txt_aD02.Text))
            {
                row.AADO2 = int.Parse(txt_aD02.Text);
            }

            if (!string.IsNullOrEmpty(txt_Pa02.Text))
            {
                row.PAO2 = int.Parse(txt_Pa02.Text);
            }

            if (!string.IsNullOrEmpty(txt_Fi92.Text))
            {
                row.FIO2 = int.Parse(txt_Fi92.Text);
            }

            if (!string.IsNullOrEmpty(txt_PH.Text))
            {
                row.PH = int.Parse(txt_PH.Text);
            }

            if (!string.IsNullOrEmpty(txt_HCT.Text))
            {
                row.HCT = int.Parse(txt_HCT.Text);
            }

            if (!string.IsNullOrEmpty(txt_WBC.Text))
            {
                row.WBC = int.Parse(txt_WBC.Text);
            }

            if (!string.IsNullOrEmpty(txt_K.Text))
            {
                row.K = int.Parse(txt_K.Text);
            }

            if (!string.IsNullOrEmpty(txt_Na.Text))
            {
                row.NA = int.Parse(txt_Na.Text);
            }

            if (!string.IsNullOrEmpty(txt_Cr.Text))
            {
                row.CR = int.Parse(txt_Cr.Text);
            }

            row.NO_OPER_PAT = cbxNoOper.SelectedText;
            row.AFTER_OPER_PAT = cbxAfterOper.SelectedText;

            row.EYES_REFLECT = getEyeOpenValue();
            row.TALK_REFLECT = getLanguageValue();
            row.LIMB_REFLECT = getBodyValue();
            row.MEMO = tex_DescriptionIllness.Text;

            if (checkBox1.Checked == true)
            {
                row.KEY_INDICATOR = 1;
            }

            if (cbxJiZheng.Checked == true)
            {
                row.JI_ZHEN_OPER = 1;
            }

            if (radio_select.Checked == true)
            {
                row.HEALTH_STATUS = 2;
            }
            else if (radio_NoSelect.Checked == true)
            {
                row.HEALTH_STATUS = 5;
            }

            detailTable.Add(row);

            if (DataOperator.UpdateApache2ScoringResult(detailTable) >= 0)
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
        /// 取得对应逻辑值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool getBoolValue(object value)
        {
            try
            {
                if (double.Parse(value.ToString()) == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="deTable"></param>
        private void pushValue(List<MED_APACHE2_SCORING_RESULT> deTable)
        {
            txt_Age.Text = deTable[0].AGE.ToString();
            txt_HeartRate.Text = deTable[0].HR.ToString();
            txt_MAP.Text = deTable[0].MAP.ToString();
            txt_Breath.Text = deTable[0].BR.ToString();
            txt_Temperature.Text = deTable[0].TMP.ToString();
            txt_aD02.Text = deTable[0].AADO2.ToString();
            txt_Pa02.Text = deTable[0].PAO2.ToString();
            txt_Fi92.Text = deTable[0].FIO2.ToString();
            txt_PH.Text = deTable[0].PH.ToString();
            txt_HCT.Text = deTable[0].HCT.ToString();
            txt_WBC.Text = deTable[0].WBC.ToString();
            txt_K.Text = deTable[0].K.ToString();
            txt_Na.Text = deTable[0].NA.ToString();
            txt_Cr.Text = deTable[0].CR.ToString();
            double death = dgvApache.SelectedRows[0].Cells["deathRate"].Value == null ? 0 : double.Parse(dgvApache.SelectedRows[0].Cells["deathRate"].Value.ToString()) * 100;
            txtDeathRate.Text = death.ToString();
            txtScore.Text = dgvApache.SelectedRows[0].Cells["SCORING_VALUE"].Value == null ? "" : dgvApache.SelectedRows[0].Cells["SCORING_VALUE"].Value.ToString();
            comb_EyeOpen.SelectedIndex = getEyeOpenIndex(int.Parse(deTable[0].EYES_REFLECT.ToString().Trim()));
            comb_language.SelectedIndex = getLanguageIndex(int.Parse(deTable[0].TALK_REFLECT.ToString().Trim()));
            comb_Body.SelectedIndex = getBodyIndex(int.Parse(deTable[0].LIMB_REFLECT.ToString().Trim()));
            tex_DescriptionIllness.Text = deTable[0].MEMO.ToString();
            checkBox1.Checked = getBoolValue(deTable[0].KEY_INDICATOR);
            if (deTable[0].HEALTH_STATUS.ToString().Trim() != "")
            {
                if (double.Parse(deTable[0].HEALTH_STATUS.ToString().Trim()) == 2)
                    radio_select.Checked = true;
                if (double.Parse(deTable[0].HEALTH_STATUS.ToString().Trim()) == 5)
                    radio_NoSelect.Checked = true;
            }
            cbxJiZheng.Checked = getBoolValue(deTable[0].JI_ZHEN_OPER);
            cbxNoOper.Text = deTable[0].NO_OPER_PAT == null ? "" : deTable[0].NO_OPER_PAT.ToString();
            cbxAfterOper.Text = deTable[0].AFTER_OPER_PAT == null ? "" : deTable[0].AFTER_OPER_PAT.ToString();
        }

        /// <summary>
        /// 获取dataGirdView选中行索引
        /// </summary>
        /// <returns></returns>
        private int findMainTableIndex()
        {
            int deleteBeforeSelect = 0, exsitRow = 0, index;
            for (int i = 0; i < appcheScore.Count; i++)
            {
                if (appcheScore[i].ModelStatus == ModelStatus.Deleted)
                    deleteBeforeSelect++;
                else
                    exsitRow++;
                if (exsitRow >= dgvApache.SelectedRows[0].Index + 1)
                    break;
            }
            for (index = dgvApache.SelectedRows[0].Index + deleteBeforeSelect; index < appcheScore.Count; index++)
            {
                if (appcheScore[index].ModelStatus == ModelStatus.Deleted)
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
            for (int rowNo = 0; rowNo < apache2Score.Count; rowNo++)
            {
                if (apache2Score[rowNo].ModelStatus != ModelStatus.Deleted)
                {
                    if (apache2Score[rowNo].SCORING_DATE_TIME.ToString() == appcheScore[findMainTableIndex()].SCORING_DATE_TIME.ToString())
                        return rowNo;
                }
            }
            return -1;
        }

        #endregion 方法

        #region 控件事件

        /// <summary>
        /// APACHEII评分控件加载事件
        /// </summary>
        /// <param name="sender">APACHEII评分控件</param>
        /// <param name="e">事件参数</param>
        private void UserControlAPACHEII_Load(object sender, EventArgs e)
        {
            this.btnExtraction.Visible = false;
            //nameConvertCollection = (System.Collections.Specialized.NameValueCollection)System.Configuration.ConfigurationManager.GetSection("FlowConfig/SignCodes");
            SetGraphParameters();
            bindToDataGrid();
            RefreshGraph();
        }

        private void initTable()
        {
            panel2.Visible = true;
            DataColumn content = new DataColumn("content");
            DataColumn value = new DataColumn("value");
            noOper.Columns.Add(content);
            noOper.Columns.Add(value);
            afterOper = noOper.Copy();

            noOper.Rows.Add(new string[] { "", "0" });
            noOper.Rows.Add(new string[] { "哮喘/过敏症", "-2.108" });
            noOper.Rows.Add(new string[] { "COPD", "-0.367" });
            noOper.Rows.Add(new string[] { "非心源性肺水肿", "-0.251" });
            noOper.Rows.Add(new string[] { "呼吸暂停", "-0.168" });
            noOper.Rows.Add(new string[] { "误吸/中毒/毒性反应", "-0.142" });
            noOper.Rows.Add(new string[] { "肺栓塞", "-0.128" });
            noOper.Rows.Add(new string[] { "肿瘤", "0.891" });
            noOper.Rows.Add(new string[] { "高血压", "-1.798" });
            noOper.Rows.Add(new string[] { "心律失常", "-1.368" });
            noOper.Rows.Add(new string[] { "充血性心衰", "-0.424" });
            noOper.Rows.Add(new string[] { "出血性休克/低血容量", "0.493" });
            noOper.Rows.Add(new string[] { "冠状动脉疾病", "-0.191" });
            noOper.Rows.Add(new string[] { "全身感染", "0.113" });
            noOper.Rows.Add(new string[] { "心跳骤停", "0.393" });
            noOper.Rows.Add(new string[] { "心源性休克", "-0.259" });
            noOper.Rows.Add(new string[] { "胸/腹主动脉瘤破裂", "0.731" });
            noOper.Rows.Add(new string[] { "多发伤", "-1.228" });
            noOper.Rows.Add(new string[] { "头部创伤", "0.517" });
            noOper.Rows.Add(new string[] { "癫痫病", "-0.584" });
            noOper.Rows.Add(new string[] { "颅内出血/硬膜下腔出血/蛛网膜下腔出血", "0.732" });
            noOper.Rows.Add(new string[] { "药物过量", "-3.353" });
            noOper.Rows.Add(new string[] { "糖尿病酮症酸中毒", "-1.507" });
            noOper.Rows.Add(new string[] { "消化道出血", "0.334" });
            noOper.Rows.Add(new string[] { "代谢/肾脏", "-0.885" });
            noOper.Rows.Add(new string[] { "呼吸系统", "0.890" });
            noOper.Rows.Add(new string[] { "神经系统", "-0.759" });
            noOper.Rows.Add(new string[] { "心血管系统", "0.470" });
            noOper.Rows.Add(new string[] { "胃肠道", "-0.501" });

            cbxNoOper.Properties.Columns.Clear();
            foreach (DataColumn column in noOper.Columns)
            {
                LookUpColumnInfo lookUpColumnInfo = new LookUpColumnInfo(column.ColumnName, string.Empty);
                cbxNoOper.Properties.Columns.Add(lookUpColumnInfo);
                if (column.ColumnName != "content")
                    lookUpColumnInfo.Visible = false;
            }

            cbxNoOper.Properties.DataSource = noOper;
            cbxNoOper.Properties.DisplayMember = "content";
            cbxNoOper.Properties.ValueMember = "value";
            cbxNoOper.Properties.NullText = string.Empty;
            cbxNoOper.Properties.ShowHeader = false;


            afterOper.Rows.Add(new string[] { "", "0" });
            afterOper.Rows.Add(new string[] { "多发伤", "-1.684" });
            afterOper.Rows.Add(new string[] { "因慢性心血管疾病住ICU", "-1.376" });
            afterOper.Rows.Add(new string[] { "外周血管手术", "-1.315" });
            afterOper.Rows.Add(new string[] { "心脏瓣膜手术", "-1.261" });
            afterOper.Rows.Add(new string[] { "颅内肿瘤手术", "-1.245" });
            afterOper.Rows.Add(new string[] { "肾脏肿瘤手术", "-1.204" });
            afterOper.Rows.Add(new string[] { "肾移植术", "-1.042" });
            afterOper.Rows.Add(new string[] { "颅脑外伤手术", "-0.955" });
            afterOper.Rows.Add(new string[] { "胸腔肿瘤手术", "-0.802" });
            afterOper.Rows.Add(new string[] { "颅内出血/硬膜下腔出血/蛛网膜下腔出血", "-0.788" });
            afterOper.Rows.Add(new string[] { "椎板切除手术及其它脊髓手术", "-0.699" });
            afterOper.Rows.Add(new string[] { "出血性休克", "-0.682" });
            afterOper.Rows.Add(new string[] { "胃肠道出血", "-0.617" });
            afterOper.Rows.Add(new string[] { "胃肠道肿瘤手术", "-0.248" });
            afterOper.Rows.Add(new string[] { "手术后呼吸功能不全", "-0.140" });
            afterOper.Rows.Add(new string[] { "胃肠道穿孔/梗阻", "0.060" });

            cbxAfterOper.Properties.Columns.Clear();
            foreach (DataColumn column in afterOper.Columns)
            {
                LookUpColumnInfo lookUpColumnInfo = new LookUpColumnInfo(column.ColumnName, string.Empty);
                cbxAfterOper.Properties.Columns.Add(lookUpColumnInfo);
                if (column.ColumnName != "content")
                    lookUpColumnInfo.Visible = false;
            }

            cbxAfterOper.Properties.DataSource = afterOper;
            cbxAfterOper.Properties.DisplayMember = "content";
            cbxAfterOper.Properties.ValueMember = "value";
            cbxAfterOper.Properties.NullText = string.Empty;
            cbxAfterOper.Properties.ShowHeader = false;

        }

        /// <summary>
        /// 点击删除按钮事件
        /// </summary>
        /// <param name="sender">删除按钮</param>
        /// <param name="e">事件参数</param>
        private void btn_dele_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvApache.Rows.Count > 0 && dgvApache.SelectedRows != null)
                {
                    var row = apache2Score[quaryIndex()];
                    row.ModelStatus = ModelStatus.Deleted;

                    var row2 = appcheScore[findMainTableIndex()];
                    row2.ModelStatus = ModelStatus.Deleted;

                    RefreshGraph();

                    if (dgvApache.Rows.Count > 0)
                    {
                        dgvApache.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 点击保存按钮事件
        /// </summary>
        /// <param name="sender">保存按钮</param>
        /// <param name="e">事件参数</param>
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
                Dialog.MessageBox("保存成功！", "麻醉信息工作站", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindToDataGrid();
            }
        }

        /// <summary>
        /// 点击评分按钮事件
        /// </summary>
        /// <param name="sender">评分按钮</param>
        /// <param name="e">事件参数</param>
        private void btnScore_Click(object sender, EventArgs e)
        {
            comb_Value_Validated(sender, e);
            if (errorIndex == 1)
                return;
            computeScore();
        }

        /// <summary>
        /// 点击清除按钮事件
        /// </summary>
        /// <param name="sender">清除按钮</param>
        /// <param name="e">事件参数</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// 单击表格单元格内容事件
        /// </summary>
        /// <param name="sender">表格</param>
        /// <param name="e">事件参数</param>
        private void dgvApache_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            List<MED_APACHE2_SCORING_RESULT> detailTable;
            detailTable = DataOperator.GetApache2ScoringResultDt(_patientID, _visitID, _deptID,
                (DateTime)dgvApache.Rows[e.RowIndex].Cells[0].Value);
            btnReset_Click(sender, e);
            pushValue(detailTable);
        }



        private void btnSaveScore_Click(object sender, EventArgs e)
        {
            if (DataOperator.UpdatePatientScoringResult(appcheScore) >= 0)
            {
                if (DataOperator.UpdateApache2ScoringResult(apache2Score) >= 0)
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
        /// <summary>
        /// 提取信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtExtraction_Click(object sender, EventArgs e)
        {
            //setVital_lab_Value();
        }

        private void radio_select_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_select.Checked)
            {
                radio_NoSelect.Checked = false;
            }
        }

        private void radio_NoSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_NoSelect.Checked)
            {
                radio_select.Checked = false;
            }
        }
        #endregion 控件事件

        #region 获取生命体征-检验信息方法
        private void setVital_lab_Value()
        {
            Clear();
            //获取生命体征信息
            int Values;
            double firstScore, lastScore;
            careItemsDateTable = new Com.MedicalSystem.Icu.DataSetModel.CareItems.VitalSignsRecLifeDataTable();
            string HeartRate = "心率";
            string MAP = "血压high";
            string Breath = "呼吸";
            string Temperature = "体温";
            string FiO2 = getListName("FIO2");
            //if (!PatientRow.IsDATE_OF_BIRTHNull())
            //{
            //    txt_Age.Text = (DateTime.Now.Year - PatientRow.DATE_OF_BIRTH.Year).ToString();
            //}
            startTime = dateTimePicker1.DateTime.Date;
            endTime = startTime.AddDays(1).AddSeconds(-1);
            //if (DataOperator.HospitalID == HospitalIDList.DNDXFSZDYY)
            //{
            //    careItemsDateTable = DataOperator.GetSignsRecLife(_patientID, _visitID, _deptID, startTime, endTime);
            //    //获取心率 取数值最大的或最小的（哪个数值得分最大取哪个）
            //    careItemsDateTable.DefaultView.RowFilter = "VITAL_SIGNS='心率'";
            //    careItemsDateTable.DefaultView.Sort = "VITAL_SIGNS_VALUES";
            //    if (careItemsDateTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = careItemsDateTable.DefaultView[0]["VITAL_SIGNS_VALUES"].ToString();
            //        string lastValue = careItemsDateTable.DefaultView[careItemsDateTable.DefaultView.Count - 1]["VITAL_SIGNS_VALUES"].ToString();
            //        firstScore = (double.Parse(firstValue) >= 180 ? 4 : 0) + (double.Parse(firstValue) >= 140 && double.Parse(firstValue) <= 179 ? 3 : 0) + (double.Parse(firstValue) >= 110 && double.Parse(firstValue) <= 139 ? 2 : 0) + (double.Parse(firstValue) >= 70 && double.Parse(firstValue) <= 109 ? 0 : 0) + (double.Parse(firstValue) >= 55 && double.Parse(firstValue) <= 69 ? 2 : 0) + (double.Parse(firstValue) >= 40 && double.Parse(firstValue) <= 54 ? 3 : 0) + (double.Parse(firstValue) <= 39 ? 4 : 0);
            //        lastScore = (double.Parse(lastValue) >= 180 ? 4 : 0) + (double.Parse(lastValue) >= 140 && double.Parse(lastValue) <= 179 ? 3 : 0) + (double.Parse(lastValue) >= 110 && double.Parse(lastValue) <= 139 ? 2 : 0) + (double.Parse(lastValue) >= 70 && double.Parse(lastValue) <= 109 ? 0 : 0) + (double.Parse(lastValue) >= 55 && double.Parse(lastValue) <= 69 ? 2 : 0) + (double.Parse(lastValue) >= 40 && double.Parse(lastValue) <= 54 ? 3 : 0) + (double.Parse(lastValue) <= 39 ? 4 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_HeartRate.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_HeartRate.Text = firstValue.ToString();
            //        }
            //    }

            //    //获取平均动脉压
            //    careItemsDateTable.DefaultView.RowFilter = "VITAL_SIGNS='血压high'";
            //    careItemsDateTable.DefaultView.Sort = "VITAL_SIGNS_VALUES";
            //    if (careItemsDateTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = careItemsDateTable.DefaultView[0]["VITAL_SIGNS_VALUES"].ToString();
            //        string lastValue = careItemsDateTable.DefaultView[careItemsDateTable.DefaultView.Count - 1]["VITAL_SIGNS_VALUES"].ToString();
            //        firstScore = (double.Parse(firstValue) >= 160 ? 4 : 0) + (double.Parse(firstValue) >= 130 && double.Parse(firstValue) <= 159 ? 3 : 0) + (double.Parse(firstValue) >= 110 && double.Parse(firstValue) <= 129 ? 2 : 0) + (double.Parse(firstValue) >= 70 && double.Parse(firstValue) <= 109 ? 0 : 0) + (double.Parse(firstValue) >= 50 && double.Parse(firstValue) <= 69 ? 2 : 0) + (double.Parse(firstValue) <= 49 ? 4 : 0);
            //        lastScore = (double.Parse(lastValue) >= 160 ? 4 : 0) + (double.Parse(lastValue) >= 130 && double.Parse(lastValue) <= 159 ? 3 : 0) + (double.Parse(lastValue) >= 110 && double.Parse(lastValue) <= 129 ? 2 : 0) + (double.Parse(lastValue) >= 70 && double.Parse(lastValue) <= 109 ? 0 : 0) + (double.Parse(lastValue) >= 50 && double.Parse(lastValue) <= 69 ? 2 : 0) + (double.Parse(lastValue) <= 49 ? 4 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_MAP.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_MAP.Text = firstValue.ToString();
            //        }
            //    }

            //    //获取呼吸频率
            //    careItemsDateTable.DefaultView.RowFilter = "VITAL_SIGNS='呼吸'";
            //    careItemsDateTable.DefaultView.Sort = "VITAL_SIGNS_VALUES";
            //    if (careItemsDateTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = careItemsDateTable.DefaultView[0]["VITAL_SIGNS_VALUES"].ToString();
            //        string lastValue = careItemsDateTable.DefaultView[careItemsDateTable.DefaultView.Count - 1]["VITAL_SIGNS_VALUES"].ToString();
            //        firstScore = (double.Parse(firstValue) >= 50 ? 4 : 0) + (double.Parse(firstValue) >= 35 && double.Parse(firstValue) <= 49 ? 3 : 0) + (double.Parse(firstValue) >= 25 && double.Parse(firstValue) <= 34 ? 1 : 0) + (double.Parse(firstValue) >= 12 && double.Parse(firstValue) <= 24 ? 0 : 0) + (double.Parse(firstValue) >= 10 && double.Parse(firstValue) <= 11 ? 1 : 0) + (double.Parse(firstValue) >= 6 && double.Parse(firstValue) <= 9 ? 2 : 0) + (double.Parse(firstValue) <= 5 ? 4 : 0);
            //        lastScore = (double.Parse(lastValue) >= 50 ? 4 : 0) + (double.Parse(lastValue) >= 35 && double.Parse(lastValue) <= 49 ? 3 : 0) + (double.Parse(lastValue) >= 25 && double.Parse(lastValue) <= 34 ? 1 : 0) + (double.Parse(lastValue) >= 12 && double.Parse(lastValue) <= 24 ? 0 : 0) + (double.Parse(lastValue) >= 10 && double.Parse(lastValue) <= 11 ? 1 : 0) + (double.Parse(lastValue) >= 6 && double.Parse(lastValue) <= 9 ? 2 : 0) + (double.Parse(lastValue) <= 5 ? 4 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_Breath.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_Breath.Text = firstValue.ToString();
            //        }
            //    }

            //    //获取体温
            //    careItemsDateTable.DefaultView.RowFilter = "VITAL_SIGNS='体温'";
            //    careItemsDateTable.DefaultView.Sort = "VITAL_SIGNS_VALUES";
            //    if (careItemsDateTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = careItemsDateTable.DefaultView[0]["VITAL_SIGNS_VALUES"].ToString();
            //        string lastValue = careItemsDateTable.DefaultView[careItemsDateTable.DefaultView.Count - 1]["VITAL_SIGNS_VALUES"].ToString();
            //        firstScore = (Double.Parse(firstValue) >= 41 ? 4 : 0) + (Double.Parse(firstValue) >= 39 && Double.Parse(firstValue) <= 40.9 ? 3 : 0) + (Double.Parse(firstValue) >= 38.5 && Double.Parse(firstValue) <= 38.9 ? 1 : 0) + (Double.Parse(firstValue) >= 36 && Double.Parse(firstValue) <= 38.4 ? 0 : 0) + (Double.Parse(firstValue) >= 34 && Double.Parse(firstValue) <= 35.9 ? 1 : 0) + (Double.Parse(firstValue) >= 32 && Double.Parse(firstValue) <= 33.9 ? 2 : 0) + (Double.Parse(firstValue) >= 30 && Double.Parse(firstValue) <= 31.9 ? 3 : 0) + (Double.Parse(firstValue) <= 29.9 ? 4 : 0);
            //        lastScore = (Double.Parse(lastValue) >= 41 ? 4 : 0) + (Double.Parse(lastValue) >= 39 && Double.Parse(lastValue) <= 40.9 ? 3 : 0) + (Double.Parse(lastValue) >= 38.5 && Double.Parse(lastValue) <= 38.9 ? 1 : 0) + (Double.Parse(lastValue) >= 36 && Double.Parse(lastValue) <= 38.4 ? 0 : 0) + (Double.Parse(lastValue) >= 34 && Double.Parse(lastValue) <= 35.9 ? 1 : 0) + (Double.Parse(lastValue) >= 32 && Double.Parse(lastValue) <= 33.9 ? 2 : 0) + (Double.Parse(lastValue) >= 30 && Double.Parse(lastValue) <= 31.9 ? 3 : 0) + (Double.Parse(lastValue) <= 29.9 ? 4 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_Temperature.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_Temperature.Text = firstValue.ToString();
            //        }
            //    }

            //    //获取Fio2
            //    //careItemsDateTable.DefaultView.RowFilter = "VITAL_SIGNS='FiO2'";
            //    //careItemsDateTable.DefaultView.Sort = "VITAL_SIGNS_VALUES";
            //    //if (careItemsDateTable.DefaultView.Count > 0)
            //    //{
            //    //    txt_Fi92.Text = careItemsDateTable.DefaultView[0]["VITAL_SIGNS_VALUES"].ToString();
            //    //    if (double.Parse(careItemsDateTable.DefaultView[0]["VITAL_SIGNS_VALUES"].ToString()) >= 0.5)
            //    //    {
            //    //        careItemsDateTable.DefaultView.RowFilter = "VITAL_SIGNS='aDO2'";
            //    //        careItemsDateTable.DefaultView.Sort = "VITAL_SIGNS_VALUES desc";
            //    //        if (careItemsDateTable.DefaultView.Count > 0)
            //    //        {
            //    //            txt_aD02.Text = careItemsDateTable.DefaultView[0]["VITAL_SIGNS_VALUES"].ToString();
            //    //        }
            //    //    }
            //    //    else
            //    //    {
            //    //        careItemsDateTable.DefaultView.RowFilter = "VITAL_SIGNS='PaO2'";
            //    //        careItemsDateTable.DefaultView.Sort = "VITAL_SIGNS_VALUES desc";
            //    //        if (careItemsDateTable.DefaultView.Count > 0)
            //    //        {
            //    //            txt_Pa02.Text = careItemsDateTable.DefaultView[0]["VITAL_SIGNS_VALUES"].ToString();
            //    //        }
            //    //    }
            //    //}

            //    //提取检验
            //    AssayTable = DataOperator.GetAssayReportByDate(_patientID, _visitID, startTime, endTime);
            //    if (AssayTable.Count == 0)
            //    {
            //        AssayTable = DataOperator.GetAssayReportByDate(_patientID, _visitID, startTime, endTime.AddDays(-1));
            //    }
            //    double max;
            //    string convertName = "";

            //    AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("FIO2") + "'";
            //    if (AssayTable.DefaultView.Count > 0)
            //    {
            //        //string firstValue = AssayTable.DefaultView[0]["RESULT"].ToString();
            //        //string lastValue = AssayTable.DefaultView[AssayTable.DefaultView.Count - 1]["RESULT"].ToString();
            //        txt_Fi92.Text = AssayTable.DefaultView[0]["RESULT"].ToString();
            //    }
            //    //    if (double.Parse(AssayTable.DefaultView[0]["RESULT"].ToString()) >= 0.5)
            //    //    {
            //    //        AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("aDO2") + "'";
            //    //        max = quaryMaxValue(AssayTable.DefaultView, "RESULT");
            //    //        if (careItemsDateTable.DefaultView.Count > 0)
            //    //        {
            //    //            txt_aD02.Text = max.ToString();
            //    //        }
            //    //    }
            //    //    else
            //    //    {
            //    //        AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("PaO2") + "'";
            //    //        max = quaryMaxValue(AssayTable.DefaultView, "RESULT");
            //    //        if (AssayTable.DefaultView.Count > 0)
            //    //        {
            //    //            txt_Pa02.Text = max.ToString();
            //    //        }
            //    //    }
            //    //}

            //    AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("aDO2") + "'";
            //    max = quaryMaxValue(AssayTable.DefaultView, "RESULT");
            //    if (careItemsDateTable.DefaultView.Count > 0)
            //    {
            //        txt_aD02.Text = max.ToString();
            //    }

            //    AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("PaO2") + "'";
            //    max = quaryMaxValue(AssayTable.DefaultView, "RESULT");
            //    if (AssayTable.DefaultView.Count > 0)
            //    {
            //        txt_Pa02.Text = max.ToString();
            //    }

            //    AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("PH") + "'";
            //    if (AssayTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = AssayTable.DefaultView[0]["RESULT"].ToString();
            //        string lastValue = AssayTable.DefaultView[AssayTable.DefaultView.Count - 1]["RESULT"].ToString();
            //        firstScore = (Double.Parse(firstValue) >= 7.7 ? 4 : 0) + (Double.Parse(firstValue) >= 7.6 && Double.Parse(firstValue) <= 7.69 ? 3 : 0) + (Double.Parse(firstValue) >= 7.5 && Double.Parse(firstValue) <= 7.59 ? 1 : 0) + (Double.Parse(firstValue) >= 7.33 && Double.Parse(firstValue) <= 7.49 ? 3 : 0) + (Double.Parse(firstValue) >= 7.25 && Double.Parse(firstValue) <= 7.32 ? 2 : 0) + (Double.Parse(firstValue) >= 7.15 && Double.Parse(firstValue) <= 7.24 ? 3 : 0) + (Double.Parse(firstValue) < 7.15 ? 4 : 0);
            //        lastScore = (Double.Parse(lastValue) >= 7.7 ? 4 : 0) + (Double.Parse(lastValue) >= 7.6 && Double.Parse(lastValue) <= 7.69 ? 3 : 0) + (Double.Parse(lastValue) >= 7.5 && Double.Parse(lastValue) <= 7.59 ? 1 : 0) + (Double.Parse(lastValue) >= 7.33 && Double.Parse(lastValue) <= 7.49 ? 3 : 0) + (Double.Parse(lastValue) >= 7.25 && Double.Parse(lastValue) <= 7.32 ? 2 : 0) + (Double.Parse(lastValue) >= 7.15 && Double.Parse(lastValue) <= 7.24 ? 3 : 0) + (Double.Parse(lastValue) < 7.15 ? 4 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_PH.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_PH.Text = firstValue.ToString();
            //        }
            //    }

            //    AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("肌酐Cr") + "'";
            //    if (AssayTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = AssayTable.DefaultView[0]["RESULT"].ToString();
            //        string lastValue = AssayTable.DefaultView[AssayTable.DefaultView.Count - 1]["RESULT"].ToString();
            //        firstScore = (Double.Parse(firstValue) >= 3.5 ? 4 : 0) + (Double.Parse(firstValue) >= 2 && Double.Parse(firstValue) <= 3.4 ? 3 : 0) + (Double.Parse(firstValue) >= 1.5 && Double.Parse(firstValue) <= 1.9 ? 2 : 0) + (Double.Parse(firstValue) >= 0.6 && Double.Parse(firstValue) <= 1.4 ? 0 : 0) + (Double.Parse(firstValue) <= 0.6 ? 2 : 0);
            //        lastScore = (Double.Parse(lastValue) >= 3.5 ? 4 : 0) + (Double.Parse(lastValue) >= 2 && Double.Parse(lastValue) <= 3.4 ? 3 : 0) + (Double.Parse(lastValue) >= 1.5 && Double.Parse(lastValue) <= 1.9 ? 2 : 0) + (Double.Parse(lastValue) >= 0.6 && Double.Parse(lastValue) <= 1.4 ? 0 : 0) + (Double.Parse(lastValue) <= 0.6 ? 2 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_Cr.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_Cr.Text = firstValue.ToString();
            //        }
            //    }

            //    AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("HCT") + "'";
            //    if (AssayTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = AssayTable.DefaultView[0]["RESULT"].ToString();
            //        string lastValue = AssayTable.DefaultView[AssayTable.DefaultView.Count - 1]["RESULT"].ToString();
            //        firstScore = (Double.Parse(firstValue) >= 60 ? 4 : 0) + (Double.Parse(firstValue) >= 50 && Double.Parse(firstValue) <= 59.9 ? 2 : 0) + (Double.Parse(firstValue) >= 46 && Double.Parse(firstValue) <= 49.9 ? 1 : 0) + (Double.Parse(firstValue) >= 30 && Double.Parse(firstValue) <= 45.9 ? 0 : 0) + (Double.Parse(firstValue) >= 20 && Double.Parse(firstValue) <= 29.9 ? 2 : 0) + (Double.Parse(firstValue) < 20 ? 4 : 0);
            //        lastScore = (Double.Parse(lastValue) >= 60 ? 4 : 0) + (Double.Parse(lastValue) >= 50 && Double.Parse(lastValue) <= 59.9 ? 2 : 0) + (Double.Parse(lastValue) >= 46 && Double.Parse(lastValue) <= 49.9 ? 1 : 0) + (Double.Parse(lastValue) >= 30 && Double.Parse(lastValue) <= 45.9 ? 0 : 0) + (Double.Parse(lastValue) >= 20 && Double.Parse(lastValue) <= 29.9 ? 2 : 0) + (Double.Parse(lastValue) < 20 ? 4 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_HCT.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_HCT.Text = firstValue.ToString();
            //        }
            //    }

            //    AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("WBC") + "'";
            //    if (AssayTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = AssayTable.DefaultView[0]["RESULT"].ToString();
            //        string lastValue = AssayTable.DefaultView[AssayTable.DefaultView.Count - 1]["RESULT"].ToString();
            //        firstScore = (Double.Parse(firstValue) >= 40 ? 4 : 0) + (Double.Parse(firstValue) >= 20 && Double.Parse(firstValue) <= 39.9 ? 2 : 0) + (Double.Parse(firstValue) >= 15 && Double.Parse(firstValue) <= 19.9 ? 1 : 0) + (Double.Parse(firstValue) >= 3 && Double.Parse(firstValue) <= 14.9 ? 0 : 0) + (Double.Parse(firstValue) >= 1 && Double.Parse(firstValue) <= 2.9 ? 2 : 0) + (Double.Parse(firstValue) < 1 ? 4 : 0);
            //        lastScore = (Double.Parse(lastValue) >= 40 ? 4 : 0) + (Double.Parse(lastValue) >= 20 && Double.Parse(lastValue) <= 39.9 ? 2 : 0) + (Double.Parse(lastValue) >= 15 && Double.Parse(lastValue) <= 19.9 ? 1 : 0) + (Double.Parse(lastValue) >= 3 && Double.Parse(lastValue) <= 14.9 ? 0 : 0) + (Double.Parse(lastValue) >= 1 && Double.Parse(lastValue) <= 2.9 ? 2 : 0) + (Double.Parse(lastValue) < 1 ? 4 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_WBC.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_WBC.Text = firstValue.ToString();
            //        }
            //    }

            //    AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("K") + "'";
            //    if (AssayTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = AssayTable.DefaultView[0]["RESULT"].ToString();
            //        string lastValue = AssayTable.DefaultView[AssayTable.DefaultView.Count - 1]["RESULT"].ToString();
            //        firstScore = (Double.Parse(firstValue) >= 7 ? 4 : 0) + (Double.Parse(firstValue) >= 6 && Double.Parse(firstValue) <= 6.9 ? 3 : 0) + (Double.Parse(firstValue) >= 5.5 && Double.Parse(firstValue) <= 5.9 ? 1 : 0) + (Double.Parse(firstValue) >= 3.5 && Double.Parse(firstValue) <= 5.4 ? 0 : 0) + (Double.Parse(firstValue) >= 3 && Double.Parse(firstValue) <= 3.4 ? 1 : 0) + (Double.Parse(firstValue) >= 2.5 && Double.Parse(firstValue) <= 2.9 ? 2 : 0) + (Double.Parse(firstValue) < 2.5 ? 4 : 0);
            //        lastScore = (Double.Parse(lastValue) >= 7 ? 4 : 0) + (Double.Parse(lastValue) >= 6 && Double.Parse(lastValue) <= 6.9 ? 3 : 0) + (Double.Parse(lastValue) >= 5.5 && Double.Parse(lastValue) <= 5.9 ? 1 : 0) + (Double.Parse(lastValue) >= 3.5 && Double.Parse(lastValue) <= 5.4 ? 0 : 0) + (Double.Parse(lastValue) >= 3 && Double.Parse(lastValue) <= 3.4 ? 1 : 0) + (Double.Parse(lastValue) >= 2.5 && Double.Parse(lastValue) <= 2.9 ? 2 : 0) + (Double.Parse(lastValue) < 2.5 ? 4 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_K.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_K.Text = firstValue.ToString();
            //        }
            //    }

            //    AssayTable.DefaultView.RowFilter = "REPORT_ITEM_NAME='" + getListName("Na") + "'";
            //    if (AssayTable.DefaultView.Count > 0)
            //    {
            //        string firstValue = AssayTable.DefaultView[0]["RESULT"].ToString();
            //        string lastValue = AssayTable.DefaultView[AssayTable.DefaultView.Count - 1]["RESULT"].ToString();
            //        firstScore = (Double.Parse(firstValue) >= 180 ? 4 : 0) + (Double.Parse(firstValue) >= 160 && Double.Parse(firstValue) <= 179 ? 3 : 0) + (Double.Parse(firstValue) >= 155 && Double.Parse(firstValue) <= 159 ? 2 : 0) + (Double.Parse(firstValue) >= 150 && Double.Parse(firstValue) <= 154 ? 1 : 0) + (Double.Parse(firstValue) >= 130 && Double.Parse(firstValue) <= 149 ? 0 : 0) + (Double.Parse(firstValue) >= 120 && Double.Parse(firstValue) <= 129 ? 2 : 0) + (Double.Parse(firstValue) >= 111 && Double.Parse(firstValue) <= 119 ? 3 : 0) + (Double.Parse(firstValue) <= 111 ? 4 : 0);
            //        lastScore = (Double.Parse(lastValue) >= 180 ? 4 : 0) + (Double.Parse(lastValue) >= 160 && Double.Parse(lastValue) <= 179 ? 3 : 0) + (Double.Parse(lastValue) >= 155 && Double.Parse(lastValue) <= 159 ? 2 : 0) + (Double.Parse(lastValue) >= 150 && Double.Parse(lastValue) <= 154 ? 1 : 0) + (Double.Parse(lastValue) >= 130 && Double.Parse(lastValue) <= 149 ? 0 : 0) + (Double.Parse(lastValue) >= 120 && Double.Parse(lastValue) <= 129 ? 2 : 0) + (Double.Parse(lastValue) >= 111 && Double.Parse(lastValue) <= 119 ? 3 : 0) + (Double.Parse(lastValue) <= 111 ? 4 : 0);
            //        if (firstScore < lastScore)
            //        {
            //            txt_Na.Text = lastValue.ToString();
            //        }
            //        else
            //        {
            //            txt_Na.Text = firstValue.ToString();
            //        }
            //    }
            //}
            //else
            {
                ////获取心率数值
                //careItemsDateTable = DataOperator.GetVital(_patientID, _visitID, _deptID, HeartRate);
                //if (careItemsDateTable != null)
                //{
                //    if (careItemsDateTable.Count > 0)
                //    {
                //        if (!careItemsDateTable[0].IsVITAL_SIGNS_VALUESNull())
                //        {
                //            int.TryParse(careItemsDateTable[0].VITAL_SIGNS_VALUES.ToString("0"), out Values);
                //            if (Values != 0)
                //            {
                //                txt_HeartRate.Text = Values.ToString();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        txt_HeartRate.Text = "";
                //    }
                //}
                ////获取血压数值
                //careItemsDateTable = DataOperator.GetVital(_patientID, _visitID, _deptID, MAP);
                //if (careItemsDateTable != null)
                //{
                //    if (careItemsDateTable.Count > 0)
                //    {
                //        if (!careItemsDateTable[0].IsVITAL_SIGNS_VALUESNull())
                //        {
                //            int.TryParse(careItemsDateTable[0].VITAL_SIGNS_VALUES.ToString("0"), out Values);
                //            if (Values != 0)
                //            {
                //                this.txt_MAP.Text = Values.ToString();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        this.txt_MAP.Text = "";
                //    }
                //}
                ////获取呼吸次数数值
                //careItemsDateTable = DataOperator.GetVital(_patientID, _visitID, _deptID, Breath);
                //if (careItemsDateTable != null)
                //{
                //    if (careItemsDateTable.Count > 0)
                //    {
                //        if (!careItemsDateTable[0].IsVITAL_SIGNS_VALUESNull())
                //        {
                //            int.TryParse(careItemsDateTable[0].VITAL_SIGNS_VALUES.ToString("0"), out Values);
                //            if (Values != 0)
                //            {
                //                this.txt_Breath.Text = Values.ToString();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        this.txt_Breath.Text = "";
                //    }
                //}
                ////获取最后一次体温数值
                //careItemsDateTable = DataOperator.GetVital(_patientID, _visitID, _deptID, Temperature);
                //if (careItemsDateTable != null)
                //{
                //    if (careItemsDateTable.Count > 0)
                //    {

                //        if (!careItemsDateTable[0].IsVITAL_SIGNS_VALUESNull())
                //        {
                //            int.TryParse(careItemsDateTable[0].VITAL_SIGNS_VALUES.ToString("0"), out Values);
                //            if (Values != 0)
                //            {
                //                this.txt_Temperature.Text = Values.ToString();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        this.txt_Temperature.Text = "";
                //    }
                //}
                ////fio2数值
                //careItemsDateTable = DataOperator.GetVital(_patientID, _visitID, _deptID, FiO2);
                //if (careItemsDateTable != null)
                //{
                //    if (careItemsDateTable.Count > 0)
                //    {

                //        if (!careItemsDateTable[0].IsVITAL_SIGNS_VALUESNull())
                //        {
                //            int.TryParse(careItemsDateTable[0].VITAL_SIGNS_VALUES.ToString("0"), out Values);
                //            if (Values != 0)
                //            {
                //                this.txt_Fi92.Text = Values.ToString();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        this.txt_Fi92.Text = "";
                //    }
                //}
                ////PaO2
                //string PaO2 = getListName("PaO2");
                //careItemsDateTable = DataOperator.GetVital(_patientID, _visitID, _deptID, PaO2);

                //if (careItemsDateTable != null)
                //{
                //    if (careItemsDateTable.Count > 0)
                //    {

                //        if (!careItemsDateTable[0].IsVITAL_SIGNS_VALUESNull())
                //        {
                //            int.TryParse(careItemsDateTable[0].VITAL_SIGNS_VALUES.ToString("0"), out Values);
                //            if (Values != 0)
                //            {
                //                this.txt_Pa02.Text = Values.ToString();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        this.txt_Pa02.Text = "";
                //    }
                //}
                //获取检验信息
                //PH
                //string PH = "PH";
                //careItemsDateTable = DataOperator.GetVital(PatientRow.PATIENT_ID, PatientRow.VISIT_ID, PH);
                //if (careItemsDateTable != null)
                //{
                //    if (careItemsDateTable.Count > 0)
                //    {

                //        if (!careItemsDateTable[0].IsVITAL_SIGNS_VALUESNull())
                //        {
                //            int.TryParse(careItemsDateTable[0].VITAL_SIGNS_VALUES.ToString("0"), out Values);
                //            if (Values != 0)
                //            {
                //                this.txt_PH.Text = Values.ToString();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        this.txt_PH.Text = "";
                //    }
                //}
                //AssayTable = new Com.MedicalSystem.Icu.DataSetModel.CheckReport.AssayReportDataTable();
                //string report_item_name = getListName("血PH值");
                //AssayTable = DataOperator.GetAssay(_patientID, _visitID, report_item_name);
                //if (AssayTable != null)
                //{
                //    if (AssayTable.Count > 0)
                //    {
                //        if (!AssayTable[0].IsREPORT_ITEM_NAMENull())
                //        {
                //            this.txt_PH.Text = AssayTable[0].RESULT.ToString();
                //        }
                //    }
                //    else
                //    {
                //        txt_PH.Text = "";
                //    }
                //}
                //AssayTable = new Com.MedicalSystem.Icu.DataSetModel.CheckReport.AssayReportDataTable();
                //string report_name = getListName("肌酐");
                //AssayTable = DataOperator.GetAssay(_patientID, _visitID, report_name);
                //if (AssayTable != null)
                //{
                //    if (AssayTable.Count > 0)
                //    {
                //        if (!AssayTable[0].IsREPORT_ITEM_NAMENull())
                //        {
                //            this.txt_Cr.Text = AssayTable[0].RESULT.ToString();
                //        }
                //    }
                //    else
                //    {
                //        txt_Cr.Text = "";
                //    }
                //}
                //AssayTable = new Com.MedicalSystem.Icu.DataSetModel.CheckReport.AssayReportDataTable();
                //string report_name1 = getListName("红细胞压积");
                //AssayTable = DataOperator.GetAssay(_patientID, _visitID, report_name1);
                //if (AssayTable != null)
                //{
                //    if (AssayTable.Count > 0)
                //    {
                //        if (!AssayTable[0].IsREPORT_ITEM_NAMENull())
                //        {
                //            this.txt_HCT.Text = AssayTable[0].RESULT.ToString();
                //        }
                //    }
                //    else
                //    {
                //        txt_HCT.Text = "";
                //    }
                //}
                //AssayTable = new Com.MedicalSystem.Icu.DataSetModel.CheckReport.AssayReportDataTable();
                //string report_name2 = getListName("白细胞");
                //AssayTable = DataOperator.GetAssay(_patientID, _visitID, report_name2);
                //if (AssayTable != null)
                //{
                //    if (AssayTable.Count > 0)
                //    {
                //        if (!AssayTable[0].IsREPORT_ITEM_NAMENull())
                //        {
                //            this.txt_WBC.Text = AssayTable[0].RESULT.ToString();
                //        }
                //    }
                //    else
                //    {
                //        txt_WBC.Text = "";
                //    }
                //}

                //AssayTable = new Com.MedicalSystem.Icu.DataSetModel.CheckReport.AssayReportDataTable();
                //string report_name3 = getListName("血清钾");
                //AssayTable = DataOperator.GetAssay(_patientID, _visitID, report_name3);
                //if (AssayTable != null)
                //{
                //    if (AssayTable.Count > 0)
                //    {
                //        if (!AssayTable[0].IsREPORT_ITEM_NAMENull())
                //        {
                //            this.txt_K.Text = AssayTable[0].RESULT.ToString();
                //        }
                //    }
                //    else
                //    {
                //        txt_K.Text = "";
                //    }
                //}

                //AssayTable = new Com.MedicalSystem.Icu.DataSetModel.CheckReport.AssayReportDataTable();
                //string report_name4 = getListName("血清钠");
                //AssayTable = DataOperator.GetAssay(_patientID, _visitID, report_name4);
                //if (AssayTable != null)
                //{
                //    if (AssayTable.Count > 0)
                //    {
                //        if (!AssayTable[0].IsREPORT_ITEM_NAMENull())
                //        {
                //            this.txt_Na.Text = AssayTable[0].RESULT.ToString();
                //        }
                //    }
                //    else
                //    {
                //        txt_Na.Text = "";
                //    }
                //}
            }

        }

        //查询最大值
        private double quaryMaxValue(DataView view, string columnName)
        {
            double value = 0, convert = 0;

            for (int i = 0; i < view.Count; i++)
            {
                if (double.TryParse(view[i][columnName].ToString(), out convert))
                {
                    if (value < convert)
                    {
                        value = convert;
                    }
                }
            }
            return value;
        }

        /// <summary>
        /// 获取配置文件中配置的检验名称对照
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string getListName(string name)
        {
            //string value = nameConvertCollection.Get(name);
            //if (!string.IsNullOrEmpty(value))
            //{
            //    return value;
            //}
            //else
            {
                return name;
            }
        }
        #endregion

    }
}
