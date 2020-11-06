namespace MedicalSystem.Anes.Client.AppPC
{
    partial class DayWeekView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DayWeekView));
            this.panelNoFlash1 = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.labTitle = new System.Windows.Forms.Label();
            this.labDay = new System.Windows.Forms.Label();
            this.panelNoFlash2 = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.panelNoFlash1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNoFlash1
            // 
            this.panelNoFlash1.BackColor = System.Drawing.Color.Transparent;
            this.panelNoFlash1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelNoFlash1.Controls.Add(this.labTitle);
            this.panelNoFlash1.Controls.Add(this.labDay);
            this.panelNoFlash1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNoFlash1.Location = new System.Drawing.Point(0, 0);
            this.panelNoFlash1.Name = "panelNoFlash1";
            this.panelNoFlash1.Padding = new System.Windows.Forms.Padding(4);
            this.panelNoFlash1.Size = new System.Drawing.Size(307, 40);
            this.panelNoFlash1.TabIndex = 2;
            // 
            // labTitle
            // 
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(216)))), ((int)(((byte)(172)))));
            this.labTitle.Location = new System.Drawing.Point(36, 4);
            this.labTitle.Name = "labTitle";
            this.labTitle.Padding = new System.Windows.Forms.Padding(10, 7, 0, 7);
            this.labTitle.Size = new System.Drawing.Size(267, 32);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "labTitle";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labDay
            // 
            this.labDay.Dock = System.Windows.Forms.DockStyle.Left;
            this.labDay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labDay.ForeColor = System.Drawing.Color.White;
            this.labDay.Image = ((System.Drawing.Image)(resources.GetObject("labDay.Image")));
            this.labDay.Location = new System.Drawing.Point(4, 4);
            this.labDay.Name = "labDay";
            this.labDay.Size = new System.Drawing.Size(32, 32);
            this.labDay.TabIndex = 0;
            this.labDay.Text = "28";
            this.labDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelNoFlash2
            // 
            this.panelNoFlash2.BackColor = System.Drawing.Color.Transparent;
            this.panelNoFlash2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoFlash2.Location = new System.Drawing.Point(0, 40);
            this.panelNoFlash2.Name = "panelNoFlash2";
            this.panelNoFlash2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelNoFlash2.Size = new System.Drawing.Size(307, 233);
            this.panelNoFlash2.TabIndex = 3;
            // 
            // DayWeekView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panelNoFlash2);
            this.Controls.Add(this.panelNoFlash1);
            this.Name = "DayWeekView";
            this.Size = new System.Drawing.Size(307, 273);
            this.panelNoFlash1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labDay;
        private FrameWork.PanelNoFlash panelNoFlash1;
        private System.Windows.Forms.Label labTitle;
        private FrameWork.PanelNoFlash panelNoFlash2;





    }
}
