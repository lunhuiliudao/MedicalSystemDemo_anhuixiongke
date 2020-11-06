// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      ImageSource.xaml.cs
// 功能描述(Description)：    根据急诊、隔离等信息显示对应的图标
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// 图标枚举
    /// </summary>
    public enum EnumImagePath
    {
        /// <summary>
        /// 放射标志
        /// </summary>
        RadiateInd,

        /// <summary>
        /// 隔离标志
        /// </summary>
        IsolationInd,

        /// <summary>
        /// 急诊标志
        /// </summary>
        EmergencyInd,

        /// <summary>
        /// 急诊标志：如果是择期则不显示图片
        /// </summary>
        EmergencyIndNotShow,

        /// <summary>
        /// ASA标识
        /// </summary>
        AsaGrade,

        /// <summary>
        /// 未知
        /// </summary>
        UnKnow,
    }

    /// <summary>
    /// 自定义图标控件：可以绑定图片路径
    /// </summary>
    public partial class ImageSource : UserControl
    {
        /// <summary>
        /// 依赖属性：图片路径的值
        /// </summary>
        public static readonly DependencyProperty ImagePathValueProperty = DependencyProperty.Register("ImagePathValue",
                                                                                                       typeof(string),
                                                                                                       typeof(ImageSource),
                                                                                                       new PropertyMetadata(defaultValue: "-1",
                                                                                                                            propertyChangedCallback: ImagePathValuePropertyChangedCallback));

        public static readonly DependencyProperty CurEnumImagePathProperty = DependencyProperty.Register("CurEnumImagePath",
                                                                                                         typeof(EnumImagePath),
                                                                                                         typeof(ImageSource),
                                                                                                         new PropertyMetadata(defaultValue:EnumImagePath.UnKnow,
                                                                                                                              propertyChangedCallback: CurEnumImagePathPropertyChangedCallback));

        /// <summary>
        /// 当前图片的类型
        /// </summary>
        public EnumImagePath CurEnumImagePath
        {
            get { return (EnumImagePath)GetValue(CurEnumImagePathProperty); }
            set { SetValue(CurEnumImagePathProperty, value); }
        }

        /// <summary>
        /// 图片路径的值
        /// </summary>
        public string ImagePathValue
        {
            get { return (string)GetValue(ImagePathValueProperty); }
            set { SetValue(ImagePathValueProperty, value); }
        }

        public ImageSource()
        {
            InitializeComponent();
            this.RefreshImage();
        }

        /// <summary>
        /// 数据值更改后自动更改图片
        /// </summary>
        private static void ImagePathValuePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ImageSource;
            control.RefreshImage();
        }

        public static void CurEnumImagePathPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ImageSource;
            control.RefreshImage();
        }

        /// <summary>
        /// 刷新图片
        /// </summary>
        private void RefreshImage()
        {
            try
            {
                string strImagePath = string.Empty;
                switch (this.CurEnumImagePath)
                {
                    case EnumImagePath.RadiateInd:
                        strImagePath = this.ImagePathValue == "1" ? "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/放射.png" :
                                                                  "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/放射2.png";
                        break;

                    case EnumImagePath.IsolationInd:
                        strImagePath = this.ImagePathValue == "1" ? "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/隔离.png" :
                                                                  "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/隔离2.png";
                        break;

                    case EnumImagePath.EmergencyInd:
                        strImagePath = this.ImagePathValue == "1" ? "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/急救.png" :
                                                                  "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/急救2.png";
                        break;

                    case EnumImagePath.EmergencyIndNotShow:
                        strImagePath = this.ImagePathValue == "1" ? "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/急救.png" :
                                                                  "";
                        break;

                    case EnumImagePath.AsaGrade:
                        // 当前仅考虑Ⅰ,Ⅱ,Ⅲ,Ⅳ,Ⅴ
                        switch (this.ImagePathValue)
                        {
                            case "Ⅰ":
                            case "Ⅰ级":
                            case "一级":
                            case "1级":
                                strImagePath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA1.png";
                                break;
                            case "Ⅱ":
                            case "Ⅱ级":
                            case "二级":
                            case "2级":
                                strImagePath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA2.png";
                                break;
                            case "Ⅲ":
                            case "Ⅲ级":
                            case "三级":
                            case "3级":
                                strImagePath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA3.png";
                                break;
                            case "Ⅳ":
                            case "Ⅳ级":
                            case "四级":
                            case "4级":
                                strImagePath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA4.png";
                                break;
                            case "Ⅴ":
                            case "Ⅴ级":
                            case "五级":
                            case "5级":
                                strImagePath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA5.png";
                                break;
                            case "Ⅵ":
                            case "Ⅵ级":
                            case "六级":
                            case "6级":
                                strImagePath = "/MedicalSystem.AnesWorkStation.View;component/WorkList/Assets/icon/ASA6.png";
                                break;

                            default:
                                break;
                        }

                        break;

                    default:
                        break;
                }

                if (string.IsNullOrEmpty(strImagePath))
                {
                    this.curImage.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    this.curImage.Visibility = System.Windows.Visibility.Visible;
                    this.curImage.Source = new BitmapImage(new Uri(strImagePath, UriKind.RelativeOrAbsolute));
                }
            }
            catch (Exception)
            { 
                
            }
        }
    }
}
