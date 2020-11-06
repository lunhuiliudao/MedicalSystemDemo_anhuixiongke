/*----------------------------------------------------------------
      // Copyright (C) 2010 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：GridViewHelper.cs
      // 文件功能描述：
      //
      // 
      // 修改标识：戴呈祥-2010-12-16
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace MedicalSystem.Anes.Document.Utilities
{
    public class GridViewHelper
    {
        public static void DataGridViewCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            DataGridViewCellPainting(e, e.CellStyle.ForeColor); 
        }

        /// <summary>
        /// 画表头列头-换肤通知无，只能重启
        /// </summary>
        /// <param name="e"></param>
        /// <param name="textColor"></param>
        public static void DataGridViewCellPainting(DataGridViewCellPaintingEventArgs e, Color textColor)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            { 
            }
        }

        public static void ApplyGridViewStyle(DataGridView grid)
        {
            grid.GridColor = Color.FromArgb(218, 234, 253);
            grid.BorderStyle = BorderStyle.Fixed3D;
            grid.BackgroundColor = Color.White;
            grid.CellPainting += new DataGridViewCellPaintingEventHandler(grid_CellPainting);
        }

        static void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridViewCellPainting(e);
        }
    }
}
