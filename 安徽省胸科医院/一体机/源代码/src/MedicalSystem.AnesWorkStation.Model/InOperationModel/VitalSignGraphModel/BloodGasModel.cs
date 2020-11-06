// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      BloodGasModel.cs
// 功能描述(Description)：    血气分析功能包含的血气明细实体类，未被使用，是从麻醉5.0移植过来的
//                            一体机中的血气实体是直接使用对应的数据库实体类：MED_BLOOD_GAS_MASTER、MED_BLOOD_GAS_DETAIL
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 血气明细
    /// </summary>
    public class BloodGasDetail
    {
        #region 属性
        /// <summary>
        /// 血气标识
        /// </summary>
        private string detailId;

        public string DetailId
        {
            get { return detailId; }
            set { detailId = value; }
        }
        /// <summary>
        /// 血气CODE
        /// </summary>
        private string bloodGasCode;

        public string BloodGasCode
        {
            get { return bloodGasCode; }
            set { bloodGasCode = value; }
        }
        /// <summary>
        /// 血气名称
        /// </summary>
        private string bloodGasName;

        public string BloodGasName
        {
            get
            {
                if (string.IsNullOrEmpty(bloodGasName))
                {
                    return BloodGasCode;
                }
                else
                {
                    return bloodGasName;
                }
            }
            set { bloodGasName = value; }
        }
        /// <summary>
        /// 血气值
        /// </summary>
        private string bloodGasValue;

        public string BloodGasValue
        {
            get { return bloodGasValue; }
            set { bloodGasValue = value; }
        }
        /// <summary>
        /// 操作者
        /// </summary>
        private string oper;

        public string Oper
        {
            get { return oper; }
            set { oper = value; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime operdate;

        public DateTime Operdate
        {
            get { return operdate; }
            set { operdate = value; }
        }
        #endregion 属性
    }
    public class BloodGasModel : ObservableObject
    {
        #region 属性
        /// <summary>
        ///相关ID
        /// </summary>
        private string patientId;

        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }
        /// <summary>
        ///相关ID
        /// </summary>
        private int vistId;

        public int VistId
        {
            get { return vistId; }
            set { vistId = value; }
        }
        /// <summary>
        ///相关ID
        /// </summary>
        private int operId;

        public int OperId
        {
            get { return operId; }
            set { operId = value; }
        }
        /// <summary>
        ///记录时间
        /// </summary>
        private DateTime recorddate;

        public DateTime Recorddate
        {
            get { return recorddate; }
            set { recorddate = value; }
        }
        /// <summary>
        ///操作时间
        /// </summary>
        private DateTime operdate;

        public DateTime Operdate
        {
            get { return operdate; }
            set { operdate = value; }
        }
        /// <summary>
        ///明细ID
        /// </summary>
        private string detailId;

        public string DetailId
        {
            get { return detailId; }
            set { detailId = value; }
        }
        /// <summary>
        ///操作者
        /// </summary>
        private string oper;

        public string Oper
        {
            get { return oper; }
            set { oper = value; }
        }
        /// <summary>
        ///明细
        /// </summary>
        private List<BloodGasDetail> details = new List<BloodGasDetail>();

        public List<BloodGasDetail> Details
        {
            get { return details; }
            set { details = value; }
        }
        /// <summary>
        ///显示名称
        /// </summary>
        private string _diaplayName = "";
        public string DisplayName
        {
            get
            {
                return _diaplayName;
            }
            set
            {
                _diaplayName = value;
            }
        }
        #endregion 属性
    }
}
