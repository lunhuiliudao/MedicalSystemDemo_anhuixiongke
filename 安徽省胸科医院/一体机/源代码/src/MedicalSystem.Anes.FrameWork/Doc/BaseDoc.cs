/*----------------------------------------------------------------
// Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
// 文件名：BaseDoc.cs
// 文件功能描述：医疗文书的基类
// 创建标识：顾伟伟 2011-06-05
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Designer;
using DevExpress.XtraEditors;
using System.Diagnostics;
using DevExpress.XtraBars.Demos.DockingDemo;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text.pdf;
using MedicalSystem.Anes.Document.Configurations;
using MedicalSystem.AnesWorkStation.Domain;
using System.Linq;
using MedicalSystem.Anes.Document.Properties;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.FrameWork.Properties;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;

namespace MedicalSystem.Anes.Document.Documents
{
    /// <summary>
    /// 医疗文书的基类
    /// </summary>
    [ToolboxItem(false)]
    public partial class BaseDoc : BaseView
    {
        /// <summary>
        /// 数据源集合
        /// </summary>
        private Dictionary<string, DataTable> _dataSources = new Dictionary<string, DataTable>();
        private Dictionary<string, DataTable> originalDataSources = new Dictionary<string, DataTable>();
        protected string _pageName = null;
        protected System.Drawing.Printing.PaperSize _paperSize = null;
        protected float _pagePrintHeight = 1050;
        protected bool _pageFromHeight = false;
        public int _pageHours = 4;
        public bool isShowButton = true;
        public Bitmap _imgReport;
        public DataTemplate curDataTemplate = null;

        private bool _isPostSuccessed = true;
        /// <summary>
        /// 文书上传是否成功，用于归档
        /// </summary>
        public bool IsPostSuccessed
        {
            get { return _isPostSuccessed; }
            set { _isPostSuccessed = value; }
        }

        /// <summary>
        /// 打印是否完成
        /// </summary>
        public bool IsPrintEnd = false;
        // protected int _pageHours = ApplicationConfiguration.AnesDocPageHours; 
        /// <summary>
        /// 分页设置类
        /// </summary>
        private PagerSetting _pageSetting = new PagerSetting();
        /// <summary>
        /// 控件处理类集合
        /// </summary>
        protected List<IUIElementHandler> _UIElementHandlers = new List<IUIElementHandler>();
        /// <summary>
        /// 标题
        /// </summary>
        private new string _caption = "麻醉单";
        /// <summary>
        /// 医疗文书模版名称
        /// </summary>
        private string _reportName = string.Empty;

        private DocKind _docKind = DocKind.Default;

        System.Windows.Forms.DockStyle _anesSheetDetailsDockStyle = System.Windows.Forms.DockStyle.Fill;

        private int _width;
        private int _pageHeight = 0;
        public string statusReadOnly = string.Empty;

        private bool saveResult = true; // 文书保存结果
        /// <summary>
        /// 文书保存结果
        /// </summary>
        public bool SaveResult
        {
            get { return this.saveResult; }
        }

        protected string curDoublePrintName = string.Empty;                   // 当前文书对应的双面打印文书名称

        public BaseDoc()
        {
            InitializeComponent();
            if (ExtendAppContext.Current.LoginUser.isMDSD)
                this.DesignButton.Visible = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014) // 禁掉清除背景消息 
                return;
            base.WndProc(ref m);

        }
        // 设置参数
        public virtual void SetDocParameters(object[] param)
        {
        }

        public List<IUIElementHandler> GetUIElementHandlers()
        {
            return _UIElementHandlers;
        }

        /// <summary>
        /// 从模块加载文书,并设置界面元素
        /// </summary>
        /// <param name="reportName"></param>
        public Bitmap LoadReport(string reportName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ToolBarLayoutPanel.Visible = isShowButton;
                DoLoadReport(reportName);
                this.curDataTemplate = new DataTemplate(this);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            return _imgReport;
        }

        //定义委托
        public delegate void BtnClickHandle(object sender, int index);
        //定义事件
        public event BtnClickHandle BtnClicked;

        /// <summary>
        /// 加载文书
        /// 【Key文书名称，Value文书路径】
        /// </summary>
        /// <param name="reportNameDic">文书XML列表</param>
        public void LoadReport(Dictionary<string, string> reportNameDic, string firstReportName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (reportNameDic != null && reportNameDic.Count > 0)
                {
                    if (panelTabControl.Controls.Count > 1)//文书切换时，已经加载无需重复加载
                    {
                        DoLoadReport(reportNameDic[firstReportName]);
                        return;
                    }


                    panelTabControl.Visible = true;
                    int index = 0;
                    int tabWidth = 0;
                    List<string> _Items = new List<string>();//菜单列表
                    foreach (KeyValuePair<string, string> item in reportNameDic)
                    {
                        if (tabWidth + 211 > panelTabControl.Width)
                        {
                            _Items.Add(item.Key);
                            continue;
                        }
                        Label lab = new Label() { AutoSize = false, Width = 211, Text = item.Key, Tag = item.Value, TabIndex = index };
                        lab.Click += lab_Click;
                        panelTabControl.Controls.Add(lab);
                        lab.BringToFront();//将控件放置所有控件最前端 
                        lab.Dock = DockStyle.Left;
                        index++;
                        if (item.Key == firstReportName)
                        {
                            lab.Image = Resources.文书_选中;
                            lab.ForeColor = Color.FromArgb(77, 139, 211);
                        }
                        else
                        {
                            lab.Image = Resources.文书_未选中;
                            lab.ForeColor = Color.FromArgb(92, 92, 92);
                        }
                        lab.TextAlign = ContentAlignment.MiddleCenter;
                        tabWidth += 211;

                    }
                    DoLoadReport(reportNameDic[firstReportName]);

                    if (_Items.Count > 0)
                    {
                        downMenuDoc.Visible = true;
                        downMenuDoc.Tags = index;
                        downMenuDoc.Items = _Items;
                        downMenuDoc.InitItem(firstReportName);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        void lab_Click(object sender, EventArgs e)
        {
            if (BtnClicked != null)
            {
                BtnClicked(this, ((Label)(sender)).TabIndex);
            }
        }
        private void downMenuDoc_ItemClick(object sender, DownMenuDoc.SelectedItem item, int index)
        {
            if (BtnClicked != null)
            {
                BtnClicked(this, index);
            }
        }
        /// <summary>
        /// 执行文书的加载,数据绑定
        /// </summary>
        /// <param name="reportName"></param>
        private Bitmap DoLoadReport(string reportName)
        {
            //从模版加载文书

            this.MedReportView.LoadReport(reportName);

            _reportName = reportName;

            //向文书添加UIElementHandler
            AddUIElementHandlers();

            //添加数据源
            BuildData(_dataSources);

            // 保存原始数据
            SetOriginalDataSources();

            //根据控件类型,将控件添加到UIElementHandlers
            BuildUIElementsControl(this.MedReportView.Controls);

            //分页设置
            OnPagerSetting(_pageSetting);

            //设置分页按纽是否可见
            InitalizePageButton(_pageSetting.PagerDesc.Count > 1);

            //按类型处理控件
            UIElementHandler();

            //界面生成完毕
            OnViewBuilded(_UIElementHandlers, _dataSources);


            this.MedReportView.Dock = DockStyle.None;
            this.MedReportView.Top = 0;
            if (_autoCenter)
            {
                this.MedReportView.Left = (int)((Width - MedReportView.Width) / 2);
            }
            this.MedReportView.Height = _pageHeight;

            _imgReport = new Bitmap(MedReportView.Width, MedReportView.Height);
            this.MedReportView.DrawToBitmap
                (_imgReport, new Rectangle(0, 0, _imgReport.Width, _imgReport.Height));

            return _imgReport;
        }

        /// <summary>
        /// 记录原始数据
        /// </summary>
        private void SetOriginalDataSources()
        {
            // 保存原始数据
            this.originalDataSources.Clear();
            foreach (KeyValuePair<string, DataTable> item in this._dataSources)
            {
                if (!this.originalDataSources.ContainsKey(item.Key))
                {
                    DataTable newDt = item.Value.Copy();
                    this.originalDataSources.Add(item.Key, newDt);
                }
            }
        }

        protected bool _autoCenter = true;

        /// <summary>
        /// 设置分页按纽样式
        /// </summary>
        /// <param name="visible"></param>
        private void InitalizePageButton(bool visible)
        {
            // this.LastPageButton.Visible = visible;
            this.NextPageButton.Visible = visible;
            this.PreviousPageButton.Visible = visible;
            // this.FirstPageButton.Visible = visible;



            //this.gotoPageComboBox.Visible = visible;
        }
        /// <summary>
        /// 调用UIElementHandler类的方法来处理控件
        /// </summary>
        private void UIElementHandler()
        {
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.Handle();
                handler.HasDirty = false;
            }
            //如果允许分页,则触发分页事件,显示首页
            if (_pageSetting.AllowPage)
            {
                FirstPageButton_Click(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="dataSource"></param>
        protected virtual void BuildData(Dictionary<string, DataTable> dataSource)
        {

        }
        /// <summary>
        /// 打印前
        /// </summary>
        /// <param name="pageDesc"></param>
        protected virtual bool CheckBeforePrint()
        {
            return true;
        }


        /// <summary>
        /// 打印后
        /// </summary>
        /// <param name="pageDesc"></param>
        protected virtual void OnAfterPrint()
        {

        }

        public virtual bool AllowSingleDocModify()
        {
            return false;
        }

        public virtual bool OnCustomCheckBeforeSave()
        {
            return true;
        }

        /// <summary>
        /// 打印后触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EventAfterPrint(object sender, EventArgs e);
        public event EventAfterPrint AfterPrint;


        /// <summary>
        ///向文书添加UIElementHandler处理类
        /// </summary>
        /// <param name="handler"></param>
        private void AddUIElementHandlers()
        {
            _UIElementHandlers.Clear();

            _UIElementHandlers.Add(new LabelHandler());
            _UIElementHandlers.Add(new TextBoxHandler());
            _UIElementHandlers.Add(new RichTextBoxHandler());
            _UIElementHandlers.Add(new CustomControlHandler());
            _UIElementHandlers.Add(new GridViewHandler());

            AddCustomUIElementHandlers(_UIElementHandlers);
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.AttatchDoc = this;
            }
        }
        /// <summary>
        /// 向文书添加自定义的UIElementHandler处理类
        /// </summary>
        /// <param name="handlers"></param>
        protected virtual void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {

        }
        /// <summary>
        ///控件属性事件设置,数据绑定等
        /// </summary>
        private void BuildUIElementsControl(ControlCollection controls)
        {
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.DataSource = _dataSources;
                handler.ErrorProvider = this.errorProvider1;
                handler.MedicalPaperUIElementHandlers = _UIElementHandlers;
                handler.PagerSetting = _pageSetting;
            }

            foreach (Control element in controls)
            {
                OnControlInitalizing(element);

                foreach (IUIElementHandler handler in _UIElementHandlers)
                {
                    handler.AddControlByType(element);
                }
                //处理子控件
                if (element.HasChildren)
                {
                    BuildUIElementsControl(element.Controls);
                }

                if (_pageHeight < element.Bottom)
                {
                    _pageHeight = element.Bottom;
                }
            }

        }
        /// <summary>
        /// 控件创建后,未被UIElementHandler处理前调用的方法
        /// </summary>
        /// <param name="control"></param>
        protected virtual void OnControlInitalizing(Control control)
        {

        }
        /// <summary>
        /// 界面生成完,所有控件都被UIElementHandler处理后调用的方法
        /// </summary>
        /// <param name="handlers"></param>
        protected virtual void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            List<NewPictureBox> picBoxList = ReportViewer.GetControls<NewPictureBox>();
            foreach (var item in picBoxList)
            {
                if (item.Name == "picBoxInpNo")
                {
                    Code39 code39 = new Code39();
                    code39.Height = 30;
                    code39.Magnify = 0;

                    // 获取患者信息的INP_NO用于归档时生成条形码的时候可以使用
                    List<MED_PATS_IN_HOSPITAL> patsInHospital = AnesInfoService.ClientInstance.GetPatsInHospitalList(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, ExtendAppContext.Current.PatientInformationExtend.VISIT_ID);
                    if (patsInHospital.Count > 0)
                    {
                        ExtendAppContext.Current.PatientInformationExtend.INP_NO = patsInHospital[0].INP_NO;// 条形码会使用到
                    }
                    else
                    {
                        ExtendAppContext.Current.PatientInformationExtend.INP_NO = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                    }
                    item.Image = code39.GetCodeImage(ExtendAppContext.Current.PatientInformationExtend.INP_NO, Code39.Code39Model.Code39Normal, true);
                }
            }

        }

        /// <summary>
        /// 在完成基类ValidateData()方法后调用的自定义扩展验证方法
        /// </summary>
        /// <param name="UIElementHandlers"></param>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        protected virtual bool CustomValidate(List<IUIElementHandler> UIElementHandlers, Dictionary<string, DataTable> dataSource)
        {
            return true;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        protected virtual bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            return true;
        }

        protected virtual bool SaveDocDataPars(Dictionary<string, DataTable> dataSource)
        {
            DocDataPars docData = new DocDataPars();

            if (dataSource.ContainsKey("MED_OPERATION_MASTER"))
            {
                List<MED_OPERATION_MASTER> operMasterList = new ModelHandler<MED_OPERATION_MASTER>().
                    FillModel(dataSource["MED_OPERATION_MASTER"]);
                if (operMasterList != null && operMasterList.Count > 0)
                {
                    docData.OperMaster = operMasterList[0];
                    docData.OriginalOperMaster = new ModelHandler<MED_OPERATION_MASTER>().
                    FillModel(this.OriginalDataSources["MED_OPERATION_MASTER"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_OPERATION_MASTER_EXT"))
            {
                List<MED_OPERATION_MASTER_EXT> operMasterEXTList = new ModelHandler<MED_OPERATION_MASTER_EXT>().
                    FillModel(dataSource["MED_OPERATION_MASTER_EXT"]);
                if (operMasterEXTList != null && operMasterEXTList.Count > 0)
                {
                    docData.OperMasterExt = operMasterEXTList[0];
                    docData.OriginalOperMasterExt = new ModelHandler<MED_OPERATION_MASTER_EXT>().
                    FillModel(this.OriginalDataSources["MED_OPERATION_MASTER_EXT"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_PAT_MASTER_INDEX"))
            {
                List<MED_PAT_MASTER_INDEX> patIndexList = new ModelHandler<MED_PAT_MASTER_INDEX>().
                    FillModel(dataSource["MED_PAT_MASTER_INDEX"]);
                if (patIndexList != null && patIndexList.Count > 0)
                {
                    docData.PatMasterIndex = patIndexList[0];
                    docData.OriginalPatMasterIndex = new ModelHandler<MED_PAT_MASTER_INDEX>().
                    FillModel(this.OriginalDataSources["MED_PAT_MASTER_INDEX"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_PAT_VISIT"))
            {
                List<MED_PAT_VISIT> patVisitList = new ModelHandler<MED_PAT_VISIT>().
                    FillModel(dataSource["MED_PAT_VISIT"]);
                if (patVisitList != null && patVisitList.Count > 0)
                {
                    docData.PatVisit = patVisitList[0];
                    docData.OriginalPatVisit = new ModelHandler<MED_PAT_VISIT>().
                    FillModel(this.OriginalDataSources["MED_PAT_VISIT"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_ANESTHESIA_PLAN"))
            {
                List<MED_ANESTHESIA_PLAN> anesPlanList = new ModelHandler<MED_ANESTHESIA_PLAN>().
                    FillModel(dataSource["MED_ANESTHESIA_PLAN"]);
                if (anesPlanList != null && anesPlanList.Count > 0)
                {
                    docData.AnesPlan = anesPlanList[0];
                    docData.OriginalAnesPlan = new ModelHandler<MED_ANESTHESIA_PLAN>().
                    FillModel(this.OriginalDataSources["MED_ANESTHESIA_PLAN"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_ANESTHESIA_PLAN_PMH"))
            {
                List<MED_ANESTHESIA_PLAN_PMH> anesPlanPMHList = new ModelHandler<MED_ANESTHESIA_PLAN_PMH>().
                    FillModel(dataSource["MED_ANESTHESIA_PLAN_PMH"]);
                if (anesPlanPMHList != null && anesPlanPMHList.Count > 0)
                {
                    docData.AnesPlanPmh = anesPlanPMHList[0];
                    docData.OriginalAnesPlanPmh = new ModelHandler<MED_ANESTHESIA_PLAN_PMH>().
                    FillModel(this.OriginalDataSources["MED_ANESTHESIA_PLAN_PMH"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_ANESTHESIA_PLAN_EXAM"))
            {
                List<MED_ANESTHESIA_PLAN_EXAM> anesPlanExamList = new ModelHandler<MED_ANESTHESIA_PLAN_EXAM>().
                    FillModel(dataSource["MED_ANESTHESIA_PLAN_EXAM"]);
                if (anesPlanExamList != null && anesPlanExamList.Count > 0)
                {
                    docData.AnesPlanExam = anesPlanExamList[0];
                    docData.OriginalAnesPlanExam = new ModelHandler<MED_ANESTHESIA_PLAN_EXAM>().
                    FillModel(this.OriginalDataSources["MED_ANESTHESIA_PLAN_EXAM"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_PATS_IN_HOSPITAL"))
            {
                List<MED_PATS_IN_HOSPITAL> patsInHospitalList = new ModelHandler<MED_PATS_IN_HOSPITAL>().
                    FillModel(dataSource["MED_PATS_IN_HOSPITAL"]);
                if (patsInHospitalList != null && patsInHospitalList.Count > 0)
                {
                    docData.PatsInHospital = patsInHospitalList[0];
                    docData.OriginalPatsInHospital = new ModelHandler<MED_PATS_IN_HOSPITAL>().
                    FillModel(this.OriginalDataSources["MED_PATS_IN_HOSPITAL"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_ANESTHESIA_INPUT_DATA"))
            {
                List<MED_ANESTHESIA_INPUT_DATA> anesInputDataList = new ModelHandler<MED_ANESTHESIA_INPUT_DATA>().
                    FillModel(dataSource["MED_ANESTHESIA_INPUT_DATA"]);
                if (anesInputDataList != null && anesInputDataList.Count > 0)
                {
                    docData.AnesInputData = anesInputDataList[0];
                    docData.OriginalAnesInputData = new ModelHandler<MED_ANESTHESIA_INPUT_DATA>().
                    FillModel(this.OriginalDataSources["MED_ANESTHESIA_INPUT_DATA"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_OPERATION_ANALGESIC_MASTER"))
            {
                List<MED_OPERATION_ANALGESIC_MASTER> analgesicMaster = new ModelHandler<MED_OPERATION_ANALGESIC_MASTER>().
                    FillModel(dataSource["MED_OPERATION_ANALGESIC_MASTER"]);
                if (analgesicMaster != null && analgesicMaster.Count > 0)
                {
                    docData.OperAnalgesicMaster = analgesicMaster[0];
                    docData.OriginalOperAnalgesicMaster = new ModelHandler<MED_OPERATION_ANALGESIC_MASTER>().
                    FillModel(this.OriginalDataSources["MED_OPERATION_ANALGESIC_MASTER"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_OPER_ANALGESIC_MEDICINE"))
            {
                List<MED_OPER_ANALGESIC_MEDICINE> analgesicMedicine = new ModelHandler<MED_OPER_ANALGESIC_MEDICINE>().
                    FillModel(dataSource["MED_OPER_ANALGESIC_MEDICINE"]);
                if (analgesicMedicine != null)
                {
                    docData.OperAnalgesicMedicine = analgesicMedicine;
                    docData.OriginalOperAnalgesicMedicine = new ModelHandler<MED_OPER_ANALGESIC_MEDICINE>().
                    FillModel(this.OriginalDataSources["MED_OPER_ANALGESIC_MEDICINE"]);
                }
            }

            if (dataSource.ContainsKey("MED_OPER_ANALGESIC_TOTAL"))
            {
                List<MED_OPER_ANALGESIC_TOTAL> analgesicTotal = new ModelHandler<MED_OPER_ANALGESIC_TOTAL>().
                    FillModel(dataSource["MED_OPER_ANALGESIC_TOTAL"]);
                if (analgesicTotal != null)
                {
                    docData.OperAnalgesicTotal = analgesicTotal;
                    docData.OriginalOperAnalgesicTotal = new ModelHandler<MED_OPER_ANALGESIC_TOTAL>().
                    FillModel(this.OriginalDataSources["MED_OPER_ANALGESIC_TOTAL"]);
                }
            }

            if (dataSource.ContainsKey("MED_ANESTHESIA_RECOVER"))
            {
                List<MED_ANESTHESIA_RECOVER> anesRecover = new ModelHandler<MED_ANESTHESIA_RECOVER>().
                    FillModel(dataSource["MED_ANESTHESIA_RECOVER"]);
                if (anesRecover != null && anesRecover.Count > 0)
                {
                    docData.AnesRecover = anesRecover[0];
                    docData.OriginalAnesRecover = new ModelHandler<MED_ANESTHESIA_RECOVER>().
                    FillModel(this.OriginalDataSources["MED_ANESTHESIA_RECOVER"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_ANESTHESIA_INQUIRY"))
            {
                List<MED_ANESTHESIA_INQUIRY> anesInquiry = new ModelHandler<MED_ANESTHESIA_INQUIRY>().
                    FillModel(dataSource["MED_ANESTHESIA_INQUIRY"]);
                if (anesInquiry != null && anesInquiry.Count > 0)
                {
                    docData.AnesInquiry = anesInquiry[0];
                    docData.OriginalAnesInquiry = new ModelHandler<MED_ANESTHESIA_INQUIRY>().
                    FillModel(this.OriginalDataSources["MED_ANESTHESIA_INQUIRY"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_CHUFANG_RECORD"))
            {
                List<MED_CHUFANG_RECORD> chuFangList = new ModelHandler<MED_CHUFANG_RECORD>().
                    FillModel(dataSource["MED_CHUFANG_RECORD"]);
                if (null != chuFangList && chuFangList.Count > 0)
                {
                    docData.ChuFangRecord = chuFangList;
                    docData.OriginalChuFangRecord = new ModelHandler<MED_CHUFANG_RECORD>().
                        FillModel(this.OriginalDataSources["MED_CHUFANG_RECORD"]);
                }
            }

            if (dataSource.ContainsKey("MED_SAFETY_CHECKS"))
            {
                List<MED_SAFETY_CHECKS> safetyCheck = new ModelHandler<MED_SAFETY_CHECKS>().
                    FillModel(dataSource["MED_SAFETY_CHECKS"]);
                if (safetyCheck != null && safetyCheck.Count > 0)
                {
                    docData.SafetyChecks = safetyCheck[0];
                    docData.OriginalSafetyChecks = new ModelHandler<MED_SAFETY_CHECKS>().
                    FillModel(this.OriginalDataSources["MED_SAFETY_CHECKS"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_OPER_RISK_ESTIMATE"))
            {
                List<MED_OPER_RISK_ESTIMATE> operRiskEstimate = new ModelHandler<MED_OPER_RISK_ESTIMATE>().
                    FillModel(dataSource["MED_OPER_RISK_ESTIMATE"]);
                if (operRiskEstimate != null && operRiskEstimate.Count > 0)
                {
                    docData.OperRiskEstimate = operRiskEstimate[0];
                    docData.OriginalOperRiskEstimate = new ModelHandler<MED_OPER_RISK_ESTIMATE>().
                    FillModel(this.OriginalDataSources["MED_OPER_RISK_ESTIMATE"])[0];
                }
            }

            if (dataSource.ContainsKey("MED_PACU_SORCE"))
            {
                List<MED_PACU_SORCE> pacuSocre = new ModelHandler<MED_PACU_SORCE>().
                    FillModel(dataSource["MED_PACU_SORCE"]);
                if (pacuSocre != null && pacuSocre.Count > 0)
                {
                    docData.PacuSorce = pacuSocre;
                    docData.OriginalPacuSorce = new ModelHandler<MED_PACU_SORCE>().
                    FillModel(this.OriginalDataSources["MED_PACU_SORCE"]);
                }
            }

            if (dataSource.ContainsKey("MED_OPERATION_EXTENDED"))
            {
                docData.OperExtended = new ModelHandler<MED_OPERATION_EXTENDED>().
                    FillModel(dataSource["MED_OPERATION_EXTENDED"]);
                docData.OriginalOperExtended = new ModelHandler<MED_OPERATION_EXTENDED>().
                    FillModel(this.OriginalDataSources["MED_OPERATION_EXTENDED"]);
            }

            if (dataSource.ContainsKey("MED_POSTOPERATIVE_EXTENDED"))
            {
                docData.PostExtended = new ModelHandler<MED_POSTOPERATIVE_EXTENDED>().
                    FillModel(dataSource["MED_POSTOPERATIVE_EXTENDED"]);
                docData.OriginalPostExtended = new ModelHandler<MED_POSTOPERATIVE_EXTENDED>().
                    FillModel(this.OriginalDataSources["MED_POSTOPERATIVE_EXTENDED"]);
            }

            if (dataSource.ContainsKey("MED_PREOPERATIVE_EXPANSION"))
            {
                docData.PreExpansion = new ModelHandler<MED_PREOPERATIVE_EXPANSION>().
                    FillModel(dataSource["MED_PREOPERATIVE_EXPANSION"]);
                docData.OriginalPreExpansion = new ModelHandler<MED_PREOPERATIVE_EXPANSION>().
                    FillModel(this.OriginalDataSources["MED_PREOPERATIVE_EXPANSION"]);
            }

            bool result = CareDocService.ClientInstance.SaveDocDataPars(docData);
            return result;
        }

        /// <summary>
        /// 分页设置
        /// </summary>
        /// <param name="pageDesc"></param>
        protected virtual void OnPagerSetting(PagerSetting pagerSetting)
        {

        }
        /// <summary>
        /// 刷新数据前触发
        /// </summary>
        /// <param name="pageDesc"></param>
        protected virtual void OnBeforeRefreshData()
        {

        }
        /// <summary>
        /// 刷新数据后触发
        /// </summary>
        /// <param name="pageDesc"></param>
        protected virtual void OnAfterRefreshData()
        {

        }
        /// <summary>
        /// 当前页改变事件
        /// </summary>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="isMasterPage">当前页是否为主页</param>
        public void PageIndexChanged(int mainPageIndex, bool isMasterPage, Dictionary<string, DataTable> dataSource)
        {
            // this.PageDesc.Text = string.Format("第{0}页/共{1}页", PagerSetting.CurrentPageIndex + 1, _pageSetting.TotalPageCount);

            int oldPageIndex = PagerSetting.CurrentPageIndex;
            int addPage = 0;
            foreach (PageDesc pageD in PagerSetting.PagerDesc)
            {
                if (pageD.PageIndex >= mainPageIndex) break;
                if (!isMasterPage)
                {
                    addPage++;
                }
            }
            // _pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].IsMain
            if (isMasterPage)
            {
                PagerSetting.CurrentPageIndex = mainPageIndex + addPage;
            }
            else
            {
                PagerSetting.CurrentPageIndex = mainPageIndex + 1;
            }

            OnPageIndexChanged(mainPageIndex, isMasterPage, dataSource);

            PagerSetting.CurrentPageIndex = oldPageIndex;
        }
        /// <summary>
        /// 调用自定义刷新方法
        /// </summary>
        public void CustomRefresh()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (_pageSetting.AllowPage && _pageSetting.TotalPageCount > 0)
                {
                    OnCustomRefresh(_pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].PageIndex,
                                 _pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].IsMain, _dataSources);
                }
                else
                {
                    OnCustomRefresh(0, true, _dataSources);
                }
            }
            catch (Exception e)
            {

                ExceptionHandler.Handle(e);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }
        /// <summary>
        /// 自定义刷新数据.部分刷新
        /// </summary>
        /// <param name="currentPageIndex"><当前页码/param>
        /// <param name="dataSource">数据源</param>
        /// <param name="controls">要刷新的控件类型</param>
        protected virtual void OnCustomRefresh(int mainPageIndex, bool isMasterPage, Dictionary<string, DataTable> dataSource)
        {

        }

        /// <summary>
        /// 制定控件是否有脏数据
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        protected bool HasDirty(Type[] controls)
        {
            foreach (Type t in controls)
            {
                foreach (IUIElementHandler handler in _UIElementHandlers)
                {
                    if (handler.GetControlType == t)
                    {
                        if (handler.HasDirty)
                            return true;

                    }

                }
            }
            return false;
        }


        private bool isCustomRefreshFinished = true;
        /// <summary>
        /// 刷新指定控件的数据
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="controls"></param>
        protected void RefreshCurrentControls(DateTimeRange timeSpan, Type[] controls, bool isMasterPage, int attachPageMaxCount)
        {
            if (isCustomRefreshFinished == false)
                return;
            isCustomRefreshFinished = false;
            if (HasDirty(controls))
            {

                DialogResult dialogResult = Dialog.MessageBox("您当前的界面有未保存的数据,是否保存此数据?", "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!ValidateData())
                    {
                        isCustomRefreshFinished = true;
                        return;
                    }
                    else
                    {
                        if (!OnCustomCheckBeforeSave()) return;
                        OnSaveData(_dataSources);
                        foreach (Type t in controls)
                        {
                            foreach (IUIElementHandler handler in _UIElementHandlers)
                            {
                                if (handler.GetControlType == t)
                                {
                                    handler.HasDirty = false;
                                }
                            }
                        }
                        //MessageQueue.AddMessage("数据保存成功", Color.Black);
                        //MessageBox.Show("数据保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("数据保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }

                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    isCustomRefreshFinished = true;
                    return;
                }

            }

            foreach (Type t in controls)
            {
                foreach (IUIElementHandler handler in _UIElementHandlers)
                {
                    if (handler.GetControlType == t)
                    {

                        RefreshHandlerControls(handler, timeSpan, isMasterPage, attachPageMaxCount);
                        break;
                    }
                }
            }
            isCustomRefreshFinished = true;
        }

        /// <summary>
        /// 当前页改变事件
        /// </summary>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="isMasterPage">当前页是否为主页</param>
        /// <param name="dataSource">数据源</param>
        protected virtual void OnPageIndexChanged(int mainPageIndex, bool isMasterPage, Dictionary<string, DataTable> dataSource)
        {

        }
        /// <summary>
        /// 是否含有脏数据
        /// </summary>
        public bool HasDirty()
        {
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                if (handler.HasDirty)
                    return true;
            }
            return false;
        }


        #region Functions
        /// <summary>
        /// 保存
        /// </summary>
        public override bool Save()
        {
            if (!ValidateData() || !OnCustomCheckBeforeSave())
            {
                return false;
            }

            bool res = OnSaveData(_dataSources);
            if (res)
            {
                foreach (IUIElementHandler handler in _UIElementHandlers)
                {
                    handler.HasDirty = false;
                }

                // 刷新数据
                this.RefreshData();

                MessageBox.Show("数据保存成功", "提示信息",
                                MessageBoxButtons.OK, MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                MessageBox.Show("数据保存失败！", "提示信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }

            //return true;
            return res; // 保存成功时则关闭文书(返回true)，保存失败则不关闭(返回false)

        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save(bool bNeedMsg)
        {
            if (!ValidateData())
                return;
            if (!OnCustomCheckBeforeSave()) return;
            OnSaveData(_dataSources);
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.HasDirty = false;
            }
            if (bNeedMsg)
            {
                //MessageQueue.AddMessage("数据保存成功", Color.Black);
                XtraMessageBox.Show("数据保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// 标题
        /// </summary>
        public new string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
            }
        }
        /// <summary>
        /// 获取文书阅读控件
        /// </summary>
        public MedReportView ReportViewer
        {
            get
            {
                return this.MedReportView;
            }
        }
        public int PageWidth
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public void HideScrollBar()
        {
            this.panelDoc.AutoScroll = false;
        }
        public void ShowScrollBar()
        {
            this.panelDoc.AutoScroll = true;
        }
        /// <summary>
        /// 当鼠标在首页患者列表中滑过或者单击时,在右侧患者详情面版中刷新患者数据
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="operId"></param>
        public void RefreshSelectedPatient(string patientId, decimal visitId, int operId)
        {
            OnRefreshSelectedPatient(_dataSources, patientId, visitId, operId);

            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.RefreshData();
                handler.HasDirty = false;
            }
        }
        /// <summary>
        ///  当鼠标在首页患者列表中滑过或者单击时,在右侧患者详情面版中刷新患者数据
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="operId"></param>
        protected virtual void OnRefreshSelectedPatient(Dictionary<string, DataTable> dataSource, string patientId, decimal visitId, int operId)
        {


        }
        public bool RefreshData(bool ignoreDirty)
        {
            OnBeforeRefreshData();
            //检查是否有脏数据
            if (!ignoreDirty && this.HasDirty())
            {
                DialogResult dialogResult = Dialog.MessageBox("您当前的界面有未保存的数据,是否保存此数据?",
                    "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!ValidateData())
                        return false;
                    else
                    {
                        if (!OnCustomCheckBeforeSave()) return false;
                        OnSaveData(_dataSources);
                        //MessageQueue.AddMessage("数据保存成功", Color.Black);
                        //XtraMessageBox.Show("数据保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("数据保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }

                }
                else if (dialogResult == DialogResult.Cancel)
                    return false;
            }
            //重新生成数据源
            BuildData(_dataSources);
            // 保存原始数据
            SetOriginalDataSources();
            //分页设置
            OnPagerSetting(_pageSetting);
            //设置分页按纽是否可见
            InitalizePageButton(_pageSetting.PagerDesc.Count > 1);
            //刷新界面,重新绑定数据源到控件
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                //如果无分页活动,则直接刷新数据到控件,否则将在PageIndexChanged事件中刷新数据
                if (_pageSetting.AllowPage == false)
                {
                    handler.RefreshData();
                    if (handler.GetCurrentControl is AnesBand)
                    {
                        (handler.GetCurrentControl as AnesBand).Invalidate();
                    }
                }
                handler.HasDirty = false;
            }
            //如果允许分页,则触发分页事件,显示首页
            if (_pageSetting.AllowPage)
            {
                //FirstPageButton_Click(this, EventArgs.Empty);

                if (_pageSetting.TotalPageCount > 0)
                {
                    //_pageSetting.CurrentPageIndex = 0;
                    if (_pageSetting.CurrentPageIndex >= _pageSetting.TotalPageCount)
                    { _pageSetting.CurrentPageIndex = 0; }

                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        PageIndexChanged(_pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].PageIndex,
                                 _pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].IsMain, _dataSources);
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
            OnAfterRefreshData();

            return true;
        }


        /// <summary>
        /// 验证是否有脏数据,数据验证,提示脏数据是否保存,重新生成数据源,重新设置分页,重新绑定界面数据,
        /// </summary>
        public override void RefreshData()
        {
            OnBeforeRefreshData();
            //检查是否有脏数据
            //if (!ValidateData())
            //    return;
            if (this.HasDirty())
            {
                DialogResult dialogResult = Dialog.MessageBox("您当前的界面有未保存的数据,是否保存此数据?",
                    "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!ValidateData())
                        return;
                    else
                    {
                        if (!OnCustomCheckBeforeSave()) return;
                        OnSaveData(_dataSources);
                        //MessageQueue.AddMessage("数据保存成功", Color.Black);
                        //XtraMessageBox.Show("数据保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("数据保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }

                }
                else if (dialogResult == DialogResult.Cancel)
                    return;
            }
            //重新生成数据源
            BuildData(_dataSources);
            SetOriginalDataSources();
            //分页设置
            OnPagerSetting(_pageSetting);
            //设置分页按纽是否可见
            InitalizePageButton(_pageSetting.PagerDesc.Count > 1);
            //刷新界面,重新绑定数据源到控件
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                //如果无分页活动,则直接刷新数据到控件,否则将在PageIndexChanged事件中刷新数据
                if (_pageSetting.AllowPage == false)
                {
                    handler.RefreshData();
                    if (handler.GetCurrentControl is AnesBand)
                    {
                        (handler.GetCurrentControl as AnesBand).Invalidate();
                    }
                }
                handler.HasDirty = false;
            }
            List<MPanel> panels = this.ReportViewer.GetControls<MPanel>();
            if (panels != null && panels.Count > 0)
            {
                foreach (MPanel panel in panels)
                {
                    if (panel.Name.Equals("DocTitle"))
                    {
                        panel.Visible = false;
                    }
                }
            }
            //如果允许分页,则触发分页事件,显示首页
            if (_pageSetting.AllowPage)
            {
                //FirstPageButton_Click(this, EventArgs.Empty);

                if (_pageSetting.TotalPageCount > 0)
                {
                    //_pageSetting.CurrentPageIndex = 0;
                    if (_pageSetting.CurrentPageIndex >= _pageSetting.TotalPageCount)
                    { _pageSetting.CurrentPageIndex = 0; }

                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        PageIndexChanged(_pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].PageIndex,
                                 _pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].IsMain, _dataSources);
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
            OnAfterRefreshData();
        }
        /// <summary>
        /// 设置所有控件是否可编辑
        /// </summary>
        /// <param name="canEdit"></param>
        /// <returns></returns>
        public void SetAllControlEditable(bool canEdit)
        {
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.SetAllControlEditable(canEdit);
            }
        }

        public void SetAllButtonsEnable(bool isEnable)
        {
            foreach (Control ctr in ToolBarLayoutPanel.Controls)
            {
                if (ctr is SimpleButton)
                {
                    (ctr as SimpleButton).Enabled = isEnable;
                }
            }
        }
        /// <summary>
        /// 根据当前页的时间范围,将数据源绑定到界面
        /// </summary>
        public void SetCurrentPageData(DateTimeRange timeSpan, bool isMasterPage, int attachPageMaxCount)
        {
            if (_pageSetting.AllowPage)
            {
                foreach (IUIElementHandler handler in _UIElementHandlers)
                {
                    handler.PagerSetting.PageTimeSpan = timeSpan;
                    handler.RefreshData();
                    handler.HasDirty = false;
                    //if (handler.GetCurrentControl is AnesGraph)
                    //{
                    //    if (isMasterPage)
                    //        handler.SetControlVisible(true);
                    //    else
                    //        handler.SetControlVisible(false);
                    //}
                    //else if (handler.GetCurrentControl is MedLegengGraph)
                    //{
                    //    if (isMasterPage)
                    //        handler.SetControlVisible(true);
                    //    else
                    //        handler.SetControlVisible(false);
                    //}
                    //else if (handler.GetCurrentControl is MedAnesSheetDetails)
                    if (handler.GetCurrentControl is MedAnesSheetDetails)
                    {
                        MedAnesSheetDetails anesSheetDetails = handler.GetCurrentControl as MedAnesSheetDetails;
                        int totalCount = anesSheetDetails.TotalCount > 0 ? anesSheetDetails.TotalCount : attachPageMaxCount;
                        if (isMasterPage)
                        {
                            if (anesSheetDetails.Dock == DockStyle.Fill)
                            {
                                anesSheetDetails.Dock = _anesSheetDetailsDockStyle;
                            }
                            else
                            {
                                _anesSheetDetailsDockStyle = anesSheetDetails.Dock;
                            }
                            anesSheetDetails.StartIndex = 0;

                        }
                        else
                        {
                            anesSheetDetails.Dock = DockStyle.Top;
                            anesSheetDetails.StartIndex = totalCount;
                        }
                        int cnt = 0;
                        for (int i = 0; i < anesSheetDetails.Collections.Count; i++)
                        {
                            if (anesSheetDetails.Collections[i] == null)
                                continue;
                            for (int j = 0; j < anesSheetDetails.Collections[i].Points.Count; j++)
                            {
                                if (anesSheetDetails.Collections[i].Points[j].StartTime >= timeSpan.StartDateTime && anesSheetDetails.Collections[i].Points[j].StartTime < timeSpan.StartDateTime.AddHours(_pageHours))
                                {
                                    cnt++;
                                    anesSheetDetails.Collections[i].Points[j].Index = cnt;//更新序号
                                }
                            }
                        }
                    }
                    if (handler.GetCurrentControl is AnesBand)
                    {
                        (handler.GetCurrentControl as AnesBand).Invalidate();
                    }

                }
            }
            else
            {
                throw new NotSupportedException("SetCurrentPageData方法只能在使用分页功能的文书中被调用");
            }

        }

        /// <summary>
        /// 执行数据验证
        /// </summary>
        /// <returns></returns>
        public bool ValidateData()
        {
            bool isValid = true;
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.ClearError();
            }
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                handler.EndCurrentEdit();

                if (!handler.Validate())
                    isValid = false;
            }
            return isValid && CustomValidate(_UIElementHandlers, _dataSources);
        }
        /// <summary>
        /// 保存数据模版
        /// </summary>
        protected virtual void SaveDocDataTemplate()
        {
            if (null != this.curDataTemplate)
            {
                this.curDataTemplate.SaveModel();
            }
        }
        /// <summary>
        /// 应用数据模版
        /// </summary>
        protected virtual void ApplyDocDataTemplate()
        {
            if (this.curDataTemplate != null)
            {
                this.curDataTemplate.ApplyModel();
            }
        }

        /// <summary>
        /// 保存整个文书的数据模版
        /// </summary>
        protected virtual void SaveAllDocDataTemplate()
        {
        }

        /// <summary>
        /// 获取当前文书的整体模板数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTotalModelDataTabla()
        {
            DataTable TotalModelDT = new DataTable();
            TotalModelDT.Columns.Add(new DataColumn("ControlName", typeof(string)));
            TotalModelDT.Columns.Add(new DataColumn("ControlValue", typeof(string)));
            foreach (Control control in this.ReportViewer.GetControls<Control>())
            {
                if (control is MTextBox || control is MRichTextBox || control is CustomControl)
                {
                    if (control is MTextBox)
                    {
                        if ((control as MTextBox).IsTotalModel == false) continue;
                    }
                    if (control is MRichTextBox)
                    {
                        if ((control as MRichTextBox).IsTotalModel == false) continue;
                    }
                    if (control is CustomControl)
                    {
                        if ((control as CustomControl).IsTotalModel == false) continue;
                    }
                    DataRow row = TotalModelDT.NewRow();
                    row["ControlName"] = control.Name;
                    if (control is CustomControl)
                    {
                        foreach (Control ctr in control.Controls)
                        {
                            if ((control as CustomControl).MultiSelect)
                            {
                                row["ControlValue"] = (control as CustomControl).Value;
                            }
                            else
                            {
                                row["ControlValue"] = (control as CustomControl).SimpleValue;
                            }
                        }
                    }
                    else if (control is MTextBox)
                    {
                        row["ControlValue"] = string.IsNullOrEmpty((control as MTextBox).Data.ToString()) ? control.Text : (control as MTextBox).Data;
                    }
                    else if (control is MRichTextBox)
                    {
                        row["ControlValue"] = string.IsNullOrEmpty((control as MRichTextBox).Data.ToString()) ? control.Text : (control as MRichTextBox).Data;
                    }
                    TotalModelDT.Rows.Add(row);
                }
            }
            return TotalModelDT;
        }
        public void ApplyAllDocTemplate(DataTable TotalModelDT)
        {
            if (TotalModelDT != null)
            {
                foreach (Control control in this.ReportViewer.GetControls<Control>())
                {
                    if (control is MTextBox || control is MRichTextBox || control is CustomControl)
                    {
                        if (control is MTextBox)
                        {
                            if ((control as MTextBox).IsTotalModel == true)
                            {
                                DataRow[] rows = TotalModelDT.Select(string.Format("ControlName='{0}'", control.Name));
                                if (rows.Length > 0)
                                {
                                    if (!string.IsNullOrEmpty((control as MTextBox).CelerityInputTableName))
                                    {
                                        foreach (IUIElementHandler item in _UIElementHandlers)
                                        {
                                            if (item is TextBoxHandler)
                                            {
                                                if ((control as MTextBox).MultiSelect)
                                                {
                                                    (control as MTextBox).Data = rows[0]["ControlValue"].ToString();
                                                }
                                                else
                                                {
                                                    (control as MTextBox).Data = rows[0]["ControlValue"].ToString();
                                                    (control as MTextBox).Text = (item as TextBoxHandler).TransDictCode((control as MTextBox).DictTableName, (control as MTextBox).DictValueFieldName, (control as MTextBox).DisplayFieldName, (control as MTextBox).DictWhereString, (control as MTextBox).Data);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        (control as MTextBox).Text = rows[0]["ControlValue"].ToString();
                                    }
                                }
                            }
                        }
                        if (control is MRichTextBox)
                        {
                            if ((control as MRichTextBox).IsTotalModel == true)
                            {
                                DataRow[] rows = TotalModelDT.Select(string.Format("ControlName='{0}'", control.Name));
                                if (rows.Length > 0)
                                {
                                    if (!string.IsNullOrEmpty((control as MRichTextBox).CelerityInputTableName))
                                    {
                                        (control as MRichTextBox).Data = rows[0]["ControlValue"].ToString();
                                    }
                                    else
                                    {
                                        (control as MRichTextBox).Text = rows[0]["ControlValue"].ToString();
                                    }
                                }
                            }
                        }
                        if (control is CustomControl)
                        {
                            if ((control as CustomControl).IsTotalModel == true)
                            {
                                DataRow[] rows = TotalModelDT.Select(string.Format("ControlName='{0}'", control.Name));
                                if (rows.Length > 0)
                                {
                                    if ((control as CustomControl).MultiSelect)
                                    {
                                        (control as CustomControl).Value = rows[0]["ControlValue"].ToString();
                                    }
                                    else
                                    {
                                        (control as CustomControl).SimpleValue = rows[0]["ControlValue"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 应用整张文书的数据模版
        /// </summary>
        protected virtual void ApplyAllDocDataTemplate()
        {
        }


        //获取文书的属性设置
        public ReportViewProperties GetReportViewerProperties
        {
            get
            {
                foreach (Component component in this.MedReportView.Components)
                {
                    if (component is ReportViewProperties)
                    {
                        return component as ReportViewProperties;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        protected virtual void Print()
        {
            UIElementPrinter printer = new UIElementPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);

            printer.Print();
        }

        protected virtual void Print(bool bMultiPrint)
        {
            UIElementPrinter printer = new UIElementPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);

            printer.Print(bMultiPrint);
        }

        public virtual void CustomDraw(Graphics g)
        {
        }

        /// <summary>
        /// 获取分页设置
        /// </summary>
        public PagerSetting PagerSetting
        {
            get
            {
                return _pageSetting;
            }

        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        public Dictionary<string, DataTable> DataSource
        {
            get
            {
                return _dataSources;
            }
        }

        /// <summary>
        /// 医疗文书模版名称
        /// </summary>
        public string ReportName
        {
            get
            {
                return _reportName;
            }
        }

        #endregion

        public event EventHandler SaveTemplateClicked;
        public event EventHandler ApplyTemplateClicked;
        public event EventHandler SaveAllDataTemplateClicked;
        public event EventHandler ApplyAllDataTemplateClicked;
        /// <summary>
        /// 保存模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDataTemplate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (SaveTemplateClicked != null)
                    SaveTemplateClicked(this, EventArgs.Empty);
                else
                    this.SaveDocDataTemplate();
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

        /// <summary>
        /// 获取或者设置文书类型
        /// </summary>
        public DocKind DocKind
        {
            get
            {
                return _docKind;
            }
            set
            {
                _docKind = value;
            }

        }

        /// <summary>
        ///应用数据模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyDataTemplate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (ApplyTemplateClicked != null)
                    ApplyTemplateClicked(this, EventArgs.Empty);
                this.ApplyDocDataTemplate();
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

        /// <summary>
        /// 保存为整套模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAllDataTemplate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (SaveAllDataTemplateClicked != null)
                    SaveAllDataTemplateClicked(this, EventArgs.Empty);
                // this.SaveAllDocDataTemplate();
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


        /// <summary>
        /// 应用整套模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyAllDataTemplate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (ApplyAllDataTemplateClicked != null)
                    ApplyAllDataTemplateClicked(this, EventArgs.Empty);
                // this.ApplyAllDocDataTemplate();
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

        public void PreviousPageButton_Click(object sender, EventArgs e)
        {
            if (_pageSetting.CurrentPageIndex > 0 && _pageSetting.TotalPageCount > 0)
            {
                _pageSetting.CurrentPageIndex--;
                Cursor = Cursors.WaitCursor;
                try
                {
                    PageIndexChanged(_pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].PageIndex,
                             _pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].IsMain, _dataSources);
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

        public void NextPageButton_Click(object sender, EventArgs e)
        {
            if (_pageSetting.CurrentPageIndex < _pageSetting.TotalPageCount - 1 && _pageSetting.TotalPageCount > 0)
            {
                _pageSetting.CurrentPageIndex++;
                Cursor = Cursors.WaitCursor;
                try
                {
                    PageIndexChanged(_pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].PageIndex,
                             _pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].IsMain, _dataSources);
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

        private void LastPageButton_Click(object sender, EventArgs e)
        {
            if (_pageSetting.TotalPageCount > 0)
            {
                Cursor = Cursors.WaitCursor;
                _pageSetting.CurrentPageIndex = _pageSetting.TotalPageCount - 1;

                try
                {
                    PageIndexChanged(_pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].PageIndex,
                             _pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].IsMain, _dataSources);
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

        private void FirstPageButton_Click(object sender, EventArgs e)
        {
            if (_pageSetting.TotalPageCount > 0)
            {
                _pageSetting.CurrentPageIndex = 0;
                Cursor = Cursors.WaitCursor;
                try
                {
                    PageIndexChanged(_pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].PageIndex,
                             _pageSetting.PagerDesc[_pageSetting.CurrentPageIndex].IsMain, _dataSources);
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

        /// <summary>
        /// 双面打印
        /// </summary>
        public void DoublePrint_Click(object sender, EventArgs e)
        {
            string[] names = this.curDoublePrintName.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length == 2)
            {
                this.DoublePrintDoc(names[0], names[1]);
            }
        }

        /// <summary>
        /// 双面打印的具体实现
        /// </summary>
        protected virtual void DoublePrintDoc(string docName1, string docName2)
        {
        }

        /// <summary>
        /// 打印当前页
        /// </summary>
        public void PrintCurPage_Click(object sender, EventArgs e)
        {
            if (this.CheckBeforePrint())
            {
                this.PrintCurPage();
                this.OnAfterPrint();
            }
        }

        /// <summary>
        /// 打印当前页具体实现
        /// </summary>
        protected virtual void PrintCurPage()
        {

        }

        public void PrintButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {


                //OnDoSomeThing(sender, e);


                if (CheckBeforePrint())
                {
                    //Print 会触发 GridViewHandler Dirty
                    bool hasDirty = false;
                    IUIElementHandler gridViewHandler = null;
                    foreach (IUIElementHandler handler in _UIElementHandlers)
                    {
                        if (handler is GridViewHandler)
                        {
                            gridViewHandler = handler;
                            hasDirty = handler.HasDirty;
                            break;
                        }
                    }

                    this.Print();


                    OnAfterPrint();

                    //打印后触发事件
                    if (AfterPrint != null)
                    {
                        AfterPrint(this, new EventArgs());

                    }

                    if (gridViewHandler != null)
                    {
                        gridViewHandler.HasDirty = hasDirty;
                    }


                    this.RefreshData();
                }
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

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                this.RefreshData();
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

        public void SaveButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (!OnCustomCheckBeforeSave()) return;
                //this.Save();
                this.saveResult = this.Save(); // 保存成功时则关闭文书，保存失败则不关闭

                //此版本不存在打开文书时还可以在文书范围外录入数据的情况，故保存完之后不用重新刷新数据源
                //this.RefreshData();
            }
            catch (Exception)
            {
                // throw;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }
        public void Design_Click(object sender, EventArgs e)
        {
            DevDesignerShellForm designer = new DevDesignerShellForm(_reportName);
            designer.ShowDialog();
        }

        #region Hepler

        /// <summary>
        /// 刷新IUIElementHandler中的所有控件
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="timeSpan"></param>
        /// <param name="isMasterPage"></param>
        private void RefreshHandlerControls(IUIElementHandler handler, DateTimeRange timeSpan, bool isMasterPage, int attachPageMaxCount)
        {
            handler.PagerSetting.PageTimeSpan = timeSpan;
            handler.RefreshData();
            handler.HasDirty = false;
            if (handler.GetCurrentControl is AnesGraph)
            {
                if (isMasterPage)
                    handler.SetControlVisible(true);
                else
                    handler.SetControlVisible(false);
            }
            else if (handler.GetCurrentControl is MedAnesSheetDetails)
            {
                MedAnesSheetDetails anesSheetDetails = handler.GetCurrentControl as MedAnesSheetDetails;
                int totalCount = anesSheetDetails.TotalCount > 0 ? anesSheetDetails.TotalCount : attachPageMaxCount;
                if (isMasterPage)
                {
                    if (anesSheetDetails.Dock == DockStyle.Fill)
                    {
                        anesSheetDetails.Dock = _anesSheetDetailsDockStyle;
                    }
                    else
                    {
                        _anesSheetDetailsDockStyle = anesSheetDetails.Dock;
                    }
                    anesSheetDetails.StartIndex = 0;

                }
                else
                {
                    anesSheetDetails.Dock = DockStyle.Top;
                    anesSheetDetails.StartIndex = totalCount;
                }
                int cnt = 0;
                for (int i = 0; i < anesSheetDetails.Collections.Count; i++)
                {
                    if (anesSheetDetails.Collections[i] == null)
                        continue;
                    for (int j = 0; j < anesSheetDetails.Collections[i].Points.Count; j++)
                    {
                        if (anesSheetDetails.Collections[i].Points[j].StartTime >= timeSpan.StartDateTime && anesSheetDetails.Collections[i].Points[j].StartTime < timeSpan.StartDateTime.AddHours(_pageHours))
                        {
                            cnt++;
                            anesSheetDetails.Collections[i].Points[j].Index = cnt;//更新序号
                        }
                    }
                }
            }
            if (handler.GetCurrentControl is AnesBand)
            {
                (handler.GetCurrentControl as AnesBand).Invalidate();
            }


        }
        protected DateTimeRange GetGraphDateTime(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_ANESTHESIA_EVENT> anesthesiaEventDataTable, string eventNo, MED_OPERATION_MASTER masterTable)
        {
            DateTime startTime = DateTime.MinValue, endTime = DateTime.MinValue;
            bool result = false;
            if (vitalSignDataTable != null && vitalSignDataTable.Count > 0)
            {
                vitalSignDataTable = vitalSignDataTable.OrderBy(x => x.TIME_POINT).ToList();
                startTime = vitalSignDataTable[0].TIME_POINT;
                DateTime dt = vitalSignDataTable[vitalSignDataTable.Count - 1].TIME_POINT;
                if (startTime < dt)
                {
                    endTime = dt;
                }
                else
                {
                    endTime = startTime.AddMinutes(1);
                }
                result = true;
            }
            if (anesthesiaEventDataTable != null && anesthesiaEventDataTable.Count > 0)
            {
                anesthesiaEventDataTable = anesthesiaEventDataTable.OrderBy(x => x.START_TIME).ToList();
                if (!result || startTime > anesthesiaEventDataTable[0].START_TIME.Value)
                {
                    startTime = anesthesiaEventDataTable[0].START_TIME.Value;
                }
                anesthesiaEventDataTable.ForEach(row =>
                    {
                        if (row.START_TIME.HasValue && endTime == DateTime.MaxValue)
                        {
                            endTime = row.START_TIME.Value;
                        }
                        if (row.START_TIME.HasValue && row.START_TIME > endTime)
                        {
                            endTime = row.START_TIME.Value;
                        }
                        if (row.END_TIME.HasValue && row.END_TIME > endTime)
                        {
                            endTime = row.END_TIME.Value;
                        }
                    });
                result = true;
            }

            if (masterTable != null)
            {
                if (this.DocKind == DocKind.PACU) //
                {
                    if (masterTable.IN_PACU_DATE_TIME.HasValue)
                    {

                        DateTime dt = masterTable.IN_PACU_DATE_TIME.Value;
                        if (!result || (dt < startTime))
                        {
                            startTime = dt;
                        }
                        result = true;
                    }
                    if (masterTable.OUT_PACU_DATE_TIME.HasValue)
                    {

                        if (!result || (masterTable.OUT_PACU_DATE_TIME.Value > endTime || endTime == DateTime.MaxValue))
                        {
                            endTime = masterTable.OUT_PACU_DATE_TIME.Value;
                        }
                        result = true;
                    }

                }
                else
                {
                    if (masterTable.IN_DATE_TIME.HasValue)
                    {

                        ExtendAppContext.Current.AnesStartTime = masterTable.IN_DATE_TIME.Value;
                        if (!result || (ExtendAppContext.Current.AnesStartTime < startTime))
                        {
                            startTime = ExtendAppContext.Current.AnesStartTime;
                        }
                        if (!result || (masterTable.IN_DATE_TIME.Value > endTime))
                        {
                            endTime = masterTable.IN_DATE_TIME.Value;
                        }
                        result = true;
                    }
                    if (masterTable.END_DATE_TIME.HasValue)
                    {

                        if (!result || (masterTable.END_DATE_TIME.Value > endTime))
                        {
                            endTime = masterTable.END_DATE_TIME.Value;
                        }
                        result = true;
                    }
                    if (masterTable.ANES_END_TIME.HasValue)
                    {

                        if (!result || (masterTable.ANES_END_TIME.Value > endTime))
                        {
                            endTime = masterTable.ANES_END_TIME.Value;
                        }
                        result = true;
                    }
                    if (masterTable.OUT_DATE_TIME.HasValue)
                    {

                        if (!result || (masterTable.OUT_DATE_TIME.Value > endTime))
                        {
                            endTime = masterTable.OUT_DATE_TIME.Value;
                        }
                        result = true;
                    }

                }





            }
            if (result)
            {
                if (endTime == DateTime.MinValue)
                {
                    endTime = startTime.AddMinutes(1);
                }

            }
            else
            {
                startTime = DateTime.Parse("08:00");
                endTime = startTime.AddHours(_pageHours);
            }
            return new DateTimeRange(startTime, endTime);
        }

        protected void AdjustDateTimeRange(TimeScaleType timeScaleType, ref DateTimeRange dateTimeRange)
        {
            if (timeScaleType != TimeScaleType.None)
            {
                switch (timeScaleType)
                {
                    case TimeScaleType.OneMinute:
                        ModMinute(ref dateTimeRange.StartDateTime, 1);
                        break;
                    case TimeScaleType.FiveMinute:
                        ModMinute(ref dateTimeRange.StartDateTime, 5);
                        break;
                    case TimeScaleType.Quarter:
                        ModMinute(ref dateTimeRange.StartDateTime, 15);
                        break;
                    case TimeScaleType.HaveHour:
                        ModMinute(ref dateTimeRange.StartDateTime, 30);
                        break;
                }
            }
        }
        private void ModMinute(ref DateTime dateTime, int modNumber)
        {
            dateTime = dateTime.AddMinutes(-dateTime.Minute % modNumber);
        }
        #endregion

        private void BaseDoc_Resize(object sender, EventArgs e)
        {
            if (_autoCenter)
            {
                this.MedReportView.Left = (int)((Width - MedReportView.Width) / 2);
            }
            if (this.MedReportView.Left <= 0)
                this.MedReportView.Left = 0;
            //如果为竖屏
            if (Screen.PrimaryScreen.Bounds.Width < Screen.PrimaryScreen.Bounds.Height)
            {
                this.panelDoc.Padding = new Padding(50, 0, 0, 0);
            }
            this.panelDoc.Padding = new Padding(0, 0, 0, 0);
            this.MedReportView.Padding = new Padding(0, 0, 0, 0);
        }

        public Dictionary<string, DataTable> OriginalDataSources
        {
            get { return this.originalDataSources; }
        }

        public Color PaperBackColor
        {
            set
            {
                this.MedReportView.BackColor = value;
                this.panelDoc.BackColor = value;
                this.BackColor = value;
            }
        }

        /// <summary>
        /// 报表鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ReportViewMouseDown(object sender, MouseEventArgs e);
        /// <summary>
        /// 报表鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public event ReportViewMouseDown OnReportViewMouseDown;
        private void MedReportView_MouseDown(object sender, MouseEventArgs e)
        {
            if (OnReportViewMouseDown != null)
                OnReportViewMouseDown(sender, e);
        }

        //public ControlCollection GetControls()
        //{
        //    return this.MedReportView.Controls;
        //}

        public List<T> GetControls<T>() where T : Control
        {
            List<T> controls = new List<T>();
            GetControls<T>(this.MedReportView, controls);
            return controls;
        }
        private void GetControls<T>(Control parent, List<T> list) where T : Control
        {
            //if (parent.GetType().Equals(typeof(T)))
            if (parent is T)
            {
                list.Add((T)parent);
            }
            //else
            {
                foreach (Control control in parent.Controls)
                {
                    GetControls<T>(control, list);
                }
            }
        }

        // 转出PDF
        private void exportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.Filter = "PDF文档(*.pdf)|*.pdf";
                System.Windows.Forms.DialogResult dialogResult = saveFileDialog.ShowDialog();
                System.Windows.Forms.Application.DoEvents();
                if (dialogResult == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    ExportPDF(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }
        public bool ExportDocToWebJPG(string path, string docName)
        {
            List<Image> imageList = new List<Image>();
            UIElementPrinter printer = new UIElementPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            int index = PagerSetting.CurrentPageIndex;
            int mainCout = 0;
            int pageCount = _pageSetting.TotalPageCount < 1 ? 1 : _pageSetting.TotalPageCount;
            for (int i = 0; i < pageCount; i++)
            {
                if (i > 100) continue;
                if (i < PagerSetting.PagerDesc.Count)
                {
                    if (!PagerSetting.PagerDesc[i].IsMain) mainCout++;
                    if (mainCout > 0 && PagerSetting.PagerDesc[i].IsMain) PagerSetting.PagerDesc[i].PageIndex = PagerSetting.PagerDesc[i].PageIndex + mainCout;
                    if (!PagerSetting.PagerDesc[i].IsMain)
                    {
                        PageIndexChanged(PagerSetting.PagerDesc[i - 1].PageIndex, PagerSetting.PagerDesc[i].IsMain, DataSource);
                    }
                    else
                    {
                        PageIndexChanged(PagerSetting.PagerDesc[i].PageIndex, PagerSetting.PagerDesc[i].IsMain, DataSource);
                    }
                }
                //创建 metafile
                using (Metafile curPageFile = printer.GetPageMetafile())
                {
                    using (Bitmap img = new Bitmap(curPageFile.Width + 40, curPageFile.Height + 40))
                    {
                        using (Graphics g = Graphics.FromImage(img))
                        {
                            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, img.Width, img.Height));
                            g.DrawImage(curPageFile, 20, 20, curPageFile.Width, curPageFile.Height);
                            g.Dispose();
                        }
                        int doc = i + 1;
                        string pathName = path + "\\" + docName + "_" + doc + ".jpg";
                        img.Save(pathName);
                        imageList.Add(img);
                        curPageFile.Dispose();
                        img.Dispose();
                    }
                }
            }

            // 还原当前页
            if (index < PagerSetting.PagerDesc.Count)
                PageIndexChanged(PagerSetting.PagerDesc[index].PageIndex, PagerSetting.PagerDesc[index].IsMain, DataSource);


            return true;

        }
        // 导出PDF文件
        public List<Image> ExportJPG()
        {
            List<Image> imageList = new List<Image>();
            UIElementPrinter printer = new UIElementPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);
            int index = PagerSetting.CurrentPageIndex;
            int mainCout = 0;
            int pageCount = _pageSetting.TotalPageCount < 1 ? 1 : _pageSetting.TotalPageCount;
            for (int i = 0; i < pageCount; i++)
            {
                if (i > 100) continue;
                if (i < PagerSetting.PagerDesc.Count)
                {
                    if (!PagerSetting.PagerDesc[i].IsMain) mainCout++;
                    if (mainCout > 0 && PagerSetting.PagerDesc[i].IsMain) PagerSetting.PagerDesc[i].PageIndex = PagerSetting.PagerDesc[i].PageIndex + mainCout;
                    if (!PagerSetting.PagerDesc[i].IsMain)
                    {
                        PageIndexChanged(PagerSetting.PagerDesc[i - 1].PageIndex, PagerSetting.PagerDesc[i].IsMain, DataSource);
                    }
                    else
                    {
                        PageIndexChanged(PagerSetting.PagerDesc[i].PageIndex, PagerSetting.PagerDesc[i].IsMain, DataSource);
                    }

                }
                //创建 metafile
                using (Metafile curPageFile = printer.GetPageMetafile())
                {
                    using (Bitmap img = new Bitmap(curPageFile.Width + 40, curPageFile.Height + 40))
                    {
                        using (Graphics g = Graphics.FromImage(img))
                        {
                            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, img.Width, img.Height));
                            g.DrawImage(curPageFile, 20, 20, curPageFile.Width, curPageFile.Height);
                            g.Dispose();
                        }
                        img.Save(@"D:\\pdf\\img1.jpg");
                        imageList.Add(img);
                        curPageFile.Dispose();
                        img.Dispose();
                    }
                }
            }

            // 还原当前页
            if (index < PagerSetting.PagerDesc.Count)
                PageIndexChanged(PagerSetting.PagerDesc[index].PageIndex, PagerSetting.PagerDesc[index].IsMain, DataSource);


            return imageList;

        }
        // 导出PDF文件
        protected virtual void ExportPDF(string fileName)
        {
            string wmfFileName = fileName.Replace(".pdf", ".wmf");
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                PdfWriter writer = null;
                try
                {
                    using (iTextSharp.text.Document document = new iTextSharp.text.Document())
                    {
                        document.SetMargins(20f, 20f, 20f, 20f);

                        //这里不用释放，先于Document对象释放，会引起BUG。
                        writer = PdfWriter.GetInstance(document, fileStream);
                        {
                            document.Open();

                            UIElementPrinter printer = new UIElementPrinter(this, _paperSize, _pageFromHeight, _pagePrintHeight, _pageName);

                            int index = PagerSetting.CurrentPageIndex;
                            int pageCount = _pageSetting.TotalPageCount < 1 ? 1 : _pageSetting.TotalPageCount;
                            for (int i = 0; i < pageCount; i++)
                            {
                                if (i < PagerSetting.PagerDesc.Count)
                                    PageIndexChanged(PagerSetting.PagerDesc[i].PageIndex, PagerSetting.PagerDesc[i].IsMain, DataSource);

                                //创建 metafile
                                using (Metafile curPageFile = printer.GetPageMetafile())
                                {
                                    curPageFile.Save(wmfFileName);

                                    // 写入PDF
                                    iTextSharp.text.Rectangle docRect = new iTextSharp.text.Rectangle(curPageFile.Width, curPageFile.Height);
                                    document.SetPageSize(docRect);
                                    document.NewPage();
                                }
                                PdfContentByte cb = writer.DirectContent;
                                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(wmfFileName);
                                img.SetAbsolutePosition(0, 0);
                                cb.AddImage(img);
                                cb.Stroke();
                            }

                            // 还原当前页
                            if (index < PagerSetting.PagerDesc.Count)
                                PageIndexChanged(PagerSetting.PagerDesc[index].PageIndex, PagerSetting.PagerDesc[index].IsMain, DataSource);

                            if (File.Exists(wmfFileName))
                            {
                                File.Delete(wmfFileName);
                            }
                        }
                    }
                }
                finally
                {
                    if (writer != null)
                        writer.Dispose();
                    this.IsPrintEnd = true;// 打印完成，不会调用等待方法了
                }
            }
        }

        private void printCurrent_Click(object sender, EventArgs e)
        {
            bool bAllowPage = _pageSetting.AllowPage;
            Cursor = Cursors.WaitCursor;
            _pageSetting.AllowPage = false;
            try
            {
                if (CheckBeforePrint())
                {
                    //Print 会触发 GridViewHandler Dirty
                    bool hasDirty = false;
                    IUIElementHandler gridViewHandler = null;
                    foreach (IUIElementHandler handler in _UIElementHandlers)
                    {
                        if (handler is GridViewHandler)
                        {
                            gridViewHandler = handler;
                            hasDirty = handler.HasDirty;
                            break;
                        }
                    }

                    this.Print();


                    OnAfterPrint();

                    //打印后触发事件
                    if (AfterPrint != null)
                    {
                        AfterPrint(this, new EventArgs());

                    }

                    if (gridViewHandler != null)
                    {
                        gridViewHandler.HasDirty = hasDirty;
                    }


                    this.RefreshData();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                _pageSetting.AllowPage = bAllowPage;
            }
        }

        // 初始化
        public virtual void Initial()
        {
            // 判断双面打印按钮是否显示
            string[] names = ApplicationConfiguration.DoublePrintDocNames;
            if (null != names && names.Length > 0)
            {
                string name1 = this.Name + ",";
                string name2 = "," + this.Name;
                foreach (string item in names)
                {
                    if (item.Contains(name1) || item.Contains(name2))
                    {
                        this.pictureBoxDoublePrint.Visible = true;
                        this.curDoublePrintName = item;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 集中打印
        /// </summary>
        private void BtnMultiPrint_Click(object sender, EventArgs e)
        {
            MultiPrint();
        }
        protected virtual void MultiPrint()
        {
        }

        public bool PrintBaseDoc()
        {
            bool result = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                if (CheckBeforePrint())
                {
                    bool hasDirty = false;
                    IUIElementHandler gridViewHandler = null;
                    foreach (IUIElementHandler handler in _UIElementHandlers)
                    {
                        if (handler is GridViewHandler)
                        {
                            gridViewHandler = handler;
                            hasDirty = handler.HasDirty;
                            break;
                        }
                    }

                    Print(true);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return result;
        }

        public string CommitDocNoMess()
        {
            string ret = "";
            if (CheckBeforeCommit())
            {
                ret = CommitDoc2();
            }
            else
            {
                ret = "失败";
            }
            return ret;
        }

        protected virtual bool CheckBeforeCommit()
        {
            return true;
        }

        protected virtual string CommitDoc2()
        {
            return "";
        }

        private void btnRescue_Click(object sender, EventArgs e)
        {
            RescueMode();
        }

        protected virtual void RescueMode()
        {

        }

        private void MedReportView_Load(object sender, EventArgs e)
        {
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.配置1, Resources.配置2, Resources.配置2).AddMouseMove(DesignButton);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.缩放1, Resources.缩放2, Resources.缩放2).AddMouseMove(pictureBoxSuoFang);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.调用模版1, Resources.调用模版2, Resources.调用模版2).AddMouseMove(ApplyDataTemplate);

            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.保存模版1, Resources.保存模版2, Resources.保存模版2).AddMouseMove(SaveDataTemplate);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.保存1, Resources.保存2, Resources.保存2).AddMouseMove(SaveButton);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.归档1, Resources.归档2, Resources.归档2).AddMouseMove(button2);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.预览1, Resources.预览2, Resources.预览2).AddMouseMove(pictureBoxYuLan);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.打印1, Resources.打印2, Resources.打印2).AddMouseMove(PrintButton);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.集中打印1, Resources.集中打印2, Resources.集中打印2).AddMouseMove(btnMultiPrint);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.双面打印1, Resources.双面打印2, Resources.双面打印2).AddMouseMove(pictureBoxDoublePrint);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.打印当前页1, Resources.打印当前页2, Resources.打印当前页2).AddMouseMove(printCurPage);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.上页1, Resources.上页2, Resources.上页2).AddMouseMove(PreviousPageButton);
            new MedicalSystem.Anes.Document.Controls.ControlAddEvent(Resources.下页1, Resources.下页2, Resources.下页2).AddMouseMove(NextPageButton);

            DesignButton.Click += PictureBoxButton_Click;
            pictureBoxSuoFang.Click += PictureBoxButton_Click;
            ApplyDataTemplate.Click += PictureBoxButton_Click;
            SaveDataTemplate.Click += PictureBoxButton_Click;
            SaveButton.Click += PictureBoxButton_Click;
            button2.Click += PictureBoxButton_Click;
            pictureBoxYuLan.Click += PictureBoxButton_Click;
            PrintButton.Click += PictureBoxButton_Click;
            btnMultiPrint.Click += PictureBoxButton_Click;
            PreviousPageButton.Click += PictureBoxButton_Click;
            NextPageButton.Click += PictureBoxButton_Click;
            pictureBoxDoublePrint.Click += PictureBoxButton_Click;
            printCurPage.Click += PictureBoxButton_Click;
        }

        /// <summary>
        /// 文书归档无需提示框
        /// </summary>
        public virtual void SingPostPDFNoMsgbox()
        {
        }

        /// <summary>
        /// 归档：上传PDF文档
        /// </summary>
        public void PostPDFButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (CheckBeforeCommit())
                {
                    this.SingPostPDF();
                }
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

        public virtual void SingPostPDF()
        {

        }

        /// <summary>
        /// 文书菜单点击事件
        /// </summary>
        private void PictureBoxButton_Click(object sender, EventArgs e)
        {
            string senderName = ((PictureBox)sender).Tag.ToString();
            switch (senderName)
            {
                case "配置":
                    Design_Click(sender, e);
                    break;
                case "缩放":
                    break;
                case "调用模板":
                    ApplyDataTemplate_Click(sender, e);
                    break;
                case "保存模板":
                    SaveDataTemplate_Click(sender, e);
                    break;
                case "保存":
                    SaveButton_Click(sender, e);
                    break;
                case "归档":
                    PostPDFButton_Click(sender, e);
                    break;
                case "预览":
                    break;
                case "打印":
                    PrintButton_Click(sender, e);
                    break;
                case "集中打印":
                    this.BtnMultiPrint_Click(sender, e);
                    break;
                case "上页":
                    PreviousPageButton_Click(sender, e);
                    break;
                case "下页":
                    NextPageButton_Click(sender, e);
                    break;
                case "双面打印":
                    DoublePrint_Click(sender, e);
                    break;
                case "打印当前页":
                    PrintCurPage_Click(sender, e);
                    break;
                default:
                    break;
            }
        }
    }
}
