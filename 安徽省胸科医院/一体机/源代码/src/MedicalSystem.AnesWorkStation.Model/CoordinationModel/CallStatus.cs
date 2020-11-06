// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      CallStatus.cs
// 功能描述(Description)：    通信状态枚举
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

namespace MedicalSystem.AnesWorkStation.Model.CoordinationModel
{
    /// <summary>
    /// 通信状态枚举
    /// </summary>
    public enum CallStatus
    {
        /// <summary>
        /// 空闲
        /// </summary>
        Free = 0,
        /// <summary>
        /// 通话中（和自己）
        /// </summary>
        Calling,
        /// <summary>
        /// 通话中（和其他人）
        /// </summary>
        Called
    }
}
