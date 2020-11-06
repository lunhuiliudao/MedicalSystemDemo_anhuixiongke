namespace MedicalSystem.Anes.Client.AppPC
{
    partial class ModifyMonitor
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblMonitorName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(35, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前设置监护仪";
            // 
            // lblMonitorName
            // 
            this.lblMonitorName.AutoSize = true;
            this.lblMonitorName.Font = new System.Drawing.Font("宋体", 12F);
            this.lblMonitorName.Location = new System.Drawing.Point(175, 25);
            this.lblMonitorName.Name = "lblMonitorName";
            this.lblMonitorName.Size = new System.Drawing.Size(120, 16);
            this.lblMonitorName.TabIndex = 1;
            this.lblMonitorName.Text = "当前设置监护仪";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(51, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "当前采集频率";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(19, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "当前频率采集次数";
            // 
            // tbTime
            // 
            this.tbTime.Font = new System.Drawing.Font("宋体", 12F);
            this.tbTime.ForeColor = System.Drawing.Color.Blue;
            this.tbTime.Location = new System.Drawing.Point(178, 59);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(69, 26);
            this.tbTime.TabIndex = 4;
            this.tbTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTime_KeyDown);
            // 
            // tbCount
            // 
            this.tbCount.Font = new System.Drawing.Font("宋体", 12F);
            this.tbCount.Location = new System.Drawing.Point(178, 110);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(69, 26);
            this.tbCount.TabIndex = 5;
            this.tbCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCount_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(265, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "分";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(265, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "次";
            // 
            // ModifyMonitor
            // 
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMonitorName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.Name = "ModifyMonitor";
            this.Size = new System.Drawing.Size(342, 162);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMonitorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}