namespace DevExpress.XtraBars.Demos.DockingDemo {
    partial class SolutionExplorer {
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionExplorer));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.iRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.iShow = new DevExpress.XtraBars.BarButtonItem();
            this.iProperties = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new DevExpress.Utils.Design.DXTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.iRefresh,
            this.iShow,
            this.iProperties});
            this.barManager1.MaxItemId = 0;
            // 
            // bar1
            // 
            this.bar1.BarName = "Explorer";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(53, 102);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.iShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iProperties, true)});
            this.bar1.Offset = 2;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.RotateWhenVertical = false;
            this.bar1.Text = "Explorer";
            // 
            // iRefresh
            // 
            this.iRefresh.Caption = "Refresh";
            this.iRefresh.Hint = "Refresh";
            this.iRefresh.Id = 0;
            this.iRefresh.ImageIndex = 0;
            this.iRefresh.Name = "iRefresh";
            // 
            // iShow
            // 
            this.iShow.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iShow.Caption = "Show All Files";
            this.iShow.Hint = "Show All Files";
            this.iShow.Id = 1;
            this.iShow.ImageIndex = 1;
            this.iShow.Name = "iShow";
            this.iShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iShow_ItemClick);
            // 
            // iProperties
            // 
            this.iProperties.Caption = "Properties";
            this.iProperties.Hint = "Properties";
            this.iProperties.Id = 2;
            this.iProperties.ImageIndex = 2;
            this.iProperties.Name = "iProperties";
            this.iProperties.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iProperties_ItemClick);
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 262);
            this.panel1.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(1, 1);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.SelectionMode = DevExpress.Utils.Design.DXTreeSelectionMode.MultiSelectChildrenSameBranch;
            this.treeView1.Size = new System.Drawing.Size(286, 260);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            // 
            // SolutionExplorer
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "SolutionExplorer";
            this.Size = new System.Drawing.Size(288, 288);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem iRefresh;
        private DevExpress.XtraBars.BarButtonItem iShow;
        private DevExpress.XtraBars.BarButtonItem iProperties;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.Utils.Design.DXTreeView treeView1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private System.ComponentModel.IContainer components;

    }
}
