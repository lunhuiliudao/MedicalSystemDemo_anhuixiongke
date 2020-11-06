namespace MedicalSystem.Anes.Client.AppPC
{
    partial class PatientListViewPACU
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientListViewPACU));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlBody = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.dgPACUList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAction = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOperID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.panel3 = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.radioGroupStatus = new DevExpress.XtraEditors.RadioGroup();
            this.labelWInpacu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelUnFinishedCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelOutPACU = new System.Windows.Forms.Label();
            this.panel1 = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.label4 = new System.Windows.Forms.Label();
            this.operationRoomPandect1 = new MedicalSystem.Anes.Client.AppPC.OperationRoomPandect();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPACUList)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupStatus.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.pnlBody);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.operationRoomPandect1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.splitContainer1.Size = new System.Drawing.Size(1426, 442);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 95;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.dgPACUList);
            this.pnlBody.Controls.Add(this.medScrollbar1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 72);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(390, 370);
            this.pnlBody.TabIndex = 94;
            // 
            // dgPACUList
            // 
            this.dgPACUList.AllowUserToAddRows = false;
            this.dgPACUList.AllowUserToDeleteRows = false;
            this.dgPACUList.AllowUserToResizeColumns = false;
            this.dgPACUList.AllowUserToResizeRows = false;
            this.dgPACUList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPACUList.BackgroundColor = System.Drawing.Color.White;
            this.dgPACUList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPACUList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(138)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPACUList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPACUList.ColumnHeadersHeight = 36;
            this.dgPACUList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPACUList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.OperStatus,
            this.ColAction,
            this.ColumnPatientID,
            this.ColumnVisitID,
            this.ColumnOperID});
            this.dgPACUList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPACUList.EnableHeadersVisualStyles = false;
            this.dgPACUList.Location = new System.Drawing.Point(0, 0);
            this.dgPACUList.MultiSelect = false;
            this.dgPACUList.Name = "dgPACUList";
            this.dgPACUList.RowHeadersVisible = false;
            this.dgPACUList.RowHeadersWidth = 22;
            this.dgPACUList.RowTemplate.Height = 23;
            this.dgPACUList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgPACUList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPACUList.Size = new System.Drawing.Size(390, 370);
            this.dgPACUList.TabIndex = 95;
            this.dgPACUList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgPACUList_CellFormatting);
            this.dgPACUList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPACUList_CellMouseDown);
            this.dgPACUList.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPACUList_CellMouseLeave);
            this.dgPACUList.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPACUList_CellMouseMove);
            this.dgPACUList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPACUList_ColumnHeaderMouseClick);
            this.dgPACUList.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgPACUList_SortCompare);
            this.dgPACUList.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgPACUList_DragDrop);
            this.dgPACUList.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgPACUList_DragEnter);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            //this.Column1.DataPropertyName = "PACU_BED_NO";
            this.Column1.DataPropertyName = "OPER_ROOM_NO";
            this.Column1.FillWeight = 82.78861F;
            this.Column1.HeaderText = "手术间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 75;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.DataPropertyName = "INP_NO";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.FillWeight = 82.78861F;
            this.Column4.HeaderText = "住院号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.DataPropertyName = "NAME";
            this.Column5.FillWeight = 82.78861F;
            this.Column5.HeaderText = "姓名";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 68;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.DataPropertyName = "SEX";
            this.Column6.FillWeight = 82.78861F;
            this.Column6.HeaderText = "性别";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 45;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7.DataPropertyName = "AGE";
            this.Column7.FillWeight = 82.78861F;
            this.Column7.HeaderText = "年龄";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 45;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.DataPropertyName = "OPERATION_NAME";
            this.Column8.FillWeight = 82.78861F;
            this.Column8.HeaderText = "手术名称";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // OperStatus
            // 
            this.OperStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OperStatus.DataPropertyName = "OPER_STATUS_CODE";
            this.OperStatus.HeaderText = "状态";
            this.OperStatus.Name = "OperStatus";
            this.OperStatus.ReadOnly = true;
            this.OperStatus.Width = 80;
            // 
            // ColAction
            // 
            this.ColAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColAction.FillWeight = 82.78861F;
            this.ColAction.HeaderText = "操作";
            this.ColAction.Name = "ColAction";
            this.ColAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColAction.Width = 68;
            // 
            // ColumnPatientID
            // 
            this.ColumnPatientID.DataPropertyName = "PATIENT_ID";
            this.ColumnPatientID.HeaderText = "ColumnPatientID";
            this.ColumnPatientID.Name = "ColumnPatientID";
            this.ColumnPatientID.Visible = false;
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
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 69;
            this.medScrollbar1.Location = new System.Drawing.Point(374, 1);
            this.medScrollbar1.Maximum = 69;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 368);
            this.medScrollbar1.SmallChange = 23;
            this.medScrollbar1.TabIndex = 0;
            this.medScrollbar1.ThisControl = this.dgPACUList;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.radioGroupStatus);
            this.panel3.Controls.Add(this.labelWInpacu);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.labelUnFinishedCount);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.labelOutPACU);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 36);
            this.panel3.TabIndex = 91;
            // 
            // radioGroupStatus
            // 
            this.radioGroupStatus.EditValue = "全部";
            this.radioGroupStatus.Location = new System.Drawing.Point(4, 3);
            this.radioGroupStatus.Name = "radioGroupStatus";
            this.radioGroupStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroupStatus.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.radioGroupStatus.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupStatus.Properties.Appearance.Options.UseFont = true;
            this.radioGroupStatus.Properties.Appearance.Options.UseForeColor = true;
            this.radioGroupStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("全部", "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("复苏前", "复苏前"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("复苏中", "复苏中"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("复苏后", "复苏后")});
            this.radioGroupStatus.Properties.LookAndFeel.SkinName = "Blue";
            this.radioGroupStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.radioGroupStatus.Size = new System.Drawing.Size(245, 30);
            this.radioGroupStatus.TabIndex = 96;
            this.radioGroupStatus.SelectedIndexChanged += new System.EventHandler(this.radioGroupStatus_SelectedIndexChanged);
            // 
            // labelWInpacu
            // 
            this.labelWInpacu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWInpacu.AutoSize = true;
            this.labelWInpacu.BackColor = System.Drawing.Color.Transparent;
            this.labelWInpacu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWInpacu.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelWInpacu.Location = new System.Drawing.Point(228, 8);
            this.labelWInpacu.Name = "labelWInpacu";
            this.labelWInpacu.Size = new System.Drawing.Size(15, 17);
            this.labelWInpacu.TabIndex = 123;
            this.labelWInpacu.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 97;
            this.label1.Text = "已出PACU:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(258, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 122;
            this.label3.Text = "人   复苏中手术";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(128, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 102;
            this.label6.Text = "人   等待入PACU:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(184)))), ((int)(((byte)(230)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 3);
            this.panel2.TabIndex = 120;
            // 
            // labelUnFinishedCount
            // 
            this.labelUnFinishedCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUnFinishedCount.AutoSize = true;
            this.labelUnFinishedCount.BackColor = System.Drawing.Color.Transparent;
            this.labelUnFinishedCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUnFinishedCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelUnFinishedCount.Location = new System.Drawing.Point(347, 9);
            this.labelUnFinishedCount.Name = "labelUnFinishedCount";
            this.labelUnFinishedCount.Size = new System.Drawing.Size(19, 17);
            this.labelUnFinishedCount.TabIndex = 104;
            this.labelUnFinishedCount.Text = " 0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(366, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 103;
            this.label2.Text = "台";
            // 
            // labelOutPACU
            // 
            this.labelOutPACU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOutPACU.AutoSize = true;
            this.labelOutPACU.BackColor = System.Drawing.Color.Transparent;
            this.labelOutPACU.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOutPACU.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelOutPACU.Location = new System.Drawing.Point(107, 9);
            this.labelOutPACU.Name = "labelOutPACU";
            this.labelOutPACU.Size = new System.Drawing.Size(15, 17);
            this.labelOutPACU.TabIndex = 97;
            this.labelOutPACU.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 36);
            this.panel1.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(127, 36);
            this.label4.TabIndex = 97;
            this.label4.Text = "PACU等待";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // operationRoomPandect1
            // 
            this.operationRoomPandect1.Appearance.BackColor = System.Drawing.Color.White;
            this.operationRoomPandect1.Appearance.Options.UseBackColor = true;
            this.operationRoomPandect1.AutoScroll = true;
            this.operationRoomPandect1.Caption = "";
            this.operationRoomPandect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationRoomPandect1.IsDirty = false;
            this.operationRoomPandect1.Location = new System.Drawing.Point(10, 0);
            this.operationRoomPandect1.Name = "operationRoomPandect1";
            this.operationRoomPandect1.Size = new System.Drawing.Size(1005, 442);
            this.operationRoomPandect1.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OPER_ROOM_NO";
            this.dataGridViewTextBoxColumn1.FillWeight = 82.78861F;
            this.dataGridViewTextBoxColumn1.HeaderText = "手术间";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 68;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "INP_NO";
            this.dataGridViewTextBoxColumn2.FillWeight = 82.78861F;
            this.dataGridViewTextBoxColumn2.HeaderText = "住院号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 68;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NAME";
            this.dataGridViewTextBoxColumn3.FillWeight = 82.78861F;
            this.dataGridViewTextBoxColumn3.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 68;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SEX";
            this.dataGridViewTextBoxColumn4.FillWeight = 82.78861F;
            this.dataGridViewTextBoxColumn4.HeaderText = "性别";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 58;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "AGE";
            this.dataGridViewTextBoxColumn5.FillWeight = 82.78861F;
            this.dataGridViewTextBoxColumn5.HeaderText = "年龄";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 58;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "OPERATION_NAME";
            this.dataGridViewTextBoxColumn6.FillWeight = 82.78861F;
            this.dataGridViewTextBoxColumn6.HeaderText = "手术名称";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "OPER_STATUS_CODE";
            this.dataGridViewTextBoxColumn7.HeaderText = "状态";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PATIENT_ID";
            this.dataGridViewTextBoxColumn8.HeaderText = "ColumnPatientID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "VISIT_ID";
            this.dataGridViewTextBoxColumn9.HeaderText = "ColumnVisitID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "OPER_ID";
            this.dataGridViewTextBoxColumn10.HeaderText = "ColumnOperID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // PatientListViewPACU
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "PatientListViewPACU";
            this.Size = new System.Drawing.Size(1426, 442);
            this.Load += new System.EventHandler(this.PatientListViewPACU_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPACUList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupStatus.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Document.Controls.MedScrollbar medScrollbar1;
        private FrameWork.PanelNoFlash pnlBody;
        private FrameWork.PanelNoFlash panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelUnFinishedCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelOutPACU;
        private FrameWork.PanelNoFlash panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgPACUList;
        private System.Windows.Forms.Label labelWInpacu;
        private System.Windows.Forms.Label label3;
        public OperationRoomPandect operationRoomPandect1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DevExpress.XtraEditors.RadioGroup radioGroupStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperStatus;
        private System.Windows.Forms.DataGridViewImageColumn ColAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOperID;
    }
}
