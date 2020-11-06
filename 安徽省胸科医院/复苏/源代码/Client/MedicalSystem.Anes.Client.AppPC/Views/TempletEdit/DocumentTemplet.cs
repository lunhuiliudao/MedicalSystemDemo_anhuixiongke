using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Client.FrameWork;
using DevExpress.XtraTreeList.Nodes;
using MedicalSystem.Anes.Domain;
using System.IO;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(false)]
    public partial class DocumentTemplet : BaseView
    {
        CommonRepository commonRepository = new CommonRepository();

        AccountRepository accountRepository = new AccountRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        public string DialogResultData;
        public DataTable DialogResultDataTable;
        private bool _isApply = false;
        private string _eventNo = "0";
        private MRichTextBox mRichBox = null;
        private bool _hasTotalRight = false;
        private DocTempletType _templetFlag = DocTempletType.None;
        List<MED_DOCUMENT_TEMPLET> _documentTempletDataTable;
        private string _customTempletFlagName = string.Empty;
        /// <summary>
        /// 模板管理构造方法
        /// </summary>
        public DocumentTemplet()
        {
            InitializeComponent();
            btnExit.Visible = false;
            btnApply.Visible = false;
            btnSave.Enabled = false;
            flowLayoutPanel1.Width = 250;
        }

        public bool IsDirty
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        /// <summary>
        /// 模板套用
        /// </summary>
        /// <param name="templetFlag">控件模板标示属性值</param>
        /// <param name="eventNo">0麻醉，1复苏，2体外</param>
        public DocumentTemplet(DocTempletType templetFlag, string eventNo)
        {
            InitializeComponent();
            _eventNo = eventNo;
            _templetFlag = templetFlag;
            _isApply = true;
            btnSave.Visible = false;
            flowLayoutPanel1.Width = 350;
        }
        /// <summary>
        /// 模板套用
        /// </summary>
        /// <param name="templetFlag">控件模板标示属性值</param>
        /// <param name="eventNo">0麻醉，1复苏，2体外</param>
        public DocumentTemplet(string customTempletFlagName, string eventNo)
        {
            InitializeComponent();
            _eventNo = eventNo;
            _customTempletFlagName = customTempletFlagName;
            _isApply = true;
            btnSave.Visible = false;
            flowLayoutPanel1.Width = 350;
        }

        /// <summary>
        /// 模板套用
        /// </summary>
        /// <param name="templetFlag">控件模板标示属性值</param>
        /// <param name="customTempletFlagName">控件模板标示名称</param>
        /// <param name="eventNo">0麻醉，1复苏，2体外</param>
        public DocumentTemplet(DocTempletType templetFlag, string customTempletFlagName, string eventNo)
        {
            InitializeComponent();
            _eventNo = eventNo;
            _customTempletFlagName = customTempletFlagName;
            _templetFlag = templetFlag;
            _isApply = true;
            btnSave.Visible = false;
            flowLayoutPanel1.Width = 350;
        }

        public static DocTempletType TempletTypeFromString(string templetTypeName)
        {
            List<MemberDetail> list = AssemblyHelper.GetEnumList(typeof(DocTempletType), true);
            foreach (MemberDetail item in list)
            {
                if (item.Name.Equals(templetTypeName))
                {
                    return (DocTempletType)item.Value;
                }
            }
            return DocTempletType.None;
        }

        public static string TempletTypeToString(DocTempletType templetType)
        {
            List<MemberDetail> list = AssemblyHelper.GetEnumList(typeof(DocTempletType), true);
            //List<string> itemNames = new List<string>();
            foreach (MemberDetail item in list)
            {
                if (((DocTempletType)item.Value) == templetType)
                {
                    return item.Name;
                }
            }
            return "";
        }

        /// <summary>
        /// treelist初始化
        /// </summary>
        private void InitTreeList()
        {
            _documentTempletDataTable = commonRepository.GetDocumentTemplet().Data;
            treeList1.Nodes.Clear();
            if (_isApply)
            {
                if ((_templetFlag == DocTempletType.None || _templetFlag == DocTempletType.ALL) && !string.IsNullOrEmpty(_customTempletFlagName))
                {
                    treeList1.AppendNode(new object[] { _customTempletFlagName }, null);
                    List<MED_DOCUMENT_TEMPLET> documentRows = _documentTempletDataTable.Where(x => x.DOCUMENT_NAME == _customTempletFlagName && x.EVENT_NO == _eventNo).ToList();
                    foreach (MED_DOCUMENT_TEMPLET row in documentRows)
                    {
                        AppendNode(row);
                    }
                }
                else
                {
                    AppendRootNode(_templetFlag);
                    List<MED_DOCUMENT_TEMPLET> documentRows = _documentTempletDataTable.Where(x => x.DOCUMENT_NAME == TempletTypeToString(_templetFlag) && x.EVENT_NO == _eventNo).ToList();
                    foreach (MED_DOCUMENT_TEMPLET row in documentRows)
                    {
                        AppendNode(row);
                    }
                }
            }
            else
            {
                _eventNo = ExtendApplicationContext.Current.EventNo;
                AppendRootNode(DocTempletType.PreAnesSummary);
                AppendRootNode(DocTempletType.AnesSummary);
                AppendRootNode(DocTempletType.VisitRecord);
                if (ExtendApplicationContext.Current.CustomSettingContext.CustomTempletFlagNames.Count > 0)
                {
                    foreach (string flagName in ExtendApplicationContext.Current.CustomSettingContext.CustomTempletFlagNames)
                    {
                        bool find = false;
                        foreach (TreeListNode node in treeList1.Nodes)
                        {
                            if (node.GetDisplayText(0) == flagName)
                            {
                                find = true;
                                break;
                            }
                        }
                        if (!find)
                        {
                            treeList1.AppendNode(new object[] { flagName }, null);
                        }
                    }
                }
                AppendRootNode(DocTempletType.Other);
                List<MED_DOCUMENT_TEMPLET> documentRows = _documentTempletDataTable.Where(x => x.EVENT_NO == _eventNo).ToList();
                foreach (MED_DOCUMENT_TEMPLET row in documentRows)
                {
                    AppendNode(row);
                }
            }
            treeList1.ExpandAll();
        }

        private void AppendNode(MED_DOCUMENT_TEMPLET row)
        {
            TreeListNode rootnode = null;
            foreach (TreeListNode node in treeList1.Nodes)
            {
                if (node.GetDisplayText(0) == row.DOCUMENT_NAME)
                {
                    rootnode = node;
                    break;
                }
            }
            if (rootnode != null)
            {
                TreeListNode classNode = null;
                foreach (TreeListNode node in rootnode.Nodes)
                {
                    if (node.GetDisplayText(0) == row.CLASS_NAME)
                    {
                        classNode = node;
                        break;
                    }
                }
                if (classNode == null)
                {
                    classNode = treeList1.AppendNode(new object[] { row.CLASS_NAME }, rootnode);
                }
                TreeListNode newNode = treeList1.AppendNode(new object[] { row.TEMPLET_NAME }, classNode);
                newNode.Tag = row.TEMPLET_GUID;
            }
        }

        private void AppendRootNode(DocTempletType templetType)
        {
            string templetTypeName = TempletTypeToString(templetType);
            if (!string.IsNullOrEmpty(templetTypeName))
            {
                treeList1.AppendNode(new object[] { templetTypeName }, null);
            }
        }

        private void CheckRight()
        {
            if (!AccessControl.CheckModifyRight("模板管理"))
            {
                flowLayoutPanel1.Visible = false;
                mRichBox.ReadOnly = true;
            }
            else
            {
                _hasTotalRight = true;
            }
        }

        private void LoadRichBoxData(string templetGuid)
        {
            mRichBox.Text = string.Empty;
            List<MED_DOCUMENT_TEMPLET> prows = _documentTempletDataTable.Where(x => x.TEMPLET_GUID == templetGuid).ToList();

            if (prows != null && prows.Count > 0)
            {
                MED_DOCUMENT_TEMPLET prow = prows[0];
                if (_templetFlag == DocTempletType.ALL)
                {
                    MemoryStream stream = new MemoryStream(prow.TEMPLET_VALUE);
                    stream.Position = 0;
                    DialogResultDataTable.Rows.Clear();
                    DialogResultDataTable.ReadXml(stream);
                    mRichBox.Text = prow.TEMPLET_NAME;
                    stream.Close();
                }
                else
                {
                    string ret = StringHelper.Arr2Str(prow.TEMPLET_VALUE);
                    mRichBox.Text = ret;
                }
            }
            btnSave.Enabled = false;
        }

        public bool Save()
        {
            bool b = false;
            List<MED_DOCUMENT_TEMPLET> prows = _documentTempletDataTable.Where(x => x.TEMPLET_GUID == treeList1.FocusedNode.Tag.ToString()).ToList();
            if (prows != null && prows.Count > 0)
            {
                MED_DOCUMENT_TEMPLET prow = prows[0];
                if (string.IsNullOrEmpty(mRichBox.Text.Trim()))
                {
                    prow.SetValue("TEMPLET_VALUE", null);
                }
                else
                {
                    prow.TEMPLET_VALUE = StringHelper.Str2Arr(mRichBox.Text.Trim());
                }
                if (commonRepository.SaveDocumentTemplet(prow).Data > 0)
                {
                    b = true;
                    btnSave.Enabled = false;
                }
            }

            return b;
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!_hasTotalRight) return;
                Point clickPoint = new Point(e.X, e.Y);
                DevExpress.XtraTreeList.TreeListHitInfo hInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
                if (hInfo.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell) //在单元格上右击了 
                {
                    TreeListNode node = hInfo.Node;
                    treeList1.FocusedNode = node;
                    if (!_isApply && hInfo.Node != null)
                    {
                        toolStripMenuItemAdd.Visible = false; ;
                        toolStripMenuItemDelete.Visible = false;
                        toolStripMenuItemRename.Visible = false;
                        if (hInfo.Node.ParentNode != null && hInfo.Node.ParentNode.ParentNode != null && !hInfo.Node.HasChildren)
                        {
                            toolStripMenuItemAdd.Visible = false;
                            toolStripMenuItemDelete.Visible = true;
                            toolStripMenuItemRename.Visible = true;
                        }
                        else if (hInfo.Node.HasChildren || hInfo.Node.ParentNode == null || hInfo.Node.ParentNode.ParentNode == null)
                        {
                            toolStripMenuItemAdd.Visible = true;
                            toolStripMenuItemDelete.Visible = false;
                            toolStripMenuItemRename.Visible = false;
                        }
                        contextMenuStrip1.Show(treeList1, e.X, e.Y);
                    }
                }
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && e.Node.ParentNode != null && e.Node.ParentNode.ParentNode != null && !e.Node.HasChildren)
            {
                LoadRichBoxData(e.Node.Tag.ToString());
                mRichBox.Enabled = true;
                btnApply.Enabled = true;
            }
            else
            {
                mRichBox.Text = string.Empty;
                mRichBox.Enabled = false; ;
                btnSave.Enabled = false;
                btnApply.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag != null)
            {
                DialogResultData = mRichBox.Text;
                if (ParentForm != null && ParentForm.Modal)
                {
                    ParentForm.DialogResult = DialogResult.OK;
                }
            }
        }

        private void DocumentTemplet_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                btnApply.Visible = _isApply;
                btnExit.Visible = _isApply;
                btnSave.Visible = !_isApply;
                DialogResultDataTable = new DataTable();
                DialogResultDataTable.Columns.Add(new DataColumn("ControlName", typeof(string)));
                DialogResultDataTable.Columns.Add(new DataColumn("ControlValue", typeof(string)));
                DialogResultDataTable.TableName = "TOTALMODEL";
                mRichBox = new MRichTextBox();
                mRichBox.Enabled = !_isApply;
                medSplitContainer1.Panel2.Controls.Add(mRichBox);
                medSplitContainer1.Panel2.Padding = new Padding(15, 15, 15, 15);
                mRichBox.Dock = DockStyle.Fill;
                mRichBox.WordWrap = true;
                mRichBox.Multiline = true;
                mRichBox.BackColor = Color.White;
                mRichBox.BorderStyle = BorderStyle.Fixed3D;
                mRichBox.TextChanged += new EventHandler(mRichBox_TextChanged);
                CheckRight();
                InitTreeList();
            }
        }

        void mRichBox_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
