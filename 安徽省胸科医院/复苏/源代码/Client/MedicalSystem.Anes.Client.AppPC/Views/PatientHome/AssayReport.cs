using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class AssayReport : BaseView
    {
        CommonRepository commonRepository = new CommonRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();



        string _patientID = null;
        decimal _visitID = 0;

        DataTable labResult = null;
        public AssayReport(string patientID, decimal visitID)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            SetPatientInformation();
            this.dgList.AutoGenerateColumns = false;
            this.SetDefaultGridViewStyle(this.dgList);
        }
        public AssayReport()
        {
            InitializeComponent();
            this.dgList.AutoGenerateColumns = false;
        }

        public void SetPatientInformation()
        {
            treeViewExtendList.Nodes.Clear();
            dgList.DataSource = null;

            RefreshDataa();
        }

        private void RefreshDataa()
        {
            string ret = syncInfoRepository.SyncLis2(_patientID, _visitID, DocareSysInterfaceCompleted).Data;
        }

        private void DocareSysInterfaceCompleted(object sender, EventArgs e)
        {
            QueryMasetr();
        }

        private void QueryMasetr()
        {
            DataTable dt = ModelHelper<MED_LAB_TEST_MASTER>.ConvertListToDataTable(commonRepository.GetMedLabTestMaster(_patientID, (int)_visitID).Data);
            foreach (DataRow item in dt.Rows)
            {
                TreeNode node = new TreeNode();
                node.Tag = item["TEST_NO"].ToString();
                node.Text = string.Format("{0}\r\n{1}({2})", item["RESULTS_RPT_DATE_TIME"].ToString(), item["TEST_CAUSE"].ToString(), item["SPECIMEN"].ToString());
                treeViewExtendList.Nodes.Add(node);
            }
        }

        private void QueryResult(string TestNo)
        {
            if (!string.IsNullOrEmpty(TestNo))
            {
                DataTable dt = ModelHelper<MED_LAB_RESULT>.ConvertListToDataTable(commonRepository.GetMedLabResult(TestNo).Data);
                SetLowHeigh(dt, "ABNORMAL_INDICATOR");
                dgList.DataSource = dt;
                labelCount.Text = string.Format("共{0}条记录", dt.Rows.Count);
            }
        }

        private void AssayReport_Load(object sender, EventArgs e)
        {
            this.SetDefaultGridViewStyle(this.dgList);
        }

        private void buttonColor1_BtnClicked(object sender, EventArgs e)
        {
            List<MED_LAB_PATIENT> labPatientList = commonRepository.GetLabPatientList(_patientID, (int)_visitID).Data;

            labPatientList = labPatientList.Where(x => x.ABNORMAL_INDICATOR == "H" || x.ABNORMAL_INDICATOR == "L").ToList();
            DataTable dt = ModelHelper<MED_LAB_PATIENT>.ConvertListToDataTable(labPatientList);
            SetLowHeigh(dt, "ABNORMAL_INDICATOR");
            dgList.DataSource = dt;
            labelCount.Text = string.Format("共{0}条记录", dt.Rows.Count);

        }

        private void treeViewExtendList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
                QueryResult(e.Node.Tag.ToString());
        }

        private void SetLowHeigh(DataTable dt, string column)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][column].ToString().ToLower() == "h")
                {
                    dt.Rows[i][column] = "↑";
                }
                else if (dt.Rows[i][column].ToString().ToLower() == "l")
                {
                    dt.Rows[i][column] = "↓";
                }
            }
        }

        private void dgList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (this.dgList.Rows[e.RowIndex].Cells[3].Value.ToString() == "↑" ||
                this.dgList.Rows[e.RowIndex].Cells[3].Value.ToString() == "↓")
            {
                this.dgList.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.Red;
                //this.dgList.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Red;
            }
        }
    }
}
