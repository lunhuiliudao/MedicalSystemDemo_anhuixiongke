using AForge.Controls;
using AForge.Video.DirectShow;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// PhonoControl.xaml 的交互逻辑
    /// </summary>
    public partial class CameraControl : BaseUserControl
    {
        private CameraViewModel cameraViewModel = null;
        public string videoStr = string.Empty;
        private BitmapSource picSource = null;
        public CameraControl()
        {
            InitializeComponent();
            FormLoad();
            cameraViewModel = new CameraViewModel();
            this.DataContext = cameraViewModel;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        private void FormLoad()
        {
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);   //窗体Load事件
        }


        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 设定初始视频设备
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                videoStr = videoDevices[0].MonikerString;
            }
            else
            {
                button_Play.IsEnabled = false;
                button_Play.Content = "请安装摄像头！";
            }


        }
        private void AppListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                MainModel mm = e.AddedItems[0] as MainModel;
                string path = mm.Photo;
                if (path.Contains("pic"))
                {
                    cameraViewModel.PicVisibilty = Visibility.Visible;
                    cameraViewModel.PicButtonVisibilty = Visibility.Collapsed;
                    cameraViewModel.PicListVisiblity = Visibility.Collapsed;
                    cameraViewModel.PlayerVisiblity = Visibility.Collapsed;
                    cameraViewModel.PicContentVisibilty = Visibility.Visible;
                    cameraViewModel.PicSource= new BitmapImage(new Uri(path));
                  //  imgPhone.Source = cameraViewModel.PicSource;
                    cameraViewModel.OpenImageByPath(path);
                }
                else
                {
                    cameraViewModel.PlayerVisiblity = Visibility.Visible;
                    cameraViewModel.PicListVisiblity = Visibility.Collapsed;
                    cameraViewModel.PicVisibilty = Visibility.Collapsed;
                    cameraViewModel.PicButtonVisibilty = Visibility.Collapsed;
                    cameraViewModel.PicContentVisibilty = Visibility.Collapsed;
                    sourcePlayer.VideoSource = new VideoCaptureDevice(videoStr);
                    sourcePlayer.Start();
                }

            }
        }
        /// <summary>
        /// 摄像头截图
        /// </summary>
        /// <returns></returns>
        private string SnapShot()
        {

            string result = "";
            try
            {

                cameraViewModel.PicSource =
                 System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                               sourcePlayer.GetCurrentVideoFrame().GetHbitmap(),
                               IntPtr.Zero,
                               Int32Rect.Empty,
                               BitmapSizeOptions.FromEmptyOptions());
               // imgPhone.Source = picSource; 
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        private void button_Take_Click(object sender, RoutedEventArgs e)
        {
            SnapShot();
            cameraViewModel.PlayerVisiblity = Visibility.Collapsed;
            cameraViewModel.PicListVisiblity = Visibility.Collapsed;
            cameraViewModel.PicVisibilty = Visibility.Visible;
            cameraViewModel.PicButtonVisibilty = Visibility.Visible;
            cameraViewModel.PicContentVisibilty = Visibility.Collapsed;
        }
        /// <summary>
        /// 启动视频和关闭视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Play_Click(object sender, RoutedEventArgs e)
        {
            sourcePlayer.Stop();
            cameraViewModel.PlayerVisiblity = Visibility.Visible;
            cameraViewModel.PicListVisiblity = Visibility.Collapsed;
            cameraViewModel.PicVisibilty = Visibility.Collapsed;
            cameraViewModel.PicButtonVisibilty = Visibility.Collapsed;
            cameraViewModel.PicContentVisibilty = Visibility.Collapsed;
            sourcePlayer.VideoSource = new VideoCaptureDevice(videoStr);
            sourcePlayer.Start();
        }

        public void button_sure_Click(object sender, RoutedEventArgs e)
        {
            sourcePlayer.Stop();
            cameraViewModel.PlayerVisiblity = Visibility.Collapsed;
            cameraViewModel.PicListVisiblity = Visibility.Collapsed;
            cameraViewModel.PicVisibilty = Visibility.Visible;
            cameraViewModel.PicButtonVisibilty = Visibility.Collapsed;
            cameraViewModel.PicContentVisibilty = Visibility.Visible;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(cameraViewModel.PicSource));
            cameraViewModel.SaveBitemp(encoder);
        }
        
    } 
}
