using System;
using System.Xml;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Designer;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Designer
{
    /// <summary>
    /// DesignerContainerXmlManager - Reads an XML file and populates the DesignerContainer.
    /// </summary>
    public class DesignerContainerXmlManager
    {
        DesignerContainer m_toolbox = null;
        private Type[] windowsFormsToolTypes = new Type[] {
			typeof(System.Windows.Forms.PropertyGrid), typeof(System.Windows.Forms.Label), typeof(System.Windows.Forms.LinkLabel), typeof(System.Windows.Forms.Button), typeof(System.Windows.Forms.TextBox), typeof(System.Windows.Forms.CheckBox), typeof(System.Windows.Forms.RadioButton), typeof(System.Windows.Forms.GroupBox), typeof(System.Windows.Forms.PictureBox), typeof(System.Windows.Forms.Panel), typeof(System.Windows.Forms.DataGrid), typeof(System.Windows.Forms.ListBox), typeof(System.Windows.Forms.CheckedListBox), typeof(System.Windows.Forms.ComboBox), typeof(System.Windows.Forms.ListView), typeof(System.Windows.Forms.TreeView), typeof(System.Windows.Forms.TabControl), typeof(System.Windows.Forms.DateTimePicker), typeof(System.Windows.Forms.MonthCalendar), typeof(System.Windows.Forms.HScrollBar), typeof(System.Windows.Forms.VScrollBar), typeof(System.Windows.Forms.Timer), typeof(System.Windows.Forms.Splitter), typeof(System.Windows.Forms.DomainUpDown), typeof(System.Windows.Forms.NumericUpDown), typeof(System.Windows.Forms.TrackBar), typeof(System.Windows.Forms.ProgressBar), typeof(System.Windows.Forms.RichTextBox), typeof(System.Windows.Forms.ImageList), typeof(System.Windows.Forms.HelpProvider), typeof(System.Windows.Forms.ToolTip), typeof(System.Windows.Forms.ToolBar), typeof(System.Windows.Forms.StatusBar), typeof(System.Windows.Forms.UserControl), typeof(System.Windows.Forms.NotifyIcon), typeof(System.Windows.Forms.OpenFileDialog), typeof(System.Windows.Forms.SaveFileDialog), typeof(System.Windows.Forms.FontDialog), typeof(System.Windows.Forms.ColorDialog), typeof(System.Windows.Forms.PrintDialog), typeof(System.Windows.Forms.PrintPreviewDialog), typeof(System.Windows.Forms.PrintPreviewControl), typeof(System.Windows.Forms.ErrorProvider), typeof(System.Drawing.Printing.PrintDocument), typeof(System.Windows.Forms.PageSetupDialog)
		};
        private Type[] componentsToolTypes = new Type[] {
			typeof(System.IO.FileSystemWatcher), typeof(System.Diagnostics.Process), typeof(System.Timers.Timer)
		};
        private Type[] dataToolTypes = new Type[] {
			typeof(System.Data.OleDb.OleDbCommandBuilder), typeof(System.Data.OleDb.OleDbConnection), typeof(System.Data.SqlClient.SqlCommandBuilder), typeof(System.Data.SqlClient.SqlConnection),
		};
        private Type[] userControlsToolTypes = new Type[] {
			typeof(System.Windows.Forms.UserControl)
		};

        public DesignerContainerXmlManager(DesignerContainer toolbox)
        {
            m_toolbox = toolbox;
        }

        public DesignerContainerTabCollection PopulateToolboxInfo()
        {
            try
            {
                if (Toolbox.FilePath == null || Toolbox.FilePath == "" || Toolbox.FilePath == String.Empty)
                    return PopulateToolboxTabs();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(Toolbox.FilePath);
                return PopulateToolboxTabs(xmlDocument);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured in reading Toolbox.xml file.\n" + ex.ToString());
                return null;
            }
        }

        private DesignerContainer Toolbox
        {
            get
            {
                return m_toolbox;
            }
        }

        private DesignerContainerTabCollection PopulateToolboxTabs()
        {
            DesignerContainerTabCollection toolboxTabs = new DesignerContainerTabCollection();
            string[] tabNames = { Strings.UserControls, Strings.WindowsForms, Strings.Components, Strings.Data };

            for (int i = 0; i < tabNames.Length; i++)
            {
                if (i > 1) break;
                DesignerContainerTab toolboxTab = new DesignerContainerTab();

                toolboxTab.Name = tabNames[i];
                PopulateDesignerContainerItems(toolboxTab);
                toolboxTabs.Add(toolboxTab);
            }

            return toolboxTabs;
        }
        private void PopulateDesignerContainerItems(DesignerContainerTab DesignerContainerTab)
        {
            if (DesignerContainerTab == null)
                return;

            Type[] typeArray = null;

            switch (DesignerContainerTab.Name)
            {
                case Strings.WindowsForms:
                    typeArray = new Type[] { typeof(MLabel), typeof(MTextBox), typeof(CustomControl), 
                                             typeof(MedGridView), typeof(MRichTextBox), typeof(MPanel), 
                                             typeof(MedDateTimer), typeof(MedMyLine), typeof(MedVitalSignGraph), 
                                             typeof(MedAnesSheetDetails), typeof(MedDrugGraph),typeof(Panel),
                                             typeof(MedSheet), typeof(MedGridGraph), typeof(NewPictureBox),
                                             typeof(MedButton), typeof(DrugContent), typeof(MedBloodGasGraph),
                                             typeof(MedLiquidStat), typeof(MedLegengGraph)};
                    break;
                case Strings.Components:
                    typeArray = componentsToolTypes;
                    break;
                case Strings.Data:
                    typeArray = dataToolTypes;
                    break;
                case Strings.UserControls:
                    //typeArray = userControlsToolTypes;
                    typeArray = new Type[] { typeof(ReportViewProperties), typeof(MedPanel) };
                    break;
                default:
                    break;
            }

            DesignerContainerItemCollection DesignerContainerItems = new DesignerContainerItemCollection();

            for (int i = 0; i < typeArray.Length; i++)
            {
                DesignerContainerItem DesignerContainerItem = new DesignerContainerItem();

                DesignerContainerItem.Type = typeArray[i];
                DesignerContainerItem.Name = typeArray[i].Name;
                DesignerContainerItems.Add(DesignerContainerItem);
            }

            DesignerContainerTab.DesignerContainerItems = DesignerContainerItems;
        }

        private DesignerContainerTabCollection PopulateToolboxTabs(XmlDocument xmlDocument)
        {
            if (xmlDocument == null)
                return null;

            XmlNode toolboxNode = xmlDocument.FirstChild;
            if (toolboxNode == null)
                return null;

            XmlNode tabCollectionNode = toolboxNode.FirstChild;
            if (tabCollectionNode == null)
                return null;

            XmlNodeList tabsNodeList = tabCollectionNode.ChildNodes;
            if (tabsNodeList == null)
                return null;

            DesignerContainerTabCollection toolboxTabs = new DesignerContainerTabCollection();

            foreach (XmlNode tabNode in tabsNodeList)
            {
                if (tabNode == null)
                    continue;

                XmlNode propertiesNode = tabNode.FirstChild;
                if (propertiesNode == null)
                    continue;

                XmlNode nameNode = propertiesNode[Strings.Name];
                if (nameNode == null)
                    continue;

                DesignerContainerTab DesignerContainerTab = new DesignerContainerTab();
                DesignerContainerTab.Name = nameNode.InnerXml.ToString();
                PopulateDesignerContainerItems(tabNode, DesignerContainerTab);
                toolboxTabs.Add(DesignerContainerTab);
            }
            if (toolboxTabs.Count == 0)
                return null;

            return toolboxTabs;
        }

        private void PopulateDesignerContainerItems(XmlNode tabNode, DesignerContainerTab DesignerContainerTab)
        {
            if (tabNode == null)
                return;

            XmlNode DesignerContainerItemCollectionNode = tabNode[Strings.DesignerContainerItemCollection];
            if (DesignerContainerItemCollectionNode == null)
                return;

            XmlNodeList DesignerContainerItemNodeList = DesignerContainerItemCollectionNode.ChildNodes;
            if (DesignerContainerItemNodeList == null)
                return;

            DesignerContainerItemCollection DesignerContainerItems = new DesignerContainerItemCollection();

            foreach (XmlNode DesignerContainerItemNode in DesignerContainerItemNodeList)
            {
                if (DesignerContainerItemNode == null)
                    continue;

                XmlNode typeNode = DesignerContainerItemNode[Strings.Type];
                if (typeNode == null)
                    continue;

                bool found = false;
                System.Reflection.Assembly[] loadedAssemblies = System.AppDomain.CurrentDomain.GetAssemblies();
                for (int i = 0; i < loadedAssemblies.Length && !found; i++)
                {
                    System.Reflection.Assembly assembly = loadedAssemblies[i];
                    System.Type[] types = assembly.GetTypes();
                    for (int j = 0; j < types.Length && !found; j++)
                    {
                        System.Type type = types[j];
                        if (type.FullName == typeNode.InnerXml.ToString())
                        {
                            DesignerContainerItem DesignerContainerItem = new DesignerContainerItem();
                            DesignerContainerItem.Type = type;
                            DesignerContainerItems.Add(DesignerContainerItem);
                            found = true;
                        }
                    }
                }
            }
            DesignerContainerTab.DesignerContainerItems = DesignerContainerItems;
            return;
        }

        private class Strings
        {
            public const string Toolbox = "Toolbox";
            public const string TabCollection = "TabCollection";
            public const string Tab = "Tab";
            public const string Properties = "Properties";
            public const string Name = "Name";
            public const string DesignerContainerItemCollection = "DesignerContainerItemCollection";
            public const string DesignerContainerItem = "DesignerContainerItem";
            public const string Type = "Type";
            public const string WindowsForms = "用户控件";//"Windows Forms";
            public const string Components = "Components";
            public const string Data = "Data";
            public const string UserControls = "组件";
        }

    }// class
}// namespace
