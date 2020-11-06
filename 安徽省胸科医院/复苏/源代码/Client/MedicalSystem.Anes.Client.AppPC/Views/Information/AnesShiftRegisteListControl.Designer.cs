namespace MedicalSystem.Anes.Client.AppPC
{
    partial class AnesShiftRegisteListControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgControlShitRegister = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPERSON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDuty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonColor1 = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnCannel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControlTip = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgControlShitRegister)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgControlShitRegister
            // 
            this.dgControlShitRegister.AllowUserToAddRows = false;
            this.dgControlShitRegister.AllowUserToDeleteRows = false;
            this.dgControlShitRegister.AllowUserToResizeColumns = false;
            this.dgControlShitRegister.AllowUserToResizeRows = false;
            this.dgControlShitRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgControlShitRegister.BackgroundColor = System.Drawing.Color.White;
            this.dgControlShitRegister.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(138)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgControlShitRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgControlShitRegister.ColumnHeadersHeight = 36;
            this.dgControlShitRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgControlShitRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ColumnPERSON,
            this.Column4,
            this.ColumnDuty,
            this.Column2});
            this.dgControlShitRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgControlShitRegister.EnableHeadersVisualStyles = false;
            this.dgControlShitRegister.Location = new System.Drawing.Point(0, 43);
            this.dgControlShitRegister.MultiSelect = false;
            this.dgControlShitRegister.Name = "dgControlShitRegister";
            this.dgControlShitRegister.RowHeadersVisible = false;
            this.dgControlShitRegister.RowHeadersWidth = 22;
            this.dgControlShitRegister.RowTemplate.Height = 23;
            this.dgControlShitRegister.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgControlShitRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgControlShitRegister.Size = new System.Drawing.Size(638, 443);
            this.dgControlShitRegister.TabIndex = 97;
            this.dgControlShitRegister.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgControlShitRegister_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "DUTY_NAME";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "角色";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // ColumnPERSON
            // 
            this.ColumnPERSON.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPERSON.DataPropertyName = "DUTY_OFFICER";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnPERSON.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnPERSON.HeaderText = "当班人员";
            this.ColumnPERSON.Name = "ColumnPERSON";
            this.ColumnPERSON.ReadOnly = true;
            this.ColumnPERSON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "START_TIME";
            this.Column4.HeaderText = "开始时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // ColumnDuty
            // 
            this.ColumnDuty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDuty.DataPropertyName = "SUCCESSION_OFFICER";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnDuty.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnDuty.HeaderText = "接班人员";
            this.ColumnDuty.Name = "ColumnDuty";
            this.ColumnDuty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "SUCCESSION_ID";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonColor1);
            this.panel1.Controls.Add(this.btnCannel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 49);
            this.panel1.TabIndex = 98;
            // 
            // buttonColor1
            // 
            this.buttonColor1.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.灰色;
            this.buttonColor1.Location = new System.Drawing.Point(492, 9);
            this.buttonColor1.MaximumSize = new System.Drawing.Size(102, 34);
            this.buttonColor1.MinimumSize = new System.Drawing.Size(102, 34);
            this.buttonColor1.Name = "buttonColor1";
            this.buttonColor1.Size = new System.Drawing.Size(102, 34);
            this.buttonColor1.TabIndex = 86;
            this.buttonColor1.Title = "关闭";
            this.buttonColor1.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.buttonColor1_BtnClicked);
            // 
            // btnCannel
            // 
            this.btnCannel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCannel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.灰色;
            this.btnCannel.Location = new System.Drawing.Point(369, 9);
            this.btnCannel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(102, 34);
            this.btnCannel.TabIndex = 85;
            this.btnCannel.Title = "确认";
            this.btnCannel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCannel_BtnClicked);
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(100, 13);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.DisplayFormat.FormatString = "MM-dd HH:mm";
            this.dateEditStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStart.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateEditStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStart.Properties.LookAndFeel.SkinName = "Blue";
            this.dateEditStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dateEditStart.Properties.Mask.EditMask = "MM-dd HH:mm";
            this.dateEditStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditStart.Size = new System.Drawing.Size(191, 21);
            this.dateEditStart.TabIndex = 86;
            // 
            // labelControlTip
            // 
            this.labelControlTip.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlTip.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControlTip.Appearance.Options.UseFont = true;
            this.labelControlTip.Appearance.Options.UseForeColor = true;
            this.labelControlTip.Location = new System.Drawing.Point(26, 16);
            this.labelControlTip.Name = "labelControlTip";
            this.labelControlTip.Size = new System.Drawing.Size(52, 14);
            this.labelControlTip.TabIndex = 87;
            this.labelControlTip.Text = "交班时间";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateEditStart);
            this.panel2.Controls.Add(this.labelControlTip);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 43);
            this.panel2.TabIndex = 99;
            // 
            // AnesShiftRegisteListControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgControlShitRegister);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AnesShiftRegisteListControl";
            this.Size = new System.Drawing.Size(638, 535);
            this.Load += new System.EventHandler(this.AnesShiftRegisteListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgControlShitRegister)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgControlShitRegister;
        private System.Windows.Forms.Panel panel1;
        private FrameWork.ButtonColor buttonColor1;
        private FrameWork.ButtonColor btnCannel;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.LabelControl labelControlTip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPERSON;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDuty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
