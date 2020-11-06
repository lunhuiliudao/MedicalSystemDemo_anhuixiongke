namespace MedicalSystem.Anes.Client.AppPC
{
    partial class OperationRoomPandect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationRoomPandect));
            this.pRoomPandect = new System.Windows.Forms.Panel();
            this.panelBotton = new System.Windows.Forms.Panel();
            this.btnUp = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnNext = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.pRoomPandect.SuspendLayout();
            this.panelBotton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pRoomPandect
            // 
            this.pRoomPandect.AutoScroll = true;
            this.pRoomPandect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pRoomPandect.Controls.Add(this.panelBotton);
            this.pRoomPandect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRoomPandect.Location = new System.Drawing.Point(0, 39);
            this.pRoomPandect.Name = "pRoomPandect";
            this.pRoomPandect.Size = new System.Drawing.Size(976, 443);
            this.pRoomPandect.TabIndex = 1;
            this.pRoomPandect.Paint += new System.Windows.Forms.PaintEventHandler(this.pRoomPandect_Paint);
            // 
            // panelBotton
            // 
            this.panelBotton.Controls.Add(this.btnUp);
            this.panelBotton.Controls.Add(this.btnNext);
            this.panelBotton.Location = new System.Drawing.Point(153, 185);
            this.panelBotton.Name = "panelBotton";
            this.panelBotton.Size = new System.Drawing.Size(273, 41);
            this.panelBotton.TabIndex = 122;
            this.panelBotton.Visible = false;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.White;
            this.btnUp.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnUp.Location = new System.Drawing.Point(761, 4);
            this.btnUp.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnUp.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(102, 34);
            this.btnUp.TabIndex = 89;
            this.btnUp.Title = "上一页";
            this.btnUp.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnUp_BtnClicked);
            // 
            // btnNext
            // 
            this.btnNext.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnNext.Location = new System.Drawing.Point(871, 4);
            this.btnNext.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnNext.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(102, 34);
            this.btnNext.TabIndex = 88;
            this.btnNext.Title = "下一页";
            this.btnNext.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnNext_BtnClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 36);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(85)))), ((int)(((byte)(122)))));
            this.label6.Location = new System.Drawing.Point(13, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "当前PACU";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(184)))), ((int)(((byte)(230)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 3);
            this.panel2.TabIndex = 121;
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 426;
            this.medScrollbar1.Location = new System.Drawing.Point(960, 40);
            this.medScrollbar1.Maximum = 480;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 441);
            this.medScrollbar1.SmallChange = 1;
            this.medScrollbar1.TabIndex = 0;
            this.medScrollbar1.ThisControl = this.pRoomPandect;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // OperationRoomPandect
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScroll = true;
            this.Controls.Add(this.medScrollbar1);
            this.Controls.Add(this.pRoomPandect);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OperationRoomPandect";
            this.Size = new System.Drawing.Size(976, 482);
            this.pRoomPandect.ResumeLayout(false);
            this.panelBotton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pRoomPandect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelBotton;
        private FrameWork.ButtonColor btnUp;
        private FrameWork.ButtonColor btnNext;
        private Document.Controls.MedScrollbar medScrollbar1;
    }
}
