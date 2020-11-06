using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC
{
    public class DataGridViewActionButtonColumn : DataGridViewColumn
    {
        public DataGridViewActionButtonColumn()
        {
            this.CellTemplate = new DataGridViewActionButtonCell();
            this.HeaderText = "操作";
        }
    }
    public class DataGridViewActionButtonCell : DataGridViewButtonCell
    {
        private bool VisitButton = false;
        private bool MainDocButton = false;
        private bool otherDocButton = false;
        private static Image ImageVisit = Properties.Resources.术前访视_完成1;
        private static Image ImageMainDoc = Properties.Resources.同意书_完成1;
        private static Image ImageOtherDoc = Properties.Resources.其他_完成1;

        private static Pen penButton = new Pen(Color.Transparent);

        private static int nowColIndex = 0; // 当前列序号
        private static int nowRowIndex = 0; // 当前行序号
        private static bool isUpGridView = false;

        /// <summary>
        /// 对单元格的重绘事件进行的方法重写。
        /// </summary>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
            object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            if (this.DataGridView.Name.Equals("dgFinishedYesterday")) isUpGridView = false;
            else isUpGridView = true;
            cellBounds = PrivatePaint(graphics, cellBounds, rowIndex, cellStyle, true);
            advancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            base.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            nowColIndex = this.DataGridView.Columns.Count - 1;
        }

        /// <summary>
        /// 私有的单元格重绘方法
        /// </summary>
        private Rectangle PrivatePaint(Graphics graphics, Rectangle cellBounds, int rowIndex, DataGridViewCellStyle cellStyle, bool clearBackground)
        {
            if (isUpGridView)
            {
                if (VisitButton)
                {
                    ImageVisit = Properties.Resources.术前访视_完成3;
                }
                else
                {
                    ImageVisit = Properties.Resources.术前访视_完成1;
                }

                if (MainDocButton)
                {
                    ImageMainDoc = Properties.Resources.同意书_完成3;
                }
                else
                {
                    ImageMainDoc = Properties.Resources.同意书_完成1;
                }
                if (otherDocButton)
                {
                    ImageOtherDoc = Properties.Resources.其他_完成3;
                }
                else
                {
                    ImageOtherDoc = Properties.Resources.其他_完成1;
                }
            }
            else
            {
                if (VisitButton)
                {
                    ImageVisit = Properties.Resources.术后随访_完成3;
                }
                else
                {
                    ImageVisit = Properties.Resources.术后随访_完成1;
                }

                if (MainDocButton)
                {
                    ImageMainDoc = Properties.Resources.麻醉单_完成3;
                }
                else
                {
                    ImageMainDoc = Properties.Resources.麻醉单_完成1;
                }
                if (otherDocButton)
                {
                    ImageOtherDoc = Properties.Resources.其他二_完成3;
                }
                else
                {
                    ImageOtherDoc = Properties.Resources.其他二_完成1;
                }
            }

            if (clearBackground)
            {
                Brush brushCellBack = (rowIndex == this.DataGridView.CurrentRow.Index) ? new SolidBrush(cellStyle.SelectionBackColor) : new SolidBrush(cellStyle.BackColor);
                graphics.FillRectangle(brushCellBack, cellBounds.X + 1, cellBounds.Y + 1, cellBounds.Width - 2, cellBounds.Height - 2);
            }

            Rectangle recVisit = new Rectangle(cellBounds.Location.X + cellBounds.Width / 3 - ImageVisit.Width - 4, cellBounds.Location.Y + (cellBounds.Height - ImageVisit.Height) / 2, ImageVisit.Width, ImageVisit.Height);
            Rectangle recMainDoc = new Rectangle(cellBounds.Location.X + cellBounds.Width / 3 - 2, cellBounds.Location.Y + (cellBounds.Height - ImageMainDoc.Height) / 2, ImageMainDoc.Width, ImageMainDoc.Height);
            Rectangle recOtherDoc = new Rectangle(cellBounds.Location.X + cellBounds.Width / 3 + ImageOtherDoc.Width, cellBounds.Location.Y + (cellBounds.Height - ImageOtherDoc.Height) / 2, ImageOtherDoc.Width, ImageOtherDoc.Height);

            graphics.DrawImage(ImageVisit, recVisit);
            graphics.DrawImage(ImageMainDoc, recMainDoc);
            graphics.DrawImage(ImageOtherDoc, recOtherDoc);
            graphics.DrawRectangle(penButton, recVisit.X, recVisit.Y - 1, recVisit.Width, recVisit.Height);
            graphics.DrawRectangle(penButton, recMainDoc.X, recMainDoc.Y - 1, recMainDoc.Width, recMainDoc.Height);
            graphics.DrawRectangle(penButton, recOtherDoc.X, recOtherDoc.Y - 1, recOtherDoc.Width, recOtherDoc.Height);
            return cellBounds;
        }

        /// <summary>
        /// 判断用户是否单击了访问按钮，DataGridView发生CellMouseClick事件时，
        /// 因本单元格中有两个按钮，本方法通过坐标判断用户是否单击了访问按钮。
        /// </summary>
        public static bool IsVisitButtonClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return false;
            if (sender is DataGridView)
            {
                DataGridView DgvGrid = (DataGridView)sender;
                if (DgvGrid.Columns[e.ColumnIndex] is DataGridViewActionButtonColumn)
                {
                    Rectangle cellBounds = DgvGrid[e.ColumnIndex, e.RowIndex].ContentBounds;
                    Rectangle recVisit = new Rectangle(cellBounds.Location.X + cellBounds.Width / 3 - ImageVisit.Width - 4, cellBounds.Location.Y + (cellBounds.Height - ImageVisit.Height) / 2, ImageVisit.Width, ImageVisit.Height);
                    if (IsInRect(e.X, e.Y, recVisit))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断用户是否单击了主文书按钮，DataGridView发生CellMouseClick事件时，
        /// 因本单元格中有两个按钮，本方法通过坐标判断用户是否单击了主文书按钮。
        /// </summary>
        public static bool IsMainDocButtonClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return false;
            if (sender is DataGridView)
            {
                DataGridView DgvGrid = (DataGridView)sender;
                if (DgvGrid.Columns[e.ColumnIndex] is DataGridViewActionButtonColumn)
                {
                    Rectangle cellBounds = DgvGrid[e.ColumnIndex, e.RowIndex].ContentBounds;
                    Rectangle recMainDoc = new Rectangle(cellBounds.Location.X + cellBounds.Width / 3 - 2, cellBounds.Location.Y + (cellBounds.Height - ImageMainDoc.Height) / 2, ImageMainDoc.Width, ImageMainDoc.Height);
                    if (IsInRect(e.X, e.Y, recMainDoc))
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断用户是否单击了其他文书按钮，DataGridView发生CellMouseClick事件时，
        /// 因本单元格中有两个按钮，本方法通过坐标判断用户是否单击了其他文书按钮。
        /// </summary>
        public static bool IsOtherDocButtonClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return false;
            if (sender is DataGridView)
            {
                DataGridView DgvGrid = (DataGridView)sender;
                if (DgvGrid.Columns[e.ColumnIndex] is DataGridViewActionButtonColumn)
                {
                    Rectangle cellBounds = DgvGrid[e.ColumnIndex, e.RowIndex].ContentBounds;
                    Rectangle recOtherDoc = new Rectangle(cellBounds.Location.X + cellBounds.Width / 3 + ImageOtherDoc.Width, cellBounds.Location.Y + (cellBounds.Height - ImageOtherDoc.Height) / 2, ImageOtherDoc.Width, ImageOtherDoc.Height);
                    if (IsInRect(e.X, e.Y, recOtherDoc))
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 鼠标移动到单元格内时的事件处理，通过坐标判断鼠标是否移动到了修改或删除按钮上，并调用私有的重绘方法进行重绘。
        /// </summary>
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            if (base.DataGridView == null) return;

            nowColIndex = e.ColumnIndex;
            nowRowIndex = e.RowIndex;

            Rectangle cellBounds = DataGridView[e.ColumnIndex, e.RowIndex].ContentBounds;
            Rectangle recVisit = new Rectangle(cellBounds.Location.X + cellBounds.Width / 3 - ImageVisit.Width - 4, cellBounds.Location.Y + (cellBounds.Height - ImageVisit.Height) / 2, ImageVisit.Width, ImageVisit.Height);
            Rectangle recMainDoc = new Rectangle(cellBounds.Location.X + cellBounds.Width / 3 - 2, cellBounds.Location.Y + (cellBounds.Height - ImageMainDoc.Height) / 2, ImageMainDoc.Width, ImageMainDoc.Height);
            Rectangle recOtherDoc = new Rectangle(cellBounds.Location.X + cellBounds.Width / 3 + ImageOtherDoc.Width, cellBounds.Location.Y + (cellBounds.Height - ImageOtherDoc.Height) / 2, ImageOtherDoc.Width, ImageOtherDoc.Height);

            Rectangle paintCellBounds = DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            paintCellBounds.Width = DataGridView.Columns[nowColIndex].Width;
            paintCellBounds.Height = DataGridView.Rows[nowRowIndex].Height;

            if (IsInRect(e.X, e.Y, recVisit))
            {
                if (!VisitButton)
                {
                    VisitButton = true;
                    PrivatePaint(this.DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, this.DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (VisitButton)
                {
                    VisitButton = false;
                    PrivatePaint(this.DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, this.DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Default;
                }
            }
            if (IsInRect(e.X, e.Y, recMainDoc))
            {
                if (!MainDocButton)
                {
                    MainDocButton = true;
                    PrivatePaint(this.DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, this.DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (MainDocButton)
                {
                    MainDocButton = false;
                    PrivatePaint(this.DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, this.DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Default;
                }
            }

            if (IsInRect(e.X, e.Y, recOtherDoc))
            {
                if (!otherDocButton)
                {
                    otherDocButton = true;
                    PrivatePaint(this.DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, this.DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (otherDocButton)
                {
                    otherDocButton = false;
                    PrivatePaint(this.DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex, this.DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// 鼠标从单元格内移出时的事件处理，调用私有的重绘方法进行重绘。
        /// </summary>
        protected override void OnMouseLeave(int rowIndex)
        {
            if (VisitButton != false || VisitButton != false || otherDocButton != false)
            {
                VisitButton = false;
                VisitButton = false;
                otherDocButton = false;
                Rectangle paintCellBounds = DataGridView.GetCellDisplayRectangle(nowColIndex, nowRowIndex, true);

                paintCellBounds.Width = DataGridView.Columns[nowColIndex].Width;
                paintCellBounds.Height = DataGridView.Rows[nowRowIndex].Height;

                PrivatePaint(this.DataGridView.CreateGraphics(), paintCellBounds, nowRowIndex, this.DataGridView.RowTemplate.DefaultCellStyle, false);
                DataGridView.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// 判断鼠标坐标是否在指定的区域内。
        /// </summary>
        private static bool IsInRect(int x, int y, Rectangle area)
        {
            if (x > area.Left && x < area.Right && y > area.Top && y < area.Bottom)
                return true;
            return false;

        }
    }
}
