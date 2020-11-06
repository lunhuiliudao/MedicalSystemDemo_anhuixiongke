namespace MedicalSystem.Anes.Client.CustomProject
{
    partial class UserControl_BreathParas
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
            this.dateEdit1 = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode3 = new MedicalSystem.Anes.Document.Controls.MedTextBox();
            this.txtCode2 = new MedicalSystem.Anes.Document.Controls.MedTextBox();
            this.txtCode1 = new MedicalSystem.Anes.Document.Controls.MedTextBox();
            this.btnOK = new MedicalSystem.Anes.Document.Controls.MedButton();
            this.btnCancel = new MedicalSystem.Anes.Document.Controls.MedButton();
            this.BtnDele = new MedicalSystem.Anes.Document.Controls.MedButton();
            this.lblCode1 = new DevExpress.XtraEditors.LabelControl();
            this.lblCode2 = new DevExpress.XtraEditors.LabelControl();
            this.lblCode3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2011, 4, 13, 0, 0, 0, 0);
            this.dateEdit1.Location = new System.Drawing.Point(50, 27);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEdit1.Properties.Appearance.Options.UseFont = true;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "g";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.LookAndFeel.SkinName = "Blue";
            this.dateEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dateEdit1.Properties.Mask.EditMask = "g";
            this.dateEdit1.Size = new System.Drawing.Size(196, 23);
            this.dateEdit1.TabIndex = 64;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 17);
            this.labelControl1.TabIndex = 65;
            this.labelControl1.Text = "时间:";
            // 
            // txtCode3
            // 
            this.txtCode3.BindFieldName = "";
            this.txtCode3.BindList = "";
            this.txtCode3.BindTableName = "";
            this.txtCode3.BorderColor = System.Drawing.Color.LightGray;
            this.txtCode3.BottomLine = false;
            this.txtCode3.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtCode3.CanEdit = true;
            this.txtCode3.CelerityInputCodeColumnName = "ADMINISTRATION_NAME";
            this.txtCode3.CelerityInputSqlWhere = "";
            this.txtCode3.CelerityInputTableName = "MED_ADMINISTRATION_DICT";
            this.txtCode3.CelerityInputValueColumnName = "ADMINISTRATION_NAME";
            this.txtCode3.Data = null;
            this.txtCode3.DefaultPrintText = "";
            this.txtCode3.DictTableName = "MED_ADMINISTRATION_DICT";
            this.txtCode3.DictValueFieldName = "ADMINISTRATION_NAME";
            this.txtCode3.DictWhereString = "";
            this.txtCode3.DisplayFieldName = "ADMINISTRATION_NAME";
            this.txtCode3.DisplayMutiColFieldName = "";
            this.txtCode3.DotBorder = false;
            this.txtCode3.DotNumber = 0;
            this.txtCode3.ExamItemName = null;
            this.txtCode3.FieldName = "txtPath";
            this.txtCode3.Format = "";
            this.txtCode3.HasLookUpItems = false;
            this.txtCode3.InitValue = "";
            this.txtCode3.InputNeededMessage = "";
            this.txtCode3.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtCode3.LabItemName = null;
            this.txtCode3.LimitedString = "";
            this.txtCode3.Location = new System.Drawing.Point(50, 140);
            this.txtCode3.LockInput = false;
            this.txtCode3.Maximum = null;
            this.txtCode3.MaxLength = 20;
            this.txtCode3.Minimum = null;
            this.txtCode3.Multiline = false;
            this.txtCode3.MultiSelect = false;
            this.txtCode3.MultiSign = false;
            this.txtCode3.Name = "txtCode3";
            this.txtCode3.NoPrint = false;
            this.txtCode3.NoPrintText = "";
            this.txtCode3.NullAble = true;
            this.txtCode3.OldForeColor = System.Drawing.Color.Black;
            this.txtCode3.PasswordChar = '\0';
            this.txtCode3.PrintTail = "";
            this.txtCode3.PrintXOffSet = 0F;
            this.txtCode3.PrintYOffSet = 0F;
            this.txtCode3.ProgramChanging = false;
            this.txtCode3.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCode3.Properties.LookAndFeel.SkinName = "Blue";
            this.txtCode3.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCode3.Properties.MaxLength = 20;
            this.txtCode3.ReadOnly = false;
            this.txtCode3.SelfValue = "";
            this.txtCode3.SelfValueChanged = false;
            this.txtCode3.Size = new System.Drawing.Size(196, 21);
            this.txtCode3.SourceFieldName = "";
            this.txtCode3.SourceTableName = "";
            this.txtCode3.StoredValue = "";
            this.txtCode3.TabIndex = 66;
            this.txtCode3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCode3.UnderLineOffset = 0F;
            this.txtCode3.WantValueBeforePrint = "";
            this.txtCode3.WordWrap = false;
            // 
            // txtCode2
            // 
            this.txtCode2.BindFieldName = "";
            this.txtCode2.BindList = "";
            this.txtCode2.BindTableName = "";
            this.txtCode2.BorderColor = System.Drawing.Color.LightGray;
            this.txtCode2.BottomLine = false;
            this.txtCode2.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtCode2.CanEdit = true;
            this.txtCode2.CelerityInputCodeColumnName = "ADMINISTRATION_NAME";
            this.txtCode2.CelerityInputSqlWhere = "";
            this.txtCode2.CelerityInputTableName = "MED_ADMINISTRATION_DICT";
            this.txtCode2.CelerityInputValueColumnName = "ADMINISTRATION_NAME";
            this.txtCode2.Data = null;
            this.txtCode2.DefaultPrintText = "";
            this.txtCode2.DictTableName = "MED_ADMINISTRATION_DICT";
            this.txtCode2.DictValueFieldName = "ADMINISTRATION_NAME";
            this.txtCode2.DictWhereString = "";
            this.txtCode2.DisplayFieldName = "ADMINISTRATION_NAME";
            this.txtCode2.DisplayMutiColFieldName = "";
            this.txtCode2.DotBorder = false;
            this.txtCode2.DotNumber = 0;
            this.txtCode2.ExamItemName = null;
            this.txtCode2.FieldName = "txtPath";
            this.txtCode2.Format = "";
            this.txtCode2.HasLookUpItems = false;
            this.txtCode2.InitValue = "";
            this.txtCode2.InputNeededMessage = "";
            this.txtCode2.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtCode2.LabItemName = null;
            this.txtCode2.LimitedString = "";
            this.txtCode2.Location = new System.Drawing.Point(50, 103);
            this.txtCode2.LockInput = false;
            this.txtCode2.Maximum = null;
            this.txtCode2.MaxLength = 20;
            this.txtCode2.Minimum = null;
            this.txtCode2.Multiline = false;
            this.txtCode2.MultiSelect = false;
            this.txtCode2.MultiSign = false;
            this.txtCode2.Name = "txtCode2";
            this.txtCode2.NoPrint = false;
            this.txtCode2.NoPrintText = "";
            this.txtCode2.NullAble = true;
            this.txtCode2.OldForeColor = System.Drawing.Color.Black;
            this.txtCode2.PasswordChar = '\0';
            this.txtCode2.PrintTail = "";
            this.txtCode2.PrintXOffSet = 0F;
            this.txtCode2.PrintYOffSet = 0F;
            this.txtCode2.ProgramChanging = false;
            this.txtCode2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCode2.Properties.LookAndFeel.SkinName = "Blue";
            this.txtCode2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCode2.Properties.MaxLength = 20;
            this.txtCode2.ReadOnly = false;
            this.txtCode2.SelfValue = "";
            this.txtCode2.SelfValueChanged = false;
            this.txtCode2.Size = new System.Drawing.Size(196, 21);
            this.txtCode2.SourceFieldName = "";
            this.txtCode2.SourceTableName = "";
            this.txtCode2.StoredValue = "";
            this.txtCode2.TabIndex = 67;
            this.txtCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCode2.UnderLineOffset = 0F;
            this.txtCode2.WantValueBeforePrint = "";
            this.txtCode2.WordWrap = false;
            // 
            // txtCode1
            // 
            this.txtCode1.BindFieldName = "";
            this.txtCode1.BindList = "";
            this.txtCode1.BindTableName = "";
            this.txtCode1.BorderColor = System.Drawing.Color.LightGray;
            this.txtCode1.BottomLine = false;
            this.txtCode1.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtCode1.CanEdit = true;
            this.txtCode1.CelerityInputCodeColumnName = "ADMINISTRATION_NAME";
            this.txtCode1.CelerityInputSqlWhere = "";
            this.txtCode1.CelerityInputTableName = "MED_ADMINISTRATION_DICT";
            this.txtCode1.CelerityInputValueColumnName = "ADMINISTRATION_NAME";
            this.txtCode1.Data = null;
            this.txtCode1.DefaultPrintText = "";
            this.txtCode1.DictTableName = "MED_ADMINISTRATION_DICT";
            this.txtCode1.DictValueFieldName = "ADMINISTRATION_NAME";
            this.txtCode1.DictWhereString = "";
            this.txtCode1.DisplayFieldName = "ADMINISTRATION_NAME";
            this.txtCode1.DisplayMutiColFieldName = "";
            this.txtCode1.DotBorder = false;
            this.txtCode1.DotNumber = 0;
            this.txtCode1.ExamItemName = null;
            this.txtCode1.FieldName = "txtPath";
            this.txtCode1.Format = "";
            this.txtCode1.HasLookUpItems = false;
            this.txtCode1.InitValue = "";
            this.txtCode1.InputNeededMessage = "";
            this.txtCode1.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtCode1.LabItemName = null;
            this.txtCode1.LimitedString = "";
            this.txtCode1.Location = new System.Drawing.Point(50, 67);
            this.txtCode1.LockInput = false;
            this.txtCode1.Maximum = null;
            this.txtCode1.MaxLength = 20;
            this.txtCode1.Minimum = null;
            this.txtCode1.Multiline = false;
            this.txtCode1.MultiSelect = false;
            this.txtCode1.MultiSign = false;
            this.txtCode1.Name = "txtCode1";
            this.txtCode1.NoPrint = false;
            this.txtCode1.NoPrintText = "";
            this.txtCode1.NullAble = true;
            this.txtCode1.OldForeColor = System.Drawing.Color.Black;
            this.txtCode1.PasswordChar = '\0';
            this.txtCode1.PrintTail = "";
            this.txtCode1.PrintXOffSet = 0F;
            this.txtCode1.PrintYOffSet = 0F;
            this.txtCode1.ProgramChanging = false;
            this.txtCode1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCode1.Properties.LookAndFeel.SkinName = "Blue";
            this.txtCode1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCode1.Properties.MaxLength = 20;
            this.txtCode1.ReadOnly = false;
            this.txtCode1.SelfValue = "";
            this.txtCode1.SelfValueChanged = false;
            this.txtCode1.Size = new System.Drawing.Size(196, 21);
            this.txtCode1.SourceFieldName = "";
            this.txtCode1.SourceTableName = "";
            this.txtCode1.StoredValue = "";
            this.txtCode1.TabIndex = 68;
            this.txtCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCode1.UnderLineOffset = 0F;
            this.txtCode1.WantValueBeforePrint = "";
            this.txtCode1.WordWrap = false;
            this.txtCode1.EditValueChanged += new System.EventHandler(this.txtCode1_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.ActionName = null;
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoImage = false;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.BindControl = null;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.HasBorder = false;
            this.btnOK.IsMenu = false;
            this.btnOK.IsMouseHover = true;
            this.btnOK.Location = new System.Drawing.Point(21, 181);
            this.btnOK.LookAndFeel.SkinName = "Blue";
            this.btnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOK.MenuIndex = 0;
            this.btnOK.Name = "btnOK";
            this.btnOK.PageName = null;
            this.btnOK.Parameters = null;
            this.btnOK.ShortcutKeys = null;
            this.btnOK.ShowText = true;
            this.btnOK.Size = new System.Drawing.Size(74, 23);
            this.btnOK.TabIndex = 69;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ActionName = null;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoImage = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.BindControl = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.HasBorder = false;
            this.btnCancel.IsMenu = false;
            this.btnCancel.IsMouseHover = true;
            this.btnCancel.Location = new System.Drawing.Point(111, 181);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(74, 23);
            this.btnCancel.TabIndex = 70;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnDele
            // 
            this.BtnDele.ActionName = null;
            this.BtnDele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDele.AutoImage = false;
            this.BtnDele.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnDele.BindControl = null;
            this.BtnDele.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnDele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDele.HasBorder = false;
            this.BtnDele.IsMenu = false;
            this.BtnDele.IsMouseHover = true;
            this.BtnDele.Location = new System.Drawing.Point(200, 181);
            this.BtnDele.LookAndFeel.SkinName = "Blue";
            this.BtnDele.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnDele.MenuIndex = 0;
            this.BtnDele.Name = "BtnDele";
            this.BtnDele.PageName = null;
            this.BtnDele.Parameters = null;
            this.BtnDele.ShortcutKeys = null;
            this.BtnDele.ShowText = true;
            this.BtnDele.Size = new System.Drawing.Size(74, 23);
            this.BtnDele.TabIndex = 71;
            this.BtnDele.Text = "删除";
            this.BtnDele.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnDele.UseVisualStyleBackColor = true;
            this.BtnDele.Click += new System.EventHandler(this.BtnDele_Click);
            // 
            // lblCode1
            // 
            this.lblCode1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode1.Appearance.Options.UseFont = true;
            this.lblCode1.Location = new System.Drawing.Point(11, 70);
            this.lblCode1.Name = "lblCode1";
            this.lblCode1.Size = new System.Drawing.Size(0, 17);
            this.lblCode1.TabIndex = 72;
            // 
            // lblCode2
            // 
            this.lblCode2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode2.Appearance.Options.UseFont = true;
            this.lblCode2.Location = new System.Drawing.Point(11, 107);
            this.lblCode2.Name = "lblCode2";
            this.lblCode2.Size = new System.Drawing.Size(0, 17);
            this.lblCode2.TabIndex = 73;
            // 
            // lblCode3
            // 
            this.lblCode3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode3.Appearance.Options.UseFont = true;
            this.lblCode3.Location = new System.Drawing.Point(11, 141);
            this.lblCode3.Name = "lblCode3";
            this.lblCode3.Size = new System.Drawing.Size(0, 17);
            this.lblCode3.TabIndex = 74;
            // 
            // UserControl_BreathParas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblCode3);
            this.Controls.Add(this.lblCode2);
            this.Controls.Add(this.lblCode1);
            this.Controls.Add(this.BtnDele);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCode1);
            this.Controls.Add(this.txtCode2);
            this.Controls.Add(this.txtCode3);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.labelControl1);
            this.Name = "UserControl_BreathParas";
            this.Size = new System.Drawing.Size(288, 216);
            this.Load += new System.EventHandler(this.UserControl_BreathParas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Document.Controls.MedTextBox txtCode3;
        private Document.Controls.MedTextBox txtCode2;
        private Document.Controls.MedTextBox txtCode1;
        private Document.Controls.MedButton btnOK;
        private Document.Controls.MedButton btnCancel;
        private Document.Controls.MedButton BtnDele;
        private DevExpress.XtraEditors.LabelControl lblCode1;
        private DevExpress.XtraEditors.LabelControl lblCode2;
        private DevExpress.XtraEditors.LabelControl lblCode3;
    }
}
