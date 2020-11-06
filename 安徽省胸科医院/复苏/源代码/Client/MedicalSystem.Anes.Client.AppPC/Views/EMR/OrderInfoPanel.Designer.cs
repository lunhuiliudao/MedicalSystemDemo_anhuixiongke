namespace MedicalSystem.Anes.Client.AppPC
{
    partial class OrderInfoPanel
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.medPanel1 = new MedicalSystem.Anes.Document.Controls.MedPanel();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.medLabel1 = new MedicalSystem.Anes.Document.Controls.MedLabel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.REPEAT_INDICATOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.START_DATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STOP_DATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORDER_TEXT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOSAGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOSAGE_UNITS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADMINISTRATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FREQUENCY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ENTER_DATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STOP_ORDER_DATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).BeginInit();
            this.medPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // medPanel1
            // 
            this.medPanel1.Controls.Add(this.radioGroup2);
            this.medPanel1.Controls.Add(this.radioGroup1);
            this.medPanel1.Controls.Add(this.medLabel1);
            this.medPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.medPanel1.Location = new System.Drawing.Point(0, 0);
            this.medPanel1.Name = "medPanel1";
            this.medPanel1.Size = new System.Drawing.Size(939, 57);
            this.medPanel1.TabIndex = 1;
            // 
            // radioGroup2
            // 
            this.radioGroup2.Location = new System.Drawing.Point(395, 12);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "新开"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "校对"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "已执行"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "已停止")});
            this.radioGroup2.Size = new System.Drawing.Size(341, 34);
            this.radioGroup2.TabIndex = 2;
            this.radioGroup2.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(203, 12);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "临时"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "长期")});
            this.radioGroup1.Size = new System.Drawing.Size(175, 34);
            this.radioGroup1.TabIndex = 3;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // medLabel1
            // 
            this.medLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medLabel1.Appearance.Options.UseFont = true;
            this.medLabel1.Appearance.Options.UseTextOptions = true;
            this.medLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.medLabel1.BottomLine = false;
            this.medLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medLabel1.DotBorder = false;
            this.medLabel1.Image = null;
            this.medLabel1.Location = new System.Drawing.Point(2, 2);
            this.medLabel1.MultiLine = false;
            this.medLabel1.Name = "medLabel1";
            this.medLabel1.NoPrint = false;
            this.medLabel1.PrintXOffSet = 0F;
            this.medLabel1.PrintYOffSet = 0F;
            this.medLabel1.Size = new System.Drawing.Size(935, 53);
            this.medLabel1.SymbolType = MedicalSystem.Anes.Document.Controls.MedSymbolType.None;
            this.medLabel1.TabIndex = 0;
            this.medLabel1.Text = "医嘱信息";
            this.medLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel1.VarKey = null;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 57);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(939, 643);
            this.gridControl1.TabIndex = 14;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.REPEAT_INDICATOR,
            this.START_DATE_TIME,
            this.STOP_DATE_TIME,
            this.ORDER_TEXT,
            this.DOSAGE,
            this.DOSAGE_UNITS,
            this.ADMINISTRATION,
            this.FREQUENCY,
            this.ENTER_DATE_TIME,
            this.STOP_ORDER_DATE_TIME});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // REPEAT_INDICATOR
            // 
            this.REPEAT_INDICATOR.Caption = "长期/临时";
            this.REPEAT_INDICATOR.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.REPEAT_INDICATOR.FieldName = "REPEAT_INDICATOR";
            this.REPEAT_INDICATOR.Name = "REPEAT_INDICATOR";
            this.REPEAT_INDICATOR.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.REPEAT_INDICATOR.OptionsColumn.FixedWidth = true;
            this.REPEAT_INDICATOR.Visible = true;
            this.REPEAT_INDICATOR.VisibleIndex = 0;
            this.REPEAT_INDICATOR.Width = 70;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DisplayMember = "DisplayText";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "ItemValue";
            // 
            // START_DATE_TIME
            // 
            this.START_DATE_TIME.Caption = "开始时间";
            this.START_DATE_TIME.FieldName = "START_DATE_TIME";
            this.START_DATE_TIME.Name = "START_DATE_TIME";
            this.START_DATE_TIME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.START_DATE_TIME.Visible = true;
            this.START_DATE_TIME.VisibleIndex = 1;
            this.START_DATE_TIME.Width = 100;
            // 
            // STOP_DATE_TIME
            // 
            this.STOP_DATE_TIME.Caption = "结束时间";
            this.STOP_DATE_TIME.FieldName = "STOP_DATE_TIME";
            this.STOP_DATE_TIME.Name = "STOP_DATE_TIME";
            this.STOP_DATE_TIME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.STOP_DATE_TIME.Visible = true;
            this.STOP_DATE_TIME.VisibleIndex = 2;
            this.STOP_DATE_TIME.Width = 100;
            // 
            // ORDER_TEXT
            // 
            this.ORDER_TEXT.Caption = "医嘱内容";
            this.ORDER_TEXT.FieldName = "ORDER_TEXT";
            this.ORDER_TEXT.Name = "ORDER_TEXT";
            this.ORDER_TEXT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ORDER_TEXT.Visible = true;
            this.ORDER_TEXT.VisibleIndex = 3;
            this.ORDER_TEXT.Width = 128;
            // 
            // DOSAGE
            // 
            this.DOSAGE.Caption = "剂量";
            this.DOSAGE.FieldName = "DOSAGE";
            this.DOSAGE.Name = "DOSAGE";
            this.DOSAGE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DOSAGE.OptionsColumn.FixedWidth = true;
            this.DOSAGE.Visible = true;
            this.DOSAGE.VisibleIndex = 4;
            this.DOSAGE.Width = 50;
            // 
            // DOSAGE_UNITS
            // 
            this.DOSAGE_UNITS.Caption = "剂量单位";
            this.DOSAGE_UNITS.FieldName = "DOSAGE_UNITS";
            this.DOSAGE_UNITS.Name = "DOSAGE_UNITS";
            this.DOSAGE_UNITS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DOSAGE_UNITS.OptionsColumn.FixedWidth = true;
            this.DOSAGE_UNITS.Visible = true;
            this.DOSAGE_UNITS.VisibleIndex = 5;
            this.DOSAGE_UNITS.Width = 70;
            // 
            // ADMINISTRATION
            // 
            this.ADMINISTRATION.Caption = "途径";
            this.ADMINISTRATION.FieldName = "ADMINISTRATION";
            this.ADMINISTRATION.Name = "ADMINISTRATION";
            this.ADMINISTRATION.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ADMINISTRATION.OptionsColumn.FixedWidth = true;
            this.ADMINISTRATION.Visible = true;
            this.ADMINISTRATION.VisibleIndex = 6;
            this.ADMINISTRATION.Width = 90;
            // 
            // FREQUENCY
            // 
            this.FREQUENCY.Caption = "频率";
            this.FREQUENCY.FieldName = "FREQUENCY";
            this.FREQUENCY.Name = "FREQUENCY";
            this.FREQUENCY.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.FREQUENCY.OptionsColumn.ReadOnly = true;
            this.FREQUENCY.Visible = true;
            this.FREQUENCY.VisibleIndex = 7;
            this.FREQUENCY.Width = 70;
            // 
            // ENTER_DATE_TIME
            // 
            this.ENTER_DATE_TIME.Caption = "执行时间";
            this.ENTER_DATE_TIME.FieldName = "ENTER_DATE_TIME";
            this.ENTER_DATE_TIME.Name = "ENTER_DATE_TIME";
            this.ENTER_DATE_TIME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ENTER_DATE_TIME.Visible = true;
            this.ENTER_DATE_TIME.VisibleIndex = 8;
            this.ENTER_DATE_TIME.Width = 100;
            // 
            // STOP_ORDER_DATE_TIME
            // 
            this.STOP_ORDER_DATE_TIME.Caption = "停止时间";
            this.STOP_ORDER_DATE_TIME.FieldName = "STOP_ORDER_DATE_TIME";
            this.STOP_ORDER_DATE_TIME.Name = "STOP_ORDER_DATE_TIME";
            this.STOP_ORDER_DATE_TIME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.STOP_ORDER_DATE_TIME.Visible = true;
            this.STOP_ORDER_DATE_TIME.VisibleIndex = 9;
            this.STOP_ORDER_DATE_TIME.Width = 100;
            // 
            // OrderInfoPanel
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.medPanel1);
            this.Name = "OrderInfoPanel";
            this.Size = new System.Drawing.Size(939, 700);
            this.Load += new System.EventHandler(this.OrderInfoPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medPanel1)).EndInit();
            this.medPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Document.Controls.MedPanel medPanel1;
        private Document.Controls.MedLabel medLabel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn REPEAT_INDICATOR;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn START_DATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn STOP_DATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn ORDER_TEXT;
        private DevExpress.XtraGrid.Columns.GridColumn DOSAGE;
        private DevExpress.XtraGrid.Columns.GridColumn DOSAGE_UNITS;
        private DevExpress.XtraGrid.Columns.GridColumn ADMINISTRATION;
        private DevExpress.XtraGrid.Columns.GridColumn FREQUENCY;
        private DevExpress.XtraGrid.Columns.GridColumn ENTER_DATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn STOP_ORDER_DATE_TIME;
        private DevExpress.XtraEditors.RadioGroup radioGroup2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}
