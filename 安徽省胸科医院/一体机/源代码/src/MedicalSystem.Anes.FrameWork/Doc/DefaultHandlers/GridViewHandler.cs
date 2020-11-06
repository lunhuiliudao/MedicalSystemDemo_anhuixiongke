using System;
using System.Collections.Generic;
using System.Text; 
using System.Data; 
using System.Drawing;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Utilities;

namespace MedicalSystem.Anes.Document.Documents
{
   public class GridViewHandler:UIElementHandler<MedGridView>
    {

        /// 设置界面元素的属性和事件
        /// </summary>
        /// <param name="control"></param>
       public override void Handle()
       {
            base.Handle();
       }

       public virtual void AfterAutoCreateColumns()
       {
           
       }
       /// <summary>
       ///绑定数据源数据到控件
       /// </summary>
       /// <param name="control"></param>
       /// <param name="dataSources"></param>
       public override void BindDataToUI(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
       {
           if (dataSources.Count == 0) return;
           control.Rows.Clear();
         
           //自动生成列
           control.AutoCreateColumns();

           AfterAutoCreateColumns();
           for (int i = 0; i < control.Columns.Count; i++)
           {
               if (!string.IsNullOrEmpty(control.MedGridViewColumns[i].TableName))
               {
                   if (!dataSources.ContainsKey(control.MedGridViewColumns[i].TableName.ToUpper()))
                       throw new NotImplementedException(string.Format("在数据源中未找到名为{0}的表,请添加此绑定数据源!", control.MedGridViewColumns[i].TableName.ToUpper()));

                   DataTable dataTable = dataSources[control.MedGridViewColumns[i].TableName.ToUpper()];


                   if (dataTable.Rows.Count == 0)
                   {   
                        InitGridModelData(control, dataSources);
                        dataTable = dataSources[control.MedGridViewColumns[i].TableName.ToUpper()];
                   }


                   BeforeShowGridData(control, dataSources);


                   if (dataTable.Rows.Count > 0)
                   {
                       for (int j = 0; j < dataTable.Rows.Count; j++)
                       {
                           if (control.Rows.Count <= j)
                           {
                               int index = control.Rows.Add();
                               control.Rows[index].Tag = j;
                           }
                           DataGridViewRow gridRow = control.Rows[j];
                           DataRow dataRow = dataTable.Rows[j];

                           object value = control.MedGridViewColumns[i].TableName.ToUpper().Equals("MED_CUSTOM_DATA") ?
                               GetFieldValue(control.MedGridViewColumns[i].TableName, control.Columns[i].DataPropertyName) : dataRow[control.Columns[i].DataPropertyName];

                           if (value != System.DBNull.Value)
                           {
                               gridRow.Cells[i].Value = value;
                               gridRow.Cells[i].Tag = value;
                           }
                       }
                   }

                   
               }
           }
           if (control.Rows.Count > 0)
           {
               control.CurrentCell = control.Rows[0].Cells[0];
           }

             
       }

       protected virtual void InitGridModelData(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
       {
       }
       protected virtual void BeforeShowGridData(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
       {
       }
       /// <summary>
       /// 刷新数据
       /// </summary>
       public override void RefreshData()
       {
           foreach (MedGridView control in GetAllControls)
           {
               MedGridView gridView = (MedGridView)control;
               if (!gridView.IsCurrentCellInEditMode == true)
               {
                   BindDataToUI(control, DataSource);
               }
              
           }
       }
       /// <summary>
       /// 绑定控件内容到数据源
       /// </summary>
       /// <param name="control"></param>
       /// <param name="dataSources"></param>
       public override void BindUIToData(MedGridView control, Dictionary<string, System.Data.DataTable> dataSources)
       {
           if (dataSources.Count == 0) return;
           if (control.Tag != null && control.Tag.ToString().Equals("NoBindUIToData"))
           {
               return;
           }
          for (int i = 0; i < control.Columns.Count; i++)
           {
               if (!string.IsNullOrEmpty(control.MedGridViewColumns[i].TableName))
               {
                   DataTable dataTable = dataSources[control.MedGridViewColumns[i].TableName.ToUpper()];
                  
                   for (int j = 0; j < dataTable.Rows.Count; j++)
                   {
                       DataGridViewRow gridRow = control.Rows[j];
                      DataRow dataRow = dataTable.Rows[(int)gridRow.Tag];
                       //DataRow dataRow = dataTable.Rows[j];
                       object value = gridRow.Cells[i].Value;
                       if (value != null)
                           dataRow[control.Columns[i].DataPropertyName] = value;
                       else
                           dataRow[control.Columns[i].DataPropertyName] = DBNull.Value;
                   }
                   
               }
               
           }
           
       }
       //设置GridView的属性和事件
       public override void ControlSetting(MedGridView control)
       {

           control.CellClick += new DataGridViewCellEventHandler(gridView_CellClick);
           control.CellValueChanged += new DataGridViewCellEventHandler(gridView_CellValueChanged);
           control.CellPainting += new DataGridViewCellPaintingEventHandler(gridView_CellPainting);



           //初始化配置的字体
           control.ColumnHeadersDefaultCellStyle.Font = control.ColumnHeadersDefaultCellStyleFont;
           control.DefaultCellStyle.Font = control.DefaultCellStyleFont;
           
       }
       /// <summary>
       /// GridView单元格绘制事件
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       protected virtual void gridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
       {
           
           MedGridView grid = sender as MedGridView;
           if (e.Value != null && e.Value != System.DBNull.Value && e.ColumnIndex >= 0)
           {
               if (e.RowIndex >= 0)
               {
                   MedGridViewColumn girdViewColumn = grid.MedGridViewColumns[e.ColumnIndex];
                   if (!string.IsNullOrEmpty(girdViewColumn.DictTableName) && !string.IsNullOrEmpty(girdViewColumn.DictValueFieldName)
                       && !string.IsNullOrEmpty(girdViewColumn.DisplayFieldName) && !girdViewColumn.DictValueFieldName.Equals(girdViewColumn.DisplayFieldName))
                   {
                       Rectangle rect = e.CellBounds;
                       e.Handled = true;
                       e.PaintBackground(rect, true);
                       string text = TransDictCode(girdViewColumn.DictTableName, girdViewColumn.DictValueFieldName, girdViewColumn.DisplayFieldName, girdViewColumn.DictWhereString, e.Value);
                       Color color = e.CellStyle.ForeColor;
                       if (grid.SelectedCells != null && grid.SelectedCells.Count > 0 && grid.SelectedCells.Contains(grid.Rows[e.RowIndex].Cells[e.ColumnIndex]))
                       {
                           color = e.CellStyle.SelectionForeColor;
                       }
                       e.Graphics.DrawString(text, e.CellStyle.Font, new SolidBrush(color), rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                   }
                   else if (!string.IsNullOrEmpty(girdViewColumn.Format))
                   {
                       if (e.Value is DateTime && (IsDateTimeFomrat(girdViewColumn.Format) || IsFunctionFormat(girdViewColumn.Format)))
                       {
                           Rectangle rect = e.CellBounds;
                           e.Handled = true;
                           e.PaintBackground(rect, true);
                           string text = "";
                           if (e.Value != null )
                               text = FormatDateTime((DateTime)e.Value, girdViewColumn.Format);

                           Color color = e.CellStyle.ForeColor;
                           if (grid.SelectedCells != null && grid.SelectedCells.Count > 0 && grid.SelectedCells.Contains(grid.Rows[e.RowIndex].Cells[e.ColumnIndex]))
                           {
                               color = e.CellStyle.SelectionForeColor;
                           }
                           e.Graphics.DrawString(text, e.CellStyle.Font, new SolidBrush(color), rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                       }
                   }
               }
               else//列标题处理
               {
                   if (e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width > e.CellBounds.Width - 5)
                   {
                       //Modify by wenpei.x@2014-02-11
                       //清点单样式改为读取配置的列标题样式ColumnHeadersDefaultCellStyle
                       //旧处理
                       //Rectangle rect = e.CellBounds;
                       //e.Handled = true;
                       //e.PaintBackground(rect, true);
                       //string text = e.Value.ToString();
                       //e.Graphics.DrawString(text, e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", e.CellStyle.Font).Height) / 2);
                       DataGridViewCellStyle colStyle = grid.ColumnHeadersDefaultCellStyle;
                       Rectangle rect = e.CellBounds;
                       e.Handled = true;
                       e.PaintBackground(rect, true);
                       string text = e.Value.ToString();
                       e.Graphics.DrawString(text, colStyle.Font, new SolidBrush(colStyle.ForeColor), rect.X, rect.Y + (rect.Height - e.Graphics.MeasureString("A", colStyle.Font).Height) / 2);
                   }
               }
           }
       }
       /// <summary>
       /// GridView单元格值改变事件
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       void gridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
       {
                  
           if (e.ColumnIndex < 0 || e.RowIndex < 0)
           {
               return;
           }
           MedGridView grid = sender as MedGridView;
           DataGridViewCell cell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
           SetCellTag(cell);

           base.HasDirty = true;
       }
       /// <summary>
       /// GridView下拉框选择
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           if (e.ColumnIndex < 0 || e.RowIndex < 0)
           {
               return;
           }
           MedGridView grid = sender as MedGridView;
           DataGridViewCell cell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];

           if (cell.ReadOnly == true)
           {
               return;
           }


           if (grid.MedGridViewColumns.Count <= e.ColumnIndex) return;
           MedGridViewColumn gridViewColumn = grid.MedGridViewColumns[e.ColumnIndex];

           if (IsDateTimeFomrat(gridViewColumn.Format) && (cell.Value == null || cell.Value is DateTime))
           {
               DateTime dateTime;
               if (cell.Value == null)
               {
                   dateTime = DateTime.Now;
               }
               else
               {
                   dateTime = (DateTime)cell.Value;
               }
               Rectangle rect = grid.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
               string replaceString = "-";
               string formatString = TransDateFormat(gridViewColumn.Format, replaceString);
               Dialog.ShowDateTimeSelector(dateTime, grid, new Point(rect.Left + grid.Location.X, rect.Bottom + grid.Location.Y)
                   , new EventHandler(delegate(object sender1, EventArgs e1)
                   {
                       if (sender1 is DateTime)
                       {
                           cell.Value = (DateTime)sender1;
                           SetCellTag(cell);
                       }
                   }), formatString);
           }
           else if (!string.IsNullOrEmpty(gridViewColumn.DictTableName) && !string.IsNullOrEmpty(gridViewColumn.DictValueFieldName))
           {
               Rectangle rect = grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

               string displayName = !string.IsNullOrEmpty(gridViewColumn.DisplayFieldName) ? gridViewColumn.DisplayFieldName : gridViewColumn.DictValueFieldName;

               DataRow[] rows = BuildPopupItemsData(gridViewColumn.DictTableName, gridViewColumn.DictWhereString);
               Dialog.ShowCustomSelection(rows, displayName, grid, new Point(rect.Left, rect.Bottom), new Size(rect.Width, 300)
                   , new EventHandler(delegate(object s1, EventArgs e1)
                   {
                       if (s1 is int)
                       {
                           int index = (int)s1;
                           cell.Value = rows[index][gridViewColumn.DictValueFieldName];
                           SetCellTag(cell);

                       }
                   }));
           }
       }
       protected virtual void SetCellTag(DataGridViewCell cell)
       {
           if (cell.Value == null || cell.Value == System.DBNull.Value || cell.ColumnIndex < 0 || cell.RowIndex < 0 )
           {
               return;
           }
           string text = cell.Value.ToString();
           MedGridView grid = cell.DataGridView as MedGridView;
           MedGridViewColumn girdViewColumn = grid.MedGridViewColumns[cell.ColumnIndex];
           if (!string.IsNullOrEmpty(girdViewColumn.DictTableName) && !string.IsNullOrEmpty(girdViewColumn.DictValueFieldName)
               && !string.IsNullOrEmpty(girdViewColumn.DisplayFieldName) && !girdViewColumn.DictValueFieldName.Equals(girdViewColumn.DisplayFieldName))
           {
               text = TransDictCode(girdViewColumn.DictTableName, girdViewColumn.DictValueFieldName, girdViewColumn.DisplayFieldName, girdViewColumn.DictWhereString, cell.Value);
           }
           else if (!string.IsNullOrEmpty(girdViewColumn.Format))
           {
               if (cell.Value is DateTime && (IsDateTimeFomrat(girdViewColumn.Format) || IsFunctionFormat(girdViewColumn.Format)))
               {
                   text = FormatDateTime((DateTime)cell.Value, girdViewColumn.Format);
               }
           }
           cell.Tag = text;

       }
    }
}
