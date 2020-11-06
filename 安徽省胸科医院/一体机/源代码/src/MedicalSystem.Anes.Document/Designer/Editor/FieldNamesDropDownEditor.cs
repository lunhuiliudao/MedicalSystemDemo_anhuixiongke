using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MedicalSystem.Anes.Document;
using System.Reflection;
using MedicalSystem.AnesWorkStation.Domain;

namespace MedicalSystem.Anes.Document.Designer
{
    public class FieldNamesDropDownEditor : ListDropDownEditor
    {

        public FieldNamesDropDownEditor() : this(false) { }
        public FieldNamesDropDownEditor(bool mulitSelect) : this("TableName", mulitSelect) { }
        public FieldNamesDropDownEditor(string tableNamePropertyName, bool mulitSelect) : this(tableNamePropertyName, mulitSelect, "", "", "") { }
        public FieldNamesDropDownEditor(string tableNamePropertyName, bool mulitSelect, string tableName, string codeFieldName, string nameFieldName)
        {
            MulitSelect = mulitSelect;
            _tableName = tableName;
            _tableNamePropertyName = tableNamePropertyName;
            _nameField = nameFieldName;
            _codeField = codeFieldName;
            _fieldAlias.Add("ITEM_CODE", "编码");
            _fieldAlias.Add("ITEM_NAME", "名称");
        }

        private string _tableNamePropertyName;
        private string _tableName, _codeField, _nameField;
        private Dictionary<string, string> _fieldAlias = new Dictionary<string, string>();

        protected override void SpecialInstance(object instance)
        {
            if (!string.IsNullOrEmpty(_tableName))
            {
                List<KeyValue> list = GetFieldNames(_tableName);
                _dropDownEditorControl = new AliasNamesDropDownEditorControl(list, MulitSelect);
            }
            else
            {
                object obj = instance.GetType().GetProperty(_tableNamePropertyName).GetValue(instance, null);
                if (obj != null)
                {
                    string tableName = obj.ToString();
                    List<KeyValue> list = GetFieldNames(tableName);
                    _dropDownEditorControl = new AliasNamesDropDownEditorControl(list, MulitSelect);
                }
            }
        }

        private string GetFieldAlias(string fieldName)
        {
            if (_fieldAlias.ContainsKey(fieldName))
            {
                return _fieldAlias[fieldName];
            }
            return fieldName;
        }

        private List<KeyValue> GetFieldNames(string tableName)
        {
            List<KeyValue> list = new List<KeyValue>();
            DataTable dataTable = new DataTable();
            if (tableName.ToUpper().Trim().Equals("MED_OPERATION_MASTER"))
            {
                MED_OPERATION_MASTER master = new MED_OPERATION_MASTER();
                foreach (string column in master.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_OPERATION_MASTER_EXT"))
            {
                MED_OPERATION_MASTER_EXT ext = new MED_OPERATION_MASTER_EXT();
                foreach (string column in ext.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_PAT_MASTER_INDEX"))
            {
                MED_PAT_MASTER_INDEX tmp = new MED_PAT_MASTER_INDEX();
                foreach (string column in tmp.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_PATS_IN_HOSPITAL"))
            {
                MED_PATS_IN_HOSPITAL pats = new MED_PATS_IN_HOSPITAL();
                foreach (string column in pats.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_ANESTHESIA_RECOVER"))
            {
                MED_ANESTHESIA_RECOVER tmp = new MED_ANESTHESIA_RECOVER();
                foreach (string column in tmp.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_ANESTHESIA_INQUIRY"))
            {
                MED_ANESTHESIA_INQUIRY tmp = new MED_ANESTHESIA_INQUIRY();
                foreach (string column in tmp.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_SAFETY_CHECKS"))
            {
                MED_SAFETY_CHECKS safety = new MED_SAFETY_CHECKS();
                foreach (string column in safety.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_PAT_VISIT"))
            {
                MED_PAT_VISIT visit = new MED_PAT_VISIT();
                foreach (string column in visit.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_ANESTHESIA_PLAN"))
            {
                MED_ANESTHESIA_PLAN plan = new MED_ANESTHESIA_PLAN();
                foreach (string column in plan.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_ANESTHESIA_PLAN_EXAM"))
            {
                MED_ANESTHESIA_PLAN_EXAM plan = new MED_ANESTHESIA_PLAN_EXAM();
                foreach (string column in plan.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_ANESTHESIA_PLAN_PMH"))
            {
                MED_ANESTHESIA_PLAN_PMH plan = new MED_ANESTHESIA_PLAN_PMH();
                foreach (string column in plan.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_HIS_USERS"))
            {
                MED_HIS_USERS users = new MED_HIS_USERS();
                foreach (string column in users.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_DEPT_DICT"))
            {
                MED_DEPT_DICT dept = new MED_DEPT_DICT();
                foreach (string column in dept.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_DIAGNOSIS_DICT"))
            {
                MED_DIAGNOSIS_DICT dept = new MED_DIAGNOSIS_DICT();
                foreach (string column in dept.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_OPERATION_DICT"))
            {
                MED_OPERATION_DICT dept = new MED_OPERATION_DICT();
                foreach (string column in dept.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_ANESTHESIA_DICT"))
            {
                MED_ANESTHESIA_DICT dept = new MED_ANESTHESIA_DICT();
                foreach (string column in dept.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_OPERATING_ROOM"))
            {
                MED_OPERATING_ROOM dept = new MED_OPERATING_ROOM();
                foreach (string column in dept.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_PREOPERATIVE_EXPANSION"))
            {
                MED_PREOPERATIVE_EXPANSION row = new MED_PREOPERATIVE_EXPANSION();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_OPERATION_EXTENDED"))
            {
                MED_OPERATION_EXTENDED row = new MED_OPERATION_EXTENDED();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_POSTOPERATIVE_EXTENDED"))
            {
                MED_POSTOPERATIVE_EXTENDED row = new MED_POSTOPERATIVE_EXTENDED();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_PACU_SORCE")) 
            {
                MED_PACU_SORCE row = new MED_PACU_SORCE();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_OPERATION_ANALGESIC_MASTER"))
            {
                MED_OPERATION_ANALGESIC_MASTER row = new MED_OPERATION_ANALGESIC_MASTER();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_OPER_ANALGESIC_MEDICINE"))
            {
                MED_OPER_ANALGESIC_MEDICINE row = new MED_OPER_ANALGESIC_MEDICINE();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_OPER_ANALGESIC_TOTAL"))
            {
                MED_OPER_ANALGESIC_TOTAL row = new MED_OPER_ANALGESIC_TOTAL();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_OPER_RISK_ESTIMATE"))
            {
                MED_OPER_RISK_ESTIMATE row = new MED_OPER_RISK_ESTIMATE();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_ANESTHESIA_INPUT_DICT"))
            {
                MED_ANESTHESIA_INPUT_DICT row = new MED_ANESTHESIA_INPUT_DICT();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            else if (tableName.ToUpper().Trim().Equals("MED_ANESTHESIA_INPUT_DATA"))
            {
                MED_ANESTHESIA_INPUT_DATA row = new MED_ANESTHESIA_INPUT_DATA();
                foreach (string column in row.GetPropsName())
                {
                    list.Add(new KeyValue(GetFieldAlias(column), column));
                }
            }
            if (!string.IsNullOrEmpty(_tableName))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(new KeyValue(row[_codeField].ToString(), row[_nameField].ToString()));
                }
            }
            else
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    list.Add(new KeyValue(GetFieldAlias(column.ColumnName), column.ColumnName));
                }
            }
            return list;
        }
    }
}
