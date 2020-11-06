using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Designer
{
    public class DictTableNamesDropDownEditor : ListDropDownEditor
    {
        public DictTableNamesDropDownEditor()
        {
            _dropDownEditorControl = new AliasNamesDropDownEditorControl(Tables, false);
        }

        public static List<KeyValue> Tables
        {
            get
            {
                List<KeyValue> list = new List<KeyValue>();
                list.Add(new KeyValue("麻醉通用项目字典表", "MED_ANESTHESIA_INPUT_DICT"));
                list.Add(new KeyValue("诊断字典表", "MED_DIAGNOSIS_DICT"));
                list.Add(new KeyValue("手术名称字典表", "MED_OPERATION_DICT"));
                list.Add(new KeyValue("医护人员字典表", "MED_HIS_USERS"));
                list.Add(new KeyValue("麻醉方法字典表", "MED_ANESTHESIA_DICT"));
                list.Add(new KeyValue("科室字典", "MED_DEPT_DICT"));
                list.Add(new KeyValue("手术间字典表", "MED_OPERATING_ROOM"));
                list.Add(new KeyValue("采集项目字典表", "MED_MONITOR_FUNCTION_CODE"));
                list.Add(new KeyValue("药品字典表", "MED_EVENT_DICT"));
                list.Add(new KeyValue("血气字典表", "MED_BLOOD_GAS_DICT"));
                list.Add(new KeyValue("单位字典表", "MED_UNIT_DICT"));
                list.Add(new KeyValue("途径字典表", "MED_ADMINISTRATION_DICT"));
                return list;
            }
        }
    }
}
