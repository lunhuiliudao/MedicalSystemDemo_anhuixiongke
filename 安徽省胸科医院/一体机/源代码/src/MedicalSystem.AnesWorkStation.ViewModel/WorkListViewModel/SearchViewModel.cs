using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        private string _OPER_ROOM_NO;                                              // 手术间号
        private DateTime _SCHEDULED_DATE_TIME;                                     // 手术日期
        private string _INPUT_TEXT; //输入内容
        private List<MED_OPERATING_ROOM> _medOperatingRoomDict;                    // 手术间

        private ICommand searchCommand = null;                                                     // 搜索命令
        private ICommand searchTextChangedCommand;                                                 // 搜索文本框文本改变命令
        /// <summary>
        /// 手术间号
        /// </summary>
        public string OPER_ROOM_NO
        {
            get
            {
                return _OPER_ROOM_NO;
            }
            set
            {
                this._OPER_ROOM_NO = value;
                RaisePropertyChanged("OPER_ROOM_NO");
            }
        }
        /// <summary>
        /// 手术日期
        /// </summary>
        public DateTime SCHEDULED_DATE_TIME
        {
            get { return _SCHEDULED_DATE_TIME; }
            set
            {
                _SCHEDULED_DATE_TIME = value;
                RaisePropertyChanged("SCHEDULED_DATE_TIME");
            }
        }
        /// <summary>
        /// 输入内容
        /// </summary>
        public string INPUT_TEXT
        {
            get
            {
                return _INPUT_TEXT;
            }
            set
            {
                this._INPUT_TEXT = value;
                RaisePropertyChanged("INPUT_TEXT");
            }
        }
        /// <summary>
        /// 手术间字典绑定
        /// </summary>
        public List<MED_OPERATING_ROOM> MED_OPERATING_ROOM
        {
            get { return this._medOperatingRoomDict; }
            set
            {
                this._medOperatingRoomDict = value;
                RaisePropertyChanged("MED_OPERATING_ROOM");
            }
        }
        /// <summary>
        /// 搜索命令
        /// </summary>
        public ICommand SearchCommand
        {
            get { return this.searchCommand; }
            set { this.searchCommand = value; }
        }

        /// <summary>
        /// 搜索文本框文本改变命令
        /// </summary>
        public ICommand SearchTextChangedCommand
        {
            get { return this.searchTextChangedCommand; }
            set { this.searchTextChangedCommand = value; }
        }
        /// <summary>
        /// 构造
        /// </summary>
        public SearchViewModel()
        {
            if (!this.IsInDesignMode)
            {
                MED_OPERATING_ROOM = ApplicationModel.Instance.AllDictList.OperatingRoomList.Where(x => x.BED_TYPE == ExtendAppContext.Current.EventNo && x.DEPT_CODE == ExtendAppContext.Current.OperDeptCode).OrderBy(x => x.SORT_NO).ToList();
                SCHEDULED_DATE_TIME = DateTime.Now;
                // OPER_ROOM_NO = ExtendAppContext.Current.OperRoomNo;
                this.RegisterMessage();
            }
        }
        /// <summary>
        /// 注册命令
        /// </summary>
        private void RegisterMessage()
        {
            // 搜索命令
            this.SearchCommand = new RelayCommand<dynamic>(key =>
            {
                SendSearchCommand();
            });

            // 搜索框文本内容更改命令：当文本为空时隐藏列表同时主动释放资源
            this.SearchTextChangedCommand = new RelayCommand<dynamic>(key =>
            {
                this.INPUT_TEXT = key;
                SendSearchTextChangedCommand();
            });
        }
        public void SendSearchCommand()
        {
            this.Result = new { inputText = this.INPUT_TEXT == null ? "" : this.INPUT_TEXT, scheduledTime = this.SCHEDULED_DATE_TIME.Date, roomNo = this.OPER_ROOM_NO };
            Messenger.Default.Send<dynamic>(this.Result, EnumMessageKey.SearchCommand);
        }
        public void SendSearchTextChangedCommand()
        {
            this.Result = new { inputText = this.INPUT_TEXT, scheduledTime = this.SCHEDULED_DATE_TIME.Date, roomNo = this.OPER_ROOM_NO };
            Messenger.Default.Send<dynamic>(this.Result, EnumMessageKey.SearchTextChangedCommand);
        }
    }
}
