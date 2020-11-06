namespace MedicalSystem.Anes.Client.CustomProject
{
    partial class EditEventItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkEndDate = new DevExpress.XtraEditors.CheckEdit();
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            this.timeEditStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEnd = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelMid = new System.Windows.Forms.Panel();
            this.txtDosageUnit = new MedicalSystem.Anes.Client.CustomProject.Views.DictTextBox();
            this.txtDosage = new MedicalSystem.Anes.Document.Controls.MedTextBox();
            this.txtSpeedUnit = new MedicalSystem.Anes.Client.CustomProject.Views.DictTextBox();
            this.txtSpeed = new MedicalSystem.Anes.Document.Controls.MedTextBox();
            this.txtPathUnit = new MedicalSystem.Anes.Client.CustomProject.Views.DictTextBox();
            this.txtDensity = new MedicalSystem.Anes.Client.CustomProject.Views.DictTextBox();
            this.txtPath = new MedicalSystem.Anes.Client.CustomProject.Views.DictTextBox();
            this.chkContinued = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelpath = new DevExpress.XtraEditors.LabelControl();
            this.labelDosage = new DevExpress.XtraEditors.LabelControl();
            this.labelSpeed = new DevExpress.XtraEditors.LabelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.chkDelete = new DevExpress.XtraEditors.CheckEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEnd.Properties)).BeginInit();
            this.panelMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosageUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeedUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDensity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkContinued.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDelete.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkEndDate);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.timeEditStart);
            this.panel1.Controls.Add(this.timeEditEnd);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 110);
            this.panel1.TabIndex = 0;
            // 
            // checkEndDate
            // 
            this.checkEndDate.Location = new System.Drawing.Point(7, 70);
            this.checkEndDate.Name = "checkEndDate";
            this.checkEndDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEndDate.Properties.Appearance.Options.UseFont = true;
            this.checkEndDate.Properties.Caption = " 结束时间:";
            this.checkEndDate.Properties.LookAndFeel.SkinName = "Blue";
            this.checkEndDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkEndDate.Size = new System.Drawing.Size(106, 22);
            this.checkEndDate.TabIndex = 59;
            this.checkEndDate.CheckedChanged += new System.EventHandler(this.checkEndDate_CheckedChanged);
            // 
            // labelName
            // 
            this.labelName.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelName.Appearance.Options.UseFont = true;
            this.labelName.Appearance.Options.UseForeColor = true;
            this.labelName.Location = new System.Drawing.Point(14, 10);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(30, 17);
            this.labelName.TabIndex = 62;
            this.labelName.Text = "名称";
            // 
            // timeEditStart
            // 
            this.timeEditStart.EditValue = new System.DateTime(2011, 4, 13, 0, 0, 0, 0);
            this.timeEditStart.Location = new System.Drawing.Point(141, 40);
            this.timeEditStart.Name = "timeEditStart";
            this.timeEditStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeEditStart.Properties.Appearance.Options.UseFont = true;
            this.timeEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditStart.Properties.DisplayFormat.FormatString = "g";
            this.timeEditStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditStart.Properties.LookAndFeel.SkinName = "Blue";
            this.timeEditStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.timeEditStart.Properties.Mask.EditMask = "g";
            this.timeEditStart.Properties.DoubleClick += new System.EventHandler(this.timeEditStart_Properties_DoubleClick);
            this.timeEditStart.Size = new System.Drawing.Size(196, 23);
            this.timeEditStart.TabIndex = 60;
            // 
            // timeEditEnd
            // 
            this.timeEditEnd.EditValue = new System.DateTime(2011, 4, 13, 0, 0, 0, 0);
            this.timeEditEnd.Enabled = false;
            this.timeEditEnd.Location = new System.Drawing.Point(141, 71);
            this.timeEditEnd.Name = "timeEditEnd";
            this.timeEditEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeEditEnd.Properties.Appearance.Options.UseFont = true;
            this.timeEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditEnd.Properties.DisplayFormat.FormatString = "g";
            this.timeEditEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEnd.Properties.LookAndFeel.SkinName = "Blue";
            this.timeEditEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.timeEditEnd.Properties.Mask.EditMask = "g";
            this.timeEditEnd.Properties.DoubleClick += new System.EventHandler(this.timeEditEnd_Properties_DoubleClick);
            this.timeEditEnd.Size = new System.Drawing.Size(196, 23);
            this.timeEditEnd.TabIndex = 61;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(34, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 17);
            this.labelControl1.TabIndex = 63;
            this.labelControl1.Text = "起始时间:";
            // 
            // panelMid
            // 
            this.panelMid.Controls.Add(this.txtDosageUnit);
            this.panelMid.Controls.Add(this.txtDosage);
            this.panelMid.Controls.Add(this.txtSpeedUnit);
            this.panelMid.Controls.Add(this.txtSpeed);
            this.panelMid.Controls.Add(this.txtPathUnit);
            this.panelMid.Controls.Add(this.txtDensity);
            this.panelMid.Controls.Add(this.txtPath);
            this.panelMid.Controls.Add(this.chkContinued);
            this.panelMid.Controls.Add(this.labelControl3);
            this.panelMid.Controls.Add(this.labelControl2);
            this.panelMid.Controls.Add(this.labelpath);
            this.panelMid.Controls.Add(this.labelDosage);
            this.panelMid.Controls.Add(this.labelSpeed);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMid.Location = new System.Drawing.Point(0, 110);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(355, 145);
            this.panelMid.TabIndex = 1;
            // 
            // txtDosageUnit
            // 
            this.txtDosageUnit.BindFieldName = "";
            this.txtDosageUnit.BindList = "";
            this.txtDosageUnit.BindTableName = "";
            this.txtDosageUnit.BorderColor = System.Drawing.Color.LightGray;
            this.txtDosageUnit.BottomLine = false;
            this.txtDosageUnit.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtDosageUnit.CanEdit = true;
            this.txtDosageUnit.CelerityInputCodeColumnName = "UNIT_NAME";
            this.txtDosageUnit.CelerityInputSqlWhere = "UNIT_TYPE=3";
            this.txtDosageUnit.CelerityInputTableName = "MED_UNIT_DICT";
            this.txtDosageUnit.CelerityInputValueColumnName = "UNIT_NAME";
            this.txtDosageUnit.Data = null;
            this.txtDosageUnit.DefaultPrintText = "";
            this.txtDosageUnit.DictTableName = "MED_UNIT_DICT";
            this.txtDosageUnit.DictValueFieldName = "UNIT_NAME";
            this.txtDosageUnit.DictWhereString = "UNIT_TYPE=3";
            this.txtDosageUnit.DisplayFieldName = "UNIT_NAME";
            this.txtDosageUnit.DisplayMutiColFieldName = "";
            this.txtDosageUnit.DotBorder = false;
            this.txtDosageUnit.DotNumber = 0;
            this.txtDosageUnit.ExamItemName = null;
            this.txtDosageUnit.FieldName = "txtPath";
            this.txtDosageUnit.Format = "";
            this.txtDosageUnit.HasLookUpItems = false;
            this.txtDosageUnit.InitValue = "";
            this.txtDosageUnit.InputNeededMessage = "";
            this.txtDosageUnit.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtDosageUnit.LabItemName = null;
            this.txtDosageUnit.LimitedString = "";
            this.txtDosageUnit.Location = new System.Drawing.Point(253, 111);
            this.txtDosageUnit.LockInput = false;
            this.txtDosageUnit.Maximum = null;
            this.txtDosageUnit.MaxLength = 20;
            this.txtDosageUnit.Minimum = null;
            this.txtDosageUnit.Multiline = false;
            this.txtDosageUnit.MultiSelect = false;
            this.txtDosageUnit.MultiSign = false;
            this.txtDosageUnit.Name = "txtDosageUnit";
            this.txtDosageUnit.NoPrint = false;
            this.txtDosageUnit.NoPrintText = "";
            this.txtDosageUnit.NullAble = true;
            this.txtDosageUnit.OldForeColor = System.Drawing.Color.Black;
            this.txtDosageUnit.PasswordChar = '\0';
            this.txtDosageUnit.PrintTail = "";
            this.txtDosageUnit.PrintXOffSet = 0F;
            this.txtDosageUnit.PrintYOffSet = 0F;
            this.txtDosageUnit.ProgramChanging = false;
            this.txtDosageUnit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDosageUnit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDosageUnit.Properties.LookAndFeel.SkinName = "Blue";
            this.txtDosageUnit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDosageUnit.Properties.MaxLength = 20;
            this.txtDosageUnit.ReadOnly = false;
            this.txtDosageUnit.SelfValue = "";
            this.txtDosageUnit.SelfValueChanged = false;
            this.txtDosageUnit.Size = new System.Drawing.Size(90, 21);
            this.txtDosageUnit.SourceFieldName = "";
            this.txtDosageUnit.SourceTableName = "";
            this.txtDosageUnit.StoredValue = "";
            this.txtDosageUnit.TabIndex = 71;
            this.txtDosageUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDosageUnit.UnderLineOffset = 0F;
            this.txtDosageUnit.WantValueBeforePrint = "";
            this.txtDosageUnit.WordWrap = false;
            // 
            // txtDosage
            // 
            this.txtDosage.BindFieldName = "";
            this.txtDosage.BindList = "";
            this.txtDosage.BindTableName = "";
            this.txtDosage.BorderColor = System.Drawing.Color.LightGray;
            this.txtDosage.BottomLine = false;
            this.txtDosage.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtDosage.CanEdit = true;
            this.txtDosage.CelerityInputCodeColumnName = "";
            this.txtDosage.CelerityInputSqlWhere = "";
            this.txtDosage.CelerityInputTableName = "";
            this.txtDosage.CelerityInputValueColumnName = "";
            this.txtDosage.Data = null;
            this.txtDosage.DefaultPrintText = "";
            this.txtDosage.DictTableName = "";
            this.txtDosage.DictValueFieldName = "";
            this.txtDosage.DictWhereString = "";
            this.txtDosage.DisplayFieldName = "";
            this.txtDosage.DisplayMutiColFieldName = "";
            this.txtDosage.DotBorder = false;
            this.txtDosage.DotNumber = 0;
            this.txtDosage.ExamItemName = null;
            this.txtDosage.FieldName = "txtPath";
            this.txtDosage.Format = "";
            this.txtDosage.HasLookUpItems = false;
            this.txtDosage.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDosage.InitValue = "";
            this.txtDosage.InputNeededMessage = "";
            this.txtDosage.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.Nurmeric;
            this.txtDosage.LabItemName = null;
            this.txtDosage.LimitedString = "";
            this.txtDosage.Location = new System.Drawing.Point(58, 112);
            this.txtDosage.LockInput = false;
            this.txtDosage.Maximum = null;
            this.txtDosage.MaxLength = 20;
            this.txtDosage.Minimum = null;
            this.txtDosage.Multiline = false;
            this.txtDosage.MultiSelect = false;
            this.txtDosage.MultiSign = false;
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.NoPrint = false;
            this.txtDosage.NoPrintText = "";
            this.txtDosage.NullAble = true;
            this.txtDosage.OldForeColor = System.Drawing.Color.Black;
            this.txtDosage.PasswordChar = '\0';
            this.txtDosage.PrintTail = "";
            this.txtDosage.PrintXOffSet = 0F;
            this.txtDosage.PrintYOffSet = 0F;
            this.txtDosage.ProgramChanging = false;
            this.txtDosage.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDosage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDosage.Properties.LookAndFeel.SkinName = "Blue";
            this.txtDosage.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDosage.Properties.MaxLength = 20;
            this.txtDosage.ReadOnly = false;
            this.txtDosage.SelfValue = "";
            this.txtDosage.SelfValueChanged = false;
            this.txtDosage.Size = new System.Drawing.Size(90, 21);
            this.txtDosage.SourceFieldName = "";
            this.txtDosage.SourceTableName = "";
            this.txtDosage.StoredValue = "";
            this.txtDosage.TabIndex = 70;
            this.txtDosage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDosage.UnderLineOffset = 0F;
            this.txtDosage.WantValueBeforePrint = "";
            this.txtDosage.WordWrap = false;
            // 
            // txtSpeedUnit
            // 
            this.txtSpeedUnit.BindFieldName = "";
            this.txtSpeedUnit.BindList = "";
            this.txtSpeedUnit.BindTableName = "";
            this.txtSpeedUnit.BorderColor = System.Drawing.Color.LightGray;
            this.txtSpeedUnit.BottomLine = false;
            this.txtSpeedUnit.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtSpeedUnit.CanEdit = true;
            this.txtSpeedUnit.CelerityInputCodeColumnName = "UNIT_NAME";
            this.txtSpeedUnit.CelerityInputSqlWhere = "UNIT_TYPE=2";
            this.txtSpeedUnit.CelerityInputTableName = "MED_UNIT_DICT";
            this.txtSpeedUnit.CelerityInputValueColumnName = "UNIT_NAME";
            this.txtSpeedUnit.Data = null;
            this.txtSpeedUnit.DefaultPrintText = "";
            this.txtSpeedUnit.DictTableName = "MED_UNIT_DICT";
            this.txtSpeedUnit.DictValueFieldName = "UNIT_NAME";
            this.txtSpeedUnit.DictWhereString = "UNIT_TYPE=2";
            this.txtSpeedUnit.DisplayFieldName = "UNIT_NAME";
            this.txtSpeedUnit.DisplayMutiColFieldName = "";
            this.txtSpeedUnit.DotBorder = false;
            this.txtSpeedUnit.DotNumber = 0;
            this.txtSpeedUnit.ExamItemName = null;
            this.txtSpeedUnit.FieldName = "txtPath";
            this.txtSpeedUnit.Format = "";
            this.txtSpeedUnit.HasLookUpItems = false;
            this.txtSpeedUnit.InitValue = "";
            this.txtSpeedUnit.InputNeededMessage = "";
            this.txtSpeedUnit.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtSpeedUnit.LabItemName = null;
            this.txtSpeedUnit.LimitedString = "";
            this.txtSpeedUnit.Location = new System.Drawing.Point(253, 80);
            this.txtSpeedUnit.LockInput = false;
            this.txtSpeedUnit.Maximum = null;
            this.txtSpeedUnit.MaxLength = 20;
            this.txtSpeedUnit.Minimum = null;
            this.txtSpeedUnit.Multiline = false;
            this.txtSpeedUnit.MultiSelect = false;
            this.txtSpeedUnit.MultiSign = false;
            this.txtSpeedUnit.Name = "txtSpeedUnit";
            this.txtSpeedUnit.NoPrint = false;
            this.txtSpeedUnit.NoPrintText = "";
            this.txtSpeedUnit.NullAble = true;
            this.txtSpeedUnit.OldForeColor = System.Drawing.Color.Black;
            this.txtSpeedUnit.PasswordChar = '\0';
            this.txtSpeedUnit.PrintTail = "";
            this.txtSpeedUnit.PrintXOffSet = 0F;
            this.txtSpeedUnit.PrintYOffSet = 0F;
            this.txtSpeedUnit.ProgramChanging = false;
            this.txtSpeedUnit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSpeedUnit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSpeedUnit.Properties.LookAndFeel.SkinName = "Blue";
            this.txtSpeedUnit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSpeedUnit.Properties.MaxLength = 20;
            this.txtSpeedUnit.ReadOnly = false;
            this.txtSpeedUnit.SelfValue = "";
            this.txtSpeedUnit.SelfValueChanged = false;
            this.txtSpeedUnit.Size = new System.Drawing.Size(90, 21);
            this.txtSpeedUnit.SourceFieldName = "";
            this.txtSpeedUnit.SourceTableName = "";
            this.txtSpeedUnit.StoredValue = "";
            this.txtSpeedUnit.TabIndex = 69;
            this.txtSpeedUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSpeedUnit.UnderLineOffset = 0F;
            this.txtSpeedUnit.WantValueBeforePrint = "";
            this.txtSpeedUnit.WordWrap = false;
            // 
            // txtSpeed
            // 
            this.txtSpeed.BindFieldName = "";
            this.txtSpeed.BindList = "";
            this.txtSpeed.BindTableName = "";
            this.txtSpeed.BorderColor = System.Drawing.Color.LightGray;
            this.txtSpeed.BottomLine = false;
            this.txtSpeed.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtSpeed.CanEdit = true;
            this.txtSpeed.CelerityInputCodeColumnName = "";
            this.txtSpeed.CelerityInputSqlWhere = "";
            this.txtSpeed.CelerityInputTableName = "";
            this.txtSpeed.CelerityInputValueColumnName = "";
            this.txtSpeed.Data = null;
            this.txtSpeed.DefaultPrintText = "";
            this.txtSpeed.DictTableName = "";
            this.txtSpeed.DictValueFieldName = "";
            this.txtSpeed.DictWhereString = "";
            this.txtSpeed.DisplayFieldName = "";
            this.txtSpeed.DisplayMutiColFieldName = "";
            this.txtSpeed.DotBorder = false;
            this.txtSpeed.DotNumber = 0;
            this.txtSpeed.ExamItemName = null;
            this.txtSpeed.FieldName = "txtPath";
            this.txtSpeed.Format = "";
            this.txtSpeed.HasLookUpItems = false;
            this.txtSpeed.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSpeed.InitValue = "";
            this.txtSpeed.InputNeededMessage = "";
            this.txtSpeed.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.Nurmeric;
            this.txtSpeed.LabItemName = null;
            this.txtSpeed.LimitedString = "";
            this.txtSpeed.Location = new System.Drawing.Point(59, 83);
            this.txtSpeed.LockInput = false;
            this.txtSpeed.Maximum = null;
            this.txtSpeed.MaxLength = 20;
            this.txtSpeed.Minimum = null;
            this.txtSpeed.Multiline = false;
            this.txtSpeed.MultiSelect = false;
            this.txtSpeed.MultiSign = false;
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.NoPrint = false;
            this.txtSpeed.NoPrintText = "";
            this.txtSpeed.NullAble = true;
            this.txtSpeed.OldForeColor = System.Drawing.Color.Black;
            this.txtSpeed.PasswordChar = '\0';
            this.txtSpeed.PrintTail = "";
            this.txtSpeed.PrintXOffSet = 0F;
            this.txtSpeed.PrintYOffSet = 0F;
            this.txtSpeed.ProgramChanging = false;
            this.txtSpeed.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSpeed.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSpeed.Properties.LookAndFeel.SkinName = "Blue";
            this.txtSpeed.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSpeed.Properties.MaxLength = 20;
            this.txtSpeed.ReadOnly = false;
            this.txtSpeed.SelfValue = "";
            this.txtSpeed.SelfValueChanged = false;
            this.txtSpeed.Size = new System.Drawing.Size(90, 21);
            this.txtSpeed.SourceFieldName = "";
            this.txtSpeed.SourceTableName = "";
            this.txtSpeed.StoredValue = "";
            this.txtSpeed.TabIndex = 68;
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSpeed.UnderLineOffset = 0F;
            this.txtSpeed.WantValueBeforePrint = "";
            this.txtSpeed.WordWrap = false;
            // 
            // txtPathUnit
            // 
            this.txtPathUnit.BindFieldName = "";
            this.txtPathUnit.BindList = "";
            this.txtPathUnit.BindTableName = "";
            this.txtPathUnit.BorderColor = System.Drawing.Color.LightGray;
            this.txtPathUnit.BottomLine = false;
            this.txtPathUnit.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtPathUnit.CanEdit = true;
            this.txtPathUnit.CelerityInputCodeColumnName = "UNIT_NAME";
            this.txtPathUnit.CelerityInputSqlWhere = "UNIT_TYPE=1";
            this.txtPathUnit.CelerityInputTableName = "MED_UNIT_DICT";
            this.txtPathUnit.CelerityInputValueColumnName = "UNIT_NAME";
            this.txtPathUnit.Data = null;
            this.txtPathUnit.DefaultPrintText = "";
            this.txtPathUnit.DictTableName = "MED_UNIT_DICT";
            this.txtPathUnit.DictValueFieldName = "UNIT_NAME";
            this.txtPathUnit.DictWhereString = "UNIT_TYPE=1";
            this.txtPathUnit.DisplayFieldName = "UNIT_NAME";
            this.txtPathUnit.DisplayMutiColFieldName = "";
            this.txtPathUnit.DotBorder = false;
            this.txtPathUnit.DotNumber = 0;
            this.txtPathUnit.ExamItemName = null;
            this.txtPathUnit.FieldName = "txtPath";
            this.txtPathUnit.Format = "";
            this.txtPathUnit.HasLookUpItems = false;
            this.txtPathUnit.InitValue = "";
            this.txtPathUnit.InputNeededMessage = "";
            this.txtPathUnit.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtPathUnit.LabItemName = null;
            this.txtPathUnit.LimitedString = "";
            this.txtPathUnit.Location = new System.Drawing.Point(253, 51);
            this.txtPathUnit.LockInput = false;
            this.txtPathUnit.Maximum = null;
            this.txtPathUnit.MaxLength = 20;
            this.txtPathUnit.Minimum = null;
            this.txtPathUnit.Multiline = false;
            this.txtPathUnit.MultiSelect = false;
            this.txtPathUnit.MultiSign = false;
            this.txtPathUnit.Name = "txtPathUnit";
            this.txtPathUnit.NoPrint = false;
            this.txtPathUnit.NoPrintText = "";
            this.txtPathUnit.NullAble = true;
            this.txtPathUnit.OldForeColor = System.Drawing.Color.Black;
            this.txtPathUnit.PasswordChar = '\0';
            this.txtPathUnit.PrintTail = "";
            this.txtPathUnit.PrintXOffSet = 0F;
            this.txtPathUnit.PrintYOffSet = 0F;
            this.txtPathUnit.ProgramChanging = false;
            this.txtPathUnit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPathUnit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPathUnit.Properties.LookAndFeel.SkinName = "Blue";
            this.txtPathUnit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPathUnit.Properties.MaxLength = 20;
            this.txtPathUnit.ReadOnly = false;
            this.txtPathUnit.SelfValue = "";
            this.txtPathUnit.SelfValueChanged = false;
            this.txtPathUnit.Size = new System.Drawing.Size(90, 21);
            this.txtPathUnit.SourceFieldName = "";
            this.txtPathUnit.SourceTableName = "";
            this.txtPathUnit.StoredValue = "";
            this.txtPathUnit.TabIndex = 67;
            this.txtPathUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPathUnit.UnderLineOffset = 0F;
            this.txtPathUnit.WantValueBeforePrint = "";
            this.txtPathUnit.WordWrap = false;
            // 
            // txtDensity
            // 
            this.txtDensity.BindFieldName = "";
            this.txtDensity.BindList = "";
            this.txtDensity.BindTableName = "";
            this.txtDensity.BorderColor = System.Drawing.Color.LightGray;
            this.txtDensity.BottomLine = false;
            this.txtDensity.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtDensity.CanEdit = true;
            this.txtDensity.CelerityInputCodeColumnName = "";
            this.txtDensity.CelerityInputSqlWhere = "";
            this.txtDensity.CelerityInputTableName = "";
            this.txtDensity.CelerityInputValueColumnName = "";
            this.txtDensity.Data = null;
            this.txtDensity.DefaultPrintText = "";
            this.txtDensity.DictTableName = "";
            this.txtDensity.DictValueFieldName = "";
            this.txtDensity.DictWhereString = "";
            this.txtDensity.DisplayFieldName = "";
            this.txtDensity.DisplayMutiColFieldName = "";
            this.txtDensity.DotBorder = false;
            this.txtDensity.DotNumber = 0;
            this.txtDensity.ExamItemName = null;
            this.txtDensity.FieldName = "txtPath";
            this.txtDensity.Format = "";
            this.txtDensity.HasLookUpItems = false;
            this.txtDensity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDensity.InitValue = "";
            this.txtDensity.InputNeededMessage = "";
            this.txtDensity.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.Nurmeric;
            this.txtDensity.LabItemName = null;
            this.txtDensity.LimitedString = "";
            this.txtDensity.Location = new System.Drawing.Point(156, 51);
            this.txtDensity.LockInput = false;
            this.txtDensity.Maximum = null;
            this.txtDensity.MaxLength = 20;
            this.txtDensity.Minimum = null;
            this.txtDensity.Multiline = false;
            this.txtDensity.MultiSelect = false;
            this.txtDensity.MultiSign = false;
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.NoPrint = false;
            this.txtDensity.NoPrintText = "";
            this.txtDensity.NullAble = true;
            this.txtDensity.OldForeColor = System.Drawing.Color.Black;
            this.txtDensity.PasswordChar = '\0';
            this.txtDensity.PrintTail = "";
            this.txtDensity.PrintXOffSet = 0F;
            this.txtDensity.PrintYOffSet = 0F;
            this.txtDensity.ProgramChanging = false;
            this.txtDensity.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDensity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDensity.Properties.LookAndFeel.SkinName = "Blue";
            this.txtDensity.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDensity.Properties.MaxLength = 20;
            this.txtDensity.ReadOnly = false;
            this.txtDensity.SelfValue = "";
            this.txtDensity.SelfValueChanged = false;
            this.txtDensity.Size = new System.Drawing.Size(90, 21);
            this.txtDensity.SourceFieldName = "";
            this.txtDensity.SourceTableName = "";
            this.txtDensity.StoredValue = "";
            this.txtDensity.TabIndex = 66;
            this.txtDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDensity.UnderLineOffset = 0F;
            this.txtDensity.WantValueBeforePrint = "";
            this.txtDensity.WordWrap = false;
            // 
            // txtPath
            // 
            this.txtPath.BindFieldName = "";
            this.txtPath.BindList = "";
            this.txtPath.BindTableName = "";
            this.txtPath.BorderColor = System.Drawing.Color.LightGray;
            this.txtPath.BottomLine = false;
            this.txtPath.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtPath.CanEdit = true;
            this.txtPath.CelerityInputCodeColumnName = "ADMINISTRATION_NAME";
            this.txtPath.CelerityInputSqlWhere = "";
            this.txtPath.CelerityInputTableName = "MED_ADMINISTRATION_DICT";
            this.txtPath.CelerityInputValueColumnName = "ADMINISTRATION_NAME";
            this.txtPath.Data = null;
            this.txtPath.DefaultPrintText = "";
            this.txtPath.DictTableName = "MED_ADMINISTRATION_DICT";
            this.txtPath.DictValueFieldName = "ADMINISTRATION_NAME";
            this.txtPath.DictWhereString = "";
            this.txtPath.DisplayFieldName = "ADMINISTRATION_NAME";
            this.txtPath.DisplayMutiColFieldName = "";
            this.txtPath.DotBorder = false;
            this.txtPath.DotNumber = 0;
            this.txtPath.ExamItemName = null;
            this.txtPath.FieldName = "txtPath";
            this.txtPath.Format = "";
            this.txtPath.HasLookUpItems = false;
            this.txtPath.InitValue = "";
            this.txtPath.InputNeededMessage = "";
            this.txtPath.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtPath.LabItemName = null;
            this.txtPath.LimitedString = "";
            this.txtPath.Location = new System.Drawing.Point(59, 51);
            this.txtPath.LockInput = false;
            this.txtPath.Maximum = null;
            this.txtPath.MaxLength = 20;
            this.txtPath.Minimum = null;
            this.txtPath.Multiline = false;
            this.txtPath.MultiSelect = false;
            this.txtPath.MultiSign = false;
            this.txtPath.Name = "txtPath";
            this.txtPath.NoPrint = false;
            this.txtPath.NoPrintText = "";
            this.txtPath.NullAble = true;
            this.txtPath.OldForeColor = System.Drawing.Color.Black;
            this.txtPath.PasswordChar = '\0';
            this.txtPath.PrintTail = "";
            this.txtPath.PrintXOffSet = 0F;
            this.txtPath.PrintYOffSet = 0F;
            this.txtPath.ProgramChanging = false;
            this.txtPath.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPath.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPath.Properties.LookAndFeel.SkinName = "Blue";
            this.txtPath.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPath.Properties.MaxLength = 20;
            this.txtPath.ReadOnly = false;
            this.txtPath.SelfValue = "";
            this.txtPath.SelfValueChanged = false;
            this.txtPath.Size = new System.Drawing.Size(90, 21);
            this.txtPath.SourceFieldName = "";
            this.txtPath.SourceTableName = "";
            this.txtPath.StoredValue = "";
            this.txtPath.TabIndex = 65;
            this.txtPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPath.UnderLineOffset = 0F;
            this.txtPath.WantValueBeforePrint = "";
            this.txtPath.WordWrap = false;
            // 
            // chkContinued
            // 
            this.chkContinued.Location = new System.Drawing.Point(12, 19);
            this.chkContinued.Name = "chkContinued";
            this.chkContinued.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContinued.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkContinued.Properties.Appearance.Options.UseFont = true;
            this.chkContinued.Properties.Appearance.Options.UseForeColor = true;
            this.chkContinued.Properties.Caption = "持续用药";
            this.chkContinued.Properties.LookAndFeel.SkinName = "Blue";
            this.chkContinued.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkContinued.Size = new System.Drawing.Size(108, 22);
            this.chkContinued.TabIndex = 59;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(287, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 14);
            this.labelControl3.TabIndex = 60;
            this.labelControl3.Text = "(单位)";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(189, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 14);
            this.labelControl2.TabIndex = 61;
            this.labelControl2.Text = "(浓度)";
            // 
            // labelpath
            // 
            this.labelpath.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelpath.Appearance.Options.UseFont = true;
            this.labelpath.Location = new System.Drawing.Point(14, 52);
            this.labelpath.Name = "labelpath";
            this.labelpath.Size = new System.Drawing.Size(33, 17);
            this.labelpath.TabIndex = 62;
            this.labelpath.Text = "途径:";
            // 
            // labelDosage
            // 
            this.labelDosage.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDosage.Appearance.Options.UseFont = true;
            this.labelDosage.Location = new System.Drawing.Point(13, 115);
            this.labelDosage.Name = "labelDosage";
            this.labelDosage.Size = new System.Drawing.Size(33, 17);
            this.labelDosage.TabIndex = 63;
            this.labelDosage.Text = "剂量:";
            // 
            // labelSpeed
            // 
            this.labelSpeed.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.Appearance.Options.UseFont = true;
            this.labelSpeed.Location = new System.Drawing.Point(13, 84);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(33, 17);
            this.labelSpeed.TabIndex = 64;
            this.labelSpeed.Text = "速度:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.chkDelete);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 255);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(355, 59);
            this.panel3.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnSave.Location = new System.Drawing.Point(241, 14);
            this.btnSave.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnSave.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 34);
            this.btnSave.TabIndex = 91;
            this.btnSave.Title = "确定";
            this.btnSave.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnSave_Click);
            // 
            // chkDelete
            // 
            this.chkDelete.Location = new System.Drawing.Point(12, 21);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDelete.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.chkDelete.Properties.Appearance.Options.UseFont = true;
            this.chkDelete.Properties.Appearance.Options.UseForeColor = true;
            this.chkDelete.Properties.Caption = "删除用药";
            this.chkDelete.Properties.LookAndFeel.SkinName = "Blue";
            this.chkDelete.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkDelete.Size = new System.Drawing.Size(108, 22);
            this.chkDelete.TabIndex = 55;
            this.chkDelete.Visible = false;
            // 
            // EditEventItem
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panel1);
            this.Name = "EditEventItem";
            this.Size = new System.Drawing.Size(355, 314);
            this.Load += new System.EventHandler(this.EditEventItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEnd.Properties)).EndInit();
            this.panelMid.ResumeLayout(false);
            this.panelMid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosageUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeedUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDensity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkContinued.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDelete.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.CheckEdit checkEndDate;
        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.TimeEdit timeEditStart;
        private DevExpress.XtraEditors.TimeEdit timeEditEnd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panelMid;
        private DevExpress.XtraEditors.CheckEdit chkContinued;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelpath;
        private DevExpress.XtraEditors.LabelControl labelDosage;
        private DevExpress.XtraEditors.LabelControl labelSpeed;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.CheckEdit chkDelete;
        private Document.Controls.MedTextBox txtDosage;
        private Document.Controls.MedTextBox txtSpeed;
        private Views.DictTextBox txtDosageUnit;
        private Views.DictTextBox txtSpeedUnit;
        private Views.DictTextBox txtPathUnit;
        private Views.DictTextBox txtDensity;
        private Views.DictTextBox txtPath;
        private FrameWork.ButtonColor btnSave;

    }
}
