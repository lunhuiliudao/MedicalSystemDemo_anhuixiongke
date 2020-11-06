using MedicalSystem.Anes.FrameWork.Properties;
using MedicalSystem.Anes.Document.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.FrameWork
{
    public partial class DialogBaseDocForm : Form
    {
        public DialogBaseDocForm()
        {
            InitializeComponent();
            this.panlHeader.SendToBack();
        }
        public DialogBaseDocForm(string caption, int width, int height)
            : this()
        {
            this.Text = caption;
            this.Width = width + this.Padding.Left + this.Padding.Right;
            this.Height = height + TitleHeight + this.Padding.Top + this.Padding.Bottom;
            this.AutoScroll = false;
            StartPosition = FormStartPosition.CenterParent;
        }
        public DialogBaseDocForm(string caption, bool isMaximized)
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

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.lblTitle.Text = value;
            }
        }

        public int TitleHeight
        {
            get { return this.panlHeader.Height; }
        }
        private bool CheckSave()
        {
            if (this.Controls.Count == 1)
            {
                Control control = this.Controls[0];
                //if (control is BaseDoc)
                //{
                //    BaseDoc doc = control as BaseDoc;
                //    if (doc != null && doc.HasDirty())
                //    {
                //        //DialogResult dialogResult = XtraMessageBox.Show("您当前的界面有未保存的数据,是否保存此数据?",
                //        //           "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        //if (dialogResult == DialogResult.Yes)
                //        //{
                //        //    if (!doc.ValidateData())
                //        //        return false;
                //        //    else
                //        //    {
                //        //        if (!doc.OnCustomCheckBeforeSave())
                //        //            return false;
                //        //        doc.Save();
                //        //    }

                //        //}
                //    }
                //}
            }
            return true;
        }
        #region 设置标题栏图标

        private HeaderIconEnum _headerIcon = HeaderIconEnum.Info;
        /// <summary>
        /// 设置标题栏图标
        /// </summary>
        public HeaderIconEnum HeaderIcon
        {
            get { return _headerIcon; }
            set
            {
                _headerIcon = value;
                switch (_headerIcon)
                {
                    case HeaderIconEnum.Info:
                        this.picIcon.Image = Resources.icon_提示信息;
                        break;
                    case HeaderIconEnum.Error:
                        this.picIcon.Image = Resources.icon_error;
                        break;
                    case HeaderIconEnum.Question:
                        this.picIcon.Image = Resources.icon_疑问;
                        break;
                    case HeaderIconEnum.Warn:
                        this.picIcon.Image = Resources.icon_warning;
                        break;

                    case HeaderIconEnum.Search:
                        this.picIcon.Image = Resources.icon_搜索;
                        break;
                    case HeaderIconEnum.Location:
                        this.picIcon.Image = Resources.icon_定位;
                        break;
                    case HeaderIconEnum.Coordination:
                        this.picIcon.Image = Resources.icon_对话;
                        break;

                    case HeaderIconEnum.Print:
                        this.picIcon.Image = Resources.icon_打印;
                        break;
                    case HeaderIconEnum.Event:
                        this.picIcon.Image = Resources.icon_麻醉事件;
                        break;
                    case HeaderIconEnum.Time:
                        this.picIcon.Image = Resources.icon_时间确认;
                        break;
                    case HeaderIconEnum.Vistal:
                        this.picIcon.Image = Resources.icon_体征数据;
                        break;
                    case HeaderIconEnum.System:
                        this.picIcon.Image = Resources.icon_系统设置;
                        break;
                    case HeaderIconEnum.Dic:
                        this.picIcon.Image = Resources.icon_字典;
                        break;
                    case HeaderIconEnum.Safety:
                        this.picIcon.Image = Resources.icon_安全核查;
                        break;
                    case HeaderIconEnum.PatientList:
                        this.picIcon.Image = Resources.icon_换台;
                        break;

                    case HeaderIconEnum.PACU:
                        this.picIcon.Image = Resources.icon_PACU进程;
                        break;
                    case HeaderIconEnum.EmergencyRegister:
                        this.picIcon.Image = Resources.icon_急诊登记;
                        break;
                    case HeaderIconEnum.LAB:
                        this.picIcon.Image = Resources.icon_检验;
                        break;
                    case HeaderIconEnum.OperInfo:
                        this.picIcon.Image = Resources.icon_手术信息;
                        break;
                    case HeaderIconEnum.PreoperativeInterview:
                        this.picIcon.Image = Resources.icon_术前访视;
                        break;
                    case HeaderIconEnum.EMR:
                        this.picIcon.Image = Resources.icon_信息集成;
                        break;
                    case HeaderIconEnum.Order:
                        this.picIcon.Image = Resources.icon_医嘱;
                        break;
                    case HeaderIconEnum.Monitor:
                        this.picIcon.Image = Resources.icon_仪器确认;
                        break;
                    case HeaderIconEnum.QC:
                        this.picIcon.Image = Resources.icon_质控管理;
                        break;
                }
            }
        }
        #endregion
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DialogBaseDocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckSave())
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
