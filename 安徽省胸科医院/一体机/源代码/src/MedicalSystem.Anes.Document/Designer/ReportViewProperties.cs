/*----------------------------------------------------------------
      // Copyright (C) 2010 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：ReportViewProperties.cs
      // 文件功能描述：报表控件属性配置保存类
      //
      // 
      // 修改标识：戴呈祥-2010-06-01
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Designer
{
    /// <summary>
    /// 报表控件属性配置保存类
    /// </summary>
    [ToolboxItem(false), Description("报表控件")]
    public class ReportViewProperties : Component
    {
        public ReportViewProperties() {}

        //private string _whereString;
        //[Description("查询条件")]
        //public string WhereString
        //{
        //    get
        //    {
        //        return _whereString;
        //    }
        //    set
        //    {
        //        _whereString = value;
        //    }
        //}

        //private List<KeyValue> _defaultRowValues = new List<KeyValue>();
        //[Description("字段默认值")]
        //public List<KeyValue> DefaultRowValues
        //{
        //    get
        //    {
        //        return _defaultRowValues;
        //    }
        //    set
        //    {
        //        _defaultRowValues = value;
        //    }
        //}

        private bool _landscape = false;
        [Description("横向打印")]
        public bool Landscape
        {
            get
            {
                return _landscape;
            }
            set
            {
                _landscape = value;
            }
        }

        private float _pageWidth = 0;
        [Description("纸张宽度，如果为0则取默认宽度"), DisplayName("纸张宽度")]
        public float PageWidth
        {
            get
            {
                return _pageWidth;
            }
            set
            {
                if (value >= 0)
                {
                    _pageWidth = value;
                }
            }
        }

        private int _height = 100;
        [DisplayName("高度")]
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        private int _width = 100;
        [DisplayName("宽度")]
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

        private float _showZoomRate = 1f;
        [DisplayName("显示比例")]
        public float ShowZoomRate
        {
            get
            {
                return _showZoomRate;
            }
            set
            {
                _showZoomRate = value;
            }
        }
        private int _leftMarginOffset = 0;
        [DisplayName("左边距Margin位置")]
        public int LeftMarginOffset
        {
            get
            {
                return _leftMarginOffset;
            }
            set
            {
                _leftMarginOffset = value;
            }

        }

        private int _rightMarginOffset = 0;
        [DisplayName("右边距Margin位置")]
        public int RightMarginOffset
        {
            get
            {
                return _rightMarginOffset;
            }
            set
            {
                _rightMarginOffset = value;
            }
        }

        private int _topMarginOffset = 0;
        [DisplayName("顶部边距Margin位置")]
        public int TopMarginOffset
        {
            get
            {
                return _topMarginOffset;
            }
            set
            {
                _topMarginOffset = value;
            }
        }

        private int _bottomMarginOffset = 0;
        [DisplayName("底部边距Margin位置")]
        public int BottomMarginOffset
        {
            get
            {
                return _bottomMarginOffset;
            }
            set
            {
                _bottomMarginOffset = value;
            }
        }

    }
}
