namespace MedicalSystem.Anes.Client.AppPC
{
    partial class TopBarControl
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
            this.MainInfo = new System.Windows.Forms.Panel();
            this.currentTimeControl1 = new MedicalSystem.Anes.Client.AppPC.CurrentTimeControl();
            this.MainInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainInfo
            // 
            this.MainInfo.BackColor = System.Drawing.Color.Transparent;
            this.MainInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainInfo.Controls.Add(this.currentTimeControl1);
            this.MainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainInfo.Location = new System.Drawing.Point(0, 0);
            this.MainInfo.Margin = new System.Windows.Forms.Padding(0);
            this.MainInfo.Name = "MainInfo";
            this.MainInfo.Size = new System.Drawing.Size(210, 37);
            this.MainInfo.TabIndex = 107;
            // 
            // currentTimeControl1
            // 
            this.currentTimeControl1.BackColor = System.Drawing.Color.Transparent;
            this.currentTimeControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.currentTimeControl1.IsDirty = false;
            this.currentTimeControl1.Location = new System.Drawing.Point(0, 0);
            this.currentTimeControl1.Name = "currentTimeControl1";
            this.currentTimeControl1.RefreshTimeSpan = 120;
            this.currentTimeControl1.Size = new System.Drawing.Size(207, 37);
            this.currentTimeControl1.TabIndex = 0;
            // 
            // TopBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainInfo);
            this.Name = "TopBarControl";
            this.Size = new System.Drawing.Size(210, 37);
            this.MainInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainInfo;
        public CurrentTimeControl currentTimeControl1;
    }
}
