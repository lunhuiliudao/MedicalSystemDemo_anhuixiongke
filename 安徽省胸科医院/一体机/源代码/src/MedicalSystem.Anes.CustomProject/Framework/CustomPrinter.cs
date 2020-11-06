// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      CustomPrinter.cs
// 功能描述(Description)：    实现文书打印功能的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document.Documents;
using System.Drawing;
using System.Drawing.Printing;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 实现文书打印功能的实体类
    /// </summary>
    public class CustomPrinter : UIElementPrinter
    {
        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="baseDoc">文书实体</param>
        /// <param name="paperSize">打印纸张大小</param>
        /// <param name="pageFromHeight">打印纸张高度是否由控件高度确认</param>
        /// <param name="printHeight">打印纸张高度</param>
        /// <param name="pageName">文书名称</param>
        public CustomPrinter(CustomBaseDoc baseDoc, PaperSize paperSize, bool pageFromHeight, float printHeight, string pageName)
            : base(baseDoc, paperSize, pageFromHeight, printHeight, pageName)
        {
        }

        /// <summary>
        /// 绘制出文书打印效果，计算打印范围，自动缩放
        /// </summary>
        protected override void PrintPage(System.Drawing.Imaging.Metafile file, PrintPageEventArgs e, int width, int height)
        {
            // 纸张大小
            float paperWidth = CustomBaseDoc.PaperWidth / 2.54f * 100.0f;
            float paperHeight = CustomBaseDoc.PaperHeight / 2.54f * 100.0f;

            if (e.PageSettings.Landscape)
            {
                paperWidth = (float)(29.7 / 2.54f * 100.0f);
                paperHeight = 21 / 2.54f * 100.0f;
            }
            float clipWidth = paperWidth < e.Graphics.VisibleClipBounds.Width ? paperWidth : e.Graphics.VisibleClipBounds.Width;
            float clipHeight = paperHeight < e.Graphics.VisibleClipBounds.Height ? paperHeight : e.Graphics.VisibleClipBounds.Height;

            // 打印机边距
            float marginOX = paperWidth - clipWidth + e.Graphics.VisibleClipBounds.Left;
            float marginOY = paperHeight - clipHeight + e.Graphics.VisibleClipBounds.Top;

            // 左侧留2.5 cm 装订
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
            {
                marginY = top;
            }

            marginX = left + marginX - marginOX / 2;
            marginY = marginY - marginOY / 2;
            e.Graphics.DrawImage(file, new RectangleF(marginX, marginY, (float)width, (float)height));
        }
    }
}
