namespace MedicalSystem.Anes.Client.AppPC
{
    partial class UserMsgListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgControlMAIL = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MESSAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.check = new DevExpress.XtraEditors.CheckEdit();
            this.labelControlTip = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.btnCannel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            ((System.ComponentModel.ISupportInitialize)(this.dgControlMAIL)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgControlMAIL
            // 
            this.dgControlMAIL.AllowUserToAddRows = false;
            this.dgControlMAIL.AllowUserToDeleteRows = false;
            this.dgControlMAIL.AllowUserToResizeColumns = false;
            this.dgControlMAIL.AllowUserToResizeRows = false;
            this.dgControlMAIL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgControlMAIL.BackgroundColor = System.Drawing.Color.White;
            this.dgControlMAIL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgControlMAIL.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(138)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgControlMAIL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgControlMAIL.ColumnHeadersHeight = 36;
            this.dgControlMAIL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgControlMAIL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.MESSAGE,
            this.Column3,
            this.Column4});
            this.dgControlMAIL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgControlMAIL.EnableHeadersVisualStyles = false;
            this.dgControlMAIL.Location = new System.Drawing.Point(0, 0);
            this.dgControlMAIL.MultiSelect = false;
            this.dgControlMAIL.Name = "dgControlMAIL";
            this.dgControlMAIL.RowHeadersVisible = false;
            this.dgControlMAIL.RowHeadersWidth = 22;
            this.dgControlMAIL.RowTemplate.Height = 23;
            this.dgControlMAIL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgControlMAIL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgControlMAIL.Size = new System.Drawing.Size(663, 366);
            this.dgControlMAIL.TabIndex = 95;
            this.dgControlMAIL.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgControlMAIL_CurrentCellDirtyStateChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "SEND_TIME";
            this.Column1.HeaderText = "接收时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // MESSAGE
            // 
            this.MESSAGE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MESSAGE.DataPropertyName = "MESSAGE";
            this.MESSAGE.HeaderText = "消息内容";
            this.MESSAGE.Name = "MESSAGE";
            this.MESSAGE.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "SEND_USER_NAME";
            this.Column3.HeaderText = "发送人";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.DataPropertyName = "ISCHECKED";
            this.Column4.HeaderText = "已读标志";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.check);
            this.panel1.Controls.Add(this.labelControlTip);
            this.panel1.Controls.Add(this.dateEditStart);
            this.panel1.Controls.Add(this.btnCannel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 49);
            this.panel1.TabIndex = 96;
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(3, 13);
            this.check.Name = "check";
            this.check.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.check.Properties.Appearance.Options.UseFont = true;
            this.check.Properties.Caption = "显示已读信息";
            this.check.Properties.LookAndFeel.SkinName = "Blue";
            this.check.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.check.Size = new System.Drawing.Size(167, 22);
            this.check.TabIndex = 88;
            this.check.CheckedChanged += new System.EventHandler(this.radioButtonCheck_CheckedChanged);
            // 
            // labelControlTip
            // 
            this.labelControlTip.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlTip.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControlTip.Appearance.Options.UseFont = true;
            this.labelControlTip.Appearance.Options.UseForeColor = true;
            this.labelControlTip.Location = new System.Drawing.Point(176, 15);
            this.labelControlTip.Name = "labelControlTip";
            this.labelControlTip.Size = new System.Drawing.Size(26, 14);
            this.labelControlTip.TabIndex = 87;
            this.labelControlTip.Text = "日期";
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(216, 12);
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
            this.dateEditStart.Size = new System.Drawing.Size(133, 21);
            this.dateEditStart.TabIndex = 86;
            this.dateEditStart.EditValueChanged += new System.EventHandler(this.dateEditStart_EditValueChanged);
            // 
            // btnCannel
            // 
            this.btnCannel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.灰色;
            this.btnCannel.Location = new System.Drawing.Point(546, 6);
            this.btnCannel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(102, 34);
            this.btnCannel.TabIndex = 85;
            this.btnCannel.Title = "关闭";
            this.btnCannel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCannel_BtnClicked);
            // 
            // UserMsgListView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.dgControlMAIL);
            this.Controls.Add(this.panel1);
            this.Name = "UserMsgListView";
            this.Size = new System.Drawing.Size(663, 415);
            this.Load += new System.EventHandler(this.UserMsgListView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgControlMAIL)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgControlMAIL;
        private System.Windows.Forms.Panel panel1;
        private FrameWork.ButtonColor btnCannel;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.LabelControl labelControlTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MESSAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private DevExpress.XtraEditors.CheckEdit check;

    }
}