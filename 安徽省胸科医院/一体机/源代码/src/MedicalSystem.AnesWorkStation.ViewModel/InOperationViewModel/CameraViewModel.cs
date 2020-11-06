using GalaSoft.MvvmLight.Command;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class CameraViewModel : BaseViewModel
    {
        private List<MED_CAMERA_PICINFO> picInfoList;
        private string ImageName = string.Empty;
        private DateTime PicTime = DateTime.MinValue;
        private MED_CAMERA_PICINFO picInfo;
        public MED_CAMERA_PICINFO PicInfo
        {
            get { return this.picInfo; }
            set
            {
                this.picInfo = value;
                this.RaisePropertyChanged("PicInfo");
            }
        }

        private string photo;
        public string Photo
        {
            get { return this.photo; }
            set
            {
                this.photo = value;
                this.RaisePropertyChanged("Photo");
            }
        }
        private List<MainModel> myModel;
        public List<MainModel> MyModel
        {
            get { return this.myModel; }
            set
            {
                this.myModel = value;
                this.RaisePropertyChanged("MyModel");
            }
        }
        private string imagePath;
        public string ImagePath
        {
            get { return this.imagePath; }
            set
            {
                this.imagePath = value;
                this.RaisePropertyChanged("ImagePath");
            }
        }
        private Visibility playerVisiblity = Visibility.Hidden;
        public Visibility PlayerVisiblity
        {
            get { return this.playerVisiblity; }
            set
            {
                this.playerVisiblity = value;
                this.RaisePropertyChanged("PlayerVisiblity");
            }
        }
        private Visibility picListVisiblity = Visibility.Visible;
        public Visibility PicListVisiblity
        {
            get { return this.picListVisiblity; }
            set
            {
                this.picListVisiblity = value;
                this.RaisePropertyChanged("PicListVisiblity");
            }
        }
        private Visibility picVisibilty = Visibility.Collapsed;
        public Visibility PicVisibilty
        {
            get { return this.picVisibilty; }
            set
            {
                this.picVisibilty = value;
                this.RaisePropertyChanged("PicVisibilty");
            }
        }

        private Visibility picContentVisibilty = Visibility.Collapsed;
        public Visibility PicContentVisibilty
        {
            get { return this.picContentVisibilty; }
            set
            {
                this.picContentVisibilty = value;
                this.RaisePropertyChanged("PicContentVisibilty");
            }
        }

        private Visibility picButtonVisibilty = Visibility.Collapsed;
        public Visibility PicButtonVisibilty
        {
            get { return this.picButtonVisibilty; }
            set
            {
                this.picButtonVisibilty = value;
                this.RaisePropertyChanged("PicButtonVisibilty");
            }
        }
        private BitmapSource picSource;
        public BitmapSource PicSource
        {
            get { return this.picSource; }
            set
            {
                this.picSource = value;
                this.RaisePropertyChanged("PicSource");
            }
        }

        private ICommand updateCommand;
        /// <summary>
        /// 取消按钮命令
        /// </summary>
        public ICommand UpdateCommand
        {
            get { return this.updateCommand; }
            set { this.updateCommand = value; }
        }
        public CameraViewModel()
        {
            LoadDictData();
            MyModel = new List<MainModel>();
            ImagePath = ExtendAppContext.Current.CameraImageLocalPath;
            if(!Directory.Exists(ImagePath))
            {
                Directory.CreateDirectory(ImagePath);
            }
            DirectoryInfo di = new DirectoryInfo(ImagePath);
            FileInfo[] fils = di.GetFiles();
            if(fils!=null)
            {
                foreach(FileInfo fi in fils)
                {
                    MainModel m = new MainModel();
                    m.Photo = ImagePath + fi.Name;
                    MyModel.Add(m);
                }
            }
            picInfoList= CareDocService.ClientInstance.GetPicInfoList(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                           ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                                           ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
           
            RegisterCommand();
        }
        /// <summary>
        /// 加载接受参数
        /// </summary>
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            if (Args !=null)
            {
                PicTime = Convert.ToDateTime(Args[0]);
                PicVisibilty = Visibility.Visible;
                PicButtonVisibilty = Visibility.Collapsed;
                PicListVisiblity = Visibility.Collapsed;
                PlayerVisiblity = Visibility.Collapsed;
                PicContentVisibilty = Visibility.Visible;
                PicInfo = picInfoList.Where(x => x.UPDATE_TIME == PicTime).FirstOrDefault();
                if (PicInfo != null)
                {
                    PicSource = new BitmapImage(new Uri(PicInfo.PIC_PATH));
                }
            }
        }
        public void OpenImageByPath(string path)
        {
            PicInfo = picInfoList.Where(x => x.PIC_PATH == path).FirstOrDefault();
            if(PicInfo==null)
            {
                PicInfo = new MED_CAMERA_PICINFO();
                PicInfo.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                PicInfo.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                PicInfo.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                PicInfo.UPDATE_TIME = DateTime.MinValue;
            }
            ImageName = path.Replace(ExtendAppContext.Current.CameraImageLocalPath, "");
        }
        public void SaveBitemp(BitmapEncoder encoder)
        {
            if (PicInfo == null)
            {
                PicInfo = new MED_CAMERA_PICINFO();
                PicInfo.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                PicInfo.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                PicInfo.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                PicInfo.UPDATE_TIME = DateTime.MinValue;
            }
            string now = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID+
                                                                           ExtendAppContext.Current.PatientInformationExtend.VISIT_ID+
                                                                           ExtendAppContext.Current.PatientInformationExtend.OPER_ID+ DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" +
            DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second;
            ImageName = now + "pic.jpg";
            string filename = ImagePath + now+ "pic.jpg";
            FileStream fsstream = new FileStream(filename, FileMode.Create);
            encoder.Save(fsstream);
            fsstream.Close();
           
        }
        /// <summary>
        /// 注册命令
        /// </summary>
        public void RegisterCommand()
        {
            
            // 上传按钮命令
            this.UpdateCommand = new RelayCommand<object>(par =>
            {
                if (PicInfo.UPDATE_TIME == DateTime.MinValue)
                {
                    PicInfo.UPDATE_TIME = DateTime.Now;
                    PicInfo.PIC_PATH = ExtendAppContext.Current.CameraImageLocalPath + ImageName;
                    PicInfo.PIC_SERVER_PATH = ExtendAppContext.Current.CameraImageServePath + ImageName;
                }
                CareDocService.ClientInstance.SaveCameraPic(PicInfo);
                PublicKeyBoardMessage(KeyCode.AppCode.Save);
            }); 
        }
    }
}
public class MainModel
{
    public string Photo { get; set; }
}
