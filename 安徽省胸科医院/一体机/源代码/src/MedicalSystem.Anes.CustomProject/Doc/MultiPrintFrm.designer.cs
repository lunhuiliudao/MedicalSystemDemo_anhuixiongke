namespace MedicalSystem.Anes.Custom.CustomProject
{
    partial class MultiPrintFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiPrintFrm));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkDocCheckList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDocCheckList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.chkDocCheckList);
            this.groupBox3.Controls.Add(this.labelControl8);
            this.groupBox3.Location = new System.Drawing.Point(7, -2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 461);
            this.groupBox3.TabIndex = 78;
            this.groupBox3.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(223, 14);
            this.label16.TabIndex = 75;
            this.label16.Text = "系统将会集中打印下列被选中的医疗文书";
            // 
            // chkDocCheckList
            // 
            this.chkDocCheckList.Location = new System.Drawing.Point(6, 77);
            this.chkDocCheckList.Name = "chkDocCheckList";
            this.chkDocCheckList.Size = new System.Drawing.Size(351, 378);
            this.chkDocCheckList.TabIndex = 72;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(6, 47);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(96, 14);
            this.labelControl8.TabIndex = 73;
            this.labelControl8.Text = "选择打印的文书：";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(70, 469);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 31);
            this.btnPrint.TabIndex = 79;
            this.btnPrint.Text = "打 印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(204, 469);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 31);
            this.btnClose.TabIndex = 80;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // MultiPrintFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 512);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultiPrintFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文书打印";
            this.Load += new System.EventHandler(this.MultiPrintFrm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDocCheckList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.CheckedListBoxControl chkDocCheckList;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}