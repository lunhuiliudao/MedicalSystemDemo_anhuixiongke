// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      PACUQueryModel.cs
// 功能描述(Description)：    PACU查询功能对应的患者信息
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

namespace MedicalSystem.AnesWorkStation.Model.PACUQueryModel
{
    /// <summary>
    /// PACU功能
    /// </summary>
    public class PACUQueryModel
    {
        private string _BED_NO;
        private string _PATIENT_ID;
        private string _NAME;
        private string _SEX;
        private string _AGE;
        private string _OPERATION_NAME;
        private string _PACU_TIME_RANGE;
        
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO
        {
            get
            {
                return _BED_NO;
            }
            set
            {
                _BED_NO = value;
            }
        }

        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID
        {
            get { return _PATIENT_ID; }
            set { _PATIENT_ID = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string SEX
        {
            get { return _SEX; }
            set { _SEX = value; }
        }

        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME
        {
            get { return _OPERATION_NAME; }
            set { _OPERATION_NAME = value; }
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public string AGE
        {
            get { return _AGE; }
            set { _AGE = value; }
        }
       
        /// <summary>
        /// 复苏时长
        /// </summary>
        public string PACU_TIME_RANGE
        {
            get { return _PACU_TIME_RANGE; }
            set { _PACU_TIME_RANGE = value; }
        }
    }
}
