using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.FrameWork.Properties;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;

namespace MedicalSystem.Anes.FrameWork
{
    public partial class ButtonDownMenu : BaseControl
    {

        Font menuFont = new Font("微软雅黑", 10, FontStyle.Bold);

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

        private List<string> _Items = new List<string>();

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

        public ButtonDownMenu()
        {
            InitializeComponent();
            ControlAddEvent cotrol = new ControlAddEvent(Resources.展开箭头_1, Resources.展开箭头_2, Resources.展开箭头_3);
            cotrol.AddMouseMove(panelDown);
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
                for (int i = 0; i < _Items.Count; i++)
                {
                    panelMain.Controls.Add(CreateItemLabel(i));
                }
                showForm.Controls.Add(panelMain);
                panelMain.Dock = DockStyle.Fill;
                showForm.Height = _Items.Count * 30 + 1;
            }
        }

        void showForm_Deactivate(object sender, EventArgs e)
        {
            showForm.Hide();
        }

        private void ButtonMenu_Resize(object sender, EventArgs e)
        {
            panelDown.Left = (this.Width - panelDown.Width) / 2;
        }
        private Label CreateItemLabel(int itemIndex)
        {
            Label itemlabel = new Label();
            itemlabel.TabIndex = itemIndex;
            itemlabel.Text = _Items[itemIndex];
            itemlabel.ForeColor = Color.FromArgb(160, 218, 255);
            itemlabel.Font = menuFont;
            itemlabel.TextAlign = ContentAlignment.MiddleCenter;
            itemlabel.Size = new System.Drawing.Size(this.Width, 30);
            itemlabel.BackColor = Color.White;
            if (itemIndex == 0)
                itemlabel.Location = new Point(1, 1);
            else
                itemlabel.Location = new Point(1, itemIndex * 30);

            itemlabel.ImageAlign = ContentAlignment.MiddleLeft;
            itemlabel.Click += new EventHandler(ItemLabelClick);
            itemlabel.MouseEnter += new EventHandler(itemlabel_MouseEnter);
            itemlabel.MouseLeave += new EventHandler(itemlabel_MouseLeave);
            itemlabel.MouseDown += new MouseEventHandler(itemlabel_MouseDown);
            itemlabel.MouseUp += new MouseEventHandler(itemlabel_MouseUp);
            itemlabel.Width = 98;
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
                showForm.Hide();
                SelectedItem item = new SelectedItem();
                item.SelectIndex = currentLabel.TabIndex;
                item.SelectValue = currentLabel.Text;
                ItemClick(this, item);
            }
        }


        public delegate void ItemClickEvent(object sender, SelectedItem item);

        public class SelectedItem
        {
            public int SelectIndex { get; set; }
            public string SelectValue { get; set; }
        }

        private void panelDown_Click(object sender, EventArgs e)
        {
            if (_Items != null && _Items.Count > 0)
            {
                showForm.Show();
                Point showoint = this.PointToScreen(new Point(0, 0));
                showoint.Y += this.Height;
                showForm.Location = showoint;
                showForm.Width = 100;
                showForm.Activate();
            }
        }

        /// <summary>
        /// 删除界面的下拉效果。
        /// </summary>
        public void SetNoPanelImage()
        {
            this.panelDown.Visible = false;
            panelDown.Click -= panelDown_Click;
            this.Controls.Remove(this.panelDown);
            this.Click += panelDown_Click;
        }

    }


}
