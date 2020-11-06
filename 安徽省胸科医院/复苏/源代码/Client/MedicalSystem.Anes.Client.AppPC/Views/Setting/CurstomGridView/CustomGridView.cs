using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;

using DevExpress.XtraGrid.Views.Base;
using Medicalsystem.Anes.Framework;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.CustomProject;

namespace MedicalSystem.Anes.Client.AppPC
{
    [System.ComponentModel.ToolboxItem(false)]
    public class CustomGridView : GridControl
    {
        protected XmlNodeList _columnCfgList;
        private GridView gridView1;   // 列配置
        protected DataTable _datatable = null;         // 数据源表

        public XmlNodeList ColumnConfig
        {
            get { return _columnCfgList; }
            set
            {
                _columnCfgList = value;
                if (MainView == null)
                    return;

                GridView view = MainView as GridView;
                
                if (view == null)
                    return;

                view.Columns.Clear();
             
                foreach(XmlElement node in _columnCfgList)
                {
                    // 增加列
                    GridColumn column = new GridColumn();
                    column.Caption = node.GetAttribute("caption");
                    column.FieldName = node.GetAttribute("fieldname");
                    column.OptionsColumn.AllowEdit = node.GetAttribute("edit").ToLower() == "true" ? true : false;
                    column.Width = Convert.ToInt32(node.GetAttribute("width"));
                    //column.OptionsColumn.FixedWidth = true;
                    column.VisibleIndex = view.Columns.Count + 1;
                    //int curIndex = view.Columns.Add(column);

                    // 设置编辑方式
                    if (node.HasAttribute("edittype"))
                    {
                        RepositoryItem item = null;

                        switch (node.GetAttribute("edittype"))
                        {
                            case "checkbox":
                                item = new RepositoryItemCheckEdit();
                                item.AutoHeight = false;
                                item.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                                break; 
                            case "combobox":
                                item = new RepositoryItemComboBox();
                                item.AutoHeight = false;
                                ((RepositoryItemComboBox)item).AllowNullInput = DevExpress.Utils.DefaultBoolean.False;


                                // 设置下拉列表
                                XmlNode nodeDict = node.SelectSingleNode("DICT[@default='true']");
                                if (nodeDict != null)
                                {
                                    SetComboxItems ((RepositoryItemComboBox)item, nodeDict as XmlElement, null);
                                }
                                item.Tag = nodeDict;

                                // 设置关联事件
                                if (node.HasAttribute("depend"))
                                    ((RepositoryItemComboBox)item).Enter += new EventHandler(ComboBox_Show);
                              
                                break;
                        }

                        if(item != null)
                        {
                            RepositoryItems.Add(item);
                            column.ColumnEdit = item;
                        }
                    }
                 }     
            }
        }

       

        // 下拉框显示事件
        protected void ComboBox_Show(object sender, EventArgs e)
        {
            GridView view = MainView as GridView;
            if (view == null)
                return;

            DevExpress.XtraEditors.ComboBoxEdit boxedit = sender as DevExpress.XtraEditors.ComboBoxEdit;
            RepositoryItemComboBox box = boxedit.Properties as RepositoryItemComboBox;
            if (box == null)
                return;
            

            // 获取当前的行
            int[] selectRows = view.GetSelectedRows();
            if (selectRows.Length < 1)
                return;

            XmlElement nodeDict = box.Tag as XmlElement;
            if (nodeDict == null)
                return;

            // 重置下拉框
            box.Items.Clear();

            XmlElement node = nodeDict.ParentNode as XmlElement;
          
            // 查找对应下拉字典
            string fieldname = node.GetAttribute("depend");
            string dependvalue = string.IsNullOrEmpty(fieldname) ? "" : view.GetRowCellValue(selectRows[0], fieldname).ToString();
            string xpath = "DICT[@dependvalue='" + dependvalue + "']";
            nodeDict = node.SelectSingleNode(xpath) as XmlElement;
            if (nodeDict == null)
                  nodeDict = node.SelectSingleNode("DICT[@default='true']") as XmlElement;

            if (nodeDict != null)
            {
                DataRow row = null;
                if (nodeDict.HasAttribute("filter"))
                {
                    DataRow gridRow = _datatable.Rows[selectRows[0]];
                    DataTable dt = _datatable.Clone();
                    row = dt.NewRow();

                    // 获取数据库存储格式的行
                    foreach (XmlElement colNode in _columnCfgList)
                    {
                        string field = colNode.GetAttribute("fieldname");
                        row[field] = gridRow[field];
                    }

                    foreach (XmlElement colNode in _columnCfgList)
                    {
                        string field = colNode.GetAttribute("fieldname");
                        if (field == node.GetAttribute("fieldname"))  // 只处理当前列以前的
                            break;

                        DataColumn col = _datatable.Columns[field];
                        GridRowToDbRow(colNode, col, gridRow, row);
                    }
                }

                // 设置下拉列表
                SetComboxItems(box, nodeDict, row);
            }
            
            box.Tag = nodeDict;
        }

