namespace MedicalSystem.Anes.Client.FrameWork
{
    partial class ButtonDownMenu
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
            this.panelDown = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelDown
            // 
            this.panelDown.BackColor = System.Drawing.Color.Transparent;
            this.panelDown.BackgroundImage = global::MedicalSystem.Anes.Client.FrameWork.Properties.Resources.展开箭头_1;
            this.panelDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDown.Location = new System.Drawing.Point(0, 0);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(30, 60);
            this.panelDown.TabIndex = 1;
            this.panelDown.Click += new System.EventHandler(this.panelDown_Click);
            // 
            // ButtonDownMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelDown);
            this.Name = "ButtonDownMenu";
            this.Size = new System.Drawing.Size(30, 60);
            this.Resize += new System.EventHandler(this.ButtonMenu_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDown;

    }
}
