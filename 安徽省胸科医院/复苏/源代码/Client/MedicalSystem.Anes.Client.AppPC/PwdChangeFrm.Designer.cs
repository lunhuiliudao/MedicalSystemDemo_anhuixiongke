namespace MedicalSystem.Anes.Client.AppPC
{
    partial class PwdChangeFrm
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNewPWDtoo = new System.Windows.Forms.TextBox();
            this.txtNewPWD = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.btnOk = new MedicalSystem.Anes.Document.Controls.MedButton();
            this.btnCancel = new MedicalSystem.Anes.Document.Controls.MedButton();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(29, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "确认密码";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(29, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "新密码";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "旧密码";
            // 
            // txtNewPWDtoo
            // 
            this.txtNewPWDtoo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPWDtoo.Location = new System.Drawing.Point(115, 67);
            this.txtNewPWDtoo.Name = "txtNewPWDtoo";
            this.txtNewPWDtoo.PasswordChar = '*';
            this.txtNewPWDtoo.Size = new System.Drawing.Size(207, 21);
            this.txtNewPWDtoo.TabIndex = 11;
            // 
            // txtNewPWD
            // 
            this.txtNewPWD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPWD.Location = new System.Drawing.Point(115, 105);
            this.txtNewPWD.Name = "txtNewPWD";
            this.txtNewPWD.PasswordChar = '*';
            this.txtNewPWD.Size = new System.Drawing.Size(207, 21);
            this.txtNewPWD.TabIndex = 12;
            // 
            // txtPassWord
            // 
            this.txtPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassWord.Location = new System.Drawing.Point(115, 28);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(207, 21);
            this.txtPassWord.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.ActionName = null;
            this.btnOk.AutoImage = false;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.BindControl = null;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.HasBorder = false;
            this.btnOk.IsMenu = false;
            this.btnOk.IsMouseHover = true;
            this.btnOk.Location = new System.Drawing.Point(132, 146);
            this.btnOk.MenuIndex = 0;
            this.btnOk.Name = "btnOk";
            this.btnOk.PageName = null;
            this.btnOk.Parameters = null;
            this.btnOk.ShortcutKeys = null;
            this.btnOk.ShowText = true;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "确认";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ActionName = null;
            this.btnCancel.AutoImage = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.BindControl = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.HasBorder = false;
            this.btnCancel.IsMenu = false;
            this.btnCancel.IsMouseHover = true;
            this.btnCancel.Location = new System.Drawing.Point(247, 146);
            this.btnCancel.MenuIndex = 0;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PageName = null;
            this.btnCancel.Parameters = null;
            this.btnCancel.ShortcutKeys = null;
            this.btnCancel.ShowText = true;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PwdChangeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(351, 181);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNewPWDtoo);
            this.Controls.Add(this.txtNewPWD);
            this.Controls.Add(this.txtPassWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PwdChangeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PwdChangeFrm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PwdChangeFrm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtNewPWDtoo;
        private System.Windows.Forms.TextBox txtNewPWD;
        private System.Windows.Forms.TextBox txtPassWord;
        private Document.Controls.MedButton btnOk;
        private Document.Controls.MedButton btnCancel;
    }
}