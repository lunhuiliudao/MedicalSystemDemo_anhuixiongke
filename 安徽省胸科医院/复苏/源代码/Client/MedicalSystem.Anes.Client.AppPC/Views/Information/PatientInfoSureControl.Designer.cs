namespace MedicalSystem.Anes.Client.AppPC
{
    partial class PatientInfoSureControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientInfoSureControl));
            this.dgPatientInfo = new System.Windows.Forms.DataGridView();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatientInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPatientInfo
            // 
            this.dgPatientInfo.AllowUserToAddRows = false;
            this.dgPatientInfo.AllowUserToDeleteRows = false;
            this.dgPatientInfo.AllowUserToResizeColumns = false;
            this.dgPatientInfo.AllowUserToResizeRows = false;
            this.dgPatientInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPatientInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgPatientInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgPatientInfo.ColumnHeadersHeight = 36;
            this.dgPatientInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPatientInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn5,
            this.ColumnPatientID,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.YColumn10,
            this.dataGridViewTextBoxColumn7,
            this.ColumnVisitID,
            this.ColumnOperID});
            this.dgPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPatientInfo.EnableHeadersVisualStyles = false;
            this.dgPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.dgPatientInfo.MultiSelect = false;
            this.dgPatientInfo.Name = "dgPatientInfo";
            this.dgPatientInfo.RowHeadersVisible = false;
            this.dgPatientInfo.RowHeadersWidth = 20;
            this.dgPatientInfo.RowTemplate.Height = 23;
            this.dgPatientInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgPatientInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatientInfo.Size = new System.Drawing.Size(853, 476);
            this.dgPatientInfo.TabIndex = 96;
            this.dgPatientInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPatientInfo_CellDoubleClick);
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 69;
            this.medScrollbar1.Location = new System.Drawing.Point(835, 1);
            this.medScrollbar1.Maximum = 69;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(17, 107);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(17, 474);
            this.medScrollbar1.SmallChange = 23;
            this.medScrollbar1.TabIndex = 97;
            this.medScrollbar1.ThisControl = this.dgPatientInfo;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SCHEDULED_DATE_TIME";
            this.dataGridViewTextBoxColumn9.HeaderText = "手术日期";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NAME";
            this.dataGridViewTextBoxColumn5.HeaderText = "患者姓名";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // ColumnPatientID
            // 
            this.ColumnPatientID.DataPropertyName = "PATIENT_ID";
            this.ColumnPatientID.HeaderText = "患者ID";
            this.ColumnPatientID.Name = "ColumnPatientID";
            this.ColumnPatientID.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "INP_NO";
            this.dataGridViewTextBoxColumn4.HeaderText = "住院号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OPER_DEPT_NAME";
            this.dataGridViewTextBoxColumn2.HeaderText = "所在科室";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "BED_NO";
            this.dataGridViewTextBoxColumn6.HeaderText = "床号";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "OPERATION_NAME";
            this.dataGridViewTextBoxColumn8.HeaderText = "手术名称";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // YColumn10
            // 
            this.YColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.YColumn10.DataPropertyName = "SURGEON_NAME";
            this.YColumn10.HeaderText = "手术医生";
            this.YColumn10.Name = "YColumn10";
            this.YColumn10.ReadOnly = true;
            this.YColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "EMERGENCY_NAME";
            this.dataGridViewTextBoxColumn7.HeaderText = "急诊择期";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // ColumnVisitID
            // 
            this.ColumnVisitID.DataPropertyName = "VISIT_ID";
            this.ColumnVisitID.HeaderText = "ColumnVisitID";
            this.ColumnVisitID.Name = "ColumnVisitID";
            this.ColumnVisitID.Visible = false;
            // 
            // ColumnOperID
            // 
            this.ColumnOperID.DataPropertyName = "OPER_ID";
            this.ColumnOperID.HeaderText = "ColumnOperID";
            this.ColumnOperID.Name = "ColumnOperID";
            this.ColumnOperID.Visible = false;
            // 
            // PatientInfoSureControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.medScrollbar1);
            this.Controls.Add(this.dgPatientInfo);
            this.Name = "PatientInfoSureControl";
            this.Size = new System.Drawing.Size(853, 476);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatientInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPatientInfo;
        private Document.Controls.MedScrollbar medScrollbar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn YColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOperID;
    }
}
