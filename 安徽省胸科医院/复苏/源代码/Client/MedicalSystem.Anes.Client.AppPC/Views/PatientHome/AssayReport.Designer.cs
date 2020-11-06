namespace MedicalSystem.Anes.Client.AppPC
{
    partial class AssayReport
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssayReport));
            this.treeViewExtendList = new MedicalSystem.Anes.Client.FrameWork.TreeViewExtend(this.components);
            this.dgList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelList = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonColor1 = new MedicalSystem.Anes.Client.FrameWork.ButtonColor();
            this.labelCount = new System.Windows.Forms.Label();
            this.medScrollbar1 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            this.medScrollbar2 = new MedicalSystem.Anes.Document.Controls.MedScrollbar();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.panelList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewExtendList
            // 
            this.treeViewExtendList.BackColor = System.Drawing.Color.White;
            this.treeViewExtendList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewExtendList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeViewExtendList.Font = new System.Drawing.Font("Tahoma", 12F);
            this.treeViewExtendList.FullRowSelect = true;
            this.treeViewExtendList.HideSelection = false;
            this.treeViewExtendList.HotTracking = true;
            this.treeViewExtendList.ItemHeight = 50;
            this.treeViewExtendList.Location = new System.Drawing.Point(1, 5);
            this.treeViewExtendList.Name = "treeViewExtendList";
            this.treeViewExtendList.Scrollable = false;
            this.treeViewExtendList.Size = new System.Drawing.Size(309, 701);
            this.treeViewExtendList.TabIndex = 10;
            this.treeViewExtendList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewExtendList_AfterSelect);
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AllowUserToResizeColumns = false;
            this.dgList.AllowUserToResizeRows = false;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgList.BackgroundColor = System.Drawing.Color.White;
            this.dgList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(138)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.ColumnHeadersHeight = 36;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.EnableHeadersVisualStyles = false;
            this.dgList.Location = new System.Drawing.Point(314, 45);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.RowHeadersVisible = false;
            this.dgList.RowHeadersWidth = 22;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgList.Size = new System.Drawing.Size(877, 709);
            this.dgList.TabIndex = 95;
            this.dgList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgList_RowPrePaint);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "REPORT_ITEM_NAME";
            this.Column1.HeaderText = "报告项目名称";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RESULT";
            this.Column2.HeaderText = "结果";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "UNITS";
            this.Column3.HeaderText = "单位";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ABNORMAL_INDICATOR";
            this.Column5.HeaderText = "标志";
            this.Column5.Name = "Column5";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "REFERENCE_RESULT";
            this.Column4.HeaderText = "参考值";
            this.Column4.Name = "Column4";
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.treeViewExtendList);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelList.Location = new System.Drawing.Point(0, 45);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(314, 709);
            this.panelList.TabIndex = 96;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonColor1);
            this.panel1.Controls.Add(this.labelCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1191, 45);
            this.panel1.TabIndex = 98;
            // 
            // buttonColor1
            // 
            this.buttonColor1.ButtonColorType = MedicalSystem.Anes.Client.FrameWork.ButtonColor.ButtonType.蓝色;
            this.buttonColor1.Location = new System.Drawing.Point(3, 6);
            this.buttonColor1.MaximumSize = new System.Drawing.Size(102, 34);
            this.buttonColor1.MinimumSize = new System.Drawing.Size(102, 34);
            this.buttonColor1.Name = "buttonColor1";
            this.buttonColor1.Size = new System.Drawing.Size(102, 34);
            this.buttonColor1.TabIndex = 2;
            this.buttonColor1.Title = "异常值";
            this.buttonColor1.BtnClicked += new MedicalSystem.Anes.Client.FrameWork.ButtonColor.BtnClickHandle(this.buttonColor1_BtnClicked);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelCount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelCount.Location = new System.Drawing.Point(1191, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.labelCount.Size = new System.Drawing.Size(0, 29);
            this.labelCount.TabIndex = 0;
            // 
            // medScrollbar1
            // 
            this.medScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar1.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.DownArrowImage")));
            this.medScrollbar1.LargeChange = 10;
            this.medScrollbar1.Location = new System.Drawing.Point(298, 46);
            this.medScrollbar1.Maximum = 100;
            this.medScrollbar1.Minimum = 0;
            this.medScrollbar1.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar1.Name = "medScrollbar1";
            this.medScrollbar1.Size = new System.Drawing.Size(15, 707);
            this.medScrollbar1.SmallChange = 1;
            this.medScrollbar1.TabIndex = 11;
            this.medScrollbar1.ThisControl = this.panelList;
            this.medScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomImage")));
            this.medScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbBottomSpanImage")));
            this.medScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbMiddleImage")));
            this.medScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopImage")));
            this.medScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.ThumbTopSpanImage")));
            this.medScrollbar1.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar1.UpArrowImage")));
            this.medScrollbar1.Value = 0;
            // 
            // medScrollbar2
            // 
            this.medScrollbar2.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(239)))));
            this.medScrollbar2.DownArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.DownArrowImage")));
            this.medScrollbar2.LargeChange = 10;
            this.medScrollbar2.Location = new System.Drawing.Point(1175, 46);
            this.medScrollbar2.Maximum = 100;
            this.medScrollbar2.Minimum = 0;
            this.medScrollbar2.MinimumSize = new System.Drawing.Size(15, 92);
            this.medScrollbar2.Name = "medScrollbar2";
            this.medScrollbar2.Size = new System.Drawing.Size(15, 707);
            this.medScrollbar2.SmallChange = 1;
            this.medScrollbar2.TabIndex = 99;
            this.medScrollbar2.ThisControl = this.dgList;
            this.medScrollbar2.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbBottomImage")));
            this.medScrollbar2.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbBottomSpanImage")));
            this.medScrollbar2.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbMiddleImage")));
            this.medScrollbar2.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbTopImage")));
            this.medScrollbar2.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.ThumbTopSpanImage")));
            this.medScrollbar2.UpArrowImage = ((System.Drawing.Image)(resources.GetObject("medScrollbar2.UpArrowImage")));
            this.medScrollbar2.Value = 0;
            // 
            // AssayReport
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.medScrollbar2);
            this.Controls.Add(this.medScrollbar1);
            this.Controls.Add(this.dgList);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panel1);
            this.Name = "AssayReport";
            this.Size = new System.Drawing.Size(1191, 754);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.panelList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FrameWork.TreeViewExtend treeViewExtendList;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private FrameWork.ButtonColor buttonColor1;
        private Document.Controls.MedScrollbar medScrollbar1;
        private Document.Controls.MedScrollbar medScrollbar2;



    }
}
