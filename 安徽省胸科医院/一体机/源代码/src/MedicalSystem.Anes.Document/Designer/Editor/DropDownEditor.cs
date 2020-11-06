using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Document.Designer
{
    public class DropDownEditor : UITypeEditor, IDisposable
    {
        public DropDownEditor() { }

        public DropDownEditor(DropDownEditorControl dropDownEditorControl)
            : this()
        {
            _dropDownEditorControl = dropDownEditorControl;
        }

        protected DropDownEditorControl _dropDownEditorControl;

        protected virtual void SpecialInstance(object instance)
        {

        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service1 = null;
            if (((context != null) && (context.Instance != null)) && (provider != null))
            {
                service1 = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (service1 != null)
                {
                    SpecialInstance(context.Instance);
                    if (_dropDownEditorControl == null) _dropDownEditorControl = new DropDownEditorControl();
                    _dropDownEditorControl.SetEditValue(value);
                    service1.DropDownControl(_dropDownEditorControl);
                    return _dropDownEditorControl.GetEditValue();
                }
            }
            return value;
        }

        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if ((context != null) && (context.Instance != null))
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }



        #region IDisposable 成员

        public void Dispose()
        {
            if (_dropDownEditorControl != null && !_dropDownEditorControl.IsDisposed)
                _dropDownEditorControl.Dispose();
        }

        #endregion
    }
}
