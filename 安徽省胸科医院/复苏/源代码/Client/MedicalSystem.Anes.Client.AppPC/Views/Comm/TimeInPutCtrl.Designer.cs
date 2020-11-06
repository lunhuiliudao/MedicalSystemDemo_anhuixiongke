namespace MedicalSystem.Anes.Client.AppPC.Views
{
    partial class TimeInPutCtrl
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
            this.dtpDate = new MedicalSystem.Anes.Client.FrameWork.DateTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.AutoTurnRight = false;
            this.dtpDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(129)))), ((int)(((byte)(232)))));
            this.dtpDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(129)))), ((int)(((byte)(232)))));
            this.dtpDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(129)))), ((int)(((byte)(232)))));
            this.dtpDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(129)))), ((int)(((byte)(232)))));
            this.dtpDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDate.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(30, 44);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowUpDown = true;
            this.dtpDate.Size = new System.Drawing.Size(282, 31);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDate_KeyDown);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label2.Location = new System.Drawing.Point(30, 1);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 16, 0, 3);
            this.label2.Size = new System.Drawing.Size(282, 43);
            this.label2.TabIndex = 8;
            this.label2.Text = "请设置并确认时间点：";
            this.label2.Visible = false;
            // 
            // TimeInPutCtrl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(239)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "TimeInPutCtrl";
            this.Padding = new System.Windows.Forms.Padding(30, 1, 30, 1);
            this.Size = new System.Drawing.Size(342, 122);
            this.Load += new System.EventHandler(this.TimeInPutCtrl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FrameWork.DateTextBox dtpDate;
        private System.Windows.Forms.Label label2;
    }
}
