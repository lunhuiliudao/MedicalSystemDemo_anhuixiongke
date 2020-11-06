namespace MedicalSystem.Anes.Client.AppPC
{
    partial class UserMsgView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rTbMessage = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendMsg = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxReciverType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxReciver = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxReciverType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxReciver.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "收件人：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "留言内容：";
            // 
            // rTbMessage
            // 
            this.rTbMessage.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rTbMessage.Location = new System.Drawing.Point(107, 83);
            this.rTbMessage.Name = "rTbMessage";
            this.rTbMessage.Size = new System.Drawing.Size(340, 194);
            this.rTbMessage.TabIndex = 4;
            this.rTbMessage.Text = "";
            this.rTbMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rTbMessage_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "我要留言";
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendMsg.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSendMsg.Location = new System.Drawing.Point(252, 283);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(66, 25);
            this.btnSendMsg.TabIndex = 90;
            this.btnSendMsg.Text = "发送";
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(346, 283);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 25);
            this.btnClose.TabIndex = 91;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // comboBoxReciverType
            // 
            this.comboBoxReciverType.Location = new System.Drawing.Point(107, 47);
            this.comboBoxReciverType.Name = "comboBoxReciverType";
            this.comboBoxReciverType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxReciverType.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBoxReciverType.Properties.Appearance.Options.UseFont = true;
            this.comboBoxReciverType.Properties.Appearance.Options.UseForeColor = true;
            this.comboBoxReciverType.Properties.AutoComplete = false;
            this.comboBoxReciverType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxReciverType.Properties.DropDownRows = 9;
            this.comboBoxReciverType.Size = new System.Drawing.Size(66, 21);
            this.comboBoxReciverType.TabIndex = 92;
            this.comboBoxReciverType.SelectedIndexChanged += new System.EventHandler(this.comboBoxReciverType_SelectedIndexChanged);
            // 
            // comboBoxReciver
            // 
            this.comboBoxReciver.Location = new System.Drawing.Point(179, 47);
            this.comboBoxReciver.Name = "comboBoxReciver";
            this.comboBoxReciver.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxReciver.Properties.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBoxReciver.Properties.Appearance.Options.UseFont = true;
            this.comboBoxReciver.Properties.Appearance.Options.UseForeColor = true;
            this.comboBoxReciver.Properties.AutoComplete = false;
            this.comboBoxReciver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxReciver.Properties.DropDownRows = 9;
            this.comboBoxReciver.Size = new System.Drawing.Size(268, 21);
            this.comboBoxReciver.TabIndex = 93;
            // 
            // UserMsgView
            // 
            this.Controls.Add(this.comboBoxReciver);
            this.Controls.Add(this.comboBoxReciverType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rTbMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserMsgView";
            this.Size = new System.Drawing.Size(473, 333);
            this.Load += new System.EventHandler(this.UserMsgView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxReciverType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxReciver.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rTbMessage;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnSendMsg;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxReciverType;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxReciver;
    }
}