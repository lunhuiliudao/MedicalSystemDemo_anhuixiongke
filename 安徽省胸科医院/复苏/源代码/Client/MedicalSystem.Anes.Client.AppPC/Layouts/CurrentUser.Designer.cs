namespace MedicalSystem.Anes.Client.AppPC
{
    partial class CurrentUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentUser));
            this.labelName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labeljob = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMsg = new System.Windows.Forms.PictureBox();
            this.pictureBoxXieTong = new System.Windows.Forms.PictureBox();
            this.pictureBoxHome = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            this.buttonDownMenuRILI = new MedicalSystem.Anes.Client.FrameWork.ButtonDownMenu();
            this.buttonDownMenuDisposed = new MedicalSystem.Anes.Client.FrameWork.ButtonDownMenu();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXieTong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(6, 4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(36, 17);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "张三";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labeljob);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(246, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 44);
            this.panel1.TabIndex = 11;
            // 
            // labeljob
            // 
            this.labeljob.AutoSize = true;
            this.labeljob.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labeljob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.labeljob.Location = new System.Drawing.Point(6, 24);
            this.labeljob.Name = "labeljob";
            this.labeljob.Size = new System.Drawing.Size(55, 14);
            this.labeljob.TabIndex = 10;
            this.labeljob.Text = "麻醉医生";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(1, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxMsg
            // 
            this.pictureBoxMsg.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMsg.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxMsg.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMsg.Image")));
            this.pictureBoxMsg.Location = new System.Drawing.Point(5, 0);
            this.pictureBoxMsg.Name = "pictureBoxMsg";
            this.pictureBoxMsg.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pictureBoxMsg.Size = new System.Drawing.Size(40, 44);
            this.pictureBoxMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMsg.TabIndex = 9;
            this.pictureBoxMsg.TabStop = false;
            this.pictureBoxMsg.Visible = false;
            this.pictureBoxMsg.Click += new System.EventHandler(this.pictureBoxMsg_Click);
            this.pictureBoxMsg.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMsg_Paint);
            // 
            // pictureBoxXieTong
            // 
            this.pictureBoxXieTong.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxXieTong.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxXieTong.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxXieTong.Image")));
            this.pictureBoxXieTong.Location = new System.Drawing.Point(45, 0);
            this.pictureBoxXieTong.Name = "pictureBoxXieTong";
            this.pictureBoxXieTong.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pictureBoxXieTong.Size = new System.Drawing.Size(40, 44);
            this.pictureBoxXieTong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxXieTong.TabIndex = 8;
            this.pictureBoxXieTong.TabStop = false;
            this.pictureBoxXieTong.Visible = false;
            this.pictureBoxXieTong.Click += new System.EventHandler(this.pictureBoxXieTong_Click);
            this.pictureBoxXieTong.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxXieTong_Paint);
            // 
            // pictureBoxHome
            // 
            this.pictureBoxHome.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHome.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxHome.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxHome.Image")));
            this.pictureBoxHome.Location = new System.Drawing.Point(125, 0);
            this.pictureBoxHome.Name = "pictureBoxHome";
            this.pictureBoxHome.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pictureBoxHome.Size = new System.Drawing.Size(40, 44);
            this.pictureBoxHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxHome.TabIndex = 6;
            this.pictureBoxHome.TabStop = false;
            this.pictureBoxHome.Click += new System.EventHandler(this.pictureBoxHome_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(165, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pictureBox2.Size = new System.Drawing.Size(1, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBoxUser
            // 
            this.pictureBoxUser.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxUser.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUser.Image")));
            this.pictureBoxUser.Location = new System.Drawing.Point(206, 0);
            this.pictureBoxUser.Name = "pictureBoxUser";
            this.pictureBoxUser.Size = new System.Drawing.Size(40, 44);
            this.pictureBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxUser.TabIndex = 5;
            this.pictureBoxUser.TabStop = false;
            // 
            // buttonDownMenuRILI
            // 
            this.buttonDownMenuRILI.BackColor = System.Drawing.Color.Transparent;
            this.buttonDownMenuRILI.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDownMenuRILI.BackgroundImage")));
            this.buttonDownMenuRILI.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDownMenuRILI.IsDirty = false;
            this.buttonDownMenuRILI.Items = ((System.Collections.Generic.List<string>)(resources.GetObject("buttonDownMenuRILI.Items")));
            this.buttonDownMenuRILI.Location = new System.Drawing.Point(85, 0);
            this.buttonDownMenuRILI.Name = "buttonDownMenuRILI";
            this.buttonDownMenuRILI.SelectIndex = -1;
            this.buttonDownMenuRILI.Size = new System.Drawing.Size(40, 44);
            this.buttonDownMenuRILI.TabIndex = 14;
            this.buttonDownMenuRILI.TProgramStatus = MedicalSystem.Anes.Client.FrameWork.ProgramStatus.NoPatient;
            this.buttonDownMenuRILI.Visible = false;
            this.buttonDownMenuRILI.ItemClick += new MedicalSystem.Anes.Client.FrameWork.ButtonDownMenu.ItemClickEvent(this.buttonDownMenuRILI_ItemClick);
            // 
            // buttonDownMenuDisposed
            // 
            this.buttonDownMenuDisposed.BackColor = System.Drawing.Color.Transparent;
            this.buttonDownMenuDisposed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDownMenuDisposed.BackgroundImage")));
            this.buttonDownMenuDisposed.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDownMenuDisposed.IsDirty = false;
            this.buttonDownMenuDisposed.Items = ((System.Collections.Generic.List<string>)(resources.GetObject("buttonDownMenuDisposed.Items")));
            this.buttonDownMenuDisposed.Location = new System.Drawing.Point(166, 0);
            this.buttonDownMenuDisposed.Name = "buttonDownMenuDisposed";
            this.buttonDownMenuDisposed.SelectIndex = -1;
            this.buttonDownMenuDisposed.Size = new System.Drawing.Size(40, 44);
            this.buttonDownMenuDisposed.TabIndex = 15;
            this.buttonDownMenuDisposed.TProgramStatus = MedicalSystem.Anes.Client.FrameWork.ProgramStatus.NoPatient;
            this.buttonDownMenuDisposed.Visible = false;
            this.buttonDownMenuDisposed.ItemClick += new MedicalSystem.Anes.Client.FrameWork.ButtonDownMenu.ItemClickEvent(this.buttonDownMenuDisposed_ItemClick);
            // 
            // CurrentUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxMsg);
            this.Controls.Add(this.pictureBoxXieTong);
            this.Controls.Add(this.buttonDownMenuRILI);
            this.Controls.Add(this.pictureBoxHome);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonDownMenuDisposed);
            this.Controls.Add(this.pictureBoxUser);
            this.Controls.Add(this.panel1);
            this.Name = "CurrentUser";
            this.Size = new System.Drawing.Size(334, 44);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXieTong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labeljob;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.PictureBox pictureBoxHome;
        private System.Windows.Forms.PictureBox pictureBoxXieTong;
        private System.Windows.Forms.PictureBox pictureBoxMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private FrameWork.ButtonDownMenu buttonDownMenuRILI;
        private FrameWork.ButtonDownMenu buttonDownMenuDisposed;
    }
}
