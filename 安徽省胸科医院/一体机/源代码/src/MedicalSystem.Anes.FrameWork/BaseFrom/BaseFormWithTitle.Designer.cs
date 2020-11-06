namespace MedicalSystem.Anes.FrameWork
{
    partial class BaseFormWithTitle
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
            this.panlHeader = new System.Windows.Forms.Panel();
            this.panelClose = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTopRightBg = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblTopLeftBg = new System.Windows.Forms.Label();
            this.panlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panlHeader
            // 
            this.panlHeader.BackgroundImage = global::MedicalSystem.Anes.FrameWork.Properties.Resources.弹出框标题栏__03;
            this.panlHeader.Controls.Add(this.panelClose);
            this.panlHeader.Controls.Add(this.lblTitle);
            this.panlHeader.Controls.Add(this.lblTopRightBg);
            this.panlHeader.Controls.Add(this.picIcon);
            this.panlHeader.Controls.Add(this.lblTopLeftBg);
            this.panlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panlHeader.Location = new System.Drawing.Point(1, 1);
            this.panlHeader.Name = "panlHeader";
            this.panlHeader.Size = new System.Drawing.Size(434, 51);
            this.panlHeader.TabIndex = 1;
            // 
            // panelClose
            // 
            this.panelClose.BackColor = System.Drawing.Color.Transparent;
            this.panelClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelClose.Location = new System.Drawing.Point(337, 0);
            this.panelClose.Name = "panelClose";
            this.panelClose.Size = new System.Drawing.Size(89, 51);
            this.panelClose.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(64, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(362, 51);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "标题";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseUp);
            // 
            // lblTopRightBg
            // 
            this.lblTopRightBg.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTopRightBg.Image = global::MedicalSystem.Anes.FrameWork.Properties.Resources.弹出框标题栏__05;
            this.lblTopRightBg.Location = new System.Drawing.Point(426, 0);
            this.lblTopRightBg.Name = "lblTopRightBg";
            this.lblTopRightBg.Size = new System.Drawing.Size(8, 51);
            this.lblTopRightBg.TabIndex = 5;
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picIcon.Image = global::MedicalSystem.Anes.FrameWork.Properties.Resources.icon_提示信息;
            this.picIcon.Location = new System.Drawing.Point(8, 0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Padding = new System.Windows.Forms.Padding(10, 6, 10, 10);
            this.picIcon.Size = new System.Drawing.Size(56, 51);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblTopLeftBg
            // 
            this.lblTopLeftBg.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTopLeftBg.Image = global::MedicalSystem.Anes.FrameWork.Properties.Resources.弹出框标题栏__01;
            this.lblTopLeftBg.Location = new System.Drawing.Point(0, 0);
            this.lblTopLeftBg.Name = "lblTopLeftBg";
            this.lblTopLeftBg.Size = new System.Drawing.Size(8, 51);
            this.lblTopLeftBg.TabIndex = 4;
            // 
            // BaseFormWithTitle
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(436, 271);
            this.Controls.Add(this.panlHeader);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.Name = "BaseFormWithTitle";
            this.Text = "标题";
            this.panlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panlHeader;
        protected System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTopLeftBg;
        private System.Windows.Forms.Label lblTopRightBg;
        public System.Windows.Forms.Panel panelClose;


    }
}