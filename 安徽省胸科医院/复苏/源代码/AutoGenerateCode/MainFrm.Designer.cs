namespace MedicalSystem.AutoGenerateCode
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAllTableColumnSql = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAllTableSql = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDataType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClassTemp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerateClass = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConnString);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 41);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库配置";
            // 
            // txtConnString
            // 
            this.txtConnString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnString.Location = new System.Drawing.Point(85, 17);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(597, 21);
            this.txtConnString.TabIndex = 1;
            this.txtConnString.Text = "Data Source=docare;Persist Security Info=True;User ID=medsurgery;Password=medsurg" +
                "ery";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "连接字符串：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAllTableColumnSql);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAllTableSql);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 196);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查找语句";
            // 
            // txtAllTableColumnSql
            // 
            this.txtAllTableColumnSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAllTableColumnSql.Location = new System.Drawing.Point(3, 113);
            this.txtAllTableColumnSql.Multiline = true;
            this.txtAllTableColumnSql.Name = "txtAllTableColumnSql";
            this.txtAllTableColumnSql.Size = new System.Drawing.Size(679, 80);
            this.txtAllTableColumnSql.TabIndex = 4;
            this.txtAllTableColumnSql.Text = resources.GetString("txtAllTableColumnSql.Text");
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(679, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "查询当前表的所有列：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAllTableSql
            // 
            this.txtAllTableSql.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAllTableSql.Location = new System.Drawing.Point(3, 38);
            this.txtAllTableSql.Multiline = true;
            this.txtAllTableSql.Name = "txtAllTableSql";
            this.txtAllTableSql.Size = new System.Drawing.Size(679, 54);
            this.txtAllTableSql.TabIndex = 2;
            this.txtAllTableSql.Text = "SELECT A.TABLE_NAME, B.COMMENTS\r\n  FROM USER_TABLES A, USER_TAB_COMMENTS B\r\n WHER" +
                "E A.TABLE_NAME = B.TABLE_NAME\r\n ORDER BY TABLE_NAME";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(679, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "查询所有的表：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDataType);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtClassTemp);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 237);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(685, 220);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生成模板";
            // 
            // txtDataType
            // 
            this.txtDataType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataType.Location = new System.Drawing.Point(3, 113);
            this.txtDataType.Multiline = true;
            this.txtDataType.Name = "txtDataType";
            this.txtDataType.Size = new System.Drawing.Size(679, 104);
            this.txtDataType.TabIndex = 4;
            this.txtDataType.Text = resources.GetString("txtDataType.Text");
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(679, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据类型转换对应关系";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClassTemp
            // 
            this.txtClassTemp.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtClassTemp.Location = new System.Drawing.Point(3, 38);
            this.txtClassTemp.Multiline = true;
            this.txtClassTemp.Name = "txtClassTemp";
            this.txtClassTemp.Size = new System.Drawing.Size(679, 54);
            this.txtClassTemp.TabIndex = 2;
            this.txtClassTemp.Text = resources.GetString("txtClassTemp.Text");
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(3, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(679, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "类的模板";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGenerateClass
            // 
            this.btnGenerateClass.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerateClass.Location = new System.Drawing.Point(0, 457);
            this.btnGenerateClass.Name = "btnGenerateClass";
            this.btnGenerateClass.Size = new System.Drawing.Size(685, 23);
            this.btnGenerateClass.TabIndex = 3;
            this.btnGenerateClass.Text = "生成代码";
            this.btnGenerateClass.UseVisualStyleBackColor = true;
            this.btnGenerateClass.Click += new System.EventHandler(this.btnGenerateClass_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 480);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGenerateClass);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainFrm";
            this.Text = "代码生成器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAllTableSql;
        private System.Windows.Forms.TextBox txtAllTableColumnSql;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDataType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClassTemp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerateClass;
    }
}

