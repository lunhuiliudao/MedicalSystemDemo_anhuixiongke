using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Document.Controls;


namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class CurrentUser : UserControl
    {
        //定义委托
        public delegate void BtnClickHandle(object sender, string var);
        //定义事件
        public event BtnClickHandle BtnClicked;

        private string userName = "张三";


        private int msgCount = 0;

        /// <summary>
        /// 消息个数
        /// </summary>
        public int MsgCount
        {
            get { return msgCount; }
            set { msgCount = value; }
        }

        private int coorCount = 0;

        /// <summary>
        /// 协同个数
        /// </summary>
        public int CoorCount
        {
            get { return coorCount; }
            set { coorCount = value; }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                labelName.Text = userName;
            }
        }

        private string jobName = "麻醉医生";

        public string JobName
        {
            get { return jobName; }
            set
            {
                jobName = value;
                labeljob.Text = jobName;
            }
        }



        public CurrentUser()
        {
            InitializeComponent();
            ControlAddEvent msg = new ControlAddEvent(Resources.提醒_1, Resources.提醒_2, Resources.提醒_3);
            msg.AddMouseMove(pictureBoxMsg);

            ControlAddEvent xietong = new ControlAddEvent(Resources.协同_1, Resources.协同_2, Resources.协同_3);
            xietong.AddMouseMove(pictureBoxXieTong);

            ControlAddEvent rili = new ControlAddEvent(Resources.日历_1, Resources.日历_2, Resources.日历_3);
            rili.AddMouseMove(buttonDownMenuRILI);

            ControlAddEvent home = new ControlAddEvent(Resources.主页_1, Resources.主页_2, Resources.主页_3);
            home.AddMouseMove(pictureBoxHome);

            ControlAddEvent disposed = new ControlAddEvent(Resources.设置_1, Resources.设置_2, Resources.设置_3);
            disposed.AddMouseMove(buttonDownMenuDisposed);

            List<string> _Items = new List<string>();
            //_Items.Add("日程管理");
            //_Items.Add("手术查询");
            //_Items.Add("工作量统计");
            _Items.Add("个人模板管理");
            buttonDownMenuRILI.Items = _Items;
            buttonDownMenuRILI.InitItem();
            buttonDownMenuRILI.SetNoPanelImage();

            List<string> _ItemsDisposed = new List<string>();
            // if (AccessControl.CheckBrowseRight("字典"))
            _ItemsDisposed.Add("字典");
            // if (AccessControl.CheckBrowseRight("系统配置"))
            _ItemsDisposed.Add("系统配置");
            _ItemsDisposed.Add("HIS同步");
            buttonDownMenuDisposed.Items = _ItemsDisposed;
            buttonDownMenuDisposed.InitItem();
            buttonDownMenuDisposed.SetNoPanelImage();
        }

        private void pictureBoxMsg_Click(object sender, EventArgs e)
        {
            if (BtnClicked != null)
                this.BtnClicked(sender, "提醒");
        }

        private void pictureBoxXieTong_Click(object sender, EventArgs e)
        {
            if (BtnClicked != null)
                this.BtnClicked(sender, "协同");
        }

        private void buttonDownMenuRILI_ItemClick(object sender, ButtonDownMenu.SelectedItem item)
        {
            if (BtnClicked != null)
                this.BtnClicked(sender, item.SelectValue);
        }
        private void pictureBoxRili_Click(object sender, EventArgs e)
        {
            if (BtnClicked != null)
                this.BtnClicked(sender, "个人中心");
        }

        private void pictureBoxHome_Click(object sender, EventArgs e)
        {
            if (BtnClicked != null)
                this.BtnClicked(sender, "主页");
        }


        private void buttonDownMenuDisposed_ItemClick(object sender, ButtonDownMenu.SelectedItem item)
        {
            if (BtnClicked != null)
                this.BtnClicked(sender, item.SelectValue);
        }
        Font msgfont = new Font("宋体", 8);


        private void pictureBoxMsg_Paint(object sender, PaintEventArgs e)
        {
            if (msgCount > 0)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);//画刷
                e.Graphics.FillEllipse(myBrush, new Rectangle(20, 0, 15, 15));//画实心椭圆
                e.Graphics.DrawString(msgCount.ToString(), msgfont, Brushes.White, 20, 3);
            }

        }

        private void pictureBoxXieTong_Paint(object sender, PaintEventArgs e)
        {
            if (CoorCount > 0)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);//画刷
                e.Graphics.FillEllipse(myBrush, new Rectangle(20, 0, 15, 15));//画实心椭圆
                e.Graphics.DrawString(CoorCount.ToString(), msgfont, Brushes.White, 20, 3);
            }
        }

    }
}
