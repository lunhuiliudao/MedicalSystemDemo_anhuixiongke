using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DevExpress.XtraBars.Demos.DockingDemo {
    [ToolboxItem(false)]
    public partial class SolutionExplorer : System.Windows.Forms.UserControl
    {
		public SolutionExplorer() {
			InitializeComponent();
			AddAllNodes(iShow.Down);
		}

		private void SetIndex(TreeNode node, int index, bool expand) {
			int newIndex = expand ? index - 1 : index + 1;
			if(node.ImageIndex == index) 
				node.ImageIndex = node.SelectedImageIndex = newIndex;
		}

		private void treeView1_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			SetIndex(e.Node, 7, true);
			SetIndex(e.Node, 9, true);
		}

		private void treeView1_AfterCollapse(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			SetIndex(e.Node, 6, false);
			SetIndex(e.Node, 8, false);
		}

		private void AddAllNodes(bool showAll) {
			TreeNode node, node1, node2;
			treeView1.Nodes.Clear();
			treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
				new TreeNode("Solution \'DockingDemo\' (1 project)", 3, 3),
				node = new TreeNode("DockingDemo   ", 4, 4, new TreeNode[] {
				new TreeNode("References", 7, 7, new TreeNode[] {
				new TreeNode("DevExpress.Utils", 5, 5),
				new TreeNode("DevExpress.XtraBars", 5, 5),
				new TreeNode("DevExpress.XtraEditors", 5, 5),
				new TreeNode("System", 5, 5),
				new TreeNode("System.Drawing", 5, 5),
				new TreeNode("System.Windows.Forms", 5, 5)}),
				new TreeNode("AsseblyInfo.cs", 10, 10),
				node1 = new TreeNode("frmMain.cs", 11, 11),
				node2 = new TreeNode("SolutionExplorer.cs", 12, 12)})});
			node.NodeFont = new Font(treeView1.Font.Name, 8, FontStyle.Bold);
			if(showAll) {
				node.Nodes.Insert(1, 
					new TreeNode("bin", 9, 9, new TreeNode[] {
					new TreeNode("Debug", 9, 9),
					new TreeNode("Release", 9, 9)}));
				node.Nodes.Insert(2, 
					new TreeNode("obj", 9, 9, new TreeNode[] {
					new TreeNode("Debug", 9, 9),
					new TreeNode("Release", 9, 9)}));
				node1.Nodes.Add(new TreeNode("frmMain.resx", 13, 13));
				node2.Nodes.Add(new TreeNode("SolutionExplorer.resx", 13, 13));
			}
			treeView1.ExpandAll();
		}

		private void iShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
			AddAllNodes(((DevExpress.XtraBars.BarButtonItem)e.Item).Down);
		}

		public event EventHandler PropertiesItemClick;
		private void iProperties_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
			if(PropertiesItemClick != null) PropertiesItemClick(sender, EventArgs.Empty);
		
		}
	}
}
