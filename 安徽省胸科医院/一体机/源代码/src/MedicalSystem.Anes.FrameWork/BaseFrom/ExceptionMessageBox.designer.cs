namespace MedicalSystem.Anes.FrameWork
{
    partial class ExceptionMessageBox
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelBorder1 = new MedicalSystem.Anes.FrameWork.PanelBorder();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new MedicalSystem.Anes.FrameWork.ButtonBorder();
            this.btnDetails = new MedicalSystem.Anes.FrameWork.ButtonBorder();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelBorder1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelBorder1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 52);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panel2.Size = new System.Drawing.Size(518, 197);
            this.panel2.TabIndex = 17;
            // 
            // panelBorder1
            // 
            this.panelBorder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.panelBorder1.Controls.Add(this.txtMessage);
            this.panelBorder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorder1.Location = new System.Drawing.Point(20, 10);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Padding = new System.Windows.Forms.Padding(10);
            this.panelBorder1.Size = new System.Drawing.Size(478, 177);
            this.panelBorder1.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txtMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtMessage.Location = new System.Drawing.Point(10, 10);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(458, 157);
            this.txtMessage.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 50);
            this.panel1.TabIndex = 16;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(237)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(314, 11);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 27);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(237)))));
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(409, 11);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(89, 27);
            this.btnDetails.TabIndex = 3;
            this.btnDetails.Text = "详细信息";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // ExceptionMessageBox
            // 
            this.ClientSize = new System.Drawing.Size(520, 300);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ExceptionMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "详细错误说明";
            this.Load += new System.EventHandler(this.ExceptionMessageBox_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelBorder1.ResumeLayout(false);
            this.panelBorder1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private ButtonBorder btnOk;
        private ButtonBorder btnDetails;
        private System.Windows.Forms.TextBox txtMessage;
        private PanelBorder panelBorder1;

    }
}