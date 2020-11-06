namespace MedicalSystem.Anes.Client.AppPC
{
    partial class SelectMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMonitor));
            this.medDataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.btnCannel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnNext = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.medDataGridView1)).BeginInit();
            this.panelSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // medDataGridView1
            // 
            this.medDataGridView1.AllowDrop = true;
            this.medDataGridView1.AllowUserToAddRows = false;
            this.medDataGridView1.AllowUserToDeleteRows = false;
            this.medDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.medDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.medDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.medDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.medDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.medDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.medDataGridView1.MultiSelect = false;
            this.medDataGridView1.Name = "medDataGridView1";
            this.medDataGridView1.ReadOnly = true;
            this.medDataGridView1.RowHeadersVisible = false;
            this.medDataGridView1.RowHeadersWidth = 25;
            this.medDataGridView1.RowTemplate.Height = 23;
            this.medDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.medDataGridView1.Size = new System.Drawing.Size(700, 332);
            this.medDataGridView1.TabIndex = 1;
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.btnCannel);
            this.panelSelect.Controls.Add(this.btnNext);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSelect.Location = new System.Drawing.Point(0, 332);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(700, 48);
            this.panelSelect.TabIndex = 44;
            // 
            // btnCannel
            // 
            this.btnCannel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.灰色;
            this.btnCannel.Location = new System.Drawing.Point(581, 6);
            this.btnCannel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(102, 34);
            this.btnCannel.TabIndex = 84;
            this.btnCannel.Title = "取消";
            this.btnCannel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCannel_BtnClicked);
            // 
            // btnNext
            // 
            this.btnNext.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnNext.Location = new System.Drawing.Point(462, 6);
            this.btnNext.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnNext.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(102, 34);
            this.btnNext.TabIndex = 83;
            this.btnNext.Title = "确认";
            this.btnNext.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnNext_BtnClicked);
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 10;
            this.medScrollbar1.Location = new System.Drawing.Point(684, 1);
            this.medScrollbar1.Maximum = 100;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 330);
            this.medScrollbar1.SmallChange = 1;
            this.medScrollbar1.TabIndex = 45;
            this.medScrollbar1.ThisControl = this.medDataGridView1;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PATIENT_ID";
            this.Column6.HeaderText = "PATIENT_IDColumn6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "VISIT_ID";
            this.Column7.HeaderText = "VISIT_IDColumn7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "OPER_ID";
            this.Column8.HeaderText = "OPER_IDColumn8";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MONITOR_TYPE";
            this.Column1.HeaderText = "设备类型";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "MONITOR_LABEL";
            this.Column2.HeaderText = "设备标识";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DEFAULT_RECV_FREQUENCY";
            this.Column3.HeaderText = "默认采集频率";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 110;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CURRENT_RECV_FREQUENCY";
            this.Column4.HeaderText = "当前采集频率";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 110;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CURRENT_RECVTIMES_UPLIMIT";
            this.Column5.HeaderText = "采集次数";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // SelectMonitor
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.medScrollbar1);
            this.Controls.Add(this.medDataGridView1);
            this.Controls.Add(this.panelSelect);
            this.Name = "SelectMonitor";
            this.Size = new System.Drawing.Size(700, 380);
            this.Load += new System.EventHandler(this.SelectMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medDataGridView1)).EndInit();
            this.panelSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView medDataGridView1;
        private System.Windows.Forms.Panel panelSelect;
        private FrameWork.ButtonColor btnCannel;
        private FrameWork.ButtonColor btnNext;
        private Document.Controls.MedScrollbar medScrollbar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
