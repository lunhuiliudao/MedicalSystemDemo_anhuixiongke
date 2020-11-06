namespace MedicalSystem.Anes.Document.Designer.Controler
{
    partial class TableCreatorDlg
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAvgRow = new DevExpress.XtraEditors.SimpleButton();
            this.xtraSCRow = new DevExpress.XtraEditors.XtraScrollableControl();
            this.spinEditRow = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAvgCol = new DevExpress.XtraEditors.SimpleButton();
            this.xtraSCCol = new DevExpress.XtraEditors.XtraScrollableControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditCol = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textEditX = new DevExpress.XtraEditors.TextEdit();
            this.textEditY = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textEditWidth = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.textEditHeight = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditRow.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHeight.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAvgRow);
            this.groupBox1.Controls.Add(this.xtraSCRow);
            this.groupBox1.Controls.Add(this.spinEditRow);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "行设计";
            // 
            // btnAvgRow
            // 
            this.btnAvgRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAvgRow.Location = new System.Drawing.Point(149, 17);
            this.btnAvgRow.Name = "btnAvgRow";
            this.btnAvgRow.Size = new System.Drawing.Size(116, 25);
            this.btnAvgRow.TabIndex = 31;
            this.btnAvgRow.Text = "平均分配剩余空间";
            this.btnAvgRow.Click += new System.EventHandler(this.btnAvgRow_Click);
            // 
            // xtraSCRow
            // 
            this.xtraSCRow.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraSCRow.Appearance.BorderColor = System.Drawing.Color.Black;
            this.xtraSCRow.Appearance.Options.UseBackColor = true;
            this.xtraSCRow.Appearance.Options.UseBorderColor = true;
            this.xtraSCRow.Location = new System.Drawing.Point(21, 66);
            this.xtraSCRow.Name = "xtraSCRow";
            this.xtraSCRow.Size = new System.Drawing.Size(244, 144);
            this.xtraSCRow.TabIndex = 9;
            // 
            // spinEditRow
            // 
            this.spinEditRow.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spinEditRow.Location = new System.Drawing.Point(53, 18);
            this.spinEditRow.Name = "spinEditRow";
            this.spinEditRow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditRow.Properties.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.spinEditRow.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditRow.Size = new System.Drawing.Size(80, 21);
            this.spinEditRow.TabIndex = 8;
            this.spinEditRow.EditValueChanged += new System.EventHandler(this.spinEditRow_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "高度";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "行数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAvgCol);
            this.groupBox2.Controls.Add(this.xtraSCCol);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.Controls.Add(this.spinEditCol);
            this.groupBox2.Controls.Add(this.labelControl4);
            this.groupBox2.Location = new System.Drawing.Point(305, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 227);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "列设计";
            // 
            // btnAvgCol
            // 
            this.btnAvgCol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAvgCol.Location = new System.Drawing.Point(148, 17);
            this.btnAvgCol.Name = "btnAvgCol";
            this.btnAvgCol.Size = new System.Drawing.Size(116, 25);
            this.btnAvgCol.TabIndex = 31;
            this.btnAvgCol.Text = "平均分配剩余空间";
            this.btnAvgCol.Click += new System.EventHandler(this.btnAvgCol_Click);
            // 
            // xtraSCCol
            // 
            this.xtraSCCol.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraSCCol.Appearance.BorderColor = System.Drawing.Color.Black;
            this.xtraSCCol.Appearance.Options.UseBackColor = true;
            this.xtraSCCol.Appearance.Options.UseBorderColor = true;
            this.xtraSCCol.Location = new System.Drawing.Point(21, 66);
            this.xtraSCCol.Name = "xtraSCCol";
            this.xtraSCCol.Size = new System.Drawing.Size(243, 144);
            this.xtraSCCol.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 20);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "列数";
            // 
            // spinEditCol
            // 
            this.spinEditCol.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spinEditCol.Location = new System.Drawing.Point(53, 18);
            this.spinEditCol.Name = "spinEditCol";
            this.spinEditCol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditCol.Properties.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.spinEditCol.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditCol.Size = new System.Drawing.Size(80, 21);
            this.spinEditCol.TabIndex = 8;
            this.spinEditCol.EditValueChanged += new System.EventHandler(this.spinEditCol_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(21, 43);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "宽度";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(21, 239);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 14);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "起始坐标  X：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(213, 241);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(20, 14);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Y：";
            // 
            // textEditX
            // 
            this.textEditX.Location = new System.Drawing.Point(102, 238);
            this.textEditX.Name = "textEditX";
            this.textEditX.Size = new System.Drawing.Size(64, 21);
            this.textEditX.TabIndex = 30;
            // 
            // textEditY
            // 
            this.textEditY.Location = new System.Drawing.Point(239, 238);
            this.textEditY.Name = "textEditY";
            this.textEditY.Size = new System.Drawing.Size(64, 21);
            this.textEditY.TabIndex = 30;
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(492, 257);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 25);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "确认添加";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(21, 268);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "表格宽度：";
            // 
            // textEditWidth
            // 
            this.textEditWidth.Location = new System.Drawing.Point(102, 267);
            this.textEditWidth.Name = "textEditWidth";
            this.textEditWidth.Size = new System.Drawing.Size(64, 21);
            this.textEditWidth.TabIndex = 30;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(177, 270);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "表格高度：";
            // 
            // textEditHeight
            // 
            this.textEditHeight.Location = new System.Drawing.Point(240, 267);
            this.textEditHeight.Name = "textEditHeight";
            this.textEditHeight.Size = new System.Drawing.Size(64, 21);
            this.textEditHeight.TabIndex = 30;
            // 
            // TableCreatorDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textEditY);
            this.Controls.Add(this.textEditHeight);
            this.Controls.Add(this.textEditWidth);
            this.Controls.Add(this.textEditX);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.groupBox1);
            this.Name = "TableCreatorDlg";
            this.Size = new System.Drawing.Size(602, 299);
            this.Load += new System.EventHandler(this.TableCreatorDlg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditRow.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHeight.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinEditRow;
        private DevExpress.XtraEditors.XtraScrollableControl xtraSCRow;
        private DevExpress.XtraEditors.XtraScrollableControl xtraSCCol;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spinEditCol;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textEditX;
        private DevExpress.XtraEditors.TextEdit textEditY;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit textEditWidth;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit textEditHeight;
        private DevExpress.XtraEditors.SimpleButton btnAvgRow;
        private DevExpress.XtraEditors.SimpleButton btnAvgCol;

    }
}
