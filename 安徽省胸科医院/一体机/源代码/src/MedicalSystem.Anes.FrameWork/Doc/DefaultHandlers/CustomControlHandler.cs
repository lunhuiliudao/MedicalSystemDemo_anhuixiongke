using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Documents
{
    public class CustomControlHandler : UIElementHandler<CustomControl>
    {
        /// <summary>
        ///  绑定数据源数据到控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindDataToUI(CustomControl control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (dataSources.Count == 0) return;
            //加载自定义选项
            if (!control.IsItemsLoaded)
            {
                if (!string.IsNullOrEmpty(control.DictTableName))
                {
                    //DataTable table = ExtendAppContext.CurntSelect.CodeTables[control.DictTableName.ToUpper()];
                    //control.SetTable(table);
                }
                control.IsDesigned = false;
            }

            control.Value = "";
            control.ClearValue();

            if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
                return;
            object value = GetFieldValue(control.SourceTableName, control.SourceFieldName);

            if (value != null)
            {
                if (control.MultiSelect)
                {
                    control.Value = string.IsNullOrEmpty(value.ToString()) ? control.DefaultCheckValue : value.ToString();
                }
                else
                {
                    control.SimpleValue = string.IsNullOrEmpty(value.ToString()) ? control.DefaultCheckValue : value;
                }
            }

        }
        /// <summary>
        /// 绑定控件内容到数据源
        /// </summary>
        /// <param name="control"></param>
        /// <param name="dataSources"></param>
        public override void BindUIToData(CustomControl control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            if (dataSources.Count == 0) return;
            if (string.IsNullOrEmpty(control.SourceTableName) || string.IsNullOrEmpty(control.SourceFieldName))
                return;
            if (control.ReadOnly == true || control.Enabled == false)
                return;

            object value = null;
            if (control.MultiSelect)
            {
                Type type = typeof(string);
                if (control.SourceTableName.ToUpper().Equals("MED_OPERATION_EXTENDED") || control.SourceTableName.ToUpper().Equals("MED_POSTOPERATIVE_EXTENDED") || control.SourceTableName.ToUpper().Equals("MED_PREOPERATIVE_EXPANSION")
                   || control.SourceTableName.ToUpper().Equals("MED_OPER_ANALGESIC_TOTAL") || control.SourceTableName.ToUpper().Equals("MED_OPER_ANALGESIC_MEDICINE"))
                {
                }
                else
                {
                    type = dataSources[control.SourceTableName.ToUpper()].Columns[control.SourceFieldName].DataType;
                }
                value = AssemblyHelper.GetValueFromString(type, control.Value);
            }
            else
            {
                value = control.SimpleValue;
            }

            SetFieldValue(control.SourceTableName, control.SourceFieldName, value);
        }
        /// <summary>
        /// 界面事件属性设置
        /// </summary>
        /// <param name="control"></param>
        public override void ControlSetting(CustomControl control)
        {
            //    if (!string.IsNullOrEmpty(control.DictTableName) && !ExtendAppContext.CurntSelect.CodeTables.ContainsKey(control.DictTableName.ToUpper()))
            //        throw new NotImplementedException(string.Format("当前上下文缓存中不存在名为{0}的字典表", control.DictTableName.ToUpper()));
            control.ValueChanged += delegate
            {
                base.HasDirty = true;
            };

            if (control.EffectControls.Count > 0)
            {
                control.ValueChanged += new EventHandler(Control_ValueChanged);
                Control_ValueChanged(control, null);
            }
        }

        // 控件改变时要改变属性的项目
        protected void Control_ValueChanged(object sender, EventArgs e)
        {
            CustomControl ctrl = sender as CustomControl;
            List<Control> controls = AttatchDoc.GetControls<Control>();
            foreach (Control control in controls)
            {
                foreach (CustomControl.EffectItem item in ctrl.EffectControls)
                {
                    if (ctrl.EffectUseIndex)
                    {
                        string[] effectNames = item.EffectControlName.Split(',');

                        for (int i = 0; i < ctrl.Controls.Count; i++)
                        {
                            foreach (string ename in effectNames)
                            {
                                string realyName = string.Format(ename, item.StartIndex + i);
                                if (control.Name != realyName)
                                    continue;

                                CheckBox box = ctrl.Controls[i] as CheckBox;
                                bool equal = box.Checked;
                                SetControlProperty(control, item, equal);
                            }
                        }
                    }
                    else
                    {
                        string[] effectNames = item.EffectControlName.Split(',');

                        foreach (string ename in effectNames)
                        {
                            if (control.Name != ename)
                                continue;

                            bool equal = item.EffectValue.Equals(ctrl.SimpleValue);
                            if (!equal && ctrl.MultiSelect && ctrl.Value != null)
                            {
                                if (ctrl.Value.Contains(item.EffectValue + ",") || ctrl.Value.Contains("," + item.EffectValue))
                                    equal = true;
                            }

                            SetControlProperty(control, item, equal);
                        }
                    }
                }
            }
        }

        protected void SetControlProperty(Control control, CustomControl.EffectItem item, bool ValueIsEqual)
        {
            try
            {
                System.Reflection.PropertyInfo[] propterys = control.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo info in propterys)
                {
                    if (info.Name != item.EffectProperty)
                        continue;

                    if (info.CanWrite)
                    {
                        if (ValueIsEqual && item.ItemValidCase != CustomControl.EffectItem.ValidCase.Unequal)
                        {
                            info.SetValue(control, GetTypeValue(item.PropertyValue, info.PropertyType), null);
                        }
                        else if (!ValueIsEqual && item.ItemValidCase != CustomControl.EffectItem.ValidCase.Equal)
                        {
                            info.SetValue(control, GetTypeValue(item.ValueWhileUnequal, info.PropertyType), null);
                        }
                    }
                    break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected object GetTypeValue(string value, Type type)
        {
            if (type.Equals(System.Drawing.Color.Red.GetType()))
            {
                string[] values = value.Split(',');

                System.Drawing.Color color = System.Drawing.Color.FromArgb(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
                return color;
            }

            return Convert.ChangeType(value, type);
        }
    }
}
