// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      RescueEventArgs.cs
// 功能描述(Description)：    术中界面，涉及到抢救事件的事件信息实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System.Windows;

namespace MedicalSystem.AnesWorkStation.Model.AnesGraphModel
{
    public class RescueEventArgs : RoutedEventArgs
    {
        public RescueEventArgs(RoutedEvent routedEvent, object source)
            : base(routedEvent, source)
        { }

        /// <summary>
        /// 抢救时间段
        /// </summary>
        public RescueTime RescueTimePeroid { get; set; }
    }
}
