namespace MedicalSystem.Anes.Client.AppPC
{
    partial class PatientListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientListView));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.doctorQualityControl1 = new MedicalSystem.Anes.Client.AppPC.DoctorQualityControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.pnlBody = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.panel3 = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.checkEditPersonal = new MedicalSystem.Anes.Client.FrameWork.CheckEditControl();
            this.comboBoxOperRoom = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelOutCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPatCount = new System.Windows.Forms.Label();
            this.panel1 = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.panelJZDJ = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxOperRoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // doctorQualityControl1
            // 
            this.doctorQualityControl1.Caption = "";
            this.doctorQualityControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doctorQualityControl1.IsDirty = false;
            this.doctorQualityControl1.Location = new System.Drawing.Point(10, 0);
            this.doctorQualityControl1.Name = "doctorQualityControl1";
            this.doctorQualityControl1.Size = new System.Drawing.Size(505, 580);
            this.doctorQualityControl1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.doctorQualityControl1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.splitContainer1.Size = new System.Drawing.Size(1245, 580);
            this.splitContainer1.SplitterDistance = 719;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 96;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.medScrollbar1);
            this.panel5.Controls.Add(this.pnlBody);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(709, 580);
            this.panel5.TabIndex = 96;
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 10;
            this.medScrollbar1.Location = new System.Drawing.Point(693, 62);
            this.medScrollbar1.Maximum = 100;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 517);
            this.medScrollbar1.SmallChange = 1;
            this.medScrollbar1.TabIndex = 0;
            this.medScrollbar1.ThisControl = this.pnlBody;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBody.BackgroundImage")));
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 61);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(709, 519);
            this.pnlBody.TabIndex = 94;
            this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.checkEditPersonal);
            this.panel3.Controls.Add(this.comboBoxOperRoom);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.labelControl2);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.labelOutCount);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.labelPatCount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(709, 29);
            this.panel3.TabIndex = 91;
            // 
            // checkEditPersonal
            // 
            this.checkEditPersonal.BackColor = System.Drawing.Color.Transparent;
            this.checkEditPersonal.checkboxtext = "本人的";
            this.checkEditPersonal.IsChecked = false;
            this.checkEditPersonal.IsDirty = false;
            this.checkEditPersonal.Location = new System.Drawing.Point(4, 3);
            this.checkEditPersonal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkEditPersonal.Name = "checkEditPersonal";
            this.checkEditPersonal.Size = new System.Drawing.Size(84, 25);
            this.checkEditPersonal.TabIndex = 0;
            this.checkEditPersonal.CheckedChange += new MedicalSystem.Anes.Client.FrameWork.CheckEditControl.CheckedHandle(this.checkEditPersonal_CheckedChange);
            // 
            // comboBoxOperRoom
            // 
            this.comboBoxOperRoom.Location = new System.Drawing.Point(133, 5);
            this.comboBoxOperRoom.Name = "comboBoxOperRoom";
            this.comboBoxOperRoom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOperRoom.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBoxOperRoom.Properties.Appearance.Options.UseFont = true;
            this.comboBoxOperRoom.Properties.Appearance.Options.UseForeColor = true;
            this.comboBoxOperRoom.Properties.AutoComplete = false;
            this.comboBoxOperRoom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxOperRoom.Properties.DropDownRows = 9;
            this.comboBoxOperRoom.Properties.LookAndFeel.SkinName = "Blue";
            this.comboBoxOperRoom.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxOperRoom.Size = new System.Drawing.Size(56, 21);
            this.comboBoxOperRoom.TabIndex = 78;
            this.comboBoxOperRoom.TextChanged += new System.EventHandler(this.comboBoxOperRoom_SelectedIndexChanged_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(184)))), ((int)(((byte)(230)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(709, 3);
            this.panel2.TabIndex = 120;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(91, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 17);
            this.labelControl2.TabIndex = 79;
            this.labelControl2.Text = "手术间";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(327, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(10, 10);
            this.pictureBox3.TabIndex = 115;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(265, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 10);
            this.pictureBox2.TabIndex = 116;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(209, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 10);
            this.pictureBox1.TabIndex = 117;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(340, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 112;
            this.label7.Text = "术后";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(279, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 113;
            this.label3.Text = "术中";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(222, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 114;
            this.label5.Text = "术前";
            // 
            // labelOutCount
            // 
            this.labelOutCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOutCount.AutoSize = true;
            this.labelOutCount.BackColor = System.Drawing.Color.Transparent;
            this.labelOutCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelOutCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelOutCount.Location = new System.Drawing.Point(666, 9);
            this.labelOutCount.Name = "labelOutCount";
            this.labelOutCount.Size = new System.Drawing.Size(19, 17);
            this.labelOutCount.TabIndex = 104;
            this.labelOutCount.Text = " 0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(685, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 103;
            this.label2.Text = "条";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.Location = new System.Drawing.Point(577, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 102;
            this.label6.Text = "条记录,已完成";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(529, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 97;
            this.label1.Text = "共";
            // 
            // labelPatCount
            // 
            this.labelPatCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPatCount.AutoSize = true;
            this.labelPatCount.BackColor = System.Drawing.Color.Transparent;
            this.labelPatCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelPatCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelPatCount.Location = new System.Drawing.Point(555, 9);
            this.labelPatCount.Name = "labelPatCount";
            this.labelPatCount.Size = new System.Drawing.Size(19, 17);
            this.labelPatCount.TabIndex = 97;
            this.labelPatCount.Text = " 0";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panelJZDJ);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 32);
            this.panel1.TabIndex = 90;
            // 
            // panelJZDJ
            // 
            this.panelJZDJ.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelJZDJ.BackgroundImage")));
            this.panelJZDJ.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelJZDJ.Location = new System.Drawing.Point(604, 0);
            this.panelJZDJ.Name = "panelJZDJ";
            this.panelJZDJ.Size = new System.Drawing.Size(105, 32);
            this.panelJZDJ.TabIndex = 99;
            this.panelJZDJ.Click += new System.EventHandler(this.panelJZDJ_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(127, 32);
            this.label4.TabIndex = 97;
            this.label4.Text = "今日患者列表";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PatientListView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "PatientListView";
            this.Size = new System.Drawing.Size(1245, 580);
            this.Load += new System.EventHandler(this.PatientListView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxOperRoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPatCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        public DoctorQualityControl doctorQualityControl1;
        private MedicalSystem.Anes.Client.FrameWork.PanelNoFlash panel1;
        private System.Windows.Forms.Label label4;
        private MedicalSystem.Anes.Client.FrameWork.PanelNoFlash panel3;
        private MedicalSystem.Anes.Client.FrameWork.PanelNoFlash pnlBody;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelOutCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelJZDJ;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxOperRoom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Panel panel5;
        private FrameWork.CheckEditControl checkEditPersonal;
        private Document.Controls.MedScrollbar medScrollbar1;
    }
}
