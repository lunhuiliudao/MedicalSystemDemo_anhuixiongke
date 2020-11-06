using MedicalSystem.Anes.Client.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public partial class DialogHostForm : BaseFormWithTitle
    {
        public DialogHostForm()
        {
            InitializeComponent();
        }
        public DialogHostForm(string caption, int width, int height)
            : this()
        {
            this.Text = caption;
            this.Width = width + this.Padding.Left + this.Padding.Right;
            this.Height = height + TitleHeight + this.Padding.Top + this.Padding.Bottom;
            this.AutoScroll = true; 
            StartPosition = FormStartPosition.CenterParent;
        }
        public DialogHostForm(string caption, bool isMaximized)
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
    }
}