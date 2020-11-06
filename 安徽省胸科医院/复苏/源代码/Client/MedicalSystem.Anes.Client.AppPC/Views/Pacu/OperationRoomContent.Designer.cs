namespace MedicalSystem.Anes.Client.AppPC
{
    partial class OperationRoomContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationRoomContent));
            this.lbPatientName = new System.Windows.Forms.Label();
            this.lblAnesMethod = new System.Windows.Forms.Label();
            this.lbOperName = new System.Windows.Forms.Label();
            this.panelMainControl = new System.Windows.Forms.Panel();
            this.lbInPacuTime = new System.Windows.Forms.Label();
            this.lblOutPacu = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblChangeRoom = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lbRoomNo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInPacuTime = new System.Windows.Forms.Label();
            this.lblOutRoomTime = new System.Windows.Forms.Label();
            this.lblIntubation = new System.Windows.Forms.Label();
            this.lblAware = new System.Windows.Forms.Label();
            this.lblPupil = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblProcedures = new System.Windows.Forms.Label();
            this.pictureBoxSex = new System.Windows.Forms.PictureBox();
            this.lblInPacuDoc = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelMainControl.SuspendLayout();
            this.lblOutPacu.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSex)).BeginInit();
            this.lblInPacuDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPatientName
            // 
            this.lbPatientName.AutoSize = true;
            this.lbPatientName.BackColor = System.Drawing.Color.Transparent;
            this.lbPatientName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbPatientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lbPatientName.Location = new System.Drawing.Point(19, 32);
            this.lbPatientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPatientName.Name = "lbPatientName";
            this.lbPatientName.Size = new System.Drawing.Size(56, 18);
            this.lbPatientName.TabIndex = 16;
            this.lbPatientName.Text = "患者名";
            this.lbPatientName.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblAnesMethod
            // 
            this.lblAnesMethod.AutoSize = true;
            this.lblAnesMethod.BackColor = System.Drawing.Color.Transparent;
            this.lblAnesMethod.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblAnesMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblAnesMethod.Location = new System.Drawing.Point(18, 75);
            this.lblAnesMethod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnesMethod.Name = "lblAnesMethod";
            this.lblAnesMethod.Size = new System.Drawing.Size(68, 17);
            this.lblAnesMethod.TabIndex = 20;
            this.lblAnesMethod.Text = "麻醉方法";
            this.lblAnesMethod.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lbOperName
            // 
            this.lbOperName.BackColor = System.Drawing.Color.Transparent;
            this.lbOperName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbOperName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lbOperName.Location = new System.Drawing.Point(18, 54);
            this.lbOperName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOperName.Name = "lbOperName";
            this.lbOperName.Size = new System.Drawing.Size(306, 17);
            this.lbOperName.TabIndex = 16;
            this.lbOperName.Text = "手术方法                   体位";
            this.lbOperName.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // panelMainControl
            // 
            this.panelMainControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMainControl.BackgroundImage")));
            this.panelMainControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMainControl.Controls.Add(this.lbInPacuTime);
            this.panelMainControl.Controls.Add(this.lblOutPacu);
            this.panelMainControl.Controls.Add(this.lblChangeRoom);
            this.panelMainControl.Controls.Add(this.panelMain);
            this.panelMainControl.Controls.Add(this.lblInPacuDoc);
            this.panelMainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainControl.Location = new System.Drawing.Point(5, 5);
            this.panelMainControl.Name = "panelMainControl";
            this.panelMainControl.Size = new System.Drawing.Size(481, 116);
            this.panelMainControl.TabIndex = 100;
            this.panelMainControl.Click += new System.EventHandler(this.OperationRoomContent_Click);
            this.panelMainControl.Paint += new System.Windows.Forms.PaintEventHandler(this.OperationRoomContent_Paint);
            // 
            // lbInPacuTime
            // 
            this.lbInPacuTime.AutoSize = true;
            this.lbInPacuTime.BackColor = System.Drawing.Color.Transparent;
            this.lbInPacuTime.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbInPacuTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lbInPacuTime.Location = new System.Drawing.Point(402, 9);
            this.lbInPacuTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInPacuTime.Name = "lbInPacuTime";
            this.lbInPacuTime.Size = new System.Drawing.Size(50, 17);
            this.lbInPacuTime.TabIndex = 14;
            this.lbInPacuTime.Text = "已入室";
            this.lbInPacuTime.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblOutPacu
            // 
            this.lblOutPacu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutPacu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblOutPacu.BackgroundImage")));
            this.lblOutPacu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblOutPacu.Controls.Add(this.label4);
            this.lblOutPacu.Location = new System.Drawing.Point(396, 86);
            this.lblOutPacu.Name = "lblOutPacu";
            this.lblOutPacu.Size = new System.Drawing.Size(81, 30);
            this.lblOutPacu.TabIndex = 110;
            this.lblOutPacu.Click += new System.EventHandler(this.lblOutPacu_Click);
            this.lblOutPacu.MouseLeave += new System.EventHandler(this.lblOutPacu_MouseLeave);
            this.lblOutPacu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblOutPacu_MouseMove);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(34, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 30);
            this.label4.TabIndex = 111;
            this.label4.Text = "出室";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.lblOutPacu_Click);
            // 
            // lblChangeRoom
            // 
            this.lblChangeRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblChangeRoom.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblChangeRoom.ForeColor = System.Drawing.Color.White;
            this.lblChangeRoom.Location = new System.Drawing.Point(396, 34);
            this.lblChangeRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChangeRoom.Name = "lblChangeRoom";
            this.lblChangeRoom.Size = new System.Drawing.Size(81, 18);
            this.lblChangeRoom.TabIndex = 103;
            this.lblChangeRoom.Text = "换床";
            this.lblChangeRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChangeRoom.Click += new System.EventHandler(this.lblChangeRoom_DoubleClick);
            this.lblChangeRoom.DoubleClick += new System.EventHandler(this.lblChangeRoom_DoubleClick);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Controls.Add(this.lblIntubation);
            this.panelMain.Controls.Add(this.lblAware);
            this.panelMain.Controls.Add(this.lblPupil);
            this.panelMain.Controls.Add(this.lblAge);
            this.panelMain.Controls.Add(this.lblProcedures);
            this.panelMain.Controls.Add(this.pictureBoxSex);
            this.panelMain.Controls.Add(this.lblAnesMethod);
            this.panelMain.Controls.Add(this.lbPatientName);
            this.panelMain.Controls.Add(this.lbOperName);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(395, 116);
            this.panelMain.TabIndex = 108;
            this.panelMain.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbRoomNo);
            this.panelTop.Controls.Add(this.pictureBox2);
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.lbl2);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.lblInPacuTime);
            this.panelTop.Controls.Add(this.lblOutRoomTime);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(395, 29);
            this.panelTop.TabIndex = 105;
            // 
            // lbRoomNo
            // 
            this.lbRoomNo.BackColor = System.Drawing.Color.Transparent;
            this.lbRoomNo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbRoomNo.ForeColor = System.Drawing.Color.White;
            this.lbRoomNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbRoomNo.Location = new System.Drawing.Point(11, 8);
            this.lbRoomNo.Name = "lbRoomNo";
            this.lbRoomNo.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lbRoomNo.Size = new System.Drawing.Size(100, 17);
            this.lbRoomNo.TabIndex = 101;
            this.lbRoomNo.Text = "PACU-";
            this.lbRoomNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbRoomNo.Click += new System.EventHandler(this.lbRoomNo_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(169, 9);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 103;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(321, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 100;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lbl2.Location = new System.Drawing.Point(126, 8);
            this.lbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(38, 17);
            this.lbl2.TabIndex = 104;
            this.lbl2.Text = "出室";
            this.lbl2.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.label2.Location = new System.Drawing.Point(253, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 103;
            this.label2.Text = "入PACU";
            this.label2.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblInPacuTime
            // 
            this.lblInPacuTime.AutoSize = true;
            this.lblInPacuTime.BackColor = System.Drawing.Color.Transparent;
            this.lblInPacuTime.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInPacuTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.lblInPacuTime.Location = new System.Drawing.Point(341, 6);
            this.lblInPacuTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInPacuTime.Name = "lblInPacuTime";
            this.lblInPacuTime.Size = new System.Drawing.Size(41, 19);
            this.lblInPacuTime.TabIndex = 100;
            this.lblInPacuTime.Text = "时间";
            this.lblInPacuTime.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblOutRoomTime
            // 
            this.lblOutRoomTime.AutoSize = true;
            this.lblOutRoomTime.BackColor = System.Drawing.Color.Transparent;
            this.lblOutRoomTime.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOutRoomTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.lblOutRoomTime.Location = new System.Drawing.Point(189, 6);
            this.lblOutRoomTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutRoomTime.Name = "lblOutRoomTime";
            this.lblOutRoomTime.Size = new System.Drawing.Size(41, 19);
            this.lblOutRoomTime.TabIndex = 104;
            this.lblOutRoomTime.Text = "时间";
            this.lblOutRoomTime.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblIntubation
            // 
            this.lblIntubation.AutoSize = true;
            this.lblIntubation.BackColor = System.Drawing.Color.Transparent;
            this.lblIntubation.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblIntubation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblIntubation.Location = new System.Drawing.Point(329, 30);
            this.lblIntubation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntubation.Name = "lblIntubation";
            this.lblIntubation.Size = new System.Drawing.Size(53, 17);
            this.lblIntubation.TabIndex = 102;
            this.lblIntubation.Text = "床号：";
            this.lblIntubation.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblAware
            // 
            this.lblAware.AutoSize = true;
            this.lblAware.BackColor = System.Drawing.Color.Transparent;
            this.lblAware.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblAware.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblAware.Location = new System.Drawing.Point(203, 30);
            this.lblAware.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAware.Name = "lblAware";
            this.lblAware.Size = new System.Drawing.Size(68, 17);
            this.lblAware.TabIndex = 100;
            this.lblAware.Text = "住院号：";
            this.lblAware.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblPupil
            // 
            this.lblPupil.AutoSize = true;
            this.lblPupil.BackColor = System.Drawing.Color.Transparent;
            this.lblPupil.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblPupil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblPupil.Location = new System.Drawing.Point(218, 75);
            this.lblPupil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPupil.Name = "lblPupil";
            this.lblPupil.Size = new System.Drawing.Size(53, 17);
            this.lblPupil.TabIndex = 101;
            this.lblPupil.Text = "科室：";
            this.lblPupil.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblAge.Location = new System.Drawing.Point(124, 32);
            this.lblAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(40, 18);
            this.lblAge.TabIndex = 99;
            this.lblAge.Text = "年龄";
            this.lblAge.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblProcedures
            // 
            this.lblProcedures.AutoSize = true;
            this.lblProcedures.BackColor = System.Drawing.Color.Transparent;
            this.lblProcedures.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblProcedures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.lblProcedures.Location = new System.Drawing.Point(17, 94);
            this.lblProcedures.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcedures.Name = "lblProcedures";
            this.lblProcedures.Size = new System.Drawing.Size(88, 17);
            this.lblProcedures.TabIndex = 101;
            this.lblProcedures.Text = "术者     主麻";
            this.lblProcedures.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // pictureBoxSex
            // 
            this.pictureBoxSex.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSex.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSex.Image")));
            this.pictureBoxSex.Location = new System.Drawing.Point(96, 30);
            this.pictureBoxSex.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxSex.Name = "pictureBoxSex";
            this.pictureBoxSex.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxSex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSex.TabIndex = 35;
            this.pictureBoxSex.TabStop = false;
            this.pictureBoxSex.Click += new System.EventHandler(this.OperationRoomContent_Click);
            // 
            // lblInPacuDoc
            // 
            this.lblInPacuDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInPacuDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblInPacuDoc.BackgroundImage")));
            this.lblInPacuDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblInPacuDoc.Controls.Add(this.label3);
            this.lblInPacuDoc.Location = new System.Drawing.Point(396, 54);
            this.lblInPacuDoc.Name = "lblInPacuDoc";
            this.lblInPacuDoc.Size = new System.Drawing.Size(81, 30);
            this.lblInPacuDoc.TabIndex = 109;
            this.lblInPacuDoc.Click += new System.EventHandler(this.lblInPacuDoc_Click);
            this.lblInPacuDoc.MouseLeave += new System.EventHandler(this.lblInPacuDoc_MouseLeave);
            this.lblInPacuDoc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblInPacuDoc_MouseMove);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(34, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 30);
            this.label3.TabIndex = 110;
            this.label3.Text = "PACU";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.lblInPacuDoc_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 5);
            this.panel2.TabIndex = 103;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 121);
            this.panel3.TabIndex = 104;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(5, 121);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(481, 5);
            this.panel4.TabIndex = 104;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(486, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(5, 121);
            this.panel6.TabIndex = 104;
            // 
            // OperationRoomContent
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelMainControl);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OperationRoomContent";
            this.Size = new System.Drawing.Size(491, 126);
            this.Load += new System.EventHandler(this.OperationRoomContent_Load);
            this.Click += new System.EventHandler(this.OperationRoomContent_Click);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OperationRoomContent_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OperationRoomContent_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OperationRoomContent_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OperationRoomContent_MouseClick);
            this.panelMainControl.ResumeLayout(false);
            this.panelMainControl.PerformLayout();
            this.lblOutPacu.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSex)).EndInit();
            this.lblInPacuDoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbPatientName;
        private System.Windows.Forms.Label lblAnesMethod;
        private System.Windows.Forms.PictureBox pictureBoxSex;
        private System.Windows.Forms.Label lbOperName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Panel panelMainControl;
        private System.Windows.Forms.Label lblIntubation;
        private System.Windows.Forms.Label lblPupil;
        private System.Windows.Forms.Label lblAware;
        private System.Windows.Forms.Label lblProcedures;
        private System.Windows.Forms.Label lbInPacuTime;
        private System.Windows.Forms.Label lblInPacuTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbRoomNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel lblOutPacu;
        private System.Windows.Forms.Panel lblInPacuDoc;
        private System.Windows.Forms.Label lblChangeRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblOutRoomTime;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
