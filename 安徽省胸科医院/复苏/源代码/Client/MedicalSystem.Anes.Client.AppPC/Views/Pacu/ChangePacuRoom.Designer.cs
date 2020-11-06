namespace MedicalSystem.Anes.Client.AppPC
{
    partial class ChangePacuRoom
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentRoom = new System.Windows.Forms.Label();
            this.btnSave = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.btnCannel = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.txtPacuNo = new MedicalSystem.Anes.Client.AppPC.DictTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtPacuNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前复苏床位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "转到复苏床位";
            // 
            // lblCurrentRoom
            // 
            this.lblCurrentRoom.AutoSize = true;
            this.lblCurrentRoom.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentRoom.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentRoom.Location = new System.Drawing.Point(207, 26);
            this.lblCurrentRoom.Name = "lblCurrentRoom";
            this.lblCurrentRoom.Size = new System.Drawing.Size(0, 27);
            this.lblCurrentRoom.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.btnSave.Location = new System.Drawing.Point(89, 140);
            this.btnSave.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnSave.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 34);
            this.btnSave.TabIndex = 87;
            this.btnSave.Title = "确定";
            this.btnSave.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnSave_BtnClicked);
            // 
            // btnCannel
            // 
            this.btnCannel.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.灰色;
            this.btnCannel.Location = new System.Drawing.Point(202, 140);
            this.btnCannel.MaximumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.MinimumSize = new System.Drawing.Size(102, 34);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(102, 34);
            this.btnCannel.TabIndex = 88;
            this.btnCannel.Title = "取消";
            this.btnCannel.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.btnCannel_BtnClicked);
            // 
            // txtPacuNo
            // 
            this.txtPacuNo.BindFieldName = "";
            this.txtPacuNo.BindList = "";
            this.txtPacuNo.BindTableName = "";
            this.txtPacuNo.BorderColor = System.Drawing.Color.LightGray;
            this.txtPacuNo.BottomLine = false;
            this.txtPacuNo.BottomLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txtPacuNo.CanEdit = false;
            this.txtPacuNo.CelerityInputCodeColumnName = "ROOM_NO";
            this.txtPacuNo.CelerityInputSqlWhere = "BED_TYPE=1 AND DEPT_CODE=%config_OpertionDeptCode% AND PATIENT_ID IS NULL";
            this.txtPacuNo.CelerityInputTableName = "MED_OPERATING_ROOM";
            this.txtPacuNo.CelerityInputValueColumnName = "ROOM_NO";
            this.txtPacuNo.Data = null;
            this.txtPacuNo.DefaultPrintText = "";
            this.txtPacuNo.DictTableName = "MED_OPERATING_ROOM";
            this.txtPacuNo.DictValueFieldName = "ROOM_NO";
            this.txtPacuNo.DictWhereString = "BED_TYPE=1 AND DEPT_CODE=%config_OpertionDeptCode% AND PATIENT_ID IS NULL";
            this.txtPacuNo.DisplayFieldName = "ROOM_NO";
            this.txtPacuNo.DisplayMutiColFieldName = "";
            this.txtPacuNo.DotBorder = false;
            this.txtPacuNo.DotNumber = 0;
            this.txtPacuNo.ExamItemName = null;
            this.txtPacuNo.FieldName = "mTextBox1";
            this.txtPacuNo.Format = "";
            this.txtPacuNo.HasLookUpItems = false;
            this.txtPacuNo.InitValue = "";
            this.txtPacuNo.InputNeededMessage = "";
            this.txtPacuNo.InputType = MedicalSystem.Anes.Document.Controls.MedInputType.General;
            this.txtPacuNo.LabItemName = null;
            this.txtPacuNo.LimitedString = "";
            this.txtPacuNo.Location = new System.Drawing.Point(191, 81);
            this.txtPacuNo.LockInput = false;
            this.txtPacuNo.Maximum = null;
            this.txtPacuNo.MaxLength = 0;
            this.txtPacuNo.Minimum = null;
            this.txtPacuNo.Multiline = false;
            this.txtPacuNo.MultiSelect = false;
            this.txtPacuNo.MultiSign = false;
            this.txtPacuNo.Name = "txtPacuNo";
            this.txtPacuNo.NoPrint = false;
            this.txtPacuNo.NoPrintText = "";
            this.txtPacuNo.NullAble = true;
            this.txtPacuNo.OldForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPacuNo.PasswordChar = '\0';
            this.txtPacuNo.PrintTail = "";
            this.txtPacuNo.PrintXOffSet = 0F;
            this.txtPacuNo.PrintYOffSet = 0F;
            this.txtPacuNo.ProgramChanging = false;
            this.txtPacuNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPacuNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPacuNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPacuNo.Properties.LookAndFeel.SkinName = "Blue";
            this.txtPacuNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPacuNo.ReadOnly = false;
            this.txtPacuNo.SelfValue = "";
            this.txtPacuNo.SelfValueChanged = false;
            this.txtPacuNo.Size = new System.Drawing.Size(113, 23);
            this.txtPacuNo.SourceFieldName = "";
            this.txtPacuNo.SourceTableName = "";
            this.txtPacuNo.StoredValue = "";
            this.txtPacuNo.TabIndex = 7;
            this.txtPacuNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPacuNo.UnderLineOffset = 0F;
            this.txtPacuNo.WantValueBeforePrint = "";
            this.txtPacuNo.WordWrap = false;
            // 
            // ChangePacuRoom
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCannel);
            this.Controls.Add(this.txtPacuNo);
            this.Controls.Add(this.lblCurrentRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangePacuRoom";
            this.Size = new System.Drawing.Size(375, 188);
            this.Load += new System.EventHandler(this.ChangePacuRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPacuNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentRoom;
        private DictTextBox txtPacuNo;
        private FrameWork.ButtonColor btnSave;
        private FrameWork.ButtonColor btnCannel;

    }
}
