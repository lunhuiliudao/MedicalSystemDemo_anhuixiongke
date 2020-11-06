using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.FrameWork;

namespace MedicalSystem.Anes.FrameWork
{
    public partial class ButtonMenu : BaseControl
    {
        /// <summary>
        /// 弹出菜单窗口
        /// </summary>
        Form showForm = new Form();
        /// <summary>
        /// 菜单
        /// </summary>
        Label panelMain = new Label();

        [Category("Action"), Description("项目点击事件")]
        public event ItemClickEvent ItemClick;

        private ProgramStatus _programStatus;

        public ProgramStatus TProgramStatus
        {
            get { return _programStatus; }
            set { _programStatus = value; }
        }


        private string _title = "标题";
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private List<string> _Items;

        /// <summary>
        ///  菜单项目
        /// </summary>
        public List<string> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        private int _selectIndex = -1;
        /// <summary>
        /// 菜单选择索引
        /// </summary>
        public int SelectIndex
        {
            get { return _selectIndex; }
            set { _selectIndex = value; }
        }


        private int _btnHeight = 40;
        /// <summary>
        /// 按钮高度
        /// </summary>
        public int BtnHeight
        {
            get { return _btnHeight; }
            set
            {
                _btnHeight = value;
                panelTitle.Height = value;
            }
        }


        //private Image _backImage;

        /// <summary>
        /// 按钮背景颜色
        /// </summary>
        public Image BackImage
        {
            set { panelTitle.BackgroundImage = value; }
        }


        public ButtonMenu()
        {
            InitializeComponent();

        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {
            //   base.OnPaint(e);
            Graphics gac = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            gac.DrawString(this._title, new Font("微软雅黑", 12), new SolidBrush(Color.White), panelTitle.ClientRectangle, sf);
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        public void InitItem()
        {
            showForm.FormBorderStyle = FormBorderStyle.None;
            showForm.BackColor = Color.White;
            showForm.ShowIcon = false;
            showForm.ShowInTaskbar = false;
            showForm.Deactivate += showForm_Deactivate;
            if (_Items != null && _Items.Count > 0)
            {
                for (int i = 0; i < _Items.Count; i++)
                {
                    panelMain.Controls.Add(CreateItemLabel(i));
                }
                showForm.Controls.Add(panelMain);
                panelMain.Dock = DockStyle.Fill;
                showForm.Height = _Items.Count * 30;
            }
        }

        void showForm_Deactivate(object sender, EventArgs e)
        {

            showForm.Hide();
        }

        private void ButtonMenu_Resize(object sender, EventArgs e)
        {
            panelTitle.Width = this.Width;
            panel1.Left = (this.Width - panel1.Width) / 2;
        }

        private Label CreateItemLabel(int itemIndex)
        {
            Label itemlabel = new Label();
            itemlabel.TabIndex = itemIndex;
            itemlabel.AutoSize = false;
            itemlabel.Text = _Items[itemIndex];
            itemlabel.ForeColor = Color.Black;
            itemlabel.TextAlign = ContentAlignment.MiddleCenter;
            itemlabel.Size = new System.Drawing.Size(this.Width, 30);
            itemlabel.BackColor = Color.Transparent;
            itemlabel.Location = new Point(0, itemIndex * 30);
            itemlabel.ImageAlign = ContentAlignment.MiddleLeft;
            itemlabel.Click += new EventHandler(ItemLabelClick);
            itemlabel.MouseEnter += new EventHandler(itemlabel_MouseEnter);
            itemlabel.MouseLeave += new EventHandler(itemlabel_MouseLeave);
            itemlabel.MouseDown += new MouseEventHandler(itemlabel_MouseDown);
            itemlabel.MouseUp += new MouseEventHandler(itemlabel_MouseUp);
            return itemlabel;
        }

        void itemlabel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void itemlabel_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).ForeColor = Color.White;
            ((Label)sender).BackColor = Color.Blue;
        }
        private void itemlabel_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;
            ((Label)sender).BackColor = Color.White;
        }

        private void itemlabel_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.DodgerBlue;
            ((Label)sender).ForeColor = Color.White;
        }

        private void ItemLabelClick(object sender, EventArgs e)
        {
            Label currentLabel = sender as Label;
            if (ItemClick != null)
            {
                showForm.Hide();
                SelectedItem item = new SelectedItem();
                item.SelectIndex = currentLabel.TabIndex;
                item.SelectValue = currentLabel.Text;
                ItemClick(this, item);
            }
        }

        private void panelTitle_Click(object sender, EventArgs e)
        {
            if (_Items != null && _Items.Count > 0)
            {
                showForm.Show();
                Point showoint = panelTitle.PointToScreen(new Point(0, 0));
                showoint.Y += _btnHeight;
                showForm.Location = showoint;
                showForm.Width = this.Width;
                showForm.Activate();

            }
        }

        private void panelTitle_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panelTitle_MouseEnter(object sender, EventArgs e)
        {

        }

    }

    public delegate void ItemClickEvent(object sender, SelectedItem item);

    public class SelectedItem
    {
        public int SelectIndex { get; set; }
        public string SelectValue { get; set; }
    }

}
