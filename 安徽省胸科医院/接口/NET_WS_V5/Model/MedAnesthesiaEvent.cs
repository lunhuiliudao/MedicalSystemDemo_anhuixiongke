using System;
using System.Collections.Generic;
using System.Text;


//**2012 年 9月 10 日  ADD 
namespace MedicalSytem.Soft.Model
{
    /// <summary>
    /// med_anesthesia_event
    /// </summary>
    [Serializable]
    public class MedAnesthesiaEvent
    {
        #region define variable
        private string _patientId;
        private decimal _visitId;
		private decimal _operId;
        private decimal _itemNo;
        private string _itemClass = string.Empty;
        private decimal _eventNo;
        private string _itemName = string.Empty;
        private string _itemCode = string.Empty;
        private string _itemSpec = string.Empty;
        private string _dosageUnits = string.Empty;
        private decimal _dosage;//number(8,4)
        private string _administrator = string.Empty;
        private DateTime _startTime;
        private DateTime _endDate;
        private decimal _billIndicator;
        private decimal _durativeIndicator;
        private string _method = string.Empty;
        private decimal _performSpeed;//number(8,4);
        private string _speedUnit = string.Empty;
        private decimal _parentItemNo;
        private string _eventAttr = string.Empty;
        private decimal _concentration;//number(8,4)
        private string _concetrationUnit = string.Empty;
        private decimal _billAttr;
        private string _supplierName = string.Empty;
        private decimal _methodParentNo;
        #endregion


        #region public property

        public string PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }
        public decimal VisitId
        {
            get { return _visitId; }
            set { _visitId = value; }
        }
        public decimal OperId
        {
            get { return _operId; }
            set { _operId = value; }
        }
        /// <summary>
        /// 事件序号
        /// </summary>
        public decimal ItemNo
        {
            get { return _itemNo; }
            set { _itemNo = value; }
        }
        /// <summary>
        /// 事件类别，1-事件、2-麻醉用药、3-输液、4-输氧、5-手术、6-麻醉、7-置管、8-拔管、9-辅助呼吸、A-控制呼吸、B-输血、0-数据修改，T-ACT
        /// </summary>
        public string ItemClass
        {
            get { return _itemClass; }
            set { _itemClass = value; }
        }
        /// <summary>
        /// 分类事件项目
        /// </summary>
        public decimal EventNo
        {
            get { return _eventNo; }
            set { _eventNo = value; }
        }
        /// <summary>
        /// 事件名称
        /// </summary>
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        /// <summary>
        /// 事件代码
        /// </summary>
        public string ItemCode
        {
            get { return _itemCode; }
            set { _itemCode = value; }
        }
        /// <summary>
        /// 事件规格
        /// </summary>
        public string ItemSpec
        {
            get { return _itemSpec; }
            set { _itemSpec = value; }

        }
        /// <summary>
        /// 剂量单位
        /// </summary>
        public string DosageUnits
        {
            get { return _dosageUnits; }
            set { _dosageUnits = value; }
        }
        /// <summary>
        /// 剂量
        /// </summary>
        public decimal Dosage
        {
            get { return _dosage; }
            set { _dosage = value; }
        }
        /// <summary>
        /// 用药途径
        /// </summary>
        public string Administrator
        {
            get { return _administrator; }
            set { _administrator = value; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        /// <summary>
        /// 划价标志
        /// </summary>
        public decimal BillIndicator
        {
            get { return _billIndicator; }
            set { _billIndicator = value; }
        }
        /// <summary>
        /// 持续/一次性标志，1-持续
        /// </summary>
        public decimal DurativeIndicator
        {
            get { return _durativeIndicator; }
            set { _durativeIndicator = value; }
        }
        /// <summary>
        /// 方式
        /// </summary>
        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }
        /// <summary>
        /// 流速
        /// </summary>
        public decimal PerformSpeed
        {
            get { return _performSpeed; }
            set { _performSpeed = value; }
        }
        /// <summary>
        /// 
        /// 流速单位
        /// </summary>
        public string SpeedUnit
        {
            get { return _speedUnit; }
            set { _speedUnit = value; }
        }
        /// <summary>
        /// 父事件号
        /// </summary>
        public decimal ParentItemNo
        {
            get { return _parentItemNo; }
            set { _parentItemNo = value; }
        }
        /// <summary>
        /// 属性
        /// </summary>
        public string EventAttr
        {
            get { return _eventAttr; }
            set { _eventAttr = value; }
        }
        /// <summary>
        /// 浓度
        /// </summary>
        public decimal Concentration
        {
            get { return _concentration; }
            set { _concentration = value; }
        }
        /// <summary>
        /// 浓度单位
        /// </summary>
        public string ConcetrationUnit
        {
            get { return _concetrationUnit; }
            set { _concetrationUnit = value; }
        }
        /// <summary>
        /// 收费类别。1-麻醉，2-手术，其它不收费
        /// </summary>
        public decimal BillAttr
        {
            get { return _billAttr; }
            set { _billAttr = value; }
        }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }
        /// <summary>
        /// 父方式号
        /// </summary>
        public decimal MethodParentNo
        {
            get { return _methodParentNo; }
            set { _methodParentNo = value; }
        }
        #endregion



    }
}
