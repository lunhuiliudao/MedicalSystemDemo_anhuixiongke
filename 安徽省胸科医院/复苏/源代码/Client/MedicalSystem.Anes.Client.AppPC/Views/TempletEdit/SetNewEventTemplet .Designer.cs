namespace MedicalSystem.Anes.Client.AppPC
{
    partial class SetNewEventTemplet
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
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnCancel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(9, 158);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "是否私有";
            this.checkEdit1.Properties.LookAndFeel.SkinName = "Blue";
            this.checkEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 48;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(11, 119);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.LookAndFeel.SkinName = "Blue";
            this.textEdit2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.textEdit2.Size = new System.Drawing.Size(309, 21);
            this.textEdit2.TabIndex = 46;
            this.textEdit2.TextChanged += new System.EventHandler(this.textEdit2_TextChanged);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(11, 58);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.LookAndFeel.SkinName = "Blue";
            this.textEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.textEdit1.Size = new System.Drawing.Size(309, 21);
            this.textEdit1.TabIndex = 47;
            this.textEdit1.TextChanged += new System.EventHandler(this.textEdit1_TextChanged);
            this.textEdit1.DoubleClick += new System.EventHandler(this.textEdit1_DoubleClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 99);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 14);
            this.labelControl2.TabIndex = 45;
            this.labelControl2.Text = "模板名(必填)：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 44;
            this.labelControl1.Text = "麻醉方法：";
            // 
            // btnOK
            // 
            this.btnOK.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnOK.Location = new System.Drawing.Point(26, 195);
            this.btnOK.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnOK.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 34);
            this.btnOK.TabIndex = 84;
            this.btnOK.Title = "取消";
            this.btnOK.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCancel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnCancel.Location = new System.Drawing.Point(184, 195);
            this.btnCancel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCancel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 34);
            this.btnCancel.TabIndex = 85;
            this.btnCancel.Title = "确认";
            this.btnCancel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnOK_Click);
            // 
            // SetNewEventTemplet
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "SetNewEventTemplet";
            this.Size = new System.Drawing.Size(336, 242);
            this.Load += new System.EventHandler(this.SetNewEventTemplet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private FrameWork.ButtonColor btnOK;
        private FrameWork.ButtonColor btnCancel;
    }
}
