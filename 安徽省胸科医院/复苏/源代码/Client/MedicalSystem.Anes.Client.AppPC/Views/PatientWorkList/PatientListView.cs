using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using System.Linq.Expressions;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PatientListView : BaseView
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        protected int _normalCount = 20;
        public PatientListView()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Console.WriteLine("PatientListView —> InitializeComponent() [START]: " + DateTime.Now.ToString("mm:ss.fff"));
            InitializeComponent();
            Console.WriteLine("PatientListView —> InitializeComponent() [E N D]: " + DateTime.Now.ToString("mm:ss.fff"));
            Init();

            ControlAddEvent cotrol = new ControlAddEvent(Resources.急诊登记_1, Resources.急诊登记_1, Resources.急诊登记_2);
            cotrol.AddMouseMove(panelJZDJ);

        }

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
        /// <summary>
        /// 可选患者列表
        /// </summary>
        private List<PatientCard> _patients = new List<PatientCard>();
        /// <summary>
        /// 字典清单
        /// </summary>
        private List<MED_ANESTHESIA_DICT> _anesMethod;
        private List<MED_HIS_USERS> _doctorTable;
        private List<MED_HIS_USERS> _nurseTable;
        private List<MED_DIAGNOSIS_DICT> _diagnosisDictTable;
        private List<MED_OPERATION_DICT> _optionDictTable;
        private List<MED_ANESTHESIA_INPUT_DICT> _commonDictTable;
        private List<MED_DEPT_DICT> _deptDict;
        private List<MED_OPERATING_ROOM> _OperatingRoom;
        #endregion 变量
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


        private PatientCard _selectedPatient = null;
        public PatientCard SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
        }

        private PatientCard _showPatient = null;
        public PatientCard ShowPatient
        {
            get
            {
                return _showPatient;
            }
        }

        #endregion 属性
        #region 方法

        private void Init()
        {
            ///初始化字典
            if (!DesignMode)
            {
                _doctorTable = ExtendApplicationContext.Current.CommDict.HisUsersDict;
                _nurseTable = ExtendApplicationContext.Current.CommDict.HisUsersDict;
                _anesMethod = ExtendApplicationContext.Current.CommDict.AnesMethodDict;
                _diagnosisDictTable = ExtendApplicationContext.Current.CommDict.DiagnosisDict;
                _optionDictTable = ExtendApplicationContext.Current.CommDict.OperationNameDict;
                _commonDictTable = ExtendApplicationContext.Current.CommDict.AnesInputDictDict;
                _deptDict = ExtendApplicationContext.Current.CommDict.DeptDict;
                _OperatingRoom = ExtendApplicationContext.Current.CommDict.OperationRoomDict;

            }

        }

        /// <summary>
        /// 初始化 并设为第一页
        /// </summary>
        private void InitPatientDataTableAndPageIndex()
        {
            _pageIndex = 0;
            RefreshPatientDataTable();
        }
        /// <summary>
        /// 计算每页显示多少个信息
        /// </summary>
        /// <param name="isMin">是否最小化</param>
        /// <returns>返回每页显示多少个信息</returns>
        private int GetPatientContentCountForOnePage(bool isMin)
        {
            int res = 4;
            PatientCard patient = new PatientCard();
            int remainHeight = pnlBody.Height;
            res = (int)Math.Floor((double)remainHeight / (patient.Height + 8));
            patient.Dispose();
            patient = null;

            return res;
        }

        /// <summary>
        /// 重新获取数据
        /// </summary>
        public void RefreshPatientDataTable()
        {
            RefreshPatientDataTable("");
        }
        public void RefreshDoctorQualityDataTable()
        {
            doctorQualityControl1.DoctorQualityControlLoad();
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
                }
                if (_patients != null && _patients.Count > 0)
                {
                    foreach (PatientCard patientSearch in _patients)
                    {
                        if (patientSearch.PatCard != null && patientSearch.PatCard.PATIENT_ID == patientID && patientSearch.PatCard.VISIT_ID == visitID && patientSearch.PatCard.OPER_ID == operID)
                        {
                            patientSearch.PatCard = cardRow;
                            patientSearch.RefreshCard();
                            patientSearch.Refresh();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 刷新选定的患者
        /// </summary>
        public void RefreshSelectedPatient(PatientCard patient)
        {
            RefreshPatientDataTable(patient.PatCard.PATIENT_ID, patient.PatCard.VISIT_ID, patient.PatCard.OPER_ID);
            MED_PATIENT_CARD patientInformation = patient.PatCard;
            if (patientInformation != null)
            {
                ExtendAppContext.Current.PatientID = patientInformation.PATIENT_ID;
                ExtendAppContext.Current.VisitID = patientInformation.VISIT_ID;
                ExtendAppContext.Current.OperID = patientInformation.OPER_ID;
                ExtendApplicationContext.Current.PatientInformationExtend = patientInformation;
            }
            else
            {
                ExtendAppContext.Current.PatientID = "";
                ExtendApplicationContext.Current.PatientContextExtend.PatientID = "";
            }
        }

        public static OperationStatus GetOperationStatus(decimal operStatus)
        {
            try
            {
                return (OperationStatus)(int)operStatus;
            }
            catch
            {
                return OperationStatus.None;
            }
        }

        /// <summary>
        /// 筛选并刷新列表
        /// </summary>
        private void FilterData()
        {
            FilterData(null);
        }

        protected void SetFilter()
        {
            //Expression<Func<MED_PATIENT_CARD, bool>> expression = p => true;
            if (checkEditPersonal.IsChecked && !ExtendApplicationContext.Current.LoginUser.isMDSD)
            {
                string loginId = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
                //expression = expression.And(p => p.ANES_DOCTOR == loginId || p.FIRST_ANES_ASSISTANT == loginId || p.SECOND_ANES_ASSISTANT == loginId
                //    || p.THIRD_ANES_ASSISTANT == loginId || p.FOURTH_ANES_ASSISTANT == loginId || p.FIRST_OPER_NURSE == loginId || p.FIRST_SUPPLY_NURSE == loginId
                //    || p.SECOND_OPER_NURSE == loginId || p.SECOND_SUPPLY_NURSE == loginId || p.THIRD_OPER_NURSE == loginId || p.THIRD_SUPPLY_NURSE == loginId
                //    || p.FOURTH_OPER_NURSE == loginId || p.FOURTH_SUPPLY_NURSE == loginId);

                _operationSelectInfoDT = OperationsInfoDataTable.Where(p => p.ANES_DOCTOR == loginId || p.FIRST_ANES_ASSISTANT == loginId || p.SECOND_ANES_ASSISTANT == loginId
                    || p.THIRD_ANES_ASSISTANT == loginId || p.FOURTH_ANES_ASSISTANT == loginId || p.FIRST_OPER_NURSE == loginId || p.FIRST_SUPPLY_NURSE == loginId
                    || p.SECOND_OPER_NURSE == loginId || p.SECOND_SUPPLY_NURSE == loginId || p.THIRD_OPER_NURSE == loginId || p.THIRD_SUPPLY_NURSE == loginId
                    || p.FOURTH_OPER_NURSE == loginId || p.FOURTH_SUPPLY_NURSE == loginId).ToList();
            }
            if (comboBoxOperRoom.SelectedIndex >= 0 || !string.IsNullOrEmpty(comboBoxOperRoom.Text))
            {
                //expression = expression.And(p => p.OPER_ROOM_NO == comboBoxOperRoom.Text || string.IsNullOrEmpty(p.OPER_ROOM_NO));

                _operationSelectInfoDT = OperationsInfoDataTable.Where(p => p.OPER_ROOM_NO == comboBoxOperRoom.Text || string.IsNullOrEmpty(p.OPER_ROOM_NO)).ToList();
            }
            //_operationSelectInfoDT = OperationsInfoDataTable.Where(expression.Compile()).ToList();

            // _operationSelectInfoDT.OrderBy(x => x.OPER_ROOM_NO).ThenBy(x => x.SEQUENCE);

        }

        private int _patientCount = 4;

        private void FilterData(string patientID)
        {
            pnlBody.Controls.Clear();
            _patients.Clear();
            //if (OperationsInfoDataTable == null || OperationsInfoDataTable.Count == 0)
            //    return;
            if (OperationsInfoDataTable != null && OperationsInfoDataTable.Count > 0)
                SetFilter();
            if (_operationSelectInfoDT != null && _operationSelectInfoDT.Count > 0)
            {
                _patientCount = _operationSelectInfoDT.Count;
                labelPatCount.Text = _operationSelectInfoDT.Count.ToString();
            }
            else
            {
                _patientCount = 0;
                labelPatCount.Text = "0";
            }
            if (_operationSelectInfoDT != null && _operationSelectInfoDT.Count > 0)
            {
                List<MED_PATIENT_CARD> patCardOutList = _operationSelectInfoDT.Where(p => p.OPER_STATUS_CODE >= 35).ToList();
                if (patCardOutList != null && patCardOutList.Count > 0)
                    labelOutCount.Text = patCardOutList.Count.ToString();
                else
                    labelOutCount.Text = "0";
            }
            else
            {
                labelOutCount.Text = "0";
            }
            int top = 12;
            int left = 2;
            int count = 0;
            if (_patientCount < 8) _patientCount = 8;
            else if (_patientCount % 2 != 0) _patientCount = _patientCount + 1;

            while (_patients.Count < _patientCount)
            {
                PatientCard patient = new PatientCard();
                patient.Visible = false;
                _patients.Add(patient);
                patient.SelectNum = _patients.Count;
                pnlBody.Controls.Add(patient);
                if (_operationSelectInfoDT != null && count < _operationSelectInfoDT.Count)
                {
                    patient.Clicked += new EventHandler(patient_Click);
                    patient.DoubleClicked += new EventHandler(patient_DoubleClick);
                }
                patient.Left = left;
                patient.Top = top;
                left += patient.Width + 8;
                count++;
                if (count % 2 == 0)
                {
                    left = 3;
                    top += patient.Height + 25;
                }
                patient.BringToFront();
            }

            foreach (PatientCard patient in _patients)
            {
                patient.CancelFocus();
            }
            while (_patients.Count > _patientCount)
            {
                PatientCard patient = _patients[_patients.Count - 1];
                pnlBody.Controls.Remove(patient);
                _patients.Remove(patient);
            }
            //string filtString = "";
            int patientIndex = 0;
            for (int i = 0; i < _patients.Count; i++)
            {
                if (_operationSelectInfoDT != null && (_operationSelectInfoDT.Count - 1) >= i)
                {
                    MED_PATIENT_CARD row = _operationSelectInfoDT[i];
                    PatientCard patient = _patients[patientIndex];
                    patient.PatCard = row;
                    patientIndex++;

                    toolTip1.SetToolTip(patient, "鼠标双击选中");
                    patient.RefreshCard();

                    if (row != null
                        && row.PATIENT_ID == ExtendApplicationContext.Current.PatientContextExtend.PatientID
                        && row.VISIT_ID == ExtendApplicationContext.Current.PatientContextExtend.VisitID
                        && row.OPER_ID == ExtendApplicationContext.Current.PatientContextExtend.OperID)
                        patient.Selected = true;

                    patient.Visible = true;
                    patient.Refresh();
                    if (patientIndex >= _patientCount) break;
                }
                else
                {
                    PatientCard patient = _patients[patientIndex];
                    patient.PatCard = null;
                    patientIndex++;
                    patient.RefreshCard();
                    patient.Visible = true;
                    patient.Refresh();
                    if (patientIndex >= _patientCount) break;
                }

            }

            for (int i = _patients.Count - 1; i >= patientIndex; i--)
                _patients[i].Visible = false;
            Visible = true;
        }
        private List<MED_PATIENT_CARD> SortOperationTable(List<MED_PATIENT_CARD> operationsInfoDataTable)
        {
            List<MED_PATIENT_CARD> res = null;
            try
            {
                if (ExtendApplicationContext.Current.AppType != ApplicationType.PACU)
                {
                    List<MED_PATIENT_CARD> rows = operationsInfoDataTable.Where(x => Convert.ToInt32(x.OPER_STATUS_CODE) >= 5 && Convert.ToInt32(x.OPER_STATUS_CODE) < 35).OrderBy(x => x.OPER_STATUS_CODE).ToList();
                    List<MED_PATIENT_CARD> rows00 = operationsInfoDataTable.Where(x => x.OPER_STATUS_CODE == null || (Convert.ToInt32(x.OPER_STATUS_CODE) >= 0 && Convert.ToInt32(x.OPER_STATUS_CODE) < 5)).OrderBy(x => x.SORT_NO).ToList();
                    List<MED_PATIENT_CARD> rows25 = operationsInfoDataTable.Where(x => Convert.ToInt32(x.OPER_STATUS_CODE) >= 35).OrderBy(x => x.SORT_NO).ToList();
                    List<MED_PATIENT_CARD> t = new List<MED_PATIENT_CARD>();
                    if (rows != null && rows.Count > 0)
                    {
                        rows.ForEach(row =>
                        {
                            t.Add(row);
                        });
                    }
                    if (rows00 != null && rows00.Count > 0)
                    {
                        rows00.ForEach(row =>
                        {
                            t.Add(row);
                        });
                    }
                    if (rows25 != null && rows25.Count > 0)
                    {
                        rows25.ForEach(row =>
                        {
                            t.Add(row);
                        });
                    }
                    res = t;
                }
                //复苏
                else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {
                    List<MED_PATIENT_CARD> rows45 = operationsInfoDataTable.Where(x => Convert.ToInt32(x.OPER_STATUS_CODE) == 45).ToList();
                    List<MED_PATIENT_CARD> rows40 = operationsInfoDataTable.Where(x => (Convert.ToInt32(x.OPER_STATUS_CODE) >= 40 && Convert.ToInt32(x.OPER_STATUS_CODE) < 45)).ToList();
                    List<MED_PATIENT_CARD> rows46 = operationsInfoDataTable.Where(x => Convert.ToInt32(x.OPER_STATUS_CODE) > 45).ToList();
                    List<MED_PATIENT_CARD> t = new List<MED_PATIENT_CARD>();
                    if (rows45 != null && rows45.Count > 0)
                    {
                        rows45.ForEach(row =>
                        {
                            t.Add(row);
                        });
                    }
                    if (rows40 != null && rows40.Count > 0)
                    {
                        rows40.ForEach(row =>
                        {
                            t.Add(row);
                        });
                    }
                    if (rows46 != null && rows46.Count > 0)
                    {
                        rows46.ForEach(row =>
                        {
                            t.Add(row);
                        });
                    }
                    res = t;
                }
            }
            catch
            {

            }
            return res;


        }
        /// <summary>
        /// 重新获取数据并定位当前患者
        /// </summary>
        public void RefreshPatientDataTable(string patientID)
        {
            Cursor oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;
            string operRoom = ExtendApplicationContext.Current.OperRoom;
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                DateTime dt = accountRepository.GetServerTime().Data;
                worker.DoWork += delegate (object sender, DoWorkEventArgs e)
                {
                    OperationsInfoDataTable = patientInfoRepository.GetPatientListDataTable(
                        dt, operRoom, TransStr(ExtendApplicationContext.Current.HospBranchCode)).Data;
                };
                worker.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
                {
                    if (OperationsInfoDataTable != null && OperationsInfoDataTable.Count > 0)
                        OperationsInfoDataTable = SortOperationTable(OperationsInfoDataTable);
                    if (OperationsInfoDataTable == null || OperationsInfoDataTable.Count == 0)
                    {
                        foreach (Control ctrl in pnlBody.Controls)
                        {
                            ctrl.Visible = false;
                        }
                        labelPatCount.Text = "0";
                        labelOutCount.Text = "0";
                    }
                    else
                    {
                        FilterData(patientID);
                    }

                    Cursor = oldCursor;
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
        private int _pageIndex = 0;

        //private void SelectPatient(int index)
        //{
        //    if (_patients.Count > index && index >= 0)
        //    {
        //        SelectPatient(_patients[index]);
        //    }
        //}
        private void SelectPatient(PatientCard patCard)
        {
            if (ExtendAppContext.Current.PatientID == patCard.PatCard.PATIENT_ID && ExtendAppContext.Current.VisitID == patCard.PatCard.VISIT_ID
                && ExtendAppContext.Current.OperID == patCard.PatCard.OPER_ID)
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
            RefreshPatientDataTable(patCard.PatCard.PATIENT_ID, patCard.PatCard.VISIT_ID, patCard.PatCard.OPER_ID);
            foreach (PatientCard patient in _patients)
            {
                if (!patient.Equals(patCard))
                {
                    patient.Selected = false;
                }
            }
            patCard.Selected = true;
            _selectedPatient = patCard;

            //双击选中，全局变量赋值
            MED_PATIENT_CARD patientInformation = patCard.PatCard;
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
            ExtendApplicationContext.Current.PatientInformationExtend = patCard.PatCard;
            TransOperationName();
            ShowPatientStatus(patCard);
            EventHandler eventHandle = Events[_selectChanged] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        private void TransOperationName()
        {
            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContextExtend.PatientID))
            {
                MED_OPERATION_MASTER operationMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                    ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                if (operationMaster != null)
                {
                    List<MED_OPERATION_NAME> operationName = operationInfoRepository.GetOperNameList(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                        ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                    if (operationName != null && operationName.Count > 0)
                    {
                        string operName = "";
                        operationName.ForEach(row =>
                        {
                            operName += "," + row.OPER_NAME;
                        });
                        operationMaster.OPERATION_NAME = operName.Substring(1);
                        operationInfoRepository.SaveOperMaster(operationMaster);
                    }
                }
            }
        }

        private void Search()
        {
            InitPatientDataTableAndPageIndex();
        }
        public void Search(string searchContent)
        {
            if (!this.doctorQualityControl1.SearchTomorrowFilterData(searchContent))
            {
                if (_operationSelectInfoDT != null)
                {
                    List<MED_PATIENT_CARD> patientCardList = _operationSelectInfoDT.Where(p => p.PATIENT_ID == searchContent || p.INP_NO == searchContent || p.NAME == searchContent).ToList();
                    if (patientCardList != null && patientCardList.Count > 0)
                    {
                        MED_PATIENT_CARD patientCard = patientCardList[0];
                        foreach (PatientCard patient in _patients)
                        {
                            if (patient.PatCard != null && patient.PatCard.PATIENT_ID == patientCard.PATIENT_ID && patient.PatCard.VISIT_ID == patientCard.VISIT_ID && patient.PatCard.OPER_ID == patientCard.OPER_ID)
                            {
                                patient.Selected = true;
                                patient.Focus();
                                _selectedPatient = patient;
                                //设置滚动条
                                medScrollbar1.Value = pnlBody.VerticalScroll.Value;
                                medScrollbar1.Maximum = pnlBody.VerticalScroll.Maximum;
                                medScrollbar1.LargeChange = pnlBody.VerticalScroll.LargeChange;
                            }
                            else
                            {
                                patient.Selected = false;
                            }
                        }
                        this.doctorQualityControl1.FinishedYesterdaySelect();
                        MessageQueue.AddMessage("为您查找到今日手术患者" + patientCard.NAME + " " + patientCard.SEX + "  " + patientCard.AGE, Color.Black);
                    }
                    else
                    {
                        foreach (PatientCard patient in _patients)
                        {
                            patient.Selected = false;
                        }
                        if (!this.doctorQualityControl1.SearchYesterdayFilterData(searchContent))
                        {
                            MessageQueue.AddMessage("没有您要查找的患者信息", Color.Black);
                        }
                    }
                }
                else
                {
                    foreach (PatientCard patient in _patients)
                    {
                        patient.Selected = false;
                    }
                    if (!this.doctorQualityControl1.SearchYesterdayFilterData(searchContent))
                    {
                        MessageQueue.AddMessage("没有您要查找的患者信息", Color.Black);
                    }
                }
            }
            else
            {
                foreach (PatientCard patient in _patients)
                {
                    patient.Selected = false;
                }
                this.doctorQualityControl1.FinishedYesterdaySelect();
            }
        }
        #endregion 方法
        #region 事件

        private void patient_DoubleClick(object sender, EventArgs e)
        {
            //空着  先判断是否有术中权限
            SelectPatient(sender as PatientCard);
            ShowPatientInformation(sender as PatientCard);
            EventHandler eventHandle = Events[_patientDoubleClick] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(sender, e);
            }
        }

        int currentSelectNum = -1;//点击患者列表闪烁现象
        private void patient_Click(object sender, EventArgs e)
        {
            //foreach (PatientCard patient in _patients)
            //{
            //    if (patient.SelectNum == currentSelectNum)
            //    {
            //        patient.CancelFocus();
            //        break;
            //    }
            //}
            if ((sender as PatientCard) != null)
                ShowPatientInformation(sender as PatientCard);
        }
        /// <summary>
        /// 根据状态判断流程
        /// </summary>
        private void ShowPatientStatus(PatientCard patCard)
        {
            if (ApplicationConfiguration.ApplicationPatterns.Equals("0") && AccessControl.CheckModifyRightForOperator("麻醉记录单"))
            {
                List<MED_OPERATING_ROOM> roomList = comnDictRepository.GetOperatingRoomList("0").Data.Where(p => p.ROOM_NO == ExtendApplicationContext.Current.OperRoomNo && p.DEPT_CODE == ExtendApplicationContext.Current.OperRoom).ToList();
                if (roomList != null && roomList.Count > 0)
                {
                    MED_OPERATING_ROOM operRoom = roomList[0];
                    if (string.IsNullOrEmpty(patCard.PatCard.OPER_STATUS_CODE.ToString()) || patCard.PatCard.OPER_STATUS_CODE < 5)
                    {
                        if (string.IsNullOrEmpty(operRoom.PATIENT_ID))
                        {
                            ConfirmationSureBase sure = new ConfirmationSureBase(patCard.PatCard, Convert.ToDecimal(ExtendApplicationContext.Current.EventNo));
                            DialogHostFormPC dialogHostForm = new DialogHostFormPC("入室信息确认", sure.Width, sure.Height);
                            dialogHostForm.Text = "信息确认";
                            dialogHostForm.Child = sure;
                            dialogHostForm.ShowDialog();
                            //确认患者信息
                        }
                        else
                        {
                            MED_PATIENT_CARD cardRow = patientInfoRepository.GetPatCard(operRoom.PATIENT_ID, (int)operRoom.VISIT_ID, (int)operRoom.OPER_ID).Data;
                            MessageBoxFormPC.Show("该手术间" + operRoom.ROOM_NO + "已存在患者【" + cardRow.NAME + " " + cardRow.INP_NO + "】，请换其他手术间！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (patCard.PatCard.OPER_STATUS_CODE < 35)
                    {
                        if (!string.IsNullOrEmpty(operRoom.PATIENT_ID) && !operRoom.PATIENT_ID.Equals(patCard.PatCard.PATIENT_ID))
                        {
                            MED_PATIENT_CARD cardRow = patientInfoRepository.GetPatCard(operRoom.PATIENT_ID, (int)operRoom.VISIT_ID, (int)operRoom.OPER_ID).Data;
                            MessageBoxFormPC.Show("该手术间" + operRoom.ROOM_NO + "已存在患者【" + cardRow.NAME + " " + cardRow.INP_NO + "】，请换其他手术间！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (patCard.PatCard.OPER_ROOM_NO != ExtendApplicationContext.Current.OperRoomNo)
                        {
                            if (DialogResult.Yes == MessageBoxFormPC.Show("显示非本手术间手术，是否更换手术间？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                MED_OPERATION_MASTER operationMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                      ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                                if (operationMaster != null)
                                {
                                    operationMaster.OPER_ROOM_NO = ExtendApplicationContext.Current.OperRoomNo;
                                    operationInfoRepository.SaveOperMaster(operationMaster);
                                }
                                ClearPatientRoom(ExtendApplicationContext.Current.PatientContextExtend.PatientID);
                                ClearPatientMonitor(ExtendApplicationContext.Current.PatientContextExtend.PatientID, "0");
                                List<MED_OPERATING_ROOM> operList = comnDictRepository.GetOperatingRoomList("0").Data;
                                if (operList != null && operList.Count > 0)
                                {
                                    foreach (MED_OPERATING_ROOM room in operList)
                                    {
                                        if (room.ROOM_NO == ExtendApplicationContext.Current.OperRoomNo)
                                        {
                                            room.PATIENT_ID = patCard.PatCard.PATIENT_ID;
                                            room.VISIT_ID = patCard.PatCard.VISIT_ID;
                                            room.OPER_ID = patCard.PatCard.OPER_ID;
                                            comnDictRepository.SaveOperatingRoom(room);
                                            break;
                                        }
                                    }
                                }
                                // CommDictService.SaveOperatingRommList(operList);
                                SelectMonitor monitor = new SelectMonitor(patCard.PatCard, 1, ExtendApplicationContext.Current.OperRoomNo.ToString(), false);
                                monitor.Save();
                            }
                            else
                            {
                                //权限改为False  术中只读
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        ///清除患者手术间安排
        /// </summary>
        /// <param name="patientID"></param>
        public bool ClearPatientRoom(string patientID)
        {
            bool result = false;
            List<MED_OPERATING_ROOM> operRoomList = comnDictRepository.GetAllOperatingRoomList().Data;

            if (operRoomList != null && operRoomList.Count > 0)
            {
                foreach (MED_OPERATING_ROOM row in operRoomList)
                {
                    if (!string.IsNullOrEmpty(row.PATIENT_ID) && row.PATIENT_ID.Equals(patientID))
                    {
                        row.PATIENT_ID = null;
                        row.VISIT_ID = null;
                        row.OPER_ID = null;
                        if (comnDictRepository.SaveOperatingRoom(row).Data > 0)
                        {
                            result = true;
                        }
                    }
                }

            }
            return result;
        }


        /// <summary>
        ///清除患者设备安排
        /// </summary>
        /// <param name="patientID"></param>
        public bool ClearPatientMonitor(string patientID, string eventNo)
        {
            bool result = false;
            List<MED_MONITOR_DICT> monitorList = comnDictRepository.GetMonitorDictList(eventNo).Data;
            if (monitorList != null && monitorList.Count > 0)
            {
                foreach (MED_MONITOR_DICT row in monitorList)
                {
                    if (!string.IsNullOrEmpty(row.PATIENT_ID) && row.PATIENT_ID.Equals(patientID))
                    {
                        row.PATIENT_ID = null;
                        row.VISIT_ID = null;
                        row.OPER_ID = null;
                    }
                }
                if (comnDictRepository.SaveMonitorDictList(monitorList).Data > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        /// <summary>
        /// 显示当前患者详细信息
        /// </summary>
        private void ShowPatientInformation(PatientCard patient)
        {
            currentSelectNum = patient.SelectNum;
            _showPatient = patient;
            foreach (PatientCard pat in _patients)
            {
                if (patient.PatCard != pat.PatCard)
                {
                    pat.Selected = false;
                }
                else
                    pat.Selected = true;
            }
            EventHandler eventHandle = Events[_patientClick] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        private bool _isMin = false;
        #endregion 事件

        private void comboBoxOperRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pageIndex = 0;
            FilterData();
        }
        private void PatientListView_Load(object sender, EventArgs e)
        {
            if (_optionDictTable != null && _optionDictTable.Count > 0)
            {
                List<MED_OPERATING_ROOM> roomList = _OperatingRoom.Where(p => p.BED_TYPE == "0").ToList();
                foreach (MED_OPERATING_ROOM room in roomList)
                {
                    comboBoxOperRoom.Properties.Items.Add(room.ROOM_NO);
                }
            }
            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.OperRoomNo))
                comboBoxOperRoom.Text = ExtendApplicationContext.Current.OperRoomNo;
            InitPatientDataTableAndPageIndex();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                if (!DesignMode)
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                    return cp;
                }
                return base.CreateParams;
            }
        }

        private void panelJZDJ_Click(object sender, EventArgs e)
        {
            //List<MED_OPERATING_ROOM> roomList = CommDictService.GetOperatingRoomList("0").Where(p => p.ROOM_NO == ExtendApplicationContext.Current.OperRoomNo).ToList();
            //if (roomList != null && roomList.Count > 0)
            //{
            //    MED_OPERATING_ROOM operRoom = roomList[0];
            //    if (!string.IsNullOrEmpty(operRoom.PATIENT_ID))
            //    {
            //        MED_PATIENT_CARD cardRow = PatientInfoService.GetPatCard(operRoom.PATIENT_ID, (int)operRoom.VISIT_ID, (int)operRoom.OPER_ID);
            //        MessageBoxFormPC.Show("该手术间" + operRoom.ROOM_NO + "已存在患者【" + cardRow.NAME + " " + cardRow.INP_NO + "】，请换其他手术间！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}
            ConfirmationSureBase emergencyControl = new ConfirmationSureBase(null, 0);
            DialogHostFormPC dialogHostForm = new DialogHostFormPC("急诊登记", emergencyControl.Width, emergencyControl.Height);
            dialogHostForm.Text = "急诊登记";
            dialogHostForm.Child = emergencyControl;
            dialogHostForm.ShowDialog();
            if (emergencyControl.result == DialogResult.OK)
            { RefreshPatientDataTable(); }
        }


        private void checkEditPersonal_CheckedChange(object sender, EventArgs e)
        {
            FilterData();
        }
        private void comboBoxOperRoom_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FilterData();
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {
            //Color border = System.Drawing.Color.Silver;
            //ControlPaint.DrawBorder(e.Graphics, pnlBody.ClientRectangle,
            //border, 1, ButtonBorderStyle.Solid, //左边
            //border, 1, ButtonBorderStyle.Solid, //上边
            //border, 1, ButtonBorderStyle.Solid, //右边
            //border, 1, ButtonBorderStyle.Solid);//底边
            ControlPaint.DrawBorder(e.Graphics,
                                this.pnlBody.ClientRectangle,
                                Color.Silver,
                                1,
                                ButtonBorderStyle.Solid,
                                Color.Silver,
                                1,
                                ButtonBorderStyle.Solid,
                                Color.Silver,
                                1,
                                ButtonBorderStyle.Solid,
                                Color.Silver,
                                1,
                                ButtonBorderStyle.Solid);

        }
    }
}
