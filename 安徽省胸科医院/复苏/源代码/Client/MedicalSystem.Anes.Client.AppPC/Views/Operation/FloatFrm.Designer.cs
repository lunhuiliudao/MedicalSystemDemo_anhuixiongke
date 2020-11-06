namespace MedicalSystem.Anes.Client.AppPC
{
    partial class FloatFrm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtPinYing = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timeEvent = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPinYing.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtPinYing);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(335, 452);
            this.panelControl1.TabIndex = 10;
            // 
            // txtPinYing
            // 
            this.txtPinYing.EditValue = "";
            this.txtPinYing.Location = new System.Drawing.Point(177, 6);
            this.txtPinYing.Name = "txtPinYing";
            this.txtPinYing.Size = new System.Drawing.Size(153, 21);
            this.txtPinYing.TabIndex = 0;
            this.txtPinYing.ToolTip = "拼音搜索字符串";
            this.txtPinYing.EditValueChanged += new System.EventHandler(this.txtPinYing_EditValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.timeEvent);
            this.panel1.Location = new System.Drawing.Point(10, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 356);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // timeEvent
            // 
            this.timeEvent.CustomFormat = "HH:mm";
            this.timeEvent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeEvent.Location = new System.Drawing.Point(112, 18);
            this.timeEvent.Name = "timeEvent";
            this.timeEvent.Size = new System.Drawing.Size(93, 22);
            this.timeEvent.TabIndex = 4;
            this.timeEvent.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(709, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(615, 440);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btn_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(751, 22);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Properties.MaxLength = 8;
            this.textEdit1.Size = new System.Drawing.Size(47, 21);
            this.textEdit1.TabIndex = 11;
            this.textEdit1.ToolTip = "若为无剂量项目请在键盘输入\"+\"键";
            this.textEdit1.Visible = false;
            // 
            // FloatFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 452);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.Name = "FloatFrm";
            this.Text = "FloatFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FloatFrm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FloatFrm_FormClosed);
            this.Load += new System.EventHandler(this.FloatFrm_Load);
            this.TextChanged += new System.EventHandler(this.FloatFrm_TextChanged);
            this.Resize += new System.EventHandler(this.FloatFrm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPinYing.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtPinYing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker timeEvent;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}