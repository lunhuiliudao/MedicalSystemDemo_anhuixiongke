using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using MedicalSystem.Anes.Document.Designer;
using System.Drawing.Design;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedSheetRow
    {
        private string _celerityInputTableName = string.Empty;
        private string _celerityInputValueColumnName = string.Empty;
        private string _celerityInputCodeColumnName = string.Empty;
        private string _celerityInputSqlWhere = string.Empty;


        private bool _isgdShow = true;
        [DisplayName("是否固定显示")]
        public bool IsGdShow
        {
            get
            {
                return _isgdShow;
            }
            set
            {
                _isgdShow = value;
            }
        }


        private string _title = "";
        [DisplayName("体症标题")]
        public string Title
        {
            get
            {
                return GetLineString(_title);
            }
            set
            {
                _title = GetLineString(value);
            }
        }

        List<MedSheetCell> _cells = new List<MedSheetCell>();
        [DisplayName("单元格")]
        public List<MedSheetCell> Cells
        {
            get
            {
                return _cells;
            }
            set
            {
                _cells = value;
            }
        }

        //2013-12-11 周青 监测项目个性化设置
        /// <summary>
        /// 颜色
        /// </summary>
        private Color _color = Color.Black;
        [DisplayName("颜色")]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        private MedShowTimeInterval _showTimeInterval = MedShowTimeInterval.Fifiteen;
        [DisplayName("显示的时间简隔")]
        public MedShowTimeInterval ShowTimeInterval
        {
            get
            {
                return _showTimeInterval;
            }
            set
            {
                _showTimeInterval = value;
            }
        }

        private string _itemCode = string.Empty;
        [DisplayName("体症编码")]
        public string ItemCode
        {
            get
            {
                return _itemCode;
            }
            set
            {
                _itemCode = value;
            }
        }

        private string GetLineString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            else
            {
                return text.Replace(@"\r\n", "\r\n");
            }
        }


        [DisplayName("字典表名称"), Description("字典录入:表名"), Category("数据(自定义)")]
        [Editor(typeof(DictTableNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictTableName
        {
            set
            {
                _celerityInputTableName = value;
            }
            get
            {
                return _celerityInputTableName;
            }
        }


        [DisplayName("字典字段名称"), Description("字典录入:值对应字段名"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictValueFieldName
        {
            set
            {
                _celerityInputValueColumnName = value;
            }
            get
            {
                return _celerityInputValueColumnName;
            }
        }



        [DisplayName("字典显示字段名称"), Description("字典录入:显示字段名"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DisplayFieldName
        {
            set
            {
                _celerityInputCodeColumnName = value;
            }
            get
            {
                return _celerityInputCodeColumnName;
            }
        }


        [DisplayName("字典录入筛选条件"), Description("字典录入:选择项目筛选条件"), Category("数据(自定义)")]
        [Editor(typeof(DictFieldNamesDropDownEditor), typeof(UITypeEditor))]
        public string DictWhereString
        {
            set
            {
                _celerityInputSqlWhere = value;
            }
            get
            {
                return _celerityInputSqlWhere;
            }
        }
    }
}
