using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.MedScreen.Controls
{
    public class ImgHelper
    {

        public static Metafile GetMetaFile()
        {
            MemoryStream ms = new MemoryStream();
            Button btn = new Button();
            Graphics grfx = btn.CreateGraphics();
            IntPtr ipHdc = grfx.GetHdc();
            Metafile metafile = new Metafile(ms, ipHdc);
            grfx.ReleaseHdc(ipHdc);
            grfx.Dispose();
            ms.Dispose();
            return metafile;
        }

        /// <summary>
        /// 图片无损放大
        /// </summary>
        /// <param name="ImgSource">图片源</param>
        /// <param name="ImageWidth">目标图片长</param>
        /// <param name="ImageHeight">目标图片高</param>
        /// <returns></returns>
        public static Image GetImage(Image ImgSource, float ImageWidth, float ImageHeight)
        {

            Metafile metafile = GetMetaFile();
            Graphics metaGraphics = Graphics.FromImage(metafile);
            metaGraphics.DrawImage(ImgSource, new Point(0, 0));
            metaGraphics.Save();
            metaGraphics.Dispose();
            Image imgResult = new Bitmap((int)ImageWidth + 1, (int)ImageHeight + 1);
            Graphics gp = Graphics.FromImage(imgResult); ;
            gp.DrawImage(metafile, 0, 0, ImageWidth, ImageHeight);
            gp.Save();
            gp.Dispose();
            metafile.Dispose();
            return imgResult;
        }

    }
}
