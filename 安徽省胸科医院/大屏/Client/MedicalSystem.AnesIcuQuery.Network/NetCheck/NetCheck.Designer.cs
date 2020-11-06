namespace MedicalSystem.MedScreen.Network
{
    partial class NetCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetCheck));
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.listBoxMsg = new System.Windows.Forms.ListBox();
            this.btnCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = "网络连接中断，请先检查网线是否松动...";
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(12, 161);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.marqueeProgressBarControl1.Properties.LookAndFeel.SkinName = "Blue";
            this.marqueeProgressBarControl1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.marqueeProgressBarControl1.Properties.MarqueeAnimationSpeed = 15;
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(404, 18);
            this.marqueeProgressBarControl1.TabIndex = 4;
            this.marqueeProgressBarControl1.Visible = false;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.ForeColor = System.Drawing.Color.Black;
            this.MessageLabel.Location = new System.Drawing.Point(12, 130);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(382, 27);
            this.MessageLabel.TabIndex = 3;
            this.MessageLabel.Text = "网络连接中断，请先检查网线是否松动...";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(341, 185);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timerCheck
            // 
            this.timerCheck.Interval = 5000;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // listBoxMsg
            // 
            this.listBoxMsg.FormattingEnabled = true;
            this.listBoxMsg.ItemHeight = 14;
            this.listBoxMsg.Location = new System.Drawing.Point(12, 12);
            this.listBoxMsg.Name = "listBoxMsg";
            this.listBoxMsg.Size = new System.Drawing.Size(412, 116);
            this.listBoxMsg.TabIndex = 10;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(260, 185);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 11;
            this.btnCheck.Text = "检测";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // NetCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 212);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.listBoxMsg);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网络诊断修复服务";
            this.Load += new System.EventHandler(this.NetCheck_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetCheck_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        public System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.ListBox listBoxMsg;
        private System.Windows.Forms.Button btnCheck;
    }
}
