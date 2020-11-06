// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      CurveEventArgs.cs
// 功能描述(Description)：    自定义EventArgs：术中界面，涉及到体征绘制事件的事件信息实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.Model.AnesGraphModel
{
    public class CurveEventArgs : RoutedEventArgs
    {
        public CurveEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        { }
        /// <summary>
        /// 曲线上的点
        /// </summary>
        public VitalSignPointModel Point { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime? CurrentTime { get; set; }
    }
}
