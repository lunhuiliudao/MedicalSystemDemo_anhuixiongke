using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Views
{
    /// <summary>
    /// 普通界面的基类
    /// </summary>
    [ToolboxItem(false)]
    public partial class BaseView : XtraUserControl
    {
        private bool _hasDirty = false;
        protected string _caption = string.Empty;

        public BaseView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Caption
        {
            get
            {
                return
                    _caption;
            }
            set
            {
                _caption = value;
            }
        }

        public virtual bool IsDirty
        {
            get
            {
                return
                    _hasDirty;
            }
            set
            {
                _hasDirty = value;
            }
        }
        /// <summary>
        /// 刷新界面数据
        /// </summary>
        public virtual void RefreshData()
        {

        }

        public virtual bool Save()
        {
            return true;
        }
        #region 设置默认的DataGridView的样式

        /// <summary>
        /// 设置默认的DataGridView的样式
        /// </summary>
        /// <param name="dgv"></param>
        public virtual void SetDefaultGridViewStyle(DataGridView dgv, int RowHeight = 30, int ColumnHeight = 30)
        {
            if (dgv == null)
                return;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            if (dgv.RowsDefaultCellStyle == null)
                dgv.RowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(216, 247, 252);//选中颜色

            if (dgv.DefaultCellStyle == null)
                dgv.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(92, 92, 92);//字体颜色

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(216, 247, 252);//选中颜色
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(77, 139, 211);//选中字体颜色

            if (dgv.ColumnHeadersDefaultCellStyle == null)
                dgv.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();


            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.GridColor = Color.FromArgb(193, 207, 217);//边框颜色

            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.RowTemplate.Height = RowHeight;
            dgv.ColumnHeadersHeight = ColumnHeight;
            dgv.CellPainting += dgv_CellPainting;
            dgv.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            dgv.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
            dgv.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Single;
            dgv.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;

        }

        public virtual void SetDefaultControlStyle(XtraUserControl userControl)
        {
            userControl.Paint += userControl_Paint;
        }

        void userControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(80, 170, 250), 2.0f);
            foreach (Control ctr in this.Controls)
            {
                if (ctr is MedLabel)
                {
                    ctr.ForeColor = Color.FromArgb(80, 170, 250);
                }
                else if (ctr is RadioGroup)
                {

                }
                else
                {
                    if (ctr.Focused)
                        g.DrawRectangle(pen, new Rectangle(ctr.Left - 1, ctr.Top - 1, ctr.Width + 2, ctr.Height + 2));
                    else
                        g.DrawRectangle(pen, new Rectangle(ctr.Location, ctr.Size));

                    if (string.IsNullOrEmpty(ctr.Text))
                    {
                        ctr.BackColor = Color.FromArgb(238, 241, 246);
                    }
                    else
                    {
                        ctr.BackColor = Color.White;
                        ctr.ForeColor = Color.FromArgb(92, 92, 92);
                    }
                }
            }
            pen.Dispose();
        }



        void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //绘制渐变列头
                bool mouseOver = e.CellBounds.Contains(((DataGridView)sender).PointToClient(Cursor.Position));
                LinearGradientBrush brush = new LinearGradientBrush(
                    e.CellBounds,
                    mouseOver ? Color.FromArgb(101, 182, 252) : Color.FromArgb(133, 200, 251),
                   Color.FromArgb(162, 217, 251),
                    LinearGradientMode.Vertical);

                using (brush)
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                    Rectangle border = e.CellBounds;
                    //border.Width += 2;
                    //border.Height -= 2;
                    e.Graphics.DrawRectangle(Pens.Transparent, border);
                }
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }

        #endregion


        #region 解决界面闪烁情况

        /// <summary>
        /// 解决界面闪烁情况
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        if (!DesignMode)
        //        {
        //            var parms = base.CreateParams;
        //            parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
        //            return parms;
        //        }
        //        return base.CreateParams;
        //    }
        //}

        #endregion
    }
}
