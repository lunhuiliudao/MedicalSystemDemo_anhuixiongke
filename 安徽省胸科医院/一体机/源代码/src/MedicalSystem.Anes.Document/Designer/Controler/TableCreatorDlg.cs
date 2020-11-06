using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms; 

namespace MedicalSystem.Anes.Document.Designer.Controler
{
    public partial class TableCreatorDlg : UserControl
    {
        protected double[] _rowHeight = new double[0];  // 行高度
        protected double[] _colWidth = new double[0];   // 列宽度
        protected Point _ptStart = new Point();  // 起点

        protected Size _parentSize;   // 父容器大小

        public TableCreatorDlg(Size sizeParent)
        {
            InitializeComponent();
            _parentSize = sizeParent;
        }


        protected void InitialRow(double size)
        {
            try
            {
                int row = Convert.ToInt32(spinEditRow.Value);

                // 调整个数
                for (int i = xtraSCRow.Controls.Count; i < row; i++)
                {
                    TableSize tbsize = new TableSize();
                    tbsize.Location = new Point(0, tbsize.Height * i);
                    xtraSCRow.Controls.Add(tbsize);

                    if (size > 0)
                    {
                        tbsize.ValueType = 0;
                        tbsize.Value = size;
                    }
                    else
                    {
                        tbsize.ValueType = 1;
                        tbsize.Value = 0;
                    }
                }

                for (int i = xtraSCRow.Controls.Count; i > row; i--)
                {
                    xtraSCRow.Controls.RemoveAt(i - 1);
                }

                // 调整值
                AvgRowDistance();
                //double everV = 100.0 / row;
                //for (int i = 0; i < xtraSCRow.Controls.Count; i++)
                //{
                //    TableSize tbSize = xtraSCRow.Controls[i] as TableSize;
                //    if (tbSize != null)
                //    {
                //        tbSize.Value = everV;
                //        tbSize.ValueType = 1;
                //    }
                //}
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        protected void InitialCol(double size)
        {
            try
            {
                int col = Convert.ToInt32(spinEditCol.Value);

                // 调整个数
                for (int i = xtraSCCol.Controls.Count; i < col; i++)
                {
                    TableSize tbsize = new TableSize();
                    tbsize.Location = new Point(0, tbsize.Height * i);
                    xtraSCCol.Controls.Add(tbsize);

                    if (size > 0)
                    {
                        tbsize.ValueType = 0;
                        tbsize.Value = size;
                    }
                    else
                    {
                        tbsize.ValueType = 1;
                        tbsize.Value = 0;
                    }
                }

                for (int i = xtraSCCol.Controls.Count; i > col; i--)
                {
                    xtraSCCol.Controls.RemoveAt(i - 1);
                }

                // 调整值
                AvgColDistance();
                //double everV = 100.0 / col;
                //for (int i = 0; i < xtraSCCol.Controls.Count; i++)
                //{
                //    TableSize tbSize = xtraSCCol.Controls[i] as TableSize;
                //    if (tbSize != null)
                //    {
                //        tbSize.Value = everV;
                //        tbSize.ValueType = 1;
                //    }
                //}
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void spinEditRow_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TableSize tbSize = xtraSCRow.Controls[xtraSCRow.Controls.Count - 1] as TableSize;
                double size = tbSize.ValueType == 0 ? tbSize.Value : 0;

                InitialRow(size);
            }
            catch (Exception)
            {
            }
        }

        private void spinEditCol_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TableSize tbSize = xtraSCCol.Controls[xtraSCCol.Controls.Count -1] as TableSize;
                double size = tbSize.ValueType == 0? tbSize.Value : 0;

                InitialCol(size);
            }
            catch (Exception)
            {
            }
        }

