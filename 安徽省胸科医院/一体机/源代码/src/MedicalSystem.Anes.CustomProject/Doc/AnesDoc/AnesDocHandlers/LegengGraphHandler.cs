// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      LegengGraphHandler.cs
// 功能描述(Description)：    麻醉单图例对应的Handler
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    public class LegengGraphHandler : UIElementHandler<MedLegengGraph>
    {
        /// <summary>
        /// 绑定数据源数据到控件
        /// </summary>
        public override void BindDataToUI(MedLegengGraph control, Dictionary<string, System.Data.DataTable> dataSources)
        {
            MedVitalSignGraph vitalGraph = null;
            foreach (IUIElementHandler handler in MedicalPaperUIElementHandlers)
            {
                if (handler.GetControlType == typeof(MedVitalSignGraph) && handler.GetCurrentControl != null)
                {
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
                }
            }

            control.VitalSign = vitalGraph;
        }

        /// <summary>
        /// 根据体征图标文本信息 获取 对应的体征节点图标
        /// </summary>
        /// <param name="vitalSignGraph">体征控件</param>
        /// <param name="curveText">文本信息</param>
        private MedSymbolCurveDetail GetVitalSignEventMark(MedVitalSignGraph vitalSignGraph, string curveText)
       {
           foreach (MedSymbolCurveDetail curveDetail in vitalSignGraph.EventMarkSettings)
           {
               string text1 = curveText.Trim();
               string text2 = curveDetail.Text.Trim();
               if (text1.ToLower().Equals(text2.ToLower()) || text1.ToLower().StartsWith(text2.ToLower() + "("))
               {
                   return curveDetail;
               }
               else if ((text2.EndsWith("%") && text1.StartsWith(text2.Substring(0, text2.Length - 2))) ||
                        (text2.StartsWith("%") && text1.EndsWith(text2.Substring(1))) ||
                        (text2.StartsWith("%") && text2.EndsWith("%") && text1.Contains(text2.Substring(1, text2.Length - 2))))
               {
                   return curveDetail;
               }
           }

           return null;
       }

       /// <summary>
       ///  绑定控件内容到数据源
       /// </summary>
       public override void BindUIToData(MedLegengGraph control, Dictionary<string, System.Data.DataTable> dataSources)
       {
       }

       /// <summary>
       /// 控件属性事件设置：自定义绘制事件，暂时注释，请勿删除
       /// </summary>
       public override void ControlSetting(MedLegengGraph control)
       {
           //control.CustomDraw -= new PaintEventHandler(MedLegengGraph_CustomDraw);
           //control.CustomDraw += new PaintEventHandler(MedLegengGraph_CustomDraw);
       }
       
       /// <summary>
       /// 自定义绘制事件，绘制图例
       /// </summary>
       private void MedLegengGraph_CustomDraw(object sender, PaintEventArgs e)
       {
           Graphics g = e.Graphics;
           Font font = new Font("宋体", 9);
           Brush brush = Brushes.Black;
           float top = 2;
           float left = 6;
           float left1 = 64;
           float ySpan = 15;
           float symRaid = 5;
           g.DrawString("图例", font, brush, left, top);
           top += ySpan;

           g.DrawString("血    压", font, brush, left, top);
           MedSymbol symbol = new MedSymbol(MedSymbolType.VLetter);
           symbol.Size = 8;
           symbol.Draw(g, left1 + symRaid, top);
           symbol.Draw(g, left1 + symRaid * 3 + 10, top);
           g.DrawLine(Pens.Black, left1 + symRaid, top + symRaid, left1 + symRaid * 3 + 10, top + symRaid);
           symbol.SymbolType = MedSymbolType.VLetterDown;
           top += symRaid * 2 - 2;
           symbol.Draw(g, left1 + symRaid, top + symRaid);
           symbol.Draw(g, left1 + symRaid * 3 + 10, top + symRaid);
           g.DrawLine(Pens.Black, left1 + symRaid, top, left1 + symRaid * 3 + 10, top);
           symbol.Size = symRaid * 2;
           top += ySpan - symRaid * 2 + 4;

           g.DrawString("脉    搏", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.FillCircle;
           symbol.Draw(g, left1 + symRaid, top + symRaid);
           symbol.Draw(g, left1 + symRaid * 3 + 10, top + symRaid);
           g.DrawLine(Pens.Black, left1 + symRaid, top + symRaid, left1 + symRaid * 3 + 10, top + symRaid);
           top += ySpan;

           g.DrawString("自主呼吸", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.Circle;
           symbol.Draw(g, left1 + symRaid, top + symRaid);
           symbol.Draw(g, left1 + symRaid * 3 + 10, top + symRaid);
           g.DrawLine(Pens.Black, left1 + symRaid * 2, top + symRaid, left1 + symRaid * 2 + 10, top + symRaid);
           top += ySpan;

           g.DrawString("机械通气", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.MachineAir;
           symbol.Draw(g, left1 + symRaid + 10, top + symRaid);
           if (ExtendAppContext.Current.EventNo == "0")
           {
               top += ySpan;
               g.DrawString("麻醉开始", font, brush, left, top);
               symbol.SymbolType = MedSymbolType.XCross;
               symbol.Draw(g, left1 + symRaid + 10, top + symRaid);
           }

           top += ySpan;
           g.DrawString("置    管", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.CircleHArrow;
           symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

           top += ySpan;
           g.DrawString("拔    管", font, brush, left, top);
           symbol.SymbolType = MedSymbolType.CircleVArrow;
           symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

           if (ExtendAppContext.Current.EventNo == "0")
           {
               top += ySpan;
               g.DrawString("手术开始", font, brush, left, top);
               symbol.SymbolType = MedSymbolType.CircleDot;
               symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

               top += ySpan;
               g.DrawString("手术结束", font, brush, left, top);
               symbol.SymbolType = MedSymbolType.CircleXCross;
               symbol.Draw(g, left1 + symRaid + 10, top + symRaid);
           }

           top += ySpan;
           g.DrawString("备注:", font, brush, left, top);
           font.Dispose();
       }
    }
}
