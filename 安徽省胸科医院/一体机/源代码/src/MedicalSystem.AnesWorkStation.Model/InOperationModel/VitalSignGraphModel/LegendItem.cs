// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      LegendItem.cs
// 功能描述(Description)：    术中模块中，用药、麻醉等表格的 图例实体类，方便界面绑定
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using System.ComponentModel;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 图例元素
    /// </summary>
    public class LegendItem : ObservableObject
    {
        private string _code;                                        // 图例编码

        /// <summary>
        /// 图例编码
        /// </summary>
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                this.RaisePropertyChanged("Code");
            }
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public SymbolModel Symbol { get; set; }
    }
}
