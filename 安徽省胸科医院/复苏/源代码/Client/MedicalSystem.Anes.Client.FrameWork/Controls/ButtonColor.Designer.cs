namespace MedicalSystem.Anes.Client.FrameWork
{
    partial class ButtonColor
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
            this.panelBtn = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelBtn
            // 
            this.panelBtn.BackgroundImage = global::MedicalSystem.Anes.Client.FrameWork.Properties.Resources.蓝1;
            this.panelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBtn.Location = new System.Drawing.Point(0, 0);
            this.panelBtn.MaximumSize = new System.Drawing.Size(102, 34);
            this.panelBtn.MinimumSize = new System.Drawing.Size(102, 34);
            this.panelBtn.Name = "panelBtn";
            this.panelBtn.Size = new System.Drawing.Size(102, 34);
            this.panelBtn.TabIndex = 0;
            this.panelBtn.Click += new System.EventHandler(this.panelBtn_Click);
            this.panelBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBtn_Paint);
            // 
            // ButtonColor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panelBtn);
            this.MaximumSize = new System.Drawing.Size(102, 34);
            this.MinimumSize = new System.Drawing.Size(102, 34);
            this.Name = "ButtonColor";
            this.Size = new System.Drawing.Size(102, 34);
            this.Load += new System.EventHandler(this.ButtonColor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBtn;
    }
}
