// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      DurativeIndicatorModel.cs
// 功能描述(Description)：    方便用药类型在界面显示（持续还是单次用药）
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Model.AnesEventEditorModel
{
    /// <summary>
    /// 持续实体类型，方便数据绑定
    /// </summary>
    public class DurativeIndicatorModel : ObservableObject
    {
        private int itemValue = 0;                      // 数据库中保存的值
        private string itemName = string.Empty;         // 界面显示

        /// <summary>
        /// 数据库中保存的值
        /// </summary>
        public int ItemValue
        {
            get { return this.itemValue; }
            set
            {
                this.itemValue = value;
                this.RaisePropertyChanged("ItemValue");
            }
        }

        /// <summary>
        /// 界面显示
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
        public DurativeIndicatorModel(int itemValue, string itemName)
        {
            this.ItemValue = itemValue;
            this.ItemName = itemName;
        }
    }
}
