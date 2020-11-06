
namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 同步的进度条
    /// </summary>
    public class SyncProcess
    {
        private int minValue;
        /// <summary>
        /// 最小值
        /// </summary>
        public int MinValue { get { return minValue; } set { minValue = value; } }

        private int value;
        /// <summary>
        /// 当前值
        /// </summary>
        public int Value { get { return value; } set { this.value = value; } }

        private int maxValue;
        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxValue { get { return maxValue; } set { maxValue = value; } }

        private int successValue;
        /// <summary>
        /// 同步成功数
        /// </summary>
        public int SuccessValue { get { return successValue; } set { successValue = value; } }

        private int maxResult;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int MaxResult { get { return maxResult; } set { maxResult = value; } }

        private int result;
        /// <summary>
        /// 记录数
        /// </summary>
        public int Result { get { return result; } set { result = value; } }

        private int successResult;
        /// <summary>
        /// 同步成功记录数
        /// </summary>
        public int SuccessResult { get { return successResult; } set { successResult = value; } }
    }
}