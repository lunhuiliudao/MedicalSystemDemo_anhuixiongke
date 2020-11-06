using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using System.Linq.Expressions;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PatientListViewPACU : BaseView
    {
        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        public PatientListViewPACU()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 390;
            dgPACUList.AutoGenerateColumns = false;
            this.SetDefaultGridViewStyle(dgPACUList);
        }
        #region 事件接口
        private static readonly object _patientDoubleClick = new object();
        public event EventHandler PatientDoubleClick
        {
            add
            {
                Events.AddHandler(_patientDoubleClick, value);
            }
            remove
            {
                Events.RemoveHandler(_patientDoubleClick, value);
            }
        }

        private static readonly object _selectChanged = new object();
        public event EventHandler SelectChanged
        {
            add
            {
                Events.AddHandler(_selectChanged, value);
            }
            remove
            {
                Events.RemoveHandler(_selectChanged, value);
            }
        }
        private static readonly object _patientClick = new object();
        public event EventHandler PatientClick
        {
            add
            {
                Events.AddHandler(_patientClick, value);
            }
            remove
            {
                Events.RemoveHandler(_patientClick, value);
            }
        }
        #endregion 事件接口
        #region 属性接口


        private MED_PATIENT_CARD _selectedPatient = null;
        public MED_PATIENT_CARD SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
        }

        private MED_PATIENT_CARD _showPatient = null;
        public MED_PATIENT_CARD ShowPatient
        {
            get
            {
                return _showPatient;
            }
        }

        #endregion 属性
        #region  变量
        private List<MED_PATIENT_CARD> _operationsInfoDataTable;
        public List<MED_PATIENT_CARD> OperationsInfoDataTable
        {
            get
            {
                return _operationsInfoDataTable;
            }
            set
            {
                _operationsInfoDataTable = value;
            }
        }
        private List<MED_PATIENT_CARD> _operationSelectInfoDT;
        #endregion 变量
        /// <summary>
        /// 重新获取数据并定位当前患者
        /// </summary>
        public void RefreshPatientDataTable(DateTime scheduledTime, string searchStr)
        {
            Cursor oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;
            string departCode = ExtendApplicationContext.Current.OperRoom;
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                DateTime dt = scheduledTime == DateTime.MinValue ? DateTime.Now : scheduledTime;
                worker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    OperationsInfoDataTable = patientInfoRepository.GetPatientListDataTableByPACU(dt, TransStr(departCode), 
                        TransStr(ExtendApplicationContext.Current.HospBranchCode), searchStr).Data;
                };
                worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (OperationsInfoDataTable != null && OperationsInfoDataTable.Count > 0)
                        OperationsInfoDataTable = SortOperationTable(OperationsInfoDataTable);

                    FilterData();
                    Cursor = oldCursor;
                    operationRoomPandect1.RefreshOperationRoomContentList();
                };
                worker.RunWorkerAsync();
            };

        }
        /// <summary>
        /// 去掉特殊字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string TransStr(string s)
        {
            string[] strs = new string[]{";","&","<",">","'","--","/","%","~",",","`","!","@","#","$","^",
            "*","(",")","+",":","<",">","?","/","\\","\"","{","}","[","]","-","_"," ","！","~","￥","…","（",
            "）"," ","——","、","。","."};
            foreach (string str in strs)
            {
                if (s.Contains(str))
                {
                    if (str == "'")
                        s = s.Replace(str, "''");
                    else s = s.Replace(str, "");
                }
            }
            return s;
        }
        private List<MED_PATIENT_CARD> SortOperationTable(List<MED_PATIENT_CARD> operationsInfoDataTable)
        {
            List<MED_PATIENT_CARD> res = null;
            try
            {
                List<MED_PATIENT_CARD> rows40 = operationsInfoDataTable.Where(x => x.OPER_STATUS_CODE == 40).ToList().OrderBy(x => x.SORT_NO).ToList().OrderBy(x => x.OPER_ROOM_NO).ToList().OrderBy(x => x.SEQUENCE).ToList();
                List<MED_PATIENT_CARD> rows45 = operationsInfoDataTable.Where(x => x.OPER_STATUS_CODE == 45).ToList().OrderBy(x => x.SORT_NO).ToList().OrderBy(x => x.SEQUENCE).ToList();
                // List<MED_PATIENT_CARD> rows2530 = operationsInfoDataTable.Where(x => (Convert.ToInt32(x.OPER_STATUS_CODE) >= 25 && Convert.ToInt32(x.OPER_STATUS_CODE) < 35)).ToList();
                List<MED_PATIENT_CARD> rows55 = operationsInfoDataTable.Where(x => Convert.ToInt32(x.OPER_STATUS_CODE) > 45).ToList().OrderBy(x => x.SORT_NO).ToList().OrderBy(x => x.SEQUENCE).ToList();
                List<MED_PATIENT_CARD> t = new List<MED_PATIENT_CARD>();

                if (rows40 != null && rows40.Count > 0)
                {
                    rows40.ForEach(row =>
                    {
                        t.Add(row);
                    });
                }
                //if (rows2530 != null && rows2530.Count > 0)
                //{
                //    rows2530.ForEach(row =>
                //    {
                //        t.Add(row);
                //    });
                //}
                if (rows45 != null && rows45.Count > 0)
                {
                    rows45.ForEach(row =>
                    {
                        t.Add(row);
                    });
                }
                if (rows55 != null && rows55.Count > 0)
                {
                    rows55.ForEach(row =>
                    {
                        t.Add(row);
                    });
                }
                res = t;
            }
            catch
            {

            }
            return res;


        }


        protected void SetFilter()
        {
            Expression<Func<MED_PATIENT_CARD, bool>> expression = p => true;
            switch (radioGroupStatus.SelectedIndex)
            {
                case 1:
                    //expression = expression.And(p => p.OPER_STATUS_CODE == 40);
                    _operationSelectInfoDT = OperationsInfoDataTable.Where(p => p.OPER_STATUS_CODE == 40).ToList();

                    break;
                case 2:
                    //expression = expression.And(p => p.OPER_STATUS_CODE == 45);
                    _operationSelectInfoDT = OperationsInfoDataTable.Where(p => p.OPER_STATUS_CODE == 45).ToList();
                    break;
                case 3:
                    //expression = expression.And(p => p.OPER_STATUS_CODE >= 55);
                    _operationSelectInfoDT = OperationsInfoDataTable.Where(p => p.OPER_STATUS_CODE >= 55).ToList();
                    break;
                default:
                    _operationSelectInfoDT = OperationsInfoDataTable;
                    break;
            }
            //if (checkEditOperEnd.Checked)
            //{
            //    expression = expression.And(p => p.OPER_STATUS_CODE == 25 || p.OPER_STATUS_CODE == 20);
            //}
            //if (checkEditPACUEnd.Checked)
            //{
            //    expression = expression.And(p => p.OPER_STATUS_CODE >= 55);
            //}
            //if (!checkEditOperEnd.Checked && !checkEditPACUEnd.Checked)
            //{
            //    expression = expression.And(p => p.OPER_STATUS_CODE == 40);
            //}
            //_operationSelectInfoDT = OperationsInfoDataTable.Where(expression.Compile()).ToList();
            _operationSelectInfoDT.OrderBy(x => x.OPER_ROOM_NO);
            if (radioGroupStatus.SelectedIndex == 3)
            {
                _operationSelectInfoDT = _operationSelectInfoDT.OrderBy(x => x.IN_PACU_DATE_TIME).ToList();
            }
        }
        private void FilterData()
        {

            if (OperationsInfoDataTable == null)
                return;
            SetFilter();
            labelOutPACU.Text = (OperationsInfoDataTable.Where(p => p.OPER_STATUS_CODE >= 55).ToList()).Count.ToString();
            labelWInpacu.Text = (OperationsInfoDataTable.Where(p => p.OPER_STATUS_CODE == 40).ToList()).Count.ToString();
            labelUnFinishedCount.Text = (OperationsInfoDataTable.Where(p => p.OPER_STATUS_CODE == 45).ToList()).Count.ToString();
            BindingSource BS = new BindingSource();
            BS.DataSource = _operationSelectInfoDT;
            dgPACUList.DataSource = BS;


            operationRoomPandect1.RefreshOperationRoomContentList();


        }
        private void SelectPatient(MED_PATIENT_CARD patCard)
        {
            if (ExtendAppContext.Current.PatientID == patCard.PATIENT_ID && ExtendAppContext.Current.VisitID == patCard.VISIT_ID
                && ExtendAppContext.Current.OperID == patCard.OPER_ID)
            { }
            else
            {
                if (ExtendApplicationContext.Current.IsRescueMode)
                {
                    if (MessageBoxFormPC.Show("当前患者处于急救模式下，是否取消急救模式后切换患者？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ExtendApplicationContext.Current.IsRescueMode = false;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            RefreshPatientDataTable(patCard.PATIENT_ID, patCard.VISIT_ID, patCard.OPER_ID);
            _selectedPatient = patCard;
            MED_PATIENT_CARD patientInformation = patCard;
            if (patientInformation != null)
            {
                ExtendAppContext.Current.PatientID = patientInformation.PATIENT_ID;
                ExtendAppContext.Current.VisitID = patientInformation.VISIT_ID;
                ExtendAppContext.Current.OperID = patientInformation.OPER_ID;
                ExtendApplicationContext.Current.PatientContextExtend.PatientID = patientInformation.PATIENT_ID;
                ExtendApplicationContext.Current.PatientContextExtend.VisitID = patientInformation.VISIT_ID;
                ExtendApplicationContext.Current.PatientContextExtend.OperID = patientInformation.OPER_ID;
            }
            else
            {
                ExtendAppContext.Current.PatientID = "";
                ExtendApplicationContext.Current.PatientContextExtend.PatientID = "";
            }
            ExtendApplicationContext.Current.PatientInformationExtend = patCard;
            //ShowPatientStatus(patCard);
            EventHandler eventHandle = Events[_selectChanged] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }
        /// <summary>
        /// 重新更新指定患者信息
        /// </summary>
        public void RefreshPatientDataTable(string patientID, int visitID, int operID)
        {
            if (OperationsInfoDataTable != null)
            {
                MED_PATIENT_CARD cardRow = patientInfoRepository.GetPatCard(patientID, visitID, operID).Data;
                if (OperationsInfoDataTable != null && OperationsInfoDataTable.Count > 0 && cardRow != null)
                {
                    for (int i = 0; i < OperationsInfoDataTable.Count; i++)
                    {
                        if (OperationsInfoDataTable[i].PATIENT_ID == patientID && OperationsInfoDataTable[i].VISIT_ID == visitID && OperationsInfoDataTable[i].OPER_ID == operID)
                        {
                            OperationsInfoDataTable[i] = cardRow;
                            break;
                        }
                    }
                    _selectedPatient = cardRow;
                }
            }
        }
        protected void RefreshOperatingRoomList()
        {
            ExtendApplicationContext.Current.CommDict.OperationRoomDict = new ComnDictRepository().GetAllOperatingRoomList().Data;
            DataTable dt = ModelHelper<MED_OPERATING_ROOM>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.OperationRoomDict);
            ExtendApplicationContext.Current.CodeTables["MED_OPERATING_ROOM"] = dt;
        }
        private void patientSelectClick()
        {
            //空着  先判断是否有术中权限
            SelectPatient(_selectedPatient);
            // ShowPatientInformation(_selectedPatient);
        }
        public void Search(string searchContent)
        {
            List<MED_PATIENT_CARD> patientCardList = null;
            if (_operationSelectInfoDT != null && _operationSelectInfoDT.Count > 0)
                patientCardList = _operationSelectInfoDT.Where(p => p.PATIENT_ID == searchContent || p.INP_NO == searchContent || p.NAME == searchContent).ToList();
            else
                _operationSelectInfoDT = new List<MED_PATIENT_CARD>();
            if (patientCardList != null && patientCardList.Count > 0)
            {
                MED_PATIENT_CARD patientCard = patientCardList[0];
                for (int i = 0; i < dgPACUList.Rows.Count; i++)
                {
                    if (dgPACUList["ColumnPatientID", i].Value.ToString().Trim() == patientCard.PATIENT_ID && Convert.ToInt32(dgPACUList["ColumnVisitID", i].Value) == patientCard.VISIT_ID && Convert.ToInt32(dgPACUList["ColumnOperID", i].Value) == patientCard.OPER_ID)
                    {
                        this.dgPACUList.Rows[i].Selected = true;
                        this.dgPACUList.CurrentCell = this.dgPACUList.Rows[i].Cells[0];
                        break;
                    }
                    else
                    {
                        this.dgPACUList.Rows[i].Selected = false;
                    }
                }
                operationRoomPandect1.RefreshRoom(searchContent, false);
            }
            else
            {
                patientCardList = patientInfoRepository.GetPatientListDataTable(DateTime.MinValue, 
                    ExtendApplicationContext.Current.OperRoom, 
                    ExtendApplicationContext.Current.HospBranchCode).Data;
                if (patientCardList != null)
                    patientCardList = patientCardList.Where(x => x.PATIENT_ID == searchContent || x.INP_NO == searchContent || x.NAME == searchContent).ToList();
                if (patientCardList != null && patientCardList.Count > 0)
                {
                    foreach (MED_PATIENT_CARD card in patientCardList)
                    {
                        _operationSelectInfoDT.Add(card);
                    }
                    BindingSource BS = new BindingSource();
                    BS.DataSource = _operationSelectInfoDT;
                    dgPACUList.DataSource = BS;
                    _selectedPatient = patientCardList[0];
                }
                if (_selectedPatient != null)
                {
                    for (int i = 0; i < dgPACUList.Rows.Count; i++)
                    {
                        if (dgPACUList["ColumnPatientID", i].Value.ToString().Trim() == _selectedPatient.PATIENT_ID && Convert.ToInt32(dgPACUList["ColumnVisitID", i].Value) == _selectedPatient.VISIT_ID && Convert.ToInt32(dgPACUList["ColumnOperID", i].Value) == _selectedPatient.OPER_ID)
                        {
                            this.dgPACUList.Rows[i].Selected = true;
                            this.dgPACUList.CurrentCell = this.dgPACUList.Rows[i].Cells[0];
                            break;
                        }
                        else
                        {
                            this.dgPACUList.Rows[i].Selected = false;
                        }
                    }
                    MessageQueue.AddMessage("为您查找到已完成手术患者" + _selectedPatient.NAME + " " + _selectedPatient.SEX + "  " + _selectedPatient.AGE, Color.Black);
                }
                operationRoomPandect1.RefreshRoom(searchContent, true);
            }
        }
        private void dgPACUList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgPACUList.Columns[e.ColumnIndex].HeaderText.Equals("操作"))
            {
                MED_PATIENT_CARD card = dgPACUList.Rows[e.RowIndex].DataBoundItem as MED_PATIENT_CARD;
                int operStatus = Convert.ToInt32(dgPACUList.Rows[e.RowIndex].Cells["OperStatus"].Value);

                if (dgPACUList.Rows[e.RowIndex].Cells["OperStatus"].Value == null)
                {
                    return;
                }
                if (card.OPER_STATUS_CODE == (int)OperationStatus.TurnToPACU)
                {
                    e.Value = Resources.pacu左表格_入室1;
                }
                else if (card.OPER_STATUS_CODE > (int)OperationStatus.InPACU)
                {
                    if (card.IN_PACU_DATE_TIME.HasValue)
                        e.Value = Resources.pacu左表格_出室1;
                    else
                        e.Value = Resources.pacu左表格_入室1;
                }
                else
                {
                    e.Value = Resources.pacu左表格_blank;
                }
            }
            else if (dgPACUList.Columns[e.ColumnIndex].HeaderText.Equals("状态"))
            {

                if (e.Value == null)
                {
                    return;
                }
                int operStatus = Convert.ToInt32(e.Value);
                e.Value = OperationStatusHelper.OperationStatusToString((OperationStatus)operStatus);
            }

        }

        private void PatientListViewPACU_Load(object sender, EventArgs e)
        {
            RefreshPatientDataTable(ExtendApplicationContext.Current.CurrentDateTime, ExtendApplicationContext.Current.CurrentSearchStr);
            operationRoomPandect1.OutPACUPandectClick += operationRoomPandect1_OutPACUPandectClick;
        }
        private void dgPACUList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                MED_PATIENT_CARD card = dgPACUList.Rows[e.RowIndex].DataBoundItem as MED_PATIENT_CARD;
                ExtendApplicationContext.Current.PatientContextExtend.PatientID = card.PATIENT_ID;
                ExtendApplicationContext.Current.PatientContextExtend.VisitID = card.VISIT_ID;
                ExtendApplicationContext.Current.PatientContextExtend.OperID = card.OPER_ID;
                ExtendApplicationContext.Current.PatientInformationExtend = card;
                EventHandler eventHandle = Events[_patientClick] as EventHandler;
                if (eventHandle != null)
                {
                    eventHandle(this, null);
                }
                if (dgPACUList.Columns[e.ColumnIndex].Name.Equals("ColAction") && dgPACUList.Rows[e.RowIndex].Cells["OperStatus"].Value != null)
                {
                    for (int i = 0; i < dgPACUList.Rows.Count; i++)
                    {
                        if (dgPACUList["ColumnPatientID", i].Value.ToString().Trim() == card.PATIENT_ID && Convert.ToInt32(dgPACUList["ColumnVisitID", i].Value) == card.VISIT_ID && Convert.ToInt32(dgPACUList["ColumnOperID", i].Value) == card.OPER_ID)
                        {
                            this.dgPACUList.Rows[i].Selected = true;
                            this.dgPACUList.CurrentCell = this.dgPACUList.Rows[i].Cells[0];
                            break;
                        }
                        else
                        {
                            this.dgPACUList.Rows[i].Selected = false;
                        }
                    }
                    if (card.OPER_STATUS_CODE == (int)OperationStatus.TurnToPACU || (card.OPER_STATUS_CODE > (int)OperationStatus.InPACU && !card.IN_PACU_DATE_TIME.HasValue))//dgPACUList.Rows[e.RowIndex].Cells["OperStatus"].Value.ToString().Contains("40")
                    {
                        dgPACUList.Rows[e.RowIndex].Cells["ColAction"].Value = Resources.pacu左表格_入室3;
                        RefreshPatientDataTable(card.PATIENT_ID, card.VISIT_ID, card.OPER_ID);
                        RefreshOperatingRoomList();
                        ConfirmationInPacu inPacu = new ConfirmationInPacu(card.PATIENT_ID, card.VISIT_ID, card.OPER_ID, false);
                        DialogHostFormPC dialogHostForm = new DialogHostFormPC("入室信息确认", inPacu.Width, inPacu.Height);
                        dialogHostForm.Child = inPacu;
                        dialogHostForm.ShowDialog();
                        if (inPacu.result == DialogResult.OK)
                        {
                            operationRoomPandect1.RefreshRoom(inPacu.PacuRoom, card.PATIENT_ID, card.VISIT_ID, card.OPER_ID);
                            RefreshPatientDataTable(ExtendApplicationContext.Current.CurrentDateTime, ExtendApplicationContext.Current.CurrentSearchStr);
                        }
                        //DragDropEffects effect = (sender as DataGridView).DoDragDrop(_selectedPatient, DragDropEffects.Move);
                        //if (effect == DragDropEffects.Move)
                        //{
                        //    foreach (DataGridViewRow row in dgPACUList.SelectedRows)
                        //    {
                        //        this.dgPACUList.Rows.Remove(row);
                        //    }
                        //}
                    }
                    else if (card.OPER_STATUS_CODE > (int)OperationStatus.TurnToPACU && card.IN_PACU_DATE_TIME.HasValue)
                    {
                        dgPACUList.Rows[e.RowIndex].Cells["ColAction"].Value = Resources.pacu左表格_出室3;
                        RefreshPatientDataTable(card.PATIENT_ID, card.VISIT_ID, card.OPER_ID);
                        patientSelectClick();
                    }
                }
            }
        }

        private void dgPACUList_DragDrop(object sender, DragEventArgs e)
        {
            Point point = dgPACUList.PointToClient(new Point(e.X, e.Y));
            int rowIndex = dgPACUList.HitTest(point.X, point.Y).RowIndex;
            int colIndex = dgPACUList.HitTest(point.X, point.Y).ColumnIndex;
            if (rowIndex < 0 || rowIndex >= dgPACUList.RowCount || colIndex < 0 || colIndex >= dgPACUList.ColumnCount)
            {
                return;
            }
            DataRowView rowView = (DataRowView)dgPACUList.Rows[rowIndex].DataBoundItem;
        }

        private void dgPACUList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void operationRoomPandect1_OutPACUPandectClick(object sender, EventArgs e)
        {
            RefreshPatientDataTable(ExtendApplicationContext.Current.CurrentDateTime, ExtendApplicationContext.Current.CurrentSearchStr);
        }

        private void checkEditOperEnd_CheckedChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void dgPACUList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            if (dgPACUList.Columns[e.ColumnIndex].HeaderText.Equals("操作"))
            {
                if (dgPACUList.Rows[e.RowIndex].Cells["OperStatus"].Value.ToString().Contains("40"))
                {
                    dgPACUList.Rows[e.RowIndex].Cells["ColAction"].Value = Resources.pacu左表格_入室2;
                }
                else if ((Convert.ToInt32(dgPACUList.Rows[e.RowIndex].Cells["OperStatus"].Value)) > 45)
                {
                    dgPACUList.Rows[e.RowIndex].Cells["ColAction"].Value = Resources.pacu左表格_出室2;
                }
            }

        }

        private void dgPACUList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            if (dgPACUList.Columns[e.ColumnIndex].HeaderText.Equals("操作"))
            {
                if (dgPACUList.Rows[e.RowIndex].Cells["OperStatus"].Value.ToString().Contains("40"))
                {
                    dgPACUList.Rows[e.RowIndex].Cells["ColAction"].Value = Resources.pacu左表格_入室1;
                }
                else if ((Convert.ToInt32(dgPACUList.Rows[e.RowIndex].Cells["OperStatus"].Value)) > 45)
                {
                    dgPACUList.Rows[e.RowIndex].Cells["ColAction"].Value = Resources.pacu左表格_出室1;
                }
            }
        }

        private void radioGroupStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void dgPACUList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                List<MED_PATIENT_CARD> infoList = _operationSelectInfoDT;
                if (e.ColumnIndex == 0)
                    infoList = _operationSelectInfoDT.OrderBy(x => x.SORT_NO).ToList().OrderBy(x => x.OPER_ROOM_NO).ToList();
                else if (e.ColumnIndex == 1)
                    infoList = _operationSelectInfoDT.OrderBy(x => x.INP_NO).ToList();
                else if (e.ColumnIndex == 2)
                    infoList = _operationSelectInfoDT.OrderBy(x => x.NAME).ToList();
                else if (e.ColumnIndex == 3)
                    infoList = _operationSelectInfoDT.OrderBy(x => x.SEX).ToList();
                else if (e.ColumnIndex == 4)
                    infoList = _operationSelectInfoDT.OrderBy(x => x.DATE_OF_BIRTH).ToList();
                else if (e.ColumnIndex == 5)
                    infoList = _operationSelectInfoDT.OrderBy(x => x.OPERATION_NAME).ToList();
                else
                    infoList = _operationSelectInfoDT;
                BindingSource BS = new BindingSource();
                BS.DataSource = infoList;
                dgPACUList.DataSource = BS;
            }
        }

        private void dgPACUList_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

        }

        private void dgPACUList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
