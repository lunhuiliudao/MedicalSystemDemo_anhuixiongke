namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;
    using System.ComponentModel;



    /// <summary>
    /// 实体 麻醉事件表
    /// </summary>
    [Table("MED_ANESTHESIA_EVENT")]
    public partial class MED_ANESTHESIA_EVENT : BaseModel
    {
        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 事件序号	;	总的事件序号，按病人一次手术标识排序
        /// </summary>
        [Key]
        public Int32 ITEM_NO { get; set; }
        /// <summary>
        /// 主键 分类事件项目	;	按事件类别排序,大量都是0，只有很少的为1 
        /// </summary>
        [Key]
        public string EVENT_NO { get; set; }
        /// <summary>
        /// 事件类别	;	对应事件类型代码表,MED_EVENT_ITEM_CLASS_DICT
        /// </summary>
        public string EVENT_CLASS_CODE { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        private string _enentItemName;
        public string EVENT_ITEM_NAME
        {
            get { return this._enentItemName; }
            set
            {
                this._enentItemName = value;
                RaisePropertyChanged("EVENT_ITEM_NAME");
            }
        }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string EVENT_ITEM_CODE { get; set; }
        /// <summary>
        /// 项目规格
        /// </summary>
        public string EVENT_ITEM_SPEC { get; set; }
        /// <summary>
        /// 剂量
        /// </summary>
        private Nullable<decimal> _dosage;
        public Nullable<decimal> DOSAGE
        {
            get { return this._dosage; }
            set
            {
                this._dosage = value;
                RaisePropertyChanged("DOSAGE");
            }
        }
        /// <summary>
        /// 剂量单位
        /// </summary>
        private string _dosageUnits;
        public string DOSAGE_UNITS
        {
            get { return this._dosageUnits; }
            set
            {
                this._dosageUnits = value;
                RaisePropertyChanged("DOSAGE_UNITS");
            }
        }
        /// <summary>
        /// 用药途径	;	见用药途径代码表
        /// </summary>
        private string _administrator;
        public string ADMINISTRATOR
        {
            get { return this._administrator; }
            set
            {
                this._administrator = value;
                RaisePropertyChanged("ADMINISTRATOR");
            }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        private Nullable<DateTime> _startTime;
        public Nullable<DateTime> START_TIME
        {
            get { return this._startTime; }
            set
            {
                this._startTime = value;
                RaisePropertyChanged("START_TIME");
            }
        }
        /// <summary>
        /// 结束时间	
        /// </summary>
        private Nullable<DateTime> _endTime;
        public Nullable<DateTime> END_TIME
        {
            get { return this._endTime; }
            set
            {
                this._endTime = value;
                RaisePropertyChanged("END_TIME");
            }
        }
        /// <summary>
        /// 划价标志	;	0 未划价，默认,1 已划价 
        /// </summary>
        private Nullable<Int32> _billIndicator;
        public Nullable<Int32> BILL_INDICATOR
        {
            get { return this._billIndicator; }
            set
            {
                this._billIndicator = value;
                RaisePropertyChanged("BILL_INDICATOR");
            }
        }
        /// <summary>
        /// 持续标志	;	1 持续用药,0 一次性用药  默认
        /// </summary>
        private Nullable<Int32> _durativeIndicator;
        public Nullable<Int32> DURATIVE_INDICATOR
        {
            get { return this._durativeIndicator; }
            set
            {
                this._durativeIndicator = value;
                RaisePropertyChanged("DURATIVE_INDICATOR");
            }
        }
        /// <summary>
        /// 用药方式	;	见用药方式代码表,例如PCA、液体通路等 
        /// </summary>
        public string METHOD { get; set; }
        /// <summary>
        /// 父方式号;EVENT_ITEM_NO	
        /// </summary>
        public Nullable<Int32> METHOD_PARENT_NO { get; set; }
        /// <summary>
        /// 流速
        /// </summary>
        private Nullable<decimal> _performSpeed;
        public Nullable<decimal> PERFORM_SPEED
        {
            get { return this._performSpeed; }
            set
            {
                this._performSpeed = value;
                RaisePropertyChanged("PERFORM_SPEED");
            }
        }
        /// <summary>
        /// 流速单位
        /// </summary>
        private string _speedUnit;
        public string SPEED_UNIT
        {
            get { return this._speedUnit; }
            set
            {
                this._speedUnit = value;
                RaisePropertyChanged("SPEED_UNIT");
            }
        }
        /// <summary>
        /// 父事件序号	;	用于处理浓度、速度变化情况 EVENT_ITEM_NO
        /// </summary>
        public Nullable<Int32> PARENT_ITEM_NO { get; set; }
        /// <summary>
        /// 属性	;	衡液、血安定、贺斯、红细胞、血浆、血小板、其它等
        /// </summary>
        public string EVENT_ATTR { get; set; }
        /// <summary>
        /// 浓度
        /// </summary>
        private Nullable<decimal> _concentration;
        public Nullable<decimal> CONCENTRATION
        {
            get { return this._concentration; }
            set
            {
                this._concentration = value;
                RaisePropertyChanged("CONCENTRATION");
            }
        }
        /// <summary>
        /// 浓度单位
        /// </summary>
        private string _concentrationUnit;
        public string CONCENTRATION_UNIT
        {
            get { return this._concentrationUnit; }
            set
            {
                this._concentrationUnit = value;
                RaisePropertyChanged("CONCENTRATION_UNIT");
            }
        }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public string SUPPLIER_NAME { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public string RESERVED4 { get; set; }

    }
}