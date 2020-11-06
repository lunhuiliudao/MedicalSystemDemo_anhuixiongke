using System;
using System.Drawing;
using System.Drawing.Design;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using System.Data;
using System.IO;
using DevExpress.XtraEditors;

namespace MedicalSystem.Anes.Document.Designer
{
    public partial class DesignerShellForm : XtraForm
    {
        public DesignerShellForm()
        {
            InitializeComponent();
            CustomInitialize();
            LoadBasicDesigner();
            //NewForm();
        }

        public DesignerShellForm(string fileName):this()
        {
            OperForm(fileName);
        }

        private int _formCount = 0;
        private ControlerSurfaceManager _hostSurfaceManager = null;

        private void CustomInitialize()
        {
            _hostSurfaceManager = new ControlerSurfaceManager();
            _hostSurfaceManager.AddService(typeof(IToolboxService), this.toolbox1);
            _hostSurfaceManager.AddService(typeof(SolutionExplorer), this.solutionExplorer1);
            _hostSurfaceManager.AddService(typeof(OutputWindow), this.OutputWindow);
            _hostSurfaceManager.AddService(typeof(System.Windows.Forms.PropertyGrid), this.propertyGrid1);

            codeDomDesignerLoaderMenuItem_Click(null, null);
            this.noLoaderMenuItem_Click(null, null);
        }

        private int CurrentDocumentsDesignIndex
        {
            get
            {
                string codeText;
                string designText;
                int index = 0;

                if (CurrentDocumentView == Strings.Design)
                    return this.tabControl1.SelectedIndex;
                else
                {
                    // This is the Code View. So let us find the Design View
                    codeText = this.tabControl1.TabPages[this.tabControl1.SelectedIndex].Text.Trim();
                    designText = codeText.Replace(Strings.Code, Strings.Design);
                    foreach (TabPage tab in this.tabControl1.TabPages)
                    {
                        if (tab.Text == designText)
                            return index;
                        index++;
                    }
                }

                return -1;
            }
        }
        private int CurrentDocumentsCodeIndex
        {
            get
            {
                if (CurrentDocumentView == Strings.Code)
                    return this.tabControl1.SelectedIndex;

                int index = 0;

                //HostControl currentHostControl = CurrentDocumentsHostControl;
                // Find out if the Code Tab already exists
                string designText = this.tabControl1.TabPages[this.tabControl1.SelectedIndex].Text.Trim();
                string codeText = designText.Replace(Strings.Design, Strings.Code);

                foreach (TabPage tab in this.tabControl1.TabPages)
                {
                    if (tab.Text == codeText)
                        return index;

                    index++;
                }

                TabPage tabPage = new TabPage();

                tabPage.Text = codeText;
                //tabPage.Tag = CurrentActiveDocumentLoaderType;
                this.tabControl1.Controls.Add(tabPage);

                // Create new RichTextBox for codeEditor
                RichTextBox codeEditor = new System.Windows.Forms.RichTextBox();

                codeEditor.BackColor = System.Drawing.SystemColors.Desktop;
                codeEditor.ForeColor = System.Drawing.Color.White;
                codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
                codeEditor.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                codeEditor.Location = new System.Drawing.Point(0, 0);
                codeEditor.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
                codeEditor.WordWrap = false;
                codeEditor.Size = new System.Drawing.Size(284, 247);
                codeEditor.TabIndex = 0;
                codeEditor.ReadOnly = true;
                codeEditor.Text = "";
                tabPage.Controls.Add(codeEditor);
                return this.tabControl1.TabPages.Count - 1;
            }
        }
        private DesignerControler CurrentDocumentsHostControl
        {
            get
            {
                return (DesignerControler)this.tabControl1.TabPages[CurrentDocumentsDesignIndex].Controls[0];
            }
        }
        private RichTextBox CurrentDocumentsCodeEditor
        {
            get
            {
                return (RichTextBox)this.tabControl1.TabPages[CurrentDocumentsCodeIndex].Controls[0];
            }
        }

        private string CurrentDocumentView
        {
            get
            {
                TabPage tabPage = this.tabControl1.TabPages[this.tabControl1.SelectedIndex];

                if (tabPage.Text.Contains(Strings.Design))
                    return Strings.Design;
                else
                    return Strings.Code;
            }
        }

        private BasicDesignerViewer CurrentDesignerViewer
        {
            get
            {
                return CurrentDocumentsHostControl.HostSurface.Loader as BasicDesignerViewer;
            }
        }

        private void LoadBasicDesigner()
        {
            this.noLoaderMenuItem.Checked = false;
            this.codeDomDesignerLoaderMenuItem.Checked = false;
            this.basicDesignerLoaderMenuItem.Checked = true;
        }

