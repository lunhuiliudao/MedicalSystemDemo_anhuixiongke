using System;
namespace MedicalSytem.Soft.Model
{
    /// <summary>
    ///MedVsHisOperationSchedule
    /// </summary>
    [Serializable]
    public class MedVsHisOperationSchedule
    {
        #region define variable
        private string _medpatientId;
        private decimal _medvisitId;
        private decimal _medscheduleId;
        private string _hispatientId;
        private string _hisvisitId;
        private string _hisscheduleId;
        private DateTime _scheduledDateTime;
        private string _operatingRoom = String.Empty;
        private string _operatingRoomNo = String.Empty;
        private string _operationName;
        private decimal _sequence;
        private string _surgeon = String.Empty;
        private string _anesthesiaMethod = String.Empty;
        private string _anesthesiaDoctor = String.Empty;
        private string _anesthesiaAssistant = String.Empty;
        private string _firstAssistant = string.Empty;
        private string _firstOperationNurse = String.Empty;
        private string _firstSupplyNurse = String.Empty;
        private decimal _state;
        private DateTime _cratedate;
        private DateTime _alterdate;
        private string _reserved1 = String.Empty;
        private string _reserved2 = String.Empty;
        private string _reserved3 = String.Empty;
        private string _reserved4 = String.Empty;
        private string _reserved5 = String.Empty;
        private string _reserved6 = String.Empty;
        #endregion

        ///<summary>
        ///病人标识号;唯一确定手术病人，非空
        ///</summary>
        public string MedPatientId
        {
            get { return _medpatientId; }
            set { _medpatientId = value; }
        }

        ///<summary>
        ///病人本次住院标识;对门诊病人为0
        ///</summary>
        public decimal MedVisitId
        {
            get { return _medvisitId; }
            set { _medvisitId = value; }
        }

        ///<summary>
        ///手术安排标识;针对一个病人一次住院同时预约的多次手术，从1开始分配。每次预约时，在该表中取病人预约手术的最大标识数，加1作为本次标识。如果未找到该病人在本表中的预约记录，标识为1
        ///</summary>
        public decimal MedScheduleId
        {
            get { return _medscheduleId; }
            set { _medscheduleId = value; }
        }

        public string HisPatientId
        {
            get { return _hispatientId; }
            set { _hispatientId = value; }
        }

        ///<summary>
        ///His病人本次住院标识
        ///</summary>
        public string HisVisitId
        {
            get { return _hisvisitId; }
            set { _hisvisitId = value; }
        }

        ///<summary>
        ///His手术安排标识
        ///</summary>
        public string HisScheduleId
        {
            get { return _hisscheduleId; }
            set { _hisscheduleId = value; }
        }

        ///<summary>
        ///手术日期及时间;预约手术日期及时间，非空
        ///</summary>
        public DateTime ScheduledDateTime
        {
            get { return _scheduledDateTime; }
            set { _scheduledDateTime = value; }
        }

        ///<summary>
        ///手术室;手术室科室代码
        ///</summary>
        public string OperatingRoom
        {
            get { return _operatingRoom; }
            set { _operatingRoom = value; }
        }

        ///<summary>
        ///手术间;手术间号，由手术室分配
        ///</summary>
        public string OperatingRoomNo
        {
            get { return _operatingRoomNo; }
            set { _operatingRoomNo = value; }
        }

        ///<summary>
        ///台次;表示上述同一个手术间的手术台次，由手术室分配
        ///</summary>
        public decimal Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }

     
        ///<summary>
        ///手术者;手术医师姓名
        ///</summary>
        public string Surgeon
        {
            get { return _surgeon; }
            set { _surgeon = value; }
        }

        ///<summary>
        ///第一手术助手;第一手术助手姓名
        ///</summary>
        public string FirstAssistant
        {
            get { return _firstAssistant; }
            set { _firstAssistant = value; }
        }

     
        ///<summary>
        ///麻醉方法;使用规范名称，见4.18麻醉方法字典
        ///</summary>
        public string AnesthesiaMethod
        {
            get { return _anesthesiaMethod; }
            set { _anesthesiaMethod = value; }
        }

        ///<summary>
        ///麻醉医师;麻醉医师姓名
        ///</summary>
        public string AnesthesiaDoctor
        {
            get { return _anesthesiaDoctor; }
            set { _anesthesiaDoctor = value; }
        }

        ///<summary>
        ///麻醉助手;麻醉助手姓名
        ///</summary>
        public string AnesthesiaAssistant
        {
            get { return _anesthesiaAssistant; }
            set { _anesthesiaAssistant = value; }
        }

        ///<summary>
        ///第一台上护士;护士姓名
        ///</summary>
        public string FirstOperationNurse
        {
            get { return _firstOperationNurse; }
            set { _firstOperationNurse = value; }
        }

        ///<summary>
        ///第一供应护士;护士姓名
        ///</summary>
        public string FirstSupplyNurse
        {
            get { return _firstSupplyNurse; }
            set { _firstSupplyNurse = value; }
        }

        public DateTime CreateDate
        {
            get{return _cratedate;}
            set{_cratedate = value;}
        }
        public DateTime AlterDate
        {
            get{return _alterdate;}
            set{_alterdate = value;}
        }
        ///<summary>
        ///HIS使用 SCHEDULE_ID 手术申请号 把SCHEDULE_ID INT化以后的STRING(有可能是变化的)（HIS）
        ///</summary>
        public string Reserved1
        {
            get { return _reserved1; }
            set { _reserved1 = value; }
        }

        ///<summary>
        ///手术状态 N－ 新申请手术   G－ 手术麻醉系统已提取 M－ 手术信息变化  C－ 手术取消   F－ 手术结束
        ///</summary>
        public string Reserved2
        {
            get { return _reserved2; }
            set { _reserved2 = value; }
        }

        ///<summary>
        /// 保留字段3 福建协和医院 感染信息
        ///</summary>
        public string Reserved3
        {
            get { return _reserved3; }
            set { _reserved3 = value; }
        }

        ///<summary>
        /// HIS使用 VISIT_ID 病人次数 字符串类型 STRING（HIS）
        ///</summary>
        public string Reserved4
        {
            get { return _reserved4; }
            set { _reserved4 = value; }
        }

        ///<summary>
        /// HIS使用 SCHEDULE_ID 手术申请号 字符串类型 STRING（HIS）
        ///</summary>
        public string Reserved5
        {
            get { return _reserved5; }
            set { _reserved5 = value; }
        }

        ///<summary>
        /// 保留字段6--VARCHAR2(20) 北京航天中心医院 WEIGHT
        ///</summary>
        public string Reserved6
        {
            get { return _reserved6; }
            set { _reserved6 = value; }
        }

      
        ///<summary>
        ///手术名称OperationName
        ///</summary>
        public string OperationName
        {
            get { return _operationName; }
            set { _operationName = value; }
        }
        ///<summary>
        ///手术名称State
        ///</summary>
        public decimal State
        {
            get { return _state; }
            set { _state = value; }
        }      
    }
}
