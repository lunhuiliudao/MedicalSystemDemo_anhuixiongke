
using System;
namespace MedicalSytem.Soft.Model
{
    /// <summary>
    /// 收费记录对照表
    /// </summary>
    [Serializable]
    public class MedVsHisOperBillItems
    {
        #region define variable
        private string _medPatientId;
        private decimal _medVisitId;
        private decimal _medOperId;
        private string _hisPatientId = String.Empty;
        private string _hisVisitId = String.Empty;
        private decimal _hisScheduleId;
        private decimal _itemNo;
        private string _itemClass = String.Empty;
        private string _itemName = String.Empty;
        private string _itemCode = String.Empty;
        private string _itemSpec = String.Empty;
        private decimal _amount;
        private string _units = String.Empty;
        private DateTime _createdate;
        private string _reserved01 = String.Empty;
        private string _reserved02 = String.Empty;
        private string _reserved03 = String.Empty;
        private string _reserved04 = String.Empty;
        private string _reserved05 = String.Empty;
        #endregion

        #region public property
        ///<summary>
        ///病人ID
        ///</summary>
        public string MedPatientId
        {
            get { return _medPatientId; }
            set { _medPatientId = value; }
        }

        ///<summary>
        ///病人住院标识
        ///</summary>
        public decimal MedVisitId
        {
            get { return _medVisitId; }
            set { _medVisitId = value; }
        }

        ///<summary>
        ///手术申请号
        ///</summary>
        public decimal MedOperId
        {
            get { return _medOperId; }
            set { _medOperId = value; }
        }


        ///<summary>
        ///病人ID（HIS）
        ///</summary>
        public string HisPatientId
        {
            get { return _hisPatientId; }
            set { _hisPatientId = value; }
        }

        ///<summary>
        ///病人住院标识（HIS）
        ///</summary>
        public string HisVisitId
        {
            get { return _hisVisitId; }
            set { _hisVisitId = value; }
        }

        ///<summary>
        ///手术申请号（HIS备用）
        ///</summary>
        public decimal HisScheduleId
        {
            get { return _hisScheduleId; }
            set { _hisScheduleId = value; }
        }

        ///<summary>
        ///记录时间
        ///</summary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// 收费序号
        /// </summary>
        public decimal ItemNo
        {
            get { return _itemNo; }
            set { _itemNo = value; }
        }

        ///<summary>
        ///收费类别
        ///</summary>
        public string ItemClass
        {
            get { return _itemClass; }
            set { _itemClass = value; }
        }

        ///<summary>
        ///收费名称
        ///</summary>
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        ///<summary>
        ///收费编码
        ///</summary>
        public string ItemCode
        {
            get { return _itemCode; }
            set { _itemCode = value; }
        }

        ///<summary>
        ///收费规格
        ///</summary>
        public string ItemSpec
        {
            get { return _itemSpec; }
            set { _itemSpec = value; }
        }

        ///<summary>
        ///收费数量
        ///</summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        ///<summary>
        ///收费单位
        ///</summary>
        public string Units
        {
            get { return _units; }
            set { _units = value; }
        }

        ///<summary>
        ///备用字段1
        ///</summary>
        public string Reserved01
        {
            get { return _reserved01; }
            set { _reserved01 = value; }
        }

        ///<summary>
        ///备用字段2
        ///</summary>
        public string Reserved02
        {
            get { return _reserved02; }
            set { _reserved02 = value; }
        }


        ///<summary>
        ///备用字段3
        ///</summary>
        public string Reserved03
        {
            get { return _reserved03; }
            set { _reserved03 = value; }
        }

        ///<summary>
        ///备用字段4
        ///</summary>
        public string Reserved04
        {
            get { return _reserved04; }
            set { _reserved04 = value; }
        }

        ///<summary>
        ///备用字段5
        ///</summary>
        public string Reserved05
        {
            get { return _reserved05; }
            set { _reserved05 = value; }
        }


        #endregion
     
    }
}
