using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Designer
{
    [ToolboxItem(false)]
    public class ListDropDownEditorControl : DropDownEditorControl
    {
        protected ListBox _listbox = new ListBox();
        protected IList _list = null;
        public ListDropDownEditorControl(IList list, bool mulitSelect)
            : base()
        {
            _list = list;
            if (mulitSelect)
            {
                _listbox.SelectionMode = SelectionMode.MultiSimple;
            }
            else
            {
                _listbox.SelectionMode = SelectionMode.One;
            }
            _listbox.BorderStyle = BorderStyle.None;
            _listbox.SelectedIndexChanged += new EventHandler(_listbox_SelectedIndexChanged);
            _listbox.DoubleClick += new EventHandler(_listbox_DoubleClick);
            for (int i = 0; i < list.Count; i++)
            {
                _listbox.Items.Add(list[i]);
            }
            Controls.Add(_listbox);
            _listbox.Dock = DockStyle.Fill;
        }

        private void _listbox_DoubleClick(object sender, EventArgs e)
        {
            if (_listbox.SelectedIndex >= 0)
            {
                ProcessDialogKey(Keys.Enter);
            }
        }

        private void _listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listbox.SelectionMode == SelectionMode.One)
            {
                _newvalue = _list[_listbox.SelectedIndex];
                ProcessDialogKey(Keys.Enter);
            }
            else
            {
                List<object> list = new List<object>();
                foreach (int index in _listbox.SelectedIndices)
                {
                    list.Add(_list[index]);
                }
                _newvalue = list;
            }
        }

        protected virtual int IndexOf(object value)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].Equals(value))
                {
                    return i;
                }
            }
            return 0;
        }

        protected override void OnValueChange()
        {
            base.OnValueChange();
            if (_oldvalue == null || string.IsNullOrEmpty(_oldvalue.ToString()))
            {
                return;
            }
            _listbox.SelectedIndex = IndexOf(_oldvalue);
        }
    }
}
