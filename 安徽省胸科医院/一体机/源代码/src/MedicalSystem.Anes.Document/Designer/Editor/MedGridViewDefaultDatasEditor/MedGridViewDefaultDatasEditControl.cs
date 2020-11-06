using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Designer
{
    [ToolboxItem(false)]
    public partial class MedGridViewDefaultDatasEditControl : UserControl
    {
        private DialogEditor _editor = null;
        public MedGridViewDefaultDatasEditControl(string datas,List<string> list,DialogEditor editor)
        {
            InitializeComponent();
            _editor = editor;
            for (int i = 0; i < list.Count; i++)
            {
                dataGridView1.Columns.Add("Column" + i.ToString(), list[i]);
            }
            if (datas != null && !string.IsNullOrEmpty(datas))
            {
                if (datas.Contains("{}"))
                {
                    string[] rows = datas.Split(new string[] { "{}" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string rowData in rows)
                    {
                        if (!string.IsNullOrEmpty(rowData))
                        {
                            try
                            {
                                dataGridView1.Rows.Add(rowData.Split(new string[] { "[]" }, StringSplitOptions.None));
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                else if (!datas.Contains("{}") && datas.Contains("[]"))
                {
                    try
                    {
                        dataGridView1.Rows.Add(datas.Split(new string[] { "[]" }, StringSplitOptions.None));
                    }
                    catch
                    {
                    }
                }
            }
        }

        public MedGridViewDefaultDatasEditControl()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_editor != null)
            {
                string value = "";
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string rowData = "";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string s = "";
                        if (cell.Value != null && cell.Value != System.DBNull.Value)
                        {
                            s = cell.Value.ToString();
                        }
                        rowData += "[]" + s;
                    }
                    if (!string.IsNullOrEmpty(rowData))
                    {
                        rowData = rowData.Substring(2);
                    }
                    if (!string.IsNullOrEmpty(rowData.Replace("[]", "")))
                    {
                        value += "{}" + rowData;
                    }
                }
                if (!string.IsNullOrEmpty(value))
                {
                    value = value.Substring(2);
                }
                _editor.Value = value;
            }
            if (Parent is Form)
            {
                (Parent as Form).DialogResult = DialogResult.OK;
            }
        }
    }
}
