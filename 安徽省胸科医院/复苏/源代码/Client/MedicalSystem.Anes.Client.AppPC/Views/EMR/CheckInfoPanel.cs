using System;
using System.ComponentModel;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;

namespace MedicalSystem.Anes.Client.AppPC
{
    /// <summary>
    /// 检查信息类
    /// </summary>
    public partial class CheckInfoPanel : BaseView
    {
        private string Keys = string.Empty;
        string _patientID = null;
        decimal _visitID = 0;

        # region 构造方法

        public CheckInfoPanel() : this(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID, ExtendApplicationContext.Current.PatientInformationExtend.OPER_ID) { }

        public CheckInfoPanel(string patientID, decimal visitID, decimal operID) : this(patientID, visitID, operID, "检查") { }
        public CheckInfoPanel(string patientID, decimal visitID, decimal operID, string title)
        {
            ClassInit();
        }

        public CheckInfoPanel(string patientID, decimal visitID, decimal operID, string title, string keys)
        {
            Keys = keys;
            ClassInit();
        }

        private void ClassInit()
        {
            Caption = ViewNames.HisCheckInfo;
            InitializeComponent();
            if (!string.IsNullOrEmpty(Keys))
            {
                string[] dates = Keys.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                DateTime dt;
                if (dates != null && dates.Length > 1 && DateTime.TryParse(dates[1], out dt))
                {
                    dateEdit1.DateTime = dt;
                }
                else
                {
                    dateEdit1.DateTime = DateTime.Now;
                }
            }
            else
            {
                dateEdit1.DateTime = DateTime.Now;
            }
            dateEdit2.DateTime = DateTime.Now.AddDays(1);
            RefreshDataa();
        }
        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 检查信息表
        /// </summary>
       // Sync.CheckReportDataTable checkReportDataTable;

        #endregion 变量

        #region 方法

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshDataa()
        {
            if (this.gridView1.RowCount == 0) return;
            if (string.IsNullOrEmpty(_patientID)) return;
            //checkReportDataTable = new SyncInfoService().GetCheckReport(_patientID, _visitID);
            //this.gridControl1.DataSource = checkReportDataTable;
            //this.medTextBox1.DataBindings.Clear();
            //this.medTextBox1.DataBindings.Add(new Binding("Text", checkReportDataTable, "EXAM_PARA"));
            //this.medTextBox2.DataBindings.Clear();
            //this.medTextBox2.DataBindings.Add(new Binding("Text", checkReportDataTable, "DESCRIPTION"));
            //this.medTextBox3.DataBindings.Clear();
            //this.medTextBox3.DataBindings.Add(new Binding("Text", checkReportDataTable, "IMPRESSION"));
            //this.medTextBox4.DataBindings.Clear();
            //this.medTextBox4.DataBindings.Add(new Binding("Text", checkReportDataTable, "RECOMMENDATION"));
        }

        #endregion 方法

        private void CheckInfoPanel_Enter(object sender, EventArgs e)
        {
            //if (checkReportDataTable != null && checkReportDataTable.Count > 0 && Keys != null && Keys.Length > 0)
            //{
            //    int Index = 0;

            //    foreach (Sync.CheckReportRow CheckRow in checkReportDataTable)
            //    {
            //        string RowKeys = CheckRow.EXAM_SUB_CLASS + "," + CheckRow.EXAM_DATE_TIME.ToString() + "," + (CheckRow.IsREPORT_DATE_TIMENull() ? "" : CheckRow.REPORT_DATE_TIME.ToString());
            //        if (RowKeys == Keys)
            //        {
            //            gridView1.ClearSelection();
            //            gridView1.SelectRow(Index);
            //            break;
            //        }
            //        else
            //        {
            //            Index++;
            //        }
            //    }
            //}
        }

        private void btnQuary_Click(object sender, EventArgs e)
        {
            RefreshDataa();
        }
        /// <summary>
        /// 同步检查信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void medButton1_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    //SyncProxy.GetCheckReport(_patientID, (int)_visitID);
                    //RefreshData();
                }
            }
            catch
            {

            }
        }

        private void dateEdit2_Validating(object sender, CancelEventArgs e)
        {
            if (dateEdit2.DateTime < dateEdit1.DateTime)
            {
                (sender as DevExpress.XtraEditors.DateEdit).ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                (sender as DevExpress.XtraEditors.DateEdit).ErrorText = label1.Text + "不能大于" + label2.Text;
                e.Cancel = true;
                return;
            }
        }
    }
}
