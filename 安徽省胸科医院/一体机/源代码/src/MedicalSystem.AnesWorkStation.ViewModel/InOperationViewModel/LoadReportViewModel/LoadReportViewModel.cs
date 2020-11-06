//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      LoadReportViewModel.cs
// 功能描述(Description)：    文书加载 
// 数据表(Tables)：		     无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017-12-27 10:05:39
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.CustomProject;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.Services;
using MedicalSystem.UsbKeyBoard;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MedicalSystem.AnesWorkStation.ViewModel.LoadReportViewModel
{

    /// <summary>
    /// 载入文书ViewModel
    /// </summary>
    public class LoadReportViewModel : BaseViewModel
    {
        private BaseDoc curBaseDoc = null;                     // 文书容器父类
        private string docName;                                // 当前文书名称
        private List<Image> imgList;                           // 图片列表
        private BitmapImage reportImage;                       // 文书对应的图片

        /// <summary>
        /// 文书
        /// </summary>
        public BaseDoc CurBaseDoc
        {
            get { return this.curBaseDoc; }
            set { this.curBaseDoc = value; }
        }

        /// <summary>
        /// 文书对应的图片
        /// </summary>
        public BitmapImage ReportImage
        {
            get
            {
                return this.reportImage;
            }
            set
            {
                this.reportImage = value;
                this.RaisePropertyChanged("ReportImage");
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public LoadReportViewModel()
        {
            this.Register();
        }

        /// <summary>
        /// 等比缩放图片
        /// </summary>
        private Bitmap KiResizeImage(Bitmap bmp, int newW, int newH, int Mode)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Bitmap转BitmapImage
        /// </summary>
        private BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            Bitmap bitmapSource = new Bitmap(bitmap.Width, bitmap.Height);
            int i, j;
            for (i = 0; i < bitmap.Width; i++)
            {
                for (j = 0; j < bitmap.Height; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);
                    Color newColor = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    bitmapSource.SetPixel(i, j, newColor);
                }
            }

            MemoryStream ms = new MemoryStream();
            bitmapSource.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(ms.ToArray());
            bitmapImage.EndInit();
            return bitmapImage;
        }

        /// <summary>
        /// 载入图片
        /// </summary>
        private void LoadImage(int index)
        {
            try
            {
                if (index < 0)
                {
                    return;
                }
                OperationDocLib lib = new OperationDocLib();
                imgList = lib.GetAnesDocImageList(docName);
                Bitmap bmp = imgList[index] as Bitmap;
                bmp = KiResizeImage(bmp, (int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight - 40, 0);
                ReportImage = BitmapToBitmapImage(bmp);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设置文书长宽
        /// </summary>
        private void SetDocSize(string docName)
        {
            if (curBaseDoc == null)
            {
                return;
            }

            //文书长宽需明确设置
            switch (docName)
            {
                case MED_CONSTANT.MA_ZUI_JI_LU:
                    curBaseDoc.Width = 766;
                    curBaseDoc.Height = 1330;
                    break;
                case MED_CONSTANT.MA_ZUI_TONG_YI:
                    curBaseDoc.Width = 760;
                    curBaseDoc.Height = 1330;
                    break;
                case MED_CONSTANT.SHU_QIAN_FANG_SHI:
                    curBaseDoc.Width = 760;
                    curBaseDoc.Height = 1330;
                    break;
                case MED_CONSTANT.SHU_HOU_SUI_FANG:
                    curBaseDoc.Width = 760;
                    curBaseDoc.Height = 1330;
                    break;
                case MED_CONSTANT.SAN_FANG_HE_CHA:
                    curBaseDoc.Width = 760;
                    curBaseDoc.Height = 1330;
                    break;
                case MED_CONSTANT.MA_ZUI_ZONG_JIE:
                    curBaseDoc.Width = 760;
                    curBaseDoc.Height = 1330;
                    break;
                //case MED_CONSTANT.HUI_ZHEN_JI_LU:
                //    curBaseDoc.Width = 760;
                //    curBaseDoc.Height = 1330;
                //    break;
                default:
                    curBaseDoc.Width = 760;
                    curBaseDoc.Height = 1330;
                    break;
            }


        }
        
        /// <summary>
        /// LoadReport窗体载入后触发的事件在此
        /// </summary>
        public override void OnViewLoaded()
        {
            try
            {
                base.OnViewLoaded();
                if (string.IsNullOrEmpty(KeyBoardStateCache.CurrentAppCode))
                {
                    KeyBoardStateCache.CurrentAppCode = AppCode.OtherReport;
                    KeyBoardStateCache.AppCodeStack.Push(KeyBoardStateCache.CurrentAppCode);
                }
                // 从参数获取文书名
                if (this.Args[0] != null)
                {
                    docName = this.Args[0].ToString();
                }

                this.LoadDoc(docName);
            }
            catch (Exception ex)
            {
                Logger.Error("文书加载异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool LoadDoc(string curDocName)
        {
            bool result = true;
            ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument(curDocName);

            //没有找到退出
            if (string.IsNullOrEmpty(document.Caption))
            {
                result = false;
                ShowMessageBox(string.Format("无法加载文书'{0}'的设计模版,请确保模版文件已经存在", curDocName), MessageBoxButton.OK, MessageBoxImage.Error, callBack: (r) =>
                {
                    this.CloseContentWindow();
                    return;
                }, isAsyncShow: true);
            }
            else
            {
                // 载入文书，获取文书名
                ExtendAppContext.Current.CurrentDocName = curDocName;
                ExtendAppContext.Current.CurntOpenForm = new OpenForm(curDocName, null);
                Type t = Type.GetType(document.Type);
                curBaseDoc = Activator.CreateInstance(t) as BaseDoc;
                curBaseDoc.BackColor = Color.White;
                curBaseDoc.Name = curDocName;
                curBaseDoc.HideScrollBar();
                curBaseDoc.Initial();
                curBaseDoc.LoadReport(Path.Combine(System.Windows.Forms.Application.StartupPath, document.Path));
                curBaseDoc.SetAllControlEditable(ExtendAppContext.Current.IsPermission);
                // 设置文书大小
                SetDocSize(curDocName);
            }

            return result;
        }

        /// <summary>
        /// 注册消息
        /// </summary>
        private void Register()
        {
            Messenger.Default.Register<string>(this, EnumMessageKey.QuickChangeDoc, newDocName =>
            {
                try
                {
                    WhirlingControlManager.ShowWaitingForm();
                    // 快速切换文书
                    if (!string.IsNullOrEmpty(newDocName) &&
                        this.CheckDocData() &&
                        this.LoadDoc(newDocName))
                    {
                        keyBoardMessageLock = false;
                        Messenger.Default.Send<string>(newDocName, EnumMessageKey.ResetLoadReport);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("快速切换文书错误", ex);
                }
                finally
                {
                    WhirlingControlManager.CloseWaitingForm();
                }
            });
        }

        /// <summary>
        /// 是否加载失败。
        /// </summary>
        protected bool IsDocNullError()
        {
            if (curBaseDoc == null)
            {
                ShowMessageBox("文书加载失败，不能操作。", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            }

            return false;
        }

        protected override void KeyBoardMessage(string keyCode)
        {
            switch (keyCode)
            {
                case MedicalSystem.Anes.FrameWork.KeyCode.AppCode.Save:
                    if (!IsDocNullError())
                    {
                        curBaseDoc.SaveButton_Click(curBaseDoc, null);
                    }

                    RegisterPublicKeyBoard = false;
                    if (curBaseDoc.SaveResult) // 保存成功时则关闭文书，保存失败则不关闭
                    {
                        this.CloseContentWindow();
                    }
                    break;
                case MedicalSystem.Anes.FrameWork.KeyCode.AppCode.Print:
                    if (!IsDocNullError())
                    {
                        curBaseDoc.PrintButton_Click(curBaseDoc, null);
                    }
                    break;
            }
        }

        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        public override void OnPreviewViewUnLoaded(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !this.CheckDocData();

            if (!e.Cancel) // 关闭窗口时，清除当前打开窗体对象
            {
                ExtendAppContext.Current.CurrentDocName = string.Empty;// 文书加载也清空
                ExtendAppContext.Current.CurntOpenForm = null;
                Messenger.Default.Unregister<string>(this);

                if (curBaseDoc != null && !curBaseDoc.IsDisposed)
                {
                    GC.Collect();
                    GC.Collect();
                    curBaseDoc.Dispose();
                    GC.SuppressFinalize(curBaseDoc);
                    GC.Collect();
                    GC.Collect();
                }
            }
        }

        /// <summary>
        /// 在关闭或者切换前保存文书
        /// </summary>
        private bool CheckDocData()
        {
            bool result = true;
            if (curBaseDoc != null && curBaseDoc.HasDirty())
            {
                keyBoardMessageLock = true;
                ShowMessageBox("当前数据有修改，是否保存数据？", MessageBoxButton.YesNoCancel,
                                              MessageBoxImage.Question,
                                              new Action<MessageBoxResult>((r) =>
                                              {
                                                  if (r == MessageBoxResult.Yes || r == MessageBoxResult.OK)
                                                  {
                                                      curBaseDoc.SaveButton_Click(curBaseDoc, null);
                                                  }
                                                  else if (r == MessageBoxResult.No)
                                                  { }
                                                  else
                                                  {
                                                      keyBoardMessageLock = false;
                                                      result = false;
                                                  }
                                              }));
            }

            return result;
        }

        /// <summary>
        /// 上下页
        /// </summary>
        public override void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.PageUp)
            {
                if (!IsDocNullError())
                    curBaseDoc.PreviousPageButton_Click(curBaseDoc, null);
            }
            else if (e.Key == Key.PageDown)
            {
                if (!IsDocNullError())
                    curBaseDoc.NextPageButton_Click(curBaseDoc, null);
            }
        }
    }
}
