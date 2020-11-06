using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Views;
using System.Linq.Expressions;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(true)]
    public partial class DoctorQualityControl : BaseView
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        List<MED_USER_NOTE> userNote = null;
        public DoctorQualityControl()
        {
            InitializeComponent();
            this.dgFinishedYesterday.AutoGenerateColumns = false;
            this.dgTomorrowSchedule.AutoGenerateColumns = false;
            checkPersonalTomorrow.CheckEditControl_SizeChanged(null, null);
            checkPersonalFinished.CheckEditControl_SizeChanged(null, null);
        }
        private List<MED_OPERATION_SCHEDULE> operationSchedule = null;
        public List<MED_OPERATION_SCHEDULE> OperationScheduleFilter = null;
        private List<MED_PATIENT_CARD> patientCardSchedule = null;
        private List<MED_PATIENT_CARD> PatientCardScheduleFilter = null;
        private List<MED_PATIENT_CARD> finishedOper = null;
        public List<MED_PATIENT_CARD> FinishedOperFilter = null;
        private static readonly object _tomorrowCellClick = new object();
        public event EventHandler TomorrowCellClick
        {
            add
            {
                Events.AddHandler(_tomorrowCellClick, value);
            }
            remove
            {
                Events.RemoveHandler(_tomorrowCellClick, value);
            }
        }
        private static readonly object _yesterdayCellClick = new object();
        public event EventHandler YesterdayCellClick
        {
            add
            {
                Events.AddHandler(_yesterdayCellClick, value);
            }
            remove
            {
                Events.RemoveHandler(_yesterdayCellClick, value);
            }
        }
        private static readonly object _anesDocCellClick = new object();
        public event EventHandler AnesDocCellClick
        {
            add
            {
                Events.AddHandler(_anesDocCellClick, value);
            }
            remove
            {
                Events.RemoveHandler(_anesDocCellClick, value);
            }
        }
        public void DoctorQualityControlLoad()
        {
            if (!DesignMode)
            {
                this.Dock = DockStyle.Fill;
                using (BackgroundWorker worker = new BackgroundWorker())
                {
                    worker.DoWork += delegate(object sender, DoWorkEventArgs e)
                    {
                        //明日手术
                        DateTime startTime = accountRepository.GetServerTime().Data.Date;
                        DateTime endTime = startTime.AddDays(1);
                        operationSchedule = operationScheduleRepository.GetOperationScheduleList(endTime, endTime, "", 
                            ExtendApplicationContext.Current.HospBranchCode, ExtendApplicationContext.Current.OperRoom).Data;
                        if (operationSchedule != null && operationSchedule.Count > 0)
                        {
                            operationSchedule = operationSchedule.Where(x => x.OPER_STATUS_CODE > 1).OrderBy(x => x.SORT_NO).ToList();
                        }
                        if (operationSchedule == null || operationSchedule.Count == 0)
                        {
                            patientCardSchedule = patientInfoRepository.GetPatientListDataTable(endTime, ExtendApplicationContext.Current.OperRoom, 
                                ExtendApplicationContext.Current.HospBranchCode).Data;

                            if (patientCardSchedule != null && patientCardSchedule.Count > 0)
                            {
                                patientCardSchedule = patientCardSchedule.Where(x => x.OPER_STATUS_CODE < 5).OrderBy(x => x.SORT_NO).ToList();
                            }
                        }
                        //昨日手术
                        startTime = startTime.AddDays(-1);
                        endTime = startTime.AddDays(-7);

                        finishedOper = patientInfoRepository.GetPatientListByDate(endTime, startTime, "", ExtendApplicationContext.Current.OperRoom, 
                            ExtendApplicationContext.Current.HospBranchCode).Data;
                    };
                    worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                    {
                        FilterData("");
                    };
                    worker.RunWorkerAsync();
                }
            }
        }
        private void FilterData(string searchContent)
        {
            string loginId = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
            string loginName = ExtendApplicationContext.Current.LoginUser.USER_NAME;

            if (patientCardSchedule == null || patientCardSchedule.Count == 0)
            {
                if (checkPersonalTomorrow.IsChecked && !ExtendApplicationContext.Current.LoginUser.isMDSD)
                {
                    OperationScheduleFilter = operationSchedule.Where(p => p.ANES_DOCTOR == loginId || p.ANES_DOCTOR == loginName || p.FIRST_ANES_ASSISTANT == loginId || p.SECOND_ANES_ASSISTANT == loginId
                       || p.THIRD_ANES_ASSISTANT == loginId || p.FOURTH_ANES_ASSISTANT == loginId || p.FIRST_OPER_NURSE == loginId || p.FIRST_SUPPLY_NURSE == loginId
                       || p.SECOND_OPER_NURSE == loginId || p.SECOND_SUPPLY_NURSE == loginId || p.THIRD_OPER_NURSE == loginId || p.THIRD_SUPPLY_NURSE == loginId
                       || p.FOURTH_OPER_NURSE == loginId || p.FOURTH_SUPPLY_NURSE == loginId).ToList();
                }
                else
                {
                    OperationScheduleFilter = operationSchedule;
                }
            }
            else
            {
                if (checkPersonalTomorrow.IsChecked && !ExtendApplicationContext.Current.LoginUser.isMDSD)
                {
                    PatientCardScheduleFilter = patientCardSchedule.Where(p => p.ANES_DOCTOR == loginId || p.ANES_DOCTOR == loginName || p.FIRST_ANES_ASSISTANT == loginId || p.SECOND_ANES_ASSISTANT == loginId
                       || p.THIRD_ANES_ASSISTANT == loginId || p.FOURTH_ANES_ASSISTANT == loginId || p.FIRST_OPER_NURSE == loginId || p.FIRST_SUPPLY_NURSE == loginId
                       || p.SECOND_OPER_NURSE == loginId || p.SECOND_SUPPLY_NURSE == loginId || p.THIRD_OPER_NURSE == loginId || p.THIRD_SUPPLY_NURSE == loginId
                       || p.FOURTH_OPER_NURSE == loginId || p.FOURTH_SUPPLY_NURSE == loginId).ToList();
                }
                else
                {
                    PatientCardScheduleFilter = patientCardSchedule;
                }
                
            }

            if (checkPersonalFinished.IsChecked && !ExtendApplicationContext.Current.LoginUser.isMDSD)
            {

                FinishedOperFilter = finishedOper.Where(p => p.ANES_DOCTOR == loginId || p.ANES_DOCTOR == loginName || p.FIRST_ANES_ASSISTANT == loginId || p.SECOND_ANES_ASSISTANT == loginId
                   || p.THIRD_ANES_ASSISTANT == loginId || p.FOURTH_ANES_ASSISTANT == loginId || p.FIRST_OPER_NURSE == loginId || p.FIRST_SUPPLY_NURSE == loginId
                   || p.SECOND_OPER_NURSE == loginId || p.SECOND_SUPPLY_NURSE == loginId || p.THIRD_OPER_NURSE == loginId || p.THIRD_SUPPLY_NURSE == loginId
                   || p.FOURTH_OPER_NURSE == loginId || p.FOURTH_SUPPLY_NURSE == loginId).ToList();
            }
           
            labelTomorrowCount.Text = (OperationScheduleFilter != null && OperationScheduleFilter.Count > 0) ? OperationScheduleFilter.Count.ToString() : "0";
            labelFinishedCount.Text = (FinishedOperFilter != null && FinishedOperFilter.Count > 0) ? FinishedOperFilter.Count.ToString() : "0";
            if (patientCardSchedule == null || patientCardSchedule.Count == 0)
                dgTomorrowSchedule.DataSource = OperationScheduleFilter;
            else
                dgTomorrowSchedule.DataSource = PatientCardScheduleFilter;
            dgTomorrowSchedule.ClearSelection();
            dgFinishedYesterday.DataSource = FinishedOperFilter;
            dgFinishedYesterday.ClearSelection();
        }
        public bool SearchTomorrowFilterData(string searchContent)
        {
            bool isReturn = false;
            if (OperationScheduleFilter != null && OperationScheduleFilter.Count > 0)
            {
                List<MED_OPERATION_SCHEDULE> operScheduledList = OperationScheduleFilter.Where(x => x.PATIENT_ID == searchContent || x.INP_NO == searchContent || x.NAME == searchContent).ToList().OrderBy(x => x.SCHEDULED_DATE_TIME).ToList();
                if (operScheduledList != null && operScheduledList.Count > 0)
                {
                    MED_OPERATION_SCHEDULE operSchedule = operScheduledList[0];
                    for (int i = 0; i < dgTomorrowSchedule.Rows.Count; i++)
                    {
                        if (dgTomorrowSchedule["ColumnPatientID", i].Value.ToString().Trim() == operSchedule.PATIENT_ID && Convert.ToInt32(dgTomorrowSchedule["ColumnVisitID", i].Value) == operSchedule.VISIT_ID && Convert.ToInt32(dgTomorrowSchedule["ColumnOperID", i].Value) == operSchedule.OPER_ID)
                        {
                            this.dgTomorrowSchedule.Rows[i].Selected = true;
                            this.dgTomorrowSchedule.CurrentCell = this.dgTomorrowSchedule.Rows[i].Cells[0];
                            isReturn = true;
                            break;
                        }
                        else
                        {
                            this.dgTomorrowSchedule.Rows[i].Selected = false;
                        }
                    }
                    MessageQueue.AddMessage("为您查找到明日手术患者" + operSchedule.NAME + " " + operSchedule.SEX + "  " + operSchedule.AGE, Color.Black);
                }
            }
            else if (PatientCardScheduleFilter != null && PatientCardScheduleFilter.Count > 0)
            {
                List<MED_PATIENT_CARD> operScheduledList = PatientCardScheduleFilter.Where(x => x.PATIENT_ID == searchContent || x.INP_NO == searchContent || x.NAME == searchContent).ToList().OrderBy(x => x.SCHEDULED_DATE_TIME).ToList();
                if (operScheduledList != null && operScheduledList.Count > 0)
                {
                    MED_PATIENT_CARD operSchedule = operScheduledList[0];
                    for (int i = 0; i < dgTomorrowSchedule.Rows.Count; i++)
                    {
                        if (dgTomorrowSchedule["ColumnPatientID", i].Value.ToString().Trim() == operSchedule.PATIENT_ID && Convert.ToInt32(dgTomorrowSchedule["ColumnVisitID", i].Value) == operSchedule.VISIT_ID && Convert.ToInt32(dgTomorrowSchedule["ColumnOperID", i].Value) == operSchedule.OPER_ID)
                        {
                            this.dgTomorrowSchedule.Rows[i].Selected = true;
                            this.dgTomorrowSchedule.CurrentCell = this.dgTomorrowSchedule.Rows[i].Cells[0];
                            isReturn = true;
                            break;
                        }
                        else
                        {
                            this.dgTomorrowSchedule.Rows[i].Selected = false;
                        }
                    }
                    MessageQueue.AddMessage("为您查找到明日手术患者" + operSchedule.NAME + " " + operSchedule.SEX + "  " + operSchedule.AGE, Color.Black);
                }
            }
            if (!isReturn)
            {
                for (int i = 0; i < dgTomorrowSchedule.Rows.Count; i++)
                {
                    this.dgTomorrowSchedule.Rows[i].Selected = false;
                }
            }
            return isReturn;

        }
        public bool SearchYesterdayFilterData(string searchContent)
        {
            bool isReturn = false;
            List<MED_PATIENT_CARD> patientCardList = null;
            List<MED_PATIENT_CARD> refreshList = new List<MED_PATIENT_CARD>();
            MED_PATIENT_CARD patientCard = new MED_PATIENT_CARD();
            if (FinishedOperFilter != null && FinishedOperFilter.Count > 0)
            {
                patientCardList = FinishedOperFilter.Where(x => x.PATIENT_ID == searchContent || x.INP_NO == searchContent || x.NAME == searchContent).ToList();
            }

            if (patientCardList == null || patientCardList.Count == 0)
            {
                patientCardList = patientInfoRepository.GetPatientListDataTable(DateTime.MinValue, ExtendApplicationContext.Current.OperRoom, 
                    ExtendApplicationContext.Current.HospBranchCode).Data;
                patientCardList = patientCardList.Where(x => x.PATIENT_ID == searchContent || x.INP_NO == searchContent || x.NAME == searchContent).ToList();
                if (patientCardList != null && patientCardList.Count > 0)
                {
                    foreach (MED_PATIENT_CARD card in patientCardList)
                    {
                        bool isAdd = true;
                        foreach (MED_PATIENT_CARD patient in FinishedOperFilter)
                        {
                            if (card.PATIENT_ID == patient.PATIENT_ID && card.VISIT_ID == patient.VISIT_ID && card.OPER_ID == patient.OPER_ID) isAdd = false;
                        }
                        if (isAdd) refreshList.Add(card);
                    }
                    foreach (MED_PATIENT_CARD card in FinishedOperFilter)
                    {
                        refreshList.Add(card);
                    }
                    FinishedOperFilter = new List<MED_PATIENT_CARD>();
                    FinishedOperFilter = refreshList;
                    dgFinishedYesterday.DataSource = FinishedOperFilter;
                    patientCard = FinishedOperFilter[0];
                }
            }
            else
            {
                patientCard = patientCardList[0];
            }
            if (patientCard != null)
            {
                for (int i = 0; i < dgFinishedYesterday.Rows.Count; i++)
                {
                    if (dgFinishedYesterday["ColumnYPatientID", i].Value.ToString().Trim() == patientCard.PATIENT_ID && Convert.ToInt32(dgFinishedYesterday["ColumnYVisitID", i].Value) == patientCard.VISIT_ID && Convert.ToInt32(dgFinishedYesterday["ColumnYOperID", i].Value) == patientCard.OPER_ID)
                    {
                        this.dgFinishedYesterday.Rows[i].Selected = true;
                        this.dgFinishedYesterday.CurrentCell = this.dgFinishedYesterday.Rows[i].Cells[0];
                        isReturn = true;
                        break;
                    }
                    else
                    {
                        this.dgFinishedYesterday.Rows[i].Selected = false;
                    }
                }

                MessageQueue.AddMessage("为您查找到已完成手术患者" + patientCard.NAME + " " + patientCard.SEX + "  " + patientCard.AGE, Color.Black);
            }
            return isReturn;
        }
        public void FinishedYesterdaySelect()
        {
            for (int i = 0; i < dgFinishedYesterday.Rows.Count; i++)
            {
                this.dgFinishedYesterday.Rows[i].Selected = false;
            }
        }
        public void TomorrowScheduleSelect()
        {
            for (int i = 0; i < dgTomorrowSchedule.Rows.Count; i++)
            {
                this.dgFinishedYesterday.Rows[i].Selected = false;
            }
        }
        public DataTable RefreshDataTable(DataTable dataTable)
        {
            if (!dataTable.Columns.Contains("DOCTOR_DUTY")) dataTable.Columns.Add("DOCTOR_DUTY");
            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr.IsNull("ANES_DOCTOR") && (dr["ANES_DOCTOR"].Equals(ExtendApplicationContext.Current.LoginUser.USER_JOB_ID) || dr["ANES_DOCTOR"].Equals(ExtendApplicationContext.Current.LoginUser.USER_NAME)))
                    dr["DOCTOR_DUTY"] = "主麻医生";
                else
                    dr["DOCTOR_DUTY"] = "副麻医生";
            }
            return dataTable;
        }

        public void CellClick(DataGridViewRow row, string patientID, int visitID, int operID)
        {
            ExtendApplicationContext.Current.PatientContextExtend.PatientID = patientID;
            ExtendApplicationContext.Current.PatientContextExtend.VisitID = visitID;
            ExtendApplicationContext.Current.PatientContextExtend.OperID = operID;
            ExtendApplicationContext.Current.PatientInformationExtend = patientInfoRepository.GetPatCard(patientID, visitID, operID).Data;
            ExtendApplicationContext.Current.MED_OPERATION_MASTER
                  = operationInfoRepository.GetOperMaster(patientID, visitID, operID).Data;

            ExtendApplicationContext.Current.MED_PAT_MASTER_INDEX
                = operationInfoRepository.GetPatMasterIndex(patientID).Data;

            ExtendApplicationContext.Current.MED_PAT_VISIT
                = operationInfoRepository.GetPatVisit(patientID, visitID).Data;
        }
        public string BindControls(string bindTable, string code)
        {
            string value = code;
            if (bindTable.ToUpper().Equals("MED_DEPT_DICT"))
            {
                List<MED_DEPT_DICT> deptList = ExtendApplicationContext.Current.CommDict.DeptDict;
                foreach (MED_DEPT_DICT dept in deptList)
                {
                    if (dept.DEPT_CODE == code) { value = dept.DEPT_NAME; break; }
                }
            }
            else if (bindTable.ToUpper().Equals("MED_HIS_USERS"))
            {
                List<MED_HIS_USERS> hisUserList = ExtendApplicationContext.Current.CommDict.HisUsersDict;
                foreach (MED_HIS_USERS user in hisUserList)
                {
                    if (user.USER_JOB_ID == code) { value = user.USER_NAME; break; }
                }
            }
            return value;
        }
        public void ShowFormByDocName(object patientId, object visitId, object operId, string docName)
        {
            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);
            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                return;
            }
            try
            {
                Type t = Type.GetType(document.Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                baseDoc.ShowScrollBar();
                // 设置指定的患者信息
                if (patientId != null)
                {
                    object[] objs = new object[3];
                    objs[0] = patientId;
                    objs[1] = visitId;
                    objs[2] = operId;
                    baseDoc.SetDocParameters(objs);
                }
                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                DialogHostFormPC dialogHostForm = null;
                dialogHostForm = new DialogHostFormPC(docName, 1200, 900);
                dialogHostForm.Child = baseDoc;
                if (AccessControl.CheckModifyRightForOperator(docName))//有Modify权限
                    baseDoc.SetAllControlEditable(true);
                else
                {
                    baseDoc.SetAllButtonsEnable(false);
                    baseDoc.SetAllControlEditable(false);
                }
                if (baseDoc.AllowSingleDocModify())
                    baseDoc.SetAllControlEditable(true);
                dialogHostForm.ShowDialog();

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        List<BaseDoc> bocList = new List<BaseDoc>();
        Dictionary<string, string> reportNameDic = new Dictionary<string, string>();


        public void ShowFormByDocName(object patientId, object visitId, object operId, List<string> item)
        {
            string firstDocName = "";
            bocList.Clear();
            reportNameDic.Clear();
            try
            {
                BaseDoc baseDoc = new BaseDoc();

                foreach (string docName in item)
                {
                    if (!string.IsNullOrEmpty(docName))
                    {
                        if (string.IsNullOrEmpty(firstDocName))
                            firstDocName = docName;
                        ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);
                        //没有找到退出
                        if (!string.IsNullOrEmpty(document.Caption))
                        {
                            Type t = Type.GetType(document.Type);
                            baseDoc = Activator.CreateInstance(t) as BaseDoc;
                            baseDoc.BtnClicked += baseDoc_BtnClicked;
                            baseDoc.Caption = docName;
                            baseDoc.ShowScrollBar();
                            // 设置指定的患者信息
                            if (patientId != null)
                            {
                                object[] objs = new object[3];
                                objs[0] = patientId;
                                objs[1] = visitId;
                                objs[2] = operId;
                                baseDoc.SetDocParameters(objs);
                            }
                            bocList.Add(baseDoc);
                            reportNameDic.Add(docName, ExtendApplicationContext.Current.AppPath + document.Path);
                        }
                    }
                }
                if (reportNameDic.Count > 0)
                {
                    bocList[0].LoadReport(reportNameDic, firstDocName);
                    DialogHostFormPC dialogHostForm = null;
                    dialogHostForm = new DialogHostFormPC("其他文书", 1200, 900);
                    dialogHostForm.Child = bocList[0];
                    if (AccessControl.CheckModifyRightForOperator(firstDocName))//有Modify权限
                        bocList[0].SetAllControlEditable(true);
                    else
                    {
                        bocList[0].SetAllButtonsEnable(false);
                        bocList[0].SetAllControlEditable(false);
                    }
                    if (bocList[0].AllowSingleDocModify())
                        bocList[0].SetAllControlEditable(true);
                    dialogHostForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void baseDoc_BtnClicked(object sender, int index)
        {
            if (AccessControl.CheckModifyRightForOperator(bocList[index].Caption))//有Modify权限
                bocList[index].SetAllControlEditable(true);
            else
            {
                bocList[index].SetAllButtonsEnable(false);
                bocList[index].SetAllControlEditable(false);
            }
            if (bocList[index].AllowSingleDocModify())
                bocList[index].SetAllControlEditable(true);

            Panel panel = ((UserControl)sender).Parent as Panel;
            panel.Controls.Clear();
            DialogHostFormPC form = panel.Parent as DialogHostFormPC;

            form.Child = bocList[index];
            bocList[index].LoadReport(reportNameDic, bocList[index].Caption);
        }
        private void checkPersonalTomorrow_CheckedChange(object sender, EventArgs e)
        {
            FilterData("");
        }

        private void checkPersonalFinished_CheckedChange(object sender, EventArgs e)
        {
            FilterData("");
        }

        private void dgTomorrowSchedule_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            string patientID = dgTomorrowSchedule.Rows[e.RowIndex].Cells["ColumnPatientID"].Value.ToString();
            int visitID = (int)dgTomorrowSchedule.Rows[e.RowIndex].Cells["ColumnVisitID"].Value;
            int operID = (int)dgTomorrowSchedule.Rows[e.RowIndex].Cells["ColumnOperID"].Value;
            CellClick(dgTomorrowSchedule.CurrentRow, patientID, visitID, operID);
            if (DataGridViewActionButtonCell.IsVisitButtonClick(sender, e))
            {
                ShowFormByDocName(patientID, visitID, operID, "术前访视");
            }

            if (DataGridViewActionButtonCell.IsMainDocButtonClick(sender, e))
            {
                ShowFormByDocName(patientID, visitID, operID, "麻醉同意书");
            }
            if (DataGridViewActionButtonCell.IsOtherDocButtonClick(sender, e))
            {
                ExtendApplicationContext.Current.SystemStatus = ProgramStatus.PeroperativePatient;
                string[] buttonStrings = ExtendApplicationContext.Current.StatusButtonStrList[ExtendApplicationContext.Current.SystemStatus].Split(new char[] { ';' }, StringSplitOptions.None);

                for (int i = 0; i < buttonStrings.Length; i++)
                {
                    if (i == 1)
                    {
                        string[] groupButtons = buttonStrings[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        List<string> item = new List<string>();
                        foreach (var text in groupButtons)
                        {
                            if (AccessControl.CheckBrowseRight(text))
                            {
                                item.Add(text);
                            }
                        }
                        ShowFormByDocName(patientID, visitID, operID, item);
                    }
                }
            }
        }

        private void dgFinishedYesterday_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            string patientID = dgFinishedYesterday["ColumnYPatientID", e.RowIndex].Value.ToString();
            int visitID = (int)dgFinishedYesterday.Rows[e.RowIndex].Cells["ColumnYVisitID"].Value;
            int operID = (int)dgFinishedYesterday.Rows[e.RowIndex].Cells["ColumnYOperID"].Value;
            CellClick(dgFinishedYesterday.CurrentRow, patientID, visitID, operID);
            if (DataGridViewActionButtonCell.IsVisitButtonClick(sender, e))
            {
                ShowFormByDocName(patientID, visitID, operID, "术后随访");
            }
            if (DataGridViewActionButtonCell.IsMainDocButtonClick(sender, e))
            {
                ExtendApplicationContext.Current.SystemStatus = ProgramStatus.AnesthesiaRecord;
                CellClick(dgFinishedYesterday.CurrentRow, patientID, visitID, operID);
                EventHandler eventHandle = Events[_anesDocCellClick] as EventHandler;
                if (eventHandle != null)
                {
                    eventHandle(sender, e);
                }
            }
            if (DataGridViewActionButtonCell.IsOtherDocButtonClick(sender, e))
            {
                ExtendApplicationContext.Current.SystemStatus = ProgramStatus.PostoperativePatient;
                string[] buttonStrings = ExtendApplicationContext.Current.StatusButtonStrList[ExtendApplicationContext.Current.SystemStatus].Split(new char[] { ';' }, StringSplitOptions.None);

                for (int i = 0; i < buttonStrings.Length; i++)
                {
                    if (i == 1)
                    {
                        string[] groupButtons = buttonStrings[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        List<string> item = new List<string>();
                        foreach (var text in groupButtons)
                        {
                            if (AccessControl.CheckBrowseRight(text))
                            {
                                item.Add(text);
                            }
                        }
                        ShowFormByDocName(patientID, visitID, operID, item);
                    }
                }
            }
        }

        private void DoctorQualityControl_Load(object sender, EventArgs e)
        {
            DoctorQualityControlLoad();
            this.SetDefaultGridViewStyle(dgTomorrowSchedule);
            this.SetDefaultGridViewStyle(dgFinishedYesterday);
        }

        private void dgTomorrowSchedule_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgTomorrowSchedule.ReadOnly || e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            string patientID = dgTomorrowSchedule.CurrentRow.Cells["ColumnPatientID"].Value.ToString();
            int visitID = (int)dgTomorrowSchedule.CurrentRow.Cells["ColumnVisitID"].Value;
            int operID = (int)dgTomorrowSchedule.CurrentRow.Cells["ColumnOperID"].Value;
            string name = dgTomorrowSchedule.CurrentRow.Cells["ColumnName"].Value.ToString();
            DialogHostFormPC dialogHostForm = new DialogHostFormPC(name + "的首页", 1600, 1000);
            dialogHostForm.Child = new PatientMain(patientID, visitID, operID);
            dialogHostForm.ShowDialog();
        }

        private void dgFinishedYesterday_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgFinishedYesterday.ReadOnly || e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            string patientID = dgFinishedYesterday.CurrentRow.Cells["ColumnYPatientID"].Value.ToString();
            int visitID = (int)dgFinishedYesterday.CurrentRow.Cells["ColumnYVisitID"].Value;
            int operID = (int)dgFinishedYesterday.CurrentRow.Cells["ColumnYOperID"].Value;
            string name = dgFinishedYesterday.CurrentRow.Cells["ColumnYName"].Value.ToString();
            DialogHostFormPC dialogHostForm = new DialogHostFormPC(name + "的首页", 1600, 1000);
            dialogHostForm.Child = new PatientMain(patientID, visitID, operID);//446343
            dialogHostForm.ShowDialog();
        }
    }
}
