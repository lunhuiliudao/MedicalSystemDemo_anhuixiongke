/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：GraphHelper.cs
      // 文件功能描述：绘图辅助类
      //
      // 
      // 创建标识：戴呈祥-2008-10-22
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 绘图辅助类
    /// </summary>
    public class GraphHelper
    {
        #region 公用静态方法

        /// <summary>
        /// 画圆角矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="roundWidth">圆角宽度</param>
        /// <param name="color"></param>
        /// <param name="width"></param>
        public static void DrawRoundRect(Graphics g, Rectangle rect, int roundWidth, Color color, float penWidth)
        {
            g.DrawPath(new Pen(color, penWidth), MakeRoundPath(rect, roundWidth));
        }

        public static void FillRoundRect(Graphics g, Rectangle rect, int roundWidth, Color color)
        {
            g.FillPath(new SolidBrush(color), MakeRoundPath(rect, roundWidth));
        }

        private static GraphicsPath MakeRoundPath(Rectangle rect, int roundWidth)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(rect.X, rect.Y, roundWidth * 2, roundWidth * 2), -180, 90);
            path.AddLine(rect.X + roundWidth, rect.Y, rect.Right - roundWidth, rect.Y);
            path.AddArc(new Rectangle(rect.Right - roundWidth * 2, rect.Y, roundWidth * 2, roundWidth * 2), -90, 90);
            path.AddLine(rect.Right, rect.Y + roundWidth, rect.Right, rect.Bottom - roundWidth);
            path.AddArc(new Rectangle(rect.Right - roundWidth * 2, rect.Bottom - roundWidth * 2, roundWidth * 2, roundWidth * 2), 0, 90);
            path.AddLine(rect.Right - roundWidth, rect.Bottom, rect.X + roundWidth, rect.Bottom);
            path.AddArc(new Rectangle(rect.X, rect.Bottom - roundWidth * 2, roundWidth * 2, roundWidth * 2), 180, -90);
            path.AddLine(rect.X, rect.Bottom - roundWidth, rect.X, rect.Y + roundWidth);
            return path;
        }

        public static void DrawCenterText(Graphics g, string text, Font font, Brush brush, Rectangle rect)
        {
            DrawCenterText(g, text, font, brush, new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
        }

        public static void DrawCenterText(Graphics g, string text, Font font, Brush brush, RectangleF rectF)
        {
            float textWidth = g.MeasureString(text, font).Width;
            int lineCount = (int)(textWidth / rectF.Width);
            if (lineCount * rectF.Width < textWidth) lineCount++;
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            if (lineCount < 2)
            {
                stringFormat.Alignment = StringAlignment.Center;
            }
            g.DrawString(text, font, brush, rectF, stringFormat);
        }

        public static void SaveControlToBitmap(Control control, string bmpFileName)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, control.ClientRectangle);
            bmp.Save(bmpFileName);
        }

        public static void ImageToWMF(string imgFileName, string wmfFileName)
        {
            Image image = Image.FromFile(imgFileName);
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            System.Drawing.Imaging.Metafile metafile = new System.Drawing.Imaging.Metafile(wmfFileName, graphics.GetHdc(), rect, System.Drawing.Imaging.MetafileFrameUnit.Pixel);
            graphics = Graphics.FromImage(metafile);
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            graphics.Save();
            graphics.Dispose();
            metafile.Dispose();
        }

        #endregion 公用静态方法

    }
}
