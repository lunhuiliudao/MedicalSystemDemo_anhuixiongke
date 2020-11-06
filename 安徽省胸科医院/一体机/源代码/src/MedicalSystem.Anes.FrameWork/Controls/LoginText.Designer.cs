namespace MedicalSystem.Anes.FrameWork
{
    partial class LoginText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginText));
            this.txtbox = new System.Windows.Forms.TextBox();
            this.panelICO = new System.Windows.Forms.Panel();
            this.panelClear = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtbox
            // 
            this.txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtbox.ForeColor = System.Drawing.Color.Gray;
            this.txtbox.Location = new System.Drawing.Point(50, 8);
            this.txtbox.MaxLength = 40;
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(246, 22);
            this.txtbox.TabIndex = 2;
            this.txtbox.TextChanged += new System.EventHandler(this.txtbox_TextChanged);
            this.txtbox.Enter += new System.EventHandler(this.txtbox_Enter);
            this.txtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbox_KeyDown);
            this.txtbox.Leave += new System.EventHandler(this.txtbox_Leave);
            // 
            // panelICO
            // 
            this.panelICO.BackColor = System.Drawing.Color.Transparent;
            this.panelICO.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelICO.BackgroundImage")));
            this.panelICO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelICO.Location = new System.Drawing.Point(1, 1);
            this.panelICO.Name = "panelICO";
            this.panelICO.Padding = new System.Windows.Forms.Padding(1);
            this.panelICO.Size = new System.Drawing.Size(24, 38);
            this.panelICO.TabIndex = 3;
            // 
            // panelClear
            // 
            this.panelClear.BackColor = System.Drawing.Color.Transparent;
            this.panelClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelClear.BackgroundImage")));
            this.panelClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelClear.Location = new System.Drawing.Point(302, 1);
            this.panelClear.Name = "panelClear";
            this.panelClear.Padding = new System.Windows.Forms.Padding(1);
            this.panelClear.Size = new System.Drawing.Size(20, 38);
            this.panelClear.TabIndex = 3;
            this.panelClear.Click += new System.EventHandler(this.panelClear_Click);
            // 
            // LoginText
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtbox);
            this.Controls.Add(this.panelICO);
            this.Controls.Add(this.panelClear);
            this.MinimumSize = new System.Drawing.Size(0, 42);
            this.Name = "LoginText";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(324, 42);
            this.Load += new System.EventHandler(this.LoginText_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginText_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.Panel panelICO;
        private System.Windows.Forms.Panel panelClear;
    }
}
