using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;

namespace MedicalSystem.Anes.Document.Documents
{
    [ToolboxItem(false)]
    public partial class QiXieQingDianTemplet : BaseView
    {
        public string DialogResultData = string.Empty;
        public bool IsAddTempletData = false;
        private bool _hasTotalRight = false;
        private List<string> deptNames = new List<string>();
        List<MED_DEPT_DICT> _deptDict;
        List<MED_QIXIE_TEMPLET_DETAIL> _qiXieTempletDetail = null;
        List<MED_QIXIE_TEMPLET_MASTER> _qiXieTempletMaster = null;
        private bool _isApply = false;

        public bool IsApply
        {
            get { return _isApply; }
            set { _isApply = value; }
        }

        public QiXieQingDianTemplet()
        {

            InitializeComponent();
            btnApply.Visible = false; ;
            btnExit.Visible = false;
            btnDel.Visible = false;
        }

        public new bool IsDirty
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        /// <summary>
        /// treelist初始化
        /// </summary>
        private void InitTreeList()
        {
            _qiXieTempletMaster = CommonService.ClientInstance.GetQiXieTempletMaster();
            _deptDict = ApplicationModel.Instance.AllDictList.DeptDictList;// ExtendAppContext.Current.CommDict.DeptDict;
            foreach (MED_DEPT_DICT row in _deptDict)
            {
                deptNames.Add(row.DEPT_NAME);
            }
            treeList1.Nodes.Clear();
            TreeListNode nodeZhuBao = treeList1.AppendNode(new object[] { "主包" }, null);
            nodeZhuBao.Tag = 0;
            TreeListNode nodeFuBao = treeList1.AppendNode(new object[] { "副包" }, null);
            nodeFuBao.Tag = 1;
            if (_qiXieTempletMaster != null && _qiXieTempletMaster.Count > 0)
            {
                foreach (MED_QIXIE_TEMPLET_MASTER prow in _qiXieTempletMaster)
                {
                    AppendNode(prow);
                }
            }
            treeList1.ExpandAll();
        }

        private void AppendNode(MED_QIXIE_TEMPLET_MASTER prow)
        {
            if (prow.OPER_BAG_FLAG == 0)
            {
                AppendNode(treeList1.Nodes[0], prow);
            }
            else if (prow.OPER_BAG_FLAG == 1)
            {
                AppendNode(treeList1.Nodes[1], prow);
            }
        }

        private void AppendNode(TreeListNode parentNode, MED_QIXIE_TEMPLET_MASTER prow)
        {
            if (parentNode != null)
            {
                TreeListNode newNode = null;
                foreach (TreeListNode node in parentNode.Nodes)
                {
                    if (node.GetDisplayText(0).Equals(prow.CLASS_NAME))
                    {
                        newNode = treeList1.AppendNode(new object[] { prow.TEMPLET_NAME }, node);
                        newNode.Tag = prow.TEMPLET_GUID;
                        break;
                    }
                }
                if (newNode == null)
                {
                    newNode = treeList1.AppendNode(new object[] { prow.TEMPLET_NAME }, treeList1.AppendNode(new object[] { prow.CLASS_NAME }, parentNode));
                    newNode.Tag = prow.TEMPLET_GUID;
                }
            }
        }

        private void CheckRight()
        {
            //if (true) //(!AccessControl.CheckModifyRight("模板管理"))
            //{
            //    flowLayoutPanel1.Visible = false;
            //    dataGridView1.ReadOnly = true;
            //}
            //else
            //{
            //    _hasTotalRight = true;
            //}
            flowLayoutPanel1.Visible = false;
            dataGridView1.ReadOnly = true;
        }

        /// <summary>
        /// 载入表格数据
        /// </summary>
        private void LoadGridData(string templetGuid)
        {
            dataGridView1.Rows.Clear();

            //_qiXieTempletDetail = CommonService.GetQiXieTempletDetail(templetGuid);
            if (_qiXieTempletDetail != null && _qiXieTempletDetail.Count > 0)
            {
                int detailCount = _qiXieTempletDetail.Count;
                dataGridView1.RowCount = detailCount + 1;
                for (int i = 0; i < detailCount; i++)
                {
                    dataGridView1[0, i].Value = _qiXieTempletDetail[i].ITEM_NAME;
                    if (!string.IsNullOrEmpty(_qiXieTempletDetail[i].ITEM_VALUE))
                    {
                        dataGridView1[1, i].Value = _qiXieTempletDetail[i].ITEM_VALUE;
                    }
                }
            }
            btnSave.Enabled = false;
        }