        // 转换过滤字符串
        protected string GetSelectString(string filter, DataRow row)
        {
            int index = filter.IndexOf("#(", 0);
            while (index > 0)
            {
                int index2 = filter.IndexOf(")#", index+1);
                if (index2 > 0)
                {
                    string strField = filter.Substring(index+2 , index2 - index -2);
                    filter = filter.Replace("#(" + strField + ")#", row[strField].ToString());
                }

                index = filter.IndexOf("#(", 0);
            }

            return filter;
        }

        // 设置下拉列表选项
        protected void SetComboxItems(RepositoryItemComboBox box, XmlElement nodeDict, DataRow dbRow)
        {
            if (nodeDict.HasAttribute("dict_name") && nodeDict.HasAttribute("dict_valuefield"))
            {
                string dictKeyName = nodeDict.GetAttribute("dict_name");
                DataTable table = DataContext.GetCurrent().GetDictDataByTableName(dictKeyName);

                string fieldname = nodeDict.GetAttribute("dict_valuefield");

                if (table == null)
                    return;
                
                // 处理过滤项
                if (nodeDict.HasAttribute("filter"))
                {
                    string where = nodeDict.GetAttribute("filter");

                    XmlElement node = nodeDict.ParentNode as XmlElement;
                    if (node.HasAttribute("depend")) // 过滤中包含依赖项
                    {
                        if (dbRow == null)
                            return;

                        where = GetSelectString(where, dbRow);
                    }

                    DataRow[] rows = table.Select(where);
                    foreach (DataRow row in rows)
                    {
                        box.Items.Add(row[fieldname]);
                    }
                }
                else
                {
                    foreach (DataRow row in table.Rows)
                    {
                        box.Items.Add(row[fieldname]);
                    }
                }
            }
            else
            {
                XmlNodeList dictItemList = nodeDict.SelectNodes("RECORD/ITEM_NAME");
                foreach (XmlNode dictItem in dictItemList)
                {
                    box.Items.Add(dictItem.InnerXml);
                }
            }
        }

        // 表格用数据集转成数据库用数据集
        protected void GridRowToDbRow(XmlElement node, DataColumn col, DataRow gridRow, DataRow dbRow)
        {
            // 获取对应字典
            XmlElement nodeDict = null;
            if (node.HasAttribute("depend"))
            {
                string dependname = node.GetAttribute("depend");
                string dependvalue = string.IsNullOrEmpty(dependname)? "" : gridRow[dependname].ToString();
                string xpath = "DICT[@dependvalue='" + dependvalue + "']";
                nodeDict = node.SelectSingleNode(xpath) as XmlElement;
            }

            if (nodeDict == null)
                nodeDict = node.SelectSingleNode("DICT[@default='true']") as XmlElement;

            if (nodeDict == null)
                return;

            if (nodeDict.HasAttribute("dict_name"))
            {
                // 值转代码
                DataTable table = DataContext.GetCurrent().GetDictDataByTableName(nodeDict.GetAttribute("dict_name"));
                string valuefield = nodeDict.GetAttribute("dict_valuefield");
                string where = valuefield + "='" + dbRow[col.ColumnName] + "'";
                if(nodeDict.HasAttribute("filter"))
                {
                    where += " and " + nodeDict.GetAttribute("filter");
                }

                where = GetSelectString(where, dbRow);
                DataRow[] dictRows = table.Select(where);

                if (nodeDict.HasAttribute("dict_codefield"))
                {
                    string codefield = nodeDict.GetAttribute("dict_codefield");
                    if (dictRows.Length > 0)
                    {
                        dbRow[col.ColumnName] = Convert.ChangeType(dictRows[0][codefield], col.DataType);
                    }
                }

                // 获取联合字段值
                if (dictRows != null && dictRows.Length > 0)
                {
                    if (node.HasAttribute("combinefield") && nodeDict.HasAttribute("combinefield"))
                    {
                        string[] combofields = node.GetAttribute("combinefield").Split(',');
                        string[] dictfields = nodeDict.GetAttribute("combinefield").Split(',');
                        for (int k = 0; k < combofields.Length; k++)
                        {
                            dbRow[combofields[k]] = Convert.ChangeType(dictRows[0][dictfields[k]], col.DataType);
                        }
                    }
                }

            }
            else
            {
                string xpath = "descendant::RECORD[ITEM_NAME='" + dbRow[col.ColumnName].ToString() + "']";
                XmlNode nodeRow = nodeDict.SelectSingleNode(xpath);
                if (nodeRow != null)
                {
                    // 值转代码
                    XmlElement codeElement = ((XmlElement)nodeRow).SelectSingleNode("ITEM_CODE") as XmlElement;
                    if (codeElement != null)
                    {
                        string rowValue = codeElement.InnerXml;
                        dbRow[col.ColumnName] = Convert.ChangeType(rowValue, col.DataType);
                    }
                }
            }
        }

