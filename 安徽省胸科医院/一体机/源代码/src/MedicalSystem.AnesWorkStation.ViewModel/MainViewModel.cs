// ��������������������������������������������������������������������
// �ļ�����(File Name)��      MainViewModel.cs
// ��������(Description)��    �������Ӧ��ViewModel
// ���ݱ�(Tables)��		      ������
// ����(Author)��             MDSD
// ����(Create Date)��        2017/12/26 13:28
// R1:
//    �޸�����:
//    �޸�����:
//    �޸�����:
//��������������������������������������������������������������������
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private object locker = new object();                                             // ˢ����
        private Visibility tomorrowSurgeryVisibility = Visibility.Visible;                // ����������Ϣ���� Ĭ����ʾ 
        private Visibility weekSurgeryVisibility = Visibility.Collapsed;                  // һ��������Ϣ���� Ĭ�ϲ���ʾ
        private Visibility searchPatientListVisibility = Visibility.Collapsed;            // ��������б���ʾ���Ĭ�ϲ���ʾ
        private int patientListHeight = 262;  //��ѯ�б�߶�
        private int wordListHeight = 860;  //�����б�߶�
        /// <summary>
        /// ����������Ϣ���� Ĭ����ʾ 
        /// </summary>
        public Visibility TomorrowSurgeryVisibility
        {
            get { return this.tomorrowSurgeryVisibility; }
            set
            {
                this.tomorrowSurgeryVisibility = value;
                this.RaisePropertyChanged("TomorrowSurgeryVisibility");
            }
        }

        /// <summary>
        /// һ��������Ϣ���� Ĭ�ϲ���ʾ
        /// </summary>
        public Visibility WeekSurgeryVisibility
        {
            get { return this.weekSurgeryVisibility; }
            set
            {
                this.weekSurgeryVisibility = value;
                this.RaisePropertyChanged("WeekSurgeryVisibility");
            }
        }

        /// <summary>
        /// ��������б���ʾ���Ĭ�ϲ���ʾ
        /// </summary>
        public Visibility SearchPatientListVisibility
        {
            get { return this.searchPatientListVisibility; }
            set
            {
                this.searchPatientListVisibility = value;
                this.RaisePropertyChanged("SearchPatientListVisibility");
            }
        }
        /// <summary>
        /// ��ѯ�б�߶�
        /// </summary>
        public int PatientListHeight
        {
            get { return this.patientListHeight; }
            set
            {
                this.patientListHeight = value;
                this.RaisePropertyChanged("PatientListHeight");
            }
        }
        /// <summary>
        /// �����б�߶�
        /// </summary>
        public int WordListHeight
        {
            get { return this.wordListHeight; }
            set
            {
                this.wordListHeight = value;
                this.RaisePropertyChanged("WordListHeight");
            }
        }
        /// <summary>
        /// ���췽��
        /// </summary>
        public MainViewModel()
        {
            // ���ݷ�����ʱ�����ñ��ص���ʱ��
            SetLocalSystemDate();
            this.RegisterMessage();
        }

        /// <summary>
        /// ע����Ӧ��Ϣ
        /// </summary>
        public void RegisterMessage()
        {
            this.RegisterPublicKeyBoard = false;
            this.RegisterKeyBoardMessage();
        }

        /// <summary>
        /// ע��������Ӧ��Ϣ
        /// </summary>
        public void UnRegisterMessage()
        {
            this.UnRegisterKeyBoardMessage();
        }

        /// <summary>
        /// ������Ӧ�¼����ṩ����ģ�����
        /// </summary>
        /// <param name="keyCode">��������</param>
        protected override void KeyBoardMessage(string keyCode)
        {
            if (KeyBoardStateCache.AppCodeStack.Count == 0 &&
                (null == ExtendAppContext.Current.CurntOpenForm ||
                 ExtendAppContext.Current.CurntOpenForm.FormName.Equals("MainWindow")))
            {
                // ��Ӧ��ݼ���������
                if (ApplicationConfiguration.ShortCuts.ContainsKey(keyCode))
                {
                    string value = ApplicationConfiguration.ShortCuts[keyCode];
                    // �ж��ǲ�������
                    if (!string.IsNullOrEmpty(ApplicationConfiguration.GetMedicalDocument(value).Caption))
                    {
                        ExtendAppContext.Current.CurntOpenForm = new OpenForm(value, null);
                        this.ShowDocByDocName(value);
                    }
                    else
                    {
                        // ��ݼ���Ӧ���ܰ���
                        switch (value)
                        {
                            case "Ѫ������":
                                this.BloodGasAnalysisControlMethod();
                                break;
                            case "������ת":
                                this.OperatioinJumpMethod();
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ������ʱ�䱣�ֺͷ�����ʱ��һ��
        /// </summary>
        public static void SetLocalSystemDate()
        {
            DateTime dt = CommonService.ClientInstance.GetServerTime();
            WinAPI.SYSTEMTIME st;

            st.year = (short)dt.Year;
            st.month = (short)dt.Month;
            st.dayOfWeek = (short)dt.DayOfWeek;
            st.day = (short)dt.Day;
            st.hour = (short)dt.Hour;
            st.minute = (short)dt.Minute;
            st.second = (short)dt.Second;
            st.milliseconds = (short)dt.Millisecond;

            WinAPI.SetLocalTime(ref st);
        }

        /// <summary>
        /// ������������ж�����ʾ��������������Ϣ����һ������������Ϣ
        /// </summary>
        public void SwitchSurgeryExecute(object parameter)
        {
            EnumWorkListType tarWorkList = EnumWorkListType.Unknow;
            if (null != parameter && Enum.TryParse<EnumWorkListType>(parameter.ToString(), out tarWorkList) && tarWorkList != EnumWorkListType.Unknow)
            {
                this.TomorrowSurgeryVisibility = tarWorkList == EnumWorkListType.UnFinishWorkList ? Visibility.Visible : Visibility.Collapsed;
                this.WeekSurgeryVisibility = tarWorkList == EnumWorkListType.FinishWorkList ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        /// <summary>
        /// ���ܲ˵���ť����
        /// </summary>
        public ICommand BottomMenu
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    var message = new ShowContentWindowMessage("BottomMenu", "");
                    message.WindowType = ContentWindowType.ToolBox;
                    message.Height = MED_CONSTANT.TOOL_BAR_HEIGHT;
                    message.Width = SystemParameters.PrimaryScreenWidth;
                    message.IsModal = false;
                    message.PositionX = 0;
                    message.PositionY = SystemParameters.PrimaryScreenHeight - message.Height;
                    message.TileBackground = Brushes.Transparent;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                });
            }
        }

        /// <summary>
        /// �رմ����¼�
        /// </summary>
        public override void OnPreviewViewUnLoaded(System.ComponentModel.CancelEventArgs e)
        {
            base.OnPreviewViewUnLoaded(e);
            // �رճ���ʱ�����м��̵�����
            KeyBoardStateCache.KeyBoard.CloseMainKeyBoardAllLed();
            KeyBoardStateCache.KeyBoard.CloseSecondKeyBoardAllLed();
            Messenger.Default.Unregister<string>(this);
        }
    }
}