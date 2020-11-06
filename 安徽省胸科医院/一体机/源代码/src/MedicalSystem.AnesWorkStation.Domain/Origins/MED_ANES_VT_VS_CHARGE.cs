using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 计价单项目表与价表项目表对照关系
    /// </summary>
    [Table("MED_ANES_VT_VS_CHARGE")]
    public partial class MED_ANES_VT_VS_CHARGE : BaseModel
    {
        /// <summary>
        /// 主键 项目类别(计价单)
        /// </summary>
        [Key]
        public string VT_ITEM_CALSS { get; set; }
        /// <summary>
        /// 主键 项目编码(计价单)
        /// </summary>
        [Key]
        public string VT_ITEM_CODE { get; set; }
        /// <summary>
        /// 主键 对照序号
        /// </summary>
        [Key]
        public Int32 VS_NO { get; set; }
        /// <summary>
        /// 项目分类(价表)
        /// </summary>
        public string ITEM_CLASS { get; set; }
        /// <summary>
        /// 项目代码(价表)
        /// </summary>
        public string ITEM_CODE { get; set; }
        /// <summary>
        /// 项目名称(价表)
        /// </summary>
        public string ITEM_NAME { get; set; }
        /// <summary>
        /// 项目规格(价表)
        /// </summary>
        public string ITEM_SPEC { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public Nullable<decimal> PRICE { get; set; }
        /// <summary>
        /// 是否划价，不划价，则一个一个最小收费单位 T/F
        /// </summary>
        public string BILL_INDICATOR { get; set; }
        /// <summary>
        /// 当划价标识=T时，计算用量：时长、数量、剂量，1-时长；2-数量；3-剂量
        /// </summary>
        public string METHOD { get; set; }
        /// <summary>
        /// 计费规则
        /// </summary>
        public Nullable<decimal> SPEC { get; set; }
        /// <summary>
        /// 按时长收费时使用(基础时长)，按剂量收费时使用(基础规格),允许小数
        /// </summary>
        public Nullable<decimal> BASE_TIME { get; set; }
        /// <summary>
        /// 基础单位（按时长收费时，默认小时、按剂量收费时，需要输入）
        /// </summary>
        public string BASE_UNIT { get; set; }
        /// <summary>
        /// 如果超过基础时长，则启动超时收费项目，超过的时长÷加收的单位时长
        /// </summary>
        public string ITEM_CODE_ADD { get; set; }
    }
}