        // 数据库用数据集转成表格用数据集
        protected void DbRowToGridRow(XmlElement node, DataColumn col, DataRow gridRow, DataRow dbRow)
        {
            // 获取对应字典
            XmlElement nodeDict = null;
            if (node.HasAttribute("depend"))
            {
                string dependname = node.GetAttribute("depend");
                string dependvalue = string.IsNullOrEmpty(dependname)? "" : gridRow[dependname].ToString(); 
                string xpath = "DICT[@dependvalue='" + dependvalue + "']";
                nodeDict = node.SelectSingleNode(xpath) as XmlElement;
            }

            if (nodeDict == null)
                nodeDict = node.SelectSingleNode("DICT[@default='true']") as XmlElement;
            
            if (nodeDict == null)
                return;


            if (nodeDict.HasAttribute("dict_name"))
            {
                // 代码转值
                if (nodeDict.HasAttribute("dict_codefield"))
                {
                    DataTable table = DataContext.GetCurrent().GetDictDataByTableName(nodeDict.GetAttribute("dict_name"));
                    string valuefield = nodeDict.GetAttribute("dict_valuefield");
                    string codefield = nodeDict.GetAttribute("dict_codefield");
                    string where = codefield + "='" + dbRow[col.ColumnName].ToString() + "'";
                    if (nodeDict.HasAttribute("filter"))
                    {
                        where += " " + nodeDict.GetAttribute("filter");
                    }

                    where = GetSelectString(where, dbRow);
                    DataRow[] dictRows = table.Select(where);
                    if (dictRows.Length > 0)
                        gridRow[col.ColumnName] = Convert.ChangeType(dictRows[0][valuefield], col.DataType);
                }
            }
            else
            {
                string xpath = "descendant::RECORD[ITEM_CODE='" + gridRow[col.ColumnName].ToString() + "']";
                XmlNode nodeRow = node.SelectSingleNode(xpath);
                if (nodeRow != null)
                {
                    string rowValue = ((XmlElement)nodeRow).SelectSingleNode("ITEM_NAME").InnerXml;
                    gridRow[col.ColumnName] = Convert.ChangeType(rowValue, col.DataType);

                    if (node.HasAttribute("combofield") && nodeDict.HasAttribute("combinefield"))
                    {
                        string[] combofields = node.GetAttribute("combinefield").Split(',');
                        string[] dictfields = nodeDict.GetAttribute("combinefield").Split(',');
                        for (int k = 0; k < combofields.Length; k++)
                        {
                            gridRow[combofields[k]] = Convert.ChangeType(((XmlElement)nodeRow).GetAttribute(dictfields[k]), col.DataType);
                        }
                    }
                }
            }
        }

        // 获取/设置数据源
        public new  DataTable DataSource
        {
	        get 
	        {
                if (_datatable == null)
                    return null;

                GridView view = MainView as GridView;
                if (view == null)
                    return null;
                
                DataTable dt = _datatable.Copy();

                foreach (XmlElement node in _columnCfgList)
                {
                    string fieldname = node.GetAttribute("fieldname");
                    DataColumn col = dt.Columns[fieldname];

                    for(int i = 0; i < dt.Rows.Count; i ++)
                        GridRowToDbRow(node, col, _datatable.Rows[i], dt.Rows[i]);
                }

                return dt;
	        }
	        set
            {
                if (value == null)
                    return;

                _datatable = value.Copy();

                // 从值到代码
                foreach (XmlElement node in _columnCfgList)
                {
                    string fieldname = node.GetAttribute("fieldname");
                    DataColumn col = _datatable.Columns[fieldname];

                    for (int i = 0; i < _datatable.Rows.Count; i++)
                        DbRowToGridRow(node, col, _datatable.Rows[i], value.Rows[i]);
                    
                }

                base.DataSource = _datatable;
	        }
        }

        private void InitializeComponent()
        {
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this;
            this.gridView1.Name = "gridView1";
            // 
            // CustomGridView
            // 
            this.MainView = this.gridView1;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }


        public void AddNewRow()
        {
            if(_datatable == null)
                return;

            DataRow row = _datatable.NewRow();
            foreach (XmlElement node in _columnCfgList)
            {
                if (node.HasAttribute("defaultvalue"))
                {
                    DataColumn col = _datatable.Columns[node.GetAttribute("fieldname")];
                    object obj = Convert.ChangeType(node.GetAttribute("defaultvalue"), col.DataType);
                    row[col] = obj;
                }
            }

            _datatable.Rows.Add(row);
        }
    }
}