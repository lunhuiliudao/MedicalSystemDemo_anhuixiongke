namespace MedicalSystem.Anes.Client.FrameWork
{
    partial class TableControlMenu
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
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.BackgroundImage = global::MedicalSystem.Anes.Client.FrameWork.Properties.Resources.病历病程_1;
            this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelTitle.Size = new System.Drawing.Size(35, 122);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.Click += new System.EventHandler(this.panelTitle_Click);
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // TableControlMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelTitle);
            this.Name = "TableControlMenu";
            this.Size = new System.Drawing.Size(35, 122);
            this.Load += new System.EventHandler(this.TableControlMenu_Load);
            this.Resize += new System.EventHandler(this.ButtonMenu_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;

    }
}
