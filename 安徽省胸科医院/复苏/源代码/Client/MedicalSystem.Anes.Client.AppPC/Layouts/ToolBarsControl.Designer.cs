namespace MedicalSystem.Anes.Client.AppPC
{
    partial class ToolBarsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBarsControl));
            this.panelProcess = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lbOperStatusTime = new System.Windows.Forms.Label();
            this.patientStatusContrl1 = new MedicalSystem.Anes.Client.AppPC.PatientStatusContrl();
            this.panelTurnTo = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelProcess
            // 
            this.panelProcess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelProcess.BackgroundImage")));
            this.panelProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelProcess.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelProcess.Location = new System.Drawing.Point(0, 0);
            this.panelProcess.Name = "panelProcess";
            this.panelProcess.Size = new System.Drawing.Size(66, 59);
            this.panelProcess.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lbOperStatusTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(808, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 59);
            this.panel1.TabIndex = 8;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.lblTime.Location = new System.Drawing.Point(6, 33);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(71, 19);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOperStatusTime
            // 
            this.lbOperStatusTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbOperStatusTime.AutoSize = true;
            this.lbOperStatusTime.BackColor = System.Drawing.Color.Transparent;
            this.lbOperStatusTime.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbOperStatusTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
            this.lbOperStatusTime.Location = new System.Drawing.Point(9, 12);
            this.lbOperStatusTime.Name = "lbOperStatusTime";
            this.lbOperStatusTime.Size = new System.Drawing.Size(65, 19);
            this.lbOperStatusTime.TabIndex = 1;
            this.lbOperStatusTime.Text = "手术时长";
            this.lbOperStatusTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // patientStatusContrl1
            // 
            this.patientStatusContrl1.BackColor = System.Drawing.Color.Transparent;
            this.patientStatusContrl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("patientStatusContrl1.BackgroundImage")));
            this.patientStatusContrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientStatusContrl1.Location = new System.Drawing.Point(66, 0);
            this.patientStatusContrl1.Name = "patientStatusContrl1";
            this.patientStatusContrl1.ServiceObject = null;
            this.patientStatusContrl1.Size = new System.Drawing.Size(659, 59);
            this.patientStatusContrl1.TabIndex = 0;
            // 
            // panelTurnTo
            // 
            this.panelTurnTo.BackColor = System.Drawing.Color.Transparent;
            this.panelTurnTo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTurnTo.BackgroundImage")));
            this.panelTurnTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelTurnTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTurnTo.Location = new System.Drawing.Point(725, 0);
            this.panelTurnTo.Name = "panelTurnTo";
            this.panelTurnTo.Size = new System.Drawing.Size(83, 59);
            this.panelTurnTo.TabIndex = 9;
            this.panelTurnTo.Visible = false;
            this.panelTurnTo.Click += new System.EventHandler(this.panelTurnTo_Click);
            // 
            // ToolBarsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.patientStatusContrl1);
            this.Controls.Add(this.panelTurnTo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelProcess);
            this.Name = "ToolBarsControl";
            this.Size = new System.Drawing.Size(891, 59);
            this.Load += new System.EventHandler(this.ToolBarsControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public PatientStatusContrl patientStatusContrl1;
        private System.Windows.Forms.Panel panelProcess;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Label lbOperStatusTime;
        private System.Windows.Forms.Panel panelTurnTo;

    }
}
