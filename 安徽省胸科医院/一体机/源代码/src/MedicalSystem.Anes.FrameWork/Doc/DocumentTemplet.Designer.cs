namespace MedicalSystem.Anes.Document.Documents
{
    partial class DocumentTemplet
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMessage = new MedicalSystem.Anes.Document.Controls.MedLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new MedicalSystem.Anes.FrameWork.ButtonColor();
            this.btnSave = new MedicalSystem.Anes.FrameWork.ButtonColor();
            this.btnApply = new MedicalSystem.Anes.FrameWork.ButtonColor();
            this.medPanel2 = new MedicalSystem.Anes.Document.Controls.MedPanel();
            this.medSplitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).BeginInit();
            this.medPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medSplitContainer1)).BeginInit();
            this.medSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Appearance.Options.UseForeColor = true;
            this.lblMessage.Appearance.Options.UseTextOptions = true;
            this.lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblMessage.BottomLine = false;
            this.lblMessage.DotBorder = false;
            this.lblMessage.Image = null;
            this.lblMessage.Location = new System.Drawing.Point(12, 24);
            this.lblMessage.MultiLine = false;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.NoPrint = false;
            this.lblMessage.PrintXOffSet = 0F;
            this.lblMessage.PrintYOffSet = 0F;
            this.lblMessage.Size = new System.Drawing.Size(57, 14);
            this.lblMessage.SymbolType = MedicalSystem.Anes.Document.Controls.MedSymbolType.None;
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "lblMessage";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.VarKey = null;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnApply);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(803, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 55);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.ButtonColorType = MedicalSystem.Anes.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnExit.Location = new System.Drawing.Point(275, 11);
            this.btnExit.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnExit.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 34);
            this.btnExit.TabIndex = 92;
            this.btnExit.Title = "取消";
            this.btnExit.BtnClicked += new MedicalSystem.Anes.FrameWork.ButtonColor.BtnClickHandle(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.ButtonColorType = MedicalSystem.Anes.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnSave.Location = new System.Drawing.Point(167, 11);
            this.btnSave.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnSave.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 34);
            this.btnSave.TabIndex = 91;
            this.btnSave.Title = "保存";
            this.btnSave.BtnClicked += new MedicalSystem.Anes.FrameWork.ButtonColor.BtnClickHandle(this.btnSave_Click);
            // 
            // btnApply
            // 
            this.btnApply.ButtonColorType = MedicalSystem.Anes.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnApply.Location = new System.Drawing.Point(59, 11);
            this.btnApply.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnApply.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(102, 34);
            this.btnApply.TabIndex = 93;
            this.btnApply.Title = "套用";
            this.btnApply.BtnClicked += new MedicalSystem.Anes.FrameWork.ButtonColor.BtnClickHandle(this.btnApply_Click);
            // 
            // medPanel2
            // 
            this.medPanel2.Controls.Add(this.medSplitContainer1);
            this.medPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medPanel2.Location = new System.Drawing.Point(0, 0);
            this.medPanel2.Name = "medPanel2";
            this.medPanel2.Size = new System.Drawing.Size(1183, 493);
            this.medPanel2.TabIndex = 4;
            // 
            // medSplitContainer1
            // 
            this.medSplitContainer1.Appearance.BackColor = System.Drawing.Color.White;
            this.medSplitContainer1.Appearance.Options.UseBackColor = true;
            this.medSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medSplitContainer1.Location = new System.Drawing.Point(2, 2);
            this.medSplitContainer1.LookAndFeel.SkinName = "Blue";
            this.medSplitContainer1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.medSplitContainer1.Name = "medSplitContainer1";
            this.medSplitContainer1.Panel1.Controls.Add(this.treeList1);
            this.medSplitContainer1.Panel1.Text = "Panel1";
            this.medSplitContainer1.Panel2.Text = "Panel2";
            this.medSplitContainer1.Size = new System.Drawing.Size(1179, 489);
            this.medSplitContainer1.SplitterPosition = 196;
            this.medSplitContainer1.TabIndex = 2;
            this.medSplitContainer1.Text = "medSplitContainer1";
            // 
            // treeList1
            // 
            this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(211)))));
            this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.treeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(211)))));
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeList1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.treeList1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(211)))));
            this.treeList1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.LookAndFeel.SkinName = "Blue";
            this.treeList1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(196, 489);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "模板名称(右键菜单操作)";
            this.treeListColumn1.FieldName = "模板名称";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.OptionsColumn.AllowSize = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRename,
            this.toolStripMenuItemDelete,
            this.toolStripMenuItemAdd});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 70);
            // 
            // toolStripMenuItemRename
            // 
            this.toolStripMenuItemRename.Name = "toolStripMenuItemRename";
            this.toolStripMenuItemRename.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemRename.Text = "重命名";
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemDelete.Text = "删除";
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemAdd.Text = "添加";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 493);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 55);
            this.panel1.TabIndex = 0;
            // 
            // DocumentTemplet
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.medPanel2);
            this.Controls.Add(this.panel1);
            this.Name = "DocumentTemplet";
            this.Size = new System.Drawing.Size(1183, 548);
            this.Load += new System.EventHandler(this.DocumentTemplet_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel2)).EndInit();
            this.medPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medSplitContainer1)).EndInit();
            this.medSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Document.Controls.MedLabel lblMessage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Document.Controls.MedPanel medPanel2;
        private DevExpress.XtraEditors.SplitContainerControl medSplitContainer1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRename;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.Panel panel1;
        private FrameWork.ButtonColor btnExit;
        private FrameWork.ButtonColor btnSave;
        private FrameWork.ButtonColor btnApply;
    }
}
