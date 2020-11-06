using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(false)]
    public partial class EditDict : BaseView
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();

        #region �����ʼ��

        /// <summary>
        /// MED_ANESTHESIA_INPUT_DICT
        /// </summary>
        private DataTable _inputDictData;
        /// <summary>
        /// MED_EVENT_DICT
        /// </summary>
        private DataTable _eventOpenDataTalbe;
        /// <summary>
        /// MED_ANESTHESIA_DICT
        /// </summary>
        private DataTable _dictDataTable;
        /// <summary>
        /// MED_EVENT_DICT
        /// </summary>
        private DataTable _eventOpenCommonDataTalbe;
        /// <summary>
        /// MED_DIAGNOSIS_DICT
        /// </summary>
        private DataTable _diagnosisDataTable;
        /// <summary>
        /// MED_HIS_USERS
        /// </summary>
        private DataTable _hisUserDataTable;
        /// <summary>
        /// MED_OPERATION_DICT
        /// </summary>
        private DataTable _operationDictTable;
        /// <summary>
        /// MED_DEPT_DICT
        /// </summary>
        private DataTable _deptDictDataTable;
        /// <summary>
        /// MED_MONITOR_DICT
        /// </summary>
        private DataTable _monitorTable;
        /// <summary>
        /// MED_OPERATING_ROOM
        /// </summary>
        private DataTable _operRoomTable;
        /// <summary>
        /// MED_RESCUE_EXPERTS
        /// </summary>
        private DataTable _rescueExpertsTable;
        /// <summary>
        /// MED_RESCUE_GROUP
        /// </summary>
        private DataTable _rescueGroupTable;
        /// <summary>
        /// MED_RESCUE_GROUP_VS_DEPT
        /// </summary>
        private DataTable _rescueGroupDeptTable;
        /// <summary>
        /// MED_RESCUE_EXPERTS_GROUP
        /// </summary>
        private DataTable _rescueExpertGroupTable;

        DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit deptDictLookUp;

        DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit userDictLookUp;

        DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit expertDictLookUp;

        DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit groupDictLookUp;

        List<MED_HIS_USERS> hisUsersList = null;
        List<MED_OPERATING_ROOM> operatingRoomList = null;
        private List<MED_MONITOR_FUNCTION_CODE> _monitorFunctionCode = null;
        private DataTable _monitorCodeTable;
        /// <summary>
        /// MED_PAT_MONITOR_DATA_DICT 
        /// </summary>
        private DataTable _monitorDataDictTable;
        /// <summary>
        /// MED_BLOOD_GAS_DICT
        /// </summary>
        private DataTable _bloodGasDictTable;
        //ָʾ��ǰ�Ƿ�������״̬
        bool _currentIsAdding = false;

        public EditDict()
        {
            InitializeComponent();
            Caption = ViewNames.EditDict;

        }
        private void EditDict_Load(object sender, EventArgs e)
        {
            InitalizationData();
            InitalizeTreeList();
            InitalizeComboBox();
            InitalDosageColumns();

        }

        private void InitalizeTreeList()
        {
            //��ʼ������������
            XmlDocument xmlDoc = new XmlDocument();

            if (System.IO.File.Exists(ExtendApplicationContext.Current.AppPath + "DictNormal.xml"))
            {
                xmlDoc.Load(ExtendApplicationContext.Current.AppPath + "DictNormal.xml");
            }
            treeListNormal.Nodes.Clear();

            //TreeListNode treeListNode = treeListNormal.AppendNode("root", -1);
            //treeListNode.SetValue(0, "��������");

            foreach (XmlNode xmlNode in xmlDoc.ChildNodes[0].ChildNodes)
            {
                AppendXtraTreeNode(xmlNode, null);
            }
            treeListNormal.Nodes[0].ExpandAll();
            treeListNormal_FocusedNodeChanged(this, new FocusedNodeChangedEventArgs(treeListNormal.FocusedNode, treeListNormal.FocusedNode));
            //��ʼ�������¼���
            EventTypeHelper.InitTree(treeListEventTypes);
            //��ʼ������������
            EventTypeHelper.InitTree(treeListEventType);
            //��ʼ���¼��ֵ���
            EventTypeHelper.InitalizeOtherTabTree(treeListOther);
            //��ʼ������ר������
            EventTypeHelper.InitalizeExpertTabTree(treeListExpert);
            //�Ƴ����õ�����TabPage
            //this.xtraTabControl1.TabPages.Remove(this.xtraTabPageCustomFields);
            this.xtraTabControl1.TabPages.Remove(this.tabPageSimple);
        }

        private void AppendXtraTreeNode(XmlNode xmlNode, TreeListNode node)
        {
            if (xmlNode is XmlComment) return;
            TreeListNode nd;
            if (node != null)
                nd = treeListNormal.AppendNode(xmlNode.Name, node);
            else
                nd = treeListNormal.AppendNode(xmlNode.Name, -1);

            nd.SetValue(0, xmlNode.Name);
            //if(!xmlNode.HasChildNodes)
            //   repositoryItemComboBox1.Items.Add(xmlNode.Name);
            if (xmlNode.ChildNodes.Count > 0)
            {
                foreach (XmlNode xmlnd in xmlNode.ChildNodes)
                {
                    AppendXtraTreeNode(xmlnd, nd);
                }
            }
        }
        /// <summary>
        /// �����ʼ��
        /// </summary>
        private void InitalizationData()
        {
            SetButtonState(false);
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += delegate (object sender, DoWorkEventArgs e)
                {
                    //��ȡ������������
                    _dictDataTable = ModelHelper<MED_ANESTHESIA_DICT>.ConvertListToDataTable(comnDictRepository.GetAnesMethodDictList().Data);
                    _operationDictTable = ModelHelper<MED_OPERATION_DICT>.ConvertListToDataTable(comnDictRepository.GetOperNameDictList().Data);
                    _diagnosisDataTable = ModelHelper<MED_DIAGNOSIS_DICT>.ConvertListToDataTable(comnDictRepository.GetDiagDictList().Data);
                    _monitorTable = ModelHelper<MED_MONITOR_DICT>.ConvertListToDataTable(comnDictRepository.GetMonitorDictList().Data);
                    _operRoomTable = ModelHelper<MED_OPERATING_ROOM>.ConvertListToDataTable(comnDictRepository.GetAllOperatingRoomList().Data);
                    if (ExtendApplicationContext.Current.CommDict.MonitorFuntionDict != null)
                    {
                        _monitorFunctionCode = ExtendApplicationContext.Current.CommDict.MonitorFuntionDict;
                    }
                    if (_monitorFunctionCode == null)
                    {
                        _monitorFunctionCode = comnDictRepository.GetMonitorFuctionCodeList().Data;
                    }
                    _monitorDataDictTable = ModelHelper<MED_PAT_MONITOR_DATA_DICT>.ConvertListToDataTable(comnDictRepository.GetPatMonitorDict().Data);
                    _bloodGasDictTable = ModelHelper<MED_BLOOD_GAS_DICT>.ConvertListToDataTable(comnDictRepository.GetBloodGasDictList().Data);
                    if (!_bloodGasDictTable.Columns.Contains("Selected")) _bloodGasDictTable.Columns.Add("Selected", typeof(bool));
                    foreach (DataRow row in _bloodGasDictTable.Rows)
                    {
                        if (row["BLG_STATUS"].Equals("0"))
                        {
                            row["Selected"] = false;
                        }
                        if (row["BLG_STATUS"].Equals("1"))
                        {
                            row["Selected"] = true;
                        }
                    }
                };
                worker.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
                {
                    gridControlMethod.DataSource = _dictDataTable;
                    gridControlEQ.DataSource = _monitorTable;
                    gridControlOperRoom.DataSource = _operRoomTable;
                    gridControlMonitor.DataSource = _monitorDataDictTable;
                    gridControlBloodGas.DataSource = _bloodGasDictTable;
                };
                worker.RunWorkerAsync();
            }
        }
        private void InitalizeComboBox()
        {
            List<MED_ANESTHESIA_INPUT_DICT> inputDict = comnDictRepository.GetAnesInputDictList("��ҩ��λ").Data;
            foreach (var row in inputDict)
            {
                this.repositoryItemComboBox2.Items.Add(row.ITEM_NAME);
                this.repositoryItemComboBox4.Items.Add(row.ITEM_NAME);
                this.repositoryItemComboBox5.Items.Add(row.ITEM_NAME);
                this.repositoryItemComboBox6.Items.Add(row.ITEM_NAME);
            }
            inputDict = comnDictRepository.GetAnesInputDictList("��ҩ;��").Data;
            foreach (var row in inputDict)
            {
                this.repositoryItemComboBox3.Items.Add(row.ITEM_NAME);
            }
            foreach (string str in ApplicationConfiguration.LiquidAttrs.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                this.repositoryItemComboBox7.Items.Add(str);
            }
            //ҽ������OPER_CLASS
            List<LookUpEditItem> data1 = new List<LookUpEditItem>();
            data1.Add(new LookUpEditItem("ҽ��", "1"));
            data1.Add(new LookUpEditItem("����", "2"));
            data1.Add(new LookUpEditItem("", "0"));
            repositoryItemLookUpEdit1.DataSource = data1;
            //�շ�REL_BILL
            List<LookUpEditItem> data2 = new List<LookUpEditItem>();
            data2.Add(new LookUpEditItem("����", 1M));
            data2.Add(new LookUpEditItem("����", 2M));
            data2.Add(new LookUpEditItem("����", 3M));
            data2.Add(new LookUpEditItem("", 0M));
            repositoryItemLookUpEdit2.DataSource = data2;
            //����/һ���� DURATIVE_INDICATOR
            List<LookUpEditItem> data3 = new List<LookUpEditItem>();
            data3.Add(new LookUpEditItem("��", 1M));
            data3.Add(new LookUpEditItem("��", 2M));
            repositoryItemLookUpEdit3.DataSource = data3;

            repositoryItemLookUpEdit4.DataSource = EventTypeHelper.GetItemList();
            repositoryItemLookUpEdit5.DataSource = repositoryItemLookUpEdit4.DataSource;

            List<LookUpEditItem> data5 = new List<LookUpEditItem>();
            data5.Add(new LookUpEditItem("��", 1));
            data5.Add(new LookUpEditItem("��", 0));
            repositoryItemLookUpEdit6.DataSource = data5;

            List<LookUpEditItem> monitCode = new List<LookUpEditItem>();
            _monitorFunctionCode = comnDictRepository.GetMonitorFuctionCodeList().Data;
            foreach (var row in _monitorFunctionCode)
            {
                monitCode.Add(new LookUpEditItem(row.ITEM_NAME, row.ITEM_CODE));
            }

            repositoryItemLookUpEdit7.DataSource = monitCode;

            deptDictLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            deptDictLookUp.DisplayMember = "DisplayText";
            deptDictLookUp.ValueMember = "ItemValue";
            deptDictLookUp.NullText = "";
            gridControlOther.RepositoryItems.Add(deptDictLookUp);
            List<LookUpEditItem> data4 = new List<LookUpEditItem>();
            var tmpList = comnDictRepository.GetDeptDictList().Data;
            _deptDictDataTable = ModelHelper<MED_DEPT_DICT>.ConvertListToDataTable(tmpList);
            foreach (var row in tmpList)
            {
                data4.Add(new LookUpEditItem(row.DEPT_NAME, row.DEPT_CODE));
            }
            deptDictLookUp.DataSource = data4;
            deptDictLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            userDictLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            userDictLookUp.DisplayMember = "DisplayText";
            userDictLookUp.ValueMember = "ItemValue";
            userDictLookUp.NullText = "";

            gridControlExpert.RepositoryItems.Add(userDictLookUp);
            List<LookUpEditItem> data6 = new List<LookUpEditItem>();
            var userList = comnDictRepository.GetHisUsersList().Data;
            hisUsersList = comnDictRepository.GetHisUsersList().Data;
            _hisUserDataTable = ModelHelper<MED_HIS_USERS>.ConvertListToDataTable(userList);
            foreach (var row in userList)
            {
                data6.Add(new LookUpEditItem(row.USER_NAME, row.USER_JOB_ID));
            }
            userDictLookUp.DataSource = data6;
            userDictLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            //expertDictLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            //expertDictLookUp.DisplayMember = "DisplayText";
            //expertDictLookUp.ValueMember = "ItemValue";
            //expertDictLookUp.NullText = "";
            //gridControlExpert.RepositoryItems.Add(expertDictLookUp);
            //List<LookUpEditItem> expert = new List<LookUpEditItem>();
            //var expertList = RescueService.GetExpertDetialList();
            //_rescueExpertsTable = ModelHelper<MED_RESCUE_EXPERTS>().FillDataTable(expertList);
            //foreach (var row in expertList)
            //{
            //    expert.Add(new LookUpEditItem(row.EXPERT_NAME, row.EXPERT_ID));
            //}
            //expertDictLookUp.DataSource = expert;
            //expertDictLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            //groupDictLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            //groupDictLookUp.DisplayMember = "DisplayText";
            //groupDictLookUp.ValueMember = "ItemValue";
            //groupDictLookUp.NullText = "";
            //gridControlExpert.RepositoryItems.Add(groupDictLookUp);
            //List<LookUpEditItem> group = new List<LookUpEditItem>();
            //var groupList = RescueService.GetRescueGourpList();
            //_rescueGroupTable = ModelHelper<MED_RESCUE_GROUP>().FillDataTable(groupList);
            //foreach (var row in groupList)
            //{
            //    group.Add(new LookUpEditItem(row.GROUP_ID, row.GROUP_NAME));
            //}
            //groupDictLookUp.DataSource = group;
            //groupDictLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        }

        /// <summary>
        /// �������ò��볣������
        /// </summary>
        private void InitalDosageColumns()
        {
            for (int i = 1; i <= ApplicationConfiguration.DosageButtonsCount; i++)
            {
                GenerateColumn(gridViewEventDosage, "������" + i.ToString(), "STANDARD_DOSAGE" + i.ToString());
            }
        }



        private GridColumn GenerateColumn(DevExpress.XtraGrid.Views.Grid.GridView gridView, string caption, string fieldName, int width)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = gridView.Columns.AddVisible(fieldName, caption);
            column.Width = width;
            return column;
        }

        private GridColumn GenerateColumn(DevExpress.XtraGrid.Views.Grid.GridView gridView, string caption, string fieldName)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = gridView.Columns.AddVisible(fieldName, caption);
            return column;
        }

        #endregion

        #region �˵�����
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListNormal_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                string category = e.Node.GetDisplayText(0);
                if (category == null || string.IsNullOrEmpty(category.Trim()))
                    return;
                SetButtonState(!e.Node.HasChildren);
                _inputDictData = ModelHelper<MED_ANESTHESIA_INPUT_DICT>.ConvertListToDataTable(comnDictRepository.GetAnesInputDictList(category).Data);

                // ���������
                //int index = 0;
                //foreach (var row in _inputDictData)
                //{
                //    row.SERIAL_NO = index;
                //    index++;
                //}

                this.gridControlKind.DataSource = _inputDictData;

                this.btnSave.Enabled = false;
                this.btnAdd.Enabled = e.Node.GetDisplayText(0) != "��������" && e.Node.GetDisplayText(0).Trim() != string.Empty;
                this.btnDel.Enabled = e.Node.GetDisplayText(0) != "��������" && e.Node.GetDisplayText(0).Trim() != string.Empty && this.gridViewKind.RowCount > 0;
            }
        }
        /// <summary>
        /// �����¼�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListEventTypes_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                if (!e.Node.GetDisplayText(0).Equals("����"))
                {
                    string category = e.Node.GetDisplayText(0);
                    if (!category.Equals("ȫ��"))
                    {
                        string eventType = EventTypeHelper.GetEventType(category);
                        category = EventTypeHelper.FindItemClass(category);

                        var tmpList = EventTypeHelper.RefreshEventOpenDataTalbe(category, eventType);

                        // ���������
                        if (string.IsNullOrEmpty(eventType))
                        {
                            int index = 0;
                            foreach (var row in tmpList)
                            {
                                row.SORT_NO = index;
                                index++;
                            }
                        }
                        _eventOpenDataTalbe = ModelHelper<MED_EVENT_DICT>.ConvertListToDataTable(tmpList);

                        gridControlEvent.DataSource = _eventOpenDataTalbe;
                        this.btnDel.Enabled = this.gridViewEvent.RowCount > 0;
                        this.btnSave.Enabled = false;
                        this.btnAdd.Enabled = true;
                    }
                    else
                    {
                        SetButtonState(false);
                    }

                }
                if (e.Node.GetDisplayText(0).Equals("����") || e.Node.GetDisplayText(0).Equals("��ҩ"))
                {
                    this.btnAdd.Enabled = false;
                }

            }

        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListEventType_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                if (!e.Node.GetDisplayText(0).Equals("����"))
                {
                    string category = EventTypeHelper.FindItemClass(e.Node.GetDisplayText(0));
                    string eventType = EventTypeHelper.GetEventType(e.Node.GetDisplayText(0));
                    _eventOpenCommonDataTalbe = new NewAnesthesiaEventRepository().RefreshEventDictExt(category, eventType, ApplicationConfiguration.DosageButtonsCount);
                    gridControlEventDosage.DataSource = _eventOpenCommonDataTalbe;
                    this.btnDel.Enabled = this.gridViewEventDosage.RowCount > 0;
                    this.btnSave.Enabled = false;
                    this.btnAdd.Enabled = true;
                    if (e.Node.GetDisplayText(0) == "ȫ��" || e.Node.GetDisplayText(0).Trim() == string.Empty)
                    {
                        SetButtonState(false);
                    }
                }
                if (e.Node.GetDisplayText(0).Equals("����") || e.Node.GetDisplayText(0).Equals("��ҩ"))
                {
                    this.btnAdd.Enabled = false;
                }
            }
        }

        private void treeListExpert_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.GetDisplayText(0).Equals("����ר��ά��"))
            {
                //_rescueExpertsTable = ModelHelper<MED_RESCUE_EXPERTS>().FillDataTable(RescueService.GetExpertDetialList());

                //gridControlExpert.DataSource = _rescueExpertsTable;
                ////ר��ID��ר�����ơ�ר�ҵȼ���ר��״̬��IP��ַ���绰��΢�źš���������
                //gridViewExpert.Columns.Clear();
                //GenerateColumn(gridViewExpert, "ר������", "EXPERT_ID");
                //GenerateColumn(gridViewExpert, "ר�ҵȼ�", "EXPERT_GRADE");
                //GenerateColumn(gridViewExpert, "IP��ַ", "IP_ADDR");
                //GenerateColumn(gridViewExpert, "�绰", "PHONE_NUMBER");
                //GenerateColumn(gridViewExpert, "΢�ź�", "WECHAT_NUMBR");
                //GenerateColumn(gridViewExpert, "��������", "DEPT_CODE");
                //gridViewExpert.Columns["EXPERT_ID"].ColumnEdit = userDictLookUp;
                //gridViewExpert.Columns["DEPT_CODE"].ColumnEdit = deptDictLookUp;
            }
            else if (e.Node.GetDisplayText(0).Equals("ר����ά��"))
            {
                //_rescueGroupTable = ModelHelper<MED_RESCUE_GROUP>().FillDataTable(RescueService.GetRescueGourpList());
                //gridControlExpert.DataSource = _rescueGroupTable;
                //gridViewExpert.Columns.Clear();
                //GenerateColumn(gridViewExpert, "ר����ID", "GROUP_ID");
                //GenerateColumn(gridViewExpert, "ר��������", "GROUP_NAME");
            }
            else if (e.Node.GetDisplayText(0).Equals("ר����ר����"))
            {
                //List<LookUpEditItem> data4 = new List<LookUpEditItem>();
                //var tmpList = RescueService.GetExpertDetialList();
                //_rescueExpertsTable = ModelHelper<MED_RESCUE_EXPERTS>().FillDataTable(tmpList);
                //foreach (var row in tmpList)
                //{
                //    data4.Add(new LookUpEditItem(row.EXPERT_NAME, row.EXPERT_ID));
                //}
                //expertDictLookUp.DataSource = data4;
                //expertDictLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

                //List<LookUpEditItem> data5 = new List<LookUpEditItem>();
                //var groupList = RescueService.GetRescueGourpList();
                //_rescueGroupTable = ModelHelper<MED_RESCUE_GROUP>().FillDataTable(groupList);
                //foreach (var row in groupList)
                //{
                //    data5.Add(new LookUpEditItem(row.GROUP_NAME, row.GROUP_ID));
                //}
                //groupDictLookUp.DataSource = data5;
                //groupDictLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

                //_rescueExpertGroupTable = ModelHelper<MED_RESCUE_EXPERTS_GROUP>().FillDataTable(RescueService.GetExpertList());
                //gridControlExpert.DataSource = _rescueExpertGroupTable;
                //gridViewExpert.Columns.Clear();
                //GenerateColumn(gridViewExpert, "ר����ID", "GROUP_ID");
                //GenerateColumn(gridViewExpert, "ר��ID", "EXPERT_ID");
                //gridViewExpert.Columns["GROUP_ID"].ColumnEdit = groupDictLookUp;
                //gridViewExpert.Columns["EXPERT_ID"].ColumnEdit = expertDictLookUp;
            }
            else if (e.Node.GetDisplayText(0).Equals("ר���������"))
            {
                //List<LookUpEditItem> data = new List<LookUpEditItem>();
                //var groupList = RescueService.GetRescueGourpList();
                //_rescueGroupTable = ModelHelper<MED_RESCUE_GROUP>().FillDataTable(groupList);
                //foreach (var row in groupList)
                //{
                //    data.Add(new LookUpEditItem(row.GROUP_NAME, row.GROUP_ID));
                //}
                //groupDictLookUp.DataSource = data;
                //groupDictLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

                //_rescueGroupDeptTable = ModelHelper<MED_RESCUE_GROUP_VS_DEPT>().FillDataTable(RescueService.GetRescueDeptList());
                //gridControlExpert.DataSource = _rescueGroupDeptTable;
                //gridViewExpert.Columns.Clear();
                //GenerateColumn(gridViewExpert, "ר����ID", "GROUP_ID");
                //GenerateColumn(gridViewExpert, "��Ӧ����", "DEPT_CODE");
                //gridViewExpert.Columns["GROUP_ID"].ColumnEdit = groupDictLookUp;
                //gridViewExpert.Columns["DEPT_CODE"].ColumnEdit = deptDictLookUp;
            }
            this.btnDel.Enabled = this.gridViewExpert.RowCount > 0;
            this.btnSave.Enabled = false;
            this.btnAdd.Enabled = true;
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListOther_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.GetDisplayText(0).Equals("����ֵ�"))
            {
                this.gridControlOther.DataSource = _diagnosisDataTable;
                gridViewOther.Columns.Clear();
                GenerateColumn(gridViewOther, "��ϴ���", "DIAGNOSIS_CODE", 100);
                GenerateColumn(gridViewOther, "�������", "DIAGNOSIS_NAME", 100);
                GenerateColumn(gridViewOther, "������־", "STD_INDICATOR", 100);
                GenerateColumn(gridViewOther, "��׼����־", "APPROVED_INDICATOR", 100);
                GenerateColumn(gridViewOther, "��������", "CREATE_DATE", 160);
                GenerateColumn(gridViewOther, "������", "INPUT_CODE", 100);
                gridViewOther.Columns["DIAGNOSIS_CODE"].OptionsColumn.AllowEdit = false;
            }
            else if (e.Node.GetDisplayText(0).Equals("ҽ���ֵ�") || e.Node.GetDisplayText(0).Equals("��ʿ�ֵ�"))
            {

                var tmpList = e.Node.GetDisplayText(0).Equals("ҽ���ֵ�") ? comnDictRepository.GetHisUsersListByUserJob("ҽ��").Data : comnDictRepository.GetHisUsersListByUserJob("��ʿ").Data;
                _hisUserDataTable = ModelHelper<MED_HIS_USERS>.ConvertListToDataTable(tmpList);
                gridControlOther.DataSource = _hisUserDataTable;

                gridViewOther.Columns.Clear();
                GenerateColumn(gridViewOther, "�û�ID", "USER_JOB_ID");
                GenerateColumn(gridViewOther, "����", "USER_NAME");
                GenerateColumn(gridViewOther, "����", "USER_DEPT");
                GenerateColumn(gridViewOther, "������", "INPUT_CODE");
                GenerateColumn(gridViewOther, "���", "USER_JOB");
                GenerateColumn(gridViewOther, "��������", "CREATE_DATE");
                gridViewOther.Columns["USER_JOB_ID"].OptionsColumn.AllowEdit = false;
                gridViewOther.Columns["USER_JOB_ID"].Visible = false;
                gridViewOther.Columns["USER_JOB"].OptionsColumn.AllowEdit = false;
                gridViewOther.Columns["USER_DEPT"].ColumnEdit = deptDictLookUp;
            }

            else if (e.Node.GetDisplayText(0).Equals("��������"))
            {
                gridControlOther.DataSource = _operationDictTable;
                gridViewOther.Columns.Clear();
                GenerateColumn(gridViewOther, "����", "OPER_NAME", 300);
            }
            this.btnDel.Enabled = this.gridViewOther.RowCount > 0;
            this.btnSave.Enabled = false;
            this.btnAdd.Enabled = true;
        }
        #endregion

        #region ���ݲ���
        //������������������
        private void AddgGidViewKindRow()
        {
            if (_inputDictData == null)
                return;
            var row = new MED_ANESTHESIA_INPUT_DICT();
            row.ITEM_CLASS = treeListNormal.Selection[0].GetDisplayText(0);
            row.ITEM_NAME = "";
            //decimal maxItemNo = -1;
            //foreach (var datarow in _inputDictData)
            //{
            //    if (!datarow.IsSERIAL_NONull() && maxItemNo < datarow.SERIAL_NO) maxItemNo = datarow.SERIAL_NO;
            //}
            //maxItemNo++;
            //row.SERIAL_NO = maxItemNo;
            var dt = ModelHelper<MED_ANESTHESIA_INPUT_DICT>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _inputDictData.ImportRow(item);
                }
            }
            gridViewKind.FocusedRowHandle = _inputDictData.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ����������������
        /// </summary>
        private void DeleteGridViewKindRow()
        {
            var row = gridViewKind.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    //CommDictService.SaveAnesInputDict(
                    //    _inputDictData.GetNewAndUpdateList<MED_ANESTHESIA_INPUT_DICT>(),
                    //    _inputDictData.GetDelList<MED_ANESTHESIA_INPUT_DICT>());

                    List<MED_ANESTHESIA_INPUT_DICT> _NewAndUpdateList = _inputDictData.GetNewAndUpdateList<MED_ANESTHESIA_INPUT_DICT>();
                    List<MED_ANESTHESIA_INPUT_DICT> _DelList = _inputDictData.GetDelList<MED_ANESTHESIA_INPUT_DICT>();

                    comnDictRepository.SaveAnesInputDict(new { _NewAndUpdateList, _DelList });

                    _inputDictData.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// ��������¼�������
        /// </summary>
        private void AddGridViewEventRow()
        {
            if (_eventOpenDataTalbe == null)
                return;
            var row = new MED_EVENT_DICT();
            row.EVENT_CLASS_CODE = EventTypeHelper.FindItemClass(treeListEventTypes.Selection[0].GetDisplayText(0));
            row.EVENT_ITEM_NAME = "";
            row.EVENT_ATTR2 = EventTypeHelper.GetEventType(treeListEventTypes.Selection[0].GetDisplayText(0));
            int maxItemNo = -1;
            int maxNo = -1;
            foreach (DataRow dr in _eventOpenDataTalbe.Rows)
            {
                if (!dr.IsNull("SORT_NO") && maxItemNo < Convert.ToInt32(dr["SORT_NO"]))
                    maxItemNo = Convert.ToInt32(dr["SORT_NO"]);
                if (Convert.ToInt32(dr["EVENT_ITEM_CODE"]) > maxNo) maxNo = Convert.ToInt32(dr["EVENT_ITEM_CODE"]);
            }
            maxItemNo++;
            maxNo++;
            row.SORT_NO = maxItemNo;
            row.EVENT_ITEM_CODE = maxNo.ToString();
            var dt = ModelHelper<MED_EVENT_DICT>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _eventOpenDataTalbe.ImportRow(item);
                }
            }
            gridViewEvent.FocusedRowHandle = _eventOpenDataTalbe.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ�������¼�������
        /// </summary>
        private void DeleteGridViewEventRow()
        {
            var row = gridViewEvent.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new NewAnesthesiaEventRepository().SaveEventDict(row["EVENT_CLASS_CODE"].ToString(), row["EVENT_ITEM_CODE"].ToString());
                    row.Delete();
                    //CommDictService.SaveEventDict(
                    //    _eventOpenDataTalbe.GetNewAndUpdateList<MED_EVENT_DICT>(),
                    //    _eventOpenDataTalbe.GetDelList<MED_EVENT_DICT>());
                    _eventOpenDataTalbe.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// ���������������
        /// </summary>
        private void AddGridViewMethodRow()
        {
            if (_dictDataTable == null)
                return;
            var row = new MED_ANESTHESIA_DICT();
            row.ANAESTHESIA_NAME = "";
            int serialNo = -1;
            int anesCode = 0;
            var tmp = ModelHelper<MED_ANESTHESIA_DICT>.ConvertDataTableToList(_dictDataTable);
            foreach (var dr in tmp)
            {
                if (dr.SORT_NO.HasValue && dr.SORT_NO.Value > serialNo)
                    serialNo = dr.SORT_NO.Value;
                if (Convert.ToInt32(dr.ANAESTHESIA_CODE) > anesCode)
                    anesCode = Convert.ToInt32(dr.ANAESTHESIA_CODE);
            }
            serialNo++;
            anesCode++;
            row.SORT_NO = serialNo;
            row.ANAESTHESIA_CODE = anesCode.ToString();
            var dt = ModelHelper<MED_ANESTHESIA_DICT>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _dictDataTable.ImportRow(item);
                }
            }
            gridViewMethod.FocusedRowHandle = _dictDataTable.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ��������������
        /// </summary>
        private void DeleteGridViewMethodRow()
        {
            var row = gridViewMethod.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    //CommDictService.SaveAnesDict(
                    //    _dictDataTable.GetNewAndUpdateList<MED_ANESTHESIA_DICT>(),
                    //    _dictDataTable.GetDelList<MED_ANESTHESIA_DICT>());

                    List<MED_ANESTHESIA_DICT> _NewAndUpdateList = _dictDataTable.GetNewAndUpdateList<MED_ANESTHESIA_DICT>();
                    List<MED_ANESTHESIA_DICT> _DelList = _dictDataTable.GetDelList<MED_ANESTHESIA_DICT>();

                    comnDictRepository.SaveAnesDict(new { _NewAndUpdateList, _DelList });

                    _dictDataTable.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// �����������������
        /// </summary>
        private void AddGridViewCommonRow()
        {
            if (_eventOpenCommonDataTalbe == null)
                return;
            var row = new MED_EVENT_DICT();
            row.EVENT_CLASS_CODE = EventTypeHelper.FindItemClass(treeListEventType.Selection[0].GetDisplayText(0));
            row.EVENT_ITEM_NAME = "";
            int maxItemNo = -1;
            int maxNo = -1;
            var data = EventTypeHelper.RefreshEventOpenDataTalbe(row.EVENT_CLASS_CODE, null);
            foreach (var datarow in data)
            {
                if (datarow.SORT_NO.HasValue && maxItemNo < datarow.SORT_NO)
                    maxItemNo = datarow.SORT_NO.Value;
                if (Convert.ToInt32(datarow.EVENT_ITEM_CODE) > maxNo) maxNo = Convert.ToInt32(datarow.EVENT_ITEM_CODE);
            }
            maxItemNo++;
            maxNo++;
            row.SORT_NO = maxItemNo;
            row.EVENT_ITEM_CODE = maxNo.ToString();

            var dt = ModelHelper<MED_EVENT_DICT>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                DataRow dr = _eventOpenCommonDataTalbe.NewRow();
                dr["EVENT_ITEM_CODE"] = row.EVENT_ITEM_CODE;
                dr["EVENT_CLASS_CODE"] = row.EVENT_CLASS_CODE;
                dr["EVENT_ITEM_NAME"] = row.EVENT_ITEM_NAME;
                dr["EVENT_ITEM_SPEC"] = row.EVENT_ITEM_SPEC;
                dr["DOSAGE_UNITS"] = row.DOSAGE_UNITS;
                _eventOpenCommonDataTalbe.Rows.Add(dr);
                //foreach (DataRow item in dt.Rows)
                //{

                //    _eventOpenCommonDataTalbe.ImportRow(item);
                //}
            }
            gridViewEventDosage.FocusedRowHandle = _eventOpenCommonDataTalbe.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ����������������
        /// </summary>
        /// <returns></returns>
        private void DeleteGridViewCommmonRow()
        {
            var row = gridViewEventDosage.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new NewAnesthesiaEventRepository().SaveEventDict(row["EVENT_CLASS_CODE"].ToString(), row["EVENT_ITEM_CODE"].ToString());
                    row.Delete();

                    //CommDictService.SaveEventDict(
                    //    _eventOpenCommonDataTalbe.GetNewAndUpdateList<MED_EVENT_DICT>(),
                    //    _eventOpenCommonDataTalbe.GetDelList<MED_EVENT_DICT>());
                    _eventOpenCommonDataTalbe.AcceptChanges();
                }
            }
        }

        /// <summary>
        /// �������ר���ֵ�������
        /// </summary>
        public void AddGridViewExpertRow1()
        {
            if (_rescueExpertsTable == null)
                return;
            var row = new MED_RESCUE_EXPERTS();
            row.EXPERT_ID = "";
            row.EXPERT_NAME = "";
            var dt = ModelHelper<MED_RESCUE_EXPERTS>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _rescueExpertsTable.ImportRow(item);
                }
            }

            gridViewExpert.FocusedRowHandle = _rescueExpertsTable.Rows.Count - 1;
        }
        /// <summary>
        /// ���ר�����ֵ�������
        /// </summary>
        public void AddGridViewExpertRow2()
        {
            if (_rescueGroupTable == null)
                return;
            var row = new MED_RESCUE_GROUP();
            row.GROUP_ID = "";
            row.GROUP_NAME = "";
            var dt = ModelHelper<MED_RESCUE_GROUP>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _rescueGroupTable.ImportRow(item);
                }
            }

            gridViewExpert.FocusedRowHandle = _rescueGroupTable.Rows.Count - 1;
        }
        /// <summary>
        /// ���ר����ר�����ֵ�������
        /// </summary>
        public void AddGridViewExpertRow3()
        {
            if (_rescueExpertGroupTable == null)
                return;
            var row = new MED_RESCUE_EXPERTS_GROUP();
            row.GROUP_ID = "";
            row.EXPERT_ID = "";
            var dt = ModelHelper<MED_RESCUE_EXPERTS_GROUP>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _rescueExpertGroupTable.ImportRow(item);
                }
            }

            gridViewExpert.FocusedRowHandle = _rescueExpertGroupTable.Rows.Count - 1;
        }
        /// <summary>
        /// ���ר����������ֵ�������
        /// </summary>
        public void AddGridViewExpertRow4()
        {
            if (_rescueGroupDeptTable == null)
                return;
            var row = new MED_RESCUE_GROUP_VS_DEPT();
            row.GROUP_ID = "";
            row.DEPT_CODE = "";
            var dt = ModelHelper<MED_RESCUE_GROUP_VS_DEPT>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _rescueGroupDeptTable.ImportRow(item);
                }
            }

            gridViewExpert.FocusedRowHandle = _rescueGroupDeptTable.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ������ר���ֵ�������
        /// </summary>
        private void DeleteGridViewExpertRow1()
        {
            //var row = gridViewExpert.GetFocusedDataRow();
            //if (row != null)
            //{
            //    if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {

            //        List<MED_RESCUE_EXPERTS_GROUP> groupList = RescueService.GetExpertList();
            //        if (groupList != null && groupList.Count > 0)
            //        {
            //            groupList = groupList.Where(p => p.EXPERT_ID == row["EXPERT_ID"].ToString()).ToList();
            //            if (groupList != null && groupList.Count > 0)
            //            {
            //                _rescueExpertGroupTable = ModelHelper<MED_RESCUE_EXPERTS_GROUP>().FillDataTable(groupList);
            //                for (int i = _rescueExpertGroupTable.Rows.Count - 1; i >= 0; i--)
            //                {
            //                    _rescueExpertGroupTable.Rows[i].Delete();
            //                }
            //                RescueService.SaveRescueGroupExpertsDict(_rescueExpertGroupTable.GetNewAndUpdateList<MED_RESCUE_EXPERTS_GROUP>(),
            //          _rescueExpertGroupTable.GetDelList<MED_RESCUE_EXPERTS_GROUP>());
            //            }
            //        }
            //        row.Delete();
            //        if (_rescueExpertsTable != null && _rescueExpertsTable.Rows.Count > 0)
            //        {
            //            foreach (DataRow dr in _rescueExpertsTable.Rows)
            //            {
            //                if (dr.RowState != DataRowState.Deleted)
            //                    dr["EXPERT_NAME"] = RefUserDT(dr["EXPERT_ID"].ToString());
            //            }
            //        }
            //        RescueService.SaveRescueExpertDict(_rescueExpertsTable.GetNewAndUpdateList<MED_RESCUE_EXPERTS>(), _rescueExpertsTable.GetDelList<MED_RESCUE_EXPERTS>());

            //        _rescueExpertsTable.AcceptChanges();
            //    }
            //}
        }
        /// <summary>
        /// ɾ��ר�����ֵ�������
        /// </summary>
        private void DeleteGridViewExpertRow2()
        {
            var row = gridViewExpert.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //List<MED_RESCUE_GROUP_VS_DEPT> groupList = RescueService.GetRescueDeptList();
                    //if (groupList != null && groupList.Count > 0)
                    //{
                    //    groupList = groupList.Where(p => p.GROUP_ID == row["GROUP_ID"].ToString()).ToList();
                    //    if (groupList != null && groupList.Count > 0)
                    //    {
                    //        _rescueGroupDeptTable = ModelHelper<MED_RESCUE_GROUP_VS_DEPT>().FillDataTable(groupList);
                    //        for (int i = _rescueGroupDeptTable.Rows.Count - 1; i >= 0; i--)
                    //        {
                    //            _rescueGroupDeptTable.Rows[i].Delete();
                    //        }
                    //        RescueService.SaveRescueGroupDeptDict(_rescueGroupDeptTable.GetNewAndUpdateList<MED_RESCUE_GROUP_VS_DEPT>(),
                    //  _rescueGroupDeptTable.GetDelList<MED_RESCUE_GROUP_VS_DEPT>());
                    //    }
                    //}
                    //row.Delete();
                    //RescueService.SaveRescueGroupDict(_rescueGroupTable.GetNewAndUpdateList<MED_RESCUE_GROUP>(),
                    //  _rescueGroupTable.GetDelList<MED_RESCUE_GROUP>());

                    //_rescueGroupTable.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// ɾ��ר����ר�����ֵ�������
        /// </summary>
        private void DeleteGridViewExpertRow3()
        {
            var row = gridViewExpert.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //row.Delete();
                    //RescueService.SaveRescueGroupExpertsDict(_rescueExpertGroupTable.GetNewAndUpdateList<MED_RESCUE_EXPERTS_GROUP>(),
                    //   _rescueExpertGroupTable.GetDelList<MED_RESCUE_EXPERTS_GROUP>());
                    //_rescueExpertGroupTable.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// ɾ��ר����������ֵ�������
        /// </summary> 
        private void DeleteGridViewExpertRow4()
        {
            var row = gridViewExpert.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //row.Delete();
                    //RescueService.SaveRescueGroupDeptDict(_rescueGroupDeptTable.GetNewAndUpdateList<MED_RESCUE_GROUP_VS_DEPT>(),
                    //    _rescueGroupDeptTable.GetDelList<MED_RESCUE_GROUP_VS_DEPT>());
                    //_rescueGroupDeptTable.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// ��������Ԥ��������
        /// </summary> 
        private void AddGridViewMonitorRow()
        {
            if (_monitorDataDictTable == null)
                return;
            var row = new MED_PAT_MONITOR_DATA_DICT();
            row.DB_DATA_NAME = "";
            row.MONITOR_DATA_NAME = "";
            row.PATIENT_ID = "0";
            row.VISIT_ID = 0;
            row.DEP_ID = 0;
            var dt = ModelHelper<MED_PAT_MONITOR_DATA_DICT>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _monitorDataDictTable.ImportRow(item);
                }
            }
            gridViewMonitor.FocusedRowHandle = _monitorDataDictTable.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ������Ԥ��������
        /// </summary>
        private void DeleteGridViewMonitorRow()
        {
            var row = gridViewMonitor.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    //CommDictService.SavePatMonitorDict(
                    //    _monitorDataDictTable.GetNewAndUpdateList<MED_PAT_MONITOR_DATA_DICT>(),
                    //    _monitorDataDictTable.GetDelList<MED_PAT_MONITOR_DATA_DICT>());

                    List<MED_PAT_MONITOR_DATA_DICT> _NewAndUpdateList = _monitorDataDictTable.GetNewAndUpdateList<MED_PAT_MONITOR_DATA_DICT>();
                    List<MED_PAT_MONITOR_DATA_DICT> _DelList = _monitorDataDictTable.GetDelList<MED_PAT_MONITOR_DATA_DICT>();

                    comnDictRepository.SavePatMonitorDict(new { _NewAndUpdateList, _DelList });

                    _monitorDataDictTable.AcceptChanges();
                }
            }
        }

        private void AddGridViewOtherRow1()
        {
            if (_diagnosisDataTable == null)
                return;
            var row = new MED_DIAGNOSIS_DICT();
            decimal serialNo = -1;
            var tmp = ModelHelper<MED_DIAGNOSIS_DICT>.ConvertDataTableToList(_diagnosisDataTable);
            foreach (var dr in tmp)
            {
                decimal code = 0;
                if (decimal.TryParse(dr.DIAGNOSIS_CODE, out code) && code > serialNo)
                {
                    serialNo = code;
                }
            }
            serialNo++;
            row.DIAGNOSIS_NAME = "";
            row.DIAGNOSIS_CODE = serialNo.ToString();
            var dt = ModelHelper<MED_DIAGNOSIS_DICT>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _diagnosisDataTable.ImportRow(item);
                }
            }
            gridViewOther.FocusedRowHandle = _diagnosisDataTable.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ������ֵ�������
        /// </summary>
        private void DeleteGridViewOtherRow1()
        {
            var row = gridViewOther.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    //CommDictService.SaveDiagDict(
                    //    _eventOpenDataTalbe.GetNewAndUpdateList<MED_DIAGNOSIS_DICT>(),
                    //    _eventOpenDataTalbe.GetDelList<MED_DIAGNOSIS_DICT>());

                    List<MED_DIAGNOSIS_DICT> _NewAndUpdateList = _eventOpenDataTalbe.GetNewAndUpdateList<MED_DIAGNOSIS_DICT>();
                    List<MED_DIAGNOSIS_DICT> _DelList = _eventOpenDataTalbe.GetDelList<MED_DIAGNOSIS_DICT>();

                    comnDictRepository.SaveDiagDict(new { _NewAndUpdateList, _DelList });

                    _eventOpenDataTalbe.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// ����û��ֵ�������
        /// </summary>
        private void AddGridViewOtherRow3()
        {
            if (_hisUserDataTable == null)
                return;
            var row = new MED_HIS_USERS();
            //decimal serialNo = -1;
            //foreach (Dict.HisUserRow dr in _hisUserDataTable)
            //{
            //    decimal code = 0;
            //    if (decimal.TryParse(dr.USER_ID, out code) && code > serialNo)
            //    {
            //        serialNo = code;
            //    }
            //}
            //serialNo++;
            //int max = DataHelper.GetMaxHisUserId()+1;
            //row.USER_ID = max.ToString();
            row.USER_JOB_ID = "";
            row.USER_JOB = treeListOther.Selection[0].GetDisplayText(0).Equals("ҽ���ֵ�") ? "ҽ��" : "��ʿ";
            row.USER_NAME = "";
            row.CREATE_DATE = DateTime.Today;
            var dt = ModelHelper<MED_HIS_USERS>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _hisUserDataTable.ImportRow(item);
                }
            }
            gridViewOther.FocusedRowHandle = _hisUserDataTable.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ���û��ֵ�������
        /// </summary>
        private void DeleteGridViewRow3()
        {
            var row = gridViewOther.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    //CommDictService.SaveHisUserDict(
                    //    _hisUserDataTable.GetNewAndUpdateList<MED_HIS_USERS>(),
                    //    _hisUserDataTable.GetDelList<MED_HIS_USERS>());

                    List<MED_HIS_USERS> _NewAndUpdateList = _hisUserDataTable.GetNewAndUpdateList<MED_HIS_USERS>();
                    List<MED_HIS_USERS> _DelList = _hisUserDataTable.GetDelList<MED_HIS_USERS>();

                    comnDictRepository.SaveHisUserDict(new { _NewAndUpdateList, _DelList });

                    _hisUserDataTable.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// �����������������
        /// </summary>
        private void AddGridViewOtherRow2()
        {
            if (_operationDictTable == null)
                return;
            var row = new MED_OPERATION_DICT();
            row.OPER_NAME = "";
            System.Random Random = new System.Random();
            row.OPER_CODE = (Random.Next(0, 9999)).ToString();
            var dt = ModelHelper<MED_OPERATION_DICT>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _operationDictTable.ImportRow(item);
                }
            }
            gridViewOther.FocusedRowHandle = _operationDictTable.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ����������������
        /// </summary>
        private void DeleteGridViewOtherRow2()
        {
            var row = gridViewOther.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    //CommDictService.SaveOperDict(
                    //    _operationDictTable.GetNewAndUpdateList<MED_OPERATION_DICT>(),
                    //    _operationDictTable.GetDelList<MED_OPERATION_DICT>());

                    List<MED_OPERATION_DICT> _NewAndUpdateList = _operationDictTable.GetNewAndUpdateList<MED_OPERATION_DICT>();
                    List<MED_OPERATION_DICT> _DelList = _operationDictTable.GetDelList<MED_OPERATION_DICT>();

                    comnDictRepository.SaveOperDict(new { _NewAndUpdateList, _DelList });

                    _operationDictTable.AcceptChanges();
                }
            }
        }

        /// <summary>
        /// ��Ӽ໤��������
        /// </summary>
        private void AddGridViewEQRow()
        {
            if (_monitorTable == null)
                return;
            var row = new MED_MONITOR_DICT();
            row.MONITOR_LABEL = "";
            var dt = ModelHelper<MED_MONITOR_DICT>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _monitorTable.ImportRow(item);
                }
            }
            gridViewEQ.FocusedRowHandle = _monitorTable.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ���໤��������
        /// </summary>
        private void DeleteGridViewEQRow()
        {
            var row = gridViewEQ.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    //CommDictService.SaveMoniDict(
                    //    _monitorTable.GetNewAndUpdateList<MED_MONITOR_DICT>(),
                    //    _monitorTable.GetDelList<MED_MONITOR_DICT>());

                    List<MED_MONITOR_DICT> _NewAndUpdateList = _monitorTable.GetNewAndUpdateList<MED_MONITOR_DICT>();
                    List<MED_MONITOR_DICT> _DelList = _monitorTable.GetDelList<MED_MONITOR_DICT>();

                    comnDictRepository.SaveMoniDict(new { _NewAndUpdateList, _DelList });

                    _monitorTable.AcceptChanges();
                }
            }
        }

        /// <summary>
        /// ���������������
        /// </summary>
        private void AddGridViewOperRoomRow()
        {
            if (_operRoomTable == null)
                return;
            var row = new MED_OPERATING_ROOM();
            row.ROOM_NO = "";
            row.DEPT_CODE = ExtendApplicationContext.Current.OperRoom;
            row.BED_TYPE = "0";
            var dt = ModelHelper<MED_OPERATING_ROOM>.ConvertSingleToDataTable(row);
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item.SetAdded();
                    _operRoomTable.ImportRow(item);
                }
            }
            gridViewOperRoom.FocusedRowHandle = _operRoomTable.Rows.Count - 1;
        }
        /// <summary>
        /// ɾ��������������
        /// </summary>
        private void DeleteGridViewOperRoomRow()
        {
            var row = gridViewOperRoom.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBoxFormPC.Show("�Ƿ�ɾ��������¼?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    //CommDictService.SaveOperRoom(
                    //    _operRoomTable.GetNewAndUpdateList<MED_OPERATING_ROOM>(),
                    //    _operRoomTable.GetDelList<MED_OPERATING_ROOM>());


                    List<MED_OPERATING_ROOM> _NewAndUpdateList = _operRoomTable.GetNewAndUpdateList<MED_OPERATING_ROOM>();
                    List<MED_OPERATING_ROOM> _DelList = _operRoomTable.GetDelList<MED_OPERATING_ROOM>();

                    comnDictRepository.SaveOperRoom(new { _NewAndUpdateList, _DelList });

                    _operRoomTable.AcceptChanges();
                }
            }
        }
        /// <summary>
        /// �༭,ɾ��,������Ϊ����
        /// </summary>
        /// <param name="editMode"></param>
        private void SetEditBehaviour(EditMode editMode)
        {
            //��������
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormal && this.treeListNormal.Selection != null)
            {
                if (editMode == EditMode.Add)
                {
                    AddgGidViewKindRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _inputDictData.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    //if(gridViewKind.ValidateEditor()) 
                    gridViewKind.CloseEditor();
                    //Application.DoEvents();
                    if (!gridViewKind.UpdateCurrentRow())
                        return;

                    List<MED_ANESTHESIA_INPUT_DICT> _NewAndUpdateList = _inputDictData.GetNewAndUpdateList<MED_ANESTHESIA_INPUT_DICT>();
                    List<MED_ANESTHESIA_INPUT_DICT> _DelList = _inputDictData.GetDelList<MED_ANESTHESIA_INPUT_DICT>();

                    comnDictRepository.SaveAnesInputDict(new { _NewAndUpdateList, _DelList });

                    string category = treeListNormal.Selection[0].GetDisplayText(0);
                    if (category.Equals("��ҩ;��"))
                    {
                        new NewAnesthesiaEventRepository().SaveAdministrationDict(category);
                    }
                    else if (category.Equals("Ũ�ȵ�λ") || category.Equals("�ٶȵ�λ") || category.Equals("��ҩ��λ"))
                    {
                        new NewAnesthesiaEventRepository().SaveUnitDict(category);
                    }

                    _inputDictData.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewKindRow();
                }
                gridControlKind.Enabled = true;
                this.btnDel.Enabled = this.gridViewKind.RowCount > 0;
            }
            //�����¼�
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesEvents && this.treeListEventTypes.Selection != null)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewEventRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _eventOpenDataTalbe.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewEvent.CloseEditor();
                    //Application.DoEvents();
                    if (!gridViewEvent.UpdateCurrentRow())
                        return;
                    gridViewEvent.Focus();


                    List<MED_EVENT_DICT> _NewAndUpdateList = _eventOpenDataTalbe.GetNewAndUpdateList<MED_EVENT_DICT>();
                    List<MED_EVENT_DICT> _DelList = _eventOpenDataTalbe.GetDelList<MED_EVENT_DICT>();

                    comnDictRepository.SaveEventDict(new { _NewAndUpdateList, _DelList });

                    _eventOpenDataTalbe.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewEventRow();
                }

                gridControlEvent.Enabled = true;
                this.btnDel.Enabled = this.gridViewEvent.RowCount > 0;
            }
            //������
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesMethod)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewMethodRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _dictDataTable.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewMethod.CloseEditor();
                    //Application.DoEvents();
                    if (!gridViewMethod.UpdateCurrentRow())
                        return;
                    gridViewMethod.Focus();


                    List<MED_ANESTHESIA_DICT> _NewAndUpdateList = _dictDataTable.GetNewAndUpdateList<MED_ANESTHESIA_DICT>();
                    List<MED_ANESTHESIA_DICT> _DelList = _dictDataTable.GetDelList<MED_ANESTHESIA_DICT>();

                    comnDictRepository.SaveAnesDict(new { _NewAndUpdateList, _DelList });
                    _dictDataTable.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewMethodRow();
                }
                gridControlMethod.Enabled = true;
                this.btnDel.Enabled = this.gridViewMethod.RowCount > 0;
            }
            //��������
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormalDosage && this.treeListEventType.Selection != null)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewCommonRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _eventOpenCommonDataTalbe.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewEventDosage.CloseEditor();
                    // Application.DoEvents();
                    if (!gridViewEventDosage.UpdateCurrentRow())
                        return;
                    gridViewEventDosage.Focus();
                    new NewAnesthesiaEventRepository().SaveEventExtDict(_eventOpenCommonDataTalbe, ApplicationConfiguration.DosageButtonsCount);
                    //CommDictService.SaveEventDict(
                    //    _eventOpenCommonDataTalbe.GetNewAndUpdateList<MED_EVENT_DICT>(),
                    //    _eventOpenCommonDataTalbe.GetDelList<MED_EVENT_DICT>());
                    _eventOpenCommonDataTalbe.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewCommmonRow();
                }
                gridControlEventDosage.Enabled = true;
                this.btnDel.Enabled = this.gridViewEventDosage.RowCount > 0;
            }
            //�໤��
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitorDict)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewEQRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _monitorTable.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewEQ.CloseEditor();
                    //Application.DoEvents();
                    if (!gridViewEQ.UpdateCurrentRow())
                        return;
                    gridViewEQ.Focus();

                    List<MED_MONITOR_DICT> _newAndUpdateList = _monitorTable.GetNewAndUpdateList<MED_MONITOR_DICT>();

                    List<MED_MONITOR_DICT> _delList = _monitorTable.GetDelList<MED_MONITOR_DICT>();

                    comnDictRepository.SaveMoniDict(new
                    {
                        _newAndUpdateList,
                        _delList
                    });

                    _monitorTable.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewEQRow();
                }
                gridControlEQ.Enabled = true;
                this.btnDel.Enabled = this.gridViewEQ.RowCount > 0;
            }
            //������
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOperRoom)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewOperRoomRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _operRoomTable.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewOperRoom.CloseEditor();
                    //Application.DoEvents();
                    if (!gridViewOperRoom.UpdateCurrentRow())
                        return;
                    gridViewOperRoom.Focus();

                    List<MED_OPERATING_ROOM> _NewAndUpdateList = _operRoomTable.GetNewAndUpdateList<MED_OPERATING_ROOM>();

                    List<MED_OPERATING_ROOM> _DelList = _operRoomTable.GetDelList<MED_OPERATING_ROOM>();

                    comnDictRepository.SaveOperRoom(new { _NewAndUpdateList, _DelList });


                    _operRoomTable.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewOperRoomRow();
                }
                gridControlOperRoom.Enabled = true;
                this.btnDel.Enabled = this.gridViewOperRoom.RowCount > 0;
            }
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageExpert && this.treeListExpert.Selection != null)
            {
                if (treeListExpert.Selection[0].GetDisplayText(0).Equals("����ר��ά��"))
                {
                    //if (editMode == EditMode.Add)
                    //{
                    //    AddGridViewExpertRow1();
                    //}
                    //else if (editMode == EditMode.Cancel)
                    //{
                    //    _rescueExpertsTable.RejectChanges();
                    //}
                    //else if (editMode == EditMode.Save)
                    //{
                    //    gridViewExpert.CloseEditor();
                    //    //Application.DoEvents();
                    //    if (!gridViewExpert.UpdateCurrentRow())
                    //        return;
                    //    gridViewExpert.Focus();
                    //    if (_rescueExpertsTable != null && _rescueExpertsTable.Rows.Count > 0)
                    //    {
                    //        foreach (DataRow dr in _rescueExpertsTable.Rows)
                    //        {
                    //            if (dr.RowState != DataRowState.Deleted)
                    //                dr["EXPERT_NAME"] = RefUserDT(dr["EXPERT_ID"].ToString());
                    //        }
                    //    }
                    //    RescueService.SaveRescueExpertDict(_rescueExpertsTable.GetNewAndUpdateList<MED_RESCUE_EXPERTS>(),
                    //    _rescueExpertsTable.GetDelList<MED_RESCUE_EXPERTS>());
                    //    _rescueExpertsTable.AcceptChanges();
                    //}
                    //else if (editMode == EditMode.Delete)
                    //{
                    //    DeleteGridViewExpertRow1();
                    //}
                }
                else if (treeListExpert.Selection[0].GetDisplayText(0).Equals("ר����ά��"))
                {
                    //if (editMode == EditMode.Add)
                    //{
                    //    AddGridViewExpertRow2();
                    //}
                    //else if (editMode == EditMode.Cancel)
                    //{
                    //    _rescueGroupTable.RejectChanges();
                    //}
                    //else if (editMode == EditMode.Save)
                    //{
                    //    gridViewExpert.CloseEditor();
                    //    // Application.DoEvents();
                    //    if (!gridViewExpert.UpdateCurrentRow())
                    //        return;
                    //    gridViewExpert.Focus();
                    //    RescueService.SaveRescueGroupDict(_rescueGroupTable.GetNewAndUpdateList<MED_RESCUE_GROUP>(),
                    //    _rescueGroupTable.GetDelList<MED_RESCUE_GROUP>());
                    //    _rescueGroupTable.AcceptChanges();
                    //}
                    //else if (editMode == EditMode.Delete)
                    //{
                    //    DeleteGridViewExpertRow2();
                    //}
                }
                else if (treeListExpert.Selection[0].GetDisplayText(0).Equals("ר����ר����"))
                {
                    //if (editMode == EditMode.Add)
                    //{
                    //    AddGridViewExpertRow3();
                    //}
                    //else if (editMode == EditMode.Cancel)
                    //{
                    //    _rescueExpertGroupTable.RejectChanges();
                    //}
                    //else if (editMode == EditMode.Save)
                    //{
                    //    gridViewExpert.CloseEditor();
                    //    //Application.DoEvents();
                    //    if (!gridViewExpert.UpdateCurrentRow())
                    //        return;
                    //    gridViewExpert.Focus();
                    //    RescueService.SaveRescueGroupExpertsDict(_rescueExpertGroupTable.GetNewAndUpdateList<MED_RESCUE_EXPERTS_GROUP>(),
                    //    _rescueExpertGroupTable.GetDelList<MED_RESCUE_EXPERTS_GROUP>());
                    //    _rescueExpertGroupTable.AcceptChanges();
                    //}
                    //else if (editMode == EditMode.Delete)
                    //{
                    //    DeleteGridViewExpertRow3();
                    //}
                }
                else if (treeListExpert.Selection[0].GetDisplayText(0).Equals("ר���������"))
                {
                    //if (editMode == EditMode.Add)
                    //{
                    //    AddGridViewExpertRow4();
                    //}
                    //else if (editMode == EditMode.Cancel)
                    //{
                    //    _rescueGroupDeptTable.RejectChanges();
                    //}
                    //else if (editMode == EditMode.Save)
                    //{
                    //    gridViewExpert.CloseEditor();
                    //    //Application.DoEvents();
                    //    if (!gridViewExpert.UpdateCurrentRow())
                    //        return;
                    //    gridViewExpert.Focus();
                    //    RescueService.SaveRescueGroupDeptDict(_rescueGroupDeptTable.GetNewAndUpdateList<MED_RESCUE_GROUP_VS_DEPT>(),
                    //    _rescueGroupDeptTable.GetDelList<MED_RESCUE_GROUP_VS_DEPT>());
                    //    _rescueGroupDeptTable.AcceptChanges();
                    //}
                    //else if (editMode == EditMode.Delete)
                    //{
                    //    DeleteGridViewExpertRow4();
                    //}
                }
                gridControlExpert.Enabled = true;
                this.btnDel.Enabled = this.gridViewExpert.RowCount > 0;
            }
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitor)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewMonitorRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _monitorDataDictTable.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewMonitor.CloseEditor();
                    //Application.DoEvents();
                    if (!gridViewMonitor.UpdateCurrentRow())
                        return;
                    gridViewMonitor.Focus();
                    if (_monitorDataDictTable != null && _monitorDataDictTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in _monitorDataDictTable.Rows)
                        {
                            if (dr.RowState != DataRowState.Deleted)
                                dr["MONITOR_DATA_NAME"] = RefMonitorDT(dr["DB_DATA_NAME"].ToString());
                        }
                    }

                    List<MED_PAT_MONITOR_DATA_DICT> _NewAndUpdateList = _monitorDataDictTable.GetNewAndUpdateList<MED_PAT_MONITOR_DATA_DICT>();

                    List<MED_PAT_MONITOR_DATA_DICT> _DelList = _monitorDataDictTable.GetDelList<MED_PAT_MONITOR_DATA_DICT>();

                    comnDictRepository.SavePatMonitorDict(new { _NewAndUpdateList, _DelList });


                    _monitorDataDictTable.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewMonitorRow();
                }

                gridControlMonitor.Enabled = true;
                this.btnDel.Enabled = this.gridViewMonitor.RowCount > 0;
            }
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageBloodGas)
            {
                if (editMode == EditMode.Cancel)
                {
                    _bloodGasDictTable.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    List<MED_BLOOD_GAS_DICT> table = comnDictRepository.GetBloodGasDictList().Data;

                    foreach (DataRow row in _bloodGasDictTable.Rows)
                    {
                        foreach (MED_BLOOD_GAS_DICT bloodGasRow in table)
                        {
                            if (bloodGasRow.BLG_CODE.Equals(row["BLG_CODE"]) && bloodGasRow.BLG_SHOWID.Equals(row["BLG_SHOWID"]))
                            {
                                bloodGasRow.BLG_NAME = row["BLG_NAME"].ToString();
                                bloodGasRow.BLG_STATUS = ((bool)row["Selected"]) ? "1" : "0";
                            }
                        }
                    }
                    //����Ѫ���ֵ��
                    comnDictRepository.SaveBloodGasDict(table);
                    _monitorDataDictTable.AcceptChanges();
                }

                gridControlBloodGas.Enabled = true;
                this.btnDel.Enabled = this.gridViewBloodGas.RowCount > 0;
            }
            //����
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOther && this.treeListOther.Selection != null)
            {
                if (treeListOther.Selection[0].GetDisplayText(0).Equals("����ֵ�"))
                {
                    if (editMode == EditMode.Add)
                    {
                        AddGridViewOtherRow1();
                    }
                    else if (editMode == EditMode.Cancel)
                    {
                        _diagnosisDataTable.RejectChanges();
                    }
                    else if (editMode == EditMode.Save)
                    {
                        gridViewOther.CloseEditor();
                        //Application.DoEvents();
                        if (!gridViewOther.UpdateCurrentRow())
                            return;
                        gridViewOther.Focus();

                        List<MED_DIAGNOSIS_DICT> _NewAndUpdateList = _diagnosisDataTable.GetNewAndUpdateList<MED_DIAGNOSIS_DICT>();

                        List<MED_DIAGNOSIS_DICT> _DelList = _diagnosisDataTable.GetDelList<MED_DIAGNOSIS_DICT>();

                        comnDictRepository.SaveDiagDict(new { _NewAndUpdateList, _DelList });

                        _diagnosisDataTable.AcceptChanges();
                    }
                    else if (editMode == EditMode.Delete)
                    {
                        DeleteGridViewOtherRow1();
                    }

                }
                else if (treeListOther.Selection[0].GetDisplayText(0).Equals("��������"))
                {
                    if (editMode == EditMode.Add)
                    {
                        AddGridViewOtherRow2();
                    }
                    else if (editMode == EditMode.Cancel)
                    {
                        _operationDictTable.RejectChanges();
                    }
                    else if (editMode == EditMode.Save)
                    {
                        gridViewOther.CloseEditor();
                        //Application.DoEvents();
                        if (!gridViewOther.UpdateCurrentRow())
                            return;
                        gridViewOther.Focus();

                        List<MED_OPERATION_DICT> _NewAndUpdateList = _operationDictTable.GetNewAndUpdateList<MED_OPERATION_DICT>();

                        List<MED_OPERATION_DICT> _DelList = _operationDictTable.GetDelList<MED_OPERATION_DICT>();

                        comnDictRepository.SaveOperDict(new
                        {
                            _NewAndUpdateList,
                            _DelList
                        });
                        _operationDictTable.AcceptChanges();
                    }
                    else if (editMode == EditMode.Delete)
                    {
                        DeleteGridViewOtherRow2();
                    }

                }
                else if (treeListOther.Selection[0].GetDisplayText(0).Equals("ҽ���ֵ�") || treeListOther.Selection[0].GetDisplayText(0).Equals("��ʿ�ֵ�"))
                {
                    if (editMode == EditMode.Add)
                    {
                        AddGridViewOtherRow3();
                    }
                    else if (editMode == EditMode.Cancel)
                    {
                        _hisUserDataTable.RejectChanges();
                    }
                    else if (editMode == EditMode.Save)
                    {
                        gridViewOther.CloseEditor();
                        //Application.DoEvents();
                        if (!gridViewOther.UpdateCurrentRow())
                            return;
                        gridViewOther.Focus();

                        List<MED_HIS_USERS> _newAndUpdateList = _hisUserDataTable.GetNewAndUpdateList<MED_HIS_USERS>();

                        List<MED_HIS_USERS> _delList = _hisUserDataTable.GetDelList<MED_HIS_USERS>();

                        comnDictRepository.SaveHisUserDict(new
                        {
                            _newAndUpdateList,
                            _delList
                        });
                        _hisUserDataTable.AcceptChanges();
                    }
                    else if (editMode == EditMode.Delete)
                    {
                        DeleteGridViewRow3();
                    }

                }
                gridControlOther.Enabled = true;
                this.btnDel.Enabled = this.gridViewOther.RowCount > 0;
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetEditControlState(false);
            SetEditBehaviour(EditMode.Add);
            this.btnSave.Enabled = false;
            this.btnAdd.Enabled = false;
            this.btnCancel.Enabled = true;
            this.btnRefresh.Enabled = false;
            this.btnDel.Enabled = false;
            _currentIsAdding = true;

        }
        /// <summary>
        /// ɾ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            SetEditBehaviour(EditMode.Delete);

        }
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentIsAdding && ValidateNewRow() == false)
                return;

            SetEditBehaviour(EditMode.Save);

            SetEditControlState(true);
            this.btnSave.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btnCancel.Enabled = false;
            this.btnRefresh.Enabled = true;
            _currentIsAdding = false;
        }


        /// <summary>
        /// ȡ���༭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBoxFormPC.Show("�Ƿ�ȡ�����β���?", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            SetEditControlState(true);

            SetEditBehaviour(EditMode.Cancel);

            this.btnSave.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btnCancel.Enabled = false;
            this.btnRefresh.Enabled = true;
            _currentIsAdding = false;
        }
        #endregion

        #region ���ÿؼ�״̬
        private void SetEditControlState(bool isEnabled)
        {
            SetTreeListState(isEnabled);

            this.gridControlKind.Enabled = isEnabled;
            this.gridControlEvent.Enabled = isEnabled;
            this.gridControlMethod.Enabled = isEnabled;
            this.gridControlEventDosage.Enabled = isEnabled;
            this.gridControlOther.Enabled = isEnabled;
            this.gridControlEQ.Enabled = isEnabled;
            this.gridControlOperRoom.Enabled = isEnabled;
            this.gridControlMonitor.Enabled = isEnabled;
            this.gridControlBloodGas.Enabled = isEnabled;
            this.gridControlExpert.Enabled = isEnabled;
        }
        private void SetTreeListState(bool isEnabled)
        {
            this.treeListEventTypes.Enabled = isEnabled;
            this.treeListNormal.Enabled = isEnabled;
            this.treeListEventType.Enabled = isEnabled;
            this.treeListOther.Enabled = isEnabled;
            this.treeListExpert.Enabled = isEnabled;
        }
        /// <summary>
        /// ���ð�Ŧ��״̬
        /// </summary>
        /// <param name="isEnabled"></param>
        private void SetButtonState(bool isEnabled)
        {
            this.btnAdd.Enabled = isEnabled;
            this.btnDel.Enabled = isEnabled;
            this.btnSave.Enabled = isEnabled;
            this.btnRefresh.Enabled = isEnabled;
        }
        private void gridViewKind_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!_currentIsAdding)
            {
                SetTreeListState(false);
                this.btnAdd.Enabled = false;
                this.btnCancel.Enabled = true;
                this.btnRefresh.Enabled = false;
                this.btnDel.Enabled = true;
                this.gridControlKind.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormal;
                this.gridControlEvent.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesEvents;
                this.gridControlMethod.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesMethod;
                this.gridControlEventDosage.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormalDosage;
                this.gridControlOther.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOther;
                this.gridControlEQ.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitorDict;
                this.gridControlOperRoom.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOperRoom;
                this.gridControlExpert.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageExpert;
                this.gridControlMonitor.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitor;
                this.gridControlBloodGas.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageBloodGas;
            }
            this.btnSave.Enabled = true;
        }
        private void gridViewKind_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //��������״̬ʱ,�����Խ�����ӵ�ǰ������ȥ
            e.Allow = !_currentIsAdding;

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //��������
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormal)
            {
                btnAdd.Visible = true;
                btnDel.Visible = true;
                labelControlTip.Visible = true;
                this.btnAdd.Enabled = this.treeListNormal.Selection != null && this.treeListNormal.Selection[0].GetDisplayText(0).Trim() != string.Empty && this.treeListNormal.Selection[0].GetDisplayText(0) != "��������";
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewKind.RowCount > 0 && this.treeListNormal.Selection[0].GetDisplayText(0).Trim() != string.Empty && this.treeListNormal.Selection[0].GetDisplayText(0) != "��������"; ;
            }
            //�����¼�
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesEvents)
            {
                btnAdd.Visible = true;
                btnDel.Visible = true;
                labelControlTip.Visible = true;
                this.btnAdd.Enabled = this.treeListEventTypes.Selection != null && this.treeListEventTypes.Selection[0].GetDisplayText(0) != "ȫ��" && this.treeListEventTypes.Selection[0].GetDisplayText(0).Trim() != string.Empty;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewEvent.RowCount > 0 && this.treeListEventTypes.Selection[0].GetDisplayText(0) != "ȫ��" && this.treeListEventTypes.Selection[0].GetDisplayText(0).Trim() != string.Empty; ; ;
            }
            //������
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesMethod)
            {
                btnAdd.Visible = true;
                btnDel.Visible = true;
                labelControlTip.Visible = true;
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewMethod.RowCount > 0;
            }
            //��������
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormalDosage)
            {
                btnAdd.Visible = true;
                btnDel.Visible = true;
                labelControlTip.Visible = false;
                this.btnAdd.Enabled = this.treeListEventType.Selection != null && this.treeListEventType.Selection[0].GetDisplayText(0) != "ȫ��" && this.treeListEventType.Selection[0].GetDisplayText(0).Trim() != string.Empty; ;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewEventDosage.RowCount > 0 && this.treeListEventType.Selection[0].GetDisplayText(0) != "ȫ��" && this.treeListEventType.Selection[0].GetDisplayText(0).Trim() != string.Empty; ;
            }
            //�໤��
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitorDict)
            {
                btnAdd.Visible = true;
                btnDel.Visible = true;
                labelControlTip.Visible = false;
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewEQ.RowCount > 0;
            }
            //������
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOperRoom)
            {
                btnAdd.Visible = true;
                btnDel.Visible = true;
                labelControlTip.Visible = false;
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewOperRoom.RowCount > 0;
            }
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageExpert)
            {
                btnAdd.Visible = true;
                btnDel.Visible = true;
                labelControlTip.Visible = false;
                if (treeListExpert.FocusedNode == treeListExpert.Nodes[0])
                    treeListExpert.FocusedNode = treeListExpert.Nodes[1];
            }
            //����
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOther)
            {
                labelControlTip.Visible = false;
                btnAdd.Visible = true;
                btnDel.Visible = true;
                if (treeListOther.FocusedNode == treeListOther.Nodes[0])
                    treeListOther.FocusedNode = treeListOther.Nodes[1];
            }
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitor)
            {
                btnAdd.Visible = true;
                btnDel.Visible = true;
                labelControlTip.Visible = false;
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewMonitor.RowCount > 0;
            }
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageBloodGas)
            {
                labelControlTip.Visible = false;
                btnAdd.Visible = false;
                btnDel.Visible = false;
                this.btnAdd.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewBloodGas.RowCount > 0;
            }
        }
        private void treeListNormal_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (e.Node.GetDisplayText(0) == "��������" || e.Node.GetDisplayText(0) == "ȫ��")
                e.CanFocus = false;
        }
        #endregion

        #region ����У��
        private void gridViewKind_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.gridViewKind.FocusedColumn.FieldName == "ITEM_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "���Ʋ���Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value.ToString().Length >= 500)
                    {
                        e.ErrorText = "���Ƴ��ȳ�����Χ,ӦС�ڵ���500���ַ�!";
                        e.Valid = false;
                        return;
                    }
                    if (_inputDictData != null)
                    {

                        int index = gridViewKind.GetDataSourceRowIndex(gridViewKind.FocusedRowHandle);

                        var tmpList = ModelHelper<MED_ANESTHESIA_INPUT_DICT>.ConvertDataTableToList(_inputDictData);
                        for (int i = 0; i < tmpList.Count; i++)
                        {
                            if (tmpList[i].ITEM_NAME.Trim() == e.Value.ToString().Trim() && i != index)
                            {
                                e.ErrorText = string.Format("�Ѵ�����ͬ������'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }

                    }
                }

            }
            else if (this.gridViewKind.FocusedColumn.FieldName == "ITEM_CLASS")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "���಻��Ϊ��!";
                    e.Valid = false;
                }

            }
            else if (this.gridViewKind.FocusedColumn.FieldName == "ITEM_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length >= 39)
                {
                    e.Valid = false;
                    e.ErrorText = "���볤�ȳ�����Χ,ӦС�ڵ���40���ַ�!";
                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;

        }



        private void gridViewExpert_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewExpert.FocusedColumn.FieldName == "PHONE_NUMBER")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "�绰����Ϊ��!";
                    e.Valid = false;
                }
            }
            else if (gridViewExpert.FocusedColumn.FieldName == "WECHAT_NUMBR")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "΢�ź��벻��Ϊ��!";
                    e.Valid = false;
                }
            }
            else if (gridViewExpert.FocusedColumn.FieldName == "IP_ADDR")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "IP��ַ����Ϊ��!";
                    e.Valid = false;
                }
            }
        }

        private void gridViewExpert_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridViewCoordination_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

        }
        private void gridViewEvent_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            DataRow row = gridViewEvent.GetDataRow(gridViewEvent.FocusedRowHandle);
            DataRow openrow = _eventOpenDataTalbe.Select("SORT_NO='" + row["SORT_NO"] + "' AND EVENT_CLASS_CODE='" + row["EVENT_CLASS_CODE"] + "'").FirstOrDefault();
            //.FindByITEM_NOITEM_CLASS((decimal)row["ITEM_NO"], row["ITEM_CLASS"].ToString());
            if (gridViewEvent.FocusedColumn.FieldName == "EVENT_ITEM_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "�¼����Ʋ���Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length >= 59)
                    {
                        e.Valid = false;
                        e.ErrorText = "�¼����Ƴ��ȳ�����Χ,ӦС�ڵ���60���ַ�!";
                        return;
                    }
                    if (_eventOpenDataTalbe != null)
                    {
                        int index = gridViewEvent.GetDataSourceRowIndex(gridViewEvent.FocusedRowHandle);

                        var tmpList = ModelHelper<MED_EVENT_DICT>.ConvertDataTableToList(_eventOpenDataTalbe);
                        for (int i = 0; i < tmpList.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tmpList[i].EVENT_ITEM_NAME))
                                continue;
                            if (tmpList[i].EVENT_ITEM_NAME.Trim() == e.Value.ToString().Trim() && i != index)
                            {
                                e.ErrorText = string.Format("�Ѵ�����ͬ���¼�����'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }
                    }
                }
            }

            //else if (gridViewEvent.FocusedColumn.FieldName == "DOSAGE_UNITS")
            //{
            //    if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
            //    {
            //        e.ErrorText = "������λ����Ϊ��!";
            //        e.Valid = false;
            //    }
            //}
            else if (gridViewEvent.FocusedColumn.FieldName == "ITEM_SPEC")
            {
                if (e.Value != null && e.Value.ToString().Length >= 20)
                {
                    e.Valid = false;
                    e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���20���ַ�!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "DOSAGE_UNITS")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���20���ַ�!";
                }
            }
            //else if (gridViewEvent.FocusedColumn.FieldName == "REL_BILL")
            //{
            //    if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
            //    {
            //        e.Value = null;
            //        openrow.SetREL_BILLNull();
            //    }
            //    else
            //    {
            //        if (e.Value != null && e.Value.ToString().Length > 1)
            //        {
            //            e.Valid = false;
            //            e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���1���ַ�!";
            //        }
            //    }
            //}
            else if (gridViewEvent.FocusedColumn.FieldName == "DOSAGE")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow["DOSAGE"] = DBNull.Value;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���8���ַ�!";
                    }
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "CONCENTRATION")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow["CONCENTRATION"] = DBNull.Value;// openrow.SetCONCENTRATIONNull();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���8���ַ�!";
                    }
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "CONCENTRATION_UNIT")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���20���ַ�!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "PERFORM_SPEED")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow["PERFORM_SPEED"] = DBNull.Value;// openrow.SetPERFORM_SPEEDNull();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���8���ַ�!";
                    }
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "SPEED_UNIT")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���20���ַ�!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "ADMINISTRATOR")
            {
                if (e.Value != null && e.Value.ToString().Length > 8)
                {
                    e.Valid = false;
                    e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���8���ַ�!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "DURATIVE_INDICATOR")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���1���ַ�!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "EVENT_ATTR")
            {
                if (e.Value != null && e.Value.ToString().Length > 10)
                {
                    e.Valid = false;
                    e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���10���ַ�!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "EVENT_ATTR2")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���20���ַ�!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "OPER_CLASS")
            {
                if (e.Value != null && e.Value.ToString().Length > 16)
                {
                    e.Valid = false;
                    e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���16���ַ�!";
                }
            }

            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;

        }


        private void gridViewMethod_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewMethod.FocusedColumn.FieldName == "ANAESTHESIA_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "���������Ʋ���Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length >= 39)
                    {
                        e.Valid = false;
                        e.ErrorText = "���������Ƴ��ȳ�����Χ,ӦС�ڵ���40���ַ�!";
                        return;
                    }

                    if (_dictDataTable != null)
                    {

                        int index = gridViewMethod.GetDataSourceRowIndex(gridViewMethod.FocusedRowHandle);

                        var tmpList = ModelHelper<MED_ANESTHESIA_DICT>.ConvertDataTableToList(_dictDataTable);
                        for (int i = 0; i < tmpList.Count; i++)
                        {
                            if (tmpList[i].ANAESTHESIA_NAME.Trim() == e.Value.ToString().Trim() && i != index)
                            {
                                e.ErrorText = string.Format("�Ѵ�����ͬ������'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }

                    }
                }
            }
            else if (gridViewMethod.FocusedColumn.FieldName == "INPUT_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length > 8)
                {
                    e.Valid = false;
                    e.ErrorText = "�����볤�ȳ�����Χ,ӦС�ڵ���8���ַ�!";

                }
            }
            else if (gridViewMethod.FocusedColumn.FieldName == "ANAESTHESIA_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length > 8)
                {
                    e.Valid = false;
                    e.ErrorText = "���볤�ȳ�����Χ,ӦС�ڵ���8���ַ�!";

                }
            }
            else if (gridViewMethod.FocusedColumn.FieldName == "ANAESTHESIA_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 15)
                {
                    e.Valid = false;
                    e.ErrorText = "���೤�ȳ�����Χ,ӦС�ڵ���16���ַ�!";

                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }

        private void gridViewEventDosage_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            DataRow row = gridViewEventDosage.GetDataRow(gridViewEventDosage.FocusedRowHandle);
            //DataRow openrow = _eventOpenDataTalbe.Select("SORT_NO='" + row["SORT_NO"] + "' AND EVENT_CLASS_CODE='" + row["EVENT_CLASS_CODE"] + "'").FirstOrDefault();
            //Dict.AnesthesiaEventOpenRow openrow = _eventOpenCommonDataTalbe.FindByITEM_NOITEM_CLASS((decimal)row["ITEM_NO"], row["ITEM_CLASS"].ToString());
            if (gridViewEventDosage.FocusedColumn.FieldName == "ITEM_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "�¼����Ʋ���Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length >= 59)
                    {
                        e.Valid = false;
                        e.ErrorText = "�¼����Ƴ��ȳ�����Χ,ӦС�ڵ���60���ַ�!";
                        return;
                    }
                    if (_eventOpenCommonDataTalbe != null)
                    {
                        int index = gridViewEventDosage.GetDataSourceRowIndex(gridViewEventDosage.FocusedRowHandle);

                        var tmpList = ModelHelper<MED_EVENT_DICT>.ConvertDataTableToList(_eventOpenCommonDataTalbe);
                        for (int i = 0; i < tmpList.Count; i++)
                        {
                            if (string.IsNullOrEmpty(tmpList[i].EVENT_ITEM_NAME))
                                continue;
                            if (tmpList[i].EVENT_ITEM_NAME.Trim() == e.Value.ToString().Trim() && i != index)
                            {
                                e.ErrorText = string.Format("�Ѵ�����ͬ���¼�����'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }
                    }
                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "ITEM_CLASS")
            {
                if (e.Value != null && e.Value.ToString().Length > 2)
                {
                    e.Valid = false;
                    e.ErrorText = "���೤�ȳ�����Χ,ӦС�ڵ���2���ַ�!";

                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "ITEM_SPEC")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "ҩƷ��񳤶ȳ�����Χ,ӦС�ڵ���20���ַ�!";

                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "DOSAGE_UNITS")
            {
                if (e.Value != null && e.Value.ToString().Length > 8)
                {
                    e.Valid = false;
                    e.ErrorText = "��λ���ȳ�����Χ,ӦС�ڵ���8���ַ�!";

                }
            }
            //else if (gridViewEventDosage.FocusedColumn.FieldName == "STANDARD_DOSAGE1")
            //{
            //    if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
            //    {
            //        e.Value = null;
            //        openrow[""] = DBNull.Value;// openrow.SetSTANDARD_DOSAGE1Null();
            //    }
            //    else
            //    {
            //        if (e.Value != null && e.Value.ToString().Length > 8)
            //        {
            //            e.Valid = false;
            //            e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���8���ַ�!";
            //        }
            //    }
            //}
            //else if (gridViewEventDosage.FocusedColumn.FieldName == "STANDARD_DOSAGE2")
            //{
            //    if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
            //    {
            //        e.Value = null;
            //        openrow.SetSTANDARD_DOSAGE2Null();
            //    }
            //    else
            //    {
            //        if (e.Value != null && e.Value.ToString().Length > 8)
            //        {
            //            e.Valid = false;
            //            e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���8���ַ�!";
            //        }
            //    }
            //}
            //else if (gridViewEventDosage.FocusedColumn.FieldName == "STANDARD_DOSAGE3")
            //{
            //    if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
            //    {
            //        e.Value = null;
            //        openrow.SetSTANDARD_DOSAGE3Null();
            //    }
            //    else
            //    {
            //        if (e.Value != null && e.Value.ToString().Length > 8)
            //        {
            //            e.Valid = false;
            //            e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���8���ַ�!";
            //        }
            //    }
            //}
            //else if (gridViewEventDosage.FocusedColumn.FieldName == "STANDARD_DOSAGE4")
            //{
            //    if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
            //    {
            //        e.Value = null;
            //        openrow.SetSTANDARD_DOSAGE4Null();
            //    }
            //    else
            //    {
            //        if (e.Value != null && e.Value.ToString().Length > 8)
            //        {
            //            e.Valid = false;
            //            e.ErrorText = "���ȳ�����Χ,ӦС�ڵ���8���ַ�!";
            //        }
            //    }
            //}
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }

        private void gridViewOther_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewOther.FocusedColumn.FieldName == "DIAGNOSIS_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "������Ʋ���Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value.ToString().Length >= 39)
                    {
                        e.Valid = false;
                        e.ErrorText = "������Ƴ��ȳ�����Χ,ӦС�ڵ���40���ַ�!";

                    }
                }
            }
            else if (gridViewOther.FocusedColumn.FieldName == "USER_ID")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "ID����Ϊ��!";
                    e.Valid = false;
                }

            }
            else if (gridViewOther.FocusedColumn.FieldName == "USER_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "���Ʋ���Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value.ToString().Length >= 29)
                    {
                        e.Valid = false;
                        e.ErrorText = "���Ƴ��ȳ�����Χ,ӦС�ڵ���30���ַ�!";

                    }
                }

            }
            else if (gridViewOther.FocusedColumn.FieldName == "USER_DEPT")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "���Ҳ���Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value.ToString().Length >= 16)
                    {
                        e.Valid = false;
                        e.ErrorText = "���ҳ��ȳ�����Χ,ӦС�ڵ���16���ַ�!";

                    }
                }
            }
            else if (gridViewOther.FocusedColumn.FieldName == "OPERATION_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "�������Ʋ���Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value.ToString().Length >= 60)
                    {
                        e.Valid = false;
                        e.ErrorText = "�������Ƴ��ȳ�����Χ,ӦС�ڵ���60���ַ�!";

                    }
                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }

        private void gridViewEQ_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewEQ.FocusedColumn.FieldName == "MONITOR_LABEL")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "�໤�Ǳ�ʶ����Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 10)
                    {
                        e.Valid = false;
                        e.ErrorText = "�໤�Ǳ�ʶ���ȳ�����Χ,ӦС�ڵ���10���ַ�!";
                        return;
                    }

                    if (_monitorTable != null)
                    {

                        int index = gridViewEQ.GetDataSourceRowIndex(gridViewEQ.FocusedRowHandle);
                        var tmpList = ModelHelper<MED_MONITOR_DICT>.ConvertDataTableToList(_monitorTable);
                        for (int i = 0; i < tmpList.Count; i++)
                        {
                            if (tmpList[i].MONITOR_LABEL.Trim() == e.Value.ToString().Trim() && i != index)
                            {
                                e.ErrorText = string.Format("�Ѵ�����ͬ������'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }

                    }
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "MANU_FIRM_NAME")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "���ҳ��ȳ�����Χ,ӦС�ڵ���20���ַ�!";

                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "MODEL")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "�ͺų��ȳ�����Χ,ӦС�ڵ���20���ַ�!";

                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "INTERFACE_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "�ӿ����ͳ�����Χ,Ӧ����1���ַ�!";

                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "IP_ADDR")
            {
                if (e.Value != null && e.Value.ToString().Length > 15)
                {
                    e.Valid = false;
                    e.ErrorText = "IP��ַ���ȳ�����Χ,ӦС�ڵ���15���ַ�!";

                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "COMM_PORT")
            {
                if (e.Value != null && e.Value.ToString().Length > 6)
                {
                    e.Valid = false;
                    e.ErrorText = "ͨѶ���ڳ��ȳ�����Χ,ӦС�ڵ���6���ַ�!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "DRIVER_PROG")
            {
                if (e.Value != null && e.Value.ToString().Length > 100)
                {
                    e.Valid = false;
                    e.ErrorText = "�ɼ����򳤶ȳ�����Χ,ӦС�ڵ���100���ַ�!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "ITEM_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "�������೤�ȳ�����Χ,Ӧ���ڸ��ַ�!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "CURRENT_RECV_ITEMS")
            {
                if (e.Value != null && e.Value.ToString().Length > 100)
                {
                    e.Valid = false;
                    e.ErrorText = "�ز���ȳ�����Χ,ӦС�ڵ���100���ַ�!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "WARD_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length > 8)
                {
                    e.Valid = false;
                    e.ErrorText = "���Ҵ��볤�ȳ�����Χ,ӦС�ڵ���8���ַ�!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "WARD_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "�������ͳ��ȳ�����Χ,ӦС�ڵ���1���ַ�!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "BED_NO")
            {
                if (e.Value != null && e.Value.ToString().Length > 10)
                {
                    e.Valid = false;
                    e.ErrorText = "����(������)���ȳ�����Χ,ӦС�ڵ���10���ַ�!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "PC_PORT")
            {
                if (e.Value != null && e.Value.ToString().Length > 5)
                {
                    e.Valid = false;
                    e.ErrorText = "PC�˿ڳ��ȳ�����Χ,ӦС�ڵ���5���ַ�!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "DATALOG_STATUS")
            {
                if (e.Value != null && e.Value.ToString().Length > 4)
                {
                    e.Valid = false;
                    e.ErrorText = "״̬���ȳ�����Χ,ӦС�ڵ���4���ַ�!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "MEMO")
            {
                if (e.Value != null && e.Value.ToString().Length > 50)
                {
                    e.Valid = false;
                    e.ErrorText = "��ע���ȳ�����Χ,ӦС�ڵ���50���ַ�!";
                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }


        private void gridViewMonitor_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewMonitor.FocusedColumn.FieldName == "DB_DATA_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "�������Ʋ���Ϊ��!";
                    e.Valid = false;
                }
            }
        }
        private void gridViewOperRoom_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewOperRoom.FocusedColumn.FieldName == "ROOM_NO")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "������Ų���Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 4)
                    {
                        e.Valid = false;
                        e.ErrorText = "������ų��ȳ�����Χ,ӦС�ڵ���4���ַ�!";
                        return;
                    }

                    if (_operRoomTable != null)
                    {

                        int index = gridViewOperRoom.GetDataSourceRowIndex(gridViewOperRoom.FocusedRowHandle);
                        var tmpList = ModelHelper<MED_OPERATING_ROOM>.ConvertDataTableToList(_operRoomTable);
                        for (int i = 0; i < tmpList.Count; i++)
                        {
                            if (tmpList[i].ROOM_NO.Trim() == e.Value.ToString().Trim() && tmpList[i].DEPT_CODE.Trim() == tmpList[index].DEPT_CODE.Trim() && i != index)
                            {
                                e.ErrorText = string.Format("ͬһ�����Ѵ�����ͬ�������'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }

                    }
                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "DEPT_CODE")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "���Ҵ��벻��Ϊ��!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "���Ҵ��볤�ȳ�����Χ,ӦС�ڵ���8���ַ�!";
                        return;
                    }

                    if (_operRoomTable != null)
                    {

                        int index = gridViewOperRoom.GetDataSourceRowIndex(gridViewOperRoom.FocusedRowHandle);
                        var tmpList = ModelHelper<MED_OPERATING_ROOM>.ConvertDataTableToList(_operRoomTable);
                        for (int i = 0; i < tmpList.Count; i++)
                        {
                            if (tmpList[i].DEPT_CODE.Trim() == e.Value.ToString().Trim() && tmpList[i].ROOM_NO.Trim() == tmpList[index].ROOM_NO.Trim() && i != index)
                            {

                                e.ErrorText = string.Format("ͬһ�����Ѵ�����ͬ�������'{0}'!", tmpList[index].ROOM_NO);
                                e.Valid = false;
                                break;
                            }
                        }

                    }
                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "LOCATION")
            {
                if (e.Value != null && e.Value.ToString().Length > 10)
                {
                    e.Valid = false;
                    e.ErrorText = "λ�ó��ȳ�����Χ,ӦС�ڵ���10���ַ�!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "STATUS")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "״̬���ȳ�����Χ,Ӧ����1���ַ�!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "BED_ID")
            {
                if (e.Value != null && e.Value.ToString().Length > 4)
                {
                    e.Valid = false;
                    e.ErrorText = "���ų��ȳ�����Χ,ӦС�ڵ���4���ַ�!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "BED_LABEL")
            {
                if (e.Value != null && e.Value.ToString().Length > 12)
                {
                    e.Valid = false;
                    e.ErrorText = "��λ��ų��ȳ�����Χ,ӦС�ڵ���12���ַ�!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "MONITOR_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length > 5)
                {
                    e.Valid = false;
                    e.ErrorText = "�໤�Ǵ��볤�ȳ�����Χ,ӦС�ڵ���5���ַ�!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "BED_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "���������ͳ��ȳ�����Χ,Ӧ����1���ַ�!";

                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }
        private string RefUserDT(string userID)
        {
            foreach (MED_HIS_USERS user in hisUsersList)
            {
                if (user.USER_JOB_ID == userID)
                {
                    userID = user.USER_NAME;
                    break;
                }
            }
            return userID;
        }
        private string RefMonitorDT(string code)
        {
            foreach (MED_MONITOR_FUNCTION_CODE monitorCode in _monitorFunctionCode)
            {
                if (monitorCode.ITEM_CODE == code)
                {
                    code = monitorCode.ITEM_NAME;
                }
            }
            return code;
        }
        private string RefRoomDT(string roomNo)
        {
            foreach (MED_OPERATING_ROOM room in operatingRoomList)
            {
                if (room.ROOM_NO == roomNo)
                {
                    roomNo = room.BED_LABEL;
                    break;
                }
            }
            return roomNo;
        }
        /// <summary>
        /// ��֤����ӵ�������
        /// </summary>
        /// <returns></returns>
        private bool ValidateNewRow()
        {
            //��������
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormal)
            {
                var row = this.gridViewKind.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["ITEM_NAME"] == null || string.IsNullOrEmpty(row["ITEM_NAME"].ToString().Trim()))
                {
                    MessageBoxFormPC.Show("����������!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


            }
            //�����¼�
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesEvents)
            {
                var row = this.gridViewEvent.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["EVENT_ITEM_NAME"] == null || string.IsNullOrEmpty(row["EVENT_ITEM_NAME"].ToString().Trim()))
                {
                    MessageBoxFormPC.Show("�������¼�����!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //if (row["DOSAGE_UNITS"] == null || string.IsNullOrEmpty(row["DOSAGE_UNITS"].ToString().Trim()))
                //{
                //    MessageBoxFormPC.Show("�����������λ!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}


            }
            //������
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesMethod)
            {
                var row = this.gridViewMethod.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["ANAESTHESIA_NAME"] == null || string.IsNullOrEmpty(row["ANAESTHESIA_NAME"].ToString().Trim()))
                {
                    MessageBoxFormPC.Show("����������������!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //��������
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormalDosage)
            {
                var row = this.gridViewEventDosage.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["EVENT_ITEM_NAME"] == null || string.IsNullOrEmpty(row["EVENT_ITEM_NAME"].ToString().Trim()))
                {
                    MessageBoxFormPC.Show("�������¼�����!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //�໤��
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitorDict)
            {
                var row = this.gridViewEQ.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["MONITOR_LABEL"] == null || string.IsNullOrEmpty(row["MONITOR_LABEL"].ToString().Trim()))
                {
                    MessageBoxFormPC.Show("������໤�Ǳ�ʶ!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //������
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOperRoom)
            {
                var row = this.gridViewOperRoom.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["ROOM_NO"] == null || string.IsNullOrEmpty(row["ROOM_NO"].ToString().Trim()))
                {
                    MessageBoxFormPC.Show("�������������!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (row["DEPT_CODE"] == null || string.IsNullOrEmpty(row["DEPT_CODE"].ToString().Trim()))
                {
                    MessageBoxFormPC.Show("��������������Ҵ���!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //����
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOther)
            {
                var row = this.gridViewOther.GetFocusedDataRow();
                if (row == null)
                    return false;
                if (row.Table.Columns.Contains("DIAGNOSIS_NAME"))
                {
                    if (row["DIAGNOSIS_NAME"] == null || string.IsNullOrEmpty(row["DIAGNOSIS_NAME"].ToString().Trim()))
                    {
                        MessageBoxFormPC.Show("�������������!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (row.Table.Columns.Contains("USER_NAME"))
                {
                    if (row["USER_NAME"] == null || string.IsNullOrEmpty(row["USER_NAME"].ToString().Trim()))
                    {
                        MessageBoxFormPC.Show("����������!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (row.Table.Columns.Contains("USER_ID"))
                {
                    string userName = row["USER_NAME"].ToString().Trim().Length > 7 ? row["USER_NAME"].ToString().Trim().Remove(7) : row["USER_NAME"].ToString().Trim();
                    //string filterString = "USER_ID LIKE'" + userName + "%'";
                    var data = comnDictRepository.GetHisUsersList().Data.Where(x => x.USER_JOB_ID.Contains(userName)).ToList();
                    if (data != null && data.Count > 0)
                    {
                        row["USER_ID"] = userName + data.Count.ToString();
                    }
                    else
                    {
                        row["USER_ID"] = userName;
                    }
                }
                if (row.Table.Columns.Contains("USER_DEPT"))
                {
                    if (row["USER_DEPT"] == null || string.IsNullOrEmpty(row["USER_DEPT"].ToString().Trim()))
                    {
                        MessageBoxFormPC.Show("���������!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (row.Table.Columns.Contains("OPERATION_NAME"))
                {
                    if (row["OPERATION_NAME"] == null || string.IsNullOrEmpty(row["OPERATION_NAME"].ToString().Trim()))
                    {
                        MessageBoxFormPC.Show("��������������!", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;

        }
        #endregion
        private void gridViewKind_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40 && e.Alt)
                {
                    int rowHandler = gridViewKind.FocusedRowHandle;
                    if (rowHandler < gridViewKind.RowCount - 1)
                    {
                        DataRow rowcurrent = gridViewKind.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewKind.GetDataRow(rowHandler + 1);
                        foreach (DataColumn column in rowcurrent.Table.Columns)
                        {
                            object obj = rowcurrent[column];
                            rowcurrent[column] = rowNext[column];
                            rowNext[column] = obj;
                        }
                        btnSave.Enabled = true;
                    }
                }
                else if (e.KeyValue == 38 && e.Alt)
                {
                    int rowHandler = gridViewKind.FocusedRowHandle;
                    if (rowHandler > 0)
                    {
                        DataRow rowcurrent = gridViewKind.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewKind.GetDataRow(rowHandler - 1);
                        foreach (DataColumn column in rowcurrent.Table.Columns)
                        {
                            if (column.ColumnName.ToUpper() == "EVENT_ITEM_CODE")
                                continue;

                            object obj = rowcurrent[column];
                            rowcurrent[column] = rowNext[column];
                            rowNext[column] = obj;
                        }
                        btnSave.Enabled = true;
                    }
                }
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void gridViewEvent_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40 && e.Alt)
                {
                    int rowHandler = gridViewEvent.FocusedRowHandle;
                    if (rowHandler < gridViewEvent.RowCount - 1)
                    {
                        DataRow rowcurrent = gridViewEvent.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewEvent.GetDataRow(rowHandler + 1);

                        int tempIndex = Convert.ToInt32(rowcurrent["SORT_NO"]);
                        rowcurrent["SORT_NO"] = rowNext["SORT_NO"];
                        rowNext["SORT_NO"] = tempIndex;

                        e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }
                else if (e.KeyValue == 38 && e.Alt)
                {
                    int rowHandler = gridViewEvent.FocusedRowHandle;
                    if (rowHandler > 0)
                    {
                        DataRow rowcurrent = gridViewEvent.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewEvent.GetDataRow(rowHandler - 1);

                        int tempIndex = Convert.ToInt32(rowcurrent["SORT_NO"]);
                        rowcurrent["SORT_NO"] = rowNext["SORT_NO"];
                        rowNext["SORT_NO"] = tempIndex;

                        e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }


            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void gridViewMethod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40 && e.Alt)
                {
                    int rowHandler = gridViewMethod.FocusedRowHandle;
                    if (rowHandler < gridViewMethod.RowCount - 1)
                    {
                        DataRow rowcurrent = gridViewMethod.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewMethod.GetDataRow(rowHandler + 1);

                        int tempIndex = Convert.ToInt32(rowcurrent["SORT_NO"]);
                        rowcurrent["SORT_NO"] = rowNext["SORT_NO"];
                        rowNext["SORT_NO"] = tempIndex;

                        e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }
                else if (e.KeyValue == 38 && e.Alt)
                {
                    int rowHandler = gridViewMethod.FocusedRowHandle;
                    if (rowHandler > 0)
                    {
                        DataRow rowcurrent = gridViewMethod.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewMethod.GetDataRow(rowHandler - 1);

                        int tempIndex = Convert.ToInt32(rowcurrent["SORT_NO"]);
                        rowcurrent["SORT_NO"] = rowNext["SORT_NO"];
                        rowNext["SORT_NO"] = tempIndex;

                        e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (_currentIsAdding)
            {
                MessageBoxFormPC.Show("��ǰ��������״̬���������������������ѡ�������ֵ�ҳ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
    }




    public enum EditMode
    {
        Add,
        Save,
        Cancel,
        Delete,
        Refresh
    }
}
