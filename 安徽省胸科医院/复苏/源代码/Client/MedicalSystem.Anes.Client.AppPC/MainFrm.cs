using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.Anes.Document.Designer;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class MainFrm : DialogHostMainFormPC, ITimeTick
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();

        CommonRepository commonRepository = new CommonRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        UserRepository userRepository = new UserRepository();

        public MainFrm()
        {
            MainTickFrm = this;
            InitializeComponent();
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.DoubleBuffered = true;
            //激活窗体的双缓冲技术,可以注释掉看看是什么效果
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.ControlBox = false;
            //this.Text = "";
            //this.WindowState = FormWindowState.Maximized;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            tableControlMenuCourseOfDisease.Visible = false;
            tableControlMenuInstruments.Visible = false;
            tableControlMenuOperation.Visible = false;

            List<string> _Items = new List<string>();
            _Items.Add("切换用户");
            _Items.Add("修改密码");
            _Items.Add("关    于");
            buttonDownMenus.Items = _Items;
            buttonDownMenus.InitItem();
            txtScheduledTime.DateTime = DateTime.Now;
            ExtendApplicationContext.Current.CurrentDateTime = DateTime.Now;

            // 启动跨平台消息的连接
            TransMessageManager.Instance.OpenConnection();
        }

        protected void InvalidateEx()
        {
            if (Parent == null)
                return;
            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //do not allow the background to be painted
        }
        protected override void OnResize(EventArgs eventargs)
        {
            this.InvalidateEx();
        }

        /// <summary>
        /// 选择患者界面
        /// </summary>
        public PatientListView _patients = null;
        public PatientListViewPACU _patientsPACU = null;
        protected DataTemplate _dataTemplate;
        //截获窗体最大化最小化消息

        private bool isLockSystem = false;
        private void InitalizeUI()
        {
            //获取配置信息
            try
            {
                currentUserInfo.UserName = ExtendApplicationContext.Current.LoginUser.USER_NAME;
                //异步加载
                using (BackgroundWorker worker = new BackgroundWorker())
                {
                    worker.DoWork += delegate(object sender, DoWorkEventArgs e)
                    {
                        LoadMonitorFunctionCodeDict();
                        LoadUserPermissions();
                    };
                    worker.RunWorkerAsync();
                }
                InitWorkSpaceControl();
                InitTopBarControl();
                InitMecicalDocBarControl();
                if (_patients != null)
                    _patients.Focus();
                //this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
                this.Opacity = 100;
                SplashFormHelper.HideSplashForm();
            }
            catch (Exception ex)
            {
                SplashFormHelper.HideSplashForm();
                ExceptionHandler.Handle(ex);
                Application.Exit();
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            tableControlMenuCourseOfDisease.Left = this.Width - tableControlMenuCourseOfDisease.Width;
            tableControlMenuCourseOfDisease.ThisLeft = this.Width - tableControlMenuCourseOfDisease.Width;
            tableControlMenuInstruments.Left = this.Width - tableControlMenuInstruments.Width;
            tableControlMenuInstruments.ThisLeft = this.Width - tableControlMenuInstruments.Width;
            tableControlMenuOperation.Left = this.Width - tableControlMenuOperation.Width;
            tableControlMenuOperation.ThisLeft = this.Width - tableControlMenuOperation.Width;

            if (DesignMode)
            {
                return;
            }
            InitMainForm();
        }
        public void InitMainForm()
        {
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            LoadingFrm.EndWithMainFrm = true;
            ExtendApplicationContext.Current.SystemCurrentProcess = ProgramProcess.SystemBeforeLoad;
            InitalizeSystem();
            InitalizeUI();
            ExtendApplicationContext.Current.SystemCurrentProcess = ProgramProcess.SystemAfterLoad;
            timerResponse.Start();
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    PopulateCodeTables();
                };
                worker.RunWorkerAsync();
            };
        }
        /// <summary>
        /// 加载字典表数据
        /// </summary>
        private void PopulateCodeTables()
        {
            List<KeyValue> list = DictTableNamesDropDownEditor.Tables;
            foreach (KeyValue keyValue in list)
            {
                if (!ExtendApplicationContext.Current.CodeTables.ContainsKey(keyValue.Value))
                {
                    if (keyValue.Value.ToUpper() == "MED_ANESTHESIA_INPUT_DICT")
                    {
                        DataTable dt = ModelHelper<MED_ANESTHESIA_INPUT_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.AnesInputDictDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_DIAGNOSIS_DICT")
                    {
                        DataTable dt = ModelHelper<MED_DIAGNOSIS_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.DiagnosisDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_OPERATION_DICT")
                    {
                        DataTable dt = ModelHelper<MED_OPERATION_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.OperationNameDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_HIS_USERS")
                    {
                        DataTable dt = ModelHelper<MED_HIS_USERS>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.HisUsersDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_ANESTHESIA_DICT")
                    {
                        DataTable dt = ModelHelper<MED_ANESTHESIA_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.AnesMethodDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_DEPT_DICT")
                    {
                        DataTable dt = ModelHelper<MED_DEPT_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.DeptDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_MONITOR_FUNCTION_CODE")
                    {
                        DataTable dt = ModelHelper<MED_MONITOR_FUNCTION_CODE>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.MonitorFuntionDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_BLOOD_GAS_DICT")
                    {
                        DataTable dt = ModelHelper<MED_BLOOD_GAS_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.BloodGasDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_EVENT_DICT")
                    {
                        DataTable dt = ModelHelper<MED_EVENT_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.EventDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_UNIT_DICT")
                    {
                        DataTable dt = ModelHelper<MED_UNIT_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.UnitDictExt);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_ADMINISTRATION_DICT")
                    {
                        DataTable dt = ModelHelper<MED_ADMINISTRATION_DICT>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.AdministrationDictExt);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "MED_OPERATING_ROOM")
                    {
                        DataTable dt = ModelHelper<MED_OPERATING_ROOM>.ConvertListToDataTable(ExtendApplicationContext.Current.CommDict.OperationRoomDict);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                }
            }
            if (ExtendApplicationContext.Current.CommDict.EventSortDict == null)
                ExtendApplicationContext.Current.CommDict.EventSortDict = comnDictRepository.GetEventSortList(ExtendApplicationContext.Current.LoginUser.LOGIN_NAME).Data;
            if (ApplicationConfiguration.IsConnACS)
            {
                DataTable dt = commonRepository.GetAcsArticleKeyWord().Data;

                ExtendApplicationContext.Current.CodeTables.Add("STANDARD_ARTICLE_KEYWORD", dt);
            }
        }
        /// <summary>
        /// 初始化系统参数
        /// </summary>
        private void InitalizeSystem()
        {
            if (ApplicationConfiguration.IsPACUProgram)
            {
                //制定PACU
                ExtendApplicationContext.Current.AppType = ApplicationType.PACU;
                //制定EventNo
                ExtendApplicationContext.Current.EventNo = "1";
            }
            // PopulateCodeTables();
            Text = ApplicationConfiguration.AppTitle;
            try
            {
                string customSettingKey = ApplicationConfiguration.CustomSettingProvider;
                Type t = Type.GetType(customSettingKey);
                ICustomSetting customSetting = Activator.CreateInstance(t) as ICustomSetting;
                if (customSetting != null)
                {
                    customSetting.InitCustomSetting();
                }
                else
                {
                    Exception e = new Exception("自定义 客户化模块加载失败，请检查配置，启动系统默认 客户化模块！");
                    e.Source = "加载  客户化模块";
                    ExceptionHandler.Handle(e);
                }
            }
            catch (Exception ex)
            {
                Exception e = new Exception("自定义 客户化模块加载失败，请检查配置，启动系统默认 客户化模块！");
                e.Source = ex.StackTrace;
                ExceptionHandler.Handle(e);
            }
            List<MED_HOSPITAL_CONFIG> titleList = ExtendApplicationContext.Current.CommDict.HosotalConfigDict;
            if (titleList != null && titleList.Count > 0)
            {
                ExtendApplicationContext.Current.HospitalID = titleList[0].HOSPITAL_ID;
                ExtendApplicationContext.Current.HospitalName = titleList[0].HOSPITAL_NAME;
            }
            DateTime serverTime = accountRepository.GetServerTime().Data;
            if (CommonSysemHelper.SetLocalSystemDate(serverTime))
            {
                accountRepository.SetLocalSystemDate();
            }
        }
        /// <summary>
        /// 加载用户登录权限
        /// </summary>
        private void LoadUserPermissions()
        {
            if (ExtendApplicationContext.Current.LoginUser.MDSD_APPLICATION != null && ExtendApplicationContext.Current.LoginUser.MDSD_APPLICATION.MENU_LIST.Count > 0)
            {
                foreach (MDSD.Permission.Domain.MDSD_MENU menuList in ExtendApplicationContext.Current.LoginUser.MDSD_APPLICATION.MENU_LIST)
                {
                    if (menuList.SUB_MENU_LIST.Count > 0)
                    {
                        foreach (MDSD.Permission.Domain.MDSD_MENU menu in menuList.SUB_MENU_LIST)
                        {
                            AccessControl.AddPermission(menu.MENU_KEY, menuList.MENU_KEY);
                        }
                    }
                }
            }
            try
            {
                //读取配置 ，加载 PermissionProvider
                string permissionProvider = ApplicationConfiguration.PermissionProvider;
                Type t = Type.GetType(permissionProvider);
                PermissionProvider permissionProviderCustom = Activator.CreateInstance(t) as PermissionProvider;
                if (permissionProviderCustom != null)
                {
                    AccessControl.PermissionProviderCustom = permissionProviderCustom;
                }
            }
            catch (Exception ex)
            {

                Exception e = new Exception("自定义权限模块加载失败，请检查配置，启动系统默认权限模块！");
                e.Source = ex.Source;
                ExceptionHandler.Handle(e);
            }
        }
        #region "顶端栏目项目  相关事件处理"
        /// <summary>
        /// 初始化上边栏目项目
        /// </summary>
        private void InitTopBarControl()
        {
            try
            {
                ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.NoPatient, ApplicationConfiguration.NoPatientButtons);
                ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.PeroperativePatient, ApplicationConfiguration.PeroperativePatientButtons);
                ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.PostoperativePatient, ApplicationConfiguration.PostoperativePatientButtons);
                ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.AnesthesiaRecord, ApplicationConfiguration.AnesthesiaRecordButtons);
                ExtendApplicationContext.Current.StatusButtonStrList.Add(ProgramStatus.PACURecord, ApplicationConfiguration.PACUButtons);

                //获取当前状态状态按钮
                string text = ApplicationConfiguration.PatientStatusButtons;
                workSpaceControl1.toolBarsControl1.CreatePatientStatusButtons(text);
                this.workSpaceControl1.toolBarsControl1.SetPatientStatusAction(new PandectOperationStatusAction());
                this.workSpaceControl1.toolBarsControl1.MainFormRef = this;
                this.workSpaceControl1.toolBarsControl1.RefreshStatusEvent += new EventHandler(RefreshStatus);

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }
        private void TopBarLoad()
        {
            List<MED_PATIENT_CARD> patientCard = new List<MED_PATIENT_CARD>();
            DateTime dayNow = accountRepository.GetServerTime().Data;
        }
        #endregion


        #region "PatientListView 选中 事件相关处理"
        /// <summary>
        /// 选患者界面单击患者事件-显示右侧详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patients_PatientClick(object sender, EventArgs e)
        {
            PatientCard patient = (sender as PatientListView).ShowPatient;
            if (patient == null) patient = (sender as PatientListView).SelectedPatient;
            if (patient != null)
            {
                if (_patients != null)
                {
                    this._patients.RefreshSelectedPatient(patient);
                }
            }
        }
        private void patients_PatientClick2(object sender, EventArgs e)
        {
            tableControlMenuCourseOfDisease.Visible = true;
            tableControlMenuInstruments.Visible = true;
            tableControlMenuOperation.Visible = true;
            if (!ApplicationConfiguration.IsPACUProgram)
                ExtendApplicationContext.Current.SystemStatus = ProgramStatus.AnesthesiaRecord;
            else
                ExtendApplicationContext.Current.SystemStatus = ProgramStatus.PACURecord;
            if (ExtendApplicationContext.Current.PatientInformationExtend != null)
            {
                ExtendApplicationContext.Current.MED_OPERATION_MASTER
                   = operationInfoRepository.GetOperMaster(
                       ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID,
                       ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID,
                       ExtendApplicationContext.Current.PatientInformationExtend.OPER_ID).Data;

                ExtendApplicationContext.Current.MED_PAT_MASTER_INDEX
                    = operationInfoRepository.GetPatMasterIndex(
                        ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID).Data;

                ExtendApplicationContext.Current.MED_PAT_VISIT
                    = operationInfoRepository.GetPatVisit(
                        ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID,
                        ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID).Data;
            }
            OperationLoad();
        }

        private void patients_SelectChanged2(object sender, EventArgs e)
        {
            BaseDoc doc = workSpaceControl1.CurrentControl as BaseDoc;
            if (doc != null)
            {
                string oldName = doc.Name;
                patients_SelectChanged(sender, e);

                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {
                    if (AccessControl.CheckModifyRightForOperator(doc.Name) && ApplicationConfiguration.ApplicationPatterns == "0")//有Modify权限
                    {
                        doc.SetAllControlEditable(true);
                    }
                    else
                    {
                        doc.SetAllControlEditable(false);
                    }

                    if (doc.AllowSingleDocModify())
                    {
                        doc.SetAllControlEditable(true);
                    }
                }

                if (workSpaceControl1.CurrentControl.Name != oldName)
                {
                    workSpaceControl1.AddDocToWorkSpace(doc);
                    doc.RefreshData(true);
                    tableControlMenuCourseOfDisease.Visible = true;
                    tableControlMenuInstruments.Visible = true;
                    tableControlMenuOperation.Visible = true;

                }
            }
        }

        /// <summary>
        /// 选患者界面选中患者后事件-主界面同步更新->激活患者默认操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void patients_SelectChanged(object sender, EventArgs e)
        {
            if (!ApplicationConfiguration.IsPACUProgram)
                ExtendApplicationContext.Current.SystemStatus = ProgramStatus.AnesthesiaRecord;
            else
                ExtendApplicationContext.Current.SystemStatus = ProgramStatus.PACURecord;
            tableControlMenuCourseOfDisease.Visible = true;
            tableControlMenuInstruments.Visible = true;
            tableControlMenuOperation.Visible = true;
            ChangePatient();
            OperationLoad();
        }
        private void doctorQuality_TomorrowCellClick(object sender, EventArgs e)
        {
            ChangePatient();
        }
        private void doctorQuality_YesterdayCellClick(object sender, EventArgs e)
        {
            ChangePatient();
        }
        ///<summary>
        ///术中操作加载
        /// </summary>
        public void OperationLoad()
        {
            txtScheduledTime.Visible = false;
            searchTextBox1.Visible = false;
            string[] buttonStrings = ExtendApplicationContext.Current.StatusButtonStrList[ExtendApplicationContext.Current.SystemStatus].Split(new char[] { ';' }, StringSplitOptions.None);
            for (int i = 0; i < buttonStrings.Length; i++)
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
                if (i == 0)
                {
                    tableControlMenuCourseOfDisease.Items = item;
                    tableControlMenuCourseOfDisease.InitItem();
                }
                else if (i == 1)
                {
                    tableControlMenuInstruments.Items = item;
                    tableControlMenuInstruments.InitItem();
                }
                else if (i == 2)
                {
                    tableControlMenuOperation.Items = item;
                    tableControlMenuOperation.InitItem();
                }

            }
        }
        /// <summary>
        /// 改变患者信息
        /// </summary>
        public void ChangePatient()
        {
            Cursor = Cursors.WaitCursor;

            RefreshPatientInfo();
            if (ExtendApplicationContext.Current.PatientInformationExtend != null)
            {
                ExtendApplicationContext.Current.MED_OPERATION_MASTER
                   = operationInfoRepository.GetOperMaster(
                       ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID,
                       ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID,
                       ExtendApplicationContext.Current.PatientInformationExtend.OPER_ID).Data;

                ExtendApplicationContext.Current.MED_PAT_MASTER_INDEX
                    = operationInfoRepository.GetPatMasterIndex(
                        ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID).Data;

                ExtendApplicationContext.Current.MED_PAT_VISIT
                    = operationInfoRepository.GetPatVisit(
                        ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID,
                        ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID).Data;

                OperationStatus operationStatus;
                operationStatus = (OperationStatus)ExtendApplicationContext.Current.PatientInformationExtend.OPER_STATUS_CODE;

                SetOperationStatus(operationStatus);
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// 设置手术状态
        /// </summary>
        /// <param name="operationStatus"></param>
        public void SetOperationStatus(OperationStatus operationStatus)
        {
            //if (string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientInformationExtend.OPER_ROOM_NO)
            //    && operationStatus != OperationStatus.CancelOperation)
            //{
            //    MessageBoxFormPC.Show("检测到当前手术未设定【手术间】，请先从【手术信息】模块中填写明确信息！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    ShowFormByDocName(ViewNames.OperationInformation, 850, 600, false);
            //}
            ExtendApplicationContext.Current.OperationStatus = operationStatus;
            RefreshOperationStatus();
        }
        //定时刷新麻醉单或复苏单
        public void RefreshAnesDocOnRefreshTimeSpan()
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia || ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                var current = GetCurrentControl();
                if (current is BaseDoc)
                {
                    BaseDoc doc = current as BaseDoc;
                    if (doc.HasDirty())
                    {
                        if (!doc.ValidateData())
                        {
                            return;
                        }
                        else
                        {
                            doc.Save(false);
                        }
                    }

                    Cursor = Cursors.WaitCursor;
                    try
                    {

                        doc.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        public void CustomRefreshAnesDoc()
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia || ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                var current = GetCurrentControl();
                if (current is BaseDoc)
                {
                    BaseDoc doc = current as BaseDoc;
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        doc.CustomRefresh();
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        bool isRefreshCurrentWorkControlFinished = true;
        //刷新当前工作区域文书
        public void RefreshCurrentWorkControl()
        {
            if (isRefreshCurrentWorkControlFinished == false)
                return;
            isRefreshCurrentWorkControlFinished = false;
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia || ExtendApplicationContext.Current.AppType == ApplicationType.PACU || ExtendApplicationContext.Current.AppType == ApplicationType.YouDao)
            {
                var current = GetCurrentControl();
                if (current is BaseDoc)
                {
                    BaseDoc doc = current as BaseDoc;
                    if (doc.HasDirty())
                    {
                        DialogResult dialogResult = MessageBoxFormPC.Show("您当前的界面有未保存的数据,是否保存此数据?",
                            "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (!doc.ValidateData())
                            {
                                isRefreshCurrentWorkControlFinished = true;
                                return;
                            }
                            else
                            {
                                if (!doc.OnCustomCheckBeforeSave()) return;
                                doc.Save();
                            }
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            isRefreshCurrentWorkControlFinished = true;
                            return;
                        }
                    }
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        doc.RefreshData(true);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }

                }
            }
            isRefreshCurrentWorkControlFinished = true;
        }
        public void RefreshOperationStatus()
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia || ExtendApplicationContext.Current.AppType == ApplicationType.PACU || ExtendApplicationContext.Current.AppType == ApplicationType.YouDao
                  || ExtendApplicationContext.Current.AppType == ApplicationType.Nurse || ExtendApplicationContext.Current.AppType == ApplicationType.Director)
            {
                //执行当前状态下特殊操作，如弹出监护仪等
                DoOperationStatusActions(ExtendApplicationContext.Current.SystemStatus);
                //更新患者列表信息
                if (ApplicationConfiguration.IsPACUProgram)
                {
                    _patientsPACU.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);
                    // _patients.operationRoomPandect1.OperationRoomPandectLoad("1");
                }
                else
                {
                    _patients.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);
                }
                if (ExtendApplicationContext.Current.PatientContextExtend != null)
                {
                    this.workSpaceControl1.toolBarsControl1.SetOperationStatusTimeText(ExtendApplicationContext.Current.OperationStatus);
                    this.workSpaceControl1.toolBarsControl1.SetStatusLight(ExtendApplicationContext.Current.OperationStatus);
                }
            }
        }

        /// <summary>
        /// 执行手术状态默认动作
        /// </summary>
        /// <param name="operationStatus"></param>
        private void DoOperationStatusActions(ProgramStatus operationStatus)
        {
            string text = OperationStatusHelper.GetOperAction(operationStatus);
            if (!string.IsNullOrEmpty(text))
            {
                if (!string.IsNullOrEmpty(text))
                {
                    string[] actions = text.Split(',');
                    foreach (string s in actions)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            if (s.Equals("设备采集"))
                            {
                                //if (ExtendApplicationContext.Current.OperationStatus == OperationStatus.InOperationRoom)
                                ////   // ExecuteAction(s);
                                ////else
                                ////    continue;
                            }
                            else
                                ExecuteAction(s);
                        }
                    }
                }
                if (ExtendApplicationContext.Current.OperationStatus == OperationStatus.InOperationRoom)
                {
                    text = OperationStatusHelper.GetOperAction(ExtendApplicationContext.Current.OperationStatus);

                }
            }
            else
            {
                Dictionary<string, MedicalDocElement> docs = MedicalDocSettings.GetMedicalDocNameAndPath();
                foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in docs)
                {
                    if (operationStatus == ProgramStatus.PACURecord)
                    {
                        if (keyValuePair.Key.Trim().Equals("复苏记录单") || keyValuePair.Key.Trim().Equals("复苏单"))
                        {
                            ExecuteAction(keyValuePair.Key.Trim());
                            break;
                        }
                    }
                    else if (operationStatus == ProgramStatus.PeroperativePatient)
                    {
                        if (keyValuePair.Key.Trim().Contains("术前访视"))
                        {
                            ExecuteAction(keyValuePair.Key.Trim());
                            break;
                        }
                    }
                    else if (operationStatus == ProgramStatus.PostoperativePatient)
                    {
                        if (keyValuePair.Key.Trim().Contains("术后随访"))
                        {
                            ExecuteAction(keyValuePair.Key.Trim());
                            break;
                        }
                    }
                    else
                    {
                        if (keyValuePair.Key.Trim().Equals("麻醉单") || keyValuePair.Key.Trim().Equals("麻醉记录单"))
                        {
                            ExecuteAction(keyValuePair.Key.Trim());
                            break;
                        }
                    }
                }
                return;
            }
        }
        /// <summary>
        /// 执行手术状态默认动作,和超级配置关联
        /// </summary>
        /// <param name="actionName"></param>
        protected virtual void ExecuteAction(string actionName)
        {
            switch (actionName)
            {
                case "麻醉单":
                    ShowDocByDocName(ApplicationConfiguration.AnesDocName);
                    break;
                //case ViewNames.SetMonitor:
                //    {
                //        SelectMonitor setMonitor = new SelectMonitor(ExtendApplicationContext.Current.PatientInformationExtend, decimal.Parse(ExtendApplicationContext.Current.EventNo), ExtendApplicationContext.Current.OperRoomNo);
                //        this.workSpaceControl1.ShowViewDialog(setMonitor, setMonitor.Width, setMonitor.Height + 30);
                //        break;
                //    }
                default:
                    ShowDocByDocName(actionName);
                    break;
            }
        }

        /// <summary>
        /// 刷新患者信息头（顶部左边患者信息提示栏）
        /// </summary>
        private void RefreshPatientInfo()
        {
            if (ExtendApplicationContext.Current.PatientContextExtend != null)
            {
            }
        }
        #endregion


        #region "工作区域(workSpaceControl)  相关事件处理"


        /// <summary>
        /// 初始化工作区域项目
        /// </summary>
        private void InitWorkSpaceControl()
        {
            try
            {
                this.workSpaceControl1.ViewChangedEvent += new EventHandler<ViewChangedEventArgs>(workSpaceControl1_ViewChanged);
                if (ApplicationConfiguration.IsPACUProgram)
                {
                    if (_patientsPACU == null)
                    {
                        _patientsPACU = new PatientListViewPACU() { Dock = DockStyle.Fill };
                        _patientsPACU.SelectChanged += new EventHandler(patients_SelectChanged);
                        _patientsPACU.PatientClick += new EventHandler(patients_PatientClick2);
                        _patientsPACU.operationRoomPandect1.PACUPandectDocClick += new EventHandler(patients_SelectChanged);
                    }
                    workSpaceControl1.Initial(_patientsPACU);
                }
                else
                {
                    if (_patients == null)
                    {
                        _patients = new PatientListView() { Dock = DockStyle.Fill };
                        _patients.PatientClick += new EventHandler(patients_PatientClick);
                        _patients.SelectChanged += new EventHandler(patients_SelectChanged);
                        _patients.doctorQualityControl1.AnesDocCellClick += new EventHandler(patients_SelectChanged);
                        _patients.doctorQualityControl1.TomorrowCellClick += new EventHandler(doctorQuality_TomorrowCellClick);
                        _patients.doctorQualityControl1.YesterdayCellClick += new EventHandler(doctorQuality_YesterdayCellClick);
                    }
                    workSpaceControl1.Initial(_patients);
                }
                ReturnPatientList();
            }
            catch (Exception ex)
            {
                Logger.Error("InitWorkSpaceControl", ex);
                ExceptionHandler.Handle(ex);
            }


        }
        /// <summary>
        /// 返回患者清单
        /// </summary>
        public void ReturnPatientList()
        {
            try
            {
                var current = GetCurrentControl();
                //if (current is BaseDoc)
                //{
                //    if (ExtendApplicationContext.Current.OperationStatus > OperationStatus.InPACU)
                //    {
                //        List<MED_EMR_ARCHIVE_DETIAL> emrList = commonRepository.GetEmrArchiveList(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                //            ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID.ToString(), 
                //            ExtendApplicationContext.Current.CurrentDocName).Data;

                //        bool isUpdate = false;
                //        if (emrList != null && emrList.Count > 0)
                //        {
                //            foreach (MED_EMR_ARCHIVE_DETIAL list in emrList)
                //            {
                //                if (list.ARCHIVE_STATUS.Equals("已归档"))
                //                {
                //                    isUpdate = true;
                //                }
                //            }
                //        }
                //        if (!isUpdate)
                //        {
                //            DialogResult dialogResult = MessageBoxFormPC.Show("复苏单还未归档，请先归档！",
                //                 "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            return;
                //        }
                //    }
                //}
                RefreshCurrentWorkControl();
                TopBarLoad();
                workSpaceControl1.AddPatientView();
                if (ApplicationConfiguration.IsPACUProgram)
                    _patientsPACU.Focus();
                else
                    _patients.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }
        /// <summary>
        /// 获取当前工作区域 子窗体
        /// </summary>
        /// <returns></returns>
        public Control GetCurrentControl()
        {
            return workSpaceControl1.CurrentControl;
        }


        /// <summary>
        /// 根据主窗体界面改变左侧导航菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workSpaceControl1_ViewChanged(object sender, ViewChangedEventArgs e)
        {
            Control ctl = GetCurrentControl();
            //string anesDocName = ApplicationConfiguration.AnesDocName;
            if (ExtendApplicationContext.Current.PatientContextExtend != null && ctl != null)
            {
                if (ctl is BaseDoc)
                {
                    BaseDoc doc = ctl as BaseDoc;
                    if (doc.DocKind.Equals(DocKind.Anes))
                    {
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.AnesthesiaRecord;
                    }
                    else if (doc.DocKind.Equals(DocKind.PACU))
                    {
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.PACURecord;
                    }
                    else if (doc.DocKind.Equals(DocKind.CPB))
                    {
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.CPBReport;
                    }
                    if (ApplicationConfiguration.IsPACUProgram)
                    {
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.PACURecord;
                    }
                }
                else
                {
                    ExtendApplicationContext.Current.SystemStatus = ProgramStatus.NoPatient;
                }
            }
        }
        #endregion

        #region 状态栏初始化

        /// <summary>
        /// 所有采集项目字典
        /// </summary>
        private void LoadMonitorFunctionCodeDict()
        {

            List<MED_MONITOR_FUNCTION_CODE> monitorFunctionCodeDataTable = null;
            if (ExtendApplicationContext.Current.CommDict.MonitorFuntionDict != null)
            {
                monitorFunctionCodeDataTable = ExtendApplicationContext.Current.CommDict.MonitorFuntionDict;
            }
            else
            {
                monitorFunctionCodeDataTable = comnDictRepository.GetMonitorFuctionCodeList().Data;
            }

            if (monitorFunctionCodeDataTable != null && monitorFunctionCodeDataTable.Count > 0)
            {
                foreach (MED_MONITOR_FUNCTION_CODE codeRow in monitorFunctionCodeDataTable)
                {
                    if (!ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(codeRow.ITEM_CODE))
                    {
                        ExtendApplicationContext.Current.MonitorFunctionCodeDict.Add(codeRow.ITEM_CODE, codeRow.ITEM_NAME);
                    }
                }
            }
            if (!ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey("ECG"))
            {
                ExtendApplicationContext.Current.MonitorFunctionCodeDict.Add("ECG", "ECG");
            }
        }

        #endregion

        #region "文书状态栏  相关事件处理"

        /// <summary>
        /// 初始化文书工作栏
        /// </summary>
        private void InitMecicalDocBarControl()
        {
            try
            {
                int _RefreshTimeSpan = ApplicationConfiguration.RefreshTimeSpan;
                if (_RefreshTimeSpan <= 2)
                {
                    _RefreshTimeSpan = 120;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        //刷新麻醉单等文书 定时
        private void OnRefreshTimeSpanRefreshDoc()//object sender, EventArgs e
        {
            var current = GetCurrentControl();
            if (current is BaseDoc)
            {
                BaseDoc doc = current as BaseDoc;
                if (doc.DocKind == DocKind.Anes || doc.DocKind == DocKind.PACU)
                    RefreshAnesDocOnRefreshTimeSpan();
            }
        }
        /// <summary>
        /// 在工作区域显示文书
        /// </summary>
        /// <param name="docName"></param>
        public void ShowDocByDocName(string docName)
        {
            //获取当前工作区域 子窗体
            var current = GetCurrentControl();
            #region <<当前是BaseDoc或是其派生类的处理>>
            if (current is BaseDoc)
            {
                BaseDoc doc = current as BaseDoc;

                #region <<当前界面是否需要保存验证>>
                if (doc.HasDirty())
                {
                    DialogResult dialogResult = MessageBoxFormPC.Show("您当前的界面有未保存的数据,是否保存此数据?",
                        "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (!doc.ValidateData())
                            return;
                        else
                        {
                            if (!doc.OnCustomCheckBeforeSave()) return;
                            doc.Save();
                        }

                    }
                    else if (dialogResult == DialogResult.Cancel)
                        return;
                }
                #endregion

                #region <<再次请求“麻醉单”时的处理>>
                //麻醉单已经打开，请求的还是麻醉单，则直接刷新，不用重新Load
                if (doc.DocKind == DocKind.Anes && docName == "麻醉单")
                {

                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        doc.RefreshData();
                        this.workSpaceControl1.RaiseEvent("");
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Handle(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }

                    return;
                }
                #endregion
            }
            #endregion
            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);

            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                DialogResult dialogResult = MessageBoxFormPC.Show(string.Format("无法加载文书'{0}'的设计模版,请确保模版文件已经存在", docName),
                        "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.workSpaceControl1.AddDocToWorkSpace(null);
                return;
            }
            try
            {
                ExtendApplicationContext.Current.CurrentDocName = docName;
                Type t = Type.GetType(document.Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                baseDoc.BackColor = Color.White;
                baseDoc.Name = docName;
                baseDoc.Caption = docName;
                baseDoc.HideScrollBar();
                baseDoc.Initial();
                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                if (baseDoc.DocKind == DocKind.Anes)
                {
                    baseDoc.AfterPrint += new BaseDoc.EventAfterPrint(AfterPrint);
                }

                this.workSpaceControl1.AddDocToWorkSpace(baseDoc);
                //通过一个定时器来降低文书界面闪烁的烦恼
                using (BackgroundWorker worker = new BackgroundWorker())
                {
                    worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                    {
                        baseDoc.ShowScrollBar();
                    };
                    worker.RunWorkerAsync();
                };
                var currentbaseDoc = GetCurrentControl();
                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {
                    if (docName.Contains("麻醉单") || docName.Contains("麻醉记录单") || ((BaseDoc)currentbaseDoc).DocKind == DocKind.Anes)
                    {
                        if (AccessControl.CheckModifyRightForOperator(docName) && ApplicationConfiguration.ApplicationPatterns == "0")//有Modify权限
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                            }
                        }
                        else
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                            }
                        }
                    }
                    else
                    {
                        if (AccessControl.CheckModifyRight(docName))//有Modify权限
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                            }
                        }
                        else
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                            }
                        }
                    }
                    if (currentbaseDoc is BaseDoc)
                    {
                        if (((BaseDoc)currentbaseDoc).AllowSingleDocModify())
                        {
                            ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                        }
                    }
                }
                else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {
                    if ((currentbaseDoc is BaseDoc) && ((BaseDoc)currentbaseDoc).DocKind == DocKind.Anes && docName == "麻醉单")
                    {
                        if (AccessControl.CheckModifyRightForOperator("麻醉单") && ApplicationConfiguration.ApplicationPatterns == "0")//有Modify权限
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                            }
                        }
                        else
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                            }
                        }
                    }
                    else
                    {
                        if (AccessControl.CheckModifyRight(docName))//有Modify权限
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(true);
                            }
                        }
                        else
                        {
                            if (currentbaseDoc is BaseDoc)
                            {
                                ((BaseDoc)currentbaseDoc).SetAllControlEditable(false);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }


        // 打印后触发事件 用于刷新界面
        private void AfterPrint(object sender, EventArgs e)
        {
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
            {

                var current = GetCurrentControl();
                if (current is BaseDoc)
                {
                    BaseDoc doc = ((BaseDoc)current);
                    //左侧导航栏刷新
                    //leftBarControl1.SetLockPatBtn();
                    string strDocName = string.IsNullOrEmpty(doc.Name) ? "麻醉单" : doc.Name;

                    if (AccessControl.CheckModifyRightForOperator(strDocName) && ApplicationConfiguration.ApplicationPatterns == "0")//有Modify权限
                    {
                        doc.SetAllControlEditable(true);
                    }
                    else
                    {
                        doc.SetAllControlEditable(false);
                    }
                }

            }
        }
        #endregion


        #region TOP导航相关
        /// <summary>
        /// 左边导航界面改变事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftBarControl1_ViewChangedEventHandler(object sender, ViewChangedEventArgs e)
        {
            if (e.ViewName.StartsWith("医疗文书@"))  //飘窗
            {
                string key = e.ViewName.Replace("医疗文书@", "");//事件类型中文名
                if (!string.IsNullOrEmpty(key))
                {
                    if (ExtendApplicationContext.Current.SystemStatus == ProgramStatus.AnesthesiaRecord || ExtendApplicationContext.Current.SystemStatus == ProgramStatus.PACURecord)
                        switch (key)
                        {
                            case "麻醉记录单":
                            case "患者交接单":
                                ShowFormByDocName(key, 810, 900, false);
                                break;
                            default:
                                ShowFormByDocName(key, 1200, 900, false);
                                break;
                        }

                    else
                        ShowDocByDocName(key);
                }
            }
            else
            {
                if (ShowCustomForm(e.ViewName))
                {
                    Control control = GetCurrentControl();
                    if (control != null && control is BaseDoc)
                    {
                        BaseDoc doc = control as BaseDoc;
                        foreach (IUIElementHandler handler in doc.GetUIElementHandlers())
                        {
                            if (handler is GridViewHandler)
                            {
                                handler.RefreshData();
                                break;
                            }
                        }
                    }
                    return;
                }
                if (e.ViewName == ViewNames.HisAssay)  //检验信息
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        MessageBoxFormPC.Show("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    this.workSpaceControl1.ShowViewDialog(new AssayReport(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID), 1100, 600);
                }
                else if (e.ViewName == ViewNames.HisCheckInfo)  //检查结果
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        MessageBoxFormPC.Show("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    if (ExtendApplicationContext.Current.CustomSettingContext.IsHisCheckInfo)
                    {
                        this.workSpaceControl1.ShowViewDialog(new CheckInfoPanel(), 800, 600);
                    }
                    else
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContextExtend.PatientID))
                                syncInfoRepository.SyncPACS(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, null);
                        }
                        catch
                        { }
                    }
                }
                else if (e.ViewName == ViewNames.HisDocuments)  //病历病程
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        MessageBoxFormPC.Show("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    if (ExtendApplicationContext.Current.CustomSettingContext.IsCheckInfoShowDialog)
                    {
                        this.workSpaceControl1.ShowViewDialog(new DocumentsPanel(), 800, 600);
                    }
                    else
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContextExtend.PatientID))
                            {
                                string ret = syncInfoRepository.SyncEMR1(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                                    ExtendApplicationContext.Current.PatientContextExtend.VisitID, null
                                        , ExtendApplicationContext.Current.LoginUser.USER_JOB_ID).Data;

                                Logger.Error("调用接口EMR001:参数 patientID:" + ExtendApplicationContext.Current.PatientContextExtend.PatientID + " ,VisitID: " + ExtendApplicationContext.Current.PatientContextExtend.VisitID
                                    + " ,operator: " + ExtendApplicationContext.Current.LoginUser.USER_JOB_ID + "   " + ret);
                            }
                            // new SyncInfoService().SyncEMR(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, null);


                        }
                        catch
                        { }
                    }
                }
                else if (e.ViewName == ViewNames.HisOrderInfo)  //医嘱信息
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        MessageBoxFormPC.Show("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    this.workSpaceControl1.ShowViewDialog(new OrderInfoPanel(), 800, 600);
                }
                else if (e.ViewName == ViewNames.AboutView)  //关于界面
                {
                    //AboutForm aboutForm = new AboutForm();
                    //aboutForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    //aboutForm.ShowDialog();
                }
                else if (e.ViewName == ViewNames.BloodMove)  //血液动力
                {
                    this.workSpaceControl1.ShowViewDialog(new HemodynamicsFigureOut(), 800, 620);
                }
                else if (e.ViewName == ViewNames.BloodGasData)  //血气分析
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        MessageBoxFormPC.Show("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    // this.workSpaceControl1.ShowViewDialog(new BloodGasDataEditor(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID), 800, 600);
                }
                else if (e.ViewName == ViewNames.EditDict)  //字典
                {
                    this.workSpaceControl1.ShowViewDialog(new EditDict(), 800, 600);
                }
                else if (e.ViewName == ViewNames.LockSystem)//锁定系统
                {
                    SaveEventSort();
                    //LoginForm loginForm = new LoginForm(false);
                    //loginForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    //loginForm.Tag = "LockSystem".ToUpper();

                    //DialogResult dialogResult = loginForm.ShowDialog();
                    //if (dialogResult != DialogResult.OK)
                    //{
                    //    loginForm.DialogResult = DialogResult.None;
                    //    //isLockSystem = true;
                    //    //Application.Exit();
                    //    //loginForm.ShowDialog();
                    //    return;
                    //}
                }
                else if (e.ViewName == ViewNames.EditTemplet)  //模板管理
                {
                    EditTemplet editTemplet = new EditTemplet();
                    editTemplet.Caption = "模板维护管理";
                    this.workSpaceControl1.ShowViewDialog(editTemplet, 800, 600);
                }
                else if (e.ViewName == ViewNames.SetMonitor)  //监护仪设置
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    SelectMonitor setMonitor = new SelectMonitor(ExtendApplicationContext.Current.PatientInformationExtend, decimal.Parse(ExtendApplicationContext.Current.EventNo), ExtendApplicationContext.Current.OperRoomNo, true);
                    this.workSpaceControl1.ShowViewDialog(setMonitor, setMonitor.Width, setMonitor.Height);
                }
                else if (e.ViewName == ViewNames.OperationRoomPandect)  //手术概览
                {
                    OperationRoomPandect operationRoomPandect = new OperationRoomPandect();
                    operationRoomPandect.Caption = "手术概览";
                    this.workSpaceControl1.ShowViewDialog2(operationRoomPandect, true);
                }
                else if (e.ViewName == ViewNames.EmergencyRegister)
                {
                    ShowFormByDocName(e.ViewName, 900, 600, false);
                }
                else if (e.ViewName == ViewNames.OperationInformation || e.ViewName == ViewNames.OperationRegister)  //手术信息
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        Dialog.MessageBox("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    ShowFormByDocName(e.ViewName, 850, 600, false);
                    if (ApplicationConfiguration.IsPACUProgram)
                        _patientsPACU.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);
                    else
                        _patients.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);

                    //刷新权限
                    if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                    {

                    }
                    else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                    {

                    }
                }
                else if (e.ViewName == ViewNames.RegisterAfterOperation)//术后登记
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        MessageBoxFormPC.Show("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    ShowFormByDocName(ViewNames.RegisterAfterOperation, 850, 650, false);
                    floatFrm_AddEvent(null, null);
                    RefreshOperationStatus();
                    // topBarControl1.RefreshPatientInfo(ExtendApplicationContext.Current.PatientInformation.OperRoom, ExtendApplicationContext.Current.PatientInformation.PatientID, ExtendApplicationContext.Current.PatientInformation.Name);
                    //if (ApplicationConfiguration.IsPACUProgram)
                    //    _patientsPACU.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);
                    //else
                    //    _patients.RefreshPatientDataTable(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);

                }
                else if (e.ViewName == ViewNames.CancelOperation)//取消手术
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        MessageBoxFormPC.Show("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    object cancelReason = null;
         //           if (ExtendApplicationContext.Current.OperationStatus == OperationStatus.CancelOperation)
         //           {
         //               if (Dialog.MessageBox("患者“" + ExtendApplicationContext.Current.PatientInformationExtend.NAME + "”的手术已取消，是否要恢复？"
         //, "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0) == DialogResult.No)
         //               {
         //                   return;
         //               }
         //               cancelReason = Dialog.SingleInputSelect("恢复原因：", "");
         //               if (cancelReason == null)
         //               {
         //                   return;
         //               }
         //               workSpaceControl1.RecoveryOperation(cancelReason.ToString());
         //               if (ExtendApplicationContext.Current.OperationStatus > OperationStatus.IsReady && ExtendApplicationContext.Current.OperationStatus < OperationStatus.OutOperationRoom)
         //               {
         //                   SelectMonitor setMonitor = new SelectMonitor(ExtendApplicationContext.Current.PatientInformationExtend, decimal.Parse(ExtendApplicationContext.Current.EventNo), ExtendApplicationContext.Current.OperRoomNo, true);
         //                   this.workSpaceControl1.ShowViewDialog(setMonitor, setMonitor.Width, setMonitor.Height);
         //               }
         //           }
         //           else
                    {
                        if (ExtendApplicationContext.Current.OperationStatus >= OperationStatus.OutOperationRoom)
                        {
                            MessageBoxFormPC.Show("该患者已完成手术，无法取消");
                            return;
                        }
                        if (MessageBoxFormPC.Show("真的要取消患者“" + ExtendApplicationContext.Current.PatientInformationExtend.NAME + "”的手术吗？"
          , "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        cancelReason = Dialog.SingleInputSelect("取消原因：", "");
                        if (cancelReason == null)
                        {
                            return;
                        }
                        workSpaceControl1.CancelOrCommitOperation(OperationStatus.CancelOperation, cancelReason.ToString());
                        ExtendApplicationContext.Current.SystemStatus = ProgramStatus.NoPatient;
                        ReturnPatientList();
                        if (ApplicationConfiguration.IsPACUProgram)
                            _patientsPACU.RefreshPatientDataTable(ExtendApplicationContext.Current.CurrentDateTime, ExtendApplicationContext.Current.CurrentSearchStr);
                        else
                            _patients.RefreshPatientDataTable();
                    }

                    if (ExtendApplicationContext.Current.PatientContextExtend != null)
                    {
                        if (ApplicationConfiguration.IsUpdateHisStatus)
                        {
                            try
                            {
                                string ret = syncInfoRepository.SyncWriteHisOper(ExtendApplicationContext.Current.PatientContextExtend.PatientID, 
                                    (int)ExtendApplicationContext.Current.PatientContextExtend.VisitID, 
                                    (int)ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandler.Handle(ex);
                            }
                        }
                        ReturnPatientList();
                        if (ApplicationConfiguration.IsPACUProgram)
                            _patientsPACU.RefreshPatientDataTable(ExtendApplicationContext.Current.CurrentDateTime, ExtendApplicationContext.Current.CurrentSearchStr);
                        else
                            _patients.RefreshPatientDataTable();

                    }
                }
                else if (e.ViewName == ViewNames.SyncHis)//HIS同步
                {
                    if (ExtendApplicationContext.Current.CustomSettingContext.IsSyncScheduleInfo)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            string ret;
                            if (ApplicationConfiguration.SyncScheduleInfoMode == 0)
                            {
                                ret = syncInfoRepository.SyncScheduleInfoByDeptCode(ExtendApplicationContext.Current.OperRoom).Data;
                            }
                            else
                            {
                                ret = syncInfoRepository.SyncScheduleInfo("").Data;
                            }
                            if (!string.IsNullOrEmpty(ret))
                            {
                                ExceptionHandler.Handle(new Exception("同步手术申请信息失败\r\n" + ret));
                                ret = syncInfoRepository.SyncPatientInfoAndInHospital("").Data;
                            }
                            if (string.IsNullOrEmpty(ret))
                            {
                                Dialog.MessageBox(e.ViewName + "成功");
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
                else if (e.ViewName == ViewNames.LockPatient)//病案提交
                {
                    if (ExtendApplicationContext.Current.PatientContextExtend == null)
                    {
                        MessageBoxFormPC.Show("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    if (ExtendApplicationContext.Current.OperationStatus < OperationStatus.OutOperationRoom)
                    {
                        MessageBoxFormPC.Show("该患者手术未完成或未离开手术间，无法归档。");
                        return;
                    }
                    if (ExtendApplicationContext.Current.OperationStatus.Equals(OperationStatus.Done))
                    {
                        MessageBoxFormPC.Show("该患者病案资料已提交");
                        return;
                    }
                    if (MessageBoxFormPC.Show("真的要将患者“" + ExtendApplicationContext.Current.PatientInformationExtend.NAME + "”麻醉资料提交吗？\r\n提交后患者资料将不能再进行任何形式的更改!"
                        , "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (e.ViewName == ViewNames.InformFMembers)//家属公告
                {
                    if (ExtendApplicationContext.Current.PatientInformationExtend == null)
                    {
                        MessageBoxFormPC.Show("提示：请选中一个患者后再进行操作。");
                        return;
                    }
                    ScreenInfoNotice screenInfoNotice = new ScreenInfoNotice();
                    DialogHostFormPC dialogHostForm = new DialogHostFormPC("家属公告信息", 800, 500);
                    dialogHostForm.Child = screenInfoNotice;
                    dialogHostForm.ShowDialog();
                }
                else if (e.ViewName == ViewNames.UserConfig)//系统配置
                {
                    UserConfig userConfig = new UserConfig();
                    this.workSpaceControl1.ShowViewDialog(userConfig, userConfig.Width, userConfig.Height);
                }
                else if (e.ViewName == ViewNames.AnesShift || e.ViewName == ViewNames.NurseShift || e.ViewName == ViewNames.OperationShift)
                {
                    AnesShiftRegisteListControl control = new AnesShiftRegisteListControl(e.ViewName);
                    this.workSpaceControl1.ShowViewDialog(control, control.Width, control.Height);
                }
            }
        }
        BaseDoc _baseDoc = null;
        public void ShowFormByDocName(string docName, int width, int height, bool isMaximized)
        {
            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(docName);
            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                return;
            }
            try
            {
                ExtendApplicationContext.Current.CurrentDocName = docName;
                Type t = Type.GetType(document.Type);
                BaseDoc baseDoc = Activator.CreateInstance(t) as BaseDoc;
                baseDoc.ShowScrollBar();
                baseDoc.Caption = docName;
                baseDoc.LoadReport(ExtendApplicationContext.Current.AppPath + document.Path);
                DialogHostFormPC dialogHostForm = null;
                if (isMaximized)
                {
                    dialogHostForm = new DialogHostFormPC(docName, isMaximized);
                }
                else
                {
                    dialogHostForm = new DialogHostFormPC(docName, width, height);
                }
                dialogHostForm.ControlBox = true;
                dialogHostForm.Child = baseDoc;
                if (AccessControl.CheckModifyRightForOperator(docName) && ApplicationConfiguration.ApplicationPatterns == "0")//有Modify权限
                    baseDoc.SetAllControlEditable(true);
                else
                {
                    baseDoc.SetAllButtonsEnable(false);
                    baseDoc.SetAllControlEditable(false);
                }
                if (baseDoc.AllowSingleDocModify())
                    baseDoc.SetAllControlEditable(true);
                _baseDoc = baseDoc;
                _dataTemplate = new DataTemplate(baseDoc);


                baseDoc.SaveTemplateClicked += new EventHandler(SaveTemplateClicked);
                baseDoc.ApplyTemplateClicked += new EventHandler(ApplyTemplateClicked);
                baseDoc.SaveAllDataTemplateClicked += new EventHandler(SaveAllDataTemplateClicked);
                baseDoc.ApplyAllDataTemplateClicked += new EventHandler(ApplyAllDataTemplateClicked);
                dialogHostForm.ShowDialog();

            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }

        }
        public void SaveTemplateClicked(object sender, EventArgs e)
        {
            _dataTemplate.SaveModel();
        }
        public void ApplyTemplateClicked(object sender, EventArgs e)
        {
            _dataTemplate.ApplyModel();
        }
        public void SaveAllDataTemplateClicked(object sender, EventArgs e)
        {
            _dataTemplate.SaveAllDataModel(_baseDoc.GetTotalModelDataTabla());
        }
        public void ApplyAllDataTemplateClicked(object sender, EventArgs e)
        {
            DataTable TotalModelDT = _dataTemplate.ApplyAllDataModel();
            _baseDoc.ApplyAllDocTemplate(TotalModelDT);
        }

        private bool ShowCustomForm(string viewName)
        {
            Dictionary<string, MedicalDocElement> views = MedicalDocSettings.GetCustomForms();

            KeyValuePair<string, MedicalDocElement> keyValuePairView = new KeyValuePair<string, MedicalDocElement>();

            foreach (KeyValuePair<string, MedicalDocElement> keyValuePair in views)
            {
                if (keyValuePair.Key.Trim() == viewName.Trim())
                {
                    keyValuePairView = keyValuePair;
                    break;
                }
            }
            //没有找到退出
            if (string.IsNullOrEmpty(keyValuePairView.Key))
            {
                return false;
            }
            try
            {
                Type t = Type.GetType(keyValuePairView.Value.Type);
                BaseView view = Activator.CreateInstance(t) as BaseView;
                this.workSpaceControl1.ShowViewDialog(view, view.Width, view.Height);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                return false;
            }
        }

        private void floatFrm_AddEvent(object sender, EventArgs e)
        {
            Control control = GetCurrentControl();
            if (control != null && control is BaseDoc)
            {
                BaseDoc doc = control as BaseDoc;
                doc.RefreshData();
            }
        }
        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            SaveEventSort();
            var current = GetCurrentControl();
            if (current is BaseDoc)
            {
                BaseDoc doc = current as BaseDoc;
                if (doc.HasDirty())
                {
                    DialogResult dialogResult = MessageBoxFormPC.Show("您当前的界面有未保存的数据,是否保存数据并退出系统?",
                        "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (!doc.ValidateData())
                            return;
                        else
                        {
                            if (!doc.OnCustomCheckBeforeSave()) return;
                            doc.Save();
                        }

                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }

                }
                else
                {
                    if (MessageBoxFormPC.Show("是否退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        if (e.Cancel) ExceptionHandler.Handle((new Exception("关闭程序时发现e.Cancel = true;")), false);
                        e.Cancel = false;
                    }
                }
            }
            else
            {
                if (MessageBoxFormPC.Show("是否退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (e.Cancel) ExceptionHandler.Handle((new Exception("关闭程序时发现e.Cancel = true;")), false);
                    e.Cancel = false;
                }
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveEventSort();
            var current = GetCurrentControl();
            if (current is BaseDoc)
            {
                BaseDoc doc = current as BaseDoc;
                if (doc.HasDirty())
                {
                    DialogResult dialogResult = MessageBoxFormPC.Show("您当前的界面有未保存的数据,是否保存数据并退出系统?",
                        "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (!doc.ValidateData())
                            return;
                        else
                        {
                            if (!doc.OnCustomCheckBeforeSave()) return;
                            doc.Save();
                        }

                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }

                }
                else
                {
                    if (MessageBoxFormPC.Show("是否退出系统?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        if (e.Cancel) ExceptionHandler.Handle((new Exception("关闭程序时发现e.Cancel = true;")), false);
                        e.Cancel = false;
                    }
                }
            }
            else
            {
                if (MessageBoxFormPC.Show("是否退出系统?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (e.Cancel) ExceptionHandler.Handle((new Exception("关闭程序时发现e.Cancel = true;")), false);
                    e.Cancel = false;
                }
            }
        }
        protected void RefreshStatus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContextExtend.PatientID))
            {
                MED_OPERATION_MASTER dtMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                    ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

                if (dtMaster != null)
                {
                    ExtendApplicationContext.Current.PatientInformationExtend.OPER_ROOM_NO = dtMaster.OPER_ROOM_NO;
                    ExtendApplicationContext.Current.PatientInformationExtend.OPER_STATUS_CODE = dtMaster.OPER_STATUS_CODE;

                    patients_SelectChanged(sender, e);
                }
            }
        }
        protected void RefreshVitalSignData()
        {
            string dataType = "0";
            if (ApplicationConfiguration.IsPACUProgram)
                dataType = "1";
            if (ExtendApplicationContext.Current.PatientContextExtend != null && !string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContextExtend.PatientID))
            {
                List<MED_VITAL_SIGN> vitalSignList = new OperationVitalSignRepository().GetVitalSignData(ExtendApplicationContext.Current.PatientContextExtend.PatientID
                    , ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID, dataType, false);
                new PatientSignWarning().SetSignAlarmInfoList(vitalSignList);
            }
        }
        //protected void RefreshMessage()
        //{
        //    if (ExtendApplicationContext.Current.LoginUser != null)
        //    {
        //        if (MessageQueue.MessageList.Count == 0)
        //        {
        //            List<MED_RESCUE_MESSAGE_LOG> messageLog = RescueService.GetRescueMessageList();
        //            messageLog = messageLog.Where(p => p.RECEIVE_CONFIRM == 0 && p.EXPERT_ID == ExtendApplicationContext.Current.LoginUser.USER_JOB_ID).ToList();
        //            if (messageLog != null && messageLog.Count > 0)
        //            {
        //                currentUserInfo.MsgCount = messageLog.Count;
        //                foreach (MED_RESCUE_MESSAGE_LOG alarm in messageLog)
        //                {
        //                    string message = alarm.MESSAGE;
        //                    MessageQueue.AddMessage(message, Color.Red);
        //                }
        //            }
        //        }
        //        List<MED_MESSAGE_LOG> msgLog = CoordinationService.GetMessageList(ExtendApplicationContext.Current.LoginUser.USER_ID);
        //        if (msgLog != null && msgLog.Count > 0)
        //        {
        //            currentUserInfo.CoorCount = msgLog.Count;
        //        }
        //    }
        //}
        #region 自动归档设置

        private DateTime currentTime = DateTime.MinValue;
        /// <summary>
        /// 自动归档设置
        /// </summary>
        //private void AuotDoneDoc()
        //{
        //    if (currentTime != DateTime.MinValue && ((DateTime.Now - currentTime).TotalHours < 1))
        //    {
        //        return;
        //    }
        //    currentTime = DateTime.Now;

        //    int i = 1;
        //    OperationInfoService.GetOperMasterByRoom
        //    try
        //    {
        //        Logger.Write(string.Format("自动归档[{0}]:{1} 启动。", i++, DateTime.Now));

        //        //获取出手术室后的病人自动归档
        //        var doneList = CommonProxy.GetDataFromSQLString(
        //            string.Format("SELECT * FROM MED_OPERATION_MASTER WHERE OPER_STATUS = 35 AND OUT_DATE_TIME < (SYSDATE - {0})",
        //            ApplicationConfiguration.AutoOperDoneDays));
        //        doneList.TableName = "MED_OPERATION_MASTER";
        //        if (doneList != null && doneList.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in doneList.Rows)
        //            {
        //                row["OPER_STATUS"] = (decimal)(int)OperationStatus.Done;
        //                string fieldName = OperationStatusHelper.GetTimeFieldName(OperationStatus.Done);
        //                row[fieldName] = DateTime.Now;
        //                Logger.Write(string.Format("自动归档[{0}]:{1} PATIENT_ID:{2},VISIT_ID:{3},OPER_ID:{4}。", i++, DateTime.Now,
        //                    row["PATIENT_ID"], row["VISIT_ID"], row["OPER_ID"]));
        //            }

        //            int result = CommonProxy.UpdateDataTable(doneList);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write(string.Format("自动归档[{0}]:{1} {2}。", i++, DateTime.Now, ex.Message));
        //    }
        //    finally
        //    {

        //        Logger.Write(string.Format("自动归档[{0}]:{1} 结束。", i++, DateTime.Now));
        //    }
        //}

        #endregion

        protected void SaveEventSort()
        {
            List<MED_EVENT_SORT> eventSortList = ExtendApplicationContext.Current.CommDict.EventSortDict;
            if (eventSortList.Count > 0 && eventSortList[0].USER_ID != ExtendApplicationContext.Current.LoginUser.USER_JOB_ID)
            {
                eventSortList.ForEach(row =>
                    {
                        row.USER_ID = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
                    });
            }
            comnDictRepository.SaveEventSortList(eventSortList);

            ExtendApplicationContext.Current.LoginUser.RUN_MODE = 4;
            ExtendApplicationContext.Current.LoginUser.RUN_ADDRESS = "";
            userRepository.SaveUser(ExtendApplicationContext.Current.LoginUser);
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
        private void currentUserInfo_BtnClicked(object sender, string var)
        {
            if (var.Equals("主页"))
            {
                //tableControlMenuCourseOfDisease.Visible = false;
                //tableControlMenuInstruments.Visible = false;
                //tableControlMenuOperation.Visible = false;
                txtScheduledTime.Visible = true;
                searchTextBox1.Visible = true;
                ReturnPatientList();
                if (ApplicationConfiguration.IsPACUProgram)
                    _patientsPACU.RefreshPatientDataTable(ExtendApplicationContext.Current.CurrentDateTime, ExtendApplicationContext.Current.CurrentSearchStr);
                else
                    _patients.RefreshPatientDataTable();
            }
            else if (var.Equals("日程管理"))
            {
                tableControlMenuCourseOfDisease.Visible = false;
                tableControlMenuInstruments.Visible = false;
                tableControlMenuOperation.Visible = false;
                DailySchedule view = new DailySchedule();
                this.workSpaceControl1.AddPatientView(view, "DailySchedule");
            }
            else if (var.Equals("手术查询"))
            {
                tableControlMenuCourseOfDisease.Visible = false;
                tableControlMenuInstruments.Visible = false;
                tableControlMenuOperation.Visible = false;
                OperationQuery view = new OperationQuery();
                this.workSpaceControl1.AddPatientView(view, "OperationQuery");
            }
            else if (var.Equals("工作量统计"))
            {
                tableControlMenuCourseOfDisease.Visible = false;
                tableControlMenuInstruments.Visible = false;
                tableControlMenuOperation.Visible = false;
                OperationReport view = new OperationReport();
                this.workSpaceControl1.AddPatientView(view, "OperationReport");
            }
            else if (var.Equals("个人模板管理"))
            {
                EditTemplet editTemplet = new EditTemplet();
                editTemplet.Caption = "模板维护管理";
                this.workSpaceControl1.ShowViewDialog(editTemplet, 800, 600);
            }
            else if (var.Equals("字典"))
            {
                EditDict dict = new EditDict();
                dict.Caption = "基础字典";
                this.workSpaceControl1.ShowViewDialog(dict, dict.Width, dict.Height);
            }
            else if (var.Equals("系统配置"))
            {
                UserConfig userConfig = new UserConfig();
                this.workSpaceControl1.ShowViewDialog(userConfig, userConfig.Width, userConfig.Height);
            }
            else if (var.Equals("HIS同步"))
            {
                DateTime tiem = Convert.ToDateTime(accountRepository.GetServerTime().Data.ToString("yyyy-MM-dd"));

                string ret = syncInfoRepository.SyncScheduleInfoByDateTime("", tiem, tiem.AddDays(3)).Data;

                if (!string.IsNullOrEmpty(ret))
                {
                    MessageBoxFormPC.Show("同步失败！" + ret, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxFormPC.Show("同步成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _patients.RefreshPatientDataTable();
                    _patients.RefreshDoctorQualityDataTable();
                }
            }
            else if (var.Equals("协同"))
            {
                //CoordinationControl coordination = new CoordinationControl();
                //DialogHostFormPC dialogHostForm = new DialogHostFormPC("协同", coordination.Width, coordination.Height);
                //dialogHostForm.Child = coordination;
                //dialogHostForm.ShowDialog();
                //coordination.t.Stop();
            }
            else if (var.Equals("提醒"))
            {
                UserMsgListView userMsg = new UserMsgListView();
                this.workSpaceControl1.ShowViewDialog(userMsg, userMsg.Width, userMsg.Height);
                userMsg.SaveUserMsg();
            }
        }

        private void search_BtnClicked(object sender, string var)
        {
            // if (!string.IsNullOrEmpty(var))
            {
                if (ApplicationConfiguration.IsPACUProgram)
                {
                    if (var.Contains("请输入")) var = "";
                    ExtendApplicationContext.Current.CurrentDateTime = txtScheduledTime.DateTime;
                    ExtendApplicationContext.Current.CurrentSearchStr = var;
                    _patientsPACU.RefreshPatientDataTable(txtScheduledTime.DateTime, var);
                }
                else
                    _patients.Search(var);
            }
        }
        private void buttonDownMenus_ItemClick(object sender, ButtonDownMenu.SelectedItem item)
        {
            if (item.SelectValue == "修改密码")
            {
                PwdChangeControl pwdChange = new PwdChangeControl();
                this.workSpaceControl1.ShowViewDialog(pwdChange, pwdChange.Width, pwdChange.Height);
            }
            else if (item.SelectValue == "切换用户")
            {
                LoginFrm loginForm = new LoginFrm(true);
                loginForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                ScreenLocker.lockState = true;
                ExtendApplicationContext.Current.LoginUser.RUN_ADDRESS = "";
                ExtendApplicationContext.Current.LoginUser.RUN_MODE = 4;
                userRepository.SaveUser(ExtendApplicationContext.Current.LoginUser);
                ExtendApplicationContext.Current.LoginUser = null;
                DialogResult dialogResult = loginForm.ShowDialog();
                //if (dialogResult == DialogResult.Cancel)
                //{
                //    if (MessageBoxFormPC.Show("是否要退出系统?",
                //                  "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        try
                //        {
                //            Application.Exit();
                //        }
                //        catch
                //        {
                //            System.Environment.Exit(0);
                //        }
                //        return;
                //    }
                //}
                //if (dialogResult != DialogResult.OK)
                //{
                //    try
                //    {
                //        Application.Exit();
                //    }
                //    catch
                //    {
                //        System.Environment.Exit(0);
                //    }
                //    return;
                //}
                if (LoginFrm.IsChangeUser)
                {
                    InitMainForm();
                }
            }
            else if(item.SelectValue == "关    于")
            {
                About about = new About();
                about.ShowDialog();
            }
        }

        public override void UserLock()
        {
            SaveEventSort();
            LoginFrm loginForm = new LoginFrm(true);
            loginForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ScreenLocker.lockState = true;
            DialogResult dialogResult = loginForm.ShowDialog();
            //if (dialogResult == DialogResult.Cancel)
            //{
            //    if (MessageBoxFormPC.Show("是否要退出系统?",
            //                  "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            Application.Exit();
            //        }
            //        catch
            //        {
            //            System.Environment.Exit(0);
            //        }
            //        return;
            //    }
            //}
            //if (dialogResult != DialogResult.OK)
            //{
            //    try
            //    {
            //        Application.Exit();
            //    }
            //    catch
            //    {
            //        System.Environment.Exit(0);
            //    }
            //    return;
            //}
        }

        private void tableControlMenuTest_ItemClick(object sender, TableControlMenu.SelectedItem item)
        {
            leftBarControl1_ViewChangedEventHandler(sender, new ViewChangedEventArgs(item.SelectValue));
        }

        private void tableControlMenuInstruments_ItemClick(object sender, TableControlMenu.SelectedItem item)
        {
            leftBarControl1_ViewChangedEventHandler(sender, new ViewChangedEventArgs("医疗文书@" + item.SelectValue));
        }

        #region ITimeTick

        private static MainFrm _MainTickFrm = null;
        public static MainFrm MainTickFrm
        {
            get
            {
                if (_MainTickFrm == null)
                {
                    _MainTickFrm = ActiveForm as MainFrm;
                }
                return _MainTickFrm;
            }
            private set { _MainTickFrm = value; }
        }

        public List<ITimeTick> tickList = new List<ITimeTick>();

        public void Register(ITimeTick timer)
        {
            tickList.Add(timer);
        }

        public void UnRegister(ITimeTick timer)
        {
            tickList.Remove(timer);
        }

        public void OnTicked()
        {
            ExtendApplicationContext.Current.ClockTick++;
            ExtendApplicationContext.Current.SystemRunClockTick++;
            if (ApplicationConfiguration.RefreshTimeSpan <= 2)
            {
                ApplicationConfiguration.RefreshTimeSpan = 120;
            }
            if (ExtendApplicationContext.Current.ClockTick % ApplicationConfiguration.RefreshTimeSpan == 0)
            {
                ExtendApplicationContext.Current.ClockTick = 0;
                OnRefreshTimeSpanRefreshDoc();
                RefreshVitalSignData();
            }
            //if (ExtendApplicationContext.Current.ClockTick % 10 == 0 && workSpaceControl1.splitContainer1.Panel2Collapsed)
            //{
            //    searchTextBox1.Focus();
            //}
            //using (BackgroundWorker worker = new BackgroundWorker())
            //{
            //    worker.DoWork += delegate(object sender, DoWorkEventArgs e)
            //    {
            //        RefreshMessage();
            //    };
            //    worker.RunWorkerAsync();
            //}
            foreach (var item in tickList)
            {
                try
                {
                    item.OnTicked();
                }
                catch { throw; }
            }
        }

        private void Timer_Ticked(object sender, EventArgs e)
        {
            OnTicked();
        }

        #endregion

        private void workSpaceControl1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 页面最小化后再显示，强制刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.Show();
                Application.DoEvents();

            }
            
        }
    }
}
