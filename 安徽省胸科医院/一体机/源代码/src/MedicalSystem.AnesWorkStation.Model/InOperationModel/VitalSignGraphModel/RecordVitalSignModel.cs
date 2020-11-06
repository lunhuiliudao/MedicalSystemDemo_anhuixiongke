// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      RecordVitalSignModel.cs
// 功能描述(Description)：    新增体征项功能对应的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 新增体征项功能对应的实体类
    /// </summary>
    public class RecordVitalSignModel : ObservableObject
    {
        private string itemName;
        private string itemCode;
        private string recordValue;
        private string wamingValue;

        /// <summary>
        /// 体征名称
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set
            {
                itemName = value;
                RaisePropertyChanged("ItemName");
            }
        }

        /// <summary>
        /// 体征编码
        /// </summary>
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        /// <summary>
        /// 手动录入的值
        /// </summary>
        public string RecordValue
        {
            get { return recordValue; }
            set
            {
                recordValue = value;
                RaisePropertyChanged("RecordValue");
            }
        }

        /// <summary>
        /// 体征预警项信息，当超出体征范围时设置
        /// </summary>
        public string WamingValue
        {
            get { return wamingValue; }
            set
            {
                wamingValue = value;
                RaisePropertyChanged("WamingValue");
            }
        }

        /// <summary>
        /// 新增体征项功能对应的实体类：无参构造
        /// </summary>
        public RecordVitalSignModel()
        {
        }
    }
}
