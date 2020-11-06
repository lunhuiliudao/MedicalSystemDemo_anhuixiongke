namespace MedicalSystem.Anes.FrameWork
{
    partial class DialogHostFormPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogHostFormPC));
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.panelClose.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Size = new System.Drawing.Size(56, 30);
            // 
            // panelClose
            // 
            this.panelClose.Controls.Add(this.picClose);
            this.panelClose.Location = new System.Drawing.Point(268, 0);
            this.panelClose.Size = new System.Drawing.Size(150, 30);
            this.panelClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panelClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panelClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(212, 30);
            // 
            // panlHeader
            // 
            this.panlHeader.BackColor = System.Drawing.Color.White;
            this.panlHeader.BackgroundImage = null;
            this.panlHeader.Location = new System.Drawing.Point(1, 3);
            this.panlHeader.Size = new System.Drawing.Size(418, 30);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTitle.Size = new System.Drawing.Size(212, 30);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.picClose.Image = global::MedicalSystem.Anes.FrameWork.Properties.Resources.x2_1;
            this.picClose.Location = new System.Drawing.Point(108, 0);
            this.picClose.Name = "picClose";
            this.picClose.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.picClose.Size = new System.Drawing.Size(42, 30);
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(1, 33);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panelMain.Size = new System.Drawing.Size(418, 276);
            this.panelMain.TabIndex = 7;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 2);
            this.panel1.TabIndex = 5;
            // 
            // DialogHostFormPC
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 310);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogHostFormPC";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DialogHostForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DialogHostFormPC_Paint);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panlHeader, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.panelClose.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panelMain;
    }
}