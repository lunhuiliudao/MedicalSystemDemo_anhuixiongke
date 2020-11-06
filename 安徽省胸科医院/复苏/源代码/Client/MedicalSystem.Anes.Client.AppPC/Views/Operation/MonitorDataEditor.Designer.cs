namespace MedicalSystem.Anes.Client.AppPC
{
    partial class MonitorDataEditor
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
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInterval = new MedicalSystem.Anes.Document.Controls.MedTextBox();
            this.btnOK = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnCancel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(316, 7);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit2.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit2.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(141, 21);
            this.dateEdit2.TabIndex = 47;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(99, 7);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit1.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(141, 21);
            this.dateEdit1.TabIndex = 46;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(17, 427);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 14);
            this.lblMessage.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 14);
            this.label4.TabIndex = 51;
            this.label4.Text = "秒";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 50;
            this.label3.Text = "时间间隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 49;
            this.label2.Text = "结束时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 48;
            this.label1.Text = "开始时间";
            // 
            // txtInterval
            // 
            this.txtInterval.BindFieldName = "";
            this.txtInterval.BindList = "";
            this.txtInterval.BindTableName = "";
            this.txtInterval.BorderColor = System.Drawing.Color.LightGray;
            this.txtInterval.BottomLine = false;
            this.txtInterval.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtInterval.CanEdit = true;
            this.txtInterval.CelerityInputCodeColumnName = "";
            this.txtInterval.CelerityInputSqlWhere = "";
            this.txtInterval.CelerityInputTableName = "";
            this.txtInterval.CelerityInputValueColumnName = "";
            this.txtInterval.Data = null;
            this.txtInterval.DefaultPrintText = "";
            this.txtInterval.DictTableName = "";
            this.txtInterval.DictValueFieldName = "";
            this.txtInterval.DictWhereString = "";
            this.txtInterval.DisplayFieldName = "";
            this.txtInterval.DisplayMutiColFieldName = "";
            this.txtInterval.DotBorder = false;
            this.txtInterval.DotNumber = 0;
            this.txtInterval.EditValue = "300";
            this.txtInterval.ExamItemName = null;
            this.txtInterval.FieldName = "txtInterval";
            this.txtInterval.Format = "";
            this.txtInterval.HasLookUpItems = false;
            this.txtInterval.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtInterval.InitValue = "";
            this.txtInterval.InputNeededMessage = "";
            this.txtInterval.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.Integer;
            this.txtInterval.LabItemName = null;
            this.txtInterval.LimitedString = "";
            this.txtInterval.Location = new System.Drawing.Point(99, 42);
            this.txtInterval.LockInput = false;
            this.txtInterval.Maximum = null;
            this.txtInterval.MaxLength = 0;
            this.txtInterval.Minimum = null;
            this.txtInterval.Multiline = false;
            this.txtInterval.MultiSelect = false;
            this.txtInterval.MultiSign = false;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.NoPrint = false;
            this.txtInterval.NoPrintText = "";
            this.txtInterval.NullAble = true;
            this.txtInterval.OldForeColor = System.Drawing.Color.Black;
            this.txtInterval.PasswordChar = '\0';
            this.txtInterval.PrintTail = "";
            this.txtInterval.PrintXOffSet = 0F;
            this.txtInterval.PrintYOffSet = 0F;
            this.txtInterval.ProgramChanging = false;
            this.txtInterval.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInterval.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtInterval.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtInterval.ReadOnly = false;
            this.txtInterval.SelfValue = "";
            this.txtInterval.SelfValueChanged = false;
            this.txtInterval.Size = new System.Drawing.Size(141, 21);
            this.txtInterval.SourceFieldName = "";
            this.txtInterval.SourceTableName = "";
            this.txtInterval.StoredValue = "";
            this.txtInterval.TabIndex = 55;
            this.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtInterval.UnderLineOffset = 0F;
            this.txtInterval.WantValueBeforePrint = "";
            this.txtInterval.WordWrap = false;
            // 
            // btnOK
            // 
            this.btnOK.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnOK.Location = new System.Drawing.Point(472, 407);
            this.btnOK.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnOK.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 34);
            this.btnOK.TabIndex = 87;
            this.btnOK.Title = "确认";
            this.btnOK.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnCancel.Location = new System.Drawing.Point(346, 407);
            this.btnCancel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCancel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 34);
            this.btnCancel.TabIndex = 86;
            this.btnCancel.Title = "取消";
            this.btnCancel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCancel_BtnClicked);
            // 
            // MonitorDataEditor
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MonitorDataEditor";
            this.Size = new System.Drawing.Size(589, 456);
            this.Load += new System.EventHandler(this.MonitorDataEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Document.Controls.MedTextBox txtInterval;
        private FrameWork.ButtonColor btnOK;
        private FrameWork.ButtonColor btnCancel;
    }
}
