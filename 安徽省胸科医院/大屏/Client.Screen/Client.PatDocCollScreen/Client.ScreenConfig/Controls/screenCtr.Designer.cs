namespace MedicalSystem.MedScreen.Client.ScreenConfig
{
    partial class screenCtr
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
            this.lblScreenNum = new System.Windows.Forms.Label();
            this.lblScreenLabel = new System.Windows.Forms.Label();
            this.lblScreenType = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScreenNum
            // 
            this.lblScreenNum.AutoSize = true;
            this.lblScreenNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblScreenNum.Location = new System.Drawing.Point(15, 9);
            this.lblScreenNum.Name = "lblScreenNum";
            this.lblScreenNum.Size = new System.Drawing.Size(65, 20);
            this.lblScreenNum.TabIndex = 0;
            this.lblScreenNum.Text = "大屏编号";
            // 
            // lblScreenLabel
            // 
            this.lblScreenLabel.AutoSize = true;
            this.lblScreenLabel.Location = new System.Drawing.Point(15, 33);
            this.lblScreenLabel.Name = "lblScreenLabel";
            this.lblScreenLabel.Size = new System.Drawing.Size(65, 20);
            this.lblScreenLabel.TabIndex = 1;
            this.lblScreenLabel.Text = "大屏标签";
            // 
            // lblScreenType
            // 
            this.lblScreenType.AutoSize = true;
            this.lblScreenType.Location = new System.Drawing.Point(15, 56);
            this.lblScreenType.Name = "lblScreenType";
            this.lblScreenType.Size = new System.Drawing.Size(65, 20);
            this.lblScreenType.TabIndex = 2;
            this.lblScreenType.Text = "大屏类型";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(15, 80);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(103, 20);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "尺寸1024×768";
            // 
            // screenCtr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblScreenType);
            this.Controls.Add(this.lblScreenLabel);
            this.Controls.Add(this.lblScreenNum);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "screenCtr";
            this.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Size = new System.Drawing.Size(195, 104);
            this.Load += new System.EventHandler(this.screenCtr_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.screenCtr_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScreenNum;
        private System.Windows.Forms.Label lblScreenLabel;
        private System.Windows.Forms.Label lblScreenType;
        private System.Windows.Forms.Label lblSize;
    }
}
