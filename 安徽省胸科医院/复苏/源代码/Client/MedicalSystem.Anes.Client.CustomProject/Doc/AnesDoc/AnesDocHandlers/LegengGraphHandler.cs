using System;
using System.Collections.Generic;
using System.Text;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using System.Windows.Forms;
using System.Drawing;

namespace MedicalSystem.Anes.Client.CustomProject
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
                    vitalGraph = handler.GetCurrentControl as MedVitalSignGraph;
            }
            control.VitalSign = vitalGraph;
        }
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
       /// <param name="control"></param>
       /// <param name="dataSources"></param>
       public override void BindUIToData(MedLegengGraph control, Dictionary<string, System.Data.DataTable> dataSources)
       {
           
       }
       /// <summary>
       /// 控件属性事件设置
       /// </summary>
       /// <param name="control"></param>
       public override void ControlSetting(MedLegengGraph control)
       {
           control.CustomDraw -= new PaintEventHandler(control_CustomDraw);
           control.CustomDraw += new PaintEventHandler(control_CustomDraw);
       }

       void control_CustomDraw(object sender, PaintEventArgs e)
       {

            Graphics g = e.Graphics;
            Font font = new Font("宋体", 10f);
            Brush brush = Brushes.Black;

            float top = 2;
            float left = 6;
            float left1 = 64;
            float ySpan = 18;// 15;
            float symRaid = 5;
            g.DrawString("图例", font, brush, left, top);
            MedSymbol symbol = new MedSymbol(MedSymbolType.VLetter);

            symbol.Size = symRaid * 2;

            top += ySpan;
            g.DrawString("舒 张 压", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.VLetterDown;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

            top += ySpan;
            g.DrawString("收 缩 压", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.VLetter;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

            top += ySpan;
            g.DrawString("中心静脉压", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.Triangle;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

            top += ySpan;
            g.DrawString("动脉平均压", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.Diamond;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

            top += ySpan;
            g.DrawString("呼    吸", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.Circle;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

            top += ySpan;
            g.DrawString("心    率", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.FillMiniCircle;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

            if (ExtendApplicationContext.Current.EventNo == "0")
            {
                top += ySpan;
                g.DrawString("麻醉开始", font, brush, left, top);
                symbol.SymbolType = MedSymbolType.XCross;
                symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

                top += ySpan;
                g.DrawString("麻醉结束", font, brush, left, top);
                symbol.SymbolType = MedSymbolType.CircleXCross;
                symbol.Draw(g, left1 + symRaid + 10, top + symRaid);
            }

            top += ySpan;
            g.DrawString("气管插管", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.CircleHLine;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

            top += ySpan;
            g.DrawString("气管拔管", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.PullPipe1;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

            top += ySpan;
            g.DrawString("置入喉罩", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.InHouZhao;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);

            top += ySpan;
            g.DrawString("拔出喉罩", font, brush, left, top);
            symbol.SymbolType = MedSymbolType.OutHouZhao;
            symbol.Draw(g, left1 + symRaid + 10, top + symRaid);


            if (ExtendApplicationContext.Current.EventNo == "0")
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

            font.Dispose();
        }
    }
}
