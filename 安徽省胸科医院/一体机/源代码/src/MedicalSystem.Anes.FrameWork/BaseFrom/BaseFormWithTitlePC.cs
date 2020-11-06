using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.Anes.FrameWork.Properties;
using System.Runtime.InteropServices;

namespace MedicalSystem.Anes.FrameWork
{

    [ComVisible(true)]
    public partial class BaseFormWithTitlePC : BaseForm
    {
        public BaseFormWithTitlePC()
        {
            InitializeComponent();
            this.panlHeader.SendToBack();
        }

        //public override bool RegisterHotKey
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

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

        #region 设置标题栏图标

        private HeaderIconEnumPC _headerIcon = HeaderIconEnumPC.Info;
        /// <summary>
        /// 设置标题栏图标
        /// </summary>
        public HeaderIconEnumPC HeaderIcon
        {
            get { return _headerIcon; }
            set
            {
                _headerIcon = value;
                switch (_headerIcon)
                {
                    case HeaderIconEnumPC.Info:
                        this.picIcon.Image = Resources.icon_提示信息;
                        break;
                    case HeaderIconEnumPC.Error:
                        this.picIcon.Image = Resources.icon_error;
                        break;
                    case HeaderIconEnumPC.Question:
                        this.picIcon.Image = Resources.icon_疑问;
                        break;
                    case HeaderIconEnumPC.Warn:
                        this.picIcon.Image = Resources.icon_warning;
                        break;

                    case HeaderIconEnumPC.Search:
                        this.picIcon.Image = Resources.icon_搜索;
                        break;
                    case HeaderIconEnumPC.Location:
                        this.picIcon.Image = Resources.icon_定位;
                        break;
                    case HeaderIconEnumPC.Coordination:
                        this.picIcon.Image = Resources.icon_对话;
                        break;

                    case HeaderIconEnumPC.Print:
                        this.picIcon.Image = Resources.icon_打印;
                        break;
                    case HeaderIconEnumPC.Event:
                        this.picIcon.Image = Resources.icon_麻醉事件;
                        break;
                    case HeaderIconEnumPC.Time:
                        this.picIcon.Image = Resources.icon_时间确认;
                        break;
                    case HeaderIconEnumPC.Vistal:
                        this.picIcon.Image = Resources.icon_体征数据;
                        break;
                    case HeaderIconEnumPC.System:
                        this.picIcon.Image = Resources.icon_系统设置;
                        break;
                    case HeaderIconEnumPC.Dic:
                        this.picIcon.Image = Resources.icon_字典;
                        break;
                    case HeaderIconEnumPC.Safety:
                        this.picIcon.Image = Resources.icon_安全核查;
                        break;
                    case HeaderIconEnumPC.PatientList:
                        this.picIcon.Image = Resources.icon_换台;
                        break;

                    case HeaderIconEnumPC.PACU:
                        this.picIcon.Image = Resources.icon_PACU进程;
                        break;
                    case HeaderIconEnumPC.EmergencyRegister:
                        this.picIcon.Image = Resources.icon_急诊登记;
                        break;
                    case HeaderIconEnumPC.LAB:
                        this.picIcon.Image = Resources.icon_检验;
                        break;
                    case HeaderIconEnumPC.OperInfo:
                        this.picIcon.Image = Resources.icon_手术信息;
                        break;
                    case HeaderIconEnumPC.PreoperativeInterview:
                        this.picIcon.Image = Resources.icon_术前访视;
                        break;
                    case HeaderIconEnumPC.EMR:
                        this.picIcon.Image = Resources.icon_信息集成;
                        break;
                    case HeaderIconEnumPC.Order:
                        this.picIcon.Image = Resources.icon_医嘱;
                        break;
                    case HeaderIconEnumPC.Monitor:
                        this.picIcon.Image = Resources.icon_仪器确认;
                        break;
                    case HeaderIconEnumPC.QC:
                        this.picIcon.Image = Resources.icon_质控管理;
                        break;
                }
            }
        }
        #endregion

        private bool down = false;//标记是否按下鼠标左键
        private int starX, starY;//起始坐标

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((Control)sender).Cursor = Cursors.Hand;
                down = true;
                starX = e.X;
                starY = e.Y;
            }
        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.SizeAll;
            down = false;
        }

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (down)
            {
                this.Location = new Point(this.Location.X + e.X - starX, this.Location.Y + e.Y - starY);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作
                return cp;
            }
        }
    }

    public enum HeaderIconEnumPC
    {
        /// <summary>
        /// 信息提示
        /// </summary>
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 疑问
        /// </summary>
        Question,
        /// <summary>
        /// 错误
        /// </summary>
        Error,

        /// <summary>
        /// 搜索
        /// </summary>
        Search,
        /// <summary>
        /// 定位
        /// </summary>
        Location,
        /// <summary>
        /// 协同
        /// </summary>
        Coordination,
        /// <summary>
        /// 打印
        /// </summary>
        Print,
        /// <summary>
        /// 事件
        /// </summary>
        Event,
        /// <summary>
        /// 时间
        /// </summary>
        Time,
        /// <summary>
        /// 体征
        /// </summary>
        Vistal,
        /// <summary>
        /// 系统设置
        /// </summary>
        System,
        /// <summary>
        /// 字典
        /// </summary>
        Dic,
        /// <summary>
        /// 安全核查
        /// </summary>
        Safety,
        /// <summary>
        /// 换台
        /// </summary>
        PatientList,
        /// <summary>
        /// PACU进程
        /// </summary>
        PACU,//icon-PACU进程
        /// <summary>
        /// 急诊登记
        /// </summary>
        EmergencyRegister,//icon-急诊登记
        /// <summary>
        /// 检验
        /// </summary>
        LAB,// icon-检验
        /// <summary>
        /// 手术信息
        /// </summary>
        OperInfo, //icon-手术信息
        /// <summary>
        /// 术前访视
        /// </summary>
        PreoperativeInterview,// icon-术前访视
        /// <summary>
        /// 信息集成
        /// </summary>
        EMR,// icon-信息集成
        /// <summary>
        /// 医嘱
        /// </summary>
        Order,//icon-医嘱
        /// <summary>
        /// 仪器确认
        /// </summary>
        Monitor,  // icon-仪器确认
        /// <summary>
        /// 质控管理
        /// </summary>
        QC   // icon-质控管理

    }
}
