using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Properties;


namespace MedicalSystem.Anes.Document.Controls
{
    public partial class DownMenuDoc : UserControl
    {

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

        private List<string> _Items = new List<string>();



        private int tags = 0;

        public int Tags
        {
            get { return tags; }
            set { tags = value; }
        }


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

        public DownMenuDoc()
        {
            InitializeComponent();
            ControlAddEvent cotrol = new ControlAddEvent(Resources.文书_下拉箭头1, Resources.文书_下拉箭头2, Resources.文书_下拉箭头2);
            cotrol.AddMouseMove(panelDown);
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        public void InitItem(string item)
        {
            showForm.FormBorderStyle = FormBorderStyle.None;
            showForm.BackColor = Color.FromArgb(160, 218, 255);
            showForm.ShowIcon = false;
            showForm.ShowInTaskbar = false;
            showForm.Deactivate += showForm_Deactivate;
            if (_Items != null && _Items.Count > 0)
            {
                panelMain.Controls.Clear();
                for (int i = 0; i < _Items.Count; i++)
                {
                    panelMain.Controls.Add(CreateItemLabel(i, item));
                }
                showForm.Controls.Add(panelMain);
                panelMain.Dock = DockStyle.Fill;
                showForm.Height = _Items.Count * 30 + 2;
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
        private Label CreateItemLabel(int itemIndex, string item)
        {
            Label itemlabel = new Label();
            itemlabel.TabIndex = itemIndex + tags;


            if (_Items[itemIndex] == item)
            {
                itemlabel.Image = Resources.文书_勾2;
                itemlabel.ImageAlign = ContentAlignment.MiddleLeft;
                itemlabel.Text = "   " + _Items[itemIndex];
            }
            else
            {
                itemlabel.Text = _Items[itemIndex];
                itemlabel.Image = null;

            }
            itemlabel.TextAlign = ContentAlignment.MiddleLeft;
            itemlabel.ForeColor = Color.FromArgb(160, 218, 255);
            itemlabel.Font = menuFont;

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
            itemlabel.Width = 148;
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
            if (((Label)sender).Image != null)
                ((Label)sender).Image = Resources.文书_勾2;
        }

        private void itemlabel_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(126, 196, 252);
            ((Label)sender).ForeColor = Color.White;
            if (((Label)sender).Image != null)
                ((Label)sender).Image = Resources.文书_勾1;
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
                ItemClick(this, item, currentLabel.TabIndex);
            }
        }


        public delegate void ItemClickEvent(object sender, SelectedItem item, int index);

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
                showForm.Width = 150;
                showForm.Activate();
            }
        }

    }


}
