
namespace MedicalSystem.AnesWorkStation.Domain.Screen
{
    /// <summary>
    /// 字典
    /// </summary>
    public class AnesDict : BaseModel
    {

        /// <summary>
        /// 字典分类
        /// </summary>
        public string itemClass { get; set; }

        /// <summary>
        /// 字典代码
        /// </summary>
        public string itemCode { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        public string itemName { get; set; }

        /// <summary>
        /// 输入字符
        /// </summary>
        public string inputCode { get; set; }

        /// <summary>
        /// 科室代码
        /// </summary>
        public string wardCode { get; set; }

    }
}
