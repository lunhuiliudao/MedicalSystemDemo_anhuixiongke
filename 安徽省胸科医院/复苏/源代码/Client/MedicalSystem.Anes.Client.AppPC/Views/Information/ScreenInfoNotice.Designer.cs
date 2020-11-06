namespace MedicalSystem.Anes.Client.AppPC
{
    partial class ScreenInfoNotice
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMsg = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numUDNoticeTime = new System.Windows.Forms.NumericUpDown();
            this.lbMsgHeader = new System.Windows.Forms.Label();
            this.chkPreMsg = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCannel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnNext = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.lbMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoticeContext = new MedicalSystem.Anes.Client.AppPC.DictTextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNoticeTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticeContext.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "（支持字典双击下拉）";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMsg);
            this.groupBox2.Location = new System.Drawing.Point(28, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 208);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "公告队列";
            // 
            // dgvMsg
            // 
            this.dgvMsg.BackgroundColor = System.Drawing.Color.White;
            this.dgvMsg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMsg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.dgvMsg.Location = new System.Drawing.Point(7, 23);
            this.dgvMsg.Name = "dgvMsg";
            this.dgvMsg.RowHeadersVisible = false;
            this.dgvMsg.RowTemplate.Height = 23;
            this.dgvMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMsg.Size = new System.Drawing.Size(712, 177);
            this.dgvMsg.TabIndex = 11;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "INSERT_TIME";
            this.Column1.HeaderText = "添加时间";
            this.Column1.MinimumWidth = 80;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "COUNTS";
            this.Column3.HeaderText = "次数";
            this.Column3.MinimumWidth = 40;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 40;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "MSG";
            this.Column2.HeaderText = "公告内容";
            this.Column2.MinimumWidth = 120;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // numUDNoticeTime
            // 
            this.numUDNoticeTime.Location = new System.Drawing.Point(94, 55);
            this.numUDNoticeTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDNoticeTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDNoticeTime.Name = "numUDNoticeTime";
            this.numUDNoticeTime.Size = new System.Drawing.Size(54, 22);
            this.numUDNoticeTime.TabIndex = 20;
            this.numUDNoticeTime.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lbMsgHeader
            // 
            this.lbMsgHeader.AutoSize = true;
            this.lbMsgHeader.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsgHeader.Location = new System.Drawing.Point(323, 59);
            this.lbMsgHeader.Name = "lbMsgHeader";
            this.lbMsgHeader.Size = new System.Drawing.Size(118, 12);
            this.lbMsgHeader.TabIndex = 18;
            this.lbMsgHeader.Text = "XX手术室XXX的家属";
            // 
            // chkPreMsg
            // 
            this.chkPreMsg.AutoSize = true;
            this.chkPreMsg.Checked = true;
            this.chkPreMsg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreMsg.Location = new System.Drawing.Point(190, 57);
            this.chkPreMsg.Name = "chkPreMsg";
            this.chkPreMsg.Size = new System.Drawing.Size(110, 18);
            this.chkPreMsg.TabIndex = 17;
            this.chkPreMsg.Text = "自动附加消息头";
            this.chkPreMsg.UseVisualStyleBackColor = true;
            this.chkPreMsg.CheckedChanged += new System.EventHandler(this.chkPreMsg_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCannel);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.lbMsg);
            this.groupBox1.Location = new System.Drawing.Point(28, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 85);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消息预览";
            // 
            // btnCannel
            // 
            this.btnCannel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnCannel.Location = new System.Drawing.Point(613, 45);
            this.btnCannel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(102, 34);
            this.btnCannel.TabIndex = 88;
            this.btnCannel.Title = "刷新";
            this.btnCannel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnNext.Location = new System.Drawing.Point(496, 45);
            this.btnNext.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnNext.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(102, 34);
            this.btnNext.TabIndex = 87;
            this.btnNext.Title = "保存";
            this.btnNext.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnSave_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lbMsg.Location = new System.Drawing.Point(12, 28);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(137, 14);
            this.lbMsg.TabIndex = 0;
            this.lbMsg.Text = "XX手术室XXX的家属";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "公告内容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "公告次数";
            // 
            // txtNoticeContext
            // 
            this.txtNoticeContext.BindFieldName = "";
            this.txtNoticeContext.BindList = "";
            this.txtNoticeContext.BindTableName = "";
            this.txtNoticeContext.BorderColor = System.Drawing.Color.LightGray;
            this.txtNoticeContext.BottomLine = false;
            this.txtNoticeContext.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtNoticeContext.CanEdit = true;
            this.txtNoticeContext.CelerityInputCodeColumnName = "ITEM_NAME";
            this.txtNoticeContext.CelerityInputSqlWhere = "ITEM_CLASS = \'家属公告信息\'";
            this.txtNoticeContext.CelerityInputTableName = "MED_ANESTHESIA_INPUT_DICT";
            this.txtNoticeContext.CelerityInputValueColumnName = "ITEM_CODE";
            this.txtNoticeContext.Data = null;
            this.txtNoticeContext.DefaultPrintText = "";
            this.txtNoticeContext.DictTableName = "MED_ANESTHESIA_INPUT_DICT";
            this.txtNoticeContext.DictValueFieldName = "ITEM_CODE";
            this.txtNoticeContext.DictWhereString = "ITEM_CLASS = \'家属公告信息\'";
            this.txtNoticeContext.DisplayFieldName = "ITEM_NAME";
            this.txtNoticeContext.DisplayMutiColFieldName = "";
            this.txtNoticeContext.DotBorder = false;
            this.txtNoticeContext.DotNumber = 0;
            this.txtNoticeContext.ExamItemName = null;
            this.txtNoticeContext.FieldName = "mTextBox1";
            this.txtNoticeContext.Format = "";
            this.txtNoticeContext.HasLookUpItems = false;
            this.txtNoticeContext.InitValue = "";
            this.txtNoticeContext.InputNeededMessage = "";
            this.txtNoticeContext.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtNoticeContext.LabItemName = null;
            this.txtNoticeContext.LimitedString = "";
            this.txtNoticeContext.Location = new System.Drawing.Point(87, 20);
            this.txtNoticeContext.LockInput = false;
            this.txtNoticeContext.Maximum = null;
            this.txtNoticeContext.MaxLength = 0;
            this.txtNoticeContext.Minimum = null;
            this.txtNoticeContext.Multiline = false;
            this.txtNoticeContext.MultiSelect = false;
            this.txtNoticeContext.MultiSign = false;
            this.txtNoticeContext.Name = "txtNoticeContext";
            this.txtNoticeContext.NoPrint = false;
            this.txtNoticeContext.NoPrintText = "";
            this.txtNoticeContext.NullAble = true;
            this.txtNoticeContext.OldForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNoticeContext.PasswordChar = '\0';
            this.txtNoticeContext.PrintTail = "";
            this.txtNoticeContext.PrintXOffSet = 0F;
            this.txtNoticeContext.PrintYOffSet = 0F;
            this.txtNoticeContext.ProgramChanging = false;
            this.txtNoticeContext.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoticeContext.Properties.Appearance.Options.UseFont = true;
            this.txtNoticeContext.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNoticeContext.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNoticeContext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtNoticeContext.Properties.LookAndFeel.SkinName = "Blue";
            this.txtNoticeContext.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtNoticeContext.ReadOnly = false;
            this.txtNoticeContext.SelfValue = "";
            this.txtNoticeContext.SelfValueChanged = false;
            this.txtNoticeContext.Size = new System.Drawing.Size(648, 23);
            this.txtNoticeContext.SourceFieldName = "";
            this.txtNoticeContext.SourceTableName = "";
            this.txtNoticeContext.StoredValue = "";
            this.txtNoticeContext.TabIndex = 24;
            this.txtNoticeContext.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNoticeContext.UnderLineOffset = 0F;
            this.txtNoticeContext.WantValueBeforePrint = "";
            this.txtNoticeContext.WordWrap = false;
            this.txtNoticeContext.EditValueChanged += new System.EventHandler(this.txtNoticeContext_TextChanged);
            // 
            // ScreenInfoNotice
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNoticeContext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.numUDNoticeTime);
            this.Controls.Add(this.lbMsgHeader);
            this.Controls.Add(this.chkPreMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ScreenInfoNotice";
            this.Size = new System.Drawing.Size(779, 432);
            this.Load += new System.EventHandler(this.ScreenInfoNotice_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNoticeTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticeContext.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.NumericUpDown numUDNoticeTime;
        private System.Windows.Forms.Label lbMsgHeader;
        private System.Windows.Forms.CheckBox chkPreMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FrameWork.ButtonColor btnCannel;
        private FrameWork.ButtonColor btnNext;
        private DictTextBox txtNoticeContext;
    }
}
