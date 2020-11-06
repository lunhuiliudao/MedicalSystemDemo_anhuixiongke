// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SymbolCurveDetailModel.cs
// 功能描述(Description)：    图标明细的实体类
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
using System.Drawing;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 图标明细的实体类
    /// </summary>
    public class SymbolCurveDetailModel : ObservableObject
    {
        private string _text;                                   // 文本
        protected SymbolType _symbolType = SymbolType.Circle;   // 图标类型
        protected string _symbolEntry = null;                   // 图标实体
        protected Color _color = Color.Red;                     // 图标填充的颜色

        /// <summary>
        /// 文本
        /// </summary>
        [DisplayName("文本")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
        
        /// <summary>
        /// 图标类型
        /// </summary>
        [Description("标识类型")]
        public SymbolType SymbolType
        {
            get
            {
                return _symbolType;
            }
            set
            {
                _symbolType = value;
            }
        }

        /// <summary>
        /// 图标实体
        /// </summary>
        [Description("标识实体")]
        public string SymbolEntry
        {
            get
            {
                return _symbolEntry;
            }
            set
            {
                _symbolEntry = value;
            }
        }

        /// <summary>
        /// 图标填充颜色
        /// </summary>
        [Description("颜色")]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        /// <summary>
        /// 重写ToString方法，返回图标文本信息
        /// </summary>
        public override string ToString()
        {
            return _text;
        }
    }
}
