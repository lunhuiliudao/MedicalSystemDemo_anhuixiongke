namespace MedicalSystem.Anes.Client.AppPC
{
    partial class ConfirmationTimeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmationTimeControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCannel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnUp = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnNext = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.panelEmergency = new System.Windows.Forms.Panel();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.panelSafetyDoc = new System.Windows.Forms.Panel();
            this.panelInTimeControl = new System.Windows.Forms.Panel();
            this.timeControl = new MedicalSystem.Anes.Client.FrameWork.TimeControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelEmergency.SuspendLayout();
            this.panelInTimeControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSecond);
            this.panel1.Controls.Add(this.lblFirst);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 48);
            this.panel1.TabIndex = 45;
            // 
            // lblSecond
            // 
            this.lblSecond.BackColor = System.Drawing.Color.Transparent;
            this.lblSecond.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSecond.Image = ((System.Drawing.Image)(resources.GetObject("lblSecond.Image")));
            this.lblSecond.Location = new System.Drawing.Point(210, 0);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(187, 48);
            this.lblSecond.TabIndex = 5;
            this.lblSecond.Text = "第2步. 时间确认";
            this.lblSecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFirst
            // 
            this.lblFirst.BackColor = System.Drawing.Color.Transparent;
            this.lblFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFirst.Image = ((System.Drawing.Image)(resources.GetObject("lblFirst.Image")));
            this.lblFirst.Location = new System.Drawing.Point(0, 0);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(210, 48);
            this.lblFirst.TabIndex = 4;
            this.lblFirst.Text = "第1步. 三方核查";
            this.lblFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCannel);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 402);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1121, 48);
            this.panel2.TabIndex = 88;
            // 
            // btnCannel
            // 
            this.btnCannel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnCannel.Location = new System.Drawing.Point(1016, 6);
            this.btnCannel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(102, 34);
            this.btnCannel.TabIndex = 86;
            this.btnCannel.Title = "取消";
            this.btnCannel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCannel_BtnClicked);
            // 
            // btnUp
            // 
            this.btnUp.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnUp.Location = new System.Drawing.Point(780, 5);
            this.btnUp.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnUp.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(102, 34);
            this.btnUp.TabIndex = 87;
            this.btnUp.Title = "上一步";
            this.btnUp.Visible = false;
            this.btnUp.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnUp_BtnClicked);
            // 
            // btnNext
            // 
            this.btnNext.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnNext.Location = new System.Drawing.Point(897, 6);
            this.btnNext.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnNext.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(102, 34);
            this.btnNext.TabIndex = 85;
            this.btnNext.Title = "下一步";
            this.btnNext.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnNext_BtnClicked);
            // 
            // panelEmergency
            // 
            this.panelEmergency.Controls.Add(this.medScrollbar1);
            this.panelEmergency.Controls.Add(this.panelInTimeControl);
            this.panelEmergency.Controls.Add(this.panelSafetyDoc);
            this.panelEmergency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEmergency.Location = new System.Drawing.Point(0, 48);
            this.panelEmergency.Name = "panelEmergency";
            this.panelEmergency.Size = new System.Drawing.Size(1121, 354);
            this.panelEmergency.TabIndex = 89;
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 10;
            this.medScrollbar1.Location = new System.Drawing.Point(1105, 1);
            this.medScrollbar1.Maximum = 100;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 352);
            this.medScrollbar1.SmallChange = 1;
            this.medScrollbar1.TabIndex = 0;
            this.medScrollbar1.ThisControl = this.panelSafetyDoc;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // panelSafetyDoc
            // 
            this.panelSafetyDoc.AutoScroll = true;
            this.panelSafetyDoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSafetyDoc.Location = new System.Drawing.Point(0, 0);
            this.panelSafetyDoc.Name = "panelSafetyDoc";
            this.panelSafetyDoc.Size = new System.Drawing.Size(1121, 354);
            this.panelSafetyDoc.TabIndex = 90;
            // 
            // panelInTimeControl
            // 
            this.panelInTimeControl.BackColor = System.Drawing.Color.White;
            this.panelInTimeControl.Controls.Add(this.timeControl);
            this.panelInTimeControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInTimeControl.Location = new System.Drawing.Point(0, 354);
            this.panelInTimeControl.Name = "panelInTimeControl";
            this.panelInTimeControl.Size = new System.Drawing.Size(1121, 354);
            this.panelInTimeControl.TabIndex = 90;
            // 
            // timeControl
            // 
            this.timeControl.BackColor = System.Drawing.Color.White;
            this.timeControl.DateTimes = new System.DateTime(2016, 9, 15, 16, 55, 0, 0);
            this.timeControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeControl.Location = new System.Drawing.Point(0, 0);
            this.timeControl.Name = "timeControl";
            this.timeControl.Padding = new System.Windows.Forms.Padding(500, 150, 0, 0);
            this.timeControl.Size = new System.Drawing.Size(1121, 230);
            this.timeControl.StrMemo = "请输入时间：";
            this.timeControl.TabIndex = 0;
            this.timeControl.TimeType = MedicalSystem.Anes.Client.FrameWork.TimeControl.TimeInputType.Time;
            // 
            // ConfirmationTimeControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelEmergency);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ConfirmationTimeControl";
            this.Size = new System.Drawing.Size(1121, 450);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelEmergency.ResumeLayout(false);
            this.panelInTimeControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FrameWork.ButtonColor btnUp;
        private FrameWork.ButtonColor btnCannel;
        private FrameWork.ButtonColor btnNext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelEmergency;
        private System.Windows.Forms.Panel panelInTimeControl;
        private FrameWork.TimeControl timeControl;
        private System.Windows.Forms.Panel panelSafetyDoc;
        private Document.Controls.MedScrollbar medScrollbar1;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblFirst;
    }
}
