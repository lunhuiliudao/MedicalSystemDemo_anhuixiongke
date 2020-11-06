using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Designer
{

    public class ListDropDownEditor:DropDownEditor
    {
        public ListDropDownEditor(List<object> list,bool mulitSelect)
            : base(new ListDropDownEditorControl(list, mulitSelect))
        {
            _mulitSelect = mulitSelect;
        }

        private bool _mulitSelect = false;
        public bool MulitSelect
        {
            get
            {
                return _mulitSelect;
            }
            set
            {
                _mulitSelect = value;
            }
        }

        public ListDropDownEditor() { }

        public void SetList(List<object> list)
        {
            _dropDownEditorControl = new ListDropDownEditorControl(list,_mulitSelect);
        }
    }
}
