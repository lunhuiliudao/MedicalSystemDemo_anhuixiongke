namespace MedicalSystem.Anes.Client.FrameWork
{
    partial class CheckEditControl
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
            this.checkTxt = new System.Windows.Forms.Label();
            this.panelCheck = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // checkTxt
            // 
            this.checkTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkTxt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkTxt.Location = new System.Drawing.Point(25, 0);
            this.checkTxt.Name = "checkTxt";
            this.checkTxt.Size = new System.Drawing.Size(198, 25);
            this.checkTxt.TabIndex = 0;
            this.checkTxt.Text = "label1";
            this.checkTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkTxt.TextChanged += new System.EventHandler(this.checkTxt_TextChanged);
            // 
            // panelCheck
            // 
            this.panelCheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCheck.Image = global::MedicalSystem.Anes.Client.FrameWork.Properties.Resources.未选中;
            this.panelCheck.Location = new System.Drawing.Point(0, 0);
            this.panelCheck.Name = "panelCheck";
            this.panelCheck.Size = new System.Drawing.Size(25, 25);
            this.panelCheck.TabIndex = 2;
            this.panelCheck.TabStop = false;
            this.panelCheck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCheck_MouseDown);
            // 
            // CheckEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.checkTxt);
            this.Controls.Add(this.panelCheck);
            this.Name = "CheckEditControl";
            this.Size = new System.Drawing.Size(223, 25);
            this.SizeChanged += new System.EventHandler(this.CheckEditControl_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label checkTxt;
        private System.Windows.Forms.PictureBox panelCheck;
    }
}
