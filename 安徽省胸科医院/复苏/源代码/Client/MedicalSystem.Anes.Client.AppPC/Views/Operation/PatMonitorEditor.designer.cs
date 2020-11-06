namespace MedicalSystem.Anes.Client.AppPC
{
    partial class PatMonitorEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatMonitorEditor));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgMonitorEditorView = new System.Windows.Forms.DataGridView();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Label();
            this.btnInsertColumns = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Label();
            this.btnDeleteItem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            ((System.ComponentModel.ISupportInitialize)(this.dgMonitorEditorView)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgMonitorEditorView
            // 
            this.dgMonitorEditorView.AllowDrop = true;
            this.dgMonitorEditorView.AllowUserToAddRows = false;
            this.dgMonitorEditorView.AllowUserToDeleteRows = false;
            this.dgMonitorEditorView.AllowUserToResizeColumns = false;
            this.dgMonitorEditorView.AllowUserToResizeRows = false;
            this.dgMonitorEditorView.BackgroundColor = System.Drawing.Color.White;
            this.dgMonitorEditorView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgMonitorEditorView.ColumnHeadersHeight = 50;
            this.dgMonitorEditorView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMonitorEditorView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgMonitorEditorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMonitorEditorView.EnableHeadersVisualStyles = false;
            this.dgMonitorEditorView.Location = new System.Drawing.Point(1, 1);
            this.dgMonitorEditorView.Margin = new System.Windows.Forms.Padding(4);
            this.dgMonitorEditorView.Name = "dgMonitorEditorView";
            this.dgMonitorEditorView.RowHeadersVisible = false;
            this.dgMonitorEditorView.RowHeadersWidth = 15;
            this.dgMonitorEditorView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgMonitorEditorView.RowTemplate.Height = 30;
            this.dgMonitorEditorView.Size = new System.Drawing.Size(705, 377);
            this.dgMonitorEditorView.TabIndex = 30;
            this.dgMonitorEditorView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgMonitorEditorView_CellBeginEdit);
            this.dgMonitorEditorView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMonitorEditorView_CellClick);
            this.dgMonitorEditorView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgMonitorEditorView_CellFormatting);
            this.dgMonitorEditorView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgMonitorEditorView_CellPainting);
            this.dgMonitorEditorView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgMonitorEditorView_CellValidating);
            this.dgMonitorEditorView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMonitorEditorView_CellValueChanged);
            this.dgMonitorEditorView.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgMonitorEditorView_CurrentCellDirtyStateChanged);
            this.dgMonitorEditorView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgMonitorEditorView_DataBindingComplete);
            this.dgMonitorEditorView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgMonitorEditorView_EditingControlShowing);
            this.dgMonitorEditorView.SelectionChanged += new System.EventHandler(this.dgMonitorEditorView_SelectionChanged);
            this.dgMonitorEditorView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgMonitorEditorView_KeyDown);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlTitle.Controls.Add(this.btnRefresh);
            this.pnlTitle.Controls.Add(this.btnSave);
            this.pnlTitle.Controls.Add(this.btnInsertColumns);
            this.pnlTitle.Controls.Add(this.btnDelete);
            this.pnlTitle.Controls.Add(this.btnAddItem);
            this.pnlTitle.Controls.Add(this.btnDeleteItem);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Controls.Add(this.panel2);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(707, 38);
            this.pnlTitle.TabIndex = 36;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(203, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 35);
            this.btnRefresh.TabIndex = 51;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(287, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 35);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "保存";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsertColumns
            // 
            this.btnInsertColumns.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnInsertColumns.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnInsertColumns.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertColumns.Image")));
            this.btnInsertColumns.Location = new System.Drawing.Point(371, 3);
            this.btnInsertColumns.Name = "btnInsertColumns";
            this.btnInsertColumns.Size = new System.Drawing.Size(84, 35);
            this.btnInsertColumns.TabIndex = 51;
            this.btnInsertColumns.Text = "    插入数据";
            this.btnInsertColumns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInsertColumns.Click += new System.EventHandler(this.btnInsertColumns_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(455, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 35);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Location = new System.Drawing.Point(539, 3);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(84, 35);
            this.btnAddItem.TabIndex = 51;
            this.btnAddItem.Text = "    增加项目";
            this.btnAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.Image")));
            this.btnDeleteItem.Location = new System.Drawing.Point(623, 3);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(84, 35);
            this.btnDeleteItem.TabIndex = 51;
            this.btnDeleteItem.Text = "    删除项目";
            this.btnDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(-2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 14);
            this.label1.TabIndex = 44;
            this.label1.Text = "要删除某时间点，必须选中整列!";
            this.label1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(184)))), ((int)(((byte)(230)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 3);
            this.panel2.TabIndex = 125;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.medScrollbar1);
            this.pnlBody.Controls.Add(this.dgMonitorEditorView);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 38);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBody.Size = new System.Drawing.Size(707, 379);
            this.pnlBody.TabIndex = 36;
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 10;
            this.medScrollbar1.Location = new System.Drawing.Point(690, 2);
            this.medScrollbar1.Maximum = 100;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 375);
            this.medScrollbar1.SmallChange = 1;
            this.medScrollbar1.TabIndex = 31;
            this.medScrollbar1.ThisControl = this.dgMonitorEditorView;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // PatMonitorEditor
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PatMonitorEditor";
            this.Size = new System.Drawing.Size(707, 417);
            ((System.ComponentModel.ISupportInitialize)(this.dgMonitorEditorView)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgMonitorEditorView;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnDeleteItem;
        private System.Windows.Forms.Label btnInsertColumns;
        private System.Windows.Forms.Label btnAddItem;
        private System.Windows.Forms.Label btnDelete;
        private System.Windows.Forms.Label btnRefresh;
        private System.Windows.Forms.Label btnSave;
        private System.Windows.Forms.Panel panel2;
        private Document.Controls.MedScrollbar medScrollbar1;
    }
}
