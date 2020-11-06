using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Documents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public class CustomPrinter : UIElementPrinter
    {
        public CustomPrinter(CustomBaseDoc baseDoc, PaperSize paperSize, bool pageFromHeight, float printHeight, string pageName)
            : base(baseDoc, paperSize, pageFromHeight, printHeight, pageName)
        {
        }

        protected override void PrintPage(System.Drawing.Imaging.Metafile file, PrintPageEventArgs e, int width, int height)
        {
            // 纸张大小
            float paperWidth = CustomBaseDoc.PaperWidth / 2.54f * 100.0f;
            float paperHeight = CustomBaseDoc.PaperHeight / 2.54f * 100.0f;
            float clipWidth = paperWidth < e.Graphics.VisibleClipBounds.Width ? paperWidth : e.Graphics.VisibleClipBounds.Width;
            float clipHeight = paperHeight < e.Graphics.VisibleClipBounds.Height ? paperHeight : e.Graphics.VisibleClipBounds.Height;

            // 打印机边距
            float marginOX = paperWidth - clipWidth + e.Graphics.VisibleClipBounds.Left;
            float marginOY = paperHeight - clipHeight + e.Graphics.VisibleClipBounds.Top;

            // 左侧留2.5 cm 装订
            //float left = 2.5f / 2.54f * 100.0f;
            float left = CustomBaseDoc.PaperLeftOff / 2.54f * 100.0f;
            // 左右平均分配空间
            float marginX = (clipWidth + marginOX - left - (float)width) / 2;
            if (marginX < 0)
            {
                marginX = 10;
            }
            // 上下平均分配空间，但上面最多空1 cm
            float top = CustomBaseDoc.PaperTopOff / 2.54f * 100.0f;
            float marginY = (clipHeight + marginOY - (float)height) / 2;
            if (marginY > top)
                marginY = top;


            marginX = left + marginX - marginOX / 2;
            marginY = marginY - marginOY / 2;

            if (marginY<30)
            {
                marginY = 30;
            }

            e.Graphics.DrawImage(file, new RectangleF(marginX, marginY, (float)width, (float)height));
        }
    }
}
