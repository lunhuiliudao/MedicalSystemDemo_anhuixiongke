namespace MedicalSystem.Anes.Client.AppPC
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labMainVersion = new System.Windows.Forms.Label();
            this.labLatestVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "麻醉临床信息系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(30, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "麦迪斯顿医疗科股份有限公司";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(30, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Copyright MedicalSystem Co.,Ltd.";
            // 
            // labMainVersion
            // 
            this.labMainVersion.AutoSize = true;
            this.labMainVersion.Font = new System.Drawing.Font("宋体", 10F);
            this.labMainVersion.Location = new System.Drawing.Point(30, 116);
            this.labMainVersion.Name = "labMainVersion";
            this.labMainVersion.Size = new System.Drawing.Size(63, 14);
            this.labMainVersion.TabIndex = 0;
            this.labMainVersion.Text = "2.2.1001";
            // 
            // labLatestVersion
            // 
            this.labLatestVersion.AutoSize = true;
            this.labLatestVersion.Font = new System.Drawing.Font("宋体", 10F);
            this.labLatestVersion.Location = new System.Drawing.Point(30, 139);
            this.labLatestVersion.Name = "labLatestVersion";
            this.labLatestVersion.Size = new System.Drawing.Size(63, 14);
            this.labLatestVersion.TabIndex = 0;
            this.labLatestVersion.Text = "2.2.1001";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MedicalSystem.Anes.Client.AppPC.Properties.Resources.ICON_anesthesia_64X64;
            this.pictureBox1.Location = new System.Drawing.Point(324, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labLatestVersion);
            this.Controls.Add(this.labMainVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labMainVersion;
        private System.Windows.Forms.Label labLatestVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}