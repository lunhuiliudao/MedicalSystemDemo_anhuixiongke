namespace MedicalSystem.Anes.Client.AppPC
{
    partial class ConfirmationOutPacu
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
            this.btnCannel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnNext = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.lblInPacuTime = new MedicalSystem.Anes.Document.Controls.MedLabel();
            this.medLabel1 = new MedicalSystem.Anes.Document.Controls.MedLabel();
            this.radioStatusOperTurnTo = new DevExpress.XtraEditors.RadioGroup();
            this.timeControl = new MedicalSystem.Anes.Client.FrameWork.TimeControl();
            this.labelMemo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPACU3H = new DevExpress.XtraEditors.CheckEdit();
            this.medLabel10 = new MedicalSystem.Anes.Document.Controls.MedLabel();
            this.checkPACU_LowTemp = new DevExpress.XtraEditors.CheckEdit();
            this.checkNoPlanToIcu = new DevExpress.XtraEditors.CheckEdit();
            this.chkANES_ANAPHYLAXIS = new DevExpress.XtraEditors.CheckEdit();
            this.chkSPINAL_ANES_COMP = new DevExpress.XtraEditors.CheckEdit();
            this.chkTRACHEA_HOARSE = new DevExpress.XtraEditors.CheckEdit();
            this.chkAFTER_ANES_COMA = new DevExpress.XtraEditors.CheckEdit();
            this.chkOTHER_NOT_EXP = new DevExpress.XtraEditors.CheckEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioStatusOperTurnTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPACU3H.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPACU_LowTemp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNoPlanToIcu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkANES_ANAPHYLAXIS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSPINAL_ANES_COMP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTRACHEA_HOARSE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAFTER_ANES_COMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOTHER_NOT_EXP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCannel);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 48);
            this.panel1.TabIndex = 43;
            // 
            // btnCannel
            // 
            this.btnCannel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.灰色;
            this.btnCannel.Location = new System.Drawing.Point(367, 6);
            this.btnCannel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(102, 34);
            this.btnCannel.TabIndex = 84;
            this.btnCannel.Title = "取消";
            this.btnCannel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCannel_BtnClicked);
            // 
            // btnNext
            // 
            this.btnNext.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnNext.Location = new System.Drawing.Point(248, 6);
            this.btnNext.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnNext.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(102, 34);
            this.btnNext.TabIndex = 83;
            this.btnNext.Title = "确认";
            this.btnNext.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnNext_BtnClicked);
            this.btnNext.Load += new System.EventHandler(this.btnNext_Load);
            // 
            // lblInPacuTime
            // 
            this.lblInPacuTime.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInPacuTime.Appearance.Options.UseFont = true;
            this.lblInPacuTime.Appearance.Options.UseTextOptions = true;
            this.lblInPacuTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblInPacuTime.BottomLine = false;
            this.lblInPacuTime.DotBorder = false;
            this.lblInPacuTime.Image = null;
            this.lblInPacuTime.Location = new System.Drawing.Point(99, 14);
            this.lblInPacuTime.MultiLine = false;
            this.lblInPacuTime.Name = "lblInPacuTime";
            this.lblInPacuTime.NoPrint = false;
            this.lblInPacuTime.PrintXOffSet = 0F;
            this.lblInPacuTime.PrintYOffSet = 0F;
            this.lblInPacuTime.Size = new System.Drawing.Size(68, 19);
            this.lblInPacuTime.SymbolType = MedicalSystem.Anes.Document.Controls.MedSymbolType.None;
            this.lblInPacuTime.TabIndex = 66;
            this.lblInPacuTime.Text = "入室时间";
            this.lblInPacuTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInPacuTime.VarKey = null;
            // 
            // medLabel1
            // 
            this.medLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.medLabel1.Appearance.Options.UseFont = true;
            this.medLabel1.Appearance.Options.UseTextOptions = true;
            this.medLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medLabel1.BottomLine = false;
            this.medLabel1.DotBorder = false;
            this.medLabel1.Image = null;
            this.medLabel1.Location = new System.Drawing.Point(17, 14);
            this.medLabel1.MultiLine = false;
            this.medLabel1.Name = "medLabel1";
            this.medLabel1.NoPrint = false;
            this.medLabel1.PrintXOffSet = 0F;
            this.medLabel1.PrintYOffSet = 0F;
            this.medLabel1.Size = new System.Drawing.Size(64, 19);
            this.medLabel1.SymbolType = MedicalSystem.Anes.Document.Controls.MedSymbolType.None;
            this.medLabel1.TabIndex = 60;
            this.medLabel1.Text = "入室时间";
            this.medLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel1.VarKey = null;
            // 
            // radioStatusOperTurnTo
            // 
            this.radioStatusOperTurnTo.EditValue = 65;
            this.radioStatusOperTurnTo.Location = new System.Drawing.Point(126, 156);
            this.radioStatusOperTurnTo.Name = "radioStatusOperTurnTo";
            this.radioStatusOperTurnTo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioStatusOperTurnTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radioStatusOperTurnTo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.radioStatusOperTurnTo.Properties.Appearance.Options.UseBackColor = true;
            this.radioStatusOperTurnTo.Properties.Appearance.Options.UseFont = true;
            this.radioStatusOperTurnTo.Properties.Appearance.Options.UseForeColor = true;
            this.radioStatusOperTurnTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioStatusOperTurnTo.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(60, "病房"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(65, "ICU"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(67, "离院")});
            this.radioStatusOperTurnTo.Properties.LookAndFeel.SkinName = "Blue";
            this.radioStatusOperTurnTo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.radioStatusOperTurnTo.Size = new System.Drawing.Size(331, 33);
            this.radioStatusOperTurnTo.TabIndex = 127;
            // 
            // timeControl
            // 
            this.timeControl.BackColor = System.Drawing.Color.White;
            this.timeControl.DateTimes = new System.DateTime(2016, 9, 15, 16, 55, 0, 0);
            this.timeControl.Location = new System.Drawing.Point(76, 34);
            this.timeControl.Name = "timeControl";
            this.timeControl.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.timeControl.Size = new System.Drawing.Size(383, 112);
            this.timeControl.StrMemo = "请输入时间：";
            this.timeControl.TabIndex = 131;
            this.timeControl.TimeType = MedicalSystem.Anes.Client.FrameWork.TimeControl.TimeInputType.DateTime;
            // 
            // labelMemo
            // 
            this.labelMemo.AutoSize = true;
            this.labelMemo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelMemo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
            this.labelMemo.Location = new System.Drawing.Point(-2, 48);
            this.labelMemo.Name = "labelMemo";
            this.labelMemo.Size = new System.Drawing.Size(89, 19);
            this.labelMemo.TabIndex = 132;
            this.labelMemo.Text = "出室时间：";
            this.labelMemo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(77)))));
            this.label1.Location = new System.Drawing.Point(3, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 133;
            this.label1.Text = "术后去向：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkPACU3H
            // 
            this.chkPACU3H.Location = new System.Drawing.Point(44, 237);
            this.chkPACU3H.Name = "chkPACU3H";
            this.chkPACU3H.Properties.Caption = "入PACU超过3小时";
            this.chkPACU3H.Properties.LookAndFeel.SkinName = "Blue";
            this.chkPACU3H.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkPACU3H.Size = new System.Drawing.Size(123, 19);
            this.chkPACU3H.TabIndex = 158;
            // 
            // medLabel10
            // 
            this.medLabel10.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medLabel10.Appearance.Options.UseFont = true;
            this.medLabel10.Appearance.Options.UseTextOptions = true;
            this.medLabel10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.medLabel10.BottomLine = false;
            this.medLabel10.DotBorder = false;
            this.medLabel10.Image = null;
            this.medLabel10.Location = new System.Drawing.Point(17, 199);
            this.medLabel10.MultiLine = false;
            this.medLabel10.Name = "medLabel10";
            this.medLabel10.NoPrint = false;
            this.medLabel10.PrintXOffSet = 0F;
            this.medLabel10.PrintYOffSet = 0F;
            this.medLabel10.Size = new System.Drawing.Size(80, 19);
            this.medLabel10.SymbolType = MedicalSystem.Anes.Document.Controls.MedSymbolType.None;
            this.medLabel10.TabIndex = 155;
            this.medLabel10.Text = "非预期事件";
            this.medLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.medLabel10.VarKey = null;
            // 
            // checkPACU_LowTemp
            // 
            this.checkPACU_LowTemp.Location = new System.Drawing.Point(289, 237);
            this.checkPACU_LowTemp.Name = "checkPACU_LowTemp";
            this.checkPACU_LowTemp.Properties.Caption = "PACU入室低体温";
            this.checkPACU_LowTemp.Properties.LookAndFeel.SkinName = "Blue";
            this.checkPACU_LowTemp.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkPACU_LowTemp.Size = new System.Drawing.Size(123, 19);
            this.checkPACU_LowTemp.TabIndex = 159;
            // 
            // checkNoPlanToIcu
            // 
            this.checkNoPlanToIcu.Location = new System.Drawing.Point(44, 274);
            this.checkNoPlanToIcu.Name = "checkNoPlanToIcu";
            this.checkNoPlanToIcu.Properties.Caption = "非计划转入ICU";
            this.checkNoPlanToIcu.Properties.LookAndFeel.SkinName = "Blue";
            this.checkNoPlanToIcu.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkNoPlanToIcu.Size = new System.Drawing.Size(123, 19);
            this.checkNoPlanToIcu.TabIndex = 160;
            // 
            // chkANES_ANAPHYLAXIS
            // 
            this.chkANES_ANAPHYLAXIS.Location = new System.Drawing.Point(289, 315);
            this.chkANES_ANAPHYLAXIS.Name = "chkANES_ANAPHYLAXIS";
            this.chkANES_ANAPHYLAXIS.Properties.Caption = "麻醉期间发生严重过敏反应";
            this.chkANES_ANAPHYLAXIS.Properties.LookAndFeel.SkinName = "Blue";
            this.chkANES_ANAPHYLAXIS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkANES_ANAPHYLAXIS.Size = new System.Drawing.Size(183, 19);
            this.chkANES_ANAPHYLAXIS.TabIndex = 171;
            // 
            // chkSPINAL_ANES_COMP
            // 
            this.chkSPINAL_ANES_COMP.Location = new System.Drawing.Point(44, 358);
            this.chkSPINAL_ANES_COMP.Name = "chkSPINAL_ANES_COMP";
            this.chkSPINAL_ANES_COMP.Properties.Caption = "椎管内麻醉后严重并发症";
            this.chkSPINAL_ANES_COMP.Properties.LookAndFeel.SkinName = "Blue";
            this.chkSPINAL_ANES_COMP.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkSPINAL_ANES_COMP.Size = new System.Drawing.Size(161, 19);
            this.chkSPINAL_ANES_COMP.TabIndex = 170;
            // 
            // chkTRACHEA_HOARSE
            // 
            this.chkTRACHEA_HOARSE.Location = new System.Drawing.Point(44, 315);
            this.chkTRACHEA_HOARSE.Name = "chkTRACHEA_HOARSE";
            this.chkTRACHEA_HOARSE.Properties.Caption = "全麻气管插管拔管后声音嘶哑";
            this.chkTRACHEA_HOARSE.Properties.LookAndFeel.SkinName = "Blue";
            this.chkTRACHEA_HOARSE.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkTRACHEA_HOARSE.Size = new System.Drawing.Size(185, 19);
            this.chkTRACHEA_HOARSE.TabIndex = 168;
            // 
            // chkAFTER_ANES_COMA
            // 
            this.chkAFTER_ANES_COMA.Location = new System.Drawing.Point(289, 274);
            this.chkAFTER_ANES_COMA.Name = "chkAFTER_ANES_COMA";
            this.chkAFTER_ANES_COMA.Properties.Caption = "麻醉后新发昏迷";
            this.chkAFTER_ANES_COMA.Properties.LookAndFeel.SkinName = "Blue";
            this.chkAFTER_ANES_COMA.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkAFTER_ANES_COMA.Size = new System.Drawing.Size(123, 19);
            this.chkAFTER_ANES_COMA.TabIndex = 163;
            // 
            // chkOTHER_NOT_EXP
            // 
            this.chkOTHER_NOT_EXP.Location = new System.Drawing.Point(289, 358);
            this.chkOTHER_NOT_EXP.Name = "chkOTHER_NOT_EXP";
            this.chkOTHER_NOT_EXP.Properties.Caption = "其它非预期事件";
            this.chkOTHER_NOT_EXP.Properties.LookAndFeel.SkinName = "Blue";
            this.chkOTHER_NOT_EXP.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkOTHER_NOT_EXP.Size = new System.Drawing.Size(123, 19);
            this.chkOTHER_NOT_EXP.TabIndex = 162;
            // 
            // ConfirmationOutPacu
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.chkANES_ANAPHYLAXIS);
            this.Controls.Add(this.chkSPINAL_ANES_COMP);
            this.Controls.Add(this.chkTRACHEA_HOARSE);
            this.Controls.Add(this.chkAFTER_ANES_COMA);
            this.Controls.Add(this.chkOTHER_NOT_EXP);
            this.Controls.Add(this.checkNoPlanToIcu);
            this.Controls.Add(this.checkPACU_LowTemp);
            this.Controls.Add(this.chkPACU3H);
            this.Controls.Add(this.medLabel10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMemo);
            this.Controls.Add(this.timeControl);
            this.Controls.Add(this.radioStatusOperTurnTo);
            this.Controls.Add(this.lblInPacuTime);
            this.Controls.Add(this.medLabel1);
            this.Controls.Add(this.panel1);
            this.Name = "ConfirmationOutPacu";
            this.Size = new System.Drawing.Size(500, 442);
            this.Load += new System.EventHandler(this.ConfirmationOutPacu_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioStatusOperTurnTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPACU3H.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPACU_LowTemp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNoPlanToIcu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkANES_ANAPHYLAXIS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSPINAL_ANES_COMP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTRACHEA_HOARSE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAFTER_ANES_COMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOTHER_NOT_EXP.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Document.Controls.MedLabel medLabel1;
        private Document.Controls.MedLabel lblInPacuTime;
        private FrameWork.ButtonColor btnCannel;
        private FrameWork.ButtonColor btnNext;
        private DevExpress.XtraEditors.RadioGroup radioStatusOperTurnTo;
        private FrameWork.TimeControl timeControl;
        private System.Windows.Forms.Label labelMemo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckEdit chkPACU3H;
        private Document.Controls.MedLabel medLabel10;
        private DevExpress.XtraEditors.CheckEdit checkPACU_LowTemp;
        private DevExpress.XtraEditors.CheckEdit checkNoPlanToIcu;
        private DevExpress.XtraEditors.CheckEdit chkANES_ANAPHYLAXIS;
        private DevExpress.XtraEditors.CheckEdit chkSPINAL_ANES_COMP;
        private DevExpress.XtraEditors.CheckEdit chkTRACHEA_HOARSE;
        private DevExpress.XtraEditors.CheckEdit chkAFTER_ANES_COMA;
        private DevExpress.XtraEditors.CheckEdit chkOTHER_NOT_EXP;
    }
}
