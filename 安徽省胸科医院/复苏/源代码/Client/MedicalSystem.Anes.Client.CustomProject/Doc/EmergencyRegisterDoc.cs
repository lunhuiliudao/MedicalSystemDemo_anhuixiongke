using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class EmergencyRegisterDoc : CustomBaseDoc
    {
        AccountRepository accountRepository = new AccountRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        private bool bPatientID_Change = true;
        DateTime serverTime = new AccountRepository().GetServerTime().Data;
        private bool emptyInpNoOrPatID = false;
        private int visitID = 1;
        private int operID = 1;
        private DataTable scheduleOperInfoDT = null;
        private List<MED_OPERATION_SCHEDULE> operScheduleList = new List<MED_OPERATION_SCHEDULE>();
        private MED_OPERATION_SCHEDULE currentOperSchedule = null;
        private MED_PAT_MASTER_INDEX patMasterIndex = null;
        private MED_OPERATION_MASTER operationMaster = null;
        private MED_PATS_IN_HOSPITAL patInHospital = null;
        private List<MED_OPERATION_NAME> operNameNewList = new List<MED_OPERATION_NAME>();
        private MED_PAT_VISIT patVisit = null;
        List<MTextBox> textBoxs = null;
        MedGridView dgvScheduleOperInfo = null;
        public EmergencyRegisterDoc()
        {
            InitializeComponent();
            base.PrintButton.Visible = false;
            base.btnMultiPrint.Visible = false;
            base.DocKind = DocKind.Default;
            base.HideScrollBar();
        }
        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            textBoxs = this.GetControls<MTextBox>();
            foreach (MTextBox ctl in textBoxs)
            {
                if (ctl.Name == "mtbInpNo" || ctl.Name == "mtbPatID")
                {
                    ctl.TextChanged += new EventHandler(ctl_TextChanged);
                    ctl.Leave += new EventHandler(ctl_Leave);
                }
            }
            List<MedGridView> girdView = this.GetControls<MedGridView>();
            foreach (MedGridView view in girdView)
            {
                if (view.Name == "dgvScheduleOperInfo")
                {
                    dgvScheduleOperInfo = view;
                }
            }
        }
        private void ctl_TextChanged(object sender, EventArgs e)
        {
            MTextBox txtBox = sender as MTextBox;
            if (!IsNaturalNumber(txtBox.Text) && txtBox.Text.Length > 0)
            {
                MessageBoxFormPC.Show("只允许输入字母和数字。");
                txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1);
                txtBox.SelectionStart = txtBox.Text.Length;
            }
            else
            {
                bPatientID_Change = true;
            }
        }
        private void ctl_Leave(object sender, EventArgs e)
        {
            MTextBox txtBox = sender as MTextBox;
            if (txtBox.Name == "mtbInpNo")
            {
                if (!bPatientID_Change) return;
                bPatientID_Change = false;
                SyncPatientByInpNo(txtBox.Text.Trim());
            }
            else if (txtBox.Name == "mtbPatID")
            {
                if (!bPatientID_Change) return;
                bPatientID_Change = false;
                SyncPatientByPatientId(txtBox.Text.Trim());
            }
        }
        private void SyncPatientByPatientId(string patientID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                if (ExtendApplicationContext.Current.IsSync)
                {
                    string ret = "";

                    ret = syncInfoRepository.SyncPatientInfoAndInHospital(patientID).Data;

                    ret += syncInfoRepository.SyncScheduleInfo(patientID, serverTime).Data;

                    if (!string.IsNullOrEmpty(ret))
                    {
                        MessageBoxFormPC.Show(ret);
                    }
                }
            }
            emptyInpNoOrPatID = false;
            bool flag = true;
            if (patientID != "")
            {
                patMasterIndex = operationInfoRepository.GetPatMasterIndex(patientID).Data;
                List<MED_PAT_VISIT> patVisitList = operationInfoRepository.GetPatVisitList(patientID).Data;
                if (patVisitList != null && patVisitList.Count > 0)
                {
                    flag = flag & false;
                    patVisit = patVisitList[0];
                    visitID = Convert.ToInt32(patVisitList[0].GetValue("VISIT_ID"));
                }
                else
                {
                    flag = flag & true;
                    patVisit = new MED_PAT_VISIT();
                    visitID = 1;
                    patVisit.SetValue("PATIENT_ID", patientID);
                }
                if (patMasterIndex == null)
                {
                    flag = flag & true;
                    patMasterIndex = new MED_PAT_MASTER_INDEX();
                    patMasterIndex.SetValue("PATIENT_ID", patientID);
                    emptyInpNoOrPatID = flag;
                    BindData();
                    MessageBoxFormPC.Show("当前输入患者ID，需要手动输入患者信息进行急诊登记", "系统提示");
                    // return;
                }
                operScheduleList = operationInfoRepository.GetOperScheduleList(patientID, visitID).Data.Where(x => x.SCHEDULED_DATE_TIME.Value >= serverTime & x.OPER_STATUS_CODE == 0).ToList();
                patInHospital = operationInfoRepository.GetPatsInHospitalByID(patientID, visitID).Data;
                GetScheduleOperInfo();
                if (scheduleOperInfoDT != null && scheduleOperInfoDT.Rows.Count > 0)
                {
                    BindGridViewData(dgvScheduleOperInfo, scheduleOperInfoDT);
                }
                List<MED_OPERATION_MASTER> operMasterList = operationInfoRepository.GetOperMasterList(patientID, visitID).Data;
                if (operMasterList != null && operMasterList.Count > 0)
                {
                    operID = Convert.ToInt32(operMasterList[0].GetValue("OPER_ID")) + 1;
                }
                operationMaster = new MED_OPERATION_MASTER();
                operationMaster.PATIENT_ID = patientID;
                operationMaster.VISIT_ID = visitID;
                operationMaster.OPER_ID = operID;
                BindData();
            }
        }

        private void SyncPatientByInpNo(string inpNo)
        {
            //调用接口
            if (!string.IsNullOrEmpty(inpNo))
            {
                if (ExtendApplicationContext.Current.IsSync)
                {
                    string ret = "";
                    ret = syncInfoRepository.SyncPatientInfoAndInHospitalByInpNo(inpNo).Data;
                    if (!string.IsNullOrEmpty(ret))
                    {
                        MessageBoxFormPC.Show(ret);
                    }
                }
                emptyInpNoOrPatID = false;
                bool flag = true;
                string patientID = string.Empty;
                List<MED_PAT_VISIT> patVisitList = operationInfoRepository.GetPatVisitListByInpNo(inpNo).Data;

                if (patVisitList != null && patVisitList.Count > 0)
                {
                    flag = flag & false;
                    patVisit = patVisitList[0];
                    visitID = Convert.ToInt32(patVisitList[0].GetValue("VISIT_ID"));
                    patientID = patVisitList[0].PATIENT_ID;
                    BindControls("MED_PAT_MASTER_INDEX", "PATIENT_ID", patientID);
                }
                else
                {
                    flag = flag & true;
                    patVisit = new MED_PAT_VISIT();
                    visitID = 1;
                    patVisit.SetValue("INP_NO", inpNo);
                }

                if (ExtendApplicationContext.Current.IsSync)
                {
                    string ret = syncInfoRepository.SyncPatientInfoAndInHospitalByInpNo(inpNo).Data;
                    if (!string.IsNullOrEmpty(ret))
                    {
                        MessageBoxFormPC.Show(ret);
                    }
                }
                patMasterIndex = operationInfoRepository.GetPatMasterIndex(patientID).Data;
                if (patMasterIndex == null)
                {
                    flag = flag & true;
                    patMasterIndex = new MED_PAT_MASTER_INDEX();
                    BindData();
                    emptyInpNoOrPatID = flag;
                    MessageBoxFormPC.Show("当前输入患者ID，需要手动输入患者信息进行急诊登记", "系统提示");
                    // return;
                }
                operScheduleList = operationInfoRepository.GetOperScheduleList(patientID, visitID).Data.Where(x => x.SCHEDULED_DATE_TIME.Value >= serverTime & x.OPER_STATUS_CODE == 0).ToList();
                patInHospital = operationInfoRepository.GetPatsInHospitalByID(patientID, visitID).Data;
                GetScheduleOperInfo();
                if (scheduleOperInfoDT != null && scheduleOperInfoDT.Rows.Count > 0)
                {
                    BindGridViewData(dgvScheduleOperInfo, scheduleOperInfoDT);
                }
                List<MED_OPERATION_MASTER> operMasterList = operationInfoRepository.GetOperMasterList(patientID, visitID).Data;
                if (operMasterList != null && operMasterList.Count > 0)
                {
                    operID = Convert.ToInt32(operMasterList[0].GetValue("OPER_ID")) + 1;
                }
                operationMaster = new MED_OPERATION_MASTER();
                operationMaster.PATIENT_ID = patientID;
                operationMaster.VISIT_ID = visitID;
                operationMaster.OPER_ID = operID;
                BindData();
            }
        }
        private void GetScheduleOperInfo()
        {
            scheduleOperInfoDT = new DataTable();
            scheduleOperInfoDT.Columns.Add("PATIENT_ID", Type.GetType("System.String"));
            scheduleOperInfoDT.Columns.Add("VISIT_ID", Type.GetType("System.Int32"));
            scheduleOperInfoDT.Columns.Add("SCHEDULE_ID", Type.GetType("System.Int32"));
            scheduleOperInfoDT.Columns.Add("SCHEDULED_DATE_TIME", Type.GetType("System.DateTime"));
            scheduleOperInfoDT.Columns.Add("NAME", Type.GetType("System.String"));
            scheduleOperInfoDT.Columns.Add("INP_NO", Type.GetType("System.String"));
            scheduleOperInfoDT.Columns.Add("OPERATION_NAME", Type.GetType("System.String"));
            if (operScheduleList != null && operScheduleList.Count > 0)
            {
                foreach (MED_OPERATION_SCHEDULE item in operScheduleList)
                {
                    DataRow row = scheduleOperInfoDT.NewRow();
                    row["PATIENT_ID"] = item.PATIENT_ID;
                    row["VISIT_ID"] = item.VISIT_ID;
                    row["SCHEDULE_ID"] = item.SCHEDULE_ID;
                    row["SCHEDULED_DATE_TIME"] = item.SCHEDULED_DATE_TIME;
                    if (patMasterIndex != null)
                    {
                        row["NAME"] = patMasterIndex.NAME;
                    }
                    if (patVisit != null)
                    {
                        row["INP_NO"] = patVisit.INP_NO;
                    }
                    row["OPERATION_NAME"] = item.OPERATION_NAME;
                    scheduleOperInfoDT.Rows.Add(row);
                }
            }
        }
        /// <summary>
        ///数据绑定
        /// </summary>
        private void BindData()
        {
            foreach (MTextBox mtb in textBoxs)
            {
                if (mtb.SourceTableName == "MED_PAT_MASTER_INDEX")
                {
                    if (patMasterIndex != null)
                    {
                        if (mtb.SourceFieldName.Equals("PATIENT_ID") && emptyInpNoOrPatID)
                        {
                        }
                        else
                        {
                            if (patMasterIndex.GetValue(mtb.SourceFieldName) != null)
                            {
                                if (mtb.SourceFieldName.Equals("DATE_OF_BIRTH") && !string.IsNullOrEmpty(patMasterIndex.GetValue(mtb.SourceFieldName).ToString()))
                                {
                                    mtb.Text = DateTime.Parse(patMasterIndex.GetValue(mtb.SourceFieldName).ToString()).ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    mtb.Text = patMasterIndex.GetValue(mtb.SourceFieldName).ToString();
                                }
                            }
                            else
                            {
                                mtb.Text = string.Empty;
                                mtb.Data = string.Empty;
                            }
                        }
                    }
                }
                else if (mtb.SourceTableName == "MED_OPERATION_MASTER")
                {
                    if (operationMaster != null)
                    {
                        if (mtb.SourceFieldName.Equals("SCHEDULED_DATE_TIME"))
                        {
                            if (operationMaster.GetValue(mtb.SourceFieldName) != null && !string.IsNullOrEmpty(operationMaster.GetValue(mtb.SourceFieldName).ToString()))
                            {
                                mtb.Text = DateTime.Parse(operationMaster.GetValue(mtb.SourceFieldName).ToString()).ToString("yyyy-MM-dd HH:mm");
                            }
                            else
                            {
                                mtb.Text = accountRepository.GetServerTime().Data.ToString("yyyy-MM-dd HH:mm");
                            }
                        }
                        else if (operationMaster.GetValue(mtb.SourceFieldName) != null)
                        {
                            mtb.Text = operationMaster.GetValue(mtb.SourceFieldName).ToString();  // operationMasterDT.Rows[0][mtb.SourceFieldName].ToString();
                        }
                    }
                }
                else if (mtb.SourceTableName == "MED_OPERATION_SCHEDULE")
                {
                    if (currentOperSchedule != null)
                    {
                        if (mtb.SourceFieldName.Equals("SCHEDULED_DATE_TIME"))
                        {
                            if (currentOperSchedule.GetValue(mtb.SourceFieldName) != null && !string.IsNullOrEmpty(currentOperSchedule.GetValue(mtb.SourceFieldName).ToString()))
                            {
                                mtb.Text = DateTime.Parse(currentOperSchedule.GetValue(mtb.SourceFieldName).ToString()).ToString("yyyy-MM-dd HH:mm");
                            }
                            else
                            {
                                mtb.Text = accountRepository.GetServerTime().Data.ToString("yyyy-MM-dd HH:mm");
                            }
                        }
                        else if (currentOperSchedule.GetValue(mtb.SourceFieldName) != null)
                        {
                            mtb.Text = currentOperSchedule.GetValue(mtb.SourceFieldName).ToString();
                        }
                    }
                }
                else if (mtb.SourceTableName == "MED_PAT_VISIT")
                {
                    if (patVisit != null)
                    {
                        if (mtb.SourceFieldName.Equals("INP_NO") && emptyInpNoOrPatID)
                        {
                        }
                        else
                        {
                            if (patVisit.GetValue(mtb.SourceFieldName) != null)
                            {
                                mtb.Text = patVisit.GetValue(mtb.SourceFieldName).ToString();
                            }
                            else
                            {
                                mtb.Text = string.Empty;
                                mtb.Data = string.Empty;
                            }
                        }
                    }
                }
                else if (mtb.SourceTableName == "MED_PATS_IN_HOSPITAL")
                {
                    if (patInHospital != null)
                    {
                        if (mtb.SourceFieldName.Equals("INP_NO") && emptyInpNoOrPatID)
                        {
                        }
                        else
                        {
                            if (patInHospital.GetValue(mtb.SourceFieldName) != null)
                            {
                                if (mtb.DictTableName != null && mtb.DictTableName == "MED_DEPT_DICT")
                                {
                                    List<MED_DEPT_DICT> deptDict = ExtendApplicationContext.Current.CommDict.DeptDict;
                                    string deptID = patInHospital.GetValue(mtb.SourceFieldName).ToString();
                                    foreach (MED_DEPT_DICT row in deptDict)
                                    {
                                        if (row.DEPT_CODE == deptID) { mtb.Text = row.DEPT_NAME; mtb.SelectedData = deptID; break; }
                                    }
                                }
                                else
                                {
                                    mtb.Text = patInHospital.GetValue(mtb.SourceFieldName).ToString();
                                }
                            }
                            else
                            {
                                mtb.Text = string.Empty;
                                mtb.Data = string.Empty;
                            }
                        }
                    }
                }
            }
        }
        public void BindControls(string bindTable, string bindField, string value)
        {
            if (textBoxs.Count > 0)
            {
                foreach (MTextBox txt in textBoxs)
                {
                    if (txt.BindTableName != null && txt.BindTableName.Equals(bindTable) && txt.BindFieldName != null && txt.BindFieldName.Equals(bindField))
                    {
                        txt.Text = value;
                    }
                }
            }
        }
        public string BindControls(string bindTable, string bindField)
        {
            string value = string.Empty;
            if (textBoxs.Count > 0)
            {
                foreach (MTextBox txt in textBoxs)
                {
                    if (txt.BindTableName != null && txt.BindTableName.Equals(bindTable) && txt.BindFieldName != null && txt.BindFieldName.Equals(bindField))
                    {
                        if (txt.SelectedData != null) value = txt.SelectedData.ToString();
                        else
                            value = txt.Text;
                        break;
                    }
                }
            }
            return value;
        }
        public bool IsNaturalNumber(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9]+$");
            return reg1.IsMatch(str);
        }
        public void BindGridViewData(MedGridView control, DataTable dataSources)
        {
            control.EnableHeadersVisualStyles = false;
            control.AutoCreateColumns();
            for (int j = 0; j < control.Columns.Count; j++)
            {
                control.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            InitGridSource(control, dataSources);
        }
        private void InitGridSource(MedGridView control, DataTable dataSources)
        {
            int rowCount = control.LinesPerPage;
            for (int i = 0; i < rowCount; i++)
            {
                int index = control.Rows.Add();
                control.Rows[i].Tag = i + control.LinesPerPage * PagerSetting.CurrentPageIndex;
            }
            for (int i = 0; i < dataSources.Rows.Count; i++)
            {
                if (i < control.LinesPerPage * PagerSetting.CurrentPageIndex || i >= control.LinesPerPage * (PagerSetting.CurrentPageIndex + 1))
                {
                    continue;
                }
                DataGridViewRow gridRow = control.Rows[i - control.LinesPerPage * PagerSetting.CurrentPageIndex];
                DataRow dataRow = dataSources.Rows[i];

                for (int j = 0; j < control.ColumnCount; j++)
                {
                    object value = dataRow[control.MedGridViewColumns[j].DataProperty];
                    if (value != System.DBNull.Value)
                    {
                        gridRow.Cells[j].Value = value;
                        gridRow.Cells[j].Tag = value;
                    }
                }
            }
        }
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)//, ref bool bNeedMsg
        {
            foreach (MTextBox mtb in textBoxs)
            {
                if (string.IsNullOrEmpty(mtb.Text) && !string.IsNullOrEmpty(mtb.InputNeededMessage))
                {
                    MessageBoxFormPC.Show("*号为必填项目，请重新填写");
                    // bNeedMsg = false;
                    return;
                }
            }
            string patientID = BindControls("MED_PAT_MASTER_INDEX", "PATIENT_ID");
            if (operationMaster == null)
                operationMaster = new MED_OPERATION_MASTER();
            operationMaster.SetValue("PATIENT_ID", patientID);
            operationMaster.SetValue("VISIT_ID", visitID);
            operationMaster.SetValue("OPER_ID", operID);
            operationMaster.SetValue("OPER_ROOM", ExtendApplicationContext.Current.OperRoom);
            operationMaster.SetValue("HOSP_BRANCH", ExtendApplicationContext.Current.HospBranchCode);
            operationMaster.SetValue("EMERGENCY_IND", BindControls("MED_OPERATION_MASTER", "EMERGENCY_IND"));
            operationMaster.SetValue("DEPT_CODE", BindControls("MED_OPERATION_MASTER", "DEPT_CODE"));
            operationMaster.SetValue("BED_NO", BindControls("MED_OPERATION_MASTER", "BED_NO"));
            operationMaster.SetValue("SCHEDULED_DATE_TIME", BindControls("MED_OPERATION_MASTER", "SCHEDULED_DATE_TIME"));
            operationMaster.SetValue("OPER_ROOM_NO", BindControls("MED_OPERATION_MASTER", "OPER_ROOM_NO"));
            operationMaster.SetValue("SEQUENCE", BindControls("MED_OPERATION_MASTER", "SEQUENCE"));
            operationMaster.SetValue("ANES_DOCTOR", BindControls("MED_OPERATION_MASTER", "ANES_DOCTOR"));
            operationMaster.SetValue("DIAG_BEFORE_OPERATION", BindControls("MED_OPERATION_MASTER", "DIAG_BEFORE_OPERATION"));
            operationMaster.SetValue("OPERATION_NAME", BindControls("MED_OPERATION_MASTER", "OPERATION_NAME"));
            operationMaster.SetValue("OPER_STATUS_CODE", 2);

            if (currentOperSchedule != null)
            {
                currentOperSchedule.SetValue("OPER_STATUS_CODE", 2);
            }

            if (patVisit == null)
            {
                patVisit = new MED_PAT_VISIT();
            }
            patVisit.SetValue("PATIENT_ID", patientID);
            patVisit.SetValue("VISIT_ID", visitID);
            patVisit.SetValue("INP_NO", BindControls("MED_PATS_IN_HOSPITAL", "INP_NO"));

            if (patMasterIndex == null)
            {
                patMasterIndex = new MED_PAT_MASTER_INDEX();
            }
            patMasterIndex.SetValue("PATIENT_ID", patientID);
            patMasterIndex.SetValue("NAME", BindControls("MED_PAT_MASTER_INDEX", "NAME"));
            patMasterIndex.SetValue("SEX", BindControls("MED_PAT_MASTER_INDEX", "SEX"));
            patMasterIndex.SetValue("DATE_OF_BIRTH", BindControls("MED_PAT_MASTER_INDEX", "DATE_OF_BIRTH"));

            string strOperName = BindControls("MED_OPERATION_MASTER", "OPER_NAME");
            if (!string.IsNullOrEmpty(strOperName))
            {
                string[] operNameArr = strOperName.Split('+');
                for (int i = 0; i < operNameArr.Length; i++)
                {
                    MED_OPERATION_NAME operName = new MED_OPERATION_NAME();
                    operName.SetValue("PATIENT_ID", operationMaster.PATIENT_ID);
                    operName.SetValue("VISIT_ID", operationMaster.VISIT_ID);
                    operName.SetValue("OPER_ID", operationMaster.OPER_ID);
                    operName.SetValue("OPER_NO", i + 1);
                    operName.SetValue("OPER_NAME", operNameArr[i].ToString());
                    operNameNewList.Add(operName);
                }
            }

            MED_ANESTHESIA_PLAN anesPlan = operationInfoRepository.GetAnesPlan(patientID, visitID, operID).Data;
            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = operationInfoRepository.GetAnesPlanPmh(patientID, visitID, operID).Data;
            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = operationInfoRepository.GetAnesPlanExam(patientID, visitID, operID).Data;

            if (anesPlan == null)
            {
                anesPlan = new MED_ANESTHESIA_PLAN();
                anesPlan.SetValue("PATIENT_ID", patientID);
                anesPlan.SetValue("VISIT_ID", visitID);
                anesPlan.SetValue("OPER_ID", operID);
            }
            if (anesPlanPmh == null)
            {
                anesPlanPmh = new MED_ANESTHESIA_PLAN_PMH();
                anesPlanPmh.SetValue("PATIENT_ID", patientID);
                anesPlanPmh.SetValue("VISIT_ID", visitID);
                anesPlanPmh.SetValue("OPER_ID", operID);
            }
            if (anesPlanExam == null)
            {
                anesPlanExam = new MED_ANESTHESIA_PLAN_EXAM();
                anesPlanExam.SetValue("PATIENT_ID", patientID);
                anesPlanExam.SetValue("VISIT_ID", visitID);
                anesPlanExam.SetValue("OPER_ID", operID);
            }
            //OperationInfoService.SavePatientOperation(currentOperSchedule, patVisit, patMasterIndex, null, operNameNewList, operationMaster, anesPlan, anesPlanPmh, anesPlanExam, null);



            List<MED_OPERATION_NAME> operNameOldList = null;

            MED_OPERATION_MASTER_EXT operMasterExt = null;

            operationInfoRepository.SavePatientOperation(new { currentOperSchedule, patVisit, patMasterIndex, operNameOldList, operNameNewList, operationMaster, anesPlan, anesPlanPmh, anesPlanExam, operMasterExt });

        }
    }
}
