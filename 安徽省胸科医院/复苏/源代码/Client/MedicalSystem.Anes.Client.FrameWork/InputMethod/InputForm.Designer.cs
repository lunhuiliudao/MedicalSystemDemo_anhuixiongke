namespace MedicalSystem.Anes.Client.FrameWork
{
    partial class InputForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.listBoxGroup = new System.Windows.Forms.ListBox();
            this.btnInputType = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.PictureBox();
            this.btnPrevious = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxResult
            // 
            this.listBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxResult.Font = new System.Drawing.Font("宋体", 15F);
            this.listBoxResult.ForeColor = System.Drawing.Color.Blue;
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.ItemHeight = 20;
            this.listBoxResult.Location = new System.Drawing.Point(0, 0);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(464, 20);
            this.listBoxResult.TabIndex = 1;
            // 
            // listBoxGroup
            // 
            this.listBoxGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxGroup.Font = new System.Drawing.Font("宋体", 10F);
            this.listBoxGroup.ForeColor = System.Drawing.Color.Blue;
            this.listBoxGroup.FormattingEnabled = true;
            this.listBoxGroup.Location = new System.Drawing.Point(0, 70);
            this.listBoxGroup.Name = "listBoxGroup";
            this.listBoxGroup.Size = new System.Drawing.Size(484, 0);
            this.listBoxGroup.TabIndex = 1;
            // 
            // btnInputType
            // 
            this.btnInputType.AutoSize = true;
            this.btnInputType.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnInputType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnInputType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnInputType.Location = new System.Drawing.Point(373, 0);
            this.btnInputType.Name = "btnInputType";
            this.btnInputType.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnInputType.Size = new System.Drawing.Size(25, 26);
            this.btnInputType.TabIndex = 3;
            this.btnInputType.Text = "数";
            this.btnInputType.Click += new System.EventHandler(this.btnInputType_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.AutoSize = true;
            this.textBoxInput.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.textBoxInput.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxInput.Location = new System.Drawing.Point(9, 6);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.textBoxInput.Size = new System.Drawing.Size(0, 29);
            this.textBoxInput.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = global::MedicalSystem.Anes.Client.FrameWork.Properties.Resources.InputMethodlogo;
            this.pictureBox2.Location = new System.Drawing.Point(398, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 41);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Image = global::MedicalSystem.Anes.Client.FrameWork.Properties.Resources.InputMethodRight1;
            this.btnNext.Location = new System.Drawing.Point(474, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(10, 25);
            this.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnNext.TabIndex = 4;
            this.btnNext.TabStop = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrevious.Image = global::MedicalSystem.Anes.Client.FrameWork.Properties.Resources.InputMethodLeft1;
            this.btnPrevious.Location = new System.Drawing.Point(464, 0);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(10, 25);
            this.btnPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxInput);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnInputType);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxResult);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrevious);
            this.splitContainer1.Panel2.Controls.Add(this.btnNext);
            this.splitContainer1.Size = new System.Drawing.Size(484, 70);
            this.splitContainer1.SplitterDistance = 41;
            this.splitContainer1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(0, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1217, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // InputForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 47);
            this.Controls.Add(this.listBoxGroup);
            this.Controls.Add(this.splitContainer1);
            this.Name = "InputForm";
            this.Text = "输入法";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InputForm_FormClosed);
            this.Load += new System.EventHandler(this.InputForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevious)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.ListBox listBoxGroup;
        private System.Windows.Forms.Label btnInputType;
        private System.Windows.Forms.PictureBox btnPrevious;
        private System.Windows.Forms.PictureBox btnNext;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label textBoxInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
    }
}

