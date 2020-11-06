using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.IO;
using System.ComponentModel;
using MedicalSystem.Anes.Document;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(false),Description("表单表格")]
    public class SheetGrid : MedGridView
    {
        private string _tableName;
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        private int _modelLines;
        public int ModelLines
        {
            get
            {
                return _modelLines;
            }
            set
            {
                _modelLines = value;
            }
        }

        private int _addLines;
        public int AddLines
        {
            get
            {
                return _addLines;
            }
            set
            {
                _addLines = value;
            }
        }

        private int _columnGroupNumber;
        public int ColumnGroupNumber
        {
            get
            {
                return _columnGroupNumber;
            }
            set
            {
                _columnGroupNumber = value;
            }
        }

        private List<SheetGridColumn> _columnItems = new List<SheetGridColumn>();
        public List<SheetGridColumn> ColumnItems
        {
            get
            {
                return _columnItems;
            }
            set
            {
                _columnItems = value;
            }
        }

        private List<string> _simpleModelItems;
        [Description("简单模板")]
        public List<string> SimpleModelItems
        {
            get
            {
                return _simpleModelItems;
            }
            set
            {
                _simpleModelItems = value;
            }
        }

        public SheetGrid() 
        {
            SetColumnItems();
            InitGrid();
        }

        protected override void ColumnChanged()
        {
            //SetColumnItems();
            //InitColumns();
        }

        public void SetColumnItems()
        {
            if (!DesignMode && _columnItems == null || _columnItems.Count == 0)
            {
                List<MedGridViewColumn> medGridViewColumn = new List<MedGridViewColumn>();
                GetMedGridViewColumns(out medGridViewColumn);
                if (medGridViewColumn != null)
                {
                    _columnItems = new List<SheetGridColumn>();
                    foreach (MedGridViewColumn column in medGridViewColumn)
                    {
                        _columnItems.Add(new SheetGridColumn(column.HeaderText, column.Width));
                    }
                }
            }
        }

        public SheetGrid(string griddataKey, int rowHeight, int modelLines, int addLines, int columnGroupNumber,List<SheetGridColumn> columnItems)
            : this()
        {
            RowTemplate.Height = rowHeight;
            _tableName = griddataKey;
            _addLines = addLines;
            _modelLines = modelLines;
            _columnGroupNumber = columnGroupNumber;
            _columnItems = columnItems;
            InitColumns();
        }

        public void InitColumns()
        {
            int width = 0;
            for (int i = 0; i < _columnGroupNumber; i++)
            {
                for (int j = 0; j < _columnItems.Count; j++)
                {
                    Columns.Add(GenGridColumn("Field" + i.ToString() + j.ToString(), _columnItems[j].HeadText, _columnItems[j].Width));
                    width += _columnItems[j].Width;
                }
            }
            Width = width + 2;
        }

        private DataGridViewTextBoxColumn GenGridColumn(string fieldName, string headText, int width)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = fieldName;
            column.DataPropertyName = fieldName;
            column.HeaderText = headText;
            column.Width = width;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            return column;
        }

        private void InitGrid()
        {
            DataGridView grid = this;
            grid.MultiSelect = true;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //grid.Font = new Font("楷体_GB2312", 10);
            //grid.ColumnHeadersDefaultCellStyle.Font = new Font("楷体_GB2312", 10, FontStyle.Bold);
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersWidth = 10;
            grid.RowHeadersVisible = false;
            grid.ColumnHeadersHeight = 35;
            grid.BackgroundColor = Color.White;
            grid.BringToFront();
            grid.ScrollBars = ScrollBars.None;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Color.Black;
            grid.CellPainting += new DataGridViewCellPaintingEventHandler(grid_CellPainting);
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                e.Handled = true;
                Rectangle rect = e.CellBounds;
                rect.Width -= 1;
                rect.Height -= 1;
                Color bColor = Color.White;
                if (CurrentCell != null)
                {
                    if (CurrentCell.RowIndex == e.RowIndex && CurrentCell.ColumnIndex == e.ColumnIndex)
                    {
                        bColor = e.CellStyle.SelectionBackColor;
                    }
                }
                using (SolidBrush solidBrush = new SolidBrush(bColor))
                {
                    e.Graphics.FillRectangle(solidBrush, rect);
                }
                using (Pen pen = Pens.Black)
                {
                    if (e.ColumnIndex == 0)
                    {
                        e.Graphics.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom);
                    }
                    e.Graphics.DrawLine(pen, rect.Right, rect.Y, rect.Right, rect.Bottom);
                    e.Graphics.DrawLine(pen, rect.X, rect.Bottom, rect.Right, rect.Bottom);
                }
               

                if (e.Value != null)
                {
                    string text = e.Value.ToString();
                    if (!string.IsNullOrEmpty(text))
                    {
                        Color fColor = e.CellStyle.ForeColor;
                        if (CurrentCell != null)
                        {
                            if (CurrentCell.RowIndex == e.RowIndex && CurrentCell.ColumnIndex == e.ColumnIndex)
                            {
                                fColor = e.CellStyle.SelectionForeColor;
                            }
                        }
                        if (e.Graphics.MeasureString(text, e.CellStyle.Font).Width < rect.Width)
                        {
                            using (SolidBrush solidBrush2 = new SolidBrush(fColor))
                            {
                                e.Graphics.DrawString(text, e.CellStyle.Font, solidBrush2, rect.X + (rect.Width - e.Graphics.MeasureString(text, e.CellStyle.Font).Width) / 2
                                , rect.Y + (rect.Height - e.Graphics.MeasureString(text, e.CellStyle.Font).Height) / 2);
                            }
                            
                        }
                        else
                        {
                            StringFormat sf = new StringFormat();
                            sf.Alignment = StringAlignment.Center;
                            using (SolidBrush solidBrush3 = new SolidBrush(fColor))
                            {
                                e.Graphics.DrawString(text, e.CellStyle.Font, solidBrush3, rect, sf);
                            }
                           
                        }
                    }
                }
            }
        }

        public DataTable GetSelectionData()
        {
            DataTable dataTable = new DataTable();
            int startCol = Columns.Count - 1;
            int endCol = 0;
            int startRow = Rows.Count - 1;
            int endRow = 0;
            foreach (DataGridViewCell cell in SelectedCells)
            {
                if (startCol > cell.ColumnIndex) startCol = cell.ColumnIndex;
                if (endCol < cell.ColumnIndex) endCol = cell.ColumnIndex;
                if (startRow > cell.RowIndex) startRow = cell.RowIndex;
                if (endRow < cell.RowIndex) endRow = cell.RowIndex;
            }
            for (int i = startCol; i <= endCol; i++)
            {
                dataTable.Columns.Add(Columns[i].Name);
            }
            for (int i = startRow; i <= endRow; i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = startCol; j <= endCol; j++)
                {
                    //object obj = Rows[i].Cells[j].Value;
                    //if (obj == null || obj == System.DBNull.Value) obj = "";
                    //row[j - startCol] = obj.ToString();
                    row[j - startCol] = Rows[i].Cells[j].Value;
                }
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable GetData()
        {
            DataTable dataTable = new DataTable();
            for (int i = 0; i < Columns.Count; i++)
            {
                dataTable.Columns.Add(Columns[i].Name);
            }
            for (int i = 0; i < Rows.Count; i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < Columns.Count; j++)
                {
                    //if (Rows[i].Cells[j].Value == null || Rows[i].Cells[j].Value == System.DBNull.Value)
                    //{
                    //    row[j] = "";
                    //}
                    //else
                    //{
                    //    row[j] = Rows[i].Cells[j].Value.ToString();
                    //}
                    row[j] = Rows[i].Cells[j].Value;
                }
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private Stream DataTableToStream(DataTable dataTable)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            dataTable.TableName = _tableName;
            dataTable.WriteXml(stream, XmlWriteMode.WriteSchema);
            //dataTable.WriteXml(stream, XmlWriteMode.IgnoreSchema);
            stream.Position = 0;
            return stream;
        }

        public Stream GetSelectionStream()
        {
            return DataTableToStream(GetSelectionData());
        }

        public Stream GetStream()
        {
            return DataTableToStream(GetData());
        }

        private DataTable DataTableFromBuffer(byte[] buffer)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(buffer);
            stream.Position = 0;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(stream);
            DataTable dataTable = dataSet.Tables[0];
            return dataTable;
        }

        public void InitData()
        {
            int modelLines = _modelLines;
            int addLines = _addLines;
            Rows.Clear();
            string[] defualItems = null;
            if (_simpleModelItems != null) defualItems = _simpleModelItems.ToArray();
            bool flowout = false;
            for (int j = 0; j < _columnGroupNumber; j++)
            {
                for (int i = 0; i < modelLines; i++)
                {
                    if (defualItems == null || (defualItems.Length < i + 1 + j * modelLines))
                    {
                        flowout = true;
                        break;
                    }
                    if (j == 0)
                    {
                        Rows.Add(new object[] { defualItems[i] });
                    }
                    else
                    {
                        Rows[i].Cells[j*_columnItems.Count].Value = defualItems[i + modelLines];
                    }
                }
                if (flowout) break;
            }
            while (Rows.Count < modelLines) Rows.Add();

            for (int i = 0; i < addLines; i++)
            {
                Rows.Add();
            }
        }

        public void SetData(byte[] buffer)
        {
            Rows.Clear();
            DataTable dataTable = DataTableFromBuffer(buffer);
            SetData(dataTable);
        }

        public void SetData(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Rows.Add();
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (Columns.Count <= j) break;
                    //Rows[i].Cells[j].Value = dataTable.Rows[i][j].ToString();
                    if (dataTable.Rows[i][j] != null && dataTable.Rows[i][j].ToString() == "")
                    {
                        Rows[i].Cells[j].Value = null;
                    }
                    else
                    {
                        Rows[i].Cells[j].Value = dataTable.Rows[i][j];
                    }
                    Rows[i].Cells[j].Tag = dataTable.Rows[i][j];
                }
            }
        }

        public void SetJuBuData(byte[] buffer)
        {
            if (CurrentCell == null) return;
            int startCol = CurrentCell.ColumnIndex;
            int startRow = CurrentCell.RowIndex;
            DataTable dataTable = DataTableFromBuffer(buffer);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (Rows.Count < startRow + i + 1) break;
                DataGridViewRow rw = Rows[startRow + i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (Columns.Count < startCol + j + 1) break;
                    //rw.Cells[startCol + j].Value = dataTable.Rows[i][j].ToString();
                    if (dataTable.Rows[i][j] != null && dataTable.Rows[i][j].ToString() == "")
                    {
                        rw.Cells[startCol + j].Value = null;
                    }
                    else
                    {
                        rw.Cells[startCol + j].Value = dataTable.Rows[i][j];
                    }
                    rw.Cells[startCol + j].Tag = dataTable.Rows[i][j];
                }
            }
        }

        public float Draw(Graphics g, float leftOffSet, float topOffSet, float scale)
        {
            float xOffSet = leftOffSet;
            float yOffSet = topOffSet;
            float rowHeight;
            if(Rows.Count > 0)rowHeight = Rows[0].Height;else rowHeight = ColumnHeadersHeight;
            float lineHeight  = rowHeight;
            float widthScale = 1;
            for (int i = -1; i < Rows.Count; i++)
            {
                if (i == -1) lineHeight = ColumnHeadersHeight; else lineHeight = rowHeight;
                using (Pen pen1 = Pens.Black)
                {
                    g.DrawLine(pen1, xOffSet, yOffSet, xOffSet, yOffSet + lineHeight);
                }
               
                for (int j = 0; j < Columns.Count; j++)
                {
                    if (Columns[j].Visible)
                    {
                        object obj;
                        if (i == -1)
                            obj = Columns[j].HeaderText;
                        else obj = Rows[i].Cells[j].Value;
                        if (obj != null)
                        {
                            string text = obj.ToString();
                            using (Brush brush = Brushes.Black)
                            {
                                if (Columns[j].Width * widthScale > g.MeasureString(text, (i == -1) ? ColumnHeadersDefaultCellStyle.Font : Font).Width)
                                {

                                    g.DrawString(text, (i == -1) ? ColumnHeadersDefaultCellStyle.Font : Font, brush, xOffSet + (Columns[j].Width * widthScale
                                     - g.MeasureString(text, (i == -1) ? ColumnHeadersDefaultCellStyle.Font : Font).Width) / 2, yOffSet + (lineHeight
                                     - g.MeasureString(text, (i == -1) ? ColumnHeadersDefaultCellStyle.Font : Font).Height) / 2);

                                }
                                else
                                {
                                    StringFormat sf = new StringFormat();
                                    sf.Alignment = StringAlignment.Center;
                                    g.DrawString(text, (i == -1) ? ColumnHeadersDefaultCellStyle.Font : Font, brush, new RectangleF(xOffSet, yOffSet, Columns[j].Width * widthScale, lineHeight), sf);
                                }
                            }
                           
                        }
                        using (Pen pen4 = Pens.Black)
                        {
                            g.DrawLine(pen4, xOffSet, yOffSet + lineHeight, xOffSet + Columns[j].Width * widthScale, yOffSet + lineHeight);
                            g.DrawLine(pen4, xOffSet + Columns[j].Width * widthScale, yOffSet, xOffSet + Columns[j].Width * widthScale, yOffSet + lineHeight);
                        }
                        
                        xOffSet += Columns[j].Width * widthScale;
                    }
                }
                xOffSet = leftOffSet;
                yOffSet += lineHeight;
            }
            return yOffSet;
        }

    }

    [Serializable]
    public class SheetGridColumn
    {
        private string _headText;
        [Description("列标题")]
        public string HeadText
        {
            get
            {
                return _headText;
            }
            set
            {
                _headText = value;
            }
        }

        private int _width;
        [Description("列宽度")]
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public SheetGridColumn() { }
        public SheetGridColumn(string headText, int width) { _headText = headText; _width = width; }

        public override string ToString()
        {
            return _headText;
        }
    }
}
