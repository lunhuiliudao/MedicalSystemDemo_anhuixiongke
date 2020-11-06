/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：ContextMenuForm.cs
      // 文件功能描述：菜单式窗体（弹出窗体）
      //
      // 
      // 创建标识：戴呈祥-2008-10-24
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MedicalSystem.Anes.Document.Constants
{
    /// <summary>
    /// 菜单式窗体（弹出窗体）
    /// </summary>
    public partial class ContextMenuForm : XtraForm
    {

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public ContextMenuForm()
        {
            InitializeComponent();
            Deactivate += new EventHandler(ContextMenuForm_Deactivate);
        }

        private void ContextMenuForm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 锁标记
        /// </summary>
        private bool _locked = false;

        /// <summary>
        /// 父控件
        /// </summary>
        private Control _parentControl = null;

        #endregion 变量

        #region 属性

        /// <summary>
        /// 锁标记
        /// </summary>
        public bool Locked
        {
            get { return _locked; }
            set 
            {
                _locked = value; 
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="parent">父控件</param>
        /// <param name="location">位置</param>
        /// <param name="size">大小</param>
        /// <param name="control">窗体上要放置的控件</param>
        public void Show(Control parent, Point location, Size size, Control control)
        {
            _parentControl = parent;
            this.Location = parent.PointToScreen(location);
            this.Size = size;
            SetContainingControl(control);
            this.Show();
            this.Focus();
        }

        /// <summary>
        /// 放置控件
        /// </summary>
        /// <param name="control">要放置的控件</param>
        private void SetContainingControl(Control control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        /// <summary>
        /// 隐藏窗体
        /// </summary>
        new public void Hide()
        {
            base.Hide();
        }

        #endregion 方法


        #region 事件

        private void ContextMenuPanel_Deactivate(object sender, EventArgs e)
        {
            if (!Locked)
            {
                //Hide();
            }
        }

        private void ContextMenuPanel_Leave(object sender, EventArgs e)
        {
            if (!Locked)
            {
                //Hide();
            }
        }

        #endregion 事件

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = e.ClipRectangle;
            rect.Inflate(-1,-1);
            ControlPaint.DrawBorder3D(e.Graphics, rect,Border3DStyle.Etched);
        }

    }
}