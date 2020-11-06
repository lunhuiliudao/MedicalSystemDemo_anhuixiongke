using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork.Common
{
    public class ImageManage
    {   
        /// <summary>
        /// 根据image获取图片的字节
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(Image image)
        {
            System.IO.MemoryStream mStream = new System.IO.MemoryStream();
            image.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] ret = mStream.ToArray();
            mStream.Close();
            return ret;
        }
    }
}
