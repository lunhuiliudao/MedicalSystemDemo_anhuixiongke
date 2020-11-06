using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using System.IO;
using Aspose.Cells;
using MedicalSystem.Anes.Client.AppPC.Views.OperationQuery;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class OperationReport : BaseView
    {
        AccountRepository accountRepository = new AccountRepository();

        QueryRepository queryRepository = new QueryRepository();


        DateTime serverDay = DateTime.Now;
        public OperationReport()
        {
            InitializeComponent();
        }

        private void OperationReport_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;

            try
            {
                serverDay = accountRepository.GetServerTime().Data;
            }
            catch { }

            this.dateMoth1.Location = this.dateTimePicker1.Location;
            this.dateYear1.Location = this.dateTimePicker1.Location;

            this.dataGridView1.Visible = true;
            this.dataGridView2.Visible = false;
            this.dataGridView3.Visible = false;

            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView2.Dock = DockStyle.Fill;
            this.dataGridView3.Dock = DockStyle.Fill;

            this.dateTimePicker1.Value = serverDay;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbtnDay.Checked)
            {
                DataTable dt = queryRepository.GetOperationReport(this.dateTimePicker1.Value, 1).Data;

                this.dataGridView1.DataSource = queryRepository.GetOperationReport(this.dateTimePicker1.Value, 1).Data;
            }
            else if (rbtnMonth.Checked)
            {
                this.dataGridView2.DataSource = queryRepository.GetOperationReport(this.dateMoth1.StartDate, 2).Data;
            }
            else if (rbtnYear.Checked)
            {
                this.dataGridView3.DataSource = queryRepository.GetOperationReport(this.dateYear1.StartDate, 3).Data;
            }
        }
        private DataTable RefreshDate(DataTable dt)
        {
            DataTable reDT = new DataTable();

            return reDT;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (InitializePrinting())
            {
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument1;
                printPreviewDialog.ShowDialog();
            }
        }

        GridPrinter gridPrinter;

        private bool InitializePrinting()
        {
            PrintDialog printDialog = new PrintDialog();
            //printDialog.AllowCurrentPage = true;
            //printDialog.AllowPrintToFile = true;
            //printDialog.AllowSelection = true;
            //printDialog.AllowSomePages = true;
            //printDialog.PrintToFile = true;
            //printDialog.ShowHelp = true;
            //printDialog.ShowNetwork = true;
            if (printDialog.ShowDialog() != DialogResult.OK)
                return false;
            printDocument1.DocumentName = "工作量统计";
            printDocument1.PrinterSettings = printDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = printDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(40, 40, 40, 40);

            DataGridView tmpGrid = null;
            if (rbtnDay.Checked)
            {
                tmpGrid = this.dataGridView1;
            }
            else if (rbtnMonth.Checked)
            {
                tmpGrid = this.dataGridView2;
            }
            else if (rbtnYear.Checked)
            {
                tmpGrid = this.dataGridView3;
            }

            gridPrinter = new GridPrinter(tmpGrid, printDocument1, true, true, "工作量统计", new System.Drawing.Font("黑体", 18f, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);
            return true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = gridPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (rbtnDay.Checked)
            {
                DataGridViewToExcel(dataGridView1, this.dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            }
            else if (rbtnMonth.Checked)
            {
                DataGridViewToExcel(dataGridView2, this.dateMoth1.StartDate.ToString("yyyy-MM"));
            }
            else if (rbtnYear.Checked)
            {
                DataGridViewToExcel(dataGridView3, this.dateYear1.StartDate.ToString("yyyy年"));
            }

        }

        #region DataGridView导出到Excel，有一定的判断性
        /// <summary>   
        ///方法，导出DataGridView中的数据到Excel文件   
        /// </summary>   
        /// <remarks>  
        /// add com "Microsoft Excel 11.0 Object Library"  
        /// using Excel=Microsoft.Office.Interop.Excel;  
        /// using System.Reflection;  
        /// </remarks>  
        /// <param name= "dgv"> DataGridView </param>   
        public void DataGridViewToExcel(DataGridView dgv, string currentDate)
        {
            #region   验证可操作性

            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀   
            dlg.DefaultExt = "xls ";
            //文件后缀列表   
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            //默然路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == " ")
            { return; }
            //定义表格内数据的行数和列数   
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0   
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0   
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536   
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255   
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它   
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion

            try
            {
                Workbook workbook = new Workbook(); //工作簿 
                Worksheet sheet = workbook.Worksheets[0]; //工作表 
                sheet.Name = "工作量统计";
                Cells cells = sheet.Cells;//单元格 

                //为标题设置样式     
                Style styleTitle = workbook.Styles[workbook.Styles.Add()];//新增样式 
                styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
                styleTitle.Font.Name = "宋体";//文字字体 
                styleTitle.Font.Size = 18;//文字大小 
                styleTitle.Font.IsBold = true;//粗体 

                //样式2 
                Style style2 = workbook.Styles[workbook.Styles.Add()];//新增样式 
                style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
                style2.Font.Name = "宋体";//文字字体 
                style2.Font.Size = 12;//文字大小 
                style2.Font.IsBold = true;//粗体 
                style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

                //样式3 
                Style style3 = workbook.Styles[workbook.Styles.Add()];//新增样式 
                style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
                style3.Font.Name = "宋体";//文字字体 
                style3.Font.Size = 10;//文字大小 
                style3.IsTextWrapped = true;//单元格内容自动换行 
                style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

                int Colnum = dgv.Columns.Count;//表格列数 
                int Rownum = dgv.Rows.Count;//表格行数 
                int visibleCols = dgv.Columns.Cast<DataGridViewColumn>().Where(x => x.Visible).Count();

                //生成行1 标题行    
                cells.Merge(0, 0, 1, visibleCols);//合并单元格 
                cells[0, 0].PutValue(string.Format("工作量统计（{0}）", currentDate));//填写内容 
                cells[0, 0].SetStyle(styleTitle);
                cells.SetRowHeight(0, 38);

                int hideIndex = 0;
                //生成行2 列名行 
                for (int i = 0; i + hideIndex < Colnum; i++)
                {
                    while (i + hideIndex < Colnum && !dgv.Columns[i + hideIndex].Visible)
                    {
                        hideIndex++;
                    }
                    if (i + hideIndex >= Colnum)
                        continue;
                    cells[1, i].PutValue(dgv.Columns[i + hideIndex].HeaderText);
                    cells[1, i].SetStyle(style2);
                    cells.SetRowHeight(1, 25);
                    //设置表页的列宽度自适应
                    sheet.AutoFitColumn(i, 0, cells.MaxRow);
                    cells.SetColumnWidthPixel(i, cells.GetColumnWidthPixel(i) + 2);
                }

                //生成数据行 
                for (int i = 0; i < Rownum; i++)
                {
                    hideIndex = 0;
                    for (int k = 0; k + hideIndex < Colnum; k++)
                    {
                        while (k + hideIndex < Colnum && !dgv.Columns[k + hideIndex].Visible)
                        {
                            hideIndex++;
                        }
                        if (k + hideIndex >= Colnum)
                            continue;
                        cells[2 + i, k].PutValue(Convert.ToString(dgv.Rows[i].Cells[k + hideIndex].FormattedValue) ?? "");
                        cells[2 + i, k].SetStyle(style3);
                    }
                    cells.SetRowHeight(2 + i, 24);

                    //设置表页的行高自适应
                    sheet.AutoFitRow(i + 2);
                    cells.SetColumnWidthPixel(i + 2, cells.GetColumnWidthPixel(i + 2) + 6);
                }

                workbook.Save(fileNameString);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(fileNameString + "，导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        /// <summary>
        /// 设置表页的列宽度自适应
        /// </summary>
        /// <param name="sheet">worksheet对象</param>
        void setColumnWithAuto(Worksheet sheet)
        {
            Cells cells = sheet.Cells;
            int columnCount = cells.MaxColumn;
            //获取表页的最大列数
            int rowCount = cells.MaxRow;
            //获取表页的最大行数
            for (int col = 0; col < columnCount; col++)
            {
                sheet.AutoFitColumn(col, 0, rowCount);
            }
            for (int col = 0; col < columnCount; col++)
            {
                cells.SetColumnWidthPixel(col, cells.GetColumnWidthPixel(col) + 30);
            }
        }

        #endregion

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView tmpGrid = sender as DataGridView;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                tmpGrid.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                tmpGrid.RowHeadersDefaultCellStyle.Font,
                rectangle,
                tmpGrid.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 选中某个患者双击进入患者病案首页界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            string patientID = dataGridView1.CurrentRow.Cells[this.ColumnPatientID.Index].Value.ToString();
            int visitID = int.Parse(dataGridView1.CurrentRow.Cells[this.ColumnVisitID.Index].Value.ToString());
            int operID = int.Parse(dataGridView1.CurrentRow.Cells[this.ColumnOperID.Index].Value.ToString());
            string name = dataGridView1.CurrentRow.Cells[this.ColumnNAME.Index].Value.ToString();
            DialogHostFormPC dialogHostForm = new DialogHostFormPC(name + "的首页", true);
            dialogHostForm.Child = new PatientMain(patientID, visitID, operID);
            dialogHostForm.ShowDialog();
        }

        private void rbtnDay_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDay.Checked)
            {
                this.dateTimePicker1.Visible = true;
                this.dateMoth1.Visible = false;
                this.dateYear1.Visible = false;

                this.dataGridView1.Visible = true;
                this.dataGridView2.Visible = false;
                this.dataGridView3.Visible = false;
            }
            else if (rbtnMonth.Checked)
            {
                this.dateTimePicker1.Visible = false;
                this.dateMoth1.Visible = true;
                this.dateYear1.Visible = false;

                this.dataGridView1.Visible = false;
                this.dataGridView2.Visible = true;
                this.dataGridView3.Visible = false;
            }
            else if (rbtnYear.Checked)
            {
                this.dateTimePicker1.Visible = false;
                this.dateMoth1.Visible = false;
                this.dateYear1.Visible = true;

                this.dataGridView1.Visible = false;
                this.dataGridView2.Visible = false;
                this.dataGridView3.Visible = true;
            }
        }


    }
}
