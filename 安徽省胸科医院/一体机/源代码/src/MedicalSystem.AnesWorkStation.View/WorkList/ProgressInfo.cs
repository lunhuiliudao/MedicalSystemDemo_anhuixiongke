// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      ProgressInfo.cs
// 功能描述(Description)：    正在手术面板中的时间进度图片
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    public class ProgressInfo : Image
    {
        private BitmapImage progressPoint = null;                   // 圆点图片

        /// <summary>
        /// 依赖属性：当前手术状态
        /// </summary>
        public static readonly DependencyProperty CurOperStatusCodeProperty = DependencyProperty.Register("CurOperStatusCode",
                                                                                                          typeof(OperationStatus),
                                                                                                          typeof(ProgressInfo),
                                                                                                          new PropertyMetadata(defaultValue: OperationStatus.IsReady,
                                                                                                              propertyChangedCallback: CurOperStatusCodePropertyChangedCallback));

        /// <summary>
        /// 手术状态：根据手术状态显示进度条
        /// </summary>
        public OperationStatus CurOperStatusCode
        {
            set
            {
                SetValue(CurOperStatusCodeProperty, value);
                DrawImage();
            }
            get
            {
                return (OperationStatus)GetValue(CurOperStatusCodeProperty);
            }
        }

        /// <summary>
        /// 圆点图片
        /// </summary>
        public BitmapImage ProgressPoint
        {
            get
            {
                if (this.progressPoint == null)
                {
                    this.progressPoint = ImageHelper.BitmapToBitmapImage(MedicalSystem.AnesWorkStation.View.Properties.Resources.ProgressPoint);
                }

                return this.progressPoint;
            }
        }       

        /// <summary>
        /// 绘制圆点图片
        /// </summary>
        private void DrawImage()
        {
            try
            {
                if (OperationStatus.InOperationRoom > CurOperStatusCode ||
                    OperationStatus.OutOperationRoom < CurOperStatusCode)
                {
                    return;
                }

                RenderTargetBitmap composeImage = new RenderTargetBitmap(450, 14, 96, 96, PixelFormats.Default);
                DrawingVisual drawingVisual = new DrawingVisual();
                DrawingContext drawingContext = drawingVisual.RenderOpen();

                this.DrawLine(ref drawingContext);
                this.DrawPoint(ref drawingContext);
                drawingContext.Close();
                composeImage.Render(drawingVisual);
                this.Source = composeImage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 绘制圆点：根据手术状态绘制点的位置
        /// </summary>
        private void DrawPoint(ref DrawingContext drawingContext)
        {
            int operStatus = this.ConvertOperStatus();
            for (int i = 0; i < operStatus; i++)
            {
                if (i == 0)
                {
                    drawingContext.DrawImage(ProgressPoint, new Rect(0, 0, 14, 14));
                }
                else
                {
                    drawingContext.DrawImage(ProgressPoint, new Rect(i * 90 - 14, 0, 14, 14));
                }
            }
        }

        /// <summary>
        /// 绘制线段：根据手术状态绘制线段
        /// </summary>
        private void DrawLine(ref DrawingContext drawingContext)
        {
            int operStatus = this.ConvertOperStatus();
            Pen pen = new Pen() { Thickness = 4, Brush = new SolidColorBrush(Color.FromRgb(83, 211, 223)) };
            if (operStatus == 6)
            {
                drawingContext.DrawLine(pen, new Point(0, 7), new Point(90 * (operStatus - 1), 7));
            }
            else
            {
                drawingContext.DrawLine(pen, new Point(0, 7), new Point(90 * (operStatus - 1) + 45, 7));
            }
        }

        /// <summary>
        /// 根据手术状态获取绘制的位置
        /// </summary>
        private int ConvertOperStatus()
        {
            int result = -1;
            switch (CurOperStatusCode)
            {
                case OperationStatus.InOperationRoom:
                    result = 1;
                    break;

                case OperationStatus.AnesthesiaStart:
                    result = 2;
                    break;

                case OperationStatus.OperationStart:
                    result = 3;
                    break;

                case OperationStatus.OperationEnd:
                    result = 4;
                    break;

                case OperationStatus.AnesthesiaEnd:
                    result = 5;
                    break;

                case OperationStatus.OutOperationRoom:
                    result = 6;
                    break;

                default:
                    result = 0;
                    break;
            }

            return result;
        }

        /// <summary>
        /// 手术状态变更时触发
        /// </summary>
        private static void CurOperStatusCodePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressInfo proInfo = d as ProgressInfo;
            proInfo.DrawImage();
        }
    }
}
