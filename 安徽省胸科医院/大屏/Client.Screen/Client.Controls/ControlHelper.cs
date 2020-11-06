using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalSystem.MedScreen.Controls
{
    /// <summary>
    /// 控件辅助类
    /// </summary>
    public class ControlHelper
    {
        
        /// <summary>
        /// 根据控件高度，获取显示字体大小
        /// </summary>
        /// <param name="height"></param>
        /// <param name="fontName"></param>
        /// <returns></returns>
        public static float GetFontSizeByHeight(float height, string fontName)
        {
            Button btn = new Button();
            float size = 3;
            Font font = new Font(fontName, size);
            float h = btn.CreateGraphics().MeasureString("我", font).Height;
            while (h < height)
            {
                if(h < height /3f)
                {
                    size = size * 2;
                }
                else if (h < height / 2f)
                {
                    size += 0.5F;
                }
                else size += 0.1F;
                font = new Font(fontName, size);
                h = btn.CreateGraphics().MeasureString("我", font).Height;
            }
            return size;
        }

        /// <summary>
        /// 根据控件宽度，获取显示字体大小
        /// </summary>
        /// <param name="width"></param>
        /// <param name="fontName"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float GetFontSizeByWidth(float width, string fontName, string str)
        {
            Button btn = new Button();
            float size = 3;
            Font font = new Font(fontName, size);
            float w = btn.CreateGraphics().MeasureString(str, font).Width;
            while (w < width)
            {
                if (w < width / 3f)
                {
                    size = size * 2;
                }
                else if (w < width / 2f)
                {
                    size += 0.5F;
                }
                else size += 0.1F;
                font = new Font(fontName, size);
                w = btn.CreateGraphics().MeasureString(str, font).Width;
            }
            return size;
        }
    }
}
