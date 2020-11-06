using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Designer
{
    public class TableNamesDropDownEditor : ListDropDownEditor
    {
        public TableNamesDropDownEditor()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue("手术信息表", "MED_OPERATION_MASTER"));
            list.Add(new KeyValue("手术信息表扩展表", "MED_OPERATION_MASTER_EXT"));
            list.Add(new KeyValue("患者主表", "MED_PAT_MASTER_INDEX"));
            list.Add(new KeyValue("患者在院记录表", "MED_PATS_IN_HOSPITAL"));
            list.Add(new KeyValue("安全核查表", "MED_SAFETY_CHECKS"));
            list.Add(new KeyValue("麻醉计划表", "MED_ANESTHESIA_PLAN"));
            list.Add(new KeyValue("麻醉计划表检查", "MED_ANESTHESIA_PLAN_EXAM"));
            list.Add(new KeyValue("麻醉计划表病史", "MED_ANESTHESIA_PLAN_PMH"));
            list.Add(new KeyValue("术后恢复记录表", "MED_ANESTHESIA_RECOVER"));
            list.Add(new KeyValue("术后随访记录表", "MED_ANESTHESIA_INQUIRY"));
            list.Add(new KeyValue("住院记录表", "MED_PAT_VISIT"));
            list.Add(new KeyValue("术前扩展表", "MED_PREOPERATIVE_EXPANSION"));
            list.Add(new KeyValue("术中扩展表", "MED_OPERATION_EXTENDED"));
            list.Add(new KeyValue("术后扩展表", "MED_POSTOPERATIVE_EXTENDED"));
            list.Add(new KeyValue("镇痛记录表", "MED_OPERATION_ANALGESIC_MASTER"));
            list.Add(new KeyValue("镇痛药物表", "MED_OPER_ANALGESIC_MEDICINE"));
            list.Add(new KeyValue("镇痛观察表", "MED_OPER_ANALGESIC_TOTAL"));
            list.Add(new KeyValue("风险评估表", "MED_OPER_RISK_ESTIMATE"));
            list.Add(new KeyValue("科室字典表", "MED_DEPT_DICT"));
            list.Add(new KeyValue("人员字典表", "MED_HIS_USERS"));
            list.Add(new KeyValue("麻醉方法字典", "MED_ANESTHESIA_DICT"));
            list.Add(new KeyValue("手术名称字典", "MED_OPERATION_DICT"));
            list.Add(new KeyValue("复苏评分表", "MED_PACU_SORCE"));
            list.Add(new KeyValue("质控信息表", "MED_ANESTHESIA_INPUT_DATA"));
            _dropDownEditorControl = new AliasNamesDropDownEditorControl(list, false);
        }
    }
}
