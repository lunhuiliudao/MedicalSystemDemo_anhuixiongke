/*----------------------------------------------------------------
      // Copyright (C) 2010 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedGridView.cs
      // 文件功能描述：表格控件
      //
      // 
      // 修改标识：戴呈祥-2010-05-19
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Designer; 


namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(false), Description("表格")]
    public class MedGridView : DataGridView, IPrintable
    {
        public MedGridView()
        {
            if (!DesignMode)
            {
               //这个事件可能做了重复或者无用的事情,因为发现子类或者基类里会重新注册并实现这个事件
               //因此,先将之注释掉 *************************************************leo 2011-06-06
               // CellPainting += new DataGridViewCellPaintingEventHandler(MedGridView_CellPainting);
            }



           // this.ColumnHeadersDefaultCellStyle.Font = _ColumnHeadersDefaultCellStyleFont;
        }

        private string _columnItemStrings;
        [Description("自定义编辑器:自行编辑列信息"), Category("设计")]
        [Editor(typeof(MedGridViewColumnsEditor), typeof(UITypeEditor))]
        public string CustomEdit
        {
            get
            {
                return _columnItemStrings;
            }
            set
            {
                if (GetMedGridViewColumns(value))
                {
                    _columnItemStrings = value;
                    ColumnChanged();
                }
            }
        }
        private Font _ColumnHeadersDefaultCellStyleFont = new Font("宋体", 9.0f);
        private Font _DefaultCellStyleFont = new Font("宋体", 9.0f);




        private string _defalutCellPrintText = "";
        [DisplayName("单元格默认打印文本")]
        public string DefaultCellPrintText
        {
            get
            {
                return _defalutCellPrintText;
            }
            set
            {
                _defalutCellPrintText = value;
            }
        }

        private string _defaultDatas;
        [DisplayName("默认数据"), Category("设计")]
        [Editor(typeof(MedGridViewDefaultDatasEditor), typeof(UITypeEditor))]
        public string DefaultDatas
        {
            get
            {
                return _defaultDatas;
            }
            set
            {
                _defaultDatas = value;
            }
        }

        [DisplayName("列头默认字体"), Description("列头默认字体"), Category("设计")]
        public Font ColumnHeadersDefaultCellStyleFont
        {
            get
            {
                return _ColumnHeadersDefaultCellStyleFont;
            }
            set
            {
                _ColumnHeadersDefaultCellStyleFont = value;
            }
        }



        [DisplayName("单元格默认字体"), Description("单元格默认字体"), Category("设计")]
        public Font DefaultCellStyleFont
        {
            get
            {
                return _DefaultCellStyleFont;
            }
            set
            {
                _DefaultCellStyleFont = value;
            }
        }



        private bool _noPrint = false;
        [Description("不打印")]
        public bool NoPrint
        {
            get
            {
                return _noPrint;
            }
            set
            {
                _noPrint = value;
            }
        }

        private bool _printGridLine = true;
        [Description("打印网格线")]
        public bool PrintGridLine
        {
            get
            {
                return _printGridLine;
            }
            set
            {
                _printGridLine = value;
            }
        }

        private DocTempletType _templetFlag = DocTempletType.None;
        [Description("控件模板标志"), DisplayName("控件模板标志")]
        public DocTempletType TempletFlag
        {
            get
            {
                return _templetFlag;
            }
            set
            {
                _templetFlag = value;
            }
        }

        private int _linesPerPage = 20;
        [Description("每页行数")]
        public int LinesPerPage
        {
            get
            {
                return _linesPerPage;
            }
            set
            {
                _linesPerPage = value;
            }
        }

        private int _startPrintIndex = 0;
        [Browsable(false)]
        public int StartPrintIndex
        {
            get
            {
                return _startPrintIndex;
            }
            set
            {
                _startPrintIndex = value;
            }
        }

        private List<MedGridViewColumn> _medGridViewColumns;
        [Browsable(false)]
        public List<MedGridViewColumn> MedGridViewColumns
        {
            get
            {
                return _medGridViewColumns;
            }
        }

        [Browsable(false)]
        public List<string> TableNames
        {
            get
            {
                List<string> tableNames = new List<string>();
                if (_medGridViewColumns != null && _medGridViewColumns.Count > 0)
                {
                    foreach (MedGridViewColumn column in _medGridViewColumns)
                    {
                        if (!string.IsNullOrEmpty(column.TableName) && !string.IsNullOrEmpty(column.TableName.Trim()) && !tableNames.Contains(column.TableName.ToUpper()))
                        {
                            tableNames.Add(column.TableName.ToUpper());
                        }
                    }
                }
                return tableNames;
            }
        }

        [Browsable(false)]
        public List<string> FieldNames
        {
            get
            {
                List<string> list = new List<string>();
                if (_medGridViewColumns != null && _medGridViewColumns.Count > 0)
                {
                    foreach (MedGridViewColumn column in _medGridViewColumns)
                    {
                        if (!string.IsNullOrEmpty(column.TableName) && !string.IsNullOrEmpty(column.TableName.Trim()) && !string.IsNullOrEmpty(column.DataProperty)
                            && !string.IsNullOrEmpty(column.DataProperty.Trim()))
                        {
                            int index = IndexOfFieldName(list, column.DataProperty);
                            if (index < 0)
                            {
                                list.Add(column.TableName.ToUpper() + "." + column.DataProperty.ToUpper());
                            }
                        }
                    }
                }
                return list;
            }
        }

        protected virtual void ColumnChanged()
        {
        }

        public delegate Color GetRowColorEventHandle(object sender,int rowIndex, Color defaultColor);
        private static readonly object _getRowColorEvent = new object();
        public event GetRowColorEventHandle GetRowColorEvent
        {
            add
            {
                Events.AddHandler(_getRowColorEvent, value);
            }
            remove
            {
                Events.RemoveHandler(_getRowColorEvent, value);
            }
        }

        public int IndexOfFieldName(List<string> list, string fieldName)
        {
            string fName = fieldName.Trim().ToUpper();
            int index = fName.LastIndexOf(".");
            if (index > 0)
            {
                fName = fName.Substring(index + 1);
            }
            for (int i = 0; i < list.Count; i++)
            {
                string fdName = list[i];
                index = fdName.LastIndexOf(".");
                if (index > 0)
                {
                    fdName = fdName.Substring(index + 1);
                }
                if (fdName.ToUpper().Trim().Equals(fName))
                {
                    return i;
                }
            }
            return -1;
        }

        public void AutoCreateColumns()
        {
            Columns.Clear();
            if (GetMedGridViewColumns(out _medGridViewColumns))
            {
                foreach (MedGridViewColumn column in _medGridViewColumns)
                {
                    Columns.Add(column.DataProperty, column.HeaderText);
                    Columns[Columns.Count - 1].DataPropertyName = column.DataProperty;
                    Columns[Columns.Count - 1].Width = column.Width;
                    //if (column.Width < 5)
                    //{
                    //    Columns[Columns.Count - 1].Visible = false;
                    //}
                    Columns[Columns.Count - 1].AutoSizeMode = column.AutoSizeMode;
                    Columns[Columns.Count - 1].ReadOnly = column.ReadOnly;
                }
            }
        }

        private bool GetMedGridViewColumns(string value)
        {
            List<MedGridViewColumn> medGridViewColumn;
            return GetMedGridViewColumns(value, out medGridViewColumn);
        }

        public bool GetMedGridViewColumns(out List<MedGridViewColumn> medGridViewColumns)
        {
            return GetMedGridViewColumns(_columnItemStrings, out medGridViewColumns);
        }

        private bool GetMedGridViewColumns(string value,out List<MedGridViewColumn> medGridViewColumns)
        {
            medGridViewColumns = null;
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            System.IO.Stream stream = Sundries.DecodeWithString(value);
            object obj =AssemblyHelper.ReadFile(stream);
            if (obj != null && obj is List<MedGridViewColumn>)
            {
                medGridViewColumns = obj as List<MedGridViewColumn>;
                if (medGridViewColumns != null)
                {
                    foreach (MedGridViewColumn item in medGridViewColumns)
                    {
                        item.HeaderText = item.HeaderText.Replace(@"\r\n", "\r\n");
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(Graphics g, float x, float y)
        {
            float topOffSet = 0,leftOffSet = 0;
             float leftOffSetAlignmentX  = 0 ;
            bool isFirstLine = true;
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].Width < 15) continue;
                string text = Columns[i].HeaderText;
                Font font = Columns[i].HeaderCell.Style.Font;
                if (font == null)
                {
                   // font = Font;
                    font = this.ColumnHeadersDefaultCellStyle.Font;
                    if (font == null)
                    {
                        font = Font;
                    }
                }
                Color color = Color.Black;
                using (Brush brush = new SolidBrush(color))
                {
                     leftOffSetAlignmentX = 0 ;
                    if (this.ColumnHeadersDefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter || this.ColumnHeadersDefaultCellStyle.Alignment == DataGridViewContentAlignment.TopCenter || this.ColumnHeadersDefaultCellStyle.Alignment == DataGridViewContentAlignment.BottomCenter)
                    {
                       
                        leftOffSetAlignmentX =  ((Columns[i].Width - Columns[i].HeaderCell.ContentBounds.Width) / 2);
                    }
                    else
                    {
                        leftOffSetAlignmentX = 0 ;
                    }
                     g.DrawString(text, font, brush, x + leftOffSet + leftOffSetAlignmentX, Columns[i].HeaderCell.ContentBounds.Y + topOffSet + y);
                }
                if (_printGridLine)
                {
                    g.DrawLine(Pens.Black, x + leftOffSet, topOffSet + y, x + leftOffSet + Columns[i].HeaderCell.Size.Width, topOffSet + y);

                    g.DrawLine(Pens.Black, x + leftOffSet, topOffSet + y + Columns[i].HeaderCell.Size.Height, x + leftOffSet + Columns[i].HeaderCell.Size.Width, topOffSet + y + Columns[i].HeaderCell.Size.Height);
                    g.DrawLine(Pens.Black, x + leftOffSet + Columns[i].HeaderCell.Size.Width, topOffSet + y, x + leftOffSet + Columns[i].HeaderCell.Size.Width, topOffSet + y + Columns[i].HeaderCell.Size.Height);
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        g.DrawLine(Pens.Black, x + leftOffSet, topOffSet + y, x + leftOffSet, topOffSet + y + Columns[i].HeaderCell.Size.Height);
                    }
                }
                leftOffSet += Columns[i].Width;
            }
            topOffSet += ColumnHeadersHeight;
            leftOffSet = 0;
            int count = 0;
            for(int k = _startPrintIndex; k < Rows.Count; k++) 
            {
                DataGridViewRow row = Rows[k];
                isFirstLine = true;
                for (int i = 0; i < Columns.Count; i++)
                {
                    if (Columns[i].Width < 15) continue;
                    if (row.Cells[i].Tag != null || (row.Cells[i].Value != null && row.Cells[i].Value != System.DBNull.Value) || !string.IsNullOrEmpty(_defalutCellPrintText))
                    {
                        string text;
                        if (row.Cells[i].Tag != null)
                        {
                            text = row.Cells[i].Tag.ToString();
                        }
                        else if (row.Cells[i].Value != null && row.Cells[i].Value != System.DBNull.Value)
                        {
                            text = row.Cells[i].Value.ToString();
                        }
                        else
                        {
                            text = _defalutCellPrintText;
                        }
                        Font font = row.Cells[i].Style.Font;
                        if(font == null)
                        {

                            //font = Font;
                            font = this.DefaultCellStyle.Font;

                            if (font == null)
                            {
                                font = Font;
                            }
                          
                        }
                        Color color = Color.Black;
                        int index = text.LastIndexOf(",");
                        if (index > 0)
                        {
                            color = AssemblyHelper.ColorFromString(text.Substring(index + 1));
                            text = text.Substring(0, index);
                        }
                        using (Brush brush = new SolidBrush(color))
                        {
                            g.DrawString(text, font, brush, x + row.Cells[i].ContentBounds.X + leftOffSet, row.Cells[i].ContentBounds.Y + topOffSet + y);
                        }
                    }
                    if (_printGridLine)
                    {
                        g.DrawLine(Pens.Black, x + leftOffSet, topOffSet + y + row.Cells[i].Size.Height, x + leftOffSet + row.Cells[i].Size.Width, topOffSet + y + row.Cells[i].Size.Height);
                        g.DrawLine(Pens.Black, x + leftOffSet + row.Cells[i].Size.Width, topOffSet + y, x + leftOffSet + row.Cells[i].Size.Width, topOffSet + y + row.Cells[i].Size.Height);
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            g.DrawLine(Pens.Black, x + leftOffSet, topOffSet + y, x + leftOffSet, topOffSet + y + row.Cells[i].Size.Height);
                        }
                    }
                    leftOffSet += Columns[i].Width;
                }
                topOffSet += row.Height;
                leftOffSet = 0;
                count++;
                if (count >= _linesPerPage) break;
            }
        }

        private Color GetRowColor(int rowIndex, Color defaultColor)
        {
            GetRowColorEventHandle eventHandle = Events[_getRowColorEvent] as GetRowColorEventHandle;
            if (eventHandle != null)
            {
                return eventHandle(this, rowIndex, defaultColor);
            }
            return defaultColor;
        }

        private void MedGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            MedGridView grid = sender as MedGridView;
            if (e.Value != null && e.Value != System.DBNull.Value && e.ColumnIndex >= 0)
            {
                if (e.RowIndex >= 0)
                {
                    Rectangle rect = e.CellBounds;
                    e.Handled = true;
                    e.PaintBackground(rect, true);
                    string text = e.Value.ToString();
                    Color color = e.CellStyle.ForeColor;
                    if (grid.SelectedCells != null && grid.SelectedCells.Count > 0 && grid.SelectedCells.Contains(grid.Rows[e.RowIndex].Cells[e.ColumnIndex]))
                    {
                        color = e.CellStyle.SelectionForeColor;
                    }
                    if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
                    {
                        text = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString();
                        int index = text.LastIndexOf(",");
                        if (index > 0)
                        {
                            color = AssemblyHelper.ColorFromString(text.Substring(index + 1));
                            text = text.Substring(0, index);
                        }
                    }
                    color = GetRowColor(e.RowIndex, color);
                    using (Brush brush = new SolidBrush(color))
                    {
                        e.Graphics.DrawString(text, e.CellStyle.Font, brush, rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                    }
                }
                else//列标题处理
                {
                    if (e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width > e.CellBounds.Width - 5)
                    {
                        Rectangle rect = e.CellBounds;
                        e.Handled = true;
                        e.PaintBackground(rect, true);
                        string text = e.Value.ToString();
                        using (Brush cellBrush = new SolidBrush(e.CellStyle.ForeColor))
                        {
                            e.Graphics.DrawString(text, e.CellStyle.Font, cellBrush, rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                        }
                    }
                }
            }
       
        }

    }
}
