using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// 基类用户控件，热键设置等。
    /// </summary> 
    public partial class BaseControl : UserControl, IBaseView
    {
        public BaseControl()
        {
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        public virtual bool IsDirty { get; set; }

        /// <summary>
        /// 通过热键注册控件
        /// </summary>
        public virtual bool RegisterControlByHotKey(string keyCode)
        {
            return false;
        }

        public virtual bool RegisterControlByHotKey(Keys keyCode)
        {
            return false;
        }


        public virtual void RegisterControlByImeMode(ImeMode imeMode)
        {
        }

        /// <summary>
        /// 返回输入法内容
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public virtual void GetInputMethodResult(string result)
        {
        }

        #region 解决界面闪烁情况

        /// <summary>
        /// 解决界面闪烁情况
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        //if (!DesignMode)
        //        {
        //            var parms = base.CreateParams;
        //            parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
        //            return parms;
        //        }
        //        return base.CreateParams;
        //    }
        //}

        #endregion

        #region 释放重载方法

        /// <summary>
        /// 释放重载方法
        /// </summary>
        protected virtual void OnDispose()
        {

        }

        protected override void Dispose(bool disposing)
        {
            OnDispose();
            base.Dispose(disposing);
        }

        #endregion

        #region 设置默认的DataGridView的样式

        /// <summary>
        /// 设置默认的DataGridView的样式
        /// </summary>
        /// <param name="dgv"></param>
        public virtual void SetDefaultGridViewStyle(DataGridView dgv, int RowHeight = 40, int ColumnHeight = 50)
        {
            if (dgv == null)
                return;

            if (dgv.RowsDefaultCellStyle == null)
            {
                dgv.RowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            }
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));

            if (dgv.DefaultCellStyle == null)
            {
                dgv.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            }
            dgv.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10F);
            dgv.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;//System.Drawing.SystemColors.HighlightText;

            if (dgv.AlternatingRowsDefaultCellStyle == null)
            {
                dgv.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            }
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));

            if (dgv.ColumnHeadersDefaultCellStyle == null)
            {
                dgv.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            }
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 10F);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.RowTemplate.Height = RowHeight;
            dgv.ColumnHeadersHeight = ColumnHeight;
        }

        #endregion








        
    }
}
