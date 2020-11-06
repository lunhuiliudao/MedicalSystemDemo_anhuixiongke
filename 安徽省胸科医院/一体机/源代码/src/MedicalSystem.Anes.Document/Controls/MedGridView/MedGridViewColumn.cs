using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;
using MedicalSystem.Anes.Document.Designer;


namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedGridViewColumn
    {
        public MedGridViewColumn() { }
        public MedGridViewColumn(string dataProperty, string headerText)
            : this()
        {
            _dataProperty = dataProperty;
            _headerText = headerText;
        }
        public MedGridViewColumn(string fieldName):this(fieldName,fieldName)
        {
        }

        private string _headerText;
        [Description("列标题")]
        public string HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                _headerText = value;
            }
        }

        private string _tableName;
        [Description("表名称")]
        [Editor(typeof(TableNamesDropDownEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        private string _dataProperty;
        [Description("字段名称")]
        [Editor(typeof(FieldNamesDropDownEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataProperty
        {
            get
            {
                return _dataProperty;
            }
            set
            {
                _dataProperty = value;
            }
        }

        private int _width = 60;
        [Description("宽度")]
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        private DataGridViewAutoSizeColumnMode _autoSizeMode = DataGridViewAutoSizeColumnMode.None;
        [Description("自动大小模式")]
        public DataGridViewAutoSizeColumnMode AutoSizeMode
        {
            get
            {
                return _autoSizeMode;
            }
            set
            {
                _autoSizeMode = value;
            }
        }

        private bool _readOnly = false;
        [Description("只读")]
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
            }
        }

        private string _dictTableName;
        /// <summary>
        /// 快速录入绑定表名
        /// </summary>
        [Description("字典录入:表名"), Category("数据(自定义)")]
        [Editor(typeof(DictTableNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictTableName
        {
            set
            {
                _dictTableName = value;
            }
            get
            {
                return _dictTableName;
            }
        }

         private string _dictValueFieldName;
       /// <summary>
        /// 快速录入绑定值字段名
        /// </summary>
        [Description("字典录入:值对应字段名"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictValueFieldName
        {
            set
            {
                _dictValueFieldName = value;
            }
            get
            {
                return _dictValueFieldName;
            }
        }

         private string _displayFieldName;
        /// <summary>
        /// 快速录入绑定拼音字段名
        /// </summary>
        [Description("字典录入:显示字段名"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DisplayFieldName
        {
            set
            {
                _displayFieldName = value;
            }
            get
            {
                return _displayFieldName;
            }
        }

        private string _dictWhereString;
        /// <summary>
        /// 快速录入过滤条件
        /// </summary>
        [Description("字典录入:选择项目筛选条件"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictWhereString
        {
            set
            {
                _dictWhereString = value;
            }
            get
            {
                return _dictWhereString;
            }
        }

        private string _format;
        [Description("格式化字串")]
        public string Format
        {
            get
            {
                return _format;
            }
            set
            {
                _format = value;
            }
        }

    }
}
