using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 给药途径代码表
    /// </summary>
    [Table("MED_ANESTHESIA_EVENT_TEMPLET")]
    public partial class MED_ANESTHESIA_EVENT_TEMPLET : BaseModel
    {
        private string _templet_name;
        private string _create_by = "公共";
        private string _templet_class = "0";
        private string _anesthesia_method = "*";
        private string _event_item_class;
        private int _event_item_no;
        private string _event_item_name;
        private string _event_item_code;
        private string _event_item_spec;
        private decimal? _dosage;
        private string _dosage_units;
        private string _administrator;
        private int? _durative_indicator = 0;
        private string _method;
        private int? _method_parent_no;
        private decimal? _perform_speed;
        private string _speed_unit;
        private decimal? _concentration;
        private string _concentration_unit;
        private string _event_attr;
        private decimal _start_after_input = 0M;
        private decimal? _durative;
        private int? _parent_item_no;
        private int? _bill_attr;
        /// <summary>
        /// 模板名称
        /// </summary>
        public string TEMPLET_NAME
        {
            set { _templet_name = value; }
            get { return _templet_name; }
        }
        /// <summary>
        /// 模板所有者	;	默认“公共”  
        /// </summary>
        public string CREATE_BY
        {
            set { _create_by = value; }
            get { return _create_by; }
        }
        /// <summary>
        /// 模板类别	;	1/PACU、2/手术室、0/通用，默认0 
        /// </summary>
        public string TEMPLET_CLASS
        {
            set { _templet_class = value; }
            get { return _templet_class; }
        }
        /// <summary>
        /// 麻醉方法	;	* - 通用，默认*
        /// </summary>
        public string ANESTHESIA_METHOD
        {
            set { _anesthesia_method = value; }
            get { return _anesthesia_method; }
        }
        /// <summary>
        /// 事件类别
        /// </summary>
        public string EVENT_ITEM_CLASS
        {
            set { _event_item_class = value; }
            get { return _event_item_class; }
        }
        /// <summary>
        /// 项目序号
        /// </summary>
        public int EVENT_ITEM_NO
        {
            set { _event_item_no = value; }
            get { return _event_item_no; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string EVENT_ITEM_NAME
        {
            set { _event_item_name = value; }
            get { return _event_item_name; }
        }
        /// <summary>
        /// 代码
        /// </summary>
        public string EVENT_ITEM_CODE
        {
            set { _event_item_code = value; }
            get { return _event_item_code; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string EVENT_ITEM_SPEC
        {
            set { _event_item_spec = value; }
            get { return _event_item_spec; }
        }
        /// <summary>
        /// 剂量
        /// </summary>
        public decimal? DOSAGE
        {
            set { _dosage = value; }
            get { return _dosage; }
        }
        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DOSAGE_UNITS
        {
            set { _dosage_units = value; }
            get { return _dosage_units; }
        }
        /// <summary>
        /// 用药途径
        /// </summary>
        public string ADMINISTRATOR
        {
            set { _administrator = value; }
            get { return _administrator; }
        }
        /// <summary>
        /// 持续/一次性标志	;	0 默认一次性用药；1-持续
        /// </summary>
        public int? DURATIVE_INDICATOR
        {
            set { _durative_indicator = value; }
            get { return _durative_indicator; }
        }
        /// <summary>
        /// 方式	;	例如PCA等
        /// </summary>
        public string METHOD
        {
            set { _method = value; }
            get { return _method; }
        }
        /// <summary>
        /// 父方式号
        /// </summary>
        public int? METHOD_PARENT_NO
        {
            set { _method_parent_no = value; }
            get { return _method_parent_no; }
        }
        /// <summary>
        /// 流速	;	输液滴入速度
        /// </summary>
        public decimal? PERFORM_SPEED
        {
            set { _perform_speed = value; }
            get { return _perform_speed; }
        }
        /// <summary>
        /// 流速单位
        /// </summary>
        public string SPEED_UNIT
        {
            set { _speed_unit = value; }
            get { return _speed_unit; }
        }
        /// <summary>
        /// 浓度	
        /// </summary>
        public decimal? CONCENTRATION
        {
            set { _concentration = value; }
            get { return _concentration; }
        }
        /// <summary>
        /// 浓度单位	
        /// </summary>
        public string CONCENTRATION_UNIT
        {
            set { _concentration_unit = value; }
            get { return _concentration_unit; }
        }
        /// <summary>
        /// 属性
        /// </summary>
        public string EVENT_ATTR
        {
            set { _event_attr = value; }
            get { return _event_attr; }
        }
        /// <summary>
        /// 距离录入的时间间隔
        /// </summary>
        public decimal START_AFTER_INPUT
        {
            set { _start_after_input = value; }
            get { return _start_after_input; }
        }
        /// <summary>
        /// 持续时间
        /// </summary>
        public decimal? DURATIVE
        {
            set { _durative = value; }
            get { return _durative; }
        }
        /// <summary>
        /// 父事件序号	;	用于处理浓度、速度变化情况
        /// </summary>
        public int? PARENT_ITEM_NO
        {
            set { _parent_item_no = value; }
            get { return _parent_item_no; }
        }
        /// <summary>
        /// 收费属性	
        /// </summary>
        public int? BILL_ATTR
        {
            set { _bill_attr = value; }
            get { return _bill_attr; }
        }
    }

    public partial class MED_TEMPLET_MENU
    {
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public String ANESTHESIA_METHOD { get; set; }

        /// <summary>
        /// 模版名称
        /// </summary>
        public string TEMPLET_NAME { get; set; }
    }
}
