namespace MedicalSystem.Anes.FrameWork
{
    partial class MessageBoxFormPC
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
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonColorOK = new MedicalSystem.Anes.FrameWork.ButtonColor();
            this.buttonColorExit = new MedicalSystem.Anes.FrameWork.ButtonColor();
            this.pictureBoxMsgIco = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.panelClose.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panlHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMsgIco)).BeginInit();
            this.SuspendLayout();
            // 
            // picClose
            // 
            this.picClose.Location = new System.Drawing.Point(34, 0);
            this.picClose.Margin = new System.Windows.Forms.Padding(4);
            this.picClose.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.pictureBoxMsgIco);
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.textBoxMsg);
            this.panelMain.Location = new System.Drawing.Point(4, 31);
            this.panelMain.Size = new System.Drawing.Size(442, 243);
            // 
            // picIcon
            // 
            this.picIcon.Margin = new System.Windows.Forms.Padding(4);
            this.picIcon.Padding = new System.Windows.Forms.Padding(15, 8, 15, 13);
            this.picIcon.Size = new System.Drawing.Size(84, 28);
            // 
            // panelClose
            // 
            this.panelClose.Location = new System.Drawing.Point(362, 0);
            this.panelClose.Margin = new System.Windows.Forms.Padding(4);
            this.panelClose.Size = new System.Drawing.Size(80, 28);
            // 
            // panelTop
            // 
            this.panelTop.Location = new System.Drawing.Point(84, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Size = new System.Drawing.Size(278, 28);
            // 
            // panlHeader
            // 
            this.panlHeader.Location = new System.Drawing.Point(4, 3);
            this.panlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panlHeader.Size = new System.Drawing.Size(442, 28);
            // 
            // lblTitle
            // 
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(278, 28);
            this.lblTitle.Text = "MessageBoxFormPC";
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.BackColor = System.Drawing.Color.White;
            this.textBoxMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMsg.Enabled = false;
            this.textBoxMsg.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBoxMsg.ForeColor = System.Drawing.Color.Gray;
            this.textBoxMsg.Location = new System.Drawing.Point(158, 55);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.ReadOnly = true;
            this.textBoxMsg.Size = new System.Drawing.Size(250, 150);
            this.textBoxMsg.TabIndex = 0;
            this.textBoxMsg.Text = "文本内容";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonColorOK);
            this.panel2.Controls.Add(this.buttonColorExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 50);
            this.panel2.TabIndex = 1;
            // 
            // buttonColorOK
            // 
            this.buttonColorOK.ButtonColorType = MedicalSystem.Anes.FrameWork.ButtonColor.ButtonType.蓝色;
            this.buttonColorOK.Location = new System.Drawing.Point(265, 5);
            this.buttonColorOK.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonColorOK.MaximumSize = new System.Drawing.Size(102, 34);
            this.buttonColorOK.MinimumSize = new System.Drawing.Size(102, 34);
            this.buttonColorOK.Name = "buttonColorOK";
            this.buttonColorOK.Size = new System.Drawing.Size(102, 34);
            this.buttonColorOK.TabIndex = 0;
            this.buttonColorOK.Title = "确定";
            this.buttonColorOK.BtnClicked += new MedicalSystem.Anes.FrameWork.ButtonColor.BtnClickHandle(this.buttonColorOK_BtnClicked);
            // 
            // buttonColorExit
            // 
            this.buttonColorExit.ButtonColorType = MedicalSystem.Anes.FrameWork.ButtonColor.ButtonType.灰色;
            this.buttonColorExit.Location = new System.Drawing.Point(114, 5);
            this.buttonColorExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonColorExit.MaximumSize = new System.Drawing.Size(102, 34);
            this.buttonColorExit.MinimumSize = new System.Drawing.Size(102, 34);
            this.buttonColorExit.Name = "buttonColorExit";
            this.buttonColorExit.Size = new System.Drawing.Size(102, 34);
            this.buttonColorExit.TabIndex = 0;
            this.buttonColorExit.Title = "取消";
            this.buttonColorExit.BtnClicked += new MedicalSystem.Anes.FrameWork.ButtonColor.BtnClickHandle(this.buttonColorExit_BtnClicked);
            // 
            // pictureBoxMsgIco
            // 
            this.pictureBoxMsgIco.Image = global::MedicalSystem.Anes.FrameWork.Properties.Resources.警告;
            this.pictureBoxMsgIco.Location = new System.Drawing.Point(36, 55);
            this.pictureBoxMsgIco.Name = "pictureBoxMsgIco";
            this.pictureBoxMsgIco.Size = new System.Drawing.Size(88, 88);
            this.pictureBoxMsgIco.TabIndex = 2;
            this.pictureBoxMsgIco.TabStop = false;
            // 
            // MessageBoxFormPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 277);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MessageBoxFormPC";
            this.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ShowInTaskbar = false;
            this.Text = "MessageBoxFormPC";
            this.Load += new System.EventHandler(this.MessageBoxFormPC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.panelClose.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panlHeader.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMsgIco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxMsgIco;
        private ButtonColor buttonColorExit;
        private ButtonColor buttonColorOK;

    }
}