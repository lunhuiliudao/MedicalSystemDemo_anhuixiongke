namespace MedicalSystem.Anes.Client.AppPC
{
    partial class PwdChangeControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnColse = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnCommit = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassWord = new MedicalSystem.Anes.Client.FrameWork.LoginText();
            this.txtNewPWDtoo = new MedicalSystem.Anes.Client.FrameWork.LoginText();
            this.txtNewPWD = new MedicalSystem.Anes.Client.FrameWork.LoginText();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnColse);
            this.panel1.Controls.Add(this.btnCommit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 49);
            this.panel1.TabIndex = 99;
            // 
            // btnColse
            // 
            this.btnColse.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.灰色;
            this.btnColse.Location = new System.Drawing.Point(226, 6);
            this.btnColse.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnColse.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(102, 34);
            this.btnColse.TabIndex = 86;
            this.btnColse.Title = "关闭";
            this.btnColse.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnColse_BtnClicked);
            // 
            // btnCommit
            // 
            this.btnCommit.BackColor = System.Drawing.SystemColors.Control;
            this.btnCommit.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.灰色;
            this.btnCommit.Location = new System.Drawing.Point(334, 6);
            this.btnCommit.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCommit.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(102, 34);
            this.btnCommit.TabIndex = 85;
            this.btnCommit.Title = "提交";
            this.btnCommit.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCommit_BtnClicked);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 152);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 105;
            this.labelControl3.Text = "确认密码";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 104;
            this.labelControl2.Text = "新密码";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 103;
            this.labelControl1.Text = "旧密码";
            // 
            // txtPassWord
            // 
            this.txtPassWord.BackColor = System.Drawing.Color.White;
            this.txtPassWord.DefaultText = "密码";
            this.txtPassWord.Location = new System.Drawing.Point(99, 13);
            this.txtPassWord.LoginType = MedicalSystem.Anes.Client.FrameWork.LoginText.LoginTextType.密码;
            this.txtPassWord.MinimumSize = new System.Drawing.Size(0, 42);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.txtPassWord.Size = new System.Drawing.Size(337, 42);
            this.txtPassWord.TabIndex = 106;
            this.txtPassWord.Value = "";
            this.txtPassWord.ValueKeyDown += new MedicalSystem.Anes.Client.FrameWork.LoginText.ValueKeyDownHandle(this.txtPassWord_ValueKeyDown);
            // 
            // txtNewPWDtoo
            // 
            this.txtNewPWDtoo.BackColor = System.Drawing.Color.White;
            this.txtNewPWDtoo.DefaultText = "密码";
            this.txtNewPWDtoo.Location = new System.Drawing.Point(99, 73);
            this.txtNewPWDtoo.LoginType = MedicalSystem.Anes.Client.FrameWork.LoginText.LoginTextType.密码;
            this.txtNewPWDtoo.MinimumSize = new System.Drawing.Size(0, 42);
            this.txtNewPWDtoo.Name = "txtNewPWDtoo";
            this.txtNewPWDtoo.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.txtNewPWDtoo.Size = new System.Drawing.Size(337, 42);
            this.txtNewPWDtoo.TabIndex = 107;
            this.txtNewPWDtoo.Value = "";
            this.txtNewPWDtoo.ValueKeyDown += new MedicalSystem.Anes.Client.FrameWork.LoginText.ValueKeyDownHandle(this.txtNewPWDtoo_ValueKeyDown);
            // 
            // txtNewPWD
            // 
            this.txtNewPWD.BackColor = System.Drawing.Color.White;
            this.txtNewPWD.DefaultText = "密码";
            this.txtNewPWD.Location = new System.Drawing.Point(99, 136);
            this.txtNewPWD.LoginType = MedicalSystem.Anes.Client.FrameWork.LoginText.LoginTextType.密码;
            this.txtNewPWD.MinimumSize = new System.Drawing.Size(0, 42);
            this.txtNewPWD.Name = "txtNewPWD";
            this.txtNewPWD.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.txtNewPWD.Size = new System.Drawing.Size(337, 42);
            this.txtNewPWD.TabIndex = 108;
            this.txtNewPWD.Value = "";
            this.txtNewPWD.ValueKeyDown += new MedicalSystem.Anes.Client.FrameWork.LoginText.ValueKeyDownHandle(this.txtNewPWD_ValueKeyDown);
            // 
            // PwdChangeControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtNewPWD);
            this.Controls.Add(this.txtNewPWDtoo);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panel1);
            this.Name = "PwdChangeControl";
            this.Size = new System.Drawing.Size(486, 255);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PwdChangeControl_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PwdChangeControl_KeyUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FrameWork.ButtonColor btnColse;
        private FrameWork.ButtonColor btnCommit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private FrameWork.LoginText txtPassWord;
        private FrameWork.LoginText txtNewPWDtoo;
        private FrameWork.LoginText txtNewPWD;
    }
}
