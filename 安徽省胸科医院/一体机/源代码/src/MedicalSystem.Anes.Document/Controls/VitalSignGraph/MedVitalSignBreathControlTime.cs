using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
   public class MedVitalSignBreathControlTime
   {
       public DateTime startTime ;
       public DateTime endTime ;
       public BreathControlType BreathType;
        //原始的未调整到5分钟节点的时间
       public DateTime oStartTime;
       public DateTime oEndTime;
       public double breathValue = 0;
        //呼吸参数
       public List<string> list;
        //时间显示间隔
       public int showTimeInterval = 10;
       //显示颜色
       public Color curveColor = Color.Magenta;
   }

   [Serializable]
   public enum BreathControlType
   {
       /// <summary>
       /// 控制呼吸
       /// </summary>
       ControlBreath,
       /// <summary>
       /// 自由呼吸
       /// </summary>
       FreeBreath,
       /// <summary>
       /// 辅助呼吸
       /// </summary>
       HelpBreath,
       /// <summary>
       /// 其他呼吸
       /// </summary>
       OtherBreath,
       /// <summary>
       /// 非呼吸
       /// </summary>
       NotBreath
   }
}
