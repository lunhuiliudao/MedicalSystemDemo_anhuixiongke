namespace MedicalSystem.Anes.FrameWork
{
    partial class DialogHostMainFormPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogHostMainFormPC));
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pciMax = new System.Windows.Forms.PictureBox();
            this.picMin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.panelClose.SuspendLayout();
            this.panlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pciMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Size = new System.Drawing.Size(56, 50);
            // 
            // panelClose
            // 
            this.panelClose.Controls.Add(this.pciMax);
            this.panelClose.Controls.Add(this.picMin);
            this.panelClose.Controls.Add(this.picClose);
            this.panelClose.Location = new System.Drawing.Point(370, 0);
            this.panelClose.Size = new System.Drawing.Size(150, 50);
            this.panelClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panelClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panelClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(314, 50);
            // 
            // panlHeader
            // 
            this.panlHeader.BackgroundImage = global::MedicalSystem.Anes.FrameWork.Properties.Resources.title1;
            this.panlHeader.Size = new System.Drawing.Size(520, 50);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.picClose.Image = global::MedicalSystem.Anes.FrameWork.Properties.Resources.x1;
            this.picClose.Location = new System.Drawing.Point(108, 0);
            this.picClose.Name = "picClose";
            this.picClose.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.picClose.Size = new System.Drawing.Size(42, 50);
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseDown);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            this.picClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseUp);
            // 
            // pciMax
            // 
            this.pciMax.BackColor = System.Drawing.Color.Transparent;
            this.pciMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.pciMax.Image = global::MedicalSystem.Anes.FrameWork.Properties.Resources.窗口1;
            this.pciMax.Location = new System.Drawing.Point(24, 0);
            this.pciMax.Name = "pciMax";
            this.pciMax.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pciMax.Size = new System.Drawing.Size(42, 50);
            this.pciMax.TabIndex = 2;
            this.pciMax.TabStop = false;
            this.pciMax.Click += new System.EventHandler(this.pciMax_Click);
            this.pciMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pciMax_MouseDown);
            this.pciMax.MouseEnter += new System.EventHandler(this.pciMax_MouseEnter);
            this.pciMax.MouseLeave += new System.EventHandler(this.pciMax_MouseLeave);
            this.pciMax.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pciMax_MouseUp);
            // 
            // picMin
            // 
            this.picMin.BackColor = System.Drawing.Color.Transparent;
            this.picMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.picMin.Image = global::MedicalSystem.Anes.FrameWork.Properties.Resources.最小化1;
            this.picMin.Location = new System.Drawing.Point(66, 0);
            this.picMin.Name = "picMin";
            this.picMin.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.picMin.Size = new System.Drawing.Size(42, 50);
            this.picMin.TabIndex = 3;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            this.picMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMin_MouseDown);
            this.picMin.MouseEnter += new System.EventHandler(this.picMin_MouseEnter);
            this.picMin.MouseLeave += new System.EventHandler(this.picMin_MouseLeave);
            this.picMin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picMin_MouseUp);
            // 
            // DialogHostMainFormPC
            // 
            this.ClientSize = new System.Drawing.Size(522, 292);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogHostMainFormPC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DialogHostForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.panelClose.ResumeLayout(false);
            this.panlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pciMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox pciMax;

    }
}