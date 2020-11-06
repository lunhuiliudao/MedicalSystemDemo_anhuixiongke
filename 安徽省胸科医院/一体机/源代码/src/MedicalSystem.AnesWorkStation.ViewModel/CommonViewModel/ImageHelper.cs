using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace MedicalSystem.Anes.FrameWork
{
    public class ImageHelper
    {
        public static BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage bitImage = new BitmapImage();
                bitImage.BeginInit();
                bitImage.StreamSource = ms;
                bitImage.EndInit();
                return bitImage;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
