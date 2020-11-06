using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(false)]
    public partial class BloodGasTemplet : BaseView
    {
        private string _bloodGasTempletNames;
        public BloodGasTemplet()
        {
            InitializeComponent();
            btnAddTemplet.Enabled = false;
            btnSave.Enabled = false;
            btnDel.Enabled = false;
        }
        #region 方法
        /// <summary>
        /// 显示当前血气模板项目
        /// </summary>
        /// <param name="templetName"></param>
        private void ShowSelectedTempletItems(string templetName)
        {
            dgvItemCanSelect.Rows.Clear();
            foreach (KeyValuePair<string, string> keyValuePair in ExtendApplicationContext.Current.BloodGasItemDict)
            {
                dgvItemCanSelect.Rows.Add(new object[] { keyValuePair.Key, keyValuePair.Value });
            }
            dgvItemSelected.Rows.Clear();
            if (string.IsNullOrEmpty(templetName)) return;
            string templetString = ApplicationConfiguration.GetFromConfigTable("BloodGasItems@" + templetName);
            if (string.IsNullOrEmpty(templetString)) return;
            string[] items = templetString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                if (string.IsNullOrEmpty(item)) continue;
                string name = ExtendApplicationContext.Current.BloodGasItemDict.ContainsKey(item) ? ExtendApplicationContext.Current.BloodGasItemDict[item] : item;
                dgvItemSelected.Rows.Add(new object[] { item, name });
                RemoveFromGrid(dgvItemCanSelect, item);
            }
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="rowKey"></param>
        private void RemoveFromGrid(DataGridView grid, string rowKey)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(rowKey))
                {
                    grid.Rows.Remove(row);
                    break;
                }
            }
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="grid"></param>
        private void MoveUp(DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                int index = grid.CurrentRow.Index;
                if (index > 0)
                {
                    string code = grid.CurrentRow.Cells[0].Value.ToString();
                    string name = grid.CurrentRow.Cells[1].Value.ToString();
                    grid.Rows.Remove(grid.CurrentRow);
                    grid.Rows.Insert(index - 1, new object[] { code, name });
                    grid.CurrentCell = grid.Rows[index - 1].Cells[grid.CurrentCell.ColumnIndex];
                    ModifyConfigTable(comboBoxEditSample.Text.Trim());
                }
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="grid"></param>
        private void MoveDown(DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                int index = grid.CurrentRow.Index;
                if (index < grid.Rows.Count - 1)
                {
                    string code = grid.CurrentRow.Cells[0].Value.ToString();
                    string name = grid.CurrentRow.Cells[1].Value.ToString();
                    grid.Rows.Remove(grid.CurrentRow);
                    grid.Rows.Insert(index + 1, new object[] { code, name });
                    grid.CurrentCell = grid.Rows[index + 1].Cells[grid.CurrentCell.ColumnIndex];
                    ModifyConfigTable(comboBoxEditSample.Text.Trim());
                }
            }
        }

        private void ModifyConfigTable(string templetName)
        {
            string valueString = "";
            foreach (DataGridViewRow drow in dgvItemSelected.Rows)
            {
                valueString += "," + drow.Cells[0].Value.ToString();
            }
            if (valueString.Length > 0)
            {
                valueString = valueString.Substring(1);
            }
            ApplicationConfiguration.ModifyConfigTable("BloodGasItems@" + templetName, valueString);
            btnSave.Enabled = true;
        }
        #endregion


        private void BloodGasTemplet_Load(object sender, EventArgs e)
        {
            this.SetDefaultGridViewStyle(dgvItemCanSelect);
            this.SetDefaultGridViewStyle(dgvItemSelected);
            splitContainerControl2.SplitterPosition = splitContainerControl2.Width / 2 - 10;
            _bloodGasTempletNames = ApplicationConfiguration.BloodGasTempletNames;
            if (!string.IsNullOrEmpty(_bloodGasTempletNames))
            {
                string[] nameStrings = _bloodGasTempletNames.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string name in nameStrings)
                {
                    comboBoxEditSample.Properties.Items.Add(name);
                }
            }
            if (comboBoxEditSample.Properties.Items.Count > 0)
            {
                comboBoxEditSample.SelectedIndex = 0;
            }
        }

        private void dgvItemCanSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentRow != null)
            {
                string code = grid.CurrentRow.Cells[0].Value.ToString();
                string name = grid.CurrentRow.Cells[1].Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvItemSelected.Rows.Add(new string[] { code, name });
                ModifyConfigTable(comboBoxEditSample.Text.Trim());
            }
        }

        private void dgvItemSelected_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid.CurrentRow != null)
            {
                string code = grid.CurrentRow.Cells[0].Value.ToString();
                string name = grid.CurrentRow.Cells[1].Value.ToString();
                grid.Rows.Remove(grid.CurrentRow);
                dgvItemCanSelect.Rows.Add(new string[] { code, name });
                ModifyConfigTable(comboBoxEditSample.Text.Trim());
            }
        }

        private void comboBoxEditSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditSample.SelectedIndex >= 0)
            {
                ShowSelectedTempletItems(comboBoxEditSample.Text.Trim());
                btnDel.Enabled = !string.IsNullOrEmpty(comboBoxEditSample.Text.Trim());
            }
            else
            {
                btnDel.Enabled = false;
            }
        }

        private void txtNewTempletName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewTempletName.Text.Trim()))
            {
                btnAddTemplet.Enabled = false;
            }
            else
            {
                btnAddTemplet.Enabled = true;
            }
        }

        private void btnAddTemplet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewTempletName.Text.Trim()))
            {
                comboBoxEditSample.Properties.Items.Add(txtNewTempletName.Text.Trim());
                string str = ApplicationConfiguration.BloodGasTempletNames;
                ApplicationConfiguration.BloodGasTempletNames = !string.IsNullOrEmpty(str) ? (str + "," + txtNewTempletName.Text.Trim()) : txtNewTempletName.Text.Trim();
                comboBoxEditSample.SelectedIndex = comboBoxEditSample.Properties.Items.Count - 1;
                txtNewTempletName.Text = "";
                btnAddTemplet.Enabled = false;
            }
        }

        private void btnMenuUp_Click(object sender, EventArgs e)
        {
            MoveUp(dgvItemSelected);
        }

        private void btnMenuDown_Click(object sender, EventArgs e)
        {
            MoveDown(dgvItemSelected);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            new ComnDictRepository().SaveConfig(ExtendApplicationContext.Current.CommDict.ConfigDict);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (Dialog.MessageBox("是否确定删除该血气模板？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question).Equals(DialogResult.OK))
            {
                comboBoxEditSample.Properties.Items.Remove(comboBoxEditSample.Text);
                string str = "";
                foreach (string item in comboBoxEditSample.Properties.Items)
                {
                    str += "," + item;
                }
                if (str.Length > 0)
                {
                    str = str.Substring(1);
                }
                ApplicationConfiguration.BloodGasTempletNames = str;
                ShowSelectedTempletItems(comboBoxEditSample.Text.Trim());
                btnSave.Enabled = true;
            }
        }
    }
}
