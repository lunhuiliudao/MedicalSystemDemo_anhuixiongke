using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.Model.AnesGraphModel
{
    public class IntakeAndOutputDataEventArgs : RoutedEventArgs
    {
        public IntakeAndOutputDataEventArgs(RoutedEvent routedEvent, object source)
            : base(routedEvent, source)
        { }
        /// <summary>
        /// 用药数据
        /// </summary>
        public IntakeAndOutputData DataPoint { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime? BeforeTime { get; set; }

        /// <summary>
        /// 原始的，未被修改的时间
        /// </summary>
        public DateTime? OriginalTime { get; set; }
    }
}
