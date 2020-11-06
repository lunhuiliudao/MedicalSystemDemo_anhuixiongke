using System.Collections.Generic;

namespace MedicalSystem.AnesIcuQuery.Models
{
    public class IcuQCDataEntity
    {
        /// <summary>
        /// 结果值
        /// </summary>
        public decimal Result { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        public List<IcuQCPatInfo> DataList { get; set; }
    }
}
