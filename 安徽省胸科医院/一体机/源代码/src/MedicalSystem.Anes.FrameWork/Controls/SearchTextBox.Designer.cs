namespace MedicalSystem.Anes.FrameWork
{
    partial class SearchTextBox
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
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxValue
            // 
            this.textBoxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxValue.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(147)))), ((int)(((byte)(210)))));
            this.textBoxValue.Location = new System.Drawing.Point(6, 3);
            this.textBoxValue.Multiline = true;
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(260, 24);
            this.textBoxValue.TabIndex = 2;
            this.textBoxValue.TextChanged += new System.EventHandler(this.textBoxValue_TextChanged);
            this.textBoxValue.Enter += new System.EventHandler(this.textBoxValue_Enter);
            this.textBoxValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxValue_KeyDown);
            this.textBoxValue.Leave += new System.EventHandler(this.textBoxValue_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Image = global::MedicalSystem.Anes.FrameWork.Properties.Resources.搜索1;
            this.btnSearch.Location = new System.Drawing.Point(268, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 29);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TabStop = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SearchTextBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.btnSearch);
            this.Name = "SearchTextBox";
            this.Size = new System.Drawing.Size(299, 29);
            this.Load += new System.EventHandler(this.SearchTextBox_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SearchTextBox_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnSearch;
        private System.Windows.Forms.TextBox textBoxValue;
    }
}
