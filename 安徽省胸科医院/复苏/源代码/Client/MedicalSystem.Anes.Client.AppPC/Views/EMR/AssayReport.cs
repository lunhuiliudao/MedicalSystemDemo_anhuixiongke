using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Service;
using MedicalSystem.Anes.Domain;
using DevExpress.XtraGrid;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class AssayReport : BaseView
    {
        private bool _querySign = false;
        string _patientID = null;
        decimal _visitID = 0;
        DataTable labResult = null;
        public AssayReport() : this(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID, ExtendApplicationContext.Current.PatientInformationExtend.OPER_ID) { }

        public AssayReport(string patientID, decimal visitID, decimal operID) : this(patientID, visitID, operID, "检验") { }
        public AssayReport(string patientID, decimal visitID, decimal operID, string title) 
        {
            _patientID = patientID;
            _visitID = visitID;
            InitializeComponent(); 
            SetPatientInformation();
            ConditionsAdjustment();
        }

        public void SetPatientInformation()
        {
            Caption = ViewNames.HisAssay;
            gridControl1.DataSource = null;
            gridControl2.DataSource = null; 
            RefreshDataa();
        }

        private void RefreshDataa()
        {
            Query();
        }

        private void Query()
        {
            if (_querySign)
            {
                return;
            }
            _querySign = true;
            label1.Visible = true;
            string ret = new SyncInfoService().SyncLis(_patientID, _visitID, DocareSysInterfaceCompleted); 
            QueryMasetr();
            _querySign = false;
            label1.Visible = false; 
        }

        private void DocareSysInterfaceCompleted(object sender, EventArgs e)
        {
            QueryMasetr();
            _querySign = false;
            label1.Visible = false;
        }

        private void QueryMasetr()
        {
            DataTable dt = new ModelHandler<MED_LAB_TEST_MASTER>().ToDataTable(EMRDictService.GetPatLabTestMaster(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID));
            gridControl1.DataSource = dt;//
           
        }
         
        private void QueryResult(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                string TestNo = gridView1.GetDataRow(rowIndex)[0].ToString();
                DataTable dt = new ModelHandler<MED_LAB_RESULT>().ToDataTable(EMRDictService.GetLabResult(TestNo));
                // gridView1.GetDataRow(1)
                gridControl2.DataSource = dt;
            }
        } 

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            QueryResult(e.FocusedRowHandle);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = gridControl2.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null)
                return;
            //DataRow row = view.GetDataRow(view.FocusedRowHandle);
            //if (row != null && !row.IsNull("REPORT_ITEM_NAME"))
            //{
            //    LabValueTrendChart labValueTrendChart = new LabValueTrendChart(row["REPORT_ITEM_NAME"].ToString(),_patientID,_visitID);
            //    DialogHostForm dialogHostForm = new DialogHostForm(row["REPORT_ITEM_NAME"].ToString(), 600, 500);
            //    dialogHostForm.Child = labValueTrendChart;
            //    dialogHostForm.ShowDialog();
            //}
        }

        private void btnUnusual_Click(object sender, EventArgs e)
        {
            List<MED_LAB_PATIENT> labPatientList=EMRDictService.GetLabPatientList(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID);
            labPatientList = labPatientList.Where(x => x.ABNORMAL_INDICATOR == "H" || x.ABNORMAL_INDICATOR == "L").ToList();
            DataTable dt = new ModelHandler<MED_LAB_PATIENT>().ToDataTable(labPatientList);
           
            gridControl2.DataSource = dt;
        }
        private void ConditionsAdjustment()
        {
            DevExpress.XtraGrid.StyleFormatCondition cn;
            cn = new DevExpress.XtraGrid.StyleFormatCondition(FormatConditionEnum.Equal, gridView2.Columns["ABNORMAL_INDICATOR"], null, "H");
            cn.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            cn.ApplyToRow = true;
            gridView2.FormatConditions.Add(cn);

            cn = new DevExpress.XtraGrid.StyleFormatCondition(FormatConditionEnum.Equal, gridView2.Columns["ABNORMAL_INDICATOR"], null, "L");
            cn.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(158)))), ((int)(((byte)(55)))));
            cn.ApplyToRow = true;
            gridView2.FormatConditions.Add(cn);
        }
    }
}
