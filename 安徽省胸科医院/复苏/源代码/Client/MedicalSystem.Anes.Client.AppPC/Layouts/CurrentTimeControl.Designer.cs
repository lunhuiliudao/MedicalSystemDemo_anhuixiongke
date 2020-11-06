namespace MedicalSystem.Anes.Client.AppPC
{
    partial class CurrentTimeControl
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
            this.lbTime = new System.Windows.Forms.Label();
            this.lbWeek = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(12, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(81, 31);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "21:20";
            // 
            // lbWeek
            // 
            this.lbWeek.AutoSize = true;
            this.lbWeek.BackColor = System.Drawing.Color.Transparent;
            this.lbWeek.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbWeek.ForeColor = System.Drawing.Color.White;
            this.lbWeek.Location = new System.Drawing.Point(112, 16);
            this.lbWeek.Name = "lbWeek";
            this.lbWeek.Size = new System.Drawing.Size(58, 22);
            this.lbWeek.TabIndex = 2;
            this.lbWeek.Text = "星期一";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.BackColor = System.Drawing.Color.Transparent;
            this.lbDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDate.ForeColor = System.Drawing.Color.White;
            this.lbDate.Location = new System.Drawing.Point(98, -1);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(84, 22);
            this.lbDate.TabIndex = 3;
            this.lbDate.Text = "2016-7-1";
            // 
            // CurrentTimeControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbWeek);
            this.Controls.Add(this.lbDate);
            this.Name = "CurrentTimeControl";
            this.Size = new System.Drawing.Size(195, 39);
            this.Load += new System.EventHandler(this.CurrentTimeControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbWeek;
        private System.Windows.Forms.Label lbDate;
    }
}
