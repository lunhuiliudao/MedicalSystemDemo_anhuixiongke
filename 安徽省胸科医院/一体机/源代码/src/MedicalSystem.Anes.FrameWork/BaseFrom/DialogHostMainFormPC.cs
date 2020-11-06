using MedicalSystem.Anes.FrameWork;
using MedicalSystem.Anes.FrameWork.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork
{
    public partial class DialogHostMainFormPC : BaseFormWithTitlePC
    {
        public DialogHostMainFormPC()
        {
            InitializeComponent();
        }
        public DialogHostMainFormPC(string caption, int width, int height)
            : this()
        {
            this.Text = caption;
            this.Width = width + this.Padding.Left + this.Padding.Right;
            this.Height = height + TitleHeight + this.Padding.Top + this.Padding.Bottom;
            this.AutoScroll = true;
            StartPosition = FormStartPosition.CenterParent;
        }
        public DialogHostMainFormPC(string caption, bool isMaximized)
            : this()
        {
            this.Text = caption;
            if (isMaximized)
            {
                this.MaximizeBox = true;
                this.MinimizeBox = true;
                this.ControlBox = true;

                this.WindowState = FormWindowState.Maximized;

            }

        }

        public Control Child
        {
            set
            {
                if (value != null)
                {
                    value.Dock = DockStyle.Fill;
                    this.Controls.Add(value);
                    value.BringToFront();
                }

            }
        }
        private bool CheckSave()
        {
            //if (this.Controls.Count == 1)
            //{
            //    Control control = this.Controls[0];
            //    if (control is BaseView)
            //    {
            //        BaseView baseControl = control as BaseView;
            //        if (baseControl.IsDirty)
            //        {
            //            DialogResult result = Dialog.MessageBox("输入未保存，现在保存吗?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //            Application.DoEvents();
            //            if (result == DialogResult.No)
            //            {
            //                return true;
            //            }
            //            else if (result == DialogResult.Cancel)
            //            {
            //                return false;
            //            }
            //            else
            //            {
            //                return baseControl.Save();
            //            }
            //        }
            //    }

            //    if (control is BaseDoc)
            //    {
            //        BaseDoc doc = control as BaseDoc;
            //        if (doc != null && doc.HasDirty())
            //        {
            //            DialogResult dialogResult = XtraMessageBox.Show("您当前的界面有未保存的数据,是否保存此数据?",
            //                       "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //            if (dialogResult == DialogResult.Yes)
            //            {
            //                if (!doc.ValidateData())
            //                    return false;
            //                else
            //                {
            //                    if (!doc.OnCustomCheckBeforeSave())
            //                        return false;
            //                    doc.Save();
            //                }

            //            }
            //        }
            //    }
            //}
            return true;
        }
        private void DialogHostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckSave())
            {
                e.Cancel = true;
                return;
            }
        }
        public override bool RegisterControlByHotKey(string keyCode)
        {
            if (keyCode == KeyCode.AppCode.HOME)
            {
                this.Close();
            }
            return base.RegisterControlByHotKey(keyCode);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pciMax_Click(object sender, EventArgs e)
        {
            UserLock();
        }


        public virtual void UserLock()
        { }

        private void picMin_MouseEnter(object sender, EventArgs e)
        {
            picMin.Image = Resources.最小化2;
        }

        private void picMin_MouseLeave(object sender, EventArgs e)
        {
            picMin.Image = Resources.最小化1;
        }
        private void picMin_MouseDown(object sender, MouseEventArgs e)
        {
            picMin.Image = Resources.最小化3;
        }

        private void picMin_MouseUp(object sender, MouseEventArgs e)
        {
            picMin.Image = Resources.最小化1;
        }

        private void pciMax_MouseEnter(object sender, EventArgs e)
        {
            pciMax.Image = Resources.窗口2;
        }

        private void pciMax_MouseLeave(object sender, EventArgs e)
        {
            pciMax.Image = Resources.窗口1;
        }

        private void pciMax_MouseUp(object sender, MouseEventArgs e)
        {
            pciMax.Image = Resources.窗口1;
        }

        private void pciMax_MouseDown(object sender, MouseEventArgs e)
        {
            pciMax.Image = Resources.窗口3;
        }

        private void picClose_MouseDown(object sender, MouseEventArgs e)
        {
            picClose.Image = Resources.x3;
        }

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Resources.x2;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Resources.x1;
        }

        private void picClose_MouseUp(object sender, MouseEventArgs e)
        {
            picClose.Image = Resources.x1;
        }

        private bool down = false;//标记是否按下鼠标左键
        private int starX, starY;//起始坐标
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((Control)sender).Cursor = Cursors.Hand;
                down = true;
                starX = e.X;
                starY = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.SizeAll;
            down = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (down)
            {
                this.Location = new Point(this.Location.X + e.X - starX, this.Location.Y + e.Y - starY);
            }
        }
    }
}