        private void basicDesignerLoaderMenuItem_Click(object sender, System.EventArgs e)
        {
            LoadBasicDesigner();
        }

        private void noLoaderMenuItem_Click(object sender, System.EventArgs e)
        {
            this.noLoaderMenuItem.Checked = true;
            this.codeDomDesignerLoaderMenuItem.Checked = false;
            this.basicDesignerLoaderMenuItem.Checked = false;
        }

        private void codeDomDesignerLoaderMenuItem_Click(object sender, System.EventArgs e)
        {
            this.noLoaderMenuItem.Checked = false;
            this.codeDomDesignerLoaderMenuItem.Checked = true;
            this.basicDesignerLoaderMenuItem.Checked = false;
        }

        private void saveMenuItem_Click(object sender, System.EventArgs e)
        {
            CurrentDesignerViewer.Save();
            this.OutputWindow.RichTextBox.Text += "Saved host.\n";
        }

        private void OperForm(string fileName)
        {
            try
            {
                if (fileName == null || !System.IO.File.Exists(fileName))
                {
                    return;
                }
                _formCount++;
                //System.IO.File.Copy(fileName, "temp.xml");
                DesignerControler hc = _hostSurfaceManager.GetNewHost(fileName);
                //DesignerControler hc = _hostSurfaceManager.GetNewHost("temp.xml");
                this.Toolbox.DesignerHost = hc.DesignerHost;
                TabPage tabpage = new TabPage("Form" + _formCount.ToString() + " - " + Strings.Design);

                hc.Parent = tabpage;
                hc.Dock = DockStyle.Fill;
                this.tabControl1.TabPages.Add(tabpage);
                this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                this.OutputWindow.RichTextBox.Text += "Opened new host.\n";
            }
            catch
            {
                MessageBox.Show("Error in creating new host", "Shell Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void openMenuItem_Click(object sender, System.EventArgs e)
        {
            string fileName = null;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "xml";
            dlg.Filter = "Xml Files|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
                fileName = dlg.FileName;

            if (fileName == null)
                return;

            OperForm(fileName);
        }

        private void Save(bool showDialog)
        {
            CurrentDesignerViewer.Save(showDialog);
        }

        private void saveAsMenuItem_Click(object sender, System.EventArgs e)
        {
            Save(true);
        }

        private void exitMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void AddTabForNewHost(string tabText, DesignerControler hc)
        {
            this.Toolbox.DesignerHost = hc.DesignerHost;
            TabPage tabpage = new TabPage(tabText);
            //tabpage.Tag = CurrentMenuSelectionLoaderType;
            hc.Parent = tabpage;
            hc.Dock = DockStyle.Fill;
            this.tabControl1.TabPages.Add(tabpage);
            this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
            _hostSurfaceManager.ActiveDesignSurface = hc.HostSurface;
            //if (CurrentActiveDocumentLoaderType == LoaderType.CodeDomDesignerLoader)
            //    this.eMenuItem.Enabled = true;
            //else
            //    this.eMenuItem.Enabled = false;
            this.solutionExplorer1.AddFileNode(tabText);
            
        }

        private void NewForm()
        {
            try
            {
                _formCount++;
                DesignerControler hc = _hostSurfaceManager.GetNewHost(typeof(Form));//, CurrentMenuSelectionLoaderType);
                AddTabForNewHost("Form" + _formCount.ToString() + " - " + Strings.Design, hc);
                tabControl1.TabPages[tabControl1.TabPages.Count - 1].BackColor = Color.White;
            }
            catch
            {
                MessageBox.Show("Error in creating new host", "Shell Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void formMenuItem_Click(object sender, System.EventArgs e)
        {
            NewForm();
        }

        private void PerformAction(string text)
        {
            if (this.CurrentDocumentView == Strings.Code)
            {
                MessageBox.Show("This is not in supported code view");
                return;
            }

            if (this.CurrentDocumentsHostControl == null)
                return;

            IMenuCommandService ims = this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService;

            try
            {
                switch (text)
                {
                    case "&Cut":
                        ims.GlobalInvoke(StandardCommands.Cut);
                        break;
                    case "C&opy":
                        ims.GlobalInvoke(StandardCommands.Copy);
                        break;
                    case "&Paste":
                        ims.GlobalInvoke(StandardCommands.Paste);
                        break;
                    case "&Undo":
                        ims.GlobalInvoke(StandardCommands.Undo);
                        break;
                    case "&Redo":
                        ims.GlobalInvoke(StandardCommands.Redo);
                        break;
                    case "&Delete":
                        ims.GlobalInvoke(StandardCommands.Delete);
                        break;
                    case "&Select All":
                        ims.GlobalInvoke(StandardCommands.SelectAll);
                        break;
                    case "&Lefts":
                        ims.GlobalInvoke(StandardCommands.AlignLeft);
                        break;
                    case "&Centers":
                        ims.GlobalInvoke(StandardCommands.AlignHorizontalCenters);
                        break;
                    case "&Rights":
                        ims.GlobalInvoke(StandardCommands.AlignRight);
                        break;
                    case "&Tops":
                        ims.GlobalInvoke(StandardCommands.AlignTop);
                        break;
                    case "&Middles":
                        ims.GlobalInvoke(StandardCommands.AlignVerticalCenters);
                        break;
                    case "&Bottoms":
                        ims.GlobalInvoke(StandardCommands.AlignBottom);
                        break;
                    default:
                        break;
                }
            }
            catch 
            {
                this.OutputWindow.RichTextBox.Text += "Error in performing the action: " + text.Replace("&", "");
            }
        }

        private void ActionClick(object sender, EventArgs e)
        {
            PerformAction((sender as MenuItem).Text);
        }

        private void openMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Options can be implemented here");
        }

        private void abMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Designer Hosting sample. Whidbey ROCKS!");
        }

        private class Strings
        {
            public const string Design = "Design";
            public const string Code = "Code";
            public const string Xml = "Xml";
            public const string CS = "C#";
            public const string JS = "J#";
            public const string VB = "VB";
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            Toolbox.Top = 0;// -58;
            Toolbox.Left = 0;
            Toolbox.Width = panel1.ClientSize.Width;
            Toolbox.Height = panel1.ClientSize.Height - Toolbox.Top;
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            tabControl1.Top = -20;
            tabControl1.Left = -2;
            tabControl1.Width = panel2.ClientSize.Width + 4;
            tabControl1.Height = panel2.ClientSize.Height - tabControl1.Top + 2;
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            NewForm();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.Delete);
        }

        private void selectAllToolItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.SelectAll);
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.SelectAll);
        }