        private void QiXieQingDianTemplet_Load(object sender, EventArgs e)
        {
            this.SetDefaultGridViewStyle(dataGridView1);
            if (!DesignMode)
            {
                btnApply.Visible = IsApply;
                btnExit.Visible = IsApply;
                btnSave.Visible = !IsApply;
                checkEdit1.Visible = false;//IsApply;
                checkEdit1.Checked = true;
                CheckRight();
                InitTreeList();
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && e.Node.ParentNode != null && e.Node.ParentNode.ParentNode != null && !e.Node.HasChildren)
            {
                LoadGridData(e.Node.Tag.ToString());
                dataGridView1.ReadOnly = false;
                btnApply.Enabled = true; ;
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.ReadOnly = true; ;
                btnSave.Enabled = false;
                btnApply.Enabled = false;
            }
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

        private void toolStripMenuItemRename_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag != null && !string.IsNullOrEmpty(treeList1.FocusedNode.Tag.ToString()))
            {
                List<MED_QIXIE_TEMPLET_MASTER> prow = _qiXieTempletMaster.Where(x => x.TEMPLET_GUID == treeList1.FocusedNode.Tag.ToString()).ToList();
                if (prow != null && prow.Count > 0)
                {
                    MED_QIXIE_TEMPLET_MASTER row = prow[0];
                    object result = Dialog.SingleInputSelect("手术清点模板名称", prow[0].TEMPLET_NAME);
                    if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()) && result.ToString().Trim() != prow[0].TEMPLET_NAME)
                    {
                        List<MED_QIXIE_TEMPLET_MASTER> prows = _qiXieTempletMaster.Where(x => x.OPER_BAG_FLAG == row.OPER_BAG_FLAG && x.CLASS_NAME == row.CLASS_NAME && x.TEMPLET_NAME == row.TEMPLET_NAME).ToList();
                        if (prows.Count > 0)
                        {
                            Dialog.MessageBox("所在模板分类中已存在该名字");
                        }
                        else
                        {
                            row.TEMPLET_NAME = result.ToString().Trim();
                            //if (CommonService.SaveQiXieMaster(row))
                            {
                                treeList1.FocusedNode.SetValue(0, row.TEMPLET_NAME);
                            }
                        }
                    }
                }
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && !treeList1.FocusedNode.HasChildren && treeList1.FocusedNode.Tag != null)
            {
                for (int i = 0; i < _qiXieTempletDetail.Count; i++)
                {
                    _qiXieTempletDetail.Remove(_qiXieTempletDetail[i]);
                }
                //if (CommonService.SaveQiXieDetailList(_qiXieTempletDetail) || _qiXieTempletDetail.Count == 0)
                {
                    List<MED_QIXIE_TEMPLET_MASTER> prow = _qiXieTempletMaster.Where(x => x.TEMPLET_GUID == treeList1.FocusedNode.Tag.ToString()).ToList();
                    if (prow != null && prow.Count > 0)
                    {
                        MED_QIXIE_TEMPLET_MASTER row = prow[0];
                        _qiXieTempletMaster.Remove(row);
                        //if (CommonService.SaveQiXieMasterList(_qiXieTempletMaster))
                        {
                            treeList1.FocusedNode.ParentNode.Nodes.Remove(treeList1.FocusedNode);
                        }

                    }
                }
            }
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                if (treeList1.FocusedNode.ParentNode == null)
                {
                    object result = Dialog.SingleInputSelect("手术清点模板分类", deptNames.ToArray());
                    if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()))
                    {
                        bool isFind = false;
                        foreach (TreeListNode node in treeList1.FocusedNode.Nodes)
                        {
                            if (node.GetDisplayText(0).Equals(result.ToString().Trim()))
                            {
                                Dialog.MessageBox("分类已存在");
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            treeList1.AppendNode(new object[] { result.ToString().Trim() }, treeList1.FocusedNode);
                        }
                    }
                }
                else
                {
                    object result = Dialog.SingleInputSelect("手术清点模板名称", "");
                    if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()))
                    {
                        bool isFind = false;
                        foreach (TreeListNode node in treeList1.FocusedNode.Nodes)
                        {
                            if (node.GetDisplayText(0).Equals(result.ToString().Trim()))
                            {
                                Dialog.MessageBox("名称已存在");
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            TreeListNode newnode = treeList1.AppendNode(new object[] { result.ToString().Trim() }, treeList1.FocusedNode);
                            MED_QIXIE_TEMPLET_MASTER prow = new MED_QIXIE_TEMPLET_MASTER();
                            prow.TEMPLET_GUID = Guid.NewGuid().ToString();
                            newnode.Tag = prow.TEMPLET_GUID;
                            prow.OPER_BAG_FLAG = int.Parse(treeList1.FocusedNode.RootNode.Tag.ToString());
                            prow.CLASS_NAME = treeList1.FocusedNode.GetDisplayText(0);
                            prow.TEMPLET_NAME = result.ToString().Trim();
                            //CommonService.SaveQiXieMaster(prow);
                            treeList1.FocusedNode = newnode;
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string templetGuid = treeList1.FocusedNode.Tag.ToString();
            MED_QIXIE_TEMPLET_DETAIL prow = null;
            for (int i = 0; i < _qiXieTempletDetail.Count; i++)
            {
                _qiXieTempletDetail.Remove(_qiXieTempletDetail[i]);
            }
            int n = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString().Trim()))
                {
                    prow = new MED_QIXIE_TEMPLET_DETAIL();
                    prow.TEMPLET_GUID = templetGuid;
                    prow.SERIAL_NO = n;
                    prow.ITEM_NAME = row.Cells[0].Value.ToString().Trim();
                    if (row.Cells[1].Value != null && !string.IsNullOrEmpty(row.Cells[1].Value.ToString().Trim()))
                    {
                        prow.ITEM_VALUE = row.Cells[1].Value.ToString().Trim();
                    }
                    _qiXieTempletDetail.Add(prow);
                    n++;
                }
            }
            //if (CommonService.SaveQiXieDetailList(_qiXieTempletDetail))
            {
                btnSave.Enabled = false;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (e.FormattedValue != null && dataGridView1[0, i].Value != null && dataGridView1[0, i].Value.ToString().Trim().Equals(e.FormattedValue.ToString().Trim()))
                    {
                        if (e.RowIndex == i && e.ColumnIndex == 0) continue;
                        Dialog.MessageBox("品名已存在");
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag != null)
            {
                DialogResultData = treeList1.FocusedNode.Tag.ToString();
                IsAddTempletData = checkEdit1.Checked;
                if (ParentForm != null && ParentForm.Modal)
                {
                    ParentForm.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
