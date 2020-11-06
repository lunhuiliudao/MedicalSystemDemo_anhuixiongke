using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// 判断是否是一个窗口
    /// </summary>
    public class PopupForm : BaseForm
    {
        public PopupForm()
        {
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            ShowIcon = false;
            TopMost = true;
        }

        #region 弹出窗的特性设置

        /// <summary>
        /// 设计短的时间间隔
        /// </summary>
        protected override int dwTime { get { return 150; } }

        /// <summary>
        /// 失去焦点时，自动关闭窗口
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Close();
        }

        #endregion

        /// <summary>
        /// 弹出窗口
        /// </summary>
        /// <param name="popupCtrl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void Show(Control parent, Control popupCtrl, int width, int height)
        {
            Point location = parent.PointToScreen(new Point(0, parent.Height));

            if (location.X + width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                location.X = Screen.PrimaryScreen.WorkingArea.Width - width;
            }

            if (location.Y + height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                location.Y = location.Y - parent.Height - height;
            }

            Show(location, popupCtrl, width, height);
        }

        public static void Show(Point location, Control popupCtrl, int width, int height)
        {
            PopupForm popupFrm = new PopupForm();
            popupFrm.Location = location;

            popupFrm.Controls.Clear();
            popupFrm.Controls.Add(popupCtrl);
            popupCtrl.Dock = DockStyle.Fill;

            popupFrm.Width = width;
            popupFrm.Height = height + GetTop(popupCtrl) + GetBottom(popupCtrl);

            popupFrm.Show();
        }

        private static int GetTop(Control ctrl)
        {
            if (ctrl.Parent == null)
            {
                return 0;
            }
            else
            {
                return ctrl.Location.Y + GetTop(ctrl.Parent);
            }

        }

        private static int GetBottom(Control ctrl)
        {
            if (ctrl.Parent == null)
            {
                return 0;
            }
            else
            {
                return ctrl.Parent.Width - ctrl.Location.Y - ctrl.Width
                    + GetBottom(ctrl.Parent);
            }

        }

        public override bool RegisterControlByHotKey(string keyCode)
        {
            return base.RegisterControlByHotKey(keyCode);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PopupForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "PopupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

    }

}
