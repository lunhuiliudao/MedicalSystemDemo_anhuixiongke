// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      OperationCanceledTypeModel.cs
// 功能描述(Description)：    手术取消类型，方便绑定界面
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
    /// 手术取消类型，方便绑定界面
    /// </summary>
    public class OperationCanceledTypeModel : ObservableObject
    {
        private bool isChecked = false;                                       // 选中状态
        private string itemClass = string.Empty;                              // 取消类型类别
        private string itemName = string.Empty;                               // 取消类型名称

        /// <summary>
        /// 选中状态
        /// </summary>
        public bool IsChecked
        {
            get { return this.isChecked; }
            set
            {
                this.isChecked = value;
                this.RaisePropertyChanged("IsChecked");
            }
        }

        /// <summary>
        /// 取消类型类别
        /// </summary>
        public string ItemClass
        {
            get { return this.itemClass; }
            set
            {
                this.itemClass = value;
                this.RaisePropertyChanged("ItemClass");
            }
        }

        /// <summary>
        /// 取消类型名称
        /// </summary>
        public string ItemName
        {
            get { return this.itemName; }
            set
            {
                this.itemName = value;
                this.RaisePropertyChanged("ItemName");
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationCanceledTypeModel(bool isChecked, string itemClass, string itemName)
        {
            this.isChecked = isChecked;
            this.itemClass = itemClass;
            this.itemName = itemName;
        }
    }
}
