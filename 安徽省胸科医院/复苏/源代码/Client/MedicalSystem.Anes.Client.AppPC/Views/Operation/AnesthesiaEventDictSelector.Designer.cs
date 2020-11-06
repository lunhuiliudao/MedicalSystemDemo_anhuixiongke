namespace MedicalSystem.Anes.Client.AppPC
{
    partial class AnesthesiaEventDictSelector
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
            this.panelBody = new System.Windows.Forms.Panel();
            this.lblPage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEventType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchTextBox = new MedicalSystem.Anes.Client.FrameWork.SearchTextBox();
            this.panelType = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelPage = new System.Windows.Forms.Panel();
            this.lblDosage1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelType.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.White;
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(20, 36);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(759, 109);
            this.panelBody.TabIndex = 0;
            this.panelBody.SizeChanged += new System.EventHandler(this.panelBody_SizeChanged);
            this.panelBody.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBody_Paint);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
            this.lblPage.Location = new System.Drawing.Point(42, 9);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(25, 20);
            this.lblPage.TabIndex = 1;
            this.lblPage.Text = "10";
            this.lblPage.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "常用";
            // 
            // cboEventType
            // 
            this.cboEventType.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboEventType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(186)))), ((int)(((byte)(230)))));
            this.cboEventType.FormattingEnabled = true;
            this.cboEventType.Location = new System.Drawing.Point(1, 1);
            this.cboEventType.Name = "cboEventType";
            this.cboEventType.Size = new System.Drawing.Size(124, 28);
            this.cboEventType.TabIndex = 1;
            this.cboEventType.Text = "选择事件分类";
            this.cboEventType.SelectedIndexChanged += new System.EventHandler(this.cboEventType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
            this.label1.Location = new System.Drawing.Point(18, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "输入事件名称";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Controls.Add(this.panelType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.panel1.Size = new System.Drawing.Size(799, 70);
            this.panel1.TabIndex = 1;
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.Transparent;
            this.searchTextBox.CurrentText = "";
            this.searchTextBox.DefaultText = "请输入拼音首字母检索事件名称";
            this.searchTextBox.Location = new System.Drawing.Point(152, 30);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(337, 30);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.EditValueChanged += new MedicalSystem.Anes.Client.FrameWork.SearchTextBox.EditValueChangedHandle(this.txtPinYing_EditValueChanged);
            this.searchTextBox.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTime_Paint);
            // 
            // panelType
            // 
            this.panelType.BackColor = System.Drawing.Color.Transparent;
            this.panelType.Controls.Add(this.cboEventType);
            this.panelType.Location = new System.Drawing.Point(20, 30);
            this.panelType.Name = "panelType";
            this.panelType.Size = new System.Drawing.Size(126, 30);
            this.panelType.TabIndex = 5;
            this.panelType.Paint += new System.Windows.Forms.PaintEventHandler(this.panelType_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panelBody);
            this.panel3.Controls.Add(this.panelPage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(20, 0, 20, 5);
            this.panel3.Size = new System.Drawing.Size(799, 150);
            this.panel3.TabIndex = 1;
            // 
            // panelPage
            // 
            this.panelPage.BackColor = System.Drawing.Color.Transparent;
            this.panelPage.Controls.Add(this.lblDosage1);
            this.panelPage.Controls.Add(this.label2);
            this.panelPage.Controls.Add(this.lblPage);
            this.panelPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPage.Location = new System.Drawing.Point(20, 0);
            this.panelPage.Name = "panelPage";
            this.panelPage.Size = new System.Drawing.Size(759, 36);
            this.panelPage.TabIndex = 6;
            // 
            // lblDosage1
            // 
            this.lblDosage1.AutoSize = true;
            this.lblDosage1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDosage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
            this.lblDosage1.Location = new System.Drawing.Point(677, 6);
            this.lblDosage1.Name = "lblDosage1";
            this.lblDosage1.Size = new System.Drawing.Size(29, 17);
            this.lblDosage1.TabIndex = 2;
            this.lblDosage1.Text = "100";
            this.lblDosage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDosage1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(20, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 1);
            this.panel2.TabIndex = 6;
            // 
            // AnesthesiaEventDictSelector
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "AnesthesiaEventDictSelector";
            this.Size = new System.Drawing.Size(799, 220);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelType.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelPage.ResumeLayout(false);
            this.panelPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEventType;
        private FrameWork.SearchTextBox searchTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelType;
        private System.Windows.Forms.Panel panelPage;
        private System.Windows.Forms.Label lblDosage1;
        private System.Windows.Forms.Panel panel2;
    }
}
