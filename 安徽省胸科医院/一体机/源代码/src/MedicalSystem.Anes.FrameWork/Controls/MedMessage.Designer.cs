namespace MedicalSystem.Anes.FrameWork
{
    partial class MedMessage
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
            this.labelMsg = new System.Windows.Forms.Label();
            this.timerMsg = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.BackColor = System.Drawing.Color.Transparent;
            this.labelMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMsg.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelMsg.ForeColor = System.Drawing.Color.DimGray;
            this.labelMsg.Location = new System.Drawing.Point(0, 0);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(269, 20);
            this.labelMsg.TabIndex = 2;
            this.labelMsg.Text = "您好，欢迎使用DoCare麻醉临床信息系统";
            // 
            // timerMsg
            // 
            this.timerMsg.Enabled = true;
            this.timerMsg.Interval = 2000;
            this.timerMsg.Tick += new System.EventHandler(this.timerMsg_Tick);
            // 
            // MedMessage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelMsg);
            this.Name = "MedMessage";
            this.Size = new System.Drawing.Size(327, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Timer timerMsg;
    }
}
