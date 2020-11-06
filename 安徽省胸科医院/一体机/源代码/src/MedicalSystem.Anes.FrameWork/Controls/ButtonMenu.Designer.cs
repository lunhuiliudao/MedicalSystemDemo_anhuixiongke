namespace MedicalSystem.Anes.FrameWork
{
    partial class ButtonMenu
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackgroundImage = global::MedicalSystem.Anes.FrameWork.Properties.Resources.功能按钮底图;
            this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelTitle.Controls.Add(this.panel1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(83, 36);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.Click += new System.EventHandler(this.panelTitle_Click);
            this.panelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitle_Paint);
            this.panelTitle.MouseEnter += new System.EventHandler(this.panelTitle_MouseEnter);
            this.panelTitle.MouseLeave += new System.EventHandler(this.panelTitle_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::MedicalSystem.Anes.FrameWork.Properties.Resources.功能按钮箭头;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(33, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 8);
            this.panel1.TabIndex = 0;
            // 
            // ButtonMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panelTitle);
            this.Name = "ButtonMenu";
            this.Size = new System.Drawing.Size(83, 36);
            this.Resize += new System.EventHandler(this.ButtonMenu_Resize);
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panel1;
    }
}
