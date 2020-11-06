using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Designer
{
    [ToolboxItem(false)]
    public class DropDownEditorControl : UserControl
    {
        public DropDownEditorControl()
        {
            Enter += new EventHandler(DropDownEditorControl_Enter);
            Leave += new EventHandler(DropDownEditorControl_Leave);
        }

        private bool _isCancel = false;
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                _isCancel = true;
            }
            return base.ProcessDialogKey(keyData);
        }

        void DropDownEditorControl_Leave(object sender, EventArgs e)
        {
            if (_isCancel)
            {
                _newvalue = _oldvalue;
            }
        }

        void DropDownEditorControl_Enter(object sender, EventArgs e)
        {
        }

        public DropDownEditorControl(object value):this()
        {
            SetEditValue(value);
        }

        protected object _oldvalue;
        protected object _newvalue;

        protected virtual void OnValueChange()
        {
            _newvalue = _oldvalue;
        }

        public virtual void SetEditValue(object value)
        {
            _oldvalue = value;
            OnValueChange();
        }

        public virtual object GetEditValue()
        {
            return _newvalue;
        }
    }
}
