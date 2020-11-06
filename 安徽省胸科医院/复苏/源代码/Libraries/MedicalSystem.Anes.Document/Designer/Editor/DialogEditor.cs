using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Designer
{
    public abstract class DialogEditor:UITypeEditor
    {

        public DialogEditor() {}

        protected object _value;
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        protected string _title = "自定义编辑器";

        protected virtual Control GetEditControl(object instance)
        {
            return new Control();
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service1 = null;
            if (((context != null) && (context.Instance != null)) && (provider != null))
            {
                service1 = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (service1 != null)
                {
                    _value = value;
                    Control control = GetEditControl(context.Instance);
                    Form frm = new Form();
                    frm.Text = _title;
                    frm.Controls.Add(control);
                    frm.Width = control.Width;
                    frm.Height = control.Height + 20;
                    control.Dock = DockStyle.Fill;
                    frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                    frm.MaximizeBox = false;
                    service1.ShowDialog(frm);
                }
            }
            return _value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if ((context != null) && (context.Instance != null))
            {
                return UITypeEditorEditStyle.Modal;
            }
            return base.GetEditStyle(context);
        }
    }
}
