namespace MedicalSystem.Anes.Client.AppPC
{
    partial class LoginFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.panelOK = new System.Windows.Forms.Panel();
            this.panelClose = new System.Windows.Forms.Panel();
            this.panelMin = new System.Windows.Forms.Panel();
            this.labelMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoginName = new MedicalSystem.Anes.Client.FrameWork.LoginText();
            this.txtLoginPwd = new MedicalSystem.Anes.Client.FrameWork.LoginText();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelOK
            // 
            this.panelOK.BackColor = System.Drawing.Color.Transparent;
            this.panelOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelOK.BackgroundImage")));
            this.panelOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelOK.Location = new System.Drawing.Point(264, 486);
            this.panelOK.Name = "panelOK";
            this.panelOK.Size = new System.Drawing.Size(175, 47);
            this.panelOK.TabIndex = 7;
            this.panelOK.Click += new System.EventHandler(this.panelOK_Click);
            // 
            // panelClose
            // 
            this.panelClose.BackColor = System.Drawing.Color.Transparent;
            this.panelClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelClose.BackgroundImage")));
            this.panelClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelClose.Location = new System.Drawing.Point(505, 0);
            this.panelClose.Name = "panelClose";
            this.panelClose.Size = new System.Drawing.Size(42, 28);
            this.panelClose.TabIndex = 5;
            this.panelClose.Click += new System.EventHandler(this.panelClose_Click);
            // 
            // panelMin
            // 
            this.panelMin.BackColor = System.Drawing.Color.Transparent;
            this.panelMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMin.BackgroundImage")));
            this.panelMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelMin.Location = new System.Drawing.Point(463, 0);
            this.panelMin.Name = "panelMin";
            this.panelMin.Size = new System.Drawing.Size(42, 28);
            this.panelMin.TabIndex = 5;
            this.panelMin.Click += new System.EventHandler(this.panelMin_Click);
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMsg.ForeColor = System.Drawing.Color.Red;
            this.labelMsg.Location = new System.Drawing.Point(106, 454);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(0, 14);
            this.labelMsg.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(40, 580);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "版权所有@2005-2016 麦迪斯顿 Copyright Reserved 2005-2016 Medicalsystem Co.,Ltd.";
            // 
            // txtLoginName
            // 
            this.txtLoginName.BackColor = System.Drawing.Color.White;
            this.txtLoginName.DefaultText = "用户名";
            this.txtLoginName.Location = new System.Drawing.Point(109, 333);
            this.txtLoginName.LoginType = MedicalSystem.Anes.Client.FrameWork.LoginText.LoginTextType.用户名;
            this.txtLoginName.MinimumSize = new System.Drawing.Size(0, 42);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.txtLoginName.Size = new System.Drawing.Size(330, 42);
            this.txtLoginName.TabIndex = 10;
            this.txtLoginName.TxtReadOnly = false;
            this.txtLoginName.Value = "";
            this.txtLoginName.ValueChange += new MedicalSystem.Anes.Client.FrameWork.LoginText.ValueChangeHandle(this.txtbox_TextChanged);
            this.txtLoginName.ValueKeyDown += new MedicalSystem.Anes.Client.FrameWork.LoginText.ValueKeyDownHandle(this.txtLoginName_KeyDown);
            // 
            // txtLoginPwd
            // 
            this.txtLoginPwd.BackColor = System.Drawing.Color.White;
            this.txtLoginPwd.DefaultText = "密码";
            this.txtLoginPwd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLoginPwd.Location = new System.Drawing.Point(109, 393);
            this.txtLoginPwd.LoginType = MedicalSystem.Anes.Client.FrameWork.LoginText.LoginTextType.密码;
            this.txtLoginPwd.MinimumSize = new System.Drawing.Size(0, 42);
            this.txtLoginPwd.Name = "txtLoginPwd";
            this.txtLoginPwd.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.txtLoginPwd.Size = new System.Drawing.Size(330, 42);
            this.txtLoginPwd.TabIndex = 10;
            this.txtLoginPwd.TxtReadOnly = false;
            this.txtLoginPwd.Value = "";
            this.txtLoginPwd.ValueChange += new MedicalSystem.Anes.Client.FrameWork.LoginText.ValueChangeHandle(this.txtbox_TextChanged);
            this.txtLoginPwd.ValueKeyDown += new MedicalSystem.Anes.Client.FrameWork.LoginText.ValueKeyDownHandle(this.txtLoginPwd_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(186)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(104, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "用户登录";
            // 
            // LoginFrm
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(548, 621);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLoginPwd);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.panelOK);
            this.Controls.Add(this.panelClose);
            this.Controls.Add(this.panelMin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMainForm = true;
            this.Name = "LoginFrm";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelOK;
        private System.Windows.Forms.Panel panelClose;
        private System.Windows.Forms.Panel panelMin;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Label label1;
        private FrameWork.LoginText txtLoginName;
        private FrameWork.LoginText txtLoginPwd;
        private System.Windows.Forms.Label label2;

    }
}

