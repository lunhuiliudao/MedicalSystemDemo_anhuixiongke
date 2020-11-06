using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork.Properties;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public partial class TableControlMenu : BaseControl
    {
        public enum ControlType
        {
            病历病程,
            患者文书,
            术中操作
        }
        Font menuFont = new Font("Tahoma", 10, FontStyle.Bold);

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

        public int ThisLeft { get; set; }
        private ControlType menuType = ControlType.病历病程;

        public ControlType MenuType
        {
            get { return menuType; }
            set { menuType = value; }
        }


        public TableControlMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        public void InitItem()
        {
            showForm.FormBorderStyle = FormBorderStyle.None;
            showForm.BackColor = Color.FromArgb(160, 218, 255);
            showForm.ShowIcon = false;
            showForm.ShowInTaskbar = false;
            showForm.Deactivate += showForm_Deactivate;
            if (_Items != null && _Items.Count > 0)
            {
                int height = _Items.Count;
                if (_Items.Count < 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        panelMain.Controls.Add(CreateItemLabel(i));
                    }
                    height = 4;
                }
                else
                    for (int i = 0; i < _Items.Count; i++)
                    {
                        panelMain.Controls.Add(CreateItemLabel(i));
                    }
                showForm.Controls.Add(panelMain);
                panelMain.Dock = DockStyle.Fill;
                showForm.Height = height * 30 + 1;
            }
        }
        void showForm_Deactivate(object sender, EventArgs e)
        {
            showForm.Hide();
            if (this.Left + 100 == ThisLeft)
                this.Left += 100;
            addevent.ShowLeave = true;
            switch (menuType)
            {
                case ControlType.病历病程:
                    panelTitle.BackgroundImage = Resources.病历病程_1;
                    break;
                case ControlType.患者文书:
                    panelTitle.BackgroundImage = Resources.患者文书_1;
                    break;
                case ControlType.术中操作:
                    panelTitle.BackgroundImage = Resources.术中操作_1;
                    break;
            }
        }

        private void ButtonMenu_Resize(object sender, EventArgs e)
        {
            panelTitle.Width = this.Width;
        }

        private Label CreateItemLabel(int itemIndex)
        {
            Label itemlabel = new Label();
            itemlabel.TabIndex = itemIndex;
            itemlabel.AutoSize = false;
            itemlabel.Text = _Items.Count <= itemIndex ? "" : _Items[itemIndex];
            itemlabel.ForeColor = Color.FromArgb(160, 218, 255);
            itemlabel.TextAlign = ContentAlignment.MiddleCenter;
            itemlabel.Size = new System.Drawing.Size(this.Width, 30);
            itemlabel.BackColor = Color.White;
            itemlabel.Font = menuFont;
            if (itemIndex == 0)
                itemlabel.Location = new Point(1, 1);
            else
                itemlabel.Location = new Point(1, itemIndex * 30);

            itemlabel.ImageAlign = ContentAlignment.MiddleLeft;
            itemlabel.Click += new EventHandler(ItemLabelClick);
            itemlabel.MouseEnter += new EventHandler(itemlabel_MouseEnter);
            itemlabel.MouseLeave += new EventHandler(itemlabel_MouseLeave);
            itemlabel.MouseDown += new MouseEventHandler(itemlabel_MouseDown);
            itemlabel.Width = 98;
            return itemlabel;
        }


        private void itemlabel_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).ForeColor = Color.White;
            ((Label)sender).BackColor = Color.Blue;
        }
        private void itemlabel_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.FromArgb(126, 196, 252);
            ((Label)sender).BackColor = Color.White;
        }

        private void itemlabel_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(126, 196, 252);
            ((Label)sender).ForeColor = Color.White;
        }

        private void ItemLabelClick(object sender, EventArgs e)
        {
            Label currentLabel = sender as Label;
            if (ItemClick != null)
            {
                this.Width = 37;
                showForm.Hide();
                SelectedItem item = new SelectedItem();
                item.SelectIndex = currentLabel.TabIndex;
                item.SelectValue = currentLabel.Text;
                ItemClick(this, item);
            }
        }

        private void panelTitle_Click(object sender, EventArgs e)
        {

        }


        public delegate void ItemClickEvent(object sender, SelectedItem item);
        ControlAddEvent addevent = null;

        public class SelectedItem
        {
            public int SelectIndex { get; set; }
            public string SelectValue { get; set; }
        }
        private void TableControlMenu_Load(object sender, EventArgs e)
        {


            switch (menuType)
            {
                case ControlType.病历病程:
                    panelTitle.BackgroundImage = Resources.病历病程_1;
                    addevent = new ControlAddEvent(Resources.病历病程_1, Resources.病历病程_2, Resources.病历病程_3);
                    break;
                case ControlType.患者文书:
                    panelTitle.BackgroundImage = Resources.患者文书_1;
                    addevent = new ControlAddEvent(Resources.患者文书_1, Resources.患者文书_2, Resources.患者文书_3);
                    break;
                case ControlType.术中操作:
                    panelTitle.BackgroundImage = Resources.术中操作_1;
                    addevent = new ControlAddEvent(Resources.术中操作_1, Resources.术中操作_2, Resources.术中操作_3);
                    break;
            }
            addevent.AddMouseMove(panelTitle);
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (_Items != null && _Items.Count > 0)
            {
                addevent.ShowLeave = false;
                this.Left -= 100;
                showForm.Show();
                Point showoint = panelTitle.PointToScreen(new Point(0, 0));
                showoint.X += panelTitle.Width;
                showForm.Location = showoint;
                showForm.Width = 100;
                showForm.Activate();
            }
        }

    }
}