        private void deMenuItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.Delete);
        }

        private void leMenuItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignLeft);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignLeft);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignRight);
        }

        private void rightsMenuItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignRight);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignTop);
        }

        private void ceMenuItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignHorizontalCenters);
        }

        private void tMenuItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignTop);
        }

        private void miMenuItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignVerticalCenters);
        }

        private void bMenuItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignBottom);
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.Cut);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignHorizontalCenters);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignVerticalCenters);
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.Undo);
        }

        private void DesignerShellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BasicDesignerViewer basicDesignerViewer = CurrentDesignerViewer;
            if (basicDesignerViewer != null && basicDesignerViewer.WantSave)
            {
                switch (XtraMessageBox.Show("设计已修改并且未保存，需要保存吗", "提示", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        basicDesignerViewer.Save(false);
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void Toolbox_Load(object sender, EventArgs e)
        {

        }

        private void toolBtnBottomAlign_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignBottom);
        }

           private void toolBtnSameWidth_Click(object sender, EventArgs e)
        {
            //(this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.Ungroup);
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 1)
            {
                for(int i = 1; i <objects.Length; i++)
                {
                    (objects[i] as Control).Width = (objects[0] as Control).Width;
                }
            }
        }

        private void toolBtnBringToFront_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.BringToFront);
        }

        private void toolBtnSendToBack_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.SendToBack);
        }

        private void toolBtnUndo_Click(object sender, EventArgs e)
        {
            //(this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.MultiLevelUndo);
        }

        private void toolBtnSameHeight_Click(object sender, EventArgs e)
        {
            //(this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.Ungroup);
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 1)
            {
                for (int i = 1; i < objects.Length; i++)
                {
                    (objects[i] as Control).Height = (objects[0] as Control).Height;
                }
            }
        }

        private void toolBtnMoveLeft_Click(object sender, EventArgs e)
        {
            //(this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.Ungroup);
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 0)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    (objects[i] as Control).Left -= 1;
                }
            }
        }

        private void toolBtnMoveRight_Click(object sender, EventArgs e)
        {
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 0)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    (objects[i] as Control).Left += 1;
                }
            }
        }

        private void toolBtnMoveUp_Click(object sender, EventArgs e)
        {
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 0)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    (objects[i] as Control).Top -= 1;
                }
            }
        }

        private void toolBtnMoveDown_Click(object sender, EventArgs e)
        {
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 0)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    (objects[i] as Control).Top += 1;
                }
            }
        }

        private void toolBtnSameVSpace_Click(object sender, EventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.VertSpaceMakeEqual);
        }

        private void DesignerShellForm_Load(object sender, EventArgs e)
        {

        }

    }
}