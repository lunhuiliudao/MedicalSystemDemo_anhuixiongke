namespace MedicalSystem.Anes.Client.AppPC
{
    partial class TurnToControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TurnToControl));
            this.radioStatusOperTurnTo = new DevExpress.XtraEditors.RadioGroup();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSequence = new MedicalSystem.Anes.Document.Controls.MedLabel();
            this.medLabel2 = new MedicalSystem.Anes.Document.Controls.MedLabel();
            this.lblOperRoom = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCannel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnOK = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            ((System.ComponentModel.ISupportInitialize)(this.radioStatusOperTurnTo.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioStatusOperTurnTo
            // 
            this.radioStatusOperTurnTo.Location = new System.Drawing.Point(15, 59);
            this.radioStatusOperTurnTo.Name = "radioStatusOperTurnTo";
            this.radioStatusOperTurnTo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioStatusOperTurnTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioStatusOperTurnTo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.radioStatusOperTurnTo.Properties.Appearance.Options.UseBackColor = true;
            this.radioStatusOperTurnTo.Properties.Appearance.Options.UseFont = true;
            this.radioStatusOperTurnTo.Properties.Appearance.Options.UseForeColor = true;
            this.radioStatusOperTurnTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioStatusOperTurnTo.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ICU"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "恢复室"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "病房"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "门/急诊观察室"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "离院"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "死亡")});
            this.radioStatusOperTurnTo.Properties.LookAndFeel.SkinName = "Blue";
            this.radioStatusOperTurnTo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.radioStatusOperTurnTo.Size = new System.Drawing.Size(729, 33);
            this.radioStatusOperTurnTo.TabIndex = 110;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lblSequence);
            this.panel2.Controls.Add(this.medLabel2);
            this.panel2.Controls.Add(this.lblOperRoom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 30);
            this.panel2.TabIndex = 108;
            // 
            // lblSequence
            // 
            this.lblSequence.Appearance.Options.UseTextOptions = true;
            this.lblSequence.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblSequence.BottomLine = false;
            this.lblSequence.DotBorder = false;
            this.lblSequence.Image = null;
            this.lblSequence.Location = new System.Drawing.Point(721, 9);
            this.lblSequence.MultiLine = false;
            this.lblSequence.Name = "lblSequence";
            this.lblSequence.NoPrint = false;
            this.lblSequence.PrintXOffSet = 0F;
            this.lblSequence.PrintYOffSet = 0F;
            this.lblSequence.Size = new System.Drawing.Size(7, 14);
            this.lblSequence.SymbolType = MedicalSystem.Anes.Document.Controls.MedSymbolType.None;
            this.lblSequence.TabIndex = 0;
            this.lblSequence.Text = "0";
            this.lblSequence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSequence.VarKey = null;
            // 
            // medLabel2
            // 
            this.medLabel2.Appearance.Options.UseTextOptions = true;
            this.medLabel2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medLabel2.BottomLine = false;
            this.medLabel2.DotBorder = false;
            this.medLabel2.Image = null;
            this.medLabel2.Location = new System.Drawing.Point(679, 9);
            this.medLabel2.MultiLine = false;
            this.medLabel2.Name = "medLabel2";
            this.medLabel2.NoPrint = false;
            this.medLabel2.PrintXOffSet = 0F;
            this.medLabel2.PrintYOffSet = 0F;
            this.medLabel2.Size = new System.Drawing.Size(24, 14);
            this.medLabel2.SymbolType = MedicalSystem.Anes.Document.Controls.MedSymbolType.None;
            this.medLabel2.TabIndex = 2;
            this.medLabel2.Text = "台次";
            this.medLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel2.VarKey = null;
            // 
            // lblOperRoom
            // 
            this.lblOperRoom.BackColor = System.Drawing.Color.Transparent;
            this.lblOperRoom.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperRoom.ForeColor = System.Drawing.Color.White;
            this.lblOperRoom.Image = ((System.Drawing.Image)(resources.GetObject("lblOperRoom.Image")));
            this.lblOperRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOperRoom.Location = new System.Drawing.Point(0, 0);
            this.lblOperRoom.Name = "lblOperRoom";
            this.lblOperRoom.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblOperRoom.Size = new System.Drawing.Size(772, 30);
            this.lblOperRoom.TabIndex = 102;
            this.lblOperRoom.Text = "  手术间";
            this.lblOperRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCannel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 41);
            this.panel1.TabIndex = 156;
            // 
            // btnCannel
            // 
            this.btnCannel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnCannel.Location = new System.Drawing.Point(651, 3);
            this.btnCannel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(102, 34);
            this.btnCannel.TabIndex = 86;
            this.btnCannel.Title = "取消";
            this.btnCannel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCannel_BtnClicked);
            // 
            // btnOK
            // 
            this.btnOK.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnOK.Location = new System.Drawing.Point(543, 3);
            this.btnOK.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnOK.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 34);
            this.btnOK.TabIndex = 85;
            this.btnOK.Title = "确认";
            this.btnOK.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnOK_BtnClicked);
            // 
            // TurnToControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radioStatusOperTurnTo);
            this.Controls.Add(this.panel2);
            this.Name = "TurnToControl";
            this.Size = new System.Drawing.Size(772, 163);
            this.Load += new System.EventHandler(this.TurnToControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioStatusOperTurnTo.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioStatusOperTurnTo;
        private System.Windows.Forms.Panel panel2;
        private Document.Controls.MedLabel lblSequence;
        private Document.Controls.MedLabel medLabel2;
        private System.Windows.Forms.Label lblOperRoom;
        private System.Windows.Forms.Panel panel1;
        private FrameWork.ButtonColor btnCannel;
        private FrameWork.ButtonColor btnOK;
    }
}
