namespace MedicalSystem.Anes.Client.AppPC
{
    partial class TimeInPutFrmPC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonColorClose = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.buttonColorOK = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.timeControl = new MedicalSystem.Anes.Client.FrameWork.TimeControl();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.panelClose.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panlHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.timeControl);
            this.panelMain.Size = new System.Drawing.Size(430, 242);
            // 
            // panelClose
            // 
            this.panelClose.Location = new System.Drawing.Point(280, 0);
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(224, 30);
            // 
            // panlHeader
            // 
            this.panlHeader.Size = new System.Drawing.Size(430, 30);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(224, 30);
            this.lblTitle.Text = "时间确认";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonColorClose);
            this.panel2.Controls.Add(this.buttonColorOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(1, 211);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 64);
            this.panel2.TabIndex = 2;
            // 
            // buttonColorClose
            // 
            this.buttonColorClose.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.灰色;
            this.buttonColorClose.Location = new System.Drawing.Point(256, 15);
            this.buttonColorClose.MaximumSize = new System.Drawing.Size(102, 34);
            this.buttonColorClose.MinimumSize = new System.Drawing.Size(102, 34);
            this.buttonColorClose.Name = "buttonColorClose";
            this.buttonColorClose.Size = new System.Drawing.Size(102, 34);
            this.buttonColorClose.TabIndex = 90;
            this.buttonColorClose.Title = "取消";
            this.buttonColorClose.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.buttonColorClose_BtnClicked);
            // 
            // buttonColorOK
            // 
            this.buttonColorOK.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.绿色;
            this.buttonColorOK.Location = new System.Drawing.Point(96, 15);
            this.buttonColorOK.MaximumSize = new System.Drawing.Size(102, 34);
            this.buttonColorOK.MinimumSize = new System.Drawing.Size(102, 34);
            this.buttonColorOK.Name = "buttonColorOK";
            this.buttonColorOK.Size = new System.Drawing.Size(102, 34);
            this.buttonColorOK.TabIndex = 90;
            this.buttonColorOK.Title = "确定";
            this.buttonColorOK.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.buttonColorOK_BtnClicked);
            // 
            // timeControl
            // 
            this.timeControl.BackColor = System.Drawing.Color.White;
            this.timeControl.DateTimes = new System.DateTime(2016, 5, 26, 10, 45, 0, 0);
            this.timeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeControl.Location = new System.Drawing.Point(10, 0);
            this.timeControl.Name = "timeControl";
            this.timeControl.Padding = new System.Windows.Forms.Padding(20, 50, 0, 0);
            this.timeControl.Size = new System.Drawing.Size(410, 232);
            this.timeControl.StrMemo = "请输入时间：";
            this.timeControl.TabIndex = 1;
            this.timeControl.TimeType = MedicalSystem.Anes.Client.FrameWork.TimeControl.TimeInputType.DateTime;
            this.timeControl.MyKeyDown += new MedicalSystem.Anes.Client.FrameWork.TimeControl.KeyDownHandle(this.timeControl_MyKeyDown);
            // 
            // TimeInPutFrmPC
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(432, 276);
            this.Controls.Add(this.panel2);
            this.Name = "TimeInPutFrmPC";
            this.Text = "时间确认";
            this.Load += new System.EventHandler(this.TimeInPutFrmPC_Load);
            this.Controls.SetChildIndex(this.panlHeader, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.panelClose.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panlHeader.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private FrameWork.ButtonColor buttonColorOK;
        private FrameWork.ButtonColor buttonColorClose;
        private FrameWork.TimeControl timeControl;


    }
}