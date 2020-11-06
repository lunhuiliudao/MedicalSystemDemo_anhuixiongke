using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MedicalSystem.AnesWorkStation.Domain;
using System.Collections;
using System.Drawing;

namespace MedicalSystem.Anes.FrameWork
{
    public enum DataEnum
    {
        NotSet,
        DataTable,
        DataRows,
        BaseModel
    }
    /// <summary>
    /// 弹出的Gridview控件
    /// </summary>
    public class GridViewPopup : BaseControl
    {
        public GridViewPopup()
        {
            InitializeComponent();
            PageSize = 10;
            MultiChar = ",";
            bottomMsg = this.lblBottom.Text;
        }

        #region InitializeComponent

        private readonly string bottomMsg = null;
        private DataGridView dataGridView1;
        private Label lblBottom;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblBottom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(186)))), ((int)(((byte)(248)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(186)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(186)))), ((int)(((byte)(248)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.DividerHeight = 1;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(280, 139);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // lblBottom
            // 
            this.lblBottom.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBottom.Font = new System.Drawing.Font("宋体", 12F);
            this.lblBottom.Location = new System.Drawing.Point(0, 139);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Padding = new System.Windows.Forms.Padding(4);
            this.lblBottom.Size = new System.Drawing.Size(280, 26);
            this.lblBottom.TabIndex = 1;
            this.lblBottom.Text = "按数字键0-9选中；按←→前后翻页";
            // 
            // GridViewPopup
            // 
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblBottom);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GridViewPopup";
            this.Size = new System.Drawing.Size(280, 165);
            this.Resize += new System.EventHandler(this.GridViewPopup_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region 分页信息

        private int _pageSize = 10;
        /// <summary>
        /// 每页记录数
        /// </summary>
        [DefaultValue(10)]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value < 1 ? 1 : value; this.Height = GetHeightByRows(_pageSize); }
        }

        public int PageCount
        {
            get
            {
                if (DataSource == null)
                    return 1;

                int count = 0;

                switch (dataType)
                {
                    case DataEnum.DataTable:
                    case DataEnum.DataRows:
                        count = currentDataRowSource.Count;
                        break;
                    case DataEnum.BaseModel:
                        count = currentDataModelSource.Count;
                        break;
                    default:
                        break;
                }

                return (int)Math.Ceiling(count * 1f / (PageSize - SelectedIndexs.Count));
            }
        }

        private int _pageIndex = 1;
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                if (value > PageCount)
                {
                    _pageIndex = PageCount;
                }
                else if (value < 1)
                {
                    _pageIndex = 1;
                }
                else
                {
                    _pageIndex = value;
                }
            }
        }

        #endregion

        #region 根据分页计算下拉的高度 GetHeightByRows(int pageSize)

        /// <summary>
        /// 根据分页计算下拉的高度
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        private int GetHeightByRows(int pageSize)
        {
            return this.dataGridView1.RowTemplate.Height * pageSize
                + this.lblBottom.Height
                + this.Padding.Top
                + this.Padding.Bottom;
        }

        #endregion

        #region DataSource

        private object _dataSource = null;
        /// <summary>
        /// 获取或设置 System.Windows.Forms.DataGridView 所显示数据的数据源。
        /// </summary>
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public object DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;

                if (value is DataTable)
                {
                    dataType = DataEnum.DataTable;
                    DataTable dt = DataSource as DataTable;
                    _dataRowSource = dt.Rows.Cast<DataRow>().ToList();
                    currentDataRowSource = new List<DataRow>(_dataRowSource);
                }
                else if (DataSource is DataRow[])
                {
                    dataType = DataEnum.DataRows;
                    _dataRowSource = (DataSource as DataRow[]).ToList();
                    currentDataRowSource = new List<DataRow>(_dataRowSource);
                }
                else
                {
                    Type desiredType = null;
                    Type elemType = null;
                    if (IsGenericList(desiredType = DataSource.GetType())
                        && ((elemType = desiredType.GetGenericArguments()[0]) == typeof(BaseModel)
                            || elemType.IsSubclassOf(typeof(BaseModel))))
                    {
                        dataType = DataEnum.BaseModel;
                        _dataModelSource = (DataSource as IList).Cast<BaseModel>().ToList();
                        currentDataModelSource = new List<BaseModel>(_dataModelSource);
                    }
                    else
                    {
                        throw new NotSupportedException(desiredType.Name);
                    }
                }
            }
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        private DataEnum dataType { get; set; }
        /// <summary>
        /// 转成DataRow数据源模式
        /// </summary>
        private List<DataRow> _dataRowSource = null;
        /// <summary>
        /// 转成BaseModel数据源模式
        /// </summary>
        private List<BaseModel> _dataModelSource = null;

        /// <summary>
        /// 匹配后的数据源
        /// </summary>
        private List<DataRow> currentDataRowSource = null;
        /// <summary>
        /// 匹配后的数据源
        /// </summary>
        private List<BaseModel> currentDataModelSource = null;

        /// <summary>
        /// 匹配后的当前页的数据源
        /// </summary>
        private List<DataRow> currentPageRowSource
        {
            get
            {
                List<DataRow> tmpList = new List<DataRow>();
                foreach (var index in SelectedIndexs)
                {
                    tmpList.Add(_dataRowSource[index]);
                }
                tmpList.AddRange(currentDataRowSource
                    .Skip((PageIndex - 1) * (PageSize - SelectedIndexs.Count))
                    .Take(PageSize - SelectedIndexs.Count));
                return tmpList;
            }
        }
        /// <summary>
        /// 匹配后的当前页的数据源
        /// </summary>
        private List<BaseModel> currentPageModelSource
        {
            get
            {
                List<BaseModel> tmpList = new List<BaseModel>();
                foreach (var index in SelectedIndexs)
                {
                    tmpList.Add(_dataModelSource[index]);
                }
                tmpList.AddRange(currentDataModelSource
                    .Skip((PageIndex - 1) * (PageSize - SelectedIndexs.Count))
                    .Take(PageSize - SelectedIndexs.Count));
                return tmpList;
            }
        }

        protected DataTable PageSource = new DataTable();

        Dictionary<string, float> dictWidth = new Dictionary<string, float>();

        /// <summary>
        /// 数字键行号的列名
        /// </summary>
        const string rowNo = "RowNo";

        private List<string> gridViewMembers = null;
        private string _gridViewMember = null;
        public string GridViewMember
        {
            get { return _gridViewMember; }
            set
            {
                _gridViewMember = value;

                PageSource.Columns.Add(rowNo);
                dictWidth[rowNo] = GetFontWidth("8");

                gridViewMembers = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var column in gridViewMembers)
                {
                    PageSource.Columns.Add(column);
                }
                reSetWidth();

                dataGridView1.Columns.Clear();
                foreach (var item in dictWidth)
                {
                    var column = new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = item.Key,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                        FillWeight = item.Value,
                        HeaderText = item.Key,
                        Name = item.Key,
                        ReadOnly = true,
                        Resizable = System.Windows.Forms.DataGridViewTriState.False
                    };
                    column.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns.Add(column);
                }

            }
        }
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public bool MultiSelect { get; set; }
        public string MultiChar { get; set; }

        private readonly List<int> _selectedIndexs = new List<int>();
        /// <summary>
        /// 选中的数据源的行号
        /// </summary>
        public List<int> SelectedIndexs { get { return _selectedIndexs; } }

        /// <summary>
        /// 获取当前的值 - <see cref="ValueMember"/>
        /// </summary>
        public string SelectedValue
        {
            get
            {
                if (SelectedIndexs.Count == 0)
                {
                    return "";
                }
                switch (dataType)
                {
                    case DataEnum.DataTable:
                    case DataEnum.DataRows:
                        if (_dataRowSource != null)
                        {
                            if (!MultiSelect)
                            {
                                var currentRow = _dataRowSource[SelectedIndexs[0]];
                                return Convert.ToString(currentRow[this.ValueMember]) ?? "";
                            }
                            else
                            {
                                var vals = SelectedIndexs.Select(x => _dataRowSource[x]).Select(x => Convert.ToString(x[this.ValueMember]) ?? "").ToArray();
                                return string.Join(this.MultiChar, vals);
                            }
                        }
                        break;
                    case DataEnum.BaseModel:
                        if (_dataModelSource != null)
                        {
                            if (!MultiSelect)
                            {
                                var currentRow = _dataModelSource[SelectedIndexs[0]];
                                return Convert.ToString(currentRow.GetValue(this.ValueMember)) ?? "";
                            }
                            else
                            {
                                var vals = SelectedIndexs.Select(x => _dataModelSource[x]).Select(x => Convert.ToString(x.GetValue(this.ValueMember)) ?? "").ToArray();
                                return string.Join(this.MultiChar, vals);
                            }
                        }
                        break;
                    default:
                        break;
                }
                return "";
            }
            set
            {
                SelectedIndexs.Clear();
                if (!string.IsNullOrEmpty(value))
                {
                    switch (dataType)
                    {
                        case DataEnum.DataTable:
                        case DataEnum.DataRows:
                            if (_dataRowSource != null)
                            {
                                if (!MultiSelect)
                                {
                                    var currentRow = _dataRowSource
                                        .FirstOrDefault(x => Convert.ToString(x[this.ValueMember]) == value);
                                    if (currentRow != null)
                                    {
                                        SelectedIndexs.Add(_dataRowSource.IndexOf(currentRow));
                                        //从当前数据源中移除已选中的数据行
                                        currentDataRowSource.Remove(currentRow);
                                    }
                                }
                                else
                                {
                                    var vals = value.Split(new string[] { this.MultiChar }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                    var currentRows = _dataRowSource
                                        .Where(x => vals.Contains(Convert.ToString(x[this.ValueMember])))
                                        .OrderBy(x => vals.IndexOf(Convert.ToString(x[this.ValueMember])))
                                        .ToList();
                                    SelectedIndexs.AddRange(currentRows.Select(x => _dataRowSource.IndexOf(x)));
                                    //从当前数据源中移除已选中的数据行
                                    currentRows.ForEach(item => { currentDataRowSource.Remove(item); });
                                }
                            }
                            break;
                        case DataEnum.BaseModel:
                            if (_dataModelSource != null)
                            {
                                if (!MultiSelect)
                                {
                                    var currentRow = _dataModelSource
                                        .FirstOrDefault(x => Convert.ToString(x.GetValue(this.ValueMember)) == value);
                                    if (currentRow != null)
                                    {
                                        SelectedIndexs.Add(_dataModelSource.IndexOf(currentRow));
                                        //从当前数据源中移除已选中的数据行
                                        currentDataModelSource.Remove(currentRow);
                                    }
                                }
                                else
                                {
                                    var vals = value.Split(new string[] { this.MultiChar }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                    var currentRows = _dataModelSource
                                        .Where(x => vals.Contains(Convert.ToString(x.GetValue(this.ValueMember))))
                                        .OrderBy(x => vals.IndexOf(Convert.ToString(x.GetValue(this.ValueMember))))
                                        .ToList();
                                    SelectedIndexs.AddRange(currentRows.Select(x => _dataModelSource.IndexOf(x)));
                                    //从当前数据源中移除已选中的数据行
                                    currentRows.ForEach(item => { currentDataModelSource.Remove(item); });
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                DataBind();
                return;
            }
        }

        /// <summary>
        /// 获取当前的值 - <see cref="DisplayMember"/>
        /// </summary>
        public string SelectedText
        {
            get
            {
                if (SelectedIndexs.Count == 0)
                {
                    return "";
                }
                switch (dataType)
                {
                    case DataEnum.DataTable:
                    case DataEnum.DataRows:
                        if (_dataRowSource != null)
                        {
                            if (!MultiSelect)
                            {
                                var currentRow = _dataRowSource[SelectedIndexs[0]];
                                return Convert.ToString(currentRow[this.DisplayMember]) ?? "";
                            }
                            else
                            {
                                var vals = SelectedIndexs.Select(x => _dataRowSource[x]).Select(x => Convert.ToString(x[this.DisplayMember]) ?? "").ToArray();
                                return string.Join(this.MultiChar, vals);
                            }
                        }
                        break;
                    case DataEnum.BaseModel:
                        if (_dataModelSource != null)
                        {
                            if (!MultiSelect)
                            {
                                var currentRow = _dataModelSource[SelectedIndexs[0]];
                                return Convert.ToString(currentRow.GetValue(this.DisplayMember)) ?? "";
                            }
                            else
                            {
                                var vals = SelectedIndexs.Select(x => _dataModelSource[x]).Select(x => Convert.ToString(x.GetValue(this.DisplayMember)) ?? "").ToArray();
                                return string.Join(this.MultiChar, vals);
                            }
                        }
                        break;
                    default:
                        break;
                }
                return "";
            }
            set
            {
                SelectedIndexs.Clear();
                if (!string.IsNullOrEmpty(value))
                {
                    switch (dataType)
                    {
                        case DataEnum.DataTable:
                        case DataEnum.DataRows:
                            if (_dataRowSource != null)
                            {
                                if (!MultiSelect)
                                {
                                    var currentRow = _dataRowSource
                                        .FirstOrDefault(x => Convert.ToString(x[this.DisplayMember]) == value);
                                    if (currentRow != null)
                                    {
                                        SelectedIndexs.Add(_dataRowSource.IndexOf(currentRow));
                                        //从当前数据源中移除已选中的数据行
                                        currentDataRowSource.Remove(currentRow);
                                    }
                                }
                                else
                                {
                                    var vals = value.Split(new string[] { this.MultiChar }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                    var currentRows = _dataRowSource
                                        .Where(x => vals.Contains(Convert.ToString(x[this.DisplayMember])))
                                        .OrderBy(x => vals.IndexOf(Convert.ToString(x[this.DisplayMember])))
                                        .ToList();
                                    SelectedIndexs.AddRange(currentRows.Select(x => _dataRowSource.IndexOf(x)));
                                    //从当前数据源中移除已选中的数据行
                                    currentRows.ForEach(item => { currentDataRowSource.Remove(item); });
                                }
                            }
                            break;
                        case DataEnum.BaseModel:
                            if (_dataModelSource != null)
                            {
                                if (!MultiSelect)
                                {
                                    var currentRow = _dataModelSource
                                        .FirstOrDefault(x => Convert.ToString(x.GetValue(this.DisplayMember)) == value);
                                    if (currentRow != null)
                                    {
                                        SelectedIndexs.Add(_dataModelSource.IndexOf(currentRow));
                                        //从当前数据源中移除已选中的数据行
                                        currentDataModelSource.Remove(currentRow);
                                    }
                                }
                                else
                                {
                                    var vals = value.Split(new string[] { this.MultiChar }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                    var currentRows = _dataModelSource
                                        .Where(x => vals.Contains(Convert.ToString(x.GetValue(this.DisplayMember))))
                                        .OrderBy(x => vals.IndexOf(Convert.ToString(x.GetValue(this.DisplayMember))))
                                        .ToList();
                                    SelectedIndexs.AddRange(currentRows.Select(x => _dataModelSource.IndexOf(x)));
                                    //从当前数据源中移除已选中的数据行
                                    currentRows.ForEach(item => { currentDataModelSource.Remove(item); });
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                DataBind();
                return;
            }
        }

        private void reSetWidth()
        {
            foreach (var column in gridViewMembers)
            {
                dictWidth[column] = dictWidth[rowNo];
            }
        }

        /// <summary>
        /// 绑定到数据源上。
        /// </summary>
        public void DataBind()
        {
            if (DataSource == null)
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                int i = 1;
                PageSource.Clear();
                reSetWidth();

                switch (dataType)
                {
                    case DataEnum.DataTable:
                    case DataEnum.DataRows:
                        {
                            foreach (var item in currentPageRowSource)
                            {
                                DataRow dr = PageSource.NewRow();
                                PageSource.Rows.Add(dr);
                                dr[rowNo] = i % (PageSize < 10 ? 10 : PageSize);
                                foreach (DataColumn column in PageSource.Columns)
                                {
                                    if (column.ColumnName != rowNo)
                                    {
                                        string val = Convert.ToString(item[column.ColumnName]);
                                        dr[column.ColumnName] = val;
                                        dictWidth[column.ColumnName] += GetFontWidth(val);
                                    }
                                }
                                i++;
                            }
                        }
                        break;
                    case DataEnum.BaseModel:
                        {
                            foreach (var item in currentPageModelSource)
                            {
                                DataRow dr = PageSource.NewRow();
                                PageSource.Rows.Add(dr);
                                dr[rowNo] = i % (PageSize < 10 ? 10 : PageSize);
                                foreach (DataColumn column in PageSource.Columns)
                                {
                                    if (column.ColumnName != rowNo)
                                    {
                                        string val = Convert.ToString(item.GetValue(column.ColumnName));
                                        dr[column.ColumnName] = val;
                                        dictWidth[column.ColumnName] += GetFontWidth(val);
                                    }
                                }
                                i++;
                            }
                        }
                        break;
                    default:
                        break;
                }

                ResizeGridView();

                dataGridView1.DataSource = PageSource;
                if (EnterString.Length > 0)
                {
                    this.lblBottom.Text = EnterString;
                }
                else
                {
                    this.lblBottom.Text = bottomMsg;
                }
                for (int s = 0; s < SelectedIndexs.Count && s < dataGridView1.Rows.Count; s++)
                {
                    dataGridView1.Rows[s].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[s].Cells[0];
                }
            }
        }

        private void GridViewPopup_Resize(object sender, EventArgs e)
        {
            ResizeGridView();
        }

        /// <summary>
        /// 文字超长时，调整非正常的宽度问题。
        /// </summary>
        private void ResizeGridView()
        {
            if (dictWidth.Count == 0)
                return;
            /*
                 * 1      83      16  总长度 200
                 * 20  (83/99)*(200-20)
                 * 
                 * (x + 1) * 200 / (100 + x) = 20
                 * 200x + 200 = 2000 + 20x
                 * 180x = 1800
                 */
            //文字超长时，调整非正常的宽度问题。
            int minRowWidth = 20;
            float width1 = dictWidth[rowNo];
            float count = dictWidth.Sum(x => x.Value);
            float rowWidth = (width1 / count) * this.Width;
            if (rowWidth < minRowWidth)
            {
                //int x = 0;
                //(width1 + x) * this.Width = minRowWidth * (count + x);
                //(this.Width - minRowWidth) * x = minRowWidth * count - this.Width * width1;
                dictWidth[rowNo] = width1 + (minRowWidth * count - this.Width * width1) / (this.Width - minRowWidth);
            }

            foreach (DataGridViewTextBoxColumn item in dataGridView1.Columns)
            {
                item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                item.FillWeight = dictWidth[item.Name];
                if (rowNo != item.Name)
                {
                    item.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    item.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private Graphics g = null;
        private float GetFontWidth(string str)
        {
            if (this.IsDisposed)
            {
                return 1f;
            }
            if (g == null)
                g = this.CreateGraphics();
            SizeF size = g.MeasureString(str, this.dataGridView1.Font);
            return size.Width;
        }

        protected override void Dispose(bool disposing)
        {
            if (g != null)
                g.Dispose();
            base.Dispose(disposing);
        }

        #endregion

        public override bool RegisterControlByHotKey(Keys keyCode)
        {
            if (keyCode == Keys.Enter)
            {
                if (this.dataGridView1.CurrentRow != null)
                {
                    int keyIndex = this.dataGridView1.CurrentRow.Index + 1;
                    if (this.Selected != null)
                    {
                        var popupEvent = SetPopupEvent(keyIndex);

                        if (!MultiSelect) //单选
                        {
                            SetDisplayValue(popupEvent);
                            this.Selected(popupEvent);
                            EnterString = "";
                            this.Close();
                        }
                        else //多选
                        {
                            //不存在时，选中状态，否则无响应
                            popupEvent.IsClosed = false;
                            SetDisplayValue(popupEvent);
                            this.Selected(popupEvent);
                            EnterString = "";
                            PageIndex = 1;
                            this.DataBind();
                        }
                    }
                }
            }
            return base.RegisterControlByHotKey(keyCode);
        }
        public override bool RegisterControlByHotKey(string keyCode)
        {
            if (keyCode == KeyCode.AppCode.Back)
            {
                this.Close();
                if (this.Selected != null)
                {
                    this.Selected(null);
                }
                return true;
            }
            return base.RegisterControlByHotKey(keyCode);
        }

        #region 事件

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private string _enterString = "";
        /// <summary>
        /// 模糊查询的字符
        /// </summary>
        private string EnterString
        {
            get { return _enterString; }
            set
            {
                string upString = value.ToUpper().Trim();
                bool strNext = !string.IsNullOrEmpty(upString) && value.Length >= _enterString.Length; //在前一次筛选过的基础上筛选，节省时间
                _enterString = value;

                switch (dataType)
                {
                    case DataEnum.DataTable:
                    case DataEnum.DataRows:
                        {
                            List<DataRow> tmpList = null;
                            if (strNext) //在前一次筛选过的基础上筛选，节省时间
                            {
                                tmpList = new List<DataRow>(currentDataRowSource);
                            }
                            else
                            {
                                tmpList = new List<DataRow>(_dataRowSource);
                            }

                            currentDataRowSource.Clear();

                            SelectedIndexs.ForEach(index =>
                            {
                                tmpList.Remove(_dataRowSource[index]);
                            });

                            tmpList.ForEach(item =>
                            {
                                if (string.IsNullOrEmpty(upString) || gridViewMembers
                                    .Exists(y => (Convert.ToString(item[y]) ?? "").ToUpper().Contains(upString)))
                                {
                                    currentDataRowSource.Add(item);
                                }
                            });

                            tmpList.Clear();
                            tmpList = null;
                        }
                        break;
                    case DataEnum.BaseModel:
                        {
                            List<BaseModel> tmpList = null;
                            if (strNext) //在前一次筛选过的基础上筛选，节省时间
                            {
                                tmpList = new List<BaseModel>(currentDataModelSource);
                            }
                            else
                            {
                                tmpList = new List<BaseModel>(_dataModelSource);
                            }

                            currentDataModelSource.Clear();

                            SelectedIndexs.ForEach(index =>
                            {
                                tmpList.Remove(_dataModelSource[index]);
                            });

                            tmpList.ForEach(item =>
                            {
                                if (string.IsNullOrEmpty(upString) || gridViewMembers
                                    .Exists(y => (Convert.ToString(item.GetValue(y)) ?? "").ToUpper().Contains(upString)))
                                {
                                    currentDataModelSource.Add(item);
                                }
                            });

                            tmpList.Clear();
                            tmpList = null;

                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 根据选中行，读取记录表中的行号和数据，排除多选的情况
        /// </summary>
        /// <param name="popupEvent"></param>
        private GridViewPopupEventArgs SetPopupEvent(int keyIndex)
        {
            GridViewPopupEventArgs popupEvent = new GridViewPopupEventArgs(this);

            switch (dataType)
            {
                case DataEnum.DataTable:
                case DataEnum.DataRows:
                    {
                        var item = currentPageRowSource.Skip(keyIndex - 1).FirstOrDefault();
                        popupEvent.RowIndex = _dataRowSource.IndexOf(item);
                        popupEvent.RowSource = item;
                    }
                    break;
                case DataEnum.BaseModel:
                    {
                        var item = currentPageModelSource.Skip(keyIndex - 1).FirstOrDefault();
                        popupEvent.RowIndex = _dataModelSource.IndexOf(item);
                        popupEvent.RowSource = item;
                    }
                    break;
                default:
                    break;
            }

            if (!MultiSelect) //单选
            {
                SelectedIndexs.Clear();
                SelectedIndexs.Add(popupEvent.RowIndex);
            }
            else //多选
            {
                //不存在时，选中状态，否则无响应
                if (!SelectedIndexs.Contains(popupEvent.RowIndex))
                {
                    SelectedIndexs.Add(popupEvent.RowIndex);
                }
                else
                {
                    SelectedIndexs.Remove(popupEvent.RowIndex);
                }
            }
            popupEvent.SelectedIndexs = SelectedIndexs;

            return popupEvent;
        }

        private void SetDisplayValue(GridViewPopupEventArgs e)
        {
            if (e == null)
                return;

            e.Display = this.SelectedText;
            e.Value = this.SelectedValue;
        }

        [Obsolete("请使用SelectedValue,SelectedText属性。")]
        public string GetDisplayByValue(string value)
        {
            if (DataSource == null)
                return "";

            this.SelectedValue = value;

            return this.SelectedText;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            for (int s = 0; s < dataGridView1.Rows.Count; s++)
            {
                var item = dataGridView1.Rows[s];
                if (s < SelectedIndexs.Count)
                {
                    item.Selected = true;
                }
                if (dataGridView1.CurrentRow == item)
                {
                    item.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(248)))));
                    item.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                }
                else
                {
                    item.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(186)))), ((int)(((byte)(248)))));
                    item.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                }
            }
        }

        /// <summary>
        /// 处理键盘操作等信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                PageIndex++;
                DataBind();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                PageIndex--;
                DataBind();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (this.MultiSelect && this.SelectedIndexs.Count >= 1)
                {
                    if (this.Selected != null)
                    {
                        GridViewPopupEventArgs popupEvent = new GridViewPopupEventArgs(this)
                        {
                            SelectedIndexs = this.SelectedIndexs
                        };
                        SetDisplayValue(popupEvent);
                        //不存在时，选中状态，否则无响应
                        this.Selected(popupEvent);
                    }
                }
                else if (this.dataGridView1.CurrentRow != null)
                {
                    int keyIndex = this.dataGridView1.CurrentRow.Index + 1;
                    if (this.Selected != null)
                    {
                        var popupEvent = SetPopupEvent(keyIndex);

                        if (!MultiSelect) //单选
                        {
                            SetDisplayValue(popupEvent);
                            this.Selected(popupEvent);
                            EnterString = "";
                        }
                        else //多选
                        {
                            SetDisplayValue(popupEvent);
                            //不存在时，选中状态，否则无响应
                            this.Selected(popupEvent);
                        }
                    }
                }
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                if (this.MultiSelect)
                {
                    if (this.Selected != null)
                    {
                        this.Selected(null);
                    }
                }
            }
            else if (e.KeyCode == Keys.Back) //删除键
            {
                if (EnterString.Length > 0) //当多选时，删除选择项，删空时退出
                {
                    EnterString = EnterString.Substring(0, EnterString.Length - 1);
                    PageIndex = 1;
                    this.DataBind();
                }
                else
                {
                    var popupEvent = new GridViewPopupEventArgs(this);
                    if (this.SelectedIndexs.Count > 0)
                    {
                        this.SelectedIndexs.RemoveAt(this.SelectedIndexs.Count - 1);
                        this.DataBind();
                        popupEvent.IsClosed = false;
                    }
                    else
                    {
                        this.Close();
                    }
                    if (this.Selected != null)
                    {
                        popupEvent.SelectedIndexs = this.SelectedIndexs;
                        SetDisplayValue(popupEvent);
                        this.Selected(popupEvent);
                    }
                }
            }
        }

        readonly char[] numberChars = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        /// <summary>
        /// 处理键盘字符等信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterString.Length == 0)  //当没有输入字符匹配时
            {
                // 是否是数字选择
                bool numSelected = true;

                int keyIndex = 0;
                if (numberChars.Contains(e.KeyChar))
                {
                    keyIndex = int.Parse(e.KeyChar.ToString());
                    if (keyIndex == 0)
                    {
                        keyIndex = 10;
                    }
                }
                else
                {
                    numSelected = false;
                    if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) //字母或空格， 空格开启数字匹配模式
                    {
                        EnterString += e.KeyChar;
                        PageIndex = 1;
                        this.DataBind();
                        e.Handled = true;
                        return;
                    }
                }
                //分页时，数字键超出记录数
                if (keyIndex > PageSource.Rows.Count)
                {
                    e.Handled = true;
                    return;
                }
                if (this.Selected != null && numSelected)
                {
                    var popupEvent = SetPopupEvent(keyIndex);

                    if (!MultiSelect) //单选
                    {
                        SetDisplayValue(popupEvent);
                        this.Selected(popupEvent);
                        this.Close();
                    }
                    else //多选
                    {
                        popupEvent.IsClosed = false;
                        SetDisplayValue(popupEvent);
                        this.Selected(popupEvent);
                        EnterString = "";
                        PageIndex = 1;
                        this.DataBind();
                        e.Handled = true;
                    }

                }
            }
            else if (EnterString.Length > 0)
            {
                if (char.IsLetterOrDigit(e.KeyChar))
                {
                    EnterString += e.KeyChar;
                    PageIndex = 1;
                    this.DataBind();
                    e.Handled = true;
                }
            }
        }

        #endregion

        public void Close(Control ctrl = null)
        {
            if (ctrl == null)
                ctrl = this;
            if (ctrl is Form)
            {
                (ctrl as Form).Close();
            }
            else if (ctrl.Parent != null)
            {
                Close(ctrl.Parent);
            }
        }

        public static bool IsGenericList(Type instanceType)
        {
            if (!instanceType.IsGenericType)
            {
                return false;
            }
            if (typeof(IList).IsAssignableFrom(instanceType))
            {
                return true;
            }

            Type[] genericArgs = instanceType.GetGenericArguments();

            if (genericArgs.Length == 0)
            {
                return false;
            }
            Type listType = typeof(IList<>).MakeGenericType(genericArgs[0]);
            return listType.IsAssignableFrom(instanceType);
        }

        public event SelectedHandler Selected;

    }

    public delegate void SelectedHandler(GridViewPopupEventArgs e);

    public class GridViewPopupEventArgs : EventArgs
    {
        public GridViewPopupEventArgs(GridViewPopup popup)
        {
            Popup = popup;
            IsClosed = true;
            Display = "";
            Value = "";
        }
        public GridViewPopup Popup { get; set; }
        /// <summary>
        /// 是否关闭窗口了
        /// </summary>
        public bool IsClosed { get; set; }
        public int RowIndex { get; set; }
        public object RowSource { get; set; }
        public List<int> SelectedIndexs { get; set; }
        public string Display { get; set; }
        public string Value { get; set; }
    }


}