        private void TableCreatorDlg_Load(object sender, EventArgs e)
        {
            InitialRow(0);
            InitialCol(0);

            textEditWidth.Text = _parentSize.Width.ToString();
            textEditHeight.Text = _parentSize.Height.ToString();
            textEditX.Text = _ptStart.X.ToString();
            textEditY.Text = _ptStart.Y.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                _rowHeight = new double[xtraSCRow.Controls.Count];

                // 处理指定的高度
                double remainHeight = Convert.ToDouble(textEditHeight.Text);
                for (int i = 0; i < _rowHeight.Length; i++)
                {
                    TableSize tbSize = xtraSCRow.Controls[i] as TableSize;
                    if (tbSize != null && tbSize.ValueType == 0)
                    {
                        _rowHeight[i] = tbSize.Value;
                        remainHeight -= _rowHeight[i];
                    }
                }

                // 处理百分比高度
                if (remainHeight > 1)
                {
                    for (int i = 0; i < _rowHeight.Length; i++)
                    {
                        TableSize tbSize = xtraSCRow.Controls[i] as TableSize;
                        if (tbSize != null && tbSize.ValueType == 1)
                        {
                            _rowHeight[i] = tbSize.Value / 100 * remainHeight;
                        }
                    }
                }

                _colWidth = new double[xtraSCCol.Controls.Count];

                // 处理指定的宽度
                double remainWidth = Convert.ToDouble(textEditWidth.Text);
                for (int i = 0; i < _colWidth.Length; i++)
                {
                    TableSize tbSize = xtraSCCol.Controls[i] as TableSize;
                    if (tbSize != null && tbSize.ValueType == 0)
                    {
                        _colWidth[i] = tbSize.Value;
                        remainWidth -= _colWidth[i];
                    }
                }

                // 处理百分比宽度
                if (remainWidth > 1)
                {
                    for (int i = 0; i < _colWidth.Length; i++)
                    {
                        TableSize tbSize = xtraSCCol.Controls[i] as TableSize;
                        if (tbSize != null && tbSize.ValueType == 1)
                        {
                            _colWidth[i] = tbSize.Value / 100 * remainWidth;
                        }
                    }
                }

                int x = 0, y = 0;
                int.TryParse(textEditX.Text, out x);
                int.TryParse(textEditY.Text, out y);
                 _ptStart.X = x;
                _ptStart.Y = y;

                ParentForm.DialogResult = DialogResult.OK;
            }
            catch
            {
            }
        }
        
        public double[] RowHeight { get { return _rowHeight; } }
        public double[] ColWidth { get { return _colWidth; } }
        public Point TablePos 
        { 
            get { return _ptStart; }
            set { _ptStart.X = value.X; _ptStart.Y = value.Y; }
        }


        // 表格高度
        public double AllRowHeight
        {
            get
            {
                double ah = 0;
                for (int i = 0; i < _rowHeight.Length; i++)
                {
                    ah += _rowHeight[i];
                }

                return ah;
            }
        }

        // 表格宽度
        public double AllColWidth
        {
            get
            {
                double aw = 0;
                for (int i = 0; i < _colWidth.Length; i++)
                {
                    aw += _colWidth[i];
                }

                return aw;
            }
        }

        // 平均分配宽度
        protected void AvgColDistance()
        {
            // 指定为百分比的列数量
            int count = 0;
            for (int i = 0; i < xtraSCCol.Controls.Count; i++)
            {
                TableSize tbSize = xtraSCCol.Controls[i] as TableSize;
                if (tbSize != null && tbSize.ValueType == 1)
                {
                    count++;
                }
            }

            // 设置平均值
            if (count > 0)
            {
                double avg = 100.0 / count;
                for (int i = 0; i < xtraSCCol.Controls.Count; i++)
                {
                    TableSize tbSize = xtraSCCol.Controls[i] as TableSize;
                    if (tbSize != null && tbSize.ValueType == 1)
                    {
                        tbSize.Value = avg;
                    }
                }
            }
        }

        private void btnAvgCol_Click(object sender, EventArgs e)
        {
            try
            {
                AvgColDistance();
            }
            catch (Exception)
            {
            }
        }
        
        // 平均分配高度
        protected void AvgRowDistance()
        {
            // 指定为百分比的行数量
            int count = 0;
            for (int i = 0; i < xtraSCRow.Controls.Count; i++)
            {
                TableSize tbSize = xtraSCRow.Controls[i] as TableSize;
                if (tbSize != null && tbSize.ValueType == 1)
                {
                    count++;
                }
            }

            // 设置平均值
            if (count > 0)
            {
                double avg = 100.0 / count;
                for (int i = 0; i < xtraSCRow.Controls.Count; i++)
                {
                    TableSize tbSize = xtraSCRow.Controls[i] as TableSize;
                    if (tbSize != null && tbSize.ValueType == 1)
                    {
                        tbSize.Value = avg;
                    }
                }
            }
        }

        private void btnAvgRow_Click(object sender, EventArgs e)
        {
            try
            {
                AvgRowDistance();
            }
            catch (Exception)
            {
            }
        }

      

       
    }
}
