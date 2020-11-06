namespace MedicalSystem.Anes.Client.AppPC
{
    partial class PatientStatusSingleControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientStatusSingleControl));
            this.toolTipStatusTime = new System.Windows.Forms.ToolTip(this.components);
            this.lbOperStatus = new System.Windows.Forms.Label();
            this.lbOperStatusTime = new System.Windows.Forms.Label();
            this.picLightImage = new System.Windows.Forms.PictureBox();
            this.picImageLeft = new System.Windows.Forms.Panel();
            this.picImageRight = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picLightImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOperStatus
            // 
            this.lbOperStatus.AutoSize = true;
            this.lbOperStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbOperStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.lbOperStatus.Location = new System.Drawing.Point(26, 38);
            this.lbOperStatus.Name = "lbOperStatus";
            this.lbOperStatus.Size = new System.Drawing.Size(56, 17);
            this.lbOperStatus.TabIndex = 0;
            this.lbOperStatus.Text = "入手术室";
            this.lbOperStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PatientStatusSingleControl_MouseDown);
            // 
            // lbOperStatusTime
            // 
            this.lbOperStatusTime.AutoSize = true;
            this.lbOperStatusTime.BackColor = System.Drawing.Color.Transparent;
            this.lbOperStatusTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbOperStatusTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.lbOperStatusTime.Location = new System.Drawing.Point(36, 4);
            this.lbOperStatusTime.Name = "lbOperStatusTime";
            this.lbOperStatusTime.Size = new System.Drawing.Size(31, 17);
            this.lbOperStatusTime.TabIndex = 0;
            this.lbOperStatusTime.Text = "--:--";
            this.lbOperStatusTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbOperStatusTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PatientStatusSingleControl_MouseDown);
            // 
            // picLightImage
            // 
            this.picLightImage.ErrorImage = null;
            this.picLightImage.Image = ((System.Drawing.Image)(resources.GetObject("picLightImage.Image")));
            this.picLightImage.Location = new System.Drawing.Point(55, 25);
            this.picLightImage.Name = "picLightImage";
            this.picLightImage.Size = new System.Drawing.Size(12, 12);
            this.picLightImage.TabIndex = 3;
            this.picLightImage.TabStop = false;
            // 
            // picImageLeft
            // 
            this.picImageLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picImageLeft.BackgroundImage")));
            this.picImageLeft.Location = new System.Drawing.Point(0, 30);
            this.picImageLeft.Name = "picImageLeft";
            this.picImageLeft.Size = new System.Drawing.Size(55, 2);
            this.picImageLeft.TabIndex = 2;
            this.picImageLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PatientStatusSingleControl_MouseDown);
            // 
            // picImageRight
            // 
            this.picImageRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picImageRight.BackgroundImage")));
            this.picImageRight.Location = new System.Drawing.Point(66, 30);
            this.picImageRight.Name = "picImageRight";
            this.picImageRight.Size = new System.Drawing.Size(55, 2);
            this.picImageRight.TabIndex = 3;
            // 
            // PatientStatusSingleControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picImageRight);
            this.Controls.Add(this.picImageLeft);
            this.Controls.Add(this.lbOperStatus);
            this.Controls.Add(this.picLightImage);
            this.Controls.Add(this.lbOperStatusTime);
            this.Name = "PatientStatusSingleControl";
            this.Size = new System.Drawing.Size(120, 62);
            this.Load += new System.EventHandler(this.PatientStatusSingleControl_Load);
            this.Click += new System.EventHandler(this.PatientStatusSingleControl_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PatientStatusSingleControl_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picLightImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbOperStatusTime;
        private System.Windows.Forms.Label lbOperStatus;
        private System.Windows.Forms.ToolTip toolTipStatusTime;
        private System.Windows.Forms.Panel picImageLeft;
        public System.Windows.Forms.PictureBox picLightImage;
        private System.Windows.Forms.Panel picImageRight;
    }
}
