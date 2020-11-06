namespace MedicalSystem.Anes.FrameWork
{
    partial class DialogBaseDocForm
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
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTopLeftBg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panlHeader
            // 
            this.panlHeader.BackColor = System.Drawing.Color.Silver;
            this.panlHeader.Controls.Add(this.lblTitle);
            this.panlHeader.Controls.Add(this.picIcon);
            this.panlHeader.Controls.Add(this.picClose);
            this.panlHeader.Controls.Add(this.label4);
            this.panlHeader.Controls.Add(this.label1);
            this.panlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panlHeader.Location = new System.Drawing.Point(0, 0);
            this.panlHeader.Name = "panlHeader";
            this.panlHeader.Size = new System.Drawing.Size(659, 28);
            this.panlHeader.TabIndex = 2;
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picIcon.Location = new System.Drawing.Point(8, 0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Padding = new System.Windows.Forms.Padding(10, 6, 10, 10);
            this.picIcon.Size = new System.Drawing.Size(33, 28);
            this.picIcon.TabIndex = 9;
            this.picIcon.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(651, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(8, 28);
            this.label4.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(8, 28);
            this.label1.TabIndex = 5;
            // 
            // lblTopLeftBg
            // 
            this.lblTopLeftBg.BackColor = System.Drawing.Color.Silver;
            this.lblTopLeftBg.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTopLeftBg.Location = new System.Drawing.Point(0, 28);
            this.lblTopLeftBg.Name = "lblTopLeftBg";
            this.lblTopLeftBg.Size = new System.Drawing.Size(8, 466);
            this.lblTopLeftBg.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(8, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(651, 10);
            this.label2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(651, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 456);
            this.label3.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(41, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(580, 28);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "标题";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.BackgroundImage = global::MedicalSystem.Anes.FrameWork.Properties.Resources.x1;
            this.picClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.picClose.ErrorImage = null;
            this.picClose.InitialImage = null;
            this.picClose.Location = new System.Drawing.Point(621, 0);
            this.picClose.Name = "picClose";
            this.picClose.Padding = new System.Windows.Forms.Padding(10, 6, 10, 10);
            this.picClose.Size = new System.Drawing.Size(30, 28);
            this.picClose.TabIndex = 11;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // DialogBaseDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 494);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTopLeftBg);
            this.Controls.Add(this.panlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogBaseDocForm";
            this.Text = "DialogBaseDocForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DialogBaseDocForm_FormClosing);
            this.panlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panlHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTopLeftBg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.PictureBox picClose;
    }
}