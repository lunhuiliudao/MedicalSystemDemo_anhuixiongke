namespace MedicalSystem.Anes.Client.AppPC
{
    partial class BloodGasTemplet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BloodGasTemplet));
            this.txtNewTempletName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditSample = new DevExpress.XtraEditors.ComboBoxEdit();
            this.medPanel4 = new MedicalSystem.Anes.Document.Controls.MedPanel();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.dgvItemCanSelect = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.medScrollbar2 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.dgvItemSelected = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnMenuUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnMenuDown = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddTemplet = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnDel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewTempletName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSample.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel4)).BeginInit();
            this.medPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemCanSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNewTempletName
            // 
            this.txtNewTempletName.Location = new System.Drawing.Point(328, 8);
            this.txtNewTempletName.Name = "txtNewTempletName";
            this.txtNewTempletName.Properties.LookAndFeel.SkinName = "Blue";
            this.txtNewTempletName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtNewTempletName.Properties.MaxLength = 15;
            this.txtNewTempletName.Size = new System.Drawing.Size(213, 21);
            this.txtNewTempletName.TabIndex = 26;
            this.txtNewTempletName.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtNewTempletName_EditValueChanging);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 14);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "选择血气模板:";
            // 
            // comboBoxEditSample
            // 
            this.comboBoxEditSample.EditValue = "";
            this.comboBoxEditSample.Location = new System.Drawing.Point(111, 7);
            this.comboBoxEditSample.Name = "comboBoxEditSample";
            this.comboBoxEditSample.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSample.Properties.LookAndFeel.SkinName = "Blue";
            this.comboBoxEditSample.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxEditSample.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSample.Size = new System.Drawing.Size(211, 21);
            this.comboBoxEditSample.TabIndex = 23;
            this.comboBoxEditSample.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditSample_SelectedIndexChanged);
            // 
            // medPanel4
            // 
            this.medPanel4.Controls.Add(this.splitContainerControl2);
            this.medPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medPanel4.Location = new System.Drawing.Point(0, 40);
            this.medPanel4.Name = "medPanel4";
            this.medPanel4.Size = new System.Drawing.Size(657, 456);
            this.medPanel4.TabIndex = 3;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl2.LookAndFeel.SkinName = "Blue";
            this.splitContainerControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl5);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControl6);
            this.splitContainerControl2.Panel2.Controls.Add(this.panelControl6);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(653, 452);
            this.splitContainerControl2.SplitterPosition = 309;
            this.splitContainerControl2.TabIndex = 52;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.medScrollbar1);
            this.groupControl5.Controls.Add(this.dgvItemCanSelect);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(0, 0);
            this.groupControl5.LookAndFeel.SkinName = "Blue";
            this.groupControl5.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(309, 452);
            this.groupControl5.TabIndex = 0;
            this.groupControl5.Text = "备选项目";
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 69;
            this.medScrollbar1.Location = new System.Drawing.Point(291, 24);
            this.medScrollbar1.Maximum = 69;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 425);
            this.medScrollbar1.SmallChange = 23;
            this.medScrollbar1.TabIndex = 8;
            this.medScrollbar1.ThisControl = this.dgvItemCanSelect;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // dgvItemCanSelect
            // 
            this.dgvItemCanSelect.AllowUserToAddRows = false;
            this.dgvItemCanSelect.AllowUserToDeleteRows = false;
            this.dgvItemCanSelect.AllowUserToResizeRows = false;
            this.dgvItemCanSelect.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemCanSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemCanSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1});
            this.dgvItemCanSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemCanSelect.Location = new System.Drawing.Point(2, 23);
            this.dgvItemCanSelect.MultiSelect = false;
            this.dgvItemCanSelect.Name = "dgvItemCanSelect";
            this.dgvItemCanSelect.ReadOnly = true;
            this.dgvItemCanSelect.RowHeadersVisible = false;
            this.dgvItemCanSelect.RowHeadersWidth = 10;
            this.dgvItemCanSelect.RowTemplate.Height = 23;
            this.dgvItemCanSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvItemCanSelect.Size = new System.Drawing.Size(305, 427);
            this.dgvItemCanSelect.TabIndex = 7;
            this.dgvItemCanSelect.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemCanSelect_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "项目代码";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "显示名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.medScrollbar2);
            this.groupControl6.Controls.Add(this.dgvItemSelected);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl6.Location = new System.Drawing.Point(0, 0);
            this.groupControl6.LookAndFeel.SkinName = "Blue";
            this.groupControl6.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(338, 411);
            this.groupControl6.TabIndex = 0;
            this.groupControl6.Text = "当前模板项目";
            // 
            // medScrollbar2
            // 
            this.medScrollbar2.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar2.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.DownArrowImage")));
            this.medScrollbar2.LargeChange = 69;
            this.medScrollbar2.Location = new System.Drawing.Point(320, 24);
            this.medScrollbar2.Maximum = 69;
            this.medScrollbar2.Minimum = 0;
            this.medScrollbar2.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar2.Name = "medScrollbar2";
            this.medScrollbar2.Size = new System.Drawing.Size(15, 384);
            this.medScrollbar2.SmallChange = 23;
            this.medScrollbar2.TabIndex = 8;
            this.medScrollbar2.ThisControl = this.dgvItemSelected;
            this.medScrollbar2.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbBottomImage")));
            this.medScrollbar2.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbBottomSpanImage")));
            this.medScrollbar2.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbMiddleImage")));
            this.medScrollbar2.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbTopImage")));
            this.medScrollbar2.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbTopSpanImage")));
            this.medScrollbar2.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.UpArrowImage")));
            this.medScrollbar2.Value = 0;
            // 
            // dgvItemSelected
            // 
            this.dgvItemSelected.AllowUserToAddRows = false;
            this.dgvItemSelected.AllowUserToDeleteRows = false;
            this.dgvItemSelected.AllowUserToResizeRows = false;
            this.dgvItemSelected.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column2});
            this.dgvItemSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemSelected.Location = new System.Drawing.Point(2, 23);
            this.dgvItemSelected.MultiSelect = false;
            this.dgvItemSelected.Name = "dgvItemSelected";
            this.dgvItemSelected.ReadOnly = true;
            this.dgvItemSelected.RowHeadersVisible = false;
            this.dgvItemSelected.RowHeadersWidth = 10;
            this.dgvItemSelected.RowTemplate.Height = 23;
            this.dgvItemSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvItemSelected.Size = new System.Drawing.Size(334, 386);
            this.dgvItemSelected.TabIndex = 7;
            this.dgvItemSelected.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemSelected_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "项目代码";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "显示名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btnMenuUp);
            this.panelControl6.Controls.Add(this.btnMenuDown);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(0, 411);
            this.panelControl6.LookAndFeel.SkinName = "Blue";
            this.panelControl6.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(338, 41);
            this.panelControl6.TabIndex = 1;
            // 
            // btnMenuUp
            // 
            this.btnMenuUp.Location = new System.Drawing.Point(6, 7);
            this.btnMenuUp.LookAndFeel.SkinName = "Blue";
            this.btnMenuUp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMenuUp.Name = "btnMenuUp";
            this.btnMenuUp.Size = new System.Drawing.Size(63, 27);
            this.btnMenuUp.TabIndex = 10;
            this.btnMenuUp.Text = "上移";
            this.btnMenuUp.Click += new System.EventHandler(this.btnMenuUp_Click);
            // 
            // btnMenuDown
            // 
            this.btnMenuDown.Location = new System.Drawing.Point(76, 7);
            this.btnMenuDown.LookAndFeel.SkinName = "Blue";
            this.btnMenuDown.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMenuDown.Name = "btnMenuDown";
            this.btnMenuDown.Size = new System.Drawing.Size(63, 27);
            this.btnMenuDown.TabIndex = 11;
            this.btnMenuDown.Text = "下移";
            this.btnMenuDown.Click += new System.EventHandler(this.btnMenuDown_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddTemplet);
            this.panel1.Controls.Add(this.txtNewTempletName);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.comboBoxEditSample);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 40);
            this.panel1.TabIndex = 4;
            // 
            // btnAddTemplet
            // 
            this.btnAddTemplet.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnAddTemplet.Location = new System.Drawing.Point(552, 3);
            this.btnAddTemplet.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnAddTemplet.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnAddTemplet.Name = "btnAddTemplet";
            this.btnAddTemplet.Size = new System.Drawing.Size(102, 34);
            this.btnAddTemplet.TabIndex = 90;
            this.btnAddTemplet.Title = "增加模板";
            this.btnAddTemplet.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnAddTemplet_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 496);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 50);
            this.panel2.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnSave.Location = new System.Drawing.Point(29, 11);
            this.btnSave.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnSave.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 34);
            this.btnSave.TabIndex = 89;
            this.btnSave.Title = "保存";
            this.btnSave.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnDel.Location = new System.Drawing.Point(137, 11);
            this.btnDel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnDel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(102, 34);
            this.btnDel.TabIndex = 90;
            this.btnDel.Title = "删除";
            this.btnDel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnDel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnDel);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(415, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(242, 50);
            this.flowLayoutPanel1.TabIndex = 91;
            // 
            // BloodGasTemplet
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.medPanel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BloodGasTemplet";
            this.Size = new System.Drawing.Size(657, 546);
            this.Load += new System.EventHandler(this.BloodGasTemplet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNewTempletName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSample.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel4)).EndInit();
            this.medPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemCanSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNewTempletName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSample;
        private Document.Controls.MedPanel medPanel4;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.DataGridView dgvItemCanSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.DataGridView dgvItemSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btnMenuUp;
        private DevExpress.XtraEditors.SimpleButton btnMenuDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Document.Controls.MedScrollbar medScrollbar1;
        private Document.Controls.MedScrollbar medScrollbar2;
        private FrameWork.ButtonColor btnAddTemplet;
        private FrameWork.ButtonColor btnSave;
        private FrameWork.ButtonColor btnDel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
