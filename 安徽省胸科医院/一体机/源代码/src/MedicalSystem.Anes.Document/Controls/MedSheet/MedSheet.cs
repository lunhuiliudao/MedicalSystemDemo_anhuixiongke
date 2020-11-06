using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable, ToolboxItem(false), Description("麻醉表格")]
    public partial class MedSheet : UserControl, IPrintable
    {

        private List<MedSheetRow> _rows = new List<MedSheetRow>();
        [DisplayName("行集合")]
        public List<MedSheetRow> Rows
        {
            get
            {
                CheckRows();
                return _rows;
            }
            set
            {
                _rows = value;

                for (int i = 0; i < _rows.Count; i++)
                {
                    foreach (MedSheetCell cell in _rows[i].Cells)
                    {
                        cell.SetRowIndex(i);
                    }
                }
            }
        }

        private List<MedSheetCol> _cols = new List<MedSheetCol>();
        [DisplayName("列集合")]
        public List<MedSheetCol> Cols
        {
            get
            {
                return _cols;
            }
            set
            {
                _cols = value;
            }
        }

        private string _title = "";
        [DisplayName("标题")]
        public string Title
        {
            get
            {
                return GetLineString(_title);
            }
            set
            {
                _title = GetLineString(value);
            }
        }

        
        private float _titleWidth = 20;
        [DisplayName("标题宽度")]
        public float TitleWidth
        {
            get
            {
                return _titleWidth;
            }
            set
            {
                _titleWidth = value;
            }
        }

        private float _rowTitleWidth = 80;
        [DisplayName("行标题宽度")]
        public float RowTitleWidth
        {
            get
            {
                return _rowTitleWidth;
            }
            set
            {
                _rowTitleWidth = value;
            }
        }

        private Font _customFont = new Font("宋体", 9);
        [DisplayName("字体")]
        public Font CustomFont
        {
            get
            {
                return _customFont;
            }
            set
            {
                _customFont = value;
            }
        }

        private bool _noPrint = false;
        public bool NoPrint
        {
            get 
            { 
                return _noPrint; 
            }
        }

        ///// <summary>
        ///// 修改监测项目值
        ///// </summary>
        //private NewMonitorData _newMonitorData = null;
        //public NewMonitorData NewMonitorData
        //{
        //    get
        //    {
        //        return _newMonitorData;
        //    }
        //    set
        //    {
        //        _newMonitorData = value;
        //    }
        //}

        private List<MedSheetDetail> _curveDetails = new List<MedSheetDetail>();
        [Category("数据-自定义"), DisplayName("曲线明细设置")]
        public List<MedSheetDetail> CurveDetails
        {
            get
            {
                return _curveDetails;
            }
            set
            {
                _curveDetails = value;
            }
        }

        public MedSheet()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(MedSheet_Paint);
            if (!DesignMode)
            {
                Load += new EventHandler(MedSheet_Load);
            }
        }

        private void CheckRows()
        {
            if (_rows != null && _cols != null)
            {
                foreach (MedSheetRow row in _rows)
                {
                    while (row.Cells.Count < _cols.Count)
                    {
                        row.Cells.Add(new MedSheetCell());
                    }
                }
            }
        }
 
       private string GetLineString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            else
            {
                return text.Replace(@"\r\n", "\r\n");
            }
        }

        public void Draw(Graphics g, float x, float y)
        {
            using (Pen pen = new Pen(Color.Black))
            {
                if (_cols != null && _rows != null && _cols.Count > 0 && _rows.Count > 0)
                {
                    float cellWidth = (Width - _titleWidth - _rowTitleWidth) / _cols.Count;
                    float cellHeight = (Height - 1) / _rows.Count;
                    if (_titleWidth > 0)
                    {
                        g.DrawLine(pen, x, y, x, y + Height - 1);
                        g.DrawLine(pen, x, y, x + _titleWidth, y);
                        g.DrawLine(pen, x, y + Height - 1, x + _titleWidth, y + Height - 1);
                        if (!string.IsNullOrEmpty(_title))
                        {
                            g.DrawString(_title, _customFont, Brushes.Black, x + (_titleWidth - g.MeasureString(_title, _customFont).Width) / 2
                                , y + (Height - g.MeasureString(_title, _customFont).Height) / 2);
                        }
                    }
                    if (_rowTitleWidth > 0)
                    {
                        g.DrawLine(pen, x + _titleWidth, y, x + _titleWidth, y + Height - 1);
                        g.DrawLine(pen, x + _titleWidth, y, x + _titleWidth + _rowTitleWidth, y);
                        g.DrawLine(pen, x + _titleWidth, y + Height - 1, x + _titleWidth + _rowTitleWidth, y + Height - 1);
                        if (!string.IsNullOrEmpty(_title))
                        {
                            g.DrawString(_title, _customFont, Brushes.Black, x + (_titleWidth - g.MeasureString(_title, _customFont).Width) / 2
                                , y + (Height - g.MeasureString(_title, _customFont).Height) / 2);
                        }
                        for (int i = 0; i < _rows.Count; i++)
                        {
                            g.DrawLine(pen, x + _titleWidth, y + i * cellHeight, x + _titleWidth + _rowTitleWidth, y + i * cellHeight);
                            if (!string.IsNullOrEmpty(_rows[i].Title))
                            {
                                g.DrawString(_rows[i].Title, _customFont, Brushes.Black, x + _titleWidth + (_rowTitleWidth - g.MeasureString(_rows[i].Title, _customFont).Width) / 2
                                    , y + i * cellHeight + (cellHeight - g.MeasureString(_rows[i].Title, _customFont).Height) / 2);
                            }
                        }
                    }
                    CheckRows();
                    for (int i = 0; i < _rows.Count; i++)
                    {
                        List<int> spanColIndexes = new List<int>();
                        for (int j = 0; j < _cols.Count; j++)
                        {
                            Rectangle rect = new Rectangle();
                            rect.X = Convert.ToInt32(x + _titleWidth + _rowTitleWidth + cellWidth * j);
                            rect.Y = Convert.ToInt32(y + i * cellHeight);
                            rect.Width = Convert.ToInt32(cellWidth * _rows[i].Cells[j].ColSpan);
                            rect.Height = Convert.ToInt32(cellHeight);
                            _rows[i].Cells[j].DrawRectangel = rect;

                            g.DrawLine(pen, x + _titleWidth + _rowTitleWidth + cellWidth * j, y + i * cellHeight, x + _titleWidth + _rowTitleWidth + cellWidth * j + cellWidth, y + i * cellHeight);
                            if (!spanColIndexes.Contains(j))
                            {
                                g.DrawLine(pen, x + _titleWidth + _rowTitleWidth + cellWidth * j, y + i * cellHeight, x + _titleWidth + _rowTitleWidth + cellWidth * j, y + i * cellHeight + cellHeight);
                                if (_rows[i].Cells[j].Value != null)
                                {
                                    string text = _rows[i].Cells[j].Value.ToString();
                                    if (!string.IsNullOrEmpty(text))
                                    {
                                        g.DrawString(text, _customFont, Brushes.Black, x + _titleWidth + _rowTitleWidth + cellWidth * j
                                            + (cellWidth * _rows[i].Cells[j].ColSpan - g.MeasureString(text, _customFont).Width) / 2
                                            , y + i * cellHeight + (cellHeight - g.MeasureString(text, _customFont).Height) / 2);
                                    }
                                }
                                if (_rows[i].Cells[j].ColSpan > 1)
                                {
                                    for (int k = 1; k < _rows[i].Cells[j].ColSpan; k++)
                                    {
                                        if (!spanColIndexes.Contains(k + j))
                                        {
                                            spanColIndexes.Add(k + j);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    g.DrawLine(pen, x + Width - 1, y, x + Width - 1, y + Height - 1);
                    g.DrawLine(pen, x + _titleWidth + _rowTitleWidth, y + Height - 1, x + Width - 1, y + Height - 1);
                }
                else
                {
                    g.DrawRectangle(pen, x, y, Width - 1, Height - 1);
                }
            }
        }

        private void MedSheet_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics,0,0);
        }

        private void MedSheet_Load(object sender, EventArgs e)
        {
        }
    }
}
