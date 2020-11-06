namespace MedicalSystem.Anes.Client.AppPC.Views.DailySchedule
{
    partial class EditSchedule
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
            this.buttonBorder1 = new MedicalSystem.Anes.Client.FrameWork.ButtonBorder();
            this.btnOk = new MedicalSystem.Anes.Client.FrameWork.ButtonBorder();
            this.panelBorder1 = new MedicalSystem.Anes.Client.FrameWork.PanelBorder();
            this.panelNoFlash2 = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.rbtnSTATE1 = new System.Windows.Forms.RadioButton();
            this.rbtnSTATE0 = new System.Windows.Forms.RadioButton();
            this.panelNoFlash1 = new MedicalSystem.Anes.Client.FrameWork.PanelNoFlash();
            this.rbtnTYPE1 = new System.Windows.Forms.RadioButton();
            this.rbtnTYPE0 = new System.Windows.Forms.RadioButton();
            this.txtCONTENT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labDAILYNO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBorder1.SuspendLayout();
            this.panelNoFlash2.SuspendLayout();
            this.panelNoFlash1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBorder1
            // 
            this.buttonBorder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonBorder1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorder1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.buttonBorder1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.buttonBorder1.Location = new System.Drawing.Point(630, 403);
            this.buttonBorder1.Name = "buttonBorder1";
            this.buttonBorder1.Size = new System.Drawing.Size(89, 27);
            this.buttonBorder1.TabIndex = 4;
            this.buttonBorder1.Text = "取消";
            this.buttonBorder1.UseVisualStyleBackColor = false;
            this.buttonBorder1.Click += new System.EventHandler(this.buttonBorder1_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(205)))), ((int)(((byte)(158)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(535, 403);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 27);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "提交";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelBorder1
            // 
            this.panelBorder1.Controls.Add(this.panelNoFlash2);
            this.panelBorder1.Controls.Add(this.panelNoFlash1);
            this.panelBorder1.Controls.Add(this.txtCONTENT);
            this.panelBorder1.Controls.Add(this.label5);
            this.panelBorder1.Controls.Add(this.label4);
            this.panelBorder1.Controls.Add(this.label3);
            this.panelBorder1.Controls.Add(this.labDAILYNO);
            this.panelBorder1.Controls.Add(this.label1);
            this.panelBorder1.DashPattern = new float[] {
        3F,
        1F};
            this.panelBorder1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.panelBorder1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorder1.Location = new System.Drawing.Point(0, 0);
            this.panelBorder1.Name = "panelBorder1";
            this.panelBorder1.Size = new System.Drawing.Size(760, 397);
            this.panelBorder1.TabIndex = 0;
            // 
            // panelNoFlash2
            // 
            this.panelNoFlash2.Controls.Add(this.rbtnSTATE1);
            this.panelNoFlash2.Controls.Add(this.rbtnSTATE0);
            this.panelNoFlash2.Location = new System.Drawing.Point(96, 102);
            this.panelNoFlash2.Name = "panelNoFlash2";
            this.panelNoFlash2.Size = new System.Drawing.Size(207, 24);
            this.panelNoFlash2.TabIndex = 7;
            // 
            // rbtnSTATE1
            // 
            this.rbtnSTATE1.AutoSize = true;
            this.rbtnSTATE1.Checked = true;
            this.rbtnSTATE1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.rbtnSTATE1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rbtnSTATE1.Location = new System.Drawing.Point(94, 3);
            this.rbtnSTATE1.Name = "rbtnSTATE1";
            this.rbtnSTATE1.Size = new System.Drawing.Size(70, 18);
            this.rbtnSTATE1.TabIndex = 1;
            this.rbtnSTATE1.TabStop = true;
            this.rbtnSTATE1.Text = "已完结";
            this.rbtnSTATE1.UseVisualStyleBackColor = true;
            // 
            // rbtnSTATE0
            // 
            this.rbtnSTATE0.AutoSize = true;
            this.rbtnSTATE0.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.rbtnSTATE0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rbtnSTATE0.Location = new System.Drawing.Point(3, 3);
            this.rbtnSTATE0.Name = "rbtnSTATE0";
            this.rbtnSTATE0.Size = new System.Drawing.Size(70, 18);
            this.rbtnSTATE0.TabIndex = 0;
            this.rbtnSTATE0.Text = "未完结";
            this.rbtnSTATE0.UseVisualStyleBackColor = true;
            // 
            // panelNoFlash1
            // 
            this.panelNoFlash1.Controls.Add(this.rbtnTYPE1);
            this.panelNoFlash1.Controls.Add(this.rbtnTYPE0);
            this.panelNoFlash1.Location = new System.Drawing.Point(96, 59);
            this.panelNoFlash1.Name = "panelNoFlash1";
            this.panelNoFlash1.Size = new System.Drawing.Size(207, 24);
            this.panelNoFlash1.TabIndex = 6;
            // 
            // rbtnTYPE1
            // 
            this.rbtnTYPE1.AutoSize = true;
            this.rbtnTYPE1.Checked = true;
            this.rbtnTYPE1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.rbtnTYPE1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rbtnTYPE1.Location = new System.Drawing.Point(94, 3);
            this.rbtnTYPE1.Name = "rbtnTYPE1";
            this.rbtnTYPE1.Size = new System.Drawing.Size(85, 18);
            this.rbtnTYPE1.TabIndex = 1;
            this.rbtnTYPE1.TabStop = true;
            this.rbtnTYPE1.Text = "日常记录";
            this.rbtnTYPE1.UseVisualStyleBackColor = true;
            // 
            // rbtnTYPE0
            // 
            this.rbtnTYPE0.AutoSize = true;
            this.rbtnTYPE0.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.rbtnTYPE0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.rbtnTYPE0.Location = new System.Drawing.Point(3, 3);
            this.rbtnTYPE0.Name = "rbtnTYPE0";
            this.rbtnTYPE0.Size = new System.Drawing.Size(85, 18);
            this.rbtnTYPE0.TabIndex = 0;
            this.rbtnTYPE0.Text = "工作计划";
            this.rbtnTYPE0.UseVisualStyleBackColor = true;
            // 
            // txtCONTENT
            // 
            this.txtCONTENT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.txtCONTENT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCONTENT.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txtCONTENT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtCONTENT.Location = new System.Drawing.Point(41, 165);
            this.txtCONTENT.Multiline = true;
            this.txtCONTENT.Name = "txtCONTENT";
            this.txtCONTENT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCONTENT.Size = new System.Drawing.Size(678, 214);
            this.txtCONTENT.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(211)))));
            this.label5.Location = new System.Drawing.Point(38, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "内容：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(211)))));
            this.label4.Location = new System.Drawing.Point(38, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(211)))));
            this.label3.Location = new System.Drawing.Point(38, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "类型：";
            // 
            // labDAILYNO
            // 
            this.labDAILYNO.AutoSize = true;
            this.labDAILYNO.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.labDAILYNO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(211)))));
            this.labDAILYNO.Location = new System.Drawing.Point(96, 19);
            this.labDAILYNO.Name = "labDAILYNO";
            this.labDAILYNO.Size = new System.Drawing.Size(15, 14);
            this.labDAILYNO.TabIndex = 1;
            this.labDAILYNO.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(211)))));
            this.label1.Location = new System.Drawing.Point(38, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "序号：";
            // 
            // EditSchedule
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonBorder1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panelBorder1);
            this.Name = "EditSchedule";
            this.Size = new System.Drawing.Size(760, 440);
            this.panelBorder1.ResumeLayout(false);
            this.panelBorder1.PerformLayout();
            this.panelNoFlash2.ResumeLayout(false);
            this.panelNoFlash2.PerformLayout();
            this.panelNoFlash1.ResumeLayout(false);
            this.panelNoFlash1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FrameWork.PanelBorder panelBorder1;
        private FrameWork.ButtonBorder btnOk;
        private FrameWork.ButtonBorder buttonBorder1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labDAILYNO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCONTENT;
        private FrameWork.PanelNoFlash panelNoFlash1;
        private System.Windows.Forms.RadioButton rbtnTYPE1;
        private System.Windows.Forms.RadioButton rbtnTYPE0;
        private FrameWork.PanelNoFlash panelNoFlash2;
        private System.Windows.Forms.RadioButton rbtnSTATE1;
        private System.Windows.Forms.RadioButton rbtnSTATE0;
    }
}
