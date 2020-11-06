using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Design;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// DataGridView，新增文本框弹窗下拉菜单选择功能
    /// </summary>
    public class DataGridViewTextBoxGridViewPopupColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewTextBoxGridViewPopupColumn()
            : base()
        {
            this.CellTemplate = new DataGridViewTextBoxGridViewPopupCell();
            PopupDataSource = null;
            PopupMultiSelect = false;
            PopupGridViewMember = "";
            PopupDisplayMember = "";
            PopupValueMember = "";
            PopupWidth = 280;
            PopupPageSize = 10;
            PopupMultiChar = ",";
        }

        #region 弹出窗属性

        /// <summary>
        /// 是否多行选择
        /// </summary>
        [DefaultValue(false)]
        public bool PopupMultiSelect
        {
            get
            {
                return this.TextBoxPopupCellTemplate.PopupMultiSelect;
            }
            set
            {
                if (this.PopupMultiSelect != value)
                {
                    this.TextBoxPopupCellTemplate.PopupMultiSelect = value;
                    if (this.DataGridView != null)
                    {
                        DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                        int rowCount = dataGridViewRows.Count;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                            DataGridViewTextBoxGridViewPopupCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewTextBoxGridViewPopupCell;
                            if (dataGridViewCell != null)
                            {
                                dataGridViewCell.PopupMultiSelect = value;
                            }
                        }
                    }
                }
            }
        }
        [DefaultValue(",")]
        public string PopupMultiChar
        {
            get
            {
                return this.TextBoxPopupCellTemplate.PopupMultiChar;
            }
            set
            {
                if (this.PopupMultiChar != value)
                {
                    this.TextBoxPopupCellTemplate.PopupMultiChar = value;
                    if (this.DataGridView != null)
                    {
                        DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                        int rowCount = dataGridViewRows.Count;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                            DataGridViewTextBoxGridViewPopupCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewTextBoxGridViewPopupCell;
                            if (dataGridViewCell != null)
                            {
                                dataGridViewCell.PopupMultiChar = value;
                            }
                        }
                    }
                }
            }
        }
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue("")]
        public object PopupDataSource
        {
            get
            {
                return this.TextBoxPopupCellTemplate.PopupDataSource;
            }
            set
            {
                if (this.PopupDataSource != value)
                {
                    this.TextBoxPopupCellTemplate.PopupDataSource = value;
                    if (this.DataGridView != null)
                    {
                        DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                        int rowCount = dataGridViewRows.Count;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                            DataGridViewTextBoxGridViewPopupCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewTextBoxGridViewPopupCell;
                            if (dataGridViewCell != null)
                            {
                                dataGridViewCell.PopupDataSource = value;
                            }
                        }
                    }
                }
            }
        }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string PopupGridViewMember
        {
            get
            {
                return this.TextBoxPopupCellTemplate.PopupGridViewMember;
            }
            set
            {
                if (this.PopupGridViewMember != value)
                {
                    this.TextBoxPopupCellTemplate.PopupGridViewMember = value;
                    if (this.DataGridView != null)
                    {
                        DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                        int rowCount = dataGridViewRows.Count;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                            DataGridViewTextBoxGridViewPopupCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewTextBoxGridViewPopupCell;
                            if (dataGridViewCell != null)
                            {
                                dataGridViewCell.PopupGridViewMember = value;
                            }
                        }
                    }
                }
            }
        }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string PopupDisplayMember
        {
            get
            {
                return this.TextBoxPopupCellTemplate.PopupDisplayMember;
            }
            set
            {
                if (this.PopupDisplayMember != value)
                {
                    this.TextBoxPopupCellTemplate.PopupDisplayMember = value;
                    if (this.DataGridView != null)
                    {
                        DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                        int rowCount = dataGridViewRows.Count;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                            DataGridViewTextBoxGridViewPopupCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewTextBoxGridViewPopupCell;
                            if (dataGridViewCell != null)
                            {
                                dataGridViewCell.PopupDisplayMember = value;
                            }
                        }
                    }
                }
            }
        }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string PopupValueMember
        {
            get
            {
                return this.TextBoxPopupCellTemplate.PopupValueMember;
            }
            set
            {
                if (this.PopupValueMember != value)
                {
                    this.TextBoxPopupCellTemplate.PopupValueMember = value;
                    if (this.DataGridView != null)
                    {
                        DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                        int rowCount = dataGridViewRows.Count;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                            DataGridViewTextBoxGridViewPopupCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewTextBoxGridViewPopupCell;
                            if (dataGridViewCell != null)
                            {
                                dataGridViewCell.PopupValueMember = value;
                            }
                        }
                    }
                }
            }
        }
        [DefaultValue(280)]
        public int PopupWidth
        {
            get
            {
                return this.TextBoxPopupCellTemplate.PopupWidth;
            }
            set
            {
                if (this.PopupWidth != value)
                {
                    this.TextBoxPopupCellTemplate.PopupWidth = value;
                    if (this.DataGridView != null)
                    {
                        DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                        int rowCount = dataGridViewRows.Count;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                            DataGridViewTextBoxGridViewPopupCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewTextBoxGridViewPopupCell;
                            if (dataGridViewCell != null)
                            {
                                dataGridViewCell.PopupWidth = value;
                            }
                        }
                    }
                }
            }
        }
        [DefaultValue(10)]
        public int PopupPageSize
        {
            get
            {
                return this.TextBoxPopupCellTemplate.PopupPageSize;
            }
            set
            {
                if (this.PopupPageSize != value)
                {
                    this.TextBoxPopupCellTemplate.PopupPageSize = value;
                    if (this.DataGridView != null)
                    {
                        DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                        int rowCount = dataGridViewRows.Count;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                            DataGridViewTextBoxGridViewPopupCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewTextBoxGridViewPopupCell;
                            if (dataGridViewCell != null)
                            {
                                dataGridViewCell.PopupPageSize = value;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        private DataGridViewTextBoxGridViewPopupCell TextBoxPopupCellTemplate
        {
            get
            {
                return (DataGridViewTextBoxGridViewPopupCell)this.CellTemplate;
            }
        }

        #region override

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                DataGridViewTextBoxGridViewPopupCell cell = value as DataGridViewTextBoxGridViewPopupCell;
                if (value != null && cell == null)
                {
                    throw new NotSupportedException(cell == null ? "" : cell.GetType().Name);
                }
                base.CellTemplate = value;
            }
        }

        public override object Clone()
        {
            DataGridViewTextBoxGridViewPopupColumn col = (DataGridViewTextBoxGridViewPopupColumn)base.Clone();
            col.PopupMultiSelect = this.PopupMultiSelect;
            col.PopupMultiChar = this.PopupMultiChar;
            col.PopupDataSource = this.PopupDataSource;
            col.PopupGridViewMember = this.PopupGridViewMember;
            col.PopupDisplayMember = this.PopupDisplayMember;
            col.PopupValueMember = this.PopupValueMember;
            col.PopupWidth = this.PopupWidth;
            col.PopupPageSize = this.PopupPageSize;
            return col;
        }

        #endregion

    }

    public class DataGridViewTextBoxGridViewPopupCell : DataGridViewTextBoxCell
    {
        private DataGridViewTextBoxEditingControl txtPopup = null;
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            txtPopup = this.DataGridView.EditingControl as DataGridViewTextBoxEditingControl;

        }

        private GridViewPopup Popup
        {
            get
            {
                GridViewPopup popup = new GridViewPopup()
                {
                    MultiSelect = this.PopupMultiSelect,
                    MultiChar = this.PopupMultiChar,
                    DataSource = this.PopupDataSource,
                    GridViewMember = this.PopupGridViewMember,
                    DisplayMember = this.PopupDisplayMember,
                    ValueMember = this.PopupValueMember,
                    PageSize = this.PopupPageSize
                };
                popup.SelectedValue = Convert.ToString(this.Value);
                return popup;
            }
        }

        public bool PopupMultiSelect { get; set; }
        public string PopupMultiChar { get; set; }
        public object PopupDataSource { get; set; }
        public string PopupGridViewMember { get; set; }
        public string PopupDisplayMember { get; set; }
        public string PopupValueMember { get; set; }
        public int PopupWidth { get; set; }
        public int PopupPageSize { get; set; }

        #region override

        public override object Clone()
        {
            DataGridViewTextBoxGridViewPopupCell col = (DataGridViewTextBoxGridViewPopupCell)base.Clone();
            col.PopupMultiSelect = this.PopupMultiSelect;
            col.PopupMultiChar = this.PopupMultiChar;
            col.PopupDataSource = this.PopupDataSource;
            col.PopupGridViewMember = this.PopupGridViewMember;
            col.PopupDisplayMember = this.PopupDisplayMember;
            col.PopupValueMember = this.PopupValueMember;
            col.PopupWidth = this.PopupWidth;
            col.PopupPageSize = this.PopupPageSize;
            return col;
        }

        //protected override void OnEnter(int rowIndex, bool throughMouseClick)
        //{
        //    base.OnEnter(rowIndex, throughMouseClick);
        //    if (this.Selected && string.IsNullOrEmpty(Convert.ToString(this.Value)))
        //    {
        //        if (this.DataGridView.BeginEdit(true))
        //        {
        //            var popup = Popup;
        //            popup.Selected += PopupControl_Selected;
        //            PopupForm.Show(txtPopup, popup, this.PopupWidth, popup.Height);
        //        }
        //    }
        //}
        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            var popup = Popup;
            popup.DataBind();
            popup.Selected += PopupControl_Selected;
            int cellX = DataGridView.GetCellDisplayRectangle(ColumnIndex, RowIndex, false).X;

            int cellY = DataGridView.GetCellDisplayRectangle(ColumnIndex, RowIndex, false).Y;

            Point pi = new Point(cellX, cellY + this.DataGridView.CurrentCell.OwningRow.Height);
            pi = DataGridView.PointToScreen(pi);
            if (pi.X + this.PopupWidth > Screen.PrimaryScreen.WorkingArea.Width)
            {
                pi.X = Screen.PrimaryScreen.WorkingArea.Width - this.PopupWidth;
            }

            if (pi.Y + popup.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                pi.Y = pi.Y - this.DataGridView.CurrentCell.OwningRow.Height - popup.Height;
            }

            PopupForm.Show(pi, popup, this.PopupWidth, popup.Height);
        }
        protected override void OnKeyDown(KeyEventArgs e, int rowIndex)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                //if (this.DataGridView.BeginEdit(true))
                //{
                var popup = Popup;
                popup.DataBind();
                popup.Selected += PopupControl_Selected;
                //PopupForm.Show(txtPopup, popup, this.PopupWidth, popup.Height);
                int cellX = DataGridView.GetCellDisplayRectangle(ColumnIndex, RowIndex, false).X;

                int cellY = DataGridView.GetCellDisplayRectangle(ColumnIndex, RowIndex, false).Y;

                Point pi = new Point(cellX, cellY + this.DataGridView.CurrentCell.OwningRow.Height);
                pi = DataGridView.PointToScreen(pi);
                if (pi.X + this.PopupWidth > Screen.PrimaryScreen.WorkingArea.Width)
                {
                    pi.X = Screen.PrimaryScreen.WorkingArea.Width - this.PopupWidth;
                }

                if (pi.Y + popup.Height > Screen.PrimaryScreen.WorkingArea.Height)
                {
                    pi.Y = pi.Y - this.DataGridView.CurrentCell.OwningRow.Height - popup.Height;
                }

                PopupForm.Show(pi, popup, this.PopupWidth, popup.Height);
                //}
            }
            else if (e.KeyCode == Keys.Back) //删除键
            {
                this.Value = "";
            }
            else
            {
                base.OnKeyDown(e, rowIndex);
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (this.PopupDataSource != null && PopupDisplayMember != PopupValueMember)
            {
                var popup = Popup;
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, popup.GetDisplayByValue(Convert.ToString(formattedValue)), errorText, cellStyle, advancedBorderStyle, paintParts);
            }
            else
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
        }

        #endregion

        #region Popup Selected Event
        void PopupControl_Selected(GridViewPopupEventArgs e)
        {
            if (e == null)
            {
                this.DataGridView.EndEdit();
                if (this.ColumnIndex < this.DataGridView.CurrentRow.Cells.Count - 1)
                {
                    var nextCell = this.DataGridView.CurrentRow.Cells[this.ColumnIndex + 1];
                    nextCell.Selected = true;
                    this.DataGridView.CurrentCell = nextCell;
                }
                return;
            }

            //txtPopup.EditingControlFormattedValue = display;
            this.Value = e.Value;

            if (e.IsClosed)
            {
                this.DataGridView.EndEdit();
                if (this.OwningColumn.DisplayIndex < this.DataGridView.CurrentRow.Cells.Count - 1)
                {

                    var nextCell = this.DataGridView.CurrentRow
                        .Cells.Cast<DataGridViewCell>()
                        .Where(x => x.Displayed && x.OwningColumn.DisplayIndex > this.OwningColumn.DisplayIndex)
                        .OrderBy(x => x.OwningColumn.DisplayIndex)
                        .FirstOrDefault();
                    if (nextCell != null)
                    {
                        nextCell.Selected = true;
                        this.DataGridView.CurrentCell = nextCell;
                    }
                }
            }
        }

        #endregion

    }

}
