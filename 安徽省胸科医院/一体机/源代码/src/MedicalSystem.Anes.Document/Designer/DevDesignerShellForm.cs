using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars.Docking;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.IO;
using MedicalSystem.Anes.Document.Designer;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Designer.Controler;

namespace DevExpress.XtraBars.Demos.DockingDemo
 {
	public partial class DevDesignerShellForm : XtraForm {
        private int _formCount = 0;
        private ControlerSurfaceManager _hostSurfaceManager = null;
        protected TextBox _textBox = new TextBox();

        public DevDesignerShellForm()
        {
			InitializeComponent();
            CustomInitialize();
            LoadBasicDesigner();
        }

        public DevDesignerShellForm(string fileName)
            : this()
        {
            Text = "设计器（" + FileHelper.GetFileNameWithoutPath(fileName) + ")";
            OperForm(fileName);
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
                //this.Toolbox.DesignerHost = hc.DesignerHost;
                toolbox1.DesignerHost = hc.DesignerHost;
                TabPage tabpage = new TabPage("Form" + _formCount.ToString() + " - " + Strings.Design);

                Control ctrl = hc.HostSurface.View as Control ;
                ctrl.KeyDown += new KeyEventHandler(hc_KeyDown);


                hc.Parent = tabpage;
                hc.Dock = DockStyle.Fill;

                _textBox.Visible = false;
                _textBox.LostFocus += new EventHandler(LabelTextBox_LostFocus);
                tabpage.Controls.Add(_textBox);
              
                this.tabControl1.TabPages.Add(tabpage);
                this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                this.OutputWindow.RichTextBox.Text += "Opened new host.\n";
            }
            catch
            {
                MessageBox.Show("Error in creating new host", "Shell Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
        // 键盘响应
        private void hc_KeyDown(object sender, KeyEventArgs e)
        {
          
            bool done = true;
            if (!e.Alt && !e.Control && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        btnMoveUp_ItemClick(null, null);
                        break;
                    case Keys.S:
                        btnMoveDown_ItemClick(null, null);
                        break;
                    case Keys.A:
                        btnMoveLeft_ItemClick(null, null);
                        break;
                    case Keys.D:
                        btnMoveRight_ItemClick(null, null);
                        break;
                    case Keys.Delete:
                        btnDelete_ItemClick(null, null);
                        break;
                    case Keys.Space:
                        EditControl();
                        break;
                    default:
                        done = false;
                        break;
                }
            }
            else if(e.Control)
            {
                e.SuppressKeyPress = true;
                switch (e.KeyCode)
                {
                    case Keys.L:
                    case Keys.S:
                        btnAlignLeft_ItemClick(null, null);
                        break;
                    case Keys.T:
                        btnAlignTop_ItemClick(null, null);
                        break;
                    case Keys.R:
                        btnAlignRight_ItemClick(null, null);
                        break;
                    case Keys.B:
                        btnAlignBottom_ItemClick(null, null);
                        break;
                    case Keys.C:
                        iCopy_ItemClick(null, null);
                        break;
                    case Keys.V:
                        iPaste_ItemClick(null, null);
                        break;
                    default:
                        done = false;
                        break;
                }
            }
            else if (e.Shift)
            {
                e.SuppressKeyPress = true;
                switch (e.KeyCode)
                {
                    case Keys.W:
                        btnSameWidth_ItemClick(null, null);
                        break;
                    case Keys.H:
                        btnSameHeight_ItemClick(null, null);
                        break;
                    case Keys.V:
                        btnSameVSpace_ItemClick(null, null);
                        break;
                    case Keys.C:
                        btnSameHSpace_ItemClick(null, null);
                        break;
                    default:
                        done = false;
                        break;
                 }
            }
            else if (e.Alt)
            {
                e.SuppressKeyPress = true;
                switch (e.KeyCode)
                {
                    case Keys.T:
                        AddTableByLine();
                        break;
                    case Keys.Left:
                        btnMoveLeft_ItemClick(null, null);
                        break;
                    case Keys.Right:
                        btnMoveRight_ItemClick(null, null);
                        break;
                    case Keys.Up:
                        btnMoveUp_ItemClick(null, null);
                        break;
                    case Keys.Down:
                        btnMoveDown_ItemClick(null, null);
                        break;
                    default:
                        done = false;
                        break;
                }
            }

            e.SuppressKeyPress = done;
            if(done)
                CurrentDesignerViewer.NeedSave();
        }

        protected void AddTableByLine()
        {
            try
            {
                object[] objects = propertyGrid1.SelectedObjects;
                if (objects == null || objects.Length == 0)
                    return ;

                MPanel mpanel = objects[0] as MPanel;
                if (mpanel == null)
                    return;

                int maxy = 0;
                foreach (Control ctrl in mpanel.Controls)
                {
                    if (ctrl.Bottom > maxy)
                        maxy = ctrl.Bottom;
                }

                TableCreatorDlg tableCreator = new TableCreatorDlg(mpanel.Size);
                XtraForm dialogHostForm = new XtraForm();
                tableCreator.TablePos = new Point(0, maxy);
                dialogHostForm.Width = 705;
                dialogHostForm.Height = 390;
                dialogHostForm.Text = "创建表格";
                tableCreator.Dock = DockStyle.Fill;
                dialogHostForm.Controls.Add(tableCreator);

                if (dialogHostForm.ShowDialog() == DialogResult.OK)
                {
                    Type tp = Type.GetType("MedicalSystem.Anes.Document.Controls.MedMyLine");
                    int allRowHeight = Convert.ToInt32(tableCreator.AllRowHeight);
                    int allColWidth = Convert.ToInt32(tableCreator.AllColWidth);

                    // 加入横线
                    int currentPos = tableCreator.TablePos.Y;
                    for (int i = 0; i < tableCreator.RowHeight.Length; i++)
                    {
                        if (i > 0)
                        {
                            MedMyLine line1 = CurrentDocumentsHostControl.DesignerHost.CreateComponent(tp) as MedMyLine;
                            line1.Location = new Point(tableCreator.TablePos.X, currentPos);
                            line1.Width = allColWidth;
                            line1.Height = 1;
                            line1.LineType = MedMyLine.InnerLineType.Horizontal;
                            line1.Parent = mpanel;
                        }

                        currentPos += Convert.ToInt32(tableCreator.RowHeight[i]);

                        if (i == tableCreator.RowHeight.Length - 1)
                        {
                            MedMyLine line1 = CurrentDocumentsHostControl.DesignerHost.CreateComponent(tp) as MedMyLine;
                            line1.Location = new Point(tableCreator.TablePos.X, currentPos);
                            line1.Width = allColWidth;
                            line1.Height = 1;
                            line1.LineType = MedMyLine.InnerLineType.Horizontal;
                            line1.Parent = mpanel;
                        }
                    }

                    // 加入竖线
                    currentPos = tableCreator.TablePos.X;
                    for (int i = 0; i < tableCreator.ColWidth.Length; i++)
                    {
                        if (i > 0)
                        {
                            MedMyLine line1 = CurrentDocumentsHostControl.DesignerHost.CreateComponent(tp) as MedMyLine;
                            line1.Location = new Point(currentPos, tableCreator.TablePos.Y);
                            line1.Width = 1;
                            line1.Height = allRowHeight;
                            line1.LineType = MedMyLine.InnerLineType.Vertical;
                            line1.Parent = mpanel;
                        }

                        currentPos += Convert.ToInt32(tableCreator.ColWidth[i]);
                    }


                }
            }
            catch
            {
                
            }

        }


        // 编辑LABEL的文本框失去焦点时，将文本框内容赋给LABEL
        protected void LabelTextBox_LostFocus(object sender, EventArgs e)
        {
            if (_textBox.Tag is MLabel)
            {
                MLabel label = _textBox.Tag as MLabel;

                label.Text = _textBox.Text;
                _textBox.Visible = false;
                
            }
            else if (_textBox.Tag is CustomControl)
            {
                CustomControl csctrl = _textBox.Tag as CustomControl;
                csctrl.DefaultItems.Clear();
                foreach (string str in _textBox.Lines)
                {
                    int index = str.IndexOf("[#", 0);
                    if (index >= 0)
                    {
                        CustomControl.DefualtItem item = new CustomControl.DefualtItem();
                        item.ItemName = str.Substring(0, index);
                        if (index < str.Length - 4)
                        {
                            item.ItemValue = str.Substring(index + 2, str.Length - index - 4);
                        }
                        csctrl.DefaultItems.Add(item);
                    }
                    else if (str.Length > 3 && str.Substring(0, 2) == "(@")
                    {
                        csctrl.SourceTableName = "MED_CUSTOM_DATA";
                        csctrl.SourceFieldName = str.Substring(2, str.Length - 3); 
                    }
                    else
                    {
                        CustomControl.DefualtItem item = new CustomControl.DefualtItem();
                        item.ItemName = str;
                        item.ItemValue = str;
                        csctrl.DefaultItems.Add(item);
                    }
                }

                _textBox.Visible = false;
            }
        }

        // 编辑控件
        protected void EditControl()
        {
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length == 1)
            {
                Object objCtrl = objects[0];
                if(objCtrl is MLabel)
                {
                    EditLabel(objCtrl as MLabel); 
                }
                else if (objCtrl is CustomControl)
                {
                    EditCustomControl(objCtrl as CustomControl);
                }
            }
        }

        // 编辑自定义控件
        protected void EditCustomControl(CustomControl csctrl)
        {
            Point pt = csctrl.Parent.PointToScreen(csctrl.Location);
            TabPage tabpage = tabControl1.TabPages[CurrentDocumentsDesignIndex];
            pt = tabpage.PointToClient(pt);
            pt.Offset(1, -2);
            _textBox.Location = pt;
            _textBox.Width = csctrl.Width;
            _textBox.Height = csctrl.Height;
            _textBox.Font = csctrl.Font;
            _textBox.BorderStyle = BorderStyle.FixedSingle;

            bool hasFiled = false;
            int itemCount = csctrl.DefaultItems.Count;
            if (csctrl.SourceTableName != null && csctrl.SourceTableName.ToUpper() == "MED_CUSTOM_DATA")
            {
                hasFiled = true;
                itemCount ++;
            }
            
            string[] strLines = new string[itemCount];
            for (int i = 0; i < csctrl.DefaultItems.Count; i++)
            {
                strLines[i] = string.Format("{0}[#{1}#]", csctrl.DefaultItems[i].ItemName, csctrl.DefaultItems[i].ItemValue);
            }

            if (hasFiled)
            {
                strLines[strLines.Length - 1] = "(@" + csctrl.FieldName + ")";
            }

            _textBox.Lines = strLines;

            _textBox.Visible = true;
            _textBox.Tag = csctrl;
            _textBox.Multiline = true;
             _textBox.AcceptsReturn = true;
 
            _textBox.BringToFront();
            _textBox.Focus();
            _textBox.SelectionStart = _textBox.Text.Length;
        }

        // 编辑LABEL文字
        protected void EditLabel(MLabel label)
        {
            Point pt = label.Parent.PointToScreen(label.Location);
            TabPage tabpage = tabControl1.TabPages[CurrentDocumentsDesignIndex];
            pt = tabpage.PointToClient(pt);
            pt.Offset(1, -2);
            _textBox.Location = pt;
            _textBox.Width = label.Width;
            _textBox.Height = label.Height;
            _textBox.Font = label.Font;
            _textBox.BorderStyle = BorderStyle.FixedSingle;
            
            _textBox.Visible = true;
            _textBox.Tag = label;
            _textBox.Multiline = label.MultiLine;
            if (_textBox.Multiline)
                _textBox.AcceptsReturn = true;
            else
                _textBox.AcceptsReturn = false;
            _textBox.BringToFront();
            _textBox.Focus();
            _textBox.Text = label.Text;
            _textBox.SelectionStart = _textBox.Text.Length;
        }

        private void LoadBasicDesigner()
        {
            //this.noLoaderMenuItem.Checked = false;
            //this.codeDomDesignerLoaderMenuItem.Checked = false;
            //this.basicDesignerLoaderMenuItem.Checked = true;
        }

        private void CustomInitialize()
        {
            _hostSurfaceManager = new ControlerSurfaceManager();
            _hostSurfaceManager.AddService(typeof(IToolboxService), this.toolbox1);
            //_hostSurfaceManager.AddService(typeof(SolutionExplorer), this.solutionExplorer1);
            _hostSurfaceManager.AddService(typeof(OutputWindow), this.OutputWindow);
            _hostSurfaceManager.AddService(typeof(System.Windows.Forms.PropertyGrid), this.propertyGrid1);

            //codeDomDesignerLoaderMenuItem_Click(null, null);
            //this.noLoaderMenuItem_Click(null, null);
        }

        #region Skins

        //void InitSkins()
        //{
        //    barManager1.ForceInitialize();
        //    if (barManager1.GetController().PaintStyleName == "Skin")
        //    {
        //        iPaintStyle.Caption = skinMask + DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSkinName;
        //        iPaintStyle.Hint = iPaintStyle.Caption;
        //    }
        //    foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
        //    {
        //        BarButtonItem item = new BarButtonItem(barManager1, skinMask + cnt.SkinName);
        //        item.Name = "bi" + cnt.SkinName;
        //        item.Id = barManager1.GetNewItemId();
        //        iPaintStyle.AddItem(item);
        //        item.ItemClick += new ItemClickEventHandler(OnSkinClick);
        //    }
        //}
        //void OnSkinClick(object sender, ItemClickEventArgs e)
        //{
        //    string skinName = e.Item.Caption.Replace(skinMask, "");
        //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinName);
        //    barManager1.GetController().PaintStyleName = "Skin";
        //    iPaintStyle.Caption = e.Item.Caption;
        //    iPaintStyle.Hint = iPaintStyle.Caption;
        //    iPaintStyle.ImageIndex = -1;
        //}
        #endregion

        //Cursor currentCursor;

		private void iExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
			this.Close();
		}

        private void btnSameVSpace_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.VertSpaceMakeEqual);
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
        public BasicDesignerViewer CurrentDesignerViewer
        {
            get
            {
                return CurrentDocumentsHostControl.HostSurface.Loader as BasicDesignerViewer;
            }
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
        private DesignerControler CurrentDocumentsHostControl
        {
            get
            {
                foreach (Control ctrl in this.tabControl1.TabPages[CurrentDocumentsDesignIndex].Controls)
                {
                    DesignerControler dc = ctrl as DesignerControler ;
                    if(dc != null)
                        return dc; 
                }

                return null;
                //return (DesignerControler)this.tabControl1.TabPages[CurrentDocumentsDesignIndex].Controls[0];
            }
        }

        private void btnAlignLeft_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignLeft);
        }

        private void btnAlignHCenter_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignVerticalCenters);
        }

        private void btnAlignRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignRight);
        }

        private void btnAlignTop_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignTop);
        }

        private void btnAlignVCenter_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignHorizontalCenters);
        }

        private void btnAlignBottom_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.AlignBottom);
        }

        private void DevDesignerShellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BasicDesignerViewer basicDesignerViewer = CurrentDesignerViewer;
            if (basicDesignerViewer != null && basicDesignerViewer.WantSave)
            {
                switch (XtraMessageBox.Show("设计已修改并且未保存，需要保存吗", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
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
        public void SaveDesignerViewer()
        {
            BasicDesignerViewer basicDesignerViewer = CurrentDesignerViewer;
            basicDesignerViewer.Save(false);
        }

        private void btnSameWidth_ItemClick(object sender, ItemClickEventArgs e)
        {
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 1)
            {
                for (int i = 1; i < objects.Length; i++)
                {
                    (objects[i] as Control).Width = (objects[0] as Control).Width;
                }
            }
        }

        private void btnSameHeight_ItemClick(object sender, ItemClickEventArgs e)
        {
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 1)
            {
                for (int i = 1; i < objects.Length; i++)
                {
                    (objects[i] as Control).Height = (objects[0] as Control).Height;
                }
            }
        }

        private void btnMoveLeft_ItemClick(object sender, ItemClickEventArgs e)
        {
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 0)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    (objects[i] as Control).Left -= 1;
                }
            }
        }

        private void btnMoveRight_ItemClick(object sender, ItemClickEventArgs e)
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

        private void btnMoveUp_ItemClick(object sender, ItemClickEventArgs e)
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

        private void btnMoveDown_ItemClick(object sender, ItemClickEventArgs e)
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

        private void btnBringToFront_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.BringToFront);
        }

        private void btnSendToBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.SendToBack);
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.Delete);
        }

        private void panelControl1_Resize(object sender, EventArgs e)
        {
            tabControl1.Width = panelControl1.Width - tabControl1.Left;
            tabControl1.Height = panelControl1.Height - tabControl1.Top;
        }

        private void iPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            MyPasteHelper.DesignerHost = (IDesignerHost)toolbox1.DesignerHost.GetService(typeof(IDesignerHost));
            MyPasteHelper.StartPaste();
        }

        private void iCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            object[] objects = propertyGrid1.SelectedObjects;
            if (objects != null && objects.Length > 0)
            {
                List<object> objs = new List<object>();
                foreach (Object obj in objects)
                {
                    if (obj is MLabel)
                    {
                        objs.Add(MyPasteHelper.CloneMedLabel(obj as MLabel));
                    }
                    else if (obj is MTextBox)
                    {
                        objs.Add(MyPasteHelper.CloneMTextBox(obj as MTextBox));
                    }
                    else if (obj is MedMyLine)
                    {
                        objs.Add(MyPasteHelper.CloneMedMyLine(obj as MedMyLine));
                    }
                    else if (obj is CustomControl)
                    {
                        objs.Add(MyPasteHelper.CloneCustomControl(obj as CustomControl));
                    }
                }
                if (objs.Count > 0)
                {
                    MyClipBoard.Data = objs;
                }
            }
        }

        private void iUndo_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void iRedo_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void iSave_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnSameHSpace_ItemClick(object sender, ItemClickEventArgs e)
        {
            (this.CurrentDocumentsHostControl.HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService).GlobalInvoke(StandardCommands.HorizSpaceMakeEqual);
        }

        private void barToolTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddTableByLine();
        }

    }
}
