namespace MedicalSystem.Anes.Client.AppPC
{
    partial class AcsContent
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
            this.lbKeyWordsList = new System.Windows.Forms.ListBox();
            this.lbDrugName = new System.Windows.Forms.Label();
            this.webBrowserContent = new System.Windows.Forms.WebBrowser();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeyWords = new MedicalSystem.Anes.Client.CustomProject.Views.DictTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbKeyWordsList
            // 
            this.lbKeyWordsList.FormattingEnabled = true;
            this.lbKeyWordsList.ItemHeight = 14;
            this.lbKeyWordsList.Location = new System.Drawing.Point(52, 28);
            this.lbKeyWordsList.Name = "lbKeyWordsList";
            this.lbKeyWordsList.Size = new System.Drawing.Size(316, 88);
            this.lbKeyWordsList.TabIndex = 16;
            this.lbKeyWordsList.Visible = false;
            this.lbKeyWordsList.DoubleClick += new System.EventHandler(this.lbKeyWordsList_DoubleClick);
            // 
            // lbDrugName
            // 
            this.lbDrugName.AutoSize = true;
            this.lbDrugName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDrugName.Location = new System.Drawing.Point(217, 36);
            this.lbDrugName.Name = "lbDrugName";
            this.lbDrugName.Size = new System.Drawing.Size(57, 19);
            this.lbDrugName.TabIndex = 15;
            this.lbDrugName.Text = "药品名";
            // 
            // webBrowserContent
            // 
            this.webBrowserContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserContent.Location = new System.Drawing.Point(6, 58);
            this.webBrowserContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserContent.Name = "webBrowserContent";
            this.webBrowserContent.Size = new System.Drawing.Size(525, 299);
            this.webBrowserContent.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(374, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "关键词";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.BindFieldName = "";
            this.txtKeyWords.BindList = "";
            this.txtKeyWords.BindTableName = "";
            this.txtKeyWords.BorderColor = System.Drawing.Color.LightGray;
            this.txtKeyWords.BottomLine = false;
            this.txtKeyWords.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtKeyWords.CanEdit = true;
            this.txtKeyWords.CelerityInputCodeColumnName = "WORD";
            this.txtKeyWords.CelerityInputSqlWhere = "";
            this.txtKeyWords.CelerityInputTableName = "STANDARD_ARTICLE_KEYWORD";
            this.txtKeyWords.CelerityInputValueColumnName = "ART_ID";
            this.txtKeyWords.Data = null;
            this.txtKeyWords.DefaultPrintText = "";
            this.txtKeyWords.DictTableName = "STANDARD_ARTICLE_KEYWORD";
            this.txtKeyWords.DictValueFieldName = "ART_ID";
            this.txtKeyWords.DictWhereString = "";
            this.txtKeyWords.DisplayFieldName = "WORD";
            this.txtKeyWords.DisplayMutiColFieldName = "";
            this.txtKeyWords.DotBorder = false;
            this.txtKeyWords.DotNumber = 0;
            this.txtKeyWords.ExamItemName = null;
            this.txtKeyWords.FieldName = "dictTextBox1";
            this.txtKeyWords.Format = "";
            this.txtKeyWords.HasLookUpItems = false;
            this.txtKeyWords.InitValue = "";
            this.txtKeyWords.InputNeededMessage = "";
            this.txtKeyWords.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtKeyWords.LabItemName = null;
            this.txtKeyWords.LimitedString = "";
            this.txtKeyWords.Location = new System.Drawing.Point(52, 8);
            this.txtKeyWords.LockInput = false;
            this.txtKeyWords.Maximum = null;
            this.txtKeyWords.MaxLength = 0;
            this.txtKeyWords.Minimum = null;
            this.txtKeyWords.Multiline = false;
            this.txtKeyWords.MultiSelect = false;
            this.txtKeyWords.MultiSign = false;
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.NoPrint = false;
            this.txtKeyWords.NoPrintText = "";
            this.txtKeyWords.NullAble = true;
            this.txtKeyWords.OldForeColor = System.Drawing.Color.Black;
            this.txtKeyWords.PasswordChar = '\0';
            this.txtKeyWords.PrintTail = "";
            this.txtKeyWords.PrintXOffSet = 0F;
            this.txtKeyWords.PrintYOffSet = 0F;
            this.txtKeyWords.ProgramChanging = false;
            this.txtKeyWords.Properties.Appearance.Options.UseTextOptions = true;
            this.txtKeyWords.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtKeyWords.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtKeyWords.ReadOnly = false;
            this.txtKeyWords.SelfValue = "";
            this.txtKeyWords.SelfValueChanged = false;
            this.txtKeyWords.Size = new System.Drawing.Size(316, 21);
            this.txtKeyWords.SourceFieldName = "";
            this.txtKeyWords.SourceTableName = "";
            this.txtKeyWords.StoredValue = "";
            this.txtKeyWords.TabIndex = 17;
            this.txtKeyWords.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKeyWords.UnderLineOffset = 0F;
            this.txtKeyWords.WantValueBeforePrint = "";
            this.txtKeyWords.WordWrap = false;
            // 
            // AcsContent
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtKeyWords);
            this.Controls.Add(this.lbKeyWordsList);
            this.Controls.Add(this.lbDrugName);
            this.Controls.Add(this.webBrowserContent);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Name = "AcsContent";
            this.Size = new System.Drawing.Size(550, 380);
            this.Load += new System.EventHandler(this.AcsContent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyWords.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbKeyWordsList;
        private System.Windows.Forms.Label lbDrugName;
        private System.Windows.Forms.WebBrowser webBrowserContent;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private CustomProject.Views.DictTextBox txtKeyWords;
    }
}
