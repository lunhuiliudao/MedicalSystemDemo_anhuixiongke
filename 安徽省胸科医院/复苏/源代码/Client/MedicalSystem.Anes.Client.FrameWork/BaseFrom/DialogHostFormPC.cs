using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.FrameWork.Properties;
using MedicalSystem.Anes.Document.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public partial class DialogHostFormPC : BaseFormWithTitlePC
    {
        public DialogHostFormPC()
        {
            InitializeComponent();

            ControlAddEvent cotrol = new ControlAddEvent(Resources.x2_1, Resources.x2_2, Resources.x2_3);
            cotrol.AddMouseMove(picClose);
        }
        public DialogHostFormPC(string caption, int width, int height)
            : this()
        {
            this.Text = caption;
            this.Width = width + this.Padding.Left + this.Padding.Right;
            this.Height = height + TitleHeight + this.Padding.Top + this.Padding.Bottom;
            this.AutoScroll = true;
            StartPosition = FormStartPosition.CenterParent;

            ControlAddEvent cotrol = new ControlAddEvent(Resources.x2_1, Resources.x2_2, Resources.x2_3);
            cotrol.AddMouseMove(picClose);

        }
        public DialogHostFormPC(string caption, bool isMaximized)
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
                    panelMain.Controls.Add(value);
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

        private void DialogHostFormPC_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(Pens.DarkOliveGreen, 0, 0, this.Width - 1, this.Height - 1);
            //Pen pen = new Pen(Color.FromArgb(199, 233, 250));
            //e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(129, 186, 230), ButtonBorderStyle.Solid);
            //Pen pen = new Pen(Color.FromArgb(129, 186, 230));
            //e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(129, 186, 230));
            e.Graphics.DrawRectangle(pen, new Rectangle(8, 0, panelMain.Width - 16, panelMain.Height - 8));
            //Color border = System.Drawing.Color.FromArgb(199, 233, 250);
            //ControlPaint.DrawBorder(e.Graphics, panelMain.ClientRectangle,
            //border, 1, ButtonBorderStyle.Solid, //左边
            //border, 1, ButtonBorderStyle.Solid, //上边
            //border, 1, ButtonBorderStyle.Solid, //右边
            //border, 1, ButtonBorderStyle.Solid);//底边
        }
    }
}