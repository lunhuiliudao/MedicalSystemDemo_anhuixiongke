using MedicalSystem.Anes.Client.FrameWork.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public partial class TreeViewExtend : TreeView
    {
        /*1节点被选中 ,TreeView有焦点*/
        private SolidBrush brush1 = new SolidBrush(Color.FromArgb(223, 242, 252));//填充颜色
        //private Pen pen1 = new Pen(Color.FromArgb(102, 167, 232), 1);//边框颜色

        /*2节点被选中 ,TreeView没有焦点*/
        private SolidBrush brush2 = new SolidBrush(Color.FromArgb(247, 247, 247));
        private Pen pen2 = new Pen(Color.FromArgb(222, 222, 222), 1);

        /*3 MouseMove的时候 画光标所在的节点的背景*/
        private SolidBrush brush3 = new SolidBrush(Color.FromArgb(229, 243, 251));
        private Pen pen3 = new Pen(Color.FromArgb(112, 192, 231), 1);

        bool ArrowKeyUp = false;
        bool ArrowKeyDown = false;



        public TreeViewExtend()
        {
            InitializeComponent();
            this.Font = new Font("Tahoma", 12);
            this.ItemHeight = 35;

            this.HotTracking = true;
            this.HideSelection = false;


            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FullRowSelect = true;
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;

            this.DrawNode += TreeViewExtend_DrawNode;
            this.BeforeSelect += TreeViewExtend_BeforeSelect;
            this.KeyDown += TreeViewExtend_KeyDown;
            this.AfterCollapse += TreeViewExtend_AfterCollapse;
            this.AfterExpand += TreeViewExtend_AfterExpand;

        }
        public TreeViewExtend(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.Font = new Font("Tahoma", 12);
            this.ItemHeight = 35;

            this.HotTracking = true;
            this.HideSelection = false;
            this.ShowLines = false;

            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FullRowSelect = true;
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;

            this.DrawNode += TreeViewExtend_DrawNode;
            this.BeforeSelect += TreeViewExtend_BeforeSelect;
            this.KeyDown += TreeViewExtend_KeyDown;
            this.AfterCollapse += TreeViewExtend_AfterCollapse;
            this.AfterExpand += TreeViewExtend_AfterExpand;
        }

        void TreeViewExtend_AfterExpand(object sender, TreeViewEventArgs e)
        {

            int result = 0;
            foreach (TreeNode tn in this.Nodes)
            {
                result += GetTreeHeight(tn);
            }
            this.Height = result;
        }

        void TreeViewExtend_AfterCollapse(object sender, TreeViewEventArgs e)
        {

            int result = 0;
            foreach (TreeNode tn in this.Nodes)
            {
                result += GetTreeHeight(tn);
            }
            this.Height = result;
        }

        private int GetTreeHeight(TreeNode tn)
        {

            int height = 0;
            if (tn.IsExpanded)
            {
                foreach (TreeNode tnSub in tn.Nodes)
                {
                    if (tnSub.IsExpanded)
                    {
                        height += GetTreeHeight(tnSub);
                    }
                    else
                    {
                        height += tn.Bounds.Height;
                    }
                }
            }
            else
            {
                height += tn.Bounds.Height;
            }
            return height + tn.Bounds.Height;
        }

        void TreeViewExtend_KeyDown(object sender, KeyEventArgs e)
        {
            ArrowKeyUp = (e.KeyCode == Keys.Up);
            if (e.KeyCode == Keys.Down)
            {
                Text = "Down";
            }

            ArrowKeyDown = (e.KeyCode == Keys.Down);
            if (e.KeyCode == Keys.Up)
            {
                Text = "UP";
            }
        }

        void TreeViewExtend_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null)
            {
                //禁止选中空白项
                if (e.Node.Text == "")
                {
                    //响应上下键
                    if (ArrowKeyUp)
                    {
                        if (e.Node.PrevNode != null && e.Node.PrevNode.Text != "")
                            this.SelectedNode = e.Node.PrevNode;
                    }

                    if (ArrowKeyDown)
                    {
                        if (e.Node.NextNode != null && e.Node.NextNode.Text != "")
                            this.SelectedNode = e.Node.NextNode;
                    }

                    e.Cancel = true;
                }
            }
        }

        void TreeViewExtend_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Rectangle nodeRect = new Rectangle(1,
                                               e.Bounds.Top,
                                               e.Bounds.Width - 3,
                                               e.Bounds.Height - 1);
            //1     选中的节点背景=========================================
            if (e.Node.IsSelected)
            {
                //TreeView有焦点的时候 画选中的节点
                if (this.Focused)
                {
                    e.Graphics.FillRectangle(brush1, nodeRect);
                    //e.Graphics.DrawRectangle(pen1, nodeRect);

                    /*测试 画聚焦的边框*/
                    ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, Color.Black, SystemColors.Highlight);
                }
                /*TreeView失去焦点的时候 */
                else
                {
                    e.Graphics.FillRectangle(brush2, nodeRect);
                    // e.Graphics.DrawRectangle(pen2, nodeRect);
                }
            }
            else if ((e.State & TreeNodeStates.Hot) != 0 && e.Node.Text != "")//|| currentMouseMoveNode == e.Node)
            {
                e.Graphics.FillRectangle(brush3, nodeRect);
                //e.Graphics.DrawRectangle(pen3, nodeRect);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            //2     +-号绘制=========================================

            Rectangle plusRect = new Rectangle(e.Node.Bounds.Left - 20, nodeRect.Top + 4, 20, 20); // +-号的大小 是9 * 9

            if (e.Node.IsExpanded)
                e.Graphics.DrawImage(Resources.展开箭头2, plusRect);
            else if (e.Node.IsExpanded == false && e.Node.Nodes.Count > 0)
                e.Graphics.DrawImage(Resources.展开箭头1, plusRect);

            //3     文本绘制=========================================
            Rectangle nodeTextRect = new Rectangle(
                                                    e.Node.Bounds.Left + 30,
                                                    e.Node.Bounds.Top + 2,
                                                    e.Node.Bounds.Width + 20,
                                                    e.Node.Bounds.Height
                                                    );
            nodeTextRect.Width += 4;
            nodeTextRect.Height -= 4;

            e.Graphics.DrawString(e.Node.Text,
                                  e.Node.TreeView.Font,
                                  new SolidBrush(Color.FromArgb(92, 92, 92)),
                                  nodeTextRect);


            //画子节点个数 (111)
            if (e.Node.GetNodeCount(true) > 0)
            {
                e.Graphics.DrawString(string.Format("({0})", e.Node.GetNodeCount(true)),
                                        new Font("Arial", 8),
                                        Brushes.Gray,
                                        nodeTextRect.Right - 4,
                                        nodeTextRect.Top + 4);
            }


            //4     画的图标===================================================================

            if (e.Node.Parent != null)
            {
                Rectangle imagebox = new Rectangle(
              e.Node.Bounds.X - 3,
              e.Node.Bounds.Y + 3,
              20,//IMAGELIST IMAGE WIDTH
              20);//HEIGHT
                if (e.Node.IsSelected)
                    e.Graphics.DrawImage(Resources.麻醉下文书2, imagebox);
                else
                    e.Graphics.DrawImage(Resources.麻醉下文书1, imagebox);
                if ((e.State & TreeNodeStates.Hot) != 0 && e.Node.Text != "")
                    e.Graphics.DrawImage(Resources.麻醉下文书2, imagebox);
            }
            else
            {
                Rectangle imagebox = new Rectangle(
              e.Node.Bounds.X + 10,
              e.Node.Bounds.Y + 3,
              20,//IMAGELIST IMAGE WIDTH
              20);//HEIGHT
                if (e.Node.Text == "电子病历")
                {
                    e.Graphics.DrawImage(Resources.电子病历1, imagebox);
                }
                else if (e.Node.Text == "检验查询")
                {
                    e.Graphics.DrawImage(Resources.检验1, imagebox);
                }
                else if (e.Node.Text.Contains("麻醉首页"))
                {
                    if (e.Node.IsExpanded && e.Node.Nodes.Count > 0)
                        e.Graphics.DrawImage(Resources.麻醉首页2, imagebox);
                    else
                        e.Graphics.DrawImage(Resources.麻醉首页1, imagebox);
                }
                else
                {
                    if (e.Node.IsSelected)
                        e.Graphics.DrawImage(Resources.麻醉下文书2, imagebox);
                    else
                        e.Graphics.DrawImage(Resources.麻醉下文书1, imagebox);

                    if ((e.State & TreeNodeStates.Hot) != 0 && e.Node.Text != "")
                        e.Graphics.DrawImage(Resources.麻醉下文书2, imagebox);

                }
            }
        }
    }
}
