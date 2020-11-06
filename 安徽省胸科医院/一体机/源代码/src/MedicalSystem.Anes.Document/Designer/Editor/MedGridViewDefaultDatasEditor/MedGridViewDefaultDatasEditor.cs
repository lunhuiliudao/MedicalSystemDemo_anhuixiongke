using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Designer
{
    public class MedGridViewDefaultDatasEditor : DialogEditor
    {
        public MedGridViewDefaultDatasEditor() : base() { _title = "编辑表格默认数据"; }

        private object _source;

        protected override Control GetEditControl(object instance)
        {
            _source = instance;
            if (_source != null)
            {
                if (_source is MedGridView)
                {
                    List<string> list = new List<string>();
                    List<MedGridViewColumn> medGridViewColumns;
                    (_source as MedGridView).GetMedGridViewColumns(out medGridViewColumns);
                    if (medGridViewColumns != null)
                    {
                        foreach (MedGridViewColumn column in medGridViewColumns)
                        {
                            list.Add(column.HeaderText);
                        }
                    }
                    return new MedGridViewDefaultDatasEditControl((_source as MedGridView).DefaultDatas, list,this);
                }
                else
                {
                    return base.GetEditControl(instance);
                }
            }
            else
            {
                return base.GetEditControl(instance);
            }
        }
    }
}
