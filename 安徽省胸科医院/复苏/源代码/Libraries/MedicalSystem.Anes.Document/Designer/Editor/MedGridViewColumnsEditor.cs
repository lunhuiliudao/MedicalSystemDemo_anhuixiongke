using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Controls; 

namespace MedicalSystem.Anes.Document.Designer
{
    public class MedGridViewColumnsEditor:DialogEditor
    {
        public MedGridViewColumnsEditor() : base() { _title = "编辑列"; }

        Panel _panelBody = new Panel();
        object _source;
        MedGridView _gird;
        PropertyGrid _propertyGrid;
        ListBox _listBox;
        List<MedGridViewColumn> _medGridViewColumns;

        protected override Control GetEditControl(object instance)
        {
            _source = instance;
            if (_source != null)
            {
                _panelBody = new Panel();
                _panelBody.Width = 800;
                _panelBody.Height = 500;
                Panel panelBottom = new Panel();
                panelBottom.Height = 80;
                panelBottom.Dock = DockStyle.Bottom;
                _panelBody.Controls.Add(panelBottom);

                MedButton btnUp = new MedButton();
                btnUp.Click += new EventHandler(btnUp_Click);
                panelBottom.Controls.Add(btnUp);
                btnUp.Text = "上移(&W)";
                btnUp.Location = new System.Drawing.Point(10, 10);
                btnUp.Width = 60;

                MedButton btnDown = new MedButton();
                btnDown.Click += new EventHandler(btnDown_Click);
                panelBottom.Controls.Add(btnDown);
                btnDown.Text = "下移(&S)";
                btnDown.Location = new System.Drawing.Point(90, 10);
                btnDown.Width = 60;

                MedButton btnAdd = new MedButton();
                btnAdd.Click += new EventHandler(btnAdd_Click);
                panelBottom.Controls.Add(btnAdd);
                btnAdd.Text = "添加(&A)";
                btnAdd.Location = new System.Drawing.Point(170, 10);
                btnAdd.Width = 60;

                MedButton btnDelete = new MedButton();
                btnDelete.Click += new EventHandler(btnDelete_Click);
                panelBottom.Controls.Add(btnDelete);
                btnDelete.Text = "删除(&D)";
                btnDelete.Location = new System.Drawing.Point(250, 10);
                btnDelete.Width = 60;

                MedButton btnOK = new MedButton();
                btnOK.Click += new EventHandler(btnOK_Click);
                panelBottom.Controls.Add(btnOK);
                btnOK.Text = "确定(&O)";
                btnOK.Location = new System.Drawing.Point(410, 10);
                btnOK.Width = 60;


                _gird = new MedGridView();
                _gird.Columns.Add("显示文本", "显示文本");
                _gird.Columns.Add("字段名称", "字段名称");
                _gird.Columns.Add("宽度", "宽度");

                _listBox = new ListBox();
                _propertyGrid = new PropertyGrid();

                if (_source is MedGridView)
                {
                    (_source as MedGridView).GetMedGridViewColumns(out _medGridViewColumns);
                }
                //else
                //    if (_source is MedDevGrid)
                //    {
                //        (_source as MedDevGrid).GetMedGridViewColumns(out _medGridViewColumns);
                //    }
                ResetList();

                 _panelBody.Controls.Add(_gird);
                _gird.Dock = DockStyle.Left;
                _gird.BringToFront();
                _gird.Visible = false;

                _panelBody.Controls.Add(_listBox);
                _listBox.Dock = DockStyle.Left;
                _listBox.BringToFront();
                _listBox.Width += 30;
                _listBox.SelectedIndexChanged += new EventHandler(listBox_SelectedIndexChanged);

                _panelBody.Controls.Add(_propertyGrid);
                _propertyGrid.Dock = DockStyle.Fill;
                _propertyGrid.BringToFront();
                _propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);

                return _panelBody;
            }
            else
            {
                return base.GetEditControl(instance);
            }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.PropertyDescriptor.Name.Equals("HeaderText"))
            {
                _listBox.Items[_listBox.SelectedIndex] = _medGridViewColumns[_listBox.SelectedIndex].HeaderText;
            }
        }

        private void ResetList()
        {
            _listBox.Items.Clear();
            _gird.Rows.Clear();
            if (_medGridViewColumns != null)
            {
                foreach (MedGridViewColumn column in _medGridViewColumns)
                {
                    _listBox.Items.Add(column.HeaderText);
                    _gird.Rows.Add();
                    _gird.Rows[_gird.Rows.Count - 2].Cells[0].Value = column.HeaderText;
                    _gird.Rows[_gird.Rows.Count - 2].Cells[1].Value = column.DataProperty;
                    _gird.Rows[_gird.Rows.Count - 2].Cells[2].Value = column.Width.ToString();
                }
            }
            if (_listBox.Items.Count > 0)
            {
                _listBox.SelectedIndex = _listBox.Items.Count - 1;
                listBox_SelectedIndexChanged(_listBox, null);
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listBox.SelectedIndex >= 0)
            {
                _propertyGrid.SelectedObject = _medGridViewColumns[_listBox.SelectedIndex];
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_panelBody != null && _panelBody.Parent != null && _panelBody.Parent is Form)
            {
                _value = Sundries.EncodeWithString(AssemblyHelper.XmlDocumentToStream(AssemblyHelper.WriteXmlDocument(_medGridViewColumns)));
                (_panelBody.Parent as Form).DialogResult = DialogResult.OK;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int index = _listBox.SelectedIndex;
            _medGridViewColumns.Reverse(index-1, 2);
            ResetList();
            index--;
            if (_listBox.Items.Count > index)
            {
                _listBox.SelectedIndex = index;
            }
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            int index = _listBox.SelectedIndex;
            _medGridViewColumns.Reverse(index, 2);
            ResetList();
            index++;
            if (_listBox.Items.Count > index)
            {
                _listBox.SelectedIndex = index;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_medGridViewColumns == null)
            {
                _medGridViewColumns = new List<MedGridViewColumn>();
            }
            _medGridViewColumns.Add(new MedGridViewColumn("column1","列1"));
            ResetList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_medGridViewColumns != null && _medGridViewColumns.Count > 0 && _listBox.SelectedIndex >= 0)
            {
                _medGridViewColumns.RemoveAt(_listBox.SelectedIndex);
                ResetList();
            }
        }
    }
}
